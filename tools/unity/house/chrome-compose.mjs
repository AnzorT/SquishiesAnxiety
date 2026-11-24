// Draws the C# room compositions (dotnet run --project tools/unity/house-test -- compose all all: out/<fixture>-<room>-
// <day|night>.svg) with Chrome and diffs them with the page's screenshots: how far the C# room is from the page before
// the vector renderer is involved (pictures, positions, order, CSS boxes).
import fs from 'node:fs';
import path from 'node:path';
import { PNG } from 'pngjs';
import { launch, REPO } from './harness.mjs';

const OUTD = path.join(REPO, 'tools/unity/house-test/out'), PICS = path.join(REPO, 'unity/Assets/Resources/House/pics'), CAP = path.join(REPO, 'tools/unity/house/captures');
const K = 0.9765 * 2.8125;
const b = await launch(); const ctx = await b.newContext({ viewport: { width: 2340, height: 1080 }, deviceScaleFactor: 1 }); const pg = await ctx.newPage();
const rows = [];
for (const f of fs.readdirSync(OUTD).filter(f => /-(day|night)\.svg$/.test(f)).sort()) {
  const m = /^(.*?)-(living|kitchen|bathroom|bedroom|backyard|dance|movie|beach)-(day|night)\.svg$/.exec(f); if (!m) continue;
  const ref = path.join(CAP, m[1], m[2] + '-' + m[3] + '.png'); if (!fs.existsSync(ref)) continue;
  let svg = fs.readFileSync(path.join(OUTD, f), 'utf8').replace('viewBox="0 0 852 393">', 'viewBox="0 0 852 393" width="' + 852 * K + '" height="' + 393 * K + '" preserveAspectRatio="none">');
  svg = svg.replace(/<image href="([0-9a-f]{16})"/g, (q, n) => '<image href="data:image/png;base64,' + fs.readFileSync(path.join(PICS, n + '.png')).toString('base64') + '"');
  await pg.setContent('<html><body style="margin:0;background:#fff">' + svg + '</body></html>');
  await pg.waitForTimeout(300);
  const a = PNG.sync.read(await pg.screenshot()), r = PNG.sync.read(fs.readFileSync(ref));
  let vis = 0, n = 0; const W = Math.floor(852 * K), H = Math.floor(393 * K);
  for (let y = 0; y < H; y++) for (let x = 0; x < W; x++) { const i = (y * r.width + x) * 4; const d = Math.max(Math.abs(a.data[i] - r.data[i]), Math.abs(a.data[i + 1] - r.data[i + 1]), Math.abs(a.data[i + 2] - r.data[i + 2])); n++; if (d > 24) vis++; }
  rows.push([f.replace('.svg', ''), 100 * vis / n]);
  console.log(f.replace('.svg', ''), (100 * vis / n).toFixed(2) + '%');
}
await b.close();
const mean = rows.reduce((a, r) => a + r[1], 0) / rows.length;
console.log(`chrome-compose: ${rows.length} rooms, mean ${mean.toFixed(2)}% visibly different, worst ${Math.max(...rows.map(r => r[1])).toFixed(2)}%`);
