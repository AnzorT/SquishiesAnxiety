import React, { memo } from 'react';
import { Image, View } from 'react-native';
import { SvgXml } from 'react-native-svg';
import { CEIL_H, FLOOR_TOP, ROOM_ART, THEMES as DESIGN_THEMES, WALL_H } from './roomArt';
import { FIXTURE_ART } from './fixtureArt';
import { FIXTURE_GEO } from './fixtureGeo';
import { SCENE_H, SCENE_W } from './data';
import { themeOf } from './home';
import { ATTIC_SVG } from './attic';

// The Crib's art: the rooms (the design's CSS rooms, rendered in layers by
// tools/crib-art/render.mjs — see roomArt.js) with the player's wall, floor
// and ceiling slid in between, and the furniture pieces (SVG strings from
// the catalogue, or pictures cut out of the design by
// tools/crib-art/fixtures.mjs), drawn where the player put them.
//
// The rooms with fixtures start bare: their built-in fixtures are decor now
// (home.js), so the design's "over" picture isn't drawn; the room's wall
// trim (wainscoting, tile bands, baseboards) is, but only with the design's
// own wallpapers — the bare plaster and the luxe wall have none.

const pick = (byPhase, phase) => (byPhase ? byPhase[phase] || byPhase.day || Object.values(byPhase)[0] || null : null);
// a cut-out picture by name ('kitchen.table'), for the time of day if it has one
export const artImage = (name, phase = 'day') => {
  const a = FIXTURE_ART[name];
  if (!a) return null;
  return typeof a === 'number' || a.uri ? a : pick(a, phase);
};

function Layer({ source, top = 0, height = SCENE_H, scale }) {
  if (!source) return null;
  return <Image source={source} fadeDuration={0} resizeMode="stretch" style={{ position: 'absolute', left: 0, top: top * scale, width: SCENE_W * scale, height: height * scale }} />;
}

// a wall / floor / ceiling: the design's picture, or this app's SVG
function Theme({ room, kind, theme, top, height, scale }) {
  if (!theme) return null;
  if (theme.svg) {
    return (
      <View pointerEvents="none" style={{ position: 'absolute', left: 0, top: top * scale, width: SCENE_W * scale, height: height * scale }}>
        <SvgXml xml={theme.svg(SCENE_W, height)} width={SCENE_W * scale} height={height * scale} />
      </View>
    );
  }
  const list = DESIGN_THEMES[room] && DESIGN_THEMES[room][kind];
  const t = list && list[theme.design];
  return t && t.img ? <Layer source={t.img} top={top} height={height} scale={scale} /> : null;
}

// A room up to its furniture: what's behind (the yard's sky), its wall and
// floor (or the player's over them), the trim, and — in the rooms without
// fixtures — what the design draws on top.
export const RoomBackdrop = memo(function RoomBackdrop({ room, phase, home, scale }) {
  // the hatchery is the attic (attic.js)
  if (room === 'hatch') {
    return (
      <View pointerEvents="none" style={{ position: 'absolute', left: 0, top: 0, width: SCENE_W * scale, height: SCENE_H * scale }}>
        <SvgXml xml={ATTIC_SVG} width={SCENE_W * scale} height={SCENE_H * scale} />
      </View>
    );
  }
  const art = ROOM_ART[room] || ROOM_ART.living;
  const geo = FIXTURE_GEO[room];
  const wall = themeOf(home, room, 'wall');
  const floor = themeOf(home, room, 'floor');
  const ceil = themeOf(home, room, 'ceil');
  // the design's wallpapers (not the bare or the luxe one) come with the trim
  const trim = geo && wall && wall.design != null;
  return (
    <>
      <Layer source={pick(art.under, phase)} scale={scale} />
      <Layer source={art.base} scale={scale} />
      <Theme room={room} kind="wall" theme={wall} top={0} height={WALL_H[room]} scale={scale} />
      <Theme room={room} kind="ceil" theme={ceil} top={0} height={CEIL_H} scale={scale} />
      <Theme room={room} kind="floor" theme={floor} top={FLOOR_TOP[room]} height={SCENE_H - FLOOR_TOP[room]} scale={scale} />
      {trim ? (
        <Image source={artImage(`${room}.trim`)} fadeDuration={0} resizeMode="stretch" style={{ position: 'absolute', left: geo.trim.x * scale, top: geo.trim.y * scale, width: geo.trim.w * scale, height: geo.trim.h * scale }} />
      ) : null}
      {geo ? null : <Layer source={pick(art.over, phase)} scale={scale} />}
    </>
  );
});

// What the design draws in front of the creatures in rooms without fixtures
// (the kitchen's table is the table slot now).
export function RoomFront({ room, scale }) {
  const art = ROOM_ART[room];
  return art && art.front && !FIXTURE_GEO[room] ? <Layer source={art.front} scale={scale} /> : null;
}

// a wall / floor / ceiling's swatch for the edit panel and the shop
export function ThemeSwatch({ room, kind, theme, width, height }) {
  if (!theme) return null;
  if (theme.svg) {
    // a slice of the left of it, at the room's scale
    const k = (width * 3) / SCENE_W;
    const h = kind === 'wall' ? WALL_H[room] || 200 : kind === 'floor' ? SCENE_H - (FLOOR_TOP[room] || 200) : CEIL_H;
    return (
      <View style={{ width, height, overflow: 'hidden', borderRadius: 6 }}>
        <SvgXml xml={theme.svg(SCENE_W, h)} width={SCENE_W * k} height={h * k} />
      </View>
    );
  }
  const list = DESIGN_THEMES[room] && DESIGN_THEMES[room][kind];
  const img = list && list[theme.design] && list[theme.design].img;
  if (!img) {
    // the room's own (no overlay): a bit of its base picture
    const base = (ROOM_ART[room] || {}).base;
    const top = kind === 'floor' ? FLOOR_TOP[room] || 200 : 0;
    const k = (width * 3) / SCENE_W;
    return (
      <View style={{ width, height, overflow: 'hidden', borderRadius: 6, backgroundColor: kind === 'ceil' ? '#efe4d4' : '#f6e7cf' }}>
        {base ? <Image source={base} fadeDuration={0} resizeMode="stretch" style={{ position: 'absolute', left: 0, top: -top * k, width: SCENE_W * k, height: SCENE_H * k }} /> : null}
      </View>
    );
  }
  const src = Image.resolveAssetSource(img);
  const ratio = src && src.width ? src.height / src.width : 0.25;
  return (
    <View style={{ width, height, overflow: 'hidden', borderRadius: 6 }}>
      <Image source={img} fadeDuration={0} resizeMode="stretch" style={{ width: width * 3, height: width * 3 * ratio }} />
    </View>
  );
}

// A furniture piece: { svg | art, x, y, w, h, tf } in scene units. (Always
// a transform list: a piece that loses its mirroring otherwise hands React
// Native a null transform, which throws.)
const MIRROR = [{ scaleX: -1 }];
const NO_TF = [];
export const Piece = memo(function Piece({ art, scale, phase }) {
  if (!art || (!art.svg && !art.art)) return null;
  const w = art.w * scale;
  const h = art.h * scale;
  return (
    <View pointerEvents="none" style={{ position: 'absolute', left: art.x * scale, top: art.y * scale, width: w, height: h, transform: art.tf === 'scaleX(-1)' ? MIRROR : NO_TF }}>
      {art.svg ? <SvgXml xml={art.svg} width={w} height={h} /> : <Image source={artImage(art.art, phase)} fadeDuration={0} resizeMode="stretch" style={{ width: w, height: h }} />}
    </View>
  );
});

// an item's picture fitted inside w×h (an SVG icon, or a cut-out picture)
export function ItemArt({ svg, art, aspect = 1, w, h, phase }) {
  if (svg) {
    const m = svg.match(/viewBox="([-\d.\s]+)"/);
    const [, , vw, vh] = m ? m[1].trim().split(/\s+/).map(Number) : [0, 0, 1, 1];
    const a = vw && vh ? vw / vh : 1;
    const fw = Math.min(w, h * a);
    return (
      <View style={{ width: fw, height: fw / a }}>
        <SvgXml xml={svg} width={fw} height={fw / a} />
      </View>
    );
  }
  if (!art) return null;
  const fw = Math.min(w, h * aspect);
  return <Image source={artImage(art, phase)} fadeDuration={0} resizeMode="contain" style={{ width: fw, height: fw / aspect }} />;
}
