import React, { memo, useEffect, useRef } from 'react';
import { Animated, Easing, StyleSheet, Text, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Defs, RadialGradient, LinearGradient as SvgLinearGradient, Stop, Path, G, Ellipse } from 'react-native-svg';
import { candyColors, candyFonts, TIERS } from '../../theme/candyTheme';

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

// ---- gold pedestal the card creature stands on ------------------------
// A flat gold ellipse (white rim, brown ring and 6px lip) — SVG because a
// View's borderRadius caps at half the height, which makes a pill, not an
// ellipse.
export function Pedestal({ width = 180, height = 22 }) {
  const rx = width / 2;
  const ry = height / 2;
  return (
    <View style={{ width: width + 4, height: height + 10 }} pointerEvents="none">
      <Svg width={width + 4} height={height + 10}>
        <Defs>
          <SvgLinearGradient id="pedGold" x1="0" y1="0" x2="0" y2="1">
            <Stop offset="0" stopColor="#fff3b0" />
            <Stop offset="0.45" stopColor="#ffcc33" />
            <Stop offset="1" stopColor="#e08a00" />
          </SvgLinearGradient>
        </Defs>
        <Ellipse cx={rx + 2} cy={ry + 8} rx={rx + 2} ry={ry + 2} fill="#a0520a" />
        <Ellipse cx={rx + 2} cy={ry + 2} rx={rx + 2} ry={ry + 2} fill="#a0520a" />
        <Ellipse cx={rx + 2} cy={ry + 2} rx={rx} ry={ry} fill="#ffffff" />
        <Ellipse cx={rx + 2} cy={ry + 2} rx={rx - 3} ry={ry - 3} fill="url(#pedGold)" />
      </Svg>
    </View>
  );
}

// ---- the white/pink card every creature sits in ------------------------
export function CandyCard({ children, style, innerStyle, dashed = false, colors }) {
  return (
    <View style={[styles.cardRing, style]}>
      <View style={[styles.cardWhite, dashed && styles.cardDashed]}>
        <LinearGradient
          colors={colors || ['#fff6fd', '#ffdcf4', '#f5cbff']}
          locations={colors ? undefined : [0, 0.6, 1]}
          style={[styles.cardFill, innerStyle]}
        >
          {children}
        </LinearGradient>
      </View>
    </View>
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

// ---- rarity chip (COMMON / RARE / … ) ---------------------------------
// `look` ({ label, bg, color }) draws a chip that isn't a rarity, like a
// custom creature's MY CREATION.
export function TierChip({ tier, look, pulse = true, style, fontSize = 9 }) {
  const t = look || TIERS[tier];
  const anim = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    if (!pulse) return undefined;
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(anim, { toValue: 1, duration: 800, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
        Animated.timing(anim, { toValue: 0, duration: 800, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
      ])
    );
    loop.start();
    return () => loop.stop();
  }, [pulse, anim]);
  if (!t) return null;
  const scale = anim.interpolate({ inputRange: [0, 1], outputRange: [1, 1.04] });
  return (
    <Animated.View style={[styles.chipRing, { transform: [{ scale }] }, style]}>
      {/* white rim as its own layer — on Android a gradient view paints over
          part of its own border */}
      <View style={styles.chipRim}>
        <LinearGradient colors={t.bg} start={{ x: 0, y: 0 }} end={{ x: 1, y: 0.4 }} style={styles.chipFace}>
          <Text style={[styles.chipText, { color: t.color, fontSize, lineHeight: Math.round(fontSize * 1.36) }]}>{t.label}</Text>
        </LinearGradient>
      </View>
    </Animated.View>
  );
}

// ---- a gentle 1→1.04 breathing wrapper ---------------------------------
export function SoftPulse({ children, to = 1.04, halfMs = 800, style, active = true, onLayout }) {
  const anim = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    if (!active) return undefined;
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(anim, { toValue: 1, duration: halfMs, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
        Animated.timing(anim, { toValue: 0, duration: halfMs, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
      ])
    );
    loop.start();
    return () => loop.stop();
  }, [anim, halfMs, active]);
  const scale = anim.interpolate({ inputRange: [0, 1], outputRange: [1, to] });
  return (
    <Animated.View style={[style, { transform: [{ scale }] }]} onLayout={onLayout}>
      {children}
    </Animated.View>
  );
}

const styles = StyleSheet.create({
  cardRing: {
    borderRadius: 31,
    padding: 3,
    backgroundColor: candyColors.cardRing,
    shadowColor: '#320064',
    shadowOffset: { width: 0, height: 14 },
    shadowOpacity: 0.5,
    shadowRadius: 18,
    elevation: 12,
  },
  cardWhite: { flex: 1, borderRadius: 28, borderWidth: 4, borderColor: '#ffffff', overflow: 'hidden' },
  cardDashed: { borderStyle: 'dashed' },
  cardFill: { flex: 1 },

  progRing: { padding: 2 },
  progTrack: { borderWidth: 2.5, borderColor: '#ffffff', backgroundColor: 'rgba(80,12,140,0.45)', overflow: 'hidden' },

  chipRing: { borderRadius: 999, backgroundColor: candyColors.cardRing, padding: 1.5 },
  chipRim: { borderRadius: 999, padding: 2, backgroundColor: '#ffffff' },
  chipFace: { borderRadius: 999, paddingHorizontal: 8, paddingVertical: 1 },
  chipText: { fontFamily: candyFonts.bodyBlack, letterSpacing: 1.2, includeFontPadding: false },
});
