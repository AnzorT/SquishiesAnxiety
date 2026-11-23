// Stage 2's camera check: the room as HouseRoomView draws it (dotnet run --project tools/unity/house-test -- camera
// <fixture> <room>: the box at camK 1 over the region the zoom shows, the night overlay on its own) zoomed by camK about
// (426, 343) of the box, the night laid over it, drawn by Chrome and compared with the page's screenshot; next to it,
// stage 1's composition (camK in the markup) against the same screenshot. The two should match the page equally well.
//
//   node tools/unity/house/camera-check.mjs lv12 living
import fs from 'node:fs';
import path from 'node:path';
import { createRequire } from 'node:module';
import { PNG } from 'pngjs';
import { REPO, REF } from './harness.mjs';

const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
const [fx, rk] = process.argv.slice(2);
const OUT = path.join(REPO, 'tools/unity/house-test/out');
const browser = await chromium.launch();
for (const tod of ['day', 'night']) {
  const name = `${fx}-${rk}-${tod}`;
  const meta = JSON.parse(fs.readFileSync(path.join(OUT, name + '-meta.json'), 'utf8'));
  const ref = PNG.sync.read(fs.readFileSync(path.join(REPO, 'tools/unity/house/captures', fx, `${rk}-${tod}.png`)));
  const dpr = ref.width / 852;
  const page = await browser.newPage({ viewport: { width: 852, height: 393 }, deviceScaleFactor: dpr });
  const svg = (s) => fs.readFileSync(path.join(OUT, `${name}-${s}.svg`), 'utf8');
  const [vx, vy, vw, vh] = meta.view;
  const shot = async (html) => { await page.setContent(`<body style="margin:0"><div style="position:relative;width:852px;height:393px;overflow:hidden;background:#f6ead8">${html}</div></body>`); await page.waitForTimeout(300); return PNG.sync.read(await page.screenshot()); };
  const room = await shot(`<div style="position:absolute;left:${vx}px;top:${vy}px;width:${vw}px;height:${vh}px;transform:scale(${meta.k});transform-origin:${426 - vx}px ${393 - vy}px">${svg('room').replace('<svg ', `<svg width="${vw}" height="${vh}" `)}</div>` +
    (meta.nightOn ? `<div style="position:absolute;left:0;top:0;width:852px;height:393px">${svg('night').replace('<svg ', '<svg width="852" height="393" ')}</div>` : ''));
  const plain = await shot(svg('plain').replace('<svg ', '<svg width="852" height="393" '));
  const diff = (a) => { let n = 0; for (let i = 0; i < a.data.length; i += 4) { const d = Math.max(Math.abs(a.data[i] - ref.data[i]), Math.abs(a.data[i + 1] - ref.data[i + 1]), Math.abs(a.data[i + 2] - ref.data[i + 2])); if (d > 24) n++; } return (100 * n / (a.data.length / 4)).toFixed(2) + '%'; };
  const same = (a, b) => { let n = 0; for (let i = 0; i < a.data.length; i += 4) if (Math.max(Math.abs(a.data[i] - b.data[i]), Math.abs(a.data[i + 1] - b.data[i + 1]), Math.abs(a.data[i + 2] - b.data[i + 2])) > 24) n++; return (100 * n / (a.data.length / 4)).toFixed(2) + '%'; };
  console.log(`${name}: zoomed layers vs page ${diff(room)}, stage 1 vs page ${diff(plain)}, zoomed vs stage 1 ${same(room, plain)}`);
  fs.writeFileSync(path.join(OUT, name + '-camera.png'), PNG.sync.write(room));
  await page.close();
}
await browser.close();
