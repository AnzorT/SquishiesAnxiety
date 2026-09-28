import React from 'react';
import { StyleSheet, Text, View } from 'react-native';
import Svg, { Defs, RadialGradient, Stop, Circle, Ellipse, Path } from 'react-native-svg';
import { candyColors, candyFonts } from '../../theme/candyTheme';

// Gold star coin: orange ring + lip, white rim, radial gold face, a tilted
// highlight and a raised star. Scales cleanly from 10px (price tags) to 30px
// (floating "+1" pops) since it's all one SVG.

const STAR = 'M12 5.2 L13.9 9.4 L18.4 9.8 L15 12.8 L16 17.2 L12 14.9 L8 17.2 L9 12.8 L5.6 9.8 L10.1 9.4 Z';

export function CoinIcon({ size = 14, glow = false }) {
  return (
    <View style={glow ? styles.glow : null}>
      <Svg width={size} height={size * 1.12} viewBox="0 0 24 27">
        <Defs>
          <RadialGradient id="coinFace" cx="50%" cy="42%" r="55%">
            <Stop offset="0" stopColor="#fff6a8" />
            <Stop offset="0.42" stopColor="#ffd83a" />
            <Stop offset="0.72" stopColor="#ffb000" />
            <Stop offset="1" stopColor="#f08c00" />
          </RadialGradient>
        </Defs>
        {/* lip + ring */}
        <Circle cx={12} cy={14.5} r={11.8} fill="#a04a00" />
        <Circle cx={12} cy={12} r={11.8} fill="#a04a00" />
        {/* white rim */}
        <Circle cx={12} cy={12} r={10.6} fill="#ffffff" />
        <Circle cx={12} cy={12} r={8.6} fill="url(#coinFace)" />
        <Ellipse cx={8.6} cy={6.6} rx={4.4} ry={2.4} fill="#ffffff" opacity={0.85} transform="rotate(-25 8.6 6.6)" />
        <Path d={STAR} fill="#c46800" transform="translate(0,0.9)" />
        <Path d={STAR} fill="#ffec7a" />
      </Svg>
    </View>
  );
}

// Translucent violet capsule with a white rim — the design's standard
// "glass" container (coin counters, tab bars).
export function GlassPill({ children, style }) {
  return <View style={[styles.glass, style]}>{children}</View>;
}

export function CoinPill({ coins, style, size = 14, textStyle }) {
  return (
    <GlassPill style={[styles.coinPill, style]}>
      <CoinIcon size={size} />
      <Text style={[styles.coinText, textStyle]}>{coins}</Text>
    </GlassPill>
  );
}

const styles = StyleSheet.create({
  glow: {
    shadowColor: '#ffd23c',
    shadowOpacity: 0.9,
    shadowRadius: 8,
    shadowOffset: { width: 0, height: 0 },
  },
  glass: {
    backgroundColor: candyColors.glass,
    borderWidth: 2,
    borderColor: candyColors.glassBorder,
    borderRadius: 999,
  },
  coinPill: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: 6,
    paddingHorizontal: 11,
    paddingVertical: 4,
  },
  coinText: {
    color: candyColors.goldText,
    fontFamily: candyFonts.bodyHeavy,
    fontSize: 13,
    textShadowColor: candyColors.outline,
    textShadowOffset: { width: 0, height: 1 },
    textShadowRadius: 1,
  },
});
