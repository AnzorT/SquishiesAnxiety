import React, { memo, useEffect, useMemo, useRef, useState } from 'react';
import { Animated, Easing, StyleSheet, View, useWindowDimensions } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';

// Placeholders ("skeletons") a screen shows on the tap's own frame while its
// real content is still being built: soft blocks in the content's shape with
// a white shine sweeping across them, so a tap is answered at once instead
// of after the whole screen has been built.
//
// A screen opened over Home builds its content once its ScreenLayer has
// slid in (`useScreenReady` in ScreenLayer.js); Home's tabs build theirs a
// couple of frames after mounting (`useAfterFirstFrame`).

// One shine for every bone on screen, so they sweep together and there's
// a single native animation however many bones are up. It's one timing in a
// native loop (no sequence), so it repeats on the UI thread by itself for as
// long as the bones are up: a loop around a sequence is restarted from JS at
// the end of every pass, and while JS was busy building the screen behind
// the bones, the shine stopped after its first sweep. The pause between
// sweeps is in the interpolation instead (SWEEP_AT).
const sweep = new Animated.Value(0);
let users = 0;
let loop = null;
function useSweep() {
  useEffect(() => {
    if (users++ === 0) {
      loop = Animated.loop(Animated.timing(sweep, { toValue: 1, duration: 1400, easing: Easing.linear, useNativeDriver: true }));
      loop.start();
    }
    return () => {
      if (--users === 0) {
        loop.stop();
        loop = null;
        sweep.setValue(0);
      }
    };
  }, []);
}

const BAND = 90;
// across during the first 70% of each 1.4 s pass, resting off the right
// edge for the rest
const SWEEP_AT = [0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 1];
const sweepEase = Easing.inOut(Easing.quad);
const SHINE = ['rgba(255,255,255,0)', 'rgba(255,255,255,0.75)', 'rgba(255,255,255,0)'];

// A placeholder block. `tone`: 'sky' on the screen's sky background, 'card'
// inside a white card (BoneCard), 'dark' on the Crib's dark wood.
export const Bone = memo(function Bone({ w = '100%', h = 14, r = 8, tone = 'card', style }) {
  useSweep();
  const { width } = useWindowDimensions();
  const translateX = useMemo(
    () => sweep.interpolate({ inputRange: SWEEP_AT, outputRange: SWEEP_AT.map((t) => -BAND + (width + BAND) * sweepEase(Math.min(1, t / 0.7))) }),
    [width],
  );
  return (
    <View style={[styles.bone, styles[tone] || styles.card, { width: w, height: h, borderRadius: r }, style]}>
      <Animated.View style={[styles.band, tone === 'dark' && styles.dimBand, { transform: [{ translateX }, { skewX: '-14deg' }] }]}>
        <LinearGradient colors={SHINE} start={{ x: 0, y: 0.5 }} end={{ x: 1, y: 0.5 }} style={StyleSheet.absoluteFill} />
      </Animated.View>
    </View>
  );
});

// Swaps the bones for the real content with a crossfade instead of a pop:
// the content fades in from 0 to 100% while the bones, laid over it, fade
// out; then they unmount. Content that is ready from the start (a screen
// kept alive, a list already built) shows at once with no fade.
//   <Reveal ready={built} placeholder={<CollectionBones />}>…</Reveal>
// `fill`: the wrapper takes the parent's remaining height (flex: 1).
// `contentStyle`: for the content's wrapper (e.g. the parent's `gap`, which
// a wrapper View would otherwise swallow).
// short: the content is ready, the fade only softens the swap
const REVEAL = { duration: 160, easing: Easing.out(Easing.quad), useNativeDriver: true };

export function Reveal({ ready, placeholder, fill = false, contentStyle, children }) {
  const [bones, setBones] = useState(!ready);
  const t = useRef(new Animated.Value(ready ? 1 : 0)).current;
  useEffect(() => {
    if (!ready || !bones) return undefined;
    const a = Animated.timing(t, { toValue: 1, ...REVEAL });
    a.start(({ finished }) => finished && setBones(false));
    return () => a.stop();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [ready]);
  const boneOpacity = useMemo(() => t.interpolate({ inputRange: [0, 1], outputRange: [1, 0] }), [t]);
  return (
    <View style={fill ? styles.fill : null}>
      {ready && <Animated.View style={[fill && styles.fill, contentStyle, { opacity: t }]}>{children}</Animated.View>}
      {bones && (
        <Animated.View pointerEvents="none" style={[ready ? (fill ? StyleSheet.absoluteFill : styles.over) : fill && styles.fill, contentStyle, { opacity: boneOpacity }]}>
          {placeholder}
        </Animated.View>
      )}
    </View>
  );
}

// The design's white card (white rim, lilac lip) holding bones.
export function BoneCard({ style, children }) {
  return <View style={[styles.boneCard, style]}>{children}</View>;
}

// false on the first render, true a couple of frames later: what's
// rendered before it flips (the screen's frame and its bones) is drawn
// first, and the real content is built after.
export function useAfterFirstFrame() {
  const [ready, setReady] = useState(false);
  useEffect(() => {
    let second = null;
    const first = requestAnimationFrame(() => {
      second = requestAnimationFrame(() => setReady(true));
    });
    return () => {
      cancelAnimationFrame(first);
      if (second != null) cancelAnimationFrame(second);
    };
  }, []);
  return ready;
}

const styles = StyleSheet.create({
  fill: { flex: 1 },
  // the bones over the content while they fade out
  over: { position: 'absolute', top: 0, left: 0, right: 0 },
  bone: { overflow: 'hidden' },
  sky: { backgroundColor: 'rgba(255,255,255,0.5)' },
  card: { backgroundColor: 'rgba(162,58,216,0.12)' },
  dark: { backgroundColor: 'rgba(255,236,214,0.1)' },
  band: { position: 'absolute', top: -10, bottom: -10, left: 0, width: BAND },
  dimBand: { opacity: 0.2 },
  boneCard: { borderRadius: 22, backgroundColor: '#ffffff', borderWidth: 3, borderColor: '#ffffff', borderBottomWidth: 7, borderBottomColor: '#e3d4f5', padding: 12 },
});
