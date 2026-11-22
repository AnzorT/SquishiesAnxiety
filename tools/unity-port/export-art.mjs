// Art for the Unity port, made by the browser so every still is pixel-identical to what the game shows:
//   - WebP pictures (creature thumbnails, cards) -> PNG (Unity can't import WebP). The browser decodes them and
//     PNG stores the decoded pixels losslessly, so nothing changes.
//   - The creatures' SVG poses -> PNG, drawn by Chromium with everything Unity's SVG importer can't do (the fabric-
//     texture filter on every creature, blurs, blend modes).
//
//   node webgame/build.mjs --out webgame/test/out/webgame
//   node tools/unity-port/export-art.mjs [thumbs] [cards] [poses] [--pose-size 512]
//        -> unity/Assets/_Project/Art/Generated/Creatures/{Thumbs,Cards,Poses}/ (not in git: rebuilt by this script)
// With no names it exports all three. Re-running overwrites; files are only rewritten when their pixels changed.
import fs from 'node:fs';
import path from 'node:path';
import http from 'node:http';
import { createRequire } from 'node:module';
import { fileURLToPath } from 'node:url';

const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
const HERE = path.dirname(fileURLToPath(import.meta.url));
const REPO = path.resolve(HERE, '../..');
const BUILT = path.join(REPO, 'webgame/test/out/webgame');
const ART = path.join(REPO, 'unity/Assets/_Project/Art/Generated/Creatures');

const args = process.argv.slice(2);
const flag = (name, def) => (args.includes(name) ? args[args.indexOf(name) + 1] : def);
const POSE_SIZE = +flag('--pose-size', 512);
const wanted = args.filter((a, i) => !a.startsWith('--') && !(i > 0 && args[i - 1].startsWith('--')));
const want = k => !wanted.length || wanted.includes(k);

if (!fs.existsSync(path.join(BUILT, 'export'))) {
  console.error('Build the game pages first: node webgame/build.mjs --out webgame/test/out/webgame');
  process.exit(1);
}

const list = (dir, ext) => {
  const out = [];
  const walk = d => fs.readdirSync(d, { withFileTypes: true }).forEach(e => {
    const p = path.join(d, e.name);
    if (e.isDirectory()) walk(p); else if (p.endsWith(ext)) out.push(p);
  });
  walk(dir);
  return out.sort();
};

// The built folder over http, so the page can fetch and decode its files.
const TYPES = { '.svg': 'image/svg+xml', '.webp': 'image/webp', '.png': 'image/png', '.html': 'text/html' };
const server = http.createServer((q, s) => {
  if (q.url === '/') { s.writeHead(200, { 'Content-Type': 'text/html' }); s.end('<!doctype html><body style="margin:0;background:transparent">'); return; }
  const f = path.join(BUILT, decodeURIComponent(q.url.split('?')[0]));
  fs.readFile(f, (e, b) => { if (e) { s.writeHead(404); s.end(); return; } s.writeHead(200, { 'Content-Type': TYPES[path.extname(f)] || 'application/octet-stream' }); s.end(b); });
}).listen(0);
const BASE = `http://127.0.0.1:${server.address().port}`;

const browser = await chromium.launch();
const page = await browser.newPage();
await page.goto(BASE + '/');

let written = 0, same = 0;
function save(file, b64) {
  const buf = Buffer.from(b64, 'base64');
  fs.mkdirSync(path.dirname(file), { recursive: true });
  if (fs.existsSync(file) && fs.readFileSync(file).equals(buf)) { same++; return; }
  fs.writeFileSync(file, buf);
  written++;
}

// Decode a picture in the page and return it as PNG at its own size (WebP), or at size x size (SVG).
async function toPng(url, size) {
  return page.evaluate(async ({ url, size }) => {
    const img = new Image();
    img.decoding = 'sync';
    img.src = url;
    await img.decode();
    const w = size || img.naturalWidth, h = size || img.naturalHeight;
    const c = document.createElement('canvas');
    c.width = w; c.height = h;
    const g = c.getContext('2d');
    g.imageSmoothingQuality = 'high';
    g.drawImage(img, 0, 0, w, h);
    return c.toDataURL('image/png').split(',')[1];
  }, { url, size });
}

// WebP -> PNG, same size, same folder layout
async function webpFolder(from, to) {
  const files = list(path.join(BUILT, from), '.webp');
  for (const f of files) {
    const rel = path.relative(path.join(BUILT, from), f);
    save(path.join(ART, to, rel.replace(/\.webp$/, '.png')), await toPng('/' + path.relative(BUILT, f).split(path.sep).join('/')));
  }
  console.log(`${to}: ${files.length} pictures`);
}

if (want('thumbs')) await webpFolder('export/thumbs', 'Thumbs');
if (want('cards')) await webpFolder('export/cards4', 'Cards');

// SVG poses -> PNG. An <img> draws the SVG with its filters (the fabric texture) exactly like the game's pages do.
if (want('poses')) {
  const files = list(path.join(BUILT, 'export/tripo'), '.svg');
  for (const f of files) {
    const rel = path.relative(path.join(BUILT, 'export/tripo'), f);
    save(path.join(ART, 'Poses', rel.replace(/\.svg$/, '.png')), await toPng('/' + path.relative(BUILT, f).split(path.sep).join('/'), POSE_SIZE));
  }
  console.log(`Poses: ${files.length} pictures at ${POSE_SIZE} px`);
}

console.log(`${written} written, ${same} unchanged -> ${path.relative(REPO, ART)}`);
await browser.close();
server.close();
