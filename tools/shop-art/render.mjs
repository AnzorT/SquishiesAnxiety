// Renders the design's chests ("Loot Chest Art.dc.html") to images, run for
// real in headless Chrome. The chest is an SVG whose look leans on CSS
// filters (the white sticker outline is four drop-shadows, the glows are
// blurs, the felt is an feTurbulence) that react-native-svg can't draw, so
// the app shows these images and does the chest's motion itself (wobble,
// squash, tremble, burst: src/squad/Chest.js).
//
// Each tier comes out at every crack stage (0 closed … 4 about to burst)
// and once bursting (lid gone), at 2×, with PAD px of room around the
// 240×240 chest for its rays and glow. The design's own small loops inside
// the art (the glints, the gem's blink and pulse) are frozen out.
//
//   node tools/shop-art/extract.mjs   (once, after a new "Squish Squad App.html")
//   node tools/shop-art/render.mjs
// Output: assets/squad/chests/<tier>-<0..4|burst>.webp and
// src/squad/chestArt.js (the require map).

import fs from 'node:fs';
import http from 'node:http';
import path from 'node:path';
import { fileURLToPath } from 'node:url';
import { connect, evaluate } from './cdp.mjs';

const HERE = path.dirname(fileURLToPath(import.meta.url));
const ROOT = path.resolve(HERE, '../..');
const DESIGN = path.join(HERE, 'design');
const OUT = path.join(ROOT, 'assets/squad/chests');
const OUT_JS = path.join(ROOT, 'src/squad/chestArt.js');
const PAGE = 'Loot Chest Art.dc.html';
const TIERS = ['basic', 'silver', 'gold', 'crystal', 'rainbow'];
const STAGES = [0, 1, 2, 3, 4, 'burst'];
const PAD = 40;
const SIZE = 240 + PAD * 2;
const DPR = 2;
const QUALITY = 92;
const PORT = 9600 + Math.floor(Math.random() * 300);

// ---- serve the design folder; /chest?tier=&stage= is the chest page with
// those props as its defaults --------------------------------------------------

const MIME = { '.html': 'text/html', '.js': 'text/javascript', '.svg': 'image/svg+xml' };
function chestPage(tier, stage) {
  const html = fs.readFileSync(path.join(DESIGN, PAGE), 'utf8');
  return html.replace(/data-props="([^"]*)"/, (m, attr) => {
    const props = JSON.parse(attr.replace(/&quot;/g, '"').replace(/&amp;/g, '&'));
    props.tier.default = tier;
    props.stage.default = stage === 'burst' ? 4 : stage;
    props.bursting = { ...props.bursting, default: stage === 'burst' };
    return `data-props="${JSON.stringify(props).replace(/&/g, '&amp;').replace(/"/g, '&quot;')}"`;
  });
}
const server = http
  .createServer((req, res) => {
    const url = new URL(req.url, 'http://x');
    if (url.pathname === '/chest') {
      res.writeHead(200, { 'Content-Type': 'text/html' });
      res.end(chestPage(url.searchParams.get('tier'), url.searchParams.get('stage') === 'burst' ? 'burst' : Number(url.searchParams.get('stage'))));
      return;
    }
    const file = path.join(DESIGN, decodeURIComponent(url.pathname));
    if (!file.startsWith(DESIGN) || !fs.existsSync(file) || fs.statSync(file).isDirectory()) {
      res.writeHead(404);
      res.end();
      return;
    }
    res.writeHead(200, { 'Content-Type': MIME[path.extname(file)] || 'application/octet-stream' });
    fs.createReadStream(file).pipe(res);
  })
  .listen(PORT);

// No animation (the art's loops frozen, the burst at its start), the glints
// hidden, a see-through page, and the chest's box on screen.
const PREP = `(() => {
  // the chest's own 240×240 box (the template's copy in <x-dc> never lays out)
  const root = [...document.querySelectorAll('div')].find((d) => {
    const st = d.getAttribute('style') || '';
    const r = d.getBoundingClientRect();
    return st.includes('--tr') && r.width > 0 && d.querySelector('svg');
  });
  if (!root) return null;
  const css = document.createElement('style');
  css.textContent = '*{animation:none!important;transition:none!important} [style*="lcGlint"]{display:none!important} html,body{background:transparent!important;margin:0} body{padding:${PAD}px!important}';
  document.head.appendChild(css);
  const r = root.getBoundingClientRect();
  return { x: r.x, y: r.y, w: r.width, h: r.height };
})()`;

const { send, close } = await connect();
try {
  await send('Emulation.setDeviceMetricsOverride', { width: 600, height: 600, deviceScaleFactor: DPR, mobile: false });
  await send('Emulation.setDefaultBackgroundColorOverride', { color: { r: 0, g: 0, b: 0, a: 0 } });
  fs.mkdirSync(OUT, { recursive: true });
  for (const tier of TIERS) {
    for (const stage of STAGES) {
      await send('Page.navigate', { url: `http://127.0.0.1:${PORT}/chest?tier=${tier}&stage=${stage}` });
      let rect = null;
      for (let i = 0; i < 60 && !rect; i++) {
        await new Promise((r) => setTimeout(r, 150));
        rect = await evaluate(send, PREP).catch(() => null);
      }
      if (!rect) throw new Error(`${tier} ${stage}: the chest never drew`);
      if (Math.round(rect.w) !== 240 || Math.round(rect.h) !== 240) throw new Error(`${tier} ${stage}: chest box ${rect.w}×${rect.h}, not 240×240`);
      await new Promise((r) => setTimeout(r, 120));
      const shot = await send('Page.captureScreenshot', { format: 'webp', quality: QUALITY, clip: { x: rect.x - PAD, y: rect.y - PAD, width: SIZE, height: SIZE, scale: 1 } });
      fs.writeFileSync(path.join(OUT, `${tier}-${stage}.webp`), Buffer.from(shot.data, 'base64'));
      process.stdout.write(`${tier}-${stage} `);
    }
  }
  console.log();
} finally {
  close();
  server.close();
}

const lines = TIERS.map((t) => `  ${t}: [${STAGES.map((s) => `require('../../assets/squad/chests/${t}-${s}.webp')`).join(', ')}],`);
fs.writeFileSync(
  OUT_JS,
  `// Generated by tools/shop-art/render.mjs — don't edit.\n// The design's chests: [stage 0 … 4, bursting] per tier, ${SIZE}×${SIZE} (the 240×240 chest\n// with ${PAD} px around it), drawn at ${DPR}×.\nexport const CHEST_PAD = ${PAD};\nexport const CHEST_BOX = ${SIZE};\nexport default {\n${lines.join('\n')}\n};\n`,
);
console.log(`→ ${path.relative(ROOT, OUT)}, ${path.relative(ROOT, OUT_JS)}`);
