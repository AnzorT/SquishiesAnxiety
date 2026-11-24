// Exports the Yard Games page (develop: the menu's games page in yard mode, webgame/app/games.js yardCard / yardPage,
// webgame/patches.mjs "the Main Menu's Mini Games page", 2026-11-18, the user: "in the menu of the yard games I want it
// to be in horizontal and put the images of the games on them (on all of them) and make the list of the games
// scrollable, I want the game to be unlocked only when the game got purchased") as art the Unity port loads
// (unity/Assets/Resources/Yard/page, Games/Yard/View/YardPage*.cs), and the app's own screenshots of it to compare
// with (webgame/test/out/unity-pages/yard-*.png, tools/unity/pages-test `yd`).
//
//   node tools/unity/house/export-yardpage.mjs
//
// The app's menu is opened in Chromium at the Galaxy A15's size (832 x 384 dp, 2.8125 px per dp), the player walks
// home into the backyard (the lv12 house fixture), and the YARD GAMES page is opened over the house as its button does
// (SquishApp.menu.games('yard')). Every piece is cut on its own (the rest of the page hidden, background transparent),
// as tools/unity/export-pages.mjs cuts the Characters page:
//   bg.jpg            the page's wood (.mm-page2 with its children hidden)
//   head.png          the back orb and the "Yard Games" lettering (the "n of 7 ready" line is drawn by Unity)
//   card/<id>-open|lock.png   each game's card with its toy bought or not: the frame, the poster's drawing under the
//                     creatures (open, or under the lock's saturate(.3) brightness(.78)), the name, the toy, PLAY or the
//                     "Buy <toy> in the Backyard catalog (n coins)" box; the best chip left out (drawn by Unity)
//   poster/<id>-open|lock-<n>.png   the poster's drawing in front of its n-th creature (yg-intros.js: the creatures are
//                     the player's rig posed in the poster, YardGames.posterRig; Unity draws them in between)
//   padlock.png       the locked card's padlock (over the poster)
// and yardpage.json: where each piece goes (page px, the page at scale H / 393 as .mm-pg), the list's padding and gap,
// the chip's and the subtitle's styles, each poster's creature slots (their transform in the card, size, pose, yaw).
import fs from 'node:fs';
import path from 'node:path';
import { execFileSync } from 'node:child_process';
import { pathToFileURL } from 'node:url';
import { PNG } from 'pngjs';
import { launch, buildWeb, REPO, WORK } from './harness.mjs';
import { loadFixtures } from './fixtures.mjs';

const OUT = path.join(REPO, 'unity/Assets/Resources/Yard/page');
const SHOTS = path.join(REPO, 'webgame/test/out/unity-pages');
const REF = { w: 832, h: 384, dpr: 2.8125 };
const K = REF.h / 393, U = K * REF.dpr;   // the page's scale and px per page px
const r4 = v => Math.round(v * 1e4) / 1e4;
const GAMES = ['hoop', 'soccer', 'hop', 'tramp', 'slide', 'corn', 'pong'];
const TOY = { hoop: 'YRD-102', soccer: 'YRD-104', hop: 'YRD-101', tramp: 'YRD-120', slide: 'YRD-123', corn: 'YRD-037', pong: 'YRD-057' };

function trimBox(png) {
  const { width: W, height: H, data } = png;
  let x0 = W, y0 = H, x1 = -1, y1 = -1;
  for (let y = 0; y < H; y++) for (let x = 0; x < W; x++) if (data[(y * W + x) * 4 + 3]) { if (x < x0) x0 = x; if (x > x1) x1 = x; if (y < y0) y0 = y; if (y > y1) y1 = y; }
  return x1 < 0 ? null : { x: x0, y: y0, w: x1 - x0 + 1, h: y1 - y0 + 1 };
}
function crop(png, b) { const o = new PNG({ width: b.w, height: b.h }); PNG.bitblt(png, o, b.x, b.y, b.w, b.h, 0, 0); return o; }

await buildWeb();
fs.mkdirSync(OUT, { recursive: true }); fs.mkdirSync(SHOTS, { recursive: true });
const browser = await launch();
const fx = loadFixtures().find(f => f.name === 'lv12');
const ctx = await browser.newContext({ viewport: { width: REF.w, height: REF.h }, deviceScaleFactor: REF.dpr });
const page = await ctx.newPage();
const errs = [];
page.on('pageerror', e => errs.push(e.message));
await page.route(/^https?:/, r => r.abort());
await page.addInitScript(F => {
  try { localStorage.clear(); } catch (e) { /* none */ }
  const set = (k, v) => localStorage.setItem(k, typeof v === 'string' ? v : JSON.stringify(v));
  set('squishsquad.profile.v1', Object.assign({ level: 1, coins: 100, owned: [] }, F.profile || {}));
  if (F.collection) set('squishsquad.collection.v1', F.collection);
  if (F.house) set('ssHouse5b', F.house);
  set('yardgames.v1', { best: { tramp: 240 } });
}, fx);
await page.goto(pathToFileURL(path.join(WORK, 'App.dc.html')).href + '?screen=menu');
await page.waitForFunction(() => !!(window.SquishApp && window.SquishApp.menu && window.SquishApp.menu._geo()), null, { timeout: 120000 });
await page.waitForTimeout(1500);
await page.evaluate(() => window.SquishApp.menu.home('backyard'));
await page.waitForFunction(() => !!(window.__sh && window.__sh.state && window.__sh.state.ready && !window.SquishApp.menu._busy()), null, { timeout: 120000 });
await page.waitForTimeout(2500);
// the posters without the live creature (Unity draws it): the slots stay empty
await page.evaluate(() => { window.YardGames.posterRig = null; });

// the page opened again with `owned` games' toys bought (the house's own owned counts)
async function open(owned) {
  await page.evaluate(({ owned, TOY }) => {
    const sh = window.__sh; for (const g in TOY) { delete sh.H.owned['R:' + TOY[g]]; } owned.forEach(g => { sh.H.owned['R:' + TOY[g]] = 1; });
    const p = document.querySelector('.mm-page2'); if (p) p.remove();
    window.SquishApp.menu.games('yard');
  }, { owned, TOY });
  await page.waitForTimeout(2500);
  await page.evaluate(() => {
    let st = document.getElementById('__still'); if (!st) { st = document.createElement('style'); st.id = '__still'; document.head.appendChild(st); }
    st.textContent = '*,*::before,*::after{animation:none!important;transition:none!important;caret-color:transparent!important;}';
    // each poster's drawing split at its creatures: data-seg = how many creature slots come before it
    const SKIP = new Set(['defs', 'clipPath', 'mask', 'pattern', 'linearGradient', 'radialGradient', 'filter', 'symbol', 'marker', 'style']);
    document.querySelectorAll('.sq-ygc .win > svg').forEach(svg => {
      let seg = 0;
      const walk = el => { for (const c of el.children) {
        const t = c.tagName; if (SKIP.has(t)) continue;
        if (c.classList.contains('ygp-cr')) { seg++; continue; }
        if (c.classList.contains('ygp-prop')) { c.style.display = 'none'; continue; }   // (a prop held on the rig's paw: not drawn without it)
        if (t === 'g' || t === 'a' || t === 'svg') walk(c); else c.setAttribute('data-seg', seg);
      } };
      walk(svg); svg.setAttribute('data-segs', seg + 1);
    });
  });
}
async function scrollTo(id) {
  await page.evaluate(id => { const gr = document.querySelector('.mm-gr'), c = gr.querySelector('[data-g="' + id + '"]'); gr.scrollLeft = c.offsetLeft - 22; }, id);
  await page.waitForTimeout(60);
}
// one piece on its own (export-pages.mjs cut): everything else hidden, transparent background
async function cut(file, q, hide = [], css = '') {
  const r = await page.evaluate(({ q, hide, css }) => {
    const root = document.documentElement;
    document.querySelectorAll('[data-iso]').forEach(e => { e.style.visibility = e.dataset.iso === '-' ? '' : e.dataset.iso; delete e.dataset.iso; });
    let st = document.getElementById('__iso_css'); if (!st) { st = document.createElement('style'); st.id = '__iso_css'; document.head.appendChild(st); }
    st.textContent = css;
    const el = document.querySelector(q); if (!el) return null;
    root.style.visibility = 'hidden'; root.style.background = 'transparent'; document.body.style.background = 'transparent';
    const mark = (e, v) => { e.dataset.iso = e.style.visibility || '-'; e.style.visibility = v; };
    mark(el, 'visible');
    for (const h of hide) el.querySelectorAll(h).forEach(e => mark(e, 'hidden'));
    const b = el.getBoundingClientRect();
    return { x: b.left, y: b.top, w: b.width, h: b.height };
  }, { q, hide, css });
  if (!r) throw new Error('no element for ' + file + ' (' + q + ')');
  await page.waitForTimeout(40);
  const png = PNG.sync.read(await page.screenshot({ omitBackground: true }));
  const t = trimBox(png);
  if (!t) return null;
  const f = path.join(OUT, file + '.png.bytes'); fs.mkdirSync(path.dirname(f), { recursive: true }); fs.writeFileSync(f, PNG.sync.write(crop(png, t)));
  const box = [r.x, r.y, r.w, r.h].map(v => v * REF.dpr);
  return { res: file, at: [r4(t.x - box[0]), r4(t.y - box[1])], size: [t.w, t.h], box: box.map(v => r4(v / U)) };
}
async function uncut() {
  await page.evaluate(() => {
    document.querySelectorAll('[data-iso]').forEach(e => { e.style.visibility = e.dataset.iso === '-' ? '' : e.dataset.iso; delete e.dataset.iso; });
    const st = document.getElementById('__iso_css'); if (st) st.remove();
    document.documentElement.style.visibility = ''; document.documentElement.style.background = ''; document.body.style.background = '';
  });
  await page.waitForTimeout(40);
}
// a box in page px (the page's own px: .mm-pg at scale k)
const boxOf = (q, rel) => page.evaluate(({ q, rel, U }) => { const e = document.querySelector(q); if (!e) return null; const b = e.getBoundingClientRect(), o = rel ? document.querySelector(rel).getBoundingClientRect() : { left: 0, top: 0 };
  return [b.left - o.left, b.top - o.top, b.width, b.height].map(v => Math.round(v * 2.8125 / U * 1e4) / 1e4); }, { q, rel, U });

const L = { note: 'Written by tools/unity/house/export-yardpage.mjs. Page px (the page at scale H / 393); pictures cut at 2340 x 1080.', reference: { px: [Math.round(REF.w * REF.dpr), Math.round(REF.h * REF.dpr)], dp: [REF.w, REF.h], dpr: REF.dpr, k: r4(K), u: r4(U) }, games: [] };

// ---- everything open: the layout, the background, the head, the open cards ----
await open(GAMES);
L.list = await page.evaluate(() => { const gr = document.querySelector('.mm-gr'), cs = getComputedStyle(gr);
  return { top: gr.offsetTop, padL: parseFloat(cs.paddingLeft), padR: parseFloat(cs.paddingRight), padT: parseFloat(cs.paddingTop), gap: parseFloat(cs.columnGap || cs.gap) }; });
L.orb = await boxOf('.mm-pgh .mm-orb');
L.sub = await page.evaluate(({ U }) => { const e = document.querySelector('.mm-pgh .s'), c = getComputedStyle(e), b = e.getBoundingClientRect(), k = 2.8125 / U; return { box: [b.left, b.top, b.width, b.height].map(v => Math.round(v * k * 1e4) / 1e4), font: c.font, color: c.color, text: e.textContent }; }, { U });
{
  // the background: JPEG (Pillow: quality 95, full-resolution colour), the page with its children hidden
  await page.evaluate(() => { const st = document.createElement('style'); st.id = '__bg_css'; st.textContent = '.mm-page2 > *{visibility:hidden!important;}'; document.head.appendChild(st); });
  await page.waitForTimeout(80);
  const tmp = path.join(SHOTS, '__yard-bg.png'); fs.writeFileSync(tmp, await page.screenshot());
  await page.evaluate(() => document.getElementById('__bg_css').remove());
  execFileSync('python3', ['-c', 'import sys\nfrom PIL import Image\nImage.open(sys.argv[1]).convert("RGB").save(sys.argv[2],format="JPEG",quality=95,subsampling=0,optimize=True)', tmp, path.join(OUT, 'bg.jpg.bytes')]);
  fs.rmSync(tmp);
  L.bg = { res: 'bg', size: L.reference.px };
}
L.head = await cut('head', '.mm-pgh', ['.s']);
await uncut();
// the chip ("★ Best n" / "New!" / "Locked") as the CSS draws it
L.chip = await page.evaluate(() => { const e = document.querySelector('.sq-ygc .best'), c = getComputedStyle(e); return { bg: c.backgroundColor, ring: c.boxShadow, font: c.font, color: c.color, ls: c.letterSpacing, padX: parseFloat(c.paddingLeft), padY: parseFloat(c.paddingTop), h: parseFloat(c.height) }; });
for (const id of GAMES) {
  await scrollTo(id);
  const q = '.sq-ygc[data-g="' + id + '"]';
  const segs = await page.evaluate(q => +document.querySelector(q + ' .win > svg').getAttribute('data-segs'), q);
  const g = { id, segs };
  g.box = await page.evaluate(q => { const c = document.querySelector(q); return [c.offsetLeft, c.offsetTop, c.offsetWidth, c.offsetHeight]; }, q);   // (in the list, unscrolled)
  g.win = await boxOf(q + ' .win', q);
  g.chip = await boxOf(q + ' .best', q);   // (right-aligned in its row: its right edge stays)
  g.play = await boxOf(q + ' .go', q);
  g.card = { open: await cut('card/' + id + '-open', q, ['.best', '.padlock', '[data-seg]:not([data-seg="0"])']) };
  g.over = { open: [] };
  for (let s = 1; s < segs; s++) g.over.open.push(await cut('poster/' + id + '-open-' + s, q + ' .win > svg', ['[data-seg]:not([data-seg="' + s + '"])']));
  g.slots = await page.evaluate(({ q, U }) => { const card = document.querySelector(q).getBoundingClientRect(), k = 2.8125 / U;
    return [...document.querySelectorAll(q + ' .ygp-cr')].map(e => { const m = e.getScreenCTM();
      return { w: +e.dataset.w, who: e.dataset.who || '', yaw: e.dataset.yaw ? +e.dataset.yaw : 0, pose: e.dataset.pose ? JSON.parse(e.dataset.pose) : {}, // (as two lists too, for Unity's JsonUtility)
        m: [m.a * k, m.b * k, m.c * k, m.d * k, (m.e - card.left) * k, (m.f - card.top) * k].map(v => Math.round(v * 1e5) / 1e5) }; }); }, { q, U });
  await uncut();
  L.games.push(g);
}
// what a tap on PLAY / a card does is the page's (main-menu.js: the card is the button; a locked one toasts its need)

// ---- everything locked: the locked cards, the padlock ----
await open([]);
L.need = {};
for (const g of L.games) {
  await scrollTo(g.id);
  const q = '.sq-ygc[data-g="' + g.id + '"]';
  L.need[g.id] = await page.evaluate(q => document.querySelector(q + ' .need').textContent, q);
  g.chipLock = await boxOf(q + ' .best', q);   // (the locked card's row sits higher: the need box under it)
  g.card.lock = await cut('card/' + g.id + '-lock', q, ['.best', '.padlock', '[data-seg]:not([data-seg="0"])']);
  g.over.lock = [];
  for (let s = 1; s < g.segs; s++) g.over.lock.push(await cut('poster/' + g.id + '-lock-' + s, q + ' .win > svg', ['[data-seg]:not([data-seg="' + s + '"])']));
  if (!L.padlock) L.padlock = await cut('padlock', q + ' .padlock');
  if (!L.padlockAt) L.padlockAt = await boxOf(q + ' .padlock', q);
  await uncut();
}

// ---- the app's screenshots to compare with: hoop and tramp bought (tramp's best 240), at the start and scrolled ----
L.shots = [];
await open(['hoop', 'tramp']);
for (const [name, scroll] of [['yard-start', 0], ['yard-mid', 700], ['yard-end', 99999]]) {
  const s = await page.evaluate(v => { const gr = document.querySelector('.mm-gr'); gr.scrollLeft = v; return gr.scrollLeft; }, scroll);
  await page.waitForTimeout(80);
  fs.writeFileSync(path.join(SHOTS, name + '.png'), await page.screenshot());
  L.shots.push({ name, file: name + '.png', scroll: r4(s), owned: ['hoop', 'tramp'], best: { tramp: 240 } });
}
L.scrollMax = await page.evaluate(() => { const gr = document.querySelector('.mm-gr'); return gr.scrollWidth - gr.clientWidth; });
for (const g of L.games) for (const sl of g.slots) { sl.poseK = Object.keys(sl.pose); sl.poseV = Object.values(sl.pose); }
fs.writeFileSync(path.join(OUT, 'yardpage.json'), JSON.stringify(L, null, 1));
// the pictures recompressed losslessly (Pillow's optimize)
execFileSync('python3', ['-c', 'import sys,os,io\nfrom PIL import Image\nfor r,_,fs in os.walk(sys.argv[1]):\n  for f in fs:\n    if f.endswith(".png.bytes"):\n      p=os.path.join(r,f);b=open(p,"rb").read();o=io.BytesIO();Image.open(io.BytesIO(b)).save(o,format="PNG",optimize=True)\n      if len(o.getvalue())<len(b): open(p,"wb").write(o.getvalue())', OUT]);
if (errs.length) console.log('page errors:', errs.slice(0, 5).join(' | '));
console.log('yard page ->', path.relative(REPO, OUT), '·', L.games.map(g => g.id + ':' + g.segs + ' segs, ' + g.slots.length + ' creatures').join(', '));
await browser.close();
