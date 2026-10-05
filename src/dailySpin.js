// Daily Spin, app side. The server (spinWheel in functions/index.js, rules in
// functions/dailySpin.js) rolls and hands out the prize; the app draws the
// wheel and lands it on the slice the server picked. The eight slices here
// must match functions/dailySpin.js, in the same order.

export const WHEEL = [
  { kind: 'coins', amount: 60, label: '60', color: '#ff4fbf' },
  { kind: 'coins', amount: 120, label: '120', color: '#9d4dff' },
  { kind: 'create', label: 'CREATE', color: '#ffb81f' },
  { kind: 'coins', amount: 200, label: '200', color: '#ff4fbf' },
  { kind: 'coins', amount: 80, label: '80', color: '#9d4dff' },
  { kind: 'unlock', label: 'FREE', color: '#2fc8f0' },
  { kind: 'coins', amount: 150, label: '150', color: '#9d4dff' },
  { kind: 'coins', amount: 300, label: '300', color: '#ff4fbf' },
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

// SPIN AGAIN: after the free spin, up to MAX_AD_SPINS more a day for a
// rewarded video each (free with Remove Ads). The server counts them in
// `adSpins: { day, n }` (functions/dailySpin.js has the same number).
export const MAX_AD_SPINS = 3;
export function adSpinsLeft(profile, now = new Date()) {
  const day = todayKey(now);
  const a = profile && profile.adSpins;
  const used = a && a.day === day ? Math.max(0, Math.floor(a.n || 0)) : 0;
  return Math.max(0, MAX_AD_SPINS - used);
}

// The prize card under the wheel (the design's prizeTitle / prizeDesc /
// prizeCta), for a spinWheel result.
export function prizeCard(result) {
  if (!result) return null;
  if (result.kind === 'coins') {
    return {
      title: `+${result.amount.toLocaleString()} COINS`,
      desc: result.allOwned ? 'You already own every creature, so here are coins instead.' : 'Straight into your balance.',
      cta: 'COLLECT',
      color: '#c25e00',
    };
  }
  if (result.kind === 'create') {
    return {
      title: `${result.discountPct}% OFF CREATING`,
      desc: `Your next custom squishy costs ${result.discountPct}% less.`,
      cta: 'CONTINUE',
      color: '#0f9d90',
    };
  }
  return {
    title: 'FREE CREATURE',
    desc: 'Spin the reel and keep whichever creature it lands on.',
    cta: 'CONTINUE',
    color: '#0f9d90',
  };
}
