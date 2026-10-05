import React, { memo } from 'react';
import { StyleSheet, View } from 'react-native';
import Svg, { Circle, Defs, Mask, RadialGradient, Rect, Stop } from 'react-native-svg';
import { PH, SCENE_H, SCENE_W } from './data';

// The evening and the night over a room (the design's "nl" layer and its
// ph.overlay): the dark, with a soft hole around each lamp that's on and its
// coloured glow, then the time of day's tint over everything. `lights` are
// home.js's: [{ x, y, r, c: 'r,g,b' }] in scene units. The hatchery has no
// lamps and no dark, just the tint.

export const Night = memo(function Night({ phase, lights, dark = true, scale }) {
  const P = PH[phase] || PH.day;
  const w = SCENE_W * scale;
  const h = SCENE_H * scale;
  const L = dark && P.dark ? lights || [] : [];
  return (
    <>
      {dark && P.dark ? (
        <Svg pointerEvents="none" style={StyleSheet.absoluteFill} width={w} height={h} viewBox={`0 0 ${SCENE_W} ${SCENE_H}`}>
          <Defs>
            {L.map((l, i) => (
              <RadialGradient key={`h${i}`} id={`hole${i}`} cx={l.x} cy={l.y} r={l.r} gradientUnits="userSpaceOnUse">
                <Stop offset="0" stopColor="#000000" stopOpacity={1} />
                <Stop offset="0.35" stopColor="#000000" stopOpacity={1} />
                <Stop offset="1" stopColor="#000000" stopOpacity={0} />
              </RadialGradient>
            ))}
            {L.map((l, i) => (
              <RadialGradient key={`g${i}`} id={`glow${i}`} cx={l.x} cy={l.y} r={l.r} gradientUnits="userSpaceOnUse">
                <Stop offset="0" stopColor={`rgb(${l.c})`} stopOpacity={P.glow} />
                <Stop offset="1" stopColor={`rgb(${l.c})`} stopOpacity={0} />
              </RadialGradient>
            ))}
            {L.length ? (
              <Mask id="dark" maskUnits="userSpaceOnUse" x={0} y={0} width={SCENE_W} height={SCENE_H}>
                <Rect x={0} y={0} width={SCENE_W} height={SCENE_H} fill="#ffffff" />
                {L.map((l, i) => (
                  <Circle key={i} cx={l.x} cy={l.y} r={l.r} fill={`url(#hole${i})`} />
                ))}
              </Mask>
            ) : null}
          </Defs>
          <Rect x={0} y={0} width={SCENE_W} height={SCENE_H} fill={`rgb(${P.dark[0]},${P.dark[1]},${P.dark[2]})`} opacity={P.dark[3]} mask={L.length ? 'url(#dark)' : undefined} />
          {L.map((l, i) => (
            <Circle key={i} cx={l.x} cy={l.y} r={l.r} fill={`url(#glow${i})`} />
          ))}
        </Svg>
      ) : null}
      {P.tint ? <View pointerEvents="none" style={[StyleSheet.absoluteFill, { backgroundColor: P.tint }]} /> : null}
    </>
  );
});
