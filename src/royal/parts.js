import React, { memo, useMemo, useState } from 'react';
import { Animated, Image, Pressable, StyleSheet, Text, View, useWindowDimensions } from 'react-native';
import Svg, { Circle, Defs, LinearGradient, Path, RadialGradient, Rect, Stop } from 'react-native-svg';
import ShadowText from '../components/candy/ShadowText';
import { LinearGradient as LGrad } from 'expo-linear-gradient';
import { COIN, GEM } from '../squad/currencyArt';
import { useKeyLoop } from '../components/idleLoop';
import Plaque from './Plaque';
import Lettering from './Lettering';
import { FONT, ICON, INK, ORB, PAGE, RIM, TX_W } from './theme';

// The rest of the menu's kit (main-menu.js): the jewel orb buttons, the coin / gem pills, the gold PLAY-style button,
// the full-screen page (background + header), and the Stage that scales the design's 393-tall units to the phone.

let UID = 0;
const fmt = (n) => (n == null ? '' : String(Math.round(n)).replace(/\B(?=(\d{3})+(?!\d))/g, ','));

// The design's units on the phone: the menu scales by k = screen height / 393 (main-menu.js layout()).
export function useK() {
  const { width, height } = useWindowDimensions();
  return Math.min(width, height) / 393;
}

// A landscape page in design units: 393 tall, as wide as the screen allows, scaled up to the phone (.mm-pg).
export function Stage({ children, style }) {
  const { width, height } = useWindowDimensions();
  const H = Math.min(width, height), W = Math.max(width, height), k = H / 393;
  return (
    <View style={[StyleSheet.absoluteFill, style]}>
      <View style={{ position: 'absolute', left: 0, top: 0, width: W / k, height: 393, transform: [{ scale: k }], transformOrigin: 'left top' }}>{children}</View>
    </View>
  );
}

// a 24 x 24 stroke icon with the menu's ink drop under it
export function Icon({ d, size = 20, color = '#ffffff', width = 2.5, drop = true }) {
  return (
    <Svg width={size} height={size} viewBox="0 0 24 24">
      {drop ? <Path d={d} stroke={INK} strokeWidth={width} fill="none" strokeLinecap="round" strokeLinejoin="round" translateY={1.4} /> : null}
      <Path d={d} stroke={color} strokeWidth={width} fill="none" strokeLinecap="round" strokeLinejoin="round" />
    </Svg>
  );
}

// The jewel orb (.mm-orb): 40 across, a 3 gold rim, the ink outline and lip. icon: an ICON key or a path.
export const Orb = memo(function Orb({ icon = 'back', size = 40, onPress, iconWidth = 3, style, children, disabled }) {
  const [id] = useState(() => 'orb' + ++UID);
  const d = ICON[icon] || icon;
  const ring = 1.6, lip = 3, rim = 3;
  return (
    <Pressable onPress={onPress} disabled={disabled} hitSlop={8} style={({ pressed }) => [{ width: size, height: size }, style, pressed && { transform: [{ translateY: 2 }] }]}>
      <View pointerEvents="none" style={{ position: 'absolute', left: -ring, top: -ring + lip, width: size + ring * 2, height: size + ring * 2, borderRadius: size, backgroundColor: INK }} />
      <View pointerEvents="none" style={{ position: 'absolute', left: -ring, top: -ring, width: size + ring * 2, height: size + ring * 2, borderRadius: size, backgroundColor: INK }} />
      <Svg width={size} height={size} style={StyleSheet.absoluteFill}>
        <Defs>
          <LinearGradient id={id + 'r'} x1="0" y1="0" x2="0" y2="1">
            {RIM.map(([o, c], i) => <Stop key={i} offset={o} stopColor={c} />)}
          </LinearGradient>
          <RadialGradient id={id + 'f'} cx="34%" cy="28%" rx="98%" ry="98%" fx="34%" fy="28%">
            {ORB.map(([o, c], i) => <Stop key={i} offset={o} stopColor={c} />)}
          </RadialGradient>
        </Defs>
        <Circle cx={size / 2} cy={size / 2} r={size / 2} fill={`url(#${id}r)`} />
        <Circle cx={size / 2} cy={size / 2} r={size / 2 - rim} fill={`url(#${id}f)`} />
      </Svg>
      <View pointerEvents="none" style={[StyleSheet.absoluteFill, styles.center]}>
        {children || <Icon d={d} size={size / 2} width={iconWidth} />}
      </View>
    </Pressable>
  );
});

// White text with the ink outline (.tx-w)
export function InkText({ children, size = 13.5, style, font = FONT.display, numberOfLines }) {
  return (
    <ShadowText style={[{ color: '#ffffff', fontFamily: font, fontSize: size, includeFontPadding: false }, style]} shadows={TX_W} numberOfLines={numberOfLines}>
      {children}
    </ShadowText>
  );
}

// The coin / gem pill (.mm-pill): a wood pill, the currency picture big over its left end (REDESIGN_V8, as the menu's).
export const Pill = memo(function Pill({ cur = 'coins', amount, onPress, style }) {
  return (
    <Plaque variant="vel" onPress={onPress} style={[styles.pill, style]}>
      <Image source={cur === 'gems' ? GEM[0] : COIN[0]} style={styles.pillImg} />
      <InkText size={13.5}>{fmt(amount)}</InkText>
    </Plaque>
  );
});

// A sweep of light across a button now and then (the menu's PLAY .sq-glint): 1.9 s off to the left, a 1 s sweep
// (ease in-out), 0.5 s off to the right, every 3.4 s. One native loop of keyframes (idleLoop.js), stopped while a
// screen covers this one; a loop(sequence) with delays was restarted from JS at every step.
const GLINT_MS = 3400, GLINT_A = 1900 / GLINT_MS, GLINT_B = 2900 / GLINT_MS;
const GLINT_STEPS = Array.from({ length: 9 }, (_, i) => i / 8);
const GLINT_AT = [0, ...GLINT_STEPS.map((s) => GLINT_A + (GLINT_B - GLINT_A) * s), 1];
const GLINT_K = [0, ...GLINT_STEPS.map((s) => (s < 0.5 ? 2 * s * s : 1 - 2 * (1 - s) * (1 - s))), 1];
function Glint({ width }) {
  const values = useMemo(() => GLINT_K.map((k) => -width * 0.5 + width * 1.8 * k), [width]);
  const translateX = useKeyLoop(GLINT_MS, { at: GLINT_AT, values });
  return (
    <View pointerEvents="none" style={[StyleSheet.absoluteFill, { overflow: 'hidden', borderRadius: 18 }]}>
      <Animated.View style={{ position: 'absolute', top: -10, bottom: -10, width: width * 0.26, transform: [{ translateX }, { skewX: '-18deg' }] }}>
        <Svg width="100%" height="100%">
          <Defs>
            <LinearGradient id="glintG" x1="0" y1="0" x2="1" y2="0">
              <Stop offset="0" stopColor="#ffffff" stopOpacity={0} />
              <Stop offset="0.5" stopColor="#ffffff" stopOpacity={0.8} />
              <Stop offset="1" stopColor="#ffffff" stopOpacity={0} />
            </LinearGradient>
          </Defs>
          <Rect x="0" y="0" width="100%" height="100%" fill="url(#glintG)" />
        </Svg>
      </Animated.View>
    </View>
  );
}

// The gold button (PLAY, CLAIM, CHOOSE …): a gold plaque with tips and the menu's white-and-brown lettering.
// variant 'vel' for the quiet one. glow: the pulsing halo (mmGlow); glint: the sweep of light.
export function Btn({ label, size = 20, width, height = 42, radius = 14, variant = 'gold', glow = false, glint = false, onPress, disabled, style, children, tips = true }) {
  return (
    <Plaque variant={variant} tips={tips} radius={radius} glow={glow} onPress={onPress} disabled={disabled} style={[{ width, height }, disabled && { opacity: 0.55 }, style]}>
      {glint && width ? <Glint width={width} /> : null}
      {children || <Lettering text={label} variant={variant === 'gold' ? 'whiteB' : 'white'} size={size} />}
    </Plaque>
  );
}

// The full-screen page's background (.mm-page2): a warm amber (REDESIGN_V8; was deep purple) and soft rays from above. A native gradient and one image (performance, 2026-11-14: it was a full-screen SVG, rendered in software each time a screen opened).
const RAYS = require('../../assets/royal/rays.png');
export const PageBg = memo(function PageBg({ style }) {
  return (
    <View pointerEvents="none" style={[StyleSheet.absoluteFill, { backgroundColor: '#d27c3e' }, style]}>
      <LGrad colors={PAGE.stops.map((x) => x[1])} locations={PAGE.stops.map((x) => x[0])} style={StyleSheet.absoluteFill} />
      <Image source={RAYS} resizeMode="stretch" style={StyleSheet.absoluteFill} fadeDuration={0} />
    </View>
  );
});

// REDESIGN_V9 (2026-11-16, the user): the Level Pass, Achievements, Characters and Shop stand on the wood the Game
// Park shows its games on (the game card's planks). One picture of the menu's CSS for it (webgame/tools/wood-bg.mjs),
// so the app's screens and the menu's pages match.
const WOOD = require('../../assets/royal/wood-bg.jpg');
export const WoodBg = memo(function WoodBg({ style }) {
  return (
    <View pointerEvents="none" style={[StyleSheet.absoluteFill, { backgroundColor: '#cf955a' }, style]}>
      {/* (width and height too: on web an Image without them takes the picture's own size) */}
      <Image source={WOOD} resizeMode="cover" style={[StyleSheet.absoluteFill, { width: '100%', height: '100%' }]} fadeDuration={0} />
    </View>
  );
});

// The page header (.mm-pgh): back orb, gold title, a note, then whatever goes on the right (pills).
export function PageHeader({ title, note, onBack, right, style }) {
  return (
    <View style={[styles.header, style]}>
      {onBack ? <Orb icon="back" onPress={onBack} /> : null}
      <Lettering text={title} variant="gold" size={30} />
      {note ? <Text style={styles.note} numberOfLines={1}>{note}</Text> : null}
      <View style={{ flex: 1 }} />
      {right}
    </View>
  );
}

const styles = StyleSheet.create({
  center: { alignItems: 'center', justifyContent: 'center' },
  pill: { height: 32, flexDirection: 'row', alignItems: 'center', paddingLeft: 32, paddingRight: 14 },
  pillImg: { position: 'absolute', left: -15, top: -6, width: 44, height: 44, resizeMode: 'contain' },
  header: { position: 'absolute', left: 16, right: 16, top: 12, height: 46, flexDirection: 'row', alignItems: 'center', gap: 12 },
  note: { fontFamily: FONT.body, fontSize: 11.5, color: '#fff6e2' },
});
