// Must load before anything that touches GLTFLoader (see SquishyToy.js's
// Glorp build path) — Hermes doesn't provide TextDecoder/TextEncoder,
// which GLTFLoader needs to decode a GLB's embedded JSON chunk. Has to be
// the first import in the app's entry file so its global.TextDecoder/
// TextEncoder polyfill is in place before any other module (transitively
// including SquishyToy.js) gets evaluated.
import 'fast-text-encoding';
import React, { useCallback, useEffect, useRef, useState } from 'react';
import { View, Alert, Image, AppState } from 'react-native';
import { StatusBar } from 'expo-status-bar';
import { SafeAreaProvider } from 'react-native-safe-area-context';
import mobileAds from 'react-native-google-mobile-ads';
import { useFonts } from 'expo-font';
import { Baloo2_500Medium, Baloo2_700Bold, Baloo2_800ExtraBold } from '@expo-google-fonts/baloo-2';
import { Nunito_400Regular, Nunito_600SemiBold, Nunito_700Bold, Nunito_800ExtraBold, Nunito_900Black } from '@expo-google-fonts/nunito';
import { Fredoka_500Medium, Fredoka_600SemiBold, Fredoka_700Bold } from '@expo-google-fonts/fredoka';
import SplashScreen from './src/screens/SplashScreen';
import AuthScreen from './src/screens/AuthScreen';
import MainScreen from './src/screens/MainScreen';
import SettingsSheet from './src/screens/SettingsSheet';
import AchievementsScreen from './src/screens/AchievementsScreen';
import StatsScreen from './src/screens/StatsScreen';
import ShopScreen from './src/screens/ShopScreen';
import SquishiesScreen from './src/screens/SquishiesScreen';
import DailySpinScreen from './src/screens/DailySpinScreen';
import LoadingScreen from './src/screens/LoadingScreen';
import SquishScreen from './src/screens/SquishScreen';
import CribScreen from './src/screens/CribScreen';
import DailyChallengesSheet from './src/screens/DailyChallengesSheet';
import StreakScreen from './src/screens/StreakScreen';
import TutorialGuide from './src/tutorial/Guide';
import useTutorial from './src/tutorial/useTutorial';
import { report as tutReport } from './src/tutorial/store';
import { tutorialActive } from './src/tutorial/steps';
import { streakMultiplier, streakOf, TUTORIAL_BOOST, cribUnlocked, dailyUnlocked as dailyIsUnlocked, dailyView, level as levelOf } from './src/progression';
import AchievementToast from './src/components/squad/AchievementToast';
import Toast from './src/components/squad/Toast';
import { TurnWithCrib } from './src/crib/orientation';
import { RemoveAdsSheet } from './src/components/RemoveAds';
import ForcedInterstitialAd from './src/components/ForcedInterstitialAd';
import { computeAchievements } from './src/achievements';
import { subscribeToAuthUser, logout } from './src/firebase/auth';
import {
  subscribeToUserProfile,
  subscribeToCreatures,
  subscribeToPricing,
  addCoins,
  recordPress,
  markAchievement,
  recordAdWatched,
  updateNickname,
  submitFeedback,
  ensureStarterCreaturesOwned,
  subscribeToCustomCreatures,
  addCustomCreature,
  deleteCustomCreature,
  retryCustomCreature,
  newCustomCreatureId,
  setTutorialStep,
  setLevel,
  markStreakSeen,
  bumpDaily,
  claimDailyChallenge,
  claimDailyChest,
} from './src/firebase/firestore';
import { uploadSourceImage, deleteCustomAssets } from './src/firebase/storage';
import { loadCachedCreatures, saveCreaturesToCache } from './src/data/creatureCache';
import CreateScreen from './src/screens/CreateScreen';
import { plushArtUrls } from './src/components/CreatureThumbnail';
import * as billing from './src/billing';
import { setPricing } from './src/economy';
import { adSpinsLeft, hasSpunToday, todayKey, tzOffsetMinutes } from './src/dailySpin';
import callFunction from './src/firebase/callFunction';
import { dailyGift as squadDailyGift, startSquad } from './src/squad/api';
import sfx from './src/audio/sfx';

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

// Background music for each screen (the design's MUSIC table).
const APP_TOAST_AT = { position: 'absolute', left: 0, right: 0, bottom: 150, height: 0, zIndex: 70, elevation: 70 };

const MUSIC_FOR_STAGE = {
  splash: 'dream',
  auth: 'dream',
  wheel: 'party',
  streak: 'party',
  home: 'cozy',
  store: 'cozy',
  achievements: 'cozy',
  stats: 'cozy',
  create: 'cozy',
  loading: 'calm',
  toy: 'calm',
  box: 'mystery',
  // the Crib plays its rooms' own music (CribScreen)
};

// The creature cheering on the streak screen: the owned one squished the
// longest, else the first owned, else the starter.
function streakMascot(creatures, profile) {
  const owned = creatures.filter((c) => (profile?.ownedIds || []).includes(c.id));
  const time = profile?.stats?.playTime || {};
  const best = owned.reduce((a, c) => ((time[c.id] || 0) > (a ? time[a.id] || 0 : -1) ? c : a), null);
  return best || owned[0] || creatures[0] || null;
}

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

  const [splashDone, setSplashDone] = useState(false);
  const [authChecked, setAuthChecked] = useState(false);
  const [authUser, setAuthUser] = useState(null);
  const [profile, setProfile] = useState(null);
  const [creatures, setCreatures] = useState([]);
  const [customCreatures, setCustomCreatures] = useState([]);
  // The creature just made in CREATE: Home opens on MY CREATURES at its
  // card, then clears this (clearMineFocus).
  const [mineFocus, setMineFocus] = useState(null); // { id, token }
  const clearMineFocus = useCallback(() => setMineFocus(null), []);
  const [screen, setScreen] = useState('home'); // 'home' | 'achievements' | 'stats' | 'create' | 'crib' | … — only relevant once signed in
  // 'home' is the app shell (MainScreen): its open tab ('squish' | 'shop'),
  // and the Shop's own tab to open on (`shopKey` restarts the Shop there)
  const [mainTab, setMainTab] = useState('squish');
  const [shopTab, setShopTab] = useState('chests');
  const [shopKey, setShopKey] = useState(0);
  const [settingsOpen, setSettingsOpen] = useState(false);
  // A card tap moves a creature into `loadingToy` (LoadingScreen's "getting
  // ready" beat) before it graduates to `activeToy` (SquishScreen actually
  // mounted) — kept as two separate slots so the transition screen has
  // somewhere to read the pending creature from.
  const [loadingToy, setLoadingToy] = useState(null);
  const [activeToy, setActiveToy] = useState(null);
  const [achToast, setAchToast] = useState(null);
  const [achToastKey, setAchToastKey] = useState(0);
  // Bumped by handleCreatureCreated whenever a creature was just made using
  // a free generation credit — ForcedInterstitialAd fires once per bump.
  // Paid creations (once real IAP exists) never bump this.
  const [freeGenAdTrigger, setFreeGenAdTrigger] = useState(0);
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
  // is waiting — it comes before Home) or 'done'.
  const [spinState, setSpinState] = useState('unknown');

  // Purchases: the Remove Ads popup, what's being bought right now
  // ('removeAds', a gem pack, a creation),
  // Google Play's prices, and a toast for how a purchase went.
  const [removeAdsOpen, setRemoveAdsOpen] = useState(false);
  const [buying, setBuying] = useState(null);
  const [storePrices, setStorePrices] = useState({});
  const [appToast, setAppToast] = useState(null);
  const [appToastKey, setAppToastKey] = useState(0);
  // the Daily Challenges panel (src/progression.js)
  const [dailyOpen, setDailyOpen] = useState(false);
  // the streak screen opening by itself, once a day after the Daily Spin
  // (StreakScreen's `intro`; from the menu it's just a screen)
  const [streakIntro, setStreakIntro] = useState(false);

  const prevAchievementsRef = useRef(null);

  useEffect(
    () =>
      subscribeToAuthUser((user) => {
        setAuthUser(user);
        setAuthChecked(true);
      }),
    []
  );

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
  // day, the Daily Spin comes before Home.
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
    // not during the tutorial (the design skips the wheel until it's done)
    const offer = !spunToday && !tutorialActive(profile) && spinOfferedDayRef.current !== today;
    if (offer) spinOfferedDayRef.current = today;
    setSpinState(offer ? 'show' : 'done');
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [authUser, hasProfile, spunToday, spinState]);
  // Coming back to the app on a new day offers it too — but only from Home,
  // never in the middle of a squish.
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
  const [, setPricingVersion] = useState(0);
  useEffect(() => {
    if (!authUser) return undefined;
    return subscribeToPricing((doc) => {
      setPricing(doc);
      setPricingVersion((v) => v + 1);
      billing.loadProducts();
    });
  }, [authUser]);
  useEffect(() => {
    if (!authUser) return;
    billing.loadProducts().then(() => billing.syncPurchases());
    // the starting 600 gems and 180 Stars, once (until the `squad` function
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

  // Seeds `creatures` from the on-device cache immediately (before auth even
  // resolves — SplashScreen needs something to render at cold start), then
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
    // never comes back, leaving Home stuck on "Loading your shelf…" forever.
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
  // arrives, so paging through Home or opening a screen never waits on the
  // network for a picture.
  const prefetchedRef = useRef(new Set());
  useEffect(() => {
    plushArtUrls(creatures).forEach((url) => {
      if (prefetchedRef.current.has(url)) return;
      prefetchedRef.current.add(url);
      Image.prefetch(url).catch(() => prefetchedRef.current.delete(url));
    });
  }, [creatures]);

  // Fires a top-banner toast the instant an achievement flips from
  // not-done to done — diffed against the previous profile snapshot rather
  // than stored server-side, since every achievement is itself derived from
  // the profile (see src/achievements.js).
  useEffect(() => {
    if (!profile || !creatures.length) return;
    const current = computeAchievements(creatures, profile, customCreatures.length);
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
  }, [profile, creatures, customCreatures.length]);

  const openToy = useCallback((creature) => setLoadingToy(creature), []);
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
  // wheel screen. The prizes (coins, gems, Stars) are paid by the server.
  const handleSpin = useCallback((bonus = false) => callFunction('spinWheel', { tzOffsetMinutes: tzOffsetMinutes(), bonus }), []);
  const handleSpinDone = useCallback(() => {
    setSpinState('done');
    setScreen('home');
  }, []);

  // --- custom creatures (the "Create your own squishy" flow) ---
  const handleOpenCreator = useCallback(() => setScreen('create'), []);
  const openAchievements = useCallback(() => setScreen('achievements'), []);
  const openStats = useCallback(() => setScreen('stats'), []);
  // the tutorial's current step (useTutorial runs further down; this ref is
  // for callbacks declared before it)
  const tutorialStepRef = useRef('done');
  // the Shop tab, on one of its own tabs
  const openShopAt = useCallback((tab = 'chests') => {
    setShopTab(tab);
    setShopKey((k) => k + 1);
    setMainTab('shop');
    setScreen('home');
  }, []);
  const openSettings = useCallback(() => setSettingsOpen(true), []);
  const closeSettings = useCallback(() => setSettingsOpen(false), []);
  const openCrib = useCallback(() => setScreen('crib'), []);

  const flashApp = useCallback((msg) => {
    setAppToast(msg);
    setAppToastKey((k) => k + 1);
    setTimeout(() => setAppToast((cur) => (cur === msg ? null : cur)), 2600);
  }, []);

  // --- progression: daily challenges, the chest, the tutorial (src/progression.js) ---
  // `n` more of a challenge event; a toast when that completes one.
  const noteDaily = useCallback(
    (ev, n = 1) => {
      if (!authUser || !profile) return;
      const done = bumpDaily(authUser.uid, profile, ev, n);
      if (done.length) flashApp(`Challenge complete: ${done[0]}`);
    },
    [authUser, profile, flashApp]
  );
  const openDaily = useCallback(() => setDailyOpen(true), []);
  const closeDaily = useCallback(() => setDailyOpen(false), []);
  // Once a day, straight after the Daily Spin (or on the first visit Home
  // that day), while a streak is alive and today's chest is still shut: the
  // streak screen, to keep it going. `streakSeen` on the profile keeps it to
  // once a day across devices; the ref covers a failed write.
  const streakOfferedDayRef = useRef(null);
  const streakIntroDue =
    !!authUser &&
    !!profile &&
    spinState === 'done' &&
    screen === 'home' &&
    !activeToy &&
    !loadingToy &&
    !tutorialActive(profile) &&
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
  const openStreak = useCallback(() => setScreen('streak'), []);
  const closeStreak = useCallback(() => {
    setStreakIntro(false);
    setScreen('home');
  }, []);
  const streakToDaily = useCallback(() => {
    setStreakIntro(false);
    setScreen('home');
    setDailyOpen(true);
  }, []);
  const handleClaimDaily = useCallback(
    (id) => {
      if (!authUser) return;
      const coins = claimDailyChallenge(authUser.uid, profile, id);
      if (coins) flashApp(`+${coins} coins!`);
    },
    [authUser, profile, flashApp]
  );
  // the daily chest: its coins here, its Stars (and a streak day's Stars or
  // Silver chest) from the server — squad dailyGift
  // (the streak day's reward: src/progression.js STREAK_REWARDS)
  const handleClaimChest = useCallback(() => {
    if (!authUser) return;
    const r = claimDailyChest(authUser.uid, profile);
    if (!r) return;
    const gift = r.reward.kind === 'stars' || r.reward.kind === 'chest' ? r.reward : null;
    squadDailyGift(gift).catch(() => {});
    const extra = r.reward.kind === 'stars' ? ` + ${5 + r.reward.amount} Stars` : r.reward.kind === 'chest' ? ' + 5 Stars + a free Silver chest' : r.reward.kind === 'half' ? ' + 5 Stars + half price on your next creation' : ' + 5 Stars';
    flashApp(`Daily chest: +${r.coins} coins${extra}!`);
  }, [authUser, profile, flashApp]);
  const dailyToCrib = useCallback(() => {
    setDailyOpen(false);
    setScreen('crib');
  }, []);
  const replayTutorial = useCallback(() => {
    if (authUser) setTutorialStep(authUser.uid, 'start');
  }, [authUser]);
  const tutorial = useTutorial({
    profile,
    creatures,
    signedIn: !!authUser && !!profile,
    setStep: useCallback((step) => authUser && setTutorialStep(authUser.uid, step), [authUser]),
    setLevel: useCallback((lv) => authUser && setLevel(authUser.uid, lv), [authUser]),
  });
  tutorialStepRef.current = tutorial.step;

  const handleCreatureCreated = useCallback(
    // Photo path: upload the resized JPEG to Storage, then write a
    // `status: 'pending'` doc — the generateCustomModel Cloud Function runs
    // Tripo from there. Assemble path: no upload, doc is born `ready`.
    // Throws on failure so CreateScreen can surface it and stay put.
    async ({ name, imageUri, build, audio, paid = false }) => {
      if (!authUser) return;
      // Captured before the writes below spend it, so the ad trigger below
      // reflects whether *this* creation was free — see ForcedInterstitialAd.
      // `paid`: bought just now. A credit bought earlier (paidCredits — the
      // creation didn't go through right after the purchase) is spent first
      // by the server, and gets no ad break either.
      const hadFreeCredit = !paid && (profile?.generationCredits ?? 1) > 0 && !(profile?.paidCredits > 0);
      const uid = authUser.uid;
      const id = newCustomCreatureId(uid);
      let sourceImageUrl = null;
      let sourceImagePath = null;
      if (imageUri) {
        const up = await uploadSourceImage(uid, imageUri, id);
        sourceImageUrl = up.url;
        sourceImagePath = up.path;
      }
      await addCustomCreature(uid, { id, name, sourceImageUrl, sourceImagePath, build, audio });
      setMineFocus({ id, token: Date.now() });
      setScreen('home');
      // Forced ad only on the house, never after a real (future) purchase,
      // and never with Remove Ads.
      if (hadFreeCredit && !profile?.adsFree) setFreeGenAdTrigger((t) => t + 1);
    },
    [authUser, profile]
  );
  const handleRetryCustom = useCallback(
    (custom) => {
      if (authUser) retryCustomCreature(authUser.uid, custom.id).catch(() => {});
    },
    [authUser]
  );
  const handleSelectCustom = useCallback((custom) => {
    // Not playable until generation finished (photo path). Assemble creatures
    // and finished photo creatures both open.
    if (custom.status && custom.status !== 'ready') return;
    setLoadingToy({
      id: `custom:${custom.id}`,
      name: custom.name,
      isCustom: true,
      image: custom.sourceImageUrl || null,
      build: custom.build || null,
      modelUrl: custom.modelUrl || null,
      audio: custom.audio || null,
    });
  }, []);
  const handleDeleteCustom = useCallback(
    (custom) => {
      if (!authUser) return;
      Alert.alert('Delete creature', `Delete ${custom.name}? This can't be undone.`, [
        { text: 'Cancel', style: 'cancel' },
        {
          text: 'Delete',
          style: 'destructive',
          onPress: () => {
            deleteCustomCreature(authUser.uid, custom.id).catch(() => {});
            deleteCustomAssets({ sourceImagePath: custom.sourceImagePath, modelPath: custom.modelPath }).catch(() => {});
          },
        },
      ]);
    },
    [authUser]
  );

  const handleLogout = useCallback(async () => {
    setActiveToy(null);
    setLoadingToy(null);
    setMainTab('squish');
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

  // Real-money purchases through Google Play / the App Store (src/billing):
  // Remove Ads, a gem pack, or a custom creation. The server grants
  // them; the profile snapshot brings the change in. Resolves with the
  // server's answer, or null if nothing was granted (yet).
  const purchase = useCallback(
    async (key, creature = null) => {
      if (!authUser || buying) return null;
      setBuying(creature ? creature.id : key);
      try {
        const r = await billing.buy(key, { uid: authUser.uid, creatureId: creature ? creature.id : '' });
        if (r.pending) flashApp('Payment pending — it arrives as soon as it clears');
        else if (r.granted === 'adsFree' || r.granted === 'restored') flashApp('Ads removed — thank you!');
        else if (r.granted === 'coins') flashApp(`Already unlocked — here are ${r.coins.toLocaleString()} coins instead`);
        else if (r.granted === 'gems') flashApp(`+${r.gems.toLocaleString()} gems${r.doubled ? ' (doubled!)' : ''}`);
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
  const buyRemoveAds = useCallback(() => purchase('removeAds'), [purchase]);
  // a creation: the half-price product while the 10-day streak's reward is
  // waiting, else the 15%-off one while the Daily Spin prize is (each is
  // used up by its own product; the half price is the better deal)
  const creationKey = profile?.streakDiscount ? 'creationHalf' : profile?.creationDiscountPct ? 'creationDiscount' : 'creation';
  const buyCreation = useCallback(async () => {
    const r = await purchase(creationKey);
    return !!r && r.granted === 'creation';
  }, [purchase, creationKey]);
  const closeRemoveAds = useCallback(() => setRemoveAdsOpen(false), []);
  // a locked creature's card: the Shop's squishies (coins, Stars or chests)
  const showUnlock = useCallback(() => openShopAt('squish', 'home'), [openShopAt]);

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

  let stage = 'splash';
  if (splashDone && authChecked) {
    if (!authUser) stage = 'auth';
    else if (spinState === 'show') stage = 'wheel';
    else if (streakIntro) stage = 'streak';
    else if (activeToy) stage = 'toy';
    else if (loadingToy) stage = 'loading';
    else stage = screen;
  }

  // --- sound (src/audio/sfx.js): each screen's music, a whoosh between
  // screens, and coins coming in or going out. The squish screen and the
  // Mystery Box play their own coin sounds.
  useEffect(() => {
    if (stage === 'crib') return;
    sfx.music(fontsLoaded ? MUSIC_FOR_STAGE[stage] : null);
  }, [stage, fontsLoaded]);
  const prevStageRef = useRef(stage);
  useEffect(() => {
    if (prevStageRef.current !== stage) sfx.play('whoosh');
    prevStageRef.current = stage;
  }, [stage]);
  // the tutorial follows the screen; it hides behind popups
  useEffect(() => {
    tutReport({ screen: stage === 'home' && mainTab === 'shop' ? 'store' : stage, busy: removeAdsOpen || dailyOpen || settingsOpen });
  }, [stage, mainTab, removeAdsOpen, dailyOpen, settingsOpen]);
  const coinsNow = profile?.coins;
  const prevCoinsRef = useRef(coinsNow);
  useEffect(() => {
    const prev = prevCoinsRef.current;
    prevCoinsRef.current = coinsNow;
    if (prev == null || coinsNow == null || prev === coinsNow || stage === 'toy' || stage === 'box') return;
    sfx.play(coinsNow > prev ? 'coinShower' : 'spend');
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [coinsNow]);
  // a sparkle when a custom creature finishes turning 3D
  const readyCustomsRef = useRef(null);
  useEffect(() => {
    const ready = new Set(customCreatures.filter((c) => c.status === 'ready').map((c) => c.id));
    const prev = readyCustomsRef.current;
    readyCustomsRef.current = ready;
    if (prev && customCreatures.some((c) => ready.has(c.id) && !prev.has(c.id) && c.sourceImageUrl)) sfx.play('sparkle');
  }, [customCreatures]);

  if (!fontsLoaded) {
    return <View style={{ flex: 1, backgroundColor: '#b24fe6' }} />;
  }

  const ownedIds = profile?.ownedIds ?? [];
  // A creation's price comes from the store: the half-price product while
  // the streak's reward waits (−50%), the 15%-off one while the Daily Spin's
  // CREATE prize, creationDiscountPct, does.
  const discountPct = profile?.streakDiscount ? 50 : profile?.creationDiscountPct ?? 0;
  const priceLabel = billing.priceLabel(creationKey, storePrices);
  const adsFree = profile?.adsFree ?? false;
  const removeAdsPrice = billing.priceLabel('removeAds', storePrices);
  const dailyNow = profile ? dailyView(profile) : null;
  // the streak screen's squishy (the one squished longest, else the first
  // owned)
  const mascot = stage === 'streak' ? streakMascot(creatures, profile) : null;
  // squish coins: the streak's +5% a day, ×10 in the tutorial's goal step
  const coinMultiplier = streakMultiplier(profile) * (tutorial.step === 'goal' ? TUTORIAL_BOOST : 1);

  // Every screen sits on the design's light sky (blue at the top), so the
  // status-bar icons are dark; the Crib's HUD is dark brown, so light there.
  const statusBarStyle = stage === 'crib' ? 'light' : 'dark';

  return (
    <SafeAreaProvider>
      <StatusBar style={statusBarStyle} />
      {stage === 'splash' && <SplashScreen onFinish={() => setSplashDone(true)} creatures={creatures} />}
      {stage === 'auth' && <AuthScreen />}
      {stage === 'home' && (
        <MainScreen
          tab={mainTab}
          onTab={setMainTab}
          adsFree={adsFree}
          squishies={
            <SquishiesScreen
              creatures={creatures}
              profile={profile}
              onPlay={openToy}
              onOpenShop={openShopAt}
              onOpenCreator={handleOpenCreator}
              createPrice={priceLabel}
              generationCredits={profile?.generationCredits ?? 1}
              paidCredits={profile?.paidCredits ?? 0}
              discountPct={discountPct}
              customCreatures={customCreatures}
              onSelectCustom={handleSelectCustom}
              onDeleteCustom={handleDeleteCustom}
              onRetryCustom={handleRetryCustom}
              focusMine={mineFocus}
              onFocusMineDone={clearMineFocus}
              level={levelOf(profile)}
              cribUnlocked={cribUnlocked(profile)}
              onOpenCrib={openCrib}
              onOpenAchievements={openAchievements}
              onOpenSettings={openSettings}
              onOpenStats={openStats}
              dailyUnlocked={dailyIsUnlocked(profile)}
              dailyBadge={dailyNow ? dailyNow.claimable : 0}
              onOpenDaily={openDaily}
              streak={streakOf(profile)}
              streakHot={!!dailyNow && dailyNow.streak > 0 && !dailyNow.chestDone}
              onOpenStreak={openStreak}
            />
          }
          renderShop={(onImmersive) => (
            <ShopScreen
              key={shopKey}
              startTab={shopTab}
              creatures={creatures}
              profile={profile}
              onBuyProduct={purchase}
              priceOf={(key) => billing.priceLabel(key, storePrices)}
              onImmersive={onImmersive}
            />
          )}
        />
      )}
      {stage === 'crib' && (
        <CribScreen
          authUser={authUser}
          profile={profile}
          creatures={creatures}
          onBack={() => setScreen('home')}
          noteDaily={noteDaily}
          daily={{ unlocked: dailyIsUnlocked(profile), badge: dailyNow ? dailyNow.claimable : 0, onClaim: handleClaimDaily, onClaimChest: handleClaimChest }}
          tutorialStep={tutorial.step}
          onTutorialAction={tutorial.onAction}
        />
      )}
      {stage === 'wheel' && (
        <DailySpinScreen
          onSpin={handleSpin}
          onDone={handleSpinDone}
          bonusLeft={adSpinsLeft(profile)}
          adsFree={profile?.adsFree ?? false}
          name={profile?.nickname}
          creatures={creatures}
        />
      )}
      {stage === 'streak' && (
        <StreakScreen profile={profile} mascot={mascot} intro={streakIntro} onClose={closeStreak} onOpenDaily={streakToDaily} />
      )}
      {stage === 'create' && (
        <CreateScreen
          onBack={() => setScreen('home')}
          onCreated={handleCreatureCreated}
          generationCredits={profile?.generationCredits ?? 1}
          paidCredits={profile?.paidCredits ?? 0}
          priceLabel={priceLabel}
          discountPct={discountPct}
          onBuyCreation={buyCreation}
          buying={buying === 'creation' || buying === 'creationDiscount' || buying === 'creationHalf'}
        />
      )}
      {stage === 'achievements' && (
        <AchievementsScreen creatures={creatures} profile={profile} customCount={customCreatures.length} onBack={() => setScreen('home')} />
      )}
      {stage === 'stats' && (
        <StatsScreen creatures={creatures} customCreatures={customCreatures} profile={profile} onBack={() => setScreen('home')} />
      )}
      {stage === 'loading' && <LoadingScreen creature={loadingToy} onFinish={finishLoadingToy} />}
      {stage === 'toy' && activeToy && (
        <SquishScreen
          toy={activeToy}
          coins={profile?.coins ?? 0}
          onBack={backToHome}
          onEarnCoins={handleEarnCoins}
          onRecordPress={handleRecordPress}
          achievements={profile?.achievements ?? {}}
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
          hideHints={tutorial.step !== 'done'}
        />
      )}
      {authUser ? (
        <>
          <SettingsSheet
            visible={settingsOpen}
            onClose={closeSettings}
            nickname={profile?.nickname ?? 'Squisher'}
            onSaveNickname={handleSaveNickname}
            onSubmitFeedback={handleSubmitFeedback}
            onLogout={handleLogout}
            onReplayTutorial={replayTutorial}
          />
          <RemoveAdsSheet visible={removeAdsOpen} adsFree={adsFree} price={removeAdsPrice} buying={buying === 'removeAds'} onBuy={buyRemoveAds} onClose={closeRemoveAds} />
          <DailyChallengesSheet visible={dailyOpen} profile={profile} onClose={closeDaily} onClaim={handleClaimDaily} onClaimChest={handleClaimChest} onOpenCrib={dailyToCrib} />
        </>
      ) : null}
      {/* above the ad strip and the Mystery Box banner */}
      {/* (turned with the Crib while it's landscape, so they come from its top) */}
      <TurnWithCrib>
        <View pointerEvents="none" style={APP_TOAST_AT}>
          <Toast message={appToast} messageKey={appToastKey} />
        </View>
        <AchievementToast title={achToast} messageKey={achToastKey} />
      </TurnWithCrib>
      <ForcedInterstitialAd trigger={freeGenAdTrigger} />
      {/* the guided tutorial's coach marks, over everything */}
      <TutorialGuide onAction={tutorial.onAction} />
    </SafeAreaProvider>
  );
}
