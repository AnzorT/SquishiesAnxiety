import { tierOf } from './theme/candyTheme';
import { STARTER_CREATURE_IDS } from './data/creatures';

// How creatures unlock. Glorp (#0) is free; every other creature has its own
// TOKENS, and its key comes one of two ways (then hold its Home card to
// unlock it):
//
//  · TOKENS — a Mystery Box gives 1, 2 or 3 tokens of one locked creature.
//    Which creature: first a rarity (rarityOdds — a rarity with nothing
//    left to unlock is skipped), then a random locked creature of it. A full
//    set puts the key on its card by itself. A creature's price climbs
//    along the roster: firstPrice for #1 Puffle, +priceStep for each one
//    after (30, 35, 40 … Cosmo 120). The very first box ever fills Puffle's
//    set, so a new player unlocks one straight away.
//  · $0.99 — the key through Google Play / the App Store (verified by the
//    verifyPurchase Cloud Function), one price for every creature.
//
// Coins don't buy creatures: they buy Mystery Boxes (src/mysteryBox.js).
//
// The numbers live in Firestore, `config/mysteryBox` (read-only for the app,
// edited in the Firebase console), so they can be tuned without an app
// update; BOX_DEFAULTS is used until that document exists, and for any field
// it leaves out. At the defaults (a simulation of an engaged player: 1,500
// coins a day into boxes plus the two daily boxes) the second creature comes
// on day ~64 and all 19 in ~7½ months; a casual player takes ~a year.

export const BOX_DEFAULTS = {
  // which rarity a box's tokens come from, in percent
  rarityOdds: { Common: 50, Rare: 28, Epic: 13, Legendary: 6, Rainbow: 2, Golden: 1 },
  // how many tokens a box gives, in percent
  tokenOdds: { 1: 80, 2: 17, 3: 3 },
  // tokens for #1 Puffle, and how many more each creature after it needs
  firstPrice: 30,
  priceStep: 5,
};

// A box with no locked creature to give tokens for (the rest are keyed and
// waiting to be unlocked) pays coins.
export const SPARE_BOX_COINS = 150;

// Google Play / App Store product ids — the same in both stores (create
// them with these ids; see REDESIGN_V3.md). The labels are fallbacks until
// the store's own localized prices load.
export const PRODUCTS = {
  creatureKey: { id: 'creature_key', fallbackPrice: '$0.99' },
  removeAds: { id: 'remove_ads', fallbackPrice: '$1.99' },
  creation: { id: 'creature_creation', fallbackPrice: '$4.99' },
  creationDiscount: { id: 'creature_creation_15off', fallbackPrice: '$4.24' },
};

// Without ads, a ×N boost starts straight away; this recharge after each
// one keeps the same pace as watching the video would.
export const AD_FREE_BOOST_RECHARGE_MS = 30000;

// --- the box settings (config/mysteryBox) -----------------------------------

const positive = (n) => typeof n === 'number' && Number.isFinite(n) && n >= 0;
function oddsOr(given, fallback) {
  if (!given || typeof given !== 'object') return fallback;
  const out = {};
  Object.keys(fallback).forEach((k) => {
    out[k] = positive(given[k]) ? given[k] : fallback[k];
  });
  return Object.values(out).some((v) => v > 0) ? out : fallback;
}

let settings = BOX_DEFAULTS;

// App calls this with the config/mysteryBox document (or null) whenever it
// changes. Anything missing or malformed falls back to BOX_DEFAULTS.
export function setBoxSettings(doc) {
  const d = doc || {};
  settings = {
    rarityOdds: oddsOr(d.rarityOdds, BOX_DEFAULTS.rarityOdds),
    tokenOdds: oddsOr(d.tokenOdds, BOX_DEFAULTS.tokenOdds),
    firstPrice: positive(d.firstPrice) && d.firstPrice >= 1 ? Math.round(d.firstPrice) : BOX_DEFAULTS.firstPrice,
    priceStep: positive(d.priceStep) ? Math.round(d.priceStep) : BOX_DEFAULTS.priceStep,
  };
}

export function boxSettings() {
  return settings;
}

// --- creatures and tokens ---------------------------------------------------

// A roster creature's place (0 Glorp … 19 Cosmo), or null for custom ones.
function rosterNumber(creatureId) {
  if (!tierOf(creatureId)) return null;
  return Number(creatureId);
}

// A roster creature that can be locked (Glorp never is).
export function isUnlockable(creature) {
  const n = creature ? rosterNumber(creature.id) : null;
  return n != null && !STARTER_CREATURE_IDS.includes(creature.id);
}

// Tokens needed for a creature's key.
export function tokenPrice(creatureId) {
  const n = rosterNumber(creatureId);
  return n ? settings.firstPrice + settings.priceStep * (n - 1) : 0;
}

export function tokenCount(profile, creatureId) {
  return Math.max(0, Math.min(tokenPrice(creatureId), Math.floor(profile?.tokens?.[creatureId] ?? 0)));
}

// Owned, or its key is waiting to be redeemed on the Home card.
export function isSettled(profile, creatureId) {
  return !!profile?.ownedIds?.includes(creatureId) || profile?.keys?.[creatureId] === true;
}

// Creatures a box can still give tokens for, cheapest first.
export function tokenCandidates(creatures = [], profile) {
  return creatures.filter((c) => isUnlockable(c) && !isSettled(profile, c.id)).sort((a, b) => tokenPrice(a.id) - tokenPrice(b.id));
}

function roll(odds, random) {
  const keys = Object.keys(odds).filter((k) => odds[k] > 0);
  let r = random() * keys.reduce((s, k) => s + odds[k], 0);
  for (const k of keys) {
    r -= odds[k];
    if (r <= 0) return k;
  }
  return keys[keys.length - 1];
}

// A box's creature: a rarity by rarityOdds among the rarities that still
// have a locked creature, then one of those at random. `random` is
// injectable for tests.
export function pickTokenCreature(candidates, random = Math.random) {
  if (!candidates.length) return null;
  const present = {};
  candidates.forEach((c) => {
    const t = tierOf(c.id);
    if (settings.rarityOdds[t] > 0) present[t] = settings.rarityOdds[t];
  });
  // (only if every remaining rarity is set to 0%: any locked creature)
  const tier = Object.keys(present).length ? roll(present, random) : null;
  const pool = tier ? candidates.filter((c) => tierOf(c.id) === tier) : candidates;
  return pool[Math.floor(random() * pool.length) % pool.length];
}

// How many tokens a box gives (tokenOdds), never more than `left`.
export function tokenAmount(left, random = Math.random) {
  return Math.min(left, Number(roll(settings.tokenOdds, random)));
}
