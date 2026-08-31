import React, { forwardRef, useEffect, useImperativeHandle, useRef } from 'react';
import { View, StyleSheet } from 'react-native';
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

// The 2D squish rig, used for every creature on the squish stage EXCEPT
// Glorp (id 0), which mounts the real Tripo3D mesh via SquishyToy.js.
//
// Instead of deforming a mesh, this wraps the exact 2D design art
// (CreatureThumbnail — the literal SVG port of Claude Design's
// Creature.dc.html) in a Reanimated layer and drives a soft-body "jelly"
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

// Extra viewBox room (in the SVG's 100-unit space) so antennae / flame / horns
// / tentacles / the silhouette glow don't get clipped at the stage edges. We
// scale the SVG up by the same factor so the *body* still fills `size` — only
// the previously-clipped overhang spills (harmlessly) past the touch box.
const ART_BLEED = 15;
const BLEED_SCALE = (100 + ART_BLEED * 2) / 100;

const SquishyToy2D = forwardRef(function SquishyToy2D({ creatureId = '0', size = 220, onSquish, onRelease }, ref) {
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
        { translateY: pressY.value * SHIFT_PX * 0.7 * p + (1 - scaleY) * size * 0.5 * pressY.value },
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
        <CreatureThumbnail
          creatureId={String(creatureId)}
          size={size * BLEED_SCALE}
          bleed={ART_BLEED}
          animate={false}
        />
      </Animated.View>
    </View>
  );
});

const styles = StyleSheet.create({
  stage: { alignItems: 'center', justifyContent: 'center' },
});

export default SquishyToy2D;
