// The Daily Spin's rules (dailySpin.js), no Firebase needed:
//   cd functions && node dailySpin.test.js

const assert = require('assert');
const D = require('./dailySpin');
const { withStart, START } = require('./squad');

const DAY = '2026-10-08';

// the weights cover [0, 1) in slice order
assert.strictEqual(D.WHEEL.reduce((a, w) => a + w.weight, 0), 100);
assert.strictEqual(D.rollWheel(0), 0);
assert.strictEqual(D.rollWheel(0.2199), 0);
assert.strictEqual(D.rollWheel(0.22), 1);
assert.strictEqual(D.rollWheel(0.9899), 6);
assert.strictEqual(D.rollWheel(0.99), 7);
assert.strictEqual(D.rollWheel(0.999999), 7);

// odds over many rolls stay near the weights
const hits = D.WHEEL.map(() => 0);
for (let i = 0; i < 100000; i++) hits[D.rollWheel((i + 0.5) / 100000)]++;
D.WHEEL.forEach((w, i) => assert.strictEqual(hits[i], w.weight * 1000));

// each slice pays its own currency; only 50 gems is the jackpot
for (let i = 0; i < D.WHEEL.length; i++) {
  const { result, changes } = D.spinOutcome({ day: DAY, index: i });
  const w = D.WHEEL[i];
  assert.deepStrictEqual([result.kind, result.amount], [w.kind, w.amount]);
  for (const cur of ['coins', 'gems', 'stars']) assert.strictEqual(changes[cur], cur === w.kind ? w.amount : 0);
  assert.strictEqual(changes.jackpot, w.kind === 'gems' && w.amount === 50);
}

// one free spin a day, then one video spin
assert.deepStrictEqual(D.spinAllowed({}, DAY), { lastSpinDay: DAY });
assert.strictEqual(D.spinAllowed({}, DAY, true), null);
const spun = { lastSpinDay: DAY };
assert.strictEqual(D.spinAllowed(spun, DAY), null);
assert.deepStrictEqual(D.spinAllowed(spun, DAY, true), { adSpins: { day: DAY, n: 1 } });
assert.strictEqual(D.spinAllowed({ ...spun, adSpins: { day: DAY, n: 1 } }, DAY, true), null);
assert.deepStrictEqual(D.spinAllowed({ lastSpinDay: '2026-10-07', adSpins: { day: '2026-10-07', n: 1 } }, DAY), { lastSpinDay: DAY });

// a fresh profile still gets its starting gems before a gems prize
const begun = withStart({ coins: 0 });
assert.strictEqual(begun.p.gems, START.gems);
assert.strictEqual(withStart({ gems: 3 }).p.gems, 3);

console.log('dailySpin.test.js: all passed');
