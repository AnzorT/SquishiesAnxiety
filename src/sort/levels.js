// Squish Sort's levels, difficulty, scoring and rewards (SQUISH_SORT.md),
// and the profile's `sort` record they're saved in. Pure functions: the
// screen writes what they return.
//
// Like Squishdoku: each container (the fridge, the toy cupboard) has 50
// levels in bands of one size (shelves × spots per shelf) across seven
// models, small to very very large (models.js), and each level
// asks for a difficulty tier (0 easy, 1 medium, 2 hard, 3 expert) that
// rises inside its band, with a few easier "breather" levels in between. A
// hidden skill score moves the tier one step either way (adaptive
// difficulty); the size never changes. Wins pay coins and the player's XP
// (src/playerXp.js, PLAYER_XP.md).
import { addXp, gameXp, winXp, xpRules } from '../playerXp.js';

export const LEVELS = 50;

// It starts easy, on one shelf (the user, 2026-10-24: "the 1st level should
// be easy with like 1 shelf and then level it up"), in seven real
// containers, small to very very large, each wider than the last and
// gaining shelves as it goes (2026-10-28: "several fridge types … with each
// time adding more shelfs"; models.js draws them). A new shelf mostly
// starts a tier easier than the levels before it.
const MODEL_SIZES = [
  { cols: 3, steps: [{ rows: 1, base: 2, tiers: [0, 0] }, { rows: 2, base: 3, tiers: [0, 0, 0] }] }, //  1-5   SMALL
  { cols: 3, steps: [{ rows: 3, base: 3, tiers: [1, 0, 1] }, { rows: 4, base: 4, tiers: [0, 1, 1] }] }, //  6-11  MEDIUM
  { cols: 4, steps: [{ rows: 3, base: 5, tiers: [0, 1, 1] }, { rows: 4, base: 6, tiers: [1, 2, 1, 2] }] }, // 12-18  BIG
  { cols: 4, steps: [{ rows: 5, base: 7, tiers: [0, 1, 2] }, { rows: 6, base: 7, tiers: [1, 2, 2, 3] }] }, // 19-25  LARGE
  { cols: 5, steps: [{ rows: 5, base: 8, tiers: [1, 1, 2] }, { rows: 6, base: 8, tiers: [1, 2, 3, 2] }] }, // 26-32  EXTRA LARGE
  { cols: 5, steps: [{ rows: 7, base: 9, tiers: [1, 2, 2, 3] }, { rows: 8, base: 9, tiers: [1, 2, 3, 2, 3] }] }, // 33-41  XXL
  { cols: 6, steps: [{ rows: 7, base: 10, tiers: [1, 2, 3, 2] }, { rows: 8, base: 10, tiers: [2, 3, 2, 3, 3] }] }, // 42-50  VERY VERY LARGE
];
// a level each: { band (a size, for the map's banners), model, rows, cols,
// base, tier, first (the model's first level), more (a new shelf's) }
let bands = 0;
export const LEVEL_LIST = MODEL_SIZES.flatMap((m, model) =>
  m.steps.flatMap((st, k) => {
    const band = bands++;
    return st.tiers.map((tier, j) => ({ band, model, rows: st.rows, cols: m.cols, base: st.base, tier, first: k === 0 && j === 0, more: k > 0 && j === 0 }));
  }),
);
// the first level of each model
export const MODEL_STARTS = LEVEL_LIST.map((L, i) => (L.first ? i + 1 : 0)).filter(Boolean);

export const TIER_NAMES = ['EASY', 'MEDIUM', 'HARD', 'EXPERT'];
export const TIER_COLORS = ['#3ddc97', '#5fb8ff', '#ff8a4a', '#e01e4a'];
export const HEARTS = 3;

// The twists, by the tier: medium has one, hard two, expert all three —
// impostors (squishies in the tray that were never inside), sneaky swaps
// (two squishies trade places near the end of the peek) and mixed-up ones
// (left inside after the shake, in the wrong spots). Which ones turns with
// the level number, so they arrive one at a time (impostors at 6, mixed up
// at 10, the swap at 14).
const TWISTS = ['decoys', 'mixed', 'swaps'];
function twistsFor(lv, tier) {
  if (tier <= 0) return [];
  const first = TWISTS[lv % 3];
  if (tier === 1) return [first];
  if (tier === 2) return TWISTS.filter((t) => t !== TWISTS[(lv + 1) % 3]);
  return TWISTS;
}

// Level `lv` (1-50) at a skill: { lv, band, model, first, more, rows,
// cols, tier, baseTier, count, foods, decoys, swaps, mixed, peekMs,
// limitMs, parMs }.
//   count   squishies on the shelves: the band's, plus one per tier
//   foods   the clutter (food in the fridge, toys in the cupboard): about
//           four in ten spots, more on harder tiers; it's moved about by
//           the shake, so it's no landmark
//   peekMs  ~5 s, a little more for many squishies, less on harder tiers
export function levelSpec(lv, skill = 0) {
  const L = Math.max(1, Math.min(LEVELS, Math.floor(lv) || 1));
  const b = LEVEL_LIST[L - 1];
  const tier = Math.max(0, Math.min(3, b.tier + skillShift(skill)));
  const slots = b.rows * b.cols;
  const count = Math.min(slots - 1, b.base + tier);
  // (a spot or more left empty: one on the small shelves, three on big ones)
  const foods = Math.max(0, Math.min(slots - count - (slots <= 8 ? 1 : 3), Math.round(slots * 0.4) + tier));
  const tw = twistsFor(L, tier);
  const decoys = tw.includes('decoys') ? Math.min(3, 1 + (tier === 3 ? 1 : 0) + (b.model >= 4 ? 1 : 0)) : 0;
  const swaps = tw.includes('swaps') ? 1 + (tier === 3 ? 1 : 0) : 0;
  const mixed = tw.includes('mixed') ? Math.min(count - 1, 2 + (tier === 3 ? 1 : 0) + (b.model >= 4 ? 1 : 0)) : 0;
  const peekMs = Math.max(3800, 5000 + Math.max(0, count - 5) * 350 - tier * 300);
  return {
    lv: L,
    band: b.band,
    model: b.model,
    first: b.first,
    more: b.more,
    rows: b.rows,
    cols: b.cols,
    tier,
    baseTier: b.tier,
    count,
    foods,
    decoys,
    swaps,
    mixed,
    peekMs,
    // to put them all back: generous, but it runs out
    limitMs: (20 + 4 * count) * 1000,
    // under this with no mistakes: 3 stars
    parMs: Math.round((5 + 2.6 * count + 1.5 * mixed + 1.5 * decoys) * 1000),
  };
}

// --- adaptive difficulty -------------------------------------------------------

export const SKILL_MIN = -2;
export const SKILL_MAX = 2;
export const skillShift = (skill) => (skill <= -1 ? -1 : skill >= 1.2 ? 1 : 0);
const clampSkill = (s) => Math.round(Math.max(SKILL_MIN, Math.min(SKILL_MAX, s)) * 100) / 100;

// After a level: fast clean wins raise it, mistakes and fails lower it.
export function nextSkill(skill = 0, { won, stars = 0, mistakes = 0 }) {
  if (!won) return clampSkill(skill - 0.5);
  const gain = stars === 3 ? 0.35 : stars === 2 ? 0.15 : 0;
  return clampSkill(skill + gain - 0.12 * Math.min(3, mistakes));
}

// --- scoring --------------------------------------------------------------------

// 3: no mistakes and under the par time; 2: no more than one mistake; 1: won.
export function starsFor(spec, { mistakes, ms }) {
  if (!mistakes && ms <= spec.parMs) return 3;
  if (mistakes <= 1) return 2;
  return 1;
}

const STAR_MULT = [0, 1, 1.5, 2];
export function coinsFor(spec, stars) {
  const base = 6 + 3 * spec.count + 4 * spec.decoys + 6 * spec.swaps + 3 * spec.mixed;
  return Math.round(base * STAR_MULT[stars] * (1 + 0.15 * spec.tier));
}

// The player's XP for a win: Squishdoku's range (base 10 at level 1, 50 at
// level 50 on EXPERT), by the level number as the bands differ.
export function xpFor(spec, stars) {
  return Math.round((10 + Math.floor(spec.lv / 2) + 5 * spec.tier) * (0.6 + 0.2 * stars));
}

// --- Blitz -----------------------------------------------------------------------
//
// Ten rounds in a row (the user, 2026-10-24: "in the fridge game i also want
// to have a blitz option", like Squishdoku's): the fridge and the toy
// cupboard take turns, each round played like a Regular level from further
// up the map. One clock for the run, running only while you sort (not
// through the peek and the shake). One mistake ends the run; one revive per
// run (an ad, free with Remove Ads).

const BLITZ_LEVELS = [2, 5, 8, 11, 14, 17, 20, 24, 28, 33];
export const BLITZ_ROUNDS = BLITZ_LEVELS.length;
// the rounds' 3-star times add up to about 3:45
export const BLITZ_MS = 5 * 60 * 1000;
export const BLITZ_COINS = 800;
// a won run's XP: config/levels `xp.blitz.sort` (this by default)
export const BLITZ_XP = 200;

export const blitzTheme = (i) => (i % 2 ? 'cupboard' : 'fridge');
// round i (0-9) at the Blitz skill: a Regular level's spec, plus its round
export function blitzSpec(i, skill = 0) {
  return { ...levelSpec(BLITZ_LEVELS[i], skill), round: i + 1 };
}

// The fields to write after a Blitz run ends (won or not), and what it paid.
export function afterBlitz(profile, { won, reached, ms }) {
  const rec = record(profile);
  const update = {
    'sort.bSkill': clampSkill(rec.bSkill + (won ? 0.4 : reached >= 6 ? 0 : -0.3)),
    'sort.blitz.reached': Math.max(rec.blitz.reached, reached),
  };
  if (!won) return { update, coins: 0, xp: 0, levelUps: [] };
  update['sort.blitz.wins'] = rec.blitz.wins + 1;
  if (!rec.blitz.bestMs || ms < rec.blitz.bestMs) update['sort.blitz.bestMs'] = ms;
  const xp = xpRules().blitz.sort;
  return { update, coins: BLITZ_COINS, xp, ...addXp(profile, xp) };
}

// --- the profile's record -----------------------------------------------------------

export const THEME_KEYS = ['fridge', 'cupboard'];

export function record(profile) {
  const s = (profile && profile.sort) || {};
  const of = (k) => ({
    lv: Math.max(1, Math.min(LEVELS, (s[k] && s[k].lv) || 1)),
    best: (s[k] && s[k].best) || {},
    skill: (s[k] && s[k].skill) || 0,
  });
  return {
    fridge: of('fridge'),
    cupboard: of('cupboard'),
    plays: s.plays || 0,
    wins: s.wins || 0,
    seen: !!s.seen,
    bSkill: s.bSkill || 0,
    blitz: { reached: 0, bestMs: 0, wins: 0, ...(s.blitz || {}) },
  };
}

// total stars won in a theme
export const starsIn = (rec, theme) => Object.values(rec[theme].best).reduce((a, n) => a + (n || 0), 0);
// every level of a theme beaten
export const doneIn = (rec, theme) => rec[theme].lv - 1 + (rec[theme].best[LEVELS] ? 1 : 0);

// The fields to write after a level of `theme`, and what it paid: coins,
// the player's XP (half on a replay: winXp) and the levels it reached
// (`before` / `after`: the result's XP bar). result: { won, mistakes, ms }
export function afterLevel(profile, theme, spec, result) {
  const rec = record(profile);
  const t = rec[theme];
  const won = !!result.won;
  const stars = won ? starsFor(spec, result) : 0;
  const update = {
    'sort.plays': rec.plays + 1,
    'sort.seen': true,
    [`sort.${theme}.skill`]: nextSkill(t.skill, { won, stars, mistakes: result.mistakes || 0 }),
  };
  if (!won) return { update, coins: 0, xp: 0, levelUps: [], stars: 0, unlocked: false };
  const coins = coinsFor(spec, stars);
  const best = t.best[spec.lv] || 0;
  const xp = winXp(gameXp(xpFor(spec, stars)), best ? gameXp(xpFor(spec, best)) : null);
  update['sort.wins'] = rec.wins + 1;
  if (stars > best) update[`sort.${theme}.best.${spec.lv}`] = stars;
  const unlocked = spec.lv === t.lv && t.lv < LEVELS;
  if (unlocked) update[`sort.${theme}.lv`] = t.lv + 1;
  return { update, coins, xp, ...addXp(profile, xp), stars, unlocked };
}

// 0:42
export function clock(ms) {
  const s = Math.max(0, Math.ceil(ms / 1000));
  return `${Math.floor(s / 60)}:${String(s % 60).padStart(2, '0')}`;
}
