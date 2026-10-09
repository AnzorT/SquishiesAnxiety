import React, { useEffect, useRef } from 'react';
import { Animated, Easing, StyleSheet, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { BUTTON_VARIANTS } from '../../theme/candyTheme';
import { Shine } from './CandyButton';

// Three candy balls hopping in turn: the "something's loading" dots of the
// creature loading screen (LoadingScreen's "Getting Ready"), also used in
// the Log in / Register button while it waits on the server. Each ball is
// the candy buttons' look (dark ring, white rim, glossy gradient face, a lip
// underneath) at dot size, on the design's dotBounce cycle (up by 40% of
// 1 s, down by 80%, brighter at the top), squashing a little as it lands.
// All native-driver, so the hop stays smooth while JS is busy.
const hopIn = [0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.85, 0.92, 1];
const hopUp = [0, 0.44, 0.75, 0.94, 1, 0.94, 0.75, 0.44, 0, 0, 0, 0];

function Dot({ delay, variant, size, hop }) {
  const v = BUTTON_VARIANTS[variant];
  const p = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const anim = Animated.sequence([
      Animated.delay(delay),
      Animated.loop(Animated.timing(p, { toValue: 1, duration: 1000, easing: Easing.linear, useNativeDriver: true })),
    ]);
    anim.start();
    return () => anim.stop();
  }, [p, delay]);
  const translateY = p.interpolate({ inputRange: hopIn, outputRange: hopUp.map((f) => -f * hop) });
  const scaleX = p.interpolate({ inputRange: [0, 0.8, 0.85, 0.92, 1], outputRange: [1, 1, 1.18, 1, 1] });
  const scaleY = p.interpolate({ inputRange: [0, 0.8, 0.85, 0.92, 1], outputRange: [1, 1, 0.8, 1, 1] });
  const opacity = p.interpolate({ inputRange: [0, 0.4, 0.8, 1], outputRange: [0.65, 1, 0.65, 0.65] });
  const round = { width: size, height: size, borderRadius: size / 2 };
  const ring = Math.max(1, size / 12);
  return (
    <Animated.View style={{ width: size, height: size + 2, opacity, transform: [{ translateY }, { scaleX }, { scaleY }] }}>
      <View style={[styles.lip, round, { backgroundColor: v.ring }]} />
      <View style={[round, { backgroundColor: v.ring, padding: ring }]}>
        <View style={[styles.fill, { borderRadius: size / 2, backgroundColor: '#ffffff', padding: ring }]}>
          <LinearGradient colors={v.colors} locations={v.locations} style={[styles.fill, { borderRadius: size / 2, overflow: 'hidden' }]}>
            <Shine />
          </LinearGradient>
        </View>
      </View>
    </Animated.View>
  );
}

// `size`: each ball's diameter; the row keeps room above for the hop (half
// a ball), so it doesn't grow while they jump.
export default function HopDots({ size = 18, gap = 5, style }) {
  const hop = size / 2;
  return (
    <View style={[styles.row, { gap, paddingTop: hop }, style]}>
      <Dot delay={0} variant="pink" size={size} hop={hop} />
      <Dot delay={150} variant="gold" size={size} hop={hop} />
      <Dot delay={300} variant="blue" size={size} hop={hop} />
    </View>
  );
}

const styles = StyleSheet.create({
  row: { flexDirection: 'row' },
  lip: { position: 'absolute', top: 2, left: 0 },
  fill: { flex: 1 },
});
