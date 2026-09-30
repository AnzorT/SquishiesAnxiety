import React, { useRef } from 'react';
import { Animated, Pressable, StyleSheet, Text, View } from 'react-native';
import Svg, { Defs, RadialGradient, LinearGradient, Stop, Circle, Path, G } from 'react-native-svg';
import { Shine } from './CandyButton';
import sfx from '../../audio/sfx';

// Purple glossy circle button (header icons, back, close, carousel arrows):
// radial violet face, white border, dark ring + 4px lip, sinks when pressed.

const RING = '#45189a';

export default function RoundButton({ size = 42, onPress, children, disabled = false, dim = false, style, hitSlop = 6, lip = 4 }) {
  const press = useRef(new Animated.Value(0)).current;
  const sink = (to) => Animated.timing(press, { toValue: to, duration: 80, useNativeDriver: true }).start();
  const faceY = press.interpolate({ inputRange: [0, 1], outputRange: [0, lip - 1] });
  const ring = 2;
  const border = size >= 36 ? 2.5 : 2;
  const inner = size - ring * 2 - border * 2;

  return (
    <Pressable
      onPress={onPress}
      onPressIn={() => {
        if (disabled) return;
        sink(1);
        sfx.play('tap');
      }}
      onPressOut={() => sink(0)}
      disabled={disabled}
      hitSlop={hitSlop}
      style={[{ width: size, height: size + lip, opacity: dim ? 0.4 : 1 }, style]}
    >
      <View style={[styles.lip, { top: lip, width: size, height: size, borderRadius: size / 2 }]} />
      <Animated.View
        style={[
          styles.face,
          { width: size, height: size, borderRadius: size / 2, borderWidth: ring, transform: [{ translateY: faceY }] },
        ]}
      >
        <View style={{ width: size - ring * 2, height: size - ring * 2, borderRadius: size, borderWidth: border, borderColor: '#fff', overflow: 'hidden' }}>
          <Svg width={inner} height={inner} style={StyleSheet.absoluteFill}>
            <Defs>
              <RadialGradient id="violet" cx="35%" cy="25%" r="80%">
                <Stop offset="0" stopColor="#f3d2ff" />
                <Stop offset="0.45" stopColor="#b65cff" />
                <Stop offset="1" stopColor="#6a22d6" />
              </RadialGradient>
            </Defs>
            <Circle cx={inner / 2} cy={inner / 2} r={inner} fill="url(#violet)" />
          </Svg>
          <Shine inset="9%" />
          <View style={styles.content}>{children}</View>
        </View>
      </Animated.View>
    </Pressable>
  );
}

// ---- glyphs ---------------------------------------------------------------

export function BackGlyph({ size = 18 }) {
  return <Text style={[styles.glyph, { fontSize: size + 6, lineHeight: size + 8, marginTop: -3 }]}>‹</Text>;
}

export function CloseGlyph({ size = 14 }) {
  return <Text style={[styles.glyph, { fontSize: size, lineHeight: size + 2 }]}>✕</Text>;
}

// White triangle with a purple drop (carousel / list arrows).
export function Triangle({ dir = 'up', size = 8 }) {
  const w = size * 2;
  const h = size * 1.4;
  const d =
    dir === 'up'
      ? `M0 ${h} L${size} 0 L${w} ${h} Z`
      : dir === 'down'
      ? `M0 0 L${size} ${h} L${w} 0 Z`
      : dir === 'left'
      ? `M${h} 0 L0 ${size} L${h} ${w} Z`
      : `M0 0 L${h} ${size} L0 ${w} Z`;
  const vw = dir === 'up' || dir === 'down' ? w : h;
  const vh = dir === 'up' || dir === 'down' ? h : w;
  return (
    <Svg width={vw} height={vh + 2} viewBox={`0 0 ${vw} ${vh + 2}`}>
      <Path d={d} fill={RING} transform="translate(0,2)" strokeLinejoin="round" />
      <Path d={d} fill="#ffffff" strokeLinejoin="round" />
    </Svg>
  );
}

const TROPHY_PATHS = [
  'M6 5 H3.5 V7.5 A3.5 3.5 0 0 0 7 11',
  'M18 5 H20.5 V7.5 A3.5 3.5 0 0 1 17 11',
  'M6 3 H18 V9 A6 6 0 0 1 6 9 Z',
  'M10.5 15 H13.5 V18 H10.5 Z',
  'M7.5 18 H16.5 V21 H7.5 Z',
];

export function TrophyIcon({ size = 24 }) {
  return (
    <Svg width={size} height={size} viewBox="0 0 24 24">
      <Defs>
        <LinearGradient id="icoGold" x1="0" y1="0" x2="0" y2="1">
          <Stop offset="0" stopColor="#fff7b0" />
          <Stop offset="0.5" stopColor="#ffd23a" />
          <Stop offset="1" stopColor="#ff9c0a" />
        </LinearGradient>
      </Defs>
      <G transform="translate(0,1.5)">
        {TROPHY_PATHS.map((d) => (
          <Path key={d} d={d} stroke={RING} strokeWidth={4.2} strokeLinejoin="round" strokeLinecap="round" fill="none" />
        ))}
      </G>
      {TROPHY_PATHS.map((d) => (
        <Path key={d} d={d} stroke={RING} strokeWidth={4.2} strokeLinejoin="round" strokeLinecap="round" fill="none" />
      ))}
      {TROPHY_PATHS.map((d, i) => (
        <Path key={`f${d}`} d={d} stroke="#ffffff" strokeWidth={1.8} strokeLinejoin="round" strokeLinecap="round" fill={i < 2 ? 'none' : 'url(#icoGold)'} />
      ))}
      <Path d="M8.5 5 V8.5" stroke="#ffffff" strokeWidth={1.6} strokeLinecap="round" opacity={0.9} />
    </Svg>
  );
}

// A bin (a custom creature's delete button): white, outlined like the glyphs.
export function TrashIcon({ size = 16 }) {
  const lid = 'M5 7 H19';
  const handle = 'M9.5 7 V4.8 H14.5 V7';
  const body = 'M6.8 9.5 H17.2 L16.3 20 H7.7 Z';
  return (
    <Svg width={size} height={size} viewBox="0 0 24 24">
      <G stroke={RING} strokeWidth={3.8} strokeLinejoin="round" strokeLinecap="round" fill="none">
        <Path d={lid} />
        <Path d={handle} />
        <Path d={body} />
      </G>
      <Path d={lid} stroke="#ffffff" strokeWidth={2} strokeLinecap="round" />
      <Path d={handle} stroke="#ffffff" strokeWidth={1.6} strokeLinejoin="round" fill="none" />
      <Path d={body} fill="#ffffff" stroke="#ffffff" strokeWidth={1} strokeLinejoin="round" />
      <Path d="M10.4 12 V17.4 M13.6 12 V17.4" stroke="#b65cff" strokeWidth={1.4} strokeLinecap="round" />
    </Svg>
  );
}

// A rising three-bar chart (the Stats screen): blue, pink and gold bars
// drawn like the trophy — dark outline with a drop, white edge, glossy fill.
const statBar = (x, top) => `M${x} ${top + 1.6} a1.6 1.6 0 0 1 1.6 -1.6 h1.4 a1.6 1.6 0 0 1 1.6 1.6 V20.5 H${x} Z`;
const STAT_BARS = [
  [statBar(3.2, 12.5), 'url(#icoStatBlue)'],
  [statBar(9.8, 7.5), 'url(#icoStatPink)'],
  [statBar(16.4, 3), 'url(#icoStatGold)'],
];

export function StatsIcon({ size = 24 }) {
  return (
    <Svg width={size} height={size} viewBox="0 0 24 24">
      <Defs>
        <LinearGradient id="icoStatBlue" x1="0" y1="0" x2="0" y2="1">
          <Stop offset="0" stopColor="#b0fbff" />
          <Stop offset="0.55" stopColor="#3fd7f6" />
          <Stop offset="1" stopColor="#1695d6" />
        </LinearGradient>
        <LinearGradient id="icoStatPink" x1="0" y1="0" x2="0" y2="1">
          <Stop offset="0" stopColor="#ffc2ee" />
          <Stop offset="0.55" stopColor="#ff4fbf" />
          <Stop offset="1" stopColor="#d3179a" />
        </LinearGradient>
        <LinearGradient id="icoStatGold" x1="0" y1="0" x2="0" y2="1">
          <Stop offset="0" stopColor="#fff7b0" />
          <Stop offset="0.5" stopColor="#ffd23a" />
          <Stop offset="1" stopColor="#ff9c0a" />
        </LinearGradient>
      </Defs>
      <G transform="translate(0,1.5)">
        {STAT_BARS.map(([d]) => (
          <Path key={d} d={d} stroke={RING} strokeWidth={4.2} strokeLinejoin="round" fill="none" />
        ))}
      </G>
      {STAT_BARS.map(([d]) => (
        <Path key={d} d={d} stroke={RING} strokeWidth={4.2} strokeLinejoin="round" fill="none" />
      ))}
      {STAT_BARS.map(([d, fill]) => (
        <Path key={`f${d}`} d={d} stroke="#ffffff" strokeWidth={1.8} strokeLinejoin="round" fill={fill} />
      ))}
      <Path d="M18 5.2 V8.5" stroke="#ffffff" strokeWidth={1.4} strokeLinecap="round" opacity={0.9} />
    </Svg>
  );
}

export function BagIcon({ size = 24 }) {
  const handle = 'M8.5 9 V7 a3.5 3.5 0 0 1 7 0 V9';
  const body = 'M4.5 8 H19.5 L18.5 20.5 H5.5 Z';
  return (
    <Svg width={size} height={size} viewBox="0 0 24 24">
      <Defs>
        <LinearGradient id="icoPink" x1="0" y1="0" x2="0" y2="1">
          <Stop offset="0" stopColor="#ffc2ee" />
          <Stop offset="0.55" stopColor="#ff4fbf" />
          <Stop offset="1" stopColor="#d3179a" />
        </LinearGradient>
      </Defs>
      <Path d={body} fill="none" stroke={RING} strokeWidth={4.2} strokeLinejoin="round" transform="translate(0,1.5)" />
      <Path d={handle} fill="none" stroke={RING} strokeWidth={4} strokeLinecap="round" />
      <Path d={handle} fill="none" stroke="#ffd23a" strokeWidth={1.8} strokeLinecap="round" />
      <Path d={body} fill="none" stroke={RING} strokeWidth={4.2} strokeLinejoin="round" />
      <Path d={body} fill="url(#icoPink)" stroke="#ffffff" strokeWidth={1.8} strokeLinejoin="round" />
      <Path
        d="M12 17.6 C9.2 15.6 8.6 14.2 9.6 13.1 C10.4 12.3 11.5 12.6 12 13.4 C12.5 12.6 13.6 12.3 14.4 13.1 C15.4 14.2 14.8 15.6 12 17.6 Z"
        fill="#ffffff"
      />
    </Svg>
  );
}

const GEAR_D =
  'M19.13 10.03 L21.89 10.49 L21.89 13.51 L19.13 13.97 L18.44 15.65 L20.06 17.93 L17.93 20.06 L15.65 18.44 L13.97 19.13 L13.51 21.89 L10.49 21.89 L10.03 19.13 L8.35 18.44 L6.07 20.06 L3.94 17.93 L5.56 15.65 L4.87 13.97 L2.11 13.51 L2.11 10.49 L4.87 10.03 L5.56 8.35 L3.94 6.07 L6.07 3.94 L8.35 5.56 L10.03 4.87 L10.49 2.11 L13.51 2.11 L13.97 4.87 L15.65 5.56 L17.93 3.94 L20.06 6.07 L18.44 8.35 Z';

export function GearIcon({ size = 24 }) {
  return (
    <Svg width={size} height={size} viewBox="0 0 24 24">
      <Defs>
        <LinearGradient id="icoSilver" x1="0" y1="0" x2="0" y2="1">
          <Stop offset="0" stopColor="#ffffff" />
          <Stop offset="0.6" stopColor="#e8dcff" />
          <Stop offset="1" stopColor="#b9a2ee" />
        </LinearGradient>
      </Defs>
      <Path d={GEAR_D} fill="none" stroke={RING} strokeWidth={3.6} strokeLinejoin="round" transform="translate(0,1.2)" />
      <Path d={GEAR_D} fill="none" stroke={RING} strokeWidth={3.6} strokeLinejoin="round" />
      <Path d={GEAR_D} fill="url(#icoSilver)" stroke="#ffffff" strokeWidth={1.2} strokeLinejoin="round" />
      <Circle cx={12} cy={12} r={3.3} fill="#b65cff" stroke={RING} strokeWidth={1.6} />
      <Circle cx={11} cy={11} r={1} fill="#ffffff" opacity={0.9} />
    </Svg>
  );
}

// The design's gold key (Key Shop rows, hold-to-unlock).
export function KeyIcon({ width = 54 }) {
  const h = (width * 26) / 54;
  const bit = 'M19 11 H50 V15 H45 V21 H40 V15 H35 V19 H30 V15 H19 Z';
  return (
    <Svg width={width} height={h} viewBox="-2 -2 58 30">
      <Defs>
        <LinearGradient id="keyGold" x1="0" y1="0" x2="0" y2="1">
          <Stop offset="0" stopColor="#fff7b0" />
          <Stop offset="0.5" stopColor="#ffd23a" />
          <Stop offset="1" stopColor="#ff9c0a" />
        </LinearGradient>
      </Defs>
      <G stroke="#9c4d06" strokeWidth={4.5} strokeLinejoin="round" fill="none">
        <Circle cx={11} cy={13} r={8.5} />
        <Path d={bit} />
      </G>
      <G stroke="#ffffff" strokeWidth={2} strokeLinejoin="round" fill="url(#keyGold)">
        <Path d="M11 4.5 a8.5 8.5 0 1 0 0.01 0 Z M11 9.5 a3.5 3.5 0 1 1 -0.01 0 Z" fillRule="evenodd" />
        <Path d={bit} />
      </G>
      <Circle cx={8} cy={9.5} r={1.6} fill="#ffffff" />
    </Svg>
  );
}

const styles = StyleSheet.create({
  lip: { position: 'absolute', left: 0, backgroundColor: RING },
  face: {
    position: 'absolute',
    top: 0,
    left: 0,
    borderColor: RING,
    backgroundColor: RING,
    alignItems: 'center',
    justifyContent: 'center',
    shadowColor: '#320064',
    shadowOffset: { width: 0, height: 6 },
    shadowOpacity: 0.4,
    shadowRadius: 8,
    elevation: 5,
  },
  content: { ...StyleSheet.absoluteFillObject, alignItems: 'center', justifyContent: 'center' },
  glyph: {
    color: '#ffffff',
    fontWeight: '900',
    textAlign: 'center',
    textShadowColor: RING,
    textShadowOffset: { width: 0, height: 2 },
    textShadowRadius: 1,
    includeFontPadding: false,
  },
});
