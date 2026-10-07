import React, { memo, useEffect, useRef } from 'react';
import { Animated, Easing, Image, Pressable, StyleSheet, Text, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { SvgXml } from 'react-native-svg';
import { candyFonts } from '../theme/candyTheme';
import ShadowText, { outline3 } from '../components/candy/ShadowText';
import CHEST_ART, { CHEST_BOX } from './chestArt';
import { COIN_SVG, GEM_SVG, STAR_SVG } from './icons';

// Small pieces shared by the squad screens (Shop, chest opener, Squishies),
// drawn from the 2026-10-06 design's CSS. Its "ring" look — a white border
// inside a coloured ring with a deeper lip under it (box-shadow: 0 0 0 Rpx C,
// 0 Lpx 0 Rpx C) — is <Ringed>.

export const F = {
  display: candyFonts.display, // Fredoka 700
  black: candyFonts.bodyBlack,
  heavy: candyFonts.bodyHeavy,
  bold: candyFonts.body,
};

export const GOLD = ['#fff7b0', '#ffd23a', '#ff9c0a'];
export const GOLD_RING = '#9c4d06';
export const PINK = ['#ffd6f4', '#ff5cc6', '#c02bd9'];
export const PINK_RING = '#8e1580';
export const BLUE = ['#d6f3ff', '#5fb8ff', '#2f7fd6'];
export const BLUE_RING = '#1d4f9a';
export const GREEN = ['#b8ffd9', '#3ddc97', '#16a86a'];
export const GREEN_RING = '#0d7a4a';

export const CoinIcon = memo(({ size = 19 }) => <SvgXml xml={COIN_SVG} width={size} height={size} />);
export const GemIcon = memo(({ size = 17 }) => <SvgXml xml={GEM_SVG} width={size} height={size} />);
export const StarIcon = memo(({ size = 17 }) => <SvgXml xml={STAR_SVG} width={size} height={size} />);
export const CurrencyIcon = ({ cur, size }) => (cur === 'gems' ? <GemIcon size={size} /> : cur === 'stars' ? <StarIcon size={size} /> : <CoinIcon size={size} />);

// The design's chest (tools/shop-art/render.mjs) at `size` px for its 240px
// box; the image carries extra room round it for the rays and glow.
export const Chest = memo(function Chest({ tier, stage = 0, size = 104, style }) {
  const k = size / 240;
  const box = CHEST_BOX * k;
  const pad = (box - size) / 2;
  const src = CHEST_ART[tier]?.[stage === 'burst' ? 5 : stage] ?? CHEST_ART.basic[0];
  return (
    <View style={[{ width: size, height: size }, style]} pointerEvents="none">
      <Image source={src} style={{ position: 'absolute', left: -pad, top: -pad, width: box, height: box }} fadeDuration={0} />
    </View>
  );
});

// shBob: up 7px and back, forever.
export function Bob({ children, ms = 2800, delay = 0, dy = 7, style }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(t, { toValue: 1, duration: ms / 2, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
        Animated.timing(t, { toValue: 0, duration: ms / 2, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
      ]),
    );
    const start = setTimeout(() => loop.start(), delay * 1000);
    return () => {
      clearTimeout(start);
      loop.stop();
    };
  }, [t, ms, delay]);
  const translateY = t.interpolate({ inputRange: [0, 1], outputRange: [0, -dy] });
  return <Animated.View style={[style, { transform: [{ translateY }] }]}>{children}</Animated.View>;
}

// A white-bordered shape in a coloured ring with a lip: `colors` fills it
// (a vertical gradient), or `bg` (a flat colour).
export function Ringed({ ring, lip = 4, ringW = 2.5, border = 3, radius = 999, colors, bg = '#ffffff', style, innerStyle, children }) {
  const inner = [{ borderRadius: radius, borderWidth: border, borderColor: '#ffffff', overflow: 'hidden' }, innerStyle];
  return (
    <View style={[{ borderRadius: radius + ringW, backgroundColor: ring, padding: ringW, paddingBottom: ringW + lip }, style]}>
      {colors ? (
        <LinearGradient colors={colors} locations={colors.length === 3 ? [0, 0.5, 1] : undefined} style={inner}>
          {children}
        </LinearGradient>
      ) : (
        <View style={[inner, { backgroundColor: bg }]}>{children}</View>
      )}
    </View>
  );
}

// The candy price/action buttons: gold (prices), pink, blue, green.
const BTN = { gold: [GOLD, GOLD_RING], pink: [PINK, PINK_RING], blue: [BLUE, BLUE_RING], green: [GREEN, GREEN_RING], purple: [['#efe6ff', '#b48bff', '#8f3cf2'], '#45189a'], cyan: [['#b0fbff', '#3fd7f6', '#1695d6'], '#0c5a9c'], grey: [['#e6dcf0', '#c9b9da', '#b9a6cc'], '#7a6a8c'] };
export function CandyBtn({ kind = 'gold', onPress, disabled, children, padV = 5, padH = 14, lip = 4, style, stretch }) {
  const [colors, ring] = BTN[kind];
  return (
    <Pressable onPress={onPress} disabled={disabled} style={({ pressed }) => [stretch && { alignSelf: 'stretch' }, style, pressed && { transform: [{ translateY: 3 }] }]}>
      <Ringed ring={ring} lip={lip} colors={colors} innerStyle={{ paddingVertical: padV, paddingHorizontal: padH, flexDirection: 'row', alignItems: 'center', justifyContent: 'center', gap: 5 }}>
        <View style={s.shine} pointerEvents="none" />
        {children}
      </Ringed>
    </Pressable>
  );
}

// Button caption: white Fredoka outlined in the button's ring colour.
export const BtnText = ({ children, ring = GOLD_RING, size = 16 }) => (
  <ShadowText style={{ fontFamily: F.display, fontSize: size, color: '#ffffff' }} shadows={outline3(ring, 2)}>
    {children}
  </ShadowText>
);

// A gold price button: an icon (coins, gems or Stars) and the amount.
export function PriceBtn({ cur, amount, was, onPress, disabled, size = 16, padH = 14 }) {
  return (
    <CandyBtn kind={disabled ? 'grey' : 'gold'} onPress={onPress} disabled={disabled} padH={padH} style={{ marginTop: 4 }}>
      {was != null && <Text style={{ fontFamily: F.heavy, fontSize: 10, color: GOLD_RING, textDecorationLine: 'line-through' }}>{was}</Text>}
      <CurrencyIcon cur={cur} size={size - 1} />
      <BtnText ring={disabled ? '#7a6a8c' : GOLD_RING} size={size}>
        {amount.toLocaleString('en-US')}
      </BtnText>
    </CandyBtn>
  );
}

// A small rounded label (DAILY DEAL, FREE, OPENS WITH TAP …).
export const Chip = ({ children, bg, color = '#ffffff', border = true, size = 9.5, style }) => (
  <View style={[{ alignSelf: 'flex-start', backgroundColor: bg, borderRadius: 999, paddingHorizontal: 7, paddingVertical: 1 }, border && { borderWidth: 2, borderColor: '#ffffff' }, style]}>
    <Text style={{ fontFamily: F.black, fontSize: size, letterSpacing: 1, color }}>{children}</Text>
  </View>
);

// "05:12:30"
export function hms(ms) {
  const sec = Math.max(0, Math.floor(ms / 1000));
  const p = (n) => String(n).padStart(2, '0');
  return `${p(Math.floor(sec / 3600))}:${p(Math.floor(sec / 60) % 60)}:${p(sec % 60)}`;
}
export const untilMidnight = (now = new Date()) => new Date(now.getFullYear(), now.getMonth(), now.getDate() + 1) - now;

const s = StyleSheet.create({
  shine: { position: 'absolute', left: '9%', right: '9%', top: 2, height: '42%', borderRadius: 999, backgroundColor: 'rgba(255,255,255,0.45)' },
});
