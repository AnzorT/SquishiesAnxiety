import { fmtNum } from './format';

// Daily Spin, app side. The server (spinWheel in functions/index.js, rules in
// functions/dailySpin.js) rolls and hands out the prize; the app draws the
// wheel and lands it on the slice the server picked. The eight slices here
// must match functions/dailySpin.js, in the same order.

// The shell's wheel (2026-10-08): coins and gems; `tone` is the slice's
// look on the wood-and-gold wheel (DailySpinScreen TONES; 2026-11-17, the
// user: the wheel remodelled to the game's look). The 150 coins slice is a
// Common chest since 2026-11-17 (the user: "1 mystery box"): today's first
// HOT group's, opened by the server, smashed after the prize card.
export const WHEEL = [
  { kind: 'coins', amount: 100, tone: 'cream' },
  { kind: 'gems', amount: 5, tone: 'wood' },
  { kind: 'coins', amount: 250, tone: 'cream' },
  { kind: 'chest', amount: 1, size: 'common', tone: 'gold' },
  { kind: 'coins', amount: 50, tone: 'cream' },
  { kind: 'gems', amount: 15, tone: 'wood' },
  { kind: 'coins', amount: 500, tone: 'cream' },
  { kind: 'gems', amount: 50, tone: 'jewel' },
];
export const SLICE = 360 / WHEEL.length;

// The player's calendar day, in the same form the server stores as
// `lastSpinDay` ("2026-09-28").
export function todayKey(now = new Date()) {
  const local = new Date(now.getTime() - now.getTimezoneOffset() * 60000);
  return local.toISOString().slice(0, 10);
}

// The app's UTC offset in minutes, as the server wants it.
export function tzOffsetMinutes(now = new Date()) {
  return -now.getTimezoneOffset();
}

export function hasSpunToday(profile, now = new Date()) {
  return !!profile && !!profile.lastSpinDay && profile.lastSpinDay >= todayKey(now);
}

// "Watch ad, spin again": after the free spin, MAX_AD_SPINS more a day for
// a rewarded video (free with Remove Ads). The server counts them in
// `adSpins: { day, n }` (functions/dailySpin.js has the same number).
export const MAX_AD_SPINS = 1;
export function adSpinsLeft(profile, now = new Date()) {
  const day = todayKey(now);
  const a = profile && profile.adSpins;
  const used = a && a.day === day ? Math.max(0, Math.floor(a.n || 0)) : 0;
  return Math.max(0, MAX_AD_SPINS - used);
}

// The prize popup (the design's prizeTitle / prizeAmt / prizeWhat) for a
// spinWheel result.
export function prizeCard(result) {
  if (!result) return null;
  return {
    title: result.kind === 'gems' && result.amount >= 50 ? 'JACKPOT!' : 'You won!',
    amount: `+${fmtNum(result.amount)}`,
    what: result.kind === 'chest' ? 'MYSTERY BOX' : result.kind.toUpperCase(),
  };
}
