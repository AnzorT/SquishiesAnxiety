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
// content: two frames in, once the slide is already running (it runs on the
// native side, so the build doesn't hold it up). Until then it shows its
// frame and placeholders (src/components/Skeleton.js). It used to wait for
// the end of the slide, which put the whole slide in front of every build:
// the content showed up 0.3-0.6 s later than it had to (measured
// 2026-10-10). Outside a layer it's always true.
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

// `ref.exit(then)`: the way back. Home is uncovered first (`onUncover`: App
// unfreezes it in the same render, so it's drawn under the layer in the
// same frame the layer starts to move), the layer slides out to the right
// (native, fast at first, like the way in), and `then` runs when the slide
// is over (App switches the screen, and the layer unmounts out of sight).
// The slide used to start slow (an ease-in over 380 ms, so Home had time to
// draw), which read as the back button not reacting.
const EXIT = { duration: 280, easing: Easing.bezier(0.22, 1, 0.36, 1), useNativeDriver: true };

function ScreenLayer({ slide, onCovered, onUncover, children }, ref) {
  const { width } = useWindowDimensions();
  const x = useRef(new Animated.Value(slide ? 1 : 0)).current;
  const [ready, setReady] = useState(false);
  useEffect(() => {
    let second = null;
    const first = requestAnimationFrame(() => {
      second = requestAnimationFrame(() => setReady(true));
    });
    const stopReady = () => {
      cancelAnimationFrame(first);
      if (second != null) cancelAnimationFrame(second);
    };
    if (!slide) {
      onCovered();
      return stopReady;
    }
    const anim = Animated.timing(x, { toValue: 0, ...SLIDE });
    // only when it really got there: a layer closed mid-slide must not
    // freeze the Home it was leaving for
    anim.start(({ finished }) => finished && onCovered());
    return () => {
      stopReady();
      anim.stop();
    };
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);
  const exiting = useRef(false);
  useImperativeHandle(
    ref,
    () => ({
      exit(then) {
        if (exiting.current) return;
        exiting.current = true;
        if (onUncover) onUncover();
        Animated.timing(x, { toValue: 1, ...EXIT }).start(() => then());
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
