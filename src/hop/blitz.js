// Squish Hop's BLITZ MODE boards (SQUISH_HOP.md; 2026-11-16, the user: "the same thing" as Squishdoku's Blitz). The
// 100 levels are fixed and big (up to 54 hops, most with only one full clear), too much for a short clock and too easy
// to learn by heart, so Blitz deals fresh small boards, as the other games' Blitz do. A board is made the way the
// prototype's tools/gen.mjs starts a level: a random walk that covers most of a w × h grid (the cells it skips are
// holes), its start the squishy's cushion and its end the ★. Friends sit on the walk, and an arrow points the way the
// walk leaves its cushion, so the walk is always a full clear. Other full clears may exist too: Blitz doesn't need
// just one, since the game asks the solver whether a full clear is still possible after every hop.
import { leftOf, newState, parse, tryMove } from './engine.js';

// the climb: 3 × 3 to 6 × 5, friends from the 3rd board, arrows from the 6th
const RAMP = [
  { w: 3, h: 3, fill: 1, F: 0, A: 0 },
  { w: 4, h: 3, fill: 1, F: 0, A: 0 },
  { w: 4, h: 3, fill: 0.92, F: 1, A: 0 },
  { w: 4, h: 4, fill: 0.88, F: 0, A: 0 },
  { w: 4, h: 4, fill: 0.94, F: 1, A: 0 },
  { w: 5, h: 4, fill: 0.85, F: 1, A: 1 },
  { w: 5, h: 4, fill: 0.9, F: 2, A: 0 },
  { w: 5, h: 4, fill: 0.9, F: 1, A: 2 },
  { w: 5, h: 5, fill: 0.84, F: 1, A: 1 },
  { w: 5, h: 5, fill: 0.88, F: 2, A: 2 },
  { w: 5, h: 5, fill: 0.9, F: 2, A: 2 },
  { w: 6, h: 5, fill: 0.85, F: 2, A: 2 },
];
// past the climb, for good
const PAST = [
  { w: 6, h: 5, fill: 0.9, F: 2, A: 3 },
  { w: 6, h: 5, fill: 0.93, F: 3, A: 2 },
];
export const BLITZ_RAMP = RAMP.length;

// Board i's shape (0 = the first): { w, h, fill, F (friends), A (arrows), past (boards beyond the climb) }.
export function blitzShape(i) {
  const past = Math.max(0, i - RAMP.length + 1);
  return { ...(i < RAMP.length ? RAMP[i] : PAST[i % 2]), past };
}

// a board's clock: 5 s to look, then 1 s a hop, whole seconds; past the climb each board's is 3% shorter than the
// last, down to three quarters
export const blitzMs = (hops, past = 0) => Math.ceil((5 + hops) * Math.max(0.75, 1 - 0.03 * past)) * 1000;

// a seeded random (mulberry32): the same run seed and board give the same board
export function seeded(a) {
  return () => {
    a |= 0;
    a = (a + 0x6d2b79f5) | 0;
    let t = Math.imul(a ^ (a >>> 15), 1 | a);
    t = (t + Math.imul(t ^ (t >>> 7), 61 | t)) ^ t;
    return ((t ^ (t >>> 14)) >>> 0) / 4294967296;
  };
}

const ABORT = {};
// A walk over `n` cells of the w × h grid, from a random start, trying the cell with the fewest free neighbours first
// (so it doesn't leave cells cut off). null if this start doesn't make it.
function makeWalk(w, h, n, rnd) {
  const used = new Uint8Array(w * h);
  const walk = [];
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
  function go(c) {
    if (++steps > 3000) throw ABORT;
    walk.push(c);
    used[c] = 1;
    if (walk.length === n) return true;
    const cand = near(c)
      .filter((j) => !used[j])
      .map((j) => [j, near(j).filter((k) => !used[k]).length + rnd() * 1.6])
      .sort((a, b) => a[1] - b[1]);
    for (const [j] of cand) if (go(j)) return true;
    walk.pop();
    used[c] = 0;
    return false;
  }
  try {
    return go(Math.floor(rnd() * w * h)) ? walk : null;
  } catch (e) {
    if (e !== ABORT) throw e;
    return null;
  }
}

const dirOf = (w, a, b) => (b === a - w ? 0 : b === a + 1 ? 1 : b === a + w ? 2 : 3);
const ARROW_CH = ['^', '>', 'v', '<'];

// the rows without the empty rows and columns round them (moves are directions, so the walk still works)
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

// One board of `shape` (blitzShape): { map (rows), sol (the walk, as directions) }.
export function makeBoard(shape, rnd) {
  const { w, h, F, A } = shape;
  const n = Math.max(4, Math.round(w * h * shape.fill));
  for (let tries = 0; tries < 400; tries++) {
    const walk = makeWalk(w, h, n, rnd);
    if (!walk) continue;
    const cells = new Array(w * h).fill('#');
    walk.forEach((c) => (cells[c] = '.'));
    cells[walk[0]] = 'S';
    cells[walk[walk.length - 1]] = 'G';
    // the walk's cushions in between, shuffled: friends first, then arrows (pointing the way the walk leaves)
    const mid = walk.slice(1, -1).map((c, k) => [c, k + 1]);
    for (let i = mid.length - 1; i > 0; i--) {
      const j = Math.floor(rnd() * (i + 1));
      [mid[i], mid[j]] = [mid[j], mid[i]];
    }
    if (mid.length < F + A) continue;
    mid.slice(0, F).forEach(([c]) => (cells[c] = 'F'));
    mid.slice(F, F + A).forEach(([c, k]) => (cells[c] = ARROW_CH[dirOf(w, c, walk[k + 1])]));
    const rows = [];
    for (let y = 0; y < h; y++) rows.push(cells.slice(y * w, y * w + w).join(''));
    const map = crop(rows);
    const sol = [];
    for (let k = 0; k + 1 < walk.length; k++) sol.push(dirOf(w, walk[k], walk[k + 1]));
    // (a check: the walk is a full clear of the board as parsed)
    const lv = parse(map);
    let st = newState(lv);
    let ok = true;
    for (const d of sol) {
      const m = tryMove(lv, st, d);
      if (!m.ok) {
        ok = false;
        break;
      }
      st = m.st;
    }
    if (ok && st.done && leftOf(lv, st.life) === 0) return { map, sol };
  }
  throw new Error(`no Blitz board for ${w}x${h}`);
}

// Board i of the run with this seed, in the shape of a level's spec (levels.js levelSpec) so the game plays it the
// same way: played in the Crib's Dance Room (the party room, as Squishdoku's Blitz), with no stored count of full
// clears (`sols: 0`: the solver is asked after every hop), its own clock (`ms`) and what it pays (`coins`).
export function blitzSpec(i, seed) {
  const shape = blitzShape(i);
  const { map, sol } = makeBoard(shape, seeded((seed + i * 7919) | 0));
  const board = parse(map);
  const twists = [];
  if (board.friends.length) twists.push('friends');
  if (board.arrow.some((a) => a >= 0)) twists.push('arrows');
  return {
    lv: i + 1,
    blitz: true,
    map,
    tier: i < 3 ? 0 : i < 8 ? 1 : i < RAMP.length ? 2 : 3,
    news: null,
    sols: 0,
    effort: 0,
    board,
    sol,
    room: 'dance',
    phase: 'day',
    stageKey: 'dance:blitz',
    beats: false,
    cushions: board.life.filter((x) => x > 0).length,
    twists,
    size: `${board.w}×${board.h}`,
    ms: blitzMs(sol.length, shape.past),
    coins: BLITZ_COINS[shape.w * shape.h],
  };
}

// coins for each board cleared, by its grid
export const BLITZ_COINS = { 9: 25, 12: 35, 16: 45, 20: 60, 25: 75, 30: 95 };

