import { useEffect, useRef } from 'react';
import { InterstitialAd, AdEventType } from 'react-native-google-mobile-ads';
import { INTERSTITIAL_AD_UNIT_ID } from '../firebase/ads';

// Auto-fires a forced interstitial (no in-app dismiss button — only the ad's
// own close) whenever `trigger` changes to a new value. Same create -> wire
// LOADED/CLOSED/ERROR -> load() -> cleanup lifecycle as SquishScreen.js's
// PunishmentModal (see its `acceptPunishment`), just kicked off automatically
// on a prop change instead of a button press, so it can be mounted once at
// the app root and fired from wherever a free generation actually completes.
export default function ForcedInterstitialAd({ trigger, onDone }) {
  const unsubsRef = useRef([]);
  const lastFiredRef = useRef(trigger);

  useEffect(() => {
    if (trigger == null || trigger === lastFiredRef.current) return undefined;
    lastFiredRef.current = trigger;

    const ad = InterstitialAd.createForAdRequest(INTERSTITIAL_AD_UNIT_ID);
    const done = () => {
      unsubsRef.current.forEach((fn) => fn());
      unsubsRef.current = [];
      onDone && onDone();
    };
    unsubsRef.current = [
      ad.addAdEventListener(AdEventType.LOADED, () => ad.show()),
      ad.addAdEventListener(AdEventType.CLOSED, done),
      ad.addAdEventListener(AdEventType.ERROR, done),
    ];
    // If the ad never loads, don't silently swallow the trigger forever.
    const t = setTimeout(done, 8000);
    unsubsRef.current.push(() => clearTimeout(t));
    ad.load();

    return () => {
      unsubsRef.current.forEach((fn) => fn());
      unsubsRef.current = [];
    };
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [trigger]);

  return null;
}
