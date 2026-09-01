import React, { useCallback, useEffect, useRef, useState } from 'react';
import { View, Text, StyleSheet, PanResponder, Animated, Pressable, Easing, Dimensions } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { Canvas } from '@react-three/fiber';
import { MaterialIcons } from '@expo/vector-icons';
import { InterstitialAd, AdEventType } from 'react-native-google-mobile-ads';
import SquishyToy, { MODEL_3D_IDS } from '../components/SquishyToy';
import SquishyToy2D from '../components/SquishyToy2D';
import { INTERSTITIAL_AD_UNIT_ID } from '../firebase/ads';

// Some creatures render from a real Tripo3D mesh (MODEL_3D_IDS, the single
// source of truth in SquishyToy); every other creature squishes as the 2D
// design art (see SquishyToy2D).
import SquishSound from '../audio/SquishSound';
import CoinSound from '../audio/CoinSound';
import PopSound from '../audio/PopSound';
import { squadColors, squadGradients, squadFonts } from '../theme/squadTheme';
import AdBanner from '../components/AdBanner';
import WatchAdButton from '../components/WatchAdButton';

// Squish stage — a single finger both dents the creature *and* slowly spins it
// while dragging (no separate two-finger orbit gesture, see SquishyToy.js).
//
// Coin earning:
//  - 3D-model creatures: you EARN WHILE YOU HOLD — ~2 coins/sec (EARN_PER_TICK
//    every EARN_TICK_MS) for as long as a one-finger press is down; two fingers
//    (rotate) earn nothing. The total banks to the profile on release.
//  - 2D creatures: unchanged — a lump sum on release scaled by hold time
//    (`rewardForHoldMs`, capped at 60).
// Watching a rewarded ad opens a 60s "double coins" window (`BONUS_MS`) that
// doubles every payout and pops a "×2 SQUISH POINTS!" flash.
//
// Touch-abuse guard: more than ABUSE_TAP_LIMIT quick jabs at a 3D model inside
// ABUSE_WINDOW_MS pops the PunishmentModal — the only way out is to watch an
// interstitial ad.

// The interactive play area (the "square"): a centred box the creature lives
// in. Sized to the device rather than a fixed 220 so the creature reads big
// on a real phone.
const STAGE_SIZE = Math.min(Math.round(Dimensions.get('window').width - 32), 380);
const RIPPLE_LIFETIME_MS = 620;
const REWARD_VISIBLE_MS = 900;
const DOUBLE_FLASH_MS = 1800;
// Watching a rewarded ad grants a 60s window where every squish reward is ×2.
const BONUS_MS = 60000;
const SPEED_TAP_WINDOW_MS = 60000;
const SPEED_TAP_THRESHOLD = 60;

// Passive earning: while you HOLD a one-finger press on a 3D-model creature you
// bank coins over time (~2 / second, ticked every 850ms). Two fingers = rotate,
// which earns nothing.
const EARN_TICK_MS = 850;
const EARN_PER_TICK = 2;

// Touch-abuse guard: more than this many separate taps on a 3D model inside the
// window pops the "you're tapping too much" punishment (an interstitial ad).
const ABUSE_WINDOW_MS = 60000;
const ABUSE_TAP_LIMIT = 5;
const ABUSE_COOLDOWN_MS = 60000;

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

// The prototype's `popIn` keyframe (see LoadingScreen): springs in from small +
// tilted + invisible, overshoots, then settles. Re-mount (via `key`) to replay.
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

// The three bottom-panel hint hands, matching the prototype art: a rounded palm,
// one or two finger bars, an angled thumb, and (single-finger hands only) two
// small knuckle dots in the darker `accent` tone.
function HandIcon({ color, accent, fingers = 1, anim }) {
  return (
    <Animated.View style={[styles.handIcon, anim]}>
      <View style={[styles.handPalm, { backgroundColor: color }]} />
      {fingers === 1 ? (
        <View style={[styles.handFinger, { backgroundColor: color, left: 8, top: 4, width: 7, height: 16 }]} />
      ) : (
        <>
          <View style={[styles.handFinger, { backgroundColor: color, left: 8, top: 3, width: 6, height: 17 }]} />
          <View style={[styles.handFinger, { backgroundColor: color, left: 15, top: 5, width: 6, height: 15 }]} />
        </>
      )}
      <View style={[styles.handThumb, { backgroundColor: accent }]} />
      {fingers === 1 && (
        <>
          <View style={[styles.handKnuckle, { backgroundColor: accent, top: 11, left: 16 }]} />
          <View style={[styles.handKnuckle, { backgroundColor: accent, top: 15, left: 17 }]} />
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

// Shown when the player hammers the 3D model too fast. There's exactly one way
// out: "ACCEPT PUNISHMENT", which loads and shows a full-screen interstitial ad.
// When the ad closes (or fails to load) the modal dismisses itself.
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
  // passive-earn interval + coins banked this hold (flushed to the profile on release)
  const earnIntervalRef = useRef(null);
  const earnAccumRef = useRef(0);
  // touch-abuse guard: 3D-model tap timestamps + a cooldown so it can't spam
  const abuseTapsRef = useRef([]);
  const abuseCooldownUntilRef = useRef(0);
  // 'none' | 'poke' (one finger, squishing) | 'orbit' (two fingers, turning)
  const gestureModeRef = useRef('none');
  const lastCentroidRef = useRef({ x: 0, y: 0 });
  // true once a gesture has had 2+ fingers at any point — such a gesture never
  // plays the squish sound or grants coins, even after fingers are lifted.
  const gestureHadTwoRef = useRef(false);

  const [displayCoins, setDisplayCoins] = useState(coins);
  const [ripples, setRipples] = useState([]);
  const [showReward, setShowReward] = useState(false);
  const [rewardAmount, setRewardAmount] = useState(0);
  const [rewardKey, setRewardKey] = useState(0);
  const [wheelOpen, setWheelOpen] = useState(false);
  const [punishOpen, setPunishOpen] = useState(false);
  const [doubleFlash, setDoubleFlash] = useState(false);
  const [doubleFlashKey, setDoubleFlashKey] = useState(0);
  // Timestamp the 60s double-coins window ends at (null while inactive), plus a
  // `now` that ticks every 250ms so the countdown widget re-renders.
  const [bonusEndsAt, setBonusEndsAt] = useState(null);
  const [now, setNow] = useState(() => Date.now());

  const wheelAnim = useRef(new Animated.Value(0)).current;
  const handSway1 = useLoopAnim({ duration: 1400 });
  const handSway2 = useLoopAnim({ duration: 1400 });
  const tapPulseAnim = useLoopAnim({ duration: 900 });
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
    bonusEndsAt,
  };

  const grantReward = useCallback((amount) => {
    const { coinSoundEnabled: coinSoundOn, onEarnCoins: earnCoins } = latestRef.current;
    setDisplayCoins((before) => before + amount);
    if (coinSoundOn) coinSoundRef.current?.play();
    earnCoins && earnCoins(amount);
  }, []);

  const is3DToy = useCallback(() => MODEL_3D_IDS.has(String(latestRef.current?.toy?.id)), []);

  // Passive earning while a one-finger press is held on a 3D model: bank
  // EARN_PER_TICK coins every EARN_TICK_MS (doubled while the bonus window is
  // live), updating the on-screen counter + playing the coin ding each tick.
  // The profile write is deferred to `stopEarning` so we don't hammer Firestore.
  const startEarning = useCallback(() => {
    if (earnIntervalRef.current) return;
    earnAccumRef.current = 0;
    earnIntervalRef.current = setInterval(() => {
      const { bonusEndsAt: be, coinSoundEnabled: coinSoundOn } = latestRef.current;
      const gain = EARN_PER_TICK * (be && be > Date.now() ? 2 : 1);
      earnAccumRef.current += gain;
      setDisplayCoins((c) => c + gain);
      if (coinSoundOn) coinSoundRef.current?.play();
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
      setRewardAmount(earned);
      setShowReward(true);
      setRewardKey((k) => k + 1);
      setTimeout(() => setShowReward(false), REWARD_VISIBLE_MS);
    }
    return earned;
  }, []);

  useEffect(() => () => {
    if (earnIntervalRef.current) clearInterval(earnIntervalRef.current);
  }, []);

  // Called on every completed one-finger tap of a 3D model. Trips the punishment
  // once the tap count in the rolling window passes ABUSE_TAP_LIMIT (outside the
  // post-punishment cooldown).
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

  // Finishing a rewarded ad doesn't pay out directly — it opens the 60s ×2
  // window (see the reward calc in onPanResponderRelease) and pops the flash.
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
      // Fires on the first touch AND every additional touch. A second finger
      // landing (without moving) doesn't trigger onPanResponderMove, so this
      // is where a poke -> orbit switch has to be caught to kill the squish
      // sound immediately.
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
        // One finger on a 3D model → start banking coins for as long as it's held.
        if (is3DToy()) startEarning();
      },
      onPanResponderMove: (evt) => {
        const touches = evt.nativeEvent.touches || [];

        if (touches.length >= 2) {
          gestureHadTwoRef.current = true;
          // Two fingers down — orbit. If a one-finger poke was in progress,
          // drop it (no reward) and silence the squish sound so the gesture
          // cleanly becomes a rotate.
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
        const hadTwo = gestureHadTwoRef.current;
        gestureModeRef.current = 'none';
        gestureHadTwoRef.current = false;
        // A two-finger gesture (now or at any earlier point) is a rotate, not
        // a squish: no reward, no release sound, and stop the squish loop.
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

        if (MODEL_3D_IDS.has(String(currentToy.id))) {
          // Passive earning already paid out over the hold — flush it + show the
          // "+N" float. A quick jab (< 400ms, no full tick) earns nothing and
          // counts toward the tap-abuse guard.
          stopEarning();
          if (holdMs < 400) registerAbuseTap();
        } else {
          const bonusOn = !!latestRef.current.bonusEndsAt && latestRef.current.bonusEndsAt > Date.now();
          const reward = rewardForHoldMs(holdMs) * (bonusOn ? 2 : 1);
          setRewardAmount(reward);
          setShowReward(true);
          setRewardKey((k) => k + 1);
          setTimeout(() => setShowReward(false), REWARD_VISIBLE_MS);
          grantReward(reward);
        }

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
          {MODEL_3D_IDS.has(String(toy.id)) ? (
            <Canvas flat frameloop="always" camera={{ fov: 30, position: [0, 0.1, 4.6], near: 0.1, far: 100 }}>
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
          <View style={styles.hints}>
            <View style={styles.hintRow}>
              <HandIcon
                color="#ffb8dd"
                accent="#ff9ecd"
                anim={{ transform: [{ translateX: handSway1.interpolate({ inputRange: [0, 1], outputRange: [-8, 8] }) }, { rotate: handSway1.interpolate({ inputRange: [0, 1], outputRange: ['-6deg', '6deg'] }) }] }}
              />
              <Text style={styles.hintText}>FOR SQUASHING</Text>
            </View>
            <View style={styles.hintRow}>
              <HandIcon
                color="#a5f3fc"
                accent="#67e8f9"
                fingers={2}
                anim={{ transform: [{ translateX: handSway2.interpolate({ inputRange: [0, 1], outputRange: [-8, 8] }) }, { rotate: handSway2.interpolate({ inputRange: [0, 1], outputRange: ['-6deg', '6deg'] }) }] }}
              />
              <Text style={styles.hintText}>FOR ROTATING {(toy.name || '').toUpperCase()}</Text>
            </View>
            <View style={styles.hintRow}>
              <HandIcon
                color="#ffe27a"
                accent="#fcd34d"
                anim={{ transform: [{ translateY: tapPulseAnim.interpolate({ inputRange: [0, 1], outputRange: [0, 6] }) }, { scale: tapPulseAnim.interpolate({ inputRange: [0, 1], outputRange: [1, 0.9] }) }] }}
              />
              <Text style={styles.hintText}>FOR EARNING MORE COINS</Text>
            </View>
          </View>

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
  hints: { gap: 10, flexShrink: 1 },
  hintRow: { flexDirection: 'row', alignItems: 'center', gap: 8 },
  handIcon: { width: 28, height: 34 },
  handPalm: {
    position: 'absolute',
    bottom: 0,
    left: 5,
    width: 18,
    height: 17,
    borderTopLeftRadius: 5,
    borderTopRightRadius: 7,
    borderBottomRightRadius: 9,
    borderBottomLeftRadius: 9,
  },
  handFinger: { position: 'absolute', borderRadius: 3, borderWidth: 1, borderColor: 'rgba(21,10,46,0.55)' },
  handThumb: {
    position: 'absolute',
    bottom: 6,
    left: 1,
    width: 8,
    height: 7,
    borderRadius: 4,
    transform: [{ rotate: '-30deg' }],
    borderWidth: 1,
    borderColor: 'rgba(21,10,46,0.55)',
  },
  handKnuckle: { position: 'absolute', width: 6, height: 5, borderRadius: 3 },
  hintText: { color: squadColors.textLavender, fontFamily: squadFonts.bodyExtraBold, fontSize: 11, flexShrink: 1 },
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
  // Baloo has tall built-in font padding that shoves a short glyph like "×2"
  // above the optical centre. Kill the padding and stretch the line box to the
  // full height of the coin so the glyph sits vertically centred inside it,
  // then let `justifyContent: 'center'` on the coin place that line box.
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
