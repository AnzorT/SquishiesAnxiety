// Renders the Crib's rooms from the design's own page ("Squad Crib
// v5.dc.html"), run for real in headless Chrome: each room is painted in CSS
// (hundreds of styled divs, gradients and box-shadows) that React Native
// can't draw, so the page is loaded with a fresh home and screenshotted at
// 2×, with everything the app draws itself left out (creatures, furniture,
// decor, the yard's games, the dance floor, the HUD, the night).
//
// A room comes out in layers, so the app can slide a wall or floor theme
// (the design's th.wall / th.floor / th.ceil, which sit right on top of the
// room's own wall and floor) in between:
//   under  what's behind the wall and floor (only the yard: sky, hills,
//          tree, fence) — per time of day
//   base   the room's own wall and floor — one per room
//   over   everything on top of them (shelves, windows, rugs, trim…), with
//          see-through holes where the wall and floor show — per time of day
//   front  what the design draws in front of the creatures (the kitchen's
//          snack table)
// Rooms whose look follows the time of day (a window, the sky) are shot once
// per phase. Every theme is rendered to its own image at the size of the
// wall / floor / ceiling it covers. A check composites the layers back
// together and compares them with the room shot whole.
//
//   node tools/crib-art/render.mjs            every room, the themes, roomArt.js
//   node tools/crib-art/render.mjs living     one room (and the themes)
// Output: assets/crib/rooms/*.webp, assets/crib/themes/*.webp and
// src/crib/roomArt.js (the require map). The design folder is
// tools/plush-art/design (extract the zip there first).

import { spawn } from 'node:child_process';
import fs from 'node:fs';
import http from 'node:http';
import os from 'node:os';
import path from 'node:path';
import { fileURLToPath } from 'node:url';
import vm from 'node:vm';

const HERE = path.dirname(fileURLToPath(import.meta.url));
const ROOT = path.resolve(HERE, '../..');
const DESIGN = path.resolve(HERE, '../plush-art/design');
const OUT_ROOMS = path.join(ROOT, 'assets/crib/rooms');
const OUT_THEMES = path.join(ROOT, 'assets/crib/themes');
const OUT_JS = path.join(ROOT, 'src/crib/roomArt.js');
const CHECK = path.join(HERE, 'out');
const PAGE = 'Squad Crib v5.dc.html';
const W = 852;
const H = 393;
const DPR = 2;
const QUALITY = 90;
const PORT = 9600 + Math.floor(Math.random() * 300);
const CDP_PORT = 9900 + Math.floor(Math.random() * 300);

// which rooms change with the time of day (the others are shot at 'day')
const PHASED = new Set(['living', 'kitchen', 'bed', 'yard']);
const PHASES = { morning: 8, day: 13, evening: 18, night: 23 }; // an hour in each
const ROOMS = ['living', 'kitchen', 'bath', 'bed', 'dance', 'hatch', 'yard'];
// where each room's wall ends and floor starts (the design's markup)
const WALL_H = { living: 200, kitchen: 236, bath: 236, bed: 212, dance: 200 };
const FLOOR_TOP = { living: 200, kitchen: 236, bath: 236, bed: 212, dance: 200, yard: 214 };
const CEIL_H = 16;
const CEIL_EDGE = 3; // the ceiling's 2.5px box-shadow below it

// ---- serve the design folder ---------------------------------------------

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

// ---- headless Chrome over CDP ------------------------------------------------

function findChrome() {
  const candidates = [process.env.CHROME_PATH, path.join(os.homedir(), 'AppData/Local/Google/Chrome/Application/chrome.exe'), 'C:/Program Files/Google/Chrome/Application/chrome.exe', '/Applications/Google Chrome.app/Contents/MacOS/Google Chrome', '/usr/bin/google-chrome'].filter(Boolean);
  const hit = candidates.find((p) => fs.existsSync(p));
  if (!hit) throw new Error('Chrome not found — set CHROME_PATH');
  return hit;
}

async function connect() {
  const profile = fs.mkdtempSync(path.join(os.tmpdir(), 'crib-art-'));
  const chrome = spawn(findChrome(), ['--headless=new', '--no-sandbox', '--hide-scrollbars', '--autoplay-policy=no-user-gesture-required', `--remote-debugging-port=${CDP_PORT}`, `--user-data-dir=${profile}`, 'about:blank'], { stdio: 'ignore' });
  let target;
  for (let i = 0; i < 50 && !target; i++) {
    await new Promise((r) => setTimeout(r, 200));
    try {
      const list = await (await fetch(`http://127.0.0.1:${CDP_PORT}/json/list`)).json();
      target = list.find((t) => t.type === 'page');
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
  const close = () => {
    ws.close();
    chrome.kill();
  };
  return { send, close };
}

const evaluate = async (send, expression) => {
  const r = await send('Runtime.evaluate', { expression, awaitPromise: true, returnByValue: true });
  if (r.exceptionDetails) throw new Error(r.exceptionDetails.exception ? r.exceptionDetails.exception.description : r.exceptionDetails.text);
  return r.result.value;
};

// Before the page's own scripts run: a fixed hour for the phase, the fresh
// home (every slot at tier 0, the starter swing and ball field on their
// pads — the sim needs a yard spot for its yard creatures; their DOM is left
// out of the shots), no profile (so no tutorial), and no animations.
const PRELUDE = (hour) => `
  (() => {
    const h = ${hour};
    Date.prototype.getHours = function () { return h; };
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

// In the page: sort the room's elements into the layers and show one of
// them. The room's elements are the children of the scene's first layer;
// the wall / floor and their theme overlays are found by their geometry.
const LAYERS = (room, mode) => `
  (() => {
    const root = document.querySelector('[data-tut-root]');
    if (!root) return 'no root';
    root.style.background = 'transparent';
    root.style.boxShadow = 'none';
    root.style.borderRadius = '0';
    const wallH = ${WALL_H[room] || 0}, floorTop = ${FLOOR_TOP[room] || 0};
    const kids = Array.from(root.children[0].children);
    const st = (e) => e.getAttribute('style') || '';
    const isBase = (e) => {
      const s = st(e);
      if (wallH && (s.startsWith('position: absolute; left: 0px; right: 0px; top: 0px; height: ' + wallH + 'px;') || s.startsWith('position: absolute; left: 0px; right: 0px; top: 0px; height: ${CEIL_H}px;'))) return true;
      return !!floorTop && s.startsWith('position: absolute; inset: ' + floorTop + 'px 0px 0px;');
    };
    // drawn by the app: the yard's games, the dance floor and its lights
    const isApp = (e) => {
      const s = st(e);
      if ('${room}' === 'yard') return /^position: absolute; inset: 0px; transform: translate/.test(s);
      if ('${room}' === 'dance') return /top: 210px;/.test(s) && /height: 172px;/.test(s);
      return false;
    };
    const first = kids.findIndex(isBase);
    const layerOf = (e, i) => (isApp(e) ? 'app' : isBase(e) ? 'base' : first < 0 || i < first ? 'under' : 'over');
    const mode = '${mode}';
    const shown = { under: ['under'], base: ['base'], over: ['over'], full: ['under', 'base', 'over'], front: [] }[mode];
    // the base layer is only the room's own wall and floor (not the theme
    // overlays: those are rendered on their own)
    const counts = {};
    kids.forEach((e, i) => {
      const l = layerOf(e, i);
      let show = shown.includes(l);
      if (l === 'base') {
        const key = st(e).slice(0, 70);
        counts[key] = (counts[key] || 0) + 1;
        if (counts[key] > 1) show = false;
      }
      e.style.visibility = show ? 'visible' : 'hidden';
    });
    root.children[0].style.visibility = mode === 'front' ? 'hidden' : 'visible';
    // the other layers of the page: only the front one (minus the
    // furniture pictures and the TV's glow), and only for 'front'
    Array.from(root.children).forEach((c, i) => {
      if (i === 0) return;
      const front = /z-index: 3;/.test(st(c)) && !c.querySelector('[data-tut]');
      c.style.visibility = mode === 'front' && front ? 'visible' : 'hidden';
      if (front) {
        c.querySelectorAll('img').forEach((img) => img.remove());
        Array.from(c.children).forEach((d) => { if (/opacity: 0;/.test(st(d))) d.remove(); });
      }
    });
    const has = { under: kids.some((e, i) => layerOf(e, i) === 'under'), base: first >= 0, over: kids.some((e, i) => layerOf(e, i) === 'over'), front: false };
    const fr = Array.from(root.children).find((c) => /z-index: 3;/.test(st(c)) && !c.querySelector('[data-tut]'));
    has.front = !!fr && Array.from(fr.querySelectorAll('*')).some((d) => d.getBoundingClientRect().width > 0 && getComputedStyle(d).visibility !== 'hidden');
    const r = root.getBoundingClientRect();
    return { x: r.left, y: r.top, w: r.width, h: r.height, has };
  })()`;

// ---- render ------------------------------------------------------------------

const only = process.argv.slice(2);
const todo = only.length ? ROOMS.filter((r) => only.includes(r)) : ROOMS;
fs.mkdirSync(OUT_ROOMS, { recursive: true });
fs.mkdirSync(OUT_THEMES, { recursive: true });
fs.mkdirSync(CHECK, { recursive: true });
const manifestPath = path.join(CHECK, 'rooms.json');
const manifest = fs.existsSync(manifestPath) ? JSON.parse(fs.readFileSync(manifestPath, 'utf8')) : {};

const { send, close } = await connect();
const shoot = async (rect, file, format = 'webp') => {
  const shot = await send('Page.captureScreenshot', { format, quality: format === 'webp' ? QUALITY : undefined, clip: { x: rect.x, y: rect.y, width: rect.w, height: rect.h, scale: 1 } });
  fs.writeFileSync(file, Buffer.from(shot.data, 'base64'));
};

try {
  await send('Page.enable');
  await send('Runtime.enable');
  await send('Emulation.setDeviceMetricsOverride', { width: W + 40, height: H + 40, deviceScaleFactor: DPR, mobile: false });
  await send('Emulation.setDefaultBackgroundColorOverride', { color: { r: 0, g: 0, b: 0, a: 0 } });

  for (const room of todo) {
    const phases = PHASED.has(room) ? Object.keys(PHASES) : ['day'];
    const M = (manifest[room] = { under: {}, over: {}, base: null, front: null });
    for (const phase of phases) {
      const { identifier } = await send('Page.addScriptToEvaluateOnNewDocument', { source: PRELUDE(PHASES[phase]) });
      await send('Page.navigate', { url: `http://127.0.0.1:${PORT}/${encodeURIComponent(PAGE)}?room=${room}` });
      // the scene is up once a creature wrapper exists (the sim has started)
      let ready = false;
      for (let i = 0; i < 100 && !ready; i++) {
        await new Promise((r) => setTimeout(r, 150));
        ready = await evaluate(send, `!!document.querySelector('[data-tut^="cr"]') && !!document.querySelector('[data-tut-root]')`);
      }
      if (!ready) throw new Error(`${room}: the page did not start`);
      await new Promise((r) => setTimeout(r, 400));
      const first = phase === phases[0];
      for (const mode of ['full', 'under', 'base', 'over', 'front']) {
        if ((mode === 'base' || mode === 'front') && !first) continue;
        const rect = await evaluate(send, LAYERS(room, mode));
        if (!rect || !rect.w) throw new Error(`${room}: ${JSON.stringify(rect)}`);
        if (mode !== 'full' && !rect.has[mode]) continue;
        await new Promise((r) => setTimeout(r, 120));
        if (mode === 'full') {
          await shoot(rect, path.join(CHECK, `${room}-${phase}-full.png`), 'png');
          continue;
        }
        const name = mode === 'base' || mode === 'front' ? `${room}-${mode}.webp` : `${room}-${mode}-${phase}.webp`;
        await shoot(rect, path.join(OUT_ROOMS, name));
        if (mode === 'base' || mode === 'front') M[mode] = name;
        else M[mode][phase] = name;
      }
      await send('Page.removeScriptToEvaluateOnNewDocument', { identifier });
      process.stdout.write(`${room}/${phase} `);
    }
  }
  fs.writeFileSync(manifestPath, JSON.stringify(manifest, null, 1));
  console.log();

  // ---- the themes -----------------------------------------------------------
  // Read straight from crib-home.js (its THEMES table) and painted on a blank
  // page at the size of what they cover, like the design's overlay divs.
  let themes = null;
  {
    const ctx = { window: { addEventListener() {}, dispatchEvent() {} }, localStorage: { getItem: () => null, setItem() {} }, encodeURIComponent, decodeURIComponent, Math, Array, Object, JSON, String, Number };
    ctx.window.localStorage = ctx.localStorage;
    vm.createContext(ctx);
    vm.runInContext(fs.readFileSync(path.join(DESIGN, 'crib-home.js'), 'utf8'), ctx);
    const T = ctx.window.SquishHome.THEMES;
    const sizeOf = (room, kind) => (kind === 'wall' ? WALL_H[room] : kind === 'floor' ? H - FLOOR_TOP[room] : CEIL_H + CEIL_EDGE);
    // the design's floor overlay adds its shadow under the wall
    const cssOf = (kind, css) => (kind === 'floor' ? `linear-gradient(180deg,rgba(60,30,10,0.2),rgba(60,30,10,0) 28%), ${css}` : css);
    await send('Page.navigate', { url: 'about:blank' });
    await new Promise((r) => setTimeout(r, 300));
    themes = {};
    const done = new Map(); // css|height → file
    for (const room of Object.keys(T)) {
      themes[room] = {};
      for (const kind of Object.keys(T[room])) {
        const h = sizeOf(room, kind);
        themes[room][kind] = T[room][kind].map(([name, css, lvl], i) => {
          if (!css) return { name, lvl, file: null };
          const key = `${kind}|${css}|${h}`;
          if (!done.has(key)) done.set(key, { file: `${kind}-${h}-${done.size}.webp`, kind, css, h });
          return { name, lvl, file: done.get(key).file };
        });
      }
    }
    for (const { file, kind, css, h } of done.values()) {
      const inner = kind === 'ceil' ? `<div style="position:absolute;left:0;top:0;width:${W}px;height:${CEIL_H}px;background:${css};box-shadow:0 2.5px 0 #5b3a29"></div>` : `<div style="position:absolute;left:0;top:0;width:${W}px;height:${h}px;background:${cssOf(kind, css)}"></div>`;
      await evaluate(send, `(() => { document.documentElement.style.background = 'transparent'; document.body.style.margin = '0'; document.body.style.background = 'transparent'; document.body.innerHTML = ${JSON.stringify(`<div style="position:relative;width:${W}px;height:${h}px;overflow:hidden">${inner}</div>`)}; return true; })()`);
      await new Promise((r) => setTimeout(r, 60));
      await shoot({ x: 0, y: 0, w: W, h }, path.join(OUT_THEMES, file));
    }
    console.log(`${done.size} theme images`);
  }

  // ---- the require map --------------------------------------------------------
  // from what's in assets/crib/rooms (so one room's render keeps the others)
  const files = fs.readdirSync(OUT_ROOMS).filter((f) => f.endsWith('.webp'));
  const scanned = {};
  files.forEach((f) => {
    const m = f.match(/^([a-z]+)-(under|over|base|front)(?:-([a-z]+))?\.webp$/);
    if (!m) return;
    const [, room, layer, phase] = m;
    const r = (scanned[room] = scanned[room] || { under: {}, over: {}, base: null, front: null });
    if (phase) r[layer][phase] = f;
    else r[layer] = f;
  });
  const req = (dir, f) => (f ? `require('../../assets/crib/${dir}/${f}')` : 'null');
  const phasesJs = (o) => `{ ${Object.entries(o).map(([p, f]) => `${p}: ${req('rooms', f)}`).join(', ')} }`;
  const lines = [];
  lines.push(`// Generated by tools/crib-art/render.mjs — don't edit.`);
  lines.push(`// The Crib's room layers (under / base / over per time of day, front) and`);
  lines.push(`// the wall / floor / ceiling themes, rendered from the design's CSS.`);
  lines.push(`export const WALL_H = ${JSON.stringify(WALL_H)};`);
  lines.push(`export const FLOOR_TOP = ${JSON.stringify(FLOOR_TOP)};`);
  lines.push(`export const CEIL_H = ${CEIL_H + CEIL_EDGE};`);
  lines.push(`export const ROOM_ART = {`);
  for (const room of ROOMS) {
    const m = scanned[room];
    if (!m) continue;
    lines.push(`  ${room}: { under: ${phasesJs(m.under)}, base: ${req('rooms', m.base)}, over: ${phasesJs(m.over)}, front: ${req('rooms', m.front)} },`);
  }
  lines.push(`};`);
  lines.push(`export const THEMES = {`);
  for (const [room, kinds] of Object.entries(themes || {})) {
    lines.push(`  ${room}: {`);
    for (const [kind, list] of Object.entries(kinds)) lines.push(`    ${kind}: [${list.map((t) => `{ name: ${JSON.stringify(t.name)}, lvl: ${t.lvl}, img: ${req('themes', t.file)} }`).join(', ')}],`);
    lines.push(`  },`);
  }
  lines.push(`};`);
  fs.writeFileSync(OUT_JS, lines.join('\n') + '\n');
  console.log('wrote', OUT_JS);
} finally {
  close();
  server.close();
}
