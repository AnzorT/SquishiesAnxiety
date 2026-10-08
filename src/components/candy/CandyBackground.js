import React, { memo, useState } from 'react';
import { View, StyleSheet } from 'react-native';
import Svg, { Defs, LinearGradient, RadialGradient, Stop, Rect, Pattern, Circle, Ellipse } from 'react-native-svg';
import Sparkles from './Sparkles';

// The stage every full-screen view sits on: since 2026-10-08 the sky of
// "Squish Squad App.html" (Squishies Tab v2, Shop Screen v2, Full Roster):
// blue at the top through pale blue and lavender to pink, five soft white
// cloud wisps, and white dots every 26px. Drawn once in a single static SVG
// and memoized, so screens that re-render a lot never repaint it.
// `sparkles` adds the twinkling ✦ layer.
//
// The SVG gets the container's measured pixel size rather than "100%":
// with percentage sizing it kept the size from its first layout pass, so a
// later resize (e.g. the system nav bar settling) left a bare strip at the
// bottom.

// the design's clouds: radial-gradient(ellipse RXpx RYpx at X% Y%, white A
// 0 SOLID%, transparent 100%)
const CLOUDS = [
  { x: 0.12, y: 0.09, rx: 90, ry: 26, a: 0.95, solid: 0.6 },
  { x: 0.24, y: 0.07, rx: 60, ry: 20, a: 0.95, solid: 0.55 },
  { x: 0.88, y: 0.15, rx: 110, ry: 30, a: 0.9, solid: 0.55 },
  { x: 0.08, y: 0.52, rx: 130, ry: 34, a: 0.7, solid: 0.5 },
  { x: 0.96, y: 0.7, rx: 120, ry: 30, a: 0.7, solid: 0.5 },
];

// Kept as one hardware layer on Android: without it, every frame that has
// anything moving over it re-runs the full-screen fills for the dirty
// region on the GPU. As a layer it's a single texture read.
const Stage = memo(function Stage({ width, height }) {
  return (
    <Svg style={StyleSheet.absoluteFill} width={width} height={height} renderToHardwareTextureAndroid>
      <Defs>
        <LinearGradient id="stageBg" x1="0" y1="0" x2="0" y2="1">
          <Stop offset="0" stopColor="#8fd0ff" />
          <Stop offset="0.38" stopColor="#b9e2ff" />
          <Stop offset="0.68" stopColor="#e6dcff" />
          <Stop offset="1" stopColor="#ffd6f4" />
        </LinearGradient>
        {CLOUDS.map((c, i) => (
          <RadialGradient key={i} id={`cloud${i}`} cx="50%" cy="50%" r="50%">
            <Stop offset={c.solid} stopColor="#ffffff" stopOpacity={c.a} />
            <Stop offset="1" stopColor="#ffffff" stopOpacity={0} />
          </RadialGradient>
        ))}
        <Pattern id="stageDots" x="0" y="0" width="26" height="26" patternUnits="userSpaceOnUse">
          <Circle cx="1" cy="1" r="1.3" fill="#ffffff" fillOpacity={0.8} />
        </Pattern>
      </Defs>
      <Rect x="0" y="0" width={width} height={height} fill="url(#stageBg)" />
      {CLOUDS.map((c, i) => (
        <Ellipse key={i} cx={c.x * width} cy={c.y * height} rx={c.rx} ry={c.ry} fill={`url(#cloud${i})`} />
      ))}
      <Rect x="0" y="0" width={width} height={height} fill="url(#stageDots)" />
    </Svg>
  );
});

export default function CandyBackground({ children, style, sparkles = false, sparkleOpacity = 0.7 }) {
  const [size, setSize] = useState(null);
  return (
    <View
      style={[styles.fill, style]}
      onLayout={(e) => {
        const { width, height } = e.nativeEvent.layout;
        if (!size || size.width !== width || size.height !== height) setSize({ width, height });
      }}
    >
      {size ? <Stage width={size.width} height={size.height} /> : null}
      {sparkles ? <Sparkles opacity={sparkleOpacity} /> : null}
      {children}
    </View>
  );
}

const styles = StyleSheet.create({
  fill: { flex: 1, backgroundColor: '#b9e2ff', overflow: 'hidden' },
});
