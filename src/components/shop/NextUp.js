import React, { memo, useEffect, useRef } from 'react';
import { Animated, Easing, StyleSheet, Text, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Defs, RadialGradient, Rect, Stop } from 'react-native-svg';
import { BUTTON_VARIANTS, candyFonts, tierOf } from '../../theme/candyTheme';
import CandyButton, { ButtonText } from '../candy/CandyButton';
import { CandyProgress, RaysSpin, TierChip } from '../candy/Decor';
import CreatureToken from '../candy/Tokens';
import CreatureThumbnail from '../CreatureThumbnail';
import TutTarget from '../../tutorial/Target';
import ShadowText from '../candy/ShadowText';
import { GoldKey } from './Stall';
import { tokenPrice } from '../../economy';

// The Key Shop's "NEXT UP" banner (the design's storeFeatured, v3): the
// first creature you neither own nor hold a key for, jumping in front of
// slow rays under a gold ribbon, with its rarity, its tokens so far and the
// key's price — the same two ways to the key as on its shelf.

export const NEXT_UP_H = 176;
const RING = '#a0520a';
// the design's name: white, outlined in purple with a deeper drop
const NAME_OUTLINE = [
  [0, 3, '#6a1b9a'],
  [2, 0, '#6a1b9a'],
  [-2, 0, '#6a1b9a'],
  [0, -2, '#6a1b9a'],
];

// a sunny pink glow from the plush's side (the design's radial-gradient at 28% 50%)
const Glow = memo(function Glow({ width }) {
  const cx = width * 0.28;
  const cy = NEXT_UP_H / 2;
  const r = Math.hypot(width - cx, cy);
  return (
    <Svg width={width} height={NEXT_UP_H} style={StyleSheet.absoluteFill}>
      <Defs>
        <RadialGradient id="nextUpBg" cx={cx} cy={cy} r={r} gradientUnits="userSpaceOnUse">
          <Stop offset="0" stopColor="#fff9d6" />
          <Stop offset="0.4" stopColor="#ffd9f3" />
          <Stop offset="0.75" stopColor="#ff8fd8" />
          <Stop offset="1" stopColor="#c95cf0" />
        </RadialGradient>
      </Defs>
      <Rect x={0} y={0} width={width} height={NEXT_UP_H} fill="url(#nextUpBg)" />
    </Svg>
  );
});

// the plush bobbing up and down (the design's floatBg)
function Float({ children }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(t, { toValue: 1, duration: 1500, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
        Animated.timing(t, { toValue: 0, duration: 1500, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
      ])
    );
    loop.start();
    return () => loop.stop();
  }, [t]);
  return <Animated.View style={{ transform: [{ translateY: t.interpolate({ inputRange: [0, 1], outputRange: [0, -6] }) }] }}>{children}</Animated.View>;
}

function NextUp({ creature, width, have, moneyPrice, buying, onBuyNow, tut }) {
  const need = tokenPrice(creature.id);
  const ways = (
    <View style={styles.ways}>
      <View style={styles.keyRow}>
        <GoldKey width={27} />
        <Text style={styles.keyText}>Unlock key</Text>
      </View>
      <View style={styles.tokenRow}>
        <CreatureToken creature={creature} size={20} />
        <Text style={styles.tokenText}>{`${have.toLocaleString()}/${need.toLocaleString()}`}</Text>
        <CandyProgress pct={(have / need) * 100} height={10} ring="#a23ad8" style={{ flex: 1 }} />
      </View>
      <CandyButton variant="blue" size="xs" loading={buying} onPress={() => onBuyNow(creature)} style={{ alignSelf: 'flex-start' }}>
        <ButtonText ring={BUTTON_VARIANTS.blue.ring} size={14}>
          {`KEY · ${moneyPrice}`}
        </ButtonText>
      </CandyButton>
    </View>
  );
  return (
    <View style={[styles.ring, { width }]}>
      <View style={styles.rim}>
        <Glow width={width - 12} />
        <RaysSpin size={360} rayDeg={9} gapDeg={13} opacity={0.55} fadeStart={0.15} fadeEnd={0.65} style={{ left: (width - 12) * 0.28 - 180, top: NEXT_UP_H / 2 - 3 - 180 }} />
        <View style={styles.row}>
          <View style={styles.art}>
            <Float>
              <CreatureThumbnail creature={creature} size={112} mood="jump" />
            </Float>
          </View>
          <View style={styles.info}>
            <TierChip tier={tierOf(creature.id)} fontSize={10} />
            <ShadowText style={styles.name} shadows={NAME_OUTLINE} numberOfLines={1}>
              {creature.name}
            </ShadowText>
            {tut ? (
              <TutTarget name="key" style={{ alignSelf: 'stretch' }}>
                {ways}
              </TutTarget>
            ) : (
              ways
            )}
          </View>
        </View>
        <LinearGradient colors={['#fff7b0', '#ffd23a', '#ff9c0a']} locations={[0, 0.55, 1]} style={styles.ribbon} pointerEvents="none">
          <Text style={styles.ribbonText}>NEXT UP</Text>
        </LinearGradient>
      </View>
    </View>
  );
}

export default memo(NextUp);

const styles = StyleSheet.create({
  ring: { height: NEXT_UP_H, borderRadius: 26, padding: 3, backgroundColor: RING, shadowColor: '#320064', shadowOffset: { width: 0, height: 8 }, shadowOpacity: 0.4, shadowRadius: 10, elevation: 8 },
  rim: { flex: 1, borderRadius: 23, borderWidth: 3, borderColor: '#ffffff', overflow: 'hidden' },
  row: { flex: 1, flexDirection: 'row', alignItems: 'center' },
  art: { width: '46%', alignItems: 'center', justifyContent: 'center' },
  info: { flex: 1, minWidth: 0, paddingRight: 14, alignItems: 'flex-start', gap: 6 },
  name: { maxWidth: '100%', fontFamily: candyFonts.display, fontSize: 26, lineHeight: 30, color: '#ffffff' },
  ways: { alignSelf: 'stretch', gap: 5 },
  keyRow: { flexDirection: 'row', alignItems: 'center', gap: 6 },
  keyText: { fontFamily: candyFonts.bodyHeavy, fontSize: 12, color: '#6a1b9a' },
  tokenRow: { flexDirection: 'row', alignItems: 'center', gap: 5 },
  tokenText: { fontFamily: candyFonts.display, fontSize: 12, color: '#6a1b9a' },
  ribbon: { position: 'absolute', top: 12, left: -30, width: 120, paddingVertical: 3, alignItems: 'center', borderTopWidth: 2, borderBottomWidth: 2, borderColor: '#ffffff', transform: [{ rotate: '-35deg' }] },
  ribbonText: { fontFamily: candyFonts.display, fontSize: 11, letterSpacing: 1, color: '#7a3a00' },
});
