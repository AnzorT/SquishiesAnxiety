import React, { memo, useEffect, useRef } from 'react';
import { Animated, Easing, Pressable, StyleSheet, Text, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { BUTTON_VARIANTS, candyColors, candyFonts } from '../theme/candyTheme';
import CandyPopup from './candy/CandyPopup';
import CandyButton, { ButtonText, Shine } from './candy/CandyButton';
import ShineSweep from './candy/ShineSweep';
import OutlinedTitle from './candy/OutlinedTitle';
import sfx from '../audio/sfx';

// Remove Ads ($1.99, one-time — src/billing): the "no ads" candy badge, the
// floating button on Home's lists that offers it, and the popup that says
// what it does and sells it. With it bought (`adsFree`), the app shows no
// banner and no ad breaks, the day's two Mystery Boxes open free without
// their videos, and the squish screen's ×2/×3/×4 boosts start without one.

// A candy "no" sign: "AD" in pink on a white-pink face, under a red ring
// and slash, all inside a white rim and a pink ring.
export function NoAdsIcon({ size = 40 }) {
  const stroke = Math.max(2, Math.round(size * 0.085));
  const inner = size - 6; // inside the 1.5px ring + 1.5px rim
  return (
    <View style={[styles.iconRing, { width: size, height: size, borderRadius: size / 2 }]}>
      <LinearGradient colors={['#ffffff', '#ffe1f3']} style={[styles.iconFace, { borderRadius: size / 2 }]}>
        <Text style={[styles.iconText, { fontSize: Math.round(size * 0.34), lineHeight: Math.round(size * 0.4) }]}>AD</Text>
        <View style={[styles.noRing, { borderRadius: inner / 2, borderWidth: stroke }]} />
        <View style={[styles.noSlash, { width: inner - stroke, height: stroke, borderRadius: stroke }]} />
      </LinearGradient>
    </View>
  );
}

const PERKS = ['No ad banner, no ad breaks', '2 free Mystery Boxes every day', '×2 ×3 ×4 boosts without videos'];

// memoized: it re-rendered with App on every screen change
export const RemoveAdsSheet = memo(function RemoveAdsSheet({ visible, adsFree, price, buying, onBuy, onClose }) {
  return (
    <CandyPopup visible={visible} onClose={onClose}>
      <NoAdsIcon size={70} />
      <OutlinedTitle text={adsFree ? 'NO MORE ADS!' : 'REMOVE ADS'} fill="gold" size={28} style={styles.title} />
      <Text style={styles.lead}>{adsFree ? 'Thanks for supporting Squish Squad!' : 'One payment, and the ads are gone for good'}</Text>
      <View style={styles.perks}>
        {PERKS.map((p) => (
          <View key={p} style={styles.perk}>
            <View style={styles.tick}>
              <LinearGradient colors={BUTTON_VARIANTS.blue.colors} locations={BUTTON_VARIANTS.blue.locations} style={styles.tickFace}>
                <ButtonText ring={BUTTON_VARIANTS.blue.ring} size={11}>
                  ✓
                </ButtonText>
              </LinearGradient>
            </View>
            <Text style={styles.perkText}>{p}</Text>
          </View>
        ))}
      </View>
      {adsFree ? (
        <CandyButton label="YAY!" variant="blue" size="md" onPress={onClose} style={styles.buy} />
      ) : (
        <CandyButton variant="gold" size="lg" pulse="soft" loading={buying} onPress={onBuy} style={styles.buy} faceStyle={styles.buyFace}>
          <ShineSweep />
          <View style={styles.buyRow}>
            <ButtonText ring={BUTTON_VARIANTS.gold.ring} size={18}>
              REMOVE ADS
            </ButtonText>
            <View style={styles.buyDivider} />
            <ButtonText ring={BUTTON_VARIANTS.gold.ring} size={18}>
              {price}
            </ButtonText>
          </View>
        </CandyButton>
      )}
      {adsFree ? null : <Text style={styles.small}>One-time purchase · comes back on any phone you sign in on</Text>}
    </CandyPopup>
  );
});

// The floating offer on Home's lists: a gold candy pill — the no-ads badge,
// "NO ADS", and a white price tag — bobbing gently in the corner under the
// cards, with a light streak running across it.
export const RemoveAdsButton = memo(function RemoveAdsButton({ price, onPress, style }) {
  const bob = useRef(new Animated.Value(0)).current;
  const press = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(bob, { toValue: 1, duration: 1200, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
        Animated.timing(bob, { toValue: 0, duration: 1200, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
      ])
    );
    loop.start();
    return () => loop.stop();
  }, [bob]);
  const translateY = Animated.add(
    bob.interpolate({ inputRange: [0, 1], outputRange: [0, -5] }),
    press.interpolate({ inputRange: [0, 1], outputRange: [0, 3] })
  );
  const rotate = bob.interpolate({ inputRange: [0, 1], outputRange: ['-2deg', '2deg'] });
  const sink = (to) => Animated.timing(press, { toValue: to, duration: 80, useNativeDriver: true }).start();
  const gold = BUTTON_VARIANTS.gold;
  return (
    <Animated.View style={[style, { transform: [{ translateY }, { rotate }] }]}>
      <Pressable
        onPress={onPress}
        onPressIn={() => {
          sink(1);
          sfx.play('tap');
        }}
        onPressOut={() => sink(0)}
        hitSlop={8}
        accessibilityRole="button"
        accessibilityLabel={`Remove ads for ${price}`}
      >
        <View style={[styles.fabLip, { backgroundColor: gold.ring }]}>
          <View style={[styles.fabRing, { backgroundColor: gold.ring }]}>
            <LinearGradient colors={gold.colors} locations={gold.locations} style={styles.fabFace}>
              <Shine />
              <ShineSweep />
              <NoAdsIcon size={26} />
              <ButtonText ring={gold.ring} size={13} style={styles.fabLabel}>
                NO ADS
              </ButtonText>
              <View style={styles.tag}>
                <Text style={styles.tagText}>{price}</Text>
              </View>
            </LinearGradient>
          </View>
        </View>
      </Pressable>
    </Animated.View>
  );
});

const styles = StyleSheet.create({
  iconRing: { backgroundColor: BUTTON_VARIANTS.pink.ring, padding: 1.5 },
  iconFace: { flex: 1, borderWidth: 1.5, borderColor: '#ffffff', overflow: 'hidden', alignItems: 'center', justifyContent: 'center' },
  iconText: { color: '#ff3ea5', fontFamily: candyFonts.display, includeFontPadding: false, letterSpacing: 0.3 },
  noRing: { ...StyleSheet.absoluteFillObject, borderColor: '#e5484d' },
  noSlash: { position: 'absolute', backgroundColor: '#e5484d', transform: [{ rotate: '-45deg' }] },

  title: { marginTop: 8 },
  lead: { color: candyColors.inkSoft, fontFamily: candyFonts.bodyHeavy, fontSize: 12.5, textAlign: 'center', marginTop: 4 },
  perks: { alignSelf: 'stretch', gap: 8, marginVertical: 14, paddingHorizontal: 4 },
  perk: { flexDirection: 'row', alignItems: 'center', gap: 10, backgroundColor: '#ffffff', borderRadius: 14, paddingVertical: 9, paddingHorizontal: 12, borderWidth: 1.5, borderColor: '#ecd9fb' },
  tick: { width: 22, height: 22, borderRadius: 11, backgroundColor: BUTTON_VARIANTS.blue.ring, padding: 1.5 },
  tickFace: { flex: 1, borderRadius: 10, borderWidth: 2, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center', overflow: 'hidden' },
  perkText: { flex: 1, color: candyColors.ink, fontFamily: candyFonts.bodyHeavy, fontSize: 12.5 },
  buy: { alignSelf: 'stretch' },
  buyFace: { paddingHorizontal: 16 },
  buyRow: { flexDirection: 'row', alignItems: 'center', gap: 10 },
  buyDivider: { width: 1.5, height: 18, backgroundColor: 'rgba(156,77,6,0.35)' },
  small: { color: candyColors.mutedLight, fontFamily: candyFonts.body, fontSize: 10.5, marginTop: 10, textAlign: 'center' },

  fabLip: { borderRadius: 999, paddingBottom: 4 },
  fabRing: { borderRadius: 999, padding: 2 },
  fabFace: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: 6,
    borderRadius: 999,
    borderWidth: 3,
    borderColor: '#ffffff',
    overflow: 'hidden',
    paddingLeft: 4,
    paddingRight: 5,
    paddingVertical: 3,
  },
  fabLabel: { letterSpacing: 0.6 },
  tag: { backgroundColor: '#ffffff', borderRadius: 999, borderWidth: 2, borderColor: '#9c4d06', paddingHorizontal: 7, paddingVertical: 1.5 },
  tagText: { color: candyColors.goldInk, fontFamily: candyFonts.display, fontSize: 12, includeFontPadding: false },
});
