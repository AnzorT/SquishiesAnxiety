import React, { useCallback, useEffect, useRef, useState } from 'react';
import { View, Text, Pressable, StyleSheet, Animated, Easing } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { RewardedAd, RewardedAdEventType, AdEventType } from 'react-native-google-mobile-ads';
import { REWARDED_AD_UNIT_ID } from '../firebase/ads';
import { squadGradients, squadColors, squadFonts } from '../theme/squadTheme';

// "Watch ad" CTA at the bottom of SquishScreen, restyled to match the prototype:
// a teal-outlined dark pill with a little "ad monitor" glyph (play triangle +
// film sprockets) and a "×2 / WATCH AD" label. It breathes (a slow scale pulse,
// the spec's `adBreathe`) and a light bar sweeps across it (`adSheen`). While a
// double-coins window is running it dims to a passive "×2 ACTIVE" state.
// A reward earned here opens SquishScreen's 60s ×2 window (see handleAdReward);
// this component only loads/shows a real rewarded ad and reports back.
export default function WatchAdButton({ onRewardEarned, disabled, bonusActive }) {
  const rewardedRef = useRef(null);
  const earnedRef = useRef(false);
  const [ready, setReady] = useState(false);
  const breatheAnim = useRef(new Animated.Value(0)).current;
  const sheenAnim = useRef(new Animated.Value(0)).current;

  useEffect(() => {
    const breathe = Animated.loop(
      Animated.sequence([
        Animated.timing(breatheAnim, { toValue: 1, duration: 1200, easing: Easing.inOut(Easing.ease), useNativeDriver: true }),
        Animated.timing(breatheAnim, { toValue: 0, duration: 1200, easing: Easing.inOut(Easing.ease), useNativeDriver: true }),
      ])
    );
    const sheen = Animated.loop(
      Animated.timing(sheenAnim, { toValue: 1, duration: 2800, easing: Easing.linear, useNativeDriver: true })
    );
    breathe.start();
    sheen.start();
    return () => {
      breathe.stop();
      sheen.stop();
    };
  }, [breatheAnim, sheenAnim]);

  useEffect(() => {
    let unsub = [];

    const load = () => {
      setReady(false);
      const rewarded = RewardedAd.createForAdRequest(REWARDED_AD_UNIT_ID);
      rewardedRef.current = rewarded;

      unsub = [
        rewarded.addAdEventListener(RewardedAdEventType.LOADED, () => setReady(true)),
        // Fires while the ad is still on screen — just flag it and pay out on CLOSED
        // so the double-coins flash animates in full once the app is visible again.
        rewarded.addAdEventListener(RewardedAdEventType.EARNED_REWARD, () => {
          earnedRef.current = true;
        }),
        rewarded.addAdEventListener(AdEventType.CLOSED, () => {
          setReady(false);
          if (earnedRef.current) {
            earnedRef.current = false;
            onRewardEarned && onRewardEarned();
          }
          load();
        }),
        rewarded.addAdEventListener(AdEventType.ERROR, () => setReady(false)),
      ];

      rewarded.load();
    };

    load();
    return () => unsub.forEach((fn) => fn());
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const handlePress = useCallback(() => {
    if (!ready || !rewardedRef.current) return;
    rewardedRef.current.show();
  }, [ready]);

  const isDisabled = !ready || disabled;
  const scale = breatheAnim.interpolate({ inputRange: [0, 1], outputRange: [1, 1.035] });
  // Sweep the light bar across in the first 60% of the loop, then hold it off
  // the right edge for the remaining 40% (the spec's `adSheen` timing).
  const sheenX = sheenAnim.interpolate({ inputRange: [0, 0.6, 1], outputRange: [-40, 150, 150] });

  return (
    <View style={styles.wrap}>
      <Animated.View style={{ transform: [{ scale }] }}>
        <Pressable onPress={handlePress} disabled={isDisabled} style={[styles.button, isDisabled && !bonusActive && styles.dim]}>
          <LinearGradient colors={['#2a1650', '#170c33']} start={{ x: 0, y: 0 }} end={{ x: 1, y: 1 }} style={StyleSheet.absoluteFillObject} />
          <Animated.View
            pointerEvents="none"
            style={[styles.sheen, { transform: [{ translateX: sheenX }, { skewX: '-20deg' }] }]}
          />

          <View style={styles.monitor}>
            <LinearGradient colors={['#22e0d0', '#0b8f83']} start={{ x: 0, y: 0 }} end={{ x: 1, y: 1 }} style={StyleSheet.absoluteFillObject} />
            <View style={[styles.sprockets, styles.sprocketsLeft]}>
              <View style={styles.sprocket} />
              <View style={styles.sprocket} />
              <View style={styles.sprocket} />
            </View>
            <View style={[styles.sprockets, styles.sprocketsRight]}>
              <View style={styles.sprocket} />
              <View style={styles.sprocket} />
              <View style={styles.sprocket} />
            </View>
            <View style={styles.monitorTriangle} />
          </View>

          <View style={styles.labelCol}>
            <View style={styles.labelTopRow}>
              <View style={styles.coinDot}>
                <LinearGradient
                  colors={squadGradients.goldDot.colors}
                  start={squadGradients.goldDot.start}
                  end={squadGradients.goldDot.end}
                  style={StyleSheet.absoluteFillObject}
                />
              </View>
              <Text style={styles.x2}>×2</Text>
            </View>
            <Text style={styles.subLabel}>{bonusActive ? 'ACTIVE' : 'WATCH AD'}</Text>
          </View>
        </Pressable>
      </Animated.View>
    </View>
  );
}

const styles = StyleSheet.create({
  wrap: { flexShrink: 0, alignItems: 'center', justifyContent: 'center' },
  button: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: 9,
    paddingLeft: 8,
    paddingRight: 12,
    paddingVertical: 7,
    borderRadius: 18,
    borderWidth: 1.5,
    borderColor: squadColors.teal,
    overflow: 'hidden',
    shadowColor: squadColors.teal,
    shadowOpacity: 0.28,
    shadowRadius: 12,
    shadowOffset: { width: 0, height: 8 },
    elevation: 8,
  },
  dim: { opacity: 0.5 },
  sheen: { position: 'absolute', top: 0, bottom: 0, width: 26, backgroundColor: 'rgba(255,255,255,0.16)' },
  monitor: {
    width: 44,
    height: 32,
    borderRadius: 9,
    overflow: 'hidden',
    alignItems: 'center',
    justifyContent: 'center',
  },
  sprockets: { position: 'absolute', top: 4, bottom: 4, width: 4, justifyContent: 'space-between' },
  sprocketsLeft: { left: 3 },
  sprocketsRight: { right: 3 },
  sprocket: { width: 4, height: 4, borderRadius: 1, backgroundColor: 'rgba(13,6,32,0.45)' },
  monitorTriangle: {
    width: 0,
    height: 0,
    marginLeft: 3,
    backgroundColor: 'transparent',
    borderStyle: 'solid',
    borderTopWidth: 8,
    borderBottomWidth: 8,
    borderLeftWidth: 13,
    borderTopColor: 'transparent',
    borderBottomColor: 'transparent',
    borderLeftColor: squadColors.bgDeepest,
  },
  labelCol: { alignItems: 'flex-start', gap: 2 },
  labelTopRow: { flexDirection: 'row', alignItems: 'center', gap: 4 },
  coinDot: { width: 16, height: 16, borderRadius: 8, overflow: 'hidden' },
  // "×2" rides high on Baloo's tall metrics, so nudge it down with a little
  // top padding to sit level with the coin.
  x2: {
    fontFamily: squadFonts.headingExtraBold,
    fontSize: 15,
    lineHeight: 16,
    paddingTop: 7,
    includeFontPadding: false,
    color: squadColors.gold,
  },
  subLabel: { color: squadColors.textLavender, fontFamily: squadFonts.bodyExtraBold, fontSize: 8, letterSpacing: 1.4 },
});
