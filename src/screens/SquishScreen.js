import React, { useCallback, useEffect, useRef, useState } from 'react';
import { View, Text, StyleSheet, PanResponder, Animated, Pressable, Easing, Dimensions } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { Canvas } from '@react-three/fiber';
import SquishyToy from '../components/SquishyToy';
import SquishyToy2D from '../components/SquishyToy2D';

// Glorp (id 0) is the one creature rendered from a real Tripo3D mesh; every
// other creature squishes as the 2D design art (see SquishyToy2D).
const MODEL_3D_IDS = new Set(['0']);
import SquishSound from '../audio/SquishSound';
import CoinSound from '../audio/CoinSound';
import PopSound from '../audio/PopSound';
import { squadColors, squadGradients, squadFonts } from '../theme/squadTheme';
import AdBanner from '../components/AdBanner';
import WatchAdButton from '../components/WatchAdButton';

// Squish stage — matches "ASMR Creature Squash Game.html" exactly: a single
// finger both dents the creature *and* slowly spins it while dragging (no
// separate two-finger orbit gesture, see SquishyToy.js), a lump-sum coin
// reward lands on release scaled by how long you held (capped at 60, see
// `rewardForHoldMs`), and every 100-coin milestone crossed pops a fake
// "AD BREAK" interstitial the way the source's addCoins() does. Watching a
// rewarded ad doubles the current coin total outright (source: `addCoins
// (this.state.coins)`) rather than the old build's timed 2x-multiplier
// window.

// The interactive play area (the "square"): a centred box the creature lives
// in. Sized to the device rather than a fixed 220 so the creature reads big
// on a real phone.
const STAGE_SIZE = Math.min(Math.round(Dimensions.get('window').width - 32), 380);
const RIPPLE_LIFETIME_MS = 620;
const REWARD_VISIBLE_MS = 900;
const INTERSTITIAL_CONTINUE_DELAY_MS = 1400;
const DOUBLE_FLASH_MS = 1800;
const SPEED_TAP_WINDOW_MS = 60000;
const SPEED_TAP_THRESHOLD = 60;

const DEFAULT_SQUISH_SOUND = require('../../assets/audio/slime.wav');

function rewardForHoldMs(holdMs) {
  return Math.min(60, Math.round(5 + holdMs / 40));
}

const RIPPLE_MAX = 120;

// A soft ring that blooms out from the exact touch point and fades — the
// tap feedback on the squish stage. Centred on (x, y) via a negative margin
// of half its own final size.
function Ripple({ x, y }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    Animated.timing(t, { toValue: 1, duration: RIPPLE_LIFETIME_MS, easing: Easing.out(Easing.quad), useNativeDriver: true }).start();
  }, [t]);
  const scale = t.interpolate({ inputRange: [0, 1], outputRange: [0.25, 1] });
  const opacity = t.interpolate({ inputRange: [0, 0.15, 1], outputRange: [0, 0.5, 0] });
  return (
    <Animated.View
      pointerEvents="none"
      style={[
        styles.ripple,
        { left: x - RIPPLE_MAX / 2, top: y - RIPPLE_MAX / 2, opacity, transform: [{ scale }] },
      ]}
    />
  );
}

function HandIcon({ color, fingers = 1, anim }) {
  return (
    <Animated.View style={[styles.handIcon, anim]}>
      <View style={[styles.handPalm, { backgroundColor: color }]} />
      {fingers === 1 ? (
        <View style={[styles.handFinger, { backgroundColor: color, left: 9 }]} />
      ) : (
        <>
          <View style={[styles.handFinger, { backgroundColor: color, left: 7, width: 5 }]} />
          <View style={[styles.handFinger, { backgroundColor: color, left: 14, width: 5 }]} />
        </>
      )}
    </Animated.View>
  );
}

function useLoopAnim(config) {
  const anim = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(anim, { toValue: 1, duration: config.duration, easing: Easing.inOut(Easing.ease), useNativeDriver: true }),
        Animated.timing(anim, { toValue: 0, duration: config.duration, easing: Easing.inOut(Easing.ease), useNativeDriver: true }),
      ])
    );
    loop.start();
    return () => loop.stop();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);
  return anim;
}

function SoundSwitch({ value, onToggle }) {
  const anim = useRef(new Animated.Value(value ? 1 : 0)).current;
  useEffect(() => {
    Animated.timing(anim, { toValue: value ? 1 : 0, duration: 150, useNativeDriver: false }).start();
  }, [value, anim]);
  const knobLeft = anim.interpolate({ inputRange: [0, 1], outputRange: [2, 18] });
  return (
    <Pressable onPress={onToggle}>
      <View style={[styles.switchTrack, { backgroundColor: value ? undefined : squadColors.panelBorder }]}>
        {value && (
          <LinearGradient colors={squadGradients.ctaTeal.colors} start={squadGradients.ctaTeal.start} end={squadGradients.ctaTeal.end} style={StyleSheet.absoluteFillObject} />
        )}
        <Animated.View style={[styles.switchKnob, { left: knobLeft }]} />
      </View>
    </Pressable>
  );
}

export default function SquishScreen({
  toy,
  coins = 0,
  onBack,
  onEarnCoins,
  onRecordPress,
  achievements = {},
  onMarkAchievement,
  squishSoundEnabled = true,
  onToggleSquishSound,
  coinSoundEnabled = true,
  onToggleCoinSound,
  releaseSoundEnabled = true,
  onToggleReleaseSound,
}) {
  const insets = useSafeAreaInsets();
  const toyRef = useRef(null);
  const soundRef = useRef(null);
  const coinSoundRef = useRef(null);
  const popSoundRef = useRef(null);
  const lastTouch = useRef({ x: 0, y: 0 });
  const holdStartRef = useRef(0);
  const rippleSeqRef = useRef(0);
  const tapTimestampsRef = useRef([]);
  // 'none' | 'poke' (one finger, squishing) | 'orbit' (two fingers, turning)
  const gestureModeRef = useRef('none');
  const lastCentroidRef = useRef({ x: 0, y: 0 });

  const [displayCoins, setDisplayCoins] = useState(coins);
  const [ripples, setRipples] = useState([]);
  const [showReward, setShowReward] = useState(false);
  const [rewardAmount, setRewardAmount] = useState(0);
  const [rewardKey, setRewardKey] = useState(0);
  const [wheelOpen, setWheelOpen] = useState(false);
  const [interstitial, setInterstitial] = useState(false);
  const [interstitialReady, setInterstitialReady] = useState(false);
  const [doubleFlash, setDoubleFlash] = useState(false);

  const wheelAnim = useRef(new Animated.Value(0)).current;
  const handSway1 = useLoopAnim({ duration: 1400 });
  const handSway2 = useLoopAnim({ duration: 1400 });
  const tapPulseAnim = useLoopAnim({ duration: 900 });

  useEffect(() => {
    const sound = new SquishSound();
    soundRef.current = sound;
    sound.load(DEFAULT_SQUISH_SOUND);
    return () => sound.unload();
  }, []);

  useEffect(() => {
    const sound = new CoinSound();
    coinSoundRef.current = sound;
    sound.load();
    return () => sound.unload();
  }, []);

  useEffect(() => {
    const sound = new PopSound();
    popSoundRef.current = sound;
    sound.load();
    return () => sound.unload();
  }, []);

  useEffect(() => {
    if (!squishSoundEnabled) soundRef.current?.stop();
  }, [squishSoundEnabled]);

  const toggleWheel = useCallback(() => {
    setWheelOpen((open) => {
      const next = !open;
      Animated.timing(wheelAnim, { toValue: next ? 1 : 0, duration: 400, useNativeDriver: true }).start();
      return next;
    });
  }, [wheelAnim]);
  const wheelRotate = wheelAnim.interpolate({ inputRange: [0, 1], outputRange: ['0deg', '180deg'] });

  // The PanResponder below is created exactly once (via useRef) so its
  // touch handlers never see a stale closure over `toyRef`. But that same
  // one-time creation means any *other* reactive value/callback it reads
  // (current coin total, sound toggles, the achievements map, the parent's
  // callback props) would otherwise be frozen at whatever they were on the
  // very first render. `latestRef` is kept in sync on every render (a plain
  // assignment during render is safe here — it never reads its own value
  // mid-render) so those handlers can always read the current value via
  // `latestRef.current.*` instead of capturing a stale one.
  const latestRef = useRef(null);
  latestRef.current = {
    displayCoins,
    achievements,
    releaseSoundEnabled,
    coinSoundEnabled,
    toy,
    onRecordPress,
    onEarnCoins,
    onMarkAchievement,
  };

  const grantReward = useCallback((amount) => {
    const { coinSoundEnabled: coinSoundOn, onEarnCoins: earnCoins } = latestRef.current;
    setDisplayCoins((before) => {
      const after = before + amount;
      if (Math.floor(after / 100) > Math.floor(before / 100)) {
        setInterstitial(true);
        setInterstitialReady(false);
        setTimeout(() => setInterstitialReady(true), INTERSTITIAL_CONTINUE_DELAY_MS);
      }
      return after;
    });
    if (coinSoundOn) coinSoundRef.current?.play();
    earnCoins && earnCoins(amount);
  }, []);

  const handleAdReward = useCallback(() => {
    const { displayCoins: current, achievements: liveAchievements, onMarkAchievement: markAch } = latestRef.current;
    grantReward(current);
    setDoubleFlash(true);
    setTimeout(() => setDoubleFlash(false), DOUBLE_FLASH_MS);
    if (!liveAchievements.watchAd) markAch && markAch('watchAd');
  }, [grantReward]);

  const ndcFromLocation = (locationX, locationY) => ({
    x: (locationX / STAGE_SIZE) * 2 - 1,
    y: -((locationY / STAGE_SIZE) * 2 - 1),
  });

  const spawnRipple = useCallback((locationX, locationY) => {
    const id = ++rippleSeqRef.current;
    // pixel position of the touch inside the stage — the ripple centres on it
    setRipples((prev) => [...prev, { id, x: locationX, y: locationY }]);
    setTimeout(() => setRipples((prev) => prev.filter((r) => r.id !== id)), RIPPLE_LIFETIME_MS);
  }, []);

  const centroidOf = (touches) => {
    let sx = 0;
    let sy = 0;
    for (const t of touches) {
      sx += t.locationX;
      sy += t.locationY;
    }
    return { x: sx / touches.length, y: sy / touches.length };
  };

  const panResponder = useRef(
    PanResponder.create({
      onStartShouldSetPanResponder: () => true,
      onMoveShouldSetPanResponder: () => true,
      onStartShouldSetPanResponderCapture: () => true,
      onMoveShouldSetPanResponderCapture: () => true,
      onPanResponderGrant: (evt) => {
        const touches = evt.nativeEvent.touches || [];
        if (touches.length >= 2) {
          gestureModeRef.current = 'orbit';
          lastCentroidRef.current = centroidOf(touches);
          return;
        }
        gestureModeRef.current = 'poke';
        const { locationX, locationY } = evt.nativeEvent;
        lastTouch.current = { x: locationX, y: locationY };
        holdStartRef.current = Date.now();
        const ndc = ndcFromLocation(locationX, locationY);
        toyRef.current?.pointerDown(ndc.x, ndc.y);
        spawnRipple(locationX, locationY);
      },
      onPanResponderMove: (evt) => {
        const touches = evt.nativeEvent.touches || [];

        if (touches.length >= 2) {
          // Two fingers down — orbit. If a one-finger poke was in progress,
          // drop it (no reward) so the gesture cleanly becomes a rotate.
          if (gestureModeRef.current !== 'orbit') {
            toyRef.current?.cancelPoke();
            gestureModeRef.current = 'orbit';
            lastCentroidRef.current = centroidOf(touches);
            return;
          }
          const c = centroidOf(touches);
          toyRef.current?.orbit(c.x - lastCentroidRef.current.x, c.y - lastCentroidRef.current.y);
          lastCentroidRef.current = c;
          return;
        }

        if (gestureModeRef.current === 'orbit') {
          // Down to one finger but still an orbit gesture — keep turning with
          // the remaining finger instead of suddenly denting the toy.
          if (touches.length === 1) {
            const c = { x: touches[0].locationX, y: touches[0].locationY };
            toyRef.current?.orbit(c.x - lastCentroidRef.current.x, c.y - lastCentroidRef.current.y);
            lastCentroidRef.current = c;
          }
          return;
        }

        const { locationX, locationY } = evt.nativeEvent;
        lastTouch.current = { x: locationX, y: locationY };
        const ndc = ndcFromLocation(locationX, locationY);
        toyRef.current?.pointerMove(ndc.x, ndc.y);
      },
      onPanResponderRelease: () => {
        const mode = gestureModeRef.current;
        gestureModeRef.current = 'none';
        if (mode === 'orbit') {
          toyRef.current?.endOrbit();
          return;
        }
        const result = toyRef.current?.pointerUp();
        if (!result || !result.wasPoke) return;
        const { achievements: liveAchievements, releaseSoundEnabled: releaseSoundOn, toy: currentToy, onRecordPress: recordPress, onMarkAchievement: markAch } = latestRef.current;

        const holdMs = Date.now() - holdStartRef.current;
        const reward = rewardForHoldMs(holdMs);

        const now = Date.now();
        const timestamps = [...tapTimestampsRef.current, now].filter((t) => now - t < SPEED_TAP_WINDOW_MS);
        tapTimestampsRef.current = timestamps;
        if (timestamps.length >= SPEED_TAP_THRESHOLD && !liveAchievements.speedTap) {
          markAch && markAch('speedTap');
        }

        recordPress && recordPress(currentToy.id, holdMs);

        setRewardAmount(reward);
        setShowReward(true);
        setRewardKey((k) => k + 1);
        setTimeout(() => setShowReward(false), REWARD_VISIBLE_MS);
        grantReward(reward);

        soundRef.current?.stop();
        if (releaseSoundOn) popSoundRef.current?.play();
      },
      onPanResponderTerminate: () => {
        gestureModeRef.current = 'none';
        toyRef.current?.endOrbit();
        toyRef.current?.pointerUp();
      },
    })
    // eslint-disable-next-line react-hooks/exhaustive-deps
  ).current;

  return (
    <View style={styles.container}>
      <LinearGradient colors={squadGradients.homeBg.colors} start={squadGradients.homeBg.start} end={squadGradients.homeBg.end} style={styles.stageArea}>
        <View style={[styles.topLeft, { top: insets.top + 14 }]}>
          <Pressable onPress={onBack} style={styles.backButton} hitSlop={8}>
            <Text style={styles.backGlyph}>‹</Text>
          </Pressable>
          <View style={styles.coinPill}>
            <View style={styles.coinDot} />
            <Text style={styles.coinPillText}>{displayCoins}</Text>
          </View>
        </View>

        <Pressable onPress={toggleWheel} style={[styles.wheelButton, { top: insets.top + 14 }]} hitSlop={6}>
          <Animated.View style={{ transform: [{ rotate: wheelRotate }] }}>
            <View style={styles.wheelGlyph} />
          </Animated.View>
        </Pressable>

        <View style={styles.stage} {...panResponder.panHandlers}>
          {MODEL_3D_IDS.has(String(toy.id)) ? (
            <Canvas flat camera={{ fov: 30, position: [0, 0.1, 4.6], near: 0.1, far: 100 }}>
              <ambientLight intensity={0.65} />
              <directionalLight color={0xfff2e0} intensity={1.3} position={[2, 3, 3]} />
              <directionalLight color={0xd8ccff} intensity={0.55} position={[-2.5, -1, 2]} />
              <directionalLight color={0xffffff} intensity={0.35} position={[-1.5, 2, -3]} />
              <SquishyToy
                ref={toyRef}
                creatureId={toy.id}
                onSquish={() => {
                  if (squishSoundEnabled) soundRef.current?.start();
                }}
                onRelease={() => {
                  soundRef.current?.stop();
                }}
              />
            </Canvas>
          ) : (
            <SquishyToy2D
              ref={toyRef}
              creatureId={toy.id}
              size={STAGE_SIZE}
              onSquish={() => {
                if (squishSoundEnabled) soundRef.current?.start();
              }}
              onRelease={() => {
                soundRef.current?.stop();
              }}
            />
          )}

          <View style={StyleSheet.absoluteFillObject} pointerEvents="none">
            {ripples.map((r) => (
              <Ripple key={r.id} x={r.x} y={r.y} />
            ))}
            {showReward && (
              <Text key={rewardKey} style={styles.rewardText}>
                +{rewardAmount}
              </Text>
            )}
          </View>
        </View>

        {wheelOpen && (
          <View style={[styles.wheelPopup, { top: insets.top + 62 }]}>
            <View style={styles.wheelRow}>
              <Text style={styles.wheelLabel}>Sound</Text>
              <SoundSwitch value={squishSoundEnabled} onToggle={() => onToggleSquishSound(!squishSoundEnabled)} />
            </View>
            <View style={styles.wheelRow}>
              <Text style={styles.wheelLabel}>Coin Sound</Text>
              <SoundSwitch value={coinSoundEnabled} onToggle={() => onToggleCoinSound(!coinSoundEnabled)} />
            </View>
            <View style={[styles.wheelRow, styles.wheelRowLast]}>
              <Text style={styles.wheelLabel}>Release Sound</Text>
              <SoundSwitch value={releaseSoundEnabled} onToggle={() => onToggleReleaseSound(!releaseSoundEnabled)} />
            </View>
          </View>
        )}
      </LinearGradient>

      <View style={styles.bottomPanel}>
        <View style={styles.bottomRow}>
          <View style={styles.hints}>
            <View style={styles.hintRow}>
              <HandIcon
                color="#ffb8dd"
                anim={{ transform: [{ translateX: handSway1.interpolate({ inputRange: [0, 1], outputRange: [-8, 8] }) }, { rotate: handSway1.interpolate({ inputRange: [0, 1], outputRange: ['-6deg', '6deg'] }) }] }}
              />
              <Text style={styles.hintText}>FOR SQUASHING</Text>
            </View>
            <View style={styles.hintRow}>
              <HandIcon
                color="#a5f3fc"
                fingers={2}
                anim={{ transform: [{ translateX: handSway2.interpolate({ inputRange: [0, 1], outputRange: [-8, 8] }) }, { rotate: handSway2.interpolate({ inputRange: [0, 1], outputRange: ['-6deg', '6deg'] }) }] }}
              />
              <Text style={styles.hintText}>FOR ROTATING {(toy.name || '').toUpperCase()}</Text>
            </View>
            <View style={styles.hintRow}>
              <HandIcon
                color="#ffe27a"
                anim={{ transform: [{ translateY: tapPulseAnim.interpolate({ inputRange: [0, 1], outputRange: [0, 6] }) }, { scale: tapPulseAnim.interpolate({ inputRange: [0, 1], outputRange: [1, 0.9] }) }] }}
              />
              <Text style={styles.hintText}>FOR EARNING MORE COINS</Text>
            </View>
          </View>

          <WatchAdButton onRewardEarned={handleAdReward} />
        </View>

        <View style={[styles.adSlot, { paddingBottom: insets.bottom }]}>
          <AdBanner />
        </View>
      </View>

      {interstitial && (
        <View style={styles.overlay}>
          <View style={styles.adBreakBox}>
            <Text style={styles.adBreakText}>AD BREAK</Text>
          </View>
          <Text style={styles.adBreakSub}>100 coins earned — thanks for playing!</Text>
          {interstitialReady && (
            <Pressable onPress={() => setInterstitial(false)}>
              <LinearGradient colors={squadGradients.ctaPink.colors} start={squadGradients.ctaPink.start} end={squadGradients.ctaPink.end} style={styles.continueButton}>
                <Text style={styles.continueText}>CONTINUE</Text>
              </LinearGradient>
            </Pressable>
          )}
        </View>
      )}

      {doubleFlash && (
        <View style={styles.overlay} pointerEvents="none">
          <Text style={styles.doubleFlashText}>×2 SQUISH POINTS!</Text>
        </View>
      )}
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, backgroundColor: squadColors.bgDeepest },
  stageArea: { flex: 7, position: 'relative', alignItems: 'center', justifyContent: 'center' },
  topLeft: { position: 'absolute', left: 14, flexDirection: 'row', alignItems: 'center', gap: 8, zIndex: 3 },
  backButton: { width: 34, height: 34, borderRadius: 12, backgroundColor: '#241243cc', alignItems: 'center', justifyContent: 'center' },
  backGlyph: { color: '#fff', fontSize: 18, fontWeight: '800' },
  coinPill: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: 6,
    backgroundColor: '#241243cc',
    borderWidth: 1,
    borderColor: squadColors.panelBorder,
    borderRadius: 999,
    paddingHorizontal: 12,
    paddingVertical: 5,
  },
  coinDot: { width: 14, height: 14, borderRadius: 7, backgroundColor: squadColors.gold },
  coinPillText: { color: squadColors.gold, fontFamily: squadFonts.bodyExtraBold, fontSize: 13 },
  wheelButton: {
    position: 'absolute',
    right: 14,
    zIndex: 3,
    width: 42,
    height: 42,
    borderRadius: 14,
    backgroundColor: '#241243cc',
    alignItems: 'center',
    justifyContent: 'center',
  },
  wheelGlyph: {
    width: 22,
    height: 22,
    borderRadius: 11,
    borderWidth: 6,
    borderColor: squadColors.textMutedLavender,
    backgroundColor: 'transparent',
  },
  stage: { width: STAGE_SIZE, height: STAGE_SIZE },
  ripple: {
    position: 'absolute',
    width: RIPPLE_MAX,
    height: RIPPLE_MAX,
    borderRadius: RIPPLE_MAX / 2,
    borderWidth: 2,
    borderColor: 'rgba(255,255,255,0.7)',
  },
  rewardText: {
    position: 'absolute',
    top: '20%',
    left: 0,
    right: 0,
    textAlign: 'center',
    fontFamily: squadFonts.headingExtraBold,
    fontSize: 26,
    color: squadColors.goldLight,
  },
  wheelPopup: {
    position: 'absolute',
    right: 14,
    width: 200,
    backgroundColor: squadColors.panelAlt,
    borderRadius: 16,
    borderWidth: 1.5,
    borderColor: squadColors.panelBorder,
    padding: 14,
    zIndex: 15,
  },
  wheelRow: { flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between', marginBottom: 10 },
  wheelRowLast: { marginBottom: 0 },
  wheelLabel: { color: squadColors.textLavender, fontFamily: squadFonts.bodyBold, fontSize: 12.5 },
  switchTrack: { width: 38, height: 22, borderRadius: 11, overflow: 'hidden' },
  switchKnob: { position: 'absolute', top: 2, width: 18, height: 18, borderRadius: 9, backgroundColor: '#fff' },
  bottomPanel: { flex: 3, backgroundColor: '#150a2e', borderTopWidth: 1, borderTopColor: squadColors.panelBorder },
  bottomRow: { flex: 1, flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between', paddingHorizontal: 16, paddingVertical: 10 },
  hints: { gap: 10 },
  hintRow: { flexDirection: 'row', alignItems: 'center', gap: 8 },
  handIcon: { width: 26, height: 32 },
  handPalm: { position: 'absolute', bottom: 0, left: 5, width: 16, height: 17, borderRadius: 8, borderBottomLeftRadius: 4, borderBottomRightRadius: 4 },
  handFinger: { position: 'absolute', top: 0, width: 6, height: 13, borderRadius: 3 },
  hintText: { color: squadColors.textLavender, fontFamily: squadFonts.bodyExtraBold, fontSize: 11 },
  adSlot: { alignItems: 'center' },
  overlay: { ...StyleSheet.absoluteFillObject, backgroundColor: 'rgba(5,2,15,0.92)', alignItems: 'center', justifyContent: 'center', zIndex: 30 },
  adBreakBox: {
    width: '80%',
    aspectRatio: 16 / 10,
    backgroundColor: squadColors.panel,
    borderWidth: 2,
    borderColor: '#4c3a80',
    borderStyle: 'dashed',
    borderRadius: 20,
    alignItems: 'center',
    justifyContent: 'center',
  },
  adBreakText: { color: squadColors.textFaint, fontFamily: squadFonts.headingExtraBold, letterSpacing: 2 },
  adBreakSub: { marginTop: 16, color: squadColors.textMutedLavender, fontFamily: squadFonts.bodyBold, fontSize: 13 },
  continueButton: { marginTop: 18, paddingVertical: 12, paddingHorizontal: 30, borderRadius: 14 },
  continueText: { color: '#fff', fontFamily: squadFonts.headingExtraBold },
  doubleFlashText: {
    fontFamily: squadFonts.headingExtraBold,
    fontSize: 40,
    color: squadColors.goldLight,
    textShadowColor: 'rgba(255,183,3,0.9)',
    textShadowRadius: 24,
  },
});
