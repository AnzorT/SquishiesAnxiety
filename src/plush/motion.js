// The design's plush body motion (plush-anim.js `frame`), as sampled tracks
// the native animation driver can loop without touching the JS thread.
//
// The design computes the body transform every frame from formulas of the
// time: a breath, a slow sway, hops, dance poses… Here each mood is a few
// TRACKS, each a periodic (or one-shot) curve sampled densely into keyframes:
//   { period, loop, channels: { ty, tx, rot, sy, scale, opacity } }
// and PlushCreature (CreatureThumbnail.js) drives every track with one
// Animated.Value and combines them: ty/tx/rot add up, sy/scale/opacity
// multiply. The same numbers as the design, in its 150-px units (the
// component scales ty/tx by size / 150).
//
// Per-creature variation comes from the design's hash of the creature's key
// (`per` stretches the periods 0.88-1.12×, `hopH` is its hop height).
//
// The Crib's moods are here too: bath (one motion per bath station, by
// `opts.bathStyle`), dirty (the smelly itch), tv. Eating is timed to the meal
// and lives in care.js with its props.

import { Animated, Easing } from 'react-native';

const TAU = Math.PI * 2;
const clamp01 = (x) => (x < 0 ? 0 : x > 1 ? 1 : x);
const ss = (x) => {
  x = clamp01(x);
  return x * x * (3 - 2 * x);
};
const bump = (x) => (x <= 0 || x >= 1 ? 0 : Math.pow(Math.sin(Math.PI * x), 2));
const backOut = (x) => {
  x = clamp01(x);
  const c = 1.7;
  return 1 + (c + 1) * Math.pow(x - 1, 3) + c * Math.pow(x - 1, 2);
};
const easeOut = (x) => 1 - Math.pow(1 - x, 3);
const easeBack = (x) => {
  const c = 1.9;
  return 1 + (c + 1) * Math.pow(x - 1, 3) + c * Math.pow(x - 1, 2);
};
const noise = (t, s) => (Math.sin(t * 0.00071 + s) + 0.6 * Math.sin(t * 0.00117 + s * 1.7) + 0.4 * Math.sin(t * 0.00029 + s * 2.3)) / 2;
const breath = (q) => (q < 0.42 ? ss(q / 0.42) : 1 - ss((q - 0.42) / 0.58));

// anticipation crouch -> stretched takeoff -> arc -> squash landing with
// damped overshoot
function hop(ms, P, o) {
  const p = (ms % P) / P;
  const a = o.ant;
  const b = a + o.air;
  if (p < a) return { y: 0, sy: 1 - o.sq * 0.75 * ss(p / a), air: 0 };
  if (p < b) {
    const q = (p - a) / o.air;
    return { y: o.h * 4 * q * (1 - q), sy: 1 + o.st * Math.pow(Math.abs(1 - 2 * q), 2), air: Math.sin(Math.PI * q) };
  }
  const tl = (p - b) * P;
  return { y: 0, sy: 1 - o.sq * Math.exp(-tl / 70) * Math.cos(tl / 46), air: 0 };
}
// swings between -1 and 1, one side per beat
const pose = (t, B, ease, hold) => {
  const nb = Math.floor(t / B);
  const q = (t % B) / B;
  const side = (m) => (m & 1 ? 1 : -1);
  const a = side(nb - 1);
  const b = side(nb);
  return { x: a + (b - a) * ease(q / hold), q, n: nb };
};

export { clamp01, ss, bump, backOut, easeOut, noise, breath, hop };

export function hashOf(key = 'nimbo') {
  return String(key)
    .split('')
    .reduce((a, ch) => a + ch.charCodeAt(0), 0);
}

// puff: the extra width of a chomp (the design's E.puff), added to sx
export const NEUTRAL = { ty: 0, tx: 0, rot: 0, sy: 1, scale: 1, opacity: 1, puff: 0 };

// Samples `fn(t)` (t in ms over one period; returns a partial channel set)
// into a track. `step` ms between samples.
export function track(period, fn, { loop = true, step = 25 } = {}) {
  const count = Math.max(12, Math.ceil(period / step));
  const input = [];
  const channels = {};
  for (let i = 0; i <= count; i++) {
    const u = i / count;
    // the last sample wraps to the first so the loop has no seam
    const v = { ...NEUTRAL, ...fn(loop && i === count ? 0 : u * period, u) };
    input.push(u);
    Object.keys(NEUTRAL).forEach((k) => (channels[k] = channels[k] || []).push(v[k]));
  }
  // drop the channels that never move
  Object.keys(channels).forEach((k) => {
    if (channels[k].every((x) => x === NEUTRAL[k])) delete channels[k];
  });
  return { period, loop, input, channels };
}

// The design's sway uses non-periodic noise; sampled over a long stretch
// with its last tenth faded into its start so it loops unnoticed.
export function noiseTrack(period, fn) {
  const t = track(period, fn, { loop: false, step: 60 });
  const k = t.input.length;
  Object.keys(t.channels).forEach((ch) => {
    const a = t.channels[ch];
    const first = a[0];
    for (let i = Math.floor(k * 0.9); i < k; i++) {
      const w = ss((i - k * 0.9) / (k * 0.1));
      a[i] = a[i] + (first - a[i]) * w;
    }
  });
  t.loop = true;
  return t;
}

const HOP_IDLE = { ant: 0.24, air: 0.4, h: 6, st: 0.06, sq: 0.09 };

// sin(t / d) as a track: one period is 2πd ms
const sinP = (d) => TAU * d;

// The tracks for a mood, for a creature with hash `h`.
export function moodTracks(mood, h, opts = {}) {
  const per = 0.88 + (h % 7) * 0.04;
  const hopH = 13 + (h % 5) * 1.5;
  switch (mood) {
    case 'tv': {
      const P = 3600;
      return [track(P, (t) => ({ sy: 1 + 0.012 * breath((t % P) / P) })), noiseTrack(14000, (t) => ({ rot: 0.8 * noise(t, h) }))];
    }
    case 'dirty': {
      // a scratch at the start of every 3 s, slumped a little
      return [
        track(3000, (t) => {
          const env = bump(t / 3000 / 0.22);
          return { sy: 0.96, tx: 1.4 * env * Math.sin(t / 28) };
        }, { step: 16 }),
        noiseTrack(14000, (t) => ({ rot: 3 * noise(t, h) })),
      ];
    }
    case 'bath':
      return bathTracks(opts.bathStyle, h);
    case 'idle':
    case 'ready': {
      const P = 2800 * per;
      return [
        track(P, (t) => ({ sy: 1 + 0.022 * breath((t % P) / P) })),
        noiseTrack(14000, (t) => ({ rot: 2.4 * noise(t, h), tx: 1.1 * noise(t * 0.7, h + 5) })),
        // a little hop every 7.4 s
        track(7400, (t) => {
          const q = t / 7400;
          if (q >= 0.11) return {};
          const r = hop(q * 7400, 814, HOP_IDLE);
          return { ty: -r.y, sy: r.sy };
        }),
      ];
    }
    case 'happy':
    case 'jump': {
      const P = 780 * per;
      return [
        track(2 * P, (t) => {
          const r = hop(t, P, { ant: 0.2, air: 0.46, h: hopH, st: 0.1, sq: 0.15 });
          return { ty: -r.y, sy: r.sy, rot: 5 * r.air * (Math.floor(t / P) & 1 ? 1 : -1) };
        }),
      ];
    }
    case 'dance':
    case 'wobble': {
      const B = 540 * per;
      return [
        track(2 * B, (t) => {
          const p = pose(t, B, backOut, 0.42);
          const g = Math.exp((-p.q * B) / 95);
          return { rot: 9 * p.x, tx: 3.5 * p.x, sy: 1 - 0.075 * g, ty: 2.6 * g - 3 * bump(p.q) };
        }),
      ];
    }
    case 'clean': {
      const B = 1100 * per;
      return [
        track(2 * B, (t) => {
          const p = pose(t, B, ss, 0.5);
          return { rot: 6 * p.x, ty: -3 * bump(p.q / 0.5), sy: 1 + 0.02 * bump(p.q / 0.5) };
        }),
      ];
    }
    case 'sleep': {
      const P = 3800 * per;
      return [
        track(P, (t) => {
          const b = breath((t % P) / P);
          return { sy: 1 + 0.035 * b, rot: -5 + 1.2 * b, ty: 3 };
        }),
      ];
    }
    case 'sad':
      // the design's sob (three hiccups in the first 38%), made big enough to
      // read at the Crib's size, and a slow sway of the head
      return [
        track(2600, (t) => {
          const q = t / 2600;
          const env = bump(q / 0.38);
          const hic = env * Math.abs(Math.sin((q / 0.38) * 3 * Math.PI));
          return { sy: 0.94 + 0.06 * hic, rot: -4 + 3 * Math.sin(TAU * q), ty: 5 - 5 * hic };
        }),
      ];
    case 'spin':
      // one turn with a little jump, then still
      return [
        track(
          1150,
          (t) => {
            const u = Math.min(1, t / 1150);
            const hq = clamp01((u - 0.1) / 0.8);
            const rot = 360 * (u < 0.15 ? 0 : ss((u - 0.15) / 0.75));
            const sy = u < 0.15 ? 1 - 0.12 * ss(u / 0.15) : u > 0.9 ? 1 - 0.1 * bump((u - 0.9) / 0.1) : 1 + 0.06 * Math.sin(Math.PI * hq);
            return { rot, ty: -16 * Math.sin(Math.PI * hq), sy };
          },
          { loop: false, step: 16 }
        ),
      ];
    case 'reveal': {
      // out of the box: shoots up small, drops, settles with a wobble, then
      // hops
      const P = 900 * per;
      return [
        track(
          1400,
          (t) => {
            const ts = t / 1000;
            if (ts < 0.42) {
              const e = ts / 0.42;
              const eo = easeOut(e);
              return { scale: 0.35 + 0.65 * eo, ty: 46 - 104 * eo, sy: 1 + 0.22 * (1 - e), rot: 10 * Math.sin(e * 7) * (1 - e) };
            }
            if (ts < 0.78) {
              const e = (ts - 0.42) / 0.36;
              return { ty: -58 + 58 * e * e, sy: 1 + 0.08 * e };
            }
            const e = (ts - 0.78) / 0.62;
            return { sy: 1 - 0.18 * Math.exp(-e * 4.5) * Math.cos(e * 13) };
          },
          { loop: false, step: 16 }
        ),
        {
          ...track(2 * P, (t) => {
            const r = hop(t, P, { ant: 0.22, air: 0.42, h: hopH * 0.8, st: 0.08, sq: 0.13 });
            return { ty: -r.y, sy: r.sy, rot: 4 * Math.sin(t / 600) };
          }),
          delay: 1400,
        },
      ];
    }
    case 'unlock':
    case 'celebrate': {
      // hidden, pops in from nothing, then hops
      const P = 780 * per;
      return [
        track(
          3400,
          (t) => {
            const U = t / 3400;
            if (U < 0.22) return { opacity: 0, scale: 0.001 };
            if (U < 0.34) {
              const e = (U - 0.22) / 0.12;
              return { scale: Math.max(0.001, easeBack(e)), ty: 18 * (1 - easeOut(e)), sy: 1 + 0.12 * (1 - e) };
            }
            const r = hop(t, P, { ant: 0.2, air: 0.46, h: hopH, st: 0.1, sq: 0.15 });
            return { ty: -r.y, sy: r.sy };
          },
          { step: 16 }
        ),
      ];
    }
    default:
      return moodTracks('idle', h);
  }
}

// plush-anim.js `frame`, case 'bath': each station moves its own way
function bathTracks(style, h) {
  const st = style === 'washtub' ? 'tub' : style || 'tub';
  if (st === 'hottub' || st === 'sauna' || st === 'spa') {
    const P = st === 'hottub' ? 3200 : st === 'sauna' ? 3600 : 4000;
    const b = (t) => breath((t % P) / P);
    const body =
      st === 'hottub'
        ? (t) => ({ ty: 6, rot: -5 + 1.5 * b(t), sy: 1 + 0.02 * b(t) })
        : st === 'sauna'
          ? (t) => ({ ty: 3, rot: -2, sy: 1 + 0.03 * b(t) })
          : (t) => ({ ty: 4, sy: 1 + 0.018 * b(t) });
    const out = [track(P, body)];
    if (st === 'sauna') out.push(noiseTrack(14000, (t) => ({ rot: noise(t, h) })));
    if (st === 'spa') out.push(noiseTrack(14000, (t) => ({ rot: 1.5 * noise(t, h) })));
    return out;
  }
  if (st === 'duck')
    return [
      track(sinP(400), (t) => ({ ty: 6 + 2.2 * Math.sin(t / 400) })),
      track(sinP(520), (t) => ({ rot: 6 * Math.sin(t / 520) })),
      track(sinP(260), (t) => ({ sy: 1 - 0.02 * Math.sin(t / 260) })),
    ];
  if (st === 'mud' || st === 'shower') {
    // the scrub under the water
    const [a, d] = st === 'mud' ? [5, 280] : [4, 320];
    const q = st === 'mud' ? 0.025 : 0.02;
    return [track(sinP(d), (t) => ({ rot: a * Math.sin(t / d) })), track(Math.PI * (d / 2), (t) => ({ sy: 1 - q * Math.abs(Math.sin(t / (d / 2))) }))];
  }
  // the tub and the bubble bath: bob and rock
  const f = st === 'bubble' ? 0.8 : 1;
  return [
    track(sinP(700 * f), (t) => ({ ty: 6 + 1.8 * Math.sin(t / (700 * f)) })),
    track(sinP(1100 * f), (t) => ({ rot: 4 * Math.sin(t / (1100 * f)) })),
    track(sinP(530), (t) => ({ rot: 1.5 * Math.sin(t / 530 + 1) })),
    track(sinP(350), (t) => ({ sy: 1 - 0.015 * Math.sin(t / 350) })),
  ];
}

// the face each bath station gives (plush-anim.js: faceKey per style)
export const BATH_FACE = { hottub: 'content', spa: 'content', duck: 'party', mud: 'party', shower: 'happy', sauna: 'content', bubble: 'happy', tub: 'content', washtub: 'content' };

// The design's "cycle" mood on lists: 3 s of each, round and round.
export const CYCLE = ['idle', 'dance', 'idle', 'happy', 'idle', 'clean', 'idle', 'spin'];
export const CYCLE_STEP_MS = 3000;

// Starts a track's Animated.Value: from a random phase for a loop (so a row
// of creatures isn't in step), after `delay` for a one-shot that follows
// another. Returns the running animation.
export function runTrack(value, t, { phase = 0 } = {}) {
  const once = (from, to, duration) => Animated.timing(value, { toValue: to, duration, easing: Easing.linear, useNativeDriver: true });
  const steps = [];
  if (t.delay) {
    // a native hold at 0, not Animated.delay (which runs on the JS driver and
    // blocks InteractionManager — see Blink in CreatureThumbnail.js)
    value.setValue(0);
    steps.push(once(0, 0, t.delay));
  } else value.setValue(t.loop ? phase : 0);
  if (t.loop) {
    if (phase > 0 && !t.delay) steps.push(once(phase, 1, t.period * (1 - phase)));
    steps.push(Animated.loop(once(0, 1, t.period)));
  } else steps.push(once(0, 1, t.period));
  const anim = steps.length === 1 ? steps[0] : Animated.sequence(steps);
  anim.start();
  return anim;
}
