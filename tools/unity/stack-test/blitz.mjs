// Squish Stack's Blitz as the app plays it (Expo web, src/web/Preview.js "game-stack": a made-up player with Remove Ads,
// nothing saved), on a virtual clock, for Blitz.cs to play the same from the Unity code (StackGame.CreateBlitz) and compare.
//   The hub is opened in real time, then the page's clock is replaced (tools/unity/rig/virtual-clock.js) and BLITZ GO
//   tapped. The clock is stepped 16 ms a frame; T0 is when the countdown's timers are set (3, 2, 1, GO! from T0 + 200).
//   Then the run is played: every puzzle solved with the engine's best moves (one tap-tap move every 450 ms once it's
//   dealt), a mistake on puzzle 2 (REVIVE), all ten cleared (BLITZ CHAMPION!), AGAIN, a pause on the new run's puzzle 1
//   (RESUME), a mistake, BACK TO PUZZLE 1 (the fail card). Every tap and every screenshot is logged with its moment.
// node blitz.mjs <out dir>   <out>/blitz-<ms>.png  the screen at T0 + ms;  <out>/blitz.json  the puzzles, steps, the win's heads
import fs from 'node:fs';
import path from 'node:path';
import { openApp, ROOT } from '../ui/snap-page.mjs';

const [out] = process.argv.slice(2);
fs.mkdirSync(out, { recursive: true });
const { browser, page, errors } = await openApp('http://localhost:8081/?phone=1&preview=1&card=game-stack');
await page.waitForTimeout(6000);
await page.evaluate(fs.readFileSync(path.join(ROOT, 'tools', 'unity', 'rig', 'virtual-clock.js'), 'utf8'));
await page.evaluate(() => {
  // when the countdown's timers are set (Game.js: 200, 900, 1600, 2300 and 3000 at once)
  const st = window.setTimeout;
  window.__cdAt = null;
  window.setTimeout = function (fn, ms, ...a) { if (ms === 2300 && window.__cdAt == null) window.__cdAt = window.__clock.now; return st(fn, ms, ...a); };
  // the game's state, from its hooks: the phase, the puzzle (start, goal, star, par and its solution), who
  const PHASES = new Set(['load', 'intro', 'deal', 'play', 'held', 'won', 'lost']);
  window.__game = () => {
    const root = document.getElementById('root');
    let f;
    for (const k in root) if (k.startsWith('__reactContainer$')) f = root[k];
    if (f.stateNode && f.stateNode.current) f = f.stateNode.current;
    let found = null;
    const walk = (x) => { for (; x && !found; x = x.sibling) { if (typeof x.type === 'function' && x.type.name === 'StackGame') { found = x; return; } if (x.child) walk(x.child); } };
    walk(f);
    if (!found) return null;
    const vals = [];
    for (let h = found.memoizedState; h; h = h.next) vals.push(h.memoizedState);
    return {
      phase: vals.find((v) => v && typeof v === 'object' && !Array.isArray(v) && PHASES.has(v.current)).current,
      puzzle: vals.find((v) => Array.isArray(v) && v[0] && v[0].sol && v[0].start)[0],
      who: vals.find((v) => Array.isArray(v) && Array.isArray(v[0]) && v[0][0] && v[0][0].key && 'mine' in v[0][0])[0],
      cast: found.memoizedProps.cast,
      win: vals.find((v) => v && typeof v === 'object' && !Array.isArray(v) && Array.isArray(v.uris)) || null,
    };
  };
  // engine.js bestMove on the page's own solution: the moves from `pos` to the goal
  window.__solve = (pos) => {
    const { sol } = window.__game().puzzle;
    const left = (p) => sol.dist[sol.enc(p)];
    const topOf = (p, c) => { for (let r = 0; r < p.length; r++) if (p[r] === c) return r; return -1; };
    const moves = [];
    pos = pos.slice();
    for (let d = left(pos); d > 0; d = left(pos)) {
      let next = null;
      for (let a = 0; a < sol.k && !next; a++)
        for (let b = 0; b < sol.k && !next; b++) {
          if (a === b) continue;
          const r = topOf(pos, a);
          if (r < 0) continue;
          const t = topOf(pos, b);
          if (t >= 0 && t < r) continue;
          const p = pos.slice();
          p[r] = b;
          if (left(p) === d - 1) next = [r, a, b, p];
        }
      moves.push([next[1], next[2]]);
      pos = next[3];
    }
    return moves;
  };
});
const yieldN = 'for (let i = 0; i < 3; i++) await new Promise((r) => window.__realSetTimeout(r, 0));';
const frame = () => page.evaluate(`(async () => { window.__clock.frame(16); ${yieldN} })()`);
const now = () => page.evaluate(() => window.__clock.now);
const run = (ms) =>
  page.evaluate(async (target) => {
    const y = () => new Promise((r) => window.__realSetTimeout(r, 0));
    while (window.__clock.now < target - 1e-9) {
      window.__clock.frame(Math.min(16, target - window.__clock.now));
      for (let i = 0; i < 3; i++) await y();
    }
  }, ms);

await page.mouse.click(712, 270); // BLITZ GO
let T0 = null;
for (let i = 0; i < 600 && T0 == null; i++) {
  await frame();
  T0 = await page.evaluate(() => window.__cdAt);
}
console.log('BLITZ GO tapped; the countdown set at', T0);
// every squishy's picture loaded (in real time: the page's clock waits)
await page.evaluate(async () => {
  const uris = [...new Set(window.__game().cast.map((c) => c.uri).filter((u) => u && u !== 'about:blank'))];
  await Promise.all(uris.map((u) => new Promise((r) => { const i = new Image(); i.onload = i.onerror = r; i.src = u; })));
});
await page.waitForTimeout(1500);

const steps = [];
const puzzles = [];
const rel = async () => (await now()) - T0;
async function at(ms) { await run(T0 + ms); }
async function shot(name) {
  const ms = await rel();
  await page.waitForTimeout(600);
  const file = `blitz-${Math.round(ms)}.png`;
  await page.screenshot({ path: path.join(out, file) });
  steps.push({ at: ms, shot: file, name });
  console.log(`  ${name} at ${ms} ms`);
}
async function shotAt(ms, name) { await at(ms); await shot(name); }
async function noteP() {
  const g = await page.evaluate(() => { const g = window.__game(); return { start: g.puzzle.start, goal: g.puzzle.goal, star: g.puzzle.star, par: g.puzzle.par, who: g.who.map((c) => (c.source && c.source.uri === 'about:blank' ? '' : c.key)) }; });
  const last = puzzles[puzzles.length - 1];
  if (!last || JSON.stringify(last) !== JSON.stringify(g)) puzzles.push(g);
  return g;
}
// the phase `ph` (`fresh`: of a puzzle not seen yet, as the last one stays in play until its last squishy lands)
async function waitPhase(ph, fresh = true) {
  for (let i = 0; i < 1000; i++) {
    const ok = await page.evaluate(([ph, fresh]) => { const g = window.__game(); return g.phase === ph && (!fresh || g.puzzle !== window.__seen); }, [ph, fresh]);
    if (ok) { await page.evaluate(() => (window.__seen = window.__game().puzzle)); return rel(); }
    await frame();
  }
  await page.screenshot({ path: path.join(out, 'stuck.png') });
  throw new Error(`no ${ph} (${await page.evaluate(() => window.__game().phase)} at ${await rel()})`);
}
const colX = (k, p) => 250 + (432 / k) * (p + 0.5);
async function tapMove(k, from, to, what = 'move') {
  const ms = await rel();
  await page.mouse.click(colX(k, from), 300);
  await page.mouse.click(colX(k, to), 300);
  await page.waitForTimeout(100);
  steps.push({ at: ms, move: [from, to], what });
}
async function press(label) {
  const ms = await rel();
  const p = await page.evaluate((label) => {
    const b = window.__components('SdButton').map((c) => c.el).filter((e) => e && e.getBoundingClientRect().width > 0).reverse().find((e) => e.innerText.replace(/\s+/g, ' ').includes(label));
    const r = b.getBoundingClientRect();
    return [r.x + r.width / 2, r.y + r.height / 2];
  }, label);
  await page.mouse.click(p[0], p[1]);
  await page.waitForTimeout(200);
  steps.push({ at: ms, press: label });
  console.log(`  ${label} at ${ms} ms`);
}
// a puzzle's best moves, 450 ms apart from when it's playable (`shots`: moments after that to shoot); k by puzzle
// (levels.js BLITZ)
const BLITZ_K = [3, 3, 3, 3, 3, 4, 4, 4, 4, 4];
let idx = 0;
async function puzzle(shots) {
  const t = await waitPhase('play');
  const g = await noteP();
  g.k = BLITZ_K[idx];
  const moves = await page.evaluate((s) => window.__solve(s), g.start);
  const plan = moves.map((m, i) => ({ ms: t + 100 + i * 450, m })).concat((shots || []).map(([ms, name]) => ({ ms: t + ms, name })));
  plan.sort((a, b) => a.ms - b.ms);
  for (const s of plan) {
    await at(s.ms);
    if (s.m) await tapMove(g.k, s.m[0], s.m[1]);
    else await shot(s.name);
  }
  idx++;
  return t + 100 + (moves.length - 1) * 450; // the last move
}
// a big one onto a smaller one (after best moves until there is one)
async function mistake(fresh = true) {
  const t = await waitPhase("play", fresh);
  const g = await noteP();
  g.k = BLITZ_K[idx];
  let pos = g.start.slice();
  const topOf = (p, c) => { for (let r = 0; r < p.length; r++) if (p[r] === c) return r; return -1; };
  let ms = t + 100;
  for (;;) {
    let pair = null;
    for (let a = 0; a < g.k && !pair; a++) for (let b = 0; b < g.k && !pair; b++) { const ra = topOf(pos, a), rb = topOf(pos, b); if (a !== b && ra >= 0 && rb >= 0 && ra > rb) pair = [a, b]; }
    await at(ms);
    if (pair) { await tapMove(g.k, pair[0], pair[1], 'mistake'); return [ms, pos]; }
    const m = (await page.evaluate((s) => window.__solve(s), pos))[0];
    await tapMove(g.k, m[0], m[1]);
    const r = topOf(pos, m[0]);
    pos[r] = m[1];
    ms += 450;
  }
}

// ---- run 1: the countdown, puzzle 1 solved, a mistake on puzzle 2 and the revive, all ten, the win ----
await shotAt(600, 'countdown 3');
await shotAt(1000, 'countdown 2');
await shotAt(1700, 'countdown 1');
await shotAt(2400, 'GO!');
await shotAt(2750, 'GO! and the deal');
let last = await puzzle([[50, 'puzzle 1 in play'], [100 + 450 + 150, 'a move in the air']]);
await shotAt(last + 700, 'puzzle 1 cleared, its pip');
await shotAt(last + 1700, 'puzzle 2: its banner');
let [m, pos] = await mistake();
await shotAt(m + 300, 'TOO BIG!');
await shotAt(m + 1450, 'the revive card coming');
await shotAt(m + 3500, 'the revive card');
await press('REVIVE');
await shotAt(m + 3800, 'revived');
// puzzle 2 from where the mistake left it
{
  const g = puzzles[puzzles.length - 1];
  const t = await rel();
  const moves = await page.evaluate((s) => window.__solve(s), pos);
  for (let i = 0; i < moves.length; i++) { await at(t + 300 + i * 450); await tapMove(g.k, moves[i][0], moves[i][1]); }
  idx++;
}
for (let p = 2; p < 10; p++) last = await puzzle(p === 6 ? [[60, 'puzzle 7 in play (a picture goal)']] : p === 9 ? [[60, 'puzzle 10 in play']] : []);
await shotAt(last + 1000, 'the tenth cleared');
await shotAt(last + 1800, 'BLITZ CHAMPION! opening');
await shotAt(last + 4500, 'BLITZ CHAMPION! counting');
await shotAt(last + 8000, 'BLITZ CHAMPION!');
const heads = await page.evaluate(() => { const g = window.__game(); const by = Object.fromEntries(g.cast.map((c) => [c.uri, c.key])); return g.win ? g.win.uris.map((u) => (u && u !== 'about:blank' ? by[u] : '')) : null; });
await press('AGAIN');
// ---- run 2: the countdown again, a pause, a mistake, BACK TO PUZZLE 1 ----
idx = 0;
const t2 = await waitPhase('play');
await noteP();
await shotAt(t2 + 200, 'run 2 in play');
{
  const ms = await rel();
  await page.mouse.click(32, 32.5);
  await page.waitForTimeout(200);
  steps.push({ at: ms, back: true });
}
const tp = await rel();
await shotAt(tp + 150, 'paused, opening');
await shotAt(tp + 2000, 'paused');
await press('RESUME');
[m] = await mistake(false);
await shotAt(m + 2500, 'the revive card again');
await press('BACK TO PUZZLE 1');
const tf = await rel();
await shotAt(tf + 400, 'BACK TO PUZZLE 1! opening');
await shotAt(tf + 3600, 'BACK TO PUZZLE 1!');
fs.writeFileSync(path.join(out, 'blitz.json'), JSON.stringify({ T0, steps, puzzles, heads }, null, 1));
if (errors.length) console.log('page errors:', errors.slice(0, 3).join(' | '));
await browser.close();
