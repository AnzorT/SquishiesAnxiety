// Cuts the Crib rooms' built-in fixtures out of the design's page ("Squad
// Crib v5.dc.html") so the app can sell them and let the player move them:
// render.mjs shoots a room's "over" layer as one picture (bookshelf, windows,
// clock, oven, neon signs… all baked in), which made every room look
// finished from the start. Here each fixture is shot on its own — only its
// elements visible, clipped to their box — and so is each room's wall trim
// (wainscoting, tile bands, baseboards: it goes with the room's own
// wallpaper, so it's drawn only with that wall style). The kitchen's snack
// table (render.mjs's "front" layer) becomes a picture too: a tier of the
// kitchen's new table slot.
//
// Windows look out on the time of day, so they're shot once per phase.
//
//   node tools/crib-art/fixtures.mjs
// Output: assets/crib/fixtures/*.webp, src/crib/fixtureGeo.js (where each
// one sits — plain data, so the Crib's rules run in Node) and
// src/crib/fixtureArt.js (the pictures, by the same `room.key` names). The
// design folder is tools/plush-art/design.

import { spawn } from 'node:child_process';
import fs from 'node:fs';
import http from 'node:http';
import os from 'node:os';
import path from 'node:path';
import { fileURLToPath } from 'node:url';

const HERE = path.dirname(fileURLToPath(import.meta.url));
const ROOT = path.resolve(HERE, '../..');
const DESIGN = path.resolve(HERE, '../plush-art/design');
const OUT = path.join(ROOT, 'assets/crib/fixtures');
const OUT_JS = path.join(ROOT, 'src/crib/fixtureArt.js');
const OUT_GEO = path.join(ROOT, 'src/crib/fixtureGeo.js');
const PAGE = 'Squad Crib v5.dc.html';
const W = 852;
const H = 393;
const DPR = 2;
const QUALITY = 90;
const MARGIN = 6; // room for box-shadows around a fixture
const PORT = 9600 + Math.floor(Math.random() * 300);
const CDP_PORT = 9900 + Math.floor(Math.random() * 300);
const PHASES = { morning: 8, day: 13, evening: 18, night: 23 };

// Each room's fixtures by the index of their elements among the room
// layer's children (the order of the design's markup: the room's wall and
// floor come first, then what's drawn over them); `phased` ones change with
// the time of day. `trim` is the room's wall trim.
const ROOMS = {
  living: {
    trim: [3, 4, 7],
    fixtures: {
      bunting: [8],
      bookshelf: [9, 10],
      painting: [11],
      mirror: [12],
      window: { els: [13, 14, 15, 16, 17], phased: true },
      clock: [18],
      dresser: [19],
      lamp: [20],
      vase: [21],
      rug: [22],
    },
  },
  kitchen: {
    trim: [3, 6],
    fixtures: { cabinet: [7, 8, 9, 10, 11], window: { els: [12, 13], phased: true }, potrack: [14, 15], oven: [16, 17, 18] },
    front: 'table',
  },
  bath: {
    trim: [3, 4, 7],
    fixtures: { curtain: [8, 9], mirror: [10], towel: [11, 12], shelf: [13, 14, 15, 16, 17] },
  },
  bed: {
    trim: [5],
    fixtures: { window: { els: [6, 7, 8, 9], phased: true }, fairy: [10], sign: [11, 12, 13], moon: [14] },
  },
  dance: {
    trim: [3, 4, 7],
    fixtures: { partylights: [8], neonDance: [9], neonParty: [10] },
  },
};

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

// In the page: show only these elements of the room layer (or only the
// front layer) and return their box in the scene.
const SHOW = (els, front) => `
  (() => {
    const root = document.querySelector('[data-tut-root]');
    root.style.background = 'transparent';
    root.style.boxShadow = 'none';
    root.style.borderRadius = '0';
    const show = new Set(${JSON.stringify(els || [])});
    const st = (e) => e.getAttribute('style') || '';
    const kids = Array.from(root.children[0].children);
    kids.forEach((e, i) => (e.style.visibility = show.has(i) ? 'visible' : 'hidden'));
    root.children[0].style.visibility = ${front ? "'hidden'" : "'visible'"};
    let fr = null;
    Array.from(root.children).forEach((c, i) => {
      if (i === 0) return;
      const isFront = /z-index: 3;/.test(st(c)) && !c.querySelector('[data-tut]');
      if (isFront) {
        fr = c;
        c.querySelectorAll('img').forEach((img) => img.remove());
        Array.from(c.children).forEach((d) => { if (/opacity: 0;/.test(st(d))) d.remove(); });
      }
      c.style.visibility = ${front ? 'isFront' : 'false'} ? 'visible' : 'hidden';
    });
    const R = root.getBoundingClientRect();
    const els = ${front ? '(fr ? Array.from(fr.querySelectorAll("*")) : [])' : 'kids.filter((e, i) => show.has(i))'};
    const boxes = els.map((e) => e.getBoundingClientRect()).filter((r) => r.width > 0 && r.height > 0);
    if (!boxes.length) return null;
    const x0 = Math.min(...boxes.map((r) => r.left)) - R.left, y0 = Math.min(...boxes.map((r) => r.top)) - R.top;
    const x1 = Math.max(...boxes.map((r) => r.right)) - R.left, y1 = Math.max(...boxes.map((r) => r.bottom)) - R.top;
    return { ox: R.left, oy: R.top, x: x0, y: y0, w: x1 - x0, h: y1 - y0 };
  })()`;

// ---- shoot ----------------------------------------------------------------------

fs.mkdirSync(OUT, { recursive: true });
fs.readdirSync(OUT).forEach((f) => f.endsWith('.webp') && fs.unlinkSync(path.join(OUT, f)));
const { send, close } = await connect();
const art = {}; // room → { trim, fixtures: { key: { x, y, w, h, img | phases } }, front }
const shoot = async (box, file) => {
  // a little extra around the box, kept inside the scene
  const x = Math.max(0, Math.floor(box.x - MARGIN));
  const y = Math.max(0, Math.floor(box.y - MARGIN));
  const w = Math.min(W, Math.ceil(box.x + box.w + MARGIN)) - x;
  const h = Math.min(H, Math.ceil(box.y + box.h + MARGIN)) - y;
  const shot = await send('Page.captureScreenshot', { format: 'webp', quality: QUALITY, clip: { x: box.ox + x, y: box.oy + y, width: w, height: h, scale: 1 } });
  fs.writeFileSync(path.join(OUT, file), Buffer.from(shot.data, 'base64'));
  return { x, y, w, h };
};

try {
  await send('Page.enable');
  await send('Runtime.enable');
  await send('Emulation.setDeviceMetricsOverride', { width: W + 40, height: H + 40, deviceScaleFactor: DPR, mobile: false });
  await send('Emulation.setDefaultBackgroundColorOverride', { color: { r: 0, g: 0, b: 0, a: 0 } });
  for (const [room, spec] of Object.entries(ROOMS)) {
    const A = (art[room] = { trim: null, fixtures: {}, front: null });
    const anyPhased = Object.values(spec.fixtures).some((f) => f.phased);
    for (const phase of anyPhased ? Object.keys(PHASES) : ['day']) {
      const { identifier } = await send('Page.addScriptToEvaluateOnNewDocument', { source: PRELUDE(PHASES[phase]) });
      await send('Page.navigate', { url: `http://127.0.0.1:${PORT}/${encodeURIComponent(PAGE)}?room=${room}` });
      let ready = false;
      for (let i = 0; i < 100 && !ready; i++) {
        await new Promise((r) => setTimeout(r, 150));
        ready = await evaluate(send, `!!document.querySelector('[data-tut^="cr"]') && !!document.querySelector('[data-tut-root]')`);
      }
      if (!ready) throw new Error(`${room}: the page did not start`);
      await new Promise((r) => setTimeout(r, 400));
      const day = phase === 'day';
      const jobs = [];
      if (day) jobs.push(['trim', spec.trim, false]);
      Object.entries(spec.fixtures).forEach(([key, f]) => {
        const phased = !Array.isArray(f) && f.phased;
        if (phased || day) jobs.push([key, Array.isArray(f) ? f : f.els, phased]);
      });
      if (day && spec.front) jobs.push([spec.front, null, false, true]);
      for (const [key, els, phased, front] of jobs) {
        const box = await evaluate(send, SHOW(els, front));
        if (!box) throw new Error(`${room}/${key}: nothing to shoot`);
        await new Promise((r) => setTimeout(r, 100));
        const file = `${room}-${key}${phased ? `-${phase}` : ''}.webp`;
        const g = await shoot(box, file);
        if (key === 'trim') A.trim = { ...g, file };
        else if (front) A.front = { key, ...g, file };
        else if (phased) A.fixtures[key] = { ...(A.fixtures[key] || g), phases: { ...((A.fixtures[key] || {}).phases || {}), [phase]: file } };
        else A.fixtures[key] = { ...g, file };
      }
      await send('Page.removeScriptToEvaluateOnNewDocument', { identifier });
      process.stdout.write(`${room}/${phase} `);
    }
  }
  console.log();

  const req = (f) => `require('../../assets/crib/fixtures/${f}')`;
  const geo = {};
  const pics = [];
  for (const [room, A] of Object.entries(art)) {
    const g = (geo[room] = { trim: null, fixtures: {} });
    const box = ({ x, y, w, h }) => ({ x, y, w, h });
    g.trim = box(A.trim);
    pics.push(`  '${room}.trim': ${req(A.trim.file)},`);
    for (const [key, f] of Object.entries(A.fixtures)) {
      g.fixtures[key] = box(f);
      pics.push(f.phases ? `  '${room}.${key}': { ${Object.entries(f.phases).map(([p, file]) => `${p}: ${req(file)}`).join(', ')} },` : `  '${room}.${key}': ${req(f.file)},`);
    }
    if (A.front) {
      g[A.front.key] = box(A.front);
      pics.push(`  '${room}.${A.front.key}': ${req(A.front.file)},`);
    }
  }
  fs.writeFileSync(
    OUT_GEO,
    [
      `// Generated by tools/crib-art/fixtures.mjs — don't edit.`,
      `// Where the rooms' built-in fixtures, their wall trim and the kitchen's`,
      `// snack table sit in the scene (the pictures: fixtureArt.js).`,
      `export const FIXTURE_GEO = ${JSON.stringify(geo)};`,
      '',
    ].join('\n')
  );
  fs.writeFileSync(
    OUT_JS,
    [
      `// Generated by tools/crib-art/fixtures.mjs — don't edit.`,
      `// The pictures of the rooms' fixtures, wall trim and snack table, by`,
      `// \`room.key\` (one per time of day for the windows). Where they sit:`,
      `// fixtureGeo.js.`,
      `export const FIXTURE_ART = {`,
      ...pics,
      `};`,
      '',
    ].join('\n')
  );
  console.log('wrote', OUT_GEO, OUT_JS);
} finally {
  close();
  server.close();
}
