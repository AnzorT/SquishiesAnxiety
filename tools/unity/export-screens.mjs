// The menu's screens' pieces for Unity (unity/Assets/Resources/Screens/): Achievements, the daily streak, the daily
// challenges sheet, Settings, Stats and the Daily Spin (unity/Assets/Scripts/Screens). Most of those screens change
// with the player (numbers, names, which day is today), so the Unity code draws them (the way tools/unity/ui/snap.js
// writes what Chrome paints); what's cut out of the app here is what doesn't change:
//   img/rays.png, img/wood-bg.png      PageBg's rays and WoodBg's planks (assets/royal), as PNG
//   img/chest-silver.png               the streak's FREE CHEST (squad/ui.js Chest: assets/squad/chests/silver-0)
//   orb-back|left|right.xml            the royal kit's orb buttons (royal/parts.js Orb, 40 dp), from Achievements
//   orb-close34.xml                    the 34 dp close orb over Settings' Test wallet
//   round-close.xml                    the daily sheet's close button (candy RoundButton 36 + CloseGlyph)
//   coin-candy.xml                     candy/Coin.js CoinIcon (the streak's prize tiles), drawn at 24.96 dp
//   coin.xml, gem.xml                  squad/ui.js CoinIcon / GemIcon (26 dp, the wheel's slices)
//   emoji/*.png, emoji.json            the characters no font of the app has (🔥 on the streak badges, ⏱ on the
//                                      streak's clock), drawn by Chrome alone, with their boxes and advances
//   roster.json                        functions/squad.js's roster (ids, names, rarity, groups, set members): what
//                                      the achievements count
// Expo web on http://localhost:8081 (src/web/Preview.js "scr-…"; `npx expo start --web --port 8081`).
// node tools/unity/export-screens.mjs [--no-page]   (--no-page: only the files that don't need the page)
import fs from 'node:fs';
import path from 'node:path';
import { execFileSync } from 'node:child_process';
import { openApp, snap, ROOT } from './ui/snap-page.mjs';

const OUT = path.join(ROOT, 'unity', 'Assets', 'Resources', 'Screens');
fs.mkdirSync(path.join(OUT, 'img'), { recursive: true });
fs.mkdirSync(path.join(OUT, 'emoji'), { recursive: true });

// ---- files straight from the repository -------------------------------------------------------------------------
const toPng = (src, dst) => execFileSync('python3', ['-c', 'import sys; from PIL import Image; Image.open(sys.argv[1]).convert("RGBA").save(sys.argv[2], optimize=True)', src, dst]);
toPng(path.join(ROOT, 'assets', 'royal', 'rays.png'), path.join(OUT, 'img', 'rays.png'));
toPng(path.join(ROOT, 'assets', 'royal', 'wood-bg.jpg'), path.join(OUT, 'img', 'wood-bg.png'));
toPng(path.join(ROOT, 'assets', 'squad', 'chests', 'silver-0.webp'), path.join(OUT, 'img', 'chest-silver.png'));

const squad = (await import(path.join(ROOT, 'functions', 'squad.js'))).default;
const roster = {
  rarity: squad.RARITY,
  sets: squad.SETS,
  setOf: Object.entries(squad.SET_OF).map(([key, s]) => ({ key, ids: s.ids, reward: s.reward })),
  creatures: squad.ROSTER.map((c) => ({ id: c.id, key: c.key, name: c.name, set: c.set, rar: c.rar })),
};
fs.writeFileSync(path.join(OUT, 'roster.json'), JSON.stringify(roster));
console.log(`roster.json: ${roster.creatures.length} creatures`);
if (process.argv.includes('--no-page')) process.exit(0);

// ---- cut out of the app's screens --------------------------------------------------------------------------------
const { browser, page, errors } = await openApp('http://localhost:8081/?phone=1&preview=1&card=none');
await page.waitForTimeout(5000);
const show = async (name, ms = 2500) => {
  await page.evaluate((c) => window.__preview(c), name);
  await page.waitForTimeout(ms);
};
// pieces inside a Stage (royal/parts.js: the design's 393-tall units scaled to the phone) are cut in those units:
// the Stage's scale is taken off first
const unstage = () => page.evaluate(() => window.__components('Stage').forEach((s) => (s.el.firstElementChild.style.transform = 'none')));
const clean = (svg) => svg.split(' style="transform: none !important;"').join('');
// a piece's SVG; its pictures (inlined as data URLs by snap) become PNG files in img/, named after the piece
async function save(name, handle) {
  const s = await snap(page, handle);
  let svg = clean(s.svg), n = 0;
  for (const data of new Set(Object.values(s.images))) {
    const file = `${name}-${n++}`;
    fs.writeFileSync(path.join(OUT, 'img', file + '.src'), Buffer.from(data.split(',')[1], 'base64'));
    toPng(path.join(OUT, 'img', file + '.src'), path.join(OUT, 'img', file + '.png'));
    fs.unlinkSync(path.join(OUT, 'img', file + '.src'));
    svg = svg.split(`href="${data}"`).join(`href="Screens/img/${file}"`);
  }
  fs.writeFileSync(path.join(OUT, name + '.xml'), svg);
  console.log(`${name}.xml ${s.w.toFixed(2)} x ${s.h.toFixed(2)}`);
}
const comp = (name, i = 0) => page.evaluateHandle(([n, i]) => window.__components(n)[i].el, [name, i]);

await show('scr-achievements');
await unstage();
// Orb's Pressable: back, then the two arrows (left, right)
const orbs = await page.evaluate(() => window.__components('Orb').map((o) => o.props.icon));
for (const icon of ['back', 'left', 'right']) await save('orb-' + icon, await comp('Orb', orbs.indexOf(icon)));

await show('scr-settings-tester');
await unstage();
await page.getByText('Test wallet', { exact: true }).last().click();
await page.waitForTimeout(800);
await unstage();
const sorbs = await page.evaluate(() => window.__components('Orb').map((o) => o.props.icon));
await save('orb-close34', await comp('Orb', sorbs.indexOf('close')));

await show('scr-daily');
await save('round-close', await comp('RoundButton'));

await show('scr-streak');
// the candy coin on day 1's tile (32 * 0.78 dp)
await save('coin-candy', await comp('CoinIcon'));

await show('scr-spin');
// the wheel's slice icons: the <svg> of squad/ui.js CoinIcon / GemIcon (26 dp), each in its own 26 x 26 view
for (const [name, mark] of [['coin', '_cf"'], ['gem', '_gt"']]) {
  const h = await page.evaluateHandle((m) => [...document.querySelectorAll('svg')].find((s) => s.getAttribute('viewBox') === '0 0 64 64' && s.innerHTML.includes(m)).parentElement, mark);
  await save(name, h);
}

// ---- the characters no font has: Chrome draws each on its own (as snap-page.mjs does), at the device's density ----
const EMOJI = [
  { name: 'fire-40', ch: '🔥', font: 'Fredoka_700Bold', size: 40 },
  { name: 'fire-30', ch: '🔥', font: 'Fredoka_700Bold', size: 30 },
  { name: 'timer-11', ch: '⏱', font: 'Nunito_900Black', size: 11 },
];
const emoji = {};
for (const e of EMOJI) {
  const r = await page.evaluate(async (e) => {
    // its box and advance as a Text lays it out
    const d = document.createElement('div');
    d.style.cssText = `position:absolute;left:0;top:0;white-space:pre;font-family:${e.font};font-size:${e.size}px;line-height:normal`;
    d.textContent = e.ch;
    document.body.appendChild(d);
    const range = document.createRange();
    range.selectNodeContents(d.firstChild);
    const b = range.getBoundingClientRect();
    const box = d.getBoundingClientRect();
    d.remove();
    const c = document.createElement('canvas');
    const k = window.devicePixelRatio;
    c.width = Math.ceil(b.width * k);
    c.height = Math.ceil(b.height * k);
    const g = c.getContext('2d');
    g.scale(k, k);
    g.font = `${e.size}px ${e.font}`;
    g.textBaseline = 'alphabetic';
    const m = g.measureText(e.ch);
    const base = m.fontBoundingBoxAscent + (b.height - m.fontBoundingBoxAscent - m.fontBoundingBoxDescent) / 2;
    g.fillText(e.ch, 0, base);
    return { w: b.width, h: b.height, adv: m.width, lineH: box.height, base, png: c.toDataURL('image/png') };
  }, e);
  fs.writeFileSync(path.join(OUT, 'emoji', e.name + '.png'), Buffer.from(r.png.split(',')[1], 'base64'));
  emoji[e.name] = { ch: e.ch, font: e.font, size: e.size, w: r.w, h: r.h, adv: r.adv, base: r.base };
}
fs.writeFileSync(path.join(OUT, 'emoji.json'), JSON.stringify(emoji, null, 1));
console.log('emoji:', Object.keys(emoji).join(' '));
if (errors.length) console.log('page errors:', errors.slice(0, 3).join(' | '));
await browser.close();
