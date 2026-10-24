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

// roster: the 2026-10-19 design's 86 in 11 groups
assert.strictEqual(S.ROSTER.length, 86);
assert.strictEqual(S.GROUPS.length, 11);
assert.strictEqual(S.BY_ID['1'].name, 'Mittens');
assert.strictEqual(S.BY_ID['28'].rar, 3); // Boba is Legendary in the new design
assert.strictEqual(S.BY_ID['59'].key, 'ember'); // renamed Flicker, same art
S.ROSTER.forEach((c) => assert.ok(S.GROUPS.some((g) => g.key === c.set), c.name));
S.SETS.filter((k) => k !== 'dream').forEach((k) => assert.ok(S.SET_OF[k].ids.length >= 3 && S.SET_OF[k].reward, k));
assert.strictEqual(S.SET_OF.dream.reward, null); // Jinni is a Legendary now
assert.deepStrictEqual(S.SET_OF.elemental.ids, ['80', '81', '82', '83', '84', '85']);
// Ids are permanent (the collection is keyed by them): this list only ever
// grows at the end. Never edit an entry in it.
const KEYS_BY_ID = [
  'nimbo', 'mittens', 'mallow', 'bao', 'dunkie', 'frybo', 'pip', 'bunbun', 'jelli', 'pina', 'finn', 'sealy',
  'biscuit', 'hana', 'choco', 'prickle', 'lumi', 'kiko', 'bubbly', 'twinkle', 'zappi', 'scoop', 'teddy',
  'hoot', 'leo', 'nibbles', 'quill', 'panko', 'boba', 'avo', 'berri', 'lemmy', 'kiwi', 'melo', 'peachy',
  'pitaya', 'tutti', 'puff', 'shelly', 'octo', 'marina', 'pearl', 'waffles', 'poppy', 'duchess', 'mamapaws',
  'acorn', 'fawn', 'moss', 'sprout', 'plip', 'breeze', 'dusty', 'aurora', 'boo', 'pixie', 'floof', 'unibun',
  'gumdrop', 'ember', 'drako', 'jinni', 'cuppy', 'chip', 'twisty', 'crois', 'maca', 'puddi', 'mochi',
  'cakey', 'sugarplum', 'chefbun', 'gourdy', 'batty', 'kernel', 'hexie', 'mumbles', 'hocus',
  'countsquishula', 'wisecrack', 'gigagrowth', 'crystalline', 'aeroswift', 'phantasm', 'magmara',
  'chronoshade',
];
assert.deepStrictEqual(S.ROSTER.slice(0, KEYS_BY_ID.length).map((c) => c.key), KEYS_BY_ID);
assert.deepStrictEqual(S.ROSTER.map((c) => c.id), S.ROSTER.map((c, i) => String(i)));
assert.strictEqual(new Set(S.ROSTER.map((c) => c.key)).size, S.ROSTER.length);

// buying chests
let p = { coins: 1000, gems: 200 };
let g;
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

// copies: Common 5, Rare 10, Epic 12, Legendary 14, Rainbow (set rewards) 15
assert.deepStrictEqual(S.COPIES, [5, 10, 12, 14, 15]);
assert.deepStrictEqual(S.ROSTER.filter((c) => c.reward).map((c) => S.needOf(c)), S.ROSTER.filter((c) => c.reward).map(() => 15));
assert.deepStrictEqual(S.copiesOf({ copies: [1, 2, 3, 4, 5] }), [1, 2, 3, 4, 5]);
assert.deepStrictEqual(S.copiesOf({ copies: [1, 2] }), S.COPIES);
assert.deepStrictEqual(S.copiesOf({ copies: [0, 2, 3, 4, 5] }), S.COPIES);
// one short of a creature's count
const ready = (id, n = S.needOf(S.BY_ID[id]) - 1) => ({ [id]: n });

// opening: a Common, Normal: its first copy, not in the squad yet
p = { chestBag: { basic: 1 } };
m = S.MOVES.openChest(p, { tier: 'basic', artIds: ART, random: seq(0.1, 0, 0.99) });
assert.strictEqual(m.result.rar, 0);
assert.strictEqual(m.result.isNew, false);
assert.strictEqual(m.result.copies, 1);
assert.strictEqual(m.result.need, 5);
assert.strictEqual(m.result.f, 'n');
assert.strictEqual(m.set.chestBag.basic, 0);
assert.strictEqual(m.set.chestOpens, 1);
assert.deepStrictEqual(m.set.tierPulls, { Common: 1 });
assert.deepStrictEqual(m.set.copies, { [m.result.id]: 1 });
assert.strictEqual(m.set.ownedIds, undefined);
assert.strictEqual(Object.keys(m.set).some((k) => k.startsWith('col.')), false);
assert.strictEqual(S.MOVES.openChest(apply(p, m.set), { tier: 'basic', artIds: ART }).error, 'no_chest');
const id = m.result.id;
// copies 2-4, then the 5th unlocks it and leaves the copies list
p = apply(p, m.set);
for (let n = 2; n <= 4; n++) {
  g = S.grant(p, id, 'n');
  assert.strictEqual(g.result.copies, n);
  assert.strictEqual(g.result.isNew, false);
  p = apply(p, g.set);
}
p.copies = { ...p.copies, 99: 3 };
g = S.grant(p, id, 'n');
assert.ok(g.result.isNew);
assert.strictEqual(g.result.copies, 5);
assert.deepStrictEqual(g.set.ownedIds, [id]);
assert.deepStrictEqual(g.set[`col.${id}`], { f: { n: 1 }, eq: 'n', st: 0 });
assert.deepStrictEqual(g.set.copies, { 99: 3 });
// config/roster's counts
assert.strictEqual(S.grant({}, id, 'n', S.DUPE, false, { need: [1, 1, 1, 1, 1] }).result.isNew, true);

// a duplicate pays coins; a duplicate Shiny pays double
p = { chestBag: { basic: 2 }, ownedIds: [id], coins: 7 };
g = S.grant(p, id, 'n');
assert.strictEqual(g.result.coins, S.DUPE[0]);
assert.strictEqual(g.set.coins, 7 + S.DUPE[0]);
p = apply(p, S.grant(p, id, 's').set);
assert.strictEqual(S.grant(p, id, 's').result.coins, S.DUPE[0] * 2);

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

// with set rewards on, a set's last member brings its reward and the bonus
const fruit = S.SET_OF.fruit;
const allArt = S.ROSTER.map((c) => c.id);
p = { ownedIds: fruit.ids.slice(0, -1), coins: 0, copies: ready(fruit.ids[fruit.ids.length - 1]) };
// for now (SET_REWARDS off, config/roster's setRewards) it brings nothing extra
assert.strictEqual(S.SET_REWARDS, false);
assert.strictEqual(S.setRewardsOf(null), false);
assert.strictEqual(S.setRewardsOf({ setRewards: true }), true);
assert.strictEqual(S.setRewardsOf({ setRewards: 'yes' }), false);
g = S.grant(p, fruit.ids[fruit.ids.length - 1], 'n');
assert.strictEqual(g.result.reward, null);
assert.strictEqual(g.result.coins, 0);
assert.ok(!g.set.ownedIds.includes(fruit.reward));
g = S.grant(p, fruit.ids[fruit.ids.length - 1], 'n', S.DUPE, true);
assert.strictEqual(g.result.reward, fruit.reward);
assert.strictEqual(g.set.coins, S.SET_BONUS);
assert.strictEqual(g.result.coins, S.SET_BONUS);
assert.ok(g.set.ownedIds.includes(fruit.reward));
assert.ok(allArt.length);
// a group with no reward (Dreamland) completes without one
const dream = S.SET_OF.dream;
g = S.grant({ ownedIds: dream.ids.slice(0, -1), coins: 0, copies: ready(dream.ids[dream.ids.length - 1]) }, dream.ids[dream.ids.length - 1], 'n', S.DUPE, true);
assert.strictEqual(g.result.reward, null);
assert.strictEqual(g.result.coins, 0);

// no squishy is sold for coins: chest copies are the only way in
assert.strictEqual(S.MOVES.buyCreature, undefined);
assert.strictEqual(S.creaturePrice, undefined);
assert.strictEqual(S.picks, undefined);

// growing: XP only (written by the app)
p = { ownedIds: ['1'], xp: { 1: 99 } };
assert.strictEqual(S.MOVES.grow(p, { id: '1' }).error, 'need_xp');
p.xp = { 1: 120 };
m = S.MOVES.grow(p, { id: '1' });
assert.deepStrictEqual(Object.keys(m.set), ['col.1']);
assert.strictEqual(m.set['col.1'].st, 1);
p = apply(p, m.set);
assert.strictEqual(S.MOVES.grow(p, { id: '1' }).error, 'need_xp');

// finishes come from chests only; equip one you own
assert.strictEqual(S.MOVES.buyFinish, undefined);
p = apply({ ownedIds: ['1'] }, S.grant({ ownedIds: ['1'] }, '1', 's').set);
assert.strictEqual(S.MOVES.equip(p, { id: '1', f: 's' }).set['col.1'].eq, 's');
p = apply(p, S.MOVES.equip(p, { id: '1', f: 's' }).set);
assert.strictEqual(p.col['1'].eq, 's');
assert.strictEqual(S.MOVES.equip(p, { id: '1', f: 'n' }).set['col.1'].eq, 'n');
assert.strictEqual(S.MOVES.equip(p, { id: '1', f: 'r' }).error, 'not_owned');

// gems → coins
assert.deepStrictEqual(S.MOVES.swap({ gems: 250, coins: 5 }, { i: 1 }).set, { gems: 50, coins: 9005 });

// the start: 600 gems, once
let st = S.withStart({});
assert.deepStrictEqual(st.set, { gems: 600 });
assert.deepStrictEqual(S.MOVES.start(st.p).result, { gems: 600 });
assert.deepStrictEqual(S.withStart({ gems: 0 }).set, {});

// the old welcome chest (a pre-v6 bag): always Mittens, and not for sale
m = S.MOVES.openChest({ chestBag: { welcome: 1 } }, { tier: 'welcome', artIds: ART, random: seq(0.99) });
assert.strictEqual(m.result.id, '1');
assert.ok(m.result.isNew);
assert.strictEqual(S.MOVES.buyChest({ coins: 1e6, gems: 1e6 }, { tier: 'welcome', day: DAY }).error, 'unknown_chest');

// the daily gift: once a day; the streak day's gems (up to 20), or an extra free chest
m = S.MOVES.dailyGift({ gems: 1 }, { day: DAY, reward: { kind: 'gems', amount: 99 } });
assert.strictEqual(m.set.gems, 1 + 20);
assert.deepStrictEqual(S.MOVES.dailyGift({ gems: 1 }, { day: DAY, reward: { kind: 'coins', amount: 100 } }).set, { giftDay: DAY });
assert.strictEqual(S.MOVES.dailyGift({ giftDay: DAY }, { day: DAY }).error, 'gift_used');
m = S.MOVES.dailyGift({ freeBonus: 1 }, { day: DAY, reward: { kind: 'chest' } });
assert.strictEqual(m.set.freeBonus, 2);
assert.strictEqual(m.set.chestBag, undefined);

// --- v6 group chests (REDESIGN_V6 step 5) ---
const ALL = S.ROSTER.map((c) => c.id);
const NOW = Date.parse('2026-10-20T12:00:00Z');
const D20 = '2026-10-20';
// the lineup: three of the ten non-season groups, the same for one day, changing by day
const L20 = S.lineup(D20);
assert.strictEqual(L20.length, 3);
assert.ok(L20.every((k) => k !== 'spooky' && S.GROUPS.some((g) => g.key === k)));
assert.deepStrictEqual(S.lineup(D20), L20);
assert.notDeepStrictEqual(S.lineup('2026-10-21'), L20);

// not out yet: the Heroes groups (squad.js HIDDEN, or config/roster's list)
assert.deepStrictEqual(S.hiddenOf(null), ['heroes', 'elemental']);
assert.deepStrictEqual(S.hiddenOf({ hidden: [] }), []);
assert.deepStrictEqual(S.hiddenOf({ hidden: 'x' }), S.HIDDEN);
assert.ok(!S.groupOut('elemental') && S.groupOut('elemental', []) && S.groupOut('ocean'));
assert.deepStrictEqual(S.outIds(['1', '79', '80', '85', 'x']), ['1']);
assert.deepStrictEqual(S.outIds(['1', '79', '80'], ['80']), ['1', '79']); // one creature by id
// no HOT slot is a hidden group, on any day; there are three either way
for (let d = 1; d <= 60; d++) {
  const day = `2026-11-${String((d % 30) + 1).padStart(2, '0')}`;
  assert.ok(S.lineup(day).every((k) => !S.HIDDEN.includes(k)), day);
  assert.strictEqual(S.lineup(day, []).length, 3);
}
// a hidden group's chest isn't for sale; once it's out it is
assert.strictEqual(S.MOVES.groupChest({ coins: 1000 }, { group: 'elemental', size: 'common', artIds: ALL, random: seq(0.99) }).error, 'unknown_chest');
assert.ok(S.MOVES.groupChest({ coins: 1000 }, { group: 'elemental', size: 'common', artIds: ALL, hidden: [], random: seq(0.99, 0.1, 0.1, 0.5) }).result.id);

// a Common chest, no upgrade (first roll 0.99), a Common pull of the group
m = S.MOVES.groupChest({ coins: 1000, gems: 0 }, { group: 'ocean', size: 'common', artIds: ALL, random: seq(0.99, 0.1, 0.1, 0.5) });
assert.strictEqual(m.result.final, 'common');
assert.strictEqual(m.result.upgraded, false);
assert.strictEqual(S.BY_ID[m.result.id].set, 'ocean');
assert.strictEqual(m.result.rar, 0);
assert.strictEqual(m.result.isNew, false); // a first copy
assert.strictEqual(m.result.copies, 1);
assert.strictEqual(m.result.need, 5);
assert.deepStrictEqual(m.set.copies, { [m.result.id]: 1 });
assert.strictEqual(m.result.dupeCoins, 0);
assert.ok(m.result.coins >= 40 && m.result.coins <= 120 && m.result.coins % 10 === 0);
assert.strictEqual(m.set.coins, 1000 - 300 + m.result.coins);
assert.strictEqual(m.set.epic, 1);
assert.strictEqual(m.set.passXp, 20);
// its last copy from a chest unlocks it
const oceanId = m.result.id;
m = S.MOVES.groupChest({ coins: 1000, copies: ready(oceanId) }, { group: 'ocean', size: 'common', artIds: [oceanId], random: seq(0.99, 0.1, 0.1, 0.5) });
assert.ok(m.result.isNew);
assert.strictEqual(m.result.copies, 5);
assert.deepStrictEqual(m.set.ownedIds, [oceanId]);
// a Rainbow (a set reward from a chest) takes 15
m = S.MOVES.groupChest({ gems: 1e4, ownedIds: ['28'] }, { group: 'snack', size: 'set', artIds: ALL, random: seq(0.99, 0.99, 0.5) });
assert.strictEqual(m.result.need, 15);
// prices and money checks
assert.strictEqual(S.MOVES.groupChest({ coins: 299 }, { group: 'ocean', size: 'common', artIds: ALL }).error, 'not_enough_coins');
assert.strictEqual(S.MOVES.groupChest({ gems: 119 }, { group: 'ocean', size: 'epic', artIds: ALL }).error, 'not_enough_gems');
assert.strictEqual(S.MOVES.groupChest({ gems: 1e4 }, { group: 'nope', size: 'epic', artIds: ALL }).error, 'unknown_chest');
assert.strictEqual(S.MOVES.groupChest({ gems: 1e4 }, { group: 'ocean', size: 'huge', artIds: ALL }).error, 'unknown_chest');
m = S.MOVES.groupChest({ gems: 700, coins: 0 }, { group: 'pet', size: 'set', artIds: ALL, random: seq(0.5) });
assert.strictEqual(m.set.gems, 20);
assert.ok(m.result.rar >= 2); // a Rainbow chest is Epic or Legendary
assert.strictEqual(m.set.epic, 0);
assert.strictEqual(m.set.passXp, 80);
// the first-smash upgrade: a Common under 25% becomes Epic (share roll < 78)
m = S.MOVES.groupChest({ coins: 1000 }, { group: 'snack', size: 'common', artIds: ALL, random: seq(0.1, 0.5, 0.5, 0.5, 0.5) });
assert.strictEqual(m.result.final, 'epic');
assert.ok(m.result.upgraded);
assert.ok(m.result.coins >= 150);
// an Epic never upgrades
m = S.MOVES.groupChest({ gems: 200 }, { group: 'snack', size: 'epic', artIds: ALL, random: seq(0.01, 0.01, 0.5) });
assert.strictEqual(m.result.final, 'epic');
// the Lucky meter: the 10th chest is Epic or better, and says so
m = S.MOVES.groupChest({ coins: 1000, epic: 9 }, { group: 'ocean', size: 'common', artIds: ALL, random: seq(0.99, 0.01, 0.5, 0.5) });
assert.ok(m.result.rar >= 2);
assert.ok(m.result.luck);
assert.strictEqual(m.set.epic, 0);
// a duplicate pays the design's coins
const dupId = S.ROSTER.find((c) => c.set === 'ocean' && c.rar === 0).id;
m = S.MOVES.groupChest({ coins: 1000, ownedIds: S.ROSTER.filter((c) => c.set === 'ocean').map((c) => c.id) }, { group: 'ocean', size: 'common', artIds: ALL, random: seq(0.99, 0.01, 0.01, 0.5) });
assert.strictEqual(m.result.isNew, false);
assert.strictEqual(m.result.dupeCoins, S.GDUPE[m.result.rar]);
assert.strictEqual(m.set.coins, 700 + m.result.coins + m.result.dupeCoins);
// with set rewards on, never a set reward; never a creature without art
for (let i = 0; i < 200; i++) {
  const r = S.MOVES.groupChest({ gems: 1e4 }, { group: 'snack', size: 'set', artIds: ALL, setRewards: true }).result;
  assert.ok(!S.BY_ID[r.id].reward);
}
// for now a set reward drops too, as a Legendary of its group (Chef Bun with Boba)
const chefBun = S.SET_OF.snack.reward;
let gotReward = 0;
for (let i = 0; i < 400; i++) {
  const r = S.MOVES.groupChest({ gems: 1e4 }, { group: 'snack', size: 'set', artIds: ALL }).result;
  assert.ok(S.BY_ID[r.id].set === 'snack' && S.dropRar(S.BY_ID[r.id]) >= 2);
  if (r.id === chefBun) gotReward++;
}
assert.ok(gotReward > 0);
// a Legendary roll: Boba or Chef Bun, unowned ones 3x as likely
m = S.MOVES.groupChest({ gems: 1e4, ownedIds: ['28'] }, { group: 'snack', size: 'set', artIds: ALL, random: seq(0.99, 0.99, 0.5) });
assert.strictEqual(m.result.id, chefBun);
assert.strictEqual(m.result.rar, 4);
assert.strictEqual(m.result.reward, null);
// its duplicate pays a Legendary's coins
m = S.MOVES.groupChest({ gems: 1e4, ownedIds: ['28', chefBun] }, { group: 'snack', size: 'set', artIds: ALL, random: seq(0.99, 0.99, 0.9) });
assert.strictEqual(m.result.dupeCoins, S.GDUPE[3]);
// with set rewards on, a set's last member from a chest brings the reward
const snackLast = S.SET_OF.snack.ids;
m = S.MOVES.groupChest({ coins: 1e4, ownedIds: snackLast.slice(1), copies: ready(snackLast[0]) }, { group: 'snack', size: 'common', artIds: [snackLast[0]], setRewards: true, random: seq(0.99, 0.1, 0.1, 0.5) });
assert.strictEqual(m.result.reward, chefBun);
assert.strictEqual(S.MOVES.groupChest({ gems: 1e4 }, { group: 'snack', size: 'epic', artIds: [] }).result.id, null);
// the free chest: today's first HOT group, Common, every 4 h
m = S.MOVES.freeChest({ ownedIds: ['1'] }, { now: NOW, day: D20, artIds: ALL, random: seq(0.99, 0.1, 0.1, 0.5) });
assert.strictEqual(m.result.group, L20[0]);
assert.strictEqual(m.result.size, 'common');
assert.strictEqual(m.set.freeAt, NOW + S.FREE_MS);
assert.strictEqual(S.MOVES.freeChest({ freeAt: NOW + 1 }, { now: NOW, day: D20, artIds: ALL }).error, 'not_yet');
// a streak's extra free chest: used while the timer runs, the timer kept
m = S.MOVES.freeChest({ ownedIds: ['1'], freeAt: NOW + 1, freeBonus: 2 }, { now: NOW, day: D20, artIds: ALL });
assert.strictEqual(m.set.freeBonus, 1);
assert.strictEqual(m.set.freeAt, undefined);
// the timer first when both are there
m = S.MOVES.freeChest({ ownedIds: ['1'], freeBonus: 2 }, { now: NOW, day: D20, artIds: ALL });
assert.strictEqual(m.set.freeBonus, undefined);
assert.strictEqual(m.set.freeAt, NOW + S.FREE_MS);
// a new player's first free chest is the welcome one: Mittens, from its
// group, no upgrade (a roll that would upgrade), the Lucky meter untouched
m = S.MOVES.freeChest({ epic: 9 }, { now: NOW, day: D20, artIds: ALL, random: seq(0.001, 0.001, 0.5) });
assert.strictEqual(m.result.id, '1');
assert.ok(m.result.isNew); // whole, not a copy
assert.deepStrictEqual(m.set.ownedIds, ['1']);
assert.strictEqual(m.result.group, S.BY_ID['1'].set);
assert.strictEqual(m.result.final, 'common');
assert.strictEqual(m.set.epic, 9);
assert.strictEqual(m.set.chestOpens, 1);
assert.strictEqual(m.set.freeAt, NOW + S.FREE_MS);
// not once a chest is opened, nor with Mittens
for (const p of [{ chestOpens: 1 }, { ownedIds: ['1'] }]) assert.strictEqual(S.MOVES.freeChest(p, { now: NOW, day: D20, artIds: ALL, random: seq(0.99, 0.1, 0.1, 0.5) }).result.group, L20[0]);
// the ad chest: the second HOT group's Rare, 3 a day
m = S.MOVES.adChest({}, { now: NOW, day: D20, artIds: ALL, random: seq(0.99, 0.1, 0.1, 0.5) });
assert.strictEqual(m.result.group, L20[1]);
assert.strictEqual(m.result.size, 'rare');
assert.deepStrictEqual(m.set.adChests, { day: D20, n: 1 });
assert.strictEqual(S.MOVES.adChest({ adChests: { day: D20, n: 3 } }, { day: D20, artIds: ALL }).error, 'no_videos_left');
assert.ok(!S.MOVES.adChest({ adChests: { day: '2026-10-19', n: 3 } }, { day: D20, artIds: ALL }).error);
// the daily deal: 320 gems for a Legendary of the first HOT group + 2,000 coins, once a day
m = S.MOVES.dealChest({ gems: 400, coins: 5 }, { day: D20, artIds: ALL, random: seq(0.5) });
assert.strictEqual(m.result.group, L20[0]);
assert.strictEqual(m.result.final, 'legendary');
assert.strictEqual(m.set.gems, 80);
assert.strictEqual(m.set.dealDay, D20);
assert.strictEqual(m.set.coins, 5 + 2000 + m.result.coins + m.result.dupeCoins + m.result.setBonus);
assert.strictEqual(S.MOVES.dealChest({ gems: 400, dealDay: D20 }, { day: D20, artIds: ALL }).error, 'deal_used');
assert.strictEqual(S.MOVES.dealChest({ gems: 300 }, { day: D20, artIds: ALL }).error, 'not_enough_gems');

// --- offers: the season pass, the 7-day streak, the gem jar (REDESIGN_V6 step 7) ---
const OFF = S.DEFAULT_OFFERS;
const SEASON_ON = Date.parse('2026-10-25T12:00:00Z');
// node 0: 300 coins at 0 XP; once
m = S.MOVES.passClaim({ coins: 10 }, { i: 0, offers: OFF, now: SEASON_ON, day: D20, artIds: ALL });
assert.strictEqual(m.set.coins, 310);
assert.deepStrictEqual(m.set.passGot, { spooky: { 0: true } });
assert.strictEqual(S.MOVES.passClaim({ passGot: { spooky: { 0: true } } }, { i: 0, offers: OFF, now: SEASON_ON }).error, 'claimed');
// node 1: a gold one (needs the pass) at 100 XP; a chest of the season
assert.strictEqual(S.MOVES.passClaim({ passXp: 50 }, { i: 1, offers: OFF, now: SEASON_ON }).error, 'need_xp');
assert.strictEqual(S.MOVES.passClaim({ passXp: 150 }, { i: 1, offers: OFF, now: SEASON_ON }).error, 'need_pass');
m = S.MOVES.passClaim({ passXp: 150, passPrem: { spooky: true } }, { i: 1, offers: OFF, now: SEASON_ON, day: D20, artIds: ALL, random: seq(0.99, 0.1, 0.1, 0.5) });
assert.strictEqual(m.result.kind, 'chest');
assert.strictEqual(m.result.chest.group, 'spooky');
assert.strictEqual(S.MOVES.passClaim({}, { i: 0, offers: OFF, now: Date.parse('2026-11-02T00:00:00Z') }).error, 'season_over');
assert.strictEqual(S.MOVES.passClaim({}, { i: 9, offers: OFF, now: SEASON_ON }).error, 'unknown_reward');
// the streak: day 1 coins, then day 2 gems the next day, a missed day starts over
m = S.MOVES.streakClaim({ coins: 0 }, { offers: OFF, day: D20, artIds: ALL });
assert.strictEqual(m.result.day, 1);
assert.strictEqual(m.set.coins, 200);
assert.deepStrictEqual(m.set.shopStreak, { count: 1, last: D20 });
assert.strictEqual(S.MOVES.streakClaim({ shopStreak: { count: 1, last: D20 } }, { offers: OFF, day: D20 }).error, 'claimed');
m = S.MOVES.streakClaim({ gems: 5, shopStreak: { count: 1, last: D20 } }, { offers: OFF, day: '2026-10-21', artIds: ALL });
assert.strictEqual(m.result.day, 2);
assert.strictEqual(m.set.gems, 35);
m = S.MOVES.streakClaim({ shopStreak: { count: 4, last: '2026-10-18' } }, { offers: OFF, day: D20, artIds: ALL });
assert.strictEqual(m.result.day, 1);
// day 3: a Common chest of the third HOT group
m = S.MOVES.streakClaim({ shopStreak: { count: 2, last: '2026-10-19' } }, { offers: OFF, day: D20, artIds: ALL, random: seq(0.99, 0.1, 0.1, 0.5) });
assert.strictEqual(m.result.kind, 'chest');
assert.strictEqual(m.result.chest.group, S.lineup(D20)[2]);
assert.strictEqual(m.result.chest.size, 'common');
// the jar: a gem per 25 coins earned since it was broken, up to 1500
const JAR = OFF.offers.find((o) => o.kind === 'jar');
assert.strictEqual(S.jarGems({ totalEarned: 2500 }, JAR), 100);
assert.strictEqual(S.jarGems({ totalEarned: 2500, jarBase: 2000 }, JAR), 20);
assert.strictEqual(S.jarGems({ totalEarned: 1e7 }, JAR), 1500);
// a broken config falls back to the design's
assert.strictEqual(S.offersOf({ offers: 'x' }).offers.length, OFF.offers.length);

console.log('squad.test.js: all passed');
