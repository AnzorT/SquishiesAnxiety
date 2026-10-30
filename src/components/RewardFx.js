import React, { forwardRef, useEffect, useImperativeHandle, useRef, useState } from 'react';
import { Animated, Easing, StyleSheet, View, useWindowDimensions } from 'react-native';
import { RaysSpin } from './candy/Decor';
import GCHEST from '../squad/groupChestArt';
import sfx from '../audio/sfx';

// A reward arriving (the level road's claims, PLAYER_XP.md, and the Shop
// Deals tab's streak and season pass): coins or gems bursting out of the
// prize's icon and flying up to their counter, and a chest dropping in from
// above before it opens.

// Where a view's middle is on screen ({ x, y }), or null if it isn't laid out.
export const centerOf = (ref) =>
  new Promise((done) => {
    const v = ref && ref.current;
    if (!v || !v.measureInWindow) return done(null);
    v.measureInWindow((x, y, w, h) => done(w || h ? { x: x + w / 2, y: y + h / 2 } : null));
  });

// A coin / gem counter's insides. While a reward flies in it holds still
// (`held`, instead of `amount`) and counts up as each piece lands, with a
// bump; only the counter redraws then, not the screen.
// ref: { icon (where the reward flies to), hold(n), add(n), release() }
export function usePurse(ref, amount) {
  const scale = useRef(new Animated.Value(1)).current;
  const icon = useRef(null);
  const [held, setHeld] = useState(null);
  useImperativeHandle(ref, () => ({
    icon,
    hold: (n) => setHeld(n),
    add(n) {
      setHeld((h) => (h == null ? h : h + n));
      scale.setValue(1.22);
      Animated.spring(scale, { toValue: 1, friction: 4, tension: 220, useNativeDriver: true }).start();
    },
    release: () => setHeld(null),
  }));
  return { icon, scale, shown: held == null ? amount : held };
}

// `n` coins or gems (`gem`) flying as `img` from the screen point `from`
// into `purse` (a usePurse counter) on `layer` (a FlyLayer), the counter
// counting up as they land. Without a place to fly from or to, the counter
// just takes them.
export async function flyReward({ layer, from, purse, n, gem, img, onDone }) {
  const to = purse ? await centerOf(purse.icon) : null;
  if (!from || !to || !layer) {
    if (purse) purse.add(n);
    return onDone && onDone();
  }
  const count = Math.max(gem ? 5 : 6, Math.min(gem ? 10 : 12, Math.round(n / (gem ? 10 : 100))));
  let landed = 0;
  let given = 0;
  layer.fly({
    from,
    to,
    img,
    count,
    onArrive: () => {
      landed += 1;
      const part = landed === count ? n - given : Math.floor(n / count);
      given += part;
      purse.add(part);
      sfx.play(gem ? 'sparkle' : 'coin');
    },
    onDone,
  });
}

const BIT = 30;

// One coin or gem's flight, as one smooth path (the user, 2026-10-25: pop
// up, drift a little down, and get magnetised to the counter — no stop):
// a ballistic pop that peaks at POP of the way and then sinks back by up to
// DIP, and a pull toward the counter that starts at PULL and grows
// (^PULL_POW) until it has the bit at the end. Sampled into STEPS points for
// the native driver; `wait` (ms, hidden at the start) staggers the bits
// inside their own paths, so no JS timer can hold one back.
const STEPS = 28;
const POP = 0.26;
const PULL = 0.34;
const PULL_POW = 2.6;
const DIP = 34; // how far it drifts down after the pop, at most
const FLY_MS = 1100;
function flightPath(tx, ty, wait = 0) {
  const a = (-160 + Math.random() * 140) * (Math.PI / 180); // up and out
  const spread = 50 + Math.random() * 60;
  const dx = Math.cos(a) * spread;
  const h = 40 + Math.random() * 40 + Math.max(0, -Math.sin(a)) * 25; // how high it pops
  const g = (2 * h) / (POP * POP);
  const ms = FLY_MS + wait;
  const w = wait / ms;
  const input = [];
  const xs = [];
  const ys = [];
  const scales = [];
  if (w > 0) {
    input.push(0, w * 0.999);
    xs.push(0, 0);
    ys.push(0, 0);
    scales.push(0, 0);
  }
  for (let k = 0; k <= STEPS; k++) {
    const t = k / STEPS;
    const fx = dx * ((1 - Math.exp(-t / 0.22)) / (1 - Math.exp(-1 / 0.22)));
    // up to the peak, then falling — slowing to a stop DIP below it
    const fy = t <= POP ? -g * POP * t + 0.5 * g * t * t : -h + DIP * (1 - Math.exp(-(0.5 * g * (t - POP) * (t - POP)) / DIP));
    const m = t <= PULL ? 0 : Math.pow((t - PULL) / (1 - PULL), PULL_POW);
    input.push(w + (1 - w) * t);
    xs.push(fx * (1 - m) + tx * m);
    ys.push(fy * (1 - m) + ty * m);
    scales.push(t < 0.12 ? 0.3 + (t / 0.12) * 0.9 : t < POP ? 1.2 - ((t - 0.12) / (POP - 0.12)) * 0.15 : 1.05 - Math.pow((t - POP) / (1 - POP), 2) * 0.5);
  }
  return { input, xs, ys, scales, ms };
}

// starts flying as soon as it's on screen
function Bit({ m }) {
  const { input, xs, ys, scales } = m.path;
  useEffect(() => {
    Animated.timing(m.t, { toValue: 1, duration: m.path.ms, easing: Easing.linear, useNativeDriver: true }).start(m.done);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);
  const translateX = m.t.interpolate({ inputRange: input, outputRange: xs });
  const translateY = m.t.interpolate({ inputRange: input, outputRange: ys });
  const scale = m.t.interpolate({ inputRange: input, outputRange: scales });
  return <Animated.Image source={m.img} fadeDuration={0} style={[styles.bit, { left: m.x - BIT / 2, top: m.y - BIT / 2, transform: [{ translateX }, { translateY }, { scale }] }]} />;
}

// A full-screen layer the bits fly over. ref.fly({ from, to, img, count,
// onArrive(i), onDone }): `from` / `to` are screen points (centerOf). The
// bits pop one right after another and each flies in one go.
export const FlyLayer = forwardRef(function FlyLayer(_, ref) {
  const [bits, setBits] = useState([]);
  const box = useRef(null);
  const ids = useRef(0);
  useImperativeHandle(ref, () => ({
    fly({ from, to, img, count, onArrive, onDone }) {
      const go = (o) => {
        let left = count;
        const made = Array.from({ length: count }, (__, i) => {
          const id = ++ids.current;
          return {
            id,
            img,
            x: from.x - o.x,
            y: from.y - o.y,
            path: flightPath(to.x - from.x, to.y - from.y, i * 45 + Math.random() * 30),
            t: new Animated.Value(0),
            done: () => {
              setBits((b) => b.filter((x) => x.id !== id));
              if (onArrive) onArrive(i);
              left -= 1;
              if (!left && onDone) onDone();
            },
          };
        });
        setBits((b) => [...b, ...made]);
      };
      // the layer's own place on screen (it may not start at the top)
      const v = box.current;
      if (v && v.measureInWindow) v.measureInWindow((x, y) => go({ x, y }));
      else go({ x: 0, y: 0 });
    },
  }));
  return (
    <View ref={box} collapsable={false} pointerEvents="none" style={StyleSheet.absoluteFill}>
      {bits.map((m) => (
        <Bit key={m.id} m={m} />
      ))}
    </View>
  );
});

// A chest of `size` from `group` falling from above the screen onto about
// where the chest smash draws its own (a little below the middle, 40% of the
// width): it lands with a thump and a squash, rays come up behind it, then
// onReveal (show the smash, under this) and it fades away (onDone).
export function ChestDrop({ group, size, onReveal, onDone }) {
  const { width, height } = useWindowDimensions();
  const y = useRef(new Animated.Value(-height)).current;
  const squash = useRef(new Animated.Value(0)).current;
  const landed = useRef(new Animated.Value(0)).current;
  const scrim = useRef(new Animated.Value(0)).current;
  const out = useRef(new Animated.Value(1)).current;
  useEffect(() => {
    sfx.play('swoosh');
    Animated.timing(scrim, { toValue: 1, duration: 220, useNativeDriver: true }).start();
    let timer = null;
    Animated.timing(y, { toValue: 0, duration: 620, easing: Easing.in(Easing.quad), useNativeDriver: true }).start(() => {
      sfx.play('boxThump');
      Animated.parallel([
        Animated.sequence([
          Animated.timing(squash, { toValue: 1, duration: 90, useNativeDriver: true }),
          Animated.spring(squash, { toValue: 0, friction: 3.2, tension: 170, useNativeDriver: true }),
        ]),
        Animated.sequence([
          Animated.timing(y, { toValue: -44, duration: 170, easing: Easing.out(Easing.quad), useNativeDriver: true }),
          Animated.timing(y, { toValue: 0, duration: 190, easing: Easing.in(Easing.quad), useNativeDriver: true }),
        ]),
        Animated.timing(landed, { toValue: 1, duration: 300, useNativeDriver: true }),
      ]).start();
      timer = setTimeout(() => {
        if (onReveal) onReveal();
        Animated.timing(out, { toValue: 0, duration: 320, useNativeDriver: true }).start(() => onDone && onDone());
      }, 780);
    });
    return () => clearTimeout(timer);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);
  const art = (GCHEST[group] || GCHEST.snack)[`${size}-grow`] || GCHEST.snack['common-grow'];
  const scaleX = squash.interpolate({ inputRange: [0, 1], outputRange: [1, 1.18] });
  const scaleY = squash.interpolate({ inputRange: [0, 1], outputRange: [1, 0.8] });
  // the art is 480 × 400 with the chest about half its width, its middle at
  // 58% of the height; the smash's chest sits at about 61% of the screen
  const w = Math.min(width * 0.78, 400);
  const h = (w * 400) / 480;
  const cy = height * 0.61;
  return (
    <Animated.View style={[StyleSheet.absoluteFill, { opacity: out }]}>
      <Animated.View style={[StyleSheet.absoluteFill, styles.scrim, { opacity: scrim }]} />
      <Animated.View pointerEvents="none" style={[styles.rays, { left: width / 2 - RAYS / 2, top: cy - RAYS / 2, opacity: landed }]}>
        <RaysSpin size={RAYS} color="#ffe45c" opacity={0.55} />
      </Animated.View>
      <Animated.View pointerEvents="none" style={[styles.shadow, { left: width / 2 - 85, top: cy + h * 0.36, opacity: landed }]} />
      <Animated.Image
        source={art}
        fadeDuration={0}
        resizeMode="contain"
        style={{ position: 'absolute', left: (width - w) / 2, top: cy - h * 0.58, width: w, height: h, transform: [{ translateY: y }, { scaleX }, { scaleY }] }}
      />
    </Animated.View>
  );
}

const RAYS = 460;

const styles = StyleSheet.create({
  bit: { position: 'absolute', width: BIT, height: BIT },
  scrim: { backgroundColor: 'rgba(40,8,80,0.6)' },
  rays: { position: 'absolute', width: RAYS, height: RAYS },
  // under the chest's base
  shadow: { position: 'absolute', width: 170, height: 26, borderRadius: 85, backgroundColor: 'rgba(30,6,60,0.35)' },
});
