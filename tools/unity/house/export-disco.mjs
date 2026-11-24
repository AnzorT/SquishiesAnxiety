// The light-up dance floors' moments (develop, webgame/app/menu.js SquishDisco, 2026-11-21, the user wanted the
// light-up floors' colours back): a Dance Room floor in DISCO (CLB-005, -025, -045, -065, -085, -114) shows its tile's
// animation as DK = 4 moments, each a still of the tile `k * P / 4` s into its SMIL (svgAt: the animations paused and
// seeked, their values written in), switched on in turn over the floor every D / 4 s with no fade (step-end; loopOf:
// P = its longest animation up to 6 s, else its slowest up to 20 s; D = min(P, 6)); moment 0 is the floor itself.
//
//   node tools/unity/house/export-disco.mjs        (export-house.mjs runs it too, after it writes the pictures)
//
// -> unity/Assets/Resources/House/pics/<name>.png   each moment of each animated tile layer, rendered by Chrome at
//                                                   PNG_K px per unit, at most 1,400 px (HouseFlat reads its pixels)
//    unity/Assets/Resources/House/disco.json        { <floor id>: { D: seconds a loop, layers: [ [4 picture names] |
//                                                   null (a layer that doesn't move) ] } }
// svgAt, loopOf and the DISCO list are menu.js's own, read from it.
import fs from 'node:fs';
import path from 'node:path';
import crypto from 'node:crypto';
import { fileURLToPath } from 'node:url';
import { openHouse, launch, REPO } from './harness.mjs';
import { loadFixtures } from './fixtures.mjs';

const OUT = path.join(REPO, 'unity/Assets/Resources/House');
const PNG_K = 3;   // (as export-house.mjs)
const sha = s => crypto.createHash('sha1').update(s).digest('hex').slice(0, 16);
const stripSmil = s => s.replace(/<(animate|animateTransform|animateMotion|set|animateColor)\b[^>]*\/>/g, '').replace(/<(animate|animateTransform|animateMotion|set|animateColor)\b[^>]*>[\s\S]*?<\/\1>/g, '');
const canonIds = s => { const m = new Map(); for (const x of s.matchAll(/\bid="([^"]+)"/g)) if (!m.has(x[1])) m.set(x[1], 'k' + m.size);
  return s.replace(/(\bid=")([^"]+)(")|(url\(#)([^)]+)(\))|(href="#)([^"]+)(")/g, (all, a1, a2, a3, b1, b2, b3, c1, c2, c3) => a1 ? a1 + (m.get(a2) || a2) + a3 : b1 ? b1 + (m.get(b2) || b2) + b3 : c1 + (m.get(c2) || c2) + c3); };

// menu.js's own: the DISCO floors, DK, loopOf, svgOfUrl and svgAt
function menuCode() {
  const L = fs.readFileSync(path.join(REPO, 'webgame/app/menu.js'), 'utf8').split('\n');
  const a = L.findIndex(l => /const DISCO = \{/.test(l)), b = L.findIndex((l, i) => i > a && /^\s*function discoJob\(\)/.test(l));
  if (a < 0 || b < 0) throw new Error('SquishDisco not found in webgame/app/menu.js');
  return L.slice(a, b).join('\n') + '\nreturn { DISCO, DK, loopOf, svgOfUrl, svgAt };';
}

export async function exportDisco(browser) {
  const H = await openHouse(browser, loadFixtures().find(f => f.name === 'decorated'), { room: 'living' });
  await H.ready();
  await H.frames(2);
  const found = await H.page.evaluate(code => {
    const M = new Function(code)(), sh = window.__sh, out = {};
    for (const f of Object.keys(M.DISCO)) {
      const r = sh.byId.get(f), D = r && sh.rnDraw(r, 0), FR = D && D.floorRoom; if (!FR) continue;
      let P = 0;
      const layers = FR.layers.map(l => {
        const src = l.url; if (typeof src !== 'string' || src.indexOf('data:image/svg') !== 0) return null;
        const s = M.svgOfUrl(src); if (!/<(animate|animateTransform|set)\b/.test(s)) return null;
        const lp = M.loopOf(s); P = Math.max(P, lp[1]);
        return Array.from({ length: M.DK }, (x, k) => M.svgAt(s, k * lp[0] / M.DK));
      });
      out[f] = { D: P, layers };
    }
    return out;
  }, menuCode());
  await H.close();
  const ctx = await browser.newContext({ viewport: { width: 64, height: 64 }, deviceScaleFactor: 1 });
  const pg = await ctx.newPage();
  const disco = {}; let n = 0;
  for (const f in found) {
    disco[f] = { D: found[f].D, layers: [] };
    for (const L of found[f].layers) {
      if (!L || L.some(s => !s)) { disco[f].layers.push(null); continue; }
      const names = [];
      for (const s0 of L) {
        const svg = canonIds(stripSmil(s0)), name = sha(svg);
        names.push(name);
        const file = path.join(OUT, 'pics', name + '.png');
        if (fs.existsSync(file)) continue;
        const vb = (/viewBox="([^"]+)"/.exec(svg) || [])[1] || '0 0 100 100', [, , w, h] = vb.split(/[\s,]+/).map(Number);
        const k = Math.min(PNG_K, 1400 / Math.max(w, h)), W = Math.max(1, Math.ceil(w * k)), Hh = Math.max(1, Math.ceil(h * k));   // (a big tile at about 1,400 px, as menu.js bakes it)
        await pg.setViewportSize({ width: Math.min(4000, W), height: Math.min(4000, Hh) });
        await pg.setContent('<html><body style="margin:0;background:transparent"><img id="i" style="display:block;width:' + W + 'px;height:' + Hh + 'px"></body></html>');
        await pg.evaluate(async s => { const i = document.getElementById('i'); i.src = 'data:image/svg+xml,' + encodeURIComponent(s.includes('preserveAspectRatio') ? s : s.replace('<svg ', '<svg preserveAspectRatio="none" ')); await i.decode(); await document.fonts.ready; }, svg);
        fs.writeFileSync(file, await pg.screenshot({ omitBackground: true, clip: { x: 0, y: 0, width: Math.min(4000, W), height: Math.min(4000, Hh) } }));
        n++;
      }
      disco[f].layers.push(names);
    }
  }
  await ctx.close();
  fs.writeFileSync(path.join(OUT, 'disco.json'), JSON.stringify(disco));
  console.log('disco floors:', Object.keys(disco).map(f => f + ' ' + disco[f].D + ' s').join(', '), '·', n, 'new pictures');
  return disco;
}

if (process.argv[1] && path.resolve(process.argv[1]) === fileURLToPath(import.meta.url)) {
  const b = await launch();
  await exportDisco(b);
  await b.close();
}
