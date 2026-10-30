import React, { memo, useEffect, useRef, useState } from 'react';
import { Animated, Easing, StyleSheet, Text, View } from 'react-native';
import Pressable from '../components/Pressable';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import Svg, { Circle, Defs, Ellipse, LinearGradient as SvgGradient, Path, Stop } from 'react-native-svg';
import ShadowText, { outline3 } from '../components/candy/ShadowText';
import TutTarget from '../tutorial/Target';
import { F, PINK, PINK_RING, Ringed } from './ui';

// The app shell's bottom nav: Squish | Shop in a floating candy dock drawn
// like the Shop's Chests / Deals / Gems switch (a white bar in a magenta ring
// with a lip, a pink candy pill sliding under the open tab), so it reads as
// part of the app (the user, 2026-10-28: the plain white sheet before it
// looked "out of context"). The open tab's icon sits in a white disc on the
// pill, its name white outlined in magenta; the other's is plain magenta.
// The tapped tab's icon pops, and a red dot sits on the Shop while you're
// elsewhere. Tutorial targets: `storeBack` on Squish (the way back from the
// Shop), `store` on Shop.

export const TABS = [
  ['squish', 'Squish', 'storeBack'],
  ['shop', 'Shop', 'store'],
];
const SLIDE = { duration: 450, easing: Easing.bezier(0.3, 1.3, 0.5, 1), useNativeDriver: true };
const ICON = 26;

// a pink plush with round ears, a shine, blush and a smile
function SquishIcon() {
  return (
    <Svg width={ICON} height={ICON} viewBox="0 0 32 32">
      <Defs>
        <SvgGradient id="navSquish" x1="0" y1="0" x2="0" y2="1">
          <Stop offset="0" stopColor="#ffc2ec" />
          <Stop offset="0.55" stopColor="#ff6fcb" />
          <Stop offset="1" stopColor="#d62fb5" />
        </SvgGradient>
      </Defs>
      <Circle cx={8.5} cy={9} r={3.6} fill="#ff8fd8" stroke="#8e1580" strokeWidth={1.6} />
      <Circle cx={23.5} cy={9} r={3.6} fill="#ff8fd8" stroke="#8e1580" strokeWidth={1.6} />
      <Circle cx={8.5} cy={8.4} r={1.5} fill="#ffd6f4" />
      <Circle cx={23.5} cy={8.4} r={1.5} fill="#ffd6f4" />
      <Path d="M3.5 19 C3.5 11.5 9 7 16 7 C23 7 28.5 11.5 28.5 19 C28.5 25.2 23.5 28.5 16 28.5 C8.5 28.5 3.5 25.2 3.5 19 Z" fill="url(#navSquish)" stroke="#8e1580" strokeWidth={1.6} />
      <Ellipse cx={10} cy={12.6} rx={3} ry={1.6} fill="#ffffff" opacity={0.75} transform="rotate(-25 10 12.6)" />
      <Circle cx={12} cy={18} r={2} fill="#45107a" />
      <Circle cx={20} cy={18} r={2} fill="#45107a" />
      <Circle cx={12.7} cy={17.3} r={0.7} fill="#ffffff" />
      <Circle cx={20.7} cy={17.3} r={0.7} fill="#ffffff" />
      <Ellipse cx={8.6} cy={21.4} rx={2.1} ry={1.3} fill="#ff2f86" opacity={0.4} />
      <Ellipse cx={23.4} cy={21.4} rx={2.1} ry={1.3} fill="#ff2f86" opacity={0.4} />
      <Path d="M14 21.6 Q16 23.6 18 21.6" fill="none" stroke="#45107a" strokeWidth={1.5} strokeLinecap="round" />
    </Svg>
  );
}

// a violet shopping bag with a gold heart
function ShopIcon() {
  return (
    <Svg width={ICON} height={ICON} viewBox="0 0 32 32">
      <Defs>
        <SvgGradient id="navBag" x1="0" y1="0" x2="0" y2="1">
          <Stop offset="0" stopColor="#d9bfff" />
          <Stop offset="0.5" stopColor="#a66bff" />
          <Stop offset="1" stopColor="#7a2fe0" />
        </SvgGradient>
      </Defs>
      <Path d="M11.5 13 V9.8 C11.5 6.9 13.4 5 16 5 C18.6 5 20.5 6.9 20.5 9.8 V13" fill="none" stroke="#45189a" strokeWidth={2.2} strokeLinecap="round" />
      <Path
        d="M7 11.5 H25 C25.8 11.5 26.4 12.1 26.5 12.9 L27.6 26 C27.7 27.4 26.6 28.6 25.2 28.6 H6.8 C5.4 28.6 4.3 27.4 4.4 26 L5.5 12.9 C5.6 12.1 6.2 11.5 7 11.5 Z"
        fill="url(#navBag)"
        stroke="#45189a"
        strokeWidth={1.6}
        strokeLinejoin="round"
      />
      <Path d="M8.4 15 L7.8 21.5" stroke="#ffffff" strokeWidth={1.8} strokeLinecap="round" opacity={0.6} />
      <Path
        d="M16 25 C12.6 22.6 11 20.9 11 19 C11 17.6 12.1 16.5 13.5 16.5 C14.6 16.5 15.5 17.1 16 18 C16.5 17.1 17.4 16.5 18.5 16.5 C19.9 16.5 21 17.6 21 19 C21 20.9 19.4 22.6 16 25 Z"
        fill="#ffd23a"
        stroke="#ffffff"
        strokeWidth={1.3}
        strokeLinejoin="round"
      />
    </Svg>
  );
}

// appPop: scale 0.7 → 1.18 → 1 with a wobble, on every tap of the tab
const NavItem = memo(function NavItem({ id, label, tut, on, onPress }) {
  const pop = useRef(new Animated.Value(1)).current;
  const press = () => {
    pop.setValue(0);
    Animated.timing(pop, { toValue: 1, duration: 500, easing: Easing.bezier(0.3, 1.4, 0.5, 1), useNativeDriver: true }).start();
    onPress(id);
  };
  const scale = pop.interpolate({ inputRange: [0, 0.55, 1], outputRange: [0.7, 1.18, 1] });
  const rotate = pop.interpolate({ inputRange: [0, 0.55, 1], outputRange: ['-8deg', '4deg', '0deg'] });
  return (
    <TutTarget name={tut} style={styles.item}>
      <Pressable style={styles.itemIn} onPress={press}>
        <Animated.View style={{ transform: [{ scale }, { rotate }] }}>
          <View style={[styles.discLip, !on && styles.bare]}>
            <View style={[styles.disc, !on && styles.bare]}>{id === 'shop' ? <ShopIcon /> : <SquishIcon />}</View>
          </View>
          {id === 'shop' && !on && <View style={styles.dot} pointerEvents="none" />}
        </Animated.View>
        {on ? (
          <ShadowText style={styles.label} shadows={ON_SHADOWS}>
            {label}
          </ShadowText>
        ) : (
          <Text style={[styles.label, styles.labelOff]}>{label}</Text>
        )}
      </Pressable>
    </TutTarget>
  );
});
const ON_SHADOWS = outline3(PINK_RING, 2);

export default function BottomNav({ tab, onTab }) {
  const insets = useSafeAreaInsets();
  const [w, setW] = useState(0);
  const x = useRef(new Animated.Value(tab === 'shop' ? 1 : 0)).current;
  useEffect(() => {
    Animated.timing(x, { toValue: tab === 'shop' ? 1 : 0, ...SLIDE }).start();
  }, [tab, x]);
  // the dock's inside is padded 4 all round; the pill fills one tab of it
  const pill = (w - 8) / TABS.length;
  return (
    <View style={[styles.bar, { paddingBottom: Math.max(insets.bottom, 6) + 4 }]}>
      <Ringed ring={PINK_RING} lip={5} ringW={2.5} border={3} radius={26} colors={['#ffffff', '#fbf2ff']} innerStyle={styles.dock}>
        <View style={StyleSheet.absoluteFill} onLayout={(e) => e.nativeEvent.layout.width > 0 && setW(e.nativeEvent.layout.width)} />
        {w > 0 && (
          <Animated.View pointerEvents="none" style={[styles.pill, { width: pill, transform: [{ translateX: x.interpolate({ inputRange: [0, 1], outputRange: [0, pill] }) }] }]}>
            <Ringed ring={PINK_RING} lip={3} ringW={2} border={2.5} radius={20} colors={PINK} style={styles.fill} innerStyle={styles.fill} />
          </Animated.View>
        )}
        {TABS.map(([id, label, tut]) => (
          <NavItem key={id} id={id} label={label} tut={tut} on={tab === id} onPress={onTab} />
        ))}
      </Ringed>
    </View>
  );
}

const styles = StyleSheet.create({
  // the dock floats on the page's pastel
  bar: { paddingTop: 4, paddingHorizontal: 12 },
  // 60 with its white border: the pill's face (39) holds the 36 px disc
  dock: { flexDirection: 'row', height: 60, padding: 4 },
  pill: { position: 'absolute', left: 4, top: 4, bottom: 4 },
  fill: { flex: 1 },
  item: { flex: 1 },
  // lifted by the pill's lip, so the disc and name sit on its face
  itemIn: { flex: 1, flexDirection: 'row', alignItems: 'center', justifyContent: 'center', gap: 8, paddingBottom: 4 },
  // the open tab's white disc, a magenta lip under it
  discLip: { borderRadius: 17, paddingBottom: 2, backgroundColor: PINK_RING },
  disc: { width: 34, height: 34, borderRadius: 17, backgroundColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  bare: { backgroundColor: 'transparent' },
  dot: { position: 'absolute', right: -3, top: -2, width: 11, height: 11, borderRadius: 6, backgroundColor: '#e01e4a', borderWidth: 2, borderColor: '#ffffff' },
  label: { fontFamily: F.display, fontSize: 17, letterSpacing: 0.4, color: '#ffffff', includeFontPadding: false },
  labelOff: { color: PINK_RING },
});
