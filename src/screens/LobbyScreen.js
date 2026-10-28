import React, { memo, useCallback, useContext, useEffect, useMemo, useRef, useState } from 'react';
import { Animated, BackHandler, Easing, Image, StyleSheet, Text, View, useWindowDimensions } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Defs, Ellipse, Path, RadialGradient, Rect, Stop, Circle } from 'react-native-svg';
import Pressable from '../components/Pressable';
import CandyBackground from '../components/candy/CandyBackground';
import RoundButton, { GearIcon, HouseIcon, TrophyIcon } from '../components/candy/RoundButton';
import OutlinedTitle from '../components/candy/OutlinedTitle';
import ShadowText from '../components/candy/ShadowText';
import RigCreature from '../components/RigCreature';
import { preloadCreatureModel } from '../components/SquishyToy';
import { LoopsOn, RigAway } from '../components/idleLoop';
import Freeze from '../components/Freeze';
import SquadScreen from './SquadScreen';
import GamePicker from './GamePicker';
import TutTarget from '../tutorial/Target';
import { BY_ID, GROUPS, GROUP_INK, wallet } from '../squad/data';
import { newIds, selectedId } from '../squad/lobby';
import { ownedKey, rosterOf } from '../squishdoku/roster';
import { poolOf } from '../sort/themes';
import { COIN, GEM } from '../squad/currencyArt';
import { F, Ringed } from '../squad/ui';
import { fmtNum } from '../format';

// The home screen (the 2026-10-19 design's "Squad Lobby v2"): the SQUAD
// header with the Crib (Home), trophies and settings, the coin and gem
// purses, the selected squishy live and big (the design's own rig, in a
// WebView: tap to poke, drag to spin), and the SQUAD button (with how many
// squishies are NEW) beside PLAY, the same size, its name inside (user,
// 2026-10-24). PLAY slides up the games to pick from
// (GamePicker: Squish, Squishdoku, Squish Sort); during the tutorial it goes straight to
// Squish, the step it points at.
//
// The creature starts at full resolution and drops to 80 % (RigCreature's
// renderScale) when it runs under 58 fps for 2 s while idle: the step-0
// spike's fix for the heaviest art on the Galaxy A15. It's paused whenever
// the lobby isn't on screen (`active` off), and while the Squad screen
// (src/screens/SquadScreen.js) is up: it slides up over the lobby, under the
// nav, as in the design. It and the games sheet are built in the background
// once the lobby has settled (useSettled), then kept (asleep while closed),
// so they open at once.

const STAGE = 330; // the design's creature area; the creature is 310 of it
const NAME_SHADOWS = [[0, 3.5], [2.5, 0], [-2.5, 0], [0, -2.5], [2, 2], [-2, 2]].map(([x, y]) => [x, y, '#45107a']);
const PLAY_SHADOWS = [[0, 2.5], [2, 0], [-2, 0], [0, -1.5]].map(([x, y]) => [x, y, '#17652f']);
const SQUAD_SHADOWS = [[0, 2.5], [2, 0], [-2, 0], [0, -1.5]].map(([x, y]) => [x, y, '#45189a']);
const GROUP_NAME = Object.fromEntries(GROUPS.map((g) => [g.key, g.name]));
const SLOW_FPS = 58;
const SLOW_SECONDS = 2;

// The coin / gem counters: the design's creature-stamped coin and
// creature-shaped gem (tools/shop-art/currency.mjs) on a white pill.
function Purse({ gem, amount, onPress }) {
  return (
    <Pressable onPress={onPress}>
      <Ringed ring={gem ? '#45189a' : '#8e1580'} lip={3} ringW={2} border={2.5} innerStyle={styles.purse}>
        <Image source={gem ? GEM[0] : COIN[0]} style={gem ? styles.gemImg : styles.coinImg} fadeDuration={0} />
        <Text style={[styles.purseText, { color: gem ? '#5a22c8' : '#b86200' }]}>{fmtNum(amount)}</Text>
      </Ringed>
    </Pressable>
  );
}

// The glossy highlight across the top of a candy button.
const Shine = ({ inset = '10%', height = '40%', from = 0.8 }) => (
  <LinearGradient pointerEvents="none" colors={[`rgba(255,255,255,${from})`, 'rgba(255,255,255,0.06)']} style={[styles.shine, { left: inset, right: inset, height }]} />
);

function SquadGlyph() {
  const cells = [
    [3, 3],
    [13, 3],
    [3, 13],
    [13, 13],
  ];
  return (
    <Svg width={28} height={28} viewBox="0 0 24 24">
      {cells.map(([x, y]) => (
        <Rect key={`s${x}${y}`} x={x} y={y + 1.5} width={8} height={8} rx={2.5} fill="#45189a" />
      ))}
      {cells.map(([x, y]) => (
        <Rect key={`${x}${y}`} x={x} y={y} width={8} height={8} rx={2.5} fill="#ffffff" />
      ))}
    </Svg>
  );
}

// The SQUAD button: a violet candy twin of PLAY, NEW count on its corner.
function SquadTile({ count, onPress }) {
  return (
    <View style={styles.squadSlot}>
      <Pressable onPress={onPress} style={({ pressed }) => pressed && { transform: [{ translateY: 5 }] }}>
        <Ringed ring="#45189a" lip={7} ringW={2.5} border={3} radius={26} bg="#b65cff" innerStyle={styles.squadFace}>
          <Svg style={StyleSheet.absoluteFill} width="100%" height="100%">
            <Defs>
              <RadialGradient id="squadFace" cx="35%" cy="25%" r="85%">
                <Stop offset="0" stopColor="#f3d2ff" />
                <Stop offset="0.45" stopColor="#b65cff" />
                <Stop offset="1" stopColor="#6a22d6" />
              </RadialGradient>
            </Defs>
            <Rect x="0" y="0" width="100%" height="100%" fill="url(#squadFace)" />
          </Svg>
          <Shine inset="6%" from={0.75} />
          <SquadGlyph />
          <ShadowText style={styles.squadText} shadows={SQUAD_SHADOWS}>
            SQUAD
          </ShadowText>
        </Ringed>
        {count > 0 && (
          <View style={styles.badge} pointerEvents="none">
            <LinearGradient colors={['#ff8f8f', '#e01e4a']} style={styles.badgeFace}>
              <Text style={styles.badgeText}>{count}</Text>
            </LinearGradient>
          </View>
        )}
      </Pressable>
    </View>
  );
}

function PlayButton({ onPress }) {
  return (
    <TutTarget name="play" style={styles.playSlot}>
      <Pressable onPress={onPress} style={({ pressed }) => pressed && { transform: [{ translateY: 5 }] }}>
        <Ringed ring="#17652f" lip={7} ringW={2.5} border={3} radius={26} colors={['#d8ffc2', '#6fe07a', '#26a94e']} innerStyle={styles.playFace}>
          <Shine inset="6%" from={0.75} />
          <Svg width={26} height={26} viewBox="0 0 24 24">
            <Path d="M7 6.5 L19 14 L7 21.5 Z" fill="#17652f" stroke="#17652f" strokeWidth={2.4} strokeLinejoin="round" />
            <Path d="M7 4.5 L19 12 L7 19.5 Z" fill="#ffffff" stroke="#ffffff" strokeWidth={2.4} strokeLinejoin="round" />
          </Svg>
          <ShadowText style={styles.playText} shadows={PLAY_SHADOWS}>
            PLAY
          </ShadowText>
        </Ringed>
      </Pressable>
    </TutTarget>
  );
}

// The white glow behind the creature and its shadow on the floor.
const StageBack = memo(function StageBack({ size }) {
  const k = size / STAGE;
  const glow = 320 * k;
  return (
    <>
      <Svg pointerEvents="none" width={glow} height={glow} style={[styles.abs, { left: '50%', top: '50%', marginLeft: -glow / 2, marginTop: -glow / 2 }]}>
        <Defs>
          <RadialGradient id="lobbyGlow" cx="50%" cy="50%" r="50%">
            <Stop offset="0" stopColor="#ffffff" stopOpacity={0.95} />
            <Stop offset="0.45" stopColor="#ffffff" stopOpacity={0.5} />
            <Stop offset="0.72" stopColor="#ffffff" stopOpacity={0} />
          </RadialGradient>
        </Defs>
        <Circle cx={glow / 2} cy={glow / 2} r={glow / 2} fill="url(#lobbyGlow)" />
      </Svg>
      <Svg pointerEvents="none" width={200 * k} height={28 * k} style={[styles.abs, { left: '50%', bottom: 22 * k, marginLeft: -100 * k }]}>
        <Defs>
          <RadialGradient id="lobbyFloor" cx="50%" cy="50%" r="50%">
            <Stop offset="0" stopColor="#45107a" stopOpacity={0.28} />
            <Stop offset="0.7" stopColor="#45107a" stopOpacity={0} />
          </RadialGradient>
        </Defs>
        <Ellipse cx={100 * k} cy={14 * k} rx={100 * k} ry={14 * k} fill="url(#lobbyFloor)" />
      </Svg>
    </>
  );
});

// true once the lobby has been on screen for `ms` (and from then on): what it
// opens (the games sheet, the Squad screen) is built then, in the background,
// so opening it is only its slide. Built on the tap, it held the slide for
// 0.3-0.4 s (the games) and 3.6 s (the Squad's 80 tiles and live creature)
// in a debug build on the Galaxy A15 (2026-10-28).
function useSettled(active, ms) {
  const [settled, setSettled] = useState(false);
  useEffect(() => {
    if (settled || !active) return undefined;
    const t = setTimeout(() => setSettled(true), ms);
    return () => clearTimeout(t);
  }, [settled, active, ms]);
  return settled;
}

function LobbyScreen({ active = true, profile, creatures, hidden, setRewards, cribUnlocked = false, pickGames = true, onOpenCrib, onOpenAchievements, onOpenSettings, onOpenShop, onPlay, onOpenPuzzle, onOpenSort, onSelect, onSeen }) {
  const insets = useSafeAreaInsets();
  // off while the lobby is out of sight (a screen over it, the Shop's page
  // beside it): its live creature is taken out then. A WebView, even paused
  // and off screen, cost the phone ~3.5 ms of every frame of whatever was on
  // screen (Galaxy A15, 2026-10-28)
  const onScreen = useContext(LoopsOn);
  // under another screen: the creature's WebView let go (RigAway), its still
  // shown in its place until a fresh one has drawn
  const rigAway = useContext(RigAway);
  const [rigDrawn, setRigDrawn] = useState(false);
  useEffect(() => {
    if (rigAway) setRigDrawn(false);
  }, [rigAway]);
  const onRigDrawn = useCallback(() => setRigDrawn(true), []);
  const w = wallet(profile);
  const id = selectedId(profile);
  const c = BY_ID[id];
  const fresh = newIds(profile).length;

  // The creature area shrinks on short screens so the name, the hint and
  // the buttons always fit.
  const [stage, setStage] = useState(STAGE);
  const onMiddle = useCallback((e) => {
    const h = e.nativeEvent.layout.height;
    if (h > 0) setStage(Math.max(180, Math.min(STAGE, Math.floor(h - 82))));
  }, []);

  // 80 % resolution once the creature has run slow for SLOW_SECONDS while
  // idle; a new creature starts again at full.
  const [scale, setScale] = useState(1);
  const slow = useRef(0);
  const rigState = useRef('idle');
  const activeRef = useRef(active);
  activeRef.current = active;
  useEffect(() => {
    setScale(1);
    slow.current = 0;
  }, [id]);
  const onState = useCallback((s) => {
    rigState.current = s;
  }, []);
  const onPerf = useCallback((p) => {
    if (!activeRef.current || rigState.current !== 'idle') {
      slow.current = 0;
      return;
    }
    slow.current = p.fps < SLOW_FPS ? slow.current + 1 : 0;
    if (slow.current >= SLOW_SECONDS) setScale(0.8);
  }, []);

  // the Squad screen: slides up (the design's slUp, 0.42 s) and back down.
  // Built in the background (`warmSquad`) and asleep while closed (Freeze);
  // the lobby under it is hidden while it's up (`covered`), so the phone
  // doesn't draw both screens for every frame of its live creature. Both
  // really hidden (display: none): kept laid out instead (off screen, or at
  // opacity 0) the phone still worked through them every frame, and the
  // lobby and the Squad dropped to ~10 fps (Galaxy A15 release, 2026-10-28).
  const { height: winH } = useWindowDimensions();
  const warmGames = useSettled(active, 2500);
  const warmSquad = useSettled(active, 4500);
  const [squadBuilt, setSquadBuilt] = useState(false);
  const [squadOpen, setSquadOpen] = useState(false);
  const [squadUp, setSquadUp] = useState(false); // on screen, or sliding
  // asleep only once all of it has been built (its tiles come a few a frame,
  // and a frozen subtree isn't built) and it's closed
  const [squadDone, setSquadDone] = useState(false);
  const onSquadBuilt = useCallback(() => setSquadDone(true), []);
  const [covered, setCovered] = useState(false);
  useEffect(() => {
    if (warmSquad) setSquadBuilt(true);
  }, [warmSquad]);
  const up = useRef(new Animated.Value(0)).current;
  const openSquad = useCallback(() => {
    // the slide first: it starts once this render is committed
    Animated.timing(up, { toValue: 1, duration: 420, easing: Easing.bezier(0.22, 1, 0.36, 1), useNativeDriver: true }).start(({ finished }) => finished && setCovered(true));
    setSquadBuilt(true);
    setSquadUp(true);
    setSquadOpen(true);
  }, [up]);
  const closeSquad = useCallback(() => {
    Animated.timing(up, { toValue: 0, duration: 320, easing: Easing.bezier(0.22, 1, 0.36, 1), useNativeDriver: true }).start(({ finished }) => finished && setSquadUp(false));
    setCovered(false);
    setSquadOpen(false);
  }, [up]);
  useEffect(() => {
    if (!squadOpen || !active) return undefined;
    const sub = BackHandler.addEventListener('hardwareBackPress', () => {
      closeSquad();
      return true;
    });
    return () => sub.remove();
  }, [squadOpen, active, closeSquad]);

  const toGems = useCallback(() => onOpenShop('gems'), [onOpenShop]);
  const play = useCallback(() => onPlay(id), [onPlay, id]);

  // the games sheet; `pickerUp` while it's all the way up: the creature and
  // the buttons it covers are hidden then (display: none), so the phone
  // doesn't draw them under it every frame of its cards' animations (the
  // open sheet ran at ~40 fps on the Galaxy A15, 2026-10-28)
  const [picking, setPicking] = useState(false);
  const [pickerUp, setPickerUp] = useState(false);
  const openGames = useCallback(() => setPicking(true), []);
  const closeGames = useCallback(() => setPicking(false), []);
  const pickGame = useCallback(
    (game) => {
      setPicking(false);
      // at once: the game's screen slides in over the sheet going down (it
      // used to wait 0.2 s for a calm lobby first)
      if (game === 'squishdoku') onOpenPuzzle && onOpenPuzzle();
      else if (game === 'sort') onOpenSort && onOpenSort();
      else play();
    },
    [onOpenPuzzle, onOpenSort, play],
  );
  const owned = ownedKey(profile);
  const puzzleUris = useMemo(() => rosterOf(creatures, profile).slice(0, 8), [creatures, owned]); // eslint-disable-line react-hooks/exhaustive-deps
  const sortUris = useMemo(() => poolOf('fridge', creatures, hidden).slice(0, 3).map((c) => c.uri), [creatures, hidden]);
  const creatureEntry = useMemo(() => (creatures || []).find((x) => String(x.id) === String(id)) || null, [creatures, id]);
  const creatureUri = creatureEntry && creatureEntry.thumb ? creatureEntry.thumb.url : null;
  // the squish game's model of the creature, loaded while the lobby is up
  // (after the sheets' background builds), so PLAY → Squish skips most of
  // the loading screen
  const warmModel = useSettled(active, 6500);
  useEffect(() => {
    if (warmModel && creatureEntry) preloadCreatureModel(creatureEntry).catch(() => {});
  }, [warmModel, creatureEntry]);
  const creature = stage - 20;

  return (
    <View style={styles.root}>
      <CandyBackground style={[{ paddingTop: insets.top }, covered && styles.gone]}>
        <View style={styles.top}>
          <View style={styles.titleRow}>
            <OutlinedTitle text="SQUAD" fill="pink" size={25} outline={3} ring={2} drop={5} />
            <View style={styles.icons}>
              {cribUnlocked ? (
                <TutTarget name="crib">
                  <RoundButton size={42} variant="green" onPress={onOpenCrib}>
                    <HouseIcon />
                  </RoundButton>
                </TutTarget>
              ) : null}
              <RoundButton size={42} onPress={onOpenAchievements}>
                <TrophyIcon size={24} />
              </RoundButton>
              <RoundButton size={42} onPress={onOpenSettings}>
                <GearIcon size={24} />
              </RoundButton>
            </View>
          </View>
          <View style={styles.purses}>
            <Purse amount={w.coins} onPress={toGems} />
            <Purse gem amount={w.gems} onPress={toGems} />
          </View>
        </View>

        <View style={[styles.middle, pickerUp && styles.gone]} onLayout={onMiddle}>
          <ShadowText style={styles.name} shadows={NAME_SHADOWS} numberOfLines={1}>
            {c ? c.name : ''}
          </ShadowText>
          <Text style={[styles.group, { color: (c && GROUP_INK[c.set]) || '#45107a' }]}>{c ? GROUP_NAME[c.set] : ''}</Text>
          <View style={[styles.stage, { height: stage }, !onScreen && styles.gone]}>
            <StageBack size={stage} />
            {c && !rigDrawn && creatureUri ? (
              <View style={styles.stillWrap} pointerEvents="none">
                <Image source={{ uri: creatureUri }} style={{ width: creature, height: creature }} resizeMode="contain" fadeDuration={0} />
              </View>
            ) : null}
            {c && !rigAway ? (
              <RigCreature creatureKey={c.key} renderScale={scale} paused={!active || squadOpen || picking} rigShadow={false} onState={onState} onPerf={onPerf} onMounted={onRigDrawn} style={{ width: creature, height: creature }} />
            ) : null}
          </View>
          <Text style={styles.hint}>Tap to poke · drag to spin</Text>
        </View>

        <View style={[styles.bottom, pickerUp && styles.gone]}>
          <SquadTile count={fresh} onPress={openSquad} />
          <PlayButton onPress={pickGames ? openGames : play} />
        </View>

        <View style={StyleSheet.absoluteFill} pointerEvents="box-none">
          <GamePicker
            visible={picking && active}
            warm={warmGames}
            profile={profile}
            creatureName={c ? c.name : ''}
            creatureUri={creatureUri}
            puzzleUris={puzzleUris}
            sortUris={sortUris}
            onClose={closeGames}
            onPick={pickGame}
            onUp={setPickerUp}
          />
        </View>
      </CandyBackground>
      {squadBuilt && (
        <Animated.View
          pointerEvents={squadOpen ? 'auto' : 'none'}
          style={[StyleSheet.absoluteFill, { transform: [{ translateY: up.interpolate({ inputRange: [0, 1], outputRange: [winH, 0] }) }] }]}
        >
          <Freeze freeze={squadDone && !squadUp}>
            <SquadScreen active={active && squadOpen} profile={profile} creatures={creatures} hidden={hidden} setRewards={setRewards} onClose={closeSquad} onSelect={onSelect} onSeen={onSeen} onBuilt={onSquadBuilt} />
          </Freeze>
        </Animated.View>
      )}
    </View>
  );
}

const styles = StyleSheet.create({
  root: { flex: 1 },
  // the lobby while the Squad screen covers it
  gone: { display: 'none' },
  // the creature's still, in the live creature's box, until it has drawn
  stillWrap: { ...StyleSheet.absoluteFillObject, alignItems: 'center', justifyContent: 'center' },
  abs: { position: 'absolute' },
  top: { gap: 9, paddingHorizontal: 14, paddingTop: 10, paddingBottom: 10 },
  titleRow: { flexDirection: 'row', alignItems: 'center', gap: 8 },
  icons: { flexDirection: 'row', alignItems: 'center', gap: 8, marginLeft: 'auto' },
  purses: { flexDirection: 'row', alignItems: 'center', gap: 6 },
  purse: { flexDirection: 'row', alignItems: 'center', gap: 5, paddingLeft: 7, paddingRight: 9, paddingVertical: 4 },
  coinImg: { width: 22, height: 22, marginVertical: -5, marginLeft: -4 },
  gemImg: { width: 24, height: 24, marginVertical: -6, marginLeft: -5 },
  purseText: { fontFamily: F.black, fontSize: 13.5, includeFontPadding: false },
  middle: { flex: 1, minHeight: 0, alignItems: 'center', justifyContent: 'center', paddingHorizontal: 16 },
  name: { fontFamily: F.display, fontSize: 36, lineHeight: 40, color: '#ffffff', textAlign: 'center', includeFontPadding: false },
  group: { marginTop: 4, fontFamily: F.display, fontSize: 16, includeFontPadding: false },
  stage: { width: '100%', alignItems: 'center', justifyContent: 'center' },
  hint: { fontFamily: F.heavy, fontSize: 11.5, color: '#6a4a9a' },
  bottom: { flexDirection: 'row', alignItems: 'flex-end', justifyContent: 'center', gap: 12, paddingTop: 14, paddingHorizontal: 16, paddingBottom: 22 },
  // SQUAD and PLAY: two equal 76 px candy buttons
  squadSlot: { flexBasis: 190, flexShrink: 1, minWidth: 0, marginBottom: 12 },
  squadFace: { height: 76, flexDirection: 'row', alignItems: 'center', justifyContent: 'center', gap: 9 },
  squadText: { fontFamily: F.display, fontSize: 28, lineHeight: 34, letterSpacing: 1.2, color: '#ffffff', includeFontPadding: false },
  shine: { position: 'absolute', top: 3, borderRadius: 999 },
  badge: { position: 'absolute', right: -4, top: -8, borderRadius: 999, backgroundColor: '#8e1030', paddingBottom: 2 },
  badgeFace: { minWidth: 24, height: 24, paddingHorizontal: 6, borderRadius: 999, borderWidth: 2.5, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  badgeText: { fontFamily: F.display, fontSize: 13, color: '#ffffff', includeFontPadding: false },
  playSlot: { flexBasis: 190, flexShrink: 1, minWidth: 0, marginBottom: 12 },
  playFace: { height: 76, flexDirection: 'row', alignItems: 'center', justifyContent: 'center', gap: 10 },
  playText: { fontFamily: F.display, fontSize: 32, lineHeight: 36, letterSpacing: 1.5, color: '#ffffff', includeFontPadding: false },
});

export default memo(LobbyScreen);
