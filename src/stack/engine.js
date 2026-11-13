// Squish Stack's puzzle (SQUISH_STACK.md): squishies sitting on cushions,
// a big one never on a smaller one (the Tower of Hanoi). Pure functions: the
// game draws and animates what these say.
//
// A state is where each squishy sits: pos[r] is the cushion of the squishy of
// size r (0 = the smallest). A cushion's stack follows from it, biggest at
// the bottom, so every state is a legal one. With k cushions and n squishies
// there are k^n states: few enough (65,536 at 8 on 4) to work out how far
// every one of them is from the goal, which gives the par, the hint and the
// "stars still possible" meter.

// the squishies on cushion p, bottom (biggest) to top
export function stackOf(pos, p) {
  const s = [];
  for (let r = pos.length - 1; r >= 0; r--) if (pos[r] === p) s.push(r);
  return s;
}

// the squishy on top of cushion p, or -1 for an empty one
export function topOf(pos, p) {
  for (let r = 0; r < pos.length; r++) if (pos[r] === p) return r;
  return -1;
}

// Can the top squishy of `from` go onto `to`? Its size, or -1.
export function canMove(pos, from, to) {
  if (from === to) return -1;
  const r = topOf(pos, from);
  if (r < 0) return -1;
  const t = topOf(pos, to);
  return t < 0 || t > r ? r : -1;
}

export const same = (a, b) => a.length === b.length && a.every((v, i) => v === b[i]);

// How far every state is from `goal` (a breadth-first search out from the
// goal; a move undoes itself, so the distance back is the distance there).
// { dist (Int16Array by code), enc (pos → code), n, k }
export function solve(n, k, goal) {
  const N = k ** n;
  const pw = Array.from({ length: n }, (_, i) => k ** i);
  const enc = (p) => {
    let s = 0;
    for (let i = 0; i < n; i++) s += p[i] * pw[i];
    return s;
  };
  const dist = new Int16Array(N).fill(-1);
  const q = new Int32Array(N);
  let head = 0;
  let tail = 0;
  const g = enc(goal);
  dist[g] = 0;
  q[tail++] = g;
  const top = new Array(k);
  while (head < tail) {
    const s = q[head++];
    top.fill(n);
    // the smallest squishy on each cushion is its top: walk from the biggest
    for (let i = n - 1; i >= 0; i--) top[Math.floor(s / pw[i]) % k] = i;
    for (let a = 0; a < k; a++) {
      const r = top[a];
      if (r === n) continue;
      for (let b = 0; b < k; b++) {
        if (b === a || top[b] < r) continue;
        const ns = s + (b - a) * pw[r];
        if (dist[ns] < 0) {
          dist[ns] = dist[s] + 1;
          q[tail++] = ns;
        }
      }
    }
  }
  return { dist, enc, n, k };
}

// moves left from `pos` to the goal it was solved for
export const left = (sol, pos) => sol.dist[sol.enc(pos)];

// One move that brings `pos` a step closer: [r, from, to], or null when
// it's already there.
export function bestMove(sol, pos) {
  const d = left(sol, pos);
  if (d <= 0) return null;
  for (let from = 0; from < sol.k; from++) {
    for (let to = 0; to < sol.k; to++) {
      const r = canMove(pos, from, to);
      if (r < 0) continue;
      const next = pos.slice();
      next[r] = to;
      if (left(sol, next) === d - 1) return [r, from, to];
    }
  }
  return null;
}

const pick = (rand, n) => Math.floor(rand() * n);

// A goal picture: at least two cushions used, never everyone on one.
function pictureGoal(n, k, rand) {
  for (;;) {
    const g = Array.from({ length: n }, () => pick(rand, k));
    if (new Set(g).size >= 2) return g;
  }
}

// A level's puzzle: { start, goal, star, par, sol }.
//   spec.start  'tower' (everyone on the first cushion, the classic) or
//               'scrambled' (anywhere, `par` moves from the goal)
//   spec.goal   'star' (everyone on one cushion, `star`) or 'picture'
//   spec.par    [lo, hi]: how many moves the best answer takes
// A scrambled start is drawn from every state whose answer is in the range
// (widened a move at a time if none is), never the goal itself.
export function makePuzzle(spec, rand = Math.random) {
  const { n, k } = spec;
  if (spec.start === 'tower') {
    const goal = Array(n).fill(k - 1);
    const sol = solve(n, k, goal);
    const start = Array(n).fill(0);
    return { start, goal, star: k - 1, par: left(sol, start), sol };
  }
  const star = spec.goal === 'picture' ? -1 : pick(rand, k);
  const goal = star >= 0 ? Array(n).fill(star) : pictureGoal(n, k, rand);
  const sol = solve(n, k, goal);
  let [lo, hi] = spec.par;
  for (let widen = 0; widen < 40; widen++) {
    const fits = [];
    for (let s = 0; s < sol.dist.length; s++) if (sol.dist[s] >= Math.max(1, lo) && sol.dist[s] <= hi) fits.push(s);
    if (fits.length) {
      const s = fits[pick(rand, fits.length)];
      const start = Array.from({ length: n }, (_, i) => Math.floor(s / k ** i) % k);
      return { start, goal, star, par: sol.dist[s], sol };
    }
    lo -= 1;
    hi += 1;
  }
  throw new Error(`no start for ${n} on ${k}`);
}
