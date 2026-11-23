// Checks the UI exporter (snap.js): a screen of the app as SVG, drawn by Chrome, against Chrome's own screenshot.
//   node tools/unity/ui/snap-test.mjs <out dir> [preview card] [clicks "x,y;wait<ms>;..." in dp]
import fs from 'node:fs';
import path from 'node:path';
import { openApp, snap, DP, DPR } from './snap-page.mjs';

const [out, card = 'game-stack', clicks = '705,143;wait6500'] = process.argv.slice(2);
fs.mkdirSync(path.join(out, 'vt'), { recursive: true });
const { browser, page, errors } = await openApp(`http://localhost:8081/?phone=1&preview=1&card=${card}`);
await page.waitForTimeout(5000);
for (const c of clicks.split(';').filter(Boolean)) {
  if (c.startsWith('wait')) await page.waitForTimeout(+c.slice(4));
  else { const [x, y] = c.split(',').map(Number); await page.mouse.click(x, y); await page.waitForTimeout(400); }
}
const s = await snap(page, '#root');
await page.screenshot({ path: path.join(out, 'app.png') });
fs.copyFileSync(path.join(out, 'app.png'), path.join(out, 'vt', 'screen.png'));
fs.writeFileSync(path.join(out, 'snap.svg'), s.svg);
// for tools/unity/vector-test: the SVG with its pictures as PNG files next to it, and the app's screenshot
const vt = path.join(out, 'vt');
fs.mkdirSync(vt, { recursive: true });
let svgFiles = s.svg;
for (const [id, data] of Object.entries(s.images)) {
  const file = path.join(vt, id + '.src');
  fs.writeFileSync(file, Buffer.from(data.split(',')[1], 'base64'));
  svgFiles = svgFiles.split(`href="${data}"`).join(`href="${id}.png"`);
}
fs.writeFileSync(path.join(vt, 'screen.svg'), svgFiles);
fs.writeFileSync(path.join(out, 'texts.json'), JSON.stringify(s.texts));
console.log(`svg ${(s.svg.length / 1024).toFixed(0)} KB, ${Object.keys(s.images).length} images, rasters: ${s.rasters.map((r) => r.ch + '(' + r.font + ')').join(' ') || 'none'}`);
const p2 = await browser.newPage({ viewport: DP, deviceScaleFactor: DPR });
await p2.setContent(`<html><body style="margin:0;background:#000">${s.svg}</body></html>`);
await p2.waitForTimeout(1500);
await p2.screenshot({ path: path.join(out, 'snap.png') });
if (errors.length) console.log('page errors:', errors.slice(0, 3).join(' | '));
await browser.close();
