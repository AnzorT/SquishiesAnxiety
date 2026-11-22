import React, { memo, useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { Animated, Easing, StyleSheet, Text, View, useWindowDimensions } from 'react-native';
import Pressable from '../components/Pressable';
import Svg, { Circle, Defs, Ellipse, Line, LinearGradient, Path, RadialGradient, Stop } from 'react-native-svg';
import ShadowText from '../components/candy/ShadowText';
import ChestSmash from '../components/ChestSmash';
import VaultLoader, { buddyUriOf } from '../components/VaultLoader';
import { PrizeArt } from '../components/LevelBits';
import { HIDDEN, lineup } from '../squad/data';
import { BtnLabel, SdButton } from '../squishdoku/ui';
import { InkText, Lettering, PageBg, RIM } from '../royal';
import { usePingPong } from '../components/idleLoop';
import { F } from '../squad/ui';
import { MAX_AD_SPINS, WHEEL, SLICE, prizeCard, todayKey } from '../dailySpin';
import useRewardedAd from '../components/useRewardedAd';
import sfx from '../audio/sfx';

// The Daily Spin, from the "Squish Squad App" shell (2026-10-08): once a
// day, before the main screen. "HI <NAME>!", the DAILY SPIN title, the wheel
// with blinking lights and its SPIN hub in the middle (the hub is the
// button). SPIN asks the server (onSpin → spinWheel) for the prize; the
// wheel whirls while it waits, then eases onto the slice it picked (the
// design's 4.5 s), and the "You won!" popup shows it. After Collect: "Watch
// ad, spin again" — a rewarded video (none with Remove Ads) unlocks the hub
// for one more spin a day (MAX_AD_SPINS; the server counts it too) — and
// "Continue to my squad". The design's made-up video ad is our real
// rewarded ad.
//
// 2026-11-17 (the user): the wheel in the game's look — a gold rim with an
// ink outline, cream and wood slices (the chest's gold, the jackpot's
// amethyst), the menu's coins and gems (squad/currencyArt) and today's
// chest; the prizes turn with the wheel (no longer kept upright); the
// buttons in the app's gold and white (as the games' cards); the popup's
// prize and amount on one row. One slice is a Mystery Box: a Common chest of
// today's first HOT group, which the server opens; Open plays the chest
// smash (under "To the treasure vault", as the level road's chests).
//
// 2026-11-18 (the user: the outer ring "is not spinning and it should", and the
// pointer "needs to be affected by the wheel that is spinning like in real
// spinning wheels"): the rim's lights turn with the wheel, and the pointer is a
// flapper hung above the rim whose tip reaches in between the gold pegs: each
// peg knocks it aside as it passes and it springs back, wobbling (useFlapper).
// The wheel rests with a slice's middle under it.

const S = 366; // the wheel's box, scaled down to fit short screens
const DISC = 318; // the turning disc
const R = DISC / 2;
const SEAT = R + 4; // the ink ring the disc sits in
const LIGHTS_R = 173; // the rim's lights, half way across the gold
const LABEL_R = 100; // a prize's middle, from the wheel's
const HUB = 98;
const SPIN_MS = 4500;
const SPIN_EASE = Easing.bezier(0.12, 0.72, 0.06, 1);
const LAPS = 5;
const BROWN = '#6b4426'; // the wood look's ink
const REST = 360 - SLICE / 2; // the wheel's turn before the first spin: slice 0's middle under the pointer
// the flapper (wheel box units): its pivot above the rim, the tip FLAP_L below it (in past the pegs' circle)
const PEG_R = R - 10; // the gold pegs' circle (Disc)
const PIV_Y = -16;
const FLAP_L = 60;
const PEG_GAP = 7; // a peg's radius + half the tip's width
const CAP = 32; // the room above the wheel for the flapper's cap (pivot PIV_Y, radius 13, its outline)
const D2R = Math.PI / 180;

// a slice's colours, from the middle out (src/royal/theme.js: the cream
// labels, the wood plaques, the gold plaque, the amethyst one)
const TONES = {
  cream: [[0, '#fffaf0'], [0.55, '#fbe7c4'], [1, '#f0c88c']],
  wood: [[0, '#eebf86'], [0.55, '#d59a5c'], [1, '#b47a42']],
  gold: [[0, '#fff1b0'], [0.5, '#ffd650'], [1, '#f6a524']],
  jewel: [[0, '#e6c8ff'], [0.5, '#a565ff'], [1, '#6420c8']],
};

const polar = (deg, r) => {
  const a = ((deg - 90) * Math.PI) / 180;
  return [R + r * Math.cos(a), R + r * Math.sin(a)];
};
const wedge = (i) => {
  const [x0, y0] = polar(i * SLICE, R);
  const [x1, y1] = polar((i + 1) * SLICE, R);
  return `M${R} ${R} L${x0} ${y0} A${R} ${R} 0 0 1 ${x1} ${y1} Z`;
};

// ---- rim lights -----------------------------------------------------------

function Bulb({ angle, delay }) {
  // one native loop (src/components/idleLoop.js): a loop around a sequence went back to JS at every step, every
  // bulb twice a second, and stuttered while the spin's answer was being handled (PERF 2026-11-20)
  const t = usePingPong(900, { delay });
  // bulbBlink: the glow fades out and back
  const opacity = t.interpolate({ inputRange: [0, 1], outputRange: [1, 0.15] });
  return (
    <View style={[styles.bulbSpot, { transform: [{ rotate: `${angle}deg` }, { translateY: -LIGHTS_R }] }]} pointerEvents="none">
      {/* the stud (always there), its light over it (blinking) */}
      <Svg width={29} height={29} style={StyleSheet.absoluteFill}>
        <Defs>
          <RadialGradient id="dsStud" cx="38%" cy="32%" r="70%">
            <Stop offset="0" stopColor="#fff3c4" />
            <Stop offset="0.55" stopColor="#e2b14a" />
            <Stop offset="1" stopColor="#8a5d1a" />
          </RadialGradient>
        </Defs>
        <Circle cx={14.5} cy={14.5} r={6} fill="url(#dsStud)" stroke={BROWN} strokeWidth={1.4} />
      </Svg>
      <Animated.View style={[StyleSheet.absoluteFill, { opacity }]}>
        <Svg width={29} height={29}>
          <Defs>
            <RadialGradient id="dsGlow" cx="50%" cy="50%" r="50%">
              <Stop offset="0.35" stopColor="#fff6c8" stopOpacity={0.95} />
              <Stop offset="1" stopColor="#fff0aa" stopOpacity={0} />
            </RadialGradient>
          </Defs>
          <Circle cx={14.5} cy={14.5} r={14.5} fill="url(#dsGlow)" />
          <Circle cx={14.5} cy={14.5} r={4.6} fill="#ffffff" />
        </Svg>
      </Animated.View>
    </View>
  );
}

// ---- the wheel -----------------------------------------------------------

// The disc: the slices, ink lines between them with gold pegs at the rim,
// and each prize fixed in its slice, standing out from the middle — it turns
// with the wheel.
const Disc = memo(function Disc({ rot, group }) {
  const spin = useMemo(() => rot.interpolate({ inputRange: [0, 360], outputRange: ['0deg', '360deg'] }), [rot]);
  return (
    <Animated.View style={[styles.disc, { transform: [{ rotate: spin }] }]}>
      <Svg width={DISC} height={DISC} style={StyleSheet.absoluteFill}>
        <Defs>
          {Object.entries(TONES).map(([k, stops]) => (
            <RadialGradient key={k} id={`dsT${k}`} cx={R} cy={R} r={R} fx={R} fy={R} gradientUnits="userSpaceOnUse">
              {stops.map(([o, c], j) => (
                <Stop key={j} offset={o} stopColor={c} />
              ))}
            </RadialGradient>
          ))}
          <RadialGradient id="dsPeg" cx="38%" cy="32%" r="70%">
            <Stop offset="0" stopColor="#fffbe2" />
            <Stop offset="0.5" stopColor="#ffd34e" />
            <Stop offset="1" stopColor="#b8680c" />
          </RadialGradient>
        </Defs>
        {WHEEL.map((w, i) => (
          <Path key={i} d={wedge(i)} fill={`url(#dsT${w.tone})`} />
        ))}
        {WHEEL.map((_, i) => {
          const [x, y] = polar(i * SLICE, R);
          return <Line key={i} x1={R} y1={R} x2={x} y2={y} stroke={BROWN} strokeWidth={3} strokeLinecap="round" />;
        })}
        {/* a soft dark edge round the disc, then its ink line */}
        <Circle cx={R} cy={R} r={R - 7} fill="none" stroke={BROWN} strokeOpacity={0.12} strokeWidth={10} />
        <Circle cx={R} cy={R} r={R - 1.5} fill="none" stroke={BROWN} strokeWidth={3} />
        {WHEEL.map((_, i) => {
          const [x, y] = polar(i * SLICE, R - 10);
          return <Circle key={i} cx={x} cy={y} r={4.6} fill="url(#dsPeg)" stroke={BROWN} strokeWidth={1.5} />;
        })}
      </Svg>
      {WHEEL.map((w, i) => {
        const angle = i * SLICE + SLICE / 2;
        return (
          <View key={i} pointerEvents="none" style={[styles.label, { transform: [{ rotate: `${angle}deg` }, { translateY: -LABEL_R }] }]}>
            {w.kind === 'chest' ? (
              <PrizeArt r={{ k: 'chest', t: w.size }} group={group} size={46} />
            ) : (
              <>
                <PrizeArt r={{ k: w.kind }} i={0} size={w.kind === 'gems' ? 36 : 34} />
                <InkText size={22} style={styles.labelText}>
                  {String(w.amount)}
                </InkText>
              </>
            )}
          </View>
        );
      })}
    </Animated.View>
  );
});

// the gold SPIN button in the middle (the menu's gold plaque, round)
function Hub({ label, onPress, live }) {
  const B = HUB + 8;
  return (
    <Pressable onPress={onPress} style={({ pressed }) => [styles.hubSpot, pressed && live && { transform: [{ scale: 0.94 }] }]} hitSlop={6}>
      <Svg width={B} height={B + 5} style={StyleSheet.absoluteFill}>
        <Defs>
          <LinearGradient id="dsHubRim" x1="0" y1="0" x2="0" y2="1">
            {RIM.map(([o, c], i) => (
              <Stop key={i} offset={o} stopColor={c} />
            ))}
          </LinearGradient>
          <RadialGradient id="dsHub" cx="38%" cy="30%" r="75%">
            <Stop offset="0" stopColor="#fff7c8" />
            <Stop offset="0.45" stopColor="#ffd34e" />
            <Stop offset="1" stopColor="#f09a1c" />
          </RadialGradient>
        </Defs>
        <Circle cx={B / 2} cy={B / 2 + 5} r={B / 2} fill={BROWN} />
        <Circle cx={B / 2} cy={B / 2} r={B / 2} fill={BROWN} />
        <Circle cx={B / 2} cy={B / 2} r={B / 2 - 2.5} fill="url(#dsHubRim)" />
        <Circle cx={B / 2} cy={B / 2} r={B / 2 - 8} fill="url(#dsHub)" stroke={BROWN} strokeOpacity={0.55} strokeWidth={1.5} />
        <Ellipse cx={B / 2} cy={B / 2 - 21} rx={27} ry={11} fill="#ffffff" fillOpacity={0.45} />
      </Svg>
      <View style={[styles.hubFace, !live && { opacity: 0.75 }]} pointerEvents="none">
        <Lettering text={label} variant="whiteB" size={25} />
      </View>
    </Pressable>
  );
}

// ---- the pointer: a flapper the pegs knock aside ----------------------------

// One step of the flapper (angle a in degrees, + = its tip to the left; w its
// speed) with the disc turned theta: a damped spring pulls it straight down
// (~11 Hz, a few wobbles), the hinge stops it at ±48°, and the peg nearest the
// top, while it's within the tip's reach, keeps to its side of the flapper,
// pushing it along until it slips out under the tip.
function stepFlap(F, theta, dt) {
  F.w += (-4800 * F.a - 26 * F.w) * dt;
  F.a += F.w * dt;
  if (F.a > 48) { F.a = 48; F.w *= -0.3; } else if (F.a < -48) { F.a = -48; F.w *= -0.3; }
  const n = Math.round(theta / SLICE);
  const d = (theta - n * SLICE) * D2R;
  const px = PEG_R * Math.sin(d); // the peg from the pivot (+ x = right)
  const py = S / 2 - PEG_R * Math.cos(d) - PIV_Y;
  const rho = Math.hypot(px, py);
  if (rho > FLAP_L + 2) { F.n = null; F.lim = null; return; }
  const beta = Math.atan2(-px, py) / D2R;
  const delta = Math.asin(Math.min(1, PEG_GAP / rho)) / D2R;
  // the side it came in on: left of the flapper (1) or right (-1)
  if (F.n !== n) { F.n = n; F.side = beta > F.a ? 1 : -1; F.lim = null; }
  const lim = beta - F.side * delta;
  if (F.side * (F.a - lim) > 0) {
    const push = F.lim == null ? 0 : (lim - F.lim) / dt;
    F.a = lim;
    if (F.side * (F.w - push) > 0) F.w = push;
  }
  F.lim = lim;
}

// The flapper's angle, from the wheel's (a listener on rot, which turns on the
// native driver; the physics runs only while something moves)
function useFlapper(rot) {
  const flap = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const F = { a: 0, w: 0, n: null, side: 1, lim: null };
    let th = REST;
    let sim = REST;
    let raf = 0;
    let last = 0;
    let still = 0;
    let shown = 0;
    const frame = (now) => {
      raf = 0;
      const dt = Math.min(0.05, last ? (now - last) / 1000 : 1 / 60);
      last = now;
      const t0 = sim;
      const t1 = th;
      // small steps: at most ~0.75° of the wheel and 1/240 s each (a fast whirl passes several pegs a frame)
      const steps = Math.max(1, Math.min(160, Math.ceil(Math.max(Math.abs(t1 - t0) / 0.75, dt * 240))));
      for (let i = 1; i <= steps; i++) stepFlap(F, t0 + ((t1 - t0) * i) / steps, dt / steps);
      sim = t1;
      if (Math.abs(F.a - shown) > 0.05) {
        shown = F.a;
        flap.setValue(F.a);
      }
      const moving = t1 !== t0 || Math.abs(F.a) > 0.05 || Math.abs(F.w) > 1;
      still = moving ? 0 : still + 1;
      if (still < 3) raf = requestAnimationFrame(frame);
      else {
        last = 0;
        F.a = 0;
        F.w = 0;
        if (shown !== 0) {
          shown = 0;
          flap.setValue(0);
        }
      }
    };
    const id = rot.addListener(({ value }) => {
      th = value;
      if (!raf) raf = requestAnimationFrame(frame);
    });
    return () => {
      rot.removeListener(id);
      if (raf) cancelAnimationFrame(raf);
    };
  }, [rot, flap]);
  return flap;
}

// the flapper: a gold tongue hung from a round cap with a screw, its tip
// pointing down into the wheel; its box is centred on the pivot so it turns
// about it
const FW = 44;
const FH = 2 * (FLAP_L + 16);
const FP = FH / 2; // the pivot's y in its box
const tongue = (dy = 0) => `M${FW / 2 - 12} ${FP + dy} L${FW / 2 - 3.2} ${FP + FLAP_L - 4 + dy} Q${FW / 2} ${FP + FLAP_L + 2 + dy} ${FW / 2 + 3.2} ${FP + FLAP_L - 4 + dy} L${FW / 2 + 12} ${FP + dy} Z`;
const TONGUE = tongue();
const TONGUE_LIP = tongue(3);
const Pointer = memo(function Pointer({ flap }) {
  const turn = useMemo(() => flap.interpolate({ inputRange: [-90, 90], outputRange: ['-90deg', '90deg'] }), [flap]);
  return (
    <Animated.View style={[styles.flap, { transform: [{ rotate: turn }] }]} pointerEvents="none">
      <Svg width={FW} height={FH}>
        <Defs>
          <LinearGradient id="dsPin" x1="0" y1="0" x2="1" y2="0">
            <Stop offset="0" stopColor="#fff1b0" />
            <Stop offset="0.45" stopColor="#ffd650" />
            <Stop offset="1" stopColor="#f08c10" />
          </LinearGradient>
          <RadialGradient id="dsCap" cx="38%" cy="32%" r="70%">
            <Stop offset="0" stopColor="#fff7c8" />
            <Stop offset="0.5" stopColor="#ffd34e" />
            <Stop offset="1" stopColor="#e08a12" />
          </RadialGradient>
        </Defs>
        <Path d={TONGUE_LIP} fill={BROWN} />
        <Path d={TONGUE} fill="url(#dsPin)" stroke={BROWN} strokeWidth={3} strokeLinejoin="round" />
        <Line x1={FW / 2 - 6.5} y1={FP + 14} x2={FW / 2 - 2} y2={FP + FLAP_L - 12} stroke="#ffffff" strokeOpacity={0.7} strokeWidth={2.2} strokeLinecap="round" />
        <Circle cx={FW / 2} cy={FP + 3} r={13} fill={BROWN} />
        <Circle cx={FW / 2} cy={FP} r={13} fill="url(#dsCap)" stroke={BROWN} strokeWidth={3} />
        <Circle cx={FW / 2} cy={FP} r={5} fill="#fff6e2" stroke={BROWN} strokeWidth={2} />
        <Line x1={FW / 2 - 3} y1={FP} x2={FW / 2 + 3} y2={FP} stroke={BROWN} strokeWidth={1.6} strokeLinecap="round" />
        <Ellipse cx={FW / 2 - 5} cy={FP - 6} rx={4} ry={2.4} fill="#ffffff" fillOpacity={0.8} />
      </Svg>
    </Animated.View>
  );
});

// the rim's lights, turning with the wheel (the gold ring under them looks the
// same at any turn, so they show it turning)
const Lights = memo(function Lights({ rot }) {
  const bulbs = useMemo(() => Array.from({ length: 16 }, (_, i) => ({ id: i, angle: i * 22.5 + 11.25, delay: i % 2 ? 450 : 0 })), []);
  const spin = useMemo(() => rot.interpolate({ inputRange: [0, 360], outputRange: ['0deg', '360deg'] }), [rot]);
  return (
    <Animated.View style={[StyleSheet.absoluteFill, { transform: [{ rotate: spin }] }]} pointerEvents="none">
      {bulbs.map((b) => (
        <Bulb key={b.id} angle={b.angle} delay={b.delay} />
      ))}
    </Animated.View>
  );
});

const Wheel = memo(function Wheel({ rot, hubLabel, hubLive, onHub, group }) {
  const flap = useFlapper(rot);
  return (
    <View style={styles.wheel}>
      {/* the warm glow round the rim */}
      <Svg width={S + 100} height={S + 100} style={styles.rimGlow} pointerEvents="none">
        <Defs>
          <RadialGradient id="dsRimGlow" cx="50%" cy="50%" r="50%">
            <Stop offset={S / (S + 100)} stopColor="#ffd250" stopOpacity={0.55} />
            <Stop offset="1" stopColor="#ffd250" stopOpacity={0} />
          </RadialGradient>
        </Defs>
        <Circle cx={(S + 100) / 2} cy={(S + 100) / 2} r={(S + 100) / 2} fill="url(#dsRimGlow)" />
      </Svg>
      {/* the frame: an ink lip and outline, the menu's gold rim (--rimG), and the ink seat the disc turns in */}
      <Svg width={S + 6} height={S + 12} style={styles.frame} pointerEvents="none">
        <Defs>
          <LinearGradient id="dsRim" x1="0" y1="0" x2="0" y2="1">
            {RIM.map(([o, c], i) => (
              <Stop key={i} offset={o} stopColor={c} />
            ))}
          </LinearGradient>
        </Defs>
        <Circle cx={S / 2 + 3} cy={S / 2 + 9} r={S / 2 + 3} fill={BROWN} />
        <Circle cx={S / 2 + 3} cy={S / 2 + 3} r={S / 2 + 3} fill={BROWN} />
        <Circle cx={S / 2 + 3} cy={S / 2 + 3} r={S / 2} fill="url(#dsRim)" />
        <Circle cx={S / 2 + 3} cy={S / 2 + 3} r={S / 2 - 2.5} fill="none" stroke="#ffffff" strokeOpacity={0.55} strokeWidth={2} />
        <Circle cx={S / 2 + 3} cy={S / 2 + 3} r={SEAT} fill={BROWN} />
      </Svg>
      <Lights rot={rot} />
      <Disc rot={rot} group={group} />
      <Pointer flap={flap} />
      <Hub label={hubLabel} live={hubLive} onPress={onHub} />
    </View>
  );
});

// ---- screen ----------------------------------------------------------------

export default function DailySpinScreen({ onSpin, onDone, bonusLeft = 0, adsFree = false, name, creatures, profile, hidden = HIDDEN }) {
  const { height: H } = useWindowDimensions();
  // 'idle' | 'spinning' | 'prize' (the popup) | 'done' | 'adReady' | 'error'
  const [phase, setPhase] = useState('idle');
  const [result, setResult] = useState(null);
  // video spins taken on this screen (the profile's count may lag behind)
  const [usedHere, setUsedHere] = useState(0);
  const [adNote, setAdNote] = useState(null);
  const busyRef = useRef(false);
  const ad = useRewardedAd();
  const spinsLeft = Math.max(0, Math.min(bonusLeft, MAX_AD_SPINS - usedHere));
  const rot = useRef(new Animated.Value(REST)).current;
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

  // the Mystery Box slice shows today's chest: the first HOT group's, which the server gives
  const group = useMemo(() => lineup(todayKey(), hidden)[0], [hidden]);
  const catalog = useMemo(() => Object.fromEntries((creatures || []).map((c) => [c.id, c])), [creatures]);
  const buddy = useMemo(() => buddyUriOf(creatures, profile), [creatures, profile]);

  // REDESIGN_V7 step 4: the wheel on the left, sized by the height (CAP: the room the pointer's cap needs above it); the
  // rest beside it
  const k = Math.min(1, (H - 40) / (S + 14 + CAP));

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

  // The Mystery Box: Open smashes the chest the server opened (`result.chest`), under the treasure vault loading
  // screen until the smash's page has painted (`up`), as the level road's chests
  const [smash, setSmash] = useState(null); // { chest: { key, result }, up }
  const [vaultGone, setVaultGone] = useState(false);
  const collect = useCallback(() => {
    if (result && result.kind === 'chest' && result.chest) {
      setVaultGone(false);
      setSmash({ chest: { key: Date.now(), result: result.chest }, up: false });
    }
    setPhase('done');
  }, [result]);
  const smashShown = useCallback(() => setSmash((s) => s && { ...s, up: true }), []);
  const smashDone = useCallback(() => setSmash(null), []);
  const vaultDone = useCallback(() => setVaultGone(true), []);

  const card = phase === 'prize' ? prizeCard(result) : null;
  const popScale = pop.interpolate({ inputRange: [0, 0.6, 1], outputRange: [0.7, 1.06, 1] });
  const hubLive = phase === 'idle' || phase === 'adReady';

  const wheel = (
    <View style={{ width: (S + 6) * k, height: (S + 14 + CAP) * k, alignItems: 'center' }}>
      <View style={{ width: S, height: S, marginTop: (S * k - S) / 2 + (3 + CAP) * k, transform: [{ scale: k }] }}>
        <Wheel rot={rot} hubLabel={phase === 'spinning' ? '…' : 'SPIN'} hubLive={hubLive} onHub={onHub} group={group} />
      </View>
    </View>
  );
  // the new look's page behind it
  return (
    <View style={styles.wRoot}>
      <PageBg />
      <View style={styles.wRow}>
        {wheel}
        <View style={styles.wSide}>
          <Text style={styles.hi}>{`HI ${(name || 'friend').toUpperCase()}!`}</Text>
          <Lettering text="Daily Spin" variant="gold" size={38} />
          <Text style={styles.sub}>One free spin every day</Text>
          {phase === 'idle' ? <Text style={[styles.sub, { marginTop: 14 }]}>Tap SPIN in the middle of the wheel!</Text> : null}
          <View style={{ height: 16 }} />

          {phase === 'done' ? (
            <View style={styles.after}>
              {spinsLeft > 0 ? (
                <SdButton kind="gold" onPress={watchAd} faceStyle={styles.adFace}>
                  <View style={styles.play}>
                    <View style={styles.playTri} />
                  </View>
                  <View>
                    <BtnLabel kind="gold" size={18}>
                      {adsFree ? 'Spin again' : 'Watch ad, spin again'}
                    </BtnLabel>
                    <Text style={styles.adSub}>ONE BONUS SPIN PER DAY</Text>
                  </View>
                </SdButton>
              ) : (
                <Text style={styles.note}>That’s all the spins for today. Come back tomorrow!</Text>
              )}
              {adNote ? <Text style={styles.note}>{adNote}</Text> : null}
              <SdButton kind="white" onPress={onDone} faceStyle={styles.goFace}>
                <BtnLabel kind="white" size={17}>
                  Continue to my squad
                </BtnLabel>
              </SdButton>
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
              <SdButton kind="white" onPress={onDone} faceStyle={styles.goFace}>
                <BtnLabel kind="white" size={17}>
                  Continue to my squad
                </BtnLabel>
              </SdButton>
            </View>
          ) : null}
        </View>
      </View>

      {card ? (
        <View style={styles.scrim}>
          <Animated.View style={[styles.cardLip, { opacity: pop, transform: [{ scale: popScale }] }]}>
            <View style={styles.card}>
              <Svg width="100%" height="100%" style={StyleSheet.absoluteFill}>
                <Defs>
                  <RadialGradient id="prizeCard" cx="50%" cy="30%" r="80%">
                    <Stop offset="0" stopColor="#ffffff" />
                    <Stop offset="0.6" stopColor="#fff6e8" />
                    <Stop offset="1" stopColor="#f6e2c4" />
                  </RadialGradient>
                </Defs>
                <Circle cx="50%" cy="30%" r="200%" fill="url(#prizeCard)" />
              </Svg>
              <ShadowText
                style={styles.cardTitle}
                shadows={[
                  [0, 3, BROWN],
                  [2, 0, BROWN],
                  [-2, 0, BROWN],
                  [0, -2, BROWN],
                ]}
              >
                {card.title}
              </ShadowText>
              {/* the prize and how much, on one row (the user, 2026-11-17) */}
              <View style={styles.prizeRow}>
                <PrizeArt r={{ k: result.kind, t: result.size || 'common' }} group={(result.chest && result.chest.group) || group} i={0} size={result.kind === 'chest' ? 60 : 62} />
                <View style={styles.prizeCol}>
                  <Text style={styles.cardAmt}>{card.amount}</Text>
                  <Text style={styles.cardWhat}>{card.what}</Text>
                </View>
              </View>
              <SdButton kind="gold" onPress={collect} style={styles.collect} faceStyle={styles.collectFace}>
                <BtnLabel kind="gold" size={20}>
                  {result.kind === 'chest' && result.chest ? 'Open' : 'Collect'}
                </BtnLabel>
              </SdButton>
            </View>
          </Animated.View>
        </View>
      ) : null}

      {smash ? (
        <View style={StyleSheet.absoluteFill}>
          <ChestSmash chest={smash.chest} catalog={catalog} onCollect={smashDone} onShown={smashShown} />
        </View>
      ) : null}
      {smash && !vaultGone ? <VaultLoader ready={!!smash.up} uri={buddy} onDone={vaultDone} /> : null}
    </View>
  );
}

const styles = StyleSheet.create({
  wRoot: { flex: 1, backgroundColor: '#24123f' },
  wRow: { flex: 1, flexDirection: 'row', alignItems: 'center', justifyContent: 'center', gap: 40, paddingHorizontal: 24 },
  wSide: { width: 360, alignItems: 'center', gap: 6 },
  hi: { fontFamily: F.black, fontSize: 12, letterSpacing: 2, color: BROWN },
  sub: { fontFamily: F.heavy, fontSize: 13, color: BROWN },
  wheel: { width: S, height: S },
  rimGlow: { position: 'absolute', left: -50, top: -50 },
  frame: { position: 'absolute', left: -3, top: -3 },
  bulbSpot: { position: 'absolute', left: S / 2 - 14.5, top: S / 2 - 14.5, width: 29, height: 29 },
  disc: { position: 'absolute', left: (S - DISC) / 2, top: (S - DISC) / 2, width: DISC, height: DISC },
  label: { position: 'absolute', left: R - 42, top: R - 38, width: 84, height: 76, alignItems: 'center', justifyContent: 'center', gap: 1 },
  labelText: { lineHeight: 25 },
  flap: { position: 'absolute', left: S / 2 - FW / 2, top: PIV_Y - FP, width: FW, height: FH },
  hubSpot: { position: 'absolute', left: S / 2 - (HUB + 8) / 2, top: S / 2 - (HUB + 8) / 2, width: HUB + 8, height: HUB + 13 },
  hubFace: { position: 'absolute', left: 0, top: 0, width: HUB + 8, height: HUB + 8, alignItems: 'center', justifyContent: 'center' },
  after: { alignItems: 'center', gap: 9, marginTop: 2 },
  adFace: { paddingVertical: 7, paddingHorizontal: 16 },
  goFace: { paddingVertical: 7, paddingHorizontal: 26 },
  play: { width: 30, height: 30, borderRadius: 15, backgroundColor: '#ffffff', alignItems: 'center', justifyContent: 'center', marginRight: 2 },
  playTri: { width: 0, height: 0, marginLeft: 3, borderTopWidth: 7, borderBottomWidth: 7, borderLeftWidth: 11, borderTopColor: 'transparent', borderBottomColor: 'transparent', borderLeftColor: '#c66f0a' },
  adSub: { fontFamily: F.black, fontSize: 10.5, letterSpacing: 0.6, color: '#8a4a06' },
  note: { fontFamily: F.heavy, fontSize: 13, color: BROWN, textAlign: 'center', maxWidth: 320 },
  unlocked: { fontFamily: F.display, fontSize: 17, color: '#9c4d06', marginTop: 4 },
  scrim: { ...StyleSheet.absoluteFillObject, backgroundColor: 'rgba(50,24,6,0.55)', alignItems: 'center', justifyContent: 'center', padding: 24 },
  cardLip: { width: '100%', maxWidth: 300, borderRadius: 30, backgroundColor: '#b8641c', paddingBottom: 6 },
  card: { borderRadius: 30, borderWidth: 3, borderColor: '#ffffff', overflow: 'hidden', paddingTop: 20, paddingHorizontal: 20, paddingBottom: 18, alignItems: 'center', gap: 12 },
  cardTitle: { fontFamily: F.display, fontSize: 30, color: '#ffffff' },
  prizeRow: { flexDirection: 'row', alignItems: 'center', justifyContent: 'center', gap: 12, alignSelf: 'stretch', paddingVertical: 8, paddingHorizontal: 14, borderRadius: 20, backgroundColor: 'rgba(184,100,28,0.10)' },
  prizeCol: { alignItems: 'flex-start' },
  cardAmt: { fontFamily: F.display, fontSize: 34, lineHeight: 38, color: '#8a3a0e' },
  cardWhat: { fontFamily: F.black, fontSize: 13, letterSpacing: 1.5, color: '#9a6a3a' },
  collect: { alignSelf: 'stretch', marginTop: 2 },
  collectFace: { paddingVertical: 8 },
});
