import { GameBack, useGameDims } from '../royal/GameFrame';
import React, { memo, useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { Animated, AppState, BackHandler, Easing, PanResponder, StyleSheet, Text, View } from 'react-native';
import useRewardedAd from '../components/useRewardedAd';
import sfx from '../audio/sfx';
import { FxLayer, PopIn } from '../squishdoku/fx';
import { makeHaptics, prefetchImages } from '../squishdoku/game';
import { Countdown } from '../squishdoku/BlitzGame';
import { BlitzOverCard, BlitzSaveCard, PauseCard, ResultCard } from '../squishdoku/Overlays';
import { trioOf } from '../squishdoku/Trio';
import { blitzSaveGems } from '../squishdoku/levels';
import * as squad from '../squad/api';
import { BtnLabel, Chip, SdButton } from '../squishdoku/ui';
import { F, INK } from '../squishdoku/theme';
import { saveStack } from '../firebase/firestore';
import { Banner } from '../sort/Game';
import { HintCard, RESULT_TITLES } from './Cards';
import { bestMove, canMove, makePuzzle, same, stackOf, topOf } from './engine';
import { LEVELS, TIER_COLORS, TIER_NAMES, afterBlitz, afterLevel, blitzSpec, levelSpec, record } from './levels';
import { Cushion, GoalCard, OVER, StarBadge, Squishy, bodyH } from './Pieces';
import { pickCast } from './roster';
import Svg, { Path } from 'react-native-svg';
import { PHASE, SWING, useKeyLoop, usePingPong } from '../components/idleLoop';

// One level of Squish Stack (SQUISH_STACK.md), and the next ones after it:
//   intro  the level's number and what's in it
//   deal   the squishies drop onto their cushions, one after another
//   play   tap a cushion to lift its top squishy (it hovers and wiggles),
//          tap another to put it there; or drag it. A big one dropped on a
//          smaller one squashes it flat and boings home (no move counted).
//          No clock (the user, 2026-11-16), and no UNDO: RESTART and HINT.
//   won
// The puzzle's rules are engine.js; this draws and animates them.
//
// BLITZ MODE (`blitz`, levels.js blitzSpec; 2026-11-16, the user: "the same
// thing" as Squishdoku's): after a 3, 2, 1, GO! puzzle after puzzle, with no
// end and no clock. A big one dropped on a smaller one is the mistake that
// stops the run ('held'). It can be saved, once with a rewarded ad (free with Remove Ads)
// or with gems, each save twice the last (functions/squad.js blitzSave), and
// the run goes on from the same puzzle; or it's GAME OVER and the puzzles
// cleared pay out (levels.js afterBlitz). No hints.

const LOAD_SOUNDS = ['st_lift', 'st_land', 'st_cushion', 'st_ouch', 'st_bounce', 'st_undo', 'st_hint', 'st_empty', 'st_news', 'sd_tick', 'sd_solve', 'sd_confetti', 'sd_boardIn', 'sd_timeUp'];

const GAP = 16; // between the tallest tower and a lifted squishy
const GRAVITY = Easing.bezier(0.55, 0, 1, 0.45);

// --- how the squishies move (2026-11-17, the user's list: SQUISH_STACK.md "Moves") -----------
// Every move is ONE native timing: a phase 0 → 1 read through keyframes (every list starts and ends at rest, so a
// phase can be left at 0 or 1), or a place reached along a path whose turns are worked into the timing's easing
// (`pathTiming`). A chained Animated.sequence, or a loop of one, is stepped from JS and hitches when JS is busy
// (src/components/idleLoop.js), so none is used.
const kf = (v, at, out) => v.interpolate({ inputRange: at, outputRange: out });
const sum = (...xs) => xs.reduce((p, q) => Animated.add(p, q));
const prod = (...xs) => xs.reduce((p, q) => Animated.multiply(p, q));
// eased progress that waits `d` of its time first (a move that starts a little after the timing does)
const after = (d, ease = (t) => t) => (t) => (t <= d ? 0 : ease((t - d) / (1 - d)));
// an easing that is a curve through [t, v] keyframes (v can leave 0 … 1 and come back: a wobble on a plain value)
const curve = (K) => (t) => {
  let i = 1;
  while (i < K.length - 1 && t > K[i][0]) i++;
  const [t0, a] = K[i - 1];
  const [t1, b] = K[i];
  return a + (b - a) * (t1 > t0 ? Math.min(1, Math.max(0, (t - t0) / (t1 - t0))) : 1);
};
// landing: squashed flat, a springy wobble back up (`ldA` how hard: a soft landing is about half)
const LAND = { at: [0, 0.1, 0.3, 0.5, 0.7, 1], x: [0, 0.26, -0.1, 0.06, -0.02, 0], y: [0, -0.28, 0.12, -0.05, 0.02, 0] };
const LAND_MS = 420;
// lifted: stretched up tall, then settling
const PICK = { at: [0, 0.25, 0.5, 0.75, 1], x: [1, 0.8, 1.08, 0.97, 1], y: [1, 1.26, 0.92, 1.03, 1] };
const PICK_MS = 360;
// the one under a lifted squishy, relieved of its weight: springs up a little (hop in its heights)
const RELIEF = { at: [0, 0.2, 0.45, 0.7, 0.85, 1], hop: [0, 0.04, -0.16, 0, -0.03, 0], x: [1, 1.08, 0.92, 1.04, 0.99, 1], y: [1, 0.9, 1.14, 0.96, 1.01, 1] };
const RELIEF_MS = 440;
// squashed by one landing on it: flat and bulging sideways, then springing back (`ripA` how hard: less further down)
const RIPPLE = { at: [0, 0.14, 0.36, 0.56, 0.76, 1], x: [0, 0.34, -0.1, 0.06, -0.02, 0], y: [0, -0.32, 0.1, -0.05, 0.02, 0] };
const RIPPLE_MS = 460;
const RIPPLE_STEP = 60; // ms from one squishy down to the next
// too big: the small one flattened like a pancake, held, then springing back
const PANCAKE = { at: [0, 0.06, 0.55, 0.7, 0.82, 0.92, 1], x: [1, 1.75, 1.66, 0.84, 1.1, 0.97, 1], y: [1, 0.3, 0.34, 1.22, 0.92, 1.03, 1] };
const PANCAKE_MS = 950;
// "nope": a shake of the head (degrees, from its feet)
const NOPE = { at: [0, 0.12, 0.3, 0.48, 0.66, 0.84, 1], v: [0, 13, -13, 10, -6, 3, 0] };
const NOPE_MS = 560;
// the win: a squash, a stretch up and a squash again (the wave runs up each tower); the hop is `waveH` of its
// height: small inside a tower (so it doesn't jump into the one on it), big for the one on top
const WAVE = { at: [0, 0.18, 0.32, 0.55, 0.75, 0.88, 1], hop: [0, 0, -0.26, -1, 0, -0.1, 0], x: [1, 1.18, 0.86, 0.96, 1.2, 0.97, 1], y: [1, 0.82, 1.18, 1.04, 0.8, 1.03, 1] };
const WAVE_MS = 620;
const WAVE_STEP = 85; // ms from one level of a tower up to the next
// the hint: two hops
const HINT = { at: [0, 0.23, 0.5, 0.73, 1], hop: [0, -0.28, 0, -0.28, 0] };
const HINT_MS = 760;
// stuck squishies (Blitz's mistake): drooped (sunk and wide), swaying slowly (a native loop)
const DROOP = { x: 1.07, y: 0.86 };
const SWAY_MS = 2000;
// lifted and hovering: a gentle dangle from its top (a native loop); dragged: a swing from how fast it's moved
const HOVER_MS = 1150;
const BUMP_EASE = curve([[0, 0], [0.16, 1], [0.4, -0.35], [0.6, 0.15], [0.8, -0.05], [1, 0]]);

// A squishy's animated values (see above), all at rest.
function pieceAnims() {
  const V = (v) => new Animated.Value(v);
  const a = { x: V(0), y: V(0), o: V(0), wx: V(1), wy: V(1), ld: V(1), ldA: V(1), pk: V(1), rel: V(1), rip: V(1), ripA: V(0), pan: V(1), no: V(1), wave: V(1), waveH: V(0.4), hint: V(1), droop: V(0), sway: V(0), hov: V(0), swing: V(0) };
  const dev = (ph, K, c, amp) => Animated.add(1, Animated.multiply(kf(ph, K.at, K[c]), amp));
  const axis = (c) => prod(dev(a.ld, LAND, c, a.ldA), kf(a.pk, PICK.at, PICK[c]), kf(a.rel, RELIEF.at, RELIEF[c]), dev(a.rip, RIPPLE, c, a.ripA), kf(a.pan, PANCAKE.at, PANCAKE[c]), kf(a.wave, WAVE.at, WAVE[c]), kf(a.droop, [0, 1], [1, DROOP[c]]));
  a.sx = axis('x');
  a.sy = axis('y');
  a.lift = sum(kf(a.rel, RELIEF.at, RELIEF.hop), Animated.multiply(kf(a.wave, WAVE.at, WAVE.hop), a.waveH), kf(a.hint, HINT.at, HINT.hop)); // of its height
  a.rotFeet = sum(kf(a.no, NOPE.at, NOPE.v), Animated.multiply(kf(a.sway, PHASE, SWING), 5)); // degrees
  a.rotTop = sum(a.swing, Animated.multiply(kf(a.hov, PHASE, SWING), 6)); // degrees
  Object.assign(a, { tgt: null, at: { x: 0, y: 0 }, w: -1, tok: 0, hovLoop: null, swayLoop: null, swingT: 0 });
  return a;
}

// One native timing taking `v` from `from` through `keys` ([[t 0…1, value, easing?], …], the last at t = 1) in `ms`:
// Animated works out a timing's frames from its easing once, in JS, so a path with turns in it is still one
// animation. (It runs from wherever `v` really is; `from` is where the path is drawn from.)
function pathTiming(v, from, keys, ms) {
  const pts = [[0, from], ...keys];
  const far = pts.reduce((m, q) => (Math.abs(q[1] - from) > Math.abs(m - from) ? q[1] : m), from);
  if (Math.abs(far - from) < 0.5) {
    const end = keys[keys.length - 1][1];
    return Math.abs(end - from) < 0.01 ? null : Animated.timing(v, { toValue: end, duration: ms, useNativeDriver: true });
  }
  const span = far - from;
  const easing = (t) => {
    let i = 1;
    while (i < pts.length - 1 && t > pts[i][0]) i++;
    const [t0, a] = pts[i - 1];
    const [t1, b, e] = pts[i];
    const u = t1 > t0 ? Math.min(1, Math.max(0, (t - t0) / (t1 - t0))) : 1;
    return (a + (b - a) * (e || Easing.inOut(Easing.quad))(u) - from) / span;
  };
  return Animated.timing(v, { toValue: far, duration: ms, easing, useNativeDriver: true });
}

const NEWS = {
  picture: { text: 'GOAL CARD!', sub: 'Make the cushions look like the picture' },
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
// feet), its own squash, stretch, hops and sways on top (from its feet), and
// dangling from its top while it's lifted. (The transforms are made once: a
// re-render must not build new animated nodes. PERFORMANCE.md.)
const Piece = memo(function Piece({ c, w, h, a, z }) {
  const t = useMemo(() => {
    const deg = (v) => v.interpolate({ inputRange: [-1, 1], outputRange: ['-1deg', '1deg'] });
    return {
      weight: [{ translateY: a.wy.interpolate({ inputRange: [0, 1], outputRange: [h / 2, 0] }) }, { scaleX: a.wx }, { scaleY: a.wy }],
      body: [{ translateY: h / 2 }, { translateY: Animated.multiply(a.lift, h) }, { rotate: deg(a.rotFeet) }, { scaleX: a.sx }, { scaleY: a.sy }, { translateY: -h / 2 }],
      dangle: [{ translateY: -h / 2 }, { rotate: deg(a.rotTop) }, { translateY: h / 2 }],
    };
  }, [a, h]);
  return (
    <Animated.View pointerEvents="none" style={[styles.piece, { width: w, height: h, zIndex: z, opacity: a.o, transform: [{ translateX: a.x }, { translateY: a.y }] }]}>
      <Animated.View style={{ transform: t.weight }}>
        <Animated.View style={{ transform: t.body }}>
          <Animated.View style={{ transform: t.dangle }}>
            <Squishy c={c} w={w} />
          </Animated.View>
        </Animated.View>
      </Animated.View>
    </Animated.View>
  );
});

// Dizzy stars circling over a squishy flattened by a big one (TOO BIG!): three
// stars on a tilted ring (one native loop), fading out at the end.
const STAR_D = 'M12 2 L14.6 8.6 L21.6 9.2 L16.3 13.8 L18 20.8 L12 17 L6 20.8 L7.7 13.8 L2.4 9.2 L9.4 8.6 Z';
const Dizzy = memo(function Dizzy({ x, y, w }) {
  const spin = useKeyLoop(760, { at: PHASE, values: PHASE });
  const life = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    Animated.timing(life, { toValue: 1, duration: 1250, easing: Easing.linear, useNativeDriver: true }).start();
  }, [life]);
  const size = Math.max(12, w * 0.2);
  const stars = useMemo(
    () =>
      [0, 1 / 3, 2 / 3].map((o) => {
        const ang = PHASE.map((p) => 2 * Math.PI * (p + o));
        return {
          tx: spin.interpolate({ inputRange: PHASE, outputRange: ang.map((q) => Math.cos(q) * w * 0.34) }),
          ty: spin.interpolate({ inputRange: PHASE, outputRange: ang.map((q) => Math.sin(q) * w * 0.1) }),
          k: spin.interpolate({ inputRange: PHASE, outputRange: ang.map((q) => 0.75 + 0.3 * Math.sin(q)) }),
        };
      }),
    [spin, w],
  );
  const opacity = life.interpolate({ inputRange: [0, 0.08, 0.8, 1], outputRange: [0, 1, 1, 0] });
  return (
    <Animated.View pointerEvents="none" style={[styles.dizzy, { left: x, top: y, opacity }]}>
      {stars.map((st, i) => (
        <Animated.View key={i} style={{ position: 'absolute', left: -size / 2, top: -size / 2, transform: [{ translateX: st.tx }, { translateY: st.ty }, { scale: st.k }] }}>
          <Svg width={size} height={size} viewBox="0 0 24 24">
            <Path d={STAR_D} fill="#ffe045" stroke="#b86200" strokeWidth={1.6} strokeLinejoin="round" />
          </Svg>
        </Animated.View>
      ))}
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

// a number in the counter: a small label over it
const Stat = memo(function Stat({ label, value, gold }) {
  return (
    <View style={styles.stat}>
      <Text style={[styles.statLabel, gold && styles.gold]}>{label}</Text>
      <Text style={[styles.statNum, gold && styles.gold]}>{value}</Text>
    </View>
  );
});

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
  const dims = useGameDims();
  const haptics = useRef(makeHaptics(hapticsOn)).current;
  const ad = useRewardedAd();
  const [lv, setLv] = useState(startLv);
  const [round, setRound] = useState(0);
  // Blitz: the run, its puzzle, the puzzles cleared, its saves, which of its
  // cards is up, and the countdown
  const [run, setRun] = useState(0);
  const [idx, setIdx] = useState(0);
  const idxRef = useRef(0);
  idxRef.current = idx;
  const [cleared, setCleared] = useState(0);
  const [blitzCard, setBlitzCard] = useState(null); // save | over
  const blitzCardRef = useRef(null);
  blitzCardRef.current = blitzCard;
  const [failReason, setFailReason] = useState('mistake');
  const [adUsed, setAdUsed] = useState(false);
  const [gemSaves, setGemSaves] = useState(0);
  const [saving, setSaving] = useState(false);
  const [saveErr, setSaveErr] = useState(null);
  const [over, setOver] = useState(null);
  const [count, setCount] = useState(null); // 3, 2, 1, 'GO!'
  const runStarted = useRef(false);
  // the run so far: the puzzles it cleared, and whether it's been paid out (payOut)
  const runRec = useRef({ cleared: 0, ended: false });
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
  // the result card's three: from the level's stack
  const trio = useMemo(() => trioOf(who.slice(0, 3).map((c) => c && c.key), (cast || []).map((c) => c.key)), [who, cast]);

  const [area, setArea] = useState(null);
  const areaRef = useRef(null);
  const origin = useRef({ x: 0, y: 0 });
  const onArea = useCallback((e) => {
    const { width, height } = e.nativeEvent.layout;
    if (width > 0 && height > 0) setArea((a) => (a && a.w === width && a.h === height ? a : { w: width, h: height }));
    areaRef.current?.measure((x, y, w, h, px, py) => (origin.current = { x: px, y: py }));
  }, []);
  const g = useMemo(() => (area && who.length === spec.n ? geometry(area.w, area.h, spec.n, spec.k, who) : null), [area, spec, who]);

  // each squishy's animated values (pieceAnims); tgt: where it's headed, at: where its last move takes it, w: the
  // weight it's squished to, tok: bumped by every new move (a stale landing does nothing)
  const anims = useMemo(() => who.map(pieceAnims), [who]);
  const bumps = useMemo(() => Array.from({ length: 4 }, () => new Animated.Value(0)), []);
  const flash = useRef(new Animated.Value(0)).current; // TOO BIG!'s red flash
  const [dizzy, setDizzy] = useState(null); // { key, x, y, w }: stars over a flattened squishy
  const fx = useRef(null);
  const fxTop = useRef(null); // Blitz: over the cards, a new best's confetti

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
  const [result, setResult] = useState(null);
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
  live.current = { g, anims, puzzle, spec, who, bumps };

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
      A.at = { x: s.x, y: s.y };
      A.tok += 1;
      Animated.parallel([
        Animated.spring(A.x, { toValue: s.x, friction: 7, tension: 120, useNativeDriver: true }),
        Animated.spring(A.y, { toValue: s.y, friction: 7, tension: 120, useNativeDriver: true }),
      ]).start();
    });
  }

  // steps: [{ x, y, ms, ex, ey }] one after another, as ONE timing per axis (pathTiming); `done` only if nothing
  // else moved it meanwhile
  function fly(r, steps, done) {
    const total = steps.reduce((m, st) => m + st.ms, 0);
    let t = 0;
    const kx = [];
    const ky = [];
    steps.forEach((st) => {
      t += st.ms;
      kx.push([t / total, st.x, st.ex]);
      ky.push([t / total, st.y, st.ey]);
    });
    flyKeys(r, kx, ky, total, done);
  }
  // the same with each axis's own keys ([[t, value, easing?], …]): an arc's x and y turn at different times
  function flyKeys(r, kx, ky, ms, done) {
    const A = live.current.anims[r];
    const tok = ++A.tok;
    const end = { x: kx[kx.length - 1][1], y: ky[ky.length - 1][1] };
    const from = A.at;
    A.tgt = end;
    A.at = end;
    Animated.parallel([pathTiming(A.x, from.x, kx, ms), pathTiming(A.y, from.y, ky, ms)].filter(Boolean)).start(({ finished }) => {
      if (finished && A.tok === tok && alive.current && done) done();
    });
  }
  // one go of a phase 0 → 1 (pieceAnims reads it through its keyframes), after `delay` ms (worked into the timing)
  function play(v, ms, delay = 0) {
    v.setValue(0);
    Animated.timing(v, { toValue: 1, duration: ms + delay, easing: after(delay / (ms + delay)), useNativeDriver: true }).start();
  }
  // a native loop of a phase (the hover dangle, the sad sway), or stopped and back at rest
  function loopOf(A, key, v, ms, on) {
    A[key]?.stop();
    A[key] = null;
    if (!on) {
      Animated.timing(v, { toValue: 0, duration: 160, useNativeDriver: true }).start();
      return;
    }
    v.setValue(0);
    A[key] = Animated.loop(Animated.timing(v, { toValue: 1, duration: ms, easing: Easing.linear, useNativeDriver: true }));
    A[key].start();
  }

  // lifted: a gentle dangle from its top while it hovers (off: back still, and any swing let go)
  function hover(r, on) {
    const A = live.current.anims[r];
    loopOf(A, 'hovLoop', A.hov, HOVER_MS, on);
    if (!on) Animated.spring(A.swing, { toValue: 0, friction: 2.6, tension: 70, useNativeDriver: true }).start();
  }
  // dragged: it swings from its top against the way it's moved, by how fast (a native spring: let go, it swings back
  // and forth like a pendulum and settles)
  function swing(r, vx) {
    const A = live.current.anims[r];
    const deg = Math.max(-30, Math.min(30, vx * 22));
    Animated.spring(A.swing, { toValue: deg, friction: 5, tension: 120, useNativeDriver: true }).start();
    clearTimeout(A.swingT);
    A.swingT = setTimeout(() => Animated.spring(A.swing, { toValue: 0, friction: 2.4, tension: 60, useNativeDriver: true }).start(), 90);
  }

  // a cushion's bump (k: how hard; negative springs it up), one timing whose easing wobbles back to 0
  function bump(p, k = 1) {
    const B = live.current.bumps[p];
    B.setValue(0);
    Animated.timing(B, { toValue: k, duration: 420, easing: BUMP_EASE, useNativeDriver: true }).start();
  }

  function pickUp(r, p) {
    const { anims: AS } = live.current;
    const A = AS[r];
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
    // stretched up tall as it's lifted
    play(A.pk, PICK_MS);
    // the one under it springs up, relieved of the weight (or, from the cushion, the cushion does)
    const st = stackOf(posRef.current, p);
    const under = st[st.indexOf(r) - 1];
    if (under != null) play(AS[under].rel, RELIEF_MS);
    else bump(p, -0.7);
    A.tgt = { x: xOf(r, p), y: hoverY(r) };
    const from = A.at;
    A.at = A.tgt;
    A.tok += 1;
    Animated.parallel([pathTiming(A.x, from.x, [[1, A.tgt.x, Easing.out(Easing.quad)]], 160), pathTiming(A.y, from.y, [[1, A.tgt.y, Easing.out(Easing.back(1.6))]], 220)].filter(Boolean)).start();
    hover(r, true);
    settle(); // the stack under it stands up a little
  }

  function land(r, soft = false) {
    if (heldRef.current && heldRef.current.r === r) return;
    const { g: G, anims: AS } = live.current;
    settle(); // the ones under it squish down a little
    const A = AS[r];
    A.ldA.setValue(soft ? 0.5 : 1);
    play(A.ld, LAND_MS);
    const p = posRef.current[r];
    const st = stackOf(posRef.current, p);
    const below = st.indexOf(r);
    if (below === 0) {
      bump(p, soft ? 0.6 : 1);
      sfx.play('st_cushion', { rate: rateOf(r) });
    } else sfx.play('st_land', { rate: rateOf(r) });
    if (soft) return;
    haptics.place();
    // the one under it squashes flat and bulges, and the squash runs down the tower, smaller at each level, to the
    // cushion; a puff of dust off the cushion
    for (let j = below - 1, k = 0; j >= 0; j--, k++) {
      const U = AS[st[j]];
      U.ripA.setValue(0.95 * Math.pow(0.62, k));
      play(U.rip, RIPPLE_MS, k * RIPPLE_STEP);
    }
    if (below > 0) later(below * RIPPLE_STEP, () => bump(p, Math.max(0.35, 0.8 * Math.pow(0.62, below))));
    later(below * RIPPLE_STEP, () => fx.current?.burst('puff', cx(G, p), G.surface - G.cushH * 0.1, Math.max(0.8, G.cushW / 110)));
    if (phaseRef.current === 'play' && same(posRef.current, live.current.puzzle.goal)) win();
  }

  // the lifted one let go over cushion p
  function drop(p, dragged = false) {
    const h = heldRef.current;
    if (!h) return;
    const G = live.current.g;
    const { r, from } = h;
    hover(r, false);
    setDragCol(-1);
    setHeld(null);
    if (p === from || p < 0) {
      const s = spotsOf(G, posRef.current)[r];
      fly(r, [{ x: s.x, y: s.y, ms: 170, ey: GRAVITY }], () => land(r, true));
      return;
    }
    if (canMove(posRef.current, from, p) < 0) {
      bounce(r, from, p, dragged);
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

  // Too big for cushion p: it lands on the small one's head and flattens it like a pancake (dizzy stars, a quick red
  // flash), boings off, shakes its head "nope" and arcs back home. No move counted.
  function bounce(r, from, p, dragged = false) {
    const { g: G, anims: AS, spec: S } = live.current;
    const t = topOf(posRef.current, p);
    const ts = spotsOf(G, posRef.current)[t];
    const sit = ts.y + G.bh[t] * 0.66 - G.bh[r]; // on the flattened one (PANCAKE leaves it a third as tall)
    const dx = Math.abs(cx(G, p) - cx(G, from));
    setTop(r);
    // (let go from a drag: straight down from where it was dropped; from a tap: over from its hover, then down)
    const there = dragged ? [{ x: xOf(r, p), y: sit, ms: 190, ex: Easing.out(Easing.quad), ey: GRAVITY }] : [{ x: xOf(r, p), y: hoverY(r), ms: 110 + dx * 0.45 }, { x: xOf(r, p), y: sit, ms: 140, ey: GRAVITY }];
    fly(r, there, () => {
      const T = AS[t];
      const A = AS[r];
      play(T.pan, PANCAKE_MS);
      setDizzy({ key: Date.now(), x: cx(G, p), y: ts.y + G.bh[t] * 0.62, w: G.bw[t] });
      later(1300, () => setDizzy(null));
      flash.setValue(0);
      Animated.timing(flash, { toValue: 1, duration: 340, easing: Easing.linear, useNativeDriver: true }).start();
      sfx.play('st_ouch');
      haptics.wrong();
      fx.current?.burst('angry', cx(G, p), ts.y + G.bh[t] * 0.6, 1);
      say('TOO BIG!', { small: true, ink: '#8e1030', hold: 380, sub: S.lv <= 3 ? 'Big ones never sit on smaller ones' : null });
      if (blitz) blitzMistake();
      // the big one: squashed on landing, then boing, up and away in an arc, shaking its head, and home
      A.ldA.setValue(1);
      play(A.ld, LAND_MS);
      const tok = A.tok;
      later(200, () => {
        if (A.tok !== tok || (heldRef.current && heldRef.current.r === r)) return;
        sfx.play('st_bounce');
        play(A.pk, PICK_MS);
        play(A.no, NOPE_MS, 60);
        const home = spotsOf(G, posRef.current)[r];
        // (not so high that it leaves the play area for the counter over it)
        const peak = Math.max(-G.bh[r] * 0.05, Math.min(sit, hoverY(r)) - G.bh[r] * 0.22);
        const ms = 520 + dx * 0.4;
        flyKeys(r, [[0.15, xOf(r, p)], [1, home.x, Easing.inOut(Easing.sin)]], [[0.45, peak, Easing.out(Easing.quad)], [1, home.y, GRAVITY]], ms, () => land(r, true));
      });
    });
  }

  // Blitz's mistake: everyone droops and sways sadly (until the run's saved, or a new one)
  function sad(on) {
    live.current.anims.forEach((A, r) => {
      Animated.timing(A.droop, { toValue: on ? 1 : 0, duration: on ? 520 : 200, easing: Easing.out(Easing.quad), useNativeDriver: true }).start();
      if (on) later(r * 120, () => loopOf(A, 'swayLoop', A.sway, SWAY_MS, true));
      else loopOf(A, 'swayLoop', A.sway, SWAY_MS, false);
    });
  }

  // Blitz: a mistake stops the run; then the save card
  function blitzMistake() {
    setPhase('held');
    setGlow(null);
    if (heldRef.current) drop(heldRef.current.from);
    // everyone droops and sways sadly, and the save card comes once that's shown (1.5 s: it covers the cushions)
    later(280, () => sad(true));
    later(1500, () => offerSave('mistake'));
  }

  // Blitz: a mistake — save the run, or END RUN for GAME OVER
  function offerSave(reason) {
    setFailReason(reason);
    setSaveErr(null);
    setBlitzCard('save');
  }

  // The run goes on from the same puzzle.
  function goOn() {
    setSaving(false);
    setBlitzCard(null);
    sfx.play('sd_revive');
    sad(false);
    setPhase('play');
  }
  function saveByAd() {
    const back = () => {
      setAdUsed(true);
      acts.current.goOn();
    };
    if (adsFree) back();
    else ad.show(back);
  }
  function saveByGems() {
    if (saving) return;
    setSaving(true);
    setSaveErr(null);
    squad
      .blitzSave(gemSaves)
      .then(() => {
        setGemSaves((n) => n + 1);
        acts.current.goOn();
      })
      .catch((e) => {
        setSaving(false);
        setSaveErr(String((e && e.message) || e) === 'not_enough_gems' ? 'Not enough gems' : "Couldn't reach the server. Try again?");
      });
  }

  // Pays the run out once (the puzzles it cleared) and saves the record. Also
  // when the player quits or starts over in the middle of a run, so cleared
  // puzzles always count.
  function payOut() {
    const R = runRec.current;
    if (!blitz || !runStarted.current || R.ended) return null;
    R.ended = true;
    const out = afterBlitz(profileRef.current, { cleared: R.cleared });
    if (uid) saveStack(uid, out.update, out.coins, out.xp, profileRef.current);
    return out;
  }

  // Blitz: GAME OVER — the puzzles cleared, the best, and what they paid
  function endRun() {
    setPhase('lost');
    setGlow(null);
    if (heldRef.current) drop(heldRef.current.from);
    const top = record(profileRef.current).blitz.top;
    const out = payOut() || { coins: 0, xp: 0, levelUps: [], newTop: false };
    const res = { ...out, cleared: runRec.current.cleared, best: Math.max(top, runRec.current.cleared) };
    setOver(res);
    setBlitzCard('over');
    if (res.newTop) {
      sfx.play('sd_blitzWin');
      haptics.win();
      [0, 300, 600].forEach((d, i) => later(d, () => fxTop.current?.burst('confetti', dims.width * (0.25 + 0.25 * i), dims.height * 0.3, 1)));
    } else {
      sfx.play('sd_blitzFail');
      haptics.wrong();
      later(600, () => sfx.play('sd_drain'));
    }
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

  // everyone back where this puzzle started
  function restart() {
    if (phaseRef.current !== 'play' || pausedRef.current) return;
    if (heldRef.current) {
      hover(heldRef.current.r, false);
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
    play(AS[r].hint, HINT_MS);
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
      later(250, () => acts.current.showHint());
    });
  }

  function win() {
    setPhase('won');
    setGlow(null);
    const { g: G, anims: AS, puzzle: P, spec: S } = live.current;
    sfx.play('sd_solve');
    haptics.win();
    // a bounce wave up each tower, bottom to top, a sparkle off each one as it jumps (over before the result card)
    const m = spotsOf(G, posRef.current);
    for (let p = 0; p < S.k; p++) {
      const st = stackOf(posRef.current, p);
      st.forEach((r, j) => {
        const d = 120 + j * WAVE_STEP + p * 45;
        AS[r].waveH.setValue(j === st.length - 1 ? 0.42 : 0.1);
        play(AS[r].wave, WAVE_MS, d);
        later(d + WAVE_MS * 0.45, () => fx.current?.burst('spark', cx(G, p), m[r].y + G.bh[r] * 0.1, Math.max(0.7, G.bw[r] / 90)));
      });
    }
    // (Blitz keeps its confetti for a new best at GAME OVER)
    if (!blitz) {
      later(250, () => {
        sfx.play('sd_confetti');
        fx.current?.burst('confetti', G.w / 2, G.h * 0.35, 1.2);
      });
      later(650, () => fx.current?.burst('confetti', G.w * 0.25, G.h * 0.5, 1));
      later(800, () => fx.current?.burst('confetti', G.w * 0.75, G.h * 0.5, 1));
    }
    if (blitz) {
      // one more cleared; on to the next puzzle
      const i = idxRef.current;
      runRec.current.cleared = i + 1;
      later(300, () => {
        setCleared(i + 1);
        sfx.play('sd_pip', { rate: 0.9 + Math.min(12, i) * 0.05 });
      });
      later(1300, () => {
        sfx.play('sd_blitzNext');
        setIdx(i + 1);
      });
      return;
    }
    const out = afterLevel(profileRef.current, S, P.par, { won: true, moves: movesRef.current, hinted: hintedRef.current });
    if (uid) saveStack(uid, out.update, out.coins, out.xp, profileRef.current);
    const { stars, coins, xp, before, after, levelUps, unlocked } = out;
    const res = { stars, coins, xp, before, after, levelUps, unlocked, moves: movesRef.current, par: P.par, hinted: hintedRef.current };
    later(1500, () => setResult(res));
  }

  // --- the round -----------------------------------------------------------------------

  function startPlay() {
    setPhase('play');
    if (blitz) runStarted.current = true;
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
    setResult(null);
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
    // everyone above their spot, waiting to drop in (their spots are already
    // their targets, so nothing settles them there early)
    const m = spotsOf(g, puzzle.start);
    anims.forEach((A, r) => {
      A.hovLoop?.stop();
      A.swayLoop?.stop();
      A.hovLoop = null;
      A.swayLoop = null;
      clearTimeout(A.swingT);
      A.tok += 1;
      [A.ld, A.pk, A.rel, A.rip, A.pan, A.no, A.wave, A.hint].forEach((v) => {
        v.stopAnimation();
        v.setValue(1);
      });
      [A.droop, A.sway, A.hov, A.swing, A.o].forEach((v) => {
        v.stopAnimation();
        v.setValue(0);
      });
      A.wx.setValue(m[r].sx);
      A.wy.setValue(m[r].sy);
      A.w = m[r].sy;
      A.x.setValue(m[r].x);
      A.y.setValue(m[r].y - g.h * 0.6);
      A.at = { x: m[r].x, y: m[r].y - g.h * 0.6 };
      A.tgt = { x: m[r].x, y: m[r].y };
    });
    setDizzy(null);
    setPhase('intro');
    // a Blitz run opens with 3, 2, 1, GO! (the first puzzle drops in on GO)
    const countdown = blitz && !runStarted.current;
    if (!countdown) {
      const chips = [TIER_NAMES[spec.tier]];
      if (spec.goal === 'picture') chips.push('GOAL CARD');
      if (spec.k === 4) chips.push('4 CUSHIONS');
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

  // --- pause and leaving ---------------------------------------------------------------

  function pause() {
    if (phaseRef.current !== 'play' || pausedRef.current) return;
    if (heldRef.current) drop(heldRef.current.from);
    setPaused(true);
  }
  function resume() {
    setPaused(false);
  }
  function leave() {
    payOut();
    clearTimers();
    onExit();
  }
  const next = useCallback(() => {
    setLv((l) => Math.min(LEVELS, l + 1));
    setRound((r) => r + 1);
  }, []);
  const replay = useCallback(() => setRound((r) => r + 1), []);
  // Blitz: a fresh run from puzzle 1 (the one before is paid out first)
  function again() {
    payOut();
    clearTimers();
    runStarted.current = false;
    runRec.current = { cleared: 0, ended: false };
    setBlitzCard(null);
    setOver(null);
    setAdUsed(false);
    setGemSaves(0);
    setSaving(false);
    setSaveErr(null);
    setCleared(0);
    setCount(null);
    setPaused(false);
    setIdx(0);
    setRun((r) => r + 1);
  }

  const acts = useRef({});
  acts.current = { swing, hoverOff: (r) => loopOf(live.current.anims[r], 'hovLoop', live.current.anims[r].hov, HOVER_MS, false), pickUp, drop, undo, restart, askHint, watchHint, showHint, pause, resume, leave, replay, again, goOn, saveByAd, saveByGems, endRun };
  // web, development only: the browser tests move squishies without finding the cushions on screen (src/web/README.md)
  if (__DEV__ && typeof window !== 'undefined' && window.document) {
    window.__stack = {
      best: () => bestMove(live.current.puzzle.sol, posRef.current),
      move: (from, to) => {
        const r = topOf(posRef.current, from);
        if (r < 0 || phaseRef.current !== 'play') return false;
        acts.current.pickUp(r, from);
        setTimeout(() => acts.current.drop(to), 60);
        return true;
      },
      // lift the top one off cushion `from` (it hovers), and let it go over cushion `to`
      pick: (from) => {
        const r = topOf(posRef.current, from);
        if (r < 0 || phaseRef.current !== 'play' || heldRef.current) return false;
        acts.current.pickUp(r, from);
        return true;
      },
      drop: (to) => acts.current.drop(to),
      state: () => ({ phase: phaseRef.current, pos: posRef.current.slice(), k: live.current.spec.k }),
    };
  }

  useEffect(() => {
    const sub = BackHandler.addEventListener('hardwareBackPress', () => {
      const A = acts.current;
      if (hintAskRef.current) setHintAsk(false);
      else if (pausedRef.current) A.resume();
      else if (phaseRef.current === 'play') A.pause();
      else if (blitzCardRef.current === 'save') A.endRun();
      else if (phaseRef.current === 'held') return true;
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
          const nx = Math.max(0, Math.min(G.w - bw, x - bw / 2));
          const ny = Math.max(-bh * 0.3, Math.min(G.surface - bh, y - bh * 0.85));
          A.x.setValue(nx);
          A.y.setValue(ny);
          // the swing: from how fast it's moved sideways (px a ms), every few frames
          const now = Date.now();
          if (T.lt == null) {
            T.lt = now;
            T.lx = nx;
            acts.current.hoverOff(h.r);
          } else if (now - T.lt >= 40) {
            acts.current.swing(h.r, (nx - T.lx) / (now - T.lt));
            T.lt = now;
            T.lx = nx;
          }
          A.at = { x: nx, y: ny };
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
  const nudge = spec.lv === 1 && moves === 0 && phase === 'play' ? (held ? puzzle.star : 0) : -1;
  const glowOf = (p) => (glow ? (p === glow.to ? 'gold' : p === glow.from ? 'white' : null) : p === nudge ? 'white' : null);
  const playing = phase === 'play' && !paused;
  // Blitz: the best run so far, and whether this one has beaten it
  const bestRun = record(profile).blitz.top;
  const beat = blitz && cleared > bestRun && bestRun > 0;

  // The counter (the user, 2026-11-16: "my attempt / attempts for 3 stars", no stars, no level, no game name, no
  // clock): the moves so far over the par, red once past it, and the level's tier. Blitz: the puzzles cleared and the
  // best run, and its one rule.
  const pastPar = moves > puzzle.par;
  const counterEl = (
    <View style={styles.counter}>
      {blitz ? (
        <>
          <Stat label="CLEARED" value={cleared} />
          <Stat label={beat ? 'NEW BEST' : 'BEST'} value={Math.max(bestRun, cleared)} gold={beat} />
        </>
      ) : (
        <View style={styles.stat}>
          <Text style={styles.statLabel}>MOVES</Text>
          <Text style={styles.countLine}>
            <Text style={[styles.countNum, pastPar && styles.countOver]}>{moves}</Text>
            <Text style={styles.countPar}>{` / ${puzzle.par}`}</Text>
          </Text>
        </View>
      )}
      <View style={[styles.challenge, { backgroundColor: TIER_COLORS[spec.tier] }]}>
        <Text style={styles.challengeText}>{TIER_NAMES[spec.tier]}</Text>
      </View>
      {blitz ? (
        <Chip bg="#e01e4a" color="#ffffff">
          1 MISTAKE = GAME OVER
        </Chip>
      ) : null}
    </View>
  );
  const backEl = <GameBack onPress={() => (phaseRef.current === 'play' ? acts.current.pause() : acts.current.leave())} />;
  const goalEl = <GoalCard who={who} goal={puzzle.goal} k={spec.k} star={puzzle.star} />;
  const areaEl = (
    <>
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
            {dizzy ? <Dizzy key={dizzy.key} x={dizzy.x} y={dizzy.y} w={dizzy.w} /> : null}
            {/* TOO BIG!'s quick red flash */}
            <Animated.View pointerEvents="none" style={[styles.flash, { opacity: flash.interpolate({ inputRange: [0, 0.18, 1], outputRange: [0, 0.32, 0] }) }]} />
            <Banner banner={banner} top={4} />
            <FxLayer ref={fx} />
          </>
        ) : null}
        {count != null ? <Countdown value={count} /> : null}
      </View>
    </>
  );
  // restart and hint (no UNDO: the user, 2026-11-16), side by side at the bottom right
  const ctrlEl = (
    <View style={styles.controls}>
      <SdButton kind="purple" onPress={() => acts.current.restart()} disabled={!playing || moves === 0} sound="sd_select" faceStyle={styles.ctrlFace}>
        <BtnLabel kind="purple" size={14}>
          RESTART
        </BtnLabel>
      </SdButton>
      {!blitz ? (
        <SdButton kind="gold" onPress={() => acts.current.askHint()} disabled={!playing || (hinted && !adsFree && !ad.ready)} sound="sd_select" faceStyle={styles.ctrlFace}>
          <BtnLabel kind="gold" size={14}>
            {adsFree ? 'HINT' : '▶ HINT'}
          </BtnLabel>
        </SdButton>
      ) : null}
    </View>
  );
  return (
    <View style={styles.fill}>
      {/* (the user, 2026-11-16) the back button top left and the goal bottom left; the counter at the top in the
          middle, the cushions under it; RESTART and HINT side by side at the bottom right. The two side columns are as
          wide as each other, so the cushions sit in the middle of the screen. */}
      <View style={styles.row}>
        <View style={styles.side}>
          {backEl}
          <View style={styles.fill} />
          {goalEl}
        </View>
        <View style={styles.fill}>
          <View style={styles.counterRow}>{counterEl}</View>
          {areaEl}
        </View>
        <View style={[styles.side, styles.sideR]}>{ctrlEl}</View>
      </View>

      {blitz ? (
        <>
          <PauseCard visible={paused} onResume={() => acts.current.resume()} onQuit={() => acts.current.leave()} />
          <BlitzSaveCard
            visible={blitzCard === 'save'}
            unit="puzzle"
            reason={failReason}
            board={idx + 1}
            cleared={cleared}
            adUsed={adUsed}
            adReady={ad.ready}
            adsFree={adsFree}
            gems={Number(profile && profile.gems) || 0}
            price={blitzSaveGems(gemSaves)}
            saving={saving}
            error={saveErr}
            onAd={() => acts.current.saveByAd()}
            onGems={() => acts.current.saveByGems()}
            onEnd={() => acts.current.endRun()}
          />
          <BlitzOverCard visible={blitzCard === 'over'} unit="puzzle" res={over} onAgain={() => acts.current.again()} onQuit={() => acts.current.leave()} />
          <FxLayer ref={fxTop} style={styles.fxTop} />
        </>
      ) : (
        <>
          <ResultCard visible={!!result} res={result} titles={RESULT_TITLES} keys={trio} last={lv >= LEVELS} onNext={next} onReplay={replay} onBack={() => acts.current.leave()} />
          <PauseCard visible={paused} onResume={() => acts.current.resume()} onQuit={() => acts.current.leave()} />
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
  challenge: { paddingHorizontal: 7, paddingVertical: 1, borderRadius: 999, borderWidth: 2, borderColor: '#ffffff' },
  challengeText: { fontFamily: F.display, fontSize: 10, letterSpacing: 0.6, color: '#ffffff' },
  gold: { color: '#ffd23a' },
  // the cards sit at elevation 50 (squishdoku/Overlays.js)
  fxTop: { zIndex: 60, elevation: 60 },
  area: { flex: 1 },
  row: { flex: 1, flexDirection: 'row' },
  // the counter: MOVES n / par, the tier; Blitz: cleared, best, the rule
  counter: { flexDirection: 'row', alignItems: 'center', gap: 12, paddingHorizontal: 12, paddingVertical: 3, borderRadius: 16, backgroundColor: 'rgba(91,58,41,0.75)', borderWidth: 2, borderColor: 'rgba(255,255,255,0.9)' },
  stat: { alignItems: 'center', minWidth: 44 },
  statLabel: { fontFamily: F.display, fontSize: 9.5, letterSpacing: 1, color: '#ffe6c2', includeFontPadding: false },
  statNum: { fontFamily: F.display, fontSize: 21, color: '#ffe045', includeFontPadding: false, fontVariant: ['tabular-nums'] },
  countLine: { includeFontPadding: false },
  countNum: { fontFamily: F.display, fontSize: 22, color: '#ffe045', fontVariant: ['tabular-nums'] },
  countOver: { color: '#ff8fa3' },
  countPar: { fontFamily: F.display, fontSize: 16, color: '#ffe6c2', fontVariant: ['tabular-nums'] },
  // two side columns of the same width, the counter and the cushions between them
  side: { width: 200, paddingHorizontal: 12, paddingTop: 6, paddingBottom: 10, alignItems: 'flex-start' },
  sideR: { alignItems: 'flex-end', justifyContent: 'flex-end' },
  counterRow: { alignItems: 'center', paddingTop: 6 },
  // (no dashed outline: the user, 2026-11-16)
  rug: { position: 'absolute', left: 0, right: 0, bottom: 0, backgroundColor: 'rgba(255,255,255,0.16)' },
  colGlow: { position: 'absolute', top: 0, bottom: 0, borderRadius: 26, backgroundColor: 'rgba(255,255,255,0.16)' },
  seat: { position: 'absolute' },
  halo: { position: 'absolute', left: -10, right: -10, top: -9, bottom: -6 },
  badge: { position: 'absolute' },
  piece: { position: 'absolute', left: 0, top: 0 },
  dizzy: { position: 'absolute', zIndex: 120 },
  flash: { ...StyleSheet.absoluteFillObject, zIndex: 110, backgroundColor: '#ff2d55', borderRadius: 24 },
  // RESTART and HINT, side by side
  controls: { flexDirection: 'row', justifyContent: 'center', alignItems: 'flex-end', gap: 8 },
  ctrlFace: { paddingHorizontal: 10, paddingVertical: 10 },
  loading: { position: 'absolute', alignSelf: 'center', top: '45%' },
  loadingText: { fontFamily: F.display, fontSize: 16, color: INK },
});
