import React, { useCallback, useEffect, useRef, useState } from 'react';
import { Animated, Easing, Pressable, StyleSheet, Text, View } from 'react-native';
import { candyColors, candyFonts } from '../theme/candyTheme';
import RoundButton from './candy/RoundButton';
import { SoftPulse } from './candy/Decor';
import TutTarget from '../tutorial/Target';
import { useTutorialStore } from '../tutorial/store';
import { Flame } from './StreakIcons';

// Home's menu button (beside the Crib, shop and settings buttons): it drops
// down the rest (Daily Challenges, the streak, trophies, stats) as a column
// of round buttons with their names, under the button.
//
// It points the player at what's waiting, so they know when it's worth
// opening: the button wears the Daily Challenges' count of rewards to claim,
// or — with none — a flame while today's chest still has a streak riding on
// it. Inside, those items wear the same badges.
//
// Should the tutorial point at one of the items (by its `tut` name), the
// menu opens itself and stays open, so the item is there to point at and tap.
//
// `items`: [{ key, label, variant, icon, onPress, badge, badgeGold, hot, tut }]
// — `badge` a number on the item (gold for the streak's days), `hot` a flame
// on it when there's no number, `tut` its tutorial target name. `anchor` is where the header keeps room for the button:
// { top, right } in this screen's coordinates.

export const MENU_BUTTON = 40;
const ITEM = 42;

// Three candy bars that fold into an ✕ as the menu opens (`t` 0 → 1).
function MenuGlyph({ t }) {
  const turn = (deg) => t.interpolate({ inputRange: [0, 1], outputRange: ['0deg', `${deg}deg`] });
  const shift = (px) => t.interpolate({ inputRange: [0, 1], outputRange: [0, px] });
  const fade = t.interpolate({ inputRange: [0, 0.5], outputRange: [1, 0], extrapolate: 'clamp' });
  return (
    <View style={styles.glyph}>
      <Animated.View style={[styles.bar, { transform: [{ translateY: shift(6) }, { rotate: turn(45) }] }]} />
      <Animated.View style={[styles.bar, { opacity: fade }]} />
      <Animated.View style={[styles.bar, { transform: [{ translateY: shift(-6) }, { rotate: turn(-45) }] }]} />
    </View>
  );
}

function Badge({ n, hot, gold = false }) {
  if (n > 0)
    return (
      <View style={[styles.badge, gold && styles.badgeGold]} pointerEvents="none">
        <Text style={[styles.badgeText, gold && styles.badgeGoldText]}>{n}</Text>
      </View>
    );
  if (hot)
    return (
      <View style={[styles.badge, styles.badgeHot]} pointerEvents="none">
        <Flame size={10} />
      </View>
    );
  return null;
}

function Row({ item, t, i, onPick }) {
  const a = Math.min(0.45, i * 0.07);
  const opacity = t.interpolate({ inputRange: [a, a + 0.35], outputRange: [0, 1], extrapolate: 'clamp' });
  const translateY = t.interpolate({ inputRange: [a, a + 0.55], outputRange: [-(ITEM + 8) * (i + 1) * 0.6, 0], extrapolate: 'clamp' });
  const scale = t.interpolate({ inputRange: [a, a + 0.4, a + 0.55], outputRange: [0.5, 1.06, 1], extrapolate: 'clamp' });
  const press = () => onPick(item);
  const button = (
    <View>
      <RoundButton size={ITEM} variant={item.variant} onPress={press}>
        {item.icon}
      </RoundButton>
      <Badge n={item.badge} hot={item.hot} gold={item.badgeGold} />
    </View>
  );
  return (
    <Animated.View style={[styles.row, { opacity, transform: [{ translateY }, { scale }] }]}>
      <Pressable onPress={press} style={({ pressed }) => [styles.labelRing, pressed && { opacity: 0.8 }]}>
        <View style={styles.label}>
          <Text style={styles.labelText}>{item.label}</Text>
        </View>
      </Pressable>
      {item.tut ? <TutTarget name={item.tut}>{button}</TutTarget> : button}
    </Animated.View>
  );
}

export default function HomeMenu({ items, anchor, badge = 0, hot = false, onOpenChange }) {
  const [open, setOpen] = useState(false);
  // the tutorial's guide points at one of the items: open, and stay open
  const tut = useTutorialStore();
  const target = tut.screen === 'home' && tut.ui && tut.ui.target;
  const forced = !!target && items.some((it) => it.tut === target);
  const shown = open || forced;

  const t = useRef(new Animated.Value(0)).current;
  const [mounted, setMounted] = useState(false);
  useEffect(() => {
    if (shown) setMounted(true);
    Animated.timing(t, {
      toValue: shown ? 1 : 0,
      duration: shown ? 520 : 200,
      easing: shown ? Easing.out(Easing.cubic) : Easing.in(Easing.quad),
      useNativeDriver: true,
    }).start(({ finished }) => {
      if (finished && !shown) setMounted(false);
    });
  }, [shown, t]);
  useEffect(() => {
    if (onOpenChange) onOpenChange(shown);
  }, [shown, onOpenChange]);

  const toggle = useCallback(() => setOpen((o) => !o), []);
  const close = useCallback(() => {
    if (!forced) setOpen(false);
  }, [forced]);
  const pick = useCallback((item) => {
    setOpen(false);
    item.onPress();
  }, []);

  if (!anchor) return null;
  const scrim = t.interpolate({ inputRange: [0, 1], outputRange: [0, 1] });
  const showBadge = !shown;
  return (
    <View style={StyleSheet.absoluteFill} pointerEvents="box-none">
      {mounted ? (
        <Animated.View style={[StyleSheet.absoluteFill, styles.scrim, { opacity: scrim }]} pointerEvents={shown ? 'auto' : 'none'}>
          <Pressable style={StyleSheet.absoluteFill} onPress={close} />
        </Animated.View>
      ) : null}
      <View style={[styles.trigger, { top: anchor.top, right: anchor.right }]}>
        {showBadge && (badge > 0 || hot) ? (
          <SoftPulse to={1.06} halfMs={700}>
            <RoundButton size={MENU_BUTTON} onPress={toggle}>
              <MenuGlyph t={t} />
            </RoundButton>
          </SoftPulse>
        ) : (
          <RoundButton size={MENU_BUTTON} onPress={toggle}>
            <MenuGlyph t={t} />
          </RoundButton>
        )}
        {showBadge ? <Badge n={badge} hot={hot} /> : null}
      </View>
      {mounted ? (
        <View style={[styles.list, { top: anchor.top + MENU_BUTTON + 12, right: anchor.right - (ITEM - MENU_BUTTON) / 2 }]} pointerEvents={shown ? 'box-none' : 'none'}>
          {items.map((item, i) => (
            <Row key={item.key} item={item} t={t} i={i} onPick={pick} />
          ))}
        </View>
      ) : null}
    </View>
  );
}

const styles = StyleSheet.create({
  scrim: { backgroundColor: 'rgba(36,8,72,0.5)' },
  trigger: { position: 'absolute' },
  glyph: { width: 18, height: 16, justifyContent: 'space-between' },
  bar: {
    height: 4,
    borderRadius: 2,
    backgroundColor: '#ffffff',
    shadowColor: candyColors.outlineDeep,
    elevation: 1,
  },
  list: { position: 'absolute', alignItems: 'flex-end', gap: 8 },
  row: { flexDirection: 'row', alignItems: 'center', gap: 8 },
  labelRing: { borderRadius: 999, padding: 2, backgroundColor: candyColors.cardRing, marginBottom: 4 },
  label: { borderRadius: 999, borderWidth: 2, borderColor: '#ffffff', backgroundColor: candyColors.paper, paddingHorizontal: 12, paddingVertical: 5 },
  labelText: { fontFamily: candyFonts.display, fontSize: 13, letterSpacing: 0.6, color: candyColors.ink, includeFontPadding: false },
  badge: {
    position: 'absolute',
    right: -5,
    top: -5,
    minWidth: 18,
    height: 18,
    paddingHorizontal: 3,
    borderRadius: 9,
    backgroundColor: '#e8339f',
    borderWidth: 2,
    borderColor: '#ffffff',
    alignItems: 'center',
    justifyContent: 'center',
  },
  badgeHot: { backgroundColor: '#ffd23a' },
  badgeGold: { backgroundColor: '#ffd23a' },
  badgeGoldText: { color: '#7a3d00' },
  badgeText: { fontFamily: candyFonts.bodyBlack, fontSize: 10, color: '#ffffff', includeFontPadding: false },
});
