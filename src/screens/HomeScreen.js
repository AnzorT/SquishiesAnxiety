import React, { useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { View, Text, StyleSheet, Pressable, ActivityIndicator, Animated, Easing, PanResponder } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { spacing } from '../theme/tokens';
import { squadColors, squadFonts } from '../theme/squadTheme';
import CreatureCard from '../components/CreatureCard';
import { CreateOwnCard, CustomCreatureCard } from '../components/CustomCards';
import { PagedCard, GhostCard, PAGED_CARD_EASING } from '../components/PagedCard';
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
  onRetryCustom = () => {},
  focusMineToken = 0,
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
    (next, opts = {}) => {
      const clamped = Math.min(Math.max(next, 0), pageCount - 1);
      if (clamped === view.index) return;
      const dir = clamped > view.index ? 1 : -1;
      // `instant` means a real-time drag (see panResponder below) already
      // animated the card into its resting position — skip the timed
      // slide-in/ghost-exit for this transition so it doesn't yank back
      // off-screen and replay.
      setGhost(opts.instant ? null : { index: view.index, dir, id: Date.now() });
      setView({ index: clamped, dir, instant: !!opts.instant });
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

  // App bumps focusMineToken right after a creature is created — jump to the
  // MY CREATURES tab and to its last page (the new creature); `clampedMineIndex`
  // pins the big index to the last real page once the Firestore snapshot lands.
  const didMountFocus = useRef(false);
  useEffect(() => {
    if (!didMountFocus.current) {
      didMountFocus.current = true;
      return;
    }
    setListDir(1);
    setTab('mine');
    setMineIndex(9999);
  }, [focusMineToken]);
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
  // Two separate problems compounded here. (1) A finger drag used to do
  // nothing until release, so the card sat frozen under your thumb for the
  // whole gesture. Fixed by having `dragY` track the raw touch offset every
  // frame. (2) Even after that, the *first* drag on a given page still felt
  // like it took a beat to "notice" you — because the neighbouring card was
  // only ever mounted once a drag actually started (inside `dragState`),
  // so React had to build that whole card (a fresh CreatureCard instance,
  // its SVG thumbnail, its animated values) in the middle of your gesture.
  // The fix is to always keep the previous/next card mounted (see the
  // prev/next slots in cardTrack below, rendered whenever that neighbour
  // page exists) so there's nothing left to build when a drag begins —
  // only their position changes, driven by `dragY`.
  const dragY = useRef(new Animated.Value(0)).current;
  const pageRef = useRef(page);
  pageRef.current = page;
  const pageCountRef = useRef(pageCount);
  pageCountRef.current = pageCount;
  const cardTrackHRef = useRef(cardTrackH);
  cardTrackHRef.current = cardTrackH;

  const panResponder = useMemo(
    () =>
      PanResponder.create({
        // CreatureCard's Pressable (hold-to-unlock) claims the responder the
        // instant a touch lands on it, on the bubble phase — so a *bubble*
        // onMoveShouldSetPanResponder here never even gets asked once that
        // happens, and the swipe only "woke up" if you dragged off the card
        // entirely. The *capture* phase is evaluated top-down on every move,
        // before the touch reaches the Pressable, so it can reliably steal
        // the gesture away the moment real vertical dragging starts.
        onStartShouldSetPanResponderCapture: () => false,
        onMoveShouldSetPanResponderCapture: (_e, g) => Math.abs(g.dy) > 6 && Math.abs(g.dy) > Math.abs(g.dx),
        onMoveShouldSetPanResponder: (_e, g) => Math.abs(g.dy) > 6 && Math.abs(g.dy) > Math.abs(g.dx),
        onPanResponderTerminationRequest: () => false,
        onPanResponderGrant: () => {
          dragY.setValue(0);
        },
        onPanResponderMove: (_e, g) => {
          const dir = g.dy < 0 ? 1 : -1;
          const peekIndex = pageRef.current + dir;
          const hasPeek = peekIndex >= 0 && peekIndex <= pageCountRef.current - 1;
          // Rubber-band: at the end of the list there's nowhere to reveal, so
          // let the current card drift a little (feedback that you dragged)
          // instead of tracking 1:1 forever.
          dragY.setValue(hasPeek ? g.dy : g.dy * 0.25);
        },
        onPanResponderRelease: (_e, g) => {
          const dir = g.dy < 0 ? 1 : -1;
          const peekIndex = pageRef.current + dir;
          const hasPeek = peekIndex >= 0 && peekIndex <= pageCountRef.current - 1;
          const committed = hasPeek && Math.abs(g.dy) >= SWIPE_THRESHOLD;
          if (committed) {
            const trackH = cardTrackHRef.current || 1;
            const target = dir > 0 ? -trackH : trackH;
            Animated.timing(dragY, {
              toValue: target,
              duration: 180,
              easing: PAGED_CARD_EASING,
              useNativeDriver: false,
            }).start(() => {
              goTo(peekIndex, { instant: true });
              dragY.setValue(0);
            });
          } else {
            Animated.spring(dragY, {
              toValue: 0,
              useNativeDriver: false,
              friction: 9,
              tension: 80,
            }).start();
          }
        },
      }),
    [goTo, dragY]
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
          onRetry={() => onRetryCustom(custom)}
        />
      );
    },
    [creatures, ownedIds, keys, customCreatures, onSelectToy, onOpenStore, onUnlockWithKey, onOpenCreator, onSelectCustom, onDeleteCustom, onRetryCustom]
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
  const downDim = page === pageCount - 1;
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
                {/* The current page's own live position — dragY rides on top
                    of PagedCard's normal button-triggered slide (0 whenever
                    that's playing, since a live drag and a button transition
                    never happen at the same time), so no separate "current"
                    copy is needed. */}
                <Animated.View style={[styles.wrapFill, { transform: [{ translateY: dragY }] }]}>
                  {ghost && (
                    <GhostCard key={ghost.id} direction={ghost.dir} cardH={cardTrackH} onDone={() => setGhost(null)}>
                      {renderPage(tab, ghost.index)}
                    </GhostCard>
                  )}
                  <PagedCard key={`${tab}-${page}`} direction={view.dir} cardH={cardTrackH} instant={view.instant}>
                    {renderPage(tab, page)}
                  </PagedCard>
                </Animated.View>

                {/* Always mounted (keyed by page, so it's swapped for a
                    fresh neighbour right after a commit settles — never in
                    the middle of a drag) so the very first swipe from a
                    freshly-landed page already has something to reveal,
                    instead of mounting it on demand when the drag starts. */}
                {page > 0 && (
                  <Animated.View
                    key={`prev-${tab}-${page - 1}`}
                    pointerEvents="none"
                    style={[
                      styles.dragLayerFill,
                      {
                        opacity: dragY.interpolate({ inputRange: [0, cardTrackH], outputRange: [0.5, 1], extrapolate: 'clamp' }),
                        transform: [
                          { translateY: Animated.add(dragY, -cardTrackH) },
                          { scale: dragY.interpolate({ inputRange: [0, cardTrackH], outputRange: [0.94, 1], extrapolate: 'clamp' }) },
                        ],
                      },
                    ]}
                  >
                    {renderPage(tab, page - 1)}
                  </Animated.View>
                )}
                {page < pageCount - 1 && (
                  <Animated.View
                    key={`next-${tab}-${page + 1}`}
                    pointerEvents="none"
                    style={[
                      styles.dragLayerFill,
                      {
                        opacity: dragY.interpolate({ inputRange: [-cardTrackH, 0], outputRange: [1, 0.5], extrapolate: 'clamp' }),
                        transform: [
                          { translateY: Animated.add(dragY, cardTrackH) },
                          { scale: dragY.interpolate({ inputRange: [-cardTrackH, 0], outputRange: [1, 0.94], extrapolate: 'clamp' }) },
                        ],
                      },
                    ]}
                  >
                    {renderPage(tab, page + 1)}
                  </Animated.View>
                )}
              </>
            )}
          </View>

          <View style={styles.arrowRow}>
            <ArrowButton direction="down" onPress={() => goTo(page + 1)} dim={downDim} />
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
  // Same "don't centre here" rule as cardTrack above — this just needs to
  // stretch to full width so PagedCard's flex:1 (and in turn CreatureCard's
  // 84%) resolve against the real track width, not a shrink-wrapped one.
  wrapFill: { ...StyleSheet.absoluteFillObject },
  // The drag layer wraps renderPage()'s output directly (no PagedCard in
  // between to centre it), so this one DOES need alignItems: 'center' to
  // centre the 84%-wide card horizontally.
  dragLayerFill: { ...StyleSheet.absoluteFillObject, alignItems: 'center', justifyContent: 'center' },
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
