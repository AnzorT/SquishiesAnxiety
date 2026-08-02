import React, { useCallback, useEffect, useRef, useState } from 'react';
import { View, Pressable, Text, StyleSheet, ActivityIndicator } from 'react-native';
import { RewardedAd, RewardedAdEventType, AdEventType } from 'react-native-google-mobile-ads';
import { REWARDED_AD_UNIT_ID } from '../firebase/ads';
import { colors, spacing } from '../theme/tokens';

// Small round "game icon" ad button, matching the PlushCrush2 reference:
// a yellow circle with a play triangle and a "2×" badge, captioned below.
// Loads a rewarded ad eagerly and re-loads the next one as soon as the
// current one closes, so there's (almost) always one ready to show.
//
// While a 2× boost is running (boostSecondsLeft > 0), the play triangle is
// replaced by a live backwards-counting timer, a fill drains down the icon
// as the boost runs out (see progressOverlay — height tracks elapsed time,
// clipped to the circle via iconButtonInner's overflow:hidden so it reads
// as a depleting gauge rather than just a static number), and the button
// locks — it only becomes watchable again once the boost expires.
export default function WatchAdButton({
  onRewardEarned,
  disabled,
  boostSecondsLeft = 0,
  boostTotalSeconds = 60,
  label = 'Watch a video to earn 2× coins',
}) {
  const rewardedRef = useRef(null);
  const [ready, setReady] = useState(false);

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

  const boosted = boostSecondsLeft > 0;
  const isDisabled = !ready || disabled || boosted;
  const minutes = Math.floor(boostSecondsLeft / 60);
  const seconds = boostSecondsLeft % 60;
  const timerLabel = minutes > 0 ? `${minutes}:${String(seconds).padStart(2, '0')}` : `${seconds}`;
  const remaining = boostTotalSeconds > 0 ? Math.min(1, boostSecondsLeft / boostTotalSeconds) : 0;
  const elapsedPercent = `${Math.round((1 - remaining) * 100)}%`;

  return (
    <View style={styles.wrap}>
      <Pressable
        style={[
          styles.iconButton,
          !boosted && isDisabled && styles.iconButtonDisabled,
          boosted && styles.iconButtonBoosted,
        ]}
        onPress={handlePress}
        disabled={isDisabled}
      >
        <View style={styles.iconButtonInner}>
          {boosted && <View style={[styles.progressOverlay, { height: elapsedPercent }]} pointerEvents="none" />}
          {boosted ? (
            <Text style={styles.timerText}>{timerLabel}</Text>
          ) : !ready ? (
            <ActivityIndicator color={colors.buttonPrimary} size="small" />
          ) : (
            <View style={styles.playTriangle} />
          )}
        </View>
        <View style={styles.multiplierBadge}>
          <Text style={styles.multiplierText}>2×</Text>
        </View>
      </Pressable>
      <Text style={styles.caption}>{boosted ? `2× coins active · ${timerLabel} left` : label}</Text>
    </View>
  );
}

const styles = StyleSheet.create({
  wrap: { width: '100%', alignItems: 'flex-start', paddingHorizontal: spacing(5), marginTop: spacing(3) },
  iconButton: {
    width: 44,
    height: 44,
    borderRadius: 22,
    backgroundColor: colors.adIconBg,
    alignItems: 'center',
    justifyContent: 'center',
    shadowColor: colors.coinGoldDeep,
    shadowOpacity: 0.3,
    shadowRadius: 6,
    shadowOffset: { width: 0, height: 3 },
    elevation: 4,
  },
  iconButtonInner: {
    width: '100%',
    height: '100%',
    borderRadius: 22,
    overflow: 'hidden',
    alignItems: 'center',
    justifyContent: 'center',
  },
  // Grows from 0% to 100% height (top-down) as the boost runs out, clipped
  // to the circle by iconButtonInner — a draining gauge instead of a static
  // countdown number sitting still.
  progressOverlay: {
    position: 'absolute',
    top: 0,
    left: 0,
    right: 0,
    backgroundColor: 'rgba(124,79,192,0.32)',
  },
  iconButtonDisabled: { opacity: 0.5 },
  iconButtonBoosted: { borderWidth: 2, borderColor: colors.buttonPrimary },
  timerText: { fontSize: 14, fontWeight: '900', color: colors.buttonPrimary },
  playTriangle: {
    width: 0,
    height: 0,
    marginLeft: 3,
    backgroundColor: 'transparent',
    borderStyle: 'solid',
    borderTopWidth: 8,
    borderBottomWidth: 8,
    borderLeftWidth: 12,
    borderTopColor: 'transparent',
    borderBottomColor: 'transparent',
    borderLeftColor: colors.buttonPrimary,
  },
  multiplierBadge: {
    position: 'absolute',
    bottom: -6,
    right: -6,
    backgroundColor: colors.buttonPrimary,
    borderRadius: 8,
    paddingHorizontal: 4,
    paddingVertical: 1,
  },
  multiplierText: { color: '#FFFFFF', fontSize: 9, fontWeight: '900' },
  caption: {
    fontSize: 12,
    fontWeight: '600',
    color: colors.caption,
    marginTop: spacing(1.5),
    textAlign: 'left',
    maxWidth: 220,
  },
});
