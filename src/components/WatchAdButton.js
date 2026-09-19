import React, { useCallback, useEffect, useRef, useState } from 'react';
import { View, Text, Pressable, StyleSheet, Animated, Easing } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { RewardedAd, RewardedAdEventType, AdEventType } from 'react-native-google-mobile-ads';
import { REWARDED_AD_UNIT_ID } from '../firebase/ads';
import { squadGradients, squadColors, squadFonts } from '../theme/squadTheme';

// One "watch ad for a coin multiplier" CTA at the bottom of SquishScreen —
// there are three of these side by side (×2/×3/×4, see SquishScreen.js),
// each holding its own independently-loaded rewarded ad. A dark pill with a
// little "ad monitor" glyph (play triangle + film sprockets) and a
// "×N / WATCH AD" label. It breathes (a slow scale pulse) and a light bar
// sweeps across it, but ONLY while it's actually tappable — see `isStill`
// below. A reward earned here opens SquishScreen's 60s ×N window (see
// handleAdReward); this component only loads/shows a real rewarded ad and
// reports back.
//
// `activeMultiplier` is the multiplier currently running (or null) — shared
// across all three buttons, from SquishScreen. Only one bonus window can run
// at a time: whichever button isn't the active one is locked out entirely
// (greyed out, unpressable, no animation) until the active window's timer
// ends, regardless of whether that button's own ad happens to be loaded.
export default function WatchAdButton({ multiplier, onRewardEarned, activeMultiplier }) {
  const rewardedRef = useRef(null);
  const earnedRef = useRef(false);
  const [ready, setReady] = useState(false);
  const breatheAnim = useRef(new Animated.Value(0)).current;
  const sheenAnim = useRef(new Animated.Value(0)).current;

  const isThisActive = activeMultiplier === multiplier;
  const isLockedByOther = activeMultiplier != null && !isThisActive;
  // "Still": no ad ready yet, or another multiplier's window is running —
  // the two cases the button must go grey + unpressable + animation-frozen
  // for, treated identically. The active button itself keeps its own look
  // (the "ACTIVE" label below) rather than going grey.
  const isStill = !ready || isLockedByOther;
  const isDisabled = isStill || isThisActive;

  useEffect(() => {
    if (isStill) return undefined;
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
      // Reset so a re-render while still frozen doesn't briefly show a
      // mid-cycle pose from the last time it was animating.
      breatheAnim.setValue(0);
      sheenAnim.setValue(0);
    };
  }, [isStill, breatheAnim, sheenAnim]);

  useEffect(() => {
    let unsub = [];

    const load = () => {
      setReady(false);
      const rewarded = RewardedAd.createForAdRequest(REWARDED_AD_UNIT_ID);
      rewardedRef.current = rewarded;

      unsub = [
        rewarded.addAdEventListener(RewardedAdEventType.LOADED, () => setReady(true)),
        // Fires while the ad is still on screen — just flag it and pay out on CLOSED
        // so the coin-multiplier flash animates in full once the app is visible again.
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
    if (!ready || isDisabled || !rewardedRef.current) return;
    rewardedRef.current.show();
  }, [ready, isDisabled]);

  const scale = breatheAnim.interpolate({ inputRange: [0, 1], outputRange: [1, 1.035] });
  // Sweep the light bar across in the first 60% of the loop, then hold it off
  // the right edge for the remaining 40%.
  const sheenX = sheenAnim.interpolate({ inputRange: [0, 0.6, 1], outputRange: [-40, 150, 150] });

  return (
    <View style={styles.wrap}>
      <Animated.View style={{ transform: [{ scale }] }}>
        <Pressable onPress={handlePress} disabled={isDisabled} style={[styles.button, isStill && styles.dim]}>
          <LinearGradient colors={['#2a1650', '#170c33']} start={{ x: 0, y: 0 }} end={{ x: 1, y: 1 }} style={StyleSheet.absoluteFillObject} />
          <Animated.View
            pointerEvents="none"
            style={[styles.sheen, { transform: [{ translateX: sheenX }, { skewX: '-20deg' }] }]}
          />

          <View style={styles.monitor}>
            <LinearGradient colors={[squadColors.goldLight, squadColors.goldAmber]} start={{ x: 0, y: 0 }} end={{ x: 1, y: 1 }} style={StyleSheet.absoluteFillObject} />
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
              <Text style={styles.x2}>×{multiplier}</Text>
            </View>
            <Text style={styles.subLabel}>{isThisActive ? 'ACTIVE' : 'WATCH AD'}</Text>
          </View>
        </Pressable>
      </Animated.View>
    </View>
  );
}

const styles = StyleSheet.create({
  wrap: { flexShrink: 1, alignItems: 'center', justifyContent: 'center' },
  button: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: 6,
    paddingLeft: 6,
    paddingRight: 9,
    paddingVertical: 6,
    borderRadius: 16,
    borderWidth: 1.5,
    borderColor: squadColors.gold,
    overflow: 'hidden',
    shadowColor: squadColors.gold,
    shadowOpacity: 0.28,
    shadowRadius: 10,
    shadowOffset: { width: 0, height: 6 },
    elevation: 8,
  },
  dim: { opacity: 0.5 },
  sheen: { position: 'absolute', top: 0, bottom: 0, width: 22, backgroundColor: 'rgba(255,255,255,0.16)' },
  monitor: {
    width: 36,
    height: 26,
    borderRadius: 8,
    overflow: 'hidden',
    alignItems: 'center',
    justifyContent: 'center',
  },
  sprockets: { position: 'absolute', top: 3, bottom: 3, width: 3, justifyContent: 'space-between' },
  sprocketsLeft: { left: 2 },
  sprocketsRight: { right: 2 },
  sprocket: { width: 3, height: 3, borderRadius: 1, backgroundColor: 'rgba(13,6,32,0.45)' },
  monitorTriangle: {
    width: 0,
    height: 0,
    marginLeft: 2,
    backgroundColor: 'transparent',
    borderStyle: 'solid',
    borderTopWidth: 6,
    borderBottomWidth: 6,
    borderLeftWidth: 10,
    borderTopColor: 'transparent',
    borderBottomColor: 'transparent',
    borderLeftColor: squadColors.bgDeepest,
  },
  labelCol: { alignItems: 'flex-start', gap: 1 },
  labelTopRow: { flexDirection: 'row', alignItems: 'center', gap: 3 },
  coinDot: { width: 13, height: 13, borderRadius: 6.5, overflow: 'hidden' },
  // "×N" rides high on Baloo's tall metrics, so nudge it down with a little
  // top padding to sit level with the coin.
  x2: {
    fontFamily: squadFonts.headingExtraBold,
    fontSize: 13,
    lineHeight: 14,
    paddingTop: 6,
    includeFontPadding: false,
    color: squadColors.gold,
  },
  subLabel: { color: squadColors.textLavender, fontFamily: squadFonts.bodyExtraBold, fontSize: 7, letterSpacing: 1.1 },
});
