import React from 'react';
import { View, Text, StyleSheet, ScrollView } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { LinearGradient } from 'expo-linear-gradient';
import { candyColors, candyFonts } from '../theme/candyTheme';
import CandyBackground from '../components/candy/CandyBackground';
import CandyButton from '../components/candy/CandyButton';
import RoundButton, { BackGlyph, KeyIcon } from '../components/candy/RoundButton';
import { CoinIcon, CoinPill } from '../components/candy/Coin';
import OutlinedTitle from '../components/candy/OutlinedTitle';
import CreatureThumbnail from '../components/CreatureThumbnail';

// The Key Shop sells a *key*, not the creature itself — redeeming it is the
// hold-to-unlock gesture on the Home card (CreatureCard). So a row's candy
// button reflects one of four states: already owned (purple ★ OWNED), key
// bought and waiting on Home (gold KEY READY), too poor (grey, dimmed), or
// buyable (pink BUY, gently pulsing).
export default function StoreScreen({ creatures = [], ownedIds = [], keys = {}, coins = 0, onBuyKey, onBack }) {
  const insets = useSafeAreaInsets();
  const items = creatures.filter((c) => (c.price ?? 0) > 0);

  return (
    <CandyBackground style={{ paddingTop: insets.top }}>
      <View style={styles.header}>
        <RoundButton size={36} onPress={onBack}>
          <BackGlyph />
        </RoundButton>
        <OutlinedTitle text="KEY SHOP" fill="pink" size={20} outline={3} />
        <CoinPill coins={coins} style={styles.coinPill} />
      </View>

      <ScrollView contentContainerStyle={[styles.list, { paddingBottom: insets.bottom + 20 }]}>
        {items.map((creature) => {
          const owned = ownedIds.includes(creature.id);
          const hasKey = keys[creature.id] === true;
          const afford = coins >= creature.price;

          let label = 'BUY';
          let variant = 'pink';
          let pulse = 'soft';
          let dim = false;
          let onPress = () => onBuyKey(creature);
          if (owned) {
            label = '★ OWNED';
            variant = 'purple';
            pulse = false;
            onPress = undefined;
          } else if (hasKey) {
            label = 'KEY READY';
            variant = 'gold';
            pulse = false;
            onPress = undefined;
          } else if (!afford) {
            variant = 'grey';
            pulse = false;
            dim = true;
            onPress = undefined;
          }

          return (
            <View key={creature.id} style={styles.rowRing}>
              <View style={styles.rowWhite}>
                <LinearGradient colors={['#fff6fd', '#ffdcf4', '#f5cbff']} locations={[0, 0.6, 1]} style={styles.row}>
                  <View style={styles.keyArt}>
                    <View style={styles.bowRing}>
                      <View style={styles.bowGold}>
                        <View style={styles.bowInner}>
                          <CreatureThumbnail creature={creature} mood="idle" size={28} glow={false} />
                        </View>
                      </View>
                    </View>
                    <View style={styles.keyBit}>
                      <KeyIcon width={28} />
                    </View>
                  </View>
                  <View style={styles.info}>
                    <Text style={styles.name} numberOfLines={1}>
                      {creature.name} Key
                    </Text>
                    <View style={styles.priceRow}>
                      <CoinIcon size={11} />
                      <Text style={styles.priceText}>{creature.price}</Text>
                    </View>
                  </View>
                  <CandyButton
                    label={label}
                    variant={variant}
                    size="xs"
                    pulse={pulse}
                    dim={dim}
                    onPress={onPress}
                    disabled={!onPress}
                    faceStyle={styles.buyFace}
                  />
                </LinearGradient>
              </View>
            </View>
          );
        })}
      </ScrollView>
    </CandyBackground>
  );
}

const styles = StyleSheet.create({
  header: { flexDirection: 'row', alignItems: 'center', gap: 8, paddingHorizontal: 16, paddingTop: 12, paddingBottom: 8 },
  coinPill: { marginLeft: 'auto' },
  list: { paddingHorizontal: 16, paddingTop: 6, gap: 12 },
  rowRing: {
    borderRadius: 23,
    padding: 2.5,
    backgroundColor: candyColors.cardRing,
    shadowColor: '#320064',
    shadowOffset: { width: 0, height: 8 },
    shadowOpacity: 0.35,
    shadowRadius: 9,
    elevation: 6,
  },
  rowWhite: { borderRadius: 20, borderWidth: 3, borderColor: '#ffffff', overflow: 'hidden' },
  row: { flexDirection: 'row', alignItems: 'center', gap: 10, paddingHorizontal: 12, paddingVertical: 9 },
  // The creature sits in a gold-ringed bow; a small gold key shaft runs off
  // its right edge.
  keyArt: { flexDirection: 'row', alignItems: 'center', width: 78, flexShrink: 0 },
  bowRing: { width: 46, height: 46, borderRadius: 23, backgroundColor: '#a0520a', padding: 2 },
  bowGold: { flex: 1, borderRadius: 21, backgroundColor: '#ffd23a', padding: 2 },
  bowInner: {
    flex: 1,
    borderRadius: 19,
    backgroundColor: '#fff2fb',
    borderWidth: 2.5,
    borderColor: '#ffffff',
    alignItems: 'center',
    justifyContent: 'center',
    overflow: 'hidden',
  },
  keyBit: { marginLeft: 3 },
  info: { flex: 1 },
  name: { color: candyColors.ink, fontFamily: candyFonts.display, fontSize: 15 },
  priceRow: { flexDirection: 'row', alignItems: 'center', gap: 4, marginTop: 2 },
  priceText: { color: candyColors.goldInk, fontFamily: candyFonts.bodyHeavy, fontSize: 12 },
  buyFace: { minWidth: 76 },
});
