import React, { useEffect, useRef } from 'react';
import { Animated, Text, StyleSheet } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { candyColors, candyFonts } from '../../theme/candyTheme';

// Top banner that drops in, holds, then lifts back out — mirrors the
// prototype's bannerDrop keyframe. Parent owns the message + auto-clear
// timer and bumps `messageKey` to retrigger the animation for back-to-back
// achievements.
export default function AchievementToast({ title, messageKey }) {
  const insets = useSafeAreaInsets();
  const anim = useRef(new Animated.Value(0)).current;

  useEffect(() => {
    if (!title) return undefined;
    anim.setValue(0);
    const sequence = Animated.sequence([
      Animated.timing(anim, { toValue: 1, duration: 260, useNativeDriver: true }),
      Animated.delay(1900),
      Animated.timing(anim, { toValue: 0, duration: 260, useNativeDriver: true }),
    ]);
    sequence.start();
    return () => sequence.stop();
  }, [title, messageKey, anim]);

  if (!title) return null;

  const translateY = anim.interpolate({ inputRange: [0, 1], outputRange: [-40, 0] });

  return (
    <Animated.View style={[styles.wrap, { top: insets.top + 12, opacity: anim, transform: [{ translateY }] }]} pointerEvents="none">
      <LinearGradient colors={['#ffe27a', '#ff9fd6']} start={{ x: 0, y: 0 }} end={{ x: 1, y: 1 }} style={styles.pill}>
        <Text style={styles.text}>🏆 ACHIEVEMENT: {title}</Text>
      </LinearGradient>
    </Animated.View>
  );
}

const styles = StyleSheet.create({
  wrap: {
    position: 'absolute',
    top: 16,
    alignSelf: 'center',
    zIndex: 40,
  },
  pill: {
    borderRadius: 14,
    paddingHorizontal: 20,
    paddingVertical: 10,
    shadowColor: '#6b3fa0',
    shadowOpacity: 0.22,
    shadowRadius: 11,
    shadowOffset: { width: 0, height: 10 },
    elevation: 6,
  },
  text: {
    color: candyColors.ink,
    fontFamily: candyFonts.bodyHeavy,
    fontSize: 12.5,
    letterSpacing: 0.3,
  },
});
