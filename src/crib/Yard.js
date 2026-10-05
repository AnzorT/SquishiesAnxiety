import React, { memo } from 'react';
import { View } from 'react-native';
import Animated, { useAnimatedStyle } from 'react-native-reanimated';
import Svg, { Circle, Defs, Ellipse, Path, RadialGradient, Stop } from 'react-native-svg';
import { SIZE } from './data';

// The yard's games in motion (the design's yardPos and its swing / seesaw /
// trampoline / ball code in "Squad Crib v5"): the four starter games the
// design draws in CSS, and how a creature moves on each game. Everything
// runs on the UI thread from one clock (ms, a Reanimated shared value the
// scene ticks while the yard is on screen) and the swing's and seesaw's
// amplitudes (0-1, eased in when someone gets on).

const TAU = Math.PI * 2;
const INK = '#5b3a29';

// Where a creature on a game is right now, relative to its spot: { dx, dy }
// (scene units), the body's rotation (deg), its hop (ty) and squish (sq).
export function yardPose(P, c, swA, ssA, i) {
  'worklet';
  let x = P.x;
  let y = P.y;
  let rot = 0;
  let ty = 0;
  let sq = 0;
  const dy0 = P.dy || 0;
  if (P.g === 'swing') {
    const th = 0.42 * swA * Math.sin((TAU * c) / 1900);
    x = P.x + 112 * Math.sin(th);
    y = dy0 + 204 + 112 * Math.cos(th) + 6;
    rot = th * 57;
  } else if (P.g === 'tramp') {
    const u = (c % 950) / 950;
    ty = -64 * Math.sin(Math.PI * u);
    sq = Math.pow(1 - Math.sin(Math.PI * u), 8);
  } else if (P.g === 'seesaw') {
    const ph = 0.2 * ssA * Math.sin((TAU * c) / 2200);
    y = dy0 + 322 + P.side * 68 * Math.sin(ph);
    rot = ph * 57;
    const e = Math.max(0, (P.side * Math.sin(ph)) / 0.2);
    sq = Math.pow(e, 6) * 0.6;
  } else if (P.g === 'ball') {
    const u = (c % 1800) / 1800;
    const d = (P.side ? Math.abs(u - 0.5) : Math.min(u, 1 - u)) * 1800;
    const b = Math.exp(-Math.pow(d / 130, 2));
    ty = -18 * b;
    sq = -b * 0.4;
  } else if (P.g === 'slide') {
    const u = ((c + i * 900) % 3600) / 3600;
    const cx = P.cx;
    if (u < 0.35) {
      const q = u / 0.35;
      x = cx - 46;
      y = dy0 + 360 - 98 * q;
      rot = -6;
      ty = -3 * Math.abs(Math.sin(q * 18));
    } else if (u < 0.45) {
      x = cx - 46 + (16 * (u - 0.35)) / 0.1;
      y = dy0 + 262;
    } else if (u < 0.65) {
      const e = Math.pow((u - 0.45) / 0.2, 2);
      x = cx - 30 + 92 * e;
      y = dy0 + 262 + 98 * e;
      rot = 24;
    } else {
      const q = (u - 0.65) / 0.35;
      x = cx + 62 - 108 * q;
      y = dy0 + 360;
      ty = -4 * Math.abs(Math.sin(q * 20));
    }
  } else if (P.g === 'sand') {
    ty = 2 * Math.sin(c / 180 + P.side * 2);
    rot = 7 * Math.sin(c / 360 + P.side * 2);
  } else if (P.g === 'pit') {
    ty = 5 * Math.sin(c / 420 + P.side * 2) - 2;
    rot = 6 * Math.sin(c / 560 + P.side);
  } else if (P.g === 'pool') {
    ty = 3 * Math.sin(c / 600 + P.side * 2);
    rot = 5 * Math.sin(c / 800 + P.side);
  } else if (P.g === 'merry') {
    const a = (TAU * c) / 2600 + P.side * Math.PI;
    x = P.cx + 50 * Math.cos(a);
    y = dy0 + 348 + 9 * Math.sin(a);
    rot = -6 * Math.sin(a);
  } else if (P.g === 'kite') {
    rot = -8 + 4 * Math.sin(c / 900);
    ty = -2 * Math.abs(Math.sin(c / 450));
  } else if (P.g === 'bubble') {
    rot = 7 * Math.sin(c / 700);
    ty = -1.5 * Math.abs(Math.sin(c / 350));
  } else if (P.g === 'hop') {
    const u = (c % 4200) / 4200;
    const p = u < 0.5 ? u * 2 : 2 - u * 2;
    x = P.cx - 64 + 128 * p;
    const hq = (c % 520) / 520;
    ty = -14 * Math.sin(Math.PI * hq);
    sq = Math.pow(1 - Math.sin(Math.PI * hq), 8) * 0.5;
  }
  return { dx: x - P.x, dy: y - P.y, rot, ty, sq };
}

// The transform for a creature's body on a game: moved, turned and squished
// about its feet (the design's 50% 92% origin). `box` is its size on screen.
export function useYardMotion(spot, i, yard, scale, box) {
  return useAnimatedStyle(() => {
    if (!spot || !yard) return { transform: [] };
    const v = yardPose(spot, yard.clock.value, yard.swA.value, yard.ssA.value, i);
    const foot = box * 0.42;
    return {
      transform: [
        { translateX: v.dx * scale },
        { translateY: (v.dy + v.ty) * scale + foot },
        { rotate: `${v.rot}deg` },
        { scaleX: 1 + 0.2 * v.sq },
        { scaleY: 1 - 0.26 * v.sq },
        { translateY: -foot },
      ],
    };
  }, [spot, i, yard, scale, box]);
}

// ---- the starter games (the design's CSS, drawn with views) ------------------

// a block with the design's 2.5px brown ring around it (box-shadow 0 0 0 2.5px)
function Ringed({ x, y, w, h, r = 0, bg, ring = 2.5, scale, style }) {
  return <View style={[{ position: 'absolute', left: (x - ring) * scale, top: (y - ring) * scale, width: (w + ring * 2) * scale, height: (h + ring * 2) * scale, borderRadius: (r + ring) * scale, borderWidth: ring * scale, borderColor: INK, backgroundColor: bg }, style]} />;
}

function Swing({ g, yard, scale }) {
  const L = 106;
  // the ropes turn about their tops, the seat follows their ends
  const rope = useAnimatedStyle(() => {
    const th = 0.42 * yard.swA.value * Math.sin((TAU * yard.clock.value) / 1900);
    return { transform: [{ translateY: (-L / 2) * scale }, { rotate: `${-th * 57}deg` }, { translateY: (L / 2) * scale }] };
  });
  const seat = useAnimatedStyle(() => {
    const th = 0.42 * yard.swA.value * Math.sin((TAU * yard.clock.value) / 1900);
    return { transform: [{ translateX: L * Math.sin(th) * scale }, { translateY: -L * (1 - Math.cos(th)) * scale }] };
  });
  const s = scale;
  return (
    <View pointerEvents="none" style={{ position: 'absolute', left: g.dx * s, top: g.dy * s, width: 852 * s, height: 393 * s }}>
      <Ringed x={42} y={196} w={10} h={136} r={5} bg="#c98a4b" scale={s} style={{ transform: [{ rotate: '9deg' }] }} />
      <Ringed x={168} y={196} w={10} h={136} r={5} bg="#c98a4b" scale={s} style={{ transform: [{ rotate: '-9deg' }] }} />
      <Ringed x={34} y={190} w={152} h={14} r={6} bg="#a8693a" scale={s} />
      <Animated.View style={[{ position: 'absolute', left: (110 - 30) * s, top: 204 * s, width: 3 * s, height: L * s, backgroundColor: INK }, rope]} />
      <Animated.View style={[{ position: 'absolute', left: (110 + 27) * s, top: 204 * s, width: 3 * s, height: L * s, backgroundColor: INK }, rope]} />
      <Animated.View style={[{ position: 'absolute', left: 0, top: 0, width: 852 * s, height: 393 * s }, seat]}>
        <Ringed x={110 - 36} y={204 + 104} w={72} h={11} r={5} bg="#f2665a" scale={s} />
      </Animated.View>
    </View>
  );
}

function Trampoline({ g, on, yard, scale }) {
  const mat = useAnimatedStyle(() => {
    const tu = (yard.clock.value % 950) / 950;
    const land = Math.pow(1 - Math.sin(Math.PI * tu), 8);
    return { transform: [{ scaleY: 1 - (on ? 0.35 : 0) * land }] };
  }, [on]);
  const s = scale;
  return (
    <View pointerEvents="none" style={{ position: 'absolute', left: g.dx * s, top: g.dy * s, width: 852 * s, height: 393 * s }}>
      <Ringed x={246} y={338} w={8} h={22} bg="#7fae6a" ring={2} scale={s} />
      <Ringed x={326} y={338} w={8} h={22} bg="#7fae6a" ring={2} scale={s} />
      <Animated.View style={[{ position: 'absolute', left: (230 - 2.5) * s, top: (312 - 2.5) * s, width: 125 * s, height: 40 * s }, mat]}>
        <Svg width={125 * s} height={40 * s} viewBox="-2.5 -2.5 125 40">
          <Defs>
            <RadialGradient id="mat" cx="50%" cy="50%" r="50%">
              <Stop offset="0.5" stopColor="#5a6f8f" />
              <Stop offset="1" stopColor="#47597a" />
            </RadialGradient>
          </Defs>
          {/* the lip below, the ring, the green frame, the mat */}
          <Ellipse cx={60} cy={20} rx={62.5} ry={17.5} fill={INK} />
          <Ellipse cx={60} cy={15} rx={62.5} ry={17.5} fill={INK} />
          <Ellipse cx={60} cy={15} rx={60} ry={15} fill="#7fae6a" />
          <Ellipse cx={60} cy={15} rx={55} ry={10} fill="url(#mat)" />
        </Svg>
      </Animated.View>
    </View>
  );
}

function Seesaw({ g, yard, scale }) {
  const plank = useAnimatedStyle(() => {
    const ph = 0.2 * yard.ssA.value * Math.sin((TAU * yard.clock.value) / 2200);
    return { transform: [{ rotate: `${ph * 57}deg` }] };
  });
  const s = scale;
  return (
    <View pointerEvents="none" style={{ position: 'absolute', left: g.dx * s, top: g.dy * s, width: 852 * s, height: 393 * s }}>
      <View style={{ position: 'absolute', left: 462 * s, top: 320 * s }}>
        <Svg width={36 * s} height={38 * s} viewBox="0 0 36 38">
          <Path d="M18 2 L34 36 H2 Z" fill="#f2665a" stroke={INK} strokeWidth={3} strokeLinejoin="round" />
        </Svg>
      </View>
      <Animated.View style={[{ position: 'absolute', left: (386 - 2.5) * s, top: (316 - 2.5) * s, width: 193 * s, height: 17 * s, borderRadius: 8.5 * s, borderWidth: 2.5 * s, borderColor: INK, backgroundColor: '#d99a5b' }, plank]} />
    </View>
  );
}

function BallField({ g, spots, occ, yard, scale }) {
  const A = spots[0];
  const B = spots[1];
  const a = occ[0];
  const b = occ[1];
  const ball = useAnimatedStyle(() => {
    if (!A || !B || (!a && !b)) return { opacity: 0 };
    const c = yard.clock.value;
    const u = (c % 1800) / 1800;
    const p = u < 0.5 ? u / 0.5 : 1 - (u - 0.5) / 0.5;
    const both = a && b;
    const bx = both ? A.x + (B.x - A.x) * p : a ? A.x : B.x;
    const by = both ? A.y - SIZE * 1.05 - 70 * 4 * p * (1 - p) : (a ? A.y : B.y) - SIZE - 50 * Math.abs(Math.sin((Math.PI * c) / 700));
    return { opacity: 1, transform: [{ translateX: (bx - 12) * scale }, { translateY: (by - 12) * scale }, { rotate: `${(c * 0.4) % 360}deg` }] };
  }, [A, B, a, b, scale]);
  const s = scale;
  return (
    <View pointerEvents="none" style={{ position: 'absolute', left: 0, top: 0, width: 852 * s, height: 393 * s }}>
      <View style={{ position: 'absolute', left: (610 + g.dx) * s, top: (346 + g.dy) * s, width: 240 * s, height: 34 * s, borderRadius: 120 * s, backgroundColor: '#f6dca4', borderWidth: 3 * s, borderColor: INK }} />
      <Animated.View style={[{ position: 'absolute', left: 0, top: 0, width: 24 * s, height: 24 * s }, ball]}>
        <Svg width={24 * s} height={24 * s} viewBox="0 0 26 26">
          <Circle cx={13} cy={13} r={11.5} fill="#ffd66b" stroke={INK} strokeWidth={2.5} />
          <Path d="M2 13h22M13 1v24" stroke="#f2665a" strokeWidth={3} />
        </Svg>
      </Animated.View>
    </View>
  );
}

// The starter games that are out on their play spots, in the design's order.
// `occ` is who's on each yard spot (spot index → creature id | null).
export const YardGames = memo(function YardGames({ games, spots, occ, yard, scale }) {
  if (!games || !yard) return null;
  const on = (g) => spots.some((p, k) => p.g === g && occ[k] != null);
  const ballIdx = spots.map((p, k) => (p.g === 'ball' ? k : -1)).filter((k) => k >= 0);
  return (
    <>
      {games.swing ? <Swing g={games.swing} yard={yard} scale={scale} /> : null}
      {games.tramp ? <Trampoline g={games.tramp} on={on('tramp')} yard={yard} scale={scale} /> : null}
      {games.seesaw ? <Seesaw g={games.seesaw} yard={yard} scale={scale} /> : null}
      {games.ball ? <BallField g={games.ball} spots={ballIdx.map((k) => spots[k])} occ={ballIdx.map((k) => occ[k] != null)} yard={yard} scale={scale} /> : null}
    </>
  );
});

