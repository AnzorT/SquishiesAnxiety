import React, { useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { Animated, Easing, Pressable, StyleSheet, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { candyFonts } from '../theme/candyTheme';
import CandyBackground from '../components/candy/CandyBackground';
import CandyButton from '../components/candy/CandyButton';
import OutlinedTitle, { HaloText } from '../components/candy/OutlinedTitle';
import CreatureThumbnail from '../components/CreatureThumbnail';
import sfx from '../audio/sfx';

// The Daily Spin's FREE creature, as the v3 design's slot reel ("PICK A
// CREATURE"): the creatures you didn't own tick past one by one, TAP TO STOP
// slows the reel down, and it lands on your new creature. The server already
// picked and granted it (spinWheel) — the reel just lands on `winnerId`.

const FRAME = 170;
const CYCLES = 3;
const TICK_MS = 300;

export default function CreatureReelScreen({ creatures = [], lockedIds = [], winnerId, onDone }) {
  // The reel: the creatures that were locked, shuffled, with the winner in.
  const seq = useMemo(() => {
    const ids = lockedIds.includes(winnerId) ? lockedIds.slice() : [...lockedIds, winnerId];
    for (let i = ids.length - 1; i > 0; i--) {
      const j = Math.floor(Math.random() * (i + 1));
      [ids[i], ids[j]] = [ids[j], ids[i]];
    }
    return ids.map((id) => creatures.find((c) => c.id === id)).filter(Boolean);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);
  const n = Math.max(1, seq.length);
  const winIdx = Math.max(0, seq.findIndex((c) => c.id === winnerId));
  const winner = seq[winIdx];

  const [stage, setStage] = useState('running'); // 'running' | 'landing' | 'done'
  const y = useRef(new Animated.Value(0)).current;
  const flash = useRef(new Animated.Value(0)).current;

  // reelRoll: one creature every TICK_MS, round and round
  const roll = useRef(null);
  const tickRef = useRef(null);
  useEffect(() => {
    roll.current = Animated.loop(
      Animated.timing(y, { toValue: -n * FRAME, duration: n * TICK_MS, easing: (t) => Math.floor(t * n) / n, useNativeDriver: true })
    );
    roll.current.start();
    tickRef.current = sfx.loop('reelLoop');
    const blink = Animated.loop(
      Animated.sequence([
        Animated.timing(flash, { toValue: 1, duration: 450, useNativeDriver: false }),
        Animated.timing(flash, { toValue: 0, duration: 450, useNativeDriver: false }),
      ])
    );
    blink.start();
    return () => {
      roll.current && roll.current.stop();
      blink.stop();
      tickRef.current && tickRef.current.stop();
    };
  }, [y, flash, n]);

  const stop = useCallback(() => {
    if (stage !== 'running') return;
    setStage('landing');
    roll.current && roll.current.stop();
    tickRef.current && tickRef.current.stop();
    sfx.play('reelLand');
    // reelLand: glide down to the winner, three rounds on
    Animated.timing(y, { toValue: -(CYCLES * n + winIdx) * FRAME, duration: 2800, easing: Easing.bezier(0.14, 0.86, 0.2, 1), useNativeDriver: true }).start(() => {
      setStage('done');
      sfx.play('jackpot');
    });
  }, [stage, y, n, winIdx]);

  const frames = useMemo(() => {
    const out = [];
    for (let rep = 0; rep <= CYCLES; rep++) seq.forEach((c, i) => out.push({ key: `${rep}-${i}`, creature: c, win: rep === CYCLES && i === winIdx }));
    return out;
  }, [seq, winIdx]);

  const borderColor = flash.interpolate({ inputRange: [0, 1], outputRange: ['#6b3fa0', '#c25e00'] });
  const done = stage === 'done';
  const finish = useCallback(() => onDone(winnerId), [onDone, winnerId]);

  return (
    <CandyBackground sparkles style={styles.container}>
      <View style={styles.column}>
        <View style={styles.titles}>
          <OutlinedTitle text="PICK A CREATURE" fill="pink" size={22} />
          <HaloText style={styles.subtitle}>{done ? 'This one is yours' : 'Tap once to slow the reel down'}</HaloText>
        </View>

        <Animated.View style={[styles.window, { borderColor }]}>
          <LinearGradient colors={['#fff6fd', '#ffdcf4', '#f5cbff']} locations={[0, 0.6, 1]} style={StyleSheet.absoluteFill} />
          <View style={styles.reelClip}>
            <Animated.View style={{ transform: [{ translateY: y }] }}>
              {frames.map((f) => (
                <View key={f.key} style={styles.frame}>
                  <CreatureThumbnail creature={f.creature} mood="wobble" size={150} animate={done && f.win} />
                </View>
              ))}
            </Animated.View>
            <LinearGradient
              pointerEvents="none"
              colors={['rgba(255,255,255,0.85)', 'rgba(255,255,255,0)', 'rgba(255,255,255,0)', 'rgba(255,255,255,0.85)']}
              locations={[0, 0.22, 0.78, 1]}
              style={StyleSheet.absoluteFill}
            />
          </View>
        </Animated.View>

        <View style={styles.nameRow}>{done && winner ? <OutlinedTitle text={winner.name} fill="gold" size={19} /> : null}</View>

        {done ? (
          <CandyButton variant="blue" label={`UNLOCK ${winner ? winner.name.toUpperCase() : ''}`} onPress={finish} faceStyle={styles.ctaFace} textStyle={styles.ctaLabel} />
        ) : (
          <CandyButton variant="pink" label={stage === 'landing' ? 'SLOWING…' : 'TAP TO STOP'} onPress={stop} faceStyle={styles.stopFace} textStyle={styles.stopLabel} />
        )}
        <Pressable onPress={finish} hitSlop={8}>
          <HaloText style={styles.take}>TAKE THIS ONE &amp; CLOSE</HaloText>
        </Pressable>
      </View>
    </CandyBackground>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1 },
  column: { flex: 1, alignItems: 'center', justifyContent: 'center', gap: 24, padding: 24 },
  titles: { alignItems: 'center', gap: 5 },
  subtitle: { fontFamily: candyFonts.bodyHeavy, fontSize: 12 },
  window: {
    width: 224,
    height: 224,
    borderRadius: 28,
    borderWidth: 4,
    overflow: 'hidden',
    alignItems: 'center',
    justifyContent: 'center',
    shadowColor: '#6b3fa0',
    shadowOpacity: 0.3,
    shadowRadius: 20,
    shadowOffset: { width: 0, height: 18 },
    elevation: 8,
  },
  reelClip: { width: FRAME, height: FRAME, overflow: 'hidden' },
  frame: { width: FRAME, height: FRAME, alignItems: 'center', justifyContent: 'center' },
  nameRow: { minHeight: 34, justifyContent: 'center' },
  stopFace: { paddingVertical: 15, paddingHorizontal: 40 },
  stopLabel: { fontSize: 17, letterSpacing: 1 },
  ctaFace: { paddingVertical: 14, paddingHorizontal: 34 },
  ctaLabel: { fontSize: 12, letterSpacing: 1.6 },
  take: { fontFamily: candyFonts.bodyBlack, fontSize: 10, letterSpacing: 1.4 },
});
