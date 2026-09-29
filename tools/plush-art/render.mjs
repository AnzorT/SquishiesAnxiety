// Renders the v3 "Creature Plush" art to transparent images, straight from the
// design's own HTML/CSS, so the app shows the creatures exactly as designed.
//
// The design draws every creature out of CSS (border-radius blobs, gradients,
// inset box-shadows, a white sticker outline made of drop-shadow filters).
// react-native-svg has no blur or filter support, so instead of re-drawing
// that in the app, Chrome renders it once here and the images go to Firebase
// (see publish.js). The app only adds what has to move: the mood animation
// and the two twinkling sparkles (see src/components/CreatureThumbnail.js).
//
// Usage (from the repo root):
//   python -m zipfile -e "ASMR Creature Squash Game.zip" tools/plush-art/design
//   node tools/plush-art/render.mjs
// Output: tools/plush-art/out/{id}/{variant}.webp plus out/manifest.json.
// A few creatures are changed from the design; see fixes.mjs.

import { spawn } from 'node:child_process';
import fs from 'node:fs';
import os from 'node:os';
import path from 'node:path';
import { fileURLToPath } from 'node:url';
import { FIXES } from './fixes.mjs';

const HERE = path.dirname(fileURLToPath(import.meta.url));
const SRC = process.argv[2] || path.join(HERE, 'design', 'Creature Plush.dc.html');
const OUT = path.join(HERE, 'out');
const PORT = 9400 + Math.floor(Math.random() * 400);

// One PNG per size class. The design's shadows are in px, not %, so a
// creature looks different at 26px than at 160px — each class is rendered at
// the size the design uses it at and the app picks the closest one.
//   lg — the Home card, Loading, Mystery Box reveal (design: 140-170px)
//   md — Achievements badges, Splash floaters (design: 42-84px)
//   sm — Key Shop rows (design: 26px)
const VARIANTS = [
  { name: 'lg', size: 160, dpr: 3, locked: false },
  { name: 'lgLocked', size: 160, dpr: 3, locked: true },
  { name: 'md', size: 84, dpr: 3, locked: false },
  { name: 'mdLocked', size: 84, dpr: 3, locked: true },
  { name: 'sm', size: 30, dpr: 3, locked: false },
];

// ---- read the design's template ---------------------------------------

const html = fs.readFileSync(SRC, 'utf8');
const body = html.slice(html.indexOf('<div style="{{ wrapStyle }}">') + '<div style="{{ wrapStyle }}">'.length, html.indexOf('</x-dc>'));

const blocks = {};
for (const m of body.matchAll(/<sc-if value="\{\{ (\w+) \}\}"[^>]*>([\s\S]*?)<\/sc-if>/g)) blocks[m[1]] = m[2];
// Everything that isn't inside an sc-if: the glossy streak + catch-light dot.
const common = body
  .replace(/<sc-if[\s\S]*?<\/sc-if>/g, '')
  .replace(/<\/div>\s*$/, '') // the wrapper's own closing tag
  .trim();

// Glimmer (8) and Pearla (16) carry an animated shine band (creShine). A
// still frame can't animate it, and the shine sweep is dropped on purpose.
const stripShine = (s) => s.replace(/<div[^>]*animation:creShine[^>]*><\/div>/g, '');

function creatureHtml(id, size, locked) {
  // Same numbers as the component's renderVals().
  const w = Math.max(1, Math.round(size / 70));
  const filter = locked
    ? 'grayscale(0.85) sepia(0.35) hue-rotate(230deg) saturate(1.6) brightness(0.62) drop-shadow(2px 0 0 rgba(255,255,255,0.7)) drop-shadow(-2px 0 0 rgba(255,255,255,0.7)) drop-shadow(0 2px 0 rgba(255,255,255,0.7)) drop-shadow(0 -2px 0 rgba(255,255,255,0.7))'
    : `saturate(1.12) drop-shadow(${w}px 0 0 #fff) drop-shadow(-${w}px 0 0 #fff) drop-shadow(0 ${w}px 0 #fff) drop-shadow(0 -${w}px 0 #fff) drop-shadow(0 ${w * 3}px ${w * 4}px rgba(90,0,120,0.3))`;
  // Our changes to a few creatures (fixes.mjs) replace the design's markup.
  const fix = FIXES[id] || {};
  const showBlush = !locked && size >= 40 && id !== 1 && id !== 10 && id !== 15 && !fix.noBlush;
  const art = stripShine(fix.art || blocks[`isC${id}`] || '');
  const blush = showBlush ? blocks.showBlush : '';
  const gloss = fix.noGloss ? '' : common;
  return `<div style="width:${size}px; height:${size}px; position:relative; flex-shrink:0; filter:${filter}; opacity:${locked ? 0.88 : 1};">${art}${gloss}${blush}</div>`;
}

// Generous room around the nominal box: accessories poke out (Zappy's bolt,
// Cosmo's ring) and the soft body shadow falls ~40px below. Trimmed after.
const marginOf = (size) => Math.round(size * 0.35 + 50);

function pageHtml(id, v) {
  const m = marginOf(v.size);
  return `<!DOCTYPE html><html><head><meta charset="utf-8"><style>
    html,body{margin:0;background:transparent;}
    *{animation:none !important;}
    #stage{position:absolute;left:0;top:0;width:${v.size + m * 2}px;height:${v.size + m * 2}px;}
    #box{position:absolute;left:${m}px;top:${m}px;}
  </style></head><body><div id="stage"><div id="box">${creatureHtml(id, v.size, v.locked)}</div></div></body></html>`;
}

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

const ids = Array.from({ length: 20 }, (_, i) => i);
const { send, close } = await connect();
try {
  await send('Page.enable');
  await send('Emulation.setDefaultBackgroundColorOverride', { color: { r: 0, g: 0, b: 0, a: 0 } });
  const frame = (await send('Page.getFrameTree')).frameTree.frame.id;
  const manifest = {};
  for (const id of ids) {
    fs.mkdirSync(path.join(OUT, String(id)), { recursive: true });
    manifest[id] = {};
    for (const v of VARIANTS) {
      const m = marginOf(v.size);
      const canvas = v.size + m * 2;
      await send('Emulation.setDeviceMetricsOverride', { width: canvas, height: canvas, deviceScaleFactor: v.dpr, mobile: false });
      await send('Page.setDocumentContent', { frameId: frame, html: pageHtml(id, v) });
      await new Promise((r) => setTimeout(r, 60));
      const shot = await send('Page.captureScreenshot', { format: 'png', clip: { x: 0, y: 0, width: canvas, height: canvas, scale: 1 } });
      const trimmed = await trim(send, shot.data);
      fs.writeFileSync(path.join(OUT, String(id), `${v.name}.webp`), Buffer.from(trimmed.webp, 'base64'));
      // Where the trimmed image sits relative to the nominal size×size box,
      // in units of that box (so 1 = the creature's size) — the app lays the
      // image out from this at any display size.
      const px = v.size * v.dpr;
      const mpx = m * v.dpr;
      const r4 = (n) => Math.round(n * 10000) / 10000;
      manifest[id][v.name] = {
        frame: [r4((trimmed.x - mpx) / px), r4((trimmed.y - mpx) / px), r4(trimmed.w / px), r4(trimmed.h / px)],
        px: [trimmed.w, trimmed.h],
      };
    }
    process.stdout.write(`${id} `);
  }
  fs.writeFileSync(path.join(OUT, 'manifest.json'), JSON.stringify(manifest, null, 1));
  console.log('\nrendered to', OUT);
} finally {
  close();
}
