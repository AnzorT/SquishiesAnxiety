import React, { memo } from 'react';
import { Image, StyleSheet, View } from 'react-native';
import { FACE } from './cushions';

// A board cell's plush cushion (since 2026-10-28; it was a glossy candy
// button, which didn't match the plush creatures): a picture per patch
// colour (tools/squishdoku/cushions.mjs: puffy shading, the rigs' fabric
// grain, a soft shadow) filling its whole `size` × `size`
// cell; the gaps round the cushions are the quilt's seams. `children` go on
// the cushion, clipped to its shape (the board's flashes and the mistake's
// red glow). `patch` is a PATCHES entry: { name, shade, src }.

// where the cushion sits in its cell (lip: what's under it, for centring
// the creature on it)
export function tileBox(size) {
  return { left: size * FACE.left, top: size * FACE.top, right: size * FACE.right, bottom: size * FACE.bottom, lip: size * FACE.bottom, radius: size * FACE.radius };
}

function Tile({ size, patch, children }) {
  const b = tileBox(size);
  return (
    <>
      <Image source={patch.src} style={[styles.abs, { left: 0, top: 0, width: size, height: size }]} fadeDuration={0} />
      {children ? (
        <View style={[styles.abs, styles.face, { left: b.left, top: b.top, right: b.right, bottom: b.bottom, borderRadius: b.radius }]}>{children}</View>
      ) : null}
    </>
  );
}

const styles = StyleSheet.create({
  abs: { position: 'absolute' },
  face: { overflow: 'hidden' },
});

export default memo(Tile);
