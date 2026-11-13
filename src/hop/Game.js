import React, { memo, useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { Animated, AppState, BackHandler, Easing, Image, PanResponder, StyleSheet, Text, View } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import Svg, { Path } from 'react-native-svg';
import useRewardedAd from '../components/useRewardedAd';
import sfx from '../audio/sfx';
import { FxLayer } from '../squishdoku/fx';
import { makeHaptics } from '../squishdoku/game';
import { BtnLabel, Head, SdButton } from '../squishdoku/ui';
import { F } from '../squishdoku/theme';
import { Banner } from '../sort/Game';
import { CribButton, PhasePill, RoomFlash, RoomTitle } from '../crib/Hud';
import { PH } from '../crib/data';
import { saveHop } from '../firebase/firestore';
import { bodyH } from '../stack/Pieces';
import { DIRS, leftOf, moves as movesOf, newState, search, tryMove } from './engine';
import { LEVELS, ROOMS, TIER_COLORS, TIER_NAMES, TWISTS, afterLevel, afterStuck, levelSpec, record, stageOf } from './levels';
import { DEPTH, cellAt, layout, standOn } from './board';
import { BEAT_COL, BEAT_NAMES, Bubble, FlatCushion, GoalStar, HintGlow, OrderChip, PILE_TOP, Piece, Star, Tile, Under, freshPose, poseAt } from './Pieces';
import Room, { roomGeometry } from './Room';
import { friendsOf, headOf, hopperOf } from './roster';
import { HintCard, PauseCard, ResultCard, StuckCard } from './Cards';

// One level of Squish Hop (SQUISH_HOP.md), and the next ones after it. The
// squishy hops across cushions on the floor of one of the Crib's rooms; the
// cushion it hops off puffs away, so it can never go back. It has to reach
// the ★ cushion, and clearing every other cushion first gives 3 stars.
// Swipe (a long drag can turn corners) or tap a cushion next to it. The
// rules are engine.js, the board's perspective board.js; this draws and
// animates them.

const LOAD_SOUNDS = ['st_lift', 'st_land', 'st_undo', 'st_hint', 'st_news', 'fs_pop', 'tap', 'bonk', 'sd_squeak', 'sd_unlock', 'sd_wrong', 'sd_solve', 'sd_confetti', 'sd_boardIn', 'swoosh'];

// why a hop bumped, said in the tip line
const WHY = {
  arrow: 'Arrow cushions only let you hop off the way they point.',
  bounce: 'That bubble has nowhere to bounce you.',
  order: 'Pick up the friends in order: 1, 2, 3…',
  beat: "That tile isn't lit on this hop. Wait for its beat!",
  locked: 'Pick up every friend first. Then the ★ opens!',
};

const RUG = require('../../assets/crib/fixtures/living-rug.webp');
const PLAYER_W = 0.86; // the hopper's body, in tiles
const FRIEND_W = 0.72;
const popcount = (n) => {
  let c = 0;
  while (n) {
    c += n & 1;
    n >>= 1;
  }
  return c;
};

// The line under the stars: what to do, or why 3 stars are gone.
function tipFor(spec, s, room) {
  const what = room.dance ? 'tile' : 'cushion';
  const all = spec.board.all;
  if (!s.feasible) return `Some ${what}s can't be cleared now. UNDO to go for 3 stars!`;
  if (spec.lv === 1 && s.hops === 0) return 'Swipe, or tap a cushion next to you, to hop.';
  if (spec.lv === 1) return 'Cushions puff away behind you. Clear them all, then hop onto the ★!';
  if (spec.news === 'friends' && s.got !== all) return 'Pick up the friend. The ★ opens when everyone is with you.';
  if (spec.news === 'arrows') return 'Arrow cushions: you can only hop off them the way they point.';
  if (spec.news === 'bubbles') return 'Hop onto a bubble and it bounces you one cushion further.';
  if (spec.news === 'piles') return 'A pile of two cushions takes two hops to clear.';
  if (spec.news === 'ordered') return 'Pick up the friends in number order: 1, then 2, then 3.';
  if (spec.beats) return `Coloured tiles are lit on their beat only. Next hop: the ${BEAT_NAMES[(s.hops + 1) % 3]} ones.`;
  if (spec.board.friends.length && s.got !== all) return `Pick up every friend${spec.twists.includes('ordered') ? ' in order' : ''}, clear every ${what}, then the ★.`;
  return `Clear every ${what}, then hop onto the ★.`;
}

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

// the next three beats: the next hop's colour first, big
const BeatPill = memo(function BeatPill({ next }) {
  return (
    <View style={[styles.pill, styles.beatPill]}>
      <Text style={[styles.pillText, { color: '#8e1580' }]}>BEAT</Text>
      {[0, 1, 2].map((k) => (
        <View key={k} style={[styles.beatDot, { backgroundColor: BEAT_COL[(next + k) % 3] }, k === 0 && styles.beatNow]} />
      ))}
    </View>
  );
});

// A friend in the goal card: its head, dim until it's picked up (and a pop
// when it lands there), with its number on in-order levels.
const Slot = memo(function Slot({ c, size, got, n, pop, onRef }) {
  const head = headOf(c);
  return (
    <Animated.View ref={onRef} collapsable={false} style={{ transform: [{ scale: pop }] }}>
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

export default function HopGame({ startLv = 1, cast, profile, uid, adsFree, haptics: hapticsOn = true, onExit }) {
  const insets = useSafeAreaInsets();
  const haptics = useRef(makeHaptics(hapticsOn)).current;
  const ad = useRewardedAd();
  const profileRef = useRef(profile);
  profileRef.current = profile;

  const [lv, setLv] = useState(startLv);
  const [round, setRound] = useState(0); // a new go at the level
  const fresh = useRef(true); // a new go that also forgets the hint (not RESTART / RETRY)
  const spec = useMemo(() => levelSpec(lv), [lv]);
  const board = spec.board;
  const room = ROOMS[spec.room];
  const hopper = useMemo(() => hopperOf(cast, profileRef.current), [cast]);
  const friends = useMemo(() => friendsOf(cast, hopper, board.friends.length, lv), [cast, hopper, board, lv]);
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
    const { width, height, y } = e.nativeEvent.layout;
    setArea((a) => (a && a.w === width && a.h === height && a.y === y ? a : { w: width, h: height, y }));
  }, []);
  const floorY = root ? roomGeometry(spec.room, root.w, root.h).floorY : 0;
  const B = useMemo(() => (area && root ? layout(board.w, board.h, area.w, area.h, floorY - area.y) : null), [area, root, board, floorY]);
  const cells = useMemo(() => board.life.map((x, i) => (x ? i : -1)).filter((i) => i >= 0), [board]);

  // --- animated values: the cushions, bubbles, ★, squishies ------------------------------
  const cellA = useMemo(() => board.life.map((x) => (x ? { a0: new Animated.Value(0), a1: new Animated.Value(0) } : null)), [board]);
  const bubbleA = useMemo(() => board.bubble.map((b) => (b ? new Animated.Value(0) : null)), [board]);
  const player = useMemo(freshPose, []);
  const friendA = useMemo(() => board.friends.map(() => freshPose()), [board]);
  const slotPop = useMemo(() => board.friends.map(() => new Animated.Value(1)), [board]);
  const starPop = useMemo(() => new Animated.Value(0), [board]);
  const starGone = useMemo(() => new Animated.Value(0), [board]);
  const shake = useRef(new Animated.Value(0)).current;
  const flash = useRef(new Animated.Value(0)).current;
  const fx = useRef(null);
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
  const G = useRef({ st: newState(board), hist: [], moves: [], hinted: false, busy: false, queue: [], over: false, won: false, feasible: true, shown: 0, life: [] }).current;
  const [view, setView] = useState({ hops: 0, moves: 0, left: 0, got: 0, cur: board.start, feasible: true, hinted: false });
  const [shown, setShown] = useState(0); // the friends that have landed in the goal card
  const [playerZ, setPlayerZ] = useState(10);
  const [phase, setPhase] = useState('load'); // load | play | won | stuck
  const [tip, setTip] = useState(null); // a passing tip (why a hop bumped)
  const [glow, setGlow] = useState(-1); // the hint's cell
  const [banner, setBanner] = useState(null);
  const [result, setResult] = useState(null);
  const [stuck, setStuck] = useState(false);
  const [paused, setPaused] = useState(false);
  const [hintAsk, setHintAsk] = useState(false);
  const blocked = useRef(false);
  blocked.current = paused || hintAsk || !!result || stuck;
  const say = useCallback((text, more = {}) => setBanner({ text, key: Date.now(), ...more }), []);

  // hops: cells entered (a bubble bounce enters two: the beat counts them); moves: hops made
  const sync = () => setView({ hops: G.st.hops, moves: G.moves.length, left: leftOf(board, G.st.life), got: G.st.got, cur: G.st.cur, feasible: G.feasible, hinted: G.hinted });

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
    sfx.preload(LOAD_SOUNDS);
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
          fx.current?.burst('poof', q.x, q.y - q.s * 0.45, q.s / 60);
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

  // hop squishy `a` (w × h) onto `cell` in `ms`, `hopH` tiles high
  function moveTo(a, w, h, cell, ms, life, hopH = 0.5) {
    const p = poseOn(cell, w, h, life);
    if (a === player) setPlayerZ(zOf(cell, 2));
    a.hp.setValue(0);
    a.liftH.setValue(B.T * hopH);
    return new Promise((done) =>
      Animated.parallel([timing(a.x, p.x, ms), timing(a.y, p.y, ms), timing(a.k, p.k, ms), timing(a.hp, 1, ms, Easing.linear)]).start(() => {
        a.land.setValue(0);
        timing(a.land, 1, 220, Easing.out(Easing.quad)).start();
        done();
      }),
    );
  }
  // a bump toward d (`by` tiles), or a little nudge
  function nudge(d, by, ms = 200, delay = 0) {
    player.dx.setValue(DIRS[d][0] * B.T * by);
    player.dy.setValue(DIRS[d][1] * B.T * by * 0.6);
    player.bump.setValue(0);
    return new Promise((done) => timing(player.bump, 1, ms, Easing.out(Easing.quad), delay).start(done));
  }
  function wobble(seq, ms) {
    Animated.sequence(seq.map((v) => timing(player.rot, v, ms / seq.length))).start();
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
    nudge(d, 0.14).then(() => {
      G.busy = false;
      drain();
    });
    if (m.why === 'locked') {
      shake.setValue(0);
      timing(shake, 1, 320, Easing.linear).start();
    }
    if (WHY[m.why]) flashTip(WHY[m.why]);
  }
  function flashTip(text) {
    setTip(text);
    clearTimeout(G.tipT);
    G.tipT = setTimeout(() => alive.current && setTip(null), 2400);
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
    // onto each cell in turn; a bubble pops as it bounces you on
    for (let k = 0; k < m.cells.length; k++) {
      const c = m.cells[k];
      const last = k === m.cells.length - 1;
      await moveTo(player, pw, ph, c, last ? 190 : 170, last ? nxt.life[c] : 1, k ? 0.8 : 0.5);
      if (!alive.current || G.st !== nxt) return;
      if (!last) setCell(c, nxt.life[c]);
    }
    const q = standOn(B, nxt.cur);
    fx.current?.burst('dust', q.x, q.y, q.s / 60);
    m.cells.forEach((c) => {
      if (nxt.got & board.fbit[c] && !(prev.got & board.fbit[c])) collect(c);
    });
    if (nxt.done) {
      win();
      return;
    }
    check();
    sync();
    if (!movesOf(board, G.st).length) {
      goStuck();
      return;
    }
    G.busy = false;
    drain();
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
    a.shadow.setValue(0);
    a.hp.setValue(0);
    a.liftH.setValue(B.T * 0.9);
    const anims = [timing(a.hp, 1, 640, Easing.linear)];
    if (to) {
      const p = poseAt(fw, fh, to.x, to.y + to.size / 2, to.size / fw);
      anims.push(timing(a.x, p.x, 640), timing(a.y, p.y, 640), timing(a.k, p.k, 640));
    }
    anims.push(timing(a.o, 0.5, 640, Easing.in(Easing.quad)));
    Animated.parallel(anims).start(() => {
      a.o.setValue(0);
      if (!alive.current || !(G.st.got & board.fbit[cell])) return;
      G.shown |= board.fbit[cell];
      setShown(G.shown);
      slotPop[k].setValue(0.4);
      Animated.spring(slotPop[k], { toValue: 1, friction: 4, tension: 160, useNativeDriver: true }).start();
      if (G.shown === board.all) {
        starPop.setValue(0);
        timing(starPop, 1, 520, Easing.out(Easing.quad)).start();
        const q = standOn(B, board.goal);
        fx.current?.burst('spark', q.x, q.y - B.T * 0.4, q.s / 60);
        sfx.play('sd_unlock');
      }
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
      const p = poseOn(cell, fw, bodyH(c, fw), board.life[cell]);
      place(a, { ...p, k: p.k * 0.3 });
      a.shadow.setValue(1);
      a.hp.setValue(0);
      if (G.shown & board.fbit[cell]) a.o.setValue(0);
      Animated.parallel([timing(a.k, p.k, 300, Easing.out(Easing.back(1.6))), timing(a.y, p.y, 300, Easing.out(Easing.back(1.6))), timing(a.o, 1, 200)]).start();
    });
    G.shown &= target.got;
    setShown(G.shown);
    return moveTo(player, pw, ph, target.cur, ms, target.life[target.cur]);
  }

  function undo() {
    if (!G.hist.length || G.won || phaseRef.current === 'load') return;
    // mid-hop: after it lands
    if (G.busy && !G.over) {
      if (G.queue.length < 2) G.queue.push(undo);
      return;
    }
    setGlow(-1);
    const prev = G.hist.pop();
    G.moves.pop();
    if (G.over) {
      G.over = false;
      setStuck(false);
      setPhase('play');
      player.rot.stopAnimation();
      player.rot.setValue(0);
    }
    sfx.play('st_undo');
    G.busy = true;
    restoreTo(prev, 190).then(() => {
      G.busy = false;
      drain();
    });
    check();
    sync();
  }

  // the same board again from the start (the hint stays taken)
  function restart() {
    if (G.st.hops === 0 && !G.over) return;
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
      player.rot.setValue(0);
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
    if (back) flashTip(`Went back ${back} hop${back === 1 ? '' : 's'}. Try the glowing one!`);
  }

  // --- the end of a level ------------------------------------------------------------------------

  function win() {
    G.over = true;
    G.won = true;
    G.busy = true;
    setPhase('won');
    sync();
    const q = standOn(B, board.goal);
    sfx.play('st_land');
    timing(starGone, 1, 420, Easing.out(Easing.quad)).start();
    fx.current?.burst('spark', q.x, q.y - B.T * 0.5, q.s / 60);
    later(160, () => {
      sfx.play('sd_solve');
      sfx.play('sd_confetti');
      haptics.win();
      fx.current?.burst('confetti', q.x, q.y - B.T * 0.6, 1);
      // two happy hops on the ★
      player.hp.setValue(0);
      player.liftH.setValue(B.T * 0.55);
      Animated.sequence([timing(player.hp, 1, 340, Easing.linear), Animated.timing(player.hp, { toValue: 0, duration: 0, useNativeDriver: true }), timing(player.hp, 1, 340, Easing.linear)]).start();
    });
    const left = leftOf(board, G.st.life);
    const out = afterLevel(profileRef.current, spec, { left, hinted: G.hinted });
    if (uid) saveHop(uid, out.update, out.coins, out.xp, profileRef.current);
    const { stars, coins, xp, before, after, levelUps, unlocked } = out;
    later(1300, () => setResult({ stars, coins, xp, before, after, levelUps, unlocked, hops: G.moves.length, left, hinted: G.hinted }));
  }

  function goStuck() {
    G.over = true;
    G.busy = false;
    setPhase('stuck');
    sfx.play('sd_wrong');
    haptics.wrong();
    wobble([-0.8, 0.8, -0.5, 0], 800);
    later(1000, () => {
      if (G.over && !G.won) setStuck(true);
    });
  }

  // --- a new go at the level ------------------------------------------------------------------------

  const phaseRef = useRef(phase);
  phaseRef.current = phase;
  // a new go: a new level or round, once the board has a place on screen
  const goKey = B && hopper ? `${lv}:${round}` : '';
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
    if (forget) G.hinted = false;
    G.over = false;
    G.won = false;
    G.busy = false;
    G.queue = [];
    G.shown = 0;
    G.life = board.life.slice();
    check();
    sync();
    setShown(0);
    setResult(null);
    setStuck(false);
    setPaused(false);
    setHintAsk(false);
    setGlow(-1);
    setTip(null);
    // the board fluffs in, back to front
    cells.forEach((i) => {
      const A = cellA[i];
      const d = ((i % board.w) + Math.floor(i / board.w)) * 24;
      A.a0.setValue(0);
      A.a1.setValue(0);
      timing(A.a0, 1, 300, Easing.out(Easing.back(1.4)), d).start();
      if (board.life[i] === 2) timing(A.a1, 1, 300, Easing.out(Easing.back(1.4)), d + 70).start();
      const bub = bubbleA[i];
      if (bub) {
        bub.setValue(0);
        timing(bub, 1, 260, Easing.out(Easing.quad), 360).start();
      }
    });
    starPop.setValue(0);
    starGone.setValue(0);
    // the hopper drops in, the friends pop up
    const p = poseOn(board.start, pw, ph, board.life[board.start]);
    setPlayerZ(zOf(board.start, 2));
    [player.rot, player.bump, player.hp].forEach((v) => {
      v.stopAnimation();
      v.setValue(0);
    });
    player.land.setValue(1);
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
      a.shadow.setValue(1);
      a.hp.setValue(0);
      a.land.setValue(1);
      Animated.parallel([timing(a.k, q.k, 320, Easing.out(Easing.back(1.6)), 320 + k * 90), timing(a.y, q.y, 320, Easing.out(Easing.back(1.6)), 320 + k * 90), timing(a.o, 1, 160, Easing.linear, 320 + k * 90)]).start();
      slotPop[k].setValue(1);
    });
    sfx.play('sd_boardIn');
    setPhase('play');
    if (forget) {
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
    setPaused(true);
  }
  function leave() {
    clearTimers();
    onExit();
  }
  function retry() {
    const p = profileRef.current;
    if (uid) saveHop(uid, afterStuck(p), 0);
    setStuck(false);
    fresh.current = false;
    setRound((r) => r + 1);
  }

  const acts = useRef({});
  acts.current = { tryDir, input, undo, restart, askHint, watchHint, giveHint, pause, leave, retry, wiggle: () => wobble([-0.6, 0.6, 0], 360) };

  useEffect(() => {
    const sub = BackHandler.addEventListener('hardwareBackPress', () => {
      if (hintAsk) setHintAsk(false);
      else if (paused) setPaused(false);
      else if (result || stuck) acts.current.leave();
      else acts.current.pause();
      return true;
    });
    return () => sub.remove();
  }, [hintAsk, paused, result, stuck]);
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
  const leftToOpen = n - popcount(shown);
  let can = view.feasible ? 3 : 2;
  if (view.hinted) can = Math.max(1, can - 1);
  const nextBeat = (view.hops + 1) % 3;
  const slotSize = n > 4 ? 19 : n > 2 ? 21 : n > 1 ? 24 : 27;
  const playing = phase === 'play' && !paused;
  const shakeX = shake.interpolate({ inputRange: [0, 0.25, 0.5, 0.75, 1], outputRange: [0, -6, 6, -3, 0] });
  const ph0 = PH[spec.phase] || PH.day;
  const nextRoom = lv < LEVELS ? ROOMS[stageOf(lv + 1).room].name : null;

  return (
    <View style={styles.fill} onLayout={onRoot}>
      {root ? <Room room={spec.room} phase={spec.phase} width={root.w} height={root.h} /> : null}

      {/* the Crib's top bar: back, the room's title, the time of day */}
      <View style={[styles.hud, { paddingTop: insets.top + 6 }]}>
        <CribButton face="pink" icon="back" size={44} onPress={() => (phaseRef.current === 'play' ? acts.current.pause() : acts.current.leave())} />
        <View style={styles.titleBox}>
          <RoomTitle title={room.name} />
          <View style={styles.subRow}>
            <Text style={styles.sub} numberOfLines={1}>{`SQUISH HOP · LEVEL ${lv}`}</Text>
            <View style={[styles.tier, { backgroundColor: TIER_COLORS[spec.tier] }]}>
              <Text style={styles.tierText}>{TIER_NAMES[spec.tier]}</Text>
            </View>
          </View>
        </View>
        {room.dance ? null : <PhasePill sun={ph0.sun} label={ph0.label} />}
      </View>

      {/* the board on the floor */}
      <View ref={areaRef} collapsable={false} style={styles.area} onLayout={onArea} {...responder.panHandlers}>
        {B && hopper ? (
          <>
            {room.rug ? <Rug B={B} /> : null}
            <Under B={B} cells={cells} dance={!!room.dance} dent={room.dent} width={area.w} height={area.h} />
            {cells.map((i) => (
              <Tile key={`${lv}:${i}`} B={B} i={i} look={board.beat[i] >= 0 && board.beat[i] === nextBeat ? looks[i].on : looks[i].off} a0={cellA[i].a0} a1={cellA[i].a1} />
            ))}
            {glow >= 0 ? <HintGlow key={`g${glow}`} B={B} i={glow} z={G.life[glow] === 2 ? PILE_TOP : 0} /> : null}
            <View pointerEvents="none" style={StyleSheet.absoluteFill}>
              {cells
                .filter((i) => board.bubble[i])
                .map((i) => (
                  <View key={`b${lv}:${i}`} style={{ position: 'absolute', left: 0, top: 0, right: 0, bottom: 0, zIndex: zOf(i, 0) }} pointerEvents="none">
                    <Bubble B={B} i={i} a={bubbleA[i]} />
                  </View>
                ))}
              <GoalStar key={`s${lv}`} B={B} i={board.goal} left={leftToOpen} pop={starPop} gone={starGone} z={zOf(board.goal, 0)} />
              {board.friends.map((cell, k) =>
                friends[k] ? <Piece key={`f${lv}:${k}`} c={friends[k]} w={fw} h={bodyH(friends[k], fw)} a={friendA[k]} z={zOf(cell, 1)} shade={room.dance ? 'rgba(255,255,255,0.3)' : 'rgba(69,16,122,0.28)'} friend delay={k * 900} /> : null,
              )}
              <Piece c={hopper} w={pw} h={ph} a={player} z={playerZ} shade={room.dance ? 'rgba(255,255,255,0.3)' : 'rgba(69,16,122,0.28)'} />
            </View>
            {/* numbered friends' chips, over everything so the order can be read */}
            {board.friends.map((cell, k) => {
              if (!board.order[cell] || G.st.got & board.fbit[cell] || !friends[k]) return null;
              const q = standOn(B, cell, board.life[cell] === 2 ? PILE_TOP : 0);
              const hh = bodyH(friends[k], fw) * (q.s / B.T);
              return <OrderChip key={`o${lv}:${k}`} n={board.order[cell]} x={q.x + fw * (q.s / B.T) * 0.42} y={q.y - hh * 0.9} size={Math.max(18, q.s * 0.3)} />;
            })}
            <Banner banner={banner} top={4} />
            <FxLayer ref={fx} />
          </>
        ) : null}
      </View>

      {/* the goal, the stars still possible, what's left, and a tip */}
      <View style={styles.strip}>
        <Animated.View style={[styles.goalCard, { transform: [{ translateX: shakeX }] }]}>
          <Text style={styles.goalLabel}>GOAL</Text>
          <View style={styles.goalRow}>
            {slotOrder.map((k) =>
              friends[k] ? <Slot key={`${lv}:${k}`} c={friends[k]} size={slotSize} got={!!(shown & board.fbit[board.friends[k]])} n={board.order[board.friends[k]] || 0} pop={slotPop[k]} onRef={(r) => (slotRefs.current[k] = r)} /> : null,
            )}
            {n ? <Text style={styles.goalArrow}>›</Text> : null}
            <View style={styles.miniGoal}>
              {room.dance ? <View style={styles.miniTile} /> : <FlatCushion size={34} col="peach" id="hopMini" />}
              <View style={styles.miniStar}>
                <Star size={19} shut={leftToOpen > 0} />
              </View>
            </View>
          </View>
        </Animated.View>
        <View style={styles.stripRight}>
          <View style={styles.meterRow}>
            <Meter stars={can} />
            <View style={styles.pill}>
              <Text style={styles.pillText}>{`LEFT ${view.left}`}</Text>
            </View>
            <View style={[styles.pill, styles.hopsPill]}>
              <Text style={[styles.pillText, { color: '#5b3a29' }]}>{`HOPS ${view.moves}`}</Text>
            </View>
            {spec.beats ? <BeatPill next={nextBeat} /> : null}
          </View>
          <Text style={[styles.tip, !view.feasible && phase !== 'won' && styles.tipWarn]} numberOfLines={3}>
            {tip || tipFor(spec, view, room)}
          </Text>
        </View>
      </View>

      {/* undo, restart, hint */}
      <View style={[styles.controls, { paddingBottom: Math.max(insets.bottom, 6) + 6 }]}>
        <SdButton kind="white" onPress={() => acts.current.undo()} disabled={!(playing || phase === 'stuck') || view.hops === 0} sound={null} faceStyle={styles.ctrlFace} style={styles.ctrl}>
          <BtnLabel kind="purple" size={15}>
            UNDO
          </BtnLabel>
        </SdButton>
        <SdButton kind="purple" onPress={() => acts.current.restart()} disabled={!(playing || phase === 'stuck') || view.hops === 0} sound="sd_select" faceStyle={styles.ctrlFace} style={styles.ctrl}>
          <BtnLabel kind="purple" size={15}>
            RESTART
          </BtnLabel>
        </SdButton>
        <SdButton kind="gold" onPress={() => acts.current.askHint()} disabled={!playing || (view.hinted && !adsFree && !ad.ready)} sound="sd_select" faceStyle={styles.ctrlFace} style={styles.ctrl}>
          <BtnLabel kind="gold" size={15}>
            {adsFree ? 'HINT' : '▶ HINT'}
          </BtnLabel>
        </SdButton>
      </View>

      <ResultCard visible={!!result} res={result} spec={spec} nextRoom={nextRoom} onNext={() => goTo(lv + 1)} onReplay={() => goTo(lv)} onHub={() => acts.current.leave()} />
      <StuckCard
        visible={stuck}
        head={headOf(hopper, 'sad')}
        uri={hopper?.uri}
        shut={board.nbrs[view.cur].includes(board.goal) && popcount(view.got) < n}
        onUndo={() => {
          setStuck(false);
          acts.current.undo();
        }}
        onRetry={() => acts.current.retry()}
      />
      <PauseCard
        visible={paused}
        onResume={() => setPaused(false)}
        onRestart={() => {
          setPaused(false);
          fresh.current = false;
          setRound((r) => r + 1);
        }}
        onQuit={() => acts.current.leave()}
      />
      <HintCard visible={hintAsk} adReady={ad.ready} adsFree={adsFree} onWatch={() => acts.current.watchHint()} onClose={() => setHintAsk(false)} />

      <Animated.View pointerEvents="none" style={[StyleSheet.absoluteFill, { opacity: flash }]}>
        <RoomFlash />
      </Animated.View>
    </View>
  );
}

const GLASS = 'rgba(91,58,41,0.75)';
const styles = StyleSheet.create({
  fill: { flex: 1 },
  hud: { flexDirection: 'row', alignItems: 'center', gap: 8, paddingHorizontal: 12, zIndex: 3 },
  titleBox: { flex: 1, minWidth: 0 },
  subRow: { flexDirection: 'row', alignItems: 'center', gap: 6, marginTop: -2 },
  sub: { flexShrink: 1, fontFamily: F.heavy, fontSize: 11, color: '#ffffff', letterSpacing: 0.6, textShadowColor: '#5b3a29', textShadowRadius: 1.5, textShadowOffset: { width: 0, height: 1 } },
  tier: { paddingHorizontal: 6, borderRadius: 999, borderWidth: 2, borderColor: '#ffffff' },
  tierText: { fontFamily: F.display, fontSize: 9.5, letterSpacing: 0.6, color: '#ffffff' },
  area: { flex: 1, zIndex: 2 },
  strip: { flexDirection: 'row', alignItems: 'stretch', gap: 8, marginHorizontal: 12, marginTop: 4, padding: 6, borderRadius: 20, backgroundColor: GLASS, borderWidth: 2, borderColor: 'rgba(255,255,255,0.9)', zIndex: 1 },
  goalCard: { minWidth: 104, flexShrink: 0, backgroundColor: 'rgba(255,255,255,0.95)', borderRadius: 15, borderWidth: 3, borderColor: '#ffffff', paddingHorizontal: 5, paddingTop: 1, paddingBottom: 4, alignItems: 'center' },
  goalLabel: { fontFamily: F.display, fontSize: 10.5, letterSpacing: 1.2, color: '#6b3fa0', includeFontPadding: false },
  goalRow: { flex: 1, flexDirection: 'row', alignItems: 'center', justifyContent: 'center', gap: 3, paddingTop: 3 },
  goalArrow: { fontFamily: F.display, fontSize: 14, color: '#b9a6cc', includeFontPadding: false },
  miniGoal: { width: 36, height: 38, alignItems: 'center', justifyContent: 'center' },
  miniTile: { width: 30, height: 30, borderRadius: 5, backgroundColor: '#ffffff', borderWidth: 2, borderColor: '#140818' },
  miniStar: { position: 'absolute', left: 8.5, top: 7 },
  sticker: { backgroundColor: '#ffffff', padding: 2 },
  stickerDim: { backgroundColor: 'rgba(255,255,255,0.55)' },
  stickerIn: { flex: 1, borderRadius: 999, backgroundColor: '#f6efff', overflow: 'hidden', alignItems: 'center', justifyContent: 'center' },
  stickerImg: { width: '94%', height: '94%', resizeMode: 'contain' },
  slotNum: { position: 'absolute', right: -5, top: -5, minWidth: 14, height: 14, paddingHorizontal: 2, borderRadius: 7, backgroundColor: '#ff5cc6', borderWidth: 1.5, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
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
  // three lines always, so a longer tip never moves the board
  tip: { fontFamily: F.heavy, fontSize: 12, lineHeight: 15, color: '#ffffff', height: 45 },
  tipWarn: { color: '#ffd0d6' },
  controls: { flexDirection: 'row', justifyContent: 'center', gap: 8, paddingHorizontal: 12, paddingTop: 8, zIndex: 1 },
  ctrl: { flex: 1, maxWidth: 130 },
  ctrlFace: { paddingHorizontal: 6, paddingVertical: 10 },
});
