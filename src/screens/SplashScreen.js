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
// READY!, on the intro sky. It moves on by itself once the bar is full:
// 10 seconds (the user's ruling, 2026-10-08; the design took about one), and
// a tap no longer skips it.
//
// `creatures` comes from App.js's on-device cache of the Firestore catalog
// (src/data/creatureCache.js): on a brand-new install, before anyone has
// logged in, there's no cache yet, so Mittens' spot stays empty that once.

const PURPLE = '#45107a';
const MASCOT = 230;

// The bar fills on the native driver (a slide inside the track, not a width
// change), so it glides at the screen's frame rate even while the JS thread
// is busy starting the app — it used to be set from JS every 110 ms in 7-16%
// jumps, and stuttered. Over 10 s it runs close to steady (CSS's `ease`), so
// it never seems to stall on the way.
const FILL_MS = 10000;
const FILL_EASE = Easing.bezier(0.25, 0.1, 0.25, 1);
const TRACK_W = 210; // the white track inside the ring: 215 - 2 × 2.5

// The "WAKING UP THE SQUAD… N%" line, counting along the same curve. Its own
// component, so its updates re-render only this text.
function LoadLabel() {
  const [pct, setPct] = useState(0);
  useEffect(() => {
    const start = Date.now();
    const tick = setInterval(() => {
      const t = Math.min(1, (Date.now() - start) / FILL_MS);
      setPct(Math.round(FILL_EASE(t) * 100));
      if (t >= 1) clearInterval(tick);
    }, 200);
    return () => clearInterval(tick);
  }, []);
  return <Text style={styles.load}>{pct >= 100 ? 'READY!' : `WAKING UP THE SQUAD… ${pct}%`}</Text>;
}

export default function SplashScreen({ onFinish, creatures = [] }) {
  const finished = useRef(false);
  const fill = useRef(new Animated.Value(0)).current;
  const mittens = useMemo(() => creatures.find((c) => String(c.id) === '1' || c.name === 'Mittens'), [creatures]);

  const finish = () => {
    if (finished.current) return;
    finished.current = true;
    onFinish();
  };
  const finishRef = useRef(finish);
  finishRef.current = finish;

  // the design's introInit: the bar fills in about a second, then on 350ms
  // after 100%
  useEffect(() => {
    let done = null;
    const anim = Animated.timing(fill, { toValue: 1, duration: FILL_MS, easing: FILL_EASE, useNativeDriver: true });
    anim.start(({ finished: full }) => {
      if (full) done = setTimeout(() => finishRef.current(), 350);
    });
    return () => {
      anim.stop();
      clearTimeout(done);
    };
  }, [fill]);
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
          <LoadLabel />
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
