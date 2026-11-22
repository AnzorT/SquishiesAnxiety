import React, { memo, useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { Animated, AppState, BackHandler, Easing, Image, PanResponder, StyleSheet, Text, View } from 'react-native';
import Svg, { Path } from 'react-native-svg';
import useRewardedAd from '../components/useRewardedAd';
import { stepKeys, useKeyLoop } from '../components/idleLoop';
import sfx from '../audio/sfx';
import { FxLayer } from '../squishdoku/fx';
import { makeHaptics, useClock } from '../squishdoku/game';
import { Countdown } from '../squishdoku/BlitzGame';
import { TimerBar } from '../squishdoku/Hud';
import { BlitzOverCard, BlitzSaveCard, PauseCard, ResultCard } from '../squishdoku/Overlays';
import { trioOf } from '../squishdoku/Trio';
import { blitzSaveGems, clock } from '../squishdoku/levels';
import * as squad from '../squad/api';
import { BtnLabel, Chip, Head, SdButton } from '../squishdoku/ui';
import { F } from '../squishdoku/theme';
import { Banner } from '../sort/Game';
import { CribButton, RoomFlash, RoomTitle } from '../crib/Hud';
import { saveHop } from '../firebase/firestore';
import { bodyH } from '../stack/Pieces';
import { DIRS, leftOf, moves as movesOf, newState, search, tryMove } from './engine';
import { LEVELS, ROOMS, TIER_COLORS, TIER_NAMES, TWISTS, afterBlitz, afterLevel, afterStuck, levelSpec, record, stageOf, starsFor } from './levels';
import { blitzSpec } from './blitz';
import { DEPTH, cellAt, layout, standOn } from './board';
import { BEAT_COL, Bubble, CROUCH, FlatCushion, GoalStar, HAP_GO, HintGlow, LEAN_X, OrderChip, PILE_TOP, Piece, SPRING, Star, Tile, Under, freshPose, poseAt, restPose } from './Pieces';
import Room, { roomGeometry } from './Room';
import { friendsOf, headOf, hopperOf } from './roster';
import { HintCard, RESULT_TITLES, StuckCard } from './Cards';
import RigStage from './RigStage';

// One level of Squish Hop (SQUISH_HOP.md), and the next ones after it. The
// squishy hops across cushions on the floor of one of the Crib's rooms; the
// cushion it hops off puffs away, so it can never go back. It has to reach
// the ★ cushion, which opens only once every other cushion is cleared (the
// user, 2026-11-16). The stars are for doing it without taking hops back.
// Swipe (a long drag can turn corners) or tap a cushion next to it. The
// rules are engine.js, the board's perspective board.js; this draws and
// animates them.
//
// BLITZ MODE (`blitz`; 2026-11-16, the user: "the same thing" as
// Squishdoku's): after a 3, 2, 1, GO! fresh small boards (blitz.js) one after
// another in the Dance Room, each on its own short clock. A hop that leaves
// no full clear (the solver checks after every hop), getting stuck, or the
// clock running out stops the run. It can be saved, once with a rewarded ad
// (free with Remove Ads) or with gems, each save twice the last
// (functions/squad.js blitzSave): the hops since the last spot a full clear
// was possible from are taken back, or after the clock, the board's clock
// starts again. Or it's GAME OVER, and the boards cleared pay out
// (levels.js afterBlitz). No UNDO, RESTART or hints in Blitz.

const LOAD_SOUNDS = ['st_lift', 'st_land', 'st_hint', 'st_news', 'fs_pop', 'tap', 'bonk', 'sd_squeak', 'sd_unlock', 'sd_wrong', 'sd_solve', 'sd_confetti', 'sd_boardIn', 'swoosh'];
const BLITZ_SOUNDS = ['sd_count', 'sd_go', 'sd_pip', 'sd_blitzNext', 'sd_blitzFail', 'sd_blitzWin', 'sd_drain', 'sd_revive', 'sd_timeUp', 'sd_tick', 'sd_pause'];
// Blitz: the last seconds of a board's clock tick
const HURRY_MS = 5000;

// (No tip line since 2026-11-17, the user: "too much text in instructions, make it simple with UI not text". A bump
// shakes the goal card (the ★ shut, a friend out of order) or the beat pill instead; a board that can't be cleared any
// more makes RESTART pulse; a new twist still gets its banner, and HOW TO PLAY has the rules.)

const RUG = require('../../assets/crib/fixtures/living-rug.webp');
const PLAYER_W = 0.86; // the hopper's body, in tiles
const FRIEND_W = 0.72;

// How long each of the squishies' moves takes (Pieces.js freshPose has their shapes). A hop is 190 ms (170 onto a
// bubble) as before, and still the only time a hop holds the next one back; the rest play on while the next one goes.
const LAND_MS = 360; // the landing's squash and wobble
const NO_MS = 560; // a bump's shake of the head
const HAP_MS = 760; // a friend's happy hop and flight to the goal card
const JOY_MS = 1150; // the win's three jumps (Blitz: BLITZ_JOY_MS, before the next board drops in)
const BLITZ_JOY_MS = 900;
const LOOK_MS = 850; // stuck: the look left and right (then the sad sway, Piece's SAD_SWAY_AT)
const STUCK_CARD_MS = 1400; // stuck: when the STUCK card comes up, once the sway has begun
const CHEER_MS = 1050; // the friends cheering in the goal card
// eased travel that waits while the squishy crouches (or squashes on a bubble), then goes
const holdEase = (hold, ease = Easing.inOut(Easing.quad)) => (t) => (t <= hold ? 0 : ease((t - hold) / (1 - hold)));
const AFTER_CROUCH = holdEase(CROUCH * 0.8);
const AFTER_SPRING = holdEase(SPRING * 0.8);
const FLY = holdEase(HAP_GO);
const FLY_FADE = holdEase(HAP_GO, Easing.in(Easing.quad));
const SHADOW_GO = holdEase(0.7, Easing.linear);

const STAR_D = 'M12 2.2 L14.9 8.6 L21.8 9.3 L16.6 14 L18.1 20.9 L12 17.4 L5.9 20.9 L7.4 14 L2.2 9.3 L9.1 8.6 Z';
// the stars still possible
const Meter = memo(function Meter({ stars }) {
  return (
    <View style={styles.meter}>
      {[0, 1, 2].map((i) => (
        <Svg key={i} width={i === 1 ? 24 : 19} height={i === 1 ? 24 : 19} viewBox="0 0 24 24" style={{ marginTop: i === 1 ? 0 : 3 }}>
          <Path d={STAR_D} fill={i < stars ? '#ffd23a' : 'rgba(255,255,255,0.55)'} stroke={i < stars ? '#b86200' : '#b9a6cc'} strokeWidth={1.6} strokeLinejoin="round" />
        </Svg>
      ))}
    </View>
  );
});

// the next three beats: the next hop's colour first, big (it shakes when a hop bumps an unlit tile)
const BeatPill = memo(function BeatPill({ next, shakeX }) {
  return (
    <Animated.View style={[styles.pill, styles.beatPill, { transform: [{ translateX: shakeX }] }]}>
      <Text style={[styles.pillText, { color: '#8a3a0e' }]}>BEAT</Text>
      {[0, 1, 2].map((k) => (
        <View key={k} style={[styles.beatDot, { backgroundColor: BEAT_COL[(next + k) % 3] }, k === 0 && styles.beatNow]} />
      ))}
    </Animated.View>
  );
});

// The arrow keys, bottom left (the user, 2026-11-17): a hop each press, as soon as the finger lands, the same as a
// swipe that way (queued like one while a hop plays). The hint's way lights up gold.
const KEY_W = 50; // a key, lip and all
const KEY_H = 46;
const PAD = [
  { d: 0, x: 1, y: 0 },
  { d: 3, x: 0, y: 1 },
  { d: 1, x: 2, y: 1 },
  { d: 2, x: 1, y: 2 },
];
const ARROW_ROT = ['0deg', '90deg', '180deg', '270deg'];
const DPad = memo(function DPad({ onDir, lit }) {
  return (
    <View style={styles.pad}>
      {PAD.map(({ d, x, y }) => (
        <SdButton
          key={d}
          kind={lit === d ? 'gold' : 'white'}
          onDown={() => onDir(d)}
          sound={null}
          radius={14}
          lip={4}
          faceStyle={styles.keyFace}
          style={[styles.key, { left: x * (KEY_W - 2), top: y * (KEY_H - 6) }]}
        >
          <Svg width={22} height={22} viewBox="0 0 24 24" style={{ transform: [{ rotate: ARROW_ROT[d] }] }}>
            <Path d="M5 15.5 L12 8.5 L19 15.5" fill="none" stroke={lit === d ? '#9c4d06' : '#6b4426'} strokeWidth={4.2} strokeLinecap="round" strokeLinejoin="round" />
          </Svg>
        </SdButton>
      ))}
    </View>
  );
});

// a gentle throb while `on` (RESTART, once the board can't be cleared from here): up 420 ms, down 520 ms, as one
// native loop (idleLoop.js), back at 1 when off
const THROB = stepKeys(1, [
  [1.08, 420, Easing.out(Easing.quad)],
  [1, 520, Easing.inOut(Easing.quad)],
]);
function Pulse({ on, children, style }) {
  const scale = useKeyLoop(THROB.ms, { at: THROB.at, values: THROB.values, on: !!on });
  return <Animated.View style={[style, { transform: [{ scale }] }]}>{children}</Animated.View>;
}

// A friend in the goal card: its head, dim until it's picked up (and a pop
// when it lands there), with its number on in-order levels. On a win the
// friends cheer: `cheer` 0 → 1 is three jumps with a wiggle, the last a spin,
// each friend a little after the one before (`idx`).
const Slot = memo(function Slot({ c, size, got, n, pop, cheer, idx, onRef }) {
  const head = headOf(c);
  const style = useMemo(() => {
    const s = Math.min(0.12, idx * 0.04);
    const at = [0, s + 0.02, s + 0.12, s + 0.24, s + 0.34, s + 0.46, s + 0.6, s + 0.74, 1];
    const J = size * 0.5;
    return {
      transform: [
        { translateY: cheer.interpolate({ inputRange: at, outputRange: [0, 0, -J, 0, -J, 0, -J * 1.3, 0, 0] }) },
        { rotate: cheer.interpolate({ inputRange: at, outputRange: ['0deg', '0deg', '14deg', '0deg', '-14deg', '0deg', '180deg', '360deg', '360deg'] }) },
        { scale: Animated.multiply(pop, cheer.interpolate({ inputRange: at, outputRange: [1, 1, 1.18, 0.92, 1.18, 0.92, 1.25, 1, 1] })) },
      ],
    };
  }, [cheer, idx, size, pop]);
  return (
    <Animated.View ref={onRef} collapsable={false} style={style}>
      {head ? (
        <View style={[styles.sticker, { width: size, height: size, borderRadius: size / 2 }, !got && styles.stickerDim]}>
          <View style={[styles.stickerIn, !got && { backgroundColor: 'rgba(255,255,255,0.35)' }]}>
            <Image source={head} fadeDuration={0} style={[styles.stickerImg, !got && { opacity: 0.28 }]} />
          </View>
        </View>
      ) : (
        <Head uri={c.uri} size={size} dim={!got} />
      )}
      {n ? (
        <View style={styles.slotNum}>
          <Text style={styles.slotNumText}>{n}</Text>
        </View>
      ) : null}
    </Animated.View>
  );
});

// the Living Room's rug, laid on the floor under the board (the room's own
// rug, in the board's perspective)
const Rug = memo(function Rug({ B }) {
  const W = B.w * B.T;
  const H = B.h * B.T;
  return (
    <View pointerEvents="none" style={{ position: 'absolute', left: B.cx - W / 2, top: B.cy - H / 2, width: W, height: H, transform: [{ perspective: B.T * DEPTH }, { rotateX: `${B.tilt}deg` }] }}>
      <Image source={RUG} fadeDuration={0} resizeMode="stretch" style={{ position: 'absolute', left: -0.16 * W, top: -0.12 * H, width: 1.32 * W, height: 1.24 * H }} />
    </View>
  );
});

export default function HopGame({ startLv = 1, blitz = false, cast, profile, uid, adsFree, haptics: hapticsOn = true, onExit }) {
  const haptics = useRef(makeHaptics(hapticsOn)).current;
  const ad = useRewardedAd();
  const profileRef = useRef(profile);
  profileRef.current = profile;

  const [lv, setLv] = useState(startLv);
  const [round, setRound] = useState(0); // a new go at the level
  const fresh = useRef(true); // a new go that also forgets the hint and the take-backs (not RESTART / RETRY)
  // Blitz: the run (each with its own seed for its boards), its board, the
  // boards cleared, its saves, which of its cards is up, the countdown and the
  // board's clock
  const [run, setRun] = useState(0);
  const [idx, setIdx] = useState(0);
  const idxRef = useRef(0);
  idxRef.current = idx;
  const seed = useMemo(() => (Date.now() ^ Math.imul(run + 1, 2654435761)) | 0, [run]);
  const [cleared, setCleared] = useState(0);
  const [blitzCard, setBlitzCard] = useState(null); // save | over
  const [failReason, setFailReason] = useState('mistake'); // mistake | stuck | time
  const [adUsed, setAdUsed] = useState(false);
  const [gemSaves, setGemSaves] = useState(0);
  const [saving, setSaving] = useState(false);
  const [saveErr, setSaveErr] = useState(null);
  const [over, setOver] = useState(null);
  const [count, setCount] = useState(null); // 3, 2, 1, 'GO!'
  const [label, setLabel] = useState('');
  const [warn, setWarn] = useState(false);
  const clk = useClock();
  // the run so far: started (its first board's clock ran), paid out (payOut), the boards it cleared
  const runRec = useRef({ started: false, ended: false, cleared: 0 });
  const spec = useMemo(() => (blitz ? blitzSpec(idx, seed) : levelSpec(lv)), [blitz, lv, idx, seed]);
  // a key for this board's pieces (Blitz boards follow each other at level 1)
  const tag = blitz ? `b${run}-${idx}` : String(lv);
  const board = spec.board;
  const room = ROOMS[spec.room];
  const hopper = useMemo(() => hopperOf(cast, profileRef.current), [cast]);
  const friends = useMemo(() => friendsOf(cast, hopper, board.friends.length, blitz ? 101 + idx * 31 + (seed & 1023) : lv), [cast, hopper, board, lv]); // eslint-disable-line react-hooks/exhaustive-deps
  // the goal card's friends: in pick-up order on in-order levels
  const slotOrder = useMemo(() => board.friends.map((_, k) => k).sort((a, b) => (board.order[board.friends[a]] || 0) - (board.order[board.friends[b]] || 0)), [board]);

  // --- where things are -----------------------------------------------------------------
  // (from layouts, not measure(): the screen slides in, and a measure taken
  // mid-slide is off by however far it still had to go)
  const areaRef = useRef(null);
  const [root, setRoot] = useState(null); // { w, h }
  const [area, setArea] = useState(null); // { w, h, y: from the top of the screen }
  const onRoot = useCallback((e) => {
    const { width, height } = e.nativeEvent.layout;
    setRoot((r) => (r && r.w === width && r.h === height ? r : { w: width, h: height }));
  }, []);
  const onArea = useCallback((e) => {
    const { width, height, x, y } = e.nativeEvent.layout;
    setArea((a) => (a && a.w === width && a.h === height && a.y === y && a.x === x ? a : { w: width, h: height, x, y }));
  }, []);
  const floorY = root ? roomGeometry(spec.room, root.w, root.h).floorY : 0;
  const B = useMemo(() => (area && root ? layout(board.w, board.h, area.w, area.h, floorY - area.y) : null), [area, root, board, floorY]);
  const cells = useMemo(() => board.life.map((x, i) => (x ? i : -1)).filter((i) => i >= 0), [board]);

  // --- animated values: the cushions, bubbles, ★, squishies ------------------------------
  const cellA = useMemo(() => board.life.map((x) => (x ? { a0: new Animated.Value(0), a1: new Animated.Value(0) } : null)), [board]);
  const bubbleA = useMemo(() => board.bubble.map((b) => (b ? new Animated.Value(0) : null)), [board]);
  const player = useMemo(() => freshPose({ juicy: true }), []);
  const friendA = useMemo(() => board.friends.map(() => freshPose({ juicy: true })), [board]);
  const slotPop = useMemo(() => board.friends.map(() => new Animated.Value(1)), [board]);
  const slotCheer = useMemo(() => new Animated.Value(0), [board]);
  const [mood, setMood] = useState(null); // 'sad': the hopper is stuck (Piece)
  // The characters as the design's live rigs (RigStage.js): the page draws them once this board's cast is drawn
  // (rigTag), and until then (or if a rig's art won't load) the cut-outs stand in.
  const stage = useRef(null);
  const [rigTag, setRigTag] = useState(null);
  const castTag = useMemo(() => [hopper && hopper.key, ...friends.map((f) => f && f.key)].join(','), [hopper, friends]);
  // the result card's three: the hopper in the middle, the friends either side
  const trio = useMemo(() => trioOf([friends[0] && friends[0].key, hopper && hopper.key, friends[1] && friends[1].key], (cast || []).map((c) => c.key)), [hopper, friends, cast]);
  const rigsOn = rigTag === castTag;
  const rigsOnRef = useRef(false);
  rigsOnRef.current = rigsOn;
  const starPop = useMemo(() => new Animated.Value(0), [board]);
  const starGone = useMemo(() => new Animated.Value(0), [board]);
  const shake = useRef(new Animated.Value(0)).current; // the goal card's
  const beatShake = useRef(new Animated.Value(0)).current;
  const flash = useRef(new Animated.Value(0)).current;
  const fx = useRef(null);
  const fxTop = useRef(null); // over the cards: a new best's confetti
  const slotRefs = useRef([]);
  const slotAt = useRef([]); // each slot's middle, in the board area's coordinates
  const pw = B ? B.T * PLAYER_W : 0;
  const ph = hopper && B ? bodyH(hopper, pw) : 0;
  const fw = B ? B.T * FRIEND_W : 0;

  // how each cell looks: fixed for the level, but a beat tile has a lit look too
  const looks = useMemo(
    () =>
      board.life.map((life, i) => {
        if (!life) return null;
        const off = { dance: !!room.dance, color: room.cushion || 'pink', goal: i === board.goal, pile: life === 2, arrow: board.arrow[i], beat: board.beat[i], beats: spec.beats, lit: false };
        return { off, on: board.beat[i] >= 0 ? { ...off, lit: true } : off };
      }),
    [board, room, spec.beats],
  );

  // --- the game's state (refs: the touch handlers and timers read it) ---------------------
  // takebacks: the RESTARTs and RETRYs on this level (the stars; no UNDO since 2026-11-17, the user); okAt[k]: whether a full clear was still possible after k
  // hops (Blitz's save goes back to the last one that was)
  const G = useRef({ st: newState(board), hist: [], moves: [], hinted: false, takebacks: 0, okAt: [true], busy: false, queue: [], over: false, won: false, feasible: true, shown: 0, life: [], lastSecond: -1 }).current;
  const [view, setView] = useState({ hops: 0, moves: 0, left: 0, got: 0, cur: board.start, feasible: true, hinted: false, takebacks: 0 });
  const [shown, setShown] = useState(0); // the friends that have landed in the goal card
  const [playerZ, setPlayerZ] = useState(10);
  const [phase, setPhase] = useState('load'); // load | intro (Blitz: before a board's clock) | play | won | stuck | held (Blitz: stopped)
  const [glow, setGlow] = useState(-1); // the hint's cell
  const [banner, setBanner] = useState(null);
  const [result, setResult] = useState(null);
  const [stuck, setStuck] = useState(false);
  const [paused, setPaused] = useState(false);
  const [hintAsk, setHintAsk] = useState(false);
  const blocked = useRef(false);
  blocked.current = paused || hintAsk || !!result || stuck || !!blitzCard;
  const say = useCallback((text, more = {}) => setBanner({ text, key: Date.now(), ...more }), []);

  // hops: cells entered (a bubble bounce enters two: the beat counts them); moves: hops made
  const sync = () => setView({ hops: G.st.hops, moves: G.moves.length, left: leftOf(board, G.st.life), got: G.st.got, cur: G.st.cur, feasible: G.feasible, hinted: G.hinted, takebacks: G.takebacks });

  // timers, cleared on a new go and on leaving
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

  const timing = (v, toValue, duration, easing = Easing.inOut(Easing.quad), delay = 0) => Animated.timing(v, { toValue, duration, easing, delay, useNativeDriver: true });
  const zOf = (cell, k) => 10 + Math.floor(cell / board.w) * 3 + k;

  // a squishy's pose standing on `cell` (on top of a pile if `life` is 2)
  const poseOn = (cell, w, h, life) => {
    const q = standOn(B, cell, life === 2 ? PILE_TOP : 0);
    return poseAt(w, h, q.x, q.y, q.s / B.T);
  };
  const place = (a, p) => {
    a.x.setValue(p.x);
    a.y.setValue(p.y);
    a.k.setValue(p.k);
  };
  // the rig stage (RigStage.js): a move for one of its characters ('p' the hopper, 'f<k>' friend k), and where a
  // character stands on `cell` (on top of a pile if `life` is 2): its feet in the board area, scale and z
  const rig = (fn, ...args) => stage.current && stage.current[fn](...args);
  const rigAt = (cell, k, life) => {
    const q = standOn(B, cell, life === 2 ? PILE_TOP : 0);
    return { x: q.x, y: q.y, s: q.s / B.T, z: zOf(cell, k) };
  };
  // everyone where they are now (a new board, the page ready, the board moved)
  function sendCast() {
    if (!B || !hopper || !area) return;
    const life = G.st.life;
    const list = [{ id: 'p', key: hopper.key, W: pw, ...rigAt(G.st.cur, 2, life[G.st.cur]) }];
    board.friends.forEach((cell, k) => {
      const c = friends[k];
      if (c) list.push({ id: `f${k}`, key: c.key, W: fw, ...rigAt(cell, 1, board.life[cell]), o: G.st.got & board.fbit[cell] ? 0 : 1 });
    });
    rig('origin', area.x || 0, area.y || 0);
    rig('cast', list, castTag);
  }

  // --- the cushions -------------------------------------------------------------------------

  // a cell to `life` hops left, puffing away or back
  function setCell(i, life, anim = true) {
    const A = cellA[i];
    if (!A || i === board.goal) return;
    const from = G.life[i];
    if (from === life) return;
    G.life[i] = life;
    const bub = bubbleA[i];
    if (!anim) {
      A.a0.setValue(life > 0 ? 1 : 0);
      A.a1.setValue(life > 1 ? 1 : 0);
      if (bub) bub.setValue(life > 0 ? 1 : 0);
      return;
    }
    if (life < from) {
      if (from === 2) timing(A.a1, 0, 260, Easing.out(Easing.quad)).start();
      if (life === 0) {
        timing(A.a0, 0, 260, Easing.out(Easing.quad)).start();
        const q = standOn(B, i);
        if (bub) {
          timing(bub, 0, 220, Easing.out(Easing.quad)).start();
          // (a rig pops it with its own bubbles round its feet: this layer is over the rig's face)
          if (!rigsOnRef.current) fx.current?.burst('poof', q.x, q.y - q.s * 0.45, q.s / 60);
          sfx.play('tap');
        } else {
          fx.current?.burst('pop', q.x, q.y - q.s * 0.1, q.s / 60);
          sfx.play('fs_pop');
        }
      }
    } else {
      if (from === 0) {
        timing(A.a0, 1, 300, Easing.out(Easing.back(1.4))).start();
        if (bub) timing(bub, 1, 260, Easing.out(Easing.quad)).start();
      }
      if (life === 2) timing(A.a1, 1, 300, Easing.out(Easing.back(1.4)), from === 0 ? 80 : 0).start();
    }
  }

  // --- moving the squishies -------------------------------------------------------------------

  // Hop squishy `a` (w × h) onto `cell` in `ms`, `hopH` tiles high: it crouches (and doesn't travel yet), stretches
  // up and over, and lands with a squash that wobbles back while the next hop may already be going (Pieces.js
  // freshPose). `how.d`: the way it's going, so it leans into the hop (sideways, or away from / toward the camera
  // going up / down the board) and faces left or right. `how.boing`: it springs off a bubble (its squash on the
  // bubble is the take-off). `how.land: false`: it lands on a bubble, whose boing is its landing.
  function moveTo(a, w, h, cell, ms, life, hopH = 0.5, how = {}) {
    const p = poseOn(cell, w, h, life);
    if (a === player) setPlayerZ(zOf(cell, 2));
    const phase = how.boing ? a.bp : a.hp;
    const [ux, uy] = how.d == null ? [0, 0] : DIRS[how.d];
    a.lx.setValue(ux);
    a.lzDeg.setValue(-uy * LEAN_X);
    phase.setValue(0);
    a.liftH.setValue(B.T * hopH);
    const ease = how.boing ? AFTER_SPRING : AFTER_CROUCH;
    const anims = [timing(a.x, p.x, ms, ease), timing(a.y, p.y, ms, ease), timing(a.k, p.k, ms, ease), timing(phase, 1, ms, Easing.linear)];
    // as drawn going right, mirrored going left: a quick paper turn in the crouch
    if (ux && a.facing !== ux) {
      a.facing = ux;
      anims.push(timing(a.face, ux, Math.min(130, ms * 0.7)));
    }
    return new Promise((done) =>
      Animated.parallel(anims).start(() => {
        if (how.land !== false) {
          a.land.setValue(0);
          timing(a.land, 1, LAND_MS, Easing.linear).start();
        }
        done();
      }),
    );
  }
  // a bump toward d (`by` tiles), squished against the way it can't go if `squish`; or a little nudge
  function nudge(d, by, ms = 200, delay = 0, squish = false) {
    const [ux, uy] = DIRS[d];
    player.dx.setValue(ux * B.T * by);
    player.dy.setValue(uy * B.T * by * 0.6);
    player.ex.setValue(squish ? (ux ? -0.24 : 0.14) : 0);
    player.ey.setValue(squish ? (ux ? 0.12 : -0.2) : 0);
    player.bump.setValue(0);
    return new Promise((done) => timing(player.bump, 1, ms, Easing.out(Easing.quad), delay).start(done));
  }
  // one go of a phase 0 → 1 (Pieces.js freshPose reads it through its keyframes)
  function play(v, ms) {
    v.setValue(0);
    timing(v, 1, ms, Easing.linear).start();
  }
  // Stuck (or a Blitz run stopped): the hopper droops, looks left and right, sweats and then sways sadly (Piece's
  // 'sad' mood), until a hint, a save or a new go snaps it back (cheerUp).
  function sadden() {
    setMood('sad');
    rig('stuck', 'p');
    player.droop.setValue(0);
    timing(player.droop, 1, 420, Easing.out(Easing.quad)).start();
    play(player.look, LOOK_MS);
  }
  function cheerUp() {
    setMood(null);
    rig('unstuck', 'p');
    player.look.stopAnimation();
    player.look.setValue(0);
    timing(player.droop, 0, 160, Easing.out(Easing.back(2))).start();
  }

  function tryDir(d) {
    const m = tryMove(board, G.st, d);
    if (!m.ok) {
      bump(d, m);
      return;
    }
    hop(d, m);
  }
  function bump(d, m) {
    sfx.play('bonk');
    haptics.tap();
    G.busy = true;
    // squished against the edge, then a shake of the head (which plays on after the next hop may start)
    rig('bump', 'p', DIRS[d][0] * B.T * 0.16, DIRS[d][1] * B.T * 0.1, true);
    nudge(d, 0.16, 200, 0, true).then(() => {
      G.busy = false;
      drain();
    });
    play(player.no, NO_MS);
    // what said no shakes (it was a line of text before, 2026-11-17): the goal card for the ★ still shut or a friend
    // out of order, the beat pill for an unlit tile
    const s = m.why === 'locked' || m.why === 'order' ? shake : m.why === 'beat' ? beatShake : null;
    if (s) {
      s.setValue(0);
      timing(s, 1, 320, Easing.linear).start();
    }
  }

  async function hop(d, m) {
    const prev = G.st;
    const nxt = m.st;
    G.hist.push(prev);
    G.moves.push(d);
    G.st = nxt;
    G.busy = true;
    setGlow(-1);
    sfx.play('st_lift');
    haptics.tap();
    setCell(prev.cur, nxt.life[prev.cur]);
    rig(
      'hop',
      'p',
      m.cells.map((c, k) => {
        const last = k === m.cells.length - 1;
        return { ...rigAt(c, 2, last ? nxt.life[c] : 1), ms: last ? 190 : 170, h: B.T * (k ? 0.8 : 0.5) * (standOn(B, c).s / B.T), boing: k > 0 };
      }),
      d,
    );
    // onto each cell in turn; a bubble pops as it boings you on
    for (let k = 0; k < m.cells.length; k++) {
      const c = m.cells[k];
      const last = k === m.cells.length - 1;
      if (k) sfx.play('st_lift', { rate: 1.5 });
      await moveTo(player, pw, ph, c, last ? 190 : 170, last ? nxt.life[c] : 1, k ? 0.8 : 0.5, { d, boing: k > 0, land: last });
      if (!alive.current || G.st !== nxt) return;
      if (!last) setCell(c, nxt.life[c]);
    }
    // a puff of dust off the cushion it lands on (a rig puffs its own, round its feet: this layer is over it)
    const q = standOn(B, nxt.cur, nxt.life[nxt.cur] === 2 ? PILE_TOP : 0);
    if (!rigsOnRef.current) fx.current?.burst('puff', q.x, q.y, q.s / 60);
    m.cells.forEach((c) => {
      if (nxt.got & board.fbit[c] && !(prev.got & board.fbit[c])) collect(c);
    });
    if (nxt.done) {
      win();
      return;
    }
    // the ★ opens: every other cushion is cleared (the one underfoot clears as it's hopped off)
    if (leftOf(board, nxt.life) <= 1 && leftOf(board, prev.life) > 1) openStar();
    check();
    G.okAt[G.moves.length] = G.feasible;
    sync();
    const stuckNow = !movesOf(board, G.st).length;
    // Blitz: a hop that leaves no full clear is the mistake that stops the run (or getting stuck, if the solver gave up)
    if (blitz && (!G.feasible || stuckNow)) {
      blitzMistake(G.feasible ? 'stuck' : 'mistake');
      return;
    }
    if (stuckNow) {
      goStuck();
      return;
    }
    G.busy = false;
    drain();
  }

  // the ★ opening: a pop, a sparkle and the unlock chime
  function openStar() {
    starPop.setValue(0);
    timing(starPop, 1, 520, Easing.out(Easing.quad)).start();
    const q = standOn(B, board.goal);
    fx.current?.burst('spark', q.x, q.y - B.T * 0.4, q.s / 60);
    sfx.play('sd_unlock');
  }

  // the queued hops (taps and swipes during a hop), one at a time
  function drain() {
    if (G.busy || G.over || !G.queue.length) return;
    G.queue.shift()();
  }
  function input(fn) {
    if (G.over || blocked.current || phaseRef.current !== 'play') return;
    if (G.busy) {
      if (G.queue.length < 2) G.queue.push(fn);
      return;
    }
    fn();
  }

  // a friend hopped onto: a squeak, and off to its place in the goal card
  function collect(cell) {
    const k = board.friends.indexOf(cell);
    const a = friendA[k];
    const c = friends[k];
    if (!a || !c) return;
    sfx.play('sd_squeak');
    const fh = bodyH(c, fw);
    const to = slotAt.current[k];
    // a happy little hop (popping up behind the hopper) with a wiggle, then off to the goal card in a spin
    const q = standOn(B, cell, board.life[cell] === 2 ? PILE_TOP : 0);
    fx.current?.burst('pop', q.x, q.y - fh * (q.s / B.T) * 0.9, q.s / 60);
    a.hap.setValue(0);
    a.liftH.setValue(B.T * 0.5);
    rig('pickup', `f${k}`, to ? to.x : q.x, to ? to.y + to.size / 2 : q.y - B.T * 2, HAP_MS);
    const anims = [timing(a.hap, 1, HAP_MS, Easing.linear), timing(a.shadow, 0, HAP_MS * 0.45, SHADOW_GO)];
    if (to) {
      const p = poseAt(fw, fh, to.x, to.y + to.size / 2, to.size / fw);
      anims.push(timing(a.x, p.x, HAP_MS, FLY), timing(a.y, p.y, HAP_MS, FLY), timing(a.k, p.k, HAP_MS, FLY));
    }
    anims.push(timing(a.o, 0.5, HAP_MS, FLY_FADE));
    Animated.parallel(anims).start(() => {
      a.o.setValue(0);
      if (!alive.current || !(G.st.got & board.fbit[cell])) return;
      G.shown |= board.fbit[cell];
      setShown(G.shown);
      slotPop[k].setValue(0.4);
      Animated.spring(slotPop[k], { toValue: 1, friction: 4, tension: 160, useNativeDriver: true }).start();
    });
  }

  // back to an earlier state: cushions puff back, friends hop back on
  function restoreTo(target, ms) {
    G.st = target;
    cells.forEach((i) => setCell(i, i === board.goal ? 1 : target.life[i]));
    board.friends.forEach((cell, k) => {
      const got = !!(target.got & board.fbit[cell]);
      if (got) return;
      const a = friendA[k];
      const c = friends[k];
      if (!c) return;
      a.x.stopAnimation();
      a.y.stopAnimation();
      a.k.stopAnimation();
      a.o.stopAnimation();
      a.shadow.stopAnimation();
      restPose(a);
      const p = poseOn(cell, fw, bodyH(c, fw), board.life[cell]);
      place(a, { ...p, k: p.k * 0.3 });
      a.shadow.setValue(1);
      if (G.shown & board.fbit[cell]) a.o.setValue(0);
      Animated.parallel([timing(a.k, p.k, 300, Easing.out(Easing.back(1.6))), timing(a.y, p.y, 300, Easing.out(Easing.back(1.6))), timing(a.o, 1, 200)]).start();
      rig('restore', `f${k}`, rigAt(cell, 1, board.life[cell]));
    });
    G.shown &= target.got;
    setShown(G.shown);
    rig('hop', 'p', [{ ...rigAt(target.cur, 2, target.life[target.cur]), ms, h: B.T * 0.5 * (standOn(B, target.cur).s / B.T) }], -1);
    return moveTo(player, pw, ph, target.cur, ms, target.life[target.cur]);
  }

  // the same board again from the start (the hint and the take-backs stay)
  function restart() {
    if (G.st.hops === 0 && !G.over) return;
    G.takebacks += 1;
    fresh.current = false;
    setRound((r) => r + 1);
  }

  // Can every cushion still be cleared? With one full clear (every level from
  // 5), only by following it; on the first few, the solver looks.
  function onSolution() {
    if (G.moves.length > spec.sol.length) return false;
    for (let k = 0; k < G.moves.length; k++) if (G.moves[k] !== spec.sol[k]) return false;
    return true;
  }
  function check() {
    if (spec.sols === 1) {
      G.feasible = onSolution();
      return;
    }
    const r = search(board, G.st, { limit: 60000 });
    G.feasible = !!r.path || r.aborted;
  }

  // --- the hint -------------------------------------------------------------------------------

  function askHint() {
    if (G.won || G.busy || phaseRef.current !== 'play') return;
    if (G.hinted) watchHint();
    else setHintAsk(true);
  }
  function watchHint() {
    setHintAsk(false);
    if (adsFree) {
      later(200, () => acts.current.giveHint());
      return;
    }
    // the ad leaves the app (the pause card comes up); a reward brings the game back
    ad.show(() => {
      setPaused(false);
      later(250, () => acts.current.giveHint());
    });
  }
  // back to the last spot on a full clear (k moves in)
  function rewindTo(k) {
    const back = G.hist.length - k;
    const target = G.hist[k];
    G.hist.length = k;
    G.moves.length = k;
    G.okAt.length = k + 1;
    restoreTo(target, 280);
    return back;
  }
  // The next hop of a full clear: from here if there is one, else after
  // going back to the last spot that had one.
  function giveHint() {
    if (G.won) return;
    if (G.over) {
      G.over = false;
      setStuck(false);
      setPhase('play');
      cheerUp();
    }
    G.hinted = true;
    let back = 0;
    let d = -1;
    if (spec.sols === 1) {
      let k = 0;
      while (k < G.moves.length && G.moves[k] === spec.sol[k]) k++;
      if (k < G.moves.length) back = rewindTo(k);
      d = spec.sol[k];
    } else {
      let r = search(board, G.st, { limit: 300000 });
      for (let k = G.hist.length - 1; !r.path && k >= 0; k--) {
        const t = search(board, G.hist[k], { limit: 300000 });
        if (t.path) {
          back = rewindTo(k);
          r = t;
        }
      }
      if (r.path && r.path.length) d = r.path[0];
    }
    check();
    sync();
    if (d == null || d < 0) return;
    const m = tryMove(board, G.st, d);
    if (!m.ok) return;
    sfx.play('st_hint');
    setGlow(m.cells[0]);
    later(3200, () => setGlow(-1));
    nudge(d, 0.1, 360, back ? 320 : 0);
    later(back ? 320 : 0, () => rig('bump', 'p', DIRS[d][0] * B.T * 0.1, DIRS[d][1] * B.T * 0.06, false));
  }

  // --- the end of a level ------------------------------------------------------------------------

  function win() {
    G.over = true;
    G.won = true;
    G.busy = true;
    if (blitz) clk.pause();
    setPhase('won');
    setWarn(false);
    sync();
    const q = standOn(B, board.goal);
    sfx.play('st_land');
    timing(starGone, 1, 420, Easing.out(Easing.quad)).start();
    fx.current?.burst('spark', q.x, q.y - B.T * 0.5, q.s / 60);
    later(160, () => {
      sfx.play('sd_solve');
      if (!blitz) sfx.play('sd_confetti');
      haptics.win();
      if (!blitz) fx.current?.burst('confetti', q.x, q.y - B.T * 0.6, 1);
      // three happy jumps on the ★, the last one higher with a spin round, sparkles as each lands; the friends
      // cheer in the goal card (all of it over before the result card, at 1.3 s)
      const ms = blitz ? BLITZ_JOY_MS : JOY_MS;
      player.liftH.setValue(B.T * 0.55);
      play(player.joy, ms);
      rig('win', 'p', ms);
      later(ms * 0.26, () => fx.current?.burst('spark', q.x, q.y - B.T * 0.15, q.s / 60));
      later(ms * 0.57, () => fx.current?.burst('spark', q.x, q.y - B.T * 0.15, q.s / 60));
      later(ms * 0.8, () => fx.current?.burst('gold', q.x, q.y - ph * (q.s / B.T) * 0.6 - B.T * 0.77, q.s / 60));
      later(ms * 0.96, () => fx.current?.burst('spark', q.x, q.y - B.T * 0.15, (q.s / 60) * 1.3));
      if (n) play(slotCheer, CHEER_MS);
    });
    if (blitz) {
      // one more cleared; on to the next board
      const i = idxRef.current;
      runRec.current.cleared = i + 1;
      later(300, () => {
        setCleared(i + 1);
        sfx.play('sd_pip', { rate: 0.9 + Math.min(12, i) * 0.05 });
      });
      later(1100, () => {
        sfx.play('sd_blitzNext');
        setIdx(i + 1);
      });
      return;
    }
    const out = afterLevel(profileRef.current, spec, { takebacks: G.takebacks, hinted: G.hinted });
    if (uid) saveHop(uid, out.update, out.coins, out.xp, profileRef.current);
    const { stars, coins, xp, before, after, levelUps, unlocked } = out;
    later(1300, () => setResult({ stars, coins, xp, before, after, levelUps, unlocked, hops: G.moves.length, takebacks: G.takebacks, hinted: G.hinted }));
  }

  function goStuck() {
    G.over = true;
    G.busy = false;
    setPhase('stuck');
    sfx.play('sd_wrong');
    haptics.wrong();
    sadden();
    later(STUCK_CARD_MS, () => {
      if (G.over && !G.won) setStuck(true);
    });
  }

  // --- Blitz: a mistake or the clock, the save, GAME OVER ---------------------------------------------

  function blitzMistake(why) {
    clk.pause();
    G.over = true;
    G.busy = false;
    setPhase('held');
    setWarn(false);
    sfx.play('sd_wrong');
    haptics.wrong();
    sadden();
    later(1000, () => offerSave(why));
  }
  // the board's clock ran out (not mid-hop: a hop under way still counts)
  function timeUp() {
    if (G.busy || G.over || phaseRef.current !== 'play') return;
    clk.pause();
    G.over = true;
    setPhase('held');
    setWarn(false);
    sfx.play('sd_timeUp');
    haptics.wrong();
    sadden();
    later(900, () => offerSave('time'));
  }
  function offerSave(reason) {
    setFailReason(reason);
    setSaveErr(null);
    setBlitzCard('save');
  }
  // The run goes on from the same board: after a mistake, back to the last spot a full clear was still possible from,
  // with the clock running on; after the clock ran out, from where it stood, with the board's clock started again.
  function goOn() {
    setSaving(false);
    setBlitzCard(null);
    sfx.play('sd_revive');
    G.lastSecond = -1;
    setWarn(false);
    cheerUp();
    G.over = false;
    G.queue = [];
    if (failReason !== 'time') {
      // (stuck: at least one hop back, even if the solver had given up on the spot it stopped at)
      let k = Math.min(G.okAt.length - 1, failReason === 'stuck' ? G.moves.length - 1 : G.moves.length);
      while (k > 0 && !G.okAt[k]) k--;
      k = Math.max(0, k);
      if (k < G.moves.length) {
        const target = G.hist[k];
        G.hist.length = k;
        G.moves.length = k;
        G.busy = true;
        restoreTo(target, 280).then(() => {
          G.busy = false;
          drain();
        });
      }
      G.okAt.length = k + 1;
      G.feasible = true;
      sync();
    }
    setPhase('play');
    if (failReason === 'time') clk.start(spec.ms);
    else clk.resume();
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
  // Pays the run out once (the boards it cleared) and saves the record. Also when the player quits or starts over in
  // the middle of a run, so cleared boards always count.
  function payOut() {
    const R = runRec.current;
    if (!blitz || !R.started || R.ended) return null;
    R.ended = true;
    const out = afterBlitz(profileRef.current, { cleared: R.cleared });
    if (uid) saveHop(uid, out.update, out.coins, out.xp, profileRef.current);
    return out;
  }
  function endRun() {
    clk.pause();
    G.over = true;
    setPhase('held');
    const top = record(profileRef.current).blitz.top;
    const n = runRec.current.cleared;
    const out = payOut() || { coins: 0, xp: 0, levelUps: [], newTop: false };
    const res = { ...out, cleared: n, best: Math.max(top, n) };
    setOver(res);
    setBlitzCard('over');
    if (res.newTop) {
      sfx.play('sd_blitzWin');
      haptics.win();
      if (root) [0, 300, 600].forEach((d, i) => later(d, () => fxTop.current?.burst('confetti', root.w * (0.25 + 0.25 * i), root.h * 0.3, 1)));
    } else {
      sfx.play('sd_blitzFail');
      later(600, () => sfx.play('sd_drain'));
    }
  }
  // a fresh run from board 1 (the one before is paid out first)
  function again() {
    payOut();
    clearTimers();
    clk.reset();
    runRec.current = { started: false, ended: false, cleared: 0 };
    setBlitzCard(null);
    setOver(null);
    setAdUsed(false);
    setGemSaves(0);
    setSaving(false);
    setSaveErr(null);
    setCleared(0);
    setCount(null);
    setPaused(false);
    setWarn(false);
    setIdx(0);
    setRun((r) => r + 1);
  }

  // --- a new go at the level ------------------------------------------------------------------------

  const phaseRef = useRef(phase);
  phaseRef.current = phase;
  // a new go: a new level or round (Blitz: a new board), once the board has a place on screen
  const goKey = B && hopper ? (blitz ? `b${run}:${idx}` : `${lv}:${round}`) : '';
  useEffect(() => {
    if (!goKey) return undefined;
    clearTimers();
    const forget = fresh.current;
    fresh.current = true;
    G.go = goKey;
    G.B = B;
    G.st = newState(board);
    G.hist = [];
    G.moves = [];
    G.okAt = [true];
    if (forget) {
      G.hinted = false;
      G.takebacks = 0;
    }
    G.over = false;
    G.won = false;
    G.busy = false;
    G.queue = [];
    G.shown = 0;
    G.lastSecond = -1;
    G.life = board.life.slice();
    check();
    sync();
    setShown(0);
    setResult(null);
    setStuck(false);
    setPaused(false);
    setHintAsk(false);
    setGlow(-1);
    // everything hidden, ready to come in
    cells.forEach((i) => {
      cellA[i].a0.setValue(0);
      cellA[i].a1.setValue(0);
      if (bubbleA[i]) bubbleA[i].setValue(0);
    });
    starPop.setValue(0);
    starGone.setValue(0);
    player.o.setValue(0);
    friendA.forEach((a) => a.o.setValue(0));
    // the board fluffs in, back to front; the hopper drops in, the friends pop up
    const enter = () => {
      cells.forEach((i) => {
        const A = cellA[i];
        const d = ((i % board.w) + Math.floor(i / board.w)) * 24;
        timing(A.a0, 1, 300, Easing.out(Easing.back(1.4)), d).start();
        if (board.life[i] === 2) timing(A.a1, 1, 300, Easing.out(Easing.back(1.4)), d + 70).start();
        const bub = bubbleA[i];
        if (bub) timing(bub, 1, 260, Easing.out(Easing.quad), 360).start();
      });
      const p = poseOn(board.start, pw, ph, board.life[board.start]);
      setPlayerZ(zOf(board.start, 2));
      restPose(player);
      setMood(null);
      player.shadow.setValue(1);
      place(player, { ...p, y: p.y - B.T * 1.2 });
      player.o.setValue(0);
      Animated.parallel([timing(player.y, p.y, 420, Easing.out(Easing.back(1.5)), 260), timing(player.o, 1, 160, Easing.linear, 260)]).start();
      board.friends.forEach((cell, k) => {
        const a = friendA[k];
        const c = friends[k];
        if (!c) return;
        const q = poseOn(cell, fw, bodyH(c, fw), board.life[cell]);
        place(a, { ...q, k: q.k * 0.3 });
        a.o.setValue(0);
        a.shadow.stopAnimation();
        a.shadow.setValue(1);
        restPose(a);
        Animated.parallel([timing(a.k, q.k, 320, Easing.out(Easing.back(1.6)), 320 + k * 90), timing(a.y, q.y, 320, Easing.out(Easing.back(1.6)), 320 + k * 90), timing(a.o, 1, 160, Easing.linear, 320 + k * 90)]).start();
        slotPop[k].setValue(1);
      });
      sfx.play('sd_boardIn');
      // the rigs: everyone in place, then the hopper drops in and the friends pop up as the cut-outs do
      sendCast();
      rig('enter', 'p', rigAt(board.start, 2, board.life[board.start]), 260, false);
      board.friends.forEach((cell, k) => friends[k] && rig('enter', `f${k}`, rigAt(cell, 1, board.life[cell]), 320 + k * 90, true));
    };
    if (blitz) {
      // Blitz: no hops until the board's clock starts; the run's first board drops in on GO
      setPhase('intro');
      setWarn(false);
      setLabel(clock(spec.ms));
      clk.reset();
      const startClock = () => {
        runRec.current.started = true;
        setPhase('play');
        clk.start(spec.ms);
      };
      if (!runRec.current.started) {
        [3, 2, 1, 'GO!'].forEach((n, i) =>
          later(200 + i * 700, () => {
            setCount(n);
            sfx.play(n === 'GO!' ? 'sd_go' : 'sd_count');
            haptics.tick();
            if (n === 'GO!') enter();
          }),
        );
        later(200 + 4 * 700, () => setCount(null));
        later(200 + 3 * 700 + 760, startClock);
      } else {
        enter();
        say(`BOARD ${spec.lv}`, { chips: [spec.size, `⏱ ${clock(spec.ms)}`], hold: 700 });
        later(760, startClock);
      }
    } else {
      enter();
      setPhase('play');
    }
    if (!blitz && forget) {
      say(`LEVEL ${spec.lv}`, { chips: [TIER_NAMES[spec.tier], room.name.toUpperCase()], hold: 800 });
      const news = spec.news && !record(profileRef.current).best[spec.lv] ? TWISTS[spec.news] : null;
      if (news)
        later(1500, () => {
          sfx.play('st_news');
          say(news.text, { small: true, sub: news.sub, hold: 1700, ink: '#0c5a9c' });
        });
    }
    // where the goal card's slots are (for the friends flying there)
    later(450, measureSlots);
    return undefined;
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [goKey]);

  // Blitz: the board's clock (its last seconds tick; at 0, TIME'S UP)
  useEffect(() => {
    if (!blitz || phase !== 'play' || paused) return undefined;
    const id = setInterval(() => {
      const rest = clk.limit() - clk.elapsed();
      setLabel(clock(rest));
      const sec = Math.ceil(rest / 1000);
      if (rest <= HURRY_MS && rest > 0 && sec !== G.lastSecond) {
        G.lastSecond = sec;
        sfx.play('sd_tick', { rate: sec <= 3 ? 1.3 : 1 });
        setWarn(true);
      }
      if (rest <= 0) acts.current.timeUp();
    }, 150);
    return () => clearInterval(id);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [phase, paused]);

  // The board moved mid-go (the screen's layout changed): everyone back in
  // place, nothing restarted.
  useEffect(() => {
    if (!B || !hopper || !G.B || G.B === B || G.go !== goKey) return;
    const moved = B.T !== G.B.T || Math.abs(B.cx - G.B.cx) > 1 || Math.abs(B.cy - G.B.cy) > 1;
    G.B = B;
    if (!moved) return;
    const life = G.st.life;
    place(player, poseOn(G.st.cur, pw, ph, life[G.st.cur]));
    board.friends.forEach((cell, k) => {
      const c = friends[k];
      if (c && !(G.st.got & board.fbit[cell])) place(friendA[k], poseOn(cell, fw, bodyH(c, fw), life[cell]));
    });
    sendCast();
    later(100, measureSlots);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [B]);

  // each slot against the board area, measured together (so a slide still
  // going moves both alike)
  function measureSlots() {
    areaRef.current?.measure((ax, ay, aw, ah, apx, apy) => {
      slotOrder.forEach((k) => {
        const r = slotRefs.current[k];
        if (!r) return;
        r.measure((x, y, w, h, px, py) => {
          slotAt.current[k] = { x: px - apx + w / 2, y: py - apy + h / 2, size: w };
        });
      });
    });
  }

  // --- moving on, pausing and leaving -----------------------------------------------------------------

  const goTo = useCallback(
    (n) => {
      const to = Math.max(1, Math.min(LEVELS, n));
      fresh.current = true;
      if (stageOf(to).key === stageOf(lv).key || to === lv) {
        if (to === lv) setRound((r) => r + 1);
        else setLv(to);
        return;
      }
      // a new room (or time of day): the Crib's room-switch flash
      sfx.play('swoosh');
      timing(flash, 1, 200, Easing.linear).start(() => {
        setLv(to);
        setTimeout(() => timing(flash, 0, 320, Easing.linear, 120).start(), 30);
      });
    },
    [lv, flash],
  );
  function pause() {
    if (blocked.current || phaseRef.current !== 'play') return;
    if (blitz) {
      clk.pause();
      sfx.play('sd_pause');
    }
    setPaused(true);
  }
  function resume() {
    setPaused(false);
    if (blitz && phaseRef.current === 'play') clk.resume();
  }
  function leave() {
    payOut();
    clk.pause();
    clearTimers();
    onExit();
  }
  function retry() {
    const p = profileRef.current;
    if (uid) saveHop(uid, afterStuck(p), 0);
    setStuck(false);
    G.takebacks += 1;
    fresh.current = false;
    setRound((r) => r + 1);
  }

  // the rig page is up (send it the board), or it has drawn a cast (or couldn't: its art didn't load)
  const onRigReady = useCallback(() => acts.current.sendCast(), []);
  const onRigCast = useCallback((m) => {
    if (m.ok) setRigTag(m.tag);
    else console.warn('[hop rig] no rig for', m.key, '- cut-outs instead');
  }, []);
  const acts = useRef({});
  acts.current = { sendCast, tryDir, input, restart, askHint, watchHint, giveHint, pause, resume, leave, retry, timeUp, goOn, saveByAd, saveByGems, endRun, again, wiggle: () => {
      play(player.wig, 380);
      rig('giggle', 'p');
    },
  };
  // web, development only: the browser tests hop without finding the cushions on screen (src/web/README.md)
  if (__DEV__ && typeof window !== 'undefined' && window.document) {
    window.__hop = { sol: spec.sol, hop: (d) => acts.current.input(() => acts.current.tryDir(d)), state: () => ({ phase: phaseRef.current, moves: G.moves.length, feasible: G.feasible, takebacks: G.takebacks }) };
  }

  useEffect(() => {
    const sub = BackHandler.addEventListener('hardwareBackPress', () => {
      if (hintAsk) setHintAsk(false);
      else if (paused) acts.current.resume();
      else if (blitzCard === 'save') acts.current.endRun();
      else if (result || stuck || blitzCard === 'over') acts.current.leave();
      else if (blitz && phaseRef.current !== 'play') return true;
      else acts.current.pause();
      return true;
    });
    return () => sub.remove();
  }, [hintAsk, paused, result, stuck, blitzCard, blitz]);
  useEffect(() => {
    const sub = AppState.addEventListener('change', (s) => s !== 'active' && acts.current.pause());
    return () => sub.remove();
  }, []);

  // --- touch: swipes (a hop each half a tile of drag, so a long one can turn
  // corners) and taps on a cushion next to the squishy ---------------------------------------------
  const live = useRef({});
  live.current = { B, cur: G.st.cur, board };
  const touch = useRef(null);
  const responder = useMemo(
    () =>
      PanResponder.create({
        onStartShouldSetPanResponder: () => true,
        onMoveShouldSetPanResponder: () => true,
        onPanResponderTerminationRequest: () => false,
        // where the finger went down on the board (everything on it lets
        // touches through, so the area is always the target), then how far
        // it has moved since (the gesture's own dx, dy)
        onPanResponderGrant: (e) => {
          const { locationX: x, locationY: y } = e.nativeEvent;
          touch.current = { x0: x, y0: y, gx: 0, gy: 0, moved: false };
        },
        onPanResponderMove: (e, g) => {
          const T = touch.current;
          const { B: b } = live.current;
          if (!T || !b) return;
          const dx = g.dx - T.gx;
          const dy = g.dy - T.gy;
          if (Math.max(Math.abs(dx), Math.abs(dy)) < Math.max(24, b.T * 0.45)) return;
          T.moved = true;
          T.gx = g.dx;
          T.gy = g.dy;
          const d = Math.abs(dx) > Math.abs(dy) ? (dx > 0 ? 1 : 3) : dy > 0 ? 2 : 0;
          acts.current.input(() => acts.current.tryDir(d));
        },
        onPanResponderRelease: (e, g) => {
          const T = touch.current;
          touch.current = null;
          const { B: b, board: bd } = live.current;
          if (!T || !b) return;
          // a quick flick can end before any move event got a hop's worth
          // away: if it went most of the way, it's a hop
          const { dx, dy } = g;
          if (!T.moved && Math.max(Math.abs(dx), Math.abs(dy)) >= Math.max(24, b.T * 0.45) * 0.6) {
            const d = Math.abs(dx) > Math.abs(dy) ? (dx > 0 ? 1 : 3) : dy > 0 ? 2 : 0;
            acts.current.input(() => acts.current.tryDir(d));
            return;
          }
          if (T.moved || Math.hypot(g.dx, g.dy) > 12) return;
          const cur = G.st.cur;
          const j = cellAt(b, T.x0, T.y0);
          if (j === cur) {
            sfx.play('sd_squeak');
            acts.current.wiggle();
            return;
          }
          if (j < 0) return;
          const [px, py] = [cur % bd.w, Math.floor(cur / bd.w)];
          const [jx, jy] = [j % bd.w, Math.floor(j / bd.w)];
          if (Math.abs(jx - px) + Math.abs(jy - py) !== 1) return;
          const d = jy < py ? 0 : jx > px ? 1 : jy > py ? 2 : 3;
          acts.current.input(() => acts.current.tryDir(d));
        },
        onPanResponderTerminate: () => {
          touch.current = null;
        },
      }),
    // eslint-disable-next-line react-hooks/exhaustive-deps
    [],
  );

  // --- drawing ---------------------------------------------------------------------------------------

  const n = board.friends.length;
  // the cushions still to clear before the ★ opens (the one underfoot clears as it's hopped off)
  const toOpen = Math.max(0, view.left - 1);
  // the stars still possible: off a full clear, it takes at least one more RESTART
  const can = starsFor(view.takebacks + (view.feasible ? 0 : 1), view.hinted);
  // Blitz: the best run so far, and whether this one has beaten it
  const bestRun = record(profile).blitz.top;
  const beat = blitz && cleared > bestRun && bestRun > 0;
  const barW = root ? 124 : 200;
  const nextBeat = (view.hops + 1) % 3;
  const slotSize = n > 4 ? 19 : n > 2 ? 21 : n > 1 ? 24 : 27;
  // (2026-11-21, on the phone "the distance between the widgets gets destroyed": the A15 gives the app 796 dp, not the
  // 852 this was laid out at, and the board ran edge to edge between a 250 dp column and the buttons) the left column
  // is only as wide as its goal card needs (the stars and the BEAT pill on one line), so the board gets the room; Blitz
  // keeps one width for the run (its boards gain friends as it goes)
  const leftW = blitz ? 230 : 10 + Math.max(spec.beats ? 186 : 156, goalCardW(n, slotSize) + 16);
  const playing = phase === 'play' && !paused;
  const shakeX = useMemo(() => shake.interpolate({ inputRange: [0, 0.25, 0.5, 0.75, 1], outputRange: [0, -6, 6, -3, 0] }), [shake]);
  const beatShakeX = useMemo(() => beatShake.interpolate({ inputRange: [0, 0.25, 0.5, 0.75, 1], outputRange: [0, -6, 6, -3, 0] }), [beatShake]);
  // the arrow keys hop as a swipe would; the one the hint points (its glowing cushion is next to the squishy) is gold
  const onDir = useCallback((d) => acts.current.input(() => acts.current.tryDir(d)), []);
  const hintDir = glow >= 0 ? DIRS.findIndex(([dx, dy]) => view.cur + dx + dy * board.w === glow) : -1;
  // no full clear left from here: RESTART throbs
  const stranded = !blitz && !view.feasible && phase === 'play';

  // (REDESIGN_V8, the games sideways) the top bar and the goal strip in a column on the left with the arrow keys at its
  // bottom, the board in the middle on the room's floor, RESTART / HINT at the bottom right (2026-11-17)
  const hudEl = (
    <>
      {/* the Crib's top bar: back and the room's title */}
      <View style={styles.hud}>
        <CribButton
          face="orange"
          icon={blitz && phase === 'play' ? 'pause' : 'back'}
          size={44}
          onPress={() => (phaseRef.current === 'play' ? acts.current.pause() : blitz && phaseRef.current !== 'won' && !blitzCard ? null : acts.current.leave())}
        />
        <View style={styles.titleBox}>
          <RoomTitle title={blitz ? 'Blitz Mode' : room.name} />
          {/* (no "SQUISH HOP · LEVEL n" line: the user, 2026-11-17; the level's number shows in its banner as it starts) */}
          {blitz ? null : (
            <View style={styles.subRow}>
              <View style={[styles.tier, { backgroundColor: TIER_COLORS[spec.tier] }]}>
                <Text style={styles.tierText}>{TIER_NAMES[spec.tier]}</Text>
              </View>
            </View>
          )}
        </View>
      </View>
    </>
  );
  const areaEl = (
    <>
      {/* the board on the floor */}
      <View ref={areaRef} collapsable={false} style={styles.area} onLayout={onArea} {...responder.panHandlers}>
        {B && hopper ? (
          // (Blitz: hidden while paused, and during the countdown until GO drops the board in)
          <View pointerEvents="none" style={[StyleSheet.absoluteFill, { opacity: blitz && (paused || (count != null && count !== 'GO!')) ? 0 : 1 }]}>
            {room.rug ? <Rug B={B} /> : null}
            <Under B={B} cells={cells} dance={!!room.dance} dent={room.dent} width={area.w} height={area.h} />
            {cells.map((i) => (
              <Tile key={`${tag}:${i}`} B={B} i={i} look={board.beat[i] >= 0 && board.beat[i] === nextBeat ? looks[i].on : looks[i].off} a0={cellA[i].a0} a1={cellA[i].a1} />
            ))}
            {glow >= 0 ? <HintGlow key={`g${glow}`} B={B} i={glow} z={G.life[glow] === 2 ? PILE_TOP : 0} /> : null}
            <View pointerEvents="none" style={StyleSheet.absoluteFill}>
              {cells
                .filter((i) => board.bubble[i])
                .map((i) => (
                  <View key={`b${tag}:${i}`} style={{ position: 'absolute', left: 0, top: 0, right: 0, bottom: 0, zIndex: zOf(i, 0) }} pointerEvents="none">
                    <Bubble B={B} i={i} a={bubbleA[i]} />
                  </View>
                ))}
              <GoalStar key={`s${tag}`} B={B} i={board.goal} left={toOpen} pop={starPop} gone={starGone} z={zOf(board.goal, 0)} />
              {board.friends.map((cell, k) =>
                friends[k] && !rigsOn ? <Piece key={`f${tag}:${k}`} c={friends[k]} w={fw} h={bodyH(friends[k], fw)} a={friendA[k]} z={zOf(cell, 1)} shade={room.dance ? 'rgba(255,255,255,0.3)' : 'rgba(69,16,122,0.28)'} friend delay={k * 900} /> : null,
              )}
              {rigsOn ? null : <Piece c={hopper} w={pw} h={ph} a={player} z={playerZ} shade={room.dance ? 'rgba(255,255,255,0.3)' : 'rgba(69,16,122,0.28)'} mood={mood} />}
            </View>
            {/* the characters as live rigs, over the board and as big as the screen (a friend flies to the goal card) */}
            {root ? <RigStage ref={stage} style={{ position: 'absolute', left: -(area.x || 0), top: -area.y, width: root.w, height: root.h }} paused={paused} onReady={onRigReady} onCast={onRigCast} /> : null}
            {/* numbered friends' chips, over everything so the order can be read */}
            {board.friends.map((cell, k) => {
              if (!board.order[cell] || G.st.got & board.fbit[cell] || !friends[k]) return null;
              const q = standOn(B, cell, board.life[cell] === 2 ? PILE_TOP : 0);
              const hh = bodyH(friends[k], fw) * (q.s / B.T);
              return <OrderChip key={`o${tag}:${k}`} n={board.order[cell]} x={q.x + fw * (q.s / B.T) * 0.42} y={q.y - hh * 0.9} size={Math.max(18, q.s * 0.3)} />;
            })}
            <Banner banner={banner} top={4} />
            <FxLayer ref={fx} />
          </View>
        ) : null}
        {count != null ? <Countdown value={count} /> : null}
      </View>
    </>
  );
  const stripEl = (
    <>
      {/* the goal as pictures (the user, 2026-11-17: "make it simple with UI not text"): the cushions still to clear
          with their count (a tick once they're all gone), the friends to pick up, then the ★; under it the stars still
          possible (Blitz: the boards cleared and the best run) */}
      <View style={styles.strip}>
        <Animated.View style={[styles.goalCard, { transform: [{ translateX: shakeX }] }]}>
          <Text style={styles.goalLabel}>GOAL</Text>
          <View style={styles.goalRow}>
            <View style={styles.miniGoal}>
              {room.dance ? <View style={[styles.miniTile, styles.miniTileLeft]} /> : <FlatCushion size={34} col="lilac" id="hopLeft" />}
              <View style={[styles.leftBadge, toOpen === 0 && styles.leftDone]}>
                <Text style={styles.leftBadgeText}>{toOpen === 0 ? '✓' : toOpen}</Text>
              </View>
            </View>
            {slotOrder.map((k) =>
              friends[k] ? <Slot key={`${tag}:${k}`} c={friends[k]} size={slotSize} got={!!(shown & board.fbit[board.friends[k]])} n={board.order[board.friends[k]] || 0} pop={slotPop[k]} cheer={slotCheer} idx={k} onRef={(r) => (slotRefs.current[k] = r)} /> : null,
            )}
            <Text style={styles.goalArrow}>›</Text>
            <View style={styles.miniGoal}>
              {room.dance ? <View style={styles.miniTile} /> : <FlatCushion size={34} col="peach" id="hopMini" />}
              <View style={styles.miniStar}>
                <Star size={19} shut={toOpen > 0} />
              </View>
            </View>
          </View>
        </Animated.View>
        <View style={styles.stripRight}>
          {blitz ? (
            // Blitz: the boards cleared this run, and the best run (gold once it's beaten)
            <View style={styles.meterRow}>
              <View style={styles.pill}>
                <Text style={styles.pillText}>{`CLEARED ${cleared}`}</Text>
              </View>
              <View style={[styles.pill, styles.hopsPill, beat && styles.bestPill]}>
                <Text style={[styles.pillText, { color: beat ? '#ffffff' : '#5b3a29' }]}>{`${beat ? 'NEW BEST' : 'BEST'} ${Math.max(bestRun, cleared)}`}</Text>
              </View>
              {spec.beats ? <BeatPill next={nextBeat} shakeX={beatShakeX} /> : null}
            </View>
          ) : (
            <View style={styles.meterRow}>
              <Meter stars={can} />
              {spec.beats ? <BeatPill next={nextBeat} shakeX={beatShakeX} /> : null}
            </View>
          )}
        </View>
      </View>
    </>
  );
  const padEl = <DPad onDir={onDir} lit={hintDir} />;
  const ctrlEl = blitz ? (
    <>
      {/* Blitz: the rule and the board's clock, on the Crib's glass */}
      <View style={styles.glass}>
        <Chip bg="#e01e4a" color="#ffffff">
          1 MISTAKE = GAME OVER
        </Chip>
        <TimerBar frac={clk.frac} width={barW} warn={warn} label={label} />
      </View>
    </>
  ) : (
    <>
      {/* restart, hint (no UNDO: the user, 2026-11-17), at the bottom (the user, 2026-11-17); RESTART throbs once the
          board can't be cleared from here (it was a line of text) */}
      <View style={styles.controls}>
        <Pulse on={stranded}>
          <SdButton kind="purple" onPress={() => acts.current.restart()} disabled={!(playing || phase === 'stuck') || view.hops === 0} sound="sd_select" faceStyle={styles.ctrlFace}>
            <BtnLabel kind="purple" size={15}>
              RESTART
            </BtnLabel>
          </SdButton>
        </Pulse>
        <SdButton kind="gold" onPress={() => acts.current.askHint()} disabled={!playing || (view.hinted && !adsFree && !ad.ready)} sound="sd_select" faceStyle={styles.ctrlFace}>
          <BtnLabel kind="gold" size={15}>
            {adsFree ? 'HINT' : '▶ HINT'}
          </BtnLabel>
        </SdButton>
      </View>
    </>
  );
  return (
    <View style={styles.fill} onLayout={onRoot}>
      {root ? <Room room={spec.room} phase={spec.phase} width={root.w} height={root.h} /> : null}
      <View style={styles.row}>
        <View style={[styles.left, { width: leftW }]}>
          {hudEl}
          {stripEl}
          <View style={styles.fill} />
          {padEl}
        </View>
        {areaEl}
        <View style={[styles.right, !blitz && styles.rightLow]}>{ctrlEl}</View>
      </View>

      {blitz ? (
        <>
          <PauseCard visible={paused} onResume={() => acts.current.resume()} onQuit={() => acts.current.leave()} />
          <BlitzSaveCard
            visible={blitzCard === 'save'}
            reason={failReason}
            why={failReason === 'mistake' ? `That hop left ${room.dance ? 'tile' : 'cushion'}s you can't clear.` : failReason === 'stuck' ? 'Nowhere left to hop.' : null}
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
          <BlitzOverCard visible={blitzCard === 'over'} res={over} onAgain={() => acts.current.again()} onQuit={() => acts.current.leave()} />
          <FxLayer ref={fxTop} style={styles.fxTop} />
        </>
      ) : (
        <>
          <ResultCard visible={!!result} res={result} titles={RESULT_TITLES} keys={trio} last={lv >= LEVELS} onNext={() => goTo(lv + 1)} onReplay={() => goTo(lv)} onBack={() => acts.current.leave()} />
          <StuckCard
            visible={stuck}
            who={hopper}
            shut={board.nbrs[view.cur].includes(board.goal) && toOpen > 0}
            onRetry={() => acts.current.retry()}
          />
          <PauseCard visible={paused} onResume={() => setPaused(false)} onQuit={() => acts.current.leave()} />
          <HintCard visible={hintAsk} adReady={ad.ready} adsFree={adsFree} onWatch={() => acts.current.watchHint()} onClose={() => setHintAsk(false)} />
        </>
      )}

      <Animated.View pointerEvents="none" style={[StyleSheet.absoluteFill, { opacity: flash }]}>
        <RoomFlash />
      </Animated.View>
    </View>
  );
}

const GLASS = 'rgba(91,58,41,0.75)';
// the goal card's width with n friends of `slot` points: its two cushions, the friends and the › with the row's 3-point
// gaps, then its padding and border (styles.goalCard, goalRow, miniGoal)
const goalCardW = (n, slot) => Math.max(104, 36 * 2 + n * slot + 8 + (n + 2) * 3 + 16);
const styles = StyleSheet.create({
  // the top bar, the goal and the arrow keys on the left (its width: leftW), the board, the buttons (Blitz: the rule
  // and the clock) right
  row: { flex: 1, flexDirection: 'row' },
  left: { paddingTop: 8, paddingLeft: 10, paddingBottom: 8, gap: 8, zIndex: 3 },
  right: { width: 150, justifyContent: 'center', zIndex: 3 },
  rightLow: { width: 138, justifyContent: 'flex-end', paddingBottom: 10 },
  fill: { flex: 1 },
  hud: { flexDirection: 'row', alignItems: 'center', gap: 8, zIndex: 3 },
  titleBox: { flex: 1, minWidth: 0 },
  subRow: { flexDirection: 'row', alignItems: 'center', gap: 6, marginTop: -2 },
  tier: { paddingHorizontal: 6, borderRadius: 999, borderWidth: 2, borderColor: '#ffffff' },
  tierText: { fontFamily: F.display, fontSize: 9.5, letterSpacing: 0.6, color: '#ffffff' },
  area: { flex: 1, zIndex: 2 },
  strip: { flexDirection: 'column', alignItems: 'stretch', gap: 8, marginTop: 4, padding: 6, borderRadius: 20, backgroundColor: GLASS, borderWidth: 2, borderColor: 'rgba(255,255,255,0.9)', zIndex: 1 },
  goalCard: { minWidth: 104, flexShrink: 0, backgroundColor: 'rgba(255,255,255,0.95)', borderRadius: 15, borderWidth: 3, borderColor: '#ffffff', paddingHorizontal: 5, paddingTop: 1, paddingBottom: 4, alignItems: 'center' },
  goalLabel: { fontFamily: F.display, fontSize: 10.5, letterSpacing: 1.2, color: '#6b3fa0', includeFontPadding: false },
  goalRow: { flex: 1, flexDirection: 'row', alignItems: 'center', justifyContent: 'center', gap: 3, paddingTop: 3 },
  goalArrow: { fontFamily: F.display, fontSize: 14, color: '#b9a6cc', includeFontPadding: false },
  miniGoal: { width: 36, height: 38, alignItems: 'center', justifyContent: 'center' },
  miniTile: { width: 30, height: 30, borderRadius: 5, backgroundColor: '#ffffff', borderWidth: 2, borderColor: '#140818' },
  miniTileLeft: { backgroundColor: '#5cf2c8' },
  miniStar: { position: 'absolute', left: 8.5, top: 7 },
  // the cushions still to clear, on the goal card's first cushion (a tick once they're gone)
  leftBadge: { position: 'absolute', right: -4, top: -3, minWidth: 20, height: 20, paddingHorizontal: 3, borderRadius: 10, backgroundColor: '#6b3fa0', borderWidth: 2, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  leftDone: { backgroundColor: '#16a86a' },
  leftBadgeText: { fontFamily: F.display, fontSize: 11, color: '#ffffff', includeFontPadding: false, fontVariant: ['tabular-nums'] },
  sticker: { backgroundColor: '#ffffff', padding: 2 },
  stickerDim: { backgroundColor: 'rgba(255,255,255,0.55)' },
  stickerIn: { flex: 1, borderRadius: 999, backgroundColor: '#f6efff', overflow: 'hidden', alignItems: 'center', justifyContent: 'center' },
  stickerImg: { width: '94%', height: '94%', resizeMode: 'contain' },
  slotNum: { position: 'absolute', right: -5, top: -5, minWidth: 14, height: 14, paddingHorizontal: 2, borderRadius: 7, backgroundColor: '#ff8a3d', borderWidth: 1.5, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  slotNumText: { fontFamily: F.display, fontSize: 8.5, color: '#ffffff', includeFontPadding: false },
  stripRight: { flex: 1, minWidth: 0, justifyContent: 'center', gap: 5 },
  meterRow: { flexDirection: 'row', alignItems: 'center', flexWrap: 'wrap', gap: 6 },
  meter: { flexDirection: 'row', alignItems: 'flex-start', gap: 1 },
  pill: { paddingHorizontal: 8, paddingVertical: 1, borderRadius: 999, backgroundColor: '#ffffff', borderWidth: 2.5, borderColor: '#ffd23a' },
  hopsPill: { borderColor: '#ffe6b8' },
  pillText: { fontFamily: F.display, fontSize: 12, color: '#b86200', letterSpacing: 0.5, fontVariant: ['tabular-nums'], includeFontPadding: false },
  beatPill: { flexDirection: 'row', alignItems: 'center', gap: 4, borderColor: '#ff5c8a' },
  beatDot: { width: 9, height: 9, borderRadius: 3, opacity: 0.5 },
  beatNow: { width: 13, height: 13, opacity: 1, borderWidth: 2, borderColor: '#ffffff' },
  // RESTART over HINT
  controls: { alignItems: 'stretch', gap: 10, paddingRight: 12, paddingLeft: 6, zIndex: 1 },
  ctrlFace: { paddingHorizontal: 6, paddingVertical: 10 },
  // the arrow keys: a cross of four, each key KEY_W × KEY_H with its lip (the rows overlap by the lip's shadow)
  pad: { width: KEY_W * 3 - 4, height: KEY_H * 3 - 12, zIndex: 3 },
  key: { position: 'absolute', width: KEY_W },
  keyFace: { height: 32, paddingHorizontal: 0, paddingVertical: 0 },
  // Blitz: the rule and the clock on the glass, and the best pill once it's beaten
  glass: { alignSelf: 'stretch', alignItems: 'center', gap: 8, marginHorizontal: 10, marginTop: 6, paddingHorizontal: 12, paddingVertical: 8, borderRadius: 20, backgroundColor: GLASS, borderWidth: 2, borderColor: 'rgba(255,255,255,0.9)', zIndex: 1 },
  bestPill: { backgroundColor: '#ffb02e', borderColor: '#ffffff' },
  // the cards sit at elevation 50 (squishdoku/Overlays.js)
  fxTop: { zIndex: 60, elevation: 60 },
});
