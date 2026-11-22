import React, { memo, useCallback, useEffect, useRef, useState } from 'react';
import { Animated, Dimensions, Easing, Image, Keyboard, Platform, StyleSheet, Text, TextInput, View, useWindowDimensions } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import Pressable from '../../components/Pressable';
import RigCreature from '../../components/RigCreature';
import { phaseLoop } from '../../components/idleLoop';
import sfx from '../../audio/sfx';
import { Icon, InkText, Plaque, FONT, ICON, INK, WOOD } from '../../royal';

// The sign-in screens' look (AuthScreen, VerifyEmailScreen), 2026-11-20: the front door of the same game. Behind
// everything, one picture of the Main Menu's house (assets/auth/make-art.mjs: the menu's own scene, softened); on top,
// the menu's wood and gold (src/royal): a wood panel like Settings', the Shop's gold-on-wood tabs, the gold PLAY-style
// button, Settings' dark inset fields. Along the top, Mittens beside the plush SQUISH SQUAD logo the game intro drops in.
//
// Performance (a weak phone): one full-screen picture over a plain colour (no full-screen SVG or gradient); the panel is
// native views; the only loops are native-driver ones (the button's glint, the mode pill's spring, the waiting dots);
// one live rig (a WebView), shown as a still until it has drawn, and paused while the keyboard is up.

const HOUSE = require('../../../assets/auth/house-bg.jpg');
const LOGO = require('../../../assets/auth/logo.png');
// (Mittens at rest, drawn by the rig's own page, until the live rig has drawn: no empty box first)
const MITTENS = require('../../../assets/auth/mittens.png');
const LOGO_RATIO = 981 / 133; // logo.png's pixels (make-art.mjs trims it to the letters: update this if it's drawn again)

export const CREAM = WOOD.cream; // '#fff6e2'
export const GOLD_TXT = '#ffd650';
const PLACEHOLDER = 'rgba(255,236,200,0.55)';
// (web: the field's own gold rim shows it's being typed in, not the browser's focus ring)
const WEB_INPUT = Platform.OS === 'web' ? { outlineStyle: 'none' } : null;

// Sizes for the phone's height: 360 (small), 384 (the test phone), 412 (tall). Everything fits without scrolling.
export function useAuthSizes() {
  const { width, height } = useWindowDimensions();
  const W = Math.max(width, height), H = Math.min(width, height);
  const t = H < 376 ? 0 : H < 400 ? 1 : 2;
  const pick = (a, b, c) => [a, b, c][t];
  return {
    W,
    H,
    top: pick(6, 9, 10), // above the header (and under the panel at least)
    head: pick(52, 58, 64), // the header row (Mittens' box)
    logoW: pick(262, 296, 324),
    // (2026-11-21: was 560/580/600, "too much in the width": now a little wider than the logo row above it)
    cardW: Math.min(pick(450, 470, 490), W - 28),
    padH: pick(14, 16, 18),
    padT: pick(10, 12, 14),
    padB: pick(12, 14, 16),
    gap: pick(7, 9, 11),
    track: pick(30, 34, 36),
    input: pick(36, 40, 42),
    font: pick(14, 15, 15),
    btn: pick(38, 42, 46),
    btnFont: pick(17, 19, 20),
    social: pick(32, 36, 38),
  };
}

// a press that clicks like every other button (src/components/Pressable plays it; Plaque's own press doesn't)
export const tap = (fn) => () => {
  sfx.play('tap');
  fn();
};

// The backdrop: the house, the one full-screen picture (its average colour under it while it decodes).
export const AuthBg = memo(function AuthBg() {
  return <Image source={HOUSE} resizeMode="cover" fadeDuration={0} style={styles.bg} />;
});
export const ROOT_BG = '#94a280';

// A line that fades up whenever its text changes (not on the first draw).
export function useFadeUp(text) {
  const t = useRef(new Animated.Value(1)).current;
  const first = useRef(true);
  useEffect(() => {
    if (first.current) {
      first.current = false;
      return;
    }
    t.setValue(0);
    Animated.timing(t, { toValue: 1, duration: 260, easing: Easing.out(Easing.quad), useNativeDriver: true }).start();
  }, [text, t]);
  return { opacity: t, transform: [{ translateY: t.interpolate({ inputRange: [0, 1], outputRange: [6, 0] }) }] };
}

// Mittens (live) beside the logo. `paused`: the rig stops drawing (the keyboard is up).
export function AuthHeader({ z, paused }) {
  const [drawn, setDrawn] = useState(false);
  const onMounted = useCallback(() => setDrawn(true), []);
  const m = z.head;
  return (
    <View style={[styles.header, { height: m }]}>
      <View style={{ width: m, height: m }}>
        <View style={[styles.floor, { width: m * 0.6, left: m * 0.2, height: m * 0.12 }]} />
        {!drawn ? <Image source={MITTENS} resizeMode="contain" fadeDuration={0} style={styles.still} /> : null}
        <RigCreature creatureKey="mittens" rigShadow={false} paused={paused} onMounted={onMounted} style={StyleSheet.absoluteFill} />
      </View>
      <Image source={LOGO} fadeDuration={0} style={{ width: z.logoW, height: z.logoW / LOGO_RATIO }} />
    </View>
  );
}

// The panel (Settings' wood panel).
export function Card({ z, width, style, children }) {
  return (
    <Plaque variant="vel" radius={22} rim={3.5} ring={2} lip={4} style={[styles.card, { width: width || z.cardW, paddingHorizontal: z.padH, paddingTop: z.padT, paddingBottom: z.padB, gap: z.gap }, style]}>
      {children}
    </Plaque>
  );
}

// A labelled field: cream small caps over Settings' dark inset input, its rim gold while it's being typed in.
// `right` sits inside the input's right end (the password's Show / Hide).
export function Field({ label, z, right, inputRef, style, onFocus, onBlur, ...input }) {
  const [focus, setFocus] = useState(false);
  return (
    <View style={style}>
      <Text style={styles.label} numberOfLines={1}>
        {label}
      </Text>
      <View>
        <TextInput
          ref={inputRef}
          placeholderTextColor={PLACEHOLDER}
          selectionColor="rgba(255,214,80,0.55)"
          cursorColor={GOLD_TXT}
          underlineColorAndroid="transparent"
          {...input}
          onFocus={(e) => {
            setFocus(true);
            onFocus && onFocus(e);
          }}
          onBlur={(e) => {
            setFocus(false);
            onBlur && onBlur(e);
          }}
          style={[styles.input, WEB_INPUT, { height: z.input, fontSize: z.font }, focus && styles.inputOn, right ? styles.inputRight : null]}
        />
        {right}
      </View>
    </View>
  );
}

// "Show" / "Hide" inside the password field
export function Eye({ shown, onPress }) {
  return (
    <Pressable onPress={onPress} hitSlop={8} style={styles.eye}>
      <Text style={styles.eyeT}>{shown ? 'Hide' : 'Show'}</Text>
    </Pressable>
  );
}

// Log in | Register: the Shop's tabs as one switch, a gold pill springing across a dark inset track. `width`: the
// track's width (known from the card's, so the pill is there on the first frame).
export function ModeSwitch({ z, width, mode, onChange, tabs }) {
  const x = useRef(new Animated.Value(mode === tabs[1][0] ? 1 : 0)).current;
  useEffect(() => {
    Animated.timing(x, { toValue: mode === tabs[1][0] ? 1 : 0, duration: 340, easing: Easing.bezier(0.3, 1.3, 0.5, 1), useNativeDriver: true }).start();
  }, [mode, tabs, x]);
  const half = (width - 2 * TRACK_PAD) / 2;
  return (
    <View style={[styles.track, { height: z.track }]}>
      <Animated.View pointerEvents="none" style={[styles.pill, { width: half, transform: [{ translateX: x.interpolate({ inputRange: [0, 1], outputRange: [0, half] }) }] }]}>
        <Plaque variant="gold" radius={999} rim={2} ring={1.4} lip={2.5} style={StyleSheet.absoluteFill} />
      </Animated.View>
      {tabs.map(([value, label]) => (
        <Pressable key={value} onPress={() => onChange(value)} style={styles.tab}>
          {mode === value ? <Text style={styles.tabOn}>{label}</Text> : <InkText size={16}>{label}</InkText>}
        </Pressable>
      ))}
    </View>
  );
}
const TRACK_PAD = 3;

// a gold tick box (the menu's check) and its label
export function CheckRow({ on, onToggle, label }) {
  return (
    <Pressable onPress={onToggle} hitSlop={6} style={styles.check}>
      {on ? (
        <LinearGradient colors={['#fff1b0', '#ffd650', '#f6a524']} locations={[0, 0.45, 1]} style={[styles.box, styles.boxOn]}>
          <Icon d={ICON.check} size={15} color={INK} width={3.6} drop={false} />
        </LinearGradient>
      ) : (
        <View style={styles.box} />
      )}
      <InkText size={14}>{label}</InkText>
    </Pressable>
  );
}

// — OR — (or, in its place, the error: the row keeps its height, so nothing under it moves)
export function OrRow({ error, style }) {
  const fade = useFadeUp(error);
  return (
    <View style={[styles.orRow, style]}>
      {error ? (
        <Animated.View style={[styles.errWrap, fade]}>
          <ErrorPill text={error} />
        </Animated.View>
      ) : (
        <>
          <View style={styles.orLine} />
          <Text style={styles.orT}>OR</Text>
          <View style={styles.orLine} />
        </>
      )}
    </View>
  );
}

export function ErrorPill({ text, lines = 1 }) {
  return (
    <View style={styles.err}>
      <Text style={styles.errT} numberOfLines={lines}>
        {text}
      </Text>
    </View>
  );
}

// Three dots hopping in turn, in the button while it waits on the server: one native loop.
export function Dots({ size = 10 }) {
  const p = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const loop = phaseLoop(p, 900);
    loop.start();
    return () => loop.stop();
  }, [p]);
  return (
    <View style={[styles.dots, { height: size * 2 }]}>
      {[0, 1, 2].map((i) => {
        const s = i * 0.18;
        const translateY = p.interpolate({ inputRange: [0, s, s + 0.16, s + 0.32, 1], outputRange: [0, 0, -size * 0.7, 0, 0] });
        return <Animated.View key={i} style={[styles.dot, { width: size, height: size, borderRadius: size / 2, transform: [{ translateY }] }]} />;
      })}
    </View>
  );
}

// Keeping the fields in sight above the soft keyboard.
// A landscape keyboard covers more than half the screen. Two kinds:
//  - most phone keyboards (Gboard, Samsung) edit in their own full-screen box in landscape: the field is in that box,
//    its action key goes to the next field / logs in, and the app isn't covered (the keyboard reports no overlap)
//  - one drawn over the app: the window doesn't shrink (the status bar is hidden, so adjustResize is ignored), so the
//    content is lifted until the fields row and the button under it sit above the keyboard's top (never the row past
//    the screen's top; the row before the button if both can't fit)
// `keep()` returns [the fields row, the button] (refs' current views). Returns the lift (a native-driver translateY
// for the content) and whether the keyboard is up.
export function useKeyboardLift(keep) {
  const lift = useRef(new Animated.Value(0)).current;
  const [up, setUp] = useState(false);
  const kbTop = useRef(null); // the keyboard's top on the screen (null: down)
  const keepRef = useRef(keep);
  keepRef.current = keep;
  const to = useCallback(
    (v) => Animated.timing(lift, { toValue: v, duration: 240, easing: Easing.out(Easing.cubic), useNativeDriver: true }).start(),
    [lift],
  );
  const relift = useCallback(() => {
    const top = kbTop.current;
    const [row, btn] = keepRef.current() || [];
    if (top == null || !row) return to(0);
    // where things are with the lift stopped, minus the lift: their places unlifted
    lift.stopAnimation((cur) => {
      row.measureInWindow((rx, ry, rw, rh) => {
        const go = (by, bh) => {
          const rowTop = ry - cur, rowBot = ry + rh - cur, btnBot = by == null ? rowBot : by + bh - cur;
          const L = Math.max(0, Math.min(Math.max(btnBot + 8 - top, rowBot + 4 - top), rowTop - 4));
          to(-L);
        };
        if (btn) btn.measureInWindow((bx, by, bw, bh) => go(by, bh));
        else go(null, 0);
      });
    });
  }, [lift, to]);
  const onShow = useCallback(
    (e) => {
      const c = (e && e.endCoordinates) || {};
      // (Android: screenY is the visible area's bottom, the keyboard's top; a full-screen editor leaves it at the
      // screen's bottom, so nothing moves)
      kbTop.current = c.screenY > 0 ? c.screenY : Dimensions.get('window').height - (c.height || 0);
      setUp(true);
      relift();
    },
    [relift],
  );
  const onHide = useCallback(() => {
    kbTop.current = null;
    setUp(false);
    to(0);
  }, [to]);
  useEffect(() => {
    const ios = Platform.OS === 'ios';
    const a = Keyboard.addListener(ios ? 'keyboardWillShow' : 'keyboardDidShow', onShow);
    const b = Keyboard.addListener(ios ? 'keyboardWillHide' : 'keyboardDidHide', onHide);
    // (web, development: no soft keyboard there; window.__authKeyboard(height) plays one coming up, 0 going down)
    const web = __DEV__ && Platform.OS === 'web' && typeof window !== 'undefined';
    const fake = (h) => (h > 0 ? onShow({ endCoordinates: { screenY: window.innerHeight - h, height: h } }) : onHide());
    if (web) window.__authKeyboard = fake;
    return () => {
      a.remove();
      b.remove();
      if (web && window.__authKeyboard === fake) delete window.__authKeyboard;
    };
  }, [onShow, onHide]);
  return { lift, up, relift };
}

const styles = StyleSheet.create({
  bg: { ...StyleSheet.absoluteFillObject, width: '100%', height: '100%' },
  header: { flexDirection: 'row', alignItems: 'center', justifyContent: 'center', gap: 6 },
  floor: { position: 'absolute', bottom: 1, borderRadius: 999, backgroundColor: 'rgba(40,20,6,0.28)' },
  still: { ...StyleSheet.absoluteFillObject, width: '100%', height: '100%' },
  card: { alignItems: 'stretch', justifyContent: 'flex-start' },
  label: { fontFamily: FONT.bodyBlack, fontSize: 10.5, lineHeight: 13, letterSpacing: 1.2, color: CREAM, marginBottom: 3, marginLeft: 2, textShadowColor: 'rgba(80,40,12,0.75)', textShadowOffset: { width: 0, height: 1 }, textShadowRadius: 0.01 },
  input: {
    borderRadius: 12,
    paddingHorizontal: 12,
    paddingVertical: 0,
    backgroundColor: 'rgba(60,30,10,0.42)',
    borderWidth: 1.5,
    borderColor: 'rgba(255,236,170,0.55)',
    color: '#ffffff',
    fontFamily: FONT.bodyHeavy,
  },
  inputOn: { borderWidth: 2, borderColor: GOLD_TXT, backgroundColor: 'rgba(60,30,10,0.55)' },
  inputRight: { paddingRight: 50 },
  eye: { position: 'absolute', right: 11, top: 0, bottom: 0, justifyContent: 'center' },
  eyeT: { fontFamily: FONT.bodyBlack, fontSize: 12, color: GOLD_TXT },
  track: { flexDirection: 'row', borderRadius: 999, padding: TRACK_PAD, backgroundColor: 'rgba(60,30,10,0.42)', borderWidth: 1.5, borderColor: 'rgba(255,236,170,0.55)' },
  pill: { position: 'absolute', top: TRACK_PAD - 1.5, bottom: TRACK_PAD - 1.5, left: TRACK_PAD - 1.5 },
  tab: { flex: 1, alignItems: 'center', justifyContent: 'center' },
  tabOn: { fontFamily: FONT.display, fontSize: 16, color: INK, includeFontPadding: false },
  check: { flexDirection: 'row', alignItems: 'center', gap: 8, alignSelf: 'center' },
  box: { width: 22, height: 22, borderRadius: 7, borderWidth: 1.6, borderColor: 'rgba(255,236,170,0.7)', backgroundColor: 'rgba(60,30,10,0.42)', alignItems: 'center', justifyContent: 'center' },
  boxOn: { borderColor: INK },
  orRow: { height: 20, flexDirection: 'row', alignItems: 'center', justifyContent: 'center', gap: 10 },
  orLine: { flex: 1, height: 1.5, borderRadius: 1, backgroundColor: 'rgba(255,236,170,0.45)' },
  orT: { fontFamily: FONT.bodyBlack, fontSize: 10.5, letterSpacing: 1.5, color: CREAM, includeFontPadding: false },
  errWrap: { maxWidth: '100%' },
  err: { minHeight: 20, borderRadius: 10, paddingHorizontal: 12, paddingVertical: 2, justifyContent: 'center', backgroundColor: '#d9412c', borderWidth: 1.6, borderColor: '#5a1a08' },
  errT: { fontFamily: FONT.bodyBlack, fontSize: 12, lineHeight: 15, color: '#ffffff', textAlign: 'center', includeFontPadding: false },
  dots: { flexDirection: 'row', alignItems: 'flex-end', gap: 6 },
  dot: { backgroundColor: '#ffffff', borderWidth: 1.6, borderColor: '#6a2c00' },
});
