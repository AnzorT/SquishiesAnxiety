import React, { memo, useEffect, useMemo, useRef, useState } from 'react';
import { View, Image, Animated, Easing, StyleSheet } from 'react-native';
import { SvgXml } from 'react-native-svg';
import { FACE_FOR_MOOD, faceSvg, lidsSvg } from '../plush/faces';
import { runTrack, hashOf, CYCLE, CYCLE_STEP_MS } from '../plush/motion';
import { planMood } from '../plush/care';
import { FOODS } from '../crib/data';

// Draws a creature from its Firestore catalog entry (`creatures/{id}`).
//
// The plush roster's art lives in `creature.plush`: images Chrome rendered
// from the design's own SVGs with its sticker filter (tools/plush-art/
// render.mjs), hosted in Firebase Storage (tools/plush-art/publish.mjs). One
// image per size class, because the design's shadows and outline are fixed
// pixel sizes and a 30px creature really does look different from a 160px
// one:
//
//   plush.xl            — the squish stage (SquishyToy2D, ~340px)
//   plush.lg / lgLocked — Home card, Loading, box reveal (design 112-170)
//   plush.md / mdLocked — Achievements, Key Shop rows, Crib (design 72-84)
//   plush.sm            — tokens and other tiny spots (design 26-30)
//   plush.lgFace, lgLockedFace, mdFace, mdLockedFace — the same without the
//                         drawing's own eyes and mouth, for the mood faces
//
// Each variant is `{ url, frame: [x, y, w, h] }`; `frame` places the trimmed
// image relative to the creature's size×size box, in units of that box
// (shadows and accessories spill outside it). This component adds what can't
// be baked into an image, from the design's animation engine (plush-anim.js
// + squish-rig.js, see src/plush/): the mood's body motion, its face (drawn
// over the faceless image from the creature's `rig`), the blink while the
// drawing's own face shows, and the sparkles on the happy moods.
//
// SquishScreen doesn't use this for a creature with a 3D model; it mounts the
// interactive mesh (SquishyToy.js). Creatures without one squish in 2D with
// this art (SquishyToy2D.js).

// `bleed` callers size the thumbnail with extra room around the creature
// (the old SVG art needed it for antennae, rings…): size = box * ratio.
const bleedRatio = (bleed) => (bleed > 0 ? (100 + bleed * 2) / 100 : 1);

// The image for a creature shown `box` px big. `faceless` wants the variant
// without the drawing's eyes and mouth (null if the art has none).
export function pickPlushArt(creature, box, locked, faceless = false) {
  const p = creature && creature.plush;
  if (!p) return null;
  const xl = box >= 220 && !locked && !faceless;
  const cls = xl ? 'xl' : box >= 110 ? 'lg' : box >= 44 || locked || faceless ? 'md' : 'sm';
  const name = `${cls}${locked ? 'Locked' : ''}${faceless ? 'Face' : ''}`;
  if (faceless) return p[name] || null;
  return p[name] || p[`lg${locked ? 'Locked' : ''}`] || p[`md${locked ? 'Locked' : ''}`] || p.lg || null;
}

// Every image URL in the catalog, for warming the image cache as soon as the
// catalog arrives (so paging through Home never waits on the network).
export function plushArtUrls(creatures = []) {
  const urls = [];
  creatures.forEach((c) => {
    const p = c && c.plush;
    if (!p) return;
    Object.keys(p).forEach((k) => p[k] && p[k].url && urls.push(p[k].url));
  });
  return urls;
}

const CSS_EASE_IN_OUT = Easing.bezier(0.42, 0, 0.58, 1);

// ---- motion -----------------------------------------------------------------
//
// A mood's plan (src/plush/care.js) is a set of sampled tracks: the body's,
// the faces' opacities, the props' (sprites). Tracks with the same period
// and loop play off one Animated.Value, so everything stays in step. The
// body's tracks combine into one transform: ty/tx/rot add up, sy/scale/
// opacity multiply. The design pivots the body at 50% 90% (its feet).

const PIVOT_Y = 0.4; // 90% of the box, measured from its centre

const interp = (value, t, ch) => value.interpolate({ inputRange: t.input, outputRange: t.channels[ch] });
const sumOf = (parts, fallback) => (parts.length ? parts.reduce((a, b) => Animated.add(a, b)) : fallback);
const prodOf = (parts, fallback) => (parts.length ? parts.reduce((a, b) => Animated.multiply(a, b)) : fallback);
const isNode = (v) => typeof v !== 'number';
const times = (a, b) => (isNode(a) || isNode(b) ? Animated.multiply(a, b) : a * b);
const groupOf = (t) => `${t.period}|${t.loop ? 1 : 0}|${t.delay || 0}`;

// every track of a plan
function planTracks(plan) {
  if (!plan) return [];
  const out = [...plan.body];
  if (plan.face) {
    if (plan.face.cover) out.push(plan.face.cover);
    plan.face.layers.forEach((l) => l.op && out.push(l.op));
  }
  plan.sprites.forEach((s) => out.push(s.t));
  return out;
}

// One Animated.Value per timing group of the plan, playing: loops from the
// creature's own phase, a one-shot (a meal) from `plan.start`.
export function usePlanValues(plan, h) {
  const store = useRef(new Map()).current;
  const groups = useMemo(() => {
    const g = new Map();
    planTracks(plan).forEach((t) => {
      const k = groupOf(t);
      if (!g.has(k)) g.set(k, t);
    });
    return g;
  }, [plan]);
  const valueOf = (t) => {
    const k = groupOf(t);
    if (!store.has(k)) store.set(k, new Animated.Value(0));
    return store.get(k);
  };
  groups.forEach((t) => valueOf(t));
  useEffect(() => {
    let i = 0;
    const running = [];
    groups.forEach((t, k) => {
      const v = store.get(k);
      if (!t.loop && plan && plan.start) {
        v.setValue(plan.start);
        const a = Animated.timing(v, { toValue: 1, duration: t.period * (1 - plan.start), easing: Easing.linear, useNativeDriver: true });
        a.start();
        running.push(a);
      } else running.push(runTrack(v, t, { phase: t.loop && !t.delay ? ((h * 7919 + i * 131) % 1000) / 1000 : 0 }));
      i += 1;
    });
    return () => running.forEach((a) => a.stop());
  }, [groups, plan, h, store]);
  return valueOf;
}

function bodyStyle(tracks, valueOf, box) {
  if (!tracks.length) return { transform: [], opacity: 1 };
  const u = box / 150;
  const nodes = (ch) => tracks.map((t) => (t.channels[ch] ? interp(valueOf(t), t, ch) : null)).filter(Boolean);
  const ty = sumOf(nodes('ty'), 0);
  const tx = sumOf(nodes('tx'), 0);
  const rot = sumOf(nodes('rot'), 0);
  const sy = prodOf(nodes('sy'), 1);
  const scale = prodOf(nodes('scale'), 1);
  const opacity = prodOf(nodes('opacity'), 1);
  const puff = sumOf(nodes('puff'), 0);
  // the design's puff: the body widens as it flattens (sx = 1 + (1 - sy)·0.85),
  // plus a chomp's extra width
  let sx = isNode(sy) ? Animated.add(Animated.multiply(sy, -0.85), 1.85) : 1.85 - 0.85 * sy;
  if (isNode(puff)) sx = Animated.add(sx, puff);
  const rotate = isNode(rot) ? rot.interpolate({ inputRange: [-360, 360], outputRange: ['-360deg', '360deg'] }) : `${rot}deg`;
  const pivot = box * PIVOT_Y;
  return {
    opacity,
    transform: [{ translateX: times(tx, u) }, { translateY: times(ty, u) }, { translateY: pivot }, { rotate }, { scaleX: times(sx, scale) }, { scaleY: times(sy, scale) }, { translateY: -pivot }],
  };
}

// a mood's prop: a small picture moved by its track (box units → px)
export const Sprite = memo(function Sprite({ s, value, k }) {
  const style = useMemo(() => {
    const { ch, input } = s.t;
    const I = (c, mul = 1) => (typeof ch[c] === 'number' ? ch[c] * mul : value.interpolate({ inputRange: input, outputRange: ch[c].map((v) => v * mul) }));
    const rot = typeof ch.rot === 'number' ? `${ch.rot}deg` : value.interpolate({ inputRange: input, outputRange: ch.rot.map((v) => `${v}deg`) });
    const sc = I('scale');
    return {
      position: 'absolute',
      left: (-s.w / 2) * k,
      top: (-s.h / 2) * k,
      width: s.w * k,
      height: s.h * k,
      opacity: I('opacity'),
      transform: [{ translateX: I('x', k) }, { translateY: I('y', k) }, { rotate: rot }, { scaleX: times(sc, I('sx')) }, { scaleY: times(sc, I('sy')) }],
    };
  }, [s, value, k]);
  return (
    <Animated.View pointerEvents="none" style={style}>
      <SvgXml xml={s.xml} width={s.w * k} height={s.h * k} />
    </Animated.View>
  );
});

// the props that don't move on their own (they go with the body)
const Statics = memo(function Statics({ xml, box }) {
  const doc = useMemo(() => `<svg xmlns="http://www.w3.org/2000/svg" viewBox="-30 -40 160 160">${xml}</svg>`, [xml]);
  return (
    <View pointerEvents="none" style={{ position: 'absolute', left: -0.3 * box, top: -0.4 * box, width: 1.6 * box, height: 1.6 * box }}>
      <SvgXml xml={doc} width={1.6 * box} height={1.6 * box} />
    </View>
  );
});

// ---- the face ----------------------------------------------------------------

// A mood's face over the faceless body (static; one SVG per mood).
const Face = memo(function Face({ rig, faceKey, box, mouth = true }) {
  const xml = useMemo(() => faceSvg(rig, faceKey, { mouth }), [rig, faceKey, mouth]);
  return (
    <View style={[StyleSheet.absoluteFill, { width: box, height: box }]} pointerEvents="none">
      <SvgXml xml={xml} width={box} height={box} />
    </View>
  );
});

// The blink while the drawing's own face shows: lids in the patch's colour,
// down for 70 ms and up in 130 ms, every 2.4-5.6 s, sometimes twice.
const Blink = memo(function Blink({ rig, box, h }) {
  const xml = useMemo(() => lidsSvg(rig), [rig]);
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const down = Animated.timing(t, { toValue: 1, duration: 70, easing: CSS_EASE_IN_OUT, useNativeDriver: true });
    const up = Animated.timing(t, { toValue: 0, duration: 130, easing: CSS_EASE_IN_OUT, useNativeDriver: true });
    const blink = () => [down, up];
    // The pauses are native timings that hold 0, NOT Animated.delay: delay()
    // runs on the JS driver and counts as an "interaction", and a few dozen
    // of these looping would keep InteractionManager busy forever — and
    // FlatList (the Key Shop) only builds its rows between interactions.
    const hold = (ms) => Animated.timing(t, { toValue: 0, duration: ms, useNativeDriver: true });
    const wait = (k) => hold(2400 + ((h * 37 + k * 1009) % 3200));
    const loop = Animated.loop(Animated.sequence([wait(1), ...blink(), wait(2), ...blink(), hold(240), ...blink(), wait(3), ...blink()]));
    loop.start();
    return () => loop.stop();
  }, [t, h]);
  return (
    <Animated.View style={[StyleSheet.absoluteFill, { width: box, height: box, opacity: t }]} pointerEvents="none">
      <SvgXml xml={xml} width={box} height={box} />
    </Animated.View>
  );
});

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

// The design's "cycle" mood: idle, dance, idle, happy… 3 s each, each
// creature starting somewhere else in the round.
// (`list`, `step`: the round and how long each mood lasts; returns the mood
// and when it started)
function useCycle(on, h, list = CYCLE, step = CYCLE_STEP_MS) {
  const [s, setS] = useState(() => ({ i: h % list.length, since: Date.now() }));
  useEffect(() => {
    if (!on) return undefined;
    const iv = setInterval(() => setS((c) => ({ i: (c.i + 1) % list.length, since: Date.now() })), step);
    return () => clearInterval(iv);
  }, [on, list, step]);
  return { mood: list[s.i], since: s.since };
}

// The lists' mood (the user's): idle, dancing, eating — 4 s each. The snack
// is one of the Crib's foods, the creature's own (by its hash), eaten in 3 s
// with the full-tummy moment after.
const SHOWCASE = ['idle', 'dance', 'eat'];
const SHOWCASE_MS = 4000;
const SHOWCASE_EAT_MS = 3000;

const SPARKLE_MOODS = new Set(['celebrate', 'unlock', 'jump']);
// below this the props are too small to see
const MIN_PROPS_BOX = 40;

function PlushCreature({ creature, mood, size, box, locked, animate, wash, care, tint }) {
  const rig = creature.rig || null;
  const h = useMemo(() => hashOf(rig ? rig.key : creature.id), [rig, creature.id]);
  const cycle = useCycle(mood === 'cycle' && animate, h);
  const show = useCycle(mood === 'list' && animate, h, SHOWCASE, SHOWCASE_MS);
  const liveMood = mood === 'cycle' ? cycle.mood : mood === 'list' ? show.mood : mood;
  if (mood === 'list' && show.mood === 'eat') care = { food: FOODS[h % FOODS.length].k, eatStart: show.since, eatMs: SHOWCASE_EAT_MS };
  const ownArt = pickPlushArt(creature, box, locked);
  const facelessArt = animate && rig ? pickPlushArt(creature, box, locked, true) : null;
  const food = care && care.food;
  const eatStart = care && care.eatStart;
  const eatMs = care && care.eatMs;
  const bathStyle = care && care.bathStyle;
  const frame = ownArt ? ownArt.frame : null;
  const plan = useMemo(
    () => (animate ? planMood(liveMood, { h, rig, frame, food, eatStart, eatMs, bathStyle, now: Date.now() }) : null),
    [animate, liveMood, h, rig, frame, food, eatStart, eatMs, bathStyle]
  );
  const valueOf = usePlanValues(plan, h);
  const motion = useMemo(() => bodyStyle(plan ? plan.body : [], valueOf, box), [plan, box]); // eslint-disable-line react-hooks/exhaustive-deps

  // The face: the plan's, or the mood's one face over the faceless art, or
  // (a still creature, an idle one) the drawing's own with the blink.
  let face = plan && plan.face;
  if (!face) {
    const key = animate && rig ? (plan && plan.faceKey) || FACE_FOR_MOOD[liveMood] || null : null;
    face = key ? { own: false, cover: null, layers: [{ key, op: null }] } : { own: true, cover: null, layers: [] };
  }
  if (!facelessArt) face = { own: true, cover: null, layers: [] };
  const art = face.own ? ownArt : facelessArt;
  if (!art) return <View style={{ width: size, height: size }} />;

  const inset = (size - box) / 2;
  const props = !!plan && !locked && box >= MIN_PROPS_BOX;
  const sparkles = !locked && animate && box >= 60 && SPARKLE_MOODS.has(liveMood);
  const imageStyle = (a) => ({ position: 'absolute', left: a.frame[0] * box, top: a.frame[1] * box, width: a.frame[2] * box, height: a.frame[3] * box });
  const layers = face.layers.map((l) => (
    <Animated.View key={l.key} pointerEvents="none" style={[StyleSheet.absoluteFill, { width: box, height: box, opacity: l.op ? interp(valueOf(l.op), l.op, 'opacity') : 1 }]}>
      <Face rig={rig} faceKey={l.key} box={box} mouth={l.mouth !== false} />
    </Animated.View>
  ));
  return (
    <View style={{ width: size, height: size }} pointerEvents="none">
      <Animated.View style={{ position: 'absolute', left: inset, top: inset, width: box, height: box, transform: motion.transform, opacity: motion.opacity }}>
        <Image source={{ uri: art.url }} fadeDuration={0} resizeMode="stretch" style={imageStyle(art)} />
        {wash ? <Wash kind={wash} uri={art.url} style={imageStyle(art)} /> : null}
        {tint && tint[1] ? <Image source={{ uri: art.url }} fadeDuration={0} resizeMode="stretch" style={[imageStyle(art), { tintColor: tint[0], opacity: tint[1] }]} /> : null}
        {face.own && animate && rig && !locked ? <Blink rig={rig} box={box} h={h} /> : null}
        {face.own && face.layers.length ? (
          <Animated.View pointerEvents="none" style={[StyleSheet.absoluteFill, { width: box, height: box, opacity: face.cover ? interp(valueOf(face.cover), face.cover, 'opacity') : 1 }]}>
            <Image source={{ uri: facelessArt.url }} fadeDuration={0} resizeMode="stretch" style={imageStyle(facelessArt)} />
            {layers}
          </Animated.View>
        ) : (
          layers
        )}
        {props && plan.statics ? <Statics xml={plan.statics} box={box} /> : null}
        {props ? plan.sprites.map((sp, i) => <Sprite key={i} s={sp} value={valueOf(sp.t)} k={box / 100} />) : null}
      </Animated.View>
      {sparkles ? (
        <>
          <CreatureSparkle size={Math.round(box * 0.13)} color="#ffffff" delay={0} style={{ position: 'absolute', right: '2%', top: '4%' }} />
          <CreatureSparkle size={Math.round(box * 0.09)} color="#fff6c0" delay={1100} style={{ position: 'absolute', left: '4%', bottom: '14%' }} />
        </>
      ) : null}
    </View>
  );
}

// (`list`: idle → dance → eat, 4 s each — Home's creature cards)
// `size` is the thumbnail's footprint; with `bleed` the creature itself is
// drawn at size / ((100 + 2·bleed) / 100), centred, with room around it.
// `mood`: idle | sleep | happy | dance | clean | spin | sad | reveal |
// celebrate | ready | jump | wobble | cycle, and the Crib's eat | bath |
// dirty | tv (the design's names; see src/plush/). `care`: what the Crib's
// moods need — { food, eatStart, eatMs } for eat, { bathStyle } for bath.
// `wash`: 'holo' | 'gold' — see Wash above. `tint`: [colour, alpha], a
// colour laid over the creature (the Crib's care states).
function CreatureThumbnail({ creature, mood = 'idle', size = 90, locked = false, animate = true, bleed = 0, wash = null, care = null, tint = null }) {
  const box = size / bleedRatio(bleed);
  if (!creature) return <View style={{ width: size, height: size }} />;
  return <PlushCreature creature={creature} mood={mood} size={size} box={box} locked={locked} animate={animate} wash={wash} care={care} tint={tint} />;
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
