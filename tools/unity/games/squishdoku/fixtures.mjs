// Squishdoku's differential test, JS side: runs src/squishdoku/engine.js and levels.js on many inputs and writes the
// inputs with the JS outputs to out/fixtures.json, which the .NET project here (SquishdokuParity) replays against
// the Unity C# port (unity/Assets/Scripts/Games/Squishdoku).
//   node tools/unity/games/squishdoku/fixtures.mjs && dotnet run -c Release --project tools/unity/games/squishdoku
// Non-finite numbers in inputs are written as the strings "NaN", "Infinity" and "-Infinity".
import { mkdirSync, writeFileSync } from 'node:fs';
import { dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import * as E from '../../../../src/squishdoku/engine.js';
import * as L from '../../../../src/squishdoku/levels.js';
import { setLevelsConfig, levelsConfig, xpRules, playerLevel, addXp } from '../../../../src/playerXp.js';

const here = dirname(fileURLToPath(import.meta.url));
const num = (x) => (Number.isFinite(x) ? x : String(x));
const F = {};
const t0 = Date.now();

// the fixtures' own random inputs (any generator would do: the inputs are written down)
const fr = E.rng(20261123);
const ri = (a, b) => a + Math.floor(fr() * (b - a + 1));
const pickOf = (xs) => xs[Math.floor(fr() * xs.length)];

// --- rng -------------------------------------------------------------------------------
{
  const seeds = [0, 1, 2, 3, 42, 1000, -1, -2, -123456, 2147483647, 2147483648, 4294967295, 4294967296, 4294967301, 123456789, 2 ** 40 + 7, -(2 ** 40) - 9, 2 ** 53 - 1];
  for (let i = 0; i < 40; i++) seeds.push(ri(0, 2 ** 31 - 1));
  F.rng = seeds.map((seed) => {
    const r = E.rng(seed);
    return { seed, out: Array.from({ length: 64 }, () => r()) };
  });
}

// --- the maker's parts, one seed at a time ----------------------------------------------
// r = rng(seed): randomSolution → growRegions → makeUnique (same r), then the next r() (the stream's position);
// makeUnique again with maxMoves 1 and 2 on fresh streams; countSolutions and grade of the raw and mended boards.
{
  F.pipeline = [];
  const perN = { 0: 3, 1: 3, 2: 5, 3: 5, 4: 80, 5: 80, 6: 70, 7: 60, 8: 45, 9: 40 };
  for (let n = 0; n <= 9; n++) {
    for (let k = 0; k < perN[n]; k++) {
      const seed = k < 10 ? k + 1 : ri(0, 2 ** 31 - 1);
      const r = E.rng(seed);
      const sol = E.randomSolution(n, r);
      const c = { n, seed, sol };
      if (sol) {
        const regions = E.growRegions(n, sol, r);
        const unique = E.makeUnique(n, regions, sol, r);
        c.regions = regions;
        c.unique = unique;
        c.next = r();
        c.unique1 = E.makeUnique(n, regions, sol, E.rng(seed + 7), 1);
        c.unique2 = E.makeUnique(n, regions, sol, E.rng(seed + 8), 2);
        c.count = E.countSolutions(n, regions);
        c.count1 = E.countSolutions(n, regions, 1);
        c.count50 = E.countSolutions(n, regions, 50);
        c.grade = E.grade(n, regions);
        if (unique) {
          c.uniqueCount = E.countSolutions(n, unique);
          c.uniqueGrade = E.grade(n, unique);
        }
      } else c.next = r();
      F.pipeline.push(c);
    }
  }
}

// --- grade and countSolutions on fixed boards: all 600 levels, plus odd ones ---------------
{
  F.boards = [];
  for (let lv = 1; lv <= L.LEVELS; lv++) {
    const { n, puzzle } = L.levelSpec(lv);
    F.boards.push({ n, regions: puzzle.regions });
  }
  F.boards.push({ n: 4, regions: [0, 0, 1, 1, 0, 2, 2, 1, 3, 2, 2, 1, 3, 3, 3, 3] }); // engine.test.js's hand-made one
  for (let n = 1; n <= 9; n++) F.boards.push({ n, regions: new Array(n * n).fill(0) }); // one patch: stuck
  for (let n = 1; n <= 9; n++) F.boards.push({ n, regions: Array.from({ length: n * n }, (_, i) => i % n) }); // columns
  for (let n = 1; n <= 9; n++) F.boards.push({ n, regions: Array.from({ length: n * n }, (_, i) => Math.floor(i / n)) }); // rows
  for (let i = 0; i < 60; i++) {
    const n = ri(4, 9);
    F.boards.push({ n, regions: Array.from({ length: n * n }, () => ri(0, n - 1)) }); // scattered patches
  }
  for (const b of F.boards) {
    b.grade = E.grade(b.n, b.regions);
    b.count = E.countSolutions(b.n, b.regions);
    b.count5 = E.countSolutions(b.n, b.regions, 5);
  }
}

// --- conflicts -------------------------------------------------------------------------
{
  F.conflicts = [];
  for (let i = 0; i < 600; i++) {
    const lv = ri(1, L.LEVELS);
    const { n, puzzle } = L.levelSpec(lv);
    const m = ri(0, n + 2);
    let cells;
    if (i % 5 === 0) cells = puzzle.solution.map((c, r) => r * n + c).slice(0, m);
    else cells = Array.from({ length: m }, () => ri(0, n * n - 1));
    F.conflicts.push({ n, regions: puzzle.regions, cells, out: [...E.conflicts(n, puzzle.regions, cells)] });
  }
  const regions = new Array(16).fill(0).map((_, i) => i % 4);
  for (const cells of [[0, 2], [0, 5], [1, 7], [], [3], [3, 3], [0, 6, 9, 15]]) F.conflicts.push({ n: 4, regions, cells, out: [...E.conflicts(4, regions, cells)] });
}

// --- puzzleMaker / makePuzzle ----------------------------------------------------------
{
  F.makePuzzle = [];
  for (let n = 4; n <= 9; n++) {
    for (let tier = 0; tier <= 3; tier++) {
      const count = n <= 7 ? 14 : 10;
      for (let k = 0; k < count; k++) {
        const seed = k < 4 ? 1000 * n + 100 * tier + k : ri(0, 2 ** 31 - 1);
        const maxTries = k === 4 ? 1 : k === 5 ? 3 : k === 6 ? 25 : undefined;
        const opts = { n, tier, seed };
        if (maxTries !== undefined) opts.maxTries = maxTries;
        const m = E.puzzleMaker(opts);
        let p = null;
        let calls = 0;
        while (!(p = m.run(k % 2 ? 0 : 50))) calls++;
        // a finished maker hands back the same board
        const again = m.run(5) === p;
        F.makePuzzle.push({ n, tier, seed, maxTries: maxTries ?? null, tries: m.tries, again, out: p, viaMake: E.makePuzzle(opts) });
      }
    }
  }
  F.tierOf = Array.from({ length: 30 }, (_, e) => ({ e: e - 2, out: E.tierOf(e - 2) }));
}

// --- levels: constants, every level's spec, chapters, stages --------------------------------
F.constants = {
  TIERS: E.TIERS,
  LEVELS: L.LEVELS,
  CHAPTER: L.CHAPTER,
  CHAPTERS: L.CHAPTERS,
  LEVEL_LIST: L.LEVEL_LIST,
  HEAD_START: L.HEAD_START,
  HEARTS: L.HEARTS,
  HEARTS_FROM: L.HEARTS_FROM,
  SKILL_MIN: L.SKILL_MIN,
  SKILL_MAX: L.SKILL_MAX,
  PERFECT_MULT: L.PERFECT_MULT,
  BLITZ_SECS: L.BLITZ_SECS,
  BLITZ_COINS: L.BLITZ_COINS,
};
{
  F.levelSpec = [];
  const lvs = [];
  for (let lv = 1; lv <= L.LEVELS; lv++) lvs.push(lv);
  lvs.push(0, -0, -3, 601, 1000, 2.5, 599.9, 45.99, 0.5, -0.5, NaN, Infinity, -Infinity, 1e15);
  for (const lv of lvs) for (const head of [false, true]) F.levelSpec.push({ lv: num(lv), head, out: L.levelSpec(lv, head) });
  const xs = [-5, -1, 0, 0.5, 1, 1.5, 19, 19.99, 20, 20.01, 21, 39.5, 40, 41, 599, 600, 601, 700, 1e9];
  for (let lv = 1; lv <= 600; lv += 7) xs.push(lv);
  F.chapterOf = xs.map((lv) => ({ lv, out: L.chapterOf(lv) }));
  F.stageOf = xs.concat(Array.from({ length: 600 }, (_, i) => i + 1)).map((lv) => ({ lv, out: L.stageOf(lv) }));
  F.roomOfChapter = Array.from({ length: 40 }, (_, i) => ({ c: i + 1, out: L.roomOfChapter(i + 1) }));
  F.tierOfEffort = Array.from({ length: 50 }, (_, e) => ({ e: e - 2, out: L.tierOfEffort(e - 2) }));
}

// --- scoring ---------------------------------------------------------------------------
{
  F.stars = [];
  const lvs = [1, 2, 4, 5, 22, 23, 45, 46, 80, 130, 131, 300, 450, 599, 600];
  for (let i = 0; i < 25; i++) lvs.push(ri(1, 600));
  for (const lv of lvs) {
    for (const head of [false, true]) {
      const spec = L.levelSpec(lv, head);
      const mss = [0, 1, spec.aMs - 1, spec.aMs, spec.aMs + 0.5, spec.aMs + 1, spec.bMs - 1, spec.bMs, spec.bMs + 1, spec.limitMs, spec.limitMs * 3, -10];
      for (const ms of mss) {
        for (const mistakes of [0, 1, 2]) {
          for (const usedX of [false, true]) {
            F.stars.push({ lv, head, ms, mistakes, usedX, starsFor: L.starsFor(spec, { ms, mistakes, usedX }), starsLeft: L.starsLeft(spec, ms, mistakes) });
          }
        }
      }
    }
  }
  F.rewards = [];
  for (let lv = 1; lv <= L.LEVELS; lv++) {
    for (const head of [false, true]) {
      const spec = L.levelSpec(lv, head);
      const coins = [];
      const xp = [];
      for (const perfect of [false, true]) for (let stars = 0; stars <= 3; stars++) {
        coins.push(L.coinsFor(spec, { stars, perfect }));
        xp.push(L.xpFor(spec, { stars, perfect }));
      }
      F.rewards.push({ lv, head, coins, xp }); // order: perfect false/true × stars 0-3
    }
  }
  F.skillShift = [];
  for (let s = -30; s <= 30; s++) F.skillShift.push({ skill: s / 10, out: L.skillShift(s / 10) });
  for (const s of [-1.0000001, -0.9999999, 1.1999999, 1.2000001, NaN, Infinity, -Infinity]) F.skillShift.push({ skill: num(s), out: L.skillShift(s) });
}

// --- Blitz -----------------------------------------------------------------------------
{
  const skills = [-2, -1.5, -1, -0.99, -0.3, 0, 0.4, 1, 1.19, 1.2, 1.6, 2];
  F.blitzSpec = [];
  for (let i = 0; i <= 120; i++) for (const skill of skills) F.blitzSpec.push({ i, skill, out: L.blitzSpec(i, skill) });
  F.blitzSpec.push({ i: 500, skill: 0, out: L.blitzSpec(500) }, { i: 100000, skill: 0, out: L.blitzSpec(100000) });
  F.blitzSaveGems = [0, 1, 2, 3, 4, 5, 6, 9, 100, -1, -0.5, 2.7, 4.999, '3', '2.9', ' 4 ', '', 'abc', '1e1', '0x2', null, true, false, '-1', 'Infinity', '3px'].map((i) => ({ i, out: L.blitzSaveGems(i) }));
  F.blitzSaveGemsNum = [NaN, Infinity, -Infinity].map((i) => ({ i: num(i), out: L.blitzSaveGems(i) }));
}

// --- the profile: record / afterLevel / afterBlitz, under two XP configs -------------------
const CONFIGS = [null, { xpPerLevel: 150, xp: { games: 1.25, replay: 0.3, blitz: { squishdoku: 333 } } }, { xpPerLevel: 77.5, xp: { games: 0.8, replay: 1, blitz: { squishdoku: 55 } } }];
const profileOf = () => {
  const roll = fr();
  if (roll < 0.03) return null;
  if (roll < 0.06) return {};
  const p = {};
  const pick = fr();
  if (pick < 0.7) p.pxp = pickOf([0, 1, 50, 99, 100, 199, 200, 499, 500, 1234, 12345, 99999, 3.7, -5, 1e7, ri(0, 40000)]);
  else if (pick < 0.9) p.level = pickOf([1, 2, 5, 12, 0, -2, 3.5, null]);
  if (fr() < 0.9) {
    const s = {};
    const f = (k, v) => {
      if (fr() < 0.75) s[k] = v;
    };
    f('lv', pickOf([1, 2, 3, 12, 37, 45, 46, 47, 100, 599, 600, 9999, 0, -3, 2.5, null, ri(1, 600)]));
    if (fr() < 0.7) {
      const best = {};
      const perfect = {};
      for (let j = ri(0, 12); j > 0; j--) {
        const lv = pickOf([1, 2, 3, 12, 37, 46, 599, 600, ri(1, 600)]);
        best[lv] = pickOf([1, 2, 3, 3, 0, 2]);
        if (fr() < 0.4) perfect[lv] = pickOf([true, true, false]);
      }
      s.best = best;
      if (fr() < 0.8) s.perfect = perfect;
    }
    f('skill', pickOf([0, 0.5, -1.2, 2]));
    f('bSkill', pickOf([0, 0.4, -0.3, 1.6, 1.95, -1.99, 2, -2, 0.005, -0.005, 0.015, 1.2, 1.19, -1, 0.1 + 0.2, null]));
    if (fr() < 0.7) {
      const b = {};
      if (fr() < 0.8) b.top = pickOf([0, 1, 3, 7, 9, 10, 25, null, -1]);
      if (fr() < 0.7) b.runs = pickOf([0, 1, 4, 100, null]);
      if (fr() < 0.3) b.reached = ri(0, 10);
      if (fr() < 0.2) b.extra = 'kept';
      s.blitz = b;
    }
    f('plays', pickOf([0, 1, 5, 120, null]));
    f('solves', pickOf([0, 1, 4, 99]));
    f('head', pickOf([true, false, 1, 0, null]));
    if (fr() < 0.2) s.xp = pickOf([0, 40, 250, 1000.7]);
    p.sdk = s;
  }
  return p;
};
{
  F.profiles = { configs: [], list: [], record: [], afterLevel: [], afterBlitz: [], playerLevel: [] };
  // profiles are written once (`list`) and named by index (`p`)
  const keep = (profile) => F.profiles.list.push(profile) - 1;
  const clearedList = [0, 1, 2, 4, 5, 6, 9, 10, 11, 14, 15, 20, 21, 25, 40, 60];
  CONFIGS.forEach((cfg, ci) => {
    setLevelsConfig(cfg);
    const lc = levelsConfig();
    const rules = xpRules();
    F.profiles.configs.push({ xpPerLevel: lc.xpPerLevel, games: rules.games, replay: rules.replay, blitzSquishdoku: rules.blitz.squishdoku });
    for (let x = 0; x <= 6000; x += 13) F.profiles.playerLevel.push({ config: ci, pxp: x, out: playerLevel(x) });
    for (const x of [-10, 0.5, 99.99, 100, 1e6, 123456789, 1e12, NaN, Infinity]) F.profiles.playerLevel.push({ config: ci, pxp: num(x), out: playerLevel(x) });
    const count = ci === 0 ? 700 : 250;
    for (let i = 0; i < count; i++) {
      const profile = profileOf();
      const pi = keep(profile);
      F.profiles.record.push({ config: ci, p: pi, out: L.record(profile) });
      const rec = L.record(profile);
      const lvs = [rec.lv, rec.lv, 1, 46, 600, ri(1, 600)];
      const bestKeys = Object.keys(rec.best);
      if (bestKeys.length) lvs.push(Number(pickOf(bestKeys)));
      for (const lv of lvs) {
        const head = fr() < 0.3;
        const results = [{ solved: false }, { solved: true, stars: 3, perfect: true }, { solved: true, stars: 3, perfect: false }, { solved: true, stars: 2, perfect: false }, { solved: true, stars: 1, perfect: false }];
        if (fr() < 0.2) results.push({ solved: true, stars: 1, perfect: true }, { solved: true, stars: 0, perfect: false });
        for (const result of results) {
          F.profiles.afterLevel.push({ config: ci, p: pi, lv, head, result, out: L.afterLevel(profile, L.levelSpec(lv, head), result) });
        }
      }
      for (const cleared of clearedList) {
        if (fr() < 0.5) F.profiles.afterBlitz.push({ config: ci, p: pi, cleared, out: L.afterBlitz(profile, { cleared }) });
      }
    }
    // blitzPrize and addXp under this config too
    F.profiles.blitzPrize = F.profiles.blitzPrize || [];
    for (let c = 0; c <= 60; c++) for (const skill of [-2, -1, 0, 1.2, 2]) F.profiles.blitzPrize.push({ config: ci, cleared: c, skill, out: L.blitzPrize(c, skill) });
    F.profiles.addXp = F.profiles.addXp || [];
    for (let i = 0; i < 150; i++) {
      const profile = profileOf();
      const pi = keep(profile);
      const n = pickOf([0, 1, 10, 49.5, 50.5, 99, 250, 1000, -5, 3.3, ri(0, 5000)]);
      F.profiles.addXp.push({ config: ci, p: pi, n, out: addXp(profile, n) });
    }
  });
  setLevelsConfig(null);
}

// --- clock -----------------------------------------------------------------------------
{
  const ms = [0, 1, 999, 1000, 1001, 9000, 9001, 59999, 60000, 60001, 65000, 599999, 3599999, 3600000, 86400000, -5, -1000, -1, 0.5, 1.5, 1e9, 1e12, 1e15, 9007199254740993, 1e20, 1e23, 1e25, 1e300, -1e300, NaN, Infinity, -Infinity];
  for (let i = 0; i < 300; i++) ms.push(ri(0, 1200000));
  for (let i = 0; i < 50; i++) ms.push(fr() * 100000);
  F.clock = ms.map((m) => ({ ms: num(m), out: L.clock(m) }));
}

mkdirSync(resolve(here, 'out'), { recursive: true });
const file = resolve(here, 'out/fixtures.json');
writeFileSync(file, JSON.stringify(F));
const counts = Object.entries(F)
  .map(([k, v]) => (Array.isArray(v) ? `${k} ${v.length}` : k === 'profiles' ? Object.entries(v).map(([a, b]) => `${a} ${b.length}`).join(', ') : k))
  .join(', ');
console.log(`wrote ${file} in ${Date.now() - t0} ms: ${counts}`);
