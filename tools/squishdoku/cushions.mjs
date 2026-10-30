// Squishdoku's board squares as plush cushions (the user's pick, 2026-10-28: the glossy candy
// buttons didn't match the plush creatures' fabric). Each patch colour is one cushion picture, drawn
// on a canvas in headless Chrome: a puffy rounded square shaded light at the upper left to its edge
// colour, the rigs' own fabric grain (tools/rig/host.html fabric(), the same noise at the same
// strength) and a soft shadow under it. (A white stitched seam round each one went, the user's ask.) The gaps between cushions are the quilt's
// seams. Writes assets/squishdoku/cushions/<name>.webp and src/squishdoku/cushions.js, the list
// theme.js serves as PATCHES. FACE is where the cushion sits in its cell: src/squishdoku/Tile.js
// clips the flashes and the mistake's glow to the same shape.
// usage: node tools/squishdoku/cushions.mjs [size=256]
import { spawn } from 'node:child_process';
import { mkdirSync, readdirSync, unlinkSync, writeFileSync } from 'node:fs';
import { join, dirname } from 'node:path';
import { fileURLToPath, pathToFileURL } from 'node:url';
import { tmpdir } from 'node:os';

const ROOT = join(dirname(fileURLToPath(import.meta.url)), '..', '..');
const OUT = join(ROOT, 'assets', 'squishdoku', 'cushions');
const INDEX = join(ROOT, 'src', 'squishdoku', 'cushions.js');
const PORT = 9339;
const SIZE = +(process.argv[2] || 256);
// "Jewel" made velvet: [edge shade, body, light]. Nine clearly different hues (no lines between
// patches: the colours alone tell them apart); warm and cool alternate, since the Rules card and the
// game picker take the first few.
const COLORS = [
  ['magenta', ['#9a2a78', '#d64f9f', '#f39acb']],
  ['sky', ['#1d6fa0', '#3c9fdc', '#94d2f7']],
  ['gold', ['#b07a12', '#e5ad3a', '#fbd88a']],
  ['violet', ['#55309f', '#8460d8', '#bba2f2']],
  ['emerald', ['#1f7650', '#3aa774', '#8ad8ae']],
  ['tangerine', ['#ad5428', '#e2804a', '#f7b892']],
  ['sapphire', ['#29489e', '#4c78da', '#9bb6f5']],
  ['teal', ['#16767c', '#2ba7a6', '#86d8d2']],
  ['ruby', ['#a12d45', '#dc5a6c', '#f5a2ad']],
];
// the cushion in its cell, as fractions of the cell (Tile.js FACE)
const FACE = { left: 0.025, top: 0.025, right: 0.025, bottom: 0.05, radius: 0.24 };

mkdirSync(OUT, { recursive: true });
const chromePath = (await import(pathToFileURL(join(ROOT, 'node_modules', 'chrome-launcher', 'dist', 'chrome-finder.js')).href).catch(() => null))
  ?.win32?.()[0] || 'C:/Program Files/Google/Chrome/Application/chrome.exe';
const chrome = spawn(chromePath, ['--headless=new', '--no-sandbox', `--remote-debugging-port=${PORT}`, `--user-data-dir=${join(tmpdir(), 'sd-cushions-' + process.pid)}`, 'about:blank'], { stdio: 'ignore' });
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

// In the page: one cushion, as webp (base64).
function cushion(S, [edge, body, light], F) {
  // the rigs' fabric grain: two octaves of smooth noise as a black alpha tile (host.html fabric())
  const grain = (() => { const N = 128, cv = document.createElement('canvas'); cv.width = cv.height = N; const x = cv.getContext('2d'), im = x.createImageData(N, N);
    let sd = 7; const rnd = () => (sd = (sd * 16807) % 2147483647) / 2147483647;
    const oct = n => { const g = []; for (let i = 0; i < n * n; i++) g.push(rnd()); const c = N / n, sm = t => t * t * (3 - 2 * t);
      return (px, py) => { const gx = px / c, gy = py / c, x0 = Math.floor(gx), y0 = Math.floor(gy), fx = sm(gx - x0), fy = sm(gy - y0), a = (i, j) => g[((j % n + n) % n) * n + ((i % n + n) % n)];
        const t = a(x0, y0) + (a(x0 + 1, y0) - a(x0, y0)) * fx, b = a(x0, y0 + 1) + (a(x0 + 1, y0 + 1) - a(x0, y0 + 1)) * fx; return t + (b - t) * fy; }; };
    const o1 = oct(32), o2 = oct(64);
    for (let y = 0; y < N; y++) for (let X = 0; X < N; X++) { const v = (o1(X, y) + o2(X, y)) / 2, k = (y * N + X) * 4; im.data[k + 3] = Math.round(0.22 * 255 * v); }
    x.putImageData(im, 0, 0); return cv; })();
  const c = document.createElement('canvas'); c.width = c.height = S; const x = c.getContext('2d');
  const rr = (l, t, w, h, r) => { x.beginPath(); x.roundRect(l, t, w, h, r); };
  const L = F.left * S, T = F.top * S, W = S - L - F.right * S, H = S - T - F.bottom * S, R = F.radius * S;
  // the soft shadow under it
  x.save(); x.filter = `blur(${S * 0.035}px)`; x.globalAlpha = 0.5; x.fillStyle = edge;
  rr(S * 0.03, S * 0.075, S * 0.94, S * 0.9, R); x.fill(); x.restore();
  // the cushion: puffed up, light at the upper left, its edge colour round the rim
  x.save(); rr(L, T, W, H, R); x.clip();
  const g = x.createRadialGradient(L + W * 0.38, T + H * 0.32, 0, L + W * 0.38, T + H * 0.32, W * 0.85);
  g.addColorStop(0, light); g.addColorStop(0.48, body); g.addColorStop(1, edge);
  x.fillStyle = g; x.fillRect(0, 0, S, S);
  // the grain, multiplied in (a tile about 3/4 of the cell, as on the mock the user picked)
  x.globalCompositeOperation = 'multiply'; x.globalAlpha = 0.45;
  const k = (S * 0.76) / 128;
  for (let gy = 0; gy < S; gy += 128 * k) for (let gx = 0; gx < S; gx += 128 * k) x.drawImage(grain, gx, gy, 128 * k, 128 * k);
  x.restore();
  return c.toDataURL('image/webp', 0.9).split(',')[1];
}

for (const f of readdirSync(OUT)) if (f.endsWith('.webp')) unlinkSync(join(OUT, f));
let bytes = 0;
for (const [name, shade] of COLORS) {
  const b64 = await evalJs(`(${cushion})(${SIZE}, ${JSON.stringify(shade)}, ${JSON.stringify(FACE)})`);
  const buf = Buffer.from(b64, 'base64'); bytes += buf.length;
  writeFileSync(join(OUT, `${name}.webp`), buf);
}
ws.close(); chrome.kill();

writeFileSync(INDEX, `// Generated by tools/squishdoku/cushions.mjs: the board's patch colours as plush cushions,
// [edge shade, body, light] and the cushion picture. theme.js serves this as PATCHES. Don't edit by hand.

export const FACE = ${JSON.stringify(FACE)};

export default [
${COLORS.map(([name, shade]) => `  { name: '${name}', shade: ${JSON.stringify(shade).replace(/,/g, ', ')}, src: require('../../assets/squishdoku/cushions/${name}.webp') },`).join('\n')}
];
`);
console.log(`${COLORS.length} cushions (${SIZE}px, ${(bytes / 1024).toFixed(0)} KB) -> ${OUT}; index -> ${INDEX}`);
