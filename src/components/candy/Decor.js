import React, { memo, useEffect, useRef } from 'react';
import { Animated, Easing, StyleSheet, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Defs, RadialGradient, Stop, Path, G } from 'react-native-svg';
import { candyColors } from '../../theme/candyTheme';
import { usePingPong } from '../idleLoop';

// ---- spinning light rays ----------------------------------------------
// The design's `repeating-conic-gradient` sunburst, faded out toward the rim
// by a radial mask, turning slowly (raysSpin). Wedges are drawn once as SVG
// and the whole thing rotates on the native driver.

function wedgePath(cx, r, a0, a1) {
  const rad = (a) => ((a - 90) * Math.PI) / 180;
  const x0 = cx + r * Math.cos(rad(a0));
  const y0 = cx + r * Math.sin(rad(a0));
  const x1 = cx + r * Math.cos(rad(a1));
  const y1 = cx + r * Math.sin(rad(a1));
  return `M${cx} ${cx} L${x0.toFixed(2)} ${y0.toFixed(2)} A${r} ${r} 0 0 1 ${x1.toFixed(2)} ${y1.toFixed(2)} Z`;
}

const RaysArt = memo(function RaysArt({ size, rayDeg, gapDeg, opacity, fadeStart, fadeEnd, color }) {
  const c = size / 2;
  const step = rayDeg + gapDeg;
  const n = Math.round(360 / step);
  const paths = [];
  for (let i = 0; i < n; i++) paths.push(wedgePath(c, c, i * (360 / n), i * (360 / n) + rayDeg));
  return (
    <Svg width={size} height={size}>
      <Defs>
        <RadialGradient id="rayFade" cx={c} cy={c} r={c} gradientUnits="userSpaceOnUse">
          <Stop offset={fadeStart} stopColor={color} stopOpacity={opacity} />
          <Stop offset={fadeEnd} stopColor={color} stopOpacity={0} />
        </RadialGradient>
      </Defs>
      <G>
        {paths.map((d, i) => (
          <Path key={i} d={d} fill="url(#rayFade)" />
        ))}
      </G>
    </Svg>
  );
});

export function RaysSpin({ size = 260, durationMs = 14000, rayDeg = 8, gapDeg = 14, opacity = 0.45, fadeStart = 0.15, fadeEnd = 0.65, color = '#ffffff', style }) {
  const spin = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const loop = Animated.loop(Animated.timing(spin, { toValue: 1, duration: durationMs, easing: Easing.linear, useNativeDriver: true }));
    loop.start();
    return () => loop.stop();
  }, [spin, durationMs]);
  const rotate = spin.interpolate({ inputRange: [0, 1], outputRange: ['0deg', '360deg'] });
  return (
    <Animated.View
      pointerEvents="none"
      // rasterised once; the spin only rotates the texture
      renderToHardwareTextureAndroid
      style={[{ position: 'absolute', width: size, height: size, transform: [{ rotate }] }, style]}
    >
      <RaysArt size={size} rayDeg={rayDeg} gapDeg={gapDeg} opacity={opacity} fadeStart={fadeStart} fadeEnd={fadeEnd} color={color} />
    </Animated.View>
  );
}

// ---- progress bar: white rim, coloured ring, violet track --------------
export function CandyProgress({ pct = 0, height = 12, ring = candyColors.cardRing, fill = ['#fff3a0', '#ffc233'], horizontal = true, style, animatedWidth }) {
  const width = animatedWidth || `${Math.max(0, Math.min(100, pct))}%`;
  return (
    <View style={[styles.progRing, { borderRadius: height, backgroundColor: ring }, style]}>
      <View style={[styles.progTrack, { height, borderRadius: height }]}>
        <Animated.View style={{ width, height: '100%', overflow: 'hidden', borderRadius: height }}>
          <LinearGradient colors={fill} start={{ x: 0, y: 0 }} end={horizontal ? { x: 1, y: 0 } : { x: 0, y: 1 }} style={StyleSheet.absoluteFill} />
        </Animated.View>
      </View>
    </View>
  );
}

// ---- a gentle 1→1.04 breathing wrapper ---------------------------------
// (the pulses here are one native loop each, idleLoop.js)
export function SoftPulse({ children, to = 1.04, halfMs = 800, style, active = true, onLayout }) {
  const scale = usePingPong(halfMs * 2, { from: 1, to, on: !!active });
  return (
    <Animated.View style={[style, { transform: [{ scale }] }]} onLayout={onLayout}>
      {children}
    </Animated.View>
  );
}

const styles = StyleSheet.create({
  progRing: { padding: 2 },
  progTrack: { borderWidth: 2.5, borderColor: '#ffffff', backgroundColor: 'rgba(80,12,140,0.45)', overflow: 'hidden' },
});
