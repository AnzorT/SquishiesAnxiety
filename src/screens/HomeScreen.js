import React from 'react';
import { View, Text, StyleSheet, Pressable, ActivityIndicator } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { colors, spacing } from '../theme/tokens';
import CreatureCard from '../components/CreatureCard';
import AdBanner from '../components/AdBanner';

// Home Screen — one creature at a time, filling the space between the
// header and the ad banner, with circular prev/next buttons on either
// side. Tapping an unlocked card opens the Toy Screen; tapping a locked
// one spends coins to unlock it.

export default function HomeScreen({
  creatures = [],
  ownedIds = [],
  coins = 0,
  index,
  onChangeIndex,
  onSelectToy,
  onPurchase,
  onLogout,
}) {
  const insets = useSafeAreaInsets();

  if (!creatures.length) {
    return (
      <View style={[styles.container, styles.centered, { paddingTop: insets.top, paddingBottom: insets.bottom }]}>
        <ActivityIndicator color={colors.accent} />
        <Text style={styles.loadingText}>Loading your shelf…</Text>
      </View>
    );
  }

  const safeIndex = Math.min(index, creatures.length - 1);
  const creature = creatures[safeIndex];
  const unlocked = ownedIds.includes(creature.id);
  const canGoLeft = safeIndex > 0;
  const canGoRight = safeIndex < creatures.length - 1;

  const handleCardPress = () => {
    if (unlocked) {
      onSelectToy(creature);
    } else {
      onPurchase(creature);
    }
  };

  return (
    <View
      style={[
        styles.container,
        { paddingTop: insets.top + spacing(5), paddingBottom: insets.bottom + spacing(5) },
      ]}
    >
      <View style={styles.header}>
        <View>
          <Text style={styles.label}>HOME</Text>
          <Text style={styles.title}>PlushCrush</Text>
        </View>
        <View style={styles.headerRight}>
          <View style={styles.coinPill}>
            <Text style={styles.coinText}>{coins}⊙</Text>
          </View>
          <Pressable onPress={onLogout} hitSlop={8}>
            <Text style={styles.logout}>Log out</Text>
          </Pressable>
        </View>
      </View>

      <View style={styles.pagerRow}>
        <Pressable
          style={styles.arrowBtn}
          onPress={() => canGoLeft && onChangeIndex(safeIndex - 1)}
          disabled={!canGoLeft}
        >
          <Text style={[styles.arrowGlyph, { color: canGoLeft ? colors.arrowActive : colors.arrowInactive }]}>‹</Text>
        </Pressable>

        <CreatureCard creature={creature} unlocked={unlocked} onPress={handleCardPress} style={styles.card} />

        <Pressable
          style={styles.arrowBtn}
          onPress={() => canGoRight && onChangeIndex(safeIndex + 1)}
          disabled={!canGoRight}
        >
          <Text style={[styles.arrowGlyph, { color: canGoRight ? colors.arrowActive : colors.arrowInactive }]}>›</Text>
        </Pressable>
      </View>

      <AdBanner />
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, backgroundColor: colors.bg, padding: spacing(5) },
  centered: { alignItems: 'center', justifyContent: 'center' },
  loadingText: { marginTop: spacing(3), color: colors.textMuted, fontSize: 13, fontWeight: '600' },
  header: {
    flexDirection: 'row',
    alignItems: 'flex-start',
    justifyContent: 'space-between',
    marginBottom: spacing(5),
  },
  label: { fontSize: 12, fontWeight: '700', letterSpacing: 1, color: colors.textMuted, textTransform: 'uppercase' },
  title: { fontSize: 28, fontWeight: '800', color: colors.textPrimary, marginTop: spacing(1) },
  headerRight: { alignItems: 'flex-end', gap: spacing(2) },
  coinPill: {
    backgroundColor: colors.coinGoldBg,
    borderRadius: 999,
    borderWidth: 1,
    borderColor: colors.coinGold,
    paddingHorizontal: spacing(4),
    paddingVertical: spacing(1.5),
  },
  coinText: {
    fontSize: 14,
    fontWeight: '800',
    color: colors.coinGoldDeep,
    textShadowColor: colors.coinGoldShine,
    textShadowRadius: 1,
    textShadowOffset: { width: 0, height: -1 },
  },
  logout: { fontSize: 12, fontWeight: '600', color: colors.textMuted, textDecorationLine: 'underline' },
  pagerRow: {
    flex: 1,
    flexDirection: 'row',
    alignItems: 'stretch',
    gap: spacing(3),
    marginBottom: spacing(4),
  },
  arrowBtn: {
    width: 40,
    alignSelf: 'center',
    height: 40,
    borderRadius: 20,
    backgroundColor: 'rgba(58,46,77,0.32)',
    alignItems: 'center',
    justifyContent: 'center',
  },
  arrowGlyph: { fontSize: 24, fontWeight: '700', lineHeight: 26 },
  card: { flex: 1 },
});
