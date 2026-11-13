// Squishdoku's board heads: every creature the game draws (not the Masked or Elemental Heroes),
// its head alone (no body, arms, feet or tail) in three faces, rendered with the same host page the
// app's WebView uses. The faces are poses of the rig's own face channels with no body motion, so
// the head sits still and the three line up:
//   idle   the rest face
//   happy  squinting smile, mouth open, blushing (a right creature)
//   sad    frown, teary eyes, lids and ears down (a wrong one)
// Limbs go by their rig role; a creature with a body of its own under the head (CUT) also loses
// everything under the head's middle that is outside the head's circle (×k), and BAND keeps a tail
// beside the head out too. Each face is cropped to the three's common square and written as
// assets/squishdoku/heads/<key>-<face>.webp, plus src/squishdoku/heads.js: key -> { idle, happy,
// sad, eyes } (eyes: where the two eyes are, as fractions of the picture, for the tears).
// usage: node tools/rig/build.mjs && node tools/rig/heads.mjs [size=224] [key ...]
import { spawn } from 'node:child_process';
import { mkdirSync, readdirSync, readFileSync, unlinkSync, writeFileSync, existsSync } from 'node:fs';
import { createRequire } from 'node:module';
import { join, dirname } from 'node:path';
import { fileURLToPath, pathToFileURL } from 'node:url';
import { tmpdir } from 'node:os';

const ROOT = join(dirname(fileURLToPath(import.meta.url)), '..', '..');
const ASSETS = join(ROOT, 'android', 'app', 'src', 'main', 'assets', 'rig');
const OUT = join(ROOT, 'assets', 'squishdoku', 'heads');
const INDEX = join(ROOT, 'src', 'squishdoku', 'heads.js');
const PORT = 9337;
const WIN = 640; // the page; the creature's box is 80 % of it, so a head is ~300 px before the crop
const FACES = ['idle', 'happy', 'sad'];
const LEFT_OUT = new Set(['heroes', 'elemental']); // as src/squishdoku/roster.js
// a body of its own under the head: cut to the head's circle (× k) under its middle
const CUT = {
  acorn: 1.03, biscuit: 1.03, countsquishula: 1.03, drako: 1.03, fawn: 1.03, gumdrop: 1.03, hana: 1.03, hexie: 1.03,
  hocus: 1.03, hoot: 1.03, jelli: 1.03, jinni: 1.03, kiko: 1.03, leo: 1.3, lumi: 1.03, mamapaws: 1.03, marina: 1.03,
  mumbles: 1.03, nibbles: 1.03, octo: 1.03, panko: 1.0, pip: 1.03, pixie: 1.03, sugarplum: 1.03, teddy: 1.03, unibun: 1.03,
};
// a tail beside the head (above its middle too): also keep only a band this wide (× the head's width)
const BAND = { acorn: 1.08, drako: 1.15 };

const args = process.argv.slice(2);
const SIZE = /^\d+$/.test(args[0] || '') ? +args.shift() : 224;
if (!existsSync(join(ASSETS, 'host.html'))) throw new Error('run node tools/rig/build.mjs first');
const { ROSTER } = createRequire(import.meta.url)(join(ROOT, 'functions', 'squad.js'));
const keys = args.length ? args : ROSTER.filter((c) => !LEFT_OUT.has(c.set)).map((c) => c.key).sort();
mkdirSync(OUT, { recursive: true });

const chromePath = (await import(pathToFileURL(join(ROOT, 'node_modules', 'chrome-launcher', 'dist', 'chrome-finder.js')).href).catch(() => null))
  ?.win32?.()[0] || 'C:/Program Files/Google/Chrome/Application/chrome.exe';
const profile = join(tmpdir(), 'rig-heads-' + process.pid);
const chrome = spawn(chromePath, ['--headless=new', '--no-sandbox', '--allow-file-access-from-files', '--hide-scrollbars',
  `--remote-debugging-port=${PORT}`, `--window-size=${WIN},${WIN}`, `--user-data-dir=${profile}`, 'about:blank'], { stdio: 'ignore' });
const sleep = ms => new Promise(r => setTimeout(r, ms));
let page;
for (let i = 0; i < 50 && !page; i++) { await sleep(200); try { page = (await (await fetch(`http://127.0.0.1:${PORT}/json/list`)).json()).find(t => t.type === 'page'); } catch (e) {} }
if (!page) { chrome.kill(); throw new Error('Chrome did not start'); }

const ws = new WebSocket(page.webSocketDebuggerUrl);
await new Promise(r => ws.addEventListener('open', r));
let id = 0; const pend = new Map();
ws.addEventListener('message', e => { const m = JSON.parse(e.data); if (m.id && pend.has(m.id)) { pend.get(m.id)(m); pend.delete(m.id); } });
const send = (method, params = {}) => new Promise(r => { const i = ++id; pend.set(i, r); ws.send(JSON.stringify({ id: i, method, params })); });
const evalJs = async js => {
  const m = await send('Runtime.evaluate', { expression: js, returnByValue: true, awaitPromise: true });
  if (m.result?.exceptionDetails) throw new Error(JSON.stringify(m.result.exceptionDetails).slice(0, 400));
  return m.result?.result?.value;
};

await send('Page.enable');
await send('Emulation.setDeviceMetricsOverride', { width: WIN, height: WIN, deviceScaleFactor: 1, mobile: false });
await send('Emulation.setDefaultBackgroundColorOverride', { color: { r: 0, g: 0, b: 0, a: 0 } });
await send('Page.navigate', { url: pathToFileURL(join(ASSETS, 'host.html')).href });
for (let i = 0; i < 100 && !(await evalJs('!!(window.__rigOut||[]).find(m=>m.type==="ready")')); i++) await sleep(100);
await evalJs(`document.getElementById('stage').style.inset = '10%'`);
// the three faces: face channels only (rive-rig.js REST), held for good
await evalJs(`(RiveRig.add({
  hd_idle: { dur: 1e9, k: {} },
  hd_happy: { dur: 1e9, k: { hap: [[0, 1]], smile: [[0, 1]], open: [[0, 0.55]], ly: [[0, -0.3]], blush: [[0, 0.7]] } },
  hd_sad: { dur: 1e9, k: { frown: [[0, 0.95]], teary: [[0, 1]], sl: [[0, 1]], ly: [[0, 0.55]], earL: [[0, 24]], earR: [[0, 24]] } },
}), true)`);

// In the page, after a mount: hide the limbs (and a separate body), stop blinks and glances, and
// return the head's circle and the eyes in page pixels.
function prepare(key, cut) {
  const I = window.RiveRig._last._I, G = (window.__rgI || {})[key], E = I.E || {};
  const hide = e => { if (e && e.style) e.style.setProperty('display', 'none', 'important'); };
  const LIMBS = new Set(['arm', 'hand', 'foot', 'pad', 'leg', 'tail', 'swing', 'pgFlip']);
  if (G && G.items) G.items.forEach(q => { if (LIMBS.has(q.role) || (q.role === 'side' && q.limb)) { hide(q.e); hide(q.rim); hide(q.gl); } });
  (I.tubes || []).forEach(hide);
  ['tail', 'tailH', 'body', 'pup', 'arms', 'armT'].forEach(k => [].concat(E[k] || []).forEach(hide));
  (E.feet || []).forEach(f => { hide(f.f); hide(f.p); });
  document.querySelectorAll('ellipse[fill="#6a1b9a"]').forEach(hide); // the floor shadow
  I.blinkAt = I.glAt = I.fidAt = Infinity; I.gl = [0, 0];
  let H, eyes;
  if (I.geo && I.geo.headA) { const a = I.geo.headA; H = [a.cx, a.cy, a.hx, a.hy]; eyes = (I.geo.EY || []).map(e => [e.x, e.y]); }
  else { const h = I.D.head; H = [h[0], h[1], h[2], h[3] || h[2]]; eyes = (I.D.eyes || []).map(e => [e[0], e[1]]); }
  if (cut && G && G.items) G.items.forEach(q => { if (['body', 'bsurf', 'bnop', 'patch'].includes(q.role) && q.pet !== 'head' && q.cy > H[1] + H[3] * 0.55) hide(q.e); });
  const svg = document.querySelector('#stage svg'), m = svg.getScreenCTM();
  const px = (x, y) => { const p = svg.createSVGPoint(); p.x = x; p.y = y; const q = p.matrixTransform(m); return [q.x, q.y]; };
  const c = px(H[0], H[1]), e = px(H[0] + H[2], H[1] + H[3]);
  return { head: [c[0], c[1], e[0] - c[0], e[1] - c[1]], eyes: eyes.slice(0, 2).map(([x, y]) => px(x, y)) };
}

// In the page: the three screenshots, cut (cut: head circle × k, band × head width), cropped to
// their common square and scaled to `size`, as webp; plus the eyes in that square.
function finish(shots, head, eyes, cut, band, size) {
  const load = b64 => new Promise(ok => { const im = new Image(); im.onload = () => ok(im); im.src = 'data:image/png;base64,' + b64; });
  return Promise.all(shots.map(load)).then(ims => {
    const W = ims[0].width, Hh = ims[0].height, [cx, cy, rx, ry] = head;
    const cvs = ims.map(im => {
      const c = document.createElement('canvas'); c.width = W; c.height = Hh; const x = c.getContext('2d'); x.drawImage(im, 0, 0);
      if (cut) {
        const mk = document.createElement('canvas'); mk.width = W; mk.height = Hh; const y = mk.getContext('2d');
        if (band) y.fillRect(cx - rx * band, 0, rx * band * 2, cy); else y.fillRect(0, 0, W, cy);
        y.beginPath(); y.ellipse(cx, cy, rx * cut, ry * cut, 0, 0, Math.PI * 2); y.fill();
        x.globalCompositeOperation = 'destination-in'; x.drawImage(mk, 0, 0);
      }
      return c;
    });
    let x0 = W, y0 = Hh, x1 = -1, y1 = -1;
    cvs.forEach(c => { const d = c.getContext('2d').getImageData(0, 0, W, Hh).data;
      for (let y = 0; y < Hh; y++) for (let x = 0; x < W; x++) if (d[(y * W + x) * 4 + 3] > 12) { if (x < x0) x0 = x; if (x > x1) x1 = x; if (y < y0) y0 = y; if (y > y1) y1 = y; } });
    const side = Math.max(x1 - x0, y1 - y0) * 1.03, sx = (x0 + x1) / 2 - side / 2, sy = (y0 + y1) / 2 - side / 2;
    const out = cvs.map(c => { const o = document.createElement('canvas'); o.width = o.height = size; const x = o.getContext('2d');
      x.imageSmoothingQuality = 'high'; x.drawImage(c, sx, sy, side, side, 0, 0, size, size); return o.toDataURL('image/webp', 0.9).split(',')[1]; });
    return { out, eyes: eyes.map(([x, y]) => [Math.round((x - sx) / side * 1000) / 1000, Math.round((y - sy) / side * 1000) / 1000]) };
  });
}

for (const f of readdirSync(OUT)) if (f.endsWith('.webp') && (!args.length || keys.some(k => f.startsWith(k + '-')))) unlinkSync(join(OUT, f));
const done = {};
let bytes = 0;
for (const key of keys) {
  const m = await evalJs(`new Promise(ok => { window.__rigOut = []; rigHost.shuffle(false); rigHost.mount(${JSON.stringify(key)});
    const t0 = performance.now(), wait = () => { const m = window.__rigOut.find(x => x.type === 'mounted' || x.type === 'error');
      if (m) requestAnimationFrame(() => requestAnimationFrame(() => ok(m)));
      else if (performance.now() - t0 > 9000) ok({ type: 'error', message: 'timeout' }); else setTimeout(wait, 20); }; wait(); })`);
  if (!m || m.type !== 'mounted') { console.log('FAILED', key, m && m.message); continue; }
  const geo = await evalJs(`(${prepare})(${JSON.stringify(key)}, ${!!CUT[key]})`);
  const shots = [];
  for (const face of FACES) {
    await evalJs(`(RiveRig._last._pose('hd_${face}', 0), new Promise(r => requestAnimationFrame(() => requestAnimationFrame(r))))`);
    shots.push((await send('Page.captureScreenshot', { format: 'png' })).result.data);
  }
  const r = await evalJs(`(${finish})(${JSON.stringify(shots)}, ${JSON.stringify(geo.head)}, ${JSON.stringify(geo.eyes)}, ${CUT[key] || 0}, ${BAND[key] || 0}, ${SIZE})`);
  FACES.forEach((face, i) => { const buf = Buffer.from(r.out[i], 'base64'); bytes += buf.length; writeFileSync(join(OUT, `${key}-${face}.webp`), buf); });
  done[key] = r.eyes;
  process.stdout.write('.');
}
ws.close(); chrome.kill();

// the index: every head on disk (a partial run keeps the others)
const all = [...new Set(readdirSync(OUT).filter(f => f.endsWith('-idle.webp')).map(f => f.slice(0, -'-idle.webp'.length)))].sort();
const prev = {};
if (existsSync(INDEX)) for (const [, k, v] of readFileSync(INDEX, 'utf8').matchAll(/^ {2}(\w+): (\[\[.*\]\]),$/gm)) prev[k] = JSON.parse(v);
const eyesOf = k => done[k] || prev[k] || [];
const src = `// Generated by tools/rig/heads.mjs: each creature's head alone (no body, arms or feet) in three
// faces, cropped to the same square, and where its two eyes are in it (fractions). Don't edit by hand.

export const EYES = {
${all.map(k => `  ${k}: ${JSON.stringify(eyesOf(k))},`).join('\n')}
};

export default {
${all.map(k => `  ${k}: { ${FACES.map(f => `${f}: require('../../assets/squishdoku/heads/${k}-${f}.webp')`).join(', ')}, eyes: EYES.${k} },`).join('\n')}
};
`;
writeFileSync(INDEX, src);
console.log(`\n${Object.keys(done).length}/${keys.length} heads (${SIZE}px, ${(bytes / 1024).toFixed(0)} KB) -> ${OUT}; index -> ${INDEX}`);
