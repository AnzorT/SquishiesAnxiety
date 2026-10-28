import React, { memo, useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { Animated, Dimensions, Easing, ScrollView, StyleSheet, Text, View, useWindowDimensions } from 'react-native';
import Pressable from '../components/Pressable';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { LinearGradient } from 'expo-linear-gradient';
import CandyBackground from '../components/candy/CandyBackground';
import RoundButton, { BackGlyph } from '../components/candy/RoundButton';
import OutlinedTitle from '../components/candy/OutlinedTitle';
import ShadowText, { outline3 } from '../components/candy/ShadowText';
import useRewardedAd from '../components/useRewardedAd';
import { PRODUCTS, GEM_KEYS } from '../economy';
import { todayKey } from '../dailySpin';
import sfx from '../audio/sfx';
import { BY_ID, GDEAL, HIDDEN, SET_REWARDS, SEASON, SIZES, SIZE_I, SWAPS, AD_CHESTS, lineup, outIds, owns, wallet } from '../squad/data';
import * as squad from '../squad/api';
import { BtnText, CandyBtn, CoinIcon, F, GemIcon, GOLD_RING, PINK_RING, Ringed, untilMidnight } from '../squad/ui';
import ChestsTabV6, { ChestSheetBody, OddsSheetBody } from './ShopChests';
import ChestSmash from '../components/ChestSmash';
import { DealsTab, GemsTab as GemsTabV6 } from './ShopDeals';
import Freeze from '../components/Freeze';
import TutTarget from '../tutorial/Target';
import { report as tutReport } from '../tutorial/store';
import { Bone, BoneCard, Reveal, useAfterFirstFrame } from '../components/Skeleton';
import { useSeenTabs } from '../components/TabPane';
import { fmtNum } from '../format';
import useInstantTab from '../components/useInstantTab';

// The Shop (the 2026-10-06 design's "Shop Screen v2"): chests, squishies
// and gems, on the squad economy (src/squad, run by the `squad` Cloud
// Function). Three tabs:
//  · Chests — the v6 group chests (ShopChests.js); no "My Chests" shelf:
//    every chest opens as soon as it's got;
//  · (no Squishies tab: a squishy unlocks only by being found in chests
//    enough times — functions/squad.js COPIES; none is sold for coins);
//  · Gems — the gem packs (real money), gems → coins, Remove Ads.
// Left out until their products exist: the hero offers (Season Pass,
// Starter Pack, Mega Bundle, VIP Club).
//
// Every move goes to the server; the profile listener brings the result in.

const LIP = ['#f2c7a0', '#a9d2f2', '#f0a8d8', '#93e0d2', '#cdb0f2'];
const CHIP = ['#d9772f', '#2f7fd6', '#d3179a', '#1b9c8c'];
// the v6 tabs (the Squishies tab's buying moved to the Squad screen's UNLOCK)
const SEGS = [['chests', 'Chests'], ['deals', 'Deals'], ['gems', 'Gems']];
const GEM_PILE = [[20, 12, 22], [4, 18, 18], [40, 18, 18], [12, 4, 16], [30, 2, 16], [22, 24, 14]];
const COIN_POS = [[0, 6], [15, 6], [30, 6], [8, 0], [22, 0]];
const ODDS_NAMES = ['Common', 'Rare', 'Epic', 'Legend'];
const ODDS_BG = ['#d7f0ff', '#c9f7e1', '#ead6ff', '#ffdcb0'];
const ERRORS = {
  not_enough_coins: null, // → the broke sheet
  not_enough_gems: null,
  deal_used: 'You already got today\'s deal',
  no_videos_left: 'No more free chests today',
  no_chest: 'That chest is already open',
  empty_chest: 'Nothing in that chest yet. Coming soon!',
  owned: 'Already in your squad',
  not_for_sale: 'Not for sale',
  not_yet: 'Your free chest isn\'t ready yet',
  unknown_chest: 'That chest isn\'t in the shop any more',
  claimed: 'Already claimed',
  need_xp: 'Open more chests to earn XP first',
  need_pass: 'This reward needs the season pass',
  season_over: 'The season is over',
  unknown_reward: 'That reward isn\'t there any more',
};
const fmt = fmtNum;
// the season's last minute (its chest's "Ends in" countdown)
const SEASON_END = new Date(2026, 9, 31, 23, 59);

export function Title({ children, size = 17 }) {
  return (
    <ShadowText style={{ fontFamily: F.display, fontSize: size, color: '#ffffff' }} shadows={[[0, 3, '#45107a'], [1.5, 0, '#45107a'], [-1.5, 0, '#45107a'], [0, 1.5, '#45107a'], [0, -1.5, '#45107a']]}>
      {children}
    </ShadowText>
  );
}

// The coin / gem counters in the header.
export function Purse({ cur, amount, onPress, plus = true }) {
  const ring = cur === 'gems' ? '#45189a' : PINK_RING;
  return (
    <Pressable onPress={onPress}>
      <Ringed ring={ring} lip={3} ringW={2} border={2.5} innerStyle={styles.purse}>
        {cur === 'gems' ? <GemIcon size={17} /> : <CoinIcon size={19} />}
        <Text style={[styles.purseText, { color: cur === 'coins' ? '#b86200' : '#5a22c8' }, !plus && { marginRight: 6 }]}>{fmt(amount)}</Text>
        {plus && (
          <LinearGradient colors={['#b8ffd9', '#3ddc97', '#16a86a']} style={styles.plus}>
            <Text style={styles.plusText}>+</Text>
          </LinearGradient>
        )}
      </Ringed>
    </Pressable>
  );
}

// The segmented tab switch (Chests / Squishies / Gems here).
// `onPick(k)`: called on the tap itself (before onTab), for a caller that
// starts its own animation at once (the Squishies screen's page slide)
export function Seg({ tab: current, onTab, onPick, badges = {}, segs = SEGS }) {
  // the tapped tab lights up and the pill moves at once; onTab follows
  const [tab, press] = useInstantTab(current, onTab);
  const [w, setW] = useState(0);
  const x = useRef(new Animated.Value(0)).current;
  const i = segs.findIndex(([k]) => k === tab);
  useEffect(() => {
    Animated.spring(x, { toValue: i, friction: 7, tension: 110, useNativeDriver: true }).start();
  }, [i, x]);
  const pill = (w - 8) / segs.length;
  return (
    <Ringed ring={PINK_RING} lip={4} style={styles.segOuter} innerStyle={styles.seg}>
      <View style={StyleSheet.absoluteFill} onLayout={(e) => e.nativeEvent.layout.width > 0 && setW(e.nativeEvent.layout.width)} />
      {w > 0 && (
        <Animated.View style={[styles.segPill, { width: pill, transform: [{ translateX: x.interpolate({ inputRange: [0, 1], outputRange: [0, pill] }) }] }]}>
          <Ringed ring={PINK_RING} lip={3} ringW={2} border={2} colors={['#ffd6f4', '#ff5cc6', '#c02bd9']} style={{ flex: 1 }} innerStyle={{ flex: 1 }} />
        </Animated.View>
      )}
      {segs.map(([k, label]) => (
        <Pressable
          key={k}
          style={styles.segItem}
          onPress={() => {
            if (onPick) onPick(k);
            press(k);
          }}
        >
          {k === tab ? (
            <ShadowText style={styles.segOn} shadows={outline3(PINK_RING, 2)}>
              {label}
            </ShadowText>
          ) : (
            <Text style={styles.segOff}>{label}</Text>
          )}
          {!!badges[k] && k !== tab && (
            <View style={styles.segBadge}>
              <Text style={styles.segBadgeText}>{badges[k]}</Text>
            </View>
          )}
        </Pressable>
      ))}
    </Ringed>
  );
}

// --- Chests tab -----------------------------------------------------------------

// --- Gems tab --------------------------------------------------------------------

// `firstBought`: the packs already bought once ('a,b'), `adsFree`: Remove
// Ads owned. Not the profile: it changes with every move.
const GemsTab = memo(function GemsTab({ firstBought, adsFree, priceOf, onPack, onSwap, onNoAds, noAdsPrice }) {
  const first = Object.fromEntries(firstBought.split(',').filter(Boolean).map((k) => [k, true]));
  return (
    <View style={[styles.col14, { paddingTop: 8 }]}>
      <View style={styles.grid3}>
        {GEM_KEYS.map((key, i) => {
          const p = PRODUCTS[key];
          const dbl = !first[p.base];
          const tag = dbl ? '2× FIRST BUY' : p.tag;
          return (
            <Pressable key={key} style={styles.packWrap} onPress={() => onPack(key)}>
              <LinearGradient colors={['#eef6ff', '#d6e8ff', '#c9b8ff']} locations={[0, 0.6, 1]} style={styles.pack}>
                <View style={{ width: 64, height: 44 }}>
                  {GEM_PILE.slice(0, i + 1).map(([x, y, sz], j) => (
                    <View key={j} style={{ position: 'absolute', left: x, top: y }}>
                      <GemIcon size={sz} />
                    </View>
                  ))}
                </View>
                <Text style={styles.packAmount}>{fmt(dbl ? p.gems * 2 : p.gems)}</Text>
                {(dbl || !!p.bonus) && <Text style={styles.packBonus}>{dbl ? `was ${fmt(p.gems)}` : p.bonus}</Text>}
                <Ringed ring="#1d4f9a" lip={3} ringW={2} border={2.5} colors={['#d6f3ff', '#5fb8ff', '#2f7fd6']} style={{ alignSelf: 'stretch' }} innerStyle={{ paddingVertical: 4, alignItems: 'center' }}>
                  <BtnText ring="#1d4f9a" size={13.5}>
                    {priceOf(key)}
                  </BtnText>
                </Ringed>
              </LinearGradient>
              {!!tag && (
                <View style={styles.packTag}>
                  <Text style={styles.packTagText}>{tag}</Text>
                </View>
              )}
            </Pressable>
          );
        })}
      </View>

      <View style={{ gap: 8 }}>
        <Title>Coins for gems</Title>
        <View style={styles.row8}>
          {SWAPS.map((sw, i) => (
            <Pressable key={i} style={styles.swap} onPress={() => onSwap(i)}>
              <View style={{ width: 52, height: 30 }}>
                {COIN_POS.slice(0, i + 3)
                  .reverse()
                  .map(([x, y], j) => (
                    <View key={j} style={{ position: 'absolute', left: x, top: y }}>
                      <CoinIcon size={26} />
                    </View>
                  ))}
              </View>
              <Text style={styles.swapAmount}>{fmt(sw.coins)}</Text>
              <Ringed ring="#45189a" lip={3} ringW={2} border={2.5} colors={['#efe6ff', '#b48bff', '#8f3cf2']} innerStyle={styles.swapCost}>
                <GemIcon size={13} />
                <BtnText ring="#45189a" size={13.5}>
                  {fmt(sw.gems)}
                </BtnText>
              </Ringed>
            </Pressable>
          ))}
        </View>
      </View>

      <Pressable style={styles.noAds} onPress={onNoAds}>
        <LinearGradient colors={['#ffd6f4', '#ff5cc6']} style={styles.noAdsIcon}>
          <Text style={styles.noAdsIconText}>AD</Text>
          <View style={styles.noAdsSlash} />
        </LinearGradient>
        <View style={{ flex: 1, gap: 2 }}>
          <Text style={styles.noAdsTitle}>Remove Ads</Text>
          <Text style={styles.noAdsNote}>No more ads between screens. Free reward videos stay optional.</Text>
        </View>
        <Ringed ring={adsFree ? '#0d7a4a' : '#1d4f9a'} lip={3} ringW={2} border={2.5} colors={adsFree ? ['#b8ffd9', '#3ddc97', '#16a86a'] : ['#d6f3ff', '#5fb8ff', '#2f7fd6']} innerStyle={{ paddingHorizontal: 10, paddingVertical: 5 }}>
          <BtnText ring={adsFree ? '#0d7a4a' : '#1d4f9a'} size={14}>
            {adsFree ? 'OWNED' : noAdsPrice}
          </BtnText>
        </Ringed>
      </Pressable>
      <Text style={styles.foot}>First purchase of each gem pack gives double gems.</Text>
    </View>
  );
});

// --- the sheet ---------------------------------------------------------------------

function Sheet({ sheet, profile, catalog, artIds, setRewards, wallet: w, onClose, onBroke, onBuyGroup }) {
  const up = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    up.setValue(0);
    Animated.spring(up, { toValue: 1, friction: 8, tension: 80, useNativeDriver: true }).start();
  }, [sheet, up]);
  if (!sheet) return null;
  const translateY = up.interpolate({ inputRange: [0, 1], outputRange: [500, 0] });
  let body = null;
  if (sheet.type === 'odds') {
    body = <OddsSheetBody />;
  } else if (sheet.type === 'gchest') {
    body = (
      <ScrollView style={styles.sheetScroll} contentContainerStyle={{ paddingBottom: 6 }} showsVerticalScrollIndicator={false}>
        <ChestSheetBody gk={sheet.gk} size={sheet.size} profile={profile} artIds={artIds} setRewards={setRewards} catalog={catalog} wallet={w} onBuy={onBuyGroup} />
      </ScrollView>
    );
  } else if (sheet.type === 'broke') {
    body = (
      <>
        <Text style={styles.sheetTitle}>{sheet.cur === 'gems' ? 'Not enough gems' : 'Not enough coins'}</Text>
        <Text style={styles.sheetSub}>
          You need {fmt(sheet.need)} more {sheet.cur === 'gems' ? 'gems' : 'coins'}
        </Text>
        <CandyBtn kind="gold" stretch padV={12} lip={5} onPress={onBroke}>
          <BtnText size={18}>{sheet.cur === 'gems' ? 'GET GEMS' : 'GET COINS'}</BtnText>
        </CandyBtn>
      </>
    );
  }
  return (
    <View style={StyleSheet.absoluteFill}>
      <Pressable silent style={styles.scrim} onPress={onClose} />
      <Animated.View style={[styles.sheet, { transform: [{ translateY }] }]}>
        <View style={styles.grip} />
        {body}
      </Animated.View>
    </View>
  );
}

// --- the screen ----------------------------------------------------------------------

// As a tab of the app shell (MainScreen) there's no back button (`onBack`
// unset), the nav sits under it (no bottom inset), and `onImmersive` hears
// when the chest opener takes the screen.
// The Shop's first frame, before its tab is built: a big card and a grid of
// smaller ones.
function ShopBones() {
  return (
    <View style={{ gap: 12 }}>
      <BoneCard style={{ gap: 10, alignItems: 'center' }}>
        <Bone w="50%" h={18} r={9} />
        <Bone w={150} h={120} r={24} />
        <Bone w="70%" h={40} r={20} />
      </BoneCard>
      <View style={{ flexDirection: 'row', flexWrap: 'wrap', justifyContent: 'space-between', rowGap: 12 }}>
        {[0, 1, 2, 3].map((i) => (
          <BoneCard key={i} style={{ width: '48.4%', gap: 8, alignItems: 'center' }}>
            <Bone w={80} h={70} r={18} />
            <Bone w="70%" h={12} r={6} />
            <Bone w="85%" h={30} r={15} />
          </BoneCard>
        ))}
      </View>
    </View>
  );
}

// The whole Shop page as placeholders (the header, the tab switch, ShopBones):
// what the Shop's page shows while it slides in to be built (MainScreen).
export const ShopPageBones = memo(function ShopPageBones() {
  const insets = useSafeAreaInsets();
  return (
    <CandyBackground style={{ paddingTop: insets.top }}>
      <View style={styles.header}>
        <Bone w={92} h={34} r={17} tone="sky" />
        <View style={styles.purses}>
          <Bone w={84} h={32} r={16} tone="sky" />
          <Bone w={72} h={32} r={16} tone="sky" />
        </View>
      </View>
      <Bone w="auto" h={46} r={23} tone="sky" style={styles.segOuter} />
      <View style={styles.scroll}>
        <ShopBones />
      </View>
    </CandyBackground>
  );
});

// `openKey`: bumped by App each time something opens the Shop on a tab
// (`startTab`); the Shop goes there without being rebuilt. `hidden`: the
// groups and creatures not out yet; `setRewards`: whether set rewards stay
// out of chests (config/roster)
function ShopScreen({ profile, creatures, offers = null, hidden = HIDDEN, setRewards = SET_REWARDS, onSeenOffer, onBuyProduct, priceOf, onBack, startTab = 'chests', openKey = 0, onImmersive }) {
  const insets = useSafeAreaInsets();
  // the tab's content is built a couple of frames after the Shop opens
  // (placeholders until then), so its first frame is up at once
  const built = useAfterFirstFrame();
  const [tab, setTab] = useState(startTab);
  const seen = useSeenTabs(tab);
  const openedAt = useRef(openKey);
  const [sheet, setSheet] = useState(null);
  // the v6 chest smash: the chests to open, the first one showing (`chest`
  // null while the server's answer is on its way: the smash is up at once,
  // with the scene of `first`, the chest that was tapped); `up` once its page
  // has painted (until then the Shop shows under it)
  const [smash, setSmash] = useState(null); // { chest, first, queue, up }
  useEffect(() => onImmersive?.(!!smash), [smash, onImmersive]);
  const smashShown = useCallback(() => setSmash((s) => s && { ...s, up: true }), []);
  const [toast, setToast] = useState(null);
  // a move on its way (no second one meanwhile); a ref, not state: as
  // state it changed `run`, so every move re-rendered the tabs' cards twice
  // (~2 s of a purchase in a debug build)
  const busy = useRef(false);
  // today's key (picks and deals change with it), moved on at midnight; the
  // countdowns tick by themselves (TickingText)
  const [day, setDay] = useState(() => todayKey(new Date()));
  useEffect(() => {
    const t = setTimeout(() => setDay(todayKey(new Date())), untilMidnight() + 500);
    return () => clearTimeout(t);
  }, [day]);
  const ad = useRewardedAd();
  // each tab is its own page with its own scroll (see the pages below)
  const scrolls = { chests: useRef(null), deals: useRef(null), gems: useRef(null) };
  // opened again on a tab (a purse, GET SEASON CHEST…): that tab, from the
  // top, with no sheet up (it used to be rebuilt for this)
  useEffect(() => {
    if (openedAt.current === openKey) return;
    openedAt.current = openKey;
    setTab(startTab);
    setSheet(null);
    scrolls[startTab]?.current?.scrollTo({ y: 0, animated: false });
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [openKey, startTab]);
  // memoized: the buy handlers depend on it, and the memoized tabs on them
  const w = useMemo(() => wallet(profile), [profile]);
  // the tutorial's view: which sheet is up
  useEffect(() => tutReport({ shopSheet: sheet ? sheet.type : null }), [sheet]);
  useEffect(() => () => tutReport({ shopSheet: null }), []);

  // the catalog's creatures by id (only these have art); what's for sale or
  // in a chest: the ones with art that are out (as the server counts them)
  const catalog = useMemo(() => Object.fromEntries((creatures || []).map((c) => [c.id, c])), [creatures]);
  const artIds = useMemo(() => outIds(Object.keys(catalog), hidden), [catalog, hidden]);

  const flash = useCallback((text) => {
    setToast({ text, key: Date.now() });
  }, []);

  // Runs a squad move; the rule errors become the broke sheet or a toast.
  const run = useCallback(
    async (fn, broke) => {
      if (busy.current) return null;
      busy.current = true;
      try {
        return await fn();
      } catch (e) {
        const code = e.message;
        if ((code === 'not_enough_gems' || code === 'not_enough_coins') && broke) setSheet({ type: 'broke', cur: code === 'not_enough_gems' ? 'gems' : 'coins', need: broke(code) });
        else flash(ERRORS[code] || 'Something went wrong. Try again!');
        return null;
      } finally {
        busy.current = false;
      }
    },
    [flash],
  );

  // A group chest move (squad groupChest / freeChest / adChest / dealChest)
  // of `first` ({ group, size }, the same pick the server makes): the smash
  // comes up at once on that chest and plays the server's answer when it lands.
  const smashKey = useRef(0);
  const openGroup = useCallback(
    async (move, broke, first) => {
      if (busy.current) return;
      setSheet(null);
      setSmash({ chest: null, first, queue: [] });
      const r = await run(move, broke);
      if (!r) return setSmash(null);
      smashKey.current += 1;
      setSmash((s) => ({ ...s, chest: { key: smashKey.current, result: r }, queue: [] }));
    },
    [run],
  );
  const collectSmash = useCallback(() => {
    setSmash((s) => {
      if (!s || !s.queue.length) return null;
      smashKey.current += 1;
      return { ...s, chest: { key: smashKey.current, result: s.queue[0] }, queue: s.queue.slice(1) };
    });
    const r = smash?.chest?.result;
    if (r && r.id) {
      const name = BY_ID[r.id].name;
      // a copy toward unlocking it, the copy that unlocks it, or a duplicate
      flash(r.isNew ? `${name} joined your squad!` : r.copies ? `${name}: ${r.copies} / ${r.need} found` : `${name} again: +${fmt(r.dupeCoins)} coins`);
    }
  }, [smash, flash]);
  const buyGroup = useCallback(
    (gk, size) => {
      const T = SIZES[SIZE_I[size]];
      const cur = T.price.cur;
      if (w[cur] < T.price.n) return setSheet({ type: 'broke', cur, need: T.price.n - w[cur] });
      sfx.play('coin');
      openGroup(() => squad.groupChest(gk, size), () => T.price.n - w[cur], { group: gk, size });
    },
    [openGroup, w],
  );
  const freeGroup = useCallback(() => {
    if ((profile?.freeAt || 0) > Date.now() && !profile?.freeBonus) return flash(ERRORS.not_yet);
    // the welcome chest (a new player's first) is of Mittens' group
    const welcome = !owns(profile || {}, '1') && !profile?.chestOpens;
    openGroup(() => squad.freeChest(), undefined, { group: welcome ? BY_ID['1'].set : lineup(day, hidden)[0], size: 'common' });
  }, [profile, day, hidden, openGroup, flash]);
  const adGroup = useCallback(() => {
    const used = profile?.adChests?.day === day ? profile.adChests.n || 0 : 0;
    if (used >= AD_CHESTS) return flash('No more ad chests today. Back tomorrow!');
    const claim = () => openGroup(() => squad.adChest(), undefined, { group: lineup(day, hidden)[1], size: 'rare' });
    if (profile?.adsFree) return claim();
    if (!ad.ready) return flash('No video right now. Try again in a moment');
    ad.show(claim);
  }, [profile, day, hidden, ad, openGroup, flash]);
  const dealGroup = useCallback(() => {
    if (profile?.dealDay === day) return flash(ERRORS.deal_used);
    if (w.gems < GDEAL.gems) return setSheet({ type: 'broke', cur: 'gems', need: GDEAL.gems - w.gems });
    openGroup(() => squad.dealChest(), () => GDEAL.gems - w.gems, { group: lineup(day, hidden)[0], size: GDEAL.size });
  }, [profile, day, hidden, w, openGroup, flash]);
  const openGroupSheet = useCallback((gk, size) => setSheet({ type: 'gchest', gk, size }), []);
  // chests a purchase or a reward brought (rolled by the server): the smash
  const smashAll = useCallback((list) => {
    const chests = (list || []).filter(Boolean);
    if (!chests.length) return;
    smashKey.current += 1;
    setSheet(null);
    setSmash({ chest: { key: smashKey.current, result: chests[0] }, queue: chests.slice(1) });
  }, []);
  // --- the Deals tab (config/offers) ---
  const buyOffer = useCallback(
    async (o) => {
      if (o.kind === 'noads') return onBuyProduct('removeAds');
      const r = await onBuyProduct(`offer:${o.id}`);
      if (!r) return;
      if (r.granted === 'bundle') smashAll(r.chests);
      else if (r.granted === 'pass') flash('Season pass unlocked!');
      else if (r.granted === 'gems' && r.offer) flash(`Gem jar broken: +${fmt(r.gems)} gems!`);
    },
    [onBuyProduct, smashAll, flash],
  );
  const reward = useCallback(
    (r, what) => {
      if (!r) return;
      if (r.kind === 'chest') smashAll([r.chest]);
      else flash(`${what}+${r.kind === 'coins' ? `${fmt(r.n)} coins` : `${r.n} gems`}`);
    },
    [smashAll, flash],
  );
  const claimStreak = useCallback(async () => {
    const r = await run(() => squad.streakClaim());
    reward(r, r ? `Day ${r.day}: ` : '');
  }, [run, reward]);
  const claimPass = useCallback(
    async (i) => {
      const r = await run(() => squad.passClaim(i));
      reward(r, '');
    },
    [run, reward],
  );
  const seeOffer = useCallback((id, at) => onSeenOffer && onSeenOffer(id, at), [onSeenOffer]);
  const swap = useCallback(
    async (i) => {
      const r = await run(() => squad.swapGems(i), () => SWAPS[i].gems - w.gems);
      if (r) flash(`+${fmt(r.coins)} coins`);
    },
    [run, w, flash],
  );
  const goTab = useCallback((k) => {
    setTab(k);
    setSheet(null);
  }, []);

  // Chests | Squishies | Gems are three pages side by side, like the
  // Squishies screen's: a switch is a native slide started on the tap (Seg's
  // onPick), towards the left going right in the list and back the other
  // way. Every tab is built once (the one shown first, then the others in
  // the background a moment later), so switching never waits on a build.
  const { width: pageW } = useWindowDimensions();
  const order = SEGS.map(([k]) => k);
  const pageX = useRef(new Animated.Value(Math.max(0, order.indexOf(startTab)))).current;
  const pageAt = useRef(Math.max(0, order.indexOf(startTab)));
  const slideTo = useCallback(
    (k) => {
      const to = Math.max(0, order.indexOf(k));
      if (pageAt.current === to) return;
      pageAt.current = to;
      Animated.timing(pageX, { toValue: to, duration: 360, easing: Easing.bezier(0.22, 1, 0.36, 1), useNativeDriver: true }).start();
    },
    // eslint-disable-next-line react-hooks/exhaustive-deps
    [pageX],
  );
  useEffect(() => slideTo(tab), [tab, slideTo]);
  // the other two pages one at a time, a second apart: one big build blocks
  // JS long enough for a tap to wait on it (measured: ~6 s in a debug build
  // when the whole Shop was built at once)
  const [warm, setWarm] = useState(0); // pages built in the background so far
  useEffect(() => {
    if (!built || warm >= 2) return undefined;
    const t = setTimeout(() => setWarm((n) => n + 1), 1000);
    return () => clearTimeout(t);
  }, [built, warm]);
  const isOn = (k) => {
    if (!built) return false;
    if (seen.has(k)) return true;
    // the ones not shown first, in the bar's order
    const rest = order.filter((o) => o !== startTab);
    return rest.indexOf(k) < warm;
  };
  const pageShift = pageX.interpolate({ inputRange: [0, 1, 2], outputRange: [0, -pageW, -2 * pageW] });
  const pageStyle = [styles.scroll, { paddingBottom: 22 + (onBack ? insets.bottom : 0) }];

  const adsUsed = profile?.adChests?.day === day ? profile.adChests.n || 0 : 0;
  const chestBadge = ((profile?.freeAt || 0) <= Date.now() ? 1 : 0) + (adsUsed < AD_CHESTS ? 1 : 0);
  const streakWaiting = profile?.shopStreak?.last !== day;
  const doubleLeft = (offers?.packs || []).some((p) => !(profile?.gemFirst || {})[p.product]) || !offers;
  const badges = { chests: chestBadge ? String(chestBadge) : '', deals: streakWaiting ? '1' : '', gems: doubleLeft ? '2X' : '' };
  // stable, so a re-render of the Shop (a tab switch, a sheet) doesn't
  // re-render all three tabs' content (they're memoized)
  const openOdds = useCallback(() => setSheet({ type: 'odds' }), []);
  const buyPack = useCallback((key) => onBuyProduct(key), [onBuyProduct]);
  const adsFree = !!profile?.adsFree;
  const firstBought = Object.keys(profile?.gemFirst || {})
    .filter((k) => profile.gemFirst[k])
    .sort()
    .join(',');
  const buyNoAds = useCallback(() => (adsFree ? flash('Ads are already off') : onBuyProduct('removeAds')), [adsFree, flash, onBuyProduct]);

  return (
    <CandyBackground style={{ paddingTop: insets.top }}>
      {/* asleep under an open chest: the server's answers (the purchase, the
          roll) change the profile mid-smash, and re-rendering the three tabs
          for it held up the taps */}
      <Freeze freeze={!!smash && !!smash.chest && !!smash.up}>
        <View style={styles.header}>
          {onBack ? (
            <TutTarget name="storeBack">
              <RoundButton size={36} onPress={onBack}>
                <BackGlyph />
              </RoundButton>
            </TutTarget>
          ) : null}
          <OutlinedTitle text="SHOP" fill="pink" size={25} outline={3} ring={2} drop={5} />
          <View style={styles.purses}>
            <Purse cur="coins" amount={w.coins} onPress={() => goTab('gems')} />
            <Purse cur="gems" amount={w.gems} onPress={() => goTab('gems')} />
          </View>
        </View>
        <Seg tab={tab} onPick={slideTo} onTab={goTab} badges={badges} />
        {/* only the page shown has placeholders: the others are built
            unseen, a second apart (or at once when their tab is tapped) */}
        <View style={styles.pager}>
          <Animated.View style={[styles.pageTrack, { width: pageW * 3, transform: [{ translateX: pageShift }] }]}>
            <ScrollView ref={scrolls.chests} style={{ width: pageW }} contentContainerStyle={pageStyle} showsVerticalScrollIndicator={false}>
              <Reveal ready={isOn('chests')} placeholder={tab === 'chests' ? <ShopBones /> : null}>
                <ChestsTabV6
                  profile={profile}
                  day={day}
                  artIds={artIds}
                  hidden={hidden}
                  setRewards={setRewards}
                  onFree={freeGroup}
                  onAd={adGroup}
                  onDeal={dealGroup}
                  onOpenSheet={openGroupSheet}
                  onBuy={buyGroup}
                  onOdds={openOdds}
                />
              </Reveal>
            </ScrollView>
            <ScrollView ref={scrolls.deals} style={{ width: pageW }} contentContainerStyle={pageStyle} showsVerticalScrollIndicator={false}>
              <Reveal ready={isOn('deals')} placeholder={tab === 'deals' ? <ShopBones /> : null}>
                <DealsTab config={offers} profile={profile} day={day} hidden={hidden} priceOf={priceOf} onBuyOffer={buyOffer} onClaimStreak={claimStreak} onClaimPass={claimPass} onNoAds={buyNoAds} onSeen={seeOffer} toast={flash} />
              </Reveal>
            </ScrollView>
            <ScrollView ref={scrolls.gems} style={{ width: pageW }} contentContainerStyle={pageStyle} showsVerticalScrollIndicator={false}>
              <Reveal ready={isOn('gems')} placeholder={tab === 'gems' ? <ShopBones /> : null}>
                <GemsTabV6 config={offers} profile={profile} priceOf={priceOf} onPack={buyPack} onSwap={swap} />
              </Reveal>
            </ScrollView>
          </Animated.View>
        </View>

        <Sheet
          sheet={sheet}
          profile={profile}
          catalog={catalog}
          artIds={artIds}
          setRewards={setRewards}
          wallet={w}
          onBuyGroup={buyGroup}
          onClose={() => setSheet(null)}
          onBroke={() => goTab('gems')}
        />
      </Freeze>
      {toast && <Toast key={toast.key} text={toast.text} bottom={60 + (onBack ? insets.bottom : 0)} onDone={() => setToast(null)} />}
      {smash && <ChestSmash chest={smash.chest} first={smash.first} catalog={catalog} onCollect={collectSmash} onShown={smashShown} />}
    </CandyBackground>
  );
}

function Toast({ text, bottom, onDone }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    Animated.sequence([
      Animated.timing(t, { toValue: 1, duration: 260, easing: Easing.out(Easing.quad), useNativeDriver: true }),
      Animated.delay(1600),
      Animated.timing(t, { toValue: 2, duration: 340, useNativeDriver: true }),
    ]).start(onDone);
  }, [t, onDone]);
  return (
    <Animated.View
      pointerEvents="none"
      style={[styles.toastWrap, { bottom, opacity: t.interpolate({ inputRange: [0, 1, 2], outputRange: [0, 1, 0] }), transform: [{ translateY: t.interpolate({ inputRange: [0, 1, 2], outputRange: [12, 0, -6] }) }] }]}
    >
      <Ringed ring={PINK_RING} lip={4} border={0} innerStyle={styles.toast}>
        <Text style={styles.toastText}>{text}</Text>
      </Ringed>
    </Animated.View>
  );
}

const card = { borderWidth: 3, borderColor: '#ffffff', borderBottomWidth: 3 };
const styles = StyleSheet.create({
  header: { flexDirection: 'row', alignItems: 'center', gap: 8, paddingHorizontal: 14, paddingTop: 8, paddingBottom: 10 },
  purses: { marginLeft: 'auto', flexDirection: 'row', gap: 6 },
  purse: { flexDirection: 'row', alignItems: 'center', gap: 6, paddingLeft: 9, paddingRight: 4, paddingVertical: 3 },
  purseText: { fontFamily: F.black, fontSize: 15 },
  plus: { width: 22, height: 22, borderRadius: 11, borderWidth: 2, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  plusText: { fontFamily: F.black, fontSize: 15, lineHeight: 17, color: '#ffffff' },
  segOuter: { marginHorizontal: 14, marginBottom: 12 },
  seg: { flexDirection: 'row', padding: 4 },
  segPill: { position: 'absolute', left: 4, top: 4, bottom: 4 },
  segItem: { flex: 1, flexDirection: 'row', alignItems: 'center', justifyContent: 'center', gap: 5, paddingVertical: 7 },
  segOn: { fontFamily: F.display, fontSize: 14, letterSpacing: 0.4, color: '#ffffff' },
  segOff: { fontFamily: F.display, fontSize: 14, letterSpacing: 0.4, color: PINK_RING },
  segBadge: { backgroundColor: '#ff2f8f', borderWidth: 1.5, borderColor: '#ffffff', borderRadius: 999, paddingHorizontal: 5 },
  segBadgeText: { fontFamily: F.black, fontSize: 8.5, letterSpacing: 0.6, color: '#ffffff' },
  scroll: { paddingHorizontal: 14, paddingTop: 2 },
  // Chests | Squishies | Gems, side by side (see slideTo)
  pager: { flex: 1, overflow: 'hidden' },
  pageTrack: { flex: 1, flexDirection: 'row' },
  col14: { gap: 14 },
  row10: { flexDirection: 'row', gap: 10 },
  row8: { flexDirection: 'row', gap: 8 },
  rowCenter: { flexDirection: 'row', alignItems: 'center', gap: 6 },
  bigCard: { paddingHorizontal: 8, paddingTop: 8, paddingBottom: 10, alignItems: 'center', gap: 2, overflow: 'hidden' },
  cardRays: { position: 'absolute', left: '50%', top: '30%', marginLeft: -150, marginTop: -150 },
  cardTop: { alignSelf: 'stretch', flexDirection: 'row', justifyContent: 'space-between', alignItems: 'center' },
  cardName: { fontFamily: F.display, fontSize: 16, lineHeight: 18 },
  cardNote: { fontFamily: F.black, fontSize: 10 },
  videoShort: { fontFamily: F.black, fontSize: 10, color: '#0d6a40' },
  play: { color: '#ffffff', fontSize: 11 },
  sold: { marginTop: 4, backgroundColor: '#8a5aa8', borderWidth: 2, borderColor: '#ffffff', borderRadius: 999, paddingHorizontal: 10, paddingVertical: 5 },
  soldText: { fontFamily: F.black, fontSize: 11, color: '#ffffff' },
  pity: { flexDirection: 'row', alignItems: 'center', gap: 10, borderRadius: 20, backgroundColor: '#fff0dc', ...card, borderBottomColor: '#f2c98f', borderBottomWidth: 6, paddingHorizontal: 12, paddingVertical: 8 },
  pityStar: { width: 34, height: 34, borderRadius: 17, borderWidth: 2.5, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  pityStarText: { color: '#ffffff', fontSize: 16, textShadowColor: '#a04a00', textShadowOffset: { width: 0, height: 1 }, textShadowRadius: 0 },
  pityHead: { flexDirection: 'row', justifyContent: 'space-between', alignItems: 'baseline' },
  pityTitle: { fontFamily: F.black, fontSize: 10.5, letterSpacing: 0.8, color: '#c46a00' },
  pityCount: { fontFamily: F.display, fontSize: 14, color: '#7a3a00' },
  pityBar: { flexDirection: 'row', gap: 2 },
  pitySeg: { flex: 1, height: 10, borderRadius: 3, borderWidth: 1.5, borderColor: '#ffffff' },
  pityNote: { fontFamily: F.heavy, fontSize: 10, color: '#9a5a10' },
  titleRow: { flexDirection: 'row', alignItems: 'baseline', justifyContent: 'space-between', marginBottom: -4 },
  link: { fontFamily: F.black, fontSize: 11, color: '#45107a', textDecorationLine: 'underline' },
  small: { fontFamily: F.black, fontSize: 11, color: '#45107a' },
  grid2: { flexDirection: 'row', flexWrap: 'wrap', gap: 10 },
  tierCard: { width: '48.3%', borderRadius: 24, ...card, borderBottomWidth: 8, paddingHorizontal: 8, paddingTop: 8, paddingBottom: 10, alignItems: 'center', gap: 3, overflow: 'hidden' },
  tierChip: { alignSelf: 'flex-start', borderRadius: 999, paddingHorizontal: 7, paddingVertical: 1 },
  tierChipText: { fontFamily: F.black, fontSize: 9, letterSpacing: 0.8, color: '#ffffff' },
  tierArt: { width: 112, height: 104 },
  tierShadow: { position: 'absolute', left: 8, bottom: 2, width: 96, height: 18, borderRadius: 48, opacity: 0.6 },
  tierName: { fontFamily: F.display, fontSize: 17, lineHeight: 19, color: '#4a1a73' },
  tierBest: { fontFamily: F.black, fontSize: 10 },
  wideCard: { flexDirection: 'row', alignItems: 'center', gap: 6, paddingVertical: 10, paddingLeft: 6, paddingRight: 14, overflow: 'hidden' },
  rainbowRays: { position: 'absolute', left: -80, top: '50%', marginTop: -180 },
  wideName: { fontFamily: F.display, fontSize: 24, lineHeight: 27, color: '#ffffff' },
  wideNote: { fontFamily: F.black, fontSize: 11, lineHeight: 14, color: '#5a22c8' },
  seasonNote: { fontFamily: F.heavy, fontSize: 11, lineHeight: 15, color: '#ffe9c4' },
  pick: { alignItems: 'center', gap: 2, paddingHorizontal: 4, paddingVertical: 8 },
  pickOff: { alignSelf: 'flex-start', backgroundColor: '#ff2f8f', borderRadius: 999, paddingHorizontal: 6, paddingVertical: 1, marginLeft: 2 },
  pickOffText: { fontFamily: F.black, fontSize: 8.5, letterSpacing: 0.8, color: '#ffffff' },
  pickName: { fontFamily: F.display, fontSize: 14, lineHeight: 16, color: '#4a1a73' },
  pickRar: { backgroundColor: 'rgba(255,255,255,0.75)', borderRadius: 999, paddingHorizontal: 6 },
  pickRarText: { fontFamily: F.black, fontSize: 8.5, letterSpacing: 0.8, color: '#4a1a73' },
  pickPrice: { alignItems: 'center', paddingHorizontal: 10, paddingVertical: 2 },
  pickOld: { fontFamily: F.heavy, fontSize: 9, lineHeight: 10, color: GOLD_RING, textDecorationLine: 'line-through' },
  center: { fontFamily: F.heavy, fontSize: 12, color: '#45107a', textAlign: 'center' },
  setName: { borderRadius: 999, borderWidth: 2, borderColor: '#ffffff', borderBottomWidth: 3, paddingHorizontal: 10, paddingVertical: 1 },
  setNameText: { fontFamily: F.display, fontSize: 13, color: '#ffffff' },
  grid4: { flexDirection: 'row', flexWrap: 'wrap', gap: 6 },
  cell: { width: '23.4%', borderRadius: 16, borderWidth: 2.5, borderColor: '#ffffff', borderBottomWidth: 5, alignItems: 'center', gap: 2, paddingHorizontal: 2, paddingTop: 5, paddingBottom: 6 },
  cellDot: { position: 'absolute', top: 4, left: 4, width: 8, height: 8, borderRadius: 4, borderWidth: 1.5, borderColor: '#ffffff' },
  cellName: { maxWidth: '100%', fontFamily: F.display, fontSize: 11.5, lineHeight: 13, color: '#4a1a73' },
  egg: { width: 38, height: 34, borderRadius: 17, backgroundColor: '#dccbf2', borderWidth: 2.5, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  eggText: { fontFamily: F.display, fontSize: 15, color: '#ffffff' },
  tag: { marginTop: 2, borderRadius: 999, paddingHorizontal: 6, paddingVertical: 1, backgroundColor: '#ffffff', borderWidth: 2 },
  tagText: { fontFamily: F.display, fontSize: 10 },
  foot: { fontFamily: F.bold, fontSize: 10.5, lineHeight: 15, color: 'rgba(255,255,255,0.9)', textAlign: 'center', paddingHorizontal: 10 },
  grid3: { flexDirection: 'row', flexWrap: 'wrap', columnGap: 8, rowGap: 14 },
  packWrap: { width: '31.6%' },
  pack: { borderRadius: 20, ...card, borderBottomColor: '#a9b8f2', borderBottomWidth: 6, paddingTop: 14, paddingBottom: 9, paddingHorizontal: 4, alignItems: 'center', gap: 6 },
  packAmount: { fontFamily: F.display, fontSize: 17, lineHeight: 19, color: '#45189a' },
  packBonus: { fontFamily: F.black, fontSize: 9, color: '#16a86a', marginTop: -3 },
  packTag: { position: 'absolute', top: -9, alignSelf: 'center', backgroundColor: '#ff2f8f', borderWidth: 2, borderColor: '#ffffff', borderRadius: 999, paddingHorizontal: 7, paddingVertical: 1 },
  packTagText: { fontFamily: F.black, fontSize: 8.5, letterSpacing: 0.8, color: '#ffffff' },
  swap: { flex: 1, borderRadius: 18, backgroundColor: '#fff6d6', ...card, borderBottomColor: '#ecd078', borderBottomWidth: 6, paddingTop: 10, paddingBottom: 9, paddingHorizontal: 4, alignItems: 'center', gap: 5 },
  swapAmount: { fontFamily: F.display, fontSize: 15, color: '#b86200' },
  swapCost: { flexDirection: 'row', alignItems: 'center', gap: 5, paddingHorizontal: 10, paddingVertical: 3 },
  noAds: { flexDirection: 'row', alignItems: 'center', gap: 12, borderRadius: 22, backgroundColor: '#ffffff', ...card, borderBottomColor: '#e2a9d6', borderBottomWidth: 6, paddingHorizontal: 12, paddingVertical: 10 },
  noAdsIcon: { width: 46, height: 46, borderRadius: 14, borderWidth: 2.5, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  noAdsIconText: { fontFamily: F.display, fontSize: 15, color: '#ffffff' },
  noAdsSlash: { position: 'absolute', left: 6, right: 6, top: '50%', height: 3, marginTop: -1.5, backgroundColor: '#ffffff', borderRadius: 2, transform: [{ rotate: '-35deg' }] },
  noAdsTitle: { fontFamily: F.display, fontSize: 16, color: '#4a1a73' },
  noAdsNote: { fontFamily: F.heavy, fontSize: 11, color: '#8a5aa8' },
  scrim: { ...StyleSheet.absoluteFillObject, backgroundColor: 'rgba(30,0,60,0.55)' },
  // a group chest's sheet scrolls when it's taller than the screen allows
  sheetScroll: { alignSelf: 'stretch', maxHeight: Dimensions.get('window').height * 0.78 },
  sheet: { position: 'absolute', left: 0, right: 0, bottom: 0, paddingTop: 20, paddingHorizontal: 18, paddingBottom: 30, borderTopLeftRadius: 30, borderTopRightRadius: 30, backgroundColor: '#fbefff', borderTopWidth: 3, borderColor: '#ffffff', alignItems: 'center', gap: 10 },
  grip: { width: 44, height: 5, borderRadius: 999, backgroundColor: '#e0c8f2', marginTop: -8 },
  sheetTitle: { fontFamily: F.display, fontSize: 24, color: PINK_RING, textAlign: 'center' },
  sheetSub: { fontFamily: F.heavy, fontSize: 13, color: '#6a1b9a', textAlign: 'center' },
  later: { flex: 1, alignItems: 'center', justifyContent: 'center', borderWidth: 3, borderColor: '#e0c8f2', borderBottomWidth: 6, borderBottomColor: '#d6b8ee', borderRadius: 999, paddingVertical: 11, backgroundColor: '#ffffff' },
  laterText: { fontFamily: F.display, fontSize: 16, color: PINK_RING },
  pressed: { transform: [{ translateY: 3 }] },
  oddsRow: { flexDirection: 'row', alignItems: 'center', gap: 8, borderRadius: 14, paddingHorizontal: 10, paddingVertical: 6 },
  oddsName: { fontFamily: F.display, fontSize: 14, color: '#4a1a73', width: 62 },
  oddsChips: { flex: 1, flexDirection: 'row', flexWrap: 'wrap', gap: 3 },
  oddsChip: { borderWidth: 1.5, borderColor: '#ffffff', borderRadius: 999, paddingHorizontal: 5 },
  oddsChipText: { fontFamily: F.display, fontSize: 9.5, color: '#4a1a73' },
  pvArt: { width: 170, height: 170, alignItems: 'center', justifyContent: 'center' },
  pvGlow: { position: 'absolute', width: 150, height: 150, borderRadius: 75, opacity: 0.35 },
  pvRar: { borderWidth: 2, borderColor: '#ffffff', borderRadius: 999, paddingHorizontal: 8, paddingVertical: 1 },
  pvRarText: { fontFamily: F.black, fontSize: 10, letterSpacing: 1, color: '#4a1a73' },
  finChip: { borderWidth: 2, borderColor: '#ffffff', borderRadius: 999, paddingHorizontal: 7, paddingVertical: 1 },
  finChipText: { fontFamily: F.black, fontSize: 9.5, letterSpacing: 0.6, color: '#4a1a73' },
  finNote: { fontFamily: F.bold, fontSize: 10.5, color: '#a07cc0', marginTop: -4 },
  already: { alignSelf: 'stretch', alignItems: 'center', marginTop: 4, borderWidth: 3, borderColor: '#e0c8f2', borderRadius: 999, paddingVertical: 12, backgroundColor: '#ffffff' },
  alreadyText: { fontFamily: F.display, fontSize: 17, color: '#a07cc0' },
  pvOld: { fontFamily: F.heavy, fontSize: 13, color: GOLD_RING, textDecorationLine: 'line-through' },
  toastWrap: { position: 'absolute', alignSelf: 'center', zIndex: 20 },
  toast: { paddingHorizontal: 16, paddingVertical: 8 },
  toastText: { fontFamily: F.display, fontSize: 14, color: PINK_RING },
});

// memo: App re-renders on things the Shop doesn't show (the bottom nav's tab…)
export default memo(ShopScreen);
