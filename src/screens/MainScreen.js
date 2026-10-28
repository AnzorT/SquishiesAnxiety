import React, { createContext, useContext, useEffect, useRef, useState } from 'react';
import { Animated, Easing, StyleSheet, View, useWindowDimensions } from 'react-native';
import AdStrip from '../components/AdStrip';
import BottomNav from '../squad/BottomNav';
import useInstantTab from '../components/useInstantTab';
import { Hold } from '../components/Freeze';
import { LoopsOn } from '../components/idleLoop';
import { Reveal } from '../components/Skeleton';
import { ShopPageBones } from './ShopScreen';

// The app shell (the design's App Shell): the Squishies tab and the Shop
// side by side, sliding under a bottom nav, with the banner ad between the
// page and the nav. The Shop is built in the background (or on its first
// visit) and then stays mounted. While the Shop runs its chest opener
// (`immersive`) the ad and the nav step aside so the opener has the whole
// screen. `active` is off while another screen covers this one (App keeps
// it alive underneath): the strip then holds no real banner.
const SLIDE = { duration: 550, easing: Easing.bezier(0.22, 1, 0.36, 1), useNativeDriver: true };

// On (App) while a screen covers Home whose own pictures, with the Shop's
// (its chest art), overflow Android's texture cache: the Crib. The Shop page
// is let go then (unmounted), and built again only when its tab is next
// tapped (its placeholders first, as on its first visit). With it there, the
// Crib's every frame re-uploaded ~175 textures (~150 ms a frame, Galaxy A15,
// 2026-10-28); hiding it instead (display: none) cost ~0.35 s frames as the
// Crib came in and again on the way back.
export const ShopAway = createContext(false);

export default function MainScreen({ tab: current, onTab, adsFree, active = true, squishies, renderShop }) {
  // a nav tap slides the pages on its own frame; App's tab (and its
  // re-render) follows two frames later
  const [tab, press] = useInstantTab(current, onTab);
  const { width } = useWindowDimensions();
  const [shopMounted, setShopMounted] = useState(tab === 'shop');
  const shopAway = useContext(ShopAway);
  // let go under the Crib: built again on its next tap, not in the background
  const [shopLater, setShopLater] = useState(false);
  const [immersive, setImmersive] = useState(false);
  const x = useRef(new Animated.Value(tab === 'shop' ? 1 : 0)).current;
  // the page the last slide ended on
  const [settled, setSettled] = useState(tab);
  // the Shop's page is up from a tap on its tab until a slide away from it
  // is over
  const [shopPage, setShopPage] = useState(tab === 'shop');
  useEffect(() => {
    if (tab === 'shop') setShopPage(true);
    Animated.timing(x, { toValue: tab === 'shop' ? 1 : 0, ...SLIDE }).start(({ finished }) => {
      if (!finished) return;
      setSettled(tab);
      if (tab !== 'shop') setShopPage(false);
    });
  }, [tab, x]);
  // A Shop not built yet when its tab is tapped (let go under the Crib, or
  // before its background build) slides in as placeholders (ShopPageBones)
  // and is built once it's in, fading in over them. Built on the tap, its
  // views held the slide's first frame (~0.25 s on the Galaxy A15 after the
  // Crib, 2026-10-28).
  useEffect(() => {
    if (settled === 'shop') setShopMounted(true);
  }, [settled]);
  // The Shop is built in the background once Home has settled (after the
  // Squishies tab's own pages), so the first Shop tap is only the slide; it
  // used to be built on that tap, before it could slide in.
  useEffect(() => {
    if (shopMounted || !active || shopLater) return undefined;
    const t = setTimeout(() => setShopMounted(true), 2500);
    return () => clearTimeout(t);
  }, [shopMounted, active, shopLater]);
  useEffect(() => {
    if (!shopAway || tab === 'shop') return;
    setShopMounted(false);
    setShopBuilt(false);
    setShopLater(true);
  }, [shopAway, tab]);
  // The page you're not on sleeps (Hold: not re-rendered from above) once
  // the slide away from it is over. Otherwise every profile change (coins
  // from the Crib, a purchase) re-rendered the off-screen Shop's three tabs
  // too: 2.7 s in a debug build on coming back from the Crib. A tap on its
  // tab wakes it at once, so it catches up while its slide runs. It stays
  // laid out beside the other page (until 2026-10-28 it was hidden with
  // Freeze, and waking the Shop was a 0.3-0.7 s re-layout on the UI thread,
  // in the middle of its slide). The Shop only sleeps once its background
  // build (MainScreen's, then its own pages a second apart) has had time to
  // finish.
  const [shopBuilt, setShopBuilt] = useState(false);
  useEffect(() => {
    if (!shopMounted || shopBuilt) return undefined;
    const t = setTimeout(() => setShopBuilt(true), 4000);
    return () => clearTimeout(t);
  }, [shopMounted, shopBuilt]);
  const shopAsleep = shopBuilt && tab !== 'shop' && settled !== 'shop';
  const squishAsleep = tab === 'shop' && settled === 'shop';
  // a sleeping page's loops stop, and the lobby takes its live creature out
  // (LoopsOn, src/components/idleLoop.js); within App's own (Home covered)
  const on = useContext(LoopsOn);
  const translateX = x.interpolate({ inputRange: [0, 1], outputRange: [0, -width] });
  return (
    <View style={styles.root}>
      <View style={styles.pages}>
        <Animated.View style={[styles.track, { width: width * 2, transform: [{ translateX }] }]}>
          <View style={{ width }} pointerEvents={tab === 'squish' ? 'auto' : 'none'}>
            <LoopsOn.Provider value={on && !squishAsleep}>
              <Hold hold={squishAsleep}>{squishies}</Hold>
            </LoopsOn.Provider>
          </View>
          <View style={{ width }} pointerEvents={tab === 'shop' ? 'auto' : 'none'}>
            <LoopsOn.Provider value={on && !shopAsleep}>
              {shopMounted || shopPage ? (
                <Reveal ready={shopMounted} placeholder={<ShopPageBones />} fill>
                  <Hold hold={shopAsleep}>{renderShop(setImmersive)}</Hold>
                </Reveal>
              ) : null}
            </LoopsOn.Provider>
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
  root: { flex: 1, backgroundColor: '#fdeefa' },
  pages: { flex: 1, overflow: 'hidden' },
  track: { flex: 1, flexDirection: 'row' },
  // on the nav bar's own pastel (the design has no banner; ours sits on top of the bar)
  ad: { backgroundColor: '#fdeefa', borderTopWidth: 0 },
});
