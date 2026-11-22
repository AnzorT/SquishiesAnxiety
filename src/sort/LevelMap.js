import React, { memo, useEffect, useLayoutEffect, useMemo, useRef, useState } from 'react';
import { useGameDims } from '../royal/GameFrame';
import { Animated, Pressable, StyleSheet, Text, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Path } from 'react-native-svg';
import sfx from '../audio/sfx';
import { Bob } from '../squad/ui';
import { useProgressive } from '../components/Skeleton';
import { usePingPong } from '../components/idleLoop';
import { FxLayer } from '../squishdoku/fx';
import { Head } from '../squishdoku/ui';
import { F, INK } from '../squishdoku/theme';
import { LEVEL_LIST, TIER_COLORS } from './levels';

// A container's 50 levels in a row, level 1 at the left: beaten levels gold
// with their stars, the next one pink and pulsing with a squishy bobbing
// beside it, the rest locked. A sign opens each size band (5 SHELVES × 4 …),
// with a picture over its banner when `iconOf` draws one (Squish Sort's
// fridges); the dot on a node is its tier. Squish Hop's map is this one with
// its own `list` and `bannerOf`; Squish Stack's forest map (ForestMap.js)
// uses its Node. The nodes are built nearest the current one first, a few a
// frame (useProgressive), so the map is up at once and fills outwards.

export const NODE = 60;
const STAR_D = 'M12 2.2 L14.9 8.6 L21.8 9.3 L16.6 14 L18.1 20.9 L12 17.4 L5.9 20.9 L7.4 14 L2.2 9.3 L9.1 8.6 Z';

const shelves = (L) => `${L.rows} ${L.rows > 1 ? 'SHELVES' : 'SHELF'} · ${L.cols} SPOTS`;

const Stars = ({ n }) => (
  <View style={styles.stars}>
    {[0, 1, 2].map((i) => (
      <Svg key={i} width={i === 1 ? 20 : 16} height={i === 1 ? 20 : 16} viewBox="0 0 24 24" style={{ marginTop: i === 1 ? 0 : 4 }}>
        <Path d={STAR_D} fill={i < n ? '#ffd23a' : 'rgba(255,255,255,0.75)'} stroke={i < n ? '#b86200' : '#c9b9da'} strokeWidth={1.6} strokeLinejoin="round" />
      </Svg>
    ))}
  </View>
);

export const Node = memo(function Node({ lv, tier, x, y, state, stars, delay, onPress, mascot, mascotLeft }) {
  const t = useRef(new Animated.Value(0)).current;
  const shake = useRef(new Animated.Value(0)).current;
  // the next level's pulse: one native loop (src/components/idleLoop.js)
  const pulse = usePingPong(1400, { on: state === 'current' });
  const fx = useRef(null);
  useEffect(() => {
    Animated.spring(t, { toValue: 1, friction: 5, tension: 150, delay, useNativeDriver: true }).start();
  }, [t, delay]);
  const press = () => {
    if (state === 'locked') {
      sfx.play('sd_locked');
      shake.setValue(0);
      Animated.sequence([1, -1, 0.7, -0.7, 0.3, 0].map((k) => Animated.timing(shake, { toValue: k, duration: 45, useNativeDriver: true }))).start();
      return;
    }
    sfx.play('sd_select');
    fx.current?.burst('spark', NODE / 2, NODE / 2, 0.8);
    onPress(lv);
  };
  const colors = state === 'done' ? ['#fff7b0', '#ffd23a', '#ff9c0a'] : state === 'current' ? ['#ffe2c8', '#ff9a4a', '#e0601c'] : ['#f1ebe4', '#dacdbf', '#c2b2a1'];
  const ring = state === 'done' ? '#9c4d06' : state === 'current' ? '#8a3a0e' : '#7a6a8c';
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
        {state === 'locked' ? (
          <View style={styles.lock}>
            <View style={styles.lockShackle} />
            <View style={styles.lockBody} />
          </View>
        ) : null}
      </Pressable>
      {state === 'done' ? <Stars n={stars} /> : null}
      <FxLayer ref={fx} />
    </Animated.View>
  );
});

// list: [{ band, tier, … }] a level each; bannerOf(level) names its band,
// iconOf(level) draws its picture (or null)
// (REDESIGN_V8, the user: the level maps sideways): the levels run left to right, the page scrolling
// sideways, in one row along the middle of the screen (2026-11-16, the user: the list in the middle). Each band opens
// with its sign, its picture over its banner, standing in the row before its first level (it was over the row, which
// pushed the row down to the bottom edge).
const GAP_X = 92;
const SIGN_W = 210; // a sign with a picture (Squish Sort's fridges, Squish Hop's rooms)
const SIGN_W_TEXT = 150; // a banner only
const SIGN_GAP = 50; // from a node's centre to the sign's edge

// rowAt: where the row's middle line runs, as a fraction of the map's height (lower over a room's floor)
// the rooms behind the map (src/royal/WorldBg.js RoomBackdrop, useRoomStrip): roomOf(level) names the room
// a band's levels are played in; onSpans([{ room, x0, x1 }]) gets where each room runs along the page (from just
// before its first band's sign); scrollX (an Animated.Value) follows the page's scroll on the UI thread, so the rooms
// scroll with the levels (2026-11-17, the user: the background stood still while the list scrolled)
function LevelMap({ rec, uris = [], onPlay, list = LEVEL_LIST, bannerOf = shelves, iconOf, roomOf, onSpans, scrollX, rowAt = 0.5 }) {
  const { width, height: winH } = useGameDims(); // (the window)
  const [boxH, setBoxH] = useState(0);
  const H = boxH || winH - 60;
  const scroll = useRef(null);
  const cur = rec.lv;
  const LEVELS = list.length;
  const bandOf = (i) => list[i].band;
  const points = useMemo(() => {
    // a gentle wave about the middle line (a little above it: the stars hang under a beaten level)
    const amp = Math.min(rowAt > 0.6 ? 14 : 22, H * 0.07);
    const mid = H * rowAt - 10;
    const out = [];
    let x = 0;
    for (let i = 0; i < LEVELS; i++) {
      let sign = null;
      if (i === 0 || list[i].band !== list[i - 1].band) {
        sign = i === 0 ? 20 : out[i - 1].x + SIGN_GAP;
        const w = iconOf && iconOf(list[i]) ? SIGN_W : SIGN_W_TEXT;
        x = sign + w + SIGN_GAP;
      }
      out.push({ x, y: mid + Math.sin(i * 1.05) * amp, sign });
      x += GAP_X;
    }
    return out;
  }, [list, LEVELS, iconOf, H, rowAt]);
  const contentW = points[LEVELS - 1].x + 120;
  const mascot = uris.length ? uris[(cur * 11) % uris.length] : null;

  // the rooms along the page: a room from where its first band starts (between the last band's last level and the
  // sign) to the next room's
  const spans = useMemo(() => {
    if (!roomOf) return null;
    const out = [];
    for (let i = 0; i < LEVELS; i++) {
      if (points[i].sign == null) continue;
      const room = roomOf(list[i]);
      const last = out[out.length - 1];
      if (last && last.room === room) continue;
      const x0 = i === 0 ? 0 : points[i].sign - (SIGN_GAP - NODE / 2) / 2;
      if (last) last.x1 = x0;
      out.push({ room, x0, x1: 0 });
    }
    out[out.length - 1].x1 = Math.max(contentW, width);
    return out;
  }, [roomOf, LEVELS, points, list, contentW, width]);
  // (before the first frame: the rooms drawn where the page opens, the current level in the middle)
  useLayoutEffect(() => {
    if (scrollX) scrollX.setValue(Math.max(0, Math.min(points[Math.min(cur, LEVELS) - 1].x - width / 2, contentW - width)));
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);
  useLayoutEffect(() => {
    if (onSpans) onSpans(spans);
  }, [spans, onSpans]);
  const onScroll = useMemo(() => (scrollX ? Animated.event([{ nativeEvent: { contentOffset: { x: scrollX } } }], { useNativeDriver: true }) : undefined), [scrollX]);

  const order = useMemo(() => Array.from({ length: LEVELS }, (_, i) => i).sort((a, b) => Math.abs(a + 1 - cur) - Math.abs(b + 1 - cur)), [cur, LEVELS]);
  const n = useProgressive(LEVELS, 12, 10);
  const built = useMemo(() => new Set(order.slice(0, n)), [order, n]);

  useEffect(() => {
    const p = points[cur - 1];
    const tm = setTimeout(() => scroll.current?.scrollTo({ x: Math.max(0, p.x - width / 2), animated: false }), 0);
    const pops = [];
    for (let k = 0; k < 6; k++) pops.push(setTimeout(() => sfx.play('sd_nodePop', { rate: 0.9 + k * 0.07 }), 120 + k * 70));
    return () => {
      clearTimeout(tm);
      pops.forEach(clearTimeout);
    };
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const dots = [];
  for (let i = 0; i < LEVELS - 1; i++) {
    if (!built.has(i) || !built.has(i + 1)) continue;
    // (a band's sign stands between its levels and the last band's: no dots through it)
    if (points[i + 1].sign != null) continue;
    const a = points[i];
    const b = points[i + 1];
    for (let k = 1; k <= 3; k++) {
      const f = k / 4;
      dots.push(<View key={`d${i}-${k}`} style={[styles.dot, { left: a.x + (b.x - a.x) * f - 4, top: a.y + (b.y - a.y) * f - 4, backgroundColor: i + 1 < cur ? '#ffd23a' : 'rgba(255,255,255,0.75)' }]} />);
    }
  }
  const banners = [];
  for (let i = 0; i < LEVELS; i++) {
    if (i === 0 || bandOf(i) !== bandOf(i - 1)) {
      const L = list[i];
      // (the picture comes with its level's node, a few a frame)
      const icon = iconOf ? iconOf(L) : null;
      banners.push(
        <View key={`b${L.band}`} style={[styles.sign, { left: points[i].sign, width: icon ? SIGN_W : SIGN_W_TEXT, top: H * rowAt - 10 - H / 2, height: H }]}>
          {icon ? <View style={styles.icon}>{built.has(i) ? icon : null}</View> : null}
          <Text style={styles.bannerText}>{bannerOf(L)}</Text>
        </View>,
      );
    }
  }

  return (
    <Animated.ScrollView
      ref={scroll}
      horizontal
      style={styles.fill}
      contentContainerStyle={{ width: contentW, height: H }}
      showsHorizontalScrollIndicator={false}
      onLayout={(e) => setBoxH(Math.round(e.nativeEvent.layout.height))}
      onScroll={onScroll}
      // (every frame: the rooms behind follow the scroll)
      scrollEventThrottle={16}
    >
      {dots}
      {banners}
      {points.map((p, i) => {
        if (!built.has(i)) return null;
        const lv = i + 1;
        const state = lv < cur ? 'done' : lv === cur ? (rec.best[lv] ? 'done' : 'current') : 'locked';
        return (
          <Node
            key={lv}
            lv={lv}
            tier={list[i].tier}
            x={p.x}
            y={p.y}
            state={state}
            stars={rec.best[lv] || 0}
            delay={Math.min(700, Math.abs(lv - cur) * 45)}
            onPress={onPlay}
            mascot={lv === cur ? mascot : null}
            mascotLeft={p.sign == null}
          />
        );
      })}
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
  stars: { flexDirection: 'row', marginTop: 4, gap: 1 },
  mascot: { position: 'absolute', top: 8, zIndex: 3 },
  dot: { position: 'absolute', width: 8, height: 8, borderRadius: 4 },
  // a sign in the row: centred on the row's middle line (H / 2 - 10)
  sign: { position: 'absolute', alignItems: 'center', justifyContent: 'center' },
  icon: { marginBottom: 8, alignItems: 'center' },
  bannerText: { fontFamily: F.display, fontSize: 14, letterSpacing: 1.5, color: '#ffffff', textAlign: 'center', backgroundColor: '#b8641c', borderRadius: 16, borderWidth: 2.5, borderColor: '#ffffff', paddingHorizontal: 14, paddingVertical: 3, overflow: 'hidden' },
});

export default memo(LevelMap);
