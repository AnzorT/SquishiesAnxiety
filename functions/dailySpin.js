// Daily Spin — the rules, kept free of Firebase so they can be tested alone.
// The spinWheel function in index.js applies them to the player's profile.
//
// The wheel is the "Squish Squad App" shell's (2026-10-08): eight slices of
// coins and gems, each with its own weight (out of 100). The app
// draws the same eight in the same order (src/dailySpin.js) — change both
// together.

const WHEEL = [
  { kind: 'coins', amount: 100, weight: 22 },
  { kind: 'gems', amount: 5, weight: 18 },
  { kind: 'coins', amount: 250, weight: 14 },
  { kind: 'coins', amount: 150, weight: 14 },
  { kind: 'coins', amount: 50, weight: 20 },
  { kind: 'gems', amount: 15, weight: 7 },
  { kind: 'coins', amount: 500, weight: 4 },
  { kind: 'gems', amount: 50, weight: 1 }, // the JACKPOT
];
const JACKPOT_GEMS = 50;
// After the day's free spin, one more for a rewarded video ("Watch ad, spin
// again"), counted per day in `adSpins: { day, n }`.
const MAX_AD_SPINS = 1;
// Time zones run from UTC-12 to UTC+14.
const MAX_OFFSET_MIN = 14 * 60;

// r in [0, 1) → a slice index, by weight
function rollWheel(r = Math.random()) {
  const total = WHEEL.reduce((a, w) => a + w.weight, 0);
  let left = r * total;
  for (let i = 0; i < WHEEL.length; i++) {
    if (left < WHEEL[i].weight) return i;
    left -= WHEEL[i].weight;
  }
  return WHEEL.length - 1;
}

// The player's local calendar day ("2026-09-28"). The app sends its UTC
// offset; it's clamped to real time zones, and a spin is only allowed on a
// later day than the last one, so changing it can't buy more than one extra
// spin.
function dayKey(nowMs, offsetMinutes) {
  const off = Math.max(-MAX_OFFSET_MIN, Math.min(MAX_OFFSET_MIN, Math.round(Number(offsetMinutes) || 0)));
  return new Date(nowMs + off * 60000).toISOString().slice(0, 10);
}

// What one spin pays. Returns { result, changes }: `result` goes back to
// the app; `changes` holds the amounts to add (the caller writes them).
function spinOutcome({ day, index }) {
  const slice = WHEEL[index];
  const result = { index, kind: slice.kind, amount: slice.amount, day };
  const changes = { lastSpinDay: day, spins: 1, coins: 0, gems: 0, jackpot: false };
  changes[slice.kind] = slice.amount;
  if (slice.kind === 'gems' && slice.amount >= JACKPOT_GEMS) {
    result.jackpot = true;
    changes.jackpot = true;
  }
  return { result, changes };
}

// May the player spin today? The free spin once a day; a video spin
// (`bonus`) only after it, up to MAX_AD_SPINS a day. Returns the fields to
// write besides the prize's, or null.
function spinAllowed(profile = {}, day, bonus = false) {
  const spunToday = !!profile.lastSpinDay && day <= profile.lastSpinDay;
  if (!bonus) return spunToday ? null : { lastSpinDay: day };
  if (!spunToday) return null;
  const used = profile.adSpins && profile.adSpins.day === day ? Math.max(0, Math.floor(profile.adSpins.n || 0)) : 0;
  return used < MAX_AD_SPINS ? { adSpins: { day, n: used + 1 } } : null;
}

module.exports = { WHEEL, MAX_AD_SPINS, rollWheel, dayKey, spinOutcome, spinAllowed };
