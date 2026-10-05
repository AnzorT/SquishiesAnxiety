// Shoots the Crib's map (the design's CRIB MAP in "Squad Crib v5": a house
// cut open to show its rooms, the yard beside it) without what changes —
// the rooms' names, counts and creatures, the "you're here" frame, the close
// button — for the app to draw those over it (src/crib/CribMap.js). Also the
// vertical page's room dock: each room tile's wall and floor (the design's
// DOCK_BG) and the dock's wooden planks (src/crib/RoomTiles.js).
//
//   node tools/crib-art/map.mjs
// Output: assets/crib/map.webp (852×393 at 2×), assets/crib/dock/*@3x.webp.

import { spawn } from 'node:child_process';
import fs from 'node:fs';
import http from 'node:http';
import os from 'node:os';
import path from 'node:path';
import { fileURLToPath } from 'node:url';

const HERE = path.dirname(fileURLToPath(import.meta.url));
const ROOT = path.resolve(HERE, '../..');
const DESIGN = path.resolve(HERE, '../plush-art/design');
const OUT = path.join(ROOT, 'assets/crib/map.webp');
const OUT_DOCK = path.join(ROOT, 'assets/crib/dock');
const PAGE = 'Squad Crib v5.dc.html';
const W = 852;
const H = 393;
const DPR = 2;
const PORT = 9600 + Math.floor(Math.random() * 300);
const CDP_PORT = 9900 + Math.floor(Math.random() * 300);

// ---- serve the design folder, drive headless Chrome ------------------------

const MIME = { '.html': 'text/html', '.js': 'text/javascript', '.svg': 'image/svg+xml', '.png': 'image/png', '.jpg': 'image/jpeg', '.wav': 'audio/wav', '.css': 'text/css' };
const server = http
  .createServer((req, res) => {
    const file = path.join(DESIGN, decodeURIComponent(req.url.split('?')[0]));
    if (!file.startsWith(DESIGN) || !fs.existsSync(file) || fs.statSync(file).isDirectory()) {
      res.writeHead(404);
      res.end();
      return;
    }
    res.writeHead(200, { 'Content-Type': MIME[path.extname(file)] || 'application/octet-stream' });
    fs.createReadStream(file).pipe(res);
  })
  .listen(PORT);

function findChrome() {
  const candidates = [process.env.CHROME_PATH, path.join(os.homedir(), 'AppData/Local/Google/Chrome/Application/chrome.exe'), 'C:/Program Files/Google/Chrome/Application/chrome.exe', '/Applications/Google Chrome.app/Contents/MacOS/Google Chrome', '/usr/bin/google-chrome'].filter(Boolean);
  const hit = candidates.find((p) => fs.existsSync(p));
  if (!hit) throw new Error('Chrome not found — set CHROME_PATH');
  return hit;
}

async function connect() {
  const profile = fs.mkdtempSync(path.join(os.tmpdir(), 'crib-fix-'));
  const chrome = spawn(findChrome(), ['--headless=new', '--no-sandbox', '--hide-scrollbars', `--remote-debugging-port=${CDP_PORT}`, `--user-data-dir=${profile}`, 'about:blank'], { stdio: 'ignore' });
  let target;
  for (let i = 0; i < 50 && !target; i++) {
    await new Promise((r) => setTimeout(r, 200));
    try {
      target = (await (await fetch(`http://127.0.0.1:${CDP_PORT}/json/list`)).json()).find((t) => t.type === 'page');
    } catch {
      // not up yet
    }
  }
  if (!target) throw new Error('Chrome did not start');
  const ws = new WebSocket(target.webSocketDebuggerUrl);
  await new Promise((r) => (ws.onopen = r));
  let id = 0;
  const pending = new Map();
  ws.onmessage = (m) => {
    const d = JSON.parse(m.data);
    if (d.id && pending.has(d.id)) {
      pending.get(d.id)(d);
      pending.delete(d.id);
    }
  };
  const send = (method, params = {}) =>
    new Promise((res, rej) => {
      const i = ++id;
      pending.set(i, (d) => (d.error ? rej(new Error(`${method}: ${d.error.message}`)) : res(d.result)));
      ws.send(JSON.stringify({ id: i, method, params }));
    });
  return { send, close: () => (ws.close(), chrome.kill()) };
}

const evaluate = async (send, expression) => {
  const r = await send('Runtime.evaluate', { expression, awaitPromise: true, returnByValue: true });
  if (r.exceptionDetails) throw new Error(r.exceptionDetails.exception ? r.exceptionDetails.exception.description : r.exceptionDetails.text);
  return r.result.value;
};

// before the page's scripts: a fixed hour, a fresh home, no tutorial, no
// animations, a see-through page
const PRELUDE = (hour) => `
  (() => {
    Date.prototype.getHours = function () { return ${hour}; };
    try {
      localStorage.clear();
      localStorage.setItem('squishHome', JSON.stringify({ own: {}, eq: {}, pads: { A: 'swing', B: null, C: null, D: 'ball' }, padX: {}, padY: {}, pos: {}, stored: {}, th: {}, song: 0, off: {} }));
      localStorage.setItem('squishCribMusic', '0');
    } catch (e) {}
    document.addEventListener('DOMContentLoaded', () => {
      const st = document.createElement('style');
      st.textContent = '*{animation:none!important;transition:none!important} html,body{background:transparent!important}';
      document.head.appendChild(st);
    });
  })()`;

const { send, close } = await connect();
try {
  await send('Page.enable');
  await send('Runtime.enable');
  await send('Emulation.setDeviceMetricsOverride', { width: W + 40, height: H + 40, deviceScaleFactor: DPR, mobile: false });
  await send('Page.addScriptToEvaluateOnNewDocument', { source: PRELUDE(13) });
  await send('Page.navigate', { url: `http://127.0.0.1:${PORT}/${encodeURIComponent(PAGE)}` });
  let ready = false;
  for (let i = 0; i < 100 && !ready; i++) {
    await new Promise((r) => setTimeout(r, 150));
    ready = await evaluate(send, `!!document.querySelector('[data-tut^="cr"]') && !!document.querySelector('[data-tut-root]')`);
  }
  if (!ready) throw new Error('the page did not start');
  // open the map with its HUD button (the green one), then strip it
  const rect = await evaluate(
    send,
    `(async () => {
      const btn = Array.from(document.querySelectorAll('button')).find((b) => /201, 232, 168/.test(b.getAttribute('style') || ''));
      btn.click();
      await new Promise((r) => setTimeout(r, 400));
      const root = document.querySelector('[data-tut-root]');
      // no phone frame around it
      for (let e = root; e && e !== document.body; e = e.parentElement) Object.assign(e.style, { borderRadius: '0', boxShadow: 'none', border: 'none' });
      const map = Array.from(root.querySelectorAll('div')).find((d) => /z-index: 30;/.test(d.getAttribute('style') || '') && /159, 216, 240/.test(d.getAttribute('style') || ''));
      map.querySelectorAll('button > span, button img, button > div[style*="z-index: 2"]').forEach((e) => (e.style.visibility = 'hidden'));
      Array.from(map.children).filter((e) => e.tagName === 'BUTTON' && !e.querySelector('div')).forEach((b) => (b.style.visibility = 'hidden'));
      const r = map.getBoundingClientRect();
      return { x: r.left, y: r.top, w: r.width, h: r.height };
    })()`
  );
  await new Promise((r) => setTimeout(r, 300));
  const shot = await send('Page.captureScreenshot', { format: 'webp', quality: 92, clip: { x: rect.x, y: rect.y, width: W, height: H, scale: 1 } });
  fs.writeFileSync(OUT, Buffer.from(shot.data, 'base64'));
  console.log('wrote', OUT, rect);

  // ---- the dock: the tiles' wall + floor (the floor 44px tall, under a
  // 2.5px line), wider than any tile so each shows its left part; the planks
  const vert = fs.readFileSync(path.join(DESIGN, 'Squad Crib Vertical.dc.html'), 'utf8');
  const DOCK_BG = new Function(`return ${vert.match(/const DOCK_BG = (\{.*\});/)[1]}`)();
  const WOOD = vert.match(/background:(linear-gradient\(180deg,rgba\(60,30,10,0\.25\)[^;]*?)(;|")/)[1];
  fs.mkdirSync(OUT_DOCK, { recursive: true });
  await send('Emulation.setDeviceMetricsOverride', { width: 500, height: 500, deviceScaleFactor: 3, mobile: false });
  await send('Page.navigate', { url: 'about:blank' });
  await new Promise((r) => setTimeout(r, 300));
  const paint = async (html, w, h, file) => {
    await evaluate(send, `(() => { document.body.style.margin = '0'; document.body.innerHTML = ${JSON.stringify(html)}; return true; })()`);
    await new Promise((r) => setTimeout(r, 80));
    const shot = await send('Page.captureScreenshot', { format: 'webp', quality: 92, clip: { x: 0, y: 0, width: w, height: h, scale: 1 } });
    fs.writeFileSync(path.join(OUT_DOCK, file), Buffer.from(shot.data, 'base64'));
  };
  for (const [room, [wall, floor]] of Object.entries(DOCK_BG)) {
    await paint(`<div style="position:relative;width:400px;height:118px;background:${wall}"><div style="position:absolute;left:0;right:0;bottom:0;height:44px;border-top:2.5px solid #5b3a29;background:${floor}"></div></div>`, 400, 118, `${room}@3x.webp`);
  }
  // the planks repeat every 240 × 30 px
  await paint(`<div style="width:480px;height:360px;background:${WOOD.replace(/^linear-gradient\(180deg,rgba\(60,30,10,0\.25\),rgba\(60,30,10,0\) 24px\),\s*/, '')}"></div>`, 480, 360, 'wood@3x.webp');
  console.log('wrote the dock tiles');
} finally {
  close();
  server.close();
}
