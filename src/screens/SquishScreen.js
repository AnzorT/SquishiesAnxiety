import React, { useCallback, useEffect, useRef, useState } from 'react';
import { View, Text, StyleSheet, PanResponder, Animated, Switch, Pressable, Modal } from 'react-native';
import { MaterialIcons } from '@expo/vector-icons';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { Canvas } from '@react-three/fiber';
import SquishyToy, { COLOR_DEFS } from '../components/SquishyToy';
import SquishSound from '../audio/SquishSound';
import CoinSound from '../audio/CoinSound';
import PopSound from '../audio/PopSound';
import { colors, radii, spacing } from '../theme/tokens';
import AdBanner from '../components/AdBanner';
import WatchAdButton from '../components/WatchAdButton';
import CoinPopup from '../components/CoinPopup';

// "Squish Buddies" — ported design: poke the body to dent it (soft-body
// spring + diffusion physics), tap the nose to boop it. The buddy holds
// still until touched. Finger count on the stage picks the gesture: one
// finger squishes, two fingers orbit the buddy 360 degrees — the two
// behaviors don't run at the same time.
//
// Coins: a squish starting (finger lands and holds) grants a coin after a
// short delay, then another coin on each tick for as long as that single
// finger keeps pressing. The delay exists because RN reports a two-finger
// touch one finger at a time (grant fires for the first contact before the
// second finger's touch is reported), so an instant grant would award a
// coin for the split second before a rotate gesture is recognized as two
// fingers. Two-finger touches are the rotate gesture (see SquishScreen's
// PanResponder) and, once recognized, tear down the poke via pointerUp
// before entering orbit — cancelling the pending coin.
// Coins are applied to the local display instantly but only flushed to
// Firestore every ~1.5s (and on unmount) so holding down doesn't spam
// the network with a write per tick.
//
// The ad sits outside the padded content column (its own bottom-inset-only
// wrapper), same as HomeScreen, so it lands flush against the screen edge.

const STAGE_WIDTH = 360;
const STAGE_HEIGHT = 360;
const COIN_FLUSH_MS = 1500;
const COIN_TICK_MS = 1500;
const COIN_START_DELAY_MS = 500;
const BOOST_DURATION_MS = 60 * 1000;
const BOOST_TICK_MS = 250;
// Popups spawn this far above the actual touch point so the fingertip isn't
// covering the "+N" the moment it appears — without this the popup starts
// out hidden under the finger and has only fully faded by the time it rises
// clear of it.
const COIN_POPUP_Y_OFFSET = 90;
// How long the settings icon takes to rotate open/closed.
const SETTINGS_SPIN_MS = 300;

// Each creature has its own squish sample; Metro needs these require() calls
// literal (no dynamic paths), so they're all listed up front and picked by
// species below rather than built from a filename string.
const DEFAULT_SQUISH_SOUND = require('../../assets/audio/slime.wav');
const SQUISH_SOUND_BY_SPECIES = {
  seal: require('../../assets/audio/squish-seal.mp3'),
  cat: require('../../assets/audio/squish-cat.mp3'),
  cheese: require('../../assets/audio/squish-cheese.mp3'),
};

function firstAllowedColorIndex(toy) {
  if (!toy.colors?.length) return toy.startingColorIndex ?? 0;
  const idx = COLOR_DEFS.findIndex((c) => toy.colors.includes(c.mid));
  return idx === -1 ? 0 : idx;
}

export default function SquishScreen({
  toy,
  coins = 0,
  onBack,
  onEarnCoins,
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
  const activeModeRef = useRef(false);
  const coinStartTimeoutRef = useRef(null);
  const coinTimerRef = useRef(null);
  const pendingCoinsRef = useRef(0);
  const popupIdRef = useRef(0);
  const coinScale = useRef(new Animated.Value(1)).current;
  const coinFirstRender = useRef(true);
  const boostActiveRef = useRef(false);
  const boostTimerRef = useRef(null);
  const settingsAnim = useRef(new Animated.Value(0)).current;
  const [displayCoins, setDisplayCoins] = useState(coins);
  const [boostSecondsLeft, setBoostSecondsLeft] = useState(0);
  const [popups, setPopups] = useState([]);
  const [selected] = useState(() => firstAllowedColorIndex(toy));
  const [settingsOpen, setSettingsOpen] = useState(false);

  const toggleSettings = useCallback(() => {
    setSettingsOpen((open) => {
      const next = !open;
      Animated.timing(settingsAnim, {
        toValue: next ? 1 : 0,
        duration: SETTINGS_SPIN_MS,
        useNativeDriver: true,
      }).start();
      return next;
    });
  }, [settingsAnim]);

  const settingsSpin = settingsAnim.interpolate({ inputRange: [0, 1], outputRange: ['0deg', '180deg'] });

  useEffect(() => {
    const sound = new SquishSound();
    soundRef.current = sound;
    sound.load(SQUISH_SOUND_BY_SPECIES[toy.species] ?? DEFAULT_SQUISH_SOUND);
    return () => {
      sound.unload();
    };
  }, [toy.species]);

  useEffect(() => {
    const sound = new CoinSound();
    coinSoundRef.current = sound;
    sound.load();
    return () => {
      sound.unload();
    };
  }, []);

  useEffect(() => {
    const sound = new PopSound();
    popSoundRef.current = sound;
    sound.load();
    return () => {
      sound.unload();
    };
  }, []);

  // Toggling squish sound off mid-hold should cut it immediately, not just
  // block the *next* start() — the coin/pop toggles don't need this since
  // those are one-shot sounds, never mid-playback when the switch flips.
  useEffect(() => {
    if (!squishSoundEnabled) soundRef.current?.stop();
  }, [squishSoundEnabled]);

  useEffect(() => {
    const flush = () => {
      if (pendingCoinsRef.current > 0) {
        const amount = pendingCoinsRef.current;
        pendingCoinsRef.current = 0;
        onEarnCoins && onEarnCoins(amount);
      }
    };
    const timer = setInterval(flush, COIN_FLUSH_MS);
    return () => {
      clearInterval(timer);
      flush();
    };
  }, [onEarnCoins]);

  useEffect(() => {
    if (coinFirstRender.current) {
      coinFirstRender.current = false;
      return;
    }
    coinScale.setValue(1.35);
    Animated.spring(coinScale, { toValue: 1, friction: 3, useNativeDriver: true }).start();
  }, [displayCoins, coinScale]);

  const removePopup = useCallback((id) => {
    setPopups((prev) => prev.filter((p) => p.id !== id));
  }, []);

  const stopCoinTimer = useCallback(() => {
    if (coinStartTimeoutRef.current) {
      clearTimeout(coinStartTimeoutRef.current);
      coinStartTimeoutRef.current = null;
    }
    if (coinTimerRef.current) {
      clearInterval(coinTimerRef.current);
      coinTimerRef.current = null;
    }
  }, []);

  useEffect(() => stopCoinTimer, [stopCoinTimer]);

  const grantCoins = useCallback(
    (amount, at) => {
      const finalAmount = boostActiveRef.current ? amount * 2 : amount;
      pendingCoinsRef.current += finalAmount;
      setDisplayCoins((c) => c + finalAmount);
      if (coinSoundEnabled) coinSoundRef.current?.play();
      if (at) {
        const id = ++popupIdRef.current;
        setPopups((prev) => {
          const next = [...prev, { id, amount: finalAmount, x: at.x, y: at.y - COIN_POPUP_Y_OFFSET }];
          return next.length > 12 ? next.slice(next.length - 12) : next;
        });
      }
    },
    [coinSoundEnabled]
  );

  const startCoinTimer = useCallback(() => {
    stopCoinTimer();
    coinStartTimeoutRef.current = setTimeout(() => {
      coinStartTimeoutRef.current = null;
      grantCoins(1, lastTouch.current);
      coinTimerRef.current = setInterval(() => {
        grantCoins(1, lastTouch.current);
      }, COIN_TICK_MS);
    }, COIN_START_DELAY_MS);
  }, [grantCoins, stopCoinTimer]);

  const stopBoostTimer = useCallback(() => {
    if (boostTimerRef.current) {
      clearInterval(boostTimerRef.current);
      boostTimerRef.current = null;
    }
  }, []);

  useEffect(() => stopBoostTimer, [stopBoostTimer]);

  // Watching the ad starts a 1-minute window where every coin grant is
  // doubled — the icon shows a live countdown for as long as it's active,
  // and the ad can't be watched again until it runs out.
  const handleAdReward = useCallback(() => {
    if (coinSoundEnabled) coinSoundRef.current?.play();
    boostActiveRef.current = true;
    stopBoostTimer();
    const endsAt = Date.now() + BOOST_DURATION_MS;
    setBoostSecondsLeft(Math.ceil(BOOST_DURATION_MS / 1000));
    boostTimerRef.current = setInterval(() => {
      const remainingMs = endsAt - Date.now();
      if (remainingMs <= 0) {
        boostActiveRef.current = false;
        setBoostSecondsLeft(0);
        stopBoostTimer();
      } else {
        setBoostSecondsLeft(Math.ceil(remainingMs / 1000));
      }
    }, BOOST_TICK_MS);
  }, [stopBoostTimer, coinSoundEnabled]);

  const ndcFromLocation = (locationX, locationY) => ({
    x: (locationX / STAGE_WIDTH) * 2 - 1,
    y: -((locationY / STAGE_HEIGHT) * 2 - 1),
  });

  const panResponder = useRef(
    PanResponder.create({
      onStartShouldSetPanResponder: () => true,
      onMoveShouldSetPanResponder: () => true,
      // Capture (not just bubble) phase — without this, the Canvas's
      // underlying native GL view can hang onto the very first touch itself,
      // so pointerDown only actually fires once a move forces the responder
      // system to renegotiate. Claiming capture makes this view grab every
      // touch immediately, before the GL view underneath ever sees it.
      onStartShouldSetPanResponderCapture: () => true,
      onMoveShouldSetPanResponderCapture: () => true,
      onPanResponderGrant: (evt) => {
        const { locationX, locationY, touches } = evt.nativeEvent;
        lastTouch.current = { x: locationX, y: locationY };
        const ndc = ndcFromLocation(locationX, locationY);
        activeModeRef.current = touches.length >= 2;
        toyRef.current?.pointerDown(ndc.x, ndc.y, activeModeRef.current);
      },
      onPanResponderMove: (evt) => {
        const { locationX, locationY, touches } = evt.nativeEvent;
        const rotate = touches.length >= 2;
        if (rotate !== activeModeRef.current) {
          // Finger count changed mid-gesture — restart the interaction in
          // the new mode rather than mixing squish and orbit deltas. Pass
          // `rotate` through so a poke torn down by a second finger joining
          // (not an actual release) doesn't fire release-only feedback.
          activeModeRef.current = rotate;
          toyRef.current?.pointerUp(rotate);
          const ndc = ndcFromLocation(locationX, locationY);
          toyRef.current?.pointerDown(ndc.x, ndc.y, rotate);
          lastTouch.current = { x: locationX, y: locationY };
          return;
        }
        const dx = locationX - lastTouch.current.x;
        const dy = locationY - lastTouch.current.y;
        lastTouch.current = { x: locationX, y: locationY };
        const ndc = ndcFromLocation(locationX, locationY);
        toyRef.current?.pointerMove(ndc.x, ndc.y, dx, dy);
      },
      onPanResponderRelease: () => {
        toyRef.current?.pointerUp();
      },
      onPanResponderTerminate: () => {
        toyRef.current?.pointerUp();
      },
    })
  ).current;

  const current = COLOR_DEFS[selected];

  return (
    <View style={styles.container}>
      <View style={styles.content}>
        <View style={styles.topBar}>
          <Text onPress={onBack} style={[styles.back, { color: current.deep }]}>
            ‹
          </Text>
          <Animated.View style={[styles.coinPill, { transform: [{ scale: coinScale }] }]}>
            <View style={styles.coinPillDot} />
            <Text style={styles.coinPillText}>{displayCoins}</Text>
          </Animated.View>
          <View style={styles.topBarSpacer} />
          <Pressable onPress={toggleSettings} style={styles.settingsButton} hitSlop={8}>
            <Animated.View style={{ transform: [{ rotate: settingsSpin }] }}>
              <MaterialIcons name="widgets" size={20} color={current.deep} />
            </Animated.View>
          </Pressable>
        </View>

        <View style={styles.stage} {...panResponder.panHandlers}>
          <Canvas flat camera={{ fov: 32, position: [0, 0.15, 4.4], near: 0.1, far: 100 }}>
            <ambientLight intensity={0.62} />
            <directionalLight color={0xfff2e0} intensity={1.35} position={[2.2, 3, 3]} />
            <directionalLight color={0xcdd8ff} intensity={0.55} position={[-2.5, -1, 2]} />
            <directionalLight color={0xffffff} intensity={0.4} position={[-1.5, 2, -3]} />
            <SquishyToy
              ref={toyRef}
              startingColorIndex={selected}
              species={toy.species}
              onSquish={() => {
                if (squishSoundEnabled) soundRef.current?.start();
                startCoinTimer();
              }}
              onRelease={(_amount, switchingToOrbit) => {
                soundRef.current?.stop();
                if (!switchingToOrbit && releaseSoundEnabled) popSoundRef.current?.play();
                stopCoinTimer();
              }}
            />
          </Canvas>

          <View style={StyleSheet.absoluteFillObject} pointerEvents="none">
            {popups.map((p) => (
              <CoinPopup key={p.id} x={p.x} y={p.y} amount={p.amount} onDone={() => removePopup(p.id)} />
            ))}
          </View>
        </View>

        <View style={styles.legend}>
          <View style={styles.legendDivider} />
          <View style={styles.legendRow}>
            <Text style={styles.legendIcon}>☝️</Text>
            <Text style={styles.legendArrow}>→</Text>
            <Text style={styles.legendText}>squish squish</Text>
          </View>
          <View style={styles.legendRow}>
            <Text style={styles.legendIcon}>✌️</Text>
            <Text style={styles.legendArrow}>→</Text>
            <Text style={styles.legendText}>rotate</Text>
          </View>
        </View>

        <Modal visible={settingsOpen} transparent animationType="fade" onRequestClose={toggleSettings}>
          <Pressable style={styles.settingsBackdrop} onPress={toggleSettings}>
            <Pressable style={styles.settingsPopup} onPress={() => {}}>
              <Text style={styles.settingsTitle}>Sound</Text>
              <View style={styles.settingsRow}>
                <Text style={styles.settingsLabel}>Squish</Text>
                <Switch
                  value={squishSoundEnabled}
                  onValueChange={onToggleSquishSound}
                  trackColor={{ false: colors.surfaceBorder, true: colors.accent }}
                  thumbColor="#FFFFFF"
                />
              </View>
              <View style={styles.settingsRow}>
                <Text style={styles.settingsLabel}>Coins</Text>
                <Switch
                  value={coinSoundEnabled}
                  onValueChange={onToggleCoinSound}
                  trackColor={{ false: colors.surfaceBorder, true: colors.accent }}
                  thumbColor="#FFFFFF"
                />
              </View>
              <View style={styles.settingsRow}>
                <Text style={styles.settingsLabel}>Release</Text>
                <Switch
                  value={releaseSoundEnabled}
                  onValueChange={onToggleReleaseSound}
                  trackColor={{ false: colors.surfaceBorder, true: colors.accent }}
                  thumbColor="#FFFFFF"
                />
              </View>
            </Pressable>
          </Pressable>
        </Modal>

        <WatchAdButton
          onRewardEarned={handleAdReward}
          boostSecondsLeft={boostSecondsLeft}
          boostTotalSeconds={BOOST_DURATION_MS / 1000}
        />
      </View>

      <View style={{ paddingBottom: insets.bottom }}>
        <AdBanner />
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, backgroundColor: colors.bg },
  content: { flex: 1, alignItems: 'center' },
  topBar: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: spacing(4),
    width: '100%',
    paddingHorizontal: spacing(5),
    paddingTop: spacing(12),
  },
  back: { fontSize: 26, fontWeight: '700' },
  coinPill: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: spacing(1.5),
    backgroundColor: colors.surface,
    borderRadius: 999,
    paddingHorizontal: spacing(3.5),
    paddingVertical: spacing(1.5),
    shadowColor: colors.accent,
    shadowOpacity: 0.12,
    shadowRadius: 8,
    shadowOffset: { width: 0, height: 4 },
    elevation: 2,
  },
  coinPillDot: {
    width: 16,
    height: 16,
    borderRadius: 8,
    backgroundColor: colors.coinGold,
    borderWidth: 2,
    borderColor: colors.coinGoldDeep,
  },
  coinPillText: { fontSize: 14, fontWeight: '800', color: colors.textPrimary },
  topBarSpacer: { flex: 1 },
  settingsButton: {
    width: 36,
    height: 36,
    borderRadius: 18,
    alignItems: 'center',
    justifyContent: 'center',
    backgroundColor: colors.surface,
    shadowColor: colors.accent,
    shadowOpacity: 0.12,
    shadowRadius: 8,
    shadowOffset: { width: 0, height: 4 },
    elevation: 2,
  },
  stage: { width: STAGE_WIDTH, height: STAGE_HEIGHT, marginTop: spacing(3) },
  legend: {
    width: '100%',
    marginTop: spacing(3),
    paddingHorizontal: spacing(5),
    alignItems: 'flex-start',
  },
  legendDivider: {
    width: '100%',
    height: 1,
    backgroundColor: colors.surfaceBorder,
    marginBottom: spacing(3),
  },
  legendRow: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: spacing(2),
    marginBottom: spacing(1.5),
  },
  legendIcon: { fontSize: 18 },
  legendArrow: { fontSize: 14, color: colors.textMuted },
  legendText: { fontSize: 14, fontWeight: '700', color: colors.textPrimary },
  settingsBackdrop: {
    flex: 1,
    backgroundColor: 'rgba(58,46,77,0.35)',
    alignItems: 'flex-end',
    paddingTop: spacing(12) + 44,
    paddingRight: spacing(5),
  },
  settingsPopup: {
    minWidth: 190,
    backgroundColor: colors.surface,
    borderRadius: radii.md,
    paddingVertical: spacing(3.5),
    paddingHorizontal: spacing(4),
    gap: spacing(3),
    shadowColor: colors.accent,
    shadowOpacity: 0.2,
    shadowRadius: 16,
    shadowOffset: { width: 0, height: 8 },
    elevation: 8,
  },
  settingsTitle: {
    fontSize: 12,
    fontWeight: '800',
    color: colors.textMuted,
    textTransform: 'uppercase',
    letterSpacing: 0.5,
    marginBottom: spacing(1),
  },
  settingsRow: {
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'space-between',
    gap: spacing(4),
  },
  settingsLabel: { fontSize: 14, fontWeight: '700', color: colors.textPrimary },
});
