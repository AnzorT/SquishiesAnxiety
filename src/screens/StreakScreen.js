import React, { memo, useEffect, useRef, useState } from 'react';
import { Animated, Easing, StyleSheet, Text, View } from 'react-native';
import Pressable from '../components/Pressable';
import { LinearGradient } from 'expo-linear-gradient';
import { candyColors, candyFonts } from '../theme/candyTheme';
import CandyButton from '../components/candy/CandyButton';
import { HaloText } from '../components/candy/OutlinedTitle';
import ShadowText, { outline3 } from '../components/candy/ShadowText';
import { CandyProgress, SoftPulse } from '../components/candy/Decor';
import ShineSweep from '../components/candy/ShineSweep';
import { CoinIcon } from '../components/candy/Coin';
import { BigFlame, Flame } from '../components/StreakIcons';
import { Chest, GemIcon } from '../squad/ui';
import { CHEST_COINS, STREAK_BONUS, STREAK_DAYS, dailyView, streakReward, streakRewardText } from '../progression';
import sfx from '../audio/sfx';
import { useScreenReady } from '../components/ScreenLayer';
import { Lettering, Orb, PageBg } from '../royal';
import { usePingPong } from '../components/idleLoop';

// The daily streak's own screen (the rules are src/progression.js: the
// streak grows each day the daily chest is opened, every chest pays that
// day's prize, day 10 is half price on a creation).
//
// Two ways in:
//  · `intro` — once a day, right after the Daily Spin, while a streak is
//    alive and today's chest is still shut (App.js): "keep it going", LET'S
//    GO opens the Daily Challenges, Later goes Home.
//  · from the Menu — the same screen with a back button.
//
// All of it on one screen (REDESIGN_V7 step 4, V8): on the left the title, the
// fire (a big flame with the streak on it) with the squishy's line and the coin
// bonus beside it, what today needs and how long is left, and the buttons; on
// the right all ten days' prizes, five to a row, day 10 the jackpot.

function bonusPct(streak) {
  return Math.round(STREAK_BONUS * Math.min(STREAK_DAYS, streak) * 100);
}

// ---- the fire ---------------------------------------------------------------

// The big flame, flickering from its base, with the streak's number on it.
function Fire({ streak, w = 118 }) {
  // one native loop (idleLoop.js) instead of a loop around a sequence, which went back to JS at every step
  const t = usePingPong(1160);
  const W = w;
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
        <ShadowText style={[styles.fireNumberText, w < 110 && { fontSize: 34 }, streak >= 100 && { fontSize: w < 110 ? 26 : 34 }]} shadows={outline3(streak === 0 ? '#1d4f9a' : '#8a1d0c', 3)}>
          {String(streak)}
        </ShadowText>
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
              <CandyProgress pct={(v.claimedN / v.total) * 100} height={11} ring="#b8641c" fill={['#fff3a0', '#ffc233']} style={{ flex: 1 }} />
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
  today: { colors: ['#ffffff', '#ffe9d1', '#ffc690'], ring: '#e8681c', text: '#a04a00' },
  next: { colors: ['#ffffff', '#fff7ea', '#f6e2c4'], ring: '#b8865a', text: candyColors.ink },
};

// The prize's picture: coins, gems, a chest (an extra free one in the Shop).
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
          <RewardArt reward={day.reward} size={32} />
        </View>
        <Text style={[styles.tileCaption, styles.tileCaptionDay, { color: look.text }]} numberOfLines={1} adjustsFontSizeToFit minimumFontScale={0.7}>
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

// The jackpot, the tenth tile of the grid: half price on a creation, the Create card's ball.
function Jackpot({ day, enter }) {
  const anim = useEnter(enter, 9);
  return (
    <Animated.View style={[styles.tileSlot, anim]}>
      <View style={[styles.tileRing, { backgroundColor: '#8a3a0e' }, day.done && { opacity: 0.75 }]}>
        <LinearGradient colors={['#ffe9b8', '#ffb347', '#e8681c']} locations={[0, 0.5, 1]} style={styles.tile}>
          <ShineSweep durationMs={2600} strength={0.6} />
          <Text style={[styles.tileDay, { color: '#7a2310' }]}>{`DAY ${day.n}`}</Text>
          <View style={styles.tileArt}>
            <View style={styles.createBall}>
              <View style={styles.plusH} />
              <View style={styles.plusV} />
            </View>
          </View>
          <ShadowText style={[styles.tileCaption, { color: '#ffffff' }]} shadows={outline3('#8a3a0e', 2)}>
            50% OFF
          </ShadowText>
          {day.done ? <Check /> : null}
        </LinearGradient>
      </View>
      {day.today ? (
        <View style={styles.todayTag} pointerEvents="none">
          <Text style={styles.todayTagText}>TODAY</Text>
        </View>
      ) : null}
    </Animated.View>
  );
}

// ---- the screen ---------------------------------------------------------------

function StreakScreen({ profile, mascot, intro = false, onClose, onOpenDaily }) {
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
    <View style={styles.wRoot}>
      <PageBg />
      <View style={styles.wLeft}>
        <View style={styles.wHead}>
          {intro ? null : <Orb icon="back" onPress={onClose} />}
          <Lettering text="Daily Streak" variant="gold" size={26} />
        </View>
        <View style={styles.wHero}>
          <View style={styles.fireCol}>
            <Fire streak={v.streak} w={84} />
            <HaloText style={styles.fireLabel}>DAY STREAK</HaloText>
          </View>
          <View style={styles.wHeroSide}>
            <View style={styles.bubble}>
              <Text style={styles.bubbleText}>{line}</Text>
            </View>
            <View style={styles.bonusPill}>
              <Flame size={13} />
              <Text style={[styles.bonusText, { flexShrink: 1 }]} numberOfLines={2}>
                {v.streak > 0 ? `+${bonusPct(v.streak)}% squish coins today` : `+${bonusPct(1)}% squish coins a streak day`}
              </Text>
            </View>
          </View>
        </View>
        <TodayCard v={v} todayDay={todayDay} />
        <View style={styles.wFoot}>
          {!v.chestDone ? (
            <CandyButton variant="gold" size="md" pulse label={intro ? 'LET’S GO!' : 'DAILY CHALLENGES'} onPress={onOpenDaily} />
          ) : intro ? (
            <CandyButton variant="blue" size="md" label="CONTINUE" onPress={onClose} />
          ) : null}
          {intro && !v.chestDone ? (
            <Pressable onPress={onClose} hitSlop={10} style={({ pressed }) => [styles.later, pressed && { opacity: 0.6 }]}>
              <HaloText style={styles.laterText}>Later</HaloText>
            </Pressable>
          ) : null}
        </View>
      </View>
      <View style={styles.wRight}>
        <View style={styles.sectionHead}>
          <HaloText style={styles.sectionTitle}>THE DAILY PRIZES</HaloText>
          <HaloText style={styles.sectionNote}>{`Every chest: ${CHEST_COINS} coins + 1 token + the day’s prize`}</HaloText>
        </View>
        <View style={styles.grid}>
          {tiles.map((d, i) => (
            <DayTile key={d.n} day={d} enter={enter} i={i} />
          ))}
          <Jackpot day={jackpot} enter={enter} />
        </View>
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  wRoot: { flex: 1, flexDirection: 'row', backgroundColor: '#24123f', paddingHorizontal: 16, gap: 18 },
  wLeft: { width: '40%', paddingTop: 10, paddingBottom: 10, gap: 8 },
  wHead: { flexDirection: 'row', alignItems: 'center', gap: 10 },
  wHero: { flexDirection: 'row', alignItems: 'center', gap: 10 },
  wHeroSide: { flex: 1, gap: 8, alignItems: 'flex-start' },
  wFoot: { flexDirection: 'row', alignItems: 'center', justifyContent: 'center', gap: 14, marginTop: 'auto' },
  wRight: { flex: 1, justifyContent: 'center', gap: 6 },

  fireCol: { alignItems: 'center' },
  fireNumber: { position: 'absolute', left: 0, right: 0, bottom: '10%', alignItems: 'center' },
  fireNumberText: { fontFamily: candyFonts.display, fontSize: 44, color: '#ffffff', includeFontPadding: false },
  fireLabel: { fontFamily: candyFonts.display, fontSize: 13, letterSpacing: 1, marginTop: 2 },
  bubble: { alignSelf: 'stretch', backgroundColor: '#ffffff', borderRadius: 16, borderWidth: 2.5, borderColor: candyColors.cardRing, paddingHorizontal: 10, paddingVertical: 7 },
  bubbleText: { fontFamily: candyFonts.bodyBlack, fontSize: 11.5, lineHeight: 15, color: candyColors.ink, textAlign: 'center' },
  bonusPill: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: 6,
    alignSelf: 'stretch',
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
  todayPill: { paddingHorizontal: 11, paddingVertical: 4, borderRadius: 999, backgroundColor: '#e8681c', borderWidth: 2, borderColor: '#ffffff' },
  todayPillDone: { backgroundColor: '#26a94e' },
  todayPillText: { fontFamily: candyFonts.display, fontSize: 12, letterSpacing: 0.6, color: '#ffffff', includeFontPadding: false },
  clock: { paddingHorizontal: 9, paddingVertical: 3, borderRadius: 999, backgroundColor: '#f6ead8' },
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

  grid: { flexDirection: 'row', flexWrap: 'wrap', justifyContent: 'flex-start', rowGap: 16, columnGap: 8, paddingTop: 6 },
  tileSlot: { width: '18.6%' },
  tileRing: { borderRadius: 20, padding: 2.5, elevation: 4 },
  tileRingToday: { padding: 3.5, shadowColor: '#ff8a3d', shadowOpacity: 0.8, shadowRadius: 12, elevation: 10 },
  // (overflow hidden: the jackpot's shine sweep waits off its right edge, and showed beside the tile as a white bar)
  tile: { borderRadius: 18, borderWidth: 2.5, borderColor: '#ffffff', alignItems: 'center', paddingTop: 6, paddingBottom: 7, paddingHorizontal: 4, gap: 3, overflow: 'hidden' },
  tileDay: { fontFamily: candyFonts.display, fontSize: 11, letterSpacing: 0.8, includeFontPadding: false },
  tileArt: { height: 36, alignItems: 'center', justifyContent: 'center' },
  tileCaption: { fontFamily: candyFonts.display, fontSize: 14, includeFontPadding: false, maxWidth: '100%' },
  tileCaptionDay: { fontSize: 12 },
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
    backgroundColor: '#e8681c',
    borderWidth: 2,
    borderColor: '#ffffff',
    elevation: 12,
  },
  todayTagText: { fontFamily: candyFonts.display, fontSize: 10, letterSpacing: 0.8, color: '#ffffff', includeFontPadding: false },

  createBall: {
    width: 34,
    height: 34,
    borderRadius: 17,
    borderWidth: 2.5,
    borderColor: '#ffffff',
    backgroundColor: '#ff8a3d',
    alignItems: 'center',
    justifyContent: 'center',
  },
  plusH: { position: 'absolute', width: 16, height: 5, borderRadius: 3, backgroundColor: '#ffffff' },
  plusV: { position: 'absolute', width: 5, height: 16, borderRadius: 3, backgroundColor: '#ffffff' },

  later: { paddingVertical: 4, paddingHorizontal: 18 },
  laterText: { fontFamily: candyFonts.bodyHeavy, fontSize: 13 },
});

// memoized: App re-renders while this is open (Home going to sleep under it,
// a profile change), and those re-rendered the whole screen
export default memo(StreakScreen);
