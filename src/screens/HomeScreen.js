import React, { useCallback, useRef, useState } from 'react';
import { View, Text, StyleSheet, Pressable, ActivityIndicator, Animated } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { spacing } from '../theme/tokens';
import { squadColors, squadGradients, squadFonts } from '../theme/squadTheme';
import CreatureCard from '../components/CreatureCard';
import AdBanner from '../components/AdBanner';
import IconButton from '../components/squad/IconButton';
import SettingsSheet from './SettingsSheet';

// Home Screen — chrome restyled to match "Squish Squad Prototype.html"
// (dark stage, nickname + coins pill, achievements/store/settings icon
// buttons, recolored nav arrows). The card pager itself — CreatureCard and
// the paging FlatList below — is untouched on purpose; only the frame
// around it changed.

export default function HomeScreen({
  creatures = [],
  ownedIds = [],
  coins = 0,
  index,
  onChangeIndex,
  onSelectToy,
  onPurchase,
  nickname,
  onSaveNickname,
  adsFree,
  onClaimAdsFree,
  totalEarned,
  onSubmitFeedback,
  onLogout,
  onOpenAchievements,
  onOpenStore,
}) {
  const insets = useSafeAreaInsets();
  const listRef = useRef(null);
  const scrollY = useRef(new Animated.Value(0)).current;
  const [slotHeight, setSlotHeight] = useState(0);
  const [settingsOpen, setSettingsOpen] = useState(false);

  const safeIndex = creatures.length ? Math.min(index, creatures.length - 1) : 0;
  const canGoUp = safeIndex > 0;
  const canGoDown = safeIndex < creatures.length - 1;

  const goTo = useCallback(
    (next) => {
      if (next < 0 || next >= creatures.length) return;
      onChangeIndex(next);
      if (listRef.current && slotHeight) {
        listRef.current.scrollToOffset({ offset: next * slotHeight, animated: true });
      }
    },
    [creatures.length, onChangeIndex, slotHeight]
  );

  const handleMomentumEnd = useCallback(
    (e) => {
      if (!slotHeight) return;
      const next = Math.round(e.nativeEvent.contentOffset.y / slotHeight);
      if (next !== safeIndex && next >= 0 && next < creatures.length) onChangeIndex(next);
    },
    [slotHeight, safeIndex, creatures.length, onChangeIndex]
  );

  const handleCardPress = useCallback(
    (creature) => {
      if (ownedIds.includes(creature.id)) onSelectToy(creature);
      else onPurchase(creature);
    },
    [ownedIds, onSelectToy, onPurchase]
  );

  const renderItem = useCallback(
    ({ item, index: i }) => {
      const unlocked = ownedIds.includes(item.id);
      const inputRange = [(i - 1) * slotHeight, i * slotHeight, (i + 1) * slotHeight];
      const scale = scrollY.interpolate({ inputRange, outputRange: [0.88, 1, 0.88], extrapolate: 'clamp' });
      const opacity = scrollY.interpolate({ inputRange, outputRange: [0.35, 1, 0.35], extrapolate: 'clamp' });
      return (
        <Animated.View style={{ height: slotHeight, padding: spacing(2), transform: [{ scale }], opacity }}>
          <CreatureCard creature={item} unlocked={unlocked} onPress={() => handleCardPress(item)} style={styles.card} />
        </Animated.View>
      );
    },
    [ownedIds, slotHeight, scrollY, handleCardPress]
  );

  if (!creatures.length) {
    return (
      <LinearGradient colors={squadGradients.homeBg.colors} start={squadGradients.homeBg.start} end={squadGradients.homeBg.end} style={[styles.centered, { paddingTop: insets.top, paddingBottom: insets.bottom }]}>
        <ActivityIndicator color={squadColors.pinkLight} />
        <Text style={styles.loadingText}>Loading your shelf…</Text>
      </LinearGradient>
    );
  }

  const ownedCount = creatures.filter((c) => ownedIds.includes(c.id)).length;

  return (
    <LinearGradient colors={squadGradients.homeBg.colors} start={squadGradients.homeBg.start} end={squadGradients.homeBg.end} style={styles.container}>
      <View style={[styles.content, { paddingTop: insets.top + spacing(3) }]}>
        <View style={styles.header}>
          <View>
            <Text style={styles.nickname}>{nickname}</Text>
            <View style={styles.coinPill}>
              <View style={styles.coinPillDot} />
              <Text style={styles.coinPillText}>{coins}</Text>
            </View>
          </View>
          <View style={styles.headerIcons}>
            <IconButton name="emoji-events" onPress={onOpenAchievements} />
            <IconButton name="storefront" onPress={onOpenStore} />
            <IconButton name="settings" onPress={() => setSettingsOpen(true)} />
          </View>
        </View>

        <Pressable
          style={[styles.navArrow, !canGoUp && styles.navArrowDisabled]}
          onPress={() => goTo(safeIndex - 1)}
          disabled={!canGoUp}
          hitSlop={8}
        >
          <Text style={[styles.navArrowGlyph, { color: canGoUp ? squadColors.pinkLight : squadColors.panelBorder }]}>▲</Text>
        </Pressable>

        <View style={styles.listArea} onLayout={(e) => setSlotHeight(e.nativeEvent.layout.height)}>
          {slotHeight > 0 && (
            <Animated.FlatList
              ref={listRef}
              data={creatures}
              keyExtractor={(c) => c.id}
              renderItem={renderItem}
              showsVerticalScrollIndicator={false}
              pagingEnabled
              decelerationRate="fast"
              snapToInterval={slotHeight}
              snapToAlignment="start"
              getItemLayout={(_, i) => ({ length: slotHeight, offset: slotHeight * i, index: i })}
              initialScrollIndex={safeIndex}
              onScroll={Animated.event([{ nativeEvent: { contentOffset: { y: scrollY } } }], {
                useNativeDriver: true,
              })}
              scrollEventThrottle={16}
              onMomentumScrollEnd={handleMomentumEnd}
            />
          )}
        </View>

        <Pressable
          style={[styles.navArrow, !canGoDown && styles.navArrowDisabled]}
          onPress={() => goTo(safeIndex + 1)}
          disabled={!canGoDown}
          hitSlop={8}
        >
          <Text style={[styles.navArrowGlyph, { color: canGoDown ? squadColors.pinkLight : squadColors.panelBorder }]}>▼</Text>
        </Pressable>
      </View>

      <View style={{ paddingBottom: insets.bottom }}>
        <AdBanner />
      </View>

      <SettingsSheet
        visible={settingsOpen}
        onClose={() => setSettingsOpen(false)}
        nickname={nickname}
        onSaveNickname={onSaveNickname}
        adsFree={adsFree}
        onClaimAdsFree={onClaimAdsFree}
        onSubmitFeedback={onSubmitFeedback}
        onLogout={onLogout}
        ownedCount={ownedCount}
        totalCount={creatures.length}
        totalEarned={totalEarned}
        coins={coins}
      />
    </LinearGradient>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1 },
  content: { flex: 1, paddingHorizontal: spacing(4) },
  centered: { flex: 1, alignItems: 'center', justifyContent: 'center' },
  loadingText: { marginTop: spacing(3), color: squadColors.textLavender, fontSize: 13, fontFamily: squadFonts.bodyBold },
  header: {
    flexDirection: 'row',
    alignItems: 'flex-start',
    justifyContent: 'space-between',
    marginBottom: spacing(3),
  },
  nickname: { fontFamily: squadFonts.headingExtraBold, color: squadColors.textWhite, fontSize: 17 },
  coinPill: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: spacing(1.5),
    backgroundColor: squadColors.panel,
    borderWidth: 1,
    borderColor: squadColors.panelBorder,
    borderRadius: 999,
    paddingHorizontal: spacing(3),
    paddingVertical: spacing(1),
    marginTop: spacing(1.5),
    alignSelf: 'flex-start',
  },
  coinPillDot: {
    width: 14,
    height: 14,
    borderRadius: 7,
    backgroundColor: squadColors.gold,
    shadowColor: squadColors.goldAmber,
    shadowOpacity: 0.7,
    shadowRadius: 6,
  },
  coinPillText: { fontSize: 13, fontFamily: squadFonts.bodyExtraBold, color: squadColors.gold },
  headerIcons: { flexDirection: 'row', gap: spacing(2) },
  navArrow: {
    alignSelf: 'center',
    width: 52,
    height: 34,
    alignItems: 'center',
    justifyContent: 'center',
  },
  navArrowDisabled: { opacity: 0.5 },
  navArrowGlyph: { fontSize: 20, fontWeight: '800' },
  listArea: { flex: 1, marginVertical: spacing(1) },
  card: { flex: 1 },
});
