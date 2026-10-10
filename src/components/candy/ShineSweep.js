import React, { useEffect, useRef, useState } from 'react';
import { Animated, Easing, StyleSheet, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';

// The design's `shineSweep`: a soft white streak (40% of the width) that
// slides across from -70% to 140% in the first 55% of each cycle, then waits
// off the right edge. Drop it inside anything with overflow hidden.
export default function ShineSweep({ durationMs = 2200, delayMs = 0, strength = 0.75 }) {
  const [w, setW] = useState(0);
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    if (!w) return undefined;
    const loop = Animated.loop(
      Animated.timing(t, {
        toValue: 1,
        duration: durationMs,
        easing: Easing.bezier(0.42, 0, 0.58, 1),
        useNativeDriver: true,
      })
    );
    const start = setTimeout(() => loop.start(), delayMs);
    return () => {
      clearTimeout(start);
      loop.stop();
    };
  }, [t, w, durationMs, delayMs]);
  const translateX = t.interpolate({
    inputRange: [0, 0.55, 1],
    outputRange: [-0.7 * w, 1.4 * w, 1.4 * w],
  });
  return (
    <View pointerEvents="none" style={StyleSheet.absoluteFill} onLayout={(e) => e.nativeEvent.layout.width > 0 && setW(e.nativeEvent.layout.width)}>
      {w ? (
        <Animated.View style={[styles.streak, { width: w * 0.4, transform: [{ translateX }] }]}>
          <LinearGradient
            colors={['rgba(255,255,255,0)', `rgba(255,255,255,${strength})`, 'rgba(255,255,255,0)']}
            start={{ x: 0, y: 0.4 }}
            end={{ x: 1, y: 0.6 }}
            style={StyleSheet.absoluteFill}
          />
        </Animated.View>
      ) : null}
    </View>
  );
}

const styles = StyleSheet.create({
  streak: { position: 'absolute', top: 0, bottom: 0, left: 0 },
});
