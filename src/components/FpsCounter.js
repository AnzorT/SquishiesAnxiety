import React, { useEffect, useRef, useState } from 'react';
import { StyleSheet, Text, View } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { LinearGradient } from 'expo-linear-gradient';
import { F } from '../squad/ui';

// The design's FPS counter ("Squish Squad App v4"): a dark pill in the top
// right corner — a dot (green 50+, yellow 30+, red below), the frames per
// second over the last half second, and the slowest frame as "low". It counts
// JS-thread animation frames, which is what stalls when the app is busy.
// Only for tester accounts (Settings → FPS counter, REDESIGN_V6 ruling 5).
export default function FpsCounter() {
  const insets = useSafeAreaInsets();
  const [m, setM] = useState({ fps: null, low: null });
  const raf = useRef(0);
  useEffect(() => {
    let last = performance.now();
    let t0 = last;
    let n = 0;
    let worst = 0;
    const tick = (now) => {
      const dt = now - last;
      last = now;
      n++;
      if (dt > worst) worst = dt;
      if (now - t0 >= 500) {
        setM({ fps: Math.round((n * 1000) / (now - t0)), low: Math.round(1000 / Math.max(worst, 1)) });
        t0 = now;
        n = 0;
        worst = 0;
      }
      raf.current = requestAnimationFrame(tick);
    };
    raf.current = requestAnimationFrame(tick);
    return () => cancelAnimationFrame(raf.current);
  }, []);
  const c = m.fps == null ? '#7cf0a0' : m.fps >= 50 ? '#7cf0a0' : m.fps >= 30 ? '#ffd83a' : '#ff6a82';
  return (
    <View pointerEvents="none" style={[styles.wrap, { top: insets.top + 6 }]}>
      <LinearGradient colors={['#5a2aa8', '#2a0b47']} style={styles.pill}>
        <View style={[styles.dot, { backgroundColor: c, shadowColor: c }]} />
        <Text style={styles.num}>{m.fps == null ? '--' : m.fps}</Text>
        <Text style={styles.unit}>FPS</Text>
        {m.low != null && <Text style={styles.low}>{`low ${m.low}`}</Text>}
      </LinearGradient>
    </View>
  );
}

const styles = StyleSheet.create({
  wrap: { position: 'absolute', right: 10, zIndex: 210, elevation: 30, borderRadius: 999, backgroundColor: '#1c0a38', paddingBottom: 3 },
  pill: { flexDirection: 'row', alignItems: 'center', gap: 6, paddingVertical: 4, paddingLeft: 8, paddingRight: 11, borderRadius: 999, borderWidth: 2.5, borderColor: '#ffffff' },
  dot: { width: 10, height: 10, borderRadius: 5, elevation: 4 },
  num: { minWidth: 22, textAlign: 'right', fontFamily: F.display, fontSize: 16, color: '#ffffff', includeFontPadding: false },
  unit: { fontFamily: F.display, fontSize: 10.5, letterSpacing: 0.5, color: 'rgba(255,255,255,0.85)' },
  low: { fontFamily: F.heavy, fontSize: 10, color: '#d9c4f7' },
});
