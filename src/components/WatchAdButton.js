import React, { useCallback, useEffect, useRef, useState } from 'react';
import { View, Text, StyleSheet, Animated, Easing } from 'react-native';
import Pressable from './Pressable';
import { LinearGradient } from 'expo-linear-gradient';
import { RewardedAd, RewardedAdEventType, AdEventType } from 'react-native-google-mobile-ads';
import { REWARDED_AD_UNIT_ID } from '../firebase/ads';
import { BUTTON_VARIANTS, candyFonts } from '../theme/candyTheme';
import { Shine } from './candy/CandyButton';
import { stepKeys, useKeyLoop } from './idleLoop';

// One "watch ad for a coin multiplier" CTA at the bottom of SquishScreen —
// there are three of these side by side (×2/×3/×4, see SquishScreen.js),
// each holding its own independently-loaded rewarded ad (kept for the
// session in adPool, below). In the v3 look it's
// a gold candy button: a little play-screen badge beside a big "×N", and
// "WATCH AD" / "LONG AD" underneath. It breathes (a slow scale pulse) and a
// light streak sweeps across it, but ONLY while it's actually tappable — see
// `isStill` below. A reward earned here opens SquishScreen's 60s ×N window
// (see handleAdReward); this component only loads/shows a real rewarded ad
// and reports back.
//
// `activeMultiplier` is the multiplier currently running (or null) — shared
// across all three buttons, from SquishScreen. Only one bonus window can run
// at a time: whichever button isn't the active one is locked out entirely
// (dimmed, unpressable, no animation) until the active window's timer ends,
// regardless of whether that button's own ad happens to be loaded.
//
// `adFree` (Remove Ads bought): no video at all — a tap starts the boost
// straight away, the caption reads "NO AD", and after each boost the buttons
// recharge until `rechargeUntil` (a timestamp), counting the seconds down.
const GOLD = BUTTON_VARIANTS.gold;
// the breath: 1 → 1.035 → 1, 1.2 s each way, eased
const BREATHE = stepKeys(1, [
  [1.035, 1200, Easing.inOut(Easing.ease)],
  [1, 1200, Easing.inOut(Easing.ease)],
]);
// the light streak sweeps across in the first 60% of its 2.8 s, then holds
// off the right edge for the remaining 40%
const SHEEN_AT = [0, 0.6, 1];
const SHEEN_X = [-70, 160, 160];

// PERF 2026-11-20: the rewarded ads live for the whole session, one per multiplier, instead of one per visit to Squish
// Time. Every ad that arrives makes Google's SDK build a WebView on the main thread (55-175 ms on the Galaxy A16: the
// stage and its hints froze), and the three buttons loaded three new ads on every visit, throwing the loaded ones away
// on the way out. Now a second visit finds them loaded (ready at once, nothing built). The pool's own listeners keep
// each entry's state while no button is on screen; a used (closed), failed or old ad is replaced by a new one (AdMob ads
// expire after an hour).
const AD_MAX_AGE_MS = 50 * 60 * 1000;
const adPool = new Map(); // multiplier -> { ad, state: 'loading' | 'loaded' | 'gone', at }

function pooledAd(multiplier, fresh) {
  const had = adPool.get(multiplier);
  const usable =
    had &&
    !fresh &&
    (had.state === 'loading' || (had.state === 'loaded' && had.ad.loaded && Date.now() - had.at < AD_MAX_AGE_MS));
  if (usable) return had;
  const entry = { ad: RewardedAd.createForAdRequest(REWARDED_AD_UNIT_ID), state: 'loading', at: 0 };
  entry.ad.addAdEventListener(RewardedAdEventType.LOADED, () => {
    entry.state = 'loaded';
    entry.at = Date.now();
  });
  entry.ad.addAdEventListener(AdEventType.ERROR, () => {
    entry.state = 'gone';
  });
  entry.ad.addAdEventListener(AdEventType.CLOSED, () => {
    entry.state = 'gone';
  });
  adPool.set(multiplier, entry);
  entry.ad.load();
  return entry;
}

export default function WatchAdButton({ multiplier, onRewardEarned, activeMultiplier, adFree = false, rechargeUntil = 0 }) {
  const rewardedRef = useRef(null);
  const earnedRef = useRef(false);
  const [adReady, setReady] = useState(false);
  const ready = adFree || adReady;

  // ad-free recharge countdown: a tick a second while it runs
  const [now, setNow] = useState(Date.now());
  const recharging = adFree && activeMultiplier == null && rechargeUntil > now;
  useEffect(() => {
    if (!adFree || rechargeUntil <= Date.now()) return undefined;
    setNow(Date.now());
    const id = setInterval(() => {
      const t = Date.now();
      setNow(t);
      if (t >= rechargeUntil) clearInterval(id);
    }, 1000);
    return () => clearInterval(id);
  }, [adFree, rechargeUntil]);

  const isThisActive = activeMultiplier === multiplier;
  const isLockedByOther = activeMultiplier != null && !isThisActive;
  // "Still": no ad ready yet, or another multiplier's window is running —
  // the two cases the button must go grey + unpressable + animation-frozen
  // for, treated identically. The active button itself keeps its own look
  // (the "ACTIVE" label below) rather than going grey.
  const isStill = !ready || isLockedByOther || recharging;
  const isDisabled = isStill || isThisActive;

  // The breath and the sheen, one native loop each while it's tappable, back
  // at rest while it's still (so a frozen button never shows a mid-cycle pose).
  const scale = useKeyLoop(BREATHE.ms, { at: BREATHE.at, values: BREATHE.values, on: !isStill });
  const sheenX = useKeyLoop(2800, { at: SHEEN_AT, values: SHEEN_X, on: !isStill });

  useEffect(() => {
    if (adFree) return undefined; // nothing to load
    let unsub = [];

    // this multiplier's ad from the session's pool (adPool below): already loaded on a second visit
    const load = (fresh) => {
      unsub.forEach((fn) => fn());
      const entry = pooledAd(multiplier, fresh);
      const rewarded = entry.ad;
      rewardedRef.current = rewarded;
      setReady(entry.state === 'loaded');

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
          // that ad is used up: the pool loads the next one
          load(true);
        }),
        rewarded.addAdEventListener(AdEventType.ERROR, () => setReady(false)),
      ];
    };

    load(false);
    return () => unsub.forEach((fn) => fn());
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [adFree]);

  const handlePress = useCallback(() => {
    if (!ready || isDisabled) return;
    if (adFree) {
      onRewardEarned && onRewardEarned();
      return;
    }
    if (!rewardedRef.current) return;
    rewardedRef.current.show();
  }, [ready, isDisabled, adFree, onRewardEarned]);

  const sub = isThisActive
    ? 'ACTIVE'
    : recharging
      ? `READY IN ${Math.ceil((rechargeUntil - now) / 1000)}s`
      : adFree
        ? 'NO AD'
        : multiplier >= 4
          ? 'LONG AD'
          : 'WATCH AD';

  return (
    <Animated.View style={[styles.wrap, { transform: [{ scale }] }, isStill && styles.dim]}>
      <Pressable onPress={handlePress} disabled={isDisabled} style={styles.press}>
        <View style={styles.lip} />
        <View style={styles.ring}>
          <LinearGradient colors={GOLD.colors} locations={GOLD.locations} style={styles.face}>
            <Shine radius={14} height="42%" />
            <Animated.View pointerEvents="none" style={[styles.sheen, { transform: [{ translateX: sheenX }, { skewX: '-20deg' }] }]} />
            <View style={styles.topRow}>
              {adFree ? null : (
                <View style={styles.screen}>
                  <View style={styles.play} />
                </View>
              )}
              <Text style={styles.mult}>×{multiplier}</Text>
            </View>
            <Text style={styles.sub}>{sub}</Text>
          </LinearGradient>
        </View>
      </Pressable>
    </Animated.View>
  );
}

const styles = StyleSheet.create({
  wrap: { flex: 1, minWidth: 0 },
  dim: { opacity: 0.5 },
  press: { paddingBottom: 5 },
  lip: { position: 'absolute', left: 0, right: 0, top: 5, bottom: 0, borderRadius: 22, backgroundColor: GOLD.ring },
  ring: {
    borderRadius: 22,
    padding: 2.5,
    backgroundColor: GOLD.ring,
    shadowColor: '#320064',
    shadowOffset: { width: 0, height: 8 },
    shadowOpacity: 0.4,
    shadowRadius: 9,
    elevation: 6,
  },
  face: {
    borderRadius: 20,
    borderWidth: 3,
    borderColor: '#ffffff',
    overflow: 'hidden',
    alignItems: 'center',
    paddingTop: 6,
    paddingBottom: 7,
    paddingHorizontal: 4,
    gap: 2,
  },
  sheen: { position: 'absolute', top: 0, bottom: 0, width: 30, backgroundColor: 'rgba(255,255,255,0.55)' },
  topRow: { flexDirection: 'row', alignItems: 'center', gap: 5 },
  screen: {
    width: 28,
    height: 20,
    borderRadius: 6,
    backgroundColor: '#f2b52a',
    borderWidth: 2,
    borderColor: '#ffffff',
    alignItems: 'center',
    justifyContent: 'center',
  },
  play: {
    width: 0,
    height: 0,
    marginLeft: 2,
    borderTopWidth: 5,
    borderBottomWidth: 5,
    borderLeftWidth: 8,
    borderTopColor: 'transparent',
    borderBottomColor: 'transparent',
    borderLeftColor: '#ffffff',
  },
  mult: {
    fontFamily: candyFonts.display,
    fontSize: 22,
    lineHeight: 24,
    color: '#ffffff',
    includeFontPadding: false,
    textShadowColor: GOLD.ring,
    textShadowOffset: { width: 0, height: 2 },
    textShadowRadius: 1,
  },
  sub: {
    fontFamily: candyFonts.display,
    fontSize: 10,
    letterSpacing: 0.8,
    color: '#ffffff',
    textShadowColor: GOLD.ring,
    textShadowOffset: { width: 0, height: 1 },
    textShadowRadius: 1,
  },
});
