import React from 'react';
import { StyleSheet, Text, View } from 'react-native';
import Svg, { Defs, RadialGradient, ClipPath, Stop, Circle, Ellipse, Path, G } from 'react-native-svg';
import { candyColors, candyFonts } from '../../theme/candyTheme';

// The design's gold coin, drawn from its CSS (a 14px circle): 1.5px white
// rim around a radial gold face, a brown ring with a two-tone 3D lip under
// it, a faint inner shade along the bottom, a tilted highlight and a small
// ★ with a brown drop. Geometry below is in those 14px units; the SVG is
// scaled to `size`. Like CSS box-shadows, the ring/lip/glow draw outside
// the size×size layout box.

const STAR_R = 3.3;
const starPath = (() => {
  const pts = [];
  for (let i = 0; i < 10; i++) {
    const r = i % 2 ? STAR_R * 0.42 : STAR_R;
    const a = (Math.PI / 5) * i - Math.PI / 2;
    pts.push(`${(7 + r * Math.cos(a)).toFixed(2)} ${(7.3 + r * Math.sin(a)).toFixed(2)}`);
  }
  return `M${pts.join(' L')} Z`;
})();

// viewBox with room for the lip (below) and the glow (all round)
const VB = { x: -4, y: -4, w: 22, h: 24 };

export function CoinIcon({ size = 14, glow = false }) {
  const k = size / 14;
  return (
    <View style={{ width: size, height: size }} pointerEvents="none">
      <Svg
        width={VB.w * k}
        height={VB.h * k}
        viewBox={`${VB.x} ${VB.y} ${VB.w} ${VB.h}`}
        style={{ position: 'absolute', left: VB.x * k, top: VB.y * k }}
      >
        <Defs>
          <RadialGradient id="coinFace" cx={7} cy={6.12} r={8.42} gradientUnits="userSpaceOnUse">
            <Stop offset="0" stopColor="#fff6a8" />
            <Stop offset="0.42" stopColor="#ffd83a" />
            <Stop offset="0.72" stopColor="#ffb000" />
            <Stop offset="1" stopColor="#f08c00" />
          </RadialGradient>
          <RadialGradient id="coinGlow" cx={7} cy={7} r={glow ? 11 : 10} gradientUnits="userSpaceOnUse">
            <Stop offset="0.55" stopColor="#ffd23c" stopOpacity={glow ? 0.9 : 0.7} />
            <Stop offset="1" stopColor="#ffd23c" stopOpacity={0} />
          </RadialGradient>
          <ClipPath id="coinClip">
            <Circle cx={7} cy={7} r={5.5} />
          </ClipPath>
        </Defs>
        <Circle cx={7} cy={7} r={glow ? 11 : 10} fill="url(#coinGlow)" />
        {/* lip: dark outer, lighter inner, both 1.7 below */}
        <Circle cx={7} cy={8.7} r={9.5} fill="#a04a00" />
        <Circle cx={7} cy={8.7} r={8} fill="#c46800" />
        {/* ring, white rim, face */}
        <Circle cx={7} cy={7} r={8} fill="#a04a00" />
        <Circle cx={7} cy={7} r={7} fill="#ffffff" />
        <Circle cx={7} cy={7} r={5.5} fill="url(#coinFace)" />
        <G clipPath="url(#coinClip)">
          {/* inset 0 -1px 0 — a thin shade along the bottom edge */}
          <Path d="M1.5 7 a5.5 5.5 0 1 0 11 0 a5.5 5.5 0 1 0 -11 0 Z M1.5 6 a5.5 5.5 0 1 0 11 0 a5.5 5.5 0 1 0 -11 0 Z" fillRule="evenodd" fill="rgba(200,90,0,0.45)" />
          <Ellipse cx={5.35} cy={3.81} rx={2.31} ry={1.43} fill="#ffffff" opacity={0.85} transform="rotate(-25 5.35 3.81)" />
        </G>
        {/* ★ with its two text-shadows (a pale lift above, a brown drop below) */}
        <Path d={starPath} fill="#fffbe0" transform="translate(0,-0.5)" />
        <Path d={starPath} fill="#c46800" transform="translate(0,1)" />
        <Path d={starPath} fill="#ffec7a" />
      </Svg>
    </View>
  );
}

// Translucent violet capsule with a white rim — the design's standard
// "glass" container (coin counters, tab bars).
export function GlassPill({ children, style }) {
  return <View style={[styles.glass, style]}>{children}</View>;
}

// Coin counter. A notch bigger than the design's 14px coin / 13px count, on
// request, with the same proportions.
export function CoinPill({ coins, style, size = 17, textStyle }) {
  return (
    <GlassPill style={[styles.coinPill, style]}>
      <CoinIcon size={size} />
      <Text style={[styles.coinText, textStyle]}>{coins}</Text>
    </GlassPill>
  );
}

const styles = StyleSheet.create({
  glass: {
    backgroundColor: candyColors.glass,
    borderWidth: 2,
    borderColor: candyColors.glassBorder,
    borderRadius: 999,
  },
  coinPill: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: 7,
    paddingLeft: 11,
    paddingRight: 13,
    paddingTop: 4,
    paddingBottom: 6,
  },
  coinText: {
    color: candyColors.goldText,
    fontFamily: candyFonts.bodyHeavy,
    fontSize: 15,
    lineHeight: 19,
    textShadowColor: candyColors.outline,
    textShadowOffset: { width: 0, height: 1 },
    textShadowRadius: 0.1,
    includeFontPadding: false,
  },
});
