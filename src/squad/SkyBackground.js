import React, { memo, useState } from 'react';
import { View, StyleSheet } from 'react-native';
import Svg, { Defs, LinearGradient, RadialGradient, Stop, Rect, Pattern, Circle, Ellipse } from 'react-native-svg';

// The squish screen's sky from "ASMR Creature Squash v5": blue at the top
// fading through lavender to pink, a pink glow rising from the bottom, a
// soft white glow behind the toy, three cloud puffs and a white dot grid
// every 26px. One static SVG, memoized and kept as a hardware layer (as
// CandyBackground does), so the 3D stage's frames never repaint it.
//
// The CSS radial gradients size themselves from the box ("farthest-corner"),
// so the radii are worked out here from the measured size.

const PUFFS = [
  { x: 0.16, y: 0.14, solid: 24, fade: 44, a: 0.75 },
  { x: 0.26, y: 0.12, solid: 18, fade: 36, a: 0.7 },
  { x: 0.84, y: 0.26, solid: 20, fade: 38, a: 0.6 },
];

const Sky = memo(function Sky({ width: w, height: h }) {
  // circle at 50% 46%, transparent at 48% of the farthest-corner radius
  const glowR = 0.48 * Math.hypot(w / 2, h * 0.54);
  // ellipse at 50% 112%: farthest-corner radii are √2 × the side distances
  const pinkRx = 0.62 * Math.SQRT2 * (w / 2);
  const pinkRy = 0.62 * Math.SQRT2 * (h * 1.12);
  return (
    <Svg style={StyleSheet.absoluteFill} width={w} height={h} renderToHardwareTextureAndroid>
      <Defs>
        <LinearGradient id="skyBg" x1="0" y1="0" x2="0" y2="1">
          <Stop offset="0" stopColor="#8fd0ff" />
          <Stop offset="0.38" stopColor="#b9e2ff" />
          <Stop offset="0.68" stopColor="#e6dcff" />
          <Stop offset="1" stopColor="#ffd6f4" />
        </LinearGradient>
        <RadialGradient id="skyPink" cx="50%" cy="50%" r="50%">
          <Stop offset="0" stopColor="#ff8cd7" stopOpacity={0.6} />
          <Stop offset="1" stopColor="#ff8cd7" stopOpacity={0} />
        </RadialGradient>
        <RadialGradient id="skyGlow" cx="50%" cy="50%" r="50%">
          <Stop offset="0" stopColor="#ffffff" stopOpacity={0.55} />
          <Stop offset="1" stopColor="#ffffff" stopOpacity={0} />
        </RadialGradient>
        {PUFFS.map((p, i) => (
          <RadialGradient key={i} id={`skyPuff${i}`} cx="50%" cy="50%" r="50%">
            <Stop offset="0" stopColor="#ffffff" stopOpacity={p.a} />
            <Stop offset={p.solid / p.fade} stopColor="#ffffff" stopOpacity={p.a} />
            <Stop offset="1" stopColor="#ffffff" stopOpacity={0} />
          </RadialGradient>
        ))}
        <Pattern id="skyDots" x="0" y="0" width="26" height="26" patternUnits="userSpaceOnUse">
          <Circle cx="13" cy="13" r="1.4" fill="#ffffff" fillOpacity={0.8} />
        </Pattern>
      </Defs>
      <Rect x="0" y="0" width={w} height={h} fill="url(#skyBg)" />
      <Circle cx={w / 2} cy={h * 0.46} r={glowR} fill="url(#skyGlow)" />
      <Ellipse cx={w / 2} cy={h * 1.12} rx={pinkRx} ry={pinkRy} fill="url(#skyPink)" />
      {PUFFS.map((p, i) => (
        <Circle key={i} cx={w * p.x} cy={h * p.y} r={p.fade} fill={`url(#skyPuff${i})`} />
      ))}
      <Rect x="0" y="0" width={w} height={h} fill="url(#skyDots)" />
    </Svg>
  );
});

export default function SkyBackground({ children, style }) {
  const [size, setSize] = useState(null);
  return (
    <View
      style={[styles.fill, style]}
      onLayout={(e) => {
        const { width, height } = e.nativeEvent.layout;
        if (!size || size.width !== width || size.height !== height) setSize({ width, height });
      }}
    >
      {size ? <Sky width={size.width} height={size.height} /> : null}
      {children}
    </View>
  );
}

const styles = StyleSheet.create({
  fill: { flex: 1, backgroundColor: '#c9e4ff', overflow: 'hidden' },
});
