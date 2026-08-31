import React, { useCallback, useMemo, useState } from 'react';
import { View, Text, StyleSheet, Pressable, ActivityIndicator } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { spacing } from '../theme/tokens';
import { squadColors, squadGradients, squadFonts } from '../theme/squadTheme';
import CreatureCard from '../components/CreatureCard';
import AdBanner from '../components/AdBanner';
import IconButton from '../components/squad/IconButton';
import SettingsSheet from './SettingsSheet';

// Home Screen — matches "ASMR Creature Squash Game.html" exactly: a
// nickname + coins/keys header, and a 4-section vertical stage (up arrow /
// single creature card / down arrow / ad slot) instead of a scrolling list.
// Only `creatures[carouselIndex]` is ever rendered; paging is index-driven
// via `onChangeIndex`, not scroll physics. The card itself (image area with
// its three lock states, info area, hold-to-unlock) lives in CreatureCard.

function ArrowButton({ direction, onPress, disabled }) {
  const isUp = direction === 'up';
  return (
    <Pressable
      style={[styles.arrowButton, isUp && disabled ? styles.arrowButtonDim : null]}
      onPress={onPress}
      hitSlop={10}
    >
      <View style={isUp ? styles.triangleUp : styles.triangleDown} />
    </Pressable>
  );
}

export default function HomeScreen({
  creatures = [],
  ownedIds = [],
  keys = {},
  coins = 0,
  index,
  onChangeIndex,
  onSelectToy,
  onUnlockWithKey,
  nickname,
  onSaveNickname,
  adsFree,
  onClaimAdsFree,
  totalEarned,
  stats,
  favoriteCreatureName,
  onSubmitFeedback,
  onLogout,
  onOpenAchievements,
  onOpenStore,
}) {
  const insets = useSafeAreaInsets();
  const [settingsOpen, setSettingsOpen] = useState(false);

  const safeIndex = creatures.length ? Math.min(Math.max(index ?? 0, 0), creatures.length - 1) : 0;

  const goTo = useCallback(
    (next) => {
      if (!creatures.length) return;
      const clamped = Math.min(Math.max(next, 0), creatures.length - 1);
      if (clamped !== safeIndex) onChangeIndex(clamped);
    },
    [creatures.length, safeIndex, onChangeIndex]
  );

  const keyCount = useMemo(() => Object.values(keys).filter(Boolean).length, [keys]);
  const ownedCount = creatures.filter((c) => ownedIds.includes(c.id)).length;

  if (!creatures.length) {
    return (
      <LinearGradient colors={squadGradients.homeBg.colors} start={squadGradients.homeBg.start} end={squadGradients.homeBg.end} style={[styles.centered, { paddingTop: insets.top, paddingBottom: insets.bottom }]}>
        <ActivityIndicator color={squadColors.pinkLight} />
        <Text style={styles.loadingText}>Loading your shelf…</Text>
      </LinearGradient>
    );
  }

  const currentCreature = creatures[safeIndex];
  const unlocked = ownedIds.includes(currentCreature.id);
  const hasKey = !!keys[currentCreature.id];

  return (
    <LinearGradient colors={squadGradients.homeBg.colors} start={squadGradients.homeBg.start} end={squadGradients.homeBg.end} style={styles.container}>
      <View style={[styles.content, { paddingTop: insets.top }]}>
        <View style={styles.header}>
          <View>
            <Text style={styles.nickname}>Hey {nickname} 👋</Text>
            <View style={styles.pillsRow}>
              <View style={styles.pill}>
                <LinearGradient
                  colors={squadGradients.goldDot.colors}
                  start={squadGradients.goldDot.start}
                  end={squadGradients.goldDot.end}
                  style={styles.coinDot}
                />
                <Text style={styles.coinText}>{coins}</Text>
              </View>
              <View style={styles.pill}>
                <View style={styles.keyDot} />
                <Text style={styles.keyText}>{keyCount}</Text>
              </View>
            </View>
          </View>
          <View style={styles.headerIcons}>
            <IconButton name="emoji-events" onPress={onOpenAchievements} />
            <IconButton name="storefront" onPress={onOpenStore} />
            <IconButton name="settings" onPress={() => setSettingsOpen(true)} />
          </View>
        </View>

        <View style={styles.stage}>
          <View style={styles.arrowSection}>
            <ArrowButton direction="up" onPress={() => goTo(safeIndex - 1)} disabled={safeIndex === 0} />
          </View>

          <View style={styles.cardSection}>
            <CreatureCard
              key={safeIndex}
              creature={currentCreature}
              unlocked={unlocked}
              hasKey={hasKey}
              onSelectToy={onSelectToy}
              onOpenStore={onOpenStore}
              onUnlockWithKey={onUnlockWithKey}
            />
          </View>

          <View style={styles.arrowSection}>
            <ArrowButton direction="down" onPress={() => goTo(safeIndex + 1)} disabled={safeIndex === creatures.length - 1} />
          </View>

          <View style={styles.adSection}>
            <AdBanner />
          </View>
        </View>
      </View>

      <SettingsSheet
        visible={settingsOpen}
        onClose={() => setSettingsOpen(false)}
        nickname={nickname}
        onSaveNickname={onSaveNickname}
        adsFree={true}
        onClaimAdsFree={onClaimAdsFree}
        onSubmitFeedback={onSubmitFeedback}
        onLogout={onLogout}
        ownedCount={ownedCount}
        totalCount={creatures.length}
        totalEarned={totalEarned}
        coins={coins}
        stats={stats}
        favoriteCreatureName={favoriteCreatureName}
      />
    </LinearGradient>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1 },
  content: { flex: 1 },
  centered: { flex: 1, alignItems: 'center', justifyContent: 'center' },
  loadingText: { marginTop: spacing(3), color: squadColors.textLavender, fontSize: 13, fontFamily: squadFonts.bodyBold },

  header: {
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'space-between',
    paddingTop: 14,
    paddingHorizontal: 16,
    paddingBottom: 10,
    flexShrink: 0,
  },
  nickname: { fontFamily: squadFonts.headingExtraBold, fontWeight: '800', color: squadColors.textWhite, fontSize: 17 },
  pillsRow: { flexDirection: 'row', gap: 8, marginTop: 5 },
  pill: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: 5,
    backgroundColor: squadColors.panel,
    borderWidth: 1,
    borderColor: squadColors.panelBorder,
    borderRadius: 999,
    paddingHorizontal: 10,
    paddingVertical: 4,
  },
  coinDot: {
    width: 14,
    height: 14,
    borderRadius: 7,
    shadowColor: squadColors.goldAmber,
    shadowOpacity: 0.7,
    shadowRadius: 6,
    shadowOffset: { width: 0, height: 0 },
  },
  coinText: { color: squadColors.gold, fontFamily: squadFonts.bodyExtraBold, fontWeight: '800', fontSize: 13 },
  keyDot: { width: 10, height: 6, borderRadius: 2, backgroundColor: squadColors.gold },
  keyText: { color: squadColors.textLavender, fontFamily: squadFonts.bodyExtraBold, fontWeight: '800', fontSize: 13 },
  headerIcons: { flexDirection: 'row', gap: 8 },

  stage: { flex: 1, flexDirection: 'column', minHeight: 0 },
  arrowSection: { flex: 20, alignItems: 'center', justifyContent: 'center' },
  cardSection: { flex: 40, alignItems: 'center', justifyContent: 'center', minHeight: 0 },
  adSection: { flex: 20, alignItems: 'center', justifyContent: 'center', paddingBottom: 8 },

  arrowButton: { width: 52, height: 34, alignItems: 'center', justifyContent: 'center' },
  arrowButtonDim: { opacity: 0.35 },
  triangleUp: {
    width: 0,
    height: 0,
    backgroundColor: 'transparent',
    borderStyle: 'solid',
    borderLeftWidth: 14,
    borderRightWidth: 14,
    borderBottomWidth: 20,
    borderLeftColor: 'transparent',
    borderRightColor: 'transparent',
    borderBottomColor: squadColors.pinkLight,
  },
  triangleDown: {
    width: 0,
    height: 0,
    backgroundColor: 'transparent',
    borderStyle: 'solid',
    borderLeftWidth: 14,
    borderRightWidth: 14,
    borderTopWidth: 20,
    borderLeftColor: 'transparent',
    borderRightColor: 'transparent',
    borderTopColor: squadColors.pinkLight,
  },
});
