import React, { memo, useEffect, useRef, useState } from 'react';
import { Animated, Easing, Pressable, StyleSheet, View } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Circle, Path, Rect } from 'react-native-svg';
import ShadowText from '../components/candy/ShadowText';
import TutTarget from '../tutorial/Target';
import { F, PINK, PINK_RING, Ringed } from './ui';

// The app shell's bottom nav (the design's App Shell): Squishies | Shop on a
// purple bar, with a pink candy pill sliding under the open tab and the
// tapped tab's icon popping. Tutorial targets: `storeBack` on Squishies (the
// way back from the Shop), `store` on Shop.

export const TABS = [
  ['squish', 'Squishies', 'storeBack'],
  ['shop', 'Shop', 'store'],
];
const SLIDE = { duration: 450, easing: Easing.bezier(0.3, 1.3, 0.5, 1), useNativeDriver: true };
const ON_SHADOWS = [[0, 2, PINK_RING], [1.5, 0, PINK_RING], [-1.5, 0, PINK_RING], [0, -1, PINK_RING]];
const OFF_SHADOWS = [[0, 1.5, '#2a0b47']];

function SquishGlyph({ ink }) {
  return (
    <Svg width={28} height={28} viewBox="0 0 26 26">
      <Path d="M3 17 C3 8 8 4 13 4 C18 4 23 8 23 17 C23 21 19 23 13 23 C7 23 3 21 3 17 Z" fill="#ffffff" />
      <Circle cx={9.5} cy={14} r={1.8} fill={ink} />
      <Circle cx={16.5} cy={14} r={1.8} fill={ink} />
      <Path d="M11 17.5 Q13 19 15 17.5" fill="none" stroke={ink} strokeWidth={1.6} strokeLinecap="round" />
    </Svg>
  );
}

function ShopGlyph({ ink }) {
  return (
    <Svg width={30} height={28} viewBox="0 0 28 26">
      <Path d="M4 12 L4 9 C4 5 8 3 14 3 C20 3 24 5 24 9 L24 12 Z" fill="#ffffff" stroke="#ffffff" strokeWidth={2} strokeLinejoin="round" />
      <Rect x={4} y={13} width={20} height={10} rx={3} fill="#ffffff" />
      <Circle cx={14} cy={13} r={2.6} fill={ink} />
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
  const ink = on ? '#c02bd9' : '#6a22d6';
  return (
    <TutTarget name={tut} style={styles.item}>
      <Pressable style={styles.itemIn} onPress={press}>
        <Animated.View style={{ transform: [{ scale }, { rotate }] }}>{id === 'shop' ? <ShopGlyph ink={ink} /> : <SquishGlyph ink={ink} />}</Animated.View>
        <ShadowText style={styles.label} shadows={on ? ON_SHADOWS : OFF_SHADOWS}>
          {label}
        </ShadowText>
      </Pressable>
    </TutTarget>
  );
});

export default function BottomNav({ tab, onTab }) {
  const insets = useSafeAreaInsets();
  const [w, setW] = useState(0);
  const x = useRef(new Animated.Value(tab === 'shop' ? 1 : 0)).current;
  useEffect(() => {
    Animated.timing(x, { toValue: tab === 'shop' ? 1 : 0, ...SLIDE }).start();
  }, [tab, x]);
  const half = (w - 6) / 2;
  return (
    <View>
      <View style={styles.pinkLine} />
      <LinearGradient colors={['#6a22d6', '#45107a']} style={[styles.bar, { paddingBottom: Math.max(insets.bottom, 8) + 6 }]}>
        <View style={styles.track} onLayout={(e) => setW(e.nativeEvent.layout.width)}>
          {w > 0 && (
            <Animated.View pointerEvents="none" style={[styles.pill, { width: half, transform: [{ translateX: x.interpolate({ inputRange: [0, 1], outputRange: [0, half] }) }] }]}>
              <Ringed ring={PINK_RING} lip={4} ringW={2} border={3} radius={18} colors={PINK} style={{ flex: 1 }} innerStyle={{ flex: 1 }} />
            </Animated.View>
          )}
          {TABS.map(([id, label, tut]) => (
            <NavItem key={id} id={id} label={label} tut={tut} on={tab === id} onPress={onTab} />
          ))}
        </View>
      </LinearGradient>
    </View>
  );
}

const styles = StyleSheet.create({
  pinkLine: { height: 3, backgroundColor: '#c02bd9' },
  bar: { borderTopWidth: 3, borderTopColor: '#ffffff', paddingTop: 10, paddingHorizontal: 14 },
  track: {
    flexDirection: 'row',
    height: 56,
    borderRadius: 22,
    backgroundColor: 'rgba(255,255,255,0.12)',
    borderWidth: 2,
    borderColor: 'rgba(255,255,255,0.3)',
  },
  pill: { position: 'absolute', top: 1, bottom: 5, left: 1 },
  item: { flex: 1 },
  itemIn: { flex: 1, flexDirection: 'row', alignItems: 'center', justifyContent: 'center', gap: 9 },
  label: { fontFamily: F.display, fontSize: 19, letterSpacing: 0.3, color: '#ffffff', includeFontPadding: false },
});
