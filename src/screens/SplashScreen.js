import React, { useEffect, useRef } from 'react';
import { View, Text, StyleSheet, Pressable, Animated, Easing } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { squadColors, squadGradients, squadFonts } from '../theme/squadTheme';
import SquishyThumbnail from '../components/SquishyThumbnail';
import GradientButton from '../components/squad/GradientButton';

// First thing shown on launch — a scattered field of every creature in the
// catalog (owned ones bright and full-size, locked ones dim and smaller, as
// a collection teaser) behind the logo, mirroring the prototype's splash
// exactly. Auto-advances to auth/home after a beat, but a tap anywhere — or
// the pulsing CTA — skips straight there.

const AUTO_ADVANCE_MS = 2600;

// Percent-of-screen positions for up to 6 creatures, spread so nothing sits
// under the centered title/button column.
const SPLASH_SLOTS = [
  { top: 9, left: 10, size: 74 },
  { top: 15, left: 66, size: 60 },
  { top: 30, left: 32, size: 84 },
  { top: 47, left: 76, size: 60 },
  { top: 60, left: 12, size: 68 },
  { top: 68, left: 56, size: 54 },
];

function FloatingCreature({ creature, unlocked, slot, delay }) {
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
      <SquishyThumbnail colorHex={creature.colors?.[0] ?? squadColors.pinkLight} species={creature.species} size={size} />
    </Animated.View>
  );
}

export default function SplashScreen({ onFinish, creatures = [], ownedIds = [] }) {
  const insets = useSafeAreaInsets();
  const finished = useRef(false);

  useEffect(() => {
    const timer = setTimeout(() => {
      if (!finished.current) {
        finished.current = true;
        onFinish();
      }
    }, AUTO_ADVANCE_MS);
    return () => clearTimeout(timer);
  }, [onFinish]);

  const skip = () => {
    if (finished.current) return;
    finished.current = true;
    onFinish();
  };

  return (
    <Pressable style={styles.flex} onPress={skip}>
      <LinearGradient colors={squadGradients.splashBg.colors} start={squadGradients.splashBg.start} end={squadGradients.splashBg.end} style={styles.container}>
        {creatures.slice(0, SPLASH_SLOTS.length).map((creature, i) => (
          <FloatingCreature
            key={creature.id}
            creature={creature}
            unlocked={ownedIds.includes(creature.id)}
            slot={SPLASH_SLOTS[i]}
            delay={i * 90}
          />
        ))}

        <View style={styles.center}>
          <Text style={styles.title}>PLUSH{'\n'}CRUSH</Text>
          <Text style={styles.tagline}>Squish · Collect · Combo</Text>
        </View>

        <GradientButton
          label="TAP TO START"
          onPress={skip}
          pulse
          colors={squadGradients.ctaPink.colors}
          start={squadGradients.ctaPink.start}
          end={squadGradients.ctaPink.end}
          shadowColor={squadColors.pink}
          textColor="#ffffff"
          fontSize={19}
          pillStyle={styles.cta}
          style={{ marginBottom: insets.bottom + 40 }}
        />
      </LinearGradient>
    </Pressable>
  );
}

const styles = StyleSheet.create({
  flex: { flex: 1 },
  container: { flex: 1, alignItems: 'center', overflow: 'hidden' },
  center: { flex: 1, alignItems: 'center', justifyContent: 'center' },
  title: {
    fontFamily: squadFonts.headingExtraBold,
    fontSize: 52,
    lineHeight: 50,
    textAlign: 'center',
    color: squadColors.goldLight,
    letterSpacing: 1,
    textShadowColor: 'rgba(0,0,0,0.35)',
    textShadowOffset: { width: 0, height: 6 },
    textShadowRadius: 0,
  },
  tagline: {
    marginTop: 10,
    fontFamily: squadFonts.bodyExtraBold,
    fontSize: 13,
    letterSpacing: 3,
    textTransform: 'uppercase',
    color: squadColors.textLavender,
  },
  cta: { paddingHorizontal: 44 },
});
