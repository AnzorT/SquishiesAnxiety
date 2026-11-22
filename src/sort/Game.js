import React, { memo, useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { Animated, AppState, BackHandler, Easing, Image, PanResponder, StyleSheet, Text, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Defs, Ellipse, Path, RadialGradient, Stop } from 'react-native-svg';
import { CribButton, RoomTitle } from '../crib/Hud';
import Room from '../hop/Room';
import ShadowText, { outline3 } from '../components/candy/ShadowText';
import useRewardedAd from '../components/useRewardedAd';
import { Heart } from '../components/Hearts';
import sfx from '../audio/sfx';
import { FxLayer, PopIn } from '../squishdoku/fx';
import { makeHaptics, prefetchImages, useClock } from '../squishdoku/game';
import { TimerBar } from '../squishdoku/Hud';
import { BlitzOverCard, BlitzSaveCard, PauseCard, ResultCard } from '../squishdoku/Overlays';
import { Countdown } from '../squishdoku/BlitzGame';
import { blitzSaveGems } from '../squishdoku/levels';
import * as squad from '../squad/api';
import { trioOf } from '../squishdoku/Trio';
import { Chip } from '../squishdoku/ui';
import { saveSort } from '../firebase/firestore';
import Container, { SHELF, geometry, slotAt, slotCenter } from './Container';
import { FailCard, RESULT_TITLES } from './Cards';
import { drop as dropRule, makeBoard, solved, startState } from './board';
import { HEARTS, LEVELS, TIER_COLORS, TIER_NAMES, afterBlitz, afterLevel, blitzSpec, clock, levelSpec, record } from './levels';
import { modelOf } from './models';
import { KINDS, Prop } from './props';
import { THEMES } from './themes';
import { F, INK } from '../squishdoku/theme';
import { PHASE, SWING, useKeyLoop, usePingPong } from '../components/idleLoop';
import RigStage from '../hop/RigStage';
import { BY_ID } from '../squad/data';

// One level of Squish Sort (SQUISH_SORT.md), and the next ones after it:
//   intro   the level's number and its twists
//   deal    the squishies pop onto the shelves, doors open
//   peek    REMEMBER! (the level's peek time; sneaky swaps near its end)
//   close   the doors swing shut
//   shake   it rattles and jumps twice
//   open    the doors fly open, the lamp flickers on
//   tumble  everyone falls out into the tray (the mixed-up ones stay inside,
//           in the wrong spots)
//   place   drag each one home, or tap it and then its spot; the clock runs
//   won / lost
// The board's rules are board.js; this draws and animates them. The
// squishies are the catalog's rig stills (`pool`: [{ id, uri }]).
//
// BLITZ MODE (`SortBlitz`, levels.js blitzSpec; 2026-11-17, the user: "its
// unlimited and it should behave like the others, 1 fail means you failed it
// all"), as Squishdoku's, Squish Stack's and Squish Hop's: after a 3, 2, 1,
// GO! round after round with no end, each on its own clock that runs only in
// `place`. A mistake or the clock running out stops the run (`held`). It can
// be saved, once with a rewarded ad (free with Remove Ads) or with gems, each
// save twice the last (functions/squad.js blitzSave), and the round goes on
// (after the clock ran out, with its clock started again); or it's GAME OVER
// and the rounds cleared pay out (levels.js afterBlitz). The first Blitz
// (ten rounds on one clock, one revive, its own fail and win cards) is gone.
//
// The squishies in play are the design's live 2.5D rigs (SQUISH_SORT.md,
// "Character animations"): one page (tools/rig/sort.html through
// hop/RigStage.js) draws them all over the play area, and this tells it what
// happens. Picked up, they stretch and wiggle; in the right spot they squash in
// and hop for joy; in a wrong one they shake their heads and bounce back to
// the tray sweating; an impostor found out jumps guiltily and spins away; the
// win is a bounce wave as the doors shut; a loss, everyone droops. The stills
// (the rigs at rest) do the same in a simpler way, until the page has drawn
// the deal's rigs (it loads them through the peek) or if a rig won't load.
// While the rigs draw, the stills only show the chosen ring (under the page)
// and the ? and ✓ marks (over it).

// the rig page's calls (tools/rig/sort.html `sortStage`)
const RIG_CALLS = ['cast', 'place', 'hideAll', 'tumble', 'hold', 'drag', 'go', 'correct', 'wrong', 'caught', 'huh', 'win', 'unshut', 'lose'];
const keyOf = (id) => (BY_ID[String(id)] ? BY_ID[String(id)].key : null);
// the win: the bounce wave starts, and the doors swing shut over it
const SHUT_AT = 350;
const SHUT_MS = 650;

const BLITZ_SOUNDS = ['sd_count', 'sd_go', 'sd_pip', 'sd_blitzNext', 'sd_blitzFail', 'sd_blitzWin', 'sd_drain', 'sd_revive', 'sd_timeUp'];
const LOAD_SOUNDS = ['fs_pop', 'fs_peek', 'fs_doorClose', 'fs_doorOpen', 'fs_rattle', 'fs_jump', 'fs_land', 'fs_tumble', 'fs_pick', 'fs_drop', 'fs_snap', 'fs_wrong', 'fs_impostor', 'fs_swap', 'fs_heart', 'fs_mixed', 'sd_tick', 'sd_solve', 'sd_confetti', 'sd_boardIn'];

// the tray (REDESIGN_V8, the games sideways): a column at the right of the play area, one or two spots across, and
// the fridge gets the area's whole height beside it
function trayGeo(w, h, cap) {
  const perRow = cap > 4 ? 2 : 1;
  const rows = Math.ceil(cap / perRow);
  const cell = Math.floor(Math.min(58, (h - 44) / rows));
  const tw = perRow * cell + 24;
  const th = rows * cell + 26;
  return { cell, perRow, rows, tw, th, tx: w - tw - 10, ty: Math.round((h - th) / 2) };
}
const trayCenter = (tg, j) => ({ x: tg.tx + 12 + (j % tg.perRow) * tg.cell + tg.cell / 2, y: tg.ty + 15 + Math.floor(j / tg.perRow) * tg.cell + tg.cell / 2 });

// --- a squishy -----------------------------------------------------------------------

// a mixed-up squishy's wobble: right, left, back (650 ms), then a rest
// (900 ms), as one native loop (src/components/idleLoop.js)
const WOB_AT = [0, 0.084, 0.168, 0.252, 0.335, 0.377, 0.419, 1];
const WOB_VALUES = [0, 0.71, 1, 0, -1, -0.5, 0, 0];

// A squishy's still and its marks. `part`: 'all' the still with everything;
// with the rigs drawing it, 'under' only its chosen ring (under the rig page)
// and 'over' only its ? and ✓ (over it). The still's own moves: `a.sq`
// squashed (1) … stretched (-1) and `a.tilt` (degrees), both about its feet,
// `a.spin` (degrees, about its middle), `a.sweat` a drop running down (0 → 1);
// `held` wiggles it, `sad` sways it slowly.
const Piece = memo(function Piece({ uri, size, a, mixed, selected, locked, held, sad, part = 'all' }) {
  const still = part === 'all';
  const wob = useKeyLoop(1550, { at: WOB_AT, values: WOB_VALUES, on: mixed && still });
  const pulse = usePingPong(840, { on: selected && part !== 'over' });
  const wig = useKeyLoop(330, { at: PHASE, values: SWING, on: !!held && still });
  const sway = useKeyLoop(2600, { at: PHASE, values: SWING, on: !!sad && still });
  const tilt = Animated.add(Animated.add(Animated.multiply(wob, 9), Animated.multiply(wig, 7)), Animated.add(Animated.multiply(sway, 3), a.tilt));
  const rotate = tilt.interpolate({ inputRange: [-360, 360], outputRange: ['-360deg', '360deg'] });
  const lift = Animated.add(a.lift, pulse.interpolate({ inputRange: [0, 1], outputRange: [0, 0.35] }));
  return (
    <Animated.View
      pointerEvents="none"
      style={[
        styles.piece,
        {
          width: size,
          height: size,
          opacity: a.o,
          transform: [
            { translateX: a.x },
            { translateY: a.y },
            { translateX: a.shake },
            { translateY: a.hop },
            { translateY: lift.interpolate({ inputRange: [0, 1.35], outputRange: [0, -11] }) },
            { scale: a.s },
            { scale: lift.interpolate({ inputRange: [0, 1.35], outputRange: [1, 1.16] }) },
            // squashed, stretched and tilted about its feet
            { translateY: size / 2 },
            { rotate },
            { scaleX: a.sq.interpolate({ inputRange: [-1, 0, 1], outputRange: [0.84, 1, 1.22] }) },
            { scaleY: a.sq.interpolate({ inputRange: [-1, 0, 1], outputRange: [1.2, 1, 0.78] }) },
            { translateY: -size / 2 },
            { rotate: a.spin.interpolate({ inputRange: [-3600, 3600], outputRange: ['-3600deg', '3600deg'] }) },
          ],
        },
      ]}
    >
      {/* a soft floor shadow, smaller while lifted */}
      {still ? (
        <Animated.View style={[styles.pieceShadow, { opacity: lift.interpolate({ inputRange: [0, 1.35], outputRange: [1, 0.5] }), transform: [{ scaleX: lift.interpolate({ inputRange: [0, 1.35], outputRange: [1, 0.7] }) }] }]}>
          <Svg width="100%" height="100%">
            <Defs>
              <RadialGradient id="pieceFloor" cx="50%" cy="50%" r="50%">
                <Stop offset="0" stopColor="#45107a" stopOpacity={0.28} />
                <Stop offset="1" stopColor="#45107a" stopOpacity={0} />
              </RadialGradient>
            </Defs>
            <Ellipse cx="50%" cy="50%" rx="50%" ry="50%" fill="url(#pieceFloor)" />
          </Svg>
        </Animated.View>
      ) : null}
      {selected && part !== 'over' ? <View style={styles.selRing} /> : null}
      {still ? <Image source={{ uri }} style={styles.pieceImg} resizeMode="contain" fadeDuration={0} /> : null}
      {/* a sweat drop running down the side of its head */}
      {still ? (
        <Animated.View
          style={[
            styles.sweat,
            // (a square, round but for one corner, turned so that corner points up: a drop)
            { width: size * 0.16, height: size * 0.16, borderRadius: size * 0.08, borderTopLeftRadius: 0, opacity: a.sweat.interpolate({ inputRange: [0, 0.12, 0.7, 1], outputRange: [0, 1, 1, 0] }), transform: [{ translateY: a.sweat.interpolate({ inputRange: [0, 1], outputRange: [0, size * 0.3] }) }, { rotate: '45deg' }] },
          ]}
        />
      ) : null}
      {mixed && part !== 'under' ? (
        <View style={styles.huh}>
          <Text style={styles.huhText}>?</Text>
        </View>
      ) : null}
      {locked && part !== 'under' ? (
        <Animated.View style={[styles.tick, { opacity: a.tick, transform: [{ scale: a.tick }] }]}>
          <Svg width={12} height={10} viewBox="0 0 12 10">
            <Path d="M1.5 5 L4.5 8 L10.5 2" stroke="#ffffff" strokeWidth={2.4} fill="none" strokeLinecap="round" strokeLinejoin="round" />
          </Svg>
        </Animated.View>
      ) : null}
    </Animated.View>
  );
});

// a bar that drains: `frac` (Animated 1 → 0) slides the fill out to the left
// (Squish Stack's clock too)
export function Bar({ frac, colors }) {
  const [w, setW] = useState(0);
  const shift = frac.interpolate({ inputRange: [0, 1], outputRange: [-w, 0], extrapolate: 'clamp' });
  return (
    <View style={styles.track} onLayout={(e) => setW(e.nativeEvent.layout.width)}>
      <Animated.View style={[StyleSheet.absoluteFill, { transform: [{ translateX: shift }] }]}>
        <LinearGradient colors={colors} start={{ x: 0, y: 0 }} end={{ x: 1, y: 0 }} style={StyleSheet.absoluteFill} />
        <View style={styles.trackShine} />
      </Animated.View>
    </View>
  );
}

// the glass bar's icon: an eye while you look, a clock while you sort
const BarIcon = memo(function BarIcon({ eye }) {
  return (
    <Svg width={20} height={20} viewBox="0 0 24 24">
      {eye ? (
        <>
          <Path d="M2 12 C5 6.5 8.5 4.5 12 4.5 C15.5 4.5 19 6.5 22 12 C19 17.5 15.5 19.5 12 19.5 C8.5 19.5 5 17.5 2 12 Z" fill="#ffffff" />
          <Ellipse cx={12} cy={12} rx={4.2} ry={4.2} fill="#5b3a29" />
          <Ellipse cx={13.4} cy={10.6} rx={1.3} ry={1.3} fill="#ffffff" />
        </>
      ) : (
        <>
          <Ellipse cx={12} cy={13} rx={9} ry={9} fill="#ffffff" />
          <Path d="M12 8 V13 L15.5 15" stroke="#5b3a29" strokeWidth={2.4} strokeLinecap="round" strokeLinejoin="round" fill="none" />
          <Path d="M9 2.5 H15" stroke="#ffffff" strokeWidth={2.6} strokeLinecap="round" />
        </>
      )}
    </Svg>
  );
});

// the big words over the container (and over Squish Stack's cushions)
export function Banner({ banner, top }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    if (!banner) return undefined;
    t.setValue(0);
    const a = Animated.sequence([
      Animated.spring(t, { toValue: 1, friction: 5, tension: 140, useNativeDriver: true }),
      Animated.timing(t, { toValue: 1, duration: banner.hold || 700, useNativeDriver: true }),
      Animated.timing(t, { toValue: 2, duration: 220, easing: Easing.in(Easing.quad), useNativeDriver: true }),
    ]);
    a.start();
    return () => a.stop();
  }, [banner, t]);
  if (!banner) return null;
  return (
    <Animated.View
      pointerEvents="none"
      style={[
        styles.banner,
        {
          top,
          opacity: t.interpolate({ inputRange: [0, 0.2, 1, 2], outputRange: [0, 1, 1, 0] }),
          transform: [{ scale: t.interpolate({ inputRange: [0, 1, 2], outputRange: [0.3, 1, 1.25] }) }, { rotate: t.interpolate({ inputRange: [0, 1, 2], outputRange: ['-12deg', '-3deg', '0deg'] }) }],
        },
      ]}
    >
      <ShadowText style={[styles.bannerText, banner.small && { fontSize: 30 }]} shadows={outline3(banner.ink || INK, 3)}>
        {banner.text}
      </ShadowText>
      {banner.chips && banner.chips.length ? (
        <View style={styles.chips}>
          {banner.chips.map((c) => (
            <View key={c} style={styles.chip}>
              <Text style={styles.chipText}>{c}</Text>
            </View>
          ))}
        </View>
      ) : null}
      {banner.sub ? <Text style={styles.bannerSub}>{banner.sub}</Text> : null}
    </Animated.View>
  );
}

// --- the game --------------------------------------------------------------------------

// Blitz: the game with a rewarded ad kept loaded for saving a run.
export function SortBlitz(props) {
  const ad = useRewardedAd();
  return <SortGame {...props} blitz ad={ad} />;
}

export default function SortGame({ startLv, pool, blitz = false, ad, adsFree = false, profile, uid, haptics: hapticsOn = true, onExit }) {
  const haptics = useRef(makeHaptics(hapticsOn)).current;
  const [lv, setLv] = useState(startLv);
  const [round, setRound] = useState(0);
  // Blitz: the run, its round, the rounds cleared, its saves, which of its
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
  // the run so far: the rounds it cleared, and whether it's been paid out (payOut)
  const runRec = useRef({ cleared: 0, ended: false });
  // (only the fridge since 2026-11-17, the user: "make it only with food")
  const theme = 'fridge';
  const t = THEMES[theme];
  // the level at the player's skill when it starts (adaptive difficulty;
  // fixed for the deal even when the saved skill changes under it)
  const profileRef = useRef(profile);
  profileRef.current = profile;
  const spec = useMemo(
    () => (blitz ? blitzSpec(idx, record(profileRef.current).bSkill) : levelSpec(lv, record(profileRef.current)[theme].skill)),
    [lv, round, theme, idx, run], // eslint-disable-line react-hooks/exhaustive-deps
  );
  // a fresh deal for every level and every retry
  const board = useMemo(() => makeBoard(spec, pool, Math.random, KINDS), [spec, pool]); // eslint-disable-line react-hooks/exhaustive-deps
  // the result card's three: the fridge's own squishies (the impostors come last in the pieces)
  const trio = useMemo(() => trioOf(board.pieces.filter((p) => p.home != null).slice(0, 3).map((p) => keyOf(p.id)), pool.map((p) => keyOf(p.id))), [board, pool]);
  const [area, setArea] = useState(null);
  const areaRef = useRef(null);
  const origin = useRef({ x: 0, y: 0 });
  const onArea = useCallback((e) => {
    const { width, height } = e.nativeEvent.layout;
    if (width > 0 && height > 0) setArea((a) => (a && a.w === width && a.h === height ? a : { w: width, h: height }));
    areaRef.current?.measure((x, y, w, h, px, py) => (origin.current = { x: px, y: py }));
  }, []);
  // the whole screen (the kitchen behind it; the level runs edge to edge since 2026-11-17)
  const [root, setRoot] = useState(null);
  const rootRef = useRef(null);
  rootRef.current = root;
  const onRoot = useCallback((e) => {
    const { width, height } = e.nativeEvent.layout;
    if (width > 0 && height > 0) setRoot((r) => (r && r.w === width && r.h === height ? r : { w: width, h: height }));
  }, []);
  const tg = useMemo(() => (area ? trayGeo(area.w, area.h, board.trayCap) : null), [area, board]);
  // the level's fridge, small to very very large (models.js)
  const m = modelOf(theme, spec.model);
  const g = useMemo(
    () => (area ? geometry({ w: area.w - tg.tw - 20, h: area.h, rows: spec.rows, cols: spec.cols, model: m, trayH: 0 }) : null),
    [area, spec, m, tg],
  );
  // the squishies stand on the shelves, smaller than their spots (the
  // user, 2026-10-24: "the creatures need to be smaller"), and so does the clutter
  const P = g ? Math.round(g.S * 0.8) : 0;
  const Q = g ? Math.round(g.S * 0.74) : 0;
  const trayScale = g ? Math.min(1, (tg.cell * 0.94) / P) : 1;

  // --- animated things ---
  const door = useRef(new Animated.Value(1)).current;
  const light = useRef(new Animated.Value(1)).current;
  const pop = useRef(new Animated.Value(0)).current;
  const rot = useRef(new Animated.Value(0)).current;
  const tx = useRef(new Animated.Value(0)).current;
  const ty = useRef(new Animated.Value(0)).current;
  const sq = useRef(new Animated.Value(0)).current; // -1 stretched … 1 squashed
  const peekBar = useRef(new Animated.Value(1)).current;
  const hover = useRef({ x: new Animated.Value(0), y: new Animated.Value(0), o: new Animated.Value(0) }).current;
  // the squishies on show inside (the peek) and in play (after the shake)
  // (`hop` and `sq`: the win's bounce wave behind the shutting doors, when the stills stand in for the rigs)
  const ins = useMemo(() => board.pieces.map(() => ({ x: new Animated.Value(0), y: new Animated.Value(0), s: new Animated.Value(0), hop: new Animated.Value(0), sq: new Animated.Value(0) })), [board]);
  const anims = useMemo(
    () =>
      board.pieces.map(() => ({
        x: new Animated.Value(0),
        y: new Animated.Value(0),
        s: new Animated.Value(1),
        o: new Animated.Value(0),
        lift: new Animated.Value(0),
        shake: new Animated.Value(0),
        hop: new Animated.Value(0),
        tick: new Animated.Value(0),
        sq: new Animated.Value(0),
        tilt: new Animated.Value(0),
        spin: new Animated.Value(0),
        sweat: new Animated.Value(0),
      })),
    [board],
  );
  const fx = useRef(null);
  const fxTop = useRef(null); // Blitz: over the cards, a new best's confetti
  const clk = useClock();

  // --- the rigs (tools/rig/sort.html, through RigStage) ---
  // A deal's rigs are sent to the page as it starts (`castTag` names them) and load through the peek; the page says
  // when they're all drawn (`rigTag`). From the tumble on, the deal is played by the rigs if they're drawn by then
  // (`rigLive`), else by the stills. rid(k): piece k's id on the page.
  const stage = useRef(null);
  const rig = useCallback((fn, ...args) => stage.current && stage.current[fn](...args), []);
  const castTag = useRef('');
  const castMsg = useRef(null);
  // a drag's latest spot for the page, sent once a frame; and where the dragged one is (its still's top-left)
  const dragOut = useRef(null);
  const dragAt = useRef(null);
  const dragRaf = useRef(0);
  const rigTag = useRef(null);
  const [rigLive, setRigLiveState] = useState(false);
  const rigLiveRef = useRef(false);
  const setRigLive = useCallback((on) => {
    rigLiveRef.current = on;
    setRigLiveState(on);
  }, []);
  const rids = useMemo(() => {
    const seen = new Set();
    return board.pieces.map((p, k) => {
      const id = String(p.id);
      const r = seen.has(id) ? `${id}#${k}` : id;
      seen.add(id);
      return r;
    });
  }, [board]);
  // the win's wave (the stills in play give way to the inside ones, or to the rigs), and a loss's droop
  const [winning, setWinning] = useState(false);
  const [sad, setSad] = useState(false);

  // --- state ---
  const [phase, setPhaseState] = useState('load');
  const phaseRef = useRef('load');
  const setPhase = useCallback((p) => {
    phaseRef.current = p;
    setPhaseState(p);
  }, []);
  const [play, setPlayState] = useState(() => startState(board));
  const playRef = useRef(play);
  const setPlay = useCallback((s) => {
    playRef.current = s;
    setPlayState(s);
  }, []);
  const [mistakes, setMistakesState] = useState(0);
  const mistakesRef = useRef(0);
  const [selected, setSelectedState] = useState(null);
  const selectedRef = useRef(null);
  // (a squishy chosen by a tap is held up and wiggles: the rig too)
  const setSelected = useCallback(
    (k) => {
      const prev = selectedRef.current;
      selectedRef.current = k;
      setSelectedState(k);
      if (!rigLiveRef.current || prev === k) return;
      if (prev != null) rig('hold', rids[prev], null);
      if (k != null) rig('hold', rids[k], 'tap');
    },
    [rig, rids],
  );
  const [dragK, setDragK] = useState(null);
  const [banner, setBanner] = useState(null);
  const [peekLeft, setPeekLeft] = useState(0);
  const [left, setLeft] = useState(0); // seconds left to put them back
  const [result, setResult] = useState(null);
  const [fail, setFail] = useState(null);
  const [paused, setPausedState] = useState(false);
  const pausedRef = useRef(false);
  const setPaused = useCallback((p) => {
    pausedRef.current = p;
    setPausedState(p);
  }, []);
  const say = useCallback((text, more = {}) => setBanner({ text, key: Date.now(), ...more }), []);

  // timers, cleared on a new deal and on leaving
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
    sfx.preload(blitz ? [...LOAD_SOUNDS, ...BLITZ_SOUNDS] : LOAD_SOUNDS);
    return () => {
      alive.current = false;
      clearTimers();
    };
  }, [clearTimers]);

  // refs the touch handlers read
  const live = useRef({});
  live.current = { board, g, tg, P, trayScale, anims, spec, rids, m, aw: area ? area.w : 0 };
  // the clutter shown inside: where it was for the peek, moved by the shake
  const [foodMoved, setFoodMoved] = useState(false);
  const clutterIn = useRef(new Animated.Value(0)).current;

  // where a piece sits now (its top-left and scale)
  const spotOf = useCallback((loc) => {
    const { g: G, tg: TG, P: PP, trayScale: TS } = live.current;
    if (loc.kind === 'slot') {
      const c = slotCenter(G, loc.i);
      // standing on the shelf
      return { x: c.x - PP / 2, y: c.y + G.S / 2 - PP - 1, s: 1 };
    }
    const c = trayCenter(TG, loc.i);
    return { x: c.x - PP / 2, y: c.y - PP / 2, s: TS };
  }, []);
  const fly = useCallback(
    (k, loc, { bounce = 7, hop = 0 } = {}) => {
      const A = live.current.anims[k];
      const to = spotOf(loc);
      const anims2 = [
        Animated.spring(A.x, { toValue: to.x, friction: bounce, tension: 90, useNativeDriver: true }),
        Animated.spring(A.y, { toValue: to.y, friction: bounce, tension: 90, useNativeDriver: true }),
        Animated.spring(A.s, { toValue: to.s, friction: 6, tension: 110, useNativeDriver: true }),
        Animated.timing(A.lift, { toValue: 0, duration: 140, useNativeDriver: true }),
      ];
      if (hop) anims2.push(Animated.sequence([Animated.timing(A.hop, { toValue: -hop, duration: 160, easing: Easing.out(Easing.quad), useNativeDriver: true }), Animated.timing(A.hop, { toValue: 0, duration: 200, easing: Easing.in(Easing.quad), useNativeDriver: true })]));
      Animated.parallel(anims2).start();
    },
    [spotOf],
  );

  // --- the stills' own moves (the rigs do these on their page) ---
  // A piece's turn: a later step of one of its moves (the bounce back after a head shake) is dropped once the player
  // has picked it up again.
  const turns = useRef({});
  const nextTurn = useCallback((k) => (turns.current[k] = (turns.current[k] || 0) + 1), []);
  const laterFor = useCallback(
    (k, ms, fn) => {
      const t = turns.current[k] || 0;
      later(ms, () => (turns.current[k] || 0) === t && fn());
    },
    [later],
  );
  // squashed flat, then springing back with a wobble
  const squash = useCallback((A, hard = 0.5) => {
    Animated.sequence([
      Animated.timing(A.sq, { toValue: hard, duration: 60, easing: Easing.out(Easing.quad), useNativeDriver: true }),
      Animated.spring(A.sq, { toValue: 0, friction: 3.5, tension: 170, useNativeDriver: true }),
    ]).start();
  }, []);
  // a sweat drop running down
  const sweat = useCallback((A) => {
    A.sweat.setValue(0);
    Animated.timing(A.sweat, { toValue: 1, duration: 900, easing: Easing.in(Easing.quad), useNativeDriver: true }).start();
  }, []);
  // the right spot: squashed in as it lands, a happy hop, squashed again
  const joyStill = useCallback(
    (k) => {
      const A = live.current.anims[k];
      const S = live.current.g.S;
      laterFor(k, 170, () => squash(A, 0.6));
      laterFor(k, 330, () => {
        Animated.parallel([
          Animated.sequence([
            Animated.timing(A.hop, { toValue: -S * 0.3, duration: 180, easing: Easing.out(Easing.quad), useNativeDriver: true }),
            Animated.timing(A.hop, { toValue: 0, duration: 180, easing: Easing.in(Easing.quad), useNativeDriver: true }),
          ]),
          Animated.sequence([
            Animated.timing(A.sq, { toValue: -0.45, duration: 120, useNativeDriver: true }),
            Animated.timing(A.sq, { toValue: 0, duration: 240, useNativeDriver: true }),
          ]),
        ]).start(({ finished }) => finished && squash(A, 0.45));
      });
    },
    [laterFor, squash],
  );
  // a wrong spot: onto it, a shake of the head with a sweat drop, then one big bounce back to `back`
  const nopeStill = useCallback(
    (k, at, back) => {
      const A = live.current.anims[k];
      fly(k, at, { bounce: 8 });
      laterFor(k, 160, () => {
        squash(A, 0.35);
        sweat(A);
        A.tilt.setValue(0);
        Animated.sequence([14, -14, 12, -9, 5, 0].map((v) => Animated.timing(A.tilt, { toValue: v, duration: 80, easing: Easing.inOut(Easing.quad), useNativeDriver: true }))).start();
      });
      laterFor(k, 760, () => {
        fly(k, back, { hop: live.current.P * 0.75 });
        Animated.sequence([Animated.timing(A.sq, { toValue: -0.4, duration: 140, useNativeDriver: true }), Animated.timing(A.sq, { toValue: 0, duration: 220, useNativeDriver: true })]).start();
      });
      laterFor(k, 1140, () => {
        squash(A, 0.45);
        sfx.play('fs_drop');
      });
    },
    [fly, laterFor, squash, sweat],
  );
  // an impostor found out: a guilty jump, then a spin away off the nearer side, smaller and smaller
  // (`y0`: where it stands, its still's top)
  const caughtStill = useCallback(
    (k, dir, y0, delay = 0) => {
      const A = live.current.anims[k];
      const { P: PP, aw: W } = live.current;
      laterFor(k, delay, () => {
        sweat(A);
        Animated.sequence([
          Animated.timing(A.sq, { toValue: 0.35, duration: 70, useNativeDriver: true }),
          Animated.parallel([
            Animated.timing(A.hop, { toValue: -PP * 0.5, duration: 230, easing: Easing.out(Easing.quad), useNativeDriver: true }),
            Animated.timing(A.sq, { toValue: -0.45, duration: 160, useNativeDriver: true }),
          ]),
        ]).start();
      });
      laterFor(k, delay + 320, () => {
        const ease = Easing.in(Easing.quad);
        Animated.parallel([
          Animated.timing(A.x, { toValue: dir < 0 ? -PP * 1.6 : W + PP * 0.6, duration: 720, easing: ease, useNativeDriver: true }),
          Animated.timing(A.y, { toValue: y0 - PP * 0.9, duration: 720, easing: Easing.out(Easing.quad), useNativeDriver: true }),
          Animated.timing(A.spin, { toValue: dir * 900, duration: 720, easing: ease, useNativeDriver: true }),
          Animated.timing(A.s, { toValue: 0.45, duration: 720, useNativeDriver: true }),
          Animated.timing(A.o, { toValue: 0, duration: 720, easing: Easing.in(Easing.cubic), useNativeDriver: true }),
          Animated.timing(A.sq, { toValue: 0, duration: 300, useNativeDriver: true }),
        ]).start();
      });
    },
    [laterFor, sweat],
  );
  // which side a squishy at `x` (the play area's) spins away to: the nearer one
  const awayDir = useCallback((x) => (x < live.current.aw / 2 ? -1 : 1), []);

  // --- the round ---------------------------------------------------------------------

  const insideXY = useCallback((slot) => {
    const G = live.current.g;
    const PP = live.current.P;
    return { x: (slot % G.cols) * G.S + (G.S - PP) / 2, y: Math.floor(slot / G.cols) * (G.S + SHELF) + G.S - PP - 1 };
  }, []);
  const insideNow = useRef({});
  const [showInside, setShowInside] = useState(true);

  const hopInside = useCallback(
    (k, slot) => {
      const A = ins[k];
      const to = insideXY(slot);
      const G = live.current.g;
      Animated.parallel([
        Animated.timing(A.x, { toValue: to.x, duration: 560, easing: Easing.inOut(Easing.quad), useNativeDriver: true }),
        Animated.sequence([
          Animated.timing(A.y, { toValue: to.y - G.S * 0.6, duration: 280, easing: Easing.out(Easing.quad), useNativeDriver: true }),
          Animated.timing(A.y, { toValue: to.y, duration: 280, easing: Easing.in(Easing.quad), useNativeDriver: true }),
        ]),
      ]).start();
    },
    [ins, insideXY],
  );

  const swapNow = useCallback(
    ([a, b]) => {
      const now = insideNow.current;
      const pa = now[a];
      const pb = now[b];
      if (pa != null) hopInside(pa, b);
      if (pb != null) hopInside(pb, a);
      const next = { ...now };
      delete next[a];
      delete next[b];
      if (pa != null) next[b] = pa;
      if (pb != null) next[a] = pb;
      insideNow.current = next;
      sfx.play('fs_swap');
    },
    [hopInside],
  );

  // A loss: everyone droops (`list` [{ k, delay }]), a deflating sigh, then a
  // slow sad sway.
  const droop = useCallback(
    (list) => {
      if (!list.length) return;
      if (rigLiveRef.current) rig('lose', list.map(({ k, delay }) => ({ id: live.current.rids[k], delay })));
      list.forEach(({ k, delay }) => later(delay, () => Animated.timing(live.current.anims[k].sq, { toValue: 0.24, duration: 520, easing: Easing.out(Easing.quad), useNativeDriver: true }).start()));
      later(Math.min(...list.map((d) => d.delay)), () => setSad(true));
    },
    [later, rig],
  );

  // Blitz: pays the run out once (the rounds it cleared) and saves the record. Also when the player quits or starts
  // over in the middle of a run, so cleared rounds always count.
  const payOut = useCallback(() => {
    const R = runRec.current;
    if (!blitz || !runStarted.current || R.ended) return null;
    R.ended = true;
    const out = afterBlitz(profileRef.current, { cleared: R.cleared });
    if (uid) saveSort(uid, out.update, out.coins, out.xp, profileRef.current);
    return out;
  }, [blitz, uid]);

  // Blitz: a mistake ('mistake') or the round's clock running out ('time') stops the run, and the save card comes up
  // (a squishy still being dragged goes back first)
  const blitzStop = useCallback(
    (reason) => {
      clk.pause();
      setPhase('held');
      const T = touch.current;
      touch.current = null;
      if (T && T.moved && T.k != null) {
        setDragK(null);
        handlers.current.handleDrop(T.k, null, null);
      }
      setSelected(null);
      hover.o.setValue(0);
      setFailReason(reason);
      setSaveErr(null);
      if (reason === 'time') sfx.play('sd_timeUp');
      haptics.wrong();
      later(reason === 'time' ? 900 : 800, () => setBlitzCard('save'));
    },
    [clk, haptics, hover.o, later, setPhase, setSelected],
  );

  // Blitz: the run goes on from the same round: after a mistake its clock runs on, after the clock ran out it starts
  // again
  const goOn = useCallback(
    (reason) => {
      setSaving(false);
      setBlitzCard(null);
      sfx.play('sd_revive');
      setPhase('place');
      if (reason === 'time') {
        setLeft(Math.ceil(live.current.spec.limitMs / 1000));
        clk.start(live.current.spec.limitMs);
      } else clk.resume();
    },
    [clk, setPhase],
  );
  const saveByAd = useCallback(() => {
    const back = () => {
      if (!alive.current) return;
      setAdUsed(true);
      goOn(failReason);
    };
    if (adsFree) back();
    else ad?.show(back);
  }, [ad, adsFree, failReason, goOn]);
  const saveByGems = useCallback(() => {
    if (saving) return;
    setSaving(true);
    setSaveErr(null);
    squad
      .blitzSave(gemSaves)
      .then(() => {
        if (!alive.current) return;
        setGemSaves((n) => n + 1);
        goOn(failReason);
      })
      .catch((e) => {
        if (!alive.current) return;
        setSaving(false);
        setSaveErr(String((e && e.message) || e) === 'not_enough_gems' ? 'Not enough gems' : "Couldn't reach the server. Try again?");
      });
  }, [failReason, gemSaves, goOn, saving]);

  // Blitz: GAME OVER (END RUN on the save card): everyone droops where they are, then the card with the rounds
  // cleared, the best and what they paid
  const endRun = useCallback(() => {
    setPhase('lost');
    clk.pause();
    setSelected(null);
    hover.o.setValue(0);
    setBlitzCard(null);
    const st = playRef.current;
    droop(live.current.board.pieces.map((_, k) => k).filter((k) => !st.gone[k]).map((k, n) => ({ k, delay: 150 + n * 60 })));
    const top = record(profileRef.current).blitz.top;
    const n = runRec.current.cleared;
    const out = payOut() || { coins: 0, xp: 0, levelUps: [], newTop: false };
    const res = { ...out, cleared: n, best: Math.max(top, n) };
    setOver(res);
    later(1100, () => {
      setBlitzCard('over');
      if (res.newTop) {
        sfx.play('sd_blitzWin');
        haptics.win();
        const R = rootRef.current;
        if (R) [0, 300, 600].forEach((d, i) => later(d, () => fxTop.current?.burst('confetti', R.w * (0.25 + 0.25 * i), R.h * 0.3, 1)));
      } else {
        sfx.play('sd_blitzFail');
        haptics.wrong();
        later(600, () => sfx.play('sd_drain'));
      }
    });
  }, [clk, droop, haptics, hover.o, later, payOut, setPhase, setSelected]);

  const lose = useCallback(
    (reason) => {
      if (phaseRef.current !== 'place') return;
      if (blitz) {
        blitzStop(reason);
        return;
      }
      setPhase('lost');
      clk.pause();
      setSelected(null);
      hover.o.setValue(0);
      sfx.play(reason === 'time' ? 'sd_timeUp' : 'sd_blitzFail');
      haptics.wrong();
      // show where they all belonged: the ones not home hop there, the impostors still in the tray are found out
      // and spin away; then everyone droops, and the card
      const { board: B, P: PP, rids: R } = live.current;
      const st = playRef.current;
      const rigs = rigLiveRef.current;
      const sadList = [];
      let last = 0;
      let n = 0;
      B.pieces.forEach((p, k) => {
        if (st.gone[k]) return;
        nextTurn(k);
        if (p.home == null) {
          const c = spotOf(st.at[k]);
          const dir = awayDir(c.x + PP / 2);
          const delay = 150 + n++ * 110;
          caughtStill(k, dir, c.y, delay);
          if (rigs) rig('caught', R[k], dir, delay);
          return;
        }
        if (st.locked[k]) {
          sadList.push({ k, delay: 350 + sadList.length * 50 });
          return;
        }
        const home = { kind: 'slot', i: p.home };
        const d = 200 + k * 70;
        later(d, () => {
          fly(k, home, { hop: 30 });
          if (rigs) rig('go', R[k], spotOf(home), { crowd: true, h: 30 });
        });
        sadList.push({ k, delay: d + 480 });
        last = Math.max(last, d + 480);
      });
      droop(sadList);
      const out = afterLevel(profile, theme, live.current.spec, { won: false, mistakes: mistakesRef.current });
      if (uid) saveSort(uid, out.update, 0);
      later(Math.max(1900, last + 1000), () => setFail({ reason }));
    },
    [awayDir, blitz, blitzStop, caughtStill, clk, droop, fly, haptics, hover.o, later, nextTurn, profile, rig, setPhase, setSelected, spotOf, theme, uid],
  );

  const win = useCallback(() => {
    setPhase('won');
    clk.pause();
    setSelected(null);
    hover.o.setValue(0);
    setWinning(true);
    const { board: B, g: G, m: M, P: PP, rids: R } = live.current;
    const st = playRef.current;
    const rigs = rigLiveRef.current;
    // impostors still in the tray: found out, a guilty jump and a spin away
    let n = 0;
    B.pieces.forEach((p, k) => {
      if (p.home != null || st.gone[k]) return;
      const c = spotOf(st.at[k]);
      const dir = awayDir(c.x + PP / 2);
      const delay = 100 + n++ * 110;
      nextTurn(k);
      caughtStill(k, dir, c.y, delay);
      if (rigs) rig('caught', R[k], dir, delay);
    });
    sfx.play('sd_solve');
    haptics.win();
    // a bounce wave along the shelves, column by column (each row a little behind), as the doors swing shut over it
    // (the stills: the inside ones, at home under the doors)
    const reals = B.pieces.map((_, k) => k).filter((k) => B.pieces[k].home != null);
    const waveAt = (home) => 150 + (home % G.cols) * 70 + Math.floor(home / G.cols) * 40;
    if (rigs) rig('win', reals.map((k) => ({ id: R[k], delay: waveAt(B.pieces[k].home) })), null);
    else {
      reals.forEach((k) => {
        const at = insideXY(B.pieces[k].home);
        const I = ins[k];
        [I.x, I.y, I.s, I.hop, I.sq].forEach((v, j) => v.setValue([at.x, at.y, 1, 0, 0][j]));
        later(waveAt(B.pieces[k].home), () =>
          Animated.sequence([
            Animated.timing(I.sq, { toValue: 0.3, duration: 70, useNativeDriver: true }),
            Animated.parallel([
              Animated.timing(I.hop, { toValue: -G.S * 0.42, duration: 170, easing: Easing.out(Easing.quad), useNativeDriver: true }),
              Animated.timing(I.sq, { toValue: -0.4, duration: 120, useNativeDriver: true }),
            ]),
            Animated.parallel([
              Animated.timing(I.hop, { toValue: 0, duration: 170, easing: Easing.in(Easing.quad), useNativeDriver: true }),
              Animated.timing(I.sq, { toValue: 0, duration: 170, useNativeDriver: true }),
            ]),
            Animated.timing(I.sq, { toValue: 0.3, duration: 60, useNativeDriver: true }),
            Animated.spring(I.sq, { toValue: 0, friction: 3.5, tension: 170, useNativeDriver: true }),
          ]).start(),
        );
      });
    }
    Animated.sequence([0.4, 1, 0.5, 1].map((v) => Animated.timing(light, { toValue: v, duration: 110, useNativeDriver: true }))).start();
    later(250, () => {
      sfx.play('sd_confetti');
      fx.current?.burst('confetti', G.ix + G.W / 2, G.iy + G.H * 0.3, 1.2);
    });
    // the doors (the rig page clips its squishies to the shelves they haven't covered yet, on the same curve)
    later(SHUT_AT, () => {
      if (rigs) {
        const list = M.doors === 1 ? [{ x0: G.ix, w: G.dw, hinge: M.hinge }] : [{ x0: G.ix, w: G.dw, hinge: 'left' }, { x0: G.ix + G.dw, w: G.dw, hinge: 'right' }];
        rig('win', [], { ms: SHUT_MS, deg: G.deg, persp: G.persp, list });
      }
      Animated.parallel([
        Animated.timing(door, { toValue: 0, duration: SHUT_MS, easing: Easing.in(Easing.quad), useNativeDriver: true }),
        Animated.timing(light, { toValue: 0, duration: SHUT_MS, useNativeDriver: true }),
      ]).start(({ finished }) => {
        if (!finished || !alive.current) return;
        sfx.play('fs_doorClose');
        haptics.place();
        Animated.sequence([Animated.timing(sq, { toValue: 0.45, duration: 60, useNativeDriver: true }), Animated.spring(sq, { toValue: 0, friction: 4, tension: 180, useNativeDriver: true })]).start();
        fx.current?.burst('confetti', G.ix + G.W * 0.25, G.iy + G.H * 0.4, 1);
        fx.current?.burst('confetti', G.ix + G.W * 0.75, G.iy + G.H * 0.4, 1);
      });
    });
    if (blitz) {
      // one more cleared; on to the next round
      const i = idxRef.current;
      runRec.current.cleared = i + 1;
      later(300, () => {
        setCleared(i + 1);
        sfx.play('sd_pip', { rate: 0.9 + Math.min(12, i) * 0.05 });
      });
      later(1700, () => {
        sfx.play('sd_blitzNext');
        setIdx(i + 1);
      });
      return;
    }
    const out = afterLevel(profile, theme, live.current.spec, { won: true, mistakes: mistakesRef.current, ms: clk.elapsed() });
    if (uid) saveSort(uid, out.update, out.coins, out.xp, profile);
    const ms = clk.elapsed();
    const { stars, coins, xp, before, after, levelUps, unlocked } = out;
    later(1700, () => setResult({ stars, coins, xp, before, after, levelUps, mistakes: mistakesRef.current, ms, unlocked }));
  }, [awayDir, blitz, caughtStill, clk, door, haptics, hover.o, ins, insideXY, later, light, nextTurn, pool, profile, rig, setPhase, setSelected, spotOf, sq, theme, uid]);

  const mistake = useCallback(() => {
    mistakesRef.current += 1;
    setMistakesState(mistakesRef.current);
    haptics.wrong();
    if (blitz) {
      // Blitz: one mistake stops the run (save it, or GAME OVER)
      blitzStop('mistake');
      return;
    }
    later(160, () => sfx.play('fs_heart'));
    if (mistakesRef.current >= HEARTS) later(500, () => lose('hearts'));
  }, [blitz, blitzStop, haptics, later, lose]);

  // a piece let go (or a tapped spot): the board's rule, then the animation
  const handleDrop = useCallback(
    (k, target, at) => {
      const { board: B } = live.current;
      const before = playRef.current;
      const from = before.at[k];
      const r = dropRule(B, before, k, target);
      setPlay(r.state);
      setSelected(null);
      hover.o.setValue(0);
      const A = live.current.anims[k];
      const rigs = rigLiveRef.current;
      const R = live.current.rids;
      const PP = live.current.P;
      // where it is: under the finger if it was dragged, else still in its spot (a tap on a spot sends the chosen one)
      const here = dragAt.current && dragAt.current.k === k ? dragAt.current : spotOf(from);
      dragOut.current = null;
      dragAt.current = null;
      nextTurn(k);
      if (r.outcome === 'lock') {
        // squashed into its spot, a happy hop, sparkles
        fly(k, r.state.at[k], { bounce: 5 });
        joyStill(k);
        if (rigs) rig('correct', R[k], spotOf(r.state.at[k]));
        const c = slotCenter(live.current.g, target.i);
        fx.current?.burst('spark', c.x, c.y, 1.1);
        sfx.play('fs_snap');
        haptics.place();
        A.tick.setValue(0);
        Animated.sequence([Animated.spring(A.tick, { toValue: 1, friction: 4, tension: 160, useNativeDriver: true })]).start();
        if (r.bumped != null) {
          const b = r.bumped;
          nextTurn(b);
          later(120, () => {
            fly(b, r.state.at[b], { hop: 26 });
            laterFor(b, 380, () => squash(live.current.anims[b], 0.35));
            if (rigs) rig('go', R[b], spotOf(r.state.at[b]), { h: 26 });
            sfx.play('fs_drop');
          });
        }
        // (once the last one's happy hop is down)
        if (solved(B, r.state)) later(700, win);
      } else if (r.outcome === 'wrong') {
        // onto the wrong spot, a shake of the head (no!) with a sweat drop, and one big bounce back to the tray
        sfx.play('fs_wrong');
        if (at) fx.current?.burst('angry', at.x, at.y, 1);
        const spot = { kind: 'slot', i: target.i };
        nopeStill(k, spot, from);
        if (rigs) rig('wrong', R[k], spotOf(spot), spotOf(from));
        mistake();
      } else if (r.outcome === 'impostor') {
        // found out: a guilty jump, then it spins away
        sfx.play('fs_impostor');
        say('IMPOSTOR!', { ink: '#8e1030', small: true, hold: 500, sub: 'It was never inside!' });
        const dir = awayDir(here.x + PP / 2);
        caughtStill(k, dir, here.y);
        if (rigs) rig('caught', R[k], dir, 0);
        later(380, () => fx.current?.burst('poof', here.x + PP / 2, here.y + PP / 2, 1.2));
        mistake();
      } else {
        // back to the tray (or where it was), landing with a squash
        fly(k, r.state.at[k]);
        laterFor(k, 220, () => squash(A, 0.3));
        if (rigs) rig('go', R[k], spotOf(r.state.at[k]), { h: 14 });
        sfx.play('fs_drop');
      }
    },
    [awayDir, caughtStill, fly, haptics, hover.o, joyStill, later, laterFor, mistake, nextTurn, nopeStill, rig, say, setPlay, setSelected, spotOf, squash, win],
  );

  // --- touch -------------------------------------------------------------------------

  const toLocal = (e) => ({ x: e.pageX - origin.current.x, y: e.pageY - origin.current.y });
  const hitPiece = useCallback((x, y) => {
    const { board: B, g: G, tg: TG } = live.current;
    const st = playRef.current;
    for (let k = B.pieces.length - 1; k >= 0; k--) {
      if (st.locked[k] || st.gone[k]) continue;
      const loc = st.at[k];
      const c = loc.kind === 'slot' ? slotCenter(G, loc.i) : trayCenter(TG, loc.i);
      const half = loc.kind === 'slot' ? G.S / 2 : TG.cell / 2;
      if (Math.abs(x - c.x) <= half && Math.abs(y - c.y) <= half) return k;
    }
    return null;
  }, []);
  const targetAt = useCallback((x, y) => {
    const { g: G, tg: TG } = live.current;
    const i = slotAt(G, x, y);
    if (i >= 0) return { kind: 'slot', i };
    if (x >= TG.tx - 14 && x <= TG.tx + TG.tw + 14 && y >= TG.ty - 20 && y <= TG.ty + TG.th + 14) return { kind: 'tray' };
    return null;
  }, []);
  const showHover = useCallback((x, y) => {
    const G = live.current.g;
    const i = slotAt(G, x, y);
    if (i < 0) {
      hover.o.setValue(0);
      return;
    }
    const c = slotCenter(G, i);
    hover.x.setValue(c.x - G.S / 2);
    hover.y.setValue(c.y - G.S / 2);
    hover.o.setValue(1);
  }, [hover]);

  // picked up to drag: stretched tall and lifted (the rig held, thrilled, wiggling)
  const grab = useCallback(
    (k) => {
      const A = live.current.anims[k];
      nextTurn(k);
      setDragK(k);
      setSelected(null);
      sfx.play('fs_pick');
      haptics.tap();
      [A.tilt, A.sweat, A.hop].forEach((v) => v.setValue(0));
      Animated.parallel([
        Animated.spring(A.s, { toValue: 1.06, friction: 6, tension: 160, useNativeDriver: true }),
        Animated.timing(A.lift, { toValue: 1, duration: 120, useNativeDriver: true }),
        Animated.sequence([Animated.timing(A.sq, { toValue: -0.5, duration: 90, easing: Easing.out(Easing.quad), useNativeDriver: true }), Animated.spring(A.sq, { toValue: -0.25, friction: 4, tension: 160, useNativeDriver: true })]),
      ]).start();
      if (rigLiveRef.current) rig('hold', live.current.rids[k], 'drag');
    },
    [haptics, nextTurn, rig, setSelected],
  );
  // held a little above the finger at (x, y), so it can be seen
  const dragTo = useCallback(
    (k, x, y) => {
      const { anims: AS, P: PP, g: G } = live.current;
      const nx = x - PP / 2;
      const ny = y - PP / 2 - G.S * 0.42;
      AS[k].x.setValue(nx);
      AS[k].y.setValue(ny);
      dragAt.current = { k, x: nx, y: ny };
      showHover(x, y - G.S * 0.42);
      if (!rigLiveRef.current) return;
      dragOut.current = [k, nx, ny];
      if (!dragRaf.current)
        dragRaf.current = requestAnimationFrame(() => {
          dragRaf.current = 0;
          const d = dragOut.current;
          if (d) rig('drag', live.current.rids[d[0]], d[1], d[2]);
        });
    },
    [rig, showHover],
  );

  const touch = useRef(null);
  const handlers = useRef({});
  handlers.current = { hitPiece, targetAt, handleDrop, showHover, setSelected, haptics, grab, dragTo };
  const responder = useMemo(
    () =>
      PanResponder.create({
        onStartShouldSetPanResponder: () => phaseRef.current === 'place' && !pausedRef.current,
        onMoveShouldSetPanResponder: () => false,
        onPanResponderTerminationRequest: () => false,
        onPanResponderGrant: (e) => {
          const p = toLocal(e.nativeEvent);
          touch.current = { x0: p.x, y0: p.y, k: handlers.current.hitPiece(p.x, p.y), moved: false };
        },
        onPanResponderMove: (e) => {
          const T = touch.current;
          if (!T || T.k == null) return;
          const p = toLocal(e.nativeEvent);
          if (!T.moved) {
            if (Math.hypot(p.x - T.x0, p.y - T.y0) < 9) return;
            T.moved = true;
            handlers.current.grab(T.k);
          }
          handlers.current.dragTo(T.k, p.x, p.y);
        },
        onPanResponderRelease: (e) => {
          const T = touch.current;
          touch.current = null;
          if (!T || phaseRef.current !== 'place') return;
          const p = toLocal(e.nativeEvent);
          const G = live.current.g;
          if (T.moved && T.k != null) {
            setDragK(null);
            const y = p.y - G.S * 0.42;
            handlers.current.handleDrop(T.k, handlers.current.targetAt(p.x, y), { x: p.x, y });
            return;
          }
          // a tap: pick one up, put the picked one down there, or let go of it
          const sel = selectedRef.current;
          const st = playRef.current;
          if (T.k != null && (sel == null || (st.at[T.k].kind === 'tray' && T.k !== sel))) {
            handlers.current.setSelected(T.k);
            sfx.play('fs_pick');
            handlers.current.haptics.tap();
            return;
          }
          if (sel != null && T.k === sel) {
            handlers.current.setSelected(null);
            sfx.play('fs_drop');
            return;
          }
          if (sel != null) {
            const target = handlers.current.targetAt(p.x, p.y);
            if (target) handlers.current.handleDrop(sel, target, p);
            else handlers.current.setSelected(null);
          }
        },
        onPanResponderTerminate: () => {
          const T = touch.current;
          touch.current = null;
          if (T && T.moved && T.k != null) {
            setDragK(null);
            handlers.current.handleDrop(T.k, null, null);
          }
        },
      }),
    [],
  );

  // --- the timeline ------------------------------------------------------------------

  const startPlace = useCallback(() => {
    setPhase('place');
    // the deal's rigs drawn only now (a slow phone): everyone's at rest, so they take over here
    if (!rigLiveRef.current && rigTag.current === castTag.current) {
      const st = playRef.current;
      live.current.board.pieces.forEach((_, k) => !st.gone[k] && rig('place', live.current.rids[k], { ...spotOf(st.at[k]), o: 1 }));
      setRigLive(true);
    }
    const S = live.current.spec;
    const notes = [];
    if (S.decoys) notes.push(`${S.decoys} impostor${S.decoys > 1 ? 's' : ''} snuck in!`);
    if (S.mixed) notes.push('Some got mixed up inside!');
    say('PUT THEM BACK!', { small: true, sub: notes.join('  ') || 'Drag or tap them home', hold: 900 });
    if (S.mixed) later(300, () => sfx.play('fs_mixed'));
    // (Blitz: each round on its own clock, blitzSpec's)
    clk.start(S.limitMs);
    if (blitz) runStarted.current = true;
  }, [blitz, clk, later, rig, say, setPhase, setRigLive, spotOf]);

  const tumble = useCallback(() => {
    const { board: B, g: G, rids: R } = live.current;
    setPhase('tumble');
    sfx.play('fs_tumble');
    // the rigs play the deal from here if the page has drawn them all by now (else the stills do)
    const rigs = rigTag.current === castTag.current;
    setRigLive(rigs);
    let n = 0;
    B.pieces.forEach((p, k) => {
      const A = live.current.anims[k];
      const a = B.after[k];
      [A.lift, A.hop, A.shake, A.tick, A.sq, A.tilt, A.spin, A.sweat].forEach((v) => v.setValue(0));
      if (a.kind === 'slot') {
        const to = spotOf(a);
        A.x.setValue(to.x);
        A.y.setValue(to.y);
        A.s.setValue(1);
        Animated.timing(A.o, { toValue: 1, duration: 140, useNativeDriver: true }).start();
        if (rigs) rig('tumble', R[k], null, to, 0, 0, true);
        return;
      }
      // out of the middle of the inside, into the tray, one after another (arms up, flailing)
      const PP = live.current.P;
      const from = { x: G.ix + G.W / 2 - PP / 2 + (Math.random() - 0.5) * G.W * 0.35, y: G.iy + G.H * 0.45 - PP / 2 + (Math.random() - 0.5) * G.H * 0.3, s: 0.75 };
      A.x.setValue(from.x);
      A.y.setValue(from.y);
      A.s.setValue(0.75);
      const delay = n * 85;
      n += 1;
      if (rigs) {
        const to = spotOf(a);
        rig('tumble', R[k], from, to, delay, Math.min(to.y, G.iy) - 60, false);
      }
      later(delay, () => {
        const to = spotOf(a);
        if (!rigs) laterFor(k, 560, () => squash(A, 0.35));
        Animated.parallel([
          Animated.timing(A.o, { toValue: 1, duration: 90, useNativeDriver: true }),
          Animated.timing(A.x, { toValue: to.x, duration: 560, easing: Easing.out(Easing.quad), useNativeDriver: true }),
          Animated.sequence([
            Animated.timing(A.y, { toValue: Math.min(to.y, G.iy) - 60, duration: 230, easing: Easing.out(Easing.quad), useNativeDriver: true }),
            Animated.timing(A.y, { toValue: to.y, duration: 330, easing: Easing.bounce, useNativeDriver: true }),
          ]),
          Animated.timing(A.s, { toValue: live.current.trayScale, duration: 560, useNativeDriver: true }),
        ]).start();
      });
    });
    later(n * 85 + 650, startPlace);
  }, [later, laterFor, rig, setPhase, setRigLive, spotOf, squash, startPlace]);

  const openUp = useCallback(() => {
    setPhase('open');
    sfx.play('fs_doorOpen');
    haptics.place();
    Animated.timing(door, { toValue: 1, duration: 440, easing: Easing.out(Easing.back(1.5)), useNativeDriver: true }).start();
    Animated.sequence([0.9, 0.2, 1, 0.5, 1].map((v, i) => Animated.timing(light, { toValue: v, duration: [90, 60, 90, 50, 120][i], useNativeDriver: true }))).start();
    later(230, tumble);
  }, [door, haptics, later, light, setPhase, tumble]);

  const land = useCallback(() => {
    const G = live.current.g;
    sfx.play('fs_land');
    haptics.place();
    fx.current?.burst('dust', G.bx + 26, G.by + G.bodyH + 8, 1.4);
    fx.current?.burst('dust', G.bx + G.bodyW - 26, G.by + G.bodyH + 8, 1.4);
  }, [haptics]);

  const shake = useCallback(() => {
    setPhase('shake');
    // the doors are shut: the shelves empty out behind them, and the clutter
    // gets knocked about
    setShowInside(false);
    setFoodMoved(true);
    say('SHAKE SHAKE!', { hold: 900 });
    sfx.play('fs_rattle');
    const T = (v, ms, ease = Easing.inOut(Easing.quad)) => (val) => Animated.timing(val, { toValue: v, duration: ms, easing: ease, useNativeDriver: true });
    const rattle = Animated.sequence(
      Array.from({ length: 9 }, (_, i) => {
        const s = i % 2 ? -1 : 1;
        return Animated.parallel([T(s * (3 + i * 0.35), 85)(rot), T(s * 5, 85)(tx)]);
      }).concat([Animated.parallel([T(0, 80)(rot), T(0, 80)(tx)])]),
    );
    const jump = (height, spin) =>
      Animated.sequence([
        Animated.parallel([T(0.6, 90)(sq)]),
        Animated.parallel([T(-height, 250, Easing.out(Easing.quad))(ty), T(-1, 250)(sq), T(spin, 250)(rot)]),
        Animated.parallel([T(0, 210, Easing.in(Easing.quad))(ty), T(0, 210)(sq), T(0, 210)(rot)]),
      ]);
    rattle.start(({ finished }) => {
      if (!finished || !alive.current) return;
      sfx.play('fs_jump');
      jump(34, -5).start(({ finished: f1 }) => {
        if (!f1 || !alive.current) return;
        land();
        Animated.sequence([T(1, 70)(sq), Animated.spring(sq, { toValue: 0, friction: 4, tension: 160, useNativeDriver: true })]).start(({ finished: f2 }) => {
          if (!f2 || !alive.current) return;
          sfx.play('fs_jump', { rate: 1.12 });
          jump(52, 7).start(({ finished: f3 }) => {
            if (!f3 || !alive.current) return;
            land();
            Animated.sequence([T(1, 70)(sq), Animated.spring(sq, { toValue: 0, friction: 3.5, tension: 160, useNativeDriver: true })]).start();
            later(380, openUp);
          });
        });
      });
    });
  }, [land, later, openUp, rot, say, setPhase, sq, tx, ty]);

  const closeUp = useCallback(() => {
    setPhase('close');
    Animated.parallel([
      Animated.timing(door, { toValue: 0, duration: 400, easing: Easing.in(Easing.quad), useNativeDriver: true }),
      Animated.timing(light, { toValue: 0, duration: 380, useNativeDriver: true }),
    ]).start(({ finished }) => {
      if (!finished || !alive.current) return;
      sfx.play('fs_doorClose');
      haptics.place();
      Animated.sequence([
        Animated.timing(sq, { toValue: 0.45, duration: 60, useNativeDriver: true }),
        Animated.spring(sq, { toValue: 0, friction: 4, tension: 180, useNativeDriver: true }),
      ]).start();
      later(320, shake);
    });
  }, [door, haptics, later, light, setPhase, shake, sq]);

  const peek = useCallback(() => {
    const { spec: S, board: B } = live.current;
    setPhase('peek');
    sfx.play('fs_peek');
    say('REMEMBER!', { hold: 700, sub: B.swaps.length ? 'Keep watching until the doors shut!' : null });
    peekBar.setValue(1);
    Animated.timing(peekBar, { toValue: 0, duration: S.peekMs, easing: Easing.linear, useNativeDriver: true }).start();
    const secsN = Math.ceil(S.peekMs / 1000);
    setPeekLeft(secsN);
    for (let s = 1; s < secsN; s++) {
      later(S.peekMs - (secsN - s) * 1000, () => {
        const left = secsN - s;
        setPeekLeft(left);
        if (left <= 3) {
          sfx.play('sd_tick');
          haptics.tick();
        }
      });
    }
    B.swaps.forEach((pair, i) => later(S.peekMs - 450 - (B.swaps.length - i) * 820, () => swapNow(pair)));
    later(S.peekMs, closeUp);
  }, [closeUp, haptics, later, peekBar, say, setPhase, swapNow]);

  const deal = useCallback(() => {
    const B = live.current.board;
    setPhase('deal');
    Animated.timing(clutterIn, { toValue: 1, duration: 260, useNativeDriver: true }).start();
    const seats = Object.keys(B.start)
      .map(Number)
      .sort((a, b) => a - b);
    seats.forEach((slot, n) =>
      later(n * 110, () => {
        Animated.spring(ins[B.start[slot]].s, { toValue: 1, friction: 4, tension: 170, useNativeDriver: true }).start();
        sfx.play('fs_pop', { rate: 0.9 + n * 0.07 });
      }),
    );
    later(seats.length * 110 + 380, peek);
  }, [clutterIn, ins, later, peek, setPhase]);

  // a new deal: reset everything and start
  const readyKey = g ? `${g.S}:${g.bx}:${tg.cell}` : '';
  useEffect(() => {
    if (!g) return undefined;
    clearTimers();
    clk.reset();
    setResult(null);
    setFail(null);
    setPaused(false);
    setSelected(null);
    setDragK(null);
    setBanner(null);
    mistakesRef.current = 0;
    setMistakesState(0);
    setLeft(0);
    setPlay(startState(board));
    setShowInside(true);
    setFoodMoved(false);
    setWinning(false);
    setSad(false);
    // the deal's rigs: sent to the page now, they load through the peek (none if one of them has no rig)
    setRigLive(false);
    castTag.current = `${board.pieces.length}:${Date.now()}`;
    const cast = board.pieces.map((p, k) => ({ id: rids[k], key: keyOf(p.id), P }));
    castMsg.current = cast.every((c) => c.key) ? { list: cast, tag: castTag.current } : null;
    if (castMsg.current) rig('cast', castMsg.current.list, castMsg.current.tag);
    else rig('hideAll');
    clutterIn.setValue(0);
    insideNow.current = { ...board.start };
    door.setValue(1);
    light.setValue(1);
    [rot, tx, ty, sq].forEach((v) => v.setValue(0));
    hover.o.setValue(0);
    pop.setValue(0);
    ins.forEach((a) => a.s.setValue(0));
    Object.entries(board.start).forEach(([slot, k]) => {
      const p = insideXY(Number(slot));
      ins[k].x.setValue(p.x);
      ins[k].y.setValue(p.y);
    });
    anims.forEach((a) => a.o.setValue(0));
    setPhase('intro');
    // a bigger fridge gets its own hello, a new shelf a chip
    const bigger = !blitz && spec.first && spec.lv > 1;
    const chips = [];
    if (bigger) chips.push(`LEVEL ${spec.lv}`);
    chips.push(blitz ? t.name.toUpperCase() : TIER_NAMES[spec.tier]);
    if (spec.more && !blitz) chips.push('+1 SHELF');
    if (spec.decoys) chips.push(`${spec.decoys} IMPOSTOR${spec.decoys > 1 ? 'S' : ''}`);
    if (spec.swaps) chips.push('SNEAKY SWAP');
    if (spec.mixed) chips.push('MIXED UP');
    const sub = `${m.size} · ${m.name.toUpperCase()}`;
    // a Blitz run opens with 3, 2, 1, GO! (the first round's squishies pop in on GO), as the other games' do
    const countdown = blitz && !runStarted.current;
    if (countdown) setCount(null);
    else {
      if (bigger) say('BIGGER FRIDGE!', { chips, sub, small: true, hold: 1400 });
      else say(blitz ? `ROUND ${spec.round}` : `LEVEL ${spec.lv}`, { chips, sub, hold: 900 });
      sfx.play('sd_boardIn');
    }
    Animated.spring(pop, { toValue: 1, friction: 6, tension: 70, useNativeDriver: true }).start();
    let gone = false;
    const t0 = Date.now();
    prefetchImages(board.pieces.map((p) => p.uri), 2500).then(() => {
      if (gone) return;
      if (!countdown) {
        later(Math.max(0, (bigger ? 1800 : 1300) - (Date.now() - t0)), deal);
        return;
      }
      [3, 2, 1, 'GO!'].forEach((v, i) =>
        later(200 + i * 700, () => {
          setCount(v);
          sfx.play(v === 'GO!' ? 'sd_go' : 'sd_count');
          haptics.tick();
          if (v === 'GO!') deal();
        }),
      );
      later(200 + 4 * 700, () => setCount(null));
    });
    return () => {
      gone = true;
    };
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [board, readyKey]);

  // the clock running out (and the time left, by the second)
  useEffect(() => {
    if (phase !== 'place' || paused) return undefined;
    const id = setInterval(() => {
      const ms = clk.limit() - clk.elapsed();
      setLeft((s) => (Math.ceil(ms / 1000) !== s ? Math.ceil(ms / 1000) : s));
      if (ms <= 0) lose('time');
    }, 250);
    return () => clearInterval(id);
  }, [phase, paused, clk, lose]);

  // the rig page is up (send it this deal's squishies), or it has drawn them (or couldn't: a rig's art didn't load)
  const onRigReady = useCallback(() => {
    if (castMsg.current) rig('cast', castMsg.current.list, castMsg.current.tag);
  }, [rig]);
  const onRigCast = useCallback((msg) => {
    if (msg.ok) rigTag.current = msg.tag;
    else console.warn('[sort rig] no rig for', msg.key, '- the stills instead');
  }, []);
  // the mixed-up ones (on a shelf, not home) look round, puzzled, one at a time now and then
  useEffect(() => {
    if (phase !== 'place' || !rigLive || paused) return undefined;
    let n = 0;
    const id = setInterval(() => {
      const st = playRef.current;
      const ks = board.pieces.map((_, k) => k).filter((k) => !st.gone[k] && !st.locked[k] && st.at[k].kind === 'slot' && k !== selectedRef.current && !(touch.current && touch.current.k === k));
      if (ks.length) rig('huh', rids[ks[n++ % ks.length]]);
    }, 2600);
    return () => clearInterval(id);
  }, [phase, rigLive, paused, board, rids, rig]);
  // web, development only: the browser tests play without finding the squishies on screen (src/web/README.md)
  if (__DEV__ && typeof window !== 'undefined' && window.document) {
    const center = (loc) => (loc.kind === 'slot' ? slotCenter(g, loc.i) : trayCenter(tg, loc.i));
    window.__sort = {
      state: () => ({ phase: phaseRef.current, rigLive: rigLiveRef.current, pieces: board.pieces.map((p, k) => ({ k, home: p.home, at: playRef.current.at[k], locked: !!playRef.current.locked[k], gone: !!playRef.current.gone[k] })) }),
      // a drop of piece k on spot i (or the tray: i < 0), as a drag lets go there
      drop: (k, i) => handleDrop(k, i < 0 ? { kind: 'tray' } : { kind: 'slot', i }, i < 0 ? null : slotCenter(g, i)),
      // a drag: picked up, then moved to (x, y) (the play area's); drop() lets go
      grab: (k) => {
        const c = center(playRef.current.at[k]);
        grab(k);
        dragTo(k, c.x, c.y + g.S * 0.42);
      },
      drag: (k, x, y) => dragTo(k, x, y),
      tap: (k) => setSelected(selectedRef.current === k ? null : k),
      // every squishy home but one (`leave`), or all of them
      solve: (leave = -1) => board.pieces.forEach((p, k) => p.home != null && k !== leave && !playRef.current.locked[k] && handleDrop(k, { kind: 'slot', i: p.home }, slotCenter(g, p.home))),
    };
  }

  // --- pause and leaving ---------------------------------------------------------------

  const pause = useCallback(() => {
    if (phaseRef.current !== 'place' || pausedRef.current) return;
    clk.pause();
    setPaused(true);
  }, [clk, setPaused]);
  const resume = useCallback(() => {
    setPaused(false);
    clk.resume();
  }, [clk, setPaused]);
  const leave = useCallback(() => {
    payOut();
    clearTimers();
    clk.reset();
    onExit();
  }, [clearTimers, clk, onExit, payOut]);
  useEffect(() => {
    const sub = BackHandler.addEventListener('hardwareBackPress', () => {
      if (pausedRef.current) resume();
      else if (phaseRef.current === 'place') pause();
      else if (blitzCardRef.current === 'save') endRun();
      else if (phaseRef.current === 'held') return true;
      else leave();
      return true;
    });
    return () => sub.remove();
  }, [endRun, leave, pause, resume]);
  useEffect(() => {
    const sub = AppState.addEventListener('change', (s) => s !== 'active' && pause());
    return () => sub.remove();
  }, [pause]);

  const next = useCallback(() => {
    setLv((l) => Math.min(LEVELS, l + 1));
    setRound((r) => r + 1);
  }, []);
  const replay = useCallback(() => setRound((r) => r + 1), []);
  // Blitz: a fresh run from round 1 (the one before is paid out first)
  const again = useCallback(() => {
    payOut();
    clearTimers();
    clk.reset();
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
    setLeft(0);
    setPaused(false);
    setIdx(0);
    setRun((r) => r + 1);
  }, [clearTimers, clk, payOut, setPaused]);

  // --- drawing ---------------------------------------------------------------------------

  const food = foodMoved ? board.foodAfter : board.foodBefore;
  const clutter = g
    ? Object.entries(food).map(([slot, kind]) => {
        const i = Number(slot);
        const tilt = ((i * 37) % 13) - 6;
        const dx = (((i * 53) % 9) - 4) * (g.S / 90);
        return (
          <Animated.View
            key={`f${slot}`}
            style={[styles.prop, { left: (i % g.cols) * g.S + (g.S - Q) / 2 + dx, top: Math.floor(i / g.cols) * (g.S + SHELF) + g.S - Q, width: Q, height: Q, opacity: clutterIn, transform: [{ rotate: `${tilt}deg` }] }]}
          >
            <Prop kind={kind} size={Q} />
          </Animated.View>
        );
      })
    : null;
  // (and the win's wave behind the shutting doors, when the stills play the deal: squashed and stretched about their
  // feet)
  const shown =
    g && (showInside || (winning && !rigLive))
      ? Object.values(board.start).map((k) => (
          <Animated.Image
            key={k}
            source={{ uri: board.pieces[k].uri }}
            resizeMode="contain"
            fadeDuration={0}
            style={[
              styles.insideImg,
              {
                width: P,
                height: P,
                transform: [
                  { translateX: ins[k].x },
                  { translateY: ins[k].y },
                  { translateY: ins[k].hop },
                  { scale: ins[k].s },
                  { translateY: P / 2 },
                  { scaleX: ins[k].sq.interpolate({ inputRange: [-1, 0, 1], outputRange: [0.84, 1, 1.22] }) },
                  { scaleY: ins[k].sq.interpolate({ inputRange: [-1, 0, 1], outputRange: [1.2, 1, 0.78] }) },
                  { translateY: -P / 2 },
                ],
              },
            ]}
          />
        ))
      : null;
  const insidePieces = (
    <>
      {clutter}
      {shown}
    </>
  );

  const order = board.pieces.map((_, k) => k).sort((a, b) => (a === dragK || a === selected ? 1 : 0) - (b === dragK || b === selected ? 1 : 0));
  // the squishies in play show from the tumble on (hidden behind the shut doors before)
  const inPlay = !showInside && phase !== 'shake' && phase !== 'close';
  // mixed up: still on a shelf but not home, while sorting
  const mixedAt = (k) => phase === 'place' && !play.gone[k] && play.at[k].kind === 'slot' && !play.locked[k];
  const wrapTransform = g
    ? [
        { translateX: tx },
        { translateY: ty },
        { translateY: sq.interpolate({ inputRange: [-1, 0, 1], outputRange: [-g.bodyH * 0.035, 0, g.bodyH * 0.05] }) },
        { rotate: rot.interpolate({ inputRange: [-10, 10], outputRange: ['-10deg', '10deg'] }) },
        { scaleX: sq.interpolate({ inputRange: [-1, 0, 1], outputRange: [0.95, 1, 1.09] }) },
        { scaleY: sq.interpolate({ inputRange: [-1, 0, 1], outputRange: [1.07, 1, 0.9] }) },
        { scale: pop.interpolate({ inputRange: [0, 1], outputRange: [0.6, 1] }) },
      ]
    : [];
  const hearts = Array.from({ length: HEARTS }, (_, i) => i < HEARTS - mistakes);

  // (as Squish Hop's and Squishdoku's, 2026-11-17, the user: "make sure the screens of squish sort matches the other
  // game's screen"): the round back button (Blitz: pause while sorting), the fridge's name and the tier; then the glass
  // with the hearts (Blitz, as Squish Hop's: the rounds cleared, the best run and the rule) and one bar: the peek's
  // countdown, then the clock (Blitz: the round's)
  const placing = phase === 'place';
  const peeking = phase === 'peek' || phase === 'deal';
  const timeLabel = clock(left > 0 ? left * 1000 : spec.limitMs);
  // Blitz: the best run so far, and whether this one has beaten it
  const bestRun = record(profile).blitz.top;
  const beat = blitz && cleared > bestRun && bestRun > 0;
  const barW = 186;
  const topEl = (
    <>
      <View style={styles.hud}>
        <CribButton face="orange" icon={blitz && placing ? 'pause' : 'back'} size={44} onPress={() => (phaseRef.current === 'place' ? pause() : leave())} />
        <View style={styles.titleBox}>
          <RoomTitle title={blitz ? 'Blitz Mode' : m.name} />
          {blitz ? null : (
            <View style={styles.subRow}>
              <View style={[styles.tier, { backgroundColor: TIER_COLORS[spec.tier] }]}>
                <Text style={styles.tierText}>{TIER_NAMES[spec.tier]}</Text>
              </View>
            </View>
          )}
        </View>
      </View>
      <View style={styles.glass}>
        {blitz ? (
          <>
            <View style={styles.pills}>
              <View style={styles.pill}>
                <Text style={styles.pillText}>{`CLEARED ${cleared}`}</Text>
              </View>
              <View style={[styles.pill, styles.bestPill, beat && styles.newBest]}>
                <Text style={[styles.pillText, { color: beat ? '#ffffff' : '#5b3a29' }]}>{`${beat ? 'NEW BEST' : 'BEST'} ${Math.max(bestRun, cleared)}`}</Text>
              </View>
            </View>
            <Chip bg="#e01e4a" color="#ffffff">
              1 MISTAKE = GAME OVER
            </Chip>
          </>
        ) : (
          <View style={styles.hearts}>
            {hearts.map((on, i) => (
              <Heart key={i} on={on} size={26} empty="rgba(255,255,255,0.28)" />
            ))}
          </View>
        )}
        <View style={styles.barRow}>
          <BarIcon eye={peeking} />
          <TimerBar frac={peeking ? peekBar : clk.frac} width={barW} warn={placing && left <= 10} label={phase === 'peek' ? String(peekLeft) : phase === 'deal' ? ' ' : timeLabel} />
        </View>
      </View>
    </>
  );
  const areaEl = (
    // the play area: everything is placed by geometry() and trayGeo()
      <View ref={areaRef} style={styles.area} onLayout={onArea} {...responder.panHandlers}>
        {g ? (
          <>
            {/* the tray */}
            {/* the tray they tumble onto: the same glass as the panel (no COUNTER label since 2026-11-17) */}
            <View pointerEvents="none" style={[styles.tray, { left: tg.tx, top: tg.ty, width: tg.tw, height: tg.th }]}>
              {Array.from({ length: board.trayCap }, (_, j) => {
                const c = trayCenter(tg, j);
                return <View key={j} style={[styles.traySpot, { left: c.x - tg.tx - 2 - tg.cell * 0.36, top: c.y - tg.ty - 2 + tg.cell * 0.22, width: tg.cell * 0.72, height: tg.cell * 0.2 }]} />;
              })}
            </View>
            {/* the container, shaking as one */}
            <Animated.View pointerEvents="none" style={[styles.wrap, { left: g.bx, top: g.by, transform: wrapTransform }]}>
              <Container m={m} g={g} door={door} light={light} inside={insidePieces} slots={false} />
            </Animated.View>
            {/* the spot under a dragged squishy */}
            <Animated.View pointerEvents="none" style={[styles.hover, { width: g.S, height: g.S, borderRadius: g.S * 0.24, opacity: hover.o, transform: [{ translateX: hover.x }, { translateY: hover.y }] }]} />
            {/* the squishies in play: their stills (at the win, only the impostors: the rest wave inside, under the
                doors); with the rigs drawing them, only the chosen one's ring, under the rigs */}
            {inPlay
              ? order.map((k) => {
                  if (rigLive) return selected === k && !winning ? <Piece key={k} part="under" uri={board.pieces[k].uri} size={P} a={anims[k]} selected /> : null;
                  if (winning && board.pieces[k].home != null) return null;
                  return (
                    <Piece
                      key={k}
                      uri={board.pieces[k].uri}
                      size={P}
                      a={anims[k]}
                      mixed={mixedAt(k)}
                      selected={selected === k}
                      locked={!!play.locked[k]}
                      held={selected === k || dragK === k}
                      sad={sad && !play.gone[k]}
                    />
                  );
                })
              : null}
            {/* the squishies as the design's live rigs (the page loads as soon as the play area is laid out) */}
            <RigStage ref={stage} page="sort" calls={RIG_CALLS} style={StyleSheet.absoluteFill} paused={paused} onReady={onRigReady} onCast={onRigCast} />
            {/* their ? and ✓ marks, over the rigs */}
            {inPlay && rigLive && !winning
              ? order.map((k) => (mixedAt(k) || play.locked[k] ? <Piece key={`o${k}`} part="over" uri={board.pieces[k].uri} size={P} a={anims[k]} mixed={mixedAt(k)} locked={!!play.locked[k]} /> : null))
              : null}
            <Banner banner={banner} top={Math.max(0, g.by - 34)} />
            <FxLayer ref={fx} />
          </>
        ) : null}
        {count != null ? <Countdown value={count} /> : null}
      </View>
  );
  return (
    <View style={styles.fill} onLayout={onRoot}>
      {/* the fridge stands in the Crib's kitchen (as Squish Hop's levels stand in its rooms) */}
      {root ? <Room room="kitchen" phase="day" width={root.w} height={root.h} /> : null}
      {/* (REDESIGN_V8) the top bar and the glass in a column on the left, the play area beside it */}
      <View style={styles.row}>
        <View style={styles.left}>{topEl}</View>
        {areaEl}
      </View>

      {blitz ? (
        <>
          <PauseCard visible={paused} onResume={resume} onQuit={leave} />
          {/* the other games' save and GAME OVER cards (squishdoku/Overlays.js) */}
          <BlitzSaveCard
            visible={blitzCard === 'save'}
            unit="round"
            reason={failReason}
            board={idx + 1}
            cleared={cleared}
            adUsed={adUsed}
            adReady={!!ad?.ready}
            adsFree={adsFree}
            gems={Number(profile && profile.gems) || 0}
            price={blitzSaveGems(gemSaves)}
            saving={saving}
            error={saveErr}
            onAd={saveByAd}
            onGems={saveByGems}
            onEnd={endRun}
          />
          <BlitzOverCard visible={blitzCard === 'over'} unit="round" res={over} onAgain={again} onQuit={leave} />
          <FxLayer ref={fxTop} style={styles.fxTop} />
        </>
      ) : (
        <>
          <ResultCard visible={!!result} res={result} titles={RESULT_TITLES} keys={trio} last={lv >= LEVELS} onNext={next} onReplay={replay} onBack={leave} />
          <FailCard visible={!!fail} reason={fail?.reason} uri={board.pieces[0]?.uri} onRetry={replay} onHub={leave} />
          <PauseCard visible={paused} onResume={resume} onQuit={leave} />
        </>
      )}
      {phase === 'load' ? <PopIn style={styles.loading}><Text style={styles.loadingText}>Getting the squishies…</Text></PopIn> : null}
    </View>
  );
}

const GLASS = 'rgba(91,58,41,0.75)';
const styles = StyleSheet.create({
  fill: { flex: 1 },
  // the top bar and the glass, as Squish Hop's (hop/Game.js)
  hud: { flexDirection: 'row', alignItems: 'center', gap: 8, zIndex: 3 },
  titleBox: { flex: 1, minWidth: 0 },
  subRow: { flexDirection: 'row', alignItems: 'center', gap: 6, marginTop: -2 },
  tier: { paddingHorizontal: 6, borderRadius: 999, borderWidth: 2, borderColor: '#ffffff' },
  tierText: { fontFamily: F.display, fontSize: 9.5, letterSpacing: 0.6, color: '#ffffff' },
  glass: { alignItems: 'center', gap: 8, marginTop: 4, paddingHorizontal: 10, paddingVertical: 9, borderRadius: 20, backgroundColor: GLASS, borderWidth: 2, borderColor: 'rgba(255,255,255,0.9)', zIndex: 1 },
  hearts: { flexDirection: 'row', gap: 4 },
  // Blitz: the rounds cleared and the best run (Squish Hop's pills; the best in orange once it's beaten)
  pills: { flexDirection: 'row', alignItems: 'center', gap: 6 },
  pill: { paddingHorizontal: 8, paddingVertical: 1, borderRadius: 999, backgroundColor: '#ffffff', borderWidth: 2.5, borderColor: '#ffd23a' },
  bestPill: { borderColor: '#ffe6b8' },
  newBest: { backgroundColor: '#ffb02e', borderColor: '#ffffff' },
  pillText: { fontFamily: F.display, fontSize: 12, color: '#b86200', letterSpacing: 0.5, fontVariant: ['tabular-nums'], includeFontPadding: false },
  // the cards sit at elevation 50 (squishdoku/Overlays.js)
  fxTop: { zIndex: 60, elevation: 60 },
  barRow: { flexDirection: 'row', alignItems: 'center', gap: 6 },
  track: { flex: 1, height: 14, borderRadius: 7, backgroundColor: 'rgba(69,16,122,0.18)', borderWidth: 2, borderColor: '#ffffff', overflow: 'hidden' },
  trackShine: { position: 'absolute', left: 4, right: 4, top: 1.5, height: 3, borderRadius: 2, backgroundColor: 'rgba(255,255,255,0.6)' },
  area: { flex: 1 },
  row: { flex: 1, flexDirection: 'row' },
  left: { width: 240, paddingTop: 8, paddingLeft: 10, gap: 8, zIndex: 3 },
  wrap: { position: 'absolute' },
  insideImg: { position: 'absolute', left: 0, top: 0 },
  prop: { position: 'absolute' },
  tray: { position: 'absolute', borderRadius: 20, backgroundColor: GLASS, borderWidth: 2, borderColor: 'rgba(255,255,255,0.9)' },
  traySpot: { position: 'absolute', borderRadius: 999, backgroundColor: 'rgba(255,255,255,0.13)' },
  hover: { position: 'absolute', left: 0, top: 0, borderWidth: 3, borderColor: '#ffd23a', backgroundColor: 'rgba(255,230,120,0.28)' },
  piece: { position: 'absolute', left: 0, top: 0, alignItems: 'center', justifyContent: 'center' },
  pieceImg: { width: '100%', height: '100%' },
  pieceShadow: { position: 'absolute', bottom: '0%', width: '74%', height: '14%' },
  selRing: { position: 'absolute', left: '4%', right: '4%', top: '4%', bottom: '4%', borderRadius: 999, borderWidth: 3, borderColor: '#ffd23a', backgroundColor: 'rgba(255,240,150,0.35)' },
  sweat: { position: 'absolute', top: '6%', right: '10%', backgroundColor: '#8fd3ff', borderWidth: 1.2, borderColor: '#ffffff' },
  huh: { position: 'absolute', top: -4, right: -2, width: 22, height: 22, borderRadius: 11, backgroundColor: '#ff8a3d', borderWidth: 2, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  huhText: { fontFamily: F.display, fontSize: 13, color: '#ffffff', includeFontPadding: false },
  tick: { position: 'absolute', bottom: 2, right: 2, width: 20, height: 20, borderRadius: 10, backgroundColor: '#26a94e', borderWidth: 2, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  banner: { position: 'absolute', left: 0, right: 0, alignItems: 'center' },
  bannerText: { fontFamily: F.display, fontSize: 40, color: '#ffffff', textAlign: 'center', includeFontPadding: false },
  bannerSub: { marginTop: 6, paddingHorizontal: 12, paddingVertical: 4, borderRadius: 999, backgroundColor: 'rgba(69,16,122,0.8)', fontFamily: F.display, fontSize: 13, color: '#ffffff', overflow: 'hidden' },
  chips: { flexDirection: 'row', flexWrap: 'wrap', justifyContent: 'center', gap: 6, marginTop: 8, paddingHorizontal: 20 },
  chip: { paddingHorizontal: 9, paddingVertical: 3, borderRadius: 999, backgroundColor: '#e01e4a', borderWidth: 2, borderColor: '#ffffff' },
  chipText: { fontFamily: F.display, fontSize: 12, letterSpacing: 0.6, color: '#ffffff' },
  loading: { position: 'absolute', alignSelf: 'center', top: '45%' },
  loadingText: { fontFamily: F.display, fontSize: 16, color: INK },
});
