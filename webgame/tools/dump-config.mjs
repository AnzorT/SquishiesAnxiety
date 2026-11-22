// Reads, from the design prototype itself (running in headless Chromium), everything the admin can control:
//   - every creature (118) with every animation it can play and its walk style
//   - every house item (the renovation catalog after all the designer's edits, plus the Beach) with price and level
// and writes webgame/data/game-config.json. tools/firebase/seed-game-config.mjs uploads that file to Firestore.
//
//   node webgame/tools/dump-config.mjs
//
// Re-run it when a new prototype zip comes in (new creatures, new animations, new items).
import fs from 'node:fs';
import path from 'node:path';
import http from 'node:http';
import { createRequire } from 'node:module';
import { extractPrototype, WEBGAME, PROTOTYPE_ZIP } from '../lib/prototype.mjs';

const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
const PROTO = await extractPrototype();
const OUT = path.join(WEBGAME, 'data/game-config.json');

const TYPES = { '.html': 'text/html', '.js': 'text/javascript', '.svg': 'image/svg+xml', '.png': 'image/png', '.webp': 'image/webp', '.csv': 'text/csv', '.mp3': 'audio/mpeg' };
const server = http.createServer((q, s) => {
  const f = path.join(PROTO, decodeURIComponent(q.url.split('?')[0]));
  fs.readFile(f, (e, b) => { if (e) { s.writeHead(404); s.end(); return; } s.writeHead(200, { 'Content-Type': TYPES[path.extname(f)] || 'application/octet-stream' }); s.end(b); });
}).listen(0);
const BASE = `http://localhost:${server.address().port}/`;

async function open(browser, page, ready, timeout) {
  const p = await browser.newPage();
  await p.route(/unpkg\.com\/react-dom@18\.3\.1/, r => r.fulfill({ path: path.join(WEBGAME, 'vendor/react-dom.production.min.js'), contentType: 'text/javascript' }));
  await p.route(/unpkg\.com\/react@18\.3\.1/, r => r.fulfill({ path: path.join(WEBGAME, 'vendor/react.production.min.js'), contentType: 'text/javascript' }));
  await p.route(/fonts\.(googleapis|gstatic)\.com/, r => r.fulfill({ body: '', contentType: 'text/css' }));
  await p.goto(BASE + encodeURIComponent(page));
  await p.waitForFunction(ready, null, { timeout, polling: 500 });
  return p;
}

const browser = await chromium.launch();

// ---- creatures and their animations (the All Creatures page loads every rig, family and house script) ----
const anim = await open(browser, 'All Creatures Animations.dc.html',
  () => window.SquishSquad && window.RiveRig && window.RiveRig.GROUPS && window.RiveRig.HS && window.RiveRig.idleV && window.HouseWalk && window.RiveGeneric, 60000);
await anim.waitForTimeout(3000);
const creatures = await anim.evaluate(() => {
  const R = window.RiveRig, out = [], h = document.body.appendChild(document.createElement('div'));
  const rigIds = R.GROUPS.flatMap(g => g.items.map(i => i[0]));
  const houseIds = [...new Set(Object.keys(R.HS).map(n => n.split('@')[0]))].filter(n => !/^hf\d/.test(n));
  for (const c of window.SquishSquad.ROSTER) {
    const ck = (window.SQ_ALIAS || {})[c.key] || c.key;
    try { R.mount(h, c.key, { fidgets: false }).destroy(); } catch (e) { /* a broken rig still lists its states */ }
    const has = n => !!(R.STATES[n + '@' + ck] || (R.STATES[n] && n !== 'idle_quirk'));
    const rig = rigIds.filter(has);
    const house = houseIds.filter(n => R.HS[n + '@' + ck] || R.HS[n]);
    const fidgets = R.FIDK[ck] || [];
    const own = Object.getOwnPropertyNames(R.STATES).filter(n => n.endsWith('@' + ck)).map(n => n.split('@')[0]);
    const names = (R.DESC && R.DESC[ck]) || {};
    const all = [...new Set(['idle', ...rig, ...fidgets, ...house, ...own])].filter(n => n !== 'idle');
    out.push({ id: c.id, key: c.key, name: c.name, set: c.set, rar: c.rar, move: c.move || null, gait: window.HouseWalk.prof(ck).g || 'trot',
      animations: all.sort(), own: [...new Set(own)].sort(), titles: Object.fromEntries(Object.entries(names).map(([k, v]) => [k, Array.isArray(v) ? v[0] : String(v)])) });
  }
  return { creatures: out, gaits: Object.keys(window.HouseWalk.G) };
});
await anim.close();

// ---- house items: the catalog exactly as the house builds it (CSV + every RD.edit + Beach) ----
const house = await open(browser, 'Squad House v6.dc.html', () => window.__sh && window.__sh.byId && window.__sh.byId.size > 500, 120000);
const items = await house.evaluate(() => [...window.__sh.byId.values()].map(r => ({
  id: r.id, room: r.room, name: r.name, slot: r.slotName || null, cat: r.cat || null, tier: r.tier, tierName: r.tierName || null, rarity: r.rarity || null, lv: r.lv, cost: r.cost,
})));
const catalogIds = await house.evaluate(() => (window.__sh.rows || []).map(r => r.id));
await house.close();
await browser.close();
server.close();

// "bedin", "bedout", "bedwake" are the steps into and out of "bed": they follow bed's switch (app/config.js does the
// same at runtime), so the admin sees one switch per animation
const allIds = new Set(creatures.creatures.flatMap(c => c.animations));
const variantOf = {};
for (const id of allIds) { const m = /^(.+?)(in|out|wake)$/.exec(id); if (m && allIds.has(m[1])) variantOf[id] = m[1]; }
for (const c of creatures.creatures) c.animations = c.animations.filter(a => !variantOf[a]);
const shown = new Set(catalogIds);
const data = {
  prototype: path.basename(PROTOTYPE_ZIP),
  generated: new Date().toISOString(),
  gaits: creatures.gaits,
  variantOf,
  creatures: creatures.creatures,
  items: items.map(i => ({ ...i, inCatalog: shown.has(i.id) })).sort((a, b) => a.id.localeCompare(b.id)),
};
fs.mkdirSync(path.dirname(OUT), { recursive: true });
fs.writeFileSync(OUT, JSON.stringify(data, null, 1) + '\n');
const nAnim = data.creatures.reduce((s, c) => s + c.animations.length, 0);
console.log(`${data.creatures.length} creatures (${nAnim} creature animations), ${data.items.length} house items -> ${path.relative(process.cwd(), OUT)}`);
