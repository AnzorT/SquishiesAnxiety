// The Daily Spin's rules (dailySpin.js), no Firebase needed:
//   cd functions && node dailySpin.test.js

const assert = require('assert');
const D = require('./dailySpin');
const { withStart, START, lineup, BY_ID } = require('./squad');

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
  const w = D.WHEEL[i];
  if (w.kind === 'chest') continue;
  const { result, changes } = D.spinOutcome({ day: DAY, index: i });
  assert.deepStrictEqual([result.kind, result.amount], [w.kind, w.amount]);
  for (const cur of ['coins', 'gems']) assert.strictEqual(changes[cur], cur === w.kind ? w.amount : 0);
  assert.strictEqual(changes.jackpot, w.kind === 'gems' && w.amount === 50);
  assert.strictEqual(changes.set, null);
}

// one slice is a Common chest (2026-11-17, in the 150 coins slice's place):
// today's first HOT group's, opened at once, paying no coins or gems itself
const CHEST = D.WHEEL.findIndex((w) => w.kind === 'chest');
assert.strictEqual(CHEST, 3);
assert.strictEqual(D.WHEEL.filter((w) => w.kind === 'chest').length, 1);
assert.ok(D.isChest(CHEST) && !D.isChest(0));
const group = lineup(DAY)[0];
const artIds = Object.keys(BY_ID).filter((id) => BY_ID[id].set === group);
assert.ok(artIds.length > 0);
const p0 = withStart({ coins: 40, ownedIds: [] }).p;
const c = D.spinOutcome({ day: DAY, index: CHEST, p: p0, chestArgs: { artIds } });
assert.deepStrictEqual([c.result.kind, c.result.amount, c.result.size], ['chest', 1, 'common']);
assert.strictEqual(c.result.chest.group, group);
assert.strictEqual(c.result.chest.size, 'common');
assert.ok(artIds.includes(c.result.chest.id));
assert.strictEqual(c.result.chest.copies, 1); // (a first copy toward unlocking it)
assert.deepStrictEqual([c.changes.coins, c.changes.gems, c.changes.jackpot], [0, 0, false]);
assert.strictEqual(c.changes.set.chestOpens, 1);
assert.strictEqual(c.changes.set.coins, 40);

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
