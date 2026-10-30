import React, { memo, useEffect, useRef, useState } from 'react';
import { Animated, Easing, Image, ScrollView, StyleSheet, Text, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Circle, Defs, G, Path, RadialGradient, Rect, Stop, Text as SvgText } from 'react-native-svg';
import Pressable from '../components/Pressable';
import ShadowText, { outline3 } from '../components/candy/ShadowText';
import ShineSweep from '../components/candy/ShineSweep';
import { RaysSpin } from '../components/candy/Decor';
import { Twinkle } from '../components/candy/Sparkles';
import { SWAPS, jarGems, lineup, offersOf } from '../squad/data';
import GCHEST from '../squad/groupChestArt';
import { COIN, GEM } from '../squad/currencyArt';
import { F, hms, untilMidnight } from '../squad/ui';
import { BigFlame } from '../components/StreakIcons';
import { productKey } from '../economy';
import { fmtNum } from '../format';
import { useProgressive } from '../components/Skeleton';

// The Shop's Deals and Gems tabs, drawn from Firestore config/offers
// (REDESIGN_V6 ruling 2: which offers show, what they hold, their badges,
// timers and order change without an app update; prices are the stores').
// Restyled 2026-10-24 (user: "modify the UI and style of the deals and gems
// shop"): each offer is its own candy card with a lip, a ribbon or a burst
// badge, and a big price button. The daily streak became one too on
// 2026-10-25, in the Remove Ads card's layout.
//   Deals: offers with a negative `order` first (Remove Ads, $0.99), then the
//   7-day streak, then the rest in order: the gem jar, the bundles, the
//   season pass. With ads already off, Remove Ads is a thank-you line at the
//   end.
//   Gems: the first-buy 2X banner, the packs (double on a pack's first buy),
//   and gems → coins.

const fmt = fmtNum;
const INK = '#45107a';
const SIZE_NAME = { common: 'Common', rare: 'Rare', epic: 'Epic', legendary: 'Legendary', set: 'Rainbow' };
// a bundle's colours (config/offers `style`)
const STYLES = {
  green: { bg: ['#b9f7c9', '#4fd47a', '#1f9a48'], rim: '#17652f', glow: '#eaffd8' },
  blue: { bg: ['#bfe4ff', '#5aa2ff', '#2f5fd0'], rim: '#1f3f9a', glow: '#e3f2ff' },
  pink: { bg: ['#ffc2ec', '#e04fd8', '#7a2ae0'], rim: '#5a1a9a', glow: '#ffe6fa' },
  gold: { bg: ['#fff3b0', '#ffc933', '#f08c00'], rim: '#a04a00', glow: '#fffbe0' },
};
const GREEN_BTN = { colors: ['#e2ffcf', '#7be884', '#26a94e'], rim: '#17652f' };
const GOLD_BTN = { colors: ['#fff9c9', '#ffd84a', '#ffa60a'], rim: '#9c4d06' };
const PINK_BTN = { colors: ['#ffe0f7', '#ff6fcf', '#c02bd9'], rim: '#8e1580' };
const PURPLE_BTN = { colors: ['#f1e2ff', '#b67cff', '#7a2fe0'], rim: '#45189a' };
const rewardText = (r) => (r.k === 'coins' ? `${fmt(r.n)}` : r.k === 'gems' ? `${r.n}` : SIZE_NAME[r.t] || '');
const DAY = 864e5;

// --- shared pieces -----------------------------------------------------------------------

// The candy button: a white-bordered gradient in a ring with a lip, the
// shine across its top. Sinks into its lip while pressed.
function Btn({ look, lip = 5, radius = 16, height, onPress, children, style, disabled }) {
  return (
    <Pressable disabled={disabled} onPress={onPress} style={({ pressed }) => [style, pressed && { transform: [{ translateY: lip - 1 }] }]}>
      <View style={{ borderRadius: radius + 2.5, backgroundColor: look.rim, padding: 2.5, paddingBottom: 2.5 + lip }}>
        <LinearGradient colors={look.colors} locations={[0, 0.5, 1]} style={[styles.btnFace, { height, borderRadius: radius }]}>
          <View pointerEvents="none" style={[styles.btnShine, { borderRadius: radius }]} />
          {children}
        </LinearGradient>
      </View>
    </Pressable>
  );
}
const BtnLabel = ({ children, look, size = 18 }) => (
  <ShadowText style={{ fontFamily: F.display, fontSize: size, color: '#ffffff', includeFontPadding: false }} shadows={outline3(look.rim, 2)}>
    {children}
  </ShadowText>
);

// A section's heading: white candy letters outlined in plum, a note at the right.
function Heading({ title, note, icon }) {
  return (
    <View style={styles.heading}>
      {icon}
      <ShadowText style={styles.headingText} shadows={outline3(INK, 2.5)}>
        {title}
      </ShadowText>
      {note ? <Text style={styles.headingNote}>{note}</Text> : null}
    </View>
  );
}

// A star-burst badge ("80%" over "OFF"), turning slowly back and forth.
function Burst({ top, bottom, size = 70, colors = ['#fff36b', '#ffb000'], ink = '#a3001f', style }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(t, { toValue: 1, duration: 1100, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
        Animated.timing(t, { toValue: 0, duration: 1100, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
      ]),
    );
    loop.start();
    return () => loop.stop();
  }, [t]);
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

// A little TV saying AD, crossed out, wobbling.
function NoAdsArt() {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(t, { toValue: 1, duration: 700, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
        Animated.timing(t, { toValue: 0, duration: 700, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
      ]),
    );
    loop.start();
    return () => loop.stop();
  }, [t]);
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
    <View style={styles.cardWrap}>
      <View style={[styles.cardRing, { backgroundColor: '#8e1040' }]}>
        <LinearGradient colors={['#ffc2d6', '#ff5c8a', '#d81b60']} locations={[0, 0.5, 1]} start={{ x: 0.2, y: 0 }} end={{ x: 0.8, y: 1 }} style={styles.card}>
          <RaysSpin size={340} color="#ffffff" opacity={0.28} durationMs={22000} style={{ left: -150, top: -150 }} />
          <ShineSweep durationMs={3200} strength={0.45} />
          <Twinkle size={14} color="#fff3a0" duration={1.8} style={{ position: 'absolute', top: 14, left: 104 }} />
          <Twinkle size={10} color="#ffffff" duration={2.4} delay={0.7} style={{ position: 'absolute', bottom: 86, left: 14 }} />
          <View style={styles.noAdsRow}>
            <NoAdsArt />
            <View style={styles.noAdsText}>
              <ShadowText style={styles.noAdsTitle} shadows={outline3('#8e1040', 2.5)}>
                NO MORE ADS
              </ShadowText>
              {PERKS.map((p) => (
                <View key={p} style={styles.perk}>
                  <Check size={16} color="#ff3d7f" />
                  <Text style={styles.perkText}>{p}</Text>
                </View>
              ))}
            </View>
          </View>
          <Btn look={GOLD_BTN} height={56} radius={20} lip={6} onPress={onPress}>
            <View style={{ alignItems: 'center' }}>
              <BtnLabel look={GOLD_BTN} size={26}>
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

// The streak's flame with its count on it, flickering from its base; cold
// (violet) before the first day.
function StreakFlame({ count }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(t, { toValue: 1, duration: 520, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
        Animated.timing(t, { toValue: 0, duration: 640, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
      ]),
    );
    loop.start();
    return () => loop.stop();
  }, [t]);
  const W = 82;
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
const rewardLong = (r) => (r.k === 'coins' ? `${fmt(r.n)} coins` : r.k === 'gems' ? `${r.n} gems` : `${SIZE_NAME[r.t] || ''} chest`);
// day i's coin or gem (its claim flies out as this)
const dayBit = (r, i) => (r.k === 'gems' ? GEM[i % 6] : COIN[i % 6]);

// `artRef`: today's art (where its claim flies from)
function StreakDay({ r, i, last, done, today, hot, artRef, onPress }) {
  const look = today ? DAY_LOOK.today : done ? DAY_LOOK.done : last ? DAY_LOOK.big : DAY_LOOK.next;
  const bob = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    if (!today) return undefined;
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(bob, { toValue: 1, duration: 650, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
        Animated.timing(bob, { toValue: 0, duration: 650, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
      ]),
    );
    loop.start();
    return () => loop.stop();
  }, [today, bob]);
  const art =
    r.k === 'chest' ? (
      <Image source={GCHEST[hot][`${r.t}-grow`]} style={last ? styles.dayChestBig : styles.dayChest} resizeMode="contain" />
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
  const perks = ['A free gift every day', `Day ${streak.length}: ${rewardLong(streak[streak.length - 1])}`, 'Miss a day and it starts over'];
  const from = { view: todayArt, img: dayBit(streak[idx], idx) };
  return (
    <View style={styles.cardWrap}>
      <View style={[styles.cardRing, { backgroundColor: '#9a2a06' }]}>
        <LinearGradient colors={['#ffe27a', '#ff9a3d', '#ec4a22']} locations={[0, 0.5, 1]} start={{ x: 0.2, y: 0 }} end={{ x: 0.8, y: 1 }} style={styles.card}>
          <RaysSpin size={340} color="#ffffff" opacity={0.28} durationMs={22000} style={{ left: -150, top: -150 }} />
          <ShineSweep durationMs={3400} delayMs={900} strength={0.4} />
          <Twinkle size={14} color="#ffffff" duration={1.8} style={{ position: 'absolute', top: 12, left: 92 }} />
          <Twinkle size={10} color="#fff3a0" duration={2.4} delay={0.7} style={{ position: 'absolute', top: 96, left: 10 }} />
          <View style={styles.streakTop}>
            <StreakFlame count={cnt} />
            <View style={styles.streakText}>
              <ShadowText style={styles.noAdsTitle} shadows={outline3('#9a2a06', 2.5)}>
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
            <Btn look={GREEN_BTN} height={56} radius={20} lip={6} onPress={() => onClaim(true, false, idx, from)}>
              <View style={{ alignItems: 'center' }}>
                <BtnLabel look={GREEN_BTN} size={24}>
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
    <View style={styles.cardWrap}>
      <View style={[styles.cardRing, { backgroundColor: '#45189a' }]}>
        <LinearGradient colors={['#f7f0ff', '#dcc6ff', '#b48bff']} locations={[0, 0.6, 1]} start={{ x: 0, y: 0 }} end={{ x: 1, y: 1 }} style={[styles.card, styles.jarCard]}>
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
            <Btn look={PINK_BTN} height={38} radius={13} lip={4} onPress={() => onBuy(offer, gems)}>
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

// One thing in a bundle: a white pod with its picture and amount.
const Pod = ({ img, imgStyle, amount, ink, wide }) => (
  <View style={[styles.pod, wide && styles.podWide]}>
    <View style={styles.podArt}>
      <Glow size={wide ? 96 : 70} color="#fff6c4" opacity={0.9} />
      <Image source={img} style={imgStyle} resizeMode="contain" />
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
            {offer.gems > 0 && <Pod img={GEM[(index + 1) % 6]} imgStyle={styles.img44} amount={fmt(offer.gems)} ink="#5a22c8" />}
            {offer.gems > 0 && (offer.coins > 0 || chests.length > 0) && <Text style={styles.plus}>+</Text>}
            {offer.coins > 0 && <Pod img={COIN[(index + 2) % 6]} imgStyle={styles.img42} amount={fmt(offer.coins)} ink="#b86200" />}
            {offer.coins > 0 && chests.length > 0 && <Text style={styles.plus}>+</Text>}
            {chests.length > 0 && (
              <Pod
                wide
                img={GCHEST[hot[0]][`${chests[0]}-grow`]}
                imgStyle={styles.podChest}
                amount={`${chests.length > 1 ? `${chests.length}× ` : ''}${SIZE_NAME[chests[0]]} chest${chests.length > 1 ? 's' : ''}`}
                ink={INK}
              />
            )}
          </View>
          <Btn look={GREEN_BTN} height={50} radius={18} lip={5} onPress={() => onBuy(offer)}>
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
      {r.k === 'chest' ? <Image source={GCHEST.spooky[`${r.t}-grow`]} style={styles.nodeChest} resizeMode="contain" /> : <Image source={bit} style={styles.nodeImg} />}
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
            <Btn look={GOLD_BTN} height={50} radius={18} lip={5} onPress={onBuy}>
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
export const DealsTab = memo(function DealsTab({ config, profile, day, hidden, priceOf, onBuyOffer, onClaimStreak, onClaimPass, onNoAds, onSeen, toast }) {
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
  const bundles = rest.filter((o) => o.kind === 'bundle');
  // The page a part a frame as it's built (the offers on top, the streak,
  // then each offer). All at once was one 0.3 s frame on the Galaxy A15, and
  // two offers a frame with the streak still one of 0.25 s, built unseen a
  // second after the Shop opened (2026-10-28).
  const shown = useProgressive(first.length + 1 + rest.length, 1, 1);
  const shownRest = Math.max(0, shown - first.length - 1);
  return (
    <View style={styles.tab}>
      {first.slice(0, shown).map(card)}
      {shown > first.length && (
        <Streak
          streak={C.streak}
          profile={profile}
          day={day}
          hot={hot}
          onClaim={(today, done, i, from) => (today ? onClaimStreak(from) : toast(done ? 'Already claimed' : `Come back on day ${i + 1}`))}
        />
      )}
      {rest.slice(0, shownRest).map((o, i) => (
        <React.Fragment key={o.id}>
          {o.kind === 'bundle' && o.id === bundles[0]?.id ? <Heading title="Special offers" note="Limited bundles" /> : null}
          {card(o, i)}
        </React.Fragment>
      ))}
      {adsFree && offers.some((o) => o.kind === 'noads') ? <NoAdsOwned /> : null}
    </View>
  );
});

// --- Gems -------------------------------------------------------------------------------

// each pack's card, richer as the packs grow
const PACK_LOOK = [
  { bg: ['#f0f9ff', '#c7e9ff'], rim: '#2f7fd6', glow: '#ffffff' },
  { bg: ['#f6f0ff', '#d9c4ff'], rim: '#6a22d6', glow: '#ffffff' },
  { bg: ['#fff0fa', '#ffc6ea'], rim: '#c0268f', glow: '#ffffff' },
  { bg: ['#ecfff5', '#b3f0d2'], rim: '#16a86a', glow: '#ffffff' },
  { bg: ['#fffbe6', '#ffdc8a'], rim: '#c46a00', glow: '#fff6c4' },
  { bg: ['#fff0fa', '#e6d6ff', '#c7ecff'], rim: '#8e1580', glow: '#fff6c4' },
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
          <ShadowText style={[styles.packAmt, big && { fontSize: 26 }]} shadows={outline3(look.rim, 2)}>
            {fmt(dbl ? p.gems * 2 : p.gems)}
          </ShadowText>
          <View style={styles.row4}>
            {dbl ? <Text style={styles.packWas}>{fmt(p.gems)}</Text> : null}
            <Text style={[styles.packName, { color: look.rim }]}>{(p.name || '').toUpperCase()}</Text>
          </View>
          <Btn look={GREEN_BTN} height={36} radius={13} lip={4} style={{ alignSelf: 'stretch', marginTop: 4 }} onPress={onPress}>
            <BtnLabel look={GREEN_BTN} size={17}>
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
          <LinearGradient colors={p.tag === 'BEST VALUE' ? ['#7be884', '#26a94e'] : ['#ff8fd8', '#c02bd9']} style={styles.packTag}>
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
  return (
    <View style={styles.tab}>
      {anyDouble && (
        <View style={styles.cardWrap}>
          <View style={[styles.cardRing, { backgroundColor: '#a04a00' }]}>
            <LinearGradient colors={['#fffbe0', '#ffe27a', '#ffb000']} locations={[0, 0.55, 1]} start={{ x: 0, y: 0 }} end={{ x: 1, y: 1 }} style={[styles.card, styles.double]}>
              <ShineSweep durationMs={2800} strength={0.6} />
              <Burst top="2X" size={72} colors={['#ff8fb1', '#e0123f']} ink="#ffffff" style={styles.doubleBurst} />
              <View style={{ flex: 1, gap: 2 }}>
                <ShadowText style={styles.doubleTitle} shadows={outline3('#a04a00', 2)}>
                  FIRST BUY BONUS
                </ShadowText>
                <Text style={styles.doubleText}>Every pack gives double gems the first time you buy it.</Text>
              </View>
              <View style={styles.doubleGems}>
                <Image source={GEM[2]} style={[styles.img34, { transform: [{ rotate: '-14deg' }] }]} />
                <Image source={GEM[5]} style={[styles.img34, { marginLeft: -12, marginTop: -16, transform: [{ rotate: '12deg' }] }]} />
              </View>
            </LinearGradient>
          </View>
        </View>
      )}
      <Heading title="Gem packs" note="Gems open the best chests" />
      <View style={styles.packs}>
        {C.packs.slice(0, packsShown).map((p, pi) => {
          const key = productKey(p.product);
          return <Pack key={p.product} p={p} pi={pi} dbl={!first[p.product]} price={key ? priceOf(key) : ''} onPress={() => key && onPack(key)} />;
        })}
      </View>
      {packsShown > C.packs.length && <Heading title="Swap gems for coins" />}
      {packsShown > C.packs.length && (
        <View style={styles.swaps}>
          {SWAPS.map((w, i) => (
            <View key={i} style={styles.swapSlot}>
              <View style={[styles.swapRing]}>
                <LinearGradient colors={['#fffdf2', '#ffefc2']} style={styles.swap}>
                  {!!SWAP_TAGS[i] && (
                    <View style={styles.swapTag}>
                      <Text style={styles.swapTagText}>{SWAP_TAGS[i]}</Text>
                    </View>
                  )}
                  <View style={styles.coinPile}>
                    <Glow size={70} color="#fff6c4" />
                    {Array.from({ length: i + 1 }, (_, j) => (
                      <Image key={j} source={COIN[(i + j + 1) % 6]} style={[styles.img36, { marginHorizontal: -9, marginBottom: j === 1 ? 8 : 0 }]} />
                    ))}
                  </View>
                  <ShadowText style={styles.swapCoins} shadows={outline3('#a04a00', 1.5)}>
                    {fmt(w.coins)}
                  </ShadowText>
                  <Btn look={PURPLE_BTN} height={34} radius={12} lip={4} style={{ alignSelf: 'stretch' }} onPress={() => onSwap(i)}>
                    <Image source={GEM[0]} style={styles.img22} />
                    <BtnLabel look={PURPLE_BTN} size={15}>
                      {fmt(w.gems)}
                    </BtnLabel>
                  </Btn>
                </LinearGradient>
              </View>
            </View>
          ))}
        </View>
      )}
    </View>
  );
});

const styles = StyleSheet.create({
  tab: { gap: 18, paddingTop: 4 },
  row4: { flexDirection: 'row', alignItems: 'center', gap: 4 },
  row6: { flexDirection: 'row', alignItems: 'center', gap: 6 },
  img22: { width: 22, height: 22 },
  img34: { width: 34, height: 34 },
  img36: { width: 36, height: 36 },
  img42: { width: 42, height: 42 },
  img44: { width: 44, height: 44 },
  btnFace: { borderWidth: 3, borderColor: '#ffffff', overflow: 'hidden', flexDirection: 'row', alignItems: 'center', justifyContent: 'center', gap: 8, paddingHorizontal: 12 },
  btnShine: { position: 'absolute', left: '7%', right: '7%', top: 2, height: '42%', backgroundColor: 'rgba(255,255,255,0.5)' },
  heading: { flexDirection: 'row', alignItems: 'center', gap: 7, marginBottom: -6, paddingHorizontal: 2 },
  headingText: { fontFamily: F.display, fontSize: 21, color: '#ffffff', includeFontPadding: false },
  headingNote: { marginLeft: 'auto', fontFamily: F.black, fontSize: 11.5, color: '#6a4a9a' },
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
  dayGrid: { flexDirection: 'row', gap: 4 },
  daySlot: { flex: 1, minWidth: 0 },
  daySlotLast: { flex: 1.35 },
  dayRing: { flex: 1, borderRadius: 14, padding: 2, paddingBottom: 4 },
  dayFace: { flex: 1, minHeight: 74, alignItems: 'center', justifyContent: 'center', gap: 2, paddingVertical: 5, paddingHorizontal: 2, borderRadius: 12, borderWidth: 2, borderColor: '#ffffff', overflow: 'hidden' },
  dayLabel: { fontFamily: F.black, fontSize: 8.5, letterSpacing: 0.3, maxWidth: '100%' },
  dayImg: { width: 26, height: 26 },
  dayImgBig: { width: 32, height: 32 },
  dayChest: { width: 34, height: 28 },
  dayChestBig: { width: 48, height: 40 },
  dayAmt: { fontFamily: F.display, fontSize: 11.5, includeFontPadding: false, maxWidth: '100%' },
  dayDone: { ...StyleSheet.absoluteFillObject, backgroundColor: 'rgba(255,255,255,0.7)', alignItems: 'center', justifyContent: 'center' },
  streakWait: { height: 64, alignItems: 'center', justifyContent: 'center', gap: 1, borderRadius: 22, backgroundColor: 'rgba(122,30,0,0.28)', borderWidth: 2.5, borderColor: 'rgba(255,255,255,0.85)' },
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
  // gems
  double: { flexDirection: 'row', alignItems: 'center', gap: 10, paddingVertical: 12 },
  doubleBurst: {},
  doubleTitle: { fontFamily: F.display, fontSize: 19, color: '#ffffff', includeFontPadding: false },
  doubleText: { fontFamily: F.heavy, fontSize: 12, lineHeight: 15.5, color: '#7a3d00' },
  doubleGems: { flexDirection: 'row', alignItems: 'center' },
  packs: { flexDirection: 'row', flexWrap: 'wrap', justifyContent: 'space-between', rowGap: 20 },
  packSlot: { width: '48.4%' },
  packRing: { borderRadius: 26, padding: 2.5, paddingBottom: 7 },
  pack: { alignItems: 'center', gap: 2, paddingTop: 18, paddingHorizontal: 10, paddingBottom: 10, borderRadius: 23.5, borderWidth: 3, borderColor: '#ffffff', overflow: 'hidden' },
  pack2x: { position: 'absolute', left: 8, top: 8, paddingHorizontal: 6, borderRadius: 8, backgroundColor: '#e01e4a', borderWidth: 2, borderColor: '#ffffff', transform: [{ rotate: '-8deg' }] },
  pack2xText: { fontFamily: F.display, fontSize: 13, color: '#ffffff' },
  gemPile: { height: 64, flexDirection: 'row', alignItems: 'flex-end', justifyContent: 'center' },
  packAmt: { fontFamily: F.display, fontSize: 24, lineHeight: 28, color: '#ffffff', includeFontPadding: false },
  packWas: { fontFamily: F.black, fontSize: 11, color: '#a898c8', textDecorationLine: 'line-through' },
  packName: { fontFamily: F.black, fontSize: 10, letterSpacing: 1 },
  packTagWrap: { position: 'absolute', top: -11, left: 0, right: 0, alignItems: 'center' },
  packTag: { paddingHorizontal: 10, paddingVertical: 2, borderRadius: 999, borderWidth: 2, borderColor: '#ffffff' },
  packTagText: { fontFamily: F.black, fontSize: 9.5, letterSpacing: 0.6, color: '#ffffff' },
  swaps: { flexDirection: 'row', justifyContent: 'space-between' },
  swapSlot: { width: '31.6%' },
  swapRing: { borderRadius: 22, padding: 2, paddingBottom: 6, backgroundColor: '#c46a00' },
  swap: { alignItems: 'center', gap: 4, paddingTop: 10, paddingHorizontal: 7, paddingBottom: 8, borderRadius: 20, borderWidth: 2.5, borderColor: '#ffffff', overflow: 'hidden' },
  coinPile: { height: 46, flexDirection: 'row', alignItems: 'flex-end', justifyContent: 'center' },
  swapCoins: { fontFamily: F.display, fontSize: 18, color: '#ffffff', includeFontPadding: false },
  swapTag: { position: 'absolute', right: 5, top: 5, paddingHorizontal: 5, paddingVertical: 1, borderRadius: 999, backgroundColor: '#26a94e', borderWidth: 1.5, borderColor: '#ffffff' },
  swapTagText: { fontFamily: F.black, fontSize: 9, color: '#ffffff' },
});
