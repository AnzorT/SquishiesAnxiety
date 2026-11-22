// node src/squishdoku/engine.test.js — every board the maker keeps has one
// answer that keeps the rules, and how long boards take to make per size.
import assert from 'node:assert/strict';
import { conflicts, countSolutions, grade, makePuzzle, puzzleMaker, randomSolution, rng } from './engine.js';

// the creatures never touch and use every row and column once
for (let n = 4; n <= 9; n++) {
  for (let seed = 1; seed <= 30; seed++) {
    const sol = randomSolution(n, rng(seed));
    assert.equal(new Set(sol).size, n);
    for (let r = 1; r < n; r++) assert.ok(Math.abs(sol[r] - sol[r - 1]) >= 2);
  }
}
assert.equal(randomSolution(3, rng(1)), null);

// a hand-made 4×4: patches are rows 0-1 split down the middle, and so on
{
  const n = 4;
  const regions = [0, 0, 1, 1, 0, 2, 2, 1, 3, 2, 2, 1, 3, 3, 3, 3];
  const g = grade(n, regions);
  if (g.solved) assert.equal(countSolutions(n, regions), 1);
}

// conflicts: same row, same patch, touching corners
{
  const regions = new Array(16).fill(0).map((_, i) => i % 4);
  assert.deepEqual([...conflicts(4, regions, [0, 2])].sort(), [0, 2]); // row
  assert.deepEqual([...conflicts(4, regions, [0, 5])].sort(), [0, 5]); // corner
  assert.equal(conflicts(4, regions.map((_, i) => Math.floor(i / 4) * 4 + (i % 4)), [1, 7]).size, 0);
}

// every size and tier: one answer, it's the grader's, and the time it takes
const stats = [];
for (let n = 4; n <= 9; n++) {
  for (let tier = 0; tier <= 3; tier++) {
    const runs = n >= 8 ? 6 : 10;
    let ms = 0;
    let worst = 0;
    let hit = 0;
    let tries = 0;
    for (let i = 0; i < runs; i++) {
      const seed = 1000 * n + 100 * tier + i;
      const t0 = Date.now();
      const m = puzzleMaker({ n, tier, seed });
      let p = null;
      while (!(p = m.run(50)));
      const dt = Date.now() - t0;
      ms += dt;
      worst = Math.max(worst, dt);
      tries += m.tries;
      if (p.tier === tier) hit++;
      assert.equal(countSolutions(n, p.regions), 1, `n=${n} seed=${seed} has more than one answer`);
      const cells = p.solution.map((c, r) => r * n + c);
      assert.equal(conflicts(n, p.regions, cells).size, 0);
      assert.equal(new Set(cells.map((cell) => p.regions[cell])).size, n);
      // the same seed makes the same board
      assert.deepEqual(makePuzzle({ n, tier, seed }).regions, p.regions);
    }
    stats.push(`${n}x${n} ${['easy', 'medium', 'hard', 'expert'][tier].padEnd(6)}  hit ${hit}/${runs}  avg ${(ms / runs).toFixed(0).padStart(5)} ms  worst ${String(worst).padStart(5)} ms  tries ${(tries / runs).toFixed(0)}`);
  }
}
console.log(stats.join('\n'));
console.log('engine ok');
