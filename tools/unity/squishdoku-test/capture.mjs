// A Squishdoku level as the app plays it (Expo web, src/web/Preview.js "game-squishdoku": a made-up player), frame by
// frame on a virtual clock, for Program.cs to play the same from the Unity code (SdLevel) and compare.
//   The level is opened in real time (the view slides in), then the page's clock is replaced (tools/unity/rig/
//   virtual-clock.js) and Math.random made 0.5 (so the board's tricks, the bursts and the buddy's words are the same
//   on both sides), its clock run out and RETRY pressed: the same board starts again with nothing else moving, at virtual
//   time T0. From there the clock is stepped 16 ms a frame; taps (a right creature, a wrong one, the ✕ tool, two ✕)
//   happen at set moments between frames, and the screen is shot at set moments.
// node capture.mjs <out dir> [level] [scenario: play (a right creature, a wrong one, two ✕, the clock running out) |
//   hearts (three mistakes from level 46: OUT OF HEARTS) | solve (the
//   result card) | head (HEAD START on: its creature drops in)]
//   <out>/play-<ms>.png   the screen at T0 + ms        <out>/scenario.json   the level, the taps and the moments
import fs from 'node:fs';
import path from 'node:path';
import { openApp, ROOT } from '../ui/snap-page.mjs';

const [out, lvArg = '12', scenario = 'play'] = process.argv.slice(2);
const LV = +lvArg;
const HEAD = scenario === 'head';
fs.mkdirSync(out, { recursive: true });
const { levelSpec } = await import(path.join(ROOT, 'src', 'squishdoku', 'levels.js'));
const spec = levelSpec(LV, HEAD);
const n = spec.n, sol = spec.puzzle.solution;
const play = 60 + (2 * n - 1) * 34 + 450;   // when the clock starts (RegularGame.js `settled`)
const end = play + spec.limitMs;            // time's up

// what happens when: taps on cells (row, col), the tools, and the moments to shoot
const wrongCol = (r) => (sol[r] + 1) % n;
const STEPS = {};
STEPS.play = [
  { at: 250, shot: true }, { at: 600, shot: true }, { at: 1500, shot: true },
  { at: 1600, tap: [0, sol[0]] }, { at: 1700, shot: true }, { at: 1900, shot: true }, { at: 2700, shot: true },
  { at: 2750, tap: [1, wrongCol(1)] }, { at: 2900, shot: true }, { at: 3100, shot: true }, { at: 3700, shot: true },
  { at: 4000, tool: 'mark' }, { at: 4200, tap: [3, wrongCol(3)] }, { at: 4300, tap: [4, wrongCol(4)] }, { at: 4800, shot: true },
  { at: 5000, tool: 'place' }, { at: 5600, shot: true },
  { at: end - 7000, shot: true }, { at: end - 6750, shot: true }, { at: end + 300, shot: true }, { at: end + 2000, shot: true },
];
STEPS.hearts = [
  { at: 1500, shot: true },
  { at: 1600, tap: [0, wrongCol(0)] }, { at: 1800, shot: true },
  { at: 2600, tap: [1, wrongCol(1)] }, { at: 2700, shot: true },
  { at: 3600, tap: [2, wrongCol(2)] }, { at: 3800, shot: true }, { at: 4300, shot: true }, { at: 4800, shot: true }, { at: 6600, shot: true },
];
// a right creature on every row, 250 ms apart: the solve (everyone hops, confetti), the result card 1700 ms later
const last = 1600 + 250 * (n - 1);
STEPS.solve = [
  ...sol.map((c, r) => ({ at: 1600 + 250 * r, tap: [r, c] })),
  { at: last + 300, shot: true }, { at: last + 700, shot: true }, { at: last + 1200, shot: true },
  { at: last + 2000, shot: true }, { at: last + 3000, shot: true }, { at: last + 8000, shot: true },
];
STEPS.head = [{ at: 700, shot: true }, { at: play + 100, shot: true }, { at: play + 600, shot: true }, { at: play + 1200, shot: true }];
const steps = STEPS[scenario];

const { browser, page, errors } = await openApp('http://localhost:8081/?phone=1&preview=1&card=game-squishdoku');
await page.waitForTimeout(6000);
if (HEAD) {
  // the hub's HEAD START switch
  const sw = await page.evaluate(() => {
    const t = [...document.querySelectorAll('div')].filter((d) => d.childNodes.length === 1 && d.textContent === 'OFF' && d.getBoundingClientRect().width > 0)[0];
    const r = t.getBoundingClientRect();
    return [r.x + r.width / 2, r.y + r.height / 2];
  });
  await page.mouse.click(sw[0], sw[1]);
  await page.waitForTimeout(1000);
}
// a level past the made-up player's (12): the player is put on it (Preview's profile object, in this page only)
if (LV > 12) await page.evaluate((lv) => { window.__components('SquishdokuScreen')[0].props.profile.sdk.lv = lv; }, LV);
await page.mouse.click(220, 200); // Regular Mode -> the map
await page.waitForTimeout(3000);
const node = await page.evaluate((lv) => {
  const t = [...document.querySelectorAll('div')].find((d) => d.childNodes.length === 1 && d.textContent === String(lv) && d.getBoundingClientRect().width > 0);
  const r = t.getBoundingClientRect();
  return [r.x + r.width / 2, r.y + r.height / 2];
}, LV);
await page.mouse.click(node[0], node[1]);
await page.waitForTimeout(7000); // the level, playing
await page.evaluate(fs.readFileSync(path.join(ROOT, 'tools', 'unity', 'rig', 'virtual-clock.js'), 'utf8'));
await page.evaluate(() => {
  Math.random = () => 0.5;
  // when the level's 150 ms clock interval is made (React runs its effect a little after the render that starts play)
  const si = window.setInterval;
  window.__sdIntervals = [];
  window.setInterval = function (fn, ms, ...a) { if (ms === 150) window.__sdIntervals.push(window.__clock.now); return si(fn, ms, ...a); };
});
const YIELDS = +(process.env.YIELDS || 3);
const run = (ms) =>
  page.evaluate(async ([target, YIELDS]) => {
    // (a few real moments after each frame: React renders and runs its effects before the next one)
    const y = () => new Promise((r) => window.__realSetTimeout(r, 0));
    while (window.__clock.now < target - 1e-9) {
      window.__clock.frame(Math.min(16, target - window.__clock.now));
      for (let i = 0; i < YIELDS; i++) await y();
    }
  }, [ms, YIELDS]);
// the clock run out at once (RegularGame's window.__sdk, develop's pause card has no RESTART any more), its card up
// for a moment, then RETRY: T0
await page.evaluate(() => window.__sdk.timeUp());
let now = await page.evaluate(() => window.__clock.now);
await run(now + 1500);
await page.waitForTimeout(400);
const retry = await page.evaluate(() => {
  const b = window.__components('SdButton').map((c) => c.el).find((e) => e && e.innerText.includes('RETRY'));
  const r = b.getBoundingClientRect();
  return [r.x + r.width / 2, r.y + r.height / 2];
});
await page.mouse.click(retry[0], retry[1]);
await page.waitForTimeout(2500); // the same board made again (its pictures, React), the clock still
const T0 = await page.evaluate(() => window.__clock.now);

// a cell's middle on screen (board.js project, from the board's own B)
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
async function toolPoint(name) {
  return page.evaluate((name) => {
    const b = window.__components('SdButton')[name === 'place' ? 0 : 1].el.getBoundingClientRect();
    return [b.x + b.width / 2, b.y + b.height / 2];
  }, name);
}

for (const s of steps) {
  await run(T0 + s.at);
  if (s.tap) {
    const [x, y] = await cellPoint(...s.tap);
    await page.mouse.click(x, y);
    await page.waitForTimeout(300);
  } else if (s.tool) {
    const [x, y] = await toolPoint(s.tool);
    await page.mouse.click(x, y);
    await page.waitForTimeout(300);
  } else if (s.shot) {
    await page.waitForTimeout(700); // React renders what the last frame set
    await page.screenshot({ path: path.join(out, `play-${s.at}.png`) });
    console.log(`play at ${s.at} ms`);
  }
}
const intervals = await page.evaluate(() => window.__sdIntervals);
const intervalAt = intervals.filter((t) => t >= T0).map((t) => t - T0)[0];
console.log('the clock interval made at', intervalAt, 'ms (play at', play, ')');
fs.writeFileSync(path.join(out, 'scenario.json'), JSON.stringify({ lv: LV, head: HEAD, n, retryAfter: 1500, play, intervalAt, steps }));
if (errors.length) console.log('page errors:', errors.slice(0, 3).join(' | '));
await browser.close();
