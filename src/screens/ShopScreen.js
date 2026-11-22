import React, { forwardRef, memo, useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { Animated, Dimensions, Easing, Image, ScrollView, StyleSheet, Text, View, useWindowDimensions } from 'react-native';
import Pressable from '../components/Pressable';
import useRewardedAd from '../components/useRewardedAd';
import { todayKey } from '../dailySpin';
import sfx from '../audio/sfx';
import { BY_ID, GDEAL, GROUPS, HIDDEN, RAINBOW, SET_REWARDS, SIZES, SIZE_I, SWAPS, AD_CHESTS, lineup, outIds, owns, rainbowProgress, rainbowReady, wallet } from '../squad/data';
import * as squad from '../squad/api';
import { BtnText, CandyBtn, F, PINK_RING, Ringed, untilMidnight } from '../squad/ui';
import { ChestSheetBody, OddsSheetBody } from './ShopChests';
import ChestSmash from '../components/ChestSmash';
import { FlyLayer, centerOf, flyReward, usePurse } from '../components/RewardFx';
import VaultLoader, { buddyUriOf } from '../components/VaultLoader';
import { DealsTab, GemsTab } from './ShopDeals';
import ShopChestsRoyal, { ShopDailyRoyal } from './royal/ShopChestsRoyal';
import { Icon, InkText, Orb, PageHeader, Plaque, Stage, WoodBg, FONT as RFONT, INK as RINK } from '../royal';
import { COIN, GEM } from '../squad/currencyArt';
import Freeze from '../components/Freeze';
import { useAfterFirstFrame } from '../components/Skeleton';
import { fmtNum } from '../format';

// The Shop, sideways in the wood look (REDESIGN_V7: the menu's SHOP opens it as a screen of its own), on the squad
// economy (src/squad, run by the `squad` Cloud Function). Five tabs across the top (R_TABS):
//  · Daily — today's free chest, the ad chest and the daily deal (royal/ShopChestsRoyal.js ShopDailyRoyal);
//  · Chests — every group's chests (royal/ShopChestsRoyal.js); every chest opens as soon as it's got;
//  · Deals and Special offers — config/offers (ShopDeals.js DealsTab), the bundles on Special offers;
//  · Gems — the gem packs (real money) and gems → coins (ShopDeals.js GemsTab).
// No squishy is sold for coins: one unlocks only by being found in chests enough times (functions/squad.js COPIES).
//
// Every move goes to the server; the profile listener brings the result in.

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
  need_xp: 'Open more chests to earn pass XP first',
  need_pass: 'This reward needs the season pass',
  season_over: 'The season is over',
  unknown_reward: 'That reward isn\'t there any more',
  rainbow_locked: 'Unlock the rest of the group first',
  rainbow_opened: 'That Rainbow chest is already open',
};
const GROUP_NAME = Object.fromEntries(GROUPS.map((g) => [g.key, g.name]));
const fmt = fmtNum;

// The coin / gem counter in the new look (REDESIGN_V7): the menu's pill, counting up as a reward flies in.
const RoyalPurse = forwardRef(function RoyalPurse({ cur, amount, onPress }, ref) {
  const { icon, scale, shown } = usePurse(ref, amount);
  return (
    <Animated.View style={{ transform: [{ scale }] }}>
      <Plaque variant="vel" onPress={onPress} style={styles.rPill}>
        <View ref={icon} collapsable={false} style={styles.rPillIcon}>
          <Image source={cur === 'gems' ? GEM[0] : COIN[0]} style={styles.rPillImg} />
        </View>
        <InkText size={13.5}>{fmt(shown)}</InkText>
      </Plaque>
    </Animated.View>
  );
});
// (REDESIGN_V8, the user: today's free chest, ad chest, deal and Lucky meter get a tab of their own, left of Chests)
const R_TABS = [
  ['daily', 'Daily', 'M4 6h16v14H4Z M4 10h16 M8 3v4 M16 3v4 M9 15l2 2 4-4'],
  ['chests', 'Chests', 'M4 10h16v9H4Z M4 10l2-5h12l2 5 M12 10v4'],
  ['deals', 'Deals', 'M3 12V4h8l10 10-8 8Z M7.5 7.5h.01'],
  // (2026-11-16, the user: the bundles moved here out of Deals)
  ['special', 'Special offers', 'M4 11h16v10H4Z M3 7h18v4H3Z M12 7v14 M12 7C10 3 6 3 6 5.5S12 7 12 7 M12 7c2-4 6-4 6-1.5S12 7 12 7'],
  ['gems', 'Gems', 'M6 3h12l4 6-10 12L2 9Z M2 9h20 M9 3l3 6 3-6'],
];
const R_ORDER = R_TABS.map(([k]) => k);

// --- the sheet ---------------------------------------------------------------------

// A chest's details, every size's odds, or "Not enough gems / coins": a pearl panel in the middle with a close orb
// (REDESIGN_V7)
function Sheet({ sheet, profile, catalog, artIds, setRewards, rainbow, wallet: w, onClose, onBroke, onBuyGroup }) {
  const up = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    up.setValue(0);
    Animated.spring(up, { toValue: 1, friction: 8, tension: 80, useNativeDriver: true }).start();
  }, [sheet, up]);
  if (!sheet) return null;
  let body = null;
  if (sheet.type === 'odds') {
    body = <OddsSheetBody rainbow={rainbow} />;
  } else if (sheet.type === 'gchest') {
    body = <ChestSheetBody gk={sheet.gk} size={sheet.size} profile={profile} artIds={artIds} setRewards={setRewards} rainbow={rainbow} catalog={catalog} wallet={w} onBuy={onBuyGroup} />;
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
    <View style={[StyleSheet.absoluteFill, styles.rSheetWrap]}>
      <Pressable silent style={styles.scrim} onPress={onClose} />
      <Animated.View style={{ opacity: up, transform: [{ scale: up.interpolate({ inputRange: [0, 1], outputRange: [0.92, 1] }) }] }}>
        <Plaque variant="pearl" radius={24} rim={3.5} ring={2} lip={4} style={[styles.rSheet, sheet.type === 'gchest' && styles.rSheetWide, sheet.type === 'broke' && styles.rSheetNarrow]}>
          <ScrollView style={styles.rSheetScroll} contentContainerStyle={{ paddingBottom: 6, gap: 10 }} showsVerticalScrollIndicator={false}>
            {body}
          </ScrollView>
        </Plaque>
        <Orb icon="close" size={36} onPress={onClose} style={styles.rSheetX} />
      </Animated.View>
    </View>
  );
}

// --- the screen ----------------------------------------------------------------------

// `openKey`: bumped by App each time something opens the Shop on a tab
// (`startTab`); the Shop goes there without being rebuilt. `hidden`: the
// groups and creatures not out yet; `setRewards`: whether set rewards stay
// out of chests; `rainbow`: Rainbow chests earned once per group ('chest')
// or sold ('shop') (config/roster)
function ShopScreen({ profile, creatures, offers = null, hidden = HIDDEN, setRewards = SET_REWARDS, rainbow = RAINBOW, onSeenOffer, onBuyProduct, priceOf, onBack, startTab = 'chests', openKey = 0 }) {
  // the tab's content is built a couple of frames after the Shop opens
  // (nothing under the tabs until then), so its first frame is up at once
  const built = useAfterFirstFrame();
  const [tab, setTab] = useState(startTab);
  const openedAt = useRef(openKey);
  const [sheet, setSheet] = useState(null);
  // the v6 chest smash: the chests to open, the first one showing (`chest`
  // null while the server's answer is on its way: the smash is up at once,
  // with the scene of `first`, the chest that was tapped); `up` once its page
  // has painted (until then the Shop shows under it)
  const [smash, setSmash] = useState(null); // { chest, first, queue, up }
  const smashShown = useCallback(() => setSmash((s) => s && { ...s, up: true }), []);
  // "To the treasure vault" (REDESIGN_V9: the user's loading screen for going to open a chest) over every smash
  // until its page has painted (`up`), then it plays its way out; once a smash, so a bundle's next chests (the same
  // page) don't show it again. It replaced the chest dropping in that covered a claimed chest's load (Deals).
  const [vaultGone, setVaultGone] = useState(false);
  const smashOn = !!smash;
  useEffect(() => {
    if (!smashOn) setVaultGone(false);
  }, [smashOn]);
  const vaultDone = useCallback(() => setVaultGone(true), []);
  const buddy = useMemo(() => buddyUriOf(creatures, profile), [creatures, profile]);
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
  // opened again on a tab (a purse, GET SEASON CHEST…): that tab, with no sheet
  // up (it used to be rebuilt for this)
  useEffect(() => {
    if (openedAt.current === openKey) return;
    openedAt.current = openKey;
    setTab(startTab);
    setSheet(null);
  }, [openKey, startTab]);
  // memoized: the buy handlers depend on it, and the memoized tabs on them
  const w = useMemo(() => wallet(profile), [profile]);

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
      if (r.rainbow) flash(`${name} joined! The ${GROUP_NAME[r.rainbow]} Rainbow chest is yours to open`);
      else flash(r.isNew ? `${name} joined your squad!` : r.copies ? `${name}: ${r.copies} / ${r.need} found` : `${name} again: +${fmt(r.dupeCoins)} coins`);
    }
  }, [smash, flash]);
  // A group's earned Rainbow chest (squad rainbowChest): free, once, when
  // the rest of the group is unlocked; until then, or once it's open, a note.
  const openRainbow = useCallback(
    (gk) => {
      const p = profile || {};
      const r = rainbowProgress(p, gk, artIds);
      if (!r.reward || !artIds.includes(r.reward)) return flash(`${GROUP_NAME[gk]} has no Rainbow chest`);
      if (owns(p, r.reward)) return flash(`${BY_ID[r.reward].name} is already in your squad`);
      if (!rainbowReady(p, gk, artIds)) return flash(`Unlock every ${GROUP_NAME[gk]} pal to earn it: ${r.have} / ${r.need}`);
      sfx.play('coin');
      openGroup(() => squad.rainbowChest(gk), undefined, { group: gk, size: 'set' });
    },
    [profile, artIds, openGroup, flash],
  );
  const buyGroup = useCallback(
    (gk, size) => {
      // (a Rainbow chest isn't sold while they're earned: it's opened)
      if (size === 'set' && rainbow === 'chest') return openRainbow(gk);
      const T = SIZES[SIZE_I[size]];
      const cur = T.price.cur;
      if (w[cur] < T.price.n) return setSheet({ type: 'broke', cur, need: T.price.n - w[cur] });
      sfx.play('coin');
      openGroup(() => squad.groupChest(gk, size), () => T.price.n - w[cur], { group: gk, size });
    },
    [openGroup, openRainbow, rainbow, w],
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
  // The Deals tab's claims (the streak's day, a season pass reward), as on
  // the level road: the counters hold still while the server answers, then
  // the coins or gems fly out of the prize's icon (`from`: { view, img }) and
  // the counter counts up as they land; a chest opens in the smash behind the
  // treasure vault loading screen.
  const fly = useRef(null);
  const coinPurse = useRef(null);
  const gemPurse = useRef(null);
  const wRef = useRef(w);
  wRef.current = w;
  const claiming = useRef(false); // from the tap until the counters let go
  const releasePurses = useCallback(() => {
    coinPurse.current?.release();
    gemPurse.current?.release();
    claiming.current = false;
  }, []);
  // the counters let go once the profile has the claim (the server writes
  // the coins or gems in the same go, so the wallet moves off `from`), or
  // after a while
  const [settle, setSettle] = useState(null); // { cur, from }
  useEffect(() => {
    if (!settle) return undefined;
    const go = () => {
      releasePurses();
      setSettle(null);
    };
    if (w[settle.cur] !== settle.from) {
      go();
      return undefined;
    }
    const t = setTimeout(go, 20000);
    return () => clearTimeout(t);
  }, [settle, w, releasePurses]);
  const claimReward = useCallback(
    async (move, from) => {
      if (claiming.current) return;
      claiming.current = true;
      const base = wRef.current;
      coinPurse.current?.hold(base.coins);
      gemPurse.current?.hold(base.gems);
      const r = await run(move);
      if (!r || r.kind === 'chest') {
        releasePurses();
        if (!r) return;
        smashKey.current += 1;
        setSheet(null);
        setSmash({ chest: { key: smashKey.current, result: r.chest }, queue: [] });
        return;
      }
      const cur = r.kind === 'gems' ? 'gems' : 'coins';
      let at = await centerOf(from && from.view);
      // its icon scrolled out of sight: out of the middle of the screen
      const win = Dimensions.get('window');
      if (at && (at.y < 90 || at.y > win.height - 40)) at = { x: win.width / 2, y: win.height / 2 };
      sfx.play('coinShower');
      flyReward({
        layer: fly.current,
        from: at,
        purse: cur === 'gems' ? gemPurse.current : coinPurse.current,
        n: r.n,
        gem: cur === 'gems',
        img: from && from.img,
        onDone: () => setSettle({ cur, from: base[cur] }),
      });
    },
    [run, releasePurses],
  );
  const claimStreak = useCallback((from) => claimReward(() => squad.streakClaim(), from), [claimReward]);
  const claimPass = useCallback((i, from) => claimReward(() => squad.passClaim(i), from), [claimReward]);
  const seeOffer = useCallback((id, at) => onSeenOffer && onSeenOffer(id, at), [onSeenOffer]);
  const swap = useCallback(
    async (i) => {
      const r = await run(() => squad.swapGems(i), () => SWAPS[i].gems - w.gems);
      if (r) flash(`+${fmt(r.coins)} coins`);
    },
    [run, w, flash],
  );
  // The tab switch slides (2026-11-17, the user): to a tab right of this one, the items on show leave to
  // the left and the new ones come in from the right; to one on the left, the other way. Both pages ride one native
  // timing (`tabSwap.t`), started once the new page has been drawn at its start (render before animating: a timing
  // started in the render that builds the page waits on that build on Android). Opening the Shop on a tab (openKey)
  // just shows it.
  const tabRef = useRef(tab);
  tabRef.current = tab;
  const [tabSwap, setTabSwap] = useState(null); // { from, to, dir: 1 rightwards | -1, t }
  const goTab = useCallback(
    (k) => {
      const from = tabRef.current;
      if (k !== from) {
        const dir = R_ORDER.indexOf(k) > R_ORDER.indexOf(from) ? 1 : -1;
        setTabSwap({ from, to: k, dir, t: new Animated.Value(0) });
      }
      setTab(k);
      setSheet(null);
    },
    [],
  );
  useEffect(() => {
    if (!tabSwap) return undefined;
    let second = null;
    let anim = null;
    const first = requestAnimationFrame(() => {
      second = requestAnimationFrame(() => {
        anim = Animated.timing(tabSwap.t, { toValue: 1, duration: 400, easing: Easing.bezier(0.4, 0, 0.2, 1), useNativeDriver: true });
        anim.start(({ finished }) => finished && setTabSwap((s) => (s === tabSwap ? null : s)));
      });
    });
    return () => {
      cancelAnimationFrame(first);
      if (second != null) cancelAnimationFrame(second);
      if (anim) anim.stop();
    };
  }, [tabSwap]);

  const { width: pageW, height: pageH } = useWindowDimensions();
  // the switch (goTab): the two pages' slides, a whole page width (the Stage's, in its units) each way
  const stageW = (Math.max(pageW, pageH) * 393) / Math.min(pageW, pageH);
  const slide = useMemo(() => {
    if (!tabSwap || tabSwap.to !== tab) return null;
    const { t, dir, from } = tabSwap;
    return {
      from,
      outX: t.interpolate({ inputRange: [0, 1], outputRange: [0, -dir * stageW] }),
      inX: t.interpolate({ inputRange: [0, 1], outputRange: [dir * stageW, 0] }),
    };
  }, [tabSwap, tab, stageW]);

  const adsUsed = profile?.adChests?.day === day ? profile.adChests.n || 0 : 0;
  const chestBadge = ((profile?.freeAt || 0) <= Date.now() ? 1 : 0) + (adsUsed < AD_CHESTS ? 1 : 0);
  const streakWaiting = profile?.shopStreak?.last !== day;
  const doubleLeft = (offers?.packs || []).some((p) => !(profile?.gemFirst || {})[p.product]) || !offers;
  const badges = { chests: chestBadge ? String(chestBadge) : '', deals: streakWaiting ? '1' : '', gems: doubleLeft ? '2X' : '' };
  // stable, so a re-render of the Shop (a tab switch, a sheet) doesn't
  // re-render the tabs' content (they're memoized)
  const openOdds = useCallback(() => setSheet({ type: 'odds' }), []);
  const buyPack = useCallback((key) => onBuyProduct(key), [onBuyProduct]);
  const adsFree = !!profile?.adsFree;
  const buyNoAds = useCallback(() => (adsFree ? flash('Ads are already off') : onBuyProduct('removeAds')), [adsFree, flash, onBuyProduct]);

  return (
    <View style={styles.rRoot}>
      <WoodBg />
      {/* asleep under an open chest: the server's answers (the purchase, the roll) change the profile mid-smash, and
          re-rendering the tabs for it held up the taps */}
      <Freeze freeze={!!smash && !!smash.chest && !!smash.up}>
        <Stage>
          {/* REDESIGN_V8 (the user): the tabs across the top, centred under the title; no note line */}
          <PageHeader
            title="Shop"
            onBack={onBack}
            right={
              <View style={styles.rPurses}>
                <RoyalPurse ref={coinPurse} cur="coins" amount={w.coins} onPress={() => goTab('gems')} />
                <RoyalPurse ref={gemPurse} cur="gems" amount={w.gems} onPress={() => goTab('gems')} />
              </View>
            }
          />
          <View style={styles.rTabs}>
            {R_TABS.map(([k, label, d]) => {
              const on = k === tab;
              // the free / ad chests' count shows on Daily, where they are now
              const badge = k === 'daily' ? badges.chests : k === 'chests' ? '' : badges[k];
              return (
                <Plaque key={k} variant={on ? 'gold' : 'vel'} radius={16} onPress={() => goTab(k)} style={styles.rTab}>
                  <Icon d={d} size={18} color={on ? RINK : '#fff6e2'} width={2.4} drop={!on} />
                  {on ? <Text style={styles.rTabOn}>{label}</Text> : <InkText size={16}>{label}</InkText>}
                  {badge ? (
                    <View style={styles.rBadge}>
                      <Text style={styles.rBadgeT}>{badge}</Text>
                    </View>
                  ) : null}
                </Plaque>
              );
            })}
          </View>
          <View style={styles.rBody}>
            {/* the page on show, and while a switch slides, the one leaving (each on its own layer, by its key, so
                the page coming in stays the same page once the slide is over) */}
            {built
              ? (slide ? [slide.from, tab] : [tab]).map((k) => {
                  const out = !!slide && k === slide.from;
                  return (
                    <Animated.View key={k} pointerEvents={out ? 'none' : 'auto'} style={[StyleSheet.absoluteFill, slide && { transform: [{ translateX: out ? slide.outX : slide.inX }] }]}>
                      {k === 'daily' ? <ShopDailyRoyal profile={profile} day={day} hidden={hidden} onFree={freeGroup} onAd={adGroup} onDeal={dealGroup} /> : null}
                      {k === 'chests' ? (
                        <ShopChestsRoyal profile={profile} day={day} artIds={artIds} hidden={hidden} setRewards={setRewards} rainbow={rainbow} onFree={freeGroup} onAd={adGroup} onDeal={dealGroup} onOpenSheet={openGroupSheet} onBuy={buyGroup} onOdds={openOdds} />
                      ) : null}
                      {k === 'deals' ? (
                        <ScrollView horizontal showsHorizontalScrollIndicator={false} contentContainerStyle={[styles.rShelf, styles.rCentre]}>
                          <DealsTab part="deals" config={offers} profile={profile} day={day} hidden={hidden} priceOf={priceOf} onBuyOffer={buyOffer} onClaimStreak={claimStreak} onClaimPass={claimPass} onNoAds={buyNoAds} onSeen={seeOffer} toast={flash} />
                        </ScrollView>
                      ) : null}
                      {k === 'special' ? (
                        <ScrollView horizontal showsHorizontalScrollIndicator={false} contentContainerStyle={[styles.rShelf, styles.rCentre]}>
                          <DealsTab part="special" config={offers} profile={profile} day={day} hidden={hidden} priceOf={priceOf} onBuyOffer={buyOffer} onClaimStreak={claimStreak} onClaimPass={claimPass} onNoAds={buyNoAds} onSeen={seeOffer} toast={flash} />
                        </ScrollView>
                      ) : null}
                      {k === 'gems' ? (
                        <View style={styles.rGems}>
                          <GemsTab config={offers} profile={profile} priceOf={priceOf} onPack={buyPack} onSwap={swap} />
                        </View>
                      ) : null}
                    </Animated.View>
                  );
                })
              : null}
          </View>
          <Sheet sheet={sheet} profile={profile} catalog={catalog} artIds={artIds} setRewards={setRewards} rainbow={rainbow} wallet={w} onBuyGroup={buyGroup} onClose={() => setSheet(null)} onBroke={() => goTab('gems')} />
        </Stage>
      </Freeze>
      {/* (high up, by the header: at the bottom it sat behind the cards' buttons) */}
      {toast && <Toast key={toast.key} text={toast.text} bottom={Dimensions.get('window').height - 70} onDone={() => setToast(null)} />}
      <FlyLayer ref={fly} />
      {/* a chest's smash loads unseen under the treasure vault loading screen, and shows as it plays its way out */}
      {smash && (
        <View style={StyleSheet.absoluteFill} pointerEvents="box-none">
          <ChestSmash chest={smash.chest} first={smash.first} catalog={catalog} onCollect={collectSmash} onShown={smashShown} />
        </View>
      )}
      {smash && !vaultGone && <VaultLoader ready={!!smash.up} uri={buddy} onDone={vaultDone} />}
    </View>
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

const styles = StyleSheet.create({
  // the new look (REDESIGN_V7), in the design's 393-tall units (Stage)
  rRoot: { flex: 1, backgroundColor: '#d27c3e' },
  rPurses: { flexDirection: 'row', alignItems: 'center', gap: 9 },
  // (REDESIGN_V8: the coin / gem picture big, over the pill's left end, as on the menu)
  rPill: { height: 32, flexDirection: 'row', alignItems: 'center', paddingLeft: 32, paddingRight: 14, marginLeft: 14 },
  rPillIcon: { position: 'absolute', left: -15, top: -6, width: 44, height: 44 },
  rPillImg: { width: 44, height: 44, resizeMode: 'contain' },
  // the tabs across the top, centred under the title (REDESIGN_V8; were a column down the left)
  // (five since Special offers, 2026-11-16: a little narrower, Special offers as wide as its name, to fit a 16:9 phone)
  rTabs: { position: 'absolute', left: 0, right: 0, top: 62, height: 40, flexDirection: 'row', justifyContent: 'center', gap: 12 },
  rTab: { height: 36, minWidth: 112, flexDirection: 'row', gap: 7, paddingHorizontal: 12 },
  rTabOn: { fontFamily: RFONT.display, fontSize: 16, color: RINK, includeFontPadding: false },
  rBadge: { position: 'absolute', right: -8, top: -8, minWidth: 20, height: 20, paddingHorizontal: 5, borderRadius: 10, backgroundColor: '#ff5a2a', borderWidth: 2, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  rBadgeT: { fontFamily: RFONT.bodyBlack, fontSize: 10, color: '#ffffff', includeFontPadding: false },
  rBody: { position: 'absolute', left: 0, right: 0, top: 108, bottom: 0 },
  rShelf: { paddingLeft: 24, paddingRight: 24 },
  rCentre: { flexGrow: 1, justifyContent: 'center' },
  rGems: { flex: 1, paddingHorizontal: 24 },
  rSheetWrap: { alignItems: 'center', justifyContent: 'center' },
  rSheet: { width: 540, maxHeight: 340, paddingHorizontal: 18, paddingTop: 16, paddingBottom: 14 },
  // a chest's sheet: the chest beside its details (REDESIGN_V8)
  rSheetWide: { width: 700, maxHeight: 352 },
  // "Not enough gems / coins": a short card, so a narrow panel
  rSheetNarrow: { width: 340 },
  rSheetScroll: { alignSelf: 'stretch' },
  rSheetX: { position: 'absolute', right: -12, top: -12 },
  scrim: { ...StyleSheet.absoluteFillObject, backgroundColor: 'rgba(30,0,60,0.55)' },
  sheetTitle: { fontFamily: F.display, fontSize: 24, color: PINK_RING, textAlign: 'center' },
  sheetSub: { fontFamily: F.heavy, fontSize: 13, color: '#6a1b9a', textAlign: 'center' },
  toastWrap: { position: 'absolute', alignSelf: 'center', zIndex: 20 },
  toast: { paddingHorizontal: 16, paddingVertical: 8 },
  toastText: { fontFamily: F.display, fontSize: 14, color: PINK_RING },
});

// memo: App re-renders on things the Shop doesn't show
export default memo(ShopScreen);
