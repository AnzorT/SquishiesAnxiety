import React from 'react';
import { View, Text, StyleSheet } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { LinearGradient } from 'expo-linear-gradient';
import { candyFonts } from '../theme/candyTheme';
import AdBanner from './AdBanner';

// The banner ad strip at the bottom of Home and Squish: full width, flush
// with the bottom edge (it runs under the gesture bar too). The app shell's
// look (2026-10-08): a dark purple 60px bar holding a pastel rounded card
// with a white rim and an "AD" tag; the card shows "ADVERTISEMENT" until
// the real banner loads over it (the shell's made-up cross-promo ads are
// left out). Above the bottom nav (MainScreen) it isn't the bottom edge:
// `inset={false}`.
export const AD_H = 60;

export default function AdStrip({ inset = true, style }) {
  const insets = useSafeAreaInsets();
  return (
    <View style={[styles.bar, style, { paddingBottom: inset ? insets.bottom : 0 }]}>
      <View style={styles.slot}>
        <View style={styles.cardLip} pointerEvents="none">
          <LinearGradient colors={['#fff3b0', '#ffe0f5', '#e8dcff']} locations={[0, 0.55, 1]} start={{ x: 0, y: 0 }} end={{ x: 1, y: 0 }} style={styles.card}>
            <Text style={styles.label}>ADVERTISEMENT</Text>
            <Text style={styles.tag}>AD</Text>
          </LinearGradient>
        </View>
        <AdBanner />
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  bar: { width: '100%', backgroundColor: '#2a0f4a' },
  slot: { minHeight: AD_H, justifyContent: 'center', alignItems: 'center' },
  // the card: 48px, a 2px white rim and a 3px lilac lip
  cardLip: { position: 'absolute', left: 8, right: 8, top: 4, height: 55, borderRadius: 16, backgroundColor: '#c3a6e8' },
  card: { height: 52, borderRadius: 16, borderWidth: 2, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  label: { color: '#8a6aa6', fontFamily: candyFonts.displaySemi, fontSize: 11, letterSpacing: 2 },
  tag: { position: 'absolute', left: 5, top: 2, paddingHorizontal: 3, borderRadius: 4, overflow: 'hidden', backgroundColor: 'rgba(255,255,255,0.8)', color: '#8a6aa6', fontFamily: candyFonts.bodyBlack, fontSize: 8, letterSpacing: 0.8 },
});
