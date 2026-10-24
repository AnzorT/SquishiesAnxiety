import React, { forwardRef, memo, useEffect, useImperativeHandle, useLayoutEffect, useMemo, useRef, useState } from 'react';
import { Animated, Easing, Image, PanResponder, StyleSheet, View } from 'react-native';
import { FxLayer } from './fx';
import Tile from './Tile';
import { INK, PATCHES, RING } from './theme';

// The puzzle board: n×n candy-button tiles (Tile.js) in their patch colours
// on a light tray (no border lines: the colours alone tell the patches
// apart), ✕ marks and creatures. It draws and animates; the game (SquishdokuScreen)
// decides. Touches come out as
//   onTap(cell)          a tap (place a creature, or toggle a ✕ with the ✕ tool)
//   onMark(cell, on)     a ✕ painted by a drag (✕ tool) or a long press
// and the game answers through the ref:
//   setMark(cell, on)  place(cell)  wrong(cell)  wiggle(cell)
//   intro()  outro()  hopAll()  shake()
// Each cell animates itself (drop, squash, ripple, sulk, hop); one shared
// FxLayer plays the dust, sparks and poofs. Placed creatures are alive: they
// breathe and sway, one does a trick now and then (hop, wiggle, spin, peek),
// they cheer each new creature and flinch at a mistake.

const LONG_PRESS_MS = 380;
const MOVE_SLOP = 8;
const FRAME = 6; // the ring (2.5) + white rim (3.5) round the grid

// how far each cell of a patch is from `from` (steps through the patch):
// the ripple's delays
function distancesInPatch(n, regions, from) {
  const dist = new Map([[from, 0]]);
  const todo = [from];
  while (todo.length) {
    const cell = todo.shift();
    const r = Math.floor(cell / n);
    const c = cell % n;
    for (const [dr, dc] of [[1, 0], [-1, 0], [0, 1], [0, -1]]) {
      const rr = r + dr;
      const cc = c + dc;
      if (rr < 0 || rr >= n || cc < 0 || cc >= n) continue;
      const nb = rr * n + cc;
      if (regions[nb] !== regions[from] || dist.has(nb)) continue;
      dist.set(nb, dist.get(cell) + 1);
      todo.push(nb);
    }
  }
  return dist;
}

const Cell = memo(
  forwardRef(function Cell({ cell, n, size, patch, mark, piece, uri }, ref) {
    const r = Math.floor(cell / n);
    const c = cell % n;
    const intro = useRef(new Animated.Value(0)).current;
    const press = useRef(new Animated.Value(0)).current;
    const flash = useRef(new Animated.Value(0)).current; // 0 -> 1: up and back down
    const flashK = useRef(new Animated.Value(0)).current; // how bright this flash peaks
    const red = useRef(new Animated.Value(0)).current;
    const markT = useRef(new Animated.Value(mark ? 1 : 0)).current;
    const drop = useRef(new Animated.Value(piece ? 1 : 0)).current; // 0 above, 1 landed
    const squash = useRef(new Animated.Value(0)).current; // -1 stretched … 1 squashed
    const hop = useRef(new Animated.Value(0)).current;
    const sulk = useRef(new Animated.Value(0)).current; // the wrong creature's shake
    const gone = useRef(new Animated.Value(0)).current; // the wrong creature popping off
    const breathe = useRef(new Animated.Value(0)).current; // idle: 0 … 1
    const sway = useRef(new Animated.Value(0)).current; // idle: -1 … 1
    const spin = useRef(new Animated.Value(0)).current; // a trick: one turn
    const peek = useRef(new Animated.Value(0)).current; // a trick: lean out and back
    const [wrongKey, setWrongKey] = useState(0);

    // a hop (`height` of the full one), landing with a squash
    const doHop = (delay = 0, height = 1) =>
      Animated.sequence([
        Animated.timing(hop, { toValue: height, duration: 170, delay, easing: Easing.out(Easing.quad), useNativeDriver: true }),
        Animated.timing(hop, { toValue: 0, duration: 170, easing: Easing.in(Easing.quad), useNativeDriver: true }),
        Animated.timing(squash, { toValue: 0.8 * height, duration: 60, useNativeDriver: true }),
        Animated.spring(squash, { toValue: 0, friction: 3, tension: 260, useNativeDriver: true }),
      ]).start();
    const doWiggle = () => {
      squash.setValue(0.9);
      Animated.spring(squash, { toValue: 0, friction: 2.6, tension: 300, useNativeDriver: true }).start();
    };

    // Idle life once placed: breathing and swaying at the creature's own pace
    // (random periods and start, so the board never moves in lockstep).
    useEffect(() => {
      if (!piece) return undefined;
      const b = 1500 + Math.random() * 900;
      const w = 2200 + Math.random() * 1600;
      const loops = [
        Animated.loop(
          Animated.sequence([
            Animated.timing(breathe, { toValue: 1, duration: b / 2, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
            Animated.timing(breathe, { toValue: 0, duration: b / 2, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
          ]),
        ),
        Animated.loop(
          Animated.sequence([
            Animated.timing(sway, { toValue: 1, duration: w / 4, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
            Animated.timing(sway, { toValue: -1, duration: w / 2, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
            Animated.timing(sway, { toValue: 0, duration: w / 4, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
          ]),
        ),
      ];
      const start = setTimeout(() => loops.forEach((l) => l.start()), 400 + Math.random() * 700);
      return () => {
        clearTimeout(start);
        loops.forEach((l) => l.stop());
      };
    }, [piece, breathe, sway]);
    const [lift, setLift] = useState(false);

    // A creature dropping in: fall 180 ms (the place sound's landing), squash,
    // spring back. Started before the first paint of the new creature, so it
    // never shows hanging above its cell while a busy JS thread catches up.
    const hadPiece = useRef(piece);
    useLayoutEffect(() => {
      if (piece && !hadPiece.current) {
        setLift(true);
        drop.setValue(0);
        squash.setValue(-1);
        Animated.sequence([
          Animated.timing(drop, { toValue: 1, duration: 180, easing: Easing.in(Easing.quad), useNativeDriver: true }),
          Animated.timing(squash, { toValue: 1, duration: 70, easing: Easing.out(Easing.quad), useNativeDriver: true }),
          Animated.spring(squash, { toValue: 0, friction: 3.2, tension: 260, useNativeDriver: true }),
        ]).start(() => setLift(false));
      }
      hadPiece.current = piece;
    }, [piece, drop, squash]);

    // The wrong creature: lands, goes red and shakes, then pops off.
    useLayoutEffect(() => {
      if (!wrongKey) return;
      setLift(true);
      drop.setValue(0);
      squash.setValue(-1);
      gone.setValue(0);
      sulk.setValue(0);
      red.setValue(0);
      Animated.sequence([
        Animated.timing(drop, { toValue: 1, duration: 180, easing: Easing.in(Easing.quad), useNativeDriver: true }),
        Animated.parallel([
          Animated.timing(squash, { toValue: 1, duration: 70, useNativeDriver: true }),
          Animated.timing(red, { toValue: 1, duration: 120, useNativeDriver: true }),
        ]),
        Animated.spring(squash, { toValue: 0, friction: 4, tension: 240, useNativeDriver: true }),
        Animated.sequence([1, -1, 1, -1, 0.6, -0.6, 0].map((k) => Animated.timing(sulk, { toValue: k, duration: 50, useNativeDriver: true }))),
        Animated.parallel([
          Animated.timing(gone, { toValue: 1, duration: 230, easing: Easing.in(Easing.back(2.2)), useNativeDriver: true }),
          Animated.timing(red, { toValue: 0, duration: 400, useNativeDriver: true }),
        ]),
      ]).start(({ finished }) => {
        if (!finished) return;
        setWrongKey(0);
        setLift(false);
        gone.setValue(0);
      });
    }, [wrongKey, drop, squash, gone, sulk, red]);

    useImperativeHandle(ref, () => ({
      intro(delay) {
        intro.setValue(0);
        Animated.spring(intro, { toValue: 1, friction: 5.5, tension: 140, delay, useNativeDriver: true }).start();
      },
      outro(delay) {
        Animated.timing(intro, { toValue: 0, duration: 220, delay, easing: Easing.in(Easing.back(2)), useNativeDriver: true }).start();
      },
      press() {
        press.setValue(1);
        Animated.spring(press, { toValue: 0, friction: 4, tension: 200, useNativeDriver: true }).start();
      },
      mark(on) {
        if (on) {
          markT.setValue(0);
          Animated.spring(markT, { toValue: 1, friction: 4.5, tension: 220, useNativeDriver: true }).start();
        } else {
          Animated.timing(markT, { toValue: 0, duration: 140, easing: Easing.in(Easing.quad), useNativeDriver: true }).start();
        }
      },
      // one animation per flash (a busy board starts dozens at once)
      flash(delay, strength = 0.7) {
        flashK.setValue(strength);
        flash.setValue(0);
        Animated.timing(flash, { toValue: 1, duration: 470, delay, easing: Easing.linear, useNativeDriver: true }).start();
      },
      wrong() {
        setWrongKey((k) => k + 1);
      },
      hop: doHop,
      wiggle: doWiggle,
      // an idle trick: 'spin' (a full turn with a little hop), 'peek' (lean
      // out to one side and back), 'hop', 'wiggle'
      trick(kind) {
        if (kind === 'spin') {
          spin.setValue(0);
          Animated.parallel([
            Animated.timing(spin, { toValue: 1, duration: 520, easing: Easing.inOut(Easing.cubic), useNativeDriver: true }),
            Animated.sequence([
              Animated.timing(hop, { toValue: 0.45, duration: 200, easing: Easing.out(Easing.quad), useNativeDriver: true }),
              Animated.timing(hop, { toValue: 0, duration: 220, easing: Easing.in(Easing.quad), useNativeDriver: true }),
            ]),
          ]).start(() => spin.setValue(0));
        } else if (kind === 'peek') {
          const side = Math.random() < 0.5 ? -1 : 1;
          Animated.sequence([
            Animated.timing(peek, { toValue: side, duration: 240, easing: Easing.out(Easing.quad), useNativeDriver: true }),
            Animated.timing(peek, { toValue: side, duration: 380, useNativeDriver: true }),
            Animated.spring(peek, { toValue: 0, friction: 4, tension: 160, useNativeDriver: true }),
          ]).start();
        } else if (kind === 'hop') doHop(0, 0.6);
        else doWiggle();
      },
      // a quick startle at someone else's mistake
      flinch(delay) {
        Animated.sequence([
          Animated.timing(squash, { toValue: 0.7, duration: 70, delay, useNativeDriver: true }),
          Animated.parallel([
            Animated.spring(squash, { toValue: 0, friction: 3, tension: 240, useNativeDriver: true }),
            Animated.sequence([1, -1, 0.5, 0].map((k) => Animated.timing(sulk, { toValue: k * 0.5, duration: 50, useNativeDriver: true }))),
          ]),
        ]).start();
      },
    }));

    const cellScale = Animated.multiply(
      intro.interpolate({ inputRange: [0, 1], outputRange: [0, 1] }),
      press.interpolate({ inputRange: [0, 1], outputRange: [1, 0.86] }),
    );
    const cellRot = intro.interpolate({ inputRange: [0, 1], outputRange: [(r + c) % 2 ? '-14deg' : '14deg', '0deg'] });
    const p = size * 0.84;
    const showPiece = piece || wrongKey > 0;
    const pieceY = Animated.add(
      drop.interpolate({ inputRange: [0, 1], outputRange: [-size * 1.1, 0] }),
      hop.interpolate({ inputRange: [0, 1], outputRange: [0, -size * 0.42] }),
    );
    // squash and stretch, times the idle breathing (wider as it breathes out)
    const sx = Animated.multiply(
      squash.interpolate({ inputRange: [-1, 0, 1], outputRange: [0.82, 1, 1.28] }),
      breathe.interpolate({ inputRange: [0, 1], outputRange: [1, 1.035] }),
    );
    const sy = Animated.multiply(
      squash.interpolate({ inputRange: [-1, 0, 1], outputRange: [1.22, 1, 0.7] }),
      breathe.interpolate({ inputRange: [0, 1], outputRange: [1, 0.96] }),
    );
    const swayR = sway.interpolate({ inputRange: [-1, 1], outputRange: ['-3.5deg', '3.5deg'] });
    const spinR = spin.interpolate({ inputRange: [0, 1], outputRange: ['0deg', '360deg'] });
    const peekX = peek.interpolate({ inputRange: [-1, 1], outputRange: [-size * 0.14, size * 0.14] });
    const peekR = peek.interpolate({ inputRange: [-1, 1], outputRange: ['-16deg', '16deg'] });
    const sulkX = sulk.interpolate({ inputRange: [-1, 1], outputRange: [-size * 0.07, size * 0.07] });
    const sulkR = sulk.interpolate({ inputRange: [-1, 1], outputRange: ['-9deg', '9deg'] });
    const goneS = gone.interpolate({ inputRange: [0, 1], outputRange: [1, 0] });
    const goneR = gone.interpolate({ inputRange: [0, 1], outputRange: ['0deg', '40deg'] });
    const goneY = gone.interpolate({ inputRange: [0, 1], outputRange: [0, -size * 0.3] });
    const shadowS = Animated.multiply(
      drop.interpolate({ inputRange: [0, 1], outputRange: [0.4, 1] }),
      hop.interpolate({ inputRange: [0, 1], outputRange: [1, 0.6] }),
    );
    const mScale = markT.interpolate({ inputRange: [0, 1], outputRange: [1.8, 1] });
    const mRot = markT.interpolate({ inputRange: [0, 1], outputRange: ['-60deg', '0deg'] });
    const bar = { width: size * 0.5, height: Math.max(3, size * 0.1), borderRadius: size };

    return (
      <Animated.View
        style={[
          styles.cell,
          { left: c * size, top: r * size, width: size, height: size, zIndex: lift ? 5 : 0, elevation: lift ? 5 : 0, transform: [{ scale: cellScale }, { rotate: cellRot }] },
        ]}
      >
        {/* the candy tile; its flashes and the mistake's red glow keep to its face */}
        <Tile size={size} patch={patch}>
          <Animated.View style={[StyleSheet.absoluteFill, styles.flash, { opacity: Animated.multiply(flashK, flash.interpolate({ inputRange: [0, 0.18, 1], outputRange: [0, 1, 0] })) }]} />
          <Animated.View style={[StyleSheet.absoluteFill, styles.red, { opacity: red }]} />
        </Tile>
        <Animated.View pointerEvents="none" style={[styles.center, { opacity: markT, transform: [{ scale: mScale }, { rotate: mRot }] }]}>
          <View style={[styles.xBar, bar, { transform: [{ rotate: '45deg' }] }]} />
          <View style={[styles.xBar, bar, { transform: [{ rotate: '-45deg' }] }]} />
        </Animated.View>
        {showPiece ? (
          <>
            <Animated.View style={[styles.shadow, { width: p * 0.7, height: p * 0.16, bottom: size * 0.06, marginLeft: -p * 0.35, transform: [{ scaleX: shadowS }] }]} />
            <Animated.View
              style={[
                styles.piece,
                {
                  width: p,
                  height: p,
                  left: (size - p) / 2,
                  top: (size - p) / 2,
                  transform: [
                    { translateX: Animated.add(sulkX, peekX) },
                    { translateY: Animated.add(pieceY, goneY) },
                    // squash from the feet: shift down by half the lost height
                    { translateY: squash.interpolate({ inputRange: [-1, 0, 1], outputRange: [-p * 0.11, 0, p * 0.15] }) },
                    { rotate: sulkR },
                    { rotate: goneR },
                    { rotate: swayR },
                    { rotate: peekR },
                    { rotate: spinR },
                    { scaleX: sx },
                    { scaleY: sy },
                    { scale: goneS },
                  ],
                },
              ]}
            >
              <Image source={{ uri }} style={styles.img} resizeMode="contain" fadeDuration={0} />
            </Animated.View>
          </>
        ) : null}
      </Animated.View>
    );
  }),
);

function Board({ puzzle, size, pieces, allowX = true, xTool = false, locked = false, onTap, onMark, onTapPiece }, ref) {
  const { n, regions } = puzzle;
  const inner = size - FRAME * 2;
  const cs = Math.floor(inner / n);
  const grid = cs * n;
  const [marks, setMarks] = useState(() => new Array(n * n).fill(false));
  const [placed, setPlaced] = useState(() => new Array(n * n).fill(false));
  const marksRef = useRef(marks);
  marksRef.current = marks;
  const placedRef = useRef(placed);
  placedRef.current = placed;
  const cells = useRef([]);
  const fx = useRef(null);
  const shakeX = useRef(new Animated.Value(0)).current;
  const tilt = useRef(new Animated.Value(0)).current;

  // a colour per patch, shuffled per board so boards don't all look alike
  const colors = useMemo(() => {
    const order = PATCHES.map((_, i) => i).sort(() => Math.random() - 0.5);
    return Array.from({ length: n }, (_, i) => PATCHES[order[i % PATCHES.length]]);
  }, [n, regions]);

  const center = (cell) => ({ x: FRAME + (cell % n) * cs + cs / 2, y: FRAME + Math.floor(cell / n) * cs + cs / 2 });
  const shake = () => {
    shakeX.setValue(0);
    Animated.sequence([1, -0.85, 0.65, -0.45, 0.25, -0.1, 0].map((k) => Animated.timing(shakeX, { toValue: k * 9, duration: 42, useNativeDriver: true }))).start();
  };

  useImperativeHandle(ref, () => ({
    setMark(cell, on) {
      setMarks((m) => {
        if (m[cell] === on) return m;
        const next = m.slice();
        next[cell] = on;
        return next;
      });
      cells.current[cell]?.mark(on);
    },
    // a right creature: it drops, the patch ripples out from it, the row and
    // column glint, sparks fly
    place(cell) {
      setPlaced((p) => {
        const next = p.slice();
        next[cell] = true;
        return next;
      });
      setMarks((m) => {
        if (!m[cell]) return m;
        const next = m.slice();
        next[cell] = false;
        return next;
      });
      cells.current[cell]?.mark(false);
      const land = 180;
      const dist = distancesInPatch(n, regions, cell);
      dist.forEach((d, x) => cells.current[x]?.flash(land + d * 45, 0.75));
      const r = Math.floor(cell / n);
      const c = cell % n;
      for (let i = 0; i < n; i++) {
        const row = r * n + i;
        const col = i * n + c;
        if (!dist.has(row)) cells.current[row]?.flash(land + Math.abs(i - c) * 35, 0.35);
        if (!dist.has(col)) cells.current[col]?.flash(land + Math.abs(i - r) * 35, 0.35);
      }
      setTimeout(() => {
        const { x, y } = center(cell);
        fx.current?.burst('dust', x, y + cs * 0.36, cs / 56);
        fx.current?.burst('spark', x, y, cs / 56);
      }, land);
      // the creatures already there cheer it with little hops, nearest first
      placedRef.current.forEach((on, other) => {
        if (!on || other === cell) return;
        const d = Math.abs(Math.floor(other / n) - r) + Math.abs((other % n) - c);
        cells.current[other]?.hop(land + 60 + d * 55, 0.45);
      });
    },
    // a wrong creature: it lands, sulks red and pops off; the board shakes
    wrong(cell) {
      setMarks((m) => {
        if (!m[cell]) return m;
        const next = m.slice();
        next[cell] = false;
        return next;
      });
      cells.current[cell]?.mark(false);
      cells.current[cell]?.wrong();
      setTimeout(() => {
        const { x, y } = center(cell);
        fx.current?.burst('angry', x, y - cs * 0.2, cs / 56);
      }, 260);
      setTimeout(() => {
        const { x, y } = center(cell);
        fx.current?.burst('poof', x, y - cs * 0.15, cs / 56);
      }, 640);
      setTimeout(shake, 200);
      // everyone already placed startles
      placedRef.current.forEach((on, other) => on && cells.current[other]?.flinch(240 + Math.random() * 80));
    },
    wiggle(cell) {
      cells.current[cell]?.wiggle();
    },
    // the board cascading in, a diagonal wave from the top left
    intro() {
      for (let cell = 0; cell < n * n; cell++) cells.current[cell]?.intro(((cell % n) + Math.floor(cell / n)) * 34);
      tilt.setValue(1);
      Animated.spring(tilt, { toValue: 0, friction: 6, tension: 60, useNativeDriver: true }).start();
    },
    outro() {
      for (let cell = 0; cell < n * n; cell++) cells.current[cell]?.outro((2 * n - 2 - (cell % n) - Math.floor(cell / n)) * 18);
    },
    // every creature hops, row by row, then the patches glow
    hopAll() {
      for (let cell = 0; cell < n * n; cell++) {
        if (placedRef.current[cell]) cells.current[cell]?.hop(Math.floor(cell / n) * 75);
        cells.current[cell]?.flash(Math.floor(cell / n) * 75 + 120, 0.5);
      }
    },
    shake,
  }));

  // Now and then one placed creature does a trick, so a board in progress
  // never sits still (not while the board is locked: intro, solve, overlays).
  useEffect(() => {
    const TRICKS = ['hop', 'wiggle', 'spin', 'peek', 'peek', 'wiggle'];
    const timer = setInterval(() => {
      if (live.current.locked) return;
      const on = [];
      placedRef.current.forEach((x, i) => x && on.push(i));
      if (!on.length) return;
      const cell = on[Math.floor(Math.random() * on.length)];
      cells.current[cell]?.trick(TRICKS[Math.floor(Math.random() * TRICKS.length)]);
    }, 1300);
    return () => clearInterval(timer);
  }, []);

  // --- touches: tap, drag-to-mark, long-press-to-mark ------------------------------
  const live = useRef({});
  live.current = { allowX, xTool, locked, onTap, onMark, onTapPiece, n, cs };
  const gesture = useRef({ offX: 0, offY: 0, start: -1, last: -1, painting: false, paintOn: true, moved: false, timer: null, longDone: false });

  const cellAt = (pageX, pageY) => {
    const g = gesture.current;
    const { n: nn, cs: size_ } = live.current;
    const x = pageX - g.offX;
    const y = pageY - g.offY;
    if (x < 0 || y < 0) return -1;
    const c = Math.floor(x / size_);
    const r = Math.floor(y / size_);
    if (c >= nn || r >= nn) return -1;
    return r * nn + c;
  };

  const paint = (cell) => {
    const g = gesture.current;
    if (cell < 0 || cell === g.last) return;
    g.last = cell;
    if (placedRef.current[cell]) return;
    if (marksRef.current[cell] === g.paintOn) return;
    live.current.onMark && live.current.onMark(cell, g.paintOn, true);
  };

  const responder = useMemo(
    () =>
      PanResponder.create({
        onStartShouldSetPanResponder: () => true,
        onMoveShouldSetPanResponder: () => true,
        onPanResponderTerminationRequest: () => false,
        onPanResponderGrant: (e) => {
          const g = gesture.current;
          const { locationX, locationY, pageX, pageY } = e.nativeEvent;
          // the grid's page offset, from this first touch (its target is the
          // grid itself: the cells don't take touches)
          g.offX = pageX - locationX;
          g.offY = pageY - locationY;
          g.start = cellAt(pageX, pageY);
          g.last = -1;
          g.moved = false;
          g.painting = false;
          g.longDone = false;
          clearTimeout(g.timer);
          const L = live.current;
          if (L.locked || g.start < 0) return;
          cells.current[g.start]?.press();
          if (L.xTool && L.allowX) {
            // the ✕ tool: this drag sets (or clears) ✕s like its first cell
            g.painting = true;
            g.paintOn = !marksRef.current[g.start];
          } else if (L.allowX && !placedRef.current[g.start]) {
            g.timer = setTimeout(() => {
              g.longDone = true;
              g.painting = true;
              g.paintOn = !marksRef.current[g.start];
              paint(g.start);
            }, LONG_PRESS_MS);
          }
        },
        onPanResponderMove: (e, gs) => {
          const g = gesture.current;
          if (live.current.locked) return;
          if (!g.moved && Math.abs(gs.dx) + Math.abs(gs.dy) > MOVE_SLOP) {
            g.moved = true;
            if (!g.painting) clearTimeout(g.timer);
            if (g.painting && g.last < 0) paint(g.start);
          }
          if (g.painting && g.moved) paint(cellAt(e.nativeEvent.pageX, e.nativeEvent.pageY));
        },
        onPanResponderRelease: () => {
          const g = gesture.current;
          clearTimeout(g.timer);
          const L = live.current;
          if (L.locked || g.start < 0 || g.longDone) return;
          if (g.painting && g.moved) return;
          if (g.moved) return;
          if (placedRef.current[g.start]) {
            L.onTapPiece && L.onTapPiece(g.start);
            return;
          }
          L.onTap && L.onTap(g.start);
        },
        onPanResponderTerminate: () => clearTimeout(gesture.current.timer),
      }),
    // eslint-disable-next-line react-hooks/exhaustive-deps
    [],
  );

  const tiltR = tilt.interpolate({ inputRange: [0, 1], outputRange: ['0deg', '-6deg'] });
  const tiltS = tilt.interpolate({ inputRange: [0, 1], outputRange: [1, 0.9] });

  return (
    <Animated.View style={{ width: grid + FRAME * 2, height: grid + FRAME * 2 + 5, transform: [{ translateX: shakeX }, { rotate: tiltR }, { scale: tiltS }] }}>
      <View style={[styles.lip, { width: grid + FRAME * 2, height: grid + FRAME * 2 }]} />
      <View style={[styles.frame, { width: grid + FRAME * 2, height: grid + FRAME * 2 }]}>
        <View style={styles.rim}>
        <View style={[styles.grid, { width: grid, height: grid }]} {...responder.panHandlers}>
          <View pointerEvents="none" style={StyleSheet.absoluteFill}>
            {regions.map((reg, cell) => (
              <Cell
                key={cell}
                ref={(r) => {
                  cells.current[cell] = r;
                }}
                cell={cell}
                n={n}
                size={cs}
                patch={colors[reg]}
                mark={marks[cell]}
                piece={placed[cell]}
                uri={pieces[reg]}
              />
            ))}
          </View>
        </View>
        </View>
      </View>
      <FxLayer ref={fx} />
    </Animated.View>
  );
}

const styles = StyleSheet.create({
  lip: { position: 'absolute', top: 5, left: 0, borderRadius: 20, backgroundColor: RING },
  frame: { borderRadius: 20, backgroundColor: RING, padding: 2.5, alignItems: 'center', justifyContent: 'center' },
  rim: { borderRadius: 17.5, backgroundColor: '#ffffff', padding: 3.5 },
  // under the tiles' slightly rounded corners: a soft lilac, never white
  grid: { borderRadius: 13, overflow: 'hidden', backgroundColor: '#d9c6f5' },
  cell: { position: 'absolute' },
  flash: { backgroundColor: '#ffffff' },
  red: { backgroundColor: '#ff4d6d' },
  center: { ...StyleSheet.absoluteFillObject, alignItems: 'center', justifyContent: 'center' },
  xBar: { position: 'absolute', backgroundColor: INK, opacity: 0.72 },
  piece: { position: 'absolute' },
  img: { width: '100%', height: '100%' },
  shadow: { position: 'absolute', left: '50%', borderRadius: 999, backgroundColor: 'rgba(69,16,122,0.28)' },
});

export default memo(forwardRef(Board));
export { FRAME };
