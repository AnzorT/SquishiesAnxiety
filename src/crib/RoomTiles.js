import React, { memo } from 'react';
import { Image, Pressable, StyleSheet, Text, View } from 'react-native';
import Svg, { Path, SvgXml } from 'react-native-svg';
import CreatureThumbnail from '../components/CreatureThumbnail';
import { candyFonts } from '../theme/candyTheme';
import { ROOMS, ROOM_ORDER } from './data';
import { INK } from './ui';
import { LevelPill, PhasePill } from './Hud';
import { ATTIC_SVG } from './attic';

// The vertical page's room dock (the design's <!-- ROOM DOCK --> in "Squad
// Crib Vertical"): wooden planks under a tilted "ROOMS" sign, the time of
// day and the level, and the rooms as tiles — each room's own wall and
// floor (the design's DOCK_BG, rendered by tools/crib-art/map.mjs), up to
// three of the friends in it, its name and how many are there, a red badge
// for who needs something, and a gold frame with HERE on the one you're in.
//
// `summary`: { [room]: { pets: [creature…], count, busy, needs, eggs } }

const BG = {
  living: require('../../assets/crib/dock/living.webp'),
  kitchen: require('../../assets/crib/dock/kitchen.webp'),
  bath: require('../../assets/crib/dock/bath.webp'),
  bed: require('../../assets/crib/dock/bed.webp'),
  dance: require('../../assets/crib/dock/dance.webp'),
  yard: require('../../assets/crib/dock/yard.webp'),
};
const WOOD = require('../../assets/crib/dock/wood.webp');
export const TILE_H = 118;

const EGG = 'M19 2C9 2 2 18 2 30c0 9.5 7.6 16 17 16s17-6.5 17-16C36 18 29 2 19 2z';
function Eggs() {
  return (
    <View style={styles.eggs}>
      {['#ffb3c7', '#9fd8f0', '#ffd66b'].map((c) => (
        <Svg key={c} width={20} height={25} viewBox="0 0 38 48">
          <Path d={EGG} fill={c} stroke={INK} strokeWidth={3} />
        </Svg>
      ))}
    </View>
  );
}

const Tile = memo(function Tile({ room, info, here, onGo, height, span }) {
  const name = room === 'hatch' ? 'Hatchery' : ROOMS[room].name;
  const count = room === 'hatch' ? `${info.eggs} eggs` : `${info.count} here`;
  return (
    <Pressable onPress={() => onGo(room)} style={[styles.cell, span === 2 && styles.cell2]}>
      {({ pressed }) => (
        <View style={[styles.tile, { height, transform: [{ translateY: pressed ? 3 : 0 }] }]}>
          <View style={StyleSheet.absoluteFill}>
            {room === 'hatch' ? (
              // the attic (attic.js), its window and rafters in view
              <SvgXml xml={ATTIC_SVG} width={360} height={166} style={{ position: 'absolute', left: -86, top: -22 }} />
            ) : (
              <Image source={BG[room]} fadeDuration={0} style={{ width: 400, height: TILE_H, position: 'absolute', left: 0, bottom: 0 }} />
            )}
          </View>
          <View style={styles.faces}>
            {room === 'hatch' ? (
              <Eggs />
            ) : (
              info.pets.slice(0, 3).map((c) => (
                <View key={c.id} style={{ marginHorizontal: -5 }}>
                  <CreatureThumbnail creature={c} size={32} animate={false} />
                </View>
              ))
            )}
          </View>
          <View style={styles.name}>
            <Text style={styles.nameText} numberOfLines={1} adjustsFontSizeToFit minimumFontScale={0.75}>
              {name}
            </Text>
          </View>
          <View style={styles.count}>
            <Text style={styles.countText} numberOfLines={1}>
              {count}
            </Text>
          </View>
          {info.needs ? (
            <View style={styles.needs}>
              <Text style={styles.needsText}>{info.needs}</Text>
            </View>
          ) : null}
          {here ? (
            <>
              <View pointerEvents="none" style={styles.hereFrame} />
              <View style={styles.here}>
                <Text style={styles.hereText}>HERE</Text>
              </View>
            </>
          ) : null}
        </View>
      )}
    </Pressable>
  );
});

export function RoomGrid({ summary, current, onGo, height = TILE_H }) {
  return (
    <View style={styles.grid}>
      {ROOM_ORDER.map((room) => (
        <Tile key={room} room={room} info={summary[room]} here={current === room} onGo={onGo} height={height} span={room === 'hatch' ? 2 : 1} />
      ))}
    </View>
  );
}

// the whole dock: planks, the sign, the pills, the tiles
export default function RoomDock({ summary, current, onGo, phase, level, tileH = TILE_H, bottomPad = 0 }) {
  return (
    <View style={[styles.dock, { paddingBottom: 20 + bottomPad }]}>
      <Image source={WOOD} resizeMode="repeat" style={StyleSheet.absoluteFill} />
      <View pointerEvents="none" style={styles.shade} />
      <View style={styles.head}>
        <View style={styles.signLip}>
          <View style={styles.sign}>
            <Text style={styles.signText}>ROOMS</Text>
          </View>
        </View>
        <View style={{ flex: 1 }} />
        <PhasePill sun={phase.sun} label={phase.label} />
        <LevelPill level={level} />
      </View>
      <RoomGrid summary={summary} current={current} onGo={onGo} height={tileH} />
    </View>
  );
}

const styles = StyleSheet.create({
  dock: { flex: 1, paddingHorizontal: 12, paddingTop: 14, gap: 12, borderTopWidth: 4, borderTopColor: INK, marginTop: -4, overflow: 'hidden', backgroundColor: '#e2a868' },
  shade: { position: 'absolute', left: 0, right: 0, top: 0, height: 24, backgroundColor: 'rgba(60,30,10,0.12)' },
  head: { flexDirection: 'row', alignItems: 'center', gap: 6 },
  signLip: { borderRadius: 12, paddingBottom: 3, backgroundColor: INK, transform: [{ rotate: '-2deg' }] },
  sign: { paddingHorizontal: 14, paddingVertical: 2, borderRadius: 12, borderWidth: 3, borderColor: INK, backgroundColor: '#d99a5b' },
  signText: { fontFamily: candyFonts.display, fontSize: 18, color: '#fff6e6', textShadowColor: INK, textShadowRadius: 0.5, textShadowOffset: { width: 0, height: 2 } },
  grid: { flexDirection: 'row', flexWrap: 'wrap', marginHorizontal: -4, rowGap: 10 },
  cell: { width: '25%', paddingHorizontal: 4 },
  cell2: { width: '50%' },
  tile: { borderRadius: 14, borderWidth: 3, borderColor: INK, overflow: 'hidden', alignItems: 'center', justifyContent: 'flex-end', paddingBottom: 8, gap: 5, backgroundColor: '#fff6e6', shadowColor: INK, elevation: 0 },
  faces: { height: 34, flexDirection: 'row', justifyContent: 'center', alignItems: 'flex-end' },
  eggs: { flexDirection: 'row', gap: 4, alignItems: 'flex-end' },
  name: { paddingHorizontal: 6, paddingVertical: 1, borderRadius: 999, backgroundColor: '#fff6e6', borderWidth: 2, borderColor: INK, maxWidth: '94%' },
  nameText: { fontFamily: candyFonts.display, fontSize: 12, color: INK },
  count: { paddingHorizontal: 7, borderRadius: 999, backgroundColor: INK },
  countText: { fontFamily: candyFonts.display, fontSize: 11, color: '#fff6e6' },
  needs: { position: 'absolute', right: 5, top: 5, minWidth: 20, height: 20, paddingHorizontal: 4, borderRadius: 10, backgroundColor: '#f2665a', borderWidth: 2, borderColor: INK, alignItems: 'center', justifyContent: 'center' },
  needsText: { fontFamily: candyFonts.bodyBlack, fontSize: 11, color: '#ffffff', lineHeight: 14 },
  hereFrame: { ...StyleSheet.absoluteFillObject, borderRadius: 11, borderWidth: 4, borderColor: '#ffd66b' },
  here: { position: 'absolute', left: 5, top: 5, paddingHorizontal: 6, paddingVertical: 1, borderRadius: 999, backgroundColor: '#ffd66b', borderWidth: 2, borderColor: INK },
  hereText: { fontFamily: candyFonts.bodyBlack, fontSize: 9, color: INK, letterSpacing: 0.5 },
});
