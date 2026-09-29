import React, { useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { View, StyleSheet, Animated, Easing, InteractionManager } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import CreatureCard from '../components/CreatureCard';
import { CreateOwnCard, CustomCreatureCard } from '../components/CustomCards';
import CardPager from '../components/CardPager';
import SkeletonCard from '../components/SkeletonCard';
import AdStrip from '../components/AdStrip';
import MysteryBoxBanner from '../components/box/MysteryBoxBanner';
import { RemoveAdsButton } from '../components/RemoveAds';
import CandyBackground from '../components/candy/CandyBackground';
import CandyTabs from '../components/candy/CandyTabs';
import RoundButton, { StatsIcon, TrophyIcon, BagIcon, GearIcon } from '../components/candy/RoundButton';
import { CoinPill } from '../components/candy/Coin';
import { HaloText } from '../components/candy/OutlinedTitle';
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

const LIST_SLIDE = { duration: 420, easing: Easing.bezier(0.3, 0.9, 0.3, 1) };

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
  focusMineToken = 0,
  generationCredits = 1,
  priceLabel = '$4.99',
  discountPct = 0, // a Daily Spin CREATE prize: shown as "−15%" by the price
  // the Mystery Box banner: "3/20 · FIND THE SECRET", FREE/VIDEO/500/READY
  boxLabel = '',
  boxPrice = '',
  boxVideos = 0,
  boxCoins = false,
  onOpenBox = () => {},
}) {
  const insets = useSafeAreaInsets();
  const [settingsOpen, setSettingsOpen] = useState(false);
  const [tab, setTab] = useState('ours'); // 'ours' | 'mine'
  const [listW, setListW] = useState(0);

  // --- list slide: 0 = OUR CREATURES in view, 1 = MY CREATURES in view ---
  const tabPos = useRef(new Animated.Value(0)).current;
  const slideTo = useCallback(
    (next) => {
      Animated.timing(tabPos, { toValue: next === 'mine' ? 1 : 0, ...LIST_SLIDE, useNativeDriver: true }).start();
    },
    [tabPos]
  );

  // MY CREATURES is built quietly once Home has settled, so the first switch
  // is already instant; switching before that shows the placeholder card.
  const [mineReady, setMineReady] = useState(false);
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

  // App bumps focusMineToken right after a creature is created — jump to MY
  // CREATURES and to its last page (the new creature).
  const [mineJump, setMineJump] = useState(null);
  const didMountFocus = useRef(false);
  useEffect(() => {
    if (!didMountFocus.current) {
      didMountFocus.current = true;
      return;
    }
    setMineReady(true);
    setTab('mine');
    slideTo('mine');
    setMineJump({ page: customCreatures.length, token: focusMineToken, until: Date.now() + 8000 });
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [focusMineToken]);
  // The new creature's doc can land a moment after the token — for a few
  // seconds, keep the jump target on the last page as the list grows.
  useEffect(() => {
    if (mineJump && Date.now() < mineJump.until && mineJump.page !== customCreatures.length) {
      setMineJump({ ...mineJump, page: customCreatures.length, token: mineJump.token + 0.5 });
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [customCreatures.length]);

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
      if (i === 0) return <CreateOwnCard onPress={onOpenCreator} generationCredits={generationCredits} priceLabel={priceLabel} discountPct={discountPct} />;
      const custom = customCreatures[i - 1];
      if (!custom) return null;
      return <CustomPage custom={custom} onSelect={onSelectCustom} onDelete={onDeleteCustom} onRetry={onRetryCustom} />;
    },
    [customCreatures, onOpenCreator, generationCredits, priceLabel, discountPct, onSelectCustom, onDeleteCustom, onRetryCustom]
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
            <HaloText style={styles.nickname} numberOfLines={1}>
              {nickname}
            </HaloText>
            <CoinPill coins={coins} style={styles.wallet} />
          </View>
          <View style={styles.headerIcons}>
            <RoundButton size={42} onPress={onOpenStats}>
              <StatsIcon />
            </RoundButton>
            <RoundButton size={42} onPress={onOpenAchievements}>
              <TrophyIcon />
            </RoundButton>
            <RoundButton size={42} onPress={onOpenStore}>
              <BagIcon />
            </RoundButton>
            <RoundButton size={42} onPress={() => setSettingsOpen(true)}>
              <GearIcon />
            </RoundButton>
          </View>
        </View>

        <View style={styles.tabBarWrap}>
          <CandyTabs options={HOME_TABS} value={tab} onChange={switchTab} fontSize={13} padV={9} badges={[0, customCreatures.length]} />
        </View>

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

      <MysteryBoxBanner collectedLabel={boxLabel} priceLabel={boxPrice} videos={boxVideos} coins={boxCoins} onPress={onOpenBox} />

      {/* Full-width ad strip flush with the bottom edge (under the gesture
          bar too); not part of the list animation. */}
      {adsFree ? <View style={{ height: insets.bottom }} /> : <AdStrip />}

      <SettingsSheet
        visible={settingsOpen}
        onClose={() => setSettingsOpen(false)}
        nickname={nickname}
        onSaveNickname={onSaveNickname}
        onSubmitFeedback={onSubmitFeedback}
        onLogout={onLogout}
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
  nameCol: { flexShrink: 1, alignItems: 'flex-start' },
  nickname: { fontSize: 17 },
  wallet: { marginTop: 5 },
  headerIcons: { flexDirection: 'row', gap: 8 },

  tabBarWrap: { paddingHorizontal: 16, paddingBottom: 6 },

  lists: { flex: 1, minHeight: 0, overflow: 'hidden' },
  // in the down arrow's row, right of the arrow
  noAds: { position: 'absolute', right: 12, bottom: 6 },
  pane: { ...StyleSheet.absoluteFillObject },
});
