import React, { memo, useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { View, Text, StyleSheet, Animated, Easing, PanResponder } from 'react-native';
import Pressable from '../components/Pressable';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Defs, RadialGradient, Stop, Circle } from 'react-native-svg';
import { candyFonts } from '../theme/candyTheme';
import { computeAchievements } from '../achievements';
import { Shine } from '../components/candy/CandyButton';
import { RaysSpin } from '../components/candy/Decor';
import ShadowText from '../components/candy/ShadowText';
import CreatureThumbnail from '../components/CreatureThumbnail';
import { useProgressive } from '../components/Skeleton';
import { useScreenReady } from '../components/ScreenLayer';
import { usePingPong } from '../components/idleLoop';
import sfx from '../audio/sfx';
import { fmtNum } from '../format';
import { Lettering, Orb, Stage, WoodBg, FONT as RFONT } from '../royal';

// Achievements, as the v3 design's carousel (REDESIGN_V8: across the whole
// width, on wood): one big badge at a time under spinning rays and a pulsing
// halo, neighbours fanned out smaller to either side, and the current badge's
// title / description / progress in a bar under them. Swipe sideways, use the
// arrows, or tap a side badge. Opens on the first achievement not yet done.
// See src/achievements.js for the list itself.

const BADGE = 124; // the badge (white rim included); its ring sits outside
const RING = 3;
const LIP = 7;
// badges mounted either side of the current one: the two on screen, plus
// one so a swipe has its next badge ready (5 made the screen ~40% slower to
// build)
const WINDOW = 3;

// Where a badge `d` steps from the centre sits (REDESIGN_V8, the user: the carousel spans the screen's width, so its
// badges spread wider than the design's)
const xOf = (d) => (d === 0 ? 0 : Math.sign(d) * (150 + (Math.abs(d) - 1) * 118));
const yOf = (d) => (d === 0 ? -6 : 16 + (Math.abs(d) - 1) * 6);
const scaleOf = (d) => (d === 0 ? 1 : Math.max(0.5, 0.76 - (Math.abs(d) - 1) * 0.1));
const opacityOf = (d) => (Math.abs(d) > 3 ? 0 : d === 0 ? 1 : 0.9 - (Math.abs(d) - 1) * 0.18);

// transform: 0.5s cubic-bezier(0.3,1.3,0.5,1) (a little overshoot);
// opacity: 0.35s ease — as the design's two transitions.
const MOVE = { duration: 500, easing: Easing.bezier(0.3, 1.3, 0.5, 1) };
const FADE = { duration: 350, easing: Easing.bezier(0.25, 0.1, 0.25, 1) };

// react-native-svg ignores <Stop>s wrapped in a fragment, so the fills are
// arrays: [offset, color, opacity].
const DONE_STOPS = [[0, '#fffbe0', 1], [0.3, '#ffe45c', 1], [0.62, '#ffc21a', 1], [1, '#e08a00', 1]];
// (REDESIGN_V8: warm, no purple)
const LOCKED_STOPS = [[0, '#ffffff', 0.6], [0.45, '#ffdcae', 0.5], [1, '#b8763a', 0.6]];

// the curves' key points: d = -5 … 5 (they don't depend on WINDOW)
const OFFSETS = Array.from({ length: 11 }, (_, k) => k - 5);

function curve(pos, index, fn) {
  // pos → value for a badge at `index`: it sits at d = index - pos
  const pairs = OFFSETS.map((d) => [index - d, fn(d)]).sort((a, b) => a[0] - b[0]);
  return pos.interpolate({ inputRange: pairs.map((p) => p[0]), outputRange: pairs.map((p) => p[1]), extrapolate: 'clamp' });
}

// `live`: the centre badge. Only its creature cycles its moods (a timer
// re-rendering it every 3 s); with every mounted badge cycling on its own
// clock, the screen re-rendered a creature about every 270 ms and taps
// (the back button too) waited behind those renders.
const Badge = memo(function Badge({ entry, index, move, fade, z, live, onSelect }) {
  const done = entry.done;
  const ring = done ? '#a0520a' : '#6b4426';
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
        {/* the gold glow only shows on the centre badge: built for it and its
            neighbours (for the swipe's crossfade), not for every badge
            (each was a large SVG to create and draw) */}
        {z >= 49 ? (
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
        ) : null}
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
                <CreatureThumbnail creature={entry.creature} mood={live ? 'cycle' : 'idle'} size={84} locked={!done} />
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

// Soft white→gold→pink glow behind the centre badge (haloPulse): 1 s out,
// 1 s back, one native loop (idleLoop.js) driving its size and its light.
function Halo() {
  const t = usePingPong(2000);
  const scale = useMemo(() => t.interpolate({ inputRange: [0, 1], outputRange: [0.9, 1.12] }), [t]);
  const opacity = useMemo(() => t.interpolate({ inputRange: [0, 1], outputRange: [0.55, 0.95] }), [t]);
  return (
    <Animated.View pointerEvents="none" style={[styles.halo, { opacity, transform: [{ scale }] }]}>
      <Svg width={230} height={230}>
        <Defs>
          <RadialGradient id="halo" cx="50%" cy="50%" r="50%">
            <Stop offset="0" stopColor="#ffffff" stopOpacity={0.9} />
            <Stop offset="0.3" stopColor="#ffe6a0" stopOpacity={0.55} />
            <Stop offset="0.5" stopColor="#ffa64a" stopOpacity={0.3} />
            <Stop offset="0.7" stopColor="#ffffff" stopOpacity={0} />
          </RadialGradient>
        </Defs>
        <Circle cx={115} cy={115} r={115} fill="url(#halo)" />
      </Svg>
    </Animated.View>
  );
}

// The current badge's details in one wide bar under the carousel (REDESIGN_V8, the user: "the texts below"). REDESIGN_V9 (the user): the title in the middle, how to unlock it below; no LOCKED / UNLOCKED. Its
// progress, when it counts something, sits under the text. Its "N OF M" is not in here: it stays still at the
// bottom centre while these fade in (the user, 2026-11-16).
function Details({ entry, index }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    t.setValue(0);
    Animated.timing(t, { toValue: 1, duration: 320, easing: Easing.out(Easing.quad), useNativeDriver: true }).start();
  }, [t, index]);
  const opacity = t;
  const translateY = t.interpolate({ inputRange: [0, 1], outputRange: [10, 0] });
  const done = entry.done;
  const prog = entry.progress;
  return (
    <Animated.View style={[styles.wDet, { opacity, transform: [{ translateY }] }]}>
      <Lettering text={entry.title} variant={done ? 'gold' : 'white'} size={22} />
      <Text style={styles.wDesc} numberOfLines={1}>
        {entry.desc}
      </Text>
      {prog && !done ? (
        <View style={styles.wProg}>
          <View style={[styles.wBar, styles.wBarSmall]}>
            <LinearGradient colors={['#fff1b0', '#ffd24a', '#f0a21c']} start={{ x: 0, y: 0 }} end={{ x: 0, y: 1 }} style={[styles.wBarFill, { width: `${Math.max(3, Math.min(100, (prog.cur / prog.max) * 100))}%` }]} />
          </View>
          <Text style={styles.wProgT}>{`${fmtNum(prog.cur)} / ${fmtNum(prog.max)}`}</Text>
        </View>
      ) : null}
    </Animated.View>
  );
}

function AchievementsScreen({ creatures = [], profile = null, customCount = 0, onBack }) {
  const ready = useScreenReady();
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
  // the badge in view first, then one more each side a frame: all seven at
  // once (each with its SVG glow) were one 0.15 s frame as the screen's
  // content came in (Galaxy A15 release, 2026-10-28)
  const win = useProgressive(WINDOW + 1, 1, 1, ready) - 1;
  const lo = Math.max(0, span[0] - win);
  const hi = Math.min(entries.length - 1, span[1] + win);
  const badges = [];
  for (let i = lo; i <= hi; i++) {
    badges.push(<Badge key={entries[i].key} entry={entries[i]} index={i} move={move} fade={fade} z={50 - Math.abs(i - index)} live={i === index} onSelect={select} />);
  }

  // REDESIGN_V8 (the user's remodel): the carousel across the whole width in the middle, the details in one bar below
  // it; the wood look
  return (
    <View style={styles.wRoot}>
      <WoodBg />
      <Stage>
        <View style={styles.wHead}>
          <Orb icon="back" onPress={onBack} />
          <Lettering text="Achievements" variant="gold" size={30} />
          <View style={styles.wTotal}>
            <View style={styles.wBar}>
              <LinearGradient colors={['#fff1b0', '#ffd24a', '#f0a21c']} start={{ x: 0, y: 0 }} end={{ x: 0, y: 1 }} style={[styles.wBarFill, { width: `${Math.max(3, (doneCount / Math.max(1, entries.length)) * 100)}%` }]} />
            </View>
          </View>
          <Text style={styles.wCount}>{`${doneCount} / ${entries.length}`}</Text>
        </View>
        <View style={styles.wStage} {...pan.panHandlers}>
          <View style={styles.center} pointerEvents="none">
            <RaysSpin size={360} durationMs={12000} rayDeg={9} gapDeg={13} opacity={0.4} fadeStart={0.14} fadeEnd={0.62} />
            <Halo />
          </View>
          <View style={styles.center}>{ready ? badges : null}</View>
          <Orb icon="left" onPress={() => go(index - 1)} style={[styles.wArrow, { left: 16, opacity: index === 0 ? 0.4 : 1 }]} />
          <Orb icon="right" onPress={() => go(index + 1)} style={[styles.wArrow, { right: 16, opacity: index === entries.length - 1 ? 0.4 : 1 }]} />
        </View>
        {current ? (
          <View style={styles.wPanel}>
            <Details key={current.key} entry={current} index={index} />
          </View>
        ) : null}
        {current ? <Text style={styles.wPos}>{`${index + 1} OF ${entries.length}`}</Text> : null}
      </Stage>
    </View>
  );
}

const SLOT = BADGE + RING * 2;

const styles = StyleSheet.create({
  // in the design's 393-tall units (REDESIGN_V7)
  // (REDESIGN_V8: the carousel the page's full width in the middle, the details in a bar along the bottom)
  wRoot: { ...StyleSheet.absoluteFillObject, backgroundColor: '#d27c3e' },
  wHead: { position: 'absolute', left: 16, right: 16, top: 12, height: 46, flexDirection: 'row', alignItems: 'center', gap: 12 },
  wTotal: { flex: 1, marginLeft: 12, maxWidth: 300 },
  wBar: { height: 12, borderRadius: 6, backgroundColor: 'rgba(107,68,38,0.45)', borderWidth: 1.5, borderColor: '#6b4426', overflow: 'hidden' },
  wBarFill: { height: '100%', borderRadius: 5 },
  wCount: { fontFamily: RFONT.bodyBlack, fontSize: 15, color: '#fff6e2', textShadowColor: '#6b4426', textShadowOffset: { width: 0, height: 2 }, textShadowRadius: 0.1 },
  wStage: { position: 'absolute', left: 0, right: 0, top: 60, bottom: 100, overflow: 'hidden' },
  wArrow: { position: 'absolute', top: '50%', marginTop: -20, zIndex: 60 },
  // the details between the carousel (bottom 100) and the "N OF M" line under them
  wPanel: { position: 'absolute', left: 24, right: 24, bottom: 24, height: 76, paddingHorizontal: 18, alignItems: 'stretch', justifyContent: 'center' },
  wDet: { alignItems: 'center', justifyContent: 'center', gap: 1 },
  // no card behind the details (the user, 2026-11-16): the text sits straight on the wood, so every line gets
  // the brown drop the description has
  wPos: { position: 'absolute', left: 0, right: 0, bottom: 7, textAlign: 'center', fontFamily: RFONT.bodyBlack, fontSize: 12, letterSpacing: 1.2, color: '#fff6e2', textShadowColor: '#6b4426', textShadowOffset: { width: 0, height: 1.5 }, textShadowRadius: 0.1 },
  wDesc: { alignSelf: 'stretch', textAlign: 'center', fontFamily: RFONT.bodyHeavy, fontSize: 14, lineHeight: 19, color: '#ffffff', textShadowColor: '#6b4426', textShadowOffset: { width: 0, height: 1.5 }, textShadowRadius: 0.1 },
  wProg: { flexDirection: 'row', alignItems: 'center', gap: 8, marginTop: 3 },
  wBarSmall: { width: 170, height: 10 },
  wProgT: { fontFamily: RFONT.bodyBlack, fontSize: 11, color: '#fff6e2', textAlign: 'center', textShadowColor: '#6b4426', textShadowOffset: { width: 0, height: 1.5 }, textShadowRadius: 0.1 },
  fill: { flex: 1 },
  center: { position: 'absolute', left: 0, right: 0, top: '46%', height: 0, alignItems: 'center', justifyContent: 'center' },
  halo: { position: 'absolute' },

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
  cornerLockRing: { backgroundColor: '#6b4426', right: RING, top: RING },
  cornerFace: { flex: 1, borderRadius: 15, borderWidth: 3, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center', overflow: 'hidden' },
  cornerLockFace: { backgroundColor: '#c98d52' },
  cornerCheckText: { color: '#ffffff', fontFamily: candyFonts.bodyBlack, fontSize: 15, textShadowColor: '#0c5a9c', textShadowOffset: { width: 0, height: 1 }, textShadowRadius: 0.1 },
  miniShackle: { width: 8, height: 7, borderWidth: 2, borderBottomWidth: 0, borderColor: '#ffffff', borderTopLeftRadius: 5, borderTopRightRadius: 5 },
  miniBody: { width: 12, height: 8, borderRadius: 2, backgroundColor: '#ffffff' },
});

// memoized: App re-renders while this is open (Home going to sleep under it,
// a profile change), and those re-rendered the whole screen
export default memo(AchievementsScreen);
