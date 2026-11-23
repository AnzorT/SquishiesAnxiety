// Squishdoku's Blitz as the app plays it (Expo web, src/web/Preview.js "game-squishdoku": a made-up player with Remove
// Ads), on a virtual clock, for Blitz.cs to play the same from the Unity code (SdBlitz) and compare.
//   The hub is opened in real time, then the page's clock is replaced (tools/unity/rig/virtual-clock.js) and Math.random
//   made 0.5 (the boards' seeds, the buddy's words, the bursts), and BLITZ MODE tapped. The clock is stepped 16 ms a
//   frame; T0 is when the countdown's timers are set (3, 2, 1, GO! from T0 + 200). From there taps (right creatures, a
//   wrong one, the cards' buttons, the pause) happen at set moments and the screen is shot at set moments.
// node blitz.mjs <out dir>      <out>/blitz-<ms>.png  the screen at T0 + ms;  <out>/blitz.json  the boards and the steps
import fs from 'node:fs';
import path from 'node:path';
import { openApp, ROOT } from '../ui/snap-page.mjs';

const [out] = process.argv.slice(2);
fs.mkdirSync(out, { recursive: true });
// board 1 (4×4): playing from 2300 + (2·4-1)·34 + 250 + 350 = 3138
const STEPS = [
  { at: 250, shot: true }, { at: 600, shot: true }, { at: 1000, shot: true }, { at: 2400, shot: true }, { at: 2700, shot: true },
  { at: 3000, shot: true }, { at: 3300, shot: true },
  // board 1: rows 1-3 right (row 0 was given): cleared
  { at: 3400, tap: 'right', row: 1 }, { at: 3600, tap: 'right', row: 2 }, { at: 3800, shot: true }, { at: 3850, tap: 'right', row: 3 },
  { at: 4150, shot: true }, { at: 4500, shot: true }, { at: 4700, shot: true }, { at: 5000, shot: true }, { at: 5300, shot: true },
  { at: 6000, shot: true },
  // board 2: a wrong creature, the save card, SAVE IT (FREE)
  { at: 6600, tap: 'wrong', row: 1 }, { at: 6900, shot: true }, { at: 7700, shot: true }, { at: 9000, shot: true },
  { at: 9100, press: 'SAVE IT' }, { at: 9200, shot: true }, { at: 9600, shot: true },
  // pause, RESUME
  { at: 9700, crib: true }, { at: 9900, shot: true }, { at: 11000, shot: true }, { at: 11100, press: 'RESUME' },
  // another mistake, END RUN: GAME OVER
  { at: 11500, tap: 'wrong', row: 2 }, { at: 13000, shot: true }, { at: 13100, press: 'END RUN' }, { at: 13300, shot: true }, { at: 16000, shot: true },
];

const { browser, page, errors } = await openApp('http://localhost:8081/?phone=1&preview=1&card=game-squishdoku');
await page.waitForTimeout(6000);
await page.evaluate(fs.readFileSync(path.join(ROOT, 'tools', 'unity', 'rig', 'virtual-clock.js'), 'utf8'));
await page.evaluate(() => {
  Math.random = () => 0.5;
  // when the countdown's timers are set (BlitzGame.js: 200, 900, 1600, 2300 at once)
  const st = window.setTimeout;
  window.__cdAt = null;
  window.setTimeout = function (fn, ms, ...a) { if (ms === 1600 && window.__cdAt == null) window.__cdAt = window.__clock.now; return st(fn, ms, ...a); };
});
const frame = () => page.evaluate(async () => { window.__clock.frame(16); for (let i = 0; i < 3; i++) await new Promise((r) => window.__realSetTimeout(r, 0)); });
const run = (ms) =>
  page.evaluate(async (target) => {
    const y = () => new Promise((r) => window.__realSetTimeout(r, 0));
    while (window.__clock.now < target - 1e-9) {
      window.__clock.frame(Math.min(16, target - window.__clock.now));
      for (let i = 0; i < 3; i++) await y();
    }
  }, ms);
const tapAt = await page.evaluate(() => window.__clock.now);
await page.mouse.click(610, 200); // BLITZ MODE
let T0 = null;
for (let i = 0; i < 400 && T0 == null; i++) {
  await frame();
  T0 = await page.evaluate(() => window.__cdAt);
}
console.log('BLITZ MODE tapped; the countdown set', T0 - tapAt, 'ms later');

const boards = [];
async function board() {
  const b = await page.evaluate(() => {
    const rb = window.__components('RoomBoard')[0];
    if (!rb) return null;
    const p = rb.props.puzzle;
    return { n: p.n, regions: p.regions, solution: p.solution, seed: p.seed };
  });
  if (b && !boards.some((x) => JSON.stringify(x) === JSON.stringify(b))) boards.push(b);
  return b;
}
async function cellPoint(r, c) {
  return page.evaluate(([r, c]) => {
    const rb = window.__components('RoomBoard')[0];
    const B = rb.props.B;
    const box = rb.el.getBoundingClientRect();
    const DEPTH = 13, u = c + 0.5, v = r + 0.5;
    const X = u - B.w / 2, Y = v - B.h / 2, yr = Y * B.c, zr = Y * B.sn, s = DEPTH / (DEPTH - zr);
    return [box.x + B.cx + X * s * B.T, box.y + B.cy + yr * s * B.T];
  }, [r, c]);
}
async function press(label) {
  const p = await page.evaluate((label) => {
    const b = window.__components('SdButton').map((c) => c.el).filter((e) => e && e.getBoundingClientRect().width > 0).find((e) => e.innerText.includes(label));
    const r = b.getBoundingClientRect();
    return [r.x + r.width / 2, r.y + r.height / 2];
  }, label);
  await page.mouse.click(p[0], p[1]);
}

for (const s of STEPS) {
  await run(T0 + s.at);
  if (s.tap) {
    const b = await board();
    const sol = b.solution[s.row];
    const [x, y] = await cellPoint(s.row, s.tap === 'right' ? sol : (sol + 1) % b.n);
    await page.mouse.click(x, y);
    await page.waitForTimeout(300);
  } else if (s.press) {
    await press(s.press);
    await page.waitForTimeout(300);
  } else if (s.crib) {
    await page.mouse.click(34, 34);
    await page.waitForTimeout(300);
  } else if (s.shot) {
    await board();
    await page.waitForTimeout(700);
    await page.screenshot({ path: path.join(out, `blitz-${s.at}.png`) });
    console.log(`blitz at ${s.at} ms`);
  }
}
fs.writeFileSync(path.join(out, 'blitz.json'), JSON.stringify({ steps: STEPS, boards }));
if (errors.length) console.log('page errors:', errors.slice(0, 3).join(' | '));
await browser.close();
