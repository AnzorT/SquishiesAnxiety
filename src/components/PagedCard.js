import React, { useLayoutEffect, useRef } from 'react';
import { Animated, Easing, StyleSheet } from 'react-native';

// The Home carousel's card-swap animation, ported from the decoded
// "ASMR Creature Squash Game.html": the incoming card plays `cardSlideUp` /
// `cardSlideDown` (rise/drop 108% of its own height, scale 0.94 -> 1, fade
// 0.5 -> 1) while a cloned "ghost" of the outgoing card flies off with
// `cardExitUp` / `cardExitDown`. HomeScreen renders one <PagedCard> per page
// keyed by index (so this remounts and replays), plus a <GhostCard> for the
// card that just left.

const DURATION = 400;
// cubic-bezier(0.4, 0, 0.2, 1) ~ Material standard easing
const EASING = Easing.bezier(0.4, 0, 0.2, 1);

export function PagedCard({ direction, cardH, children }) {
  const t = useRef(new Animated.Value(0)).current;

  useLayoutEffect(() => {
    t.setValue(0);
    Animated.timing(t, { toValue: 1, duration: DURATION, easing: EASING, useNativeDriver: true }).start();
  }, [t]);

  const from = (direction >= 0 ? 1 : -1) * cardH * 1.08;
  const translateY = t.interpolate({ inputRange: [0, 1], outputRange: [from, 0] });
  const scale = t.interpolate({ inputRange: [0, 1], outputRange: [0.94, 1] });
  const opacity = t.interpolate({ inputRange: [0, 1], outputRange: [0.5, 1] });

  return (
    <Animated.View style={[styles.fill, { opacity, transform: [{ translateY }, { scale }] }]}>{children}</Animated.View>
  );
}

export function GhostCard({ direction, cardH, onDone, children }) {
  const t = useRef(new Animated.Value(0)).current;

  useLayoutEffect(() => {
    t.setValue(0);
    Animated.timing(t, { toValue: 1, duration: DURATION, easing: EASING, useNativeDriver: true }).start(({ finished }) => {
      if (finished) onDone();
    });
  }, [t, onDone]);

  const to = -(direction >= 0 ? 1 : -1) * cardH * 1.08;
  const translateY = t.interpolate({ inputRange: [0, 1], outputRange: [0, to] });
  const scale = t.interpolate({ inputRange: [0, 1], outputRange: [1, 0.94] });
  const opacity = t.interpolate({ inputRange: [0, 1], outputRange: [1, 0] });

  return (
    <Animated.View pointerEvents="none" style={[styles.fill, styles.ghost, { opacity, transform: [{ translateY }, { scale }] }]}>
      {children}
    </Animated.View>
  );
}

const styles = StyleSheet.create({
  fill: { flex: 1, alignItems: 'center', justifyContent: 'center' },
  ghost: { ...StyleSheet.absoluteFillObject, zIndex: 2 },
});
