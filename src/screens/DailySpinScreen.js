import React, { memo, useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { Animated, Easing, Pressable, StyleSheet, Text, View, useWindowDimensions } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Circle, Defs, Path, RadialGradient, Stop } from 'react-native-svg';
import OutlinedTitle from '../components/candy/OutlinedTitle';
import ShadowText from '../components/candy/ShadowText';
import CreatureThumbnail from '../components/CreatureThumbnail';
import IntroBackground from '../squad/IntroBackground';
import { BtnText, CandyBtn, CurrencyIcon, F, GREEN_RING, PINK_RING } from '../squad/ui';
import { MAX_AD_SPINS, WHEEL, SLICE, prizeCard } from '../dailySpin';
import useRewardedAd from '../components/useRewardedAd';
import sfx from '../audio/sfx';

// The Daily Spin, from the "Squish Squad App" shell (2026-10-08): once a
// day, before the main screen. "HI <NAME>!", the DAILY SPIN title, the gold
// wheel with blinking bulbs and its SPIN hub in the middle (the hub is the
// button), and Mittens under it. SPIN asks the server (onSpin → spinWheel)
// for the prize; the wheel whirls while it waits, then eases onto the slice
// it picked (the design's 4.5 s), and the "You won!" popup shows it. After
// Collect: "Watch ad, spin again" — a rewarded video (none with Remove Ads)
// unlocks the hub for one more spin a day (MAX_AD_SPINS; the server counts
// it too) — and "Continue to my squad". The design's made-up video ad is
// our real rewarded ad.

const S = 366; // the wheel's box, scaled down to fit narrow screens
const DISC = 318; // inset 24px, its 3px white border included
const R = (DISC - 6) / 2; // the slices' radius
const HUB = 100;
const SPIN_MS = 4500;
const SPIN_EASE = Easing.bezier(0.12, 0.72, 0.06, 1);
const LAPS = 5;
const PURPLE = '#45107a';
const RIM = '#a0520a';

const polar = (deg, r) => {
  const a = ((deg - 90) * Math.PI) / 180;
  return [R + r * Math.cos(a), R + r * Math.sin(a)];
};
// One slice, 1.4° short of the next — the gap shows the white disc (the
// design's conic-gradient with white separators).
const wedge = (i) => {
  const [x0, y0] = polar(i * SLICE, R + 1);
  const [x1, y1] = polar((i + 1) * SLICE - 1.4, R + 1);
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
  // bulbBlink: opacity 1 → 0.35, scale 1 → 0.75
  const opacity = t.interpolate({ inputRange: [0, 1], outputRange: [1, 0.35] });
  const scale = t.interpolate({ inputRange: [0, 1], outputRange: [1, 0.75] });
  return (
    <View style={[styles.bulbSpot, { transform: [{ rotate: `${angle}deg` }, { translateY: -168 }] }]} pointerEvents="none">
      <Animated.View style={{ opacity, transform: [{ scale }] }}>
        {/* the bulb plus its glow (box-shadow 0 0 8px 2px) */}
        <Svg width={29} height={29}>
          <Defs>
            <RadialGradient id="bulbGlow" cx="50%" cy="50%" r="50%">
              <Stop offset="0.4" stopColor="#fff0aa" stopOpacity={0.95} />
              <Stop offset="1" stopColor="#fff0aa" stopOpacity={0} />
            </RadialGradient>
            <RadialGradient id="bulb" cx="35%" cy="30%" r="70%">
              <Stop offset="0" stopColor="#ffffff" />
              <Stop offset="0.4" stopColor="#fff6c0" />
              <Stop offset="1" stopColor="#ffb300" />
            </RadialGradient>
          </Defs>
          <Circle cx={14.5} cy={14.5} r={14.5} fill="url(#bulbGlow)" />
          <Circle cx={14.5} cy={14.5} r={6.5} fill="url(#bulb)" />
        </Svg>
      </Animated.View>
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
        <Svg width={R * 2} height={R * 2} style={StyleSheet.absoluteFill}>
          <Circle cx={R} cy={R} r={R} fill="#ffffff" />
          {WHEEL.map((w, i) => (
            <Path key={i} d={wedge(i)} fill={w.color} />
          ))}
        </Svg>
        {/* each prize stays upright while the wheel turns (the design's
            counter-rotation) */}
        {WHEEL.map((w, i) => {
          const angle = i * SLICE + SLICE / 2;
          return (
            <Animated.View key={i} style={[styles.label, { transform: [{ rotate: `${angle}deg` }, { translateY: -106 }, { rotate: `${-angle}deg` }, { rotate: unspin }] }]}>
              <CurrencyIcon cur={w.kind} size={26} />
              <ShadowText
                style={styles.labelText}
                shadows={[
                  [0, 2, PURPLE],
                  [1.5, 0, PURPLE],
                  [-1.5, 0, PURPLE],
                  [0, -1.5, PURPLE],
                ]}
              >
                {String(w.amount)}
              </ShadowText>
            </Animated.View>
          );
        })}
      </Animated.View>
    </View>
  );
});

function Hub({ label, onPress }) {
  return (
    <Pressable onPress={onPress} style={({ pressed }) => [styles.hubSpot, pressed && { transform: [{ scale: 0.94 }] }]} hitSlop={6}>
      <View style={styles.hubLip} />
      <View style={styles.hubRing}>
        <View style={styles.hubRim}>
          <Svg width={HUB} height={HUB} style={StyleSheet.absoluteFill}>
            <Defs>
              <RadialGradient id="hub" cx="35%" cy="28%" r="80%">
                <Stop offset="0" stopColor="#fff7c0" />
                <Stop offset="0.45" stopColor="#ffc233" />
                <Stop offset="1" stopColor="#e08a00" />
              </RadialGradient>
            </Defs>
            <Circle cx={HUB / 2} cy={HUB / 2} r={HUB * 0.75} fill="url(#hub)" />
          </Svg>
          <ShadowText
            style={styles.hubText}
            shadows={[
              [0, 2, RIM],
              [1.5, 0, RIM],
              [-1.5, 0, RIM],
              [0, -1.5, RIM],
            ]}
          >
            {label}
          </ShadowText>
        </View>
      </View>
    </Pressable>
  );
}

const Wheel = memo(function Wheel({ rot, hubLabel, onHub }) {
  const bulbs = useMemo(() => Array.from({ length: 16 }, (_, i) => ({ id: i, angle: i * 22.5, delay: i % 2 ? 450 : 0 })), []);
  return (
    <View style={styles.wheel}>
      {/* the warm glow round the rim (0 0 40px) */}
      <Svg width={S + 100} height={S + 100} style={styles.rimGlow} pointerEvents="none">
        <Defs>
          <RadialGradient id="rimGlow" cx="50%" cy="50%" r="50%">
            <Stop offset={S / (S + 100)} stopColor="#ffd250" stopOpacity={0.55} />
            <Stop offset="1" stopColor="#ffd250" stopOpacity={0} />
          </RadialGradient>
        </Defs>
        <Circle cx={(S + 100) / 2} cy={(S + 100) / 2} r={(S + 100) / 2} fill="url(#rimGlow)" />
      </Svg>
      <View style={styles.rimLip} />
      <View style={styles.rimRing} />
      <View style={styles.rimWhite}>
        <LinearGradient colors={['#fff3b0', '#ffcc33', '#e08a00']} locations={[0, 0.4, 1]} style={styles.rimFace}>
          <View style={styles.rimTopLight} />
        </LinearGradient>
      </View>
      {bulbs.map((b) => (
        <Bulb key={b.id} angle={b.angle} delay={b.delay} />
      ))}
      <Disc rot={rot} />
      {/* the pointer: a pink drop, point down, with a shine */}
      <View style={styles.pinRing}>
        <LinearGradient colors={['#ffa8e6', '#ff4fbf', '#d3179a']} locations={[0, 0.55, 1]} start={{ x: 0, y: 0 }} end={{ x: 1, y: 1 }} style={styles.pinFace} />
      </View>
      <View style={styles.pinShine} />
      <Hub label={hubLabel} onPress={onHub} />
    </View>
  );
});

// The sky's extras on this screen: a warm glow behind the wheel and two
// white cloud puffs (the design's radial gradients over the intro sky).
const Glows = memo(function Glows({ w, h }) {
  const glowR = 0.46 * Math.hypot(w / 2, h * 0.53);
  const puff = (cx, cy, solid, fade, a, id) => (
    <React.Fragment key={id}>
      <Defs>
        <RadialGradient id={id} cx="50%" cy="50%" r="50%">
          <Stop offset={solid / fade} stopColor="#ffffff" stopOpacity={a} />
          <Stop offset="1" stopColor="#ffffff" stopOpacity={0} />
        </RadialGradient>
      </Defs>
      <Circle cx={cx} cy={cy} r={fade} fill={`url(#${id})`} />
    </React.Fragment>
  );
  return (
    <Svg width={w} height={h} style={StyleSheet.absoluteFill} pointerEvents="none">
      <Defs>
        <RadialGradient id="spinGlow" cx="50%" cy="50%" r="50%">
          <Stop offset="0" stopColor="#fff0aa" stopOpacity={0.75} />
          <Stop offset="1" stopColor="#fff0aa" stopOpacity={0} />
        </RadialGradient>
      </Defs>
      <Circle cx={w / 2} cy={h * 0.47} r={glowR} fill="url(#spinGlow)" />
      {puff(w * 0.14, h * 0.12, 24, 44, 0.75, 'puffA')}
      {puff(w * 0.86, h * 0.2, 20, 38, 0.6, 'puffB')}
    </Svg>
  );
});

// ---- screen ----------------------------------------------------------------

export default function DailySpinScreen({ onSpin, onDone, bonusLeft = 0, adsFree = false, name, creatures }) {
  const { width: W, height: H } = useWindowDimensions();
  // 'idle' | 'spinning' | 'prize' (the popup) | 'done' | 'adReady' | 'error'
  const [phase, setPhase] = useState('idle');
  const [result, setResult] = useState(null);
  // video spins taken on this screen (the profile's count may lag behind)
  const [usedHere, setUsedHere] = useState(0);
  const [adNote, setAdNote] = useState(null);
  const busyRef = useRef(false);
  const ad = useRewardedAd();
  const spinsLeft = Math.max(0, Math.min(bonusLeft, MAX_AD_SPINS - usedHere));
  const rot = useRef(new Animated.Value(0)).current;
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

  const mittens = useMemo(() => (creatures || []).find((c) => String(c.id) === '1' || c.name === 'Mittens'), [creatures]);
  const k = Math.min(1, (W - 24) / (S + 6));
  // Mittens under the wheel: 150px when there's room, smaller (or none) on
  // short screens
  const mascot = !mittens ? 0 : H >= 860 ? 150 : H >= 760 ? 110 : 0;

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

  const spin = useCallback(
    async (bonus = false) => {
      if (busyRef.current) return;
      busyRef.current = true;
      setAdNote(null);
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
        res = await onSpin(bonus);
      } catch (e) {
        res = { error: true };
      }
      whirl.stop();
      busyRef.current = false;
      if (!mounted.current) return;
      if (bonus && !res.error) setUsedHere((n) => n + 1);
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
      sfx.play(res.jackpot ? 'jackpot' : 'win');
      pop.setValue(0);
      Animated.timing(pop, { toValue: 1, duration: 450, easing: Easing.out(Easing.quad), useNativeDriver: true }).start();
    },
    [rot, onSpin, land, pop]
  );

  const onHub = useCallback(() => {
    if (phase === 'idle') spin(false);
    else if (phase === 'adReady') spin(true);
  }, [phase, spin]);

  // "Watch ad, spin again": the video first (not with Remove Ads), then the
  // hub spins once more
  const watchAd = useCallback(() => {
    const ready = () => mounted.current && setPhase('adReady');
    if (adsFree) ready();
    else if (!ad.show(ready)) setAdNote('The video is still loading. Try again in a moment.');
  }, [adsFree, ad]);

  const card = phase === 'prize' ? prizeCard(result) : null;
  const popScale = pop.interpolate({ inputRange: [0, 0.6, 1], outputRange: [0.7, 1.06, 1] });

  return (
    <IntroBackground>
      <Glows w={W} h={H} />
      <View style={styles.column}>
        <Text style={styles.hi}>{`HI ${(name || 'friend').toUpperCase()}!`}</Text>
        <OutlinedTitle text="DAILY SPIN" fill="pink" size={34} outline={3} ring={2} drop={5} letterSpacing={0} />
        <Text style={styles.sub}>One free spin every day</Text>

        <View style={{ width: (S + 6) * k, height: (S + 14) * k, marginTop: 24 * k, alignItems: 'center' }}>
          <View style={{ width: S, height: S, marginTop: (S * k - S) / 2 + 3 * k, transform: [{ scale: k }] }}>
            <Wheel rot={rot} hubLabel={phase === 'spinning' ? '…' : 'SPIN'} onHub={onHub} />
          </View>
        </View>

        {mascot ? (
          <View style={{ marginTop: 8 }}>
            <CreatureThumbnail creature={mittens} size={mascot} mood={phase === 'done' || phase === 'prize' ? 'happy' : 'idle'} animate />
          </View>
        ) : (
          <View style={{ height: 16 }} />
        )}

        {phase === 'done' ? (
          <View style={styles.after}>
            {spinsLeft > 0 ? (
              <CandyBtn kind="green" onPress={watchAd} padV={8} padH={18} lip={5}>
                <View style={styles.play}>
                  <View style={styles.playTri} />
                </View>
                <View>
                  <BtnText ring={GREEN_RING} size={18}>
                    {adsFree ? 'Spin again' : 'Watch ad, spin again'}
                  </BtnText>
                  <Text style={styles.adSub}>ONE BONUS SPIN PER DAY</Text>
                </View>
              </CandyBtn>
            ) : (
              <Text style={styles.note}>That’s all the spins for today. Come back tomorrow!</Text>
            )}
            {adNote ? <Text style={styles.note}>{adNote}</Text> : null}
            <CandyBtn kind="pink" onPress={onDone} padV={7} padH={28} lip={5}>
              <BtnText ring={PINK_RING} size={17}>
                Continue to my squad
              </BtnText>
            </CandyBtn>
          </View>
        ) : null}
        {phase === 'adReady' ? <Text style={styles.unlocked}>Spin unlocked! Tap SPIN.</Text> : null}
        {phase === 'error' ? (
          <View style={styles.after}>
            <Text style={styles.note}>
              {result && result.already
                ? result.bonus
                  ? 'No more spins today. Come back tomorrow!'
                  : 'You already spun today. Come back tomorrow!'
                : "We couldn't reach the wheel. Try again next time."}
            </Text>
            <CandyBtn kind="pink" onPress={onDone} padV={7} padH={28} lip={5}>
              <BtnText ring={PINK_RING} size={17}>
                Continue to my squad
              </BtnText>
            </CandyBtn>
          </View>
        ) : null}
      </View>

      {card ? (
        <View style={styles.scrim}>
          <Animated.View style={[styles.cardLip, { opacity: pop, transform: [{ scale: popScale }] }]}>
            <View style={styles.card}>
              <Svg width="100%" height="100%" style={StyleSheet.absoluteFill}>
                <Defs>
                  <RadialGradient id="prizeCard" cx="50%" cy="30%" r="80%">
                    <Stop offset="0" stopColor="#ffffff" />
                    <Stop offset="0.6" stopColor="#fff3fb" />
                    <Stop offset="1" stopColor="#f6e2ff" />
                  </RadialGradient>
                </Defs>
                <Circle cx="50%" cy="30%" r="200%" fill="url(#prizeCard)" />
              </Svg>
              <ShadowText
                style={styles.cardTitle}
                shadows={[
                  [0, 3, PURPLE],
                  [2, 0, PURPLE],
                  [-2, 0, PURPLE],
                  [0, -2, PURPLE],
                ]}
              >
                {card.title}
              </ShadowText>
              <CurrencyIcon cur={result.kind} size={84} />
              <Text style={styles.cardAmt}>{card.amount}</Text>
              <Text style={styles.cardWhat}>{card.what}</Text>
              <CandyBtn kind="pink" onPress={() => setPhase('done')} padV={8} lip={5} stretch style={{ marginTop: 6 }}>
                <BtnText ring={PINK_RING} size={20}>
                  Collect
                </BtnText>
              </CandyBtn>
            </View>
          </Animated.View>
        </View>
      ) : null}
    </IntroBackground>
  );
}

const styles = StyleSheet.create({
  column: { flex: 1, alignItems: 'center', justifyContent: 'center', paddingHorizontal: 12, paddingTop: 30, paddingBottom: 20, gap: 4 },
  hi: { fontFamily: F.black, fontSize: 12, letterSpacing: 2, color: PURPLE },
  sub: { fontFamily: F.heavy, fontSize: 13, color: PURPLE },
  wheel: { width: S, height: S },
  rimGlow: { position: 'absolute', left: -50, top: -50 },
  rimLip: { position: 'absolute', left: -3, top: 5, width: S + 6, height: S + 6, borderRadius: S, backgroundColor: RIM },
  rimRing: { position: 'absolute', left: -3, top: -3, width: S + 6, height: S + 6, borderRadius: S, backgroundColor: RIM },
  rimWhite: { position: 'absolute', left: 0, top: 0, width: S, height: S, borderRadius: S, backgroundColor: '#ffffff', padding: 4 },
  rimFace: { flex: 1, borderRadius: S, overflow: 'hidden' },
  rimTopLight: { position: 'absolute', left: 0, right: 0, top: 0, height: 4, backgroundColor: 'rgba(255,255,255,0.7)' },
  bulbSpot: { position: 'absolute', left: S / 2 - 14.5, top: S / 2 - 14.5, width: 29, height: 29 },
  discRing: { position: 'absolute', left: 22, top: 22, width: DISC + 4, height: DISC + 4, borderRadius: DISC, backgroundColor: RIM, padding: 2 },
  disc: { flex: 1, borderRadius: DISC, borderWidth: 3, borderColor: '#ffffff', overflow: 'hidden', alignItems: 'center', justifyContent: 'center' },
  label: { position: 'absolute', width: 84, height: 52, alignItems: 'center', justifyContent: 'center', gap: 2 },
  labelText: { color: '#ffffff', fontFamily: F.display, fontSize: 24, lineHeight: 26, includeFontPadding: false },
  pinRing: {
    position: 'absolute',
    left: S / 2 - 21,
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
  pinShine: { position: 'absolute', left: S / 2 - 6, top: -3, width: 12, height: 8, borderRadius: 6, backgroundColor: 'rgba(255,255,255,0.85)' },
  hubSpot: { position: 'absolute', left: S / 2 - HUB / 2 - 3, top: S / 2 - HUB / 2 - 3, width: HUB + 6, height: HUB + 11 },
  hubLip: { position: 'absolute', left: 0, top: 5, width: HUB + 6, height: HUB + 6, borderRadius: HUB, backgroundColor: RIM },
  hubRing: { position: 'absolute', left: 0, top: 0, width: HUB + 6, height: HUB + 6, borderRadius: HUB, backgroundColor: RIM, padding: 3 },
  hubRim: { flex: 1, borderRadius: HUB, borderWidth: 4, borderColor: '#ffffff', overflow: 'hidden', alignItems: 'center', justifyContent: 'center' },
  hubText: { color: '#ffffff', fontFamily: F.display, fontSize: 25, includeFontPadding: false },
  after: { alignItems: 'center', gap: 9, marginTop: 2 },
  play: { width: 30, height: 30, borderRadius: 15, backgroundColor: '#ffffff', alignItems: 'center', justifyContent: 'center', marginRight: 5 },
  playTri: { width: 0, height: 0, marginLeft: 3, borderTopWidth: 7, borderBottomWidth: 7, borderLeftWidth: 11, borderTopColor: 'transparent', borderBottomColor: 'transparent', borderLeftColor: '#14985a' },
  adSub: { fontFamily: F.black, fontSize: 10.5, letterSpacing: 0.6, color: '#eafff3' },
  note: { fontFamily: F.heavy, fontSize: 13, color: PURPLE, textAlign: 'center', maxWidth: 320 },
  unlocked: { fontFamily: F.display, fontSize: 17, color: '#c02bd9', marginTop: 4 },
  scrim: { ...StyleSheet.absoluteFillObject, backgroundColor: 'rgba(42,15,74,0.55)', alignItems: 'center', justifyContent: 'center', padding: 24 },
  cardLip: { width: '100%', maxWidth: 300, borderRadius: 30, backgroundColor: '#c02bd9', paddingBottom: 6 },
  card: { borderRadius: 30, borderWidth: 3, borderColor: '#ffffff', overflow: 'hidden', paddingTop: 22, paddingHorizontal: 20, paddingBottom: 20, alignItems: 'center', gap: 10 },
  cardTitle: { fontFamily: F.display, fontSize: 30, color: '#ffffff' },
  cardAmt: { fontFamily: F.display, fontSize: 34, lineHeight: 38, color: '#8e1580' },
  cardWhat: { fontFamily: F.black, fontSize: 13, letterSpacing: 1.5, color: '#6a3d9a' },
});
