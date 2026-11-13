import React, { memo, useEffect, useRef } from 'react';
import { Animated, Easing, StyleSheet, Text, View } from 'react-native';
import { BUTTON_VARIANTS, candyFonts } from '../../theme/candyTheme';
import CandyButton, { ButtonText } from '../candy/CandyButton';
import ShineSweep from '../candy/ShineSweep';
import { CoinIcon } from '../candy/Coin';

// Home's "MYSTERY BOX · 3/20 · FIND THE SECRET" button (v3 design): a pink
// candy bar that breathes, with a light streak sweeping across it, a little
// gift that keeps shaking, and a white price pill on the right with what the
// next box costs: ▶ VIDEO (one of today's two boxes), FREE (the same with
// Remove Ads), ⊙500 once today's are used, or READY for one already paid for.

const PINK = BUTTON_VARIANTS.pink;

function ShakingGift() {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const loop = Animated.loop(
      Animated.timing(t, {
        toValue: 1,
        duration: 1200,
        easing: Easing.bezier(0.42, 0, 0.58, 1),
        useNativeDriver: true,
      })
    );
    loop.start();
    return () => loop.stop();
  }, [t]);
  // boxShake
  const rotate = t.interpolate({
    inputRange: [0, 0.2, 0.45, 0.7, 1],
    outputRange: ['0deg', '-9deg', '8deg', '-4deg', '0deg'],
  });
  const scaleX = t.interpolate({
    inputRange: [0, 0.2, 0.45, 0.7, 1],
    outputRange: [1, 1.04, 0.97, 1, 1],
  });
  const scaleY = t.interpolate({
    inputRange: [0, 0.2, 0.45, 0.7, 1],
    outputRange: [1, 0.96, 1.04, 1, 1],
  });
  return (
    <Animated.View style={[styles.gift, { transform: [{ rotate }, { scaleX }, { scaleY }] }]}>
      <View style={styles.giftBase} />
      <View style={styles.giftLid} />
      <View style={styles.giftRibbon} />
      <View style={styles.giftBow} />
    </Animated.View>
  );
}

function VideoChip() {
  return (
    <View style={styles.videoRing}>
      <View style={styles.videoFace}>
        <View style={styles.videoPlay} />
      </View>
    </View>
  );
}

// `videos`: video badges to show; `coins`: show the coin before the price.
// `title`: MYSTERY BOX, or CHESTS on the squad economy (which opens the Shop).
function MysteryBoxBanner({ title = 'MYSTERY BOX', collectedLabel, priceLabel, videos = 0, coins = false, onPress }) {
  return (
    <View style={styles.wrap}>
      <CandyButton variant="pink" pulse="soft" onPress={onPress} style={styles.button} faceStyle={styles.face}>
        <ShineSweep />
        <View style={styles.row}>
          <ShakingGift />
          <View style={styles.texts}>
            <ButtonText ring={PINK.ring} size={19} style={styles.title}>
              {title}
            </ButtonText>
            <Text style={styles.sub} numberOfLines={1}>
              {collectedLabel}
            </Text>
          </View>
          <View style={styles.price}>
            {Array.from({ length: videos }, (_, i) => (
              <VideoChip key={i} />
            ))}
            {videos && coins ? <Text style={styles.plus}>+</Text> : null}
            {coins ? <CoinIcon size={13} /> : null}
            <Text style={styles.priceText}>{priceLabel}</Text>
          </View>
        </View>
      </CandyButton>
    </View>
  );
}

export default memo(MysteryBoxBanner);

const styles = StyleSheet.create({
  wrap: { alignItems: 'center', paddingTop: 2, paddingBottom: 10 },
  button: { width: '84%' },
  face: { paddingVertical: 6, paddingHorizontal: 12, alignItems: 'stretch' },
  row: { flexDirection: 'row', alignItems: 'center', gap: 10 },
  texts: { alignItems: 'flex-start', gap: 1, flexShrink: 1, minWidth: 0 },
  title: { letterSpacing: 0, lineHeight: 21 },
  sub: {
    color: '#ffffff',
    fontFamily: candyFonts.bodyBlack,
    fontSize: 9,
    letterSpacing: 1.2,
    includeFontPadding: false,
  },
  price: {
    marginLeft: 'auto',
    flexDirection: 'row',
    alignItems: 'center',
    gap: 3,
    backgroundColor: '#ffffff',
    borderWidth: 2.5,
    borderColor: '#6b3fa0',
    borderRadius: 999,
    paddingVertical: 4,
    paddingHorizontal: 8,
  },
  plus: { color: '#6b3fa0', fontFamily: candyFonts.bodyBlack, fontSize: 11, includeFontPadding: false, marginHorizontal: -1.5 },
  priceText: {
    color: '#4a1a73',
    fontFamily: candyFonts.bodyBlack,
    fontSize: 13,
    includeFontPadding: false,
  },
  gift: { width: 36, height: 32 },
  giftBase: {
    position: 'absolute',
    left: 2,
    right: 2,
    bottom: 0,
    height: 22,
    borderRadius: 6,
    backgroundColor: '#fff3b0',
    borderWidth: 2.5,
    borderColor: '#6b3fa0',
  },
  giftLid: {
    position: 'absolute',
    left: 0,
    right: 0,
    top: 4,
    height: 10,
    borderRadius: 5,
    backgroundColor: '#ffe066',
    borderWidth: 2.5,
    borderColor: '#6b3fa0',
  },
  giftRibbon: {
    position: 'absolute',
    left: 15,
    top: 4,
    bottom: 0,
    width: 6,
    backgroundColor: '#ff4fa3',
  },
  giftBow: {
    position: 'absolute',
    left: 10,
    top: -2,
    width: 16,
    height: 9,
    borderRadius: 8,
    borderWidth: 2.5,
    borderColor: '#6b3fa0',
    backgroundColor: '#ff8fcf',
  },
  videoRing: {
    width: 19,
    height: 15,
    borderRadius: 5.5,
    backgroundColor: '#9c4d06',
    padding: 1.5,
  },
  videoFace: {
    flex: 1,
    borderRadius: 4.5,
    borderWidth: 2,
    borderColor: '#ffffff',
    backgroundColor: '#f5b62a',
    alignItems: 'center',
    justifyContent: 'center',
  },
  videoPlay: {
    marginLeft: 2,
    width: 0,
    height: 0,
    borderTopWidth: 3,
    borderBottomWidth: 3,
    borderLeftWidth: 5,
    borderTopColor: 'transparent',
    borderBottomColor: 'transparent',
    borderLeftColor: '#ffffff',
  },
});
