import React, { memo } from 'react';
import { Image, StyleSheet, View } from 'react-native';
import { ROOM_ART } from '../crib/roomArt';
import { PH } from '../crib/data';
import { ROOMS } from './levels';

// The room a Squish Hop level is played in (SQUISH_HOP.md): the Crib's room
// layers (src/crib/roomArt.js) scaled so the floor line sits about a third
// of the way down the screen, the room's things for the time of day down to
// that line (what stands on the floor is cut off there), and the floor
// repeated below it to the bottom of the screen, each copy under the one
// above; then the Crib's tint for the time of day.

const RATIO = 1704 / 786; // the room pictures' width / height

// where the floor line goes on a screen `height` tall
export const floorLineOf = (height) => Math.round(Math.min(330, Math.max(190, height * 0.32)));

export function roomGeometry(room, width, height) {
  const R = ROOMS[room];
  const floorY = floorLineOf(height);
  let H = floorY / R.floor;
  if (H * RATIO < width) H = width / RATIO;
  const W = H * RATIO;
  const left = Math.min(0, Math.max(width - W, width / 2 - R.cx * W));
  return { W, H, left, floorY: H * R.floor };
}

function Room({ room, phase, width, height }) {
  const R = ROOMS[room];
  const art = ROOM_ART[room];
  const { W, H, left } = roomGeometry(room, width, height);
  // the floor again and again below
  const step = H * (1 - R.floor) - H * 0.06;
  const copies = [];
  for (let k = 1; H + (k - 1) * step < height; k++) copies.push(H + (k - 1) * step - (R.floor + 0.05) * H);
  const under = art.under && art.under[phase];
  const over = art.over && art.over[phase];
  const img = (source, top, key) => <Image key={key} source={source} fadeDuration={0} style={{ position: 'absolute', left: 0, top, width: W, height: H }} />;
  const tint = PH[phase] && PH[phase].tint;
  return (
    <View pointerEvents="none" style={[StyleSheet.absoluteFill, { backgroundColor: R.bg, overflow: 'hidden' }]}>
      <View style={{ position: 'absolute', left, top: 0, width: W, height }}>
        {copies.reverse().map((top, k) => img(art.base, top, `f${k}`))}
        {under ? img(under, 0, 'under') : null}
        {img(art.base, 0, 'base')}
        {over ? <View style={{ position: 'absolute', left: 0, top: 0, width: W, height: H * (R.floor + 0.012), overflow: 'hidden' }}>{img(over, 0, 'over')}</View> : null}
      </View>
      {tint ? <View style={[StyleSheet.absoluteFill, { backgroundColor: tint }]} /> : null}
    </View>
  );
}

export default memo(Room);

// A room's little picture (the level map's band, over its banner): the room
// in daylight (or its first time of day), framed.
export const RoomCard = memo(function RoomCard({ room, width = 164, height = 96 }) {
  const R = ROOMS[room];
  const art = ROOM_ART[room];
  const W = height * RATIO;
  const left = Math.min(0, Math.max(width - W, width / 2 - R.cx * W));
  const phase = art.over.day ? 'day' : Object.keys(art.over)[0];
  const under = art.under && (art.under.day || Object.values(art.under)[0]);
  const over = phase ? art.over[phase] : null;
  const img = (source, key) => <Image key={key} source={source} fadeDuration={0} style={{ position: 'absolute', left, top: 0, width: W, height }} />;
  return (
    <View style={[styles.card, { width: width + 6, height: height + 6 }]}>
      <View style={{ width, height, borderRadius: 13, overflow: 'hidden', backgroundColor: R.bg }}>
        {under ? img(under, 'u') : null}
        {img(art.base, 'b')}
        {over ? img(over, 'o') : null}
      </View>
    </View>
  );
});

const styles = StyleSheet.create({
  card: { borderRadius: 16, borderWidth: 3, borderColor: '#ffffff', backgroundColor: '#ffffff', elevation: 3 },
});
