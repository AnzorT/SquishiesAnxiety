import React, { useCallback, useEffect, useRef, useState } from 'react';
import { View, Text, Pressable, StyleSheet, Animated, Easing } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Defs, RadialGradient as SvgRadialGradient, Stop, Rect } from 'react-native-svg';
import { squadColors, squadFonts } from '../theme/squadTheme';
import CreatureThumbnail from './CreatureThumbnail';

// The single-card "stage" for Home's carousel — matches the decoded
// "ASMR Creature Squash Game.html" spec exactly. HomeScreen mounts one of
// these per `carouselIndex`, keyed by that index so it remounts (and
// replays its entrance animation) every time the player pages up/down.
//
// This component owns all of the unlock-with-key interaction: the
// hold-to-unlock progress/interval, the locked "no key" wobble, and the
// one-shot "UNLOCKED!" celebration overlay. HomeScreen just tells it
// whether the creature is unlocked / has a key waiting, and gives it the
// three callbacks (onSelectToy, onOpenStore, onUnlockWithKey).

const HOLD_STEP = 0.03;
const HOLD_INTERVAL_MS = 30; // ~1s to fill (0.03 * ~33 ticks)
const CELEBRATION_MS = 1700;
const ENTRANCE_MS = 350;

export default function CreatureCard({ creature, unlocked, hasKey, onSelectToy, onOpenStore, onUnlockWithKey }) {
  // --- card entrance (cardIn: fade + slide-up + scale-in, replayed on mount) ---
  const entranceOpacity = useRef(new Animated.Value(0)).current;
  const entranceY = useRef(new Animated.Value(18)).current;
  const entranceScale = useRef(new Animated.Value(0.97)).current;

  useEffect(() => {
    Animated.parallel([
      Animated.timing(entranceOpacity, { toValue: 1, duration: ENTRANCE_MS, easing: Easing.out(Easing.cubic), useNativeDriver: true }),
      Animated.timing(entranceY, { toValue: 0, duration: ENTRANCE_MS, easing: Easing.out(Easing.cubic), useNativeDriver: true }),
      Animated.timing(entranceScale, { toValue: 1, duration: ENTRANCE_MS, easing: Easing.out(Easing.cubic), useNativeDriver: true }),
    ]).start();
    // Mount-only: a fresh instance is created every time HomeScreen changes
    // `key={carouselIndex}`, so this effect firing on mount IS the replay.
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  // --- hold-to-unlock (locked, has key) ---
  const [unlockProgress, setUnlockProgress] = useState(0);
  const [showUnlockCelebration, setShowUnlockCelebration] = useState(false);
  const holdIntervalRef = useRef(null);
  const progressRef = useRef(0);
  const celebrationTimeoutRef = useRef(null);

  const clearHoldInterval = useCallback(() => {
    if (holdIntervalRef.current) {
      clearInterval(holdIntervalRef.current);
      holdIntervalRef.current = null;
    }
  }, []);

  useEffect(
    () => () => {
      clearHoldInterval();
      if (celebrationTimeoutRef.current) clearTimeout(celebrationTimeoutRef.current);
    },
    [clearHoldInterval]
  );

  const handlePressIn = useCallback(() => {
    if (unlocked || !hasKey) return;
    clearHoldInterval();
    progressRef.current = 0;
    setUnlockProgress(0);
    holdIntervalRef.current = setInterval(() => {
      progressRef.current = Math.min(1, progressRef.current + HOLD_STEP);
      setUnlockProgress(progressRef.current);
      if (progressRef.current >= 1) {
        clearHoldInterval();
        progressRef.current = 0;
        setUnlockProgress(0);
        setShowUnlockCelebration(true);
        onUnlockWithKey(creature.id);
        if (celebrationTimeoutRef.current) clearTimeout(celebrationTimeoutRef.current);
        celebrationTimeoutRef.current = setTimeout(() => setShowUnlockCelebration(false), CELEBRATION_MS);
      }
    }, HOLD_INTERVAL_MS);
  }, [unlocked, hasKey, creature.id, onUnlockWithKey, clearHoldInterval]);

  const handlePressOut = useCallback(() => {
    // Already completed (interval cleared itself) — no partial credit to undo.
    if (!holdIntervalRef.current) return;
    clearHoldInterval();
    progressRef.current = 0;
    setUnlockProgress(0);
  }, [clearHoldInterval]);

  // --- locked-no-key wobble (lockTilt: 0deg -> 9deg -> 0deg, 2.2s loop) ---
  const wobble = useRef(new Animated.Value(0)).current;
  const lockedNoKey = !unlocked && !hasKey;
  const lockedHasKey = !unlocked && hasKey;

  useEffect(() => {
    if (!lockedNoKey) return undefined;
    wobble.setValue(0);
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(wobble, { toValue: 1, duration: 1100, easing: Easing.inOut(Easing.ease), useNativeDriver: true }),
        Animated.timing(wobble, { toValue: 0, duration: 1100, easing: Easing.inOut(Easing.ease), useNativeDriver: true }),
      ])
    );
    loop.start();
    return () => loop.stop();
  }, [lockedNoKey, wobble]);

  const wobbleRotate = wobble.interpolate({ inputRange: [0, 1], outputRange: ['0deg', '9deg'] });

  // --- popIn celebration (scale 0.4 -> 1.12 -> 1, slight rotate, 0.5s) ---
  const popScale = useRef(new Animated.Value(0.4)).current;
  const popRotate = useRef(new Animated.Value(-6)).current;

  useEffect(() => {
    if (!showUnlockCelebration) return;
    popScale.setValue(0.4);
    popRotate.setValue(-6);
    Animated.sequence([
      Animated.timing(popScale, { toValue: 1.12, duration: 220, easing: Easing.out(Easing.cubic), useNativeDriver: true }),
      Animated.timing(popScale, { toValue: 1, duration: 280, easing: Easing.out(Easing.cubic), useNativeDriver: true }),
    ]).start();
    Animated.timing(popRotate, { toValue: 0, duration: 500, easing: Easing.out(Easing.cubic), useNativeDriver: true }).start();
  }, [showUnlockCelebration, popScale, popRotate]);

  const handleInfoPress = useCallback(() => {
    if (unlocked) onSelectToy(creature);
    else if (!hasKey) onOpenStore();
    // else: has key but not yet unlocked — unlock only happens via the
    // hold gesture in the image area, so this is a deliberate no-op.
  }, [unlocked, hasKey, creature, onSelectToy, onOpenStore]);

  const cardBorderColor = unlocked ? `${squadColors.gold}55` : `${squadColors.panelBorder}99`;
  const shaftLeft = 4 + unlockProgress * 32;
  const mood = showUnlockCelebration ? 'celebrate' : unlocked ? 'idle' : 'sleep';

  return (
    <Animated.View
      style={[
        styles.cardOuter,
        { opacity: entranceOpacity, transform: [{ translateY: entranceY }, { scale: entranceScale }] },
      ]}
    >
      <Pressable style={styles.pressableFill} onPress={handleInfoPress}>
      <LinearGradient
        colors={['#2a1650', squadColors.inputBg]}
        start={{ x: 0.15, y: 0 }}
        end={{ x: 0.85, y: 1 }}
        style={[styles.card, { borderColor: cardBorderColor }]}
      >
        <View style={styles.imageArea}>
          <Svg style={StyleSheet.absoluteFill} pointerEvents="none">
            <Defs>
              {/* source: radial-gradient(circle at 50% 30%, rgba(255,255,255,0.06), transparent 70%) */}
              <SvgRadialGradient id="imgAreaGlow" cx="50%" cy="30%" r="75%">
                <Stop offset="0%" stopColor="#ffffff" stopOpacity={0.06} />
                <Stop offset="55%" stopColor="#ffffff" stopOpacity={0.02} />
                <Stop offset="100%" stopColor="#ffffff" stopOpacity={0} />
              </SvgRadialGradient>
            </Defs>
            <Rect x="0" y="0" width="100%" height="100%" fill="url(#imgAreaGlow)" />
          </Svg>
          <CreatureThumbnail creatureId={creature.id} mood={mood} size={110} locked={!unlocked} />
        </View>

        <View style={styles.infoArea}>
          <Text style={styles.cardName} numberOfLines={1}>
            {creature.name}
          </Text>
          <Text style={styles.cardDesc} numberOfLines={2} ellipsizeMode="tail">
            {creature.description}
          </Text>
          <View style={styles.statusRow}>
            {unlocked ? (
              <>
                <Text style={styles.unlockedLabel}>★ UNLOCKED</Text>
                <Text style={styles.tapToPlayLabel}>TAP TO PLAY →</Text>
              </>
            ) : hasKey ? (
              <Text style={styles.keyReadyLabel}>KEY READY</Text>
            ) : (
              <Text style={styles.lockedLabel}>LOCKED — GET KEY →</Text>
            )}
          </View>
        </View>

        {/* Lock / key / celebration sit in an absolute layer over the WHOLE
            card so they read as centred on the card, not just the image area. */}
        {showUnlockCelebration ? (
          <View style={styles.cardOverlay} pointerEvents="none">
            <View style={styles.celebrationGlow} />
            <Animated.Text
              style={[styles.celebrationText, { transform: [{ scale: popScale }, { rotate: popRotate.interpolate({ inputRange: [-6, 0], outputRange: ['-6deg', '0deg'] }) }] }]}
            >
              UNLOCKED!
            </Animated.Text>
          </View>
        ) : lockedNoKey ? (
          <View style={styles.cardOverlay} pointerEvents="none">
            <Animated.View style={{ alignItems: 'center', transform: [{ rotate: wobbleRotate }] }}>
              <View style={styles.padlockShackle} />
              <LinearGradient colors={['#e2e8f0', '#94a3b8']} start={{ x: 0, y: 0 }} end={{ x: 1, y: 1 }} style={styles.padlockBody}>
                <View style={styles.padlockDot} />
              </LinearGradient>
            </Animated.View>
          </View>
        ) : lockedHasKey ? (
          <Pressable style={styles.cardOverlay} onPressIn={handlePressIn} onPressOut={handlePressOut}>
            <View style={styles.keyIconBox}>
              <View style={styles.keyBow} />
              <View style={styles.keyTeeth} />
              <View style={[styles.keyRing, { left: shaftLeft - 8 }]} />
              <LinearGradient
                colors={[squadColors.goldLight, squadColors.goldDeep]}
                start={{ x: 0, y: 0 }}
                end={{ x: 1, y: 0 }}
                style={[styles.keyShaft, { left: shaftLeft }]}
              />
            </View>
            <Text style={styles.holdLabel}>HOLD TO UNLOCK</Text>
            <View style={styles.progressTrack}>
              <LinearGradient
                colors={[squadColors.gold, squadColors.pinkLight]}
                start={{ x: 0, y: 0 }}
                end={{ x: 1, y: 0 }}
                style={[styles.progressFill, { width: `${unlockProgress * 100}%` }]}
              />
            </View>
          </Pressable>
        ) : null}
      </LinearGradient>
      </Pressable>
    </Animated.View>
  );
}

const styles = StyleSheet.create({
  cardOuter: { width: '84%', height: '96%' },
  pressableFill: { flex: 1 },
  card: {
    flex: 1,
    borderRadius: 28,
    borderWidth: 2,
    overflow: 'hidden',
    flexDirection: 'column',
    shadowColor: '#000000',
    shadowOffset: { width: 0, height: 16 },
    shadowOpacity: 0.4,
    shadowRadius: 34,
    elevation: 10,
  },
  imageArea: {
    flex: 60,
    minHeight: 0,
    overflow: 'hidden',
    alignItems: 'center',
    justifyContent: 'center',
    position: 'relative',
  },
  cardOverlay: {
    ...StyleSheet.absoluteFillObject,
    alignItems: 'center',
    justifyContent: 'center',
  },

  // locked, no key
  padlockShackle: {
    width: 26,
    height: 20,
    borderWidth: 6,
    borderColor: '#cbd5e1',
    borderBottomWidth: 0,
    borderTopLeftRadius: 20,
    borderTopRightRadius: 20,
  },
  padlockBody: {
    width: 48,
    height: 38,
    borderRadius: 8,
    alignItems: 'center',
    justifyContent: 'center',
  },
  padlockDot: { width: 8, height: 8, borderRadius: 4, backgroundColor: '#334155' },

  // locked, has key
  keyIconBox: { width: 50, height: 34, position: 'relative' },
  keyBow: {
    position: 'absolute',
    right: 2,
    top: 6,
    width: 14,
    height: 14,
    borderRadius: 7,
    borderWidth: 4,
    borderColor: '#4b2e0f',
    backgroundColor: squadColors.inputBg,
  },
  keyTeeth: { position: 'absolute', right: 14, top: 12, width: 6, height: 5, backgroundColor: '#4b2e0f' },
  keyRing: {
    position: 'absolute',
    top: 9,
    width: 16,
    height: 16,
    borderRadius: 8,
    borderWidth: 4,
    borderColor: squadColors.goldDeep,
  },
  keyShaft: { position: 'absolute', top: 10.5, width: 26, height: 7, borderRadius: 4 },
  holdLabel: {
    marginTop: 10,
    fontFamily: squadFonts.headingBold,
    fontSize: 12,
    color: squadColors.goldLight,
    letterSpacing: 1,
  },
  progressTrack: {
    marginTop: 6,
    width: '70%',
    height: 5,
    borderRadius: 3,
    backgroundColor: squadColors.panelBorder,
    overflow: 'hidden',
  },
  progressFill: { height: '100%', borderRadius: 3 },

  // celebration
  celebrationGlow: {
    position: 'absolute',
    width: '160%',
    height: '160%',
    borderRadius: 999,
    backgroundColor: 'rgba(255,205,60,0.22)',
  },
  celebrationText: {
    fontFamily: squadFonts.headingExtraBold,
    fontSize: 32,
    color: squadColors.goldLight,
  },

  // info area
  infoArea: {
    flex: 40,
    minHeight: 0,
    paddingHorizontal: 16,
    paddingTop: 8,
    paddingBottom: 8,
    flexDirection: 'column',
    overflow: 'hidden',
  },
  cardName: { fontFamily: squadFonts.headingExtraBold, fontSize: 16, color: squadColors.textWhite, lineHeight: 18 },
  cardDesc: { color: '#b7a3e0', fontSize: 11, fontFamily: squadFonts.bodyBold, marginTop: 2, lineHeight: 14 },
  statusRow: {
    marginTop: 'auto',
    paddingTop: 4,
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'space-between',
    flexShrink: 0,
  },
  lockedLabel: { color: '#94a3b8', fontFamily: squadFonts.bodyExtraBold, fontSize: 12, letterSpacing: 1 },
  keyReadyLabel: { color: squadColors.gold, fontFamily: squadFonts.bodyExtraBold, fontSize: 12, letterSpacing: 1 },
  unlockedLabel: { color: squadColors.goldLight, fontFamily: squadFonts.bodyExtraBold, fontSize: 13, letterSpacing: 2 },
  tapToPlayLabel: { color: squadColors.teal, fontFamily: squadFonts.bodyExtraBold, fontSize: 12 },
});
