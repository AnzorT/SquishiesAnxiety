import React, { memo, useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { View, Text, StyleSheet, Animated, Easing, Pressable, PanResponder } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Defs, RadialGradient, Stop, Circle, Ellipse } from 'react-native-svg';
import { candyColors, candyFonts } from '../theme/candyTheme';
import { computeAchievements } from '../achievements';
import CandyBackground from '../components/candy/CandyBackground';
import RoundButton, { BackGlyph, Triangle } from '../components/candy/RoundButton';
import { Shine } from '../components/candy/CandyButton';
import { CandyProgress, RaysSpin } from '../components/candy/Decor';
import OutlinedTitle from '../components/candy/OutlinedTitle';
import ShadowText, { outline3 } from '../components/candy/ShadowText';
import CreatureThumbnail from '../components/CreatureThumbnail';
import sfx from '../audio/sfx';

// Achievements, as the v3 design's carousel: one big badge at a time under
// spinning rays and a pulsing halo, neighbours fanned out smaller to either
// side, and the current badge's position / title / description / progress /
// status at the bottom of the screen. Swipe sideways, use the arrows, or tap
// a side badge. Opens on the first achievement not yet done. See
// src/achievements.js for the list itself.

const BADGE = 124; // the badge (white rim included); its ring sits outside
const RING = 3;
const LIP = 7;
const WINDOW = 5; // badges mounted either side of the current one

// Where a badge `d` steps from the centre sits — the design's numbers.
const xOf = (d) => (d === 0 ? 0 : Math.sign(d) * (112 + (Math.abs(d) - 1) * 80));
const yOf = (d) => (d === 0 ? -14 : 24 + (Math.abs(d) - 1) * 8);
const scaleOf = (d) => (d === 0 ? 1 : Math.max(0.5, 0.76 - (Math.abs(d) - 1) * 0.1));
const opacityOf = (d) => (Math.abs(d) > 3 ? 0 : d === 0 ? 1 : 0.9 - (Math.abs(d) - 1) * 0.18);

// transform: 0.5s cubic-bezier(0.3,1.3,0.5,1) (a little overshoot);
// opacity: 0.35s ease — as the design's two transitions.
const MOVE = { duration: 500, easing: Easing.bezier(0.3, 1.3, 0.5, 1) };
const FADE = { duration: 350, easing: Easing.bezier(0.25, 0.1, 0.25, 1) };

// react-native-svg ignores <Stop>s wrapped in a fragment, so the fills are
// arrays: [offset, color, opacity].
const DONE_STOPS = [[0, '#fffbe0', 1], [0.3, '#ffe45c', 1], [0.62, '#ffc21a', 1], [1, '#e08a00', 1]];
const LOCKED_STOPS = [[0, '#ffffff', 0.55], [0.45, '#e6b4ff', 0.4], [1, '#823cd2', 0.55]];

const OFFSETS = Array.from({ length: 11 }, (_, k) => k - WINDOW);

function curve(pos, index, fn) {
  // pos → value for a badge at `index`: it sits at d = index - pos
  const pairs = OFFSETS.map((d) => [index - d, fn(d)]).sort((a, b) => a[0] - b[0]);
  return pos.interpolate({ inputRange: pairs.map((p) => p[0]), outputRange: pairs.map((p) => p[1]), extrapolate: 'clamp' });
}

const Badge = memo(function Badge({ entry, index, move, fade, z, onSelect }) {
  const done = entry.done;
  const ring = done ? '#a0520a' : candyColors.outline;
  const label = String(entry.badgeLabel ?? '');
  const anim = useMemo(
    () => ({
      translateX: curve(move, index, xOf),
      translateY: curve(move, index, yOf),
      scale: curve(move, index, scaleOf),
      opacity: curve(fade, index, opacityOf),
      // centre only: the gold glow (box-shadow 0 0 34/16px) — side badges get
      // the design's slight dimming (brightness 0.92) instead
      glow: curve(fade, index, (d) => (d === 0 ? 1 : 0)),
      dim: curve(fade, index, (d) => (d === 0 ? 0 : 0.08)),
    }),
    [move, fade, index]
  );
  const glowR = BADGE / 2 + (done ? 34 : 16);

  return (
    <Animated.View
      style={[
        styles.slot,
        { zIndex: z, opacity: anim.opacity, transform: [{ translateX: anim.translateX }, { translateY: anim.translateY }, { scale: anim.scale }] },
      ]}
    >
      <Pressable onPress={() => onSelect(index)} style={styles.fill}>
        <Animated.View pointerEvents="none" style={[styles.glow, { width: glowR * 2, height: glowR * 2, marginLeft: -glowR, marginTop: -glowR, opacity: anim.glow }]}>
          <Svg width={glowR * 2} height={glowR * 2}>
            <Defs>
              <RadialGradient id="badgeGlow" cx="50%" cy="50%" r="50%">
                <Stop offset={(BADGE / 2 - 4) / glowR} stopColor="#ffdc78" stopOpacity={0.9} />
                <Stop offset="1" stopColor="#ffdc78" stopOpacity={0} />
              </RadialGradient>
            </Defs>
            <Circle cx={glowR} cy={glowR} r={glowR} fill="url(#badgeGlow)" />
          </Svg>
        </Animated.View>
        <View style={[styles.lip, { backgroundColor: ring }]} />
        <View style={[styles.ring, { backgroundColor: ring }]}>
          <View style={styles.rim}>
            <Svg width={BADGE - 10} height={BADGE - 10} style={StyleSheet.absoluteFill}>
              <Defs>
                <RadialGradient id="badgeFill" cx="35%" cy={done ? '28%' : '25%'} r={done ? '97%' : '99%'}>
                  {(done ? DONE_STOPS : LOCKED_STOPS).map(([o, c, a]) => (
                    <Stop key={o} offset={o} stopColor={c} stopOpacity={a} />
                  ))}
                </RadialGradient>
              </Defs>
              <Circle cx={(BADGE - 10) / 2} cy={(BADGE - 10) / 2} r={BADGE} fill="url(#badgeFill)" />
            </Svg>
            <View style={styles.content}>
              {entry.creature ? (
                <CreatureThumbnail creature={entry.creature} mood="idle" size={84} locked={!done} />
              ) : (
                <ShadowText
                  style={[styles.badgeLabel, { fontSize: label.length > 3 ? 30 : 40 }]}
                  shadows={[[0, 3, ring], [2, 0, ring], [-2, 0, ring], [0, -2, ring]]}
                >
                  {label}
                </ShadowText>
              )}
            </View>
            {/* the design's gloss (16% in from each side, 38% tall), but
                flush under the white rim like the buttons' — its 5% gap
                read as a hole */}
            <Shine inset="16%" height="38%" />
            <Animated.View pointerEvents="none" style={[styles.dim, { opacity: anim.dim }]} />
          </View>
        </View>
        {done ? (
          <View style={[styles.corner, styles.cornerCheckRing]}>
            <LinearGradient colors={['#b0fbff', '#1695d6']} style={styles.cornerFace}>
              <Text style={styles.cornerCheckText}>✓</Text>
            </LinearGradient>
          </View>
        ) : !entry.creature ? (
          <View style={[styles.corner, styles.cornerLockRing]}>
            <View style={[styles.cornerFace, styles.cornerLockFace]}>
              <View style={styles.miniShackle} />
              <View style={styles.miniBody} />
            </View>
          </View>
        ) : null}
      </Pressable>
    </Animated.View>
  );
});

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

// The current badge's text block; rises in each time the selection changes
// (riseIn: up from 22px and 0.8×, a small overshoot, 0.4s).
function Details({ entry, index, total }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    t.setValue(0);
    Animated.timing(t, { toValue: 1, duration: 400, easing: Easing.out(Easing.quad), useNativeDriver: true }).start();
  }, [t, index]);
  const translateY = t.interpolate({ inputRange: [0, 0.7, 1], outputRange: [22, -4, 0] });
  const scale = t.interpolate({ inputRange: [0, 0.7, 1], outputRange: [0.8, 1.05, 1] });
  const opacity = t.interpolate({ inputRange: [0, 0.7, 1], outputRange: [0, 1, 1] });
  const done = entry.done;
  const prog = entry.progress;
  const statusRing = done ? candyColors.goldRing : candyColors.outlineDeep;
  return (
    <Animated.View style={[styles.details, { opacity, transform: [{ translateY }, { scale }] }]}>
      <ShadowText style={styles.pos} shadows={[[0, 1.5, candyColors.outlineDeep]]}>
        {`${index + 1} OF ${total}`}
      </ShadowText>
      <OutlinedTitle text={entry.title} fill={done ? 'gold' : 'pink'} size={26} outline={2.5} ring={2} drop={4} letterSpacing={0} style={styles.title} />
      <ShadowText style={styles.desc} shadows={[[0, 2, candyColors.outlineDeep]]} numberOfLines={2}>
        {entry.desc}
      </ShadowText>
      {prog ? (
        <View style={styles.progWrap}>
          <CandyProgress pct={(prog.cur / prog.max) * 100} height={12} ring={candyColors.pinkRing} fill={['#ffa8e6', '#ff4fbf']} horizontal={false} style={styles.progBar} />
          <ShadowText style={styles.progText} shadows={[[0, 1.5, candyColors.outlineDeep]]}>
            {`${prog.cur.toLocaleString()} / ${prog.max.toLocaleString()}`}
          </ShadowText>
        </View>
      ) : null}
      <ShadowText style={[styles.status, { color: done ? candyColors.goldText : '#ffffff' }]} shadows={outline3(statusRing)}>
        {done ? '★ UNLOCKED' : 'LOCKED'}
      </ShadowText>
    </Animated.View>
  );
}

export default function AchievementsScreen({ creatures = [], profile = null, customCount = 0, onBack }) {
  const insets = useSafeAreaInsets();
  const entries = useMemo(() => computeAchievements(creatures, profile || {}, customCount), [creatures, profile, customCount]);
  const doneCount = entries.filter((e) => e.done).length;

  // opens on the first achievement still to do, like the design
  const [index, setIndex] = useState(() => Math.max(0, entries.findIndex((e) => !e.done)));
  const [span, setSpan] = useState(() => [index, index]); // indexes the mounted window spans
  const move = useRef(new Animated.Value(index)).current;
  const fade = useRef(new Animated.Value(index)).current;
  const indexRef = useRef(index);
  const swipedAt = useRef(0);

  const go = useCallback(
    (i) => {
      const next = Math.max(0, Math.min(entries.length - 1, i));
      const from = indexRef.current;
      if (next === from) return;
      sfx.play('swoosh');
      indexRef.current = next;
      setIndex(next);
      setSpan([Math.min(from, next), Math.max(from, next)]);
      Animated.timing(fade, { toValue: next, ...FADE, useNativeDriver: true }).start();
      Animated.timing(move, { toValue: next, ...MOVE, useNativeDriver: true }).start(({ finished }) => {
        if (finished) setSpan([next, next]);
      });
    },
    [entries.length, fade, move]
  );
  const goRef = useRef(go);
  goRef.current = go;

  // a tap on a side badge jumps to it — unless it was the end of a swipe
  const select = useCallback((i) => {
    if (Date.now() - swipedAt.current < 250) return;
    goRef.current(i);
  }, []);

  const pan = useMemo(
    () =>
      PanResponder.create({
        onMoveShouldSetPanResponderCapture: (_e, g) => Math.abs(g.dx) > 10 && Math.abs(g.dx) > Math.abs(g.dy),
        onPanResponderRelease: (_e, g) => {
          if (Math.abs(g.dx) > 36) {
            swipedAt.current = Date.now();
            goRef.current(indexRef.current + (g.dx < 0 ? 1 : -1));
          }
        },
      }),
    []
  );

  const current = entries[index] || entries[0];
  const lo = Math.max(0, span[0] - WINDOW);
  const hi = Math.min(entries.length - 1, span[1] + WINDOW);
  const badges = [];
  for (let i = lo; i <= hi; i++) {
    badges.push(<Badge key={entries[i].key} entry={entries[i]} index={i} move={move} fade={fade} z={50 - Math.abs(i - index)} onSelect={select} />);
  }

  return (
    <CandyBackground style={{ paddingTop: insets.top }}>
      <View style={styles.header}>
        <RoundButton size={36} onPress={onBack}>
          <BackGlyph />
        </RoundButton>
        <OutlinedTitle text="ACHIEVEMENTS" fill="pink" size={20} outline={3} ring={2} drop={5} />
        <Text style={styles.count}>
          {doneCount}/{entries.length}
        </Text>
      </View>
      <View style={styles.totalBar}>
        <CandyProgress pct={(doneCount / Math.max(1, entries.length)) * 100} height={12} />
      </View>

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
        <View style={styles.center}>{badges}</View>
        <RoundButton size={38} onPress={() => go(index - 1)} style={[styles.arrow, { left: 10, opacity: index === 0 ? 0.4 : 1 }]}>
          <Triangle dir="left" size={8} />
        </RoundButton>
        <RoundButton size={38} onPress={() => go(index + 1)} style={[styles.arrow, { right: 10, opacity: index === entries.length - 1 ? 0.4 : 1 }]}>
          <Triangle dir="right" size={8} />
        </RoundButton>
      </View>

      {current ? (
        <View style={{ paddingBottom: 26 + insets.bottom }}>
          <Details key={current.key} entry={current} index={index} total={entries.length} />
        </View>
      ) : null}
    </CandyBackground>
  );
}

const SLOT = BADGE + RING * 2;

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
    textShadowRadius: 0.1,
  },
  totalBar: { paddingHorizontal: 20, paddingTop: 2 },
  stage: { flex: 1, minHeight: 220, overflow: 'hidden' },
  center: { position: 'absolute', left: 0, right: 0, top: '46%', height: 0, alignItems: 'center', justifyContent: 'center' },
  halo: { position: 'absolute' },
  shadowSpot: { position: 'absolute', left: 0, right: 0, top: '78%', alignItems: 'center' },
  arrow: { position: 'absolute', top: '46%', marginTop: -21, zIndex: 60 },

  slot: { position: 'absolute', width: SLOT, height: SLOT + LIP },
  glow: { position: 'absolute', left: SLOT / 2, top: SLOT / 2 },
  lip: { position: 'absolute', top: LIP, left: 0, width: SLOT, height: SLOT, borderRadius: SLOT / 2 },
  ring: { position: 'absolute', top: 0, left: 0, width: SLOT, height: SLOT, borderRadius: SLOT / 2, padding: RING },
  rim: { flex: 1, borderRadius: BADGE / 2, borderWidth: 5, borderColor: '#ffffff', overflow: 'hidden' },
  content: { ...StyleSheet.absoluteFillObject, alignItems: 'center', justifyContent: 'center' },
  dim: { ...StyleSheet.absoluteFillObject, backgroundColor: '#000000' },
  badgeLabel: {
    color: '#ffffff',
    fontFamily: candyFonts.display,
    includeFontPadding: false,
  },
  corner: { position: 'absolute', right: 2 + RING, top: 2 + RING, width: 34, height: 34, borderRadius: 17, padding: 2 },
  cornerCheckRing: { backgroundColor: '#0c5a9c', right: RING, top: RING },
  cornerLockRing: { backgroundColor: '#45189a', right: RING, top: RING },
  cornerFace: { flex: 1, borderRadius: 15, borderWidth: 3, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center', overflow: 'hidden' },
  cornerLockFace: { backgroundColor: '#8f3cf2' },
  cornerCheckText: { color: '#ffffff', fontFamily: candyFonts.bodyBlack, fontSize: 15, textShadowColor: '#0c5a9c', textShadowOffset: { width: 0, height: 1 }, textShadowRadius: 0.1 },
  miniShackle: { width: 8, height: 7, borderWidth: 2, borderBottomWidth: 0, borderColor: '#ffffff', borderTopLeftRadius: 5, borderTopRightRadius: 5 },
  miniBody: { width: 12, height: 8, borderRadius: 2, backgroundColor: '#ffffff' },

  details: { alignItems: 'center', paddingHorizontal: 28, gap: 7 },
  pos: {
    color: '#ffffff',
    fontFamily: candyFonts.displaySemi,
    fontSize: 12,
    letterSpacing: 1.4,
    includeFontPadding: false,
  },
  // the sticker title's SVG carries its outline margin (4.5px round + 4px
  // drop) — pulled in so the spacing matches the design's 7px gaps
  title: { marginTop: -4.5, marginBottom: -8.5 },
  desc: {
    color: '#ffffff',
    fontFamily: candyFonts.displayMedium,
    fontSize: 15,
    lineHeight: 20,
    textAlign: 'center',
    maxWidth: 280,
    includeFontPadding: false,
  },
  progWrap: { width: 200, alignItems: 'center', gap: 4, marginTop: 2 },
  progBar: { width: '100%' },
  progText: {
    color: '#ffffff',
    fontFamily: candyFonts.displaySemi,
    fontSize: 12,
    includeFontPadding: false,
  },
  status: { fontFamily: candyFonts.display, fontSize: 13, letterSpacing: 1, includeFontPadding: false },
});
