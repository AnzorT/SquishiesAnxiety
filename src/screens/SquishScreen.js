import React, { useCallback, useEffect, useRef, useState } from 'react';
import { View, Text, StyleSheet, PanResponder, Animated, Pressable, Easing, Dimensions } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { Canvas } from '@react-three/fiber';
import { MaterialIcons } from '@expo/vector-icons';
import Svg, { Path, Circle } from 'react-native-svg';
import { InterstitialAd, AdEventType } from 'react-native-google-mobile-ads';
import SquishyToy, { MODEL_3D_IDS } from '../components/SquishyToy';
import SquishyToy2D from '../components/SquishyToy2D';
import { INTERSTITIAL_AD_UNIT_ID } from '../firebase/ads';

// 3D-mesh creatures use MODEL_3D_IDS; everything else is 2D art (SquishyToy2D).
import SquishSound from '../audio/SquishSound';
import CoinSound from '../audio/CoinSound';
import PopSound from '../audio/PopSound';
import { squadColors, squadGradients, squadFonts } from '../theme/squadTheme';
import AdBanner from '../components/AdBanner';
import WatchAdButton from '../components/WatchAdButton';

// Stage size scales to the device, capped at 380.
const STAGE_SIZE = Math.min(Math.round(Dimensions.get('window').width - 32), 380);
const RIPPLE_LIFETIME_MS = 620;
const DOUBLE_FLASH_MS = 1800;
// 60s window where an ad-watch doubles squish rewards.
const BONUS_MS = 60000;
const SPEED_TAP_WINDOW_MS = 60000;
const SPEED_TAP_THRESHOLD = 60;

// Bank 1 coin every 1.5s while held; two fingers (rotate) earns nothing.
const EARN_TICK_MS = 1500;
const EARN_PER_TICK = 1;
// Floating "+1" per tick: rises, spins, fades.
const FLOATING_COIN_MS = 2200;
const FLOATING_COIN_RISE = 100;
const FLOATING_COIN_SIZE = 24;

// Too many quick taps trips the punishment ad — must be a rapid-fire burst
// (6+ taps within 1s), not just several taps spread over a minute.
const ABUSE_WINDOW_MS = 1000;
const ABUSE_TAP_LIMIT = 6;
const ABUSE_COOLDOWN_MS = 60000;

const DEFAULT_SQUISH_SOUND = require('../../assets/audio/slime.wav');

const RIPPLE_MAX = 120;

// Ring that blooms from the touch point and fades.
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

// Coin that rises, spins, and fades — pops once per earn tick.
function FloatingCoin({ x, y, amount }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    Animated.timing(t, { toValue: 1, duration: FLOATING_COIN_MS, easing: Easing.out(Easing.quad), useNativeDriver: true }).start();
  }, [t]);
  const translateY = t.interpolate({ inputRange: [0, 1], outputRange: [0, -FLOATING_COIN_RISE] });
  const scale = t.interpolate({ inputRange: [0, 0.2, 1], outputRange: [0.5, 1, 1] });
  const opacity = t.interpolate({ inputRange: [0, 0.15, 0.55, 1], outputRange: [0, 1, 1, 0] });
  const spin = t.interpolate({ inputRange: [0, 1], outputRange: ['0deg', '360deg'] });
  return (
    <Animated.View
      pointerEvents="none"
      style={[styles.floatingCoin, { left: x - 34, top: y - 46, opacity, transform: [{ translateY }, { scale }] }]}
    >
      <Animated.View style={[styles.floatingCoinBadge, { transform: [{ rotateY: spin }] }]}>
        <LinearGradient
          colors={squadGradients.goldDot.colors}
          start={squadGradients.goldDot.start}
          end={squadGradients.goldDot.end}
          style={StyleSheet.absoluteFillObject}
        />
      </Animated.View>
      <Text style={styles.floatingCoinText}>+{amount}</Text>
    </Animated.View>
  );
}

// Springs in small+tilted, overshoots, settles.
function PopIn({ style, children }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    Animated.timing(t, { toValue: 1, duration: 460, easing: Easing.out(Easing.quad), useNativeDriver: true }).start();
  }, [t]);
  const opacity = t.interpolate({ inputRange: [0, 0.5, 1], outputRange: [0, 1, 1] });
  const scale = t.interpolate({ inputRange: [0, 0.6, 1], outputRange: [0.4, 1.12, 1] });
  const rotate = t.interpolate({ inputRange: [0, 0.6, 1], outputRange: ['-8deg', '3deg', '0deg'] });
  return <Animated.View style={[style, { opacity, transform: [{ scale }, { rotate }] }]}>{children}</Animated.View>;
}

// One-time gesture tutorial, overlaid on the stage itself (replaces the old
// permanent bottom-panel hint list) — a squish hand on the left, a rotate
// hand on the right, each with a pulsing touch-point ring, fading out the
// first time the player actually touches the toy (see gestureHintOpacity).
const SQUISH_HAND_D =
  'M24 17A6 6 0 0 1 36 17L36 42C37 39 41 37.5 44 39C47.4 40.4 48.4 44 47.4 47C48.4 44 51.4 42.4 54.4 43.6C57.8 45 58.8 48.4 57.8 51.6C59.4 49.4 62.6 48.8 64.8 50.6C67.4 52.6 67.8 55.8 67 59L65.4 69C63.8 81.4 54.8 90.6 42.8 90.6L35.8 90.6C23.4 90.6 15.2 81.6 13.8 69.2L12.8 60.6L5.8 50.6C2.8 46.2 9.2 41.6 12.8 46.2L19.4 55.2C20.6 56.8 22.2 57.4 24 57.4Z';
const SQUISH_HAND_CREASE_D = 'M47.4 47c-2.6.6-5.4.2-7.6-1.2M57.8 51.6c-2.6.8-5.6.4-8-1';
const ROTATE_HAND_D =
  'M18 22A6 6 0 0 1 30 22L30 44L32 44L32 15A6 6 0 0 1 44 15L44 47C45.4 44 49 42.6 52 44.2C55.4 45.8 56.2 49.4 55 52.6C56.8 50.4 60 50 62.2 52C64.8 54.2 65 57.4 64 60.4L62.6 69.6C61 82 52 90.6 40 90.6L33 90.6C21 90.6 13 81.6 11.8 69.4L10.8 61L4 51C1 46.6 7.4 42 11 46.6L17 55.4C17.6 56.4 17.8 56.6 18 57Z';
const ROTATE_HAND_CREASE_D = 'M55 52.6c-2.6.8-5.6.4-8-1M31 44.4c-.2 4 .4 8 1.8 11.6';

function GestureHint({ side, d, creaseD, label, touchAnim, gestureAnim }) {
  const sideStyle = side === 'left' ? { left: '12%' } : { right: '12%' };
  return (
    <View style={[styles.gestureHint, sideStyle]} pointerEvents="none">
      <Animated.View style={[styles.gestureHandWrap, { transform: gestureAnim }]}>
        <Animated.View
          style={[
            styles.gestureTouchRing,
            side === 'left' ? { left: 10 } : { left: 8 },
            { opacity: touchAnim.interpolate({ inputRange: [0, 0.5, 1], outputRange: [0.9, 0.2, 0.9] }), transform: [{ scale: touchAnim.interpolate({ inputRange: [0, 1], outputRange: [1, 1.25] }) }] },
          ]}
        />
        <Svg width={46} height={62} viewBox="0 0 72 96" style={styles.gestureSvg}>
          <Path d={d} fill="rgba(255,255,255,0.28)" stroke="#ffffff" strokeWidth={2.8} strokeLinejoin="round" />
          <Path d={creaseD} stroke="rgba(255,255,255,0.75)" strokeWidth={2} strokeLinecap="round" fill="none" />
        </Svg>
      </Animated.View>
      <Text style={styles.gestureHintText}>{label}</Text>
    </View>
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

// Forces an interstitial ad after too many quick taps.
function PunishmentModal({ visible, onDismiss }) {
  const [loading, setLoading] = useState(false);
  const adRef = useRef(null);
  const unsubsRef = useRef([]);

  useEffect(() => {
    if (!visible) setLoading(false);
    return () => {
      unsubsRef.current.forEach((fn) => fn());
      unsubsRef.current = [];
    };
  }, [visible]);

  const acceptPunishment = useCallback(() => {
    if (loading) return;
    setLoading(true);
    const ad = InterstitialAd.createForAdRequest(INTERSTITIAL_AD_UNIT_ID);
    adRef.current = ad;
    const done = () => {
      unsubsRef.current.forEach((fn) => fn());
      unsubsRef.current = [];
      setLoading(false);
      onDismiss();
    };
    unsubsRef.current = [
      ad.addAdEventListener(AdEventType.LOADED, () => ad.show()),
      ad.addAdEventListener(AdEventType.CLOSED, done),
      ad.addAdEventListener(AdEventType.ERROR, done),
    ];
    // If the ad never loads, don't trap the player forever.
    const t = setTimeout(done, 8000);
    unsubsRef.current.push(() => clearTimeout(t));
    ad.load();
  }, [loading, onDismiss]);

  if (!visible) return null;
  return (
    <View style={styles.punishOverlay}>
      <View style={styles.punishCard}>
        <Text style={styles.punishEmoji}>🚨</Text>
        <Text style={styles.punishTitle}>WHOA THERE!</Text>
        <Text style={styles.punishBody}>
          You&apos;re tapping way too much.{'\n'}You will be punished.
        </Text>
        <Pressable
          onPress={acceptPunishment}
          disabled={loading}
          style={({ pressed }) => [styles.punishButton, (pressed || loading) && styles.punishButtonDim]}
        >
          <Text style={styles.punishButtonText}>{loading ? 'LOADING…' : 'ACCEPT PUNISHMENT'}</Text>
        </Pressable>
      </View>
    </View>
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
  // Coins banked this hold; flushed on release.
  const earnIntervalRef = useRef(null);
  const earnAccumRef = useRef(0);
  // Tap timestamps + cooldown for the abuse guard.
  const abuseTapsRef = useRef([]);
  const abuseCooldownUntilRef = useRef(0);
  // gesture mode: none | poke | orbit
  const gestureModeRef = useRef('none');
  const lastCentroidRef = useRef({ x: 0, y: 0 });
  // True once 2 fingers have touched — blocks sound/coins for the rest of the gesture.
  const gestureHadTwoRef = useRef(false);

  const floatingCoinSeqRef = useRef(0);

  const [displayCoins, setDisplayCoins] = useState(coins);
  const [ripples, setRipples] = useState([]);
  const [floatingCoins, setFloatingCoins] = useState([]);
  const [wheelOpen, setWheelOpen] = useState(false);
  const [punishOpen, setPunishOpen] = useState(false);
  const [doubleFlash, setDoubleFlash] = useState(false);
  const [doubleFlashKey, setDoubleFlashKey] = useState(0);
  // Bonus window end time; `now` ticks for the countdown.
  const [bonusEndsAt, setBonusEndsAt] = useState(null);
  const [now, setNow] = useState(() => Date.now());

  const wheelAnim = useRef(new Animated.Value(0)).current;
  const gestureSquishAnim = useLoopAnim({ duration: 1700 });
  const gestureRotateAnim = useLoopAnim({ duration: 1700 });
  const gestureTouchAnim = useLoopAnim({ duration: 1700 });
  // Fades the on-stage gesture tutorial out the first time the player
  // actually touches the toy — see onPanResponderGrant below. Stays hidden
  // for the rest of this screen's lifetime (hintDismissedRef).
  const gestureHintOpacity = useRef(new Animated.Value(1)).current;
  const hintDismissedRef = useRef(false);
  const bonusCoinAnim = useLoopAnim({ duration: 1300 });

  useEffect(() => {
    if (!bonusEndsAt) return undefined;
    const id = setInterval(() => {
      const t = Date.now();
      setNow(t);
      if (t >= bonusEndsAt) setBonusEndsAt(null);
    }, 250);
    return () => clearInterval(id);
  }, [bonusEndsAt]);

  const bonusRemain = bonusEndsAt ? Math.max(0, bonusEndsAt - now) : 0;
  const bonusActive = bonusRemain > 0;
  const bonusSecs = Math.ceil(bonusRemain / 1000);
  const bonusTimeText = `${Math.floor(bonusSecs / 60)}:${String(bonusSecs % 60).padStart(2, '0')}`;
  const bonusPct = Math.max(0, Math.min(100, (bonusRemain / BONUS_MS) * 100));
  const bonusCoinScale = bonusCoinAnim.interpolate({ inputRange: [0, 1], outputRange: [1, 1.1] });

  useEffect(() => {
    const sound = new SquishSound();
    soundRef.current = sound;
    // Custom creatures can carry their own squish sound.
    sound.load(toy?.audio ? { uri: toy.audio } : DEFAULT_SQUISH_SOUND);
    return () => sound.unload();
    // eslint-disable-next-line react-hooks/exhaustive-deps
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

  // Mirrors props/state so the once-created PanResponder always reads fresh values.
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
    bonusEndsAt,
  };

  // True for 3D-mesh creatures; picks Canvas vs SquishyToy2D below.
  const toyIs3D = (t) => !!(t && ((t.isCustom && t.modelUrl) || MODEL_3D_IDS.has(String(t.id))));

  // Earn EARN_PER_TICK coins every EARN_TICK_MS while held.
  const startEarning = useCallback(() => {
    if (earnIntervalRef.current) return;
    earnAccumRef.current = 0;
    earnIntervalRef.current = setInterval(() => {
      const { coinSoundEnabled: coinSoundOn } = latestRef.current;
      const gain = EARN_PER_TICK;
      earnAccumRef.current += gain;
      setDisplayCoins((c) => c + gain);
      if (coinSoundOn) coinSoundRef.current?.play();
      spawnFloatingCoin(lastTouch.current.x, lastTouch.current.y, gain);
    }, EARN_TICK_MS);
  }, []);

  const stopEarning = useCallback(() => {
    if (earnIntervalRef.current) {
      clearInterval(earnIntervalRef.current);
      earnIntervalRef.current = null;
    }
    const earned = earnAccumRef.current;
    earnAccumRef.current = 0;
    if (earned > 0) {
      const { onEarnCoins: earnCoins } = latestRef.current;
      earnCoins && earnCoins(earned);
    }
    return earned;
  }, []);

  useEffect(() => () => {
    if (earnIntervalRef.current) clearInterval(earnIntervalRef.current);
  }, []);

  // Trips the punishment after too many quick taps.
  const registerAbuseTap = useCallback(() => {
    const t = Date.now();
    const taps = [...abuseTapsRef.current, t].filter((ts) => t - ts < ABUSE_WINDOW_MS);
    abuseTapsRef.current = taps;
    if (taps.length > ABUSE_TAP_LIMIT && t >= abuseCooldownUntilRef.current) {
      abuseTapsRef.current = [];
      abuseCooldownUntilRef.current = t + ABUSE_COOLDOWN_MS;
      setPunishOpen(true);
    }
  }, []);

  const dismissPunishment = useCallback(() => {
    setPunishOpen(false);
    abuseTapsRef.current = [];
    abuseCooldownUntilRef.current = Date.now() + ABUSE_COOLDOWN_MS;
  }, []);

  // Ad reward opens the 60s double-coins window and pops the flash.
  const handleAdReward = useCallback(() => {
    const { achievements: liveAchievements, onMarkAchievement: markAch } = latestRef.current;
    const t = Date.now();
    setBonusEndsAt(t + BONUS_MS);
    setNow(t);
    setDoubleFlash(true);
    setDoubleFlashKey((k) => k + 1);
    setTimeout(() => setDoubleFlash(false), DOUBLE_FLASH_MS);
    if (!liveAchievements.watchAd) markAch && markAch('watchAd');
  }, []);

  const ndcFromLocation = (locationX, locationY) => ({
    x: (locationX / STAGE_SIZE) * 2 - 1,
    y: -((locationY / STAGE_SIZE) * 2 - 1),
  });

  const spawnRipple = useCallback((locationX, locationY) => {
    const id = ++rippleSeqRef.current;
    setRipples((prev) => [...prev, { id, x: locationX, y: locationY }]);
    setTimeout(() => setRipples((prev) => prev.filter((r) => r.id !== id)), RIPPLE_LIFETIME_MS);
  }, []);

  const spawnFloatingCoin = useCallback((x, y, amount) => {
    const id = ++floatingCoinSeqRef.current;
    setFloatingCoins((prev) => [...prev, { id, x, y, amount }]);
    setTimeout(() => setFloatingCoins((prev) => prev.filter((c) => c.id !== id)), FLOATING_COIN_MS);
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
      // Catches a poke -> orbit switch on the second finger landing.
      onPanResponderStart: (evt) => {
        const touches = evt.nativeEvent.touches || [];
        if (touches.length >= 2 && gestureModeRef.current !== 'orbit') {
          gestureHadTwoRef.current = true;
          toyRef.current?.cancelPoke();
          soundRef.current?.stop();
          stopEarning();
          gestureModeRef.current = 'orbit';
          lastCentroidRef.current = centroidOf(touches);
        }
      },
      onPanResponderGrant: (evt) => {
        if (!hintDismissedRef.current) {
          hintDismissedRef.current = true;
          Animated.timing(gestureHintOpacity, { toValue: 0, duration: 300, useNativeDriver: true }).start();
        }
        const touches = evt.nativeEvent.touches || [];
        gestureHadTwoRef.current = touches.length >= 2;
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
        startEarning();
      },
      onPanResponderMove: (evt) => {
        const touches = evt.nativeEvent.touches || [];

        if (touches.length >= 2) {
          gestureHadTwoRef.current = true;
          // Second finger cancels any poke in progress and starts orbit.
          if (gestureModeRef.current !== 'orbit') {
            toyRef.current?.cancelPoke();
            soundRef.current?.stop();
            stopEarning();
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
          // Keep orbiting with the remaining finger.
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
        const hadTwo = gestureHadTwoRef.current;
        gestureModeRef.current = 'none';
        gestureHadTwoRef.current = false;
        // Orbit gestures never earn coins or play the release sound.
        if (mode === 'orbit' || hadTwo) {
          toyRef.current?.endOrbit();
          toyRef.current?.pointerUp();
          soundRef.current?.stop();
          stopEarning();
          return;
        }
        const result = toyRef.current?.pointerUp();
        if (!result || !result.wasPoke) {
          stopEarning();
          return;
        }
        const { achievements: liveAchievements, releaseSoundEnabled: releaseSoundOn, toy: currentToy, onRecordPress: recordPress, onMarkAchievement: markAch } = latestRef.current;

        const holdMs = Date.now() - holdStartRef.current;
        const now = Date.now();
        const timestamps = [...tapTimestampsRef.current, now].filter((t) => now - t < SPEED_TAP_WINDOW_MS);
        tapTimestampsRef.current = timestamps;
        if (timestamps.length >= SPEED_TAP_THRESHOLD && !liveAchievements.speedTap) {
          markAch && markAch('speedTap');
        }

        recordPress && recordPress(currentToy.id, holdMs);

        // Flush the banked total; quick jabs count toward the abuse guard.
        stopEarning();
        if (holdMs < 400) registerAbuseTap();

        soundRef.current?.stop();
        if (releaseSoundOn) popSoundRef.current?.play();
      },
      onPanResponderTerminate: () => {
        gestureModeRef.current = 'none';
        gestureHadTwoRef.current = false;
        toyRef.current?.endOrbit();
        toyRef.current?.pointerUp();
        soundRef.current?.stop();
        stopEarning();
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
            <MaterialIcons name="settings" size={20} color={squadColors.textMutedLavender} />
          </Animated.View>
        </Pressable>

        <View style={styles.stage} {...panResponder.panHandlers}>
          {toyIs3D(toy) ? (
            <Canvas flat frameloop="always" camera={{ fov: 30, position: [0, 0.1, 4.6], near: 0.1, far: 100 }}>
              <ambientLight intensity={0.65} />
              <directionalLight color={0xfff2e0} intensity={1.3} position={[2, 3, 3]} />
              <directionalLight color={0xd8ccff} intensity={0.55} position={[-2.5, -1, 2]} />
              <directionalLight color={0xffffff} intensity={0.35} position={[-1.5, 2, -3]} />
              <SquishyToy
                ref={toyRef}
                creatureId={toy.id}
                modelUrl={toy.isCustom ? toy.modelUrl : undefined}
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
              imageUri={toy.isCustom ? toy.image : undefined}
              build={toy.isCustom ? toy.build : undefined}
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
            {floatingCoins.map((c) => (
              <FloatingCoin key={c.id} x={c.x} y={c.y} amount={c.amount} />
            ))}
          </View>

          <Animated.View style={[StyleSheet.absoluteFillObject, { opacity: gestureHintOpacity }]} pointerEvents="none">
            <GestureHint
              side="left"
              d={SQUISH_HAND_D}
              creaseD={SQUISH_HAND_CREASE_D}
              label="HOLD TO SQUISH"
              touchAnim={gestureTouchAnim}
              gestureAnim={[{ translateY: gestureSquishAnim.interpolate({ inputRange: [0, 0.5, 1], outputRange: [0, 8, 0] }) }]}
            />
            <GestureHint
              side="right"
              d={ROTATE_HAND_D}
              creaseD={ROTATE_HAND_CREASE_D}
              label="HOLD TO ROTATE"
              touchAnim={gestureTouchAnim}
              gestureAnim={[{ rotate: gestureRotateAnim.interpolate({ inputRange: [0, 0.5, 1], outputRange: ['0deg', '-14deg', '0deg'] }) }]}
            />
          </Animated.View>
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

      {bonusActive && (
        <View style={styles.bonusBar}>
          <View style={styles.bonusInner}>
            <Animated.View style={[styles.bonusCoin, { transform: [{ scale: bonusCoinScale }] }]}>
              <LinearGradient
                colors={squadGradients.goldDot.colors}
                start={squadGradients.goldDot.start}
                end={squadGradients.goldDot.end}
                style={StyleSheet.absoluteFillObject}
              />
              <Text style={styles.bonusCoinText}>×2</Text>
            </Animated.View>
            <View style={styles.bonusBody}>
              <View style={styles.bonusTopRow}>
                <Text style={styles.bonusLabel}>DOUBLE COINS ACTIVE</Text>
                <Text style={styles.bonusTime}>{bonusTimeText}</Text>
              </View>
              <View style={styles.bonusTrack}>
                <View style={[styles.bonusFill, { width: `${bonusPct}%` }]} />
              </View>
            </View>
          </View>
        </View>
      )}

      <View style={styles.bottomPanel}>
        <View style={styles.bottomRow}>
          <WatchAdButton onRewardEarned={handleAdReward} bonusActive={bonusActive} />
        </View>

        <View style={[styles.adSlot, { paddingBottom: insets.bottom }]}>
          <AdBanner />
        </View>
      </View>

      {doubleFlash && (
        <View style={styles.flashOverlay} pointerEvents="none">
          <PopIn key={doubleFlashKey}>
            <Text style={styles.doubleFlashText}>×2 SQUISH POINTS!</Text>
          </PopIn>
        </View>
      )}

      <PunishmentModal visible={punishOpen} onDismiss={dismissPunishment} />
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, backgroundColor: squadColors.bgDeepest },
  // Bottom panel no longer carries a tall hint list, so the stage claims
  // whatever's left instead of a fixed 70/30 split (see bottomPanel below).
  stageArea: { flex: 1, position: 'relative', alignItems: 'center', justifyContent: 'center' },
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
  stage: { width: STAGE_SIZE, height: STAGE_SIZE },
  ripple: {
    position: 'absolute',
    width: RIPPLE_MAX,
    height: RIPPLE_MAX,
    borderRadius: RIPPLE_MAX / 2,
    borderWidth: 2,
    borderColor: 'rgba(255,255,255,0.7)',
  },
  floatingCoin: { position: 'absolute', flexDirection: 'row', alignItems: 'center', gap: 4 },
  floatingCoinBadge: {
    width: FLOATING_COIN_SIZE,
    height: FLOATING_COIN_SIZE,
    borderRadius: FLOATING_COIN_SIZE / 2,
    overflow: 'hidden',
  },
  floatingCoinText: {
    fontFamily: squadFonts.headingExtraBold,
    fontSize: 16,
    color: squadColors.goldLight,
    textShadowColor: 'rgba(0,0,0,0.35)',
    textShadowRadius: 3,
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
  bottomPanel: { backgroundColor: '#150a2e', borderTopWidth: 1, borderTopColor: squadColors.panelBorder },
  bottomRow: { flexDirection: 'row', alignItems: 'center', justifyContent: 'flex-end', paddingHorizontal: 16, paddingVertical: 10 },
  gestureHint: { position: 'absolute', top: '52%', alignItems: 'center', gap: 6 },
  gestureHandWrap: { width: 46, height: 62, alignItems: 'center', justifyContent: 'center' },
  gestureSvg: { position: 'absolute' },
  gestureTouchRing: {
    position: 'absolute',
    top: -3,
    width: 26,
    height: 26,
    borderRadius: 13,
    borderWidth: 2,
    borderColor: 'rgba(255,255,255,0.85)',
  },
  gestureHintText: {
    color: '#ffffff',
    fontFamily: squadFonts.bodyExtraBold,
    fontSize: 9,
    letterSpacing: 1.1,
    textShadowColor: 'rgba(0,0,0,0.85)',
    textShadowRadius: 4,
    textShadowOffset: { width: 0, height: 1 },
  },
  adSlot: { alignItems: 'center' },
  bonusBar: { paddingHorizontal: 16, paddingVertical: 8, backgroundColor: squadColors.bgDeepest },
  bonusInner: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: 10,
    borderRadius: 16,
    paddingHorizontal: 12,
    paddingVertical: 8,
    borderWidth: 1.5,
    borderColor: squadColors.goldAmber,
    backgroundColor: '#2a1a08',
    overflow: 'hidden',
  },
  bonusCoin: {
    width: 30,
    height: 30,
    borderRadius: 15,
    overflow: 'hidden',
    alignItems: 'center',
    justifyContent: 'center',
  },
  // Kills Baloo's font padding so "×2" sits centred in the coin.
  bonusCoinText: {
    fontFamily: squadFonts.headingExtraBold,
    fontSize: 13,
    lineHeight: 30,
    width: 30,
    textAlign: 'center',
    color: '#5a3a00',
    includeFontPadding: false,
    textAlignVertical: 'center',
  },
  bonusBody: { flex: 1, gap: 5 },
  bonusTopRow: { flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between' },
  bonusLabel: { color: squadColors.goldLight, fontFamily: squadFonts.bodyExtraBold, fontSize: 9, letterSpacing: 1.4 },
  bonusTime: { fontFamily: squadFonts.headingExtraBold, fontSize: 16, color: squadColors.textWhite },
  bonusTrack: { height: 5, borderRadius: 3, backgroundColor: 'rgba(255,255,255,0.14)', overflow: 'hidden' },
  bonusFill: { height: '100%', borderRadius: 3, backgroundColor: squadColors.goldAmber },
  flashOverlay: { ...StyleSheet.absoluteFillObject, alignItems: 'center', justifyContent: 'center', zIndex: 32 },
  doubleFlashText: {
    fontFamily: squadFonts.headingExtraBold,
    fontSize: 44,
    color: squadColors.goldLight,
    textShadowColor: 'rgba(255,183,3,0.9)',
    textShadowRadius: 24,
  },

  punishOverlay: {
    ...StyleSheet.absoluteFillObject,
    backgroundColor: 'rgba(10,4,25,0.86)',
    alignItems: 'center',
    justifyContent: 'center',
    padding: 26,
    zIndex: 60,
  },
  punishCard: {
    width: '100%',
    maxWidth: 340,
    borderRadius: 24,
    borderWidth: 2,
    borderColor: squadColors.danger,
    backgroundColor: squadColors.panelAlt,
    paddingHorizontal: 24,
    paddingVertical: 28,
    alignItems: 'center',
  },
  punishEmoji: { fontSize: 44, marginBottom: 8 },
  punishTitle: {
    fontFamily: squadFonts.headingExtraBold,
    fontSize: 22,
    color: squadColors.danger,
    letterSpacing: 1,
    marginBottom: 10,
  },
  punishBody: {
    fontFamily: squadFonts.bodyBold,
    fontSize: 14,
    lineHeight: 20,
    color: squadColors.textLavender,
    textAlign: 'center',
    marginBottom: 22,
  },
  punishButton: {
    backgroundColor: squadColors.danger,
    borderRadius: 14,
    paddingVertical: 14,
    paddingHorizontal: 24,
    alignSelf: 'stretch',
    alignItems: 'center',
  },
  punishButtonDim: { opacity: 0.6 },
  punishButtonText: {
    fontFamily: squadFonts.headingExtraBold,
    fontSize: 15,
    letterSpacing: 1,
    color: '#ffffff',
  },
});
