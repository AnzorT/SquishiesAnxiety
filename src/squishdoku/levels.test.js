// node src/squishdoku/levels.test.js: the 600 fixed levels (levelData.js).
import assert from 'node:assert/strict';
import { conflicts, countSolutions, grade } from './engine.js';
import { CHAPTER, CHAPTERS, HEARTS, HEARTS_FROM, LEVELS, LEVEL_LIST, chapterOf, levelSpec, record, stageOf, tierOfEffort } from './levels.js';
import { shapeFits } from '../../tools/squishdoku/shape.mjs';

let n = 0;
const ok = (name, fn) => {
  fn();
  n++;
  console.log(`ok - ${name}`);
};

ok('600 levels in 30 chapters of 20', () => {
  assert.equal(LEVELS, 600);
  assert.equal(CHAPTERS, 30);
  assert.equal(chapterOf(1), 1);
  assert.equal(chapterOf(20), 1);
  assert.equal(chapterOf(21), 2);
  assert.equal(chapterOf(600), 30);
});

ok('every board has one answer, its stored one, and the grader solves it by logic', () => {
  for (let lv = 1; lv <= LEVELS; lv++) {
    const { puzzle: p, effort, n: size } = levelSpec(lv);
    assert.equal(p.n, size);
    assert.equal(p.regions.length, size * size, `level ${lv} regions`);
    assert.equal(new Set(p.regions).size, size, `level ${lv}: ${size} patches`);
    assert.equal(countSolutions(size, p.regions, 2), 1, `level ${lv}: one answer`);
    const cells = p.solution.map((c, r) => r * size + c);
    assert.equal(conflicts(size, p.regions, cells).size, 0, `level ${lv}: stored answer breaks a rule`);
    const g = grade(size, p.regions);
    assert.ok(g.solved, `level ${lv}: not solvable by logic`);
    assert.deepEqual(g.solution, p.solution, `level ${lv}: grader's answer`);
    assert.equal(g.effort, effort, `level ${lv}: effort`);
    assert.equal(new Set(p.colors).size, size, `level ${lv}: patch colours`);
  }
});

ok('no board twice', () => {
  const seen = new Set();
  for (let lv = 1; lv <= LEVELS; lv++) {
    const key = levelSpec(lv).puzzle.regions.join('');
    assert.ok(!seen.has(key), `level ${lv} repeats a board`);
    seen.add(key);
  }
});

ok('sizes rise 4×4 → 9×9; every chapter from 8 on is mostly 9×9 and harder than the one before', () => {
  assert.equal(LEVEL_LIST[0].n, 4);
  assert.equal(LEVEL_LIST[599].n, 9);
  const median = (xs) => xs.slice().sort((a, b) => a - b)[xs.length >> 1];
  let last = -1;
  for (let c = 8; c <= CHAPTERS; c++) {
    const part = LEVEL_LIST.slice((c - 1) * CHAPTER, c * CHAPTER);
    assert.ok(part.filter((x) => x.n === 9).length >= 15, `chapter ${c}`);
    const m = median(part.filter((x) => x.n === 9).map((x) => x.effort));
    assert.ok(m >= last, `chapter ${c}: median effort ${m} < ${last}`);
    last = m;
  }
  assert.ok(last >= 28, `the last chapter is hard (median ${last})`);
  assert.ok(LEVEL_LIST[599].effort >= 36, `level 600 is the hardest boss (${LEVEL_LIST[599].effort})`);
  assert.equal(tierOfEffort(LEVEL_LIST[599].effort), 5, 'level 600 is LEGEND');
});

ok('every 9×9 (climbed or plain) keeps plain-looking patches', () => {
  let hard = 0;
  for (let lv = 1; lv <= LEVELS; lv++) {
    const { puzzle: p, effort } = levelSpec(lv);
    if (p.n !== 9) continue;
    // the plain maker's top 0.1% is 25: past that they're climbed
    if (effort >= 26) hard++;
    assert.ok(shapeFits(9, p.regions), `level ${lv}: snaky patches`);
  }
  assert.ok(hard >= 60, `${hard} boards past effort 25`);
});

ok(`${HEARTS} hearts from level ${HEARTS_FROM} (the first 7×7), free mistakes before`, () => {
  assert.equal(levelSpec(HEARTS_FROM - 1).hearts, 0);
  assert.equal(levelSpec(HEARTS_FROM).hearts, HEARTS);
  assert.equal(levelSpec(HEARTS_FROM).n, 7);
  assert.equal(levelSpec(600).hearts, HEARTS);
});

ok('the clock stops growing at effort 30 (2.5 ×)', () => {
  const top = LEVEL_LIST.findIndex((x) => x.n === 9 && x.effort > 30) + 1;
  assert.ok(top > 0, 'a 9×9 past effort 30');
  assert.equal(levelSpec(top).limitMs, 1050 * 1000); // 420 s × 2.5
});

ok('a chapter is one room; time moves on through it', () => {
  assert.equal(stageOf(1).room, 'living');
  assert.equal(stageOf(20).room, 'living');
  assert.equal(stageOf(21).room, 'kitchen');
  assert.equal(stageOf(121).room, 'living');
  assert.equal(stageOf(1).phase, 'morning');
  assert.equal(stageOf(20).phase, 'night');
});

ok('clocks grow with effort; HEAD START is shorter', () => {
  const easy = levelSpec(131);
  const hard = levelSpec(600);
  assert.equal(easy.n, hard.n);
  assert.ok(hard.limitMs > easy.limitMs);
  assert.ok(hard.aMs < hard.bMs && hard.bMs < hard.limitMs);
  assert.ok(levelSpec(600, true).limitMs < hard.limitMs);
});

ok('players keep their level number (up to 600)', () => {
  assert.equal(record({ sdk: { lv: 37 } }).lv, 37);
  assert.equal(record({ sdk: { lv: 9999 } }).lv, 600);
});

console.log(`\n${n} passed`);
