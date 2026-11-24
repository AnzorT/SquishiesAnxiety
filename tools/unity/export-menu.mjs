// Exports the Main Menu, exactly as the app draws it today, as art the Unity app loads (unity/Assets/Resources/Menu).
//
//   node tools/unity/export-menu.mjs                       all 30 levels x 3 seasons
//   node tools/unity/export-menu.mjs --levels 1,5 --seasons rainy
//   node tools/unity/export-menu.mjs --hud-only            only the HUD pieces (and menu.json's hud / hudText)
//   node tools/unity/export-menu.mjs --names               only every roster creature's name plate (menu.json's names)
//
// Nothing is redrawn by hand: the in-app web game is built (webgame/build.mjs), opened in Chromium at the Galaxy
// A15's size (832 x 384 dp, 2.8125 px per dp = 2340 x 1080 px), frozen like webgame/test/pixel-diff.mjs, and each
// piece is cut out of the page it draws:
//   - scene/<season>-<level>.jpg.bytes  the house picture (main-menu-scene.js, minus its animations, as the app shows it)
//   - weather/<season>.png         one band of rain / snow and the birds (app/menu.js weather()), animated in Unity
//   - hud/<id>.png                 each button, badge, the crest, the name plate and the creature's still. The numbers
//                                  the player's profile changes are left out and drawn by Unity (Menu/HudArt.cs): the
//                                  coin / gem pills are only their coin / gem picture (the pill and its number are
//                                  drawn), the crest has no level number (drawn, with the XP ring)
//   - hud/<id>-f<n>.png            the crest's and PLAY's flourish, frame by frame (Web Animations seeked to each frame)
//   - hud/names/<key>.png          each roster creature's name plate (its rarity's plaque, stars and lettering), cut as
//                                  the menu draws it with that creature chosen; Unity shows the chosen creature's (Menu/MenuView.cs)
//   - menu.json                    where every piece goes, in the reference screen's device pixels, and how it moves
//   - unity/Reference/menu-a15.png the whole menu at the same frozen moment: what the Unity build is compared with
//
// Every cut is aligned to the page's own device-pixel grid, so at 2340 x 1080 Unity draws the same pixels.
import fs from 'node:fs';
import zlib from 'node:zlib';
import path from 'node:path';
import { createRequire } from 'node:module';
import { fileURLToPath, pathToFileURL } from 'node:url';
import { execFileSync } from 'node:child_process';
import { PNG } from 'pngjs';
import { build } from '../../webgame/build.mjs';

const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
const HERE = path.dirname(fileURLToPath(import.meta.url));
const REPO = path.resolve(HERE, '../..');
const OUT = path.join(REPO, 'unity/Assets/Resources/Menu');
const REF_DIR = path.join(REPO, 'unity/Reference');
const WORK = path.join(REPO, 'webgame/test/out/unity-webgame');

const arg = (k, d) => { const i = process.argv.indexOf('--' + k); return i > 0 ? process.argv[i + 1] : d; };
const LEVELS = arg('levels', Array.from({ length: 30 }, (_, i) => i + 1).join(',')).split(',').map(Number);
const SEASONS = arg('seasons', 'rainy,sunny,snowy').split(',');
const HUD_ONLY = process.argv.includes('--hud-only');
const NAMES_ONLY = process.argv.includes('--names');
const SKIP_BUILD = process.argv.includes('--no-build') || HUD_ONLY || NAMES_ONLY;

// the reference phone: Galaxy A15, landscape
const REF = { w: 832, h: 384, dpr: 2.8125 };
const PX = { w: Math.round(REF.w * REF.dpr), h: Math.round(REF.h * REF.dpr) };     // 2340 x 1080
// the scene's viewBox and how far its drawing reaches past it (main-menu-scene.js: sky and ground rects -60..1060, -20..480)
const VB = { w: 1000, h: 460 }, EXT = { x0: -60, y0: -20, x1: 1060, y1: 480 };
const FLOURISH_FPS = 30;
// the house picture: JPEG at quality 95 with full-resolution colour (4:4:4). Chromium's own JPEG halves the colour
// resolution, which blurs every coloured outline; Pillow does the encoding (python3 -m pip install pillow)
const JPEG_Q = 95;

const T0 = new Date('2026-11-13T12:00:00Z');
const SEED = `(() => { let s = 0x2f6b9a1; Math.random = () => { s ^= s << 13; s >>>= 0; s ^= s >>> 17; s ^= s << 5; s >>>= 0; return s / 4294967296; }; })();`;

// the HUD pieces, in drawing order (later = on top). 'scene' pieces stand in the world (they move with the picture on
// other screen shapes); the others hold to the screen edge they're nearest.
const PIECES = [
  { id: 'creature', q: '.mm-stage', world: true, press: { dy: 0, scale: 1, pivot: [0.5, 0.92] } },   // (pivot: its feet, for the breath)
  { id: 'name', q: '.mm-name', world: true },
  { id: 'tab-home', q: '.mm-tabs .mm-tab', i: 0, tap: 'home' },
  { id: 'tab-characters', q: '.mm-tabs .mm-tab', i: 1, tap: 'characters' },
  { id: 'tab-shop', q: '.mm-tabs .mm-tab', i: 2, tap: 'shop' },
  // the coin / gem pictures only (`icon`: the <img>; the tap box is the pill's); the pill and number are drawn by Unity
  { id: 'pill-coins', q: '.mm-top > .mm-pill', i: 0, tap: 'shop', icon: true },
  { id: 'pill-gems', q: '.mm-top > .mm-pill', i: 1, tap: 'shop', icon: true },
  { id: 'orb-trophy', q: '.mm-orb.sq-troph', tap: 'trophies' },
  { id: 'orb-settings', q: '.mm-orb:not(.sq-troph)', tap: 'settings' },
  // press: the piece's CSS :active look. PLAY: translateY(3px) (main-menu.js); the crest: .sq-cin scale(.92), origin 50% 62%
  { id: 'play', q: '.mm-card.sq-solo', tap: 'play', flourish: { delay: 1300 }, press: { dy: 3, scale: 1, pivot: [0.5, 0.5] } },
  // (without its level number: `noNumber`, Unity draws it and the XP ring, Menu/HudArt.cs)
  { id: 'crest', q: '.sq-crest', tap: 'level', flourish: { delay: 0 }, press: { dy: 0, scale: 0.92, pivot: [0.5, 0.62] }, noNumber: true },
];
const FLOURISH_EVERY = 5200;   // app/menu.js: the crest's flourish every 5.2 s, PLAY's glint 1.3 s after it

const sleep = ms => new Promise(r => setTimeout(r, ms));

function trimBox(png) {
  const { width: W, height: H, data } = png;
  let x0 = W, y0 = H, x1 = -1, y1 = -1;
  for (let y = 0; y < H; y++) for (let x = 0; x < W; x++) if (data[(y * W + x) * 4 + 3]) { if (x < x0) x0 = x; if (x > x1) x1 = x; if (y < y0) y0 = y; if (y > y1) y1 = y; }
  return x1 < 0 ? null : { x: x0, y: y0, w: x1 - x0 + 1, h: y1 - y0 + 1 };
}
function crop(png, b) {
  const o = new PNG({ width: b.w, height: b.h });
  PNG.bitblt(png, o, b.x, b.y, b.w, b.h, 0, 0);
  return o;
}
const union = (a, b) => !a ? b : !b ? a : (() => { const x = Math.min(a.x, b.x), y = Math.min(a.y, b.y); return { x, y, w: Math.max(a.x + a.w, b.x + b.w) - x, h: Math.max(a.y + a.h, b.y + b.h) - y }; })();
const write = (rel, buf) => { const f = path.join(OUT, rel); fs.mkdirSync(path.dirname(f), { recursive: true }); fs.writeFileSync(f, buf); return rel.replace(/\.(png|jpg)$/, ''); };

async function openMenu(browser) {
  const ctx = await browser.newContext({ viewport: { width: REF.w, height: REF.h }, deviceScaleFactor: REF.dpr });
  const page = await ctx.newPage();
  const errs = [];
  page.on('pageerror', e => errs.push(e.message));
  await page.route(/^https?:/, r => { errs.push('internet: ' + r.request().url()); r.abort(); });
  await page.addInitScript(SEED);
  await page.clock.install({ time: T0 });
  await page.clock.pauseAt(T0);
  const cdp = await ctx.newCDPSession(page);
  await cdp.send('Animation.enable');
  await cdp.send('Animation.setPlaybackRate', { playbackRate: 0 });
  await page.goto(pathToFileURL(path.join(WORK, 'App.dc.html')).href);
  await page.waitForTimeout(8000);                       // scripts, pages, art and fonts load (timers don't run)
  for (let t = 0; t < 9000; t += 500) { await page.clock.runFor(500); await page.waitForTimeout(150); }
  await page.evaluate(() => document.fonts.ready);
  await page.waitForTimeout(1000);
  return { ctx, page, errs };
}

// the scene picture for one state, on the page's own pixel grid: the 2340 x 1080 frame sits at (L, T) inside a canvas
// big enough for the whole drawing (EXT), so the frame's pixels are the app's pixels
async function sceneShots(browser, page) {
  const s = Math.max(REF.w / VB.w, REF.h / VB.h), k = s * REF.dpr;          // device px per viewBox unit
  const ox = (REF.w - VB.w * s) / 2 * REF.dpr, oy = (REF.h - VB.h * s) * REF.dpr; // where viewBox (0,0) lands in the frame, px
  const L = Math.ceil(-(ox + EXT.x0 * k)), T = Math.ceil(-(oy + EXT.y0 * k));
  const R = Math.ceil(ox + EXT.x1 * k - PX.w), B = Math.ceil(oy + EXT.y1 * k - PX.h);
  const W = L + PX.w + R, H = T + PX.h + B;
  const ctx = await browser.newContext({ viewport: { width: W, height: H }, deviceScaleFactor: 1 });
  const cp = await ctx.newPage();
  await cp.route(/^https?:/, r => r.abort());
  await cp.goto(pathToFileURL(path.join(WORK, '__unity_canvas.html')).href);
  const out = [], pending = [];
  for (const season of SEASONS) for (const level of LEVELS) {
    const svg = await page.evaluate(({ level, season }) => {
      const st = window.MainMenuScene.state({ level, season });
      // (without its vignette: the app fades the vignette out while the Game Park is beside the house, menu.js
      // vignette(); Unity draws it as its own picture, scene/vignette)
      // (develop's still() wraps the SVG in <div class="sq-live">: unwrapped, or the picture lands 2 px off on the canvas)
      return window.SquishMenu.still(window.MainMenuScene.svg(st), st, null).replace(/^<div class="sq-live">([\s\S]*)<\/div>$/, '$1').replace(/<rect x="-60" y="-20" width="1120" height="500" fill="url\(#[^)]*Vig\)" pointer-events="none"\/>/, '');
    }, { level, season });
    await cp.evaluate(({ svg, L, T, PX }) => {
      document.body.innerHTML = '<div id="f" style="position:absolute;left:' + L + 'px;top:' + T + 'px;width:' + PX.w + 'px;height:' + PX.h + 'px">' + svg + '</div>';
      const sv = document.querySelector('#f svg'); sv.style.overflow = 'visible';
    }, { svg, L, T, PX });
    await cp.waitForTimeout(60);
    const tmp = path.join(WORK, `__scene-${season}-${level}.png`);
    fs.writeFileSync(tmp, await cp.screenshot());
    // Unity loads it as bytes (Resources name scene/<season>-<level>.jpg) and decodes it itself, see MenuView.LoadJpeg
    out.push({ season, level, res: `scene/${season}-${level}.jpg` });
    pending.push([tmp, path.join(OUT, `scene/${season}-${level}.jpg.bytes`)]);
    fs.mkdirSync(path.join(OUT, 'scene'), { recursive: true });
  }
  // the vignette (main-menu-scene.js mmVig: the same in every state) on its own, on the same canvas, see-through
  const vig = await page.evaluate(() => {
    const st = window.MainMenuScene.state({ level: 1, season: 'sunny' });
    const doc = new DOMParser().parseFromString(window.SquishMenu.still(window.MainMenuScene.svg(st), st, null).replace(/^<div class="sq-live">([\s\S]*)<\/div>$/, '$1'), 'image/svg+xml');
    const rect = doc.querySelector('rect[fill$="Vig)"]'), grad = doc.getElementById(/url\(#([^)]*)\)/.exec(rect.getAttribute('fill'))[1]);
    const keep = new Set();
    for (const e of [rect, grad]) for (let n = e; n; n = n.parentNode) keep.add(n);
    const prune = n => [...n.children].forEach(c => { if (c === grad) return; if (!keep.has(c)) c.remove(); else prune(c); });
    prune(doc.documentElement);
    return new XMLSerializer().serializeToString(doc.documentElement);
  });
  await cp.evaluate(({ svg, L, T, PX }) => {
    document.body.innerHTML = '<div id="f" style="position:absolute;left:' + L + 'px;top:' + T + 'px;width:' + PX.w + 'px;height:' + PX.h + 'px">' + svg + '</div>';
    document.documentElement.style.background = 'transparent'; document.body.style.background = 'transparent';
    const sv = document.querySelector('#f svg'); sv.style.overflow = 'visible';
  }, { svg: vig, L, T, PX });
  await cp.waitForTimeout(60);
  fs.writeFileSync(path.join(OUT, 'scene/vignette.png'), await cp.screenshot({ omitBackground: true }));
  await ctx.close();
  execFileSync('python3', ['-c', 'import sys\nfrom PIL import Image\nq=int(sys.argv[1])\nfor a,b in zip(sys.argv[2::2],sys.argv[3::2]): Image.open(a).convert("RGB").save(b,format="JPEG",quality=q,subsampling=0,optimize=True)',
    String(JPEG_Q), ...pending.flat()], { stdio: 'inherit' });
  pending.forEach(([tmp]) => fs.rmSync(tmp));
  // texture pixel (0,0) is screen pixel (-L, -T) on the reference screen; in viewBox units:
  return { states: out, size: [W, H], originUnits: [(-L - ox) / k, (-T - oy) / k], unitsPerPx: 1 / k, vignette: 'scene/vignette' };
}

// rain / snow bands and birds, as app/menu.js weather() draws them for each season (it runs inside the real page)
async function weatherShots(browser, page) {
  const s = Math.max(REF.w / VB.w, REF.h / VB.h), k = s * REF.dpr;
  const ox = (REF.w - VB.w * s) / 2, oy = REF.h - VB.h * s;
  const ctx = await browser.newContext({ viewport: { width: 400, height: 400 }, deviceScaleFactor: 1 });
  const cp = await ctx.newPage();
  await cp.goto(pathToFileURL(path.join(WORK, '__unity_canvas.html')).href);
  const out = [];
  for (const season of SEASONS) {
    const info = await page.evaluate(async ({ season }) => {
      const scene = document.querySelector('.mm-scene');
      const st = window.MainMenuScene.state({ level: 30, season });   // birds only fly over a lively island (f > 0.3)
      window.SquishMenu.still('', st, scene);
      return true;
    }, { season });
    await page.clock.runFor(50); await page.waitForTimeout(50);
    const w = await page.evaluate(() => {
      const el = document.querySelector('.sq-wx'); if (!el) return null;
      const movers = [...el.querySelectorAll('.sq-wxm')].map(m => {
        const a = m.getAnimations()[0], kf = a.effect.getKeyframes().map(f => f.transform), d = a.effect.getTiming().duration;
        const g = m.querySelector('svg > g');   // one band (all five are the same markup, moved by 115)
        return { band: g ? g.innerHTML : '', kf, d };
      });
      const birds = [...el.querySelectorAll('.sq-bird')].map(b => {
        const a = b.getAnimations()[0];
        return { svg: b.innerHTML, w: b.querySelector('svg').getAttribute('width'), kf: a.effect.getKeyframes().map(f => f.transform), d: a.effect.getTiming().duration };
      });
      return { movers, birds };
    });
    if (!w) continue;
    const tr = t => { const m = /translate\(([-\d.e]+)px,\s*([-\d.e]+)px\)/.exec(t); return [+m[1], +m[2]]; };
    const entry = {};
    if (w.movers.length) {
      const m = w.movers[0];
      // render one band: x -60..1060, y -10..130 (streaks run 14 below their start, flakes reach 3 past the band)
      const bx0 = -60, by0 = -10, bw = 1120, bh = 140;
      await cp.setViewportSize({ width: Math.ceil(bw * k), height: Math.ceil(bh * k) });
      await cp.evaluate(({ band, bx0, by0, bw, bh }) => { document.body.innerHTML = '<svg viewBox="' + bx0 + ' ' + by0 + ' ' + bw + ' ' + bh + '" width="100%" height="100%" style="position:absolute;inset:0">' + band + '</svg>'; }, { band: m.band, bx0, by0, bw, bh });
      const png = await cp.screenshot({ omitBackground: true });
      const from = tr(m.kf[0]).map(v => v / s), to = tr(m.kf[m.kf.length - 1]).map(v => v / s);
      entry.band = { res: write(`weather/${season}.png`, png), rectUnits: [bx0, by0, bw, bh], period: 115, copies: [-1, 0, 1, 2, 3],
        from: from.map(v => Math.round(v * 1000) / 1000), to: to.map(v => Math.round(v * 1000) / 1000), ms: m.d };
    }
    if (w.birds.length) {
      const b = w.birds[0];
      const bwPx = Math.ceil(14 * k), bhPx = Math.ceil(6 * k);
      await cp.setViewportSize({ width: bwPx, height: bhPx });
      await cp.evaluate(({ svg }) => { document.body.innerHTML = svg; const e = document.querySelector('svg'); e.setAttribute('width', '100%'); e.setAttribute('height', '100%'); e.style.cssText = 'position:absolute;inset:0'; }, { svg: b.svg });
      const png = await cp.screenshot({ omitBackground: true });
      entry.birds = { res: write(`weather/bird.png`, png), sizeUnits: [14, 6], anchorUnits: [-1, -4],
        paths: w.birds.map(x => ({ ms: x.d, points: x.kf.map(t => tr(t)).flatMap(([px, py]) => [Math.round((px - ox) / s * 100) / 100, Math.round((py - oy) / s * 100) / 100]) })) };
    }
    out.push({ season, hasBand: !!entry.band, band: entry.band || null, hasBirds: !!entry.birds, birds: entry.birds || null });
  }
  await ctx.close();
  // put the live page back to its own season
  await page.evaluate(() => { const x = window.SquishMenu._x; if (x && x.st) window.SquishMenu.still('', x.st, document.querySelector('.mm-scene')); });
  await page.clock.runFor(50);
  return out;
}

// one HUD piece on its own: everything else hidden, transparent background, cut on the device-pixel grid
async function isolate(page, q, i, on, opt = {}) {
  return page.evaluate(({ q, i, on, opt }) => {
    const root = document.documentElement;
    if (!window.__iso) { window.__iso = { html: root.style.cssText, body: document.body.style.cssText }; }
    document.querySelectorAll('[data-iso]').forEach(e => { e.style.visibility = e.dataset.iso; delete e.dataset.iso; });
    document.querySelectorAll('[data-isohide]').forEach(e => { e.style.visibility = ''; delete e.dataset.isohide; });
    const box = on ? document.querySelectorAll(q)[i || 0] : null;
    const el = box && opt.icon ? box.querySelector('img') : box;
    if (!on) { root.style.cssText = window.__iso.html; document.body.style.cssText = window.__iso.body; root.style.visibility = ''; return null; }
    root.style.visibility = 'hidden'; root.style.background = 'transparent'; document.body.style.background = 'transparent';
    el.dataset.iso = el.style.visibility; el.style.visibility = 'visible';
    // the crest's level number: its two <text>s after LEVEL
    if (opt.noNumber) [...el.querySelectorAll('svg.mm-crest > text')].slice(-2).forEach(t => { t.dataset.isohide = '1'; t.style.visibility = 'hidden'; });
    const r = box.getBoundingClientRect(), p = el.getBoundingClientRect();
    return { x: r.left, y: r.top, w: r.width, h: r.height, pic: { x: p.left, y: p.top, w: p.width, h: p.height } };
  }, { q, i, on, opt });
}
async function shotPx(page, box) {   // box in device px (integers): the whole screen, then cut (a CSS clip rounds)
  const png = PNG.sync.read(await page.screenshot({ omitBackground: true }));
  if (png.width !== PX.w || png.height !== PX.h) throw new Error(`screenshot came back ${png.width}x${png.height}, expected ${PX.w}x${PX.h}`);
  return crop(png, box);
}
const pxBox = (r, m) => { const x = Math.max(0, Math.floor((r.x - m) * REF.dpr)), y = Math.max(0, Math.floor((r.y - m) * REF.dpr));
  return { x, y, w: Math.min(PX.w, Math.ceil((r.x + r.w + m) * REF.dpr)) - x, h: Math.min(PX.h, Math.ceil((r.y + r.h + m) * REF.dpr)) - y }; };

async function hudShots(page) {
  const out = [];
  for (const P of PIECES) {
    const r = await isolate(page, P.q, P.i, true, { icon: P.icon, noNumber: P.noNumber });
    if (!r) throw new Error('no element for ' + P.id + ' (' + P.q + ')');
    const box = pxBox(P.icon ? r.pic : r, 24);
    const png = await shotPx(page, box);
    const t = trimBox(png);
    if (!t) throw new Error(P.id + ' drew nothing');
    const item = { id: P.id, res: write(`hud/${P.id}.png`, PNG.sync.write(crop(png, t))), rect: [box.x + t.x, box.y + t.y, t.w, t.h],
      hit: [r.x * REF.dpr, r.y * REF.dpr, r.w * REF.dpr, r.h * REF.dpr].map(v => Math.round(v * 100) / 100) };
    item.world = !!P.world;
    item.tap = P.tap || '';
    item.press = P.press || { dy: 0, scale: 1, pivot: [0.5, 0.5] };
    item.hasFlourish = !!P.flourish;
    // the flourish: add .fl (as app/menu.js does), seek every animation it starts to each frame, cut the same box
    if (P.flourish) {
      const dur = await page.evaluate(({ q }) => {
        const el = document.querySelector(q); el.classList.remove('fl'); void el.offsetWidth; el.classList.add('fl');
        const an = document.getAnimations().filter(a => el.contains(a.effect.target));
        an.forEach(a => a.pause());
        return Math.max(...an.map(a => a.effect.getTiming().duration));
      }, { q: P.q });
      const n = Math.round(dur / 1000 * FLOURISH_FPS), frames = [];
      const fb = pxBox(r, 40);
      for (let f = 0; f <= n; f++) {
        await page.evaluate(({ q, t }) => { const el = document.querySelector(q); document.getAnimations().filter(a => el.contains(a.effect.target)).forEach(a => { a.currentTime = t; }); }, { q: P.q, t: dur * f / n });
        await page.waitForTimeout(30);
        frames.push(await shotPx(page, fb));
      }
      await page.evaluate(({ q }) => { const el = document.querySelector(q); document.getAnimations().filter(a => el.contains(a.effect.target)).forEach(a => a.cancel()); el.classList.remove('fl'); }, { q: P.q });
      const u = frames.map(trimBox).reduce(union, null);
      item.flourish = { ms: dur, every: FLOURISH_EVERY, delay: P.flourish.delay, rect: [fb.x + u.x, fb.y + u.y, u.w, u.h],
        frames: frames.map((png, f) => write(`hud/${P.id}-f${f}.png`, PNG.sync.write(crop(png, u)))) };
    }
    out.push(item);
  }
  await isolate(page, '', 0, false);
  return out;
}

// every roster creature's name plate: the menu with that creature chosen (window.SquadLobby.selected, then the
// 'squadlobby' event the menu redraws on), its .mm-name cut as the 'name' piece is
async function nameShots(page) {
  const roster = await page.evaluate(() => window.SquishSquad.ROSTER.map((c, id) => c && c.key ? { id, key: c.key, name: c.name } : null).filter(Boolean));
  const out = [];   // [{ key, res, rect }] (a list: Unity reads menu.json with JsonUtility)
  for (const c of roster) {
    await page.evaluate((id) => { window.SquadLobby.selected = () => id; window.dispatchEvent(new Event('squadlobby')); }, c.id);
    await page.waitForTimeout(60);
    const r = await isolate(page, '.mm-name', 0, true);
    const box = pxBox(r, 24);
    const png = await shotPx(page, box);
    const t = trimBox(png);
    if (!t) { console.log('  (no plate for ' + c.key + ')'); continue; }
    out.push({ key: c.key, res: write(`hud/names/${c.key}.png`, PNG.sync.write(crop(png, t))), rect: [box.x + t.x, box.y + t.y, t.w, t.h] });
  }
  await isolate(page, '', 0, false);
  return out;
}

// where Unity draws the HUD's numbers (Menu/HudArt.cs): the pills' boxes (the reference's, and where each coin / gem
// picture sits from its pill), the crest's <svg> and its .sq-cin (the flourish and press scale about its 50 % 62 %)
async function hudText(page) {
  return page.evaluate((dpr) => {
    const px = (r) => [r.left, r.top, r.width, r.height].map((v) => Math.round(v * dpr * 1000) / 1000);
    const pills = [...document.querySelectorAll('.mm-top > .mm-pill')].slice(0, 2).map((p, i) => {
      const b = p.getBoundingClientRect(), im = p.querySelector('img').getBoundingClientRect(), sp = p.querySelector('span');
      return { id: i ? 'pill-gems' : 'pill-coins', pill: px(b), text: sp.textContent, iconOffset: [(im.left - b.left) * dpr, (im.top - b.top) * dpr] };
    });
    const hud = document.querySelector('.mm-hud'), k = new DOMMatrix(getComputedStyle(hud).transform).a;
    const svg = document.querySelector('.sq-crest svg.mm-crest'), cin = document.querySelector('.sq-crest .sq-cin');
    const level = +((svg.getAttribute('aria-label') || '').replace(/\D+/g, '') || 1);
    return { k, hudWidth: parseFloat(hud.style.width), pills, crest: { svg: px(svg.getBoundingClientRect()), cin: px(cin.getBoundingClientRect()), level, ring: !!svg.querySelector('circle[r="27.2"]') } };
  }, REF.dpr);
}

// ---------------------------------------------------------------------------------------------------------------------
if (!SKIP_BUILD) await build(WORK);
fs.writeFileSync(path.join(WORK, '__unity_canvas.html'), '<!doctype html><meta charset="utf-8"><style>html,body{margin:0;background:transparent;overflow:hidden}</style><body></body>');
if (NAMES_ONLY) {
  const browser = await chromium.launch({ args: ['--allow-file-access-from-files'] });
  const { page, errs } = await openMenu(browser);
  fs.rmSync(path.join(OUT, 'hud/names'), { recursive: true, force: true });
  const names = await nameShots(page);
  await browser.close();
  const layout = JSON.parse(fs.readFileSync(path.join(OUT, 'menu.json'), 'utf8'));
  layout.names = names;
  write('menu.json', JSON.stringify(layout, null, 1));
  console.log('names: ' + names.length + ' plates');
  for (const e of [...new Set(errs)].slice(0, 8)) console.log('  page error:', e.slice(0, 200));
  process.exit(0);
}
if (HUD_ONLY) {
  // the HUD's pieces again, into the existing menu.json (the house pictures, weather and reference stay)
  const browser = await chromium.launch({ args: ['--allow-file-access-from-files'] });
  const { page, errs } = await openMenu(browser);
  const text = await hudText(page);
  const hud = await hudShots(page);
  await browser.close();
  const layout = JSON.parse(fs.readFileSync(path.join(OUT, 'menu.json'), 'utf8'));
  for (const f of fs.readdirSync(path.join(OUT, 'hud'))) if (!hud.some((h) => f.startsWith(h.id + '.') || f.startsWith(h.id + '-f'))) console.log('  (left as is: hud/' + f + ')');
  layout.hud = hud;
  layout.hudText = text;
  write('menu.json', JSON.stringify(layout, null, 1));
  console.log('hud: ' + hud.length + ' pieces; hudText ' + JSON.stringify(text));
  for (const e of [...new Set(errs)].slice(0, 8)) console.log('  page error:', e.slice(0, 200));
  process.exit(0);
}
fs.rmSync(OUT, { recursive: true, force: true });
fs.mkdirSync(OUT, { recursive: true });
fs.mkdirSync(REF_DIR, { recursive: true });

const browser = await chromium.launch({ args: ['--allow-file-access-from-files'] });
const { page, errs } = await openMenu(browser);
const live = await page.evaluate(() => { const st = window.SquishMenu._x && window.SquishMenu._x.st; return st ? { level: st.L, season: st.season } : null; });
const scene = await sceneShots(browser, page);
// the Game Park (left of the house, where PLAY walks to): not a picture but its SVG, which Unity draws once when it's
// needed (its vector renderer; see UNITY_MIGRATION_PLAN.md). Same viewBox and fit as the house, one screen to the left.
const parks = [];
for (const season of SEASONS) for (const level of LEVELS) {
  const svg = await page.evaluate(({ level, season }) => {
    const st = window.MainMenuScene.state({ level, season });
    return window.MainMenuScene.svg(Object.assign({}, st, { park: true })).replace(/<animate(?:Transform|Motion)?\b[^>]*\/>/g, '');
  }, { level, season });
  const rel = `park/${season}-${level}.svg`;
  fs.mkdirSync(path.join(OUT, 'park'), { recursive: true });
  fs.writeFileSync(path.join(OUT, rel + '.bytes'), zlib.gzipSync(svg, { level: 9 }));
  parks.push({ season, level, res: rel });
}
scene.parks = parks;
const weather = await weatherShots(browser, page);
// the reference, at the moment the pieces are cut (the creature's rig doesn't move between the two: the clock is still)
fs.writeFileSync(path.join(REF_DIR, 'menu-a15.png'), await page.screenshot());
const hudTextInfo = await hudText(page);
const hud = await hudShots(page);
const names = await nameShots(page);   // (last: it changes the chosen creature)
await browser.close();

const layout = {
  note: 'Written by tools/unity/export-menu.mjs. Pixel rects are device pixels on the reference screen (left, top, width, height; y down).',
  reference: { dp: [REF.w, REF.h], dpr: REF.dpr, px: [PX.w, PX.h], shot: 'unity/Reference/menu-a15.png', level: live.level, season: live.season },
  scene: { viewBox: [0, 0, VB.w, VB.h], fit: 'xMidYMax slice', ...scene },
  weather,
  hud,
  names,
  hudText: hudTextInfo,
};
write('menu.json', JSON.stringify(layout, null, 1));
fs.writeFileSync(path.join(REPO, 'unity/Reference/menu-a15.json'), JSON.stringify(live));
const files = fs.readdirSync(OUT, { recursive: true }).filter(f => /\.(png|jpg|bytes)$/.test(f));
console.log(`park drawings: ${parks.length}, ${(parks.reduce((n, p) => n + fs.statSync(path.join(OUT, p.res + '.bytes')).size, 0) / 1048576).toFixed(1)} MB`);
const bytes = files.reduce((n, f) => n + fs.statSync(path.join(OUT, f)).size, 0);
console.log(`menu: ${files.length} images, ${(bytes / 1048576).toFixed(1)} MB -> ${path.relative(REPO, OUT)}; live state ${JSON.stringify(live)}`);
for (const e of [...new Set(errs)].slice(0, 8)) console.log('  page error:', e.slice(0, 200));
