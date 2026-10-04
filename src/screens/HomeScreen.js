import React, { useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { View, StyleSheet, Animated, Easing, InteractionManager } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import CreatureCard from '../components/CreatureCard';
import { CreateOwnCard, CustomCreatureCard } from '../components/CustomCards';
import CardPager, { CARD_SIZE } from '../components/CardPager';
import SkeletonCard from '../components/SkeletonCard';
import AdStrip from '../components/AdStrip';
import MysteryBoxBanner from '../components/box/MysteryBoxBanner';
import { RemoveAdsButton } from '../components/RemoveAds';
import CandyBackground from '../components/candy/CandyBackground';
import CandyTabs from '../components/candy/CandyTabs';
import RoundButton, { StatsIcon, TrophyIcon, BagIcon, GearIcon, HouseIcon, DailyIcon } from '../components/candy/RoundButton';
import { CoinPill } from '../components/candy/Coin';
import { HaloText } from '../components/candy/OutlinedTitle';
import ShadowText, { outline3 } from '../components/candy/ShadowText';
import { LinearGradient } from 'expo-linear-gradient';
import { candyFonts } from '../theme/candyTheme';
import TutTarget from '../tutorial/Target';
import { Flame } from '../components/StreakIcons';
import HomeMenu, { MENU_BUTTON } from '../components/HomeMenu';
import { report as tutReport } from '../tutorial/store';
import SettingsSheet from './SettingsSheet';
import sfx from '../audio/sfx';

// Home — a two-tab creature shelf on the v3 candy stage:
//  · OUR CREATURES — the 20-strong roster, one card at a time
//  · MY CREATURES  — a "Create your own squishy" card, then a card per
//    custom creature the player has made
//
// Both lists stay mounted side by side once built, so switching tabs is
// only an animation: the current list slides out one way while the other
// slides in from the opposite side (the design's ghostList + listInLeft/
// listInRight — going to the left tab, the old list leaves to the right and
// the new one enters from the left; going right, the reverse). The header,
// tabs and ad bar stay put. A list whose cards aren't built yet shows a
// placeholder card rather than holding the switch back.
//
// Paging within a list lives in CardPager; the unlock-with-key hold gesture
// lives in CreatureCard. Until Remove Ads is bought, a NO ADS button floats
// in the lists' bottom-right corner (beside the down arrow) and the ad strip
// sits at the bottom; afterwards both are gone.

const HOME_TABS = [
  { value: 'ours', label: 'OUR CREATURES' },
  { value: 'mine', label: 'MY CREATURES' },
];

// one shared element, so the memoized pagers don't see a new prop each render
const SKELETON = <SkeletonCard />;
// the Create card fills its tutorial target, which has the card's size
const FILL_CARD = { width: '100%', height: '100%', maxHeight: undefined };

const LIST_SLIDE = { duration: 420, easing: Easing.bezier(0.3, 0.9, 0.3, 1) };
const HEADER_PAD = 16;
const HEADER_BUTTON = 36;

// The design's "LV 3" pill beside the name: gold, white rim, outlined text.
function LevelPill({ level }) {
  return (
    <View style={styles.lvRing}>
      <LinearGradient colors={['#fffbd6', '#ffe045', '#ff9500']} locations={[0, 0.45, 1]} style={styles.lvFace}>
        <ShadowText style={styles.lvText} shadows={outline3('#a04a00')}>{`LV ${level}`}</ShadowText>
      </LinearGradient>
    </View>
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
  tokens = {}, // creature id → its tokens so far
  boxConfigVersion = 0, // bumps when config/mysteryBox (token prices) changes
  onShowUnlock = () => {},
  removeAdsPrice = '',
  onOpenRemoveAds = () => {},
  nickname,
  onSaveNickname,
  adsFree,
  onSubmitFeedback,
  onLogout,
  onOpenStats,
  onOpenAchievements,
  onOpenStore,
  customCreatures = [],
  onOpenCreator = () => {},
  onSelectCustom = () => {},
  onDeleteCustom = () => {},
  onRetryCustom = () => {},
  focusMine = null, // { id, token }: a creature just made — open on it
  onFocusMineDone = () => {},
  generationCredits = 1,
  paidCredits = 0,
  priceLabel = '$4.99',
  discountPct = 0, // a Daily Spin CREATE prize: shown as "−15%" by the price
  // the Mystery Box banner: "3/20 · FIND THE SECRET", FREE/VIDEO/500/READY
  boxLabel = '',
  boxPrice = '',
  boxVideos = 0,
  boxCoins = false,
  onOpenBox = () => {},
  // progression (src/progression.js): the LV pill, the Daily Challenges
  // button (from level 3 once the tutorial has shown it, with how many
  // rewards wait) and the Crib (from level 2)
  level = 1,
  dailyUnlocked = false,
  cribUnlocked = false,
  dailyBadge = 0,
  onOpenDaily = () => {},
  // the daily streak (its screen, from the menu): its days so far, and
  // whether today's chest still has it riding on it
  streak = 0,
  streakHot = false,
  onOpenStreak = () => {},
  onOpenCrib = () => {},
  onReplayTutorial,
}) {
  const insets = useSafeAreaInsets();
  const [settingsOpen, setSettingsOpen] = useState(false);
  // The header: the Crib, the shop and settings as their own buttons, and a
  // menu button for the rest (HomeMenu draws it, over everything, so its
  // drop-down can cover the screen; the header keeps room for it)
  const [menuAnchor, setMenuAnchor] = useState(null);
  const onMenuSlot = useCallback(
    (e) => {
      const { y } = e.nativeEvent.layout;
      setMenuAnchor((a) => (a && a.top === insets.top + y ? a : { top: insets.top + y, right: HEADER_PAD }));
    },
    [insets.top]
  );
  const openSettings = useCallback(() => setSettingsOpen(true), []);
  // the menu's items, in a fixed order (the daily ones once they're unlocked)
  const menuItems = useMemo(() => {
    const list = [];
    if (dailyUnlocked) {
      list.push({ key: 'daily', label: 'DAILY CHALLENGES', variant: 'gold', icon: <DailyIcon />, onPress: onOpenDaily, badge: dailyBadge, tut: 'daily' });
      list.push({ key: 'streak', label: 'DAILY STREAK', variant: 'flame', icon: <Flame size={18} />, onPress: onOpenStreak, badge: streak, badgeGold: true, hot: streakHot });
    }
    list.push({ key: 'trophies', label: 'TROPHIES', icon: <TrophyIcon size={22} />, onPress: onOpenAchievements });
    list.push({ key: 'stats', label: 'STATS', icon: <StatsIcon size={22} />, onPress: onOpenStats });
    return list;
  }, [dailyUnlocked, dailyBadge, streak, streakHot, onOpenDaily, onOpenStreak, onOpenAchievements, onOpenStats]);
  // Back from CREATE with a new creature: start on MY CREATURES.
  const [tab, setTab] = useState(focusMine ? 'mine' : 'ours'); // 'ours' | 'mine'
  const [listW, setListW] = useState(0);
  // the tutorial follows the tab (src/tutorial/steps.js)
  useEffect(() => {
    tutReport({ listTab: tab });
  }, [tab]);

  // --- list slide: 0 = OUR CREATURES in view, 1 = MY CREATURES in view ---
  const tabPos = useRef(new Animated.Value(focusMine ? 1 : 0)).current;
  const slideTo = useCallback(
    (next) => {
      Animated.timing(tabPos, { toValue: next === 'mine' ? 1 : 0, ...LIST_SLIDE, useNativeDriver: true }).start();
    },
    [tabPos]
  );

  // MY CREATURES is built quietly once Home has settled, so the first switch
  // is already instant; switching before that shows the placeholder card.
  const [mineReady, setMineReady] = useState(!!focusMine);
  useEffect(() => {
    const task = InteractionManager.runAfterInteractions(() => setMineReady(true));
    return () => task.cancel();
  }, []);

  const switchTab = useCallback(
    (next) => {
      if (next === tab) return;
      slideTo(next); // start moving first — the re-render below can't hold it up
      sfx.play('swipe');
      setTab(next);
      if (next === 'mine' && !mineReady) requestAnimationFrame(() => setMineReady(true));
    },
    [tab, slideTo, mineReady]
  );

  // App passes `focusMine` right after a creature is made (Home mounts fresh
  // then): show MY CREATURES on that creature's card. Its doc can reach the
  // list a moment later — until it does, the list waits on its last page,
  // and after 8 s it stops waiting.
  const [mineJump, setMineJump] = useState(null);
  useEffect(() => {
    if (!focusMine) return undefined;
    setMineReady(true);
    setTab('mine');
    slideTo('mine');
    const i = customCreatures.findIndex((c) => c.id === focusMine.id);
    setMineJump({ page: i >= 0 ? i + 1 : customCreatures.length, token: `${focusMine.token}:${i}` });
    if (i >= 0) {
      onFocusMineDone();
      return undefined;
    }
    const giveUp = setTimeout(onFocusMineDone, 8000);
    return () => clearTimeout(giveUp);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [focusMine, customCreatures]);

  // --- pages ---
  const ownedSet = useMemo(() => new Set(ownedIds), [ownedIds]);
  const renderOurs = useCallback(
    (i) => {
      const c = creatures[i];
      if (!c) return null;
      return (
        <CreatureCard
          creature={c}
          unlocked={ownedSet.has(c.id)}
          hasKey={!!keys[c.id]}
          tokens={tokens[c.id] || 0}
          priceVersion={boxConfigVersion}
          onSelectToy={onSelectToy}
          onShowUnlock={onShowUnlock}
          onUnlockWithKey={onUnlockWithKey}
        />
      );
    },
    [creatures, ownedSet, keys, tokens, boxConfigVersion, onSelectToy, onShowUnlock, onUnlockWithKey]
  );
  const oursKey = useCallback((i) => (creatures[i] ? `c-${creatures[i].id}` : `c-${i}`), [creatures]);

  const renderMine = useCallback(
    (i) => {
      if (i === 0)
        return (
          <TutTarget name="createCard" style={CARD_SIZE}>
            <CreateOwnCard onPress={onOpenCreator} generationCredits={generationCredits} paidCredits={paidCredits} priceLabel={priceLabel} discountPct={discountPct} style={FILL_CARD} />
          </TutTarget>
        );
      const custom = customCreatures[i - 1];
      if (!custom) return null;
      return <CustomPage custom={custom} onSelect={onSelectCustom} onDelete={onDeleteCustom} onRetry={onRetryCustom} />;
    },
    [customCreatures, onOpenCreator, generationCredits, paidCredits, priceLabel, discountPct, onSelectCustom, onDeleteCustom, onRetryCustom]
  );
  const mineKey = useCallback((i) => (i === 0 ? 'create' : customCreatures[i - 1] ? `m-${customCreatures[i - 1].id}` : `m-${i}`), [customCreatures]);

  const paneStyles = useMemo(() => {
    const shift = listW * 1.05;
    return {
      ours: {
        opacity: tabPos.interpolate({ inputRange: [0, 1], outputRange: [1, 0.4] }),
        transform: [{ translateX: tabPos.interpolate({ inputRange: [0, 1], outputRange: [0, -shift] }) }],
      },
      mine: {
        opacity: tabPos.interpolate({ inputRange: [0, 1], outputRange: [0.4, 1] }),
        transform: [{ translateX: tabPos.interpolate({ inputRange: [0, 1], outputRange: [shift, 0] }) }],
      },
    };
  }, [tabPos, listW]);

  return (
    <CandyBackground sparkles style={styles.container}>
      <View style={[styles.content, { paddingTop: insets.top }]}>
        <View style={styles.header}>
          <View style={styles.nameCol}>
            {/* the LV pill beside the name, above the coins */}
            <View style={styles.nameRow}>
              <HaloText style={styles.nickname} numberOfLines={1}>
                {/* names saved before the 10-character cap */}
                {nickname?.slice(0, 10)}
              </HaloText>
              <LevelPill level={level} />
            </View>
            <View style={styles.walletRow}>
              <CoinPill coins={coins} />
            </View>
          </View>
          <View style={styles.headerIcons} onLayout={onMenuSlot}>
            {cribUnlocked ? (
              <TutTarget name="crib">
                <RoundButton size={HEADER_BUTTON} variant="green" onPress={onOpenCrib}>
                  <HouseIcon />
                </RoundButton>
              </TutTarget>
            ) : null}
            <TutTarget name="store">
              <RoundButton size={HEADER_BUTTON} onPress={onOpenStore}>
                <BagIcon size={21} />
              </RoundButton>
            </TutTarget>
            <RoundButton size={HEADER_BUTTON} onPress={openSettings}>
              <GearIcon size={21} />
            </RoundButton>
            <View style={styles.menuSlot} />
          </View>
        </View>

        <TutTarget name="tabs" style={styles.tabBarWrap}>
          <CandyTabs options={HOME_TABS} value={tab} onChange={switchTab} fontSize={13} padV={9} badges={[0, customCreatures.length]} />
        </TutTarget>

        <View style={styles.lists} onLayout={(e) => setListW(e.nativeEvent.layout.width)}>
          {listW > 0 ? (
            <>
              <Animated.View style={[styles.pane, paneStyles.ours]} pointerEvents={tab === 'ours' ? 'auto' : 'none'}>
                <CardPager
                  pageCount={creatures.length}
                  initialPage={index ?? 0}
                  onPageChange={onChangeIndex}
                  renderPage={renderOurs}
                  pageKey={oursKey}
                  ready={creatures.length > 0}
                  placeholder={SKELETON}
                />
              </Animated.View>
              <Animated.View style={[styles.pane, paneStyles.mine]} pointerEvents={tab === 'mine' ? 'auto' : 'none'}>
                <CardPager
                  pageCount={customCreatures.length + 1}
                  renderPage={renderMine}
                  pageKey={mineKey}
                  jump={mineJump}
                  ready={mineReady}
                  placeholder={SKELETON}
                />
              </Animated.View>
            </>
          ) : null}
          {adsFree ? null : <RemoveAdsButton price={removeAdsPrice} onPress={onOpenRemoveAds} style={styles.noAds} />}
        </View>
      </View>

      <TutTarget name="box">
        <MysteryBoxBanner collectedLabel={boxLabel} priceLabel={boxPrice} videos={boxVideos} coins={boxCoins} onPress={onOpenBox} />
      </TutTarget>

      {/* Full-width ad strip flush with the bottom edge (under the gesture
          bar too); not part of the list animation. */}
      {adsFree ? <View style={{ height: insets.bottom }} /> : <AdStrip />}

      <HomeMenu items={menuItems} anchor={menuAnchor} badge={dailyBadge} hot={streakHot} />

      <SettingsSheet
        visible={settingsOpen}
        onClose={() => setSettingsOpen(false)}
        nickname={nickname}
        onSaveNickname={onSaveNickname}
        onSubmitFeedback={onSubmitFeedback}
        onLogout={onLogout}
        onReplayTutorial={onReplayTutorial}
      />
    </CandyBackground>
  );
}

// Binds a custom creature to its callbacks once, so the memoized card only
// re-renders when that creature's own data changes.
const CustomPage = React.memo(function CustomPage({ custom, onSelect, onDelete, onRetry }) {
  const play = useCallback(() => onSelect(custom), [onSelect, custom]);
  const del = useCallback(() => onDelete(custom), [onDelete, custom]);
  const retry = useCallback(() => onRetry(custom), [onRetry, custom]);
  return <CustomCreatureCard creature={custom} onPlay={play} onDelete={del} onRetry={retry} />;
});

const styles = StyleSheet.create({
  container: { flex: 1 },
  content: { flex: 1 },

  header: {
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'space-between',
    paddingTop: 14,
    paddingHorizontal: 16,
    paddingBottom: 10,
  },
  nameCol: { flexShrink: 1, alignItems: 'flex-start', marginRight: 8 },
  nameRow: { flexDirection: 'row', alignItems: 'center', gap: 6, maxWidth: '100%' },
  nickname: { fontSize: 17, flexShrink: 1 },
  walletRow: { flexDirection: 'row', alignItems: 'center', gap: 6, marginTop: 5 },
  headerIcons: { flexDirection: 'row', alignItems: 'center', gap: 6 },
  menuSlot: { width: MENU_BUTTON, height: MENU_BUTTON + 4 },
  lvRing: { borderRadius: 999, backgroundColor: '#a04a00', padding: 1.5 },
  lvFace: { borderRadius: 999, borderWidth: 2, borderColor: '#ffffff', paddingHorizontal: 9, paddingVertical: 3 },
  lvText: { fontFamily: candyFonts.display, fontSize: 12, color: '#ffffff', includeFontPadding: false },
  tabBarWrap: { paddingHorizontal: 16, paddingBottom: 6 },

  lists: { flex: 1, minHeight: 0, overflow: 'hidden' },
  // in the down arrow's row, right of the arrow
  noAds: { position: 'absolute', right: 12, bottom: 6 },
  pane: { ...StyleSheet.absoluteFillObject },
});
