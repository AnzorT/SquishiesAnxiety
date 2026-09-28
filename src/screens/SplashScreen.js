import React, { useEffect, useRef } from 'react';
import { View, StyleSheet, Pressable, Animated, Easing } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { candyFonts } from '../theme/candyTheme';
import CreatureThumbnail from '../components/CreatureThumbnail';
import CandyBackground from '../components/candy/CandyBackground';
import CandyButton from '../components/candy/CandyButton';
import OutlinedTitle, { HaloText } from '../components/candy/OutlinedTitle';

// First thing shown on launch — the v3 splash: every creature scattered at
// fixed percent positions (owned ones bright and full-size, locked ones dim
// and smaller) over the candy stage with its sparkles, the wobbling
// gold/pink "SQUISH SQUAD" sticker wordmark, and the pulsing pink CTA. Stays
// up until the player taps — no auto-advance timer.
//
// `creatures` now comes from App.js's on-device cache of the Firestore
// catalog (see src/data/creatureCache.js), not bundled data — on a
// brand-new install, before anyone has ever logged in, there's no cache yet
// and this array is empty on purpose: the splash just shows no floaters
// that one time, rather than reaching Firestore before auth exists. Once a
// cache has been written (first successful login), every future launch has
// it immediately, before auth even resolves.

const MOODS = ['idle', 'jump', 'wobble'];

// Exact percent-of-screen positions from the design spec for creatures 0-9;
// 10-19 are additional slots in the same scattered style, since the
// original design only ever covered a 10-creature roster.
const SPLASH_SLOTS = [
  { top: 8, left: 10, size: 70 },
  { top: 14, left: 68, size: 60 },
  { top: 26, left: 30, size: 80 },
  { top: 38, left: 74, size: 66 },
  { top: 44, left: 6, size: 64 },
  { top: 56, left: 52, size: 58 },
  { top: 64, left: 16, size: 72 },
  { top: 70, left: 80, size: 56 },
  { top: 80, left: 36, size: 68 },
  { top: 86, left: 62, size: 60 },
  { top: 4, left: 42, size: 50 },
  { top: 10, left: 88, size: 46 },
  { top: 20, left: 4, size: 54 },
  { top: 32, left: 90, size: 50 },
  { top: 48, left: 28, size: 56 },
  { top: 50, left: 86, size: 48 },
  { top: 62, left: 46, size: 52 },
  { top: 74, left: 4, size: 50 },
  { top: 88, left: 12, size: 46 },
  { top: 92, left: 84, size: 44 },
];

function FloatingCreature({ creature, unlocked, slot, delay, mood }) {
  const enter = useRef(new Animated.Value(0)).current;

  useEffect(() => {
    const entrance = Animated.timing(enter, {
      toValue: 1,
      duration: 420,
      delay,
      easing: Easing.out(Easing.back(1.3)),
      useNativeDriver: true,
    });
    entrance.start();
    return () => entrance.stop();
  }, [enter, delay]);

  const size = unlocked ? slot.size : slot.size * 0.75;

  return (
    <Animated.View
      style={{
        position: 'absolute',
        top: `${slot.top}%`,
        left: `${slot.left}%`,
        opacity: Animated.multiply(enter, unlocked ? 0.95 : 0.35),
        transform: [{ scale: enter }],
      }}
    >
      {/* Locked creatures stay still — no bounce/wobble — so the splash
          scatter reads as "these are the ones you haven't earned yet"
          rather than inviting a tap on something not actually playable. */}
      <CreatureThumbnail creature={creature} mood={mood} size={size} locked={!unlocked} animate={unlocked} />
    </Animated.View>
  );
}

export default function SplashScreen({ onFinish, ownedIds = [], creatures = [] }) {
  const insets = useSafeAreaInsets();
  const finished = useRef(false);

  const skip = () => {
    if (finished.current) return;
    finished.current = true;
    onFinish();
  };

  return (
    <Pressable style={styles.flex} onPress={skip}>
      <CandyBackground sparkles sparkleOpacity={1} style={styles.container}>
        {creatures.map((creature, i) => {
          const slot = SPLASH_SLOTS[i % SPLASH_SLOTS.length];
          return (
            <FloatingCreature
              key={creature.id}
              creature={creature}
              unlocked={ownedIds.includes(String(creature.id))}
              slot={slot}
              delay={i * 90}
              mood={MOODS[i % 3]}
            />
          );
        })}

        <View style={styles.center}>
          <Wordmark />
          <HaloText style={styles.tagline}>Squash · Relax · Repeat</HaloText>
        </View>

        <CandyButton label="TAP TO START" onPress={skip} pulse="cta" size="lg" style={{ marginBottom: insets.bottom + 48 }} />
      </CandyBackground>
    </Pressable>
  );
}

// "SQUISH" (gold) over "SQUAD" (pink), wobbling together as one sticker.
function Wordmark() {
  const wob = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(wob, { toValue: 1, duration: 1300, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
        Animated.timing(wob, { toValue: 0, duration: 1300, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
      ])
    );
    loop.start();
    return () => loop.stop();
  }, [wob]);
  const rotate = wob.interpolate({ inputRange: [0, 1], outputRange: ['-3deg', '3deg'] });
  const scale = wob.interpolate({ inputRange: [0, 1], outputRange: [1, 1.05] });
  return (
    <Animated.View style={{ alignItems: 'center', transform: [{ rotate }, { scale }] }}>
      <OutlinedTitle text="SQUISH" fill="gold" size={52} outline={4} />
      <OutlinedTitle text="SQUAD" fill="pink" size={52} outline={4} style={{ marginTop: -14 }} />
    </Animated.View>
  );
}

const styles = StyleSheet.create({
  flex: { flex: 1 },
  container: { flex: 1, alignItems: 'center' },
  center: { flex: 1, alignItems: 'center', justifyContent: 'center' },
  tagline: {
    marginTop: 6,
    fontFamily: candyFonts.bodyHeavy,
    fontSize: 13,
    letterSpacing: 3,
    textTransform: 'uppercase',
  },
});
