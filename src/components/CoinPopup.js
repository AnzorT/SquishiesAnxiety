import React, { useEffect, useRef } from 'react';
import { Animated, StyleSheet, Easing } from 'react-native';
import { colors } from '../theme/tokens';

// One "+N [coin]" that rises from the touch point and fades out. SquishScreen
// spawns one of these per coin-earning event and unmounts it via onDone
// once the animation finishes. The coin is the same round gold dot used in
// the header pills (HomeScreen/SquishScreen's coinPillDot), not the "⊙"
// text glyph this used to render, so the popup matches the rest of the
// app's coin icon instead of introducing a second one.
export default function CoinPopup({ x, y, amount, onDone }) {
  const translateY = useRef(new Animated.Value(0)).current;
  const opacity = useRef(new Animated.Value(1)).current;
  const scale = useRef(new Animated.Value(0.5)).current;
  const spin = useRef(new Animated.Value(0)).current;

  useEffect(() => {
    Animated.parallel([
      Animated.spring(scale, { toValue: 1, friction: 4, useNativeDriver: true }),
      Animated.timing(translateY, { toValue: -64, duration: 700, useNativeDriver: true }),
      Animated.timing(opacity, { toValue: 0, duration: 450, delay: 250, useNativeDriver: true }),
      // A few full turns over the popup's whole lifetime — paired with
      // `perspective` below so the flat coin dot reads as tumbling rather
      // than just stretching in place.
      Animated.timing(spin, { toValue: 1, duration: 700, easing: Easing.linear, useNativeDriver: true }),
    ]).start(({ finished }) => {
      if (finished) onDone();
    });
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const coinSpin = spin.interpolate({ inputRange: [0, 1], outputRange: ['0deg', '160deg'] });

  return (
    <Animated.View
      style={[
        styles.wrap,
        {
          left: x - 26,
          top: y - 12,
          opacity,
          transform: [{ translateY }, { scale }],
        },
      ]}
    >
      <Animated.Text style={styles.text}>+{amount}</Animated.Text>
      <Animated.View style={[styles.coinDot, { transform: [{ perspective: 300 }, { rotateY: coinSpin }] }]} />
    </Animated.View>
  );
}

const styles = StyleSheet.create({
  wrap: {
    position: 'absolute',
    flexDirection: 'row',
    alignItems: 'center',
    gap: 3,
  },
  text: {
    fontSize: 20,
    fontWeight: '800',
    color: colors.coinGold,
    // Shine highlight sits above the glyph (negative offset) rather than
    // below, like light catching the top of a coin.
    textShadowColor: colors.coinGoldShine,
    textShadowRadius: 2,
    textShadowOffset: { width: 0, height: -1 },
  },
  coinDot: {
    width: 16,
    height: 16,
    borderRadius: 8,
    backgroundColor: colors.coinGold,
    borderWidth: 2,
    borderColor: colors.coinGoldDeep,
  },
});
