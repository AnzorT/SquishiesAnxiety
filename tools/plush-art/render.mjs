// Renders the plush roster's art to transparent images, straight from the
// design's own SVGs, so the app shows the creatures exactly as designed.
//
// The design's "Creature Plush" component (design/Creature Plush.dc.html)
// loads design/export/tripo/{key}/{key}-front.svg into a box with a CSS
// filter that adds the white sticker outline and the soft body shadow (and,
// locked, greys the creature out). react-native-svg has no filters, so
// Chrome renders each creature once here and the images go to Firebase
// (publish.mjs). The app adds what has to move — the mood body motion, the
// mood faces, the blink and the sparkles (src/components/CreatureThumbnail.js,
// src/plush/) — from the rig data this also collects (design/creatures-v2.js:
// each creature's eye/mouth/cheek geometry and colours, and its MOVES).
//
// Usage (from the repo root):
//   python -m zipfile -e "ASMR Creature Squash Game.zip" tools/plush-art/design
//   node tools/plush-art/render.mjs
// Output: tools/plush-art/out/{id}/{variant}.webp plus out/manifest.json.

import { spawn } from 'node:child_process';
import fs from 'node:fs';
import os from 'node:os';
import path from 'node:path';
import { fileURLToPath } from 'node:url';
import { ROSTER } from './roster.mjs';

const HERE = path.dirname(fileURLToPath(import.meta.url));
const DESIGN = path.join(HERE, 'design');
const OUT = path.join(HERE, 'out');
const PORT = 9400 + Math.floor(Math.random() * 400);

// One image per size class. The design's shadows and sticker outline are in
// px, not %, so a creature looks different at 30px than at 160px — each class
// is rendered at the size the design uses it at and the app picks the
// closest one.
//   xl — the squish stage, for a creature without a 3D model yet (the app
//        shows it ~340px big; SquishyToy2D.js)
//   lg — the Home card, Loading, the Mystery Box reveal, the Splash floaters,
//        the Key Shop's NEXT UP (design: 112-170px)
//   md — Achievements, Key Shop rows, the Crib (design: 72-84px)
//   sm — tokens and other tiny spots (design: 26-30px)
// `face: false` hides the drawing's own eyes and mouth (the design hides them
// the same way whenever a mood face is drawn over the creature — plush-anim.js
// `hide`); the app draws the mood's face on top of these (src/plush/faces.js).
const VARIANTS = [
  { name: 'xl', size: 320, locked: false, face: true },
  { name: 'lg', size: 160, locked: false, face: true },
  { name: 'lgLocked', size: 160, locked: true, face: true },
  { name: 'lgFace', size: 160, locked: false, face: false },
  { name: 'lgLockedFace', size: 160, locked: true, face: false },
  { name: 'md', size: 84, locked: false, face: true },
  { name: 'mdLocked', size: 84, locked: true, face: true },
  { name: 'mdFace', size: 84, locked: false, face: false },
  { name: 'mdLockedFace', size: 84, locked: true, face: false },
  { name: 'sm', size: 30, locked: false, face: true },
];
const DPR = 3;

// ---- the design's data ----------------------------------------------------

// creatures-v2.js: `const V2 = [...]` (the rig: face geometry and colours,
// `head` = the top of the head in the 0-100 box) and `const MOVES = {...}`
// (per-creature motion channels, keyed by name).
const v2Src = fs.readFileSync(path.join(DESIGN, 'creatures-v2.js'), 'utf8');
const jsonAfter = (src, marker) => {
  const start = src.indexOf(marker) + marker.length;
  const open = src[start];
  const close = open === '[' ? ']' : '}';
  let depth = 0;
  for (let i = start; i < src.length; i++) {
    if (src[i] === open) depth++;
    else if (src[i] === close && --depth === 0) return JSON.parse(src.slice(start, i + 1));
  }
  throw new Error(`unterminated ${marker}`);
};
const V2 = jsonAfter(v2Src, 'const V2 = ');
const MOVES = jsonAfter(v2Src, 'const MOVES = ');
// plush-anim.js: which food each creature nibbles in the Crib (`FOODS`).
const animSrc = fs.readFileSync(path.join(DESIGN, 'plush-anim.js'), 'utf8');
const FOODS = Object.fromEntries([...animSrc.match(/const FOODS = \{([^}]*)\}/)[1].matchAll(/(\w+): '(\w+)'/g)].map((m) => [m[1], m[2]]));

function rigOf(c) {
  const v = V2.find((x) => x.name.toLowerCase() === c.key);
  if (!v) throw new Error(`no creatures-v2 entry for ${c.key}`);
  const { name, src, ...rig } = v;
  return { key: c.key, food: FOODS[c.key] || 'apple', ...rig };
}

// The drawing, as the design's loadSvg() prepares it: no c2pa metadata, and
// sized to its box.
function svgOf(c) {
  const file = path.join(DESIGN, 'export', 'tripo', c.key, `${c.key}-front.svg`);
  return fs
    .readFileSync(file, 'utf8')
    .replace(/<metadata>[\s\S]*?<\/metadata>/, '')
    .replace(/width="\d+" height="\d+"/, 'width="100%" height="100%"');
}

// The wrapper the design puts the drawing in (Creature Plush.dc.html →
// wrapStyle), same numbers.
function creatureHtml(svg, size, locked) {
  const w = Math.max(1, Math.round(size / 70));
  const filter = locked
    ? 'grayscale(0.85) sepia(0.35) hue-rotate(230deg) saturate(1.6) brightness(0.62) drop-shadow(2px 0 0 rgba(255,255,255,0.7)) drop-shadow(-2px 0 0 rgba(255,255,255,0.7)) drop-shadow(0 2px 0 rgba(255,255,255,0.7)) drop-shadow(0 -2px 0 rgba(255,255,255,0.7))'
    : `drop-shadow(${w}px 0 0 #fff) drop-shadow(-${w}px 0 0 #fff) drop-shadow(0 ${w}px 0 #fff) drop-shadow(0 -${w}px 0 #fff) drop-shadow(0 ${w * 3}px ${w * 4}px rgba(90,0,120,0.3))`;
  return `<div style="width:${size}px; height:${size}px; position:relative; flex-shrink:0; filter:${filter}; opacity:${locked ? 0.88 : 1};"><div style="position:absolute; inset:0;">${svg}</div></div>`;
}

// Generous room around the nominal box: accessories poke out and the soft
// body shadow falls below. Trimmed after.
const marginOf = (size) => Math.round(size * 0.35 + 50);

function pageHtml(svg, v) {
  const m = marginOf(v.size);
  return `<!DOCTYPE html><html><head><meta charset="utf-8"><style>
    html,body{margin:0;background:transparent;}
    *{animation:none !important;}
    #stage{position:absolute;left:0;top:0;width:${v.size + m * 2}px;height:${v.size + m * 2}px;}
    #box{position:absolute;left:${m}px;top:${m}px;}
  </style></head><body><div id="stage"><div id="box">${creatureHtml(svg, v.size, v.locked)}</div></div></body></html>`;
}

// The design's scan (plush-anim.js): the eyes are the shapes filled with the
// `ey*` gradient plus up to two white highlights right after each, the mouth
// is the path stroked #6a3a3a. Hidden for the faceless variants.
const HIDE_FACE = `(() => {
  const root = document.querySelector('svg'); const hide = [];
  root.querySelectorAll('[fill^="url(#ey"]').forEach(e => { hide.push(e); let n = e.nextElementSibling; for (let i = 0; i < 2 && n; i++, n = n.nextElementSibling) if ((n.getAttribute('fill') || '') === '#fff') hide.push(n); });
  root.querySelectorAll('path[stroke="#6a3a3a"]').forEach(e => hide.push(e));
  hide.forEach(e => { e.style.display = 'none'; });
  return hide.length;
})()`;

// ---- a tiny CDP client --------------------------------------------------

function findChrome() {
  const candidates = [
    process.env.CHROME_PATH,
    path.join(os.homedir(), 'AppData/Local/Google/Chrome/Application/chrome.exe'),
    'C:/Program Files/Google/Chrome/Application/chrome.exe',
    '/Applications/Google Chrome.app/Contents/MacOS/Google Chrome',
    '/usr/bin/google-chrome',
  ].filter(Boolean);
  const hit = candidates.find((p) => fs.existsSync(p));
  if (!hit) throw new Error('Chrome not found — set CHROME_PATH');
  return hit;
}

async function connect() {
  const profile = fs.mkdtempSync(path.join(os.tmpdir(), 'plush-art-'));
  const chrome = spawn(findChrome(), ['--headless=new', '--no-sandbox', '--hide-scrollbars', `--remote-debugging-port=${PORT}`, `--user-data-dir=${profile}`, 'about:blank'], { stdio: 'ignore' });
  let target;
  for (let i = 0; i < 50 && !target; i++) {
    await new Promise((r) => setTimeout(r, 200));
    try {
      const list = await (await fetch(`http://127.0.0.1:${PORT}/json/list`)).json();
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

// Crops a screenshot to its visible pixels (alpha > 0), in the browser's own
// canvas so the tool needs nothing beyond Node and Chrome.
async function trim(send, pngBase64) {
  const expr = `(async () => {
    const img = new Image();
    img.src = 'data:image/png;base64,${pngBase64}';
    await img.decode();
    const c = document.createElement('canvas');
    c.width = img.width; c.height = img.height;
    const g = c.getContext('2d');
    g.drawImage(img, 0, 0);
    const a = g.getImageData(0, 0, c.width, c.height).data;
    let x0 = c.width, y0 = c.height, x1 = -1, y1 = -1;
    for (let y = 0; y < c.height; y++) for (let x = 0; x < c.width; x++) {
      if (a[(y * c.width + x) * 4 + 3] > 0) { if (x < x0) x0 = x; if (x > x1) x1 = x; if (y < y0) y0 = y; if (y > y1) y1 = y; }
    }
    const w = x1 - x0 + 1, h = y1 - y0 + 1;
    const o = document.createElement('canvas');
    o.width = w; o.height = h;
    o.getContext('2d').drawImage(c, x0, y0, w, h, 0, 0, w, h);
    return { x: x0, y: y0, w, h, webp: o.toDataURL('image/webp', 0.92).split(',')[1],
      touchesEdge: x0 === 0 || y0 === 0 || x1 === c.width - 1 || y1 === c.height - 1 };
  })()`;
  const r = await send('Runtime.evaluate', { expression: expr, awaitPromise: true, returnByValue: true });
  const v = r.result.value;
  if (v.touchesEdge) console.warn('\nwarning: art touches the canvas edge — widen marginOf()');
  return v;
}

// ---- render -------------------------------------------------------------

const only = process.argv.slice(2).filter((a) => /^\d+$/.test(a)).map(Number);
const todo = only.length ? ROSTER.filter((c) => only.includes(c.id)) : ROSTER;
const manifestPath = path.join(OUT, 'manifest.json');
const manifest = only.length && fs.existsSync(manifestPath) ? JSON.parse(fs.readFileSync(manifestPath, 'utf8')) : {};
const { send, close } = await connect();
try {
  await send('Page.enable');
  await send('Emulation.setDefaultBackgroundColorOverride', { color: { r: 0, g: 0, b: 0, a: 0 } });
  const frame = (await send('Page.getFrameTree')).frameTree.frame.id;
  for (const c of todo) {
    fs.mkdirSync(path.join(OUT, String(c.id)), { recursive: true });
    const svg = svgOf(c);
    const art = {};
    for (const v of VARIANTS) {
      const m = marginOf(v.size);
      const canvas = v.size + m * 2;
      await send('Emulation.setDeviceMetricsOverride', { width: canvas, height: canvas, deviceScaleFactor: DPR, mobile: false });
      await send('Page.setDocumentContent', { frameId: frame, html: pageHtml(svg, v) });
      if (!v.face) {
        const hidden = (await send('Runtime.evaluate', { expression: HIDE_FACE, returnByValue: true })).result.value;
        if (!hidden) console.warn(`\nwarning: ${c.key}: no eyes/mouth found to hide`);
      }
      await new Promise((r) => setTimeout(r, 60));
      const shot = await send('Page.captureScreenshot', { format: 'png', clip: { x: 0, y: 0, width: canvas, height: canvas, scale: 1 } });
      const trimmed = await trim(send, shot.data);
      fs.writeFileSync(path.join(OUT, String(c.id), `${v.name}.webp`), Buffer.from(trimmed.webp, 'base64'));
      // Where the trimmed image sits relative to the nominal size×size box,
      // in units of that box (so 1 = the creature's size) — the app lays the
      // image out from this at any display size.
      const px = v.size * DPR;
      const mpx = m * DPR;
      const r4 = (n) => Math.round(n * 10000) / 10000;
      art[v.name] = {
        frame: [r4((trimmed.x - mpx) / px), r4((trimmed.y - mpx) / px), r4(trimmed.w / px), r4(trimmed.h / px)],
        px: [trimmed.w, trimmed.h],
      };
    }
    manifest[c.id] = { key: c.key, name: c.name, description: c.description, art, rig: rigOf(c), moves: MOVES[c.name] || null };
    process.stdout.write(`${c.id} `);
  }
  fs.writeFileSync(manifestPath, JSON.stringify(manifest, null, 1));
  console.log('\nrendered to', OUT);
} finally {
  close();
}
