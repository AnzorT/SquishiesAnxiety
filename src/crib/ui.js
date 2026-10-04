import React, { useEffect, useRef } from 'react';
import { Animated, Pressable, StyleSheet, Text, View } from 'react-native';
import Svg, { Circle, Path } from 'react-native-svg';
import { LinearGradient } from 'expo-linear-gradient';
import { candyFonts } from '../theme/candyTheme';

// The Crib's small parts, in the design's palette (brown ink on cream): the
// song pill, the look-left / look-right buttons, a sticker
// button, the toast. (The HUD itself is Hud.js.)

export const INK = '#5b3a29';
export const PAPER = '#fff8ee';
export const SOFT = '#8a6a50';

// the dance room's song pill: what's playing, tap for the next one
export function SongPill({ name, count, onPress, style }) {
  return (
    <Pressable onPress={onPress} style={({ pressed }) => [styles.song, style, pressed && { opacity: 0.8 }]}>
      <Svg width={14} height={14} viewBox="0 0 24 24">
        <Path d="M9 17V5l10-2v12" stroke="#ff5cc6" strokeWidth={2.6} fill="none" />
        <Circle cx={6.5} cy={17.5} r={3} fill="#ff5cc6" />
        <Circle cx={16.5} cy={15.5} r={3} fill="#5cf2c8" />
      </Svg>
      <Text style={styles.songText}>{name}</Text>
      <Text style={styles.songCount}>{`${count} ›`}</Text>
    </Pressable>
  );
}

// look left / right (the portrait page's sideways room)
export function PanButton({ dir, onPress, style }) {
  return (
    <Pressable onPress={onPress} hitSlop={6} style={({ pressed }) => [styles.pan, style, pressed && { opacity: 0.7 }]}>
      <Svg width={16} height={16} viewBox="0 0 24 24">
        <Path d={dir < 0 ? 'M15 5 L8 12 L15 19' : 'M9 5 L16 12 L9 19'} stroke="#ffffff" strokeWidth={3.4} fill="none" strokeLinecap="round" strokeLinejoin="round" />
      </Svg>
    </Pressable>
  );
}

export function CoinGlyph({ size = 14 }) {
  return (
    <Svg width={size} height={size} viewBox="0 0 20 20">
      <Circle cx={10} cy={10} r={8.5} fill="#ffd23a" stroke="#a04a00" strokeWidth={2} />
      <Circle cx={10} cy={10} r={4.5} fill="none" stroke="#a04a00" strokeWidth={1.6} opacity={0.6} />
    </Svg>
  );
}

// a sticker button: gradient face, white rim, brown ring and lip
export function StickerButton({ label, onPress, colors = ['#fffbd6', '#ffe045', '#ff9500'], ring = '#a04a00', ink = '#ffffff', small = false, disabled = false, style, pulse = false }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    if (!pulse) return undefined;
    const loop = Animated.loop(Animated.sequence([Animated.timing(t, { toValue: 1, duration: 800, useNativeDriver: true }), Animated.timing(t, { toValue: 0, duration: 800, useNativeDriver: true })]));
    loop.start();
    return () => loop.stop();
  }, [pulse, t]);
  return (
    <Pressable onPress={onPress} disabled={disabled} style={({ pressed }) => [{ opacity: disabled ? 0.5 : 1 }, style, pressed && { transform: [{ translateY: 2 }] }]}>
      <Animated.View style={{ transform: [{ scale: pulse ? t.interpolate({ inputRange: [0, 1], outputRange: [1, 1.04] }) : 1 }] }}>
        <View style={[styles.stickerLip, { backgroundColor: ring }]} />
        <View style={[styles.stickerRing, { backgroundColor: ring }]}>
          <LinearGradient colors={colors} locations={[0, 0.45, 1]} style={[styles.stickerFace, small && styles.stickerFaceSmall]}>
            <Text style={[styles.stickerText, small && styles.stickerTextSmall, { color: ink, textShadowColor: ink === '#ffffff' ? ring : 'transparent' }]} numberOfLines={1}>
              {label}
            </Text>
          </LinearGradient>
        </View>
      </Animated.View>
    </Pressable>
  );
}

// a plain cream button (back, cancel)
export function PlainButton({ label, onPress, style }) {
  return (
    <Pressable onPress={onPress} style={({ pressed }) => [styles.plain, style, pressed && { opacity: 0.7 }]}>
      <Text style={styles.plainText}>{label}</Text>
    </Pressable>
  );
}

// The Crib's toast (the design's): a white-rimmed cream card with a title,
// a line, maybe a creature and a button. Drops in from the top; the screen
// owns the timer.
export function CribToast({ toast, children, onAction }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    if (!toast) return undefined;
    t.setValue(0);
    const a = Animated.spring(t, { toValue: 1, friction: 7, tension: 140, useNativeDriver: true });
    a.start();
    return () => a.stop();
  }, [toast, t]);
  if (!toast) return null;
  return (
    <Animated.View style={[styles.toast, { opacity: t, transform: [{ translateY: t.interpolate({ inputRange: [0, 1], outputRange: [-70, 0] }) }, { scale: t.interpolate({ inputRange: [0, 1], outputRange: [0.92, 1] }) }] }]} pointerEvents="box-none">
      {children}
      <View style={{ flex: 1 }}>
        <Text style={styles.toastTitle} numberOfLines={1}>
          {toast.title}
        </Text>
        {toast.body ? (
          <Text style={styles.toastBody} numberOfLines={2}>
            {toast.body}
          </Text>
        ) : null}
      </View>
      {toast.action ? <StickerButton small label={toast.action.label} onPress={() => onAction(toast.action)} /> : null}
    </Animated.View>
  );
}

const styles = StyleSheet.create({
  stickerLip: { position: 'absolute', left: 0, right: 0, top: 3, bottom: -3, borderRadius: 999 },
  stickerRing: { borderRadius: 999, padding: 2 },
  stickerFace: { borderRadius: 999, borderWidth: 2.5, borderColor: '#ffffff', paddingHorizontal: 16, paddingVertical: 8 },
  stickerFaceSmall: { paddingHorizontal: 12, paddingVertical: 5 },
  stickerText: { fontFamily: candyFonts.display, fontSize: 14, letterSpacing: 0.5, textAlign: 'center', textShadowRadius: 1, textShadowOffset: { width: 0, height: 1.5 } },
  stickerTextSmall: { fontSize: 12 },
  plain: { borderRadius: 999, borderWidth: 2.5, borderColor: INK, backgroundColor: PAPER, paddingHorizontal: 14, paddingVertical: 7 },
  plainText: { fontFamily: candyFonts.display, fontSize: 13, color: INK, textAlign: 'center' },
  toast: { flexDirection: 'row', alignItems: 'center', gap: 10, paddingHorizontal: 12, paddingVertical: 9, borderRadius: 18, backgroundColor: PAPER, borderWidth: 3, borderColor: '#ffffff', shadowColor: '#000', shadowOpacity: 0.25, shadowRadius: 8, shadowOffset: { width: 0, height: 4 }, elevation: 6 },
  toastTitle: { fontFamily: candyFonts.display, fontSize: 14, color: INK },
  toastBody: { fontFamily: candyFonts.body, fontSize: 12, color: SOFT },
  song: { flexDirection: 'row', alignItems: 'center', gap: 6, paddingLeft: 8, paddingRight: 12, paddingVertical: 5, borderRadius: 999, borderWidth: 2.5, borderColor: '#ffffff', backgroundColor: 'rgba(42,20,48,0.85)' },
  songText: { fontFamily: candyFonts.display, fontSize: 13, color: '#ffffff' },
  songCount: { fontFamily: candyFonts.display, fontSize: 11, color: '#c9b6f0' },
  pan: { width: 34, height: 34, borderRadius: 17, borderWidth: 2.5, borderColor: '#ffffff', backgroundColor: 'rgba(91,58,41,0.55)', alignItems: 'center', justifyContent: 'center' },
});
