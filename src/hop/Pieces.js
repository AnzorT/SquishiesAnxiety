import React, { memo, useMemo } from 'react';
import { Animated, Platform, StyleSheet, Text, View } from 'react-native';
import Svg, { Circle, Defs, Ellipse, Path, RadialGradient, Stop } from 'react-native-svg';
import { PHASE, SWING, usePingPong, useKeyLoop } from '../components/idleLoop';
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

// The ★ standing over the goal cell, bobbing. While cushions are still to
// clear it's grey with how many are left; `pop` (0 → 1) is it opening, `gone`
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
// Squish Hop's squishies (`a.juicy`, freshPose) also lean (`a.rz` sideways,
// `a.rx` toward or away from the camera, from the feet), turn their heads
// (`a.yaw`, about the middle) and face the way they hop (`a.face`, mirrored
// going left). `mood` 'sad' (stuck): a sweat drop runs down, and it sways
// slowly from side to side until the mood goes.
// A squishy with faces (`c.faces`: Squishdoku's board, src/squishdoku/bodies.js)
// shows its happy or sad one by `a.happy` / `a.sad` (0 … 1) and flashes red by
// `a.red` (a phase 0 → 1); see FacedSquishy.
// (Every interpolation is made once here: a re-render, the hopper's z on
// every hop, must not build new animated nodes. PERFORMANCE.md.)
export const Piece = memo(function Piece({ c, w, h, a, z, shade, friend = false, delay = 0, mood = null }) {
  const breathe = usePingPong(friend ? 2200 : 2600, { delay });
  const peek = useKeyLoop(6000, { at: PEEK_AT, values: PEEK_DEG, delay, on: friend });
  const sad = mood === 'sad';
  const sway = useKeyLoop(2400, { at: PHASE, values: SWING, delay: SAD_SWAY_AT, on: sad });
  const J = !!a.juicy;
  const t = useMemo(() => {
    const feet = (s) => [{ translateY: h / 2 }, ...s, { translateY: -h / 2 }];
    const deg = (v, r = 10) => v.interpolate({ inputRange: [-1, 1], outputRange: [`${-r}deg`, `${r}deg`] });
    return {
      shadow: [{ scale: a.shadowK }],
      lift: [{ translateY: a.lift }, { translateX: a.bx }, { translateY: a.by }],
      // (the web draws a 3D turn flat without a perspective; Android has a default one)
      squash: J ? [...WEB_DEPTH(w), ...feet([{ rotateX: deg(a.rx, 1) }, { rotate: deg(Animated.add(a.rz, Animated.multiply(sway, 0.45))) }, { scaleX: a.sx }, { scaleY: a.sy }])] : feet([{ scaleX: a.sx }, { scaleY: a.sy }, { rotate: deg(a.rot) }]),
      yaw: J ? [{ perspective: w * 5 }, { rotateY: deg(a.yaw, 1) }] : null,
      face: J ? [{ scaleX: a.face }] : null,
      breathe: feet([
        { scaleX: breathe.interpolate({ inputRange: [0, 1], outputRange: [1, 1.03] }) },
        { scaleY: breathe.interpolate({ inputRange: [0, 1], outputRange: [1, 0.97] }) },
        { rotate: peek.interpolate({ inputRange: [-9, 9], outputRange: ['-9deg', '9deg'] }) },
      ]),
    };
  }, [a, J, w, h, breathe, peek, sway]);
  const pic = c.faces && a.happy ? <FacedSquishy c={c} w={w} a={a} /> : <Squishy c={c} w={w} />;
  const body = J ? <Animated.View style={{ transform: t.face }}>{pic}</Animated.View> : pic;
  const breathing = <Animated.View style={{ transform: t.breathe }}>{body}</Animated.View>;
  return (
    <Animated.View pointerEvents="none" style={{ position: 'absolute', left: 0, top: 0, width: w, height: h, zIndex: z, opacity: a.o, transform: [{ translateX: a.x }, { translateY: a.y }, { scale: a.k }] }}>
      <Animated.View style={[styles.shadow, { backgroundColor: shade, opacity: a.shadow, transform: t.shadow }]} />
      <Animated.View style={{ transform: t.lift }}>
        <Animated.View style={{ transform: t.squash }}>
          {J ? <Animated.View style={{ transform: t.yaw }}>{breathing}</Animated.View> : breathing}
          {sad ? <SweatDrop w={w} h={h} /> : null}
        </Animated.View>
      </Animated.View>
    </Animated.View>
  );
});
// A squishy in three faces (src/squishdoku/bodies.js: one render each, cropped
// alike, so they lie right over each other): the happy and sad ones fade in
// over the idle one, which goes once a face is all the way in (or a sad ear
// would show twice, down and up), and a red copy of its shape flashes over it
// all (`a.red` 0 → 1: two flashes, ~0.6 strong).
const FacedSquishy = memo(function FacedSquishy({ c, w, a }) {
  const h = w * c.ar;
  const st = useMemo(
    () => ({
      box: { width: w, height: h },
      idle: { opacity: Animated.add(a.happy, a.sad).interpolate({ inputRange: [0, 0.97, 1], outputRange: [1, 1, 0], extrapolate: 'clamp' }) },
      happy: { opacity: a.happy },
      sad: { opacity: a.sad },
      red: { opacity: a.red.interpolate({ inputRange: [0, 0.12, 0.32, 0.46, 1], outputRange: [0, 0.62, 0.12, 0.62, 0], extrapolate: 'clamp' }) },
    }),
    [a, w, h],
  );
  return (
    <View style={st.box}>
      <Animated.Image source={c.faces.idle} fadeDuration={0} style={[styles.fill, st.idle]} />
      <Animated.Image source={c.faces.happy} fadeDuration={0} style={[styles.fill, st.happy]} />
      <Animated.Image source={c.faces.sad} fadeDuration={0} style={[styles.fill, st.sad]} />
      <Animated.Image source={c.faces.idle} fadeDuration={0} style={[styles.fill, styles.redTint, st.red]} />
    </View>
  );
});
const PEEK_AT = [0, 0.84, 0.88, 0.92, 0.96, 1];
const PEEK_DEG = [0, 0, -9, 8, -3, 0];
// stuck: the slow sad sway starts after the droop and the look (Game.js LOOK_MS)
export const SAD_SWAY_AT = 850;
const WEB_DEPTH = (w) => (Platform.OS === 'web' ? [{ perspective: w * 6 }] : []);
const UNIT = [0, 1];

// A sweat drop running down the side of a stuck squishy's head, again and
// again (one native loop; idleLoop.js).
const SweatDrop = memo(function SweatDrop({ w, h }) {
  const p = useKeyLoop(1400, { at: UNIT, values: UNIT, delay: 380 });
  const s = Math.max(10, w * 0.2);
  const style = useMemo(
    () => ({
      position: 'absolute',
      left: w * 0.82,
      top: h * 0.08,
      width: s,
      height: s * 1.25,
      opacity: p.interpolate({ inputRange: [0, 0.08, 0.72, 1], outputRange: [0, 1, 1, 0] }),
      transform: [{ translateY: p.interpolate({ inputRange: [0, 0.16, 1], outputRange: [0, 0, h * 0.3] }) }, { scale: p.interpolate({ inputRange: [0, 0.12, 1], outputRange: [0.2, 1, 0.8] }) }],
    }),
    [p, w, h, s],
  );
  return (
    <Animated.View pointerEvents="none" style={style}>
      <Svg width={s} height={s * 1.25} viewBox="0 0 40 50">
        <Path d="M20 3 C20 3 36 22 36 32 A16 16 0 0 1 4 32 C4 22 20 3 20 3 Z" fill="#a8e4ff" stroke="#2f8fd8" strokeWidth={3} strokeLinejoin="round" />
        <Ellipse cx={14} cy={31} rx={4} ry={6.5} fill="#ffffff" opacity={0.9} />
      </Svg>
    </Animated.View>
  );
});

// --- how Squish Hop's squishies move (freshPose({ juicy: true })) --------------------------
// Each is a phase 0 → 1, run as ONE linear native timing and read through
// keyframes; every keyframe list starts and ends at rest, so a phase can be
// left at 0 or 1.
// Of a hop: the crouch before take-off (it doesn't travel yet; Game.js holds
// the travel this long), and of a boing off a bubble, the squash on it.
export const CROUCH = 0.24;
export const SPRING = 0.2;
// A parabola 0 → -1 → 0 from `t0` to 1 (`peak` high), as keyframes.
function arcFrom(t0, peak = 1) {
  const u = [0, 0.1, 0.25, 0.5, 0.75, 0.9, 1];
  return { at: [...(t0 > 0 ? [0] : []), ...u.map((x) => t0 + x * (1 - t0))], out: [...(t0 > 0 ? [0] : []), ...u.map((x) => -4 * x * (1 - x) * peak)] };
}
const HOP = {
  arc: arcFrom(CROUCH),
  // squashed down in the crouch, stretched tall as it takes off and while it falls
  s: { at: [0, 0.2, 0.32, 0.48, 0.66, 0.86, 1], x: [1, 1.2, 0.84, 0.92, 1, 0.93, 1], y: [1, 0.76, 1.24, 1.1, 1, 1.09, 1] },
  // leans back in the crouch, then into the hop (1 = 10°)
  lean: { at: [0, 0.2, 0.36, 0.62, 0.9, 1], v: [0, -0.45, 1.1, 0.5, 0.1, 0] },
};
const BOING = {
  arc: arcFrom(SPRING, 1.15),
  // squashed flat on the bubble, sprung up tall, a jelly wobble in the air
  s: { at: [0, 0.07, SPRING, SPRING + 0.08, 0.45, 0.6, 0.75, 0.9, 1], x: [1, 1.38, 1.3, 0.78, 0.88, 1.09, 0.95, 1.04, 1], y: [1, 0.62, 0.68, 1.38, 1.16, 0.93, 1.06, 0.97, 1] },
  lean: { at: [0, SPRING, SPRING + 0.12, 0.6, 1], v: [0, -0.2, 1.2, 0.4, 0] },
};
// the landing: squashed flat, a springy wobble back up, and the top carried
// on into the hop and back
const LAND = {
  s: { at: [0, 0.08, 0.2, 0.38, 0.56, 0.74, 0.88, 1], x: [1, 1.3, 1.26, 0.9, 1.06, 0.97, 1.01, 1], y: [1, 0.7, 0.74, 1.12, 0.95, 1.03, 0.99, 1] },
  lean: { at: [0, 0.15, 0.42, 0.66, 1], v: [0, 0.6, -0.28, 0.1, 0] },
};
// a win: three happy jumps on the ★ (tilting right, then left), the last one
// higher with a spin round
const JOY = {
  arc: {
    at: [0, 0.05, 0.0975, 0.145, 0.1925, 0.24, 0.34, 0.395, 0.45, 0.505, 0.56, 0.64, 0.7175, 0.795, 0.8725, 0.95, 1],
    out: [0, 0, -0.6, -0.8, -0.6, 0, 0, -0.7, -0.95, -0.7, 0, 0, -1.05, -1.4, -1.05, 0, 0],
  },
  s: {
    at: [0, 0.03, 0.07, 0.145, 0.22, 0.26, 0.31, 0.37, 0.45, 0.53, 0.57, 0.615, 0.67, 0.8, 0.92, 0.96, 0.985, 1],
    x: [1, 1.16, 0.86, 1, 0.94, 1.22, 1.16, 0.86, 1, 0.94, 1.22, 1.26, 0.82, 1, 0.94, 1.24, 0.97, 1],
    y: [1, 0.8, 1.18, 1, 1.08, 0.78, 0.8, 1.2, 1, 1.08, 0.78, 0.72, 1.26, 1, 1.08, 0.76, 1.03, 1],
  },
  lean: { at: [0, 0.07, 0.145, 0.24, 0.37, 0.45, 0.56, 1], v: [0, 0.3, 0.8, 0, -0.3, -0.8, 0, 0] },
  spin: { at: [0, 0.66, 0.92, 1], v: [0, 0, 360, 360] },
};
// a friend picked up: a happy little hop with a wiggle, then off to the goal
// card in a spin (Game.js holds its flight until HAP_GO)
export const HAP_GO = 0.32;
const HAP = {
  arc: { at: [0, 0.03, 0.08, 0.15, 0.22, 0.28, HAP_GO, 0.47, 0.64, 0.82, 1], out: [0, 0, -1, -1.35, -1, 0, 0, -1.4, -1.8, -1.4, 0] },
  s: { at: [0, 0.03, 0.07, 0.15, 0.28, HAP_GO, 0.38, 0.6, 1], x: [1, 1.14, 0.86, 1, 1.16, 1.12, 0.88, 1, 1], y: [1, 0.84, 1.2, 1, 0.84, 0.86, 1.16, 1, 1] },
  lean: { at: [0, 0.06, 0.11, 0.16, 0.21, 0.27, 1], v: [0, 0.8, -0.8, 0.7, -0.5, 0, 0] },
  spin: { at: [0, 0.4, 0.85, 1], v: [0, 0, 360, 360] },
};
// a bump: squished against the way it can't go (by ex, ey; Game.js sets
// them), and `no`, a shake of the head (degrees)
const BUMP_SQUISH = { at: [0, 0.3, 0.42, 0.7, 1], v: [0, 0.7, 1, 0.15, 0] };
const NO = { at: [0, 0.22, 0.32, 0.46, 0.6, 0.74, 0.86, 1], v: [0, 0, 36, -32, 22, -11, 4, 0] };
// stuck: a look to the left, then to the right (degrees)
const LOOK = { at: [0, 0.25, 0.35, 0.5, 0.62, 0.78, 0.9, 1], v: [0, 0, -32, -32, 32, 32, 0, 0] };
// a tap on the squishy itself: a wiggle
const WIG = { at: [0, 0.25, 0.6, 1], v: [0, -0.6, 0.6, 0] };
// drooped (stuck): sunk down and wide, its top hanging toward the camera
const DROOP = { x: 1.08, y: 0.86, tilt: -14 };
// how far a hop up or down the board leans it away or toward the camera
export const LEAN_X = 22;

const kf = (v, at, out) => v.interpolate({ inputRange: at, outputRange: out });
const sum = (...xs) => xs.reduce((p, q) => Animated.add(p, q));
const prod = (...xs) => xs.reduce((p, q) => Animated.multiply(p, q));

// A squishy's animated values. Every move is ONE native timing of a phase
// read through keyframes (a looped or chained Animated.sequence is stepped
// from JS and hitches when JS is busy: src/components/idleLoop.js):
//   x, y, k   where it stands and how big it looks (poseAt)
//   hp        a hop, 0 → 1: up `liftH` points and down, stretching tall
//   land      the landing, 0 → 1: squashed flat, then back (rests at 1)
//   bump      a bump or a nudge, 0 → 1 → toward (dx, dy) and back
//   rot       a rock, -1 … 1 (±10°)
//   o         its opacity; shadow its shadow's (0 while it flies off)
// With `juicy` (Squish Hop) the hop and landing are the bigger HOP and LAND
// above, and there's more (each a phase 0 → 1 unless said):
//   bp        a boing off a bubble, in place of hp
//   lx, lzDeg the way the hop goes: -1 / 0 / 1 sideways, and the lean
//             toward (−) or away from (+) the camera, in degrees
//   face      1 as drawn, -1 mirrored (it hops left)
//   ex, ey    a bump's squish across and up (set per bump)
//   no        a shake of the head; look  stuck's look left and right
//   droop     0 → 1, stuck's droop (rests at 0)
//   joy       the win's jumps; hap  a friend's pick-up; wig  a wiggle
// Squishdoku's room board (RoomBoard.js) uses the plain one.
export function freshPose({ juicy = false } = {}) {
  const V = (v) => new Animated.Value(v);
  const hp = V(0);
  const liftH = V(0);
  const land = V(1);
  const bump = V(0);
  const dx = V(0);
  const dy = V(0);
  const rot = V(0);
  const out = bump.interpolate({ inputRange: [0, 0.4, 1], outputRange: [0, 1, 0] });
  const base = { x: V(0), y: V(0), k: V(1), o: V(1), shadow: V(1), rot, hp, liftH, land, bump, dx, dy, bx: Animated.multiply(out, dx), by: Animated.multiply(out, dy) };
  if (!juicy) {
    const arc = hp.interpolate({ inputRange: [0, 0.25, 0.5, 0.75, 1], outputRange: [0, -0.75, -1, -0.75, 0] });
    return {
      ...base,
      arc,
      shadowK: arc.interpolate({ inputRange: [-1, 0], outputRange: [0.6, 1] }),
      lift: Animated.multiply(arc, liftH),
      sx: Animated.multiply(hp.interpolate({ inputRange: [0, 0.4, 1], outputRange: [1, 0.9, 1] }), land.interpolate({ inputRange: [0, 0.55, 1], outputRange: [1.14, 0.96, 1] })),
      sy: Animated.multiply(hp.interpolate({ inputRange: [0, 0.4, 1], outputRange: [1, 1.12, 1] }), land.interpolate({ inputRange: [0, 0.55, 1], outputRange: [0.86, 1.05, 1] })),
    };
  }
  const [bp, joy, hap, no, look, wig, droop] = [0, 0, 0, 0, 0, 0, 0].map(V);
  const [lx, lzDeg, ex, ey, face] = [0, 0, 0, 0, 1].map(V);
  const arc = sum(kf(hp, HOP.arc.at, HOP.arc.out), kf(bp, BOING.arc.at, BOING.arc.out), kf(joy, JOY.arc.at, JOY.arc.out), kf(hap, HAP.arc.at, HAP.arc.out));
  const lean = sum(kf(hp, HOP.lean.at, HOP.lean.v), kf(bp, BOING.lean.at, BOING.lean.v), kf(land, LAND.lean.at, LAND.lean.v));
  const squish = kf(bump, BUMP_SQUISH.at, BUMP_SQUISH.v);
  const axis = (c, e) =>
    prod(
      kf(hp, HOP.s.at, HOP.s[c]),
      kf(bp, BOING.s.at, BOING.s[c]),
      kf(land, LAND.s.at, LAND.s[c]),
      kf(joy, JOY.s.at, JOY.s[c]),
      kf(hap, HAP.s.at, HAP.s[c]),
      Animated.add(1, Animated.multiply(squish, e)),
      kf(droop, UNIT, [1, DROOP[c]]),
    );
  return {
    ...base,
    juicy: true,
    facing: 1,
    bp,
    joy,
    hap,
    no,
    look,
    wig,
    droop,
    lx,
    lzDeg,
    ex,
    ey,
    face,
    arc,
    shadowK: arc.interpolate({ inputRange: [-1.8, 0], outputRange: [0.45, 1], extrapolate: 'clamp' }),
    lift: Animated.multiply(arc, liftH),
    // two squashes at once (a landing still wobbling as the next hop crouches) give way softly
    sx: kf(axis('x', ex), [0, 0.7, 1.34, 3], [0.64, 0.7, 1.34, 1.46]),
    sy: kf(axis('y', ey), [0, 0.66, 1.36, 3], [0.6, 0.66, 1.36, 1.5]),
    rz: sum(rot, kf(wig, WIG.at, WIG.v), Animated.multiply(lean, lx), kf(joy, JOY.lean.at, JOY.lean.v), kf(hap, HAP.lean.at, HAP.lean.v)),
    rx: sum(Animated.multiply(lean, lzDeg), kf(droop, UNIT, [0, DROOP.tilt])),
    yaw: sum(kf(no, NO.at, NO.v), kf(look, LOOK.at, LOOK.v), kf(joy, JOY.spin.at, JOY.spin.v), kf(hap, HAP.spin.at, HAP.spin.v)),
  };
}

// Back at rest, every move stopped (not where it stands: x, y, k, o, shadow).
export function restPose(a) {
  const stop = (v, to) => {
    v.stopAnimation();
    v.setValue(to);
  };
  [a.hp, a.bump, a.rot].forEach((v) => stop(v, 0));
  stop(a.land, 1);
  if (!a.juicy) return;
  [a.bp, a.joy, a.hap, a.no, a.look, a.wig, a.droop, a.lx, a.lzDeg, a.ex, a.ey].forEach((v) => stop(v, 0));
  stop(a.face, 1);
  a.facing = 1;
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
  fill: { position: 'absolute', left: 0, top: 0, width: '100%', height: '100%' },
  redTint: { tintColor: '#ff2e55' },
  shadow: { position: 'absolute', left: '14%', right: '14%', bottom: '-5%', height: '15%', borderRadius: 999 },
  lockCount: { position: 'absolute', right: '-16%', top: '-10%', paddingHorizontal: 3, backgroundColor: '#ff8a3d', borderWidth: 2, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  lockText: { fontFamily: F.display, color: '#ffffff', includeFontPadding: false },
  ordChip: { position: 'absolute', zIndex: 95, paddingHorizontal: 3, backgroundColor: '#ff8a3d', borderWidth: 2, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  ordText: { fontFamily: F.display, color: '#ffffff', includeFontPadding: false },
});
