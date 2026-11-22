import React, { forwardRef, memo, useCallback, useEffect, useImperativeHandle, useMemo, useRef, useState } from 'react';
import { View, Text, StyleSheet, PanResponder, Animated, Easing, Dimensions, Image } from 'react-native';
import Pressable from '../components/Pressable';
import { LinearGradient } from 'expo-linear-gradient';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { Canvas } from '@react-three/fiber';
import { NeutralToneMapping } from 'three';
import Svg, { Defs, Ellipse, Path, RadialGradient, Rect, Stop } from 'react-native-svg';
import { InterstitialAd, AdEventType } from 'react-native-google-mobile-ads';
import SquishyToy from '../components/SquishyToy';
import SquishyToy2D from '../components/SquishyToy2D';
import Supersample from '../components/Supersample';
import { stepKeys, useKeyLoop } from '../components/idleLoop';
import { useAfterFirstFrame } from '../components/Skeleton';
import { INTERSTITIAL_AD_UNIT_ID } from '../firebase/ads';

// A creature with a `card` (every roster creature since REDESIGN_V6 step 4:
// the design's card, src/components/squishCard.js) or a `modelUrl` (a Tripo
// model: a roster creature given one, which then plays it instead of its
// card, or a photo-path custom one) mounts the 3D stage; everything else
// falls back to 2D art (SquishyToy2D).
import SquishSound from '../audio/SquishSound';
import squishSoundFor from '../audio/creatureSquish';
import { pressHaptic, moveHaptic, releaseHaptic } from '../haptics/squishHaptics';
import CoinSound from '../audio/CoinSound';
import PopSound from '../audio/PopSound';
import { candyColors, candyFonts, BUTTON_VARIANTS } from '../theme/candyTheme';
import WatchAdButton from '../components/WatchAdButton';
import { AD_FREE_BOOST_RECHARGE_MS } from '../economy';
import CandyButton from '../components/candy/CandyButton';
import RoundButton, { CloseGlyph } from '../components/candy/RoundButton';
import { CoinIcon, GlassPill } from '../components/candy/Coin';
import OutlinedTitle from '../components/candy/OutlinedTitle';
import ToggleSwitch from '../components/candy/ToggleSwitch';
import Room from '../hop/Room';
import { CUSH } from '../hop/Pieces';
import { CARD_FLOOR } from '../components/squishCard';
import { ICON, Icon, InkText, Orb, Plaque } from '../royal';
import { COIN } from '../squad/currencyArt';
import sfx from '../audio/sfx';
import { fmtNum } from '../format';

// The 2026-11-21 remodel (the user: a cozy room, a slim rail of boosts, the
// gear in the top-right corner, a bigger creature): the creature stands on a
// cushion in the Crib's living room, the stage is the screen's whole height
// (half again as wide, centred), the back button and the coins earned sit
// top left, the gear top right, and the ×2/×3/×4 boosts are round buttons
// down the right edge.
const WINDOW = Dimensions.get('window');
const SCREEN_W = Math.max(WINDOW.width, WINDOW.height);
const SCREEN_H = Math.min(WINDOW.width, WINDOW.height);
const STAGE_H = Math.round(SCREEN_H);
const STAGE_W = Math.min(Math.round(SCREEN_W), Math.round(STAGE_H * 1.5));
const STAGE_LEFT = Math.round((SCREEN_W - STAGE_W) / 2);
// the 2D art's square (a creature without a card or model), in the stage's middle
const STAGE_SIZE = STAGE_H;
// The 3D stage's camera: 30° tall, looking straight ahead, lowered from 0.1
// (before the remodel, when creatures stood at the stage's bottom) so the
// card's floor (CARD_FLOOR) is 81% of the way down: the cushion's top.
const CAM_Y = -0.39;
const CAM_Z = 4.6;
const FEET_Y = Math.round((STAGE_H * (1 - (CARD_FLOOR - CAM_Y) / (CAM_Z * Math.tan(Math.PI / 12)))) / 2);
// the cushion under the creature (a Squish Hop cushion, seen from the front)
const CUSHION_W = Math.round(STAGE_H * 0.78);
const CUSHION_COLOR = 'mint';
const RIPPLE_LIFETIME_MS = 620;
// 60s window where an ad-watch doubles squish rewards.
const BONUS_MS = 60000;
const SPEED_TAP_WINDOW_MS = 60000;
const SPEED_TAP_THRESHOLD = 60;

// The squish sound plays while the finger moves and fades out when it rests
// (see SquishSound). A move counts once the finger is this far (dp) from
// where it last counted, so touch jitter on a resting finger stays silent.
const SOUND_MOTION_DP = 3;

// Bank 5 coins for every 1.5 s the finger spends MOVING on the toy (was 1
// coin per 1.5 s of holding until 2026-09-29). Coins follow the squish
// sound's rule: a finger that holds still earns nothing, just as the sound
// fades. Moving time is the gaps between counted movements (see
// SOUND_MOTION_DP), each capped at MOTION_GAP_MS — a longer gap means the
// finger rested (SquishSound's IDLE_PAUSE_MS). Two fingers (rotate) earn
// nothing. A ×N boost multiplies this.
const EARN_TICK_MS = 1500;
const EARN_PER_TICK = 5;
const MOTION_GAP_MS = 180;
// Floating "+1" per tick: rises, spins, fades.
const FLOATING_COIN_MS = 1650;
const FLOATING_COIN_RISE = 72;
const FLOATING_COIN_SIZE = 30;

// Too many quick taps trips the punishment ad — must be a rapid-fire burst,
// not just several taps spread over a minute. Each rule is a rate limit
// (limit taps per windowMs); a burst trips the alarm the moment ANY rule's
// tap-rate crosses 100% of its allowance, so e.g. either 5 taps/1s or
// 7 taps/2s (whichever is hit first) counts as abuse.
const ABUSE_RULES = [
  { windowMs: 1000, limit: 5 },
  { windowMs: 2000, limit: 7 },
];
const ABUSE_MAX_WINDOW_MS = Math.max(...ABUSE_RULES.map((r) => r.windowMs));

const RIPPLE_MAX = 180;

// True for 3D-mesh creatures; picks Canvas vs SquishyToy2D in SquishStage.
const toyIs3D = (t) => !!(t && ((t.card && t.card.url) || t.modelUrl));

// Ring that blooms from the touch point and fades. Pooled: a few of these
// stay mounted (invisible when finished) and `play` just moves one to the
// touch point and restarts its animation, so a touch never mounts views.
const Ripple = memo(forwardRef(function Ripple(_props, ref) {
  const t = useRef(new Animated.Value(1)).current;
  const x = useRef(new Animated.Value(0)).current;
  const y = useRef(new Animated.Value(0)).current;
  useImperativeHandle(
    ref,
    () => ({
      play: (px, py) => {
        x.setValue(px - RIPPLE_MAX / 2);
        y.setValue(py - RIPPLE_MAX / 2);
        t.setValue(0);
        Animated.timing(t, { toValue: 1, duration: RIPPLE_LIFETIME_MS, easing: Easing.out(Easing.quad), useNativeDriver: true }).start();
      },
    }),
    [t, x, y]
  );
  const scale = t.interpolate({ inputRange: [0, 1], outputRange: [0.25, 1] });
  const opacity = t.interpolate({ inputRange: [0, 0.15, 1], outputRange: [0, 0.5, 0] });
  return (
    <Animated.View
      pointerEvents="none"
      style={[styles.ripple, { opacity, transform: [{ translateX: x }, { translateY: y }, { scale }] }]}
    />
  );
}));

// A spinning gold coin and a sticker "+N" that rise and fade — pops once per
// earn tick (the design's coinRise / coinSpin / coinFade). Pooled like the
// ripple; only a changed amount (a new ×N boost) re-renders the sticker.
const FloatingCoin = memo(forwardRef(function FloatingCoin(_props, ref) {
  const t = useRef(new Animated.Value(1)).current;
  const x = useRef(new Animated.Value(0)).current;
  const y = useRef(new Animated.Value(0)).current;
  const [amount, setAmount] = useState(1);
  useImperativeHandle(
    ref,
    () => ({
      play: (px, py, n) => {
        setAmount((cur) => (cur === n ? cur : n));
        x.setValue(px - 40);
        y.setValue(py - 60);
        t.setValue(0);
        Animated.timing(t, { toValue: 1, duration: FLOATING_COIN_MS, easing: Easing.bezier(0.25, 0.6, 0.35, 1), useNativeDriver: true }).start();
      },
    }),
    [t, x, y]
  );
  const translateY = t.interpolate({ inputRange: [0, 1], outputRange: [8, -FLOATING_COIN_RISE] });
  const opacity = t.interpolate({ inputRange: [0, 0.15, 0.75, 1], outputRange: [0, 1, 1, 0] });
  const spin = t.interpolate({ inputRange: [0, 1], outputRange: ['0deg', '360deg'] });
  return (
    <Animated.View
      pointerEvents="none"
      style={[styles.floatingCoin, { opacity, transform: [{ translateX: x }, { translateY: y }, { translateY }] }]}
    >
      <Animated.View style={{ transform: [{ perspective: 200 }, { rotateY: spin }] }}>
        <CoinIcon size={FLOATING_COIN_SIZE} glow />
      </Animated.View>
      <OutlinedTitle text={`+${amount}`} fill="gold" size={26} outline={2.5} letterSpacing={0} />
    </Animated.View>
  );
}));

const RIPPLE_POOL = 3;
const COIN_POOL = 3;

// Touch ripples + floating "+N" coins, driven through the ref. Both pools
// are mounted once, so spawning one is a couple of native-driver setValues —
// no React work on the very touch that starts a squish, and none on each
// earn tick mid-squish.
const StageEffects = memo(forwardRef(function StageEffects(_props, ref) {
  const ripples = useRef([]);
  const coins = useRef([]);
  const nextRipple = useRef(0);
  const nextCoin = useRef(0);
  useImperativeHandle(
    ref,
    () => ({
      spawnRipple: (x, y) => {
        const r = ripples.current[nextRipple.current++ % RIPPLE_POOL];
        r && r.play(x, y);
      },
      spawnFloatingCoin: (x, y, amount) => {
        const c = coins.current[nextCoin.current++ % COIN_POOL];
        c && c.play(x, y, amount);
      },
    }),
    []
  );
  return (
    <View style={StyleSheet.absoluteFillObject} pointerEvents="none">
      {Array.from({ length: RIPPLE_POOL }, (_, i) => (
        <Ripple key={`r${i}`} ref={(el) => { ripples.current[i] = el; }} />
      ))}
      {Array.from({ length: COIN_POOL }, (_, i) => (
        <FloatingCoin key={`c${i}`} ref={(el) => { coins.current[i] = el; }} />
      ))}
    </View>
  );
}));

// Top-bar "+N EARNED" pill: the coins earned since the screen opened, on the
// menu's wood pill (the 2026-11-21 remodel). Counts up through its ref on
// each earn tick, so the tick re-renders only this pill instead of the whole
// screen mid-squish.
const CoinCounter = memo(forwardRef(function CoinCounter(_props, ref) {
  const [value, setValue] = useState(0);
  useImperativeHandle(ref, () => ({ add: (n) => setValue((c) => c + n) }), []);
  return (
    <Plaque variant="vel" style={styles.coinPill}>
      <Image source={COIN[0]} style={styles.coinPillImg} />
      <InkText size={14}>+{fmtNum(value)}</InkText>
      <InkText size={9.5} style={styles.coinPillEarned}>
        EARNED
      </InkText>
    </Plaque>
  );
}));

// The cushion the creature stands on: a Squish Hop cushion (hop/Pieces.js
// CUSH colours and layers: the ring and its lip, white piping, the soft face,
// stitching) seen from the front, its top centred where the feet are, with a
// soft shadow on the floor. Drawn behind the stage's transparent 3D canvas.
const Cushion = memo(function Cushion() {
  const c = CUSH[CUSHION_COLOR];
  const W = CUSHION_W;
  const H = Math.round(W * 0.24);
  const lip = Math.round(W * 0.07);
  const k = W / 300;
  const boxH = H + lip + Math.round(H * 0.5);
  const rect = (x, y, w, h, rx, ry, props) => <Rect x={x} y={y} width={w} height={h} rx={rx} ry={ry} {...props} />;
  return (
    <View pointerEvents="none" style={{ position: 'absolute', left: Math.round(SCREEN_W / 2 - W / 2) - 20, top: FEET_Y - H / 2, width: W + 40, height: boxH }}>
      <Svg width={W + 40} height={boxH}>
        <Defs>
          <RadialGradient id="cushFace" cx="50%" cy="40%" rx="70%" ry="70%">
            <Stop offset="0" stopColor={c.c1} />
            <Stop offset="1" stopColor={c.c2} />
          </RadialGradient>
          <RadialGradient id="cushShade" cx="50%" cy="50%" rx="50%" ry="50%">
            <Stop offset="0" stopColor="#5a280a" stopOpacity={0.35} />
            <Stop offset="1" stopColor="#5a280a" stopOpacity={0} />
          </RadialGradient>
        </Defs>
        <Ellipse cx={20 + W / 2} cy={H + lip * 0.9} rx={W * 0.58} ry={H * 0.42} fill="url(#cushShade)" />
        {rect(20, lip, W, H, W * 0.2, H * 0.45, { fill: c.ring })}
        {rect(20, 0, W, H, W * 0.2, H * 0.45, { fill: c.ring })}
        {rect(20 + 4 * k, 3 * k, W - 8 * k, H - 6 * k, W * 0.19, H * 0.43, { fill: '#ffffff' })}
        {rect(20 + 9 * k, 6 * k, W - 18 * k, H - 12 * k, W * 0.18, H * 0.4, { fill: 'url(#cushFace)' })}
        {rect(20 + 24 * k, 13 * k, W - 48 * k, H - 26 * k, W * 0.15, H * 0.33, {
          fill: 'none',
          stroke: 'rgba(255,255,255,0.75)',
          strokeWidth: 2.5 * k,
          strokeDasharray: `${7 * k} ${5 * k}`,
        })}
      </Svg>
    </View>
  );
});

// Live frames-per-second pill. Counts requestAnimationFrame callbacks — the
// same JS-thread frame loop the 3D stage renders on, so a slow squish frame
// shows up here — and redraws twice a second in its own leaf, so it never
// re-renders SquishScreen.
function FpsCounter() {
  const [fps, setFps] = useState(null);
  useEffect(() => {
    let frames = 0;
    let raf = 0;
    let last = performance.now();
    const loop = () => {
      frames += 1;
      raf = requestAnimationFrame(loop);
    };
    raf = requestAnimationFrame(loop);
    const id = setInterval(() => {
      const t = performance.now();
      setFps(Math.round((frames * 1000) / (t - last)));
      frames = 0;
      last = t;
    }, 500);
    return () => {
      cancelAnimationFrame(raf);
      clearInterval(id);
    };
  }, []);
  const color = fps == null ? '#ffffff' : fps >= 55 ? '#7dffb0' : fps >= 40 ? '#fff3a0' : '#ffb3b3';
  return (
    <GlassPill style={styles.fpsPill}>
      <Text style={[styles.fpsText, { color }]}>{fps == null ? '–' : fps} FPS</Text>
    </GlassPill>
  );
}

// Springs in small+tilted, overshoots, settles, holds, then fades out —
// onFadeOutDone fires right as it becomes invisible so the caller can
// unmount it without an abrupt cut.
function PopIn({ style, children, holdMs = 940, fadeOutMs = 400, onFadeOutDone }) {
  const t = useRef(new Animated.Value(0)).current;
  const fade = useRef(new Animated.Value(1)).current;
  useEffect(() => {
    Animated.timing(t, { toValue: 1, duration: 460, easing: Easing.out(Easing.quad), useNativeDriver: true }).start();
    const holdTimer = setTimeout(() => {
      Animated.timing(fade, { toValue: 0, duration: fadeOutMs, easing: Easing.in(Easing.quad), useNativeDriver: true }).start(({ finished }) => {
        if (finished) onFadeOutDone && onFadeOutDone();
      });
    }, 460 + holdMs);
    return () => clearTimeout(holdTimer);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);
  const popOpacity = t.interpolate({ inputRange: [0, 0.5, 1], outputRange: [0, 1, 1] });
  const scale = t.interpolate({ inputRange: [0, 0.6, 1], outputRange: [0.4, 1.12, 1] });
  const rotate = t.interpolate({ inputRange: [0, 0.6, 1], outputRange: ['-8deg', '3deg', '0deg'] });
  const opacity = Animated.multiply(popOpacity, fade);
  return <Animated.View style={[style, { opacity, transform: [{ scale }, { rotate }] }]}>{children}</Animated.View>;
}

// One-time gesture tutorial, overlaid on the stage itself (replaces the old
// permanent bottom-panel hint list) — a squish hand on the left, a
// two-finger rotate hand on the right, each with a pulsing touch ring,
// fading out the first time the player actually touches the toy (see
// gestureHintOpacity). A third hand under the gear points at the gameplay
// settings (SettingsHint). All three are drawn in the candy style: white
// hands with the header icons' dark outline and drop, pink-and-white touch
// rings, and the Mystery Box's glass hint pill for the caption.
const SQUISH_HAND_D =
  'M24 17A6 6 0 0 1 36 17L36 42C37 39 41 37.5 44 39C47.4 40.4 48.4 44 47.4 47C48.4 44 51.4 42.4 54.4 43.6C57.8 45 58.8 48.4 57.8 51.6C59.4 49.4 62.6 48.8 64.8 50.6C67.4 52.6 67.8 55.8 67 59L65.4 69C63.8 81.4 54.8 90.6 42.8 90.6L35.8 90.6C23.4 90.6 15.2 81.6 13.8 69.2L12.8 60.6L5.8 50.6C2.8 46.2 9.2 41.6 12.8 46.2L19.4 55.2C20.6 56.8 22.2 57.4 24 57.4Z';
const SQUISH_HAND_CREASE_D = 'M47.4 47c-2.6.6-5.4.2-7.6-1.2M57.8 51.6c-2.6.8-5.6.4-8-1';
const ROTATE_HAND_D =
  'M18 22A6 6 0 0 1 30 22L30 44L32 44L32 15A6 6 0 0 1 44 15L44 47C45.4 44 49 42.6 52 44.2C55.4 45.8 56.2 49.4 55 52.6C56.8 50.4 60 50 62.2 52C64.8 54.2 65 57.4 64 60.4L62.6 69.6C61 82 52 90.6 40 90.6L33 90.6C21 90.6 13 81.6 11.8 69.4L10.8 61L4 51C1 46.6 7.4 42 11 46.6L17 55.4C17.6 56.4 17.8 56.6 18 57Z';
const ROTATE_HAND_CREASE_D = 'M55 52.6c-2.6.8-5.6.4-8-1M31 44.4c-.2 4 .4 8 1.8 11.6';
// The hand paths live in a 72×96 box; the viewBox leaves room for the
// outline and its drop.
const HAND_VIEWBOX = '-5 -5 82 110';
const HAND_ASPECT = 110 / 82;
// fingertip of each hand, in path units — where its touch ring sits
const SQUISH_TIP = { x: 30, y: 11 };
const ROTATE_TIP = { x: 31, y: 12 };
const HINT_INK = '#6b4426'; // (the wood look's brown, REDESIGN_V8)

function CandyHand({ d, creaseD, width }) {
  return (
    <Svg width={width} height={width * HAND_ASPECT} viewBox={HAND_VIEWBOX}>
      <Path d={d} fill="rgba(107,63,160,0.16)" transform="translate(0,3)" />
      <Path d={d} fill="rgba(255,255,255,0.9)" stroke={HINT_INK} strokeWidth={2.8} strokeLinejoin="round" />
      <Path d={creaseD} stroke="rgba(107,63,160,0.6)" strokeWidth={2} strokeLinecap="round" fill="none" />
    </Svg>
  );
}

// Pink ring pulsing where the finger lands.
function TouchRing({ anim, style }) {
  return (
    <Animated.View
      style={[
        styles.touchRing,
        style,
        {
          opacity: anim.interpolate({ inputRange: [0, 0.5, 1], outputRange: [0.95, 0.35, 0.95] }),
          transform: [{ scale: anim.interpolate({ inputRange: [0, 1], outputRange: [1, 1.3] }) }],
        },
      ]}
    >
    </Animated.View>
  );
}

// v5's caption: dark purple caps with a white glow, no pill.
function HintPill({ label, sub, align = 'center' }) {
  return (
    <View style={{ alignItems: align === 'right' ? 'flex-end' : 'center' }}>
      <Text style={styles.hintPillText} numberOfLines={1}>
        {label}
      </Text>
      {sub ? (
        <Text style={styles.hintPillSub} numberOfLines={1}>
          {sub}
        </Text>
      ) : null}
    </View>
  );
}

const HAND_W = 52;

function GestureHint({ side, d, creaseD, tip, label, touchAnim, gestureAnim }) {
  const sideStyle = side === 'left' ? { left: '4%' } : { right: '4%' };
  const k = HAND_W / 82;
  const ring = { left: (tip.x + 5) * k - 13, top: (tip.y + 5) * k - 13 };
  return (
    <View style={[styles.gestureHint, sideStyle]} pointerEvents="none">
      <Animated.View style={[styles.gestureHandWrap, { transform: gestureAnim }]}>
        <CandyHand d={d} creaseD={creaseD} width={HAND_W} />
        <TouchRing anim={touchAnim} style={ring} />
      </Animated.View>
      <HintPill label={label} />
    </View>
  );
}

// The settings pointer: a hand under the gear, bobbing up at it, a pink halo
// pulsing round the gear, and a GAMEPLAY SETTINGS pill saying what's inside.
// It stays a little longer than the stage hints — until the gear is opened,
// or a few seconds after the first squish (see settingsHintOpacity).
const POINT_HAND_W = 44;
const GEAR_SIZE = 42;
const GEAR_RIGHT = 14;
// the top corners' buttons, from the top
const HUD_TOP = 12;

function SettingsHint({ top, opacity, bobAnim, pulseAnim }) {
  const k = POINT_HAND_W / 82;
  // put the fingertip right under the gear's centre
  const handRight = GEAR_RIGHT + GEAR_SIZE / 2 - (POINT_HAND_W - (SQUISH_TIP.x + 5) * k);
  const translateY = bobAnim.interpolate({ inputRange: [0, 1], outputRange: [0, -7] });
  return (
    <Animated.View pointerEvents="none" style={[StyleSheet.absoluteFill, styles.settingsHintLayer, { opacity }]}>
      <Animated.View
        style={[
          styles.gearHalo,
          {
            top: top - 5,
            right: GEAR_RIGHT - 5,
            opacity: pulseAnim.interpolate({ inputRange: [0, 1], outputRange: [0.95, 0.15] }),
            transform: [{ scale: pulseAnim.interpolate({ inputRange: [0, 1], outputRange: [1, 1.28] }) }],
          },
        ]}
      />
      <View style={[styles.gearHint, { top: top + GEAR_SIZE + 8 }]}>
        <Animated.View style={{ marginRight: handRight - 10, transform: [{ translateY }] }}>
          <CandyHand d={SQUISH_HAND_D} creaseD={SQUISH_HAND_CREASE_D} width={POINT_HAND_W} />
        </Animated.View>
        <HintPill label="GAMEPLAY SETTINGS" sub="Sound · vibration · poke" align="right" />
      </View>
    </Animated.View>
  );
}

// 0 → 1 → 0, `config.duration` each way, eased, forever: one native loop
// (idleLoop.js; a loop around the two timings went back to JS at every turn)
const LOOP_EASE = Easing.inOut(Easing.ease);
function useLoopAnim(config) {
  const keys = useMemo(
    () =>
      stepKeys(0, [
        [1, config.duration, LOOP_EASE],
        [0, config.duration, LOOP_EASE],
      ]),
    [config.duration]
  );
  return useKeyLoop(keys.ms, keys);
}

// The stage itself: touch surface, 3D Canvas (or the 2D rig), touch effects
// and the gesture tutorial. Every prop is stable for the screen's lifetime
// except the poke settings (which only change from the settings popup), so
// the memo keeps SquishScreen re-renders (the Firestore profile update
// after each release, the bonus window, the settings popup) from ever
// reconciling the Canvas subtree — see project perf notes on SquishScreen.
const SquishStage = memo(function SquishStage({
  toy,
  toyRef,
  effectsRef,
  panHandlers,
  onSquish,
  onRelease,
  hintOpacity,
  showHints,
  squishAnim,
  rotateAnim,
  touchAnim,
  dentScale,
  squishLevel,
  dentOutward,
}) {
  return (
    <View style={styles.stage} {...panHandlers}>
      {toyIs3D(toy) ? (
        <Canvas
          frameloop="always"
          camera={{ fov: 30, position: [0, CAM_Y, CAM_Z], near: 0.1, far: 100 }}
          // Khronos "PBR Neutral" tone mapping keeps each creature's texture
          // colours true to how Tripo shows them. R3F's default (ACES) washed
          // saturated colours (Bubbles' cyan, Tako's pink) out to pastels.
          gl={{ toneMapping: NeutralToneMapping, toneMappingExposure: 1 }}
        >
          {/* Tuned to match Tripo's viewer with plain lights only: the old
              RoomEnvironment reflection map renders black on the phone (see
              SquishyToy.js), so nothing here may depend on it. The strong
              sky/ground hemisphere is the soft all-round fill it used to give. */}
          <ambientLight intensity={0.6} />
          <hemisphereLight args={[0xffffff, 0x9aa8bc, 3.5]} />
          <directionalLight color={0xffffff} intensity={1.2} position={[2, 3, 3]} />
          <directionalLight color={0xd8ccff} intensity={0.3} position={[-2.5, -1, 2]} />
          <directionalLight color={0xffffff} intensity={0.35} position={[-1.5, 2, -3]} />
          {/* Anti-aliasing, which expo-gl doesn't provide on Android. */}
          <Supersample factor={2} />
          <SquishyToy
            ref={toyRef}
            creatureId={toy.id}
            modelUrl={toy.modelUrl}
            cardUrl={toy.card ? toy.card.url : null}
            stage={toy.stage ?? 1}
            visual={toy.visual}
            onSquish={onSquish}
            onRelease={onRelease}
            dentScale={dentScale}
            squishLevel={squishLevel}
            dentOutward={dentOutward}
          />
        </Canvas>
      ) : (
        // (pointerEvents none: touches land on the stage, whose coordinates ndcFromLocation reads)
        <View pointerEvents="none" style={styles.stage2D}>
          <SquishyToy2D
            ref={toyRef}
            creature={toy}
            imageUri={toy.isCustom ? toy.image : undefined}
            build={toy.isCustom ? toy.build : undefined}
            size={STAGE_SIZE}
            onSquish={onSquish}
            onRelease={onRelease}
          />
        </View>
      )}

      <StageEffects ref={effectsRef} />

      {/* Gone for good once faded: its three pulse loops would otherwise
          keep animating an invisible layer for the rest of the session. */}
      {showHints && (
      <Animated.View style={[StyleSheet.absoluteFillObject, { opacity: hintOpacity }]} pointerEvents="none">
        <GestureHint
          side="left"
          d={SQUISH_HAND_D}
          creaseD={SQUISH_HAND_CREASE_D}
          tip={SQUISH_TIP}
          label="HOLD TO SQUISH"
          touchAnim={touchAnim}
          gestureAnim={[{ translateY: squishAnim.interpolate({ inputRange: [0, 0.5, 1], outputRange: [0, 8, 0] }) }]}
        />
        <GestureHint
          side="right"
          d={ROTATE_HAND_D}
          creaseD={ROTATE_HAND_CREASE_D}
          tip={ROTATE_TIP}
          label="2 FINGERS TO ROTATE"
          touchAnim={touchAnim}
          gestureAnim={[{ rotate: rotateAnim.interpolate({ inputRange: [0, 0.5, 1], outputRange: ['0deg', '-14deg', '0deg'] }) }]}
        />
      </Animated.View>
      )}
    </View>
  );
});

// Row of buttons where exactly one is selected.
function Segmented({ options, value, onChange }) {
  return (
    <View style={styles.segmented}>
      {options.map((option) => {
        const active = option.value === value;
        return (
          <Pressable key={String(option.value)} onPress={() => onChange(option.value)} style={[styles.segment, active && styles.segmentActive]}>
            {active ? (
              <LinearGradient colors={BUTTON_VARIANTS.pink.colors} locations={BUTTON_VARIANTS.pink.locations} style={StyleSheet.absoluteFill} />
            ) : null}
            <Text style={[styles.segmentText, active && styles.segmentTextActive]}>{option.label}</Text>
          </Pressable>
        );
      })}
    </View>
  );
}

// Poke strength setting (1-5) -> multiplier on SquishyToy's tuned dent depth.
// 3 is the tuned default. (A Tripo model's pillow squish maps the level
// itself: SquishyToy's PILLOW_LEVEL_SCALES, from the `squishLevel` prop.)
const POKE_STRENGTH_SCALES = [0.5, 0.75, 1, 1.25, 1.5];
const POKE_STRENGTH_OPTIONS = [1, 2, 3, 4, 5].map((n) => ({ value: n, label: String(n) }));
const POKE_DIRECTION_OPTIONS = [
  { value: false, label: 'Push in' },
  { value: true, label: 'Pop out' },
];

function SettingsRow({ label, children }) {
  return (
    <View style={styles.settingsRow}>
      <Text style={styles.settingsLabel}>{label}</Text>
      {children}
    </View>
  );
}

// Settings dropdown opened from the gear: v5's white card hanging under the
// gear, with no scrim. Tapping anywhere outside it (the gear included) or
// the ✕ closes it.
function SettingsModal({
  top,
  onClose,
  squishSoundEnabled,
  onToggleSquishSound,
  coinSoundEnabled,
  onToggleCoinSound,
  releaseSoundEnabled,
  onToggleReleaseSound,
  vibrationEnabled,
  onToggleVibration,
  showFps,
  onToggleShowFps,
  pokeStrength,
  onChangePokeStrength,
  pokeOutward,
  onChangePokeOutward,
}) {
  // REDESIGN_V8: wide, in two columns (sound and display | the squish), so it fits under the gear
  const sound = (
    <>
      <Text style={styles.settingsSection}>SOUND</Text>
      <SettingsRow label="Squish sound">
        <ToggleSwitch value={squishSoundEnabled} onToggle={() => onToggleSquishSound(!squishSoundEnabled)} />
      </SettingsRow>
      <SettingsRow label="Coin sound">
        <ToggleSwitch value={coinSoundEnabled} onToggle={() => onToggleCoinSound(!coinSoundEnabled)} />
      </SettingsRow>
      <SettingsRow label="Release sound">
        <ToggleSwitch value={releaseSoundEnabled} onToggle={() => onToggleReleaseSound(!releaseSoundEnabled)} />
      </SettingsRow>

      <Text style={styles.settingsSection}>DISPLAY</Text>
      <SettingsRow label="Show FPS">
        <ToggleSwitch value={showFps} onToggle={() => onToggleShowFps(!showFps)} />
      </SettingsRow>
    </>
  );
  const squish = (
    <>
      <Text style={styles.settingsSection}>SQUISH</Text>
      <SettingsRow label="Vibration">
        <ToggleSwitch value={vibrationEnabled} onToggle={() => onToggleVibration(!vibrationEnabled)} />
      </SettingsRow>
      <Text style={styles.settingsLabel}>Poke strength</Text>
      <Segmented options={POKE_STRENGTH_OPTIONS} value={pokeStrength} onChange={onChangePokeStrength} />
      <Text style={styles.settingsHint}>1 = gentle · 5 = deepest (the vibration follows it)</Text>
      <Text style={[styles.settingsLabel, styles.settingsLabelSpaced]}>Poke direction</Text>
      <Segmented options={POKE_DIRECTION_OPTIONS} value={pokeOutward} onChange={onChangePokeOutward} />
    </>
  );
  return (
    <View style={styles.settingsOverlay}>
      <Pressable silent style={StyleSheet.absoluteFillObject} onPress={onClose} />
      <View style={[styles.settingsCard, { top }]}>
        <View style={styles.settingsHeader}>
          <Text style={styles.settingsTitle}>Settings</Text>
          <View>
            <RoundButton size={26} onPress={onClose} hitSlop={10}>
              <CloseGlyph />
            </RoundButton>
          </View>
        </View>
        <View style={styles.settingsCols}>
          <View style={styles.settingsCol}>{sound}</View>
          <View style={styles.settingsCol}>{squish}</View>
        </View>
      </View>
    </View>
  );
}

// Forces an interstitial ad after too many quick taps — unless Remove Ads
// was bought: then the popup still scolds, but ACCEPT PUNISHMENT just
// closes it.
function PunishmentModal({ visible, onDismiss, adsFree }) {
  const [loading, setLoading] = useState(false);
  const adRef = useRef(null);
  const unsubsRef = useRef([]);

  useEffect(() => {
    if (!visible) setLoading(false);
    return () => {
      unsubsRef.current.forEach((fn) => fn());
      unsubsRef.current = [];
    };
  }, [visible]);

  const acceptPunishment = useCallback(() => {
    if (loading) return;
    if (adsFree) {
      onDismiss();
      return;
    }
    setLoading(true);
    const ad = InterstitialAd.createForAdRequest(INTERSTITIAL_AD_UNIT_ID);
    adRef.current = ad;
    const done = () => {
      unsubsRef.current.forEach((fn) => fn());
      unsubsRef.current = [];
      setLoading(false);
      onDismiss();
    };
    unsubsRef.current = [
      ad.addAdEventListener(AdEventType.LOADED, () => ad.show()),
      ad.addAdEventListener(AdEventType.CLOSED, done),
      ad.addAdEventListener(AdEventType.ERROR, done),
    ];
    // If the ad never loads, don't trap the player forever.
    const t = setTimeout(done, 8000);
    unsubsRef.current.push(() => clearTimeout(t));
    ad.load();
  }, [loading, onDismiss, adsFree]);

  if (!visible) return null;
  return (
    <View style={styles.punishOverlay}>
      <PunishCard>
        <Siren />
        <OutlinedTitle text="WHOA THERE!" fill={PUNISH_FILL} size={30} />
        <Text style={styles.punishBody}>
          You&apos;re tapping way too much.{'\n'}You will be punished.
        </Text>
        <CandyButton
          label={loading ? 'LOADING…' : 'ACCEPT PUNISHMENT'}
          variant="pink"
          size="md"
          onPress={acceptPunishment}
          disabled={loading}
          dim={loading}
          style={styles.punishButton}
          textStyle={styles.punishButtonText}
        />
      </PunishCard>
    </View>
  );
}

// Red sticker fill for the "WHOA THERE!" title.
const PUNISH_FILL = { colors: ['#ffe0e6', '#ff5c7a', '#d3173d'], locations: [0, 0.5, 1] };

// The punishment card springs in (popIn) inside a red candy rim.
function PunishCard({ children }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    Animated.spring(t, { toValue: 1, friction: 5, tension: 120, useNativeDriver: true }).start();
  }, [t]);
  const scale = t.interpolate({ inputRange: [0, 1], outputRange: [0.4, 1] });
  const rotate = t.interpolate({ inputRange: [0, 1], outputRange: ['-8deg', '0deg'] });
  return (
    <Animated.View style={[styles.punishRing, { opacity: t, transform: [{ scale }, { rotate }] }]}>
      <View style={styles.punishWhite}>
        <LinearGradient colors={['#fff6fd', '#ffdcf4', '#f5cbff']} locations={[0, 0.6, 1]} style={styles.punishFace}>
          {children}
        </LinearGradient>
      </View>
    </Animated.View>
  );
}

// 🚨 that won't sit still (the design's hintShake, looped): a 360 ms shake,
// then still for 420 ms. One native loop, the pause a rest in its keyframes
// (an Animated.delay ran on JS, and held InteractionManager while it did).
const SIREN_AT = [0, 360 / 780, 1];
const SIREN_T = [0, 1, 1];
function Siren() {
  const t = useKeyLoop(780, { at: SIREN_AT, values: SIREN_T });
  const translateX = useMemo(() => t.interpolate({ inputRange: [0, 0.25, 0.75, 1], outputRange: [0, -6, 6, 0] }), [t]);
  const rotate = useMemo(() => t.interpolate({ inputRange: [0, 0.25, 0.75, 1], outputRange: ['0deg', '-10deg', '10deg', '0deg'] }), [t]);
  return <Animated.Text style={[styles.punishEmoji, { transform: [{ translateX }, { rotate }] }]}>🚨</Animated.Text>;
}

function SquishScreen({
  toy,
  coins = 0,
  onBack,
  onEarnCoins,
  onRecordPress,
  achievements = {},
  onMarkAchievement,
  onAdWatched,
  squishSoundEnabled = true,
  onToggleSquishSound,
  coinSoundEnabled = true,
  onToggleCoinSound,
  releaseSoundEnabled = true,
  onToggleReleaseSound,
  vibrationEnabled = true,
  onToggleVibration,
  showFps = false,
  onToggleShowFps,
  pokeStrength = 3,
  onChangePokeStrength,
  pokeOutward = false,
  onChangePokeOutward,
  adsFree = false,
  // the streak's +5% a day (src/progression.js), on top of a ×N boost
  coinMultiplier = 1,
  // called once the screen's views are built and drawn (App.js: the loading beat over it waits for this)
  onShown,
}) {
  const insets = useSafeAreaInsets();
  const shown = useAfterFirstFrame();
  useEffect(() => {
    if (shown && onShown) onShown();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [shown]);
  const toyRef = useRef(null);
  const soundRef = useRef(null);
  const coinSoundRef = useRef(null);
  const popSoundRef = useRef(null);
  const lastTouch = useRef({ x: 0, y: 0 });
  // where the finger was when the squish sound last counted a movement
  const soundAnchorRef = useRef({ x: 0, y: 0 });
  const holdStartRef = useRef(0);
  const effectsRef = useRef(null);
  const coinCounterRef = useRef(null);
  const tapTimestampsRef = useRef([]);
  // Coins banked this hold; flushed on release. While a poke is on:
  // earningRef, the moving time towards the next tick, and when the last
  // counted movement was.
  const earningRef = useRef(false);
  const earnAccumRef = useRef(0);
  const movingMsRef = useRef(0);
  const lastMotionAtRef = useRef(0);
  // Tap timestamps for the abuse guard; mirrors punishOpen so the
  // tap-rate check (a stable useCallback) always sees the latest value.
  const abuseTapsRef = useRef([]);
  const punishOpenRef = useRef(false);
  // gesture mode: none | poke | orbit
  const gestureModeRef = useRef('none');
  const lastCentroidRef = useRef({ x: 0, y: 0 });
  // True once 2 fingers have touched — blocks sound/coins for the rest of the gesture.
  const gestureHadTwoRef = useRef(false);

  const [settingsOpen, setSettingsOpen] = useState(false);
  const [punishOpen, setPunishOpen] = useState(false);
  const [doubleFlash, setDoubleFlash] = useState(false);
  const [doubleFlashKey, setDoubleFlashKey] = useState(0);
  // Bonus window end time + which of the three ad buttons opened it (2/3/4).
  // Only one window can run at a time — see WatchAdButton's `activeMultiplier`
  // handling. The live countdown (time and ring, ticking every 250ms) lives
  // in that button so that its frequent re-renders stay scoped to it instead
  // of the whole screen (which includes the 3D Canvas/SquishyToy tree and its
  // per-frame squish physics).
  const [bonusEndsAt, setBonusEndsAt] = useState(null);
  const [bonusMultiplier, setBonusMultiplier] = useState(2);

  const wheelAnim = useRef(new Animated.Value(0)).current;
  // the gesture hints' squish, turn and touch rings, in step: one loop for the three
  const gestureAnim = useLoopAnim({ duration: 1700 });
  // Fades the on-stage gesture tutorial out the first time the player
  // actually touches the toy — see onPanResponderGrant below. Stays hidden
  // for the rest of this screen's lifetime (hintDismissedRef).
  const gestureHintOpacity = useRef(new Animated.Value(1)).current;
  const hintDismissedRef = useRef(false);
  const [showHints, setShowHints] = useState(true);
  // The settings pointer fades when the gear is opened, or 4 s after the
  // first squish, then unmounts (its loops stop with it).
  const settingsHintOpacity = useRef(new Animated.Value(1)).current;
  const [showSettingsHint, setShowSettingsHint] = useState(true);
  const settingsHintTimerRef = useRef(null);
  const settingsPointAnim = useLoopAnim({ duration: 650 });
  const gearPulseAnim = useLoopAnim({ duration: 900 });
  const settingsHintGoneRef = useRef(false);
  const dismissSettingsHint = useCallback(() => {
    if (settingsHintGoneRef.current) return;
    settingsHintGoneRef.current = true;
    clearTimeout(settingsHintTimerRef.current);
    Animated.timing(settingsHintOpacity, { toValue: 0, duration: 300, useNativeDriver: true }).start(({ finished }) => {
      if (finished) setShowSettingsHint(false);
    });
  }, [settingsHintOpacity]);
  useEffect(() => () => clearTimeout(settingsHintTimerRef.current), []);
  // Only re-renders SquishScreen once, when the window actually expires —
  // the per-250ms countdown tick lives inside the running boost's button
  // (WatchAdButton) instead.
  useEffect(() => {
    if (!bonusEndsAt) return undefined;
    const remain = bonusEndsAt - Date.now();
    if (remain <= 0) {
      setBonusEndsAt(null);
      return undefined;
    }
    const id = setTimeout(() => setBonusEndsAt(null), remain);
    return () => clearTimeout(id);
  }, [bonusEndsAt]);

  const bonusActive = !!bonusEndsAt;
  // Remove Ads: boosts start without a video, then recharge for about as
  // long as the video would have taken (src/economy.js).
  const [boostRechargeUntil, setBoostRechargeUntil] = useState(0);

  useEffect(() => {
    const sound = new SquishSound();
    soundRef.current = sound;
    // Each premade creature has its own recording; a custom creature can
    // carry one too (see src/audio/creatureSquish.js).
    sound.load(squishSoundFor(toy));
    return () => sound.unload();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  useEffect(() => {
    const sound = new CoinSound();
    coinSoundRef.current = sound;
    sound.load();
    return () => sound.unload();
  }, []);

  useEffect(() => {
    const sound = new PopSound();
    popSoundRef.current = sound;
    sound.load();
    return () => sound.unload();
  }, []);

  useEffect(() => {
    if (!squishSoundEnabled) soundRef.current?.stop();
  }, [squishSoundEnabled]);

  // The gear turns half a revolution as the settings popup opens, and back
  // as it closes.
  const setSettingsVisible = useCallback(
    (visible) => {
      sfx.play(visible ? 'popOpen' : 'popClose');
      setSettingsOpen(visible);
      Animated.timing(wheelAnim, { toValue: visible ? 1 : 0, duration: 400, useNativeDriver: true }).start();
    },
    [wheelAnim]
  );
  const openSettings = useCallback(() => {
    dismissSettingsHint();
    setSettingsVisible(true);
  }, [setSettingsVisible, dismissSettingsHint]);
  const closeSettings = useCallback(() => setSettingsVisible(false), [setSettingsVisible]);
  const wheelRotate = wheelAnim.interpolate({ inputRange: [0, 1], outputRange: ['0deg', '180deg'] });
  const dentScale = POKE_STRENGTH_SCALES[pokeStrength - 1] ?? 1;

  const dismissSettingsHintRef = useRef(dismissSettingsHint);
  dismissSettingsHintRef.current = dismissSettingsHint;

  // Mirrors props/state so the once-created PanResponder always reads fresh values.
  const latestRef = useRef(null);
  latestRef.current = {
    achievements,
    releaseSoundEnabled,
    coinSoundEnabled,
    squishSoundEnabled,
    vibrationEnabled,
    pokeStrength,
    toy,
    onRecordPress,
    onEarnCoins,
    onMarkAchievement,
    onAdWatched,
    bonusEndsAt,
    bonusMultiplier,
    adsFree,
    coinMultiplier,
  };

  // Stable identity (deps: []) so SquishyToy/SquishyToy2D's React.memo isn't
  // defeated by a fresh closure on every SquishScreen re-render (that subtree
  // must not reconcile mid-squish: it competes with the per-frame physics).
  const handleToySquish = useCallback(() => {
    if (latestRef.current.squishSoundEnabled) soundRef.current?.start();
  }, []);
  const handleToyRelease = useCallback(() => {
    soundRef.current?.stop();
  }, []);

  // A poke starts: coins now come from moving the finger (noteEarnMotion).
  const startEarning = useCallback(() => {
    if (earningRef.current) return;
    earningRef.current = true;
    earnAccumRef.current = 0;
    movingMsRef.current = 0;
    lastMotionAtRef.current = Date.now();
  }, []);

  // A counted movement: adds the moving time since the last one, and banks
  // EARN_PER_TICK coins for every EARN_TICK_MS of it.
  const noteEarnMotion = useCallback(() => {
    if (!earningRef.current) return;
    const now = Date.now();
    movingMsRef.current += Math.min(now - lastMotionAtRef.current, MOTION_GAP_MS);
    lastMotionAtRef.current = now;
    while (movingMsRef.current >= EARN_TICK_MS) {
      movingMsRef.current -= EARN_TICK_MS;
      const { coinSoundEnabled: coinSoundOn, bonusEndsAt: liveBonusEndsAt, bonusMultiplier: liveMultiplier, coinMultiplier: liveCoinMult } = latestRef.current;
      const bonusIsLive = !!liveBonusEndsAt && now < liveBonusEndsAt;
      const gain = Math.max(1, Math.round(EARN_PER_TICK * (bonusIsLive ? liveMultiplier : 1) * (liveCoinMult || 1)));
      earnAccumRef.current += gain;
      coinCounterRef.current?.add(gain);
      if (coinSoundOn) coinSoundRef.current?.play();
      effectsRef.current?.spawnFloatingCoin(lastTouch.current.x, lastTouch.current.y, gain);
    }
  }, []);

  const stopEarning = useCallback(() => {
    earningRef.current = false;
    movingMsRef.current = 0;
    const earned = earnAccumRef.current;
    earnAccumRef.current = 0;
    if (earned > 0) {
      const { onEarnCoins: earnCoins } = latestRef.current;
      earnCoins && earnCoins(earned);
    }
    return earned;
  }, []);

  // Trips the punishment after too many quick taps. Every rule's tap-rate is
  // expressed as a percentage of its allowance (count / limit); crossing
  // 100% on any rule counts as abuse. Not gated by a cooldown — the alarm
  // is meant to reappear every single time the player abuses again, not
  // just the first time.
  const registerAbuseTap = useCallback(() => {
    if (punishOpenRef.current) return;
    const t = Date.now();
    const taps = [...abuseTapsRef.current, t].filter((ts) => t - ts < ABUSE_MAX_WINDOW_MS);
    abuseTapsRef.current = taps;
    const violated = ABUSE_RULES.some(({ windowMs, limit }) => {
      const count = taps.filter((ts) => t - ts < windowMs).length;
      const pctOfLimit = (count / limit) * 100;
      return pctOfLimit >= 100;
    });
    if (violated) {
      abuseTapsRef.current = [];
      punishOpenRef.current = true;
      setPunishOpen(true);
    }
  }, []);

  const dismissPunishment = useCallback(() => {
    punishOpenRef.current = false;
    setPunishOpen(false);
    abuseTapsRef.current = [];
  }, []);

  // Ad reward opens the 60s ×N-coins window and pops the flash. `multiplier`
  // is which of the three ad buttons was watched (2, 3, or 4) — only one
  // window runs at a time, so this simply (re)starts it at the new value.
  const handleAdReward = useCallback((multiplier) => {
    const { achievements: liveAchievements, onMarkAchievement: markAch, onAdWatched: adWatched, adsFree: noAds } = latestRef.current;
    setBonusEndsAt(Date.now() + BONUS_MS);
    if (noAds) setBoostRechargeUntil(Date.now() + BONUS_MS + AD_FREE_BOOST_RECHARGE_MS);
    setBonusMultiplier(multiplier);
    setDoubleFlash(true);
    sfx.play('boost');
    setDoubleFlashKey((k) => k + 1);
    if (!noAds && !liveAchievements.watchAd) markAch && markAch('watchAd');
    // counts toward "Movie Night" (5 ads; not when no video played) and
    // "Max Boost" (a ×4)
    if (adWatched) adWatched(multiplier);
  }, []);

  // the 3D canvas spans the whole stage; the 2D art its middle square
  const flat = !toyIs3D(toy);
  const ndcFromLocation = (locationX, locationY) =>
    flat
      ? { x: ((locationX - (STAGE_W - STAGE_SIZE) / 2) / STAGE_SIZE) * 2 - 1, y: -((locationY / STAGE_SIZE) * 2 - 1) }
      : { x: (locationX / STAGE_W) * 2 - 1, y: -((locationY / STAGE_H) * 2 - 1) };

  const centroidOf = (touches) => {
    let sx = 0;
    let sy = 0;
    for (const t of touches) {
      sx += t.locationX;
      sy += t.locationY;
    }
    return { x: sx / touches.length, y: sy / touches.length };
  };

  const panResponder = useRef(
    PanResponder.create({
      onStartShouldSetPanResponder: () => true,
      onMoveShouldSetPanResponder: () => true,
      onStartShouldSetPanResponderCapture: () => true,
      onMoveShouldSetPanResponderCapture: () => true,
      // Catches a poke -> orbit switch on the second finger landing.
      onPanResponderStart: (evt) => {
        const touches = evt.nativeEvent.touches || [];
        if (touches.length >= 2 && gestureModeRef.current !== 'orbit') {
          gestureHadTwoRef.current = true;
          toyRef.current?.cancelPoke();
          soundRef.current?.stop();
          stopEarning();
          gestureModeRef.current = 'orbit';
          lastCentroidRef.current = centroidOf(touches);
        }
      },
      onPanResponderGrant: (evt) => {
        if (!hintDismissedRef.current) {
          hintDismissedRef.current = true;
          Animated.timing(gestureHintOpacity, { toValue: 0, duration: 300, useNativeDriver: true }).start(({ finished }) => {
            if (finished) setShowHints(false);
          });
          settingsHintTimerRef.current = setTimeout(() => dismissSettingsHintRef.current(), 4000);
        }
        const touches = evt.nativeEvent.touches || [];
        gestureHadTwoRef.current = touches.length >= 2;
        if (touches.length >= 2) {
          gestureModeRef.current = 'orbit';
          lastCentroidRef.current = centroidOf(touches);
          return;
        }
        gestureModeRef.current = 'poke';
        const { locationX, locationY } = evt.nativeEvent;
        lastTouch.current = { x: locationX, y: locationY };
        soundAnchorRef.current = { x: locationX, y: locationY };
        holdStartRef.current = Date.now();
        if (latestRef.current.vibrationEnabled) pressHaptic(latestRef.current.pokeStrength);
        const ndc = ndcFromLocation(locationX, locationY);
        toyRef.current?.pointerDown(ndc.x, ndc.y);
        effectsRef.current?.spawnRipple(locationX, locationY);
        startEarning();
      },
      onPanResponderMove: (evt) => {
        const touches = evt.nativeEvent.touches || [];

        if (touches.length >= 2) {
          gestureHadTwoRef.current = true;
          // Second finger cancels any poke in progress and starts orbit.
          if (gestureModeRef.current !== 'orbit') {
            toyRef.current?.cancelPoke();
            soundRef.current?.stop();
            stopEarning();
            gestureModeRef.current = 'orbit';
            lastCentroidRef.current = centroidOf(touches);
            return;
          }
          const c = centroidOf(touches);
          toyRef.current?.orbit(c.x - lastCentroidRef.current.x, c.y - lastCentroidRef.current.y);
          lastCentroidRef.current = c;
          return;
        }

        if (gestureModeRef.current === 'orbit') {
          // Keep orbiting with the remaining finger.
          if (touches.length === 1) {
            const c = { x: touches[0].locationX, y: touches[0].locationY };
            toyRef.current?.orbit(c.x - lastCentroidRef.current.x, c.y - lastCentroidRef.current.y);
            lastCentroidRef.current = c;
          }
          return;
        }

        const { locationX, locationY } = evt.nativeEvent;
        lastTouch.current = { x: locationX, y: locationY };
        const ndc = ndcFromLocation(locationX, locationY);
        toyRef.current?.pointerMove(ndc.x, ndc.y);
        // Real movement (not jitter) keeps the squish sound going and earns
        // coins.
        const ax = locationX - soundAnchorRef.current.x;
        const ay = locationY - soundAnchorRef.current.y;
        if (ax * ax + ay * ay >= SOUND_MOTION_DP * SOUND_MOTION_DP) {
          soundAnchorRef.current = { x: locationX, y: locationY };
          noteEarnMotion();
          if (latestRef.current.squishSoundEnabled) soundRef.current?.noteMotion();
          if (latestRef.current.vibrationEnabled) moveHaptic(latestRef.current.pokeStrength);
        }
      },
      onPanResponderRelease: () => {
        const mode = gestureModeRef.current;
        const hadTwo = gestureHadTwoRef.current;
        gestureModeRef.current = 'none';
        gestureHadTwoRef.current = false;
        // Orbit gestures never earn coins or play the release sound.
        if (mode === 'orbit' || hadTwo) {
          toyRef.current?.endOrbit();
          toyRef.current?.pointerUp();
          soundRef.current?.stop();
          stopEarning();
          return;
        }
        const result = toyRef.current?.pointerUp();
        if (!result || !result.wasPoke) {
          stopEarning();
          return;
        }
        const { achievements: liveAchievements, releaseSoundEnabled: releaseSoundOn, toy: currentToy, onRecordPress: recordPress, onMarkAchievement: markAch } = latestRef.current;

        const holdMs = Date.now() - holdStartRef.current;
        const now = Date.now();
        const timestamps = [...tapTimestampsRef.current, now].filter((t) => now - t < SPEED_TAP_WINDOW_MS);
        tapTimestampsRef.current = timestamps;
        if (timestamps.length >= SPEED_TAP_THRESHOLD && !liveAchievements.speedTap) {
          markAch && markAch('speedTap');
        }

        recordPress && recordPress(currentToy.id, holdMs);

        // Flush the banked total; quick jabs count toward the abuse guard.
        stopEarning();
        if (holdMs < 400) registerAbuseTap();

        soundRef.current?.stop();
        if (releaseSoundOn) popSoundRef.current?.play();
        if (latestRef.current.vibrationEnabled) releaseHaptic(latestRef.current.pokeStrength);
      },
      onPanResponderTerminate: () => {
        gestureModeRef.current = 'none';
        gestureHadTwoRef.current = false;
        toyRef.current?.endOrbit();
        toyRef.current?.pointerUp();
        soundRef.current?.stop();
        stopEarning();
      },
    })
    // eslint-disable-next-line react-hooks/exhaustive-deps
  ).current;

  return (
    <View style={styles.container}>
      {/* the 2026-11-21 remodel: the Crib's living room in daylight, a cushion to stand on */}
      <Room room="living" phase="day" width={SCREEN_W} height={SCREEN_H} full />
      <Cushion />

      <View style={styles.stageWrap}>
        <SquishStage
          toy={toy}
          toyRef={toyRef}
          effectsRef={effectsRef}
          panHandlers={panResponder.panHandlers}
          onSquish={handleToySquish}
          onRelease={handleToyRelease}
          hintOpacity={gestureHintOpacity}
          showHints={showHints}
          squishAnim={gestureAnim}
          rotateAnim={gestureAnim}
          touchAnim={gestureAnim}
          dentScale={dentScale}
          squishLevel={pokeStrength}
          dentOutward={pokeOutward}
        />
      </View>

      <View style={[styles.topLeft, { top: insets.top + HUD_TOP }]}>
        <Orb icon="back" size={40} onPress={onBack} />
        <CoinCounter ref={coinCounterRef} />
        {showFps && <FpsCounter />}
      </View>

      {showSettingsHint ? (
        <SettingsHint top={insets.top + HUD_TOP} opacity={settingsHintOpacity} bobAnim={settingsPointAnim} pulseAnim={gearPulseAnim} />
      ) : null}

      {/* the gear: the screen's top-right corner (the user, 2026-11-21) */}
      <View style={[styles.wheelButton, { top: insets.top + HUD_TOP }]}>
        <Orb size={GEAR_SIZE} onPress={openSettings}>
          <Animated.View style={{ transform: [{ rotate: wheelRotate }] }}>
            <Icon d={ICON.gear} size={GEAR_SIZE * 0.56} width={2.2} />
          </Animated.View>
        </Orb>
      </View>

      {/* the boosts: a slim rail of round buttons down the right edge, under the gear */}
      <View style={[styles.rail, { top: insets.top + HUD_TOP + GEAR_SIZE + 8 }]}>
        {[2, 3, 4].map((m) => (
          <WatchAdButton
            key={m}
            multiplier={m}
            onRewardEarned={() => handleAdReward(m)}
            activeMultiplier={bonusActive ? bonusMultiplier : null}
            adFree={adsFree}
            rechargeUntil={boostRechargeUntil}
            endsAt={bonusActive && bonusMultiplier === m ? bonusEndsAt : 0}
            total={BONUS_MS}
          />
        ))}
      </View>

      {doubleFlash && (
        <View style={styles.flashOverlay} pointerEvents="none">
          <PopIn key={doubleFlashKey} onFadeOutDone={() => setDoubleFlash(false)} style={styles.doubleFlashPop}>
            <OutlinedTitle text={`×${bonusMultiplier} COINS!`} fill="gold" size={44} outline={4} />
          </PopIn>
        </View>
      )}

      {settingsOpen && (
        <SettingsModal
          top={insets.top + HUD_TOP + GEAR_SIZE + 8}
          onClose={closeSettings}
          squishSoundEnabled={squishSoundEnabled}
          onToggleSquishSound={onToggleSquishSound}
          coinSoundEnabled={coinSoundEnabled}
          onToggleCoinSound={onToggleCoinSound}
          releaseSoundEnabled={releaseSoundEnabled}
          onToggleReleaseSound={onToggleReleaseSound}
          vibrationEnabled={vibrationEnabled}
          onToggleVibration={onToggleVibration}
          showFps={showFps}
          onToggleShowFps={onToggleShowFps}
          pokeStrength={pokeStrength}
          onChangePokeStrength={onChangePokeStrength}
          pokeOutward={pokeOutward}
          onChangePokeOutward={onChangePokeOutward}
        />
      )}

      <PunishmentModal visible={punishOpen} onDismiss={dismissPunishment} adsFree={adsFree} />
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, backgroundColor: '#dba163', overflow: 'hidden' },
  stageWrap: { position: 'absolute', left: STAGE_LEFT, top: 0 },
  topLeft: { position: 'absolute', left: 14, flexDirection: 'row', alignItems: 'center', gap: 12, zIndex: 3 },
  // the coins earned: the menu's coin pill (royal/parts.js Pill), its coin big over the left end
  coinPill: { height: 32, flexDirection: 'row', alignItems: 'center', gap: 5, paddingLeft: 32, paddingRight: 14, marginLeft: 8 },
  coinPillImg: { position: 'absolute', left: -15, top: -6, width: 44, height: 44, resizeMode: 'contain' },
  coinPillEarned: { letterSpacing: 0.8 },
  rail: { position: 'absolute', right: 16, bottom: 10, justifyContent: 'space-evenly', alignItems: 'center', zIndex: 3 },
  fpsPill: { paddingHorizontal: 10, paddingVertical: 4 },
  fpsText: {
    fontFamily: candyFonts.bodyHeavy,
    fontSize: 12,
    textShadowColor: candyColors.outline,
    textShadowOffset: { width: 0, height: 1 },
    textShadowRadius: 1,
  },
  wheelButton: { position: 'absolute', right: GEAR_RIGHT, zIndex: 3 },
  settingsHintLayer: { zIndex: 4 },
  gearHalo: {
    position: 'absolute',
    width: GEAR_SIZE + 10,
    height: GEAR_SIZE + 10,
    borderRadius: (GEAR_SIZE + 10) / 2,
    borderWidth: 3,
    borderColor: '#ff8a3d',
  },
  gearHint: { position: 'absolute', right: 10, alignItems: 'flex-end', gap: 4 },
  stage: { width: STAGE_W, height: STAGE_H },
  stage2D: { position: 'absolute', left: (STAGE_W - STAGE_SIZE) / 2, top: 0, width: STAGE_SIZE, height: STAGE_SIZE },
  ripple: {
    position: 'absolute',
    left: 0,
    top: 0,
    width: RIPPLE_MAX,
    height: RIPPLE_MAX,
    borderRadius: RIPPLE_MAX / 2,
    borderWidth: 3,
    borderColor: 'rgba(255,111,189,0.7)',
  },
  floatingCoin: { position: 'absolute', left: 0, top: 0, flexDirection: 'row', alignItems: 'center', gap: 2, zIndex: 6 },

  settingsOverlay: { ...StyleSheet.absoluteFillObject, zIndex: 40 },
  settingsCard: {
    position: 'absolute',
    right: GEAR_RIGHT,
    width: 470,
    backgroundColor: '#ffffff',
    borderRadius: 16,
    borderWidth: 1.5,
    borderColor: '#6b4426',
    padding: 14,
    paddingTop: 10,
    shadowColor: '#3f2412',
    shadowOpacity: 0.28,
    shadowRadius: 15,
    shadowOffset: { width: 0, height: 12 },
    elevation: 10,
  },
  settingsCols: { flexDirection: 'row', gap: 22 },
  settingsCol: { flex: 1 },
  settingsHeader: { flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between' },
  settingsTitle: { fontFamily: candyFonts.display, fontSize: 15, color: '#5b3418' },
  settingsSection: {
    marginTop: 8,
    marginBottom: 1,
    color: '#b08560',
    fontFamily: candyFonts.bodyHeavy,
    fontSize: 9.5,
    letterSpacing: 1.2,
  },
  settingsRow: { flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between', paddingVertical: 3 },
  settingsLabel: { color: '#5b3418', fontFamily: candyFonts.bodyHeavy, fontSize: 12.5 },
  settingsLabelSpaced: { marginTop: 8 },
  settingsHint: { marginTop: 3, color: '#b08560', fontFamily: candyFonts.body, fontSize: 9.5 },
  segmented: { flexDirection: 'row', gap: 4, marginTop: 5 },
  segment: {
    flex: 1,
    paddingVertical: 6,
    borderRadius: 10,
    borderWidth: 2,
    borderColor: '#ecd3b0',
    backgroundColor: '#ffffff',
    alignItems: 'center',
    overflow: 'hidden',
  },
  segmentActive: { borderColor: '#ffffff' },
  segmentText: { color: candyColors.ink, fontFamily: candyFonts.display, fontSize: 13 },
  segmentTextActive: { color: '#ffffff', textShadowColor: candyColors.pinkRing, textShadowOffset: { width: 0, height: 1.5 }, textShadowRadius: 1 },

  gestureHint: { position: 'absolute', top: '50%', alignItems: 'center', gap: 6 },
  gestureHandWrap: { width: HAND_W, height: HAND_W * HAND_ASPECT },
  touchRing: {
    position: 'absolute',
    width: 26,
    height: 26,
    borderRadius: 13,
    borderWidth: 2.5,
    borderColor: '#ff6fbd',
  },
  hintPillText: {
    color: '#5b3418',
    fontFamily: candyFonts.bodyHeavy,
    fontSize: 10,
    letterSpacing: 1.1,
    textShadowColor: '#ffffff',
    textShadowOffset: { width: 0, height: 0 },
    textShadowRadius: 6,
    includeFontPadding: false,
  },
  hintPillSub: {
    color: '#6b4426',
    fontFamily: candyFonts.bodyHeavy,
    fontSize: 9.5,
    marginTop: 2,
    textShadowColor: '#ffffff',
    textShadowOffset: { width: 0, height: 0 },
    textShadowRadius: 6,
  },
  flashOverlay: {
    ...StyleSheet.absoluteFillObject,
    alignItems: 'center',
    justifyContent: 'center',
    paddingHorizontal: 20,
    zIndex: 32,
  },
  doubleFlashPop: { alignItems: 'center' },

  punishOverlay: {
    ...StyleSheet.absoluteFillObject,
    backgroundColor: 'rgba(50,24,6,0.55)',
    alignItems: 'center',
    justifyContent: 'center',
    padding: 26,
    zIndex: 60,
  },
  punishRing: {
    width: '100%',
    maxWidth: 340,
    borderRadius: 31,
    padding: 3,
    backgroundColor: candyColors.danger,
    shadowColor: '#3f2412',
    shadowOffset: { width: 0, height: 14 },
    shadowOpacity: 0.5,
    shadowRadius: 18,
    elevation: 14,
  },
  punishWhite: { borderRadius: 28, borderWidth: 4, borderColor: '#ffffff', overflow: 'hidden' },
  punishFace: { paddingHorizontal: 22, paddingTop: 22, paddingBottom: 20, alignItems: 'center' },
  punishEmoji: { fontSize: 46, marginBottom: 2 },
  punishBody: {
    fontFamily: candyFonts.body,
    fontSize: 15,
    lineHeight: 21,
    color: candyColors.ink,
    textAlign: 'center',
    marginTop: 4,
    marginBottom: 20,
  },
  punishButton: { alignSelf: 'stretch' },
  punishButtonText: { fontSize: 15 },
});

// memo: App re-renders on things the stage doesn't show (sheets, toasts);
// each of those used to re-render this whole screen
export default React.memo(SquishScreen);
