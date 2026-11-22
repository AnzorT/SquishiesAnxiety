import React, { forwardRef, memo, useEffect, useImperativeHandle, useMemo, useRef, useState } from 'react';
import { Animated, Easing, PanResponder, StyleSheet, View } from 'react-native';
import Svg, { Path } from 'react-native-svg';
import { FxLayer } from './fx';
import { INK, PATCHES } from './theme';
import BODIES from './bodies';
import { cellAt as cellAtPoint, cellBox, polyPath, project, roundRect, standOn } from '../hop/board';
import { Piece, cushionParts, freshPose, poseAt } from '../hop/Pieces';
import { usePingPong } from '../components/idleLoop';
import { bodyH } from '../stack/Pieces';

// Squishdoku's board in one of the Crib's rooms (the user, 2026-11-07: "the
// same method" as Squish Hop, "and the characters look like" it): the patches
// are plush cushions in their Jewel colours lying on the room's floor, seen
// in Squish Hop's perspective (src/hop/board.js, leaned back less so a 9×9
// stays big), and a placed creature stands on its cushion, body and all.
//
// The same contract as Board.js, so the games drive it the same way:
//   onTap(cell)          a tap (place a creature, or toggle a ✕ with the ✕ tool)
//   onMark(cell, on)     a ✕ painted by a drag (✕ tool) or a long press
//   onTapPiece(cell)     a tap on a placed creature
// and through the ref: setMark(cell, on)  place(cell)  wrong(cell)
// wiggle(cell)  intro()  outro()  hopAll(from)  sadAll(from)  cheerUp()  shake().
// `B` is the board's place on screen (board.js layout), worked out by the game.
//
// The creatures have three faces (bodies.js: idle, happy, sad, whole body and
// all) and move like Squish Hop's squishies (Pieces.js freshPose juicy):
//   right   pops up out of its cushion with a squash, turns happy, hops for
//           joy, sparkles; the row, column and patch it completes ripple with
//           a happy wave (the cushions bob, a glow and a star on each)
//   wrong   pops up the same, turns sad, flashes red, shakes its head "no",
//           then drops away in a poof
//   win     every creature turns happy, and a bounce ripples over the board
//           from the last one placed (hopAll)
//   lose    one after another every creature turns sad, droops and sinks a
//           little, and stays so (sadAll; cheerUp brings them back)

const LONG_PRESS_MS = 380;
const MOVE_SLOP = 8;
const PIECE_W = 0.7; // a creature's body, in tiles
const SHADE = 'rgba(69,16,122,0.28)';
const POP_MS = 200; // a creature popping up out of its cushion
const WAVE_STEP = 55; // a happy wave, per cell out
const SAD_STEP = 140; // a lost level: between one creature drooping and the next

// a patch's Jewel colour as a cushion: its body in the middle going to its
// deep edge, on a ring darker still (the user picked the deep Jewel colours
// over pastels, 2026-10-28)
const darker = (hex, k) => {
  const v = parseInt(hex.slice(1), 16);
  const ch = (sh) => Math.round(((v >> sh) & 255) * k);
  return `rgb(${ch(16)},${ch(8)},${ch(0)})`;
};
const colorOf = (col) => {
  const [edge, body] = PATCHES[col % PATCHES.length].shade;
  return { c1: body, c2: edge, ring: darker(edge, 0.72) };
};

// how far each cell of a patch is from `from` (steps through the patch): the
// ripple's delays
function distancesInPatch(n, regions, from) {
  const dist = new Map([[from, 0]]);
  const todo = [from];
  while (todo.length) {
    const cell = todo.shift();
    const r = Math.floor(cell / n);
    const c = cell % n;
    for (const [dr, dc] of [
      [1, 0],
      [-1, 0],
      [0, 1],
      [0, -1],
    ]) {
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

// One cushion: it cascades in (`a`, 0 → 1) and bounces (`bump`, 0 → 1 → 0)
// when its patch ripples.
const Cushion = memo(function Cushion({ B, cell, col, a, bump }) {
  const x = cell % B.w;
  const y = Math.floor(cell / B.w);
  const box = useMemo(() => cellBox(B, x, y, 0.02, 0.1), [B, x, y]);
  const parts = useMemo(() => cushionParts(B, x, y, 0, 1, colorOf(col), `sdk${cell}`, box.left, box.top), [B, x, y, col, cell, box]);
  const scale = Animated.multiply(
    a.interpolate({ inputRange: [0, 1], outputRange: [0.3, 1] }),
    bump.interpolate({ inputRange: [0, 1], outputRange: [1, 1.09] }),
  );
  return (
    <Animated.View pointerEvents="none" style={{ position: 'absolute', left: box.left, top: box.top, opacity: a, transform: [{ translateY: bump.interpolate({ inputRange: [0, 1], outputRange: [0, -B.T * 0.06] }) }, { scale }] }}>
      <Svg width={box.width} height={box.height}>
        {parts}
      </Svg>
    </Animated.View>
  );
});

// A ✕ printed on a cushion: white with a plum edge (Board.js's), popping in.
const XMark = memo(function XMark({ B, cell }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    Animated.spring(t, { toValue: 1, friction: 5, tension: 180, useNativeDriver: true }).start();
  }, [t]);
  const x = cell % B.w;
  const y = Math.floor(cell / B.w);
  const box = cellBox(B, x, y, 0.02, 0.1);
  const k = 0.2;
  const a = polyPath(B, [[x + k + 0.04, y + k + 0.02], [x + 1 - k - 0.04, y + 1 - k - 0.04]], 0.01, box.left, box.top);
  const b = polyPath(B, [[x + 1 - k - 0.04, y + k + 0.02], [x + k + 0.04, y + 1 - k - 0.04]], 0.01, box.left, box.top);
  const w = Math.max(3, B.T * 0.1);
  return (
    <Animated.View pointerEvents="none" style={{ position: 'absolute', left: box.left, top: box.top, opacity: t, transform: [{ scale: t.interpolate({ inputRange: [0, 1], outputRange: [1.6, 1] }) }] }}>
      <Svg width={box.width} height={box.height}>
        <Path d={`${a} ${b}`} stroke={INK} strokeWidth={w + 3} strokeLinecap="round" fill="none" />
        <Path d={`${a} ${b}`} stroke="#ffffff" strokeWidth={w} strokeLinecap="round" fill="none" />
      </Svg>
    </Animated.View>
  );
});

// The red glow round a cell a wrong creature was put on.
const RedGlow = memo(function RedGlow({ B, cell }) {
  const pulse = usePingPong(260, { from: 0.35, to: 0.9, eased: false });
  const x = cell % B.w;
  const y = Math.floor(cell / B.w);
  const box = cellBox(B, x, y, 0, 0.16);
  const d = roundRect(B, x - 0.03, y - 0.03, x + 1.03, y + 1.03, 0.26, 0, box.left, box.top);
  return (
    <Animated.View pointerEvents="none" style={{ position: 'absolute', left: box.left, top: box.top, opacity: pulse }}>
      <Svg width={box.width} height={box.height}>
        <Path d={d} fill="rgba(255,77,109,0.45)" stroke="#ff4d6d" strokeWidth={Math.max(2.5, B.T * 0.06)} />
      </Svg>
    </Animated.View>
  );
});

function RoomBoard({ puzzle, pieces, B, allowX = true, xTool = false, locked = false, onTap, onMark, onTapPiece }, ref) {
  const { n, regions } = puzzle;
  // each patch's colour (a 600-levels board says which; Blitz's go in order)
  const colorIdx = (reg) => (puzzle.colors ? puzzle.colors[reg] : reg);
  const N = n * n;
  const cellA = useMemo(() => Array.from({ length: N }, () => ({ a: new Animated.Value(0), bump: new Animated.Value(0) })), [N]);
  // Squish Hop's squishy moves, plus the faces (0 … 1 each) and the red flash (a phase)
  const poses = useMemo(
    () =>
      Array.from({ length: N }, () => ({ ...freshPose({ juicy: true }), happy: new Animated.Value(0), sad: new Animated.Value(0), red: new Animated.Value(0) })),
    [N],
  );
  const shakeX = useRef(new Animated.Value(0)).current;
  const fx = useRef(null);
  const [marks, setMarks] = useState(() => new Array(N).fill(false));
  const [placed, setPlaced] = useState(() => new Array(N).fill(false));
  const [shown, setShown] = useState(() => new Array(N).fill(false)); // a creature drawn (placed, or a wrong one for a moment)
  const [red, setRed] = useState(-1);
  const marksRef = useRef(marks);
  marksRef.current = marks;
  const placedRef = useRef(placed);
  placedRef.current = placed;
  const live = useRef({});
  live.current = { B, allowX, xTool, locked, onTap, onMark, onTapPiece };
  const pw = B.T * PIECE_W;
  // each patch's creature drawn in its three faces (bodies.js, one render so they line up), or as its Squish Stack
  // cut-out without faces (one published since)
  const faced = useMemo(
    () =>
      pieces.map((c) => {
        const b = c && BODIES[c.key];
        return b ? { ...c, source: b.idle, ar: b.ar, box: [0, 0, 1, 1], faces: b } : c;
      }),
    [pieces],
  );
  const pieceOf = (cell) => faced[regions[cell]] || faced[0];
  const hOf = (cell) => bodyH(pieceOf(cell), pw);
  const zOf = (cell) => 10 + Math.floor(cell / n) * 3;
  const timing = (v, toValue, duration, easing = Easing.out(Easing.quad), delay = 0) => Animated.timing(v, { toValue, duration, easing, delay, useNativeDriver: true });
  const poseOn = (cell) => {
    const q = standOn(B, cell);
    return poseAt(pw, hOf(cell), q.x, q.y, q.s / B.T);
  };
  const timers = useRef([]);
  const later = (ms, fn) => timers.current.push(setTimeout(fn, ms));
  useEffect(() => () => timers.current.forEach(clearTimeout), []);

  // everyone standing where they belong when the board's place changes
  useEffect(() => {
    placedRef.current.forEach((on, cell) => {
      if (!on) return;
      const p = poseOn(cell);
      poses[cell].x.setValue(p.x);
      poses[cell].y.setValue(p.y);
      poses[cell].k.setValue(p.k);
    });
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [B]);

  const show = (cell, on) =>
    setShown((s) => {
      if (s[cell] === on) return s;
      const next = s.slice();
      next[cell] = on;
      return next;
    });
  const unmark = (cell) =>
    setMarks((m) => {
      if (!m[cell]) return m;
      const next = m.slice();
      next[cell] = false;
      return next;
    });

  // when the last creature placed lands (hopAll's ripple starts with its hop for joy)
  const landAt = useRef(0);
  const hopGen = useRef([]); // a creature's hops: cancelHops drops the ones not started yet
  const faceGen = useRef([]); // its faces: a newer one drops an older one's way back to idle
  const stop = (v, to) => {
    v.stopAnimation();
    v.setValue(to);
  };

  // a creature pops up out of its cushion: growing from small at its feet
  // (its size and place ease alike, so the feet stay put) with an overshoot,
  // then landing with a squash
  function pop(cell) {
    const P = poses[cell];
    const p = poseOn(cell);
    [P.rot, P.bump, P.hp, P.no, P.droop, P.wig, P.joy, P.hap, P.red, P.happy, P.sad].forEach((v) => stop(v, 0));
    stop(P.land, 1);
    P.shadow.setValue(1);
    P.x.setValue(p.x);
    const k0 = p.k * 0.12;
    P.k.setValue(k0);
    P.y.setValue(poseAt(pw, hOf(cell), standOn(B, cell).x, standOn(B, cell).y, k0).y);
    P.o.setValue(0);
    show(cell, true);
    // (once it's on screen: a native animation started before its view is
    // there can be lost)
    return new Promise((done) =>
      later(30, () => {
        const e = Easing.out(Easing.back(2.2));
        Animated.parallel([timing(P.k, p.k, POP_MS, e), timing(P.y, p.y, POP_MS, e), timing(P.o, 1, 70, Easing.linear)]).start(() => {
          P.land.setValue(0);
          timing(P.land, 1, 320, Easing.linear).start();
          done();
        });
      }),
    );
  }
  // a little hop on the spot (`high` tiles up)
  function hop(cell, delay = 0, high = 0.45) {
    const P = poses[cell];
    const gen = hopGen.current[cell] || 0;
    later(delay, () => {
      if ((hopGen.current[cell] || 0) !== gen) return;
      P.hp.setValue(0);
      P.liftH.setValue(B.T * high);
      timing(P.hp, 1, 340, Easing.linear).start(() => {
        P.land.setValue(0);
        timing(P.land, 1, 220, Easing.linear).start();
      });
    });
  }
  const cancelHops = (cell) => {
    hopGen.current[cell] = (hopGen.current[cell] || 0) + 1;
  };
  // a face ('happy', 'sad' or 'idle') from `delay` ms, fading in over `ms`, for
  // `hold` ms (then back to idle; Infinity: until another face)
  function face(cell, which, { delay = 0, hold = Infinity, ms = 110 } = {}) {
    const P = poses[cell];
    const gen = (faceGen.current[cell] = (faceGen.current[cell] || 0) + 1);
    later(delay, () => {
      if (faceGen.current[cell] !== gen) return;
      timing(P.happy, which === 'happy' ? 1 : 0, ms, Easing.linear).start();
      timing(P.sad, which === 'sad' ? 1 : 0, ms, Easing.linear).start();
      if (which === 'idle' || hold === Infinity) return;
      later(hold, () => {
        if (faceGen.current[cell] !== gen) return;
        timing(P.happy, 0, 220, Easing.linear).start();
        timing(P.sad, 0, 220, Easing.linear).start();
      });
    });
  }
  function rock(cell, seq, ms) {
    Animated.sequence(seq.map((v) => timing(poses[cell].rot, v, ms / seq.length, Easing.inOut(Easing.quad)))).start();
  }
  function bounce(cell, delay) {
    const b = cellA[cell].bump;
    later(delay, () => {
      b.setValue(0);
      Animated.sequence([timing(b, 1, 110), timing(b, 0, 220, Easing.inOut(Easing.quad))]).start();
    });
  }
  // the floor's middle of a cell, and a cushion's width there (the waves' spots)
  const spot = (cell, d, glow = true) => {
    const q = project(B, (cell % n) + 0.5, Math.floor(cell / n) + 0.5, 0);
    return { x: q.x, y: q.y, s: q.s, d, glow };
  };
  // A right creature completes its row, its column and its patch (each holds
  // one): a happy wave runs out along all three from it, from `start` ms; the
  // cushions bob, a glow and a star on each.
  function wave(cell, start) {
    const r = Math.floor(cell / n);
    const c = cell % n;
    const steps = new Map();
    const put = (x, k) => {
      if (!steps.has(x) || steps.get(x) > k) steps.set(x, k);
    };
    distancesInPatch(n, regions, cell).forEach((k, x) => put(x, k));
    for (let i = 0; i < n; i++) {
      put(r * n + i, Math.abs(i - c));
      put(i * n + c, Math.abs(i - r));
    }
    const pts = [];
    steps.forEach((k, x) => {
      bounce(x, start + k * WAVE_STEP);
      if (x !== cell) pts.push(spot(x, k * WAVE_STEP));
    });
    later(start, () => fx.current?.wave(pts, B.c * 0.9));
  }
  const shake = () => {
    shakeX.setValue(0);
    Animated.sequence([1, -0.85, 0.65, -0.45, 0.25, -0.1, 0].map((k) => Animated.timing(shakeX, { toValue: k * 9, duration: 42, useNativeDriver: true }))).start();
  };
  const placedCells = () => {
    const on = [];
    placedRef.current.forEach((x, i) => x && on.push(i));
    return on;
  };
  const gap = (a, b) => Math.hypot(Math.floor(a / n) - Math.floor(b / n), (a % n) - (b % n));

  useImperativeHandle(ref, () => ({
    setMark(cell, on) {
      setMarks((m) => {
        if (m[cell] === on) return m;
        const next = m.slice();
        next[cell] = on;
        return next;
      });
    },
    // a right creature: it pops up out of its cushion with a squash, lights up
    // happy, sparkles and hops for joy; a happy wave runs along its row, its
    // column and its patch; everyone cheers with a happy hop
    place(cell) {
      setPlaced((p) => {
        const next = p.slice();
        next[cell] = true;
        return next;
      });
      unmark(cell);
      cancelHops(cell);
      const land = 30 + POP_MS;
      landAt.current = Date.now() + land;
      pop(cell).then(() => {
        const q = standOn(B, cell);
        fx.current?.burst('pop', q.x, q.y - q.s * 0.2, q.s / 56);
        fx.current?.burst('spark', q.x, q.y - q.s * 0.5, q.s / 56);
      });
      face(cell, 'happy', { delay: 120, hold: 1100 });
      hop(cell, land + 120, 0.4);
      later(land + 260, () => {
        const q = standOn(B, cell);
        fx.current?.burst('spark', q.x, q.y - q.s * 0.85, q.s / 70);
      });
      wave(cell, land);
      const r = Math.floor(cell / n);
      const c = cell % n;
      placedRef.current.forEach((on, other) => {
        if (!on || other === cell) return;
        const d = Math.abs(Math.floor(other / n) - r) + Math.abs((other % n) - c);
        hop(other, land + 60 + d * 55, 0.3);
        face(other, 'happy', { delay: land + 60 + d * 55, hold: 420 });
      });
    },
    // a wrong creature: it pops up the same, turns sad, flashes red (its cell
    // glowing red) and shakes its head "no", then drops away in a poof; the
    // board shakes, everyone startles with a worried look
    wrong(cell) {
      unmark(cell);
      setRed(cell);
      cancelHops(cell);
      const P = poses[cell];
      pop(cell).then(() => {
        face(cell, 'sad', { ms: 100 });
        timing(P.red, 1, 640, Easing.linear).start();
        timing(P.no, 1, 620, Easing.linear).start();
        later(130, () => rock(cell, [0.45, -0.45, 0.35, -0.2, 0], 480));
        later(740, () => {
          const q = standOn(B, cell);
          const p = poseOn(cell);
          const e = Easing.in(Easing.quad);
          fx.current?.burst('poof', q.x, q.y - q.s * 0.3, q.s / 56);
          Animated.parallel([
            timing(P.y, p.y + B.T * 0.5, 320, e),
            timing(P.k, p.k * 0.5, 320, e),
            timing(P.rot, 1.6, 320, e),
            timing(P.o, 0, 320, Easing.in(Easing.cubic)),
            timing(P.shadow, 0, 140),
          ]).start(() => {
            show(cell, false);
            setRed((x) => (x === cell ? -1 : x));
          });
        });
      });
      later(260, () => {
        const q = standOn(B, cell);
        fx.current?.burst('angry', q.x, q.y - q.s * 0.6, q.s / 56);
      });
      later(200, shake);
      placedRef.current.forEach((on, other) => {
        if (!on) return;
        const at = 240 + Math.random() * 80;
        hop(other, at, 0.18);
        face(other, 'sad', { delay: at, hold: 420 });
      });
    },
    wiggle(cell) {
      face(cell, 'happy', { hold: 380 });
      rock(cell, [-0.7, 0.7, -0.4, 0], 380);
    },
    // the board cascading in, a diagonal wave from the back left
    intro() {
      for (let cell = 0; cell < N; cell++) {
        const A = cellA[cell];
        A.a.setValue(0);
        timing(A.a, 1, 300, Easing.out(Easing.back(1.4)), ((cell % n) + Math.floor(cell / n)) * 34).start();
      }
    },
    outro() {
      for (let cell = 0; cell < N; cell++) timing(cellA[cell].a, 0, 220, Easing.in(Easing.quad), (2 * n - 2 - (cell % n) - Math.floor(cell / n)) * 18).start();
    },
    // The win: every creature turns happy, and a bounce ripples out over the
    // board from `from` (the last one placed): the cushions bob, the creatures
    // jump (twice unless `once`), a wave of stars over half the cells. It starts with the last
    // one's hop for joy (place). `spread`: ms from the first jump to the
    // farthest. Returns when each creature jumps (ms from now, in order), for
    // the games' hop sounds.
    hopAll(from = 0, { spread = 380, once = false } = {}) {
      const start = Math.max(0, landAt.current + 120 - Date.now());
      const far = Math.max(1, ...Array.from({ length: N }, (_, x) => gap(x, from)));
      const step = Math.min(70, spread / far);
      const beats = [];
      const pts = [];
      for (let cell = 0; cell < N; cell++) {
        const d = gap(cell, from) * step;
        bounce(cell, start + d);
        const on = placedRef.current[cell];
        // stars on half the cells, no glows: a 9×9's every cell would mount ~150 views at once
        if ((Math.floor(cell / n) + cell) % 2 === 0) pts.push(spot(cell, d, false));
        if (!on) continue;
        cancelHops(cell);
        face(cell, 'happy', { delay: cell === from ? 0 : 60 });
        hop(cell, start + d, 0.6);
        if (!once) hop(cell, start + d + 380, 0.32);
        beats.push(start + d);
      }
      later(start, () => fx.current?.wave(pts, B.c * 0.9));
      return beats.sort((a, b) => a - b);
    },
    // A lost level: one creature after another (nearest `from` first, else
    // back to front) turns sad, droops and sinks a little, and stays so,
    // `step` ms apart. Returns how long that takes (ms).
    sadAll(from = -1, { step = SAD_STEP } = {}) {
      const on = placedCells();
      if (from >= 0) on.sort((a, b) => gap(a, from) - gap(b, from));
      on.forEach((cell, i) => {
        const at = 60 + i * step;
        const P = poses[cell];
        cancelHops(cell);
        face(cell, 'sad', { delay: at, ms: 180 });
        later(at, () => {
          const p = poseOn(cell);
          const side = (cell + Math.floor(cell / n)) % 2 ? 1 : -1;
          timing(P.droop, 1, 460, Easing.out(Easing.back(1.4))).start();
          timing(P.y, p.y + B.T * 0.06, 460, Easing.out(Easing.quad)).start();
          timing(P.rot, side * 0.35, 460, Easing.inOut(Easing.quad)).start();
        });
      });
      return on.length ? 60 + (on.length - 1) * step + 460 : 0;
    },
    // after a lost run is saved (Blitz): everyone perks back up with a hop
    cheerUp() {
      placedCells().forEach((cell, i) => {
        const P = poses[cell];
        const p = poseOn(cell);
        face(cell, 'idle', { ms: 200 });
        timing(P.droop, 0, 260).start();
        timing(P.y, p.y, 260).start();
        timing(P.rot, 0, 260).start();
        hop(cell, 160 + i * 40, 0.35);
      });
    },
    shake,
  }));

  // Now and then one placed creature does a trick, so a board in progress
  // never sits still (not while the board is locked).
  useEffect(() => {
    const timer = setInterval(() => {
      if (live.current.locked) return;
      const on = [];
      placedRef.current.forEach((x, i) => x && on.push(i));
      if (!on.length) return;
      const cell = on[Math.floor(Math.random() * on.length)];
      if (Math.random() < 0.5) hop(cell, 0, 0.3);
      else rock(cell, [-0.5, 0.5, 0], 420);
    }, 1400);
    return () => clearInterval(timer);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  // --- touches: tap, drag-to-mark, long-press-to-mark ------------------------------
  // (the cell under a finger: board.js's perspective, from where the finger is
  // on the board area; everything on it lets touches through)
  const gesture = useRef({ offX: 0, offY: 0, start: -1, last: -1, painting: false, paintOn: true, moved: false, timer: null, longDone: false });
  const cellAt = (pageX, pageY) => {
    const g = gesture.current;
    const b = live.current.B;
    const cell = cellAtPoint(b, pageX - g.offX, pageY - g.offY);
    return cell;
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
          if (L.xTool && L.allowX) {
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
          if (L.locked || g.start < 0 || g.longDone || g.moved) return;
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

  const cells = useMemo(() => Array.from({ length: N }, (_, i) => i), [N]);
  return (
    <Animated.View style={[styles.fill, { transform: [{ translateX: shakeX }] }]} {...responder.panHandlers}>
      <View pointerEvents="none" style={StyleSheet.absoluteFill}>
        {cells.map((cell) => (
          <Cushion key={cell} B={B} cell={cell} col={colorIdx(regions[cell])} a={cellA[cell].a} bump={cellA[cell].bump} />
        ))}
        {cells.map((cell) => (marks[cell] && !placed[cell] ? <XMark key={`x${cell}`} B={B} cell={cell} /> : null))}
        {red >= 0 ? <RedGlow key={`r${red}`} B={B} cell={red} /> : null}
        {cells.map((cell) =>
          shown[cell] ? <Piece key={`p${cell}`} c={pieceOf(cell)} w={pw} h={hOf(cell)} a={poses[cell]} z={zOf(cell)} shade={SHADE} friend delay={(cell * 530) % 2600} /> : null,
        )}
      </View>
      <FxLayer ref={fx} />
    </Animated.View>
  );
}

const styles = StyleSheet.create({
  fill: { ...StyleSheet.absoluteFillObject },
});

export default memo(forwardRef(RoomBoard));

// where a board of n × n goes in an area (board.js layout): leaned back less
// than Squish Hop's, so the bigger boards keep big cells
export const SDK_TILT = 30;
