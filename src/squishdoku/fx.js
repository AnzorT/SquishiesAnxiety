import React, { forwardRef, memo, useCallback, useEffect, useImperativeHandle, useRef, useState } from 'react';
import { Animated, Easing, StyleSheet, Text, View } from 'react-native';
import { PHASE, SWING, useKeyLoop, usePingPong } from '../components/idleLoop';

// Squishdoku's little effects: particle bursts (dust, sparks, poofs,
// confetti) on one shared layer, pop-ins, shakes, pulses and counters.
// Everything runs on the native driver — one Animated value per burst,
// each particle its own interpolation of it.

const rnd = (a, b) => a + Math.random() * (b - a);

const KINDS = {
  // the puff under a creature landing: soft white blobs sliding sideways
  dust: { count: 7, life: 420, size: [5, 10], dist: [14, 30], up: [-4, 6], colors: ['#ffffff', '#fff6fb'], shape: 'dot', spreadY: 0.25, fall: 0 },
  // sparkles flying off a creature that landed right
  spark: { count: 8, life: 560, size: [5, 9], dist: [22, 46], up: [-6, 6], colors: ['#fff3a0', '#ffffff', '#ffd1f5', '#c9f5ff'], shape: 'star', spreadY: 1, fall: 10 },
  // a wrong creature popping off
  poof: { count: 9, life: 500, size: [7, 14], dist: [16, 34], up: [-8, 2], colors: ['#e6dcf0', '#ffffff', '#d6c8e8'], shape: 'dot', spreadY: 1, fall: -6 },
  // red bits when a creature is wrong
  angry: { count: 6, life: 380, size: [4, 7], dist: [18, 30], up: [-4, 4], colors: ['#ff4d6d', '#ff8fa3'], shape: 'dot', spreadY: 1, fall: 0 },
  // the solve and win confetti
  confetti: { count: 34, life: 1700, size: [7, 12], dist: [60, 190], up: [-260, -120], colors: ['#ff5cc6', '#ffd23a', '#3ddc97', '#5fb8ff', '#b65cff', '#ff8a4a', '#ffffff'], shape: 'rect', spreadY: 0.5, fall: 420 },
  // gold sparks round a score creature
  gold: { count: 12, life: 700, size: [6, 11], dist: [40, 80], up: [-10, 10], colors: ['#ffd23a', '#fff3a0', '#ffffff'], shape: 'star', spreadY: 1, fall: 18 },
  // coins popping out of the reward line
  coin: { count: 8, life: 650, size: [9, 12], dist: [20, 50], up: [-60, -30], colors: ['#ffc233', '#ffe38a'], shape: 'dot', spreadY: 0.4, fall: 80 },
};

function makeParticles(kind, scale) {
  const k = KINDS[kind];
  return Array.from({ length: k.count }, (_, i) => {
    const a = (i / k.count) * Math.PI * 2 + rnd(-0.3, 0.3);
    const d = rnd(k.dist[0], k.dist[1]) * scale;
    return {
      dx: Math.cos(a) * d,
      dy: Math.sin(a) * d * k.spreadY + rnd(k.up[0], k.up[1]) * scale,
      fall: k.fall * scale * rnd(0.7, 1.3),
      size: rnd(k.size[0], k.size[1]) * scale,
      color: k.colors[i % k.colors.length],
      spin: rnd(-1, 1) * (k.shape === 'rect' ? 900 : 240),
      delay: k.shape === 'rect' ? rnd(0, 0.12) : 0,
    };
  });
}

const Burst = memo(function Burst({ x, y, kind, scale = 1, onDone }) {
  const t = useRef(new Animated.Value(0)).current;
  const parts = useRef(makeParticles(kind, scale)).current;
  const k = KINDS[kind];
  useEffect(() => {
    const a = Animated.timing(t, { toValue: 1, duration: k.life, easing: Easing.out(Easing.quad), useNativeDriver: true });
    a.start(() => onDone());
    return () => a.stop();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);
  return (
    <View pointerEvents="none" style={[styles.at, { left: x, top: y }]}>
      {parts.map((p, i) => {
        const s0 = p.delay;
        const tx = t.interpolate({ inputRange: [0, s0 || 0.0001, 1], outputRange: [0, 0, p.dx] });
        // up and out, then the fall: a parabola from three points
        const ty = t.interpolate({ inputRange: [0, s0 || 0.0001, 0.45, 1], outputRange: [0, 0, p.dy * 0.8, p.dy + p.fall] });
        const op = t.interpolate({ inputRange: [0, 0.08, 0.7, 1], outputRange: [0, 1, 1, 0] });
        const sc = t.interpolate({ inputRange: [0, 0.15, 1], outputRange: [0.2, 1, k.shape === 'rect' ? 0.9 : 0.4] });
        const rot = t.interpolate({ inputRange: [0, 1], outputRange: ['0deg', `${p.spin}deg`] });
        const shape =
          k.shape === 'rect'
            ? { width: p.size, height: p.size * 0.5, borderRadius: 2 }
            : k.shape === 'star'
              ? { width: p.size, height: p.size, borderRadius: p.size * 0.18 }
              : { width: p.size, height: p.size, borderRadius: p.size };
        return (
          <Animated.View
            key={i}
            style={[
              styles.part,
              shape,
              { marginLeft: -p.size / 2, marginTop: -p.size / 2, backgroundColor: p.color, opacity: op, transform: [{ translateX: tx }, { translateY: ty }, { rotate: rot }, { scale: sc }, ...(k.shape === 'star' ? [{ rotate: '45deg' }] : [])] },
            ]}
          />
        );
      })}
    </View>
  );
});

// The layer bursts play on: `ref.current.burst(kind, x, y, scale)` (x, y in
// the layer's own coordinates).
export const FxLayer = memo(
  forwardRef(function FxLayer({ style }, ref) {
    const [bursts, setBursts] = useState([]);
    const id = useRef(0);
    const remove = useCallback((key) => setBursts((b) => b.filter((x) => x.key !== key)), []);
    useImperativeHandle(ref, () => ({
      burst(kind, x, y, scale = 1) {
        const key = ++id.current;
        // a busy board never piles up more than a dozen at once
        setBursts((b) => [...b.slice(-11), { key, kind, x, y, scale }]);
      },
    }));
    return (
      <View pointerEvents="none" style={[StyleSheet.absoluteFill, style]}>
        {bursts.map((b) => (
          <Burst key={b.key} kind={b.kind} x={b.x} y={b.y} scale={b.scale} onDone={() => remove(b.key)} />
        ))}
      </View>
    );
  }),
);

// Springs its children in from nothing after `delay` ms (with a little
// twist), every time `trigger` changes.
export function PopIn({ children, delay = 0, trigger, style, from = 0, twist = 8, friction = 5, tension = 120 }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    t.setValue(0);
    const a = Animated.spring(t, { toValue: 1, friction, tension, delay, useNativeDriver: true });
    a.start();
    return () => a.stop();
  }, [t, delay, trigger, friction, tension]);
  const scale = t.interpolate({ inputRange: [0, 1], outputRange: [from, 1] });
  const rotate = t.interpolate({ inputRange: [0, 1], outputRange: [`${-twist}deg`, '0deg'] });
  const opacity = t.interpolate({ inputRange: [0, 0.2, 1], outputRange: [0, 1, 1], extrapolate: 'clamp' });
  return <Animated.View style={[style, { opacity, transform: [{ scale }, { rotate }] }]}>{children}</Animated.View>;
}

// Slides in from `dy` below (or above, negative) after `delay`.
export function SlideIn({ children, delay = 0, dy = 40, trigger, style }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    t.setValue(0);
    const a = Animated.spring(t, { toValue: 1, friction: 7, tension: 90, delay, useNativeDriver: true });
    a.start();
    return () => a.stop();
  }, [t, delay, trigger]);
  const translateY = t.interpolate({ inputRange: [0, 1], outputRange: [dy, 0] });
  const opacity = t.interpolate({ inputRange: [0, 0.3, 1], outputRange: [0, 1, 1], extrapolate: 'clamp' });
  return <Animated.View style={[style, { opacity, transform: [{ translateY }] }]}>{children}</Animated.View>;
}

// A gentle forever-pulse (scale), without Animated.delay (a looping delay
// stalls InteractionManager — see PERFORMANCE.md), as one native loop
// (src/components/idleLoop.js).
export function Pulse({ children, to = 1.06, ms = 1400, active = true, style }) {
  const scale = usePingPong(ms, { from: 1, to, on: active });
  return <Animated.View style={[style, { transform: [{ scale }] }]}>{children}</Animated.View>;
}

// A forever side-to-side rock (rotate), one native loop.
export function Rock({ children, deg = 4, ms = 2400, style }) {
  const t = useKeyLoop(ms, { at: PHASE, values: SWING });
  const rotate = t.interpolate({ inputRange: [-1, 1], outputRange: [`${-deg}deg`, `${deg}deg`] });
  return <Animated.View style={[style, { transform: [{ rotate }] }]}>{children}</Animated.View>;
}

// [value, shake()]: a quick decaying side-to-side shake for translateX.
export function useShake(px = 10) {
  const v = useRef(new Animated.Value(0)).current;
  const shake = useCallback(() => {
    v.setValue(0);
    Animated.sequence(
      [1, -0.9, 0.7, -0.5, 0.3, -0.15, 0].map((k) => Animated.timing(v, { toValue: k * px, duration: 45, useNativeDriver: true })),
    ).start();
  }, [v, px]);
  return [v, shake];
}

// A number counting up to `value` over `ms`, calling `onTick` now and then
// (the coin ticks).
export function CountUp({ value, ms = 900, delay = 0, style, prefix = '', onTick, ticks = 10 }) {
  const [shown, setShown] = useState(0);
  useEffect(() => {
    let raf;
    let timer;
    let lastTick = -1;
    const start = () => {
      const t0 = Date.now();
      const step = () => {
        const k = Math.min(1, (Date.now() - t0) / ms);
        const eased = 1 - Math.pow(1 - k, 3);
        setShown(Math.round(value * eased));
        const tick = Math.floor(k * ticks);
        if (tick !== lastTick && k < 1) {
          lastTick = tick;
          onTick && onTick(tick);
        }
        if (k < 1) raf = requestAnimationFrame(step);
      };
      step();
    };
    timer = setTimeout(start, delay);
    return () => {
      clearTimeout(timer);
      cancelAnimationFrame(raf);
    };
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [value, ms, delay]);
  return <Text style={style}>{`${prefix}${shown}`}</Text>;
}

const styles = StyleSheet.create({
  at: { position: 'absolute', width: 0, height: 0 },
  part: { position: 'absolute', left: 0, top: 0 },
});
