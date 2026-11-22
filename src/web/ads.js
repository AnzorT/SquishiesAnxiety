// Web only: react-native-google-mobile-ads has no web version. The app uses Google's TEST ad units (src/firebase/ads.js),
// whose rewarded ads reward anyone who watches, so here a "watched" ad is simply granted: a rewarded ad loads at once,
// and show() earns its reward and closes after a moment; an interstitial closes; a banner is a plain grey strip of the
// same size, so screens keep their phone layout.
import React from 'react';
import { StyleSheet, Text, View } from 'react-native';

export const AdEventType = { LOADED: 'loaded', ERROR: 'error', OPENED: 'opened', CLICKED: 'clicked', PAID: 'paid', CLOSED: 'closed' };
export const RewardedAdEventType = { LOADED: 'rewarded_loaded', EARNED_REWARD: 'rewarded_earned_reward' };
export const TestIds = {
  BANNER: 'web-test-banner', INTERSTITIAL: 'web-test-interstitial', REWARDED: 'web-test-rewarded',
  REWARDED_INTERSTITIAL: 'web-test-rewarded-interstitial', APP_OPEN: 'web-test-app-open',
};
export const MaxAdContentRating = { G: 'G', PG: 'PG', T: 'T', MA: 'MA' };
export const BannerAdSize = {
  BANNER: 'BANNER', FULL_BANNER: 'FULL_BANNER', LARGE_BANNER: 'LARGE_BANNER', LEADERBOARD: 'LEADERBOARD',
  MEDIUM_RECTANGLE: 'MEDIUM_RECTANGLE', ADAPTIVE_BANNER: 'ADAPTIVE_BANNER', ANCHORED_ADAPTIVE_BANNER: 'ANCHORED_ADAPTIVE_BANNER',
  INLINE_ADAPTIVE_BANNER: 'INLINE_ADAPTIVE_BANNER', WRAPPED_FULL_WIDTH: 'WRAPPED_FULL_WIDTH',
};

class PretendAd {
  constructor(rewarded) {
    this.rewarded = rewarded;
    this.loaded = false;
    this.subs = new Map();
  }
  addAdEventListener(type, fn) {
    if (!this.subs.has(type)) this.subs.set(type, new Set());
    this.subs.get(type).add(fn);
    return () => this.subs.get(type) && this.subs.get(type).delete(fn);
  }
  removeAllListeners() {
    this.subs.clear();
  }
  emit(type, payload) {
    (this.subs.get(type) || []).forEach((fn) => {
      try {
        fn(payload);
      } catch (e) {
        console.error('[ads web]', e);
      }
    });
  }
  load() {
    setTimeout(() => {
      this.loaded = true;
      this.emit(this.rewarded ? RewardedAdEventType.LOADED : AdEventType.LOADED);
    }, 300);
  }
  show() {
    if (!this.loaded) return Promise.reject(new Error('Ad not loaded'));
    this.loaded = false;
    this.emit(AdEventType.OPENED);
    setTimeout(() => {
      if (this.rewarded) this.emit(RewardedAdEventType.EARNED_REWARD, { type: 'coins', amount: 1 });
      this.emit(AdEventType.CLOSED);
    }, 700);
    return Promise.resolve();
  }
}

export const RewardedAd = { createForAdRequest: () => new PretendAd(true) };
export const RewardedInterstitialAd = { createForAdRequest: () => new PretendAd(true) };
export const InterstitialAd = { createForAdRequest: () => new PretendAd(false) };
export const AppOpenAd = { createForAdRequest: () => new PretendAd(false) };

const BANNER_H = { LARGE_BANNER: 100, MEDIUM_RECTANGLE: 250, LEADERBOARD: 90, FULL_BANNER: 60 };
const BANNER_W = { LARGE_BANNER: 320, MEDIUM_RECTANGLE: 300, BANNER: 320, LEADERBOARD: 728, FULL_BANNER: 468 };
export function BannerAd({ size }) {
  const w = BANNER_W[size];
  return (
    <View style={[styles.banner, { height: BANNER_H[size] || 50 }, w ? { width: w } : styles.wide]}>
      <Text style={styles.label}>ad</Text>
    </View>
  );
}
export const GAMBannerAd = BannerAd;

const mobileAds = () => ({
  initialize: () => Promise.resolve([]),
  setRequestConfiguration: () => Promise.resolve(),
  openAdInspector: () => Promise.resolve(),
});
export default mobileAds;

const styles = StyleSheet.create({
  banner: { backgroundColor: 'rgba(0,0,0,0.12)', alignItems: 'center', justifyContent: 'center' },
  wide: { alignSelf: 'stretch' },
  label: { color: 'rgba(0,0,0,0.35)', fontSize: 11 },
});
