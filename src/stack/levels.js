// Squish Stack's levels, difficulty, scoring and rewards (SQUISH_STACK.md),
// and the profile's `stack` record they're saved in. Pure functions: the
// screen writes what they return.
//
// Like Squishdoku and Squish Sort: 50 levels in bands of one size (squishies
// × cushions), each level asking for a difficulty tier (0 easy, 1 medium,
// 2 hard, 3 expert) that rises inside its band, with breathers in between.
// A hidden skill score moves the tier one step either way (adaptive
// difficulty); the size never changes. The tier sets how many moves the best
// answer takes (the par) and whether the goal is a picture. Wins pay coins
// and the player's XP (src/playerXp.js, PLAYER_XP.md).
import { addXp, gameXp, winXp, xpRules } from '../playerXp.js';

export const LEVELS = 50;

// par: the best answer's length [lo, hi] for each tier. The 4th cushion makes
// towers much shorter, so band 5 is a breather after the long 5-on-3 ones.
const BANDS = [
  { n: 3, k: 3, tiers: [0, 0, 0], par: [[3, 5], [5, 7], [6, 7], [7, 7]] }, //  1-3
  { n: 4, k: 3, tiers: [0, 0, 1, 0, 1], par: [[6, 9], [9, 12], [12, 15], [14, 15]] }, //  4-8
  { n: 4, k: 3, tiers: [0, 1, 1, 0, 1, 2], par: [[7, 10], [9, 12], [11, 14], [13, 15]] }, //  9-14
  { n: 5, k: 3, tiers: [0, 1, 1, 2, 1, 2, 2], par: [[10, 14], [13, 18], [17, 22], [21, 26]] }, // 15-21
  { n: 5, k: 4, tiers: [0, 1, 2, 1, 2, 2, 3], par: [[6, 8], [7, 9], [9, 11], [10, 13]] }, // 22-28
  { n: 6, k: 4, tiers: [1, 1, 2, 1, 2, 3, 2, 3], par: [[9, 11], [11, 13], [12, 15], [14, 17]] }, // 29-36
  { n: 7, k: 4, tiers: [1, 2, 2, 1, 2, 3, 3], par: [[12, 15], [14, 17], [16, 19], [18, 22]] }, // 37-43
  { n: 8, k: 4, tiers: [1, 2, 2, 3, 2, 3, 3], par: [[15, 19], [18, 22], [21, 25], [24, 28]] }, // 44-50
];
export const LEVEL_LIST = BANDS.flatMap((b, band) => b.tiers.map((tier) => ({ band, n: b.n, k: b.k, tier })));

export const TIER_NAMES = ['EASY', 'MEDIUM', 'HARD', 'EXPERT'];
export const TIER_COLORS = ['#3ddc97', '#5fb8ff', '#ff8a4a', '#e01e4a'];

// The classic: everyone starts on the first cushion and goes to the last. On
// level 1, and when a band brings a new size (4 squishies, a 4th cushion, 6).
const TOWERS = [1, 4, 22, 29];
// the goal card's first level (before it, every goal is one ★ cushion)
export const PICTURE_FROM = 9;
// "for a certain level it will start a timer" (the user, 2026-10-24)
export const CLOCK_FROM = 15;

// Level `lv` (1-50) at a skill: { lv, band, n, k, tier, baseTier, start,
// goal, par, clock, news }.
//   start  'tower' or 'scrambled' (engine.makePuzzle)
//   goal   'star' (everyone on one cushion) or 'picture' (the goal card)
//   news   what's new on this level, said before it starts
export function levelSpec(lv, skill = 0) {
  const L = Math.max(1, Math.min(LEVELS, Math.floor(lv) || 1));
  const b = LEVEL_LIST[L - 1];
  const band = BANDS[b.band];
  const tier = Math.max(0, Math.min(3, b.tier + skillShift(skill)));
  const tower = TOWERS.includes(L);
  const picture = !tower && L >= PICTURE_FROM && (tier >= 2 || (tier === 1 && L % 2 === 1));
  let news = null;
  if (L === PICTURE_FROM) news = 'picture';
  else if (L === CLOCK_FROM) news = 'clock';
  else if (L > 1 && b.k > LEVEL_LIST[L - 2].k) news = 'cushion';
  return {
    lv: L,
    band: b.band,
    n: b.n,
    k: b.k,
    tier,
    baseTier: b.tier,
    start: tower ? 'tower' : 'scrambled',
    goal: tower ? 'star' : picture ? 'picture' : 'star',
    par: band.par[tier],
    clock: L >= CLOCK_FROM,
    news,
  };
}

// The clock for a puzzle whose best answer is `par` moves: generous, but it
// runs out (thinking time up front, then a few seconds a move).
export function limitFor(spec, par) {
  if (!spec.clock) return 0;
  const s = 20 + par * (spec.tier >= 2 ? 3 : 3.6);
  return Math.ceil(s / 5) * 5 * 1000;
}

// --- adaptive difficulty -------------------------------------------------------

export const SKILL_MIN = -2;
export const SKILL_MAX = 2;
export const skillShift = (skill) => (skill <= -1 ? -1 : skill >= 1.2 ? 1 : 0);
const clampSkill = (s) => Math.round(Math.max(SKILL_MIN, Math.min(SKILL_MAX, s)) * 100) / 100;

// After a level: wins in few moves raise it; fails and hints lower it.
export function nextSkill(skill = 0, { won, stars = 0, hinted = false }) {
  if (!won) return clampSkill(skill - 0.5);
  const gain = stars === 3 ? 0.35 : stars === 2 ? 0.15 : 0;
  return clampSkill(skill + gain - (hinted ? 0.15 : 0));
}

// --- scoring --------------------------------------------------------------------

// moves allowed for 2 stars
export const twoStarMoves = (par) => par + Math.max(2, Math.ceil(par * 0.5));

// 3: the par (the fewest moves there are); 2: a few over; 1: solved. A hint
// (watched for with an ad) takes one off, never the last (the user,
// 2026-10-24: "hint is by watching an ad and lose a star").
export function starsFor(par, { moves, hinted }) {
  const s = moves <= par ? 3 : moves <= twoStarMoves(par) ? 2 : 1;
  return Math.max(1, s - (hinted ? 1 : 0));
}

const STAR_MULT = [0, 1, 1.5, 2];
export function coinsFor(spec, par, stars) {
  const base = 6 + 2 * spec.n + 0.6 * par + (spec.goal === 'picture' ? 3 : 0) + (spec.clock ? 4 : 0);
  return Math.round(base * STAR_MULT[stars] * (1 + 0.15 * spec.tier));
}

// The player's XP for a win (src/playerXp.js): Squish Sort's formula —
// Squishdoku's range, by the level number. A hint's lost star costs XP too.
export function xpFor(spec, stars) {
  return Math.round((10 + Math.floor(spec.lv / 2) + 5 * spec.tier) * (0.6 + 0.2 * stars));
}

// --- Blitz -----------------------------------------------------------------------
//
// Ten puzzles in a row on one clock (the user, 2026-10-24: "in the Tower of
// Hanoi game, i also want to have a blitz version", like Squishdoku's).
// They grow from 3 squishies on 3 cushions to 7 on 4, all scrambled, some
// with a goal card. Dropping a big one on a smaller one is the mistake that
// ends the run (one revive per run: an ad, free with Remove Ads), and so does
// the clock running out. No hints.

const BLITZ = [
  { n: 3, k: 3, tier: 0, par: [4, 6] },
  { n: 3, k: 3, tier: 0, par: [5, 7] },
  { n: 4, k: 3, tier: 0, par: [6, 9] },
  { n: 4, k: 3, tier: 1, par: [8, 11] },
  { n: 4, k: 3, tier: 1, par: [9, 12], goal: 'picture' },
  { n: 5, k: 4, tier: 1, par: [7, 9] },
  { n: 5, k: 4, tier: 2, par: [8, 10], goal: 'picture' },
  { n: 6, k: 4, tier: 2, par: [10, 12] },
  { n: 6, k: 4, tier: 2, par: [11, 13], goal: 'picture' },
  { n: 7, k: 4, tier: 3, par: [13, 16] },
];
export const BLITZ_ROUNDS = BLITZ.length;
// the best answers add up to about 93 moves: some 2.6 s a move
export const BLITZ_MS = 4 * 60 * 1000;
export const BLITZ_COINS = 800;
// a won run's XP: config/levels `xp.blitz.stack` (this by default)
export const BLITZ_XP = 200;

// Puzzle i (0-9) at the Blitz skill, as a level spec (engine.makePuzzle):
// a skill step moves its par range 2 moves either way.
export function blitzSpec(i, skill = 0) {
  const b = BLITZ[i];
  const shift = skillShift(skill);
  return {
    lv: i + 1,
    round: i + 1,
    band: 0,
    n: b.n,
    k: b.k,
    tier: Math.max(0, Math.min(3, b.tier + shift)),
    baseTier: b.tier,
    start: 'scrambled',
    goal: b.goal || 'star',
    par: [Math.max(2, b.par[0] + 2 * shift), b.par[1] + 2 * shift],
    clock: false,
    news: null,
  };
}

// The fields to write after a Blitz run ends (won or not), and what it paid.
export function afterBlitz(profile, { won, reached, ms }) {
  const rec = record(profile);
  const update = {
    'stack.bSkill': clampSkill(rec.bSkill + (won ? 0.4 : reached >= 6 ? 0 : -0.3)),
    'stack.blitz.reached': Math.max(rec.blitz.reached, reached),
  };
  if (!won) return { update, coins: 0, xp: 0, levelUps: [] };
  update['stack.blitz.wins'] = rec.blitz.wins + 1;
  if (!rec.blitz.bestMs || ms < rec.blitz.bestMs) update['stack.blitz.bestMs'] = ms;
  const xp = xpRules().blitz.stack;
  return { update, coins: BLITZ_COINS, xp, ...addXp(profile, xp) };
}

// --- the profile's record -----------------------------------------------------------

export function record(profile) {
  const s = (profile && profile.stack) || {};
  return {
    lv: Math.max(1, Math.min(LEVELS, s.lv || 1)),
    best: s.best || {},
    skill: s.skill || 0,
    plays: s.plays || 0,
    wins: s.wins || 0,
    seen: !!s.seen,
    bSkill: s.bSkill || 0,
    blitz: { reached: 0, bestMs: 0, wins: 0, ...(s.blitz || {}) },
  };
}

// total stars won
export const starsOf = (rec) => Object.values(rec.best).reduce((a, n) => a + (n || 0), 0);
// levels beaten
export const doneOf = (rec) => rec.lv - 1 + (rec.best[LEVELS] ? 1 : 0);

// The fields to write after a level, and what it paid: coins, the player's
// XP (half on a replay: winXp) and the levels it reached (`before` /
// `after`: the result's XP bar). result: { won, moves, hinted }
export function afterLevel(profile, spec, par, result) {
  const rec = record(profile);
  const won = !!result.won;
  const stars = won ? starsFor(par, result) : 0;
  const update = {
    'stack.plays': rec.plays + 1,
    'stack.seen': true,
    'stack.skill': nextSkill(rec.skill, { won, stars, hinted: !!result.hinted }),
  };
  if (!won) return { update, coins: 0, xp: 0, levelUps: [], stars: 0, unlocked: false };
  const coins = coinsFor(spec, par, stars);
  const best = rec.best[spec.lv] || 0;
  const xp = winXp(gameXp(xpFor(spec, stars)), best ? gameXp(xpFor(spec, best)) : null);
  update['stack.wins'] = rec.wins + 1;
  if (stars > best) update[`stack.best.${spec.lv}`] = stars;
  const unlocked = spec.lv === rec.lv && rec.lv < LEVELS;
  if (unlocked) update['stack.lv'] = rec.lv + 1;
  return { update, coins, xp, ...addXp(profile, xp), stars, unlocked };
}

// 0:42
export function clock(ms) {
  const s = Math.max(0, Math.ceil(ms / 1000));
  return `${Math.floor(s / 60)}:${String(s % 60).padStart(2, '0')}`;
}
