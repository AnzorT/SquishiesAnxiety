// The light-up dance floor's moments as develop shows them (app/menu.js SquishDisco), for house-test `pixels --disco k`:
// the decorated house's Dance Room (its floor CLB-045) by day, with the floor at moment k (0..3: its tile svgAt k * P / 4
// s into its animation, menu.js's own code), the room alone as export-house.mjs captures it.
//
//   node tools/unity/house/disco-capture.mjs  -> tools/unity/house/captures/decorated/dance-day-d<k>.png
// (the harness keeps SquishDisco off for the room captures; here it gives the floor moment k's tile as its picture,
// a vector SVG like the rest, instead of develop's baked bitmaps)
import fs from 'node:fs';
import path from 'node:path';
import { fileURLToPath } from 'node:url';
import { openHouse, launch, REPO } from './harness.mjs';
import { loadFixtures } from './fixtures.mjs';
const MENU_K = (832 / 852).toFixed(4);   // (export-house.mjs: the menu's framing)

const HERE = path.dirname(fileURLToPath(import.meta.url));
const L = fs.readFileSync(path.join(REPO, 'webgame/app/menu.js'), 'utf8').split('\n');
const a = L.findIndex(l => /const DISCO = \{/.test(l)), b = L.findIndex((l, i) => i > a && /^\s*function discoJob\(\)/.test(l));
const CODE = L.slice(a, b).join('\n') + '\nreturn { DISCO, DK, loopOf, svgOfUrl, svgAt };';
const br = await launch();
for (let k = 0; k < 4; k++) {
  const H = await openHouse(br, loadFixtures().find(f => f.name === 'decorated'), { room: 'dance' });
  await H.ready(); await H.frames(1, 0);
  await H.page.evaluate(({ code, k, mk }) => {
    const M = new Function(code)(), sh = window.__sh;
    Object.defineProperty(window, 'SquishDisco', { configurable: true, value: (f, layers) => {
      if (!M.DISCO[f]) return null;
      return { frames: layers.map(l => { const s = M.svgOfUrl(l.url); if (!/<(animate|animateTransform|set)\b/.test(s)) return null; const P = M.loopOf(s)[0]; return [0, 1, 2, 3].map(j => 'data:image/svg+xml,' + encodeURIComponent(M.svgAt(s, (j === 0 ? k : j) * P / M.DK))); }), anims: [] };
    } });
    const f = sh.frameRef.current; f.style.transform = 'scale(' + mk + ')'; f.style.transformOrigin = '0 0';
    sh.setState(s => ({ ver: s.ver + 1 }));
  }, { code: CODE, k, mk: MENU_K });
  await H.frames(3);
  await H.still();
  await H.page.evaluate(() => {
    const sh = window.__sh, frame = sh.frameRef.current, room = frame.querySelector(':scope > div');
    let st = document.getElementById('__room_only'); if (!st) { st = document.createElement('style'); st.id = '__room_only'; document.head.appendChild(st); }
    [...frame.children].forEach(e => { if (e === room || /z-index: 860/.test(e.getAttribute('style') || '')) e.setAttribute('data-keep', ''); else e.removeAttribute('data-keep'); });
    st.textContent = '[data-house-crs],[data-house-fx]{visibility:hidden!important} [data-house-frame] > :not([data-keep]){visibility:hidden!important}';
    frame.setAttribute('data-house-frame', '');
  });
  await H.page.screenshot({ path: path.join(HERE, 'captures/decorated/dance-day-d' + k + '.png') });
  console.log('moment', k, H.errs.slice(0, 2));
  await H.close();
}
await br.close();
