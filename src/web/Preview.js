// Web, development only: the games' popups on their own, to check their layout without playing a level
// (http://localhost:8081/?phone=1&preview=1 in a window the phone's size, e.g. 832 x 384 for the A15 sideways), and
// the screens a test account can't reach (verify), and the start-up screens signed out (splash, auth) for the Unity
// port's comparisons (tools/unity/auth-test).
// window.__preview('sd-result') shows one card; the names are the keys of CARDS below. Nothing here touches the account.
import React, { useEffect, useState } from 'react';
import { StyleSheet, Text, View } from 'react-native';
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
import SplashScreen from '../screens/SplashScreen';
import AuthScreen from '../screens/AuthScreen';
import VaultLoader from '../components/VaultLoader';
import SquishdokuScreen from '../screens/SquishdokuScreen';
import SortScreen from '../screens/SortScreen';
import StackScreen from '../screens/StackScreen';
import HopScreen from '../screens/HopScreen';
import { SafeAreaProvider } from 'react-native-safe-area-context';
import { Asset } from 'expo-asset';
import { BY_ID } from '../squad/data';
import STACK_ART from '../stack/art';

const noop = () => {};
const before = { level: 6, into: 560, need: 700 };
const after = { level: 7, into: 40, need: 800 };
const res = { stars: 2, perfect: false, ms: 83000, mistakes: 1, levelCoins: 90, coins: 90, xp: 40, levelUps: [7], before, after, unlocked: true };
const best = { ...res, stars: 3, perfect: true, mistakes: 0, levelCoins: 270, coins: 270 };
const blitz = { ms: 412000, coins: 600, xp: 120, newBest: true, levelUps: [], before, after: { level: 6, into: 680, need: 700 } };
const uris = [null, null, null];

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

// the games' whole screens (hub, map, levels) for a made-up player: no uid, so nothing is saved. Creatures' stills
// are the bundled Stack cut-outs (the real ones come from Storage).
const srcUri = (s) => (s == null ? null : typeof s === 'string' ? s : typeof s === 'number' ? Asset.fromModule(s).uri : s.uri || s.default || null);
const CREATURES = Object.values(BY_ID).map((d) => ({ id: d.id, thumb: { url: srcUri(STACK_ART[d.key] && STACK_ART[d.key].src) || 'about:blank' } }));
const PLAYER = {
  coins: 100,
  gems: 600,
  ownedIds: ['1'],
  sdk: { plays: 3, lv: 12 },
  sort: { seen: true, lv: 12 },
  stack: { seen: true, lv: 12 },
  hop: { seen: true, lv: 12 },
};
const game = (Screen) => () => (
  <SafeAreaProvider initialMetrics={{ frame: { x: 0, y: 0, width: 0, height: 0 }, insets: { top: 0, left: 0, right: 0, bottom: 0 } }}>
    <Screen profile={PLAYER} creatures={CREATURES} uid={null} adsFree haptics={false} onBack={noop} />
  </SafeAreaProvider>
);

const CARDS = {
  'sd-result': (v) => <SD.ResultCard visible={v} res={res} spec={{ lv: 12, n: 6 }} uris={uris} onNext={noop} onReplay={noop} onMap={noop} />,
  'sd-perfect': (v) => <SD.ResultCard visible={v} res={best} spec={{ lv: 12, n: 6, head: true }} uris={uris} onNext={noop} onReplay={noop} onMap={noop} />,
  'sd-timeup': (v) => <SD.TimeUpCard visible={v} onRetry={noop} onMap={noop} />,
  'sd-hearts': (v) => <SD.TimeUpCard visible={v} hearts={3} onRetry={noop} onMap={noop} />,
  'sd-pause': (v) => <SD.PauseCard visible={v} onResume={noop} onRestart={noop} onQuit={noop} />,
  'sd-revive': (v) => <SD.ReviveCard visible={v} board={4} adReady onRevive={noop} onGiveUp={noop} />,
  'sd-blitzfail': (v) => <SD.BlitzFailCard visible={v} reason="mistake" reached={4} best={6} onAgain={noop} onQuit={noop} />,
  'sd-blitzwin': (v) => <SD.BlitzWinCard visible={v} res={blitz} uris={uris} onAgain={noop} onQuit={noop} />,
  'sd-rules': (v) => <SdRules visible={v} roster={[]} onClose={noop} />,
  'sort-result': (v) => <SORT.ResultCard visible={v} res={{ ...res, mistakes: 0 }} spec={{ lv: 9, tier: 1, parMs: 40000 }} onNext={noop} onReplay={noop} onHub={noop} />,
  'sort-fail': (v) => <SORT.FailCard visible={v} reason="hearts" onRetry={noop} onHub={noop} />,
  'sort-pause': (v) => <SORT.PauseCard visible={v} onResume={noop} onRestart={noop} onQuit={noop} />,
  'sort-rules': (v) => <SORT.RulesCard visible={v} onClose={noop} />,
  'stack-result': (v) => <STACK.ResultCard visible={v} res={{ ...res, moves: 9, par: 7 }} spec={{ lv: 9, tier: 1 }} onNext={noop} onReplay={noop} onHub={noop} />,
  'stack-fail': (v) => <STACK.FailCard visible={v} onRetry={noop} onHub={noop} />,
  'stack-pause': (v) => <STACK.PauseCard visible={v} clock onResume={noop} onRestart={noop} onQuit={noop} />,
  'stack-hint': (v) => <STACK.HintCard visible={v} adReady onWatch={noop} onClose={noop} />,
  'stack-rules': (v) => <STACK.RulesCard visible={v} onClose={noop} />,
  'hop-result': (v) => <HOP.ResultCard visible={v} res={{ ...res, hops: 14, left: 2 }} spec={{ lv: 9, tier: 1, room: 'living' }} nextRoom="Kitchen" onNext={noop} onReplay={noop} onHub={noop} />,
  'hop-stuck': (v) => <HOP.StuckCard visible={v} shut onUndo={noop} onRetry={noop} />,
  'hop-pause': (v) => <HOP.PauseCard visible={v} onResume={noop} onRestart={noop} onQuit={noop} />,
  'hop-hint': (v) => <HOP.HintCard visible={v} adReady onWatch={noop} onClose={noop} />,
  'hop-rules': (v) => <HOP.RulesCard visible={v} onClose={noop} />,
  // a whole screen: a new account's email check (its buttons only call Firebase when tapped)
  vault: () => <VaultPreview />,
  'game-squishdoku': game(SquishdokuScreen),
  'game-sort': game(SortScreen),
  'game-stack': game(StackScreen),
  'game-hop': game(HopScreen),
  verify: () => <VerifyEmailScreen email="new.player@example.com" onVerified={noop} onLogout={noop} />,
  // the launch screen as on a brand-new install (no creature cache yet, so no Mittens) while the app starts: the bar
  // runs to 90 % and waits (?ready=1: the app is ready, so it fills and says READY!)
  splash: () => <SplashScreen onFinish={noop} ready={/[?&]ready=1/.test(window.location.search)} creatures={[]} />,
  // Log in / Register signed out (Firebase is only called when its buttons are tapped)
  auth: () => <AuthScreen />,
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
      {card ? <React.Fragment key={name}>{card(true)}</React.Fragment> : <Text>{`No card "${name}"`}</Text>}
    </View>
  );
}
