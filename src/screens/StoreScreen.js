import React from 'react';
import { View, Text, StyleSheet, ScrollView } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { squadColors, squadGradients, squadFonts, squadRadii } from '../theme/squadTheme';
import IconButton from '../components/squad/IconButton';
import GradientButton from '../components/squad/GradientButton';
import SquishyThumbnail from '../components/SquishyThumbnail';

// The prototype's Key Shop sells a "key" that a separate hold-to-unlock
// gesture on the home card later redeems. That redeem step lives on
// CreatureCard, which is explicitly out of scope for this pass, so buying
// here goes straight through the same purchaseCreature call the card's own
// unlock button already uses — no half-built key inventory that nothing
// can spend yet.
export default function StoreScreen({ creatures = [], ownedIds = [], coins = 0, onPurchase, onBack }) {
  const insets = useSafeAreaInsets();
  const items = creatures.filter((c) => (c.price ?? 0) > 0);

  return (
    <LinearGradient colors={squadGradients.homeBg.colors} start={squadGradients.homeBg.start} end={squadGradients.homeBg.end} style={[styles.container, { paddingTop: insets.top }]}>
      <View style={styles.header}>
        <IconButton name="chevron-left" onPress={onBack} iconSize={22} />
        <Text style={styles.headerTitle}>SHOP</Text>
        <View style={styles.coinPill}>
          <View style={styles.coinDot} />
          <Text style={styles.coinText}>{coins}</Text>
        </View>
      </View>

      <ScrollView contentContainerStyle={[styles.list, { paddingBottom: insets.bottom + 20 }]}>
        {items.map((creature) => {
          const owned = ownedIds.includes(creature.id);
          const afford = coins >= creature.price;
          let label = 'BUY';
          let disabled = false;
          if (owned) {
            label = 'UNLOCKED';
            disabled = true;
          } else if (!afford) {
            disabled = true;
          }

          return (
            <View key={creature.id} style={styles.row}>
              <View style={styles.avatarWrap}>
                <SquishyThumbnail colorHex={creature.colors?.[0] ?? squadColors.pinkLight} species={creature.species} size={30} />
              </View>
              <View style={styles.info}>
                <Text style={styles.name}>{creature.name}</Text>
                <View style={styles.priceRow}>
                  <View style={styles.coinDot} />
                  <Text style={styles.priceText}>{creature.price}</Text>
                </View>
              </View>
              <GradientButton
                label={label}
                onPress={() => onPurchase(creature)}
                disabled={disabled}
                colors={squadGradients.ctaGoldPink.colors}
                start={squadGradients.ctaGoldPink.start}
                end={squadGradients.ctaGoldPink.end}
                fontSize={12}
                pillStyle={styles.buyPill}
              />
            </View>
          );
        })}
      </ScrollView>
    </LinearGradient>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1 },
  header: { flexDirection: 'row', alignItems: 'center', gap: 12, paddingHorizontal: 16, paddingVertical: 16 },
  headerTitle: { fontFamily: squadFonts.headingExtraBold, fontSize: 20, color: squadColors.textWhite },
  coinPill: {
    marginLeft: 'auto',
    flexDirection: 'row',
    alignItems: 'center',
    gap: 5,
    backgroundColor: squadColors.panel,
    borderRadius: 999,
    paddingHorizontal: 12,
    paddingVertical: 5,
  },
  coinDot: { width: 12, height: 12, borderRadius: 6, backgroundColor: squadColors.gold },
  coinText: { color: squadColors.gold, fontFamily: squadFonts.bodyExtraBold, fontSize: 13 },
  list: { paddingHorizontal: 16, gap: 12 },
  row: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: 12,
    backgroundColor: squadColors.panelAlt,
    borderRadius: squadRadii.md,
    borderWidth: 1.5,
    borderColor: squadColors.panelBorder,
    paddingHorizontal: 14,
    paddingVertical: 10,
  },
  avatarWrap: {
    width: 46,
    height: 46,
    borderRadius: 23,
    backgroundColor: squadColors.panelAlt,
    borderWidth: 3,
    borderColor: squadColors.gold,
    alignItems: 'center',
    justifyContent: 'center',
  },
  info: { flex: 1 },
  name: { color: squadColors.textWhite, fontFamily: squadFonts.headingBold, fontSize: 15 },
  priceRow: { flexDirection: 'row', alignItems: 'center', gap: 4, marginTop: 2 },
  priceText: { color: squadColors.gold, fontFamily: squadFonts.bodyExtraBold, fontSize: 12 },
  buyPill: { paddingVertical: 9, paddingHorizontal: 16 },
});
