import React, { createContext, forwardRef, useContext, useEffect, useImperativeHandle, useRef, useState } from 'react';
import { Animated, Easing, StyleSheet, useWindowDimensions } from 'react-native';
import { Reveal } from './Skeleton';

// A screen opened over Home (Crib, Achievements, Stats, Create, Streak, the
// loading screen, the squish screen…). Home stays mounted underneath, so
// going back is instant; App freezes it once this layer covers the screen
// (`onCovered`), so it doesn't draw or re-render while hidden.
//
// `slide`: comes in from the right (fast at first, so it reads as an instant
// answer to the tap). Without it, it's simply there and covers Home at once.
//
// `useScreenReady()` tells the screen inside when to build its heavy
// content: once the slide is over (or a couple of frames in, without one).
// Until then it shows its frame and placeholders (src/components/Skeleton.js),
// so the slide starts on the tap's frame and never stutters under a big
// mount. Outside a layer it's always true.
const SLIDE = { duration: 260, easing: Easing.bezier(0.22, 1, 0.36, 1), useNativeDriver: true };

const ScreenReady = createContext(true);
export const useScreenReady = () => useContext(ScreenReady);

// For a screen that doesn't ask itself: `placeholder` until the layer is
// ready, then a crossfade to the screen.
export function WhenScreenReady({ placeholder, children }) {
  return (
    <Reveal fill ready={useScreenReady()} placeholder={placeholder}>
      {children}
    </Reveal>
  );
}

// `ref.exit(then)`: the way back. The layer slides out to the right at once
// (native), Home is uncovered under it a frame later (`onUncover`: App
// unfreezes it, so it's there as the layer moves away), and `then` runs when
// the slide is over (App switches the screen, and the layer unmounts out of
// sight). Going back used to wait for Home's re-render and the screen's
// teardown before anything moved.
// slow at first, so the screen under it has a moment to draw before most of
// it is uncovered
const EXIT = { duration: 380, easing: Easing.bezier(0.55, 0, 0.75, 1), useNativeDriver: true };

function ScreenLayer({ slide, onCovered, onUncover, children }, ref) {
  const { width } = useWindowDimensions();
  const x = useRef(new Animated.Value(slide ? 1 : 0)).current;
  const [ready, setReady] = useState(false);
  useEffect(() => {
    if (!slide) {
      onCovered();
      let second = null;
      const first = requestAnimationFrame(() => {
        second = requestAnimationFrame(() => setReady(true));
      });
      return () => {
        cancelAnimationFrame(first);
        if (second != null) cancelAnimationFrame(second);
      };
    }
    const anim = Animated.timing(x, { toValue: 0, ...SLIDE });
    // only when it really got there: a layer closed mid-slide must not
    // freeze the Home it was leaving for
    anim.start(({ finished }) => {
      if (!finished) return;
      onCovered();
      setReady(true);
    });
    return () => anim.stop();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);
  const exiting = useRef(false);
  useImperativeHandle(
    ref,
    () => ({
      exit(then) {
        if (exiting.current) return;
        exiting.current = true;
        Animated.timing(x, { toValue: 1, ...EXIT }).start(() => then());
        // after the slide's start has reached the native side
        if (onUncover) requestAnimationFrame(() => onUncover());
      },
    }),
    // eslint-disable-next-line react-hooks/exhaustive-deps
    [],
  );
  const translateX = x.interpolate({ inputRange: [0, 1], outputRange: [0, width] });
  // (no zIndex/elevation: it sits above Home by order in App's tree, and
  // App's toasts, sheets and tutorial guide come after it)
  return (
    <Animated.View style={[StyleSheet.absoluteFill, { transform: [{ translateX }] }]}>
      <ScreenReady.Provider value={ready}>{children}</ScreenReady.Provider>
    </Animated.View>
  );
}

export default forwardRef(ScreenLayer);
