import React, { memo, useEffect, useMemo, useRef } from 'react';
import { Animated, Easing, Pressable, ScrollView, StyleSheet, Text, View, useWindowDimensions } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Path } from 'react-native-svg';
import sfx from '../audio/sfx';
import { Bob } from '../squad/ui';
import { FxLayer } from '../squishdoku/fx';
import { Head } from '../squishdoku/ui';
import { F, INK } from '../squishdoku/theme';
import { LEVELS, LEVEL_LIST, TIER_COLORS } from './levels';

// A container's 50 levels on a winding path, level 1 at the top (as
// Squishdoku's map): beaten levels gold with their stars, the next one pink
// and pulsing with a squishy bobbing beside it, the rest locked. A banner
// opens each size band (5 SHELVES × 4 …); the dot on a node is its tier.

const GAP = 92;
const NODE = 60;
const TOP = 130;
const BAND_GAP = 76;
const STAR_D = 'M12 2.2 L14.9 8.6 L21.8 9.3 L16.6 14 L18.1 20.9 L12 17.4 L5.9 20.9 L7.4 14 L2.2 9.3 L9.1 8.6 Z';

const bandOf = (i) => LEVEL_LIST[i].band;

const Stars = ({ n }) => (
  <View style={styles.stars}>
    {[0, 1, 2].map((i) => (
      <Svg key={i} width={i === 1 ? 20 : 16} height={i === 1 ? 20 : 16} viewBox="0 0 24 24" style={{ marginTop: i === 1 ? 0 : 4 }}>
        <Path d={STAR_D} fill={i < n ? '#ffd23a' : 'rgba(255,255,255,0.75)'} stroke={i < n ? '#b86200' : '#c9b9da'} strokeWidth={1.6} strokeLinejoin="round" />
      </Svg>
    ))}
  </View>
);

const Node = memo(function Node({ lv, x, y, state, stars, delay, onPress, mascot, mascotLeft }) {
  const t = useRef(new Animated.Value(0)).current;
  const shake = useRef(new Animated.Value(0)).current;
  const pulse = useRef(new Animated.Value(0)).current;
  const fx = useRef(null);
  useEffect(() => {
    Animated.spring(t, { toValue: 1, friction: 5, tension: 150, delay, useNativeDriver: true }).start();
  }, [t, delay]);
  useEffect(() => {
    if (state !== 'current') return undefined;
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(pulse, { toValue: 1, duration: 700, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
        Animated.timing(pulse, { toValue: 0, duration: 700, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
      ]),
    );
    loop.start();
    return () => loop.stop();
  }, [state, pulse]);
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

function LevelMap({ rec, uris = [], onPlay }) {
  const { width } = useWindowDimensions();
  const scroll = useRef(null);
  const cur = rec.lv;
  const points = useMemo(() => {
    const amp = Math.min(110, width * 0.27);
    let y = TOP;
    return Array.from({ length: LEVELS }, (_, i) => {
      if (i > 0 && bandOf(i) !== bandOf(i - 1)) y += BAND_GAP;
      const p = { x: width / 2 + Math.sin(i * 1.05) * amp, y };
      y += GAP;
      return p;
    });
  }, [width]);
  const height = points[LEVELS - 1].y + 120;
  const mascot = uris.length ? uris[(cur * 11) % uris.length] : null;

  useEffect(() => {
    const y = Math.max(0, points[cur - 1].y - 260);
    const tm = setTimeout(() => scroll.current?.scrollTo({ y, animated: false }), 0);
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
      const L = LEVEL_LIST[i];
      banners.push(
        <View key={`b${L.band}`} style={[styles.banner, { top: points[i].y - 104 }]}>
          <Text style={styles.bannerText}>{`${L.rows} ${L.rows > 1 ? 'SHELVES' : 'SHELF'} · ${L.cols} SPOTS`}</Text>
        </View>,
      );
    }
  }

  return (
    <ScrollView ref={scroll} style={styles.fill} contentContainerStyle={{ height }} showsVerticalScrollIndicator={false}>
      {dots}
      {banners}
      {points.map((p, i) => {
        const lv = i + 1;
        const state = lv < cur ? 'done' : lv === cur ? (rec.best[lv] ? 'done' : 'current') : 'locked';
        return (
          <Node
            key={lv}
            lv={lv}
            x={p.x}
            y={p.y}
            state={state}
            stars={rec.best[lv] || 0}
            delay={Math.min(700, Math.abs(lv - cur) * 45)}
            onPress={onPlay}
            mascot={lv === cur ? mascot : null}
            mascotLeft={p.x > width / 2}
          />
        );
      })}
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
  stars: { flexDirection: 'row', marginTop: 4, gap: 1 },
  mascot: { position: 'absolute', top: 8, zIndex: 3 },
  dot: { position: 'absolute', width: 8, height: 8, borderRadius: 4 },
  banner: { position: 'absolute', alignSelf: 'center', left: 0, right: 0, alignItems: 'center' },
  bannerText: { fontFamily: F.display, fontSize: 14, letterSpacing: 1.5, color: '#ffffff', backgroundColor: '#7a2fd6', borderRadius: 999, borderWidth: 2.5, borderColor: '#ffffff', paddingHorizontal: 14, paddingVertical: 3, overflow: 'hidden' },
});

export default memo(LevelMap);
