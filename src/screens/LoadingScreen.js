import React, { useEffect, useRef, useState } from 'react';
import { View, Image, StyleSheet, Animated, Easing } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { BUTTON_VARIANTS } from '../theme/candyTheme';
import CreatureThumbnail from '../components/CreatureThumbnail';
import CandyBackground from '../components/candy/CandyBackground';
import OutlinedTitle from '../components/candy/OutlinedTitle';
import { Shine } from '../components/candy/CandyButton';
import { Twinkle } from '../components/candy/Sparkles';
import AssembleCreature from '../components/AssembleCreature';
import { preloadCreatureModel } from '../components/SquishyToy';
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

const PREP_MS = 1500;
const READY_MS = 1000;
const FADE_MS = 500;
// Never block navigation forever on a slow/failed fetch — proceed anyway
// after this, same as today's fixed-timer behavior in the worst case.
const MAX_WAIT_MS = 8000;

// One bouncing candy ball: the candy buttons' look (dark ring, white rim,
// glossy gradient face, a lip underneath) at dot size. Each hops in turn on
// the design's dotBounce cycle (up by 40% of 1 s, down by 80%, brighter at
// the top) and squashes a little as it lands.
const DOT = 18;
const HOP = 9;
const hopIn = [0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.85, 0.92, 1];
const hopY = [0, 0.44, 0.75, 0.94, 1, 0.94, 0.75, 0.44, 0, 0, 0, 0].map((f) => -f * HOP);

function Dot({ delay, variant }) {
  const v = BUTTON_VARIANTS[variant];
  const p = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const anim = Animated.sequence([
      Animated.delay(delay),
      Animated.loop(Animated.timing(p, { toValue: 1, duration: 1000, easing: Easing.linear, useNativeDriver: true })),
    ]);
    anim.start();
    return () => anim.stop();
  }, [p, delay]);
  const translateY = p.interpolate({ inputRange: hopIn, outputRange: hopY });
  const scaleX = p.interpolate({ inputRange: [0, 0.8, 0.85, 0.92, 1], outputRange: [1, 1, 1.18, 1, 1] });
  const scaleY = p.interpolate({ inputRange: [0, 0.8, 0.85, 0.92, 1], outputRange: [1, 1, 0.8, 1, 1] });
  const opacity = p.interpolate({ inputRange: [0, 0.4, 0.8, 1], outputRange: [0.65, 1, 0.65, 0.65] });
  return (
    <Animated.View style={[styles.dot, { opacity, transform: [{ translateY }, { scaleX }, { scaleY }] }]}>
      <View style={[styles.dotLip, { backgroundColor: v.ring }]} />
      <View style={[styles.dotRing, { backgroundColor: v.ring }]}>
        <View style={styles.dotRim}>
          <LinearGradient colors={v.colors} locations={v.locations} style={styles.dotFace}>
            <Shine />
          </LinearGradient>
        </View>
      </View>
    </Animated.View>
  );
}

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
  const [stage, setStage] = useState('prep');
  const opacity = useRef(new Animated.Value(1)).current;

  useEffect(() => {
    let cancelled = false;
    const timers = [];
    const wait = (ms) => new Promise((resolve) => { timers.push(setTimeout(resolve, ms)); });

    (async () => {
      const modelReady = preloadCreatureModel(creature).catch(() => {});
      // Dots show for at least PREP_MS, and longer still if the model isn't
      // loaded yet — but never past MAX_WAIT_MS total.
      await Promise.race([Promise.all([wait(PREP_MS), modelReady]), wait(MAX_WAIT_MS)]);
      if (cancelled) return;
      setStage('ready');
      sfx.play('ready');
      await wait(READY_MS);
      if (cancelled) return;
      Animated.timing(opacity, { toValue: 0, duration: FADE_MS, useNativeDriver: true }).start();
      await wait(FADE_MS);
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
            <View style={styles.dots}>
              <Dot delay={0} variant="pink" />
              <Dot delay={150} variant="gold" />
              <Dot delay={300} variant="blue" />
            </View>
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
  // room above for the hop, so the row doesn't grow while the dots jump
  dots: { flexDirection: 'row', gap: 5, paddingTop: HOP },
  dot: { width: DOT, height: DOT + 2 },
  dotLip: { position: 'absolute', top: 2, left: 0, width: DOT, height: DOT, borderRadius: DOT / 2 },
  dotRing: { width: DOT, height: DOT, borderRadius: DOT / 2, padding: 1.5 },
  dotRim: { flex: 1, borderRadius: DOT / 2, backgroundColor: '#ffffff', padding: 1.5 },
  dotFace: { flex: 1, borderRadius: DOT / 2, overflow: 'hidden' },
  readyRow: { marginTop: 16, flexDirection: 'row', alignItems: 'center', gap: 6 },
});
