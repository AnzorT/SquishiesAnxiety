import React, { useEffect, useRef, useState } from 'react';
import { View, Text, StyleSheet, Animated } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { squadColors, squadFonts } from '../theme/squadTheme';
import SquishyThumbnail from '../components/SquishyThumbnail';

// Brief "getting the toy ready" beat between picking a card on Home and
// SquishScreen actually mounting — matches the prototype's loading screen
// timing (dots, then a "I AM READY!" bubble, then a fade to the toy).

const PREP_MS = 1500;
const READY_MS = 1000;
const FADE_MS = 500;

function Dot({ delay }) {
  const bounce = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const loop = Animated.loop(
      Animated.sequence([
        Animated.delay(delay),
        Animated.timing(bounce, { toValue: 1, duration: 300, useNativeDriver: true }),
        Animated.timing(bounce, { toValue: 0, duration: 400, useNativeDriver: true }),
        Animated.delay(300 - delay),
      ])
    );
    loop.start();
    return () => loop.stop();
  }, [bounce, delay]);
  const translateY = bounce.interpolate({ inputRange: [0, 1], outputRange: [0, -6] });
  return <Animated.View style={[styles.dot, { transform: [{ translateY }] }]} />;
}

export default function LoadingScreen({ creature, onFinish }) {
  const [stage, setStage] = useState('prep');
  const opacity = useRef(new Animated.Value(1)).current;

  useEffect(() => {
    const t1 = setTimeout(() => setStage('ready'), PREP_MS);
    const t2 = setTimeout(() => {
      Animated.timing(opacity, { toValue: 0, duration: FADE_MS, useNativeDriver: true }).start();
    }, PREP_MS + READY_MS);
    const t3 = setTimeout(onFinish, PREP_MS + READY_MS + FADE_MS);
    return () => {
      clearTimeout(t1);
      clearTimeout(t2);
      clearTimeout(t3);
    };
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  return (
    <Animated.View style={[styles.flex, { opacity }]}>
      <LinearGradient colors={['#241250', '#100823']} start={{ x: 0, y: 0 }} end={{ x: 0, y: 1 }} style={styles.container}>
        <SquishyThumbnail colorHex={creature?.colors?.[0] ?? squadColors.pinkLight} species={creature?.species} size={170} />
        {stage === 'prep' ? (
          <View style={styles.prepRow}>
            <Text style={styles.prepText}>Getting Ready</Text>
            <View style={styles.dots}>
              <Dot delay={0} />
              <Dot delay={150} />
              <Dot delay={300} />
            </View>
          </View>
        ) : (
          <View style={styles.readyBubble}>
            <Text style={styles.readyText}>I AM READY!</Text>
          </View>
        )}
      </LinearGradient>
    </Animated.View>
  );
}

const styles = StyleSheet.create({
  flex: { flex: 1 },
  container: { flex: 1, alignItems: 'center', justifyContent: 'center' },
  prepRow: { marginTop: 26, flexDirection: 'row', alignItems: 'center', gap: 10 },
  prepText: { color: squadColors.textMutedLavender, fontFamily: squadFonts.bodyExtraBold, fontSize: 14, letterSpacing: 0.5 },
  dots: { flexDirection: 'row', gap: 4 },
  dot: { width: 6, height: 6, borderRadius: 3, backgroundColor: squadColors.pinkLight },
  readyBubble: {
    marginTop: 22,
    backgroundColor: '#ffffff',
    paddingHorizontal: 26,
    paddingVertical: 12,
    borderRadius: 20,
    borderBottomLeftRadius: 4,
  },
  readyText: { color: squadColors.bgDeepest, fontFamily: squadFonts.headingExtraBold, fontSize: 18 },
});
