import React, { forwardRef, memo, useCallback, useEffect, useImperativeHandle, useRef, useState } from 'react';
import { View, Text, StyleSheet, PanResponder, Animated, Pressable, Easing, Dimensions } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { Canvas } from '@react-three/fiber';
import { NeutralToneMapping } from 'three';
import { MaterialIcons } from '@expo/vector-icons';
import Svg, { Path, Circle } from 'react-native-svg';
import { InterstitialAd, AdEventType } from 'react-native-google-mobile-ads';
import SquishyToy from '../components/SquishyToy';
import SquishyToy2D from '../components/SquishyToy2D';
import Supersample from '../components/Supersample';
import { INTERSTITIAL_AD_UNIT_ID } from '../firebase/ads';

// A creature with a `modelUrl` (every premade creature, plus a photo-path
// custom one) mounts the 3D mesh; everything else falls back to 2D art
// (SquishyToy2D).
import SquishSound from '../audio/SquishSound';
import CoinSound from '../audio/CoinSound';
import PopSound from '../audio/PopSound';
import { squadColors, squadGradients, squadFonts } from '../theme/squadTheme';
import AdBanner from '../components/AdBanner';
import WatchAdButton from '../components/WatchAdButton';

// Stage size scales to the device, capped at 380.
const STAGE_SIZE = Math.min(Math.round(Dimensions.get('window').width - 32), 380);
const RIPPLE_LIFETIME_MS = 620;
// 60s window where an ad-watch doubles squish rewards.
const BONUS_MS = 60000;
const SPEED_TAP_WINDOW_MS = 60000;
const SPEED_TAP_THRESHOLD = 60;

// Bank 1 coin every 1.5s while held; two fingers (rotate) earns nothing.
const EARN_TICK_MS = 1500;
const EARN_PER_TICK = 1;
// Floating "+1" per tick: rises, spins, fades.
const FLOATING_COIN_MS = 2200;
const FLOATING_COIN_RISE = 100;
const FLOATING_COIN_SIZE = 24;

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

const DEFAULT_SQUISH_SOUND = require('../../assets/audio/slime.wav');

const RIPPLE_MAX = 120;

// True for 3D-mesh creatures; picks Canvas vs SquishyToy2D in SquishStage.
const toyIs3D = (t) => !!(t && t.modelUrl);

// Ring that blooms from the touch point and fades. Memoized (like
// FloatingCoin) so spawning a new one doesn't re-render the ones already
// mid-animation.
const Ripple = memo(function Ripple({ x, y }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    Animated.timing(t, { toValue: 1, duration: RIPPLE_LIFETIME_MS, easing: Easing.out(Easing.quad), useNativeDriver: true }).start();
  }, [t]);
  const scale = t.interpolate({ inputRange: [0, 1], outputRange: [0.25, 1] });
  const opacity = t.interpolate({ inputRange: [0, 0.15, 1], outputRange: [0, 0.5, 0] });
  return (
    <Animated.View
      pointerEvents="none"
      style={[
        styles.ripple,
        { left: x - RIPPLE_MAX / 2, top: y - RIPPLE_MAX / 2, opacity, transform: [{ scale }] },
      ]}
    />
  );
});

// Coin that rises, spins, and fades — pops once per earn tick.
const FloatingCoin = memo(function FloatingCoin({ x, y, amount }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    Animated.timing(t, { toValue: 1, duration: FLOATING_COIN_MS, easing: Easing.out(Easing.quad), useNativeDriver: true }).start();
  }, [t]);
  const translateY = t.interpolate({ inputRange: [0, 1], outputRange: [0, -FLOATING_COIN_RISE] });
  const scale = t.interpolate({ inputRange: [0, 0.2, 1], outputRange: [0.5, 1, 1] });
  const opacity = t.interpolate({ inputRange: [0, 0.15, 0.55, 1], outputRange: [0, 1, 1, 0] });
  const spin = t.interpolate({ inputRange: [0, 1], outputRange: ['0deg', '360deg'] });
  return (
    <Animated.View
      pointerEvents="none"
      style={[styles.floatingCoin, { left: x - 34, top: y - 46, opacity, transform: [{ translateY }, { scale }] }]}
    >
      <Animated.View style={[styles.floatingCoinBadge, { transform: [{ rotateY: spin }] }]}>
        <LinearGradient
          colors={squadGradients.goldDot.colors}
          start={squadGradients.goldDot.start}
          end={squadGradients.goldDot.end}
          style={StyleSheet.absoluteFillObject}
        />
      </Animated.View>
      <Text style={styles.floatingCoinText}>+{amount}</Text>
    </Animated.View>
  );
});

// Touch ripples + floating "+N" coins. Owns its own lists (driven through
// the ref) so spawning/expiring them re-renders only this overlay — not
// SquishScreen — since a ripple spawns on the very touch that starts a squish.
const StageEffects = memo(forwardRef(function StageEffects(_props, ref) {
  const [ripples, setRipples] = useState([]);
  const [floatingCoins, setFloatingCoins] = useState([]);
  const seqRef = useRef(0);
  useImperativeHandle(
    ref,
    () => ({
      spawnRipple: (x, y) => {
        const id = ++seqRef.current;
        setRipples((prev) => [...prev, { id, x, y }]);
        setTimeout(() => setRipples((prev) => prev.filter((r) => r.id !== id)), RIPPLE_LIFETIME_MS);
      },
      spawnFloatingCoin: (x, y, amount) => {
        const id = ++seqRef.current;
        setFloatingCoins((prev) => [...prev, { id, x, y, amount }]);
        setTimeout(() => setFloatingCoins((prev) => prev.filter((c) => c.id !== id)), FLOATING_COIN_MS);
      },
    }),
    []
  );
  return (
    <View style={StyleSheet.absoluteFillObject} pointerEvents="none">
      {ripples.map((r) => (
        <Ripple key={r.id} x={r.x} y={r.y} />
      ))}
      {floatingCoins.map((c) => (
        <FloatingCoin key={c.id} x={c.x} y={c.y} amount={c.amount} />
      ))}
    </View>
  );
}));

// Top-bar coin pill. Counts up through its ref on each earn tick, so the
// tick re-renders only this pill instead of the whole screen mid-squish.
const CoinCounter = memo(forwardRef(function CoinCounter({ initial }, ref) {
  const [value, setValue] = useState(initial);
  useImperativeHandle(ref, () => ({ add: (n) => setValue((c) => c + n) }), []);
  return (
    <View style={styles.coinPill}>
      <View style={styles.coinDot} />
      <Text style={styles.coinPillText}>{value}</Text>
    </View>
  );
}));

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
  const color = fps == null ? squadColors.textLavender : fps >= 55 ? '#4ade80' : fps >= 40 ? '#facc15' : '#f87171';
  return (
    <View style={styles.fpsPill}>
      <Text style={[styles.fpsText, { color }]}>{fps == null ? '–' : fps} FPS</Text>
    </View>
  );
}

// Live ×N-coins countdown bar. Ticks its own `now` every 250ms in isolation
// so that redraw stays scoped to this small subtree instead of re-rendering
// the whole SquishScreen (which would otherwise drag the 3D Canvas/SquishyToy
// tree and its inline props through reconciliation 4x/sec, competing with the
// per-frame squish physics on the JS thread and making the squish feel
// laggy while a bonus window is running).
function BonusBanner({ endsAt, multiplier, coinAnim }) {
  const [now, setNow] = useState(() => Date.now());
  useEffect(() => {
    const id = setInterval(() => setNow(Date.now()), 250);
    return () => clearInterval(id);
  }, []);
  const remain = Math.max(0, endsAt - now);
  const secs = Math.ceil(remain / 1000);
  const timeText = `${Math.floor(secs / 60)}:${String(secs % 60).padStart(2, '0')}`;
  const pct = Math.max(0, Math.min(100, (remain / BONUS_MS) * 100));
  const coinScale = coinAnim.interpolate({ inputRange: [0, 1], outputRange: [1, 1.1] });
  return (
    <View style={styles.bonusBar}>
      <View style={styles.bonusInner}>
        <Animated.View style={[styles.bonusCoin, { transform: [{ scale: coinScale }] }]}>
          <LinearGradient
            colors={squadGradients.goldDot.colors}
            start={squadGradients.goldDot.start}
            end={squadGradients.goldDot.end}
            style={StyleSheet.absoluteFillObject}
          />
          <Text style={styles.bonusCoinText}>×{multiplier}</Text>
        </Animated.View>
        <View style={styles.bonusBody}>
          <View style={styles.bonusTopRow}>
            <Text style={styles.bonusLabel}>×{multiplier} COINS ACTIVE</Text>
            <Text style={styles.bonusTime}>{timeText}</Text>
          </View>
          <View style={styles.bonusTrack}>
            <View style={[styles.bonusFill, { width: `${pct}%` }]} />
          </View>
        </View>
      </View>
    </View>
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
// permanent bottom-panel hint list) — a squish hand on the left, a rotate
// hand on the right, each with a pulsing touch-point ring, fading out the
// first time the player actually touches the toy (see gestureHintOpacity).
const SQUISH_HAND_D =
  'M24 17A6 6 0 0 1 36 17L36 42C37 39 41 37.5 44 39C47.4 40.4 48.4 44 47.4 47C48.4 44 51.4 42.4 54.4 43.6C57.8 45 58.8 48.4 57.8 51.6C59.4 49.4 62.6 48.8 64.8 50.6C67.4 52.6 67.8 55.8 67 59L65.4 69C63.8 81.4 54.8 90.6 42.8 90.6L35.8 90.6C23.4 90.6 15.2 81.6 13.8 69.2L12.8 60.6L5.8 50.6C2.8 46.2 9.2 41.6 12.8 46.2L19.4 55.2C20.6 56.8 22.2 57.4 24 57.4Z';
const SQUISH_HAND_CREASE_D = 'M47.4 47c-2.6.6-5.4.2-7.6-1.2M57.8 51.6c-2.6.8-5.6.4-8-1';
const ROTATE_HAND_D =
  'M18 22A6 6 0 0 1 30 22L30 44L32 44L32 15A6 6 0 0 1 44 15L44 47C45.4 44 49 42.6 52 44.2C55.4 45.8 56.2 49.4 55 52.6C56.8 50.4 60 50 62.2 52C64.8 54.2 65 57.4 64 60.4L62.6 69.6C61 82 52 90.6 40 90.6L33 90.6C21 90.6 13 81.6 11.8 69.4L10.8 61L4 51C1 46.6 7.4 42 11 46.6L17 55.4C17.6 56.4 17.8 56.6 18 57Z';
const ROTATE_HAND_CREASE_D = 'M55 52.6c-2.6.8-5.6.4-8-1M31 44.4c-.2 4 .4 8 1.8 11.6';

function GestureHint({ side, d, creaseD, label, touchAnim, gestureAnim }) {
  const sideStyle = side === 'left' ? { left: '12%' } : { right: '12%' };
  return (
    <View style={[styles.gestureHint, sideStyle]} pointerEvents="none">
      <Animated.View style={[styles.gestureHandWrap, { transform: gestureAnim }]}>
        <Animated.View
          style={[
            styles.gestureTouchRing,
            side === 'left' ? { left: 10 } : { left: 8 },
            { opacity: touchAnim.interpolate({ inputRange: [0, 0.5, 1], outputRange: [0.9, 0.2, 0.9] }), transform: [{ scale: touchAnim.interpolate({ inputRange: [0, 1], outputRange: [1, 1.25] }) }] },
          ]}
        />
        <Svg width={46} height={62} viewBox="0 0 72 96" style={styles.gestureSvg}>
          <Path d={d} fill="rgba(255,255,255,0.28)" stroke="#ffffff" strokeWidth={2.8} strokeLinejoin="round" />
          <Path d={creaseD} stroke="rgba(255,255,255,0.75)" strokeWidth={2} strokeLinecap="round" fill="none" />
        </Svg>
      </Animated.View>
      <Text style={styles.gestureHintText}>{label}</Text>
    </View>
  );
}

function useLoopAnim(config) {
  const anim = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(anim, { toValue: 1, duration: config.duration, easing: Easing.inOut(Easing.ease), useNativeDriver: true }),
        Animated.timing(anim, { toValue: 0, duration: config.duration, easing: Easing.inOut(Easing.ease), useNativeDriver: true }),
      ])
    );
    loop.start();
    return () => loop.stop();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);
  return anim;
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
  squishAnim,
  rotateAnim,
  touchAnim,
  dentScale,
  dentOutward,
}) {
  return (
    <View style={styles.stage} {...panHandlers}>
      {toyIs3D(toy) ? (
        <Canvas
          frameloop="always"
          camera={{ fov: 30, position: [0, 0.1, 4.6], near: 0.1, far: 100 }}
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
            visual={toy.visual}
            onSquish={onSquish}
            onRelease={onRelease}
            dentScale={dentScale}
            dentOutward={dentOutward}
          />
        </Canvas>
      ) : (
        <SquishyToy2D
          ref={toyRef}
          creature={toy}
          imageUri={toy.isCustom ? toy.image : undefined}
          build={toy.isCustom ? toy.build : undefined}
          size={STAGE_SIZE}
          onSquish={onSquish}
          onRelease={onRelease}
        />
      )}

      <StageEffects ref={effectsRef} />

      <Animated.View style={[StyleSheet.absoluteFillObject, { opacity: hintOpacity }]} pointerEvents="none">
        <GestureHint
          side="left"
          d={SQUISH_HAND_D}
          creaseD={SQUISH_HAND_CREASE_D}
          label="HOLD TO SQUISH"
          touchAnim={touchAnim}
          gestureAnim={[{ translateY: squishAnim.interpolate({ inputRange: [0, 0.5, 1], outputRange: [0, 8, 0] }) }]}
        />
        <GestureHint
          side="right"
          d={ROTATE_HAND_D}
          creaseD={ROTATE_HAND_CREASE_D}
          label="HOLD TO ROTATE"
          touchAnim={touchAnim}
          gestureAnim={[{ rotate: rotateAnim.interpolate({ inputRange: [0, 0.5, 1], outputRange: ['0deg', '-14deg', '0deg'] }) }]}
        />
      </Animated.View>
    </View>
  );
});

function ToggleSwitch({ value, onToggle }) {
  const anim = useRef(new Animated.Value(value ? 1 : 0)).current;
  useEffect(() => {
    Animated.timing(anim, { toValue: value ? 1 : 0, duration: 150, useNativeDriver: false }).start();
  }, [value, anim]);
  const knobLeft = anim.interpolate({ inputRange: [0, 1], outputRange: [2, 18] });
  return (
    <Pressable onPress={onToggle}>
      <View style={[styles.switchTrack, { backgroundColor: value ? undefined : squadColors.panelBorder }]}>
        {value && (
          <LinearGradient colors={squadGradients.goldDot.colors} start={squadGradients.goldDot.start} end={squadGradients.goldDot.end} style={StyleSheet.absoluteFillObject} />
        )}
        <Animated.View style={[styles.switchKnob, { left: knobLeft }]} />
      </View>
    </Pressable>
  );
}

// Row of buttons where exactly one is selected.
function Segmented({ options, value, onChange }) {
  return (
    <View style={styles.segmented}>
      {options.map((option) => {
        const active = option.value === value;
        return (
          <Pressable
            key={String(option.value)}
            onPress={() => onChange(option.value)}
            style={[styles.segment, active && styles.segmentActive]}
          >
            <Text style={[styles.segmentText, active && styles.segmentTextActive]}>{option.label}</Text>
          </Pressable>
        );
      })}
    </View>
  );
}

// Poke strength setting (1-5) -> multiplier on SquishyToy's tuned dent depth.
// 3 is the tuned default.
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

// Settings popup opened from the gear. Tapping outside the card or the X
// closes it.
function SettingsModal({
  onClose,
  squishSoundEnabled,
  onToggleSquishSound,
  coinSoundEnabled,
  onToggleCoinSound,
  releaseSoundEnabled,
  onToggleReleaseSound,
  showFps,
  onToggleShowFps,
  pokeStrength,
  onChangePokeStrength,
  pokeOutward,
  onChangePokeOutward,
}) {
  return (
    <View style={styles.settingsOverlay}>
      <Pressable style={StyleSheet.absoluteFillObject} onPress={onClose} />
      <View style={styles.settingsCard}>
        <View style={styles.settingsHeader}>
          <Text style={styles.settingsTitle}>SETTINGS</Text>
          <Pressable onPress={onClose} hitSlop={10} style={styles.settingsClose}>
            <MaterialIcons name="close" size={20} color={squadColors.textLavender} />
          </Pressable>
        </View>

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

        <Text style={styles.settingsSection}>SQUISH</Text>
        <Text style={styles.settingsLabel}>Poke strength</Text>
        <Segmented options={POKE_STRENGTH_OPTIONS} value={pokeStrength} onChange={onChangePokeStrength} />
        <Text style={styles.settingsHint}>1 = gentle · 5 = deepest</Text>
        <Text style={[styles.settingsLabel, styles.settingsLabelSpaced]}>Poke direction</Text>
        <Segmented options={POKE_DIRECTION_OPTIONS} value={pokeOutward} onChange={onChangePokeOutward} />
      </View>
    </View>
  );
}

// Forces an interstitial ad after too many quick taps.
function PunishmentModal({ visible, onDismiss }) {
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
  }, [loading, onDismiss]);

  if (!visible) return null;
  return (
    <View style={styles.punishOverlay}>
      <View style={styles.punishCard}>
        <Text style={styles.punishEmoji}>🚨</Text>
        <Text style={styles.punishTitle}>WHOA THERE!</Text>
        <Text style={styles.punishBody}>
          You&apos;re tapping way too much.{'\n'}You will be punished.
        </Text>
        <Pressable
          onPress={acceptPunishment}
          disabled={loading}
          style={({ pressed }) => [styles.punishButton, (pressed || loading) && styles.punishButtonDim]}
        >
          <Text style={styles.punishButtonText}>{loading ? 'LOADING…' : 'ACCEPT PUNISHMENT'}</Text>
        </Pressable>
      </View>
    </View>
  );
}

export default function SquishScreen({
  toy,
  coins = 0,
  onBack,
  onEarnCoins,
  onRecordPress,
  achievements = {},
  onMarkAchievement,
  squishSoundEnabled = true,
  onToggleSquishSound,
  coinSoundEnabled = true,
  onToggleCoinSound,
  releaseSoundEnabled = true,
  onToggleReleaseSound,
  showFps = true,
  onToggleShowFps,
  pokeStrength = 3,
  onChangePokeStrength,
  pokeOutward = false,
  onChangePokeOutward,
}) {
  const insets = useSafeAreaInsets();
  const toyRef = useRef(null);
  const soundRef = useRef(null);
  const coinSoundRef = useRef(null);
  const popSoundRef = useRef(null);
  const lastTouch = useRef({ x: 0, y: 0 });
  const holdStartRef = useRef(0);
  const effectsRef = useRef(null);
  const coinCounterRef = useRef(null);
  const tapTimestampsRef = useRef([]);
  // Coins banked this hold; flushed on release.
  const earnIntervalRef = useRef(null);
  const earnAccumRef = useRef(0);
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
  // handling. The live countdown (text/progress bar, ticking every 250ms)
  // lives in the BonusBanner child below so that its frequent re-renders stay
  // scoped to that small subtree instead of the whole screen (which includes
  // the 3D Canvas/SquishyToy tree and its per-frame squish physics).
  const [bonusEndsAt, setBonusEndsAt] = useState(null);
  const [bonusMultiplier, setBonusMultiplier] = useState(2);

  const wheelAnim = useRef(new Animated.Value(0)).current;
  const gestureSquishAnim = useLoopAnim({ duration: 1700 });
  const gestureRotateAnim = useLoopAnim({ duration: 1700 });
  const gestureTouchAnim = useLoopAnim({ duration: 1700 });
  // Fades the on-stage gesture tutorial out the first time the player
  // actually touches the toy — see onPanResponderGrant below. Stays hidden
  // for the rest of this screen's lifetime (hintDismissedRef).
  const gestureHintOpacity = useRef(new Animated.Value(1)).current;
  const hintDismissedRef = useRef(false);
  const bonusCoinAnim = useLoopAnim({ duration: 1300 });

  // Only re-renders SquishScreen once, when the window actually expires —
  // the per-250ms countdown tick lives inside BonusBanner instead.
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

  useEffect(() => {
    const sound = new SquishSound();
    soundRef.current = sound;
    // Custom creatures can carry their own squish sound.
    sound.load(toy?.audio ? { uri: toy.audio } : DEFAULT_SQUISH_SOUND);
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
      setSettingsOpen(visible);
      Animated.timing(wheelAnim, { toValue: visible ? 1 : 0, duration: 400, useNativeDriver: true }).start();
    },
    [wheelAnim]
  );
  const openSettings = useCallback(() => setSettingsVisible(true), [setSettingsVisible]);
  const closeSettings = useCallback(() => setSettingsVisible(false), [setSettingsVisible]);
  const wheelRotate = wheelAnim.interpolate({ inputRange: [0, 1], outputRange: ['0deg', '180deg'] });
  const dentScale = POKE_STRENGTH_SCALES[pokeStrength - 1] ?? 1;

  // Mirrors props/state so the once-created PanResponder always reads fresh values.
  const latestRef = useRef(null);
  latestRef.current = {
    achievements,
    releaseSoundEnabled,
    coinSoundEnabled,
    squishSoundEnabled,
    toy,
    onRecordPress,
    onEarnCoins,
    onMarkAchievement,
    bonusEndsAt,
    bonusMultiplier,
  };

  // Stable identity (deps: []) so SquishyToy/SquishyToy2D's React.memo isn't
  // defeated by a fresh closure on every SquishScreen re-render — see
  // BonusBanner above for why keeping that subtree from reconciling matters.
  const handleToySquish = useCallback(() => {
    if (latestRef.current.squishSoundEnabled) soundRef.current?.start();
  }, []);
  const handleToyRelease = useCallback(() => {
    soundRef.current?.stop();
  }, []);

  // Earn EARN_PER_TICK coins every EARN_TICK_MS while held.
  const startEarning = useCallback(() => {
    if (earnIntervalRef.current) return;
    earnAccumRef.current = 0;
    earnIntervalRef.current = setInterval(() => {
      const { coinSoundEnabled: coinSoundOn, bonusEndsAt: liveBonusEndsAt, bonusMultiplier: liveMultiplier } = latestRef.current;
      const bonusIsLive = !!liveBonusEndsAt && Date.now() < liveBonusEndsAt;
      const gain = EARN_PER_TICK * (bonusIsLive ? liveMultiplier : 1);
      earnAccumRef.current += gain;
      coinCounterRef.current?.add(gain);
      if (coinSoundOn) coinSoundRef.current?.play();
      effectsRef.current?.spawnFloatingCoin(lastTouch.current.x, lastTouch.current.y, gain);
    }, EARN_TICK_MS);
  }, []);

  const stopEarning = useCallback(() => {
    if (earnIntervalRef.current) {
      clearInterval(earnIntervalRef.current);
      earnIntervalRef.current = null;
    }
    const earned = earnAccumRef.current;
    earnAccumRef.current = 0;
    if (earned > 0) {
      const { onEarnCoins: earnCoins } = latestRef.current;
      earnCoins && earnCoins(earned);
    }
    return earned;
  }, []);

  useEffect(() => () => {
    if (earnIntervalRef.current) clearInterval(earnIntervalRef.current);
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
    const { achievements: liveAchievements, onMarkAchievement: markAch } = latestRef.current;
    setBonusEndsAt(Date.now() + BONUS_MS);
    setBonusMultiplier(multiplier);
    setDoubleFlash(true);
    setDoubleFlashKey((k) => k + 1);
    if (!liveAchievements.watchAd) markAch && markAch('watchAd');
  }, []);

  const ndcFromLocation = (locationX, locationY) => ({
    x: (locationX / STAGE_SIZE) * 2 - 1,
    y: -((locationY / STAGE_SIZE) * 2 - 1),
  });

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
          Animated.timing(gestureHintOpacity, { toValue: 0, duration: 300, useNativeDriver: true }).start();
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
        holdStartRef.current = Date.now();
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
      <LinearGradient colors={squadGradients.homeBg.colors} start={squadGradients.homeBg.start} end={squadGradients.homeBg.end} style={styles.stageArea}>
        <View style={[styles.topLeft, { top: insets.top + 14 }]}>
          <Pressable onPress={onBack} style={styles.backButton} hitSlop={8}>
            <Text style={styles.backGlyph}>‹</Text>
          </Pressable>
          <CoinCounter ref={coinCounterRef} initial={coins} />
          {showFps && <FpsCounter />}
        </View>

        <Pressable onPress={openSettings} style={[styles.wheelButton, { top: insets.top + 14 }]} hitSlop={6}>
          <Animated.View style={{ transform: [{ rotate: wheelRotate }] }}>
            <MaterialIcons name="settings" size={20} color={squadColors.textMutedLavender} />
          </Animated.View>
        </Pressable>

        <SquishStage
          toy={toy}
          toyRef={toyRef}
          effectsRef={effectsRef}
          panHandlers={panResponder.panHandlers}
          onSquish={handleToySquish}
          onRelease={handleToyRelease}
          hintOpacity={gestureHintOpacity}
          squishAnim={gestureSquishAnim}
          rotateAnim={gestureRotateAnim}
          touchAnim={gestureTouchAnim}
          dentScale={dentScale}
          dentOutward={pokeOutward}
        />
      </LinearGradient>

      {bonusActive && <BonusBanner endsAt={bonusEndsAt} multiplier={bonusMultiplier} coinAnim={bonusCoinAnim} />}

      <View style={styles.bottomPanel}>
        <View style={styles.bottomRow}>
          <WatchAdButton multiplier={4} onRewardEarned={() => handleAdReward(4)} activeMultiplier={bonusActive ? bonusMultiplier : null} />
          <WatchAdButton multiplier={3} onRewardEarned={() => handleAdReward(3)} activeMultiplier={bonusActive ? bonusMultiplier : null} />
          <WatchAdButton multiplier={2} onRewardEarned={() => handleAdReward(2)} activeMultiplier={bonusActive ? bonusMultiplier : null} />
        </View>

        <View style={[styles.adSlot, { paddingBottom: insets.bottom }]}>
          <AdBanner />
        </View>
      </View>

      {doubleFlash && (
        <View style={styles.flashOverlay} pointerEvents="none">
          <PopIn key={doubleFlashKey} onFadeOutDone={() => setDoubleFlash(false)} style={styles.doubleFlashPop}>
            <Text style={styles.doubleFlashText} numberOfLines={1} adjustsFontSizeToFit>
              ×{bonusMultiplier} SQUISH POINTS!
            </Text>
          </PopIn>
        </View>
      )}

      {settingsOpen && (
        <SettingsModal
          onClose={closeSettings}
          squishSoundEnabled={squishSoundEnabled}
          onToggleSquishSound={onToggleSquishSound}
          coinSoundEnabled={coinSoundEnabled}
          onToggleCoinSound={onToggleCoinSound}
          releaseSoundEnabled={releaseSoundEnabled}
          onToggleReleaseSound={onToggleReleaseSound}
          showFps={showFps}
          onToggleShowFps={onToggleShowFps}
          pokeStrength={pokeStrength}
          onChangePokeStrength={onChangePokeStrength}
          pokeOutward={pokeOutward}
          onChangePokeOutward={onChangePokeOutward}
        />
      )}

      <PunishmentModal visible={punishOpen} onDismiss={dismissPunishment} />
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, backgroundColor: squadColors.bgDeepest },
  // Bottom panel no longer carries a tall hint list, so the stage claims
  // whatever's left instead of a fixed 70/30 split (see bottomPanel below).
  stageArea: { flex: 1, position: 'relative', alignItems: 'center', justifyContent: 'center' },
  topLeft: { position: 'absolute', left: 14, flexDirection: 'row', alignItems: 'center', gap: 8, zIndex: 3 },
  backButton: { width: 34, height: 34, borderRadius: 12, backgroundColor: '#241243cc', alignItems: 'center', justifyContent: 'center' },
  backGlyph: { color: '#fff', fontSize: 18, fontWeight: '800' },
  coinPill: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: 6,
    backgroundColor: '#241243cc',
    borderWidth: 1,
    borderColor: squadColors.panelBorder,
    borderRadius: 999,
    paddingHorizontal: 12,
    paddingVertical: 5,
  },
  coinDot: { width: 14, height: 14, borderRadius: 7, backgroundColor: squadColors.gold },
  coinPillText: { color: squadColors.gold, fontFamily: squadFonts.bodyExtraBold, fontSize: 13 },
  fpsPill: {
    backgroundColor: '#241243cc',
    borderWidth: 1,
    borderColor: squadColors.panelBorder,
    borderRadius: 999,
    paddingHorizontal: 10,
    paddingVertical: 5,
  },
  fpsText: { fontFamily: squadFonts.bodyExtraBold, fontSize: 12 },
  wheelButton: {
    position: 'absolute',
    right: 14,
    zIndex: 3,
    width: 42,
    height: 42,
    borderRadius: 14,
    backgroundColor: '#241243cc',
    alignItems: 'center',
    justifyContent: 'center',
  },
  stage: { width: STAGE_SIZE, height: STAGE_SIZE },
  ripple: {
    position: 'absolute',
    width: RIPPLE_MAX,
    height: RIPPLE_MAX,
    borderRadius: RIPPLE_MAX / 2,
    borderWidth: 2,
    borderColor: 'rgba(255,255,255,0.7)',
  },
  floatingCoin: { position: 'absolute', flexDirection: 'row', alignItems: 'center', gap: 4 },
  floatingCoinBadge: {
    width: FLOATING_COIN_SIZE,
    height: FLOATING_COIN_SIZE,
    borderRadius: FLOATING_COIN_SIZE / 2,
    overflow: 'hidden',
  },
  floatingCoinText: {
    fontFamily: squadFonts.headingExtraBold,
    fontSize: 16,
    color: squadColors.goldLight,
    textShadowColor: 'rgba(0,0,0,0.35)',
    textShadowRadius: 3,
  },
  settingsOverlay: {
    ...StyleSheet.absoluteFillObject,
    backgroundColor: 'rgba(10,4,25,0.78)',
    alignItems: 'center',
    justifyContent: 'center',
    padding: 24,
    zIndex: 40,
  },
  settingsCard: {
    width: '100%',
    maxWidth: 360,
    backgroundColor: squadColors.panelAlt,
    borderRadius: 22,
    borderWidth: 1.5,
    borderColor: squadColors.panelBorder,
    paddingHorizontal: 18,
    paddingTop: 16,
    paddingBottom: 20,
  },
  settingsHeader: { flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between' },
  settingsTitle: { fontFamily: squadFonts.headingExtraBold, fontSize: 20, letterSpacing: 1, color: squadColors.textWhite },
  settingsClose: {
    width: 32,
    height: 32,
    borderRadius: 16,
    backgroundColor: '#241243',
    alignItems: 'center',
    justifyContent: 'center',
  },
  settingsSection: {
    marginTop: 16,
    marginBottom: 4,
    color: squadColors.goldLight,
    fontFamily: squadFonts.bodyExtraBold,
    fontSize: 10,
    letterSpacing: 1.4,
  },
  settingsRow: { flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between', paddingVertical: 7 },
  settingsLabel: { color: squadColors.textLavender, fontFamily: squadFonts.bodyBold, fontSize: 13 },
  settingsLabelSpaced: { marginTop: 12 },
  settingsHint: { marginTop: 4, color: squadColors.textMutedLavender, fontFamily: squadFonts.bodyBold, fontSize: 10.5 },
  segmented: { flexDirection: 'row', gap: 6, marginTop: 8 },
  segment: {
    flex: 1,
    paddingVertical: 9,
    borderRadius: 10,
    borderWidth: 1,
    borderColor: squadColors.panelBorder,
    backgroundColor: '#241243',
    alignItems: 'center',
  },
  segmentActive: { backgroundColor: squadColors.goldAmber, borderColor: squadColors.goldAmber },
  segmentText: { color: squadColors.textWhite, fontFamily: squadFonts.bodyExtraBold, fontSize: 12.5 },
  segmentTextActive: { color: '#3a2400' },
  switchTrack: { width: 38, height: 22, borderRadius: 11, overflow: 'hidden' },
  switchKnob: { position: 'absolute', top: 2, width: 18, height: 18, borderRadius: 9, backgroundColor: '#fff' },
  bottomPanel: { backgroundColor: '#150a2e', borderTopWidth: 1, borderTopColor: squadColors.panelBorder },
  bottomRow: { flexDirection: 'row', alignItems: 'center', justifyContent: 'center', gap: 10, paddingHorizontal: 12, paddingVertical: 10 },
  gestureHint: { position: 'absolute', top: '52%', alignItems: 'center', gap: 6 },
  gestureHandWrap: { width: 46, height: 62, alignItems: 'center', justifyContent: 'center' },
  gestureSvg: { position: 'absolute' },
  gestureTouchRing: {
    position: 'absolute',
    top: -3,
    width: 26,
    height: 26,
    borderRadius: 13,
    borderWidth: 2,
    borderColor: 'rgba(255,255,255,0.85)',
  },
  gestureHintText: {
    color: '#ffffff',
    fontFamily: squadFonts.bodyExtraBold,
    fontSize: 9,
    letterSpacing: 1.1,
    textShadowColor: 'rgba(0,0,0,0.85)',
    textShadowRadius: 4,
    textShadowOffset: { width: 0, height: 1 },
  },
  adSlot: { alignItems: 'center' },
  bonusBar: { paddingHorizontal: 16, paddingVertical: 8, backgroundColor: squadColors.bgDeepest },
  bonusInner: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: 10,
    borderRadius: 16,
    paddingHorizontal: 12,
    paddingVertical: 8,
    borderWidth: 1.5,
    borderColor: squadColors.goldAmber,
    backgroundColor: '#2a1a08',
    overflow: 'hidden',
  },
  bonusCoin: {
    width: 30,
    height: 30,
    borderRadius: 15,
    overflow: 'hidden',
    alignItems: 'center',
    justifyContent: 'center',
  },
  // Kills Baloo's font padding so "×2" sits centred in the coin.
  bonusCoinText: {
    fontFamily: squadFonts.headingExtraBold,
    fontSize: 13,
    lineHeight: 30,
    width: 30,
    textAlign: 'center',
    color: '#5a3a00',
    includeFontPadding: false,
    textAlignVertical: 'center',
  },
  bonusBody: { flex: 1, gap: 5 },
  bonusTopRow: { flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between' },
  bonusLabel: { color: squadColors.goldLight, fontFamily: squadFonts.bodyExtraBold, fontSize: 9, letterSpacing: 1.4 },
  bonusTime: { fontFamily: squadFonts.headingExtraBold, fontSize: 16, color: squadColors.textWhite },
  bonusTrack: { height: 5, borderRadius: 3, backgroundColor: 'rgba(255,255,255,0.14)', overflow: 'hidden' },
  bonusFill: { height: '100%', borderRadius: 3, backgroundColor: squadColors.goldAmber },
  flashOverlay: {
    ...StyleSheet.absoluteFillObject,
    alignItems: 'center',
    justifyContent: 'center',
    paddingHorizontal: 20,
    zIndex: 32,
  },
  // Gives the flashed text a definite width to shrink-to-fit within (see
  // doubleFlashText's numberOfLines/adjustsFontSizeToFit) — without this the
  // Animated.View sizes to its content and there's nothing concrete for the
  // text to measure itself against, so it wraps to 2 lines instead of
  // shrinking to stay on 1.
  doubleFlashPop: { width: '100%' },
  doubleFlashText: {
    fontFamily: squadFonts.headingExtraBold,
    fontSize: 44,
    color: squadColors.goldLight,
    textShadowColor: 'rgba(255,183,3,0.9)',
    textShadowRadius: 24,
    textAlign: 'center',
  },

  punishOverlay: {
    ...StyleSheet.absoluteFillObject,
    backgroundColor: 'rgba(10,4,25,0.86)',
    alignItems: 'center',
    justifyContent: 'center',
    padding: 26,
    zIndex: 60,
  },
  punishCard: {
    width: '100%',
    maxWidth: 340,
    borderRadius: 24,
    borderWidth: 2,
    borderColor: squadColors.danger,
    backgroundColor: squadColors.panelAlt,
    paddingHorizontal: 24,
    paddingVertical: 28,
    alignItems: 'center',
  },
  punishEmoji: { fontSize: 44, marginBottom: 8 },
  punishTitle: {
    fontFamily: squadFonts.headingExtraBold,
    fontSize: 22,
    color: squadColors.danger,
    letterSpacing: 1,
    marginBottom: 10,
  },
  punishBody: {
    fontFamily: squadFonts.bodyBold,
    fontSize: 14,
    lineHeight: 20,
    color: squadColors.textLavender,
    textAlign: 'center',
    marginBottom: 22,
  },
  punishButton: {
    backgroundColor: squadColors.danger,
    borderRadius: 14,
    paddingVertical: 14,
    paddingHorizontal: 24,
    alignSelf: 'stretch',
    alignItems: 'center',
  },
  punishButtonDim: { opacity: 0.6 },
  punishButtonText: {
    fontFamily: squadFonts.headingExtraBold,
    fontSize: 15,
    letterSpacing: 1,
    color: '#ffffff',
  },
});
