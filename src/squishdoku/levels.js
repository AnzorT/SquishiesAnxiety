// Squishdoku's levels, timers, scoring and rewards (SQUISHDOKU.md), and
// the profile's `sdk` record they're saved in. Pure functions: the screen
// writes what they return. The XP goes to the player's level
// (src/playerXp.js; it was the game's own Puzzle Level until 2026-10-25).
import { addXp, gameXp, winXp, xpRules } from '../playerXp.js';
import LEVEL_DATA from './levelData.js';

// 600 levels, one fixed board each (the user, 2026-11-07: no board that
// "remodels itself" on every play). levelData.js holds them, made and checked
// offline by tools/squishdoku/levels600.mjs: sizes rise 4×4 → 9×9 over the
// first 130 levels, then the boards get harder by how much thinking they take
// (the grader's effort), chapter by chapter. No skill score: a level is the
// same for everyone, every time.
export const LEVELS = LEVEL_DATA.length;

// 30 chapters of 20, each in one of the Crib's rooms (stageOf)
export const CHAPTER = 20;
export const CHAPTERS = Math.ceil(LEVELS / CHAPTER);
export const chapterOf = (lv) => Math.floor((Math.max(1, Math.min(LEVELS, lv)) - 1) / CHAPTER) + 1;

// Tiers by effort (engine.js grade): EASY ≤1, MEDIUM ≤3, HARD ≤7, EXPERT ≤15,
// then MASTER (16+: two chains or more) and LEGEND (24+), so the long climb
// through the 9×9 chapters shows (theme.js TIER_NAMES).
export const tierOfEffort = (e) => (e <= 1 ? 0 : e <= 3 ? 1 : e <= 7 ? 2 : e <= 15 ? 3 : e <= 23 ? 4 : 5);

export const LEVEL_LIST = LEVEL_DATA.map((d) => ({ n: d.n, tier: tierOfEffort(d.e), effort: d.e }));

// Seconds per grid size: the level's limit, and the times A (3 creatures)
// and B (2 creatures), for an effortless board; a board gets 5% more of each
// per point of effort up to 30 (a 9×9 at effort 24 has 2.2 × as long, and
// from 30 on, 2.5 ×: the hardest boards are about thinking, not the clock).
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

// Hearts (the user, 2026-11-07): from level 46 (the first 7×7) a level has 3,
// a mistake costs one, and the third ends the try (RETRY: the same board).
// Before, mistakes were free bar the stars, so a hard board could be beaten
// by tapping around until the creatures landed. Levels 1-45 are for learning
// and keep free mistakes (`hearts` 0).
export const HEARTS = 3;
export const HEARTS_FROM = 46;

// Level `lv` (1-600): { lv, n, tier, effort, puzzle, limitMs, aMs, bMs, head, hearts }.
// `puzzle` is the board: { n, regions (each cell's patch), solution (each
// row's column), colors (each patch's PATCHES colour) }.
export function levelSpec(lv, head = false) {
  const L = Math.max(1, Math.min(LEVELS, Math.floor(lv) || 1));
  const d = LEVEL_DATA[L - 1];
  const k = (1 + 0.05 * Math.min(30, d.e)) * (head ? HEAD_START.time : 1);
  const [limit, a, b] = TIMES[d.n].map((s) => Math.round((s * k) / 5) * 5 * 1000);
  const puzzle = {
    n: d.n,
    regions: [...d.r].map((ch) => ch.charCodeAt(0) - 97),
    solution: [...d.s].map(Number),
    colors: [...d.c].map(Number),
    effort: d.e,
  };
  return { lv: L, n: d.n, tier: tierOfEffort(d.e), effort: d.e, puzzle, limitMs: limit, aMs: a, bMs: b, head: !!head, hearts: L >= HEARTS_FROM ? HEARTS : 0 };
}

// The Crib room a level is played in, and its time of day (the user,
// 2026-11-07: Squishdoku in the rooms, Squish Hop's way). Each chapter has a
// room, round the six in turn; the time of day moves on through the chapter.
const CHAPTER_ROOMS = ['living', 'kitchen', 'bath', 'bed', 'yard', 'dance'];
const PHASES_OF = { living: ['morning', 'day', 'evening', 'night'], kitchen: ['morning', 'day', 'evening', 'night'], bath: ['day'], bed: ['morning', 'day', 'evening', 'night'], yard: ['morning', 'day', 'evening', 'night'], dance: ['day'] };
export const roomOfChapter = (c) => CHAPTER_ROOMS[(c - 1) % CHAPTER_ROOMS.length];
export function stageOf(lv) {
  const L = Math.max(1, Math.min(LEVELS, lv));
  const c = chapterOf(L);
  const room = roomOfChapter(c);
  const phases = PHASES_OF[room];
  const k = Math.min(phases.length - 1, Math.floor((((L - 1) % CHAPTER) / CHAPTER) * phases.length));
  return { room, phase: phases[k], key: `${room}:${k}` };
}

// --- adaptive difficulty (Blitz only) ----------------------------------------------
// Regular has no skill score since the 600 fixed levels; Blitz still deals
// fresh boards, and its own skill (bSkill) moves their tiers.

export const SKILL_MIN = -2;
export const SKILL_MAX = 2;
export const skillShift = (skill) => (skill <= -1 ? -1 : skill >= 1.2 ? 1 : 0);
const clampSkill = (s) => Math.round(Math.max(SKILL_MIN, Math.min(SKILL_MAX, s)) * 100) / 100;

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

// --- Blitz -----------------------------------------------------------------------
// BLITZ MODE (2026-11-16, the user): no more ten boards on one clock. A run goes on board after board, each on its own
// really short clock, until a mistake (or the clock running out) ends it: GAME OVER, unless the player saves it — with
// a rewarded ad (once a run) or with gems (functions/squad.js blitzSave: 10, then 20, 40 …). The hub's HEAD START switch
// doesn't apply here; instead every board starts with 1 creature placed, at no cost (the user, 2026-11-16: Blitz was
// a little too hard; BlitzGame.js). The record is the most boards cleared in one run (`sdk.blitz.top`).

// the sizes the run climbs through: 4×4 twice, 5×5 three times, 6×6 four, 7×7 five, then 8×8 for good
const BLITZ_RAMP = [4, 4, 5, 5, 5, 6, 6, 6, 6, 7, 7, 7, 7, 7];
// a board's clock, in seconds, by size: well under Regular's 3-creature times (TIMES' A) for boards this easy
export const BLITZ_SECS = { 4: 12, 5: 20, 6: 30, 7: 42, 8: 56 };
// coins for each board cleared, by size (twice Regular's base, BASE_COINS)
export const BLITZ_COINS = { 4: 30, 5: 50, 6: 70, 7: 100, 8: 130 };

// Board `i` of a run (0 = the first): { lv, n, tier, ms }. Past the climb the boards get harder (tier 1, then 2 from
// board 21) and each clock is 3% shorter than the last, down to three quarters.
export function blitzSpec(i, skill = 0) {
  const n = i < BLITZ_RAMP.length ? BLITZ_RAMP[i] : 8;
  const past = Math.max(0, i - BLITZ_RAMP.length + 1);
  const base = i < 5 ? 0 : i < BLITZ_RAMP.length ? i % 2 : past >= 7 ? 2 : 1;
  const tier = Math.max(0, Math.min(2, base + skillShift(skill)));
  const ms = Math.round(BLITZ_SECS[n] * Math.max(0.75, 1 - 0.03 * past)) * 1000;
  return { lv: i + 1, n, tier, ms };
}

// A gem save's price: 10, then twice the last each time in the same run, up to 320 (functions/squad.js blitzSaveGems,
// which charges it). `i`: the gem saves the run has had.
export const blitzSaveGems = (i) => 10 * 2 ** Math.max(0, Math.min(5, Math.floor(Number(i) || 0)));

// What `cleared` boards pay: their coins, and the player's XP (config/levels `xp.blitz.squishdoku` is the XP for ten
// boards: 40 a board by default).
export function blitzPrize(cleared, skill = 0) {
  let coins = 0;
  for (let i = 0; i < cleared; i++) coins += BLITZ_COINS[blitzSpec(i, skill).n];
  return { coins, xp: Math.round((xpRules().blitz.squishdoku / 10) * cleared) };
}

// --- the profile's record -------------------------------------------------------

export function record(profile) {
  const s = (profile && profile.sdk) || {};
  return {
    lv: Math.max(1, Math.min(LEVELS, s.lv || 1)),
    best: s.best || {},
    perfect: s.perfect || {},
    skill: s.skill || 0,
    bSkill: s.bSkill || 0,
    // top: the most boards cleared in one run (the endless Blitz, 2026-11-16; `reached` / `bestMs` / `wins` were the
    // ten-board runs')
    blitz: { top: 0, runs: 0, reached: 0, bestMs: 0, wins: 0, ...(s.blitz || {}) },
    plays: s.plays || 0,
    solves: s.solves || 0,
    head: !!s.head,
  };
}

// The fields to write after a Regular level, and what it paid: coins, the
// player's XP (half on a replay: winXp) and the player levels it reached
// (`before` / `after`: the result's XP bar).
export function afterLevel(profile, spec, result) {
  const rec = record(profile);
  const update = { 'sdk.plays': rec.plays + 1 };
  if (!result.solved) return { update, coins: 0, xp: 0, levelUps: [], unlocked: false };
  const { stars, perfect } = result;
  const coins = coinsFor(spec, result);
  const best = rec.best[spec.lv] || 0;
  const xp = winXp(gameXp(xpFor(spec, result)), best ? gameXp(xpFor(spec, { stars: best, perfect: !!rec.perfect[spec.lv] })) : null);
  const { before, after, levelUps } = addXp(profile, xp);
  update['sdk.solves'] = rec.solves + 1;
  if (stars > best) update[`sdk.best.${spec.lv}`] = stars;
  if (perfect && !rec.perfect[spec.lv]) update[`sdk.perfect.${spec.lv}`] = true;
  const unlocked = spec.lv === rec.lv && rec.lv < LEVELS;
  if (unlocked) update['sdk.lv'] = rec.lv + 1;
  return { update, coins, levelCoins: coins, xp, levelUps, unlocked, before, after };
}

// The fields to write when a Blitz run is over (`cleared`: the boards it cleared), and what it paid. The skill moves up
// after a run of 10 or more, down after one of under 5.
export function afterBlitz(profile, { cleared }) {
  const rec = record(profile);
  const update = {
    'sdk.bSkill': clampSkill(rec.bSkill + (cleared >= 10 ? 0.4 : cleared < 5 ? -0.3 : 0)),
    'sdk.blitz.runs': (rec.blitz.runs || 0) + 1,
  };
  const newTop = cleared > rec.blitz.top;
  if (newTop) update['sdk.blitz.top'] = cleared;
  if (!cleared) return { update, coins: 0, xp: 0, levelUps: [], newTop: false };
  // the skill the run's boards were dealt at (blitzSpec), so the coins match what was played
  const prize = blitzPrize(cleared, rec.bSkill);
  const { before, after, levelUps } = addXp(profile, prize.xp);
  return { update, coins: prize.coins, xp: prize.xp, levelUps, before, after, newTop };
}

// 1:05 / 0:09
export function clock(ms) {
  const s = Math.max(0, Math.ceil(ms / 1000));
  return `${Math.floor(s / 60)}:${String(s % 60).padStart(2, '0')}`;
}
