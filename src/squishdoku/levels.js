// Squishdoku's levels, timers, scoring and rewards (SQUISHDOKU.md), and
// the profile's `sdk` record they're saved in. Pure functions: the screen
// writes what they return.

export const LEVELS = 50;

// The grid size of each band, and the tier each of its levels asks for
// (0 easy, 1 medium, 2 hard, 3 expert): rising, with a breather now and then.
const BANDS = [
  { n: 4, tiers: [0, 0, 0] },
  { n: 5, tiers: [0, 0, 1, 0, 1, 1, 1] },
  { n: 6, tiers: [0, 0, 1, 1, 1, 2, 1, 2, 2, 2] },
  { n: 7, tiers: [0, 1, 1, 1, 2, 2, 1, 2, 2, 3] },
  { n: 8, tiers: [1, 1, 1, 2, 2, 1, 2, 2, 3, 3] },
  { n: 9, tiers: [1, 1, 2, 2, 1, 2, 2, 3, 2, 3] },
];
export const LEVEL_LIST = BANDS.flatMap((b) => b.tiers.map((tier) => ({ n: b.n, tier })));

// Seconds per grid size: the level's limit, and the times A (3 creatures)
// and B (2 creatures). Harder tiers get 20% more of each. First guesses —
// tune after playing (SQUISHDOKU.md).
const TIMES = {
  4: [60, 15, 30],
  5: [90, 30, 55],
  6: [150, 50, 90],
  7: [210, 75, 130],
  8: [300, 110, 185],
  9: [420, 150, 260],
};

// HEAD START (the player's choice, both modes): the first row's creature is
// placed for you. It's easier, so the clock is shorter and the coins and
// XP smaller.
export const HEAD_START = { time: 0.8, reward: 0.6 };

// Level `lv` (1-50): { lv, n, tier, limitMs, aMs, bMs, head } — `skill`
// (the profile's) moves the tier one step either way; `head` is HEAD START.
export function levelSpec(lv, skill = 0, head = false) {
  const base = LEVEL_LIST[Math.max(0, Math.min(LEVELS, lv) - 1)];
  const tier = Math.max(0, Math.min(3, base.tier + skillShift(skill)));
  const k = (1 + 0.2 * tier) * (head ? HEAD_START.time : 1);
  const [limit, a, b] = TIMES[base.n].map((s) => Math.round(s * k) * 1000);
  return { lv, n: base.n, tier, baseTier: base.tier, limitMs: limit, aMs: a, bMs: b, head: !!head };
}

// --- adaptive difficulty -------------------------------------------------------

export const SKILL_MIN = -2;
export const SKILL_MAX = 2;
export const skillShift = (skill) => (skill <= -1 ? -1 : skill >= 1.2 ? 1 : 0);
const clampSkill = (s) => Math.round(Math.max(SKILL_MIN, Math.min(SKILL_MAX, s)) * 100) / 100;

// The skill after a level: fast clean solves raise it, mistakes and running
// out of time lower it.
export function nextSkill(skill = 0, { solved, stars = 0, mistakes = 0 }) {
  if (!solved) return clampSkill(skill - 0.5);
  const gain = stars === 3 ? 0.35 : stars === 2 ? 0.15 : 0;
  return clampSkill(skill + gain - 0.12 * Math.min(3, mistakes));
}

// --- scoring --------------------------------------------------------------------

// How many creatures a solve earns (1-3), and whether it was PERFECT (no ✕
// and no mistakes — always 3).
export function starsFor(spec, { ms, mistakes, usedX }) {
  if (!mistakes && !usedX) return { stars: 3, perfect: true };
  if (mistakes) return { stars: 1, perfect: false };
  return { stars: ms <= spec.aMs ? 3 : ms <= spec.bMs ? 2 : 1, perfect: false };
}

// How many creatures are still on offer at `ms` into the level (the HUD's
// timer-creatures fall off as A and B pass, and a mistake leaves just one).
export function starsLeft(spec, ms, mistakes) {
  if (mistakes) return 1;
  return ms <= spec.aMs ? 3 : ms <= spec.bMs ? 2 : 1;
}

const BASE_COINS = { 4: 15, 5: 25, 6: 35, 7: 50, 8: 65, 9: 85 };
const STAR_MULT = [0, 1, 1.5, 2];
export const PERFECT_MULT = 3;

const headCut = (spec) => (spec.head ? HEAD_START.reward : 1);

export function coinsFor(spec, { stars, perfect }) {
  return Math.round(BASE_COINS[spec.n] * (perfect ? PERFECT_MULT : STAR_MULT[stars]) * (1 + 0.15 * spec.tier) * headCut(spec));
}

export function xpFor(spec, { stars, perfect }) {
  const base = 10 + 5 * (spec.n - 4) + 5 * spec.tier;
  return Math.round(base * (0.6 + 0.2 * stars) * (perfect ? 1.5 : 1) * headCut(spec));
}

// --- Puzzle Level (the player's XP) -------------------------------------------------

// XP to go from level L to L+1.
export const xpToNext = (L) => 100 + 50 * (L - 1);
export const levelUpCoins = (L) => 100 + 50 * L;

// { level, into, need } for a total of `xp`.
export function puzzleLevel(xp = 0) {
  let L = 1;
  let left = Math.max(0, Math.floor(xp));
  while (left >= xpToNext(L)) {
    left -= xpToNext(L);
    L++;
  }
  return { level: L, into: left, need: xpToNext(L) };
}

// --- Blitz -----------------------------------------------------------------------

export const BLITZ_SIZES = [4, 5, 5, 6, 6, 6, 6, 7, 7, 7];
const BLITZ_TIERS = [0, 0, 0, 0, 0, 1, 1, 0, 1, 1];
export const BLITZ_MS = 10 * 60 * 1000;
export const BLITZ_COINS = 1500;
export const BLITZ_XP = 400;

export function blitzSpec(i, skill = 0) {
  const tier = Math.max(0, Math.min(2, BLITZ_TIERS[i] + skillShift(skill)));
  return { lv: i + 1, n: BLITZ_SIZES[i], tier };
}

// A run's clock and prize, with or without HEAD START.
export const blitzMs = (head) => Math.round(BLITZ_MS * (head ? HEAD_START.time : 1));
export const blitzPrize = (head) => ({
  coins: Math.round(BLITZ_COINS * (head ? HEAD_START.reward : 1)),
  xp: Math.round(BLITZ_XP * (head ? HEAD_START.reward : 1)),
});

// --- the profile's record -------------------------------------------------------

export function record(profile) {
  const s = (profile && profile.sdk) || {};
  return {
    lv: Math.max(1, Math.min(LEVELS, s.lv || 1)),
    best: s.best || {},
    perfect: s.perfect || {},
    xp: s.xp || 0,
    skill: s.skill || 0,
    bSkill: s.bSkill || 0,
    blitz: { reached: 0, bestMs: 0, wins: 0, ...(s.blitz || {}) },
    plays: s.plays || 0,
    solves: s.solves || 0,
    head: !!s.head,
  };
}

// The fields to write after a Regular level, and what it paid: coins
// (the level's plus any Puzzle Level rewards), xp, and the levels gained.
export function afterLevel(profile, spec, result) {
  const rec = record(profile);
  const update = {
    'sdk.plays': rec.plays + 1,
    'sdk.skill': nextSkill(rec.skill, result),
  };
  if (!result.solved) return { update, coins: 0, xp: 0, levelUps: [], unlocked: false };
  const { stars, perfect } = result;
  const coins = coinsFor(spec, result);
  const xp = xpFor(spec, result);
  const before = puzzleLevel(rec.xp);
  const after = puzzleLevel(rec.xp + xp);
  const levelUps = [];
  for (let L = before.level + 1; L <= after.level; L++) levelUps.push({ level: L, coins: levelUpCoins(L) });
  update['sdk.solves'] = rec.solves + 1;
  update['sdk.xp'] = rec.xp + xp;
  if (stars > (rec.best[spec.lv] || 0)) update[`sdk.best.${spec.lv}`] = stars;
  if (perfect && !rec.perfect[spec.lv]) update[`sdk.perfect.${spec.lv}`] = true;
  const unlocked = spec.lv === rec.lv && rec.lv < LEVELS;
  if (unlocked) update['sdk.lv'] = rec.lv + 1;
  return { update, coins: coins + levelUps.reduce((a, u) => a + u.coins, 0), levelCoins: coins, xp, levelUps, unlocked, before, after };
}

// The fields to write after a Blitz run ends (won or not).
export function afterBlitz(profile, { won, reached, ms, head = false }) {
  const rec = record(profile);
  const update = {
    'sdk.bSkill': clampSkill(rec.bSkill + (won ? 0.4 : reached >= 6 ? 0 : -0.3)),
    'sdk.blitz.reached': Math.max(rec.blitz.reached, reached),
  };
  if (!won) return { update, coins: 0, xp: 0, levelUps: [] };
  update['sdk.blitz.wins'] = rec.blitz.wins + 1;
  if (!rec.blitz.bestMs || ms < rec.blitz.bestMs) update['sdk.blitz.bestMs'] = ms;
  const prize = blitzPrize(head);
  const before = puzzleLevel(rec.xp);
  const after = puzzleLevel(rec.xp + prize.xp);
  const levelUps = [];
  for (let L = before.level + 1; L <= after.level; L++) levelUps.push({ level: L, coins: levelUpCoins(L) });
  update['sdk.xp'] = rec.xp + prize.xp;
  return { update, coins: prize.coins + levelUps.reduce((a, u) => a + u.coins, 0), xp: prize.xp, levelUps, before, after };
}

// 1:05 / 0:09
export function clock(ms) {
  const s = Math.max(0, Math.ceil(ms / 1000));
  return `${Math.floor(s / 60)}:${String(s % 60).padStart(2, '0')}`;
}
