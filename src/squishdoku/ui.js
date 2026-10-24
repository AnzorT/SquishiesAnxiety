import React, { memo, useRef } from 'react';
import { Animated, Image, Pressable, StyleSheet, Text, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import ShadowText, { outline3 } from '../components/candy/ShadowText';
import sfx from '../audio/sfx';
import { F, INK } from './theme';

// Squishdoku's buttons and chips. Buttons squash on press (scale down, then
// spring back past 1) and play their own sound — `sound` names an sfx
// effect, null for none.

export const BTN = {
  pink: { ring: '#8e1580', colors: ['#ffd6f4', '#ff5cc6', '#c02bd9'] },
  gold: { ring: '#9c4d06', colors: ['#fff7b0', '#ffd23a', '#ff9c0a'] },
  green: { ring: '#0d7a4a', colors: ['#b8ffd9', '#3ddc97', '#16a86a'] },
  blue: { ring: '#1d4f9a', colors: ['#d6f3ff', '#5fb8ff', '#2f7fd6'] },
  cyan: { ring: '#0c5a9c', colors: ['#b0fbff', '#3fd7f6', '#1695d6'] },
  purple: { ring: '#45189a', colors: ['#efe6ff', '#b48bff', '#8f3cf2'] },
  white: { ring: '#45189a', colors: ['#ffffff', '#f6efff', '#e4d6ff'] },
  grey: { ring: '#7a6a8c', colors: ['#e6dcf0', '#c9b9da', '#b9a6cc'] },
  red: { ring: '#8e1030', colors: ['#ffc2cc', '#ff5c7a', '#e01e4a'] },
};

export function SdButton({ kind = 'pink', onPress, disabled, children, style, faceStyle, sound = 'tap', radius = 999, lip = 5, haptic }) {
  const t = useRef(new Animated.Value(0)).current;
  const b = BTN[disabled ? 'grey' : kind] || BTN.pink;
  const down = () => {
    Animated.timing(t, { toValue: 1, duration: 70, useNativeDriver: true }).start();
  };
  const up = () => {
    Animated.spring(t, { toValue: 0, friction: 3.5, tension: 260, useNativeDriver: true }).start();
  };
  const scale = t.interpolate({ inputRange: [0, 1], outputRange: [1, 0.93] });
  const translateY = t.interpolate({ inputRange: [0, 1], outputRange: [0, lip - 1] });
  return (
    <Pressable
      disabled={disabled}
      onPressIn={down}
      onPressOut={up}
      onPress={(e) => {
        if (sound) sfx.play(sound);
        haptic && haptic();
        onPress && onPress(e);
      }}
      hitSlop={6}
      style={style}
    >
      <Animated.View style={{ transform: [{ scale }] }}>
        <View style={[styles.lip, { borderRadius: radius, backgroundColor: b.ring, top: lip }]} />
        <Animated.View style={[styles.ring, { borderRadius: radius, backgroundColor: b.ring, transform: [{ translateY }] }]}>
          <LinearGradient colors={b.colors} locations={[0, 0.5, 1]} style={[styles.face, { borderRadius: radius }, faceStyle]}>
            <View pointerEvents="none" style={[styles.shine, { borderRadius: radius }]} />
            {children}
          </LinearGradient>
        </Animated.View>
        <View style={{ height: lip }} />
      </Animated.View>
    </Pressable>
  );
}

export const BtnLabel = ({ children, kind = 'pink', size = 17, style }) => (
  <ShadowText style={[{ fontFamily: F.display, fontSize: size, color: '#ffffff', includeFontPadding: false }, style]} shadows={outline3((BTN[kind] || BTN.pink).ring, 2)}>
    {children}
  </ShadowText>
);

export const Chip = ({ children, bg = '#ffffff', color = INK, style }) => (
  <View style={[styles.chip, { backgroundColor: bg }, style]}>
    <Text style={[styles.chipText, { color }]}>{children}</Text>
  </View>
);

// A creature's still in a white sticker circle (the score creatures).
export const Head = memo(function Head({ uri, size = 44, ring = '#ffffff', bg = '#f6efff', dim = false, style }) {
  return (
    <View style={[{ width: size, height: size, borderRadius: size, backgroundColor: ring, padding: size * 0.06 }, style]}>
      <View style={{ flex: 1, borderRadius: size, backgroundColor: bg, overflow: 'hidden', alignItems: 'center', justifyContent: 'center' }}>
        {uri ? <Image source={{ uri }} style={{ width: '92%', height: '92%', opacity: dim ? 0.25 : 1 }} resizeMode="contain" fadeDuration={0} /> : null}
      </View>
    </View>
  );
});

export function XGlyph({ size = 18, color = INK }) {
  const bar = { position: 'absolute', width: size, height: size * 0.22, borderRadius: size, backgroundColor: color };
  return (
    <View style={{ width: size, height: size, alignItems: 'center', justifyContent: 'center' }}>
      <View style={[bar, { transform: [{ rotate: '45deg' }] }]} />
      <View style={[bar, { transform: [{ rotate: '-45deg' }] }]} />
    </View>
  );
}

const styles = StyleSheet.create({
  lip: { ...StyleSheet.absoluteFillObject },
  ring: { padding: 2.5 },
  face: { borderWidth: 3, borderColor: '#ffffff', overflow: 'hidden', alignItems: 'center', justifyContent: 'center', flexDirection: 'row', gap: 8, paddingHorizontal: 18, paddingVertical: 9 },
  shine: { position: 'absolute', left: '8%', right: '8%', top: 2, height: '42%', backgroundColor: 'rgba(255,255,255,0.45)' },
  chip: { borderRadius: 999, paddingHorizontal: 9, paddingVertical: 3, borderWidth: 2, borderColor: '#ffffff' },
  chipText: { fontFamily: F.display, fontSize: 11.5, letterSpacing: 0.5, includeFontPadding: false },
});
