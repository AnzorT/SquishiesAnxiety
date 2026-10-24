import React, { memo } from 'react';
import { Animated, StyleSheet, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Defs, Ellipse, Path, RadialGradient, Rect, Stop } from 'react-native-svg';

// The fridge (or the toy cupboard): its body with a lip, the freezer (or a
// carved top), the lit inside with its shelves, and two doors swinging on
// their hinges. `door` (Animated, 0 shut → 1 open) and `light` (0 → 1, the
// lamp) are the game's; `inside` is drawn between the shelves and the doors
// (the squishies on show), `slots` marks the empty spots. Sizes come from
// geometry() so the game can hit-test the same rects it draws.

export const RING = 3;
export const BORDER = 3;
export const WALL = 8;
export const SHELF = 8;
const BOTTOM = 10;
const LIP = 7;
export const FEET = 12;
const TOP = { fridge: 40, cupboard: 36 };
const OPEN_DEG = 106;

// Where everything goes for a `rows` × `cols` container in a `w` × `h` area,
// leaving `trayH` at the bottom: big (the user, 2026-10-24: "the fridge
// needs to be bigger"), but with room either side for the open doors ("so
// we can see the doors"). S: one spot's side.
const BODY_SHARE = 0.72;
export function geometry({ w, h, rows, cols, theme, trayH, maxS = 96 }) {
  const top = TOP[theme] || 40;
  const chrome = RING * 2 + BORDER * 2 + top + BOTTOM + LIP + FEET;
  const availH = h - trayH - 10;
  const S = Math.max(34, Math.floor(Math.min((w * BODY_SHARE - 2 * (RING + BORDER + WALL)) / cols, (availH - chrome) / rows - SHELF, maxS)));
  const W = S * cols;
  const H = rows * (S + SHELF);
  const bodyW = W + 2 * (RING + BORDER + WALL);
  const bodyH = RING * 2 + BORDER * 2 + top + H + BOTTOM + LIP;
  const bx = Math.round((w - bodyW) / 2);
  const by = Math.max(4, Math.round((availH - (bodyH + FEET)) / 2) + 2);
  const ix = bx + RING + BORDER + WALL;
  const iy = by + RING + BORDER + top;
  return { S, W, H, rows, cols, top, bodyW, bodyH, bx, by, ix, iy, theme };
}
export const slotCenter = (g, i) => ({ x: g.ix + (i % g.cols) * g.S + g.S / 2, y: g.iy + Math.floor(i / g.cols) * (g.S + SHELF) + g.S / 2 });
// the slot under a point inside, or -1
export function slotAt(g, x, y) {
  const pad = 12;
  if (x < g.ix - pad || x > g.ix + g.W + pad || y < g.iy - pad || y > g.iy + g.H + pad) return -1;
  const c = Math.max(0, Math.min(g.cols - 1, Math.floor((x - g.ix) / g.S)));
  const r = Math.max(0, Math.min(g.rows - 1, Math.floor((y - g.iy) / (g.S + SHELF))));
  return r * g.cols + c;
}

// --- the tops -------------------------------------------------------------------------

function FreezerTop({ t, width, height }) {
  return (
    <View style={[styles.topPanel, { height, borderColor: t.trim }]}>
      <LinearGradient colors={t.top} style={StyleSheet.absoluteFill} />
      <View style={styles.topShine} />
      <Svg width={22} height={22} viewBox="0 0 24 24" style={styles.flake}>
        {[0, 60, 120].map((a) => (
          <Path key={a} d="M12 2 V22 M12 5 L9.5 3 M12 5 L14.5 3 M12 19 L9.5 21 M12 19 L14.5 21" stroke="#7cc4e2" strokeWidth={2} strokeLinecap="round" fill="none" transform={`rotate(${a} 12 12)`} />
        ))}
      </Svg>
      <View style={[styles.hHandle, { width: Math.min(110, width * 0.42) }]}>
        <LinearGradient colors={t.handle} style={StyleSheet.absoluteFill} />
      </View>
      <View style={styles.magnets}>
        <View style={[styles.magnet, { backgroundColor: '#ff6fae' }]} />
        <View style={[styles.magnet, { backgroundColor: '#ffd23a', marginTop: 6 }]} />
        <View style={[styles.magnet, { backgroundColor: '#7be884' }]} />
      </View>
    </View>
  );
}

function CupboardTop({ t, height }) {
  return (
    <View style={[styles.topPanel, { height, borderColor: t.trim }]}>
      <LinearGradient colors={t.top} style={StyleSheet.absoluteFill} />
      <View style={styles.topShine} />
      <View style={[styles.carve, { borderColor: t.trim }]} />
      <Svg width={30} height={30} viewBox="0 0 24 24">
        <Path d="M12 2.5 L14.6 8.6 L21.2 9.2 L16.2 13.5 L17.7 20 L12 16.6 L6.3 20 L7.8 13.5 L2.8 9.2 L9.4 8.6 Z" fill="#ffd23a" stroke="#ffffff" strokeWidth={1.8} strokeLinejoin="round" />
      </Svg>
    </View>
  );
}

// --- a door ----------------------------------------------------------------------------

// The door's outside: the theme's panel, a handle by the middle seam, and
// a magnet or two (fridge) or a carved panel (cupboard).
function DoorFront({ t, side, w, h }) {
  const seam = side === 'left' ? { right: 7 } : { left: 7 };
  return (
    <View style={[styles.doorFace, { borderColor: t.trim }]}>
      <LinearGradient colors={t.door} start={{ x: side === 'left' ? 0 : 1, y: 0 }} end={{ x: side === 'left' ? 1 : 0, y: 1 }} style={StyleSheet.absoluteFill} />
      <View style={styles.doorShine} />
      {t.key === 'cupboard' ? (
        <>
          <View style={[styles.panelInset, { borderColor: t.trim }]} />
          <View style={[styles.knob, seam, { top: h / 2 - 9 }]}>
            <LinearGradient colors={t.handle} style={StyleSheet.absoluteFill} />
          </View>
          <Svg width={18} height={16} viewBox="0 0 24 22" style={[styles.heart, side === 'left' ? { left: w / 2 - 12 } : { left: w / 2 - 6 }]}>
            <Path d="M12 20 C5 14.5 2 11 2 7 C2 4 4.3 2 7 2 C9 2 10.8 3.2 12 5 C13.2 3.2 15 2 17 2 C19.7 2 22 4 22 7 C22 11 19 14.5 12 20 Z" fill={t.trim} opacity={0.5} />
          </Svg>
        </>
      ) : (
        <>
          <View style={[styles.vHandle, seam, { top: h * 0.2, height: h * 0.42 }]}>
            <LinearGradient colors={t.handle} start={{ x: 0, y: 0 }} end={{ x: 1, y: 0 }} style={StyleSheet.absoluteFill} />
          </View>
          {side === 'left' ? (
            <Svg width={26} height={26} viewBox="0 0 24 24" style={{ position: 'absolute', left: 10, top: h * 0.12 }}>
              <Path d="M12 20 C5 14.5 2 11 2 7 C2 4 4.3 2 7 2 C9 2 10.8 3.2 12 5 C13.2 3.2 15 2 17 2 C19.7 2 22 4 22 7 C22 11 19 14.5 12 20 Z" fill="#ff6fae" stroke="#ffffff" strokeWidth={2} />
            </Svg>
          ) : (
            <Svg width={24} height={24} viewBox="0 0 24 24" style={{ position: 'absolute', right: 12, top: h * 0.62 }}>
              <Path d="M12 2.5 L14.6 8.6 L21.2 9.2 L16.2 13.5 L17.7 20 L12 16.6 L6.3 20 L7.8 13.5 L2.8 9.2 L9.4 8.6 Z" fill="#ffd23a" stroke="#ffffff" strokeWidth={2} strokeLinejoin="round" />
            </Svg>
          )}
        </>
      )}
    </View>
  );
}

// The door's inside (seen when it swings open): plainer, with door shelves.
function DoorBack({ t }) {
  return (
    <View style={[styles.doorFace, { borderColor: t.trim }]}>
      <LinearGradient colors={t.doorInner} style={StyleSheet.absoluteFill} />
      {[0.3, 0.62].map((y) => (
        <View key={y} style={[styles.doorShelf, { top: `${y * 100}%`, backgroundColor: t.shelf.face, borderColor: t.shelf.edge }]} />
      ))}
    </View>
  );
}

// One door over half the inside, turning about its outer edge.
function Door({ t, side, w, h, door }) {
  const sign = side === 'left' ? -1 : 1;
  const rotateY = door.interpolate({ inputRange: [0, 1], outputRange: ['0deg', `${sign * OPEN_DEG}deg`] });
  const transform = [{ perspective: 900 }, { translateX: (sign * w) / 2 }, { rotateY }, { translateX: (-sign * w) / 2 }];
  return (
    <Animated.View pointerEvents="none" style={[styles.door, { width: w, height: h, transform }, side === 'left' ? { left: 0 } : { left: w }]}>
      <View style={[StyleSheet.absoluteFill, { backfaceVisibility: 'hidden' }]}>
        <DoorFront t={t} side={side} w={w} h={h} />
      </View>
      <View style={[StyleSheet.absoluteFill, { backfaceVisibility: 'hidden', transform: [{ rotateY: '180deg' }] }]}>
        <DoorBack t={t} />
      </View>
    </Animated.View>
  );
}

// --- the whole thing --------------------------------------------------------------------

function Container({ t, g, door, light, inside, slots }) {
  const { S, W, H, rows, cols, top, bodyW, bodyH } = g;
  const shelves = Array.from({ length: rows }, (_, r) => (r + 1) * (S + SHELF) - SHELF);
  return (
    <View pointerEvents="none" style={{ width: bodyW, height: bodyH + FEET }}>
      {/* feet */}
      <View style={[styles.foot, { left: 18, backgroundColor: t.feet }, t.key === 'cupboard' && styles.ballFoot]} />
      <View style={[styles.foot, { right: 18, backgroundColor: t.feet }, t.key === 'cupboard' && styles.ballFoot]} />
      {/* the body: ring, lip, white border */}
      <View style={[styles.ring, { width: bodyW, height: bodyH, backgroundColor: t.ring }]}>
        <View style={styles.bodyFace}>
          <LinearGradient colors={t.body} start={{ x: 0, y: 0 }} end={{ x: 1, y: 1 }} style={StyleSheet.absoluteFill} />
          <View style={[styles.sideShine]} />
          <View style={{ marginHorizontal: WALL - 2, marginTop: 4 }}>
            {t.key === 'cupboard' ? <CupboardTop t={t} height={top - 8} /> : <FreezerTop t={t} width={W} height={top - 8} />}
          </View>
        </View>
      </View>
      {/* the inside */}
      <View style={[styles.inside, { left: RING + BORDER + WALL, top: RING + BORDER + top, width: W, height: H }]}>
        <LinearGradient colors={t.inside} locations={[0, 0.55, 1]} style={StyleSheet.absoluteFill} />
        {/* the back wall's grooves */}
        {Array.from({ length: cols - 1 }, (_, c) => (
          <View key={c} style={[styles.groove, { left: (c + 1) * S - 1 }]} />
        ))}
        {/* the lamp */}
        <Animated.View style={[StyleSheet.absoluteFill, { opacity: light }]}>
          <Svg width={W} height={H} style={StyleSheet.absoluteFill}>
            <Defs>
              <RadialGradient id="lamp" cx="50%" cy="0%" r="75%">
                <Stop offset="0" stopColor={t.lamp} stopOpacity={0.95} />
                <Stop offset="0.5" stopColor={t.lamp} stopOpacity={0.35} />
                <Stop offset="1" stopColor={t.lamp} stopOpacity={0} />
              </RadialGradient>
            </Defs>
            <Rect x={0} y={0} width={W} height={H} fill="url(#lamp)" />
            <Ellipse cx={W / 2} cy={3} rx={Math.min(28, W * 0.12)} ry={4} fill="#ffffff" />
          </Svg>
        </Animated.View>
        {/* the shelves */}
        {shelves.map((y, r) => (
          <View key={r} style={[styles.shelf, { top: y, height: SHELF }]}>
            <View style={[styles.shelfTop, { backgroundColor: t.shelf.top }]} />
            <View style={[styles.shelfFace, { backgroundColor: t.shelf.face, borderBottomColor: t.shelf.edge }]} />
          </View>
        ))}
        {/* the empty spots, while putting them back */}
        {slots
          ? Array.from({ length: rows * cols }, (_, i) => (
              <View
                key={i}
                style={[styles.slotMark, { left: (i % cols) * S + S * 0.1, top: Math.floor(i / cols) * (S + SHELF) + S * 0.1, width: S * 0.8, height: S * 0.8, borderRadius: S * 0.22, borderColor: t.slotDash }]}
              />
            ))
          : null}
        {inside}
      </View>
      {/* the doors */}
      <View style={[styles.doors, { left: RING + BORDER + WALL, top: RING + BORDER + top, width: W, height: H }]} pointerEvents="none">
        <Door t={t} side="left" w={W / 2} h={H} door={door} />
        <Door t={t} side="right" w={W / 2} h={H} door={door} />
      </View>
    </View>
  );
}

export default memo(Container);

// --- a small one, for the game picker and the hub cards ------------------------------

// A little container whose doors open and close by themselves (`door`
// Animated), a squishy or two inside.
export function MiniContainer({ t, size = 92, door, uris = [] }) {
  const g = { S: (size - 2 * (RING + BORDER + 6)) / 2, rows: 2, cols: 2 };
  const W = g.S * 2;
  const H = 2 * (g.S + 4);
  const top = Math.round(size * 0.18);
  const bodyW = W + 2 * (RING + BORDER + 6);
  const bodyH = RING * 2 + BORDER * 2 + top + H + 8 + 4;
  return (
    <View pointerEvents="none" style={{ width: bodyW, height: bodyH + 6 }}>
      <View style={[styles.foot, { left: 10, width: 10, height: 8, backgroundColor: t.feet }]} />
      <View style={[styles.foot, { right: 10, width: 10, height: 8, backgroundColor: t.feet }]} />
      <View style={[styles.ring, { width: bodyW, height: bodyH, backgroundColor: t.ring, borderRadius: 16, paddingBottom: RING + 4 }]}>
        <View style={[styles.bodyFace, { borderRadius: 13 }]}>
          <LinearGradient colors={t.body} start={{ x: 0, y: 0 }} end={{ x: 1, y: 1 }} style={StyleSheet.absoluteFill} />
          <View style={[styles.miniTop, { height: top - 6 }]}>
            <LinearGradient colors={t.top} style={StyleSheet.absoluteFill} />
            <View style={[styles.miniHandle, { backgroundColor: t.trim }]} />
          </View>
        </View>
      </View>
      <View style={[styles.inside, { left: RING + BORDER + 6, top: RING + BORDER + top, width: W, height: H, borderRadius: 6 }]}>
        <LinearGradient colors={t.inside} style={StyleSheet.absoluteFill} />
        {[0, 1].map((r) => (
          <View key={r} style={[styles.shelf, { top: (r + 1) * (g.S + 4) - 4, height: 4 }]}>
            <View style={[styles.shelfFace, { backgroundColor: t.shelf.face, borderBottomColor: t.shelf.edge }]} />
          </View>
        ))}
        {uris.slice(0, 3).map((u, i) => (
          <Animated.Image key={i} source={{ uri: u }} resizeMode="contain" fadeDuration={0} style={{ position: 'absolute', left: [0, g.S, g.S * 0.5][i] + 2, top: [0, 0, g.S + 4][i] + 2, width: g.S - 4, height: g.S - 4 }} />
        ))}
      </View>
      <View style={[styles.doors, { left: RING + BORDER + 6, top: RING + BORDER + top, width: W, height: H }]}>
        <Door t={t} side="left" w={W / 2} h={H} door={door} />
        <Door t={t} side="right" w={W / 2} h={H} door={door} />
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  ring: { position: 'absolute', left: 0, top: 0, borderRadius: 26, padding: RING, paddingBottom: RING + LIP },
  bodyFace: { flex: 1, borderRadius: 23, borderWidth: BORDER, borderColor: '#ffffff', overflow: 'hidden' },
  sideShine: { position: 'absolute', left: 6, top: 10, bottom: 10, width: 6, borderRadius: 3, backgroundColor: 'rgba(255,255,255,0.55)' },
  topPanel: { borderRadius: 12, borderWidth: 2, overflow: 'hidden', flexDirection: 'row', alignItems: 'center', justifyContent: 'center' },
  topShine: { position: 'absolute', left: 8, right: 8, top: 3, height: '35%', borderRadius: 8, backgroundColor: 'rgba(255,255,255,0.55)' },
  flake: { position: 'absolute', left: 10 },
  hHandle: { position: 'absolute', bottom: 6, height: 8, borderRadius: 4, overflow: 'hidden', borderWidth: 1.5, borderColor: '#ffffff' },
  magnets: { position: 'absolute', right: 10, flexDirection: 'row', gap: 4 },
  magnet: { width: 10, height: 10, borderRadius: 5, borderWidth: 1.5, borderColor: '#ffffff' },
  carve: { position: 'absolute', left: 10, right: 10, top: 6, bottom: 6, borderRadius: 10, borderWidth: 2, opacity: 0.35 },
  inside: { position: 'absolute', borderRadius: 12, overflow: 'hidden' },
  groove: { position: 'absolute', top: 0, bottom: 0, width: 2, backgroundColor: 'rgba(255,255,255,0.35)' },
  shelf: { position: 'absolute', left: 0, right: 0 },
  shelfTop: { height: 3 },
  shelfFace: { flex: 1, borderBottomWidth: 2 },
  slotMark: { position: 'absolute', borderWidth: 2.5, borderStyle: 'dashed' },
  doors: { position: 'absolute' },
  door: { position: 'absolute', top: 0 },
  doorFace: { flex: 1, borderRadius: 10, borderWidth: 2.5, overflow: 'hidden' },
  doorShine: { position: 'absolute', left: 6, top: 8, bottom: 8, width: 5, borderRadius: 3, backgroundColor: 'rgba(255,255,255,0.7)' },
  vHandle: { position: 'absolute', width: 9, borderRadius: 5, overflow: 'hidden', borderWidth: 1.5, borderColor: '#ffffff' },
  panelInset: { position: 'absolute', left: 8, right: 8, top: 10, bottom: 10, borderRadius: 8, borderWidth: 2, opacity: 0.4 },
  knob: { position: 'absolute', width: 18, height: 18, borderRadius: 9, overflow: 'hidden', borderWidth: 2, borderColor: '#ffffff' },
  heart: { position: 'absolute', top: 14 },
  doorShelf: { position: 'absolute', left: 6, right: 6, height: 8, borderRadius: 3, borderBottomWidth: 2 },
  foot: { position: 'absolute', bottom: 0, width: 16, height: FEET + 4, borderBottomLeftRadius: 5, borderBottomRightRadius: 5 },
  ballFoot: { width: 18, height: 18, borderRadius: 9 },
  miniTop: { marginHorizontal: 5, marginTop: 3, borderRadius: 6, overflow: 'hidden', alignItems: 'center', justifyContent: 'flex-end' },
  miniHandle: { width: '40%', height: 3, borderRadius: 2, marginBottom: 3 },
});
