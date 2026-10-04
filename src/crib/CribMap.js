import React, { memo } from 'react';
import { Image, Pressable, StyleSheet, Text, View } from 'react-native';
import CreatureThumbnail from '../components/CreatureThumbnail';
import { candyFonts } from '../theme/candyTheme';
import { SCENE_H, SCENE_W } from './data';

// The landscape Crib's map (the design's CRIB MAP in "Squad Crib v5"): the
// house cut open, its rooms with their names, how many friends are in each,
// who needs something or is busy, up to a few of their faces, and "YOU'RE
// HERE"; the yard beside it. The scenery is the design's own, shot by
// tools/crib-art/map.mjs (assets/crib/map.webp); the rest is drawn here at
// the design's positions (852×393 units, at `scale`, centred in w×h).
//
// `summary`: { [room]: { pets: [creature…], count, busy, needs, eggs } }

const INK = '#5b3a29';
const MAP = require('../../assets/crib/map.webp');

// the rooms' boxes on the map; the yard's label sits under its tree
const RECTS = {
  hatch: { x: 306, y: 56, w: 128, h: 56, name: 'Hatchery' },
  bed: { x: 100, y: 124, w: 266, h: 92, name: 'Bedroom' },
  bath: { x: 374, y: 124, w: 268, h: 92, name: 'Bathroom' },
  living: { x: 100, y: 228, w: 238, h: 90, name: 'Living Room' },
  kitchen: { x: 346, y: 228, w: 144, h: 90, name: 'Kitchen' },
  dance: { x: 498, y: 228, w: 144, h: 90, name: 'Dance Room' },
  yard: { x: 668, y: 150, w: 176, h: 178, name: 'Yard', open: true },
};

const Room = memo(function Room({ room, info, here, s, onGo }) {
  const r = RECTS[room];
  const count = room === 'hatch' ? `${info.eggs} eggs` : String(info.count);
  const label = (
    <View style={[styles.labels, r.open ? { left: 0, top: 132 * s } : { left: 5 * s, top: 5 * s }]}>
      <View style={[styles.name, { paddingHorizontal: 8 * s }]}>
        <Text style={[styles.nameText, { fontSize: 11 * s }]}>{r.name}</Text>
      </View>
      <View style={[styles.count, { paddingHorizontal: 6 * s }]}>
        <Text style={[styles.countText, { fontSize: 11 * s }]}>{count}</Text>
      </View>
    </View>
  );
  return (
    <Pressable onPress={() => onGo(room)} style={({ pressed }) => [{ position: 'absolute', left: r.x * s, top: r.y * s, width: r.w * s, height: r.h * s, borderRadius: 6 * s, overflow: r.open ? 'visible' : 'hidden' }, pressed && { opacity: 0.85 }]}>
      <View style={[styles.faces, { bottom: (r.open ? 10 : 7) * s }]} pointerEvents="none">
        {info.pets.slice(0, room === 'hatch' ? 3 : 5).map((c) => (
          <View key={c.id} style={{ marginHorizontal: -2 * s }}>
            <CreatureThumbnail creature={c} size={30 * s} animate={false} />
          </View>
        ))}
      </View>
      {/* every room's frame, drawn (the picture's own thin one got lost on the
          bedroom, whose floor is the house's colour) */}
      {r.open ? null : <View pointerEvents="none" style={[StyleSheet.absoluteFill, { borderWidth: 3 * s, borderColor: INK, borderRadius: 6 * s }]} />}
      {label}
      {!r.open && (info.needs || info.busy) ? (
        <View style={[styles.labels, { right: 5 * s, top: 5 * s }]}>
          {info.needs ? (
            <View style={[styles.flag, { backgroundColor: '#f2665a' }]}>
              <Text style={[styles.flagText, { color: '#ffffff', fontSize: 10 * s }]}>{`${info.needs} need you`}</Text>
            </View>
          ) : null}
          {info.busy ? (
            <View style={[styles.flag, { backgroundColor: '#ffd66b' }]}>
              <Text style={[styles.flagText, { color: INK, fontSize: 10 * s }]}>{`${info.busy} busy`}</Text>
            </View>
          ) : null}
        </View>
      ) : null}
      {here ? (
        <>
          {r.open ? null : <View pointerEvents="none" style={[StyleSheet.absoluteFill, { borderWidth: 4, borderColor: '#ffd66b', borderRadius: 6 * s }]} />}
          <View style={[styles.here, r.open ? { right: 0, top: 132 * s } : { right: 5 * s, bottom: 5 * s }]}>
            <Text style={[styles.hereText, { fontSize: 9 * s }]}>{"YOU'RE HERE"}</Text>
          </View>
        </>
      ) : null}
    </Pressable>
  );
});

export default function CribMap({ width, height, scale, summary, current, onGo, onClose }) {
  const s = scale;
  const mw = SCENE_W * s;
  const mh = SCENE_H * s;
  const left = (width - mw) / 2;
  const top = (height - mh) / 2;
  return (
    <View style={[StyleSheet.absoluteFill, styles.wrap]}>
      {/* the sky and the grass beyond the picture's edges */}
      <View style={[styles.grass, { top: top + 318 * s }]} />
      <View style={{ position: 'absolute', left, top, width: mw, height: mh }}>
        <Image source={MAP} fadeDuration={0} resizeMode="stretch" style={{ width: mw, height: mh }} />
        {Object.keys(RECTS).map((room) => (
          <Room key={room} room={room} info={summary[room]} here={current === room} s={s} onGo={onGo} />
        ))}
        <Pressable onPress={onClose} hitSlop={8} style={[styles.closeAt, { right: 16 * s, top: 14 * s }]}>
          {({ pressed }) => (
            <View style={{ transform: [{ translateY: pressed ? 3 : 0 }] }}>
              <View style={[styles.closeLip, { width: 42 * s, height: 42 * s, borderRadius: 21 * s, top: pressed ? 1 : 4 }]} />
              <View style={[styles.close, { width: 42 * s, height: 42 * s, borderRadius: 21 * s }]}>
                <Text style={[styles.closeText, { fontSize: 18 * s }]}>✕</Text>
              </View>
            </View>
          )}
        </Pressable>
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  wrap: { zIndex: 40, backgroundColor: '#9fd8f0', overflow: 'hidden' },
  grass: { position: 'absolute', left: 0, right: 0, bottom: 0, backgroundColor: '#9ed27e' },
  labels: { position: 'absolute', flexDirection: 'row', gap: 3 },
  name: { paddingVertical: 1, borderRadius: 999, backgroundColor: '#fff6e6', borderWidth: 2, borderColor: INK },
  nameText: { fontFamily: candyFonts.display, color: INK },
  count: { minWidth: 12, paddingVertical: 1, borderRadius: 999, backgroundColor: INK, borderWidth: 2, borderColor: INK, alignItems: 'center' },
  countText: { fontFamily: candyFonts.display, color: '#fff6e6' },
  flag: { paddingHorizontal: 7, paddingVertical: 1, borderRadius: 999, borderWidth: 2, borderColor: INK },
  flagText: { fontFamily: candyFonts.bodyBlack },
  faces: { position: 'absolute', left: 0, right: 0, flexDirection: 'row', justifyContent: 'center', alignItems: 'flex-end' },
  here: { position: 'absolute', paddingHorizontal: 7, paddingVertical: 1, borderRadius: 999, backgroundColor: '#ffd66b', borderWidth: 2, borderColor: INK },
  hereText: { fontFamily: candyFonts.bodyBlack, color: INK, letterSpacing: 0.5 },
  closeAt: { position: 'absolute' },
  closeLip: { position: 'absolute', left: 0, backgroundColor: INK },
  close: { backgroundColor: '#f2665a', borderWidth: 3, borderColor: INK, alignItems: 'center', justifyContent: 'center' },
  closeText: { fontFamily: candyFonts.bodyBlack, color: '#ffffff' },
});
