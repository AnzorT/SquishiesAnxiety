import React, { memo, useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { Animated, Easing, StyleSheet, Text, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Circle, Defs, Path, RadialGradient, Stop } from 'react-native-svg';
import { candyFonts } from '../theme/candyTheme';
import CandyBackground from '../components/candy/CandyBackground';
import CandyButton from '../components/candy/CandyButton';
import OutlinedTitle, { HaloText } from '../components/candy/OutlinedTitle';
import ShadowText from '../components/candy/ShadowText';
import { Shine } from '../components/candy/CandyButton';
import { WHEEL, SLICE, prizeCard } from '../dailySpin';
import sfx from '../audio/sfx';

// The v3 Daily Spin: once a day, before Home. SPIN asks the server
// (onSpin → spinWheel) for today's prize; the wheel whirls while it waits,
// then eases onto the slice it picked, like the design's 4.5s spin, and the
// prize card pops up. onClaim(result) takes it from there (coins are
// already in, CREATE opens the creator, FREE goes to the creature reel).

const SIZE = 290;
const DISC = SIZE - 40; // the design's `inset: 20px`
const R = DISC / 2;
const SPIN_MS = 4500;
const SPIN_EASE = Easing.bezier(0.12, 0.72, 0.06, 1);
const LAPS = 5;

const polar = (deg, r) => {
  const a = ((deg - 90) * Math.PI) / 180;
  return [R + r * Math.cos(a), R + r * Math.sin(a)];
};
// One slice, 1.4° short of the next — the gap shows the white disc (the
// design's conic-gradient with white separators).
const wedge = (i) => {
  const a0 = i * SLICE;
  const a1 = (i + 1) * SLICE - 1.4;
  const [x0, y0] = polar(a0, R + 1);
  const [x1, y1] = polar(a1, R + 1);
  return `M${R} ${R} L${x0} ${y0} A${R + 1} ${R + 1} 0 0 1 ${x1} ${y1} Z`;
};

// ---- rim bulbs ------------------------------------------------------------

function Bulb({ angle, delay }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(t, { toValue: 1, duration: 450, easing: Easing.inOut(Easing.ease), useNativeDriver: true }),
        Animated.timing(t, { toValue: 0, duration: 450, easing: Easing.inOut(Easing.ease), useNativeDriver: true }),
      ])
    );
    const start = setTimeout(() => loop.start(), delay);
    return () => {
      clearTimeout(start);
      loop.stop();
    };
  }, [t, delay]);
  const opacity = t.interpolate({ inputRange: [0, 1], outputRange: [1, 0.45] });
  return (
    <View style={[styles.bulbSpot, { transform: [{ rotate: `${angle}deg` }, { translateY: -131 }] }]} pointerEvents="none">
      <Animated.View style={[styles.bulb, { opacity }]}>
        {/* the bulb plus its glow (box-shadow 0 0 8px 2px), which Android
            views can't draw as a shadow */}
        <Svg width={27} height={27}>
          <Defs>
            <RadialGradient id="bulbGlow" cx="50%" cy="50%" r="50%">
              <Stop offset="0.35" stopColor="#fff0aa" stopOpacity={0.95} />
              <Stop offset="1" stopColor="#fff0aa" stopOpacity={0} />
            </RadialGradient>
            <RadialGradient id="bulb" cx="42%" cy="40%" r="30%">
              <Stop offset="0" stopColor="#ffffff" />
              <Stop offset="0.4" stopColor="#fff6c0" />
              <Stop offset="1" stopColor="#ffb300" />
            </RadialGradient>
          </Defs>
          <Circle cx={13.5} cy={13.5} r={13.5} fill="url(#bulbGlow)" />
          <Circle cx={13.5} cy={13.5} r={5.5} fill="url(#bulb)" />
        </Svg>
      </Animated.View>
    </View>
  );
}

// ---- the two rare-prize icons (they turn with the wheel) -------------------

function CreateIcon() {
  return (
    <View style={styles.icon}>
      <View style={styles.createBall}>
        <Shine inset="14%" height="40%" />
        <View style={styles.plusH} />
        <View style={styles.plusV} />
      </View>
      <Text style={styles.iconSpark}>✦</Text>
      <ShadowText
        style={styles.iconLabel}
        shadows={[
          [0, 1.5, '#45107a'],
          [1, 0, '#45107a'],
          [-1, 0, '#45107a'],
          [0, -1, '#45107a'],
        ]}
      >
        CREATE
      </ShadowText>
    </View>
  );
}

function FreeIcon() {
  return (
    <View style={styles.icon}>
      <View style={styles.giftBase}>
        <LinearGradient colors={['#ffd0ee', '#ff7cc6']} style={StyleSheet.absoluteFill} />
      </View>
      <View style={styles.giftLid}>
        <LinearGradient colors={['#fff7b0', '#ffc233']} style={StyleSheet.absoluteFill} />
      </View>
      <View style={styles.giftRibbon} />
      <View style={styles.giftBow} />
      <ShadowText
        style={styles.giftQ}
        shadows={[
          [0, 1, '#8e1580'],
          [1, 0, '#8e1580'],
          [-1, 0, '#8e1580'],
        ]}
      >
        ?
      </ShadowText>
      <Text style={[styles.iconSpark, { left: -3, right: undefined, top: 6, fontSize: 10, color: '#fff6c0' }]}>✦</Text>
      <ShadowText
        style={styles.iconLabel}
        shadows={[
          [0, 1.5, '#45107a'],
          [1, 0, '#45107a'],
          [-1, 0, '#45107a'],
          [0, -1, '#45107a'],
        ]}
      >
        FREE
      </ShadowText>
    </View>
  );
}

// ---- the wheel -----------------------------------------------------------

const Disc = memo(function Disc({ rot }) {
  const spin = useMemo(() => rot.interpolate({ inputRange: [0, 360], outputRange: ['0deg', '360deg'] }), [rot]);
  const unspin = useMemo(() => rot.interpolate({ inputRange: [0, 360], outputRange: ['0deg', '-360deg'] }), [rot]);
  return (
    <View style={styles.discRing}>
      <Animated.View style={[styles.disc, { transform: [{ rotate: spin }] }]}>
        <Svg width={DISC - 6} height={DISC - 6} viewBox={`0 0 ${DISC} ${DISC}`} style={StyleSheet.absoluteFill}>
          <Circle cx={R} cy={R} r={R} fill="#ffffff" />
          {WHEEL.map((w, i) => (
            <Path key={i} d={wedge(i)} fill={w.color} />
          ))}
        </Svg>
        {WHEEL.map((w, i) => {
          const angle = i * SLICE + SLICE / 2;
          if (w.kind === 'coins') {
            // Coin amounts stay upright while the wheel turns (the design's
            // counter-rotation).
            return (
              <Animated.View
                key={i}
                style={[styles.label, { transform: [{ rotate: `${angle}deg` }, { translateY: -84 }, { rotate: `${-angle}deg` }, { rotate: unspin }] }]}
              >
                <ShadowText
                  style={styles.labelText}
                  shadows={[
                    [0, 2, '#45107a'],
                    [1.5, 0, '#45107a'],
                    [-1.5, 0, '#45107a'],
                    [0, -1.5, '#45107a'],
                  ]}
                >
                  {w.label}
                </ShadowText>
              </Animated.View>
            );
          }
          return (
            <View key={i} style={[styles.iconSpot, { transform: [{ rotate: `${angle}deg` }, { translateY: -88 }] }]}>
              {w.kind === 'create' ? <CreateIcon /> : <FreeIcon />}
            </View>
          );
        })}
      </Animated.View>
    </View>
  );
});

const Wheel = memo(function Wheel({ rot }) {
  const bulbs = useMemo(() => Array.from({ length: 16 }, (_, i) => ({ id: i, angle: i * 22.5, delay: i % 2 ? 450 : 0 })), []);
  return (
    <View style={styles.wheel}>
      <View style={styles.rimLip} />
      <View style={styles.rimRing}>
        <View style={styles.rimWhite}>
          <LinearGradient colors={['#fff3b0', '#ffcc33', '#e08a00']} locations={[0, 0.4, 1]} style={styles.rimFace}>
            <View style={styles.rimTopLight} />
          </LinearGradient>
        </View>
      </View>
      <Disc rot={rot} />
      {/* the gloss over the slices (doesn't turn) */}
      <View style={styles.gloss} pointerEvents="none">
        <Svg width={SIZE - 46} height={SIZE - 46}>
          <Defs>
            <RadialGradient id="wheelGloss" cx="38%" cy="22%" r="38%">
              <Stop offset="0" stopColor="#ffffff" stopOpacity={0.55} />
              <Stop offset="1" stopColor="#ffffff" stopOpacity={0} />
            </RadialGradient>
            <RadialGradient id="wheelEdge" cx="50%" cy="50%" r="50%">
              <Stop offset="0.62" stopColor="#3c0064" stopOpacity={0} />
              <Stop offset="1" stopColor="#3c0064" stopOpacity={0.25} />
            </RadialGradient>
          </Defs>
          <Circle cx={(SIZE - 46) / 2} cy={(SIZE - 46) / 2} r={(SIZE - 46) / 2} fill="url(#wheelEdge)" />
          <Circle cx={(SIZE - 46) / 2} cy={(SIZE - 46) / 2} r={(SIZE - 46) / 2} fill="url(#wheelGloss)" />
        </Svg>
      </View>
      {bulbs.map((b) => (
        <Bulb key={b.id} angle={b.angle} delay={b.delay} />
      ))}
      {/* pointer */}
      <View style={styles.pinRing}>
        <LinearGradient
          colors={['#ffa8e6', '#ff4fbf', '#d3179a']}
          locations={[0, 0.55, 1]}
          start={{ x: 0, y: 0 }}
          end={{ x: 1, y: 1 }}
          style={styles.pinFace}
        />
      </View>
      <View style={styles.pinShine} />
      {/* hub */}
      <View style={styles.hubLip} />
      <View style={styles.hubRing}>
        <View style={styles.hubRim}>
          <Svg width={62} height={62} style={StyleSheet.absoluteFill}>
            <Defs>
              <RadialGradient id="hub" cx="35%" cy="28%" r="80%">
                <Stop offset="0" stopColor="#fffbe0" />
                <Stop offset="0.45" stopColor="#ffd23a" />
                <Stop offset="1" stopColor="#e08a00" />
              </RadialGradient>
            </Defs>
            <Circle cx={31} cy={31} r={46} fill="url(#hub)" />
          </Svg>
          <Shine inset="14%" height="40%" />
          <ShadowText
            style={styles.hubStar}
            shadows={[
              [0, 2, '#a0520a'],
              [1, 0, '#a0520a'],
              [-1, 0, '#a0520a'],
            ]}
          >
            ★
          </ShadowText>
        </View>
      </View>
    </View>
  );
});

// ---- screen ----------------------------------------------------------------

export default function DailySpinScreen({ onSpin, onClaim, onSkip }) {
  const [phase, setPhase] = useState('idle'); // 'idle' | 'spinning' | 'prize' | 'error'
  const [result, setResult] = useState(null);
  const rot = useRef(new Animated.Value(0)).current;
  const shrink = useRef(new Animated.Value(0)).current;
  const pop = useRef(new Animated.Value(0)).current;
  const mounted = useRef(true);
  const whirlRef = useRef(null);
  useEffect(() => {
    mounted.current = true;
    return () => {
      mounted.current = false;
      whirlRef.current && whirlRef.current.stop();
    };
  }, []);

  const land = useCallback(
    (index) =>
      new Promise((resolve) => {
        rot.stopAnimation((v) => {
          // From wherever the whirl is, a few more laps, then stop with the
          // slice's middle under the pointer.
          const stop = (360 - (index * SLICE + SLICE / 2)) % 360;
          const target = v - (v % 360) + 360 * LAPS + stop;
          Animated.timing(rot, { toValue: target, duration: SPIN_MS, easing: SPIN_EASE, useNativeDriver: true }).start(() => resolve());
        });
      }),
    [rot]
  );

  const spin = useCallback(async () => {
    if (phase !== 'idle') return;
    setPhase('spinning');
    // fast ticking while it whirls; the slowing-down ticks once it lands
    const whirl = sfx.loop('whirlLoop');
    whirlRef.current = whirl;
    // Whirl straight away (ramping up) while the server decides.
    rot.stopAnimation((v) => {
      Animated.sequence([
        Animated.timing(rot, { toValue: v + 360, duration: 450, easing: Easing.in(Easing.quad), useNativeDriver: true }),
        Animated.timing(rot, { toValue: v + 360 + 36000, duration: 15000, easing: Easing.linear, useNativeDriver: true }),
      ]).start();
    });
    let res;
    try {
      res = await onSpin();
    } catch (e) {
      res = { error: true };
    }
    whirl.stop();
    if (!mounted.current) return;
    if (res.error || res.already) {
      sfx.play('fail');
      rot.stopAnimation((v) => Animated.timing(rot, { toValue: v + 180, duration: 900, easing: Easing.out(Easing.quad), useNativeDriver: true }).start());
      setResult(res);
      setPhase('error');
      return;
    }
    sfx.play('wheelSpin');
    await land(res.index);
    if (!mounted.current) return;
    setResult(res);
    setPhase('prize');
    sfx.play(res.kind === 'coins' ? 'win' : 'jackpot');
    Animated.timing(shrink, { toValue: 1, duration: 400, easing: Easing.bezier(0.25, 0.1, 0.25, 1), useNativeDriver: true }).start();
    pop.setValue(0);
    Animated.timing(pop, { toValue: 1, duration: 450, easing: Easing.out(Easing.quad), useNativeDriver: true }).start();
  }, [phase, rot, onSpin, land, shrink, pop]);

  const card = phase === 'prize' ? prizeCard(result) : null;
  // wheelScale 0.92 → 0.72 and margin -12 → -40 when the prize shows
  const wheelScale = shrink.interpolate({ inputRange: [0, 1], outputRange: [0.92, 0.72] });
  // shrinking also nudges it down, toward the prize card (the design's
  // margin -12px → -40px)
  const wheelShift = shrink.interpolate({ inputRange: [0, 1], outputRange: [0, 28] });
  const popScale = pop.interpolate({ inputRange: [0, 0.6, 1], outputRange: [0.7, 1.06, 1] });
  const popOpacity = pop.interpolate({ inputRange: [0, 0.6, 1], outputRange: [0, 1, 1] });

  return (
    <CandyBackground sparkles style={styles.container}>
      <View style={styles.column}>
        <View style={styles.titles}>
          <OutlinedTitle text="DAILY SPIN" fill="pink" size={22} />
          <HaloText style={styles.subtitle}>{phase === 'prize' ? 'Here is what you won' : 'One free spin, every day'}</HaloText>
        </View>

        <Animated.View style={[styles.wheelWrap, { transform: [{ translateY: wheelShift }, { scale: wheelScale }] }]}>
          <Wheel rot={rot} />
        </Animated.View>

        <View style={styles.below}>
          {phase === 'idle' ? <CandyButton variant="gold" label="SPIN" onPress={spin} faceStyle={styles.spinFace} textStyle={styles.spinLabel} /> : null}
          {phase === 'spinning' ? <SpinningText /> : null}
          {phase === 'prize' && card ? (
            <Animated.View style={[styles.prize, { opacity: popOpacity, transform: [{ scale: popScale }] }]}>
              <View style={styles.cardRing}>
                <LinearGradient colors={['#fff6fd', '#ffdcf4', '#f5cbff']} locations={[0, 0.6, 1]} style={styles.card}>
                  <Text style={[styles.cardTitle, { color: card.color }]}>{card.title}</Text>
                  <Text style={styles.cardDesc}>{card.desc}</Text>
                </LinearGradient>
              </View>
              <CandyButton variant="blue" label={card.cta} onPress={() => onClaim(result)} faceStyle={styles.ctaFace} textStyle={styles.ctaLabel} />
            </Animated.View>
          ) : null}
          {phase === 'error' ? (
            <View style={styles.prize}>
              <View style={styles.cardRing}>
                <LinearGradient colors={['#fff6fd', '#ffdcf4', '#f5cbff']} locations={[0, 0.6, 1]} style={styles.card}>
                  <Text style={[styles.cardTitle, { color: '#6b3fa0' }]}>{result && result.already ? 'ALREADY SPUN TODAY' : 'THE WHEEL IS RESTING'}</Text>
                  <Text style={styles.cardDesc}>
                    {result && result.already ? 'Come back tomorrow for another spin.' : "We couldn't reach the wheel. Try again next time."}
                  </Text>
                </LinearGradient>
              </View>
              <CandyButton variant="blue" label="CONTINUE" onPress={onSkip} faceStyle={styles.ctaFace} textStyle={styles.ctaLabel} />
            </View>
          ) : null}
        </View>
      </View>
    </CandyBackground>
  );
}

function SpinningText() {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(t, { toValue: 1, duration: 400, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
        Animated.timing(t, { toValue: 0, duration: 400, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
      ])
    );
    loop.start();
    return () => loop.stop();
  }, [t]);
  const scale = t.interpolate({ inputRange: [0, 1], outputRange: [1, 1.04] });
  return (
    <Animated.View style={{ transform: [{ scale }], paddingVertical: 12 }}>
      <HaloText style={styles.spinning}>SPINNING…</HaloText>
    </Animated.View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1 },
  column: { flex: 1, alignItems: 'center', justifyContent: 'center', gap: 14, padding: 24 },
  titles: { alignItems: 'center', gap: 5 },
  subtitle: { fontFamily: candyFonts.bodyHeavy, fontSize: 12 },
  wheelWrap: { width: SIZE, height: SIZE, marginVertical: -12 },
  // room for the tallest thing under the wheel (the prize card + button), so
  // nothing moves when it swaps in
  below: { height: 190, alignItems: 'center', justifyContent: 'flex-start', paddingTop: 6 },
  wheel: { width: SIZE, height: SIZE },
  rimLip: { position: 'absolute', left: -3, right: -3, top: 5, bottom: -11, borderRadius: SIZE, backgroundColor: '#a0520a' },
  rimRing: {
    position: 'absolute',
    left: -3,
    top: -3,
    right: -3,
    bottom: -3,
    borderRadius: SIZE,
    backgroundColor: '#a0520a',
    padding: 3,
    shadowColor: '#ffd250',
    shadowOpacity: 0.55,
    shadowRadius: 20,
    shadowOffset: { width: 0, height: 0 },
  },
  rimWhite: { flex: 1, borderRadius: SIZE, backgroundColor: '#ffffff', padding: 4 },
  rimFace: { flex: 1, borderRadius: SIZE, overflow: 'hidden' },
  rimTopLight: { position: 'absolute', left: 0, right: 0, top: 0, height: 4, backgroundColor: 'rgba(255,255,255,0.7)' },
  discRing: { position: 'absolute', left: 18, top: 18, width: DISC + 4, height: DISC + 4, borderRadius: DISC, backgroundColor: '#a0520a', padding: 2 },
  disc: { flex: 1, borderRadius: DISC, borderWidth: 3, borderColor: '#ffffff', overflow: 'hidden', alignItems: 'center', justifyContent: 'center' },
  label: { position: 'absolute', width: 74, alignItems: 'center' },
  labelText: { color: '#ffffff', fontFamily: candyFonts.display, fontSize: 20, letterSpacing: 0.3, includeFontPadding: false },
  iconSpot: { position: 'absolute', width: 40, height: 48 },
  icon: { width: 40, height: 48 },
  createBall: {
    position: 'absolute',
    left: 5,
    top: 2,
    width: 30,
    height: 30,
    borderRadius: 15,
    borderWidth: 2.5,
    borderColor: '#ffffff',
    backgroundColor: '#ff4fbf',
    overflow: 'hidden',
    alignItems: 'center',
    justifyContent: 'center',
  },
  plusH: { position: 'absolute', width: 14, height: 4, borderRadius: 2, backgroundColor: '#ffffff' },
  plusV: { position: 'absolute', width: 4, height: 14, borderRadius: 2, backgroundColor: '#ffffff' },
  iconSpark: { position: 'absolute', right: -2, top: -3, fontSize: 12, lineHeight: 13, color: '#ffffff' },
  iconLabel: {
    position: 'absolute',
    bottom: 0,
    alignSelf: 'center',
    color: '#ffffff',
    fontFamily: candyFonts.display,
    fontSize: 9,
    letterSpacing: 0.4,
    includeFontPadding: false,
  },
  giftBase: { position: 'absolute', left: 7, right: 7, top: 14, height: 20, borderRadius: 6, borderWidth: 2.5, borderColor: '#ffffff', overflow: 'hidden' },
  giftLid: { position: 'absolute', left: 3, right: 3, top: 9, height: 10, borderRadius: 5, borderWidth: 2.5, borderColor: '#ffffff', overflow: 'hidden' },
  giftRibbon: {
    position: 'absolute',
    left: 17,
    top: 9,
    height: 25,
    width: 6,
    backgroundColor: '#ffd23a',
    borderLeftWidth: 1.5,
    borderRightWidth: 1.5,
    borderColor: '#ffffff',
  },
  giftBow: {
    position: 'absolute',
    left: 11,
    top: 1,
    width: 18,
    height: 10,
    borderRadius: 9,
    backgroundColor: '#ffd23a',
    borderWidth: 2,
    borderColor: '#ffffff',
  },
  giftQ: { position: 'absolute', top: 19, alignSelf: 'center', color: '#ffffff', fontFamily: candyFonts.display, fontSize: 12, includeFontPadding: false },
  gloss: { position: 'absolute', left: 23, top: 23 },
  bulbSpot: { position: 'absolute', left: SIZE / 2 - 13.5, top: SIZE / 2 - 13.5, width: 27, height: 27 },
  bulb: { width: 27, height: 27 },
  pinRing: {
    position: 'absolute',
    left: SIZE / 2 - 21,
    top: -16,
    width: 42,
    height: 42,
    padding: 2,
    backgroundColor: '#8e1580',
    borderTopLeftRadius: 21,
    borderTopRightRadius: 21,
    borderBottomRightRadius: 21,
    transform: [{ rotate: '-45deg' }],
  },
  pinFace: { flex: 1, borderTopLeftRadius: 19, borderTopRightRadius: 19, borderBottomRightRadius: 19, borderWidth: 3, borderColor: '#ffffff' },
  pinShine: { position: 'absolute', left: SIZE / 2 - 6, top: -3, width: 12, height: 8, borderRadius: 6, backgroundColor: 'rgba(255,255,255,0.85)' },
  hubLip: { position: 'absolute', left: SIZE / 2 - 37.5, top: SIZE / 2 - 37.5 + 4, width: 75, height: 75, borderRadius: 38, backgroundColor: '#a0520a' },
  hubRing: {
    position: 'absolute',
    left: SIZE / 2 - 37.5,
    top: SIZE / 2 - 37.5,
    width: 75,
    height: 75,
    borderRadius: 38,
    backgroundColor: '#a0520a',
    padding: 2.5,
  },
  hubRim: { flex: 1, borderRadius: 35, borderWidth: 4, borderColor: '#ffffff', overflow: 'hidden', alignItems: 'center', justifyContent: 'center' },
  hubStar: { color: '#ffffff', fontSize: 26, lineHeight: 30, includeFontPadding: false },
  spinFace: { paddingVertical: 15, paddingHorizontal: 44 },
  spinLabel: { fontSize: 17, letterSpacing: 1 },
  spinning: { fontFamily: candyFonts.display, fontSize: 18, letterSpacing: 2 },
  prize: { alignItems: 'center', gap: 13 },
  cardRing: { borderRadius: 25, backgroundColor: '#a23ad8', padding: 2.5, maxWidth: 280 },
  card: { borderRadius: 22, borderWidth: 3, borderColor: '#ffffff', paddingVertical: 13, paddingHorizontal: 20, alignItems: 'center', gap: 4 },
  cardTitle: { fontFamily: candyFonts.display, fontSize: 18, textAlign: 'center' },
  cardDesc: { color: '#9467bd', fontFamily: candyFonts.bodyHeavy, fontSize: 11, lineHeight: 16, textAlign: 'center' },
  ctaFace: { paddingVertical: 13, paddingHorizontal: 34 },
  ctaLabel: { fontSize: 12, letterSpacing: 1.6 },
});
