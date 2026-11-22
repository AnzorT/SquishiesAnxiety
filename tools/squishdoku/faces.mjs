// Squishdoku's board creatures in three faces, whole body and all (the creatures standing on the room board's
// cushions, RoomBoard.js): every creature Squish Stack has a cut-out of (src/stack/art.js), rendered with the
// face poses tools/rig/heads.mjs gives the board heads (the rig's own face channels, no body motion):
//   idle   the rest face, eyes straight ahead
//   happy  squinting smile, mouth open, blushing (a right creature, the win)
//   sad    frown, teary eyes, lids and ears down (a wrong one, a lost level)
// Rendered like tools/rig/thumbs.mjs makes the stills the cut-outs come from (same page, size and margin,
// idle at t = 0, blinks and glances off), the floor shadow cleared like tools/stack/fit.py, and all three
// cropped to one box, so they lie exactly over each other (the board fades a face in over the idle one).
// Not the cut-outs themselves: those were made from older rigs and glances, a few pixels off these.
// Writes assets/squishdoku/bodies/<key>-<face>.webp and src/squishdoku/bodies.js:
// key -> { idle, happy, sad, ar } (ar = height / width).
// usage: node tools/rig/build.mjs && node tools/squishdoku/faces.mjs [key ...]
import { spawn } from 'node:child_process';
import { mkdirSync, readdirSync, readFileSync, unlinkSync, writeFileSync, existsSync } from 'node:fs';
import { createRequire } from 'node:module';
import { join, dirname } from 'node:path';
import { fileURLToPath, pathToFileURL } from 'node:url';
import { tmpdir } from 'node:os';

const ROOT = join(dirname(fileURLToPath(import.meta.url)), '..', '..');
const ASSETS = join(ROOT, 'android', 'app', 'src', 'main', 'assets', 'rig');
const CUTS = join(ROOT, 'assets', 'stack');
const OUT = join(ROOT, 'assets', 'squishdoku', 'bodies');
const INDEX = join(ROOT, 'src', 'squishdoku', 'bodies.js');
const PORT = 9338;
const SIZE = 512; // thumbs.mjs's
const MARGIN = 0.06; // thumbs.mjs's
const SOLID = 60; // fit.py's: alpha at or under it is the floor shadow
const MAX_SIDE = 256; // the longest side (a board creature is drawn ~180 px wide at most)
const QUALITY = 0.86;
const FACES = ['idle', 'happy', 'sad'];
const LEFT_OUT = new Set(['heroes', 'elemental']); // as src/stack/roster.js and src/squishdoku/roster.js

const args = process.argv.slice(2);
if (!existsSync(join(ASSETS, 'host.html'))) throw new Error('run node tools/rig/build.mjs first');
const { ROSTER } = createRequire(import.meta.url)(join(ROOT, 'functions', 'squad.js'));
const cut = new Set(readdirSync(CUTS).filter((f) => f.endsWith('.webp')).map((f) => f.slice(0, -5)));
const keys = args.length ? args : ROSTER.filter((c) => !LEFT_OUT.has(c.set) && cut.has(c.key)).map((c) => c.key).sort();
mkdirSync(OUT, { recursive: true });

const chromePath = (await import(pathToFileURL(join(ROOT, 'node_modules', 'chrome-launcher', 'dist', 'chrome-finder.js')).href).catch(() => null))
  ?.win32?.()[0] || 'C:/Program Files/Google/Chrome/Application/chrome.exe';
const profile = join(tmpdir(), 'sdk-faces-' + process.pid);
const chrome = spawn(chromePath, ['--headless=new', '--no-sandbox', '--allow-file-access-from-files', '--hide-scrollbars',
  `--remote-debugging-port=${PORT}`, `--window-size=${SIZE},${SIZE}`, `--user-data-dir=${profile}`, 'about:blank'], { stdio: 'ignore' });
const sleep = (ms) => new Promise((r) => setTimeout(r, ms));
let page;
for (let i = 0; i < 50 && !page; i++) { await sleep(200); try { page = (await (await fetch(`http://127.0.0.1:${PORT}/json/list`)).json()).find((t) => t.type === 'page'); } catch (e) {} }
if (!page) { chrome.kill(); throw new Error('Chrome did not start'); }

const ws = new WebSocket(page.webSocketDebuggerUrl);
await new Promise((r) => ws.addEventListener('open', r));
let id = 0; const pend = new Map();
ws.addEventListener('message', (e) => { const m = JSON.parse(e.data); if (m.id && pend.has(m.id)) { pend.get(m.id)(m); pend.delete(m.id); } });
const send = (method, params = {}) => new Promise((r) => { const i = ++id; pend.set(i, r); ws.send(JSON.stringify({ id: i, method, params })); });
const evalJs = async (js) => {
  const m = await send('Runtime.evaluate', { expression: js, returnByValue: true, awaitPromise: true });
  if (m.result?.exceptionDetails) throw new Error(JSON.stringify(m.result.exceptionDetails).slice(0, 400));
  return m.result?.result?.value;
};

await send('Page.enable');
await send('Emulation.setDeviceMetricsOverride', { width: SIZE, height: SIZE, deviceScaleFactor: 1, mobile: false });
await send('Emulation.setDefaultBackgroundColorOverride', { color: { r: 0, g: 0, b: 0, a: 0 } });
await send('Page.navigate', { url: pathToFileURL(join(ASSETS, 'host.html')).href });
for (let i = 0; i < 100 && !(await evalJs('!!(window.__rigOut||[]).find(m=>m.type==="ready")')); i++) await sleep(100);
await evalJs(`document.getElementById('stage').style.inset = '${MARGIN * 100}%'`);
// heads.mjs's faces: face channels only, held for good
await evalJs(`(RiveRig.add({
  bd_idle: { dur: 1e9, k: {} },
  bd_happy: { dur: 1e9, k: { hap: [[0, 1]], smile: [[0, 1]], open: [[0, 0.55]], ly: [[0, -0.3]], blush: [[0, 0.7]] } },
  bd_sad: { dur: 1e9, k: { frown: [[0, 0.95]], teary: [[0, 1]], sl: [[0, 1]], ly: [[0, 0.55]], earL: [[0, 24]], earR: [[0, 24]] } },
}), true)`);

// In the page: the floor shadow cleared from each shot (fit.py), all three cropped to the box they fill
// together and scaled so its longest side is `max`, as webp; and the box's height / width.
function finish(shots, solid, max, quality) {
  const load = (b64) => new Promise((ok) => { const im = new Image(); im.onload = () => ok(im); im.src = 'data:image/png;base64,' + b64; });
  return Promise.all(shots.map(load)).then((ims) => {
    const W = ims[0].width, H = ims[0].height;
    let x0 = W, y0 = H, x1 = -1, y1 = -1;
    const cvs = ims.map((im) => {
      const c = document.createElement('canvas'); c.width = W; c.height = H; const x = c.getContext('2d'); x.drawImage(im, 0, 0);
      const d = x.getImageData(0, 0, W, H);
      for (let i = 3; i < d.data.length; i += 4) if (d.data[i] <= solid) d.data[i] = 0;
      x.putImageData(d, 0, 0);
      for (let y = 0; y < H; y++) for (let xx = 0; xx < W; xx++) if (d.data[(y * W + xx) * 4 + 3]) { if (xx < x0) x0 = xx; if (xx > x1) x1 = xx; if (y < y0) y0 = y; if (y > y1) y1 = y; }
      return c;
    });
    const w = x1 + 1 - x0, h = y1 + 1 - y0, k = Math.min(1, max / Math.max(w, h));
    const out = cvs.map((c) => { const o = document.createElement('canvas'); o.width = Math.round(w * k); o.height = Math.round(h * k); const x = o.getContext('2d');
      x.imageSmoothingQuality = 'high'; x.drawImage(c, x0, y0, w, h, 0, 0, o.width, o.height); return o.toDataURL('image/webp', quality).split(',')[1]; });
    return { out, ar: h / w };
  });
}

for (const f of readdirSync(OUT)) if (f.endsWith('.webp') && (!args.length || keys.some((k) => f.startsWith(k + '-')))) unlinkSync(join(OUT, f));
const done = {};
let bytes = 0;
for (const key of keys) {
  const m = await evalJs(`new Promise(ok => { window.__rigOut = []; rigHost.shuffle(false); rigHost.mount(${JSON.stringify(key)});
    const t0 = performance.now(), wait = () => { const m = window.__rigOut.find(x => x.type === 'mounted' || x.type === 'error');
      if (m) { const I = window.RiveRig._last && window.RiveRig._last._I; if (I) { I.blinkAt = I.glAt = I.fidAt = Infinity; I.gl = [0, 0]; }
        requestAnimationFrame(() => requestAnimationFrame(() => ok(m))); }
      else if (performance.now() - t0 > 9000) ok({ type: 'error', message: 'timeout' }); else setTimeout(wait, 20); }; wait(); })`);
  if (!m || m.type !== 'mounted') { console.log('FAILED', key, m && m.message); continue; }
  const shots = [];
  for (const face of FACES) {
    await evalJs(`(RiveRig._last._pose('bd_${face}', 0), new Promise(r => requestAnimationFrame(() => requestAnimationFrame(r))))`);
    shots.push((await send('Page.captureScreenshot', { format: 'png' })).result.data);
  }
  const r = await evalJs(`(${finish})(${JSON.stringify(shots)}, ${SOLID}, ${MAX_SIDE}, ${QUALITY})`);
  FACES.forEach((face, i) => { const buf = Buffer.from(r.out[i], 'base64'); bytes += buf.length; writeFileSync(join(OUT, `${key}-${face}.webp`), buf); });
  done[key] = r.ar;
  process.stdout.write('.');
}
ws.close(); chrome.kill();
console.log(`\n${Object.keys(done).length}/${keys.length} creatures (${(bytes / 1024).toFixed(0)} KB) -> ${OUT}`);

// the index: every creature with all three faces on disk (a partial run keeps the others' ar)
const prev = {};
if (existsSync(INDEX)) for (const [, k, v] of readFileSync(INDEX, 'utf8').matchAll(/^ {2}(\w+): \{.*ar: ([\d.]+) \},$/gm)) prev[k] = +v;
const all = [...new Set(readdirSync(OUT).filter((f) => f.endsWith('-idle.webp')).map((f) => f.slice(0, -'-idle.webp'.length)))]
  .filter((k) => FACES.every((f) => existsSync(join(OUT, `${k}-${f}.webp`))) && (done[k] || prev[k])).sort();
const src = `// Generated by tools/squishdoku/faces.mjs: each board creature, whole body and all, in its idle, happy and
// sad faces, cropped to one box so they lie right over each other (ar = height / width). Don't edit by hand.

export default {
${all.map((k) => `  ${k}: { ${FACES.map((f) => `${f}: require('../../assets/squishdoku/bodies/${k}-${f}.webp')`).join(', ')}, ar: ${(done[k] || prev[k]).toFixed(3)} },`).join('\n')}
};
`;
writeFileSync(INDEX, src);
console.log(`index -> ${INDEX} (${all.length})`);
