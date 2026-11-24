// Exports the game intro (develop's webgame/app/intro.js, "Squish wakes the house") as the pictures the Unity menu plays it
// with (unity/Assets/Resources/Intro), from the app's own page:
//
//   node tools/unity/export-intro.mjs            (--no-build reuses the last web build of export-menu.mjs)
//
// What Unity's vector renderer can't draw is drawn here by Chrome; the rest Unity draws itself (Menu/MenuIntro.cs: the
// box, the ring, the sparks, bursts and puffs, the squad peeking out, the camera, Mittens):
//   - <weather>/<state>.jpg  the house at night with its lights (the scene and the intro's back layer: the veil with its
//                            holes, the moon, the window halos in `screen`, the panes in `soft-light`, the dawn in
//                            `multiply`) on the house pictures' own canvas (export-menu.mjs: the frame at (L, T) inside a
//                            canvas big enough for the drawing, so other screen shapes work). States: night (no room lit),
//                            lit1-3 (the living room, the bedroom, the bathroom), lit6 (every room, the door light), dawn
//                            1-3 (the dawn tween at t .25 .5 .75) and morning (its end: the house by day, the windows at .3)
//   - cap/<n>.png, skip.png, tap.png   the captions (each with its dots), Skip, TAP TO START (the overlay's, 852 x 393
//                            units scaled to the screen's height)
//   - logo/<i>.png           the plush logo's letters, each where it rests
//   - peek/<key>.png         the squad's thumbnails that peek out of the windows
//   - intro.json             where it all goes
// The night pictures are re-rendered from the running intro's own markup (its back layer, with the lights set as its
// setLit sets them), so they're the page's pixels.
import fs from 'node:fs';
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
const OUT = path.join(REPO, 'unity/Assets/Resources/Intro');
const WORK = path.join(REPO, 'webgame/test/out/unity-webgame');
const SKIP_BUILD = process.argv.includes('--no-build');
const REF = { w: 832, h: 384, dpr: 2.8125 };
const PX = { w: Math.round(REF.w * REF.dpr), h: Math.round(REF.h * REF.dpr) };
const VB = { w: 1000, h: 460 }, EXT = { x0: -60, y0: -20, x1: 1060, y1: 480 };
const JPEG_Q = 90;
const T0 = new Date('2026-11-13T22:00:00Z');
const SEED = `(() => { let s = 0x2f6b9a1; Math.random = () => { s ^= s << 13; s >>>= 0; s ^= s >>> 17; s ^= s << 5; s >>>= 0; return s / 4294967296; }; })();`;
const WEATHERS = ['sunny', 'rainy', 'snowy'];
const ROOMS = ['living', 'bedroom', 'bathroom', 'kitchen', 'movie', 'dance'];
const PEEK = ['biscuit', 'berri', 'nibbles', 'appy', 'peachy', 'scoop', 'truffle', 'boba', 'bao'];

// the house pictures' canvas (export-menu.mjs): the 2340 x 1080 frame at (L, T)
const s0 = Math.max(REF.w / VB.w, REF.h / VB.h), K = s0 * REF.dpr;
const ox = (REF.w - VB.w * s0) / 2 * REF.dpr, oy = (REF.h - VB.h * s0) * REF.dpr;
const L = Math.ceil(-(ox + EXT.x0 * K)), T = Math.ceil(-(oy + EXT.y0 * K));
const CW = L + PX.w + Math.ceil(ox + EXT.x1 * K - PX.w), CH = T + PX.h + Math.ceil(oy + EXT.y1 * K - PX.h);

function trimBox(png) {
  const { width: W, height: H, data } = png;
  let x0 = W, y0 = H, x1 = -1, y1 = -1;
  for (let y = 0; y < H; y++) for (let x = 0; x < W; x++) if (data[(y * W + x) * 4 + 3]) { if (x < x0) x0 = x; if (x > x1) x1 = x; if (y < y0) y0 = y; if (y > y1) y1 = y; }
  return x1 < 0 ? null : { x: x0, y: y0, w: x1 - x0 + 1, h: y1 - y0 + 1 };
}
function crop(png, b) { const o = new PNG({ width: b.w, height: b.h }); PNG.bitblt(png, o, b.x, b.y, b.w, b.h, 0, 0); return o; }
const r4 = v => Math.round(v * 1e4) / 1e4;

async function openIntro(browser, weather) {
  const ctx = await browser.newContext({ viewport: { width: REF.w, height: REF.h }, deviceScaleFactor: REF.dpr });
  const page = await ctx.newPage();
  const errs = [];
  page.on('pageerror', e => errs.push(e.message));
  await page.route(/^https?:/, r => r.abort());
  await page.addInitScript(SEED);
  await page.addInitScript(w => { window.ReactNativeWebView = { postMessage() {} }; window.__SQUISH_INIT__ = { intro: true, state: { weather: w } }; }, weather);
  await page.clock.install({ time: T0 });
  await page.clock.pauseAt(T0);
  await page.goto(pathToFileURL(path.join(WORK, 'App.dc.html')).href);
  await page.waitForTimeout(8000);
  for (let t = 0; t < 4000; t += 100) { await page.clock.runFor(100); await page.waitForTimeout(20); if (await page.evaluate(() => !!document.querySelector('.si-back'))) break; }
  if (!(await page.evaluate(() => !!document.querySelector('.si-back')))) throw new Error('the intro did not start: ' + errs.slice(0, 3).join(' | '));
  return { ctx, page, errs };
}
const run = async (page, ms) => { for (let t = 0; t < ms; t += 32) { await page.clock.runFor(32); await page.waitForTimeout(8); } };

// one piece of the overlay on its own (everything else hidden, see-through), trimmed: its picture and its box in the
// overlay's units (852 x 393 scaled by H / 393)
async function cut(page, el, file, css) {
  const r = await page.evaluate(({ sel, css }) => {
    const e = typeof sel === 'string' ? document.querySelector(sel) : null; if (!e) return null;
    let st = document.getElementById('__cut'); if (!st) { st = document.createElement('style'); st.id = '__cut'; document.head.appendChild(st); }
    st.textContent = 'html,body{background:transparent!important;}html *{visibility:hidden!important;transition:none!important;animation:none!important;}' + sel + ',' + sel + ' *{visibility:visible!important;}' + (css || '');
    const b = e.getBoundingClientRect(), ov = document.querySelector('.si-ov').getBoundingClientRect(), k = ov.height / 393;
    return { x: (b.left - ov.left) / k, y: (b.top - ov.top) / k, w: b.width / k, h: b.height / k, k };
  }, { sel: el, css });
  if (!r) throw new Error('no ' + el);
  await page.waitForTimeout(60);
  const png = PNG.sync.read(await page.screenshot({ omitBackground: true }));
  const t = trimBox(png); if (!t) throw new Error(file + ' drew nothing');
  const f = path.join(OUT, file + '.png'); fs.mkdirSync(path.dirname(f), { recursive: true }); fs.writeFileSync(f, PNG.sync.write(crop(png, t)));
  await page.evaluate(() => { const st = document.getElementById('__cut'); if (st) st.remove(); });
  // its picture's top-left in overlay units, and its size in device px
  const ovB = await page.evaluate(() => { const b = document.querySelector('.si-ov').getBoundingClientRect(); return [b.left, b.top]; });
  return { res: 'Intro/' + file, at: [r4((t.x / REF.dpr - ovB[0]) / r.k), r4((t.y / REF.dpr - ovB[1]) / r.k)], size: [t.w, t.h], box: [r4(r.x), r4(r.y), r4(r.w), r4(r.h)] };
}

// ---------------------------------------------------------------------------------------------------------------------
if (!SKIP_BUILD) await build(WORK);
fs.rmSync(OUT, { recursive: true, force: true });
fs.mkdirSync(OUT, { recursive: true });
fs.writeFileSync(path.join(WORK, '__unity_canvas.html'), '<!doctype html><meta charset="utf-8"><style>html,body{margin:0;background:transparent;overflow:hidden}</style><body></body>');
const browser = await chromium.launch({ args: ['--allow-file-access-from-files'] });
const layout = { canvas: { size: [CW, CH], frameAt: [L, T] }, weathers: {}, overlay: {}, logo: [], peek: {} };

for (const weather of WEATHERS) {
  const { ctx, page, errs } = await openIntro(browser, weather);
  await run(page, 6200);   // the box has landed, its caption is up
  const mk = await page.evaluate(() => ({ scene: document.querySelector('.mm-world > .mm-scene:not(.si-sceneb)').innerHTML, back: document.querySelector('.si-back').outerHTML }));
  // the states, drawn on the canvas page from that markup
  const cctx = await browser.newContext({ viewport: { width: CW, height: CH }, deviceScaleFactor: 1 });
  const cp = await cctx.newPage();
  await cp.goto(pathToFileURL(path.join(WORK, '__unity_canvas.html')).href);
  await cp.evaluate(({ mk, L, T, PX, EXT }) => {
    document.body.innerHTML = '<div id="f" style="position:absolute;left:' + L + 'px;top:' + T + 'px;width:' + PX.w + 'px;height:' + PX.h + 'px">' + mk.scene + mk.back + '</div>';
    document.querySelectorAll('#f > svg').forEach(s => { s.style.cssText = 'position:absolute;left:0;top:0;width:100%;height:100%;overflow:visible;'; s.setAttribute('preserveAspectRatio', 'xMidYMax slice'); if (!s.getAttribute('viewBox')) s.setAttribute('viewBox', '0 0 1000 460'); });
    // the veil over the whole canvas (the intro fits it to the frame: veilFit)
    document.querySelectorAll('#f .si-veil').forEach(r => { r.setAttribute('x', EXT.x0 - 1); r.setAttribute('y', EXT.y0 - 1); r.setAttribute('width', EXT.x1 - EXT.x0 + 2); r.setAttribute('height', EXT.y1 - EXT.y0 + 2); });
    const clamp = (x, a, b) => Math.max(a, Math.min(b, x));
    // intro.js setLit, and the dawn tween's own values
    window.__setLit = (room, v, f, keepHoles) => { const dk = room === 'dance' ? 0.6 : 1, back = document.querySelector('#f .si-back');
      if (!keepHoles) back.querySelectorAll('.h-' + room).forEach(e => e.setAttribute('opacity', (clamp(v * 0.9 + f * 0.1, 0, 1) * dk).toFixed(3)));
      back.querySelectorAll('.g-' + room).forEach(e => e.setAttribute('opacity', clamp(v * 0.85 + f * 0.6, 0, 1.4).toFixed(3)));
      back.querySelectorAll('.p-' + room).forEach(e => e.setAttribute('opacity', (clamp(v * 0.75 + f * 0.25, 0, 1) * dk).toFixed(3))); };
    window.__dawn = t => { const back = document.querySelector('#f .si-back'), e = t;
      back.querySelector('.si-night').style.opacity = (0.8 * (1 - e)).toFixed(3);
      back.querySelector('.si-moon').style.opacity = (0.6 * (1 - Math.min(1, t * 2))).toFixed(3);
      back.querySelector('.si-dawn').style.opacity = (0.6 * Math.sin(Math.min(1, t * 1.1) * Math.PI)).toFixed(3);
      const day = clamp((t - 0.45) / 0.5, 0, 1); ['living', 'bedroom', 'bathroom', 'kitchen', 'movie', 'dance'].forEach(r => window.__setLit(r, 1 - 0.7 * day, 0, true)); };
    window.__door = v => document.querySelectorAll('#f .mm-doorlight').forEach(e => e.setAttribute('opacity', v));
  }, { mk, L, T, PX, EXT });
  const pending = [], states = [];
  const snap = async name => { await cp.waitForTimeout(80); const tmp = path.join(WORK, `__intro-${weather}-${name}.png`); fs.writeFileSync(tmp, await cp.screenshot()); const rel = `${weather}/${name}.jpg`; pending.push([tmp, path.join(OUT, rel + '.bytes')]); states.push({ name, res: 'Intro/' + rel }); };
  fs.mkdirSync(path.join(OUT, weather), { recursive: true });
  await snap('night');
  for (let i = 0; i < 3; i++) { await cp.evaluate(r => window.__setLit(r, 1, 0), ROOMS[i]); await snap('lit' + (i + 1)); }
  for (let i = 3; i < 6; i++) await cp.evaluate(r => window.__setLit(r, 1, 0), ROOMS[i]);
  await cp.evaluate(() => window.__door(0.95));
  await snap('lit6');
  for (const [i, t] of [[1, 0.25], [2, 0.5], [3, 0.75], [4, 1]]) { await cp.evaluate(t => window.__dawn(t), t); await snap(i < 4 ? 'dawn' + i : 'morning'); }
  await cctx.close();
  execFileSync('python3', ['-c', 'import sys\nfrom PIL import Image\nq=int(sys.argv[1])\nfor a,b in zip(sys.argv[2::2],sys.argv[3::2]): Image.open(a).convert("RGB").save(b,format="JPEG",quality=q,subsampling=0,optimize=True)', String(JPEG_Q), ...pending.flat()], { stdio: 'inherit' });
  pending.forEach(([tmp]) => fs.rmSync(tmp));
  layout.weathers[weather] = states;

  if (weather === 'sunny') {
    // the overlay's pieces: each caption, Skip; then on to the end for the logo and TAP TO START
    const cap = async (n, html) => { await page.evaluate(h => { const c = document.querySelector('.si-cap'); c.innerHTML = h; c.classList.add('on'); c.classList.remove('pop'); }, html); return cut(page, '.si-cap', 'cap/' + n, '.si-cap{opacity:1!important;transform:translateX(-50%)!important;}'); };
    const dots = n => '<span class="si-dots">' + [0, 1, 2].map(i => '<i class="' + (i < n ? 'on' : '') + '"></i>').join('') + '</span>';
    const CAPS = [
      ['house', 'A little house is waiting for its squad…'],
      ['box', 'Something is moving in the box… <b>Tap it!</b>'],
      ['squish0', 'Squish Mittens to wake up the house!' + dots(0)],
      ['squish1', 'The living room is awake! <b>Again!</b>' + dots(1)],
      ['squish2', 'The bedroom too! <b>One more!</b>' + dots(2)],
      ['squish3', 'The whole house is waking up!' + dots(3)],
    ];
    layout.overlay.captions = {};
    for (const [n, h] of CAPS) layout.overlay.captions[n] = await cap(n, h);
    layout.overlay.skip = await cut(page, '.si-skip', 'skip');
    // tap the box (its hit area), then squish Mittens three times
    const hit = await page.evaluate(() => { const b = document.querySelector('.si-hit').getBoundingClientRect(); return [b.left + b.width / 2, b.top + b.height / 2]; });
    await page.mouse.click(hit[0], hit[1]);
    await run(page, 3600);
    for (let n = 0; n < 3; n++) {
      const st = await page.evaluate(() => { const b = document.querySelector('.mm-stage').getBoundingClientRect(); return [b.left + b.width / 2, b.top + b.height * 0.55]; });
      await page.mouse.move(st[0], st[1]); await page.mouse.down(); await run(page, 64); await page.mouse.up();
      await run(page, 1600);
    }
    await run(page, 700 + 1200 + 2800 + 1100 + 800 + 12 * 80 + 1200);
    const letters = await page.evaluate(() => document.querySelectorAll('.si-logo > div').length);
    if (!letters) throw new Error('the logo did not come: ' + errs.slice(0, 3).join(' | '));
    for (let i = 0; i < letters; i++) {
      await page.evaluate(i => document.querySelectorAll('.si-logo > div').forEach((d, j) => { d.id = j === i ? '__l' : ''; }), i);
      layout.logo.push(await cut(page, '#__l', 'logo/' + i, '#__l{transform:none!important;}'));
    }
    layout.overlay.tap = await cut(page, '.si-tap', 'tap', '.si-tap{opacity:1!important;}.si-tap span{transform:none!important;}');
  }
  if (errs.length) console.log(weather, 'page errors:', errs.slice(0, 3).join(' | '));
  await ctx.close();
  console.log(weather + ':', layout.weathers[weather].map(s => s.name).join(' '));
}
await browser.close();

// the squad's thumbnails (the peeks), PNG
for (const key of PEEK) {
  const src = path.join(WORK, 'export/thumbs/c-' + key + '.webp'), dst = path.join(OUT, 'peek', key + '.png');
  fs.mkdirSync(path.dirname(dst), { recursive: true });
  execFileSync('python3', ['-c', 'import sys\nfrom PIL import Image\nImage.open(sys.argv[1]).convert("RGBA").save(sys.argv[2])', src, dst]);
  layout.peek[key] = 'Intro/peek/' + key;
}
fs.writeFileSync(path.join(OUT, 'intro.json'), JSON.stringify(layout, null, 1));
console.log('intro ->', path.relative(REPO, OUT), JSON.stringify(layout.canvas));
