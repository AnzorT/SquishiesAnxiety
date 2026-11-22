import React, { memo, useEffect, useRef, useState } from 'react';
import { Plaque as RoyalPlaque } from '../royal';
import { Animated, Easing, Image, ScrollView, StyleSheet, Text, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Circle, Defs, G, Path, RadialGradient, Rect, Stop, Text as SvgText } from 'react-native-svg';
import Pressable from '../components/Pressable';
import ShadowText, { outline3 } from '../components/candy/ShadowText';
import ShineSweep from '../components/candy/ShineSweep';
import { RaysSpin } from '../components/candy/Decor';
import { Twinkle } from '../components/candy/Sparkles';
import { SWAPS, jarGems, lineup, offersOf, shownSize } from '../squad/data';
import GCHEST from '../squad/groupChestArt';
import { COIN, GEM } from '../squad/currencyArt';
import { F, hms, untilMidnight } from '../squad/ui';
import { BigFlame } from '../components/StreakIcons';
import { productKey } from '../economy';
import { fmtNum } from '../format';
import { useProgressive } from '../components/Skeleton';
import { stepKeys, useKeyLoop, usePingPong } from '../components/idleLoop';

// The Shop's Deals, Special offers and Gems tabs, drawn from Firestore config/offers
// (REDESIGN_V6 ruling 2: which offers show, what they hold, their badges,
// timers and order change without an app update; prices are the stores').
// Restyled 2026-10-24 (user: "modify the UI and style of the deals and gems
// shop"): each offer is its own candy card with a lip, a ribbon or a burst
// badge, and a big price button. The daily streak became one too on
// 2026-10-25, in the Remove Ads card's layout. Sideways (REDESIGN_V7, V8): the
// cards side by side, each in a column of the same height; the buttons are the
// wood look's plaques.
//   Deals: offers with a negative `order` first (Remove Ads, $0.99), then the
//   7-day streak, then the rest in order: the gem jar, the season pass. With
//   ads already off, Remove Ads is a thank-you line at the end.
//   Special offers: the bundles.
//   Gems: the first-buy 2X ribbon, the packs (double on a pack's first buy),
//   and gems → coins.

const fmt = fmtNum;
const INK = '#45107a';
const SIZE_NAME = { common: 'Common', rare: 'Rare', epic: 'Epic', legendary: 'Legendary', set: 'Rainbow' };
// a bundle's colours (config/offers `style`)
const STYLES = {
  green: { bg: ['#b9f7c9', '#4fd47a', '#1f9a48'], rim: '#17652f', glow: '#eaffd8' },
  blue: { bg: ['#bfe4ff', '#5aa2ff', '#2f5fd0'], rim: '#1f3f9a', glow: '#e3f2ff' },
  // (REDESIGN_V8: "pink" offers show warm ruby, not pink and purple)
  pink: { bg: ['#ffd0b8', '#ff6a3d', '#c8361a'], rim: '#7a1e0c', glow: '#fff0e6' },
  gold: { bg: ['#fff3b0', '#ffc933', '#f08c00'], rim: '#a04a00', glow: '#fffbe0' },
};
const GREEN_BTN = { colors: ['#e2ffcf', '#7be884', '#26a94e'], rim: '#17652f' };
const GOLD_BTN = { colors: ['#fff9c9', '#ffd84a', '#ffa60a'], rim: '#9c4d06' };
const PINK_BTN = { colors: ['#ffe2c8', '#ff9a4a', '#e0601c'], rim: '#8a3a0e' }; // (REDESIGN_V8: orange, not pink)
const rewardText = (r) => (r.k === 'coins' ? `${fmt(r.n)}` : r.k === 'gems' ? `${r.n}` : SIZE_NAME[shownSize(r.t)] || '');
const DAY = 864e5;

// --- shared pieces -----------------------------------------------------------------------

// A button: the wood look's gold plaque (REDESIGN_V7); its label (BtnLabel) outlined in its `look`'s rim colour.
function Btn({ radius = 16, height, onPress, children, style, disabled }) {
  return (
    <RoyalPlaque variant="gold" tips radius={radius} onPress={onPress} disabled={disabled} style={[{ height, flexDirection: 'row', gap: 8, paddingHorizontal: 12 }, style]}>
      {children}
    </RoyalPlaque>
  );
}
const BtnLabel = ({ children, look, size = 18 }) => (
  <ShadowText style={{ fontFamily: F.display, fontSize: size, color: '#ffffff', includeFontPadding: false }} shadows={outline3(look.rim, 2)}>
    {children}
  </ShadowText>
);

// A star-burst badge ("80%" over "OFF"), turning slowly back and forth (1.1 s each way).
// (The idle motions here are one native loop each, src/components/idleLoop.js: a loop around a sequence went back
// to JS at every step, so they stalled whenever JS was busy.)
function Burst({ top, bottom, size = 70, colors = ['#fff36b', '#ffb000'], ink = '#a3001f', style }) {
  const t = usePingPong(2200);
  const pts = [];
  const n = 14;
  for (let i = 0; i < n * 2; i++) {
    const r = i % 2 ? 0.8 : 1;
    const a = (Math.PI * i) / n;
    pts.push(`${(50 + 48 * r * Math.sin(a)).toFixed(1)},${(50 - 48 * r * Math.cos(a)).toFixed(1)}`);
  }
  const d = `M${pts.join(' L')} Z`;
  return (
    <Animated.View
      pointerEvents="none"
      style={[{ width: size, height: size, transform: [{ rotate: t.interpolate({ inputRange: [0, 1], outputRange: ['-10deg', '8deg'] }) }, { scale: t.interpolate({ inputRange: [0, 1], outputRange: [1, 1.06] }) }] }, style]}
    >
      <Svg width={size} height={size} viewBox="0 0 100 100">
        <Defs>
          <RadialGradient id="burstFill" cx="40%" cy="35%" r="70%">
            <Stop offset="0" stopColor={colors[0]} />
            <Stop offset="1" stopColor={colors[1]} />
          </RadialGradient>
        </Defs>
        <Path d={d} fill={ink} transform="translate(0 4)" />
        <Path d={d} fill="#ffffff" />
        <Path d={d} fill="url(#burstFill)" transform="translate(50 50) scale(0.88) translate(-50 -50)" />
        <SvgText x="50" y={bottom ? 50 : 60} fontSize={top && top.length > 3 ? 23 : 28} fontWeight="900" fill={ink} textAnchor="middle">
          {top}
        </SvgText>
        {bottom ? (
          <SvgText x="50" y="70" fontSize="16" fontWeight="900" fill={ink} textAnchor="middle">
            {bottom}
          </SvgText>
        ) : null}
      </Svg>
    </Animated.View>
  );
}

// A ribbon across a card's top corner (the card's last child).
function Ribbon({ text, colors = ['#ff6f91', '#e0123f'], rim = '#8e0a2a' }) {
  return (
    <View pointerEvents="none" style={styles.ribbonClip}>
      <View style={[styles.ribbon, { backgroundColor: rim }]}>
        <LinearGradient colors={colors} style={styles.ribbonFace}>
          <Text style={styles.ribbonText}>{text}</Text>
        </LinearGradient>
      </View>
    </View>
  );
}

const Check = ({ size = 18, color = '#26a94e' }) => (
  <Svg width={size} height={size} viewBox="0 0 24 24">
    <Circle cx={12} cy={12} r={11} fill="#ffffff" />
    <Circle cx={12} cy={12} r={8.5} fill={color} />
    <Path d="M8 12.3 L10.8 15 L16.2 9.4" stroke="#ffffff" strokeWidth={2.6} fill="none" strokeLinecap="round" strokeLinejoin="round" />
  </Svg>
);

const LockMini = ({ size = 14, color = '#9a6a2a' }) => (
  <Svg width={size} height={size * 1.1} viewBox="0 0 13 14">
    <Rect x={1.5} y={6} width={10} height={7} rx={2} fill={color} />
    <Path d="M3.8 6 V4.2 A2.7 2.7 0 0 1 9.2 4.2 V6" stroke={color} strokeWidth={1.8} fill="none" />
  </Svg>
);

function Countdown({ to, style, prefix = '' }) {
  const [now, setNow] = useState(Date.now());
  useEffect(() => {
    const t = setInterval(() => setNow(Date.now()), 1000);
    return () => clearInterval(t);
  }, []);
  return <Text style={style}>{`${prefix}${hms(to - now)}`}</Text>;
}

// A soft white glow disc (behind a chest or a gem pile).
const Glow = memo(function Glow({ size, color = '#ffffff', opacity = 0.9, style }) {
  return (
    <Svg pointerEvents="none" width={size} height={size} style={[{ position: 'absolute' }, style]}>
      <Defs>
        <RadialGradient id={`glow${size}`} cx="50%" cy="50%" r="50%">
          <Stop offset="0" stopColor={color} stopOpacity={opacity} />
          <Stop offset="0.55" stopColor={color} stopOpacity={opacity * 0.4} />
          <Stop offset="1" stopColor={color} stopOpacity={0} />
        </RadialGradient>
      </Defs>
      <Circle cx={size / 2} cy={size / 2} r={size / 2} fill={`url(#glow${size})`} />
    </Svg>
  );
});

// --- Remove Ads --------------------------------------------------------------------------

// A little TV saying AD, crossed out, wobbling (0.7 s each way).
function NoAdsArt() {
  const t = usePingPong(1400);
  return (
    <Animated.View style={{ transform: [{ rotate: t.interpolate({ inputRange: [0, 1], outputRange: ['-6deg', '6deg'] }) }, { translateY: t.interpolate({ inputRange: [0, 0.5, 1], outputRange: [0, -4, 0] }) }] }}>
      <Svg width={96} height={96} viewBox="0 0 100 100">
        <Path d="M38 20 L28 6 M62 20 L72 6" stroke="#ffffff" strokeWidth={5} strokeLinecap="round" />
        <Circle cx={28} cy={6} r={4.5} fill="#ffd84a" stroke="#ffffff" strokeWidth={2} />
        <Circle cx={72} cy={6} r={4.5} fill="#ffd84a" stroke="#ffffff" strokeWidth={2} />
        <Rect x={10} y={22} width={80} height={60} rx={16} fill="#8e1040" />
        <Rect x={10} y={18} width={80} height={60} rx={16} fill="#ffffff" />
        <Rect x={17} y={25} width={66} height={46} rx={10} fill="#3a1a6a" />
        <SvgText x={50} y={58} fontSize={26} fontWeight="900" fill="#ffd84a" textAnchor="middle">
          AD
        </SvgText>
        <G>
          <Circle cx={50} cy={48} r={31} fill="none" stroke="#ffffff" strokeWidth={12} />
          <Path d="M28 70 L72 26" stroke="#ffffff" strokeWidth={12} strokeLinecap="round" />
          <Circle cx={50} cy={48} r={31} fill="none" stroke="#e0123f" strokeWidth={7} />
          <Path d="M28 70 L72 26" stroke="#e0123f" strokeWidth={7} strokeLinecap="round" />
        </G>
      </Svg>
    </Animated.View>
  );
}

const PERKS = ['No banner or pop-up ads', 'Ad chests open with no video', 'Boosts and revives, video-free'];

function NoAds({ offer, price, onPress }) {
  return (
    <View style={[styles.cardWrap, styles.flex1]}>
      <View style={[styles.cardRing, { backgroundColor: '#1d4f9a' }, styles.flex1]}>
        <LinearGradient colors={['#d6ecff', '#5aa8ff', '#2f6fd6']} locations={[0, 0.5, 1]} start={{ x: 0.2, y: 0 }} end={{ x: 0.8, y: 1 }} style={[styles.card, styles.cardFit]}>
          <RaysSpin size={340} color="#ffffff" opacity={0.28} durationMs={22000} style={{ left: -150, top: -150 }} />
          <ShineSweep durationMs={3200} strength={0.45} />
          <Twinkle size={14} color="#fff3a0" duration={1.8} style={{ position: 'absolute', top: 14, left: 104 }} />
          <Twinkle size={10} color="#ffffff" duration={2.4} delay={0.7} style={{ position: 'absolute', bottom: 86, left: 14 }} />
          <View style={styles.noAdsRow}>
            <NoAdsArt />
            <View style={styles.noAdsText}>
              <ShadowText style={[styles.noAdsTitle, styles.titleFit]} shadows={outline3('#1d4f9a', 2.5)}>
                NO MORE ADS
              </ShadowText>
              {PERKS.map((p) => (
                <View key={p} style={styles.perk}>
                  <Check size={16} color="#2f6fd6" />
                  <Text style={styles.perkText}>{p}</Text>
                </View>
              ))}
            </View>
          </View>
          <Btn height={50} radius={20} onPress={onPress}>
            <View style={{ alignItems: 'center' }}>
              <BtnLabel look={GOLD_BTN} size={23}>
                {price}
              </BtnLabel>
              <Text style={styles.oneTime}>ONE-TIME PURCHASE</Text>
            </View>
          </Btn>
          {offer.tag ? <Ribbon text={offer.tag} /> : null}
        </LinearGradient>
      </View>
    </View>
  );
}

// Ads already off: a thank-you line.
const NoAdsOwned = () => (
  <View style={styles.owned}>
    <Check size={26} />
    <View style={{ flex: 1 }}>
      <Text style={styles.ownedTitle}>Ads are off</Text>
      <Text style={styles.ownedNote}>Thanks for supporting the squad!</Text>
    </View>
  </View>
);

// --- the daily streak --------------------------------------------------------------------

// Laid out like the Remove Ads card (user, 2026-10-25): a fire-orange card,
// the flame and three lines at the top, the seven days, a big CLAIM button
// (or the time to the next gift once today's is in).

// The streak's flame with its count on it, flickering from its base (up 520 ms, down 640 ms); cold
// (violet) before the first day.
const FLICKER = stepKeys(0, [
  [1, 520, Easing.inOut(Easing.sin)],
  [0, 640, Easing.inOut(Easing.sin)],
]);
function StreakFlame({ count }) {
  const t = useKeyLoop(FLICKER.ms, FLICKER);
  const W = 62; // (small enough for a Deals column)
  const H = W * 1.15;
  const flicker = [
    { translateY: H / 2 },
    { rotate: t.interpolate({ inputRange: [0, 1], outputRange: ['-2deg', '2deg'] }) },
    { scaleX: t.interpolate({ inputRange: [0, 1], outputRange: [1, 0.96] }) },
    { scaleY: t.interpolate({ inputRange: [0, 1], outputRange: [1, 1.07] }) },
    { translateY: -H / 2 },
  ];
  return (
    <View style={{ width: W, height: H }}>
      <Glow size={130} color="#fff6c4" opacity={0.95} style={{ left: (W - 130) / 2, top: (H - 130) / 2 }} />
      <Animated.View style={{ transform: flicker }}>
        <BigFlame width={W} cold={!count} />
      </Animated.View>
      <View pointerEvents="none" style={styles.flameNum}>
        <ShadowText style={[styles.flameNumText, count >= 100 && { fontSize: 22 }]} shadows={outline3(count ? '#8a1d0c' : '#45189a', 2.5)}>
          {String(count)}
        </ShadowText>
      </View>
    </View>
  );
}

const DAY_LOOK = {
  next: { bg: ['#ffffff', '#fff0dc'], ring: '#c2531c', ink: '#a33a06' },
  today: { bg: ['#fffbe0', '#ffd84a'], ring: '#9c4d06', ink: '#7a3d00' },
  done: { bg: ['#fff6ea', '#ffe0c2'], ring: '#d98a52', ink: '#b8662a' },
  big: { bg: ['#fbf5ff', '#dcc6ff'], ring: '#6a22d6', ink: '#5a22c8' },
};
const rewardLong = (r) => (r.k === 'coins' ? `${fmt(r.n)} coins` : r.k === 'gems' ? `${r.n} gems` : `${SIZE_NAME[shownSize(r.t)] || ''} chest`);
// day i's coin or gem (its claim flies out as this)
const dayBit = (r, i) => (r.k === 'gems' ? GEM[i % 6] : COIN[i % 6]);

// `artRef`: today's art (where its claim flies from)
function StreakDay({ r, i, last, done, today, hot, artRef, onPress }) {
  const look = today ? DAY_LOOK.today : done ? DAY_LOOK.done : last ? DAY_LOOK.big : DAY_LOOK.next;
  // today's gift bobs (0.65 s each way)
  const bob = usePingPong(1300, { on: !!today });
  const art =
    r.k === 'chest' ? (
      <Image source={GCHEST[hot][`${shownSize(r.t)}-grow`]} style={last ? styles.dayChestBig : styles.dayChest} resizeMode="contain" />
    ) : (
      <Image source={dayBit(r, i)} style={last ? styles.dayImgBig : styles.dayImg} />
    );
  return (
    <Pressable onPress={onPress} style={[styles.daySlot, last && styles.daySlotLast]}>
      <View style={[styles.dayRing, { backgroundColor: look.ring }]}>
        <LinearGradient colors={look.bg} style={styles.dayFace}>
          {last && !done ? <RaysSpin size={130} color="#ffffff" opacity={0.7} durationMs={16000} style={{ alignSelf: 'center', top: -30 }} /> : null}
          <Text style={[styles.dayLabel, { color: look.ink }]} numberOfLines={1} adjustsFontSizeToFit minimumFontScale={0.7}>
            {today ? 'TODAY' : `DAY ${i + 1}`}
          </Text>
          <View ref={artRef} collapsable={false}>
            <Animated.View style={{ transform: [{ translateY: bob.interpolate({ inputRange: [0, 1], outputRange: [0, -3] }) }, { scale: bob.interpolate({ inputRange: [0, 1], outputRange: [1, 1.08] }) }] }}>{art}</Animated.View>
          </View>
          <Text style={[styles.dayAmt, { color: look.ink }]} numberOfLines={1} adjustsFontSizeToFit minimumFontScale={0.6}>
            {rewardText(r)}
          </Text>
          {done ? (
            <View style={styles.dayDone}>
              <Check size={22} />
            </View>
          ) : null}
        </LinearGradient>
      </View>
    </Pressable>
  );
}

// onClaim(today, done, i, from): `from` { view, img }, where today's claim flies from
function Streak({ streak, profile, day, hot, onClaim }) {
  const todayArt = useRef(null);
  const st = profile?.shopStreak || { count: 0, last: null };
  const doneToday = st.last === day;
  const yesterday = new Date(Date.parse(`${day}T00:00:00Z`) - DAY).toISOString().slice(0, 10);
  const alive = doneToday || st.last === yesterday;
  const cnt = alive ? st.count || 0 : 0;
  const idx = doneToday ? (cnt - 1) % streak.length : cnt % streak.length;
  const perks = ['A free gift every day', `Day ${streak.length}: ${rewardLong(streak[streak.length - 1])}`];
  const from = { view: todayArt, img: dayBit(streak[idx], idx) };
  return (
    <View style={[styles.cardWrap, styles.flex1]}>
      <View style={[styles.cardRing, { backgroundColor: '#9a2a06' }, styles.flex1]}>
        <LinearGradient colors={['#ffe27a', '#ff9a3d', '#ec4a22']} locations={[0, 0.5, 1]} start={{ x: 0.2, y: 0 }} end={{ x: 0.8, y: 1 }} style={[styles.card, styles.cardFit]}>
          <RaysSpin size={340} color="#ffffff" opacity={0.28} durationMs={22000} style={{ left: -150, top: -150 }} />
          <ShineSweep durationMs={3400} delayMs={900} strength={0.4} />
          <Twinkle size={14} color="#ffffff" duration={1.8} style={{ position: 'absolute', top: 12, left: 92 }} />
          <Twinkle size={10} color="#fff3a0" duration={2.4} delay={0.7} style={{ position: 'absolute', top: 96, left: 10 }} />
          <View style={styles.streakTop}>
            <StreakFlame count={cnt} />
            <View style={styles.streakText}>
              <ShadowText style={[styles.noAdsTitle, styles.titleFit]} shadows={outline3('#9a2a06', 2.5)}>
                DAILY STREAK
              </ShadowText>
              {perks.map((p) => (
                <View key={p} style={styles.perk}>
                  <Check size={16} color="#ff6a1a" />
                  <Text style={[styles.perkText, styles.streakPerk]}>{p}</Text>
                </View>
              ))}
            </View>
          </View>
          <View style={styles.dayGrid}>
            {streak.map((r, i) => {
              const done = doneToday ? i <= idx : i < idx;
              const today = !doneToday && i === idx;
              return <StreakDay key={i} r={r} i={i} last={i === streak.length - 1} done={done} today={today} hot={hot[2]} artRef={today ? todayArt : undefined} onPress={() => onClaim(today, done, i, from)} />;
            })}
          </View>
          {doneToday ? (
            <View style={styles.streakWait}>
              <ShadowText style={styles.streakWaitTitle} shadows={outline3('#9a2a06', 2)}>
                {`${cnt} DAY${cnt === 1 ? '' : 'S'} IN A ROW!`}
              </ShadowText>
              <Countdown to={Date.now() + untilMidnight()} style={styles.streakWaitText} prefix="Next gift in " />
            </View>
          ) : (
            <Btn height={44} radius={18} onPress={() => onClaim(true, false, idx, from)}>
              <View style={{ alignItems: 'center' }}>
                <BtnLabel look={GREEN_BTN} size={21}>
                  {`CLAIM DAY ${idx + 1}`}
                </BtnLabel>
                <Text style={[styles.oneTime, { color: '#17652f' }]}>{`FREE · ${rewardLong(streak[idx]).toUpperCase()}`}</Text>
              </View>
            </Btn>
          )}
          <Ribbon text="FREE" colors={['#7be884', '#26a94e']} rim="#17652f" />
        </LinearGradient>
      </View>
    </View>
  );
}

// --- the gem jar --------------------------------------------------------------------------

function Jar({ offer, profile, price, onBuy }) {
  const gems = jarGems(profile || {}, offer);
  const max = offer.max || 1500;
  const pct = Math.min(100, Math.round((gems / max) * 100));
  const full = gems >= max;
  return (
    <View style={[styles.cardWrap, styles.flex1]}>
      <View style={[styles.cardRing, { backgroundColor: '#14917e' }, styles.flex1]}>
        <LinearGradient colors={['#effffb', '#bff2e8', '#6fd6c4']} locations={[0, 0.6, 1]} start={{ x: 0, y: 0 }} end={{ x: 1, y: 1 }} style={[styles.card, styles.jarCard, styles.cardFit]}>
          <View style={styles.jarRing}>
            <View style={styles.jar}>
              <LinearGradient colors={['#b9e6ff', '#8a5cff', '#6a22d6']} style={[styles.jarFill, { height: `${pct}%` }]} />
              <Image source={GEM[1]} style={[styles.jarGem, { transform: [{ rotate: '-12deg' }] }]} />
              <Image source={GEM[5]} style={[styles.jarGem2, { transform: [{ rotate: '14deg' }] }]} />
              <View style={styles.jarLid} />
              <View style={styles.jarShine} />
            </View>
            <Twinkle size={12} color="#ffffff" duration={1.6} style={{ position: 'absolute', top: 12, right: -4 }} />
          </View>
          <View style={styles.jarText}>
            <View style={styles.row6}>
              <ShadowText style={styles.cardTitle} shadows={outline3('#45189a', 2)}>
                {offer.name || 'Gem jar'}
              </ShadowText>
              {full ? (
                <View style={styles.fullChip}>
                  <Text style={styles.fullText}>FULL!</Text>
                </View>
              ) : null}
            </View>
            <Text style={styles.jarNote}>Fills with gems as you earn coins. Break it to keep them all!</Text>
            <View style={styles.meter}>
              <LinearGradient colors={['#b9e6ff', '#8a5cff']} start={{ x: 0, y: 0 }} end={{ x: 1, y: 0 }} style={[styles.meterFill, { width: `${Math.max(4, pct)}%` }]} />
              <Text style={styles.meterText}>{`${fmt(gems)} / ${fmt(max)}`}</Text>
            </View>
            <Btn height={38} radius={13} onPress={() => onBuy(offer, gems)}>
              <BtnLabel look={PINK_BTN} size={16}>
                {`BREAK IT · ${price}`}
              </BtnLabel>
            </Btn>
          </View>
        </LinearGradient>
      </View>
    </View>
  );
}

// --- bundles -----------------------------------------------------------------------------

// A mountain of coins or gems (2026-11-16, the user: "add mountains of golds and gems" to the special offers): rows of
// pieces heaped into a peak, one more piece in each row down, every piece a little turned, the rows above the base
// drooping at their ends so the heap is a rounded mound. The front row is drawn last (nearest). A big amount heaps a
// fourth row. `art`: the six coins or the six gems, mixed through the heap from `start`.
const TILT = [-14, 9, -5, 12, -9, 4, 15, -11, 6, -3];
const Mountain = memo(function Mountain({ art, rows, start = 0, twinkle = '#ffffff' }) {
  const size = rows >= 4 ? 24 : 26;
  const h = Math.round(size * 0.64);
  const v = Math.round(size * 0.52);
  const w = (rows - 1) * h + size;
  const tall = (rows - 1) * v + size + 4;
  const pieces = [];
  let n = 0;
  for (let r = 0; r < rows; r++) {
    for (let c = 0; c <= r; c++) {
      const s = Math.round(size * (0.86 + (0.14 * r) / Math.max(1, rows - 1)));
      const off = (c - r / 2) / Math.max(1, (rows - 1) / 2);
      const droop = r < rows - 1 ? off * off * v * 0.6 : 0;
      pieces.push(
        <Image
          key={n}
          source={art[(start + n) % art.length]}
          style={{ position: 'absolute', left: w / 2 + (c - r / 2) * h - s / 2, top: r * v + (size - s) + droop, width: s, height: s, transform: [{ rotate: `${TILT[n % TILT.length]}deg` }] }}
        />,
      );
      n++;
    }
  }
  return (
    <View style={{ width: w, height: tall }}>
      {pieces}
      <Twinkle size={11} color={twinkle} duration={1.8} style={{ position: 'absolute', left: w / 2 + h * 0.7, top: -4 }} />
      <Twinkle size={8} color="#ffffff" duration={2.4} delay={0.7} style={{ position: 'absolute', left: 1, top: v * (rows - 2) }} />
    </View>
  );
});
// rows in a bundle's mountain: a bigger amount, a bigger mountain
const gemRows = (n) => (n >= 2000 ? 4 : 3);
const coinRows = (n) => (n >= 20000 ? 4 : 3);

// One thing in a bundle: a white pod with its picture (or `art`, a mountain) and amount.
const Pod = ({ img, imgStyle, art, amount, ink, wide }) => (
  <View style={[styles.pod, wide && styles.podWide]}>
    <View style={[styles.podArt, art && styles.podArtTall]}>
      <Glow size={art ? 90 : wide ? 96 : 70} color="#fff6c4" opacity={0.9} style={art ? { top: -10 } : undefined} />
      {art || <Image source={img} style={imgStyle} resizeMode="contain" />}
    </View>
    <Text style={[styles.podAmt, { color: ink }]} numberOfLines={2}>
      {amount}
    </Text>
  </View>
);

function Bundle({ offer, hot, price, seenAt, onBuy, index }) {
  const look = STYLES[offer.style] || STYLES.pink;
  const chests = offer.chests || [];
  const timer = offer.once && offer.windowHours ? seenAt + offer.windowHours * 3600e3 : null;
  const [pct, word] = String(offer.off || '').split(' ');
  return (
    <View style={styles.cardWrap}>
      {offer.tag ? (
        <View style={styles.topTagWrap} pointerEvents="none">
          <LinearGradient colors={['#ffe14d', '#ffb000']} style={[styles.topTag, { borderColor: '#ffffff' }]}>
            <Text style={[styles.topTagText, { color: '#7a3d00' }]}>{`★ ${offer.tag} ★`}</Text>
          </LinearGradient>
        </View>
      ) : null}
      <View style={[styles.cardRing, { backgroundColor: look.rim }]}>
        <LinearGradient colors={look.bg} locations={[0, 0.5, 1]} start={{ x: 0.1, y: 0 }} end={{ x: 0.9, y: 1 }} style={[styles.card, offer.tag && { paddingTop: 20 }]}>
          <View style={styles.bundleBubble} pointerEvents="none" />
          <View style={styles.bundleBubble2} pointerEvents="none" />
          <ShineSweep durationMs={3600} delayMs={index * 500} strength={0.35} />
          <View style={styles.bundleHead}>
            <View style={{ flex: 1, minWidth: 0 }}>
              <ShadowText style={styles.bundleName} shadows={outline3(look.rim, 2.5)} numberOfLines={1}>
                {offer.name}
              </ShadowText>
              {timer ? (
                <View style={styles.timerChip}>
                  <Svg width={12} height={12} viewBox="0 0 24 24">
                    <Circle cx={12} cy={13} r={9} fill="none" stroke={look.rim} strokeWidth={3} />
                    <Path d="M12 8 V13 L15 15" stroke={look.rim} strokeWidth={3} fill="none" strokeLinecap="round" />
                  </Svg>
                  <Countdown to={timer} style={[styles.timerText, { color: look.rim }]} prefix="One time only · " />
                </View>
              ) : null}
            </View>
          </View>
          <View style={styles.pods}>
            {offer.gems > 0 && <Pod art={<Mountain art={GEM} rows={gemRows(offer.gems)} start={index + 1} twinkle="#d9c4ff" />} amount={fmt(offer.gems)} ink="#5a22c8" />}
            {offer.gems > 0 && (offer.coins > 0 || chests.length > 0) && <Text style={styles.plus}>+</Text>}
            {offer.coins > 0 && <Pod art={<Mountain art={COIN} rows={coinRows(offer.coins)} start={index + 2} twinkle="#fff3a0" />} amount={fmt(offer.coins)} ink="#b86200" />}
            {offer.coins > 0 && chests.length > 0 && <Text style={styles.plus}>+</Text>}
            {chests.length > 0 && (
              <Pod
                wide
                img={GCHEST[hot[0]][`${shownSize(chests[0])}-grow`]}
                imgStyle={styles.podChest}
                amount={`${chests.length > 1 ? `${chests.length}× ` : ''}${SIZE_NAME[shownSize(chests[0])]} chest${chests.length > 1 ? 's' : ''}`}
                ink={INK}
              />
            )}
          </View>
          <Btn height={50} radius={18} onPress={() => onBuy(offer)}>
            {!!offer.was && <Text style={styles.was}>{offer.was}</Text>}
            <BtnLabel look={GREEN_BTN} size={22}>
              {price}
            </BtnLabel>
          </Btn>
        </LinearGradient>
      </View>
      {pct ? <Burst top={pct} bottom={word} size={74} style={styles.burst} /> : null}
    </View>
  );
}

// --- the season pass ----------------------------------------------------------------------

// onPress(i, r, state, from): `from` { view, img }, where its claim flies from
function PassNode({ r, i, xp, got, prem, onPress }) {
  const icon = useRef(null);
  const claimed = !!got[i];
  const reach = xp >= r.xp;
  const lock = r.prem && !prem;
  const can = reach && !claimed && !lock;
  const bit = r.k === 'gems' ? GEM[(i + 2) % 6] : COIN[(i + 1) % 6];
  const img = (
    <View ref={icon} collapsable={false}>
      {r.k === 'chest' ? <Image source={GCHEST.spooky[`${shownSize(r.t)}-grow`]} style={styles.nodeChest} resizeMode="contain" /> : <Image source={bit} style={styles.nodeImg} />}
    </View>
  );
  return (
    <Pressable onPress={() => onPress(i, r, { claimed, reach, lock }, { view: icon, img: bit })} style={styles.node}>
      <View style={[styles.nodeRing, { backgroundColor: can ? '#b86200' : r.prem ? '#c47a00' : '#6a3aa8' }]}>
        <LinearGradient
          colors={can ? ['#fff6c4', '#ffd84a'] : r.prem ? ['#fff3d0', '#ffd98a'] : ['#f6efff', '#dcc6ff']}
          style={[styles.nodeFace, claimed && { opacity: 0.55 }]}
        >
          {img}
          <Text style={[styles.nodeAmt, { color: r.prem ? '#7a3d00' : INK }]} numberOfLines={1}>
            {rewardText(r)}
          </Text>
          {claimed ? (
            <View style={styles.nodeCheck}>
              <Check size={24} />
            </View>
          ) : null}
        </LinearGradient>
        {r.prem ? <Image source={require('../../assets/squad/crown.png')} style={styles.nodeCrown} resizeMode="contain" /> : null}
      </View>
      <View style={[styles.nodeState, can ? styles.nodeStateCan : null]}>
        {lock && !claimed ? <LockMini size={9} /> : null}
        <Text style={[styles.nodeStateText, can && { color: '#ffffff' }]}>{claimed ? 'GOT IT' : can ? 'CLAIM!' : lock ? 'PASS' : `${r.xp} XP`}</Text>
      </View>
    </Pressable>
  );
}

function Pass({ pass, profile, price, onClaim, onBuy }) {
  const xp = profile?.passXp || 0;
  const prem = !!(profile?.passPrem || {})[pass.season];
  const got = (profile?.passGot || {})[pass.season] || {};
  const max = pass.nodes[pass.nodes.length - 1].xp || 1;
  const ends = pass.ends ? Date.parse(pass.ends) : null;
  const days = ends ? Math.max(0, Math.ceil((ends - Date.now()) / DAY)) : null;
  return (
    <View style={styles.cardWrap}>
      <View style={[styles.cardRing, { backgroundColor: '#2a0a4a' }]}>
        <LinearGradient colors={['#4a1a7a', '#6a22b0', '#c2410c']} locations={[0, 0.55, 1]} start={{ x: 0, y: 0 }} end={{ x: 1, y: 1 }} style={styles.card}>
          <Twinkle size={12} color="#ffd84a" duration={2} style={{ position: 'absolute', top: 12, right: 20 }} />
          <Twinkle size={9} color="#ffffff" duration={2.6} delay={0.8} style={{ position: 'absolute', top: 40, right: 64 }} />
          <View style={styles.row6}>
            <Image source={require('../../assets/squad/crown.png')} style={styles.passCrown} resizeMode="contain" />
            <View style={{ flex: 1 }}>
              <Text style={styles.passSeason}>{(pass.name || 'Season pass').toUpperCase()}</Text>
              <ShadowText style={styles.passTitle} shadows={outline3('#2a0a4a', 2.5)}>
                Season pass
              </ShadowText>
            </View>
            {days != null ? (
              <View style={styles.passLeft}>
                <Text style={styles.passLeftText}>{`${days} DAY${days === 1 ? '' : 'S'} LEFT`}</Text>
              </View>
            ) : null}
          </View>
          <View style={styles.passBar}>
            <LinearGradient colors={['#ffd84a', '#ff8a3d', '#ff5cc6']} start={{ x: 0, y: 0 }} end={{ x: 1, y: 0 }} style={[styles.passFill, { width: `${Math.max(3, Math.min(100, Math.round((xp / max) * 100)))}%` }]} />
            <Text style={styles.passBarText}>{`${fmt(xp)} / ${fmt(max)} PASS XP`}</Text>
          </View>
          <Text style={styles.passHint}>Every chest you open gives pass XP. Gold rewards need the pass.</Text>
          <ScrollView horizontal showsHorizontalScrollIndicator={false} contentContainerStyle={styles.track} style={styles.trackBox}>
            <View style={styles.trackLine} />
            {pass.nodes.map((r, i) => (
              <PassNode key={i} r={r} i={i} xp={xp} got={got} prem={prem} onPress={onClaim} />
            ))}
          </ScrollView>
          {prem ? (
            <View style={styles.passOwned}>
              <Check size={20} />
              <Text style={styles.passOwnedText}>Pass unlocked: every gold reward is yours to claim</Text>
            </View>
          ) : (
            <Btn height={50} radius={18} onPress={onBuy}>
              <BtnLabel look={GOLD_BTN} size={18}>
                {`UNLOCK GOLD REWARDS · ${price}`}
              </BtnLabel>
            </Btn>
          )}
        </LinearGradient>
      </View>
    </View>
  );
}

// `buyOffer(offer, extra)`, `priceOf(key)`, `claimStreak(from)`, `claimPass(i, from)`, `seeOffer(id)`
// (`from`: { view, img }, the prize's icon its coins or gems fly out of)
// `part`: which of the Shop's two tabs (2026-11-16, the user: the bundles get a Special offers tab of their own):
// 'deals' (everything but the bundles) or 'special' (the bundles only). A one-time bundle's window starts when its tab
// first shows.
export const DealsTab = memo(function DealsTab({ config, profile, day, hidden, priceOf, onBuyOffer, onClaimStreak, onClaimPass, onNoAds, onSeen, toast, part }) {
  // the cards side by side, each in a column of its own (REDESIGN_V7)
  const col = (el, key) => (el ? <View key={key} style={styles.wideCol}>{el}</View> : el);
  const C = offersOf(config);
  const hot = lineup(day, hidden);
  const now = Date.now();
  const bought = profile?.offersBought || {};
  const seen = profile?.offerSeen || {};
  const adsFree = !!profile?.adsFree;
  const offers = C.offers
    .filter((o) => o.enabled !== false)
    .filter((o) => !(o.once && bought[o.id]))
    .filter((o) => !(o.once && o.windowHours && seen[o.id] && now > seen[o.id] + o.windowHours * 3600e3))
    .filter((o) => !(o.kind === 'pass' && C.pass.ends && now > Date.parse(C.pass.ends)))
    .filter((o) => (part === 'special') === (o.kind === 'bundle'))
    .sort((a, b) => (a.order || 0) - (b.order || 0));
  // a one-time offer's window starts the first time it shows
  useEffect(() => {
    offers.filter((o) => o.once && o.windowHours && !seen[o.id]).forEach((o) => onSeen(o.id, now));
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [offers.map((o) => o.id).join(','), JSON.stringify(seen)]);
  const priceFor = (o) => (o.kind === 'noads' ? priceOf('removeAds') : priceOf(`offer:${o.id}`));
  const card = (o, i) => {
    if (o.kind === 'noads') return adsFree ? null : <NoAds key={o.id} offer={o} price={priceFor(o)} onPress={onNoAds} />;
    if (o.kind === 'jar') return <Jar key={o.id} offer={o} profile={profile} price={priceFor(o)} onBuy={(off, gems) => (gems < 100 ? toast('The jar is nearly empty. Play to fill it!') : onBuyOffer(off))} />;
    if (o.kind === 'bundle') return <Bundle key={o.id} offer={o} index={i} hot={hot} price={priceFor(o)} seenAt={seen[o.id] || now} onBuy={onBuyOffer} />;
    if (o.kind === 'pass')
      return (
        <Pass
          key={o.id}
          pass={C.pass}
          profile={profile}
          price={priceFor(o)}
          onBuy={() => onBuyOffer(o)}
          onClaim={(idx, r, st, from) => {
            if (st.claimed) return;
            if (!st.reach) return toast(`Open more chests to reach ${r.xp} pass XP`);
            if (st.lock) return toast('This reward needs the season pass');
            onClaimPass(idx, from);
          }}
        />
      );
    return null;
  };
  const first = offers.filter((o) => (o.order || 0) < 0);
  const rest = offers.filter((o) => (o.order || 0) >= 0);
  const streakN = part === 'special' ? 0 : 1;
  // The page a part a frame as it's built (the offers on top, the streak,
  // then each offer). All at once was one 0.3 s frame on the Galaxy A15, and
  // two offers a frame with the streak still one of 0.25 s, built unseen a
  // second after the Shop opened (2026-10-28).
  const shown = useProgressive(first.length + streakN + rest.length, 1, 1);
  const shownRest = Math.max(0, shown - first.length - streakN);
  if (part === 'special' && !offers.length)
    return (
      <View style={styles.specialNone}>
        <Text style={styles.specialNoneT}>No special offers right now.</Text>
        <Text style={styles.specialNoneT}>Check back soon!</Text>
      </View>
    );
  return (
    <View style={styles.tabWide}>
      {first.slice(0, shown).map((o, i) => col(card(o, i), o.id))}
      {streakN && shown > first.length ? col(
        <Streak
          streak={C.streak}
          profile={profile}
          day={day}
          hot={hot}
          onClaim={(today, done, i, from) => (today ? onClaimStreak(from) : toast(done ? 'Already claimed' : `Come back on day ${i + 1}`))}
        />, 'streak'
      ) : null}
      {rest.slice(0, shownRest).map((o, i) => col(card(o, i), o.id))}
      {part !== 'special' && adsFree && offers.some((o) => o.kind === 'noads') ? col(<NoAdsOwned />, 'noads') : null}
    </View>
  );
});

// --- Gems -------------------------------------------------------------------------------

// each pack's card, richer as the packs grow
// (REDESIGN_V8: no pink or purple; blue, teal, coral, green, gold, then the warm "Mountain")
const PACK_LOOK = [
  { bg: ['#f0f9ff', '#c7e9ff'], rim: '#2f7fd6', glow: '#ffffff' },
  { bg: ['#ecfffb', '#b6f0e6'], rim: '#14917e', glow: '#ffffff' },
  { bg: ['#fff3ea', '#ffd0b0'], rim: '#d0561c', glow: '#ffffff' },
  { bg: ['#ecfff5', '#b3f0d2'], rim: '#16a86a', glow: '#ffffff' },
  { bg: ['#fffbe6', '#ffdc8a'], rim: '#c46a00', glow: '#fff6c4' },
  { bg: ['#fff6e2', '#ffe0a8', '#ffc98a'], rim: '#a04a00', glow: '#fff6c4' },
];
const PILE = [[0], [-0.6, 0.6], [-1, 0, 1], [-1.4, -0.45, 0.45, 1.4], [-1.6, -0.8, 0, 0.8, 1.6], [-2, -1, 0, 1, 2]];

function Pack({ p, pi, dbl, price, onPress }) {
  const look = PACK_LOOK[Math.min(pi, PACK_LOOK.length - 1)];
  const pl = PILE[Math.min(PILE.length - 1, Math.max(0, (p.icons || pi + 1) - 1))];
  const big = pi >= 3;
  return (
    <Pressable style={({ pressed }) => [styles.packSlot, pressed && { transform: [{ scale: 0.97 }] }]} onPress={onPress}>
      <View style={[styles.packRing, { backgroundColor: look.rim }]}>
        <LinearGradient colors={look.bg} style={styles.pack}>
          {p.tag ? <RaysSpin size={200} color="#ffffff" opacity={0.55} durationMs={18000} style={{ top: -60, alignSelf: 'center' }} /> : null}
          <View style={styles.gemPile}>
            <Glow size={120} color={look.glow} opacity={0.95} style={{ top: -22 }} />
            {pl.map((o, i) => {
              const c = Math.abs(o);
              const s = Math.round((big ? 50 : 46) - c * 7 + Math.min(pi, 3) * 1.5);
              return <Image key={i} source={GEM[(pi + i) % 6]} style={{ width: s, height: s, marginHorizontal: -6, marginBottom: Math.round(Math.max(0, 8 - c * 6)), transform: [{ rotate: `${Math.round(o * 10)}deg` }] }} />;
            })}
          </View>
          <ShadowText style={styles.packAmt} shadows={outline3(look.rim, 2)}>
            {fmt(dbl ? p.gems * 2 : p.gems)}
          </ShadowText>
          <View style={styles.row4}>
            {dbl ? <Text style={styles.packWas}>{fmt(p.gems)}</Text> : null}
            <Text style={[styles.packName, { color: look.rim }]}>{(p.name || '').toUpperCase()}</Text>
          </View>
          <Btn height={32} radius={13} style={{ alignSelf: 'stretch', marginTop: 4 }} onPress={onPress}>
            <BtnLabel look={GREEN_BTN} size={15}>
              {price}
            </BtnLabel>
          </Btn>
          {dbl ? (
            <View style={styles.pack2x}>
              <Text style={styles.pack2xText}>2X</Text>
            </View>
          ) : null}
        </LinearGradient>
      </View>
      {!!p.tag && (
        <View style={styles.packTagWrap} pointerEvents="none">
          <LinearGradient colors={p.tag === 'BEST VALUE' ? ['#7be884', '#26a94e'] : ['#ffb347', '#ff7a1e']} style={styles.packTag}>
            <Text style={styles.packTagText}>{p.tag}</Text>
          </LinearGradient>
        </View>
      )}
    </Pressable>
  );
}

const SWAP_TAGS = ['', '+12%', '+25%'];

export const GemsTab = memo(function GemsTab({ config, profile, priceOf, onPack, onSwap }) {
  const C = offersOf(config);
  const first = profile?.gemFirst || {};
  const anyDouble = C.packs.some((p) => !first[p.product]);
  // the packs one a frame as the page is built, then the swaps
  const packsShown = useProgressive(C.packs.length + 1, 1, 1);
  // REDESIGN_V8 (the user): every pack side by side, all on screen; the 2X bonus a ribbon above them; the swaps (gems
  // for coins) in a short row under them
  return (
    <View style={styles.gemsWide}>
      {anyDouble ? (
        <LinearGradient colors={['#fffbe0', '#ffe27a', '#ffb000']} start={{ x: 0, y: 0 }} end={{ x: 1, y: 0 }} style={styles.gemRibbon}>
          <Text style={styles.gemRibbon2x}>2X</Text>
          <Text style={styles.gemRibbonT}>FIRST BUY BONUS · every pack gives double gems the first time you buy it</Text>
        </LinearGradient>
      ) : null}
      <View style={styles.packsRow}>
        {C.packs.slice(0, packsShown).map((p, pi) => {
          const key = productKey(p.product);
          return <Pack key={p.product} p={p} pi={pi} dbl={!first[p.product]} price={key ? priceOf(key) : ''} onPress={() => key && onPack(key)} />;
        })}
      </View>
      {packsShown > C.packs.length ? (
        <View style={styles.swapsRow}>
          <Text style={styles.swapsLabel}>Swap gems for coins</Text>
          {SWAPS.map((w, i) => (
            <Pressable key={i} onPress={() => onSwap(i)} style={({ pressed }) => [styles.swapChip, pressed && { transform: [{ translateY: 2 }] }]}>
              <Image source={COIN[(i + 1) % 6]} style={styles.img22} />
              <Text style={styles.swapChipCoins}>{fmt(w.coins)}</Text>
              <View style={styles.swapChipPrice}>
                <Image source={GEM[0]} style={styles.img18} />
                <Text style={styles.swapChipGems}>{fmt(w.gems)}</Text>
              </View>
              {!!SWAP_TAGS[i] && <Text style={styles.swapChipTag}>{SWAP_TAGS[i]}</Text>}
            </Pressable>
          ))}
        </View>
      ) : null}
    </View>
  );
});

const styles = StyleSheet.create({
  // the sections side by side in a row that scrolls sideways (REDESIGN_V7)
  tabWide: { flexDirection: 'row', alignItems: 'center', gap: 18, paddingTop: 10, paddingBottom: 8 },
  wideCol: { width: 330, height: 262 },
  // the Special offers tab with every bundle bought or gone
  specialNone: { flex: 1, alignItems: 'center', justifyContent: 'center', gap: 4 },
  specialNoneT: { fontFamily: F.display, fontSize: 18, color: '#fff6e2', textAlign: 'center', textShadowColor: 'rgba(107,68,38,0.8)', textShadowOffset: { width: 0, height: 1.5 }, textShadowRadius: 1, includeFontPadding: false },
  // (REDESIGN_V8, the user: "No more ads" and the daily streak the same size): every card fills a column of the same
  // height, its parts spaced out to fill it
  flex1: { flex: 1 },
  cardFit: { flex: 1, justifyContent: 'space-between', gap: 6, padding: 10 },
  titleFit: { fontSize: 21, lineHeight: 25, paddingRight: 34 },
  // the Gems tab (REDESIGN_V8)
  gemsWide: { flex: 1, alignItems: 'center', gap: 10, paddingTop: 2 },
  gemRibbon: { height: 26, flexDirection: 'row', alignItems: 'center', gap: 8, paddingHorizontal: 14, borderRadius: 999, borderWidth: 2, borderColor: '#a04a00' },
  gemRibbon2x: { fontFamily: F.display, fontSize: 15, color: '#e0123f', includeFontPadding: false },
  gemRibbonT: { fontFamily: F.black, fontSize: 11.5, color: '#7a3a00', includeFontPadding: false },
  packsRow: { flexDirection: 'row', gap: 10, alignItems: 'flex-end', paddingTop: 10 },
  swapsRow: { flexDirection: 'row', alignItems: 'center', gap: 10 },
  swapsLabel: { fontFamily: F.display, fontSize: 14, color: '#fff6e2', textShadowColor: 'rgba(107,68,38,0.8)', textShadowOffset: { width: 0, height: 1.5 }, textShadowRadius: 1, includeFontPadding: false },
  swapChip: { height: 36, flexDirection: 'row', alignItems: 'center', gap: 5, paddingLeft: 8, paddingRight: 4, borderRadius: 999, backgroundColor: '#fff6e2', borderWidth: 2, borderColor: '#6b4426', borderBottomWidth: 4 },
  swapChipCoins: { fontFamily: F.display, fontSize: 14, color: '#5b3418', includeFontPadding: false },
  swapChipPrice: { flexDirection: 'row', alignItems: 'center', gap: 2, height: 26, paddingHorizontal: 8, borderRadius: 999, backgroundColor: '#ffd24a', borderWidth: 1.5, borderColor: '#9c4d06' },
  swapChipGems: { fontFamily: F.display, fontSize: 13, color: '#5b3418', includeFontPadding: false },
  swapChipTag: { position: 'absolute', right: -6, top: -9, paddingHorizontal: 4, borderRadius: 999, overflow: 'hidden', backgroundColor: '#26a94e', color: '#ffffff', fontFamily: F.black, fontSize: 8.5 },
  img18: { width: 18, height: 18 },
  row4: { flexDirection: 'row', alignItems: 'center', gap: 4 },
  row6: { flexDirection: 'row', alignItems: 'center', gap: 6 },
  img22: { width: 22, height: 22 },
  // a card: a white border in a coloured ring with a deep lip
  cardWrap: {},
  cardRing: { borderRadius: 28, padding: 2.5, paddingBottom: 8 },
  card: { gap: 12, padding: 14, borderRadius: 25.5, borderWidth: 3, borderColor: '#ffffff', overflow: 'hidden' },
  cardTitle: { fontFamily: F.display, fontSize: 20, color: '#ffffff', includeFontPadding: false },
  // inside the card's white border, its corner rounded to match, so the
  // ribbon never reaches past the card
  ribbonClip: { position: 'absolute', top: 0, right: 0, width: 96, height: 96, overflow: 'hidden', borderTopRightRadius: 22.5 },
  ribbon: { position: 'absolute', top: 16, right: -44, width: 150, paddingBottom: 3, transform: [{ rotate: '45deg' }] },
  ribbonFace: { paddingVertical: 4, alignItems: 'center', borderTopWidth: 2, borderBottomWidth: 2, borderColor: '#ffffff' },
  ribbonText: { fontFamily: F.black, fontSize: 11, letterSpacing: 1, color: '#ffffff' },
  // Remove Ads
  noAdsRow: { flexDirection: 'row', alignItems: 'center', gap: 12, paddingTop: 4 },
  noAdsText: { flex: 1, gap: 5, paddingRight: 24 },
  noAdsTitle: { fontFamily: F.display, fontSize: 25, lineHeight: 29, color: '#ffffff', includeFontPadding: false },
  perk: { flexDirection: 'row', alignItems: 'center', gap: 6 },
  perkText: { flex: 1, fontFamily: F.black, fontSize: 12, color: '#ffffff', textShadowColor: 'rgba(110,0,40,0.55)', textShadowOffset: { width: 0, height: 1 }, textShadowRadius: 1 },
  oneTime: { fontFamily: F.black, fontSize: 9.5, letterSpacing: 1.2, color: '#8a4a00', marginTop: -1 },
  owned: { flexDirection: 'row', alignItems: 'center', gap: 10, padding: 12, borderRadius: 20, backgroundColor: 'rgba(255,255,255,0.88)', borderWidth: 2, borderColor: '#ffffff' },
  ownedTitle: { fontFamily: F.display, fontSize: 16, color: '#17803a' },
  ownedNote: { fontFamily: F.bold, fontSize: 11.5, color: '#6a4a9a' },
  // streak
  streakTop: { flexDirection: 'row', alignItems: 'center', gap: 12, paddingTop: 4, paddingLeft: 4 },
  streakText: { flex: 1, gap: 5, paddingRight: 24 },
  streakPerk: { textShadowColor: 'rgba(122,30,0,0.6)' },
  flameNum: { position: 'absolute', left: 0, right: 0, bottom: '9%', alignItems: 'center' },
  flameNumText: { fontFamily: F.display, fontSize: 30, color: '#ffffff', includeFontPadding: false },
  // all seven in one row (user, 2026-10-25), day 7 a little wider
  dayGrid: { flexDirection: 'row', gap: 4, minHeight: 0 },
  daySlot: { flex: 1, minWidth: 0 },
  daySlotLast: { flex: 1.35 },
  dayRing: { flex: 1, borderRadius: 14, padding: 2, paddingBottom: 4 },
  dayFace: { flex: 1, minHeight: 60, alignItems: 'center', justifyContent: 'center', gap: 2, paddingVertical: 3, paddingHorizontal: 2, borderRadius: 12, borderWidth: 2, borderColor: '#ffffff', overflow: 'hidden' },
  dayLabel: { fontFamily: F.black, fontSize: 8.5, letterSpacing: 0.3, maxWidth: '100%' },
  dayImg: { width: 26, height: 26 },
  dayImgBig: { width: 32, height: 32 },
  dayChest: { width: 34, height: 28 },
  dayChestBig: { width: 48, height: 40 },
  dayAmt: { fontFamily: F.display, fontSize: 11.5, includeFontPadding: false, maxWidth: '100%' },
  dayDone: { ...StyleSheet.absoluteFillObject, backgroundColor: 'rgba(255,255,255,0.7)', alignItems: 'center', justifyContent: 'center' },
  streakWait: { height: 52, alignItems: 'center', justifyContent: 'center', gap: 1, borderRadius: 22, backgroundColor: 'rgba(122,30,0,0.28)', borderWidth: 2.5, borderColor: 'rgba(255,255,255,0.85)' },
  streakWaitTitle: { fontFamily: F.display, fontSize: 20, color: '#ffffff', includeFontPadding: false },
  streakWaitText: { fontFamily: F.black, fontSize: 12, letterSpacing: 0.4, color: '#fff3d6' },
  // jar
  jarCard: { flexDirection: 'row', alignItems: 'center', gap: 14 },
  jarRing: { borderTopLeftRadius: 34, borderTopRightRadius: 34, borderBottomLeftRadius: 28, borderBottomRightRadius: 28, backgroundColor: '#45189a', padding: 2.5, paddingBottom: 7 },
  jar: { width: 84, height: 104, borderTopLeftRadius: 32, borderTopRightRadius: 32, borderBottomLeftRadius: 26, borderBottomRightRadius: 26, backgroundColor: 'rgba(255,255,255,0.85)', borderWidth: 3, borderColor: '#ffffff', overflow: 'hidden' },
  jarFill: { position: 'absolute', left: 0, right: 0, bottom: 0 },
  jarGem: { position: 'absolute', left: 8, bottom: 8, width: 42, height: 42 },
  jarGem2: { position: 'absolute', right: 6, bottom: 22, width: 34, height: 34 },
  jarLid: { position: 'absolute', left: '50%', top: 7, width: 34, height: 6, marginLeft: -17, borderRadius: 3, backgroundColor: '#c9a8ef' },
  jarShine: { position: 'absolute', left: 9, top: 18, width: 9, height: 42, borderRadius: 5, backgroundColor: 'rgba(255,255,255,0.8)' },
  jarText: { flex: 1, minWidth: 0, gap: 7 },
  jarNote: { fontFamily: F.heavy, fontSize: 11.5, lineHeight: 15, color: '#45107a' },
  fullChip: { paddingHorizontal: 7, paddingVertical: 1, borderRadius: 999, backgroundColor: '#e01e4a', borderWidth: 2, borderColor: '#ffffff' },
  fullText: { fontFamily: F.black, fontSize: 10, color: '#ffffff' },
  meter: { height: 20, borderRadius: 10, backgroundColor: 'rgba(69,24,154,0.22)', borderWidth: 2, borderColor: '#ffffff', overflow: 'hidden', justifyContent: 'center' },
  meterFill: { position: 'absolute', left: 0, top: 0, bottom: 0, borderRadius: 10 },
  meterText: { textAlign: 'center', fontFamily: F.display, fontSize: 11.5, color: '#ffffff', textShadowColor: '#45189a', textShadowOffset: { width: 0, height: 1.2 }, textShadowRadius: 1, includeFontPadding: false },
  // bundles
  topTagWrap: { position: 'absolute', top: -12, left: 0, right: 0, alignItems: 'center', zIndex: 3 },
  topTag: { paddingHorizontal: 12, paddingVertical: 3, borderRadius: 999, borderWidth: 2.5 },
  topTagText: { fontFamily: F.black, fontSize: 11, letterSpacing: 0.8 },
  bundleBubble: { position: 'absolute', right: -60, top: -80, width: 220, height: 220, borderRadius: 110, backgroundColor: 'rgba(255,255,255,0.14)' },
  bundleBubble2: { position: 'absolute', left: -40, bottom: -70, width: 160, height: 160, borderRadius: 80, backgroundColor: 'rgba(255,255,255,0.1)' },
  bundleHead: { flexDirection: 'row', alignItems: 'flex-start', paddingRight: 64, minHeight: 30 },
  bundleName: { fontFamily: F.display, fontSize: 23, lineHeight: 27, color: '#ffffff', includeFontPadding: false },
  timerChip: { alignSelf: 'flex-start', flexDirection: 'row', alignItems: 'center', gap: 4, marginTop: 4, paddingHorizontal: 8, paddingVertical: 2, borderRadius: 999, backgroundColor: '#ffffff' },
  timerText: { fontFamily: F.black, fontSize: 10.5 },
  burst: { position: 'absolute', top: -14, right: -8, zIndex: 4 },
  pods: { flexDirection: 'row', alignItems: 'center', gap: 2 },
  pod: { flex: 1, minWidth: 0, alignItems: 'center', gap: 2, paddingTop: 6, paddingBottom: 7, paddingHorizontal: 3, borderRadius: 18, backgroundColor: 'rgba(255,255,255,0.92)', borderWidth: 2, borderColor: '#ffffff' },
  podWide: { flex: 1.35 },
  podArt: { height: 56, alignSelf: 'stretch', alignItems: 'center', justifyContent: 'center' },
  // a mountain's: as tall as the chest pod's picture and two-line name, so the row doesn't grow
  podArtTall: { height: 70, justifyContent: 'flex-end' },
  podChest: { width: 76, height: 62 },
  podAmt: { fontFamily: F.display, fontSize: 15, textAlign: 'center', includeFontPadding: false },
  plus: { fontFamily: F.display, fontSize: 20, color: '#ffffff', textShadowColor: 'rgba(40,0,70,0.45)', textShadowOffset: { width: 0, height: 1.5 }, textShadowRadius: 1, includeFontPadding: false },
  was: { fontFamily: F.black, fontSize: 13, color: '#1d6a3a', textDecorationLine: 'line-through' },
  // pass
  passCrown: { width: 40, height: 34 },
  passSeason: { fontFamily: F.black, fontSize: 9.5, letterSpacing: 1, color: '#ffc27a' },
  passTitle: { fontFamily: F.display, fontSize: 23, lineHeight: 27, color: '#ffffff', includeFontPadding: false },
  passLeft: { paddingHorizontal: 8, paddingVertical: 3, borderRadius: 999, backgroundColor: '#ff8a3d', borderWidth: 2, borderColor: '#ffffff' },
  passLeftText: { fontFamily: F.black, fontSize: 9.5, letterSpacing: 0.5, color: '#ffffff' },
  passBar: { height: 22, borderRadius: 11, backgroundColor: 'rgba(0,0,0,0.3)', borderWidth: 2.5, borderColor: '#ffffff', overflow: 'hidden', justifyContent: 'center' },
  passFill: { position: 'absolute', left: 0, top: 0, bottom: 0, borderRadius: 11 },
  passBarText: { textAlign: 'center', fontFamily: F.display, fontSize: 12, color: '#ffffff', textShadowColor: '#2a0a4a', textShadowOffset: { width: 0, height: 1.2 }, textShadowRadius: 1, includeFontPadding: false },
  passHint: { marginTop: -5, fontFamily: F.heavy, fontSize: 11, color: '#f3dcff' },
  trackBox: { marginHorizontal: -14 },
  track: { paddingHorizontal: 14, paddingTop: 10, paddingBottom: 4, gap: 10, alignItems: 'flex-start' },
  trackLine: { position: 'absolute', left: 30, right: 30, top: 52, height: 8, borderRadius: 4, backgroundColor: 'rgba(255,255,255,0.35)' },
  node: { width: 78, alignItems: 'center' },
  nodeRing: { borderRadius: 20, padding: 2, paddingBottom: 5 },
  nodeFace: { width: 74, height: 80, alignItems: 'center', justifyContent: 'center', gap: 2, borderRadius: 18, borderWidth: 2.5, borderColor: '#ffffff', overflow: 'hidden' },
  nodeImg: { width: 34, height: 34 },
  nodeChest: { width: 50, height: 42 },
  nodeAmt: { fontFamily: F.display, fontSize: 12.5, includeFontPadding: false },
  nodeCheck: { ...StyleSheet.absoluteFillObject, alignItems: 'center', justifyContent: 'center' },
  nodeCrown: { position: 'absolute', top: -12, right: -8, width: 26, height: 22 },
  nodeState: { flexDirection: 'row', alignItems: 'center', gap: 3, marginTop: 5, paddingHorizontal: 7, paddingVertical: 1.5, borderRadius: 999, backgroundColor: 'rgba(255,255,255,0.9)' },
  nodeStateCan: { backgroundColor: '#26a94e', borderWidth: 1.5, borderColor: '#ffffff' },
  nodeStateText: { fontFamily: F.black, fontSize: 9.5, color: '#45107a' },
  passOwned: { flexDirection: 'row', alignItems: 'center', gap: 8, padding: 10, borderRadius: 16, backgroundColor: 'rgba(255,255,255,0.18)' },
  passOwnedText: { flex: 1, fontFamily: F.black, fontSize: 12, color: '#ffffff' },
  // the gem packs
  packSlot: { width: 120 },
  packRing: { borderRadius: 26, padding: 2.5, paddingBottom: 7 },
  pack: { alignItems: 'center', gap: 2, paddingTop: 12, paddingHorizontal: 7, paddingBottom: 8, borderRadius: 23.5, borderWidth: 3, borderColor: '#ffffff', overflow: 'hidden' },
  pack2x: { position: 'absolute', left: 8, top: 8, paddingHorizontal: 6, borderRadius: 8, backgroundColor: '#e01e4a', borderWidth: 2, borderColor: '#ffffff', transform: [{ rotate: '-8deg' }] },
  pack2xText: { fontFamily: F.display, fontSize: 13, color: '#ffffff' },
  gemPile: { height: 64, flexDirection: 'row', alignItems: 'flex-end', justifyContent: 'center' },
  packAmt: { fontFamily: F.display, fontSize: 21, lineHeight: 25, color: '#ffffff', includeFontPadding: false },
  packWas: { fontFamily: F.black, fontSize: 11, color: '#a898c8', textDecorationLine: 'line-through' },
  packName: { fontFamily: F.black, fontSize: 10, letterSpacing: 1 },
  packTagWrap: { position: 'absolute', top: -11, left: 0, right: 0, alignItems: 'center' },
  packTag: { paddingHorizontal: 10, paddingVertical: 2, borderRadius: 999, borderWidth: 2, borderColor: '#ffffff' },
  packTagText: { fontFamily: F.black, fontSize: 9.5, letterSpacing: 0.6, color: '#ffffff' },
});
