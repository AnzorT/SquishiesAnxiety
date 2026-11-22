// Web, development only: the games' popups on their own, to check their layout without playing a level
// (http://localhost:8081/?phone=1&preview=1 in a window the phone's size, e.g. 832 x 384 for the A15 sideways), and
// the screens a test account can't reach (verify).
// window.__preview('sd-result') shows one card; the names are the keys of CARDS below. Nothing here touches the account.
import React, { useEffect, useMemo, useState } from 'react';
import { Animated, ScrollView, StyleSheet, Text, View } from 'react-native';
import { SafeAreaProvider } from 'react-native-safe-area-context';
import { useFonts } from 'expo-font';
import { Baloo2_500Medium, Baloo2_700Bold, Baloo2_800ExtraBold } from '@expo-google-fonts/baloo-2';
import { Nunito_400Regular, Nunito_600SemiBold, Nunito_700Bold, Nunito_800ExtraBold, Nunito_900Black } from '@expo-google-fonts/nunito';
import { Fredoka_500Medium, Fredoka_600SemiBold, Fredoka_700Bold } from '@expo-google-fonts/fredoka';
import { GameBackground } from '../royal/GameFrame';
import * as SD from '../squishdoku/Overlays';
import SdRules from '../squishdoku/Rules';
import * as SORT from '../sort/Cards';
import * as STACK from '../stack/Cards';
import * as HOP from '../hop/Cards';
import VerifyEmailScreen from '../screens/VerifyEmailScreen';
import VaultLoader from '../components/VaultLoader';
import ChestSmash from '../components/ChestSmash';
import Freeze from '../components/Freeze';
import StackScreen from '../screens/StackScreen';
import HopScreen from '../screens/HopScreen';
import SquishdokuScreen from '../screens/SquishdokuScreen';
import SortScreen from '../screens/SortScreen';
import DailySpinScreen from '../screens/DailySpinScreen';
import ShopScreen from '../screens/ShopScreen';
import { WHEEL, todayKey } from '../dailySpin';
import { Asset } from 'expo-asset';
import { BY_ID, lineup } from '../squad/data';
import StackGame from '../stack/Game';
import SdRegular from '../squishdoku/RegularGame';
import SdBlitz from '../squishdoku/BlitzGame';
import HopGame from '../hop/Game';
import SortGame, { SortBlitz } from '../sort/Game';
import { poolOf } from '../sort/themes';
import Container, { geometry } from '../sort/Container';
import { modelOf } from '../sort/models';
import { MODEL_STARTS, levelSpec } from '../sort/levels';
import STACK_ART from '../stack/art';
import SD_BODIES from '../squishdoku/bodies';
import { rosterOf } from '../squishdoku/roster';

const noop = () => {};
// a number from the page's address (?lv=…), or `d`
const param = (k, d) => {
  const v = new URLSearchParams(window.location.search).get(k);
  return v == null || v === '' || Number.isNaN(Number(v)) ? d : Number(v);
};
const before = { level: 6, into: 560, need: 700 };
const after = { level: 7, into: 40, need: 800 };
const res = { stars: 2, perfect: false, ms: 83000, mistakes: 1, levelCoins: 90, coins: 90, xp: 40, levelUps: [7], before, after, unlocked: true };
const best = { ...res, stars: 3, perfect: true, mistakes: 0, levelCoins: 270, coins: 270 };
const blitz = { ms: 412000, coins: 600, xp: 120, newBest: true, levelUps: [], before, after: { level: 6, into: 680, need: 700 } };
const uris = [null, null, null];
// Squish Stack's and Squish Hop's players without the roster from Firestore: the bundled cut-outs (stack/art.js), the
// first three as the player's own (stack/roster.js castOf's shape)
const CAST = Object.entries(STACK_ART)
  .slice(0, 12)
  .map(([key, a], i) => ({ id: key, key, uri: null, source: a.src, ar: a.ar, box: [0, 0, 1, 1], mine: i < 3 }));
// the result card's three live characters (?keys=a,b,c, else the first three cut-outs; ?keys=none: the stills) and
// how many are earned (?stars=…)
const KEYS = ((q) => (q === 'none' ? null : q ? q.split(',') : CAST.slice(0, 3).map((c) => c.key)))(new URLSearchParams(window.location.search).get('keys'));
const withStars = (r) => ({ ...r, stars: param('stars', r.stars) });
// the roster as Firestore gives it ({ id, thumb: { url } }), from the creatures with a bundled cut-out: the four games'
// whole screens run on it (screen-sd, screen-sort, screen-stack, screen-hop), with some progress on the profile
const CREATURES = Object.entries(BY_ID)
  .filter(([, d]) => STACK_ART[d.key] && !d.pass)
  .map(([id, d]) => ({ id, thumb: { url: Asset.fromModule(STACK_ART[d.key].src).uri } }));
const PROFILE = {
  gems: 120,
  ownedIds: CREATURES.slice(0, 10).map((c) => c.id),
  sdk: { lv: 25, blitz: { top: 12 } },
  sort: { seen: true, fridge: { lv: 6 }, blitz: { top: 4 } },
  stack: { lv: 23, seen: true, blitz: { top: 14 } },
  hop: { lv: 37, seen: true, blitz: { top: 6 } },
};
// Squishdoku's board creatures: ones with their faces drawn (squishdoku/bodies.js; the game never deals the heroes,
// which have none), and its score creatures: the cut-outs' pictures
const SD_CAST = Object.entries(STACK_ART)
  .filter(([key]) => SD_BODIES[key])
  .slice(0, 12)
  .map(([key, a], i) => ({ id: key, key, uri: null, source: a.src, ar: a.ar, box: [0, 0, 1, 1], mine: i < 3 }));
// (through rosterOf, as the app: it also learns each one's rig key, for the result card's live characters)
const SD_ROSTER = rosterOf(CREATURES, PROFILE).slice(0, 12);
const screen = (Screen) => () => <Screen profile={PROFILE} creatures={CREATURES} uid={null} adsFree onBack={noop} />;
const over = { cleared: 7, best: 9, coins: 420, xp: 140, newTop: false, levelUps: [], before, after: { level: 6, into: 700 - 1, need: 700 } };

// the chest smash's loading screen on its own: the page "paints" after `ms` (?ms=…, 4500 by default), then it plays
// its way out and starts again (window.__vaultReady() makes it ready at once)
function VaultPreview() {
  const ms = Number(new URLSearchParams(window.location.search).get('ms')) || 4500;
  const [run, setRun] = useState(0);
  const [ready, setReady] = useState(false);
  useEffect(() => {
    setReady(false);
    window.__vaultReady = () => setReady(true);
    const t = setTimeout(() => setReady(true), ms);
    return () => clearTimeout(t);
  }, [run, ms]);
  return <VaultLoader key={run} ready={ready} uri={null} onDone={() => setTimeout(() => setRun((n) => n + 1), 900)} />;
}

// the real chest smash under the loading screen, as the Shop's chest buy runs it (ShopScreen openGroup): the smash comes
// up on the tapped chest (`first`), a made-up server answer lands after ?ans=… ms (900 by default), the page under it
// goes to sleep (Freeze, as the Shop's tabs) and the loader leaves once the smash's page says it has painted. Nothing
// is bought: the answer never leaves the page. window.__smashLog: when each step happened.
function SmashPreview() {
  const ans = param('ans', 900);
  // (&id=…: the creature it holds, Mittens by default; &copies=7&need=12: a copy toward unlocking it, +1 COPY and the
  //  bar on the reveal, the unlocking one when copies = need; &group=fruit…: another group's chest and vault room, the
  //  creature's own by default)
  const q = new URLSearchParams(window.location.search);
  const id = BY_ID[q.get('id')] ? q.get('id') : '1';
  const copies = param('copies', 0);
  const need = param('need', 0);
  const first = { group: q.get('group') || BY_ID[id].set, size: 'common' };
  const [chest, setChest] = useState(null);
  const [up, setUp] = useState(false);
  const [gone, setGone] = useState(false);
  useEffect(() => {
    const t0 = performance.now();
    window.__smashLog = [];
    window.__smashMark = (what) => window.__smashLog.push([what, Math.round(performance.now() - t0)]);
    const t = setTimeout(() => {
      window.__smashMark('answer');
      setChest({ key: 1, result: { group: first.group, size: 'common', final: 'common', id, isNew: !need || copies >= need, copies, need } });
    }, ans);
    return () => clearTimeout(t);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);
  return (
    <View style={StyleSheet.absoluteFill}>
      <Freeze freeze={!!chest && up}>
        <View style={StyleSheet.absoluteFill} />
      </Freeze>
      <ChestSmash chest={chest} first={first} catalog={{}} onCollect={noop} onShown={() => (window.__smashMark('shown'), setUp(true))} />
      {!gone && <VaultLoader ready={up} uri={null} onDone={() => (window.__smashMark('loader done'), setGone(true))} />}
    </View>
  );
}

// The Daily Spin with a made-up server: SPIN lands on slice ?i=… (3, the Mystery Box, by default) after ?ans=… ms
// (700), and the box's chest smashes as a Shop chest's, with nothing sent. Watch ad, spin again works too (ads are free
// here). Nothing touches the account.
function SpinPreview() {
  const i = param('i', 3);
  const ans = param('ans', 700);
  const onSpin = () =>
    new Promise((ok) =>
      setTimeout(() => {
        const w = WHEEL[i] || WHEEL[0];
        // (today's first HOT group's chest, as the server gives and the wheel shows; Mittens inside)
        const chest = w.kind === 'chest' ? { group: lineup(todayKey())[0], size: 'common', final: 'common', id: '1', isNew: true } : null;
        ok({ index: i, kind: w.kind, amount: w.amount, size: w.size, chest, jackpot: w.kind === 'gems' && w.amount >= 50 });
      }, ans)
    );
  return <DailySpinScreen onSpin={onSpin} onDone={noop} bonusLeft={1} adsFree name="Claude Test" creatures={[]} profile={null} />;
}

// Squish Sort's seven fridges side by side, each at its model's last level's shelves (&open=0: shut; &m=…: just that
// one; &w=…: the area each is laid out in)
function FridgeGallery() {
  const open = param('open', 1);
  const one = param('m', -1);
  const area = param('w', 330);
  const door = useMemo(() => new Animated.Value(open), [open]);
  const light = useMemo(() => new Animated.Value(1), []);
  const list = one >= 0 ? [one] : [0, 1, 2, 3, 4, 5, 6];
  return (
    <ScrollView horizontal style={{ flex: 1, backgroundColor: '#e8d2b4' }} contentContainerStyle={{ alignItems: 'flex-end', paddingHorizontal: 60, paddingVertical: 24, gap: 90 }}>
      {list.map((i) => {
        const m = modelOf('fridge', i);
        const spec = levelSpec((MODEL_STARTS[i + 1] || 51) - 1);
        const g = geometry({ w: area * (m.doors === 2 ? 1.25 : 1), h: area, rows: spec.rows, cols: spec.cols, model: m, trayH: 0 });
        return (
          <View key={i} style={{ width: g.bodyW, height: g.bodyH + g.feet }}>
            <Container m={m} g={g} door={door} light={light} inside={null} slots={false} />
          </View>
        );
      })}
    </ScrollView>
  );
}

// Squish Stack's forest map with a walker (tap REGULAR): the player owns and has picked ?sel=… (Mittens, 1), starts on
// level ?lv=… (6); window.__stackWin() beats the next level as a win would (back on the map, the walker walks on)
function StackForestPreview() {
  const [lv, setLv] = useState(param('lv', 6));
  const sel = String(param('sel', 1));
  useEffect(() => {
    window.__stackWin = (n = 1) => setLv((v) => Math.min(50, v + n));
  }, []);
  const best = useMemo(() => Object.fromEntries(Array.from({ length: lv - 1 }, (_, i) => [i + 1, 1 + (i % 3)])), [lv]);
  return <StackScreen profile={{ ownedIds: [sel], lobby: { sel }, stack: { lv, best, seen: true } }} creatures={[]} uid={null} onBack={noop} />;
}

const CARDS = {
  'sort-fridges': () => <FridgeGallery />,
  'sd-result': (v) => <SD.ResultCard visible={v} res={withStars(res)} titles={SD.SD_RESULT_TITLES} perfectTitle="PERFECT SQUISH!" uris={uris} keys={KEYS} coins={res.levelCoins} backLabel="MAP" onNext={noop} onReplay={noop} onBack={noop} />,
  'sd-perfect': (v) => <SD.ResultCard visible={v} res={best} titles={SD.SD_RESULT_TITLES} perfectTitle="PERFECT SQUISH!" uris={uris} keys={KEYS} coins={best.levelCoins} backLabel="MAP" onNext={noop} onReplay={noop} onBack={noop} />,
  'sd-timeup': (v) => <SD.TimeUpCard visible={v} onRetry={noop} onMap={noop} />,
  'sd-hearts': (v) => <SD.TimeUpCard visible={v} hearts={3} onRetry={noop} onMap={noop} />,
  'sd-pause': (v) => <SD.PauseCard visible={v} onResume={noop} onQuit={noop} />,
  'sd-revive': (v) => <SD.ReviveCard visible={v} board={4} adReady onRevive={noop} onGiveUp={noop} />,
  'sd-blitzfail': (v) => <SD.BlitzFailCard visible={v} reason="mistake" reached={4} best={6} onAgain={noop} onQuit={noop} />,
  'sd-blitzwin': (v) => <SD.BlitzWinCard visible={v} res={blitz} uris={uris} onAgain={noop} onQuit={noop} />,
  'sd-rules': (v) => <SdRules visible={v} roster={[]} onClose={noop} />,
  'sort-result': (v) => <SD.ResultCard visible={v} res={withStars(res)} titles={SORT.RESULT_TITLES} keys={KEYS} onNext={noop} onReplay={noop} onBack={noop} />,
  'sort-fail': (v) => <SORT.FailCard visible={v} reason="hearts" onRetry={noop} onHub={noop} />,
  'sort-rules': (v) => <SORT.RulesCard visible={v} onClose={noop} />,
  'stack-result': (v) => <SD.ResultCard visible={v} res={withStars(res)} titles={STACK.RESULT_TITLES} keys={KEYS} onNext={noop} onReplay={noop} onBack={noop} />,
  'stack-hint': (v) => <STACK.HintCard visible={v} adReady onWatch={noop} onClose={noop} />,
  'stack-rules': (v) => <STACK.RulesCard visible={v} onClose={noop} />,
  'hop-result': (v) => <SD.ResultCard visible={v} res={withStars({ ...res, stars: 3 })} titles={HOP.RESULT_TITLES} keys={KEYS} onNext={noop} onReplay={noop} onBack={noop} />,
  'hop-stuck': (v) => <HOP.StuckCard visible={v} who={CAST[0]} shut onRetry={noop} />,
  'hop-hint': (v) => <HOP.HintCard visible={v} adReady onWatch={noop} onClose={noop} />,
  'hop-rules': (v) => <HOP.RulesCard visible={v} onClose={noop} />,
  'screen-sd': screen(SquishdokuScreen),
  'screen-sort': screen(SortScreen),
  'screen-stack': screen(StackScreen),
  'screen-hop': screen(HopScreen),
  'sd-save': (v) => <SD.BlitzSaveCard visible={v} reason="mistake" board={5} cleared={4} adReady gems={35} price={10} onAd={noop} onGems={noop} onEnd={noop} />,
  'sd-over': (v) => <SD.BlitzOverCard visible={v} res={over} onAgain={noop} onQuit={noop} />,
  // BLITZ MODE's save and GAME OVER cards, as Squish Stack and Squish Hop say them
  'stack-save': (v) => <SD.BlitzSaveCard visible={v} unit="puzzle" reason="mistake" board={6} cleared={5} adReady gems={35} price={20} onAd={noop} onGems={noop} onEnd={noop} />,
  'stack-over': (v) => <SD.BlitzOverCard visible={v} unit="puzzle" res={over} onAgain={noop} onQuit={noop} />,
  'hop-save': (v) => <SD.BlitzSaveCard visible={v} reason="mistake" why="That hop left cushions you can't clear." board={4} cleared={3} adUsed gems={5} price={10} onAd={noop} onGems={noop} onEnd={noop} />,
  'hop-over': (v) => <SD.BlitzOverCard visible={v} res={{ ...over, newTop: true, best: 7 }} onAgain={noop} onQuit={noop} />,
  // the hubs (2026-11-16), and the games themselves with the bundled cast (no account: nothing is saved, the ads are
  // free; don't tap a gem save, it calls the server)
  // (the screens with no roster: the hub and the map work, a level waits for the squishies)
  'stack-forest': () => <StackForestPreview />,
  'stack-hub': () => <StackScreen profile={{ stack: { lv: 23, seen: true, blitz: { top: 14 } } }} creatures={[]} uid={null} onBack={noop} />,
  'hop-hub': () => <HopScreen profile={{ hop: { lv: 37, seen: true, blitz: { top: 6 } } }} creatures={[]} uid={null} onBack={noop} />,
  // (&top=… sets the best run, 3 by default: 0 makes the first board cleared a NEW BEST)
  'stack-blitz': () => <StackGame blitz cast={CAST} profile={{ gems: 50, stack: { blitz: { top: param('top', 3) } } }} uid={null} adsFree onExit={noop} />,
  'hop-blitz': () => <HopGame blitz cast={CAST} profile={{ gems: 50, hop: { blitz: { top: param('top', 3) } } }} uid={null} adsFree onExit={noop} />,
  'stack-level': () => <StackGame startLv={param('lv', 5)} cast={CAST} profile={{ stack: { lv: 50, seen: true } }} uid={null} adsFree onExit={noop} />,
  'hop-level': () => <HopGame startLv={param('lv', 8)} cast={CAST} profile={{}} uid={null} adsFree onExit={noop} />,
  // Squish Sort's level and Blitz with the bundled cast (window.__sort plays it)
  'sort-level': () => <SortGame startLv={param('lv', 8)} pool={poolOf('fridge', CREATURES)} profile={{}} uid={null} adsFree onExit={noop} />,
  'sort-blitz': () => <SortBlitz pool={poolOf('fridge', CREATURES)} profile={{ gems: 50, sort: { blitz: { top: param('top', 3) } } }} uid={null} adsFree onExit={noop} />,
  // Squishdoku's level (&lv=…, &head=1 for HEAD START) and Blitz (&top=…) with the bundled cast, its creatures in
  // their three faces (squishdoku/bodies.js); window.__sdk plays them (answer(), miss(), tap(cell), timeUp(), save())
  'sd-level': () => <SdRegular startLv={param('lv', 12)} cast={SD_CAST} roster={SD_ROSTER} profile={PROFILE} head={param('head', 0) > 0} uid={null} onExit={noop} />,
  'sd-blitz': () => <SdBlitz cast={SD_CAST} roster={SD_ROSTER} profile={{ ...PROFILE, sdk: { blitz: { top: param('top', 3) } } }} uid={null} adsFree onExit={noop} />,
  // a whole screen: a new account's email check (its buttons only call Firebase when tapped)
  vault: () => <VaultPreview />,
  smash: () => <SmashPreview />,
  spin: () => <SpinPreview />,
  // the Shop sideways with a made-up wallet, to see its tabs slide (&tab=chests…: the one it opens on). Only switch
  // tabs: its buttons call the server
  shop: () => (
    <ShopScreen startTab={new URLSearchParams(window.location.search).get('tab') || 'daily'} creatures={CREATURES} profile={{ ...PROFILE, coins: 4200 }} priceOf={() => null} onBuyProduct={noop} onSeenOffer={noop} onBack={noop} />
  ),
  verify: () => <VerifyEmailScreen email="new.player@example.com" onVerified={noop} onLogout={noop} />,
};

export default function Preview() {
  const [fonts] = useFonts({
    Baloo2_500Medium,
    Baloo2_700Bold,
    Baloo2_800ExtraBold,
    Nunito_400Regular,
    Nunito_600SemiBold,
    Nunito_700Bold,
    Nunito_800ExtraBold,
    Nunito_900Black,
    Fredoka_500Medium,
    Fredoka_600SemiBold,
    Fredoka_700Bold,
  });
  const [name, setName] = useState(new URLSearchParams(window.location.search).get('card') || 'sd-result');
  useEffect(() => {
    window.__preview = setName;
    window.__previewNames = Object.keys(CARDS);
  }, []);
  if (!fonts) return null;
  const card = CARDS[name];
  return (
    <View style={StyleSheet.absoluteFill}>
      <GameBackground style={StyleSheet.absoluteFill} />
      {card ? <SafeAreaProvider key={name}>{card(true)}</SafeAreaProvider> : <Text>{`No card "${name}"`}</Text>}
    </View>
  );
}
