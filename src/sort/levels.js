// Squish Sort's levels, difficulty, scoring and rewards (SQUISH_SORT.md),
// and the profile's `sort` record they're saved in. Pure functions: the
// screen writes what they return.
//
// Like Squishdoku: each container (the fridge, the toy cupboard) has 50
// levels in bands of one size (shelves × spots per shelf), and each level
// asks for a difficulty tier (0 easy, 1 medium, 2 hard, 3 expert) that
// rises inside its band, with a few easier "breather" levels in between. A
// hidden skill score moves the tier one step either way (adaptive
// difficulty); the size never changes.

export const LEVELS = 50;

// It starts easy, on one shelf, and gains a shelf a band (the user,
// 2026-10-24: "the 1st level should be easy with like 1 shelf and then
// level it up").
const BANDS = [
  { rows: 1, cols: 4, base: 2, tiers: [0, 0, 0] }, //  1-3
  { rows: 2, cols: 4, base: 3, tiers: [0, 0, 1, 0] }, //  4-7
  { rows: 3, cols: 4, base: 4, tiers: [0, 1, 1, 0, 1] }, //  8-12
  { rows: 4, cols: 4, base: 5, tiers: [0, 1, 1, 2, 1, 2] }, // 13-18
  { rows: 5, cols: 4, base: 6, tiers: [0, 1, 2, 1, 2, 2, 3] }, // 19-25
  { rows: 6, cols: 5, base: 7, tiers: [1, 1, 2, 1, 2, 3, 2, 3] }, // 26-33
  { rows: 7, cols: 5, base: 8, tiers: [1, 2, 2, 1, 2, 3, 2, 3] }, // 34-41
  { rows: 8, cols: 5, base: 9, tiers: [1, 2, 2, 3, 2, 3, 2, 3, 3] }, // 42-50
];
export const LEVEL_LIST = BANDS.flatMap((b, band) => b.tiers.map((tier) => ({ band, rows: b.rows, cols: b.cols, base: b.base, tier })));

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

// Level `lv` (1-50) at a skill: { lv, rows, cols, tier, baseTier, count,
// foods, decoys, swaps, mixed, peekMs, limitMs, parMs }.
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
  const count = b.base + tier;
  // (a spot or more left empty: one on the small shelves, three on big ones)
  const foods = Math.max(0, Math.min(slots - count - (slots <= 8 ? 1 : 3), Math.round(slots * 0.4) + tier));
  const tw = twistsFor(L, tier);
  const decoys = tw.includes('decoys') ? Math.min(3, 1 + (tier === 3 ? 1 : 0) + (b.band >= 5 ? 1 : 0)) : 0;
  const swaps = tw.includes('swaps') ? 1 + (tier === 3 ? 1 : 0) : 0;
  const mixed = tw.includes('mixed') ? Math.min(count - 1, 2 + (tier === 3 ? 1 : 0) + (b.band >= 5 ? 1 : 0)) : 0;
  const peekMs = Math.max(3800, 5000 + Math.max(0, count - 5) * 350 - tier * 300);
  return {
    lv: L,
    band: b.band,
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

// --- the profile's record -----------------------------------------------------------

export const THEME_KEYS = ['fridge', 'cupboard'];

export function record(profile) {
  const s = (profile && profile.sort) || {};
  const of = (k) => ({
    lv: Math.max(1, Math.min(LEVELS, (s[k] && s[k].lv) || 1)),
    best: (s[k] && s[k].best) || {},
    skill: (s[k] && s[k].skill) || 0,
  });
  return { fridge: of('fridge'), cupboard: of('cupboard'), plays: s.plays || 0, wins: s.wins || 0, seen: !!s.seen };
}

// total stars won in a theme
export const starsIn = (rec, theme) => Object.values(rec[theme].best).reduce((a, n) => a + (n || 0), 0);
// every level of a theme beaten
export const doneIn = (rec, theme) => rec[theme].lv - 1 + (rec[theme].best[LEVELS] ? 1 : 0);

// The fields to write after a level of `theme`, and what it paid.
// result: { won, mistakes, ms }
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
  if (!won) return { update, coins: 0, stars: 0, unlocked: false };
  const coins = coinsFor(spec, stars);
  update['sort.wins'] = rec.wins + 1;
  if (stars > (t.best[spec.lv] || 0)) update[`sort.${theme}.best.${spec.lv}`] = stars;
  const unlocked = spec.lv === t.lv && t.lv < LEVELS;
  if (unlocked) update[`sort.${theme}.lv`] = t.lv + 1;
  return { update, coins, stars, unlocked };
}

// 0:42
export function clock(ms) {
  const s = Math.max(0, Math.ceil(ms / 1000));
  return `${Math.floor(s / 60)}:${String(s % 60).padStart(2, '0')}`;
}
