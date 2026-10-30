import React from 'react';
import { View, StyleSheet } from 'react-native';
import { BannerAd, BannerAdSize } from 'react-native-google-mobile-ads';
import { BANNER_AD_UNIT_ID } from '../firebase/ads';

// `large`: the 320×100 large banner (else the full-width anchored adaptive one)
export default function AdBanner({ large = false }) {
  return (
    <View style={styles.container}>
      <BannerAd unitId={BANNER_AD_UNIT_ID} size={large ? BannerAdSize.LARGE_BANNER : BannerAdSize.ANCHORED_ADAPTIVE_BANNER} />
    </View>
  );
}

const styles = StyleSheet.create({
  container: { width: '100%', alignItems: 'center' },
});
