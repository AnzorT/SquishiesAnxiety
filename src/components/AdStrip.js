import React, { useEffect, useState } from 'react';
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
// `inset={false}`. `live={false}` keeps the strip's look but no real banner
// (Home kept alive under another screen doesn't hold an ad nobody can see).
// A real banner is a native ad view (a web view of its own) that costs the
// UI thread a few frames to make, so it comes LIVE_AFTER ms after the strip
// goes live: not in the middle of the slide back to Home (it was a 0.3 s
// stall right as Home showed, Galaxy A15 debug build, 2026-10-28).
// `large`: a 320×100 large banner instead of the ~50px adaptive one (the
// main screen's, user 2026-10-28: "increase the size of the ad"), in a white
// frame cut to the banner's size: on the full-width card it sat in the
// middle with the card's ends and AD tag showing beside it ("not sitting
// well", 2026-10-28). The frame's corners are only as round as its padding
// allows, so the banner's square corners never poke through them.
export const AD_H = 60;
const AD_H_LARGE = 118;
const LIVE_AFTER = 700;

export default function AdStrip({ inset = true, live = true, large = false, style }) {
  const insets = useSafeAreaInsets();
  const [on, setOn] = useState(false);
  useEffect(() => {
    if (!live) {
      setOn(false);
      return undefined;
    }
    const t = setTimeout(() => setOn(true), LIVE_AFTER);
    return () => clearTimeout(t);
  }, [live]);
  const card = (
    <LinearGradient colors={['#fff3b0', '#ffe0f5', '#e8dcff']} locations={[0, 0.55, 1]} start={{ x: 0, y: 0 }} end={{ x: 1, y: 0 }} style={large ? styles.cardLarge : styles.card}>
      <Text style={styles.label}>ADVERTISEMENT</Text>
      <Text style={styles.tag}>AD</Text>
    </LinearGradient>
  );
  return (
    <View style={[styles.bar, style, { paddingBottom: inset ? insets.bottom : 0 }]}>
      {large ? (
        <View style={[styles.slot, styles.slotLarge]}>
          <View style={styles.frameLip}>
            <View style={styles.frame}>
              {card}
              {on ? (
                <View style={styles.frameAd}>
                  <AdBanner large />
                </View>
              ) : null}
            </View>
          </View>
        </View>
      ) : (
        <View style={styles.slot}>
          <View style={styles.cardLip} pointerEvents="none">
            {card}
          </View>
          {on ? <AdBanner /> : null}
        </View>
      )}
    </View>
  );
}

const styles = StyleSheet.create({
  bar: { width: '100%', backgroundColor: '#2a0f4a' },
  slot: { minHeight: AD_H, justifyContent: 'center', alignItems: 'center' },
  slotLarge: { minHeight: AD_H_LARGE },
  // the card: 48px, a 2px white rim and a 3px lilac lip
  cardLip: { position: 'absolute', left: 8, right: 8, top: 4, height: 55, borderRadius: 16, backgroundColor: '#c3a6e8' },
  card: { height: 52, borderRadius: 16, borderWidth: 2, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  // the large banner's: a 4px white frame (10px corners) round the 320×100
  // card, a 3px lilac lip, the banner over the card
  frameLip: { borderRadius: 10, paddingBottom: 3, backgroundColor: '#c3a6e8' },
  frame: { padding: 4, borderRadius: 10, backgroundColor: '#ffffff' },
  cardLarge: { width: 320, height: 100, borderRadius: 6, alignItems: 'center', justifyContent: 'center' },
  frameAd: { position: 'absolute', left: 4, top: 4, width: 320, height: 100, overflow: 'hidden' },
  label: { color: '#8a6aa6', fontFamily: candyFonts.displaySemi, fontSize: 11, letterSpacing: 2 },
  tag: { position: 'absolute', left: 5, top: 2, paddingHorizontal: 3, borderRadius: 4, overflow: 'hidden', backgroundColor: 'rgba(255,255,255,0.8)', color: '#8a6aa6', fontFamily: candyFonts.bodyBlack, fontSize: 8, letterSpacing: 0.8 },
});
