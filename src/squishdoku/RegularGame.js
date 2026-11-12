import React, { useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { Animated, AppState, BackHandler, Easing, StyleSheet, Text, View, useWindowDimensions } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import sfx from '../audio/sfx';
import RoomBoard, { SDK_TILT } from './RoomBoard';
import Room, { roomGeometry } from '../hop/Room';
import { ROOMS } from '../hop/levels';
import { layout } from '../hop/board';
import { CribButton, PhasePill, RoomTitle } from '../crib/Hud';
import { PH } from '../crib/data';
import Buddy from './Buddy';
import { ScoreRow, TimerBar } from './Hud';
import { PauseCard, ResultCard, TimeUpCard } from './Overlays';
import { FxLayer, PopIn } from './fx';
import { makeHaptics, pickCreatures, prefetchImages, PLAY_SOUNDS, RESULT_SOUNDS, useClock } from './game';
import { afterLevel, clock, HEARTS_FROM, LEVELS, levelSpec, stageOf, starsFor, starsLeft } from './levels';
import { Heart } from '../components/Hearts';
import { BtnLabel, Chip, SdButton, XGlyph } from './ui';
import { F, INK, TIER_COLORS, TIER_NAMES } from './theme';
import { saveSquishdoku } from '../firebase/firestore';

// One Regular level: a fresh board for level `lv`, the timer with the
// creatures riding on it, ✕ marks, the solve, the result. Plays on until the
// player leaves (onExit). Since the 600 fixed levels, REPLAY, RETRY and
// RESTART play the same board again; NEXT moves on.
// Since 2026-11-07 it's played in one of the Crib's rooms, Squish Hop's way:
// the room behind (hop/Room.js), the board on its floor (RoomBoard.js), the
// Crib's top bar, and the creatures standing on their cushions (`cast`:
// stack/roster.js castOf, drawn by their cut-outs).

export default function RegularGame({ startLv, profile, uid, roster, cast = [], head = false, buddyKey, buddyUri, haptics: hapticsOn = true, onExit }) {
  const { width, height } = useWindowDimensions();
  const insets = useSafeAreaInsets();
  // the board's creatures: the player's own (all of them if they own none)
  const castRef = useRef(cast);
  castRef.current = cast;
  const haptics = useRef(makeHaptics(hapticsOn)).current;
  const [lv, setLv] = useState(startLv);
  const [attempt, setAttempt] = useState(0);
  const [game, setGame] = useState(null); // { spec, puzzle, pieces, score }
  // loading | intro | play | paused | solved | result | timeup | out (the last
  // heart just went: the board locks) | nohearts (its card)
  const [phase, setPhase] = useState('loading');
  const [xTool, setXTool] = useState(false);
  const [left, setLeft] = useState(3);
  const [heartsLost, setHeartsLost] = useState(0);
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
    sfx.preload([...PLAY_SOUNDS, 'sd_timeUp', 'sd_select', 'fs_heart', 'sd_blitzFail']);
  }, []);

  // --- a new board ---------------------------------------------------------------
  useEffect(() => {
    let alive = true;
    const spec = levelSpec(lv, head);
    setPhase('loading');
    setResult(null);
    setXTool(false);
    setLeft(3);
    setHeartsLost(0);
    setPerfect(true);
    setWarn(false);
    setLabel(clock(spec.limitMs));
    Object.assign(g, { placed: 0, mistakes: 0, usedX: false, combo: 0, lastSecond: -1, left: 3 });
    clk.reset();
    (async () => {
      // the level's own board, the same every time (levelData.js)
      const { puzzle } = spec;
      const mine = castRef.current.filter((c) => c.mine);
      const pieces = pickCreatures(mine.length ? mine : castRef.current, spec.n);
      const score = pickCreatures(roster, 3);
      await prefetchImages([...pieces.map((c) => c && c.source && c.source.uri), ...score]);
      if (!alive) return;
      // HEAD START: the first row's creature, placed for you after the intro
      const given = spec.head ? puzzle.solution[0] : null;
      setGame({ spec, puzzle, pieces, score, given, id: `${lv}-${attempt}` });
      setPhase('intro');
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

  // the last heart: the board locks at once (no more taps, the clock stops),
  // the wrong creature's shake plays out, then the card
  const outOfHearts = () => {
    clk.pause();
    setPhase('out');
    setWarn(false);
    const r = afterLevel(profileRef.current, game.spec, { solved: false });
    if (uid) saveSquishdoku(uid, r.update, 0);
    setTimeout(() => {
      sfx.play('sd_blitzFail');
      buddy.current?.react('timeup');
      haptics.wrong();
      board.current?.shake();
    }, 450);
    setTimeout(() => setPhase('nohearts'), 1000);
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
        // from level 46: a heart goes, and the last one ends the try
        if (game.spec.hearts) {
          setHeartsLost(g.mistakes);
          setTimeout(() => sfx.play('fs_heart'), 160);
          if (g.mistakes >= game.spec.hearts) {
            outOfHearts();
            return;
          }
        }
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
  const spec = game ? game.spec : levelSpec(lv, head);
  const stage = stageOf(lv);
  const room = ROOMS[stage.room];
  const ph = PH[stage.phase] || PH.day;
  const barW = Math.min(width - 48, 400);
  // the room fills the screen; the board lies on its floor (from layouts, not
  // measure(): the screen slides in)
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
  const floorY = root ? roomGeometry(stage.room, root.w, root.h).floorY : 0;
  const B = useMemo(() => (area && root ? layout(spec.n, spec.n, area.w, area.h, floorY - area.y, SDK_TILT, 80) : null), [area, root, spec.n, floorY]);
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
    <View style={styles.fill} onLayout={onRoot}>
      {root ? <Room room={stage.room} phase={stage.phase} width={root.w} height={root.h} /> : null}

      {/* the Crib's top bar: pause (back once it's over), the room, the time of day */}
      <View style={[styles.header, { paddingTop: insets.top + 6 }]}>
        <CribButton face="pink" icon={phase === 'play' ? 'pause' : 'back'} size={44} onPress={phase === 'play' ? pause : exit} />
        <View style={styles.titleBox}>
          <RoomTitle title={room.name} />
          <View style={styles.chips}>
            <Text style={styles.sub} numberOfLines={1}>{`LEVEL ${lv} · ${spec.n}×${spec.n}`}</Text>
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
        {room.dance ? null : <PhasePill sun={ph.sun} label={ph.label} />}
      </View>

      {/* the score creatures and the clock, on the Crib's brown glass */}
      <View style={styles.glass}>
        {game ? <ScoreRow uris={game.score} left={left} perfect={perfect && phase !== 'loading'} size={40} /> : <View style={{ height: 48 }} />}
        {spec.hearts ? (
          <View style={styles.hearts}>
            {Array.from({ length: spec.hearts }, (_, i) => (
              <Heart key={i} on={i < spec.hearts - heartsLost} size={18} empty="rgba(255,255,255,0.16)" />
            ))}
          </View>
        ) : null}
        <Text style={[styles.perfectText, !perfect && styles.perfectLost]}>{perfect ? 'NO ✕ + NO MISTAKES = PERFECT ×3' : 'BEAT THE CREATURES ON THE CLOCK'}</Text>
        <View style={styles.barRow}>
          <TimerBar frac={clk.frac} width={barW} markers={perfect ? [] : markers} warn={warn} label={label} />
        </View>
      </View>

      {/* the board on the room's floor */}
      <View style={styles.boardArea} onLayout={onArea}>
        {game && phase !== 'loading' && B ? (
          <View style={[StyleSheet.absoluteFill, { opacity: hidden ? 0 : 1 }]}>
            <RoomBoard
              key={game.id}
              ref={board}
              puzzle={game.puzzle}
              B={B}
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
          <View style={styles.makingWrap}>
            <Making />
          </View>
        )}
        {/* never takes touches: faded out, it still sat over the board's middle */}
        {banner ? (
          <View pointerEvents="none" style={styles.bannerWrap}>
            <PopIn key={banner} trigger={banner} from={2} twist={-6}>
              <FadeAway delay={lv === HEARTS_FROM ? 2400 : 750}>
                <Text style={styles.banner}>{`LEVEL ${lv}`}</Text>
                {lv === HEARTS_FROM ? <Text style={styles.bannerSub}>{`NEW: ${spec.hearts} HEARTS!\nA MISTAKE COSTS ONE`}</Text> : null}
              </FadeAway>
            </PopIn>
          </View>
        ) : null}
      </View>

      {/* the player's Lobby creature cheering them on, beside the tools */}
      <View style={[styles.bottom, { marginBottom: Math.max(insets.bottom, 6) + 4 }]}>
        <Buddy ref={buddy} creatureKey={buddyKey} uri={buddyUri} paused={phase === 'paused' || phase === 'result' || phase === 'timeup' || phase === 'nohearts'} size={84} />
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
      <TimeUpCard visible={phase === 'timeup' || phase === 'nohearts'} hearts={phase === 'nohearts' ? spec.hearts : 0} uri={game?.score[0]} onRetry={() => setAttempt((a) => a + 1)} onMap={exit} />
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
      <Text style={styles.makingText}>Setting up the board…</Text>
    </View>
  );
}

function FadeAway({ children, delay = 750 }) {
  const t = useRef(new Animated.Value(1)).current;
  useEffect(() => {
    Animated.timing(t, { toValue: 0, duration: 400, delay, useNativeDriver: true }).start();
  }, [t, delay]);
  return <Animated.View style={{ opacity: t, transform: [{ translateY: t.interpolate({ inputRange: [0, 1], outputRange: [-30, 0] }) }] }}>{children}</Animated.View>;
}

const GLASS = 'rgba(91,58,41,0.75)'; // the Crib's pills
const styles = StyleSheet.create({
  fill: { flex: 1 },
  header: { flexDirection: 'row', alignItems: 'center', alignSelf: 'stretch', gap: 8, paddingHorizontal: 12, zIndex: 3 },
  titleBox: { flex: 1, minWidth: 0 },
  chips: { flexDirection: 'row', alignItems: 'center', gap: 5, marginTop: -2 },
  sub: { flexShrink: 0, fontFamily: F.heavy, fontSize: 11, color: '#ffffff', letterSpacing: 0.6, textShadowColor: '#5b3a29', textShadowRadius: 1.5, textShadowOffset: { width: 0, height: 1 } },
  glass: { alignSelf: 'center', alignItems: 'center', marginTop: 6, paddingHorizontal: 12, paddingTop: 4, paddingBottom: 8, borderRadius: 20, backgroundColor: GLASS, borderWidth: 2, borderColor: 'rgba(255,255,255,0.9)', zIndex: 1 },
  hearts: { position: 'absolute', top: 14, right: 10, flexDirection: 'row', gap: 2 },
  bannerSub: { fontFamily: F.display, fontSize: 17, color: '#ffe08a', textAlign: 'center', letterSpacing: 1, marginTop: 4, textShadowColor: INK, textShadowOffset: { width: 0, height: 2 }, textShadowRadius: 1 },
  perfectText: { fontFamily: F.display, fontSize: 10.5, letterSpacing: 0.6, color: '#ffe08a', marginTop: 2 },
  perfectLost: { color: '#e9d6ff' },
  barRow: { marginTop: 22 },
  boardArea: { flex: 1, alignSelf: 'stretch', zIndex: 2 },
  makingWrap: { ...StyleSheet.absoluteFillObject, alignItems: 'center', justifyContent: 'center' },
  bottom: { flexDirection: 'row', alignItems: 'flex-end', alignSelf: 'center', justifyContent: 'center', gap: 10, paddingHorizontal: 12, paddingTop: 4, paddingBottom: 6, borderRadius: 22, backgroundColor: GLASS, borderWidth: 2, borderColor: 'rgba(255,255,255,0.9)', zIndex: 1 },
  toolsCol: { alignItems: 'center', paddingBottom: 2 },
  tools: { flexDirection: 'row', gap: 8 },
  toolFace: { paddingHorizontal: 20, paddingVertical: 9 },
  hint: { fontFamily: F.heavy, fontSize: 11, color: '#ffffff', marginTop: 2, textAlign: 'center', lineHeight: 14 },
  making: { alignItems: 'center', gap: 10 },
  dots: { flexDirection: 'row', gap: 8, height: 30, alignItems: 'flex-end' },
  dot: { width: 14, height: 14, borderRadius: 7, backgroundColor: '#ff5cc6', borderWidth: 2.5, borderColor: '#ffffff' },
  makingText: { fontFamily: F.display, fontSize: 14, color: '#ffffff', textShadowColor: INK, textShadowRadius: 2, textShadowOffset: { width: 0, height: 1 } },
  bannerWrap: { position: 'absolute', alignSelf: 'center', top: '22%' },
  banner: { fontFamily: F.display, fontSize: 40, color: '#ffffff', textShadowColor: INK, textShadowOffset: { width: 0, height: 4 }, textShadowRadius: 1, letterSpacing: 2 },
});
