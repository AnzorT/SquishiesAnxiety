// Squishdoku's puzzles (SQUISHDOKU.md): an n×n grid cut into n coloured
// patches. One creature goes in every row, every column and every patch,
// and no two creatures touch, not even corner to corner (the "Queens"
// puzzle).
//
// A puzzle is made on the phone, a new one every time:
//   1. place the n creatures (one per row and column, never touching),
//   2. grow one patch out of each creature's cell, at random,
//   3. solve it the way a player would (grade below). Only a puzzle that
//      solves by logic alone is kept, and every step of that is forced, so
//      it has exactly one answer: the creatures from step 1.
// The solver's tricks, easiest first (the grade is the hardest one used):
//   1 singles: a row, column or patch with one free cell left
//   2 peeks: a cell that would leave some row, column or patch no room
//   3 pairs: 2 patches squeezed into the same 2 rows (or columns)
//   4 groups: 3+ patches squeezed into as many rows (or columns)
//   5 chains: a cell that leads to a dead end a few forced steps later
// `effort` adds up the moments with no single in sight, each costing its
// hardest trick (STALL_COST), and the tier (what a level asks for) comes
// from it: easy (effort ≤ 1), medium (2-3), hard (4-7), expert (8+).
// Measured over 600 random boards (2026-10-22): 5×5 never gets past
// medium; 9×9 is ~28% easy, 44% medium, 22% hard, 6% expert.
//
// Puzzles: { n, regions: [n*n patch index], solution: [column per row],
// tier, grade, effort, steps, seed }. Cells are numbered r * n + c.

export const TIERS = ['easy', 'medium', 'hard', 'expert'];
export const tierOf = (effort) => (effort <= 1 ? 0 : effort <= 3 ? 1 : effort <= 7 ? 2 : 3);

// mulberry32: a small seeded generator, so a seed always makes the same
// puzzle (the tests, and a board shared between devices one day).
export function rng(seed) {
  let a = seed >>> 0;
  return () => {
    a = (a + 0x6d2b79f5) >>> 0;
    let t = a;
    t = Math.imul(t ^ (t >>> 15), t | 1);
    t ^= t + Math.imul(t ^ (t >>> 7), t | 61);
    return ((t ^ (t >>> 14)) >>> 0) / 4294967296;
  };
}

const shuffled = (list, r) => {
  const a = list.slice();
  for (let i = a.length - 1; i > 0; i--) {
    const j = Math.floor(r() * (i + 1));
    [a[i], a[j]] = [a[j], a[i]];
  }
  return a;
};

// --- 1. the creatures ------------------------------------------------------------

// A column for every row, all different, neighbouring rows at least 2
// columns apart (so none touch). Null if none exists (n = 2 or 3).
export function randomSolution(n, r) {
  const sol = new Array(n).fill(-1);
  const used = new Array(n).fill(false);
  const place = (row) => {
    if (row === n) return true;
    for (const c of shuffled([...Array(n).keys()], r)) {
      if (used[c] || (row > 0 && Math.abs(sol[row - 1] - c) < 2)) continue;
      sol[row] = c;
      used[c] = true;
      if (place(row + 1)) return true;
      used[c] = false;
    }
    return false;
  };
  return place(0) ? sol : null;
}

// --- 2. the patches --------------------------------------------------------------

const neighbours4 = (n, cell) => {
  const r = Math.floor(cell / n);
  const c = cell % n;
  const out = [];
  if (r > 0) out.push(cell - n);
  if (r < n - 1) out.push(cell + n);
  if (c > 0) out.push(cell - 1);
  if (c < n - 1) out.push(cell + 1);
  return out;
};

// Patch i starts at row i's creature and grows a cell at a time into free
// neighbours until the grid is full. Each step picks the patch at random,
// weighted by `weights` (a few patches grow faster: long ones, big ones,
// small ones — boards don't all look alike).
export function growRegions(n, sol, r) {
  const regions = new Array(n * n).fill(-1);
  const weights = [];
  for (let i = 0; i < n; i++) {
    regions[i * n + sol[i]] = i;
    const roll = r();
    weights.push(roll < 0.2 ? 0.35 : roll > 0.85 ? 2.6 : 1);
  }
  let free = n * n - n;
  while (free > 0) {
    // every patch with room to grow, and its free neighbours
    const open = [];
    let total = 0;
    for (let i = 0; i < n; i++) open.push([]);
    for (let cell = 0; cell < n * n; cell++) {
      if (regions[cell] < 0) continue;
      for (const nb of neighbours4(n, cell)) if (regions[nb] < 0) open[regions[cell]].push(nb);
    }
    for (let i = 0; i < n; i++) if (open[i].length) total += weights[i];
    let pick = r() * total;
    let reg = 0;
    for (; reg < n; reg++) {
      if (!open[reg].length) continue;
      pick -= weights[reg];
      if (pick <= 0) break;
    }
    if (reg >= n) reg = open.findIndex((o) => o.length);
    const cells = open[reg];
    regions[cells[Math.floor(r() * cells.length)]] = reg;
    free--;
  }
  return regions;
}

// An answer to the board other than `sol` (column per row), or null.
function otherSolution(n, regions, sol) {
  const cols = new Array(n).fill(false);
  const regs = new Array(n).fill(false);
  const cur = new Array(n);
  const go = (row, prev, same) => {
    if (row === n) return !same;
    for (let c = 0; c < n; c++) {
      const reg = regions[row * n + c];
      if (cols[c] || regs[reg] || (prev >= 0 && Math.abs(prev - c) < 2)) continue;
      cols[c] = regs[reg] = true;
      cur[row] = c;
      const found = go(row + 1, c, same && c === sol[row]);
      cols[c] = regs[reg] = false;
      if (found) return true;
    }
    return false;
  };
  return go(0, -1, true) ? cur.slice() : null;
}

// Whether patch `reg` stays in one piece without `cell`.
function connectedWithout(n, regions, reg, cell) {
  const cells = [];
  for (let i = 0; i < n * n; i++) if (regions[i] === reg && i !== cell) cells.push(i);
  if (!cells.length) return false;
  const seen = new Set([cells[0]]);
  const todo = [cells[0]];
  while (todo.length) {
    for (const nb of neighbours4(n, todo.pop())) {
      if (nb !== cell && regions[nb] === reg && !seen.has(nb)) {
        seen.add(nb);
        todo.push(nb);
      }
    }
  }
  return seen.size === cells.length;
}

// Random patches mostly allow more than one answer (1 in 40 at 6×6). This
// mends them: while a second answer exists, one of its creatures that isn't
// in ours moves its cell over to a neighbouring patch — that patch then holds
// two of the other answer's creatures, so that answer is gone. Patches stay
// in one piece and keep their own creature. Null if it gets stuck.
export function makeUnique(n, regions, sol, r, maxMoves = 6 * n) {
  const regs = regions.slice();
  const ours = new Set(sol.map((c, row) => row * n + c));
  for (let move = 0; move < maxMoves; move++) {
    const alt = otherSolution(n, regs, sol);
    if (!alt) return regs;
    const options = [];
    alt.forEach((c, row) => {
      const cell = row * n + c;
      if (ours.has(cell)) return;
      for (const nb of neighbours4(n, cell)) {
        if (regs[nb] !== regs[cell]) options.push([cell, regs[nb]]);
      }
    });
    const ok = shuffled(options, r).find(([cell]) => connectedWithout(n, regs, regs[cell], cell));
    if (!ok) return null;
    regs[ok[0]] = ok[1];
  }
  return null;
}

// --- checking ----------------------------------------------------------------------

// How many answers a board has (stops at `limit`): the tests' check that the
// grader only keeps one-answer boards.
export function countSolutions(n, regions, limit = 2) {
  let count = 0;
  const cols = new Array(n).fill(false);
  const regs = new Array(n).fill(false);
  const go = (row, prev) => {
    if (row === n) {
      count++;
      return count >= limit;
    }
    for (let c = 0; c < n; c++) {
      const reg = regions[row * n + c];
      if (cols[c] || regs[reg] || (prev >= 0 && Math.abs(prev - c) < 2)) continue;
      cols[c] = regs[reg] = true;
      const stop = go(row + 1, c);
      cols[c] = regs[reg] = false;
      if (stop) return true;
    }
    return false;
  };
  go(0, -1);
  return count;
}

// Whether `cells` (filled cell numbers) break a rule: two in a row, column or
// patch, or two touching. The board uses this for the red warnings.
export function conflicts(n, regions, cells) {
  const bad = new Set();
  for (let i = 0; i < cells.length; i++) {
    for (let j = i + 1; j < cells.length; j++) {
      const a = cells[i];
      const b = cells[j];
      const ra = Math.floor(a / n);
      const rb = Math.floor(b / n);
      const ca = a % n;
      const cb = b % n;
      if (ra === rb || ca === cb || regions[a] === regions[b] || (Math.abs(ra - rb) <= 1 && Math.abs(ca - cb) <= 1)) {
        bad.add(a);
        bad.add(b);
      }
    }
  }
  return bad;
}

// --- 3. solving like a player ------------------------------------------------------

// The 3n lines a creature must appear in once: rows, columns, patches. Each
// is a list of cells; `unitsOf[cell]` the three a cell belongs to.
function unitsFor(n, regions) {
  const units = [];
  for (let r = 0; r < n; r++) units.push([...Array(n).keys()].map((c) => r * n + c));
  for (let c = 0; c < n; c++) units.push([...Array(n).keys()].map((r) => r * n + c));
  for (let g = 0; g < n; g++) units.push([]);
  for (let cell = 0; cell < n * n; cell++) units[2 * n + regions[cell]].push(cell);
  const unitsOf = [];
  for (let cell = 0; cell < n * n; cell++) {
    unitsOf.push([Math.floor(cell / n), n + (cell % n), 2 * n + regions[cell]]);
  }
  return { units, unitsOf };
}

// The cells a creature at `cell` rules out: its row, column, patch and the
// eight around it.
function shadowOf(n, regions, cell) {
  const r = Math.floor(cell / n);
  const c = cell % n;
  const out = new Set();
  for (let i = 0; i < n; i++) {
    out.add(r * n + i);
    out.add(i * n + c);
  }
  for (let dr = -1; dr <= 1; dr++) {
    for (let dc = -1; dc <= 1; dc++) {
      const rr = r + dr;
      const cc = c + dc;
      if (rr >= 0 && rr < n && cc >= 0 && cc < n) out.add(rr * n + cc);
    }
  }
  for (let i = 0; i < n * n; i++) if (regions[i] === regions[cell]) out.add(i);
  out.delete(cell);
  return out;
}

function makeSolver(n, regions) {
  const { units, unitsOf } = unitsFor(n, regions);
  const shadows = [];
  for (let cell = 0; cell < n * n; cell++) shadows.push(shadowOf(n, regions, cell));
  return { n, units, unitsOf, shadows };
}

// state: { cand: bool[n*n], placed: bool[n*n], done: bool[3n] }
const fresh = (n) => ({ cand: new Array(n * n).fill(true), placed: new Array(n * n).fill(false), done: new Array(3 * n).fill(false), count: 0 });
const copy = (s) => ({ cand: s.cand.slice(), placed: s.placed.slice(), done: s.done.slice(), count: s.count });

function place(S, s, cell) {
  s.placed[cell] = true;
  s.cand[cell] = false;
  s.count++;
  for (const u of S.unitsOf[cell]) s.done[u] = true;
  for (const x of S.shadows[cell]) s.cand[x] = false;
}

const freeIn = (S, s, u) => S.units[u].filter((cell) => s.cand[cell]);
// a line still waiting for its creature with no free cell left
const stuck = (S, s) => S.units.some((cells, u) => !s.done[u] && !cells.some((cell) => s.cand[cell]));

// One forced step, the cheapest kind first. Returns the grade of the trick
// it used (1-5), 0 when nothing is forced, -1 when the state is broken.
// `maxGrade` stops before the costlier tricks (the chains look-ahead uses
// 1-2 only).
function step(S, s, maxGrade = 5) {
  const { n, units } = S;
  if (stuck(S, s)) return -1;
  // 1 singles
  for (let u = 0; u < units.length; u++) {
    if (s.done[u]) continue;
    const free = freeIn(S, s, u);
    if (free.length === 1) {
      place(S, s, free[0]);
      return 1;
    }
  }
  if (maxGrade < 2) return 0;
  // 2 peeks: a creature here would leave another line no room
  for (let cell = 0; cell < n * n; cell++) {
    if (!s.cand[cell]) continue;
    const sh = S.shadows[cell];
    const mine = S.unitsOf[cell];
    for (let u = 0; u < units.length; u++) {
      if (s.done[u] || mine.includes(u)) continue;
      if (units[u].every((x) => !s.cand[x] || sh.has(x))) {
        s.cand[cell] = false;
        return 2;
      }
    }
  }
  if (maxGrade < 3) return 0;
  // 3-4 pairs and groups: k lines of one kind whose free cells all sit in
  // k lines of another kind own those lines — every other free cell in them goes.
  const kinds = [
    [0, n], // rows
    [n, 2 * n], // columns
    [2 * n, 3 * n], // patches
  ];
  for (let k = 2; k < n; k++) {
    for (const [a0, a1] of kinds) {
      for (const [b0, b1] of kinds) {
        if (a0 === b0) continue;
        const open = [];
        for (let u = a0; u < a1; u++) if (!s.done[u]) open.push(u);
        if (open.length <= k) continue;
        // which b-lines each open a-line's free cells fall in
        const spans = open.map((u) => {
          const set = new Set();
          for (const cell of units[u]) if (s.cand[cell]) set.add(S.unitsOf[cell][b0 === 0 ? 0 : b0 === n ? 1 : 2]);
          return set;
        });
        const found = combos(open.length, k, (idx) => {
          const span = new Set();
          for (const i of idx) for (const b of spans[i]) span.add(b);
          if (span.size !== k) return false;
          const mine = new Set(idx.map((i) => open[i]));
          let changed = false;
          for (const b of span) {
            for (const cell of units[b]) {
              if (!s.cand[cell]) continue;
              const a = S.unitsOf[cell][a0 === 0 ? 0 : a0 === n ? 1 : 2];
              if (!mine.has(a)) {
                s.cand[cell] = false;
                changed = true;
              }
            }
          }
          return changed;
        });
        if (found) return k === 2 ? 3 : 4;
      }
    }
  }
  if (maxGrade < 5) return 0;
  // 5 chains: try a creature here, follow the easy steps; a dead end rules it out
  for (let cell = 0; cell < n * n; cell++) {
    if (!s.cand[cell]) continue;
    const t = copy(s);
    place(S, t, cell);
    let g;
    let guard = 0;
    while ((g = step(S, t, 2)) > 0 && guard++ < 200);
    if (g === -1) {
      s.cand[cell] = false;
      return 5;
    }
  }
  return 0;
}

// Calls `fn(indices)` for every k-subset of 0..m-1 until it returns true.
function combos(m, k, fn) {
  const idx = [...Array(k).keys()];
  for (;;) {
    if (fn(idx)) return true;
    let i = k - 1;
    while (i >= 0 && idx[i] === m - k + i) i--;
    if (i < 0) return false;
    idx[i]++;
    for (let j = i + 1; j < k; j++) idx[j] = idx[j - 1] + 1;
  }
}

const STALL_COST = [0, 0, 1, 3, 5, 8];

// Solves a board like a player: { solved, grade, steps, effort, solution }.
export function grade(n, regions) {
  const S = makeSolver(n, regions);
  const s = fresh(n);
  let max = 0;
  let steps = 0;
  // effort: every time no single is in sight the player has to think, as
  // hard as the hardest trick before the next single
  let effort = 0;
  let stall = 0;
  let g;
  while (s.count < n && (g = step(S, s)) > 0) {
    max = Math.max(max, g);
    steps++;
    if (g === 1) {
      effort += STALL_COST[stall];
      stall = 0;
    } else stall = Math.max(stall, g);
  }
  effort += STALL_COST[stall];
  if (s.count < n) return { solved: false, grade: max, steps, effort };
  const solution = [];
  for (let r = 0; r < n; r++) solution.push(s.placed.slice(r * n, r * n + n).indexOf(true));
  return { solved: true, grade: max, steps, effort, solution };
}

// --- making one --------------------------------------------------------------------

// A maker for one board of size `n` at `tier` (0-3), worked a slice at a
// time so the app stays smooth: `maker.run(ms)` tries boards for about `ms`
// and returns the puzzle once it has one that fits (else null; call again).
// After `maxTries` it settles for the closest tier it saw — small boards
// can't be expert. `seed` fixes everything it does.
export function puzzleMaker({ n, tier = 0, seed = Math.floor(Math.random() * 2 ** 31), maxTries = 600 }) {
  const r = rng(seed);
  let tries = 0;
  let best = null;
  let result = null;
  const tryOne = () => {
    tries++;
    const sol = randomSolution(n, r);
    if (!sol) return null;
    const regions = makeUnique(n, growRegions(n, sol, r), sol, r);
    if (!regions) return null;
    const g = grade(n, regions);
    if (!g.solved) return null;
    const p = { n, regions, solution: g.solution, grade: g.grade, effort: g.effort, tier: tierOf(g.effort), steps: g.steps, seed };
    const off = Math.abs(p.tier - tier);
    // a near miss: below the tier beats above it (too easy, not too hard)
    const score = off * 2 + (p.tier > tier ? 1 : 0);
    if (!best || score < best.score) best = { p, score };
    return off === 0 ? p : null;
  };
  return {
    get tries() {
      return tries;
    },
    run(ms = 8) {
      if (result) return result;
      const until = Date.now() + ms;
      do {
        const p = tryOne();
        if (p) return (result = p);
        if (tries >= maxTries && best) return (result = best.p);
      } while (Date.now() < until);
      return null;
    },
  };
}

// Makes one board straight away (the tests, and node tools).
export function makePuzzle(opts) {
  const m = puzzleMaker(opts);
  let p = null;
  while (!(p = m.run(50)));
  return p;
}

// The same board, made over several frames: resolves with the puzzle.
// `signal.cancelled = true` stops it.
export function makePuzzleAsync(opts, signal = {}) {
  const m = puzzleMaker(opts);
  return new Promise((resolve, reject) => {
    const tick = () => {
      if (signal.cancelled) return reject(new Error('cancelled'));
      const p = m.run(6);
      if (p) resolve(p);
      else setTimeout(tick, 0);
    };
    tick();
  });
}
