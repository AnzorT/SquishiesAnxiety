// The squad economy (the 2026-10-06 design's squad-store.js and Shop Screen
// v2), kept free of Firebase so it can be tested alone. The `squad` callable
// in index.js runs these in a transaction on users/{uid}. The app's copy of
// the tables is src/squad/data.js — keep the two in step.
//
// Currencies: coins (the profile's `coins`, still written by the app too;
// duplicates and finished sets pay coins here) and gems (bought with real
// money: the g1–g6 packs in purchases.js). Stars were dropped (user,
// 2026-10-09). Gems and the collection are server-only fields
// (firestore.rules).
//
// Profile fields this owns:
//   gems                 a number
//   col                  { [id]: { f: { n: 1, s: 1 … }, eq: 'n', st: 0 } } —
//                        the finishes owned, the one shown, the growth stage
//   pity                 Gold/Crystal/Rainbow chests since the last
//                        Legendary (30 = a guaranteed Legendary)
//   epic                 chests since the last Epic or better (10 = a
//                        guaranteed Epic)
//   chestBag             { basic: 2, … } — My Chests, bought and not opened
//                        (`chests` is taken: the daily chests opened)
//   chestVideos          { day, n } — today's free video chests
//   dealDay              the day the Daily Deal was bought
//   giftDay              the day the daily chest's gift was given
//   chestOpens, tierPulls chests opened, and pulls by rarity / finish name
//   gemFirst             { g1: true … } — packs whose first-buy double is used
//   ownedIds             (shared with the rest of the app) gets every grant
// The app writes `xp` ({ [id]: n }, squish XP toward growing) itself.

// --- the roster --------------------------------------------------------------

// Rarity: 0 Common, 1 Rare, 2 Epic, 3 Legendary, 4 Set reward.
const RARITY = ['Common', 'Rare', 'Epic', 'Legendary', 'Set reward'];
const SETS = ['snack', 'fruit', 'ocean', 'pet', 'forest', 'sky', 'dream', 'bakery'];
const SEASON = { key: 'spooky', name: 'Spooky Squish' };

// [id, name, set, rarity, flag] — ids 0-29 are the 2026-10-03 plush roster.
const R = [
  [0, 'Nimbo', 'sky', 0], [1, 'Mittens', 'pet', 0], [2, 'Mallow', 'snack', 1], [3, 'Bao', 'snack', 0],
  [4, 'Dunkie', 'snack', 0], [5, 'Frybo', 'snack', 0], [6, 'Pip', 'ocean', 0], [7, 'Bunbun', 'snack', 0],
  [8, 'Jelli', 'ocean', 2], [9, 'Pina', 'fruit', 0], [10, 'Finn', 'ocean', 0], [11, 'Sealy', 'ocean', 1],
  [12, 'Biscuit', 'pet', 0], [13, 'Hana', 'dream', 0], [14, 'Choco', 'snack', 2], [15, 'Prickle', 'pet', 2],
  [16, 'Lumi', 'sky', 3], [17, 'Kiko', 'forest', 3], [18, 'Bubbly', 'sky', 1], [19, 'Twinkle', 'sky', 2],
  [20, 'Zappi', 'sky', 1], [21, 'Scoop', 'snack', 1], [22, 'Teddy', 'forest', 0], [23, 'Hoot', 'forest', 1],
  [24, 'Leo', 'forest', 2], [25, 'Nibbles', 'pet', 0], [26, 'Quill', 'pet', 1], [27, 'Panko', 'forest', 1],
  [28, 'Boba', 'snack', 3], [29, 'Avo', 'fruit', 1], [30, 'Berri', 'fruit', 0], [31, 'Lemmy', 'fruit', 0],
  [32, 'Kiwi', 'fruit', 0], [33, 'Melo', 'fruit', 1], [34, 'Peachy', 'fruit', 2], [35, 'Pitaya', 'fruit', 3],
  [36, 'Tutti', 'fruit', 4], [37, 'Puff', 'ocean', 0], [38, 'Shelly', 'ocean', 0], [39, 'Octo', 'ocean', 1],
  [40, 'Marina', 'ocean', 3], [41, 'Pearl', 'ocean', 4], [42, 'Waffles', 'pet', 0], [43, 'Poppy', 'pet', 1],
  [44, 'Duchess', 'pet', 3], [45, 'Mama Paws', 'pet', 4], [46, 'Acorn', 'forest', 0], [47, 'Fawn', 'forest', 0],
  [48, 'Moss', 'forest', 0], [49, 'Sprout', 'forest', 4], [50, 'Plip', 'sky', 0], [51, 'Breeze', 'sky', 0],
  [52, 'Dusty', 'sky', 0], [53, 'Aurora', 'sky', 4], [54, 'Boo', 'dream', 0], [55, 'Pixie', 'dream', 0],
  [56, 'Floof', 'dream', 0], [57, 'Unibun', 'dream', 1], [58, 'Gumdrop', 'dream', 1], [59, 'Ember', 'dream', 2],
  [60, 'Drako', 'dream', 3], [61, 'Wishling', 'dream', 4], [62, 'Cuppy', 'bakery', 0], [63, 'Chip', 'bakery', 0],
  [64, 'Twisty', 'bakery', 0], [65, 'Crois', 'bakery', 0], [66, 'Maca', 'bakery', 1], [67, 'Puddi', 'bakery', 1],
  [68, 'Mochi', 'bakery', 2], [69, 'Cakey', 'bakery', 3], [70, 'Sugarplum', 'bakery', 4], [71, 'Chef Bun', 'snack', 4],
  [72, 'Gourdy', 'spooky', 0], [73, 'Batty', 'spooky', 0], [74, 'Kernel', 'spooky', 0], [75, 'Hexie', 'spooky', 1],
  [76, 'Mumbles', 'spooky', 2], [77, 'Hocus', 'spooky', 3], [78, 'Count Squishula', 'spooky', 3, 'pass'],
];
const ROSTER = R.map(([id, name, set, rar, flag]) => ({
  id: String(id),
  name,
  set,
  rar,
  reward: rar === 4,
  season: set === SEASON.key,
  pass: flag === 'pass',
  base: rar < 4 && set !== SEASON.key,
}));
const BY_ID = Object.fromEntries(ROSTER.map((c) => [c.id, c]));
// Each set's members (not its reward) and its reward creature.
const SET_OF = Object.fromEntries(
  SETS.map((k) => [k, { ids: ROSTER.filter((c) => c.set === k && c.base).map((c) => c.id), reward: ROSTER.find((c) => c.set === k && c.reward).id }]),
);

// --- prices and odds ---------------------------------------------------------

const COIN_PRICE = [1500, 4000, 9000, null]; // Legendaries come from chests only
const PICK_OFF = 0.8; // Today's Picks: 20% off, rounded to 50
const DUPE = [400, 1000, 2500, 5000, 2500]; // coins for a duplicate (doubled for a finish)
const SET_BONUS = 2000; // coins, with a set's reward creature
// Finishes: odds in a normal chest (a Rainbow chest triples them). They
// only come from chests.
const FIN = { n: { odds: 97.4 }, s: { odds: 2 }, r: { odds: 0.5 }, g: { odds: 0.1 } };
// Growth: the squish XP each stage needs.
const STAGES = [{ xp: 0 }, { xp: 100 }, { xp: 300 }];
const CHESTS = {
  basic: { coins: 250, odds: [72, 22, 5, 1] },
  silver: { coins: 600, odds: [55, 33, 9.5, 2.5] },
  gold: { coins: 1200, odds: [30, 45, 20, 5], gp: 1 },
  crystal: { gems: 150, odds: [0, 50, 38, 12], gp: 1 },
  rainbow: { gems: 300, odds: [0, 0, 70, 30], gp: 1, fx: 3 },
  season: { gems: 120, odds: [50, 30, 15, 5], season: 1 },
  // every new player's first chest (the tutorial's): always Mittens
  welcome: { odds: [100, 0, 0, 0], fixed: '1' },
};
const PITY_MAX = 30;
const EPIC_MAX = 10;
const DEAL = { tier: 'crystal', gems: 105 };
const VIDEO_CHESTS = 3; // free Basic chests a day, one video each
const SWAPS = [{ coins: 2000, gems: 100 }, { coins: 5500, gems: 250 }, { coins: 12000, gems: 500 }];
// What every player starts with (user, 2026-10-06), given on their first
// squad move: the profile has no `gems` yet.
const START = { gems: 600 };
const GEM_PACKS = { gems_80: 80, gems_450: 450, gems_950: 950, gems_2000: 2000, gems_5500: 5500, gems_12000: 12000 };

// --- reading a profile -------------------------------------------------------

const num = (n) => (typeof n === 'number' && Number.isFinite(n) ? n : 0);
const colOf = (p) => (p && p.col && typeof p.col === 'object' ? p.col : {});
const owns = (p, id) => !!colOf(p)[id] || ((p && p.ownedIds) || []).includes(id);
const entryOf = (p, id) => colOf(p)[id] || (owns(p, id) ? { f: { n: 1 }, eq: 'n', st: 0 } : null);

// The three creatures on sale today (Common to Epic, with art), unowned
// ones first; the same for app and server on the same day.
function picks(p, artIds, day) {
  const d = Math.floor(Date.parse(`${day}T00:00:00Z`) / 864e5) || 0;
  const pool = ROSTER.filter((c) => c.base && c.rar < 3 && artIds.includes(c.id));
  const order = pool
    .map((c) => ({ id: c.id, k: (Number(c.id) * 7919 + d * 104729) % 1009 }))
    .sort((a, b) => a.k - b.k)
    .map((x) => x.id);
  const un = order.filter((id) => !owns(p, id));
  return (un.length >= 3 ? un : order).slice(0, 3);
}

function creaturePrice(p, id, artIds, day) {
  const c = BY_ID[id];
  if (!c || !c.base) return null;
  const base = COIN_PRICE[c.rar];
  if (!base) return null;
  return picks(p, artIds, day).includes(id) ? Math.round((base * PICK_OFF) / 50) * 50 : base;
}

// --- the moves ---------------------------------------------------------------
// Each takes the profile (users/{uid} data) and returns { error } or
// { set, result }: `set` is the plain values to write (whole fields, or
// `col.<id>` paths), `result` goes back to the app.

const bad = (error) => ({ error });

function pay(p, cur, n) {
  if (cur === 'coins') return num(p.coins) >= n ? { coins: num(p.coins) - n } : null;
  if (cur === 'gems') return num(p.gems) >= n ? { gems: num(p.gems) - n } : null;
  return null;
}

// Puts `n` chests of `tier` in My Chests.
function addChests(p, tier, n = 1) {
  return { chestBag: { ...(p.chestBag || {}), [tier]: num((p.chestBag || {})[tier]) + n } };
}

// Buying a chest (deal: the Daily Deal's Crystal chest at its price, once a day).
function buyChest(p, { tier, deal, day }) {
  if (deal) {
    if (p.dealDay === day) return bad('deal_used');
    const paid = pay(p, 'gems', DEAL.gems);
    if (!paid) return bad('not_enough_gems');
    return { set: { ...paid, ...addChests(p, DEAL.tier), dealDay: day }, result: { tier: DEAL.tier } };
  }
  const T = CHESTS[tier];
  if (!T || (!T.coins && !T.gems)) return bad('unknown_chest');
  const paid = T.gems ? pay(p, 'gems', T.gems) : pay(p, 'coins', T.coins);
  if (!paid) return bad(T.gems ? 'not_enough_gems' : 'not_enough_coins');
  return { set: { ...paid, ...addChests(p, tier) }, result: { tier } };
}

// A free Basic chest for a video (no video with Remove Ads).
function videoChest(p, { day }) {
  const v = p.chestVideos && p.chestVideos.day === day ? num(p.chestVideos.n) : 0;
  if (v >= VIDEO_CHESTS) return bad('no_videos_left');
  return { set: { ...addChests(p, 'basic'), chestVideos: { day, n: v + 1 } }, result: { tier: 'basic', left: VIDEO_CHESTS - v - 1 } };
}

function pickWeighted(weights, random) {
  let x = random() * weights.reduce((a, b) => a + b, 0);
  for (let i = 0; i < weights.length - 1; i++) {
    if (x < weights[i]) return i;
    x -= weights[i];
  }
  return weights.length - 1;
}

// One chest's pull: { id, rar, f } and the new pity/epic counters.
function roll(p, tier, artIds, random) {
  const T = CHESTS[tier];
  if (T.fixed) return { id: T.fixed, rar: BY_ID[T.fixed].rar, f: 'n', pity: num(p.pity), epic: num(p.epic) };
  let pity = num(p.pity) + (T.gp ? 1 : 0);
  let epic = num(p.epic) + 1;
  let r = pickWeighted(T.odds, random);
  if (T.gp && pity >= PITY_MAX) r = 3;
  if (r < 2 && epic >= EPIC_MAX) r = 2;
  if (r === 3) pity = 0;
  if (r >= 2) epic = 0;
  const inChest = (c) => (T.season ? c.season && !c.pass : c.base) && artIds.includes(c.id);
  let pool = ROSTER.filter((c) => inChest(c) && c.rar === r);
  if (!pool.length) {
    // nothing with art at that rarity: the best rarity below it that has some
    const lower = ROSTER.filter((c) => inChest(c) && c.rar <= r);
    const top = Math.max(-1, ...lower.map((c) => c.rar));
    pool = lower.filter((c) => c.rar === top);
  }
  if (!pool.length) return null;
  // creatures not owned yet are 3× as likely
  const c = pool[pickWeighted(pool.map((x) => (owns(p, x.id) ? 1 : 3)), random)];
  const m = T.fx || 1;
  const fr = random() * 100;
  const f = fr < FIN.g.odds * m ? 'g' : fr < (FIN.g.odds + FIN.r.odds) * m ? 'r' : fr < (FIN.g.odds + FIN.r.odds + FIN.s.odds) * m ? 's' : 'n';
  return { id: c.id, rar: r, f, pity: Math.min(PITY_MAX, pity), epic };
}

// Adds creature `id` in finish `f` to the collection: new, a new finish,
// or a duplicate (coins). A base set's last member also brings its reward.
function grant(p, id, f = 'n') {
  const c = BY_ID[id];
  const col = colOf(p);
  const e = entryOf(p, id);
  const out = { id, isNew: !e, newFinish: false, coins: 0, reward: null };
  const set = {};
  const owned = new Set(p.ownedIds || []);
  if (!e) {
    set[`col.${id}`] = { f: f === 'n' ? { n: 1 } : { n: 1, [f]: 1 }, eq: f, st: 0 };
    owned.add(id);
  } else if (!e.f[f]) {
    set[`col.${id}`] = { ...e, f: { ...e.f, [f]: 1 } };
    out.newFinish = true;
  } else out.coins = DUPE[c.rar] * (f !== 'n' ? 2 : 1);
  let coins = num(p.coins) + out.coins;
  if (c.base) {
    const s = SET_OF[c.set];
    const has = (x) => x === id || owns(p, x);
    if (!col[s.reward] && !owned.has(s.reward) && s.ids.every(has)) {
      set[`col.${s.reward}`] = { f: { n: 1 }, eq: 'n', st: 0 };
      owned.add(s.reward);
      coins += SET_BONUS;
      out.coins += SET_BONUS;
      out.reward = s.reward;
    }
  }
  if (coins !== num(p.coins)) set.coins = coins;
  if (owned.size !== (p.ownedIds || []).length) set.ownedIds = [...owned];
  return { set, result: out };
}

// Pulls so far by rarity name and by finish (Shiny, Rainbow, Golden), for
// the achievements.
function pulled(p, pull) {
  const t = { ...(p.tierPulls || {}) };
  const add = (k) => (t[k] = num(t[k]) + 1);
  add(RARITY[pull.rar]);
  if (pull.f !== 'n') add({ s: 'Shiny', r: 'Rainbow', g: 'Golden' }[pull.f]);
  return t;
}

function openChest(p, { tier, artIds, random = Math.random }) {
  if (!CHESTS[tier]) return bad('unknown_chest');
  const have = num((p.chestBag || {})[tier]);
  if (have <= 0) return bad('no_chest');
  const pull = roll(p, tier, artIds, random);
  if (!pull) return bad('empty_chest');
  const g = grant(p, pull.id, pull.f);
  return {
    set: { ...g.set, chestBag: { ...p.chestBag, [tier]: have - 1 }, pity: pull.pity, epic: pull.epic, chestOpens: num(p.chestOpens) + 1, tierPulls: pulled(p, pull) },
    result: { ...g.result, tier, rar: pull.rar, f: pull.f },
  };
}

// Buying a creature, with coins.
function buyCreature(p, { id, artIds, day }) {
  const c = BY_ID[id];
  if (!c || !c.base || !artIds.includes(id)) return bad('not_for_sale');
  if (owns(p, id)) return bad('owned');
  const price = creaturePrice(p, id, artIds, day);
  if (!price) return bad('not_for_sale');
  const paid = pay(p, 'coins', price);
  if (!paid) return bad('not_enough_coins');
  const g = grant({ ...p, ...paid }, id, 'n');
  return { set: { ...paid, ...g.set }, result: { ...g.result, price, cur: 'coins' } };
}

// Growing a creature: free once it has squished enough XP.
function grow(p, { id }) {
  const e = owns(p, id) ? entryOf(p, id) : null;
  if (!e) return bad('not_owned');
  const next = STAGES[num(e.st) + 1];
  if (!next) return bad('max_stage');
  if (num((p.xp || {})[id]) < next.xp) return bad('need_xp');
  return { set: { [`col.${id}`]: { ...e, st: num(e.st) + 1 } }, result: { id, st: num(e.st) + 1 } };
}

function equip(p, { id, f }) {
  const e = owns(p, id) ? entryOf(p, id) : null;
  if (!e || !e.f[f]) return bad('not_owned');
  return { set: { [`col.${id}`]: { ...e, eq: f } }, result: { id, f } };
}

function swap(p, { i }) {
  const s = SWAPS[i];
  if (!s) return bad('unknown_swap');
  const paid = pay(p, 'gems', s.gems);
  if (!paid) return bad('not_enough_gems');
  return { set: { ...paid, coins: num(p.coins) + s.coins }, result: { coins: s.coins, gems: s.gems } };
}

// The profile with the starting gems if it has none yet, and the fields
// that writes.
function withStart(p) {
  if (p.gems != null) return { p, set: {} };
  const set = { gems: START.gems };
  if (!owns(p, '1')) set.chestBag = { ...(p.chestBag || {}), welcome: 1 };
  return { p: { ...p, ...set }, set };
}

// The daily chest's gift (once a day, with the coins the app adds itself):
// the streak day's own server-side reward — gems (`gems`, up to 20) or a
// Silver chest (`chest`).
function dailyGift(p, { day, reward }) {
  if (p.giftDay === day) return bad('gift_used');
  const set = { giftDay: day };
  const gems = reward && reward.kind === 'gems' ? Math.max(0, Math.min(20, Math.floor(num(reward.amount)))) : 0;
  if (gems) set.gems = num(p.gems) + gems;
  if (reward && reward.kind === 'chest') Object.assign(set, addChests(p, 'silver'));
  return { set, result: { gems, chest: reward && reward.kind === 'chest' ? 'silver' : null } };
}

// `start`: only the starting gems (the app calls it on sign-in).
const start = (p) => ({ set: {}, result: { gems: num(p.gems) } });

const MOVES = { start, dailyGift, buyChest, videoChest, openChest, buyCreature, grow, equip, swap };

module.exports = {
  RARITY,
  SETS,
  SEASON,
  ROSTER,
  BY_ID,
  SET_OF,
  COIN_PRICE,
  DUPE,
  SET_BONUS,
  FIN,
  STAGES,
  CHESTS,
  PITY_MAX,
  EPIC_MAX,
  DEAL,
  VIDEO_CHESTS,
  SWAPS,
  GEM_PACKS,
  START,
  withStart,
  owns,
  picks,
  creaturePrice,
  roll,
  grant,
  MOVES,
};
