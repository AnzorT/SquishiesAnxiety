// node tools/unity/games/stack/fixtures.mjs — writes fixtures/stack.json: inputs and what src/stack/engine.js and
// levels.js answer for them, for the C# port's differential test (StackDiff.csproj, Program.cs).
//
// Every random number the JS draws comes from a seeded mulberry32 here and is recorded (`tape`), so the C# replays
// the exact sequence and must draw exactly as many.
import { mkdirSync, writeFileSync } from 'node:fs';
import { dirname, join } from 'node:path';
import { fileURLToPath } from 'node:url';
import * as E from '../../../../src/stack/engine.js';
import * as L from '../../../../src/stack/levels.js';
import { levelsConfig, setLevelsConfig, xpRules, addXp, pxpOf } from '../../../../src/playerXp.js';

const here = dirname(fileURLToPath(import.meta.url));

function mulberry32(a) {
  return () => {
    a |= 0;
    a = (a + 0x6d2b79f5) | 0;
    let t = Math.imul(a ^ (a >>> 15), 1 | a);
    t = (t + Math.imul(t ^ (t >>> 7), 61 | t)) ^ t;
    return ((t ^ (t >>> 14)) >>> 0) / 4294967296;
  };
}
// a recording random source
const taped = (seed) => {
  const r = mulberry32(seed);
  const tape = [];
  const rand = () => {
    const v = r();
    tape.push(v);
    return v;
  };
  return { rand, tape };
};
// the generator of the test inputs themselves (not replayed)
const G = mulberry32(20261123);
const int = (n) => Math.floor(G() * n);
const pickOf = (a) => a[int(a.length)];

// FNV-1a over a distance table: checks the whole of solve()'s answer cheaply
function distHash(dist) {
  let h = 2166136261;
  for (let i = 0; i < dist.length; i++) h = Math.imul(h ^ (dist[i] & 0xffff), 16777619) >>> 0;
  return h;
}
const randPos = (n, k) => Array.from({ length: n }, () => int(k));
// a hint walk: bestMove until there
function walk(sol, p) {
  const path = [];
  for (let m = E.bestMove(sol, p); m; m = E.bestMove(sol, p)) {
    path.push(m);
    p = p.slice();
    p[m[0]] = m[2];
  }
  return path;
}
// what C# checks about a solution: the whole table (hash, and itself when small), sampled lefts / best moves, walks
function solCheck(sol, n, k, samples, walks) {
  const pos = [];
  for (let i = 0; i < samples; i++) {
    const p = randPos(n, k);
    pos.push({ p, left: E.left(sol, p), best: E.bestMove(sol, p) });
  }
  const ws = [];
  for (let i = 0; i < walks; i++) {
    const p = randPos(n, k);
    ws.push({ p, path: walk(sol, p) });
  }
  return {
    size: sol.dist.length,
    hash: distHash(sol.dist),
    max: sol.dist.reduce((a, b) => Math.max(a, b), -1),
    dist: sol.dist.length <= 4096 ? Array.from(sol.dist) : null,
    pos,
    walks: ws,
  };
}

// --- basics: stackOf / topOf / canMove / same -------------------------------------------
const basics = [];
for (let c = 0; c < 400; c++) {
  const n = int(9);
  const k = 1 + int(5);
  const pos = randPos(n, k);
  const cushions = Array.from({ length: k + 2 }, (_, i) => i - 1);
  basics.push({
    pos,
    k,
    stackOf: cushions.map((p) => E.stackOf(pos, p)),
    topOf: cushions.map((p) => E.topOf(pos, p)),
    canMove: cushions.map((a) => cushions.map((b) => E.canMove(pos, a, b))),
  });
}
const sames = [];
for (let c = 0; c < 200; c++) {
  const a = randPos(int(6), 3);
  const b = int(3) === 0 ? a.slice() : int(2) ? randPos(a.length, 3) : randPos(int(6), 3);
  sames.push({ a, b, same: E.same(a, b) });
}

// --- solve ---------------------------------------------------------------------------------
const SIZES = [[0, 3], [1, 2], [2, 2], [3, 2], [3, 3], [4, 3], [5, 3], [6, 3], [7, 3], [3, 4], [4, 4], [5, 4], [6, 4], [7, 4], [8, 4], [3, 5], [5, 5], [6, 5], [4, 6]];
const solves = [];
for (const [n, k] of SIZES) {
  const goals = [Array(n).fill(k - 1), Array(n).fill(0)];
  for (let i = 0; i < 6; i++) goals.push(randPos(n, k));
  for (const goal of goals) {
    const sol = E.solve(n, k, goal);
    solves.push({ n, k, goal, ...solCheck(sol, n, k, n === 0 ? 1 : 40, n === 0 ? 1 : 3) });
  }
}

// --- makePuzzle ------------------------------------------------------------------------------
const specOut = (s) => ({ ...s, par: s.par ? s.par.slice() : null });
function puzzleCase(spec, seed, what) {
  const { rand, tape } = taped(seed);
  const P = E.makePuzzle(spec, rand);
  const draws = tape.length;
  // what's checked of the solution uses the input generator, not the tape
  return {
    what,
    spec: specOut(spec),
    seed,
    tape,
    draws,
    start: P.start,
    goal: P.goal,
    star: P.star,
    par: P.par,
    hint: E.bestMove(P.sol, P.start),
    sol: solCheck(P.sol, spec.n, spec.k, 8, 1),
  };
}
const puzzles = [];
let seed = 1;
for (let lv = 1; lv <= L.LEVELS; lv++) {
  for (let skill = -2; skill <= 2; skill++) {
    for (let r = 0; r < 4; r++) puzzles.push(puzzleCase(L.levelSpec(lv, skill), seed++ * 7919, `level ${lv} skill ${skill}`));
  }
}
// the endless Blitz (develop, 2026-11-16): the climb, then 7-on-4 and 8-on-4 for good
const BLITZ_N = 22;
for (let i = 0; i < BLITZ_N; i++) {
  for (let skill = -2; skill <= 2; skill++) {
    for (let r = 0; r < 4; r++) puzzles.push(puzzleCase(L.blitzSpec(i, skill), seed++ * 7919, `blitz ${i} skill ${skill}`));
  }
}
// odd par ranges: widening, nothing in range, ranges past the farthest state
const odd = [
  { n: 3, k: 3, start: 'scrambled', goal: 'star', par: [0, 0] },
  { n: 3, k: 3, start: 'scrambled', goal: 'star', par: [30, 40] },
  { n: 3, k: 3, start: 'scrambled', goal: 'picture', par: [20, 25] },
  { n: 4, k: 3, start: 'scrambled', goal: 'star', par: [-5, -3] },
  { n: 2, k: 2, start: 'scrambled', goal: 'picture', par: [1, 1] },
  { n: 5, k: 4, start: 'scrambled', goal: 'picture', par: [14, 14] },
  { n: 6, k: 4, start: 'tower', goal: 'star', par: [1, 2] },
  { n: 8, k: 4, start: 'scrambled', goal: 'picture', par: [40, 60] },
  { n: 6, k: 5, start: 'scrambled', goal: 'star', par: [5, 9] },
];
for (const spec of odd) for (let r = 0; r < 5; r++) puzzles.push(puzzleCase(spec, seed++ * 7919, `odd ${spec.n}x${spec.k} ${spec.par}`));

// --- specs ---------------------------------------------------------------------------------
const LVS = [-5, -0.5, 0, 0.5, 1.9, 3.7, 50.9, 51, 100, 1e9];
for (let lv = 1; lv <= L.LEVELS; lv++) LVS.push(lv);
const SKILLS = [-3, -2, -1.5, -1, -0.99, -0.5, 0, 0.5, 1, 1.19, 1.2, 1.5, 2, 3];
const specs = [];
for (const lv of LVS) {
  specs.push({ lv, skill: null, spec: L.levelSpec(lv) });
  for (const skill of SKILLS) specs.push({ lv, skill, spec: L.levelSpec(lv, skill) });
}
const PARS = [0, 1, 3, 5, 7, 9, 13, 15, 17, 22, 26, 28, 33, 40];
const blitzSpecs = [];
for (let i = 0; i < BLITZ_N; i++) {
  blitzSpecs.push({ i, skill: null, spec: L.blitzSpec(i) });
  for (const skill of SKILLS) blitzSpecs.push({ i, skill, spec: L.blitzSpec(i, skill) });
}

// --- scoring --------------------------------------------------------------------------------
const nextSkills = [];
const SK = [-2.5, -2, -1.73, -1.5, -1.2, -1, -0.65, -0.5, -0.35, -0.15, 0, 0.01, 0.1, 0.15, 0.2, 0.35, 0.5, 0.7, 1.05, 1.2, 1.65, 1.8, 2, 2.3];
for (let i = 0; i < 60; i++) SK.push(Math.round((G() * 5 - 2.5) * 100) / 100, G() * 5 - 2.5);
for (const skill of SK) {
  for (const won of [false, true]) for (let stars = 0; stars <= 3; stars++) for (const hinted of [false, true]) nextSkills.push({ skill, won, stars, hinted, out: L.nextSkill(skill, { won, stars, hinted }) });
}
const twoStars = [];
for (let par = 0; par <= 60; par++) twoStars.push({ par, out: L.twoStarMoves(par) });
const starsFor = [];
for (let par = 1; par <= 40; par++) for (let moves = 0; moves <= par * 3 + 2; moves++) for (const hinted of [false, true]) starsFor.push({ par, moves, hinted, out: L.starsFor(par, { moves, hinted }) });
const coins = [];
const xps = [];
for (let lv = 1; lv <= L.LEVELS; lv++) {
  for (const skill of [-2, 0, 2]) {
    const s = L.levelSpec(lv, skill);
    for (const par of [1, 4, 7, 10, 13, 17, 22, 28, 33]) for (let stars = 0; stars <= 3; stars++) coins.push({ lv, skill, blitz: null, par, stars, out: L.coinsFor(s, par, stars) });
    for (const stars of [0, 1, 2, 2.5, 3]) xps.push({ lv, skill, blitz: null, stars, out: L.xpFor(s, stars) });
  }
}
for (let i = 0; i < BLITZ_N; i++) {
  const s = L.blitzSpec(i, 0);
  for (const par of [3, 9, 16]) for (let stars = 0; stars <= 3; stars++) coins.push({ lv: 0, skill: 0, blitz: i, par, stars, out: L.coinsFor(s, par, stars) });
  for (let stars = 0; stars <= 3; stars++) xps.push({ lv: 0, skill: 0, blitz: i, stars, out: L.xpFor(s, stars) });
}

// --- profiles ------------------------------------------------------------------------------------
// config/levels docs (null: the defaults) and the numbers levelsOf makes of them, which C# is given
const CONFIGS = [
  null,
  { xpPerLevel: 150, xp: { games: 1.3, replay: 0.3, blitz: { stack: 250.5 } } },
  { xpPerLevel: 77.7, xp: { games: 0.85, replay: 1, blitz: { stack: 199.4 } } },
  { xpPerLevel: 100, xp: { games: 2, replay: 0 } },
];
const maybe = (p, v) => (G() < p ? v : undefined);
function randProfile() {
  const p = {};
  const r = G();
  if (r < 0.55) p.pxp = pickOf([0, 0, 1, 99, 100, 299, 300, 1234.5, 5000, 9999, 25000, -50, int(60000)]);
  else if (r < 0.7) p.pxp = null;
  if (G() < 0.4) p.level = pickOf([null, 0, 1, 2, 3.5, 7, 12, 30, -2]);
  if (G() < 0.3) p.sdk = pickOf([null, {}, { xp: 50 }, { xp: 123.9 }, { xp: -5 }, { xp: null }, 4]);
  if (G() < 0.08) return p;
  if (G() < 0.05) {
    p.stack = null;
    return p;
  }
  const s = {};
  s.lv = maybe(0.85, pickOf([1, 1, 2, 3, 5, 9, 14, 15, 20, 21, 22, 30, 44, 49, 50, 50, 0, null, 51, 75, 3.5, -4]));
  if (G() < 0.8) {
    const best = {};
    const top = int(52);
    for (let i = 1; i <= top; i++) if (G() < 0.85) best[i] = pickOf([1, 2, 3, 3, 3, 0, null]);
    s.best = best;
  } else if (G() < 0.3) s.best = null;
  s.skill = maybe(0.7, pickOf([0, -2, -1.5, -1, -0.65, 0.35, 0.7, 1.19, 1.2, 1.5, 2, null, Math.round((G() * 4 - 2) * 100) / 100]));
  s.plays = maybe(0.7, pickOf([0, 1, 5, 17, 120, null]));
  s.wins = maybe(0.7, pickOf([0, 1, 3, 15, 99, null]));
  s.seen = maybe(0.6, pickOf([true, false, null, 1, 0]));
  s.bSkill = maybe(0.6, pickOf([0, -2, -0.3, 0.4, 1.6, 2, null, Math.round((G() * 4 - 2) * 100) / 100]));
  if (G() < 0.6) {
    const b = {};
    if (G() < 0.7) b.top = pickOf([0, 1, 4, 6, 9, 10, 17, null]);
    if (G() < 0.5) b.runs = pickOf([0, 1, 3, 12, null]);
    if (G() < 0.4) b.reached = pickOf([0, 1, 4, 6, 9, 10, null]);
    if (G() < 0.6) b.bestMs = pickOf([0, 90000, 150000, 199999, 240000, null]);
    if (G() < 0.6) b.wins = pickOf([0, 1, 2, 7, null]);
    s.blitz = b;
  } else if (G() < 0.2) s.blitz = null;
  for (const key of Object.keys(s)) if (s[key] === undefined) delete s[key];
  p.stack = s;
  return p;
}
const recOut = (rec) => ({ ...rec, blitz: { top: Number(rec.blitz.top), runs: Number(rec.blitz.runs), reached: Number(rec.blitz.reached), bestMs: Number(rec.blitz.bestMs), wins: Number(rec.blitz.wins) } });
const lvlOut = (o) => ({
  update: o.update,
  coins: o.coins,
  xp: o.xp,
  before: o.before || null,
  after: o.after || null,
  levelUps: o.levelUps,
  stars: o.stars === undefined ? null : o.stars,
  unlocked: o.unlocked === undefined ? null : o.unlocked,
  newTop: o.newTop === undefined ? null : o.newTop,
});
const profiles = [];
for (const cfg of CONFIGS) {
  setLevelsConfig(cfg);
  const lc = levelsConfig();
  const rules = { xpPerLevel: lc.xpPerLevel, games: xpRules().games, replay: xpRules().replay, blitzStack: xpRules().blitz.stack };
  const cases = [];
  for (let c = 0; c < 250; c++) {
    const profile = randProfile();
    const rec = L.record(profile);
    const levels = [];
    for (let t = 0; t < 6; t++) {
      const blitz = G() < 0.1;
      const lv = blitz ? int(BLITZ_N) : int(3) === 0 && typeof rec.lv === 'number' ? Math.min(50, Math.max(1, Math.floor(rec.lv))) : 1 + int(L.LEVELS);
      const skill = pickOf([-2, -1, 0, 0, 1.2, 2]);
      const spec = blitz ? L.blitzSpec(lv, skill) : L.levelSpec(lv, skill);
      const par = Math.max(1, (spec.par ? spec.par[0] : 7) + int(5) - 1);
      const won = G() < 0.75;
      const moves = pickOf([par, par, par + 1, par + 3, L.twoStarMoves(par), L.twoStarMoves(par) + 1, par * 4, 0]);
      const hinted = G() < 0.25;
      levels.push({ lv, blitz, skill, par, won, moves, hinted, out: lvlOut(L.afterLevel(profile, spec, par, { won, moves, hinted })) });
    }
    const blitzes = [];
    for (let t = 0; t < 3; t++) {
      const cleared = pickOf([0, 0, 1, 3, 4, 5, 9, 10, 11, 16, 25]);
      blitzes.push({ cleared, out: lvlOut(L.afterBlitz(profile, { cleared })) });
    }
    const adds = [];
    for (const n of [0, 1, 12, 49.5, 50.5, -3, 100, 333, 2500]) {
      const a = addXp(profile, n);
      adds.push({ n, out: { xp: a.xp, before: a.before, after: a.after, levelUps: a.levelUps } });
    }
    const prizes = [0, 1, 5, 10, 11, 16, 17, 30].map((cleared) => ({ cleared, skill: rec.bSkill, out: L.blitzPrize(cleared, rec.bSkill) }));
    cases.push({ prizes, profile, record: recOut(rec), starsOf: L.starsOf(rec), doneOf: L.doneOf(rec), pxp: pxpOf(profile), levels, blitzes, adds });
  }
  profiles.push({ cfg, rules, cases });
}
setLevelsConfig(null);

// --- clock -------------------------------------------------------------------------------------
const MS = [-5000, -1, -0.5, 0, 0.4, 1, 999, 1000, 1000.0001, 1001, 9999, 10000, 59000, 59999, 60000, 60001, 61000, 599000, 600000, 3599999, 3600000, 1e7, 240000, 12345.678];
for (let i = 0; i < 100; i++) MS.push(Math.floor(G() * 4e6) - 1000, G() * 3e5);
const clocks = MS.map((ms) => ({ ms, out: L.clock(ms) }));

// --- constants -------------------------------------------------------------------------------------
const consts = {
  LEVELS: L.LEVELS,
  LEVEL_LIST: L.LEVEL_LIST,
  TIER_NAMES: L.TIER_NAMES,
  TIER_COLORS: L.TIER_COLORS,
  PICTURE_FROM: L.PICTURE_FROM,
  LATE_FROM: L.LATE_FROM,
  SKILL_MIN: L.SKILL_MIN,
  SKILL_MAX: L.SKILL_MAX,
  BLITZ_COINS: L.BLITZ_COINS,
  skillShift: SKILLS.map((s) => ({ skill: s, out: L.skillShift(s) })),
};

// --- timing: solve() on the biggest boards ------------------------------------------------------------
const timing = [];
for (const [n, k] of [[8, 4], [7, 4], [6, 5], [7, 3]]) {
  const goals = Array.from({ length: 5 }, () => randPos(n, k));
  for (const g of goals) E.solve(n, k, g); // warm up
  const runs = 30;
  const t0 = process.hrtime.bigint();
  for (let i = 0; i < runs; i++) E.solve(n, k, goals[i % goals.length]);
  const ms = Number(process.hrtime.bigint() - t0) / 1e6 / runs;
  timing.push({ n, k, goals, runs, jsMs: ms });
}

const out = { consts, basics, sames, solves, puzzles, specs, blitzSpecs, nextSkills, twoStars, starsFor, coins, xps, profiles, clocks, timing };
mkdirSync(join(here, 'fixtures'), { recursive: true });
const file = join(here, 'fixtures', 'stack.json');
writeFileSync(file, JSON.stringify(out));
const count = (a) => a.length;
console.log(
  `wrote ${file}: ${count(basics)} positions, ${count(sames)} same, ${count(solves)} solves, ${count(puzzles)} puzzles, ` +
    `${count(specs)} levelSpecs, ${count(blitzSpecs)} blitzSpecs, ${count(nextSkills)} nextSkill, ` +
    `${count(starsFor)} starsFor, ${count(coins)} coins, ${count(xps)} xp, ${profiles.reduce((a, p) => a + p.cases.length, 0)} profiles, ${count(clocks)} clocks`,
);
console.log(`JS solve(): ${timing.map((t) => `${t.n}x${t.k} ${t.jsMs.toFixed(2)} ms`).join(', ')}`);
