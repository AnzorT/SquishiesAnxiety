import React, { useCallback, useEffect, useRef, useState } from 'react';
import { View, Text, StyleSheet, PanResponder, Pressable, Modal, Animated } from 'react-native';
import { Canvas } from '@react-three/fiber';
import SquishyToy, { COLOR_DEFS, FILLS } from '../components/SquishyToy';
import SquishSound from '../audio/SquishSound';
import CoinSound from '../audio/CoinSound';
import { colors, spacing, radii } from '../theme/tokens';
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

const STAGE_WIDTH = 360;
const STAGE_HEIGHT = 360;
const COIN_FLUSH_MS = 1500;
const COIN_TICK_MS = 1500;
const COIN_START_DELAY_MS = 500;

function firstAllowedColorIndex(toy) {
  if (!toy.colors?.length) return toy.startingColorIndex ?? 0;
  const idx = COLOR_DEFS.findIndex((c) => toy.colors.includes(c.mid));
  return idx === -1 ? 0 : idx;
}

export default function SquishScreen({ toy, coins = 0, onBack, onEarnCoins }) {
  const toyRef = useRef(null);
  const soundRef = useRef(null);
  const coinSoundRef = useRef(null);
  const lastTouch = useRef({ x: 0, y: 0 });
  const activeModeRef = useRef(false);
  const coinStartTimeoutRef = useRef(null);
  const coinTimerRef = useRef(null);
  const pendingCoinsRef = useRef(0);
  const sessionCoinsRef = useRef(0);
  const popupIdRef = useRef(0);
  const coinScale = useRef(new Animated.Value(1)).current;
  const coinFirstRender = useRef(true);
  const [displayCoins, setDisplayCoins] = useState(coins);
  const [sessionCoins, setSessionCoins] = useState(0);
  const [popups, setPopups] = useState([]);
  const [selected, setSelected] = useState(() => firstAllowedColorIndex(toy));
  const [fillIndex, setFillIndex] = useState(1);
  const [showFillSheet, setShowFillSheet] = useState(false);

  useEffect(() => {
    const sound = new SquishSound();
    soundRef.current = sound;
    sound.load();
    return () => {
      sound.unload();
    };
  }, []);

  useEffect(() => {
    const sound = new CoinSound();
    coinSoundRef.current = sound;
    sound.load();
    return () => {
      sound.unload();
    };
  }, []);

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
      pendingCoinsRef.current += amount;
      sessionCoinsRef.current += amount;
      setDisplayCoins((c) => c + amount);
      setSessionCoins(sessionCoinsRef.current);
      coinSoundRef.current?.play();
      if (at) {
        const id = ++popupIdRef.current;
        setPopups((prev) => {
          const next = [...prev, { id, amount, x: at.x, y: at.y }];
          return next.length > 12 ? next.slice(next.length - 12) : next;
        });
      }
    },
    []
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

  const handleAdReward = useCallback(() => {
    const bonus = sessionCoinsRef.current;
    if (bonus <= 0) return;
    sessionCoinsRef.current = 0;
    setSessionCoins(0);
    pendingCoinsRef.current += bonus;
    setDisplayCoins((c) => c + bonus);
    coinSoundRef.current?.play();
  }, []);

  const selectFill = (i) => {
    setFillIndex(i);
    toyRef.current?.selectFill(i);
    setShowFillSheet(false);
  };

  const ndcFromLocation = (locationX, locationY) => ({
    x: (locationX / STAGE_WIDTH) * 2 - 1,
    y: -((locationY / STAGE_HEIGHT) * 2 - 1),
  });

  const panResponder = useRef(
    PanResponder.create({
      onStartShouldSetPanResponder: () => true,
      onMoveShouldSetPanResponder: () => true,
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
          // the new mode rather than mixing squish and orbit deltas.
          activeModeRef.current = rotate;
          toyRef.current?.pointerUp();
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
  const currentFill = FILLS[fillIndex];

  return (
    <View style={[styles.container, { backgroundColor: current.light }]}>
      <View style={styles.topBar}>
        <Text onPress={onBack} style={[styles.back, { color: current.deep }]}>
          ‹
        </Text>
        <Animated.Text
          style={[styles.scoreText, { color: current.deep, transform: [] }]}
        >
          Coins: <Text style={styles.scoreValue}>{displayCoins}⊙</Text>
        </Animated.Text>
      </View>

      <Pressable style={styles.fillPill} onPress={() => setShowFillSheet(true)}>
        <View style={[styles.fillPillDot, { backgroundColor: currentFill.color }]} />
        <Text style={styles.fillPillText}>Fill · {currentFill.name}</Text>
        <Text style={styles.fillPillChevron}>▾</Text>
      </Pressable>

      <View style={styles.stage} {...panResponder.panHandlers}>
        <Canvas flat camera={{ fov: 32, position: [0, 0.15, 4.4], near: 0.1, far: 100 }}>
          <ambientLight intensity={0.62} />
          <directionalLight color={0xfff2e0} intensity={1.35} position={[2.2, 3, 3]} />
          <directionalLight color={0xcdd8ff} intensity={0.55} position={[-2.5, -1, 2]} />
          <directionalLight color={0xffffff} intensity={0.4} position={[-1.5, 2, -3]} />
          <SquishyToy
            ref={toyRef}
            startingColorIndex={selected}
            startingFillIndex={fillIndex}
            onSquish={() => {
              soundRef.current?.start();
              startCoinTimer();
            }}
            onRelease={() => {
              soundRef.current?.stop();
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

      <WatchAdButton onRewardEarned={handleAdReward} disabled={sessionCoins === 0} />
      <AdBanner />

      <Modal
        visible={showFillSheet}
        transparent
        animationType="slide"
        onRequestClose={() => setShowFillSheet(false)}
      >
        <Pressable style={styles.sheetBackdrop} onPress={() => setShowFillSheet(false)}>
          <Pressable style={styles.sheet} onPress={() => {}}>
            <View style={styles.sheetHandle} />
            <Text style={styles.sheetTitle}>Change fill</Text>
            <Text style={styles.sheetSubtitle}>Each fill squishes differently.</Text>
            {FILLS.map((fill, i) => (
              <Pressable key={fill.key} style={styles.fillRow} onPress={() => selectFill(i)}>
                <View style={[styles.fillDot, { backgroundColor: fill.color }]} />
                <View style={styles.fillRowText}>
                  <Text style={styles.fillName}>{fill.name}</Text>
                  <Text style={styles.fillDesc}>{fill.desc}</Text>
                </View>
                {i === fillIndex && <Text style={styles.fillCheck}>✓</Text>}
              </Pressable>
            ))}
          </Pressable>
        </Pressable>
      </Modal>
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, alignItems: 'center' },
  topBar: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: spacing(4),
    width: '100%',
    paddingHorizontal: spacing(5),
    paddingTop: spacing(12),
  },
  back: { fontSize: 26, fontWeight: '700' },
  scoreText: { fontSize: 15, fontWeight: '600' },
  scoreValue: {
    fontWeight: '800',
    color: colors.coinGoldDeep,
    textShadowColor: colors.coinGoldShine,
    textShadowRadius: 1,
    textShadowOffset: { width: 0, height: -1 },
  },
  title: {
    fontSize: 32,
    fontWeight: '800',
    marginTop: spacing(4),
    letterSpacing: -0.5,
  },
  swatchRow: {
    flexDirection: 'row',
    gap: spacing(3),
    marginTop: spacing(4),
  },
  swatchBtn: {
    width: 46,
    height: 46,
    borderRadius: 23,
    borderWidth: 3,
    backgroundColor: '#FFFFFF',
    alignItems: 'center',
    justifyContent: 'center',
  },
  swatchInner: { width: 26, height: 26, borderRadius: 13 },
  fillPill: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: 6,
    marginTop: spacing(3),
    backgroundColor: colors.glass,
    borderRadius: radii.pill,
    paddingHorizontal: spacing(4),
    paddingVertical: spacing(2),
  },
  fillPillDot: { width: 14, height: 14, borderRadius: 7 },
  fillPillText: { fontSize: 13, fontWeight: '700', color: colors.textPrimary },
  fillPillChevron: { fontSize: 10, color: colors.textMuted },
  stage: { width: STAGE_WIDTH, height: STAGE_HEIGHT, marginTop: spacing(3) },
  legend: {
    width: '100%',
    maxWidth: 300,
    marginTop: spacing(3),
    alignItems: 'center',
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
  sheetBackdrop: {
    flex: 1,
    backgroundColor: 'rgba(58,46,77,0.4)',
    justifyContent: 'flex-end',
  },
  sheet: {
    width: '100%',
    backgroundColor: colors.surface,
    borderTopLeftRadius: radii.lg,
    borderTopRightRadius: radii.lg,
    paddingTop: spacing(3),
    paddingHorizontal: spacing(6),
    paddingBottom: spacing(7),
    shadowColor: '#6E46A0',
    shadowOffset: { width: 0, height: -8 },
    shadowOpacity: 0.2,
    shadowRadius: 24,
    elevation: 8,
  },
  sheetHandle: {
    width: 36,
    height: 4,
    borderRadius: 2,
    backgroundColor: colors.surfaceBorder,
    alignSelf: 'center',
    marginBottom: spacing(4),
  },
  sheetTitle: { fontSize: 18, fontWeight: '700', color: colors.textPrimary, marginBottom: spacing(1) },
  sheetSubtitle: { fontSize: 13, color: colors.textMuted, marginBottom: spacing(2) },
  fillRow: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: spacing(3.5),
    paddingVertical: spacing(3),
    borderBottomWidth: 1,
    borderBottomColor: '#F1E9FC',
  },
  fillDot: { width: 36, height: 36, borderRadius: 18, flexShrink: 0 },
  fillRowText: { flex: 1 },
  fillName: { fontSize: 15, fontWeight: '700', color: colors.textPrimary },
  fillDesc: { fontSize: 12, color: colors.textMuted, marginTop: 2 },
  fillCheck: { color: colors.accent, fontSize: 18, fontWeight: '700' },
});
