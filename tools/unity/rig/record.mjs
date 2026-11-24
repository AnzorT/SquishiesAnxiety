// Records a creature's frames from the app's own rig code (on the browser stand-in) for the Unity app to play back,
// until the JS engine runs the rig live inside Unity: each frame is the creature's <svg> markup, as the live host
// would hand it over.
//
//   node tools/unity/rig/record.mjs mittens [--seconds 8] [--fps 30] [--moves idle]
//   node tools/unity/rig/record.mjs mittens --clip park-enter --seconds 4    (PLAY's walk to the Game Park; park-leave)
//   node tools/unity/rig/record.mjs mittens --clip result [--fps 24]    (the result card's character: four clips)
//
// --clip result: the result card's character (tools/rig/result.html, src/squishdoku/Trio.js) as Creatures/ResultRig.cs
// plays it: <key>-res-wait (resWait, a loop), -res-fill (the fill and the slow jump: resWait, resWow at 62 % of the
// fill, then resHappy, the page's arms and turn and its bursts in it), -res-happy (resHappy with the page's sway and its
// four happy moves, as the first of the three plays them), -res-miss (resMiss, its tear, then resSad). The body's lift,
// squash and tilt are the card's (Ui/Cards/TrioItem.cs), not in the clips. Also writes Creatures/result-states.txt: the
// page's states for the live engine (Creatures/LiveRig.cs).
//
// -> unity/Assets/Resources/Creatures/<key>[-<clip>].bytes (gzip of: fps\n then one frame per line), grain tile alongside.
import fs from 'node:fs';
import path from 'node:path';
import vm from 'node:vm';
import zlib from 'node:zlib';
import { fileURLToPath } from 'node:url';
import { PNG } from 'pngjs';

const HERE = path.dirname(fileURLToPath(import.meta.url));
const REPO = path.resolve(HERE, '../../..');
const WORK = path.join(REPO, 'webgame/test/out/unity-webgame');
const OUT = path.join(REPO, 'unity/Assets/Resources/Creatures');
const args = process.argv.slice(2);
const arg = (k, d) => { const i = args.indexOf('--' + k); return i >= 0 ? args[i + 1] : d; };
const key = args.find((a, i) => !a.startsWith('--') && !(args[i - 1] || '').startsWith('--')) || 'mittens';
const SECONDS = +arg('seconds', 8), FPS = +arg('fps', 30), MOVES = arg('moves', 'idle').split(',');
const RIG = eval(fs.readFileSync(path.join(HERE, 'parity.mjs'), 'utf8').match(/export const RIG_SCRIPTS = (\[[\s\S]*?\]);/)[1]);

if (!fs.existsSync(path.join(WORK, 'rive-rig.js'))) { const { build } = await import('../../../webgame/build.mjs'); await build(WORK); }
const ctx = vm.createContext({ __realSetTimeout: setTimeout, console: { log() {}, warn() {}, error() {} }, Promise, Uint8ClampedArray, Float32Array, Uint32Array, Map, Set, JSON, Symbol, Proxy });
const run = (c, f) => vm.runInContext(c, ctx, { filename: f });
run(fs.readFileSync(path.join(HERE, 'dom-shim.js'), 'utf8'), 'dom-shim.js');
ctx.__rf = r => fs.readFileSync(path.join(WORK, r), 'utf8');
run('RigDomShim.install(globalThis, { readFile: __rf })', 'install');
run(fs.readFileSync(path.join(HERE, 'virtual-clock.js'), 'utf8'), 'virtual-clock.js');
for (const s of RIG) { try { run(fs.readFileSync(path.join(WORK, s), 'utf8'), s); } catch (e) { /* as in the app */ } }
run(`var host = document.createElement('div'); document.body.appendChild(host); var ctl = RiveRig.mount(host, ${JSON.stringify(key)}, {});`, 'mount');
await new Promise(r => setTimeout(r, 400));

fs.mkdirSync(OUT, { recursive: true });
// the fabric tile the rig made (128 x 128 noise; the filter tiles it), for Unity's grain
const tile = run(`(() => { for (const k in __rigShim.canvases) { const c = __rigShim.canvases[k]; if (c._tiled && c._tiled.src._pixels) return c._tiled.src._pixels; } return null; })()`, 'grain');
if (tile) {
  const png = new PNG({ width: tile.width, height: tile.height });
  png.data.set(tile.data);
  fs.writeFileSync(path.join(OUT, 'grain-tile.png'), PNG.sync.write(png));
}

const step = 1000 / FPS, frames = [];
let t = 0, next = 0;
const grab = () => frames.push(run(`host.querySelector('svg').outerHTML`, 'svg').replace(/href="shim-canvas:[^"]*"/g, 'href="grain"').replace(/\n/g, ' '));
const CLIP = arg('clip', null);
if (CLIP === 'result') {
  // result.html's addStates, as the page has it (the rig's states for the result card), for this run and for Unity's engine
  const page = fs.readFileSync(path.join(REPO, 'tools/rig/result.html'), 'utf8');
  const helpers = page.match(/const AR = K => \(\{ armL: K, armR: K \}\), ER = K => \(\{ earL: K, earR: K \}\);/)[0];
  const body = page.match(/function addStates\(\) \{\n([\s\S]*?)\n  \}\n/)[1];
  const states = `// tools/rig/result.html addStates (written by tools/unity/rig/record.mjs --clip result): the result card's states\n`
    + `(function () { if (window.__resStates) return; window.__resStates = true;\n${helpers}\n${body}\n`
    + `  // (the last controller RiveRig.mount made: Creatures/ResultRig.cs keeps it per creature, for the bursts)\n`
    + `  const mount = window.RiveRig.mount; window.RiveRig.mount = function () { const c = mount.apply(this, arguments); window.__resLast = c; return c; };\n})();\n`;
  fs.mkdirSync(OUT, { recursive: true });
  fs.writeFileSync(path.join(OUT, 'result-states.txt'), states);
  run(states, 'result-states');
  // result.html's moves on the rig (ext) and its bursts, frame by frame from each clip's start (the first character: idx 0)
  run(`(() => {
    const R = RiveRig, kv = R.kv, clamp = (v, a, b) => Math.max(a, Math.min(b, v)), SM = x => { x = clamp(x, 0, 1); return x * x * (3 - 2 * x); };
    const parab = u => (u <= 0 || u >= 1 ? 0 : 4 * u * (1 - u)), AR = K => ({ armL: K, armR: K });
    const FILL = 560, CROUCH = 360, RISE = 640, HANG = 320, FALL = 460, LAND = 480;
    const a = FILL, b = a + CROUCH, top = b + RISE, down = top + HANG, ground = down + FALL, D = ground + LAND;
    const HAPPY = [
      { ms: 1000, f(t) { const u = t / 1000, h = Math.max(parab(u * 2), parab(u * 2 - 1)); return { ext: AR(30 * h + 8) }; } },
      { ms: 1300, f(t) { const e = Math.sin(clamp(t / 1300, 0, 1) * Math.PI), w = Math.sin(t / 85); return { ext: { armR: (54 + 16 * w) * e, armL: -6 * e, htilt: 6 * e } }; } },
      { ms: 1100, f(t) { const e = Math.sin(clamp(t / 1100, 0, 1) * Math.PI), w = Math.sin(t / 90); return { ext: { lean: 2.2 * w * e, armL: (24 + 14 * w) * e, armR: (24 - 14 * w) * e } }; } },
      { ms: 1200, f(t) { const u = t / 1200, h = parab((u - 0.15) / 0.7); return { ext: Object.assign({ spin: 360 * SM((u - 0.2) / 0.62) }, AR(40 * h)) }; } },
    ];
    let c = null, I = null, E = {}, bb = null, fired = {}, hp = null;
    const box = () => { try { const g = host.querySelector('svg').getBBox(); return { cx: g.x + g.width / 2, gy: g.y + g.height, top: g.y }; } catch (e) { return { cx: 50, gy: 90, top: 10 }; } };
    const burst = (kind, where, n) => { const p = where === 'feet' ? [bb.cx, bb.gy - 2] : where === 'head' ? [bb.cx, bb.top + 4] : (I.W && I.W[where]) || [50, 50]; try { R.emit(I, kind, p, n); } catch (e) {} };
    const once = (k, t, at, fn) => { if (t >= at && !fired[k]) { fired[k] = 1; fn(); } };
    window.__resStart = (clip) => {
      if (c) c.destroy();
      host.innerHTML = '';
      c = R.mount(host, ${JSON.stringify(key)}, { fidgets: false }); I = c._I; I.fidgets = false; I.hfid = 1;
      E = {}; I.ext = E; bb = null; fired = {}; hp = clip === 'happy' ? { n: 0, next: 500, mv: null, at: 0 } : null;
      // (waiting first, as on the card, until what it does as it's mounted has settled and its particles are gone)
      c.play('resWait');
      for (let t = 0; t < 1500; t += 16) __clock.frame(16);
      if (clip === 'happy') c.play('resHappy'); else if (clip === 'miss') c.play('resMiss');
    };
    window.__resStep = (clip, t) => {
      if (!bb) bb = box();
      for (const k in E) E[k] = 0;
      if (clip === 'fill') {
        once('wow', t, FILL * 0.62, () => c.play('resWow'));
        once('s1', t, FILL, () => burst('resSpark', 'head', 7));
        once('h1', t, top - 120, () => burst('resHeart', 'head', 1));
        once('h2', t, top + 160, () => burst('resHeart', 'head', 1));
        once('g', t, ground, () => { burst('resDust', 'feet'); burst('resSpark', 'feet', 5); });
        once('happy', t, D, () => c.play('resHappy'));
        if (t < D) {
          const arm = kv([[0, 0], [a, 6, 'io'], [b, -16, 'io'], [b + 160, 52, 'o'], [down, 46, 'io'], [ground, 30, 'io'], [ground + 120, -10, 'o'], [D, 14, 'io']], t);
          const wave = t > b + 160 && t < down ? 10 * Math.sin((t - b) / 95) : 0;
          const spin = t < b + 80 ? 0 : t > ground - 40 ? 0 : 360 * SM((t - b - 80) / (ground - 40 - b - 80));
          Object.assign(E, { armL: arm + wave, armR: arm - wave, spin, footL: t > b && t < ground ? 2 : 0, footR: t > b && t < ground ? 2 : 0 });
        }
      } else if (clip === 'miss') once('tear', t, 700, () => burst('resTear', 'eyeL'));
      else if (clip === 'happy') {
        const w = t / 1000; Object.assign(E, AR(10 + 6 * Math.sin(w * 3)));
        if (!hp.mv && t >= hp.next) { hp.mv = HAPPY[hp.n % HAPPY.length]; hp.n += 1; hp.at = t; if (hp.n % 2 === 0) burst('resHeart', 'head', 1); }
        if (hp.mv) {
          const u = t - hp.at;
          if (u >= hp.mv.ms) { hp.mv = null; hp.next = t + 900 + ((hp.n * 211) % 700); }
          else { const r = hp.mv.f(u); for (const k in r.ext) E[k] = (E[k] || 0) + r.ext[k]; }
        }
      }
    };
  })()`, 'result');
  // each clip's length: the wait's loop; the fill to its landing and a moment of resHappy; the happy moves' round
  // (500 ms, then four moves with their rests); the sigh and the tear's fall
  const LEN = { wait: 2000, fill: 2820 + 400, happy: 500 + 1000 + 1111 + 1300 + 1322 + 1100 + 1533 + 1200 + 1044, miss: 1900 };
  for (const clip of ['wait', 'fill', 'happy', 'miss']) {
    run(`__resStart(${JSON.stringify(clip)})`, 'start');
    const fr = [];
    let ct = 0, cn = 0;
    const total = Math.round(LEN[clip] / 1000 * FPS);
    for (let f = 0; f < total; f++) {
      cn += step;
      while (ct + 16 <= cn) { run(`__resStep(${JSON.stringify(clip)}, ${ct}); __clock.frame(16)`, 'frame'); ct += 16; }
      fr.push(run(`host.querySelector('svg').outerHTML`, 'svg').replace(/href="shim-canvas:[^"]*"/g, 'href="grain"').replace(/\n/g, ' '));
    }
    const body = FPS + '\n' + fr.join('\n');
    const gz = zlib.gzipSync(body, { level: 9 });
    fs.writeFileSync(path.join(OUT, `${key}-res-${clip}.bytes`), gz);
    console.log(`${key}-res-${clip}: ${fr.length} frames at ${FPS} fps, ${(gz.length / 1024).toFixed(0)} KB gzip`);
  }
  process.exit(0);
}
if (CLIP === 'park-enter' || CLIP === 'park-leave') {
  // webgame/app/menu.js enterPark / leavePark, the creature's part: turn (spinOff), walk with HouseWalk's gait, turn
  // back, then 'happy'. The same calls, frame by frame at 16 ms; a frame kept every 1000 / FPS ms.
  run(`(() => {
    const I = ctl._I, HW = window.HouseWalk, EIO = t => t < 0.5 ? 2 * t * t : 1 - Math.pow(-2 * t + 2, 2) / 2;
    const enter = ${JSON.stringify(CLIP === 'park-enter')}, turn = enter ? 380 : 340, walkMs = enter ? 2300 : 2100, dir = enter ? -90 : 90;
    const E = {}, ws = {}, prev = I.ext; let ph = 0, at = 0;
    window.__clipStep = function (now) {
      // now: ms since the clip started
      if (ph === 0) { ctl.play('idle'); ph = 1; }
      if (now < turn) { I.spinOff = dir * EIO(now / turn); return; }
      if (now < turn + walkMs) {
        if (I.ext !== E) I.ext = E;
        const tt = (now - turn) / walkMs, w = Math.min(1, tt / 0.08, (1 - tt) / 0.1);
        for (const k in E) E[k] = 0;
        try { HW.step(${JSON.stringify(key)}, ws, E, Math.max(0, w), 0.016, 1, dir); } catch (e) {}
        I.spinOff = dir;
        return;
      }
      if (I.ext === E) { for (const k in E) E[k] = 0; I.ext = prev; }
      if (now < 2 * turn + walkMs) { I.spinOff = dir * (1 - EIO((now - turn - walkMs) / turn)); return; }
      if (ph === 1) { I.spinOff = 0; ctl.play('happy'); ph = 2; }
    };
  })()`, 'clip');
  const total = Math.round(SECONDS * FPS);
  for (let f = 0; f < total; f++) {
    next += step;
    while (t + 16 <= next) { run(`__clipStep(${t}); __clock.frame(16)`, 'frame'); t += 16; }
    grab();
  }
} else {
  const total = Math.round(SECONDS * FPS);
  for (let f = 0; f < total; f++) {
    const move = MOVES[Math.floor(f / total * MOVES.length)];
    if (f === 0 || MOVES[Math.floor((f - 1) / total * MOVES.length)] !== move) run(`ctl.play(${JSON.stringify(move)})`, 'play');
    next += step;
    while (t + 16 <= next) { run('__clock.frame(16)', 'frame'); t += 16; }
    if (next > t) { run(`__clock.frame(${next - t})`, 'frame'); t = next; }
    grab();
  }
}
const body = FPS + '\n' + frames.join('\n');
const gz = zlib.gzipSync(body, { level: 9 });
const outName = key + (CLIP ? '-' + CLIP : '');
fs.writeFileSync(path.join(OUT, outName + '.bytes'), gz);
console.log(`${outName}: ${frames.length} frames at ${FPS} fps (${CLIP || MOVES.join(', ')}), ${(body.length / 1048576).toFixed(1)} MB of SVG -> ${(gz.length / 1024).toFixed(0)} KB gzip`);
