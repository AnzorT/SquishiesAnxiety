// Squish Hop's BLITZ MODE as develop's app plays it (Expo web, src/web/Preview.js "game-hop": a made-up player, nothing
// saved; the rigs' page kept from loading, so the cut-outs stand in as in Unity), on a virtual clock, for Program.cs
// (`blitzshots`) to play the same from the Unity code (HopLevel with `blitz`) and compare.
//   The hub is opened in real time, then the page's clock is replaced (tools/unity/rig/virtual-clock.js) and BLITZ MODE
//   tapped. The clock is stepped 16 ms a frame; T0 is when the countdown's timers are set (3, 2, 1, GO! from T0 + 200).
//   The run's seed is read from the game's state. Then the first board is played by its full clear (a hop every 450 ms
//   from when its clock starts, through Game.js's own window.__hop), the second board comes in with BOARD 2, one hop is
//   made on it, and the game is paused.
// node blitz.mjs <out dir>   <out>/blitz-<ms>.png  the screen at T0 + ms;  <out>/blitz.json  the seed, hops and shots
import fs from 'node:fs';
import path from 'node:path';
import { openApp, ROOT } from '../ui/snap-page.mjs';

const [out] = process.argv.slice(2);
fs.mkdirSync(out, { recursive: true });
const HOST = process.env.HOP_HOST || 'http://localhost:8081';
const { browser, page, errors } = await openApp(`${HOST}/?phone=1&preview=1&card=game-hop`);
await page.route('**/android_asset/rig/**', (r) => r.abort());
await page.waitForTimeout(6000);
await page.evaluate(fs.readFileSync(path.join(ROOT, 'tools', 'unity', 'rig', 'virtual-clock.js'), 'utf8'));
await page.evaluate(() => {
  // when the countdown's timers are set (Game.js: 200, 900, 1600, 2300 and 3000 at once)
  const st = window.setTimeout;
  window.__cdAt = null;
  window.setTimeout = function (fn, ms, ...a) { if (ms === 2300 && window.__cdAt == null) window.__cdAt = window.__clock.now; return st(fn, ms, ...a); };
  // the run's seed: Game.js's useMemo on `run` (its hook holds [seed, [run]])
  window.__seed = () => {
    const root = document.getElementById('root');
    let f;
    for (const k in root) if (k.startsWith('__reactContainer$')) f = root[k];
    if (f.stateNode && f.stateNode.current) f = f.stateNode.current;
    let found = null;
    const walk = (x) => { for (; x && !found; x = x.sibling) { if (typeof x.type === 'function' && x.type.name === 'HopGame') { found = x; return; } if (x.child) walk(x.child); } };
    walk(f);
    for (let h = found && found.memoizedState; h; h = h.next) {
      const v = h.memoizedState;
      if (Array.isArray(v) && typeof v[0] === 'number' && Array.isArray(v[1]) && v[1].length === 1 && v[1][0] === 0) return v[0];
    }
    return null;
  };
});
const now = () => page.evaluate(() => window.__clock.now);
async function stepTo(ms) {
  await page.evaluate(async (to) => {
    while (window.__clock.now < to) {
      window.__clock.frame(Math.min(16, to - window.__clock.now));
      await new Promise((r) => { const ch = new MessageChannel(); ch.port1.onmessage = () => r(); ch.port2.postMessage(0); });
    }
  }, ms);
}
await page.mouse.click(614, 180);   // the hub's BLITZ MODE
let T0 = null;
for (let t = 16; T0 == null && t < 4000; t += 16) {
  await stepTo(t);
  T0 = await page.evaluate(() => window.__cdAt);
}
if (T0 == null) throw new Error('no countdown');
const seed = await page.evaluate(() => window.__seed());
const log = { t0: T0, seed, steps: [], shots: [] };
async function shot(ms) {
  await stepTo(T0 + ms);
  await page.waitForTimeout(700);
  await page.screenshot({ path: path.join(out, `blitz-${ms}.png`) });
  log.shots.push(ms);
  console.log(`blitz at ${ms} ms`);
}
async function hop(ms) {
  await stepTo(T0 + ms);
  const d = await page.evaluate(() => {
    const s = window.__hop.state();
    const d = window.__hop.sol[s.moves];
    window.__hop.hop(d);
    return d;
  });
  log.steps.push({ at: ms, dir: d });
}
// the countdown, GO and the board dropping in, its clock running
for (const ms of [250, 1000, 2400, 2560, 3400]) await shot(ms);
// the first board's full clear: a hop every 450 ms from 3200 (its clock starts at 3060)
const n = await page.evaluate(() => window.__hop.sol.length);
let t = 3600;
for (let k = 0; k < n; k++, t += 450) {
  await hop(t);
  if (k === 0) { await shot(t + 120); await shot(t + 300); }
}
// the win (the jumps for joy), CLEARED 1, the next board with BOARD 2
for (const ms of [t + 300, t + 700, t + 1300, t + 2200]) await shot(ms);
// a hop on board 2, then the pause card
await hop(t + 2600);
await shot(t + 2900);
await stepTo(T0 + t + 3400);
await page.mouse.click(34, 32);
log.steps.push({ at: t + 3400, tap: [34, 32] });
await shot(t + 3700);
fs.writeFileSync(path.join(out, 'blitz.json'), JSON.stringify(log, null, 1));
if (errors.length) console.log('page errors:', errors.slice(0, 3).join(' | '));
await browser.close();
