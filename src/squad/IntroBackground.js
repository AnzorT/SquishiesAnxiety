import React, { memo, useState } from 'react';
import { View, StyleSheet } from 'react-native';
import Svg, { Defs, LinearGradient, Stop, Rect, Pattern, Circle } from 'react-native-svg';

// The background of the app shell's intro screens (log in / register and the
// daily spin) in "Squish Squad App.html": blue at the top through pale blue
// and lavender to pink, under white dots every 26px. One static SVG, memoized
// and kept as a hardware layer, as SkyBackground.

const Intro = memo(function Intro({ width: w, height: h }) {
  return (
    <Svg style={StyleSheet.absoluteFill} width={w} height={h} renderToHardwareTextureAndroid>
      <Defs>
        <LinearGradient id="introBg" x1="0" y1="0" x2="0" y2="1">
          <Stop offset="0" stopColor="#8fd0ff" />
          <Stop offset="0.38" stopColor="#b9e2ff" />
          <Stop offset="0.68" stopColor="#e6dcff" />
          <Stop offset="1" stopColor="#ffd6f4" />
        </LinearGradient>
        <Pattern id="introDots" width={26} height={26} patternUnits="userSpaceOnUse">
          <Circle cx={1} cy={1} r={1.3} fill="rgba(255,255,255,0.8)" />
        </Pattern>
      </Defs>
      <Rect width={w} height={h} fill="url(#introBg)" />
      <Rect width={w} height={h} fill="url(#introDots)" />
    </Svg>
  );
});

export default function IntroBackground({ children, style }) {
  const [size, setSize] = useState(null);
  return (
    <View style={[styles.fill, style]} onLayout={(e) => e.nativeEvent.layout.width > 0 && e.nativeEvent.layout.height > 0 && setSize(e.nativeEvent.layout)}>
      {size ? <Intro width={size.width} height={size.height} /> : <View style={[StyleSheet.absoluteFill, { backgroundColor: '#b9e2ff' }]} />}
      {children}
    </View>
  );
}

const styles = StyleSheet.create({
  fill: { flex: 1, backgroundColor: '#b9e2ff' },
});
