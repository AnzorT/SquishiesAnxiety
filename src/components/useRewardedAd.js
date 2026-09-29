import { useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { RewardedAd, RewardedAdEventType, AdEventType } from 'react-native-google-mobile-ads';
import { REWARDED_AD_UNIT_ID } from '../firebase/ads';
import sfx from '../audio/sfx';

// Keeps one rewarded ad loaded. `show(onEarned)` plays it; `onEarned` runs
// after the ad is CLOSED, and only if its reward was earned (the reward
// event fires while the ad is still on screen, so anything animated waits
// until the app is visible again). A fresh ad starts loading right after.
export default function useRewardedAd() {
  const adRef = useRef(null);
  const earnedRef = useRef(false);
  const onEarnedRef = useRef(null);
  const [ready, setReady] = useState(false);

  useEffect(() => {
    let unsub = [];
    let alive = true;
    const load = () => {
      unsub.forEach((fn) => fn());
      if (!alive) return;
      setReady(false);
      const ad = RewardedAd.createForAdRequest(REWARDED_AD_UNIT_ID);
      adRef.current = ad;
      unsub = [
        ad.addAdEventListener(RewardedAdEventType.LOADED, () => setReady(true)),
        ad.addAdEventListener(RewardedAdEventType.EARNED_REWARD, () => {
          earnedRef.current = true;
        }),
        ad.addAdEventListener(AdEventType.CLOSED, () => {
          const cb = onEarnedRef.current;
          const earned = earnedRef.current;
          earnedRef.current = false;
          onEarnedRef.current = null;
          if (earned) sfx.play('adDone');
          if (earned && cb) cb();
          load();
        }),
        ad.addAdEventListener(AdEventType.ERROR, () => setReady(false)),
      ];
      ad.load();
    };
    load();
    return () => {
      alive = false;
      unsub.forEach((fn) => fn());
    };
  }, []);

  const show = useCallback(
    (onEarned) => {
      if (!ready || !adRef.current) return false;
      onEarnedRef.current = onEarned;
      setReady(false);
      adRef.current.show();
      return true;
    },
    [ready]
  );

  return useMemo(() => ({ ready, show }), [ready, show]);
}
