// The vault room (REDESIGN_V9, 2026-11-16, the user: "where is the vault room?" -> the place every chest is opened):
// the chest smash page (tools/chest/host.html) stands in the squad's treasure vault, where "To the treasure vault"
// (src/components/VaultLoader.js) flies in. Redrawn the same day after the user: "the vault is not looking great, it
// should be in the same warm and cozy Squish Squad app": the cold grey dungeon became a warm wooden treasure room in
// the app's colours (the Shop's honey planks, cream, gold, brown outlines; the loader's candle-lit table):
//   - honey wood planks on the wall over a darker panelled wainscot, a beam along the top with warm string lights;
//   - a round brass vault door standing open behind the chest, its opening glowing with gold;
//   - a berry-red rug with a gold border where the chest stands, on warm floorboards;
//   - old chests, a coin sack, a gem jar and coin piles in the corners (two wall lanterns and the page's two banners
//     were taken out 2026-11-21).
// The page puts the chest on the rug.
//
// The treasure is the app's own art (the user, 2026-11-16: "change the chests in the vault into our chests, from the
// selected squad only; replace the coins and gems with the ones in the app; more coins, chests and gems"): the
// currency coins and gems (assets/squad/currency) in heaps, stacks and scattered, and the group's own five chests
// (Common, Rare, Epic, Legendary, Rainbow) in the corners. So it's drawn once per group, at the A15's landscape
// pixels, as tools/chest/vault/<group>.webp; host.html shows the opened chest's.
// Round 2 (the user: "add much more", "the chests look out of context, they don't merge with the coins and gems", "why
// is the chest texture blurred"): the chests are drawn here by the chest engine itself (tools/design-v6, as the Shop's
// pictures are: tools/shop-art/groupchests.mjs) at twice their size on the screen, so they're as sharp as the coins
// (the Shop's 480 px pictures drawn at ~410 px came out soft); without the Shop's glow; in the room's warm light; and
// sunk into the heaps, coins piled against them, some tumbled at a tilt. Taller heaps up the corner walls, ten
// chests, gem clusters, heaps beside the vault door.
//
//   NODE_PATH=<a folder with playwright> node tools/chest/vault-room.mjs [group]   -> tools/chest/vault/<group>.webp
//   node tools/chest/build.mjs                                                    (copies them next to host.html)
import fs from 'node:fs';
import path from 'node:path';
import { createRequire } from 'node:module';
import { fileURLToPath } from 'node:url';

const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
const HERE = path.dirname(fileURLToPath(import.meta.url));
const OUT = path.join(HERE, 'vault');
const ART = path.join(HERE, '..', '..', 'assets', 'squad');
// the chest page's groups (host.html GROUPS); one group as the argument draws only that one
const GROUP_KEYS = ['snack', 'fruit', 'ocean', 'pet', 'forest', 'sky', 'dream', 'bakery', 'heroes', 'elemental', 'spooky'];
const ONLY = process.argv[2] || null;
const dataUri = (f) => `data:image/${f.endsWith('.png') ? 'png' : 'webp'};base64,${fs.readFileSync(f).toString('base64')}`;
// the app's currency (src/squad/currencyArt.js): 160 x 160 each
const COINS = ['mittens', 'pip', 'bao', 'dunkie', 'boo', 'jelli'].map((k) => dataUri(path.join(ART, 'currency', `coin-${k}.png`)));
const GEMS = ['mittens', 'jelli', 'twinkle', 'pip', 'boo', 'jinni'].map((k) => dataUri(path.join(ART, 'currency', `gem-${k}.png`)));

// The viewBox (sliced to the screen from the bottom middle, so it fills any landscape phone). Where the page puts
// things, in these units (1 unit is about 0.84 dp on the A15): the chest stands at x 500 on the rug's middle (y 402);
// the HUD covers the top middle down to ~y 120; the hint sits at the bottom middle.
const W = 1000, H = 460;
const BEAM = 20; // the ceiling beam's underside
const WAIN = 262; // the wainscot's top
const FLOOR = 334; // where the wall meets the floor
const DX = 500, DY = 212, DR = 128; // the vault door's middle and outer radius
const RUG = { x: 500, y: 404, rx: 292, ry: 46 };
const OL = '#5b3418'; // the app's brown outline

let seed = 11;
const rnd = () => ((seed = (seed * 9301 + 49297) % 233280) / 233280);
const r1 = (x) => Math.round(x * 10) / 10;
const pick = (a) => a[Math.floor(rnd() * a.length)];

// ---- the wall: honey planks ----
let wall = `<rect x="-200" y="0" width="${W + 400}" height="${FLOOR}" fill="#d49a5c"/>`;
const PLANK = 46;
for (let x = -46; x < W + 46; x += PLANK) {
  const c = pick(['#d99c5c', '#cf9050', '#dfa766', '#c98a4c', '#d6995a']);
  wall += `<rect x="${x}" y="${BEAM}" width="${PLANK}" height="${WAIN - BEAM}" fill="${c}"/>`;
  // grain: two soft wavy lines
  for (let g = 0; g < 2; g++) {
    const gx = x + 10 + rnd() * (PLANK - 20), w1 = (rnd() - 0.5) * 8;
    wall += `<path d="M${r1(gx)} ${BEAM} C${r1(gx + w1)} ${BEAM + 70} ${r1(gx - w1)} ${BEAM + 150} ${r1(gx + w1 * 0.5)} ${WAIN}" stroke="#a8692e" stroke-width="1.6" fill="none" opacity=".22"/>`;
  }
  // a knot now and then
  if (rnd() < 0.3) {
    const kx = x + 12 + rnd() * (PLANK - 24), ky = BEAM + 30 + rnd() * (WAIN - BEAM - 60);
    wall += `<ellipse cx="${r1(kx)}" cy="${r1(ky)}" rx="5" ry="8" fill="none" stroke="#a8692e" stroke-width="1.6" opacity=".35"/><ellipse cx="${r1(kx)}" cy="${r1(ky)}" rx="1.8" ry="3.2" fill="#a8692e" opacity=".35"/>`;
  }
  // a butt joint with its nails
  const jy = BEAM + 40 + rnd() * (WAIN - BEAM - 80);
  wall += `<path d="M${x + 1} ${r1(jy)} H${x + PLANK - 1}" stroke="${OL}" stroke-width="2" opacity=".55"/>`
    + `<circle cx="${x + 9}" cy="${r1(jy - 6)}" r="1.8" fill="${OL}" opacity=".7"/><circle cx="${x + PLANK - 9}" cy="${r1(jy + 6)}" r="1.8" fill="${OL}" opacity=".7"/>`;
  // the seam and a highlight on the plank's left edge
  wall += `<path d="M${x} ${BEAM} V${WAIN}" stroke="${OL}" stroke-width="2.2" opacity=".7"/><path d="M${x + 2.5} ${BEAM} V${WAIN}" stroke="#ffe3b0" stroke-width="1.4" opacity=".35"/>`;
}
// the wainscot: darker panels under a rail
wall += `<rect x="-200" y="${WAIN}" width="${W + 400}" height="${FLOOR - WAIN}" fill="#a96a36"/>`;
for (let x = -40; x < W + 40; x += 120) {
  wall += `<rect x="${x + 10}" y="${WAIN + 16}" width="100" height="${FLOOR - WAIN - 30}" rx="6" fill="#b97a42" stroke="${OL}" stroke-width="2" opacity=".95"/>`
    + `<rect x="${x + 16}" y="${WAIN + 21}" width="88" height="4" rx="2" fill="#ffe3b0" opacity=".28"/>`;
}
wall += `<rect x="-200" y="${WAIN - 9}" width="${W + 400}" height="16" fill="#8a5328" stroke="${OL}" stroke-width="2.4"/>`
  + `<rect x="-200" y="${WAIN - 7}" width="${W + 400}" height="4" fill="#d9a066" opacity=".75"/>`;
// the skirting board where the wall meets the floor
wall += `<rect x="-200" y="${FLOOR - 12}" width="${W + 400}" height="14" fill="#7a4520" stroke="${OL}" stroke-width="2.4"/>`;

// ---- the ceiling beam and the string lights ----
let beam = `<rect x="-200" y="-10" width="${W + 400}" height="${BEAM + 10}" fill="#8a5328" stroke="${OL}" stroke-width="3"/>`
  + `<rect x="-200" y="${BEAM - 7}" width="${W + 400}" height="3" fill="#c98a4c" opacity=".7"/>`;
for (let x = 30; x < W; x += 140) beam += `<circle cx="${x}" cy="${BEAM - 10}" r="3.2" fill="#e6b47c" stroke="${OL}" stroke-width="1.6"/>`;
let lights = '';
const BULBS = ['#fff1a8', '#ffd36a', '#ffb870', '#ffe08a'];
for (let x0 = -40; x0 < W + 40; x0 += 150) {
  const x1 = x0 + 150, sag = 30, y0 = BEAM + 2;
  lights += `<path d="M${x0} ${y0} Q${x0 + 75} ${y0 + sag * 2} ${x1} ${y0}" stroke="#4a2a14" stroke-width="2" fill="none"/>`;
  for (let i = 1; i < 6; i++) {
    const t = i / 6, bx = (1 - t) * (1 - t) * x0 + 2 * t * (1 - t) * (x0 + 75) + t * t * x1, by = (1 - t) * (1 - t) * y0 + 2 * t * (1 - t) * (y0 + sag * 2) + t * t * y0;
    const c = BULBS[(i + Math.round(x0 / 150)) % BULBS.length];
    lights += `<circle cx="${r1(bx)}" cy="${r1(by + 9)}" r="16" fill="url(#bulbGlow)"/>`
      + `<rect x="${r1(bx - 3)}" y="${r1(by)}" width="6" height="5" rx="1.5" fill="#6a4a2a"/>`
      + `<ellipse cx="${r1(bx)}" cy="${r1(by + 10)}" rx="5" ry="6.5" fill="${c}" stroke="#a8692e" stroke-width="1.2"/>`
      + `<ellipse cx="${r1(bx - 1.6)}" cy="${r1(by + 8)}" rx="1.6" ry="2.4" fill="#ffffff" opacity=".8"/>`;
  }
}

// ---- the vault door, standing open ----
const deg = (a) => (a * Math.PI) / 180;
const onR = (r, a) => [r1(DX + Math.cos(deg(a)) * r), r1(DY + Math.sin(deg(a)) * r)];
let door = '';
// a warm glow on the wall around it
door += `<circle cx="${DX}" cy="${DY}" r="${DR + 110}" fill="url(#doorHalo)"/>`;
// the frame: a thick brass ring set in the wall, with rivets
door += `<circle cx="${DX}" cy="${DY + 5}" r="${DR + 4}" fill="#3a1e0a" opacity=".35"/>`
  + `<circle cx="${DX}" cy="${DY}" r="${DR}" fill="url(#brass)" stroke="${OL}" stroke-width="3.2"/>`
  + `<circle cx="${DX}" cy="${DY}" r="${DR - 6}" fill="none" stroke="#fff3c4" stroke-width="2" opacity=".55"/>`;
for (let i = 0; i < 20; i++) {
  const [x, y] = onR(DR - 13, i * 18);
  door += `<circle cx="${x}" cy="${y}" r="4.6" fill="url(#rivet)" stroke="${OL}" stroke-width="1.4"/>`;
}
// the opening: deep and glowing, with the treasure inside
const IR = DR - 26;
door += `<circle cx="${DX}" cy="${DY}" r="${IR + 3}" fill="#7a4520" stroke="${OL}" stroke-width="3"/>`
  + `<circle cx="${DX}" cy="${DY}" r="${IR}" fill="url(#opening)"/>`;
// (the treasure inside is drawn with the corners' heaps, below: the app's coins)
door += `<g clip-path="url(#openClip)">@@INSIDE@@<rect x="${DX - IR}" y="${DY - IR}" width="${IR * 2}" height="34" fill="url(#openTop)"/></g>`;
// the door itself, swung open on its hinges to the right: a thick brass disc seen almost edge-on
const HX = DX + DR - 6;
door += `<rect x="${HX - 8}" y="${DY - 74}" width="22" height="26" rx="5" fill="url(#brass)" stroke="${OL}" stroke-width="2.4"/>`
  + `<rect x="${HX - 8}" y="${DY + 48}" width="22" height="26" rx="5" fill="url(#brass)" stroke="${OL}" stroke-width="2.4"/>`;
door += `<ellipse cx="${HX + 38}" cy="${DY + 2}" rx="34" ry="${DR - 4}" fill="#9a5e14" stroke="${OL}" stroke-width="3"/>`
  + `<ellipse cx="${HX + 30}" cy="${DY}" rx="34" ry="${DR - 4}" fill="url(#brassSide)" stroke="${OL}" stroke-width="3"/>`
  + `<ellipse cx="${HX + 30}" cy="${DY}" rx="25" ry="${DR - 22}" fill="none" stroke="#fff3c4" stroke-width="1.6" opacity=".5"/>`;
// its wheel, foreshortened
door += `<ellipse cx="${HX + 32}" cy="${DY}" rx="13" ry="40" fill="none" stroke="${OL}" stroke-width="7"/><ellipse cx="${HX + 32}" cy="${DY}" rx="13" ry="40" fill="none" stroke="#ffd34a" stroke-width="4"/>`;
for (const a of [0, 60, 120]) {
  const s = Math.sin(deg(a)), c = Math.cos(deg(a));
  door += `<path d="M${r1(HX + 32 - c * 12)} ${r1(DY - s * 39)} L${r1(HX + 32 + c * 12)} ${r1(DY + s * 39)}" stroke="${OL}" stroke-width="5.5" stroke-linecap="round"/><path d="M${r1(HX + 32 - c * 12)} ${r1(DY - s * 39)} L${r1(HX + 32 + c * 12)} ${r1(DY + s * 39)}" stroke="#ffd34a" stroke-width="2.6" stroke-linecap="round"/>`;
}
door += `<ellipse cx="${HX + 32}" cy="${DY}" rx="6" ry="11" fill="url(#rivet)" stroke="${OL}" stroke-width="2"/>`;

// ---- the floor: warm boards in perspective, and the rug ----
const VY = 120; // the boards' vanishing point
let floor = `<rect x="-200" y="${FLOOR}" width="${W + 400}" height="${H - FLOOR + 10}" fill="url(#floorG)"/>`;
for (let i = -18; i <= 18; i++) {
  const xt = DX + i * 46, xb = DX + i * 46 * ((H - VY) / (FLOOR - VY));
  floor += `<path d="M${xt} ${FLOOR} L${r1(xb)} ${H}" stroke="${OL}" stroke-width="2" opacity=".45"/>`;
}
for (let j = 0; j < 26; j++) {
  // a board's end joint: a short line across one board
  const i = Math.floor(rnd() * 36) - 18, t = 0.15 + rnd() * 0.8, y = FLOOR + t * (H - FLOOR), f = (y - VY) / (FLOOR - VY);
  floor += `<path d="M${r1(DX + i * 46 * f)} ${r1(y)} L${r1(DX + (i + 1) * 46 * f)} ${r1(y)}" stroke="${OL}" stroke-width="1.8" opacity=".4"/>`;
}
floor += `<rect x="-200" y="${FLOOR}" width="${W + 400}" height="18" fill="#3a1e0a" opacity=".18"/>`;
// the rug: a fringe, a gold border, berry-red velvet, a gold line inside
let rug = `<ellipse cx="${RUG.x}" cy="${RUG.y + 6}" rx="${RUG.rx + 4}" ry="${RUG.ry + 4}" fill="#3a1e0a" opacity=".28"/>`;
for (let i = 0; i < 72; i++) {
  const a = (i / 72) * Math.PI * 2, x = RUG.x + Math.cos(a) * (RUG.rx + 7), y = RUG.y + Math.sin(a) * (RUG.ry + 5);
  const x2 = RUG.x + Math.cos(a) * (RUG.rx + 15), y2 = RUG.y + Math.sin(a) * (RUG.ry + 9);
  rug += `<path d="M${r1(x)} ${r1(y)} L${r1(x2)} ${r1(y2)}" stroke="#fff1cf" stroke-width="2.6" stroke-linecap="round"/>`;
}
rug += `<ellipse cx="${RUG.x}" cy="${RUG.y}" rx="${RUG.rx + 6}" ry="${RUG.ry + 5}" fill="#f2c24a" stroke="${OL}" stroke-width="2.8"/>`
  + `<ellipse cx="${RUG.x}" cy="${RUG.y}" rx="${RUG.rx - 6}" ry="${RUG.ry - 4}" fill="url(#rugG)" stroke="#8a2034" stroke-width="2"/>`
  + `<ellipse cx="${RUG.x}" cy="${RUG.y}" rx="${RUG.rx - 26}" ry="${RUG.ry - 12}" fill="none" stroke="#ffd36a" stroke-width="2.2" stroke-dasharray="10 7" opacity=".85"/>`
  + `<ellipse cx="${RUG.x}" cy="${RUG.y - 2}" rx="${RUG.rx * 0.55}" ry="${RUG.ry * 0.42}" fill="#ffe2a0" opacity=".16"/>`;

// (The two brass wall lanterns at x 258 / 742 were taken out 2026-11-21, the user: "take out the 2 lamps and the two
// flags"; the page's banners went with them.)

// ---- the treasure: the app's coins and gems, and the group's chests ----
// Where the page's twinkles can pop (the user: "add the shiny flicker that pops on gold and gems, and on the legendary
// and rainbow chests"): coins near a heap's surface, every gem, and per group its Legendary and Rainbow chests' boxes,
// in the picture's units -> vault/spots.js (host.html). `REC` is on while the first treasure is drawn.
const SPOTS = { gold: [], gems: [], chests: {} };
let REC = false, GK = null;
const inOpening = (x, y) => (x - DX) ** 2 + (y - DY) ** 2 < (IR - 12) ** 2;
// A coin: the app's coin picture, standing (turned a little) or lying (squashed, with its gold edge under it).
function coin(x, y, size, rot, flat) {
  const k = size / 160, i = Math.floor(rnd() * COINS.length);
  if (!flat) return `<use href="#c${i}" transform="translate(${r1(x)} ${r1(y)}) rotate(${r1(rot)}) scale(${r1(k * 1000) / 1000}) translate(-80 -80)"/>`;
  const ky = k * 0.46;
  return `<ellipse cx="${r1(x)}" cy="${r1(y + size * 0.07)}" rx="${r1(size * 0.47)}" ry="${r1(size * 0.22)}" fill="#a8681a" stroke="${OL}" stroke-width="1.2"/>`
    + `<use href="#c${i}" transform="translate(${r1(x)} ${r1(y)}) rotate(${r1(rot * 0.15)}) scale(${r1(k * 1000) / 1000} ${r1(ky * 1000) / 1000}) translate(-80 -80)"/>`;
}
// A gem: one of the app's crystal gems, in a soft glow (they're pale on the gold without it), with a soft shadow
const gem = (x, y, size, rot = 0, i = Math.floor(rnd() * GEMS.length)) =>
  (REC && SPOTS.gems.push([r1(x), r1(y), r1(size)]), '')
  + `<circle cx="${r1(x)}" cy="${r1(y)}" r="${r1(size * 0.62)}" fill="url(#gemGlow)"/>`
  + `<ellipse cx="${r1(x)}" cy="${r1(y + size * 0.4)}" rx="${r1(size * 0.34)}" ry="${r1(size * 0.08)}" fill="#3a1e0a" opacity=".28"/>`
  + `<use href="#g${i}" transform="translate(${r1(x)} ${r1(y)}) rotate(${r1(rot)}) scale(${r1((size / 160) * 1000) / 1000}) translate(-80 -80)"/>`;
// A heap of coins: a gold hill (so no floor shows between the coins) covered in coins, back to front, a few gems on it
function heap(cx, y0, w, h, { n = Math.round((w * h) / 210), size = 34, gems = 0 } = {}) {
  const hw = w / 2, top = (u) => y0 - h * Math.pow(Math.max(0, 1 - u * u), 0.85);
  let g = `<path d="M${r1(cx - hw)} ${y0} C${r1(cx - hw * 0.62)} ${r1(y0 - h * 1.36)} ${r1(cx + hw * 0.62)} ${r1(y0 - h * 1.36)} ${r1(cx + hw)} ${y0} Z" fill="url(#heap)" stroke="${OL}" stroke-width="2.4"/>`;
  const items = [];
  for (let i = 0; i < n; i++) {
    const u = rnd() * 2 - 1, t = top(u * 0.97), y = t + 4 + Math.pow(rnd(), 1.4) * Math.max(0, y0 - t - 6);
    items.push({ x: cx + u * hw * 0.94, y, gem: false });
  }
  for (let i = 0; i < gems; i++) {
    const u = (rnd() * 2 - 1) * 0.75, t = top(u);
    items.push({ x: cx + u * hw, y: t + 6 + rnd() * h * 0.35, gem: true });
  }
  items.sort((a, b) => a.y - b.y);
  for (const it of items) {
    const d = Math.min(1, Math.max(0, (it.y - (y0 - h)) / h)), s = size * (0.82 + 0.3 * d);
    if (REC && !it.gem && it.y - top((it.x - cx) / hw) < (y0 - top((it.x - cx) / hw)) * 0.35 && (!heap.inside || inOpening(it.x, it.y))) SPOTS.gold.push([r1(it.x), r1(it.y), r1(s)]);
    g += it.gem ? gem(it.x, it.y - s * 0.3, s * 1.45, (rnd() - 0.5) * 34) : coin(it.x, it.y, s, (rnd() - 0.5) * 56, rnd() < 0.6);
  }
  return g;
}
// A stack of lying coins
function stack(x, y, n, size = 30) {
  let g = `<ellipse cx="${x}" cy="${y + size * 0.16}" rx="${r1(size * 0.6)}" ry="${r1(size * 0.16)}" fill="#3a1e0a" opacity=".3"/>`;
  for (let i = 0; i < n; i++) g += coin(x + (rnd() - 0.5) * 3.5, y - i * size * 0.17, size, 0, true);
  if (REC) SPOTS.gold.push([r1(x), r1(y - (n - 1) * size * 0.17), r1(size)]);
  return g;
}
// Scattered coins and gems on the floor
function scatter(x0, x1, y0, y1, n, size = 28) {
  const it = [];
  for (let i = 0; i < n; i++) it.push([x0 + rnd() * (x1 - x0), y0 + rnd() * (y1 - y0), rnd() < 0.22]);
  it.sort((a, b) => a[1] - b[1]);
  return it.map(([x, y, isGem]) => (isGem ? gem(x, y - 8, size * 1.2, (rnd() - 0.5) * 40) : coin(x, y, size * (0.85 + rnd() * 0.3), (rnd() - 0.5) * 60, rnd() < 0.7))).join('');
}
// One of the group's chests, drawn by the chest engine (CH: its picture per tier, see drawChests below): its foot's
// middle at (x, y), `w` wide (units), tilted `rot` degrees; a soft contact shadow under it, the room's warm light on it
let CH = null;
const TIERS = ['common', 'rare', 'epic', 'legendary', 'set'];
function chest(t, x, y, w, rot = 0) {
  const C = CH[t], k = w / C.cw;
  // (its box for the twinkles: the drawing is CHEST_PX wide with 16% room round it, its foot at fy)
  if (t === 'legendary' || t === 'set') (SPOTS.chests[GK] = SPOTS.chests[GK] || []).push([r1(x - w * 0.46), r1(y - (C.fy - Math.round(C.cw * 0.16)) * k * 0.94), r1(x + w * 0.46), r1(y - w * 0.06), t === 'set' ? 'rb' : 'lg']);
  return `<ellipse cx="${r1(x)}" cy="${r1(y - 2)}" rx="${r1(w * 0.58)}" ry="${r1(w * 0.1)}" fill="url(#contact)"/>`
    + `<use href="#k${t}" filter="url(#warmChest)" transform="translate(${r1(x)} ${r1(y)}) rotate(${rot}) scale(${Math.round(k * 100000) / 100000}) translate(${-C.fx} ${-C.fy})"/>`;
}
// a few gems together
function gems(x, y, n, size = 44) {
  let g = '';
  for (let i = 0; i < n; i++) g += gem(x + (i - (n - 1) / 2) * size * 0.55 + (rnd() - 0.5) * 6, y - (i % 2) * size * 0.3 + (rnd() - 0.5) * 4, size * (0.85 + rnd() * 0.3), (rnd() - 0.5) * 40);
  return g;
}
// a glass jar full of the app's gems
function jar(x, y) {
  let g = `<g transform="translate(${x} ${y})"><path d="M-26 -48 H26 V-36 Q36 -31 36 -17 V17 Q36 29 24 29 H-24 Q-36 29 -36 17 V-17 Q-36 -31 -26 -36Z" fill="#e8f6ff" opacity=".5" stroke="${OL}" stroke-width="2.8"/></g>`;
  for (let i = 0; i < 9; i++) g += `<use href="#g${i % GEMS.length}" transform="translate(${r1(x - 20 + (i % 3) * 20 + (rnd() - 0.5) * 4)} ${r1(y + 16 - Math.floor(i / 3) * 16)}) rotate(${r1((rnd() - 0.5) * 40)}) scale(0.15) translate(-80 -80)"/>`;
  g += `<g transform="translate(${x} ${y})"><rect x="-28" y="-57" width="56" height="12" rx="4" fill="#c98a4c" stroke="${OL}" stroke-width="2.4"/>`
    + `<path d="M-27 -16 V12" stroke="#ffffff" stroke-width="3.4" stroke-linecap="round" opacity=".6"/></g>`;
  return g;
}

// One corner's treasure, the left one as drawn (the right one is the same mirrored, with other chests): back to front
// so each chest stands in its heap and the next heap buries its foot. (The HUD covers the top middle, the hint the
// bottom middle from x ~296 to ~688.)
function corner(m, t) {
  const X = (x) => (m ? W - x : x), R = (r) => (m ? -r : r);
  const H_ = (cx, y0, w, h, o) => heap(X(cx), y0, w, h, o);
  let g = '';
  g += H_(64, 352, 380, 156, { gems: 10, size: 33 }); // the big heap up the corner wall
  g += chest(t[0], X(84), 304, 140, R(-4)); // half sunk in it
  g += H_(158, 330, 170, 52, { gems: 2, size: 31 }); // coins against its side
  g += chest(t[1], X(204), 334, 94, R(7)); // on the heap's shoulder
  g += H_(36, 396, 340, 96, { gems: 7 }); // the big chest's foot buried
  g += H_(196, 362, 110, 30, { size: 28, gems: 1 });
  g += chest(t[2], X(244), 404, 118, R(-3));
  g += H_(266, 414, 120, 32, { size: 28, gems: 1 }) + H_(196, 420, 110, 30, { size: 28 }); // against its foot
  g += H_(22, 490, 420, 124, { gems: 9 }); // the front heap
  g += chest(t[3], X(150), 462, 98, R(9)); // tumbled into it
  g += H_(100, 494, 190, 48, { gems: 3, size: 32 }) + H_(214, 486, 100, 28, { size: 28 }); // coins over its foot
  g += gems(X(262), 448, 3, 40) + stack(X(290), 452, 5, 27) + stack(X(232), 460, 8, 28);
  g += scatter(X(m ? 330 : 176), X(m ? 176 : 330), 424, 452, 10, 26);
  return g;
}

// The whole treasure for a group (the same heaps for every group: the random draw starts over each time)
function treasure() {
  seed = 4242;
  REC = SPOTS.gold.length === 0;
  SPOTS.chests[GK] = [];
  // the vault's opening: a bank of coins inside, gems on it (a mountain nearly to the top was tried and turned down:
  // the user, 2026-11-16, "not looking good, revert it")
  heap.inside = true;
  const inside = heap(DX, DY + IR + 6, IR * 2.3, 80, { n: 160, size: 27, gems: 5 });
  heap.inside = false;
  // heaps at the wainscot's foot beside the vault door, then the two corners
  let g = heap(322, 348, 150, 40, { size: 27, gems: 2 }) + heap(678, 348, 150, 40, { size: 27, gems: 2 });
  g += scatter(300, 360, 352, 372, 5, 24) + scatter(640, 700, 352, 372, 5, 24);
  g += corner(false, ['legendary', 'rare', 'epic', 'common']) + corner(true, ['set', 'epic', 'legendary', 'rare']);
  g += jar(724, 452);
  REC = false;
  return { inside, corners: g };
}

const svgOf = () => {
const { inside, corners } = treasure();
const chestPics = TIERS.map((t) => `<image id="k${t}" width="${CH[t].w}" height="${CH[t].h}" href="${CH[t].url}"/>`).join('');
return `<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 ${W} ${H}" preserveAspectRatio="xMidYMax slice" width="100%" height="100%">
<defs>
  ${COINS.map((u, i) => `<image id="c${i}" width="160" height="160" href="${u}"/>`).join('')}
  ${GEMS.map((u, i) => `<image id="g${i}" width="160" height="160" href="${u}"/>`).join('')}
  ${chestPics}
  <radialGradient id="contact"><stop offset="0" stop-color="#2a1204" stop-opacity=".5"/><stop offset=".6" stop-color="#2a1204" stop-opacity=".22"/><stop offset="1" stop-color="#2a1204" stop-opacity="0"/></radialGradient>
  <filter id="warmChest" color-interpolation-filters="sRGB"><feColorMatrix type="matrix" values="0.95 0.07 0 0 0.02  0.03 0.9 0.03 0 0.01  0.02 0.06 0.76 0 0  0 0 0 1 0"/></filter>
  <radialGradient id="gemGlow"><stop offset="0" stop-color="#fffbe8" stop-opacity=".85"/><stop offset=".55" stop-color="#fff2c0" stop-opacity=".45"/><stop offset="1" stop-color="#fff2c0" stop-opacity="0"/></radialGradient>
  <linearGradient id="heap" x1="0" y1="0" x2="0" y2="1"><stop offset="0" stop-color="#ffe07a"/><stop offset=".45" stop-color="#f2b830"/><stop offset="1" stop-color="#c98a1c"/></linearGradient>
  <linearGradient id="brass" x1="0" y1="0" x2="0" y2="1"><stop offset="0" stop-color="#fff1b0"/><stop offset=".35" stop-color="#f6c64e"/><stop offset=".75" stop-color="#d99a28"/><stop offset="1" stop-color="#a8681a"/></linearGradient>
  <linearGradient id="brassSide" x1="0" y1="0" x2="1" y2="0"><stop offset="0" stop-color="#b8781e"/><stop offset=".45" stop-color="#f6c64e"/><stop offset=".7" stop-color="#ffe08a"/><stop offset="1" stop-color="#c98a24"/></linearGradient>
  <radialGradient id="rivet" cx=".35" cy=".3" r=".8"><stop offset="0" stop-color="#fff8d8"/><stop offset=".5" stop-color="#f2c24a"/><stop offset="1" stop-color="#a8681a"/></radialGradient>
  <radialGradient id="opening" cx=".5" cy=".8" r=".85"><stop offset="0" stop-color="#fff4cf"/><stop offset=".3" stop-color="#ffd27a"/><stop offset=".65" stop-color="#e09a3c"/><stop offset="1" stop-color="#9a5420"/></radialGradient>
  <linearGradient id="openTop" x1="0" y1="0" x2="0" y2="1"><stop offset="0" stop-color="#5a2a0c" stop-opacity=".45"/><stop offset="1" stop-color="#5a2a0c" stop-opacity="0"/></linearGradient>
  <clipPath id="openClip"><circle cx="${DX}" cy="${DY}" r="${IR}"/></clipPath>
  <radialGradient id="doorHalo"><stop offset=".45" stop-color="#ffe2a0" stop-opacity=".42"/><stop offset="1" stop-color="#ffe2a0" stop-opacity="0"/></radialGradient>
  <radialGradient id="bulbGlow"><stop offset="0" stop-color="#fff1b0" stop-opacity=".7"/><stop offset="1" stop-color="#ffcf6a" stop-opacity="0"/></radialGradient>
  <linearGradient id="floorG" x1="0" y1="0" x2="0" y2="1"><stop offset="0" stop-color="#c88a50"/><stop offset=".5" stop-color="#d9a066"/><stop offset="1" stop-color="#c58750"/></linearGradient>
  <radialGradient id="rugG" cx=".5" cy=".4" r=".7"><stop offset="0" stop-color="#e2566a"/><stop offset=".7" stop-color="#c23a50"/><stop offset="1" stop-color="#9e2840"/></radialGradient>
  <radialGradient id="warm" cx=".5" cy=".55" r=".6"><stop offset="0" stop-color="#fff0c8" stop-opacity=".16"/><stop offset="1" stop-color="#fff0c8" stop-opacity="0"/></radialGradient>
  <radialGradient id="vig" cx=".5" cy=".5" r=".72"><stop offset=".6" stop-color="#3a1a06" stop-opacity="0"/><stop offset="1" stop-color="#3a1a06" stop-opacity=".5"/></radialGradient>
</defs>
<rect x="-200" y="-100" width="${W + 400}" height="${H + 200}" fill="#c88a50"/>
${wall}${door.replace('@@INSIDE@@', inside)}${floor}${rug}${beam}${lights}${corners}
<rect x="-200" y="-100" width="${W + 400}" height="${H + 200}" fill="url(#warm)"/>
<rect x="-200" y="-100" width="${W + 400}" height="${H + 200}" fill="url(#vig)"/>
</svg>`;
};

// The chest engine (the design's chest-models.js + chest-<group>.js), in a page of its own: each tier drawn at rest,
// CHEST_PX wide, with no glow or shadow, its foot's middle at (fx, fy) in the picture
const DESIGN = path.join(HERE, '..', 'design-v6');
const CHEST_PX = 660; // (the biggest chest is ~140 units = ~330 px on the A15: drawn at twice that)
const ENGINE = ['chest-models.js', 'chest-fruit.js', 'chest-ocean.js', 'chest-pet.js', 'chest-kit.js', 'chest-forest.js', 'chest-sky.js', 'chest-dream.js', 'chest-bakery.js', 'chest-heroes.js', 'chest-elemental.js', 'chest-spooky.js'];
async function drawChests(pg, gk) {
  return pg.evaluate(({ gk, px, tiers }) => {
    const CM = window.ChestModels, IDW = (x, y, o) => { o[0] = x; o[1] = y; }, out = {};
    tiers.forEach((t, ti) => {
      const m = CM.model(gk, ti), bb = m.bb, s = px / (bb.x1 - bb.x0), pad = Math.round(px * 0.16);
      const cv = document.createElement('canvas');
      cv.width = Math.ceil(px + pad * 2); cv.height = Math.ceil((6 - bb.y0) * s + pad * 2);
      const c = cv.getContext('2d');
      c.translate(pad - bb.x0 * s, pad - bb.y0 * s); c.scale(s, s);
      for (const p of m.parts) CM._drawPart(c, p, IDW, 0, 0);
      out[t] = { url: cv.toDataURL('image/png'), w: cv.width, h: cv.height, cw: px, fx: Math.round(pad + px / 2), fy: Math.round(pad + (4 - bb.y0) * s) };
    });
    return out;
  }, { gk, px: CHEST_PX, tiers: TIERS });
}

fs.mkdirSync(OUT, { recursive: true });
const browser = await chromium.launch();
const engine = await browser.newPage();
await engine.setContent('<!doctype html><html><body></body></html>');
for (const f of ENGINE) await engine.addScriptTag({ path: path.join(DESIGN, f) });
await engine.waitForFunction((gs) => window.ChestModels && gs.every((g) => window.ChestModels.groups.includes(g)), GROUP_KEYS);
const page = await browser.newPage({ viewport: { width: 832, height: 384 }, deviceScaleFactor: 2340 / 832 });
for (const gk of GROUP_KEYS) {
  GK = gk;
  CH = await drawChests(engine, gk);
  const svg = svgOf(); // (every group's, for its chests' twinkle boxes; drawn only when asked)
  if (ONLY && gk !== ONLY) continue;
  await page.setContent(`<!doctype html><html><body style="margin:0;width:100vw;height:100vh;background:#c88a50">${svg}</body></html>`);
  await page.waitForTimeout(400); // (the pictures are data: addresses, decoded a moment after the page)
  const png = await page.screenshot({ type: 'png' });
  // (WebP: about half a JPEG's size at the same look; the phone's WebView shows it)
  const webp = await page.evaluate(async (b64) => {
    const im = new Image();
    im.src = 'data:image/png;base64,' + b64;
    await im.decode();
    const c = document.createElement('canvas');
    c.width = im.naturalWidth; c.height = im.naturalHeight;
    c.getContext('2d').drawImage(im, 0, 0);
    return c.toDataURL('image/webp', 0.86).split(',')[1];
  }, png.toString('base64'));
  const f = path.join(OUT, `${gk}.webp`);
  fs.writeFileSync(f, Buffer.from(webp, 'base64'));
  console.log(path.relative(process.cwd(), f), Math.round(fs.statSync(f).size / 1024) + ' KB');
}
await browser.close();
// (gems in the opening: only those inside it)
SPOTS.gems = SPOTS.gems.filter(([x, y]) => !((x - DX) ** 2 + (y - DY) ** 2 < (IR + 30) ** 2) || inOpening(x, y));
fs.writeFileSync(path.join(OUT, 'spots.js'), `// Generated by tools/chest/vault-room.mjs — don't edit.
// Where the vault room's twinkles pop (host.html), in the picture's units (${W} x ${H}): coins [x, y, size], gems
// [x, y, size], and per group its Legendary ('lg') and Rainbow ('rb') chests' boxes [x0, y0, x1, y1, kind].
window.VAULT_SPOTS = ${JSON.stringify(SPOTS)};
`);
console.log('spots:', SPOTS.gold.length, 'coins,', SPOTS.gems.length, 'gems,', Object.keys(SPOTS.chests).length, 'groups of chests');
