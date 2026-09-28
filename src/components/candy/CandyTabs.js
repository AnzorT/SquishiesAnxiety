import React, { useEffect, useRef, useState } from 'react';
import { Animated, Pressable, StyleSheet, Text, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { BUTTON_VARIANTS, candyColors, candyFonts } from '../../theme/candyTheme';
import { Shine } from './CandyButton';

// Two-option glass tab bar with a glossy pink pill that springs between the
// options (the design's cubic-bezier(0.34,1.4,0.5,1) overshoot). Used for
// LOGIN/REGISTER and OUR/MY CREATURES. `badges[i]` shows a gold count chip
// next to that tab's label.

export default function CandyTabs({ options, value, onChange, fontSize = 16, padV = 11, badges = [], style }) {
  const [w, setW] = useState(0);
  const index = Math.max(0, options.findIndex((o) => o.value === value));
  const slide = useRef(new Animated.Value(index)).current;
  useEffect(() => {
    Animated.spring(slide, { toValue: index, friction: 7, tension: 90, useNativeDriver: true }).start();
  }, [index, slide]);
  const pillW = Math.max(0, (w - 8) / options.length);
  const translateX = slide.interpolate({ inputRange: [0, 1], outputRange: [0, pillW] });
  const pink = BUTTON_VARIANTS.pink;

  return (
    <View style={[styles.bar, style]} onLayout={(e) => setW(e.nativeEvent.layout.width)}>
      {w > 0 ? (
        <Animated.View style={[styles.pill, { width: pillW, transform: [{ translateX }] }]}>
          <LinearGradient colors={pink.colors} locations={pink.locations} style={styles.pillFace}>
            <Shine />
          </LinearGradient>
        </Animated.View>
      ) : null}
      {options.map((o, i) => {
        const active = i === index;
        return (
          <Pressable key={String(o.value)} style={[styles.tab, { paddingVertical: padV }]} onPress={() => onChange(o.value)}>
            <Text style={[styles.label, { fontSize, color: active ? '#ffffff' : 'rgba(255,255,255,0.72)' }]} numberOfLines={1}>
              {o.label}
            </Text>
            {badges[i] ? (
              <View style={styles.badge}>
                <Text style={styles.badgeText}>{badges[i]}</Text>
              </View>
            ) : null}
          </Pressable>
        );
      })}
    </View>
  );
}

const styles = StyleSheet.create({
  bar: {
    flexDirection: 'row',
    backgroundColor: candyColors.glass,
    borderWidth: 2,
    borderColor: candyColors.glassBorder,
    borderRadius: 999,
    padding: 4,
  },
  pill: {
    position: 'absolute',
    top: 4,
    bottom: 4,
    left: 4,
    borderRadius: 999,
    backgroundColor: candyColors.pinkRing,
    padding: 1,
  },
  pillFace: { flex: 1, borderRadius: 999, borderWidth: 2.5, borderColor: '#ffffff', overflow: 'hidden' },
  tab: { flex: 1, flexDirection: 'row', alignItems: 'center', justifyContent: 'center', gap: 6 },
  label: {
    fontFamily: candyFonts.display,
    letterSpacing: 0.8,
    textShadowColor: candyColors.pinkRing,
    textShadowOffset: { width: 0, height: 2 },
    textShadowRadius: 1,
  },
  badge: {
    minWidth: 16,
    height: 16,
    paddingHorizontal: 4,
    borderRadius: 8,
    backgroundColor: '#ffc233',
    borderWidth: 1.5,
    borderColor: '#ffffff',
    alignItems: 'center',
    justifyContent: 'center',
  },
  badgeText: { color: '#7a3a00', fontSize: 9, fontFamily: candyFonts.bodyBlack },
});
