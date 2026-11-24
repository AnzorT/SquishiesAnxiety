// Compares two screenshots of the Main Menu pixel by pixel and writes a diff picture.
//
//   node tools/unity/compare.mjs <reference.png> <candidate.png> [diff.png] [--tolerance 6] [--max-share 0.5]
//
// A pixel counts as different when any channel is off by more than the tolerance (JPEG noise in the house picture is
// 1-4). Exits 1 when more than --max-share percent of the pixels differ, so CI fails on a real change, not on noise.
// Also: node tools/unity/compare.mjs --compose  rebuilds the menu from unity/Assets/Resources/Menu the way the Unity
// app places it (MenuLayout.cs) and compares that with unity/Reference/menu-a15.png: a check of the export itself.
import fs from 'node:fs';
import path from 'node:path';
import { fileURLToPath } from 'node:url';
import { PNG } from 'pngjs';
import { createRequire } from 'node:module';

const HERE = path.dirname(fileURLToPath(import.meta.url));
const REPO = path.resolve(HERE, '../..');
const MENU = path.join(REPO, 'unity/Assets/Resources/Menu');
const arg = (k, d) => { const i = process.argv.indexOf('--' + k); return i > 0 ? process.argv[i + 1] : d; };
const TOL = +arg('tolerance', 6), MAX_SHARE = +arg('max-share', 0.5);

export function diff(A, B, out) {
  if (A.width !== B.width || A.height !== B.height) throw new Error(`sizes differ: ${A.width}x${A.height} vs ${B.width}x${B.height}`);
  const D = new PNG({ width: A.width, height: A.height });
  let n = 0, worst = 0;
  for (let i = 0; i < A.data.length; i += 4) {
    const d = Math.max(Math.abs(A.data[i] - B.data[i]), Math.abs(A.data[i + 1] - B.data[i + 1]), Math.abs(A.data[i + 2] - B.data[i + 2]));
    if (d > worst) worst = d;
    const g = (A.data[i] + A.data[i + 1] + A.data[i + 2]) / 3 * 0.3;
    if (d > TOL) { n++; D.data[i] = 255; D.data[i + 1] = 0; D.data[i + 2] = 60; } else { D.data[i] = D.data[i + 1] = D.data[i + 2] = g; }
    D.data[i + 3] = 255;
  }
  if (out) fs.writeFileSync(out, PNG.sync.write(D));
  return { n, total: A.width * A.height, share: 100 * n / (A.width * A.height), worst };
}

// straight-alpha "source over" onto an opaque canvas, 8-bit, as Unity's sprite shader blends in Gamma colour space
function blit(dst, src, dx, dy) {
  for (let y = 0; y < src.height; y++) {
    const ty = dy + y; if (ty < 0 || ty >= dst.height) continue;
    for (let x = 0; x < src.width; x++) {
      const tx = dx + x; if (tx < 0 || tx >= dst.width) continue;
      const s = (y * src.width + x) * 4, d = (ty * dst.width + tx) * 4, a = src.data[s + 3] / 255;
      if (!a) continue;
      for (let c = 0; c < 3; c++) dst.data[d + c] = Math.round(src.data[s + c] * a + dst.data[d + c] * (1 - a));
      dst.data[d + 3] = 255;
    }
  }
}

async function compose() {
  const require = createRequire(import.meta.url);
  const { chromium } = require('playwright');
  const L = JSON.parse(fs.readFileSync(path.join(MENU, 'menu.json'), 'utf8'));
  const [W, H] = L.reference.px, st = L.reference;
  const k = 1 / L.scene.unitsPerPx, ox = (W - L.scene.viewBox[2] * k) / 2, oy = H - L.scene.viewBox[3] * k;
  const canvas = new PNG({ width: W, height: H });
  // the house picture is a JPEG: let Chromium decode it (pngjs can't)
  const browser = await chromium.launch();
  const page = await browser.newPage({ viewport: { width: L.scene.size[0], height: L.scene.size[1] } });
  const file = arg('scene', path.join(MENU, L.scene.states.find(x => x.season === st.season && x.level === st.level).res + '.bytes'));
  const img = fs.readFileSync(file), mime = file.endsWith('.png') ? 'image/png' : 'image/jpeg';
  await page.setContent('<style>html,body{margin:0}</style><img src="data:' + mime + ';base64,' + img.toString('base64') + '">');
  const scene = PNG.sync.read(await page.screenshot());
  await browser.close();
  const sx = Math.round(ox + L.scene.originUnits[0] * k), sy = Math.round(oy + L.scene.originUnits[1] * k);
  blit(canvas, scene, sx, sy);
  const png = rel => PNG.sync.read(fs.readFileSync(path.join(MENU, rel + '.png')));
  // its vignette, over it (MenuView: the house picture's own canvas, on at home)
  if (L.scene.vignette) blit(canvas, png(L.scene.vignette), sx, sy);
  for (const h of L.hud.filter(h => h.world)) blit(canvas, png(h.res), h.rect[0], h.rect[1]);
  const w = L.weather.find(x => x.season === st.season);
  if (w && w.band) {   // frozen at the start of its loop, as in the reference
    const tile = png(w.band.res);
    for (const c of w.band.copies) blit(canvas, tile, Math.round(ox + (w.band.rectUnits[0] + w.band.from[0]) * k), Math.round(oy + (w.band.rectUnits[1] + w.band.from[1] + c * w.band.period) * k));
  }
  for (const h of L.hud.filter(h => !h.world)) blit(canvas, png(h.res), h.rect[0], h.rect[1]);
  return canvas;
}

if (process.argv[1] === fileURLToPath(import.meta.url)) {
  let ref, cand, out;
  if (process.argv.includes('--compose')) {
    const L = JSON.parse(fs.readFileSync(path.join(MENU, 'menu.json'), 'utf8'));
    ref = PNG.sync.read(fs.readFileSync(path.join(REPO, L.reference.shot)));
    cand = await compose();
    const dir = path.join(REPO, 'webgame/test/out/unity');
    fs.mkdirSync(dir, { recursive: true });
    fs.writeFileSync(path.join(dir, 'composed.png'), PNG.sync.write(cand));
    out = path.join(dir, 'composed-diff.png');
  } else {
    const [a, b, o] = process.argv.slice(2).filter(x => !x.startsWith('--') && !/^[\d.]+$/.test(x));
    ref = PNG.sync.read(fs.readFileSync(a)); cand = PNG.sync.read(fs.readFileSync(b)); out = o;
  }
  const r = diff(ref, cand, out);
  const ok = r.share <= MAX_SHARE;
  console.log(`${ok ? 'MATCH' : 'DIFFERENT'}: ${r.n} of ${r.total} pixels (${r.share.toFixed(3)}%) differ by more than ${TOL}; worst channel difference ${r.worst}${out ? '; diff: ' + path.relative(process.cwd(), out) : ''}`);
  process.exit(ok ? 0 : 1);
}
