import React, { useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { useGameDims } from '../royal/GameFrame';
import { Animated, AppState, BackHandler, Easing, StyleSheet, Text, View } from 'react-native';
import useRewardedAd from '../components/useRewardedAd';
import sfx from '../audio/sfx';
import RoomBoard, { SDK_TILT } from './RoomBoard';
import Room, { roomGeometry } from '../hop/Room';
import { layout } from '../hop/board';
import { CribButton, RoomTitle } from '../crib/Hud';
import Buddy from './Buddy';
import { TimerBar } from './Hud';
import { BlitzOverCard, BlitzSaveCard, PauseCard } from './Overlays';
import { FxLayer } from './fx';
import { getPuzzle, makeHaptics, pickCreatures, prefetchImages, prefetchPuzzle, PLAY_SOUNDS, useClock } from './game';
import { afterBlitz, blitzSaveGems, blitzSpec, clock, record } from './levels';
import { Chip } from './ui';
import { F } from './theme';
import { saveSquishdoku } from '../firebase/firestore';
import * as squad from '../squad/api';

// BLITZ MODE (2026-11-16, the user): board after board, each on its own really short clock (levels.js blitzSpec), no
// ✕, until a mistake or the clock running out. Then the run can be saved — once with a rewarded ad (free with Remove
// Ads), or with gems, each save twice the last (functions/squad.js blitzSave) — and goes on from the same board; or
// it's GAME OVER and the boards cleared pay out (levels.js afterBlitz).
// Every board gives a head start of 1 creature, whether the hub's HEAD START is on or off (the user, 2026-11-16: Blitz
// was a little too hard): the first row's creature drops in once the board has landed, then its clock starts. Unlike
// Regular's HEAD START it costs nothing: the clocks and the pay stay as they are.
// A run is played in the Crib's Dance Room (party music, party room), on Regular's room board (RoomBoard.js).

const ROOM = 'dance';
// from the given creature dropping in to the board's clock starting
const GIVEN_MS = 350;
// the last seconds of a board's clock tick
const HURRY_MS = 5000;

export default function BlitzGame({ profile, uid, roster, cast = [], adsFree, buddyKey, buddyUri, haptics: hapticsOn = true, onExit }) {
  const { width, height } = useGameDims();
  const castRef = useRef(cast);
  castRef.current = cast;
  const haptics = useRef(makeHaptics(hapticsOn)).current;
  const ad = useRewardedAd();
  const [run, setRun] = useState(0);
  const [idx, setIdx] = useState(0);
  const [cleared, setCleared] = useState(0);
  const [game, setGame] = useState(null); // { spec, puzzle, pieces, id }
  const [phase, setPhase] = useState('loading'); // loading | countdown | intro | play | between | save | over | paused
  const [count, setCount] = useState(null); // 3, 2, 1, 'GO!'
  const [label, setLabel] = useState('');
  const [warn, setWarn] = useState(false);
  const [adUsed, setAdUsed] = useState(false);
  const [gemSaves, setGemSaves] = useState(0);
  const [saving, setSaving] = useState(false);
  const [saveErr, setSaveErr] = useState(null);
  const [failReason, setFailReason] = useState('mistake');
  const [over, setOver] = useState(null);
  const board = useRef(null);
  const buddy = useRef(null);
  const fx = useRef(null);
  const clk = useClock();
  // skill: the run's boards are dealt at the skill it started with; ended: paid out already
  const g = useRef({ placed: 0, combo: 0, lastSecond: -1, skill: 0, started: false, ended: false, cleared: 0 }).current;
  const profileRef = useRef(profile);
  profileRef.current = profile;
  const phaseRef = useRef(phase);
  phaseRef.current = phase;
  const top = record(profile).blitz.top;

  useEffect(() => {
    sfx.preload([...PLAY_SOUNDS, 'sd_count', 'sd_go', 'sd_pip', 'sd_blitzNext', 'sd_blitzFail', 'sd_blitzWin', 'sd_drain', 'sd_revive']);
  }, []);

  // --- a new run ---------------------------------------------------------------------
  useEffect(() => {
    g.skill = record(profileRef.current).bSkill;
    g.started = false;
    g.ended = false;
    g.cleared = 0;
    setIdx(0);
    setCleared(0);
    setAdUsed(false);
    setGemSaves(0);
    setSaveErr(null);
    setWarn(false);
    setOver(null);
    setLabel(clock(blitzSpec(0, g.skill).ms));
    clk.reset();
    // the first few boards start cooking right away
    [0, 1, 2].forEach((i) => {
      const s = blitzSpec(i, g.skill);
      prefetchPuzzle(s.n, s.tier);
    });
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [run]);

  // --- each board ------------------------------------------------------------------
  useEffect(() => {
    let alive = true;
    const spec = blitzSpec(idx, g.skill);
    setPhase((p) => (p === 'between' ? p : 'loading'));
    g.placed = 0;
    g.combo = 0;
    g.lastSecond = -1;
    (async () => {
      const puzzle = await getPuzzle(spec.n, spec.tier);
      const mine = castRef.current.filter((c) => c.mine);
      const pieces = pickCreatures(mine.length ? mine : castRef.current, spec.n);
      await prefetchImages(pieces.map((c) => c && c.source && c.source.uri), 1000);
      if (!alive) return;
      // the head start: the first row's creature (solution: each row's column)
      setGame({ spec, puzzle, pieces, given: puzzle.solution[0], id: `${run}-${idx}-${puzzle.seed}` });
      setLabel(clock(spec.ms));
      setWarn(false);
      const next = blitzSpec(idx + 1, g.skill);
      prefetchPuzzle(next.n, next.tier);
      if (!g.started) setPhase('countdown');
      else setPhase('intro');
    })();
    return () => {
      alive = false;
    };
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [run, idx]);

  // the head start's creature drops into place (g.placed counts it, so the board is done after n - 1 taps)
  const dropGiven = () => {
    board.current?.place(game.given);
    sfx.play('sd_place');
    g.placed = 1;
  };
  // a board's cascade, from its intro() to every cushion landed
  const landMs = (n) => (2 * n - 1) * 34 + 250;

  // 3, 2, 1, GO! — the first board falls in on GO, its given creature drops in, and its clock starts
  useEffect(() => {
    if (phase !== 'countdown' || !game) return undefined;
    const GO = 200 + 3 * 700;
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
    const settled = GO + landMs(game.spec.n);
    timers.push(setTimeout(dropGiven, settled));
    timers.push(
      setTimeout(() => {
        setCount(null);
        g.started = true;
        setPhase('play');
        clk.start(game.spec.ms);
      }, settled + GIVEN_MS),
    );
    return () => timers.forEach(clearTimeout);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [phase, game]);

  // the next board cascades in, its given creature drops in, then its own clock starts
  useEffect(() => {
    if (phase !== 'intro' || !game) return undefined;
    const settled = 40 + landMs(game.spec.n);
    const timers = [
      setTimeout(() => {
        board.current?.intro();
        sfx.play('sd_boardIn');
      }, 40),
      setTimeout(dropGiven, settled),
      setTimeout(() => {
        setPhase('play');
        clk.start(game.spec.ms);
      }, settled + GIVEN_MS),
    ];
    return () => timers.forEach(clearTimeout);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [phase, game]);

  // --- the clock ------------------------------------------------------------------------
  useEffect(() => {
    if (phase !== 'play') return undefined;
    const timer = setInterval(() => {
      const rest = clk.limit() - clk.elapsed();
      setLabel(clock(rest));
      const sec = Math.ceil(rest / 1000);
      if (rest <= HURRY_MS && rest > 0 && sec !== g.lastSecond) {
        if (g.lastSecond < 0) buddy.current?.react('hurry');
        g.lastSecond = sec;
        sfx.play('sd_tick', { rate: sec <= 3 ? 1.3 : 1 });
        setWarn(true);
      }
      if (rest <= 0) lose('time');
    }, 150);
    return () => clearInterval(timer);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [phase]);

  // --- a mistake or the clock: save the run, or GAME OVER -----------------------------------
  // Everyone on the board turns sad and droops one after another (nearest the
  // mistake first, quicker than Regular's), the save card coming up as the
  // last one sinks. `cell`: the mistake's.
  const lose = (reason, cell = -1) => {
    clk.pause();
    setFailReason(reason);
    setWarn(false);
    setSaveErr(null);
    setPhase('between');
    if (reason === 'time') {
      buddy.current?.react('timeup');
      sfx.play('sd_timeUp');
      board.current?.shake();
    }
    const sad = board.current?.sadAll(cell, { step: 100 }) || 0;
    setTimeout(() => setPhase((p) => (p === 'between' ? 'save' : p)), Math.max(reason === 'time' ? 900 : 300, sad - 150));
  };

  // the run goes on from the same board: after a mistake its clock runs on, after the clock ran out it starts again
  const goOn = () => {
    setSaving(false);
    g.lastSecond = -1;
    sfx.play('sd_revive');
    board.current?.cheerUp();
    setPhase('play');
    if (failReason === 'time') clk.start(game.spec.ms);
    else clk.resume();
  };
  const saveByAd = () => {
    const back = () => {
      setAdUsed(true);
      goOn();
    };
    if (adsFree) back();
    else ad.show(back);
  };
  const saveByGems = () => {
    if (saving) return;
    setSaving(true);
    setSaveErr(null);
    squad
      .blitzSave(gemSaves)
      .then(() => {
        setGemSaves((n) => n + 1);
        goOn();
      })
      .catch((e) => {
        setSaving(false);
        setSaveErr(String((e && e.message) || e) === 'not_enough_gems' ? 'Not enough gems' : 'Couldn\'t reach the server. Try again?');
      });
  };

  // Pays the run out once (the boards it cleared) and saves the record. Also when the player quits or restarts in the
  // middle of a run, so cleared boards always count.
  const settle = () => {
    if (!g.started || g.ended) return null;
    g.ended = true;
    const out = afterBlitz(profileRef.current, { cleared: g.cleared });
    if (uid) saveSquishdoku(uid, out.update, out.coins, out.xp, profileRef.current);
    return out;
  };

  const gameOver = () => {
    clk.pause();
    const out = settle() || { coins: 0, xp: 0, levelUps: [], newTop: false };
    const res = { ...out, cleared: g.cleared, best: Math.max(top, g.cleared) };
    setOver(res);
    setPhase('over');
    buddy.current?.react('timeup');
    if (res.newTop) {
      sfx.play('sd_blitzWin');
      haptics.win();
      [0, 300, 600].forEach((d, i) => setTimeout(() => fx.current?.burst('confetti', width * (0.25 + 0.25 * i), height * 0.3, 1), d));
    } else {
      sfx.play('sd_blitzFail');
      setTimeout(() => sfx.play('sd_drain'), 600);
    }
  };

  // `cell`: the last creature: every one turns happy and a bounce ripples out from it (one jump each, quick: the
  // next board is waiting), then the board goes
  const boardDone = (cell) => {
    clk.pause();
    setPhase('between');
    g.cleared = idx + 1;
    buddy.current?.react('solve');
    const beats = board.current?.hopAll(cell, { spread: 240, once: true }) || [];
    beats.forEach((at, i) => sfx.play('sd_hop', { delay: at, rate: 0.95 + i * 0.06 }));
    const out = Math.max(650, (beats.length ? beats[beats.length - 1] : 0) + 420);
    setTimeout(() => {
      setCleared(idx + 1);
      sfx.play('sd_pip', { rate: 0.9 + Math.min(12, idx) * 0.05 });
    }, 300);
    setTimeout(() => {
      sfx.play('sd_blitzNext');
      board.current?.outro();
    }, out);
    setTimeout(() => setIdx((i) => i + 1), out + 350);
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
        if (g.placed === n) boardDone(cell);
        return;
      }
      clk.pause();
      setPhase('between');
      board.current?.wrong(cell);
      sfx.play('sd_wrong');
      buddy.current?.react('wrong');
      setTimeout(() => haptics.wrong(), 200);
      g.combo = 0;
      // (as the wrong creature drops away)
      setTimeout(() => lose('mistake', cell), 900);
    },
    // eslint-disable-next-line react-hooks/exhaustive-deps
    [game, idx],
  );

  // web, development only: the browser tests play a board without finding the cushions on screen (src/web/README.md)
  if (__DEV__ && typeof window !== 'undefined' && window.document) {
    window.__sdk = {
      phase: () => phaseRef.current,
      // the answer's cells, row by row (each row's creature), and a cell that isn't one
      answer: () => (game ? game.puzzle.solution.map((c, r) => r * game.puzzle.n + c) : []),
      miss: () => (game ? game.puzzle.solution.findIndex((c) => c !== 0) * game.puzzle.n : -1),
      tap: (cell) => onTap(cell),
      // the board's clock running out now; the save card's free save
      timeUp: () => phaseRef.current === 'play' && lose('time'),
      save: () => phaseRef.current === 'save' && goOn(),
    };
  }
  const onTapPiece = useCallback((cell) => {
    board.current?.wiggle(cell);
    sfx.play('sd_squeak', { rate: 0.85 + Math.random() * 0.35 });
  }, []);

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
    settle();
    onExit();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [clk, onExit]);
  useEffect(() => {
    const sub = BackHandler.addEventListener('hardwareBackPress', () => {
      if (phaseRef.current === 'play') pause();
      else if (phaseRef.current === 'save') gameOver();
      else exit();
      return true;
    });
    return () => sub.remove();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [pause, exit]);
  useEffect(() => {
    const sub = AppState.addEventListener('change', (s) => {
      if (s !== 'active') pause();
    });
    return () => sub.remove();
  }, [pause]);

  const again = () => {
    settle();
    setRun((r) => r + 1);
  };
  const barW = 196;
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

  // REDESIGN_V8: the top bar and the run's glass on the left, the board in the middle, the buddy right
  const beat = cleared > top && top > 0;
  const headerEl = (
    <>
      {/* the Crib's top bar: pause (back once it's over), BLITZ MODE and the board */}
      <View style={styles.header}>
        <CribButton face="orange" icon={phase === 'play' ? 'pause' : 'back'} size={44} onPress={phase === 'play' ? pause : exit} />
        <View style={styles.titleBox}>
          <RoomTitle title="Blitz Mode" />
          <Text style={styles.boardNo}>{`BOARD ${idx + 1}`}</Text>
        </View>
      </View>
    </>
  );
  const glassEl = (
    <>
      {/* the boards cleared, the record, the rule and the board's clock, on the Crib's brown glass */}
      <View style={styles.glass}>
        <View style={styles.scoreRow}>
          <View style={styles.score}>
            <Text style={styles.scoreNum}>{cleared}</Text>
            <Text style={styles.scoreLabel}>CLEARED</Text>
          </View>
          <View style={styles.scoreSep} />
          <View style={styles.score}>
            <Text style={[styles.scoreNum, beat && styles.scoreGold]}>{Math.max(top, cleared)}</Text>
            <Text style={[styles.scoreLabel, beat && styles.scoreGold]}>{beat ? 'NEW BEST!' : 'BEST'}</Text>
          </View>
        </View>
        <View style={styles.rules}>
          <Chip bg="#e01e4a" color="#ffffff">1 MISTAKE = GAME OVER</Chip>
        </View>
        <View style={styles.barRow}>
          <TimerBar frac={clk.frac} width={barW} warn={warn} label={label} />
        </View>
      </View>
    </>
  );
  const boardEl = (
    <>
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
    </>
  );
  const bottomEl = (
    <>
      {/* the player's selected creature cheering them on */}
      <View style={styles.bottom}>
        <Buddy ref={buddy} creatureKey={buddyKey} uri={buddyUri} paused={phase === 'paused' || phase === 'over' || phase === 'save'} size={80} />
        <Text style={styles.hint}>{'Tap to place · no ✕ in Blitz\none mistake ends the run!'}</Text>
      </View>
    </>
  );
  return (
    <View style={styles.fill} onLayout={onRoot}>
      {root ? <Room room={ROOM} phase="day" width={root.w} height={root.h} /> : null}
      <View style={styles.wRow}>
        <View style={styles.wLeft}>
          {headerEl}
          {glassEl}
        </View>
        {boardEl}
        <View style={styles.wRight}>{bottomEl}</View>
      </View>

      <PauseCard visible={phase === 'paused'} onResume={resume} onQuit={exit} />
      <BlitzSaveCard
        visible={phase === 'save'}
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
        onAd={saveByAd}
        onGems={saveByGems}
        onEnd={gameOver}
      />
      <BlitzOverCard visible={phase === 'over'} res={over} onAgain={again} onQuit={exit} />
      {/* over the cards: a new best's confetti rains on top of everything */}
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
  header: { flexDirection: 'row', alignItems: 'center', alignSelf: 'stretch', gap: 8, paddingHorizontal: 0, zIndex: 3 },
  titleBox: { flex: 1, minWidth: 0 },
  boardNo: { fontFamily: F.heavy, fontSize: 11, color: '#ffffff', letterSpacing: 0.8, marginTop: -2, textShadowColor: '#5b3a29', textShadowRadius: 1.5, textShadowOffset: { width: 0, height: 1 } },
  glass: { alignSelf: 'stretch', alignItems: 'center', marginTop: 2, paddingHorizontal: 12, paddingTop: 6, paddingBottom: 6, borderRadius: 20, backgroundColor: GLASS, borderWidth: 2, borderColor: 'rgba(255,255,255,0.9)', zIndex: 1 },
  rules: { flexDirection: 'row', gap: 6, marginTop: 6 },
  scoreRow: { flexDirection: 'row', alignItems: 'center', gap: 14 },
  score: { alignItems: 'center', minWidth: 64 },
  scoreNum: { fontFamily: F.display, fontSize: 30, color: '#ffffff', includeFontPadding: false, textShadowColor: '#5b3a29', textShadowRadius: 1.5, textShadowOffset: { width: 0, height: 2 } },
  scoreLabel: { fontFamily: F.display, fontSize: 10.5, color: '#ffe6c2', letterSpacing: 1, marginTop: -2 },
  scoreGold: { color: '#ffd23a' },
  scoreSep: { width: 2, alignSelf: 'stretch', marginVertical: 6, borderRadius: 1, backgroundColor: 'rgba(255,255,255,0.35)' },
  barRow: { marginTop: 8 },
  boardArea: { flex: 1, alignSelf: 'stretch', zIndex: 2 },
  // REDESIGN_V8: the left column, the board, the right column
  wRow: { flex: 1, flexDirection: 'row' },
  wLeft: { width: 236, paddingTop: 8, paddingLeft: 10, gap: 6, zIndex: 3 },
  wRight: { width: 206, justifyContent: 'flex-end', alignItems: 'center', paddingBottom: 10, zIndex: 3 },
  bottom: { flexDirection: 'column', alignItems: 'center', alignSelf: 'auto', justifyContent: 'center', gap: 12, paddingHorizontal: 14, paddingVertical: 4, borderRadius: 22, backgroundColor: GLASS, borderWidth: 2, borderColor: 'rgba(255,255,255,0.9)', zIndex: 1 },
  hint: { fontFamily: F.heavy, fontSize: 11.5, color: '#ffffff', lineHeight: 16 },
  // the cards sit at elevation 50 (Overlays.js)
  fxTop: { zIndex: 60, elevation: 60 },
  countWrap: { ...StyleSheet.absoluteFillObject, alignItems: 'center', justifyContent: 'center' },
  count: { fontFamily: F.display, fontSize: 110, color: '#ffffff', textShadowColor: '#0c5a9c', textShadowOffset: { width: 0, height: 7 }, textShadowRadius: 1, includeFontPadding: false },
  go: { color: '#ffd23a', textShadowColor: '#9c4d06', fontSize: 96 },
});
