import React, { useEffect, useMemo, useRef, useState } from 'react';
import { Animated, Easing, Pressable, StyleSheet, Text, View, useWindowDimensions } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { LinearGradient } from 'expo-linear-gradient';
import ShadowText, { outline3 } from '../components/candy/ShadowText';
import OutlinedTitle from '../components/candy/OutlinedTitle';
import { RaysSpin } from '../components/candy/Decor';
import CreatureThumbnail from '../components/CreatureThumbnail';
import sfx from '../audio/sfx';
import { BY_ID, FIN_LOOK, RAR_LOOK } from '../squad/data';
import MOVES from '../squad/moves';
import { BtnText, CandyBtn, F, StarIcon } from '../squad/ui';
import TutTarget from '../tutorial/Target';

// What came out of a chest (the design's "Reveal Show"): the squishy
// launches onto a disco floor, waves, does its signature move, then a
// banner with its name and rarity drops in (NEW! if it's new). Rarer pulls
// get more show — the floor from Rare, spotlights and a beat from Epic,
// fireworks from Legendary — with confetti cannons on every landing.
// Tap to skip to the end. A duplicate shows the Stars it paid, a set's last
// member the reward creature that came with it.
//
// Timeline (ms): land 880 · wave 1100 · dance 1900 · celebrate 1900 + D ·
// banner +500 · stamp +900 · done +1300, with D = 1500 … 3000 by rarity.

const DANCE_MS = [1500, 2000, 2500, 3000, 3000];
const TILE_C = ['#ff5cc6', '#ffd23a', '#3fd7f6', '#c78bff'];
const CONFETTI = ['#ff5cc6', '#ffd23a', '#3fd7f6', '#7be495', '#c78bff', '#ffffff'];
const SPARKLES = Array.from({ length: 10 }, (_, i) => ({ x: ((i * 37 + 9) % 92) + 3, y: ((i * 53 + 7) % 60) + 4, size: 10 + ((i * 7) % 12), ms: 1600 + (i % 5) * 400 }));
const rnd = (a, b) => a + Math.random() * (b - a);

function Twinkle({ x, y, size, ms }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const loop = Animated.loop(Animated.sequence([Animated.timing(t, { toValue: 1, duration: ms / 2, useNativeDriver: true }), Animated.timing(t, { toValue: 0, duration: ms / 2, useNativeDriver: true })]));
    loop.start();
    return () => loop.stop();
  }, [t, ms]);
  return (
    <Animated.Text style={{ position: 'absolute', left: `${x}%`, top: `${y}%`, fontSize: size, color: '#ffffff', opacity: t.interpolate({ inputRange: [0, 1], outputRange: [0.2, 1] }), transform: [{ scale: t.interpolate({ inputRange: [0, 1], outputRange: [0.6, 1.1] }) }] }}>
      ✦
    </Animated.Text>
  );
}

// A burst of confetti from both bottom corners (the cannons).
function Confetti({ shot, width, height }) {
  const pieces = useMemo(() => {
    const out = [];
    for (let side = 0; side < 2; side++)
      for (let i = 0; i < 22; i++) {
        const s = side ? -1 : 1;
        out.push({ key: `${shot}-${side}-${i}`, x: side ? width - 26 : 18, w: Math.round(rnd(6, 10)), h: Math.round(rnd(10, 16)), round: i % 3 === 0, c: CONFETTI[i % CONFETTI.length], dx: s * rnd(70, 230), dy: -rnd(320, 560), fall: rnd(560, 720), rot: rnd(-720, 720), ms: rnd(1600, 2100) });
      }
    return out;
  }, [shot, width]);
  return pieces.map((p) => <ConfettiBit key={p.key} p={p} top={height - 60} />);
}
function ConfettiBit({ p, top }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    Animated.timing(t, { toValue: 1, duration: p.ms, easing: Easing.linear, useNativeDriver: true }).start();
  }, [t, p]);
  return (
    <Animated.View
      style={{
        position: 'absolute', left: p.x, top, width: p.w, height: p.h, borderRadius: p.round ? p.w : 2, backgroundColor: p.c,
        opacity: t.interpolate({ inputRange: [0, 0.8, 1], outputRange: [1, 1, 0] }),
        transform: [
          { translateX: t.interpolate({ inputRange: [0, 0.42, 1], outputRange: [0, p.dx, p.dx * 1.35] }) },
          { translateY: t.interpolate({ inputRange: [0, 0.42, 1], outputRange: [0, p.dy, p.dy + p.fall], easing: Easing.inOut(Easing.quad) }) },
          { rotate: t.interpolate({ inputRange: [0, 1], outputRange: ['0deg', `${p.rot}deg`] }) },
        ],
      }}
    />
  );
}

// A firework: 16 sparks out from a point.
function Firework({ x, y, delay, colors }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    Animated.sequence([Animated.delay(delay), Animated.timing(t, { toValue: 1, duration: 1100, easing: Easing.out(Easing.cubic), useNativeDriver: true })]).start();
  }, [t, delay]);
  return (
    <View style={{ position: 'absolute', left: `${x}%`, top: `${y}%` }} pointerEvents="none">
      {Array.from({ length: 16 }, (_, i) => {
        const a = (i / 16) * Math.PI * 2;
        const d = 60 + (i % 3) * 14;
        const s = 5 + (i % 2) * 2;
        return (
          <Animated.View
            key={i}
            style={{
              position: 'absolute', width: s, height: s, borderRadius: s, backgroundColor: colors[i % 4], marginLeft: -s / 2, marginTop: -s / 2,
              opacity: t.interpolate({ inputRange: [0, 0.12, 1], outputRange: [0, 1, 0] }),
              transform: [{ translateX: t.interpolate({ inputRange: [0, 1], outputRange: [0, Math.cos(a) * d] }) }, { translateY: t.interpolate({ inputRange: [0, 1], outputRange: [0, Math.sin(a) * d + 12] }) }],
            }}
          />
        );
      })}
    </View>
  );
}

// The dance floor: 8 × 4 tiles in perspective, flashing on the beat.
function Floor({ beat, lit, width }) {
  const tileW = (width * 1.5) / 8;
  return (
    <View style={[styles.floorWrap, { opacity: lit ? 1 : 0.35 }]} pointerEvents="none">
      <View style={{ width: width * 1.5, flexDirection: 'row', flexWrap: 'wrap', transform: [{ perspective: 600 }, { rotateX: '58deg' }] }}>
        {Array.from({ length: 32 }, (_, i) => {
          const on = (i + Math.floor(i / 8) + beat) % 2 === 0;
          const c = TILE_C[(i + Math.floor(i / 8)) % 4];
          return <View key={i} style={{ width: tileW - 6, height: tileW * 0.9, margin: 3, borderRadius: 8, borderWidth: 2, borderColor: 'rgba(255,255,255,0.6)', backgroundColor: on ? c : 'rgba(255,255,255,0.10)' }} />;
        })}
      </View>
    </View>
  );
}

export default function RevealShow({ pull, creature, chestName, canAgain, onAgain, onClose }) {
  const insets = useSafeAreaInsets();
  const { width, height } = useWindowDimensions();
  const rar = Math.min(4, pull.rar ?? BY_ID[pull.id]?.rar ?? 0);
  const R = RAR_LOOK[rar];
  const D = DANCE_MS[rar];
  const move = MOVES[Number(pull.id)] || ['Happy Dance', 'sway'];
  const fin = pull.f && pull.f !== 'n' ? FIN_LOOK[pull.f] : null;

  const [phase, setPhase] = useState('launch');
  const [beat, setBeat] = useState(0);
  const [landed, setLanded] = useState(false);
  const [shot, setShot] = useState(0);
  const [fireworks, setFireworks] = useState(false);
  const [banner, setBanner] = useState(false);
  const [stamp, setStamp] = useState(false);
  const [ready, setReady] = useState(false);
  const timers = useRef([]);

  const launch = useRef(new Animated.Value(0)).current;
  const jump = useRef(new Animated.Value(0)).current;
  const shake = useRef(new Animated.Value(0)).current;
  const bannerIn = useRef(new Animated.Value(0)).current;
  const stampIn = useRef(new Animated.Value(0)).current;
  const moveIn = useRef(new Animated.Value(0)).current;

  const shakeIt = () => {
    shake.setValue(0);
    Animated.timing(shake, { toValue: 1, duration: 350, easing: Easing.out(Easing.quad), useNativeDriver: true }).start();
  };

  useEffect(() => {
    const at = (ms, fn) => timers.current.push(setTimeout(fn, ms));
    const beatT = setInterval(() => setBeat((b) => b + 1), rar >= 2 ? 500 : 1000);
    Animated.timing(launch, { toValue: 1, duration: 1100, easing: Easing.out(Easing.back(1.4)), useNativeDriver: true }).start();
    sfx.play('whoosh');
    at(880, () => {
      setLanded(true);
      shakeIt();
      if (rar >= 1) setShot((k) => k + 1);
      sfx.play('boxThump');
    });
    at(1100, () => setPhase('wave'));
    at(1900, () => {
      setPhase('dance');
      Animated.spring(moveIn, { toValue: 1, friction: 6, useNativeDriver: true }).start();
    });
    at(1900 + D, () => {
      setPhase('celebrate');
      setFireworks(rar >= 3);
      shakeIt();
      if (rar >= 1) setShot((k) => k + 1);
      Animated.sequence([Animated.timing(jump, { toValue: 1, duration: 280, easing: Easing.out(Easing.quad), useNativeDriver: true }), Animated.timing(jump, { toValue: 0, duration: 420, easing: Easing.bounce, useNativeDriver: true })]).start();
      sfx.play(rar >= 3 ? 'jackpot' : 'win');
    });
    at(1900 + D + 500, () => {
      setBanner(true);
      shakeIt();
      Animated.spring(bannerIn, { toValue: 1, friction: 6, tension: 90, useNativeDriver: true }).start();
    });
    at(1900 + D + 900, () => {
      if (pull.isNew || pull.newFinish) {
        setStamp(true);
        Animated.spring(stampIn, { toValue: 1, friction: 5, tension: 120, useNativeDriver: true }).start();
        sfx.play('sparkle');
      }
    });
    at(1900 + D + 1300, () => {
      setPhase('done');
      setReady(true);
    });
    return () => {
      timers.current.forEach(clearTimeout);
      clearInterval(beatT);
    };
    // runs once per pull
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const skip = () => {
    if (ready) return;
    timers.current.forEach(clearTimeout);
    timers.current = [];
    launch.setValue(1);
    setLanded(true);
    setPhase('done');
    setBanner(true);
    bannerIn.setValue(1);
    if (pull.isNew || pull.newFinish) {
      setStamp(true);
      stampIn.setValue(1);
    }
    setFireworks(false);
    setReady(true);
  };

  const mood = phase === 'launch' ? 'reveal' : phase === 'dance' ? 'dance' : phase === 'wave' ? 'happy' : phase === 'celebrate' ? 'happy' : 'idle';
  const shakeX = shake.interpolate({ inputRange: [0, 0.2, 0.4, 0.6, 1], outputRange: [0, -8, 7, -4, 0] });
  const size = Math.min(220, width * 0.55);
  const cam = phase === 'dance' ? (rar >= 2 ? 1.22 : 1.1) : 1;

  return (
    <Pressable style={StyleSheet.absoluteFill} onPress={skip}>
      <Animated.View style={[StyleSheet.absoluteFill, { transform: [{ translateX: shakeX }] }]}>
        <LinearGradient colors={['#2a0b57', '#5a1fa6', '#8f3cf2', '#c06bff']} locations={[0, 0.35, 0.7, 1]} style={StyleSheet.absoluteFill} />
        <View style={[StyleSheet.absoluteFill, { alignItems: 'center', justifyContent: 'center' }]} pointerEvents="none">
          <RaysSpin size={height * 1.1} durationMs={14000} rayDeg={8} gapDeg={12} opacity={rar >= 2 ? 0.35 : 0.22} color={R.dot} />
        </View>
        {SPARKLES.map((s, i) => (
          <Twinkle key={i} {...s} />
        ))}
        {rar >= 1 && <Floor beat={beat} lit={landed} width={width} />}
        {rar >= 2 && landed && (
          <>
            <View style={[styles.beam, { left: -40, backgroundColor: ['#ff8fd8', '#fff3a0', '#7cc8ff', '#c78bff'][beat % 4], transform: [{ rotate: '28deg' }] }]} pointerEvents="none" />
            <View style={[styles.beam, { right: -40, backgroundColor: ['#7cc8ff', '#c78bff', '#ff8fd8', '#fff3a0'][beat % 4], transform: [{ rotate: '-28deg' }] }]} pointerEvents="none" />
          </>
        )}

        {phase !== 'launch' && phase !== 'wave' && phase !== 'done' && !banner && (
          <Animated.View style={[styles.moveWrap, { top: insets.top + 90, opacity: moveIn, transform: [{ scale: moveIn.interpolate({ inputRange: [0, 1], outputRange: [0.4, 1] }) }] }]} pointerEvents="none">
            <View style={styles.movePill}>
              <Text style={styles.moveTag}>SIGNATURE MOVE</Text>
            </View>
            <OutlinedTitle text={move[0]} fill="gold" size={28} outline={3} ring={2} drop={4} />
          </Animated.View>
        )}

        <View style={[StyleSheet.absoluteFill, { alignItems: 'center', justifyContent: 'center' }]} pointerEvents="none">
          <Animated.View
            style={{
              marginTop: height * 0.12,
              transform: [
                { translateY: launch.interpolate({ inputRange: [0, 0.6, 1], outputRange: [height * 0.5, -60, 0] }) },
                { translateY: jump.interpolate({ inputRange: [0, 1], outputRange: [0, -95] }) },
                { scale: launch.interpolate({ inputRange: [0, 0.6, 1], outputRange: [0.3, 1.1, cam] }) },
              ],
            }}
          >
            {fin && <View style={[styles.finGlow, { width: size, height: size, borderRadius: size / 2, backgroundColor: fin.glow }]} />}
            <CreatureThumbnail creature={creature} size={size} mood={mood} />
          </Animated.View>
        </View>

        {shot > 0 && <Confetti key={shot} shot={shot} width={width} height={height} />}
        {fireworks &&
          [[24, 20, 0], [76, 16, 250], [50, 8, 500], [30, 34, 750]].map(([x, y, d], j) => (
            <Firework key={j} x={x} y={y} delay={d} colors={[R.dot, '#ffd23a', '#ff5cc6', '#ffffff']} />
          ))}

        {banner && (
          <Animated.View style={[styles.banner, { top: insets.top + 60, opacity: bannerIn, transform: [{ translateY: bannerIn.interpolate({ inputRange: [0, 1], outputRange: [-60, 0] }) }, { scale: bannerIn.interpolate({ inputRange: [0, 1], outputRange: [2.2, 1] }) }] }]} pointerEvents="none">
            <View style={styles.nameRow}>
              <View style={[styles.ribbon, styles.ribbonL]} />
              <View style={[styles.ribbon, styles.ribbonR]} />
              <LinearGradient colors={['#ffd6f4', '#ff5cc6', '#c02bd9']} style={styles.namePill}>
                <ShadowText style={styles.name} shadows={outline3('#8e1580', 2.5)}>
                  {BY_ID[pull.id]?.name || creature?.name}
                </ShadowText>
              </LinearGradient>
            </View>
            <View style={styles.rarRow}>
              <View style={[styles.rarPill, { backgroundColor: R.bg }]}>
                <Text style={styles.rarText}>{R.label}</Text>
              </View>
              {fin && (
                <LinearGradient colors={fin.bg || ['#fffbe0', '#fff6a8']} start={{ x: 0, y: 0 }} end={{ x: 1, y: 0 }} style={styles.rarPill}>
                  <Text style={styles.rarText}>{fin.name.toUpperCase()}</Text>
                </LinearGradient>
              )}
              <Text style={styles.from}>from a {chestName.toLowerCase()} chest</Text>
            </View>
            {pull.stars > 0 && (
              <View style={styles.dupe}>
                <StarIcon size={16} />
                <Text style={styles.dupeText}>Duplicate! +{pull.stars} Stars</Text>
              </View>
            )}
            {pull.reward && (
              <View style={styles.dupe}>
                <Text style={styles.dupeText}>Set complete! {BY_ID[pull.reward]?.name} joined too</Text>
              </View>
            )}
          </Animated.View>
        )}

        {stamp && (
          <Animated.View style={[styles.stamp, { top: height * 0.47, left: width / 2 + size * 0.28, opacity: stampIn, transform: [{ scale: stampIn.interpolate({ inputRange: [0, 1], outputRange: [3, 1] }) }, { rotate: stampIn.interpolate({ inputRange: [0, 1], outputRange: ['-40deg', '-14deg'] }) }] }]} pointerEvents="none">
            <LinearGradient colors={['#fff7b0', '#ffd23a', '#ff9c0a']} style={styles.stampBadge}>
              <ShadowText style={styles.stampText} shadows={outline3('#9c4d06', 2)}>
                {pull.isNew ? 'NEW!' : 'NEW LOOK!'}
              </ShadowText>
            </LinearGradient>
          </Animated.View>
        )}

        <View style={[styles.foot, { paddingBottom: 24 + insets.bottom }]}>
          {ready ? (
            <View style={styles.footRow}>
              <TutTarget name="revealDone">
                <CandyBtn kind="gold" padV={11} padH={28} lip={5} onPress={canAgain ? onAgain : onClose}>
                  <BtnText size={18}>{canAgain ? 'OPEN ANOTHER' : 'YAY!'}</BtnText>
                </CandyBtn>
              </TutTarget>
            </View>
          ) : (
            <View style={styles.skip}>
              <Text style={styles.skipText}>TAP TO SKIP</Text>
            </View>
          )}
        </View>
      </Animated.View>
    </Pressable>
  );
}

const styles = StyleSheet.create({
  floorWrap: { position: 'absolute', left: 0, right: 0, bottom: -40, height: '42%', alignItems: 'center', justifyContent: 'flex-end', overflow: 'hidden' },
  beam: { position: 'absolute', bottom: -60, width: 70, height: '90%', opacity: 0.28, borderRadius: 40 },
  moveWrap: { position: 'absolute', left: 0, right: 0, alignItems: 'center', gap: 6 },
  movePill: { borderWidth: 2, borderColor: 'rgba(255,255,255,0.8)', borderRadius: 999, paddingHorizontal: 10, paddingVertical: 2, backgroundColor: 'rgba(42,11,87,0.55)' },
  moveTag: { fontFamily: F.black, fontSize: 11, letterSpacing: 1.6, color: '#ffffff' },
  finGlow: { position: 'absolute', opacity: 0.55 },
  banner: { position: 'absolute', left: 0, right: 0, alignItems: 'center', gap: 8 },
  nameRow: { alignItems: 'center', justifyContent: 'center' },
  ribbon: { position: 'absolute', top: 14, width: 60, height: 34, backgroundColor: '#8f3cf2' },
  ribbonL: { left: -44 },
  ribbonR: { right: -44 },
  namePill: { borderRadius: 22, borderWidth: 3.5, borderColor: '#ffffff', paddingHorizontal: 34, paddingVertical: 8 },
  name: { fontFamily: F.display, fontSize: 34, color: '#ffffff' },
  rarRow: { flexDirection: 'row', alignItems: 'center', gap: 8 },
  rarPill: { borderWidth: 3, borderColor: '#ffffff', borderRadius: 999, paddingHorizontal: 16, paddingVertical: 4 },
  rarText: { fontFamily: F.black, fontSize: 13, letterSpacing: 1.4, color: '#4a1a73' },
  from: { fontFamily: F.heavy, fontSize: 12, color: '#ffffff' },
  dupe: { flexDirection: 'row', alignItems: 'center', gap: 6, backgroundColor: 'rgba(255,255,255,0.92)', borderRadius: 999, paddingHorizontal: 12, paddingVertical: 4 },
  dupeText: { fontFamily: F.black, fontSize: 12, color: '#5a22c8' },
  stamp: { position: 'absolute' },
  stampBadge: { borderRadius: 14, borderWidth: 3, borderColor: '#ffffff', paddingHorizontal: 10, paddingVertical: 6 },
  stampText: { fontFamily: F.display, fontSize: 20, color: '#ffffff' },
  foot: { position: 'absolute', left: 0, right: 0, bottom: 0, alignItems: 'center' },
  footRow: { flexDirection: 'row', gap: 10 },
  skip: { backgroundColor: 'rgba(42,11,87,0.55)', borderRadius: 999, paddingHorizontal: 12, paddingVertical: 4 },
  skipText: { fontFamily: F.black, fontSize: 12, letterSpacing: 1.2, color: 'rgba(255,255,255,0.85)' },
});
