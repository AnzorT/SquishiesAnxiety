import React, { forwardRef, memo, useCallback, useEffect, useImperativeHandle, useLayoutEffect, useMemo, useRef, useState } from 'react';
import { Animated, Easing, Image, PanResponder, StyleSheet, View } from 'react-native';
import { FxLayer } from './fx';
import { PHASE, SWING, UP_DOWN, phaseLoop } from '../components/idleLoop';
import Tile, { tileBox } from './Tile';
import { headOf } from './roster';
import { INK, PATCHES, RING } from './theme';

// The puzzle board: n×n plush cushions (Tile.js) in their patch colours,
// a quilt on a light tray (no border lines: the colours alone tell the
// patches apart), ✕ marks and creatures. It draws and animates; the game (SquishdokuScreen)
// decides. Touches come out as
//   onTap(cell)          a tap (place a creature, or toggle a ✕ with the ✕ tool)
//   onMark(cell, on)     a ✕ painted by a drag (✕ tool) or a long press
// and the game answers through the ref:
//   setMark(cell, on)  place(cell)  wrong(cell)  wiggle(cell)
//   intro()  outro()  hopAll()  shake()
// The creatures are heads alone (heads.js: idle, happy and sad faces of the
// rig, no body or hands). A tapped one zooms up from small to fill its cell,
// then a right one lights up happy and hops for joy, and a wrong one turns
// sad, cries, shakes its head and shrinks away. Each cell animates itself
// (zoom, squash, faces, ripple, sulk, hop); one shared FxLayer plays the
// dust, sparks and poofs. Placed creatures are alive: they breathe and sway,
// one does a trick now and then (hop, wiggle, spin, peek), they smile and
// hop to cheer each new creature and look worried at a mistake.

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
  forwardRef(function Cell({ cell, n, size, patch, mark, piece, uri, face, onShrink }, ref) {
    const r = Math.floor(cell / n);
    const c = cell % n;
    const intro = useRef(new Animated.Value(0)).current;
    const press = useRef(new Animated.Value(0)).current;
    const flash = useRef(new Animated.Value(0)).current; // 0 -> 1: up and back down
    const flashK = useRef(new Animated.Value(0)).current; // how bright this flash peaks
    const red = useRef(new Animated.Value(0)).current;
    const markT = useRef(new Animated.Value(mark ? 1 : 0)).current;
    const grow = useRef(new Animated.Value(piece ? 1 : 0)).current; // the head zooming up: 0 tiny, 1 filling its cell
    const happy = useRef(new Animated.Value(0)).current; // the happy face over the idle one (opacity)
    const sad = useRef(new Animated.Value(0)).current; // the sad face over the idle one (opacity)
    // one-shot phases 0 → 1, each a single native timing read through a
    // many-point interpolation (a sequence of steps waits on the JS thread
    // between steps: on the A15 that stretched the wrong one by ~150 ms)
    const joyT = useRef(new Animated.Value(0)).current; // a right creature's happy head-waggle
    const bounceT = useRef(new Animated.Value(0)).current; // its two happy hops
    const shakeT = useRef(new Animated.Value(0)).current; // the wrong creature shaking its head "no"
    const tear = useRef(new Animated.Value(0)).current; // 0 … 1: the wrong creature's tears rolling down
    const droop = useRef(new Animated.Value(0)).current; // the wrong creature hanging its head
    const squash = useRef(new Animated.Value(0)).current; // -1 stretched … 1 squashed
    const hop = useRef(new Animated.Value(0)).current;
    const sulk = useRef(new Animated.Value(0)).current; // the wrong creature's head shake
    const gone = useRef(new Animated.Value(0)).current; // the wrong creature shrinking away
    // idle: breathe 0 … 1 … 0 and sway 0 … 1 … -1 … 0, each read off a phase
    // that loops 0 → 1 natively (src/components/idleLoop.js)
    const breatheT = useRef(new Animated.Value(0)).current;
    const swayT = useRef(new Animated.Value(0)).current;
    const breathe = useMemo(() => breatheT.interpolate({ inputRange: PHASE, outputRange: UP_DOWN }), [breatheT]);
    const sway = useMemo(() => swayT.interpolate({ inputRange: PHASE, outputRange: SWING }), [swayT]);
    const spin = useRef(new Animated.Value(0)).current; // a trick: one turn
    const peek = useRef(new Animated.Value(0)).current; // a trick: lean out and back
    const [wrongKey, setWrongKey] = useState(0);

    // a face showing for `hold` ms after `delay`, then back to idle (the
    // face's own value: a newer one takes over from an older one)
    const showFace = (v, delay, hold, peak = 1) =>
      Animated.sequence([
        Animated.timing(v, { toValue: peak, duration: 90, delay, useNativeDriver: true }),
        Animated.timing(v, { toValue: peak, duration: hold, useNativeDriver: true }),
        Animated.timing(v, { toValue: 0, duration: 220, useNativeDriver: true }),
      ]).start();
    // a hop (`height` of the full one), landing with a squash; smiling (eyes
    // shut) unless it's an idle trick: a smile flashing on its own read as the
    // creature closing and opening its eyes (user, 2026-10-28)
    const doHop = (delay = 0, height = 1, smile = true) => {
      if (smile) showFace(happy, delay, 300);
      Animated.sequence([
        Animated.timing(hop, { toValue: height, duration: 170, delay, easing: Easing.out(Easing.quad), useNativeDriver: true }),
        Animated.timing(hop, { toValue: 0, duration: 170, easing: Easing.in(Easing.quad), useNativeDriver: true }),
        Animated.timing(squash, { toValue: 0.8 * height, duration: 60, useNativeDriver: true }),
        Animated.spring(squash, { toValue: 0, friction: 3, tension: 260, useNativeDriver: true }),
      ]).start();
    };
    const doWiggle = (smile = true) => {
      if (smile) showFace(happy, 0, 260);
      squash.setValue(0.9);
      Animated.spring(squash, { toValue: 0, friction: 2.6, tension: 300, useNativeDriver: true }).start();
    };

    // Idle life once placed: breathing and swaying at the creature's own pace
    // (random periods and start, so the board never moves in lockstep). Each
    // is one linear timing looping on the native side, its curve in the
    // interpolation (src/components/idleLoop.js): a loop around a sequence is
    // restarted from JS at every step, so a full board kept the JS thread
    // waking all the time and the motion hitched whenever JS was busy.
    useEffect(() => {
      if (!piece) return undefined;
      const loops = [
        phaseLoop(breatheT, 1500 + Math.random() * 900),
        phaseLoop(swayT, 2200 + Math.random() * 1600),
      ];
      const start = setTimeout(() => loops.forEach((l) => l.start()), 400 + Math.random() * 700);
      return () => {
        clearTimeout(start);
        loops.forEach((l) => l.stop());
      };
    }, [piece, breatheT, swayT]);
    const [lift, setLift] = useState(false);

    // The head zooming up from small to fill its cell: 180 ms (the place and
    // wrong sounds' rising sweep), overshooting a little.
    const zoomIn = () => Animated.timing(grow, { toValue: 1, duration: 180, easing: Easing.out(Easing.back(1.8)), useNativeDriver: true });

    // A right creature: zooms up with its idle face, lands with a squash and
    // lights up happy (the chime), hops twice and waggles its head for joy,
    // then settles back to its idle face. Started before the first paint of
    // the new creature, so it never shows full size first while a busy JS
    // thread catches up.
    const hadPiece = useRef(piece);
    useLayoutEffect(() => {
      if (piece && !hadPiece.current) {
        setLift(true);
        [grow, squash, sad, happy, gone, droop, sulk, tear, joyT, bounceT, shakeT].forEach((v) => v.setValue(0));
        Animated.sequence([
          zoomIn(),
          Animated.timing(squash, { toValue: 0.75, duration: 60, easing: Easing.out(Easing.quad), useNativeDriver: true }),
          Animated.spring(squash, { toValue: 0, friction: 3.2, tension: 260, useNativeDriver: true }),
        ]).start(() => setLift(false));
        showFace(happy, 170, 900);
        Animated.timing(bounceT, { toValue: 1, duration: 540, delay: 260, easing: Easing.linear, useNativeDriver: true }).start();
        Animated.timing(joyT, { toValue: 1, duration: 630, delay: 240, easing: Easing.linear, useNativeDriver: true }).start();
      }
      hadPiece.current = piece;
    }, [piece]); // eslint-disable-line react-hooks/exhaustive-deps

    // A wrong creature: zooms up the same, then turns sad as it lands (the
    // buzz) with the tile glowing red, cries, hangs its head and shakes it
    // "no" (the grumble), and shrinks away (the poof, 630 ms in).
    useLayoutEffect(() => {
      if (!wrongKey) return;
      setLift(true);
      [grow, squash, gone, sulk, red, happy, sad, tear, droop, shakeT].forEach((v) => v.setValue(0));
      Animated.timing(tear, { toValue: 1, duration: 560, delay: 290, easing: Easing.in(Easing.quad), useNativeDriver: true }).start();
      Animated.sequence([
        zoomIn(),
        Animated.parallel([
          Animated.timing(squash, { toValue: 0.6, duration: 70, useNativeDriver: true }),
          Animated.timing(red, { toValue: 1, duration: 120, useNativeDriver: true }),
          Animated.timing(sad, { toValue: 1, duration: 110, useNativeDriver: true }),
        ]),
        Animated.parallel([
          Animated.timing(squash, { toValue: 0, duration: 200, easing: Easing.out(Easing.quad), useNativeDriver: true }),
          Animated.timing(droop, { toValue: 1, duration: 260, easing: Easing.out(Easing.quad), useNativeDriver: true }),
          Animated.timing(shakeT, { toValue: 1, duration: 330, easing: Easing.linear, useNativeDriver: true }),
        ]),
      ]).start(({ finished }) => {
        if (!finished) return;
        // the shrink, with the board's poof on it (started from here, so the
        // two always meet however late the steps above ran)
        onShrink && onShrink(cell);
        Animated.parallel([
          Animated.timing(gone, { toValue: 1, duration: 240, easing: Easing.in(Easing.back(1.8)), useNativeDriver: true }),
          Animated.timing(red, { toValue: 0, duration: 400, useNativeDriver: true }),
        ]).start(({ finished: done }) => {
          if (!done) return;
          // the values stay where they ended (shrunk away) until the next
          // creature here resets them: reset now, the head would show again
          // for a frame before this render takes it off
          setWrongKey(0);
          setLift(false);
        });
      });
    }, [wrongKey]); // eslint-disable-line react-hooks/exhaustive-deps

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
      wiggle: () => doWiggle(),
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
        } else if (kind === 'hop') doHop(0, 0.6, false);
        else doWiggle(false);
      },
      // a quick startle at someone else's mistake, with a worried face
      flinch(delay) {
        showFace(sad, delay, 380, 0.85);
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
    // the head fills the tile's face (above its 3D lip); a creature without a
    // head of its own (heads.js) is its rig still, which has a margin
    const { lip } = tileBox(size);
    const p = face ? size * 0.88 : size * 0.84;
    const pTop = face ? (size - lip - p) / 2 : (size - p) / 2;
    const showPiece = piece || wrongKey > 0;
    const pieceY = Animated.add(
      droop.interpolate({ inputRange: [0, 1], outputRange: [0, size * 0.06] }),
      hop.interpolate({ inputRange: [0, 1], outputRange: [0, -size * 0.42] }),
    );
    const growS = grow.interpolate({ inputRange: [0, 1], outputRange: [0.1, 1] });
    const growR = grow.interpolate({ inputRange: [0, 1], outputRange: [(r + c) % 2 ? '18deg' : '-18deg', '0deg'] });
    const growO = grow.interpolate({ inputRange: [0, 0.25, 1], outputRange: [0, 1, 1], extrapolate: 'clamp' });
    const STEPS = [0, 1 / 6, 2 / 6, 3 / 6, 4 / 6, 5 / 6, 1];
    const joyR = joyT.interpolate({ inputRange: STEPS, outputRange: ['0deg', '11deg', '-11deg', '9deg', '-6.5deg', '3deg', '0deg'] });
    // two hops, 0.34 and 0.2 of the full one, as parabolas from their points
    const bounceY = bounceT.interpolate({
      inputRange: [0, 0.14, 0.28, 0.42, 0.56, 0.67, 0.78, 0.89, 1],
      outputRange: [0, -0.26, -0.34, -0.26, 0, -0.15, -0.2, -0.15, 0].map((k) => k * size * 0.42),
    });
    const shakeX = shakeT.interpolate({ inputRange: STEPS, outputRange: [0, 1, -1, 1, -1, 0.5, 0].map((k) => k * size * 0.07) });
    const shakeR = shakeT.interpolate({ inputRange: STEPS, outputRange: ['0deg', '9deg', '-9deg', '9deg', '-9deg', '4.5deg', '0deg'] });
    const droopR = droop.interpolate({ inputRange: [0, 1], outputRange: ['0deg', (r + c) % 2 ? '7deg' : '-7deg'] });
    const tearY = tear.interpolate({ inputRange: [0, 1], outputRange: [0, p * 0.24] });
    const tearO = tear.interpolate({ inputRange: [0, 0.12, 0.7, 1], outputRange: [0, 1, 1, 0] });
    const tearS = tear.interpolate({ inputRange: [0, 0.2, 1], outputRange: [0.3, 1, 0.8] });
    const tw = Math.max(4, p * 0.085);
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
    const goneR = gone.interpolate({ inputRange: [0, 1], outputRange: ['0deg', '-30deg'] });
    const goneY = gone.interpolate({ inputRange: [0, 1], outputRange: [0, size * 0.14] });
    const shadowS = Animated.multiply(
      Animated.multiply(grow, gone.interpolate({ inputRange: [0, 1], outputRange: [1, 0] })),
      hop.interpolate({ inputRange: [0, 1], outputRange: [1, 0.6] }),
    );
    const mScale = markT.interpolate({ inputRange: [0, 1], outputRange: [1.8, 1] });
    const mRot = markT.interpolate({ inputRange: [0, 1], outputRange: ['-60deg', '0deg'] });
    // the ✕: white bars on plum ones a little bigger (a plum outline), so it
    // reads on light and deep patches alike (a plum ✕ was lost on the Jewel
    // violet, sapphire and ruby)
    const bar = { width: size * 0.5, height: Math.max(3, size * 0.1), borderRadius: size };
    const edge = Math.max(1.2, size * 0.028);
    const barEdge = { width: bar.width + edge * 2, height: bar.height + edge * 2, borderRadius: size };

    return (
      <Animated.View
        style={[
          styles.cell,
          { left: c * size, top: r * size, width: size, height: size, zIndex: lift ? 5 : 0, elevation: lift ? 5 : 0, transform: [{ scale: cellScale }, { rotate: cellRot }] },
        ]}
      >
        {/* the cushion; its flashes and the mistake's red glow keep to its shape */}
        <Tile size={size} patch={patch}>
          <Animated.View style={[StyleSheet.absoluteFill, styles.flash, { opacity: Animated.multiply(flashK, flash.interpolate({ inputRange: [0, 0.18, 1], outputRange: [0, 1, 0] })) }]} />
          <Animated.View style={[StyleSheet.absoluteFill, styles.red, { opacity: red }]} />
        </Tile>
        <Animated.View pointerEvents="none" style={[styles.center, { opacity: markT, transform: [{ scale: mScale }, { rotate: mRot }] }]}>
          <View style={[styles.xEdge, barEdge, { transform: [{ rotate: '45deg' }] }]} />
          <View style={[styles.xEdge, barEdge, { transform: [{ rotate: '-45deg' }] }]} />
          <View style={[styles.xBar, bar, { transform: [{ rotate: '45deg' }] }]} />
          <View style={[styles.xBar, bar, { transform: [{ rotate: '-45deg' }] }]} />
        </Animated.View>
        {showPiece ? (
          <>
            {/* a floor shadow under a whole creature; a head has none (under one it showed as a bar) */}
            {face ? null : <Animated.View style={[styles.shadow, { width: p * 0.7, height: p * 0.16, bottom: size * 0.06, marginLeft: -p * 0.35, transform: [{ scaleX: shadowS }] }]} />}
            <Animated.View
              style={[
                styles.piece,
                {
                  width: p,
                  height: p,
                  left: (size - p) / 2,
                  top: pTop,
                  opacity: growO,
                  transform: [
                    { translateX: Animated.add(Animated.add(sulkX, peekX), shakeX) },
                    { translateY: Animated.add(Animated.add(pieceY, goneY), bounceY) },
                    // squash from the chin: shift down by half the lost height
                    { translateY: squash.interpolate({ inputRange: [-1, 0, 1], outputRange: [-p * 0.11, 0, p * 0.15] }) },
                    { rotate: sulkR },
                    { rotate: goneR },
                    { rotate: swayR },
                    { rotate: peekR },
                    { rotate: spinR },
                    { rotate: joyR },
                    { rotate: shakeR },
                    { rotate: droopR },
                    { rotate: growR },
                    { scaleX: sx },
                    { scaleY: sy },
                    { scale: Animated.multiply(goneS, growS) },
                  ],
                },
              ]}
            >
              {face ? (
                <>
                  <Image source={face.idle} style={styles.img} fadeDuration={0} />
                  <Animated.Image source={face.happy} style={[styles.img, styles.layer, { opacity: happy }]} fadeDuration={0} />
                  <Animated.Image source={face.sad} style={[styles.img, styles.layer, { opacity: sad }]} fadeDuration={0} />
                  {wrongKey > 0
                    ? face.eyes.map(([ex, ey], i) => (
                        <Animated.View
                          key={i}
                          style={[
                            styles.tear,
                            {
                              width: tw,
                              height: tw,
                              borderRadius: tw / 2,
                              borderTopLeftRadius: 0,
                              left: ex * p - tw / 2,
                              top: ey * p + p * 0.05,
                              opacity: tearO,
                              transform: [{ translateY: tearY }, { scale: tearS }, { rotate: '45deg' }],
                            },
                          ]}
                        />
                      ))
                    : null}
                </>
              ) : (
                <Image source={{ uri }} style={styles.img} resizeMode="contain" fadeDuration={0} />
              )}
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

  // each patch's creature as a head with its faces (null: its rig still)
  const faces = useMemo(() => pieces.map(headOf), [pieces]);
  // a colour per patch, shuffled per board so boards don't all look alike
  const colors = useMemo(() => {
    const order = PATCHES.map((_, i) => i).sort(() => Math.random() - 0.5);
    return Array.from({ length: n }, (_, i) => PATCHES[order[i % PATCHES.length]]);
  }, [n, regions]);

  const center = (cell) => ({ x: FRAME + (cell % n) * cs + cs / 2, y: FRAME + Math.floor(cell / n) * cs + cs / 2 });
  // the poof as a wrong creature shrinks away (the cell says when)
  const geo = useRef({ n, cs });
  geo.current = { n, cs };
  const onShrink = useCallback((cell) => {
    const { n: nn, cs: size_ } = geo.current;
    fx.current?.burst('poof', FRAME + (cell % nn) * size_ + size_ / 2, FRAME + Math.floor(cell / nn) * size_ + size_ * 0.4, size_ / 56);
  }, []);
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
    // a right creature: it zooms up, the patch ripples out from it, the row and
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
        fx.current?.burst('pop', x, y, cs / 56);
        fx.current?.burst('spark', x, y, cs / 56);
      }, land);
      // the creatures already there cheer it with little hops, nearest first
      placedRef.current.forEach((on, other) => {
        if (!on || other === cell) return;
        const d = Math.abs(Math.floor(other / n) - r) + Math.abs((other % n) - c);
        cells.current[other]?.hop(land + 60 + d * 55, 0.45);
      });
    },
    // a wrong creature: it zooms up, turns sad and red, cries and shrinks away; the board shakes
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
                face={faces[reg]}
                onShrink={onShrink}
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
  // the quilt's seams between the cushions: a soft lilac, never white
  grid: { borderRadius: 13, overflow: 'hidden', backgroundColor: '#e9dcf7' },
  cell: { position: 'absolute' },
  flash: { backgroundColor: '#ffffff' },
  red: { backgroundColor: '#ff4d6d' },
  center: { ...StyleSheet.absoluteFillObject, alignItems: 'center', justifyContent: 'center' },
  xEdge: { position: 'absolute', backgroundColor: INK },
  xBar: { position: 'absolute', backgroundColor: '#ffffff' },
  piece: { position: 'absolute' },
  img: { width: '100%', height: '100%' },
  layer: { position: 'absolute', left: 0, top: 0 },
  // a tear: a drop with its point up (a square, round but for one corner, turned 45°)
  tear: { position: 'absolute', backgroundColor: '#8fdcff', borderWidth: 1, borderColor: '#ffffff' },
  shadow: { position: 'absolute', left: '50%', borderRadius: 999, backgroundColor: 'rgba(69,16,122,0.28)' },
});

export default memo(forwardRef(Board));
export { FRAME };
