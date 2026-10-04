import React from 'react';
import { View, Text, StyleSheet } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { candyFonts } from '../theme/candyTheme';
import AdBanner from './AdBanner';

// The banner ad strip at the bottom of Home and Squish: full width, flush
// with the bottom edge (it runs under the gesture bar too), with an
// "ADVERTISEMENT" caption behind the banner until the ad loads.
export const AD_H = 60;

export default function AdStrip() {
  const insets = useSafeAreaInsets();
  return (
    <View style={[styles.bar, { paddingBottom: insets.bottom }]}>
      <View style={styles.slot}>
        <View style={styles.labelWrap} pointerEvents="none">
          <Text style={styles.label}>ADVERTISEMENT</Text>
        </View>
        <AdBanner />
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  bar: {
    width: '100%',
    backgroundColor: 'rgba(80,12,140,0.4)',
    borderTopWidth: 2,
    borderColor: 'rgba(255,255,255,0.85)',
  },
  slot: { minHeight: AD_H, justifyContent: 'center' },
  labelWrap: {
    ...StyleSheet.absoluteFillObject,
    alignItems: 'center',
    justifyContent: 'center',
  },
  label: {
    color: 'rgba(255,255,255,0.85)',
    fontFamily: candyFonts.displaySemi,
    fontSize: 11,
    letterSpacing: 2,
  },
});
