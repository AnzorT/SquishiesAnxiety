// Squish Hop's 100 levels. For each level slot (a room chapter, a board
// size, which twists it has) it makes candidate boards and keeps the ones
// with exactly one full clear, then picks one by how hard it is.
//
// A candidate: a random walk over the w × h grid that covers the board
// (the cells it skips are holes; with piles, some cells are walked twice).
// Its start is S, its end the ★. The twists are placed so that the walk
// still works (an arrow points the way the walk leaves, a bubble sits where
// the walk goes straight through, a beat tile gets the beat the walk lands
// on it with, numbered friends are numbered in walk order). While another
// full clear exists, one more twist is added that the other clear breaks
// and the walk keeps. Hardness ("effort") is how many moves the solver
// tries before it finds the clear, averaged over shuffled move orders.
//
// Run:  node tools/gen.mjs --slots=1-100 [--secs=15] [--out=DIR]   search slots, one JSON per slot in DIR
//       node tools/gen.mjs --merge=DIR    pick from DIR into picks.json and levels.js
//       node tools/gen.mjs --write        rebuild levels.js from picks.json
//       node tools/gen.mjs --plan         print the 100 slots
// (run several --slots ranges at once, one per core, then --merge)
import { existsSync, mkdirSync, readFileSync, readdirSync, writeFileSync } from 'node:fs';
import { createRequire } from 'node:module';
const require = createRequire(import.meta.url);
const E = require('../engine.js');

const arg = (k, d) => {
  const a = process.argv.find((x) => x.startsWith(`--${k}=`));
  return a ? a.slice(k.length + 3) : d;
};
const PICKS = new URL('./picks.json', import.meta.url);

// ---- the plan: 6 rooms, 100 levels
const CHAPTERS = [
  { room: 'living', from: 1, to: 14 },
  { room: 'kitchen', from: 15, to: 30 },
  { room: 'bath', from: 31, to: 46 },
  { room: 'bed', from: 47, to: 62 },
  { room: 'yard', from: 63, to: 80 },
  { room: 'dance', from: 81, to: 100 },
];
const pickN = (n, list) => list[(n * 7 + 3) % list.length];
function specOf(n) {
  const ch = CHAPTERS.find((c) => n >= c.from && n <= c.to);
  const t = (n - ch.from) / (ch.to - ch.from);
  const boss = n === ch.to;
  const s = { n, room: ch.room, F: 0, ordered: false, P: 0, A: 0, B: 0, T: 0, repair: [], maxSols: 1, news: null };
  // How hard a pick within the slot, 0 (the easiest found) to 1 (the
  // hardest), on a log scale of effort: low for a new twist, rising through
  // the room, a breather every fifth level, the room's last level near the
  // top. Later rooms reach higher.
  const room = CHAPTERS.indexOf(ch);
  const reach = 0.55 + 0.09 * room;
  s.q = boss ? 0.85 + 0.03 * room : n === ch.from ? 0.1 : n % 5 === 0 ? 0.3 * reach : (0.3 + 0.7 * t) * reach;
  const size = (list) => {
    const [w, h] = list[Math.min(list.length - 1, Math.floor(t * list.length))];
    s.w = w;
    s.h = h;
  };
  if (ch.room === 'living') {
    const L = [[3, 3, 1], [4, 3, 1], [4, 4, 0.88], [5, 4, 0.85], [5, 4, 0.9], [5, 5, 0.84], [5, 5, 0.88], [5, 5, 0.84], [6, 5, 0.83], [6, 5, 0.87], [5, 6, 0.85], [6, 6, 0.8], [6, 6, 0.83], [6, 6, 0.86]][n - 1];
    [s.w, s.h, s.fill] = L;
    s.F = [0, 0, 0, 0, 0, 0, 0, 1, 1, 2, 2, 1, 2, 2][n - 1];
    if (n <= 4) s.maxSols = 3;
    if (n === 8) s.news = 'friends';
  } else if (ch.room === 'kitchen') {
    size([[5, 5], [5, 6], [6, 6], [6, 6], [6, 7], [7, 6], [6, 7], [7, 7]]);
    s.fill = 0.9 + 0.05 * t;
    s.A = n === ch.from ? 2 : pickN(n, [1, 2, 2, 3]);
    s.F = pickN(n, [0, 0, 1, 2]);
    s.repair = ['arrow'];
    if (n === ch.from) {
      s.news = 'arrows';
      s.F = 0;
    }
  } else if (ch.room === 'bath') {
    size([[5, 5], [6, 6], [6, 6], [6, 7], [7, 6], [6, 7], [7, 7], [7, 7]]);
    s.fill = 0.9 + 0.06 * t;
    s.B = n === ch.from ? 2 : pickN(n, [2, 3, 3, 4]);
    s.A = n === ch.from ? 0 : pickN(n, [0, 1, 2]);
    s.F = n === ch.from ? 0 : pickN(n, [0, 1, 0, 2]);
    s.repair = n === ch.from ? ['bubble'] : ['bubble', 'arrow'];
    if (n === ch.from) s.news = 'bubbles';
  } else if (ch.room === 'bed') {
    size([[5, 5], [6, 6], [6, 6], [6, 7], [7, 6], [6, 7], [7, 7], [7, 7]]);
    s.fill = 0.88 + 0.08 * t;
    s.P = n === ch.from ? 2 : pickN(n, [2, 3, 2, 4]);
    s.A = n === ch.from ? 0 : pickN(n, [0, 1, 1, 2]);
    s.B = n === ch.from ? 0 : pickN(n, [1, 0, 2, 1]);
    s.repair = ['arrow', 'bubble'];
    if (n === ch.from) s.news = 'piles';
    if (n >= 55) {
      s.F = n === 55 ? 3 : pickN(n, [3, 4, 3]);
      s.ordered = true;
      if (n === 55) {
        s.news = 'ordered';
        s.P = 1;
        s.A = 0;
        s.B = 0;
        s.w = 6;
        s.h = 5;
      }
    }
  } else if (ch.room === 'yard') {
    size([[6, 6], [6, 7], [7, 6], [7, 7], [6, 7], [7, 7], [7, 7]]);
    s.fill = 0.9 + 0.07 * t;
    s.P = pickN(n, [0, 2, 3, 1]);
    s.A = pickN(n, [1, 2, 1, 2, 3]);
    s.B = pickN(n, [2, 1, 3, 1]);
    s.F = pickN(n, [2, 3, 0, 3, 4]);
    s.ordered = n % 2 === 0;
    s.repair = ['arrow', 'bubble'];
  } else {
    size([[5, 5], [6, 6], [6, 7], [7, 6], [7, 7], [7, 7], [6, 8], [7, 8], [7, 8]]);
    s.fill = 0.9 + 0.07 * t;
    s.T = n === ch.from ? 3 : pickN(n, [3, 4, 5, 6]);
    s.P = n === ch.from ? 0 : pickN(n, [0, 2, 1, 3]);
    s.A = n === ch.from ? 0 : pickN(n, [1, 0, 2, 1]);
    s.B = n === ch.from ? 0 : pickN(n, [1, 2, 0, 2]);
    s.F = n === ch.from ? 0 : pickN(n, [2, 0, 3, 4]);
    s.ordered = n % 3 !== 0;
    s.repair = n === ch.from ? ['beat'] : ['beat', 'arrow', 'bubble'];
    if (n === ch.from) s.news = 'beats';
  }
  return s;
}

// ---- random
function mulberry(a) {
  return () => {
    a |= 0;
    a = (a + 0x6d2b79f5) | 0;
    let t = Math.imul(a ^ (a >>> 15), 1 | a);
    t = (t + Math.imul(t ^ (t >>> 7), 61 | t)) ^ t;
    return ((t ^ (t >>> 14)) >>> 0) / 4294967296;
  };
}

// ---- the walk
const ABORT = {};
function makeWalk(w, h, N, P, rnd) {
  const n = w * h;
  const cnt = new Int8Array(n);
  const walk = [];
  let distinct = 0;
  let piles = 0;
  let steps = 0;
  const near = (i) => {
    const x = i % w;
    const y = (i / w) | 0;
    const out = [];
    if (y > 0) out.push(i - w);
    if (x < w - 1) out.push(i + 1);
    if (y < h - 1) out.push(i + w);
    if (x > 0) out.push(i - 1);
    return out;
  };
  const start = Math.floor(rnd() * n);
  function go(c) {
    if (++steps > 4000) throw ABORT;
    walk.push(c);
    cnt[c]++;
    if (cnt[c] === 1) distinct++;
    else piles++;
    if (distinct === N && piles === P && cnt[c] === 1) return true;
    // the last new cell (the ★) has to wait until the piles are made
    const allowNew = distinct < N - 1 || piles === P;
    const allowRe = piles < P && distinct >= 2;
    const cand = [];
    for (const j of near(c)) {
      if (cnt[j] === 0 && allowNew) cand.push([j, near(j).filter((k) => cnt[k] === 0).length + rnd() * 1.6]);
      else if (cnt[j] === 1 && allowRe && j !== start && j !== walk[walk.length - 2] && rnd() < 0.35) cand.push([j, 2 + rnd() * 3]);
    }
    cand.sort((a, b) => a[1] - b[1]);
    for (const [j] of cand) if (go(j)) return true;
    walk.pop();
    cnt[c]--;
    if (cnt[c] === 0) distinct--;
    else piles--;
    return false;
  }
  try {
    return go(start) ? { walk, cnt } : null;
  } catch (e) {
    if (e !== ABORT) throw e;
    return null;
  }
}

const dirOf = (w, a, b) => (b === a - w ? 0 : b === a + 1 ? 1 : b === a + w ? 2 : 3);
const ARROW_CH = ['^', '>', 'v', '<'];
const BEAT_CH = ['a', 'b', 'c'];

function toRows(w, h, cells) {
  const rows = [];
  for (let y = 0; y < h; y++) rows.push(cells.slice(y * w, y * w + w).join(''));
  return rows;
}
// trim empty rows and columns round the board (moves are directions, so
// the answer stays the same)
function crop(rows) {
  let top = 0;
  let bot = rows.length - 1;
  while (top < bot && /^#*$/.test(rows[top])) top++;
  while (bot > top && /^#*$/.test(rows[bot])) bot--;
  const r = rows.slice(top, bot + 1);
  let l = 0;
  let rt = r[0].length - 1;
  while (l < rt && r.every((s) => s[l] === '#')) l++;
  while (rt > l && r.every((s) => s[rt] === '#')) rt--;
  return r.map((s) => s.slice(l, rt + 1));
}

// the walk's moves (a bubble folds the hop over it into the hop before)
function walkMoves(lv, walk, w) {
  let st = E.newState(lv);
  const dirs = [];
  let i = 0;
  while (i < walk.length - 1) {
    const d = dirOf(w, walk[i], walk[i + 1]);
    const m = E.tryMove(lv, st, d);
    if (!m.ok) return null;
    dirs.push(d);
    st = m.st;
    i += m.cells.length;
  }
  return st.done && E.leftOf(lv, st.life) === 0 ? dirs : null;
}

function effortOf(lv, rnd, runs = 4) {
  let sum = 0;
  for (let r = 0; r < runs; r++) {
    const res = E.search(lv, E.newState(lv), { limit: 250000, rand: rnd });
    sum += res.path ? res.nodes : 250000;
  }
  return sum / runs;
}

function candidate(s, rnd) {
  const { w, h } = s;
  const N = Math.max(4, Math.round(w * h * s.fill));
  const made = makeWalk(w, h, N, s.P, rnd);
  if (!made) return null;
  const { walk, cnt } = made;
  const L = walk.length;
  const cells = new Array(w * h).fill('#');
  walk.forEach((c) => (cells[c] = cnt[c] === 2 ? 'D' : '.'));
  cells[walk[0]] = 'S';
  cells[walk[L - 1]] = 'G';
  const idx = new Map(); // cell -> its walk index (cells walked once)
  walk.forEach((c, i) => cnt[c] === 1 && idx.set(c, i));
  const free = () => walk.filter((c, i) => i > 0 && i < L - 1 && cnt[c] === 1 && cells[c] === '.');
  const take = (list) => (list.length ? list.splice(Math.floor(rnd() * list.length), 1)[0] : -1);
  // the twists, placed so the walk still works
  const straight = (c) => {
    const i = idx.get(c);
    return dirOf(w, walk[i - 1], c) === dirOf(w, c, walk[i + 1]);
  };
  const place = (type, c) => {
    const i = idx.get(c);
    if (type === 'arrow') cells[c] = ARROW_CH[dirOf(w, c, walk[i + 1])];
    else if (type === 'bubble') cells[c] = 'o';
    else if (type === 'beat') cells[c] = BEAT_CH[i % 3];
    else cells[c] = 'F';
  };
  for (const [type, k] of [['friend', s.F], ['arrow', s.A], ['bubble', s.B], ['beat', s.T]]) {
    const pool = free().filter((c) => type !== 'bubble' || straight(c));
    for (let j = 0; j < k; j++) {
      const c = take(pool);
      if (c < 0) return null;
      place(type, c);
    }
  }
  if (s.ordered && s.F) {
    let k = 1;
    walk.forEach((c) => {
      if (cells[c] === 'F') cells[c] = String(k++);
    });
  }
  // add twists until the walk is the only full clear
  for (let tries = 0; ; tries++) {
    const rows = toRows(w, h, cells);
    const lv = E.parse(rows);
    if (!E.parityOk(lv)) return null;
    const mine = walkMoves(lv, walk, w);
    if (!mine) return null;
    const r = E.search(lv, E.newState(lv), { count: true, cap: Math.max(2, s.maxSols + 1), limit: 1500000 });
    if (r.aborted) return null;
    if (r.count <= s.maxSols) {
      const out = crop(rows);
      const lv2 = E.parse(out);
      return { map: out, solution: mine.map((d) => E.DCH[d]).join(''), sols: r.count, effort: effortOf(lv2, rnd), added: tries };
    }
    if (!s.repair.length || tries >= 8) return null;
    // where does another clear go differently from the walk?
    const other = r.sols.find((x) => x.join() !== mine.join());
    const rep = E.replay(lv, other);
    const seq = [lv.start];
    rep.steps.forEach((m) => seq.push(...m.cells));
    const pos = new Map();
    seq.forEach((c, i) => pos.has(c) || pos.set(c, i));
    const fixes = [];
    for (const c of free()) {
      const i = idx.get(c);
      const e = pos.get(c);
      if (e === undefined) continue;
      const mineOut = dirOf(w, c, walk[i + 1]);
      const theirIn = dirOf(w, seq[e - 1], c);
      const theirOut = e + 1 < seq.length ? dirOf(w, c, seq[e + 1]) : -1;
      for (const type of s.repair) {
        if (type === 'arrow' && theirOut !== mineOut) fixes.push([type, c]);
        if (type === 'beat' && e % 3 !== i % 3) fixes.push([type, c]);
        if (type === 'bubble' && straight(c) && theirIn !== theirOut) fixes.push([type, c]);
      }
    }
    if (!fixes.length) return null;
    const [type, c] = fixes[Math.floor(rnd() * fixes.length)];
    place(type, c);
  }
}

function searchSlot(n, secs) {
  const s = specOf(n);
  const rnd = mulberry(n * 7919 + 17);
  const end = Date.now() + secs * 1000;
  const found = [];
  let tried = 0;
  // keep going past the time (up to 4x) if nothing has been found yet
  while (Date.now() < end || (!found.length && Date.now() < end + secs * 3000)) {
    tried++;
    const c = candidate(s, rnd);
    if (c) found.push(c);
  }
  found.sort((a, b) => a.effort - b.effort);
  const step = Math.max(1, Math.floor(found.length / 40));
  return { n, spec: s, tried, found: found.length, pool: found.filter((_, i) => i % step === 0 || i === found.length - 1) };
}

// ---- levels.js
const TIER = (p) => (p < 0.25 ? 0 : p < 0.55 ? 1 : p < 0.82 ? 2 : 3);
function writeLevels(picks) {
  const efforts = picks.map((p) => p.effort).slice().sort((a, b) => a - b);
  const body = picks
    .map((p) => {
      const rank = efforts.indexOf(p.effort) / (efforts.length - 1 || 1);
      const tier = p.n <= 5 ? 0 : TIER(rank);
      return `    { map: ${JSON.stringify(p.map)}, room: ${JSON.stringify(p.room)}, tier: ${tier}, news: ${JSON.stringify(p.news)}, sols: ${p.sols}, effort: ${Math.round(p.effort)}, solution: ${JSON.stringify(p.solution)} },`;
    })
    .join('\n');
  writeFileSync(
    new URL('../levels.js', import.meta.url),
    `// Generated by tools/gen.mjs from tools/picks.json: Squish Hop's levels.
// Don't edit by hand. map: see engine.js for the letters. room: the Crib
// room it's played in. tier: 0 EASY … 3 EXPERT (by effort, against the
// other levels). news: the twist it brings in. sols: how many full clears
// there are. effort: how many moves the solver tries before it finds the
// clear (higher is harder). solution: the clear, as U R D L moves.
(function (root) {
  const LEVELS = [
${body}
  ];
  if (typeof module !== 'undefined' && module.exports) module.exports = { LEVELS };
  else root.HopLevels = LEVELS;
})(typeof window !== 'undefined' ? window : globalThis);
`
  );
}

// ---- main
const slots = arg('slots');
const merge = arg('merge');
if (slots) {
  const [a, b] = slots.split('-').map(Number);
  const out = arg('out', new URL('./out/', import.meta.url).pathname);
  if (!existsSync(out)) mkdirSync(out, { recursive: true });
  const secs = Number(arg('secs', 15));
  for (let n = a; n <= (b || a); n++) {
    const t0 = Date.now();
    const r = searchSlot(n, secs);
    writeFileSync(`${out}/slot-${String(n).padStart(3, '0')}.json`, JSON.stringify(r));
    const e = r.pool.map((p) => Math.round(p.effort));
    console.log(`slot ${n} (${r.spec.room} ${r.spec.w}x${r.spec.h}): tried ${r.tried}, found ${r.found}, effort ${e[0]}..${e[e.length - 1]} (${((Date.now() - t0) / 1000).toFixed(0)}s)`);
  }
} else if (merge) {
  const files = readdirSync(merge).filter((f) => f.startsWith('slot-')).sort();
  const picks = [];
  for (const f of files) {
    const r = JSON.parse(readFileSync(`${merge}/${f}`, 'utf8'));
    if (!r.pool.length) {
      console.error(`slot ${r.n}: nothing found`);
      process.exit(1);
    }
    // the candidate nearest the slot's spot on a log scale of effort
    const lo = Math.log(r.pool[0].effort);
    const hi = Math.log(r.pool[r.pool.length - 1].effort);
    const want = lo + r.spec.q * (hi - lo);
    const p = r.pool.reduce((a, b) => (Math.abs(Math.log(b.effort) - want) < Math.abs(Math.log(a.effort) - want) ? b : a));
    picks.push({ n: r.n, room: r.spec.room, news: r.spec.news, map: p.map, solution: p.solution, sols: p.sols, effort: p.effort });
  }
  writeFileSync(PICKS, JSON.stringify(picks, null, 1) + '\n');
  writeLevels(picks);
  console.log(`wrote picks.json and levels.js (${picks.length} levels)`);
} else if (process.argv.includes('--write')) {
  writeLevels(JSON.parse(readFileSync(PICKS, 'utf8')));
  console.log('wrote levels.js');
} else if (process.argv.includes('--plan')) {
  for (let n = 1; n <= 100; n++) {
    const s = specOf(n);
    console.log(n, s.room, `${s.w}x${s.h}`, s.fill.toFixed(2), `F${s.F}${s.ordered ? 'o' : ''} P${s.P} A${s.A} B${s.B} T${s.T}`, s.repair.join('/'), s.news || '', `q${s.q.toFixed(2)}`);
  }
}
