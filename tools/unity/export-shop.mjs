// The Shop's, the chests' and the Level Road's pieces for Unity (unity/Assets/Resources/Shop/ and Resources/Chests/;
// the code is unity/Assets/Scripts/Screens/Shop, Chests and Road). The screens change with the player (prices, counts,
// which chests are HOT today), so the Unity code draws them; what's copied here is what doesn't change:
//   Shop/img/gc/<group>-<look>.png   the design's group chests (src/squad/groupChestArt.js): '<size>-grow' (480 x 400),
//                                    'common-tile', 'rare-tile' (600 x 384), 'legendary-deal' (448 x 424)
//   Shop/img/gc/bg-<group>.jpg       each group's card backdrop (800 x 464; opaque, so JPEG)
//   Shop/img/coin-<i>.png, gem-<i>   the currency art (src/squad/currencyArt.js, 160 x 160): coins stamped with
//                                    mittens, pip, bao, dunkie, boo, jelli; gems shaped like mittens, jelli, twinkle...
//   Shop/img/crown.png               the season pass's crown
//   Shop/shop.json                   functions/squad.js's tables the screens read (groups, roster flags, chest sizes,
//                                    prices and odds, the deal, the swaps, copies, the default offers and level road),
//                                    the chests' names, the products' fallback prices (src/economy.js)
//   Chests/vault-*.png|jpg           "To the treasure vault" (src/components/VaultLoader.js): the table, the map, the
//                                    glow (no bar); vault.json its layout (src/components/vaultArt.js)
//   Chests/paw.png, paw.json       the vault coin's 🐾 (no picture of the squishy), as Chrome draws it
//   Chests/vault/<group>.jpg         each group's vault room the chest is smashed in, spots.json where its twinkles pop
//                                    (android/app/src/main/assets/chest/vault)
//   Chests/models.json               Chest Smash v2's chest models (chest-models.js + chest-<group>.js), built by the
//                                    design's own code: every group's five chests as data (parts, shapes as path
//                                    commands, paints, materials), drawn and damaged by Screens/Chests/ChestEngine.cs
//   Chests/icons.json                the loot icons (drawIcon / the groups' ICONS), recorded as canvas calls at size 100
//                                    with the colour as "#COL", replayed by Screens/Chests/Canvas2D.cs
//   Shop/twinkle.json, img/twinkle-* Twinkle's ✦ with its glow, as Chrome draws it (no font here has it)
//   Shop/orb-close36.xml             cut out of the app (Expo web, src/web/Preview.js "shop-…"): the sheets' 36 dp
//                                    close orb (royal/parts.js Orb)
// node tools/unity/export-shop.mjs [--no-page]   (--no-page: only the files that don't need the page)
import fs from 'node:fs';
import path from 'node:path';
import vm from 'node:vm';
import { execFileSync } from 'node:child_process';
import { fileURLToPath, pathToFileURL } from 'node:url';

const ROOT = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '..', '..');
const SHOP = path.join(ROOT, 'unity', 'Assets', 'Resources', 'Shop');
const CHESTS = path.join(ROOT, 'unity', 'Assets', 'Resources', 'Chests');
for (const d of [path.join(SHOP, 'img', 'gc'), CHESTS]) fs.mkdirSync(d, { recursive: true });

// PNG (RGBA, optimized) or JPEG (opaque pictures), through Pillow
const PY = 'import sys; from PIL import Image; im = Image.open(sys.argv[1]); q = int(sys.argv[3]);\n'
  + 'im.convert("RGB").save(sys.argv[2], quality=q, subsampling=0) if q else im.convert("RGBA").save(sys.argv[2], optimize=True)';
const conv = (src, dst, q = 0) => execFileSync('python3', ['-c', PY, src, dst, String(q)]);

// ---- the group chests --------------------------------------------------------------------------------------------
const gcSrc = fs.readFileSync(path.join(ROOT, 'src', 'squad', 'groupChestArt.js'), 'utf8');
const CHEST_NAMES = JSON.parse(/CHEST_NAMES = (\{.*?\});/s.exec(gcSrc)[1]);
let nArt = 0;
for (const m of gcSrc.matchAll(/require\('\.\.\/\.\.\/assets\/squad\/gchests\/([a-z0-9-]+)\.webp'\)/g)) {
  const name = m[1];
  const src = path.join(ROOT, 'assets', 'squad', 'gchests', name + '.webp');
  if (name.startsWith('bg-')) conv(src, path.join(SHOP, 'img', 'gc', name + '.jpg'), 90);
  else conv(src, path.join(SHOP, 'img', 'gc', name + '.png'));
  nArt++;
}
console.log(`group chests: ${nArt} pictures`);
const curSrc = fs.readFileSync(path.join(ROOT, 'src', 'squad', 'currencyArt.js'), 'utf8');
for (const [kind, re] of [['coin', /COIN = \[(.*?)\];/s], ['gem', /GEM = \[(.*?)\];/s]]) {
  [...re.exec(curSrc)[1].matchAll(/currency\/([a-z-]+)\.png/g)].forEach((m, i) => conv(path.join(ROOT, 'assets', 'squad', 'currency', m[1] + '.png'), path.join(SHOP, 'img', `${kind}-${i}.png`)));
}
conv(path.join(ROOT, 'assets', 'squad', 'crown.png'), path.join(SHOP, 'img', 'crown.png'));

// ---- the tables ----------------------------------------------------------------------------------------------------
const squad = (await import(pathToFileURL(path.join(ROOT, 'functions', 'squad.js')).href)).default;
const econ = fs.readFileSync(path.join(ROOT, 'src', 'economy.js'), 'utf8');
const PRODUCTS = {};
for (const m of /export const PRODUCTS = \{(.*?)\n\};/s.exec(econ)[1].matchAll(/(\w+): \{ base: '([a-z0-9_]+)', usd: ([\d.]+)/g)) PRODUCTS[m[1]] = { base: m[2], usd: +m[3] };
const shop = {
  groups: squad.GROUPS,
  sets: squad.SETS,
  season: squad.SEASON,
  hidden: squad.HIDDEN,
  roster: squad.ROSTER.map((c) => ({ id: c.id, key: c.key, name: c.name, set: c.set, rar: c.rar, reward: c.reward, pass: c.pass, base: c.base })),
  setOf: squad.SET_OF,
  sizes: squad.SIZES,
  upgrade: squad.UPGRADE,
  copies: squad.COPIES,
  deal: squad.GDEAL,
  adChests: squad.AD_CHESTS,
  freeMs: squad.FREE_MS,
  swaps: squad.SWAPS,
  start: squad.START,
  rainbow: squad.RAINBOW,
  setRewards: squad.SET_REWARDS,
  offers: squad.DEFAULT_OFFERS,
  levels: squad.levelsOf(null),
  chestNames: CHEST_NAMES,
  products: PRODUCTS,
  dupeCoins: Object.fromEntries(squad.SIZES.map((t) => [t.k, squad.dupeCoinsFor(t.k)])),
};
fs.writeFileSync(path.join(SHOP, 'shop.json'), JSON.stringify(shop));
console.log(`shop.json: ${shop.roster.length} creatures, ${shop.offers.offers.length} offers, road of ${shop.levels.road.length}`);

// ---- the treasure vault ----------------------------------------------------------------------------------------------
const ROYAL = path.join(ROOT, 'assets', 'royal');
conv(path.join(ROYAL, 'vault-table.jpg'), path.join(CHESTS, 'vault-table.jpg'), 92);
conv(path.join(ROYAL, 'vault-map.webp'), path.join(CHESTS, 'vault-map.png'));
conv(path.join(ROYAL, 'vault-glow.png'), path.join(CHESTS, 'vault-glow.png'));   // (no bar, so no fill or key, since 2026-11-16)
const va = fs.readFileSync(path.join(ROOT, 'src', 'components', 'vaultArt.js'), 'utf8');
const vault = {};
for (const m of va.matchAll(/export const (\w+) = (.*?);\n/g)) vault[m[1]] = JSON.parse(m[2]);
fs.writeFileSync(path.join(CHESTS, 'vault.json'), JSON.stringify(vault));
const CHEST_DIR = path.join(ROOT, 'android', 'app', 'src', 'main', 'assets', 'chest');
// each group's own vault room (2026-11-18: one room per group, tools/chest/vault-room.mjs) and where its twinkles pop
fs.mkdirSync(path.join(CHESTS, 'vault'), { recursive: true });
for (const f of fs.readdirSync(path.join(CHEST_DIR, 'vault'))) if (f.endsWith('.webp')) conv(path.join(CHEST_DIR, 'vault', f), path.join(CHESTS, 'vault', f.replace('.webp', '.jpg')), 90);
{
  const w = {};
  vm.runInNewContext(fs.readFileSync(path.join(CHEST_DIR, 'vault', 'spots.js'), 'utf8'), { window: w });
  fs.writeFileSync(path.join(CHESTS, 'vault', 'spots.json'), JSON.stringify(w.VAULT_SPOTS));
}

// ---- the chest models, built by the design's own code ----------------------------------------------------------------
const ctx = { console, Math: Object.create(Math), performance: { now: () => 0 } };
ctx.window = ctx;
// (the models don't roll anything while they're built: fin()'s `peeks` do, and Unity rolls those itself)
let rolls = 0;
ctx.Math.random = () => (rolls++, 0.5);
vm.createContext(ctx);
const SCRIPTS = ['chest-models.js', 'chest-fruit.js', 'chest-ocean.js', 'chest-pet.js', 'chest-kit.js', 'chest-forest.js', 'chest-sky.js', 'chest-dream.js', 'chest-bakery.js', 'chest-heroes.js', 'chest-elemental.js', 'chest-spooky.js'];
for (const f of SCRIPTS) vm.runInContext(fs.readFileSync(path.join(CHEST_DIR, f), 'utf8'), ctx, { filename: f });
const CM = ctx.ChestModels;
const shape = (s) => {
  const o = {};
  for (const k of ['d', 'clip', 'f', 's', 'w', 'a', 'op', 'g', 'gb', 'txt', 'x', 'y', 'font', 'rot']) if (s[k] !== undefined) o[k] = s[k];
  if (o.d) o.d = CM.H.P_(o.d);
  if (o.clip) o.clip = CM.H.P_(o.clip);
  return o;
};
const models = {};
for (const g of CM.groups) {
  models[g] = [];
  for (let t = 0; t < 5; t++) {
    rolls = 0;
    const m = CM.model(g, t);
    const peekRolls = rolls;
    models[g].push({
      name: m.name, mat: m.mat, hp: m.hp, W: m.W, H: m.H, ko: m.ko, pieN: m.pieN, ring: m.ring, rows: m.rows, loot: m.loot,
      hull: CM.H.P_(m.hull), rolls: peekRolls,
      parts: m.parts.map((p) => {
        const o = { id: p.id, sh: p.sh.map(shape) };
        for (const k of ['launch', 'launchV', 'tear', 'hang', 'loose', 'hmax', 'hdir']) if (p[k] !== undefined) o[k] = p[k];
        if (p.scar) o.scar = p.scar.map(shape);
        return o;
      }),
    });
  }
}
// (numbers to 1/1000 of a unit: the chests are ~300 units across)
const r3 = (k, v) => (typeof v === 'number' && !Number.isInteger(v) ? Math.round(v * 1000) / 1000 : v);
fs.writeFileSync(path.join(CHESTS, 'models.json'), JSON.stringify({ groups: CM.groups, mat: CM.MAT, crack: CM.CRACK, tier: CM.TIER, models }, r3));
console.log(`models.json: ${CM.groups.length} groups x 5, ${(fs.statSync(path.join(CHESTS, 'models.json')).size / 1e6).toFixed(2)} MB`);

// the loot icons as canvas calls: a recording 2D context at size 100, colour "#COL"
function recorder() {
  const ops = [];
  const grad = (kind, args) => { const g = { kind, args, stops: [] }; g.addColorStop = (o, c) => g.stops.push([o, c]); return g; };
  const style = (v) => (v && typeof v === 'object' && v.kind ? { g: v.kind, a: v.args, s: v.stops } : v);
  const c = {};
  for (const m of ['beginPath', 'closePath', 'moveTo', 'lineTo', 'quadraticCurveTo', 'bezierCurveTo', 'arc', 'ellipse', 'rect', 'fill', 'stroke', 'fillRect', 'strokeRect', 'save', 'restore', 'translate', 'rotate', 'scale', 'clip', 'fillText', 'setLineDash'])
    c[m] = (...a) => ops.push([m, ...a]);
  c.createLinearGradient = (...a) => grad('l', a);
  c.createRadialGradient = (...a) => grad('r', a);
  for (const p of ['fillStyle', 'strokeStyle', 'lineWidth', 'lineJoin', 'lineCap', 'globalAlpha', 'font', 'textAlign', 'textBaseline', 'globalCompositeOperation', 'shadowBlur', 'shadowColor'])
    Object.defineProperty(c, p, { set: (v) => ops.push(['set', p, style(v)]), get: () => undefined });
  return { c, ops };
}
const icons = {};
const kinds = new Set(['fry', 'coin', 'drop', 'star', 'gem', ...Object.keys(CM.ICONS)]);
for (const g of CM.groups) for (const m of models[g]) m.loot.forEach((k) => kinds.add(k));
const drawIcon = vm.runInContext('(function(){ return function (c, k, s, col) { return ChestModels._drawIcon ? ChestModels._drawIcon(c, k, s, col) : null; }; })()', ctx);
// (drawIcon isn't exported: the stage's particles call it; reach it through a loot particle)
const stage = Object.create(CM.Stage.prototype);
for (const k of kinds) {
  const { c, ops } = recorder();
  if (!drawIcon(c, k, 100, '#COL')) stage.drawP.call(stage, c, { type: 'loot', k, s: 100, c: '#COL', t: 0, life: 10, x: 0, y: 0, r: 0 });
  // (drawP wraps it in save / globalAlpha / translate / rotate / restore: keep what's between)
  const a = ops.findIndex((o) => o[0] === 'rotate'), b = ops.length - 1;
  icons[k] = ops.slice(a + 1, b);
}
fs.writeFileSync(path.join(CHESTS, 'icons.json'), JSON.stringify(icons, r3));
console.log(`icons.json: ${Object.keys(icons).length} icons`);
if (process.argv.includes('--no-page')) process.exit(0);

// ---- pieces cut out of the app ---------------------------------------------------------------------------------------
const { openApp, snap } = await import('./ui/snap-page.mjs');
const { browser, page, errors } = await openApp('http://localhost:8081/?phone=1&preview=1&card=none');
await page.waitForTimeout(5000);
const show = async (name, ms = 3000) => {
  await page.evaluate((c) => window.__preview(c), name);
  await page.waitForTimeout(ms);
};
const unstage = () => page.evaluate(() => window.__components('Stage').forEach((s) => (s.el.firstElementChild.style.transform = 'none')));
const clean = (svg) => svg.split(' style="transform: none !important;"').join('');
async function save(name, handle) {
  const s = await snap(page, handle);
  let svg = clean(s.svg), n = 0;
  for (const data of new Set(Object.values(s.images))) {
    const file = `${name}-${n++}`;
    const tmp = path.join(SHOP, 'img', file + '.src');
    fs.writeFileSync(tmp, Buffer.from(data.split(',')[1], 'base64'));
    conv(tmp, path.join(SHOP, 'img', file + '.png'));
    fs.unlinkSync(tmp);
    svg = svg.split(`href="${data}"`).join(`href="Shop/img/${file}"`);
  }
  fs.writeFileSync(path.join(SHOP, name + '.xml'), svg);
  console.log(`${name}.xml ${s.w.toFixed(2)} x ${s.h.toFixed(2)}`);
}
// the sheets' close orb (royal Orb, 36 dp): open the odds sheet from the Daily tab's "Drop odds"
await show('shop-daily');
await page.getByText('Drop odds', { exact: true }).click();
await page.waitForTimeout(1200);
await unstage();
const orbs = await page.evaluate(() => window.__components('Orb').map((o) => o.props.icon + ':' + (o.props.size || 40)));
await save('orb-close36', await page.evaluateHandle((i) => window.__components('Orb')[i].el, orbs.indexOf('close:36')));
// Twinkle's ✦ (candy/Sparkles.js; no font of the app has it): Chrome draws it with the Text's own font and its glow
// (textShadow 0 0 8 rgba(255,200,245,0.95)), at the device's density, for each size and colour the Deals and Special offers tabs use
// (the last three: the Special offers' mountains of gems and coins, ShopDeals.js Mountain)
await show('shop-deals');
const tw = await page.evaluate(async (list) => {
  const el = window.__components('Twinkle')[0].el;
  const cs = getComputedStyle(el);
  const out = {};
  for (const [size, color] of list) {
    const k = window.devicePixelRatio, M = 12, lh = size * 1.1;
    const font = `${cs.fontWeight} ${size}px ${cs.fontFamily}`;
    const c = document.createElement('canvas');
    const g0 = c.getContext('2d');
    g0.font = font;
    const m = g0.measureText('✦');
    const w = m.width;
    c.width = Math.ceil((w + 2 * M) * k);
    c.height = Math.ceil((lh + 2 * M) * k);
    const g = c.getContext('2d');
    g.scale(k, k);
    g.font = font;
    g.fillStyle = color;
    g.shadowColor = 'rgba(255,200,245,0.95)';
    g.shadowBlur = 8 * k;
    const base = m.fontBoundingBoxAscent + (lh - m.fontBoundingBoxAscent - m.fontBoundingBoxDescent) / 2;
    g.fillText('✦', M, M + base);
    out[`${size}${color}`] = { w, h: lh, px: -M, py: -M, pw: c.width / k, ph: c.height / k, png: c.toDataURL('image/png') };
  }
  return out;
}, [[14, '#fff3a0'], [10, '#ffffff'], [14, '#ffffff'], [10, '#fff3a0'], [12, '#ffffff'], [12, '#ffd84a'], [9, '#ffffff'], [11, '#d9c4ff'], [11, '#fff3a0'], [8, '#ffffff']]);
const twinkle = {};
let ti = 0;
for (const [key, v] of Object.entries(tw)) {
  const file = `twinkle-${ti++}`;
  fs.writeFileSync(path.join(SHOP, 'img', file + '.png'), Buffer.from(v.png.split(',')[1], 'base64'));
  twinkle[key] = { file, w: v.w, h: v.h, px: v.px, py: v.py, pw: v.pw, ph: v.ph };
}
fs.writeFileSync(path.join(SHOP, 'twinkle.json'), JSON.stringify(twinkle, null, 1));
console.log(`twinkle: ${Object.keys(twinkle).length}`);
// the treasure vault's paw (its coin with no picture of the squishy): 🐾 as Chrome draws it in the Text's own font, at
// 48 px and the device's density, with its box (advance x line height)
await show('vault', 1500);
const paw = await page.evaluate(() => {
  const el = [...document.querySelectorAll('div')].find((e) => e.childNodes.length === 1 && e.textContent === '🐾');
  const cs = getComputedStyle(el);
  const k = window.devicePixelRatio, size = 48, M = 4;
  const font = `${cs.fontWeight} ${size}px ${cs.fontFamily}`;
  const d = document.createElement('div');
  d.style.cssText = `position:absolute;left:0;top:0;white-space:pre;font:${font};line-height:normal`;
  d.textContent = '🐾';
  document.body.appendChild(d);
  const box = d.getBoundingClientRect();
  d.remove();
  const c = document.createElement('canvas');
  const g0 = c.getContext('2d');
  g0.font = font;
  const m = g0.measureText('🐾');
  c.width = Math.ceil((box.width + 2 * M) * k);
  c.height = Math.ceil((box.height + 2 * M) * k);
  const g = c.getContext('2d');
  g.scale(k, k);
  g.font = font;
  const base = m.fontBoundingBoxAscent + (box.height - m.fontBoundingBoxAscent - m.fontBoundingBoxDescent) / 2;
  g.fillText('🐾', M, M + base);
  return { w: box.width, h: box.height, px: -M, py: -M, pw: c.width / k, ph: c.height / k, png: c.toDataURL('image/png') };
});
fs.writeFileSync(path.join(CHESTS, 'paw.png'), Buffer.from(paw.png.split(',')[1], 'base64'));
delete paw.png;
fs.writeFileSync(path.join(CHESTS, 'paw.json'), JSON.stringify(paw));
console.log('paw', JSON.stringify(paw));
if (errors.length) console.log('page errors:', errors.slice(0, 3).join(' | '));
await browser.close();
