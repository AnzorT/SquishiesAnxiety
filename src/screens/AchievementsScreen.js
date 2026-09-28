import React, { useEffect, useMemo, useRef, useState } from 'react';
import { View, Text, StyleSheet, Animated, Easing, Pressable, PanResponder } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import Svg, { Defs, RadialGradient, Stop, Circle, Ellipse } from 'react-native-svg';
import { candyColors, candyFonts } from '../theme/candyTheme';
import { computeAchievements } from '../achievements';
import CandyBackground from '../components/candy/CandyBackground';
import RoundButton, { BackGlyph, Triangle } from '../components/candy/RoundButton';
import { CandyProgress, RaysSpin } from '../components/candy/Decor';
import { Shine } from '../components/candy/CandyButton';
import OutlinedTitle from '../components/candy/OutlinedTitle';
import CreatureThumbnail from '../components/CreatureThumbnail';

// Achievements as the v3 carousel: one big badge at a time under spinning
// rays and a pulsing halo, neighbours fanned out smaller to each side, the
// current one's title/description/progress underneath. Swipe or use the
// arrows; tapping a side badge jumps to it. See src/achievements.js for
// what's tracked and why.

const BADGE = 124;
const MAX_D = 5;

// Where a badge `d` steps from the centre sits (the design's own numbers).
const xOf = (d) => (d === 0 ? 0 : Math.sign(d) * (112 + (Math.abs(d) - 1) * 80));
const yOf = (d) => (d === 0 ? -14 : 24 + (Math.abs(d) - 1) * 8);
const scaleOf = (d) => (d === 0 ? 1 : Math.max(0.5, 0.76 - (Math.abs(d) - 1) * 0.1));
const opacityOf = (d) => (Math.abs(d) > 3 ? 0 : d === 0 ? 1 : 0.9 - (Math.abs(d) - 1) * 0.18);

// react-native-svg ignores <Stop>s wrapped in a fragment, so the two badge
// fills are plain arrays: [offset, color, opacity].
const DONE_STOPS = [[0, '#fffbe0', 1], [0.3, '#ffe45c', 1], [0.62, '#ffc21a', 1], [1, '#e08a00', 1]];
const LOCKED_STOPS = [[0, '#ffffff', 0.55], [0.45, '#e6b4ff', 0.4], [1, '#823cd2', 0.55]];

const OFFSETS = Array.from({ length: MAX_D * 2 + 1 }, (_, k) => k - MAX_D);

function Badge({ entry, index, pos, current, onSelect }) {
  const done = entry.done;
  const ring = done ? '#a0520a' : candyColors.outline;
  // item sits at d = index - pos
  const inputRange = OFFSETS.map((d) => index - d);
  const sorted = inputRange.map((v, k) => [v, OFFSETS[k]]).sort((a, b) => a[0] - b[0]);
  const range = sorted.map((e) => e[0]);
  const ds = sorted.map((e) => e[1]);
  const translateX = pos.interpolate({ inputRange: range, outputRange: ds.map(xOf), extrapolate: 'clamp' });
  const translateY = pos.interpolate({ inputRange: range, outputRange: ds.map(yOf), extrapolate: 'clamp' });
  const scale = pos.interpolate({ inputRange: range, outputRange: ds.map(scaleOf), extrapolate: 'clamp' });
  const opacity = pos.interpolate({ inputRange: range, outputRange: ds.map(opacityOf), extrapolate: 'clamp' });
  const isCreature = !!entry.creature;
  const label = String(entry.badgeLabel ?? '');

  return (
    <Animated.View
      style={[
        styles.badgeSlot,
        { zIndex: 50 - Math.abs(index - current), opacity, transform: [{ translateX }, { translateY }, { scale }] },
      ]}
    >
      <Pressable onPress={() => onSelect(index)} style={styles.fill}>
        <View style={[styles.badgeLip, { backgroundColor: ring }]} />
        <View style={[styles.badgeRing, { backgroundColor: ring }]}>
          <View style={styles.badgeWhite}>
            <Svg width={BADGE} height={BADGE} style={StyleSheet.absoluteFill}>
              <Defs>
                <RadialGradient id="badgeFill" cx="35%" cy="28%" r="75%">
                  {(done ? DONE_STOPS : LOCKED_STOPS).map(([o, c, a]) => (
                    <Stop key={o} offset={o} stopColor={c} stopOpacity={a} />
                  ))}
                </RadialGradient>
              </Defs>
              <Circle cx={BADGE / 2} cy={BADGE / 2} r={BADGE} fill="url(#badgeFill)" />
            </Svg>
            <View style={styles.badgeContent}>
              {isCreature ? (
                <CreatureThumbnail creature={entry.creature} mood="idle" size={84} locked={!done} animate={index === current} />
              ) : (
                <Text style={[styles.badgeLabel, { fontSize: label.length > 3 ? 30 : 40, textShadowColor: ring }]}>{label}</Text>
              )}
            </View>
            <Shine inset="16%" top="5%" height="38%" />
          </View>
        </View>
        {done ? (
          <View style={[styles.corner, styles.cornerCheck]}>
            <Text style={styles.cornerCheckText}>✓</Text>
          </View>
        ) : !isCreature ? (
          <View style={[styles.corner, styles.cornerLock]}>
            <View style={styles.miniShackle} />
            <View style={styles.miniBody} />
          </View>
        ) : null}
      </Pressable>
    </Animated.View>
  );
}

// Soft white→gold→pink glow behind the centre badge (haloPulse).
function Halo() {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(t, { toValue: 1, duration: 1000, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
        Animated.timing(t, { toValue: 0, duration: 1000, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
      ])
    );
    loop.start();
    return () => loop.stop();
  }, [t]);
  const scale = t.interpolate({ inputRange: [0, 1], outputRange: [0.9, 1.12] });
  const opacity = t.interpolate({ inputRange: [0, 1], outputRange: [0.55, 0.95] });
  return (
    <Animated.View pointerEvents="none" style={[styles.halo, { opacity, transform: [{ scale }] }]}>
      <Svg width={230} height={230}>
        <Defs>
          <RadialGradient id="halo" cx="50%" cy="50%" r="50%">
            <Stop offset="0" stopColor="#ffffff" stopOpacity={0.9} />
            <Stop offset="0.3" stopColor="#ffe6a0" stopOpacity={0.55} />
            <Stop offset="0.5" stopColor="#ff78dc" stopOpacity={0.3} />
            <Stop offset="0.7" stopColor="#ffffff" stopOpacity={0} />
          </RadialGradient>
        </Defs>
        <Circle cx={115} cy={115} r={115} fill="url(#halo)" />
      </Svg>
    </Animated.View>
  );
}

// The current badge's text block rises in each time the selection changes.
function Details({ entry, index, total }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    t.setValue(0);
    Animated.timing(t, { toValue: 1, duration: 400, easing: Easing.bezier(0.3, 1.4, 0.5, 1), useNativeDriver: true }).start();
  }, [t, index]);
  const translateY = t.interpolate({ inputRange: [0, 1], outputRange: [22, 0] });
  const scale = t.interpolate({ inputRange: [0, 1], outputRange: [0.8, 1] });
  const opacity = t.interpolate({ inputRange: [0, 0.7, 1], outputRange: [0, 1, 1] });
  const done = entry.done;
  const prog = entry.progress;
  const hasProg = !done && prog && prog.max > 1;
  return (
    <Animated.View style={[styles.details, { opacity, transform: [{ translateY }, { scale }] }]}>
      <Text style={styles.pos}>
        {index + 1} OF {total}
      </Text>
      <OutlinedTitle text={entry.title} fill={done ? 'gold' : 'pink'} size={26} outline={2.5} />
      <Text style={styles.desc}>{entry.desc}</Text>
      {hasProg ? (
        <View style={styles.progWrap}>
          <CandyProgress pct={(prog.cur / prog.max) * 100} height={12} ring={candyColors.pinkRing} fill={['#ffa8e6', '#ff4fbf']} horizontal={false} style={styles.progBar} />
          <Text style={styles.progText}>
            {prog.cur.toLocaleString()} / {prog.max.toLocaleString()}
          </Text>
        </View>
      ) : null}
      <Text style={[styles.status, done ? styles.statusDone : styles.statusLocked]}>{done ? '★ UNLOCKED' : 'LOCKED'}</Text>
    </Animated.View>
  );
}

export default function AchievementsScreen({ creatures = [], ownedIds = [], totalEarned = 0, achievements = {}, onBack }) {
  const insets = useSafeAreaInsets();
  const entries = useMemo(() => computeAchievements(creatures, ownedIds, totalEarned, achievements), [creatures, ownedIds, totalEarned, achievements]);
  const doneCount = entries.filter((e) => e.done).length;
  const [index, setIndex] = useState(0);
  const pos = useRef(new Animated.Value(0)).current;

  const go = (i) => {
    const next = Math.max(0, Math.min(entries.length - 1, i));
    setIndex(next);
    Animated.timing(pos, { toValue: next, duration: 500, easing: Easing.bezier(0.3, 1.3, 0.5, 1), useNativeDriver: true }).start();
  };
  const goRef = useRef(go);
  goRef.current = go;
  const indexRef = useRef(index);
  indexRef.current = index;

  const pan = useMemo(
    () =>
      PanResponder.create({
        onMoveShouldSetPanResponderCapture: (_e, g) => Math.abs(g.dx) > 10 && Math.abs(g.dx) > Math.abs(g.dy),
        onPanResponderRelease: (_e, g) => {
          if (g.dx < -36) goRef.current(indexRef.current + 1);
          else if (g.dx > 36) goRef.current(indexRef.current - 1);
        },
      }),
    []
  );

  const current = entries[index] || entries[0];

  return (
    <CandyBackground style={{ paddingTop: insets.top }}>
      <View style={styles.header}>
        <RoundButton size={36} onPress={onBack}>
          <BackGlyph />
        </RoundButton>
        <OutlinedTitle text="ACHIEVEMENTS" fill="pink" size={20} outline={3} />
        <Text style={styles.count}>
          {doneCount}/{entries.length}
        </Text>
      </View>
      <View style={styles.totalBar}>
        <CandyProgress pct={(doneCount / Math.max(1, entries.length)) * 100} height={12} />
      </View>

      <View style={styles.body}>
      <View style={styles.stage} {...pan.panHandlers}>
        <View style={styles.center} pointerEvents="none">
          <RaysSpin size={360} durationMs={12000} rayDeg={9} gapDeg={13} opacity={0.4} fadeStart={0.14} fadeEnd={0.62} />
          <Halo />
        </View>
        <View style={styles.shadowSpot} pointerEvents="none">
          <Svg width={150} height={26}>
            <Defs>
              <RadialGradient id="spot" cx="50%" cy="50%" r="50%">
                <Stop offset="0" stopColor="#3c006e" stopOpacity={0.35} />
                <Stop offset="0.7" stopColor="#3c006e" stopOpacity={0} />
              </RadialGradient>
            </Defs>
            <Ellipse cx={75} cy={13} rx={75} ry={13} fill="url(#spot)" />
          </Svg>
        </View>
        <View style={styles.center}>
          {entries.map((entry, i) =>
            Math.abs(i - index) <= MAX_D ? <Badge key={entry.key} entry={entry} index={i} pos={pos} current={index} onSelect={go} /> : null
          )}
        </View>
        <RoundButton size={38} onPress={() => go(index - 1)} dim={index === 0} style={[styles.arrow, { left: 10 }]}>
          <Triangle dir="left" size={8} />
        </RoundButton>
        <RoundButton size={38} onPress={() => go(index + 1)} dim={index === entries.length - 1} style={[styles.arrow, { right: 10 }]}>
          <Triangle dir="right" size={8} />
        </RoundButton>
      </View>

      {current ? (
        <View style={styles.detailsWrap}>
          <Details key={current.key} entry={current} index={index} total={entries.length} />
        </View>
      ) : null}
      </View>
      <View style={{ height: insets.bottom + 16 }} />
    </CandyBackground>
  );
}

const styles = StyleSheet.create({
  fill: { flex: 1 },
  header: { flexDirection: 'row', alignItems: 'center', gap: 8, paddingHorizontal: 16, paddingTop: 12, paddingBottom: 4 },
  count: {
    marginLeft: 'auto',
    color: candyColors.goldText,
    fontFamily: candyFonts.bodyBlack,
    fontSize: 14,
    textShadowColor: candyColors.outline,
    textShadowOffset: { width: 0, height: 2 },
    textShadowRadius: 1,
  },
  totalBar: { paddingHorizontal: 20, paddingTop: 2 },
  body: { flex: 1, justifyContent: 'center' },
  stage: { height: 380, overflow: 'hidden' },
  detailsWrap: { minHeight: 190 },
  center: { position: 'absolute', left: 0, right: 0, top: '46%', height: 0, alignItems: 'center', justifyContent: 'center' },
  halo: { position: 'absolute' },
  shadowSpot: { position: 'absolute', left: 0, right: 0, top: '78%', alignItems: 'center' },
  arrow: { position: 'absolute', top: '46%', marginTop: -21, zIndex: 60 },

  badgeSlot: { position: 'absolute', width: BADGE, height: BADGE + 7 },
  badgeLip: { position: 'absolute', top: 7, left: 0, width: BADGE, height: BADGE, borderRadius: BADGE / 2 },
  badgeRing: { position: 'absolute', top: 0, left: 0, width: BADGE, height: BADGE, borderRadius: BADGE / 2, padding: 3 },
  badgeWhite: { flex: 1, borderRadius: BADGE / 2, borderWidth: 5, borderColor: '#ffffff', overflow: 'hidden' },
  badgeContent: { ...StyleSheet.absoluteFillObject, alignItems: 'center', justifyContent: 'center' },
  badgeLabel: {
    color: '#ffffff',
    fontFamily: candyFonts.display,
    textShadowOffset: { width: 0, height: 3 },
    textShadowRadius: 1,
    includeFontPadding: false,
  },
  corner: {
    position: 'absolute',
    right: 2,
    top: 2,
    width: 30,
    height: 30,
    borderRadius: 15,
    borderWidth: 3,
    borderColor: '#ffffff',
    alignItems: 'center',
    justifyContent: 'center',
  },
  cornerCheck: { backgroundColor: '#1fa6dc' },
  cornerCheckText: { color: '#ffffff', fontFamily: candyFonts.bodyBlack, fontSize: 15, textShadowColor: '#0c5a9c', textShadowOffset: { width: 0, height: 1 }, textShadowRadius: 1 },
  cornerLock: { backgroundColor: '#8f3cf2' },
  miniShackle: { width: 8, height: 7, borderWidth: 2, borderBottomWidth: 0, borderColor: '#ffffff', borderTopLeftRadius: 5, borderTopRightRadius: 5 },
  miniBody: { width: 12, height: 8, borderRadius: 2, backgroundColor: '#ffffff' },

  details: { alignItems: 'center', paddingHorizontal: 28, gap: 6 },
  pos: {
    color: '#ffffff',
    fontFamily: candyFonts.displaySemi,
    fontSize: 12,
    letterSpacing: 1.4,
    textShadowColor: candyColors.outlineDeep,
    textShadowOffset: { width: 0, height: 1.5 },
    textShadowRadius: 1,
  },
  desc: {
    color: '#ffffff',
    fontFamily: candyFonts.displayMedium,
    fontSize: 15,
    lineHeight: 20,
    textAlign: 'center',
    maxWidth: 280,
    textShadowColor: candyColors.outlineDeep,
    textShadowOffset: { width: 0, height: 2 },
    textShadowRadius: 2,
  },
  progWrap: { width: 200, alignItems: 'center', gap: 4, marginTop: 2 },
  progBar: { width: '100%' },
  progText: {
    color: '#ffffff',
    fontFamily: candyFonts.displaySemi,
    fontSize: 12,
    textShadowColor: candyColors.outlineDeep,
    textShadowOffset: { width: 0, height: 1.5 },
    textShadowRadius: 1,
  },
  status: { fontFamily: candyFonts.display, fontSize: 13, letterSpacing: 1, textShadowOffset: { width: 0, height: 2 }, textShadowRadius: 1 },
  statusDone: { color: candyColors.goldText, textShadowColor: candyColors.goldRing },
  statusLocked: { color: '#ffffff', textShadowColor: candyColors.outlineDeep },
});
