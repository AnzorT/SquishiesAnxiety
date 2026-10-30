import React, { memo, useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { Animated, AppState, BackHandler, Easing, PanResponder, StyleSheet, Text, View } from 'react-native';
import Svg, { Path } from 'react-native-svg';
import RoundButton, { BackGlyph } from '../components/candy/RoundButton';
import useRewardedAd from '../components/useRewardedAd';
import sfx from '../audio/sfx';
import { FxLayer, PopIn } from '../squishdoku/fx';
import { makeHaptics, pickCreatures, prefetchImages, useClock } from '../squishdoku/game';
import { Countdown } from '../squishdoku/BlitzGame';
import { Pips } from '../squishdoku/Hud';
import { BlitzFailCard, BlitzWinCard, PauseCard as BlitzPauseCard, ReviveCard } from '../squishdoku/Overlays';
import { BtnLabel, Chip, SdButton } from '../squishdoku/ui';
import { F, INK } from '../squishdoku/theme';
import { saveStack } from '../firebase/firestore';
import { Banner, Bar } from '../sort/Game';
import { FailCard, HintCard, PauseCard, ResultCard } from './Cards';
import { bestMove, canMove, left as movesLeft, makePuzzle, same, stackOf, topOf } from './engine';
import { BLITZ_MS, BLITZ_ROUNDS, LEVELS, TIER_COLORS, TIER_NAMES, afterBlitz, afterLevel, blitzSpec, clock, levelSpec, limitFor, record, starsFor } from './levels';
import { Cushion, GoalCard, OVER, StarBadge, Squishy, bodyH } from './Pieces';
import { pickCast } from './roster';
import { usePingPong } from '../components/idleLoop';

// One level of Squish Stack (SQUISH_STACK.md), and the next ones after it:
//   intro  the level's number and what's in it
//   deal   the squishies drop onto their cushions, one after another
//   play   tap a cushion to lift its top squishy (it hovers and wiggles),
//          tap another to put it there; or drag it. A big one dropped on a
//          smaller one squashes it flat and boings home (no move counted).
//          The clock runs from level 15.
//   won / lost (the clock ran out)
// The puzzle's rules are engine.js; this draws and animates them.
//
// Blitz (`blitz`, levels.js BLITZ_*): ten puzzles on one clock after a 3, 2,
// 1, GO! A big one dropped on a smaller one is a mistake: the clock stops
// ('held') and the run ends, unless its one revive is used. No hints.

const LOAD_SOUNDS = ['st_lift', 'st_land', 'st_cushion', 'st_ouch', 'st_bounce', 'st_undo', 'st_hint', 'st_empty', 'st_news', 'sd_tick', 'sd_solve', 'sd_confetti', 'sd_boardIn', 'sd_timeUp'];

const GAP = 16; // between the tallest tower and a lifted squishy
const GRAVITY = Easing.bezier(0.55, 0, 1, 0.45);

const NEWS = {
  picture: { text: 'GOAL CARD!', sub: 'Make the cushions look like the picture' },
  clock: { text: 'BEAT THE CLOCK!', sub: 'From now on, every level has a timer' },
  cushion: { text: 'A 4TH CUSHION!', sub: 'Big towers move much faster now' },
};

// --- geometry -------------------------------------------------------------------------

// Squished a little by the ones sitting on it.
const weightOf = (above) => ({ sx: 1 + 0.035 * above, sy: Math.max(0.8, 1 - 0.045 * above) });

// A stack's feet lines (0 = the cushion, negative is up), bottom to top.
function stackLines(list, bh) {
  let yb = 0;
  const out = [];
  list.forEach((r, j) => {
    const w = weightOf(list.length - 1 - j);
    out.push({ r, yb, ...w });
    yb -= bh[r] * w.sy * (1 - OVER);
  });
  const height = list.length ? -(out[out.length - 1].yb - bh[list[list.length - 1]]) : 0;
  return { out, height };
}

// Where everything goes in a w × h play area: a column per cushion, the
// squishies sized by rank (the smallest half the biggest), all shrunk
// together until the tallest tower and a lifted squishy above it fit.
function geometry(w, h, n, k, who) {
  const colW = w / k;
  const cushW = Math.min(colW * 0.86, 150);
  const cushH = Math.max(24, Math.min(cushW * 0.34, 44));
  const surface = h - 18 - cushH * 0.6;
  const ratio = who.map((c) => bodyH(c, 1));
  const widths = (m) => Array.from({ length: n }, (_, r) => m * (n === 1 ? 1 : 0.5 + (0.5 * r) / (n - 1)));
  const maxW = Math.min(colW * 0.94, 140);
  let bw = widths(maxW);
  let bh = bw.map((x, r) => x * ratio[r]);
  const tower = stackLines(Array.from({ length: n }, (_, i) => n - 1 - i), bh).height;
  const s = Math.max(0.3, Math.min(1, (surface - 10) / (tower + GAP + Math.max(...bh))));
  bw = widths(maxW * s);
  bh = bw.map((x, r) => x * ratio[r]);
  return { w, h, k, colW, cushW, cushH, surface, bw, bh, hover: surface - tower * s - GAP };
}
const cx = (G, p) => G.colW * (p + 0.5);
// every squishy's top-left, its weight and drawing order (`skip`: the lifted one)
function spotsOf(G, pos, skip = -1) {
  const m = {};
  for (let p = 0; p < G.k; p++) {
    stackLines(stackOf(pos, p).filter((r) => r !== skip), G.bh).out.forEach((o, j) => {
      m[o.r] = { x: cx(G, p) - G.bw[o.r] / 2, y: G.surface + o.yb - G.bh[o.r], sx: o.sx, sy: o.sy, z: 10 + j };
    });
  }
  return m;
}

// --- drawing ---------------------------------------------------------------------------

// A squishy: placed (x, y), squished by the ones on it (wx, wy, from its
// feet), and its own squash / hop / wiggle on top.
const Piece = memo(function Piece({ c, w, h, a, z }) {
  const wT = a.wy.interpolate({ inputRange: [0, 1], outputRange: [h / 2, 0] });
  const sqX = a.sq.interpolate({ inputRange: [-1, 0, 1], outputRange: [0.9, 1, 1.22] });
  const sqY = a.sq.interpolate({ inputRange: [-1, 0, 1], outputRange: [1.12, 1, 0.74] });
  const sqT = a.sq.interpolate({ inputRange: [-1, 0, 1], outputRange: [-0.06 * h, 0, 0.13 * h] });
  const rotate = a.rot.interpolate({ inputRange: [-1, 1], outputRange: ['-6deg', '6deg'] });
  return (
    <Animated.View pointerEvents="none" style={[styles.piece, { width: w, height: h, zIndex: z, opacity: a.o, transform: [{ translateX: a.x }, { translateY: a.y }] }]}>
      <Animated.View style={{ transform: [{ translateY: wT }, { scaleX: a.wx }, { scaleY: a.wy }] }}>
        <Animated.View style={{ transform: [{ translateY: a.hop }, { translateY: sqT }, { scaleX: sqX }, { scaleY: sqY }, { rotate }] }}>
          <Squishy c={c} w={w} />
        </Animated.View>
      </Animated.View>
    </Animated.View>
  );
});

// A cushion in its place, bumping when something lands on it, glowing for
// the tutorial and the hint ('white' / 'gold').
const Seat = memo(function Seat({ i, x, top, w, h, star, bump, glow }) {
  // one native loop (src/components/idleLoop.js)
  const pulse = usePingPong(960, { on: !!glow });
  return (
    <View pointerEvents="none" style={[styles.seat, { left: x - w / 2, top, width: w, height: h + 5 }]}>
      {glow ? (
        <Animated.View
          style={[
            styles.halo,
            {
              borderRadius: h,
              backgroundColor: glow === 'gold' ? 'rgba(255,224,69,0.85)' : 'rgba(255,255,255,0.8)',
              opacity: pulse.interpolate({ inputRange: [0, 1], outputRange: [0.3, 0.95] }),
              transform: [{ scale: pulse.interpolate({ inputRange: [0, 1], outputRange: [0.94, 1.08] }) }],
            },
          ]}
        />
      ) : null}
      <Animated.View
        style={{
          transform: [
            { translateY: bump.interpolate({ inputRange: [-1, 0, 1], outputRange: [-h * 0.04, 0, h * 0.09] }) },
            { scaleX: bump.interpolate({ inputRange: [-1, 0, 1], outputRange: [0.97, 1, 1.07] }) },
            { scaleY: bump.interpolate({ inputRange: [-1, 0, 1], outputRange: [1.06, 1, 0.8] }) },
          ],
        }}
      >
        <Cushion w={w} h={h} i={i} />
      </Animated.View>
      {star ? (
        <View style={[styles.badge, { left: w / 2 - 14, top: h - 9 }]}>
          <StarBadge size={28} />
        </View>
      ) : null}
    </View>
  );
});

const STAR_D = 'M12 2.2 L14.9 8.6 L21.8 9.3 L16.6 14 L18.1 20.9 L12 17.4 L5.9 20.9 L7.4 14 L2.2 9.3 L9.1 8.6 Z';
// the stars still possible, if every move from here is the best one
const Meter = memo(function Meter({ stars }) {
  return (
    <View style={styles.meter}>
      {[0, 1, 2].map((i) => (
        <Svg key={i} width={i === 1 ? 26 : 21} height={i === 1 ? 26 : 21} viewBox="0 0 24 24" style={{ marginTop: i === 1 ? 0 : 4 }}>
          <Path d={STAR_D} fill={i < stars ? '#ffd23a' : 'rgba(255,255,255,0.55)'} stroke={i < stars ? '#b86200' : '#b9a6cc'} strokeWidth={1.6} strokeLinejoin="round" />
        </Svg>
      ))}
    </View>
  );
});

// the line under the meter on levels with no clock
function tipFor(spec, holding, moves) {
  if (spec.lv === 1 && moves === 0) return holding ? 'Now tap the ★ cushion to put it there!' : 'Tap a cushion to lift the squishy on top.';
  if (spec.lv <= 3) return 'A big squishy can never sit on a smaller one!';
  if (spec.goal === 'picture') return 'Make the cushions look like the GOAL card.';
  return 'Get everyone onto the ★ cushion.';
}

// state with a ref beside it, for the touch handlers and the timers
function useRefState(init) {
  const [v, setV] = useState(init);
  const ref = useRef(init);
  const set = useCallback((x) => {
    ref.current = x;
    setV(x);
  }, []);
  return [v, ref, set];
}

// --- the game --------------------------------------------------------------------------

export default function StackGame({ startLv = 1, cast, blitz = false, profile, uid, adsFree, haptics: hapticsOn = true, onExit }) {
  const haptics = useRef(makeHaptics(hapticsOn)).current;
  const ad = useRewardedAd();
  const [lv, setLv] = useState(startLv);
  const [round, setRound] = useState(0);
  // Blitz: the run, its puzzle, the puzzles done (the pips), the revive,
  // which of its cards is up, and the countdown
  const [run, setRun] = useState(0);
  const [idx, setIdx] = useState(0);
  const idxRef = useRef(0);
  idxRef.current = idx;
  const [done, setDone] = useState(0);
  const [revived, setRevived] = useState(false);
  const revivedRef = useRef(false);
  revivedRef.current = revived;
  const [blitzCard, setBlitzCard] = useState(null); // revive | fail | win
  const [failReason, setFailReason] = useState('mistake');
  const [blitzWin, setBlitzWin] = useState(null);
  const [count, setCount] = useState(null); // 3, 2, 1, 'GO!'
  const runStarted = useRef(false);
  // the level at the player's skill when it starts (adaptive difficulty;
  // fixed for the puzzle even when the saved skill changes under it)
  const profileRef = useRef(profile);
  profileRef.current = profile;
  const spec = useMemo(
    () => (blitz ? blitzSpec(idx, record(profileRef.current).bSkill) : levelSpec(lv, record(profileRef.current).skill)),
    [lv, round, idx, run], // eslint-disable-line react-hooks/exhaustive-deps
  );
  // a fresh puzzle and fresh squishies for every level and every retry
  const puzzle = useMemo(() => makePuzzle(spec), [spec]);
  const who = useMemo(() => pickCast(cast, spec.n), [puzzle]); // eslint-disable-line react-hooks/exhaustive-deps
  const limit = limitFor(spec, puzzle.par);

  const [area, setArea] = useState(null);
  const areaRef = useRef(null);
  const origin = useRef({ x: 0, y: 0 });
  const onArea = useCallback((e) => {
    const { width, height } = e.nativeEvent.layout;
    if (width > 0 && height > 0) setArea((a) => (a && a.w === width && a.h === height ? a : { w: width, h: height }));
    areaRef.current?.measure((x, y, w, h, px, py) => (origin.current = { x: px, y: py }));
  }, []);
  const g = useMemo(() => (area && who.length === spec.n ? geometry(area.w, area.h, spec.n, spec.k, who) : null), [area, spec, who]);

  const anims = useMemo(
    () =>
      who.map(() => ({
        x: new Animated.Value(0),
        y: new Animated.Value(0),
        o: new Animated.Value(0),
        wx: new Animated.Value(1),
        wy: new Animated.Value(1),
        sq: new Animated.Value(0),
        hop: new Animated.Value(0),
        rot: new Animated.Value(0),
        tgt: null, // where it's headed
        w: -1, // the weight it's squished to
        tok: 0, // bumped by every new move, so a stale landing does nothing
        wig: null,
      })),
    [who],
  );
  const bumps = useMemo(() => Array.from({ length: 4 }, () => new Animated.Value(0)), []);
  const fx = useRef(null);
  const clk = useClock();

  // --- state ---
  const [phase, phaseRef, setPhase] = useRefState('load');
  const [pos, posRef, setPos] = useRefState(puzzle.start);
  const [held, heldRef, setHeld] = useRefState(null); // { r, from }
  const [moves, movesRef, setMoves] = useRefState(0);
  const [hinted, hintedRef, setHinted] = useRefState(false);
  const [paused, pausedRef, setPaused] = useRefState(false);
  const hist = useRef([]);
  const [canUndo, setCanUndo] = useState(false);
  const [top, setTop] = useState(-1); // the last one moved, drawn over the rest
  const [glow, setGlow] = useState(null); // the hint: { from, to }
  const [dragCol, setDragCol] = useState(-1);
  const [banner, setBanner] = useState(null);
  const [secs, setSecs] = useState(0);
  const [result, setResult] = useState(null);
  const [fail, setFail] = useState(false);
  const [hintAsk, setHintAsk] = useState(false);
  const hintAskRef = useRef(false);
  hintAskRef.current = hintAsk;
  const say = useCallback((text, more = {}) => setBanner({ text, key: Date.now(), ...more }), []);

  // timers, cleared on a new puzzle and on leaving
  const timers = useRef([]);
  const alive = useRef(true);
  const later = useCallback((ms, fn) => {
    const id = setTimeout(() => alive.current && fn(), ms);
    timers.current.push(id);
    return id;
  }, []);
  const clearTimers = useCallback(() => {
    timers.current.forEach(clearTimeout);
    timers.current = [];
  }, []);
  useEffect(() => {
    alive.current = true;
    sfx.preload(LOAD_SOUNDS);
    return () => {
      alive.current = false;
      clearTimers();
    };
  }, [clearTimers]);

  // what the handlers and timers read
  const live = useRef({});
  live.current = { g, anims, puzzle, spec, who, bumps, limit };

  // --- moving things ---------------------------------------------------------------------

  const rateOf = (r) => 1.25 - (0.45 * r) / Math.max(1, live.current.spec.n - 1);
  const hoverY = (r) => live.current.g.hover - live.current.g.bh[r];
  const xOf = (r, p) => cx(live.current.g, p) - live.current.g.bw[r] / 2;

  // Everyone not lifted springs to where they belong, squished by what's on them.
  function settle() {
    const { g: G, anims: AS } = live.current;
    if (!G) return;
    const h = heldRef.current;
    const m = spotsOf(G, posRef.current, h ? h.r : -1);
    Object.keys(m).forEach((k) => {
      const r = Number(k);
      const A = AS[r];
      const s = m[r];
      if (A.w !== s.sy) {
        A.w = s.sy;
        Animated.parallel([
          Animated.spring(A.wx, { toValue: s.sx, friction: 5, tension: 140, useNativeDriver: true }),
          Animated.spring(A.wy, { toValue: s.sy, friction: 5, tension: 140, useNativeDriver: true }),
        ]).start();
      }
      if (A.tgt && Math.abs(A.tgt.x - s.x) < 0.5 && Math.abs(A.tgt.y - s.y) < 0.5) return;
      A.tgt = { x: s.x, y: s.y };
      A.tok += 1;
      Animated.parallel([
        Animated.spring(A.x, { toValue: s.x, friction: 7, tension: 120, useNativeDriver: true }),
        Animated.spring(A.y, { toValue: s.y, friction: 7, tension: 120, useNativeDriver: true }),
      ]).start();
    });
  }

  // steps: [{ x, y, ms, ex, ey }] one after another; `done` only if nothing
  // else moved it meanwhile
  function fly(r, steps, done) {
    const A = live.current.anims[r];
    const tok = ++A.tok;
    const last = steps[steps.length - 1];
    A.tgt = { x: last.x, y: last.y };
    Animated.sequence(
      steps.map((s) =>
        Animated.parallel([
          Animated.timing(A.x, { toValue: s.x, duration: s.ms, easing: s.ex || Easing.inOut(Easing.quad), useNativeDriver: true }),
          Animated.timing(A.y, { toValue: s.y, duration: s.ms, easing: s.ey || Easing.inOut(Easing.quad), useNativeDriver: true }),
        ]),
      ),
    ).start(({ finished }) => {
      if (finished && A.tok === tok && alive.current && done) done();
    });
  }

  function wiggle(r, on) {
    const A = live.current.anims[r];
    A.wig?.stop();
    A.wig = null;
    if (!on) {
      Animated.spring(A.rot, { toValue: 0, friction: 4, tension: 160, useNativeDriver: true }).start();
      return;
    }
    A.wig = Animated.loop(
      Animated.sequence([
        Animated.timing(A.rot, { toValue: 1, duration: 260, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
        Animated.timing(A.rot, { toValue: -1, duration: 260, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
      ]),
    );
    A.wig.start();
  }

  function bump(p, k = 1) {
    const B = live.current.bumps[p];
    B.setValue(0);
    Animated.sequence([
      Animated.timing(B, { toValue: k, duration: 80, easing: Easing.out(Easing.quad), useNativeDriver: true }),
      Animated.spring(B, { toValue: 0, friction: 3.5, tension: 170, useNativeDriver: true }),
    ]).start();
  }

  function pickUp(r, p) {
    const A = live.current.anims[r];
    setHeld({ r, from: p });
    setTop(r);
    setGlow(null);
    sfx.play('st_lift', { rate: rateOf(r) });
    haptics.tap();
    if (A.w !== 1) {
      A.w = 1;
      Animated.parallel([
        Animated.spring(A.wx, { toValue: 1, friction: 5, tension: 140, useNativeDriver: true }),
        Animated.spring(A.wy, { toValue: 1, friction: 5, tension: 140, useNativeDriver: true }),
      ]).start();
    }
    A.tgt = { x: xOf(r, p), y: hoverY(r) };
    A.tok += 1;
    Animated.parallel([
      Animated.timing(A.x, { toValue: A.tgt.x, duration: 150, easing: Easing.out(Easing.quad), useNativeDriver: true }),
      Animated.timing(A.y, { toValue: A.tgt.y, duration: 200, easing: Easing.out(Easing.back(1.6)), useNativeDriver: true }),
    ]).start();
    wiggle(r, true);
    settle(); // the stack under it stands up a little
  }

  function land(r, soft = false) {
    if (heldRef.current && heldRef.current.r === r) return;
    const { g: G, anims: AS } = live.current;
    settle(); // the ones under it squish down a little
    const A = AS[r];
    A.sq.setValue(0);
    Animated.sequence([
      Animated.timing(A.sq, { toValue: soft ? 0.6 : 1, duration: 70, useNativeDriver: true }),
      Animated.spring(A.sq, { toValue: 0, friction: 3.5, tension: 170, useNativeDriver: true }),
    ]).start();
    const p = posRef.current[r];
    if (stackOf(posRef.current, p)[0] === r) {
      bump(p, soft ? 0.6 : 1);
      sfx.play('st_cushion', { rate: rateOf(r) });
    } else sfx.play('st_land', { rate: rateOf(r) });
    if (soft) return;
    haptics.place();
    const s = spotsOf(G, posRef.current)[r];
    fx.current?.burst('dust', cx(G, p), s.y + G.bh[r] * 0.98, 0.8);
    if (phaseRef.current === 'play' && same(posRef.current, live.current.puzzle.goal)) win();
  }

  // the lifted one let go over cushion p
  function drop(p, dragged = false) {
    const h = heldRef.current;
    if (!h) return;
    const G = live.current.g;
    const { r, from } = h;
    wiggle(r, false);
    setDragCol(-1);
    setHeld(null);
    if (p === from || p < 0) {
      const s = spotsOf(G, posRef.current)[r];
      fly(r, [{ x: s.x, y: s.y, ms: 170, ey: GRAVITY }], () => land(r, true));
      return;
    }
    if (canMove(posRef.current, from, p) < 0) {
      bounce(r, from, p);
      return;
    }
    const next = posRef.current.slice();
    next[r] = p;
    setPos(next);
    hist.current.push([r, from, p]);
    setCanUndo(true);
    setMoves(movesRef.current + 1);
    const s = spotsOf(G, next)[r];
    const dx = Math.abs(cx(G, p) - cx(G, from));
    if (dragged) fly(r, [{ x: s.x, y: s.y, ms: 200, ex: Easing.out(Easing.quad), ey: GRAVITY }], () => land(r));
    else fly(r, [{ x: s.x, y: hoverY(r), ms: 110 + dx * 0.45 }, { x: s.x, y: s.y, ms: 170, ey: GRAVITY }], () => land(r));
  }

  // Too big for cushion p: it lands on the small one's head, squashes it
  // flat, and boings home. No move counted.
  function bounce(r, from, p) {
    const { g: G, anims: AS, spec: S } = live.current;
    const t = topOf(posRef.current, p);
    const ts = spotsOf(G, posRef.current)[t];
    const sit = ts.y + G.bh[t] * (1 - ts.sy) + G.bh[t] * 0.42 - G.bh[r];
    const dx = Math.abs(cx(G, p) - cx(G, from));
    setTop(r);
    fly(r, [{ x: xOf(r, p), y: hoverY(r), ms: 110 + dx * 0.45 }, { x: xOf(r, p), y: sit, ms: 140, ey: GRAVITY }], () => {
      const T = AS[t];
      T.sq.setValue(0);
      Animated.sequence([
        Animated.timing(T.sq, { toValue: 1.7, duration: 80, useNativeDriver: true }),
        Animated.timing(T.sq, { toValue: 1.55, duration: 180, useNativeDriver: true }),
        Animated.spring(T.sq, { toValue: 0, friction: 3, tension: 140, useNativeDriver: true }),
      ]).start();
      sfx.play('st_ouch');
      haptics.wrong();
      fx.current?.burst('angry', cx(G, p), ts.y + G.bh[t] * 0.5, 1);
      say('TOO BIG!', { small: true, ink: '#8e1030', hold: 380, sub: S.lv <= 3 ? 'Big ones never sit on smaller ones' : null });
      if (blitz) blitzMistake();
      const tok = AS[r].tok;
      later(260, () => {
        if (AS[r].tok !== tok || (heldRef.current && heldRef.current.r === r)) return;
        sfx.play('st_bounce');
        const s = spotsOf(G, posRef.current)[r];
        fly(r, [{ x: xOf(r, p), y: hoverY(r) - 24, ms: 220, ey: Easing.out(Easing.quad) }, { x: s.x, y: hoverY(r) - 10, ms: 130 + dx * 0.45 }, { x: s.x, y: s.y, ms: 170, ey: GRAVITY }], () => land(r, true));
      });
    });
  }

  // Blitz: a mistake stops the clock; then the revive, or the run's over
  function blitzMistake() {
    clk.pause();
    setPhase('held');
    setGlow(null);
    if (heldRef.current) drop(heldRef.current.from);
    later(1000, () => {
      if (revivedRef.current) endRun('mistake');
      else setBlitzCard('revive');
    });
  }

  // Blitz: the run's over (a mistake with the revive used or turned down, or
  // the clock), back to puzzle 1
  function endRun(reason) {
    setPhase('lost');
    clk.pause();
    setGlow(null);
    if (heldRef.current) drop(heldRef.current.from);
    setFailReason(reason);
    setBlitzCard('fail');
    if (reason === 'time') sfx.play('sd_timeUp');
    haptics.wrong();
    later(reason === 'time' ? 900 : 0, () => sfx.play('sd_blitzFail'));
    later(reason === 'time' ? 1500 : 600, () => {
      sfx.play('sd_drain');
      setDone(0);
    });
    const out = afterBlitz(profileRef.current, { won: false, reached: idxRef.current + 1 });
    if (uid) saveStack(uid, out.update, 0);
  }

  function undo() {
    if (phaseRef.current !== 'play' || pausedRef.current) return;
    if (heldRef.current) drop(heldRef.current.from);
    const m = hist.current.pop();
    if (!m) return;
    setCanUndo(hist.current.length > 0);
    const [r, from, to] = m;
    const next = posRef.current.slice();
    next[r] = from;
    setPos(next);
    setTop(r);
    setGlow(null);
    sfx.play('st_undo');
    const G = live.current.g;
    const s = spotsOf(G, next)[r];
    fly(r, [{ x: xOf(r, to), y: hoverY(r), ms: 140, ey: Easing.out(Easing.quad) }, { x: s.x, y: hoverY(r), ms: 150 }, { x: s.x, y: s.y, ms: 160, ey: GRAVITY }], () => land(r, true));
    settle(); // the stack it left stands up
  }

  // everyone back where this puzzle started (the clock keeps going)
  function restart() {
    if (phaseRef.current !== 'play' || pausedRef.current) return;
    if (heldRef.current) {
      wiggle(heldRef.current.r, false);
      setHeld(null);
    }
    setPos(live.current.puzzle.start.slice());
    hist.current = [];
    setCanUndo(false);
    setMoves(0);
    setGlow(null);
    sfx.play('st_undo', { rate: 0.8 });
    settle();
  }

  function showHint() {
    if (phaseRef.current !== 'play') return;
    if (heldRef.current) drop(heldRef.current.from);
    const { puzzle: P, anims: AS, g: G } = live.current;
    const m = bestMove(P.sol, posRef.current);
    if (!m) return;
    const [r, from, to] = m;
    setHinted(true);
    setGlow({ from, to });
    const A = AS[r];
    Animated.sequence(
      [0, 1].flatMap(() => [
        Animated.timing(A.hop, { toValue: -G.bh[r] * 0.28, duration: 170, easing: Easing.out(Easing.quad), useNativeDriver: true }),
        Animated.timing(A.hop, { toValue: 0, duration: 200, easing: Easing.bounce, useNativeDriver: true }),
      ]),
    ).start();
    sfx.play('st_hint');
    fx.current?.burst('spark', cx(G, to), G.surface - 4, 1);
    later(2800, () => setGlow((x) => (x && x.from === from && x.to === to ? null : x)));
  }
  function askHint() {
    if (phaseRef.current !== 'play' || pausedRef.current) return;
    if (hintedRef.current) watchHint();
    else setHintAsk(true);
  }
  function watchHint() {
    setHintAsk(false);
    if (adsFree) {
      showHint();
      return;
    }
    // the ad leaves the app (the pause card comes up); a reward brings the game back
    ad.show(() => {
      setPaused(false);
      if (live.current.spec.clock) clk.resume();
      later(250, () => acts.current.showHint());
    });
  }

  function win() {
    setPhase('won');
    clk.pause();
    setGlow(null);
    const { g: G, anims: AS, puzzle: P, spec: S } = live.current;
    sfx.play('sd_solve');
    haptics.win();
    // a hop down each tower, top first
    let i = 0;
    for (let p = 0; p < S.k; p++) {
      stackOf(posRef.current, p)
        .slice()
        .reverse()
        .forEach((r) => {
          const d = 150 + i++ * 70;
          later(d, () =>
            Animated.sequence([
              Animated.timing(AS[r].hop, { toValue: -G.bh[r] * 0.3, duration: 170, easing: Easing.out(Easing.quad), useNativeDriver: true }),
              Animated.timing(AS[r].hop, { toValue: 0, duration: 220, easing: Easing.bounce, useNativeDriver: true }),
            ]).start(),
          );
        });
    }
    // (Blitz keeps its confetti for the end of the run)
    const last = !blitz || idxRef.current === BLITZ_ROUNDS - 1;
    if (last) {
      later(250, () => {
        sfx.play('sd_confetti');
        fx.current?.burst('confetti', G.w / 2, G.h * 0.35, 1.2);
      });
      later(650, () => fx.current?.burst('confetti', G.w * 0.25, G.h * 0.5, 1));
      later(800, () => fx.current?.burst('confetti', G.w * 0.75, G.h * 0.5, 1));
    }
    if (blitz) {
      // a pip fills; on to the next puzzle, or the run is won
      const i = idxRef.current;
      later(300, () => {
        setDone(i + 1);
        sfx.play('sd_pip', { rate: 0.9 + i * 0.06 });
      });
      if (i < BLITZ_ROUNDS - 1) {
        later(1300, () => {
          sfx.play('sd_blitzNext');
          setIdx(i + 1);
        });
        return;
      }
      later(1000, () => {
        const ms = clk.elapsed();
        const rec = record(profileRef.current);
        const out = afterBlitz(profileRef.current, { won: true, reached: BLITZ_ROUNDS, ms });
        if (uid) saveStack(uid, out.update, out.coins, out.xp, profileRef.current);
        setBlitzWin({ ...out, ms, newBest: !rec.blitz.bestMs || ms < rec.blitz.bestMs, uris: pickCreatures(cast.map((c) => c.uri), 3) });
        setBlitzCard('win');
        sfx.play('sd_blitzWin');
      });
      return;
    }
    const out = afterLevel(profileRef.current, S, P.par, { won: true, moves: movesRef.current, hinted: hintedRef.current });
    if (uid) saveStack(uid, out.update, out.coins, out.xp, profileRef.current);
    const { stars, coins, xp, before, after, levelUps, unlocked } = out;
    const res = { stars, coins, xp, before, after, levelUps, unlocked, moves: movesRef.current, par: P.par, hinted: hintedRef.current };
    later(1500, () => setResult(res));
  }

  function lose() {
    if (phaseRef.current !== 'play') return;
    if (blitz) {
      endRun('time');
      return;
    }
    setPhase('lost');
    clk.pause();
    setGlow(null);
    if (heldRef.current) drop(heldRef.current.from);
    sfx.play('sd_timeUp');
    haptics.wrong();
    const { puzzle: P, spec: S } = live.current;
    const out = afterLevel(profileRef.current, S, P.par, { won: false });
    if (uid) saveStack(uid, out.update, 0);
    later(1300, () => setFail(true));
  }

  // --- the round -----------------------------------------------------------------------

  function startPlay() {
    setPhase('play');
    if (blitz) {
      // the run's one clock goes on from where the last puzzle left it
      if (runStarted.current) clk.resume();
      else {
        runStarted.current = true;
        setSecs(BLITZ_MS / 1000);
        clk.start(BLITZ_MS);
      }
    } else if (live.current.spec.clock) clk.start(live.current.limit);
  }
  function deal() {
    const { g: G, anims: AS, puzzle: P, spec: S } = live.current;
    setPhase('deal');
    const m = spotsOf(G, P.start);
    let last = 0;
    for (let p = 0; p < S.k; p++) {
      stackOf(P.start, p).forEach((r, j) => {
        const d = p * 110 + j * 130;
        last = Math.max(last, d);
        later(d, () => {
          Animated.timing(AS[r].o, { toValue: 1, duration: 120, useNativeDriver: true }).start();
          fly(r, [{ x: m[r].x, y: m[r].y, ms: 380, ey: GRAVITY }], () => land(r, true));
        });
      });
    }
    later(last + 560, () => {
      const news = S.news && !record(profileRef.current).best[S.lv] ? NEWS[S.news] : null;
      if (!news) {
        startPlay();
        return;
      }
      sfx.play('st_news');
      say(news.text, { small: true, sub: news.sub, hold: 1300, ink: '#0c5a9c' });
      later(1750, startPlay);
    });
  }

  // a new puzzle: reset everything and start
  const readyKey = g ? `${Math.round(g.w)}:${Math.round(g.h)}` : '';
  useEffect(() => {
    if (!g) return undefined;
    clearTimers();
    // (Blitz keeps its clock from puzzle to puzzle: again() resets it)
    if (!blitz) clk.reset();
    setResult(null);
    setFail(false);
    setPaused(false);
    setHintAsk(false);
    setGlow(null);
    setDragCol(-1);
    setBanner(null);
    setHeld(null);
    setTop(-1);
    setPos(puzzle.start.slice());
    hist.current = [];
    setCanUndo(false);
    setMoves(0);
    setHinted(false);
    if (!blitz) setSecs(Math.ceil(limit / 1000));
    // everyone above their spot, waiting to drop in (their spots are already
    // their targets, so nothing settles them there early)
    const m = spotsOf(g, puzzle.start);
    anims.forEach((A, r) => {
      A.wig?.stop();
      A.wig = null;
      A.tok += 1;
      [A.rot, A.sq, A.hop, A.o].forEach((v) => v.setValue(0));
      A.wx.setValue(m[r].sx);
      A.wy.setValue(m[r].sy);
      A.w = m[r].sy;
      A.x.setValue(m[r].x);
      A.y.setValue(m[r].y - g.h * 0.6);
      A.tgt = { x: m[r].x, y: m[r].y };
    });
    setPhase('intro');
    // a Blitz run opens with 3, 2, 1, GO! (the first puzzle drops in on GO)
    const countdown = blitz && !runStarted.current;
    if (!countdown) {
      const chips = [TIER_NAMES[spec.tier]];
      if (spec.goal === 'picture') chips.push('GOAL CARD');
      if (spec.k === 4) chips.push('4 CUSHIONS');
      if (spec.clock) chips.push(`⏱ ${clock(limit)}`);
      say(blitz ? `PUZZLE ${spec.round}` : `LEVEL ${spec.lv}`, { chips, hold: 900 });
      sfx.play('sd_boardIn');
    }
    let gone = false;
    const t0 = Date.now();
    // (only creatures newer than the bundled cut-outs come over the network)
    prefetchImages(
      who.filter((c) => c.source.uri).map((c) => c.source.uri),
      2500,
    ).then(() => {
      if (gone) return;
      if (!countdown) {
        later(Math.max(0, 1250 - (Date.now() - t0)), deal);
        return;
      }
      [3, 2, 1, 'GO!'].forEach((s, i) =>
        later(200 + i * 700, () => {
          setCount(s);
          sfx.play(s === 'GO!' ? 'sd_go' : 'sd_count');
          haptics.tick();
          if (s === 'GO!') deal();
        }),
      );
      later(200 + 4 * 700, () => setCount(null));
    });
    return () => {
      gone = true;
    };
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [puzzle, readyKey]);

  // the clock running out (and the time left, by the second)
  const lastTick = useRef(0);
  useEffect(() => {
    if (phase !== 'play' || paused || !(spec.clock || blitz)) return undefined;
    // ticks for the last seconds (more of them on Blitz's long clock)
    const tickFrom = blitz ? 15 : 5;
    const id = setInterval(() => {
      const ms = clk.limit() - clk.elapsed();
      const s = Math.max(0, Math.ceil(ms / 1000));
      setSecs((x) => (x !== s ? s : x));
      if (s > 0 && s <= tickFrom && s !== lastTick.current) {
        lastTick.current = s;
        sfx.play('sd_tick', { rate: s <= 5 ? 1.3 : 1 });
        haptics.tick();
      }
      if (ms <= 0) acts.current.lose();
    }, 250);
    return () => clearInterval(id);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [phase, paused, spec.clock]);

  // --- pause and leaving ---------------------------------------------------------------

  function pause() {
    if (phaseRef.current !== 'play' || pausedRef.current) return;
    if (heldRef.current) drop(heldRef.current.from);
    clk.pause();
    setPaused(true);
  }
  function resume() {
    setPaused(false);
    if (live.current.spec.clock || blitz) clk.resume();
  }
  function leave() {
    clearTimers();
    clk.reset();
    onExit();
  }
  const next = useCallback(() => {
    setLv((l) => Math.min(LEVELS, l + 1));
    setRound((r) => r + 1);
  }, []);
  const replay = useCallback(() => setRound((r) => r + 1), []);
  // Blitz: a fresh run from puzzle 1
  function again() {
    clearTimers();
    clk.reset();
    runStarted.current = false;
    setBlitzCard(null);
    setBlitzWin(null);
    setRevived(false);
    setDone(0);
    setCount(null);
    setPaused(false);
    setIdx(0);
    setRun((r) => r + 1);
  }
  // Blitz: the run's one revive (an ad, free with Remove Ads), back to it
  function revive() {
    const back = () => {
      setRevived(true);
      setBlitzCard(null);
      sfx.play('sd_revive');
      setPhase('play');
      clk.resume();
    };
    if (adsFree) back();
    else ad.show(back);
  }

  const acts = useRef({});
  acts.current = { pickUp, drop, undo, restart, askHint, watchHint, showHint, pause, resume, leave, lose, replay, again, revive, endRun };

  useEffect(() => {
    const sub = BackHandler.addEventListener('hardwareBackPress', () => {
      const A = acts.current;
      if (hintAskRef.current) setHintAsk(false);
      else if (pausedRef.current) A.resume();
      else if (phaseRef.current === 'play') A.pause();
      else A.leave();
      return true;
    });
    return () => sub.remove();
  }, [pausedRef, phaseRef]);
  useEffect(() => {
    const sub = AppState.addEventListener('change', (s) => s !== 'active' && acts.current.pause());
    return () => sub.remove();
  }, []);

  // --- touch: tap a cushion to lift its top one, tap another to put it there; or drag ---

  const touch = useRef(null);
  const responder = useMemo(
    () =>
      PanResponder.create({
        onStartShouldSetPanResponder: () => phaseRef.current === 'play' && !pausedRef.current,
        onMoveShouldSetPanResponder: () => false,
        onPanResponderTerminationRequest: () => false,
        onPanResponderGrant: (e) => {
          const G = live.current.g;
          if (!G) return;
          const x = e.nativeEvent.pageX - origin.current.x;
          const y = e.nativeEvent.pageY - origin.current.y;
          const col = Math.max(0, Math.min(G.k - 1, Math.floor(x / G.colW)));
          touch.current = { x0: x, y0: y, moved: false, picked: false, dead: false };
          if (heldRef.current) return;
          const r = topOf(posRef.current, col);
          if (r < 0) {
            touch.current.dead = true;
            sfx.play('st_empty');
            bump(col, -1);
            return;
          }
          acts.current.pickUp(r, col);
          touch.current.picked = true;
        },
        onPanResponderMove: (e) => {
          const T = touch.current;
          const h = heldRef.current;
          const G = live.current.g;
          if (!T || T.dead || !h || !G) return;
          const x = e.nativeEvent.pageX - origin.current.x;
          const y = e.nativeEvent.pageY - origin.current.y;
          if (!T.moved) {
            if (Math.hypot(x - T.x0, y - T.y0) < 9) return;
            T.moved = true;
          }
          // held by its middle, a little above the finger so it can be seen
          const A = live.current.anims[h.r];
          const bw = G.bw[h.r];
          const bh = G.bh[h.r];
          A.tok += 1;
          A.tgt = null;
          A.x.stopAnimation();
          A.y.stopAnimation();
          A.x.setValue(Math.max(0, Math.min(G.w - bw, x - bw / 2)));
          A.y.setValue(Math.max(-bh * 0.3, Math.min(G.surface - bh, y - bh * 0.85)));
          const col = Math.max(0, Math.min(G.k - 1, Math.floor(x / G.colW)));
          if (col !== T.col) {
            T.col = col;
            setDragCol(col);
          }
        },
        onPanResponderRelease: (e) => {
          const T = touch.current;
          touch.current = null;
          const G = live.current.g;
          if (!T || T.dead || !heldRef.current || !G || phaseRef.current !== 'play') return;
          const x = e.nativeEvent.pageX - origin.current.x;
          const col = Math.max(0, Math.min(G.k - 1, Math.floor(x / G.colW)));
          if (T.moved) acts.current.drop(col, true);
          else if (!T.picked) acts.current.drop(col);
          // a tap that lifted it: it stays up for the next tap
        },
        onPanResponderTerminate: () => {
          const T = touch.current;
          touch.current = null;
          if (T && T.moved && heldRef.current) acts.current.drop(heldRef.current.from);
        },
      }),
    // eslint-disable-next-line react-hooks/exhaustive-deps
    [],
  );

  // --- drawing ---------------------------------------------------------------------------

  // (for the one render between a new puzzle and its reset, the old places
  // don't fit it)
  const at = pos.length === spec.n ? pos : puzzle.start;
  const zOf = {};
  for (let p = 0; p < spec.k; p++) stackOf(at, p).forEach((r, j) => (zOf[r] = 10 + j));
  const order = who.map((_, r) => r).sort((a, b) => (a === top ? 99 : zOf[a] || 0) - (b === top ? 99 : zOf[b] || 0));
  const can = starsFor(puzzle.par, { moves: moves + movesLeft(puzzle.sol, at), hinted });
  const nudge = spec.lv === 1 && moves === 0 && phase === 'play' ? (held ? puzzle.star : 0) : -1;
  const glowOf = (p) => (glow ? (p === glow.to ? 'gold' : p === glow.from ? 'white' : null) : p === nudge ? 'white' : null);
  const playing = phase === 'play' && !paused;

  return (
    <View style={styles.fill}>
      {/* the top bar */}
      <View style={styles.hud}>
        <RoundButton size={40} onPress={() => (phaseRef.current === 'play' ? acts.current.pause() : acts.current.leave())}>
          <BackGlyph />
        </RoundButton>
        <View style={styles.titleBox}>
          <Text style={styles.gameName}>{blitz ? 'SQUISH STACK · BLITZ ⚡' : 'SQUISH STACK'}</Text>
          <View style={styles.row6}>
            <Text style={styles.levelText}>{blitz ? `PUZZLE ${spec.round}/${BLITZ_ROUNDS}` : `LEVEL ${spec.lv}`}</Text>
            <View style={[styles.challenge, { backgroundColor: TIER_COLORS[spec.tier] }]}>
              <Text style={styles.challengeText}>{TIER_NAMES[spec.tier]}</Text>
            </View>
          </View>
        </View>
        {blitz ? (
          <Chip bg={revived ? '#b9a6cc' : '#ffb02e'} color="#ffffff">
            {revived ? 'REVIVE USED' : '♥ 1 REVIVE'}
          </Chip>
        ) : (
          <View style={styles.movesPill}>
            <Text style={styles.movesLabel}>MOVES</Text>
            <Text style={styles.movesNum}>{moves}</Text>
          </View>
        )}
      </View>
      {blitz ? (
        <View style={styles.pips}>
          <Pips count={BLITZ_ROUNDS} done={done} current={blitzCard === 'fail' || blitzCard === 'win' ? -1 : idx} />
        </View>
      ) : null}

      {/* the goal, and the stars still possible and the clock or a tip
          (Blitz: the run's clock and its rule) */}
      <View style={styles.info}>
        <GoalCard who={who} goal={puzzle.goal} k={spec.k} star={puzzle.star} />
        <View style={styles.infoRight}>
          {blitz ? (
            <>
              <View style={styles.clockRow}>
                <Text style={[styles.clockText, phase === 'play' && secs <= 15 && { color: '#e01e4a' }]}>{clock((runStarted.current ? secs : BLITZ_MS / 1000) * 1000)}</Text>
                <Bar frac={clk.frac} colors={['#b0fbff', '#3fd7f6']} />
              </View>
              <Text style={styles.blitzRule} numberOfLines={2}>
                Big on small = back to puzzle 1!
              </Text>
            </>
          ) : (
            <>
              <View style={styles.meterRow}>
                <Meter stars={can} />
                <View style={styles.parPill}>
                  <Text style={styles.parText}>{`PAR ${puzzle.par}`}</Text>
                </View>
              </View>
              {spec.clock ? (
                <View style={styles.clockRow}>
                  <Text style={[styles.clockText, phase === 'play' && secs <= 10 && { color: '#e01e4a' }]}>{clock(secs * 1000)}</Text>
                  <Bar frac={clk.frac} colors={['#b8ffd9', '#3ddc97']} />
                </View>
              ) : (
                <Text style={styles.tip} numberOfLines={2}>
                  {tipFor(spec, !!held, moves)}
                </Text>
              )}
            </>
          )}
        </View>
      </View>

      {/* the cushions: everything is placed by geometry() */}
      <View ref={areaRef} style={styles.area} onLayout={onArea} {...responder.panHandlers}>
        {g ? (
          <>
            <View pointerEvents="none" style={[styles.rug, { height: g.cushH * 1.9, borderRadius: g.w }]} />
            {dragCol >= 0 ? <View pointerEvents="none" style={[styles.colGlow, { left: g.colW * dragCol + 4, width: g.colW - 8 }]} /> : null}
            {Array.from({ length: spec.k }, (_, p) => (
              <Seat key={p} i={p} x={cx(g, p)} top={g.surface - g.cushH * 0.4} w={g.cushW} h={g.cushH} star={puzzle.star === p} bump={bumps[p]} glow={glowOf(p)} />
            ))}
            {order.map((r) => (
              <Piece key={r} c={who[r]} w={g.bw[r]} h={g.bh[r]} a={anims[r]} z={r === top ? 99 : zOf[r] || 10} />
            ))}
            <Banner banner={banner} top={4} />
            <FxLayer ref={fx} />
          </>
        ) : null}
        {count != null ? <Countdown value={count} /> : null}
      </View>

      {/* undo, restart, hint */}
      <View style={styles.controls}>
        <SdButton kind="white" onPress={() => acts.current.undo()} disabled={!playing || !canUndo} sound={null} faceStyle={styles.ctrlFace} style={styles.ctrl}>
          <BtnLabel kind="purple" size={15}>
            UNDO
          </BtnLabel>
        </SdButton>
        <SdButton kind="purple" onPress={() => acts.current.restart()} disabled={!playing || moves === 0} sound="sd_select" faceStyle={styles.ctrlFace} style={styles.ctrl}>
          <BtnLabel kind="purple" size={15}>
            RESTART
          </BtnLabel>
        </SdButton>
        {!blitz ? (
          <SdButton kind="gold" onPress={() => acts.current.askHint()} disabled={!playing || (hinted && !adsFree && !ad.ready)} sound="sd_select" faceStyle={styles.ctrlFace} style={styles.ctrl}>
            <BtnLabel kind="gold" size={15}>
              {adsFree ? 'HINT' : '▶ HINT'}
            </BtnLabel>
          </SdButton>
        ) : null}
      </View>

      {blitz ? (
        <>
          <BlitzPauseCard blitz visible={paused} onResume={() => acts.current.resume()} onRestart={() => acts.current.again()} onQuit={() => acts.current.leave()} />
          <ReviveCard visible={blitzCard === 'revive'} board={idx + 1} unit="puzzle" adReady={ad.ready} adsFree={adsFree} onRevive={() => acts.current.revive()} onGiveUp={() => acts.current.endRun('mistake')} />
          <BlitzFailCard visible={blitzCard === 'fail'} reason={failReason} reached={idx + 1} best={record(profile).blitz.reached} unit="puzzle" onAgain={() => acts.current.again()} onQuit={() => acts.current.leave()} />
          <BlitzWinCard visible={blitzCard === 'win'} res={blitzWin} uris={blitzWin?.uris || []} unit="puzzle" onAgain={() => acts.current.again()} onQuit={() => acts.current.leave()} />
        </>
      ) : (
        <>
          <ResultCard visible={!!result} res={result} spec={spec} last={lv >= LEVELS} onNext={next} onReplay={replay} onHub={() => acts.current.leave()} />
          <FailCard visible={fail} uri={who[0]?.uri} onRetry={replay} onHub={() => acts.current.leave()} />
          <PauseCard
            visible={paused}
            clock={spec.clock}
            onResume={() => acts.current.resume()}
            onRestart={() => {
              setPaused(false);
              replay();
            }}
            onQuit={() => acts.current.leave()}
          />
          <HintCard visible={hintAsk} adReady={ad.ready} adsFree={adsFree} onWatch={() => acts.current.watchHint()} onClose={() => setHintAsk(false)} />
        </>
      )}
      {phase === 'load' ? (
        <PopIn style={styles.loading}>
          <Text style={styles.loadingText}>Fluffing the cushions…</Text>
        </PopIn>
      ) : null}
    </View>
  );
}

const styles = StyleSheet.create({
  fill: { flex: 1 },
  hud: { flexDirection: 'row', alignItems: 'center', gap: 10, paddingHorizontal: 14, paddingTop: 6 },
  titleBox: { flex: 1, minWidth: 0 },
  gameName: { fontFamily: F.display, fontSize: 13, letterSpacing: 1, color: '#8e1580' },
  row6: { flexDirection: 'row', alignItems: 'center', gap: 6 },
  levelText: { fontFamily: F.display, fontSize: 21, color: '#ffffff', textShadowColor: INK, textShadowOffset: { width: 0, height: 2.5 }, textShadowRadius: 1, includeFontPadding: false },
  challenge: { paddingHorizontal: 7, paddingVertical: 1, borderRadius: 999, borderWidth: 2, borderColor: '#ffffff' },
  challengeText: { fontFamily: F.display, fontSize: 10, letterSpacing: 0.6, color: '#ffffff' },
  movesPill: { alignItems: 'center', minWidth: 64, paddingHorizontal: 10, paddingVertical: 3, borderRadius: 16, backgroundColor: 'rgba(80,12,140,0.42)', borderWidth: 2.5, borderColor: '#ffffff' },
  movesLabel: { fontFamily: F.display, fontSize: 10, letterSpacing: 1, color: '#ffffff' },
  movesNum: { fontFamily: F.display, fontSize: 22, color: '#ffe045', includeFontPadding: false, fontVariant: ['tabular-nums'] },
  info: { flexDirection: 'row', alignItems: 'stretch', gap: 10, paddingHorizontal: 14, marginTop: 8, minHeight: 72 },
  infoRight: { flex: 1, minWidth: 0, justifyContent: 'center', gap: 6 },
  meterRow: { flexDirection: 'row', alignItems: 'center', gap: 10 },
  meter: { flexDirection: 'row', alignItems: 'flex-start', gap: 1 },
  parPill: { paddingHorizontal: 10, paddingVertical: 2, borderRadius: 999, backgroundColor: '#ffffff', borderWidth: 2.5, borderColor: '#ffd23a' },
  parText: { fontFamily: F.display, fontSize: 13, color: '#b86200', letterSpacing: 0.6 },
  clockRow: { flexDirection: 'row', alignItems: 'center', gap: 8 },
  clockText: { minWidth: 40, fontFamily: F.display, fontSize: 14, color: INK, fontVariant: ['tabular-nums'] },
  tip: { fontFamily: F.heavy, fontSize: 12.5, lineHeight: 16, color: INK },
  blitzRule: { fontFamily: F.display, fontSize: 12.5, color: '#e01e4a' },
  pips: { marginTop: 8 },
  area: { flex: 1 },
  rug: { position: 'absolute', left: 0, right: 0, bottom: 0, backgroundColor: 'rgba(255,255,255,0.16)', borderWidth: 2, borderColor: 'rgba(255,255,255,0.4)', borderStyle: 'dashed' },
  colGlow: { position: 'absolute', top: 0, bottom: 0, borderRadius: 26, backgroundColor: 'rgba(255,255,255,0.16)' },
  seat: { position: 'absolute' },
  halo: { position: 'absolute', left: -10, right: -10, top: -9, bottom: -6 },
  badge: { position: 'absolute' },
  piece: { position: 'absolute', left: 0, top: 0 },
  controls: { flexDirection: 'row', justifyContent: 'center', gap: 8, paddingHorizontal: 12, paddingTop: 4, paddingBottom: 10 },
  ctrl: { flex: 1, maxWidth: 130 },
  ctrlFace: { paddingHorizontal: 6, paddingVertical: 10 },
  loading: { position: 'absolute', alignSelf: 'center', top: '45%' },
  loadingText: { fontFamily: F.display, fontSize: 16, color: INK },
});
