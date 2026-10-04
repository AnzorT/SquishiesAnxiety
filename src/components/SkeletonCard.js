import React, { useEffect, useRef, useState } from 'react';
import { Animated, Easing, StyleSheet, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { CandyCard } from './candy/Decor';
import { CARD_SIZE } from './CardPager';

// Stand-in card while a list's real cards are still being built: the card's
// frame with soft placeholder blocks and a white flash sweeping across it
// (the design's shineSweep), so switching lists never waits on content.

export default function SkeletonCard() {
  const [w, setW] = useState(0);
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(t, { toValue: 1, duration: 900, easing: Easing.inOut(Easing.quad), useNativeDriver: true }),
        Animated.delay(350),
        Animated.timing(t, { toValue: 0, duration: 0, useNativeDriver: true }),
      ])
    );
    loop.start();
    return () => loop.stop();
  }, [t]);
  const translateX = t.interpolate({ inputRange: [0, 1], outputRange: [-w * 0.7, w * 1.4] });

  return (
    <View style={CARD_SIZE} onLayout={(e) => setW(e.nativeEvent.layout.width)}>
      <CandyCard style={styles.fill}>
        <View style={styles.image}>
          <View style={styles.blob} />
          <View style={styles.pedestal} />
        </View>
        <View style={styles.info}>
          <View style={[styles.bar, { width: '46%', height: 18 }]} />
          <View style={[styles.bar, { width: '78%', height: 10, marginTop: 8 }]} />
          <View style={styles.row}>
            <View style={[styles.bar, { width: 70, height: 14 }]} />
            <View style={[styles.bar, { width: 92, height: 30, borderRadius: 999 }]} />
          </View>
        </View>
        {w > 0 ? (
          <Animated.View pointerEvents="none" style={[styles.flash, { width: w * 0.4, transform: [{ translateX }, { skewX: '-12deg' }] }]}>
            <LinearGradient
              colors={['rgba(255,255,255,0)', 'rgba(255,255,255,0.75)', 'rgba(255,255,255,0)']}
              start={{ x: 0, y: 0.5 }}
              end={{ x: 1, y: 0.5 }}
              style={StyleSheet.absoluteFill}
            />
          </Animated.View>
        ) : null}
      </CandyCard>
    </View>
  );
}

const styles = StyleSheet.create({
  fill: { flex: 1 },
  image: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
    backgroundColor: 'rgba(231,156,255,0.35)',
    borderTopLeftRadius: 24,
    borderTopRightRadius: 24,
    borderBottomLeftRadius: 16,
    borderBottomRightRadius: 16,
  },
  blob: { width: 120, height: 110, borderRadius: 60, backgroundColor: 'rgba(255,255,255,0.55)' },
  pedestal: { width: 170, height: 20, borderRadius: 999, marginTop: -8, backgroundColor: 'rgba(255,255,255,0.4)' },
  info: { paddingHorizontal: 14, paddingTop: 10, paddingBottom: 12 },
  bar: { borderRadius: 6, backgroundColor: 'rgba(162,58,216,0.16)' },
  row: { marginTop: 12, flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between' },
  flash: { position: 'absolute', top: -20, bottom: -20, left: 0 },
});
