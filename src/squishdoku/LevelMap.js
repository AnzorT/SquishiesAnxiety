import React, { memo, useEffect, useMemo, useRef, useState } from 'react';
import { Animated, Easing, Pressable, ScrollView, StyleSheet, Text, View, useWindowDimensions } from 'react-native';
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
import RoundButton from '../components/candy/RoundButton';
import { F, INK, TIER_COLORS } from './theme';

// The levels on a winding path, a chapter (20 levels, one Crib room) a page:
// the room's picture and name on top, ◀ ▶ to the chapters either side, and
// NEXT CHAPTER at the bottom (600 levels in one page was 60,000 points tall).
// Done levels are gold
// with the creatures they earned, the next one pink and pulsing with a
// creature bobbing on it, the rest locked. Nodes pop in around the current
// one; a level just unlocked breaks its lock open. The nodes are built
// nearest the current one first, a few a frame (useProgressive), so the map
// is up at once and fills outwards.

const GAP = 96;
const NODE = 62;
const TOP = 140;
const HEAD = 96; // the chapter's picture and banner, over the first node

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
  const colors = state === 'done' ? ['#fff7b0', '#ffd23a', '#ff9c0a'] : state === 'current' ? ['#ffd6f4', '#ff5cc6', '#c02bd9'] : ['#ece6f3', '#cfc3dd', '#b3a5c4'];
  const ring = state === 'done' ? '#9c4d06' : state === 'current' ? '#8e1580' : '#7a6a8c';
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

function LevelMap({ rec, roster, onPlay, justUnlocked }) {
  const { width } = useWindowDimensions();
  const scroll = useRef(null);
  const cur = Math.min(rec.lv, LEVELS); // the next level to beat
  const [chapter, setChapter] = useState(() => chapterOf(justUnlocked || cur));
  const from = (chapter - 1) * CHAPTER; // its first level's index
  const count = Math.min(CHAPTER, LEVELS - from);
  const points = useMemo(() => {
    const amp = Math.min(110, width * 0.27);
    return Array.from({ length: count }, (_, i) => ({ x: width / 2 + Math.sin((from + i) * 1.05) * amp, y: TOP + HEAD + i * GAP }));
  }, [width, from, count]);
  const height = points[count - 1].y + 170;
  // a creature for each node's score heads (fixed per level) and the mascot
  const heads = useMemo(() => Array.from({ length: count }, (_, i) => [0, 1, 2].map((k) => roster.length && roster[((from + i + 1) * 7 + k * 13) % roster.length])), [roster, from, count]);
  const mascot = roster.length ? roster[(cur * 11) % roster.length] : null;

  const order = useMemo(() => Array.from({ length: count }, (_, i) => i).sort((a, b) => Math.abs(from + a + 1 - cur) - Math.abs(from + b + 1 - cur)), [cur, from, count]);
  const n = useProgressive(count, 12, 10);
  const built = useMemo(() => new Set(order.slice(0, n)), [order, n]);

  // the current level in view (the top of the page on another chapter)
  useEffect(() => {
    const i = cur - 1 - from;
    const y = i >= 0 && i < count ? Math.max(0, points[i].y - 260) : 0;
    const t = setTimeout(() => scroll.current?.scrollTo({ y, animated: false }), 0);
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
  const room = roomOfChapter(chapter);
  const sizes = [...new Set(LEVEL_LIST.slice(from, from + count).map((x) => x.n))].sort((a, b) => a - b);

  return (
    <ScrollView ref={scroll} style={styles.fill} contentContainerStyle={{ height }} showsVerticalScrollIndicator={false}>
      {/* the chapter: its room, its name, the chapters either side */}
      <View style={[styles.chapter, { top: TOP - 120 }]}>
        <RoomCard room={room} />
        <View style={styles.chapterRow}>
          <RoundButton size={36} onPress={() => turn(chapter - 1)} disabled={chapter <= 1} dim={chapter <= 1}>
            <Text style={styles.arrow}>◀</Text>
          </RoundButton>
          <View style={styles.chapterBox}>
            <Text style={styles.bannerText}>{`CHAPTER ${chapter} · ${ROOMS[room].name.toUpperCase()}`}</Text>
            <Text style={styles.chapterSub}>{`LEVELS ${from + 1}-${from + count} · ${sizes.map((s) => `${s}×${s}`).join(' ')}`}</Text>
          </View>
          <RoundButton size={36} onPress={() => turn(chapter + 1)} disabled={chapter >= CHAPTERS} dim={chapter >= CHAPTERS}>
            <Text style={styles.arrow}>▶</Text>
          </RoundButton>
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
        <View style={[styles.nextWrap, { top: points[count - 1].y + 70 }]}>
          <Pressable onPress={() => turn(chapter + 1)} hitSlop={8} style={styles.nextBtn}>
            <Text style={styles.nextText}>{`CHAPTER ${chapter + 1} ▶`}</Text>
          </Pressable>
        </View>
      ) : null}
    </ScrollView>
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
  chapter: { position: 'absolute', left: 0, right: 0, alignItems: 'center', gap: 8 },
  chapterRow: { flexDirection: 'row', alignItems: 'center', gap: 10, paddingHorizontal: 14 },
  chapterBox: { alignItems: 'center', gap: 3 },
  chapterSub: { fontFamily: F.display, fontSize: 11, letterSpacing: 1, color: INK },
  arrow: { fontFamily: F.display, fontSize: 14, color: '#ffffff', includeFontPadding: false },
  nextWrap: { position: 'absolute', left: 0, right: 0, alignItems: 'center' },
  nextBtn: { backgroundColor: '#7a2fd6', borderRadius: 999, borderWidth: 3, borderColor: '#ffffff', paddingHorizontal: 22, paddingVertical: 9 },
  nextText: { fontFamily: F.display, fontSize: 15, letterSpacing: 1.5, color: '#ffffff' },
  bannerText: { fontFamily: F.display, fontSize: 15, letterSpacing: 2, color: '#ffffff', backgroundColor: '#7a2fd6', borderRadius: 999, borderWidth: 2.5, borderColor: '#ffffff', paddingHorizontal: 14, paddingVertical: 3, overflow: 'hidden' },
});

export default memo(LevelMap);
