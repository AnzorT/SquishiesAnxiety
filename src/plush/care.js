// The design's plush moods with their props (plush-anim.js: eatState,
// extras, and the per-element animation at the end of `frame`), as data the
// native driver can play: a PLAN for a mood.
//
//   {
//     body:    [track]            — the body's motion (motion.js tracks)
//     face:    { own, cover, layers: [{ key, mouth, op }] }
//              own: the drawing's own face shows under everything (and
//              blinks); cover: when it does, the opacity track of the
//              faceless art + face layers over it (null = always covered);
//              layers: mood faces (faces.js keys), each with an opacity
//              track or null (always on); `mouth: false` leaves the mouth
//              to a sprite (the chomp)
//     statics: SVG drawn in the creature's 0-100 box, moving with the body
//              (smudges, tears, the bath's foam, the spa's mask…)
//     sprites: [{ xml, w, h, t }] — small SVGs (viewBox centred on 0,0, w×h
//              box units) moved by a sprite track t: channels x, y (box
//              units), scale, sx, sy, rot (deg), opacity
//   }
//
// Tracks are sampled once per plan (the same functions of time as the
// design's frame loop). Tracks with the same period and loop share one
// Animated.Value in the component, so a sprite's motion stays in step with
// the body's. A meal is one one-shot track as long as the meal plus the full
// tummy afterwards, started at how far into it the creature already is.

import { foodOf } from '../crib/data';
import { BATH_FACE, backOut, breath, bump, clamp01, easeOut, moodTracks, noise, ss, track } from './motion';

const TAU = Math.PI * 2;
const n = (v) => +v.toFixed(2);
const INK = '#5b3a29';

// ---- sprite tracks ------------------------------------------------------------------

const SPRITE_NEUTRAL = { x: 0, y: 0, scale: 1, sx: 1, sy: 1, rot: 0, opacity: 1 };

// `fn(t)` sampled over one period, channels defaulting to `neutral`; a
// channel that never changes is kept as a plain number
export function sampleTrack(period, fn, neutral, { loop = true, step = 25 } = {}) {
  const count = Math.max(12, Math.ceil(period / step));
  const input = [];
  const ch = {};
  for (let i = 0; i <= count; i++) {
    const u = i / count;
    const v = { ...neutral, ...fn(loop && i === count ? 0 : u * period, u) };
    input.push(u);
    Object.keys(neutral).forEach((k) => (ch[k] = ch[k] || []).push(Number.isFinite(v[k]) ? v[k] : neutral[k]));
  }
  Object.keys(ch).forEach((k) => {
    if (ch[k].every((x) => x === ch[k][0])) ch[k] = ch[k][0];
  });
  return { period, loop, input, ch };
}
export const spriteTrack = (period, fn, opts) => sampleTrack(period, fn, SPRITE_NEUTRAL, opts);

// a 0/1 target eased toward like the design's face weights (dtm / 150)
function ramped(values, stepMs, ms = 150) {
  let w = values[0];
  return values.map((v) => {
    w = v > w ? Math.min(v, w + stepMs / ms) : Math.max(v, w - stepMs / ms);
    return w;
  });
}
// an opacity track from a sampled 0/1 function, eased in and out
function opTrack(period, on, { loop = true, step = 25 } = {}) {
  const t = track(period, (x) => ({ opacity: on(x) ? 1 : 0.0001 }), { loop, step });
  const a = t.channels.opacity || t.input.map(() => 1);
  t.channels = { opacity: ramped(a, period / (t.input.length - 1)).map((v) => Math.max(0, v)) };
  return t;
}

// ---- sprite pictures (viewBox centred on 0,0) ------------------------------------------

const vb = (w, h, body) => ({ xml: `<svg xmlns="http://www.w3.org/2000/svg" viewBox="${-w / 2} ${-h / 2} ${w} ${h}">${body}</svg>`, w, h });
const HEART = vb(10, 10, '<path d="M0 2.6c-1.6-1.4-4-2.6-4-4.6a2 2 0 0 1 4-0.6a2 2 0 0 1 4 0.6c0 2-2.4 3.2-4 4.6z" fill="#ff6fae" stroke="#fff" stroke-width="0.6"/>');
const SPARK = vb(10, 10, '<path d="M0 -4 Q0.6 -0.6 4 0 Q0.6 0.6 0 4 Q-0.6 0.6 -4 0 Q-0.6 -0.6 0 -4Z" fill="#fff6b8"/>');
// the design's ♪ glyph, drawn
const note = (c) => vb(12, 14, `<path d="M1.6 3 V-5 Q4.4 -3.6 4.6 -0.6" stroke="#fff" stroke-width="2.6" fill="none" stroke-linecap="round"/><path d="M1.6 3 V-5 Q4.4 -3.6 4.6 -0.6" stroke="${c}" stroke-width="1.3" fill="none" stroke-linecap="round"/><ellipse cx="-0.6" cy="3.4" rx="2.6" ry="2" fill="${c}" stroke="#fff" stroke-width="0.8"/>`);
// the design's "z" (Fredoka, lilac with a purple outline), drawn
const ZED = vb(9, 9, '<path d="M-2.6 -2.8 H2.6 L-2.6 2.8 H2.6" stroke="#6b5bd6" stroke-width="2.6" fill="none" stroke-linecap="round" stroke-linejoin="round"/><path d="M-2.6 -2.8 H2.6 L-2.6 2.8 H2.6" stroke="#ece6ff" stroke-width="1.1" fill="none" stroke-linecap="round" stroke-linejoin="round"/>');
const DROP = vb(4, 4, '<circle r="1.4" fill="#8fd3ff"/>');
const STINK = vb(8, 38, '<path d="M0 0 q-3 -3 0 -6 q3 -3 0 -6 q-3 -3 0 -6" stroke="#a3b38c" stroke-width="1.6" stroke-linecap="round" fill="none"/>');
const FSTEAM = vb(6, 26, '<path d="M0 0 q-2 -3 0 -6 q2 -3 0 -6" stroke="#fff" stroke-width="1.3" fill="none" stroke-linecap="round"/>');
const BSTEAM = vb(8, 30, '<path d="M0 0 q-2.5 -3.5 0 -7 q2.5 -3.5 0 -7" stroke="#fff" stroke-width="1.6" fill="none" stroke-linecap="round"/>');
const BUB = vb(6, 6, '<circle r="2" fill="rgba(210,244,255,0.35)" stroke="#fff" stroke-width="0.6"/>');
const rain = (c, w) => vb(4, 14, `<path d="M0 0 v6" stroke="${c}" stroke-width="${w}" stroke-linecap="round"/>`);
const MDROP = vb(4, 5, '<ellipse rx="1.4" ry="2" fill="#7a4a2a"/>');
const SWEAT = vb(3, 4, '<ellipse rx="0.9" ry="1.4" fill="#9fdcff"/>');
const SPLASH = vb(3, 3, '<circle r="1.3" fill="#8fd3ff"/>');
const DUCK = vb(18, 18, '<ellipse cx="0" cy="3" rx="6" ry="4" fill="#ffd23a" stroke="#5b3a29" stroke-width="0.8"/><circle cx="2.5" cy="-2" r="3.4" fill="#ffd23a" stroke="#5b3a29" stroke-width="0.8"/><path d="M5.6 -2 l3 0.8 l-3 0.8z" fill="#ff9a3c"/><circle cx="3" cy="-2.8" r="0.7" fill="#2a1a30"/>');
const duck2 = (c) => vb(16, 16, `<ellipse cx="0" cy="3" rx="5" ry="3.4" fill="${c}" stroke="#5b3a29" stroke-width="0.8"/><circle cx="2.2" cy="-1.6" r="2.9" fill="${c}" stroke="#5b3a29" stroke-width="0.8"/><path d="M4.8 -1.6 l2.6 0.7 l-2.6 0.7z" fill="#ff9a3c"/><circle cx="2.6" cy="-2.3" r="0.6" fill="#2a1a30"/>`);
const crumbDot = (c, r) => vb(3, 3, `<circle r="${r}" fill="${c}"/>`);
const JUICE = vb(3, 3, '<ellipse rx="0.9" ry="1.3" fill="#ffe14a"/>');
const BURP = vb(5, 5, '<circle r="2" fill="#fff" stroke="#e8d6f0" stroke-width="0.6"/>');
const STRAND = vb(3, 20, '<path d="M0 -10 V10" stroke="#ffe08a" stroke-width="1.5" stroke-linecap="round"/>');
const TV_GLOW = ['#7cc8ff', '#ff9fcb', '#ffe14a', '#9be38a'];

// ---- the eating (plush-anim.js eatState) ----------------------------------------------

const BITE_AT = { nibble: 0.16, chomp: 0.3, savor: 0.26, gulp: 0.6, slurp: 0.7 };
const FULL_MS = 3400; // the design's after-meal loop length

// what the eating looks like `el` ms into a meal of `ms` (t: the clock, for
// the little wobbles)
function eatState(F, m, ms, el, t) {
  const R = { v: { sy: 1, rot: 0, tx: 0, ty: 0 }, puff: 0, mo: 0, food: null, strand: 0, crumb: -1, burp: -1, steam: true, juice: -1, heart: false, face: 'eating' };
  const hx = m.x;
  const HY = (sc) => Math.min(70, m.y + 1 + 6 * sc);
  const hy = HY(1.7);
  if (el >= ms) {
    const f = el - ms;
    R.face = 'content';
    R.steam = false;
    const b = breath((f % 2400) / 2400);
    R.v.sy = 1 + 0.03 * b;
    R.v.rot = -4 + 1.5 * b;
    const bu = (f - 700) / 650;
    if (bu > 0 && bu < 1) {
      R.burp = bu;
      const hk = bump(bu / 0.35);
      R.v.sy *= 1 - 0.07 * hk;
      R.v.ty -= 2.5 * hk;
    }
    R.heart = f > 1300;
    return R;
  }
  const nb = F.bites;
  const w = ms / nb;
  const bi = Math.floor(el / w);
  const q = (el % w) / w;
  const qb = BITE_AT[F.style] || 0.3;
  const rem = 1 - (bi + ss((q - qb) / 0.05)) / nb;
  const aB = clamp01((q - qb) / (1 - qb));
  if (F.fx === 'crumbs' && q >= qb && q < qb + 0.32) R.crumb = (q - qb) / 0.32;
  switch (F.style) {
    case 'nibble': {
      const lean = bump(q / (qb * 2.2));
      const ch = q > qb ? (0.5 - 0.5 * Math.cos(TAU * aB * 4)) * (1 - aB * 0.5) : 0;
      R.mo = q < qb ? ss(q / qb) * 0.7 : ch * 0.8;
      R.v.ty = ch + lean;
      R.v.rot = 3 * lean + 1.2 * Math.sin(t / 300);
      R.v.sy = 1 - 0.03 * ch;
      const sc = 1.8 * (0.6 + 0.4 * rem);
      R.food = { x: hx, y: HY(sc) - 6 * lean, s: sc, r: F.k === 'carrot' ? 180 : 0 };
      break;
    }
    case 'chomp': {
      const wind = q < 0.24 ? ss(q / 0.24) : 0;
      const snap = q < 0.24 ? 0 : q < 0.34 ? ss((q - 0.24) / 0.1) : 1 - ss((q - 0.34) / 0.22);
      const ch = q > qb ? 0.5 - 0.5 * Math.cos(TAU * aB * 3) : 0;
      const imp = q > qb ? Math.exp((-(q - qb) * w) / 90) : 0;
      R.mo = q < 0.24 ? wind : q < qb ? 1 : ch * 0.8;
      R.puff = q > qb ? 0.07 * (1 - ss(aB)) : 0;
      R.v.rot = -3 * wind + 6 * snap;
      R.v.ty = 2 * snap + ch;
      R.v.sy = 1 + 0.03 * wind - 0.08 * imp - 0.03 * ch;
      const sc = 2.0 * (0.6 + 0.4 * rem);
      R.food = { x: hx, y: HY(sc) + 2 * wind - 8 * snap, s: sc, r: F.k === 'pizza' ? 180 : 0 };
      break;
    }
    case 'savor': {
      const lean = bump(q / (qb * 2.2));
      const ch = q > qb ? (0.5 - 0.5 * Math.cos(TAU * aB * 3)) * 0.7 : 0;
      const sway = q > qb ? Math.sin(TAU * aB * 1.5) * bump(aB) : 0;
      R.mo = q < qb ? ss(q / qb) * 0.8 : ch;
      R.face = q > qb + 0.08 && q < 0.9 ? 'content' : 'eating';
      R.v.rot = 2 * lean + 5 * sway;
      R.v.ty = lean;
      R.v.sy = 1 - 0.02 * ch;
      R.heart = F.fx === 'hearts' && q > qb;
      if (F.fx === 'juice' && q >= qb && q < qb + 0.5) R.juice = (q - qb) / 0.5;
      const sc = 1.8 * (0.6 + 0.4 * rem);
      R.food = { x: hx, y: HY(sc) - 6 * lean, s: sc, r: 0 };
      break;
    }
    case 'gulp': {
      const crouch = q < 0.25 ? ss(q / 0.25) : q < 0.32 ? 1 - ss((q - 0.25) / 0.07) : 0;
      const u = clamp01((q - 0.27) / (qb - 0.27));
      const look = q > 0.25 && q < 0.8 ? bump((q - 0.25) / 0.55) : 0;
      const sw = q >= qb ? Math.exp((-(q - qb) * w) / 110) : 0;
      const ch = q > qb ? (0.5 - 0.5 * Math.cos(TAU * aB * 2)) * 0.6 : 0;
      R.v.sy = 1 - 0.07 * crouch - 0.09 * sw + 0.04 * look;
      R.v.rot = -8 * look;
      R.v.ty = 1.5 * crouch;
      R.mo = q > 0.3 && q < qb ? 1 : ch;
      if (q < 0.27) R.food = { x: hx, y: hy + 1.5 * crouch, s: 1.7 * (F.k === 'marshmallow' ? 1 - 0.18 * crouch : 1), r: 0 };
      else if (q < qb) R.food = { x: hx + 5 * Math.sin(Math.PI * u), y: hy + (m.y - 1 - hy) * u - 30 * Math.sin(Math.PI * u), s: 1.7 * (1 - 0.4 * ss((u - 0.8) / 0.2)), r: 360 * u };
      else if (bi < nb - 1 && q > 0.82) R.food = { x: hx, y: hy, s: 1.7 * backOut((q - 0.82) / 0.18), r: 0 };
      break;
    }
    case 'slurp': {
      const on = q > 0.1 && q < qb;
      const su = clamp01((q - 0.1) / (qb - 0.1));
      const pop = q >= qb ? Math.exp((-(q - qb) * w) / 80) : 0;
      const ch = q > qb ? (0.5 - 0.5 * Math.cos(TAU * aB * 3)) * 0.6 : 0;
      R.v.sy = 1 + 0.05 * (on ? ss(su / 0.15) : 0) - 0.08 * pop - 0.02 * ch;
      R.v.rot = 4 * ss(q / 0.1) * (1 - ss((q - qb) / 0.15));
      R.v.tx = on ? 0.35 * Math.sin(t / 28) : 0;
      R.mo = on ? 0.45 : ch;
      R.strand = on ? 1 - su : 0;
      R.food = { x: m.x, y: Math.min(82, m.y + 20), s: 1.8, r: 0 };
      break;
    }
    default:
      break;
  }
  return R;
}

// the meal's plan: the body, the eating / content faces with the chomping
// mouth, the food and its crumbs, steam, juice, the noodle strand, the
// burp and the hearts afterwards
function eatPlan(rig, food, ms, seed) {
  const F = foodOf(food);
  if (!F) return null;
  const m = rig.mouth;
  const head = rig.head;
  const D = ms + FULL_MS;
  const step = 40;
  const at = (el) => eatState(F, m, ms, el, el + seed);
  const once = { loop: false, step };
  const body = track(
    D,
    (el) => {
      const R = at(el);
      return { ty: R.v.ty, tx: R.v.tx, rot: R.v.rot, sy: R.v.sy, puff: R.puff };
    },
    once
  );
  const eating = opTrack(D, (el) => at(el).face === 'eating', once);
  const content = opTrack(D, (el) => at(el).face === 'content', once);
  const sprites = [];
  // the chomp mouth opens and closes with the bites
  const mouth = vb(20, 20, `<g transform="translate(${-m.x} ${-m.y})"><ellipse cx="${m.x}" cy="${m.y}" rx="${n(m.w * 0.3)}" ry="${n(m.w * 0.24)}" fill="${rig.mouthInk}"/><ellipse cx="${m.x}" cy="${n(m.y + m.w * 0.12)}" rx="${n(m.w * 0.16)}" ry="${n(m.w * 0.08)}" fill="#ff8fb8"/></g>`);
  const eatOp = eating.channels.opacity;
  sprites.push({ ...mouth, t: spriteTrack(D, (el, u) => ({ x: m.x, y: m.y, sy: 0.35 + 0.65 * at(el).mo, opacity: eatOp[Math.round(u * (eatOp.length - 1))] }), once) });
  // the food itself
  if (F.svg) {
    const art = { xml: F.svg, w: 22, h: 22 };
    sprites.push({ ...art, t: spriteTrack(D, (el) => { const fo = at(el).food; return fo ? { x: fo.x, y: fo.y, scale: Math.max(0.001, fo.s), rot: fo.r } : { opacity: 0, x: m.x, y: m.y }; }, once) });
  }
  if (F.style === 'slurp') {
    const y0 = m.y + 1;
    const L = Math.min(82, m.y + 20) - 2 - y0;
    sprites.push({ ...STRAND, t: spriteTrack(D, (el) => { const s = at(el).strand; return s > 0.01 ? { x: m.x + 0.5, y: y0 + (L * s) / 2, sy: (L * s) / 20 } : { opacity: 0 }; }, once) });
  }
  if (F.fx === 'crumbs')
    [0, 1, 2, 3].forEach((i) =>
      sprites.push({
        ...crumbDot(F.crumb || '#e9b26a', 0.8 + (i % 2) * 0.4),
        t: spriteTrack(D, (el) => { const p = at(el).crumb; if (p < 0 || p >= 1) return { opacity: 0 }; const dir = i - 1.5; return { x: m.x + dir * 6 * easeOut(p), y: m.y + 3 - 3 * p + 14 * p * p, opacity: 1 - ss(p) }; }, once),
      })
    );
  if (F.fx === 'steam')
    [0, 1].forEach((i) =>
      sprites.push({
        ...FSTEAM,
        t: spriteTrack(D, (el) => {
          const R = at(el);
          const p = ((el + seed) / 1800 + i * 0.5) % 1;
          const base = R.food || { x: m.x + 9, y: m.y + 4 };
          return { x: base.x - 2 + i * 4 + Math.sin(p * TAU) * 1.5, y: base.y - 4 - p * 9, scale: 0.5 + 0.4 * p, opacity: R.steam ? 0.75 * bump(p) : 0 };
        }, once),
      })
    );
  if (F.fx === 'juice')
    [0, 1].forEach((i) =>
      sprites.push({
        ...JUICE,
        t: spriteTrack(D, (el) => { const J = at(el).juice; const p = J >= 0 ? clamp01(J * 1.4 - i * 0.4) : -1; return p <= 0 || p >= 1 ? { opacity: 0 } : { x: m.x + 5 + i * 3, y: m.y + 6 + 16 * p * p, opacity: 1 - ss(p) }; }, once),
      })
    );
  sprites.push({
    ...BURP,
    t: spriteTrack(D, (el) => { const p = at(el).burp; if (p < 0) return { opacity: 0 }; const e = easeOut(p); return { x: m.x + 4 + 7 * e, y: m.y - 2 - 6 * e, scale: (1.5 + 4.5 * e) / 2, opacity: 0.95 * (1 - ss(p)) }; }, once),
  });
  [0, 1].forEach((i) =>
    sprites.push({
      ...HEART,
      t: spriteTrack(D, (el) => {
        const p = ((el + seed) / 1700 + i / 2) % 1;
        return { x: (i ? 74 : 26) + 2 * Math.sin(p * TAU), y: head + 8 - easeOut(p) * 24, scale: p < 0.2 ? 0.8 * backOut(p / 0.2) : 0.8 + (p - 0.2) * 0.5, opacity: at(el).heart ? 1 - ss((p - 0.4) / 0.6) : 0 };
      }, once),
    })
  );
  return {
    body: [body],
    face: { own: false, cover: null, layers: [{ key: 'eating', mouth: false, op: eating }, { key: 'content', op: content }] },
    statics: null,
    sprites,
    oneShot: D,
  };
}

// ---- the other moods' props (plush-anim.js extras + frame) -----------------------------

const loopSprites = (pic, count, period, fn) => Array.from({ length: count }, (_, i) => ({ ...pic, t: spriteTrack(period, (t) => fn(i, ((t / period) + i / count) % 1, t)) }));

// the bath's static props, drawn in the 0-100 box
function bathStatics(st, rig, bb) {
  const head = rig.head;
  const ex = rig.eyes;
  const ecx = ex.reduce((a, e) => a + e.x, 0) / ex.length;
  const ecy = ex.reduce((a, e) => a + e.y, 0) / ex.length;
  const er = ex[0].r;
  const crownH = (big) =>
    [36, 42, 48, 54, 60, 64, 45, 55]
      .concat(big ? [32, 68, 50] : [])
      .map((x, i) => `<circle cx="${x}" cy="${n(head - (i > 5 ? 5 : 1) + (i % 2) - (i > 7 ? 7 : 0))}" r="${n((i > 5 ? 4.5 : 3.8) * (big ? 1.25 : 1))}" fill="#fff" stroke="#d6f2fc" stroke-width="0.6"/>`)
      .join('');
  const towel = (c) => `<ellipse cx="50" cy="${head + 1}" rx="17" ry="7" fill="${c}" stroke="${INK}" stroke-width="0.9"/><circle cx="62" cy="${head - 4}" r="4.5" fill="${c}" stroke="${INK}" stroke-width="0.9"/>`;
  if (st === 'tub' || st === 'duck' || st === 'shower') return crownH(false);
  if (st === 'bubble') {
    let f = '';
    const fy = ex[0].y;
    for (let yy = bb.y + 4; yy <= bb.y + bb.height + 2; yy += 7)
      for (let xx = bb.x + 2; xx <= bb.x + bb.width; xx += 7.5) {
        const jx = xx + ((Math.round(yy) * 7) % 4) - 2;
        const jy = yy + ((Math.round(xx) * 3) % 3) - 1;
        if (Math.pow((jx - ecx) / 19, 2) + Math.pow((jy - fy - 2) / 11, 2) < 1) continue;
        f += `<circle cx="${n(jx)}" cy="${n(jy)}" r="${n(4.2 + ((Math.round(xx + yy)) % 3) * 0.7)}" fill="#fff" stroke="#d6f2fc" stroke-width="0.6"/>`;
      }
    return f + crownH(true);
  }
  if (st === 'spa')
    return (
      `<ellipse cx="${n(ecx)}" cy="${n(ecy + 2)}" rx="${n(Math.abs(ex[ex.length - 1].x - ex[0].x) / 2 + er + 7)}" ry="${n(er + 8)}" fill="#a8d98a" opacity="0.75"/>` +
      ex.map((e) => `<circle cx="${e.x}" cy="${e.y}" r="${n(er + 1.6)}" fill="#d4f5b8" stroke="#5fb85a" stroke-width="1.3"/><circle cx="${e.x}" cy="${e.y}" r="${n(er * 0.55)}" fill="none" stroke="#a8d98a" stroke-width="0.8" stroke-dasharray="1 1.2"/>`).join('') +
      towel('#ff9db0')
    );
  if (st === 'mud') return `<path d="M${n(bb.x + 6)} ${head - 2} q8 6 16 0 q8 6 16 0 q8 6 16 0 q8 6 16 0" stroke="#8a5a38" stroke-width="5" fill="none" stroke-linecap="round" opacity="0.9"/>`;
  if (st === 'sauna') return `<ellipse cx="${n(bb.x + bb.width / 2)}" cy="${n(bb.y + bb.height * 0.55)}" rx="${n(bb.width / 2.2)}" ry="${n(bb.height / 2.4)}" fill="#ff7a7a" opacity="0.16"/>` + towel('#fff6e6');
  return '';
}

function bathSprites(st, rig, bb) {
  const head = rig.head;
  const out = [];
  const bub = (count) => loopSprites(BUB, count, 2400, (i, p) => ({ x: 26 + i * 12 + Math.sin(p * TAU + i) * 3, y: 80 - p * 60, scale: (1.5 + p * 2) / 2, opacity: p > 0.88 ? 1 - ss((p - 0.88) / 0.12) : ss(p / 0.08) }));
  const steam = (count) => loopSprites(BSTEAM, count, 2200, (i, p) => ({ x: 32 + i * 13 + Math.sin(p * TAU + i) * 2, y: head - 2 - p * 18, scale: 0.6 + 0.5 * p, opacity: 0.8 * bump(p) }));
  const rains = (pic) => loopSprites(pic, 7, 520, (i, p) => ({ x: 24 + i * 8.5, y: head - 22 + p * 60, opacity: 0.85 * bump(p) }));
  if (st === 'tub') out.push(...bub(5));
  if (st === 'bubble') out.push(...bub(9));
  if (st === 'hottub') out.push(...steam(3), ...bub(6));
  if (st === 'spa') out.push(...steam(2));
  if (st === 'duck') {
    ['#ffd23a', '#ff9db0', '#7cc8ff'].forEach((c, k) => {
      const i = k + 1;
      const P = TAU * (1600 + i * 300);
      out.push({
        ...duck2(c),
        t: spriteTrack(P, (t) => {
          const a = t / (1600 + i * 300) + i * 2.1;
          return { x: 50 + Math.cos(a) * 34, y: 74 + Math.sin(a) * 4 + 1.4 * Math.sin(t / 300 + i), sx: Math.cos(a) < 0 ? -1 : 1, rot: 6 * Math.sin(t / 400 + i) };
        }, { step: 40 }),
      });
    });
    out.push({ ...DUCK, t: spriteTrack(TAU * 900, (t) => ({ x: 78 + 3 * Math.sin(t / 900), y: 72 + 1.6 * Math.sin(t / 380), rot: 8 * Math.sin(t / 600) }), { step: 40 }) });
    out.push(...loopSprites(SPLASH, 3, 700, (i, p) => ({ x: 30 + i * 20 + (i - 1) * 8 * p, y: 74 - 16 * p + 22 * p * p, opacity: p < 0.8 ? 0.9 : (1 - p) * 4.5 })));
  }
  if (st === 'shower') out.push(...rains(rain('#8fd3ff', 1.3)));
  if (st === 'mud') {
    [[0.28, 0.7, 7], [0.7, 0.62, 6], [0.5, 0.86, 8], [0.22, 0.44, 4.5], [0.8, 0.82, 5], [0.62, 0.3, 4], [0.4, 0.25, 3.6]].forEach(([fx, fy, r], i) => {
      const pic = vb(r * 2 + 1, r * 1.5 + 1, `<ellipse rx="${r}" ry="${n(r * 0.75)}" fill="#8a5a38"/>`);
      out.push({ ...pic, t: spriteTrack(6000, (t) => { const p = ((t / 6000) + i * 0.13) % 1; return { x: bb.x + bb.width * fx, y: bb.y + bb.height * fy, opacity: 0.85 * Math.min(1, p * 3) * (p > 0.92 ? (1 - p) / 0.08 : 1) }; }, { step: 50 }) });
    });
    out.push(...rains(rain('#8a5a38', 2)));
    out.push(...loopSprites(MDROP, 3, 1100, (i, p) => ({ x: bb.x + bb.width * [0.3, 0.55, 0.75][i % 3], y: bb.y + bb.height * 0.55 + p * 30, opacity: bump(p) * 0.9 })));
  }
  if (st === 'sauna') {
    out.push(...steam(4));
    out.push(...loopSprites(SWEAT, 2, 1600, (i, p) => { const e = rig.eyes[i] || rig.eyes[0]; return { x: e.x + (i ? 6 : -6), y: e.y - 6 + p * 14, opacity: bump(p) * 0.9 }; }));
  }
  return out;
}

// the creature's body box in its 0-100 box (the design's getBBox), from the
// art's trimmed frame less its sticker outline
export const bbOf = (frame) => {
  if (!frame) return { x: 14, y: 14, width: 72, height: 78 };
  const [x, y, w, h] = frame;
  return { x: x * 100 + 3, y: y * 100 + 3, width: Math.max(10, w * 100 - 6), height: Math.max(10, h * 100 - 8) };
};

// Everything a mood draws besides the body art, and its motion.
// ctx: { h (hash), rig, frame (the art's), food, eatStart, eatMs, bathStyle, now }
const CACHE = new Map();
const CACHE_MAX = 400;
function cached(key, make) {
  if (CACHE.has(key)) return CACHE.get(key);
  const v = make();
  if (CACHE.size >= CACHE_MAX) CACHE.delete(CACHE.keys().next().value);
  CACHE.set(key, v);
  return v;
}

export function planMood(mood, ctx) {
  const { h, rig } = ctx;
  const seed = (h * 97) % 10000;
  if (mood === 'eat' && rig && ctx.food && ctx.eatMs) {
    const p = cached(`eat|${rig.key}|${h}|${ctx.food}|${ctx.eatMs}`, () => eatPlan(rig, ctx.food, ctx.eatMs, seed));
    if (p) return { ...p, start: Math.max(0, Math.min(0.999, ((ctx.now || Date.now()) - (ctx.eatStart || 0)) / p.oneShot)) };
  }
  return cached(`${mood}|${h}|${rig ? rig.key : '-'}|${ctx.frame ? ctx.frame.join(',') : '-'}|${ctx.bathStyle || ''}`, () => buildPlan(mood, ctx, seed));
}

function buildPlan(mood, ctx, seed) {
  const { h, rig } = ctx;
  const plan = { body: moodTracks(mood === 'eat' ? 'idle' : mood, h, { bathStyle: ctx.bathStyle }), face: null, statics: '', sprites: [] };
  if (!rig) return plan;
  const bb = bbOf(ctx.frame);
  const head = rig.head;
  const st = mood === 'bath' ? (ctx.bathStyle === 'washtub' ? 'tub' : ctx.bathStyle || 'tub') : '';
  switch (mood) {
    case 'sad':
      rig.eyes.forEach((e, i) => {
        const s = i ? 1 : -1;
        plan.statics += `<path d="M${e.x} ${n(e.y + e.r)} Q${n(e.x + s * 3)} ${n(e.y + e.r + 10)} ${n(e.x + s)} ${n(e.y + e.r + 22)}" stroke="#8fd3ff" stroke-width="2.4" stroke-linecap="round" fill="none" opacity="0.85" stroke-dasharray="4 3"/>`;
      });
      plan.sprites.push(...loopSprites(DROP, 2, 900, (i, p) => { const e = rig.eyes[i] || rig.eyes[0]; return { x: e.x + (i ? 1 : -1) * (1 + p * 2), y: e.y + e.r + 22 + p * p * 10, opacity: 1 - ss(p) }; }));
      break;
    case 'dirty':
      [[0.25, 0.72, 5], [0.72, 0.56, 4], [0.6, 0.86, 4.5], [0.34, 0.4, 3.2], [0.8, 0.8, 2.6]].forEach(([fx, fy, r]) => {
        plan.statics += `<ellipse cx="${n(bb.x + bb.width * fx)}" cy="${n(bb.y + bb.height * fy)}" rx="${r}" ry="${n(r * 0.7)}" fill="#6e6a75" opacity="0.32"/>`;
      });
      plan.sprites.push(...loopSprites(STINK, 3, 2000, (i, p) => ({ x: [38, 50, 62][i] + Math.sin(p * TAU) * 2, y: head - 2 - easeOut(p) * 12, opacity: bump(p) })));
      break;
    case 'bath':
      plan.statics += bathStatics(st, rig, bb);
      plan.sprites.push(...bathSprites(st, rig, bb));
      break;
    case 'clean':
      plan.sprites.push(...loopSprites(SPARK, 4, 1100, (i, p) => { const a = i * 1.7 + 0.6; return { x: 50 + Math.cos(a) * 34, y: 52 + Math.sin(a) * 32, scale: p < 0.35 ? backOut(p / 0.35) : 1 - ss((p - 0.35) / 0.65), rot: p * 90 }; }));
      break;
    case 'sleep':
      plan.sprites.push(...loopSprites(ZED, 3, 2600, (i, p) => ({ x: 60 + easeOut(p) * 18 + Math.sin(p * TAU) * 3, y: head + 4 - p * 22, scale: (6 + p * 6) / 9, opacity: p < 0.15 ? ss(p / 0.15) : 1 - ss((p - 0.15) / 0.85) })));
      break;
    case 'happy':
      plan.sprites.push(...loopSprites(HEART, 2, 1700, (i, p) => ({ x: (i ? 74 : 26) + 2 * Math.sin(p * TAU), y: head + 8 - easeOut(p) * 24, scale: p < 0.2 ? 0.8 * backOut(p / 0.2) : 0.8 + (p - 0.2) * 0.5, opacity: 1 - ss((p - 0.4) / 0.6) })));
      break;
    case 'dance':
      plan.sprites.push(...[0, 1].map((i) => ({ ...note(i ? '#b38cff' : '#ff5cc6'), t: spriteTrack(1500, (t) => { const p = ((t / 1500) + i / 2) % 1; return { x: i ? 76 + p * 8 : 18 - p * 8, y: head + 10 - easeOut(p) * 22, opacity: bump(p) }; }) })));
      break;
    case 'tv': {
      // its own face 45% of the time, then laughing, cheering, content; the
      // screen's colours on its eyes
      const P = 9000;
      const ph = (t) => (t % P) / P;
      const own = (t) => ph(t) < 0.45;
      plan.face = {
        own: true,
        cover: opTrack(P, (t) => !own(t)),
        layers: [
          { key: 'happy', op: opTrack(P, (t) => ph(t) >= 0.45 && ph(t) < 0.7) },
          { key: 'party', op: opTrack(P, (t) => ph(t) >= 0.7 && ph(t) < 0.82) },
          { key: 'content', op: opTrack(P, (t) => ph(t) >= 0.82) },
        ],
      };
      TV_GLOW.forEach((c, k) => {
        const glow = vb(100, 100, `<g transform="translate(-50 -50)">${rig.eyes.map((e) => `<circle cx="${e.x}" cy="${e.y}" r="${n(e.r * 1.05)}" fill="${c}"/>`).join('')}</g>`);
        plan.sprites.push({ ...glow, t: spriteTrack(2 * P, (t) => ({ x: 50, y: 50, opacity: Math.floor(t / 900) % 4 === k && own(t) ? 0.38 + 0.18 * noise(t * 9, 1) : 0 }), { step: 50 }) });
      });
      break;
    }
    default:
      break;
  }
  if (mood === 'bath') plan.faceKey = BATH_FACE[st] || 'content';
  return plan;
}

