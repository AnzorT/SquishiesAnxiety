import React, { memo, useMemo, useRef } from 'react';
import { Animated, Image, PanResponder, Pressable, StyleSheet, Text, View } from 'react-native';
import { SvgXml } from 'react-native-svg';
import { candyFonts } from '../theme/candyTheme';
import { decorPos, gameOf, itemOf, lightOn, movables, padBox, padLimits, padOffset, unitOffset } from './home';
import { artImage } from './art';

// The decor the player placed in a room (the design's decor layer): lamps
// switch on and off with a tap; in Edit mode every piece shows a dashed
// outline and can be dragged, and so can the yard's play spots and every
// piece of furniture (by their dashed boxes — the furniture's seats go with
// it). Drags arrive in screen points; `toLocal` turns them into the scene's
// directions (the landscape layout is a rotated view).

const INK = '#5b3a29';
const DASH = 'rgba(91,58,41,0.75)';

// a drag that reports scene-unit offsets from where it started
function useDrag({ scale, toLocal, onMove, onEnd }) {
  const cb = useRef({});
  cb.current = { scale, toLocal, onMove, onEnd };
  return useMemo(
    () =>
      PanResponder.create({
        onStartShouldSetPanResponder: () => true,
        onMoveShouldSetPanResponder: () => true,
        onPanResponderTerminationRequest: () => false,
        onPanResponderMove: (_, g) => {
          const { scale: s, toLocal: tl, onMove: m } = cb.current;
          const d = tl(g.dx, g.dy);
          if (m) m(d.x / s, d.y / s);
        },
        onPanResponderRelease: (_, g) => {
          const { scale: s, toLocal: tl, onEnd: e } = cb.current;
          const d = tl(g.dx, g.dy);
          if (e) e(d.x / s, d.y / s);
        },
        onPanResponderTerminate: (_, g) => {
          const { scale: s, toLocal: tl, onEnd: e } = cb.current;
          const d = tl(g.dx, g.dy);
          if (e) e(d.x / s, d.y / s);
        },
      }),
    []
  );
}

function DecorPiece({ d, home, scale, edit, phase, onToggleLight, onMoveDecor, toLocal }) {
  const p = decorPos(home, d.id);
  const off = d.light && !lightOn(home, d.id);
  const shift = useRef(new Animated.ValueXY({ x: 0, y: 0 })).current;
  const drag = useDrag({
    scale,
    toLocal,
    onMove: (dx, dy) => shift.setValue({ x: dx * scale, y: dy * scale }),
    onEnd: (dx, dy) => {
      shift.setValue({ x: 0, y: 0 });
      onMoveDecor(d.id, p.x + dx, p.y + dy);
    },
  });
  const w = d.w * scale;
  const h = d.h * scale;
  const art = d.svg ? <SvgXml xml={d.svg} width={w} height={h} /> : <Image source={artImage(d.art, phase)} fadeDuration={0} resizeMode="stretch" style={{ width: w, height: h }} />;
  const box = { position: 'absolute', left: p.x * scale, top: p.y * scale, width: w, height: h };
  if (edit) {
    return (
      <Animated.View {...drag.panHandlers} style={[box, { transform: shift.getTranslateTransform() }]}>
        {art}
        <View pointerEvents="none" style={[styles.dash, { borderRadius: 6 }]} />
      </Animated.View>
    );
  }
  if (d.light) {
    return (
      <Pressable onPress={() => onToggleLight(d.id)} hitSlop={6} style={[box, { opacity: off ? 0.62 : 1 }]}>
        {art}
      </Pressable>
    );
  }
  return (
    <View pointerEvents="none" style={box}>
      {art}
    </View>
  );
}

// a yard play spot's handle in Edit mode: drag the game around the yard
function PadHandle({ k, home, scale, onMovePad, toLocal }) {
  const start = useRef(null);
  const lim = (dx, dy) => {
    const L = start.current.lim;
    return { dx: Math.max(L.minX, Math.min(L.maxX, start.current.dx + dx)), dy: Math.max(L.minY, Math.min(L.maxY, start.current.dy + dy)) };
  };
  const drag = useDrag({
    scale,
    toLocal,
    onMove: (dx, dy) => {
      if (!start.current) start.current = { ...padOffset(home, k), lim: padLimits(home, k) };
      const v = lim(dx, dy);
      onMovePad(k, v.dx, v.dy, false);
    },
    onEnd: (dx, dy) => {
      if (!start.current) return;
      const v = lim(dx, dy);
      start.current = null;
      onMovePad(k, v.dx, v.dy, true);
    },
  });
  const b = padBox(home, k);
  if (!b) return null;
  const name = (itemOf(`g_${home.pads[k]}`) || gameOf(home.pads[k]) || { name: '' }).name;
  return (
    <View {...drag.panHandlers} style={{ position: 'absolute', left: b.x * scale, top: b.y * scale, width: b.w * scale, height: b.h * scale, alignItems: 'center' }}>
      <View pointerEvents="none" style={[styles.dash, { borderRadius: 10 }]} />
      <View pointerEvents="none" style={styles.tag}>
        <Text style={styles.tagText} numberOfLines={1}>
          {name}
        </Text>
      </View>
    </View>
  );
}

// a piece of furniture's handle in Edit mode: its dashed box and name; the
// drag moves the piece (and its seats) anywhere in the room
function UnitHandle({ m, home, scale, onMoveUnit, toLocal }) {
  const start = useRef(null);
  const lim = (dx, dy) => {
    const s = start.current;
    return { dx: Math.max(s.lim.minX, Math.min(s.lim.maxX, s.dx + dx)), dy: Math.max(s.lim.minY, Math.min(s.lim.maxY, s.dy + dy)) };
  };
  const drag = useDrag({
    scale,
    toLocal,
    onMove: (dx, dy) => {
      if (!start.current) start.current = { ...unitOffset(home, m.key), lim: m.lim };
      const v = lim(dx, dy);
      onMoveUnit(m.key, v.dx, v.dy, false);
    },
    onEnd: (dx, dy) => {
      if (!start.current) return;
      const v = lim(dx, dy);
      start.current = null;
      onMoveUnit(m.key, v.dx, v.dy, true);
    },
  });
  return (
    <View {...drag.panHandlers} style={{ position: 'absolute', left: m.box.x * scale, top: m.box.y * scale, width: m.box.w * scale, height: m.box.h * scale, alignItems: 'center' }}>
      <View pointerEvents="none" style={[styles.dash, styles.dashFurn, { borderRadius: 10 }]} />
      <View pointerEvents="none" style={styles.tag}>
        <Text style={styles.tagText} numberOfLines={1}>
          {m.name}
        </Text>
      </View>
    </View>
  );
}

export const DecorLayer = memo(function DecorLayer({ decor, home, room, scale, edit, phase, onToggleLight, onMoveDecor, onMovePad, onMoveUnit, toLocal }) {
  // the furniture's handles go under the decor's, biggest first, so a small
  // piece on top of a big one can still be picked up
  const units = edit ? movables(home, room).sort((a, b) => b.box.w * b.box.h - a.box.w * a.box.h) : [];
  return (
    <>
      {units.map((m) => (
        <UnitHandle key={m.key} m={m} home={home} scale={scale} onMoveUnit={onMoveUnit} toLocal={toLocal} />
      ))}
      {decor.map((d) => (
        <DecorPiece key={d.id} d={d} home={home} scale={scale} edit={edit} phase={phase} onToggleLight={onToggleLight} onMoveDecor={onMoveDecor} toLocal={toLocal} />
      ))}
      {edit && room === 'yard' ? Object.keys(home.pads).filter((k) => home.pads[k]).map((k) => <PadHandle key={k} k={k} home={home} scale={scale} onMovePad={onMovePad} toLocal={toLocal} />) : null}
    </>
  );
});

const styles = StyleSheet.create({
  dash: { ...StyleSheet.absoluteFillObject, borderWidth: 2, borderStyle: 'dashed', borderColor: DASH },
  dashFurn: { borderColor: 'rgba(79,154,58,0.9)', backgroundColor: 'rgba(201,232,168,0.12)' },
  tag: { marginTop: -11, paddingHorizontal: 7, paddingVertical: 1, borderRadius: 999, backgroundColor: '#fff8ee', borderWidth: 2, borderColor: INK },
  tagText: { fontFamily: candyFonts.bodyHeavy, fontSize: 9, color: INK },
});
