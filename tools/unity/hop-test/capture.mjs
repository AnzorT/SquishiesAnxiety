// Squish Hop's level as the app shows it on develop (Expo web, src/web/Preview.js "game-hop": a made-up player, nothing
// saved; the rigs' page kept from loading, so the cut-outs stand in as in Unity), at
// known moments, for Program.cs to build the same from the Unity code (Games/Hop/HopLevel) and compare. The page's
// clock is replaced by tools/unity/rig/virtual-clock.js before the level opens and stepped 16 ms a frame (each frame its
// own task, so React renders and the hop's promises run between frames, as on a phone), so both run the same frames.
// Each scene opens level 12 from the map (the hub's REGULAR MODE first; others: the level is switched in the game's
// own state, as NEXT does), lets
// it settle (SETTLE ms: the board fluffed in, the banners gone, the loops done: Expo web plays a looping native
// animation once), then plays its steps at their times (ms after SETTLE) and takes its shots.
//   steps: { sol: 1 } the full clear's next hop, as a tap on the cushion next to the squishy
//          { tap: [x, y] } a tap on the screen (dp)          { card: 'LABEL' } a tap on a card's button
//          { dir: d } a tap on the cushion next to the squishy that way (0 up, 1 right, 2 down, 3 left)
//          { swipe: d } a drag from the squishy 60 dp that way (0 up, 1 right, 2 down, 3 left), in 4 moves
//          { key: d } a press of the arrow key that way
//   <out>/<scene>-<ms>.png  the screen          <out>/scenes.json  the scenes, for Program.cs
// node capture.mjs <out dir> [scene ...]
import fs from 'node:fs';
import path from 'node:path';
import { openApp, ROOT } from '../ui/snap-page.mjs';

const [out, ...only] = process.argv.slice(2);
const HOST = process.env.HOP_HOST || 'http://localhost:8081';
fs.mkdirSync(out, { recursive: true });
const SETTLE = 12000;
const sol = (n, every = 450) => Array.from({ length: n }, (_, i) => ({ at: i * every, sol: 1 }));
export const SCENES = [
  { name: 'l12', lv: 12, steps: [], shots: [0] },
  // a hop: lifting off, in the air, landing (the cushion it left puffing away), settled
  { name: 'l12-hop', lv: 12, steps: sol(1), shots: [64, 128, 176, 272, 1200] },
  { name: 'l12-play', lv: 12, steps: sol(6), shots: [3600] },
  { name: 'l12-pause', lv: 12, steps: [{ at: 0, tap: [34, 32] }], shots: [160, 2000] },
  { name: 'l12-hint', lv: 12, steps: [{ at: 0, tap: [760, 346] }, { at: 2000, card: 'SHOW ME' }], shots: [1600, 2700, 4400] },
  // RESTART (it throbs once a hop leaves no full clear: the first hop off the full clear's way)
  { name: 'l12-restart', lv: 12, steps: [...sol(3), { at: 1800, tap: [760, 281] }], shots: [2000, 3200] },
  // the arrow keys: hops and bumps (squished against the edge, the head's no)
  { name: 'l12-keys', lv: 12, steps: [{ at: 0, key: 3 }, { at: 600, key: 2 }, { at: 1200, key: 2 }], shots: [100, 250, 1320, 1500, 2200] },
  // a level coming in (as NEXT brings it): the board fluffing in, the squishies dropping and popping in, LEVEL n, the
  // new twist's banner; shots: ms after the switch
  { name: 'l31-intro', lv: 31, intro: [120, 400, 900, 1750] },
  // nowhere left to hop (D L U, from: dotnet run --project tools/unity/hop-test -- stuck 12): the droop and the look,
  // STUCK!, its RETRY
  { name: 'l12-stuck', lv: 12, steps: [{ at: 0, dir: 2 }, { at: 450, dir: 3 }, { at: 900, dir: 0 }, { at: 5200, card: 'RETRY' }], shots: [1300, 1700, 2600, 5000, 6400] },
  { name: 'l15', lv: 15, steps: [], shots: [0] },
  // swipes every way from the start: bumps (and why, in the tip), and hops
  { name: 'l15-swipe', lv: 15, steps: [0, 1, 2, 3].map((d, i) => ({ at: i * 500, swipe: d })), shots: [1700] },
  { name: 'l31', lv: 31, steps: [], shots: [0] },
  { name: 'l31-play', lv: 31, steps: sol(5, 600), shots: [4000] },
  { name: 'l47', lv: 47, steps: sol(3, 600), shots: [2600] },
  { name: 'l55', lv: 55, steps: [], shots: [0] },
  { name: 'l66', lv: 66, steps: [], shots: [0] },
  { name: 'l81', lv: 81, steps: sol(2, 600), shots: [2400] },
  // the whole full clear: the jumps for joy and the friends' cheer, then the result card popping in and settled (shots:
  // after the last hop)
  { name: 'l3-win', lv: 3, win: true, steps: [], shots: [500, 900, 1800, 8700] },
];

const clock = fs.readFileSync(path.join(ROOT, 'tools', 'unity', 'rig', 'virtual-clock.js'), 'utf8');

// in the page: the HopGame's state (its hooks), the board's layout, and the full clear
const HELPERS = () => {
  function fiberOf(el) { for (const k in el) if (k.startsWith('__reactFiber$') || k.startsWith('__reactContainer$')) return el[k]; return null; }
  window.__hopFiber = () => {
    let f = fiberOf(document.getElementById('root'));
    if (f && f.stateNode && f.stateNode.current) f = f.stateNode.current;
    const stack = [f];
    while (stack.length) {
      const x = stack.pop();
      if (!x) continue;
      if (typeof x.type === 'function' && x.type.name === 'HopGame') return x;
      if (x.sibling) stack.push(x.sibling);
      if (x.child) stack.push(x.child);
    }
    return null;
  };
  window.__hopX = () => {
    const f = window.__hopFiber();
    const hooks = [];
    for (let h = f.memoizedState; h; h = h.next) hooks.push(h);
    const spec = hooks.map((h) => h.memoizedState).find((v) => Array.isArray(v) && v[0] && v[0].sol && v[0].board)[0];
    const G = hooks.map((h) => h.memoizedState).find((v) => v && v.current && v.current.st && v.current.hist).current;
    const setLv = hooks.find((h) => h.queue && h.memoizedState === f.memoizedProps.startLv && typeof h.memoizedState === 'number');
    const tile = window.__components('Tile')[0];
    return { spec, G, B: tile && tile.props.B, setLvHook: setLv };
  };
  window.__project = (B, u, v) => {
    const X = u - B.w / 2, Y = v - B.h / 2, s = 13 / (13 - Y * B.sn);
    return { x: B.cx + X * s * B.T, y: B.cy + Y * B.c * s * B.T };
  };
  // where to tap for the full clear's next hop (the cushion next to the squishy that way)
  window.__solTap = (dir) => {
    const { spec, G, B } = window.__hopX();
    const d = dir != null ? dir : spec.sol[G.moves.length];
    if (d == null) return null;
    const cur = G.st.cur, w = spec.board.w;
    const DIRS = [[0, -1], [1, 0], [0, 1], [-1, 0]];
    const x = (cur % w) + DIRS[d][0], y = Math.floor(cur / w) + DIRS[d][1];
    const p = window.__project(B, x + 0.5, y + 0.5);
    return [p.x + window.__areaX(), p.y];
  };
  // the board area's left (the left column is as wide as its goal card needs)
  window.__areaX = () => window.__components('Under')[0].el.parentElement.getBoundingClientRect().x;
  window.__keyAt = (d) => {
    const r = window.__components('SdButton')[[0, 2, 3, 1][d]].el.getBoundingClientRect();
    return [r.x + r.width / 2, r.y + r.height / 2];
  };
  window.__hopperAt = () => {
    const { spec, G, B } = window.__hopX();
    const cur = G.st.cur, w = spec.board.w;
    const p = window.__project(B, (cur % w) + 0.5, Math.floor(cur / w) + 0.5);
    return [p.x + window.__areaX(), p.y];
  };
  // a new level in the game's own state (as NEXT does), with the squishy's cell reset first: Game.js reads the last
  // level's view.cur against the new board while it renders (StuckCard's `shut`), which throws when that cell is past
  // the new board's end
  window.__goLevel = (lv) => {
    const f = window.__hopFiber();
    for (let h = f.memoizedState; h; h = h.next) {
      const v = h.memoizedState;
      if (h.queue && v && typeof v === 'object' && 'cur' in v && 'hops' in v) h.queue.dispatch({ ...v, cur: 0 });
    }
    window.__hopX().setLvHook.queue.dispatch(lv);
  };
};

async function frames(page, to) {
  await page.evaluate(async (to) => {
    while (window.__clock.now < to) {
      window.__clock.frame(Math.min(16, to - window.__clock.now));
      await new Promise((r) => { const ch = new MessageChannel(); ch.port1.onmessage = () => r(); ch.port2.postMessage(0); });
    }
  }, to);
}

const results = [];
for (const scene of SCENES) {
  if (only.length && !only.includes(scene.name)) continue;
  const { browser, page, errors } = await openApp(`${HOST}/?phone=1&preview=1&card=game-hop`);
  await page.route('**/android_asset/rig/**', (r) => r.abort());
  await page.waitForTimeout(6000);
  await page.mouse.click(218, 180);   // the hub's REGULAR MODE
  await page.waitForTimeout(4000);
  await page.evaluate(HELPERS);
  await page.evaluate(clock);
  await page.mouse.click(416, 280);   // level 12 on the map
  for (let t = 0; t < 2000; t += 400) { await frames(page, t + 400); await page.waitForTimeout(150); }
  if (scene.lv !== 12) {
    await page.evaluate((lv) => window.__goLevel(lv), scene.lv);
    await page.waitForTimeout(500);
  }
  if (scene.intro) {
    for (const ms of scene.intro) {
      await frames(page, 2000 + ms);
      await page.waitForTimeout(700);
      await page.screenshot({ path: path.join(out, `${scene.name}-${ms}.png`) });
      console.log(`${scene.name} at ${ms} ms`);
    }
    results.push({ name: scene.name, lv: scene.lv, switchAt: 2000, steps: [], shots: scene.intro });
    await browser.close();
    continue;
  }
  // settle: in steps, with real time for React between
  for (let t = 2000; t < SETTLE; t += 500) { await frames(page, t + 500); await page.waitForTimeout(60); }
  let steps = scene.steps.slice(), shotsAt = scene.shots.slice();
  if (scene.win) {
    const n = await page.evaluate(() => window.__hopX().spec.sol.length);
    steps = sol(n, 420);
    shotsAt = scene.shots.map((ms) => ms + (n - 1) * 420);
  }
  const events = [...steps.map((s) => ({ ...s, kind: 'step' })), ...shotsAt.map((ms) => ({ at: ms, kind: 'shot' }))].sort((a, b) => a.at - b.at || (a.kind === 'step' ? -1 : 1));
  const played = [];
  for (const e of events) {
    await frames(page, SETTLE + e.at);
    if (e.kind === 'shot') {
      await page.waitForTimeout(700);
      await page.screenshot({ path: path.join(out, `${scene.name}-${e.at}.png`) });
      console.log(`${scene.name} at ${e.at} ms`);
      continue;
    }
    await page.waitForTimeout(80);
    let at = null;
    if (e.sol) at = await page.evaluate(() => window.__solTap());
    else if (e.dir != null) at = await page.evaluate((d) => window.__solTap(d), e.dir);
    else if (e.tap) at = e.tap;
    else if (e.key != null) at = await page.evaluate((d) => window.__keyAt(d), e.key);
    else if (e.card) at = await page.evaluate((label) => {
      const t = [...document.querySelectorAll('div')].filter((d) => d.innerText === label).pop();
      if (!t) return null;
      const r = t.getBoundingClientRect();
      return [r.x + r.width / 2, r.y + r.height / 2];
    }, e.card);
    if (e.swipe != null) {
      const [x0, y0] = await page.evaluate(() => window.__hopperAt());
      const D = [[0, -1], [1, 0], [0, 1], [-1, 0]][e.swipe];
      const path = [0, 1, 2, 3, 4].map((i) => [x0 + D[0] * 15 * i, y0 + D[1] * 15 * i]);
      await page.mouse.move(x0, y0);
      await page.mouse.down();
      for (const [x, y] of path.slice(1)) await page.mouse.move(x, y);
      await page.mouse.up();
      played.push({ at: e.at, path });
      continue;
    }
    if (!at) continue;
    await page.mouse.click(at[0], at[1]);
    played.push({ ...e, kind: undefined, x: at[0], y: at[1] });
    await page.waitForTimeout(60);
  }
  results.push({ name: scene.name, lv: scene.lv, settle: SETTLE, steps: played, shots: shotsAt });
  if (errors.length) console.log('page errors:', errors.slice(0, 3).join(' | '));
  await browser.close();
}
const file = path.join(out, 'scenes.json');
const old = fs.existsSync(file) ? JSON.parse(fs.readFileSync(file, 'utf8')) : [];
const merged = [...old.filter((s) => !results.some((r) => r.name === s.name)), ...results];
fs.writeFileSync(file, JSON.stringify(merged, null, 1));
