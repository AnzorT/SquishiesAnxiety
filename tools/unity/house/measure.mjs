// Measures the renovation pieces' drawings (HOUSE_PORT_PLAN.md stage 0): how many RenoDraw variants the house can ask
// for, how big they are, how long RenoDraw takes, and what in them the vector renderer can't draw yet.
//
//   node tools/unity/house/measure.mjs           -> prints a summary, writes tools/unity/house/captures/measure.json
import fs from 'node:fs';
import path from 'node:path';
import zlib from 'node:zlib';
import { fileURLToPath } from 'node:url';
import { openHouse, launch } from './harness.mjs';

const HERE = path.dirname(fileURLToPath(import.meta.url));
const b = await launch();
const H = await openHouse(b, { profile: { level: 30, coins: 0 } });
await H.ready();
// the drawing: every row's default view, MEMO cleared first (real time, measured outside the page's virtual clock)
await H.page.evaluate(() => window.RenoDraw.MEMO.clear());
const t0 = Date.now();
const all = await H.page.evaluate(() => {
  const sh = window.__sh, RD = window.RenoDraw, out = [];
  for (const r of sh.rows) {
    const D = RD.draw(r, sh.rnOpt(r, 0, null, null, ''));
    const A = D && !D.surf ? sh.rnReg(r.id) : null, it = { t: 'R:' + r.id, id: 'm' };
    const svgs = D ? [D.svg || '', D.srcF ? decodeURIComponent(D.srcF.slice(19)) : '', D.srcB ? decodeURIComponent(D.srcB.slice(19)) : ''] : [];
    out.push({ id: r.id, room: r.room, surf: !!(D && D.surf), spin: !!(A && sh.canSpin(it)), mount: !!(A && A.mount), split: !!(D && D.srcF), modes: (r.modes || []).length, texts: (r.texts || []).length || (A && A.sign ? 1 : 0), svgs });
  }
  return out;
});
const tDraw = Date.now() - t0;
// a sample of turned views (the spin pieces are drawn per angle in the room)
const t1 = Date.now();
const nTurn = await H.page.evaluate(() => { const sh = window.__sh, RD = window.RenoDraw; let n = 0; for (const r of sh.rows.filter(r => r.room === 'LIV').slice(0, 40)) for (const a of [0, 45, 90, 135, 180, 225, 270]) { RD.draw(r, sh.rnOpt(r, 0, a, null, '')); n++; } return n; });
const tTurn = Date.now() - t1;
await b.close();

const FEAT = [['<pattern', 'pattern'], ['url(#mt', 'pattern fill (house4 grain)'], ['<text', 'text'], ['mix-blend-mode', 'mix-blend-mode'], ['<animate', 'SMIL animate'], ['<animateTransform', 'SMIL animateTransform'], ['<animateMotion', 'SMIL animateMotion'], ['<set', 'SMIL set'], ['<image', 'image'], ['data:image/svg+xml', 'nested SVG picture'], ['<filter', 'filter'], ['feGaussianBlur', 'feGaussianBlur'], ['feMorphology', 'feMorphology'], ['feMerge', 'feMerge'], ['feColorMatrix', 'feColorMatrix'], ['feOffset', 'feOffset'], ['feFlood', 'feFlood'], ['feComposite', 'feComposite'], ['feTurbulence', 'feTurbulence'], ['<mask', 'mask'], ['clip-path', 'clip-path'], ['<use', 'use'], ['textPath', 'textPath'], ['foreignObject', 'foreignObject']];
const feat = {}; let bytes = 0, gz = 0, n = 0, spin = 0, surf = 0, split = 0, modes = 0, texts = 0, mount = 0;
for (const p of all) {
  if (p.surf) surf++; if (p.spin) spin++; if (p.split) split++; if (p.mount) mount++; modes += p.modes; texts += p.texts ? 1 : 0;
  const s = p.svgs.join(''); bytes += s.length; gz += zlib.gzipSync(s).length; n++;
  for (const [k, w] of FEAT) if (s.includes(k)) { const f = feat[w] = feat[w] || { pieces: 0, bytes: 0 }; f.pieces++; f.bytes += s.length; }
}
// variants a room can ask for: a spin piece any of 72 angles (5 degree steps), the others their one view (+ the mirror,
// which is the same picture flipped), each state (modes) and the split (srcB + srcF) as separate pictures
const variants = all.reduce((a, p) => a + (p.surf ? 1 : (p.spin ? 72 : 1) * Math.max(1, p.modes) * (p.split ? 2 : 1)), 0);
const res = { rows: all.length, surf, spin, mount, split, withModes: all.filter(p => p.modes).length, withTexts: texts, defaultSvgMB: bytes / 1048576, defaultGzMB: gz / 1048576, avgKB: bytes / n / 1024, drawAllMs: tDraw, drawPerPieceMs: tDraw / n, turnedViewsMs: tTurn / nTurn, variants, estAllVariantsGzMB: gz / n / 1048576 * variants, features: feat };
fs.mkdirSync(path.join(HERE, 'captures'), { recursive: true });
fs.writeFileSync(path.join(HERE, 'captures/measure.json'), JSON.stringify(res, null, 1));
console.log(JSON.stringify(res, null, 1));
