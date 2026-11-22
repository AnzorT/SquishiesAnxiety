import React, { memo, useEffect, useLayoutEffect, useMemo, useRef, useState } from 'react';
import { useGameDims } from '../royal/GameFrame';
import { Animated, Pressable, StyleSheet, Text, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import sfx from '../audio/sfx';
import { Bob } from '../squad/ui';
import { useProgressive } from '../components/Skeleton';
import { usePingPong } from '../components/idleLoop';
import { FxLayer } from './fx';
import { Head } from './ui';
import { CHAPTER, CHAPTERS, LEVEL_LIST, LEVELS, chapterOf, roomOfChapter } from './levels';
import { RoomCard } from '../hop/Room';
import { ROOMS } from '../hop/levels';
import { Orb } from '../royal';
import { F, INK, TIER_COLORS } from './theme';

// The levels on a winding path, a chapter (20 levels, one Crib room) a page:
// the room's name and ◀ ▶ to the chapters either side at the start, and
// NEXT CHAPTER at the end (600 levels in one page was far too long).
// Done levels are gold
// with the creatures they earned, the next one pink and pulsing with a
// creature bobbing on it, the rest locked. Nodes pop in around the current
// one; a level just unlocked breaks its lock open. The nodes are built
// nearest the current one first, a few a frame (useProgressive), so the map
// is up at once and fills outwards.

const NODE = 62;

const Node = memo(function Node({ lv, x, y, state, stars, perfect, heads, delay, onPress, unlocking, mascot, mascotLeft }) {
  const t = useRef(new Animated.Value(0)).current;
  const shake = useRef(new Animated.Value(0)).current;
  // the next level's pulse: one native loop (src/components/idleLoop.js)
  const pulse = usePingPong(1400, { on: state === 'current' });
  const lock = useRef(new Animated.Value(unlocking ? 0 : 1)).current;
  const fx = useRef(null);
  useEffect(() => {
    Animated.spring(t, { toValue: 1, friction: 5, tension: 150, delay, useNativeDriver: true }).start();
  }, [t, delay]);
  // a lock rattling, then bursting off
  useEffect(() => {
    if (!unlocking) return undefined;
    const timer = setTimeout(() => {
      Animated.sequence([
        ...[1, -1, 1, -1, 0.5, 0].map((k) => Animated.timing(shake, { toValue: k, duration: 55, useNativeDriver: true })),
        Animated.timing(lock, { toValue: 0, duration: 1, useNativeDriver: true }),
      ]).start();
      setTimeout(() => {
        sfx.play('sd_unlock');
        fx.current?.burst('gold', NODE / 2, NODE / 2, 1);
      }, 330);
    }, delay + 500);
    return () => clearTimeout(timer);
  }, [unlocking, delay, shake, lock]);

  const press = () => {
    if (state === 'locked') {
      sfx.play('sd_locked');
      shake.setValue(0);
      Animated.sequence([1, -1, 0.7, -0.7, 0.3, 0].map((k) => Animated.timing(shake, { toValue: k, duration: 45, useNativeDriver: true }))).start();
      return;
    }
    sfx.play('sd_select');
    onPress(lv);
  };
  const colors = state === 'done' ? ['#fff7b0', '#ffd23a', '#ff9c0a'] : state === 'current' ? ['#ffe2c8', '#ff9a4a', '#e0601c'] : ['#f1ebe4', '#dacdbf', '#c2b2a1'];
  const ring = state === 'done' ? '#9c4d06' : state === 'current' ? '#8a3a0e' : '#7a6a8c';
  const tier = LEVEL_LIST[lv - 1].tier;
  return (
    <Animated.View
      style={[
        styles.node,
        {
          left: x - NODE / 2,
          top: y - NODE / 2,
          opacity: t,
          transform: [
            { scale: Animated.multiply(t, pulse.interpolate({ inputRange: [0, 1], outputRange: [1, 1.08] })) },
            { translateX: shake.interpolate({ inputRange: [-1, 1], outputRange: [-6, 6] }) },
            { rotate: shake.interpolate({ inputRange: [-1, 1], outputRange: ['-8deg', '8deg'] }) },
          ],
        },
      ]}
    >
      {state === 'current' && mascot ? (
        // beside the node, on the side towards the middle (above it, it hid the
        // last level's creatures)
        <Bob style={[styles.mascot, mascotLeft ? { right: NODE + 6 } : { left: NODE + 6 }]} dy={6} ms={1400}>
          <Head uri={mascot} size={40} ring="#ffffff" />
        </Bob>
      ) : null}
      <Pressable onPress={press} hitSlop={8}>
        <View style={[styles.nodeLip, { backgroundColor: ring }]} />
        <View style={[styles.nodeRing, { backgroundColor: ring }]}>
          <LinearGradient colors={colors} locations={[0, 0.5, 1]} style={styles.nodeFace}>
            <View style={styles.nodeShine} />
            <Text style={[styles.nodeNum, state === 'locked' && { color: '#8f80a3' }]}>{lv}</Text>
            <View style={[styles.tierDot, { backgroundColor: TIER_COLORS[tier] }]} />
          </LinearGradient>
        </View>
        {state === 'locked' || unlocking ? (
          <Animated.View style={[styles.lock, { opacity: lock, transform: [{ scale: lock.interpolate({ inputRange: [0, 1], outputRange: [1.8, 1] }) }] }]}>
            <View style={styles.lockShackle} />
            <View style={styles.lockBody} />
          </Animated.View>
        ) : null}
        {perfect ? (
          <View style={styles.perfect}>
            <Text style={styles.perfectText}>P</Text>
          </View>
        ) : null}
      </Pressable>
      {state === 'done' ? (
        <View style={styles.heads}>
          {[0, 1, 2].map((i) => (
            <Head key={i} uri={heads[i]} size={i === 1 ? 22 : 19} dim={i >= stars} ring={i < stars ? '#ffd23a' : '#ffffff'} style={{ marginTop: i === 1 ? 0 : 3 }} />
          ))}
        </View>
      ) : null}
      <FxLayer ref={fx} />
    </Animated.View>
  );
});

// (REDESIGN_V8, the user: the level maps sideways): the chapter's room, name and arrows at the start, then its levels
// winding left to right, the page scrolling sideways
const HEAD_W = 214;
const FIRST_X = HEAD_W + 78; // the first level, clear of the chapter's column
const GAP_X = 96;

// rowAt: where the row's middle line runs, as a fraction of the map's height (lower over a room's floor);
// the chapter's room behind the map (src/royal/WorldBg.js RoomBackdrop, useRoomStrip): onSpans([{ room, x0,
// x1 }]) gets the room and how far it runs along the page (all of it); scrollX (an Animated.Value) follows the page's
// scroll on the UI thread, so the room scrolls with the levels (2026-11-17, the user: the background stood still while
// the list scrolled)
function LevelMap({ rec, roster, onPlay, justUnlocked, onSpans, scrollX, rowAt = 0.5 }) {
  const { width, height: winH } = useGameDims();
  const [boxH, setBoxH] = useState(0);
  const H = boxH || winH - 60; // the map's own height (under the screen's top bar)
  const scroll = useRef(null);
  const cur = Math.min(rec.lv, LEVELS); // the next level to beat
  const [chapter, setChapter] = useState(() => chapterOf(justUnlocked || cur));
  const from = (chapter - 1) * CHAPTER; // its first level's index
  const count = Math.min(CHAPTER, LEVELS - from);
  // a gentle wave about the middle line, level with the chapter's card (2026-11-16, the user: the list in the middle;
  // it swung from near the top bar to near the bottom)
  const points = useMemo(() => {
    const amp = Math.min(rowAt > 0.6 ? 14 : 24, H * 0.075);
    return Array.from({ length: count }, (_, i) => ({ x: FIRST_X + i * GAP_X, y: H * rowAt - 10 + Math.sin((from + i) * 1.05) * amp }));
  }, [from, count, H, rowAt]);
  const contentW = points[count - 1].x + 190;
  const room = roomOfChapter(chapter);
  // the chapter's room, the length of the page
  const spans = useMemo(() => (onSpans ? [{ room, x0: 0, x1: Math.max(contentW, width) }] : null), [onSpans, room, contentW, width]);
  // (before the first frame: the room drawn where the page opens, as the effect below scrolls it)
  useLayoutEffect(() => {
    const i = cur - 1 - from;
    if (scrollX) scrollX.setValue(i >= 0 && i < count ? Math.max(0, Math.min(points[i].x - width / 2, contentW - width)) : 0);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [chapter]);
  useLayoutEffect(() => {
    if (onSpans) onSpans(spans);
  }, [spans, onSpans]);
  const onScroll = useMemo(() => (scrollX ? Animated.event([{ nativeEvent: { contentOffset: { x: scrollX } } }], { useNativeDriver: true }) : undefined), [scrollX]);
  // a creature for each node's score heads (fixed per level) and the mascot
  const heads = useMemo(() => Array.from({ length: count }, (_, i) => [0, 1, 2].map((k) => roster.length && roster[((from + i + 1) * 7 + k * 13) % roster.length])), [roster, from, count]);
  const mascot = roster.length ? roster[(cur * 11) % roster.length] : null;

  const order = useMemo(() => Array.from({ length: count }, (_, i) => i).sort((a, b) => Math.abs(from + a + 1 - cur) - Math.abs(from + b + 1 - cur)), [cur, from, count]);
  const n = useProgressive(count, 12, 10);
  const built = useMemo(() => new Set(order.slice(0, n)), [order, n]);

  // the current level in view (the start of the page on another chapter)
  useEffect(() => {
    const i = cur - 1 - from;
    const at = i >= 0 && i < count;
    const t = setTimeout(() => {
      scroll.current?.scrollTo({ x: at ? Math.max(0, points[i].x - width / 2) : 0, animated: false });
    }, 0);
    // the nodes round the current one pop in with rising bubbles
    const pops = [];
    for (let k = 0; k < 6; k++) pops.push(setTimeout(() => sfx.play('sd_nodePop', { rate: 0.9 + k * 0.07 }), 120 + k * 70));
    return () => {
      clearTimeout(t);
      pops.forEach(clearTimeout);
    };
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [chapter]);
  const turn = (c) => {
    if (c < 1 || c > CHAPTERS) return;
    sfx.play('sd_select');
    setChapter(c);
  };

  const dots = [];
  for (let i = 0; i < count - 1; i++) {
    if (!built.has(i) || !built.has(i + 1)) continue;
    const a = points[i];
    const b = points[i + 1];
    for (let k = 1; k <= 3; k++) {
      const f = k / 4;
      dots.push(<View key={`d${i}-${k}`} style={[styles.dot, { left: a.x + (b.x - a.x) * f - 4, top: a.y + (b.y - a.y) * f - 4, backgroundColor: from + i + 1 < cur ? '#ffd23a' : 'rgba(255,255,255,0.75)' }]} />);
    }
  }
  const sizes = [...new Set(LEVEL_LIST.slice(from, from + count).map((x) => x.n))].sort((a, b) => a - b);

  return (
    <Animated.ScrollView
      ref={scroll}
      horizontal
      style={styles.fill}
      contentContainerStyle={{ width: contentW, height: H }}
      showsVerticalScrollIndicator={false}
      showsHorizontalScrollIndicator={false}
      onLayout={(e) => setBoxH(Math.round(e.nativeEvent.layout.height))}
      onScroll={onScroll}
      // (every frame: the room behind follows the scroll)
      scrollEventThrottle={16}
    >
      {/* the chapter: its room, its name, the chapters either side (the screen drawing the chapter's room behind the
          map, `onSpans`: no picture of it here, the name and the arrows level with the row) */}
      <View style={[styles.chapter, { top: onSpans ? H * rowAt - 56 : H * rowAt - 112 }]}>
        {onSpans ? null : <RoomCard room={room} width={190} height={104} />}
        <Text style={styles.bannerText} numberOfLines={1}>{`CHAPTER ${chapter} · ${ROOMS[room].name.toUpperCase()}`}</Text>
        <Text style={[styles.chapterSub, onSpans && styles.chapterSubOn]}>{`LEVELS ${from + 1}-${from + count} · ${sizes.map((s) => `${s}×${s}`).join(' ')}`}</Text>
        <View style={styles.chapterArrows}>
          <Orb icon="left" size={36} onPress={() => turn(chapter - 1)} disabled={chapter <= 1} style={chapter <= 1 && styles.dimmed} />
          <Orb icon="right" size={36} onPress={() => turn(chapter + 1)} disabled={chapter >= CHAPTERS} style={chapter >= CHAPTERS && styles.dimmed} />
        </View>
      </View>
      {dots}
      {points.map((p, i) => {
        if (!built.has(i)) return null;
        const lv = from + i + 1;
        // every level before the unlocked one was beaten to get there
        const state = lv < cur ? 'done' : lv === cur ? (rec.best[lv] ? 'done' : 'current') : 'locked';
        return (
          <Node
            key={lv}
            lv={lv}
            x={p.x}
            y={p.y}
            state={state}
            stars={rec.best[lv] || 0}
            perfect={!!rec.perfect[lv]}
            heads={heads[i]}
            delay={Math.min(700, Math.abs(lv - cur) * 45)}
            onPress={onPlay}
            unlocking={justUnlocked === lv}
            mascot={lv === cur ? mascot : null}
            mascotLeft={p.x > width / 2}
          />
        );
      })}
      {chapter < CHAPTERS ? (
        <View style={[styles.nextWrap, { left: points[count - 1].x + 54, top: H * rowAt - 24 }]}>
          <Pressable onPress={() => turn(chapter + 1)} hitSlop={8} style={styles.nextBtn}>
            <Text style={styles.nextText}>{`CHAPTER ${chapter + 1} ▶`}</Text>
          </Pressable>
        </View>
      ) : null}
    </Animated.ScrollView>
  );
}

const styles = StyleSheet.create({
  fill: { flex: 1 },
  node: { position: 'absolute', width: NODE, alignItems: 'center' },
  nodeLip: { position: 'absolute', top: 5, left: 0, width: NODE, height: NODE, borderRadius: NODE / 2 },
  nodeRing: { width: NODE, height: NODE, borderRadius: NODE / 2, padding: 2.5 },
  nodeFace: { flex: 1, borderRadius: NODE / 2, borderWidth: 3, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center', overflow: 'hidden' },
  nodeShine: { position: 'absolute', top: 3, left: 8, right: 8, height: '38%', borderRadius: 99, backgroundColor: 'rgba(255,255,255,0.5)' },
  nodeNum: { fontFamily: F.display, fontSize: 22, color: '#ffffff', textShadowColor: INK, textShadowOffset: { width: 0, height: 2 }, textShadowRadius: 1, includeFontPadding: false },
  tierDot: { position: 'absolute', bottom: 5, width: 8, height: 8, borderRadius: 4, borderWidth: 1.5, borderColor: '#ffffff' },
  lock: { position: 'absolute', right: -6, top: -6, width: 26, height: 28, alignItems: 'center' },
  lockShackle: { width: 14, height: 14, borderRadius: 7, borderWidth: 3.5, borderColor: '#7a6a8c', borderBottomWidth: 0 },
  lockBody: { width: 22, height: 15, borderRadius: 5, backgroundColor: '#7a6a8c', borderWidth: 2, borderColor: '#ffffff', marginTop: -3 },
  perfect: { position: 'absolute', left: -6, top: -6, width: 22, height: 22, borderRadius: 11, backgroundColor: '#e01e4a', borderWidth: 2, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  perfectText: { fontFamily: F.display, fontSize: 11, color: '#ffffff', includeFontPadding: false },
  heads: { flexDirection: 'row', marginTop: 4, gap: 1 },
  mascot: { position: 'absolute', top: 8, zIndex: 3 },
  dot: { position: 'absolute', width: 8, height: 8, borderRadius: 4 },
  chapter: { position: 'absolute', left: 14, width: HEAD_W, alignItems: 'center', gap: 6 },
  chapterArrows: { flexDirection: 'row', gap: 18, marginTop: 4 },
  dimmed: { opacity: 0.4 },
  nextWrap: { position: 'absolute' },
  chapterSub: { fontFamily: F.display, fontSize: 11, letterSpacing: 1, color: INK },
  chapterSubOn: { backgroundColor: 'rgba(255,247,234,0.92)', borderRadius: 10, paddingHorizontal: 8, paddingVertical: 1, overflow: 'hidden' },
  nextBtn: { backgroundColor: '#b8641c', borderRadius: 999, borderWidth: 3, borderColor: '#ffffff', paddingHorizontal: 22, paddingVertical: 9 },
  nextText: { fontFamily: F.display, fontSize: 15, letterSpacing: 1.5, color: '#ffffff' },
  bannerText: { fontFamily: F.display, fontSize: 11.5, letterSpacing: 1, color: '#ffffff', backgroundColor: '#b8641c', borderRadius: 999, borderWidth: 2.5, borderColor: '#ffffff', paddingHorizontal: 10, paddingVertical: 3, overflow: 'hidden', maxWidth: HEAD_W },
});

export default memo(LevelMap);
