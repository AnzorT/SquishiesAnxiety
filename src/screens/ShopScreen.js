import React, { memo, useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { Animated, Easing, Pressable, ScrollView, StyleSheet, Text, View, useWindowDimensions } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { LinearGradient } from 'expo-linear-gradient';
import CandyBackground from '../components/candy/CandyBackground';
import RoundButton, { BackGlyph } from '../components/candy/RoundButton';
import OutlinedTitle from '../components/candy/OutlinedTitle';
import ShadowText, { outline3 } from '../components/candy/ShadowText';
import { RaysSpin } from '../components/candy/Decor';
import CreatureThumbnail from '../components/CreatureThumbnail';
import useRewardedAd from '../components/useRewardedAd';
import { PRODUCTS, GEM_KEYS } from '../economy';
import { todayKey } from '../dailySpin';
import sfx from '../audio/sfx';
import {
  BY_ID, CHESTS, CHEST_LOOK, CHEST_ORDER, COIN_PRICE, DEAL, PITY_MAX, RAR_LOOK, ROSTER, SEASON, SETS, SET_OF, SWAPS,
  chestArtOf, chestPrice, chestVideosLeft, creaturePrice, dealBought, myChests, owns, picks as todaysPicks, wallet,
} from '../squad/data';
import * as squad from '../squad/api';
import { Bob, BtnText, CandyBtn, Chest, Chip, CoinIcon, F, GemIcon, GOLD, GOLD_RING, PINK_RING, PriceBtn, Ringed, hms, TickingText, untilMidnight } from '../squad/ui';
import ChestOpener from './ChestOpener';
import TutTarget from '../tutorial/Target';
import { report as tutReport } from '../tutorial/store';
import { Bone, BoneCard, Reveal, useAfterFirstFrame } from '../components/Skeleton';
import { useSeenTabs } from '../components/TabPane';
import { fmtNum } from '../format';
import useInstantTab from '../components/useInstantTab';

// The Shop (the 2026-10-06 design's "Shop Screen v2"): chests, squishies
// and gems, on the squad economy (src/squad, run by the `squad` Cloud
// Function). Three tabs:
//  · Chests — My Chests (bought, not opened), the Daily Deal, free video
//    chests, the Legendary guarantee, the five chests and the season chest;
//  · Squishies — Today's Picks (20% off) and every squishy by set, to buy
//    with coins (Legendaries come from chests only);
//  · Gems — the gem packs (real money), gems → coins, Remove Ads.
// Left out until their products exist: the hero offers (Season Pass,
// Starter Pack, Mega Bundle, VIP Club).
//
// Every move goes to the server; the profile listener brings the result in.

const TINT = ['#fff0e2', '#e4f3ff', '#ffe6f6', '#dffcf6', '#f1e6ff'];
const LIP = ['#f2c7a0', '#a9d2f2', '#f0a8d8', '#93e0d2', '#cdb0f2'];
const CHIP = ['#d9772f', '#2f7fd6', '#d3179a', '#1b9c8c'];
const SEGS = [['chests', 'Chests'], ['squish', 'Squishies'], ['gems', 'Gems']];
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
      <View style={StyleSheet.absoluteFill} onLayout={(e) => setW(e.nativeEvent.layout.width)} />
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

const ChestsTab = memo(function ChestsTab({ profile, day, onBuy, onDeal, onVideo, onOpen, onOdds, seasonOn }) {
  const mine = myChests(profile);
  const shelf = ['welcome', ...CHEST_ORDER, 'season'].filter((t) => (mine[t] || 0) > 0);
  const videos = chestVideosLeft(profile, day);
  const dealDone = dealBought(profile, day);
  const pity = Math.min(PITY_MAX, profile?.pity || 0);
  return (
    <View style={styles.col14}>
      {shelf.length > 0 && (
        <TutTarget name="shelf" style={styles.shelf}>
          <Text style={styles.shelfTitle}>My Chests</Text>
          {shelf.map((t) => (
            <Pressable key={t} onPress={() => onOpen(t)} style={[styles.shelfSlot, { backgroundColor: TINT[Math.max(0, CHEST_ORDER.indexOf(t))] }]}>
              <Chest tier={chestArtOf(t)} size={46} style={{ marginLeft: 2 }} />
              <View style={styles.shelfN}>
                <Text style={styles.shelfNText}>{mine[t]}</Text>
              </View>
            </Pressable>
          ))}
          <Text style={styles.shelfHint}>{'TAP TO\nOPEN'}</Text>
        </TutTarget>
      )}

      <View style={styles.row10}>
        <Ringed ring="#8e1580" lip={5} radius={24} style={{ flex: 1 }} innerStyle={styles.bigCard} colors={['#c9fff4', '#7ee8e0', '#b98bff']}>
          <RaysSpin size={300} durationMs={16000} gapDeg={14} opacity={0.5} style={styles.cardRays} />
          <View style={styles.cardTop}>
            <Chip bg="#ff2f8f">DAILY DEAL</Chip>
            <Chip bg="#ff2f8f" size={11}>
              -30%
            </Chip>
          </View>
          <Bob ms={2600}>
            <Chest tier="crystal" size={104} />
          </Bob>
          <Text style={[styles.cardName, { color: '#45107a' }]}>Crystal Chest</Text>
          <TickingText style={[styles.cardNote, { color: '#45107a' }]} text={(now) => hms(untilMidnight(now))} />
          {dealDone ? (
            <View style={styles.sold}>
              <Text style={styles.soldText}>BOUGHT TODAY</Text>
            </View>
          ) : (
            <PriceBtn cur="gems" amount={DEAL.gems} was={CHESTS.crystal.gems} onPress={onDeal} />
          )}
        </Ringed>

        <Pressable style={{ flex: 1 }} onPress={onVideo}>
          <Ringed ring="#0d7a4a" lip={5} radius={24} innerStyle={styles.bigCard} colors={['#e9fff3', '#9ff0c6', '#4fd39a']}>
            <View style={styles.cardTop}>
              <Chip bg="#16a86a">FREE</Chip>
              <Text style={styles.videoShort}>{videos > 0 ? `${videos} LEFT` : 'DONE'}</Text>
            </View>
            <Bob ms={2600} delay={0.6}>
              <Chest tier="basic" size={104} />
            </Bob>
            <Text style={[styles.cardName, { color: '#0d6a40' }]}>Free Chest</Text>
            <Text style={[styles.cardNote, { color: '#0d6a40' }]}>{videos > 0 ? `${videos} left today` : 'Back tomorrow'}</Text>
            <CandyBtn kind={videos > 0 ? 'green' : 'grey'} onPress={onVideo} disabled={videos <= 0} style={{ marginTop: 4 }}>
              <Text style={styles.play}>▶</Text>
              <BtnText ring={videos > 0 ? '#0d7a4a' : '#7a6a8c'} size={15}>
                {profile?.adsFree && videos > 0 ? 'FREE' : videos > 0 ? 'WATCH' : 'DONE'}
              </BtnText>
            </CandyBtn>
          </Ringed>
        </Pressable>
      </View>

      <View style={styles.pity}>
        <LinearGradient colors={['#fff3c4', '#ffa94d', '#e07a00']} start={{ x: 0.3, y: 0 }} end={{ x: 0.7, y: 1 }} style={styles.pityStar}>
          <Text style={styles.pityStarText}>★</Text>
        </LinearGradient>
        <View style={{ flex: 1, gap: 4 }}>
          <View style={styles.pityHead}>
            <Text style={styles.pityTitle}>LEGENDARY GUARANTEE</Text>
            <Text style={styles.pityCount}>
              {pity} / {PITY_MAX}
            </Text>
          </View>
          <View style={styles.pityBar}>
            {Array.from({ length: 10 }, (_, i) => (
              <View key={i} style={[styles.pitySeg, { backgroundColor: i < Math.floor(pity / 3) ? '#ffa94d' : '#f3dcc0' }]} />
            ))}
          </View>
          <Text style={styles.pityNote}>{pity >= PITY_MAX ? 'Your next Gold+ chest is Legendary!' : `${PITY_MAX - pity} more Gold+ chests to a sure Legendary`}</Text>
        </View>
      </View>

      <View style={styles.titleRow}>
        <Title size={19}>Chests</Title>
        <Text style={styles.link} onPress={onOdds}>
          View odds
        </Text>
      </View>
      <View style={styles.grid2}>
        {CHEST_ORDER.slice(0, 4).map((t, i) => {
          const p = chestPrice(t);
          const best = CHESTS[t].odds.slice(2).reduce((a, b) => a + b, 0);
          return (
            <View key={t} style={[styles.tierCard, { backgroundColor: TINT[i], shadowColor: LIP[i], borderBottomColor: LIP[i] }]}>
              <View style={[styles.tierChip, { backgroundColor: CHIP[i] }]}>
                <Text style={styles.tierChipText}>OPENS WITH {CHEST_LOOK[t].mech}</Text>
              </View>
              <View style={styles.tierArt}>
                <View style={[styles.tierShadow, { backgroundColor: LIP[i] }]} />
                <Bob ms={2800} delay={i * 0.35} style={{ position: 'absolute', left: 4, top: -6 }}>
                  <Chest tier={t} size={104} />
                </Bob>
              </View>
              <Text style={styles.tierName}>{CHEST_LOOK[t].name}</Text>
              <Text style={[styles.tierBest, { color: CHIP[i] }]}>Epic or better {best.toFixed(0)}%</Text>
              <TutTarget name={`buy:${t}`}>
                <PriceBtn cur={p.cur} amount={p.n} onPress={() => onBuy(t)} />
              </TutTarget>
            </View>
          );
        })}
      </View>

      <Ringed ring="#8f3cf2" lip={6} radius={26} innerStyle={styles.wideCard} colors={['#ffd1ec', '#fff1b0', '#c9fbe4', '#cbe8ff', '#e6d3ff']}>
        <RaysSpin size={360} durationMs={12000} gapDeg={12} opacity={0.6} style={styles.rainbowRays} />
        <Bob ms={2600}>
          <Chest tier="rainbow" size={136} />
        </Bob>
        <View style={{ flex: 1, gap: 4 }}>
          <Chip bg="#8f3cf2">THE BEST CHEST</Chip>
          <ShadowText style={styles.wideName} shadows={[[0, 2.5, '#8f3cf2'], [2, 0, '#8f3cf2'], [-2, 0, '#8f3cf2'], [0, -2, '#8f3cf2']]}>
            Rainbow
          </ShadowText>
          <Text style={styles.wideNote}>Epic or better every time. Opens with tap, hold and swipe.</Text>
          <View style={{ alignSelf: 'flex-start' }}>
            <PriceBtn cur="gems" amount={CHESTS.rainbow.gems} onPress={() => onBuy('rainbow')} size={17} padH={16} />
          </View>
        </View>
      </Ringed>

      {seasonOn && (
        <Ringed ring="#7a2a00" lip={6} radius={26} innerStyle={[styles.wideCard, { paddingLeft: 14, paddingRight: 6 }]} colors={['#4a1a73', '#8f3cf2', '#ff8a3d']}>
          <View style={{ flex: 1, gap: 4 }}>
            <Chip bg="#ffd23a" color="#4a1a73">
              SEASON 1 · LIMITED
            </Chip>
            <ShadowText style={[styles.wideName, { fontSize: 23 }]} shadows={[[0, 2.5, '#4a1a73'], [2, 0, '#4a1a73'], [-2, 0, '#4a1a73'], [0, -2, '#4a1a73']]}>
              {SEASON.name}
            </ShadowText>
            <Text style={styles.seasonNote}>6 squishies that leave forever when the season ends: Gourdy, Batty, Hexie and more.</Text>
            <Chip bg="#7a2a00" size={10.5}>
              Ends in <TickingText text={(now) => hms(SEASON_END - now)} />
            </Chip>
            <View style={{ alignSelf: 'flex-start' }}>
              <PriceBtn cur="gems" amount={CHESTS.season.gems} onPress={() => onBuy('season')} size={17} padH={16} />
            </View>
          </View>
          <Bob ms={2600}>
            <Chest tier="gold" size={130} />
          </Bob>
        </Ringed>
      )}
    </View>
  );
});

// --- Squishies tab --------------------------------------------------------------

const SquishTab = memo(function SquishTab({ profile, catalog, artIds, day, onPick }) {
  const pickIds = todaysPicks(profile || {}, artIds, day);
  const base = ROSTER.filter((c) => c.base);
  const ownedN = base.filter((c) => owns(profile || {}, c.id)).length;
  return (
    <View style={{ gap: 16 }}>
      <View style={{ gap: 8 }}>
        <View style={styles.titleRow}>
          <Title>Today's Picks</Title>
          <TickingText style={styles.small} text={(now) => `New picks in ${hms(untilMidnight(now))}`} />
        </View>
        <View style={styles.row8}>
          {pickIds.map((id) => {
            const c = BY_ID[id];
            const mine = owns(profile || {}, id);
            return (
              <Pressable key={id} style={{ flex: 1 }} onPress={() => onPick(id, true)}>
                <Ringed ring={PINK_RING} lip={5} radius={22} colors={mine ? ['#efe6f7', '#cdbde0'] : [RAR_LOOK[c.rar].bg, RAR_LOOK[c.rar].bg]} innerStyle={styles.pick}>
                  <View style={styles.pickOff}>
                    <Text style={styles.pickOffText}>-20%</Text>
                  </View>
                  <CreatureThumbnail creature={catalog[id]} size={84} />
                  <Text style={styles.pickName}>{c.name}</Text>
                  <View style={styles.pickRar}>
                    <Text style={styles.pickRarText}>{mine ? 'OWNED' : RAR_LOOK[c.rar].label}</Text>
                  </View>
                  {!mine && (
                    <Ringed ring={GOLD_RING} lip={3} ringW={2} border={2.5} colors={GOLD} innerStyle={styles.pickPrice}>
                      <Text style={styles.pickOld}>{fmt(COIN_PRICE[c.rar])}</Text>
                      <View style={styles.rowCenter}>
                        <CoinIcon size={12} />
                        <BtnText size={13}>{fmt(creaturePrice(profile || {}, id, artIds, day))}</BtnText>
                      </View>
                    </Ringed>
                  )}
                </Ringed>
              </Pressable>
            );
          })}
        </View>
        {pickIds.length > 0 && pickIds.every((id) => owns(profile || {}, id)) && <Text style={styles.center}>You own every pick today. New ones tomorrow!</Text>}
      </View>

      <View style={{ gap: 8 }}>
        <View style={styles.titleRow}>
          <Title>All Squishies</Title>
          <Text style={styles.small}>
            {ownedN} / {base.length} owned
          </Text>
        </View>
        {SETS.map((key) => (
          <SetBlock key={key} setKey={key} profile={profile} catalog={catalog} artIds={artIds} onPick={onPick} />
        ))}
      </View>
      <Text style={styles.foot}>
        Legendaries can't be bought. Get them from chests or the Legendary guarantee. Any squishy can drop as Shiny, Rainbow or Golden in chests, and a duplicate turns into coins.
      </Text>
    </View>
  );
});

const SET_LOOK = {
  snack: ['Snack Shack', '#c4651f', '#f2c7a0'],
  fruit: ['Fruit Patch', '#b88a00', '#ecd078'],
  ocean: ['Ocean Pals', '#2f7fd6', '#a9d2f2'],
  pet: ['Pet Shop', '#c0268f', '#f0a8d8'],
  forest: ['Forest Friends', '#16a86a', '#98dcbc'],
  sky: ['Sky & Stars', '#5a3ad0', '#c3b0f2'],
  dream: ['Dreamland', '#9a2fc8', '#d9a8f0'],
  bakery: ['Sweet Bakery', '#c2502a', '#f2b8a0'],
};
const CARD_BG = ['#e6f5ff', '#e2fbef', '#f1e6ff', '#fff0dc'];
const CARD_LIP = ['#a9d2f2', '#98dcbc', '#cdb0f2', '#f2c98f'];

function SetBlock({ setKey, profile, catalog, artIds, onPick }) {
  const [name, ink, lip] = SET_LOOK[setKey];
  const ids = [...SET_OF[setKey].ids].sort((a, b) => BY_ID[a].rar - BY_ID[b].rar || a - b);
  const have = ids.filter((id) => owns(profile || {}, id)).length;
  return (
    <View style={{ gap: 6, marginTop: 4 }}>
      <View style={styles.rowCenter}>
        <View style={[styles.setName, { backgroundColor: ink, shadowColor: lip, borderBottomColor: lip }]}>
          <Text style={styles.setNameText}>{name}</Text>
        </View>
        <Text style={styles.small}>
          {have} / {ids.length}
        </Text>
      </View>
      <View style={styles.grid4}>
        {ids.map((id) => {
          const c = BY_ID[id];
          const mine = owns(profile || {}, id);
          const soon = !artIds.includes(id);
          const chestOnly = c.rar >= 3;
          return (
            <Pressable key={id} style={[styles.cell, { backgroundColor: mine ? '#efe9f4' : CARD_BG[c.rar], borderBottomColor: mine ? '#d8cce4' : CARD_LIP[c.rar] }]} onPress={() => onPick(id, false)}>
              <View style={[styles.cellDot, { backgroundColor: RAR_LOOK[c.rar].dot }]} />
              <View style={{ width: 50, height: 50, alignItems: 'center', justifyContent: 'center', opacity: mine ? 0.55 : 1 }}>
                {soon ? (
                  <View style={styles.egg}>
                    <Text style={styles.eggText}>?</Text>
                  </View>
                ) : (
                  <CreatureThumbnail creature={catalog[id]} size={50} animate={false} />
                )}
              </View>
              <Text style={styles.cellName} numberOfLines={1}>
                {c.name}
              </Text>
              {soon ? (
                <View style={[styles.tag, { backgroundColor: '#f1ebf7', borderColor: '#e0d4ee' }]}>
                  <Text style={[styles.tagText, { color: '#a07cc0' }]}>SOON</Text>
                </View>
              ) : mine ? (
                <View style={[styles.tag, { borderColor: '#d8cce4' }]}>
                  <Text style={[styles.tagText, { color: '#9a88ad' }]}>OWNED</Text>
                </View>
              ) : chestOnly ? (
                <View style={[styles.tag, { borderColor: '#e0c8f2' }]}>
                  <Text style={[styles.tagText, { color: '#8e1580' }]}>IN CHESTS</Text>
                </View>
              ) : (
                <Ringed ring={GOLD_RING} lip={2} ringW={1.5} border={2} colors={GOLD} style={{ marginTop: 2 }} innerStyle={{ paddingHorizontal: 6, paddingVertical: 1, flexDirection: 'row', alignItems: 'center', gap: 2 }}>
                  <CoinIcon size={10} />
                  <BtnText size={10}>{fmt(COIN_PRICE[c.rar])}</BtnText>
                </Ringed>
              )}
            </Pressable>
          );
        })}
      </View>
    </View>
  );
}

// --- Gems tab --------------------------------------------------------------------

const GemsTab = memo(function GemsTab({ profile, priceOf, onPack, onSwap, onNoAds, noAdsPrice }) {
  const first = profile?.gemFirst || {};
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
        <Ringed ring={profile?.adsFree ? '#0d7a4a' : '#1d4f9a'} lip={3} ringW={2} border={2.5} colors={profile?.adsFree ? ['#b8ffd9', '#3ddc97', '#16a86a'] : ['#d6f3ff', '#5fb8ff', '#2f7fd6']} innerStyle={{ paddingHorizontal: 10, paddingVertical: 5 }}>
          <BtnText ring={profile?.adsFree ? '#0d7a4a' : '#1d4f9a'} size={14}>
            {profile?.adsFree ? 'OWNED' : noAdsPrice}
          </BtnText>
        </Ringed>
      </Pressable>
      <Text style={styles.foot}>First purchase of each gem pack gives double gems.</Text>
    </View>
  );
});

// --- the sheet ---------------------------------------------------------------------

function Sheet({ sheet, profile, catalog, artIds, day, onClose, onOpenNow, onBuyCreature, onBroke, onToChests }) {
  const up = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    up.setValue(0);
    Animated.spring(up, { toValue: 1, friction: 8, tension: 80, useNativeDriver: true }).start();
  }, [sheet, up]);
  if (!sheet) return null;
  const translateY = up.interpolate({ inputRange: [0, 1], outputRange: [500, 0] });
  let body = null;
  if (sheet.type === 'got') {
    body = (
      <>
        <Chest tier={chestArtOf(sheet.tier)} size={120} />
        <Text style={styles.sheetTitle}>{CHEST_LOOK[sheet.tier].name} Chest!</Text>
        <View style={[styles.row10, { alignSelf: 'stretch', marginTop: 4 }]}>
          <Pressable style={({ pressed }) => [styles.later, pressed && styles.pressed]} onPress={onClose}>
            <Text style={styles.laterText}>SAVE FOR LATER</Text>
          </Pressable>
          <TutTarget name="openNow" style={{ flex: 1 }}>
            <CandyBtn kind="pink" padV={11} onPress={() => onOpenNow(sheet.tier)}>
              <BtnText ring={PINK_RING}>OPEN NOW</BtnText>
            </CandyBtn>
          </TutTarget>
        </View>
      </>
    );
  } else if (sheet.type === 'odds') {
    body = (
      <>
        <Text style={[styles.sheetTitle, { fontSize: 22 }]}>Chest odds</Text>
        <View style={{ alignSelf: 'stretch', gap: 6 }}>
          {CHEST_ORDER.map((t, i) => (
            <View key={t} style={[styles.oddsRow, { backgroundColor: TINT[i] }]}>
              <Text style={styles.oddsName}>{CHEST_LOOK[t].name}</Text>
              <View style={styles.oddsChips}>
                {CHESTS[t].odds.map((p, r) =>
                  p > 0 ? (
                    <View key={r} style={[styles.oddsChip, { backgroundColor: ODDS_BG[r] }]}>
                      <Text style={styles.oddsChipText}>
                        {ODDS_NAMES[r]} {p}%
                      </Text>
                    </View>
                  ) : null,
                )}
              </View>
            </View>
          ))}
        </View>
      </>
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
  } else if (sheet.type === 'creature') {
    const c = BY_ID[sheet.id];
    const mine = owns(profile || {}, sheet.id);
    const price = creaturePrice(profile || {}, sheet.id, artIds, day);
    body = (
      <>
        <View style={styles.pvArt}>
          <View style={[styles.pvGlow, { backgroundColor: RAR_LOOK[c.rar].dot }]} />
          <CreatureThumbnail creature={catalog[sheet.id]} size={150} mood="dance" />
        </View>
        <View style={styles.rowCenter}>
          <Text style={[styles.sheetTitle, { fontSize: 26 }]}>{c.name}</Text>
          <View style={[styles.pvRar, { backgroundColor: RAR_LOOK[c.rar].bg }]}>
            <Text style={styles.pvRarText}>{RAR_LOOK[c.rar].label}</Text>
          </View>
        </View>
        <View style={styles.rowCenter}>
          <View style={[styles.finChip, { backgroundColor: '#e8f4ff' }]}>
            <Text style={styles.finChipText}>SHINY 2%</Text>
          </View>
          <LinearGradient colors={['#ffb3c7', '#ffe38a', '#b3f5c8', '#b3e0ff', '#dcc2ff']} start={{ x: 0, y: 0 }} end={{ x: 1, y: 0 }} style={styles.finChip}>
            <Text style={styles.finChipText}>RAINBOW 0.5%</Text>
          </LinearGradient>
          <LinearGradient colors={['#fff3b0', '#ffc233', '#f0a000']} style={styles.finChip}>
            <Text style={styles.finChipText}>GOLDEN 0.1%</Text>
          </LinearGradient>
        </View>
        <Text style={styles.finNote}>Finishes drop from chests only</Text>
        {mine ? (
          <View style={styles.already}>
            <Text style={styles.alreadyText}>ALREADY IN YOUR SQUAD</Text>
          </View>
        ) : (
          <>
            {c.rar >= 3 ? (
              <CandyBtn kind="pink" stretch padV={12} lip={5} onPress={onToChests}>
                <BtnText ring={PINK_RING} size={17}>
                  FIND IT IN CHESTS
                </BtnText>
              </CandyBtn>
            ) : (
              <CandyBtn kind="gold" stretch padV={12} lip={5} onPress={() => onBuyCreature(sheet.id)}>
                {price !== COIN_PRICE[c.rar] && <Text style={styles.pvOld}>{fmt(COIN_PRICE[c.rar])}</Text>}
                <BtnText size={19}>BUY</BtnText>
                <CoinIcon size={18} />
                <BtnText size={19}>{fmt(price)}</BtnText>
              </CandyBtn>
            )}
          </>
        )}
      </>
    );
  }
  return (
    <View style={StyleSheet.absoluteFill}>
      <Pressable style={styles.scrim} onPress={onClose} />
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

// `openKey`: bumped by App each time something opens the Shop on a tab
// (`startTab`); the Shop goes there without being rebuilt
function ShopScreen({ profile, creatures, onBack, onBuyProduct, priceOf, startTab = 'chests', openKey = 0, onImmersive }) {
  const insets = useSafeAreaInsets();
  // the tab's content is built a couple of frames after the Shop opens
  // (placeholders until then), so its first frame is up at once
  const built = useAfterFirstFrame();
  const [tab, setTab] = useState(startTab);
  const seen = useSeenTabs(tab);
  const openedAt = useRef(openKey);
  const [sheet, setSheet] = useState(null);
  const [opening, setOpening] = useState(null);
  useEffect(() => onImmersive?.(!!opening), [opening, onImmersive]);
  const [toast, setToast] = useState(null);
  const [busy, setBusy] = useState(false);
  // today's key (picks and deals change with it), moved on at midnight; the
  // countdowns tick by themselves (TickingText)
  const [day, setDay] = useState(() => todayKey(new Date()));
  useEffect(() => {
    const t = setTimeout(() => setDay(todayKey(new Date())), untilMidnight() + 500);
    return () => clearTimeout(t);
  }, [day]);
  const ad = useRewardedAd();
  // each tab is its own page with its own scroll (see the pages below)
  const scrolls = { chests: useRef(null), squish: useRef(null), gems: useRef(null) };
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

  // the catalog's creatures by id (only these have art)
  const catalog = useMemo(() => Object.fromEntries((creatures || []).map((c) => [c.id, c])), [creatures]);
  const artIds = useMemo(() => Object.keys(catalog).filter((id) => BY_ID[id]), [catalog]);
  const seasonOn = artIds.some((id) => BY_ID[id].season);

  const flash = useCallback((text) => {
    setToast({ text, key: Date.now() });
  }, []);

  // Runs a squad move; the rule errors become the broke sheet or a toast.
  const run = useCallback(
    async (fn, broke) => {
      if (busy) return null;
      setBusy(true);
      try {
        return await fn();
      } catch (e) {
        const code = e.message;
        if ((code === 'not_enough_gems' || code === 'not_enough_coins') && broke) setSheet({ type: 'broke', cur: code === 'not_enough_gems' ? 'gems' : 'coins', need: broke(code) });
        else flash(ERRORS[code] || 'Something went wrong. Try again!');
        return null;
      } finally {
        setBusy(false);
      }
    },
    [busy, flash],
  );

  const buyChest = useCallback(
    async (tier) => {
      const p = chestPrice(tier);
      const r = await run(() => squad.buyChest(tier), () => p.n - w[p.cur]);
      if (r) {
        sfx.play('coin');
        setSheet({ type: 'got', tier: r.tier });
      }
    },
    [run, w],
  );
  const buyDeal = useCallback(async () => {
    const r = await run(() => squad.buyDeal(), () => DEAL.gems - w.gems);
    if (r) setSheet({ type: 'got', tier: r.tier });
  }, [run, w]);
  const videoChest = useCallback(() => {
    if (chestVideosLeft(profile, day) <= 0) return flash('No more free chests today');
    const claim = async () => {
      const r = await run(() => squad.videoChest());
      if (r) setSheet({ type: 'got', tier: 'basic' });
    };
    if (profile?.adsFree) return claim();
    if (!ad.ready) return flash('No video right now. Try again in a moment');
    ad.show(claim);
  }, [profile, day, ad, run, flash]);
  const openChest = useCallback((tier) => {
    setSheet(null);
    setOpening(tier);
  }, []);
  const buyCreature = useCallback(
    async (id) => {
      const price = creaturePrice(profile || {}, id, artIds, day);
      const r = await run(() => squad.buyCreature(id), () => price - w.coins);
      if (r) {
        setSheet(null);
        sfx.play('unlock');
        flash(r.reward ? `Set complete! ${BY_ID[r.reward].name} joined too` : `${BY_ID[id].name} joined your squad!`);
      }
    },
    [profile, artIds, day, w, run, flash],
  );
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

  const badges = { chests: chestVideosLeft(profile, day) > 0 ? 'FREE' : '', squish: '', gems: '' };
  // stable, so a re-render of the Shop (a tab switch, a sheet) doesn't
  // re-render all three tabs' content (they're memoized)
  const openOdds = useCallback(() => setSheet({ type: 'odds' }), []);
  const pickCreature = useCallback(
    (id) => (artIds.includes(id) ? setSheet({ type: 'creature', id }) : flash(`${BY_ID[id].name} is still hatching. Coming soon!`)),
    [artIds, flash],
  );
  const buyPack = useCallback((key) => onBuyProduct(key), [onBuyProduct]);
  const adsFree = !!profile?.adsFree;
  const buyNoAds = useCallback(() => (adsFree ? flash('Ads are already off') : onBuyProduct('removeAds')), [adsFree, flash, onBuyProduct]);

  return (
    <CandyBackground style={{ paddingTop: insets.top }}>
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
      <View style={styles.pager}>
        <Animated.View style={[styles.pageTrack, { width: pageW * 3, transform: [{ translateX: pageShift }] }]}>
          <ScrollView ref={scrolls.chests} style={{ width: pageW }} contentContainerStyle={pageStyle} showsVerticalScrollIndicator={false}>
            <Reveal ready={isOn('chests')} placeholder={<ShopBones />}>
              <ChestsTab profile={profile} day={day} onBuy={buyChest} onDeal={buyDeal} onVideo={videoChest} onOpen={openChest} onOdds={openOdds} seasonOn={seasonOn} />
            </Reveal>
          </ScrollView>
          <ScrollView ref={scrolls.squish} style={{ width: pageW }} contentContainerStyle={pageStyle} showsVerticalScrollIndicator={false}>
            <Reveal ready={isOn('squish')} placeholder={<ShopBones />}>
              <SquishTab profile={profile} catalog={catalog} artIds={artIds} day={day} onPick={pickCreature} />
            </Reveal>
          </ScrollView>
          <ScrollView ref={scrolls.gems} style={{ width: pageW }} contentContainerStyle={pageStyle} showsVerticalScrollIndicator={false}>
            <Reveal ready={isOn('gems')} placeholder={<ShopBones />}>
              <GemsTab profile={profile} priceOf={priceOf} onPack={buyPack} onSwap={swap} onNoAds={buyNoAds} noAdsPrice={priceOf('removeAds')} />
            </Reveal>
          </ScrollView>
        </Animated.View>
      </View>

      <Sheet
        sheet={sheet}
        profile={profile}
        catalog={catalog}
        artIds={artIds}
        day={day}
        onClose={() => {
          if (sheet?.type === 'got') flash('Saved to My Chests');
          setSheet(null);
        }}
        onOpenNow={openChest}
        onBuyCreature={buyCreature}
        onBroke={() => goTab('gems')}
        onToChests={() => goTab('chests')}
      />
      {toast && <Toast key={toast.key} text={toast.text} bottom={60 + (onBack ? insets.bottom : 0)} onDone={() => setToast(null)} />}
      {opening && <ChestOpener tier={opening} profile={profile} catalog={catalog} onClose={() => setOpening(null)} />}
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
  shelf: { flexDirection: 'row', alignItems: 'center', gap: 8, borderRadius: 20, backgroundColor: '#ffffff', ...card, borderBottomColor: '#e2a9d6', borderBottomWidth: 6, paddingHorizontal: 8, paddingVertical: 6 },
  shelfTitle: { fontFamily: F.display, fontSize: 13, lineHeight: 14, color: PINK_RING, width: 44 },
  shelfSlot: { width: 50, height: 50, borderRadius: 14, justifyContent: 'center' },
  shelfN: { position: 'absolute', right: -5, top: -6, minWidth: 19, height: 19, paddingHorizontal: 4, borderRadius: 999, backgroundColor: '#ff2f8f', borderWidth: 2, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  shelfNText: { fontFamily: F.black, fontSize: 10, color: '#ffffff' },
  shelfHint: { marginLeft: 'auto', fontFamily: F.black, fontSize: 10, lineHeight: 12, color: '#8a5aa8', textAlign: 'right' },
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
