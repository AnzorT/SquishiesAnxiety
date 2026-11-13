import React, { memo, useEffect, useRef } from 'react';
import { Animated, StyleSheet, View } from 'react-native';
import Svg, { Path } from 'react-native-svg';

// A mini-game's hearts (Squish Sort, Squishdoku from level 46): `on` is
// full; when it goes out the heart pops and greys. One pop, not a loop.
const HEART_D = 'M12 21 C5 15.5 2 12 2 7.8 C2 4.6 4.4 2.5 7.2 2.5 C9.2 2.5 11 3.6 12 5.4 C13 3.6 14.8 2.5 16.8 2.5 C19.6 2.5 22 4.6 22 7.8 C22 12 19 15.5 12 21 Z';

export const Heart = memo(function Heart({ on, size = 24, empty = 'rgba(69,16,122,0.22)' }) {
  const t = useRef(new Animated.Value(on ? 1 : 0)).current;
  useEffect(() => {
    if (on) t.setValue(1);
    else Animated.sequence([Animated.timing(t, { toValue: 1.6, duration: 120, useNativeDriver: true }), Animated.spring(t, { toValue: 0, friction: 5, tension: 120, useNativeDriver: true })]).start();
  }, [on, t]);
  return (
    <View style={{ width: size, height: size }}>
      <Svg width={size} height={size} viewBox="0 0 24 24" style={StyleSheet.absoluteFill}>
        <Path d={HEART_D} fill={empty} stroke="#ffffff" strokeWidth={2} />
      </Svg>
      <Animated.View style={[StyleSheet.absoluteFill, { opacity: t.interpolate({ inputRange: [0, 0.3, 1.6], outputRange: [0, 1, 1], extrapolate: 'clamp' }), transform: [{ scale: t.interpolate({ inputRange: [0, 1, 1.6], outputRange: [0.4, 1, 1.35], extrapolate: 'clamp' }) }] }]}>
        <Svg width={size} height={size} viewBox="0 0 24 24">
          <Path d={HEART_D} fill="#ff4d7d" stroke="#ffffff" strokeWidth={2} />
          <Path d="M6.5 7 C7 5.6 8.2 5 9.2 5.2" stroke="#ffd6e4" strokeWidth={1.6} strokeLinecap="round" fill="none" />
        </Svg>
      </Animated.View>
    </View>
  );
});
