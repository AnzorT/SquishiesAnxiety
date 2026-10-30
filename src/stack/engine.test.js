// node src/stack/engine.test.js — Squish Stack's puzzle, levels and scoring.
import assert from 'node:assert/strict';
import { bestMove, canMove, left, makePuzzle, same, solve, stackOf, topOf } from './engine.js';
import { BLITZ_COINS, BLITZ_ROUNDS, CLOCK_FROM, LEVELS, LEVEL_LIST, PICTURE_FROM, afterBlitz, afterLevel, blitzSpec, coinsFor, levelSpec, limitFor, nextSkill, record, starsFor, twoStarMoves, xpFor } from './levels.js';

// a seeded random
const rng = (seed) => () => {
  seed = (seed * 16807) % 2147483647;
  return (seed - 1) / 2147483646;
};

// stacks: biggest at the bottom, the smallest on top
const pos = [2, 0, 2, 0]; // sizes 0 and 2 on cushion 2, 1 and 3 on cushion 0
assert.deepEqual(stackOf(pos, 0), [3, 1]);
assert.deepEqual(stackOf(pos, 2), [2, 0]);
assert.equal(topOf(pos, 0), 1);
assert.equal(topOf(pos, 1), -1);
// the 1 can go on the empty cushion, not on the 0; the 0 can go anywhere
assert.equal(canMove(pos, 0, 1), 1);
assert.equal(canMove(pos, 0, 2), -1);
assert.equal(canMove(pos, 2, 0), 0);
assert.equal(canMove(pos, 1, 0), -1); // nothing to move
assert.equal(canMove(pos, 0, 0), -1);

// the classic towers take 2^n - 1 moves on 3 cushions, and the known
// Frame-Stewart numbers on 4
const tower = (n, k) => left(solve(n, k, Array(n).fill(k - 1)), Array(n).fill(0));
assert.equal(tower(3, 3), 7);
assert.equal(tower(4, 3), 15);
assert.equal(tower(5, 3), 31);
assert.equal(tower(5, 4), 13);
assert.equal(tower(6, 4), 17);
assert.equal(tower(8, 4), 33);

// every state can reach every goal, and following the hint gets there in
// exactly the par
for (const [n, k] of [[4, 3], [6, 4]]) {
  const R = rng(n * 10 + k);
  for (let t = 0; t < 30; t++) {
    const goal = Array.from({ length: n }, () => Math.floor(R() * k));
    const sol = solve(n, k, goal);
    assert.ok(sol.dist.every((d) => d >= 0), `${n}×${k} all reachable`);
    let p = Array.from({ length: n }, () => Math.floor(R() * k));
    const par = left(sol, p);
    let steps = 0;
    for (let m = bestMove(sol, p); m; m = bestMove(sol, p)) {
      const [r, from, to] = m;
      assert.equal(canMove(p, from, to), r);
      p = p.slice();
      p[r] = to;
      steps++;
    }
    assert.ok(same(p, goal));
    assert.equal(steps, par);
  }
}

// levels: 50, never shrinking; the classic towers where they belong
assert.equal(LEVELS, 50);
assert.equal(LEVEL_LIST.length, 50);
for (let lv = 2; lv <= LEVELS; lv++) {
  assert.ok(LEVEL_LIST[lv - 1].n >= LEVEL_LIST[lv - 2].n && LEVEL_LIST[lv - 1].k >= LEVEL_LIST[lv - 2].k, lv);
}
assert.deepEqual([levelSpec(1).n, levelSpec(1).k, levelSpec(1).start, levelSpec(1).tier], [3, 3, 'tower', 0]);
assert.equal(levelSpec(4).start, 'tower');
assert.equal(levelSpec(22).k, 4);
assert.equal(levelSpec(22).news, 'cushion');
assert.equal(levelSpec(PICTURE_FROM).news, 'picture');
assert.equal(levelSpec(CLOCK_FROM).news, 'clock');
assert.equal(levelSpec(50).n, 8);
for (let lv = 1; lv < PICTURE_FROM; lv++) for (const s of [-2, 0, 2]) assert.equal(levelSpec(lv, s).goal, 'star', lv);
for (let lv = 1; lv <= LEVELS; lv++) {
  assert.equal(levelSpec(lv).clock, lv >= CLOCK_FROM, lv);
  for (const skill of [-2, 0, 2]) {
    const s = levelSpec(lv, skill);
    assert.ok(s.tier >= 0 && s.tier <= 3);
    assert.ok(Math.abs(s.tier - s.baseTier) <= 1);
    // a puzzle comes out, close to the asked par, never already solved
    const P = makePuzzle(s, rng(lv * 7 + skill + 3));
    assert.ok(P.par >= 1, `lv ${lv} not solved already`);
    assert.equal(left(P.sol, P.start), P.par);
    if (s.start === 'scrambled') assert.ok(P.par >= s.par[0] - 3 && P.par <= s.par[1], `lv ${lv} skill ${skill} par ${P.par} vs ${s.par}`);
    if (s.goal === 'picture') assert.ok(new Set(P.goal).size >= 2, lv);
    else assert.ok(P.goal.every((g) => g === P.star), lv);
    if (s.clock) assert.ok(limitFor(s, P.par) >= 20000 + P.par * 2500, lv);
    else assert.equal(limitFor(s, P.par), 0);
  }
}
// adaptive: a high skill asks for more, a low one for less
assert.ok(levelSpec(20, 2).tier >= levelSpec(20, 0).tier);
assert.ok(levelSpec(20, -2).tier <= levelSpec(20, 0).tier);

// stars: the par for 3, a few over for 2; a hint takes one off but never the last
assert.equal(starsFor(7, { moves: 7 }), 3);
assert.equal(starsFor(7, { moves: 8 }), 2);
assert.equal(starsFor(7, { moves: twoStarMoves(7) }), 2);
assert.equal(starsFor(7, { moves: twoStarMoves(7) + 1 }), 1);
assert.equal(starsFor(7, { moves: 7, hinted: true }), 2);
assert.equal(starsFor(7, { moves: 99, hinted: true }), 1);
assert.ok(coinsFor(levelSpec(30), 12, 3) > coinsFor(levelSpec(30), 12, 1));
assert.ok(nextSkill(0, { won: true, stars: 3 }) > 0);
assert.ok(nextSkill(0, { won: false }) < 0);
assert.ok(nextSkill(0, { won: true, stars: 3, hinted: true }) < nextSkill(0, { won: true, stars: 3 }));

// the record: a win on the current level opens the next
const profile = { stack: { lv: 3, best: { 1: 3, 2: 2 }, skill: 0.4, plays: 5, wins: 2 } };
assert.equal(record(profile).lv, 3);
assert.equal(record({}).lv, 1);
const out = afterLevel(profile, levelSpec(3), 7, { won: true, moves: 7, hinted: false });
assert.equal(out.stars, 3);
assert.equal(out.update['stack.lv'], 4);
assert.equal(out.update['stack.best.3'], 3);
assert.equal(out.update['stack.wins'], 3);
assert.ok(out.coins > 0 && out.unlocked);
// a replay of an old level opens nothing, and a worse result keeps the best
const old = afterLevel(profile, levelSpec(1), 7, { won: true, moves: 30 });
assert.equal(old.update['stack.lv'], undefined);
assert.equal(old.update['stack.best.1'], undefined);
const lost = afterLevel(profile, levelSpec(3), 7, { won: false });
assert.equal(lost.coins, 0);
assert.equal(lost.update['stack.plays'], 6);

// Blitz: ten puzzles, never shrinking, each one close to its par range, and
// never already solved; the run's record
assert.equal(BLITZ_ROUNDS, 10);
for (let i = 0; i < BLITZ_ROUNDS; i++) {
  for (const skill of [-2, 0, 2]) {
    const s = blitzSpec(i, skill);
    if (i > 0) assert.ok(s.n >= blitzSpec(i - 1, skill).n && s.k >= blitzSpec(i - 1, skill).k, i);
    assert.equal(s.clock, false);
    const P = makePuzzle(s, rng(i * 13 + skill + 5));
    assert.ok(P.par >= 1, `blitz ${i} not solved already`);
    assert.ok(P.par >= s.par[0] - 3 && P.par <= s.par[1], `blitz ${i} skill ${skill} par ${P.par} vs ${s.par}`);
  }
}
assert.ok(blitzSpec(9, 2).par[0] > blitzSpec(9, -2).par[0]);
const lostRun = afterBlitz(profile, { won: false, reached: 4 });
assert.equal(lostRun.coins, 0);
assert.equal(lostRun.update['stack.blitz.reached'], 4);
assert.ok(lostRun.update['stack.bSkill'] < 0);
const wonRun = afterBlitz({ stack: { blitz: { reached: 10, bestMs: 200000, wins: 1 } } }, { won: true, reached: 10, ms: 150000 });
assert.equal(wonRun.coins, BLITZ_COINS);
assert.equal(wonRun.update['stack.blitz.wins'], 2);
assert.equal(wonRun.update['stack.blitz.bestMs'], 150000);
const slowRun = afterBlitz({ stack: { blitz: { reached: 10, bestMs: 100000, wins: 1 } } }, { won: true, reached: 10, ms: 150000 });
assert.equal(slowRun.update['stack.blitz.bestMs'], undefined);

// the player's XP: all of it on a first win, half on a replay; a hint's lost star costs some
{
  const spec = levelSpec(20);
  const first = afterLevel({ pxp: 0 }, spec, 9, { won: true, moves: 9, hinted: false });
  assert.equal(first.xp, xpFor(spec, 3));
  const again = afterLevel({ pxp: 0, stack: { lv: 21, best: { 20: 3 } } }, spec, 9, { won: true, moves: 9, hinted: false });
  assert.equal(again.xp, Math.round(xpFor(spec, 3) / 2));
  assert.ok(afterLevel({ pxp: 0 }, spec, 9, { won: true, moves: 9, hinted: true }).xp < first.xp);
  assert.equal(afterBlitz({ pxp: 0 }, { won: true, reached: 10, ms: 1000 }).xp, 200);
  assert.equal(afterBlitz({ pxp: 0 }, { won: false, reached: 3 }).xp, 0);
}

console.log('stack: all good');
