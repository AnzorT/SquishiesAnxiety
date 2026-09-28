import React, { memo, useState } from 'react';
import { View, StyleSheet } from 'react-native';
import Svg, { Defs, LinearGradient, RadialGradient, Stop, Rect, Pattern, Circle } from 'react-native-svg';
import { candyBg } from '../../theme/candyTheme';
import Sparkles from './Sparkles';

// The v3 stage every full-screen view sits on: a pink→violet vertical
// gradient, three soft colour glows, four bokeh circles, and two offset
// polka-dot grids (white every 19px, butter-yellow every 29px). Drawn once
// in a single static SVG and memoized, so screens that re-render a lot (the
// squish stage) never repaint it. `sparkles` adds the twinkling ✦ layer
// (Splash, Home, Mystery Box) — the squish screen leaves it off.
//
// The SVG gets the container's measured pixel size rather than "100%":
// with percentage sizing it kept the size from its first layout pass, so a
// later resize (e.g. the system nav bar settling) left a bare strip at the
// bottom.

const Stage = memo(function Stage({ width, height }) {
  return (
    <Svg style={StyleSheet.absoluteFill} width={width} height={height}>
      <Defs>
        <LinearGradient id="stageBg" x1="0" y1="0" x2="0" y2="1">
          {candyBg.colors.map((c, i) => (
            <Stop key={c} offset={candyBg.locations[i]} stopColor={c} />
          ))}
        </LinearGradient>
        <RadialGradient id="glowTL" cx="15%" cy="5%" r="40%">
          <Stop offset="0" stopColor="#ffc8f5" stopOpacity={0.95} />
          <Stop offset="1" stopColor="#ffc8f5" stopOpacity={0} />
        </RadialGradient>
        <RadialGradient id="glowR" cx="92%" cy="32%" r="45%">
          <Stop offset="0" stopColor="#aa6eff" stopOpacity={0.85} />
          <Stop offset="1" stopColor="#aa6eff" stopOpacity={0} />
        </RadialGradient>
        <RadialGradient id="glowC" cx="50%" cy="40%" r="55%">
          <Stop offset="0" stopColor="#ffb4eb" stopOpacity={0.55} />
          <Stop offset="1" stopColor="#ffb4eb" stopOpacity={0} />
        </RadialGradient>
        <RadialGradient id="bokeh" cx="50%" cy="50%" r="50%">
          <Stop offset="0" stopColor="#ffffff" stopOpacity={0.26} />
          <Stop offset="0.7" stopColor="#ffffff" stopOpacity={0.22} />
          <Stop offset="1" stopColor="#ffffff" stopOpacity={0} />
        </RadialGradient>
        <Pattern id="dotsWhite" x="0" y="0" width="19" height="19" patternUnits="userSpaceOnUse">
          <Circle cx="1" cy="1" r="1.2" fill="#ffffff" fillOpacity={0.7} />
        </Pattern>
        <Pattern id="dotsGold" x="9" y="11" width="29" height="29" patternUnits="userSpaceOnUse">
          <Circle cx="1" cy="1" r="1.2" fill="#fff0aa" fillOpacity={0.55} />
        </Pattern>
      </Defs>
      <Rect x="0" y="0" width="100%" height="100%" fill="url(#stageBg)" />
      <Rect x="0" y="0" width="100%" height="100%" fill="url(#glowR)" />
      <Rect x="0" y="0" width="100%" height="100%" fill="url(#glowC)" />
      <Rect x="0" y="0" width="100%" height="100%" fill="url(#glowTL)" />
      <Circle cx="12%" cy="22%" r="20" fill="url(#bokeh)" />
      <Circle cx="86%" cy="14%" r="30" fill="url(#bokeh)" />
      <Circle cx="78%" cy="62%" r="26" fill="url(#bokeh)" />
      <Circle cx="20%" cy="78%" r="34" fill="url(#bokeh)" />
      <Rect x="0" y="0" width="100%" height="100%" fill="url(#dotsWhite)" />
      <Rect x="0" y="0" width="100%" height="100%" fill="url(#dotsGold)" />
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
  fill: { flex: 1, backgroundColor: '#b24fe6', overflow: 'hidden' },
});
