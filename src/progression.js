import { todayKey } from './dailySpin.js';

// Progression (the 2026-10-03 design: daily-challenges.js + the tutorial's
// level cards): levels, daily challenges, the daily chest and the streak.
// All of it lives on the player's profile document, written by the app like
// coins are (prototype-grade trust, see src/firebase/firestore.js):
//
//   level      1+. 2 when the first key arrives (the tutorial), 3 when the
//              Crib tutorial is done, then +1 for every day the daily chest
//              is opened (levelDay: the day it last rose).
//   tut        the tutorial step (src/tutorial/steps.js), 'done' when over.
//   daily      { date, prog: { squish, earn, ad, bath, feed, sleep, dance,
//              tv, play }, claimed: { [challengeId]: true }, chest: bool } —
//              today's progress. A new day starts over (the challenges
//              themselves come from the date, see challengesFor).
//   streak     days in a row the chest was opened; lastFull the last one.
//              Each streak day adds STREAK_BONUS to squish coins (up to
//              STREAK_DAYS days). A missed day resets it. Every chest also
//              pays that streak day's reward (STREAK_REWARDS: coins, Stars,
//              a free Silver chest, and on day 10 half price on the next creation —
//              `streakDiscount`); the track starts over after day 10.
//              bestStreak is the longest one, chests the chests opened.
//
// Daily Challenges open at level DAILY_LEVEL (the design's "LV 3").

export const DAILY_LEVEL = 3;
export const CHEST_COINS = 250;
export const STREAK_BONUS = 0.05; // +5% squish coins per streak day
export const STREAK_DAYS = 10;
// what each day of a streak pays when its chest is opened
export const STREAK_REWARDS = [
  { day: 1, kind: 'coins', amount: 100, label: '100' },
  { day: 2, kind: 'coins', amount: 150, label: '150' },
  { day: 3, kind: 'stars', amount: 10, label: '+10' },
  { day: 4, kind: 'coins', amount: 250, label: '250' },
  { day: 5, kind: 'chest', label: 'CHEST' },
  { day: 6, kind: 'coins', amount: 400, label: '400' },
  { day: 7, kind: 'stars', amount: 20, label: '+20' },
  { day: 8, kind: 'coins', amount: 600, label: '600' },
  { day: 9, kind: 'chest', label: 'CHEST' },
  { day: 10, kind: 'half', label: '50%' },
];
// the reward for streak day `n` (1, 2, … — day 11 pays day 1's again)
export const streakReward = (n) => STREAK_REWARDS[(Math.max(1, n) - 1) % STREAK_DAYS];
export function streakRewardText(r) {
  if (r.kind === 'coins') return `+${r.amount} coins`;
  if (r.kind === 'stars') return `+${r.amount} Stars`;
  if (r.kind === 'chest') return 'a free Silver chest';
  return 'half price on your next creation';
}
export const TUTORIAL_BOOST = 10; // ×10 coins during the tutorial's goal step

// The design's challenge pool: 3 game challenges every day, plus 3 of the 6
// Crib ones, each at one of its goal sizes. Picked by the date, so every
// player (and every device of one player) sees the same day's list.
const GAME = [
  { id: 'g_squish', ev: 'squish', goals: [50, 80, 120], title: (n) => `Squish ${n} times`, reward: 60 },
  { id: 'g_earn', ev: 'earn', goals: [200, 300, 500], title: (n) => `Earn ${n} coins squishing`, reward: 80 },
  { id: 'g_ad', ev: 'ad', goals: [1], title: () => 'Watch 1 bonus video', reward: 40 },
];
const CRIB = [
  { id: 'c_bath', ev: 'bath', goals: [2, 3], title: (n) => `Give ${n} friends a bath`, reward: 60 },
  { id: 'c_feed', ev: 'feed', goals: [2, 3], title: (n) => `Feed ${n} friends a snack`, reward: 60 },
  { id: 'c_sleep', ev: 'sleep', goals: [1, 2], title: (n) => `Tuck ${n} ${n > 1 ? 'friends' : 'friend'} into bed`, reward: 50 },
  { id: 'c_dance', ev: 'dance', goals: [2, 3], title: (n) => `Send ${n} friends to dance`, reward: 50 },
  { id: 'c_tv', ev: 'tv', goals: [2], title: (n) => `Watch TV with ${n} friends`, reward: 40 },
  { id: 'c_play', ev: 'play', goals: [2, 3], title: (n) => `Send ${n} friends out to play`, reward: 40 },
];
const byId = Object.fromEntries([...GAME, ...CRIB].map((c) => [c.id, c]));

// the design's little seeded generator, seeded from the date
const rng = (seed) => () => (seed = (seed * 9301 + 49297) % 233280) / 233280;
const seedOf = (date) => date.split('-').reduce((a, b) => a * 31 + +b, 7) % 233280;

// Today's six challenges: [{ id, ev, side: 'game' | 'crib', goal }].
export function challengesFor(date = todayKey()) {
  const r = rng(seedOf(date));
  const crib = CRIB.slice();
  for (let i = crib.length - 1; i > 0; i--) {
    const j = Math.floor(r() * (i + 1));
    [crib[i], crib[j]] = [crib[j], crib[i]];
  }
  const pick = (c, side) => ({ id: c.id, ev: c.ev, side, goal: c.goals[Math.floor(r() * c.goals.length)] });
  return GAME.map((c) => pick(c, 'game')).concat(crib.slice(0, 3).map((c) => pick(c, 'crib')));
}

const EMPTY_DAY = { prog: {}, claimed: {}, chest: false };

// The profile's daily state for `date` — a fresh one if it's from another day.
export function dailyState(profile, date = todayKey()) {
  const d = profile?.daily;
  return d && d.date === date ? { prog: d.prog || {}, claimed: d.claimed || {}, chest: !!d.chest, date } : { ...EMPTY_DAY, date };
}

// Today's challenges with their progress, as the Daily Challenges sheet
// shows them.
export function dailyRows(profile, date = todayKey()) {
  const s = dailyState(profile, date);
  return challengesFor(date).map((c) => {
    const def = byId[c.id];
    const prog = Math.min(c.goal, s.prog[c.ev] || 0);
    const claimed = !!s.claimed[c.id];
    const full = prog >= c.goal;
    return {
      id: c.id,
      ev: c.ev,
      side: c.side,
      title: def.title(c.goal),
      prog,
      goal: c.goal,
      pct: Math.round((prog / c.goal) * 100),
      label: `${prog} / ${c.goal}`,
      reward: def.reward,
      claimable: full && !claimed,
      claimed,
      open: !full,
    };
  });
}

// Everything the sheet and the Home badge need.
export function dailyView(profile, now = new Date()) {
  const date = todayKey(now);
  const s = dailyState(profile, date);
  const rows = dailyRows(profile, date);
  const claimedN = rows.filter((r) => r.claimed).length;
  const midnight = new Date(now.getFullYear(), now.getMonth(), now.getDate() + 1);
  const mins = Math.max(0, Math.round((midnight - now) / 60000));
  return {
    date,
    game: rows.filter((r) => r.side === 'game'),
    crib: rows.filter((r) => r.side === 'crib'),
    claimable: rows.filter((r) => r.claimable).length,
    claimedN,
    total: rows.length,
    chestPct: Math.round((claimedN / rows.length) * 100),
    chestReady: claimedN === rows.length && !s.chest,
    chestDone: s.chest,
    chestReward: CHEST_COINS,
    resetIn: `${Math.floor(mins / 60)}h ${mins % 60}m`,
    streak: streakOf(profile, now),
    track: streakTrack(profile, now),
  };
}

// The streak's ten days as the sheet draws them: which are done, which one
// today's chest pays (`today`, or `done` once it's open), and each reward.
// After day 10 the track shows the next ten (11-20 pay like 1-10).
export function streakTrack(profile, now = new Date()) {
  const streak = streakOf(profile, now);
  const openedToday = profile?.lastFull === todayKey(now) && streak > 0;
  // the day today's chest pays (or paid)
  const todayN = openedToday ? streak : streak + 1;
  const first = Math.floor((todayN - 1) / STREAK_DAYS) * STREAK_DAYS + 1;
  return Array.from({ length: STREAK_DAYS }, (_, i) => {
    const n = first + i;
    return { n, reward: streakReward(n), done: n < todayN || (n === todayN && openedToday), today: n === todayN };
  });
}

export const level = (profile) => Math.max(1, Math.floor(profile?.level ?? 1));
// The tutorial (src/tutorial/steps.js) hands out levels 2 and 3. Daily
// Challenges wait until it has shown them (its c_daily step) or is over — a
// replay doesn't bring them back early; the Crib opens at level 2.
const TUT_DAILY = ['c_daily', 'c_offers'];
const tutOver = (profile) => !profile?.tut || profile.tut === 'done';
export const dailyUnlocked = (profile) => level(profile) >= DAILY_LEVEL && (tutOver(profile) || TUT_DAILY.includes(profile.tut));
export const CRIB_LEVEL = 2;
export const cribUnlocked = (profile) => level(profile) >= CRIB_LEVEL;

const dayBefore = (date) => {
  const d = new Date(`${date}T12:00:00`);
  d.setDate(d.getDate() - 1);
  return todayKey(d);
};

// The streak as it stands: alive if the chest was opened today or yesterday.
export function streakOf(profile, now = new Date()) {
  const today = todayKey(now);
  const last = profile?.lastFull;
  return last && (last === today || last === dayBefore(today)) ? Math.max(0, Math.floor(profile?.streak ?? 0)) : 0;
}

// The multiplier the streak puts on squish coins (1.05 per streak day).
export const streakMultiplier = (profile, now) => 1 + STREAK_BONUS * Math.min(STREAK_DAYS, streakOf(profile, now));

// --- the profile updates (Firestore merge-style patches) -----------------

// `n` more of event `ev` today. Returns the fields to write, and the titles
// of the challenges this just completed (for the toast).
export function bumpDaily(profile, ev, n = 1, date = todayKey()) {
  const before = dailyRows(profile, date);
  const s = dailyState(profile, date);
  const prog = { ...s.prog, [ev]: (s.prog[ev] || 0) + n };
  const next = { ...profile, daily: { ...s, prog } };
  const completed = dailyRows(next, date)
    .filter((r, i) => r.claimable && !before[i].claimable)
    .map((r) => r.title);
  return { update: { daily: { date, prog, claimed: s.claimed, chest: s.chest } }, completed };
}

// Claims a completed challenge: its coins. Null if it can't be claimed.
export function claimDaily(profile, id, date = todayKey()) {
  const row = dailyRows(profile, date).find((r) => r.id === id);
  if (!row || !row.claimable) return null;
  const s = dailyState(profile, date);
  return { coins: row.reward, update: { daily: { date, prog: s.prog, claimed: { ...s.claimed, [id]: true }, chest: s.chest } } };
}

// Opens the chest once every challenge is claimed: CHEST_COINS, the streak
// and its day's reward (`reward`, applied by the caller: coins here, Stars
// and chests by the server's dailyGift with its +5 Stars) and, from level 3, a level a day. Null
// if it isn't ready.
export function claimChest(profile, date = todayKey()) {
  const s = dailyState(profile, date);
  const rows = dailyRows(profile, date);
  if (s.chest || !rows.every((r) => r.claimed)) return null;
  const alive = profile?.lastFull === dayBefore(date);
  const streak = alive ? Math.floor(profile?.streak ?? 0) + 1 : profile?.lastFull === date ? Math.floor(profile?.streak ?? 0) : 1;
  const lv = level(profile);
  const update = {
    daily: { date, prog: s.prog, claimed: s.claimed, chest: true },
    streak,
    lastFull: date,
    bestStreak: Math.max(streak, Math.floor(profile?.bestStreak ?? 0)),
  };
  if (lv >= DAILY_LEVEL && profile?.levelDay !== date) {
    update.level = lv + 1;
    update.levelDay = date;
  }
  return { coins: CHEST_COINS, update, reward: streakReward(streak) };
}
