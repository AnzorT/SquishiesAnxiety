import React, { useEffect, useMemo, useRef, useState } from 'react';
import { View, Text, StyleSheet, Pressable } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import CreatureThumbnail from '../components/CreatureThumbnail';
import ShadowText from '../components/candy/ShadowText';
import IntroBackground from '../squad/IntroBackground';
import { F, PINK, PINK_RING } from '../squad/ui';

// First thing shown on launch, from the "Squish Squad App" shell
// (2026-10-08): Mittens hopping (the design's rive-rig kitten playing
// "happy"; here our plush with the happy mood), the white "Squish Squad"
// title outlined in deep purple, and a pink loading bar counting up to
// READY!, on the intro sky. It moves on by itself once the bar is full
// (about a second, as in the design); a tap skips it.
//
// `creatures` comes from App.js's on-device cache of the Firestore catalog
// (src/data/creatureCache.js): on a brand-new install, before anyone has
// logged in, there's no cache yet, so Mittens' spot stays empty that once.

const PURPLE = '#45107a';
const MASCOT = 230;

export default function SplashScreen({ onFinish, creatures = [] }) {
  const finished = useRef(false);
  const [pct, setPct] = useState(0);
  const mittens = useMemo(() => creatures.find((c) => String(c.id) === '1' || c.name === 'Mittens'), [creatures]);

  const finish = () => {
    if (finished.current) return;
    finished.current = true;
    onFinish();
  };
  const finishRef = useRef(finish);
  finishRef.current = finish;

  // the design's introInit: +7–16% every 110ms, then on 350ms after 100%
  useEffect(() => {
    let p = 0;
    let done = null;
    const tick = setInterval(() => {
      p = Math.min(100, p + 7 + Math.random() * 9);
      setPct(Math.round(p));
      if (p >= 100) {
        clearInterval(tick);
        done = setTimeout(() => finishRef.current(), 350);
      }
    }, 110);
    return () => {
      clearInterval(tick);
      clearTimeout(done);
    };
  }, []);

  return (
    <Pressable style={styles.flex} onPress={finish}>
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
              <LinearGradient colors={PINK} locations={[0, 0.55, 1]} style={[styles.fill, { width: `${pct}%` }]} />
            </View>
          </View>
          <Text style={styles.load}>{pct >= 100 ? 'READY!' : `WAKING UP THE SQUAD… ${pct}%`}</Text>
        </View>
      </IntroBackground>
    </Pressable>
  );
}

const styles = StyleSheet.create({
  flex: { flex: 1 },
  column: { flex: 1, alignItems: 'center', justifyContent: 'center', gap: 12 },
  mascot: { width: MASCOT, height: MASCOT },
  title: { fontFamily: F.display, fontSize: 54, lineHeight: 52, textAlign: 'center', color: '#ffffff' },
  barRing: { marginTop: 14, width: 215, borderRadius: 999, backgroundColor: PINK_RING, padding: 2.5, paddingBottom: 6.5 },
  bar: { height: 14, borderRadius: 999, backgroundColor: '#ffffff', overflow: 'hidden' },
  fill: { height: '100%', borderRadius: 999 },
  load: { fontFamily: F.black, fontSize: 12, letterSpacing: 1.5, color: PURPLE },
});
