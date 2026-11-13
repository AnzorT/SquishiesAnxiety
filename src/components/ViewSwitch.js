import React, { useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { Animated } from 'react-native';
import { Reveal, ViewBones } from './Skeleton';
import Freeze from './Freeze';

// The mini-games' views (hub, level map, a level, Blitz): a switch answers
// on the tap's own frame. The new view slides in at once with placeholders
// in its shape (ViewBones), and its real content is built two frames later,
// then fades in (Reveal). It used to be built in the same render as the
// switch, and on Android a native animation only starts once the render it
// was started in has been committed: the level map held its own slide (and
// every frame) for 0.75 s in a debug build, then 0.8 s more while the UI
// thread made its views (2026-10-28).
const SPRING = { toValue: 1, friction: 8, tension: 70, useNativeDriver: true };

export function useViewSwitch(initial) {
  const slide = useRef(new Animated.Value(1)).current;
  const [view, setView] = useState(initial);
  const [built, setBuilt] = useState(initial);
  const go = useCallback(
    (next) => {
      slide.setValue(0);
      Animated.spring(slide, SPRING).start();
      setView(next);
    },
    [slide],
  );
  useEffect(() => {
    if (built === view) return undefined;
    let second = null;
    const first = requestAnimationFrame(() => {
      second = requestAnimationFrame(() => setBuilt(view));
    });
    return () => {
      cancelAnimationFrame(first);
      if (second != null) cancelAnimationFrame(second);
    };
  }, [view, built]);
  const style = useMemo(
    () => ({
      opacity: slide.interpolate({ inputRange: [0, 0.4, 1], outputRange: [0, 1, 1] }),
      transform: [{ translateX: slide.interpolate({ inputRange: [0, 1], outputRange: [60, 0] }) }],
    }),
    [slide],
  );
  return { view, ready: built === view, go, style };
}

// One view's slot: its placeholder (`bones`: a ViewBones kind) until it's
// built, then the content fading in. Keyed by the view, so every switch
// starts from the placeholder again.
export function ViewSlot({ sw, bones, children }) {
  return (
    <Reveal key={sw.view} fill ready={sw.ready} placeholder={<ViewBones kind={bones} />}>
      {sw.ready ? children : null}
    </Reveal>
  );
}

// The view `name` (a level map), built like a ViewSlot the first time, then
// kept, asleep (Freeze), while `keepWhile` holds (a level opened from it is
// up), so coming back to it is instant instead of a rebuild. Dropped when
// the switch goes anywhere else.
export function KeptView({ sw, name, keepWhile, bones, children }) {
  const on = sw.view === name;
  const [kept, setKept] = useState(false);
  const ready = kept || (on && sw.ready);
  useEffect(() => {
    if (on && sw.ready) setKept(true);
    else if (!on && !keepWhile) setKept(false);
  }, [on, sw.ready, keepWhile]);
  if (!on && !kept) return null;
  return (
    <Freeze freeze={!on}>
      <Reveal fill ready={ready} placeholder={<ViewBones kind={bones} />}>
        {ready ? children : null}
      </Reveal>
    </Freeze>
  );
}
