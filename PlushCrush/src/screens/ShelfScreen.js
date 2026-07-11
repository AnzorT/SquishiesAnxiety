import React from 'react';
import { View, Text, StyleSheet, FlatList, Pressable } from 'react-native';
import { TOY_CATALOG } from '../data/toyCatalog';
import { colors, spacing, typography, radii } from '../theme/tokens';

const RARITY_COLOR = {
  common: colors.rarityCommon,
  rare: colors.rarityRare,
  epic: colors.rarityEpic,
};

export default function ShelfScreen({ ownedIds = ['peach', 'strawberry'], coins = 200, onSelectToy }) {
  const renderItem = ({ item }) => {
    const owned = ownedIds.includes(item.id);
    return (
      <Pressable
        style={[styles.card, !owned && styles.cardLocked]}
        onPress={() => owned && onSelectToy(item)}
      >
        <View style={[styles.swatch, { backgroundColor: item.colorHex }]} />
        <Text style={styles.name}>{item.name}</Text>
        <Text style={[styles.rarity, { color: RARITY_COLOR[item.rarity] }]}>{item.rarity}</Text>
        {!owned && <Text style={styles.price}>{item.price}</Text>}
      </Pressable>
    );
  };

  return (
    <View style={styles.container}>
      <View style={styles.header}>
        <Text style={styles.title}>YOUR SHELF</Text>
        <View style={styles.coinPill}>
          <Text style={styles.coinText}>{coins}⊙</Text>
        </View>
      </View>
      <Text style={styles.subtitle}>PlushCrush</Text>

      <FlatList
        data={TOY_CATALOG}
        keyExtractor={(item) => item.id}
        numColumns={2}
        columnWrapperStyle={{ gap: spacing(4) }}
        contentContainerStyle={{ gap: spacing(4), paddingTop: spacing(6) }}
        renderItem={renderItem}
      />
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, backgroundColor: colors.bgDeep, padding: spacing(5), paddingTop: spacing(14) },
  header: { flexDirection: 'row', justifyContent: 'space-between', alignItems: 'center' },
  title: { ...typography.label },
  coinPill: {
    backgroundColor: colors.glass,
    borderRadius: radii.pill,
    paddingHorizontal: spacing(3),
    paddingVertical: spacing(1),
  },
  coinText: { ...typography.body, color: colors.textPrimary },
  subtitle: { ...typography.display, marginTop: spacing(1) },
  card: {
    flex: 1,
    backgroundColor: colors.glass,
    borderRadius: radii.md,
    borderWidth: 1,
    borderColor: colors.bgPanelBorder,
    padding: spacing(4),
    alignItems: 'center',
  },
  cardLocked: { opacity: 0.45 },
  swatch: { width: 56, height: 56, borderRadius: radii.pill, marginBottom: spacing(2) },
  name: { ...typography.body, color: colors.textPrimary, fontWeight: '600' },
  rarity: { ...typography.label, marginTop: spacing(1) },
  price: { ...typography.body, marginTop: spacing(1) },
});
