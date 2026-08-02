import React, { useEffect, useRef } from 'react';
import { View, StyleSheet, Animated, Easing } from 'react-native';

// Flat 2D illustration of a squishy buddy — mirrors the blob placeholder
// drawn in the "Cute Squishies" reference (body fill, soft highlight,
// dark eyes, pink nose), built from plain Views so it needs no image asset.
// The seal gets its own wider/flatter body plus two flippers. The cat keeps
// the round body but gets pointed ear triangles poking up past the crown,
// a face-mask tint, and two paws peeking out at the bottom. The glitter ball
// swaps the nose for a smile and gets a few white sparkle-dot accents. The
// cheese gets a rounded-square body (not a circle) plus dark hole dots, and
// shares the glitter ball's smile-instead-of-nose face.
//
// RN's borderRadius is a single value, so width != height + borderRadius =
// height/2 draws a "stadium" (straight sides, round caps) rather than a true
// ellipse. A true ellipse is a circle scaled non-uniformly, so the body here
// is a perfect circle stretched with `transform: scaleX` — that preserves
// the actual elliptical curve everywhere, not just at the ends. The content
// (highlight/spots/eyes/nose) is rendered as a separate, unscaled overlay on
// top so it doesn't get stretched along with the shape.
//
// Every model bobs up and down continuously (a looping translateY) so the
// shelf feels alive even before a card is opened. Duration is randomized a
// bit per mount so cards visible at the same time don't bob in lockstep.

export default function SquishyThumbnail({ colorHex, species, size = 180 }) {
  const eye = size * 0.07;
  const nose = size * 0.12;
  const isSeal = species === 'seal';
  const isCat = species === 'cat';
  const isSparkle = species === 'sparkle';
  const isCheese = species === 'cheese';
  const isSimpleFace = isSparkle || isCheese;
  const bodyWidth = isSeal ? size * 1.3 : size;
  const bodyHeight = isSeal ? size * 0.78 : size;
  const sidePadding = isSeal ? size * 0.14 : 0;
  // Room above/below the body for the cat's ears and paws to occupy. The
  // ears/paws are each sized taller than their padding strip so a chunk of
  // them overlaps into the head (drawn under the body layer, which then
  // covers that overlap) — without that overlap they read as floating
  // separately instead of attached to the head.
  const topPadding = isCat ? size * 0.16 : 0;
  const bottomPadding = isCat ? size * 0.14 : 0;

  const floatAnim = useRef(new Animated.Value(0)).current;
  const halfDuration = useRef(1400 + Math.random() * 400).current;

  useEffect(() => {
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(floatAnim, {
          toValue: 1,
          duration: halfDuration,
          easing: Easing.inOut(Easing.sin),
          useNativeDriver: true,
        }),
        Animated.timing(floatAnim, {
          toValue: 0,
          duration: halfDuration,
          easing: Easing.inOut(Easing.sin),
          useNativeDriver: true,
        }),
      ])
    );
    loop.start();
    return () => loop.stop();
  }, [floatAnim, halfDuration]);

  const translateY = floatAnim.interpolate({ inputRange: [0, 1], outputRange: [6, -6] });

  return (
    <Animated.View
      style={{
        width: bodyWidth + sidePadding * 2,
        height: bodyHeight + topPadding + bottomPadding,
        alignItems: 'center',
        justifyContent: 'flex-end',
        transform: [{ translateY }],
      }}
    >
      {isSeal && (
        <>
          <View
            style={[
              styles.flipper,
              {
                width: size * 0.22,
                height: size * 0.34,
                borderRadius: size * 0.14,
                top: bodyHeight * 0.42 + topPadding,
                left: 0,
                transform: [{ rotate: '18deg' }],
              },
            ]}
          />
          <View
            style={[
              styles.flipper,
              {
                width: size * 0.22,
                height: size * 0.34,
                borderRadius: size * 0.14,
                top: bodyHeight * 0.42 + topPadding,
                right: 0,
                transform: [{ rotate: '-18deg' }],
              },
            ]}
          />
        </>
      )}

      {isCat && (
        <>
          <View
            style={[
              styles.earTriangle,
              {
                borderLeftWidth: size * 0.1,
                borderRightWidth: size * 0.1,
                borderBottomWidth: size * 0.34,
                borderBottomColor: '#5B5750',
                top: 0,
                left: size * 0.22,
                transform: [{ rotate: '-14deg' }],
              },
            ]}
          />
          <View
            style={[
              styles.earTriangle,
              {
                borderLeftWidth: size * 0.1,
                borderRightWidth: size * 0.1,
                borderBottomWidth: size * 0.34,
                borderBottomColor: '#5B5750',
                top: 0,
                right: size * 0.22,
                transform: [{ rotate: '14deg' }],
              },
            ]}
          />
          <View
            style={[
              styles.paw,
              {
                width: size * 0.24,
                height: size * 0.22,
                borderRadius: size * 0.11,
                backgroundColor: colorHex,
                top: topPadding + bodyHeight - size * 0.09,
                left: size * 0.16,
              },
            ]}
          />
          <View
            style={[
              styles.paw,
              {
                width: size * 0.24,
                height: size * 0.22,
                borderRadius: size * 0.11,
                backgroundColor: colorHex,
                top: topPadding + bodyHeight - size * 0.09,
                right: size * 0.16,
              },
            ]}
          />
        </>
      )}

      {/* Shape layer: a true circle, stretched into a true ellipse — except
          the cheese, which is a plain rounded square (a cube read flat). */}
      <View
        style={{
          position: 'absolute',
          bottom: bottomPadding,
          width: bodyHeight,
          height: bodyHeight,
          borderRadius: isCheese ? size * 0.2 : bodyHeight / 2,
          backgroundColor: colorHex,
          transform: [{ scaleX: bodyWidth / bodyHeight }],
        }}
      />

      {/* Content layer: sits on top, unscaled, so features stay round. */}
      <View style={[styles.content, { width: bodyWidth, height: bodyHeight, bottom: bottomPadding }]}>
        <View
          style={[
            styles.highlight,
            {
              width: size * 0.34,
              height: size * 0.34,
              borderRadius: (size * 0.34) / 2,
              top: bodyHeight * 0.14,
              left: bodyWidth * 0.14,
            },
          ]}
        />
        {isSeal && (
          <>
            <View style={[styles.spot, { width: size * 0.16, height: size * 0.12, borderRadius: size * 0.08, top: bodyHeight * 0.18, left: bodyWidth * 0.62 }]} />
            <View style={[styles.spot, { width: size * 0.12, height: size * 0.1, borderRadius: size * 0.06, top: bodyHeight * 0.64, left: bodyWidth * 0.14 }]} />
            <View style={[styles.spot, { width: size * 0.1, height: size * 0.08, borderRadius: size * 0.05, top: bodyHeight * 0.7, left: bodyWidth * 0.56 }]} />
          </>
        )}
        {isCat && (
          <View
            style={[
              styles.mask,
              {
                width: bodyWidth * 0.78,
                height: bodyHeight * 0.62,
                borderRadius: bodyHeight * 0.31,
                top: bodyHeight * 0.02,
                left: bodyWidth * 0.11,
              },
            ]}
          />
        )}
        {isSparkle && (
          <>
            <View style={[styles.sparkleDot, { width: size * 0.05, height: size * 0.05, borderRadius: size * 0.025, top: bodyHeight * 0.2, left: bodyWidth * 0.64 }]} />
            <View style={[styles.sparkleDot, { width: size * 0.032, height: size * 0.032, borderRadius: size * 0.016, top: bodyHeight * 0.68, left: bodyWidth * 0.26 }]} />
            <View style={[styles.sparkleDot, { width: size * 0.04, height: size * 0.04, borderRadius: size * 0.02, top: bodyHeight * 0.3, left: bodyWidth * 0.2 }]} />
          </>
        )}
        {isCheese && (
          <>
            <View style={[styles.hole, { width: size * 0.16, height: size * 0.16, borderRadius: size * 0.08, top: bodyHeight * 0.16, left: bodyWidth * 0.6 }]} />
            <View style={[styles.hole, { width: size * 0.11, height: size * 0.11, borderRadius: size * 0.055, top: bodyHeight * 0.66, left: bodyWidth * 0.22 }]} />
            <View style={[styles.hole, { width: size * 0.13, height: size * 0.13, borderRadius: size * 0.065, top: bodyHeight * 0.62, left: bodyWidth * 0.64 }]} />
            <View style={[styles.hole, { width: size * 0.09, height: size * 0.09, borderRadius: size * 0.045, top: bodyHeight * 0.24, left: bodyWidth * 0.16 }]} />
          </>
        )}
        <View style={[styles.eyeRow, { top: bodyHeight * 0.42 }]}>
          <View style={[styles.eye, { width: eye, height: eye * 1.25, borderRadius: eye / 2, marginRight: size * 0.16 }]} />
          <View style={[styles.eye, { width: eye, height: eye * 1.25, borderRadius: eye / 2 }]} />
        </View>
        {isSimpleFace ? (
          // Smile — the bottom half of a circle. Clipping a full circle to a
          // half-height container (and shifting it up by that same half
          // height) leaves only its curved bottom edge visible, reading as a
          // simple "u" smile instead of the usual nose dot.
          <View style={[styles.mouthClip, { width: size * 0.22, height: size * 0.11, top: bodyHeight * 0.58 }]}>
            <View style={[styles.mouthCircle, { width: size * 0.22, height: size * 0.22, borderRadius: size * 0.11, top: -size * 0.11 }]} />
          </View>
        ) : (
          <View
            style={[
              styles.nose,
              {
                width: nose,
                height: nose,
                borderRadius: nose / 2,
                top: bodyHeight * 0.56,
                backgroundColor: isSeal ? '#2B2333' : isCat ? '#B98A82' : '#F4A6C0',
              },
            ]}
          />
        )}
      </View>
    </Animated.View>
  );
}

const styles = StyleSheet.create({
  content: { position: 'absolute', alignItems: 'center' },
  highlight: { position: 'absolute', backgroundColor: 'rgba(255,255,255,0.55)' },
  spot: { position: 'absolute', backgroundColor: 'rgba(50,60,64,0.35)' },
  mask: { position: 'absolute', backgroundColor: 'rgba(60,54,48,0.4)' },
  sparkleDot: { position: 'absolute', backgroundColor: '#FFFFFF' },
  hole: { position: 'absolute', backgroundColor: '#8B5A1F' },
  flipper: { position: 'absolute', backgroundColor: '#3F4B52' },
  paw: { position: 'absolute' },
  earTriangle: {
    position: 'absolute',
    width: 0,
    height: 0,
    backgroundColor: 'transparent',
    borderStyle: 'solid',
    borderLeftColor: 'transparent',
    borderRightColor: 'transparent',
  },
  mouthClip: { position: 'absolute', overflow: 'hidden' },
  mouthCircle: { position: 'absolute', backgroundColor: '#2B2333' },
  eyeRow: { position: 'absolute', flexDirection: 'row' },
  eye: { backgroundColor: '#2B2333' },
  nose: { position: 'absolute', backgroundColor: '#F4A6C0' },
});
