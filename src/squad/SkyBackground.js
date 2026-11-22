import React, { memo, useState } from 'react';
import { View, Image, StyleSheet } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';

// The squish screen's sky from "ASMR Creature Squash v5": blue at the top
// fading through sand to peach, a warm glow rising from the bottom (REDESIGN_V8: no pink), a
// soft white glow behind the toy, three cloud puffs and a white dot grid
// every 26px.
//
// PERF 2026-11-20: native pieces, not one full-screen react-native-svg. The
// SVG was painted in software on the UI thread (65 ms on the Galaxy A16, more
// on older phones) every time the stage came up, which froze the loading beat
// over it. Now: a native linear gradient, the glows and puffs as small white
// radial bitmaps scaled and tinted (assets/squad/sky/make-sky.mjs), and the
// dots as blocks of the grid laid edge to edge. The whole sky is one hardware layer, so the 3D
// stage's frames only blit it.
//
// The CSS radial gradients size themselves from the box ("farthest-corner"),
// so the radii are worked out here from the measured size.

const GLOW = require('../../assets/squad/sky/glow.png');
const PUFF = require('../../assets/squad/sky/puff.png');
// a 10 × 5 block of the 26 dp dot grid, laid out edge to edge (resizeMode repeat drew a single tile on Android)
const DOTS = require('../../assets/squad/sky/dotgrid.png');
const DOTS_W = 260;
const DOTS_H = 130;

const PUFFS = [
  { x: 0.16, y: 0.14, fade: 44, a: 0.75 },
  { x: 0.26, y: 0.12, fade: 36, a: 0.7 },
  { x: 0.84, y: 0.26, fade: 38, a: 0.6 },
];

const blob = (cx, cy, rx, ry) => ({ position: 'absolute', left: cx - rx, top: cy - ry, width: rx * 2, height: ry * 2 });

const Sky = memo(function Sky({ width: w, height: h }) {
  // circle at 50% 46%, transparent at 48% of the farthest-corner radius
  const glowR = 0.48 * Math.hypot(w / 2, h * 0.54);
  // ellipse at 50% 112%: farthest-corner radii are √2 × the side distances
  const pinkRx = 0.62 * Math.SQRT2 * (w / 2);
  const pinkRy = 0.62 * Math.SQRT2 * (h * 1.12);
  return (
    <View style={StyleSheet.absoluteFill} pointerEvents="none" renderToHardwareTextureAndroid>
      <LinearGradient colors={SKY} locations={SKY_AT} style={StyleSheet.absoluteFill} />
      <Image source={GLOW} fadeDuration={0} style={[blob(w / 2, h * 0.46, glowR, glowR), { opacity: 0.55 }]} />
      <Image source={GLOW} fadeDuration={0} tintColor="#ffab5c" style={[blob(w / 2, h * 1.12, pinkRx, pinkRy), { opacity: 0.6 }]} />
      {PUFFS.map((p, i) => (
        <Image key={i} source={PUFF} fadeDuration={0} style={[blob(w * p.x, h * p.y, p.fade, p.fade), { opacity: p.a }]} />
      ))}
      {dotBlocks(w, h).map((b) => (
        <Image key={b.key} source={DOTS} fadeDuration={0} style={b.style} />
      ))}
    </View>
  );
});

function dotBlocks(w, h) {
  const out = [];
  for (let y = 0; y < h; y += DOTS_H) {
    for (let x = 0; x < w; x += DOTS_W) {
      out.push({ key: `${x},${y}`, style: { position: 'absolute', left: x, top: y, width: DOTS_W, height: DOTS_H } });
    }
  }
  return out;
}

const SKY = ['#8fd0ff', '#b9e2ff', '#f3e6d6', '#ffdcb4'];
const SKY_AT = [0, 0.38, 0.68, 1];

export default function SkyBackground({ children, style }) {
  const [size, setSize] = useState(null);
  return (
    <View
      style={[styles.fill, style]}
      onLayout={(e) => {
        const { width, height } = e.nativeEvent.layout;
        // 0 × 0 is a hidden screen (display: none): keep the real size
        if (!width || !height) return;
        if (!size || size.width !== width || size.height !== height) setSize({ width, height });
      }}
    >
      {size ? <Sky width={size.width} height={size.height} /> : null}
      {children}
    </View>
  );
}

const styles = StyleSheet.create({
  fill: { flex: 1, backgroundColor: '#c9e4ff', overflow: 'hidden' },
});
