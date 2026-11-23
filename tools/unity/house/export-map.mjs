// The house map (HOUSE_PORT_PLAN.md stage 8) for Unity (House/HouseMap.cs, House/View/HouseMapView.cs): the map's
// picture is the page's own <svg> template (written to Resources/House/map-template.html) filled with the page's own
// mapVals, which the draw host runs (tools/unity/house/draw-host.js __house.map). This writes the template and the
// map's small pieces (the Back button, the pin and padlock of the room labels, the weather icons; their SVG as the
// page has them, bindings filled in by Unity), and checks the host's values against the page's for each fixture.
//
//   node tools/unity/rig/bundle.mjs && node tools/unity/house/export-map.mjs
import fs from 'node:fs';
import path from 'node:path';
import vm from 'node:vm';
import zlib from 'node:zlib';
import { launch, openHouse, REPO } from './harness.mjs';
import { loadFixtures } from './fixtures.mjs';
import { fontData, HERE as UI, snap } from '../ui/snap-page.mjs';

const OUT = path.join(REPO, 'unity/Assets/Resources/House');
const dir = fs.readdirSync(path.join(REPO, 'webgame/.cache')).find((d) => d.startsWith('Squish-Squad-Prototype'));
const PAGE = fs.readFileSync(path.join(REPO, 'webgame/.cache', dir, 'squish-squad/Squad House v6.dc.html'), 'utf8');
// ---- the template: the map's <svg> (the first one inside its transform box) ----
const a = PAGE.indexOf('<sc-if value="{{ map }}"');
const s0 = PAGE.indexOf('<svg', a);
let depth = 0, e = s0;
for (const m of PAGE.slice(s0).matchAll(/<svg\b|<\/svg>/g)) { depth += m[0] === '<svg' ? 1 : -1; if (!depth) { e = s0 + m.index + m[0].length; break; } }
const tpl = PAGE.slice(s0, e);
fs.writeFileSync(path.join(OUT, 'map-template.html'), '<!-- Squad House v6.dc.html: the house map\'s picture (tools/unity/house/export-map.mjs) -->\n' + tpl + '\n');
// the overlay's small SVGs (in the page's order: the "You're here" pin, the padlock, Back's arrow, the weather icon, the
// level chip's house), raw: their bindings are filled by HouseMapView
const rest = PAGE.slice(e, PAGE.indexOf('</sc-if>\n', PAGE.indexOf('{{ mx.label }}')));
const smalls = [...rest.matchAll(/<svg\b[\s\S]*?<\/svg>/g)].map((m) => m[0]);
fs.writeFileSync(path.join(OUT, 'map-bits.json'), JSON.stringify({ note: 'The house map overlay\'s SVGs in page order: pin, padlock, back arrow, weather, level house (export-map.mjs).', svgs: smalls }));
console.log(`map template: ${tpl.length} chars, ${(tpl.match(/\{\{/g) || []).length} bindings; ${smalls.length} small svgs`);

// ---- the draw host (as draw-check.mjs loads it) ----
const R = (f) => JSON.parse(zlib.gunzipSync(fs.readFileSync(path.join(REPO, 'unity/Assets/Resources/Rig', f))));
const scripts = R('scripts.bytes'), files = R('files.bytes');
const ctx = vm.createContext({ console: { log() {}, warn() {}, error() {} } });
for (const [n, c] of scripts) { try { vm.runInContext(c, ctx, { filename: n }); } catch (err) { if (n === 'house-draw.js') throw err; } if (n === 'live-host.js') { ctx.__f = files; vm.runInContext('__live.install(function (p) { return Object.prototype.hasOwnProperty.call(__f, p) ? __f[p] : null; })', ctx); } }
for (let i = 0; i < 20; i++) vm.runInContext('__clock.frame(40)', ctx);
vm.runInContext('__house.init()', ctx);

// ---- the page's values vs the host's, per fixture ----
const browser = await launch();
const clean = (o) => JSON.parse(JSON.stringify(o, (k, v) => (typeof v === 'function' ? undefined : v)));
let bad = 0;
for (const fx of loadFixtures()) {
  const H = await openHouse(browser, fx, { room: fx.name === 'lv30-beach' ? 'beach' : 'living' });
  await H.ready(); await H.frames(30);
  const P = await H.page.evaluate(() => {
    const sh = window.__sh, S = sh.state; sh.state = Object.assign({}, S, { mapIn: true, mapHov: null, mapGo: null });
    const v = sh.mapVals({}); sh.state = S;
    const open = sh.X.RKEYS.filter((r) => sh.isOpen(r)), b0 = {}; open.forEach((r) => { const s = sh.shellOf(r); b0[r] = s && s.P && s.P.b0; });
    return { v: JSON.parse(JSON.stringify(v, (k, x) => (typeof x === 'function' ? undefined : x))), nat: sh._nat, st: { lvl: sh.lvl(), cur: S.cur, open, b0, cs: sh.cs.map((c) => ({ key: c.key, name: c.name, room: c.room, N: c.N, id: c.id })), season: sh.seasonNow(), mapIn: true } };
  });
  // the page's map drawn (for house-test `map`: the C# template's markup against it)
  const svg = await H.page.evaluate(() => new Promise((r) => { const sh = window.__sh; sh.setState({ map: true, mapIn: true, mapHov: null, mapGo: null }, () => setTimeout(() => { const el = document.querySelector('[data-screen-label="House map"] svg'); r(el ? el.outerHTML : null); }, 0)); }));
  await H.frames(2);
  const svg2 = await H.page.evaluate(() => { const el = document.querySelector('[data-screen-label="House map"] svg'); return el ? el.outerHTML : null; });
  fs.mkdirSync(path.join(REPO, 'tools/unity/house-test/out'), { recursive: true });
  fs.writeFileSync(path.join(REPO, 'tools/unity/house-test/out', 'map-' + fx.name + '.json'), JSON.stringify({ st: P.st, svg: svg2 || svg }));
  const mine = JSON.parse(vm.runInContext('__house.map(' + JSON.stringify(JSON.stringify(P.st)) + ')', ctx));
  const nat = mine.mx.nat; delete mine.mx.nat;
  const same = JSON.stringify(clean(mine)) === JSON.stringify(P.v) && JSON.stringify(nat) === JSON.stringify(P.nat);
  if (!same) { bad++; const A = JSON.stringify(clean(mine)), B = JSON.stringify(P.v); let i = 0; while (i < A.length && A[i] === B[i]) i++; console.log(`${fx.name}: DIFFERENT at ${i}\n  host …${A.slice(Math.max(0, i - 80), i + 120)}\n  page …${B.slice(Math.max(0, i - 80), i + 120)}`); }
  else console.log(`${fx.name}: the map's values equal (${P.st.open.length} rooms open, ${P.st.season})`);
  await H.ctx.close();
}
// ---- the pieces cut from the page: the room's House map button (each room), the map's Back button and weather chip
// (each season) ----
fs.mkdirSync(path.join(OUT, 'map'), { recursive: true });
const pieces = {};
{
  const fd = fontData();
  const H = await openHouse(browser, loadFixtures().find((f) => f.name === 'lv30-beach'), { room: 'living' });
  await H.ready(); await H.frames(30); await H.still();
  await H.page.evaluate((fd) => { window.__snapFonts = fd.names; window.__snapGlyphs = Object.fromEntries(Object.entries(fd.glyphs).map(([k, v]) => [k, new Set(v)])); window.__snapUpm = fd.upm; window.__snapPaths = fd.paths; }, fd);
  await H.page.addScriptTag({ path: path.join(UI, 'snap.js') });
  await H.page.addStyleTag({ content: '*, *::before, *::after { transition: none !important; animation: none !important; }' });
  const f = await H.page.evaluate(() => { const r = document.querySelector('[data-screen-label]').getBoundingClientRect(); return { x: r.left, y: r.top, k: 852 / r.width }; });
  const cut = async (id, find) => {
    const ok = await H.page.evaluate((find) => { const el = new Function('return ' + find)()(document); if (!el) return false; el.dataset.ed = 'x'; return true; }, find);
    if (!ok) { console.log('  not found:', id); return; }
    const s = await snap(H.page, '[data-ed="x"]');
    await H.page.evaluate(() => document.querySelector('[data-ed="x"]').removeAttribute('data-ed'));
    fs.writeFileSync(path.join(OUT, 'map', id + '.xml'), s.svg);
    pieces[id] = [(s.x - f.x) * f.k, (s.y - f.y) * f.k, s.w * f.k, s.h * f.k].map((v) => Math.round(v * 1000) / 1000);
  };
  for (const rk of ['living', 'kitchen', 'bathroom', 'bedroom', 'backyard', 'dance', 'movie', 'beach']) {
    await H.page.evaluate((rk) => { const sh = window.__sh; if (sh.state.cur !== rk) sh.enterRoom(rk, null, null); }, rk);
    await H.frames(3);
    await cut('btn-' + rk, `(d) => d.querySelector('button[aria-label="House map"]')`);
  }
  for (const season of ['sunny', 'rainy', 'snowy']) {
    await H.page.evaluate((season) => new Promise((r) => window.__sh.setState({ season, map: true, mapIn: true }, r)), season);
    await H.frames(2);
    if (season === 'sunny') await cut('back', `(d) => d.querySelector('button[aria-label="Back to room"]')`);
    await cut('weather-' + season, `(d) => d.querySelector('button[aria-label="Back to room"]').nextElementSibling`);
  }
  await H.ctx.close();
}
fs.writeFileSync(path.join(OUT, 'map.json'), JSON.stringify({ note: 'The house map\'s pieces (export-map.mjs): frame px rects.', pieces }));
console.log('map pieces:', Object.keys(pieces).join(' '));
await browser.close();
process.exit(bad ? 1 : 0);
