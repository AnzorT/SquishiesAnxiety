import React, { memo } from 'react';
import Svg, { Circle, Ellipse, G, Path, Rect } from 'react-native-svg';

// Squish Sort's clutter (the user, 2026-10-24: "random foods everywhere in
// order to confuse the player"): food for the fridge (only the fridge since
// 2026-11-17, the user: "make it only with food"), 16 kinds, drawn in the app's candy style on a 64 × 64 box
// standing on its bottom edge. Some look a lot like the food squishies (a
// lemon, a watermelon slice, a cupcake), only without faces.

const W = '#ffffff';
const hi = (x, y, w, h, r = 2, o = 0.6) => <Rect x={x} y={y} width={w} height={h} rx={r} fill={W} opacity={o} />;

const FOODS = [
  // milk carton
  () => (
    <G>
      <Path d="M17 22 L32 9 L47 22 Z" fill="#dfeeff" stroke="#8ab6e0" strokeWidth={2} strokeLinejoin="round" />
      <Rect x={28.5} y={5} width={7} height={6} rx={1.5} fill="#bcd8f2" />
      <Rect x={17} y={22} width={30} height={38} rx={3} fill={W} stroke="#8ab6e0" strokeWidth={2} />
      <Rect x={17} y={33} width={30} height={12} fill="#4a90e2" />
      <Circle cx={25} cy={53} r={3} fill="#3a3a4a" />
      <Ellipse cx={39} cy={27} rx={3.5} ry={2.2} fill="#3a3a4a" />
      {hi(20, 24, 3, 32)}
    </G>
  ),
  // two eggs
  () => (
    <G>
      <Ellipse cx={24} cy={45} rx={11} ry={14.5} fill="#fff8ec" stroke="#e2cba8" strokeWidth={2} />
      <Ellipse cx={42} cy={47} rx={10} ry={12.5} fill="#ffe9cc" stroke="#e2cba8" strokeWidth={2} />
      <Ellipse cx={20} cy={39} rx={3} ry={5} fill={W} opacity={0.8} />
      <Ellipse cx={39} cy={42} rx={2.5} ry={4} fill={W} opacity={0.7} />
    </G>
  ),
  // cheese wedge
  () => (
    <G>
      <Path d="M8 58 L58 58 L58 26 Z" fill="#ffd23a" stroke="#d99a00" strokeWidth={2} strokeLinejoin="round" />
      <Path d="M8 58 L58 26 L60 30 L12 60 Z" fill="#ffe680" />
      <Circle cx={44} cy={48} r={4} fill="#eeb100" />
      <Circle cx={52} cy={39} r={2.6} fill="#eeb100" />
      <Circle cx={33} cy={53} r={2.4} fill="#eeb100" />
    </G>
  ),
  // apple
  () => (
    <G>
      <Path d="M32 22 C26 15 12 17 11 33 C10 48 21 61 32 57 C43 61 54 48 53 33 C52 17 38 15 32 22 Z" fill="#ff4d5e" stroke="#c4223a" strokeWidth={2} />
      <Path d="M32 22 L34 11" stroke="#7a4a1e" strokeWidth={3} strokeLinecap="round" />
      <Path d="M35 15 C40 9 47 11 47 11 C45 17 39 18 35 15 Z" fill="#52c46a" />
      <Ellipse cx={21} cy={32} rx={3.5} ry={6} fill={W} opacity={0.6} />
    </G>
  ),
  // carrot
  () => (
    <G>
      <Path d="M22 22 L42 22 L33 60 Z" fill="#ff8a2a" stroke="#d45d00" strokeWidth={2} strokeLinejoin="round" />
      <Path d="M27 30 L33 31 M28 39 L34 40 M30 48 L34 49" stroke="#d45d00" strokeWidth={2} strokeLinecap="round" />
      <Path d="M32 22 C26 12 22 10 22 10 M32 22 C32 10 33 6 33 6 M32 22 C38 12 43 10 43 10" stroke="#3db45a" strokeWidth={4} strokeLinecap="round" fill="none" />
    </G>
  ),
  // tomato
  () => (
    <G>
      <Ellipse cx={32} cy={42} rx={21} ry={18} fill="#ff4a3d" stroke="#c42418" strokeWidth={2} />
      <Path d="M32 26 L27 20 L31 25 L24 25 L31 27 L28 32 L32 28 L36 32 L33 27 L40 25 L33 25 L37 20 Z" fill="#3db45a" stroke="#2a8a42" strokeWidth={1.5} strokeLinejoin="round" />
      <Ellipse cx={22} cy={38} rx={4} ry={6} fill={W} opacity={0.55} />
    </G>
  ),
  // broccoli
  () => (
    <G>
      <Path d="M28 40 L26 60 L38 60 L36 40 Z" fill="#9be07a" stroke="#4f9a3c" strokeWidth={2} strokeLinejoin="round" />
      <Circle cx={20} cy={32} r={10} fill="#3db45a" stroke="#2a8a42" strokeWidth={2} />
      <Circle cx={44} cy={32} r={10} fill="#3db45a" stroke="#2a8a42" strokeWidth={2} />
      <Circle cx={32} cy={22} r={12} fill="#47c264" stroke="#2a8a42" strokeWidth={2} />
      <Circle cx={28} cy={18} r={3} fill="#8be09f" />
      <Circle cx={17} cy={29} r={2.4} fill="#8be09f" />
    </G>
  ),
  // soda bottle
  () => (
    <G>
      <Path d="M27 4 L37 4 L37 14 C37 20 44 22 44 30 L44 58 C44 60 42 61 40 61 L24 61 C22 61 20 60 20 58 L20 30 C20 22 27 20 27 14 Z" fill="#7be0b0" stroke="#2a9a6a" strokeWidth={2} strokeLinejoin="round" />
      <Rect x={26} y={2} width={12} height={5} rx={1.5} fill="#ff5c8a" />
      <Rect x={20} y={36} width={24} height={13} fill="#ff5c8a" />
      <Path d="M26 42 L38 42" stroke={W} strokeWidth={2.4} strokeLinecap="round" />
      {hi(23, 24, 3, 32)}
    </G>
  ),
  // jam jar
  () => (
    <G>
      <Rect x={14} y={24} width={36} height={36} rx={8} fill="#ff4d7a" stroke="#b8164a" strokeWidth={2} />
      <Rect x={18} y={34} width={28} height={14} rx={3} fill="#fff6e0" />
      <Path d="M24 41 C24 37 30 37 30 41 C30 37 36 37 36 41 C36 45 30 47 30 47 C30 47 24 45 24 41 Z" fill="#ff4d7a" />
      <Path d="M12 18 L52 18 L50 26 L14 26 Z" fill="#fff" stroke="#b8164a" strokeWidth={2} strokeLinejoin="round" />
      <Path d="M16 18 L20 26 M24 18 L28 26 M32 18 L36 26 M40 18 L44 26" stroke="#ff4d7a" strokeWidth={2.4} />
      {hi(17, 28, 3, 26, 2, 0.5)}
    </G>
  ),
  // yogurt cup
  () => (
    <G>
      <Path d="M14 22 L50 22 L45 60 L19 60 Z" fill="#fff6fb" stroke="#d78bb8" strokeWidth={2} strokeLinejoin="round" />
      <Rect x={11} y={17} width={42} height={7} rx={3} fill="#cfd8e8" stroke="#9aa6bc" strokeWidth={1.5} />
      <Path d="M27 38 C27 32 37 32 37 38 C37 45 32 49 32 49 C32 49 27 45 27 38 Z" fill="#ff4d6a" />
      <Path d="M29 33 L32 30 L35 33" stroke="#3db45a" strokeWidth={2} fill="none" strokeLinecap="round" />
      <Rect x={17} y={50} width={30} height={5} rx={2} fill="#ffc2dc" />
    </G>
  ),
  // watermelon slice
  () => (
    <G>
      <Path d="M6 26 C6 50 58 50 58 26 Z" fill="#3db45a" />
      <Path d="M9 26 C9 45 55 45 55 26 Z" fill="#c9f5b0" />
      <Path d="M12 26 C12 42 52 42 52 26 Z" fill="#ff5a6e" />
      <Ellipse cx={24} cy={31} rx={1.5} ry={2.4} fill="#3a2a2a" />
      <Ellipse cx={32} cy={35} rx={1.5} ry={2.4} fill="#3a2a2a" />
      <Ellipse cx={40} cy={31} rx={1.5} ry={2.4} fill="#3a2a2a" />
      <Rect x={10} y={44} width={44} height={14} rx={7} fill="none" />
    </G>
  ),
  // lemon
  () => (
    <G>
      <Path d="M8 42 C12 26 52 26 56 42 C52 58 12 58 8 42 Z" fill="#ffe14a" stroke="#d9a800" strokeWidth={2} />
      <Path d="M6 42 L10 40 M58 42 L54 40" stroke="#d9a800" strokeWidth={3} strokeLinecap="round" />
      <Ellipse cx={22} cy={37} rx={6} ry={2.5} fill={W} opacity={0.6} />
    </G>
  ),
  // grapes
  () => (
    <G>
      {[
        [24, 26], [34, 26], [44, 26], [29, 35], [39, 35], [24, 44], [34, 44], [29, 53],
      ].map(([x, y], i) => (
        <Circle key={i} cx={x} cy={y} r={6.5} fill="#9a5ce0" stroke="#6a2fb0" strokeWidth={1.6} />
      ))}
      <Path d="M34 19 L36 10" stroke="#7a4a1e" strokeWidth={3} strokeLinecap="round" />
      <Path d="M36 13 C42 8 48 11 48 11 C46 16 40 17 36 13 Z" fill="#52c46a" />
      <Circle cx={22} cy={24} r={1.8} fill={W} opacity={0.7} />
    </G>
  ),
  // ketchup bottle
  () => (
    <G>
      <Path d="M22 22 C22 18 26 16 32 16 C38 16 42 18 42 22 L44 56 C44 59 41 61 38 61 L26 61 C23 61 20 59 20 56 Z" fill="#ff3d3d" stroke="#b81818" strokeWidth={2} strokeLinejoin="round" />
      <Rect x={26} y={6} width={12} height={11} rx={3} fill={W} stroke="#c9c9d6" strokeWidth={1.5} />
      <Rect x={22} y={34} width={20} height={12} rx={3} fill="#fff6e0" />
      <Path d="M27 40 L37 40" stroke="#3db45a" strokeWidth={3} strokeLinecap="round" />
      {hi(24, 23, 3, 28)}
    </G>
  ),
  // butter on its dish
  () => (
    <G>
      <Ellipse cx={32} cy={56} rx={27} ry={5} fill="#cfe3f2" stroke="#8ab6e0" strokeWidth={2} />
      <Path d="M14 52 L18 36 L50 36 L50 52 Z" fill="#fff1a0" stroke="#d9b400" strokeWidth={2} strokeLinejoin="round" />
      <Path d="M18 36 L24 30 L54 30 L50 36 Z" fill="#fff8c8" stroke="#d9b400" strokeWidth={2} strokeLinejoin="round" />
      <Path d="M50 36 L54 30 L54 46 L50 52 Z" fill="#ffe56a" stroke="#d9b400" strokeWidth={2} strokeLinejoin="round" />
    </G>
  ),
  // cupcake
  () => (
    <G>
      <Path d="M16 36 L48 36 L43 60 L21 60 Z" fill="#7fd8f0" stroke="#2f9ac0" strokeWidth={2} strokeLinejoin="round" />
      <Path d="M24 38 L26 58 M32 38 L32 58 M40 38 L38 58" stroke="#2f9ac0" strokeWidth={1.6} />
      <Path d="M12 37 C10 27 20 22 24 24 C26 14 40 14 41 23 C48 21 55 28 51 37 Z" fill="#fff0f8" stroke="#e48ac0" strokeWidth={2} strokeLinejoin="round" />
      <Circle cx={32} cy={13} r={4.5} fill="#ff3d5a" />
      <Rect x={20} y={28} width={3} height={1.6} rx={0.8} fill="#ffd23a" />
      <Rect x={36} y={25} width={3} height={1.6} rx={0.8} fill="#5fb8ff" />
      <Rect x={42} y={31} width={3} height={1.6} rx={0.8} fill="#3ddc97" />
    </G>
  ),
];

export const KINDS = 16;

// One piece of clutter, `kind` 0-15, `size` px square.
export const Prop = memo(function Prop({ kind, size }) {
  const draw = FOODS[kind % FOODS.length];
  return (
    <Svg width={size} height={size} viewBox="0 0 64 64">
      {draw()}
    </Svg>
  );
});
