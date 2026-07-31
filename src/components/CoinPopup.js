import React, { useEffect, useRef } from 'react';
import { Animated, StyleSheet } from 'react-native';
import { colors } from '../theme/tokens';

// One "+N⊙" that rises from the touch point and fades out. SquishScreen
// spawns one of these per coin-earning event and unmounts it via onDone
// once the animation finishes.
export default function CoinPopup({ x, y, amount, onDone }) {
  const translateY = useRef(new Animated.Value(0)).current;
  const opacity = useRef(new Animated.Value(1)).current;
  const scale = useRef(new Animated.Value(0.5)).current;

  useEffect(() => {
    Animated.parallel([
      Animated.spring(scale, { toValue: 1, friction: 4, useNativeDriver: true }),
      Animated.timing(translateY, { toValue: -64, duration: 700, useNativeDriver: true }),
      Animated.timing(opacity, { toValue: 0, duration: 450, delay: 250, useNativeDriver: true }),
    ]).start(({ finished }) => {
      if (finished) onDone();
    });
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  return (
    <Animated.Text
      style={[
        styles.text,
        {
          left: x - 20,
          top: y - 12,
          opacity,
          transform: [{ translateY }, { scale }],
        },
      ]}
    >
      +{amount}⊙
    </Animated.Text>
  );
}

const styles = StyleSheet.create({
  text: {
    position: 'absolute',
    fontSize: 20,
    fontWeight: '800',
    color: colors.coinGold,
    // Shine highlight sits above the glyph (negative offset) rather than
    // below, like light catching the top of a coin.
    textShadowColor: colors.coinGoldShine,
    textShadowRadius: 2,
    textShadowOffset: { width: 0, height: -1 },
  },
});
