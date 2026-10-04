import React, { memo, useEffect, useMemo, useRef } from 'react';
import { View, Image, Animated, Easing, StyleSheet } from 'react-native';
import Svg, { Defs, ClipPath, RadialGradient, Stop, Path, G, Rect, Ellipse, Circle, SvgXml } from 'react-native-svg';

// Draws a creature from its Firestore catalog entry (`creatures/{id}`).
//
// The v3 art lives in `creature.plush`: images Chrome rendered from the
// design's own "Creature Plush" HTML/CSS (tools/plush-art/render.mjs),
// hosted in Firebase Storage (tools/plush-art/publish.js). One image per
// size class, because the design's shadows are fixed pixel sizes and a 26px
// creature really does look different from a 160px one:
//
//   plush.lg / lgLocked — Home card, Loading (design size 150-170)
//   plush.md / mdLocked — Achievements, Splash (design size 42-84)
//   plush.sm            — Key Shop (design size 26)
//
// Each variant is `{ url, frame: [x, y, w, h] }`; `frame` places the trimmed
// image relative to the creature's size×size box, in units of that box
// (shadows and accessories spill outside it). This component only adds what
// can't be baked into an image: the design's mood animation (creFloat,
// creJump, …) and the two creTwinkle sparkles.
//
// A catalog entry without `plush` falls back to its older baked `svg`.
//
// SquishScreen doesn't use this for the built-in creatures; it mounts the
// interactive 3D mesh (SquishyToy.js).

// `bleed` callers size the thumbnail with extra room around the creature
// (the old SVG art needed it for antennae, rings…): size = box * ratio.
const bleedRatio = (bleed) => (bleed > 0 ? (100 + bleed * 2) / 100 : 1);

export function pickPlushArt(creature, box, locked) {
  const p = creature && creature.plush;
  if (!p) return null;
  if (locked) return box >= 110 ? p.lgLocked || p.mdLocked : p.mdLocked || p.lgLocked;
  if (box >= 110) return p.lg || p.md;
  if (box >= 44) return p.md || p.lg;
  return p.sm || p.md;
}

// Every image URL in the catalog, for warming the image cache as soon as the
// catalog arrives (so paging through Home never waits on the network).
export function plushArtUrls(creatures = []) {
  const urls = [];
  creatures.forEach((c) => {
    const p = c && c.plush;
    if (!p) return;
    ['lg', 'lgLocked', 'md', 'mdLocked', 'sm'].forEach((k) => p[k] && p[k].url && urls.push(p[k].url));
  });
  return urls;
}

// ---- mood animation: the design's keyframes, 1:1 --------------------------
//
// [offset, translateY (% of size), scaleX, scaleY, rotate (deg)], each
// segment eased with the CSS `ease-in-out` curve, as `animation: … ease-in-out`
// does per keyframe segment.

const MOODS = {
  idle: {
    // creFloat
    dur: 2600,
    kf: [
      [0, 0, 1.04, 0.96, 0],
      [0.3, -6, 0.97, 1.03, -1.5],
      [0.55, -8, 1, 1, 0],
      [0.8, -2, 1.02, 0.98, 1],
      [1, 0, 1.04, 0.96, 0],
    ],
  },
  jump: {
    // creJump
    dur: 1100,
    kf: [
      [0, 0, 1, 1, 0],
      [0.15, 2, 1, 0.9, 0],
      [0.4, -26, 1, 1.08, 0],
      [0.6, 0, 1, 0.95, 0],
      [0.8, -4, 1, 1.02, 0],
      [1, 0, 1, 1, 0],
    ],
  },
  // creWobble
  wobble: { dur: 1700, kf: [[0, 0, 1, 1, -6], [0.5, 0, 1, 1, 6], [1, 0, 1, 1, -6]] },
  // creSleep
  sleep: { dur: 2600, kf: [[0, 0, 1.03, 0.97, 0], [0.5, -3, 0.98, 1.03, 0], [1, 0, 1.03, 0.97, 0]] },
  // creReady
  ready: { dur: 1100, kf: [[0, 0, 1, 1, 0], [0.5, 0, 1.06, 1.06, 0], [1, 0, 1, 1, 0]] },
  celebrate: {
    // creCelebrate, 3 times, then back to rest
    dur: 500,
    iterations: 3,
    kf: [
      [0, 0, 1, 1, 0],
      [0.25, -30, 1.1, 1.1, 0],
      [0.5, 0, 0.95, 0.95, 0],
      [0.75, -30, 1.1, 1.1, 0],
      [1, 0, 1, 1, 0],
    ],
  },
};

const CSS_EASE_IN_OUT = Easing.bezier(0.42, 0, 0.58, 1);
const SAMPLES = 60;

// Piecewise-linear stand-in for per-segment easing: dense samples of the
// eased curve, so the native driver can run it with a single interpolate.
function sampleMood(spec) {
  const input = [];
  const out = [[], [], [], []];
  const kf = spec.kf;
  for (let i = 0; i <= SAMPLES; i++) {
    const t = i / SAMPLES;
    let s = 0;
    while (s < kf.length - 2 && t > kf[s + 1][0]) s++;
    const a = kf[s];
    const b = kf[s + 1];
    const e = CSS_EASE_IN_OUT((t - a[0]) / (b[0] - a[0] || 1));
    input.push(t);
    for (let k = 0; k < 4; k++) out[k].push(a[k + 1] + (b[k + 1] - a[k + 1]) * e);
  }
  return { input, out };
}
const SAMPLED = Object.fromEntries(Object.entries(MOODS).map(([k, v]) => [k, sampleMood(v)]));

function useMoodTransform(mood, size, animate) {
  const key = MOODS[mood] ? mood : 'idle';
  const spec = MOODS[key];
  const t = useRef(new Animated.Value(0)).current;
  const resting = !animate;

  useEffect(() => {
    if (resting) return undefined;
    t.setValue(0);
    const once = Animated.timing(t, { toValue: 1, duration: spec.dur, easing: Easing.linear, useNativeDriver: true });
    const anim = Animated.loop(once, spec.iterations ? { iterations: spec.iterations } : undefined);
    anim.start(({ finished }) => {
      // A finite animation (celebrate) ends back at rest, like CSS without a
      // fill mode.
      if (finished && spec.iterations) t.setValue(0);
    });
    return () => anim.stop();
  }, [key, spec, t, resting]);

  return useMemo(() => {
    if (resting) return [];
    const { input, out } = SAMPLED[key];
    return [
      { translateY: t.interpolate({ inputRange: input, outputRange: out[0].map((v) => (v / 100) * size) }) },
      { scaleX: t.interpolate({ inputRange: input, outputRange: out[1] }) },
      { scaleY: t.interpolate({ inputRange: input, outputRange: out[2] }) },
      { rotate: t.interpolate({ inputRange: input, outputRange: out[3].map((v) => `${v}deg`) }) },
    ];
  }, [key, t, size, resting]);
}

// The component's two ✦ (creTwinkle: fade/grow in while turning 45°).
function CreatureSparkle({ size, color, delay, style }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(t, { toValue: 1, duration: 1100, easing: CSS_EASE_IN_OUT, useNativeDriver: true }),
        Animated.timing(t, { toValue: 0, duration: 1100, easing: CSS_EASE_IN_OUT, useNativeDriver: true }),
      ])
    );
    const start = setTimeout(() => loop.start(), delay);
    return () => {
      clearTimeout(start);
      loop.stop();
    };
  }, [t, delay]);
  return (
    <Animated.Text
      pointerEvents="none"
      renderToHardwareTextureAndroid
      style={[
        styles.sparkle,
        {
          fontSize: size,
          lineHeight: size * 1.05,
          color,
          opacity: t,
          transform: [
            { scale: t.interpolate({ inputRange: [0, 1], outputRange: [0.4, 1] }) },
            { rotate: t.interpolate({ inputRange: [0, 1], outputRange: ['0deg', '45deg'] }) },
          ],
        },
        style,
      ]}
    >
      ✦
    </Animated.Text>
  );
}

// A colour wash over the creature, standing in for the design's CSS filters
// (which React Native can't apply to an image): 'holo' cycles tinted copies
// of the art through the rainbow (the design's hue-rotate `holo`), 'gold'
// pulses a gold-tinted copy (its sepia `goldGlint`).
const HOLO_HUES = ['#ff5c8a', '#ffc233', '#5cf08a', '#3fd7f6', '#7c6cff', '#e25cff'];

function Wash({ kind, uri, style }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const anim =
      kind === 'holo'
        ? Animated.loop(Animated.timing(t, { toValue: 1, duration: 3000, easing: Easing.linear, useNativeDriver: true }))
        : Animated.loop(
            Animated.sequence([
              Animated.timing(t, { toValue: 1, duration: 1000, easing: CSS_EASE_IN_OUT, useNativeDriver: true }),
              Animated.timing(t, { toValue: 0, duration: 1000, easing: CSS_EASE_IN_OUT, useNativeDriver: true }),
            ])
          );
    anim.start();
    return () => anim.stop();
  }, [kind, t]);
  if (kind === 'gold') {
    const opacity = t.interpolate({ inputRange: [0, 1], outputRange: [0.35, 0.55] });
    return <Animated.Image source={{ uri }} fadeDuration={0} resizeMode="stretch" style={[style, { tintColor: '#ffb81f', opacity }]} />;
  }
  const n = HOLO_HUES.length;
  return HOLO_HUES.map((hue, i) => {
    // each hue peaks in turn; the last one fades back into the first
    const at = i / n;
    const input = i === 0 ? [0, 1 / n, (n - 1) / n, 1] : [at - 1 / n, at, at + 1 / n];
    const output = i === 0 ? [0.45, 0, 0, 0.45] : [0, 0.45, 0];
    const opacity = t.interpolate({ inputRange: input, outputRange: output, extrapolate: 'clamp' });
    return <Animated.Image key={hue} source={{ uri }} fadeDuration={0} resizeMode="stretch" style={[style, { tintColor: hue, opacity }]} />;
  });
}

function PlushCreature({ art, mood, size, box, locked, animate, wash }) {
  const transform = useMoodTransform(mood, box, animate);
  const [fx, fy, fw, fh] = art.frame;
  const inset = (size - box) / 2;
  const sparkles = !locked && box >= 60;
  const imageStyle = { position: 'absolute', left: fx * box, top: fy * box, width: fw * box, height: fh * box };
  return (
    <View style={{ width: size, height: size }} pointerEvents="none">
      <Animated.View style={{ position: 'absolute', left: inset, top: inset, width: box, height: box, transform }}>
        <Image source={{ uri: art.url }} fadeDuration={0} resizeMode="stretch" style={imageStyle} />
        {wash ? <Wash kind={wash} uri={art.url} style={imageStyle} /> : null}
        {sparkles ? (
          <>
            <CreatureSparkle size={Math.round(box * 0.13)} color="#ffffff" delay={0} style={{ position: 'absolute', right: '2%', top: '4%' }} />
            <CreatureSparkle size={Math.round(box * 0.09)} color="#fff6c0" delay={1100} style={{ position: 'absolute', left: '4%', bottom: '14%' }} />
          </>
        ) : null}
      </Animated.View>
    </View>
  );
}

// ---- fallback: the older baked-SVG catalog art ---------------------------

const W = 100; // the baked svg's own coordinate space
const NO_BLUSH_IDS = new Set(['1', '10', '15']);

function LegacyCreature({ creature, mood, size, box, locked, animate, bleed, glow, plush }) {
  const transform = useMoodTransform(mood, box, animate);
  if (!creature || !creature.svg) return <View style={{ width: size, height: size }} />;

  const gray = locked;
  const outlineD = creature.outline;
  const plushOn = plush && typeof outlineD === 'string' && outlineD.length > 0;
  const xml = gray ? creature.svgLocked || creature.svg : creature.svg;
  const bcx = creature.outlineCx ?? 50;
  const bcy = creature.outlineCy ?? 50;
  // react-native-svg always clips to the viewBox, so art that pokes outside
  // the 0-100 body box needs a wider viewBox (`bleed`).
  const viewBox = bleed > 0 ? `${-bleed} ${-bleed} ${W + bleed * 2} ${W + bleed * 2}` : `0 0 ${W} ${W}`;
  const unitsPerPx = (W + bleed * 2) / size;
  const stickerPx = Math.max(1, Math.round(size / 70));
  const showBlush = plushOn && !gray && size >= 40 && !NO_BLUSH_IDS.has(String(creature.id));
  const id = `legacy-${creature.id}`;

  return (
    <Animated.View style={{ width: size, height: size, opacity: locked ? 0.88 : 1, transform }} pointerEvents="none">
      {plushOn ? (
        <Svg width={size} height={size} viewBox={viewBox} style={StyleSheet.absoluteFill}>
          {glow && !gray ? (
            <G opacity={0.3}>
              {[[1.06, 0.25], [1.03, 0.35], [1.0, 0.45]].map(([s, op], i) => (
                <G key={`drop-${i}`} scale={s} originX={bcx} originY={bcy} y={stickerPx * 3 * unitsPerPx}>
                  <Path d={outlineD} fill="#5a0078" opacity={op} />
                </G>
              ))}
            </G>
          ) : null}
          <Path
            d={outlineD}
            fill={gray ? 'rgba(255,255,255,0.7)' : '#ffffff'}
            stroke={gray ? 'rgba(255,255,255,0.7)' : '#ffffff'}
            strokeWidth={(gray ? 2 : stickerPx) * 2 * unitsPerPx}
            strokeLinejoin="round"
          />
        </Svg>
      ) : null}
      <SvgXml xml={xml} width={size} height={size} viewBox={viewBox} style={StyleSheet.absoluteFill} />
      {plushOn ? (
        <Svg width={size} height={size} viewBox={viewBox} style={StyleSheet.absoluteFill}>
          <Defs>
            <ClipPath id={`${id}-clip`}>
              <Path d={outlineD} />
            </ClipPath>
            <RadialGradient id={`${id}-hi`} cx={bcx - 14} cy={bcy - 18} r={36} gradientUnits="userSpaceOnUse">
              <Stop offset="0" stopColor="#ffffff" stopOpacity={0.5} />
              <Stop offset="1" stopColor="#ffffff" stopOpacity={0} />
            </RadialGradient>
            <RadialGradient id={`${id}-gloss`} cx="50%" cy="50%" r="50%">
              <Stop offset="0" stopColor="#ffffff" stopOpacity={0.9} />
              <Stop offset="0.55" stopColor="#ffffff" stopOpacity={0.35} />
              <Stop offset="0.72" stopColor="#ffffff" stopOpacity={0} />
            </RadialGradient>
            <RadialGradient id={`${id}-blush`} cx="50%" cy="50%" r="50%">
              <Stop offset="0" stopColor="#ff69aa" stopOpacity={0.75} />
              <Stop offset="0.7" stopColor="#ff69aa" stopOpacity={0} />
            </RadialGradient>
          </Defs>
          <G clipPath={`url(#${id}-clip)`}>
            {gray ? (
              <Path d={outlineD} fill="#6a2fc0" opacity={0.42} />
            ) : (
              <>
                <Rect x={-bleed} y={-bleed} width={W + bleed * 2} height={W + bleed * 2} fill={`url(#${id}-hi)`} />
                <Ellipse cx={35} cy={22} rx={13} ry={7} fill={`url(#${id}-gloss)`} transform="rotate(-28 35 22)" />
                <Circle cx={65.5} cy={23.5} r={3.5} fill="#ffffff" opacity={0.75} />
                {showBlush ? (
                  <>
                    <Ellipse cx={25.5} cy={60} rx={8.5} ry={5} fill={`url(#${id}-blush)`} />
                    <Ellipse cx={74.5} cy={60} rx={8.5} ry={5} fill={`url(#${id}-blush)`} />
                  </>
                ) : null}
              </>
            )}
          </G>
        </Svg>
      ) : null}
    </Animated.View>
  );
}

// `size` is the thumbnail's footprint; with `bleed` the creature itself is
// drawn at size / ((100 + 2·bleed) / 100), centred, with room around it.
// `wash`: 'holo' | 'gold' — see Wash above (plush art only).
function CreatureThumbnail({ creature, mood = 'idle', size = 90, locked = false, animate = true, bleed = 0, glow = true, plush = true, wash = null }) {
  const box = size / bleedRatio(bleed);
  const art = pickPlushArt(creature, box, locked);
  if (art) return <PlushCreature art={art} mood={mood} size={size} box={box} locked={locked} animate={animate} wash={wash} />;
  return <LegacyCreature creature={creature} mood={mood} size={size} box={box} locked={locked} animate={animate} bleed={bleed} glow={glow} plush={plush} />;
}

export default memo(CreatureThumbnail);

const styles = StyleSheet.create({
  sparkle: {
    textShadowColor: '#ffc6ef',
    textShadowOffset: { width: 0, height: 0 },
    textShadowRadius: 8,
    includeFontPadding: false,
  },
});
