// Must load before anything that touches GLTFLoader (see SquishyToy.js's
// Glorp build path) — Hermes doesn't provide TextDecoder/TextEncoder,
// which GLTFLoader needs to decode a GLB's embedded JSON chunk. Has to be
// the first import in the app's entry file so its global.TextDecoder/
// TextEncoder polyfill is in place before any other module (transitively
// including SquishyToy.js) gets evaluated.
import 'fast-text-encoding';
import React, { useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { View, Alert, Dimensions, Image, AppState, BackHandler, Linking, StyleSheet } from 'react-native';
import { StatusBar } from 'expo-status-bar';
import { SafeAreaProvider } from 'react-native-safe-area-context';
import mobileAds from 'react-native-google-mobile-ads';
import { useFonts } from 'expo-font';
import { Baloo2_500Medium, Baloo2_700Bold, Baloo2_800ExtraBold } from '@expo-google-fonts/baloo-2';
import { Nunito_400Regular, Nunito_600SemiBold, Nunito_700Bold, Nunito_800ExtraBold, Nunito_900Black } from '@expo-google-fonts/nunito';
import { Fredoka_500Medium, Fredoka_600SemiBold, Fredoka_700Bold } from '@expo-google-fonts/fredoka';
import * as ScreenOrientation from 'expo-screen-orientation';
import AuthScreen from './src/screens/AuthScreen';
import VerifyEmailScreen from './src/screens/VerifyEmailScreen';
import AchievementsScreen from './src/screens/AchievementsScreen';
import StatsScreen from './src/screens/StatsScreen';
import ShopScreen from './src/screens/ShopScreen';
import SquishdokuScreen from './src/screens/SquishdokuScreen';
import SortScreen from './src/screens/SortScreen';
import StackScreen from './src/screens/StackScreen';
import HopScreen from './src/screens/HopScreen';
import DailySpinScreen from './src/screens/DailySpinScreen';
import LoadingScreen from './src/screens/LoadingScreen';
import SquishScreen from './src/screens/SquishScreen';
import DailyChallengesSheet from './src/screens/DailyChallengesSheet';
import StreakScreen from './src/screens/StreakScreen';
import LevelRoadScreen from './src/screens/LevelRoadScreen';
import SettingsRoyal from './src/screens/royal/SettingsRoyal';
import GameScreen from './src/game/GameScreen';
import RoyalGallery from './src/royal/Gallery';
import { LevelUpCard } from './src/components/LevelBits';
import AchievementToast from './src/components/squad/AchievementToast';
import Toast from './src/components/squad/Toast';
import FpsCounter from './src/components/FpsCounter';
import ScreenLayer, { WhenScreenReady } from './src/components/ScreenLayer';
import ScreenBones from './src/components/ScreenBones';
import { setFpsActive, setFpsWanted, useFpsWanted } from './src/components/fpsMeter';
import { plushArtUrls } from './src/components/CreatureThumbnail';
import { roadClaimable, roadPrize, roadView, setLevelsConfig, xpView } from './src/playerXp';
import { streakMultiplier, streakOf, dailyUnlocked as dailyIsUnlocked, level as levelOf } from './src/progression';
import { computeAchievements } from './src/achievements';
import { subscribeToAuthUser, logout, needsVerification } from './src/firebase/auth';
import { listenForSocial } from './src/firebase/social';
import { BY_ID, hiddenOf, isOut, lineup, owns, rainbowOf, setCopyCounts, setRainbowMode, setRewardsOf, stageOf, wallet as walletOf } from './src/squad/data';
import { setLookConfig, withLooks } from './src/squad/looks';
import { selectedId as selectedIdOf } from './src/squad/lobby';
import { setWeatherConfig } from './src/weather';
import {
  subscribeToUserProfile,
  subscribeToCreatures,
  subscribeToPricing,
  subscribeToOffers,
  subscribeToRoster,
  subscribeToLevels,
  subscribeToWeather,
  setOfferSeen,
  addCoins,
  recordPress,
  markAchievement,
  recordAdWatched,
  updateNickname,
  submitFeedback,
  ensureStarterCreaturesOwned,
  subscribeToCustomCreatures,
  migrateToXp,
  markLevelSeen,
  markStreakSeen,
  bumpDaily,
  claimDailyChallenge,
  claimDailyChest,
  setLobbySelected,
} from './src/firebase/firestore';
import { gamePlayer, idOfKey } from './src/game/player';
import { loadCachedCreatures, saveCreaturesToCache } from './src/data/creatureCache';
import * as billing from './src/billing';
import { setOfferProducts, setPricing } from './src/economy';
import { adSpinsLeft, hasSpunToday, todayKey, tzOffsetMinutes } from './src/dailySpin';
import callFunction from './src/firebase/callFunction';
import { dailyGift as squadDailyGift, levelClaim as squadLevelClaim, levelClaimAll as squadLevelClaimAll, move as squadMove, startSquad } from './src/squad/api';
import { fmtNum } from './src/format';
import sfx from './src/audio/sfx';
import { SKIP_EMAIL_VERIFY, WEBVIEW_DEBUG } from './src/webDebug';

// GLTFParser's constructor (three.js, used by SquishyToy.js's Glorp build
// path) sniffs navigator.userAgent to work around known Safari ImageBitmap
// bugs (`userAgent.match(/Version\/(\d+)/)`). React Native's global
// `navigator` exists but has no `userAgent` string, so that call throws
// "Cannot read property 'match' of undefined" before parsing even gets to
// the mesh/texture data. A harmless placeholder string is enough — the
// Safari-specific branch it guards is a no-op on a value that isn't
// actually Safari's UA anyway.
if (typeof navigator !== 'undefined' && typeof navigator.userAgent === 'undefined') {
  navigator.userAgent = 'ReactNative';
}

mobileAds()
  .initialize()
  .catch(() => {});
sfx.init();

// 2026-11-20: React Native's "window" size on Android leaves out the navigation bar's strip even though the app hides
// the bar and draws over it (MainActivity hideNavigationBar): on the test phone it said 748 dp wide while the app's
// root is 796. Every screen laid out from it (Settings, Stats, Shop, Achievements…) stopped ~48 dp short of the right
// edge, off centre. The window is set to the root view's real size, measured below, and set again whenever Android
// reports its own (smaller) size.
let rootSize = null;
function fitWindowToRoot() {
  if (!rootSize) return;
  const w = Dimensions.get('window');
  if (Math.abs(w.width - rootSize.width) < 0.5 && Math.abs(w.height - rootSize.height) < 0.5) return;
  Dimensions.set({ window: { ...w, width: rootSize.width, height: rootSize.height }, screen: Dimensions.get('screen') });
}
Dimensions.addEventListener('change', fitWindowToRoot);
const measureRoot = (e) => {
  const { width, height } = e.nativeEvent.layout;
  if (!(width > 0 && height > 0)) return;
  rootSize = { width, height };
  fitWindowToRoot();
};

const APP_TOAST_AT = { position: 'absolute', left: 0, right: 0, bottom: 150, height: 0, zIndex: 70, elevation: 70 };

// one empty object, so a memoized screen sees the same prop every render
const NO_ACHIEVEMENTS = {};
// creature pictures fetched into the image cache at a time (see below)
const PREFETCH_AT_ONCE = 6;

// The app is one landscape game (REDESIGN_V7/V8): the new design's Main Menu (src/game/GameScreen.js, webgame/) is
// Home, and every other screen opens over it. 2026-11-20 (the user: "get rid of everything related to the old UI"):
// the classic Home (Lobby, the Shop tab, Squad), the old Crib, the old settings sheet, Create-a-squishy and the guided
// tutorial (which kept new players on those) are gone; a new player goes straight to the menu.
//
// Music: the splash is silent, and so is the game intro until Mittens is squished the third time (2026-11-17, the
// user; `musicHeld` below; a launch that signs in first is silent on the sign-in screens too, up to that squish). From
// then on, Velvet Map Study (src/audio/sfx.js) is the one track on every screen but the house, which plays its own.
// the launch colour (android's native launch screen, REDESIGN_V8): what shows until the launch is ready, and behind
// everything (it used to be the old design's light sky blue, which flashed between screens)
const LAUNCH_BG = '#2a1608';
const musicFor = (stage) => (stage === 'splash' || stage === 'crib' ? null : 'theme');

// The creature cheering on the streak screen: the owned one squished the
// longest, else the first owned, else the starter.
function streakMascot(creatures, profile) {
  const owned = creatures.filter((c) => (profile?.ownedIds || []).includes(c.id));
  const time = profile?.stats?.playTime || {};
  const best = owned.reduce((a, c) => ((time[c.id] || 0) > (a ? time[a.id] || 0 : -1) ? c : a), null);
  return best || owned[0] || creatures[0] || null;
}

// the screens Android back closes (back to the menu) when they don't handle it themselves
const BACK_TO_MENU = new Set(['shop', 'achievements', 'stats', 'streak', 'road', 'settings']);

export default function App() {
  const [fontsLoaded] = useFonts({
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

  // The game intro (2026-11-16, the user: the designer's "Squish wakes the house", webgame/app/intro.js) replaced the old
  // splash screen. At launch the app waits on the launch colour until sign-in is known and, signed in, the profile and
  // the catalog are here (`splashDone`; 10 s at most, offline), then the menu plays the intro the first time it shows
  // in this launch (`introPending`): the daily spin, the streak screen and the level-up card wait for its end.
  const [splashDone, setSplashDone] = useState(false);
  const [introPending, setIntroPending] = useState(true);
  // the intro's third squish of Mittens has lit the house: the music may start (onIntro 'awake')
  const [introAwake, setIntroAwake] = useState(false);
  const introStartedRef = useRef(false);
  const [authChecked, setAuthChecked] = useState(false);
  const [authUser, setAuthUser] = useState(null);
  const [profile, setProfile] = useState(null);
  // the Firestore catalog as it came; `creatures` (below) is it with the chosen looks' pictures (src/squad/looks.js)
  const [catalog, setCreatures] = useState([]);
  // creatures made with the retired Create-a-squishy: they still count in the achievements and the stats
  const [customCreatures, setCustomCreatures] = useState([]);
  // the screen over the menu: 'home' (the menu itself) | 'crib' (the menu's house) | 'shop' | 'settings' | …
  const [screen, setScreen] = useState('home');
  // the Shop's own tab to open on (`shopKey` sends the Shop there)
  const [shopTab, setShopTab] = useState('chests');
  const [shopKey, setShopKey] = useState(0);
  // A card tap moves a creature into `loadingToy` (LoadingScreen's "getting
  // ready" beat) before it graduates to `activeToy` (SquishScreen actually
  // mounted) — kept as two separate slots so the transition screen has
  // somewhere to read the pending creature from.
  const [loadingToy, setLoadingToy] = useState(null);
  const [activeToy, setActiveToy] = useState(null);
  const [achToast, setAchToast] = useState(null);
  const [achToastKey, setAchToastKey] = useState(0);
  // Sound preferences — kept here (not local to SquishScreen) so a toggle
  // sticks across leaving and reopening a toy, not just within one visit.
  const [squishSoundEnabled, setSquishSoundEnabled] = useState(true);
  const [coinSoundEnabled, setCoinSoundEnabled] = useState(true);
  const [releaseSoundEnabled, setReleaseSoundEnabled] = useState(true);
  // Vibration on the squish stage (its strength follows pokeStrength).
  const [vibrationEnabled, setVibrationEnabled] = useState(true);
  // Squish-screen settings popup: FPS pill (off until switched on), poke
  // strength (1-5, 3 = the tuned default depth) and poke direction (push
  // in / pop out).
  const [showFps, setShowFps] = useState(false);
  const [pokeStrength, setPokeStrength] = useState(3);
  const [pokeOutward, setPokeOutward] = useState(false);

  // Daily Spin: 'unknown' until the profile loads, then 'show' (today's spin
  // is waiting — it comes before the menu) or 'done'.
  const [spinState, setSpinState] = useState('unknown');

  // Purchases: what's being bought right now (Remove Ads, a gem pack, an offer), Google Play's prices, and a toast for
  // how a purchase went.
  const [buying, setBuying] = useState(null);
  const [storePrices, setStorePrices] = useState({});
  const [appToast, setAppToast] = useState(null);
  const [appToastKey, setAppToastKey] = useState(0);
  // the Daily Challenges panel (src/progression.js)
  const [dailyOpen, setDailyOpen] = useState(false);
  // the streak screen opening by itself, once a day after the Daily Spin
  // (StreakScreen's `intro`)
  const [streakIntro, setStreakIntro] = useState(false);
  // the player level (src/playerXp.js, PLAYER_XP.md): the LEVEL UP card
  // ({ level, levels }: the levels it announces) and the levels the level
  // road claims as it opens (its COLLECT)
  const [levelUp, setLevelUp] = useState(null);
  const [roadAuto, setRoadAuto] = useState(null);

  const prevAchievementsRef = useRef(null);

  useEffect(
    () =>
      subscribeToAuthUser((user) => {
        setAuthUser(user);
        setAuthChecked(true);
      }),
    []
  );
  // Google / Facebook / TikTok: the browser comes back with a token
  useEffect(() => listenForSocial(() => Alert.alert('Sign-in', "That didn't work. Please try again.")), []);
  // an email account that hasn't confirmed its address yet waits on the
  // verify screen (`verifiedNow`: confirmed during this run)
  const [verifiedNow, setVerifiedNow] = useState(false);
  // (developer mode: never: SKIP_EMAIL_VERIFY, src/webDebug.js)
  const mustVerify = !SKIP_EMAIL_VERIFY && !!authUser && needsVerification(authUser) && !verifiedNow;
  // a tester account (the `tester` claim, tools/admin/tester.mjs): the Test
  // wallet and the FPS counter (REDESIGN_V6 ruling 5)
  const [tester, setTester] = useState(false);
  // (the switch is kept across launches; the web pages report while it's on for a tester: fpsMeter.js)
  const fpsOverlay = useFpsWanted();
  useEffect(() => setFpsActive(tester && fpsOverlay), [tester, fpsOverlay]);
  useEffect(() => {
    setTester(false);
    if (!authUser) return;
    authUser
      .getIdTokenResult(true)
      .then((t) => setTester(!!(t && t.claims && t.claims.tester)))
      .catch(() => {});
  }, [authUser]);
  const toggleFps = useCallback(() => setFpsWanted(!fpsOverlay), [fpsOverlay]);
  // a different account (or none) starts unconfirmed again
  useEffect(() => setVerifiedNow(false), [authUser?.uid]);

  useEffect(() => {
    if (!authUser) {
      setProfile(null);
      return undefined;
    }
    return subscribeToUserProfile(authUser.uid, setProfile);
  }, [authUser]);

  useEffect(() => {
    if (!authUser) {
      setCustomCreatures([]);
      return undefined;
    }
    return subscribeToCustomCreatures(authUser.uid, setCustomCreatures);
  }, [authUser]);

  // Once a day, the first time the app is opened (or brought back) on a new
  // day, the Daily Spin comes before the menu.
  const hasProfile = !!profile;
  const spunToday = hasSpunToday(profile);
  // The wheel is offered at most once per day per app run (the day it was
  // last offered is kept here), so a failed spin — or an ad closing, which
  // counts as coming back to the app — never brings it straight back.
  const spinOfferedDayRef = useRef(null);
  useEffect(() => {
    if (!authUser) {
      setSpinState('unknown');
      return;
    }
    if (!hasProfile || spinState !== 'unknown') return;
    const today = todayKey();
    const offer = !spunToday && spinOfferedDayRef.current !== today;
    if (offer) spinOfferedDayRef.current = today;
    setSpinState(offer ? 'show' : 'done');
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [authUser, hasProfile, spunToday, spinState]);
  // Coming back to the app on a new day offers it too — but only from the
  // menu, never in the middle of a squish.
  const resumeRef = useRef({ spunToday, onHome: false });
  resumeRef.current = { spunToday, onHome: screen === 'home' && !activeToy && !loadingToy };
  useEffect(() => {
    const sub = AppState.addEventListener('change', (state) => {
      const { spunToday: spun, onHome } = resumeRef.current;
      if (state === 'active' && !spun && onHome && spinOfferedDayRef.current !== todayKey()) setSpinState((s) => (s === 'done' ? 'unknown' : s));
    });
    return () => sub.remove();
  }, []);

  // In-app purchases (src/billing): Google Play's prices, and any purchase
  // not yet granted (or Remove Ads bought on another phone) sent to the
  // server once signed in.
  useEffect(() => billing.subscribePrices(setStorePrices), []);
  // Which price level each product sells at (config/pricing): a change
  // loads that level's store price; the re-render updates every label.
  const [pricingVersion, setPricingVersion] = useState(0);
  useEffect(() => {
    if (!authUser) return undefined;
    return subscribeToPricing((doc) => {
      setPricing(doc);
      setPricingVersion((v) => v + 1);
      billing.loadProducts();
    });
  }, [authUser]);
  // What the Shop's Deals and Gems tabs sell (config/offers): its offers'
  // store products load with the rest.
  const [offers, setOffers] = useState(null);
  useEffect(() => {
    if (!authUser) return undefined;
    return subscribeToOffers((doc) => {
      setOffers(doc);
      setOfferProducts(doc);
      setPricingVersion((v) => v + 1);
      billing.loadProducts();
    });
  }, [authUser]);
  const seenOffer = useCallback((id, at) => authUser && setOfferSeen(authUser.uid, id, at), [authUser]);
  // The groups and creatures not out yet and the set-reward rule
  // (config/roster, else functions/squad.js HIDDEN and SET_REWARDS): the
  // Shop and the menu follow them. Its copy counts (how many finds
  // unlock a creature) go to src/squad/data.js before the screens redraw.
  const [rosterCfg, setRosterCfg] = useState(null);
  useEffect(() => {
    if (!authUser) return undefined;
    return subscribeToRoster((cfg) => {
      setCopyCounts(cfg);
      setRainbowMode(cfg);
      setLookConfig(cfg); // the live rigs' outline (RigCreature)
      setRosterCfg(cfg);
    });
  }, [authUser]);
  const hidden = useMemo(() => hiddenOf(rosterCfg), [rosterCfg]);
  // every still creature picture in the look config/roster picks (REDESIGN_V9: look 1-4, 0 the old pictures)
  const creatures = useMemo(() => withLooks(catalog, rosterCfg), [catalog, rosterCfg]);
  // What the levels are (config/levels: the road, the curve, what earns XP):
  // into src/playerXp.js before the screens redraw, as the roster's counts
  const [levelsCfg, setLevelsCfg] = useState(null);
  // debug builds: com.plushcrush.app://royal opens the new look's kit (src/royal/Gallery.js, REDESIGN_V7 step 0)
  const [royal, setRoyal] = useState(false);
  useEffect(() => {
    if (!__DEV__) return undefined;
    const on = ({ url }) => /:\/\/royal/.test(url || '') && setRoyal(true);
    Linking.getInitialURL().then((url) => on({ url })).catch(() => {});
    const sub = Linking.addEventListener('url', on);
    return () => sub.remove();
  }, []);
  const closeRoyal = useCallback(() => setRoyal(false), []);
  useEffect(() => {
    if (!authUser) return undefined;
    return subscribeToLevels((cfg) => {
      setLevelsConfig(cfg);
      setLevelsCfg(cfg);
    });
  }, [authUser]);
  // Which weathers the game may show (config/weather, src/weather.js): one, always that one; more, today's by the
  // month. Into src/weather.js before the screens redraw; the menu's pages get today's in the game state below.
  const [weatherCfg, setWeatherCfg] = useState(null);
  useEffect(() => {
    if (!authUser) return undefined;
    return subscribeToWeather((cfg) => {
      setWeatherConfig(cfg);
      setWeatherCfg(cfg);
    });
  }, [authUser]);
  const setRewards = setRewardsOf(rosterCfg);
  // Rainbow chests earned once per group, or sold (config/roster { rainbow })
  const rainbow = rainbowOf(rosterCfg);
  // the catalog less what's not out yet (one already owned stays): what the
  // achievements and stats count
  const counted = useMemo(
    () => creatures.filter((c) => !BY_ID[String(c.id)] || isOut(BY_ID[String(c.id)], hidden) || owns(profile || {}, String(c.id))),
    [creatures, hidden, profile],
  );
  useEffect(() => {
    if (!authUser) return;
    billing.loadProducts().then(() => billing.syncPurchases());
    // the starting 600 gems, once (until the `squad` function
    // is deployed this fails quietly; the wallet shows them anyway)
    startSquad().catch(() => {});
  }, [authUser]);

  // One-time backward-compat migration for accounts created before the new
  // 10-creature roster existed — see ensureStarterCreaturesOwned's comment.
  useEffect(() => {
    if (!authUser || !profile) return;
    ensureStarterCreaturesOwned(authUser.uid, profile.ownedIds ?? []).catch(() => {});
    // Only needs to run once per profile snapshot that's missing a starter;
    // re-running after it succeeds is harmless (arrayUnion) but pointless.
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [authUser, profile?.ownedIds]);
  // …and for those from before player XP: their level (and Squishdoku's
  // Puzzle XP) become `pxp`, once
  const hasXp = typeof profile?.pxp === 'number';
  useEffect(() => {
    if (authUser && profile && !hasXp) migrateToXp(authUser.uid, profile);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [authUser, !!profile, hasXp]);

  // Seeds `creatures` from the on-device cache immediately (before auth even
  // resolves, so a signed-in launch is ready sooner), then
  // the live Firestore subscription below takes over once signed in and
  // refreshes the cache for next time.
  useEffect(() => {
    loadCachedCreatures().then((cached) => {
      if (cached.length) setCreatures((cur) => (cur.length ? cur : cached));
    });
  }, []);

  useEffect(() => {
    // firestore.rules requires auth for `creatures`, and a permission-denied
    // listen error doesn't auto-retry the way a transient one would — so
    // this must wait for authUser (and re-subscribe on sign-in/out) rather
    // than firing once at mount, or it dies before login ever happens and
    // never comes back.
    if (!authUser) return undefined;
    return subscribeToCreatures((list) => {
      if (list.length) {
        setCreatures(list);
        saveCreaturesToCache(list);
      }
      // An empty list here means a transient error — keep whatever the
      // cache (or a prior successful fetch) already put in state rather
      // than blanking the roster out from under the UI.
    });
  }, [authUser]);

  // Warm the image cache with every creature's art as soon as the catalog
  // arrives, so opening a screen never waits on the network for a picture.
  // PREFETCH_AT_ONCE at a time: all of them at once (hundreds) flooded the
  // bridge while the app started ("Excessive number of pending callbacks:
  // 501", 2026-10-28).
  const prefetchedRef = useRef(new Set());
  const prefetchQueue = useRef([]);
  const prefetching = useRef(0);
  useEffect(() => {
    const pump = () => {
      while (prefetching.current < PREFETCH_AT_ONCE && prefetchQueue.current.length) {
        const url = prefetchQueue.current.shift();
        prefetching.current += 1;
        Image.prefetch(url)
          .catch(() => prefetchedRef.current.delete(url))
          .finally(() => {
            prefetching.current -= 1;
            pump();
          });
      }
    };
    plushArtUrls(creatures).forEach((url) => {
      // (the looks' pictures are the app's own files: nothing to fetch)
      if (prefetchedRef.current.has(url) || !/^https?:/.test(url)) return;
      prefetchedRef.current.add(url);
      prefetchQueue.current.push(url);
    });
    pump();
  }, [creatures]);

  // Fires a top-banner toast the instant an achievement flips from
  // not-done to done — diffed against the previous profile snapshot rather
  // than stored server-side, since every achievement is itself derived from
  // the profile (see src/achievements.js).
  useEffect(() => {
    if (!profile || !counted.length) return;
    const current = computeAchievements(counted, profile, customCreatures.length);
    const prev = prevAchievementsRef.current;
    if (prev) {
      const newlyDone = current.find((entry) => entry.done && !prev[entry.key]);
      if (newlyDone) {
        setAchToast(newlyDone.title);
        setAchToastKey((k) => k + 1);
        sfx.play('achievement', { delay: 250 });
      }
    }
    prevAchievementsRef.current = Object.fromEntries(current.map((entry) => [entry.key, entry.done]));
  }, [profile, counted, customCreatures.length]);

  const profileRef = useRef(profile);
  profileRef.current = profile;
  // PLAY (Squish Time): the selected squishy (its catalog doc, the game's creature)
  const creaturesRef = useRef(creatures);
  creaturesRef.current = creatures;
  const playSelected = useCallback((id) => {
    const creature = creaturesRef.current.find((c) => c.id === id);
    // with its growth stage: the game's card is scaled (and crowned) by it
    if (creature) setLoadingToy({ ...creature, stage: stageOf(profileRef.current, id) });
  }, []);
  // the creature picked on the menu (CHARACTERS) is the player's selected squishy
  const selectSquishy = useCallback(
    (id) => {
      if (authUser) setLobbySelected(authUser.uid, id);
    },
    [authUser],
  );
  // the squish stage built under the loading beat: two frames after the beat came up (App's render below)
  const [squishUnder, setSquishUnder] = useState(false);
  // the stage under the loading beat has been built and drawn (SquishScreen's onShown): the beat starts moving only
  // then, since building it holds the UI thread for 0.2-0.3 s (LoadingScreen `hold`)
  const [squishShown, setSquishShown] = useState(false);
  const markSquishShown = useCallback(() => setSquishShown(true), []);
  const loadingOn = !!loadingToy;
  useEffect(() => {
    if (!loadingOn) {
      setSquishUnder(false);
      setSquishShown(false);
      return undefined;
    }
    let second = null;
    const first = requestAnimationFrame(() => {
      second = requestAnimationFrame(() => setSquishUnder(true));
    });
    return () => {
      cancelAnimationFrame(first);
      if (second != null) cancelAnimationFrame(second);
    };
  }, [loadingOn]);
  const finishLoadingToy = useCallback(() => {
    setActiveToy(loadingToy);
    setLoadingToy(null);
  }, [loadingToy]);
  const backToHome = useCallback(() => {
    setActiveToy(null);
    setScreen('home');
  }, []);

  // --- Daily Spin (src/dailySpin.js; the server rolls it) ---
  // `bonus`: "Watch ad, spin again", paid with a rewarded video on the
  // wheel screen. The prizes (coins, gems, a Mystery Box chest) are paid by
  // the server; the screen smashes a won chest itself.
  const handleSpin = useCallback((bonus = false) => callFunction('spinWheel', { tzOffsetMinutes: tzOffsetMinutes(), bonus }), []);
  const handleSpinDone = useCallback(() => {
    setSpinState('done');
    setScreen('home');
  }, []);

  const openAchievements = useCallback(() => setScreen('achievements'), []);
  // a mini-game (src/screens/*Screen.js), from the menu's Game Park
  const openGame = useCallback((name) => setScreen(name), []);

  // stable, so the memoized Shop only re-renders when the prices change
  const priceOf = useCallback((key) => billing.priceLabel(key, storePrices), [storePrices, pricingVersion]); // eslint-disable-line react-hooks/exhaustive-deps

  const flashApp = useCallback((msg) => {
    setAppToast(msg);
    setAppToastKey((k) => k + 1);
    setTimeout(() => setAppToast((cur) => (cur === msg ? null : cur)), 2600);
  }, []);

  // --- progression: daily challenges and the daily chest (src/progression.js) ---
  // `n` more of a challenge event; a toast when that completes one.
  const noteDaily = useCallback(
    (ev, n = 1) => {
      if (!authUser || !profile) return;
      const done = bumpDaily(authUser.uid, profile, ev, n);
      if (done.length) flashApp(`Challenge complete: ${done[0]}`);
    },
    [authUser, profile, flashApp]
  );
  const closeDaily = useCallback(() => setDailyOpen(false), []);

  // the layer the screen over the menu sits in (its exit slide on the way back)
  const layerRef = useRef(null);
  // Once a day, straight after the Daily Spin (or on the first visit to the
  // menu that day), while a streak is alive and today's chest is still shut:
  // the streak screen, to keep it going. `streakSeen` on the profile keeps it
  // to once a day across devices; the ref covers a failed write.
  const streakOfferedDayRef = useRef(null);
  const streakIntroDue =
    !!authUser &&
    !!profile &&
    spinState === 'done' &&
    screen === 'home' &&
    !activeToy &&
    !loadingToy &&
    dailyIsUnlocked(profile) &&
    streakOf(profile) > 0 &&
    profile.lastFull !== todayKey() &&
    profile.streakSeen !== todayKey() &&
    streakOfferedDayRef.current !== todayKey();
  useEffect(() => {
    if (!streakIntroDue) return;
    const today = todayKey();
    streakOfferedDayRef.current = today;
    markStreakSeen(authUser.uid, today);
    setStreakIntro(true);
  }, [streakIntroDue, authUser]);
  // back to the menu with the layer's slide, like every other screen
  const closeStreak = useCallback(() => {
    const done = () => {
      setStreakIntro(false);
      setScreen('home');
    };
    const layer = layerRef.current;
    if (layer) layer.exit(done);
    else done();
  }, []);
  const streakToDaily = useCallback(() => {
    setStreakIntro(false);
    setScreen('home');
    setDailyOpen(true);
  }, []);
  const handleClaimDaily = useCallback(
    (id) => {
      if (!authUser) return;
      const r = claimDailyChallenge(authUser.uid, profile, id);
      if (r) flashApp(`+${r.coins} coins · +${r.xp} XP!`);
    },
    [authUser, profile, flashApp]
  );
  // the daily chest: its coins here, a streak day's gems or extra free chest
  // from the server — squad dailyGift
  // (the streak day's reward: src/progression.js STREAK_REWARDS)
  const handleClaimChest = useCallback(() => {
    if (!authUser) return;
    const r = claimDailyChest(authUser.uid, profile);
    if (!r) return;
    const gift = r.reward.kind === 'gems' || r.reward.kind === 'chest' ? r.reward : null;
    squadDailyGift(gift).catch(() => {});
    const extra = r.reward.kind === 'gems' ? ` + ${r.reward.amount} gems` : r.reward.kind === 'chest' ? ' + a free chest in the Shop' : r.reward.kind === 'half' ? ' + half price on your next creation' : '';
    flashApp(`Daily chest: +${r.coins} coins · +${r.xp} XP${extra}!`);
  }, [authUser, profile, flashApp]);
  // the daily challenges' "go to the house": the menu walks into its house
  const dailyToCrib = useCallback(() => {
    setDailyOpen(false);
    setScreen('crib');
  }, []);

  // --- the menu (src/game, webgame/): its gear opens Settings, its trophy the Achievements, SHOP the Shop ---
  const openSettingsPage = useCallback(() => setScreen('settings'), []);
  // screens opened from Settings (Achievements, Stats, the level road) go back to it, not to the menu
  const fromSettingsRef = useRef(false);
  const openFromSettings = useCallback((name) => {
    fromSettingsRef.current = true;
    if (name === 'road') setRoadAuto(null);
    setScreen(name);
  }, []);
  const settingsAchievements = useCallback(() => openFromSettings('achievements'), [openFromSettings]);
  const settingsStats = useCallback(() => openFromSettings('stats'), [openFromSettings]);
  const settingsRoad = useCallback(() => openFromSettings('road'), [openFromSettings]);
  // a house request (the daily challenges) has walked into the menu's house: the menu is the screen again
  const gameHouseShown = useCallback(() => {
    setScreen((s) => (s === 'crib' ? 'home' : s));
  }, []);
  // the menu's SHOP (and its coin / gem pills): the Shop, a landscape screen of its own over the menu
  const openGameShop = useCallback(() => {
    setShopTab('chests');
    setShopKey((k) => k + 1);
    setScreen('shop');
  }, []);
  // the menu's games page: Squish Time (with the menu's creature) or one of the app's games
  const handleGamePlay = useCallback(
    (mode, key) => {
      if (mode === 'squishdoku' || mode === 'sort' || mode === 'stack' || mode === 'hop') openGame(mode);
      else playSelected(idOfKey(key) || selectedIdOf(profileRef.current));
    },
    [openGame, playSelected],
  );
  // the creature picked on the menu (CHARACTERS) is the player's selected squishy
  const handleGameSelect = useCallback((key) => {
    const id = idOfKey(key);
    if (id) selectSquishy(id);
  }, [selectSquishy]);
  // the menu's Level Pass: coins and gems are claimed here; a chest opens the level road (its chest smash) on that level
  const handleGameClaim = useCallback(async ({ lv, all }) => {
    const waiting = roadView(profileRef.current).filter((n) => n.claimable).map((n) => n.lv);
    const lvs = all ? waiting : waiting.filter((l) => l === lv);
    if (!lvs.length) return { ok: false, error: 'nothing_to_claim' };
    if (lvs.some((l) => (roadPrize(l) || {}).k === 'chest')) {
      setRoadAuto(lvs);
      setScreen('road');
      return { road: true };
    }
    try {
      if (lvs.length > 1) await squadLevelClaimAll();
      else await squadLevelClaim(lvs[0]);
      return { ok: true };
    } catch (e) {
      return { ok: false, error: e?.message || 'failed' };
    }
  }, []);
  // eslint-disable-next-line react-hooks/exhaustive-deps
  const gamePlayerNow = useMemo(() => gamePlayer(profile, { level: xpView(profile).level, hidden, rosterCfg }), [profile, hidden, levelsCfg, rosterCfg, weatherCfg]);

  const handleLogout = useCallback(async () => {
    // closed, so the next sign-in doesn't open on it
    setActiveToy(null);
    setLoadingToy(null);
    setScreen('home');
    await logout();
  }, []);

  const handleEarnCoins = useCallback(
    (amount) => {
      if (!authUser) return;
      addCoins(authUser.uid, amount).catch(() => {});
      noteDaily('earn', amount);
    },
    [authUser, noteDaily]
  );

  // Real-money purchases through Google Play (src/billing): Remove Ads, a gem pack or an offer. The server grants
  // them; the profile snapshot brings the change in. Resolves with the server's answer, or null if nothing was
  // granted (yet).
  const purchase = useCallback(
    async (key, creature = null) => {
      if (!authUser || buying) return null;
      setBuying(creature ? creature.id : key);
      try {
        const r = await billing.buy(key, { uid: authUser.uid, creatureId: creature ? creature.id : '' });
        if (r.pending) flashApp('Payment pending — it arrives as soon as it clears');
        else if (r.granted === 'adsFree' || r.granted === 'restored') flashApp('Ads removed — thank you!');
        else if (r.granted === 'coins') flashApp(`Already unlocked — here are ${fmtNum(r.coins)} coins instead`);
        else if (r.granted === 'gems' && !r.offer) flashApp(`+${fmtNum(r.gems)} gems${r.doubled ? ' (doubled!)' : ''}`);
        return r.pending ? null : r;
      } catch (e) {
        if (e.code === 'cancelled') return null;
        if (e.code === 'verify') {
          flashApp("Payment received — it'll show up in a moment");
          setTimeout(() => billing.syncPurchases(), 5000);
        } else if (e.code === 'network') flashApp('No connection — try again');
        else if (e.code === 'busy') flashApp('Another purchase is still going');
        else flashApp("Purchases aren't available right now");
        return null;
      } finally {
        setBuying(null);
      }
    },
    [authUser, buying, flashApp]
  );
  // the menu's pages ask the app for what needs the phone or the server (webgame/app/bridge.js App.ask, REDESIGN_V7):
  // 'squad' { move, args }: a squad server move; 'buy' { key }: a Play purchase; 'price' { keys }: the store prices
  const handleGameAsk = useCallback(
    async (what, p) => {
      if (what === 'squad') return squadMove(p.move, p.args || {});
      if (what === 'buy') return purchase(p.key);
      if (what === 'price') return Object.fromEntries((p.keys || []).map((k) => [k, priceOf(k)]));
      throw new Error('unknown_ask');
    },
    [purchase, priceOf],
  );

  const handleRecordPress = useCallback(
    (creatureId, holdMs) => {
      if (!authUser) return;
      recordPress(authUser.uid, creatureId, holdMs).catch(() => {});
      noteDaily('squish');
    },
    [authUser, noteDaily]
  );

  const handleMarkAchievement = useCallback(
    (key) => {
      if (!authUser) return;
      markAchievement(authUser.uid, key).catch(() => {});
    },
    [authUser]
  );

  // A ×N boost started (with Remove Ads there's no video, so it only counts
  // toward the biggest boost, not the ads watched).
  const handleAdWatched = useCallback(
    (multiplier) => {
      if (!authUser) return;
      recordAdWatched(authUser.uid, multiplier, profile?.maxMult ?? 0, !profile?.adsFree).catch(() => {});
      if (!profile?.adsFree) noteDaily('ad');
    },
    [authUser, profile?.maxMult, profile?.adsFree, noteDaily]
  );

  const handleSaveNickname = useCallback(
    (nickname) => {
      if (!authUser) return;
      updateNickname(authUser.uid, nickname).catch(() => {});
    },
    [authUser]
  );

  const handleSubmitFeedback = useCallback(
    (text) => {
      if (!authUser) return;
      submitFeedback(authUser.uid, text).catch(() => {});
    },
    [authUser]
  );

  // web, development only: the browser tests open screens and cards straight from the page (src/web/README.md)
  if (__DEV__ && typeof window !== 'undefined' && window.document) {
    window.__app = { setScreen, setSpinState, setStreakIntro, setLevelUp, setDailyOpen, setRoadAuto, flashApp, setAchToast, setAchToastKey, play: () => playSelected(selectedIdOf(profileRef.current)) };
  }

  // the launch is ready: sign-in known and, signed in, the profile and the catalog here (or 10 s: offline)
  const launchReady = authChecked && (!authUser || (!!profile && creatures.length > 0));
  useEffect(() => {
    if (splashDone) return undefined;
    if (launchReady) {
      setSplashDone(true);
      return undefined;
    }
    const t = setTimeout(() => setSplashDone(true), 10000);
    return () => clearTimeout(t);
  }, [launchReady, splashDone]);
  const introDue = introPending;

  let stage = 'splash';
  if (splashDone && authChecked) {
    if (!authUser) stage = 'auth';
    else if (mustVerify) stage = 'verify';
    // the game intro first (on the menu): the daily spin and the streak come after it
    else if (introDue && screen === 'home') stage = 'home';
    else if (spinState === 'show') stage = 'wheel';
    else if (streakIntro) stage = 'streak';
    else if (activeToy) stage = 'toy';
    else if (loadingToy) stage = 'loading';
    else stage = screen;
  }
  // the menu (or its house) is the screen
  const onGame = stage === 'home' || stage === 'crib';
  // the menu tells us when the intro starts and ends; if it hasn't started 15 s after the menu came up (the page
  // failed), stop waiting for it
  const onIntro = useCallback((phase) => {
    if (phase === 'start') introStartedRef.current = true;
    else if (phase === 'awake') setIntroAwake(true);
    else if (phase === 'done') setIntroPending(false);
  }, []);
  // no music during the intro until its third squish of Mittens (or until it's skipped, ends, or never starts: the
  // 15 s wait below), nor on the sign-in screens before it
  const musicHeld = introPending && !introAwake && (introDue || stage === 'auth' || stage === 'verify');
  const introWaiting = introDue && onGame;
  useEffect(() => {
    if (!introWaiting) return undefined;
    const t = setTimeout(() => {
      if (!introStartedRef.current) setIntroPending(false);
    }, 15000);
    return () => clearTimeout(t);
  }, [introWaiting]);
  // every screen is landscape (REDESIGN_V7/V8; the manifest and app.json say so too)
  useEffect(() => {
    ScreenOrientation.lockAsync(ScreenOrientation.OrientationLock.LANDSCAPE).catch(() => {});
  }, []);

  // LEVEL UP (src/components/LevelBits.js): once a level is reached past 3,
  // on the menu with nothing else up. `lvSeen` on the profile keeps it to
  // once a level on every device; the ref covers a failed write. COLLECT
  // claims every prize waiting on the level road.
  const lvNow = profile ? levelOf(profile) : 1;
  const lvSeen = Math.max(3, Math.floor(profile?.lvSeen ?? 0));
  const shownLvRef = useRef(0);
  // the test wallet's "Claim prizes again" lowers `lvSeen`: the card may
  // show again for a level it already showed this session
  const lastLvSeenRef = useRef(lvSeen);
  if (lvSeen < lastLvSeenRef.current) shownLvRef.current = Math.min(shownLvRef.current, lvSeen);
  lastLvSeenRef.current = lvSeen;
  const levelUpDue = !!authUser && hasXp && lvNow > lvSeen && lvNow > shownLvRef.current && stage === 'home' && !dailyOpen && !levelUp && !introDue;
  useEffect(() => {
    if (!levelUpDue) return;
    shownLvRef.current = lvNow;
    markLevelSeen(authUser.uid, lvNow);
    setLevelUp({ level: lvNow });
    sfx.play('sd_levelUp');
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [levelUpDue]);
  const closeLevelUp = useCallback(() => setLevelUp(null), []);
  const collectLevelUp = useCallback(() => {
    setLevelUp(null);
    setRoadAuto(
      roadView(profileRef.current)
        .filter((n) => n.claimable)
        .map((n) => n.lv),
    );
    setScreen('road');
  }, []);

  // PERF 2026-11-20 (the user: coming back to the menu showed a blank brown screen and "Loading your house…" for ~3 s):
  // the menu's WebView stays alive under every other screen instead of being rebuilt on each return. Once a screen has
  // covered it (`menuCovered`), the page is put to sleep (nothing drawn or computed: webgame/app/bridge.js 'sleep')
  // and hidden (opacity 0: Android skips drawing it). On the way back it wakes as the screen starts sliding away, so
  // the menu is already there, exactly as it was left (the Game Park, Characters…), under the slide.
  const menuAlive = !!authUser && !!profile && stage !== 'splash' && stage !== 'auth' && stage !== 'verify';
  const [menuCovered, setMenuCovered] = useState(false);
  const coverMenu = useCallback(() => setMenuCovered(true), []);
  const uncoverMenu = useCallback(() => setMenuCovered(false), []);
  useEffect(() => {
    if (onGame) setMenuCovered(false);
  }, [onGame]);
  const menuAsleep = menuCovered && !onGame;
  // Back to the menu from a screen over it: it slides away first (ScreenLayer's exit), with the menu waking under it;
  // the screen switch follows the slide.
  const goHome = useCallback(() => {
    // back from a screen Settings opened: to Settings
    if (fromSettingsRef.current) {
      fromSettingsRef.current = false;
      const layer0 = layerRef.current;
      if (layer0) layer0.exit(() => setScreen('settings'), { uncover: false });
      else setScreen('settings');
      return;
    }
    const layer = layerRef.current;
    if (layer) layer.exit(() => setScreen('home'));
    else setScreen('home');
  }, []);
  // Android back on a screen that doesn't handle it itself (Shop, Achievements, Stats…): back to the menu. (The menu's
  // own handler, src/game/GameScreen.js, steps aside while the menu is covered; the screens' own handlers come first.)
  const stageRef = useRef(stage);
  stageRef.current = stage;
  useEffect(() => {
    const sub = BackHandler.addEventListener('hardwareBackPress', () => {
      const s = stageRef.current;
      if (s === 'streak') {
        closeStreak();
        return true;
      }
      // Squish Time and its loading beat (neither handles back itself: back used to leave the app)
      if (s === 'toy') {
        backToHome();
        return true;
      }
      if (s === 'loading') {
        setLoadingToy(null);
        return true;
      }
      if (BACK_TO_MENU.has(s)) {
        goHome();
        return true;
      }
      return false;
    });
    return () => sub.remove();
  }, [goHome, closeStreak, backToHome]);

  // --- sound (src/audio/sfx.js): the music, a whoosh between screens, and coins coming in or going out. The squish
  // screen and the Mystery Box play their own coin sounds.
  useEffect(() => {
    sfx.music(fontsLoaded && !musicHeld ? musicFor(stage) : null);
  }, [stage, fontsLoaded, musicHeld]);
  const prevStageRef = useRef(stage);
  useEffect(() => {
    // no whoosh as the splash makes way for the first screen (REDESIGN_V8, the user: the "beep" at the start; the
    // whoosh's sound has a steady 1050 Hz tone in it)
    if (prevStageRef.current !== stage && prevStageRef.current !== 'splash') sfx.play('whoosh');
    prevStageRef.current = stage;
  }, [stage]);
  const coinsNow = profile?.coins;
  const prevCoinsRef = useRef(coinsNow);
  useEffect(() => {
    const prev = prevCoinsRef.current;
    prevCoinsRef.current = coinsNow;
    if (prev == null || coinsNow == null || prev === coinsNow || stage === 'toy' || stage === 'box') return;
    sfx.play(coinsNow > prev ? 'coinShower' : 'spend');
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [coinsNow]);

  // test builds only (WEBVIEW_DEBUG, src/webDebug.js; off in a release): com.plushcrush.app://open/<what> opens a screen or
  // card that the test account can't reach today, to measure it on a phone: wheel | streak | levelup | daily | <screen>.
  // It only shows them: nothing is claimed or spun unless a button is pressed.
  useEffect(() => {
    if (!WEBVIEW_DEBUG) return undefined;
    const on = ({ url }) => {
      const m = /:\/\/open\/(\w+)/.exec(url || '');
      if (!m) return;
      const w = m[1];
      if (w === 'wheel') setSpinState('show');
      else if (w === 'streak') setStreakIntro(true);
      else if (w === 'levelup') setLevelUp({ level: Math.max(2, xpView(profileRef.current).level) });
      else if (w === 'daily') setDailyOpen(true);
      else if (w === 'home') {
        setSpinState('done');
        setStreakIntro(false);
        setLevelUp(null);
        setDailyOpen(false);
        setScreen('home');
      } else setScreen(w);
    };
    const sub = Linking.addEventListener('url', on);
    return () => sub.remove();
  }, []);

  if (!fontsLoaded) {
    return <View style={styles.fill} onLayout={measureRoot} />;
  }

  const adsFree = profile?.adsFree ?? false;
  // the player's level and XP, and the level road's prizes waiting
  const xpNow = xpView(profile);
  const roadWaiting = profile ? roadClaimable(profile) : 0;
  const lvPrize = levelUp && !(profile?.levelGot || {})[levelUp.level] ? roadPrize(levelUp.level) : null;
  // the streak screen's squishy (the one squished longest, else the first owned)
  const mascot = stage === 'streak' ? streakMascot(creatures, profile) : null;
  // squish coins: the streak's +5% a day
  const coinMultiplier = streakMultiplier(profile);
  // every other screen once signed in sits in a ScreenLayer over the menu
  const overlay = !onGame && stage !== 'splash' && stage !== 'auth' && stage !== 'verify';
  // Squish Time's creature: the stage is built under its loading beat (one layer for both, so the stage carries on
  // as the beat ends instead of being built after it: that showed the bare background between the two)
  // (built once the beat's own first frame is on screen, so building the stage never holds the beat back)
  const squishToy = stage === 'toy' ? activeToy : stage === 'loading' && squishUnder ? loadingToy : null;

  return (
    <SafeAreaProvider style={styles.app}>
      <View style={StyleSheet.absoluteFill} pointerEvents="none" onLayout={measureRoot} />
      <StatusBar style="light" hidden />
      {/* until the launch is ready: the launch colour (the game intro plays on the menu once it's up) */}
      {stage === 'splash' && <View style={styles.fill} />}
      {stage === 'auth' && <AuthScreen />}
      {stage === 'verify' && <VerifyEmailScreen email={authUser?.email} onVerified={() => setVerifiedNow(true)} onLogout={handleLogout} />}
      {menuAlive && (
        <View style={[StyleSheet.absoluteFill, menuAsleep && styles.asleep]} pointerEvents={onGame ? 'auto' : 'none'}>
          <GameScreen
            uid={authUser.uid}
            player={gamePlayerNow}
            asleep={menuAsleep}
            wantHouse={stage === 'crib'}
            onHouseShown={gameHouseShown}
            onShop={openGameShop}
            onSettings={openSettingsPage}
            onAchievements={openAchievements}
            onPlay={handleGamePlay}
            onSelect={handleGameSelect}
            onClaim={handleGameClaim}
            onAsk={handleGameAsk}
            intro={introDue}
            onIntro={onIntro}
          />
        </View>
      )}
      {overlay && (
        <ScreenLayer ref={layerRef} key={stage === 'loading' || stage === 'toy' ? 'squish' : stage} slide={false} onCovered={coverMenu} onUncover={uncoverMenu}>
          {stage === 'wheel' && (
            <DailySpinScreen
              onSpin={handleSpin}
              onDone={handleSpinDone}
              bonusLeft={adSpinsLeft(profile)}
              adsFree={profile?.adsFree ?? false}
              name={profile?.nickname}
              creatures={creatures}
              profile={profile}
              hidden={hidden}
            />
          )}
          {stage === 'streak' && (
            <StreakScreen profile={profile} mascot={mascot} intro={streakIntro} onClose={closeStreak} onOpenDaily={streakToDaily} />
          )}
          {stage === 'achievements' && (
            <AchievementsScreen creatures={counted} profile={profile} customCount={customCreatures.length} onBack={goHome} />
          )}
          {/* the games and the level road come in as placeholders and are built once the layer is up (ScreenLayer) */}
          {stage === 'squishdoku' && (
            <WhenScreenReady placeholder={<ScreenBones kind="hub" bg="wood" />}>
              <SquishdokuScreen profile={profile} creatures={creatures} hidden={hidden} uid={authUser?.uid} adsFree={adsFree} haptics={vibrationEnabled} onBack={goHome} />
            </WhenScreenReady>
          )}
          {stage === 'sort' && (
            <WhenScreenReady placeholder={<ScreenBones kind="hub" />}>
              <SortScreen profile={profile} creatures={creatures} hidden={hidden} uid={authUser?.uid} adsFree={adsFree} haptics={vibrationEnabled} onBack={goHome} />
            </WhenScreenReady>
          )}
          {stage === 'stack' && (
            <WhenScreenReady placeholder={<ScreenBones kind="hub" />}>
              <StackScreen profile={profile} creatures={creatures} hidden={hidden} uid={authUser?.uid} adsFree={adsFree} haptics={vibrationEnabled} onBack={goHome} />
            </WhenScreenReady>
          )}
          {stage === 'hop' && (
            <WhenScreenReady placeholder={<ScreenBones kind="map" />}>
              <HopScreen profile={profile} creatures={creatures} hidden={hidden} uid={authUser?.uid} adsFree={adsFree} haptics={vibrationEnabled} onBack={goHome} />
            </WhenScreenReady>
          )}
          {stage === 'settings' && (
            <SettingsRoyal
              onBack={goHome}
              nickname={profile?.nickname ?? 'Squisher'}
              onSaveNickname={handleSaveNickname}
              onSubmitFeedback={handleSubmitFeedback}
              onLogout={handleLogout}
              onOpenStats={settingsStats}
              onOpenAchievements={settingsAchievements}
              onOpenRoad={settingsRoad}
              tester={tester}
              wallet={{ ...walletOf(profile), level: xpNow.level }}
              fpsOn={fpsOverlay}
              onToggleFps={toggleFps}
            />
          )}
          {stage === 'shop' && (
            <ShopScreen
              openKey={shopKey}
              startTab={shopTab}
              creatures={creatures}
              profile={profile}
              offers={offers}
              hidden={hidden}
              setRewards={setRewards}
              rainbow={rainbow}
              onSeenOffer={seenOffer}
              onBuyProduct={purchase}
              priceOf={priceOf}
              onBack={goHome}
            />
          )}
          {stage === 'stats' && (
            <StatsScreen creatures={counted} customCreatures={customCreatures} profile={profile} onBack={goHome} />
          )}
          {stage === 'road' && (
            <WhenScreenReady placeholder={<ScreenBones kind="list" bg="wood" />}>
              <LevelRoadScreen profile={profile} levels={levelsCfg} creatures={creatures} hidden={hidden} autoClaim={roadAuto} onBack={goHome} />
            </WhenScreenReady>
          )}
          {squishToy && (
            <SquishScreen
              toy={squishToy}
              onShown={markSquishShown}
              coins={profile?.coins ?? 0}
              onBack={backToHome}
              onEarnCoins={handleEarnCoins}
              onRecordPress={handleRecordPress}
              achievements={profile?.achievements ?? NO_ACHIEVEMENTS}
              onMarkAchievement={handleMarkAchievement}
              onAdWatched={handleAdWatched}
              squishSoundEnabled={squishSoundEnabled}
              onToggleSquishSound={setSquishSoundEnabled}
              coinSoundEnabled={coinSoundEnabled}
              onToggleCoinSound={setCoinSoundEnabled}
              releaseSoundEnabled={releaseSoundEnabled}
              onToggleReleaseSound={setReleaseSoundEnabled}
              vibrationEnabled={vibrationEnabled}
              onToggleVibration={setVibrationEnabled}
              showFps={showFps}
              onToggleShowFps={setShowFps}
              pokeStrength={pokeStrength}
              onChangePokeStrength={setPokeStrength}
              pokeOutward={pokeOutward}
              onChangePokeOutward={setPokeOutward}
              adsFree={adsFree}
              coinMultiplier={coinMultiplier}
            />
          )}
          {/* the loading beat over the stage, which is built under it meanwhile: its fade shows the stage ready */}
          {stage === 'loading' && (
            <View style={StyleSheet.absoluteFill}>
              <LoadingScreen creature={loadingToy} onFinish={finishLoadingToy} hold={!squishShown} />
            </View>
          )}
        </ScreenLayer>
      )}
      {authUser ? <DailyChallengesSheet visible={dailyOpen} profile={profile} onClose={closeDaily} onClaim={handleClaimDaily} onClaimChest={handleClaimChest} onOpenCrib={dailyToCrib} /> : null}
      {levelUp ? (
        <LevelUpCard
          level={levelUp.level}
          prize={lvPrize}
          more={Math.max(0, roadWaiting - (lvPrize ? 1 : 0))}
          group={lineup(todayKey(), hidden)[0]}
          onCollect={collectLevelUp}
          onLater={closeLevelUp}
        />
      ) : null}
      <View pointerEvents="none" style={APP_TOAST_AT}>
        <Toast message={appToast} messageKey={appToastKey} />
      </View>
      <AchievementToast title={achToast} messageKey={achToastKey} />
      {tester && fpsOverlay ? <FpsCounter /> : null}
      {__DEV__ && royal ? <RoyalGallery onClose={closeRoyal} /> : null}
    </SafeAreaProvider>
  );
}

const styles = StyleSheet.create({
  // the launch colour behind everything: a screen sliding away before the one under it has drawn shows warm wood,
  // never a flash of another colour
  app: { backgroundColor: LAUNCH_BG },
  fill: { flex: 1, backgroundColor: LAUNCH_BG },
  // the menu while a screen covers it: not drawn at all (Android skips a view whose opacity is 0)
  asleep: { opacity: 0 },
});
