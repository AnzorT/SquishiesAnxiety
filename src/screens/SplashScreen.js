import React, { useEffect, useMemo, useRef, useState } from 'react';
import { Animated, Easing, View, Text, StyleSheet } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import CreatureThumbnail from '../components/CreatureThumbnail';
import ShadowText from '../components/candy/ShadowText';
import IntroBackground from '../squad/IntroBackground';
import { F, PINK, PINK_RING } from '../squad/ui';

// First thing shown on launch, from the "Squish Squad App" shell
// (2026-10-08): Mittens hopping (the design's rive-rig kitten playing
// "happy"; here our plush with the happy mood), the white "Squish Squad"
// title outlined in deep purple, and a pink loading bar counting up to
// READY!, on the intro sky. It moves on by itself once the bar is full, and
// the bar fills as soon as the app is ready (`ready`: signed in or not, and
// the profile and the catalog loaded), 1.5 s at the least so it never
// flashes (the user, 2026-10-28: "no long loading screens"; from 2026-10-08
// it took a fixed 10 s). A tap doesn't skip it.
//
// `creatures` comes from App.js's on-device cache of the Firestore catalog
// (src/data/creatureCache.js): on a brand-new install, before anyone has
// logged in, there's no cache yet, so Mittens' spot stays empty that once.

const PURPLE = '#45107a';
const MASCOT = 230;

// The bar fills on the native driver (a slide inside the track, not a width
// change), so it glides at the screen's frame rate even while the JS thread
// is busy starting the app — it used to be set from JS every 110 ms in 7-16%
// jumps, and stuttered. It runs towards SOFT_TO over SOFT_MS while the app
// starts, then fills the rest in END_MS once it's ready (MIN_MS in at the
// earliest), or after MAX_MS whatever happens (offline).
const SOFT_MS = 2600;
const SOFT_TO = 0.9;
const MIN_MS = 1500;
const END_MS = 320;
const MAX_MS = 10000;
const SOFT_EASE = Easing.out(Easing.quad);
const TRACK_W = 210; // the white track inside the ring: 215 - 2 × 2.5

const soft = (ms) => SOFT_TO * SOFT_EASE(Math.min(1, ms / SOFT_MS));

// The "WAKING UP THE SQUAD… N%" line, counting along the same curve (from
// `start`, and from `endAt` the last fill). Its own component, so its
// updates re-render only this text.
function LoadLabel({ start, endAt }) {
  const [pct, setPct] = useState(0);
  useEffect(() => {
    const tick = setInterval(() => {
      const now = Date.now();
      const from = endAt ? soft(endAt - start) : 0;
      const p = endAt && now >= endAt ? from + (1 - from) * Math.min(1, (now - endAt) / END_MS) : soft(now - start);
      setPct(Math.round(p * 100));
      if (p >= 1) clearInterval(tick);
    }, 120);
    return () => clearInterval(tick);
  }, [start, endAt]);
  return <Text style={styles.load}>{pct >= 100 ? 'READY!' : `WAKING UP THE SQUAD… ${pct}%`}</Text>;
}

export default function SplashScreen({ onFinish, ready = false, creatures = [] }) {
  const finished = useRef(false);
  const fill = useRef(new Animated.Value(0)).current;
  const [start] = useState(() => Date.now());
  const [endAt, setEndAt] = useState(null);
  const [timedOut, setTimedOut] = useState(false);
  const mittens = useMemo(() => creatures.find((c) => String(c.id) === '1' || c.name === 'Mittens'), [creatures]);

  const finish = () => {
    if (finished.current) return;
    finished.current = true;
    onFinish();
  };
  const finishRef = useRef(finish);
  finishRef.current = finish;

  // the bar's run while the app starts
  useEffect(() => {
    const anim = Animated.timing(fill, { toValue: SOFT_TO, duration: SOFT_MS, easing: SOFT_EASE, useNativeDriver: true });
    anim.start();
    const giveUp = setTimeout(() => setTimedOut(true), MAX_MS);
    return () => {
      anim.stop();
      clearTimeout(giveUp);
    };
  }, [fill]);
  // ready (once seen, for good): the rest of the bar, then on 250 ms after
  // 100% (the design's introInit waits 350)
  const [due, setDue] = useState(false);
  useEffect(() => {
    if (ready || timedOut) setDue(true);
  }, [ready, timedOut]);
  useEffect(() => {
    if (!due) return undefined;
    let done = null;
    let anim = null;
    const go = setTimeout(() => {
      setEndAt(Date.now());
      anim = Animated.timing(fill, { toValue: 1, duration: END_MS, easing: SOFT_EASE, useNativeDriver: true });
      anim.start(({ finished: full }) => {
        if (full) done = setTimeout(() => finishRef.current(), 250);
      });
    }, Math.max(0, MIN_MS - (Date.now() - start)));
    return () => {
      clearTimeout(go);
      clearTimeout(done);
      if (anim) anim.stop();
    };
  }, [due, fill, start]);
  const translateX = fill.interpolate({ inputRange: [0, 1], outputRange: [-TRACK_W, 0] });

  return (
    <View style={styles.flex}>
      <IntroBackground>
        <View style={styles.column}>
          <View style={styles.mascot}>{mittens ? <CreatureThumbnail creature={mittens} size={MASCOT} mood="happy" animate /> : null}</View>
          <ShadowText
            style={styles.title}
            shadows={[
              [0, 5, PURPLE],
              [3, 0, PURPLE],
              [-3, 0, PURPLE],
              [0, -3, PURPLE],
            ]}
          >
            {'Squish\nSquad'}
          </ShadowText>
          {/* the bar: white, in a pink ring with a lip, filling pink */}
          <View style={styles.barRing}>
            <View style={styles.bar}>
              <Animated.View style={[styles.fill, { transform: [{ translateX }] }]} renderToHardwareTextureAndroid>
                <LinearGradient colors={PINK} locations={[0, 0.55, 1]} style={styles.fillFace} />
              </Animated.View>
            </View>
          </View>
          <LoadLabel start={start} endAt={endAt} />
        </View>
      </IntroBackground>
    </View>
  );
}

const styles = StyleSheet.create({
  flex: { flex: 1 },
  column: { flex: 1, alignItems: 'center', justifyContent: 'center', gap: 12 },
  mascot: { width: MASCOT, height: MASCOT },
  title: { fontFamily: F.display, fontSize: 54, lineHeight: 52, textAlign: 'center', color: '#ffffff' },
  barRing: { marginTop: 14, width: 215, borderRadius: 999, backgroundColor: PINK_RING, padding: 2.5, paddingBottom: 6.5 },
  bar: { height: 14, borderRadius: 999, backgroundColor: '#ffffff', overflow: 'hidden' },
  fill: { width: TRACK_W, height: '100%' },
  fillFace: { flex: 1, borderRadius: 999 },
  load: { fontFamily: F.black, fontSize: 12, letterSpacing: 1.5, color: PURPLE },
});
