import React, { useCallback, useEffect, useRef, useState } from 'react';
import { View, Pressable, StyleSheet, Animated, Easing, ActivityIndicator } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { RewardedAd, RewardedAdEventType, AdEventType } from 'react-native-google-mobile-ads';
import { REWARDED_AD_UNIT_ID } from '../firebase/ads';
import { squadGradients, squadColors } from '../theme/squadTheme';

// Circular "watch ad" CTA at the bottom of SquishScreen, matching the design
// spec exactly: a 64px teal-gradient circle with a dark play triangle and a
// pulsing pink glow ring (the spec's `pulseGlow` keyframe — pink, even
// though the button itself is teal; that's how the source draws it). A
// reward earned here doubles the player's current coin total outright (see
// SquishScreen's handleAdReward), not a timed multiplier window like the
// previous build had — so unlike that version, this component has no boost
// countdown state of its own; it just loads/shows a real rewarded ad and
// reports back once one is earned.
export default function WatchAdButton({ onRewardEarned, disabled }) {
  const rewardedRef = useRef(null);
  const [ready, setReady] = useState(false);
  const glowAnim = useRef(new Animated.Value(0)).current;

  useEffect(() => {
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(glowAnim, { toValue: 1, duration: 900, easing: Easing.out(Easing.ease), useNativeDriver: true }),
        Animated.timing(glowAnim, { toValue: 0, duration: 900, easing: Easing.in(Easing.ease), useNativeDriver: true }),
      ])
    );
    loop.start();
    return () => loop.stop();
  }, [glowAnim]);

  useEffect(() => {
    let unsub = [];

    const load = () => {
      setReady(false);
      const rewarded = RewardedAd.createForAdRequest(REWARDED_AD_UNIT_ID);
      rewardedRef.current = rewarded;

      unsub = [
        rewarded.addAdEventListener(RewardedAdEventType.LOADED, () => setReady(true)),
        rewarded.addAdEventListener(RewardedAdEventType.EARNED_REWARD, () => {
          onRewardEarned && onRewardEarned();
        }),
        rewarded.addAdEventListener(AdEventType.CLOSED, () => {
          setReady(false);
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
  const ringScale = glowAnim.interpolate({ inputRange: [0, 1], outputRange: [1, 1.32] });
  const ringOpacity = glowAnim.interpolate({ inputRange: [0, 1], outputRange: [0.55, 0] });

  return (
    <View style={styles.wrap}>
      <Animated.View style={[styles.ring, { transform: [{ scale: ringScale }], opacity: ringOpacity }]} pointerEvents="none" />
      <Pressable onPress={handlePress} disabled={isDisabled} style={isDisabled && styles.disabled}>
        <LinearGradient colors={squadGradients.ctaTeal.colors} start={squadGradients.ctaTeal.start} end={squadGradients.ctaTeal.end} style={styles.button}>
          {!ready ? <ActivityIndicator color={squadColors.bgDeepest} size="small" /> : <View style={styles.playTriangle} />}
        </LinearGradient>
      </Pressable>
    </View>
  );
}

const styles = StyleSheet.create({
  wrap: { width: 64, height: 64, alignItems: 'center', justifyContent: 'center' },
  ring: { position: 'absolute', width: 64, height: 64, borderRadius: 32, borderWidth: 3, borderColor: squadColors.pink },
  disabled: { opacity: 0.5 },
  button: { width: 64, height: 64, borderRadius: 32, alignItems: 'center', justifyContent: 'center' },
  playTriangle: {
    width: 0,
    height: 0,
    marginLeft: 4,
    backgroundColor: 'transparent',
    borderStyle: 'solid',
    borderTopWidth: 11,
    borderBottomWidth: 11,
    borderLeftWidth: 18,
    borderTopColor: 'transparent',
    borderBottomColor: 'transparent',
    borderLeftColor: squadColors.bgDeepest,
  },
});
