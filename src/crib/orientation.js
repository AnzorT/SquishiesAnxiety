import React, { useCallback, useState, useSyncExternalStore } from 'react';
import { StyleSheet, View } from 'react-native';
import { SafeAreaInsetsContext } from 'react-native-safe-area-context';

// Whether the Crib is on screen in landscape. The landscape Crib is a view
// turned a quarter clockwise (the phone itself stays portrait), so anything
// App.js draws over it — the achievement banner, the little toasts — has to
// turn with it, or it slides in from the side. CribScreen sets this;
// <TurnWithCrib> reads it.

let landscape = false;
const subs = new Set();
export function setCribLandscape(on) {
  if (landscape === !!on) return;
  landscape = !!on;
  subs.forEach((f) => f());
}
const subscribe = (f) => {
  subs.add(f);
  return () => subs.delete(f);
};
export const useCribLandscape = () => useSyncExternalStore(subscribe, () => landscape);

const ZERO_INSETS = { top: 0, bottom: 0, left: 0, right: 0 };

// Lays its children over the whole screen; while the Crib is landscape,
// over the Crib's turned screen instead, so "top" is the Crib's top.
export function TurnWithCrib({ children }) {
  const on = useCribLandscape();
  const [box, setBox] = useState(null);
  const onLayout = useCallback((e) => {
    const { width, height } = e.nativeEvent.layout;
    setBox((b) => (b && b.width === width && b.height === height ? b : { width, height }));
  }, []);
  const W = box ? box.width : 0;
  const H = box ? box.height : 0;
  return (
    <View pointerEvents="box-none" style={StyleSheet.absoluteFill} onLayout={onLayout}>
      {on && box ? (
        <View pointerEvents="box-none" style={{ position: 'absolute', left: (W - H) / 2, top: (H - W) / 2, width: H, height: W, transform: [{ rotate: '90deg' }] }}>
          <SafeAreaInsetsContext.Provider value={ZERO_INSETS}>{children}</SafeAreaInsetsContext.Provider>
        </View>
      ) : (
        children
      )}
    </View>
  );
}
