import React, { memo, useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { Animated, Easing, Pressable, StyleSheet, Text, View } from 'react-native';
import Reanimated, { useFrameCallback, useSharedValue, withTiming } from 'react-native-reanimated';
import Svg, { Circle, Path } from 'react-native-svg';
import { LinearGradient } from 'expo-linear-gradient';
import CreatureThumbnail, { Sprite, usePlanValues } from '../components/CreatureThumbnail';
import { carePlan } from './careState';
import TutTarget from '../tutorial/Target';
import { candyFonts } from '../theme/candyTheme';
import { Piece, RoomBackdrop, RoomFront } from './art';
import { BUBBLE, SCENE_H, SCENE_W, SIZE } from './data';
import { CRIB_MAX } from './model';
import { lights as lampsOf, placedDecor, visuals } from './home';
import { DanceFloor, DanceLights } from './Dance';
import { DecorLayer } from './Decor';
import { Night } from './Night';
import { YardGames, useYardMotion } from './Yard';
import { EF, sample } from '../plush/ease';

// One room of the Crib, the design's 852×393 scene drawn at `scale`: the
// room (with the player's themes), the dance room's floor and lights or the
// yard's games, the furniture behind, the decor, the creatures (sorted by
// their feet so the lower ones are in front), the furniture in front, and
// the evening / night with the lamps lit.
//
// `pets`: what the screen derives from the model for the room on screen —
//   { id, creature, x, y, mood, need, since, from, bathing, food, plus,
//     selected, game } — x/y are the feet, scene units; `from` is where the
//   creature teleported from (it pops in), `plus` a { text, at } label,
//   `game` its yard spot while it plays there.
// A creature that leaves the list plays out (a ghost for half a second).
// `home` is the furniture (home.js) — it changes in place, `homeRev` says
// when. In Edit mode the creatures step out and the decor can be dragged.

const INK = '#5b3a29';
const TAU = Math.PI * 2;
const TELEPORT_MS = 520;
const WALK_PX_S = 120;

// the design's teleport (squish-rig tick: tp-out, tp-in), sampled
const TP_N = 32;
const TP_IN = {
  input: sample(TP_N, (u) => u),
  scale: sample(TP_N, (u) => Math.max(0.01, EF.bouncy(u))),
  spin: sample(TP_N, (u) => `${(540 * (1 - EF.soft(u))).toFixed(1)}deg`),
};
const TP_OUT = {
  input: TP_IN.input,
  scale: sample(TP_N, (u) => 1 - EF.snappy(u) * 0.95),
  stretch: sample(TP_N, (u) => 1 + 0.4 * EF.snappy(u) * 0.95),
  spin: sample(TP_N, (u) => `${(720 * EF.soft(u)).toFixed(1)}deg`),
  opacity: sample(TP_N, (u) => 1 - u * u),
};

// ---- what floats around a creature -------------------------------------------

// the need's glyph in its bubble (the design's isBath / isFood / isSleep)
function NeedGlyph({ need, size }) {
  return (
    <Svg width={size} height={size} viewBox="0 0 24 24">
      {need === 'clean' ? (
        <>
          <Path d="M3 12h18v1.5a5.5 5.5 0 0 1-5.5 5.5h-7A5.5 5.5 0 0 1 3 13.5z" fill="#fff" />
          <Path d="M6 12V6.5a2 2 0 0 1 4 0" stroke="#fff" strokeWidth={2.2} fill="none" strokeLinecap="round" />
          <Circle cx={14} cy={8} r={2.2} fill="#fff" />
          <Circle cx={18.5} cy={5.5} r={1.5} fill="#fff" />
        </>
      ) : need === 'tummy' ? (
        <>
          <Circle cx={12} cy={12} r={9} fill="#fff" />
          <Circle cx={8.8} cy={9.8} r={1.7} fill="#c25e00" />
          <Circle cx={14.6} cy={8.6} r={1.4} fill="#c25e00" />
          <Circle cx={10.8} cy={15} r={1.6} fill="#c25e00" />
          <Circle cx={15.6} cy={14} r={1.3} fill="#c25e00" />
        </>
      ) : (
        <Path d="M15.5 3a8.8 8.8 0 1 0 6 14A7.2 7.2 0 0 1 15.5 3z" fill="#fff" />
      )}
    </Svg>
  );
}

// The need bubble over a creature's head (the design's speech bubble: 40×46
// scene px, 50 px above the box, a ring and a tail): pops in, pulses and
// floats; tapping it opens the card like the creature does.
const NeedBubble = memo(function NeedBubble({ need, box, scale, onPress, phase = 0 }) {
  const t = useRef(new Animated.Value(0)).current;
  const f = useRef(new Animated.Value(0)).current;
  const pop = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const lin = (v, ms) => Animated.loop(Animated.timing(v, { toValue: 1, duration: ms, easing: Easing.linear, useNativeDriver: true }));
    t.setValue(phase % 1);
    f.setValue((phase * 1.4) % 1);
    const a = [lin(t, 1200), lin(f, 3000)];
    a.forEach((x) => x.start());
    Animated.timing(pop, { toValue: 1, duration: 220, easing: Easing.linear, useNativeDriver: true }).start();
    return () => a.forEach((x) => x.stop());
  }, [t, f, pop, phase]);
  const w = 40 * scale;
  const ring = INK;
  const colors = BUBBLE[need] || BUBBLE.clean;
  const S = sample(16, (u) => u);
  return (
    <Animated.View
      style={{
        position: 'absolute',
        left: box / 2 - w / 2,
        top: -50 * scale,
        width: w,
        height: 46 * scale,
        opacity: pop,
        transform: [
          { translateY: Animated.add(f.interpolate({ inputRange: S, outputRange: S.map((u) => Math.sin(TAU * u) * 3 * scale) }), pop.interpolate({ inputRange: [0, 1], outputRange: [10 * scale, 0] })) },
          { scale: Animated.multiply(pop.interpolate({ inputRange: S, outputRange: S.map((u) => EF.bouncy(u)) }), t.interpolate({ inputRange: S, outputRange: S.map((u) => 1 + 0.07 * (0.5 + 0.5 * Math.sin(TAU * u))) })) },
        ],
      }}
    >
      <Pressable onPress={onPress} hitSlop={6} style={{ width: w, height: 46 * scale }}>
        {/* the tail */}
        <View style={{ position: 'absolute', left: w / 2 - 6 * scale, top: 31 * scale, width: 12 * scale, height: 12 * scale, backgroundColor: '#fff', borderRightWidth: 2.5 * scale, borderBottomWidth: 2.5 * scale, borderColor: ring, transform: [{ rotate: '45deg' }] }} />
        {/* the ring's shadow lip, then the bubble */}
        <View style={{ position: 'absolute', left: -2.5 * scale, top: 1.5 * scale, width: w + 5 * scale, height: w + 5 * scale, borderRadius: w, backgroundColor: ring }} />
        <View style={{ position: 'absolute', left: -2.5 * scale, top: -2.5 * scale, width: w + 5 * scale, height: w + 5 * scale, borderRadius: w, backgroundColor: ring }} />
        <LinearGradient colors={colors} style={{ position: 'absolute', left: 0, top: 0, width: w, height: w, borderRadius: w / 2, borderWidth: 3 * scale, borderColor: '#fff', alignItems: 'center', justifyContent: 'center', overflow: 'hidden' }}>
          <LinearGradient colors={['rgba(255,255,255,0.8)', 'rgba(255,255,255,0.05)']} style={{ position: 'absolute', left: '14%', right: '14%', top: 3 * scale, height: '40%', borderRadius: 999 }} />
          <NeedGlyph need={need} size={22 * scale} />
        </LinearGradient>
      </Pressable>
    </Animated.View>
  );
});

// "+12 TUMMY", floating up and fading (the design's plus label: gold with a
// brown outline, 22 px over the box)
const PlusLabel = memo(function PlusLabel({ plus, box, scale }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    if (!plus) return undefined;
    t.setValue(0);
    const a = Animated.timing(t, { toValue: 1, duration: 1600, easing: Easing.linear, useNativeDriver: true });
    a.start();
    return () => a.stop();
  }, [plus, t]);
  if (!plus) return null;
  const S = sample(16, (u) => u);
  return (
    <Animated.View
      pointerEvents="none"
      style={{
        position: 'absolute',
        left: box / 2 - 60 * scale,
        width: 120 * scale,
        top: -22 * scale,
        alignItems: 'center',
        opacity: t.interpolate({ inputRange: [0, 0.15, 0.7, 1], outputRange: [0, 1, 1, 0] }),
        transform: [{ translateY: t.interpolate({ inputRange: S, outputRange: S.map((u) => -26 * scale * EF.snappy(u)) }) }],
      }}
    >
      <Text style={[styles.plus, { fontSize: 15 * scale }]}>{plus.text}</Text>
    </Animated.View>
  );
});

// ---- a creature ------------------------------------------------------------------

// The care state's motion (careState.js) as a transform: the body about
// 50% 92% (translate, rotate, skew, squash), and its turn about the upright
// axis (the twirl) about 50% 55%.
function careStyles(tr, v, box) {
  const { ch, input } = tr;
  const I = (c, mul = 1) => (typeof ch[c] === 'number' ? ch[c] * mul : v.interpolate({ inputRange: input, outputRange: ch[c].map((x) => x * mul) }));
  const D = (c) => (typeof ch[c] === 'number' ? `${ch[c]}deg` : v.interpolate({ inputRange: input, outputRange: ch[c].map((x) => `${x.toFixed(2)}deg`) }));
  const k = box / 100;
  const py = box * 0.42;
  const sy = box * 0.05;
  return {
    body: { width: box, height: box, transform: [{ translateX: I('tx', k) }, { translateY: I('ty', k) }, { translateY: py }, { rotate: D('rot') }, { skewX: D('skx') }, { scaleX: I('sx') }, { scaleY: I('sy') }, { translateY: -py }] },
    spin: typeof ch.spin === 'number' && !ch.spin ? null : { width: box, height: box, transform: [{ perspective: 300 }, { translateY: sy }, { rotateY: D('spin') }, { translateY: -sy }] },
  };
}

function Pet({ pet, index, scale, onPress, host, yard }) {
  const box = SIZE * scale;
  const motion = useYardMotion(pet.game, index, pet.game ? yard : null, scale, box);
  const left = (pet.x - SIZE / 2) * scale;
  const top = (pet.y - SIZE) * scale;
  // walks (the yard's wander) hop along; teleports jump
  const pos = useRef(new Animated.ValueXY({ x: left, y: top })).current;
  const lastSince = useRef(pet.since);
  const [walking, setWalking] = useState(false);
  useEffect(() => {
    const teleported = lastSince.current !== pet.since;
    lastSince.current = pet.since;
    const cur = { x: pos.x.__getValue(), y: pos.y.__getValue() };
    const d = Math.hypot(left - cur.x, top - cur.y);
    if (teleported || d < 1 || d > 400 * scale) {
      pos.setValue({ x: left, y: top });
      setWalking(false);
      return undefined;
    }
    setWalking(true);
    const a = Animated.timing(pos, { toValue: { x: left, y: top }, duration: (d / (WALK_PX_S * scale)) * 1000, easing: Easing.linear, useNativeDriver: true });
    a.start(({ finished }) => finished && setWalking(false));
    return () => a.stop();
  }, [left, top, pet.since, pos, scale]);

  // Pops in after a teleport (the design's tp-in: half a second after it
  // left, grows with a bounce while turning about its upright axis) — only
  // for an arrival happening now. Walking into a room shows everyone as
  // they are, however recently they came.
  const arriving = () => !!pet.from && Date.now() - pet.since < TELEPORT_MS * 2;
  const pop = useRef(new Animated.Value(arriving() ? 0 : 1)).current;
  useEffect(() => {
    if (!arriving()) {
      pop.setValue(1);
      return undefined;
    }
    pop.setValue(0);
    const wait = Math.max(0, pet.since + TELEPORT_MS - Date.now());
    const a = Animated.sequence([Animated.timing(pop, { toValue: 0, duration: wait, useNativeDriver: true }), Animated.timing(pop, { toValue: 1, duration: TELEPORT_MS, easing: Easing.linear, useNativeDriver: true })]);
    a.start();
    return () => a.stop();
  }, [pet.since]); // eslint-disable-line react-hooks/exhaustive-deps

  // the care state on top of the plush mood, and its particles
  const seed = useMemo(() => String(pet.id).split('').reduce((a, c) => a * 31 + c.charCodeAt(0), 7) % 9973, [pet.id]);
  const careKey = walking ? 'walk' : pet.careKey || 'idle';
  const head = (pet.creature.rig && pet.creature.rig.head) || 30;
  const cplan = useMemo(() => carePlan(careKey, { head, seed }), [careKey, head, seed]);
  const planned = useMemo(() => ({ body: [cplan.body], sprites: cplan.sprites }), [cplan]);
  const valueOf = usePlanValues(planned, seed);
  const care = useMemo(() => careStyles(cplan.body, valueOf(cplan.body), box), [cplan, box]); // eslint-disable-line react-hooks/exhaustive-deps
  // (kept the same object while it says the same, so the creature's memo holds
  // through the screen's ticks)
  const c = pet.care || {};
  const careProps = useMemo(() => (pet.care ? { food: c.food, eatStart: c.eatStart, eatMs: c.eatMs, bathStyle: c.bathStyle } : null), [!!pet.care, c.food, c.eatStart, c.eatMs, c.bathStyle]); // eslint-disable-line react-hooks/exhaustive-deps
  const creature = <CreatureThumbnail creature={pet.creature} mood={pet.mood} size={box} care={careProps} tint={cplan.tint} />;

  const body = (
    <Animated.View
      style={{
        width: box,
        height: box,
        opacity: pop.interpolate({ inputRange: [0, 0.5, 1], outputRange: [0, 1, 1] }),
        transform: [
          { perspective: 300 },
          { translateY: box * 0.4 },
          { scale: pop.interpolate({ inputRange: TP_IN.input, outputRange: TP_IN.scale }) },
          { rotateY: pop.interpolate({ inputRange: TP_IN.input, outputRange: TP_IN.spin }) },
          { translateY: -box * 0.4 },
        ],
      }}
    >
      {pet.selected ? <View pointerEvents="none" style={{ position: 'absolute', left: box * 0.02, right: box * 0.02, bottom: -5 * scale, height: box * 0.2, borderRadius: box, borderWidth: 3 * scale, borderColor: '#ffd66b', backgroundColor: 'rgba(255,214,107,0.25)' }} /> : null}
      <Reanimated.View style={[{ width: box, height: box }, motion]}>
        <Animated.View style={care.body}>{care.spin ? <Animated.View style={care.spin}>{creature}</Animated.View> : creature}</Animated.View>
      </Reanimated.View>
    </Animated.View>
  );

  return (
    <Animated.View style={{ position: 'absolute', left: 0, top: 0, width: box, height: box, zIndex: 100 + Math.round(pet.y), transform: pos.getTranslateTransform() }}>
      <TutTarget name={`cr:${pet.id}`} host={host} style={{ width: box, height: box }}>
        <Pressable onPress={onPress} style={{ width: box, height: box }} hitSlop={4}>
          {body}
        </Pressable>
      </TutTarget>
      {cplan.sprites.map((sp, i) => (
        <Sprite key={`${careKey}${i}`} s={sp} value={valueOf(sp.t)} k={box / 100} />
      ))}
      {pet.need ? <NeedBubble need={pet.need} box={box} scale={scale} onPress={onPress} phase={(index * 0.13) % 1} /> : null}
      <PlusLabel plus={pet.plus} box={box} scale={scale} />
    </Animated.View>
  );
}

// a creature on its way out: spins about its upright axis, shrinks up and
// fades (the design's tp-out)
function Ghost({ ghost, scale }) {
  const box = SIZE * scale;
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    Animated.timing(t, { toValue: 1, duration: TELEPORT_MS, easing: Easing.linear, useNativeDriver: true }).start();
  }, [t]);
  return (
    <Animated.View
      pointerEvents="none"
      style={{
        position: 'absolute',
        left: (ghost.x - SIZE / 2) * scale,
        top: (ghost.y - SIZE) * scale,
        width: box,
        height: box,
        zIndex: 100 + Math.round(ghost.y),
        opacity: t.interpolate({ inputRange: TP_OUT.input, outputRange: TP_OUT.opacity }),
        transform: [
          { perspective: 300 },
          { translateY: t.interpolate({ inputRange: [0, 1], outputRange: [0, -36 * scale] }) },
          { translateY: box * 0.4 },
          { scale: t.interpolate({ inputRange: TP_OUT.input, outputRange: TP_OUT.scale }) },
          { scaleY: t.interpolate({ inputRange: TP_OUT.input, outputRange: TP_OUT.stretch }) },
          { rotateY: t.interpolate({ inputRange: TP_OUT.input, outputRange: TP_OUT.spin }) },
          { translateY: -box * 0.4 },
        ],
      }}
    >
      <CreatureThumbnail creature={ghost.creature} mood="idle" size={box} animate={false} />
    </Animated.View>
  );
}

// ---- the hatchery's pods ------------------------------------------------------------

// every creature of the roster on the shelf: the ones living in the Crib
// awake in a gold ring with the room they're in, hatched ones moved out
// faded with AWAY, the rest still dreaming (locked art, '???'). Tapping a
// hatched one moves it in or out (the screen decides). On top, how many
// live in the Crib.
const Pods = memo(function Pods({ pods, members, head, scale, onPress }) {
  const box = 50 * scale;
  return (
    <>
      {head ? (
        <View pointerEvents="none" style={[styles.podHead, { top: 92 * scale }]}>
          <View style={styles.podHeadPill}>
            <Text style={[styles.podHeadText, { fontSize: Math.max(10, 11 * scale) }]}>{`${members}/${CRIB_MAX} LIVE IN THE CRIB · TAP TO MOVE IN OR OUT`}</Text>
          </View>
        </View>
      ) : null}
      {pods.map((p, i) => {
        const col = i % 10;
        const row = Math.floor(i / 10);
        const x = 26 + col * 82;
        const y = 126 + row * 88;
        const away = p.owned && !p.member;
        return (
          <Pressable key={p.creature.id} onPress={() => onPress(p)} style={{ position: 'absolute', left: x * scale, top: y * scale, width: 80 * scale, alignItems: 'center', opacity: away ? 0.6 : 1 }}>
            <View style={{ width: box * 1.3, height: box * 1.3, borderRadius: box, backgroundColor: p.member ? 'rgba(255,240,170,0.65)' : away ? 'rgba(255,255,255,0.45)' : 'rgba(255,214,244,0.35)', borderWidth: p.member ? 3 : 2, borderColor: p.member ? '#ffd66b' : away ? '#b8a08a' : 'rgba(255,255,255,0.7)', borderStyle: away ? 'dashed' : 'solid', alignItems: 'center', justifyContent: 'center' }}>
              <CreatureThumbnail creature={p.creature} size={box} locked={!p.owned} animate={false} />
            </View>
            <Text numberOfLines={1} style={[styles.podName, { fontSize: Math.max(9, 10 * scale), color: p.owned ? INK : '#8a6a50' }]}>
              {p.owned ? p.creature.name : '???'}
            </Text>
            {p.owned ? <Text style={[styles.podWhere, { fontSize: Math.max(8, 8 * scale), color: p.member ? '#4f9a3a' : '#8a6a50' }]}>{p.where}</Text> : null}
          </Pressable>
        );
      })}
    </>
  );
});

// ---- the scene ---------------------------------------------------------------------

function Scene({ room, phase, scale, pets, onPetPress, host, pods, members = 0, podHead = true, onPodPress, home, homeRev, edit, yardSpots, yardOcc, dancing, onToggleLight, onMoveDecor, onMovePad, onMoveUnit, toLocal }) {
  const w = SCENE_W * scale;
  const h = SCENE_H * scale;
  // what the furniture draws; `homeRev` stands for the home's contents
  const look = useMemo(() => visuals(home, room), [home, homeRev, room]); // eslint-disable-line react-hooks/exhaustive-deps
  const decor = useMemo(() => placedDecor(home, room), [home, homeRev, room]); // eslint-disable-line react-hooks/exhaustive-deps
  const lamps = useMemo(() => lampsOf(home, room), [home, homeRev, room]); // eslint-disable-line react-hooks/exhaustive-deps
  const sorted = useMemo(() => [...pets].sort((a, b) => a.y - b.y), [pets]);

  // The yard's and the dance room's motion runs on one UI-thread clock,
  // ticking only while one of them is on screen. The swing and the seesaw
  // ease in and out as creatures get on and off.
  const clock = useSharedValue(0);
  const swA = useSharedValue(0);
  const ssA = useSharedValue(0);
  // (a stable callback: useFrameCallback registers it again whenever it
  // changes, which would restart timeSinceFirstFrame — so the frame's own
  // timestamp, which keeps counting through a re-register)
  const onFrame = useCallback(
    (f) => {
      'worklet';
      clock.value = f.timestamp;
    },
    [clock]
  );
  const frames = useFrameCallback(onFrame, false);
  const moving = room === 'yard' || room === 'dance';
  useEffect(() => {
    frames.setActive(moving);
    return () => frames.setActive(false);
  }, [moving]); // eslint-disable-line react-hooks/exhaustive-deps
  const onGame = (g) => (yardSpots || []).some((p, k) => p.g === g && yardOcc && yardOcc[k] != null);
  const swingOn = room === 'yard' && onGame('swing');
  const seesawOn = room === 'yard' && onGame('seesaw');
  useEffect(() => {
    swA.value = withTiming(swingOn ? 1 : 0, { duration: 900 });
  }, [swingOn]); // eslint-disable-line react-hooks/exhaustive-deps
  useEffect(() => {
    ssA.value = withTiming(seesawOn ? 1 : 0, { duration: 900 });
  }, [seesawOn]); // eslint-disable-line react-hooks/exhaustive-deps
  const yard = useMemo(() => ({ clock, swA, ssA }), [clock, swA, ssA]);

  // creatures that just left this room play out where they stood
  const [ghosts, setGhosts] = useState([]);
  const prev = useRef(new Map());
  useEffect(() => {
    const now = new Map(pets.map((p) => [p.id, p]));
    const gone = [];
    prev.current.forEach((p, id) => {
      if (!now.has(id)) gone.push({ ...p, key: `${id}:${Date.now()}` });
    });
    prev.current = now;
    if (!gone.length) return undefined;
    setGhosts((g) => [...g, ...gone]);
    const timer = setTimeout(() => setGhosts((g) => g.filter((x) => !gone.includes(x))), TELEPORT_MS + 80);
    return () => clearTimeout(timer);
  }, [pets]);
  // a room change: nothing lingers from the last one
  useEffect(() => {
    prev.current = new Map();
    setGhosts([]);
  }, [room]);

  return (
    <View style={{ width: w, height: h, overflow: 'hidden', backgroundColor: '#f3dcb8' }}>
      <RoomBackdrop room={room} phase={phase} home={home} homeRev={homeRev} scale={scale} />
      {room === 'dance' ? (
        <>
          <DanceLights classicBall={look.flags.classicBall} lights={look.flags.lights} clock={clock} active={!!dancing} scale={scale} />
          <DanceFloor floor={look.flags.floor} clock={clock} active={!!dancing} scale={scale} />
        </>
      ) : null}
      {room === 'yard' ? <YardGames games={look.flags.games} spots={yardSpots || []} occ={yardOcc || []} yard={yard} scale={scale} /> : null}
      {look.back.map((art, i) => (
        <Piece key={`b${i}`} art={art} scale={scale} phase={phase} />
      ))}
      <DecorLayer decor={decor} home={home} homeRev={homeRev} room={room} scale={scale} edit={edit} phase={phase} onToggleLight={onToggleLight} onMoveDecor={onMoveDecor} onMovePad={onMovePad} onMoveUnit={onMoveUnit} toLocal={toLocal} />
      {pods ? <Pods pods={pods} members={members} head={podHead} scale={scale} onPress={onPodPress} /> : null}
      {edit ? null : sorted.map((p, i) => <Pet key={p.id} pet={p} index={i} scale={scale} host={host} yard={yard} onPress={() => onPetPress(p.id)} />)}
      {edit ? null : ghosts.map((g) => <Ghost key={g.key} ghost={g} scale={scale} />)}
      {/* above every creature (they're zIndex 100 + their feet): the
          front furniture, the kitchen's table, the night */}
      <View pointerEvents="none" style={[StyleSheet.absoluteFill, { zIndex: 1000 }]}>
        {look.front.map((art, i) => (
          <Piece key={`f${i}`} art={art} scale={scale} phase={phase} />
        ))}
        <RoomFront room={room} scale={scale} />
        <Night phase={phase} lights={lamps} dark={room !== 'hatch'} scale={scale} />
      </View>
    </View>
  );
}

export default memo(Scene);

const styles = StyleSheet.create({
  plus: { fontFamily: candyFonts.display, color: '#fff3a0', textShadowColor: '#a04a00', textShadowRadius: 2, textShadowOffset: { width: 0, height: 2 }, letterSpacing: 0.4, textAlign: 'center' },
  podName: { fontFamily: candyFonts.bodyHeavy, marginTop: 2 },
  podWhere: { fontFamily: candyFonts.bodyHeavy, color: '#8a6a50' },
  podHead: { position: 'absolute', left: 0, right: 0, alignItems: 'center' },
  podHeadPill: { paddingHorizontal: 12, paddingVertical: 3, borderRadius: 999, backgroundColor: 'rgba(91,58,41,0.78)', borderWidth: 2, borderColor: '#ffffff' },
  podHeadText: { fontFamily: candyFonts.bodyBlack, color: '#ffffff', letterSpacing: 0.4 },
});
