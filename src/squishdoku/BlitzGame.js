import React, { useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { Animated, AppState, BackHandler, Easing, StyleSheet, Text, View, useWindowDimensions } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import useRewardedAd from '../components/useRewardedAd';
import sfx from '../audio/sfx';
import RoomBoard, { SDK_TILT } from './RoomBoard';
import Room, { roomGeometry } from '../hop/Room';
import { layout } from '../hop/board';
import { CribButton, RoomTitle } from '../crib/Hud';
import Buddy from './Buddy';
import { Pips, TimerBar } from './Hud';
import { BlitzFailCard, BlitzWinCard, PauseCard, ReviveCard } from './Overlays';
import { FxLayer } from './fx';
import { getPuzzle, makeHaptics, pickCreatures, prefetchImages, prefetchPuzzle, PLAY_SOUNDS, useClock } from './game';
import { afterBlitz, BLITZ_SIZES, blitzMs, blitzSpec, clock, record } from './levels';
import { Chip } from './ui';
import { F } from './theme';
import { saveSquishdoku } from '../firebase/firestore';

// Blitz: ten boards on one clock, no ✕. One mistake (or the clock running
// out) sends the run back to board 1 with new boards; one revive per run
// (a rewarded ad, free with Remove Ads) keeps you on the board you're on.
// Since 2026-11-07 a run is played in the Crib's Dance Room (party music,
// party room), on Regular's room board (RoomBoard.js).

const ROOM = 'dance';

const BOARDS = BLITZ_SIZES.length;
export default function BlitzGame({ profile, uid, roster, cast = [], adsFree, head = false, buddyKey, buddyUri, haptics: hapticsOn = true, onExit }) {
  const RUN_MS = blitzMs(head);
  const { width, height } = useWindowDimensions();
  const insets = useSafeAreaInsets();
  const castRef = useRef(cast);
  castRef.current = cast;
  const haptics = useRef(makeHaptics(hapticsOn)).current;
  const ad = useRewardedAd();
  const [run, setRun] = useState(0);
  const [idx, setIdx] = useState(0);
  const [done, setDone] = useState(0);
  const [game, setGame] = useState(null); // { spec, puzzle, pieces, id }
  const [phase, setPhase] = useState('loading'); // loading | countdown | intro | play | between | revive | fail | win | paused
  const [count, setCount] = useState(null); // 3, 2, 1, 'GO!'
  const [label, setLabel] = useState(clock(RUN_MS));
  const [warn, setWarn] = useState(false);
  const [revived, setRevived] = useState(false);
  const [failReason, setFailReason] = useState('mistake');
  const [win, setWin] = useState(null);
  const [winUris, setWinUris] = useState([]);
  const board = useRef(null);
  const buddy = useRef(null);
  const fx = useRef(null);
  const clk = useClock();
  const g = useRef({ placed: 0, combo: 0, lastSecond: -1, specs: [], started: false }).current;
  const profileRef = useRef(profile);
  profileRef.current = profile;
  const phaseRef = useRef(phase);
  phaseRef.current = phase;
  const best = record(profile).blitz.reached;

  useEffect(() => {
    sfx.preload([...PLAY_SOUNDS, 'sd_count', 'sd_go', 'sd_pip', 'sd_blitzNext', 'sd_blitzFail', 'sd_drain', 'sd_revive']);
    sfx.music('party');
    return () => sfx.music('dream');
  }, []);

  // --- a new run ---------------------------------------------------------------------
  useEffect(() => {
    const skill = record(profileRef.current).bSkill;
    g.specs = Array.from({ length: BOARDS }, (_, i) => blitzSpec(i, skill));
    g.started = false;
    setIdx(0);
    setDone(0);
    setRevived(false);
    setWarn(false);
    setWin(null);
    setLabel(clock(RUN_MS));
    clk.reset();
    // the first few boards start cooking right away
    g.specs.slice(0, 3).forEach((s) => prefetchPuzzle(s.n, s.tier));
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [run]);

  // --- each board ------------------------------------------------------------------
  useEffect(() => {
    let alive = true;
    const spec = g.specs[idx];
    if (!spec) return undefined;
    setPhase((p) => (p === 'between' ? p : 'loading'));
    g.placed = 0;
    g.combo = 0;
    (async () => {
      const puzzle = await getPuzzle(spec.n, spec.tier);
      const mine = castRef.current.filter((c) => c.mine);
      const pieces = pickCreatures(mine.length ? mine : castRef.current, spec.n);
      await prefetchImages(pieces.map((c) => c && c.source && c.source.uri), 1000);
      if (!alive) return;
      // HEAD START: the first row's creature, placed for you
      const given = head ? puzzle.solution[0] : null;
      setGame({ spec, puzzle, pieces, given, id: `${run}-${idx}-${puzzle.seed}` });
      const next = g.specs[idx + 1];
      if (next) prefetchPuzzle(next.n, next.tier);
      if (!g.started) setPhase('countdown');
      else setPhase('intro');
    })();
    return () => {
      alive = false;
    };
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [run, idx]);

  // 3, 2, 1, GO! — the first board falls in on GO and the clock starts
  useEffect(() => {
    if (phase !== 'countdown') return undefined;
    const steps = [3, 2, 1, 'GO!'];
    const timers = steps.map((s, i) =>
      setTimeout(() => {
        setCount(s);
        sfx.play(s === 'GO!' ? 'sd_go' : 'sd_count');
        haptics.tick();
        if (s === 'GO!') {
          buddy.current?.react('start');
          board.current?.intro();
          sfx.play('sd_boardIn', { delay: 120 });
        }
      }, 200 + i * 700),
    );
    if (game && game.given != null) timers.push(setTimeout(() => placeGiven(game.given), 200 + 3 * 700 + 380));
    timers.push(
      setTimeout(() => {
        setCount(null);
        g.started = true;
        setPhase('play');
        clk.start(RUN_MS);
      }, 200 + 3 * 700 + (game && game.given != null ? 800 : 450)),
    );
    return () => timers.forEach(clearTimeout);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [phase]);

  // HEAD START's creature dropping in once the board has landed
  const placeGiven = (cell) => {
    board.current?.place(cell);
    sfx.play('sd_place');
    g.placed = 1;
  };

  // the next board cascades in (and HEAD START's creature), then the clock runs on
  useEffect(() => {
    if (phase !== 'intro' || !game) return undefined;
    const settled = 40 + (2 * game.spec.n - 1) * 34 + 250;
    const timers = [
      setTimeout(() => {
        board.current?.intro();
        sfx.play('sd_boardIn');
      }, 40),
    ];
    if (game.given != null) timers.push(setTimeout(() => placeGiven(game.given), settled));
    timers.push(
      setTimeout(() => {
        setPhase('play');
        clk.resume();
      }, settled + (game.given != null ? 400 : 0)),
    );
    return () => timers.forEach(clearTimeout);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [phase, game]);

  // --- the clock ------------------------------------------------------------------------
  useEffect(() => {
    if (phase !== 'play') return undefined;
    const timer = setInterval(() => {
      const rest = RUN_MS - clk.elapsed();
      setLabel(clock(rest));
      const sec = Math.ceil(rest / 1000);
      if (rest <= 15000 && rest > 0 && sec !== g.lastSecond) {
        if (g.lastSecond < 0) buddy.current?.react('hurry');
        g.lastSecond = sec;
        sfx.play('sd_tick', { rate: sec <= 5 ? 1.3 : 1 });
        setWarn(true);
      }
      if (rest <= 0) fail('time');
    }, 150);
    return () => clearInterval(timer);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [phase]);

  // --- the run ending ------------------------------------------------------------------
  const fail = (reason) => {
    clk.pause();
    setFailReason(reason);
    setPhase('fail');
    setWarn(false);
    buddy.current?.react('timeup');
    if (reason === 'time') {
      sfx.play('sd_timeUp');
      board.current?.shake();
    }
    setTimeout(() => sfx.play('sd_blitzFail'), reason === 'time' ? 900 : 0);
    setTimeout(() => {
      sfx.play('sd_drain');
      setDone(0);
    }, reason === 'time' ? 1500 : 600);
    const out = afterBlitz(profileRef.current, { won: false, reached: idx + 1, head });
    if (uid) saveSquishdoku(uid, out.update, 0);
  };

  const boardDone = () => {
    clk.pause();
    setPhase('between');
    const last = idx === BOARDS - 1;
    buddy.current?.react('solve');
    board.current?.hopAll();
    for (let r = 0; r < game.spec.n; r++) sfx.play('sd_hop', { delay: r * 70, rate: 0.95 + r * 0.06 });
    setTimeout(() => {
      setDone(idx + 1);
      sfx.play('sd_pip', { rate: 0.9 + idx * 0.06 });
    }, 300);
    if (last) {
      setTimeout(() => {
        const ms = clk.elapsed();
        const out = afterBlitz(profileRef.current, { won: true, reached: BOARDS, ms, head });
        if (uid) saveSquishdoku(uid, out.update, out.coins, out.xp, profileRef.current);
        const rec = record(profileRef.current);
        setWinUris(pickCreatures(roster, 3));
        setWin({ ...out, ms, newBest: !rec.blitz.bestMs || ms < rec.blitz.bestMs });
        setPhase('win');
        sfx.play('sd_blitzWin');
        haptics.win();
        [0, 300, 600].forEach((d, i) => setTimeout(() => fx.current?.burst('confetti', width * (0.25 + 0.25 * i), height * 0.3, 1), d));
      }, 900);
      return;
    }
    setTimeout(() => {
      sfx.play('sd_blitzNext');
      board.current?.outro();
    }, 650);
    setTimeout(() => setIdx((i) => i + 1), 1000);
  };

  // --- touches ---------------------------------------------------------------------------
  const onTap = useCallback(
    (cell) => {
      if (phaseRef.current !== 'play' || !game) return;
      const { n, solution } = game.puzzle;
      if (solution[Math.floor(cell / n)] === cell % n) {
        board.current?.place(cell);
        sfx.play('sd_place', { rate: 1 + Math.min(8, g.combo) * 0.06 });
        haptics.place();
        g.combo++;
        if (g.placed + 1 < n) buddy.current?.react('right', g.combo);
        g.placed++;
        if (g.placed === n) boardDone();
        return;
      }
      clk.pause();
      setPhase('between');
      board.current?.wrong(cell);
      sfx.play('sd_wrong');
      buddy.current?.react('wrong');
      setTimeout(() => haptics.wrong(), 200);
      g.combo = 0;
      setTimeout(() => {
        if (revived) fail('mistake');
        else setPhase('revive');
      }, 1000);
    },
    // eslint-disable-next-line react-hooks/exhaustive-deps
    [game, revived, idx],
  );
  const onTapPiece = useCallback((cell) => {
    board.current?.wiggle(cell);
    sfx.play('sd_squeak', { rate: 0.85 + Math.random() * 0.35 });
  }, []);

  const revive = () => {
    const back = () => {
      setRevived(true);
      sfx.play('sd_revive');
      setPhase('play');
      clk.resume();
    };
    if (adsFree) back();
    else ad.show(back);
  };

  // --- pause, back, leaving ------------------------------------------------------------------
  const pause = useCallback(() => {
    if (phaseRef.current !== 'play') return;
    clk.pause();
    setPhase('paused');
    sfx.play('sd_pause');
  }, [clk]);
  const resume = () => {
    setPhase('play');
    clk.resume();
  };
  const exit = useCallback(() => {
    clk.pause();
    onExit();
  }, [clk, onExit]);
  useEffect(() => {
    const sub = BackHandler.addEventListener('hardwareBackPress', () => {
      if (phaseRef.current === 'play') pause();
      else exit();
      return true;
    });
    return () => sub.remove();
  }, [pause, exit]);
  useEffect(() => {
    const sub = AppState.addEventListener('change', (s) => {
      if (s !== 'active') pause();
    });
    return () => sub.remove();
  }, [pause]);

  const again = () => setRun((r) => r + 1);
  const barW = Math.min(width - 48, 400);
  // the room fills the screen; the board lies on its floor
  const [root, setRoot] = useState(null);
  const [area, setArea] = useState(null);
  const onRoot = useCallback((e) => {
    const { width: w, height: h } = e.nativeEvent.layout;
    setRoot((r) => (r && r.w === w && r.h === h ? r : { w, h }));
  }, []);
  const onArea = useCallback((e) => {
    const { width: w, height: h, y } = e.nativeEvent.layout;
    setArea((a) => (a && a.w === w && a.h === h && a.y === y ? a : { w, h, y }));
  }, []);
  const n = game ? game.puzzle.n : 4;
  const floorY = root ? roomGeometry(ROOM, root.w, root.h).floorY : 0;
  const B = useMemo(() => (area && root ? layout(n, n, area.w, area.h, floorY - area.y, SDK_TILT, 80) : null), [area, root, n, floorY]);

  return (
    <View style={styles.fill} onLayout={onRoot}>
      {root ? <Room room={ROOM} phase="day" width={root.w} height={root.h} /> : null}
      {/* the Crib's top bar: pause (back once it's over), BLITZ and the board */}
      <View style={[styles.header, { paddingTop: insets.top + 6 }]}>
        <CribButton face="pink" icon={phase === 'play' ? 'pause' : 'back'} size={44} onPress={phase === 'play' ? pause : exit} />
        <View style={styles.titleBox}>
          <RoomTitle title="Blitz ⚡" />
          <Text style={styles.boardNo}>{`BOARD ${Math.min(idx + 1, BOARDS)} OF ${BOARDS}`}</Text>
        </View>
      </View>
      {/* the boards done, the rules and the run's clock, on the Crib's brown glass */}
      <View style={styles.glass}>
        <Pips done={done} current={phase === 'fail' || phase === 'win' ? -1 : idx} />
        <View style={styles.rules}>
          <Chip bg="#e01e4a" color="#ffffff">1 MISTAKE = BOARD 1</Chip>
          <Chip bg={revived ? '#b9a6cc' : '#ffb02e'} color="#ffffff">
            {revived ? 'REVIVE USED' : '♥ 1 REVIVE'}
          </Chip>
        </View>
        <View style={styles.barRow}>
          <TimerBar frac={clk.frac} width={barW} warn={warn} label={label} />
        </View>
      </View>

      <View style={styles.boardArea} onLayout={onArea}>
        {game && B ? (
          // hidden while paused, and during the countdown until GO drops it in
          <View style={[StyleSheet.absoluteFill, { opacity: phase === 'paused' || (phase === 'countdown' && count !== 'GO!') ? 0 : 1 }]}>
            <RoomBoard
              key={game.id}
              ref={board}
              puzzle={game.puzzle}
              B={B}
              pieces={game.pieces}
              allowX={false}
              locked={phase !== 'play'}
              onTap={onTap}
              onTapPiece={onTapPiece}
            />
          </View>
        ) : null}
        {count != null ? <Countdown value={count} /> : null}
      </View>
      {/* the player's Lobby creature cheering them on */}
      <View style={[styles.bottom, { marginBottom: Math.max(insets.bottom, 6) + 4 }]}>
        <Buddy ref={buddy} creatureKey={buddyKey} uri={buddyUri} paused={phase === 'paused' || phase === 'fail' || phase === 'win' || phase === 'revive'} size={80} />
        <Text style={styles.hint}>{'Tap to place · no ✕ in Blitz\nthink before you tap!'}</Text>
      </View>

      <PauseCard blitz visible={phase === 'paused'} onResume={resume} onRestart={again} onQuit={exit} />
      <ReviveCard
        visible={phase === 'revive'}
        board={idx + 1}
        adReady={ad.ready}
        adsFree={adsFree}
        onRevive={revive}
        onGiveUp={() => fail('mistake')}
      />
      <BlitzFailCard visible={phase === 'fail'} reason={failReason} reached={idx + 1} best={best} onAgain={again} onQuit={exit} />
      <BlitzWinCard visible={phase === 'win'} res={win} uris={winUris} onAgain={again} onQuit={exit} />
      {/* over the cards: the win's confetti rains on top of everything */}
      <FxLayer ref={fx} style={styles.fxTop} />
    </View>
  );
}

// The big 3, 2, 1, GO! — each number slams in and swells away. (Squish
// Stack's Blitz too.)
export function Countdown({ value }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    t.setValue(0);
    Animated.timing(t, { toValue: 1, duration: 650, easing: Easing.out(Easing.cubic), useNativeDriver: true }).start();
  }, [value, t]);
  const go = value === 'GO!';
  return (
    <View pointerEvents="none" style={styles.countWrap}>
      <Animated.Text
        style={[
          styles.count,
          go && styles.go,
          {
            opacity: t.interpolate({ inputRange: [0, 0.15, 0.7, 1], outputRange: [0, 1, 1, 0] }),
            transform: [{ scale: t.interpolate({ inputRange: [0, 0.2, 1], outputRange: [2.6, 1, go ? 1.5 : 0.8] }) }, { rotate: t.interpolate({ inputRange: [0, 0.2, 1], outputRange: ['-15deg', '0deg', '0deg'] }) }],
          },
        ]}
      >
        {String(value)}
      </Animated.Text>
    </View>
  );
}

const GLASS = 'rgba(91,58,41,0.75)'; // the Crib's pills
const styles = StyleSheet.create({
  fill: { flex: 1 },
  header: { flexDirection: 'row', alignItems: 'center', alignSelf: 'stretch', gap: 8, paddingHorizontal: 12, zIndex: 3 },
  titleBox: { flex: 1, minWidth: 0 },
  boardNo: { fontFamily: F.heavy, fontSize: 11, color: '#ffffff', letterSpacing: 0.8, marginTop: -2, textShadowColor: '#5b3a29', textShadowRadius: 1.5, textShadowOffset: { width: 0, height: 1 } },
  glass: { alignSelf: 'center', alignItems: 'center', marginTop: 6, paddingHorizontal: 12, paddingTop: 6, paddingBottom: 6, borderRadius: 20, backgroundColor: GLASS, borderWidth: 2, borderColor: 'rgba(255,255,255,0.9)', zIndex: 1 },
  rules: { flexDirection: 'row', gap: 6, marginTop: 6 },
  barRow: { marginTop: 8 },
  boardArea: { flex: 1, alignSelf: 'stretch', zIndex: 2 },
  bottom: { flexDirection: 'row', alignItems: 'center', alignSelf: 'center', justifyContent: 'center', gap: 12, paddingHorizontal: 14, paddingVertical: 4, borderRadius: 22, backgroundColor: GLASS, borderWidth: 2, borderColor: 'rgba(255,255,255,0.9)', zIndex: 1 },
  hint: { fontFamily: F.heavy, fontSize: 11.5, color: '#ffffff', lineHeight: 16 },
  // the cards sit at elevation 50 (Overlays.js)
  fxTop: { zIndex: 60, elevation: 60 },
  countWrap: { ...StyleSheet.absoluteFillObject, alignItems: 'center', justifyContent: 'center' },
  count: { fontFamily: F.display, fontSize: 110, color: '#ffffff', textShadowColor: '#0c5a9c', textShadowOffset: { width: 0, height: 7 }, textShadowRadius: 1, includeFontPadding: false },
  go: { color: '#ffd23a', textShadowColor: '#9c4d06', fontSize: 96 },
});
