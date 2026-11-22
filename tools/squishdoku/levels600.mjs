// Squishdoku's 600 fixed levels (SQUISHDOKU.md "600 levels"): every level is
// one board, made here once and shipped in src/squishdoku/levelData.js, so a
// level is the same board every time it's played. No skill score.
//
//   node tools/squishdoku/levels600.mjs [--plan]
//
// 1. Workers make a set number of boards of every size with the game's own
//    engine (src/squishdoku/engine.js: random answer → grown patches → made
//    unique → graded like a player), keeping up to K per (size, effort).
// 2. Boards are de-duplicated: the same patches turned or mirrored count once.
// 3. The plan gives each level a size and a target effort (the grader's score
//    of how much thinking it takes; see `plan`). Each level takes the unused
//    board closest to its target, the rarest (hardest) targets first.
//    The 9×9 years need harder boards than the plain maker gives (its top
//    0.1% is effort 25), so the workers also climb: a 9×9 board's patches
//    are reshaped a cell at a time, keeping each change that leaves one
//    answer, solvable by logic, no less effort, and patches shaped like the
//    plain maker's (SHAPE: without it the climb wins by growing snakes and
//    one-cell-wide passages). One minute of 8 workers made boards up to 48.
// 4. Every chosen board is checked again: exactly one answer, solved by logic.
// It prints a table per chapter and writes levelData.js. Fixed seeds and
// counts (not time budgets), so a run gives the same levels on any machine:
// run it again after changing the plan.
import { Worker, isMainThread, parentPort, workerData } from 'node:worker_threads';
import fs from 'node:fs';
import path from 'node:path';
import { fileURLToPath, pathToFileURL } from 'node:url';
import { shapeFits, shapeOf } from './shape.mjs';

const HERE = fileURLToPath(import.meta.url);
const ROOT = path.resolve(path.dirname(HERE), '../..');
const E = await import(pathToFileURL(path.join(ROOT, 'src/squishdoku/engine.js')).href);

// --- the climb: the patches keep a plain board's shape (shape.mjs SHAPE) ---------------
const nb4 = (n, cell) => {
  const r = Math.floor(cell / n);
  const c = cell % n;
  const o = [];
  if (r) o.push(cell - n);
  if (r < n - 1) o.push(cell + n);
  if (c) o.push(cell - 1);
  if (c < n - 1) o.push(cell + 1);
  return o;
};
// One climb from a fresh plain board: move a random cell into a neighbouring
// patch; keep it if the patch it left is still in one piece, the shape still
// fits, there's still exactly one answer, the grader still solves it, and the
// effort didn't drop. Stops after 150·n tries without a gain.
function climb(n, r) {
  let cur = null;
  while (!cur) {
    const sol = E.randomSolution(n, r);
    const regions = sol && E.makeUnique(n, E.growRegions(n, sol, r), sol, r);
    if (!regions || !shapeFits(n, regions)) continue;
    const g = E.grade(n, regions);
    if (g.solved) cur = { regions, effort: g.effort };
  }
  let since = 0;
  while (since < 150 * n) {
    since++;
    const cell = Math.floor(r() * n * n);
    const from = cur.regions[cell];
    const opts = nb4(n, cell)
      .map((x) => cur.regions[x])
      .filter((q) => q !== from);
    if (!opts.length) continue;
    const regs = cur.regions.slice();
    regs[cell] = opts[Math.floor(r() * opts.length)];
    const rest = [];
    for (let i = 0; i < n * n; i++) if (regs[i] === from) rest.push(i);
    if (!rest.length) continue;
    const seen = new Set([rest[0]]);
    const todo = [rest[0]];
    while (todo.length) {
      for (const x of nb4(n, todo.pop())) {
        if (regs[x] === from && !seen.has(x)) {
          seen.add(x);
          todo.push(x);
        }
      }
    }
    if (seen.size !== rest.length) continue;
    if (!shapeFits(n, regs)) continue;
    if (E.countSolutions(n, regs, 2) !== 1) continue;
    const g = E.grade(n, regs);
    if (!g.solved || g.effort < cur.effort) continue;
    if (g.effort > cur.effort) since = 0;
    cur = { regions: regs, effort: g.effort };
  }
  const g = E.grade(n, cur.regions);
  return { regions: Array.from(cur.regions), solution: g.solution, effort: g.effort, climbed: true };
}

// --- 1. a worker: boards of each size, then climbed 9×9s ------------------------------
if (!isMainThread) {
  const { w, counts, K, climbs } = workerData;
  const out = {};
  for (const [n, count] of counts) {
    const r = E.rng(1000003 * (w + 1) + n * 7919);
    const keep = new Map();
    let made = 0;
    while (made < count) {
      const sol = E.randomSolution(n, r);
      if (!sol) continue;
      const regions = E.makeUnique(n, E.growRegions(n, sol, r), sol, r);
      if (!regions) continue;
      const g = E.grade(n, regions);
      if (!g.solved) continue;
      made++;
      const list = keep.get(g.effort) || [];
      if (list.length < K[n]) {
        list.push({ regions: Array.from(regions), solution: g.solution, effort: g.effort });
        keep.set(g.effort, list);
      }
    }
    out[n] = { made, boards: [...keep.values()].flat() };
  }
  // the climbed 9×9s: a set number per worker, its own seed
  const r = E.rng(7000003 * (w + 1));
  for (let k = 0; k < climbs; k++) out[9].boards.push(climb(9, r));
  parentPort.postMessage(out);
}

// --- 3. the plan ----------------------------------------------------------------------

// 30 chapters of 20, one Crib room each (levels.js stageOf). Inside a
// chapter the target rises; the 5th, 10th and 15th are breathers, the 20th
// the chapter's hardest.
export const CHAPTER = 20;
const SIZE_UPTO = [
  [4, 4],
  [22, 5],
  [45, 6],
  [80, 7],
  [130, 8],
  [600, 9],
];
// what each size can reach, low to high (measured: 4×4 is always 0-1, 5×5
// rarely past 3, …)
const RANGE = { 4: [0, 1], 5: [0, 3], 6: [1, 5], 7: [2, 8], 8: [3, 10] };
export function plan(L) {
  const p = (L - 1) % CHAPTER;
  const breather = p === 4 || p === 9 || p === 14;
  const boss = p === CHAPTER - 1;
  const n = SIZE_UPTO.find(([upto]) => L <= upto)[1];
  if (n < 9) {
    const idx = SIZE_UPTO.findIndex(([, m]) => m === n);
    const from = idx === 0 ? 1 : SIZE_UPTO[idx - 1][0] + 1;
    const to = SIZE_UPTO.find(([, m]) => m === n)[0];
    const u = to > from ? (L - from) / (to - from) : 0;
    const [lo, hi] = RANGE[n];
    const t = breather ? lo : boss ? hi : lo + (hi - lo) * u;
    return { n, target: t, breather, boss };
  }
  // the 9×9 years (131-600): the base climbs from 4 to 32; a chapter adds up
  // to 4 more as it goes; a boss is 8 over its base (up to 40, level 600). A
  // breather is a smaller board (8×8, or 7×7 on the 15th) at a fair effort
  // for its size. (Until the climb, 2026-11-07: base 4 → 24, +3, boss +5.)
  const u = (L - 131) / (600 - 131);
  const base = 4 + 28 * u;
  if (breather) {
    const m = p === 14 ? 7 : 8;
    return { n: m, target: Math.min(RANGE[m][1], Math.max(RANGE[m][0], Math.round(base * 0.45 + 2))), breather, boss };
  }
  return { n: 9, target: boss ? Math.min(40, base + 8) : base + 4 * (p / (CHAPTER - 2)), breather, boss };
}

// --- 2. the same board turned or mirrored counts once ---------------------------------
function canon(n, regions) {
  let best = null;
  for (let s = 0; s < 8; s++) {
    const map = new Map();
    let out = '';
    for (let r = 0; r < n; r++) {
      for (let c = 0; c < n; c++) {
        let rr = r;
        let cc = c;
        if (s & 1) cc = n - 1 - cc;
        if (s & 2) rr = n - 1 - rr;
        if (s & 4) [rr, cc] = [cc, rr];
        const reg = regions[rr * n + cc];
        if (!map.has(reg)) map.set(reg, String.fromCharCode(97 + map.size));
        out += map.get(reg);
      }
    }
    if (best === null || out < best) best = out;
  }
  return best;
}

// a seeded random, for the patch colours
function rng(seed) {
  let s = seed >>> 0 || 1;
  return () => {
    s = (s * 1664525 + 1013904223) >>> 0;
    return s / 4294967296;
  };
}

async function main() {
  const arg = (k, d) => {
    const a = process.argv.find((x) => x.startsWith(`--${k}=`));
    return a ? Number(a.slice(k.length + 3)) : d;
  };
  if (process.argv.includes('--plan')) {
    for (let L = 1; L <= 600; L++) {
      const p = plan(L);
      console.log(L, p.n, p.target.toFixed(1), p.breather ? 'breather' : p.boss ? 'BOSS' : '');
    }
    return;
  }
  // the boards made of each size, in 8 jobs with their own seeds (always 8:
  // the seeds fix the boards), one thread each, then each job's climbs
  const W = 8;
  const TOTAL = { 4: 72000, 5: 68000, 6: 29000, 7: 26400, 8: 19200, 9: 58400 };
  const counts = Object.entries(TOTAL).map(([n, c]) => [Number(n), Math.ceil(c / W)]);
  const K = { 4: 400, 5: 300, 6: 200, 7: 150, 8: 150, 9: 160 };
  // climbed 9×9s per worker (each about 3 s); every one is kept
  const CLIMBS = 100;
  console.log(`making boards: ${W} workers…`);
  const t0 = Date.now();
  const results = await Promise.all(
    Array.from(
      { length: W },
      (_, w) =>
        new Promise((resolve, reject) => {
          const wk = new Worker(HERE, { workerData: { w, counts, K, climbs: CLIMBS } });
          wk.once('message', resolve);
          wk.once('error', reject);
        }),
    ),
  );
  // merge, de-duplicate
  const pools = {};
  const made = {};
  for (const out of results) {
    for (const [n, { made: m, boards }] of Object.entries(out)) {
      made[n] = (made[n] || 0) + m;
      const pool = (pools[n] = pools[n] || new Map());
      boards.forEach((b) => {
        // every 9×9, plain or climbed, keeps a plain board's shape: the plain
        // maker's rare hard ones are often snaky too (levels 380, 471, 524 in
        // the first run with the climb)
        if (Number(n) === 9 && !shapeFits(9, b.regions)) return;
        const key = canon(Number(n), b.regions);
        if (!pool.has(key)) pool.set(key, b);
      });
    }
  }
  console.log(`made in ${((Date.now() - t0) / 1000).toFixed(0)} s:`, Object.entries(made).map(([n, m]) => `${n}×${n} ${m} (${pools[n].size} kept)`).join(', '));

  // assign: the hardest targets first (their boards are the rarest)
  const free = {};
  for (const [n, pool] of Object.entries(pools)) free[n] = [...pool.values()].sort((a, b) => a.effort - b.effort);
  const slots = Array.from({ length: 600 }, (_, i) => ({ L: i + 1, ...plan(i + 1) }));
  const order = slots.slice().sort((a, b) => b.n - a.n || b.target - a.target);
  const chosen = new Array(600);
  for (const s of order) {
    const list = free[s.n];
    let bi = -1;
    let bd = Infinity;
    list.forEach((b, i) => {
      // a little under the target is better than over it
      const d = b.effort >= s.target ? b.effort - s.target : (s.target - b.effort) * 1.3;
      if (d < bd) {
        bd = d;
        bi = i;
      }
    });
    if (bi < 0) throw new Error(`no board left for level ${s.L} (${s.n}×${s.n})`);
    chosen[s.L - 1] = { ...list[bi], n: s.n, target: s.target };
    list.splice(bi, 1);
  }

  // check every one again, and give each its patch colours: the first n of
  // theme.js PATCHES (its order puts the most different hues first: a
  // random n of the 9 put sky next to sapphire), shuffled by level, so
  // neighbouring levels don't look alike
  const rows = chosen.map((b, i) => {
    const { n } = b;
    if (E.countSolutions(n, b.regions, 2) !== 1) throw new Error(`level ${i + 1}: not one answer`);
    const g = E.grade(n, b.regions);
    if (!g.solved || g.effort !== b.effort || g.solution.join() !== b.solution.join()) throw new Error(`level ${i + 1}: grade changed`);
    const r = rng(7919 * (i + 1));
    const colors = [...Array(n).keys()];
    for (let k = colors.length - 1; k > 0; k--) {
      const j = Math.floor(r() * (k + 1));
      [colors[k], colors[j]] = [colors[j], colors[k]];
    }
    return {
      n,
      r: b.regions.map((x) => String.fromCharCode(97 + x)).join(''),
      s: b.solution.join(''),
      c: colors.join(''),
      e: b.effort,
      t: b.target,
      climbed: !!b.climbed,
    };
  });

  // the table: each chapter's sizes and efforts
  console.log('\nchapter  levels    sizes                 effort min / median / max   (targets)');
  for (let c = 0; c < 600 / CHAPTER; c++) {
    const part = rows.slice(c * CHAPTER, (c + 1) * CHAPTER);
    const sizes = {};
    part.forEach((x) => (sizes[x.n] = (sizes[x.n] || 0) + 1));
    const es = part.map((x) => x.e).sort((a, b) => a - b);
    const ts = part.map((x) => x.t);
    console.log(
      `${String(c + 1).padStart(4)}   ${String(c * CHAPTER + 1).padStart(3)}-${String((c + 1) * CHAPTER).padEnd(4)}  ${Object.entries(sizes)
        .map(([n, k]) => `${k}×${n}`)
        .join(' ')
        .padEnd(20)}  ${String(es[0]).padStart(3)} / ${String(es[es.length >> 1]).padStart(3)} / ${String(es[es.length - 1]).padStart(3)}      (${Math.min(...ts).toFixed(0)}-${Math.max(...ts).toFixed(0)})`,
    );
  }
  const off = rows.filter((x) => Math.abs(x.e - x.t) > 2);
  console.log(`\nlevels more than 2 off their target: ${off.length}${off.length ? ` (${off.map((x) => `${rows.indexOf(x) + 1}: ${x.e} for ${x.t.toFixed(1)}`).join(', ')})` : ''}`);
  console.log(`climbed boards used: ${rows.filter((x) => x.climbed).length}, plain: ${rows.filter((x) => !x.climbed).length}`);
  // the patches' shape: the climbed 9×9s next to the plain ones
  const nine = rows.filter((x) => x.n === 9);
  for (const [name, list] of [['plain 9×9', nine.filter((x) => !x.climbed)], ['climbed 9×9', nine.filter((x) => x.climbed)]]) {
    if (!list.length) continue;
    const s = list.map((x) => shapeOf(9, [...x.r].map((ch) => ch.charCodeAt(0) - 97)));
    const avg = (k) => (s.reduce((a, b) => a + b[k], 0) / s.length).toFixed(2);
    console.log(`  ${name.padEnd(12)} ${String(list.length).padStart(3)} boards: corridors ${avg('corridors')}, tips ${avg('tips')}, edges ${avg('edges')}, perimeter ratio ${avg('meanRatio')}`);
  }

  const body = rows.map((x) => `  { n: ${x.n}, r: '${x.r}', s: '${x.s}', c: '${x.c}', e: ${x.e} },`).join('\n');
  const file = `// Generated by tools/squishdoku/levels600.mjs: Squishdoku's 600 levels, one fixed
// board each (SQUISHDOKU.md "600 levels"). Don't edit by hand.
//   n  the grid size
//   r  each cell's patch, row by row (a = patch 0, b = patch 1, …)
//   s  each row's creature: its column
//   c  each patch's colour (an index into theme.js PATCHES)
//   e  the effort: how much thinking it takes (engine.js grade)
export default [
${body}
];
`;
  fs.writeFileSync(path.join(ROOT, 'src/squishdoku/levelData.js'), file);
  console.log(`wrote src/squishdoku/levelData.js (${(file.length / 1024).toFixed(0)} KB)`);
}

if (isMainThread) await main();
