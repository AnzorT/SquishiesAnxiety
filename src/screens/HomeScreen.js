import React, { useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { View, Text, StyleSheet, Pressable, ActivityIndicator, Animated, Easing, PanResponder } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { spacing } from '../theme/tokens';
import { squadColors, squadFonts } from '../theme/squadTheme';
import CreatureCard from '../components/CreatureCard';
import { CreateOwnCard, CustomCreatureCard } from '../components/CustomCards';
import { PagedCard, GhostCard } from '../components/PagedCard';
import AdBanner from '../components/AdBanner';
import IconButton from '../components/squad/IconButton';
import SettingsSheet from './SettingsSheet';

// Home — a two-tab creature shelf, ported from the decoded
// "ASMR Creature Squash Game.html":
//  · OUR CREATURES — the 20-strong roster, one card at a time
//  · MY CREATURES  — a "Create your own squishy" card, then a card per
//    custom creature the player has made
// Switching tabs slides the whole list in from the side (listInLeft/Right);
// paging within a tab plays the cardSlideUp/Down entrance while a ghost of
// the outgoing card flies off (see components/PagedCard). The unlock-with-key
// hold gesture and its UNLOCKED! burst live in CreatureCard.

const ARROW_H = 40;
const AD_H = 52;
const SWIPE_THRESHOLD = 46; // source: onTrackMove dy gate

function ArrowButton({ direction, onPress, dim }) {
  return (
    <Pressable style={styles.arrowButton} onPress={onPress} hitSlop={10} disabled={dim}>
      <View style={[direction === 'up' ? styles.triangleUp : styles.triangleDown, dim && styles.arrowDim]} />
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
  customCreatures = [],
  onOpenCreator = () => {},
  onSelectCustom = () => {},
  onDeleteCustom = () => {},
}) {
  const insets = useSafeAreaInsets();
  const [settingsOpen, setSettingsOpen] = useState(false);
  const [tab, setTab] = useState('ours'); // 'ours' | 'mine'
  const [mineIndex, setMineIndex] = useState(0);
  const [cardTrackH, setCardTrackH] = useState(0);
  const [tabBarW, setTabBarW] = useState(0);

  const oursIndex = creatures.length ? Math.min(Math.max(index ?? 0, 0), creatures.length - 1) : 0;
  const ownedCount = creatures.filter((c) => ownedIds.includes(c.id)).length;
  const minePageCount = customCreatures.length + 1;
  const clampedMineIndex = Math.min(Math.max(mineIndex, 0), minePageCount - 1);

  const targetPage = tab === 'ours' ? oursIndex : clampedMineIndex;
  const pageCount = tab === 'ours' ? creatures.length : minePageCount;

  // --- card swap: `view` is what's on screen; a `ghost` clone of the card
  // that just left flies off while the new one slides in (see PagedCard).
  // Both are created in the SAME render (inside goTo) so there's no one-frame
  // flash of the outgoing card popping back to centre. ---
  const [view, setView] = useState({ index: targetPage, dir: 1 });
  const [ghost, setGhost] = useState(null);
  const page = view.index;

  // An index/tab change that DIDN'T come from goTo (tab switch resetting to 0,
  // a custom creature deleted, App resetting homeIndex) — snap, no ghost.
  useEffect(() => {
    if (view.index !== targetPage) {
      setView((v) => ({ index: targetPage, dir: v.dir }));
      setGhost(null);
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [targetPage, tab]);

  const goTo = useCallback(
    (next) => {
      const clamped = Math.min(Math.max(next, 0), pageCount - 1);
      if (clamped === view.index) return;
      const dir = clamped > view.index ? 1 : -1;
      setGhost({ index: view.index, dir, id: Date.now() });
      setView({ index: clamped, dir });
      if (tab === 'ours') onChangeIndex && onChangeIndex(clamped);
      else setMineIndex(clamped);
    },
    [pageCount, view.index, tab, onChangeIndex]
  );

  // --- list slide-in on tab switch (listInLeft / listInRight) ---
  const listAnim = useRef(new Animated.Value(1)).current;
  const [listDir, setListDir] = useState(1);
  const switchTab = useCallback(
    (next) => {
      if (next === tab) return;
      setListDir(next === 'mine' ? 1 : -1);
      setTab(next);
      if (next === 'mine') setMineIndex(0);
      else onChangeIndex && onChangeIndex(0);
    },
    [tab, onChangeIndex]
  );
  useEffect(() => {
    listAnim.setValue(0);
    Animated.timing(listAnim, {
      toValue: 1,
      duration: 340,
      easing: Easing.bezier(0.2, 0.9, 0.25, 1),
      useNativeDriver: true,
    }).start();
  }, [tab, listAnim]);
  const listTranslateX = listAnim.interpolate({ inputRange: [0, 1], outputRange: [listDir > 0 ? 46 : -46, 0] });

  // --- sliding tab indicator ---
  const indicatorAnim = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    Animated.timing(indicatorAnim, {
      toValue: tab === 'mine' ? 1 : 0,
      duration: 340,
      easing: Easing.bezier(0.65, 0, 0.35, 1),
      useNativeDriver: true,
    }).start();
  }, [tab, indicatorAnim]);
  const indicatorX = indicatorAnim.interpolate({ inputRange: [0, 1], outputRange: [0, tabBarW / 2] });

  // --- vertical swipe paging on the card track ---
  const panResponder = useMemo(
    () =>
      PanResponder.create({
        onMoveShouldSetPanResponder: (_e, g) => Math.abs(g.dy) > 12 && Math.abs(g.dy) > Math.abs(g.dx),
        onPanResponderRelease: (_e, g) => {
          if (g.dy <= -SWIPE_THRESHOLD) goTo(page + 1);
          else if (g.dy >= SWIPE_THRESHOLD) goTo(page - 1);
        },
      }),
    [goTo, page]
  );

  const renderPage = useCallback(
    (tabName, pageIndex) => {
      if (tabName === 'ours') {
        const c = creatures[pageIndex];
        if (!c) return null;
        return (
          <CreatureCard
            creature={c}
            unlocked={ownedIds.includes(c.id)}
            hasKey={!!keys[c.id]}
            onSelectToy={onSelectToy}
            onOpenStore={onOpenStore}
            onUnlockWithKey={onUnlockWithKey}
          />
        );
      }
      if (pageIndex === 0) return <CreateOwnCard onPress={onOpenCreator} />;
      const custom = customCreatures[pageIndex - 1];
      if (!custom) return null;
      return (
        <CustomCreatureCard
          creature={custom}
          onPlay={() => onSelectCustom(custom)}
          onDelete={() => onDeleteCustom(custom)}
        />
      );
    },
    [creatures, ownedIds, keys, customCreatures, onSelectToy, onOpenStore, onUnlockWithKey, onOpenCreator, onSelectCustom, onDeleteCustom]
  );

  if (!creatures.length) {
    return (
      <LinearGradient colors={[squadColors.bgHomeTop, squadColors.bgHomeBottom]} style={[styles.centered, { paddingTop: insets.top, paddingBottom: insets.bottom }]}>
        <ActivityIndicator color={squadColors.pinkLight} />
        <Text style={styles.loadingText}>Loading your shelf…</Text>
      </LinearGradient>
    );
  }

  const upDim = page === 0;
  const mineBadge = customCreatures.length;

  return (
    <LinearGradient colors={[squadColors.bgHomeTop, squadColors.bgHomeBottom]} style={styles.container}>
      <View style={[styles.content, { paddingTop: insets.top }]}>
        <View style={styles.header}>
          <View>
            <Text style={styles.nickname}>{nickname}</Text>
            <View style={styles.pillsRow}>
              <View style={styles.pill}>
                <View style={styles.coinDot} />
                <Text style={styles.coinText}>{coins}</Text>
              </View>
            </View>
          </View>
          <View style={styles.headerIcons}>
            <IconButton name="emoji-events" onPress={onOpenAchievements} />
            <IconButton name="storefront" onPress={onOpenStore} />
            <IconButton name="settings" onPress={() => setSettingsOpen(true)} />
          </View>
        </View>

        <View style={styles.tabBarWrap}>
          <View style={styles.tabBar} onLayout={(e) => setTabBarW(e.nativeEvent.layout.width)}>
            <Pressable style={styles.tabButton} onPress={() => switchTab('ours')}>
              <Text style={[styles.tabLabel, tab === 'ours' ? styles.tabLabelActive : styles.tabLabelIdle]}>OUR CREATURES</Text>
            </Pressable>
            <Pressable style={styles.tabButton} onPress={() => switchTab('mine')}>
              <Text style={[styles.tabLabel, tab === 'mine' ? styles.tabLabelActive : styles.tabLabelIdle]}>MY CREATURES</Text>
              {mineBadge > 0 && (
                <View style={styles.tabBadge}>
                  <Text style={styles.tabBadgeText}>{mineBadge}</Text>
                </View>
              )}
            </Pressable>
            <Animated.View style={[styles.tabIndicator, { width: tabBarW / 2, transform: [{ translateX: indicatorX }] }]}>
              <LinearGradient colors={[squadColors.pink, squadColors.teal]} start={{ x: 0, y: 0 }} end={{ x: 1, y: 0 }} style={StyleSheet.absoluteFillObject} />
            </Animated.View>
          </View>
        </View>

        <Animated.View style={[styles.stage, { opacity: listAnim, transform: [{ translateX: listTranslateX }] }]}>
          <View style={styles.arrowRow}>
            <ArrowButton direction="up" onPress={() => goTo(page - 1)} dim={upDim} />
          </View>

          <View style={styles.cardTrack} onLayout={(e) => setCardTrackH(e.nativeEvent.layout.height)} {...panResponder.panHandlers}>
            {cardTrackH > 0 && (
              <>
                {ghost && (
                  <GhostCard key={ghost.id} direction={ghost.dir} cardH={cardTrackH} onDone={() => setGhost(null)}>
                    {renderPage(tab, ghost.index)}
                  </GhostCard>
                )}
                <PagedCard key={`${tab}-${page}`} direction={view.dir} cardH={cardTrackH}>
                  {renderPage(tab, page)}
                </PagedCard>
              </>
            )}
          </View>

          <View style={styles.arrowRow}>
            {/* source keeps the down arrow at full opacity even on the last
                card (nextCard just clamps) — only the up arrow dims at 0 */}
            <ArrowButton direction="down" onPress={() => goTo(page + 1)} />
          </View>

          <View style={styles.adRow}>
            <View style={styles.adInner}>
              <AdBanner />
            </View>
          </View>
        </Animated.View>
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
  },
  nickname: { fontFamily: squadFonts.headingExtraBold, color: squadColors.textWhite, fontSize: 17 },
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
  coinDot: { width: 14, height: 14, borderRadius: 7, backgroundColor: squadColors.gold },
  coinText: { color: squadColors.gold, fontFamily: squadFonts.bodyExtraBold, fontSize: 13 },
  headerIcons: { flexDirection: 'row', gap: 8 },

  tabBarWrap: { paddingHorizontal: 16, paddingBottom: 6 },
  tabBar: {
    flexDirection: 'row',
    alignItems: 'stretch',
    borderBottomWidth: 1.5,
    borderBottomColor: '#2f1c5a',
    position: 'relative',
  },
  tabButton: { flex: 1, alignItems: 'center', justifyContent: 'center', flexDirection: 'row', gap: 6, paddingVertical: 7 },
  tabLabel: { fontFamily: squadFonts.bodyExtraBold, fontSize: 11, letterSpacing: 1.6 },
  tabLabelActive: { color: squadColors.textWhite },
  tabLabelIdle: { color: squadColors.textFaint },
  tabBadge: {
    minWidth: 16,
    height: 16,
    paddingHorizontal: 4,
    borderRadius: 8,
    backgroundColor: squadColors.pink,
    alignItems: 'center',
    justifyContent: 'center',
  },
  tabBadgeText: { color: '#fff', fontSize: 9, fontFamily: squadFonts.bodyExtraBold },
  tabIndicator: {
    position: 'absolute',
    bottom: -1.5,
    left: 0,
    height: 3,
    borderRadius: 2,
    overflow: 'hidden',
  },

  stage: { flex: 1, minHeight: 0 },
  arrowRow: { height: ARROW_H, alignItems: 'center', justifyContent: 'center' },
  arrowButton: { width: 64, height: 34, alignItems: 'center', justifyContent: 'center' },
  arrowDim: { opacity: 0.35 },
  // NOTE: no `alignItems: 'center'` here — PagedCard needs to stretch to the
  // full track width so CreatureCard's `width: 84%` is 84% of the screen, not
  // of a collapsed parent. PagedCard itself centres the card horizontally.
  cardTrack: { flex: 1, minHeight: 0, justifyContent: 'center', overflow: 'hidden' },
  adRow: { height: AD_H, alignItems: 'center', justifyContent: 'center', paddingBottom: 8 },
  adInner: {
    width: '88%',
    maxHeight: 64,
    height: '100%',
    borderRadius: 16,
    alignItems: 'center',
    justifyContent: 'center',
    overflow: 'hidden',
  },

  triangleUp: {
    width: 0,
    height: 0,
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
    borderStyle: 'solid',
    borderLeftWidth: 14,
    borderRightWidth: 14,
    borderTopWidth: 20,
    borderLeftColor: 'transparent',
    borderRightColor: 'transparent',
    borderTopColor: squadColors.pinkLight,
  },
});
