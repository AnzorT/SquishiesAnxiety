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
//   chestBag             { basic: 2, … } — the old My Chests (pre-v6; no
//                        longer shown or filled by the app),
//                        (`chests` is taken: the daily chests opened)
//   chestVideos          { day, n } — today's free video chests
//   dealDay              the day the Daily Deal was bought
//   giftDay              the day the daily chest's gift was given
//   chestOpens, tierPulls chests opened, and pulls by rarity / finish name
//   freeAt               when the next free group chest is ready (ms)
//   freeBonus            extra free chests (the streak's chest days)
//   adChests             { day, n } — today's ad chests (group chests)
//   passXp               season-pass XP: every group chest opened adds some
//   passGot              { [season]: { [node]: true } } — pass rewards claimed
//   passPrem             { [season]: true } — the pass bought (verifyPurchase)
//   shopStreak           { count, last } — the Deals tab's 7-day streak
//   jarBase              totalEarned when the gem jar was last broken
//   offersBought         { [offer id]: true } — one-time offers bought
//   gemFirst             { g1: true … } — packs whose first-buy double is used
//   copies               { [id]: n } — copies found of creatures not
//                        unlocked yet (COPIES: one unlocks at its rarity's
//                        count, and leaves this list)
//   ownedIds             (shared with the rest of the app) gets every unlock
// The app writes `xp` ({ [id]: n }, squish XP toward growing) itself.

// --- the roster --------------------------------------------------------------

// Rarity: 0 Common, 1 Rare, 2 Epic, 3 Legendary, 4 Rainbow (the sets'
// reward creatures; "Set reward" before 2026-10-24, and still the key their
// pulls are counted under in `tierPulls`).
const RARITY = ['Common', 'Rare', 'Epic', 'Legendary', 'Set reward'];
// The design's 11 groups (squad-store.js SETS + SEASON + HEROES + ELEMENTAL,
// in its order; chest-loot.js GROUPS has their chests). The 8 SETS are the
// collectable sets, each with a reward creature (Dreamland has none since
// the 2026-10-19 drop made Jinni a Legendary).
const GROUPS = [
  { key: 'snack', name: 'Snack Shack' },
  { key: 'fruit', name: 'Fruit Patch' },
  { key: 'ocean', name: 'Ocean Pals' },
  { key: 'pet', name: 'Pet Shop' },
  { key: 'forest', name: 'Forest Friends' },
  { key: 'sky', name: 'Sky & Stars' },
  { key: 'dream', name: 'Dreamland' },
  { key: 'bakery', name: 'Sweet Bakery' },
  { key: 'spooky', name: 'Spooky Squish' },
  { key: 'heroes', name: 'Masked Heroes' },
  { key: 'elemental', name: 'Elemental Heroes' },
];
const SETS = ['snack', 'fruit', 'ocean', 'pet', 'forest', 'sky', 'dream', 'bakery'];
const SEASON = { key: 'spooky', name: 'Spooky Squish' };

// [id, key, name, group, rarity, flag] — the 2026-10-19 design's 86
// (squad-store.js R). `key` names the art (export/tripo/<key>/) and the rig.
// The collection (col, ownedIds, xp) is keyed by id, so ids are PERMANENT:
// never renumber or reuse one. A creature the design adds gets the next id
// here even if the design numbers it differently, a removed one keeps its
// row, and a creature whose key changes keeps its id (squad.test.js checks
// the id → key list). The roster before this one was reset on 2026-10-19;
// from then on collections are migrated, never reset (REDESIGN_V6.md).
const R = [
  [0, 'nimbo', 'Nimbo', 'sky', 0], [1, 'mittens', 'Mittens', 'pet', 0], [2, 'mallow', 'Mallow', 'snack', 1],
  [3, 'bao', 'Bao', 'snack', 0], [4, 'dunkie', 'Dunkie', 'snack', 0], [5, 'frybo', 'Frybo', 'snack', 0],
  [6, 'pip', 'Pip', 'ocean', 0], [7, 'bunbun', 'Bunbun', 'snack', 0], [8, 'jelli', 'Jelli', 'ocean', 2],
  [9, 'pina', 'Pina', 'fruit', 0], [10, 'finn', 'Finn', 'ocean', 0], [11, 'sealy', 'Sealy', 'ocean', 1],
  [12, 'biscuit', 'Biscuit', 'pet', 0], [13, 'hana', 'Hana', 'dream', 0], [14, 'choco', 'Choco', 'snack', 2],
  [15, 'prickle', 'Prickle', 'pet', 2], [16, 'lumi', 'Lumi', 'sky', 3], [17, 'kiko', 'Kiko', 'forest', 3],
  [18, 'bubbly', 'Bubbly', 'sky', 1], [19, 'twinkle', 'Twinkle', 'sky', 2], [20, 'zappi', 'Zappi', 'sky', 1],
  [21, 'scoop', 'Scoop', 'snack', 1], [22, 'teddy', 'Teddy', 'forest', 0], [23, 'hoot', 'Hoot', 'forest', 1],
  [24, 'leo', 'Leo', 'forest', 2], [25, 'nibbles', 'Nibbles', 'pet', 0], [26, 'quill', 'Quill', 'pet', 1],
  [27, 'panko', 'Panko', 'forest', 1], [28, 'boba', 'Boba', 'snack', 3], [29, 'avo', 'Avo', 'fruit', 1],
  [30, 'berri', 'Berri', 'fruit', 0], [31, 'lemmy', 'Lemmy', 'fruit', 0], [32, 'kiwi', 'Kiwi', 'fruit', 0],
  [33, 'melo', 'Melo', 'fruit', 1], [34, 'peachy', 'Peachy', 'fruit', 2], [35, 'pitaya', 'Pitaya', 'fruit', 3],
  [36, 'tutti', 'Tutti', 'fruit', 4], [37, 'puff', 'Puff', 'ocean', 0], [38, 'shelly', 'Shelly', 'ocean', 0],
  [39, 'octo', 'Octo', 'ocean', 1], [40, 'marina', 'Marina', 'ocean', 3], [41, 'pearl', 'Pearl', 'ocean', 4],
  [42, 'waffles', 'Waffles', 'pet', 0], [43, 'poppy', 'Poppy', 'pet', 1], [44, 'duchess', 'Duchess', 'pet', 3],
  [45, 'mamapaws', 'Mama Paws', 'pet', 4], [46, 'acorn', 'Acorn', 'forest', 0], [47, 'fawn', 'Fawn', 'forest', 0],
  [48, 'moss', 'Moss', 'forest', 0], [49, 'sprout', 'Sprout', 'forest', 4], [50, 'plip', 'Plip', 'sky', 0],
  [51, 'breeze', 'Breeze', 'sky', 0], [52, 'dusty', 'Dusty', 'sky', 0], [53, 'aurora', 'Aurora', 'sky', 4],
  [54, 'boo', 'Boo', 'dream', 0], [55, 'pixie', 'Pixie', 'dream', 0], [56, 'floof', 'Floof', 'dream', 0],
  [57, 'unibun', 'Unibun', 'dream', 1], [58, 'gumdrop', 'Gumdrop', 'dream', 1], [59, 'ember', 'Flicker', 'dream', 2],
  [60, 'drako', 'Drako', 'dream', 3], [61, 'jinni', 'Jinni', 'dream', 3], [62, 'cuppy', 'Cuppy', 'bakery', 0],
  [63, 'chip', 'Chip', 'bakery', 0], [64, 'twisty', 'Twisty', 'bakery', 0], [65, 'crois', 'Crois', 'bakery', 0],
  [66, 'maca', 'Maca', 'bakery', 1], [67, 'puddi', 'Puddi', 'bakery', 1], [68, 'mochi', 'Mochi', 'bakery', 2],
  [69, 'cakey', 'Cakey', 'bakery', 3], [70, 'sugarplum', 'Sugarplum', 'bakery', 4],
  [71, 'chefbun', 'Chef Bun', 'snack', 4], [72, 'gourdy', 'Gourdy', 'spooky', 0],
  [73, 'batty', 'Batty', 'spooky', 0], [74, 'kernel', 'Kernel', 'spooky', 0], [75, 'hexie', 'Hexie', 'spooky', 1],
  [76, 'mumbles', 'Mumbles', 'spooky', 2], [77, 'hocus', 'Hocus', 'spooky', 3],
  [78, 'countsquishula', 'Count Squishula', 'spooky', 3, 'pass'], [79, 'wisecrack', 'Wisecrack', 'heroes', 3],
  [80, 'gigagrowth', 'Giga-Growth', 'elemental', 3], [81, 'crystalline', 'Crystalline', 'elemental', 2],
  [82, 'aeroswift', 'Aero-Swift', 'elemental', 2], [83, 'phantasm', 'Phantasm', 'elemental', 3],
  [84, 'magmara', 'Magmara', 'elemental', 2], [85, 'chronoshade', 'Chrono-Shade', 'elemental', 3],
];
const ROSTER = R.map(([id, key, name, set, rar, flag]) => ({
  id: String(id),
  key,
  name,
  set,
  rar,
  reward: rar === 4,
  season: set === SEASON.key,
  pass: flag === 'pass',
  base: rar < 4 && set !== SEASON.key,
}));
const BY_ID = Object.fromEntries(ROSTER.map((c) => [c.id, c]));
// Each group's members (not its reward) and its reward creature (null when
// it has none), for every group but the season.
const SET_OF = Object.fromEntries(
  GROUPS.filter((g) => g.key !== SEASON.key).map(({ key: k }) => [
    k,
    { ids: ROSTER.filter((c) => c.set === k && c.base).map((c) => c.id), reward: (ROSTER.find((c) => c.set === k && c.reward) || {}).id || null },
  ]),
);

// --- not out yet ---------------------------------------------------------------
// Groups and creatures that aren't in the game yet (user, 2026-10-24: the
// Masked and Elemental Heroes). No chest, HOT slot, deal or shop has them,
// and the app shows them only to a player who owns one already. Firestore
// config/roster { hidden: [group key or creature id] } replaces this list for
// the app and the server alike, so bringing a group out (taking it off the
// list) needs no app update or deploy: the next chest can drop it
// (tools/admin/roster.mjs).
const HIDDEN = ['heroes', 'elemental'];
// config/roster's list as read (missing or broken: the one above)
const hiddenOf = (cfg) => (cfg && Array.isArray(cfg.hidden) ? cfg.hidden.map(String) : HIDDEN);
const isOut = (c, hidden = HIDDEN) => !hidden.includes(c.set) && !hidden.includes(c.id);
// a group is out while a chest of it has something out to drop
const groupOut = (k, hidden = HIDDEN) => ROSTER.some((c) => c.set === k && !c.reward && !c.pass && isOut(c, hidden));
// the catalog's ids (the creatures with art) less the ones not out
const outIds = (artIds, hidden = HIDDEN) => artIds.filter((id) => BY_ID[id] && isOut(BY_ID[id], hidden));

// --- set rewards ----------------------------------------------------------------
// For now every creature comes from chests (user, 2026-10-24): a set's reward
// creature drops from its group's chests as a Legendary does, and finishing a
// set brings nothing extra. config/roster { setRewards: true } brings back the
// design's rule (the reward creature and SET_BONUS for finishing the set, and
// never in a chest), for the app and the server alike.
const SET_REWARDS = false;
const setRewardsOf = (cfg) => (cfg && typeof cfg.setRewards === 'boolean' ? cfg.setRewards : SET_REWARDS);
// the rarity a creature drops at: a set reward's is Legendary
const dropRar = (c) => (c.reward ? 3 : c.rar);
// what a chest of group `k` can drop (art and the hidden list aside)
const inGroupChest = (c, k, setRewards = SET_REWARDS) => c.set === k && !c.pass && (!c.reward || !setRewards);

// --- copies ----------------------------------------------------------------------
// A creature has to be found several times before it joins the squad (user,
// 2026-10-24): every pull of one not unlocked yet is a copy of it (the
// profile's `copies`), and it unlocks at its rarity's count, Common 5 up to
// Rainbow 15. Once unlocked, a pull is a duplicate (coins) as before. Only
// the welcome chest's Mittens comes whole. Nothing is sold for coins (user,
// 2026-10-24: "no character can be unlocked with coins … they are all
// unlocked by opening X times from the chests"). config/roster { copies:
// [5, 10, 12, 14, 15] } replaces the counts for the app and the server alike.
const COPIES = [5, 10, 12, 14, 15];
const copiesOf = (cfg) => (cfg && Array.isArray(cfg.copies) && cfg.copies.length === COPIES.length && cfg.copies.every((n) => Number.isInteger(n) && n >= 1 && n <= 99) ? cfg.copies : COPIES);
// how many copies creature `c` needs, under the counts `need`
const needOf = (c, need = COPIES) => (c ? need[c.rar] || 1 : 1);
const copiesHad = (p, id) => {
  const n = p && p.copies && typeof p.copies === 'object' ? p.copies[id] : 0;
  return typeof n === 'number' && Number.isFinite(n) ? n : 0;
};

// --- prices and odds ---------------------------------------------------------

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
// gems → coins (Shop Screen v5's SWAPS)
const SWAPS = [{ coins: 2000, gems: 50 }, { coins: 9000, gems: 200 }, { coins: 25000, gems: 500 }];
// What every player starts with (user, 2026-10-06), given on their first
// squad move: the profile has no `gems` yet.
const START = { gems: 600 };
const GEM_PACKS = { gems_80: 80, gems_450: 450, gems_950: 950, gems_2000: 2000, gems_5500: 5500, gems_12000: 12000 };

// --- the v6 group chests (REDESIGN_V6 step 5: Shop Screen v5, chest-loot.js) --
// Every group has a chest in five sizes. Each drops one creature of its group
// at its size's odds (the rarity nearest the roll that the group has, never a
// pass creature, nor a set reward while those are on: SET_REWARDS; unowned
// ones 3x as likely) and coins. A
// duplicate pays GDUPE coins. Common and Rare chests can upgrade on the first
// smash (UPGRADE): rolled here, at the purchase, and played by the smash.
// The Lucky meter is `epic`: an Epic or better at least every LUCK_MAX
// chests. Group chests drop no finishes (the design's grant is always
// Normal).
const SIZES = [
  { k: 'common', odds: [72, 22, 5, 1], coins: [40, 120], price: { cur: 'coins', n: 300 } },
  { k: 'rare', odds: [55, 33, 9.5, 2.5], coins: [80, 220], price: { cur: 'coins', n: 1200 } },
  { k: 'epic', odds: [30, 45, 20, 5], coins: [150, 400], price: { cur: 'gems', n: 120 } },
  { k: 'legendary', odds: [0, 50, 38, 12], coins: [300, 700], price: { cur: 'gems', n: 320 } },
  { k: 'set', odds: [0, 0, 70, 30], coins: [600, 1400], price: { cur: 'gems', n: 680 } },
];
const SIZE_I = Object.fromEntries(SIZES.map((t, i) => [t.k, i]));
const GDUPE = [60, 180, 500, 1500, 1500]; // a set reward's as a Legendary's
const LUCK_MAX = 10;
// first-smash upgrade: % chance for a Common / Rare chest; then Epic 78%,
// Legendary 19%, Rainbow the rest (Chest Smash v2's commonUp / rareUp /
// epicShare / legendaryShare)
const UPGRADE = { common: 25, rare: 35, epic: 78, legendary: 19 };
const FREE_MS = 4 * 3600e3;
const AD_CHESTS = 3;
const GDEAL = { gems: 320, was: 640, coins: 2000, size: 'legendary' };
const passXpFor = (size) => 20 + SIZE_I[size] * 15;

// --- the offers (REDESIGN_V6 step 7, ruling 2) -------------------------------
// What the Deals and Gems tabs sell is data: Firestore config/offers, read by
// the app (which draws it) and by the server (verifyPurchase grants a bought
// offer from it; the pass and the streak are squad moves that read it too).
// So offers, their contents, badges, timers and order change without an app
// update. Prices are the stores' own, for the product an offer names. This
// is the design's set, used until config/offers exists (and to seed it:
// tools/admin/offers.mjs).
//   offers[]  { id, kind: 'bundle' | 'jar' | 'pass' | 'noads', product,
//               usd (the label until the store's price loads),
//               consumable, enabled, order, name, tag, off, was, style,
//               once, windowHours (one-time offers: shown that long from
//               the player's first sight), gems, coins, chests: [size],
//               max, per (the jar: up to `max` gems, one per `per` coins
//               earned), season, ends (the pass) } — an offer with a
//               negative order shows above the daily streak
//   packs[]   { product, gems, name, tag, icons } — the Gems tab
//   pass      { season, name, ends, nodes: [{ xp, k: 'coins'|'gems'|'chest',
//               n, t (a chest's size), prem }] }
//   streak    [{ k, n, t }] — the 7 days
const DEFAULT_OFFERS = {
  v: 1,
  offers: [
    { id: 'starter', kind: 'bundle', product: 'offer_starter', usd: 1.99, consumable: false, enabled: true, order: 1, name: 'Starter pack', off: '80% OFF', was: '$9.99', tag: 'BEST VALUE', style: 'green', once: true, windowHours: 48, gems: 500, coins: 5000, chests: ['epic'] },
    { id: 'collector', kind: 'bundle', product: 'offer_collector', usd: 9.99, consumable: true, enabled: true, order: 2, name: 'Collector bundle', off: '60% OFF', was: '$24.99', tag: 'MOST POPULAR', style: 'blue', gems: 1200, coins: 10000, chests: ['legendary'] },
    { id: 'mega', kind: 'bundle', product: 'offer_mega', usd: 19.99, consumable: true, enabled: true, order: 3, name: 'Mega bundle', off: '66% OFF', was: '$59.99', style: 'pink', gems: 2800, coins: 25000, chests: ['set', 'set'] },
    { id: 'jar', kind: 'jar', product: 'offer_gem_jar', usd: 2.99, consumable: true, enabled: true, order: 0, name: 'Gem jar', max: 1500, per: 25 },
    { id: 'pass', kind: 'pass', product: 'offer_pass_spooky', usd: 1.99, consumable: false, enabled: true, order: 4 },
    // first, above the daily streak (a negative order); $0.99 (user, 2026-10-24)
    { id: 'noads', kind: 'noads', product: 'remove_ads', consumable: false, enabled: true, order: -1, name: 'Remove ads', tag: 'BEST DEAL' },
  ],
  packs: [
    { product: 'gems_80', gems: 80, name: 'Handful', icons: 1 },
    { product: 'gems_450', gems: 500, name: 'Pouch', tag: 'MOST POPULAR', icons: 2 },
    { product: 'gems_950', gems: 1200, name: 'Bag', icons: 3 },
    { product: 'gems_2000', gems: 2500, name: 'Treasure', tag: 'BEST VALUE', icons: 3 },
    { product: 'gems_5500', gems: 6500, name: 'Vault', icons: 4 },
    { product: 'gems_12000', gems: 14000, name: 'Mountain', icons: 5 },
  ],
  pass: {
    season: 'spooky',
    name: 'Spooky Squish season pass',
    ends: '2026-10-31T23:59:00Z',
    nodes: [
      { xp: 0, k: 'coins', n: 300 },
      { xp: 100, k: 'chest', t: 'common', prem: true },
      { xp: 250, k: 'gems', n: 80 },
      { xp: 450, k: 'chest', t: 'rare', prem: true },
      { xp: 700, k: 'chest', t: 'epic' },
      { xp: 1000, k: 'chest', t: 'legendary', prem: true },
    ],
  },
  streak: [{ k: 'coins', n: 200 }, { k: 'gems', n: 30 }, { k: 'chest', t: 'common' }, { k: 'coins', n: 500 }, { k: 'gems', n: 60 }, { k: 'chest', t: 'rare' }, { k: 'chest', t: 'epic' }],
};
// config/offers as read (anything missing or broken falls back to the design's)
function offersOf(cfg) {
  const c = cfg && typeof cfg === 'object' ? cfg : {};
  return {
    offers: Array.isArray(c.offers) ? c.offers.filter((o) => o && o.id && o.kind) : DEFAULT_OFFERS.offers,
    packs: Array.isArray(c.packs) ? c.packs.filter((x) => x && x.product && x.gems > 0) : DEFAULT_OFFERS.packs,
    pass: c.pass && Array.isArray(c.pass.nodes) ? c.pass : DEFAULT_OFFERS.pass,
    streak: Array.isArray(c.streak) && c.streak.length ? c.streak : DEFAULT_OFFERS.streak,
  };
}
// The gem jar: one gem per `per` coins earned since it was last broken.
function jarGems(p, jar) {
  if (!jar) return 0;
  return Math.max(0, Math.min(num(jar.max) || 1500, Math.floor((num(p.totalEarned) - num(p.jarBase)) / (num(jar.per) || 25))));
}

// --- reading a profile -------------------------------------------------------

const num = (n) => (typeof n === 'number' && Number.isFinite(n) ? n : 0);
const colOf = (p) => (p && p.col && typeof p.col === 'object' ? p.col : {});
const owns = (p, id) => !!colOf(p)[id] || ((p && p.ownedIds) || []).includes(id);
const entryOf = (p, id) => colOf(p)[id] || (owns(p, id) ? { f: { n: 1 }, eq: 'n', st: 0 } : null);

// The day's number from its 'YYYY-MM-DD' (the player's own day).
const dayNumber = (day) => Math.floor(Date.parse(`${day}T00:00:00Z`) / 864e5) || 0;

// Today's three HOT groups (the design's seeded shuffle of every group but
// the season, then the first three that are out), the same for app and
// server: [0] gives the free chest and the daily deal, [1] the ad chest, [2]
// the streak's chests.
function lineup(day, hidden = HIDDEN) {
  const d = dayNumber(day);
  const keys = GROUPS.map((g) => g.key).filter((k) => k !== SEASON.key);
  let seed = ((d % 233280) * 9301 + 49297) % 233280;
  const rnd = () => (seed = (seed * 9301 + 49297) % 233280) / 233280;
  for (let i = keys.length - 1; i > 0; i--) {
    const j = Math.floor(rnd() * (i + 1));
    [keys[i], keys[j]] = [keys[j], keys[i]];
  }
  return keys.filter((k) => groupOut(k, hidden)).slice(0, 3);
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
function roll(p, tier, artIds, random, setRewards = SET_REWARDS) {
  const T = CHESTS[tier];
  if (T.fixed) return { id: T.fixed, rar: BY_ID[T.fixed].rar, f: 'n', pity: num(p.pity), epic: num(p.epic) };
  let pity = num(p.pity) + (T.gp ? 1 : 0);
  let epic = num(p.epic) + 1;
  let r = pickWeighted(T.odds, random);
  if (T.gp && pity >= PITY_MAX) r = 3;
  if (r < 2 && epic >= EPIC_MAX) r = 2;
  if (r === 3) pity = 0;
  if (r >= 2) epic = 0;
  const inChest = (c) => (T.season ? c.season && !c.pass : c.base || (c.reward && !setRewards)) && artIds.includes(c.id);
  let pool = ROSTER.filter((c) => inChest(c) && dropRar(c) === r);
  if (!pool.length) {
    // nothing with art at that rarity: the best rarity below it that has some
    const lower = ROSTER.filter((c) => inChest(c) && dropRar(c) <= r);
    const top = Math.max(-1, ...lower.map(dropRar));
    pool = lower.filter((c) => dropRar(c) === top);
  }
  if (!pool.length) return null;
  // creatures not owned yet are 3× as likely
  const c = pool[pickWeighted(pool.map((x) => (owns(p, x.id) ? 1 : 3)), random)];
  const m = T.fx || 1;
  const fr = random() * 100;
  const f = fr < FIN.g.odds * m ? 'g' : fr < (FIN.g.odds + FIN.r.odds) * m ? 'r' : fr < (FIN.g.odds + FIN.r.odds + FIN.s.odds) * m ? 's' : 'n';
  return { id: c.id, rar: r, f, pity: Math.min(PITY_MAX, pity), epic };
}

// Adds a pull of creature `id` in finish `f`: a copy of one not unlocked yet
// (it unlocks with its last copy: `isNew`), a new finish, or a duplicate
// (coins). `whole`: it unlocks at once (the welcome chest);
// `need`: the copy counts (COPIES, or config/roster's). The result says
// `copies` / `need` for one not owned before. With `setRewards`, a set's last
// member also brings its reward.
function grant(p, id, f = 'n', dupe = DUPE, setRewards = SET_REWARDS, { whole = false, need = COPIES } = {}) {
  const c = BY_ID[id];
  const col = colOf(p);
  const e = entryOf(p, id);
  const out = { id, isNew: !e, newFinish: false, coins: 0, reward: null };
  const set = {};
  const owned = new Set(p.ownedIds || []);
  if (!e) {
    const all = needOf(c, need);
    const n = whole ? all : Math.min(all, copiesHad(p, id) + 1);
    out.copies = n;
    out.need = all;
    const rest = { ...(p.copies || {}) };
    if (n < all) {
      // one more copy; not in the squad yet (a finish isn't kept)
      out.isNew = false;
      set.copies = { ...rest, [id]: n };
      return { set, result: out };
    }
    if (id in rest) {
      delete rest[id];
      set.copies = rest;
    }
    set[`col.${id}`] = { f: f === 'n' ? { n: 1 } : { n: 1, [f]: 1 }, eq: f, st: 0 };
    owned.add(id);
  } else if (!e.f[f]) {
    set[`col.${id}`] = { ...e, f: { ...e.f, [f]: 1 } };
    out.newFinish = true;
  } else out.coins = (dupe[c.rar] || 0) * (f !== 'n' ? 2 : 1);
  let coins = num(p.coins) + out.coins;
  if (c.base && setRewards) {
    const s = SET_OF[c.set];
    const has = (x) => x === id || owns(p, x);
    if (s.reward && !col[s.reward] && !owned.has(s.reward) && s.ids.every(has)) {
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

function openChest(p, { tier, artIds, random = Math.random, setRewards, need }) {
  if (!CHESTS[tier]) return bad('unknown_chest');
  const have = num((p.chestBag || {})[tier]);
  if (have <= 0) return bad('no_chest');
  const pull = roll(p, tier, artIds, random, setRewards);
  if (!pull) return bad('empty_chest');
  const g = grant(p, pull.id, pull.f, DUPE, setRewards, { whole: !!CHESTS[tier].fixed, need });
  return {
    set: { ...g.set, chestBag: { ...p.chestBag, [tier]: have - 1 }, pity: pull.pity, epic: pull.epic, chestOpens: num(p.chestOpens) + 1, tierPulls: pulled(p, pull) },
    result: { ...g.result, tier, rar: pull.rar, f: pull.f },
  };
}

// One group chest: the upgrade, the size's rarity (the Lucky meter can lift
// it to Epic), the creature, the coins inside. `fixed`: the creature it holds
// (the welcome chest's), with no upgrade and no Lucky meter.
function rollGroup(p, group, size, artIds, random, fixed, setRewards = SET_REWARDS) {
  if (fixed) {
    const T = SIZES[SIZE_I[size]];
    const coins = Math.round((T.coins[0] + random() * (T.coins[1] - T.coins[0])) / 10) * 10;
    return { final: T.k, id: fixed, rar: BY_ID[fixed].rar, epic: num(p.epic), luck: false, coins };
  }
  let to = SIZE_I[size];
  if ((size === 'common' || size === 'rare') && random() * 100 < UPGRADE[size]) {
    const r = random() * 100;
    to = r < UPGRADE.epic ? 2 : r < UPGRADE.epic + UPGRADE.legendary ? 3 : 4;
  }
  const T = SIZES[to];
  const due = num(p.epic) + 1 >= LUCK_MAX;
  let r = pickWeighted(T.odds, random);
  if (due && r < 2) r = 2;
  const ok = (c) => inGroupChest(c, group, setRewards) && artIds.includes(c.id);
  let c = null;
  for (let d = 0; d < 4 && !c; d++) {
    for (const rr of [r - d, r + d]) {
      const pool = ROSTER.filter((x) => ok(x) && dropRar(x) === rr);
      if (pool.length) {
        c = pool[pickWeighted(pool.map((x) => (owns(p, x.id) ? 1 : 3)), random)];
        break;
      }
    }
  }
  const coins = Math.round((T.coins[0] + random() * (T.coins[1] - T.coins[0])) / 10) * 10;
  return { final: T.k, id: c ? c.id : null, rar: c ? c.rar : r, epic: r >= 2 ? 0 : Math.min(LUCK_MAX, num(p.epic) + 1), luck: due && r >= 2, coins };
}

// Opens a group chest for `p` (already charged): `extra` is what the move
// itself writes (the price paid, a timer). Coins: the chest's, plus a
// duplicate's or a finished set's. The creature is one more copy of it
// (`whole`: the creature itself, as the welcome chest gives Mittens).
function openGroup(p, group, size, { artIds, random = Math.random, fixed, whole, setRewards, need }, extra = {}) {
  const pull = rollGroup(p, group, size, artIds, random, fixed, setRewards);
  const withCoins = { ...p, coins: num(p.coins) + pull.coins };
  const g = pull.id ? grant(withCoins, pull.id, 'n', GDUPE, setRewards, { whole, need }) : { set: {}, result: { coins: 0, isNew: false, reward: null } };
  const set = {
    ...extra,
    ...g.set,
    coins: g.set.coins != null ? g.set.coins : withCoins.coins,
    epic: pull.epic,
    chestOpens: num(p.chestOpens) + 1,
    passXp: num(p.passXp) + passXpFor(pull.final),
  };
  if (pull.id) set.tierPulls = pulled(p, { rar: pull.rar, f: 'n' });
  const bonus = g.result.reward ? SET_BONUS : 0;
  return {
    set,
    result: { group, size, final: pull.final, upgraded: pull.final !== size, id: pull.id, rar: pull.rar, isNew: !!g.result.isNew, copies: g.result.copies || null, need: g.result.need || null, coins: pull.coins, dupeCoins: g.result.coins - bonus, reward: g.result.reward, setBonus: bonus, luck: pull.luck },
  };
}

const GROUP_KEYS = GROUPS.map((g) => g.key);

// A coins / gems / chest reward (the pass's and the streak's): the profile
// changes, and a chest's result for the smash. Chests are of `group`.
function giveReward(p, r, group, args) {
  if (r.k === 'coins') return { set: { coins: num(p.coins) + num(r.n), totalEarned: num(p.totalEarned) + num(r.n) }, result: { kind: 'coins', n: num(r.n) } };
  if (r.k === 'gems') return { set: { gems: num(p.gems) + num(r.n) }, result: { kind: 'gems', n: num(r.n) } };
  if (r.k === 'chest' && SIZE_I[r.t] != null) {
    const o = openGroup(p, group, r.t, args);
    return { set: o.set, result: { kind: 'chest', chest: o.result } };
  }
  return null;
}

// Claiming a season-pass reward: the XP reached, the pass bought for a
// gold one (`prem`), once each; chests are the season's.
function passClaim(p, args) {
  const { pass } = offersOf(args.offers);
  const i = Number(args.i);
  const node = pass.nodes[i];
  if (!node) return bad('unknown_reward');
  if (pass.ends && args.now > Date.parse(pass.ends)) return bad('season_over');
  const got = ((p.passGot || {})[pass.season] || {});
  if (got[i]) return bad('claimed');
  if (num(p.passXp) < num(node.xp)) return bad('need_xp');
  if (node.prem && !(p.passPrem || {})[pass.season]) return bad('need_pass');
  const g = giveReward(p, node, SEASON.key, args);
  if (!g) return bad('unknown_reward');
  return { set: { ...g.set, passGot: { ...(p.passGot || {}), [pass.season]: { ...got, [i]: true } } }, result: { ...g.result, i } };
}

// The Deals tab's daily streak: one reward a day, the 7 in turn; a missed day
// starts it over. Chests are of today's third HOT group.
function streakClaim(p, args) {
  const { streak } = offersOf(args.offers);
  const d = dayNumber(args.day);
  const st = p.shopStreak || { count: 0, last: null };
  if (st.last === args.day) return bad('claimed');
  const kept = st.last && dayNumber(st.last) === d - 1;
  const count = kept ? num(st.count) : 0;
  const r = streak[count % streak.length];
  const g = giveReward(p, r, lineup(args.day, args.hidden)[2], args);
  if (!g) return bad('unknown_reward');
  return { set: { ...g.set, shopStreak: { count: count + 1, last: args.day } }, result: { ...g.result, day: (count % streak.length) + 1 } };
}

// Buying a group chest of a size (of a group that's out): it opens at once.
function groupChest(p, args) {
  const { group, size } = args;
  if (!GROUP_KEYS.includes(group) || !groupOut(group, args.hidden) || SIZE_I[size] == null) return bad('unknown_chest');
  const T = SIZES[SIZE_I[size]];
  const paid = pay(p, T.price.cur, T.price.n);
  if (!paid) return bad(T.price.cur === 'gems' ? 'not_enough_gems' : 'not_enough_coins');
  return openGroup({ ...p, ...paid }, group, size, args, paid);
}

// A new player's first free chest is the welcome chest (the tutorial's): a
// Common of Mittens' group that always holds Mittens.
const WELCOME_ID = '1';
const isWelcome = (p) => !owns(p, WELCOME_ID) && !num(p.chestOpens);

// The free chest: a Common of today's first HOT group, every FREE_MS. A
// streak's chest day adds one more (`freeBonus`), used while the timer runs.
function freeChest(p, args) {
  const timed = num(p.freeAt) <= args.now;
  if (!timed && !num(p.freeBonus)) return bad('not_yet');
  const extra = timed ? { freeAt: args.now + FREE_MS } : { freeBonus: num(p.freeBonus) - 1 };
  if (isWelcome(p)) return openGroup(p, BY_ID[WELCOME_ID].set, 'common', { ...args, fixed: WELCOME_ID, whole: true }, extra);
  return openGroup(p, lineup(args.day, args.hidden)[0], 'common', args, extra);
}

// The ad chest: a Rare of the second HOT group, AD_CHESTS a day (the app
// plays the video first; with Remove Ads there's none).
function adChest(p, args) {
  const n = p.adChests && p.adChests.day === args.day ? num(p.adChests.n) : 0;
  if (n >= AD_CHESTS) return bad('no_videos_left');
  return openGroup(p, lineup(args.day, args.hidden)[1], 'rare', args, { adChests: { day: args.day, n: n + 1 } });
}

// The daily deal: a Legendary of the first HOT group and 2,000 coins, at
// half price, once a day.
function dealChest(p, args) {
  if (p.dealDay === args.day) return bad('deal_used');
  const paid = pay(p, 'gems', GDEAL.gems);
  if (!paid) return bad('not_enough_gems');
  return openGroup({ ...p, ...paid, coins: num(p.coins) + GDEAL.coins }, lineup(args.day, args.hidden)[0], GDEAL.size, args, { ...paid, dealDay: args.day });
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
  return { p: { ...p, ...set }, set };
}

// The daily chest's gift (once a day, with the coins the app adds itself):
// the streak day's own server-side reward — gems (`gems`, up to 20) or an
// extra free chest in the Shop (`chest`).
function dailyGift(p, { day, reward }) {
  if (p.giftDay === day) return bad('gift_used');
  const set = { giftDay: day };
  const gems = reward && reward.kind === 'gems' ? Math.max(0, Math.min(20, Math.floor(num(reward.amount)))) : 0;
  if (gems) set.gems = num(p.gems) + gems;
  if (reward && reward.kind === 'chest') set.freeBonus = num(p.freeBonus) + 1;
  return { set, result: { gems, chest: reward && reward.kind === 'chest' ? 'free' : null } };
}

// `start`: only the starting gems (the app calls it on sign-in).
const start = (p) => ({ set: {}, result: { gems: num(p.gems) } });

// (no buyCreature: squishies aren't sold for coins any more, 2026-10-24)
const MOVES = { start, dailyGift, buyChest, videoChest, openChest, grow, equip, swap, groupChest, freeChest, adChest, dealChest, passClaim, streakClaim };

module.exports = {
  RARITY,
  GROUPS,
  SETS,
  SEASON,
  ROSTER,
  BY_ID,
  SET_OF,
  HIDDEN,
  hiddenOf,
  isOut,
  groupOut,
  outIds,
  SET_REWARDS,
  setRewardsOf,
  COPIES,
  copiesOf,
  needOf,
  copiesHad,
  dropRar,
  inGroupChest,
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
  SIZES,
  SIZE_I,
  GDUPE,
  LUCK_MAX,
  UPGRADE,
  FREE_MS,
  AD_CHESTS,
  GDEAL,
  lineup,
  rollGroup,
  openGroup,
  DEFAULT_OFFERS,
  offersOf,
  jarGems,
  withStart,
  owns,
  roll,
  grant,
  MOVES,
};
