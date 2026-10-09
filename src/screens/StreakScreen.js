import React, { memo, useEffect, useRef, useState } from 'react';
import { Animated, Easing, Pressable, ScrollView, StyleSheet, Text, View } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { LinearGradient } from 'expo-linear-gradient';
import { candyColors, candyFonts } from '../theme/candyTheme';
import CandyBackground from '../components/candy/CandyBackground';
import CandyButton from '../components/candy/CandyButton';
import OutlinedTitle, { HaloText } from '../components/candy/OutlinedTitle';
import RoundButton, { BackGlyph } from '../components/candy/RoundButton';
import ShadowText, { outline3 } from '../components/candy/ShadowText';
import { CandyProgress, RaysSpin, SoftPulse } from '../components/candy/Decor';
import { Twinkle } from '../components/candy/Sparkles';
import ShineSweep from '../components/candy/ShineSweep';
import { CoinIcon } from '../components/candy/Coin';
import CreatureThumbnail from '../components/CreatureThumbnail';
import { BigFlame, Flame } from '../components/StreakIcons';
import { Chest, GemIcon } from '../squad/ui';
import { CHEST_COINS, STREAK_BONUS, STREAK_DAYS, dailyView, streakReward, streakRewardText } from '../progression';
import sfx from '../audio/sfx';
import { Bone, BoneCard, Reveal } from '../components/Skeleton';
import { useScreenReady } from '../components/ScreenLayer';

// The daily streak's own screen (the rules are src/progression.js: the
// streak grows each day the daily chest is opened, every chest pays that
// day's prize, day 10 is half price on a creation).
//
// Two ways in:
//  · `intro` — once a day, right after the Daily Spin, while a streak is
//    alive and today's chest is still shut (App.js): "keep it going", LET'S
//    GO opens the Daily Challenges, Later goes Home.
//  · from Home's menu (the flame) — the same screen with a back button.
//
// Top to bottom: the fire (a big flame with the streak on it, one of the
// player's own squishies cheering beside it), what today needs and how long
// is left, then all ten days' prizes — days 1-9 as tiles, day 10 as the
// jackpot bar.

const GRID_GAP = 9;

function bonusPct(streak) {
  return Math.round(STREAK_BONUS * Math.min(STREAK_DAYS, streak) * 100);
}

// ---- the fire ---------------------------------------------------------------

// The big flame, flickering from its base, with the streak's number on it.
function Fire({ streak }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(t, { toValue: 1, duration: 520, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
        Animated.timing(t, { toValue: 0, duration: 640, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
      ])
    );
    loop.start();
    return () => loop.stop();
  }, [t]);
  const W = 118;
  const H = W * 1.15;
  const scaleY = t.interpolate({ inputRange: [0, 1], outputRange: [1, 1.06] });
  const scaleX = t.interpolate({ inputRange: [0, 1], outputRange: [1, 0.97] });
  const rotate = t.interpolate({ inputRange: [0, 1], outputRange: ['-1.5deg', '1.5deg'] });
  return (
    <View style={{ width: W, height: H }}>
      <Animated.View style={{ transform: [{ translateY: H / 2 }, { rotate }, { scaleX }, { scaleY }, { translateY: -H / 2 }] }}>
        <BigFlame width={W} cold={streak === 0} />
      </Animated.View>
      <View style={styles.fireNumber} pointerEvents="none">
        <ShadowText style={[styles.fireNumberText, streak >= 100 && { fontSize: 34 }]} shadows={outline3(streak === 0 ? '#45189a' : '#8a1d0c', 3)}>
          {String(streak)}
        </ShadowText>
      </View>
    </View>
  );
}

// A speech bubble with its tail pointing down-right, at the flame.
function Bubble({ text }) {
  return (
    <View style={styles.bubbleWrap}>
      <View style={styles.bubble}>
        <Text style={styles.bubbleText}>{text}</Text>
      </View>
      <View style={styles.bubbleTail} />
    </View>
  );
}

function Hero({ streak, mascot, line }) {
  return (
    <View style={styles.hero}>
      <View style={styles.rays} pointerEvents="none">
        <RaysSpin size={330} opacity={0.32} />
      </View>
      {[
        { x: '12%', y: '8%', s: 14, d: 0 },
        { x: '84%', y: '14%', s: 18, d: 0.6 },
        { x: '90%', y: '64%', s: 12, d: 1.1 },
        { x: '6%', y: '70%', s: 11, d: 1.6 },
      ].map((p, i) => (
        <Twinkle key={i} size={p.s} color={i % 2 ? '#fff3a0' : '#ffffff'} duration={2.2} delay={p.d} style={{ position: 'absolute', left: p.x, top: p.y }} />
      ))}
      <View style={styles.heroRow}>
        <View style={styles.mascotCol}>
          <Bubble text={line} />
          {mascot ? <CreatureThumbnail creature={mascot} mood={streak > 0 ? 'happy' : 'idle'} size={96} /> : <View style={{ height: 96 }} />}
        </View>
        <View style={styles.fireCol}>
          <Fire streak={streak} />
          <HaloText style={styles.fireLabel}>DAY STREAK</HaloText>
        </View>
      </View>
      <View style={styles.bonusPill}>
        <Flame size={13} />
        <Text style={styles.bonusText}>{streak > 0 ? `+${bonusPct(streak)}% squish coins today` : `+${bonusPct(1)}% squish coins for every streak day`}</Text>
      </View>
    </View>
  );
}

// ---- today ------------------------------------------------------------------

function TodayCard({ v, todayDay }) {
  const done = v.chestDone;
  const next = streakReward(todayDay.n + 1);
  return (
    <View style={styles.cardRing}>
      <View style={styles.card}>
        <View style={styles.todayHead}>
          <View style={[styles.todayPill, done && styles.todayPillDone]}>
            <Text style={styles.todayPillText}>{done ? `DAY ${todayDay.n} DONE ✓` : `TODAY · DAY ${todayDay.n}`}</Text>
          </View>
          {done ? null : (
            <View style={[styles.clock, v.streak > 0 && styles.clockHot]}>
              <Text style={[styles.clockText, v.streak > 0 && styles.clockTextHot]}>{`⏱ ${v.resetIn} left`}</Text>
            </View>
          )}
        </View>
        {done ? (
          <Text style={styles.todayText}>
            {`Today’s chest is open. Come back tomorrow for day ${todayDay.n + 1}: `}
            <Text style={styles.todayStrong}>{streakRewardText(next)}</Text>!
          </Text>
        ) : (
          <>
            <Text style={styles.todayText}>
              Claim all{' '}
              <Text style={styles.todayStrong}>{`${v.total} daily challenges`}</Text>
              {v.streak > 0 ? ` before midnight to open the chest and keep your ${v.streak}-day streak.` : ' to open the chest and light your streak.'}
            </Text>
            <View style={styles.progRow}>
              <CandyProgress pct={(v.claimedN / v.total) * 100} height={11} ring="#a23ad8" fill={['#fff3a0', '#ffc233']} style={{ flex: 1 }} />
              <Text style={styles.progText}>{`${v.claimedN}/${v.total}`}</Text>
            </View>
          </>
        )}
      </View>
    </View>
  );
}

// ---- the ten days -------------------------------------------------------------

const LOOK = {
  done: { colors: ['#fffbd6', '#ffe045', '#ffad1f'], ring: '#a04a00', text: '#7a3d00' },
  today: { colors: ['#ffffff', '#ffe3f5', '#ffb8e6'], ring: '#e8339f', text: '#a0157a' },
  next: { colors: ['#ffffff', '#faf3ff', '#ecdcff'], ring: '#a23ad8', text: candyColors.ink },
};

// The prize's picture: coins, gems, a Silver chest.
function RewardArt({ reward, size }) {
  if (reward.kind === 'coins') {
    const big = reward.amount >= 400;
    return (
      <View style={{ width: size * 1.3, height: size, alignItems: 'center', justifyContent: 'center' }}>
        {big ? <View style={{ position: 'absolute', left: 0, top: size * 0.18 }}><CoinIcon size={size * 0.62} /></View> : null}
        {big ? <View style={{ position: 'absolute', right: 0, top: size * 0.18 }}><CoinIcon size={size * 0.62} /></View> : null}
        <CoinIcon size={size * 0.78} />
      </View>
    );
  }
  if (reward.kind === 'gems') return <GemIcon size={size * 0.8} />;
  if (reward.kind === 'chest') return <Chest tier="silver" size={size * 1.1} />;
  return null;
}

function rewardCaption(reward) {
  if (reward.kind === 'coins') return `${reward.amount}`;
  if (reward.kind === 'gems') return `+${reward.amount} GEMS`;
  if (reward.kind === 'chest') return 'FREE CHEST';
  return '50% OFF';
}

function Check() {
  return (
    <View style={styles.check}>
      <Text style={styles.checkText}>✓</Text>
    </View>
  );
}

// fades and pops a tile in, `i` steps after the first
function useEnter(enter, i) {
  const a = 0.05 + i * 0.06;
  const opacity = enter.interpolate({ inputRange: [a, a + 0.25], outputRange: [0, 1], extrapolate: 'clamp' });
  const scale = enter.interpolate({ inputRange: [a, a + 0.25, a + 0.4], outputRange: [0.6, 1.06, 1], extrapolate: 'clamp' });
  return { opacity, transform: [{ scale }] };
}

const DayTile = memo(function DayTile({ day, enter, i }) {
  const look = day.done ? LOOK.done : day.today ? LOOK.today : LOOK.next;
  const tile = (
    <View style={[styles.tileRing, { backgroundColor: look.ring }, day.today && styles.tileRingToday]}>
      <LinearGradient colors={look.colors} locations={[0, 0.5, 1]} style={styles.tile}>
        <Text style={[styles.tileDay, { color: look.text }]}>{`DAY ${day.n}`}</Text>
        <View style={[styles.tileArt, day.done && { opacity: 0.55 }]}>
          <RewardArt reward={day.reward} size={36} />
        </View>
        <Text style={[styles.tileCaption, { color: look.text }]} numberOfLines={1} adjustsFontSizeToFit minimumFontScale={0.7}>
          {rewardCaption(day.reward)}
        </Text>
        {day.done ? <Check /> : null}
      </LinearGradient>
    </View>
  );
  return (
    <Animated.View style={[styles.tileSlot, useEnter(enter, i)]}>
      {day.today ? <SoftPulse to={1.05}>{tile}</SoftPulse> : tile}
      {day.today ? (
        <View style={styles.todayTag} pointerEvents="none">
          <Text style={styles.todayTagText}>TODAY</Text>
        </View>
      ) : null}
    </Animated.View>
  );
});

// The jackpot: half price on a creation, the Create card's pink ball.
function Jackpot({ day, enter }) {
  const anim = useEnter(enter, 9);
  return (
    <Animated.View style={[styles.jackSlot, anim]}>
      <View style={[styles.jackRing, day.done && { opacity: 0.75 }]}>
        <LinearGradient colors={['#ffd6f4', '#ff6fcf', '#c02bd9']} locations={[0, 0.5, 1]} start={{ x: 0, y: 0 }} end={{ x: 1, y: 1 }} style={styles.jack}>
          <ShineSweep durationMs={2600} strength={0.6} />
          <View style={styles.createBall}>
            <View style={styles.plusH} />
            <View style={styles.plusV} />
            <Text style={styles.ballSpark}>✦</Text>
          </View>
          <View style={{ flex: 1 }}>
            <Text style={styles.jackKicker}>{`DAY ${day.n} · JACKPOT`}</Text>
            <ShadowText style={styles.jackTitle} shadows={outline3('#8e1580', 2)}>
              50% OFF
            </ShadowText>
            <Text style={styles.jackDesc}>your next creature creation</Text>
          </View>
          {day.done ? <Check /> : <Twinkle size={22} color="#fff3a0" duration={1.8} />}
        </LinearGradient>
      </View>
      {day.today ? (
        <View style={[styles.todayTag, { left: 18 }]} pointerEvents="none">
          <Text style={styles.todayTagText}>TODAY</Text>
        </View>
      ) : null}
    </Animated.View>
  );
}

// ---- the screen ---------------------------------------------------------------

// The page while it slides in: the flame and squishy, today's card and the
// prize tiles as placeholders.
function StreakBones() {
  return (
    <>
      <View style={[styles.hero, { gap: 10 }]}>
        <Bone tone="sky" w={150} h={150} r={75} />
        <Bone tone="sky" w={220} h={14} r={7} />
      </View>
      <BoneCard style={{ gap: 8 }}>
        <Bone w="45%" h={18} r={9} />
        <Bone w="90%" h={11} r={6} />
        <Bone w="100%" h={12} r={6} />
      </BoneCard>
      <View style={[styles.sectionHead, { gap: 6 }]}>
        <Bone tone="sky" w={170} h={16} r={8} />
        <Bone tone="sky" w={240} h={10} r={5} />
      </View>
      <View style={styles.grid}>
        {Array.from({ length: STREAK_DAYS - 1 }, (_, i) => (
          <View key={i} style={styles.tileSlot}>
            <Bone tone="sky" h={96} r={18} />
          </View>
        ))}
      </View>
    </>
  );
}

export default function StreakScreen({ profile, mascot, intro = false, onClose, onOpenDaily }) {
  const insets = useSafeAreaInsets();
  const ready = useScreenReady();
  const [clock, setClock] = useState(() => new Date());
  useEffect(() => {
    const iv = setInterval(() => setClock(new Date()), 30000);
    return () => clearInterval(iv);
  }, []);
  const enter = useRef(new Animated.Value(0)).current;
  // the tiles' entrance plays once they're built (after the slide-in)
  useEffect(() => {
    if (!ready) return;
    sfx.play(intro ? 'sparkle' : 'popOpen');
    Animated.timing(enter, { toValue: 1, duration: 1400, easing: Easing.out(Easing.quad), useNativeDriver: true }).start();
  }, [enter, intro, ready]);

  const v = dailyView(profile, clock);
  const todayDay = v.track.find((d) => d.today) || v.track[0];
  const tiles = v.track.slice(0, STREAK_DAYS - 1);
  const jackpot = v.track[STREAK_DAYS - 1];
  const name = mascot?.name || 'Your squishy';
  const line = v.chestDone
    ? `Day ${v.streak} done! See you tomorrow!`
    : v.streak > 0
    ? `${v.streak} ${v.streak === 1 ? 'day' : 'days'} in a row! Don’t let the fire go out!`
    : `${name} wants to light the fire. Open today’s chest!`;

  return (
    <CandyBackground sparkles style={[styles.container, { paddingTop: insets.top }]}>
      <View style={styles.header}>
        {intro ? <View style={styles.headerSide} /> : (
          <RoundButton size={36} onPress={onClose}>
            <BackGlyph />
          </RoundButton>
        )}
        <OutlinedTitle text="DAILY STREAK" fill="gold" size={22} outline={3} ring={2} drop={5} letterSpacing={0} />
        <View style={styles.headerSide} />
      </View>

      <ScrollView contentContainerStyle={styles.body} showsVerticalScrollIndicator={false}>
        <Reveal ready={ready} placeholder={<StreakBones />} contentStyle={styles.stack}>
            <Hero streak={v.streak} mascot={mascot} line={line} />
            <TodayCard v={v} todayDay={todayDay} />

            <View style={styles.sectionHead}>
              <HaloText style={styles.sectionTitle}>THE DAILY PRIZES</HaloText>
              <HaloText style={styles.sectionNote}>{`Every chest: ${CHEST_COINS} coins + 1 token + the day’s prize`}</HaloText>
            </View>
            <View style={styles.grid}>
              {tiles.map((d, i) => (
                <DayTile key={d.n} day={d} enter={enter} i={i} />
              ))}
            </View>
            <Jackpot day={jackpot} enter={enter} />
        </Reveal>
      </ScrollView>

      <View style={[styles.footer, { paddingBottom: insets.bottom + 12 }]}>
        {!v.chestDone ? (
          <CandyButton variant="gold" size="lg" pulse label={intro ? 'LET’S GO!' : 'DAILY CHALLENGES'} onPress={onOpenDaily} />
        ) : intro ? (
          <CandyButton variant="blue" size="lg" label="CONTINUE" onPress={onClose} />
        ) : null}
        {intro && !v.chestDone ? (
          <Pressable onPress={onClose} hitSlop={10} style={({ pressed }) => [styles.later, pressed && { opacity: 0.6 }]}>
            <HaloText style={styles.laterText}>Later</HaloText>
          </Pressable>
        ) : null}
      </View>
    </CandyBackground>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1 },
  header: { flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between', paddingHorizontal: 16, paddingTop: 12, paddingBottom: 4 },
  headerSide: { width: 36 },
  body: { paddingHorizontal: 16, paddingBottom: 16, gap: 12 },
  stack: { gap: 12 }, // the body's gap, inside Reveal's wrapper

  hero: { alignItems: 'center', paddingTop: 6, paddingBottom: 2 },
  rays: { position: 'absolute', top: -60, alignSelf: 'center' },
  heroRow: { flexDirection: 'row', alignItems: 'flex-end', justifyContent: 'center', gap: 6 },
  mascotCol: { alignItems: 'center', width: 150, marginBottom: 14 },
  fireCol: { alignItems: 'center' },
  fireNumber: { position: 'absolute', left: 0, right: 0, bottom: '10%', alignItems: 'center' },
  fireNumberText: { fontFamily: candyFonts.display, fontSize: 44, color: '#ffffff', includeFontPadding: false },
  fireLabel: { fontFamily: candyFonts.display, fontSize: 13, letterSpacing: 1, marginTop: 2 },
  bubbleWrap: { alignItems: 'flex-end', alignSelf: 'stretch', marginBottom: 4 },
  bubble: { alignSelf: 'stretch', backgroundColor: '#ffffff', borderRadius: 16, borderWidth: 2.5, borderColor: candyColors.cardRing, paddingHorizontal: 10, paddingVertical: 7 },
  bubbleText: { fontFamily: candyFonts.bodyBlack, fontSize: 11.5, lineHeight: 15, color: candyColors.ink, textAlign: 'center' },
  bubbleTail: {
    width: 14,
    height: 14,
    marginTop: -8,
    marginRight: 26,
    backgroundColor: '#ffffff',
    borderRightWidth: 2.5,
    borderBottomWidth: 2.5,
    borderColor: candyColors.cardRing,
    transform: [{ rotate: '45deg' }],
  },
  bonusPill: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: 6,
    marginTop: 8,
    paddingLeft: 9,
    paddingRight: 13,
    paddingVertical: 5,
    borderRadius: 999,
    backgroundColor: '#fff6d6',
    borderWidth: 2.5,
    borderColor: '#a04a00',
  },
  bonusText: { fontFamily: candyFonts.bodyBlack, fontSize: 12, color: '#a04a00' },

  cardRing: { borderRadius: 24, padding: 2.5, backgroundColor: candyColors.cardRing, elevation: 6 },
  card: { borderRadius: 22, borderWidth: 3, borderColor: '#ffffff', backgroundColor: candyColors.paper, paddingHorizontal: 14, paddingVertical: 12, gap: 8 },
  todayHead: { flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between', gap: 8 },
  todayPill: { paddingHorizontal: 11, paddingVertical: 4, borderRadius: 999, backgroundColor: '#e8339f', borderWidth: 2, borderColor: '#ffffff' },
  todayPillDone: { backgroundColor: '#26a94e' },
  todayPillText: { fontFamily: candyFonts.display, fontSize: 12, letterSpacing: 0.6, color: '#ffffff', includeFontPadding: false },
  clock: { paddingHorizontal: 9, paddingVertical: 3, borderRadius: 999, backgroundColor: '#efe4ff' },
  clockHot: { backgroundColor: '#ffe1dc' },
  clockText: { fontFamily: candyFonts.bodyBlack, fontSize: 11, color: candyColors.inkSoft },
  clockTextHot: { color: '#d9312a' },
  todayText: { fontFamily: candyFonts.bodyHeavy, fontSize: 12.5, lineHeight: 17, color: candyColors.inkSoft },
  todayStrong: { fontFamily: candyFonts.bodyBlack, color: candyColors.ink },
  progRow: { flexDirection: 'row', alignItems: 'center', gap: 8 },
  progText: { fontFamily: candyFonts.display, fontSize: 13, color: candyColors.ink, minWidth: 30, textAlign: 'right' },

  sectionHead: { alignItems: 'center', gap: 2, marginTop: 4 },
  sectionTitle: { fontFamily: candyFonts.display, fontSize: 15, letterSpacing: 1 },
  sectionNote: { fontFamily: candyFonts.bodyHeavy, fontSize: 11 },

  grid: { flexDirection: 'row', flexWrap: 'wrap', justifyContent: 'space-between', rowGap: GRID_GAP + 4, paddingTop: 6 },
  tileSlot: { width: '31.5%' },
  tileRing: { borderRadius: 20, padding: 2.5, elevation: 4 },
  tileRingToday: { padding: 3.5, shadowColor: '#ff4fbf', shadowOpacity: 0.8, shadowRadius: 12, elevation: 10 },
  tile: { borderRadius: 18, borderWidth: 2.5, borderColor: '#ffffff', alignItems: 'center', paddingTop: 7, paddingBottom: 8, paddingHorizontal: 4, gap: 3 },
  tileDay: { fontFamily: candyFonts.display, fontSize: 11, letterSpacing: 0.8, includeFontPadding: false },
  tileArt: { height: 40, alignItems: 'center', justifyContent: 'center' },
  tileCaption: { fontFamily: candyFonts.display, fontSize: 14, includeFontPadding: false, maxWidth: '100%' },
  check: {
    position: 'absolute',
    top: -2,
    right: -2,
    width: 22,
    height: 22,
    borderRadius: 11,
    backgroundColor: '#26a94e',
    borderWidth: 2,
    borderColor: '#ffffff',
    alignItems: 'center',
    justifyContent: 'center',
  },
  checkText: { fontFamily: candyFonts.bodyBlack, fontSize: 12, color: '#ffffff', includeFontPadding: false },
  todayTag: {
    position: 'absolute',
    top: -9,
    alignSelf: 'center',
    paddingHorizontal: 8,
    paddingVertical: 2,
    borderRadius: 999,
    backgroundColor: '#e8339f',
    borderWidth: 2,
    borderColor: '#ffffff',
    elevation: 12,
  },
  todayTagText: { fontFamily: candyFonts.display, fontSize: 10, letterSpacing: 0.8, color: '#ffffff', includeFontPadding: false },

  jackSlot: { marginTop: 4 },
  jackRing: { borderRadius: 24, padding: 2.5, backgroundColor: '#8e1580', elevation: 6 },
  jack: { borderRadius: 22, borderWidth: 3, borderColor: '#ffffff', flexDirection: 'row', alignItems: 'center', gap: 12, paddingVertical: 12, paddingHorizontal: 14, overflow: 'hidden' },
  createBall: {
    width: 50,
    height: 50,
    borderRadius: 25,
    borderWidth: 3,
    borderColor: '#ffffff',
    backgroundColor: '#ff4fbf',
    alignItems: 'center',
    justifyContent: 'center',
  },
  plusH: { position: 'absolute', width: 22, height: 6, borderRadius: 3, backgroundColor: '#ffffff' },
  plusV: { position: 'absolute', width: 6, height: 22, borderRadius: 3, backgroundColor: '#ffffff' },
  ballSpark: { position: 'absolute', right: -3, top: -6, fontSize: 16, color: '#fff3a0' },
  jackKicker: { fontFamily: candyFonts.bodyBlack, fontSize: 11, letterSpacing: 0.8, color: '#ffffff' },
  jackTitle: { fontFamily: candyFonts.display, fontSize: 26, color: '#ffffff', includeFontPadding: false },
  jackDesc: { fontFamily: candyFonts.bodyHeavy, fontSize: 12, color: '#fff0fa' },

  footer: { alignItems: 'center', paddingTop: 10, paddingHorizontal: 16, gap: 8 },
  later: { paddingVertical: 4, paddingHorizontal: 18 },
  laterText: { fontFamily: candyFonts.bodyHeavy, fontSize: 13 },
});
