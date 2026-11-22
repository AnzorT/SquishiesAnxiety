import React, { useCallback, useEffect, useRef, useState } from 'react';
import { Animated, Platform, StyleSheet, View } from 'react-native';
import RigStage from '../hop/RigStage';
import { RaysSpin } from '../components/candy/Decor';
import sfx from '../audio/sfx';
import ART from '../stack/art';

// The result card's three characters (the user, 2026-11-17: "i want a genuine character there that is grayed and
// once they are filled their color changes and they jump from joy, not a fast jump, a slow one and they show happy
// animations"): the design's live rigs, drawn by one page (android/app/src/main/assets/rig/result.html, from
// tools/rig/result.html) laid over the card's row. They pop in grey; at T0 + i × STEP the earned ones fill with colour
// from the feet up and jump for joy, slowly, then keep playing happy moves, with the gold rays behind them; a missed
// one sighs and stays grey. The card's stars, sounds and coins start when the page has drawn the three (`onGo(true)`);
// if it can't (a rig that won't load, or too slow), `onGo(false)` and the card shows its stills instead. While the
// page loads (a moment on a phone), each one's cut-out (stack/art.js) stands in as a soft grey shape.

export const RIGS_OK = Platform.OS === 'android' || Platform.OS === 'web';
const CALLS = ['cast', 'run'];
// the page is given this long to draw the three, from the card opening
const WAIT_MS = 4000;
// the WebView is made once the card has sprung up and settled (PERF 2026-11-20: making one holds the UI thread for
// 0.1-0.3 s on the Galaxy A16; made 160 ms in, it froze the card mid-spring and the screen read 41-45 fps; the grey
// shapes stand in meanwhile, and the stars still wait for the characters)
const MOUNT_MS = 650;
// the grey shapes fade in only if the page is still loading by then (no flash on a fast one)
const SHAPES_MS = 380;

// where the three stand (fractions of the row's width), and the row: TW × TH, the characters' most width and height
// (the middle one bigger), and the page's room past the row (BX each side, BT above for the jump, BB below); sized for
// the sideways screen's one-column card
const AT = [0.17, 0.5, 0.83];
const L = { TW: 300, TH: 88, W: [62, 74, 62], H: [70, 84, 70], BX: 36, BT: 76, BB: 22 };

// Three rig keys for a result: `want`'s, any missing ones topped up from `pool` (no repeats while there are others),
// or null with none at all.
export function trioOf(want, pool = []) {
  const used = new Set(want.filter(Boolean));
  const spare = [...new Set(pool.filter((k) => k && !used.has(k)))];
  const out = [0, 1, 2].map((i) => want[i] || spare.shift() || null);
  const any = out.find(Boolean);
  return any ? out.map((k) => k || any) : null;
}

export default function Trio({ keys, stars, T0, STEP, onGo }) {
  const stage = useRef(null);
  const [on, setOn] = useState(false);
  const went = useRef(false);
  const tag = useRef(`${keys.join(',')}:${Date.now()}`).current;
  const glow = useRef([0, 1, 2].map(() => new Animated.Value(0))).current;
  const shapes = useRef(new Animated.Value(0)).current;
  const goRef = useRef(onGo);
  goRef.current = onGo;
  const go = (ok) => {
    if (went.current) return;
    went.current = true;
    goRef.current && goRef.current(ok);
  };

  useEffect(() => {
    Animated.timing(shapes, { toValue: 1, duration: 260, delay: SHAPES_MS, useNativeDriver: true }).start();
    const a = setTimeout(() => setOn(true), MOUNT_MS);
    const b = setTimeout(() => go(false), WAIT_MS);
    return () => {
      clearTimeout(a);
      clearTimeout(b);
    };
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const onReady = useCallback(() => {
    const list = keys.map((key, i) => ({ id: `r${i}`, key, W: L.W[i], H: L.H[i], x: L.BX + L.TW * AT[i], y: L.BT + L.TH - 4 }));
    stage.current && stage.current.cast(list, tag);
  }, [keys, tag]);
  const onCast = useCallback(
    (m) => {
      if (went.current || m.tag !== tag) return;
      if (!m.ok) {
        go(false);
        return;
      }
      stage.current && stage.current.run([0, 1, 2].map((i) => ({ id: `r${i}`, at: T0 + i * STEP, earned: i < stars })));
      go(true);
      // (the grey shapes give way to the characters popping in)
      shapes.stopAnimation();
      Animated.timing(shapes, { toValue: 0, duration: 220, useNativeDriver: true }).start();
      // the gold rays behind each earned one, as its colour fills in
      Animated.parallel(
        glow.slice(0, stars).map((v, i) => Animated.timing(v, { toValue: 1, duration: 520, delay: T0 + i * STEP + 320, useNativeDriver: true })),
      ).start();
    },
    // eslint-disable-next-line react-hooks/exhaustive-deps
    [tag, stars, T0, STEP],
  );
  // the page says when one takes off
  const onEvent = useCallback((m) => {
    if (m.type === 'jump') sfx.play('sd_hop');
  }, []);

  return (
    <View style={{ width: L.TW, height: L.TH }}>
      {[0, 1, 2].map((i) => {
        const S = Math.round(L.W[i] * 1.9);
        return i < stars ? (
          <Animated.View
            key={i}
            pointerEvents="none"
            style={[
              styles.rays,
              { left: L.TW * AT[i] - S / 2, top: L.TH - 4 - L.H[i] * 0.48 - S / 2, width: S, height: S },
              { opacity: glow[i], transform: [{ scale: glow[i].interpolate({ inputRange: [0, 1], outputRange: [0.4, 1] }) }] },
            ]}
          >
            <RaysSpin size={S} color="#ffe45c" opacity={0.55} />
          </Animated.View>
        ) : null;
      })}
      {keys.map((k, i) => {
        const a = ART[k];
        if (!a) return null;
        const w = Math.min(L.W[i], L.H[i] / a.ar);
        const h = w * a.ar;
        return <Animated.Image key={`p${i}`} source={a.src} style={[styles.shape, { left: L.TW * AT[i] - w / 2, top: L.TH - 4 - h, width: w, height: h, opacity: shapes }]} />;
      })}
      {on ? (
        <RigStage
          ref={stage}
          page="result"
          calls={CALLS}
          onReady={onReady}
          onCast={onCast}
          onEvent={onEvent}
          onFail={() => go(false)}
          style={{ position: 'absolute', left: -L.BX, top: -L.BT, width: L.TW + 2 * L.BX, height: L.TH + L.BT + L.BB }}
        />
      ) : null}
    </View>
  );
}

const styles = StyleSheet.create({
  rays: { position: 'absolute', alignItems: 'center', justifyContent: 'center' },
  shape: { position: 'absolute', tintColor: '#dccfbf' },
});
