// Stage 3's layer check: RoomLayers' layers (tools/unity/house-test `layers`) stacked as the house screen stacks them
// (the base, the pieces by z-index then their order, the night over all), drawn by Chrome at camK 1, against stage 1's
// single composition of the same room: the pieces' regions must hold all of each piece, and the order the page's.
//
//   node tools/unity/house/layers-check.mjs lv12 living
import fs from 'node:fs';
import path from 'node:path';
import { createRequire } from 'node:module';
import { PNG } from 'pngjs';
import { REPO } from './harness.mjs';

const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
const [fx, rk] = process.argv.slice(2);
const OUT = path.join(REPO, 'tools/unity/house-test/out');
const browser = await chromium.launch();
const page = await browser.newPage({ viewport: { width: 852, height: 393 }, deviceScaleFactor: 2 });
for (const tod of ['day', 'night']) {
  const L = JSON.parse(fs.readFileSync(path.join(OUT, `${fx}-${rk}-${tod}-layers.json`), 'utf8'));
  // each layer its own document (an <img>), as Unity draws each on its own: inline SVGs in one page share their ids
  const sized = (svg, w, h) => `<img style="display:block;width:${w}px;height:${h}px" src="data:image/svg+xml;base64,${Buffer.from(svg.replace('<svg ', `<svg width="${w}" height="${h}" `)).toString('base64')}">`;
  const box = (svg, r) => `<div style="position:absolute;left:${r[0]}px;top:${r[1]}px;width:${r[2]}px;height:${r[3]}px">${sized(svg, r[2], r[3])}</div>`;
  const order = L.pieces.map((p, i) => ({ ...p, i })).sort((a, b) => Math.round(a.z) - Math.round(b.z) || a.i - b.i);
  const shot = async (html) => { await page.setContent(`<body style="margin:0"><div style="position:relative;width:852px;height:393px;overflow:hidden;background:#f6ead8">${html}</div></body>`); await page.waitForTimeout(400); return PNG.sync.read(await page.screenshot()); };
  const layered = await shot(box(L.base, L.view) + order.map((p) => box(p.svg, p.region)).join('') + (L.night ? box(L.night, [0, 0, 852, 393]) : ''));
  const plain = await shot(sized(L.plain, 852, 393));
  let n = 0, bx0 = 1e9, by0 = 1e9, bx1 = -1, by1 = -1;
  for (let i = 0; i < plain.data.length; i += 4) if (Math.max(Math.abs(plain.data[i] - layered.data[i]), Math.abs(plain.data[i + 1] - layered.data[i + 1]), Math.abs(plain.data[i + 2] - layered.data[i + 2])) > 24) { n++; const px = (i / 4) % plain.width, py = Math.floor(i / 4 / plain.width); bx0 = Math.min(bx0, px); by0 = Math.min(by0, py); bx1 = Math.max(bx1, px); by1 = Math.max(by1, py); }
  if (n) console.log(`  differing pixels in frame px [${bx0 / 2}, ${by0 / 2}] - [${bx1 / 2}, ${by1 / 2}]; pieces: ${order.map((p) => p.z + '@' + p.region.join(',')).join(' | ')}`);
  console.log(`${fx}-${rk}-${tod}: ${L.pieces.length} pieces; layered vs one picture ${(100 * n / (plain.data.length / 4)).toFixed(2)}% of pixels differ`);
  fs.writeFileSync(path.join(OUT, `${fx}-${rk}-${tod}-layered.png`), PNG.sync.write(layered));
  fs.writeFileSync(path.join(OUT, `${fx}-${rk}-${tod}-plain.png`), PNG.sync.write(plain));
}
await browser.close();
