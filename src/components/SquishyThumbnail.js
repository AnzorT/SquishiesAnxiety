import React from 'react';
import { View, StyleSheet } from 'react-native';

// Flat 2D illustration of a squishy buddy — mirrors the blob placeholder
// drawn in the "Cute Squishies" reference (body fill, soft highlight,
// dark eyes, pink nose), built from plain Views so it needs no image asset.

export default function SquishyThumbnail({ colorHex, size = 180 }) {
  const eye = size * 0.07;
  const nose = size * 0.12;

  return (
    <View style={[styles.body, { width: size, height: size, borderRadius: size / 2, backgroundColor: colorHex }]}>
      <View
        style={[
          styles.highlight,
          {
            width: size * 0.34,
            height: size * 0.34,
            borderRadius: (size * 0.34) / 2,
            top: size * 0.14,
            left: size * 0.16,
          },
        ]}
      />
      <View style={[styles.eyeRow, { top: size * 0.42 }]}>
        <View style={[styles.eye, { width: eye, height: eye * 1.25, borderRadius: eye / 2, marginRight: size * 0.16 }]} />
        <View style={[styles.eye, { width: eye, height: eye * 1.25, borderRadius: eye / 2 }]} />
      </View>
      <View
        style={[
          styles.nose,
          {
            width: nose,
            height: nose,
            borderRadius: nose / 2,
            top: size * 0.56,
          },
        ]}
      />
    </View>
  );
}

const styles = StyleSheet.create({
  body: { alignItems: 'center', overflow: 'hidden' },
  highlight: { position: 'absolute', backgroundColor: 'rgba(255,255,255,0.55)' },
  eyeRow: { position: 'absolute', flexDirection: 'row' },
  eye: { backgroundColor: '#2B2333' },
  nose: { position: 'absolute', backgroundColor: '#F4A6C0' },
});
