// Squish Hop's differential test, the JS half: runs src/hop/{engine,levels,board}.js (and the playerXp.js parts that
// levels.js uses) on a fixed set of inputs and writes inputs + outputs to tools/unity/games/hop/fixtures/*.json. The
// hop-test console project replays the same inputs through the C# port (unity/Assets/Scripts/Games/Hop) and compares.
//
//   node tools/unity/games/hop/fixtures.mjs && dotnet run -c Release --project tools/unity/games/hop/hop-test.csproj
//
// Everything is deterministic: the random walks, maps and search shuffles come from mulberry32 seeds (ported to C#
// too, so a search's `rand` is replayed from its seed). Non-finite numbers are written as { "$num": "NaN" } etc.
import fs from 'node:fs';
import path from 'node:path';
import { fileURLToPath } from 'node:url';
import { performance } from 'node:perf_hooks';
import { DIRS, DCH, ARROWS, BEATS, parse, leftOf, newState, blockOf, tryMove, moves, search, replay, starsFor as engStars, parityOk } from '../../../../src/hop/engine.js';
import LEVEL_DATA from '../../../../src/hop/levelData.js';
import * as L from '../../../../src/hop/levels.js';
import * as BG from '../../../../src/hop/board.js';
import * as BZ from '../../../../src/hop/blitz.js';
import { setLevelsConfig } from '../../../../src/playerXp.js';

const HERE = path.dirname(fileURLToPath(import.meta.url));
const OUT = path.join(HERE, 'fixtures');
fs.mkdirSync(OUT, { recursive: true });

function mulberry32(a) {
  return function () {
    a |= 0;
    a = (a + 0x6d2b79f5) | 0;
    let t = Math.imul(a ^ (a >>> 15), 1 | a);
    t = (t + Math.imul(t ^ (t >>> 7), 61 | t)) ^ t;
    return ((t ^ (t >>> 14)) >>> 0) / 4294967296;
  };
}
const pick = (r, a) => a[Math.floor(r() * a.length)];

const replacer = (k, v) => (typeof v === 'number' && !Number.isFinite(v) ? { $num: String(v) } : v);
const counts = {};
function write(name, data, n) {
  const file = path.join(OUT, name + '.json');
  fs.writeFileSync(file, JSON.stringify(data, replacer));
  counts[name] = n;
  console.log(`${name}.json: ${n} cases, ${(fs.statSync(file).size / 1e6).toFixed(1)} MB`);
}
const st0 = (s) => ({ cur: s.cur, life: s.life.slice(), got: s.got, hops: s.hops, done: s.done });
const lvOut = (lv) => ({ ...lv }); // parse()'s object as is

// ---- maps: the 100 levels, random boards, and edge cases ------------------------------------------------------------
const levelMaps = LEVEL_DATA.map((d) => d.map);
const ALPHA = '..........##DFF123^>v<oabc';
const ODD = [' ', 'x', '0', '9', 'é', 'S', 'G', '~'];
function randomMap(r) {
  const w = 1 + Math.floor(r() * 7);
  const h = 1 + Math.floor(r() * 7);
  const g = [];
  for (let y = 0; y < h; y++) {
    const row = [];
    for (let x = 0; x < w; x++) row.push(r() < 0.03 ? pick(r, ODD) : pick(r, ALPHA));
    g.push(row);
  }
  const put = (ch) => {
    g[Math.floor(r() * h)][Math.floor(r() * w)] = ch;
  };
  if (r() < 0.95) put('S');
  if (r() < 0.95) put('G');
  let rows = g.map((row) => row.join(''));
  if (r() < 0.2) rows = rows.map((s) => (r() < 0.3 ? s.slice(0, Math.floor(r() * s.length)) : s)); // ragged
  return rows;
}
const rmr = mulberry32(12345);
const randomMaps = [];
for (let i = 0; i < 400; i++) randomMaps.push(randomMap(rmr));
const friendsRow = (k) => {
  // k friends on a board with S at the top-left and G at the bottom-right
  const w = 6;
  const cells = ['S', ...Array(k).fill('F')];
  while ((cells.length + 1) % w) cells.push('.');
  cells.push('G');
  const rows = [];
  for (let i = 0; i < cells.length; i += w) rows.push(cells.slice(i, i + w).join(''));
  return rows;
};
const edgeMaps = [
  [], [''], ['', ''], ['S'], ['G'], ['SG'], ['GS'], ['S#G'], ['S', '', 'G'], ['S.', '.G.', ''], ['SS.G'], ['SGG'],
  ['S1', '2G'], ['S21G'], ['S3.', '1.2', '..G'], ['S9F1', '.5.G'], ['SDDG'], ['S^G'], ['S.o.G'], ['Sabc', 'cbaG'],
  ['S éx0', '~..G'], ['#S#', '#.#', '#G#'], friendsRow(30), friendsRow(31), friendsRow(32), friendsRow(33),
  ['S' + 'F'.repeat(31) + 'G'], ['S123456789G'], ['S98765G'], ['SFFFFF1234G'],
];
const allMaps = [
  ...levelMaps.map((m, i) => ({ name: `level ${i + 1}`, rows: m })),
  ...randomMaps.map((m, i) => ({ name: `random ${i}`, rows: m })),
  ...edgeMaps.map((m, i) => ({ name: `edge ${i}`, rows: m })),
];

// ---- parse / newState / leftOf / parityOk ---------------------------------------------------------------------------
const parsed = [];
{
  const cases = allMaps.map(({ name, rows }) => {
    try {
      const lv = parse(rows);
      parsed.push({ name, rows, lv });
      return { name, rows, out: { lv: lvOut(lv), newState: newState(lv), leftOf: leftOf(lv, lv.life), parityOk: parityOk(lv) } };
    } catch (e) {
      return { name, rows, error: String(e.message) };
    }
  });
  write('parse', { consts: { DIRS, DCH, ARROWS, BEATS }, cases }, cases.length);
}

// ---- tryMove walks, moves, blockOf, leftOf, replay -----------------------------------------------------------------
function walk(lv, r, solution) {
  let st = newState(lv);
  const steps = [];
  const chosen = [];
  let fails = 0;
  for (let k = 0; k < 90; k++) {
    const ms = moves(lv, st);
    const blocks = [0, 1, 2, 3].map((d) => blockOf(lv, st.life, st.got, st.hops, lv.nb[st.cur][d]));
    // a few other cells too, every branch of blockOf
    const probe = [-1, Math.floor(r() * lv.life.length), lv.goal, lv.start];
    const probes = probe.map((j) => blockOf(lv, st.life, st.got, st.hops, j));
    let d;
    if (solution) {
      if (k >= solution.length) break;
      d = solution[k];
    } else if (ms.length && r() < 0.75) d = pick(r, ms).d;
    else d = Math.floor(r() * 4);
    const res = tryMove(lv, st, d);
    steps.push({ st: st0(st), d, res, moves: ms, blocks, probe, probes, left: leftOf(lv, st.life) });
    chosen.push(d);
    if (res.ok) st = res.st;
    if (st.done) {
      // one more try once done
      steps.push({ st: st0(st), d: 0, res: tryMove(lv, st, 0), moves: moves(lv, st), blocks: [], probe: [], probes: [], left: leftOf(lv, st.life) });
      chosen.push(0);
      break;
    }
    if (!ms.length && ++fails > 2) break;
  }
  const valid = steps.filter((s) => s.res.ok).map((s) => s.d);
  const half = Math.floor(valid.length / 2);
  const mid = replay(lv, valid.slice(0, half)).st;
  const replays = [
    { dirs: chosen, st0: null, out: replay(lv, chosen) },
    { dirs: valid, st0: null, out: replay(lv, valid) },
    { dirs: valid.slice(half), st0: st0(mid), out: replay(lv, valid.slice(half), st0(mid)) },
  ];
  return { steps, replays, end: st0(st) };
}
const walks = [];
const walkEnds = [];
{
  const wr = mulberry32(777);
  let n = 0;
  LEVEL_DATA.forEach((d, i) => {
    const lv = parsed[i].lv;
    const sol = [...d.solution].map((c) => DCH.indexOf(c));
    const w0 = walk(lv, wr, sol);
    walks.push({ name: `level ${i + 1} solution`, rows: d.map, ...w0 });
    n += w0.steps.length;
    for (let k = 0; k < 4; k++) {
      const w = walk(lv, wr, null);
      walks.push({ name: `level ${i + 1} walk ${k}`, rows: d.map, ...w });
      walkEnds.push({ i, rows: d.map, st: w.end, mid: w.steps[Math.floor(w.steps.length / 2)].st });
      n += w.steps.length;
    }
  });
  parsed.slice(100).forEach((p) => {
    for (let k = 0; k < 2; k++) {
      const w = walk(p.lv, wr, null);
      walks.push({ name: `${p.name} walk ${k}`, rows: p.rows, ...w });
      n += w.steps.length;
    }
  });
  write('walks', walks, n);
}

// ---- search ----------------------------------------------------------------------------------------------------------
const timing = [];
{
  const cases = [];
  const add = (name, rows, st, opts, seed) => {
    const lv = parse(rows);
    const o = { ...opts };
    if (seed != null) o.rand = mulberry32(seed);
    const t0 = performance.now();
    const out = search(lv, st || newState(lv), o);
    const ms = performance.now() - t0;
    cases.push({ name, rows, st: st || null, opts: opts, seed: seed ?? null, out, ms });
    return ms;
  };
  LEVEL_DATA.forEach((d, i) => {
    add(`level ${i + 1}`, d.map, null, {});
    add(`level ${i + 1} count`, d.map, null, { count: true });
    add(`level ${i + 1} rand`, d.map, null, {}, 1000 + i);
    add(`level ${i + 1} limit`, d.map, null, { limit: [0, 1, 5, 37, 500][i % 5] });
    // part of the way along the full clear
    const lv = parsed[i].lv;
    const sol = [...d.solution].map((c) => DCH.indexOf(c));
    for (const f of [0.3, 0.7, 1]) {
      const r = replay(lv, sol.slice(0, Math.floor(sol.length * f)));
      add(`level ${i + 1} at ${f}`, d.map, st0(r.st), { count: true, cap: 3 });
    }
  });
  for (let i = 0; i < 8; i++) add(`level ${i + 1} count cap 10`, LEVEL_DATA[i].map, null, { count: true, cap: 10, limit: 2e6 });
  for (let i = 0; i < 20; i++) add(`level ${i + 1} rand count`, LEVEL_DATA[i].map, null, { count: true, cap: 4 }, 5000 + i);
  walkEnds.forEach((w, k) => {
    add(`walk end ${k}`, w.rows, w.st, {});
    if (k % 2 === 0) add(`walk mid ${k}`, w.rows, w.mid, { count: true, limit: 20000 });
  });
  parsed.slice(100).forEach((p, k) => {
    add(`${p.name} count`, p.rows, null, { count: true, cap: 20, limit: 50000 });
    if (k % 3 === 0) add(`${p.name} rand`, p.rows, null, { limit: 50000 }, 9000 + k);
  });
  // timing: the hardest levels, best of 5
  const hard = LEVEL_DATA.map((d, i) => [d.effort, i]).sort((a, b) => b[0] - a[0]).slice(0, 8);
  for (const [, i] of hard) {
    const lv = parse(LEVEL_DATA[i].map);
    let best = Infinity;
    let nodes = 0;
    for (let k = 0; k < 5; k++) {
      const t0 = performance.now();
      const r = search(lv, newState(lv));
      best = Math.min(best, performance.now() - t0);
      nodes = r.nodes;
    }
    timing.push({ level: i + 1, nodes, ms: best });
  }
  write('search', { cases, timing }, cases.length);
}

// ---- levels.js: constants, levelSpec, stageOf, stars, coins, xp -------------------------------------------------------
{
  const lvIns = [];
  for (let i = 1; i <= 100; i++) lvIns.push(i);
  lvIns.push(0, -0, -3, 101, 250, 1.5, 14.999, 99.9, 100.5, 0.4, -0.5, NaN, Infinity, -Infinity);
  const specs = lvIns.map((x) => ({ in: x, out: L.levelSpec(x) }));
  const stages = lvIns.map((x) => ({ in: x, out: L.stageOf(x) }));
  const stars = [];
  for (let left = -2; left <= 12; left++) for (const h of [false, true]) stars.push({ left, hinted: h, out: L.starsFor(left, h), eng: engStars(left, h) });
  const coins = [];
  const xps = [];
  for (let i = 1; i <= 100; i++) {
    const s = L.levelSpec(i);
    for (let k = 0; k <= 3; k++) coins.push({ lv: i, stars: k, out: L.coinsFor(s, k) });
    for (const k of [0, 1, 2, 3, 0.5, 2.5, 4, -1]) xps.push({ lv: i, stars: k, out: L.xpFor(s, k) });
  }
  const consts = {
    LEVELS: L.LEVELS, TIER_NAMES: L.TIER_NAMES, TIER_COLORS: L.TIER_COLORS, ROOMS: L.ROOMS, TWISTS: L.TWISTS,
    CHAPTERS: L.CHAPTERS, LEVEL_LIST: L.LEVEL_LIST, LEVEL_DATA,
  };
  write('levels', { consts, specs, stages, stars, coins, xps }, specs.length + stages.length + stars.length + coins.length + xps.length + 8);
}

// ---- the profile: record, starsOf, doneOf, afterLevel, afterStuck ----------------------------------------------------
{
  const hops = [
    undefined, null, {}, { lv: 5, best: { 1: 3, 2: 2, 3: 1, 4: 3 }, plays: 10, wins: 4, seen: true },
    { lv: 1 }, { lv: 0, plays: 0, wins: 0, seen: false }, { lv: -2, seen: 1 }, { lv: 3.7, plays: 2.5, seen: 'yes' },
    { lv: '7', best: { 7: 2 } }, { lv: 100, best: { 100: 3, 99: 2, 50: 1 }, plays: 300, wins: 200 },
    { lv: 250, best: { 100: 1 } }, { lv: 14, best: { x: 2, 10: 1, 2: 3, 13: 2.5, 14: 1 }, plays: 20, wins: 13 },
    { lv: 37, best: { 37: 3, 36: 0, 5: null }, plays: 40, wins: 36, seen: true },
    { lv: 90, best: { 90: 1, 1: 2 }, plays: 1e6, wins: 999999 }, { best: { 1: 3 } }, { lv: 2, best: null, plays: null },
    { lv: 4, blitz: { top: 7, runs: 3 } }, { blitz: { top: 0 } }, { blitz: null, seen: true }, { lv: 9, blitz: { runs: 12, reached: 4 } },
  ];
  const xpsP = [
    {}, { pxp: 0 }, { pxp: 50 }, { pxp: 99 }, { pxp: 199.5 }, { pxp: 1234 }, { pxp: -20 }, { pxp: 1e7 },
    { level: 5 }, { level: 3, sdk: { xp: 77.9 } }, { level: null, sdk: null }, { pxp: '100', level: 2 }, { level: 0.5, sdk: { xp: -4 } },
  ];
  const profiles = [null];
  hops.forEach((h, i) => xpsP.forEach((x, j) => {
    if ((i + j) % 2 && i > 3) return; // a good spread, not every pair
    const p = { ...x };
    if (h !== undefined) p.hop = h;
    profiles.push(p);
  }));
  profiles.push({ hop: 5 }, { hop: 'x', pxp: 10 }, { hop: { lv: NaN } }); // odd hop values
  const configs = [null, { xpPerLevel: 150, xp: { games: 1.5, replay: 0.3 } }, { xpPerLevel: -5, xp: { games: 0, replay: 2 } }];
  // (develop, 2026-11-16: the stars count the take-backs, RESTARTs and RETRYs)
  const results = [{ takebacks: 0, hinted: false }, { takebacks: 0, hinted: true }, { takebacks: 2 }, { takebacks: 3, hinted: 1 }, { takebacks: 7, hinted: false }, { takebacks: 1, hinted: true }, { hinted: false }];
  const records = profiles.map((p) => {
    const rec = L.record(p);
    return { profile: p, out: rec, starsOf: L.starsOf(rec), doneOf: L.doneOf(rec), afterStuck: L.afterStuck(p) };
  });
  const after = [];
  configs.forEach((cfg, ci) => {
    setLevelsConfig(cfg);
    profiles.forEach((p, pi) => {
      if (ci > 0 && pi % 3) return;
      const rec = L.record(p);
      const lvs = [...new Set([1, 5, 14, 37, 90, 100, rec.lv, Math.max(1, rec.lv - 1)])];
      lvs.forEach((lv, li) => {
        results.forEach((res, ri) => {
          if ((li + ri + pi) % 2) return;
          after.push({ config: cfg, profile: pi, lv, result: res, out: L.afterLevel(p, L.levelSpec(lv), res) });
        });
      });
    });
  });
  // BLITZ MODE: afterBlitz and blitzPrize
  const blitzes = [];
  const bcfgs = [...configs, { xp: { blitz: { hop: 350 } } }, { xp: { blitz: { hop: -3 } } }];
  bcfgs.forEach((cfg, ci) => {
    setLevelsConfig(cfg);
    profiles.forEach((p, pi) => {
      if (pi % 4 && ci) return;
      for (const cleared of [0, 1, 4, 12, 13, 20]) if ((pi + cleared) % 3 === 0 || !ci) blitzes.push({ config: cfg, profile: pi, cleared, out: L.afterBlitz(p, { cleared }), prize: L.blitzPrize(cleared) });
    });
  });
  setLevelsConfig(null);
  write('profile', { profiles, records, after, blitzes }, records.length * 4 + after.length + blitzes.length);
}

// ---- blitz.js: the boards, their clocks and shapes ---------------------------------------------------------------------
{
  const shapes = [];
  for (let i = 0; i < 30; i++) shapes.push({ i, out: BZ.blitzShape(i) });
  const clocks = [];
  for (const hops of [0, 3, 8, 15, 29]) for (const past of [0, 1, 5, 8, 9, 30]) clocks.push({ hops, past, out: BZ.blitzMs(hops, past) });
  const seeds = [];
  for (const s of [1, 12345, -7, 2147483000]) { const r = BZ.seeded(s); seeds.push({ seed: s, out: Array.from({ length: 6 }, () => r()) }); }
  const specs = [];
  for (const seed of [1, 99, 424242, 987654321]) for (let i = 0; i < 22; i++) {
    const s = BZ.blitzSpec(i, seed);
    specs.push({ i, seed, out: { lv: s.lv, map: s.map, tier: s.tier, sol: s.sol, cushions: s.cushions, twists: s.twists, size: s.size, ms: s.ms, coins: s.coins } });
  }
  write('blitz', { shapes, clocks, seeds, specs }, shapes.length + clocks.length + seeds.length + specs.length);
}

// ---- board.js geometry -------------------------------------------------------------------------------------------------
{
  const sizes = [[1, 1], [3, 3], [4, 3], [5, 5], [5, 6], [6, 6], [6, 8], [7, 8], [8, 7], [10, 12], [2, 9]];
  const areas = [[390, 520, 60], [360, 430, 0], [412, 610, 120], [1080, 1920, 300], [200, 200, -50], [320, 260], [800, 400, 380]];
  const extras = [[], [undefined, 30], [undefined, 0, 40], [undefined, 60, 200], [undefined, 38.5, 64.25]];
  const cases = [];
  const r = mulberry32(4242);
  let n = 0;
  sizes.forEach(([w, h], si) => areas.forEach((a, ai) => extras.forEach((ex, ei) => {
    if ((si + ai + ei) % 2 && ei > 0) return;
    let args = [w, h, ...a];
    if (ex.length) {
      if (a.length < 3) args.push(undefined);
      args = [...args, ...ex.slice(1)];
    }
    const B = BG.layout(...args);
    const c = { args: args.map((v) => (v === undefined ? null : v)), B, project: [], cellAt: [], standOn: [], roundRect: [], polyPath: [], cellBox: [], chevron: [] };
    const us = [-0.5, 0, 0.37, w / 2, w - 0.01, w, w + 0.25];
    const vs = [-0.5, 0, 0.61, h / 2, h - 0.01, h, h + 0.25];
    for (const u of us) for (const v of vs) for (const z of [undefined, 0, 0.3, 1.2]) {
      c.project.push({ u, v, z: z ?? null, out: z === undefined ? BG.project(B, u, v) : BG.project(B, u, v, z) });
    }
    for (let i = 0; i < w * h; i++) {
      const x = i % w;
      const y = Math.floor(i / w);
      for (const [du, dv] of [[0.5, 0.5], [0.15, 0.2], [0.85, 0.85], [0.001, 0.999], [0, 0.5], [0.5, 0], [0, 0], [1e-7, 1e-7], [1 - 1e-7, 1 - 1e-7]]) {
        const p = BG.project(B, x + du, y + dv);
        c.cellAt.push({ sx: p.x, sy: p.y, out: BG.cellAt(B, p.x, p.y) });
      }
      c.standOn.push({ i, z: null, out: BG.standOn(B, i) });
      c.standOn.push({ i, z: 0.4, out: BG.standOn(B, i, 0.4) });
      c.cellBox.push({ x, y, z: null, pad: null, out: BG.cellBox(B, x, y) });
      c.cellBox.push({ x, y, z: 0.35, pad: null, out: BG.cellBox(B, x, y, 0.35) });
      c.cellBox.push({ x, y, z: 0.2, pad: 0.1, out: BG.cellBox(B, x, y, 0.2, 0.1) });
    }
    for (let k = 0; k < 40; k++) {
      const sx = (r() * 1.4 - 0.2) * a[0];
      const sy = (r() * 1.4 - 0.2) * a[1];
      c.cellAt.push({ sx, sy, out: BG.cellAt(B, sx, sy) });
    }
    c.standOn.push({ i: -1, z: null, out: BG.standOn(B, -1) });
    c.standOn.push({ i: w * h + 3, z: 0, out: BG.standOn(B, w * h + 3, 0) });
    for (let k = 0; k < 6; k++) {
      const x0 = Math.floor(r() * w) + r() * 0.2;
      const y0 = Math.floor(r() * h) + r() * 0.2;
      const args2 = [x0, y0, x0 + 0.6 + r() * 0.4, y0 + 0.6 + r() * 0.4, r() * 0.3, r() * 0.4, r() * 50 - 25, r() * 50 - 25];
      c.roundRect.push({ args: args2, out: BG.roundRect(B, ...args2) });
    }
    c.roundRect.push({ args: [0, 0, w, h, 0.25, 0, 0, 0], out: BG.roundRect(B, 0, 0, w, h, 0.25, 0, 0, 0) });
    c.roundRect.push({ args: [0.1, 0.1, 0.9, 0.9, 0, 0.1, B.cx, B.cy], out: BG.roundRect(B, 0.1, 0.1, 0.9, 0.9, 0, 0.1, B.cx, B.cy) });
    for (let k = 0; k < 6; k++) {
      const dir = k % 4;
      const size = 0.3 + r() * 0.5;
      const u = r() * w;
      const v = r() * h;
      const pts = BG.chevron(u, v, dir, size);
      c.chevron.push({ u, v, dir, size, out: pts });
      const z = r() * 0.3;
      const ox = r() * 100 - 50;
      const oy = r() * 100 - 50;
      c.polyPath.push({ pts, z, ox, oy, out: BG.polyPath(B, pts, z, ox, oy) });
    }
    c.polyPath.push({ pts: [], z: 0, ox: 0, oy: 0, out: BG.polyPath(B, [], 0, 0, 0) });
    c.polyPath.push({ pts: [[0, 0], [w, 0], [w, h], [0, h], [0.05, 0.05], [-1e-3, 2.25]], z: 0, ox: 0.04, oy: -0.05, out: BG.polyPath(B, [[0, 0], [w, 0], [w, h], [0, h], [0.05, 0.05], [-1e-3, 2.25]], 0, 0.04, -0.05) });
    n += 1 + c.project.length + c.cellAt.length + c.standOn.length + c.roundRect.length + c.polyPath.length + c.cellBox.length + c.chevron.length;
    cases.push(c);
  })));
  // toFixed(1) on its own: ties, negatives, tiny values
  const fixed = [0, -0, 0.05, 0.15, 0.25, 0.35, -0.05, -0.04, -0.25, 1.45, 2.675, 1e-7, -1e-7, 123456.75, -98.95, 1e20, 5e-324, 0.95, -0.95, 0.04999999999999999]
    .map((x) => ({ x, out: x.toFixed(1) }));
  for (let k = 0; k < 2000; k++) {
    const x = (r() - 0.5) * 10 ** Math.floor(r() * 7 - 2);
    fixed.push({ x, out: x.toFixed(1) });
  }
  for (let k = 0; k < 300; k++) {
    const x = (Math.floor(r() * 20000) - 10000) / 20; // exact .x5 ties
    fixed.push({ x, out: x.toFixed(1) });
  }
  write('board', { TILT: BG.TILT, DEPTH: BG.DEPTH, cases, fixed }, n + fixed.length);
}

fs.writeFileSync(path.join(OUT, 'counts.json'), JSON.stringify(counts, null, 1));
console.log('JS search timing (hardest levels, best of 5):', timing.map((t) => `L${t.level} ${t.ms.toFixed(1)}ms/${t.nodes}n`).join(', '));
