import { createContext, useContext, useEffect, useMemo, useRef } from 'react';
import { Animated, Easing, Platform } from 'react-native';

// Idle motion that loops forever (a bob, a twinkle, a pulse) as ONE native
// animation: a linear phase 0 → 1 repeated on the UI thread, read through
// keyframes of the motion's curve. An Animated.loop around a sequence (up,
// then down) is restarted from JS at every step, so each looping thing on
// screen woke the JS thread every half-period and hitched whenever JS was
// busy (a level's board, a screen being built). A loop of a single timing
// runs on the native side alone (2026-10-28).
export const PHASE = Array.from({ length: 17 }, (_, i) => i / 16);
// 0 → 1 → 0, eased in and out (what two Easing.inOut(Easing.sin) halves did)
export const UP_DOWN = PHASE.map((p) => (1 - Math.cos(2 * Math.PI * p)) / 2);
// 0 → 1 → 0 in straight lines (two linear halves)
export const TRIANGLE = PHASE.map((p) => (p < 0.5 ? 2 * p : 2 - 2 * p));
// 0 → 1 → -1 → 0 (a sine: a quarter out, half across, a quarter back)
export const SWING = PHASE.map((p) => Math.sin(2 * Math.PI * p));

// A looping Animated.sequence of timings as keyframes for useKeyLoop: from
// `from`, each step [to, ms, easing] (straight if no easing; a step to where
// it already is, a rest), an eased step sampled about once a frame (at most
// `n` keyframes). Returns { ms, at, values }: the period and its keyframes.
export function stepKeys(from, steps, n = 8) {
  const ms = steps.reduce((sum, s) => sum + s[1], 0);
  const at = [0];
  const values = [from];
  let t = 0;
  let v = from;
  steps.forEach(([to, d, ease]) => {
    const k = to === v || !ease || ease === Easing.linear ? 1 : Math.max(1, Math.min(n, Math.ceil(d / 16)));
    for (let i = 1; i <= k; i++) {
      at.push((t + (d * i) / k) / ms);
      values.push(k === 1 ? to : v + (to - v) * ease(i / k));
    }
    t += d;
    v = to;
  });
  return { ms, at, values };
}

// Off for a subtree that's on screen but hidden (Home kept laid out under a
// screen that covers it, App.js): its loops stop, so a hidden screen's bobs
// and twinkles don't keep the RenderThread busy. They start again with it.
export const LoopsOn = createContext(true);
// On (App) from when a screen has slid in over Home until Home is back on
// screen: the lobby lets its live creature's WebView go then, and makes a
// fresh one once it's back. One kept hidden through a heavy screen (the
// squish stage's GL, the Shop built again) couldn't get Chromium's tile
// memory back and stayed blank (2026-10-28).
export const RigAway = createContext(false);

// The native loop of a phase value (0 → 1 every `ms`). (On the web it runs
// on JS: react-native-web has no native driver, and its stand-in played a
// "native" loop's timing once and stopped, 2026-11-20.)
const NATIVE = Platform.OS !== 'web';
export function phaseLoop(phase, ms) {
  return Animated.loop(Animated.timing(phase, { toValue: 1, duration: ms, easing: Easing.linear, useNativeDriver: NATIVE }));
}

// A value going `from` → `to` → `from` every `ms` (eased, or in straight
// lines with `eased: false`), started after `delay` ms while `on`; back at
// `from` when off. Use it where an Animated.Value looped up and down was.
export function usePingPong(ms, { from = 0, to = 1, eased = true, delay = 0, on = true } = {}) {
  const shape = eased ? UP_DOWN : TRIANGLE;
  return useKeyLoop(ms, { at: PHASE, values: useMemo(() => shape.map((k) => from + (to - from) * k), [shape, from, to]), delay, on });
}

// Any looping motion as keyframes: `values` at the phases `at` (0 … 1) of
// every `ms`; at values[0] when off. (`values: SWING` with `at: PHASE` is a
// swing 0 → 1 → -1 → 0; a rest is a stretch where the value stays put.)
export function useKeyLoop(ms, { at, values, delay = 0, on: wanted = true }) {
  const on = useContext(LoopsOn) && wanted;
  const phase = useRef(new Animated.Value(0)).current;
  const value = useMemo(() => phase.interpolate({ inputRange: at, outputRange: values }), [phase, at, values]);
  useEffect(() => {
    if (!on) return undefined;
    const loop = phaseLoop(phase, ms);
    const start = setTimeout(() => loop.start(), delay);
    return () => {
      clearTimeout(start);
      loop.stop();
      phase.setValue(0);
    };
  }, [phase, ms, delay, on]);
  return value;
}
