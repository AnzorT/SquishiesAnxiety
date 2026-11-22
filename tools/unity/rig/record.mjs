// Records a creature's frames from the app's own rig code (on the browser stand-in) for the Unity app to play back,
// until the JS engine runs the rig live inside Unity: each frame is the creature's <svg> markup, as the live host
// would hand it over.
//
//   node tools/unity/rig/record.mjs mittens [--seconds 8] [--fps 30] [--moves idle]
//
// -> unity/Assets/Resources/Creatures/<key>.bytes (gzip of: fps\n then one frame per line), grain tile alongside.
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

const total = Math.round(SECONDS * FPS), step = 1000 / FPS, frames = [];
let t = 0, next = 0;
for (let f = 0; f < total; f++) {
  const move = MOVES[Math.floor(f / total * MOVES.length)];
  if (f === 0 || MOVES[Math.floor((f - 1) / total * MOVES.length)] !== move) run(`ctl.play(${JSON.stringify(move)})`, 'play');
  next += step;
  while (t + 16 <= next) { run('__clock.frame(16)', 'frame'); t += 16; }
  if (next > t) { run(`__clock.frame(${next - t})`, 'frame'); t = next; }
  frames.push(run(`host.querySelector('svg').outerHTML`, 'svg').replace(/href="shim-canvas:[^"]*"/g, 'href="grain"').replace(/\n/g, ' '));
}
const body = FPS + '\n' + frames.join('\n');
const gz = zlib.gzipSync(body, { level: 9 });
fs.writeFileSync(path.join(OUT, key + '.bytes'), gz);
console.log(`${key}: ${frames.length} frames at ${FPS} fps (${MOVES.join(', ')}), ${(body.length / 1048576).toFixed(1)} MB of SVG -> ${(gz.length / 1024).toFixed(0)} KB gzip`);
