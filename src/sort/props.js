import React, { memo } from 'react';
import Svg, { Circle, Ellipse, G, Path, Rect } from 'react-native-svg';

// Squish Sort's clutter (the user, 2026-10-24: "random foods everywhere in
// order to confuse the player"): food for the fridge, toys for the
// cupboard, 16 kinds each, drawn in the app's candy style on a 64 × 64 box
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

const TOYS = [
  // beach ball
  () => (
    <G>
      <Circle cx={32} cy={38} r={22} fill={W} stroke="#5a4a8a" strokeWidth={2} />
      <Path d="M32 16 C22 26 22 50 32 60 C27 48 27 28 32 16 Z" fill="#ff5c8a" />
      <Path d="M32 16 C42 26 42 50 32 60 C37 48 37 28 32 16 Z" fill="#5fb8ff" />
      <Path d="M10 38 C20 30 44 30 54 38 C44 34 20 34 10 38 Z" fill="#ffd23a" />
      <Circle cx={23} cy={27} r={3} fill={W} opacity={0.8} />
    </G>
  ),
  // ABC block
  () => (
    <G>
      <Rect x={12} y={22} width={38} height={38} rx={5} fill="#5fb8ff" stroke="#2f6fc0" strokeWidth={2} />
      <Path d="M12 22 L20 14 L58 14 L50 22 Z" fill="#9fd4ff" stroke="#2f6fc0" strokeWidth={2} strokeLinejoin="round" />
      <Path d="M50 22 L58 14 L58 52 L50 60 Z" fill="#3a8ae0" stroke="#2f6fc0" strokeWidth={2} strokeLinejoin="round" />
      <Path d="M24 52 L31 30 L38 52 M27 44 L35 44" stroke={W} strokeWidth={4} strokeLinecap="round" strokeLinejoin="round" fill="none" />
    </G>
  ),
  // rubber duck
  () => (
    <G>
      <Path d="M10 44 C10 34 22 32 30 36 C30 22 52 20 50 36 C56 36 58 46 52 52 C44 62 14 62 10 44 Z" fill="#ffd23a" stroke="#d99a00" strokeWidth={2} strokeLinejoin="round" />
      <Path d="M48 30 L58 31 L49 35 Z" fill="#ff8a2a" stroke="#d45d00" strokeWidth={1.5} strokeLinejoin="round" />
      <Circle cx={43} cy={29} r={2.4} fill="#3a2a2a" />
      <Path d="M20 46 C26 52 34 50 36 44" stroke="#e8b000" strokeWidth={2.4} fill="none" strokeLinecap="round" />
    </G>
  ),
  // ball of yarn
  () => (
    <G>
      <Circle cx={32} cy={39} r={20} fill="#ff8fd0" stroke="#c0268f" strokeWidth={2} />
      <Path d="M16 30 C26 36 38 36 48 28 M14 40 C26 46 40 46 52 38 M18 50 C28 54 38 54 46 50" stroke="#c0268f" strokeWidth={1.8} fill="none" />
      <Path d="M48 50 C56 54 58 60 52 61" stroke="#c0268f" strokeWidth={2} fill="none" strokeLinecap="round" />
    </G>
  ),
  // stack of books
  () => (
    <G>
      <Rect x={10} y={48} width={44} height={11} rx={2} fill="#ff5c8a" stroke="#b8164a" strokeWidth={2} />
      <Rect x={14} y={37} width={38} height={11} rx={2} fill="#5fb8ff" stroke="#2f6fc0" strokeWidth={2} />
      <Rect x={12} y={26} width={40} height={11} rx={2} fill="#3ddc97" stroke="#16a86a" strokeWidth={2} />
      <Path d="M14 53 L50 53 M18 42 L48 42 M16 31 L48 31" stroke={W} strokeWidth={2} opacity={0.8} />
    </G>
  ),
  // drum
  () => (
    <G>
      <Path d="M12 30 L12 52 C12 58 52 58 52 52 L52 30 Z" fill="#ff5c5c" stroke="#b81818" strokeWidth={2} />
      <Path d="M12 34 L22 52 L32 34 L42 52 L52 34" stroke="#ffd23a" strokeWidth={2.4} fill="none" strokeLinejoin="round" />
      <Ellipse cx={32} cy={30} rx={20} ry={6} fill="#fff6e0" stroke="#b81818" strokeWidth={2} />
      <Path d="M22 10 L30 26 M44 12 L36 26" stroke="#c98a4a" strokeWidth={3} strokeLinecap="round" />
      <Circle cx={22} cy={10} r={3} fill="#ffd23a" />
      <Circle cx={44} cy={12} r={3} fill="#ffd23a" />
    </G>
  ),
  // toy car
  () => (
    <G>
      <Path d="M6 48 L6 40 C6 37 9 36 12 36 L18 36 L24 26 L42 26 L50 36 L56 37 C59 38 59 41 59 44 L59 48 Z" fill="#5fb8ff" stroke="#2f6fc0" strokeWidth={2} strokeLinejoin="round" />
      <Path d="M22 36 L27 29 L33 29 L33 36 Z M36 36 L36 29 L41 29 L46 36 Z" fill="#dff3ff" />
      <Circle cx={18} cy={50} r={7} fill="#3a3a4a" stroke={W} strokeWidth={2} />
      <Circle cx={46} cy={50} r={7} fill="#3a3a4a" stroke={W} strokeWidth={2} />
      <Circle cx={18} cy={50} r={2.4} fill="#c9c9d6" />
      <Circle cx={46} cy={50} r={2.4} fill="#c9c9d6" />
    </G>
  ),
  // spinning top
  () => (
    <G>
      <Path d="M10 34 C10 26 54 26 54 34 L34 58 C33 60 31 60 30 58 Z" fill="#b48bff" stroke="#6a22d6" strokeWidth={2} strokeLinejoin="round" />
      <Path d="M10 34 C20 38 44 38 54 34" stroke="#ffd23a" strokeWidth={3} fill="none" />
      <Rect x={29} y={14} width={6} height={14} rx={3} fill="#ffd23a" stroke="#d99a00" strokeWidth={1.5} />
    </G>
  ),
  // rocket
  () => (
    <G>
      <Path d="M32 4 C42 14 44 30 40 48 L24 48 C20 30 22 14 32 4 Z" fill={W} stroke="#5a4a8a" strokeWidth={2} strokeLinejoin="round" />
      <Path d="M32 4 C36 8 38 12 39 16 L25 16 C26 12 28 8 32 4 Z" fill="#ff5c8a" />
      <Circle cx={32} cy={28} r={5} fill="#5fb8ff" stroke="#5a4a8a" strokeWidth={2} />
      <Path d="M24 38 L14 50 L24 48 Z M40 38 L50 50 L40 48 Z" fill="#ff5c8a" stroke="#5a4a8a" strokeWidth={1.6} strokeLinejoin="round" />
      <Path d="M27 48 L32 60 L37 48 Z" fill="#ffd23a" />
    </G>
  ),
  // crayons
  () => (
    <G>
      {[
        ['#ff5c5c', 14],
        ['#ffd23a', 24],
        ['#3ddc97', 34],
        ['#5fb8ff', 44],
      ].map(([c, x], i) => (
        <G key={i}>
          <Rect x={x} y={20 + (i % 2) * 4} width={8} height={38 - (i % 2) * 4} rx={1.5} fill={c} stroke="#5a4a8a" strokeWidth={1.4} />
          <Path d={`M${x} ${20 + (i % 2) * 4} L${x + 4} ${12 + (i % 2) * 4} L${x + 8} ${20 + (i % 2) * 4} Z`} fill={c} stroke="#5a4a8a" strokeWidth={1.4} strokeLinejoin="round" />
        </G>
      ))}
      <Rect x={10} y={40} width={46} height={20} rx={3} fill="#ffcf8f" stroke="#a05a10" strokeWidth={2} />
    </G>
  ),
  // teacup (a dolls' tea set)
  () => (
    <G>
      <Ellipse cx={30} cy={58} rx={22} ry={4} fill="#ffd6f0" stroke="#c0268f" strokeWidth={1.6} />
      <Path d="M12 30 L48 30 C48 46 40 56 30 56 C20 56 12 46 12 30 Z" fill={W} stroke="#c0268f" strokeWidth={2} strokeLinejoin="round" />
      <Path d="M48 34 C58 34 58 46 46 46" stroke="#c0268f" strokeWidth={3} fill="none" />
      <Circle cx={24} cy={42} r={3} fill="#ff8fd0" />
      <Circle cx={34} cy={40} r={3} fill="#ff8fd0" />
    </G>
  ),
  // star wand
  () => (
    <G>
      <Path d="M30 30 L22 60" stroke="#c98a4a" strokeWidth={4} strokeLinecap="round" />
      <Path d="M34 6 L38.5 16 L49.5 17 L41 24 L43.6 35 L34 29.2 L24.4 35 L27 24 L18.5 17 L29.5 16 Z" fill="#ffd23a" stroke="#d99a00" strokeWidth={2} strokeLinejoin="round" />
      <Circle cx={31} cy={17} r={2} fill={W} />
    </G>
  ),
  // xylophone
  () => (
    <G>
      {['#ff5c5c', '#ff9c3a', '#ffd23a', '#3ddc97', '#5fb8ff'].map((c, i) => (
        <Rect key={i} x={8 + i * 10} y={26 + i * 2} width={8} height={30 - i * 4} rx={2} fill={c} stroke="#5a4a8a" strokeWidth={1.4} />
      ))}
      <Path d="M8 30 L58 38 M8 52 L58 50" stroke="#a05a10" strokeWidth={2} />
    </G>
  ),
  // pinwheel
  () => (
    <G>
      <Path d="M32 34 L30 62" stroke="#c98a4a" strokeWidth={3.4} strokeLinecap="round" />
      <Path d="M32 34 L32 10 C44 10 44 24 32 34 Z" fill="#ff5c8a" />
      <Path d="M32 34 L56 34 C56 46 42 46 32 34 Z" fill="#5fb8ff" />
      <Path d="M32 34 L32 58 C20 58 20 44 32 34 Z" fill="#ffd23a" />
      <Path d="M32 34 L8 34 C8 22 22 22 32 34 Z" fill="#3ddc97" />
      <Circle cx={32} cy={34} r={3} fill={W} stroke="#5a4a8a" strokeWidth={1.4} />
    </G>
  ),
  // sailboat
  () => (
    <G>
      <Path d="M8 46 L56 46 L48 58 L16 58 Z" fill="#ff5c5c" stroke="#b81818" strokeWidth={2} strokeLinejoin="round" />
      <Path d="M31 8 L31 46" stroke="#a05a10" strokeWidth={3} />
      <Path d="M33 10 L52 42 L33 42 Z" fill={W} stroke="#5a4a8a" strokeWidth={1.6} strokeLinejoin="round" />
      <Path d="M29 16 L14 42 L29 42 Z" fill="#5fb8ff" stroke="#5a4a8a" strokeWidth={1.6} strokeLinejoin="round" />
    </G>
  ),
  // music box
  () => (
    <G>
      <Rect x={10} y={32} width={44} height={26} rx={4} fill="#b48bff" stroke="#6a22d6" strokeWidth={2} />
      <Path d="M10 32 L18 22 L58 22 L54 32 Z" fill="#d9c4ff" stroke="#6a22d6" strokeWidth={2} strokeLinejoin="round" />
      <Path d="M24 40 L24 50 M24 40 L32 38 L32 48" stroke={W} strokeWidth={2.4} fill="none" strokeLinecap="round" />
      <Circle cx={22} cy={50} r={2.6} fill={W} />
      <Circle cx={30} cy={48} r={2.6} fill={W} />
      <Path d="M54 40 L60 40 M60 36 L60 44" stroke="#ffd23a" strokeWidth={3} strokeLinecap="round" />
    </G>
  ),
];

export const KINDS = 16;
const SETS = { fridge: FOODS, cupboard: TOYS };

// One piece of clutter, `kind` 0-15, `size` px square.
export const Prop = memo(function Prop({ theme, kind, size }) {
  const set = SETS[theme] || FOODS;
  const draw = set[kind % set.length];
  return (
    <Svg width={size} height={size} viewBox="0 0 64 64">
      {draw()}
    </Svg>
  );
});
