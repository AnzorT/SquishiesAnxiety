import React, { useRef } from 'react';
import { Animated, Pressable, StyleSheet, Text, View } from 'react-native';
import Svg, { Defs, RadialGradient, LinearGradient, Stop, Circle, Path } from 'react-native-svg';
import { Shine } from './CandyButton';
import sfx from '../../audio/sfx';

// Glossy circle button (back, close, the squish screen's gear): a radial
// face, white border, dark ring + 4px lip, sinks when pressed.
// (REDESIGN_V8: the wood knob, like the royal kit's Orb; it was violet)
const RING = '#6b4426';
const STOPS = [['0', '#f6d9b0'], ['0.45', '#d9a066'], ['1', '#a86e3a']];

export default function RoundButton({ size = 42, onPress, children, disabled = false, dim = false, style, hitSlop = 6, lip = 4 }) {
  const press = useRef(new Animated.Value(0)).current;
  const sink = (to) => Animated.timing(press, { toValue: to, duration: 80, useNativeDriver: true }).start();
  const faceY = press.interpolate({ inputRange: [0, 1], outputRange: [0, lip - 1] });
  const ring = 2;
  const border = size >= 36 ? 2.5 : 2;
  const inner = size - ring * 2 - border * 2;
  const gradId = 'rb-violet';

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
      <View style={[styles.lip, { top: lip, width: size, height: size, borderRadius: size / 2, backgroundColor: RING }]} />
      <Animated.View
        style={[
          styles.face,
          { width: size, height: size, borderRadius: size / 2, borderWidth: ring, borderColor: RING, backgroundColor: RING, transform: [{ translateY: faceY }] },
        ]}
      >
        <View style={{ width: size - ring * 2, height: size - ring * 2, borderRadius: size, borderWidth: border, borderColor: '#fff', overflow: 'hidden' }}>
          <Svg width={inner} height={inner} style={StyleSheet.absoluteFill}>
            <Defs>
              <RadialGradient id={gradId} cx="35%" cy="25%" r="80%">
                {STOPS.map(([o, c]) => (
                  <Stop key={o} offset={o} stopColor={c} />
                ))}
              </RadialGradient>
            </Defs>
            <Circle cx={inner / 2} cy={inner / 2} r={inner} fill={`url(#${gradId})`} />
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
