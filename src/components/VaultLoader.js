// "To the treasure vault" (REDESIGN_V9 step 7, 2026-11-16: the user's Squish-Squad-assets.zip, its loading screen
// for going to open a chest): over a chest smash while its page loads. A treasure map on the wood table; a red dotted
// trail draws itself from Home towards the X while the page loads, the player's squishy hopping along it in a gold
// coin; once the smash has painted (`ready`: ChestSmash's onShown) the coin runs to the X, the whole screen (table,
// map, title and tip) zooms into it in a golden glow, and the screen fades off the chest. Shown for at least MIN_MS, so it reads even when the page is quick.
// No progress bar (the user, 2026-11-16: "remove the progress bars" from the loading screens).
//
// The table and the map are pictures (webgame/tools/vault-art.mjs draws them once from the recording's stills); only
// the dots, the coin and the zoom move, on the native driver. Laid out in the recording's frame (639 x 295), scaled
// to fit the screen.
import React, { memo, useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { Animated, Easing, Image, StyleSheet, Text, View, useWindowDimensions } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { Lettering } from '../royal';
import { FONT } from '../royal/theme';
import sfx from '../audio/sfx';
import { selectedId } from '../squad/lobby';
import { stepKeys, useKeyLoop } from './idleLoop';
import { useAfterFirstFrame } from './Skeleton';
import { FRAME, MAP, MAP_PAD, TRAIL, X } from './vaultArt';

const TABLE = require('../../assets/royal/vault-table.jpg');
const MAP_ART = require('../../assets/royal/vault-map.webp');
const GLOW = require('../../assets/royal/vault-glow.png');

const MIN_MS = 1600; // on screen at least this long
const CREEP_MS = 5200; // the trail's creep towards 90% of the way while the page loads
// the longest it waits after its first frame for the table and the map to say they've loaded, before starting anyway
const ART_WAIT_MS = 700;
// The coin's hop (up 170 ms slowing, down 170 ms falling) and the candle's flicker (up 420 ms, down 560 ms): one
// native loop each (idleLoop.js). A loop of a sequence was restarted from JS at every step, so with JS busy on the
// chest smash behind it the coin froze mid-hop and the candle mid-flicker.
const HOP = stepKeys(0, [
  [1, 170, Easing.out(Easing.quad)],
  [0, 170, Easing.in(Easing.quad)],
]);
const FLICK = stepKeys(0, [
  [1, 420, Easing.inOut(Easing.sin)],
  [0, 560, Easing.inOut(Easing.sin)],
]);
const TIPS = [
  'Each chest holds only pals of its own rarity',
  'Rarities: Common, Rare, Epic, Legendary, Rainbow',
  'Smash a Common or Rare chest hard: its first hit can upgrade it',
  'Collect a whole group to earn its Rainbow chest',
];
const ZOOM = 2.6; // how far the map zooms into the X on the way out
const COIN = 30; // the creature's coin, frame units
const N = TRAIL.length;
// the trail's dots show as the coin passes them (the last one just before the X)
const AT = TRAIL.map((_, i) => (i / (N - 1)) * 0.985);

// The picture of the player's squishy (the one picked in the Lobby / on the Menu) for the coin
export function buddyUriOf(creatures, profile) {
  const id = String(selectedId(profile) || '');
  const c = (creatures || []).find((x) => String(x.id) === id);
  return c && c.thumb ? c.thumb.url : null;
}

// The player's squishy in its gold coin (a paw when there's no picture yet)
const Coin = memo(function Coin({ uri, size }) {
  return (
    <LinearGradient colors={['#fff1b0', '#f2c24a', '#c98a1c']} style={[styles.coin, { width: size, height: size, borderRadius: size / 2, padding: size * 0.09 }]}>
      <View style={[styles.coinFace, { borderRadius: size / 2 }]}>
        {uri ? <Image source={{ uri }} style={styles.coinPic} resizeMode="contain" fadeDuration={0} /> : <Text style={[styles.paw, { fontSize: size * 0.42 }]}>🐾</Text>}
      </View>
    </LinearGradient>
  );
});

function VaultLoader({ ready, uri, onDone }) {
  const { width: W, height: H } = useWindowDimensions();
  const s = Math.min(W / FRAME.w, H / FRAME.h);
  const ox = (W - FRAME.w * s) / 2;
  const oy = (H - FRAME.h * s) / 2;
  const fx = (u) => ox + u * s;
  const fy = (u) => oy + u * s;

  const prog = useRef(new Animated.Value(0)).current;
  const zoom = useRef(new Animated.Value(0)).current;
  const out = useRef(new Animated.Value(0)).current;
  const [tip, setTip] = useState(() => Math.floor(Math.random() * TIPS.length));
  const tipFade = useRef(new Animated.Value(1)).current;
  const t0 = useRef(0);
  const leaving = useRef(false);
  const doneRef = useRef(onDone);
  doneRef.current = onDone;

  // On screen (`shown`): its first frame has painted and the table and the map are in (or ART_WAIT_MS after that
  // frame, so a picture that never says it's loaded can't hold it up). Nothing runs on a clock before then: the creep,
  // the hops, the candle, the tips and the MIN_MS count (so the "swoosh" too) all start from it (2026-11-20, the user:
  // "the loading screens, I only hear the audio and when I see them they are half way done"). Only the 180 ms fade in
  // goes at once: it's the tap's answer, and it covers the chest smash being built underneath.
  const painted = useAfterFirstFrame();
  const [art, setArt] = useState({ table: false, map: false, late: false });
  const tableIn = useCallback(() => setArt((a) => (a.table ? a : { ...a, table: true })), []);
  const mapIn = useCallback(() => setArt((a) => (a.map ? a : { ...a, map: true })), []);
  useEffect(() => {
    if (!painted) return undefined;
    const t = setTimeout(() => setArt((a) => ((a.table && a.map) || a.late ? a : { ...a, late: true })), ART_WAIT_MS);
    return () => clearTimeout(t);
  }, [painted]);
  const shown = painted && ((art.table && art.map) || art.late);
  const hop = useKeyLoop(HOP.ms, { at: HOP.at, values: HOP.values, on: shown });
  const flick = useKeyLoop(FLICK.ms, { at: FLICK.at, values: FLICK.values, on: shown });

  // in
  useEffect(() => {
    Animated.timing(out, { toValue: 1, duration: 180, useNativeDriver: true }).start();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  // on screen: the creep and the tips (the tip's text has to change on JS, so they stay a timer: a fade out, the next
  // tip, a fade in, every 2.8 s)
  useEffect(() => {
    if (!shown) return undefined;
    t0.current = Date.now();
    const creep = Animated.timing(prog, { toValue: 0.9, duration: CREEP_MS, easing: Easing.out(Easing.cubic), useNativeDriver: true });
    creep.start();
    const tips = setInterval(() => {
      Animated.timing(tipFade, { toValue: 0, duration: 220, useNativeDriver: true }).start(() => {
        setTip((i) => (i + 1) % TIPS.length);
        Animated.timing(tipFade, { toValue: 1, duration: 260, useNativeDriver: true }).start();
      });
    }, 2800);
    return () => {
      creep.stop();
      clearInterval(tips);
    };
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [shown]);

  // ready (and on long enough): the coin runs to the X, the map zooms into it, the screen fades off the chest
  useEffect(() => {
    if (!ready || !shown || leaving.current) return undefined;
    const go = () => {
      if (leaving.current) return;
      leaving.current = true;
      prog.stopAnimation();
      Animated.timing(prog, { toValue: 1, duration: 260, easing: Easing.out(Easing.quad), useNativeDriver: true }).start(() => {
        sfx.play('swoosh');
        Animated.parallel([
          Animated.timing(zoom, { toValue: 1, duration: 620, easing: Easing.in(Easing.cubic), useNativeDriver: true }),
          Animated.sequence([Animated.delay(430), Animated.timing(out, { toValue: 0, duration: 240, useNativeDriver: true })]),
        ]).start(() => doneRef.current && doneRef.current());
      });
    };
    const wait = MIN_MS - (Date.now() - t0.current);
    if (wait <= 0) {
      go();
      return undefined;
    }
    const t = setTimeout(go, wait);
    return () => clearTimeout(t);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [ready, shown]);

  // the map's box on the screen (its picture has MAP_PAD of torn edge round it) and the X in it
  const mw = (MAP.w + MAP_PAD * 2) * s;
  const mh = (MAP.h + MAP_PAD * 2) * s;
  const mx = (u) => (MAP_PAD + u) * s; // map units -> the map box's own
  const xX = mx(X[0]);
  const xY = mx(X[1]);
  // The way out zooms the whole screen into the X, as a camera would: the table, the candle's light, the map with its
  // trail and coin, the title and the tip, all on one layer (2026-11-17, the user: "only the map zooms in, i need
  // everything there to be zoomed in so it won't look weird"). A scale about the screen's middle, moved back so the X
  // stays where it is.
  const sx = fx(MAP.x - MAP_PAD) + xX;
  const sy = fy(MAP.y - MAP_PAD) + xY;
  const sceneMove = useMemo(
    () => [
      { translateX: zoom.interpolate({ inputRange: [0, 1], outputRange: [0, (1 - ZOOM) * (sx - W / 2)] }) },
      { translateY: zoom.interpolate({ inputRange: [0, 1], outputRange: [0, (1 - ZOOM) * (sy - H / 2)] }) },
      { scale: zoom.interpolate({ inputRange: [0, 1], outputRange: [1, ZOOM] }) },
    ],
    [zoom, sx, sy, W, H],
  );
  // the coin along the trail, hopping
  const coinMove = useMemo(() => {
    const cs = COIN * s;
    const tx = prog.interpolate({ inputRange: AT, outputRange: TRAIL.map(([x]) => mx(x) - cs / 2), extrapolate: 'clamp' });
    const ty = prog.interpolate({ inputRange: AT, outputRange: TRAIL.map(([, y]) => mx(y) - cs * 0.62), extrapolate: 'clamp' });
    return [{ translateX: tx }, { translateY: Animated.add(ty, hop.interpolate({ inputRange: [0, 1], outputRange: [0, -5 * s] })) }];
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [prog, hop, s]);
  const dots = useMemo(
    () =>
      TRAIL.map(([x, y], i) => (
        <Animated.View
          key={i}
          style={[
            styles.dot,
            { left: mx(x) - 1.8 * s, top: mx(y) - 1.8 * s, width: 3.6 * s, height: 3.6 * s, borderRadius: 1.8 * s },
            { opacity: prog.interpolate({ inputRange: [Math.max(0, AT[i] - 0.012), AT[i] + 0.0001], outputRange: [0, 1], extrapolate: 'clamp' }) },
          ]}
        />
      )),
    // eslint-disable-next-line react-hooks/exhaustive-deps
    [prog, s],
  );

  const glowOp = zoom.interpolate({ inputRange: [0, 0.35, 1], outputRange: [0, 0.85, 1] });
  const glowSize = 150 * s;

  return (
    <Animated.View style={[StyleSheet.absoluteFill, styles.root, { opacity: out }]} pointerEvents="auto">
      {/* everything on the screen, zooming as one */}
      <Animated.View style={[StyleSheet.absoluteFill, { transform: sceneMove }]}>
        <Image source={TABLE} resizeMode="cover" style={[StyleSheet.absoluteFill, styles.full]} fadeDuration={0} onLoad={tableIn} />
        {/* the candle's light */}
        <Animated.Image
          source={GLOW}
          fadeDuration={0}
          style={[styles.abs, { left: fx(48) - 34 * s, top: fy(22) - 34 * s, width: 68 * s, height: 68 * s, opacity: flick.interpolate({ inputRange: [0, 1], outputRange: [0.28, 0.5] }) }]}
        />
        {/* the map, its trail and the coin */}
        <View style={[styles.abs, { left: fx(MAP.x - MAP_PAD), top: fy(MAP.y - MAP_PAD), width: mw, height: mh }]}>
          <Image source={MAP_ART} style={styles.full} resizeMode="stretch" fadeDuration={0} onLoad={mapIn} />
          {dots}
          <Animated.Image source={GLOW} fadeDuration={0} style={[styles.abs, { left: xX - glowSize / 2, top: xY - glowSize / 2, width: glowSize, height: glowSize, opacity: glowOp }]} />
          <Animated.View style={[styles.abs, { left: 0, top: 0, transform: coinMove }]}>
            <Coin uri={uri} size={COIN * s} />
          </Animated.View>
        </View>
        {/* the title */}
        <View style={[styles.abs, styles.center, { left: 0, right: 0, top: fy(10) }]} pointerEvents="none">
          <Lettering text="To the treasure vault" variant="gold" size={Math.round(25 * s)} />
        </View>
        {/* the tip, in the gap under the map */}
        <Animated.Text numberOfLines={1} style={[styles.abs, styles.tip, { left: 0, right: 0, top: fy(262), fontSize: 9.6 * s, opacity: tipFade }]}>
          <Text style={styles.tipHead}>Tip: </Text>
          {TIPS[tip]}
        </Animated.Text>
      </Animated.View>
    </Animated.View>
  );
}

const styles = StyleSheet.create({
  root: { backgroundColor: '#8a5a32', zIndex: 80, elevation: 80, overflow: 'hidden' },
  // (width and height too: on web an Image without them takes the picture's own size)
  full: { width: '100%', height: '100%' },
  abs: { position: 'absolute' },
  center: { alignItems: 'center' },
  dot: { position: 'absolute', backgroundColor: '#d0402e' },
  coin: { alignItems: 'stretch', justifyContent: 'center', shadowColor: '#3a1e08', shadowOpacity: 0.45, shadowRadius: 3, shadowOffset: { width: 0, height: 2 }, elevation: 3, borderWidth: 1, borderColor: '#8a5a1a' },
  coinFace: { flex: 1, backgroundColor: '#fff6e2', overflow: 'hidden', alignItems: 'center', justifyContent: 'center', borderWidth: 1, borderColor: '#b8801c' },
  coinPic: { width: '96%', height: '96%' },
  paw: { textAlign: 'center' },
  tip: { textAlign: 'center', fontFamily: FONT.bodyHeavy, color: '#fff6e2', textShadowColor: '#3a1e08', textShadowOffset: { width: 0, height: 1 }, textShadowRadius: 1 },
  tipHead: { color: '#ffd56b' },
});

export default memo(VaultLoader);
