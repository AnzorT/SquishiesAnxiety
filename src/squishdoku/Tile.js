import React, { memo } from 'react';
import { StyleSheet, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';

// A board cell's candy button (the app's button look): a darker 3D base
// under a gradient face with a soft rim, a shine stripe and a sparkle. It
// fills its whole `size` × `size` cell, edge to edge with its neighbours (no
// gaps), its corners only slightly rounded. `children` go on the face
// (clipped to it: the board's flashes and the mistake's red glow). `patch`
// is a PATCHES entry: [base, face, light top].

export function tileBox(size) {
  const lip = Math.max(2, size * 0.07);
  return { m: 0, t: size, lip, radius: size * 0.14 };
}

function Tile({ size, patch, children }) {
  const { m, t, lip, radius } = tileBox(size);
  const small = size < 34;
  return (
    <>
      <View style={[styles.abs, { left: m, top: m, width: t, height: t, borderRadius: radius, backgroundColor: patch[0] }]} />
      <View style={[styles.abs, styles.face, { left: m, top: m, width: t, height: t - lip, borderRadius: radius, backgroundColor: patch[1] }]}>
        <LinearGradient colors={[patch[2], patch[1]]} locations={[0, 0.62]} style={StyleSheet.absoluteFill} />
        <View style={[StyleSheet.absoluteFill, { borderRadius: radius, borderWidth: Math.max(1, size * 0.022), borderColor: 'rgba(255,255,255,0.55)' }]} />
        <LinearGradient
          colors={['rgba(255,255,255,0.9)', 'rgba(255,255,255,0)']}
          style={[styles.abs, { left: '13%', right: '13%', top: '7%', height: '36%', borderRadius: radius * 0.8 }]}
        />
        {!small ? <View style={[styles.abs, styles.sparkle, { left: '17%', top: '13%', width: size * 0.1, height: size * 0.1, borderRadius: size }]} /> : null}
        {children}
      </View>
    </>
  );
}

const styles = StyleSheet.create({
  abs: { position: 'absolute' },
  face: { overflow: 'hidden' },
  sparkle: { backgroundColor: '#ffffff' },
});

export default memo(Tile);
