import React, { useEffect, useRef } from 'react';
import { Pressable, Text, StyleSheet, Animated, Easing, ActivityIndicator } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { squadFonts } from '../../theme/squadTheme';

// Pill CTA shared by every "Squish Squad" screen — the prototype draws this
// exact shape (gradient fill pill, Baloo 2 bold label, colored glow shadow)
// for TAP TO START, ENTER THE SQUAD, BUY, SAVE, SUBMIT, LOG OUT, etc., only
// ever changing the gradient/label/size, so one component covers all of them
// instead of restyling a Pressable per screen.
export default function GradientButton({
  label,
  onPress,
  disabled = false,
  loading = false,
  colors,
  start = { x: 0, y: 0 },
  end = { x: 1, y: 1 },
  textColor = '#0d0620',
  shadowColor,
  pulse = false,
  fontSize = 17,
  style,
  pillStyle,
  textStyle,
}) {
  const pulseAnim = useRef(new Animated.Value(0)).current;

  useEffect(() => {
    if (!pulse) return undefined;
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(pulseAnim, { toValue: 1, duration: 800, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
        Animated.timing(pulseAnim, { toValue: 0, duration: 800, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
      ])
    );
    loop.start();
    return () => loop.stop();
  }, [pulse, pulseAnim]);

  const scale = pulseAnim.interpolate({ inputRange: [0, 1], outputRange: [1, 1.05] });

  return (
    <Animated.View style={pulse ? { transform: [{ scale }] } : undefined}>
      <Pressable onPress={onPress} disabled={disabled || loading} style={style}>
        <LinearGradient
          colors={disabled ? ['#2f2450', '#2f2450'] : colors}
          start={start}
          end={end}
          style={[
            styles.pill,
            shadowColor && !disabled ? { shadowColor, shadowOpacity: 0.5, shadowRadius: 16, shadowOffset: { width: 0, height: 8 }, elevation: 8 } : null,
            pillStyle,
          ]}
        >
          {loading ? (
            <ActivityIndicator color={textColor} />
          ) : (
            <Text style={[styles.label, { color: disabled ? '#7a6ba0' : textColor, fontSize }, textStyle]}>{label}</Text>
          )}
        </LinearGradient>
      </Pressable>
    </Animated.View>
  );
}

const styles = StyleSheet.create({
  pill: {
    borderRadius: 999,
    paddingVertical: 16,
    paddingHorizontal: 32,
    alignItems: 'center',
    justifyContent: 'center',
  },
  label: {
    fontFamily: squadFonts.headingBold,
    letterSpacing: 1,
  },
});
