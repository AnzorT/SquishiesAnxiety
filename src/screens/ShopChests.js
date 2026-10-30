import React, { memo, useCallback, useMemo, useRef, useState } from 'react';
import { Image, ImageBackground, ScrollView, StyleSheet, Text, View, useWindowDimensions } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Circle, Path } from 'react-native-svg';
import Pressable from '../components/Pressable';
import ShadowText from '../components/candy/ShadowText';
import { BY_ID, GDEAL, GROUPS, LUCK_MAX, RAR_LOOK, ROSTER, SEASON, SIZES, SIZE_I, UPGRADE, AD_CHESTS, copyProgress, dropRar, dupeCoinsFor, groupOut, inGroupChest, owns, lineup } from '../squad/data';
import GCHEST, { CHEST_NAMES } from '../squad/groupChestArt';
import { COIN, GEM } from '../squad/currencyArt';
import { Bob, F, TickingText, hms, untilMidnight } from '../squad/ui';
import TutTarget from '../tutorial/Target';
import { fmtNum } from '../format';
import { useProgressive } from '../components/Skeleton';

// The Shop's Chests tab (the 2026-10-19 design's "Shop Screen v5"): the Free
// chest (every 4 h) and the Rare chest (an ad, 3 a day), the daily deal (a
// Legendary at half price), then "All chests" — every group's chest in a
// swipe carousel with a chip row, today's three HOT groups first, then the
// season, then the rest; each card picks one of the five sizes — the Lucky
// meter and the drop odds. The chests are the design's own art
// (tools/shop-art/groupchests.mjs). Every purchase is the server's (squad
// groupChest / freeChest / adChest / dealChest) and opens at once in the
// chest smash (ShopScreen → ChestSmash).

const fmt = fmtNum;
const OUT = (c, w = 1.5) => [[0, w + 0.5, c], [w, 0, c], [-w, 0, c], [0, -w, c]];
const GOLD = { bg: ['#fff3b0', '#ffd83a', '#ffb000'], rim: '#b86200', ink: '#7a3d00', ts: null };
const PURPLE = { bg: ['#f3d2ff', '#b65cff', '#6a22d6'], rim: '#45189a', ink: '#ffffff', ts: '#45189a' };
const GREY = { bg: ['#f7f3fc', '#ece6f6', '#e2d8f0'], rim: '#b8a8d4', ink: '#8a78b0', ts: null };
const GREEN = ['#d8ffc2', '#6fe07a', '#26a94e'];
// each size's colours (the design's TC)
const TC = [
  { c: '#a0623a', soft: '#fbefe4', dot: ['#f5e6d3', '#b08a68'] },
  { c: '#2f7ad6', soft: '#e6f1ff', dot: ['#d4ecff', '#2f8cff'] },
  { c: '#8a3cff', soft: '#f1e6ff', dot: ['#ecd8ff', '#a24bf0'] },
  { c: '#d98200', soft: '#fff3d6', dot: ['#fff3b8', '#f08c00'] },
  { c: '#d6249a', soft: '#ffe6f6', dot: ['#ff8fd8', '#ffe38a', '#9ff7c8', '#9fd8ff', '#d6b3ff'] },
];
const SIZE_NAME = ['Common', 'Rare', 'Epic', 'Legendary', 'Rainbow'];
const RAR_ROW = [['Common', '#e3f1ff', '#2f6fc0'], ['Rare', '#e3fbe9', '#17803a'], ['Epic', '#f1e6ff', '#6a22d6'], ['Legendary', '#fff3d6', '#b86200']];
const GROUP_LABEL = { snack: 'SNACK SHACK', fruit: 'FRUIT PATCH', ocean: 'OCEAN PALS', pet: 'PET SHOP', forest: 'FOREST FRIENDS', sky: 'SKY & STARS', dream: 'DREAMLAND', bakery: 'SWEET BAKERY', heroes: 'MASKED HEROES', elemental: 'ELEMENTAL HEROES', spooky: 'SPOOKY SQUISH' };
const title = (s) => s.toLowerCase().replace(/(^|\s)\S/g, (c) => c.toUpperCase());
const hm = (ms) => {
  const m = Math.max(0, Math.ceil(ms / 60000));
  return `${Math.floor(m / 60)}h ${String(m % 60).padStart(2, '0')}m`;
};

// Every group that's out, in the design's order for the day: the three HOT
// ones, the season, the rest.
export function allChests(day, hidden) {
  const hot = lineup(day, hidden);
  const rest = GROUPS.map((g) => g.key).filter((k) => k !== SEASON.key && !hot.includes(k) && groupOut(k, hidden));
  return [
    ...hot.map((k) => ({ k, tag: 'HOT TODAY', tagBg: ['#ff3d6e', '#ff7a3d'], dot: '#ff3d6e' })),
    { k: SEASON.key, tag: 'SEASON', tagBg: ['#ff8a1e', '#b03a00'], dot: '#ff8a1e' },
    ...rest.map((k) => ({ k, tag: '' })),
  ];
}

// A group's chest of a size: what the card and the sheet say.
export function chestInfo(gk, size, profile, artIds, setRewards) {
  const ti = SIZE_I[size];
  const T = SIZES[ti];
  const pool = ROSTER.filter((c) => inGroupChest(c, gk, setRewards) && artIds.includes(c.id));
  const have = pool.filter((c) => owns(profile || {}, c.id)).length;
  const epicUp = Math.round((T.odds[2] + T.odds[3]) * 10) / 10;
  return {
    ti,
    T,
    pool,
    have,
    name: (CHEST_NAMES[gk] || [])[ti] || `${SIZE_NAME[ti]} chest`,
    look: T.price.cur === 'coins' ? GOLD : PURPLE,
    odds: `${T.odds[3] ? `Leg ${T.odds[3]}% · ` : ''}Epic+ ${epicUp}%`,
    // what a duplicate pays: 7% of the chest's worth (no other coins inside)
    dupeCoins: `+${fmt(dupeCoinsFor(size))}`,
    upNote: ti <= 1 ? `${UPGRADE[size]}% chance it upgrades on your first smash` : '',
  };
}

// The glossy candy button (the design's bg + 3px white border + ring and lip).
function Candy({ colors, rim, lip = 4, radius = 16, height, style, children, onPress, shine = true }) {
  return (
    <Pressable onPress={onPress} style={({ pressed }) => [style, pressed && { transform: [{ translateY: 3 }] }]}>
      <View style={{ borderRadius: radius + 2, backgroundColor: rim, padding: 2, paddingBottom: 2 + lip }}>
        <LinearGradient colors={colors} locations={colors.length === 3 ? [0, 0.55, 1] : undefined} style={{ height, borderRadius: radius, borderWidth: 3, borderColor: '#ffffff', overflow: 'hidden', flexDirection: 'row', alignItems: 'center', justifyContent: 'center', gap: 6 }}>
          {shine && <LinearGradient pointerEvents="none" colors={['rgba(255,255,255,0.72)', 'rgba(255,255,255,0.05)']} style={styles.shine} />}
          {children}
        </LinearGradient>
      </View>
    </Pressable>
  );
}

const Label = ({ children, size, color = '#ffffff', ts, style }) =>
  ts ? (
    <ShadowText style={[{ fontFamily: F.display, fontSize: size, color, includeFontPadding: false }, style]} shadows={OUT(ts)}>
      {children}
    </ShadowText>
  ) : (
    <Text style={[{ fontFamily: F.display, fontSize: size, color, includeFontPadding: false }, style]}>{children}</Text>
  );

// --- the Free and Rare tiles -------------------------------------------------------

// The Free tile's chest is today's first HOT group's, or the welcome chest's
// group (Mittens', the server's freeChest) for a new player's first one.
const Tiles = memo(function Tiles({ hot, freeGk, freeAt, freeBonus, adsLeft, adsFree, onFree, onAd }) {
  return (
    <View style={styles.tiles}>
      <LinearGradient colors={['#dcffe6', '#ffffff']} locations={[0, 0.64]} style={styles.tile}>
        <Text style={[styles.tileTitle, { color: '#17652f' }]}>Free chest</Text>
        <Text style={[styles.tileSub, { color: '#3f8a55' }]}>Every 4h</Text>
        <View style={styles.tileArt}>
          <Image source={GCHEST[freeGk]['common-tile']} style={styles.fill} resizeMode="contain" fadeDuration={0} />
        </View>
        <FreeButton freeAt={freeAt} bonus={freeBonus} onFree={onFree} />
      </LinearGradient>
      <LinearGradient colors={['#dcecff', '#ffffff']} locations={[0, 0.64]} style={styles.tile}>
        <Text style={[styles.tileTitle, { color: '#2a4f9a' }]}>Rare chest</Text>
        <Text style={[styles.tileSub, { color: '#4a6fb0' }]}>{'Watch & open'}</Text>
        <View style={styles.tileArt}>
          <Image source={GCHEST[hot[1]]['rare-tile']} style={styles.fill} resizeMode="contain" fadeDuration={0} />
        </View>
        {(() => {
          const L = adsLeft ? PURPLE : GREY;
          return (
            <TutTarget name="adChest">
              <Candy colors={L.bg} rim={L.rim} height={42} onPress={onAd}>
                <Svg width={16} height={16} viewBox="0 0 24 24">
                  <Path d="M2 8 a4 4 0 0 1 4 -4 h12 a4 4 0 0 1 4 4 v8 a4 4 0 0 1 -4 4 h-12 a4 4 0 0 1 -4 -4 Z" fill={adsLeft ? '#ffffff' : GREY.ink} />
                  <Path d="M10 8.5L15.5 12L10 15.5Z" fill={L.rim} />
                </Svg>
                <Label size={14.5} color={adsLeft ? '#ffffff' : GREY.ink} ts={adsLeft ? '#45189a' : null}>
                  {adsLeft ? `${adsFree ? 'Free' : 'Watch'} · ${adsLeft} left` : 'Back tomorrow'}
                </Label>
              </Candy>
            </TutTarget>
          );
        })()}
      </LinearGradient>
    </View>
  );
});

// "Open free" or the countdown, re-rendered each second on its own. Extra
// free chests (a streak's chest days, `bonus`) open while the timer runs.
function FreeButton({ freeAt, bonus, onFree }) {
  const [, setT] = useState(0);
  const timed = (freeAt || 0) <= Date.now();
  const n = (timed ? 1 : 0) + (bonus || 0);
  const ready = n > 0;
  React.useEffect(() => {
    if (ready) return undefined;
    const t = setInterval(() => setT((n) => n + 1), 1000);
    return () => clearInterval(t);
  }, [ready, freeAt]);
  const label = n > 1 ? `Open free · ${n}` : 'Open free';
  if (ready)
    return (
      <TutTarget name="freeChest">
        <Candy colors={GREEN} rim="#17652f" height={42} onPress={onFree}>
          <Label size={16} ts="#17652f">
            {label}
          </Label>
        </Candy>
      </TutTarget>
    );
  return (
    <View style={styles.freeWait}>
      <Text style={styles.freeWaitText}>{`Next in ${hms(freeAt - Date.now())}`}</Text>
    </View>
  );
}

// --- the daily deal ----------------------------------------------------------------------

const Deal = memo(function Deal({ gk, done, onBuy }) {
  return (
    <View style={styles.dealRing}>
      <LinearGradient colors={['#ff5cc6', '#b65cff', '#6a22d6']} locations={[0, 0.55, 1]} start={{ x: 0, y: 0.2 }} end={{ x: 1, y: 0.8 }} style={styles.deal}>
        <View style={styles.dealGlow} pointerEvents="none" />
        <Bob ms={2600} dy={7} style={styles.dealArt}>
          <Image source={GCHEST[gk]['legendary-deal']} style={styles.fill} resizeMode="contain" fadeDuration={0} />
          <LinearGradient colors={['#fff3b0', '#ffd83a', '#ffb000']} style={styles.dealBadge}>
            <Text style={styles.dealBadgeText}>-50%</Text>
          </LinearGradient>
        </Bob>
        <View style={styles.dealBody}>
          <View style={styles.row6}>
            <View style={styles.dealChip}>
              <Text style={styles.dealChipText}>DAILY DEAL</Text>
            </View>
            <TickingText style={styles.dealTimer} text={(now) => `Ends in ${hms(untilMidnight(now))}`} />
          </View>
          <ShadowText style={styles.dealName} shadows={[[0, 2, '#6a1b9a']]}>
            {(CHEST_NAMES[gk] || [])[3]}
          </ShadowText>
          <View style={styles.row4}>
            <Text style={styles.dealPlus}>+</Text>
            <Image source={COIN[1]} style={styles.icon16} />
            <Text style={styles.dealPlus}>{`${fmt(GDEAL.coins)} · ${GROUP_LABEL[gk]}`}</Text>
          </View>
          {done ? (
            <View style={styles.dealDone}>
              <Text style={styles.dealDoneText}>Bought! New deal tomorrow</Text>
            </View>
          ) : (
            <Pressable onPress={onBuy} style={({ pressed }) => [styles.dealBtn, pressed && { transform: [{ translateY: 2 }] }]}>
              <Text style={styles.dealWas}>{GDEAL.was}</Text>
              <Image source={GEM[0]} style={styles.icon20} />
              <Text style={styles.dealPrice}>{GDEAL.gems}</Text>
            </Pressable>
          )}
        </View>
      </LinearGradient>
    </View>
  );
});

// --- the carousel ------------------------------------------------------------------------

// `near`: the card in view or next to it. Only those are built (their
// pictures are ~2.3 MB of texture each, and nine whole cards at once were a
// 0.25 s frame as the Shop was built); the others are an empty card of the
// same width until a swipe brings them near (2026-10-28).
const Card = memo(function Card({ x, size, info, width, index, near = true, onSize, onOpen, onBuy }) {
  const C = info;
  const tc = TC[C.ti];
  const gemsCur = C.T.price.cur === 'gems';
  if (!near) {
    return (
      <View style={[styles.cardRing, { width }]}>
        <View style={[styles.card, styles.cardShell, { backgroundColor: tc.soft }]} />
      </View>
    );
  }
  const top = (
    <>
      <View style={[styles.cardFloor, { backgroundColor: `${tc.c}55` }]} />
      <Bob ms={2800} delay={(index * 0.6) % 2.8} style={styles.cardArt}>
        {near ? <Image source={GCHEST[x.k][`${size}-grow`]} style={styles.fill} resizeMode="contain" fadeDuration={0} /> : null}
      </Bob>
      <View style={styles.cardLabel}>
        <Text style={styles.cardLabelText}>{GROUP_LABEL[x.k]}</Text>
      </View>
      {!!x.tag && (
        <LinearGradient colors={x.tagBg} start={{ x: 0, y: 0 }} end={{ x: 1, y: 0 }} style={styles.cardTag}>
          <Text style={styles.cardTagText}>{x.tag}</Text>
        </LinearGradient>
      )}
      <View style={styles.cardHave}>
        <Text style={styles.cardHaveText}>{`${C.have} / ${C.pool.length} collected`}</Text>
      </View>
    </>
  );
  return (
    <View style={[styles.cardRing, { width }]}>
      <View style={styles.card}>
        <Pressable silent onPress={() => onOpen(x.k, size)}>
          {near ? (
            <ImageBackground source={GCHEST[x.k].bg} style={styles.cardTop} imageStyle={styles.cardTopImg} resizeMode="cover">
              {top}
            </ImageBackground>
          ) : (
            <View style={[styles.cardTop, styles.cardTopImg, { backgroundColor: tc.soft }]}>{top}</View>
          )}
        </Pressable>
        <View style={styles.cardBody}>
          <View style={{ gap: 2 }}>
            <Text style={[styles.cardTier, { color: tc.c }]}>{`${SIZE_NAME[C.ti].toUpperCase()} CHEST`}</Text>
            <Text style={styles.cardName} numberOfLines={1}>
              {C.name}
            </Text>
          </View>
          <View style={styles.sizes}>
            {SIZES.map((T, ti) => {
              const on = T.k === size;
              const q = TC[ti];
              return (
                <Pressable key={T.k} onPress={() => onSize(x.k, T.k)} style={[styles.sizeBtn, { backgroundColor: on ? q.soft : '#f7f3fc', borderColor: on ? q.c : '#ece4f7' }]}>
                  <LinearGradient colors={q.dot} start={{ x: 0, y: 0 }} end={{ x: 1, y: 1 }} style={[styles.sizeDot, on && { shadowColor: q.c, elevation: 3 }]} />
                  <Text style={[styles.sizeText, { color: on ? q.c : '#8a78b0' }]}>{ti === 3 ? 'Legend' : T.k === 'set' ? 'Rainbow' : SIZE_NAME[ti]}</Text>
                </Pressable>
              );
            })}
          </View>
          {!!C.upNote && (
            <View style={styles.upNote}>
              <Svg width={16} height={16} viewBox="0 0 24 24">
                <Circle cx={12} cy={12} r={11} fill="#26a94e" />
                <Path d="M12 17.5V7M7.5 11.5L12 7L16.5 11.5" stroke="#ffffff" strokeWidth={2.6} fill="none" strokeLinecap="round" strokeLinejoin="round" />
              </Svg>
              <Text style={styles.upNoteText}>{C.upNote}</Text>
            </View>
          )}
          <View style={styles.row6}>
            <View style={[styles.info, { backgroundColor: '#f4eefc' }]}>
              <Text style={[styles.infoLabel, { color: '#8a78b0' }]}>DROP ODDS</Text>
              <Text style={[styles.infoValue, { color: '#45107a' }]}>{C.odds}</Text>
            </View>
            <View style={[styles.info, { backgroundColor: '#fff6dc' }]}>
              <Text style={[styles.infoLabel, { color: '#b88a40' }]}>DUPLICATE</Text>
              <Text style={[styles.infoValue, { color: '#b86200' }]}>{`${C.dupeCoins} coins`}</Text>
            </View>
          </View>
          <TutTarget name={index === 0 ? 'buy:hot' : `buy:${x.k}`}>
            <Candy colors={C.look.bg} rim={C.look.rim} lip={5} radius={20} height={54} onPress={() => onBuy(x.k, size)}>
              <View style={styles.buyRow}>
                <Label size={20} color={C.look.ink} ts={C.look.ts}>
                  Open
                </Label>
                <View style={styles.pricePill}>
                  <Image source={gemsCur ? GEM[0] : COIN[0]} style={styles.icon28} />
                  <Text style={[styles.priceText, { color: gemsCur ? '#5a22c8' : '#b86200' }]}>{fmt(C.T.price.n)}</Text>
                </View>
              </View>
            </Candy>
          </TutTarget>
        </View>
      </View>
    </View>
  );
});

function Carousel({ list, profile, artIds, setRewards, onOpen, onBuy }) {
  const { width: winW } = useWindowDimensions();
  const cardW = winW - 40;
  const step = cardW + 12;
  const [sel, setSel] = useState({});
  const [at, setAt] = useState(0);
  // the card being swiped to, as soon as the swipe passes half way (for
  // `near`; `at` only moves when the carousel has settled)
  const [seen, setSeen] = useState(0);
  const onScroll = useCallback(
    (e) => {
      const i = Math.round(e.nativeEvent.contentOffset.x / step);
      setSeen((s) => (s === i ? s : i));
    },
    [step],
  );
  const car = useRef(null);
  const chips = useRef(null);
  const chipX = useRef([]);
  const onSize = useCallback((gk, size) => setSel((s) => ({ ...s, [gk]: size })), []);
  const go = useCallback(
    (i) => {
      car.current?.scrollTo({ x: i * step, animated: true });
      setAt(i);
      if (chipX.current[i] != null) chips.current?.scrollTo({ x: Math.max(0, chipX.current[i] - winW / 3), animated: true });
    },
    [step, winW],
  );
  const onEnd = useCallback(
    (e) => {
      const i = Math.round(e.nativeEvent.contentOffset.x / step);
      if (i !== at) {
        setAt(i);
        if (chipX.current[i] != null) chips.current?.scrollTo({ x: Math.max(0, chipX.current[i] - winW / 3), animated: true });
      }
    },
    [at, step, winW],
  );
  return (
    <>
      <ScrollView ref={chips} horizontal showsHorizontalScrollIndicator={false} style={styles.chipsScroll} contentContainerStyle={styles.chips}>
        {list.map((x, i) => {
          const on = i === at;
          return (
            <Pressable key={x.k} onPress={() => go(i)} onLayout={(e) => (chipX.current[i] = e.nativeEvent.layout.x)}>
              {on ? (
                <View style={styles.chipOnRing}>
                  <LinearGradient colors={['#ffd6f4', '#ff5cc6', '#c02bd9']} locations={[0, 0.55, 1]} style={styles.chip}>
                    {!!x.dot && <View style={[styles.chipDot, { backgroundColor: x.dot }]} />}
                    <Label size={14} ts="#8e1580" style={{ fontFamily: F.display }}>
                      {title(GROUP_LABEL[x.k])}
                    </Label>
                  </LinearGradient>
                </View>
              ) : (
                <View style={[styles.chip, styles.chipOff]}>
                  {!!x.dot && <View style={[styles.chipDot, { backgroundColor: x.dot }]} />}
                  <Text style={styles.chipText}>{title(GROUP_LABEL[x.k])}</Text>
                </View>
              )}
            </Pressable>
          );
        })}
      </ScrollView>
      <ScrollView
        ref={car}
        horizontal
        showsHorizontalScrollIndicator={false}
        snapToInterval={step}
        decelerationRate="fast"
        disableIntervalMomentum
        onMomentumScrollEnd={onEnd}
        onScroll={onScroll}
        scrollEventThrottle={100}
        style={styles.carScroll}
        contentContainerStyle={styles.car}
      >
        {list.map((x, i) => {
          const size = sel[x.k] || 'epic';
          return <Card key={x.k} x={x} index={i} size={size} width={cardW} near={Math.abs(i - seen) <= 1} info={chestInfo(x.k, size, profile, artIds, setRewards)} onSize={onSize} onOpen={onOpen} onBuy={onBuy} />;
        })}
      </ScrollView>
    </>
  );
}

// --- the Lucky meter ---------------------------------------------------------------------

function Lucky({ epic }) {
  const n = Math.min(epic || 0, LUCK_MAX);
  const left = Math.max(1, LUCK_MAX - n);
  return (
    <View style={styles.lucky}>
      <View style={styles.row8}>
        <Svg width={18} height={18} viewBox="0 0 24 24">
          <Path d="M12 2L14.6 8.6L21.5 9.2L16.2 13.7L17.9 20.5L12 16.8L6.1 20.5L7.8 13.7L2.5 9.2L9.4 8.6Z" fill="#ff5cc6" stroke="#8e1580" strokeWidth={1.4} strokeLinejoin="round" />
        </Svg>
        <Text style={styles.luckyTitle}>Lucky meter</Text>
        <Text style={styles.luckyNote}>{`Epic or better in ${left} ${left === 1 ? 'chest' : 'chests'}`}</Text>
      </View>
      <View style={styles.row4}>
        {Array.from({ length: LUCK_MAX }, (_, i) => {
          const on = i < n;
          const hot = i >= LUCK_MAX - 3;
          return on ? (
            <LinearGradient key={i} colors={hot ? ['#ffd6f4', '#ff5cc6'] : ['#d8b8ff', '#8a3cff']} style={[styles.luckySeg, { borderBottomColor: hot ? '#c02bd9' : '#6a22d6', borderBottomWidth: 2 }]} />
          ) : (
            <View key={i} style={[styles.luckySeg, { backgroundColor: '#ece4f7' }]} />
          );
        })}
      </View>
    </View>
  );
}

// --- the tab -----------------------------------------------------------------------------

// Built a part a frame (the tiles and the deal, then the carousel, then the
// rest): built in one go, the tab's views and chest pictures made one ~0.25 s
// frame on the Galaxy A15 when the Shop was built again after the Crib
// (2026-10-28).
function ChestsTab({ profile, day, artIds, hidden, setRewards, onFree, onAd, onDeal, onOpenSheet, onBuy, onOdds }) {
  const hot = useMemo(() => lineup(day, hidden), [day, hidden]);
  const welcome = !!profile && !owns(profile, '1') && !profile.chestOpens;
  const list = useMemo(() => allChests(day, hidden), [day, hidden]);
  const adsLeft = Math.max(0, AD_CHESTS - (profile?.adChests?.day === day ? profile.adChests.n || 0 : 0));
  const parts = useProgressive(3, 1, 1);
  return (
    <View style={styles.tab}>
      <Tiles hot={hot} freeGk={welcome ? BY_ID['1'].set : hot[0]} freeAt={profile?.freeAt || 0} freeBonus={profile?.freeBonus || 0} adsLeft={adsLeft} adsFree={!!profile?.adsFree} onFree={onFree} onAd={onAd} />
      <Deal gk={hot[0]} done={profile?.dealDay === day} onBuy={onDeal} />
      {parts >= 2 && (
        <View style={{ gap: 8 }}>
          <View style={styles.allHead}>
            <View style={{ gap: 3 }}>
              <ShadowText style={styles.allTitle} shadows={OUT('#45107a', 2)}>
                All chests
              </ShadowText>
              <Text style={styles.allSub}>{`${list.length} groups · every size · swipe`}</Text>
            </View>
            <View style={styles.allTimer}>
              <TickingText style={styles.allTimerText} text={(now) => `Hot picks change in ${hm(untilMidnight(now))}`} />
            </View>
          </View>
        </View>
      )}
      {parts >= 2 && <Carousel list={list} profile={profile} artIds={artIds} setRewards={setRewards} onOpen={onOpenSheet} onBuy={onBuy} />}
      {parts >= 3 && <Lucky epic={profile?.epic || 0} />}
      {parts >= 3 && (
        <Pressable onPress={onOdds} style={styles.oddsLink}>
          <Text style={styles.oddsLinkText}>See all drop odds</Text>
        </Pressable>
      )}
    </View>
  );
}
export default memo(ChestsTab);

// --- the sheets: a chest's details, and every size's odds ----------------------------------

export function ChestSheetBody({ gk, size, profile, artIds, setRewards, catalog, wallet, onBuy }) {
  const C = chestInfo(gk, size, profile, artIds, setRewards);
  const tc = TC[C.ti];
  const gemsCur = C.T.price.cur === 'gems';
  const afford = (gemsCur ? wallet.gems : wallet.coins) >= C.T.price.n;
  const look = afford ? C.look : GREY;
  return (
    <View style={styles.sheetBody}>
      <ImageBackground source={GCHEST[gk].bg} style={styles.sheetArt} imageStyle={{ borderRadius: 22 }} resizeMode="cover">
        <Bob ms={2600} style={styles.sheetChest}>
          <Image source={GCHEST[gk][`${size}-grow`]} style={styles.fill} resizeMode="contain" fadeDuration={0} />
        </Bob>
      </ImageBackground>
      <View style={styles.sheetTag}>
        <Text style={[styles.sheetTagText, { color: tc.c }]}>{`${GROUP_LABEL[gk]} · ${SIZE_NAME[C.ti].toUpperCase()}`}</Text>
      </View>
      <Text style={styles.sheetName}>{C.name}</Text>
      {!!C.upNote && <Text style={styles.sheetUp}>{C.upNote}</Text>}
      <View style={styles.sheetOdds}>
        {C.T.odds.map((o, i) => (
          <View key={i} style={[styles.sheetOdd, { backgroundColor: RAR_ROW[i][1], opacity: o ? 1 : 0.45 }]}>
            <Text style={[styles.sheetOddPct, { color: RAR_ROW[i][2] }]}>{`${o}%`}</Text>
            <Text style={[styles.sheetOddName, { color: RAR_ROW[i][2] }]}>{RAR_ROW[i][0]}</Text>
          </View>
        ))}
      </View>
      <View style={styles.sheetRow}>
        <Text style={styles.sheetInside}>Squishies inside</Text>
        <Text style={styles.sheetHave}>{`${C.have} / ${C.pool.length} collected`}</Text>
      </View>
      <View style={styles.mons}>
        {C.pool.map((c) => {
          const o = owns(profile || {}, c.id);
          const uri = catalog[c.id]?.thumb?.url;
          const cp = o ? null : copyProgress(profile, c.id);
          return (
            <View key={c.id} style={[styles.mon, { backgroundColor: o ? '#f7f3fc' : '#ffffff', borderColor: o ? '#ece4f7' : RAR_ROW[dropRar(c)] ? RAR_ROW[dropRar(c)][2] : '#d9c4f7' }]}>
              {uri ? <Image source={{ uri }} style={[styles.monImg, { opacity: o ? 0.5 : 1 }]} resizeMode="contain" /> : null}
              {cp && (
                <View style={styles.monNew}>
                  <Text style={styles.monNewText}>{`${cp.have}/${cp.need}`}</Text>
                </View>
              )}
            </View>
          );
        })}
      </View>
      <View style={styles.row4}>
        <Image source={COIN[0]} style={styles.icon16} />
        <Text style={styles.sheetCoins}>{`Duplicate: ${C.dupeCoins} coins · Lucky meter counts this chest`}</Text>
      </View>
      <Candy colors={look.bg} rim={look.rim} lip={5} radius={20} height={58} style={{ alignSelf: 'stretch' }} onPress={() => onBuy(gk, size)}>
        {afford && <Image source={gemsCur ? GEM[0] : COIN[0]} style={styles.icon30} />}
        <Label size={20} color={look.ink} ts={look.ts}>
          {afford ? `Open · ${fmt(C.T.price.n)}` : `Get more ${C.T.price.cur}`}
        </Label>
      </Candy>
    </View>
  );
}

export function OddsSheetBody() {
  return (
    <View style={styles.sheetBody}>
      <Text style={styles.sheetName}>Drop odds</Text>
      {SIZES.map((T, i) => (
        <View key={T.k} style={styles.oddsRow}>
          <Text style={[styles.oddsRowName, { color: TC[i].c }]}>{SIZE_NAME[i]}</Text>
          <Text style={styles.oddsRowOdds}>{T.odds.map((o) => `${o}%`).join(' / ')}</Text>
        </View>
      ))}
      <Text style={styles.oddsNote}>
        Order: Common / Rare / Epic / Legendary. Common and Rare chests can upgrade on your first smash. The lucky meter guarantees an Epic or better at least every 10 chests. Duplicates turn into coins.
      </Text>
    </View>
  );
}

const styles = StyleSheet.create({
  fill: { width: '100%', height: '100%' },
  shine: { position: 'absolute', left: '8%', right: '8%', top: 2, height: '40%', borderRadius: 999 },
  row4: { flexDirection: 'row', alignItems: 'center', gap: 4 },
  row6: { flexDirection: 'row', alignItems: 'center', gap: 6 },
  row8: { flexDirection: 'row', alignItems: 'center', gap: 8 },
  icon16: { width: 16, height: 16 },
  icon20: { width: 20, height: 20 },
  icon28: { width: 28, height: 28 },
  icon30: { width: 30, height: 30 },
  tab: { gap: 16 },
  tiles: { flexDirection: 'row', gap: 10 },
  tile: { flex: 1, gap: 6, padding: 12, borderRadius: 24, borderWidth: 2, borderColor: '#ffffff', elevation: 4, shadowColor: '#45107a' },
  tileTitle: { fontFamily: F.display, fontSize: 16, lineHeight: 18 },
  tileSub: { fontFamily: F.heavy, fontSize: 10.5, marginTop: -5 },
  tileArt: { height: 96 },
  freeWait: { height: 42, alignItems: 'center', justifyContent: 'center', borderRadius: 16, backgroundColor: '#e9f8ee', borderWidth: 2, borderColor: '#c6efd3', marginBottom: 6 },
  freeWaitText: { fontFamily: F.black, fontSize: 12, color: '#17652f' },
  dealRing: { borderRadius: 26, backgroundColor: '#8e1580', padding: 2, paddingBottom: 7 },
  deal: { flexDirection: 'row', alignItems: 'center', gap: 8, paddingVertical: 12, paddingLeft: 4, paddingRight: 14, borderRadius: 24, borderWidth: 3, borderColor: '#ffffff', overflow: 'hidden' },
  dealGlow: { position: 'absolute', right: -40, top: -60, width: 180, height: 180, borderRadius: 90, backgroundColor: 'rgba(255,226,122,0.22)' },
  dealArt: { width: 112, height: 106 },
  dealBadge: { position: 'absolute', left: 2, top: 0, width: 42, height: 42, borderRadius: 21, borderWidth: 2.5, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center', transform: [{ rotate: '-12deg' }] },
  dealBadgeText: { fontFamily: F.display, fontSize: 12.5, color: '#7a3d00' },
  dealBody: { flex: 1, minWidth: 0, gap: 4 },
  dealChip: { paddingHorizontal: 8, paddingVertical: 2, borderRadius: 999, backgroundColor: '#ffffff' },
  dealChipText: { fontFamily: F.black, fontSize: 10, letterSpacing: 1, color: '#b0249a' },
  dealTimer: { fontFamily: F.heavy, fontSize: 11, color: '#ffffff' },
  dealName: { fontFamily: F.display, fontSize: 18, lineHeight: 20, color: '#ffffff' },
  dealPlus: { fontFamily: F.heavy, fontSize: 11.5, color: '#ffffff' },
  dealBtn: { alignSelf: 'flex-start', flexDirection: 'row', alignItems: 'center', gap: 6, marginTop: 3, paddingVertical: 5, paddingLeft: 8, paddingRight: 12, borderRadius: 14, backgroundColor: '#ffffff', borderBottomWidth: 3, borderBottomColor: '#6a1b9a' },
  dealWas: { fontFamily: F.black, fontSize: 11.5, color: '#b49ad8', textDecorationLine: 'line-through' },
  dealPrice: { fontFamily: F.display, fontSize: 17, color: '#5a1fb8' },
  dealDone: { alignSelf: 'flex-start', marginTop: 3, paddingVertical: 6, paddingHorizontal: 12, borderRadius: 12, backgroundColor: 'rgba(255,255,255,0.25)' },
  dealDoneText: { fontFamily: F.black, fontSize: 11.5, color: '#ffffff' },
  allHead: { flexDirection: 'row', alignItems: 'flex-end', justifyContent: 'space-between', gap: 8 },
  allTitle: { fontFamily: F.display, fontSize: 22, lineHeight: 26, color: '#ffffff', includeFontPadding: false },
  allSub: { fontFamily: F.heavy, fontSize: 11.5, color: '#45107a' },
  allTimer: { paddingHorizontal: 10, paddingVertical: 4, borderRadius: 999, backgroundColor: 'rgba(255,255,255,0.75)', borderWidth: 2, borderColor: '#ffffff' },
  allTimerText: { fontFamily: F.black, fontSize: 10.5, color: '#6a22d6' },
  chipsScroll: { marginHorizontal: -16, marginTop: -8 },
  chips: { gap: 7, paddingHorizontal: 16, paddingTop: 4, paddingBottom: 8 },
  chipOnRing: { borderRadius: 999, backgroundColor: '#8e1580', padding: 2, paddingBottom: 5 },
  chip: { height: 34, flexDirection: 'row', alignItems: 'center', gap: 6, paddingHorizontal: 12, borderRadius: 999, borderWidth: 2.5, borderColor: '#ffffff' },
  chipOff: { backgroundColor: 'rgba(255,255,255,0.8)', marginTop: 2, elevation: 2, shadowColor: '#45107a' },
  chipDot: { width: 8, height: 8, borderRadius: 4, borderWidth: 1.5, borderColor: '#ffffff' },
  chipText: { fontFamily: F.display, fontSize: 14, color: '#45107a' },
  carScroll: { marginHorizontal: -16, marginTop: -14 },
  car: { gap: 12, paddingHorizontal: 20, paddingTop: 4, paddingBottom: 16 },
  cardRing: { borderRadius: 30, backgroundColor: '#45189a', padding: 2, paddingBottom: 7 },
  card: { borderRadius: 28, backgroundColor: '#ffffff', borderWidth: 3, borderColor: '#ffffff', overflow: 'hidden' },
  // a card not built yet (away from view): the carousel's height comes from
  // the built ones
  cardShell: { height: 232 },
  cardTop: { height: 232, overflow: 'hidden' },
  cardTopImg: { borderTopLeftRadius: 25, borderTopRightRadius: 25 },
  cardFloor: { position: 'absolute', left: '50%', bottom: 22, width: 210, height: 36, marginLeft: -105, borderRadius: 105, opacity: 0.8, transform: [{ scaleY: 0.5 }] },
  cardArt: { position: 'absolute', left: '50%', top: 22, width: 240, height: 200, marginLeft: -120 },
  cardLabel: { position: 'absolute', left: 12, top: 12, paddingHorizontal: 10, paddingVertical: 3, borderRadius: 999, backgroundColor: '#ffffff', borderBottomWidth: 2, borderBottomColor: 'rgba(69,16,122,0.25)' },
  cardLabelText: { fontFamily: F.black, fontSize: 10, letterSpacing: 1, color: '#45107a' },
  cardTag: { position: 'absolute', right: 12, top: 12, paddingHorizontal: 10, paddingVertical: 3, borderRadius: 999, borderWidth: 2, borderColor: '#ffffff' },
  cardTagText: { fontFamily: F.black, fontSize: 10, letterSpacing: 0.9, color: '#ffffff' },
  cardHave: { position: 'absolute', right: 12, bottom: 10, paddingHorizontal: 10, paddingVertical: 3, borderRadius: 999, backgroundColor: 'rgba(255,255,255,0.9)' },
  cardHaveText: { fontFamily: F.heavy, fontSize: 10.5, color: '#45107a' },
  cardBody: { gap: 11, paddingTop: 11, paddingHorizontal: 14, paddingBottom: 16 },
  cardTier: { fontFamily: F.black, fontSize: 10.5, letterSpacing: 1.3 },
  cardName: { fontFamily: F.display, fontSize: 22, lineHeight: 24, color: '#45107a' },
  sizes: { flexDirection: 'row', gap: 5 },
  sizeBtn: { flex: 1, alignItems: 'center', gap: 5, paddingTop: 8, paddingBottom: 6, borderRadius: 14, borderWidth: 2 },
  sizeDot: { width: 11, height: 11, borderRadius: 3, borderWidth: 1.5, borderColor: '#ffffff', transform: [{ rotate: '45deg' }] },
  sizeText: { fontFamily: F.black, fontSize: 9.5 },
  upNote: { flexDirection: 'row', alignItems: 'center', gap: 8, paddingHorizontal: 10, paddingVertical: 7, borderRadius: 12, backgroundColor: '#e6fbec', borderWidth: 2, borderColor: '#c6efd3' },
  upNoteText: { flex: 1, fontFamily: F.heavy, fontSize: 11.5, lineHeight: 14.5, color: '#17652f' },
  info: { flex: 1, minWidth: 0, gap: 1, paddingHorizontal: 10, paddingVertical: 7, borderRadius: 12 },
  infoLabel: { fontFamily: F.heavy, fontSize: 9.5, letterSpacing: 0.8 },
  infoValue: { fontFamily: F.black, fontSize: 12 },
  buyRow: { flex: 1, flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between', paddingLeft: 18, paddingRight: 6 },
  pricePill: { flexDirection: 'row', alignItems: 'center', gap: 5, height: 38, paddingLeft: 6, paddingRight: 12, borderRadius: 14, backgroundColor: 'rgba(255,255,255,0.88)' },
  priceText: { fontFamily: F.display, fontSize: 17 },
  lucky: { gap: 9, paddingHorizontal: 14, paddingVertical: 13, borderRadius: 22, backgroundColor: 'rgba(255,255,255,0.86)', borderWidth: 2, borderColor: '#ffffff' },
  luckyTitle: { fontFamily: F.display, fontSize: 15, color: '#45107a' },
  luckyNote: { marginLeft: 'auto', fontFamily: F.heavy, fontSize: 11.5, color: '#6a4a9a' },
  luckySeg: { flex: 1, height: 11, borderRadius: 6 },
  oddsLink: { alignSelf: 'center', paddingHorizontal: 16, paddingVertical: 6, borderRadius: 999, backgroundColor: 'rgba(255,255,255,0.7)', borderWidth: 2, borderColor: '#ffffff' },
  oddsLinkText: { fontFamily: F.heavy, fontSize: 12, color: '#45107a' },
  sheetBody: { alignSelf: 'stretch', alignItems: 'center', gap: 10 },
  sheetArt: { width: '100%', height: 200, borderRadius: 22, overflow: 'hidden' },
  sheetChest: { position: 'absolute', left: '50%', top: 10, width: 240, height: 184, marginLeft: -120 },
  sheetTag: { paddingHorizontal: 12, paddingVertical: 3, borderRadius: 999, backgroundColor: '#f1e6ff' },
  sheetTagText: { fontFamily: F.black, fontSize: 10.5, letterSpacing: 1 },
  sheetName: { fontFamily: F.display, fontSize: 26, lineHeight: 28, color: '#45107a', textAlign: 'center' },
  sheetUp: { fontFamily: F.heavy, fontSize: 12, color: '#17803a', textAlign: 'center' },
  sheetOdds: { alignSelf: 'stretch', flexDirection: 'row', gap: 6 },
  sheetOdd: { flex: 1, alignItems: 'center', gap: 1, paddingVertical: 7, borderRadius: 12 },
  sheetOddPct: { fontFamily: F.display, fontSize: 16 },
  sheetOddName: { fontFamily: F.black, fontSize: 9.5 },
  sheetRow: { alignSelf: 'stretch', flexDirection: 'row', alignItems: 'baseline', justifyContent: 'space-between' },
  sheetInside: { fontFamily: F.black, fontSize: 12.5, color: '#45107a' },
  sheetHave: { fontFamily: F.heavy, fontSize: 11.5, color: '#6a4a9a' },
  mons: { alignSelf: 'stretch', flexDirection: 'row', flexWrap: 'wrap', gap: 6 },
  mon: { width: '18%', aspectRatio: 1, borderRadius: 14, borderWidth: 2, alignItems: 'center', justifyContent: 'center', overflow: 'hidden' },
  monImg: { width: '86%', height: '86%' },
  monNew: { position: 'absolute', left: 3, bottom: 3, paddingHorizontal: 4, borderRadius: 5, backgroundColor: '#e01e4a' },
  monNewText: { fontFamily: F.black, fontSize: 8, color: '#ffffff' },
  sheetCoins: { fontFamily: F.bold, fontSize: 11.5, color: '#6a4a9a' },
  oddsRow: { alignSelf: 'stretch', flexDirection: 'row', alignItems: 'center', gap: 8, paddingHorizontal: 12, paddingVertical: 9, borderRadius: 14, backgroundColor: '#f4eefc' },
  oddsRowName: { width: 80, fontFamily: F.display, fontSize: 14 },
  oddsRowOdds: { flex: 1, fontFamily: F.heavy, fontSize: 11.5, color: '#45107a' },
  oddsNote: { fontFamily: F.bold, fontSize: 11, lineHeight: 15.5, color: '#6a4a9a' },
});
