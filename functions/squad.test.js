// The squad economy's rules (squad.js), no Firebase needed:
//   cd functions && node squad.test.js

const assert = require('assert');
const S = require('./squad');

const ART = S.ROSTER.filter((c) => Number(c.id) < 30).map((c) => c.id); // the 30 with art today
const DAY = '2026-10-06';
const seq = (...xs) => {
  let i = 0;
  return () => xs[i++ % xs.length];
};
// what a move's `set` does to a profile (col.<id> paths included)
function apply(p, set) {
  const out = { ...p, col: { ...(p.col || {}) } };
  Object.entries(set).forEach(([k, v]) => {
    if (k.startsWith('col.')) out.col[k.slice(4)] = v;
    else out[k] = v;
  });
  return out;
}

// roster: 79, ids 0-29 are the current plush 30, every set has members and a reward
assert.strictEqual(S.ROSTER.length, 79);
assert.strictEqual(S.BY_ID['1'].name, 'Mittens');
assert.strictEqual(S.BY_ID['28'].rar, 3); // Boba is Legendary in the new design
S.SETS.forEach((k) => assert.ok(S.SET_OF[k].ids.length >= 3 && S.SET_OF[k].reward, k));

// buying chests
let p = { coins: 1000, gems: 200 };
assert.strictEqual(S.MOVES.buyChest(p, { tier: 'gold', day: DAY }).error, 'not_enough_coins');
let m = S.MOVES.buyChest(p, { tier: 'silver', day: DAY });
assert.deepStrictEqual(m.set, { coins: 400, chestBag: { silver: 1 } });
m = S.MOVES.buyChest(p, { tier: 'crystal', day: DAY });
assert.deepStrictEqual(m.set, { gems: 50, chestBag: { crystal: 1 } });
m = S.MOVES.buyChest(p, { deal: true, day: DAY });
assert.strictEqual(m.set.gems, 95);
assert.strictEqual(m.set.dealDay, DAY);
assert.strictEqual(S.MOVES.buyChest(apply(p, m.set), { deal: true, day: DAY }).error, 'deal_used');

// video chestBag: 3 a day
p = {};
for (let i = 0; i < 3; i++) p = apply(p, S.MOVES.videoChest(p, { day: DAY }).set);
assert.strictEqual(p.chestBag.basic, 3);
assert.strictEqual(S.MOVES.videoChest(p, { day: DAY }).error, 'no_videos_left');
assert.ok(S.MOVES.videoChest(p, { day: '2026-10-07' }).set);

// opening: a Common, new, Normal
p = { chestBag: { basic: 1 } };
m = S.MOVES.openChest(p, { tier: 'basic', artIds: ART, random: seq(0.1, 0, 0.99) });
assert.strictEqual(m.result.rar, 0);
assert.ok(m.result.isNew);
assert.strictEqual(m.result.f, 'n');
assert.strictEqual(m.set.chestBag.basic, 0);
assert.strictEqual(m.set.chestOpens, 1);
assert.deepStrictEqual(m.set.tierPulls, { Common: 1 });
assert.deepStrictEqual(m.set.ownedIds, [m.result.id]);
assert.strictEqual(S.MOVES.openChest(apply(p, m.set), { tier: 'basic', artIds: ART }).error, 'no_chest');

// a duplicate pays Stars; a duplicate Shiny pays double
const id = m.result.id;
p = apply({ chestBag: { basic: 2 } }, m.set);
p.chestBag = { basic: 2 };
let g = S.grant(p, id, 'n');
assert.strictEqual(g.result.stars, S.DUPE[0]);
p = apply(p, S.grant(p, id, 's').set);
assert.strictEqual(S.grant(p, id, 's').result.stars, S.DUPE[0] * 2);

// pity: the 30th Gold chest is a Legendary
p = { chestBag: { gold: 1 }, pity: 29 };
m = S.MOVES.openChest(p, { tier: 'gold', artIds: ART, random: seq(0, 0.5, 0.99) });
assert.strictEqual(m.result.rar, 3);
assert.strictEqual(m.set.pity, 0);
// the epic guarantee
p = { chestBag: { basic: 1 }, epic: 9 };
m = S.MOVES.openChest(p, { tier: 'basic', artIds: ART, random: seq(0, 0.5, 0.99) });
assert.strictEqual(m.result.rar, 2);
assert.strictEqual(m.set.epic, 0);

// season chest: no spooky art yet → nothing to give
assert.strictEqual(S.MOVES.openChest({ chestBag: { season: 1 } }, { tier: 'season', artIds: ART }).error, 'empty_chest');

// finishes in a Rainbow chest are 3× as likely: 0.3 → Golden
m = S.MOVES.openChest({ chestBag: { rainbow: 1 } }, { tier: 'rainbow', artIds: ART, random: seq(0.5, 0, 0.003) });
assert.strictEqual(m.result.f, 'g');

// a set's last member brings its reward and the bonus
const fruit = S.SET_OF.fruit;
const allArt = S.ROSTER.map((c) => c.id);
p = { ownedIds: fruit.ids.slice(0, -1), stars: 0 };
g = S.grant(p, fruit.ids[fruit.ids.length - 1], 'n');
assert.strictEqual(g.result.reward, fruit.reward);
assert.strictEqual(g.set.stars, S.SET_BONUS);
assert.ok(g.set.ownedIds.includes(fruit.reward));
assert.ok(allArt.length);

// buying a creature: coins, Today's Picks 20% off, Stars, Legendaries never
const pk = S.picks({}, ART, DAY);
assert.strictEqual(pk.length, 3);
const pick = pk[0];
const notPick = ART.find((x) => !pk.includes(x) && S.BY_ID[x].rar === 0);
assert.strictEqual(S.creaturePrice({}, notPick, 'coins', ART, DAY), 1500);
assert.strictEqual(S.creaturePrice({}, pick, 'coins', ART, DAY), Math.round((S.COIN_PRICE[S.BY_ID[pick].rar] * 0.8) / 50) * 50);
assert.strictEqual(S.MOVES.buyCreature({ coins: 99999 }, { id: '28', cur: 'coins', artIds: ART, day: DAY }).error, 'not_for_sale');
m = S.MOVES.buyCreature({ stars: 50 }, { id: notPick, cur: 'stars', artIds: ART, day: DAY });
assert.strictEqual(m.set.stars, 10);
assert.ok(m.result.isNew);
assert.strictEqual(S.MOVES.buyCreature({ coins: 99999 }, { id: '40', cur: 'coins', artIds: ART, day: DAY }).error, 'not_for_sale'); // no art yet

// growing: XP (written by the app) and Stars
p = { ownedIds: ['1'], stars: 9, xp: { 1: 120 } };
assert.strictEqual(S.MOVES.grow(p, { id: '1' }).error, 'not_enough_stars');
p.stars = 10;
m = S.MOVES.grow(p, { id: '1' });
assert.strictEqual(m.set['col.1'].st, 1);
p = apply(p, m.set);
assert.strictEqual(S.MOVES.grow(p, { id: '1' }).error, 'need_xp');

// finishes for Stars, equip
p = { ownedIds: ['1'], stars: 200 };
assert.strictEqual(S.finishPrice('1', 's'), 120);
assert.strictEqual(S.finishPrice('1', 'g'), null);
m = S.MOVES.buyFinish(p, { id: '1', f: 's' });
assert.strictEqual(m.set.stars, 80);
p = apply(p, m.set);
assert.strictEqual(p.col['1'].eq, 's');
assert.strictEqual(S.MOVES.equip(p, { id: '1', f: 'n' }).set['col.1'].eq, 'n');
assert.strictEqual(S.MOVES.equip(p, { id: '1', f: 'r' }).error, 'not_owned');

// gems → coins
assert.deepStrictEqual(S.MOVES.swap({ gems: 250, coins: 5 }, { i: 1 }).set, { gems: 0, coins: 5505 });

// the start: 600 gems and 180 Stars, once
let st = S.withStart({ stars: 15 });
assert.deepStrictEqual(st.set, { gems: 600, stars: 195, chestBag: { welcome: 1 } });
assert.deepStrictEqual(S.MOVES.start(st.p).result, { gems: 600, stars: 195 });
assert.deepStrictEqual(S.withStart({ gems: 0 }).set, {});

// the welcome chest: always Mittens, and not for sale
m = S.MOVES.openChest({ chestBag: { welcome: 1 } }, { tier: 'welcome', artIds: ART, random: seq(0.99) });
assert.strictEqual(m.result.id, '1');
assert.ok(m.result.isNew);
assert.strictEqual(S.MOVES.buyChest({ coins: 1e6, gems: 1e6 }, { tier: 'welcome', day: DAY }).error, 'unknown_chest');
assert.deepStrictEqual(S.withStart({ ownedIds: ['1'] }).set.chestBag, undefined);

// the daily gift: once a day; Stars, or a Silver chest
m = S.MOVES.dailyGift({ stars: 1 }, { day: DAY, reward: { kind: 'stars', amount: 99 } });
assert.strictEqual(m.set.stars, 1 + 5 + 20);
assert.strictEqual(S.MOVES.dailyGift({ giftDay: DAY }, { day: DAY }).error, 'gift_used');
assert.deepStrictEqual(S.MOVES.dailyGift({}, { day: DAY, reward: { kind: 'chest' } }).set.chestBag, { silver: 1 });

console.log('squad.test.js: all passed');
