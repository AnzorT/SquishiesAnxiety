// Web, development only: the games' popups on their own, to check their layout without playing a level
// (http://localhost:8081/?phone=1&preview=1 in a window the phone's size, e.g. 832 x 384 for the A15 sideways), and
// the screens a test account can't reach (verify), and the start-up screens signed out (splash, auth) for the Unity
// port's comparisons (tools/unity/auth-test), and the menu's screens for a made-up player ("scr-…": SCREENS below,
// tools/unity/screens-test).
// window.__preview('sd-result') shows one card; the names are the keys of CARDS below. Nothing here touches the account.
import React, { useEffect, useMemo, useState } from 'react';
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
import AchievementsScreen from '../screens/AchievementsScreen';
import StreakScreen from '../screens/StreakScreen';
import DailyChallengesSheet from '../screens/DailyChallengesSheet';
import SettingsRoyal from '../screens/royal/SettingsRoyal';
import StatsScreen from '../screens/StatsScreen';
import DailySpinScreen from '../screens/DailySpinScreen';
import { PageBg } from '../royal';
import { todayKey } from '../dailySpin';
import { challengesFor } from '../progression';
import ShopScreen from '../screens/ShopScreen';
import LevelRoadScreen from '../screens/LevelRoadScreen';
import { DEFAULT_OFFERS, lineup, BY_ID as SQUAD_BY_ID } from '../squad/data';
import { setOfferProducts } from '../economy';
import { priceLabel } from '../billing/common';
import auth from '@react-native-firebase/auth';

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

// The Unity port's other screens (tools/unity/screens-test, tools/unity/export-screens.mjs): Achievements, the streak,
// the daily challenges sheet, Settings, Stats and the Daily Spin, for a made-up player whose days are counted from
// today (the page's own clock), so the streak is alive and today's challenges are half done. Creatures' pictures are
// the bundled Stack cut-outs (the real plush art comes from Storage), with no rig (no mood faces). Nothing is saved:
// the handlers do nothing, the spin's "server" answers after 800 ms (window.__spinAnswer sets what it answers).
const fitFrame = (ar) => (ar >= 1 ? [(1 - 1 / ar) / 2, 0, 1 / ar, 1] : [0, (1 - ar) / 2, 1, ar]);
const NAMED = Object.values(BY_ID).map((d) => {
  const a = STACK_ART[d.key];
  const url = srcUri(a && a.src);
  const art = url ? { url, frame: fitFrame(a.ar) } : null;
  return { id: d.id, name: d.name, key: d.key, thumb: { url: url || 'about:blank' }, plush: art ? { md: art, mdLocked: art, lg: art, lgLocked: art, sm: art } : undefined };
});
const dayKey = (back) => {
  const d = new Date();
  d.setDate(d.getDate() - back);
  return todayKey(d);
};
// today's challenges: the first `claimed` claimed, `full` more done but not claimed, the rest part-way
function dailyOf(claimed, full, chest = false) {
  const date = todayKey();
  const prog = {}, cl = {};
  challengesFor(date).forEach((c, i) => {
    prog[c.ev] = i < claimed + full ? c.goal : Math.floor(c.goal / 2);
    if (i < claimed) cl[c.id] = true;
  });
  return { date, prog, claimed: cl, chest };
}
function screenPlayer(kind) {
  if (kind === 'new') return { nickname: 'Mia', coins: 100, gems: 30, ownedIds: ['0', '1'], pxp: 0 };
  const p = {
    nickname: 'Mia',
    coins: 2450,
    gems: 85,
    ownedIds: ['0', '1', '3', '4', '5', '6', '7', '12', '22', '24'],
    totalEarned: 12500,
    stats: { presses: 342, longestHoldMs: 12400, playTime: { 1: 754000, 12: 302000, 3: 95000, 22: 41000 } },
    adsWatched: 2,
    chestOpens: 6,
    tierPulls: { Epic: 1 },
    spins: 4,
    pxp: 1600,
    bestStreak: 4,
    streak: 3,
    lastFull: dayKey(1),
    chests: 5,
    maxMult: 2,
    cribCare: 12,
    daily: dailyOf(2, 1),
  };
  if (kind === 'done') return { ...p, streak: 4, lastFull: dayKey(0), daily: dailyOf(6, 0, true) };
  if (kind === 'ready') return { ...p, daily: dailyOf(6, 0) };
  if (kind === 'zero') return { ...p, streak: 0, lastFull: dayKey(5), daily: dailyOf(0, 1) };
  if (kind === 'long') return { ...p, streak: 8, bestStreak: 8, daily: dailyOf(4, 2) };
  return p;
}
const screen = (render) => () => (
  <SafeAreaProvider initialMetrics={{ frame: { x: 0, y: 0, width: 0, height: 0 }, insets: { top: 0, left: 0, right: 0, bottom: 0 } }}>{render()}</SafeAreaProvider>
);
function SpinPreview() {
  const onSpin = () =>
    new Promise((resolve) => setTimeout(() => resolve(window.__spinAnswer || { index: 6, kind: 'coins', amount: 500, jackpot: false }), 800));
  return <DailySpinScreen onSpin={onSpin} onDone={noop} bonusLeft={1} adsFree name="Mia" creatures={NAMED} />;
}
const sheet = (kind) => screen(() => (
  <View style={StyleSheet.absoluteFill}>
    <PageBg />
    <DailyChallengesSheet visible profile={screenPlayer(kind)} onClose={noop} onClaim={noop} onClaimChest={noop} onOpenCrib={noop} />
  </View>
));
const settings = (tester) => screen(() => (
  <SettingsRoyal onBack={noop} nickname="Mia" onSaveNickname={noop} onSubmitFeedback={() => Promise.resolve()} onLogout={noop} onReplayTutorial={noop} onOpenStats={noop} onOpenAchievements={noop} onOpenRoad={noop} tester={tester} wallet={{ coins: 2450, gems: 85, level: 4 }} fpsOn={false} onToggleFps={noop} />
));
const SCREENS = {
  'scr-achievements': screen(() => <AchievementsScreen creatures={NAMED} profile={screenPlayer('mid')} customCount={0} onBack={noop} />),
  'scr-achievements-new': screen(() => <AchievementsScreen creatures={NAMED} profile={screenPlayer('new')} customCount={0} onBack={noop} />),
  'scr-streak': screen(() => <StreakScreen profile={screenPlayer('mid')} mascot={NAMED[1]} onClose={noop} onOpenDaily={noop} />),
  'scr-streak-intro': screen(() => <StreakScreen profile={screenPlayer('mid')} mascot={NAMED[1]} intro onClose={noop} onOpenDaily={noop} />),
  'scr-streak-done': screen(() => <StreakScreen profile={screenPlayer('done')} mascot={NAMED[1]} intro onClose={noop} onOpenDaily={noop} />),
  'scr-streak-zero': screen(() => <StreakScreen profile={screenPlayer('zero')} mascot={NAMED[1]} onClose={noop} onOpenDaily={noop} />),
  'scr-streak-long': screen(() => <StreakScreen profile={screenPlayer('long')} mascot={NAMED[1]} onClose={noop} onOpenDaily={noop} />),
  'scr-daily': sheet('mid'),
  'scr-daily-ready': sheet('ready'),
  'scr-daily-done': sheet('done'),
  'scr-settings': settings(false),
  'scr-settings-tester': settings(true),
  'scr-stats': screen(() => <StatsScreen creatures={NAMED} customCreatures={[]} profile={screenPlayer('mid')} onBack={noop} />),
  'scr-stats-new': screen(() => <StatsScreen creatures={NAMED} customCreatures={[]} profile={screenPlayer('new')} onBack={noop} />),
  'scr-spin': screen(() => <SpinPreview />),
};

// The Unity port's Shop, chests and level road (tools/unity/shop-test, tools/unity/export-shop.mjs): the royal Shop on
// each tab and the landscape Level Road for made-up players, with the app's default offers (config/offers missing)
// and the prices' fallback labels (config/pricing missing). Nothing reaches Firebase: while one of these is up, a
// made-up "server" answers the `squad` moves (callFunction's fetch, signed in as nobody) after 600 ms with a fixed
// roll (window.__squadAnswer(move, args) can say otherwise); the profile doesn't change.
setOfferProducts(DEFAULT_OFFERS);
const shopDay = (back) => dayKey(back);
function shopPlayer(kind) {
  const base = {
    nickname: 'Mia',
    coins: 5200,
    gems: 640,
    ownedIds: ['0', '1', '3', '4', '5', '6', '7', '12', '22', '24'],
    copies: { 2: 3, 8: 1, 9: 6, 10: 2, 13: 4 },
    chestOpens: 6,
    epic: 6,
    freeAt: 0,
    totalEarned: 20000,
    jarBase: 0,
    gemFirst: { gems_80: true },
    shopStreak: { count: 2, last: shopDay(1) },
    passXp: 300,
    pxp: 1600,
    levelGot: { 1: true, 2: true },
    lobby: { sel: '1' },
  };
  if (kind === 'poor')
    return { ...base, coins: 120, gems: 40, freeAt: Date.now() + 2 * 3600e3 + 754000, adChests: { day: shopDay(0), n: 3 }, dealDay: shopDay(0), shopStreak: { count: 3, last: shopDay(0) }, epic: 9, adsFree: true, gemFirst: {} };
  if (kind === 'road-new') return { ...base, pxp: 120, levelGot: {} };
  return base;
}
function fakeSquad(move, args) {
  const day = shopDay(0);
  const hot = lineup(day);
  const pick = (group, size) => {
    const c = Object.values(SQUAD_BY_ID).find((x) => x.set === group && !x.reward && !x.pass) || SQUAD_BY_ID['1'];
    return { group, size, final: size, upgraded: false, id: c.id, rar: c.rar, isNew: false, copies: 3, need: 5, coins: 0, dupeCoins: 0, setBonus: 0, luck: false };
  };
  if (move === 'groupChest') return pick(args.group, args.size);
  if (move === 'freeChest') return pick(hot[0], 'common');
  if (move === 'adChest') return pick(hot[1], 'rare');
  if (move === 'dealChest') return pick(hot[0], 'legendary');
  if (move === 'rainbowChest') return pick(args.group, 'set');
  if (move === 'streakClaim') return { kind: 'coins', n: 500, day: 3 };
  if (move === 'passClaim') return { kind: 'gems', n: 80, i: args.i };
  if (move === 'swap') return { coins: [2000, 9000, 25000][args.i] || 0 };
  if (move === 'levelClaim') return { kind: 'coins', n: 500, lv: args.i };
  if (move === 'levelClaimAll') return { results: [] };
  return { error: 'unknown_move' };
}
function useFakeServer() {
  useEffect(() => {
    const a = auth();
    const had = Object.getOwnPropertyDescriptor(a, 'currentUser');
    Object.defineProperty(a, 'currentUser', { configurable: true, get: () => ({ uid: 'preview', getIdToken: async () => 'preview' }) });
    const realFetch = window.fetch;
    window.fetch = (url, init) => {
      const m = /cloudfunctions\.net\/(\w+)$/.exec(String(url));
      if (!m) return realFetch(url, init);
      const { data } = JSON.parse((init && init.body) || '{}');
      const { move, ...args } = data || {};
      const answer = (window.__squadAnswer && window.__squadAnswer(move, args)) || fakeSquad(move, args);
      (window.__squadCalls = window.__squadCalls || []).push({ move, args });
      return new Promise((resolve) =>
        setTimeout(() => resolve({ ok: true, status: 200, json: async () => (answer.error ? { error: { message: answer.error } } : { result: answer }) }), 600),
      );
    };
    return () => {
      window.fetch = realFetch;
      if (had) Object.defineProperty(a, 'currentUser', had);
      else delete a.currentUser;
    };
  }, []);
}
function ShopPreview({ kind, tab }) {
  useFakeServer();
  const profile = useMemo(() => shopPlayer(kind), [kind]);
  return <ShopScreen royal profile={profile} creatures={NAMED} offers={null} onSeenOffer={noop} onBuyProduct={() => Promise.resolve(null)} priceOf={(k) => priceLabel(k)} onBack={noop} startTab={tab} />;
}
function RoadPreview({ kind }) {
  useFakeServer();
  const profile = useMemo(() => shopPlayer(kind), [kind]);
  return <LevelRoadScreen profile={profile} creatures={NAMED} onBack={noop} />;
}
const SHOP = {
  'shop-daily': screen(() => <ShopPreview kind="shop" tab="daily" />),
  'shop-chests': screen(() => <ShopPreview kind="shop" tab="chests" />),
  'shop-deals': screen(() => <ShopPreview kind="shop" tab="deals" />),
  'shop-gems': screen(() => <ShopPreview kind="shop" tab="gems" />),
  'shop-daily-poor': screen(() => <ShopPreview kind="poor" tab="daily" />),
  'shop-chests-poor': screen(() => <ShopPreview kind="poor" tab="chests" />),
  'shop-deals-poor': screen(() => <ShopPreview kind="poor" tab="deals" />),
  'shop-gems-poor': screen(() => <ShopPreview kind="poor" tab="gems" />),
  road: screen(() => <RoadPreview kind="shop" />),
  'road-new': screen(() => <RoadPreview kind="road-new" />),
};

const CARDS = {
  ...SCREENS,
  ...SHOP,
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
    window.__screenPlayer = screenPlayer;
    window.__shopPlayer = shopPlayer;
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
