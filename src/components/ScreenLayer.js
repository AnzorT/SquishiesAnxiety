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
// content: once the slide is over (two frames in without a slide). Until
// then it shows its frame and placeholders (src/components/Skeleton.js),
// which are light, so the slide starts on the tap. Building during the slide
// (2026-10-10 to 10-28) made the UI thread create the content's views in the
// middle of it: on the Galaxy A15 a 260 ms slide took 0.6-0.85 s and
// stuttered all the way (debug build, 2026-10-28). Outside a layer it's
// always true.
const SLIDE = { duration: 260, easing: Easing.bezier(0.22, 1, 0.36, 1), useNativeDriver: true };

const ScreenReady = createContext(true);
export const useScreenReady = () => useContext(ScreenReady);

// For a screen that doesn't ask itself: `placeholder` until the layer is
// ready, then a crossfade to the screen.
export function WhenScreenReady({ placeholder, children }) {
  const ready = useScreenReady();
  return (
    <Reveal fill ready={ready} placeholder={placeholder}>
      {ready ? children : null}
    </Reveal>
  );
}

// `ref.exit(then)`: the way back. The layer starts sliding out to the right
// (native, fast at first, like the way in) on the tap, and Home is uncovered
// (`onUncover`: App unfreezes it) in the next JS task, so the slide is
// already running while Home renders. Uncovering it first put Home's render
// (and, for a game screen, the game's own re-render) in front of the slide:
// on Android a native animation only starts once the render it was started
// in has been committed (0.3 s in a debug build, 2026-10-28). `then` runs
// when the slide is over (App switches the screen, and the layer unmounts
// out of sight).
const EXIT = { duration: 280, easing: Easing.bezier(0.22, 1, 0.36, 1), useNativeDriver: true };

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
        if (onUncover) setTimeout(onUncover, 0);
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
