// Exports Renovate (HOUSE_PORT_PLAN.md stage 6) for Unity (House/HouseEdit.cs, House/View/HouseEditView.cs): the
// tables the edit code reads (RMAP, the short names, the surfaces' names, the lights SPEC knows, every catalog row's
// toolbox tab: rnSlot) and the edit UI's fixed pieces cut from the page itself (tools/unity/ui/snap.js): the Done and
// House shop buttons, the toolbox (its tab, wood box, tray well, the label card per room and hint, the tab buttons on
// and off), the toolbar's buttons and the slider's knob. What changes with the piece (the toolbar's box and labels, the
// slider's fill, the tray's cards) Unity draws from the page's styles (HouseEditView.cs).
//
//   node tools/unity/house/export-edit.mjs
//
// -> unity/Assets/Resources/House/edit/<piece>.xml   (each piece's SVG, in its own CSS px)
//    unity/Assets/Resources/House/edit.json          { rmap, short, surfN, spec, slot, pieces: { name: [x, y, w, h] frame
//                                                    px (fixed ones) or [0, 0, w, h] }, tabs: { room: [[k, x, w]] } }
import fs from 'node:fs';
import path from 'node:path';
import { launch, openHouse, REPO } from './harness.mjs';
import { loadFixtures } from './fixtures.mjs';
import { fontData, HERE as UI, snap } from '../ui/snap-page.mjs';

const OUT = path.join(REPO, 'unity/Assets/Resources/House');
fs.mkdirSync(path.join(OUT, 'edit'), { recursive: true });
const fd = fontData();
const browser = await launch();
const out = { note: 'Written by tools/unity/house/export-edit.mjs. Rects: frame px (852 x 393); [0, 0, w, h]: placed by Unity.', pieces: {}, tabs: {} };
const R3 = (v) => Math.round(v * 1000) / 1000;

async function open(fx, room) {
  const H = await openHouse(browser, fx, { room });
  await H.ready(); await H.frames(30); await H.still();
  await H.page.evaluate((fd) => { window.__snapFonts = fd.names; window.__snapGlyphs = Object.fromEntries(Object.entries(fd.glyphs).map(([k, v]) => [k, new Set(v)])); window.__snapUpm = fd.upm; window.__snapPaths = fd.paths; }, fd);
  await H.page.addScriptTag({ path: path.join(UI, 'snap.js') });
  // no transitions or pop-in animations: everything at rest where it ends up
  await H.page.addStyleTag({ content: '*, *::before, *::after { transition: none !important; animation: none !important; }' });
  H.frame = await H.page.evaluate(() => { const f = document.querySelector('[data-screen-label]').getBoundingClientRect(); return { x: f.left, y: f.top, k: 852 / f.width }; });
  return H;
}
// one element (found in the page by fn(document) => element) as a piece; placed: its frame rect kept
async function cut(H, id, find, placed, prep) {
  const ok = await H.page.evaluate(([find, prep]) => {
    const el = new Function('return ' + find)()(document); if (!el) return false;
    el.dataset.ed = 'x'; el.style.opacity = '1';
    if (prep) new Function('el', prep)(el);
    return true;
  }, [find, prep || '']);
  if (!ok) return false;
  const s = await snap(H.page, '[data-ed="x"]');
  await H.page.evaluate(() => { const el = document.querySelector('[data-ed="x"]'); el.removeAttribute('data-ed'); el.style.opacity = ''; el.querySelectorAll('[data-hid]').forEach((e) => { e.style.visibility = ''; e.removeAttribute('data-hid'); }); });
  fs.writeFileSync(path.join(OUT, 'edit', id + '.xml'), s.svg);
  const f = H.frame;
  out.pieces[id] = placed ? [(s.x - f.x) * f.k, (s.y - f.y) * f.k, s.w * f.k, s.h * f.k].map(R3) : [0, 0, R3(s.w * f.k), R3(s.h * f.k)];
  return true;
}
const btn = (label) => `(d) => d.querySelector('button[aria-label="${label}"]')`;
const hideKids = 'el.querySelectorAll(":scope > *").forEach((e) => { e.style.visibility = "hidden"; e.dataset.hid = 1; });';
const hideSvg = 'el.querySelectorAll(":scope > svg").forEach((e) => { e.style.visibility = "hidden"; e.dataset.hid = 1; });';
const set = (H, st) => H.page.evaluate((st) => new Promise((r) => window.__sh.setState(st, r)), st);

const fixtures = loadFixtures();
const H = await open(fixtures.find((f) => f.name === 'decorated'), 'living');
// ---- the tables ----
Object.assign(out, await H.page.evaluate(() => {
  const sh = window.__sh, X = sh.X;
  const short = {}; for (const r of sh.rows) if (window.RenoShort && window.RenoShort[r.id]) short[r.id] = window.RenoShort[r.id];
  const surfN = {}; for (const [k, m] of Object.entries(X.SURF || {})) if (m.n) surfN[k] = m.n;
  const slot = {}; for (const r of sh.rows) { const s = sh.rnSlot(r); if (s) slot[r.id] = s; }
  return { rmap: { LIV: 'living', KIT: 'kitchen', BTH: 'bathroom', BED: 'bedroom', YRD: 'backyard', CLB: 'dance', MOV: 'movie', BCH: 'beach' }, short, surfN, spec: Object.keys(X.SPEC || {}), slot };
}));
// the page's RMAP, checked: every row's room maps
const rm = await H.page.evaluate(() => { const sh = window.__sh; return [...new Set(sh.rows.map((r) => r.room))]; });
for (const k of rm) if (!out.rmap[k]) throw new Error('RMAP misses ' + k);

// ---- Renovate's fixed pieces ----
await set(H, { edit: true, sel: null, eSel: null, rTab: 'furn', rOpen: true, dr: false });
await H.frames(2);
await cut(H, 'done', btn('Done'), true);
await cut(H, 'shop', btn('House shop'), true);
// the toolbox open: its tab (the arrow apart: it turns), the wood box, the tray's well
const RV = `(d) => d.querySelector('button[aria-label="Hide toolbox"]').parentElement`;
await cut(H, 'rv-tab', btn('Hide toolbox'), true, hideSvg);
await cut(H, 'rv-arrow', `(d) => d.querySelector('button[aria-label="Hide toolbox"] > svg')`, true);
await cut(H, 'rv-box', `(d) => d.querySelector('button[aria-label="Hide toolbox"]').nextElementSibling.firstElementChild`, true, hideKids);
await cut(H, 'rv-well', `(d) => d.querySelector('button[aria-label="Hide toolbox"]').nextElementSibling.firstElementChild.children[1]`, true, hideKids);
// the label card for each room and hint; the tab buttons (on and off) for each room's tabs
const rooms = await H.page.evaluate(() => ['living', 'kitchen', 'bathroom', 'bedroom', 'backyard', 'dance', 'movie', 'beach'].filter((r) => window.__sh.isOpen(r)));
const LABEL = `(d) => d.querySelector('button[aria-label="Hide toolbox"]').nextElementSibling.firstElementChild.firstElementChild`;
async function roomPieces(H, rk) {
  await H.page.evaluate((rk) => { const sh = window.__sh; if (sh.state.cur !== rk) sh.enterRoom(rk, null, null); }, rk);
  await H.frames(3);
  const anItem = await H.page.evaluate(() => { const L = window.__sh.roomItems(); return L.length ? L[0].id : null; });
  for (const [h, eSel] of [[0, null], [1, anItem], [2, '__light']]) {
    if (h === 1 && !anItem) continue;
    await set(H, { edit: true, sel: null, eSel, rTab: 'furn', rOpen: true });
    await H.frames(2);
    await cut(H, `label-${rk}-${h}`, LABEL, true);
  }
  await set(H, { eSel: null });
  const tabs = await H.page.evaluate((rk) => window.__sh.rnTabs(rk), rk);
  const TB = `(d) => d.querySelector('button[aria-label="Hide toolbox"]').nextElementSibling.children[1]`;
  for (const on of tabs) {
    await set(H, { rTab: on, rOpen: true }); await H.frames(2);
    const names = await H.page.evaluate(([TB, on]) => { const row = new Function('return ' + TB)()(document); return [...row.children].map((b, i) => b.textContent.trim()); }, [TB, on]);
    for (let i = 0; i < tabs.length; i++) {
      const k = tabs[i], id = `tab-${k}${rk === 'beach' ? '-b' : ''}-${k === on ? 'on' : 'off'}`;
      if (!out.pieces[id]) await cut(H, id, `(d) => (${TB})(d).children[${i}]`, false);
    }
    if (on === tabs[0]) {
      const pos = await H.page.evaluate((TB) => { const row = new Function('return ' + TB)()(document), f = document.querySelector('[data-screen-label]').getBoundingClientRect(), k = 852 / f.width; return [...row.children].map((b) => { const r = b.getBoundingClientRect(); return [(r.left - f.left) * k, (r.top - f.top) * k, r.width * k]; }); }, TB);
      out.tabs[rk] = tabs.map((k, i) => [k, R3(pos[i][0]), R3(pos[i][1]), R3(pos[i][2]), names[i]]);
    }
  }
}
for (const rk of rooms) await roomPieces(H, rk);
// the beach's tabs (Pier, Sand, Lights) and label from the level-30 house on the beach
const B = await open(fixtures.find((f) => f.name === 'lv30-beach'), 'beach');
await roomPieces(B, 'beach');

// ---- the toolbar: each button as it appears for some piece (the decorated house has every kind) ----
const want = ['Confirm placement', 'Rotate', 'Make smaller', 'Make bigger', 'Width smaller', 'Width bigger', 'Height smaller', 'Height bigger', 'Write on the sign', 'Put away in storage', 'Change the light', 'Move the light back to the middle'];
const id = (l) => 'tb-' + l.toLowerCase().replace(/[^a-z]+/g, '-').replace(/-$/, '');
let left = new Set(want), knob = false, tbTab = false;
for (const rk of rooms) {
  await H.page.evaluate((rk) => { const sh = window.__sh; if (sh.state.cur !== rk) sh.enterRoom(rk, null, null); }, rk);
  await H.frames(3);
  const ids = await H.page.evaluate(() => window.__sh.roomItems().map((it) => it.id).concat(['__light']));
  for (const e of ids) {
    if (!left.size && knob && tbTab) break;
    await set(H, { edit: true, sel: null, eSel: e, rOpen: false, tbC: null }); await H.frames(2);
    for (const l of [...left]) if (await cut(H, id(l), btn(l), false)) left.delete(l);
    if (!knob) knob = await cut(H, 'tb-knob', `(d) => { const s = d.querySelector('[role="slider"]'); return s && s.lastElementChild; }`, false);
    if (!tbTab && (await cut(H, 'tb-tab', btn('Hide tools'), false, hideSvg))) { tbTab = true; await cut(H, 'tb-arrow', `(d) => d.querySelector('button[aria-label="Hide tools"] > svg')`, false); }
  }
}
if (left.size) console.log('toolbar buttons not found:', [...left].join(', '));
fs.writeFileSync(path.join(OUT, 'edit.json'), JSON.stringify(out, null, 1));
console.log(`edit: ${Object.keys(out.pieces).length} pieces; ${Object.keys(out.slot).length} rows with a tab; ${Object.keys(out.short).length} short names; tabs ${JSON.stringify(out.tabs.living)}`);
for (const e of [...new Set([...(H.errs || []), ...(B.errs || [])])].slice(0, 5)) console.log('  page error:', String(e).slice(0, 160));
await browser.close();
