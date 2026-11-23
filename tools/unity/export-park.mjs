// Exports the Game Park's games carousel (webgame/app/menu.js showGames), exactly as the app draws it, as art the
// Unity app loads (unity/Assets/Resources/Park), and the app's own screenshots of it to compare with.
//
//   node tools/unity/export-park.mjs              (--no-build reuses the last web build of export-menu.mjs)
//
// The menu is opened as the app opens it when you come back from a game started in the park (SquishApp.screen =
// 'park': straight into the park, carousel shown at once), with the app's games list (src/game/player.js menuGames for
// a new player) and the clock frozen, at the Galaxy A15's size (832 x 384 dp, 2.8125 px per dp = 2340 x 1080 px).
// Each piece is cut out of the page on its own device-pixel grid:
//   - cards/<id>.png        a game's card without its PLAY button and its window's inner shadow (the window shows the
//                           clip's first frame, app/previews/<id>.jpg, as the app does until the clip plays)
//   - cards/<id>-over.png   the window's inner shadow (.win::after), drawn over the clip
//   - cards/<id>-mask.png   the window's rounded shape (the clip and Squish Time's creature are clipped to it)
//   - cards/squish-*.png    Squish Time's creature and its squish lines (CSS keyframes sqSqz / sqLines, moved in Unity)
//   - go.png / go-dim.png   PLAY on the card in the middle / on the others (.sq-slot:not(.c) .go: saturate(.7))
//   - dim, header, rays, halo, arrow-l / arrow-r (.off is the same at opacity .4), dot-on / dot-off
//   - park.json             where they go (formulas of showGames, so other screen widths work) and the game list
//   - ../StreamingAssets/Park/<id>.mp4   the clips (Unity's VideoPlayer plays the middle card's)
//   - webgame/test/out/unity-park/       the app's screenshots: each game in the middle, the park without the
//                           carousel (the plate the comparison draws on), and frames in the middle of its motions
// tools/unity/park-test composes the Unity carousel from these pieces with the Unity code's own placement and
// compares it with those screenshots.
import fs from 'node:fs';
import path from 'node:path';
import { createRequire } from 'node:module';
import { fileURLToPath, pathToFileURL } from 'node:url';
import { execFileSync } from 'node:child_process';
import { PNG } from 'pngjs';
import { build } from '../../webgame/build.mjs';
import { record as sdkRecord, LEVELS as SDK_LEVELS } from '../../src/squishdoku/levels.js';
import { record as sortRecord } from '../../src/sort/levels.js';
import { LEVELS as STACK_LEVELS, record as stackRecord, starsOf as stackStars } from '../../src/stack/levels.js';
import { LEVELS as HOP_LEVELS, record as hopRecord, starsOf as hopStars } from '../../src/hop/levels.js';

const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
const HERE = path.dirname(fileURLToPath(import.meta.url));
const REPO = path.resolve(HERE, '../..');
const OUT = path.join(REPO, 'unity/Assets/Resources/Park');
const CLIPS = path.join(REPO, 'unity/Assets/StreamingAssets/Park');
const SHOTS = path.join(REPO, 'webgame/test/out/unity-park');
const REF_DIR = path.join(REPO, 'unity/Reference');
const WORK = path.join(REPO, 'webgame/test/out/unity-webgame');
const SKIP_BUILD = process.argv.includes('--no-build');

const REF = { w: 832, h: 384, dpr: 2.8125 };
const PX = { w: Math.round(REF.w * REF.dpr), h: Math.round(REF.h * REF.dpr) };
const T0 = new Date('2026-11-13T12:00:00Z');
const SEED = `(() => { let s = 0x2f6b9a1; Math.random = () => { s ^= s << 13; s >>>= 0; s ^= s >>> 17; s ^= s << 5; s >>>= 0; return s / 4294967296; }; })();`;
const LASTG = 'squishsquad.park.v1';

// the app's games, as src/game/player.js menuGames() lists them for a new player (no levels played)
function appGames() {
  const p = {}, sdk = sdkRecord(p), srt = sortRecord(p), stk = stackRecord(p), hop = hopRecord(p);
  const stars = n => (n ? ` · ★ ${n}` : '');
  return [
    { id: 'squishdoku', name: 'Squishdoku', item: `${SDK_LEVELS} puzzle levels`, best: `Level ${Math.min(sdk.lv, SDK_LEVELS)} / ${SDK_LEVELS}`, color: '#3fc4ec' },
    { id: 'sort', name: 'Squish Sort', item: 'Fridge & cupboard', best: `Fridge ${srt.fridge.lv} · Cupboard ${srt.cupboard.lv}`, color: '#ff9a3c' },
    { id: 'stack', name: 'Squish Stack', item: 'Tower puzzles', best: `Level ${stk.lv} / ${STACK_LEVELS}${stars(stackStars(stk))}`, color: '#9b6bff' },
    { id: 'hop', name: 'Squish Hop', item: 'Cushion hopping', best: `Level ${hop.lv} / ${HOP_LEVELS}${stars(hopStars(hop))}`, color: '#2fc6a8' },
  ];
}

function trimBox(png) {
  const { width: W, height: H, data } = png;
  let x0 = W, y0 = H, x1 = -1, y1 = -1;
  for (let y = 0; y < H; y++) for (let x = 0; x < W; x++) if (data[(y * W + x) * 4 + 3]) { if (x < x0) x0 = x; if (x > x1) x1 = x; if (y < y0) y0 = y; if (y > y1) y1 = y; }
  return x1 < 0 ? null : { x: x0, y: y0, w: x1 - x0 + 1, h: y1 - y0 + 1 };
}
function crop(png, b) { const o = new PNG({ width: b.w, height: b.h }); PNG.bitblt(png, o, b.x, b.y, b.w, b.h, 0, 0); return o; }
const write = (rel, buf) => { const f = path.join(OUT, rel); fs.mkdirSync(path.dirname(f), { recursive: true }); fs.writeFileSync(f, buf); return rel.replace(/\.png$/, ''); };
const r4 = v => Math.round(v * 1e4) / 1e4;

async function openPark(browser, games) {
  const ctx = await browser.newContext({ viewport: { width: REF.w, height: REF.h }, deviceScaleFactor: REF.dpr });
  const page = await ctx.newPage();
  const errs = [];
  page.on('pageerror', e => errs.push(e.message));
  await page.route(/^https?:/, r => { errs.push('internet: ' + r.request().url()); r.abort(); });
  await page.addInitScript(SEED);
  // the app's start data (app/bridge.js reads it before the page's scripts): straight into the park, the app's games
  await page.addInitScript(g => { window.__SQUISH_INIT__ = { screen: 'park', state: { games: g } }; try { localStorage.removeItem('squishsquad.park.v1'); } catch (e) { /* none */ } }, games);
  await page.clock.install({ time: T0 });
  await page.clock.pauseAt(T0);
  const cdp = await ctx.newCDPSession(page);
  await cdp.send('Animation.enable');
  await cdp.send('Animation.setPlaybackRate', { playbackRate: 0 });
  await page.goto(pathToFileURL(path.join(WORK, 'App.dc.html')).href);
  await page.waitForTimeout(8000);
  for (let t = 0; t < 9000; t += 500) { await page.clock.runFor(500); await page.waitForTimeout(150); }
  await page.evaluate(() => document.fonts.ready);
  await page.waitForTimeout(1000);
  if (!(await page.$('.sq-pk.in'))) throw new Error('the park carousel did not open');
  // the HUD's fade-out (x.fade) and the rest of the walk-in's transitions, finished as they would be by now
  await page.evaluate(() => { for (const a of document.getAnimations()) if (a.effect && a.effect.getTiming().iterations !== Infinity) a.finish(); });
  return { ctx, page, errs };
}

// the carousel at rest: no clip playing (the app shows its first frame, the .jpg, until it plays; headless Chromium
// can't play the mp4s anyway), every transition and the centre card's flash (sqCen) finished, Squish Time at 0
async function settle(page) {
  await page.evaluate(() => {
    document.querySelectorAll('.sq-pk video').forEach(v => v.remove());
    for (const a of document.getAnimations()) {
      const t = a.effect && a.effect.target; if (!t || !t.closest || !t.closest('.sq-pk')) continue;
      const tm = a.effect.getTiming();
      if (tm.iterations === Infinity) a.currentTime = 0; else a.finish();
    }
  });
  await page.waitForTimeout(60);
}

// one piece on its own: everything else hidden, transparent background; `hide` selectors inside it hidden too, `css`
// added while it's cut, `prep` run on the element first (and undone by `undo`)
async function cut(page, P) {
  const r = await page.evaluate(({ q, hide, css }) => {
    const root = document.documentElement;
    if (!window.__iso) window.__iso = { html: root.style.cssText, body: document.body.style.cssText };
    document.querySelectorAll('[data-iso]').forEach(e => { e.style.visibility = e.dataset.iso === '-' ? '' : e.dataset.iso; delete e.dataset.iso; });
    let st = document.getElementById('__iso_css'); if (!st) { st = document.createElement('style'); st.id = '__iso_css'; document.head.appendChild(st); }
    // (no transitions while cutting: 'transition: all' would hold a hidden element visible, the clock being frozen)
    st.textContent = '*,*::before,*::after{transition:none!important;}' + (css || '');
    const el = document.querySelector(q);
    if (!el) return null;
    root.style.visibility = 'hidden'; root.style.background = 'transparent'; document.body.style.background = 'transparent';
    const mark = (e, v) => { e.dataset.iso = e.style.visibility || '-'; e.style.visibility = v; };
    mark(el, 'visible');
    for (const h of hide || []) el.querySelectorAll(h).forEach(e => mark(e, 'hidden'));
    const b = el.getBoundingClientRect();
    return { x: b.left, y: b.top, w: b.width, h: b.height };
  }, P);
  if (!r) throw new Error('no element for ' + P.id + ' (' + P.q + ')');
  await page.waitForTimeout(40);
  const png = PNG.sync.read(await page.screenshot({ omitBackground: true }));
  if (png.width !== PX.w || png.height !== PX.h) throw new Error(`screenshot came back ${png.width}x${png.height}`);
  const t = trimBox(png);
  if (!t) throw new Error(P.id + ' drew nothing');
  const res = write(P.file + '.png', PNG.sync.write(crop(png, t)));
  return { res, rect: [t.x, t.y, t.w, t.h], box: [r.x, r.y, r.w, r.h].map(v => r4(v * REF.dpr)) };
}
async function uncut(page) {
  await page.evaluate(() => {
    document.querySelectorAll('[data-iso]').forEach(e => { e.style.visibility = e.dataset.iso === '-' ? '' : e.dataset.iso; delete e.dataset.iso; });
    const st = document.getElementById('__iso_css'); if (st) st.remove();
    const root = document.documentElement; if (window.__iso) { root.style.cssText = window.__iso.html; document.body.style.cssText = window.__iso.body; }
  });
  await page.waitForTimeout(40);
}

const boxOf = (page, q) => page.evaluate(({ q, dpr }) => { const e = document.querySelector(q); if (!e) return null; const b = e.getBoundingClientRect(); return [b.left, b.top, b.width, b.height].map(v => Math.round(v * dpr * 1e4) / 1e4); }, { q, dpr: REF.dpr });

// the middle card: click its dot (showGames' own go()), then let everything settle
async function select(page, i) {
  const cur = await page.evaluate(() => [...document.querySelectorAll('.sq-slot')].findIndex(s => s.classList.contains('c')));
  if (cur !== i) await page.evaluate(i => document.querySelectorAll('.sq-pos i')[i].click(), i);
  await settle(page);
}

// the app's transitions seeked to `ms` after they started (each keeps its own delay), for the motion checks. The
// values Chrome computes there are then written onto the elements, with every animation and transition off: a
// screenshot of a running (even paused) transform / opacity animation shows the compositor's copy, which doesn't
// follow the seek
async function seek(page, ms, cenMs) {
  await page.evaluate(({ ms, cenMs }) => {
    document.querySelectorAll('.sq-pk video').forEach(v => v.remove());
    const els = new Set();
    for (const a of document.getAnimations()) {
      const t = a.effect && a.effect.target; if (!t || !t.closest || !t.closest('.sq-pk')) continue;
      a.pause();
      a.currentTime = a.effect.getTiming().iterations === Infinity ? 0 : a.animationName === 'sqCen' ? cenMs : ms;
      els.add(t);
    }
    const keep = [...els].map(e => { const cs = getComputedStyle(e);
      return [e, e.matches('.sq-pos i') ? { width: cs.width, 'background-color': cs.backgroundColor, 'border-radius': cs.borderRadius } : { transform: cs.transform, opacity: cs.opacity, filter: cs.filter }]; });
    const st = document.createElement('style'); st.id = '__freeze'; st.textContent = '*,*::before,*::after{transition:none!important;animation:none!important;}'; document.head.appendChild(st);
    window.__frozen = keep.map(([e, v]) => [e, Object.keys(v).map(k => [k, e.style.getPropertyValue(k), e.style.getPropertyPriority(k)])]);
    for (const [e, v] of keep) for (const k in v) e.style.setProperty(k, v[k], 'important');
  }, { ms, cenMs });
  await page.waitForTimeout(120);
}
async function unfreeze(page) {
  await page.evaluate(() => {
    for (const [e, props] of window.__frozen || []) for (const [k, v, pr] of props) { if (v) e.style.setProperty(k, v, pr); else e.style.removeProperty(k); }
    window.__frozen = null;
    const st = document.getElementById('__freeze'); if (st) st.remove();
  });
  await page.waitForTimeout(60);
}

// ---------------------------------------------------------------------------------------------------------------------
if (!SKIP_BUILD) await build(WORK);
fs.rmSync(OUT, { recursive: true, force: true });
fs.mkdirSync(OUT, { recursive: true });
fs.mkdirSync(SHOTS, { recursive: true });
fs.mkdirSync(CLIPS, { recursive: true });

const appList = appGames();
const browser = await chromium.launch({ args: ['--allow-file-access-from-files', '--autoplay-policy=no-user-gesture-required'] });
const { page, errs } = await openPark(browser, appList);
await settle(page);

// the page's own numbers (showGames): k, the page width in its units, the carousel's left edge, the card's width
const geo = await page.evaluate(() => {
  const pg = document.querySelector('.sq-pk .mm-pg'), car = document.querySelector('.sq-car'), slot = document.querySelector('.sq-slot');
  const k = +/scale\(([\d.e-]+)\)/.exec(pg.style.transform)[1];
  const games = [...document.querySelectorAll('.sq-slot')].map(s => ({ lock: s.querySelector('.sq-gc').classList.contains('lock'), squish: !!s.querySelector('.sq-sqz'), jpg: (s.querySelector('img[data-fb]') || {}).getAttribute ? s.querySelector('img[data-fb]').getAttribute('src') : null }));
  return { k, pgW: parseFloat(pg.style.width), carL: parseFloat(car.style.left), CW: parseFloat(slot.style.width), games, sel: window.SquishMenu._x && window.SquishMenu._x.cre ? (window.SquishMenu._x.cre() || {}).key : null };
});
const G = [{ id: 'squish', name: 'Squish Time' }, ...appList].map((g, i) => ({ id: g.id, name: g.name, open: !geo.games[i].lock, squishArt: geo.games[i].squish, clip: !!geo.games[i].jpg }));
if (geo.games.length !== G.length) throw new Error(`the carousel has ${geo.games.length} games, expected ${G.length}`);
console.log('page:', JSON.stringify({ k: geo.k, pgW: geo.pgW, carL: geo.carL, CW: geo.CW, creature: geo.sel }), G.map(g => g.id + (g.open ? '' : ' (locked)')).join(', '));

// the reference screenshots: each game in the middle, and the park without the carousel
const refs = [];
for (let i = 0; i < G.length; i++) {
  await select(page, i);
  const f = `park-${G[i].id}.png`;
  fs.writeFileSync(path.join(SHOTS, f), await page.screenshot());
  refs.push(f);
  if (i === 0) fs.copyFileSync(path.join(SHOTS, f), path.join(REF_DIR, 'park-a15.png'));
}
// (no transitions: 'transition: all' on the dots would keep them visible, the clock being frozen)
await page.evaluate(() => { const st = document.createElement('style'); st.id = '__plate'; st.textContent = '*{transition:none!important;}'; document.head.appendChild(st); document.querySelector('.sq-pk').style.visibility = 'hidden'; });
await page.waitForTimeout(60);
fs.writeFileSync(path.join(SHOTS, 'plate.png'), await page.screenshot());
await page.evaluate(() => { document.querySelector('.sq-pk').style.visibility = ''; document.getElementById('__plate').remove(); });

// the pieces
const pieces = {};
const C = '.sq-slot.c';
await select(page, 0);
pieces.dim = await cut(page, { id: 'dim', q: '.sq-pkdim', file: 'dim' });
pieces.header = await cut(page, { id: 'header', q: '.sq-pk .mm-pgh', file: 'header' });
pieces.header.back = await boxOf(page, '.sq-pk .mm-pgh [data-x]');
pieces.rays = await cut(page, { id: 'rays', q: '.sq-rays', file: 'rays' });
pieces.halo = await cut(page, { id: 'halo', q: '.sq-halo', file: 'halo' });
// the arrows' own look (.off is opacity .4 on top of it)
await page.evaluate(() => document.querySelectorAll('.sq-arr').forEach(a => { a.dataset.off = a.classList.contains('off') ? '1' : ''; a.classList.remove('off'); }));
pieces.arrowL = await cut(page, { id: 'arrowL', q: '.sq-arr.l', file: 'arrow-l' });
pieces.arrowR = await cut(page, { id: 'arrowR', q: '.sq-arr.r', file: 'arrow-r' });
await page.evaluate(() => document.querySelectorAll('.sq-arr').forEach(a => { if (a.dataset.off) a.classList.add('off'); delete a.dataset.off; }));
pieces.dotOn = await cut(page, { id: 'dotOn', q: '.sq-pos i.on', file: 'dot-on' });
pieces.dotOff = await cut(page, { id: 'dotOff', q: '.sq-pos i:not(.on)', file: 'dot-off' });
pieces.car = await boxOf(page, '.sq-car');
pieces.dots = await page.evaluate(dpr => [...document.querySelectorAll('.sq-pos i')].map(e => { const b = e.getBoundingClientRect(); return [b.left, b.top, b.width, b.height].map(v => Math.round(v * dpr * 1e4) / 1e4); }), REF.dpr);
pieces.go = await cut(page, { id: 'go', q: `${C} .go`, file: 'go' });
pieces.goDim = await cut(page, { id: 'goDim', q: `${C} .go`, file: 'go-dim', css: `${C} .go{filter:saturate(.7)!important;}` });
const cards = [];
for (let i = 0; i < G.length; i++) {
  await select(page, i);
  const g = G[i], c = { id: g.id };
  const hideWin = g.squishArt ? ['.go', '.sq-sqz img', '.sq-sqz i'] : ['.go'];
  c.card = await cut(page, { id: 'card', q: `${C} .sq-gc`, file: `cards/${g.id}`, hide: hideWin, css: `${C} .win::after{display:none!important;}` });
  c.slot = await boxOf(page, C);
  c.win = await boxOf(page, `${C} .win`);
  c.go = await boxOf(page, `${C} .go`);
  c.over = await cut(page, { id: 'over', q: `${C} .win`, file: `cards/${g.id}-over`, hide: ['*'], css: `${C} .win{background:transparent!important;box-shadow:none!important;}` });
  c.mask = await cut(page, { id: 'mask', q: `${C} .win`, file: `cards/${g.id}-mask`, hide: ['*'], css: `${C} .win{background:#fff!important;box-shadow:none!important;}${C} .win::after{display:none!important;}` });
  if (g.squishArt) {
    c.squish = {
      img: await cut(page, { id: 'sqz', q: `${C} .sq-sqz img`, file: `cards/${g.id}-creature` }),
      l: await cut(page, { id: 'sqzl', q: `${C} .sq-sqz i.l`, file: `cards/${g.id}-line-l`, css: `${C} .sq-sqz i{animation:none!important;opacity:1!important;}` }),
      r: await cut(page, { id: 'sqzr', q: `${C} .sq-sqz i.r`, file: `cards/${g.id}-line-r`, css: `${C} .sq-sqz i{animation:none!important;opacity:1!important;}` }),
    };
  }
  if (g.clip) {
    const src = path.join(REPO, 'webgame/app/previews', g.id + '.mp4');
    fs.copyFileSync(src, path.join(CLIPS, g.id + '.mp4'));
    // the clip's size (object-fit: cover in the window): the first frame's, read from the jpg next to it
    const jpg = fs.readFileSync(path.join(REPO, 'webgame/app/previews', g.id + '.jpg'));
    c.clip = { file: 'Park/' + g.id + '.mp4', size: jpgSize(jpg) };
  }
  await uncut(page);
  cards.push(c);
}
await uncut(page);

function jpgSize(b) {
  for (let i = 2; i < b.length;) {
    if (b[i] !== 0xff) { i++; continue; }
    const m = b[i + 1], len = b.readUInt16BE(i + 2);
    if (m >= 0xc0 && m <= 0xc3) return [b.readUInt16BE(i + 7), b.readUInt16BE(i + 5)];
    i += 2 + len;
  }
  return null;
}

// what Chrome computed for the cards at a motion frame (to check the Unity code's numbers against)
const computed = page => page.evaluate(() => [...document.querySelectorAll('.sq-slot')].map(s => { const g = s.querySelector('.sq-gc'), cs = getComputedStyle(s), cg = getComputedStyle(g);
  const w = s.querySelector('.win').getBoundingClientRect(), im = s.querySelector('.sq-sqz img');
  return { slot: cs.transform, slotO: +cs.opacity, gc: cg.transform, gcO: +cg.opacity, gcOrigin: cg.transformOrigin, filter: cg.filter, h: g.offsetHeight, sh: s.offsetHeight,
    win: [w.left, w.top, w.width, w.height].map(v => Math.round(v * 2.8125 * 100) / 100), img: im ? getComputedStyle(im).transform : null }; }));

// motion checks: the carousel coming in (its 'in' class added again after it went out), and a change of game
const motion = [];
// (each frame from the start again: freezing a frame ends the transitions)
for (const ms of [120, 300, 600]) {
  await select(page, 0);
  await page.evaluate(() => { const ui = document.querySelector('.sq-pk'); ui.classList.remove('in'); });
  await settle(page);
  await page.evaluate(() => {
    const ui = document.querySelector('.sq-pk'); ui.classList.add('in');
    const s = document.querySelector('.sq-slot.c'); s.classList.remove('c'); void s.offsetWidth; s.classList.add('c');
  });
  // (in the app, the 'in' class comes two frames, ~33 ms, after the cards get theirs: the centre card's flash is ahead)
  await seek(page, ms, ms + 33);
  const f = `in-${ms}.png`; fs.writeFileSync(path.join(SHOTS, f), await page.screenshot()); motion.push({ kind: 'in', ms, file: f, from: 0, css: await computed(page) });
  await unfreeze(page);
}
for (const ms of [100, 250]) {
  await select(page, 0);
  await page.evaluate(() => document.querySelector('.sq-arr.r').click());
  await seek(page, ms, ms);
  const f = `go-${ms}.png`; fs.writeFileSync(path.join(SHOTS, f), await page.screenshot()); motion.push({ kind: 'go', ms, file: f, from: 0, to: 1, css: await computed(page) });
  await unfreeze(page);
}
await settle(page);
await browser.close();

// ---- the layout: the reference's measured boxes, checked against showGames' formulas ----------------------------------
const u = PX.h / 393;                                            // device px per page unit (the page is scale(k), k = H / 393)
const pgW = PX.w / u, carL = Math.round(Math.max(200, pgW * 0.29)), CW = Math.max(300, Math.round(pgW - carL - 118));
const carT = 56, carH = PX.h / u - carT, cx = carL + (pgW - carL) / 2, cy = carT + carH / 2;
const expect = {
  car: [carL, carT, pgW - carL, carH],
  slot: [cx - CW / 2, cy - 175, CW, 318],
  rays: [cx - 280, cy - 294, 560, 560],
  halo: [cx - 160, cy - 174, 320, 320],
  arrowL: [carL + 10, cy - 20, 40, 40],
  arrowR: [pgW - 12 - 40, cy - 20, 40, 40],
};
const pu = b => b.map(v => v / u);
const check = (name, got, want) => { const d = Math.max(...pu(got).map((v, i) => Math.abs(v - want[i]))); if (d > 0.02) throw new Error(`${name}: the page put it at ${pu(got).map(r4)}, the formula says ${want.map(r4)}`); };
if (Math.abs(geo.carL - carL) > 1e-6 || Math.abs(geo.CW - CW) > 1e-6) throw new Error(`carL / CW: page ${geo.carL} / ${geo.CW}, formula ${carL} / ${CW}`);
check('car', pieces.car, expect.car);
check('slot', cards[0].slot, expect.slot);
check('rays', pieces.rays.box, expect.rays);
check('halo', pieces.halo.box, expect.halo);
check('arrowL', pieces.arrowL.box, expect.arrowL);
check('arrowR', pieces.arrowR.box, expect.arrowR);

// every piece: its picture relative to its element's box (px on the reference), so Unity puts it at the box the
// formulas give on any screen
const rel = (p, box) => ({ res: p.res, at: [p.rect[0] - box[0], p.rect[1] - box[1]].map(r4), size: [p.rect[2], p.rect[3]] });
const ofBox = (b, box) => [b[0] - box[0], b[1] - box[1], b[2], b[3]].map(r4);
const layout = {
  note: 'Written by tools/unity/export-park.mjs from webgame/app/menu.js showGames. Units: "pu" = the page\'s CSS px (the park page is scale(k), k = H / 393 dp); "px" = device pixels on the reference screen. Every picture is placed relative to its element\'s box (at = picture top-left minus box top-left, px).',
  reference: { px: [PX.w, PX.h], dp: [REF.w, REF.h], dpr: REF.dpr, k: geo.k, u: r4(u), pgW: r4(pgW), carL, CW, creature: geo.sel || 'mittens' },
  games: G.map((g, i) => ({ id: g.id, name: g.name, open: g.open })),
  dim: { res: pieces.dim.res, box: [0, 0, PX.w, PX.h], rect: pieces.dim.rect },
  header: { ...rel(pieces.header, pieces.header.box), box: pu(pieces.header.box).map(r4), back: ofBox(pieces.header.back, pieces.header.box) },
  rays: rel(pieces.rays, pieces.rays.box), halo: rel(pieces.halo, pieces.halo.box),
  arrowL: rel(pieces.arrowL, pieces.arrowL.box), arrowR: rel(pieces.arrowR, pieces.arrowR.box),
  dotOn: { ...rel(pieces.dotOn, pieces.dotOn.box), box: pu(pieces.dotOn.box).map(r4) }, dotOff: { ...rel(pieces.dotOff, pieces.dotOff.box), box: pu(pieces.dotOff.box).map(r4) },
  dots: pieces.dots.flatMap(b => pu(b).map(r4)),   // (x, y, w, h) of each dot in pu, at rest (flat: JsonUtility reads no nested arrays)
  go: { ...rel(pieces.go, cards[0].go), box: ofBox(cards[0].go, cards[0].slot) },
  goDim: rel(pieces.goDim, cards[0].go),
  cards: cards.map(c => ({
    id: c.id, card: rel(c.card, c.slot), win: ofBox(c.win, c.slot), go: ofBox(c.go, c.slot),
    over: rel(c.over, c.win), mask: rel(c.mask, c.win),
    hasClip: !!c.clip, clip: c.clip || null,
    hasSquish: !!c.squish,
    squish: c.squish ? { img: { ...rel(c.squish.img, c.squish.img.box), box: ofBox(c.squish.img.box, c.win) }, l: { ...rel(c.squish.l, c.squish.l.box), box: ofBox(c.squish.l.box, c.win) }, r: { ...rel(c.squish.r, c.squish.r.box), box: ofBox(c.squish.r.box, c.win) } } : null,
  })),
  shots: { dir: path.relative(REPO, SHOTS), plate: 'plate.png', each: refs, motion },
};
write('park.json', JSON.stringify(layout, null, 1));
const files = fs.readdirSync(OUT, { recursive: true }).filter(f => /\.png$/.test(f));
const bytes = files.reduce((n, f) => n + fs.statSync(path.join(OUT, f)).size, 0);
console.log(`park: ${files.length} pictures, ${(bytes / 1048576).toFixed(1)} MB -> ${path.relative(REPO, OUT)}; clips -> ${path.relative(REPO, CLIPS)}; shots -> ${path.relative(REPO, SHOTS)}`);
for (const p of ['dim', 'header', 'rays', 'halo', 'arrowL', 'dotOn', 'go']) console.log(`  ${p}: ${pieces[p].rect.slice(2).join('x')} px`);
for (const c of cards) console.log(`  card ${c.id}: ${c.card.rect.slice(2).join('x')} px`);
for (const e of [...new Set(errs)].slice(0, 8)) console.log('  page error:', e.slice(0, 200));
