import React, { useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { Animated, AppState, BackHandler, Easing, StyleSheet, Text, View, useWindowDimensions } from 'react-native';
import RoundButton from '../components/candy/RoundButton';
import sfx from '../audio/sfx';
import Board from './Board';
import Buddy from './Buddy';
import { ScoreRow, TimerBar } from './Hud';
import { PauseCard, ResultCard, TimeUpCard } from './Overlays';
import { FxLayer, PopIn } from './fx';
import { getPuzzle, makeHaptics, pickCreatures, prefetchImages, prefetchPuzzle, PLAY_SOUNDS, RESULT_SOUNDS, useClock } from './game';
import { afterLevel, clock, LEVELS, levelSpec, record, starsFor, starsLeft } from './levels';
import { BtnLabel, Chip, SdButton, XGlyph } from './ui';
import { F, INK, TIER_COLORS, TIER_NAMES } from './theme';
import { saveSquishdoku } from '../firebase/firestore';

// One Regular level: a fresh board for level `lv`, the timer with the
// creatures riding on it, ✕ marks, the solve, the result. Plays on until the
// player leaves (onExit) — REPLAY makes a new board, NEXT moves on.

const PAUSE_GLYPH = (
  <View style={{ flexDirection: 'row', gap: 4 }}>
    <View style={{ width: 5, height: 15, borderRadius: 2, backgroundColor: '#ffffff' }} />
    <View style={{ width: 5, height: 15, borderRadius: 2, backgroundColor: '#ffffff' }} />
  </View>
);

export default function RegularGame({ startLv, profile, uid, roster, head = false, buddyKey, buddyUri, haptics: hapticsOn = true, onExit }) {
  const { width, height } = useWindowDimensions();
  const haptics = useRef(makeHaptics(hapticsOn)).current;
  const [lv, setLv] = useState(startLv);
  const [attempt, setAttempt] = useState(0);
  const [game, setGame] = useState(null); // { spec, puzzle, pieces, score }
  const [phase, setPhase] = useState('loading'); // loading | intro | play | paused | solved | result | timeup
  const [xTool, setXTool] = useState(false);
  const [left, setLeft] = useState(3);
  const [perfect, setPerfect] = useState(true);
  const [label, setLabel] = useState('');
  const [warn, setWarn] = useState(false);
  const [result, setResult] = useState(null);
  const [banner, setBanner] = useState(0);
  const board = useRef(null);
  const buddy = useRef(null);
  const fx = useRef(null);
  const clk = useClock();
  const g = useRef({ placed: 0, mistakes: 0, usedX: false, combo: 0, lastSecond: -1, left: 3, lastMarkSound: 0 }).current;
  const profileRef = useRef(profile);
  profileRef.current = profile;
  const phaseRef = useRef(phase);
  phaseRef.current = phase;
  const unlockedRef = useRef(null);

  useEffect(() => {
    sfx.preload([...PLAY_SOUNDS, 'sd_timeUp', 'sd_select']);
  }, []);

  // --- a new board ---------------------------------------------------------------
  useEffect(() => {
    let alive = true;
    const spec = levelSpec(lv, record(profileRef.current).skill, head);
    setPhase('loading');
    setResult(null);
    setXTool(false);
    setLeft(3);
    setPerfect(true);
    setWarn(false);
    setLabel(clock(spec.limitMs));
    Object.assign(g, { placed: 0, mistakes: 0, usedX: false, combo: 0, lastSecond: -1, left: 3 });
    clk.reset();
    (async () => {
      const puzzle = await getPuzzle(spec.n, spec.tier);
      const pieces = pickCreatures(roster, spec.n);
      const score = pickCreatures(roster, 3);
      await prefetchImages([...pieces, ...score]);
      if (!alive) return;
      // HEAD START: the first row's creature, placed for you after the intro
      const given = spec.head ? puzzle.solution[0] : null;
      setGame({ spec, puzzle, pieces, score, given, id: `${lv}-${attempt}-${puzzle.seed}` });
      setPhase('intro');
      // the next level's board, made while this one is played
      if (lv < LEVELS) {
        const next = levelSpec(lv + 1, record(profileRef.current).skill, head);
        prefetchPuzzle(next.n, next.tier);
      }
    })();
    return () => {
      alive = false;
    };
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [lv, attempt]);

  // the board cascades in, the level banner pops, HEAD START's creature
  // drops in, then the clock starts
  useEffect(() => {
    if (phase !== 'intro' || !game) return undefined;
    const settled = 60 + (2 * game.spec.n - 1) * 34 + 450;
    const timers = [
      setTimeout(() => {
        board.current?.intro();
        sfx.play('sd_boardIn');
        setBanner((b) => b + 1);
      }, 60),
    ];
    if (game.given != null) {
      timers.push(
        setTimeout(() => {
          board.current?.place(game.given);
          sfx.play('sd_place');
          g.placed = 1;
        }, settled),
      );
    }
    timers.push(
      setTimeout(() => {
        setPhase('play');
        clk.start(game.spec.limitMs);
        buddy.current?.react('start');
      }, settled + (game.given != null ? 450 : 0)),
    );
    return () => timers.forEach(clearTimeout);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [phase, game]);

  // --- the clock: digits, creatures falling off, the last ten seconds -----------------
  const loseCreatures = useCallback(
    (now) => {
      if (now < g.left) {
        sfx.play('sd_starLost');
        haptics.tick();
      }
      g.left = now;
      setLeft(now);
    },
    [g, haptics],
  );
  useEffect(() => {
    if (phase !== 'play' || !game) return undefined;
    const { spec } = game;
    const timer = setInterval(() => {
      const ms = clk.elapsed();
      const rest = spec.limitMs - ms;
      setLabel(clock(rest));
      const sec = Math.ceil(rest / 1000);
      if (rest <= 10000 && sec !== g.lastSecond && rest > 0) {
        if (g.lastSecond < 0) buddy.current?.react('hurry');
        g.lastSecond = sec;
        sfx.play('sd_tick', { rate: sec <= 3 ? 1.3 : 1 });
        setWarn(true);
      }
      const perfectNow = !g.usedX && !g.mistakes;
      const now = perfectNow ? 3 : starsLeft(spec, ms, g.mistakes);
      if (now !== g.left) loseCreatures(now);
      if (rest <= 0) timeUp();
    }, 150);
    return () => clearInterval(timer);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [phase, game]);

  const timeUp = () => {
    if (phaseRef.current !== 'play') return;
    clk.pause();
    setPhase('timeup');
    setWarn(false);
    sfx.play('sd_timeUp');
    buddy.current?.react('timeup');
    haptics.wrong();
    board.current?.shake();
    const r = afterLevel(profileRef.current, game.spec, { solved: false });
    if (uid) saveSquishdoku(uid, r.update, 0);
  };

  // --- touches -------------------------------------------------------------------------
  const losePerfect = () => setPerfect(false);
  const mark = (cell, on, dragged) => {
    if (phaseRef.current !== 'play') return;
    board.current?.setMark(cell, on);
    const now = Date.now();
    if (!dragged || now - g.lastMarkSound > 45) {
      g.lastMarkSound = now;
      sfx.play(on ? 'sd_x' : 'sd_xOff', dragged ? { rate: 1 + Math.random() * 0.2 } : undefined);
    }
    haptics.tap();
    if (on && !g.usedX) {
      g.usedX = true;
      losePerfect();
    }
  };
  const marks = useRef(new Set());
  const onMark = useCallback((cell, on, dragged) => {
    if (on) marks.current.add(cell);
    else marks.current.delete(cell);
    mark(cell, on, dragged);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);
  useEffect(() => {
    marks.current = new Set();
  }, [game]);

  const onTap = useCallback(
    (cell) => {
      if (phaseRef.current !== 'play' || !game) return;
      if (xTool) {
        onMark(cell, !marks.current.has(cell), false);
        return;
      }
      const { n, solution } = game.puzzle;
      const r = Math.floor(cell / n);
      const c = cell % n;
      marks.current.delete(cell);
      if (solution[r] === c) {
        board.current?.place(cell);
        sfx.play('sd_place', { rate: 1 + Math.min(8, g.combo) * 0.06 });
        buddy.current?.react('right', g.combo + 1);
        haptics.place();
        g.combo++;
        g.placed++;
        if (g.placed === n) solved();
      } else {
        board.current?.wrong(cell);
        sfx.play('sd_wrong');
        buddy.current?.react('wrong');
        setTimeout(() => haptics.wrong(), 200);
        g.combo = 0;
        g.mistakes++;
        losePerfect();
        // the cell it can't be gets its ✕ (this one doesn't count as using ✕)
        setTimeout(() => {
          if (phaseRef.current === 'play' || phaseRef.current === 'paused') {
            marks.current.add(cell);
            board.current?.setMark(cell, true);
          }
        }, 950);
      }
    },
    // eslint-disable-next-line react-hooks/exhaustive-deps
    [game, xTool],
  );
  const onTapPiece = useCallback((cell) => {
    board.current?.wiggle(cell);
    sfx.play('sd_squeak', { rate: 0.85 + Math.random() * 0.35 });
    haptics.tap();
  }, [haptics]);

  // --- solved ----------------------------------------------------------------------
  const solved = () => {
    const ms = clk.elapsed();
    clk.pause();
    setPhase('solved');
    setWarn(false);
    sfx.preload(RESULT_SOUNDS);
    const score = starsFor(game.spec, { ms, mistakes: g.mistakes, usedX: g.usedX });
    const res = { solved: true, ms, mistakes: g.mistakes, ...score };
    const out = afterLevel(profileRef.current, game.spec, res);
    if (uid) saveSquishdoku(uid, out.update, out.coins, out.xp, profileRef.current);
    if (out.unlocked) unlockedRef.current = game.spec.lv + 1;
    setTimeout(() => {
      sfx.play('sd_solve');
      buddy.current?.react('solve');
      haptics.win();
      board.current?.hopAll();
      for (let r = 0; r < game.spec.n; r++) sfx.play('sd_hop', { delay: r * 75, rate: 0.9 + r * 0.06 });
    }, 420);
    setTimeout(() => {
      sfx.play('sd_confetti');
      fx.current?.burst('confetti', width / 2, height * 0.35, 1.1);
      fx.current?.burst('confetti', width * 0.25, height * 0.4, 0.8);
      fx.current?.burst('confetti', width * 0.75, height * 0.4, 0.8);
    }, 650);
    setTimeout(() => {
      setResult({ ...res, ...out });
      setPhase('result');
    }, 1700);
  };

  // --- pause, back, leaving --------------------------------------------------------------
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
    onExit({ unlocked: unlockedRef.current });
  }, [clk, onExit]);
  useEffect(() => {
    const sub = BackHandler.addEventListener('hardwareBackPress', () => {
      const p = phaseRef.current;
      if (p === 'play') pause();
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

  const toggleX = () => {
    const on = !xTool;
    setXTool(on);
    sfx.play(on ? 'sd_mode' : 'sd_modeOff');
    haptics.tap();
  };

  // --- layout ------------------------------------------------------------------------
  const spec = game ? game.spec : levelSpec(lv, record(profile).skill, head);
  // room left under it for the buddy and the tools
  const boardSize = Math.min(width - 24, height - 380, 460);
  const barW = Math.min(width - 40, 420);
  const markers = useMemo(
    () =>
      game
        ? [
            { at: 1 - game.spec.aMs / game.spec.limitMs, uri: game.score[2], gone: left < 3 },
            { at: 1 - game.spec.bMs / game.spec.limitMs, uri: game.score[1], gone: left < 2 },
          ]
        : [],
    [game, left],
  );
  const hidden = phase === 'paused';

  return (
    <View style={styles.fill}>
      <View style={styles.header}>
        <RoundButton size={40} onPress={phase === 'play' ? pause : exit}>
          {phase === 'play' ? PAUSE_GLYPH : <Text style={styles.backText}>‹</Text>}
        </RoundButton>
        <View style={styles.titleBox}>
          <Text style={styles.levelText}>{`LEVEL ${lv}`}</Text>
          <View style={styles.chips}>
            <Chip bg="#7a2fd6" color="#ffffff">{`${spec.n}×${spec.n}`}</Chip>
            <Chip bg={TIER_COLORS[spec.tier]} color="#ffffff">
              {TIER_NAMES[spec.tier]}
            </Chip>
            {spec.head ? (
              <Chip bg="#ffb02e" color="#ffffff">
                HEAD START
              </Chip>
            ) : null}
          </View>
        </View>
        <View style={{ width: 40 }} />
      </View>

      {game ? <ScoreRow uris={game.score} left={left} perfect={perfect && phase !== 'loading'} /> : <View style={{ height: 56 }} />}
      <View style={styles.perfectLine}>
        <Text style={[styles.perfectText, !perfect && styles.perfectLost]}>{perfect ? 'NO ✕ + NO MISTAKES = PERFECT ×3' : 'BEAT THE CREATURES ON THE CLOCK'}</Text>
      </View>
      <View style={styles.barRow}>
        <TimerBar frac={clk.frac} width={barW} markers={perfect ? [] : markers} warn={warn} label={label} />
      </View>

      <View style={styles.boardArea}>
        {game && phase !== 'loading' ? (
          <View style={{ opacity: hidden ? 0 : 1 }}>
            <Board
              key={game.id}
              ref={board}
              puzzle={game.puzzle}
              size={boardSize}
              pieces={game.pieces}
              allowX
              xTool={xTool}
              locked={phase !== 'play'}
              onTap={onTap}
              onMark={onMark}
              onTapPiece={onTapPiece}
            />
          </View>
        ) : (
          <Making />
        )}
        {/* never takes touches: faded out, it still sat over the board's middle */}
        {banner ? (
          <View pointerEvents="none" style={styles.bannerWrap}>
            <PopIn key={banner} trigger={banner} from={2} twist={-6}>
              <FadeAway>
                <Text style={styles.banner}>{`LEVEL ${lv}`}</Text>
              </FadeAway>
            </PopIn>
          </View>
        ) : null}
      </View>

      {/* the player's Lobby creature cheering them on, beside the tools */}
      <View style={styles.bottom}>
        <Buddy ref={buddy} creatureKey={buddyKey} uri={buddyUri} paused={phase === 'paused' || phase === 'result' || phase === 'timeup'} size={92} />
        <View style={styles.toolsCol}>
          <View style={styles.tools}>
            <SdButton kind={xTool ? 'white' : 'pink'} onPress={() => xTool && toggleX()} sound={null} faceStyle={styles.toolFace}>
              <BtnLabel kind={xTool ? 'purple' : 'pink'} size={15}>
                PLACE
              </BtnLabel>
            </SdButton>
            <SdButton kind={xTool ? 'purple' : 'white'} onPress={() => !xTool && toggleX()} sound={null} faceStyle={styles.toolFace}>
              <XGlyph size={13} color={xTool ? '#ffffff' : INK} />
              <BtnLabel kind="purple" size={15}>
                MARK
              </BtnLabel>
            </SdButton>
          </View>
          <Text style={styles.hint}>{xTool ? 'Tap or drag to mark ✕\nusing ✕ ends a PERFECT run' : 'Tap to place\nlong-press to mark ✕'}</Text>
        </View>
      </View>

      <FxLayer ref={fx} />
      <PauseCard visible={phase === 'paused'} onResume={resume} onRestart={() => setAttempt((a) => a + 1)} onQuit={exit} />
      <TimeUpCard visible={phase === 'timeup'} uri={game?.score[0]} onRetry={() => setAttempt((a) => a + 1)} onMap={exit} />
      <ResultCard
        visible={phase === 'result'}
        res={result}
        spec={spec}
        uris={game ? game.score : []}
        last={lv >= LEVELS}
        onMap={exit}
        onReplay={() => setAttempt((a) => a + 1)}
        onNext={() => {
          setLv((l) => Math.min(LEVELS, l + 1));
          setAttempt((a) => a + 1);
        }}
      />
    </View>
  );
}

// "Making your board…": three creatures-dots hopping while a big board is found.
function Making() {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const loop = Animated.loop(Animated.timing(t, { toValue: 1, duration: 900, easing: Easing.linear, useNativeDriver: true }));
    loop.start();
    return () => loop.stop();
  }, [t]);
  return (
    <View style={styles.making}>
      <View style={styles.dots}>
        {[0, 1, 2].map((i) => (
          <Animated.View
            key={i}
            style={[
              styles.dot,
              {
                transform: [
                  {
                    translateY: t.interpolate({
                      inputRange: [0, 0.15 + i * 0.2, 0.3 + i * 0.2, 0.45 + i * 0.2, 1],
                      outputRange: [0, 0, -14, 0, 0],
                    }),
                  },
                ],
              },
            ]}
          />
        ))}
      </View>
      <Text style={styles.makingText}>Making a fresh board…</Text>
    </View>
  );
}

function FadeAway({ children }) {
  const t = useRef(new Animated.Value(1)).current;
  useEffect(() => {
    Animated.timing(t, { toValue: 0, duration: 400, delay: 750, useNativeDriver: true }).start();
  }, [t]);
  return <Animated.View style={{ opacity: t, transform: [{ translateY: t.interpolate({ inputRange: [0, 1], outputRange: [-30, 0] }) }] }}>{children}</Animated.View>;
}

const styles = StyleSheet.create({
  fill: { flex: 1, alignItems: 'center' },
  header: { flexDirection: 'row', alignItems: 'center', alignSelf: 'stretch', paddingHorizontal: 14, paddingTop: 6, paddingBottom: 4 },
  backText: { fontFamily: F.display, fontSize: 28, color: '#ffffff', marginTop: -4 },
  titleBox: { flex: 1, alignItems: 'center', gap: 2 },
  levelText: { fontFamily: F.display, fontSize: 22, color: '#ffffff', textShadowColor: INK, textShadowOffset: { width: 0, height: 2.5 }, textShadowRadius: 1, letterSpacing: 1 },
  chips: { flexDirection: 'row', gap: 5 },
  perfectLine: { height: 18, justifyContent: 'center' },
  perfectText: { fontFamily: F.display, fontSize: 10.5, letterSpacing: 0.6, color: '#b86200' },
  perfectLost: { color: '#8a5fc0' },
  barRow: { marginTop: 26, marginBottom: 6 },
  boardArea: { flex: 1, alignItems: 'center', justifyContent: 'center', alignSelf: 'stretch' },
  bottom: { flexDirection: 'row', alignItems: 'flex-end', alignSelf: 'stretch', justifyContent: 'center', gap: 10, paddingHorizontal: 12, marginTop: 4, marginBottom: 8 },
  toolsCol: { alignItems: 'center', paddingBottom: 2 },
  tools: { flexDirection: 'row', gap: 8 },
  toolFace: { paddingHorizontal: 20, paddingVertical: 9 },
  hint: { fontFamily: F.heavy, fontSize: 11, color: '#6a4a9a', marginTop: 2, textAlign: 'center', lineHeight: 14 },
  making: { alignItems: 'center', gap: 10 },
  dots: { flexDirection: 'row', gap: 8, height: 30, alignItems: 'flex-end' },
  dot: { width: 14, height: 14, borderRadius: 7, backgroundColor: '#ff5cc6', borderWidth: 2.5, borderColor: '#ffffff' },
  makingText: { fontFamily: F.display, fontSize: 14, color: INK },
  bannerWrap: { position: 'absolute', alignSelf: 'center', top: '40%' },
  banner: { fontFamily: F.display, fontSize: 40, color: '#ffffff', textShadowColor: INK, textShadowOffset: { width: 0, height: 4 }, textShadowRadius: 1, letterSpacing: 2 },
});
