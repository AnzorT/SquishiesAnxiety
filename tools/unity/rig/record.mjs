// Records a creature's frames from the app's own rig code (on the browser stand-in) for the Unity app to play back,
// until the JS engine runs the rig live inside Unity: each frame is the creature's <svg> markup, as the live host
// would hand it over.
//
//   node tools/unity/rig/record.mjs mittens [--seconds 8] [--fps 30] [--moves idle]
//   node tools/unity/rig/record.mjs mittens --clip park-enter --seconds 4    (PLAY's walk to the Game Park; park-leave)
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
