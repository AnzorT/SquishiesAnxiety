import React, { useCallback, useEffect, useRef, useState } from 'react';
import { View, Text, StyleSheet, Animated, Easing } from 'react-native';
import Svg, { Circle } from 'react-native-svg';
import Pressable from './Pressable';
import { LinearGradient } from 'expo-linear-gradient';
import { RewardedAd, RewardedAdEventType, AdEventType } from 'react-native-google-mobile-ads';
import { REWARDED_AD_UNIT_ID } from '../firebase/ads';
import { BUTTON_VARIANTS, candyFonts } from '../theme/candyTheme';
import { Shine } from './candy/CandyButton';
import { InkText } from '../royal/parts';
import { stepKeys, useKeyLoop } from './idleLoop';

// One "watch ad for a coin multiplier" button on Squish Time's rail at the
// right edge — three of them down it (×2/×3/×4, see SquishScreen.js), each
// holding its own independently-loaded rewarded ad (kept for the session in
// adPool, below). Since the 2026-11-21 remodel it's a round gold coin of a
// button: "×N" in the middle, a little play badge on its rim, and "AD" /
// "LONG AD" under it. It breathes (a slow scale pulse) and a light streak
// sweeps across it, but ONLY while it's actually tappable — see `isStill`
// below. A reward earned here opens SquishScreen's 60s ×N window (see
// handleAdReward); this component only loads/shows a real rewarded ad and
// reports back. While its window runs (`endsAt`, `total` ms long), a ring
// round it runs down and the time left shows under it (it was a separate
// banner before the remodel).
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
const SHEEN_X = [-40, 80, 80];
// the coin's size (dp) and the countdown ring round it
export const BOOST_SIZE = 58;
const RING_R = BOOST_SIZE / 2 + 5;
const RING_BOX = RING_R * 2 + 6;
const RING_LEN = 2 * Math.PI * RING_R;

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

export default function WatchAdButton({ multiplier, onRewardEarned, activeMultiplier, adFree = false, rechargeUntil = 0, endsAt = 0, total = 60000 }) {
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
  // this button's window running: its own 250 ms tick (only this button re-renders)
  const counting = isThisActive && endsAt > 0;
  useEffect(() => {
    if (!counting) return undefined;
    setNow(Date.now());
    const id = setInterval(() => setNow(Date.now()), 250);
    return () => clearInterval(id);
  }, [counting]);
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

  const left = counting ? Math.max(0, endsAt - now) : 0;
  const secs = Math.ceil(left / 1000);
  const sub = counting
    ? `${Math.floor(secs / 60)}:${String(secs % 60).padStart(2, '0')}`
    : isThisActive
      ? 'ACTIVE'
      : recharging
        ? `${Math.ceil((rechargeUntil - now) / 1000)}s`
        : adFree
          ? 'FREE'
          : multiplier >= 4
            ? 'LONG AD'
            : 'AD';

  return (
    <Animated.View style={[styles.wrap, { transform: [{ scale }] }, isStill && styles.dim]}>
      <Pressable onPress={handlePress} disabled={isDisabled} hitSlop={6} style={styles.press}>
        {counting ? (
          // the window's time left, running down clockwise from the top
          <Svg pointerEvents="none" width={RING_BOX} height={RING_BOX} style={styles.countRing}>
            <Circle cx={RING_BOX / 2} cy={RING_BOX / 2} r={RING_R} stroke="rgba(107,68,38,0.45)" strokeWidth={5} fill="none" />
            <Circle
              cx={RING_BOX / 2}
              cy={RING_BOX / 2}
              r={RING_R}
              stroke="#fff3a0"
              strokeWidth={5}
              strokeLinecap="round"
              fill="none"
              strokeDasharray={`${RING_LEN} ${RING_LEN}`}
              strokeDashoffset={RING_LEN * (1 - Math.min(1, left / total))}
              transform={`rotate(-90 ${RING_BOX / 2} ${RING_BOX / 2})`}
            />
          </Svg>
        ) : null}
        <View style={styles.lip} />
        <View style={styles.ring}>
          <LinearGradient colors={GOLD.colors} locations={GOLD.locations} style={styles.face}>
            <Shine radius={BOOST_SIZE / 2} height="46%" />
            <Animated.View pointerEvents="none" style={[styles.sheen, { transform: [{ translateX: sheenX }, { skewX: '-20deg' }] }]} />
            <Text style={styles.mult}>×{multiplier}</Text>
          </LinearGradient>
        </View>
        {adFree ? null : (
          <View style={styles.badge}>
            <View style={styles.play} />
          </View>
        )}
      </Pressable>
      <InkText size={10.5} style={styles.sub}>
        {sub}
      </InkText>
    </Animated.View>
  );
}

const styles = StyleSheet.create({
  wrap: { alignItems: 'center', gap: 1 },
  dim: { opacity: 0.5 },
  press: { width: BOOST_SIZE, height: BOOST_SIZE + 4 },
  countRing: { position: 'absolute', left: (BOOST_SIZE - RING_BOX) / 2, top: (BOOST_SIZE - RING_BOX) / 2 },
  lip: { position: 'absolute', left: 0, top: 4, width: BOOST_SIZE, height: BOOST_SIZE, borderRadius: BOOST_SIZE / 2, backgroundColor: GOLD.ring },
  ring: {
    width: BOOST_SIZE,
    height: BOOST_SIZE,
    borderRadius: BOOST_SIZE / 2,
    padding: 2.5,
    backgroundColor: GOLD.ring,
    shadowColor: '#3f2412',
    shadowOffset: { width: 0, height: 5 },
    shadowOpacity: 0.35,
    shadowRadius: 6,
    elevation: 5,
  },
  face: {
    flex: 1,
    borderRadius: BOOST_SIZE / 2,
    borderWidth: 3,
    borderColor: '#ffffff',
    overflow: 'hidden',
    alignItems: 'center',
    justifyContent: 'center',
  },
  sheen: { position: 'absolute', top: 0, bottom: 0, left: 0, width: 16, backgroundColor: 'rgba(255,255,255,0.55)' },
  // the play badge on the rim, top right
  badge: {
    position: 'absolute',
    right: -4,
    top: -3,
    width: 22,
    height: 22,
    borderRadius: 11,
    backgroundColor: '#e8681c',
    borderWidth: 2,
    borderColor: '#ffffff',
    alignItems: 'center',
    justifyContent: 'center',
  },
  play: {
    width: 0,
    height: 0,
    marginLeft: 2,
    borderTopWidth: 4.5,
    borderBottomWidth: 4.5,
    borderLeftWidth: 7,
    borderTopColor: 'transparent',
    borderBottomColor: 'transparent',
    borderLeftColor: '#ffffff',
  },
  mult: {
    fontFamily: candyFonts.display,
    fontSize: 23,
    lineHeight: 26,
    color: '#ffffff',
    includeFontPadding: false,
    textShadowColor: GOLD.ring,
    textShadowOffset: { width: 0, height: 2 },
    textShadowRadius: 1,
  },
  sub: { letterSpacing: 0.6 },
});
