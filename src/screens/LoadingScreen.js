import React, { useEffect, useRef, useState } from 'react';
import { View, Image, StyleSheet, Animated, Easing } from 'react-native';
import CreatureThumbnail from '../components/CreatureThumbnail';
import CandyBackground from '../components/candy/CandyBackground';
import OutlinedTitle from '../components/candy/OutlinedTitle';
import HopDots from '../components/candy/HopDots';
import { Twinkle } from '../components/candy/Sparkles';
import AssembleCreature from '../components/AssembleCreature';
import { isCreatureModelReady, preloadCreatureModel } from '../components/SquishyToy';
import sfx from '../audio/sfx';

// Brief "getting the toy ready" beat between picking a card on Home and
// SquishScreen actually mounting — the v3 loading screen: the creature
// bouncing on the candy stage over a gold "Getting Ready" sticker and three
// hopping candy balls, then a wobbling pink "✦ I AM READY! ✦" sticker, then
// a fade to the toy. The
// "ready" beat now also gates on the creature's .glb actually being
// fetched/parsed (preloadCreatureModel, cached and shared with SquishyToy's
// own loader) so "I AM READY!" is true, not just a timer — otherwise the
// model could still be loading once SquishScreen mounts and pop in there.
// When there's nothing to wait for (the model is already loaded, or the
// creature has none) it skips the dots: just "I AM READY!" and a quick fade,
// about 0.7 s instead of 3.

const PREP_MS = 1500;
const READY_MS = 1000;
const FADE_MS = 500;
const QUICK_READY_MS = 500;
const QUICK_FADE_MS = 200;
// Never block navigation forever on a slow/failed fetch — proceed anyway
// after this, same as today's fixed-timer behavior in the worst case.
const MAX_WAIT_MS = 8000;

// The design's `popIn` keyframe: springs in from a small, tilted, invisible
// state, overshoots to 1.12x / +3deg, then settles. Used for "I AM READY!"
// (and mirrored by the "×N COINS!" flash on SquishScreen).
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

export default function LoadingScreen({ creature, onFinish }) {
  const [quick] = useState(() => isCreatureModelReady(creature));
  const [stage, setStage] = useState(quick ? 'ready' : 'prep');
  const opacity = useRef(new Animated.Value(1)).current;

  useEffect(() => {
    let cancelled = false;
    const timers = [];
    const wait = (ms) => new Promise((resolve) => { timers.push(setTimeout(resolve, ms)); });

    (async () => {
      if (!quick) {
        const modelReady = preloadCreatureModel(creature).catch(() => {});
        // Dots show for at least PREP_MS, and longer still if the model isn't
        // loaded yet — but never past MAX_WAIT_MS total.
        await Promise.race([Promise.all([wait(PREP_MS), modelReady]), wait(MAX_WAIT_MS)]);
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
  }, []);

  return (
    <Animated.View style={[styles.flex, { opacity }]}>
      <CandyBackground style={styles.container}>
        {creature?.isCustom && creature.image ? (
          <Image source={{ uri: creature.image }} style={styles.customArt} />
        ) : creature?.isCustom && creature.build ? (
          <AssembleCreature build={creature.build} size={170} />
        ) : (
          <CreatureThumbnail creature={creature} mood="ready" size={224} bleed={16} />
        )}
        {stage === 'prep' ? (
          <View style={styles.prepRow}>
            <OutlinedTitle text="Getting Ready" fill="gold" size={22} outline={2.5} ring={1.5} />
            <HopDots />
          </View>
        ) : (
          <PopIn style={styles.readyRow}>
            <Twinkle size={18} duration={1.4} />
            <OutlinedTitle text="I AM READY!" fill="pink" size={30} wobble />
            <Twinkle size={18} duration={1.4} delay={0.7} />
          </PopIn>
        )}
      </CandyBackground>
    </Animated.View>
  );
}

const styles = StyleSheet.create({
  flex: { flex: 1 },
  container: { flex: 1, alignItems: 'center', justifyContent: 'center' },
  customArt: { width: 170, height: 170, borderRadius: 85 },
  prepRow: { marginTop: 22, flexDirection: 'row', alignItems: 'center', gap: 8 },
  readyRow: { marginTop: 16, flexDirection: 'row', alignItems: 'center', gap: 6 },
});
