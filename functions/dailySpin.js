// Daily Spin — the rules, kept free of Firebase so they can be tested alone.
// The spinWheel function in index.js applies them to the player's profile.
//
// The wheel is the v3 design's: eight slices, six of coins and two rare
// prizes. The app draws the same eight in the same order
// (src/dailySpin.js) — change both together.

const WHEEL = [
  { kind: 'coins', amount: 60 },
  { kind: 'coins', amount: 120 },
  { kind: 'create' }, // 15% off the next custom creature
  { kind: 'coins', amount: 200 },
  { kind: 'coins', amount: 80 },
  { kind: 'unlock' }, // a free creature
  { kind: 'coins', amount: 150 },
  { kind: 'coins', amount: 300 },
];

// As in the design: 0.1% CREATE, 0.1% FREE creature, the rest split evenly
// over the six coin slices.
const CREATE_ODDS = 0.001;
const UNLOCK_ODDS = 0.001;
const CREATE_DISCOUNT_PCT = 15;
// FREE creature when every creature is already owned (the design's
// fallback).
const ALL_OWNED_COINS = 2000;
// Time zones run from UTC-12 to UTC+14.
const MAX_OFFSET_MIN = 14 * 60;

function rollWheel(r = Math.random()) {
  if (r < CREATE_ODDS) return WHEEL.findIndex((w) => w.kind === 'create');
  if (r < CREATE_ODDS + UNLOCK_ODDS) return WHEEL.findIndex((w) => w.kind === 'unlock');
  const coinSlots = WHEEL.map((w, i) => (w.kind === 'coins' ? i : -1)).filter((i) => i >= 0);
  const u = (r - CREATE_ODDS - UNLOCK_ODDS) / (1 - CREATE_ODDS - UNLOCK_ODDS);
  return coinSlots[Math.min(coinSlots.length - 1, Math.floor(u * coinSlots.length))];
}

// The player's local calendar day ("2026-09-28"). The app sends its UTC
// offset; it's clamped to real time zones, and a spin is only allowed on a
// later day than the last one, so changing it can't buy more than one extra
// spin.
function dayKey(nowMs, offsetMinutes) {
  const off = Math.max(-MAX_OFFSET_MIN, Math.min(MAX_OFFSET_MIN, Math.round(Number(offsetMinutes) || 0)));
  return new Date(nowMs + off * 60000).toISOString().slice(0, 10);
}

// What one spin changes on the profile. `profile` is the users/{uid} doc,
// `rosterIds` the catalog's creature ids. Returns { result, changes }:
// `result` goes back to the app; `changes` describes the write (plain
// numbers/ids, turned into Firestore increments by the caller).
function spinOutcome({ profile, rosterIds, day, index, pick = Math.random }) {
  const slice = WHEEL[index];
  const result = { index, kind: slice.kind, day };
  const changes = { lastSpinDay: day, spins: 1, coins: 0, jackpot: false, unlockId: null, discountPct: null };
  if (slice.kind === 'coins') {
    result.amount = slice.amount;
    changes.coins = slice.amount;
  } else if (slice.kind === 'create') {
    result.discountPct = CREATE_DISCOUNT_PCT;
    changes.discountPct = CREATE_DISCOUNT_PCT;
    changes.jackpot = true;
  } else {
    const owned = new Set(profile.ownedIds || []);
    const locked = rosterIds.filter((id) => !owned.has(id));
    changes.jackpot = true;
    if (locked.length) {
      const id = locked[Math.floor(pick() * locked.length) % locked.length];
      result.creatureId = id;
      result.lockedIds = locked; // what the app's reel spins through
      changes.unlockId = id;
    } else {
      result.allOwned = true;
      result.amount = ALL_OWNED_COINS;
      changes.coins = ALL_OWNED_COINS;
    }
  }
  return { result, changes };
}

module.exports = { WHEEL, CREATE_DISCOUNT_PCT, rollWheel, dayKey, spinOutcome };
