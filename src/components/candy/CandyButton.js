import React, { useEffect, useRef } from 'react';
import { Animated, Easing, Pressable, StyleSheet, Text, View, ActivityIndicator } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { BUTTON_VARIANTS, candyFonts } from '../../theme/candyTheme';

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
};

const PULSES = {
  cta: { to: 1.05, half: 800 },
  soft: { to: 1.04, half: 800 },
};

export function Shine({ radius = 999, inset = '9%', height = '44%', top = 3 }) {
  return (
    <LinearGradient
      pointerEvents="none"
      colors={['rgba(255,255,255,0.85)', 'rgba(255,255,255,0.1)']}
      style={{ position: 'absolute', left: inset, right: inset, top, height, borderRadius: radius }}
    />
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
          if (!disabled) sink(1);
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
                  <Text
                    style={[
                      styles.label,
                      { fontSize: sz.font, textShadowColor: v.ring },
                      textStyle,
                    ]}
                    numberOfLines={1}
                  >
                    {label}
                  </Text>
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
// is already the tap target. `pulse` breathes it 1→1.04.
export function CandyPill({ variant = 'pink', label, pulse = false, halfMs = 800, fontSize, style }) {
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
            <ButtonText ring={v.ring} size={fontSize || (variant === 'blue' ? 13 : 12)}>
              {label}
            </ButtonText>
          </LinearGradient>
        </View>
      </View>
    </Animated.View>
  );
}

// White label with the ring-coloured hard drop the design puts on every
// button caption. Exposed for custom button content.
export function ButtonText({ children, ring = '#8e1580', size = 16, style, numberOfLines = 1 }) {
  return (
    <Text style={[styles.label, { fontSize: size, textShadowColor: ring }, style]} numberOfLines={numberOfLines}>
      {children}
    </Text>
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
  pillFace: { borderRadius: 999, borderWidth: 3, borderColor: '#ffffff', paddingHorizontal: 14, paddingVertical: 4, overflow: 'hidden' },
  label: {
    fontFamily: candyFonts.display,
    color: '#ffffff',
    letterSpacing: 1,
    textShadowOffset: { width: 0, height: 2 },
    textShadowRadius: 1,
    includeFontPadding: false,
  },
});
