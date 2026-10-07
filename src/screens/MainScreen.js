import React, { useEffect, useRef, useState } from 'react';
import { Animated, Easing, StyleSheet, View, useWindowDimensions } from 'react-native';
import AdStrip from '../components/AdStrip';
import BottomNav from '../squad/BottomNav';

// The app shell (the design's App Shell): the Squishies tab and the Shop
// side by side, sliding under a bottom nav, with the banner ad between the
// page and the nav. The Shop mounts on its first visit and then stays
// mounted. While the Shop runs its chest opener (`immersive`) the ad and the
// nav step aside so the opener has the whole screen.
const SLIDE = { duration: 550, easing: Easing.bezier(0.22, 1, 0.36, 1), useNativeDriver: true };

export default function MainScreen({ tab, onTab, adsFree, squishies, renderShop }) {
  const { width } = useWindowDimensions();
  const [shopMounted, setShopMounted] = useState(tab === 'shop');
  const [immersive, setImmersive] = useState(false);
  const x = useRef(new Animated.Value(tab === 'shop' ? 1 : 0)).current;
  useEffect(() => {
    if (tab === 'shop') setShopMounted(true);
    Animated.timing(x, { toValue: tab === 'shop' ? 1 : 0, ...SLIDE }).start();
  }, [tab, x]);
  const translateX = x.interpolate({ inputRange: [0, 1], outputRange: [0, -width] });
  return (
    <View style={styles.root}>
      <View style={styles.pages}>
        <Animated.View style={[styles.track, { width: width * 2, transform: [{ translateX }] }]}>
          <View style={{ width }} pointerEvents={tab === 'squish' ? 'auto' : 'none'}>
            {squishies}
          </View>
          <View style={{ width }} pointerEvents={tab === 'shop' ? 'auto' : 'none'}>
            {shopMounted ? renderShop(setImmersive) : null}
          </View>
        </Animated.View>
      </View>
      {!immersive && (
        <>
          {adsFree ? null : <AdStrip inset={false} style={styles.ad} />}
          <BottomNav tab={tab} onTab={onTab} />
        </>
      )}
    </View>
  );
}

const styles = StyleSheet.create({
  root: { flex: 1, backgroundColor: '#45107a' },
  pages: { flex: 1, overflow: 'hidden' },
  track: { flex: 1, flexDirection: 'row' },
  ad: { backgroundColor: '#2a0f4a', borderTopWidth: 0 },
});
