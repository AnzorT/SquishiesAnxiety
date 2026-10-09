import React, { useEffect, useRef, useState } from 'react';
import { Animated, Easing, StyleSheet, View, useWindowDimensions } from 'react-native';
import AdStrip from '../components/AdStrip';
import BottomNav from '../squad/BottomNav';
import useInstantTab from '../components/useInstantTab';
import Freeze from '../components/Freeze';

// The app shell (the design's App Shell): the Squishies tab and the Shop
// side by side, sliding under a bottom nav, with the banner ad between the
// page and the nav. The Shop mounts on its first visit and then stays
// mounted. While the Shop runs its chest opener (`immersive`) the ad and the
// nav step aside so the opener has the whole screen. `active` is off while
// another screen covers this one (App keeps it alive underneath): the strip
// then holds no real banner.
const SLIDE = { duration: 550, easing: Easing.bezier(0.22, 1, 0.36, 1), useNativeDriver: true };

export default function MainScreen({ tab: current, onTab, adsFree, active = true, squishies, renderShop }) {
  // a nav tap slides the pages on its own frame; App's tab (and its
  // re-render) follows two frames later
  const [tab, press] = useInstantTab(current, onTab);
  const { width } = useWindowDimensions();
  const [shopMounted, setShopMounted] = useState(tab === 'shop');
  const [immersive, setImmersive] = useState(false);
  const x = useRef(new Animated.Value(tab === 'shop' ? 1 : 0)).current;
  // the page the last slide ended on
  const [settled, setSettled] = useState(tab);
  useEffect(() => {
    if (tab === 'shop') setShopMounted(true);
    Animated.timing(x, { toValue: tab === 'shop' ? 1 : 0, ...SLIDE }).start(({ finished }) => finished && setSettled(tab));
  }, [tab, x]);
  // The Shop is built in the background once Home has settled (after the
  // Squishies tab's own pages), so the first Shop tap is only the slide; it
  // used to be built on that tap, before it could slide in.
  useEffect(() => {
    if (shopMounted || !active) return undefined;
    const t = setTimeout(() => setShopMounted(true), 2500);
    return () => clearTimeout(t);
  }, [shopMounted, active]);
  // The page you're not on sleeps (Freeze: hidden, not re-rendered) once the
  // slide away from it is over. Otherwise every profile change (coins from
  // the Crib, a purchase) re-rendered the off-screen Shop's three tabs too:
  // 2.7 s in a debug build on coming back from the Crib. A tap on its tab
  // wakes it at once, so it catches up while its slide runs. The Shop only
  // sleeps once its background build (MainScreen's, then its own pages a
  // second apart) has had time to finish: a subtree frozen before it's built
  // isn't built.
  const [shopBuilt, setShopBuilt] = useState(false);
  useEffect(() => {
    if (!shopMounted || shopBuilt) return undefined;
    const t = setTimeout(() => setShopBuilt(true), 4000);
    return () => clearTimeout(t);
  }, [shopMounted, shopBuilt]);
  const shopAsleep = shopBuilt && tab !== 'shop' && settled !== 'shop';
  const squishAsleep = tab === 'shop' && settled === 'shop';
  const translateX = x.interpolate({ inputRange: [0, 1], outputRange: [0, -width] });
  return (
    <View style={styles.root}>
      <View style={styles.pages}>
        <Animated.View style={[styles.track, { width: width * 2, transform: [{ translateX }] }]}>
          <View style={{ width }} pointerEvents={tab === 'squish' ? 'auto' : 'none'}>
            <Freeze freeze={squishAsleep}>{squishies}</Freeze>
          </View>
          <View style={{ width }} pointerEvents={tab === 'shop' ? 'auto' : 'none'}>
            {shopMounted ? <Freeze freeze={shopAsleep}>{renderShop(setImmersive)}</Freeze> : null}
          </View>
        </Animated.View>
      </View>
      {!immersive && (
        <>
          {adsFree ? null : <AdStrip inset={false} live={active} style={styles.ad} />}
          <BottomNav tab={tab} onTab={press} />
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
