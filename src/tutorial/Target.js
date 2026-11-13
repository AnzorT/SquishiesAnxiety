import React, { useCallback, useEffect, useRef } from 'react';
import { View } from 'react-native';
import { currentTarget, registerTarget, unregisterTarget, measureTarget } from './store';

// Marks a view the tutorial can point at (the design's `data-tut="…"`):
//   <TutTarget name="box"> <MysteryBoxBanner … /> </TutTarget>
// A plain wrapper View; pass `style` to keep the parent's layout (flex: 1,
// alignSelf…). The Guide measures it in window coordinates whenever a step
// targets it. Inside a hosted guide (the Crib's), `host` converts those to
// the host's own coordinates — see registerTarget in store.js.
export default function TutTarget({ name, style, pointerEvents, host = null, children }) {
  const ref = useRef(null);
  useEffect(() => {
    registerTarget(name, ref, host);
    return () => unregisterTarget(name, ref);
  }, [name, host]);
  // only the target the guide points at is measured (the Guide also polls
  // it); measuring every target on every layout cost a native round trip
  // each, for nothing
  const onLayout = useCallback(() => {
    if (currentTarget() === name) measureTarget(name);
  }, [name]);
  return (
    <View ref={ref} collapsable={false} style={style} pointerEvents={pointerEvents} onLayout={onLayout}>
      {children}
    </View>
  );
}
