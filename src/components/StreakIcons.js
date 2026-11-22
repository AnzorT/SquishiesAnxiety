import React from 'react';
import Svg, { Defs, LinearGradient, Path, Stop } from 'react-native-svg';

// The daily streak's little pictures (src/progression.js): the flame, and
// the glyphs for a streak day's free Mystery Box and creature tokens.

// the design's flame (Squad Crib v5, the daily panel's streak pill)
export function Flame({ size = 14 }) {
  return (
    <Svg width={size} height={(size * 16) / 14} viewBox="0 0 14 16">
      <Path d="M7 1 C9 5 13 6 12 11 C11.5 14 9 15 7 15 C4 15 2 13 2 10 C2 7 5 6 5 3 C6 4 7 5 7 1Z" fill="#f2665a" stroke="#5b3a29" strokeWidth={1.2} />
      <Path d="M7 8 C8 10 9.5 10.5 9 12.5 C8.6 14 7.6 14.4 7 14.4 C5.8 14.4 5 13.4 5 12.2 C5 10.8 6.4 10.2 7 8Z" fill="#ffd66b" />
    </Svg>
  );
}

// The same flame drawn big for the streak screen: a glossy gradient body,
// a yellow heart and a highlight. `width` × 1.15 tall.
export function BigFlame({ width = 120, cold = false }) {
  const body = cold ? ['#e0f2ff', '#8cc8ff', '#4f8fd6'] : ['#ffc35a', '#ff7a3a', '#e5352a'];
  const heart = cold ? ['#ffffff', '#d6ecff'] : ['#fffbd0', '#ffd23a'];
  return (
    <Svg width={width} height={width * 1.15} viewBox="0 0 105 121">
      <Defs>
        <LinearGradient id="bfBody" x1="0" y1="0" x2="0" y2="1">
          <Stop offset="0" stopColor={body[0]} />
          <Stop offset="0.5" stopColor={body[1]} />
          <Stop offset="1" stopColor={body[2]} />
        </LinearGradient>
        <LinearGradient id="bfHeart" x1="0" y1="0" x2="0" y2="1">
          <Stop offset="0" stopColor={heart[0]} />
          <Stop offset="1" stopColor={heart[1]} />
        </LinearGradient>
      </Defs>
      <Path
        d="M52 6 C67 36 97 46 91 82 C87 105 68 115 52 115 C30 115 14 99 14 76 C14 53 36 45 37 22 C45 30 51 37 52 6Z"
        fill="url(#bfBody)"
        stroke={cold ? '#1d4f9a' : '#7a2310'}
        strokeWidth={5}
        strokeLinejoin="round"
      />
      <Path d="M52 58 C61 74 72 79 68 95 C65 106 58 110 52 110 C42 110 36 102 36 92 C36 81 48 75 52 58Z" fill="url(#bfHeart)" />
      <Path d="M33 50 C27 60 26 70 29 78" stroke="#ffffff" strokeOpacity={0.65} strokeWidth={6} strokeLinecap="round" fill="none" />
    </Svg>
  );
}
