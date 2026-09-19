import React, { useCallback, useEffect, useRef, useState } from 'react';
import { View, Text, Pressable, StyleSheet, Animated, Easing } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Defs, RadialGradient as SvgRadialGradient, Stop, Rect, Circle, Path } from 'react-native-svg';
import { squadColors, squadFonts } from '../theme/squadTheme';
import CreatureThumbnail from './CreatureThumbnail';

const AnimatedLinearGradient = Animated.createAnimatedComponent(LinearGradient);

// The single creature card shown on Home's "OUR CREATURES" carousel — a
// literal port of the decoded "ASMR Creature Squash Game.html" `isDefaultCard`
// block. HomeScreen mounts exactly one of these at a time, keyed by
// `carouselIndex` so it remounts (and replays its slide-in) on every page.
//
// This component owns the whole unlock-with-key interaction: hold the image
// area and a gold key slides right into the padlock (`keySlideLeft` 2% -> 56%),
// the progress bar fills, and on completion the "UNLOCKED!" burst plays while
// the creature does its `celebrate` bounce. HomeScreen only tells it whether
// the creature is unlocked / has a key waiting.

const HOLD_DURATION_MS = 1000; // ~1s to fill, matching the source's setInterval(…,30) timing
const CELEBRATION_MS = 1700;
const CELEBRATION_FADE_MS = 450; // how long the "UNLOCKED!" screen takes to fade out afterward

// The padlock keyhole, ported 1:1 from the source: a 14x14 disc
// (`border-radius:50%`) over a downward-flaring slot
// (`clip-path:polygon(28% 0, 72% 0, 100% 100%, 0 100%)`, 9x11, bottom-aligned).
// Drawn as SVG so the tapered slot is exact rather than a border-trick guess.
function Keyhole() {
  return (
    <Svg width={13} height={20} viewBox="0 0 14 22">
      <Circle cx={7} cy={7} r={7} fill="#334155" />
      <Path d="M5.02 11 L8.98 11 L11.5 22 L2.5 22 Z" fill="#334155" />
    </Svg>
  );
}

export default function CreatureCard({ creature, unlocked, hasKey, onSelectToy, onOpenStore, onUnlockWithKey }) {
  const lockedNoKey = !unlocked && !hasKey;
  const lockedHasKey = !unlocked && hasKey;

  // --- hold-to-unlock ---
  // Driven by a single Animated.Value ticking at native frame rate via
  // Animated.timing, rather than a setInterval nudging React state every
  // 30ms — the old approach re-rendered (and re-reconciled the whole card,
  // SVG creature included) on every tick, which is what made the bar look
  // stepped/janky instead of smooth.
  const [showCelebration, setShowCelebration] = useState(false);
  const holdProgress = useRef(new Animated.Value(0)).current;
  const holdAnimRef = useRef(null);
  const celebrationTimeoutRef = useRef(null);
  // fades the whole "UNLOCKED!" screen out instead of it cutting off instantly
  const celebrationFade = useRef(new Animated.Value(1)).current;
  const celebrationFadeAnimRef = useRef(null);

  // --- grey -> full-color reveal, crossfaded rather than snapped the instant
  // `unlocked` flips true (which happens the moment the hold completes) ---
  const [colorTransitioning, setColorTransitioning] = useState(false);
  const colorFade = useRef(new Animated.Value(unlocked ? 1 : 0)).current;
  const colorFadeAnimRef = useRef(null);

  useEffect(
    () => () => {
      if (holdAnimRef.current) holdAnimRef.current.stop();
      if (celebrationTimeoutRef.current) clearTimeout(celebrationTimeoutRef.current);
      if (colorFadeAnimRef.current) colorFadeAnimRef.current.stop();
      if (celebrationFadeAnimRef.current) celebrationFadeAnimRef.current.stop();
    },
    []
  );

  const handlePressIn = useCallback(() => {
    if (!lockedHasKey) return;
    if (holdAnimRef.current) holdAnimRef.current.stop();
    holdProgress.setValue(0);
    holdAnimRef.current = Animated.timing(holdProgress, {
      toValue: 1,
      duration: HOLD_DURATION_MS,
      easing: Easing.linear,
      useNativeDriver: false, // drives `left` / `width`, which the native driver can't touch
    });
    holdAnimRef.current.start(({ finished }) => {
      if (!finished) return; // released early — handlePressOut already reset the bar
      setShowCelebration(true);
      celebrationFade.setValue(1);
      onUnlockWithKey(creature.id);

      // Let the "UNLOCKED!" screen register on its own for a beat, then
      // crossfade the creature from grey to full color instead of it
      // snapping the instant `unlocked` flips true.
      setColorTransitioning(true);
      colorFade.setValue(0);
      if (colorFadeAnimRef.current) colorFadeAnimRef.current.stop();
      colorFadeAnimRef.current = Animated.timing(colorFade, {
        toValue: 1,
        duration: 900,
        delay: 450,
        easing: Easing.out(Easing.cubic),
        useNativeDriver: true,
      });
      colorFadeAnimRef.current.start(({ finished: colorFinished }) => {
        if (colorFinished) setColorTransitioning(false);
      });

      if (celebrationTimeoutRef.current) clearTimeout(celebrationTimeoutRef.current);
      celebrationTimeoutRef.current = setTimeout(() => {
        if (celebrationFadeAnimRef.current) celebrationFadeAnimRef.current.stop();
        celebrationFadeAnimRef.current = Animated.timing(celebrationFade, {
          toValue: 0,
          duration: CELEBRATION_FADE_MS,
          easing: Easing.out(Easing.quad),
          useNativeDriver: true,
        });
        celebrationFadeAnimRef.current.start(({ finished: fadeFinished }) => {
          if (fadeFinished) setShowCelebration(false);
        });
      }, CELEBRATION_MS);
    });
  }, [lockedHasKey, creature.id, onUnlockWithKey, holdProgress, celebrationFade, colorFade]);

  const handlePressOut = useCallback(() => {
    if (!holdAnimRef.current) return; // already completed
    holdAnimRef.current.stop();
    holdAnimRef.current = null;
    holdProgress.setValue(0);
  }, [holdProgress]);

  // --- lockTilt wobble (0deg -> 9deg -> 0, 2.2s loop) for the no-key padlock ---
  const wobble = useRef(new Animated.Value(0)).current;
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

  // --- popIn celebration (scale 0.4 -> 1.12 -> 1, rotate -8 -> 0, 0.5s) ---
  const popScale = useRef(new Animated.Value(0.4)).current;
  const popRotate = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    if (!showCelebration) return;
    popScale.setValue(0.4);
    popRotate.setValue(0);
    Animated.sequence([
      Animated.timing(popScale, { toValue: 1.12, duration: 220, easing: Easing.out(Easing.cubic), useNativeDriver: true }),
      Animated.timing(popScale, { toValue: 1, duration: 280, easing: Easing.out(Easing.cubic), useNativeDriver: true }),
    ]).start();
    Animated.timing(popRotate, { toValue: 1, duration: 500, easing: Easing.out(Easing.cubic), useNativeDriver: true }).start();
  }, [showCelebration, popScale, popRotate]);

  const handleCardPress = useCallback(() => {
    if (unlocked) onSelectToy(creature);
    else if (lockedNoKey) onOpenStore();
    // has key, not unlocked → unlock happens via the hold gesture only
  }, [unlocked, lockedNoKey, creature, onSelectToy, onOpenStore]);

  const cardBorderColor = unlocked ? `${squadColors.gold}55` : `${squadColors.panelBorder}99`;
  const mood = showCelebration ? 'celebrate' : unlocked ? 'idle' : 'sleep';
  // Key and padlock both travel toward the stage's center as the hold fills.
  // The padlock's keyhole lands at x=100 (stage-relative) at progress=1
  // (160 - 60). The key's tip (keyRing 22 + keyBitWrap's -3 margin + its
  // 28-wide shaft = 47px past the slider's own left edge) needs to land on
  // that same x=100 at progress=1 and not a moment before — otherwise the
  // two visually overlap well before the hold finishes and it reads as the
  // animation "still going" after they've already touched. Solving
  // 4 + 2*coef + 47 = 100 gives coef ≈ 24.5.
  const keyLeftPct = holdProgress.interpolate({ inputRange: [0, 1], outputRange: ['2%', '26.5%'] });
  const padlockTranslateX = holdProgress.interpolate({ inputRange: [0, 1], outputRange: [0, -60] });
  const progressFillWidth = holdProgress.interpolate({ inputRange: [0, 1], outputRange: ['0%', '100%'] });

  return (
    <LinearGradient
      colors={['#2a1650', squadColors.inputBg]}
      start={{ x: 0.15, y: 0 }}
      end={{ x: 0.85, y: 1 }}
      style={[styles.card, { borderColor: cardBorderColor }]}
    >
      <Pressable style={styles.cardBody} onPress={handleCardPress}>
      <View style={styles.imageArea}>
        <Svg style={StyleSheet.absoluteFill} pointerEvents="none">
          <Defs>
            <SvgRadialGradient id="imgAreaGlow" cx="50%" cy="30%" r="75%">
              <Stop offset="0%" stopColor="#ffffff" stopOpacity={0.06} />
              <Stop offset="55%" stopColor="#ffffff" stopOpacity={0.02} />
              <Stop offset="100%" stopColor="#ffffff" stopOpacity={0} />
            </SvgRadialGradient>
          </Defs>
          <Rect x="0" y="0" width="100%" height="100%" fill="url(#imgAreaGlow)" />
        </Svg>

        {/* size 252 + bleed 16 -> ~190px of visible body, matching the
            design's `<dc-import Creature size="190">` while leaving room for
            antennae / bolts / stems that sit above the 100-unit body box.
            While colorTransitioning, two copies are crossfaded (grey ->
            color) instead of the single copy just snapping its `locked`
            flag the instant `unlocked` turns true. */}
        {colorTransitioning ? (
          <>
            <Animated.View style={[styles.thumbLayer, { opacity: colorFade.interpolate({ inputRange: [0, 1], outputRange: [1, 0] }) }]}>
              <CreatureThumbnail creature={creature} mood={mood} size={252} locked animate bleed={16} />
            </Animated.View>
            <Animated.View style={[styles.thumbLayer, { opacity: colorFade }]}>
              <CreatureThumbnail creature={creature} mood={mood} size={252} locked={false} animate bleed={16} />
            </Animated.View>
          </>
        ) : (
          <CreatureThumbnail creature={creature} mood={mood} size={252} locked={!unlocked} animate bleed={16} />
        )}

        {showCelebration ? (
          <Animated.View style={[styles.overlay, { opacity: celebrationFade }]} pointerEvents="none">
            <View style={styles.celebrationGlow} />
            <Animated.Text
              style={[
                styles.celebrationText,
                { transform: [{ scale: popScale }, { rotate: popRotate.interpolate({ inputRange: [0, 1], outputRange: ['-8deg', '0deg'] }) }] },
              ]}
            >
              UNLOCKED!
            </Animated.Text>
          </Animated.View>
        ) : lockedNoKey ? (
          <View style={styles.overlay} pointerEvents="none">
            <Animated.View style={{ alignItems: 'center', transform: [{ rotate: wobbleRotate }] }}>
              <View style={styles.padlockShackle} />
              <LinearGradient colors={['#e2e8f0', '#94a3b8']} start={{ x: 0, y: 0 }} end={{ x: 1, y: 1 }} style={styles.padlockBody}>
                <Keyhole />
              </LinearGradient>
            </Animated.View>
          </View>
        ) : lockedHasKey ? (
          <Pressable style={styles.overlay} onPressIn={handlePressIn} onPressOut={handlePressOut}>
            <View style={styles.keyStage}>
              {/* padlock starts parked on the right, then slides in to meet the key */}
              <Animated.View style={[styles.keyStagePadlock, { transform: [{ translateX: padlockTranslateX }] }]}>
                <View style={styles.padlockShackle} />
                <LinearGradient colors={['#e2e8f0', '#94a3b8']} start={{ x: 0, y: 0 }} end={{ x: 1, y: 1 }} style={styles.padlockBody}>
                  <Keyhole />
                </LinearGradient>
              </Animated.View>
              {/* key that slides right into it as the hold fills */}
              <Animated.View style={[styles.keySlider, { left: keyLeftPct }]}>
                <View style={styles.keyRing} />
                <View style={styles.keyBitWrap}>
                  <LinearGradient
                    colors={[squadColors.gold, squadColors.goldDeep]}
                    start={{ x: 0, y: 0 }}
                    end={{ x: 1, y: 0 }}
                    style={styles.keyShaft}
                  />
                  <View style={styles.keyTooth1} />
                  <View style={styles.keyTooth2} />
                </View>
              </Animated.View>
            </View>
            <Text style={styles.holdLabel}>HOLD TO UNLOCK</Text>
            <View style={styles.progressTrack}>
              <AnimatedLinearGradient
                colors={[squadColors.gold, squadColors.pinkLight]}
                start={{ x: 0, y: 0 }}
                end={{ x: 1, y: 0 }}
                style={[styles.progressFill, { width: progressFillWidth }]}
              />
            </View>
          </Pressable>
        ) : null}
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
          ) : lockedHasKey ? (
            <Text style={styles.keyReadyLabel}>KEY READY</Text>
          ) : (
            <Text style={styles.lockedLabel}>LOCKED — GET KEY →</Text>
          )}
        </View>
      </View>
      </Pressable>
    </LinearGradient>
  );
}

const styles = StyleSheet.create({
  card: {
    width: '84%',
    maxWidth: 340,
    height: '96%',
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
  // the whole card surface is one tap target (open toy / open store); the
  // key-ready hold gesture still lives on its own overlay inside the image area.
  cardBody: { flex: 1, flexDirection: 'column' },
  // image area grows; info area is a fixed 82px strip (source: `flex:60` on
  // the image div, `flex:0 0 82px` on the info div).
  imageArea: {
    flex: 1,
    minHeight: 0,
    overflow: 'hidden',
    alignItems: 'center',
    justifyContent: 'center',
    position: 'relative',
  },
  overlay: { ...StyleSheet.absoluteFillObject, alignItems: 'center', justifyContent: 'center' },
  // stacked during the grey->color crossfade so both copies sit in the same spot
  thumbLayer: { ...StyleSheet.absoluteFillObject, alignItems: 'center', justifyContent: 'center' },

  // shared padlock (source: 34x26 shackle, 62x49 body — scaled to ~0.9)
  padlockShackle: {
    width: 30,
    height: 23,
    borderWidth: 6,
    borderColor: '#cbd5e1',
    borderBottomWidth: 0,
    borderTopLeftRadius: 23,
    borderTopRightRadius: 23,
  },
  padlockBody: {
    width: 56,
    height: 44,
    borderRadius: 9,
    alignItems: 'center',
    justifyContent: 'center',
  },

  // hold-to-unlock key stage (source: 150x78 relative box)
  keyStage: { width: 200, height: 84, position: 'relative', alignItems: 'center' },
  keyStagePadlock: { position: 'absolute', right: 12, top: 0, alignItems: 'center' },
  keySlider: { position: 'absolute', top: 30, flexDirection: 'row', alignItems: 'center' }, // 10dp up from 40 to line up with the padlock's keyhole
  keyRing: {
    width: 22,
    height: 22,
    borderRadius: 11,
    borderWidth: 5,
    borderColor: squadColors.gold,
    backgroundColor: 'transparent',
  },
  keyBitWrap: { position: 'relative', width: 30, height: 20, marginLeft: -3 },
  keyShaft: { position: 'absolute', left: 0, top: 8, width: 28, height: 4, borderTopRightRadius: 1, borderBottomRightRadius: 1 },
  keyTooth1: { position: 'absolute', right: 13, top: 10, width: 3, height: 7, backgroundColor: squadColors.gold },
  keyTooth2: { position: 'absolute', right: 5, top: 9, width: 4, height: 12, borderRadius: 1, backgroundColor: squadColors.goldDeep },

  holdLabel: { marginTop: 10, fontFamily: squadFonts.headingBold, fontSize: 12, color: squadColors.goldLight, letterSpacing: 1 },
  progressTrack: {
    marginTop: 6,
    width: '70%',
    height: 5,
    borderRadius: 3,
    backgroundColor: squadColors.panelBorder,
    overflow: 'hidden',
  },
  progressFill: { height: '100%', borderRadius: 3 },

  celebrationGlow: {
    position: 'absolute',
    width: '160%',
    height: '160%',
    borderRadius: 999,
    backgroundColor: 'rgba(255,205,60,0.22)',
  },
  celebrationText: { fontFamily: squadFonts.headingExtraBold, fontSize: 32, color: squadColors.goldLight },

  infoArea: {
    height: 82,
    flexShrink: 0,
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
