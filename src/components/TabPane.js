import React, { memo, useEffect, useRef } from 'react';
import { Animated, Easing, StyleSheet } from 'react-native';

// A tab's content kept alive once it has been shown: while another tab is
// up it stays mounted but hidden (display: none) and doesn't re-render, so
// switching back is one render instead of building the whole tab again
// (the Shop's Chests / Squishies / Gems, the Squishies screen's Collection /
// Star Shop and Squishies / My creations).
//
//   const seen = useSeenTabs(tab);
//   {seen.has('gems') && <TabPane active={tab === 'gems'}><GemsTab … /></TabPane>}
// The first time a tab is opened its content fades in (0 → 100%) rather
// than popping in.
export const TabPane = memo(
  function TabPane({ active, children }) {
    const t = useRef(new Animated.Value(0)).current;
    useEffect(() => {
      Animated.timing(t, { toValue: 1, duration: 280, easing: Easing.out(Easing.quad), useNativeDriver: true }).start();
    }, [t]);
    return <Animated.View style={[active ? null : styles.hidden, { opacity: t }]}>{children}</Animated.View>;
  },
  // hidden before and after: nothing to draw, so skip the render
  (prev, next) => !prev.active && !next.active,
);

// The tabs shown so far (the current one included).
export function useSeenTabs(current) {
  const seen = useRef(new Set()).current;
  seen.add(current);
  return seen;
}

const styles = StyleSheet.create({
  hidden: { display: 'none' },
});
