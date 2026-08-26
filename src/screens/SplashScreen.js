import React, { useEffect, useRef } from 'react';
import { View, Text, StyleSheet, Pressable, Animated, Easing } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { squadColors, squadGradients, squadFonts } from '../theme/squadTheme';
import CreatureThumbnail from '../components/CreatureThumbnail';
import GradientButton from '../components/squad/GradientButton';

// First thing shown on launch — matches "ASMR Creature Squash Game.html"'s
// splash exactly: all 10 creatures scattered at fixed percent positions
// (owned ones bright and full-size, locked ones dim and smaller), the
// "SQUISH SQUAD" gradient wordmark, and the pulsing pink CTA. Stays up
// until the player taps — no auto-advance timer.

const MOODS = ['idle', 'jump', 'wobble'];

// Exact percent-of-screen positions from the design spec — one slot per
// creature id (0-9).
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
];

function FloatingCreature({ creatureId, unlocked, slot, delay, mood }) {
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
      <CreatureThumbnail creatureId={creatureId} mood={mood} size={size} locked={!unlocked} />
    </Animated.View>
  );
}

export default function SplashScreen({ onFinish, ownedIds = [] }) {
  const insets = useSafeAreaInsets();
  const finished = useRef(false);

  const skip = () => {
    if (finished.current) return;
    finished.current = true;
    onFinish();
  };

  return (
    <Pressable style={styles.flex} onPress={skip}>
      <LinearGradient colors={squadGradients.splashBg.colors} start={squadGradients.splashBg.start} end={squadGradients.splashBg.end} style={styles.container}>
        {SPLASH_SLOTS.map((slot, i) => (
          <FloatingCreature
            key={i}
            creatureId={String(i)}
            unlocked={ownedIds.includes(String(i))}
            slot={slot}
            delay={i * 90}
            mood={MOODS[i % 3]}
          />
        ))}

        <View style={styles.center}>
          <View>
            <Text style={[styles.title, { color: squadColors.goldLight }]}>SQUISH</Text>
            <Text style={[styles.title, { color: squadColors.goldAmber }]}>SQUAD</Text>
          </View>
          <Text style={styles.tagline}>Squash · Relax · Repeat</Text>
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
    letterSpacing: 1,
    textShadowColor: 'rgba(0,0,0,0.25)',
    textShadowOffset: { width: 0, height: 6 },
    textShadowRadius: 0,
  },
  tagline: {
    marginTop: 10,
    fontFamily: squadFonts.headingExtraBold,
    fontSize: 13,
    letterSpacing: 3,
    textTransform: 'uppercase',
    color: squadColors.textLavender,
  },
  cta: { paddingHorizontal: 44 },
});
