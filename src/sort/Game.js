import React, { memo, useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { Animated, AppState, BackHandler, Easing, Image, PanResponder, StyleSheet, Text, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Defs, Ellipse, Path, RadialGradient, Stop } from 'react-native-svg';
import RoundButton, { BackGlyph } from '../components/candy/RoundButton';
import ShadowText, { outline3 } from '../components/candy/ShadowText';
import useRewardedAd from '../components/useRewardedAd';
import sfx from '../audio/sfx';
import { FxLayer, PopIn } from '../squishdoku/fx';
import { makeHaptics, pickCreatures, prefetchImages, useClock } from '../squishdoku/game';
import { Pips } from '../squishdoku/Hud';
import { BlitzFailCard, BlitzWinCard, PauseCard as BlitzPauseCard, ReviveCard } from '../squishdoku/Overlays';
import { Chip } from '../squishdoku/ui';
import { saveSort } from '../firebase/firestore';
import Container, { SHELF, geometry, slotAt, slotCenter } from './Container';
import { FailCard, PauseCard, ResultCard } from './Cards';
import { drop as dropRule, makeBoard, solved, startState } from './board';
import { BLITZ_MS, BLITZ_ROUNDS, HEARTS, LEVELS, TIER_COLORS, TIER_NAMES, afterBlitz, afterLevel, blitzSpec, blitzTheme, clock, levelSpec, record } from './levels';
import { modelOf } from './models';
import { KINDS, Prop } from './props';
import { THEMES } from './themes';
import { F, INK } from '../squishdoku/theme';
import { useKeyLoop, usePingPong } from '../components/idleLoop';

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
// Blitz (`SortBlitz`, levels.js BLITZ_*): ten rounds, the fridge and the
// cupboard taking turns (`pools` has both), on one clock that runs only in
// `place`. One mistake ends the run, unless the run's one revive is used.

const LOAD_SOUNDS = ['fs_pop', 'fs_peek', 'fs_doorClose', 'fs_doorOpen', 'fs_rattle', 'fs_jump', 'fs_land', 'fs_tumble', 'fs_pick', 'fs_drop', 'fs_snap', 'fs_wrong', 'fs_impostor', 'fs_swap', 'fs_heart', 'fs_mixed', 'sd_tick', 'sd_solve', 'sd_confetti', 'sd_boardIn'];

// the tray: one row up to 6, else two
function trayGeo(w, h, cap) {
  const perRow = cap > 6 ? Math.ceil(cap / 2) : Math.max(cap, 4);
  const rows = cap > 6 ? 2 : 1;
  const cell = Math.floor(Math.min(58, (w - 48) / perRow));
  const tw = perRow * cell + 24;
  const th = rows * cell + 26;
  return { cell, perRow, rows, tw, th, tx: Math.round((w - tw) / 2), ty: h - th - 6 };
}
const trayCenter = (tg, j) => ({ x: tg.tx + 12 + (j % tg.perRow) * tg.cell + tg.cell / 2, y: tg.ty + 15 + Math.floor(j / tg.perRow) * tg.cell + tg.cell / 2 });

// --- a squishy -----------------------------------------------------------------------

// a mixed-up squishy's wobble: right, left, back (650 ms), then a rest
// (900 ms), as one native loop (src/components/idleLoop.js)
const WOB_AT = [0, 0.084, 0.168, 0.252, 0.335, 0.377, 0.419, 1];
const WOB_VALUES = [0, 0.71, 1, 0, -1, -0.5, 0, 0];

const Piece = memo(function Piece({ uri, size, a, mixed, selected, locked }) {
  const wob = useKeyLoop(1550, { at: WOB_AT, values: WOB_VALUES, on: mixed });
  const pulse = usePingPong(840, { on: selected });
  const rotate = wob.interpolate({ inputRange: [-1, 1], outputRange: ['-9deg', '9deg'] });
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
            { rotate },
          ],
        },
      ]}
    >
      {/* a soft floor shadow, smaller while lifted */}
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
      {selected ? <View style={styles.selRing} /> : null}
      <Image source={{ uri }} style={styles.pieceImg} resizeMode="contain" fadeDuration={0} />
      {mixed ? (
        <View style={styles.huh}>
          <Text style={styles.huhText}>?</Text>
        </View>
      ) : null}
      {locked ? (
        <Animated.View style={[styles.tick, { opacity: a.tick, transform: [{ scale: a.tick }] }]}>
          <Svg width={12} height={10} viewBox="0 0 12 10">
            <Path d="M1.5 5 L4.5 8 L10.5 2" stroke="#ffffff" strokeWidth={2.4} fill="none" strokeLinecap="round" strokeLinejoin="round" />
          </Svg>
        </Animated.View>
      ) : null}
    </Animated.View>
  );
});

// the hearts in the corner; a lost one pops and greys
const HEART_D = 'M12 21 C5 15.5 2 12 2 7.8 C2 4.6 4.4 2.5 7.2 2.5 C9.2 2.5 11 3.6 12 5.4 C13 3.6 14.8 2.5 16.8 2.5 C19.6 2.5 22 4.6 22 7.8 C22 12 19 15.5 12 21 Z';
const Heart = memo(function Heart({ on }) {
  const t = useRef(new Animated.Value(on ? 1 : 0)).current;
  useEffect(() => {
    if (on) t.setValue(1);
    else Animated.sequence([Animated.timing(t, { toValue: 1.6, duration: 120, useNativeDriver: true }), Animated.spring(t, { toValue: 0, friction: 5, tension: 120, useNativeDriver: true })]).start();
  }, [on, t]);
  return (
    <View style={styles.heartBox}>
      <Svg width={24} height={24} viewBox="0 0 24 24" style={StyleSheet.absoluteFill}>
        <Path d={HEART_D} fill="rgba(69,16,122,0.22)" stroke="#ffffff" strokeWidth={2} />
      </Svg>
      <Animated.View style={[StyleSheet.absoluteFill, { opacity: t.interpolate({ inputRange: [0, 0.3, 1.6], outputRange: [0, 1, 1], extrapolate: 'clamp' }), transform: [{ scale: t.interpolate({ inputRange: [0, 1, 1.6], outputRange: [0.4, 1, 1.35], extrapolate: 'clamp' }) }] }]}>
        <Svg width={24} height={24} viewBox="0 0 24 24">
          <Path d={HEART_D} fill="#ff4d7d" stroke="#ffffff" strokeWidth={2} />
          <Path d="M6.5 7 C7 5.6 8.2 5 9.2 5.2" stroke="#ffd6e4" strokeWidth={1.6} strokeLinecap="round" fill="none" />
        </Svg>
      </Animated.View>
    </View>
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

// Blitz: the game with a rewarded ad kept loaded for the revive.
export function SortBlitz(props) {
  const ad = useRewardedAd();
  return <SortGame {...props} blitz ad={ad} />;
}

export default function SortGame({ theme: themeProp, startLv, pool: poolProp, pools, blitz = false, ad, adsFree = false, profile, uid, haptics: hapticsOn = true, onExit }) {
  const haptics = useRef(makeHaptics(hapticsOn)).current;
  const [lv, setLv] = useState(startLv);
  const [round, setRound] = useState(0);
  // Blitz: the run, its round, the rounds done (the pips), the revive, and
  // which of its cards is up
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
  const runStarted = useRef(false);
  const theme = blitz ? blitzTheme(idx) : themeProp;
  const t = THEMES[theme];
  const pool = blitz ? pools[theme] : poolProp;
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
  const [area, setArea] = useState(null);
  const areaRef = useRef(null);
  const origin = useRef({ x: 0, y: 0 });
  const onArea = useCallback((e) => {
    const { width, height } = e.nativeEvent.layout;
    if (width > 0 && height > 0) setArea((a) => (a && a.w === width && a.h === height ? a : { w: width, h: height }));
    areaRef.current?.measure((x, y, w, h, px, py) => (origin.current = { x: px, y: py }));
  }, []);
  const tg = useMemo(() => (area ? trayGeo(area.w, area.h, board.trayCap) : null), [area, board]);
  // the level's fridge or cupboard, small to very very large (models.js)
  const m = modelOf(theme, spec.model);
  const g = useMemo(() => (area ? geometry({ w: area.w, h: area.h, rows: spec.rows, cols: spec.cols, model: m, trayH: tg.th + 6 }) : null), [area, spec, m, tg]);
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
  const ins = useMemo(() => board.pieces.map(() => ({ x: new Animated.Value(0), y: new Animated.Value(0), s: new Animated.Value(0) })), [board]);
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
      })),
    [board],
  );
  const fx = useRef(null);
  const clk = useClock();

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
  const setSelected = useCallback((k) => {
    selectedRef.current = k;
    setSelectedState(k);
  }, []);
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
    sfx.preload(LOAD_SOUNDS);
    return () => {
      alive.current = false;
      clearTimers();
    };
  }, [clearTimers]);

  // refs the touch handlers read
  const live = useRef({});
  live.current = { board, g, tg, P, trayScale, anims, spec };
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

  // Blitz: the run's over (a mistake with the revive used or turned down, or
  // the clock), back to round 1
  const endRun = useCallback(
    (reason) => {
      setPhase('lost');
      clk.pause();
      setSelected(null);
      hover.o.setValue(0);
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
      if (uid) saveSort(uid, out.update, 0);
    },
    [clk, haptics, hover.o, later, setPhase, setSelected, uid],
  );

  const lose = useCallback(
    (reason) => {
      if (phaseRef.current !== 'place') return;
      if (blitz) {
        endRun(reason);
        return;
      }
      setPhase('lost');
      clk.pause();
      setSelected(null);
      hover.o.setValue(0);
      sfx.play(reason === 'time' ? 'sd_timeUp' : 'sd_blitzFail');
      haptics.wrong();
      // show where they all belonged
      const { board: B } = live.current;
      B.pieces.forEach((p, k) => {
        if (playRef.current.gone[k]) return;
        const A = live.current.anims[k];
        if (p.home == null) {
          Animated.parallel([Animated.timing(A.o, { toValue: 0, duration: 300, useNativeDriver: true }), Animated.timing(A.s, { toValue: 0.2, duration: 300, useNativeDriver: true })]).start();
        } else if (!playRef.current.locked[k]) later(200 + k * 70, () => fly(k, { kind: 'slot', i: p.home }, { hop: 30 }));
      });
      const out = afterLevel(profile, theme, live.current.spec, { won: false, mistakes: mistakesRef.current });
      if (uid) saveSort(uid, out.update, 0);
      later(1700, () => setFail({ reason }));
    },
    [blitz, clk, endRun, fly, haptics, hover.o, later, profile, setPhase, setSelected, theme, uid],
  );

  const win = useCallback(() => {
    setPhase('won');
    clk.pause();
    setSelected(null);
    hover.o.setValue(0);
    const { board: B, g: G } = live.current;
    // impostors still in the tray: poof
    B.pieces.forEach((p, k) => {
      if (p.home != null || playRef.current.gone[k]) return;
      const A = live.current.anims[k];
      const c = trayCenter(live.current.tg, playRef.current.at[k].i);
      fx.current?.burst('poof', c.x, c.y, 1);
      Animated.parallel([Animated.timing(A.o, { toValue: 0, duration: 260, useNativeDriver: true }), Animated.timing(A.s, { toValue: 0.1, duration: 260, useNativeDriver: true })]).start();
    });
    sfx.play('sd_solve');
    haptics.win();
    // a hop wave along the shelves, the lamp flashing, confetti
    B.pieces.forEach((p, k) => {
      if (p.home == null) return;
      const A = live.current.anims[k];
      later(150 + p.home * 60, () =>
        Animated.sequence([
          Animated.timing(A.hop, { toValue: -G.S * 0.28, duration: 170, easing: Easing.out(Easing.quad), useNativeDriver: true }),
          Animated.timing(A.hop, { toValue: 0, duration: 200, easing: Easing.bounce, useNativeDriver: true }),
        ]).start(),
      );
    });
    Animated.sequence([0.4, 1, 0.5, 1].map((v) => Animated.timing(light, { toValue: v, duration: 110, useNativeDriver: true }))).start();
    later(250, () => {
      sfx.play('sd_confetti');
      fx.current?.burst('confetti', G.ix + G.W / 2, G.iy + G.H * 0.3, 1.2);
    });
    later(650, () => fx.current?.burst('confetti', G.ix + G.W * 0.25, G.iy + G.H * 0.5, 1));
    later(800, () => fx.current?.burst('confetti', G.ix + G.W * 0.75, G.iy + G.H * 0.5, 1));
    if (blitz) {
      // a pip fills; on to the next round, or the run is won
      const i = idxRef.current;
      later(300, () => {
        setDone(i + 1);
        sfx.play('sd_pip', { rate: 0.9 + i * 0.06 });
      });
      if (i < BLITZ_ROUNDS - 1) {
        later(1500, () => {
          sfx.play('sd_blitzNext');
          setIdx(i + 1);
        });
        return;
      }
      later(1100, () => {
        const ms = clk.elapsed();
        const rec = record(profileRef.current);
        const out = afterBlitz(profileRef.current, { won: true, reached: BLITZ_ROUNDS, ms });
        if (uid) saveSort(uid, out.update, out.coins, out.xp, profileRef.current);
        const all = [...(pools.fridge || []), ...(pools.cupboard || [])].map((p) => p.uri);
        setBlitzWin({ ...out, ms, newBest: !rec.blitz.bestMs || ms < rec.blitz.bestMs, uris: pickCreatures(all, 3) });
        setBlitzCard('win');
        sfx.play('sd_blitzWin');
        haptics.win();
      });
      return;
    }
    const out = afterLevel(profile, theme, live.current.spec, { won: true, mistakes: mistakesRef.current, ms: clk.elapsed() });
    if (uid) saveSort(uid, out.update, out.coins, out.xp, profile);
    const ms = clk.elapsed();
    const { stars, coins, xp, before, after, levelUps, unlocked } = out;
    later(1500, () => setResult({ stars, coins, xp, before, after, levelUps, mistakes: mistakesRef.current, ms, unlocked }));
  }, [blitz, clk, haptics, hover.o, later, light, pools, profile, setPhase, setSelected, theme, uid]);

  const mistake = useCallback(() => {
    mistakesRef.current += 1;
    setMistakesState(mistakesRef.current);
    haptics.wrong();
    if (blitz) {
      // Blitz: one mistake and the clock stops; the revive, or the run's over
      clk.pause();
      setPhase('held');
      setSelected(null);
      later(800, () => {
        if (revivedRef.current) endRun('mistake');
        else setBlitzCard('revive');
      });
      return;
    }
    later(160, () => sfx.play('fs_heart'));
    if (mistakesRef.current >= HEARTS) later(500, () => lose('hearts'));
  }, [blitz, clk, endRun, haptics, later, lose, setPhase, setSelected]);

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
      if (r.outcome === 'lock') {
        fly(k, r.state.at[k], { bounce: 5 });
        const c = slotCenter(live.current.g, target.i);
        fx.current?.burst('spark', c.x, c.y, 1.1);
        sfx.play('fs_snap');
        haptics.place();
        A.tick.setValue(0);
        Animated.sequence([Animated.spring(A.tick, { toValue: 1, friction: 4, tension: 160, useNativeDriver: true })]).start();
        if (r.bumped != null) {
          later(120, () => {
            fly(r.bumped, r.state.at[r.bumped], { hop: 26 });
            sfx.play('fs_drop');
          });
        }
        if (solved(B, r.state)) later(450, win);
      } else if (r.outcome === 'wrong') {
        sfx.play('fs_wrong');
        if (at) fx.current?.burst('angry', at.x, at.y, 1);
        fly(k, from, { hop: 22 });
        A.shake.setValue(0);
        Animated.sequence([10, -9, 7, -5, 3, 0].map((v) => Animated.timing(A.shake, { toValue: v, duration: 50, useNativeDriver: true }))).start();
        mistake();
      } else if (r.outcome === 'impostor') {
        sfx.play('fs_impostor');
        say('IMPOSTOR!', { ink: '#8e1030', small: true, hold: 500, sub: 'It was never inside!' });
        const c = at || spotOf(from);
        later(380, () => fx.current?.burst('poof', c.x, c.y, 1.2));
        Animated.sequence([
          Animated.timing(A.s, { toValue: 1.3, duration: 160, useNativeDriver: true }),
          Animated.parallel([Animated.timing(A.s, { toValue: 0, duration: 260, easing: Easing.in(Easing.back(2)), useNativeDriver: true }), Animated.timing(A.o, { toValue: 0, duration: 260, useNativeDriver: true })]),
        ]).start();
        mistake();
      } else {
        fly(k, r.state.at[k]);
        sfx.play('fs_drop');
      }
    },
    [fly, haptics, hover.o, later, mistake, say, setPlay, setSelected, spotOf, win],
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

  const touch = useRef(null);
  const handlers = useRef({});
  handlers.current = { hitPiece, targetAt, handleDrop, showHover, setSelected, haptics };
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
          const { anims: AS, P: PP, g: G } = live.current;
          if (!T.moved) {
            if (Math.hypot(p.x - T.x0, p.y - T.y0) < 9) return;
            T.moved = true;
            setDragK(T.k);
            handlers.current.setSelected(null);
            sfx.play('fs_pick');
            handlers.current.haptics.tap();
            Animated.parallel([
              Animated.spring(AS[T.k].s, { toValue: 1.06, friction: 6, tension: 160, useNativeDriver: true }),
              Animated.timing(AS[T.k].lift, { toValue: 1, duration: 120, useNativeDriver: true }),
            ]).start();
          }
          // held a little above the finger, so it can be seen
          AS[T.k].x.setValue(p.x - PP / 2);
          AS[T.k].y.setValue(p.y - PP / 2 - G.S * 0.42);
          handlers.current.showHover(p.x, p.y - G.S * 0.42);
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
    const S = live.current.spec;
    const notes = [];
    if (S.decoys) notes.push(`${S.decoys} impostor${S.decoys > 1 ? 's' : ''} snuck in!`);
    if (S.mixed) notes.push('Some got mixed up inside!');
    say('PUT THEM BACK!', { small: true, sub: notes.join('  ') || 'Drag or tap them home', hold: 900 });
    if (S.mixed) later(300, () => sfx.play('fs_mixed'));
    // Blitz: the run's one clock goes on from where the last round left it
    if (!blitz) clk.start(S.limitMs);
    else if (runStarted.current) clk.resume();
    else {
      runStarted.current = true;
      setLeft(BLITZ_MS / 1000);
      clk.start(BLITZ_MS);
    }
  }, [blitz, clk, later, say, setPhase]);

  const tumble = useCallback(() => {
    const { board: B, g: G } = live.current;
    setPhase('tumble');
    sfx.play('fs_tumble');
    let n = 0;
    B.pieces.forEach((p, k) => {
      const A = live.current.anims[k];
      const a = B.after[k];
      A.lift.setValue(0);
      A.hop.setValue(0);
      A.shake.setValue(0);
      A.tick.setValue(0);
      if (a.kind === 'slot') {
        const to = spotOf(a);
        A.x.setValue(to.x);
        A.y.setValue(to.y);
        A.s.setValue(1);
        Animated.timing(A.o, { toValue: 1, duration: 140, useNativeDriver: true }).start();
        return;
      }
      // out of the middle of the inside, into the tray, one after another
      const PP = live.current.P;
      A.x.setValue(G.ix + G.W / 2 - PP / 2 + (Math.random() - 0.5) * G.W * 0.35);
      A.y.setValue(G.iy + G.H * 0.45 - PP / 2 + (Math.random() - 0.5) * G.H * 0.3);
      A.s.setValue(0.75);
      const delay = n * 85;
      n += 1;
      later(delay, () => {
        const to = spotOf(a);
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
  }, [later, setPhase, spotOf, startPlace]);

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
    // (Blitz keeps its clock from round to round: again() resets it)
    if (!blitz) clk.reset();
    setResult(null);
    setFail(null);
    setPaused(false);
    setSelected(null);
    setDragK(null);
    setBanner(null);
    mistakesRef.current = 0;
    setMistakesState(0);
    if (!blitz) setLeft(0);
    setPlay(startState(board));
    setShowInside(true);
    setFoodMoved(false);
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
    // a bigger fridge (or cupboard) gets its own hello, a new shelf a chip
    const bigger = !blitz && spec.first && spec.lv > 1;
    const chips = [];
    if (bigger) chips.push(`LEVEL ${spec.lv}`);
    chips.push(blitz ? t.name.toUpperCase() : TIER_NAMES[spec.tier]);
    if (spec.more && !blitz) chips.push('+1 SHELF');
    if (spec.decoys) chips.push(`${spec.decoys} IMPOSTOR${spec.decoys > 1 ? 'S' : ''}`);
    if (spec.swaps) chips.push('SNEAKY SWAP');
    if (spec.mixed) chips.push('MIXED UP');
    const sub = `${m.size} · ${m.name.toUpperCase()}`;
    if (bigger) say(theme === 'fridge' ? 'BIGGER FRIDGE!' : 'BIGGER CUPBOARD!', { chips, sub, small: true, hold: 1400 });
    else say(blitz ? `ROUND ${spec.round}` : `LEVEL ${spec.lv}`, { chips, sub, hold: 900 });
    sfx.play('sd_boardIn');
    Animated.spring(pop, { toValue: 1, friction: 6, tension: 70, useNativeDriver: true }).start();
    let gone = false;
    const t0 = Date.now();
    prefetchImages(board.pieces.map((p) => p.uri), 2500).then(() => {
      if (gone) return;
      later(Math.max(0, (bigger ? 1800 : 1300) - (Date.now() - t0)), deal);
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
    clearTimers();
    clk.reset();
    onExit();
  }, [clearTimers, clk, onExit]);
  useEffect(() => {
    const sub = BackHandler.addEventListener('hardwareBackPress', () => {
      if (pausedRef.current) resume();
      else if (phaseRef.current === 'place') pause();
      else leave();
      return true;
    });
    return () => sub.remove();
  }, [leave, pause, resume]);
  useEffect(() => {
    const sub = AppState.addEventListener('change', (s) => s !== 'active' && pause());
    return () => sub.remove();
  }, [pause]);

  const next = useCallback(() => {
    setLv((l) => Math.min(LEVELS, l + 1));
    setRound((r) => r + 1);
  }, []);
  const replay = useCallback(() => setRound((r) => r + 1), []);
  // Blitz: a fresh run from round 1
  const again = useCallback(() => {
    clearTimers();
    clk.reset();
    runStarted.current = false;
    setBlitzCard(null);
    setBlitzWin(null);
    setRevived(false);
    setDone(0);
    setLeft(0);
    setPaused(false);
    setIdx(0);
    setRun((r) => r + 1);
  }, [clearTimers, clk, setPaused]);
  // Blitz: the run's one revive (an ad, free with Remove Ads), back to sorting
  const revive = useCallback(() => {
    const back = () => {
      setRevived(true);
      setBlitzCard(null);
      sfx.play('sd_revive');
      setPhase('place');
      clk.resume();
    };
    if (adsFree) back();
    else ad?.show(back);
  }, [ad, adsFree, clk, setPhase]);

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
            <Prop theme={theme} kind={kind} size={Q} />
          </Animated.View>
        );
      })
    : null;
  const shown =
    g && showInside
      ? Object.values(board.start).map((k) => (
          <Animated.Image
            key={k}
            source={{ uri: board.pieces[k].uri }}
            resizeMode="contain"
            fadeDuration={0}
            style={[styles.insideImg, { width: P, height: P, transform: [{ translateX: ins[k].x }, { translateY: ins[k].y }, { scale: ins[k].s }] }]}
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

  return (
    <View style={styles.fill}>
      {/* the top bar */}
      <View style={styles.hud}>
        <RoundButton size={40} onPress={() => (phaseRef.current === 'place' ? pause() : leave())}>
          <BackGlyph />
        </RoundButton>
        <View style={styles.titleBox}>
          <Text style={[styles.themeName, { color: t.ring }]} numberOfLines={1}>
            {blitz ? `BLITZ ⚡ · ${m.name.toUpperCase()}` : m.name.toUpperCase()}
          </Text>
          <View style={styles.row6}>
            <Text style={styles.levelText}>{blitz ? `ROUND ${spec.round}/${BLITZ_ROUNDS}` : `LEVEL ${spec.lv}`}</Text>
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
          <View style={styles.hearts}>
            {hearts.map((on, i) => (
              <Heart key={i} on={on} />
            ))}
          </View>
        )}
      </View>
      {blitz ? (
        <View style={styles.pips}>
          <Pips count={BLITZ_ROUNDS} done={done} current={blitzCard === 'fail' || blitzCard === 'win' ? -1 : idx} />
        </View>
      ) : null}
      {/* the peek's countdown, then the clock */}
      <View style={styles.bar}>
        {phase === 'peek' || phase === 'deal' ? (
          <>
            <Text style={styles.barLabel}>{phase === 'peek' ? `REMEMBER! ${peekLeft}` : 'GET READY'}</Text>
            <Bar frac={peekBar} colors={['#ffe45c', '#ff8a3d']} />
          </>
        ) : phase === 'place' || phase === 'won' || phase === 'lost' || blitz ? (
          // (Blitz: the run's clock shows all the time, stopped between the sorting)
          <>
            <Text style={[styles.barLabel, phase === 'place' && left <= 10 && { color: '#e01e4a' }]}>{clock(left > 0 || (blitz && runStarted.current) ? left * 1000 : blitz ? BLITZ_MS : spec.limitMs)}</Text>
            <Bar frac={clk.frac} colors={['#b8ffd9', '#3ddc97']} />
          </>
        ) : (
          <Text style={styles.barLabel}>{phase === 'shake' || phase === 'close' ? 'SHAKING…' : ' '}</Text>
        )}
      </View>

      {/* the play area: everything is placed by geometry() and trayGeo() */}
      <View ref={areaRef} style={styles.area} onLayout={onArea} {...responder.panHandlers}>
        {g ? (
          <>
            {/* the tray */}
            <View pointerEvents="none" style={[styles.trayRing, { left: tg.tx, top: tg.ty, width: tg.tw, height: tg.th, backgroundColor: t.tray.ring }]}>
              <LinearGradient colors={t.tray.colors} locations={[0, 0.6, 1]} style={styles.tray}>
                <View style={styles.trayShine} />
                {Array.from({ length: board.trayCap }, (_, j) => {
                  const c = trayCenter(tg, j);
                  return <View key={j} style={[styles.traySpot, { left: c.x - tg.tx - 2.5 - tg.cell * 0.36, top: c.y - tg.ty - 2.5 + tg.cell * 0.22, width: tg.cell * 0.72, height: tg.cell * 0.2 }]} />;
                })}
              </LinearGradient>
              <View style={[styles.trayLabel, { backgroundColor: t.tray.ring }]}>
                <Text style={styles.trayLabelText}>{t.tray.label}</Text>
              </View>
            </View>
            {/* the container, shaking as one */}
            <Animated.View pointerEvents="none" style={[styles.wrap, { left: g.bx, top: g.by, transform: wrapTransform }]}>
              <Container m={m} g={g} door={door} light={light} inside={insidePieces} slots={false} />
            </Animated.View>
            {/* the spot under a dragged squishy */}
            <Animated.View pointerEvents="none" style={[styles.hover, { width: g.S, height: g.S, borderRadius: g.S * 0.24, opacity: hover.o, transform: [{ translateX: hover.x }, { translateY: hover.y }] }]} />
            {/* the squishies in play */}
            {inPlay
              ? order.map((k) => (
                  <Piece
                    key={k}
                    uri={board.pieces[k].uri}
                    size={P}
                    a={anims[k]}
                    mixed={phase === 'place' && !play.gone[k] && play.at[k].kind === 'slot' && !play.locked[k]}
                    selected={selected === k}
                    locked={!!play.locked[k]}
                  />
                ))
              : null}
            <Banner banner={banner} top={Math.max(0, g.by - 34)} />
            <FxLayer ref={fx} />
          </>
        ) : null}
      </View>

      {blitz ? (
        <>
          <BlitzPauseCard blitz visible={paused} onResume={resume} onRestart={again} onQuit={leave} />
          <ReviveCard visible={blitzCard === 'revive'} board={idx + 1} unit="round" adReady={!!ad?.ready} adsFree={adsFree} onRevive={revive} onGiveUp={() => endRun('mistake')} />
          <BlitzFailCard visible={blitzCard === 'fail'} reason={failReason} reached={idx + 1} best={record(profile).blitz.reached} unit="round" onAgain={again} onQuit={leave} />
          <BlitzWinCard visible={blitzCard === 'win'} res={blitzWin} uris={blitzWin?.uris || []} unit="round" onAgain={again} onQuit={leave} />
        </>
      ) : (
        <>
          <ResultCard visible={!!result} res={result} spec={spec} theme={t} last={lv >= LEVELS} onNext={next} onReplay={replay} onHub={leave} />
          <FailCard visible={!!fail} reason={fail?.reason} uri={board.pieces[0]?.uri} onRetry={replay} onHub={leave} />
          <PauseCard
            visible={paused}
            onResume={resume}
            onRestart={() => {
              setPaused(false);
              replay();
            }}
            onQuit={leave}
          />
        </>
      )}
      {phase === 'load' ? <PopIn style={styles.loading}><Text style={styles.loadingText}>Getting the squishies…</Text></PopIn> : null}
    </View>
  );
}

const styles = StyleSheet.create({
  fill: { flex: 1 },
  hud: { flexDirection: 'row', alignItems: 'center', gap: 10, paddingHorizontal: 14, paddingTop: 6 },
  titleBox: { flex: 1, minWidth: 0 },
  themeName: { fontFamily: F.display, fontSize: 13, letterSpacing: 1 },
  row6: { flexDirection: 'row', alignItems: 'center', gap: 6 },
  levelText: { fontFamily: F.display, fontSize: 21, color: '#ffffff', textShadowColor: INK, textShadowOffset: { width: 0, height: 2.5 }, textShadowRadius: 1, includeFontPadding: false },
  challenge: { paddingHorizontal: 7, paddingVertical: 1, borderRadius: 999, backgroundColor: '#e01e4a', borderWidth: 2, borderColor: '#ffffff' },
  challengeText: { fontFamily: F.display, fontSize: 10, letterSpacing: 0.6, color: '#ffffff' },
  pips: { marginTop: 8 },
  hearts: { flexDirection: 'row', gap: 3, paddingHorizontal: 8, paddingVertical: 5, borderRadius: 999, backgroundColor: 'rgba(255,255,255,0.8)', borderWidth: 2, borderColor: '#ffffff' },
  heartBox: { width: 24, height: 24 },
  bar: { flexDirection: 'row', alignItems: 'center', gap: 8, height: 30, paddingHorizontal: 16, marginTop: 6 },
  barLabel: { minWidth: 64, fontFamily: F.display, fontSize: 13, letterSpacing: 0.6, color: INK },
  track: { flex: 1, height: 14, borderRadius: 7, backgroundColor: 'rgba(69,16,122,0.18)', borderWidth: 2, borderColor: '#ffffff', overflow: 'hidden' },
  trackShine: { position: 'absolute', left: 4, right: 4, top: 1.5, height: 3, borderRadius: 2, backgroundColor: 'rgba(255,255,255,0.6)' },
  area: { flex: 1 },
  wrap: { position: 'absolute' },
  insideImg: { position: 'absolute', left: 0, top: 0 },
  prop: { position: 'absolute' },
  trayRing: { position: 'absolute', borderRadius: 24, padding: 2.5, paddingBottom: 7 },
  tray: { flex: 1, borderRadius: 21.5, borderWidth: 3, borderColor: '#ffffff', overflow: 'hidden' },
  trayShine: { position: 'absolute', left: 14, right: 14, top: 3, height: 8, borderRadius: 4, backgroundColor: 'rgba(255,255,255,0.6)' },
  traySpot: { position: 'absolute', borderRadius: 999, backgroundColor: 'rgba(69,16,122,0.1)' },
  trayLabel: { position: 'absolute', top: -10, alignSelf: 'center', paddingHorizontal: 10, paddingVertical: 1, borderRadius: 999, borderWidth: 2, borderColor: '#ffffff' },
  trayLabelText: { fontFamily: F.display, fontSize: 10, letterSpacing: 1, color: '#ffffff' },
  hover: { position: 'absolute', left: 0, top: 0, borderWidth: 3, borderColor: '#ffd23a', backgroundColor: 'rgba(255,230,120,0.28)' },
  piece: { position: 'absolute', left: 0, top: 0, alignItems: 'center', justifyContent: 'center' },
  pieceImg: { width: '100%', height: '100%' },
  pieceShadow: { position: 'absolute', bottom: '0%', width: '74%', height: '14%' },
  selRing: { position: 'absolute', left: '4%', right: '4%', top: '4%', bottom: '4%', borderRadius: 999, borderWidth: 3, borderColor: '#ffd23a', backgroundColor: 'rgba(255,240,150,0.35)' },
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
