import React, { memo, useEffect, useRef } from 'react';
import { Animated, Easing, StyleSheet, Text, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { Head } from './ui';
import { F, INK } from './theme';

// The game's HUD pieces: the three score creatures, the timer bar (with the
// creatures that fall off it as times A and B pass) and Blitz's pips.

// The three score creatures. `left` of them are still on offer; the others
// tumble off (down, spinning, fading). While a PERFECT run is still
// possible they sit in a gold glow.
export const ScoreRow = memo(function ScoreRow({ uris, left, perfect, size = 46 }) {
  const out = useRef([0, 1, 2].map(() => new Animated.Value(0))).current;
  const glow = useRef(new Animated.Value(0)).current;
  const pop = useRef([0, 1, 2].map(() => new Animated.Value(0))).current;
  useEffect(() => {
    // a new level: everyone pops back in, one after another
    out.forEach((v) => v.setValue(0));
    pop.forEach((v, i) => {
      v.setValue(0);
      Animated.spring(v, { toValue: 1, friction: 4.5, tension: 160, delay: 120 + i * 110, useNativeDriver: true }).start();
    });
  }, [uris, out, pop]);
  useEffect(() => {
    out.forEach((v, i) => {
      const gone = i >= left;
      Animated.timing(v, { toValue: gone ? 1 : 0, duration: gone ? 650 : 250, easing: gone ? Easing.in(Easing.quad) : Easing.out(Easing.quad), useNativeDriver: true }).start();
    });
  }, [left, out]);
  useEffect(() => {
    if (!perfect) {
      Animated.timing(glow, { toValue: 0, duration: 300, useNativeDriver: true }).start();
      return undefined;
    }
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(glow, { toValue: 1, duration: 700, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
        Animated.timing(glow, { toValue: 0.45, duration: 700, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
      ]),
    );
    loop.start();
    return () => loop.stop();
  }, [perfect, glow]);
  return (
    <View style={styles.scoreRow}>
      <Animated.View pointerEvents="none" style={[styles.glow, { opacity: glow, transform: [{ scaleX: glow.interpolate({ inputRange: [0, 1], outputRange: [0.9, 1.05] }) }] }]}>
        <LinearGradient colors={['rgba(255,226,92,0)', 'rgba(255,226,92,0.85)', 'rgba(255,226,92,0)']} start={{ x: 0, y: 0.5 }} end={{ x: 1, y: 0.5 }} style={StyleSheet.absoluteFill} />
      </Animated.View>
      {[0, 1, 2].map((i) => {
        const v = out[i];
        const big = i === 1 ? 1.15 : 1;
        return (
          <View key={i} style={{ width: size * big + 6, height: size * big + 6, alignItems: 'center', justifyContent: 'center' }}>
            <Head uri={uris[i]} size={size * big} dim style={styles.ghost} ring="rgba(255,255,255,0.55)" bg="rgba(255,255,255,0.35)" />
            <Animated.View
              style={{
                position: 'absolute',
                opacity: v.interpolate({ inputRange: [0, 0.7, 1], outputRange: [1, 1, 0] }),
                transform: [
                  { translateY: v.interpolate({ inputRange: [0, 0.25, 1], outputRange: [0, -14, 70] }) },
                  { rotate: v.interpolate({ inputRange: [0, 1], outputRange: ['0deg', i === 0 ? '-50deg' : '50deg'] }) },
                  { scale: Animated.multiply(pop[i], v.interpolate({ inputRange: [0, 1], outputRange: [1, 0.6] })) },
                ],
              }}
            >
              <Head uri={uris[i]} size={size * big} ring={perfect ? '#ffd23a' : '#ffffff'} />
            </Animated.View>
          </View>
        );
      })}
    </View>
  );
});

// The timer bar: `frac` (Animated, 1 → 0) is the time left. The fill turns
// yellow then red as it runs down; `markers` ({ at, uri, gone }, `at` the
// time-left fraction) are the creatures riding on it, dropped as the fill
// passes them. `warn` pulses it red (the last seconds).
export const TimerBar = memo(function TimerBar({ frac, width, markers = [], warn = false, label }) {
  const pulse = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    if (!warn) {
      pulse.setValue(0);
      return undefined;
    }
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(pulse, { toValue: 1, duration: 250, useNativeDriver: true }),
        Animated.timing(pulse, { toValue: 0, duration: 250, useNativeDriver: true }),
      ]),
    );
    loop.start();
    return () => loop.stop();
  }, [warn, pulse]);
  const inner = width - 6; // inside the track's 3px border
  const shift = frac.interpolate({ inputRange: [0, 1], outputRange: [-inner, 0], extrapolate: 'clamp' });
  const yellow = frac.interpolate({ inputRange: [0.2, 0.45], outputRange: [1, 0], extrapolate: 'clamp' });
  const red = frac.interpolate({ inputRange: [0.06, 0.2], outputRange: [1, 0], extrapolate: 'clamp' });
  return (
    <Animated.View style={[styles.barWrap, { width, transform: [{ scale: pulse.interpolate({ inputRange: [0, 1], outputRange: [1, 1.04] }) }] }]}>
      <View style={styles.barTrack}>
        <Animated.View style={[StyleSheet.absoluteFill, { transform: [{ translateX: shift }] }]}>
          <LinearGradient colors={['#b8ffd9', '#3ddc97']} style={StyleSheet.absoluteFill} />
          <Animated.View style={[StyleSheet.absoluteFill, { opacity: yellow }]}>
            <LinearGradient colors={['#fff3a0', '#ffc233']} style={StyleSheet.absoluteFill} />
          </Animated.View>
          <Animated.View style={[StyleSheet.absoluteFill, { opacity: red }]}>
            <LinearGradient colors={['#ffb3c0', '#ff4d6d']} style={StyleSheet.absoluteFill} />
          </Animated.View>
          <View style={styles.barShine} />
        </Animated.View>
        <Animated.View pointerEvents="none" style={[StyleSheet.absoluteFill, styles.barWarn, { opacity: pulse }]} />
      </View>
      {markers.map((m, i) => (
        <Marker key={i} x={3 + inner * m.at} uri={m.uri} gone={m.gone} />
      ))}
      {label ? (
        <View pointerEvents="none" style={styles.barLabelWrap}>
          <Text style={[styles.barLabel, warn && { color: '#c4002b' }]}>{label}</Text>
        </View>
      ) : null}
    </Animated.View>
  );
});

const Marker = memo(function Marker({ x, uri, gone }) {
  const v = useRef(new Animated.Value(gone ? 1 : 0)).current;
  useEffect(() => {
    Animated.timing(v, { toValue: gone ? 1 : 0, duration: gone ? 600 : 200, easing: Easing.in(Easing.quad), useNativeDriver: true }).start();
  }, [gone, v]);
  return (
    <Animated.View
      pointerEvents="none"
      style={[
        styles.marker,
        {
          left: x - 13,
          opacity: v.interpolate({ inputRange: [0, 0.8, 1], outputRange: [1, 1, 0] }),
          transform: [
            { translateY: v.interpolate({ inputRange: [0, 0.2, 1], outputRange: [0, -10, 50] }) },
            { rotate: v.interpolate({ inputRange: [0, 1], outputRange: ['0deg', '120deg'] }) },
          ],
        },
      ]}
    >
      <View style={styles.markerPin} />
      <Head uri={uri} size={26} />
    </Animated.View>
  );
});

// Blitz's ten pips: done ones filled (each popping as it fills), the
// current one pulsing. `drain` empties them right to left (back to level 1).
export const Pips = memo(function Pips({ count = 10, done, current }) {
  const vals = useRef(Array.from({ length: count }, () => new Animated.Value(0))).current;
  const now = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    vals.forEach((v, i) => {
      const on = i < done;
      Animated.spring(v, { toValue: on ? 1 : 0, friction: on ? 4 : 7, tension: 180, delay: on ? 0 : (count - i) * 50, useNativeDriver: true }).start();
    });
  }, [done, vals, count]);
  useEffect(() => {
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(now, { toValue: 1, duration: 500, useNativeDriver: true }),
        Animated.timing(now, { toValue: 0, duration: 500, useNativeDriver: true }),
      ]),
    );
    loop.start();
    return () => loop.stop();
  }, [now]);
  return (
    <View style={styles.pips}>
      {vals.map((v, i) => (
        <View key={i} style={styles.pip}>
          <Animated.View style={[StyleSheet.absoluteFill, styles.pipFill, { opacity: v, transform: [{ scale: v.interpolate({ inputRange: [0, 1], outputRange: [0.3, 1] }) }] }]} />
          {i === current ? <Animated.View style={[StyleSheet.absoluteFill, styles.pipNow, { opacity: now }]} /> : null}
          <Text style={styles.pipText}>{i + 1}</Text>
        </View>
      ))}
    </View>
  );
});

const styles = StyleSheet.create({
  scoreRow: { flexDirection: 'row', alignItems: 'center', justifyContent: 'center', gap: 4 },
  glow: { position: 'absolute', left: -20, right: -20, top: 6, bottom: 6, borderRadius: 999, overflow: 'hidden' },
  ghost: { position: 'absolute' },
  barWrap: { height: 34, justifyContent: 'center' },
  barTrack: { height: 22, borderRadius: 999, borderWidth: 3, borderColor: '#ffffff', backgroundColor: 'rgba(69,16,122,0.28)', overflow: 'hidden' },
  barShine: { position: 'absolute', left: 6, right: 6, top: 2, height: 5, borderRadius: 9, backgroundColor: 'rgba(255,255,255,0.55)' },
  barWarn: { backgroundColor: 'rgba(255,40,80,0.35)' },
  barLabelWrap: { ...StyleSheet.absoluteFillObject, alignItems: 'center', justifyContent: 'center' },
  barLabel: { fontFamily: F.display, fontSize: 13.5, color: INK, includeFontPadding: false },
  marker: { position: 'absolute', top: -20, alignItems: 'center' },
  markerPin: { position: 'absolute', bottom: -8, width: 3, height: 12, borderRadius: 2, backgroundColor: '#ffffff' },
  pips: { flexDirection: 'row', gap: 5, justifyContent: 'center' },
  pip: { width: 24, height: 24, borderRadius: 12, borderWidth: 2.5, borderColor: '#ffffff', backgroundColor: 'rgba(69,16,122,0.25)', alignItems: 'center', justifyContent: 'center', overflow: 'hidden' },
  pipFill: { backgroundColor: '#3fd7f6', borderRadius: 12 },
  pipNow: { backgroundColor: '#ffd23a', borderRadius: 12 },
  pipText: { fontFamily: F.display, fontSize: 10.5, color: '#ffffff', includeFontPadding: false },
});
