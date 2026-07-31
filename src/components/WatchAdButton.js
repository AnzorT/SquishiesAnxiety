import React, { useCallback, useEffect, useRef, useState } from 'react';
import { Pressable, Text, StyleSheet, ActivityIndicator } from 'react-native';
import { RewardedAd, RewardedAdEventType, AdEventType } from 'react-native-google-mobile-ads';
import { REWARDED_AD_UNIT_ID } from '../firebase/ads';
import { colors, radii, spacing } from '../theme/tokens';

// Cartoon-style "watch an ad, get more coins" button. Loads a rewarded ad
// eagerly and re-loads the next one as soon as the current one closes, so
// there's (almost) always one ready to show.
export default function WatchAdButton({ onRewardEarned, disabled, label = 'Watch Ad · 2× Coins' }) {
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

  const isDisabled = !ready || disabled;

  return (
    <Pressable style={[styles.button, isDisabled && styles.buttonDisabled]} onPress={handlePress} disabled={isDisabled}>
      {!ready ? (
        <ActivityIndicator color="#FFFFFF" />
      ) : (
        <>
          <Text style={styles.icon}>▶</Text>
          <Text style={styles.label}>{label}</Text>
        </>
      )}
    </Pressable>
  );
}

const styles = StyleSheet.create({
  button: {
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'center',
    gap: spacing(2),
    backgroundColor: colors.success,
    borderRadius: radii.pill,
    paddingVertical: spacing(3),
    paddingHorizontal: spacing(6),
    marginTop: spacing(3),
    borderBottomWidth: 4,
    borderBottomColor: '#3C8C5C',
    shadowColor: '#000000',
    shadowOpacity: 0.15,
    shadowRadius: 6,
    shadowOffset: { width: 0, height: 3 },
    elevation: 4,
  },
  buttonDisabled: { opacity: 0.5 },
  icon: { color: '#FFFFFF', fontSize: 16, fontWeight: '800' },
  label: { color: '#FFFFFF', fontSize: 15, fontWeight: '800' },
});
