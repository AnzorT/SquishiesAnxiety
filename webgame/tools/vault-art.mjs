// The "To the treasure vault" loading screen's pictures (REDESIGN_V9 step 7, 2026-11-16: the design's recording in the
// user's Squish-Squad-assets.zip, loading-screens/2-to-the-treasure-vault*). The screen (src/components/VaultLoader.js)
// shows these and moves only what moves: the trail's dots, the creature's coin hopping along them, the bar, the zoom.
// Drawn here once by Chrome, so the phone shows pictures instead of redrawing SVG on its UI thread.
//
// Everything is laid out in the recording's frame, 639 x 295 (its 1278 x 590 stills at 2x), as VaultLoader lays it
// out; the pictures are drawn at the A15's scale (2340 / 639).
//
//   NODE_PATH=<a folder with playwright> node webgame/tools/vault-art.mjs
//     -> assets/royal/vault-table.jpg, vault-map.webp, vault-fill.png, vault-key.png, vault-glow.png
//     -> src/components/vaultArt.js (the map's place, its trail and the X, in frame units)
import fs from 'node:fs';
import path from 'node:path';
import { execFileSync } from 'node:child_process';
import { createRequire } from 'node:module';
import { fileURLToPath } from 'node:url';

const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
const REPO = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '../..');
const OUT = path.join(REPO, 'assets/royal');
const K = 2340 / 639; // pixels per frame unit
const F = { w: 639, h: 295 };
const MAP = { x: 111, y: 55, w: 418, h: 189 };
const BAR = { x: 152, y: 247, w: 335, h: 21 };

// the trail on the map (map units): from Home's door down round the bay, over the small islands, to the X
const TRAIL_D = 'M74 114 C 86 132 100 146 124 154 C 150 162 176 160 194 150 C 212 140 222 118 240 104 C 252 95 262 91 272 94 C 296 100 318 112 334 122 C 344 128 352 130 359 130';
const X = [359, 130];

const INK = '#6b4c33';
const island = (d, fill = '#ead39f') => `<path d="${d}" fill="${fill}" stroke="${INK}" stroke-width="1.6" stroke-linejoin="round"/>`;
const palm = (x, y, s = 1) => `<g transform="translate(${x} ${y}) scale(${s})" fill="none" stroke="${INK}" stroke-width="1.3" stroke-linecap="round"><path d="M0 0 Q1 -8 0 -16"/><path d="M0 -16 Q-6 -19 -11 -15 M0 -16 Q-5 -22 -9 -24 M0 -16 Q5 -22 10 -23 M0 -16 Q7 -18 11 -13 M0 -16 Q1 -21 2 -25"/></g>`;
const wave = (x, y) => `<path d="M${x} ${y} q3 -2.4 6 0 t6 0 M${x + 2} ${y + 4} q3 -2.4 6 0 t6 0" fill="none" stroke="${INK}" stroke-width="1" stroke-linecap="round" opacity=".75"/>`;

const mapSvg = `
<svg xmlns="http://www.w3.org/2000/svg" viewBox="-6 -6 ${MAP.w + 12} ${MAP.h + 12}" width="${(MAP.w + 12) * K}" height="${(MAP.h + 12) * K}">
  <defs>
    <radialGradient id="pa" cx="50%" cy="45%" r="70%"><stop offset="0" stop-color="#f6e7c2"/><stop offset=".7" stop-color="#eed9a8"/><stop offset="1" stop-color="#ddc08a"/></radialGradient>
    <filter id="sh" x="-10%" y="-10%" width="120%" height="130%"><feDropShadow dx="0" dy="3" stdDeviation="3" flood-color="#3a1e08" flood-opacity=".45"/></filter>
    <filter id="soft"><feGaussianBlur stdDeviation="4"/></filter>
  </defs>
  <!-- the torn sheet -->
  <path filter="url(#sh)" fill="url(#pa)" stroke="#a8814f" stroke-width="1.2" d="M4 6 L22 3 L40 6 L58 2 L84 5 L106 1 L132 4 L158 2 L186 6 L214 3 L240 5 L270 1 L298 4 L330 2 L358 5 L384 1 L414 3 L413 30 L417 58 L412 88 L416 118 L411 146 L415 172 L408 186 L380 183 L352 187 L320 183 L290 186 L262 182 L232 186 L200 183 L170 187 L140 183 L112 186 L84 182 L54 186 L28 183 L6 187 L8 160 L3 132 L7 104 L2 76 L6 48 L2 24 Z"/>
  <!-- folds -->
  <path d="M137 3 L139 186 M275 2 L277 184 M5 98 L414 92" stroke="#c9a874" stroke-width="1" opacity=".7"/>
  <!-- stains -->
  <ellipse cx="319" cy="52" rx="34" ry="20" fill="#c9a46a" opacity=".22" filter="url(#soft)"/>
  <ellipse cx="128" cy="158" rx="42" ry="11" fill="#c9a46a" opacity=".28" filter="url(#soft)"/>
  <!-- islands -->
  ${island('M22 112 C 16 86 30 66 54 60 C 76 54 104 56 124 66 C 138 74 138 96 132 116 C 126 138 112 150 88 152 C 60 154 34 146 26 132 Z')}
  ${island('M176 128 C 178 118 192 113 206 115 C 220 117 226 126 222 136 C 218 146 200 148 188 145 C 178 142 174 136 176 128 Z')}
  ${island('M248 90 C 250 82 262 79 272 80 C 284 81 290 88 286 96 C 282 104 268 106 258 103 C 250 101 246 96 248 90 Z')}
  ${island('M306 72 C 308 54 326 44 346 46 C 368 48 390 56 396 74 C 402 92 398 112 404 128 C 408 142 396 156 376 158 C 352 160 330 152 322 138 C 314 124 316 110 312 98 C 308 88 304 82 306 72 Z')}
  <!-- Home: the red-roofed house -->
  <g transform="translate(70.5 104)">
    <path d="M-10 0 V12 H10 V0" fill="#f6e7c2" stroke="${INK}" stroke-width="1.6"/>
    <rect x="-3" y="5" width="6" height="7" fill="${INK}"/>
    <path d="M-14 2 L0 -11 L14 2" fill="none" stroke="#c8402a" stroke-width="3" stroke-linejoin="round" stroke-linecap="round"/>
  </g>
  <text x="71" y="128" text-anchor="middle" font-family="Fredoka, Arial Rounded MT Bold, sans-serif" font-weight="700" font-size="8.5" fill="${INK}">Home</text>
  ${palm(37.5, 128)}${palm(105, 131, 0.9)}${palm(204, 124, 0.85)}
  <!-- the vault: mountains, the cave, the X -->
  <g fill="#ead39f" stroke="${INK}" stroke-width="1.5" stroke-linejoin="round">
    <path d="M319 80 L333 62 L346 80 Z"/><path d="M370 82 L382 66 L394 82 Z"/><path d="M336 79 L353 54 L370 79 Z"/>
  </g>
  <path d="M333 62 L336 74 M353 54 L356 70 M382 66 L384 76" stroke="${INK}" stroke-width=".9" opacity=".6"/>
  <path d="M342 118 V104 C 342 92 350 86 359 86 C 368 86 376 92 376 104 V118 Z" fill="#3a2a22" stroke="${INK}" stroke-width="1.6"/>
  <path d="M347 117 V105 C 347 96 352 92 359 92 C 366 92 371 96 371 105 V117" fill="#1c1210"/>
  <path d="M351 124 L367 138 M367 124 L351 138" stroke="#d93a2a" stroke-width="3.6" stroke-linecap="round"/>
  <text x="360" y="153" text-anchor="middle" font-family="Fredoka, Arial Rounded MT Bold, sans-serif" font-weight="700" font-size="8.5" fill="${INK}">Vault</text>
  ${palm(388, 136, 0.9)}
  <!-- the compass rose -->
  <g transform="translate(380.5 35)">
    <circle r="16" fill="none" stroke="${INK}" stroke-width="1.1"/><circle r="12.5" fill="none" stroke="${INK}" stroke-width=".7" stroke-dasharray="1.5 1.5"/>
    <path d="M0 -19 L3 -3 L0 0 L-3 -3 Z" fill="#d93a2a" stroke="${INK}" stroke-width=".8"/>
    <path d="M0 19 L3 3 L0 0 L-3 3 Z M19 0 L3 3 L0 0 L3 -3 Z M-19 0 L-3 3 L0 0 L-3 -3 Z" fill="#f6e7c2" stroke="${INK}" stroke-width=".8"/>
    <text y="-23" text-anchor="middle" font-family="Fredoka, Arial Rounded MT Bold, sans-serif" font-weight="700" font-size="8" fill="${INK}">N</text>
  </g>
  <!-- a bird, the waves -->
  <path d="M233 50 q5.5 -6 5.5 -1 q0 -5 5.5 1" fill="none" stroke="${INK}" stroke-width="1.3" stroke-linecap="round"/>
  ${[[112, 27], [180, 36], [226, 74], [292, 25], [33, 172], [160, 164], [250, 165], [299, 155], [393, 167]].map(([x, y]) => wave(x, y)).join('')}
</svg>`;

const wood = `
<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 ${F.w} ${F.h}" width="${F.w * K}" height="${F.h * K}">
  <defs>
    <linearGradient id="pl" x1="0" y1="0" x2="0" y2="1"><stop offset="0" stop-color="#c28750"/><stop offset=".5" stop-color="#b47a45"/><stop offset="1" stop-color="#a26a39"/></linearGradient>
    <radialGradient id="vig" cx="50%" cy="48%" r="72%"><stop offset=".55" stop-color="#2a1404" stop-opacity="0"/><stop offset="1" stop-color="#2a1404" stop-opacity=".55"/></radialGradient>
    <radialGradient id="warm" cx="8%" cy="14%" r="45%"><stop offset="0" stop-color="#ffd890" stop-opacity=".35"/><stop offset="1" stop-color="#ffd890" stop-opacity="0"/></radialGradient>
    <radialGradient id="flame" cx="50%" cy="70%" r="60%"><stop offset="0" stop-color="#fff7c8"/><stop offset=".45" stop-color="#ffc24a"/><stop offset="1" stop-color="#f07a1a"/></radialGradient>
    <radialGradient id="halo"><stop offset="0" stop-color="#ffe2a0" stop-opacity=".75"/><stop offset="1" stop-color="#ffe2a0" stop-opacity="0"/></radialGradient>
    <linearGradient id="gold" x1="0" y1="0" x2="0" y2="1"><stop offset="0" stop-color="#ffe9a0"/><stop offset=".5" stop-color="#f2c24a"/><stop offset="1" stop-color="#b8801c"/></linearGradient>
    <linearGradient id="wax" x1="0" y1="0" x2="1" y2="0"><stop offset="0" stop-color="#d9d4cc"/><stop offset=".45" stop-color="#ffffff"/><stop offset="1" stop-color="#c9c2b8"/></linearGradient>
    <filter id="dsh"><feDropShadow dx="0" dy="2" stdDeviation="1.6" flood-color="#2a1404" flood-opacity=".45"/></filter>
    <filter id="grain"><feTurbulence type="fractalNoise" baseFrequency=".9 .06" numOctaves="2" seed="4"/><feColorMatrix values="0 0 0 0 .3  0 0 0 0 .16  0 0 0 0 .05  0 0 0 .22 0"/></filter>
  </defs>
  <rect width="${F.w}" height="${F.h}" fill="url(#pl)"/>
  ${Array.from({ length: 9 }, (_, i) => `<rect y="${i * 35 - 6}" width="${F.w}" height="35" fill="${['#c48a52', '#b27744', '#bc8150', '#ab713f'][i % 4]}" opacity=".55"/>`).join('')}
  <rect width="${F.w}" height="${F.h}" filter="url(#grain)"/>
  ${Array.from({ length: 9 }, (_, i) => `<path d="M0 ${i * 35 + 29} H${F.w}" stroke="#5e3a1c" stroke-width="1.4" opacity=".75"/><path d="M0 ${i * 35 + 30.4} H${F.w}" stroke="#e0a874" stroke-width=".8" opacity=".45"/>`).join('')}
  ${[[90, 0], [287, 1], [510, 1], [180, 2], [420, 3], [60, 4], [330, 5], [560, 6], [228, 7]].map(([x, r]) => `<path d="M${x} ${r * 35 - 5} V${r * 35 + 29}" stroke="#5e3a1c" stroke-width="1.2" opacity=".7"/><circle cx="${x - 5}" cy="${r * 35 + 4}" r="1.3" fill="#3a2210"/><circle cx="${x + 5}" cy="${r * 35 + 22}" r="1.3" fill="#3a2210"/>`).join('')}
  <rect width="${F.w}" height="${F.h}" fill="url(#warm)"/>
  <!-- the candle -->
  <circle cx="48" cy="24" r="26" fill="url(#halo)"/>
  <ellipse cx="48" cy="82" rx="21" ry="6.5" fill="#8a5a1a" filter="url(#dsh)"/>
  <ellipse cx="48" cy="79.5" rx="21" ry="6.5" fill="url(#gold)" stroke="#8a5a1a" stroke-width=".8"/>
  <ellipse cx="48" cy="78.5" rx="13" ry="3.6" fill="#d9a63a"/>
  <path d="M40 40 V78 Q48 81 56 78 V40 Q48 37 40 40 Z" fill="url(#wax)" stroke="#a69e94" stroke-width=".8"/>
  <path d="M42 41 Q41 48 43 52 Q44 49 44.5 42 Z" fill="#ffffff" opacity=".9"/>
  <ellipse cx="48" cy="40" rx="8" ry="2.6" fill="#efe9e0" stroke="#a69e94" stroke-width=".6"/>
  <path d="M48 39 V34" stroke="#3a2a22" stroke-width="1.1"/>
  <path d="M48 18 C 52 25 53 30 48 34 C 43 30 44 25 48 18 Z" fill="url(#flame)"/>
  <!-- coins -->
  ${[[72, 252, 0], [88, 262, 0], [557, 248, 0]].map(([x, y]) => `<g filter="url(#dsh)"><ellipse cx="${x}" cy="${y + 1.6}" rx="9" ry="3.6" fill="#9a6a14"/><ellipse cx="${x}" cy="${y}" rx="9" ry="3.6" fill="url(#gold)" stroke="#9a6a14" stroke-width=".7"/><ellipse cx="${x}" cy="${y - 0.2}" rx="5.5" ry="1.9" fill="none" stroke="#c99a30" stroke-width=".6"/></g>`).join('')}
  <!-- the compass -->
  <g transform="translate(594 238)" filter="url(#dsh)">
    <circle r="23" fill="url(#gold)" stroke="#7a5212" stroke-width="1"/>
    <circle r="17.5" fill="#fbf6ea" stroke="#9a6a14" stroke-width="1.2"/>
    <circle r="15" fill="none" stroke="#c9b48a" stroke-width=".6" stroke-dasharray="1 2"/>
    <path d="M10 -12 L2 2 L-2 -2 Z" fill="#d93a2a"/><path d="M-10 12 L-2 -2 L2 2 Z" fill="#3a6ad0"/>
    <circle r="2" fill="#7a5212"/>
  </g>
  <rect width="${F.w}" height="${F.h}" fill="url(#vig)"/>
</svg>`;

// the bar's fill (gold, candy stripes) and the key riding its end
const fill = `
<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 ${BAR.w} 15" width="${BAR.w * K}" height="${15 * K}">
  <defs>
    <linearGradient id="g" x1="0" y1="0" x2="0" y2="1"><stop offset="0" stop-color="#ffe9a0"/><stop offset=".5" stop-color="#f6b62c"/><stop offset="1" stop-color="#e08a10"/></linearGradient>
    <pattern id="st" width="10" height="15" patternUnits="userSpaceOnUse" patternTransform="skewX(-35)"><rect width="4.5" height="15" fill="#fff6d0" opacity=".7"/></pattern>
  </defs>
  <rect width="${BAR.w}" height="15" rx="7.5" fill="url(#g)"/><rect width="${BAR.w}" height="15" rx="7.5" fill="url(#st)"/>
  <rect x="3" y="2" width="${BAR.w - 6}" height="3.4" rx="1.7" fill="#ffffff" opacity=".45"/>
</svg>`;
const key = `
<svg xmlns="http://www.w3.org/2000/svg" viewBox="-14 -14 28 28" width="${28 * K}" height="${28 * K}">
  <defs><radialGradient id="b" cx="35%" cy="30%"><stop offset="0" stop-color="#a8703e"/><stop offset="1" stop-color="#5e3a1c"/></radialGradient></defs>
  <circle r="12.5" fill="url(#b)" stroke="#f2cc6a" stroke-width="1.6"/><circle r="12.5" fill="none" stroke="#3a2210" stroke-width=".7"/>
  <g fill="none" stroke="#ffd24a" stroke-width="2.2" stroke-linecap="round"><circle cx="-4.5" cy="0" r="3.4"/><path d="M-1 0 H8 M5 0 V3 M8 0 V3"/></g>
</svg>`;
const glow = `
<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 100 100" width="200" height="200">
  <defs><radialGradient id="g"><stop offset="0" stop-color="#fffbe0" stop-opacity="1"/><stop offset=".35" stop-color="#ffe27a" stop-opacity=".75"/><stop offset="1" stop-color="#ffc24a" stop-opacity="0"/></radialGradient></defs>
  <circle cx="50" cy="50" r="50" fill="url(#g)"/>
</svg>`;

// the trail's dots (map units), evenly spaced
const browser = await chromium.launch();
const page = await browser.newPage({ viewport: { width: 1200, height: 800 }, deviceScaleFactor: 1 });
await page.setContent('<!doctype html><html><body style="margin:0;background:transparent"><div id="s"></div></body></html>');
const dots = await page.evaluate((d) => {
  const p = document.createElementNS('http://www.w3.org/2000/svg', 'path'); p.setAttribute('d', d);
  const svg = document.createElementNS('http://www.w3.org/2000/svg', 'svg'); svg.appendChild(p); document.body.appendChild(svg);
  const L = p.getTotalLength(), n = 46, out = [];
  for (let i = 0; i <= n; i++) { const q = p.getPointAtLength((L * i) / n); out.push([Math.round(q.x * 10) / 10, Math.round(q.y * 10) / 10]); }
  return out;
}, TRAIL_D);

async function shot(svg, file, opts) {
  await page.setContent(`<!doctype html><html><body style="margin:0;background:transparent">${svg}</body></html>`);
  const el = await page.$('svg');
  await page.waitForTimeout(150);
  await el.screenshot({ path: file, omitBackground: true, ...opts });
}
await shot(wood, path.join(OUT, 'vault-table.jpg'), { type: 'jpeg', quality: 84, omitBackground: false });
const mapPng = path.join(OUT, 'vault-map.png');
await shot(mapSvg, mapPng);
await shot(fill, path.join(OUT, 'vault-fill.png'));
await shot(key, path.join(OUT, 'vault-key.png'));
await shot(glow, path.join(OUT, 'vault-glow.png'));
await browser.close();
// the map as WebP (it's big, and has a see-through torn edge)
execFileSync('python', ['-I', '-c', `from PIL import Image; Image.open(r'${mapPng}').save(r'${mapPng.replace(/\.png$/, '.webp')}', quality=88, method=6)`]);
fs.unlinkSync(mapPng);

fs.writeFileSync(path.join(REPO, 'src/components/vaultArt.js'), `// Generated by webgame/tools/vault-art.mjs — don't edit.
// The treasure vault loader's layout in the recording's frame (${F.w} x ${F.h}): the map's box (its picture has
// 6 units of torn edge round it), the progress bar, the trail's dots and the X (map units: from the map box's corner).
export const FRAME = ${JSON.stringify(F)};
export const MAP = ${JSON.stringify(MAP)};
export const MAP_PAD = 6;
export const BAR = ${JSON.stringify(BAR)};
export const X = ${JSON.stringify(X)};
export const TRAIL = ${JSON.stringify(dots)};
`);
for (const f of ['vault-table.jpg', 'vault-map.webp', 'vault-fill.png', 'vault-key.png', 'vault-glow.png']) console.log(f, Math.round(fs.statSync(path.join(OUT, f)).size / 1024) + ' KB');
