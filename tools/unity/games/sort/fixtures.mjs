// node tools/unity/games/sort/fixtures.mjs
//
// Squish Sort's differential test, JS side: runs the real game modules
// (src/sort/board.js, src/sort/levels.js, src/playerXp.js) on generated
// inputs and writes them with the JS's outputs to ./fixtures/*.json. The C#
// port (unity/Assets/Scripts/Games/Sort) replays the same inputs in
// SortDiff.csproj (dotnet run -c Release --project tools/unity/games/sort)
// and must give the same outputs.
//
// Randomness: makeBoard draws from a mulberry32 here; every raw number it
// takes is recorded with the case, so C# replays the exact sequence and
// checks it takes exactly as many.
import fs from 'node:fs';
import path from 'node:path';
import { fileURLToPath } from 'node:url';
import { drop, makeBoard, occupant, solved, startState } from '../../../../src/sort/board.js';
import * as L from '../../../../src/sort/levels.js';
import { setLevelsConfig } from '../../../../src/playerXp.js';
import * as M from '../../../../src/sort/models.js';

const here = path.dirname(fileURLToPath(import.meta.url));
// props.js is JSX (no node import): its KINDS read from the source
const KINDS_DATA = Number(/export const KINDS = (\d+);/.exec(fs.readFileSync(path.join(here, '../../../../src/sort/props.js'), 'utf8'))[1]);
const outDir = path.join(here, 'fixtures');
fs.mkdirSync(outDir, { recursive: true });

function mulberry32(a) {
  return function () {
    a |= 0;
    a = (a + 0x6d2b79f5) | 0;
    let t = Math.imul(a ^ (a >>> 15), 1 | a);
    t = (t + Math.imul(t ^ (t >>> 7), 61 | t)) ^ t;
    return ((t ^ (t >>> 14)) >>> 0) / 4294967296;
  };
}
const recorder = (seed) => {
  const g = mulberry32(seed);
  const log = [];
  return { log, f: () => { const x = g(); log.push(x); return x; } };
};
// a helper rng for choosing inputs (not recorded: the inputs are)
const chooser = (seed) => {
  const g = mulberry32(seed);
  return { r: g, int: (a, b) => a + Math.floor(g() * (b - a + 1)), pick: (list) => list[Math.floor(g() * list.length)], chance: (p) => g() < p };
};

const poolOf = (n) => Array.from({ length: n }, (_, i) => ({ id: String(i), uri: `u${i}` }));
// undefined / NaN as inputs
const enc = (v) => (v === undefined ? 'undefined' : Number.isNaN(v) ? 'NaN' : v);

// --- boards -----------------------------------------------------------------------
const normBoard = (b) => ({
  rows: b.rows,
  cols: b.cols,
  slots: b.slots,
  pieces: b.pieces.map((p) => ({ id: p.id, uri: p.uri === undefined ? null : p.uri, home: p.home === undefined ? null : p.home })),
  start: Object.entries(b.start).map(([s, k]) => [Number(s), k]),
  swaps: b.swaps.map(([x, y]) => [x === undefined ? null : x, y === undefined ? null : y]),
  after: Object.entries(b.after).map(([k, a]) => [Number(k), a.kind, a.i]),
  foodBefore: Object.entries(b.foodBefore).map(([s, k]) => [Number(s), k]),
  foodAfter: Object.entries(b.foodAfter).map(([s, k]) => [Number(s), k]),
  trayCap: b.trayCap,
});
const boardSpec = (s) => ({ rows: s.rows, cols: s.cols, count: s.count, foods: s.foods, decoys: s.decoys, swaps: s.swaps, mixed: s.mixed });

const boards = [];
let seed = 1;
const deal = (label, spec, poolSize, kinds) => {
  const { f, log } = recorder(seed++);
  const b = makeBoard(spec, poolOf(poolSize), f, kinds);
  boards.push({ label, spec: boardSpec(spec), poolSize, kinds, rand: log, board: normBoard(b) });
  return b;
};
for (let lv = 1; lv <= L.LEVELS; lv++)
  for (const skill of [-2, -1, 0, 1, 2])
    for (let n = 0; n < 3; n++) deal(`lv${lv} skill${skill} #${n}`, L.levelSpec(lv, skill), n === 2 ? 40 : 27, KINDS_DATA);
// the endless Blitz (develop, 2026-11-17): the climb, then the eight-shelf levels for good
const BLITZ_N = 22;
for (let i = 0; i < BLITZ_N; i++)
  for (const skill of [-2, -1, 0, 1, 2])
    for (let n = 0; n < 3; n++) deal(`blitz${i} skill${skill} #${n}`, L.blitzSpec(i, skill), 27, KINDS_DATA);
// odd specs: tiny shelves, small pools, few clutter kinds, more twists than room
{
  const c = chooser(777);
  for (let n = 0; n < 700; n++) {
    const rows = c.int(1, 8);
    const cols = c.int(1, 6);
    const slots = rows * cols;
    const spec = {
      rows,
      cols,
      count: c.int(0, slots + 2),
      foods: c.chance(0.2) ? 0 : c.int(0, slots + 1),
      decoys: c.chance(0.4) ? 0 : c.int(0, 4),
      swaps: c.chance(0.3) ? 0 : c.int(0, 5),
      mixed: c.chance(0.3) ? 0 : c.int(0, Math.min(slots, 9) + 1),
    };
    if (c.chance(0.1)) delete spec.foods;
    if (c.chance(0.1)) delete spec.decoys;
    deal(`fuzz #${n}`, spec, c.pick([0, 1, 2, 3, 5, 8, 12, 27, 40]), c.pick([1, 2, 3, 5, 16, 16]));
  }
  // one spot, one squishy, one mixed up: the 200 tries all fail, and the
  // "sure answer" leaves it on its own home
  for (let n = 0; n < 5; n++) deal(`1x1 mixed #${n}`, { rows: 1, cols: 1, count: 1, foods: 0, decoys: n % 2, swaps: n, mixed: 1 }, 27, 16);
}

// --- playing ----------------------------------------------------------------------
const normState = (s) => ({
  at: Object.keys(s.at).map((k) => [Number(k), s.at[k].kind, s.at[k].i]),
  locked: Object.keys(s.locked).map(Number),
  gone: Object.keys(s.gone).map(Number),
});
const plays = [];
const play = (label, board, steps, c) => {
  let st = startState(board);
  const n = board.pieces.length;
  const out = [];
  let after = 0;
  for (let step = 0; step < steps; step++) {
    let k;
    let t;
    const free = [...Array(n).keys()].filter((p) => !st.locked[p] && !st.gone[p]);
    const roll = c.r();
    if (roll < 0.35 && free.length) {
      k = c.pick(free);
      const h = board.pieces[k].home;
      t = { kind: 'slot', i: h == null ? c.int(0, board.slots - 1) : h };
    } else if (roll < 0.55) {
      k = c.int(0, n - 1);
      t = { kind: 'slot', i: c.int(-1, board.slots) };
    } else if (roll < 0.65) {
      k = c.int(0, n - 1);
      t = { kind: 'tray' };
    } else if (roll < 0.7) {
      k = c.int(0, n - 1);
      t = null;
    } else if (roll < 0.75) {
      k = c.pick([-1, n, n + 3]);
      t = { kind: 'slot', i: c.int(0, board.slots - 1) };
    } else if (roll < 0.87) {
      const food = Object.keys(board.foodAfter || {}).map(Number);
      k = c.int(0, n - 1);
      t = { kind: 'slot', i: food.length ? c.pick(food) : c.int(0, board.slots - 1) };
    } else {
      // on someone (a locked one, a mixed-up one)
      const taken = [...Array(board.slots).keys()].filter((i) => occupant(st, i) != null);
      k = c.int(0, n - 1);
      t = { kind: 'slot', i: taken.length ? c.pick(taken) : c.int(0, board.slots - 1) };
    }
    if (n === 0) k = c.pick([-1, 0, 1]);
    const r = drop(board, st, k, t);
    const occ = [];
    for (let i = -1; i <= board.slots; i++) occ.push(occupant(r.state, i));
    out.push({ k, t, o: r.outcome, b: r.bumped, same: r.state === st, st: normState(r.state), occ, sol: solved(board, r.state) });
    st = r.state;
    if (solved(board, st) && ++after > 4) break;
  }
  plays.push({ label, board: normBoard(board), start: normState(startState(board)), steps: out });
};
{
  const c = chooser(4242);
  // the hand-made board of board.test.js (no uris)
  const B = { rows: 2, cols: 2, slots: 4, trayCap: 3, start: {}, swaps: [], foodBefore: {}, foodAfter: { 1: 4 }, pieces: [{ id: 'a', home: 0 }, { id: 'b', home: 3 }, { id: 'c', home: null }], after: { 0: { kind: 'slot', i: 3 }, 1: { kind: 'tray', i: 0 }, 2: { kind: 'tray', i: 1 } } };
  for (let n = 0; n < 10; n++) play(`hand #${n}`, B, 30, c);
  let sd = 90001;
  for (let lv = 1; lv <= L.LEVELS; lv++)
    for (const skill of [-2, 0, 2])
      for (let n = 0; n < 2; n++) {
        const b = makeBoard(L.levelSpec(lv, skill), poolOf(27), mulberry32(sd++));
        play(`lv${lv} skill${skill} #${n}`, b, 120, c);
      }
  for (let n = 0; n < 120; n++) {
    const rows = c.int(1, 5);
    const cols = c.int(1, 5);
    const slots = rows * cols;
    const spec = { rows, cols, count: c.int(0, slots), foods: c.int(0, slots), decoys: c.int(0, 3), swaps: c.int(0, 3), mixed: c.int(0, 5) };
    const b = makeBoard(spec, poolOf(c.pick([0, 2, 5, 27])), mulberry32(sd++), 16);
    play(`fuzz #${n}`, b, 60, c);
  }
}

// --- levels -----------------------------------------------------------------------
const lvInputs = [...Array(L.LEVELS).keys()].map((i) => i + 1).concat([-3, -0.5, 0, 0.4, 1.99, 2.5, 49.9, 50.2, 51, 77, NaN, undefined]);
const skillInputs = [-3, -2, -1.5, -1, -0.999, -0.5, 0, 0.5, 1, 1.19, 1.2, 1.5, 2, 3, undefined];
const levelSpecs = [];
for (const lv of lvInputs) for (const skill of skillInputs) levelSpecs.push({ lv: enc(lv), skill: enc(skill), out: skill === undefined ? L.levelSpec(lv) : L.levelSpec(lv, skill) });
const blitzSpecs = [];
for (let i = -2; i <= 40; i++) for (const skill of skillInputs) blitzSpecs.push({ i, skill: enc(skill), out: skill === undefined ? L.blitzSpec(i) : L.blitzSpec(i, skill) });
const blitzCoins = [];
for (let i = 0; i < BLITZ_N; i++) for (const skill of [-2, 0, 1.3, 2]) blitzCoins.push({ i, skill, out: L.blitzCoins(L.blitzSpec(i, skill)) });
const skillShifts = [-5, -2, -1.0001, -1, -0.9999, 0, 1, 1.1999, 1.2, 1.2001, 2, 9].map((s) => ({ skill: s, out: L.skillShift(s) }));
const nextSkills = [];
for (const skill of [-2.5, -2, -1.37, -0.5, 0, 0.33, 0.07, 1, 1.9, 2, 2.4, undefined])
  for (const won of [true, false])
    for (const stars of [0, 1, 2, 3, undefined])
      for (const mistakes of [0, 1, 2, 3, 4, -1, 0.5, undefined]) {
        const arg = { won };
        if (stars !== undefined) arg.stars = stars;
        if (mistakes !== undefined) arg.mistakes = mistakes;
        nextSkills.push({ skill: enc(skill), won, stars: enc(stars), mistakes: enc(mistakes), out: L.nextSkill(skill, arg) });
      }
// specs to score: every level at three skills, and the blitz rounds
const scoreSpecs = [];
for (let lv = 1; lv <= L.LEVELS; lv++) for (const skill of [-2, 0, 2]) scoreSpecs.push({ kind: 'level', lv, skill });
for (let i = 0; i < BLITZ_N; i++) for (const skill of [-2, 0, 2]) scoreSpecs.push({ kind: 'blitz', i, skill });
const specOf = (s) => (s.kind === 'blitz' ? L.blitzSpec(s.i, s.skill) : L.levelSpec(s.lv, s.skill));
const starsFor = [];
const coins = [];
const xps = [];
for (const s of scoreSpecs) {
  const spec = specOf(s);
  for (const mistakes of [undefined, 0, 1, 2, 3, NaN])
    for (const ms of [undefined, 0, spec.parMs - 1, spec.parMs, spec.parMs + 1, 1e6, NaN]) {
      const res = {};
      if (mistakes !== undefined) res.mistakes = mistakes;
      if (ms !== undefined) res.ms = ms;
      starsFor.push({ spec: s, mistakes: enc(mistakes), ms: enc(ms), out: L.starsFor(spec, res) });
    }
  for (const stars of [0, 1, 2, 3]) coins.push({ spec: s, stars, out: L.coinsFor(spec, stars) });
  for (const stars of [0, 1, 1.5, 2, 2.5, 3, 4]) xps.push({ spec: s, stars, out: L.xpFor(spec, stars) });
}
const clocks = [-5000, -1, 0, 1, 999, 1000, 1001, 42000, 59999, 60000, 61500, 299999, 300000, 599001, 3600000, 1e9, 0.5, 12345.678].map((ms) => ({ ms, out: L.clock(ms) }));
const models = [];
for (const theme of ['fridge', 'cupboard', 'other'])
  for (const i of [-3, -0.5, 0, 0.9, 1, 2, 3, 4, 5, 6, 6.7, 7, 99, 4294967297, NaN]) {
    const m = M.modelOf(theme, i);
    models.push({ theme, i: enc(i), out: { kind: m.kind, key: m.key, name: m.name, size: m.size, index: m.index } });
  }

// --- the profile ------------------------------------------------------------------
const c = chooser(31337);
const maybe = (p, f) => (c.chance(p) ? f() : undefined);
const put = (o, k, v) => {
  if (v !== undefined) o[k] = v;
};
const genTheme = () => {
  if (c.chance(0.1)) return null;
  const t = {};
  put(t, 'lv', maybe(0.85, () => c.pick([null, 0, 1, 2, 3, 5, 10, 25, 49, 50, 51, 3.5, c.int(1, 50), c.int(1, 50)])));
  put(t, 'best', maybe(0.7, () => {
    if (c.chance(0.08)) return null;
    const b = {};
    const n = c.int(0, 12);
    for (let j = 0; j < n; j++) b[c.pick([c.int(1, 50), c.int(1, 50), 50, 1, 3])] = c.pick([1, 2, 3, 3, 0, null]);
    return b;
  }));
  put(t, 'skill', maybe(0.6, () => c.pick([null, 0, -2, 2, -0.5, 1.2, 0.73, -1.37, c.r() * 4 - 2])));
  return t;
};
const genProfile = () => {
  const p = {};
  put(p, 'pxp', maybe(0.6, () => c.pick([0, 99, 100, 199, 200, 299.5, -10, 150, 5000, 123456, c.int(0, 20000), c.int(0, 3000)])));
  put(p, 'level', maybe(0.3, () => c.pick([null, 0, 1, 2, 7, 2.7, 30])));
  put(p, 'sdk', maybe(0.2, () => c.pick([null, {}, { xp: c.int(0, 900) }, { xp: null }, { xp: -40 }, { xp: 12.9 }])));
  put(p, 'sort', maybe(0.85, () => {
    if (c.chance(0.06)) return null;
    const s = {};
    put(s, 'fridge', maybe(0.75, genTheme));
    put(s, 'cupboard', maybe(0.6, genTheme));
    put(s, 'plays', maybe(0.6, () => c.pick([null, 0, 1, c.int(2, 300)])));
    put(s, 'wins', maybe(0.6, () => c.pick([null, 0, 1, c.int(2, 200)])));
    put(s, 'seen', maybe(0.5, () => c.pick([true, false, null, 0, 1])));
    put(s, 'bSkill', maybe(0.4, () => c.pick([null, 0, -2, 2, 0.4, -0.3, 1.7, c.r() * 4 - 2])));
    put(s, 'blitz', maybe(0.5, () => {
      if (c.chance(0.08)) return null;
      const b = {};
      put(b, 'top', maybe(0.7, () => c.pick([null, 0, 1, 4, 5, 9, 10, 17])));
      put(b, 'runs', maybe(0.5, () => c.pick([null, 0, 1, 3, 12])));
      put(b, 'reached', maybe(0.4, () => c.pick([null, 0, 1, 5, 6, 9, 10])));
      put(b, 'bestMs', maybe(0.6, () => c.pick([null, 0, 150000, 200000, 299999, c.int(60000, 300000)])));
      put(b, 'wins', maybe(0.6, () => c.pick([null, 0, 1, c.int(2, 40)])));
      return b;
    }));
    return s;
  }));
  return p;
};
const profiles = [{}, { sort: {} }, { sort: null }, { pxp: 0 }, { pxp: 150 }, { sort: { fridge: { lv: 3, best: { 1: 3 } } } }, { sort: { fridge: { lv: 50 } } }, { sort: { blitz: { reached: 10, bestMs: 0, wins: 0 } } }, { sort: { blitz: { top: 12, runs: 4 } } }];
for (let n = 0; n < 400; n++) profiles.push(genProfile());

const records = profiles.map((p) => {
  const rec = L.record(p);
  return { profile: p, out: rec, starsIn: L.THEME_KEYS.map((t) => L.starsIn(rec, t)), doneIn: L.THEME_KEYS.map((t) => L.doneIn(rec, t)) };
});

const configs = [
  null,
  { xpPerLevel: 150, xp: { replay: 0.3, games: 1.5, blitz: { sort: 250 } } },
  { xpPerLevel: -5, xp: { replay: 2, games: 0, blitz: 'x' } },
  { xpPerLevel: 37.5, xp: { replay: 0, games: 0.7, blitz: { squishdoku: 9 } } },
  { xp: [] },
];
const afterLevels = [];
const afterBlitzes = [];
const prizes = [];
configs.forEach((cfg, ci) => {
  setLevelsConfig(cfg);
  const per = ci === 0 ? profiles.length : 80;
  for (let n = 0; n < per; n++) {
    const p = profiles[n];
    const rec = L.record(p);
    for (let j = 0; j < (ci === 0 ? 4 : 2); j++) {
      const theme = c.pick(L.THEME_KEYS);
      const roll = c.r();
      const s = roll < 0.5 ? { kind: 'level', lv: Math.floor(rec[theme].lv), skill: rec[theme].skill } : roll < 0.85 ? { kind: 'level', lv: c.int(1, 50), skill: c.pick([-2, 0, 0.5, 2]) } : { kind: 'blitz', i: c.int(0, 9), skill: c.pick([-2, 0, 2]) };
      const spec = specOf(s);
      const result = { won: c.chance(0.75) };
      put(result, 'mistakes', maybe(0.9, () => c.pick([0, 0, 1, 2, 3, 5])));
      put(result, 'ms', maybe(0.85, () => c.pick([1, 1000, spec.parMs, spec.parMs + 1, c.int(1000, 90000)])));
      afterLevels.push({ config: ci, profile: n, theme, spec: s, result: { won: result.won, mistakes: enc(result.mistakes), ms: enc(result.ms) }, out: L.afterLevel(p, theme, spec, result) });
    }
    for (let j = 0; j < (ci === 0 ? 3 : 1); j++) {
      const cleared = c.pick([0, 0, 1, 3, 4, 5, 9, 10, 11, 16, 25]);
      afterBlitzes.push({ config: ci, profile: n, cleared, out: L.afterBlitz(p, { cleared }) });
    }
    if (n < 40) for (const cleared of [0, 1, 5, 10, 13, 14, 30]) prizes.push({ config: ci, cleared, skill: rec.bSkill, out: L.blitzPrize(cleared, rec.bSkill) });
  }
});
setLevelsConfig(null);

const constants = {
  LEVELS: L.LEVELS,
  LEVEL_LIST: L.LEVEL_LIST,
  MODEL_STARTS: L.MODEL_STARTS,
  TIER_NAMES: L.TIER_NAMES,
  TIER_COLORS: L.TIER_COLORS,
  HEARTS: L.HEARTS,
  SKILL_MIN: L.SKILL_MIN,
  SKILL_MAX: L.SKILL_MAX,
  THEME_KEYS: L.THEME_KEYS,
  KINDS: KINDS_DATA,
  SIZE_NAMES: M.SIZE_NAMES,
  MODEL_COUNT: M.MODEL_COUNT,
};

const write = (name, data) => fs.writeFileSync(path.join(outDir, name), JSON.stringify(data));
write('boards.json', boards);
write('plays.json', plays);
write('levels.json', { constants, levelSpecs, blitzSpecs, blitzCoins, skillShifts, nextSkills, starsFor, coins, xps, clocks, models });
write('profiles.json', { configs, profiles, records, afterLevels, afterBlitzes, prizes });
const steps = plays.reduce((a, p) => a + p.steps.length, 0);
console.log(
  `sort fixtures: ${boards.length} boards, ${plays.length} plays (${steps} drops), ${levelSpecs.length} levelSpecs, ${blitzSpecs.length} blitzSpecs, ${nextSkills.length} nextSkills, ${starsFor.length} starsFor, ${coins.length} coinsFor, ${xps.length} xpFor, ${clocks.length} clocks, ${records.length} records, ${afterLevels.length} afterLevels, ${afterBlitzes.length} afterBlitzes -> ${path.relative(process.cwd(), outDir)}`,
);
