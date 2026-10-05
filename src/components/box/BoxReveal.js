import React, { memo, useEffect, useMemo, useRef } from 'react';
import { Animated, Easing, StyleSheet, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { TIERS, candyColors } from '../../theme/candyTheme';
import CreatureThumbnail from '../CreatureThumbnail';
import OutlinedTitle from '../candy/OutlinedTitle';
import ShadowText from '../candy/ShadowText';
import ShineSweep from '../candy/ShineSweep';
import { CandyProgress, RaysSpin } from '../candy/Decor';
import { CoinIcon } from '../candy/Coin';

// What came out of the Mystery Box, as in the v3 design: tier-coloured rays,
// falling confetti, a burst of sparks, then the prize pops in and bounces,
// the tier badge stamps down with a shine, and the text rises in. The prize
// is a creature's tokens: the creature, its rarity, "+2 NUBBIN TOKENS" and
// a bar of its tokens so far ("KEY READY! HOLD ITS CARD TO UNLOCK" when the
// set just filled); or coins, when no locked creature is left to give tokens
// for; or, once everything is owned, the Secret creature and "YOU FOUND THE
// SECRET!". Rainbow and Secret pulls shimmer through the colours, Golden
// ones glint gold.
//
// It's built hidden, ahead of time (building ~100 views takes a moment),
// and everything starts when `shown` turns true — so it appears the instant
// the box bursts.

const CONFETTI_COLORS = ['#ff6fbd', '#ffc233', '#7cc8ff', '#9ff7ea', '#c78bff', '#ffffff'];
const CONFETTI = Array.from({ length: 22 }, (_, i) => ({
  id: i,
  x: (i * 41 + 5) % 96,
  w: 6 + (i % 3) * 3,
  h: 10 + (i % 4) * 3,
  color: CONFETTI_COLORS[i % 6],
  dur: 2400 + (i % 5) * 350,
  delay: ((i * 0.17) % 1.6) * 1000,
}));
const EASE_OUT = Easing.bezier(0, 0, 0.58, 1);

// The design's 8-way hard outline + drop under white text.
export const OUTLINE_8 = (c, w = 1.5, down = 3.5) => [
  [w, 0, c],
  [-w, 0, c],
  [0, w, c],
  [0, -w, c],
  [w, w, c],
  [-w, w, c],
  [w, -w, c],
  [-w, -w, c],
  [0, down, c],
];

// 0→1 once, `delay` ms after `active` turns true.
function useOnce(active, duration, delay = 0, easing = EASE_OUT) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    if (!active) {
      t.setValue(0);
      return undefined;
    }
    const a = Animated.sequence([
      Animated.delay(delay),
      Animated.timing(t, {
        toValue: 1,
        duration,
        easing,
        useNativeDriver: true,
      }),
    ]);
    a.start();
    return () => a.stop();
  }, [active, t, duration, delay, easing]);
  return t;
}

// A 0→1 loop, starting `delay` ms after `active` turns true.
function useLoopWhen(active, duration, delay = 0, easing = Easing.linear) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    if (!active) {
      t.setValue(0);
      return undefined;
    }
    const loop = Animated.loop(
      Animated.timing(t, {
        toValue: 1,
        duration,
        easing,
        useNativeDriver: true,
      })
    );
    const start = setTimeout(() => loop.start(), delay);
    return () => {
      clearTimeout(start);
      loop.stop();
    };
  }, [active, t, duration, delay, easing]);
  return t;
}

const ConfettiPiece = memo(function ConfettiPiece({ x, w, h, color, dur, delay, active }) {
  const t = useLoopWhen(active, dur, delay);
  const style = useMemo(
    () => ({
      opacity: t.interpolate({
        inputRange: [0, 0.1, 1],
        outputRange: [0, 1, 0.9],
      }),
      transform: [
        {
          translateY: t.interpolate({
            inputRange: [0, 1],
            outputRange: [-40, 560],
          }),
        },
        {
          rotate: t.interpolate({
            inputRange: [0, 1],
            outputRange: ['0deg', '720deg'],
          }),
        },
      ],
    }),
    [t]
  );
  return <Animated.View style={[styles.confetti, { left: `${x}%`, width: w, height: h, backgroundColor: color }, style]} />;
});

const Spark = memo(function Spark({ dx, dy, size, color, delay, active }) {
  const t = useOnce(active, 1100, delay, Easing.bezier(0.2, 0.8, 0.3, 1));
  const style = useMemo(
    () => ({
      opacity: t.interpolate({
        inputRange: [0, 0.2, 1],
        outputRange: [0, 1, 0],
      }),
      transform: [
        {
          translateX: t.interpolate({
            inputRange: [0, 1],
            outputRange: [0, dx],
          }),
        },
        {
          translateY: t.interpolate({
            inputRange: [0, 1],
            outputRange: [0, dy],
          }),
        },
        {
          scale: t.interpolate({ inputRange: [0, 1], outputRange: [0.2, 1.2] }),
        },
        {
          rotate: t.interpolate({
            inputRange: [0, 1],
            outputRange: ['0deg', '90deg'],
          }),
        },
      ],
    }),
    [t, dx, dy]
  );
  return (
    <Animated.Text
      style={[
        styles.spark,
        {
          fontSize: size,
          lineHeight: size * 1.1,
          color,
          marginLeft: -size / 2,
          marginTop: -size * 0.55,
        },
        style,
      ]}
    >
      ✦
    </Animated.Text>
  );
});

// riseIn: from 22px down at 0.8 scale, overshooting 4px up, then settling
function RiseIn({ active, delay, children }) {
  const t = useOnce(active, 500, delay);
  const style = useMemo(
    () => ({
      opacity: t.interpolate({
        inputRange: [0, 0.7, 1],
        outputRange: [0, 1, 1],
      }),
      transform: [
        {
          translateY: t.interpolate({
            inputRange: [0, 0.7, 1],
            outputRange: [22, -4, 0],
          }),
        },
        {
          scale: t.interpolate({
            inputRange: [0, 0.7, 1],
            outputRange: [0.8, 1.05, 1],
          }),
        },
      ],
    }),
    [t]
  );
  return <Animated.View style={style}>{children}</Animated.View>;
}

// badgeStamp: slams down from 2.6× and a tilt
function TierBadge({ tier, active }) {
  const t = TIERS[tier] || TIERS.Common;
  const s = useOnce(active, 500, 350, Easing.bezier(0.3, 1.4, 0.5, 1));
  const style = useMemo(
    () => ({
      opacity: s.interpolate({
        inputRange: [0, 0.55, 1],
        outputRange: [0, 1, 1],
      }),
      transform: [
        {
          scale: s.interpolate({
            inputRange: [0, 0.55, 1],
            outputRange: [2.6, 0.9, 1],
          }),
        },
        {
          rotate: s.interpolate({
            inputRange: [0, 0.55, 1],
            outputRange: ['-14deg', '3deg', '0deg'],
          }),
        },
      ],
    }),
    [s]
  );
  return (
    <Animated.View style={style}>
      <View style={styles.badgeLip} />
      <View style={[styles.badgeGlow, { shadowColor: t.glow }]}>
        <View style={styles.badgeRim}>
          <LinearGradient colors={t.bg} start={{ x: 0, y: 0 }} end={{ x: 1, y: tier === 'Rainbow' ? 0 : 1 }} style={styles.badgeFace}>
            {active ? <ShineSweep durationMs={1600} delayMs={900} strength={0.85} /> : null}
            <Animated.Text style={[styles.badgeText, { color: t.color }]}>{t.label}</Animated.Text>
          </LinearGradient>
        </View>
      </View>
    </Animated.View>
  );
}

// the creature out of the box (the design's reveal mood), with a jellyBounce on top
function Creature({ creature, tier, active }) {
  const jelly = useLoopWhen(active, 1400, 500, Easing.bezier(0.42, 0, 0.58, 1));
  const style = useMemo(
    () => ({
      transform: [
        {
          scaleX: jelly.interpolate({
            inputRange: [0, 0.25, 0.5, 0.75, 1],
            outputRange: [1, 1.12, 0.92, 1.04, 1],
          }),
        },
        {
          scaleY: jelly.interpolate({
            inputRange: [0, 0.25, 0.5, 0.75, 1],
            outputRange: [1, 0.88, 1.08, 0.97, 1],
          }),
        },
      ],
    }),
    [jelly]
  );
  const wash = tier === 'Secret' || tier === 'Rainbow' ? 'holo' : tier === 'Golden' ? 'gold' : null;
  return (
    <Animated.View style={style}>
      {/* the design's reveal: shoots up out of the box, drops, settles, hops */}
      <CreatureThumbnail creature={creature} mood="reveal" size={140} wash={wash} animate={active} />
    </Animated.View>
  );
}

// A coin stack for a box that paid coins.
function CoinPrize({ active }) {
  const jelly = useLoopWhen(active, 1400, 500, Easing.bezier(0.42, 0, 0.58, 1));
  const scale = jelly.interpolate({ inputRange: [0, 0.25, 0.5, 0.75, 1], outputRange: [1, 1.1, 0.94, 1.03, 1] });
  return (
    <Animated.View style={[styles.coinPrize, { transform: [{ scale }] }]}>
      <CoinIcon size={96} glow />
    </Animated.View>
  );
}

function BoxReveal({ pull, creature, glow, shown }) {
  // popIn for the whole column
  const pop = useOnce(shown, 550, 0, Easing.bezier(0.3, 1.5, 0.5, 1));
  const popStyle = useMemo(
    () => ({
      opacity: pop.interpolate({
        inputRange: [0, 0.6, 1],
        outputRange: [0, 1, 1],
      }),
      transform: [
        {
          scale: pop.interpolate({
            inputRange: [0, 0.6, 1],
            outputRange: [0.4, 1.12, 1],
          }),
        },
        {
          rotate: pop.interpolate({
            inputRange: [0, 0.6, 1],
            outputRange: ['-8deg', '3deg', '0deg'],
          }),
        },
      ],
    }),
    [pop]
  );
  const burst = useMemo(
    () =>
      Array.from({ length: 14 }, (_, i) => {
        const a = (i / 14) * Math.PI * 2;
        const d = 110 + (i % 3) * 30;
        return {
          id: i,
          dx: Math.round(Math.cos(a) * d),
          dy: Math.round(Math.sin(a) * d),
          size: 14 + (i % 3) * 6,
          color: [glow, '#ffc233', '#ffffff'][i % 3],
          delay: (i % 4) * 50,
        };
      }),
    [glow]
  );
  const secret = pull.kind === 'secret';
  const tokens = pull.kind === 'tokens';
  const title = tokens || secret ? pull.name : `+${pull.amount} COINS`;
  const note = secret
    ? 'YOU FOUND THE SECRET!'
    : tokens
      ? `+${pull.amount} ${pull.name.toUpperCase()} TOKEN${pull.amount === 1 ? '' : 'S'}`
      : 'EVERY CREATURE IS ON ITS WAY!';

  return (
    <View style={[styles.fill, { opacity: shown ? 1 : 0 }]} pointerEvents="none">
      <View style={styles.at}>
        <RaysSpin
          size={420}
          durationMs={9000}
          rayDeg={10}
          gapDeg={14}
          opacity={0.75}
          fadeStart={0.2}
          fadeEnd={0.68}
          color={glow}
          style={{ left: -210, top: -210 }}
        />
      </View>
      <View style={styles.confettiAt}>
        {CONFETTI.map((c) => (
          <ConfettiPiece key={c.id} {...c} active={shown} />
        ))}
      </View>
      <View style={styles.at}>
        {burst.map((b) => (
          <Spark key={b.id} {...b} active={shown} />
        ))}
      </View>
      <View style={styles.column}>
        <Animated.View style={[styles.stack, popStyle]}>
          {pull.kind === 'coins' ? <CoinPrize active={shown} /> : <Creature creature={creature} tier={pull.tier} active={shown} />}
          {pull.kind === 'coins' ? null : <TierBadge tier={pull.tier} active={shown} />}
          <RiseIn active={shown} delay={550}>
            <OutlinedTitle text={title} fill={pull.kind === 'coins' ? 'gold' : 'pink'} size={24} />
          </RiseIn>
          <RiseIn active={shown} delay={750}>
            <ShadowText style={[styles.note, tokens && styles.noteTokens]} shadows={OUTLINE_8('#45107a')}>
              {note}
            </ShadowText>
          </RiseIn>
          {tokens ? (
            <RiseIn active={shown} delay={900}>
              <View style={styles.tokenBar}>
                <CandyProgress pct={(pull.have / pull.need) * 100} height={14} ring={candyColors.pinkRing} style={styles.tokenTrack} />
                <ShadowText style={styles.tokenCount} shadows={OUTLINE_8('#45107a', 1.2, 2.5)}>
                  {`${pull.have.toLocaleString()}/${pull.need.toLocaleString()}`}
                </ShadowText>
              </View>
            </RiseIn>
          ) : null}
          {tokens && pull.complete ? (
            <RiseIn active={shown} delay={1100}>
              <ShadowText style={[styles.note, styles.noteWin]} shadows={OUTLINE_8('#45107a')}>
                KEY READY! HOLD ITS CARD TO UNLOCK
              </ShadowText>
            </RiseIn>
          ) : null}
        </Animated.View>
      </View>
    </View>
  );
}

export default memo(BoxReveal);

const styles = StyleSheet.create({
  fill: { ...StyleSheet.absoluteFillObject },
  at: { position: 'absolute', left: '50%', top: '46%', width: 0, height: 0 },
  confettiAt: { position: 'absolute', left: 0, right: 0, top: -200, height: 0 },
  confetti: {
    position: 'absolute',
    top: 0,
    borderRadius: 3,
    borderWidth: 1.5,
    borderColor: '#6b3fa0',
  },
  spark: {
    position: 'absolute',
    includeFontPadding: false,
    textShadowColor: 'rgba(255,255,255,0.8)',
    textShadowRadius: 6,
    textShadowOffset: { width: 0, height: 0 },
  },
  column: {
    ...StyleSheet.absoluteFillObject,
    alignItems: 'center',
    justifyContent: 'center',
  },
  stack: { alignItems: 'center', gap: 6 },
  badgeLip: {
    position: 'absolute',
    left: 0,
    right: 0,
    top: 4,
    bottom: -4,
    borderRadius: 999,
    backgroundColor: '#6b3fa0',
  },
  badgeGlow: {
    borderRadius: 999,
    shadowOpacity: 1,
    shadowRadius: 12,
    shadowOffset: { width: 0, height: 0 },
    elevation: 0,
  },
  badgeRim: { borderRadius: 999, backgroundColor: '#ffffff', padding: 3 },
  badgeFace: {
    borderRadius: 999,
    paddingVertical: 4,
    paddingHorizontal: 18,
    overflow: 'hidden',
  },
  badgeText: {
    fontFamily: 'Fredoka_700Bold',
    fontSize: 16,
    letterSpacing: 2,
    includeFontPadding: false,
  },
  noteWin: { color: '#fff3a0', fontSize: 15 },
  noteTokens: { fontSize: 16 },
  tokenBar: { width: 210, alignItems: 'center', gap: 4 },
  // the column centres its children, so the bar needs its own width
  tokenTrack: { alignSelf: 'stretch' },
  tokenCount: { color: '#ffffff', fontFamily: 'Fredoka_700Bold', fontSize: 13, letterSpacing: 0.5 },
  coinPrize: { width: 140, height: 120, alignItems: 'center', justifyContent: 'center' },
  note: {
    color: '#ffffff',
    fontFamily: 'Fredoka_700Bold',
    fontSize: 14,
    letterSpacing: 1,
    textAlign: 'center',
  },
});
