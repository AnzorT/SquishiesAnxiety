// Squish Stack's level map backdrop (2026-11-17, the user: "let it be the trees forest", scrolling with the road, the
// road part of the background): a forest in the main menu's world style (its own tree and bush drawings from
// main-menu-scene.js, the same season colours), with the road of src/stack/road.js baked in. One long strip of TILES
// tiles that repeats without a seam, cut into tile pictures; src/stack/ForestMap.js lays them side by side and stands
// the levels on the road. One set per season, like the menu's world (src/royal/WorldBg.js picks it by month).
//
//   node webgame/build.mjs                  (main-menu-scene.js comes from the build)
//   NODE_PATH=<a folder with playwright> node tools/stack/forest.mjs
//     -> assets/stack/forest-<season>-<i>.jpg  (i = 0 … TILES-1)
import fs from 'node:fs';
import path from 'node:path';
import { createRequire } from 'node:module';
import { fileURLToPath, pathToFileURL } from 'node:url';

const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
const REPO = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '../..');
const SCENE = path.join(REPO, 'android/app/src/main/assets/webgame/main-menu-scene.js');
const OUT = path.join(REPO, 'assets/stack');
const ROAD = await import(pathToFileURL(path.join(REPO, 'src/stack/road.js')).href);
const SEASONS = (process.argv[2] || 'sunny,rainy,snowy').split(',');
const LEVEL = 30; // the world at its liveliest (green, fruit, flowers)
const SCALE = 2.25; // 1000 × 460 → 2250 × 1035 px (the A15 sideways is 1080 px tall)

if (!fs.existsSync(SCENE)) throw new Error('no ' + SCENE + ': run node webgame/build.mjs first');
fs.mkdirSync(OUT, { recursive: true });
const browser = await chromium.launch();
const page = await browser.newPage({ viewport: { width: ROAD.TILE_W, height: ROAD.TILE_H }, deviceScaleFactor: SCALE });
await page.setContent('<!doctype html><html><body style="margin:0;overflow:hidden;background:#000"><div id="s" style="width:100vw;height:100vh"></div></body></html>');

// the road's numbers go into the page as plain values (its curve is rebuilt there from the same formula's samples)
const L = ROAD.TILE_W * ROAD.TILES;
const roadPts = [];
for (let x = -120; x <= L + 120; x += 6) roadPts.push([x, +ROAD.roadY(x).toFixed(2)]);

await page.evaluate(({ L, roadPts, ROAD_W }) => {
  // a seeded random (the strip is the same on every run)
  let seed = 1;
  const rand = () => { seed = (seed * 16807) % 2147483647; return (seed - 1) / 2147483646; };
  const r1 = (v) => Math.round(v * 10) / 10;
  const roadAt = (x) => { const u = ((x % L) + L) % L; const i = Math.max(0, Math.min(roadPts.length - 2, Math.floor((u + 120) / 6))); const [x0, y0] = roadPts[i], [x1, y1] = roadPts[i + 1]; return y0 + ((y1 - y0) * (u - x0)) / (x1 - x0); };
  // the road's top / bottom edge over [x - w, x + w]
  const roadTop = (x, w) => Math.min(roadAt(x - w), roadAt(x), roadAt(x + w)) - ROAD_W / 2;
  const roadBot = (x, w) => Math.max(roadAt(x - w), roadAt(x), roadAt(x + w)) + ROAD_W / 2;
  // draw at x, and again a strip's length over when it hangs over either end (so the last tile runs into the first)
  const wrap = (x, reach, f) => f(x) + (x < reach ? f(x + L) : '') + (x > L - reach ? f(x - L) : '');

  window.SquishMenu = {
    still: true,
    parkArt(st, P) {
      seed = 7;
      const C = st.P, snow = st.season === 'snowy', rain = st.season === 'rainy';
      let g = '<defs><linearGradient id="mmHaze" x1="0" y1="0" x2="0" y2="1"><stop offset="0" stop-color="' + C.sky1 + '" stop-opacity="0"/><stop offset="1" stop-color="' + C.sky1 + '" stop-opacity="0.55"/></linearGradient>'
        + '<linearGradient id="mmEdge" x1="0" y1="0" x2="0" y2="1"><stop offset="0" stop-color="#1c0a38" stop-opacity="0.22"/><stop offset="1" stop-color="#1c0a38" stop-opacity="0"/></linearGradient></defs>';
      // sky
      g += '<rect x="-200" y="-20" width="' + (L + 400) + '" height="300" fill="url(#mmSky)"/>';
      if (st.season === 'sunny') g += '<circle cx="260" cy="64" r="70" fill="url(#mmSun)"/><circle cx="260" cy="64" r="24" fill="#fff6c8"/>';
      if (snow) g += '<circle cx="260" cy="64" r="22" fill="#ffffff" opacity="0.35" filter="url(#mmB3)"/>';
      const cc = rain ? '#b3bcc6' : snow ? '#eef2f6' : '#ffffff', cs = rain ? '#8e98a4' : '#d6e6f2';
      for (let i = 0; i < 22; i++) {
        const x = (i + rand() * 0.8) * (L / 22), y = 26 + rand() * 60, s = 0.6 + rand() * 0.6;
        g += wrap(x, 80, (X) => '<g transform="translate(' + r1(X) + ' ' + r1(y) + ') scale(' + r1(s) + ')"><ellipse cx="0" cy="6" rx="46" ry="11" fill="' + cs + '"/><circle cx="-22" cy="0" r="14" fill="' + cc + '"/><circle cx="0" cy="-8" r="19" fill="' + cc + '"/><circle cx="22" cy="-1" r="15" fill="' + cc + '"/><ellipse cx="0" cy="4" rx="42" ry="10" fill="' + cc + '"/></g>');
      }
      if (rain) g += '<rect x="-200" y="-20" width="' + (L + 400) + '" height="120" fill="#7a8692" opacity="0.18"/>';
      // far hills (their waves fit the strip a whole number of times)
      let hill = 'M-200 300 ';
      for (let x = -200; x <= L + 200; x += 10) hill += 'L' + x + ' ' + r1(214 + 9 * Math.sin((2 * Math.PI * x * 6) / L) + 6 * Math.sin((2 * Math.PI * x * 15) / L + 1)) + ' ';
      g += '<path d="' + hill + 'L' + (L + 200) + ' 300Z" fill="' + P.mix(C.grass, C.sky1, 0.55) + '"/>';
      // the forest's far edge: small trees close together, then a haze over them
      for (let x = 0; x < L; x += 26 + rand() * 18) {
        const y = 226 + rand() * 14, s = 0.3 + rand() * 0.16, sd = 100 + Math.floor(rand() * 900), fruit = rand() < 0.1;
        g += wrap(x, 60, (X) => P.tree(X, y, s, st, sd, { fruit }));
      }
      g += '<rect x="-200" y="110" width="' + (L + 400) + '" height="140" fill="url(#mmHaze)"/>';
      // the ground
      let gr = 'M-200 240 ';
      for (let x = -200; x <= L + 200; x += 20) gr += 'L' + x + ' ' + r1(238 + 3 * Math.sin((2 * Math.PI * x * 9) / L)) + ' ';
      g += '<path d="' + gr + 'L' + (L + 200) + ' 480 L-200 480Z" fill="url(#mmGrass)"/>';
      // nearer trees behind the road, wherever it leaves room
      // the forest itself, back to front: a thick row of middling trees, bigger ones in front of it, and the biggest
      // close behind the road wherever it dips low enough to leave them room
      for (let x = 0; x < L; x += 22 + rand() * 22) {
        const s = 0.58 + rand() * 0.2, y = 237 + rand() * 7, sd = 100 + Math.floor(rand() * 900), fruit = rand() < 0.15;
        if (y > roadTop(x, 40 * s) - 6) continue;
        g += wrap(x, 70, (X) => P.tree(X, y, s, st, sd, { fruit }));
      }
      for (let x = 0; x < L; x += 48 + rand() * 40) {
        const s = 0.8 + rand() * 0.24, y = 246 + rand() * 10, sd = 100 + Math.floor(rand() * 900), fruit = rand() < 0.2;
        if (y > roadTop(x, 40 * s) - 8) continue;
        g += wrap(x, 90, (X) => P.tree(X, y, s, st, sd, { fruit }));
      }
      for (let x = 0; x < L; x += 90 + rand() * 90) {
        const s = 0.98 + rand() * 0.22, sd = 100 + Math.floor(rand() * 900), fruit = rand() < 0.3;
        const y = Math.min(284, roadTop(x, 40 * s) - 10);
        if (y < 258) continue;
        g += wrap(x, 100, (X) => P.tree(X, y, s, st, sd, { fruit }));
      }
      // grass tufts and flowers, off the road
      const blade = snow ? '#c9d6dc' : '#4f9a36', blade2 = snow ? '#e6eef2' : '#7cc85a';
      for (let i = 0; i < 1100; i++) {
        const x = rand() * L, y = 244 + Math.pow(rand(), 0.85) * 216, s = 0.5 + ((y - 244) / 216) * 1.1;
        if (Math.abs(y - roadAt(x)) < ROAD_W / 2 + 3) continue;
        g += wrap(x, 20, (X) => '<path d="M' + r1(X - 3 * s) + ' ' + r1(y) + ' q-1 ' + r1(-5 * s) + ' ' + r1(-2 * s) + ' ' + r1(-8 * s) + ' M' + r1(X) + ' ' + r1(y) + ' q1 ' + r1(-6 * s) + ' 0 ' + r1(-10 * s) + ' M' + r1(X + 3 * s) + ' ' + r1(y) + ' q2 ' + r1(-4 * s) + ' ' + r1(3 * s) + ' ' + r1(-7 * s) + '" stroke="' + (i % 3 ? blade : blade2) + '" stroke-width="' + r1(0.9 * s + 0.3) + '" fill="none" stroke-linecap="round"/>');
      }
      if (!snow) for (let i = 0; i < 300; i++) {
        const x = rand() * L, y = 250 + rand() * 205, s = 0.6 + (y - 250) / 205;
        if (Math.abs(y - roadAt(x)) < ROAD_W / 2 + 5) continue;
        const c = ['#ffffff', '#fff27a', '#ffb3c7', '#c9b8ff', '#ff9a6a'][i % 5];
        g += wrap(x, 10, (X) => '<g transform="translate(' + r1(X) + ' ' + r1(y) + ') scale(' + r1(s) + ')">' + [0, 72, 144, 216, 288].map((a) => '<circle cx="' + r1(Math.cos((a * Math.PI) / 180) * 2) + '" cy="' + r1(Math.sin((a * Math.PI) / 180) * 2) + '" r="1.5" fill="' + c + '"/>').join('') + '<circle r="1" fill="#ffcf3a"/></g>');
      }
      // the road: a packed-earth track with a worn lighter middle, darker edges and pebbles
      // (in snow a trodden blue-grey track, or it vanishes into the white)
      const c0 = snow ? '#c3ced8' : P.mix(C.sand, '#c49a6c', 0.5), c1 = snow ? '#8f9eae' : P.mix(c0, '#6a4a2e', 0.3), c2 = P.mix(c0, '#ffffff', snow ? 0.45 : 0.3);
      const line = roadPts.map(([x, y], i) => (i ? 'L' : 'M') + x + ' ' + y).join(' ');
      g += '<path d="' + line + '" stroke="' + P.mix(c1, '#1d2a16', 0.35) + '" stroke-width="' + (ROAD_W + 10) + '" fill="none" stroke-linejoin="round" opacity="0.35" transform="translate(0 3)"/>';
      g += '<path d="' + line + '" stroke="' + c1 + '" stroke-width="' + (ROAD_W + 6) + '" fill="none" stroke-linejoin="round"/>';
      g += '<path d="' + line + '" stroke="' + c0 + '" stroke-width="' + ROAD_W + '" fill="none" stroke-linejoin="round"/>';
      g += '<path d="' + line + '" stroke="' + c2 + '" stroke-width="' + r1(ROAD_W * 0.4) + '" fill="none" stroke-linejoin="round" opacity="0.6"/>';
      for (let i = 0; i < 520; i++) {
        const x = rand() * L, side = rand() < 0.5 ? -1 : 1, off = side * (ROAD_W / 2 - 3 - rand() * 14), y = roadAt(x) + off, rx = 1.2 + rand() * 2.4;
        g += wrap(x, 6, (X) => '<ellipse cx="' + r1(X) + '" cy="' + r1(y) + '" rx="' + r1(rx) + '" ry="' + r1(rx * 0.6) + '" fill="' + (i % 3 ? c1 : P.mix(c0, '#ffffff', 0.5)) + '" opacity="0.8"/>');
      }
      // grass leaning over the road's edges
      for (let i = 0; i < 360; i++) {
        const x = rand() * L, side = rand() < 0.5 ? -1 : 1, y = roadAt(x) + side * (ROAD_W / 2 + 1), s = 0.8 + rand() * 0.5;
        g += wrap(x, 10, (X) => '<path d="M' + r1(X - 2 * s) + ' ' + r1(y + 2) + ' q-1 ' + r1(-4 * s) + ' ' + r1(-3 * s) + ' ' + r1(-7 * s) + ' M' + r1(X + 1) + ' ' + r1(y + 2) + ' q1 ' + r1(-5 * s) + ' ' + r1(2 * s) + ' ' + r1(-8 * s) + '" stroke="' + (i % 2 ? blade : blade2) + '" stroke-width="1.3" fill="none" stroke-linecap="round"/>');
      }
      if (rain) for (let i = 0; i < 18; i++) {
        const x = rand() * L, y = roadAt(x) + (rand() - 0.5) * 16, a = 12 + rand() * 12;
        g += wrap(x, 30, (X) => '<ellipse cx="' + r1(X) + '" cy="' + r1(y) + '" rx="' + r1(a) + '" ry="' + r1(a * 0.18) + '" fill="' + P.mix(C.sky0, '#ffffff', 0.3) + '" opacity="0.6"/>');
      }
      // in front of the road: mushrooms and stones, then bushes along the bottom edge
      for (let i = 0; i < 70; i++) {
        const x = rand() * L, top = roadBot(x, 10) + 46, y = top + rand() * Math.max(0, 404 - top);
        if (y > 410) continue;
        const kind = rand();
        if (kind < 0.55 && !snow) {
          const s = 0.8 + rand() * 0.5, cap = ['#e8433a', '#f08a3a', '#c9774a'][i % 3];
          g += wrap(x, 10, (X) => '<g transform="translate(' + r1(X) + ' ' + r1(y) + ') scale(' + r1(s) + ')"><ellipse cx="1" cy="0.5" rx="7" ry="1.6" fill="#1d2a16" opacity="0.2"/><path d="M-2 0 V-6 H2 V0Z" fill="#f6ecd8" stroke="#5a4636" stroke-width="0.7"/><path d="M-6 -5 Q0 -13 6 -5Z" fill="' + cap + '" stroke="#5a2a1a" stroke-width="0.8"/><circle cx="-2" cy="-7.5" r="0.9" fill="#ffffff"/><circle cx="2" cy="-8.4" r="0.8" fill="#ffffff"/></g>');
        } else {
          const s = 0.7 + rand() * 0.8, st0 = snow ? '#c9d0d6' : '#a49a8a';
          g += wrap(x, 10, (X) => '<g transform="translate(' + r1(X) + ' ' + r1(y) + ') scale(' + r1(s) + ')"><ellipse cx="1" cy="0.5" rx="8" ry="2" fill="#1d2a16" opacity="0.2"/><path d="M-7 0 Q-7 -6 -1 -7 Q6 -7 7 -1 Q7 1 0 1Z" fill="' + st0 + '" stroke="#4a4036" stroke-width="0.8"/><path d="M-4 -4 Q-1 -6 3 -5" stroke="#ffffff" stroke-width="0.9" fill="none" opacity="0.5"/>' + (snow ? '<path d="M-6 -3 Q-1 -9 6 -3 Q0 -6 -6 -3Z" fill="#ffffff"/>' : '') + '</g>');
        }
      }
      for (let x = 0; x < L; x += 70 + rand() * 80) {
        const y = 452 + rand() * 20, s = 1.2 + rand() * 0.7, sd = 100 + Math.floor(rand() * 900);
        g += wrap(x, 60, (X) => P.bush(X, y, s, st, sd));
      }
      // the top edge a little darker under the screen's top bar
      g += '<rect x="-200" y="-20" width="' + (L + 400) + '" height="110" fill="url(#mmEdge)"/>';
      return g;
    },
  };
}, { L, roadPts, ROAD_W: ROAD.ROAD_W });
await page.addScriptTag({ path: SCENE });

for (const season of SEASONS) {
  const svg = await page.evaluate(({ season, level }) => {
    const S = window.MainMenuScene;
    const st = S.state({ level, season });
    st.park = true;
    return S.svg(st);
  }, { season, level: LEVEL });
  for (let i = 0; i < ROAD.TILES; i++) {
    const tile = svg.replace('viewBox="0 0 1000 460"', `viewBox="${i * ROAD.TILE_W} 0 ${ROAD.TILE_W} ${ROAD.TILE_H}"`).replace('preserveAspectRatio="xMidYMax slice"', 'preserveAspectRatio="none"');
    await page.evaluate((html) => { document.getElementById('s').innerHTML = html; }, tile);
    await page.waitForTimeout(120);
    const file = path.join(OUT, `forest-${season}-${i}.jpg`);
    await page.screenshot({ path: file, type: 'jpeg', quality: 82 });
    console.log(path.relative(REPO, file), Math.round(fs.statSync(file).size / 1024) + ' KB');
  }
}
await browser.close();
