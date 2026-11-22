// The offer grants (REDESIGN_V6 step 7) and gem packs from config/offers:
// node purchases.test.js
const assert = require('assert');
const P = require('./purchases');
const S = require('./squad');

const ALL = S.ROSTER.map((c) => c.id);
const DAY = '2026-10-20';
const seq = (...xs) => {
  let i = 0;
  return () => xs[i++ % xs.length];
};

// product ids: offers (and their price levels), the old products
assert.strictEqual(P.baseProduct('offer_starter'), 'offer_starter');
assert.strictEqual(P.baseProduct('offer_gem_jar'), 'offer_gem_jar');
assert.strictEqual(P.baseProduct('offer_gem_jar_299'), 'offer_gem_jar');
assert.strictEqual(P.baseProduct('offer_pass_spooky'), 'offer_pass_spooky');
assert.strictEqual(P.baseProduct('gems_450_499'), 'gems_450');
assert.strictEqual(P.baseProduct('offer_'), null);
assert.strictEqual(P.baseProduct('nope'), null);
assert.strictEqual(P.isConsumable('offer_collector'), true);
assert.strictEqual(P.isConsumable('offer_starter'), false);
assert.strictEqual(P.isConsumable('offer_pass_spooky'), false);
assert.strictEqual(P.isConsumable('gems_80'), true);
assert.strictEqual(P.isConsumable('remove_ads'), false);

// a bundle: gems, coins, and its chest rolled at once (of today's first HOT group)
let g = P.grantFor({ productId: 'offer_starter', profile: { gems: 10, coins: 5, totalEarned: 5 }, rosterIds: ALL, artIds: ALL, day: DAY, random: seq(0.5) });
assert.strictEqual(g.result.granted, 'bundle');
assert.strictEqual(g.result.gems, 500);
assert.strictEqual(g.result.chests.length, 1);
assert.strictEqual(g.result.chests[0].group, S.lineup(DAY)[0]);
assert.strictEqual(g.result.chests[0].size, 'epic');
assert.strictEqual(g.update.set.gems, 510);
assert.strictEqual(g.update.set.coins, 5 + 5000 + g.result.chests[0].coins + g.result.chests[0].dupeCoins + g.result.chests[0].setBonus);
assert.deepStrictEqual(g.update.set.offersBought, { starter: true });
// two chests: the first and second HOT groups
g = P.grantFor({ productId: 'offer_mega', profile: {}, rosterIds: ALL, artIds: ALL, day: DAY, random: seq(0.3) });
assert.deepStrictEqual(g.result.chests.map((c) => c.group), S.lineup(DAY).slice(0, 2));
// the jar: its gems, and it starts over
g = P.grantFor({ productId: 'offer_gem_jar', profile: { gems: 1, totalEarned: 2500 }, rosterIds: [] });
assert.strictEqual(g.result.gems, 100);
assert.deepStrictEqual(g.update.set, { gems: 101, jarBase: 2500, offersBought: { jar: true } });
// the pass
g = P.grantFor({ productId: 'offer_pass_spooky', profile: {}, rosterIds: [] });
assert.deepStrictEqual(g.update.set.passPrem, { spooky: true });
// an offer the config switched off, or never had
const off = { ...S.DEFAULT_OFFERS, offers: S.DEFAULT_OFFERS.offers.map((o) => (o.id === 'mega' ? { ...o, enabled: false } : o)) };
assert.strictEqual(P.grantFor({ productId: 'offer_mega', profile: {}, rosterIds: [], offers: off }).error, 'unknown_product');
assert.strictEqual(P.grantFor({ productId: 'offer_nothing', profile: {}, rosterIds: [] }).error, 'unknown_product');
// a config can change what a bundle holds
const rich = { ...S.DEFAULT_OFFERS, offers: [{ id: 'x', kind: 'bundle', product: 'offer_x', gems: 7, coins: 0, chests: [] }] };
assert.strictEqual(P.grantFor({ productId: 'offer_x', profile: {}, rosterIds: [], offers: rich, day: DAY }).update.set.gems, 7);
// a bundle's chests add up copies of the same creature (one art id: both chests pull it)
const twice = { ...S.DEFAULT_OFFERS, offers: [{ id: 'y', kind: 'bundle', product: 'offer_y', gems: 0, coins: 0, chests: ['common', 'common'] }] };
const one = S.ROSTER.find((c) => c.set === S.lineup(DAY)[0] && c.rar === 0).id;
const two = S.ROSTER.find((c) => c.set === S.lineup(DAY)[1] && c.rar === 0).id;
g = P.grantFor({ productId: 'offer_y', profile: { copies: { [one]: 4 } }, rosterIds: [], offers: twice, artIds: [one, two], day: DAY, random: seq(0.99, 0.1, 0.1, 0.5) });
assert.ok(g.result.chests[0].isNew);
assert.strictEqual(g.result.chests[1].copies, 1);
assert.deepStrictEqual(g.update.set.copies, { [two]: 1 });
assert.deepStrictEqual(g.update.set[`col.${one}`], { f: { n: 1 }, eq: 'n', st: 0 });

// gem packs: the config's amount, doubled the first time
g = P.grantFor({ productId: 'gems_450', profile: {}, rosterIds: [] });
assert.strictEqual(g.result.gems, 1000);
g = P.grantFor({ productId: 'gems_450', profile: { gemFirst: { gems_450: true } }, rosterIds: [] });
assert.strictEqual(g.result.gems, 500);
g = P.grantFor({ productId: 'gems_450', profile: { gemFirst: { gems_450: true } }, rosterIds: [], offers: { packs: [{ product: 'gems_450', gems: 600 }] } });
assert.strictEqual(g.result.gems, 600);

console.log('purchases.test.js: all passed');
