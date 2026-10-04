import React, { forwardRef, memo, useEffect, useImperativeHandle, useRef } from 'react';
import { View, Image, StyleSheet } from 'react-native';
import Animated, {
  cancelAnimation,
  useAnimatedStyle,
  useSharedValue,
  withRepeat,
  withSequence,
  withSpring,
  withTiming,
} from 'react-native-reanimated';
import CreatureThumbnail from './CreatureThumbnail';
import AssembleCreature from './AssembleCreature';

// The 2D squish rig: for a roster creature without a 3D model yet (the plush
// roster of 2026-10-03 ships as 2D art until its Tripo models exist —
// SquishyToy.js takes over as soon as the creature doc has a `modelUrl`), and
// for a custom creature — a player's photo (`imageUri`) or an assembled build
// (`build`).
//
// Instead of deforming a mesh, this wraps the 2D art (CreatureThumbnail's
// plush image) in a Reanimated layer and drives a soft-body "jelly"
// transform on it: press flattens the body and bulges it sideways, the
// squash leans + shifts toward the contact point, and release springs back
// with an overshoot wobble. A two-finger drag twists the whole toy, which
// then untwists on release like a plush.
//
// It exposes the SAME imperative handle as SquishyToy.js (pointerDown /
// pointerMove / pointerUp / orbit / endOrbit / cancelPoke) so SquishScreen
// can drive either one through the same PanResponder. pointerDown/Move take
// the same NDC-style args (x,y in -1..1, y up) the 3D rig uses.

const SQUASH_X = 0.2; // how much the body widens at full press
const SQUASH_Y = 0.26; // how much it flattens at full press
const LEAN_DEG = 14; // max skew toward the contact point
const SHIFT_PX = 26; // max translate toward the contact point

// A custom creature's photo / build reads ~20% larger than its touch box.
// Only the art scales up (it spills past the box) — the stage View, the
// PanResponder hit area and the NDC touch math in SquishScreen stay on the
// original `size`.
const ART_SCALE = 1.2;
// A roster creature's plush image: the 3D creatures span ~90% of the stage
// (MODEL_TUNING.visual in SquishyToy.js against the camera's view), and the
// plush image's sticker outline and shadow spill past its own box by
// 10-40%, so its box is 80% of the stage.
const PLUSH_BOX = 0.8;

// `imageUri` (a player's uploaded photo) or `build` (an assembled creature)
// swap out the roster art for a custom creature; the jelly transform is
// identical either way.
// Memoized so unrelated parent re-renders (coin counters, bonus timer, etc.)
// don't force this subtree to reconcile every tick.
const SquishyToy2D = memo(forwardRef(function SquishyToy2D({ creature, imageUri, build, size = 220, onSquish, onRelease }, ref) {
  const press = useSharedValue(0); // 0 rest .. 1 fully pressed
  const pressX = useSharedValue(0); // -0.5 .. 0.5 (contact offset from centre)
  const pressY = useSharedValue(0);
  const rot = useSharedValue(0); // two-finger twist, degrees
  const wobble = useSharedValue(0); // release jiggle, degrees
  const bounce = useSharedValue(0); // release scale pop
  const breathe = useSharedValue(0); // idle breathing

  const modeRef = useRef(null); // 'poke' | 'orbit' | null
  const holdStartRef = useRef(0);

  useEffect(() => {
    breathe.value = withRepeat(withTiming(1, { duration: 2200 }), -1, true);
    return () => cancelAnimation(breathe);
  }, [breathe]);

  const ndcToStage = (x, y) => ({
    // NDC (-1..1, y up) -> offset from centre (-0.5..0.5, y down)
    x: Math.max(-0.5, Math.min(0.5, x / 2)),
    y: Math.max(-0.5, Math.min(0.5, -y / 2)),
  });

  useImperativeHandle(
    ref,
    () => ({
      pointerDown: (ndcX, ndcY) => {
        const { x, y } = ndcToStage(ndcX, ndcY);
        cancelAnimation(wobble);
        cancelAnimation(bounce);
        wobble.value = 0;
        bounce.value = 0;
        pressX.value = x;
        pressY.value = y;
        modeRef.current = 'poke';
        holdStartRef.current = Date.now();
        // quick initial squash, then keep sinking in while held
        press.value = withSequence(
          withTiming(0.72, { duration: 110 }),
          withTiming(1, { duration: 1100 })
        );
        onSquish && onSquish();
      },
      pointerMove: (ndcX, ndcY) => {
        if (modeRef.current !== 'poke') return;
        const { x, y } = ndcToStage(ndcX, ndcY);
        pressX.value = withTiming(x, { duration: 90 });
        pressY.value = withTiming(y, { duration: 90 });
      },
      pointerUp: () => {
        if (modeRef.current !== 'poke') {
          modeRef.current = null;
          return { wasPoke: false, holdSeconds: 0 };
        }
        const holdSeconds = (Date.now() - holdStartRef.current) / 1000;
        modeRef.current = null;
        press.value = withSpring(0, { damping: 12, stiffness: 220, mass: 0.6 });
        const kick = (Math.random() - 0.5) * 10;
        wobble.value = withSequence(
          withTiming(kick, { duration: 80 }),
          withSpring(0, { damping: 3.5, stiffness: 130 })
        );
        bounce.value = withSequence(
          withTiming(0.06, { duration: 90 }),
          withSpring(0, { damping: 5, stiffness: 170 })
        );
        onRelease && onRelease(holdSeconds);
        return { wasPoke: true, holdSeconds };
      },
      orbit: (dxScreen) => {
        modeRef.current = 'orbit';
        rot.value = Math.max(-70, Math.min(70, rot.value + dxScreen * 0.5));
      },
      endOrbit: () => {
        modeRef.current = null;
        rot.value = withSpring(0, { damping: 6, stiffness: 90, mass: 0.8 });
      },
      cancelPoke: () => {
        if (modeRef.current === 'poke') modeRef.current = null;
        press.value = withTiming(0, { duration: 150 });
      },
    }),
    [press, pressX, pressY, rot, wobble, bounce, onSquish, onRelease]
  );

  const artSize = imageUri || build ? size * ART_SCALE : size * PLUSH_BOX;

  const animatedStyle = useAnimatedStyle(() => {
    const p = press.value;
    const br = (breathe.value - 0.5) * 0.024; // ±1.2% idle
    const scaleX = (1 + SQUASH_X * p + bounce.value) * (1 + br);
    const scaleY = (1 - SQUASH_Y * p + bounce.value) * (1 - br);
    return {
      transform: [
        // shift toward the finger, and drop as the body flattens so the
        // squash reads as anchored at the contact point rather than centred
        { translateX: pressX.value * SHIFT_PX * p },
        { translateY: pressY.value * SHIFT_PX * 0.7 * p + (1 - scaleY) * artSize * 0.5 * pressY.value },
        { rotateZ: `${rot.value + wobble.value}deg` },
        { skewX: `${pressX.value * LEAN_DEG * p}deg` },
        { scaleX },
        { scaleY },
      ],
    };
  });

  return (
    <View style={[styles.stage, { width: size, height: size }]} pointerEvents="none">
      <Animated.View style={animatedStyle}>
        {imageUri ? (
          <Image source={{ uri: imageUri }} style={{ width: artSize, height: artSize, borderRadius: artSize / 2 }} />
        ) : build ? (
          <AssembleCreature build={build} size={artSize} />
        ) : (
          <CreatureThumbnail creature={creature} size={artSize} animate={false} />
        )}
      </Animated.View>
    </View>
  );
}));

const styles = StyleSheet.create({
  stage: { alignItems: 'center', justifyContent: 'center' },
});

export default SquishyToy2D;
