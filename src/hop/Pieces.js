import React, { memo, useMemo } from 'react';
import { Animated, StyleSheet, Text, View } from 'react-native';
import Svg, { Circle, Defs, Ellipse, Path, RadialGradient, Stop } from 'react-native-svg';
import { usePingPong, useKeyLoop } from '../components/idleLoop';
import { Squishy } from '../stack/Pieces';
import { F } from '../squishdoku/theme';
import { cellBox, chevron, polyPath, project, roundRect } from './board';

// What Squish Hop draws on its board (SQUISH_HOP.md), all in the board's
// perspective (board.js): Squish Stack's stitched cushions laid flat on the
// floor (a pile is two, one on the other), the Crib's dance-floor tiles in
// the Dance Room, arrows printed on them, bubbles floating over them, the ★,
// the squishies standing on them, and the hint's glow.

// Squish Stack's cushion colours (stack/Pieces.js CUSHIONS); peach is the ★
export const CUSH = {
  pink: { c1: '#ffd9f3', c2: '#ff86d3', ring: '#a3168f' },
  mint: { c1: '#cffff7', c2: '#3fd6c6', ring: '#0b6670' },
  lilac: { c1: '#ebdcff', c2: '#a77bff', ring: '#4b1ca0' },
  peach: { c1: '#fff0cf', c2: '#ffb257', ring: '#9c4d06' },
};
// the Crib's dance floor (crib/Dance.js): its four tile colours in a 2 × 2
// pattern; on beat levels the plain tiles are its mint and the three beats
// its pink, blue and yellow
const DANCE_TILE = ['#7cb8ff', '#ff5c8a', '#ffd66b', '#5cf2c8'];
export const BEAT_COL = ['#ff5c8a', '#7cb8ff', '#ffd66b'];
export const BEAT_NAMES = ['pink', 'blue', 'yellow'];
const DARK = '#140818';
const GAP = 0.04; // between cushions, in tiles
const PILE_Z = 0.17; // how high the top cushion of a pile sits
export const PILE_TOP = PILE_Z;

// a colour mixed toward the dance floor's dark (`k` of the colour)
function dim(hex, k) {
  const n = parseInt(hex.slice(1), 16);
  const d = parseInt(DARK.slice(1), 16);
  const mix = (sh) => Math.round(((n >> sh) & 255) * k + ((d >> sh) & 255) * (1 - k));
  return `rgb(${mix(16)},${mix(8)},${mix(0)})`;
}

// A cushion (the prototype's cushionSvg, seen from above) on cell (x, y) at
// height z, `k` of full size: ring with its lip, white piping, a soft face
// with stitching round it and a tuft. `col`: a CUSH name or { c1, c2, ring }.
// Paths relative to (ox, oy).
export function cushionParts(B, x, y, z, k, col, id, ox, oy) {
  const c = typeof col === 'string' ? CUSH[col] : col;
  const S = (1 - 2 * GAP) * k;
  const cx = x + 0.5;
  const cy = y + 0.5;
  const rr = (d) => Math.max(0.01, (S / 2 - d) * 0.42);
  const rect = (d, dv = 0) => roundRect(B, cx - S / 2 + d, cy - S / 2 + d + dv, cx + S / 2 - d, cy + S / 2 - d + dv, rr(d), z, ox, oy);
  const mid = project(B, cx, cy + 0.03 * S, z);
  const px = mid.s; // points per tile there
  const stroke = Math.max(1.2, B.T * 0.032);
  return (
    <>
      <Defs>
        <RadialGradient id={id} cx="50%" cy="34%" rx="70%" ry="70%">
          <Stop offset="0" stopColor={c.c1} />
          <Stop offset="1" stopColor={c.c2} />
        </RadialGradient>
      </Defs>
      <Path d={rect(0, 0.06 * S)} fill={c.ring} />
      <Path d={rect(0)} fill={c.ring} />
      <Path d={rect(0.035 * S)} fill="#ffffff" />
      <Path d={rect(0.075 * S)} fill={`url(#${id})`} />
      <Path d={rect(0.17 * S)} fill="none" stroke="rgba(255,255,255,0.75)" strokeWidth={stroke} strokeDasharray={`${stroke * 2.5} ${stroke * 2}`} />
      <Ellipse cx={mid.x - ox} cy={mid.y - oy} rx={0.065 * S * px} ry={0.055 * S * px * 0.8} fill={c.ring} opacity={0.45} />
    </>
  );
}

// An arrow printed on a cushion: the chevron, white over a shadow of `ink`.
function arrowParts(B, x, y, z, dir, size, ink, ox, oy) {
  const pts = chevron(x + 0.5, y + 0.5, dir, size);
  const d = polyPath(B, pts, z, ox, oy);
  const shadow = polyPath(
    B,
    pts.map(([u, v]) => [u, v + 0.03]),
    z,
    ox,
    oy,
  );
  const w = Math.max(2.4, B.T * 0.11 * size);
  return (
    <>
      <Path d={shadow} stroke={ink} strokeWidth={w} fill="none" strokeLinecap="round" strokeLinejoin="round" />
      <Path d={d} stroke="#ffffff" strokeWidth={w} fill="none" strokeLinecap="round" strokeLinejoin="round" />
    </>
  );
}

// A dance-floor tile: its colour with a light rim and a glow in the middle; a
// beat tile is dark with a coloured rim until it's lit.
function danceParts(B, x, y, col, beat, lit, id, ox, oy) {
  const g = Math.min(0.03, 1.5 / B.T);
  const shape = roundRect(B, x + g, y + g, x + 1 - g, y + 1 - g, 0.06, 0, ox, oy);
  const inner = roundRect(B, x + 0.07, y + 0.07, x + 0.93, y + 0.93, 0.05, 0, ox, oy);
  const off = beat && !lit;
  return (
    <>
      <Defs>
        <RadialGradient id={id} cx="50%" cy="45%" rx="62%" ry="62%">
          <Stop offset="0" stopColor="#ffffff" stopOpacity={off ? 0.12 : 0.75} />
          <Stop offset="1" stopColor="#ffffff" stopOpacity={0} />
        </RadialGradient>
      </Defs>
      {lit ? <Path d={roundRect(B, x - 0.05, y - 0.05, x + 1.05, y + 1.05, 0.12, 0, ox, oy)} fill={col} opacity={0.45} /> : null}
      <Path d={shape} fill={off ? dim(col, 0.32) : col} />
      <Path d={inner} fill="none" stroke={off ? col : lit ? 'rgba(255,255,255,0.9)' : 'rgba(255,255,255,0.28)'} strokeWidth={Math.max(2, B.T * 0.045)} />
      <Path d={shape} fill={`url(#${id})`} />
    </>
  );
}

// The dance floor's tile colour for cell (x, y).
export function danceColor(x, y, goal, beat, beats) {
  if (goal) return '#ffffff';
  if (beat >= 0) return BEAT_COL[beat];
  if (beats) return DANCE_TILE[3];
  return DANCE_TILE[y % 2 === 0 ? (x % 2 ? 1 : 0) : x % 2 ? 2 : 3];
}

// One cell: the bottom cushion (or dance tile) and, on a pile, the top one,
// each in its own view so it can puff away and back (`a0`, `a1`: 1 there,
// 0 gone). `look`: { dance, color, goal, pile, arrow, beat, beats, lit }.
export const Tile = memo(function Tile({ B, i, look, a0, a1 }) {
  const x = i % B.w;
  const y = Math.floor(i / B.w);
  const box = useMemo(() => cellBox(B, x, y, look.pile ? PILE_Z + 0.04 : 0.02, 0.1), [B, x, y, look.pile]);
  const ox = box.left;
  const oy = box.top;
  const id = `hop${i}`;
  const ink = look.dance ? DARK : CUSH[look.color].ring;
  const bottom = useMemo(() => {
    if (look.dance) {
      const col = danceColor(x, y, look.goal, look.beat, look.beats);
      return (
        <>
          {danceParts(B, x, y, col, look.beat >= 0, look.lit, `${id}d`, ox, oy)}
          {look.arrow >= 0 && !look.pile ? arrowParts(B, x, y, 0, look.arrow, 0.62, ink, ox, oy) : null}
        </>
      );
    }
    return (
      <>
        {cushionParts(B, x, y, 0, 1, look.goal ? 'peach' : look.color, `${id}a`, ox, oy)}
        {look.arrow >= 0 && !look.pile ? arrowParts(B, x, y, 0, look.arrow, 0.5, ink, ox, oy) : null}
      </>
    );
  }, [B, x, y, look, id, ink, ox, oy]);
  const top = useMemo(() => {
    if (!look.pile) return null;
    if (look.dance) {
      // a ring of light over the tile
      const ring = roundRect(B, x + 0.19, y + 0.19, x + 0.81, y + 0.81, 0.12, 0.02, ox, oy);
      const w = Math.max(2, B.T * 0.05);
      return (
        <>
          <Path d={ring} fill="none" stroke="rgba(255,255,255,0.35)" strokeWidth={w * 3} />
          <Path d={ring} fill="none" stroke="#ffffff" strokeWidth={w} />
          {look.arrow >= 0 ? arrowParts(B, x, y, 0.02, look.arrow, 0.5, ink, ox, oy) : null}
        </>
      );
    }
    return (
      <>
        {cushionParts(B, x, y, PILE_Z, 0.94, look.color, `${id}b`, ox, oy)}
        {look.arrow >= 0 ? arrowParts(B, x, y, PILE_Z, look.arrow, 0.47, ink, ox, oy) : null}
      </>
    );
  }, [B, x, y, look, id, ink, ox, oy]);
  const pos = { position: 'absolute', left: box.left, top: box.top, width: box.width, height: box.height };
  return (
    <>
      <Animated.View pointerEvents="none" style={[pos, puff(a0)]}>
        <Svg width={box.width} height={box.height}>
          {bottom}
        </Svg>
      </Animated.View>
      {top ? (
        <Animated.View pointerEvents="none" style={[pos, puff(a1)]}>
          <Svg width={box.width} height={box.height}>
            {top}
          </Svg>
        </Animated.View>
      ) : null}
    </>
  );
});

// a cushion's presence (1 there, 0 gone) as its look: going, it squashes
// flat and shrinks away; coming back it does that backwards
function puff(a) {
  return {
    opacity: a.interpolate({ inputRange: [0, 0.35, 1], outputRange: [0, 1, 1] }),
    transform: [{ scaleX: a.interpolate({ inputRange: [0, 0.7, 1], outputRange: [0.25, 1.16, 1] }) }, { scaleY: a.interpolate({ inputRange: [0, 0.7, 1], outputRange: [0.25, 0.62, 1] }) }],
  };
}

// The board under the cushions: on the floor, a dashed dent where each
// cushion is (it shows once the cushion has puffed away); in the Dance Room,
// the floor's dark with a pink glow round it.
export const Under = memo(function Under({ B, cells, dance, dent, width, height }) {
  const parts = useMemo(() => {
    if (dance) {
      const edge = roundRect(B, -0.08, -0.08, B.w + 0.08, B.h + 0.08, 0.3, 0, 0, 0);
      return (
        <>
          <Path d={edge} fill="none" stroke="rgba(255,92,198,0.3)" strokeWidth={B.T * 0.2} />
          <Path d={edge} fill={DARK} stroke="#2a1430" strokeWidth={3} />
        </>
      );
    }
    const w = Math.max(1.6, B.T * 0.04);
    return cells.map((i) => {
      const x = i % B.w;
      const y = Math.floor(i / B.w);
      const S = (1 - 2 * GAP) * 0.84;
      return <Path key={i} d={roundRect(B, x + 0.5 - S / 2, y + 0.5 - S / 2, x + 0.5 + S / 2, y + 0.5 + S / 2, S * 0.22, 0, 0, 0)} fill="none" stroke={dent || 'rgba(91,58,41,0.4)'} strokeWidth={w} strokeDasharray={`${w * 2.4} ${w * 1.8}`} />;
    });
  }, [B, cells, dance, dent]);
  return (
    <Svg pointerEvents="none" width={width} height={height} style={StyleSheet.absoluteFill}>
      {parts}
    </Svg>
  );
});

// The hint: a gold outline round the cell to hop to, pulsing.
export const HintGlow = memo(function HintGlow({ B, i, z = 0 }) {
  const pulse = usePingPong(500, { from: 0.45, to: 1, eased: false });
  const x = i % B.w;
  const y = Math.floor(i / B.w);
  const box = cellBox(B, x, y, z, 0.16);
  const d = roundRect(B, x - 0.04, y - 0.04, x + 1.04, y + 1.04, 0.26, z, box.left, box.top);
  const w = Math.max(2.5, B.T * 0.055);
  return (
    <Animated.View pointerEvents="none" style={{ position: 'absolute', left: box.left, top: box.top, opacity: pulse }}>
      <Svg width={box.width} height={box.height}>
        <Path d={d} fill="rgba(255,226,92,0.25)" stroke="rgba(255,226,92,0.55)" strokeWidth={w * 3} />
        <Path d={d} fill="none" stroke="#ffd23a" strokeWidth={w} />
      </Svg>
    </Animated.View>
  );
});

// A bubble floating over cell i, bobbing (`a`: 1 there, 0 popped).
export const Bubble = memo(function Bubble({ B, i, a }) {
  const q = project(B, (i % B.w) + 0.5, Math.floor(i / B.w) + 0.56);
  const size = q.s * 0.62;
  const bob = usePingPong(2200, { from: 0, to: -size * 0.1, delay: (i * 370) % 2000 });
  return (
    <Animated.View
      pointerEvents="none"
      style={{
        position: 'absolute',
        left: q.x - size / 2,
        top: q.y - size - q.s * 0.1,
        width: size,
        height: size,
        opacity: a,
        transform: [{ translateY: bob }, { scale: a.interpolate({ inputRange: [0, 1], outputRange: [1.5, 1] }) }],
      }}
    >
      <Svg width={size} height={size}>
        <Defs>
          <RadialGradient id={`bub${i}`} cx="34%" cy="30%" rx="75%" ry="75%">
            <Stop offset="0" stopColor="#ffffff" />
            <Stop offset="0.12" stopColor="#ffffff" />
            <Stop offset="0.15" stopColor="#ffffff" stopOpacity={0.6} />
            <Stop offset="0.42" stopColor="#96d6ff" stopOpacity={0.55} />
            <Stop offset="0.72" stopColor="#c8aaff" stopOpacity={0.6} />
            <Stop offset="1" stopColor="#ffaae1" stopOpacity={0.75} />
          </RadialGradient>
        </Defs>
        <Circle cx={size / 2} cy={size / 2} r={size / 2 - 1} fill={`url(#bub${i})`} stroke="rgba(60,120,190,0.55)" strokeWidth={1.5} />
        <Circle cx={size / 2} cy={size / 2} r={size / 2 - 2.6} fill="none" stroke="#ffffff" strokeWidth={2.2} />
      </Svg>
    </Animated.View>
  );
});

const STAR_D = 'M12 2.2 L14.9 8.6 L21.8 9.3 L16.6 14 L18.1 20.9 L12 17.4 L5.9 20.9 L7.4 14 L2.2 9.3 L9.1 8.6 Z';

// the ★ badge (Squish Stack's), grey while it's shut
export const Star = memo(function Star({ size, shut = false }) {
  return (
    <Svg width={size} height={size} viewBox="0 0 24 24">
      <Path d={STAR_D} fill={shut ? '#9a8fa8' : '#b86200'} transform="translate(0 1.4)" strokeLinejoin="round" />
      <Path d={STAR_D} fill={shut ? '#e3dcea' : '#ffd23a'} stroke="#ffffff" strokeWidth={1.8} strokeLinejoin="round" />
    </Svg>
  );
});

// The ★ standing over the goal cell, bobbing. While friends are still out
// it's grey with how many are left; `pop` (0 → 1) is it opening, `gone`
// (0 → 1) it flying off at the end.
export const GoalStar = memo(function GoalStar({ B, i, left, pop, gone, z }) {
  const q = project(B, (i % B.w) + 0.5, Math.floor(i / B.w) + 0.56);
  const size = q.s * 0.52;
  const bob = usePingPong(1800, { from: 0, to: -size * 0.08 });
  return (
    <Animated.View
      pointerEvents="none"
      style={{
        position: 'absolute',
        left: q.x - size / 2,
        top: q.y - size - q.s * 0.16,
        width: size,
        height: size,
        zIndex: z,
        opacity: gone.interpolate({ inputRange: [0, 1], outputRange: [1, 0] }),
        transform: [
          { translateY: bob },
          { translateY: gone.interpolate({ inputRange: [0, 1], outputRange: [0, -size * 0.7] }) },
          { scale: Animated.add(gone.interpolate({ inputRange: [0, 1], outputRange: [1, 1.4] }), pop.interpolate({ inputRange: [0, 0.45, 1], outputRange: [0, 0.5, 0] })) },
        ],
      }}
    >
      <Star size={size} shut={left > 0} />
      {left > 0 ? (
        <View style={[styles.lockCount, { minWidth: size * 0.46, height: size * 0.46, borderRadius: size }]}>
          <Text style={[styles.lockText, { fontSize: Math.max(9, Math.round(size * 0.34)) }]}>{left}</Text>
        </View>
      ) : null}
    </Animated.View>
  );
});

// --- the squishies ---------------------------------------------------------------------

// Where a squishy `w` wide (its body, at T) and `h` tall stands at (x, y),
// looking `k` times its size: the translate and scale for a piece (RN scales
// about the middle, so the feet stay put by moving it up as it grows).
export const poseAt = (w, h, x, y, k) => ({ x: x - w / 2, y: y - (h / 2) * (1 + k), k });

// A squishy standing on the board: placed and sized by `a.x`, `a.y`, `a.k`
// (poseAt), hopping up by `a.lift`, nudged by `a.bx` / `a.by`, squashed by
// `a.sx` / `a.sy` and rocked by `a.rot` (from its feet), breathing all the
// while. Friends peek about now and then.
export const Piece = memo(function Piece({ c, w, h, a, z, shade, friend = false, delay = 0 }) {
  const breathe = usePingPong(friend ? 2200 : 2600, { delay });
  const peek = useKeyLoop(6000, { at: PEEK_AT, values: PEEK_DEG, delay, on: friend });
  const feet = (s) => [{ translateY: h / 2 }, ...s, { translateY: -h / 2 }];
  return (
    <Animated.View pointerEvents="none" style={{ position: 'absolute', left: 0, top: 0, width: w, height: h, zIndex: z, opacity: a.o, transform: [{ translateX: a.x }, { translateY: a.y }, { scale: a.k }] }}>
      <Animated.View style={[styles.shadow, { backgroundColor: shade, opacity: a.shadow, transform: [{ scale: a.arc.interpolate({ inputRange: [-1, 0], outputRange: [0.6, 1] }) }] }]} />
      <Animated.View style={{ transform: [{ translateY: a.lift }, { translateX: a.bx }, { translateY: a.by }] }}>
        <Animated.View style={{ transform: feet([{ scaleX: a.sx }, { scaleY: a.sy }, { rotate: a.rot.interpolate({ inputRange: [-1, 1], outputRange: ['-10deg', '10deg'] }) }]) }}>
          <Animated.View
            style={{
              transform: feet([
                { scaleX: breathe.interpolate({ inputRange: [0, 1], outputRange: [1, 1.03] }) },
                { scaleY: breathe.interpolate({ inputRange: [0, 1], outputRange: [1, 0.97] }) },
                { rotate: peek.interpolate({ inputRange: [-9, 9], outputRange: ['-9deg', '9deg'] }) },
              ]),
            }}
          >
            <Squishy c={c} w={w} />
          </Animated.View>
        </Animated.View>
      </Animated.View>
    </Animated.View>
  );
});
const PEEK_AT = [0, 0.84, 0.88, 0.92, 0.96, 1];
const PEEK_DEG = [0, 0, -9, 8, -3, 0];

// A squishy's animated values. Every move is ONE native timing of a phase
// read through keyframes (a looped or chained Animated.sequence is stepped
// from JS and hitches when JS is busy: src/components/idleLoop.js):
//   x, y, k   where it stands and how big it looks (poseAt)
//   hp        a hop, 0 → 1: up `liftH` points and down, stretching tall
//   land      the landing, 0 → 1: squashed flat, then back (rests at 1)
//   bump      a bump or a nudge, 0 → 1 → toward (dx, dy) and back
//   rot       a rock, -1 … 1 (±10°)
//   o         its opacity; shadow its shadow's (0 while it flies off)
export function freshPose() {
  const hp = new Animated.Value(0);
  const liftH = new Animated.Value(0);
  const land = new Animated.Value(1);
  const bump = new Animated.Value(0);
  const dx = new Animated.Value(0);
  const dy = new Animated.Value(0);
  const arc = hp.interpolate({ inputRange: [0, 0.25, 0.5, 0.75, 1], outputRange: [0, -0.75, -1, -0.75, 0] });
  const out = bump.interpolate({ inputRange: [0, 0.4, 1], outputRange: [0, 1, 0] });
  return {
    x: new Animated.Value(0),
    y: new Animated.Value(0),
    k: new Animated.Value(1),
    o: new Animated.Value(1),
    shadow: new Animated.Value(1),
    rot: new Animated.Value(0),
    hp,
    liftH,
    land,
    bump,
    dx,
    dy,
    arc,
    lift: Animated.multiply(arc, liftH),
    bx: Animated.multiply(out, dx),
    by: Animated.multiply(out, dy),
    sx: Animated.multiply(hp.interpolate({ inputRange: [0, 0.4, 1], outputRange: [1, 0.9, 1] }), land.interpolate({ inputRange: [0, 0.55, 1], outputRange: [1.14, 0.96, 1] })),
    sy: Animated.multiply(hp.interpolate({ inputRange: [0, 0.4, 1], outputRange: [1, 1.12, 1] }), land.interpolate({ inputRange: [0, 0.55, 1], outputRange: [0.86, 1.05, 1] })),
  };
}

// A cushion seen from straight above (the prototype's cushionSvg): the goal
// card's ★ cushion and the game picker's picture.
export const FlatCushion = memo(function FlatCushion({ size, col = 'peach', id = 'flat' }) {
  const c = CUSH[col];
  const k = size / 2;
  const r = k - 1;
  const rr = (x) => (r - x) * 0.42;
  const rect = (d, dy = 0) => {
    const x0 = k - r + d;
    const y0 = k - r + d + dy;
    const s = 2 * (r - d);
    const q = rr(d);
    return `M${x0 + q} ${y0} H${x0 + s - q} Q${x0 + s} ${y0} ${x0 + s} ${y0 + q} V${y0 + s - q} Q${x0 + s} ${y0 + s} ${x0 + s - q} ${y0 + s} H${x0 + q} Q${x0} ${y0 + s} ${x0} ${y0 + s - q} V${y0 + q} Q${x0} ${y0} ${x0 + q} ${y0} Z`;
  };
  return (
    <Svg width={size} height={size * 1.06}>
      <Defs>
        <RadialGradient id={id} cx="50%" cy="34%" rx="70%" ry="70%">
          <Stop offset="0" stopColor={c.c1} />
          <Stop offset="1" stopColor={c.c2} />
        </RadialGradient>
      </Defs>
      <Path d={rect(0, size * 0.06)} fill={c.ring} />
      <Path d={rect(0)} fill={c.ring} />
      <Path d={rect(size * 0.035)} fill="#ffffff" />
      <Path d={rect(size * 0.075)} fill={`url(#${id})`} />
      <Path d={rect(size * 0.17)} fill="none" stroke="rgba(255,255,255,0.75)" strokeWidth={Math.max(1, size / 30)} strokeDasharray={`${size / 12} ${size / 15}`} />
      <Ellipse cx={k} cy={k + size * 0.03} rx={size * 0.065} ry={size * 0.055} fill={c.ring} opacity={0.45} />
    </Svg>
  );
});

// a numbered friend's chip (pick-up order), kept over everything so the
// order can always be read
export const OrderChip = memo(function OrderChip({ n, x, y, size }) {
  return (
    <View pointerEvents="none" style={[styles.ordChip, { left: x - size / 2, top: y - size / 2, minWidth: size, height: size, borderRadius: size }]}>
      <Text style={[styles.ordText, { fontSize: Math.max(9, size * 0.5) }]}>{n}</Text>
    </View>
  );
});

const styles = StyleSheet.create({
  shadow: { position: 'absolute', left: '14%', right: '14%', bottom: '-5%', height: '15%', borderRadius: 999 },
  lockCount: { position: 'absolute', right: '-16%', top: '-10%', paddingHorizontal: 3, backgroundColor: '#ff5cc6', borderWidth: 2, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  lockText: { fontFamily: F.display, color: '#ffffff', includeFontPadding: false },
  ordChip: { position: 'absolute', zIndex: 95, paddingHorizontal: 3, backgroundColor: '#ff5cc6', borderWidth: 2, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  ordText: { fontFamily: F.display, color: '#ffffff', includeFontPadding: false },
});
