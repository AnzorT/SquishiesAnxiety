import React, { memo, useCallback, useEffect, useRef, useState } from 'react';
import { View, Text, Pressable, StyleSheet, Animated, Easing } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Defs, Pattern, Circle, Rect, RadialGradient, Stop, Path } from 'react-native-svg';
import { candyColors, candyFonts, BUTTON_VARIANTS, tierOf } from '../theme/candyTheme';
import CreatureThumbnail from './CreatureThumbnail';
import { CandyCard, Pedestal, RaysSpin, TierChip, CandyProgress } from './candy/Decor';
import { CandyPill, Shine } from './candy/CandyButton';
import { KeyIcon } from './candy/RoundButton';
import { Twinkle } from './candy/Sparkles';
import OutlinedTitle from './candy/OutlinedTitle';
import ShadowText, { outline3 } from './candy/ShadowText';
import CreatureToken from './candy/Tokens';
import { tokenPrice } from '../economy';
import { CARD_SIZE } from './CardPager';
import sfx from '../audio/sfx';

const AnimatedLinearGradient = Animated.createAnimatedComponent(LinearGradient);

// The single creature card shown on Home's "OUR CREATURES" carousel — the v3
// card: a white-rimmed pink card, the creature standing on a gold pedestal
// under slowly spinning light rays, name as a pink sticker title with its
// rarity chip, and a candy status row (its tokens so far + UNLOCK /
// HOLD TO UNLOCK / ★ OWNED + PLAY ▶). HomeScreen mounts one per page.
// Tapping a locked card opens the unlock choices (UnlockSheet).
//
// This component owns the whole unlock-with-key interaction: hold the image
// area and a gold key slides into a pink padlock (which shakes, then pops its
// shackle), the progress bar fills, and on completion the gold "UNLOCKED!"
// burst plays while the creature does its `celebrate` bounce. HomeScreen only
// tells it whether the creature is unlocked / has a key waiting.

const HOLD_DURATION_MS = 1000;
const CELEBRATION_MS = 1700;
const CELEBRATION_FADE_MS = 450;
const BLEED = 16;
const BLEED_RATIO = (100 + BLEED * 2) / 100;

// ---- padlocks ----------------------------------------------------------

// The purple padlock's gold keyhole, as one shape — the round top and the
// slot below it — so its white rim and thin brown edge run all the way
// round. (Built from two views, the slot had no rim and covered the bottom
// of the circle's, leaving a bare gold line.)
const KEYHOLE = 'M10.25 17.26 A6.5 6.5 0 1 1 13.75 17.26 L13.75 24.25 A1.75 1.75 0 0 1 10.25 24.25 Z';

function GoldKeyhole() {
  return (
    <Svg width={24} height={32} style={styles.goldHole}>
      <Defs>
        <RadialGradient id="keyholeGold" cx="10" cy="8.5" r="12" gradientUnits="userSpaceOnUse">
          <Stop offset="0" stopColor="#fff7b0" />
          <Stop offset="0.6" stopColor="#ffc233" />
          <Stop offset="1" stopColor="#e08a00" />
        </RadialGradient>
      </Defs>
      <Path d={KEYHOLE} fill="none" stroke="#9c4d06" strokeWidth={7} strokeLinejoin="round" />
      <Path d={KEYHOLE} fill="none" stroke="#ffffff" strokeWidth={4} strokeLinejoin="round" />
      <Path d={KEYHOLE} fill="url(#keyholeGold)" />
    </Svg>
  );
}

function Padlock({ variant = 'purple', scale = 1, shackleLift }) {
  const purple = variant === 'purple';
  const w = purple ? 74 : 66;
  const h = purple ? 92 : 84;
  const shackleW = purple ? 44 : 40;
  const shackleH = purple ? 40 : 34;
  const shackleB = purple ? 8 : 7;
  const bodyTop = purple ? 32 : 28;
  const bodyH = purple ? 60 : 54;
  const v = purple ? BUTTON_VARIANTS.purple : BUTTON_VARIANTS.pink;
  return (
    <View style={{ width: w * scale, height: h * scale, alignItems: 'center', justifyContent: 'center' }}>
      <View style={{ width: w, height: h, transform: [{ scale }] }}>
        <Animated.View
          style={{
            position: 'absolute',
            top: 0,
            left: (w - shackleW) / 2,
            width: shackleW,
            height: shackleH,
            transform: shackleLift ? [{ translateY: shackleLift }] : [],
          }}
        >
          <View style={[styles.shackle, styles.shackleRing, { borderWidth: shackleB + 5, borderTopLeftRadius: shackleW, borderTopRightRadius: shackleW }]} />
          <View style={[styles.shackle, { borderWidth: shackleB, borderTopLeftRadius: shackleW, borderTopRightRadius: shackleW }]} />
        </Animated.View>
        <View style={[styles.lockLip, { top: bodyTop + 5, height: bodyH, borderRadius: purple ? 18 : 16, backgroundColor: v.ring }]} />
        <View style={[styles.lockRing, { top: bodyTop, height: bodyH, borderRadius: purple ? 18 : 16, backgroundColor: v.ring }]}>
          <LinearGradient colors={v.colors} locations={v.locations} style={[styles.lockBody, { borderRadius: purple ? 16 : 14 }]}>
            <Shine />
            {purple ? (
              <GoldKeyhole />
            ) : (
              <View style={styles.darkHole}>
                <View style={styles.darkHoleDisc} />
                <View style={styles.darkHoleStem} />
              </View>
            )}
          </LinearGradient>
        </View>
      </View>
    </View>
  );
}

// The image-area backdrop: pink→lilac, a faint dot grid, a white glow where
// the creature stands.
function ImageBackdrop() {
  return (
    <>
      <LinearGradient colors={['#ffc2ec', '#e79cff']} style={StyleSheet.absoluteFill} />
      <Svg style={StyleSheet.absoluteFill} width="100%" height="100%">
        <Defs>
          <Pattern id="cardDots" x="0" y="0" width="16" height="16" patternUnits="userSpaceOnUse">
            <Circle cx="8" cy="8" r="1.1" fill="#ffffff" fillOpacity={0.9} />
          </Pattern>
          <RadialGradient id="cardGlow" cx="50%" cy="42%" r="60%">
            <Stop offset="0" stopColor="#ffffff" stopOpacity={1} />
            <Stop offset="0.28" stopColor="#ffffff" stopOpacity={0.6} />
            <Stop offset="1" stopColor="#ffffff" stopOpacity={0} />
          </RadialGradient>
          <RadialGradient id="cardShade" cx="50%" cy="0%" r="110%">
            <Stop offset="0.75" stopColor="#a028c8" stopOpacity={0} />
            <Stop offset="1" stopColor="#a028c8" stopOpacity={0.25} />
          </RadialGradient>
        </Defs>
        <Rect x="0" y="0" width="100%" height="100%" fill="url(#cardDots)" />
        <Rect x="0" y="0" width="100%" height="100%" fill="url(#cardGlow)" />
        <Rect x="0" y="0" width="100%" height="100%" fill="url(#cardShade)" />
      </Svg>
    </>
  );
}

function CreatureCard({ creature, unlocked, hasKey, tokens = 0, onSelectToy, onShowUnlock, onUnlockWithKey }) {
  const lockedNoKey = !unlocked && !hasKey;
  const lockedHasKey = !unlocked && hasKey;
  const tier = tierOf(creature.id);
  const [imgBox, setImgBox] = useState({ w: 0, h: 0 });

  // --- hold-to-unlock ---
  // Driven by a single Animated.Value ticking at native frame rate via
  // Animated.timing, rather than a setInterval nudging React state — so the
  // bar and key glide instead of stepping.
  const [showCelebration, setShowCelebration] = useState(false);
  const holdProgress = useRef(new Animated.Value(0)).current;
  const holdAnimRef = useRef(null);
  const celebrationTimeoutRef = useRef(null);
  const celebrationFade = useRef(new Animated.Value(1)).current;
  const celebrationFadeAnimRef = useRef(null);
  // padlock shakes (boxShake) while the hold is running
  const shake = useRef(new Animated.Value(0)).current;
  const shakeLoopRef = useRef(null);

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
      if (shakeLoopRef.current) shakeLoopRef.current.stop();
    },
    []
  );

  const stopShake = useCallback(() => {
    if (shakeLoopRef.current) shakeLoopRef.current.stop();
    shakeLoopRef.current = null;
    shake.setValue(0);
  }, [shake]);

  // The design's hold sound: a hum whose pitch climbs with the hold
  // (260 → 960 Hz, played by speeding up the loop) and a little note every
  // 10%.
  const holdSoundRef = useRef(null);
  const stopHoldSound = useCallback(() => {
    const h = holdSoundRef.current;
    holdSoundRef.current = null;
    if (!h) return;
    holdProgress.removeListener(h.listener);
    h.loop.stop();
  }, [holdProgress]);
  useEffect(() => stopHoldSound, [stopHoldSound]);

  const handlePressIn = useCallback(() => {
    if (!lockedHasKey) return;
    if (holdAnimRef.current) holdAnimRef.current.stop();
    holdProgress.setValue(0);
    stopHoldSound();
    const hum = sfx.loop('holdLoop', { volume: 0.42 });
    let lastStep = 0;
    let lastRate = 1;
    const listener = holdProgress.addListener(({ value: p }) => {
      const rate = (260 + p * 700) / 260;
      // the listener runs every frame; only send real changes to the player
      if (Math.abs(rate - lastRate) > 0.04) {
        lastRate = rate;
        hum.setRate(rate);
        hum.setVolume((0.05 + p * 0.07) / 0.12);
      }
      const step = Math.floor(p * 10);
      if (step > lastStep) {
        lastStep = step;
        sfx.play('holdStep', { rate });
      }
    });
    holdSoundRef.current = { loop: hum, listener };
    shakeLoopRef.current = Animated.loop(Animated.timing(shake, { toValue: 1, duration: 500, easing: Easing.linear, useNativeDriver: true }));
    shakeLoopRef.current.start();
    holdAnimRef.current = Animated.timing(holdProgress, {
      toValue: 1,
      duration: HOLD_DURATION_MS,
      easing: Easing.linear,
      useNativeDriver: false, // drives `left` / `width`, which the native driver can't touch
    });
    holdAnimRef.current.start(({ finished }) => {
      if (!finished) return; // released early — handlePressOut already reset the bar
      holdAnimRef.current = null;
      stopShake();
      stopHoldSound();
      sfx.play('unlock');
      setShowCelebration(true);
      celebrationFade.setValue(1);
      onUnlockWithKey(creature.id);

      // Let the "UNLOCKED!" burst register on its own for a beat, then
      // crossfade the creature from locked to full color.
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
  }, [lockedHasKey, creature.id, onUnlockWithKey, holdProgress, celebrationFade, colorFade, shake, stopShake, stopHoldSound]);

  const handlePressOut = useCallback(() => {
    if (!holdAnimRef.current) return; // already completed
    holdAnimRef.current.stop();
    holdAnimRef.current = null;
    holdProgress.setValue(0);
    stopShake();
    stopHoldSound();
  }, [holdProgress, stopShake, stopHoldSound]);

  // --- popIn for "UNLOCKED!" (scale 0.4 -> 1.12 -> 1, rotate -8 -> 0) ---
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

  // --- lockTilt (0 -> 9deg, 2.2s) for the no-key padlock ---
  const tilt = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    if (!lockedNoKey) return undefined;
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(tilt, { toValue: 1, duration: 1100, easing: Easing.inOut(Easing.ease), useNativeDriver: true }),
        Animated.timing(tilt, { toValue: 0, duration: 1100, easing: Easing.inOut(Easing.ease), useNativeDriver: true }),
      ])
    );
    loop.start();
    return () => loop.stop();
  }, [lockedNoKey, tilt]);
  const tiltRotate = tilt.interpolate({ inputRange: [0, 1], outputRange: ['0deg', '9deg'] });

  const handleCardPress = useCallback(() => {
    if (unlocked) onSelectToy(creature);
    else if (lockedNoKey) onShowUnlock(creature);
    // has key, not unlocked → unlock happens via the hold gesture only
  }, [unlocked, lockedNoKey, creature, onSelectToy, onShowUnlock]);

  const mood = showCelebration ? 'celebrate' : unlocked ? 'idle' : 'sleep';

  // Creature size: the design's min(170px, 100cqh - 34px, 80cqw) of the
  // image area; the thumbnail footprint is bigger by the bleed margin (only
  // the older SVG art needs that room — see CreatureThumbnail).
  const body = imgBox.h ? Math.max(60, Math.min(170, imgBox.h - 34, imgBox.w * 0.8)) : 0;
  const thumb = Math.round(body * BLEED_RATIO);
  // fits the padlock / key stage to short cards
  const overlayScale = imgBox.h ? Math.min(1, (imgBox.h - 16) / 150) : 1;

  const keyLeft = holdProgress.interpolate({ inputRange: [0, 1], outputRange: [3, 78] });
  const shackleLift = holdProgress.interpolate({ inputRange: [0, 0.95, 1], outputRange: [0, 0, -8] });
  const shakeRotate = shake.interpolate({ inputRange: [0, 0.2, 0.45, 0.7, 1], outputRange: ['0deg', '-9deg', '8deg', '-4deg', '0deg'] });
  const progressWidth = holdProgress.interpolate({ inputRange: [0, 1], outputRange: ['0%', '100%'] });

  const renderThumb = (locked) => <CreatureThumbnail creature={creature} mood={mood} size={thumb} locked={locked} animate bleed={BLEED} />;

  return (
    <CandyCard style={styles.card}>
      <Pressable style={styles.cardBody} onPress={handleCardPress}>
        <View style={styles.imageArea} onLayout={(e) => setImgBox({ w: e.nativeEvent.layout.width, h: e.nativeEvent.layout.height })}>
          <ImageBackdrop />
          <RaysSpin size={260} />

          {body > 0 ? (
            <View style={{ width: thumb, height: thumb, marginTop: -6 }}>
              {/* 130% of the creature wide, its bottom edge 10px below the
                  creature's box (the design's bottom:-10px) */}
              <View style={[styles.pedestalWrap, { top: (thumb + body) / 2 + 10 - 22 - 2 }]}>
                <Pedestal width={body * 1.3} height={22} />
              </View>
              {colorTransitioning ? (
                <>
                  <Animated.View style={[StyleSheet.absoluteFill, { opacity: colorFade.interpolate({ inputRange: [0, 1], outputRange: [1, 0] }) }]}>
                    {renderThumb(true)}
                  </Animated.View>
                  <Animated.View style={[StyleSheet.absoluteFill, { opacity: colorFade }]}>{renderThumb(false)}</Animated.View>
                </>
              ) : (
                renderThumb(!unlocked)
              )}
            </View>
          ) : null}

          {showCelebration ? (
            <Animated.View style={[styles.overlay, { opacity: celebrationFade }]} pointerEvents="none">
              <LinearGradient
                colors={['rgba(255,240,170,0)', 'rgba(255,205,60,0.35)', 'rgba(255,240,170,0.75)', 'rgba(255,205,60,0.35)', 'rgba(255,240,170,0)']}
                style={StyleSheet.absoluteFill}
              />
              <RaysSpin size={300} durationMs={6000} rayDeg={9} gapDeg={13} opacity={0.6} fadeStart={0.12} fadeEnd={0.62} />
              <Animated.View
                style={{ transform: [{ scale: popScale }, { rotate: popRotate.interpolate({ inputRange: [0, 1], outputRange: ['-8deg', '0deg'] }) }] }}
              >
                <OutlinedTitle text="UNLOCKED!" fill="gold" size={32} />
              </Animated.View>
            </Animated.View>
          ) : lockedNoKey ? (
            <View style={[styles.overlay, styles.lockedTint]} pointerEvents="none">
              <Animated.View style={{ transform: [{ rotate: tiltRotate }] }}>
                <Padlock variant="purple" scale={Math.min(1, overlayScale * 1.4)} />
              </Animated.View>
              <View style={styles.lockSparkle}>
                <Twinkle size={14} duration={1.8} />
              </View>
            </View>
          ) : lockedHasKey ? (
            <Pressable style={[styles.overlay, styles.keyTint]} onPressIn={handlePressIn} onPressOut={handlePressOut}>
              <View style={{ alignItems: 'center', transform: [{ scale: overlayScale }] }}>
                <View style={styles.keyStage}>
                  <Animated.View style={[styles.keyStageLock, { transform: [{ rotate: shakeRotate }] }]}>
                    <Padlock variant="pink" shackleLift={shackleLift} />
                  </Animated.View>
                  <Animated.View style={[styles.keySlider, { left: keyLeft }]}>
                    <View style={styles.keyGlow}>
                      <KeyIcon width={54} />
                    </View>
                  </Animated.View>
                </View>
                <ShadowText style={styles.holdLabel} shadows={HOLD_LABEL_SHADOWS}>
                  HOLD TO UNLOCK
                </ShadowText>
                <CandyProgress
                  height={14}
                  ring={candyColors.pinkRing}
                  fill={['#fff7b0', '#ffc233']}
                  animatedWidth={progressWidth}
                  style={styles.holdBar}
                />
              </View>
            </Pressable>
          ) : null}
        </View>

        <View style={styles.infoArea}>
          <View style={styles.nameRow}>
            <OutlinedTitle text={creature.name} fill="pink" size={21} outline={2} ring={1.5} drop={3} letterSpacing={0} style={styles.nameTitle} />
            {tier ? <TierChip tier={tier} /> : null}
          </View>
          <Text style={styles.cardDesc} numberOfLines={1} ellipsizeMode="tail">
            {creature.description}
          </Text>
          <View style={styles.statusRow}>
            {unlocked ? (
              <>
                <ShadowText style={styles.ownedLabel} shadows={outline3(candyColors.goldRing)}>
                  ★ OWNED
                </ShadowText>
                <CandyPill variant="blue" label="PLAY ▶" pulse fontSize={13} padV={5} padH={16} letterSpacing={0.8} />
              </>
            ) : lockedHasKey ? (
              <CandyPill variant="gold" label="HOLD TO UNLOCK" pulse halfMs={600} fontSize={12} padV={4} padH={12} letterSpacing={0.6} />
            ) : (
              <>
                <View style={styles.tokenRow}>
                  <CreatureToken creature={creature} size={22} />
                  <Text style={styles.tokenText}>{`${tokens.toLocaleString()}/${tokenPrice(creature.id).toLocaleString()}`}</Text>
                </View>
                <CandyPill variant="pink" label="UNLOCK" pulse fontSize={12} padV={4} padH={14} letterSpacing={0.8} />
              </>
            )}
          </View>
        </View>
      </Pressable>
    </CandyCard>
  );
}

export default memo(CreatureCard);

// the design's white caption outlined 1.5px all round plus a 3px drop
const HOLD_LABEL_SHADOWS = [
  [1.5, 0, '#45189a'],
  [-1.5, 0, '#45189a'],
  [0, 1.5, '#45189a'],
  [0, -1.5, '#45189a'],
  [0, 3, '#45189a'],
];

const styles = StyleSheet.create({
  card: CARD_SIZE,
  cardBody: { flex: 1, flexDirection: 'column' },
  imageArea: {
    flex: 1,
    minHeight: 0,
    overflow: 'hidden',
    alignItems: 'center',
    justifyContent: 'center',
    borderTopLeftRadius: 24,
    borderTopRightRadius: 24,
    borderBottomLeftRadius: 16,
    borderBottomRightRadius: 16,
    borderWidth: 2,
    borderColor: 'rgba(255,255,255,0.8)',
  },
  pedestalWrap: { position: 'absolute', left: 0, right: 0, alignItems: 'center' },
  overlay: { ...StyleSheet.absoluteFillObject, alignItems: 'center', justifyContent: 'center' },
  lockedTint: { backgroundColor: 'rgba(90,20,150,0.14)' },
  keyTint: { backgroundColor: 'rgba(90,20,150,0.22)' },
  lockSparkle: { position: 'absolute', top: '32%', right: '30%' },

  shackle: { ...StyleSheet.absoluteFillObject, borderColor: '#ffffff', borderBottomWidth: 0 },
  shackleRing: { left: -2.5, top: -2.5, right: -2.5, borderColor: '#45189a' },
  lockLip: { position: 'absolute', left: 0, right: 0 },
  lockRing: { position: 'absolute', left: 0, right: 0, padding: 2.5 },
  lockBody: { flex: 1, borderWidth: 3, borderColor: '#ffffff', overflow: 'hidden', alignItems: 'center', justifyContent: 'center' },
  goldHole: { marginTop: 2 },
  darkHole: { width: 14, height: 22, alignItems: 'center' },
  darkHoleDisc: { width: 14, height: 14, borderRadius: 7, backgroundColor: '#7a0f62' },
  darkHoleStem: { width: 8, height: 12, marginTop: -4, borderBottomLeftRadius: 2, borderBottomRightRadius: 2, backgroundColor: '#7a0f62' },

  keyStage: { width: 170, height: 92 },
  keyStageLock: { position: 'absolute', right: 4, top: 0 },
  keySlider: { position: 'absolute', top: 46 },
  keyGlow: { shadowColor: '#ffdc5a', shadowOpacity: 0.9, shadowRadius: 8, shadowOffset: { width: 0, height: 0 } },
  holdLabel: {
    marginTop: 10,
    fontFamily: candyFonts.display,
    fontSize: 16,
    letterSpacing: 1,
    color: '#ffffff',
    includeFontPadding: false,
  },
  holdBar: { width: 128, marginTop: 6 },

  // The sticker title's SVG carries its own outline margin (3.5px round, 3px
  // drop) — pulled back so the letters sit where the design's do.
  infoArea: { paddingHorizontal: 14, paddingTop: 2, paddingBottom: 8 },
  nameRow: { flexDirection: 'row', alignItems: 'center', gap: 4.5 },
  nameTitle: { marginLeft: -3.5, marginTop: -2, marginBottom: -5 },
  cardDesc: { color: candyColors.muted, fontSize: 11, fontFamily: candyFonts.body, marginTop: 2, lineHeight: 14 },
  statusRow: {
    marginTop: 4,
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'space-between',
  },
  tokenRow: { flexDirection: 'row', alignItems: 'center', gap: 6 },
  tokenText: { color: '#d3179a', fontFamily: candyFonts.display, fontSize: 14, includeFontPadding: false },
  ownedLabel: {
    color: '#ffb300',
    fontFamily: candyFonts.display,
    fontSize: 14,
    letterSpacing: 1,
    includeFontPadding: false,
  },
});
