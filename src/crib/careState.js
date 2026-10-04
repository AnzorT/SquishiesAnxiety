// The Crib's outer layer of creature motion: the design's care states
// (squish-rig.js STATES, picked by "Squad Crib v5" animFor) that move the
// whole creature on top of its plush mood — the bath's scrub wiggle, the
// sleeper's slow breathing, the smelly droop with its orbiting flies and
// mint haze, the hungry lean, the tired slump with a Z now and then, the
// three dance moves (groove, twirl, pop hop), the yard's play — plus each
// state's tint and its particles (bubbles, Zzz, notes, sparkles).
//
// Everything is sampled into tracks like src/plush/ (care.js's spriteTrack:
// channels x, y, scale, sx, sy, rot, opacity), so the native driver plays it.
// Units: the creature's box is 0-100 (SIZE scene px). The design's body
// channels are in its own units (k = SIZE / 240 · 1.6 px); they're
// converted here.

import { sampleTrack, spriteTrack } from '../plush/care';
import { EF } from '../plush/ease';
import { SIZE } from './data';

const TAU = Math.PI * 2;
const PX = 100 / SIZE; // scene px → box units
const K = (SIZE / 240) * 1.6 * PX; // the design's body units → box units
const FK = 0.6; // the design's F.k (particle scale in the Crib)
const F = { cx: 50, cy: 55, rx: 42, ry: 38 }; // the body's ellipse, box units

// channel: [base, amp, periodMs, phase, shape, extra] (squish-rig.js wave)
function wave(c, t) {
  const [b, a, P, ph = 0, sh = 'sin', ex] = c;
  const u = t / P + ph;
  if (sh === 'sin') return b + a * Math.sin(TAU * u);
  if (sh === 'cos') return b + a * Math.cos(TAU * u);
  if (sh === 'hop') return b + a * Math.abs(Math.sin(Math.PI * u));
  if (sh === 'spin' || sh === 'pulse') {
    const x = (t % P) / P;
    if (x < ex.start || x > ex.end) return b;
    const v = (x - ex.start) / (ex.end - ex.start);
    return sh === 'spin' ? b + a * EF.soft(v) : b + a * Math.sin(Math.PI * v);
  }
  if (sh === 'spinsq') {
    const x = (t % P) / P;
    let f = 0;
    if (x < 0.2) f = -Math.sin((Math.PI * x) / 0.2);
    else if (x < 0.7) f = 0.7 * Math.sin((Math.PI * (x - 0.2)) / 0.5);
    else if (x < 0.9) f = -1.2 * Math.sin((Math.PI * (x - 0.7)) / 0.2);
    return b + a * f;
  }
  if (sh === 'shake') {
    const x = (t % P) / P;
    return x >= ex.win ? b : b + a * Math.sin((TAU * t) / ex.sub) * Math.sin((Math.PI * x) / ex.win);
  }
  return b;
}

const S = {
  idle: { ch: { sy: [1, 0.025, 3000, 0, 'sin'], sx: [1, -0.015, 3000, 0, 'sin'], ty: [-3, -3, 3000, 0, 'sin'], rot: [0, 1, 3000, 0.25, 'sin'] }, loop: 3000 },
  sad: { ch: { sy: [0.95, 0.012, 4000, 0, 'sin'], sx: [1.035, -0.008, 4000, 0, 'sin'], rot: [-5, 1.5, 4000, 0.25, 'sin'], ty: [6, -2, 4000, 0, 'sin'] }, loop: 4000, tint: ['#8fa8ff', 0.16] },
  hungry: { ch: { rot: [3, 1, 2000, 0, 'sin'], skx: [0, 2.5, 2000, 0, 'shake', { sub: 90, win: 0.25 }], sy: [1, 0.02, 2000, 0.25, 'sin'], sx: [1, -0.012, 2000, 0.25, 'sin'], ty: [0, -2, 2000, 0.25, 'sin'] }, loop: 2000, tint: ['#ffc56b', 0.06] },
  smelly: { ch: { sy: [0.97, 0.01, 3000, 0, 'sin'], sx: [1.02, -0.008, 3000, 0, 'sin'], rot: [0, 2, 3000, 0.25, 'sin'], ty: [3, 0, 3000, 0, 'sin'] }, loop: 3000, tint: ['#a8d672', 0.16], haze: true, flies: true },
  bathing: { ch: { rot: [0, 5, 1000, 0, 'sin'], sx: [1, 0.025, 500, 0, 'sin'], sy: [1, -0.02, 500, 0, 'sin'], ty: [0, -2, 1000, 0.25, 'sin'] }, loop: 2000, tint: ['#bff3ff', 0.14], bubbles: true },
  sleeping: { ch: { sy: [0.97, 0.025, 4000, 0, 'sin'], sx: [1.02, -0.015, 4000, 0, 'sin'], rot: [-4, 0, 4000, 0, 'sin'], ty: [5, -1.5, 4000, 0, 'sin'] }, loop: 4000, tint: ['#5b4bb8', 0.16], zzz: 0.6 },
  dance1: { ch: { tx: [0, 12, 1000, 0, 'sin'], rot: [0, 9, 1000, 0, 'sin'], ty: [0, -6, 500, 0, 'hop'], sy: [1, -0.05, 500, 0, 'cos'], sx: [1, 0.035, 500, 0, 'cos'] }, tint: ['#ffb3e6', 0.08] },
  dance2: { ch: { ty: [0, -22, 750, 0, 'hop'], sy: [1, -0.09, 750, 0, 'cos'], sx: [1, 0.06, 750, 0, 'cos'], skx: [0, 6, 1500, 0, 'sin'], rot: [0, 4, 1500, 0.25, 'sin'] }, tint: ['#ffe45c', 0.08] },
  dance3: { ch: { spin: [0, 360, 1600, 0, 'spin', { start: 0.2, end: 0.7 }], ty: [0, -26, 1600, 0, 'pulse', { start: 0.2, end: 0.7 }], sy: [1, 0.1, 1600, 0, 'spinsq'], sx: [1, -0.07, 1600, 0, 'spinsq'] }, tint: ['#c9b8ff', 0.08] },
  walk: { ch: { ty: [0, -10, 440, 0, 'hop'], sy: [1, -0.06, 440, 0, 'cos'], sx: [1, 0.04, 440, 0, 'cos'], rot: [0, 3, 880, 0, 'sin'] }, loop: 880 },
};
// the design's TIRED (sad's motion, a lilac tint, a Z now and then), PLAY
// and PARTY (idle's motion; the party on the trampoline glows yellow)
S.tired = { ...S.sad, tint: ['#9fa8ff', 0.1], zzz: 0.35 };
S.play = { ...S.idle };
S.party = { ...S.idle, tint: ['#ffe45c', 0.05] };

const BODY_NEUTRAL = { tx: 0, ty: 0, rot: 0, sy: 1, sx: 1, skx: 0, spin: 0 };
const DANCE_MS = 1900; // each dance move plays this long, then the next
const DANCES = ['dance1', 'dance3', 'dance2'];

// the body channels at t: box units for tx / ty, degrees for rot / skx / spin
function evalS(st, t) {
  const v = { sx: 1, sy: 1, rot: 0, skx: 0, tx: 0, ty: 0, spin: 0 };
  Object.keys(st.ch).forEach((k) => (v[k] = wave(st.ch[k], t)));
  v.tx *= K;
  v.ty *= K;
  return v;
}

// ---- particles ---------------------------------------------------------------------

const vb = (w, h, body) => ({ xml: `<svg xmlns="http://www.w3.org/2000/svg" viewBox="${-w / 2} ${-h / 2} ${w} ${h}">${body}</svg>`, w, h });
const BUBBLE = vb(20, 20, '<g transform="translate(-10 -10)"><circle cx="10" cy="10" r="9" fill="rgba(210,244,255,0.28)" stroke="#fff" stroke-width="1.2"/><path d="M5 8.5a5 5 0 0 1 4-4" stroke="#fff" stroke-width="1.6" fill="none" stroke-linecap="round"/><circle cx="14" cy="13.5" r="1.3" fill="#ffd1f0"/></g>');
const ZZZ = vb(20, 20, '<path d="M-5.5 -6 H5.5 L-5.5 6 H5.5" stroke="#6b5bd6" stroke-width="4.4" fill="none" stroke-linecap="round" stroke-linejoin="round"/><path d="M-5.5 -6 H5.5 L-5.5 6 H5.5" stroke="#ece6ff" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round"/>');
const HAZE = vb(20, 20, '<defs><radialGradient id="h" cx="0" cy="0" r="10" gradientUnits="userSpaceOnUse"><stop offset="0" stop-color="#b8ec80" stop-opacity="0.8"/><stop offset="0.7" stop-color="#b8ec80" stop-opacity="0"/></radialGradient></defs><circle r="10" fill="url(#h)"/>');
const FLY = vb(18, 18, '<g transform="translate(-9 -8)"><ellipse cx="5.2" cy="4.5" rx="4" ry="3" fill="#fff" stroke="#c9d3ff" stroke-width=".8"/><ellipse cx="12.8" cy="4.5" rx="4" ry="3" fill="#fff" stroke="#c9d3ff" stroke-width=".8"/><circle cx="9" cy="10" r="5" fill="#6a5585"/><circle cx="7.2" cy="9.4" r="1.4" fill="#fff"/><circle cx="10.8" cy="9.4" r="1.4" fill="#fff"/><circle cx="7.4" cy="9.7" r=".65" fill="#2a1b3d"/><circle cx="11" cy="9.7" r=".65" fill="#2a1b3d"/><path d="M7.6 12.2q1.4 1 2.8 0" stroke="#fff" stroke-width=".7" fill="none" stroke-linecap="round"/></g>');
const SPARKLE = vb(24, 24, '<g transform="translate(-12 -12)"><path d="M12 1c1 6 5 10 11 11-6 1-10 5-11 11-1-6-5-10-11-11 6-1 10-5 11-11z" fill="#fff6b8"/><circle cx="12" cy="12" r="2.6" fill="#fff"/></g>');
const note = (c) => vb(24, 24, `<g transform="translate(-12 -12)"><path d="M9 4.5 L19 2.5 V15.5" stroke="#fff" stroke-width="5" fill="none" stroke-linejoin="round"/><path d="M9 4.5 L19 2.5 V15.5 M9 4.5 V18" stroke="${c}" stroke-width="2.6" fill="none" stroke-linejoin="round" stroke-linecap="round"/><ellipse cx="6.5" cy="18.5" rx="3.6" ry="2.9" fill="${c}" stroke="#fff" stroke-width="1.4"/><ellipse cx="16.5" cy="16" rx="3.6" ry="2.9" fill="${c}" stroke="#fff" stroke-width="1.4"/></g>`);
const NOTE_COLS = ['#ff5cc6', '#b38cff', '#3fd7f6', '#ffcd3c'];

// a seeded random, so a creature's particles are the same every loop
const rnd = (seed) => {
  let x = (seed * 9301 + 49297) % 233280;
  return (a = 0, b = 1) => {
    x = (x * 9301 + 49297) % 233280;
    return a + (x / 233280) * (b - a);
  };
};

// One particle (squish-rig PT: init + upd, as positions over its life) seen
// in a loop of `period` ms, born at `at`. px → box units; the picture is
// drawn at its size (scale 1 = the picture's own size in px · FK).
function particle(kind, head, period, at, R) {
  const k = FK;
  let life;
  let upd;
  switch (kind) {
    case 'bubble': {
      life = R(2000, 2600);
      const x0 = F.cx + R(-0.9, 0.9) * F.rx;
      const y0 = F.cy + R(-0.2, 0.6) * F.ry;
      const vy = R(-45, -28) * k * PX;
      const s = R(12, 28) * k * PX;
      const seed = R(0, 10);
      upd = (age, a) => {
        const q = a > 0.92 ? (a - 0.92) / 0.08 : 0;
        return { x: x0 + Math.sin(age * 0.004 + seed) * 8 * k * PX, y: y0 + (vy * age) / 1000, scale: (s / 20) * (a > 0.92 ? 1 + q * 0.4 : Math.min(1, EF.bouncy(Math.min(1, a / 0.08)))), opacity: a > 0.92 ? 1 - q : 1 };
      };
      break;
    }
    case 'zzz': {
      life = 2600;
      const x0 = F.cx + F.rx * 0.35;
      const y0 = head + F.ry * 0.25;
      const s = 24 * k * PX;
      upd = (age, a) => ({ x: x0 + (16 * k * PX * age) / 1000 + Math.sin(age * 0.003) * 6 * k * PX, y: y0 - (24 * k * PX * age) / 1000, scale: (s / 20) * (0.6 + 0.7 * a), opacity: a < 0.15 ? a / 0.15 : a > 0.6 ? (1 - a) / 0.4 : 1, rot: -10 + 20 * a });
      break;
    }
    case 'haze': {
      life = 2800;
      const x0 = F.cx + R(-0.7, 0.7) * F.rx;
      const y0 = F.cy + R(0.1, 0.5) * F.ry;
      const s = 70 * k * PX;
      const seed = R(0, 10);
      upd = (age, a) => ({ x: x0 + Math.sin(age * 0.002 + seed) * 8 * k * PX, y: y0 - (14 * k * PX * age) / 1000, scale: (s / 20) * (0.6 + 0.9 * a), opacity: 0.5 * Math.sin(Math.PI * a) });
      break;
    }
    case 'note': {
      life = 1800;
      const side = R() < 0.5 ? -1 : 1;
      const x0 = F.cx + side * F.rx * R(0.45, 0.85);
      const y0 = head + F.ry * R(0.1, 0.5);
      const vx = side * R(8, 22) * k * PX;
      const vy = R(-50, -35) * k * PX;
      const s = R(18, 26) * k * PX;
      const seed = R(0, 10);
      upd = (age, a) => ({ x: x0 + (vx * age) / 1000 + Math.sin(age * 0.006 + seed) * 6 * k * PX, y: y0 + (vy * age) / 1000, rot: Math.sin(age * 0.008 + seed) * 15, scale: (s / 24) * (a < 0.15 ? EF.bouncy(a / 0.15) : 1), opacity: a > 0.6 ? (1 - a) / 0.4 : 1 });
      break;
    }
    case 'sparkle': {
      life = 800;
      const an = R(0, TAU);
      const d = R(0.65, 1.1);
      const x0 = F.cx + Math.cos(an) * F.rx * d;
      const y0 = F.cy + Math.sin(an) * F.ry * d;
      const s = R(12, 22) * k * PX;
      upd = (age, a) => ({ x: x0, y: y0, scale: (s / 24) * Math.sin(Math.PI * a), rot: a * 90 });
      break;
    }
    default:
      return null;
  }
  const pic = { bubble: BUBBLE, zzz: ZZZ, haze: HAZE, note: note(NOTE_COLS[Math.floor(R(0, 4))]), sparkle: SPARKLE }[kind];
  const t = spriteTrack(
    period,
    (tt) => {
      const age = (((tt - at) % period) + period) % period;
      if (age >= life) return { opacity: 0 };
      return upd(age, age / life);
    },
    { step: 30 }
  );
  return { ...pic, t };
}

// `rate` a second, each living `life`-ish: as many loops as overlap
function emitter(kind, rate, head, R) {
  const every = 1000 / rate;
  const life = { bubble: 2600, zzz: 2600, haze: 2800 }[kind];
  const count = Math.max(1, Math.ceil(life / every));
  const period = count * every;
  return Array.from({ length: count }, (_, i) => particle(kind, head, period, i * every, R));
}

// three flies on a figure-eight round the head (squish-rig PT.fly)
function flies(head) {
  const P = TAU / 0.0021;
  return [0, 1, 2].map((i) => ({
    ...FLY,
    t: spriteTrack(
      P,
      (age) => {
        const th = age * 0.0021 + i * 2.1;
        const d = Math.cos(th);
        return { x: F.cx + F.rx * 0.95 * Math.sin(th), y: head + F.ry * 0.3 + F.ry * 0.35 * Math.sin(2 * th), scale: (18 * FK * PX / 18) * (0.9 + 0.15 * d), opacity: 0.78 + 0.22 * d, rot: Math.sin(age * 0.03) * 10 };
      },
      { step: 30 }
    ),
  }));
}

// ---- a state's plan -----------------------------------------------------------------

// { body: track (channels tx, ty in box units; sx, sy, rot, skx, spin),
//   tint: [colour, alpha] | null, sprites }
export function carePlan(key, { head = 30, seed = 1 } = {}) {
  const R = rnd(seed);
  if (key === 'dance') {
    // groove, twirl, pop hop: 1.9 s each, with their notes and sparkles
    const P = DANCE_MS * 3;
    const body = sampleTrack(
      P,
      (t) => {
        const i = Math.min(2, Math.floor(t / DANCE_MS));
        const v = evalS(S[DANCES[i]], t - i * DANCE_MS);
        return { tx: v.tx, ty: v.ty, rot: v.rot, sy: v.sy, sx: v.sx, skx: v.skx, spin: v.spin };
      },
      BODY_NEUTRAL,
      { step: 20 }
    );
    const sprites = [];
    const at = (k, t) => k * DANCE_MS + t;
    [250, 750, 1250, 1750].forEach((t) => sprites.push(particle('note', head, P, at(0, t), R)));
    sprites.push(particle('note', head, P, at(1, 320), R));
    for (let q = 0; q < 5; q++) sprites.push(particle('sparkle', head, P, at(1, 1120), R));
    [0, 750, 1500].forEach((t) => {
      sprites.push(particle('note', head, P, at(2, t), R));
      for (let q = 0; q < 3; q++) sprites.push(particle('sparkle', head, P, at(2, t), R));
    });
    return { body, tint: S.dance1.tint, sprites };
  }
  const st = S[key] || S.idle;
  const body = sampleTrack(
    st.loop,
    (t) => {
      const v = evalS(st, t);
      return { tx: v.tx, ty: v.ty, rot: v.rot, sy: v.sy, sx: v.sx, skx: v.skx };
    },
    BODY_NEUTRAL,
    { step: 25 }
  );
  const sprites = [];
  if (st.bubbles) sprites.push(...emitter('bubble', 3, head, R));
  if (st.zzz) sprites.push(...emitter('zzz', st.zzz, head, R));
  if (st.haze) sprites.push(...emitter('haze', 1.2, head, R));
  if (st.flies) sprites.push(...flies(head));
  return { body, tint: st.tint || null, sprites };
}

// Which state a creature is in (Squad Crib v5 animFor), from what it's doing
// and how it looks (model.js lookOf / needOf).
export function careKey(pet, { look, need, yardGame, walking }) {
  if (walking) return 'walk';
  switch (pet.act) {
    case 'bath':
      return 'bathing';
    case 'eat':
      // a meal going: the plush layer does the eating; between meals it
      // shows how it feels (still hungry, say)
      if (pet.meal) return 'idle';
      break;
    case 'sleep':
      return 'sleeping';
    case 'dance':
      return 'dance';
    case 'yard':
      return yardGame === 'tramp' ? 'party' : 'play';
    case 'tv':
      if (!look) return 'play';
      break;
    default:
      break;
  }
  // how it feels (a creature in need shows it on the sofa and at the table too)
  if (look === 'smelly') return 'smelly';
  if (look === 'sad') return need === 'energy' ? 'tired' : need === 'tummy' ? 'hungry' : 'sad';
  return 'idle';
}
