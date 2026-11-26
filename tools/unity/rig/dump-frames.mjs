// Real creature frames for testing a renderer: the creatures run on the browser stand-in (dom-shim.js), and every few
// frames their SVG is written out next to Chrome's own picture of it, so another renderer (Unity's) can be compared
// with the browser, pixel for pixel.
//
//   node tools/unity/rig/dump-frames.mjs <outDir> [mittens lumi ...] [--size 475] [--every 30] [--frames 240] [--look n]
//   (--look: the border look the creature is drawn in, 0-4: Creatures/Js/RigLooks; the rig's own default 4 without it)
//
// <outDir>/<key>-<frame>.svg   the creature's <svg> (the fabric tile as href="grain.png")
// <outDir>/<key>-<frame>.png   Chrome's picture of it at size x size on white
// <outDir>/grain.png           the rig's fabric-grain tile (the canvas the rig draws, 1024 x 1024)
import fs from 'node:fs';
import path from 'node:path';
import vm from 'node:vm';
import { createRequire } from 'node:module';
import { fileURLToPath, pathToFileURL } from 'node:url';
import { PNG } from 'pngjs';

const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
const HERE = path.dirname(fileURLToPath(import.meta.url));
const REPO = path.resolve(HERE, '../../..');
const WORK = path.join(REPO, 'webgame/test/out/unity-webgame');
const args = process.argv.slice(2);
const arg = (k, d) => { const i = args.indexOf('--' + k); return i >= 0 ? args[i + 1] : d; };
const OUT = path.resolve(args[0] || 'frames');
const KEYS = args.slice(1).filter((a, i, all) => !a.startsWith('--') && !(all[i - 1] || '').startsWith('--'));
const SIZE = +arg('size', 475), EVERY = +arg('every', 30), FRAMES = +arg('frames', 240), LOOK = arg('look', null);
const RIG = eval(fs.readFileSync(path.join(HERE, 'parity.mjs'), 'utf8').match(/export const RIG_SCRIPTS = (\[[\s\S]*?\]);/)[1]);
const SCRIPT = [[0, 'idle'], [40, 'dance'], [120, 'hop'], [170, 'squish'], [210, 'happy']];

fs.mkdirSync(OUT, { recursive: true });
let grainWritten = false;
const svgs = [];
for (const key of KEYS.length ? KEYS : ['mittens']) {
  const ctx = vm.createContext({ __realSetTimeout: setTimeout, console: { log() {}, warn() {}, error() {} }, Promise, Uint8ClampedArray, Float32Array, Uint32Array, Map, Set, JSON, Symbol, Proxy });
  const run = (c, f) => vm.runInContext(c, ctx, { filename: f });
  run(fs.readFileSync(path.join(HERE, 'dom-shim.js'), 'utf8'), 'dom-shim.js');
  ctx.__rf = r => fs.readFileSync(path.join(WORK, r), 'utf8');
  run('RigDomShim.install(globalThis, { readFile: __rf })', 'install');
  run(fs.readFileSync(path.join(HERE, 'virtual-clock.js'), 'utf8'), 'virtual-clock.js');
  for (const s of RIG) { try { run(fs.readFileSync(path.join(WORK, s), 'utf8'), s); } catch (e) { /* as in the app */ } }
  run(`var host = document.createElement('div'); document.body.appendChild(host); var ctl = RiveRig.mount(host, ${JSON.stringify(key)}, ${LOOK != null ? `{ look: ${+LOOK} }` : '{}'});`, 'mount');
  await new Promise(r => setTimeout(r, 400));
  // the fabric tile: the 128 x 128 noise canvas, as the 1024 x 1024 pattern the rig asks for
  if (!grainWritten) {
    const tile = run(`(() => { for (const k in __rigShim.canvases) { const c = __rigShim.canvases[k]; const t = c._tiled; if (t && t.src._pixels) return { w: t.w, h: t.h, p: t.src._pixels }; } return null; })()`, 'grain');
    if (tile) {
      const png = new PNG({ width: tile.w, height: tile.h });
      for (let y = 0; y < tile.h; y++) for (let x = 0; x < tile.w; x++) { const s = ((y % tile.p.height) * tile.p.width + (x % tile.p.width)) * 4, d = (y * tile.w + x) * 4; for (let c = 0; c < 4; c++) png.data[d + c] = tile.p.data[s + c]; }
      fs.writeFileSync(path.join(OUT, 'grain.png'), PNG.sync.write(png));
      grainWritten = true;
    }
  }
  for (let f = 0; f <= FRAMES; f++) {
    for (const [at, name] of SCRIPT) if (at === f) run(`ctl.play(${JSON.stringify(name)})`, 'play');
    if (f % EVERY === 0) {
      let svg = run(`host.querySelector('svg').outerHTML`, 'svg');
      svg = svg.replace(/href="shim-canvas:[^"]*"/g, 'href="grain.png"').replace('<svg ', '<svg xmlns="http://www.w3.org/2000/svg" ');
      const name = `${key}-${String(f).padStart(3, '0')}`;
      fs.writeFileSync(path.join(OUT, name + '.svg'), svg);
      svgs.push(name);
    }
    run('__clock.frame(16)', 'frame');
  }
}

// Chrome's pictures: the same markup in a page, the creature box at SIZE x SIZE on white
const browser = await chromium.launch({ args: ['--allow-file-access-from-files'] });
const page = await browser.newPage({ viewport: { width: SIZE, height: SIZE } });
await page.goto(pathToFileURL(path.join(OUT, 'grain.png')).href.replace(/grain\.png$/, ''));
for (const name of svgs) {
  const svg = fs.readFileSync(path.join(OUT, name + '.svg'), 'utf8');
  await page.setContent(`<!doctype html><base href="${pathToFileURL(OUT + '/').href}"><style>html,body{margin:0;background:#fff}</style><div style="position:absolute;left:0;top:0;width:${SIZE}px;height:${SIZE}px">${svg.replace('<svg ', '<svg style="position:absolute;inset:0;overflow:visible" ')}</div>`);
  await page.waitForTimeout(40);
  await page.screenshot({ path: path.join(OUT, name + '.png') });
}
await browser.close();
console.log(`${svgs.length} frames -> ${OUT}`);
