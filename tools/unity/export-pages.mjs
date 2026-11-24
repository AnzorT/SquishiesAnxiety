// Exports two of the Main Menu's pages, CHARACTERS and the LEVEL PASS (webgame/app/menu.js §4 M.levels and §5
// M.characters), exactly as the app draws them, as art the Unity app loads (unity/Assets/Resources/LevelPass and
// Resources/Characters), and the app's own screenshots of them to compare with (webgame/test/out/unity-pages).
//
//   node tools/unity/export-pages.mjs                 (--no-build reuses the last web build of export-menu.mjs)
//   node tools/unity/export-pages.mjs --only lp|ch    one page
//   node tools/unity/export-pages.mjs --shots-only    only the screenshots (the art as it is)
//
// The menu is opened in Chromium at the Galaxy A15's size (832 x 384 dp, 2.8125 px per dp = 2340 x 1080 px) with the
// clock frozen, as the app opens it: inside the app (window.ReactNativeWebView, so claims go to "the app" and wait for
// its answer, as on the phone) with a test player's state (app/bridge.js __SQUISH_INIT__: coins, the creatures owned,
// the one in use, the XP view and the level road, as src/game/player.js gamePlayer() sends them).
// Every piece is cut out of the page on its own device-pixel grid (the rest of the page hidden, background
// transparent), with where it sits relative to its element's box, so Unity puts the box where the page's CSS says for
// the screen at hand and the picture at the same offset from it. Pictures are written as <name>.png.bytes (decoded by
// Unity at run time, so they go in exactly as cut, whatever the texture import settings) and the backgrounds as JPEG
// (<name>.jpg.bytes, quality 95, full-resolution colour).
//
// What is cut, and what Unity draws itself:
//   Level Pass   the background, the back orb and title, the wood / gold boxes of the header's pills and of the
//                panel (cut wide: Unity shows their left part up to the width it needs, then their right end), the coin,
//                the XP bar, the rail and its gold fill, the "you" marker and every creature in it, each level button's
//                disc in its five looks, its number (lit or not) and its three badges, the selected one's arrow, each
//                panel title (LEVEL n, gold or white), the lines under it, the CLAIM / Claiming… / CLAIMED buttons,
//                every reward card (coins, gems, each group's chest of each size, rooms, yard games, the house's looks)
//                and the flying coin / gem. The texts with the player's numbers (LV n, the XP, the coins, CLAIM ALL (n),
//                "n XP to go") are drawn by Unity with the app's fonts (Ui/UiFont + UiSvg), as the HUD's pills are.
//   Characters   the background, the back orb and title, the rays, the platform (its side, its plate's glow and centre,
//                its turning stripes frame by frame over the 30° they repeat in, both bulbs), every creature's card in
//                the row (owned and locked), its card in the loading screen, its name plate and still (and the still's
//                silhouette), the rarity and group tags, CHOOSE / "Find it in chests", the arrows, the group labels,
//                the selected ring and IN USE tag, and the loading screen's pieces ("Gathering your squad": its
//                background, rays, title, the count for every number of creatures, the deck, the card back, the band,
//                the bar, its knob, every percentage and every tip). The toast's text is drawn by Unity.
//   The creatures stand on the platform as their still picture: the app shows each one's live rig there, and Unity
//   has only Mittens' recorded rig so far (the comparison shots show the still in the app too).
import fs from 'node:fs';
import path from 'node:path';
import { createRequire } from 'node:module';
import { fileURLToPath, pathToFileURL } from 'node:url';
import { execFileSync } from 'node:child_process';
import { PNG } from 'pngjs';

const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
const squad = require('../../functions/squad.js');
const HERE = path.dirname(fileURLToPath(import.meta.url));
const REPO = path.resolve(HERE, '../..');
const RES = path.join(REPO, 'unity/Assets/Resources');
const SHOTS = path.join(REPO, 'webgame/test/out/unity-pages');
const WORK = path.join(REPO, 'webgame/test/out/unity-webgame');
const arg = (k, d) => { const i = process.argv.indexOf('--' + k); return i > 0 ? process.argv[i + 1] : d; };
const ONLY = arg('only', 'lp,ch').split(',');
const PATCH = arg('patch', null);   // (development: --patch rays recuts only the Characters page's rays into its json)
const SKIP_BUILD = process.argv.includes('--no-build');
const SHOTS_ONLY = process.argv.includes('--shots-only');
const FEW = process.argv.includes('--few');   // (development: a few creatures only)

const REF = { w: 832, h: 384, dpr: 2.8125 };
const PX = { w: Math.round(REF.w * REF.dpr), h: Math.round(REF.h * REF.dpr) };
const K = REF.h / 393, U = K * REF.dpr;          // the page's scale (.mm-pg scale(k), k = H / 393) and px per page px
const T0 = new Date('2026-11-13T12:00:00Z');
const DAY = '2026-11-13';
const SEED = `(() => { let s = 0x2f6b9a1; Math.random = () => { s ^= s << 13; s >>>= 0; s ^= s >>> 17; s ^= s << 5; s >>>= 0; return s / 4294967296; }; })();`;
const r4 = v => Math.round(v * 1e4) / 1e4;
const PLQ = ['v-wood', 'v-bronze', 'v-amy', 'v-gold', 'v-rainbow'], NFT = ['wood', 'bronze', 'amethyst', 'whiteB', 'white'];   // (menu.js: the name plate's look and lettering by rarity)

// ---- the test player (what App.js gamePlayer() sends the menu) ---------------------------------------------------------
// level 7 with 230 / 800 XP, levels 1-4 claimed (5, 6, 7 wait), 12,345 coins; the demo save's 18 creatures, Mittens in use
const PLAYER = { pxp: 2930, levelGot: { 1: true, 2: true, 3: true, 4: true }, coins: 12345, gems: 600 };
function roadOf(p, day) {
  const pl = squad.playerLevel(p.pxp), got = p.levelGot || {};
  return squad.DEFAULT_LEVELS.road.map((r, i) => {
    const lv = i + 1, reached = pl.level >= lv, t = r.t ? (r.t === 'set' ? 'legendary' : r.t) : null;   // (shownSize: a Rainbow one comes as a Legendary)
    const g = r.k === 'chest' ? squad.prizeGroup(r, day) : null, grp = g && squad.GROUPS.find(x => x.key === g);
    return { lv, k: r.k, n: r.n || 0, t, g, gn: grp ? grp.name : null, cn: g && t ? CHEST_NAMES[g][squad.SIZE_I[t]] : null, got: reached && !!got[lv], claimable: reached && !got[lv] };
  });
}
const CHEST_NAMES = JSON.parse(/CHEST_NAMES = (\{.*\});/.exec(fs.readFileSync(path.join(REPO, 'src/squad/groupChestArt.js'), 'utf8'))[1]);
function stateOf(p, day) {
  const pl = squad.playerLevel(p.pxp);
  return { level: pl.level, coins: p.coins, gems: p.gems, xp: { level: pl.level, into: pl.into, need: pl.need, per: 100 }, road: roadOf(p, day) };
}

// ---- the page ------------------------------------------------------------------------------------------------------------
function trimBox(png) {
  const { width: W, height: H, data } = png;
  let x0 = W, y0 = H, x1 = -1, y1 = -1;
  for (let y = 0; y < H; y++) for (let x = 0; x < W; x++) if (data[(y * W + x) * 4 + 3]) { if (x < x0) x0 = x; if (x > x1) x1 = x; if (y < y0) y0 = y; if (y > y1) y1 = y; }
  return x1 < 0 ? null : { x: x0, y: y0, w: x1 - x0 + 1, h: y1 - y0 + 1 };
}
function crop(png, b) { const o = new PNG({ width: b.w, height: b.h }); PNG.bitblt(png, o, b.x, b.y, b.w, b.h, 0, 0); return o; }

async function openApp(browser, state) {
  const ctx = await browser.newContext({ viewport: { width: REF.w, height: REF.h }, deviceScaleFactor: REF.dpr });
  const page = await ctx.newPage();
  const errs = [];
  page.on('pageerror', e => errs.push(e.message));
  await page.route(/^https?:/, r => { errs.push('internet: ' + r.request().url()); r.abort(); });
  await page.addInitScript(SEED);
  // The page's loaders keep time with their Web Animations (develop, PERF 2026-11-20: menu.js gatherSquad's clock() is
  // document.timeline.currentTime - its first animation's startTime). The animations are held still here (CDP playback
  // rate 0) and seeked by hand, so that clock would stand still: it reads the virtual clock instead (performance.now,
  // which page.clock moves), each animation's start being the virtual moment it was made.
  await page.addInitScript(() => {
    try { Object.defineProperty(document.timeline, 'currentTime', { configurable: true, get: () => performance.now() }); } catch (e) { /* kept */ }
    const animate = Element.prototype.animate;
    Element.prototype.animate = function (k, o) {
      const a = animate.call(this, k, o), st = performance.now();
      try { Object.defineProperty(a, 'startTime', { configurable: true, get: () => st, set() {} }); } catch (e) { /* kept */ }
      return a;
    };
  });
  // inside the app: messages go to "the app" (kept in __sent), its player seeded into the engines' saves
  await page.addInitScript(st => { window.__squishOutbox = []; window.ReactNativeWebView = { postMessage(m) { (window.__sent = window.__sent || []).push(JSON.parse(m)); } }; window.__SQUISH_INIT__ = { state: st }; }, state);
  await page.clock.install({ time: T0 });
  await page.clock.pauseAt(T0);
  const cdp = await ctx.newCDPSession(page);
  await cdp.send('Animation.enable');
  await cdp.send('Animation.setPlaybackRate', { playbackRate: 0 });
  await page.goto(pathToFileURL(path.join(WORK, 'App.dc.html')).href);
  await page.waitForTimeout(8000);
  for (let t = 0; t < 9000; t += 500) { await page.clock.runFor(500); await page.waitForTimeout(150); }
  await page.evaluate(() => document.fonts.ready);
  await page.waitForTimeout(800);
  // the time base for the page's motions: every animation that starts from here on is noted with the (virtual) time
  await page.evaluate(() => { window.__born = new Map(); window.__now = 0; });
  return { ctx, page, errs };
}

// the virtual clock moved on `ms` in small steps, noting when each new animation / transition started
async function advance(page, ms, step = 8) {
  for (let t = 0; t < ms; t += step) {
    const d = Math.min(step, ms - t);
    await page.clock.runFor(d);
    // (a timer's class change starts its transition at the timer's time: the steps meet the page's timers, all on 4 ms)
    await page.evaluate(d => { window.__now += d; for (const a of document.getAnimations()) if (!window.__born.has(a)) window.__born.set(a, window.__now); }, d);
  }
}
const note = page => page.evaluate(() => { for (const a of document.getAnimations()) if (!window.__born.has(a)) window.__born.set(a, window.__now); });

// every animation seeked to where it is at the current virtual time (`endless`: the endless ones at this time since the
// page opened instead), then frozen there: the values Chrome computes written onto the elements with animations off
// (a screenshot of a paused compositor animation shows the compositor's copy, which doesn't follow a seek)
async function freeze(page, opts = {}) {
  await page.evaluate(({ endless, finish }) => {
    const els = new Map();
    for (const a of document.getAnimations()) {
      const t = a.effect && a.effect.target; if (!t) continue;
      if (!t.closest || !t.closest('.mm-page2')) continue;   // (the menu under the page stays as it is)
      a.pause();
      const inf = a.effect.getTiming().iterations === Infinity, born = window.__born.get(a) ?? window.__now;
      if (finish && !inf) a.finish();
      else a.currentTime = inf && endless != null ? endless : Math.max(0, window.__now - born);
      els.set(t, a.effect.pseudoElement || '');
    }
    const keep = [...els.keys()].map(e => { const cs = getComputedStyle(e); return [e, { transform: cs.transform, opacity: cs.opacity, filter: cs.filter, width: cs.width, left: cs.left, 'background-color': cs.backgroundColor }]; });
    const st = document.createElement('style'); st.id = '__freeze'; st.textContent = '*,*::before,*::after{transition:none!important;animation:none!important;}'; document.head.appendChild(st);
    window.__frozen = keep.map(([e, v]) => [e, Object.keys(v).map(k => [k, e.style.getPropertyValue(k), e.style.getPropertyPriority(k)])]);
    for (const [e, v] of keep) for (const k in v) e.style.setProperty(k, v[k], 'important');
  }, { endless: opts.endless ?? null, finish: !!opts.finish });
  await page.waitForTimeout(150);
}
async function unfreeze(page) {
  await page.evaluate(() => {
    for (const [e, props] of window.__frozen || []) for (const [k, v, pr] of props) { if (v) e.style.setProperty(k, v, pr); else e.style.removeProperty(k); }
    window.__frozen = null;
    const st = document.getElementById('__freeze'); if (st) st.remove();
    for (const a of document.getAnimations()) { if (a.playState === 'paused') a.play(); }
  });
  await page.waitForTimeout(60);
}
// the page at rest: every finite motion finished, the endless ones at `endless` ms
const settle = (page, endless = 0) => freeze(page, { finish: true, endless });

// one piece on its own: everything else hidden, transparent background. `q`: a selector (`i`: which match); `hide`:
// selectors inside it hidden; `css`: added while it's cut. Returns its picture (written to `dir/file`) and its box.
async function cut(page, dir, file, P) {
  const r = await page.evaluate(({ q, i, hide, css }) => {
    const root = document.documentElement;
    if (!window.__iso) window.__iso = { html: root.style.cssText, body: document.body.style.cssText };
    document.querySelectorAll('[data-iso]').forEach(e => { e.style.visibility = e.dataset.iso === '-' ? '' : e.dataset.iso; delete e.dataset.iso; });
    let st = document.getElementById('__iso_css'); if (!st) { st = document.createElement('style'); st.id = '__iso_css'; document.head.appendChild(st); }
    st.textContent = '*,*::before,*::after{transition:none!important;}' + (css || '');
    const el = typeof q === 'string' ? document.querySelectorAll(q)[i || 0] : null;
    if (!el) return null;
    root.style.visibility = 'hidden'; root.style.background = 'transparent'; document.body.style.background = 'transparent';
    const mark = (e, v) => { e.dataset.iso = e.style.visibility || '-'; e.style.visibility = v; };
    mark(el, 'visible');
    for (const h of hide || []) el.querySelectorAll(h).forEach(e => mark(e, 'hidden'));
    const b = el.getBoundingClientRect();
    return { x: b.left, y: b.top, w: b.width, h: b.height };
  }, P);
  if (!r) throw new Error('no element for ' + file + ' (' + P.q + ')');
  await page.waitForTimeout(30);
  const png = PNG.sync.read(await page.screenshot({ omitBackground: true }));
  const t = trimBox(png);
  if (!t) throw new Error(file + ' drew nothing');
  if (!SHOTS_ONLY) { const f = path.join(dir, file + '.png.bytes'); fs.mkdirSync(path.dirname(f), { recursive: true }); fs.writeFileSync(f, PNG.sync.write(crop(png, t))); }
  const box = [r.x, r.y, r.w, r.h].map(v => v * REF.dpr);
  // res: the Resources name (without .png); at: picture top-left minus the box's top-left (px); box: the element's box (page px)
  return { res: file, at: [r4(t.x - box[0]), r4(t.y - box[1])], size: [t.w, t.h], box: box.map(v => r4(v / U)) };
}
// a piece bigger than the screen (the rays, which turn: all of it is needed): moved (the `translate` property, in the
// page's px) so its box starts at the screen's top-left, cut a screen at a time and put together. A screen is 393 x
// pgW page px, exactly 1080 x 2340 px, so the tiles meet on whole pixels.
// the platform's moving pieces: the plate's stripes turn (12 s a turn) and repeat every 30°: 60 frames, every half
// degree; a bulb of each colour at rest (translate(100px, 20px), scale 1). (The frozen motions' own values come off
// first: they'd win over the cut's.)
async function platformPieces(page, OUT) {
  await page.evaluate(() => document.querySelectorAll('.sq-c2 .ring .turn, .sq-c2 .ring .bp').forEach(e => e.style.removeProperty('transform')));
  const P = { stripes: [] };
  for (let i = 0; i < 60; i++) {
    const deg = i * 0.5;
    P.stripes.push({ deg, ...(await cut(page, OUT, `stripes/${i}`, { q: '.sq-c2 .ring .plate', css: `.sq-c2 .ring .turn{animation:none!important;transform:rotate(${deg}deg)!important;}.sq-c2 .ring .plate{box-shadow:none!important;background:repeating-conic-gradient(#ffe9a0 0deg 15deg,#f6c457 15deg 30deg)!important;}` })) });
  }
  const atRest = '.sq-c2 .ring .bp{animation:none!important;transform:translate(100px,20px)!important;}';
  P.bulb = await cut(page, OUT, 'bulb', { q: '.sq-c2 .ring .b:not(.w)', css: atRest });
  P.bulbW = await cut(page, OUT, 'bulb-w', { q: '.sq-c2 .ring .b.w', css: atRest });
  await uncut(page);
  return P;
}
// the stills on the platform (and their silhouette, .rig.sil: the frozen filter off first), the "you" marker's picture
async function stillPieces(page, OUT, LP, list) {
    // the stills on the platform (and their silhouette, .rig.sil), the "you" marker's picture (Level Pass)
  const stills = [];
    for (const c of list) {
      const src = await page.evaluate(id => document.querySelector(`.sq-c2 .row [data-id="${id}"] img.art`).getAttribute('src'), c.id);
      await page.evaluate(src => { const host = document.querySelector('.sq-c2 .rig'); host.className = 'rig'; host.innerHTML = '<img alt="" style="position:absolute;inset:0;width:100%;height:100%;object-fit:contain" src="' + src + '">';
        let y = document.getElementById('__you'); if (!y) { y = document.createElement('div'); y.id = '__you'; y.className = 'sq-you'; y.style.left = '300px'; y.style.top = '100px'; document.querySelector('.mm-page2 .mm-pg').appendChild(y); }
        y.innerHTML = '<img alt="" src="' + src + '">'; }, src);
      await page.waitForFunction(() => [...document.querySelectorAll('.sq-c2 .rig img, #__you img')].every(i => i.complete && i.naturalWidth > 0));
      const s = await cut(page, OUT, `still/${c.key}`, { q: '.sq-c2 .rig' });
      await page.evaluate(() => { const r = document.querySelector('.sq-c2 .rig'); r.className = 'rig sil'; r.style.removeProperty('filter'); });
      const sil = await cut(page, OUT, `still/${c.key}-sil`, { q: '.sq-c2 .rig' });
      const you = await cut(page, LP, `you/${c.key}`, { q: '#__you', css: '#__you{background:none!important;box-shadow:none!important;}' });
      stills.push({ key: c.key, still: s, sil, you });
    }
  return stills;
}
async function patchRays() {
  const OUT = path.join(RES, 'Characters'), f = path.join(OUT, 'characters.json'), L = JSON.parse(fs.readFileSync(f, 'utf8'));
  const { page } = await openApp(browser, { coins: PLAYER.coins, gems: PLAYER.gems });
  await page.evaluate(() => { window.__born = new Map(); window.__now = 0; window.SquishMenu.characters(window.SquishMenu._x); });
  await advance(page, 1200, 16); await freeze(page, {});
  L.gs.rays = await cutWhole(page, OUT, 'gs/rays', '.sq-gs .rays', '.sq-gs .rays{transform:none!important;}');
  await unfreeze(page); await advance(page, 3000, 50); await settle(page, 0);
  L.rays = await cutWhole(page, OUT, 'rays', '.sq-c2 > .rays', '');
  Object.assign(L, await platformPieces(page, OUT));
  if (process.argv.includes('--stills')) {
    const list = L.roster.filter(c => !FEW || ['mittens', 'biscuit', 'octo'].includes(c.key));
    L.stills = await stillPieces(page, OUT, path.join(RES, 'LevelPass'), list);
  }
  fs.writeFileSync(f, JSON.stringify(L, null, 1));
  await page.context().close();
}
async function cutWhole(page, dir, file, q, css) {
  await page.evaluate(q => document.querySelector(q).style.removeProperty('transform'), q);   // (at its turn's start: 0°)
  const b = await page.evaluate(({ q, U }) => { const e = document.querySelector(q), r = e.getBoundingClientRect(), k = U / 2.8125; return [r.left / k, r.top / k, r.width / k, r.height / k]; }, { q, U });
  const pgW = PX.w / U, W = Math.ceil(b[2] * U), H = Math.ceil(b[3] * U);
  const out = new PNG({ width: W, height: H });
  for (let ty = 0; ty * 393 < b[3]; ty++)
    for (let tx = 0; tx * pgW < b[2]; tx++) {
      const sh = `${q}{translate:${-b[0] - tx * pgW}px ${-b[1] - ty * 393}px!important;}`;
      try { await cut(page, dir, '__tile', { q, css: css + sh }); } catch (e) { if (!/drew nothing/.test(e.message)) throw e; }   // (an empty corner)
      const png = PNG.sync.read(await page.screenshot({ omitBackground: true }));
      PNG.bitblt(png, out, 0, 0, Math.min(PX.w, W - tx * PX.w), Math.min(PX.h, H - ty * PX.h), tx * PX.w, ty * PX.h);
    }
  await uncut(page);
  if (!SHOTS_ONLY) { fs.rmSync(path.join(dir, '__tile.png.bytes'), { force: true }); fs.writeFileSync(path.join(dir, file + '.png.bytes'), PNG.sync.write(out)); }
  return { res: file, at: [0, 0], size: [W, H], box: b.map(r4) };
}
async function uncut(page) {
  await page.evaluate(() => {
    document.querySelectorAll('[data-iso]').forEach(e => { e.style.visibility = e.dataset.iso === '-' ? '' : e.dataset.iso; delete e.dataset.iso; });
    const st = document.getElementById('__iso_css'); if (st) st.remove();
    const root = document.documentElement; if (window.__iso) { root.style.cssText = window.__iso.html; document.body.style.cssText = window.__iso.body; }
  });
  await page.waitForTimeout(30);
}
// a background (opaque, the whole screen): JPEG via Pillow
async function cutJpeg(page, dir, file, css) {
  await page.evaluate(css => { const st = document.createElement('style'); st.id = '__bg_css'; st.textContent = '*,*::before,*::after{transition:none!important;}' + css; document.head.appendChild(st); }, css);
  await page.waitForTimeout(60);
  const tmp = path.join(SHOTS, '__' + path.basename(file) + '.png');
  fs.writeFileSync(tmp, await page.screenshot());
  await page.evaluate(() => document.getElementById('__bg_css').remove());
  if (!SHOTS_ONLY) {
    fs.mkdirSync(path.dirname(path.join(dir, file)), { recursive: true });
    execFileSync('python3', ['-c', 'import sys\nfrom PIL import Image\nImage.open(sys.argv[1]).convert("RGB").save(sys.argv[2],format="JPEG",quality=95,subsampling=0,optimize=True)', tmp, path.join(dir, file + '.jpg.bytes')]);
  }
  fs.rmSync(tmp);
  return { res: file, size: [PX.w, PX.h] };
}
const boxOf = (page, q, i = 0) => page.evaluate(({ q, i, U }) => { const e = document.querySelectorAll(q)[i]; if (!e) return null; const b = e.getBoundingClientRect(); return [b.left, b.top, b.width, b.height].map(v => Math.round(v * 2.8125 / U * 1e4) / 1e4); }, { q, i, U });
const shot = async (page, name) => { fs.writeFileSync(path.join(SHOTS, name + '.png'), await page.screenshot()); return name + '.png'; };
// the menu under the page at the same moment (the page hidden): what a frame of the opening is composited over
const plateShot = async (page, name) => {
  await page.evaluate(() => { const st = document.createElement('style'); st.id = '__plate'; st.textContent = '.mm-page2{visibility:hidden!important;}'; document.head.appendChild(st); });
  await page.waitForTimeout(60);
  const f = await shot(page, name + '-menu');
  await page.evaluate(() => document.getElementById('__plate').remove());
  return f;
};
// (--shots-only: only the json's screenshots and the moments measured with them are brought up to date)
const write = (dir, name, obj) => {
  const f = path.join(dir, name);
  if (SHOTS_ONLY) { const old = JSON.parse(fs.readFileSync(f, 'utf8')); old.shots = obj.shots; if (obj.awayAt != null) old.awayAt = obj.awayAt; if (obj.measured) old.measured = obj.measured; obj = old; }
  fs.writeFileSync(f, JSON.stringify(obj, null, 1));
};

// ---------------------------------------------------------------------------------------------------------------------
if (!SKIP_BUILD) { const { build } = await import('../../webgame/build.mjs'); await build(WORK); }
fs.mkdirSync(SHOTS, { recursive: true });
const browser = await chromium.launch({ args: ['--allow-file-access-from-files'] });
const shotsOut = { dir: path.relative(REPO, SHOTS) };
if (ONLY.includes('lp')) shotsOut.lp = await levelPass();
if (PATCH === 'rays') await patchRays();
else if (ONLY.includes('ch')) shotsOut.ch = await characters();
await browser.close();
// the pictures recompressed losslessly (Pillow's optimize: ~10 % smaller, the same pixels)
if (!SHOTS_ONLY) for (const d of ['LevelPass', 'Characters']) if (fs.existsSync(path.join(RES, d)))
  execFileSync('python3', ['-c', 'import sys,os,io\nfrom PIL import Image\nfor r,_,fs in os.walk(sys.argv[1]):\n  for f in fs:\n    if f.endswith(".png.bytes"):\n      p=os.path.join(r,f);b=open(p,"rb").read();o=io.BytesIO();Image.open(io.BytesIO(b)).save(o,format="PNG",optimize=True)\n      if len(o.getvalue())<len(b): open(p,"wb").write(o.getvalue())', path.join(RES, d)]);
console.log('shots ->', path.relative(REPO, SHOTS));

// =====================================================================================================================
// The Level Pass
// =====================================================================================================================
async function levelPass() {
  const OUT = path.join(RES, 'LevelPass');
  // (you/: the marker's creatures, written by the Characters part)
  if (!SHOTS_ONLY) { fs.mkdirSync(OUT, { recursive: true }); for (const f of fs.readdirSync(OUT)) if (f !== 'you') fs.rmSync(path.join(OUT, f), { recursive: true, force: true }); }
  const state = stateOf(PLAYER, DAY);
  const { page, errs } = await openApp(browser, state);
  const plate = await shot(page, 'menu');                                    // the menu under the page (the opening's backdrop)
  const open = async () => {
    await page.evaluate(() => { window.__born = new Map(); window.__now = 0; window.SquishMenu.levels(window.SquishMenu._x); });
    await note(page);
  };
  const close = () => page.evaluate(() => { const b = document.querySelector('.mm-page2 [data-x]'); if (b) b.click(); });

  // ---- the app's screenshots ----
  const shots = [];
  // the opening (mmPage .42s), timed frames
  for (const ms of [60, 140, 240, 360]) {
    await open(); await advance(page, ms); await freeze(page, {});
    shots.push({ name: 'lp-open-' + ms, file: await shot(page, 'lp-open-' + ms), plate: await plateShot(page, 'lp-open-' + ms), ms, sel: 5, scroll: 0, endless: ms });
    await unfreeze(page); await close();
  }
  await open(); await advance(page, 600);
  await settle(page, 0);
  const track = await page.evaluate(() => { const t = document.querySelector('.sq-lvtrack'); return { scrollLeft: t.scrollLeft, scrollWidth: t.scrollWidth, clientWidth: t.clientWidth }; });
  shots.push({ name: 'lp-top', file: await shot(page, 'lp-top'), sel: 5, scroll: track.scrollLeft, endless: 0 });
  // what the page measured (the Unity layout is checked against these)
  const measured = await page.evaluate(U => {
    const B = (q, i) => { const e = document.querySelectorAll(q)[i || 0]; if (!e) return null; const b = e.getBoundingClientRect(); return [b.left, b.top, b.width, b.height].map(v => Math.round(v * 2.8125 / U * 1e4) / 1e4); };
    return { pgh: B('.mm-pgh'), all: B('.sq-lvall'), lvx: B('.sq-lvx'), lvxB: B('.sq-lvx b'), bar: B('.sq-lvbar'), fill: B('.sq-lvbar i'), small: B('.sq-lvx small'), pill: B('.sq-coins'), pillImg: B('.sq-coins img'), pillTx: B('.sq-coins span'),
      track: B('.sq-lvtrack'), rail: B('.sq-rail'), railFill: B('.sq-rail i'), you: B('.sq-you'), youp: B('.sq-youp'), ln1: B('.sq-ln', 0), panel: B('.sq-lvpan'), lv: B('.sq-lvpan .lv'), act: B('.sq-lvpan .act'), items: B('.sq-lvpan .items'), it: B('.sq-it', 0) };
  }, U);
  await unfreeze(page);
  // scrolled
  await page.evaluate(() => { document.querySelector('.sq-lvtrack').scrollLeft = 1234; });
  await settle(page, 0);
  shots.push({ name: 'lp-scrolled', file: await shot(page, 'lp-scrolled'), sel: 5, scroll: 1234, endless: 0 });
  await unfreeze(page);
  // a level not reached yet: its rewards, "n XP to go"
  await page.evaluate(() => { document.querySelector('.sq-lvtrack').scrollLeft = 0; document.querySelector('.sq-ln[data-l="9"]').click(); });
  await advance(page, 50); await settle(page, 0);
  shots.push({ name: 'lp-locked', file: await shot(page, 'lp-locked'), sel: 9, scroll: 0, endless: 0 });
  await unfreeze(page);
  // the Backyard's level: three rewards
  await page.evaluate(() => { document.querySelector('.sq-ln[data-l="8"]').click(); });
  await advance(page, 50); await settle(page, 0);
  shots.push({ name: 'lp-three', file: await shot(page, 'lp-three'), sel: 8, scroll: 0, endless: 0 });
  await unfreeze(page);
  // CLAIM on level 6 (coins): the app is asked; "Claiming…" until it answers
  await page.evaluate(() => { document.querySelector('.sq-ln[data-l="6"]').click(); });
  await advance(page, 50);
  await page.evaluate(() => { document.querySelector('.sq-lvpan [data-claim]').click(); });
  await advance(page, 50); await settle(page, 700);
  shots.push({ name: 'lp-claiming', file: await shot(page, 'lp-claiming'), sel: 6, scroll: 0, endless: 700, pending: [6] });
  const sent = await page.evaluate(() => (window.__sent || []).filter(m => m.type === 'claim'));
  await unfreeze(page);
  await close();

  // ---- the pieces ----
  let P = {};
  if (!SHOTS_ONLY) {
    await open(); await advance(page, 600); await settle(page, 0);
    P.bg = await cutJpeg(page, OUT, 'bg', '.mm-page2 .mm-pg{visibility:hidden!important;}');
    P.head = await cut(page, OUT, 'head', { q: '.mm-pgh', hide: ['.sq-lvall', '.sq-lvx', '.sq-coins'] });
    P.back = await boxOf(page, '.mm-pgh [data-x]');
    // the boxes with text Unity draws, cut wide and empty
    P.allBox = await cut(page, OUT, 'claim-all', { q: '.sq-lvall', css: '.sq-lvall{width:300px!important;color:transparent!important;}' });
    P.lvxBox = await cut(page, OUT, 'lvx', { q: '.sq-lvx', hide: ['*'], css: '.sq-lvx{position:absolute!important;left:20px!important;top:18px!important;width:500px!important;}' });
    P.pillBox = await cut(page, OUT, 'pill', { q: '.sq-coins', hide: ['*'], css: '.sq-coins{position:absolute!important;left:20px!important;top:20px!important;width:300px!important;}' });
    P.coin = await cut(page, OUT, 'coin', { q: '.sq-coins img' });
    P.bar = await cut(page, OUT, 'bar', { q: '.sq-lvbar', hide: ['i'] });
    P.barFill = await cut(page, OUT, 'bar-fill', { q: '.sq-lvbar i', css: '.sq-lvbar i{width:118px!important;}' });
    // the rail and its fill, cut long
    P.rail = await cut(page, OUT, 'rail', { q: '.sq-rail', hide: ['i'], css: '.sq-rail{width:800px!important;}' });
    P.railFill = await cut(page, OUT, 'rail-fill', { q: '.sq-rail i', css: '.sq-rail{width:800px!important;}.sq-rail i{width:780px!important;}' });
    P.railFill.box = await boxOf(page, '.sq-rail i');
    P.you = await cut(page, OUT, 'you', { q: '.sq-you', hide: ['img'] });
    P.youPtr = await cut(page, OUT, 'you-ptr', { q: '.sq-youp' });
    // a level's button: its disc (no number, badge or arrow) in each look, cut on level 2 (claimed: on), 9 (locked: off)
    const noText = n => `.sq-ln[data-l="${n}"]{color:transparent!important;text-shadow:none!important;}.sq-ln[data-l="${n}"]::after{display:none!important;}`;
    const discs = [];
    const look = async (id, n, cls) => {
      await page.evaluate(({ n, cls }) => { const b = document.querySelector(`.sq-ln[data-l="${n}"]`); b.dataset.was = b.className; b.className = 'sq-ln ' + cls; }, { n, cls });
      discs.push({ id, ...(await cut(page, OUT, 'disc-' + id, { q: `.sq-ln[data-l="${n}"]`, hide: ['.st'], css: noText(n) })) });
      await page.evaluate(n => { const b = document.querySelector(`.sq-ln[data-l="${n}"]`); b.className = b.dataset.was; }, n);
    };
    await look('off', 9, ''); await look('on', 2, 'on'); await look('cl', 2, 'on cl'); await look('sel', 2, 'on sel'); await look('offsel', 9, 'sel');
    P.discs = discs;
    // the arrow under the selected one (::after)
    await page.evaluate(() => { const b = document.querySelector('.sq-ln[data-l="2"]'); b.dataset.was = b.className; b.className = 'sq-ln on sel'; });
    P.arrow = await cut(page, OUT, 'arrow', { q: '.sq-ln[data-l="2"]', hide: ['.st'], css: '.sq-ln[data-l="2"]{color:transparent!important;text-shadow:none!important;background:none!important;box-shadow:none!important;}' });
    await page.evaluate(() => { const b = document.querySelector('.sq-ln[data-l="2"]'); b.className = b.dataset.was; });
    // the badges, on level 2 (ok), 6 (!), 9 (lock)
    P.badges = [];
    for (const [id, n] of [['ok', 2], ['ex', 6], ['lkb', 9]]) P.badges.push({ id, ...(await cut(page, OUT, 'badge-' + id, { q: `.sq-ln[data-l="${n}"] .st`, css: `.sq-ln[data-l="${n}"]{animation:none!important;transform:none!important;}` })), button: await boxOf(page, `.sq-ln[data-l="${n}"]`) });
    // every number, lit (on) and not
    P.nums = [];
    const N = state.road.length;
    const bare = n => `.sq-ln[data-l="${n}"]{background:none!important;box-shadow:none!important;animation:none!important;transform:none!important;}.sq-ln[data-l="${n}"]::after{display:none!important;}`;
    await page.evaluate(() => { document.querySelectorAll('.sq-ln').forEach(b => { b.dataset.was = b.className; b.classList.remove('cur', 'cl', 'sel'); }); });
    for (const on of [true, false]) {
      await page.evaluate(on => document.querySelectorAll('.sq-ln').forEach(b => b.classList.toggle('on', on)), on);
      for (let L = 1; L <= N; L++) {
        await page.evaluate(L => { const t = document.querySelector('.sq-lvtrack'); t.scrollLeft = Math.max(0, 44 + (L - 1) * 84 - 400); }, L);
        const c = await cut(page, OUT, `num/${on ? 'on' : 'off'}-${L}`, { q: `.sq-ln[data-l="${L}"]`, hide: ['.st'], css: bare(L) });
        c.button = await boxOf(page, `.sq-ln[data-l="${L}"]`);
        P.nums.push({ L, on, ...c });
      }
    }
    await page.evaluate(() => { document.querySelectorAll('.sq-ln').forEach(b => { b.className = b.dataset.was; }); document.querySelector('.sq-lvtrack').scrollLeft = 0; });
    await uncut(page);
    // the panel: its box (cut wide), the column's parts, the buttons
    P.panel = await cut(page, OUT, 'panel', { q: '.sq-lvpan', hide: ['*'] });
    P.lvCol = await boxOf(page, '.sq-lvpan .lv');
    // every level's title (gold once reached, else white) and the lines under it, and the buttons
    P.titles = []; P.subs = []; P.acts = [];
    const pick = L => page.evaluate(L => { const b = document.querySelector(`.sq-ln[data-l="${L}"]`); if (!b.classList.contains('sel')) b.click(); }, L);
    const seen = new Set();
    for (const [lvl, list] of [[N, Array.from({ length: N }, (_, i) => i + 1)], [1, Array.from({ length: N - 1 }, (_, i) => i + 2)]]) {
      // (the player's level for these titles: N, every one reached and gold; 1, every one from 2 on white)
      await page.evaluate(lvl => window.SquishApp.receive({ type: 'state', state: { xp: { level: lvl, into: 0, need: 100 * (lvl + 1), per: 100 } } }), lvl);
      await advance(page, 20);
      for (const L of list) {
        await pick(L); await advance(page, 20); await settle(page, 0);
        const reached = lvl >= L;
        P.titles.push({ L, reached, ...(await cut(page, OUT, `title/${reached ? 'gold' : 'white'}-${L}`, { q: '.sq-lvpan .lv svg.mm-ft' })) });
        const sub = await page.evaluate(() => document.querySelector('.sq-lvpan .lv .sub').textContent);
        if (!seen.has(sub)) { seen.add(sub); P.subs.push({ text: sub, ...(await cut(page, OUT, 'sub-' + P.subs.length, { q: '.sq-lvpan .lv .sub' })) }); }
        await uncut(page); await unfreeze(page);
      }
    }
    // the buttons: CLAIM, Claiming…, CLAIMED, the empty box of "n XP to go" and its lock
    await page.evaluate(st => window.SquishApp.receive({ type: 'state', state: st }), { xp: state.xp, road: state.road });
    await advance(page, 20);
    const act = async (id, L, before) => {
      await pick(L); await advance(page, 20);
      if (before) await page.evaluate(before);
      await advance(page, 20); await settle(page, 0);
      const c = await cut(page, OUT, 'act-' + id, { q: '.sq-lvpan .act', hide: id === 'togo' ? ['*'] : [] });
      P.acts.push({ id, ...c });
      if (id === 'togo') { P.lock16 = await cut(page, OUT, 'lock16', { q: '.sq-lvpan .act svg' }); P.togoText = await boxOf(page, '.sq-lvpan .act span'); }
      await uncut(page); await unfreeze(page);
    };
    await act('claim', 5); await act('claimed', 2); await act('togo', 9);
    await act('claiming', 7, () => document.querySelector('.sq-lvpan [data-claim]').click());
    // the reward cards: each level's (the row's rewards), then every group's chest of every size
    P.cards = [];
    const have = new Set();
    const cutCards = async (L, keyOf) => {
      await pick(L); await advance(page, 20); await settle(page, 0);
      const n = await page.evaluate(() => document.querySelectorAll('.sq-it').length);
      for (let i = 0; i < n; i++) {
        const key = keyOf(i, n);
        if (!key || have.has(key)) continue;
        have.add(key);
        P.cards.push({ key, count: n, ...(await cut(page, OUT, 'card/' + key, { q: '.sq-it', i })) });
      }
      await uncut(page); await unfreeze(page);
    };
    const rows = await page.evaluate(() => { const Sc = window.MainMenuScene, out = []; for (let L = 1; L <= 50; L++) { const un = []; Object.keys(Sc.ROOMS).forEach(k => { if (Sc.ROOMS[k].lv === L && L > 1) un.push('room-' + k); }); if (L === Sc.ROOMS.backyard.lv) un.push('yard'); const TI = { 5: 1, 15: 2, 25: 3 }; if (TI[L]) un.push('tier-' + TI[L]); out.push({ L, unlocks: un }); } return out; });
    const prizeKey = r => r.k === 'chest' ? `chest-${r.g}-${r.t}` : `${r.k}-${r.n}`;
    for (const row of rows) {
      const r = state.road[row.L - 1];
      const keys = (r ? [prizeKey(r)] : []).concat(row.unlocks);
      await cutCards(row.L, (i, n) => keys[i] + (n >= 3 ? '-w' + n : ''));
    }
    // every group's chest (the road's chests are of the day's first HOT group, functions/squad.js prizeGroup)
    const groups = squad.GROUPS.filter(g => g.key !== squad.SEASON.key);
    const sizeLv = {}; state.road.forEach(r => { if (r.k === 'chest' && !sizeLv[r.t]) { const un = rows[r.lv - 1].unlocks.length; if (un + 1 < 3) sizeLv[r.t] = r.lv; } });
    for (const g of groups) {
      const road = state.road.map(r => r.k === 'chest' ? { ...r, g: g.key, gn: g.name, cn: CHEST_NAMES[g.key][squad.SIZE_I[r.t]] } : r);
      await page.evaluate(road => window.SquishApp.receive({ type: 'state', state: { road } }), road);
      await advance(page, 20);
      for (const t of Object.keys(sizeLv)) await cutCards(sizeLv[t], i => i === 0 ? `chest-${g.key}-${t}` : null);
    }
    P.rows = rows;
    P.groups = groups.map(g => ({ key: g.key, name: g.name, out: squad.ROSTER.some(c => c.set === g.key && !c.reward && !c.pass) }));
    P.allGroupKeys = squad.GROUPS.map(g => g.key);
    P.chestNames = Object.keys(CHEST_NAMES).map(g => ({ g, names: CHEST_NAMES[g] }));
    P.road = squad.DEFAULT_LEVELS.road.map(r => ({ k: r.k, n: r.n || 0, t: r.t || '' }));
    // the flying coin / gem of a claim (.sq-fly: 26 x 26)
    await page.evaluate(() => { const pg = document.querySelector('.mm-page2 .mm-pg'); for (const [k, src] of [['coin', document.querySelector('.sq-coins img').src], ['gem', window.SquishCoin.gem(0)]]) { const im = document.createElement('img'); im.className = 'sq-fly'; im.id = '__fly-' + k; im.src = src; im.style.left = '400px'; im.style.top = '200px'; pg.appendChild(im); } });
    await page.waitForTimeout(200);
    P.flyCoin = await cut(page, OUT, 'fly-coin', { q: '#__fly-coin' });
    P.flyGem = await cut(page, OUT, 'fly-gem', { q: '#__fly-gem' });
    await uncut(page);
    // the page's toast box (.sq-toast: an error) cut wide and empty
    await page.evaluate(() => { const pg = document.querySelector('.mm-page2 .mm-pg'); const d = document.createElement('div'); d.className = 'sq-toast mm-p tip v-gold'; d.id = '__toast'; d.textContent = 'Something went wrong. Try again!'; d.style.animation = 'none'; d.style.opacity = '1'; pg.appendChild(d); });
    P.toastText = await boxOf(page, '#__toast');
    P.toast = await cut(page, OUT, 'toast', { q: '#__toast', css: '#__toast{color:transparent!important;width:500px!important;max-width:none!important;}' });
    await uncut(page);
    await unfreeze(page);
  }
  // the "you" marker's creature: every creature's still in it (written by the Characters part, which opens its roster)
  const layout = {
    note: 'Written by tools/unity/export-pages.mjs from webgame/app/menu.js M.levels. Units: "pu" = the page\'s CSS px (the page is scale(k), k = H / 393 dp); "px" = device px on the reference screen. A picture\'s `at` is its top-left minus its element\'s box\'s top-left (px), `box` the element\'s box at the cut (pu).',
    reference: { px: [PX.w, PX.h], dp: [REF.w, REF.h], dpr: REF.dpr, k: r4(K), u: r4(U), pgW: r4(PX.w / U) },
    ...P,
    measured,
    track,
    player: { ...PLAYER, levelGot: Object.keys(PLAYER.levelGot).map(Number), day: DAY },
    shots: { plate, list: shots, sentClaim: sent },
  };
  write(OUT, 'levelpass.json', layout);
  if (!SHOTS_ONLY) {
    const files = fs.readdirSync(OUT, { recursive: true }).filter(f => /\.bytes$/.test(f));
    console.log(`level pass: ${files.length} pictures, ${(files.reduce((n, f) => n + fs.statSync(path.join(OUT, f)).size, 0) / 1048576).toFixed(1)} MB`);
  }
  for (const e of [...new Set(errs)].slice(0, 6)) console.log('  page error:', e.slice(0, 200));
  await page.context().close();
  return shots;
}

// =====================================================================================================================
// Characters
// =====================================================================================================================
async function characters() {
  const OUT = path.join(RES, 'Characters'), LP = path.join(RES, 'LevelPass');
  if (!SHOTS_ONLY) { fs.rmSync(OUT, { recursive: true, force: true }); fs.mkdirSync(OUT, { recursive: true }); }
  const { page, errs } = await openApp(browser, { coins: PLAYER.coins, gems: PLAYER.gems });
  const plate = await shot(page, 'menu-ch');
  // (the pictures load once, so the loading screen's wait for them is the same every time it opens)
  await page.evaluate(() => window.SquishMenu.characters(window.SquishMenu._x));
  await advance(page, 4000, 50); await page.waitForTimeout(1500);
  await page.evaluate(() => document.querySelector('.mm-page2 [data-x]').click());
  const open = async () => {
    // (the page refuses to open while the last one is still closing, x.busy: wait for that, off the virtual time base)
    for (let i = 0; i < 100; i++) {
      if (await page.evaluate(() => { window.__born = new Map(); window.__now = 0; window.__awayAt = null; return !!window.SquishMenu.characters(window.SquishMenu._x); })) break;
      if (i === 99) throw new Error('the Characters page would not open');
      await page.clock.runFor(50); await page.waitForTimeout(20);
    }
    await note(page);
  };
  const close = () => page.evaluate(() => { const b = document.querySelector('.mm-page2 [data-x]'); if (b) b.click(); });
  // the creature on the platform: its still picture (the app's live rig isn't in Unity yet), as Unity shows it
  const still = () => page.evaluate(() => {
    const host = document.querySelector('.sq-c2 .rig'), pv = document.querySelector('.sq-c2 .row .sq-cc.pv img.art');
    if (!host || !pv) return; host.innerHTML = '<img alt="" style="position:absolute;inset:0;width:100%;height:100%;object-fit:contain" src="' + pv.getAttribute('src') + '">';
  });
  const timeline = async ms => {   // to `ms` after opening, noting when the loading screen's cards go
    const step = 4;
    for (let t = 0; t < ms; t += step) {
      await advance(page, Math.min(step, ms - t), step);
      await page.evaluate(() => { const g = document.querySelector('.sq-gs'); if (g && (g.classList.contains('away') || g.classList.contains('sq-leaving')) && window.__awayAt == null) window.__awayAt = window.__now; });
    }
    return page.evaluate(() => window.__awayAt);
  };

  // ---- the app's screenshots ----
  const shots = [];
  let awayAt = null;
  for (const ms of [60, 140, 240, 360, 900, 1500, 2150, 2500]) {
    await open();
    const tip = await page.evaluate(() => { const t = document.querySelector('.sq-gs .tip span'); return t ? t.textContent : null; });
    const a = await timeline(ms); if (a != null) awayAt = a; await still();
    await freeze(page, {});
    shots.push({ name: 'ch-open-' + ms, file: await shot(page, 'ch-open-' + ms), plate: await plateShot(page, 'ch-open-' + ms), ms, awayAt: a, tip, pick: 'mittens', scroll: null, endless: ms });
    await unfreeze(page); await close();
  }
  await open(); awayAt = (await timeline(3200)) ?? awayAt; await still();
  await settle(page, 0);
  const rowAt = await page.evaluate(() => document.querySelector('.sq-c2 .row').scrollLeft);
  shots.push({ name: 'ch-top', file: await shot(page, 'ch-top'), pick: 'mittens', scroll: rowAt, endless: 0 });
  await unfreeze(page);
  const clickCard = key => page.evaluate(key => { const Q = window.SquishMenu._x.Q, c = Q.ROSTER.find(c => c.key === key); document.querySelector(`.sq-c2 .row [data-id="${c.id}"]`).click(); }, key);
  await clickCard('biscuit'); await advance(page, 400); await still(); await settle(page, 0);
  const rowPick = await page.evaluate(() => document.querySelector('.sq-c2 .row').scrollLeft);
  shots.push({ name: 'ch-pick', file: await shot(page, 'ch-pick'), pick: 'biscuit', scroll: rowPick, endless: 0 });
  await unfreeze(page);
  await page.evaluate(() => document.querySelector('.sq-c2 .act-at [data-sel]').click());
  await advance(page, 300); await still(); await settle(page, 0);
  shots.push({ name: 'ch-chosen', file: await shot(page, 'ch-chosen'), pick: 'biscuit', inUse: 'biscuit', toast: 'Biscuit is in front of your house!', scroll: rowPick, endless: 0 });
  const sentSel = await page.evaluate(() => (window.__sent || []).filter(m => m.type === 'select'));
  await unfreeze(page);
  await advance(page, 2500);
  await clickCard('octo'); await advance(page, 400); await still(); await settle(page, 0);
  shots.push({ name: 'ch-locked', file: await shot(page, 'ch-locked'), pick: 'octo', inUse: 'biscuit', scroll: rowPick, endless: 0 });
  await unfreeze(page);
  await page.evaluate(() => { document.querySelector('.sq-c2 .row').scrollLeft = 1500; });
  await advance(page, 50); await settle(page, 0);
  shots.push({ name: 'ch-scrolled', file: await shot(page, 'ch-scrolled'), pick: 'octo', inUse: 'biscuit', scroll: 1500, endless: 0 });
  await unfreeze(page);
  // CHOOSE Mittens again (the start of every shot), then close
  await clickCard('mittens'); await advance(page, 400);
  await page.evaluate(() => { const b = document.querySelector('.sq-c2 .act-at [data-sel]'); if (b) b.click(); });
  await advance(page, 2600);
  await close();

  // ---- the roster, the row's layout ----
  await open(); await timeline(3200); await still(); await settle(page, 0);
  const R = await page.evaluate(() => {
    const x = window.SquishMenu._x, Q = x.Q, row = document.querySelector('.sq-c2 .row');
    row.scrollLeft = 0;
    const k = x.k, rb = row.getBoundingClientRect();
    const box = e => { const b = e.getBoundingClientRect(); return [(b.left - rb.left) / k + row.scrollLeft, (b.top - rb.top) / k, b.width / k, b.height / k].map(v => Math.round(v * 1e4) / 1e4); };
    const groups = [...row.querySelectorAll('.grp')].map(g => ({ name: g.querySelector('.gl').textContent, box: box(g), label: box(g.querySelector('.gl')), ids: [...g.querySelectorAll('[data-id]')].map(b => +b.dataset.id), cards: [...g.querySelectorAll('[data-id]')].map(box) }));
    const sets = [].concat(Q.SETS, [Q.HEROES, Q.ELEMENTAL, Q.SEASON]).filter(Boolean).map(s => ({ key: s.key, name: s.name }));
    const roster = groups.flatMap(g => g.ids).map(id => { const c = Q.ROSTER[id]; return { id, key: c.key, name: c.name, rar: c.rar | 0, set: c.set, owned: Q.owns(id) }; });
    const rar = (Q.RAR || []).map(r => ({ label: r.label, dot: r.dot }));
    return { groups, sets, roster, rar, sel: x.selId(), scrollWidth: row.scrollWidth, clientWidth: row.clientWidth, rowBox: [rb.left / k, rb.top / k, rb.width / k, rb.height / k] };
  });
  // where the sticky group labels sit as the row scrolls
  R.sticky = [];
  for (const s of [0, 300, 700, 1500, 3000]) {
    R.sticky.push({ scroll: s, labels: await page.evaluate(s => { const row = document.querySelector('.sq-c2 .row'), k = window.SquishMenu._x.k; row.scrollLeft = s; const rb = row.getBoundingClientRect(); return { at: row.scrollLeft, x: [...row.querySelectorAll('.gl')].map(e => Math.round(((e.getBoundingClientRect().left - rb.left) / k + row.scrollLeft) * 1e4) / 1e4) }; }, s) });
  }
  await page.evaluate(() => { document.querySelector('.sq-c2 .row').scrollLeft = 0; });
  const appIds = Object.fromEntries(squad.ROSTER.map(c => [c.key, c.id]));
  R.roster.forEach(c => { c.appId = appIds[c.key] ?? null; });
  const list = FEW ? R.roster.filter((c, i) => i < 6 || ['mittens', 'biscuit', 'octo'].includes(c.key)) : R.roster;

  let P = {};
  if (!SHOTS_ONLY) {
    P.bg = await cutJpeg(page, OUT, 'bg', '.mm-page2 .mm-pg{visibility:hidden!important;}');
    P.head = await cut(page, OUT, 'head', { q: '.sq-chars .mm-pgh' });
    P.back = await boxOf(page, '.sq-chars .mm-pgh [data-x]');
    P.rays = await cutWhole(page, OUT, 'rays', '.sq-c2 > .rays', '');
    P.side = await cut(page, OUT, 'side', { q: '.sq-c2 .ring .side' });
    P.ring = await boxOf(page, '.sq-c2 .ring');
    P.glow = await cut(page, OUT, 'plate-glow', { q: '.sq-c2 .ring .plate', css: '.sq-c2 .ring .plate{background:none!important;}' });
    P.centre = await cut(page, OUT, 'plate-centre', { q: '.sq-c2 .ring .plate', css: '.sq-c2 .ring .plate{box-shadow:none!important;background:radial-gradient(circle,rgba(255,255,255,.95) 0 18%,rgba(255,255,255,0) 46%)!important;}' });
    Object.assign(P, await platformPieces(page, OUT));
    P.rig = await boxOf(page, '.sq-c2 .rig');
    P.prev = await cut(page, OUT, 'nav-prev', { q: '.sq-c2 .gnav.prev', css: '.sq-c2 .gnav{opacity:1!important;}' });
    P.next = await cut(page, OUT, 'nav-next', { q: '.sq-c2 .gnav.next', css: '.sq-c2 .gnav{opacity:1!important;}' });
    await page.evaluate(() => { const row = document.querySelector('.sq-c2 .row'), g = row.querySelector('.grp + .grp'); row.scrollLeft = Math.max(0, g.offsetLeft - 100); });
    P.sep = await cut(page, OUT, 'sep', { q: '.sq-c2 .row .grp + .grp', hide: ['*'] });
    P.sep.grp = await boxOf(page, '.sq-c2 .row .grp + .grp');
    P.labels = [];
    for (let i = 0; i < R.groups.length; i++) {
      await page.evaluate(i => { const row = document.querySelector('.sq-c2 .row'); const g = row.querySelectorAll('.grp')[i]; row.scrollLeft = Math.max(0, g.offsetLeft - 100); }, i);
      P.labels.push({ name: R.groups[i].name, ...(await cut(page, OUT, `label/${i}`, { q: '.sq-c2 .row .gl', i })) });
    }
    // the selected card's ring (::before) and the one in use's tag (::after), on Mittens' card (both)
    const mid = R.roster.find(c => c.key === 'mittens').id;
    await page.evaluate(id => { const row = document.querySelector('.sq-c2 .row'), b = row.querySelector(`[data-id="${id}"]`); row.scrollLeft = Math.max(0, b.parentNode.parentNode.offsetLeft + b.offsetLeft - 300); }, mid);
    P.pv = await cut(page, OUT, 'card-pv', { q: `.sq-c2 .row [data-id="${mid}"]`, hide: ['*'], css: `.sq-c2 .row [data-id="${mid}"]::after{display:none!important;}` });
    P.me = await cut(page, OUT, 'card-me', { q: `.sq-c2 .row [data-id="${mid}"]`, hide: ['*'], css: `.sq-c2 .row [data-id="${mid}"]::before{display:none!important;}` });
    P.lockHtml = await page.evaluate(() => document.querySelector('.sq-c2 .row .sq-cc .lk').outerHTML);
    // every creature: its card in the row (owned look and locked look), its still, its name plate
    P.cards = [];
    for (const c of list) {
      const one = {};
      await page.evaluate(({ id, lock }) => {
        const row = document.querySelector('.sq-c2 .row'), b = row.querySelector(`[data-id="${id}"]`);
        row.scrollLeft = Math.max(0, b.parentNode.parentNode.offsetLeft + b.offsetLeft - 300);
        b.dataset.was = b.className; b.dataset.html = b.innerHTML;
      }, { id: c.id });
      for (const locked of [false, true]) {
        await page.evaluate(({ id, locked, lockHtml }) => {
          const b = document.querySelector(`.sq-c2 .row [data-id="${id}"]`);
          b.className = 'sq-cc' + (locked ? ' no' : '');
          b.querySelectorAll('.lk').forEach(e => e.remove());
          if (locked) b.insertAdjacentHTML('beforeend', lockHtml);
        }, { id: c.id, locked, lockHtml: P.lockHtml });
        await page.waitForTimeout(30);
        one[locked ? 'locked' : 'card'] = await cut(page, OUT, `card/${c.key}${locked ? '-locked' : ''}`, { q: `.sq-c2 .row [data-id="${c.id}"]` });
      }
      await page.evaluate(id => { const b = document.querySelector(`.sq-c2 .row [data-id="${id}"]`); b.className = b.dataset.was; b.innerHTML = b.dataset.html; }, c.id);
      P.cards.push({ key: c.key, ...one });
    }
    await uncut(page);
    P.stills = await stillPieces(page, OUT, LP, list);
    await uncut(page);
    await page.evaluate(() => { const y = document.getElementById('__you'); if (y) y.remove(); });
    // the tags and the name plates (.who, as info() fills it: the rarity, the plate with its stars, the group)
    P.plates = []; P.rarTags = []; P.setTags = [];
    const whoOf = (c, part) => page.evaluate(({ c, PLQ, NFT, part }) => {
      const x = window.SquishMenu._x, Q = x.Q, who = document.querySelector('.sq-c2 .who'), kit = window.SquishMenu.kit;
      const r = Math.max(0, Math.min(4, c.rar | 0)), RA = Q.RAR && Q.RAR[r], set = [].concat(Q.SETS, [Q.HEROES, Q.ELEMENTAL, Q.SEASON]).find(s => s && s.key === c.set);
      who.innerHTML = (RA ? '<span class="sq-chip tag" style="background:' + RA.dot + '">' + RA.label + '</span>' : '<span></span>')
        + '<div class="np mm-p ' + PLQ[r] + '"><div class="pips">' + kit.STAR.repeat(r + 1) + '</div>' + kit.ft(c.name, NFT[r], 19) + '</div>'
        + (set ? '<span class="sq-chip tag">' + kit.esc(set.name) + '</span>' : '<span></span>');
      x.fitFT(who);
    }, { c, PLQ, NFT, part });
    for (const c of list) {
      await whoOf(c);
      P.plates.push({ key: c.key, ...(await cut(page, OUT, `plate/${c.key}`, { q: '.sq-c2 .who .np' })) });
      if (!P.rarTags.some(t => t.rar === c.rar)) P.rarTags.push({ rar: c.rar, ...(await cut(page, OUT, `tag/rar-${c.rar}`, { q: '.sq-c2 .who > span', i: 0 })) });
      if (!P.setTags.some(t => t.set === c.set)) P.setTags.push({ set: c.set, ...(await cut(page, OUT, `tag/set-${c.set}`, { q: '.sq-c2 .who > span', i: 1 })) });
    }
    // every rarity and group (the few creatures of --few may not have them all)
    for (let r = 0; r < 5; r++) if (!P.rarTags.some(t => t.rar === r)) { const c = R.roster.find(c => c.rar === r); if (c) { await whoOf(c); P.rarTags.push({ rar: r, ...(await cut(page, OUT, `tag/rar-${r}`, { q: '.sq-c2 .who > span', i: 0 })) }); } }
    for (const s of R.sets) if (!P.setTags.some(t => t.set === s.key)) { const c = R.roster.find(c => c.set === s.key); if (c) { await whoOf(c); P.setTags.push({ set: s.key, ...(await cut(page, OUT, `tag/set-${s.key}`, { q: '.sq-c2 .who > span', i: 1 })) }); } }
    P.who = await boxOf(page, '.sq-c2 .who');
    await uncut(page);
    // CHOOSE and "Find it in chests"
    await clickCard('biscuit'); await advance(page, 600); await settle(page, 0);
    P.choose = await cut(page, OUT, 'act-choose', { q: '.sq-c2 .act-at .act' });
    await uncut(page); await unfreeze(page);
    await clickCard('octo'); await advance(page, 600); await settle(page, 0);
    P.shop = await cut(page, OUT, 'act-shop', { q: '.sq-c2 .act-at .act' });
    P.actAt = await boxOf(page, '.sq-c2 .act-at');
    // the toast box (.sq-toast.r: CHOOSE's), cut wide and empty; its text is drawn
    await page.evaluate(() => { const pg = document.querySelector('.mm-page2 .mm-pg'); const d = document.createElement('div'); d.className = 'sq-toast mm-p tip v-gold r'; d.id = '__toast'; d.textContent = 'Mittens is in front of your house!'; pg.appendChild(d); });
    P.toastText = await boxOf(page, '#__toast');
    P.toast = await cut(page, OUT, 'toast', { q: '#__toast', css: '#__toast{color:transparent!important;width:500px!important;max-width:none!important;}' });
    await uncut(page); await unfreeze(page);
    await close();

    // ---- the loading screen ("Gathering your squad"), held at 1.2 s (every card dealt) ----
    await open(); await timeline(1200);
    await freeze(page, {});
    P.gs = {};
    P.gs.bg = await cutJpeg(page, OUT, 'gs/bg', '.sq-gs > *{visibility:hidden!important;}');
    P.gs.rays = await cutWhole(page, OUT, 'gs/rays', '.sq-gs .rays', '.sq-gs .rays{transform:none!important;}');
    P.gs.title = await cut(page, OUT, 'gs/title', { q: '.sq-gs .ttl svg' });
    P.gs.table = await boxOf(page, '.sq-gs .table');
    // (develop: the deal is Web Animations, so the frozen values sit on the deck, its backs and the cards themselves,
    // inline and !important: they come off first, or they'd win over the cuts' own)
    await page.evaluate(() => document.querySelectorAll('.sq-gs .deck, .sq-gs .deck .back, .sq-gs .cw, .sq-gs .fl').forEach(e => { e.style.removeProperty('opacity'); e.style.removeProperty('transform'); }));
    P.gs.backs = [];
    for (let i = 0; i < 3; i++) P.gs.backs.push(await cut(page, OUT, `gs/deck-${i}`, { q: '.sq-gs .deck .back', i, css: '.sq-gs .deck{opacity:1!important;transform:none!important;}.sq-gs .deck .back{visibility:visible!important;opacity:1!important;}' }));
    P.gs.deck = await boxOf(page, '.sq-gs .deck');
    P.gs.bk = await cut(page, OUT, 'gs/back', { q: '.sq-gs .cw .bk', css: '.sq-gs .cw{transform:none!important;opacity:1!important;}.sq-gs .fl{transform:none!important;}.sq-gs .bk{transform:none!important;}' });
    P.gs.band = await cut(page, OUT, 'gs/band', { q: '.sq-gs .band', hide: ['*'] });
    // (no progress bar since 2026-11-16, the user: "remove the progress bars": the band holds only the tip)
    P.gs.tips = [];
    const tips = await page.evaluate(() => ['Rarities: Common, Rare, Epic, Legendary, Rainbow', 'Hold your creature to squeeze it, drag to spin it', 'Tap a card to see a creature, tap USE to put it in front of your house', 'Collect a whole group to earn its Rainbow chest']);
    for (let i = 0; i < tips.length; i++) {
      await page.evaluate(t => { document.querySelector('.sq-gs .tip span').textContent = t; }, tips[i]);
      P.gs.tips.push({ text: tips[i], ...(await cut(page, OUT, `gs/tip-${i}`, { q: '.sq-gs .tip', css: '.sq-gs .tip{opacity:1!important;}' })) });
    }
    P.gs.counts = [];
    for (let n = 1; n <= R.roster.length; n++) {
      await page.evaluate(n => { document.querySelector('.sq-gs .cnt').textContent = n + (n === 1 ? ' creature' : ' creatures'); }, n);
      P.gs.counts.push(await cut(page, OUT, `gs/count/${n}`, { q: '.sq-gs .cnt' }));
    }
    // each creature's card as the loading screen deals it (92 wide, its drop shadow), upright and face up
    P.gs.cw = await boxOf(page, '.sq-gs .cw');
    // (develop, PERF 2026-11-20: the page's row, where each card is copied from, is built under the loader once its first
    // deal has played, ~1.7 s in: on to then, before the loader leaves, ~1.95 s)
    await uncut(page); await unfreeze(page);
    for (let i = 0; i < 200 && !(await page.evaluate(() => !!document.querySelector('.sq-c2 .row [data-id]') && !!document.querySelector('.sq-gs .cw .fc'))); i++) {
      await advance(page, 16); await page.waitForTimeout(20);
    }
    await freeze(page, {});
    // (the frozen deal's values off the cards again: each card is cut upright at its own box, not where it was dealt)
    await page.evaluate(() => document.querySelectorAll('.sq-gs .cw, .sq-gs .fl').forEach(e => { e.style.removeProperty('opacity'); e.style.removeProperty('transform'); }));
    P.gs.cards = [];
    const deal = '.sq-gs .cw{transform:none!important;opacity:1!important;}.sq-gs .fl{transform:none!important;}';
    for (const c of list) {
      await page.evaluate(({ id }) => {
        const src = document.querySelector(`.sq-c2 .row [data-id="${id}"]`), fc = document.querySelector('.sq-gs .cw .fc');
        fc.innerHTML = src.outerHTML.replace(/ pv| me| no/g, '').replace(/loading="lazy"/g, '').replace(/ data-id="\d+"/, '');
        fc.querySelectorAll('.lk').forEach(e => e.remove());
      }, { id: c.id });
      await page.waitForFunction(() => [...document.querySelectorAll('.sq-gs .cw .fc img')].every(i => i.complete));
      P.gs.cards.push({ key: c.key, ...(await cut(page, OUT, `gs/card/${c.key}`, { q: '.sq-gs .cw .fc .sq-cc', css: deal })) });
    }
    await uncut(page); await unfreeze(page);
    P.gs.tipsText = tips;
  }
  const layout = {
    note: 'Written by tools/unity/export-pages.mjs from webgame/app/menu.js M.characters (and gatherSquad). Units: "pu" = the page\'s CSS px; "px" = device px on the reference screen. A picture\'s `at` is its top-left minus its element\'s box\'s top-left (px), `box` the element\'s box at the cut (pu).',
    reference: { px: [PX.w, PX.h], dp: [REF.w, REF.h], dpr: REF.dpr, k: r4(K), u: r4(U), pgW: r4(PX.w / U) },
    ...P,
    roster: R.roster, groups: R.groups.map(g => ({ name: g.name, box: g.box, label: g.label, ids: g.ids, cards: g.cards.flat() })), sets: R.sets, rar: R.rar,
    row: { scrollWidth: R.scrollWidth, clientWidth: R.clientWidth, box: R.rowBox, sticky: R.sticky.map(s => ({ scroll: s.labels.at, x: s.labels.x })) },
    demo: { sel: R.roster.find(c => c.id === R.sel)?.key, owned: R.roster.filter(c => c.owned).map(c => c.key) },
    awayAt,
    shots: { plate, list: shots, sentSelect: sentSel },
  };
  write(OUT, 'characters.json', layout);
  if (!SHOTS_ONLY) {
    const files = fs.readdirSync(OUT, { recursive: true }).filter(f => /\.bytes$/.test(f));
    console.log(`characters: ${files.length} pictures, ${(files.reduce((n, f) => n + fs.statSync(path.join(OUT, f)).size, 0) / 1048576).toFixed(1)} MB`);
  }
  for (const e of [...new Set(errs)].slice(0, 6)) console.log('  page error:', e.slice(0, 200));
  await page.context().close();
  return shots;
}
