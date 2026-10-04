import React, { memo } from 'react';
import { View } from 'react-native';
import Animated, { useAnimatedStyle } from 'react-native-reanimated';
import Svg, { Circle, Defs, Ellipse, Line, LinearGradient, Path, RadialGradient, Rect, Stop } from 'react-native-svg';

// The dance room's floor and lights (the design's "dz" layer in "Squad Crib
// v5"): the floor's coloured tiles stepping round the colour wheel, and by
// the tiers of the Ceiling Light and Club Lights a disco ball, spots wheeling
// round the room, swinging beams, lasers and the light show's glow. All from
// one clock (ms, a Reanimated shared value); faster while someone dances.

const TAU = Math.PI * 2;
const FLOOR_TOP = 210;
const FLOOR_H = 172;
const CELL = 56;

// CSS's hue-rotate(), so the stepped colours are the design's exactly
function hueRotate(hex, deg) {
  const n = parseInt(hex.slice(1), 16);
  const r = (n >> 16) & 255;
  const g = (n >> 8) & 255;
  const b = n & 255;
  const a = (deg * Math.PI) / 180;
  const c = Math.cos(a);
  const s = Math.sin(a);
  const m = [
    [0.213 + c * 0.787 - s * 0.213, 0.715 - c * 0.715 - s * 0.715, 0.072 - c * 0.072 + s * 0.928],
    [0.213 - c * 0.213 + s * 0.143, 0.715 + c * 0.285 + s * 0.14, 0.072 - c * 0.072 - s * 0.283],
    [0.213 - c * 0.213 - s * 0.787, 0.715 - c * 0.715 + s * 0.715, 0.072 + c * 0.928 + s * 0.072],
  ];
  const ch = (row) => Math.max(0, Math.min(255, Math.round(row[0] * r + row[1] * g + row[2] * b)));
  return `rgb(${ch(m[0])},${ch(m[1])},${ch(m[2])})`;
}
// the floor's 112-px tile: top-left, top-right, bottom-right, bottom-left
const TILE = ['#7cb8ff', '#ff5c8a', '#ffd66b', '#5cf2c8'];
const PALETTES = [0, 90, 180, 270].map((d) => ({ tile: TILE.map((h) => hueRotate(h, d)), line: hueRotate('#140818', d) }));

const FloorTiles = memo(function FloorTiles({ w, pal }) {
  const cells = [];
  for (let y = 0; y < FLOOR_H; y += CELL) {
    for (let x = 0; x < w; x += CELL) {
      const right = (x / CELL) % 2 === 1;
      const bottom = (y / CELL) % 2 === 1;
      const k = !bottom ? (right ? 1 : 0) : right ? 2 : 3;
      cells.push(<Rect key={`${x},${y}`} x={x} y={y} width={CELL} height={CELL} fill={pal.tile[k]} />);
    }
  }
  const lines = [];
  for (let x = 0; x < w; x += CELL) lines.push(<Rect key={`v${x}`} x={x} y={0} width={3} height={FLOOR_H} fill={pal.line} />);
  for (let y = 0; y < FLOOR_H; y += CELL) lines.push(<Rect key={`h${y}`} x={0} y={y} width={w} height={3} fill={pal.line} />);
  return (
    <>
      {cells}
      {lines}
    </>
  );
});

function FloorStep({ k, floor, clock, active, scale }) {
  const style = useAnimatedStyle(() => {
    const step = Math.floor(clock.value / (active ? 450 : 1200)) % 4;
    return { opacity: step === k ? 1 : 0 };
  }, [k, active]);
  const w = floor.w;
  return (
    <Animated.View style={[{ position: 'absolute', left: 0, top: 0 }, style]}>
      <Svg width={w * scale} height={FLOOR_H * scale} viewBox={`0 0 ${w} ${FLOOR_H}`}>
        <FloorTiles w={w} pal={PALETTES[k]} />
      </Svg>
    </Animated.View>
  );
}

export function DanceFloor({ floor, clock, active, scale }) {
  const pulse = useAnimatedStyle(() => ({ opacity: 0.04 + 0.04 * Math.sin((TAU * clock.value) / 470) }));
  if (!floor) return null;
  const s = scale;
  const glow = 6;
  // moved in Edit mode (home.js keeps the offset)
  return (
    <View pointerEvents="none" style={{ position: 'absolute', left: 0, top: 0, transform: [{ translateX: (floor.dx || 0) * s }, { translateY: (floor.dy || 0) * s }] }}>
      {/* the pink glow around it (the design's box-shadow) */}
      <View pointerEvents="none" style={{ position: 'absolute', left: (floor.l - glow) * s, top: (FLOOR_TOP - glow) * s, width: (floor.w + glow * 2) * s, height: (FLOOR_H + glow * 2 + 4) * s, borderRadius: (24 + glow) * s, backgroundColor: 'rgba(255,92,198,0.35)' }} />
      <View pointerEvents="none" style={{ position: 'absolute', left: floor.l * s, top: (FLOOR_TOP + 4) * s, width: floor.w * s, height: FLOOR_H * s, borderRadius: 24 * s, backgroundColor: '#140818' }} />
      <View pointerEvents="none" style={{ position: 'absolute', left: floor.l * s, top: FLOOR_TOP * s, width: floor.w * s, height: FLOOR_H * s, borderRadius: 24 * s, borderWidth: 3 * s, borderColor: '#2a1430', overflow: 'hidden' }}>
        {[0, 1, 2, 3].map((k) => (
          <FloorStep key={k} k={k} floor={floor} clock={clock} active={active} scale={s} />
        ))}
        <Animated.View style={[{ position: 'absolute', left: 0, top: 0, right: 0, bottom: 0, backgroundColor: '#ffffff' }, pulse]} />
      </View>
    </View>
  );
}

// ---- the lights -------------------------------------------------------------------

// the spots' dots: [dx, dy, colour, solid radius, fade radius] around the
// wheel (the design's 1252×820 layer, turning about scene 426, 78)
const DOTS = [[75, 0, '#fff', 2, 4], [-104, 53, '#ffe9a8', 3, 6], [18, -116, '#ffc2e0', 4, 8], [167, 121, '#b8f5ff', 2, 4], [-335, -32, '#fff', 3, 6], [342, -123, '#ffe9a8', 4, 8], [-120, 256, '#ffc2e0', 2, 4], [-59, -63, '#b8f5ff', 3, 6], [181, 36, '#fff', 4, 8], [-238, 56, '#ffe9a8', 2, 4], [135, -166, '#ffc2e0', 3, 6], [121, 208, '#b8f5ff', 4, 8], [-398, -126, '#fff', 2, 4], [108, -14, '#ffe9a8', 3, 6], [-100, 82, '#ffc2e0', 4, 8], [-35, -135, '#b8f5ff', 2, 4], [240, 110, '#fff', 3, 6], [-376, 12, '#ffe9a8', 4, 8], [308, -178, '#ffc2e0', 2, 4], [-3, 54, '#b8f5ff', 3, 6], [-106, -69, '#fff', 4, 8], [227, 15, '#ffe9a8', 2, 4], [-239, 97, '#ffc2e0', 3, 6], [71, -198, '#b8f5ff', 4, 8], [221, 205, '#fff', 2, 4], [-78, -13, '#ffe9a8', 3, 6], [132, -37, '#ffc2e0', 4, 8], [-77, 112, '#b8f5ff', 2, 4], [-102, -146, '#fff', 3, 6], [311, 85, '#ffe9a8', 4, 8], [-396, 65, '#ffc2e0', 2, 4], [247, -230, '#b8f5ff', 3, 6], [26, 73, '#fff', 4, 8], [-161, -65, '#ffe9a8', 2, 4]];
const WHEEL = 900; // the dots layer's size: big enough to cover the room as it turns

function Spots({ clock, active, scale }) {
  const turn = useAnimatedStyle(() => ({ transform: [{ rotate: `${(clock.value * 0.036 * (active ? 1 : 0.45)) % 360}deg` }] }), [active]);
  const s = scale;
  const c = WHEEL / 2;
  return (
    <Animated.View pointerEvents="none" style={[{ position: 'absolute', left: (426 - c) * s, top: (78 - c) * s, width: WHEEL * s, height: WHEEL * s, opacity: 0.75 }, turn]}>
      <Svg width={WHEEL * s} height={WHEEL * s} viewBox={`0 0 ${WHEEL} ${WHEEL}`}>
        <Defs>
          {['#fff', '#ffe9a8', '#ffc2e0', '#b8f5ff'].map((col, i) => (
            <RadialGradient key={col} id={`dot${i}`} cx="50%" cy="50%" r="50%">
              <Stop offset="0.5" stopColor={col} stopOpacity={1} />
              <Stop offset="1" stopColor={col} stopOpacity={0} />
            </RadialGradient>
          ))}
        </Defs>
        {DOTS.map(([dx, dy, col, , r2], i) => (
          <Circle key={i} cx={c + dx} cy={c + 52 + dy} r={r2} fill={`url(#dot${['#fff', '#ffe9a8', '#ffc2e0', '#b8f5ff'].indexOf(col)})`} />
        ))}
      </Svg>
    </Animated.View>
  );
}

const BEAMS = [
  { pts: '300,0 312,0 600,320 480,320', c: '255,92,180', a: 0.8 },
  { pts: '294,0 306,0 375,320 225,320', c: '92,242,200', a: 0.75 },
  { pts: '288,0 300,0 120,320 0,320', c: '255,214,107', a: 0.8 },
];

function Beams({ clock, active, scale }) {
  // swinging about the top centre (300, 0) of their 600×320 box
  const swing = useAnimatedStyle(() => {
    const a = Math.sin((TAU * clock.value) / (active ? 1400 : 2600)) * 18;
    return { opacity: active ? 0.95 : 0.6, transform: [{ translateY: -160 * scale }, { rotate: `${a}deg` }, { translateY: 160 * scale }] };
  }, [active, scale]);
  const s = scale;
  return (
    <Animated.View pointerEvents="none" style={[{ position: 'absolute', left: 126 * s, top: 78 * s, width: 600 * s, height: 320 * s }, swing]}>
      <Svg width={600 * s} height={320 * s} viewBox="0 0 600 320">
        <Defs>
          {BEAMS.map((b, i) => (
            <LinearGradient key={i} id={`beam${i}`} x1="0" y1="0" x2="0" y2="1">
              <Stop offset="0" stopColor={`rgb(${b.c})`} stopOpacity={b.a} />
              <Stop offset="1" stopColor={`rgb(${b.c})`} stopOpacity={0} />
            </LinearGradient>
          ))}
        </Defs>
        {BEAMS.map((b, i) => (
          <Path key={i} d={`M${b.pts.split(' ').join(' L')} Z`} fill={`url(#beam${i})`} />
        ))}
      </Svg>
    </Animated.View>
  );
}

const LASERS = [
  [120, '#ff3fbf'], [250, '#3ff2c8'], [380, '#7cb8ff'], [472, '#ffd23f'], [602, '#c38bff'], [732, '#ff5c8a'],
  // the light show adds these
  [60, '#ffd23f'], [190, '#c38bff'], [320, '#ff5c8a'], [532, '#ff3fbf'], [662, '#3ff2c8'], [792, '#7cb8ff'],
];
const LASER_LEN = 440;

function Laser({ q, x, color, clock, scale }) {
  const turn = useAnimatedStyle(() => {
    const a = Math.sin((TAU * clock.value) / (1700 + q * 210) + q * 1.3) * (26 + (q % 4) * 6);
    return { transform: [{ translateY: (-LASER_LEN / 2) * scale }, { rotate: `${a}deg` }, { translateY: (LASER_LEN / 2) * scale }] };
  }, [q, scale]);
  const s = scale;
  return (
    <Animated.View pointerEvents="none" style={[{ position: 'absolute', left: (x - 2) * s, top: 24 * s, width: 6 * s, height: LASER_LEN * s }, turn]}>
      <Svg width={6 * s} height={LASER_LEN * s} viewBox={`0 0 6 ${LASER_LEN}`}>
        <Defs>
          <LinearGradient id={`lz${q}`} x1="0" y1="0" x2="0" y2="1">
            <Stop offset="0" stopColor={color} stopOpacity={1} />
            <Stop offset="1" stopColor={color} stopOpacity={0} />
          </LinearGradient>
          <LinearGradient id={`lzg${q}`} x1="0" y1="0" x2="0" y2="1">
            <Stop offset="0" stopColor={color} stopOpacity={0.45} />
            <Stop offset="1" stopColor={color} stopOpacity={0} />
          </LinearGradient>
        </Defs>
        <Rect x={0} y={0} width={6} height={LASER_LEN} rx={3} fill={`url(#lzg${q})`} />
        <Line x1={3} y1={0} x2={3} y2={LASER_LEN} stroke={`url(#lz${q})`} strokeWidth={2} />
      </Svg>
    </Animated.View>
  );
}

// the Ceiling Light's classic disco ball with its facets turning; `at` is
// where it was moved to ({ dx, dy })
function DiscoBall({ clock, active, scale, at }) {
  const facets = useAnimatedStyle(() => ({ transform: [{ translateX: -((clock.value * 0.05 * (active ? 1 : 0.45)) % 16) * scale }] }), [active, scale]);
  const s = scale;
  const cells = [];
  for (let y = 0; y < 64; y += 8) for (let x = 0; x < 80; x += 8) cells.push(<Rect key={`${x},${y}`} x={x} y={y} width={8} height={8} fill={['#ffffff', '#b9c2dc', '#8e98b8', '#e8ecf8'][((x / 8) % 2) + ((y / 8) % 2) * 2]} stroke="rgba(40,30,60,0.45)" strokeWidth={0.5} />);
  return (
    <View pointerEvents="none" style={{ position: 'absolute', left: 0, top: 0, transform: [{ translateX: ((at && at.dx) || 0) * s }, { translateY: ((at && at.dy) || 0) * s }] }}>
      <View pointerEvents="none" style={{ position: 'absolute', left: 425 * s, top: 0, width: 2 * s, height: 38 * s, backgroundColor: '#c9c9d6' }} />
      <View pointerEvents="none" style={{ position: 'absolute', left: 384 * s, top: 26 * s, width: 84 * s, height: 84 * s, borderRadius: 42 * s, backgroundColor: 'rgba(255,255,255,0.22)' }} />
      <View pointerEvents="none" style={{ position: 'absolute', left: 394 * s, top: 36 * s, width: 64 * s, height: 64 * s, borderRadius: 32 * s, borderWidth: 3 * s, borderColor: '#2a1430', overflow: 'hidden', backgroundColor: '#c9cfe0' }}>
        <Animated.View style={[{ position: 'absolute', left: 0, top: 0 }, facets]}>
          <Svg width={80 * s} height={64 * s} viewBox="0 0 80 64">
            {cells}
          </Svg>
        </Animated.View>
        <Svg style={{ position: 'absolute', left: 0, top: 0 }} width={58 * s} height={58 * s} viewBox="0 0 58 58">
          <Defs>
            <RadialGradient id="ballHi" cx="32%" cy="28%" r="60%">
              <Stop offset="0" stopColor="#ffffff" stopOpacity={0.95} />
              <Stop offset="0.1" stopColor="#ffffff" stopOpacity={0.6} />
              <Stop offset="0.5" stopColor="#ffffff" stopOpacity={0} />
              <Stop offset="1" stopColor="#1e1432" stopOpacity={0.35} />
            </RadialGradient>
          </Defs>
          <Circle cx={29} cy={29} r={29} fill="url(#ballHi)" />
        </Svg>
      </View>
      <View pointerEvents="none" style={{ position: 'absolute', left: 410 * s, top: 42 * s, width: 6 * s, height: 6 * s, backgroundColor: '#ffffff', transform: [{ rotate: '45deg' }] }} />
    </View>
  );
}

export const DanceLights = memo(function DanceLights({ classicBall, lights, clock, active, scale }) {
  const L = lights || {};
  return (
    <>
      {L.spots ? <Spots clock={clock} active={active} scale={scale} /> : null}
      {L.beams ? <Beams clock={clock} active={active} scale={scale} /> : null}
      {L.lasers ? LASERS.slice(0, L.show ? 12 : 6).map(([x, col], q) => <Laser key={q} q={q} x={x} color={col} clock={clock} scale={scale} />) : null}
      {L.show ? (
        <View pointerEvents="none" style={{ position: 'absolute', left: 0, top: 0, width: 852 * scale, height: 393 * scale }}>
          <Svg width={852 * scale} height={393 * scale} viewBox="0 0 852 393">
            <Defs>
              <RadialGradient id="show" cx="50%" cy="50%" r="50%">
                <Stop offset="0" stopColor="#ff5cc6" stopOpacity={0.2} />
                <Stop offset="0.7" stopColor="#ff5cc6" stopOpacity={0} />
              </RadialGradient>
            </Defs>
            <Ellipse cx={426} cy={118} rx={511} ry={157} fill="url(#show)" />
          </Svg>
        </View>
      ) : null}
      {classicBall ? <DiscoBall clock={clock} active={active} scale={scale} at={classicBall} /> : null}
    </>
  );
});

