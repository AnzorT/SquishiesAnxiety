import React, { memo, useEffect, useRef, useState } from 'react';
import { Animated, BackHandler, Easing, Pressable, ScrollView, StyleSheet, Text, View, useWindowDimensions } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import OutlinedTitle from '../components/candy/OutlinedTitle';
import RoundButton, { CloseGlyph } from '../components/candy/RoundButton';
import { RaysSpin } from '../components/candy/Decor';
import { Twinkle } from '../components/candy/Sparkles';
import sfx from '../audio/sfx';
import { F } from '../squad/ui';
import Freeze from '../components/Freeze';
import { PATCHES } from '../squishdoku/theme';
import Tile from '../squishdoku/Tile';
import { LEVELS, puzzleLevel, record } from '../squishdoku/levels';
import { record as sortRecord } from '../sort/levels';
import { THEMES } from '../sort/themes';
import { MiniContainer } from '../sort/Container';
import { useDoorLoop } from '../sort/Hub';

// The games, slid up over the Lobby by PLAY: a card per game with its own
// little animated picture, flying in one after another. Tap one to play it.
// Built once (in the background, `warm`, or on the first PLAY) and kept,
// asleep while closed (Freeze), so PLAY is only the slide up: building it on
// the tap held the slide for 0.3-0.4 s (Galaxy A15 debug build, 2026-10-28).
//   onPick('squish')       the classic squish with the Lobby's creature
//   onPick('squishdoku')   the puzzle (SQUISHDOKU.md)
//   onPick('sort')         the memory game with the fridge (SQUISH_SORT.md)
// A last ghost card promises more.

const ART = 104;

// Squish: the Lobby's creature on a glow, squashed and springing back over
// and over, with squish lines and twinkles.
const SquishArt = memo(function SquishArt({ uri }) {
  const s = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    // press, spring back, rest (a zero-motion timing, not Animated.delay)
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(s, { toValue: 1, duration: 260, easing: Easing.out(Easing.quad), useNativeDriver: true }),
        Animated.timing(s, { toValue: 0, duration: 620, easing: Easing.elastic(2.2), useNativeDriver: true }),
        Animated.timing(s, { toValue: 0, duration: 700, useNativeDriver: true }),
      ]),
    );
    loop.start();
    return () => loop.stop();
  }, [s]);
  const scaleX = s.interpolate({ inputRange: [-0.3, 0, 1], outputRange: [0.92, 1, 1.22] });
  const scaleY = s.interpolate({ inputRange: [-0.3, 0, 1], outputRange: [1.1, 1, 0.74] });
  const translateY = s.interpolate({ inputRange: [-0.3, 0, 1], outputRange: [-4, 0, 11] });
  const lines = s.interpolate({ inputRange: [0, 0.6, 1], outputRange: [0, 0, 1] });
  return (
    <View style={styles.art}>
      <LinearGradient colors={['#ffe8f8', '#ffc6ec']} style={StyleSheet.absoluteFill} />
      <View style={styles.center}>
        <RaysSpin size={ART * 1.5} color="#ffffff" opacity={0.7} />
      </View>
      <View style={styles.floor} />
      <Animated.View style={[styles.lines, { opacity: lines, transform: [{ scaleX: lines.interpolate({ inputRange: [0, 1], outputRange: [0.6, 1] }) }] }]}>
        <View style={[styles.line, { transform: [{ rotate: '-20deg' }], left: 6 }]} />
        <View style={[styles.line, { transform: [{ rotate: '20deg' }], right: 6 }]} />
      </Animated.View>
      {uri ? <Animated.Image source={{ uri }} style={[styles.squishImg, { transform: [{ translateY }, { scaleX }, { scaleY }] }]} resizeMode="contain" fadeDuration={0} /> : null}
      <Twinkle size={13} color="#ffffff" duration={1.6} style={{ position: 'absolute', top: 8, right: 12 }} />
      <Twinkle size={10} color="#fff3a0" duration={2.2} delay={0.6} style={{ position: 'absolute', top: 26, left: 10 }} />
    </View>
  );
});

// Squishdoku: a tiny 4×4 board whose creatures drop into place one by one,
// hop when the board's full, and start over.
const MINI = [2, 0, 0, 1, 2, 0, 1, 1, 2, 3, 3, 1, 2, 3, 3, 3]; // patches
const MINI_SOL = [1, 7, 8, 14]; // the cells the creatures land in, in order
const MINI_COLORS = [PATCHES[0], PATCHES[3], PATCHES[6], PATCHES[8]];
const SudokuArt = memo(function SudokuArt({ uris }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const loop = Animated.loop(Animated.timing(t, { toValue: 1, duration: 3600, easing: Easing.linear, useNativeDriver: true }));
    loop.start();
    return () => loop.stop();
  }, [t]);
  const cs = (ART - 12) / 4;
  return (
    <View style={[styles.art, { backgroundColor: '#d9c6f5', padding: 6 }]}>
      {MINI.map((reg, cell) => (
        <View key={cell} style={{ position: 'absolute', left: 6 + (cell % 4) * cs, top: 6 + Math.floor(cell / 4) * cs, width: cs, height: cs }}>
          <Tile size={cs} patch={MINI_COLORS[reg]} />
        </View>
      ))}
      {MINI_SOL.map((cell, i) => {
        const a = 0.08 + i * 0.14;
        const drop = t.interpolate({ inputRange: [0, a, a + 0.06, 1], outputRange: [-cs, -cs, 0, 0] });
        const hop = t.interpolate({ inputRange: [0, 0.7 + i * 0.02, 0.74 + i * 0.02, 0.78 + i * 0.02, 1], outputRange: [0, 0, -cs * 0.35, 0, 0] });
        const opacity = t.interpolate({ inputRange: [0, a, a + 0.02, 0.88, 0.95, 1], outputRange: [0, 0, 1, 1, 0, 0] });
        const squash = t.interpolate({ inputRange: [0, a + 0.06, a + 0.08, a + 0.11, 1], outputRange: [1, 1, 0.75, 1, 1] });
        return (
          <Animated.Image
            key={cell}
            source={uris[i % Math.max(1, uris.length)] ? { uri: uris[i % uris.length] } : undefined}
            resizeMode="contain"
            fadeDuration={0}
            style={{
              position: 'absolute',
              left: 6 + (cell % 4) * cs + cs * 0.06,
              top: 6 + Math.floor(cell / 4) * cs + cs * 0.06,
              width: cs * 0.88,
              height: cs * 0.88,
              opacity,
              transform: [{ translateY: Animated.add(drop, hop) }, { scaleY: squash }],
            }}
          />
        );
      })}
    </View>
  );
});

// Squish Sort: a little fridge whose doors open on its squishies, shut,
// rattle and open again.
const SortArt = memo(function SortArt({ uris }) {
  const { door, rotate } = useDoorLoop();
  return (
    <View style={[styles.art, { backgroundColor: '#cdeefe', alignItems: 'center', justifyContent: 'center' }]}>
      <LinearGradient colors={['#e8f8ff', '#b3e2f7']} style={StyleSheet.absoluteFill} />
      <Animated.View style={{ transform: [{ rotate }, { scale: 0.92 }] }}>
        <MiniContainer t={THEMES.fridge} size={66} door={door} uris={uris} />
      </Animated.View>
    </View>
  );
});

// More games: three dashed spots with question marks, breathing.
const SoonArt = memo(function SoonArt() {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(t, { toValue: 1, duration: 900, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
        Animated.timing(t, { toValue: 0, duration: 900, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
      ]),
    );
    loop.start();
    return () => loop.stop();
  }, [t]);
  return (
    <View style={[styles.art, styles.soonArt]}>
      {[0, 1, 2].map((i) => (
        <Animated.View
          key={i}
          style={[
            styles.soonDot,
            {
              left: 8 + i * 30,
              top: i === 1 ? 22 : 40,
              opacity: t.interpolate({ inputRange: [0, 1], outputRange: i === 1 ? [1, 0.5] : [0.5, 1] }),
              transform: [{ scale: t.interpolate({ inputRange: [0, 1], outputRange: i === 1 ? [1.08, 0.92] : [0.92, 1.08] }) }],
            },
          ]}
        >
          <Text style={styles.soonQ}>?</Text>
        </Animated.View>
      ))}
    </View>
  );
});

// A game's card: flies in (from alternate sides, with a twist), squashes when
// pressed (on the touch), and plays its game on the release. (It used to wait
// a beat for the squash to be seen, then the Lobby another 0.2 s: the game
// came 0.4 s after the finger lifted.)
function GameCard({ index, trigger, colors, ring, title, lines, chips = [], art, onPress, ghost }) {
  const enter = useRef(new Animated.Value(0)).current;
  const press = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    // (not while the picker is built in the background, before any PLAY)
    if (!trigger) return undefined;
    enter.setValue(0);
    Animated.spring(enter, { toValue: 1, friction: 6.5, tension: 70, delay: 140 + index * 110, useNativeDriver: true }).start();
    const pop = setTimeout(() => sfx.play('sd_nodePop', { rate: 0.95 + index * 0.1 }), 200 + index * 110);
    return () => clearTimeout(pop);
  }, [trigger, enter, index]);
  const side = index % 2 ? 1 : -1;
  const style = {
    opacity: enter.interpolate({ inputRange: [0, 0.3, 1], outputRange: [0, 1, 1] }),
    transform: [
      { translateX: enter.interpolate({ inputRange: [0, 1], outputRange: [side * 120, 0] }) },
      { rotate: enter.interpolate({ inputRange: [0, 1], outputRange: [`${side * 8}deg`, '0deg'] }) },
      { scale: press.interpolate({ inputRange: [0, 1], outputRange: [1, 0.95] }) },
    ],
  };
  return (
    <Animated.View style={[styles.cardWrap, style]}>
      <Pressable
        disabled={ghost}
        onPressIn={() => Animated.timing(press, { toValue: 1, duration: 70, useNativeDriver: true }).start()}
        onPressOut={() => Animated.spring(press, { toValue: 0, friction: 3.5, tension: 240, useNativeDriver: true }).start()}
        onPress={() => {
          sfx.play('sd_select');
          onPress();
        }}
      >
        <View style={[styles.cardLip, { backgroundColor: ring }]} />
        <View style={[styles.cardRing, { backgroundColor: ring }]}>
          {/* the face is still, so it's one cached texture; its picture,
              which never stops moving, sits over it in the same spot.
              Inside the face, the picture's frames re-drew all four cards'
              gradients and text every frame (the open sheet at ~40 fps on
              the Galaxy A15, 2026-10-28) */}
          <LinearGradient colors={colors} locations={[0, 0.55, 1]} style={[styles.cardFace, ghost && styles.ghostFace]} renderToHardwareTextureAndroid>
            <View style={styles.cardShine} />
            <View style={styles.artSlot} />
            <View style={styles.cardText}>
              <Text style={[styles.cardTitle, { color: ring }]} numberOfLines={1}>
                {title}
              </Text>
              {lines.map((l) => (
                <Text key={l} style={styles.cardLine} numberOfLines={2}>
                  {l}
                </Text>
              ))}
              <View style={styles.chips}>
                {chips.map((c) => (
                  <View key={c} style={[styles.chip, { backgroundColor: ring }]}>
                    <Text style={styles.chipText}>{c}</Text>
                  </View>
                ))}
              </View>
            </View>
            {!ghost ? (
              <View style={[styles.go, { backgroundColor: ring }]}>
                <Text style={styles.goText}>▶</Text>
              </View>
            ) : null}
          </LinearGradient>
          <View style={styles.artOver} pointerEvents="none">
            {art}
          </View>
        </View>
      </Pressable>
    </Animated.View>
  );
}

// `warm`: build it now, unseen (the Lobby, a moment after it has settled).
// `onUp(true)` once it's all the way up, `onUp(false)` as it starts down.
function GamePicker({ visible, warm = false, profile, creatureName, creatureUri, puzzleUris, sortUris = [], onClose, onPick, onUp }) {
  const { height } = useWindowDimensions();
  const t = useRef(new Animated.Value(0)).current;
  // built (kept from then on); open: on screen, from PLAY until the slide
  // down is over; slept: built a frame ago, so it may sleep (a subtree
  // frozen from its first render is never built)
  const [built, setBuilt] = useState(visible);
  const [open, setOpen] = useState(visible);
  const [slept, setSlept] = useState(false);
  const [key, setKey] = useState(0);
  const closeRef = useRef(onClose);
  closeRef.current = onClose;
  const upRef = useRef(onUp);
  upRef.current = onUp;
  useEffect(() => {
    if (warm) setBuilt(true);
  }, [warm]);
  useEffect(() => {
    if (!built || slept) return undefined;
    const f = requestAnimationFrame(() => setSlept(true));
    return () => cancelAnimationFrame(f);
  }, [built, slept]);
  useEffect(() => {
    if (visible) {
      t.setValue(0);
      Animated.spring(t, { toValue: 1, friction: 8, tension: 60, useNativeDriver: true }).start(({ finished }) => finished && upRef.current?.(true));
      setBuilt(true);
      setOpen(true);
      setKey((k) => k + 1);
      sfx.play('whoosh');
      const sub = BackHandler.addEventListener('hardwareBackPress', () => {
        closeRef.current();
        return true;
      });
      return () => sub.remove();
    }
    upRef.current?.(false);
    if (open) Animated.timing(t, { toValue: 0, duration: 240, easing: Easing.in(Easing.quad), useNativeDriver: true }).start(({ finished }) => finished && setOpen(false));
    return undefined;
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [visible]);
  if (!built) return null;

  const rec = record(profile);
  const pl = puzzleLevel(rec.xp);
  const srt = sortRecord(profile);
  const pick = (game) => () => onPick(game);
  return (
    <Freeze freeze={slept && !open}>
      <View style={StyleSheet.absoluteFill} pointerEvents={visible ? 'auto' : 'none'}>
        <Animated.View style={[StyleSheet.absoluteFill, styles.scrim, { opacity: t.interpolate({ inputRange: [0, 1], outputRange: [0, 1], extrapolate: 'clamp' }) }]}>
          <Pressable style={StyleSheet.absoluteFill} onPress={onClose} />
        </Animated.View>
        <Animated.View style={[styles.sheet, { transform: [{ translateY: t.interpolate({ inputRange: [0, 1], outputRange: [height, 0] }) }] }]}>
          <LinearGradient colors={['#fff2fb', '#f6e8ff', '#e9dcff']} style={StyleSheet.absoluteFill} />
          <View style={styles.handle} />
          <View style={styles.header}>
            <OutlinedTitle text="PICK A GAME" size={28} fill="pink" />
            <RoundButton size={36} onPress={onClose} hitSlop={10}>
              <CloseGlyph />
            </RoundButton>
          </View>
          <ScrollView contentContainerStyle={styles.list} showsVerticalScrollIndicator={false}>
            <GameCard
              index={0}
              trigger={key}
              colors={['#fff0fa', '#ffc6ea', '#ff93d6']}
              ring="#8e1580"
              title="SQUISH"
              lines={[`Squish ${creatureName || 'your squishy'} and earn coins`]}
              chips={['ASMR', 'COINS']}
              art={<SquishArt uri={creatureUri} />}
              onPress={pick('squish')}
            />
            <GameCard
              index={1}
              trigger={key}
              colors={['#e0fbff', '#9feeff', '#5fd0f5']}
              ring="#0c5a9c"
              title="SQUISHDOKU"
              lines={['One creature per row, column and patch']}
              chips={[`LEVEL ${Math.min(rec.lv, LEVELS)}/${LEVELS}`, `PUZZLE LV ${pl.level}`, ...(rec.blitz.reached ? [`BLITZ ${rec.blitz.reached}/10`] : [])]}
              art={<SudokuArt uris={puzzleUris} />}
              onPress={pick('squishdoku')}
            />
            <GameCard
              index={2}
              trigger={key}
              colors={['#fff8ec', '#ffe2b8', '#ffc078']}
              ring="#a04a00"
              title="SQUISH SORT"
              lines={['Remember who sits where, then sort them back!']}
              chips={[`FRIDGE LV ${srt.fridge.lv}`, `CUPBOARD LV ${srt.cupboard.lv}`, 'NEW!']}
              art={<SortArt uris={sortUris} />}
              onPress={pick('sort')}
            />
            <GameCard index={3} trigger={key} ghost colors={['#f7f2fc', '#ece3f7', '#ded2ee']} ring="#9a86c0" title="MORE SOON" lines={['New mini-games are on the way!']} art={<SoonArt />} />
          </ScrollView>
        </Animated.View>
      </View>
    </Freeze>
  );
}

const styles = StyleSheet.create({
  scrim: { backgroundColor: 'rgba(40,8,80,0.45)' },
  sheet: { position: 'absolute', left: 0, right: 0, bottom: 0, top: 70, borderTopLeftRadius: 30, borderTopRightRadius: 30, borderWidth: 3, borderBottomWidth: 0, borderColor: '#ffffff', overflow: 'hidden' },
  handle: { alignSelf: 'center', width: 54, height: 6, borderRadius: 3, backgroundColor: 'rgba(69,24,154,0.25)', marginTop: 8 },
  header: { flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between', paddingHorizontal: 18, paddingTop: 6, paddingBottom: 4 },
  list: { paddingHorizontal: 14, paddingTop: 8, paddingBottom: 30, gap: 14 },
  cardWrap: {},
  cardLip: { position: 'absolute', left: 0, right: 0, top: 6, bottom: -6, borderRadius: 26 },
  cardRing: { borderRadius: 26, padding: 2.5 },
  cardFace: { borderRadius: 23.5, borderWidth: 3, borderColor: '#ffffff', flexDirection: 'row', alignItems: 'center', padding: 10, gap: 12, overflow: 'hidden' },
  ghostFace: { borderStyle: 'dashed' },
  cardShine: { position: 'absolute', left: 16, right: 16, top: 3, height: '30%', borderRadius: 20, backgroundColor: 'rgba(255,255,255,0.4)' },
  cardText: { flex: 1, gap: 3 },
  cardTitle: { fontFamily: F.display, fontSize: 22, letterSpacing: 1, includeFontPadding: false },
  cardLine: { fontFamily: F.heavy, fontSize: 12.5, color: '#45107a', lineHeight: 16 },
  chips: { flexDirection: 'row', flexWrap: 'wrap', gap: 4, marginTop: 2 },
  chip: { borderRadius: 999, paddingHorizontal: 7, paddingVertical: 2, borderWidth: 1.5, borderColor: '#ffffff' },
  chipText: { fontFamily: F.display, fontSize: 9.5, color: '#ffffff', letterSpacing: 0.4 },
  go: { width: 40, height: 40, borderRadius: 20, borderWidth: 3, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  goText: { fontFamily: F.display, fontSize: 16, color: '#ffffff', marginLeft: 3, includeFontPadding: false },
  art: { width: ART, height: ART, borderRadius: 18, overflow: 'hidden', borderWidth: 3, borderColor: '#ffffff' },
  // the picture's place in the face, and the picture over it: the ring's
  // padding, the face's border and its padding in from the left, centred
  artSlot: { width: ART, height: ART },
  artOver: { position: 'absolute', left: 2.5 + 3 + 10, top: 0, bottom: 0, justifyContent: 'center' },
  center: { ...StyleSheet.absoluteFillObject, alignItems: 'center', justifyContent: 'center' },
  floor: { position: 'absolute', bottom: 12, left: '22%', right: '22%', height: 10, borderRadius: 999, backgroundColor: 'rgba(142,21,128,0.22)' },
  lines: { ...StyleSheet.absoluteFillObject },
  line: { position: 'absolute', bottom: 22, width: 16, height: 4, borderRadius: 2, backgroundColor: '#ffffff' },
  squishImg: { position: 'absolute', left: ART * 0.12, top: ART * 0.1, width: ART * 0.7, height: ART * 0.74 },
  soonArt: { backgroundColor: '#efe8f8', borderStyle: 'dashed', borderColor: '#b9a6cc' },
  soonDot: { position: 'absolute', width: 34, height: 34, borderRadius: 17, borderWidth: 2.5, borderStyle: 'dashed', borderColor: '#9a86c0', backgroundColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  soonQ: { fontFamily: F.display, fontSize: 17, color: '#9a86c0', includeFontPadding: false },
});

export default memo(GamePicker);
