import React, { useEffect, useRef, useState } from 'react';
import { Animated, Easing, StyleSheet, View } from 'react-native';
import CreatureThumbnail from '../components/CreatureThumbnail';
import { useAfterFirstFrame } from '../components/Skeleton';
import { usePingPong } from '../components/idleLoop';
import { isCreatureModelReady, preloadCreatureModel } from '../components/SquishyToy';
import { Lettering, WoodBg } from '../royal';
import sfx from '../audio/sfx';

// The short "getting your creature ready" beat between PLAY (Squish Time) and the squish stage: the creature on a warm
// glow over the wood, "Getting ready" with three hopping gold dots while its model loads, then "I AM READY!" and a fade
// to the stage. The ready beat waits for the creature's .glb (preloadCreatureModel, shared with SquishyToy's loader)
// so the stage never pops it in late; with nothing to wait for (model loaded, or none) it's just "I AM READY!", ~0.6 s.
//
// 2026-11-20 (the user: "the loading screens, I only hear the audio and when I see them they are half way done"):
// - Nothing runs on a clock before the screen is on screen: the beats (and the "ready" sound) start once its first
//   frame has painted (useAfterFirstFrame), so the sound is never ahead of the picture, and once the stage under it
//   is built (`hold`), so building it doesn't freeze them.
// - The wood look of the rest of the game (it was the old design's candy sky and pink sticker).

const PREP_MS = 600;
const READY_MS = 600;
const FADE_MS = 260;
const QUICK_READY_MS = 450;
const QUICK_FADE_MS = 150;
// Never block navigation forever on a slow/failed fetch — proceed anyway after this.
const MAX_WAIT_MS = 8000;

// springs in from small and tilted, overshoots, settles (the design's popIn)
function PopIn({ style, children }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    Animated.timing(t, { toValue: 1, duration: 420, easing: Easing.out(Easing.quad), useNativeDriver: true }).start();
  }, [t]);
  const opacity = t.interpolate({ inputRange: [0, 0.5, 1], outputRange: [0, 1, 1] });
  const scale = t.interpolate({ inputRange: [0, 0.6, 1], outputRange: [0.4, 1.12, 1] });
  const rotate = t.interpolate({ inputRange: [0, 0.6, 1], outputRange: ['-8deg', '3deg', '0deg'] });
  return <Animated.View style={[style, { opacity, transform: [{ scale }, { rotate }] }]}>{children}</Animated.View>;
}

// one hopping gold dot (a native loop each, a beat apart)
function Dot({ delay, on }) {
  const translateY = usePingPong(640, { from: 0, to: -7, delay, on });
  return <Animated.View style={[styles.dot, { transform: [{ translateY }] }]} />;
}

// `hold`: the squish stage is still being built under this screen (App.js). Building it holds the UI thread for
// 0.2-0.3 s on the Galaxy A16 (~230 native views, the stage's SVGs painted in software), which froze whatever was
// moving here: the beat waits, on its first frame (still), until the stage is up. Never longer than HOLD_MAX_MS.
const HOLD_MAX_MS = 1500;

export default function LoadingScreen({ creature, onFinish, hold = false }) {
  const [quick] = useState(() => isCreatureModelReady(creature));
  const [stage, setStage] = useState(quick ? 'ready' : 'prep');
  const opacity = useRef(new Animated.Value(1)).current;
  const painted = useAfterFirstFrame();
  const [begun, setBegun] = useState(false);
  useEffect(() => {
    if (!painted || begun) return undefined;
    if (!hold) {
      setBegun(true);
      return undefined;
    }
    const t = setTimeout(() => setBegun(true), HOLD_MAX_MS);
    return () => clearTimeout(t);
  }, [painted, hold, begun]);

  // the model starts loading at once (it isn't a clock)
  const modelReady = useRef(null);
  if (!quick && !modelReady.current) modelReady.current = preloadCreatureModel(creature).catch(() => {});

  useEffect(() => {
    if (!begun) return undefined;
    let cancelled = false;
    const timers = [];
    const wait = (ms) => new Promise((resolve) => { timers.push(setTimeout(resolve, ms)); });
    (async () => {
      if (!quick) {
        // the dots show for at least PREP_MS, longer while the model is still loading, never past MAX_WAIT_MS
        await Promise.race([Promise.all([wait(PREP_MS), modelReady.current]), wait(MAX_WAIT_MS)]);
        if (cancelled) return;
        setStage('ready');
      }
      sfx.play('ready');
      await wait(quick ? QUICK_READY_MS : READY_MS);
      if (cancelled) return;
      const fade = quick ? QUICK_FADE_MS : FADE_MS;
      Animated.timing(opacity, { toValue: 0, duration: fade, useNativeDriver: true }).start();
      await wait(fade);
      if (cancelled) return;
      onFinish();
    })();
    return () => {
      cancelled = true;
      timers.forEach(clearTimeout);
    };
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [begun]);

  return (
    <Animated.View style={[styles.flex, { opacity }]}>
      <WoodBg />
      <View style={styles.center}>
        <View style={styles.halo} />
        <CreatureThumbnail creature={creature} mood="ready" size={210} bleed={16} />
        {stage === 'prep' ? (
          <View style={styles.row}>
            <Lettering text="Getting ready" variant="gold" size={24} />
            <View style={styles.dots}>
              <Dot delay={0} on={begun} />
              <Dot delay={160} on={begun} />
              <Dot delay={320} on={begun} />
            </View>
          </View>
        ) : begun ? (
          <PopIn style={styles.row}>
            <Lettering text="I AM READY!" variant="gold" size={30} />
          </PopIn>
        ) : (
          <View style={styles.row} />
        )}
      </View>
    </Animated.View>
  );
}

const styles = StyleSheet.create({
  flex: { flex: 1 },
  center: { flex: 1, alignItems: 'center', justifyContent: 'center' },
  // a soft warm light under the creature (the Characters page's lit pad, flat)
  halo: { position: 'absolute', width: 300, height: 300, borderRadius: 150, backgroundColor: 'rgba(255,214,110,0.22)' },
  row: { marginTop: 14, height: 46, flexDirection: 'row', alignItems: 'center', gap: 8 },
  dots: { flexDirection: 'row', alignItems: 'flex-end', gap: 6, paddingTop: 10 },
  dot: { width: 10, height: 10, borderRadius: 5, backgroundColor: '#ffd24a', borderWidth: 2, borderColor: '#6b4426' },
});
