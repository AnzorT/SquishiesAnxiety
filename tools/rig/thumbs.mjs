// Renders a still of every rig creature (idle pose, transparent background) with the same host page
// the app's WebView uses, for grids, cards and reveal stills.
// usage: node tools/rig/build.mjs && node tools/rig/thumbs.mjs [size=512] [key ...]
// Writes tools/rig/out/thumbs/<key>.webp and tools/rig/out/contact.png (all of them on one sheet).
import { spawn } from 'node:child_process';
import { mkdirSync, readdirSync, writeFileSync, existsSync } from 'node:fs';
import { join, dirname } from 'node:path';
import { fileURLToPath, pathToFileURL } from 'node:url';
import { tmpdir } from 'node:os';

const ROOT = join(dirname(fileURLToPath(import.meta.url)), '..', '..');
const ASSETS = join(ROOT, 'android', 'app', 'src', 'main', 'assets', 'rig');
const OUT = join(ROOT, 'tools', 'rig', 'out');
const PORT = 9335;
const args = process.argv.slice(2);
const SIZE = /^\d+$/.test(args[0] || '') ? +args.shift() : 512;
const MARGIN = 0.06; // of the image, on every side
if (!existsSync(join(ASSETS, 'host.html'))) throw new Error('run node tools/rig/build.mjs first');
const keys = args.length ? args : readdirSync(join(ASSETS, 'export', 'tripo')).sort();
mkdirSync(join(OUT, 'thumbs'), { recursive: true });

const chromePath = (await import(pathToFileURL(join(ROOT, 'node_modules', 'chrome-launcher', 'dist', 'chrome-finder.js')).href).catch(() => null))
  ?.win32?.()[0] || 'C:/Program Files/Google/Chrome/Application/chrome.exe';
const profile = join(tmpdir(), 'rig-thumbs-' + process.pid);
const chrome = spawn(chromePath, ['--headless=new', '--no-sandbox', '--allow-file-access-from-files', '--hide-scrollbars',
  `--remote-debugging-port=${PORT}`, `--window-size=${SIZE},${SIZE}`, `--user-data-dir=${profile}`, 'about:blank'], { stdio: 'ignore' });
const sleep = ms => new Promise(r => setTimeout(r, ms));
let page;
for (let i = 0; i < 50 && !page; i++) { await sleep(200); try { page = (await (await fetch(`http://127.0.0.1:${PORT}/json/list`)).json()).find(t => t.type === 'page'); } catch (e) {} }
if (!page) { chrome.kill(); throw new Error('Chrome did not start'); }

const ws = new WebSocket(page.webSocketDebuggerUrl);
await new Promise(r => ws.addEventListener('open', r));
let id = 0; const pend = new Map();
ws.addEventListener('message', e => { const m = JSON.parse(e.data); if (m.id && pend.has(m.id)) { pend.get(m.id)(m); pend.delete(m.id); } });
const send = (method, params = {}) => new Promise(r => { const i = ++id; pend.set(i, r); ws.send(JSON.stringify({ id: i, method, params })); });
const evalJs = async js => (await send('Runtime.evaluate', { expression: js, returnByValue: true, awaitPromise: true })).result?.result?.value;

await send('Page.enable');
await send('Emulation.setDeviceMetricsOverride', { width: SIZE, height: SIZE, deviceScaleFactor: 1, mobile: false });
await send('Emulation.setDefaultBackgroundColorOverride', { color: { r: 0, g: 0, b: 0, a: 0 } });
await send('Page.navigate', { url: pathToFileURL(join(ASSETS, 'host.html')).href });
for (let i = 0; i < 100 && !(await evalJs('!!(window.__rigOut||[]).find(m=>m.type==="ready")')); i++) await sleep(100);
// A margin around the stage: ears, crowns and hats (Avo, Cakey, Acorn) reach the stage's top edge.
await evalJs(`document.getElementById('stage').style.inset = '${MARGIN * 100}%'`);

const done = [];
for (const key of keys) {
  // Fresh mount, shuffle off, idle pose at t=0 (the first blink is 1.5 s away), then two frames to paint.
  const r = await evalJs(`new Promise(ok => { window.__rigOut = []; rigHost.shuffle(false); rigHost.mount(${JSON.stringify(key)});
    const t0 = performance.now(), wait = () => { const m = window.__rigOut.find(x => x.type === 'mounted' || x.type === 'error');
      if (m) { const c = window.RiveRig._last; if (c && c._pose) c._pose('idle', 0); requestAnimationFrame(() => requestAnimationFrame(() => ok(m))); }
      else if (performance.now() - t0 > 9000) ok({ type: 'error', message: 'timeout' }); else setTimeout(wait, 20); }; wait(); })`);
  if (!r || r.type !== 'mounted') { console.log('FAILED', key, r && r.message); continue; }
  const shot = await send('Page.captureScreenshot', { format: 'webp', quality: 92 });
  writeFileSync(join(OUT, 'thumbs', key + '.webp'), Buffer.from(shot.result.data, 'base64'));
  done.push(key); process.stdout.write('.');
}
console.log(`\n${done.length}/${keys.length} thumbnails (${SIZE}px) -> ${join(OUT, 'thumbs')}`);

// Contact sheet: every thumbnail with its key, on a checkerboard so transparency and clipping show.
const cols = 10, cell = 128;
const html = `<body style="margin:0;background:#fff;font:11px sans-serif"><div style="display:grid;grid-template-columns:repeat(${cols},${cell}px)">${done.map(k =>
  `<div style="width:${cell}px;height:${cell + 14}px;text-align:center;background:repeating-conic-gradient(#eee 0 25%,#fff 0 50%) 0 0/16px 16px"><img src="thumbs/${k}.webp" style="width:${cell}px;height:${cell}px;display:block">${k}</div>`).join('')}</div></body>`;
writeFileSync(join(OUT, 'contact.html'), html);
const rows = Math.ceil(done.length / cols);
await send('Emulation.setDeviceMetricsOverride', { width: cols * cell, height: rows * (cell + 14), deviceScaleFactor: 1, mobile: false });
await send('Page.navigate', { url: pathToFileURL(join(OUT, 'contact.html')).href });
await sleep(1500);
const sheet = await send('Page.captureScreenshot', { format: 'png' });
writeFileSync(join(OUT, 'contact.png'), Buffer.from(sheet.result.data, 'base64'));
console.log('contact sheet ->', join(OUT, 'contact.png'));
ws.close(); chrome.kill();
