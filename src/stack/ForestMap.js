import React, { memo, useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { Animated, Easing, Image, ScrollView, StyleSheet, Text, View } from 'react-native';
import { useGameDims } from '../royal/GameFrame';
import { seasonNow } from '../royal/WorldBg';
import sfx from '../audio/sfx';
import { useProgressive } from '../components/Skeleton';
import RigStage from '../hop/RigStage';
import { useRigLook } from '../squad/looks';
import { NODE, Node } from '../sort/LevelMap';
import { F } from '../squishdoku/theme';
import { FOREST } from './forestTiles';
import { ROAD_W, TILES, TILE_H, TILE_W, layout, roadPath, roadY } from './road';

// Squish Stack's level map sideways (2026-11-17, the user: "let it be the trees forest", the background scrolling
// with the road, the road part of the background, "our current selected character walking to the next step"): the
// forest pictures side by side with their road (src/stack/road.js, tools/stack/forest.mjs), the whole height of the
// screen and scrolling with the levels, which stand on the road; a wooden sign by the road opens each band; the
// player's selected character (the design's live rig, rig/walk.html) stands on the next level to play, and when the
// player comes back from beating it, walks the road to the new one while the map follows. The screen's top bar lies
// over the forest's sky (`header`).

// the walker's page (rig/walk.html: its feet at the middle of the bottom edge, FOOT up) and its body's width
const BOX_W = 130;
const BOX_H = 140;
const FOOT = 14;
const BODY = 52;
// standing on a level: its feet this far above the road's middle line (on the button's top); on the road between
// levels, a little above the middle (the far half of the track)
const ON_NODE = NODE / 2 - 8;
const ON_ROAD = 6;
const TURN = 300; // the page turns it side-on before the first step (walk.html TURN)
const CALLS = ['mount', 'walk', 'face', 'play', 'look', 'pause'];
const smooth = (u) => u * u * (3 - 2 * u);

// a band's wooden sign, standing on the road's far edge at (x, y)
const SIGN_W = 136;
const SIGN_H = 70;
const Sign = memo(function Sign({ x, y, text }) {
  const [a, b] = text.split(' · ');
  return (
    <View pointerEvents="none" style={[styles.sign, { left: x - SIGN_W / 2, top: y - SIGN_H }]}>
      <View style={styles.board}>
        <Text style={styles.signText}>{a}</Text>
        {b ? <Text style={styles.signText}>{b}</Text> : null}
      </View>
      <View style={styles.posts}>
        <View style={styles.post} />
        <View style={styles.post} />
      </View>
    </View>
  );
});

// rec: the game's record ({ lv, best }); list: its levels ({ band, tier, … }); bannerOf(level): a band's sign;
// walker: the selected character's key; visit: changes each time the map comes into view (a fresh page for the
// walker: a WebView kept hidden under a level can come back blank)
function ForestMap({ rec, list, bannerOf, onPlay, walker, visit = 0, header }) {
  const { width } = useGameDims();
  const [H, setH] = useState(0);
  const k = H / TILE_H;
  const L = useMemo(() => layout(list), [list]);
  const LEVELS = list.length;
  const cur = Math.max(1, Math.min(rec.lv, LEVELS));
  const target = cur - 1; // where the walker belongs: the next level to play
  const season = useMemo(seasonNow, []);
  const scroll = useRef(null);

  // the nodes, built nearest the current one first, a few a frame
  const order = useMemo(() => Array.from({ length: LEVELS }, (_, i) => i).sort((a, b) => Math.abs(a - target) - Math.abs(b - target)), [target, LEVELS]);
  const n = useProgressive(LEVELS, 12, 10);
  const built = useMemo(() => new Set(order.slice(0, n)), [order, n]);

  // --- the walker ----------------------------------------------------------------------------------------------
  const [stand, setStand] = useState(target);
  const [walk, setWalk] = useState(null); // { pts, ms, to }
  const [shownVisit, setShownVisit] = useState(-1);
  const shown = shownVisit === visit;
  const t = useRef(new Animated.Value(0)).current;
  const stage = useRef(null);
  const follow = useRef(null);
  useEffect(() => () => clearTimeout(follow.current), []);
  const look = useRigLook(walker);
  // its feet at road place x (dp): stepping down off a level onto the road and up onto the next
  const feet = useCallback(
    (x) => {
      let d = Infinity;
      for (const nx of L.nodes) d = Math.min(d, Math.abs(nx - x));
      const u = Math.max(0, 1 - (d * k) / (NODE * 0.75));
      return [x * k, roadY(x) * k - (ON_ROAD + (ON_NODE - ON_ROAD) * smooth(u))];
    },
    [L, k],
  );
  const transform = useMemo(() => {
    if (!H) return [];
    const at = feet(L.nodes[Math.min(stand, LEVELS - 1)]);
    const pts = walk ? walk.pts : [at, at];
    const inputRange = pts.map((_, i) => i / (pts.length - 1));
    return [
      { translateX: t.interpolate({ inputRange, outputRange: pts.map((p) => p[0] - BOX_W / 2) }) },
      { translateY: t.interpolate({ inputRange, outputRange: pts.map((p) => p[1] - (BOX_H - FOOT)) }) },
    ];
  }, [walk, stand, H, feet, L, LEVELS, t]);

  // back on the map with the next level further on: walk there (once the character is drawn; too far, or back
  // down, or never drawn: just there)
  useEffect(() => {
    if (!H || walk || stand === target) return undefined;
    const far = target < stand || target - stand > 6 || !walker;
    const tm = setTimeout(
      () => {
        if (far || !shown) {
          setStand(target);
          return;
        }
        const x0 = L.nodes[stand];
        const x1 = L.nodes[target];
        const ms = Math.round(Math.min(4200, Math.max(1100, (Math.abs(x1 - x0) * k) / 0.11)));
        // the camera: both ends on screen when they fit, else from where it starts, then on to where it's going
        const X0 = x0 * k;
        const X1 = x1 * k;
        const to = (x) => scroll.current?.scrollTo({ x: Math.max(0, x), animated: true });
        if (Math.abs(X1 - X0) < width - 160) to((X0 + X1) / 2 - width / 2);
        else {
          to(X1 > X0 ? X0 - 100 : X0 - width + 100);
          follow.current = setTimeout(() => to(X1 > X0 ? X1 - width + 120 : X1 - 120), TURN + ms * 0.45);
        }
        stage.current?.walk(ms, x1 > x0 ? 1 : -1);
        setWalk({ pts: roadPath(x0, x1, 10).map(([x]) => feet(x)), ms, to: target });
      },
      far ? 0 : shown ? 650 : 3500,
    );
    return () => clearTimeout(tm);
  }, [H, walk, stand, target, shown, walker, L, k, width, feet]);
  // (started once its path is drawn: the page turns first, so the steps begin TURN later)
  useEffect(() => {
    if (!walk) return;
    t.setValue(0);
    Animated.timing(t, { toValue: 1, duration: walk.ms, delay: TURN, easing: Easing.bezier(0.3, 0, 0.7, 1), useNativeDriver: true }).start(() => {
      setStand(walk.to);
      setWalk(null);
      sfx.play('sd_nodePop', { rate: 1.1 });
    });
  }, [walk, t]);

  const onReady = useCallback(() => stage.current?.mount(walker, BODY, look), [walker, look]);
  useEffect(() => {
    stage.current?.mount(walker, BODY, look); // (a new pick, a new look: before the page is up this does nothing)
  }, [walker, look]);
  const onCast = useCallback((m) => m.ok && setShownVisit(visit), [visit]);

  // the walker's level in the middle of the screen, and the nodes round it popping in
  useEffect(() => {
    if (!H) return undefined;
    const tm = setTimeout(() => scroll.current?.scrollTo({ x: Math.max(0, L.nodes[Math.min(stand, LEVELS - 1)] * k - width / 2), animated: false }), 0);
    const pops = [];
    for (let i = 0; i < 6; i++) pops.push(setTimeout(() => sfx.play('sd_nodePop', { rate: 0.9 + i * 0.07 }), 120 + i * 70));
    return () => {
      clearTimeout(tm);
      pops.forEach(clearTimeout);
    };
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [H > 0]);

  const contentW = L.width * k;
  const tileW = TILE_W * k;
  const tiles = [];
  if (H) for (let i = 0; i * tileW < contentW; i++) tiles.push(<Image key={i} source={FOREST[season][i % TILES]} fadeDuration={0} style={{ position: 'absolute', left: Math.floor(i * tileW), top: 0, width: Math.ceil(tileW) + 1, height: H }} />);

  return (
    <View style={styles.fill} onLayout={(e) => setH(Math.round(e.nativeEvent.layout.height))}>
      {H ? (
        <ScrollView ref={scroll} horizontal style={styles.fill} contentContainerStyle={{ width: contentW, height: H }} showsHorizontalScrollIndicator={false}>
          {tiles}
          {L.signs.map((s) => (
            <Sign key={`s${s.i}`} x={s.x * k} y={(roadY(s.x) - ROAD_W / 2) * k + 6} text={bannerOf(list[s.i])} />
          ))}
          {L.nodes.map((x, i) => {
            if (!built.has(i)) return null;
            const lv = i + 1;
            const state = lv < cur ? 'done' : lv === cur ? (rec.best[lv] ? 'done' : 'current') : 'locked';
            return <Node key={lv} lv={lv} tier={list[i].tier} x={x * k} y={roadY(x) * k} state={state} stars={rec.best[lv] || 0} delay={Math.min(700, Math.abs(i - target) * 45)} onPress={onPlay} />;
          })}
          {walker ? (
            <Animated.View pointerEvents="none" style={[styles.walker, { opacity: shown ? 1 : 0, transform }]}>
              <RigStage key={visit} ref={stage} page="walk" calls={CALLS} onReady={onReady} onCast={onCast} style={styles.fill} />
            </Animated.View>
          ) : null}
        </ScrollView>
      ) : null}
      {header ? (
        <View pointerEvents="box-none" style={styles.header}>
          {header}
        </View>
      ) : null}
    </View>
  );
}

const styles = StyleSheet.create({
  fill: { flex: 1 },
  header: { position: 'absolute', left: 0, right: 0, top: 0 },
  walker: { position: 'absolute', left: 0, top: 0, width: BOX_W, height: BOX_H },
  sign: { position: 'absolute', width: SIGN_W, height: SIGN_H, alignItems: 'center', justifyContent: 'flex-end' },
  board: { backgroundColor: '#b8641c', borderRadius: 10, borderWidth: 2.5, borderColor: '#fff3dc', paddingHorizontal: 10, paddingVertical: 3, alignItems: 'center', shadowColor: '#2a1608', shadowOpacity: 0.35, shadowRadius: 3, shadowOffset: { width: 0, height: 2 }, elevation: 3 },
  signText: { fontFamily: F.display, fontSize: 12, lineHeight: 15, letterSpacing: 1.2, color: '#ffffff', textAlign: 'center', includeFontPadding: false },
  posts: { flexDirection: 'row', gap: 44, height: 16 },
  post: { width: 6, height: 16, backgroundColor: '#7a4a22', borderLeftWidth: 1.5, borderRightWidth: 1.5, borderColor: '#4a2a10' },
});

export default memo(ForestMap);
