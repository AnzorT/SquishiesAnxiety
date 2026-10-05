import React, { memo, useEffect, useMemo, useRef, useState } from 'react';
import { Animated, Easing, Platform, Pressable, StatusBar, StyleSheet, Text, View, useWindowDimensions } from 'react-native';
import Svg, { Path } from 'react-native-svg';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { candyFonts } from '../theme/candyTheme';
import { measureTarget, targetRect, useTutorialStore } from './store';

// The coach-mark overlay (the design's squish-guide.js): dims the app, cuts
// a hole around the target, pulses a ring around it, shows an animated hand
// (tap / hold / two-finger twist) and a caption bubble with an optional
// progress bar, note and button. `card` mode is a centred card (the level
// badge, a title, text, a list, buttons); `banner` a non-blocking bubble at
// the top. Rendered once at the app root (App.js), above every screen.

const T = {
  ink: '#4a1a73',
  paper: '#fff5fb',
  acc: '#ff4fbf',
  accInk: '#ffffff',
  soft: '#8a5bb5',
  dim: 'rgba(22,7,46,0.68)',
};
const HAND_D =
  'M24 17A6 6 0 0 1 36 17L36 42C37 39 41 37.5 44 39C47.4 40.4 48.4 44 47.4 47C48.4 44 51.4 42.4 54.4 43.6C57.8 45 58.8 48.4 57.8 51.6C59.4 49.4 62.6 48.8 64.8 50.6C67.4 52.6 67.8 55.8 67 59L65.4 69C63.8 81.4 54.8 90.6 42.8 90.6L35.8 90.6C23.4 90.6 15.2 81.6 13.8 69.2L12.8 60.6L5.8 50.6C2.8 46.2 9.2 41.6 12.8 46.2L19.4 55.2C20.6 56.8 22.2 57.4 24 57.4Z';

function HandSvg() {
  return (
    <Svg viewBox="0 0 72 96" width={46} height={61}>
      <Path d={HAND_D} fill="#ffffff" stroke={T.ink} strokeWidth={3.5} strokeLinejoin="round" />
    </Svg>
  );
}

const loop = (v, duration, easing = Easing.inOut(Easing.ease)) =>
  Animated.loop(Animated.sequence([Animated.timing(v, { toValue: 1, duration: duration / 2, easing, useNativeDriver: true }), Animated.timing(v, { toValue: 0, duration: duration / 2, easing, useNativeDriver: true })]));

// sgTap / sgHold: the hand presses down; sgRing: a ring blooms from the tip.
function Hand({ kind }) {
  const press = useRef(new Animated.Value(0)).current;
  const ring = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const a = loop(press, kind === 'hold' ? 2400 : 1200);
    const r = Animated.loop(Animated.timing(ring, { toValue: 1, duration: kind === 'hold' ? 2400 : 1200, easing: Easing.out(Easing.quad), useNativeDriver: true }));
    a.start();
    r.start();
    return () => {
      a.stop();
      r.stop();
    };
  }, [kind, press, ring]);
  if (kind === 'two') return <TwoHands />;
  const translateY = press.interpolate({ inputRange: [0, 1], outputRange: [0, 9] });
  const scale = press.interpolate({ inputRange: [0, 1], outputRange: [1, 0.9] });
  return (
    <View style={styles.hand} pointerEvents="none">
      <Animated.View
        style={[
          styles.handRing,
          { opacity: ring.interpolate({ inputRange: [0, 1], outputRange: [0.95, 0] }), transform: [{ scale: ring.interpolate({ inputRange: [0, 1], outputRange: [0.5, 1.7] }) }] },
        ]}
      />
      <Animated.View style={{ transform: [{ translateY }, { scale }] }}>
        <HandSvg />
      </Animated.View>
    </View>
  );
}

// sgTwistL / sgTwistR
function TwoHands() {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const a = loop(t, 1800);
    a.start();
    return () => a.stop();
  }, [t]);
  const left = {
    transform: [
      { translateX: t.interpolate({ inputRange: [0, 1], outputRange: [0, -14] }) },
      { translateY: t.interpolate({ inputRange: [0, 1], outputRange: [0, 14] }) },
      { rotate: t.interpolate({ inputRange: [0, 1], outputRange: ['-10deg', '-40deg'] }) },
    ],
  };
  const right = {
    transform: [
      { translateX: t.interpolate({ inputRange: [0, 1], outputRange: [0, 14] }) },
      { translateY: t.interpolate({ inputRange: [0, 1], outputRange: [0, -14] }) },
      { rotate: t.interpolate({ inputRange: [0, 1], outputRange: ['10deg', '40deg'] }) },
    ],
  };
  return (
    <View style={styles.hand} pointerEvents="none">
      <Animated.View style={[{ position: 'absolute', left: -40, top: 6 }, left]}>
        <HandSvg />
      </Animated.View>
      <Animated.View style={[{ position: 'absolute', left: 30, top: -6 }, right]}>
        <HandSvg />
      </Animated.View>
    </View>
  );
}

function Button({ label, primary = true, onPress }) {
  return (
    <Pressable onPress={onPress} style={({ pressed }) => [styles.btn, primary ? styles.btnPrimary : styles.btnPlain, pressed && { transform: [{ translateY: 2 }] }]}>
      <Text style={[styles.btnText, primary ? { color: T.accInk } : { color: T.ink }]}>{label}</Text>
    </Pressable>
  );
}

function ProgressBar({ value, style }) {
  return (
    <View style={[styles.prog, style]}>
      <View style={[styles.progFill, { width: `${Math.round(Math.max(0, Math.min(1, value)) * 100)}%` }]} />
    </View>
  );
}

// the caption: title, text, progress, note, a button
function Bubble({ ui, width, onAction, style }) {
  return (
    <View style={[styles.bubble, { width }, style]} pointerEvents="box-none">
      {ui.title ? <Text style={styles.bubbleTitle}>{ui.title}</Text> : null}
      {ui.text ? <Text style={styles.bubbleText}>{ui.text}</Text> : null}
      {ui.progress != null ? <ProgressBar value={ui.progress} /> : null}
      {ui.note ? <Text style={styles.note}>{ui.note}</Text> : null}
      {ui.next ? (
        <View style={styles.bubbleRow}>
          <Button label={ui.next} onPress={() => onAction(ui.onNext)} />
        </View>
      ) : null}
    </View>
  );
}

const POP_IN = { friction: 7, tension: 140, useNativeDriver: true };
function PopIn({ children, style }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    Animated.spring(t, { toValue: 1, ...POP_IN }).start();
  }, [t]);
  return (
    <Animated.View style={[style, { opacity: t, transform: [{ scale: t.interpolate({ inputRange: [0, 1], outputRange: [0.7, 1] }) }] }]} pointerEvents="box-none">
      {children}
    </Animated.View>
  );
}

// The level badge: LEVEL n in a pink disc, bobbing, over slowly turning rays.
function LevelBadge({ level }) {
  const spin = useRef(new Animated.Value(0)).current;
  const bob = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const a = Animated.loop(Animated.timing(spin, { toValue: 1, duration: 9000, easing: Easing.linear, useNativeDriver: true }));
    const b = loop(bob, 1800);
    a.start();
    b.start();
    return () => {
      a.stop();
      b.stop();
    };
  }, [spin, bob]);
  const rays = useMemo(() => Array.from({ length: 15 }, (_, i) => i * 24), []);
  return (
    <View style={styles.lvl}>
      <Animated.View style={[styles.lvlRays, { transform: [{ rotate: spin.interpolate({ inputRange: [0, 1], outputRange: ['0deg', '360deg'] }) }] }]}>
        {rays.map((deg) => (
          <View key={deg} style={[styles.lvlRay, { transform: [{ rotate: `${deg}deg` }] }]} />
        ))}
      </Animated.View>
      <Animated.View style={[styles.lvlDisc, { transform: [{ translateY: bob.interpolate({ inputRange: [0, 1], outputRange: [0, -6] }) }] }]}>
        <Text style={styles.lvlSmall}>LEVEL</Text>
        <Text style={styles.lvlBig}>{level}</Text>
      </Animated.View>
    </View>
  );
}

function Card({ ui, onAction, winW }) {
  const w = Math.min(ui.width || 340, winW - 28);
  return (
    <View style={styles.cardWrap} pointerEvents="auto">
      <Pressable style={[StyleSheet.absoluteFill, { backgroundColor: T.dim }]} />
      <PopIn style={{ width: w }}>
        <View style={styles.card}>
          {ui.level ? <LevelBadge level={ui.level} /> : null}
          {ui.badge ? (
            <View style={styles.badge}>
              <Text style={styles.badgeText}>{ui.badge}</Text>
            </View>
          ) : null}
          {ui.title ? <Text style={styles.cardTitle}>{ui.title}</Text> : null}
          {ui.text ? <Text style={styles.cardText}>{ui.text}</Text> : null}
          {ui.items ? (
            <View style={styles.items}>
              {ui.items.map((it, i) => (
                <View key={i} style={styles.item}>
                  <View style={[styles.itemIcon, it.color ? { backgroundColor: it.color } : null]}>
                    <Text style={styles.itemIconText}>{it.icon || ''}</Text>
                  </View>
                  <View style={{ flex: 1 }}>
                    <Text style={styles.itemTitle}>{it.title}</Text>
                    {it.desc ? <Text style={styles.itemDesc}>{it.desc}</Text> : null}
                  </View>
                </View>
              ))}
            </View>
          ) : null}
          {ui.buttons && ui.buttons.length ? (
            <View style={styles.cardButtons}>
              {ui.buttons.map((b, i) => (
                <Button key={i} label={b.label} primary={b.primary !== false && i === 0} onPress={() => onAction(b.next, b)} />
              ))}
            </View>
          ) : null}
        </View>
      </PopIn>
    </View>
  );
}

// One of the four dim rectangles around the hole: it swallows taps outside
// the target (unless the step doesn't block).
const DimPanel = memo(function DimPanel({ block, dim, style }) {
  return <Pressable style={[styles.panel, { backgroundColor: dim }, style]} pointerEvents={block ? 'auto' : 'none'} />;
});

// On Android, measureInWindow() reports y from below the status bar (React
// Native subtracts the window's visible frame), while this overlay starts at
// the very top under the translucent status bar — so the bar's height goes
// back on.
const Y_FIX = Platform.OS === 'android' ? StatusBar.currentHeight || 0 : 0;

function Spot({ ui, onAction, winW, winH, topInset, yFix }) {
  // a target that is mounted but off screen (a neighbouring card in the
  // pager) counts as absent
  const m = targetRect(ui.target);
  const measured = m ? { ...m, y: m.y + yFix } : null;
  const rect = measured && measured.y + measured.h > topInset && measured.y < winH && measured.x + measured.w > 0 && measured.x < winW ? measured : null;
  const glow = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const a = loop(glow, 1400);
    a.start();
    return () => a.stop();
  }, [glow]);
  // follow the target (a card paging in, a list scrolling)
  useEffect(() => {
    if (!ui.target) return undefined;
    measureTarget(ui.target);
    const iv = setInterval(() => measureTarget(ui.target), 250);
    return () => clearInterval(iv);
  }, [ui.target]);

  const bw = Math.min(ui.width || 300, winW - 24);
  const block = ui.block !== false;
  const dim = block ? T.dim : 'transparent';
  const Panel = ({ style }) => <DimPanel block={block} dim={dim} style={style} />;

  if (!rect) {
    // the target isn't on screen (yet): a banner at the top, and nothing
    // blocked so the player can page/scroll to it
    return (
      <View style={StyleSheet.absoluteFill} pointerEvents="box-none">
        <PopIn style={{ position: 'absolute', left: (winW - bw) / 2, top: topInset + (ui.bannerTop || 16) }}>
          <Bubble ui={ui} width={bw} onAction={onAction} />
        </PopIn>
      </View>
    );
  }

  const pad = ui.pad ?? 8;
  const x0 = Math.max(0, rect.x - pad);
  const y0 = Math.max(0, rect.y - pad);
  const x1 = Math.min(winW, rect.x + rect.w + pad);
  const y1 = Math.min(winH, rect.y + rect.h + pad);
  const hx = rect.x + rect.w * (ui.handX ?? 0.5);
  const hy = rect.y + rect.h * (ui.handY ?? 0.5);
  const bh = ui.bubbleH || 120;
  const below = winH - y1;
  const above = y0;
  let top = ui.place === 'top' || (ui.place !== 'bottom' && below < bh + 70 && above > below) ? y0 - bh - 16 : y1 + (ui.hand ? 64 : 16);
  top = Math.max(topInset + 8, Math.min(winH - bh - 8, top));
  const left = Math.max(12, Math.min(winW - bw - 12, rect.x + rect.w / 2 - bw / 2));
  const radius = Math.min(ui.radius ?? 16, (x1 - x0) / 2, (y1 - y0) / 2);

  return (
    <View style={StyleSheet.absoluteFill} pointerEvents="box-none">
      <Panel style={{ left: 0, top: 0, width: winW, height: y0 }} />
      <Panel style={{ left: 0, top: y1, width: winW, height: Math.max(0, winH - y1) }} />
      <Panel style={{ left: 0, top: y0, width: x0, height: y1 - y0 }} />
      <Panel style={{ left: x1, top: y0, width: Math.max(0, winW - x1), height: y1 - y0 }} />
      {ui.ring !== false ? (
        <Animated.View
          pointerEvents="none"
          style={[styles.ring, { left: x0, top: y0, width: x1 - x0, height: y1 - y0, borderRadius: radius, opacity: glow.interpolate({ inputRange: [0, 1], outputRange: [0.55, 1] }) }]}
        />
      ) : null}
      {ui.hand ? (
        <View pointerEvents="none" style={{ position: 'absolute', left: hx - 18, top: hy - 6 }}>
          <Hand kind={ui.hand} />
        </View>
      ) : null}
      <PopIn style={{ position: 'absolute', left, top }}>
        <Bubble ui={ui} width={bw} onAction={onAction} />
      </PopIn>
    </View>
  );
}

// `onAction(next, button)` — the step the pressed button moves to.
// `host`: a screen that draws the guide inside its own container (the Crib,
// whose landscape mode is a rotated view) mounts one with its name and
// reports `host` to the store while it's up; the root one (host null)
// stands down meanwhile. A hosted guide's targets are already in the
// container's coordinates (TutTarget's `host`), so no status-bar fix-up.
function TutorialGuide({ onAction, host = null }) {
  const { ui, host: current } = useTutorialStore();
  const win = useWindowDimensions();
  // the layer's own size: on Android the window height can leave the
  // navigation bar out, and the dim has to reach the bottom edge
  const [size, setSize] = useState(null);
  const winW = size ? size.width : win.width;
  const winH = size ? size.height : win.height;
  const insetTop = useSafeAreaInsets().top;
  if (!ui || (current || null) !== host) return null;
  const topInset = host ? 0 : insetTop;
  return (
    <View style={styles.layer} pointerEvents="box-none" onLayout={(e) => setSize(e.nativeEvent.layout)}>
      {ui.mode === 'card' ? (
        <Card ui={ui} onAction={onAction} winW={winW} />
      ) : (
        <Spot ui={ui.mode === 'banner' ? { ...ui, target: null, block: false, hand: null } : ui} onAction={onAction} winW={winW} winH={winH} topInset={topInset} yFix={host ? 0 : Y_FIX} />
      )}
    </View>
  );
}

export default memo(TutorialGuide);

const styles = StyleSheet.create({
  layer: { ...StyleSheet.absoluteFillObject, zIndex: 90, elevation: 90 },
  panel: { position: 'absolute' },
  ring: {
    position: 'absolute',
    borderWidth: 4,
    borderColor: T.acc,
    shadowColor: T.acc,
    shadowOpacity: 1,
    shadowRadius: 12,
    shadowOffset: { width: 0, height: 0 },
  },
  hand: { width: 46, height: 61 },
  handRing: { position: 'absolute', left: 4, top: -6, width: 28, height: 28, borderRadius: 14, borderWidth: 3, borderColor: T.acc },
  bubble: {
    padding: 14,
    borderRadius: 20,
    backgroundColor: T.paper,
    borderWidth: 3,
    borderColor: T.ink,
    gap: 6,
    shadowColor: '#000',
    shadowOpacity: 0.35,
    shadowRadius: 14,
    shadowOffset: { width: 0, height: 8 },
    elevation: 10,
  },
  bubbleTitle: { fontFamily: candyFonts.display, fontSize: 17, color: T.ink, includeFontPadding: false },
  bubbleText: { fontFamily: candyFonts.body, fontSize: 13, lineHeight: 18, color: T.soft },
  bubbleRow: { flexDirection: 'row', justifyContent: 'flex-end', marginTop: 2 },
  note: { fontFamily: candyFonts.bodyBlack, fontSize: 12, color: T.ink },
  prog: { height: 10, borderRadius: 6, borderWidth: 2, borderColor: T.ink, backgroundColor: '#fff', overflow: 'hidden' },
  progFill: { height: '100%', backgroundColor: T.acc },
  btn: { borderWidth: 3, borderColor: T.ink, borderRadius: 999, paddingVertical: 8, paddingHorizontal: 18, shadowColor: T.ink, shadowOpacity: 1, shadowRadius: 0, shadowOffset: { width: 0, height: 4 }, elevation: 3 },
  btnPrimary: { backgroundColor: T.acc },
  btnPlain: { backgroundColor: '#fff' },
  btnText: { fontFamily: candyFonts.display, fontSize: 15, includeFontPadding: false },
  cardWrap: { ...StyleSheet.absoluteFillObject, alignItems: 'center', justifyContent: 'center' },
  card: {
    padding: 18,
    paddingBottom: 16,
    borderRadius: 26,
    backgroundColor: T.paper,
    borderWidth: 3,
    borderColor: T.ink,
    alignItems: 'center',
    gap: 10,
    shadowColor: '#000',
    shadowOpacity: 0.4,
    shadowRadius: 20,
    shadowOffset: { width: 0, height: 10 },
    elevation: 12,
  },
  cardTitle: { fontFamily: candyFonts.display, fontSize: 23, color: T.ink, textAlign: 'center', includeFontPadding: false },
  cardText: { fontFamily: candyFonts.body, fontSize: 14, lineHeight: 20, color: T.soft, textAlign: 'center' },
  cardButtons: { flexDirection: 'row', flexWrap: 'wrap', gap: 8, justifyContent: 'center', marginTop: 4 },
  badge: { paddingHorizontal: 12, paddingVertical: 3, borderRadius: 999, backgroundColor: T.acc, borderWidth: 2, borderColor: T.ink },
  badgeText: { fontFamily: candyFonts.bodyBlack, fontSize: 11, letterSpacing: 1.5, color: T.accInk },
  items: { width: '100%', gap: 8, marginTop: 2 },
  item: { flexDirection: 'row', alignItems: 'center', gap: 10, padding: 10, paddingHorizontal: 12, borderRadius: 16, backgroundColor: '#fff', borderWidth: 2.5, borderColor: T.ink },
  itemIcon: { width: 34, height: 34, borderRadius: 17, backgroundColor: T.acc, borderWidth: 2.5, borderColor: T.ink, alignItems: 'center', justifyContent: 'center' },
  itemIconText: { fontFamily: candyFonts.display, fontSize: 15, color: '#fff' },
  itemTitle: { fontFamily: candyFonts.display, fontSize: 15, color: T.ink },
  itemDesc: { fontFamily: candyFonts.body, fontSize: 12, lineHeight: 16, color: T.soft },
  lvl: { width: 108, height: 108, alignItems: 'center', justifyContent: 'center', marginTop: 10, marginBottom: 6 },
  lvlRays: { position: 'absolute', width: 160, height: 160, alignItems: 'center', justifyContent: 'center' },
  lvlRay: { position: 'absolute', width: 14, height: 160, backgroundColor: 'rgba(255,79,191,0.2)', borderRadius: 7 },
  lvlDisc: {
    width: 108,
    height: 108,
    borderRadius: 54,
    backgroundColor: T.acc,
    borderWidth: 4,
    borderColor: T.ink,
    alignItems: 'center',
    justifyContent: 'center',
    shadowColor: T.ink,
    shadowOpacity: 1,
    shadowRadius: 0,
    shadowOffset: { width: 0, height: 5 },
    elevation: 4,
  },
  lvlSmall: { fontFamily: candyFonts.display, fontSize: 13, letterSpacing: 2, color: T.accInk, includeFontPadding: false },
  lvlBig: { fontFamily: candyFonts.display, fontSize: 46, lineHeight: 48, color: T.accInk, includeFontPadding: false },
});
