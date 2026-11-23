// Exports the house Catalog (HOUSE_PORT_PLAN.md stage 7) for Unity (House/HouseShop.cs, House/View/HouseShopView.cs):
// what each catalog row shows that the page works out with code we don't port (rnTag: the tag line, what it does and
// its secret; NT: the short note; rnDraw's surf: a wall / floor / light surface or a piece; rnReg: whether the piece
// can be placed) and the Catalog's fixed pieces cut from the page (tools/unity/ui/snap.js): the book, the room tab and
// header for each room (open and boarded up), the header's icons and close button, the page arrows, the detail card's
// base, close button and padlock. Cards, category buttons and texts Unity draws from the page's styles.
//
//   node tools/unity/house/export-catalog.mjs
//
// -> unity/Assets/Resources/House/shop/<piece>.xml   (each piece's SVG, in its own CSS px)
//    unity/Assets/Resources/House/shop.json          { rows: { id: [tag, what, sec, note, surf 0/1, reg 0/1] },
//                                                    pieces: { name: [x, y, w, h] frame px } }
import fs from 'node:fs';
import path from 'node:path';
import { launch, openHouse, REPO } from './harness.mjs';
import { loadFixtures } from './fixtures.mjs';
import { fontData, HERE as UI, snap } from '../ui/snap-page.mjs';

const OUT = path.join(REPO, 'unity/Assets/Resources/House');
fs.mkdirSync(path.join(OUT, 'shop'), { recursive: true });
const fd = fontData();
const browser = await launch();
const out = { note: 'Written by tools/unity/house/export-catalog.mjs. Rects: frame px (852 x 393).', rows: {}, pieces: {} };
const R3 = (v) => Math.round(v * 1000) / 1000;

async function open(fx, room) {
  const H = await openHouse(browser, fx, { room });
  await H.ready(); await H.frames(30); await H.still();
  await H.page.evaluate((fd) => { window.__snapFonts = fd.names; window.__snapGlyphs = Object.fromEntries(Object.entries(fd.glyphs).map(([k, v]) => [k, new Set(v)])); window.__snapUpm = fd.upm; window.__snapPaths = fd.paths; }, fd);
  await H.page.addScriptTag({ path: path.join(UI, 'snap.js') });
  await H.page.addStyleTag({ content: '*, *::before, *::after { transition: none !important; animation: none !important; }' });
  H.frame = await H.page.evaluate(() => { const f = document.querySelector('[data-screen-label]').getBoundingClientRect(); return { x: f.left, y: f.top, k: 852 / f.width }; });
  return H;
}
async function cut(H, id, find, prep) {
  const ok = await H.page.evaluate(([find, prep]) => {
    const el = new Function('return ' + find)()(document); if (!el) return false;
    el.dataset.ed = 'x'; el.style.opacity = '1';
    if (prep) new Function('el', prep)(el);
    return true;
  }, [find, prep || '']);
  if (!ok) { console.log('  not found:', id); return false; }
  const s = await snap(H.page, '[data-ed="x"]');
  await H.page.evaluate(() => { const el = document.querySelector('[data-ed="x"]'); el.removeAttribute('data-ed'); el.style.opacity = ''; document.querySelectorAll('[data-hid]').forEach((e) => { e.style.visibility = ''; e.removeAttribute('data-hid'); }); });
  fs.writeFileSync(path.join(OUT, 'shop', id + '.xml'), s.svg);
  const f = H.frame;
  out.pieces[id] = [(s.x - f.x) * f.k, (s.y - f.y) * f.k, s.w * f.k, s.h * f.k].map(R3);
  return true;
}
const set = (H, st) => H.page.evaluate((st) => new Promise((r) => window.__sh.setState(st, r)), st);
const CAT = `document.querySelector('[data-screen-label="Catalog"]')`;
const BOOK = `(d) => d.querySelector('[data-screen-label="Catalog"] > div').children[2]`;
const hide = (sel) => `el.querySelectorAll(${JSON.stringify(sel)}).forEach((e) => { e.style.visibility = "hidden"; e.dataset.hid = 1; });`;

const fixtures = loadFixtures();
const H = await open(fixtures.find((f) => f.name === 'lv30-beach'), 'living');
// ---- the rows ----
out.rows = await H.page.evaluate(() => {
  const sh = window.__sh, o = {};
  for (const r of sh.rows) {
    const D = sh.rnDraw(r, 0) || {}, t = sh.rnTag(r, D), note = (window.RenoNoteShort && window.RenoNoteShort[r.id]) || r.note || '';
    let reg = 0; try { reg = D.surf ? 1 : sh.rnReg(r.id) ? 1 : 0; } catch (e) { reg = 0; }
    o[r.id] = [t.tag || '', t.what || '', t.sec || '', note, D.surf ? 1 : 0, reg];
  }
  return o;
});
// ---- the Catalog open, every room: its tab and header ----
await H.page.evaluate(() => window.__sh.openCat());
await H.frames(3);
const codes = ['LIV', 'KIT', 'BTH', 'BED', 'YRD', 'CLB', 'MOV', 'BCH'];
for (const c of codes) {
  await set(H, { cRm: c, cCt: '', cPg: 0, det: null }); await H.frames(2);
  await cut(H, 'room-' + c, `(d) => d.querySelector('[data-screen-label="Catalog"] > div').children[0].children[0]`);
  await cut(H, 'head-' + c, `(d) => (${BOOK})(d).children[4]`);
}
// the book with what changes hidden (header texts, tier line, the two grids, the categories, the paging)
await cut(H, 'book', BOOK, '[...el.children].slice(4).forEach((e) => { e.style.visibility = "hidden"; e.dataset.hid = 1; });');
await cut(H, 'lv-icon', `(d) => d.querySelector('button[aria-label="House level"] > svg')`);
await cut(H, 'coin-icon', `(d) => d.querySelector('button[aria-label="House level"]').nextElementSibling.querySelector('svg')`);
await cut(H, 'close', `(d) => d.querySelector('button[aria-label="Close catalog"]')`);
await cut(H, 'prev', `(d) => d.querySelector('button[aria-label="Previous page"]')`);
await cut(H, 'next', `(d) => d.querySelector('button[aria-label="Next page"]')`);
// the detail card: a piece's (its texts and picture hidden), its close button; a locked piece's padlock
const anId = await H.page.evaluate(() => window.__sh.rows.find((r) => r.room === 'LIV').id);
await set(H, { cRm: 'LIV', det: anId, detCol: 0 }); await H.frames(2);
const DET = `(d) => d.querySelector('button[aria-label="Close"]').parentElement`;
await cut(H, 'det', DET, `el.querySelectorAll(':scope > div:nth-of-type(2) > *').forEach((e) => { e.style.visibility = "hidden"; e.dataset.hid = 1; }); [...el.children].slice(3).forEach((e) => { e.style.visibility = "hidden"; e.dataset.hid = 1; }); el.querySelector('button[aria-label="Close"]').style.visibility = "hidden"; el.querySelector('button[aria-label="Close"]').dataset.hid = 1;`);
await cut(H, 'det-close', `(d) => d.querySelector('button[aria-label="Close"]')`);
await H.ctx.close();
// boarded-up rooms (their tab's padlock, the header's "Opens at Lv"): a level-1 house; a locked piece's padlock
const L1 = await open(fixtures.find((f) => f.name === 'fresh-lv1'), 'living');
await L1.page.evaluate(() => window.__sh.openCat()); await L1.frames(3);
for (const c of codes.slice(1)) {
  await set(L1, { cRm: c, cCt: '', cPg: 0, det: null }); await L1.frames(2);
  await cut(L1, 'room-' + c + '-lock', `(d) => d.querySelector('[data-screen-label="Catalog"] > div').children[0].children[0]`);
  await cut(L1, 'head-' + c + '-lock', `(d) => (${BOOK})(d).children[4]`);
}
const lockedId = await L1.page.evaluate(() => window.__sh.rows.find((r) => r.room === 'LIV' && r.lv > 1).id);
await set(L1, { cRm: 'LIV', det: lockedId }); await L1.frames(2);
await cut(L1, 'lock-icon', `(d) => { const b = d.querySelector('button[aria-label="Close"]').parentElement; const s = [...b.querySelectorAll('svg')].find((e) => e.closest('div') && /Unlocks at level/.test(e.parentElement.textContent)); return s; }`);
fs.writeFileSync(path.join(OUT, 'shop.json'), JSON.stringify(out));
console.log(`catalog: ${Object.keys(out.rows).length} rows (${Object.values(out.rows).filter((r) => r[0]).length} tagged, ${Object.values(out.rows).filter((r) => r[4]).length} surfaces, ${Object.values(out.rows).filter((r) => !r[5]).length} not placeable); ${Object.keys(out.pieces).length} pieces`);
for (const e of [...new Set([...(L1.errs || [])])].slice(0, 5)) console.log('  page error:', String(e).slice(0, 160));
await browser.close();
