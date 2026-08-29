import React, { useEffect, useMemo, useRef } from 'react';
import { Animated, Easing } from 'react-native';
import Svg, { Defs, RadialGradient, LinearGradient, Stop, Circle, Ellipse, Path, G } from 'react-native-svg';

// Literal port of the "Creature" component decoded out of "ASMR Creature
// Squash Game.html"'s own asset bundle (manifest entry 40fb4f7a…, the real
// dc-import source — not a re-derived approximation). Every inset/left/top/
// width/height/border-radius/gradient/box-shadow value below is transcribed
// straight from that file's per-creature `isC0`…`isC9` blocks, just
// converted from CSS-on-a-100x100-box to an SVG path in a 100x100 viewBox
// (percentages of the wrapper carry over 1:1 as viewBox units) and from
// `filter: grayscale(1) brightness(0.5)` (unsupported on RN Views) to a
// manual grayscale blend of the same fill colors.
//
// This is what every screen *except* SquishScreen shows (Splash floaters,
// the Home carousel card, Achievements badges, Store rows, the Loading
// screen). SquishScreen alone mounts the real interactive soft-body mesh
// (SquishyToy.js) — an unrelated, separately-designed 3D rig.

const W = 100; // viewBox units == wrapper percent

// ---- geometry helpers ------------------------------------------------

// CSS `inset` on the wrapper -> a child box in viewBox units.
function insetBox(top, right = top, bottom = top, left = right) {
  return { x: left, y: top, w: W - left - right, h: W - top - bottom };
}

// A box positioned by left/right + top + width/height, percent of `parent`.
function rect(parent, { left, right, top, width, height }) {
  const w = (width / 100) * parent.w;
  const h = (height / 100) * parent.h;
  const x = left != null ? parent.x + (left / 100) * parent.w : parent.x + parent.w - (right / 100) * parent.w - w;
  const y = parent.y + (top / 100) * parent.h;
  return { x, y, w, h };
}

// CSS border-radius corners, each [xPercentOfWidth, yPercentOfHeight] (no
// "/" split in the source ever separates x/y per corner beyond that, so one
// percent pair per corner is exact), rendered as an elliptical-arc path —
// the same primitive the browser itself uses for border-radius.
function blobPath(box, corners) {
  const { x, y, w, h } = box;
  const c = (pct, dim) => (pct / 100) * dim;
  const tl = [c(corners.tl[0], w), c(corners.tl[1], h)];
  const tr = [c(corners.tr[0], w), c(corners.tr[1], h)];
  const br = [c(corners.br[0], w), c(corners.br[1], h)];
  const bl = [c(corners.bl[0], w), c(corners.bl[1], h)];
  // CSS's own border-radius overlap correction (spec §5.5): if adjacent
  // corners' radii would sum past an edge's length, every radius is scaled
  // down by the same factor so they meet exactly instead of overlapping —
  // needed here because a couple of the mouths below use a single radius
  // percentage past 50% (e.g. Glorp's 60%), which butts tl+tr/bl+br past
  // 100% of the box.
  const f = Math.min(1, w / (tl[0] + tr[0]), w / (bl[0] + br[0]), h / (tl[1] + bl[1]), h / (tr[1] + br[1]));
  if (f < 1) [tl, tr, br, bl].forEach((r) => { r[0] *= f; r[1] *= f; });
  return [
    `M ${x + tl[0]},${y}`,
    `L ${x + w - tr[0]},${y}`,
    `A ${tr[0]},${tr[1]} 0 0 1 ${x + w},${y + tr[1]}`,
    `L ${x + w},${y + h - br[1]}`,
    `A ${br[0]},${br[1]} 0 0 1 ${x + w - br[0]},${y + h}`,
    `L ${x + bl[0]},${y + h}`,
    `A ${bl[0]},${bl[1]} 0 0 1 ${x},${y + h - bl[1]}`,
    `L ${x},${y + tl[1]}`,
    `A ${tl[0]},${tl[1]} 0 0 1 ${x + tl[0]},${y}`,
    'Z',
  ].join(' ');
}

const CIRCLE = { tl: [50, 50], tr: [50, 50], br: [50, 50], bl: [50, 50] };

// The CSS "smile" mouth (`border-radius: 0 0 R% R%`, flat top / round
// bottom) and Nubbin's fully-round "surprised" mouth (`border-radius:50%`).
function mouthPath(box, radiusPct) {
  return blobPath(box, { tl: [0, 0], tr: [0, 0], br: [radiusPct, radiusPct], bl: [radiusPct, radiusPct] });
}

// The CSS border-trick upward triangle (border-left/right transparent,
// border-bottom solid): apex at (apexX, top), base at top+heightPct.
function trianglePath(parent, { apexXPct, right, topPct, halfWPct, heightPct }) {
  const apexX = parent.x + ((right != null ? 100 - right : apexXPct) / 100) * parent.w;
  const top = parent.y + (topPct / 100) * parent.h;
  const halfW = (halfWPct / 100) * parent.w;
  const height = (heightPct / 100) * parent.h;
  return `M ${apexX},${top} L ${apexX - halfW},${top + height} L ${apexX + halfW},${top + height} Z`;
}

function polygonPath(box, pointsPct) {
  return (
    pointsPct
      .map(([px, py], i) => `${i === 0 ? 'M' : 'L'} ${box.x + (px / 100) * box.w},${box.y + (py / 100) * box.h}`)
      .join(' ') + ' Z'
  );
}

function gradientVector(angleDeg) {
  const rad = (angleDeg * Math.PI) / 180;
  const dx = Math.sin(rad) * 0.5;
  const dy = -Math.cos(rad) * 0.5;
  return { x1: `${(0.5 - dx) * 100}%`, y1: `${(0.5 - dy) * 100}%`, x2: `${(0.5 + dx) * 100}%`, y2: `${(0.5 + dy) * 100}%` };
}

// ---- grayscale (stands in for CSS `filter: grayscale(1) brightness(0.5)`
// applied to the whole locked creature) ----
function hexToRgb(hex) {
  const n = parseInt(hex.slice(1), 16);
  return [(n >> 16) & 255, (n >> 8) & 255, n & 255];
}
function grayscaleDim(hex, brightness = 0.5) {
  const [r, g, b] = hexToRgb(hex);
  const gray = (0.299 * r + 0.587 * g + 0.114 * b) * brightness;
  const v = Math.round(Math.max(0, Math.min(255, gray)));
  return `rgb(${v},${v},${v})`;
}

// ---- eyes / mouth (identical shape everywhere, just re-positioned) ----

function EyePair({ parent, leftPct, rightPct, topPct, size, gray }) {
  const l = rect(parent, { left: leftPct, top: topPct, width: size, height: size });
  const r = rect(parent, { right: rightPct, top: topPct, width: size, height: size });
  return (
    <>
      {[l, r].map((box, i) => {
        const pupil = rect(box, { left: 28, top: 28, width: 44, height: 44 });
        return (
          <React.Fragment key={i}>
            <Circle cx={box.x + box.w / 2} cy={box.y + box.h / 2} r={box.w / 2} fill={gray ? '#c9c9c9' : '#ffffff'} />
            <Circle cx={pupil.x + pupil.w / 2} cy={pupil.y + pupil.h / 2} r={pupil.w / 2} fill="#0f172a" />
          </React.Fragment>
        );
      })}
    </>
  );
}

function SleepyEyes({ parent, leftPct, rightPct, topPct, w, h, gray }) {
  const l = rect(parent, { left: leftPct, top: topPct, width: w, height: h });
  const r = rect(parent, { right: rightPct, top: topPct, width: w, height: h });
  const color = gray ? '#3a3a3a' : '#0f172a';
  return (
    <>
      <Path d={blobPath(l, { tl: [30, 50], tr: [30, 50], br: [30, 50], bl: [30, 50] })} fill={color} />
      <Path d={blobPath(r, { tl: [30, 50], tr: [30, 50], br: [30, 50], bl: [30, 50] })} fill={color} />
    </>
  );
}

function Mouth({ parent, leftPct, rightPct, topPct, wPct, hPct, radiusPct = 50, ellipse = false, gray }) {
  const box = rect(parent, { left: leftPct, right: rightPct, top: topPct, width: wPct, height: hPct });
  const color = gray ? '#3a3a3a' : '#0f172a';
  if (ellipse) return <Ellipse cx={box.x + box.w / 2} cy={box.y + box.h / 2} rx={box.w / 2} ry={box.h / 2} fill={color} />;
  return <Path d={mouthPath(box, radiusPct)} fill={color} />;
}

// ---- per-creature render ----------------------------------------------

// Glorp and Noodle are single-eyed ("cyclops") — one big white oval with a
// pupil and a subtle raised shadow, centered rather than paired left/right.
function CyclopsEye({ parent, leftPct, topPct, sizePct, gray }) {
  const box = rect(parent, { left: leftPct, top: topPct, width: sizePct, height: sizePct });
  const pupil = rect(box, { left: 28, top: 28, width: 44, height: 44 });
  return (
    <>
      <Circle cx={box.x + box.w / 2} cy={box.y + box.h / 2} r={box.w / 2} fill={gray ? '#c9c9c9' : '#ffffff'} />
      <Circle cx={pupil.x + pupil.w / 2} cy={pupil.y + pupil.h / 2} r={pupil.w / 2} fill="#0f172a" />
    </>
  );
}

// ---- per-creature visual spec (transcribed 1:1 from the decoded HTML) ----

const CREATURES = {
  0: { // Glorp
    body: { inset: [8, 8, 8, 8], corners: { tl: [60, 55], tr: [40, 45], br: [55, 60], bl: [45, 40] }, angle: 160, from: '#5eead4', to: '#0d9488', shadow: '#0d9488' },
    extras: (b, gray) => {
      const antBox = rect({ x: 0, y: 0, w: W, h: W }, { left: 22, top: -6, width: 8, height: 18 });
      return <Path key="ant" d={blobPath(antBox, { tl: [50, 60], tr: [50, 60], br: [50, 40], bl: [50, 40] })} fill={gray ? '#8a8a8a' : 'url(#antennaGrad0)'} />;
    },
    antGrad: { angle: 180, from: '#5eead4', to: '#2dd4bf' },
    eyes: { type: 'cyclops', leftPct: 32, topPct: 30, sizePct: 34 },
    mouth: { leftPct: 40, topPct: 66, wPct: 20, hPct: 10, radiusPct: 60 },
  },
  1: { // Puffle
    body: { inset: [10, 10, 10, 10], corners: CIRCLE, radial: { cx: '35%', cy: '30%' }, from: '#f5d0fe', to: '#c084fc', shadow: '#a855f7' },
    extras: (b, gray) => (
      <>
        <Circle key="el" cx={2 + 10} cy={6 + 10} r={10} fill={gray ? '#8a8a8a' : '#e9d5ff'} />
        <Circle key="er" cx={100 - 2 - 10} cy={6 + 10} r={10} fill={gray ? '#8a8a8a' : '#e9d5ff'} />
      </>
    ),
    eyes: { type: 'pair', leftPct: 26, rightPct: 26, topPct: 36, sizePct: 16 },
    mouth: { leftPct: 38, topPct: 60, wPct: 24, hPct: 10, radiusPct: 50 },
    blush: { leftPct: 12, rightPct: 12, topPct: 52, wPct: 14, hPct: 9, color: '#f472b6' },
  },
  2: { // Nubbin
    body: { inset: [10, 10, 10, 10], corners: { tl: [48, 52], tr: [52, 48], br: [45, 52], bl: [55, 48] }, angle: 160, from: '#fdba74', to: '#ea580c', shadow: '#ea580c' },
    extras: (b, gray) => (
      <>
        <Path key="hl" d={trianglePath({ x: 0, y: 0, w: W, h: W }, { apexXPct: 16, topPct: 2, halfWPct: 7, heightPct: 16 })} fill={gray ? '#8a8a8a' : '#fb923c'} />
        <Path key="hr" d={trianglePath({ x: 0, y: 0, w: W, h: W }, { right: 16, topPct: 2, halfWPct: 7, heightPct: 16 })} fill={gray ? '#8a8a8a' : '#fb923c'} />
      </>
    ),
    eyes: { type: 'sleepy', leftPct: 28, rightPct: 28, topPct: 40, wPct: 16, hPct: 4 },
    mouth: { leftPct: 38, topPct: 62, wPct: 24, hPct: 12, ellipse: true },
  },
  3: { // Dotty
    body: { inset: [8, 8, 8, 8], corners: { tl: [50, 65], tr: [50, 65], br: [45, 35], bl: [45, 35] }, angle: 160, from: '#fef08a', to: '#eab308', shadow: '#eab308' },
    extras: (b, gray) => (
      <>
        <Circle key="d1" cx={b.x + (b.w * 26) / 100} cy={b.y + (b.h * 28) / 100} r={(b.w * 12) / 100 / 2} fill="#ffffff" opacity={0.85} />
        <Circle key="d2" cx={b.x + b.w - (b.w * 24) / 100 - (b.w * 9) / 100 / 2} cy={b.y + (b.h * 40) / 100 + (b.h * 9) / 100 / 2} r={(b.w * 9) / 100 / 2} fill="#ffffff" opacity={0.85} />
        <Circle key="d3" cx={b.x + (b.w * 36) / 100 + (b.w * 10) / 100 / 2} cy={b.y + (b.h * 62) / 100 + (b.h * 10) / 100 / 2} r={(b.w * 10) / 100 / 2} fill="#ffffff" opacity={0.85} />
      </>
    ),
    eyes: { type: 'pair', leftPct: 30, rightPct: 30, topPct: 42, sizePct: 15 },
    mouth: { leftPct: 40, topPct: 66, wPct: 20, hPct: 9, radiusPct: 50 },
  },
  4: { // Spike
    body: { inset: [10, 10, 10, 10], corners: CIRCLE, angle: 160, from: '#86efac', to: '#16a34a', shadow: '#16a34a' },
    extras: (b, gray) => (
      <>
        <Path key="l1" d={trianglePath({ x: 0, y: 0, w: W, h: W }, { apexXPct: 20, topPct: 0, halfWPct: 6, heightPct: 14 })} fill={gray ? '#8a8a8a' : '#22c55e'} />
        <Path key="l2" d={trianglePath({ x: 0, y: 0, w: W, h: W }, { apexXPct: 46, topPct: -4, halfWPct: 6, heightPct: 16 })} fill={gray ? '#8a8a8a' : '#22c55e'} />
        <Path key="l3" d={trianglePath({ x: 0, y: 0, w: W, h: W }, { right: 20, topPct: 0, halfWPct: 6, heightPct: 14 })} fill={gray ? '#8a8a8a' : '#22c55e'} />
      </>
    ),
    eyes: { type: 'pair', leftPct: 28, rightPct: 28, topPct: 38, sizePct: 14 },
    mouth: { leftPct: 40, topPct: 64, wPct: 20, hPct: 9, radiusPct: 50 },
  },
  5: { // Stellie — star; eyes/mouth are siblings of the (clipped) body, not nested
    body: { inset: [6, 6, 6, 6], star: true, angle: 160, from: '#fbcfe8', to: '#ec4899', shadow: '#ec4899', noInsetShadow: true },
    eyesOnWrapper: { type: 'pair', leftPct: 34, rightPct: 34, topPct: 46, sizePct: 13 },
    mouthOnWrapper: { leftPct: 42, topPct: 66, wPct: 16, hPct: 8, radiusPct: 50 },
  },
  6: { // Puffington — cloud: 2 plain side lobes + 1 front lobe carrying the face
    body: { inset: [14, 16, 30, 16], corners: CIRCLE, angle: 160, from: '#f0f9ff', to: '#38bdf8', shadow: '#38bdf8' },
    extras: (b, gray) => (
      <>
        <Circle key="lobeL" cx={6 + 22} cy={30 + 22} r={22} fill={gray ? '#a0a0a0' : 'url(#cloudSide6)'} />
        <Circle key="lobeR" cx={100 - 6 - 22} cy={30 + 22} r={22} fill={gray ? '#a0a0a0' : 'url(#cloudSide6)'} />
      </>
    ),
    eyes: { type: 'sleepy', leftPct: 30, rightPct: 30, topPct: 44, wPct: 12, hPct: 6 },
    mouth: { leftPct: 42, topPct: 62, wPct: 16, hPct: 8, radiusPct: 50 },
  },
  7: { // Noodle — flat-bottomed dome + tentacles, single cyclops eye
    body: { inset: [10, 10, 24, 10], corners: { tl: [50, 60], tr: [50, 60], br: [45, 40], bl: [45, 40] }, angle: 160, from: '#c4b5fd', to: '#7c3aed', shadow: '#7c3aed' },
    extras: (b, gray) => (
      <>
        <Ellipse key="t1" cx={30 + (9 * W) / 100 / 2} cy={80 + (22 * W) / 100 / 2} rx={(9 * W) / 100 / 2} ry={(22 * W) / 100 / 2} fill={gray ? '#8a8a8a' : '#a78bfa'} />
        <Ellipse key="t2" cx={46 + (9 * W) / 100 / 2} cy={82 + (26 * W) / 100 / 2} rx={(9 * W) / 100 / 2} ry={(26 * W) / 100 / 2} fill={gray ? '#8a8a8a' : '#a78bfa'} />
        <Ellipse key="t3" cx={100 - 30 - (9 * W) / 100 / 2} cy={80 + (22 * W) / 100 / 2} rx={(9 * W) / 100 / 2} ry={(22 * W) / 100 / 2} fill={gray ? '#8a8a8a' : '#a78bfa'} />
      </>
    ),
    eyes: { type: 'cyclops', leftPct: 36, topPct: 32, sizePct: 28 },
    mouth: { leftPct: 42, topPct: 68, wPct: 16, hPct: 8, radiusPct: 50 },
  },
  8: { // Glimmer — faceted gem pentagon; eyes/mouth are siblings again
    body: { inset: [6, 6, 6, 6], pentagon: true, angle: 160, from: '#a5f3fc', to: '#06b6d4', shadow: '#06b6d4', noInsetShadow: true },
    eyesOnWrapper: { type: 'pair', leftPct: 34, rightPct: 34, topPct: 44, sizePct: 13 },
    mouthOnWrapper: { leftPct: 42, topPct: 64, wPct: 16, hPct: 8, radiusPct: 50 },
  },
  9: { // Ember
    body: { inset: [10, 10, 10, 10], corners: CIRCLE, angle: 160, from: '#fca5a5', to: '#dc2626', shadow: '#f87171', trueGlow: true },
    extras: (b, gray) => (
      <Path key="flame" d={trianglePath({ x: 0, y: 0, w: W, h: W }, { apexXPct: 38, topPct: -8, halfWPct: 9, heightPct: 20 })} fill={gray ? '#8a8a8a' : '#fbbf24'} />
    ),
    eyes: { type: 'pair', leftPct: 28, rightPct: 28, topPct: 38, sizePct: 14 },
    mouth: { leftPct: 40, topPct: 64, wPct: 20, hPct: 9, radiusPct: 50 },
  },
};

const STAR_POINTS = [
  [50, 0], [63, 35], [100, 38], [71, 60], [82, 96], [50, 74], [18, 96], [29, 60], [0, 38], [37, 35],
];
const PENTAGON_POINTS = [
  [50, 0], [100, 40], [76, 100], [24, 100], [0, 40],
];

// ---- mood animation (translated from the source's @keyframes) ----

const MOOD_ANIM = {
  idle: { dur: 2.6, kf: [[0, 0, 1, 0], [0.5, -8, 1, -2], [1, 0, 1, 0]] },
  jump: { dur: 1.1, kf: [[0, 0, 1, 0], [0.15, 2, 0.9, 0], [0.4, -26, 1.08, 0], [0.6, 0, 0.95, 0], [0.8, -4, 1.02, 0], [1, 0, 1, 0]] },
  wobble: { dur: 1.7, kf: [[0, 0, 1, -6], [0.5, 0, 1, 6], [1, 0, 1, -6]] },
  sleep: { dur: 2.6, kf: [[0, 0, 1, 0], [0.5, -3, 1.02, 0], [1, 0, 1, 0]] },
  ready: { dur: 1.1, kf: [[0, 0, 1, 0], [0.5, 0, 1.06, 0], [1, 0, 1, 0]] },
  celebrate: { dur: 0.5, iterations: 3, kf: [[0, 0, 1, 0], [0.25, -30, 1.1, 0], [0.5, 0, 0.95, 0], [0.75, -30, 1.1, 0], [1, 0, 1, 0]] },
};

function useMoodAnimation(mood, size, animate = true) {
  const spec = MOOD_ANIM[mood] || MOOD_ANIM.idle;
  const progress = useRef(new Animated.Value(0)).current;

  useEffect(() => {
    if (!animate) {
      // Held still — e.g. mounted inside SquishyToy2D, which drives its own
      // squash/wobble transform on a wrapper around this SVG.
      progress.setValue(0);
      return undefined;
    }
    progress.setValue(0);
    const single = Animated.timing(progress, {
      toValue: 1,
      duration: spec.dur * 1000,
      easing: Easing.inOut(Easing.sin),
      useNativeDriver: true,
    });
    const looped = spec.iterations ? Animated.loop(single, { iterations: spec.iterations }) : Animated.loop(single);
    looped.start();
    return () => looped.stop();
  }, [mood, progress, spec.dur, spec.iterations, animate]);

  const inputRange = spec.kf.map((k) => k[0]);
  const translateY = progress.interpolate({ inputRange, outputRange: spec.kf.map((k) => (k[1] / 100) * size) });
  const scale = progress.interpolate({ inputRange, outputRange: spec.kf.map((k) => k[2]) });
  const rotate = progress.interpolate({ inputRange, outputRange: spec.kf.map((k) => `${k[3]}deg`) });
  return { translateY, scale, rotate };
}

// ---- the component ------------------------------------------------------

export default function CreatureThumbnail({ creatureId, mood = 'idle', size = 90, locked = false, animate = true }) {
  const spec = CREATURES[creatureId] ?? CREATURES[0];
  const { translateY, scale, rotate } = useMoodAnimation(mood, size, animate);

  const gradId = `body-${creatureId}`;

  const bodyBox = useMemo(() => insetBox(...spec.body.inset), [spec]);

  const gray = locked;
  const gradFrom = gray ? grayscaleDim(spec.body.from) : spec.body.from;
  const gradTo = gray ? grayscaleDim(spec.body.to) : spec.body.to;
  const vec = gradientVector(spec.body.angle ?? 160);
  const bodyFill = `url(#${gradId})`;

  let bodyPathD = null;
  if (spec.body.star) bodyPathD = polygonPath(bodyBox, STAR_POINTS);
  else if (spec.body.pentagon) bodyPathD = polygonPath(bodyBox, PENTAGON_POINTS);
  else bodyPathD = blobPath(bodyBox, spec.body.corners);

  // --- the glow / drop-shadow around the body ---------------------------
  // The source draws this with a CSS `box-shadow` (`0 14px 26px rgba(...)`,
  // or `0 0 30px` for Ember) — a blur of the body's *own silhouette*, so it
  // hugs the blob shape and feathers out smoothly. react-native-svg 15.2
  // has no blur filter, and a radial-gradient disc doesn't follow the
  // silhouette (it reads as a separate circle behind the creature). Instead
  // we stack several copies of the body path, each scaled up a little more
  // and drawn at a low opacity: where they overlap the alpha builds up, so
  // the union is a soft shape-matched halo that fades to nothing at the rim.
  const glowColor = gray ? grayscaleDim(spec.body.shadow) : spec.body.shadow;
  const bcx = bodyBox.x + bodyBox.w / 2;
  const bcy = bodyBox.y + bodyBox.h / 2;
  const glowDy = spec.body.trueGlow ? 0 : 5; // match the source's 14px vertical offset
  const glowLayers = spec.body.trueGlow
    ? [[1.42, 0.04], [1.34, 0.05], [1.26, 0.06], [1.19, 0.07], [1.13, 0.08], [1.08, 0.1], [1.04, 0.12]]
    : [[1.27, 0.035], [1.21, 0.045], [1.155, 0.055], [1.11, 0.07], [1.07, 0.085], [1.035, 0.1]];

  const eyesParentBox = spec.eyesOnWrapper ? { x: 0, y: 0, w: W, h: W } : bodyBox;
  const eyesSpec = spec.eyesOnWrapper || spec.eyes;
  const mouthSpec = spec.mouthOnWrapper || spec.mouth;

  return (
    <Animated.View
      style={{
        width: size,
        height: size,
        alignItems: 'center',
        justifyContent: 'center',
        opacity: locked ? 0.88 : 1,
        transform: [{ translateY }, { scale }, { rotate }],
      }}
    >
      <Svg width={size} height={size} viewBox={`0 0 ${W} ${W}`}>
        <Defs>
          {spec.body.radial ? (
            <RadialGradient id={gradId} cx={spec.body.radial.cx} cy={spec.body.radial.cy} r="75%">
              <Stop offset="0%" stopColor={gradFrom} />
              <Stop offset="70%" stopColor={gradTo} />
              <Stop offset="100%" stopColor={gradTo} />
            </RadialGradient>
          ) : (
            <LinearGradient id={gradId} x1={vec.x1} y1={vec.y1} x2={vec.x2} y2={vec.y2}>
              <Stop offset="0%" stopColor={gradFrom} />
              <Stop offset="100%" stopColor={gradTo} />
            </LinearGradient>
          )}
          {String(creatureId) === '0' ? (
            <LinearGradient id="antennaGrad0" x1="50%" y1="0%" x2="50%" y2="100%">
              <Stop offset="0%" stopColor={gray ? grayscaleDim('#5eead4') : '#5eead4'} />
              <Stop offset="100%" stopColor={gray ? grayscaleDim('#2dd4bf') : '#2dd4bf'} />
            </LinearGradient>
          ) : null}
          {String(creatureId) === '6' ? (
            <LinearGradient id="cloudSide6" x1="50%" y1="0%" x2="50%" y2="100%">
              <Stop offset="0%" stopColor={gray ? grayscaleDim('#e0f2fe') : '#e0f2fe'} />
              <Stop offset="100%" stopColor={gray ? grayscaleDim('#7dd3fc') : '#7dd3fc'} />
            </LinearGradient>
          ) : null}
        </Defs>

        {glowLayers.map(([s, op], i) => (
          <G key={`glow-${i}`} scale={s} originX={bcx} originY={bcy} y={glowDy}>
            <Path d={bodyPathD} fill={glowColor} opacity={op} />
          </G>
        ))}

        {spec.extras ? spec.extras(bodyBox, gray) : null}

        <Path d={bodyPathD} fill={bodyFill} />
        {/* soft glossy highlight to stand in for the source's inset light shadow */}
        <Ellipse
          cx={bodyBox.x + bodyBox.w * 0.34}
          cy={bodyBox.y + bodyBox.h * 0.28}
          rx={bodyBox.w * 0.22}
          ry={bodyBox.h * 0.16}
          fill="#ffffff"
          opacity={gray ? 0.12 : 0.22}
        />

        {spec.blush
          ? (() => {
              const { leftPct, rightPct, topPct, wPct, hPct, color } = spec.blush;
              const l = rect(bodyBox, { left: leftPct, top: topPct, width: wPct, height: hPct });
              const r = rect(bodyBox, { right: rightPct, top: topPct, width: wPct, height: hPct });
              return [l, r].map((box, i) => (
                <Ellipse key={i} cx={box.x + box.w / 2} cy={box.y + box.h / 2} rx={box.w / 2} ry={box.h / 2} fill={gray ? grayscaleDim(color) : color} opacity={0.6} />
              ));
            })()
          : null}

        {eyesSpec.type === 'cyclops' ? (
          <CyclopsEye parent={eyesParentBox} leftPct={eyesSpec.leftPct} topPct={eyesSpec.topPct} sizePct={eyesSpec.sizePct} gray={gray} />
        ) : eyesSpec.type === 'sleepy' ? (
          <SleepyEyes parent={eyesParentBox} leftPct={eyesSpec.leftPct} rightPct={eyesSpec.rightPct} topPct={eyesSpec.topPct} w={eyesSpec.wPct} h={eyesSpec.hPct} gray={gray} />
        ) : (
          <EyePair parent={eyesParentBox} leftPct={eyesSpec.leftPct} rightPct={eyesSpec.rightPct} topPct={eyesSpec.topPct} size={eyesSpec.sizePct} gray={gray} />
        )}

        <Mouth
          parent={spec.mouthOnWrapper ? { x: 0, y: 0, w: W, h: W } : bodyBox}
          leftPct={mouthSpec.leftPct}
          rightPct={mouthSpec.rightPct}
          topPct={mouthSpec.topPct}
          wPct={mouthSpec.wPct}
          hPct={mouthSpec.hPct}
          radiusPct={mouthSpec.radiusPct}
          ellipse={mouthSpec.ellipse}
          gray={gray}
        />
      </Svg>
    </Animated.View>
  );
}
