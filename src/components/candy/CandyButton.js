import React, { useEffect, useRef } from 'react';
import { Animated, Easing, Pressable, StyleSheet, Text, View, ActivityIndicator } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { BUTTON_VARIANTS, candyFonts } from '../../theme/candyTheme';
import ShadowText, { outline3 } from './ShadowText';
import sfx from '../../audio/sfx';

// The v3 "candy" button: a gradient face inside a white border, wrapped in a
// dark ring whose colour also forms a thick bottom lip, with a glossy shine
// across the top half. Pressing sinks the face onto the lip (the design's
// `style-active` translateY(4px)) — the lip is a separate layer behind the
// face, so the press is a pure native-driver transform.
//
// `variant`: pink | blue | gold | grey | purple (see BUTTON_VARIANTS).
// `pulse`: 'cta' (1→1.05, 1.6s), 'soft' (1→1.04, 1.6s) or false.
// `children` replaces the text label for custom content (icons, rows).

const SIZES = {
  lg: { padV: 14, padH: 40, font: 19, ring: 2.5, border: 3, lip: 5 },
  md: { padV: 11, padH: 24, font: 16, ring: 2.5, border: 3, lip: 5 },
  sm: { padV: 5, padH: 14, font: 13, ring: 2, border: 3, lip: 4 },
  xs: { padV: 3, padH: 11, font: 12, ring: 2, border: 2.5, lip: 3 },
  // Auth submit: padding 16px, 17px caption
  auth: { padV: 16, padH: 16, font: 17, ring: 2.5, border: 3, lip: 5 },
  // Key Shop rows: padding 8px 14px, 13px caption, 3px rim, 2.5px ring + lip
  shop: { padV: 8, padH: 14, font: 13, ring: 2.5, border: 3, lip: 4 },
};

const PULSES = {
  cta: { to: 1.05, half: 800 },
  soft: { to: 1.04, half: 800 },
};

// The glossy highlight across the top of every candy button/pill.
//
// It sits in its own full-size layer: React Native resolves an absolute
// child's percentage size against its parent's *content* box, so on a
// padded button face `height: 44%` came out as 44% of the caption's height —
// a thin floating strip. Measured against this padding-free layer the
// gloss is the design's 44% of the whole face. It also starts flush against
// the white rim (no strip of button colour above it) and, on buttons, pills
// and tabs, runs the full width of the face (the design insets it 9% a side,
// which read as too narrow); the face's own rounded clip shapes its ends.
// Round things (round buttons, coins, badges) pass an inset.
export function Shine({ radius = 999, inset = 0, height = '44%', top = 0 }) {
  return (
    <View pointerEvents="none" style={StyleSheet.absoluteFill}>
      <LinearGradient
        colors={['rgba(255,255,255,0.85)', 'rgba(255,255,255,0.1)']}
        style={{ position: 'absolute', left: inset, right: inset, top, height, borderRadius: radius }}
      />
    </View>
  );
}

export default function CandyButton({
  label,
  children,
  onPress,
  onPressIn,
  onPressOut,
  disabled = false,
  loading = false,
  variant = 'pink',
  size = 'md',
  radius = 999,
  pulse = false,
  dim = false,
  style,
  faceStyle,
  textStyle,
  hitSlop,
}) {
  const v = BUTTON_VARIANTS[variant] || BUTTON_VARIANTS.pink;
  const sz = SIZES[size] || SIZES.md;
  const press = useRef(new Animated.Value(0)).current;
  const pulseAnim = useRef(new Animated.Value(0)).current;

  const pulseSpec = pulse ? PULSES[pulse === true ? 'cta' : pulse] : null;
  useEffect(() => {
    if (!pulseSpec || disabled) return undefined;
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(pulseAnim, { toValue: 1, duration: pulseSpec.half, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
        Animated.timing(pulseAnim, { toValue: 0, duration: pulseSpec.half, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
      ])
    );
    loop.start();
    return () => {
      loop.stop();
      pulseAnim.setValue(0);
    };
  }, [pulseSpec, disabled, pulseAnim]);

  const sink = (to) => Animated.timing(press, { toValue: to, duration: 80, useNativeDriver: true }).start();

  const faceY = press.interpolate({ inputRange: [0, 1], outputRange: [0, sz.lip - 1] });
  const pressScale = press.interpolate({ inputRange: [0, 1], outputRange: [1, 0.97] });
  const pulseScale = pulseSpec ? pulseAnim.interpolate({ inputRange: [0, 1], outputRange: [1, pulseSpec.to] }) : 1;

  const outerR = radius;
  const innerR = Math.max(0, radius - sz.ring);
  const faceR = Math.max(0, innerR - sz.border);

  return (
    <Animated.View style={[{ transform: [{ scale: pulseScale }], opacity: dim ? 0.75 : 1 }, style]}>
      <Pressable
        onPress={onPress}
        onPressIn={(e) => {
          if (!disabled) {
            sink(1);
            sfx.play('tap');
          }
          onPressIn && onPressIn(e);
        }}
        onPressOut={(e) => {
          sink(0);
          onPressOut && onPressOut(e);
        }}
        disabled={disabled || loading}
        hitSlop={hitSlop}
      >
        <View style={{ paddingBottom: sz.lip }}>
          <View style={[StyleSheet.absoluteFill, { top: sz.lip, borderRadius: outerR, backgroundColor: v.ring }]} />
          <Animated.View
            style={[
              styles.shadow,
              { borderRadius: outerR, borderWidth: sz.ring, borderColor: v.ring, backgroundColor: v.ring },
              { transform: [{ translateY: faceY }, { scale: pressScale }] },
            ]}
          >
            <View style={{ borderRadius: innerR, borderWidth: sz.border, borderColor: '#ffffff', overflow: 'hidden' }}>
              <LinearGradient
                colors={v.colors}
                locations={v.locations}
                style={[styles.face, { borderRadius: faceR, paddingVertical: sz.padV, paddingHorizontal: sz.padH }, faceStyle]}
              >
                <Shine radius={radius >= 999 ? 999 : faceR} />
                {loading ? (
                  <ActivityIndicator color="#ffffff" />
                ) : children != null ? (
                  children
                ) : (
                  <ButtonText ring={v.ring} size={sz.font} style={textStyle}>
                    {label}
                  </ButtonText>
                )}
              </LinearGradient>
            </View>
          </Animated.View>
        </View>
      </Pressable>
    </Animated.View>
  );
}

// Non-interactive candy pill (card status rows like PLAY ▶ / LOCKED · GET
// KEY) — same look as a small CandyButton, for places where the whole card
// is already the tap target. `pulse` breathes it 1→1.04. Padding and letter
// spacing follow the design per use (PLAY ▶ 5/16 at 13px, the locked states
// 4/12 at 12px).
export function CandyPill({ variant = 'pink', label, pulse = false, halfMs = 800, fontSize, padV = 4, padH = 14, letterSpacing, style }) {
  const v = BUTTON_VARIANTS[variant] || BUTTON_VARIANTS.pink;
  const anim = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    if (!pulse) return undefined;
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(anim, { toValue: 1, duration: halfMs, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
        Animated.timing(anim, { toValue: 0, duration: halfMs, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
      ])
    );
    loop.start();
    return () => loop.stop();
  }, [pulse, halfMs, anim]);
  const scale = anim.interpolate({ inputRange: [0, 1], outputRange: [1, 1.04] });
  return (
    <Animated.View style={[{ transform: [{ scale }] }, style]}>
      <View style={[styles.pillLip, { backgroundColor: v.ring }]}>
        <View style={[styles.pillRing, { backgroundColor: v.ring }]}>
          <LinearGradient colors={v.colors} locations={v.locations} style={styles.pillFace}>
            <Shine />
            <View style={{ paddingVertical: padV, paddingHorizontal: padH }}>
              <ButtonText ring={v.ring} size={fontSize || (variant === 'blue' ? 13 : 12)} style={letterSpacing != null ? { letterSpacing } : null}>
                {label}
              </ButtonText>
            </View>
          </LinearGradient>
        </View>
      </View>
    </Animated.View>
  );
}

// White caption outlined in the button's ring colour — the design's
// `text-shadow: 0 2px 0 ring, 1px 0 0 ring, -1px 0 0 ring` on every button.
// Exposed for custom button content.
export function ButtonText({ children, ring = '#8e1580', size = 16, style, numberOfLines = 1 }) {
  return (
    <ShadowText style={[styles.label, { fontSize: size }, style]} shadows={outline3(ring)} numberOfLines={numberOfLines}>
      {children}
    </ShadowText>
  );
}

const styles = StyleSheet.create({
  shadow: {
    shadowColor: '#320064',
    shadowOffset: { width: 0, height: 8 },
    shadowOpacity: 0.45,
    shadowRadius: 10,
    elevation: 6,
  },
  face: { alignItems: 'center', justifyContent: 'center', overflow: 'hidden' },
  pillLip: { borderRadius: 999, paddingBottom: 4 },
  pillRing: { borderRadius: 999, padding: 2 },
  pillFace: { borderRadius: 999, borderWidth: 3, borderColor: '#ffffff', overflow: 'hidden' },
  label: {
    fontFamily: candyFonts.display,
    color: '#ffffff',
    letterSpacing: 1,
    includeFontPadding: false,
  },
});
