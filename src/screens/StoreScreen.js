import React from 'react';
import { View, Text, StyleSheet, ScrollView } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { squadColors, squadGradients, squadFonts, squadRadii } from '../theme/squadTheme';
import IconButton from '../components/squad/IconButton';
import GradientButton from '../components/squad/GradientButton';
import CreatureThumbnail from '../components/CreatureThumbnail';

// The prototype's Key Shop no longer unlocks a creature directly — it sells
// a *key* (onBuyKey). Redeeming that key is a hold-to-unlock gesture that
// lives on the Home card (CreatureCard), out of scope here. So a row's CTA
// reflects one of four states: already unlocked, key already bought and
// waiting to be redeemed on Home, too poor to afford it yet, or buyable.
export default function StoreScreen({ creatures = [], ownedIds = [], keys = {}, coins = 0, onBuyKey, onBack }) {
  const insets = useSafeAreaInsets();
  const items = creatures.filter((c) => (c.price ?? 0) > 0);

  return (
    <LinearGradient colors={squadGradients.homeBg.colors} start={squadGradients.homeBg.start} end={squadGradients.homeBg.end} style={[styles.container, { paddingTop: insets.top }]}>
      <View style={styles.header}>
        <IconButton name="chevron-left" onPress={onBack} iconSize={22} />
        <Text style={styles.headerTitle}>KEY SHOP</Text>
        <View style={styles.coinPill}>
          <View style={styles.coinDot} />
          <Text style={styles.coinText}>{coins}</Text>
        </View>
      </View>

      <ScrollView contentContainerStyle={[styles.list, { paddingBottom: insets.bottom + 20 }]}>
        {items.map((creature) => {
          const owned = ownedIds.includes(creature.id);
          const hasKey = keys[creature.id] === true;
          const afford = coins >= creature.price;

          let label = 'BUY';
          let disabled = false;
          let pillColors = squadGradients.ctaGoldPink.colors;
          let textColor = '#0d0620';
          let onPress = () => onBuyKey(creature);

          if (owned) {
            label = 'UNLOCKED';
            disabled = true;
            onPress = undefined;
          } else if (hasKey) {
            label = 'KEY READY';
            pillColors = [squadColors.keyReadyBg, squadColors.keyReadyBg];
            textColor = squadColors.keyReadyText;
            onPress = undefined;
          } else if (!afford) {
            disabled = true;
            onPress = undefined;
          }

          return (
            <View key={creature.id} style={styles.row}>
              <View style={styles.keyIconWrap}>
                <LinearGradient
                  colors={[squadColors.panelBorder, squadColors.panelAlt]}
                  start={{ x: 0.2, y: 0 }}
                  end={{ x: 0.8, y: 1 }}
                  style={styles.avatarWrap}
                >
                  <CreatureThumbnail creatureId={creature.id} mood="idle" size={26} />
                </LinearGradient>
                <LinearGradient
                  colors={[squadColors.gold, squadColors.goldDeep]}
                  start={{ x: 0, y: 0 }}
                  end={{ x: 1, y: 0 }}
                  style={styles.keyBar}
                />
                <View style={styles.keyTeeth}>
                  <View style={styles.keyTooth1} />
                  <View style={styles.keyTooth2} />
                </View>
              </View>
              <View style={styles.info}>
                <Text style={styles.name}>{creature.name} Key</Text>
                <View style={styles.priceRow}>
                  <View style={styles.coinDot} />
                  <Text style={styles.priceText}>{creature.price}</Text>
                </View>
              </View>
              <GradientButton
                label={label}
                onPress={onPress}
                disabled={disabled}
                colors={pillColors}
                textColor={textColor}
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
  list: { paddingHorizontal: 16, paddingTop: 4, gap: 12 },
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
  // The creature's circular preview reads as the bow of a key — a gold
  // gradient bar plus two stubby teeth trail off its right edge.
  keyIconWrap: { flexDirection: 'row', alignItems: 'center', width: 66, flexShrink: 0 },
  avatarWrap: {
    width: 38,
    height: 38,
    borderRadius: 19,
    borderWidth: 4,
    borderColor: squadColors.gold,
    alignItems: 'center',
    justifyContent: 'center',
    flexShrink: 0,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 4 },
    shadowOpacity: 0.35,
    shadowRadius: 10,
    elevation: 6,
  },
  keyBar: {
    width: 22,
    height: 6,
    borderTopLeftRadius: 0,
    borderBottomLeftRadius: 0,
    borderTopRightRadius: 3,
    borderBottomRightRadius: 3,
    marginLeft: -4,
  },
  keyTeeth: { marginLeft: -2, gap: 2 },
  keyTooth1: { width: 6, height: 8, backgroundColor: squadColors.gold },
  keyTooth2: { width: 9, height: 6, backgroundColor: squadColors.gold },
  info: { flex: 1 },
  name: { color: squadColors.textWhite, fontFamily: squadFonts.headingBold, fontSize: 15 },
  priceRow: { flexDirection: 'row', alignItems: 'center', gap: 4, marginTop: 2 },
  priceText: { color: squadColors.gold, fontFamily: squadFonts.bodyExtraBold, fontSize: 12 },
  buyPill: { paddingVertical: 9, paddingHorizontal: 16 },
});
