// Daily Spin, app side. The server (spinWheel in functions/index.js, rules in
// functions/dailySpin.js) rolls and hands out the prize; the app draws the
// wheel and lands it on the slice the server picked. The eight slices here
// must match functions/dailySpin.js, in the same order.

// The shell's wheel (2026-10-08): coins, gems and Stars; `color` is the
// slice's (the design's WCOL).
export const WHEEL = [
  { kind: 'coins', amount: 100, color: '#ff4fbf' },
  { kind: 'gems', amount: 5, color: '#9d4dff' },
  { kind: 'coins', amount: 250, color: '#ff4fbf' },
  { kind: 'stars', amount: 20, color: '#9d4dff' },
  { kind: 'coins', amount: 50, color: '#ff4fbf' },
  { kind: 'gems', amount: 15, color: '#2fc8f0' },
  { kind: 'coins', amount: 500, color: '#ff4fbf' },
  { kind: 'gems', amount: 50, color: '#ffb81f' },
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
    amount: `+${result.amount.toLocaleString()}`,
    what: result.kind.toUpperCase(),
  };
}
