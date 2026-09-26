import React, { useEffect, useRef } from 'react';
import { View, Animated, Easing } from 'react-native';
import Svg, { Defs, ClipPath, LinearGradient, Stop, Path, G, Rect, SvgXml } from 'react-native-svg';

const AnimatedRect = Animated.createAnimatedComponent(Rect);

// Renders a creature from server-supplied data (Firestore `creatures/{id}`:
// `svg` / `svgLocked` — full baked SVG markup for the normal and grayscale
// "locked" look — plus `outline`/`outlineCx`/`outlineCy`/`shadowColor`/
// `trueGlow`/`hasShine` used by the two *generic* runtime effects below).
// The per-creature art itself is opaque static markup (rendered via
// react-native-svg's `SvgXml`) — this component only supplies what has to
// stay dynamic: the mood bounce/wobble animation, the soft drop-shadow glow,
// and (now uniformly on every creature) the shine sweep.
//
// This is what every screen *except* SquishScreen shows (Splash floaters,
// the Home carousel card, Achievements badges, Store rows, the Loading
// screen). SquishScreen alone mounts the real interactive soft-body mesh
// (SquishyToy.js) — an unrelated, separately-designed 3D rig.

const W = 100; // viewBox units, matches the baked svg's own coordinate space

function hexToRgb(hex) {
  const n = parseInt(hex.slice(1), 16);
  return [(n >> 16) & 255, (n >> 8) & 255, n & 255];
}
function grayscaleDim(hex, brightness = 0.5) {
  const [r, g, b] = hexToRgb(hex);
  const gray = (0.299 * r + 0.587 * g + 0.114 * b) * brightness;
  const v = Math.round(Math.max(0, Math.min(255, gray)));
  return `rgb(${v},${v},${v})`;
}

// ---- mood animation (unchanged from the original hand-authored version —
// creature-independent, so it stays as shared code regardless of where the
// art itself comes from) ----

const MOOD_ANIM = {
  idle: { dur: 2.6, kf: [[0, 0, 1, 0], [0.5, -8, 1, -2], [1, 0, 1, 0]] },
  jump: { dur: 1.1, kf: [[0, 0, 1, 0], [0.15, 2, 0.9, 0], [0.4, -26, 1.08, 0], [0.6, 0, 0.95, 0], [0.8, -4, 1.02, 0], [1, 0, 1, 0]] },
  wobble: { dur: 1.7, kf: [[0, 0, 1, -6], [0.5, 0, 1, 6], [1, 0, 1, -6]] },
  sleep: { dur: 2.6, kf: [[0, 0, 1, 0], [0.5, -3, 1.02, 0], [1, 0, 1, 0]] },
  ready: { dur: 1.1, kf: [[0, 0, 1, 0], [0.5, 0, 1.06, 0], [1, 0, 1, 0]] },
  celebrate: { dur: 0.5, iterations: 3, kf: [[0, 0, 1, 0], [0.25, -30, 1.1, 0], [0.5, 0, 0.95, 0], [0.75, -30, 1.1, 0], [1, 0, 1, 0]] },
};

function useMoodAnimation(mood, size, animate = true) {
  const spec = MOOD_ANIM[mood] || MOOD_ANIM.idle;
  const progress = useRef(new Animated.Value(0)).current;

  useEffect(() => {
    if (!animate) {
      // Held still — e.g. a locked creature (see the `animate={unlocked}`
      // callers) or mounted inside SquishyToy2D, which drives its own
      // squash/wobble transform on a wrapper around this SVG.
      progress.setValue(0);
      return undefined;
    }
    progress.setValue(0);
    const single = Animated.timing(progress, {
      toValue: 1,
      duration: spec.dur * 1000,
      easing: Easing.inOut(Easing.sin),
      useNativeDriver: true,
    });
    const looped = spec.iterations ? Animated.loop(single, { iterations: spec.iterations }) : Animated.loop(single);
    looped.start();
    return () => looped.stop();
  }, [mood, progress, spec.dur, spec.iterations, animate]);

  const inputRange = spec.kf.map((k) => k[0]);
  const translateY = progress.interpolate({ inputRange, outputRange: spec.kf.map((k) => (k[1] / 100) * size) });
  const scale = progress.interpolate({ inputRange, outputRange: spec.kf.map((k) => k[2]) });
  const rotate = progress.interpolate({ inputRange, outputRange: spec.kf.map((k) => `${k[3]}deg`) });
  return { translateY, scale, rotate };
}

// ---- the component ------------------------------------------------------

// `bleed` (0 = off, >0 = on) lets bits of art that sit outside the 100x100
// body box — antennae, flame, horns, Noodle's tentacles, Cosmo's ring —
// spill past the nominal size instead of being clipped at the edges (see
// the `overflow` note below for how). Only the squish rig and a few
// close-up cards pass it; every other screen keeps the tight default
// framing.
export default function CreatureThumbnail({ creature, mood = 'idle', size = 90, locked = false, animate = true, bleed = 0, glow = true }) {
  const { translateY, scale, rotate } = useMoodAnimation(mood, size, animate);

  const gray = locked;
  const outlineD = creature && creature.outline;
  const hasOutline = typeof outlineD === 'string' && outlineD.length > 0;

  // --- shine sweep: a bright band that crosses the body, clipped to its
  // silhouette, then pauses off-frame before the next pass. Now uniform
  // across every creature (driven by `hasShine`), not just Glimmer/Pearla.
  // Every hook below must run on every render regardless of whether
  // `creature` data has arrived yet (Rules of Hooks) — the "no data" early
  // return has to come after all of them, not before.
  const hasShine = !!(creature && creature.hasShine) && hasOutline;
  const shimmer = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    if (!hasShine || !animate) return undefined;
    shimmer.setValue(0);
    const loop = Animated.loop(
      Animated.sequence([
        Animated.delay(1100),
        Animated.timing(shimmer, { toValue: 1, duration: 850, easing: Easing.in(Easing.quad), useNativeDriver: false }),
      ])
    );
    loop.start();
    return () => loop.stop();
  }, [hasShine, animate, shimmer]);
  const shimmerX = shimmer.interpolate({ inputRange: [0, 1], outputRange: [-W * 0.5, W * 1.05] });

  // No data yet (e.g. first-ever launch, before the creature catalog has
  // ever been cached — see SplashScreen) — an empty box, same footprint,
  // no crash.
  if (!creature || !creature.svg) {
    return <View style={{ width: size, height: size }} />;
  }

  const xml = gray ? creature.svgLocked || creature.svg : creature.svg;

  // --- the glow / drop-shadow around the body (generic — every creature
  // gets it, driven purely by its outline + shadow color) ---------------
  const glowColor = creature.shadowColor ? (gray ? grayscaleDim(creature.shadowColor) : creature.shadowColor) : null;
  const bcx = creature.outlineCx ?? 50;
  const bcy = creature.outlineCy ?? 50;
  const glowDy = creature.trueGlow ? 0 : 5;
  const glowLayers = creature.trueGlow
    ? [[1.24, 0.06], [1.19, 0.08], [1.15, 0.1], [1.11, 0.13], [1.08, 0.16], [1.05, 0.19], [1.02, 0.22]]
    : [[1.16, 0.06], [1.13, 0.08], [1.1, 0.11], [1.07, 0.14], [1.045, 0.17], [1.02, 0.2]];

  const clipId = `shineClip-${creature.id}`;
  const shineGradId = `shineGrad-${creature.id}`;
  // react-native-svg (checked v15.2.0's own source) never implements the
  // `overflow` SVG attribute at all — every <Svg>/<SvgXml> always clips its
  // rendering to its own viewBox rectangle, full stop. That's true no matter
  // what the markup says (the stored per-creature SVG already declares
  // overflow="visible", correctly, for a browser — it's just not honored
  // here) and no matter what any *outer* View's overflow style says, since
  // the clip happens one layer deeper, inside the SVG element's own native
  // rendering. So the only way to show art that sits outside the nominal
  // 0-100 body box (Glorp's antenna, Zappy's bolt, Cosmo's ring) is to
  // widen the viewBox itself. SvgXml's own root <Svg> is built from the
  // parsed string's attributes with any extra props (here, `viewBox`)
  // spread on top — passing one below overrides the string's baked-in
  // "0 0 100 100" without touching the stored data at all. All three layers
  // share the exact same viewBox so bleed lines up pixel-for-pixel.
  const viewBox = bleed > 0 ? `${-bleed} ${-bleed} ${W + bleed * 2} ${W + bleed * 2}` : `0 0 ${W} ${W}`;

  return (
    <Animated.View
      style={{
        width: size,
        height: size,
        alignItems: 'center',
        justifyContent: 'center',
        opacity: locked ? 0.88 : 1,
        transform: [{ translateY }, { scale }, { rotate }],
      }}
    >
      <View style={{ width: size, height: size }}>
        {glow && glowColor ? (
          <Svg width={size} height={size} viewBox={viewBox} style={{ position: 'absolute', top: 0, left: 0 }}>
            <G opacity={0.1}>
              {glowLayers.map(([s, op], i) => (
                <G key={`glow-${i}`} scale={s} originX={bcx} originY={bcy} y={glowDy}>
                  <Path d={outlineD} fill={glowColor} opacity={op} />
                </G>
              ))}
            </G>
          </Svg>
        ) : null}

        {/* The baked per-creature art — a self-contained "<svg viewBox='0 0
            100 100'>...</svg>" string. `viewBox` below overrides that to
            match the other two layers — see the note above. */}
        <SvgXml xml={xml} width={size} height={size} viewBox={viewBox} style={{ position: 'absolute', top: 0, left: 0 }} />

        {hasShine ? (
          <Svg width={size} height={size} viewBox={viewBox} style={{ position: 'absolute', top: 0, left: 0 }}>
            <Defs>
              <ClipPath id={clipId}>
                <Path d={outlineD} />
              </ClipPath>
              <LinearGradient id={shineGradId} x1="0%" y1="0%" x2="100%" y2="0%">
                <Stop offset="0%" stopColor="#ffffff" stopOpacity={0} />
                <Stop offset="50%" stopColor="#ffffff" stopOpacity={gray ? 0.35 : 0.75} />
                <Stop offset="100%" stopColor="#ffffff" stopOpacity={0} />
              </LinearGradient>
            </Defs>
            <G clipPath={`url(#${clipId})`}>
              <AnimatedRect x={shimmerX} y={-bleed - 6} width={W * 0.34} height={W + bleed * 2 + 12} fill={`url(#${shineGradId})`} opacity={0.9} />
            </G>
          </Svg>
        ) : null}
      </View>
    </Animated.View>
  );
}
