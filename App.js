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
import HomeScreen from './src/screens/HomeScreen';
import AchievementsScreen from './src/screens/AchievementsScreen';
import StatsScreen from './src/screens/StatsScreen';
import StoreScreen from './src/screens/StoreScreen';
import MysteryBoxScreen from './src/screens/MysteryBoxScreen';
import DailySpinScreen from './src/screens/DailySpinScreen';
import CreatureReelScreen from './src/screens/CreatureReelScreen';
import LoadingScreen from './src/screens/LoadingScreen';
import SquishScreen from './src/screens/SquishScreen';
import AchievementToast from './src/components/squad/AchievementToast';
import Toast from './src/components/squad/Toast';
import UnlockSheet from './src/components/UnlockSheet';
import { RemoveAdsSheet } from './src/components/RemoveAds';
import ForcedInterstitialAd from './src/components/ForcedInterstitialAd';
import { computeAchievements } from './src/achievements';
import { subscribeToAuthUser, logout } from './src/firebase/auth';
import {
  subscribeToUserProfile,
  subscribeToCreatures,
  subscribeToBoxConfig,
  addCoins,
  unlockWithKey,
  recordPress,
  markAchievement,
  recordAdWatched,
  payBoxWithAd,
  payBoxWithCoins,
  openBox,
  updateNickname,
  submitFeedback,
  ensureStarterCreaturesOwned,
  subscribeToCustomCreatures,
  addCustomCreature,
  deleteCustomCreature,
  retryCustomCreature,
  newCustomCreatureId,
} from './src/firebase/firestore';
import { uploadSourceImage, deleteCustomAssets } from './src/firebase/storage';
import { loadCachedCreatures, saveCreaturesToCache } from './src/data/creatureCache';
import CreateScreen from './src/screens/CreateScreen';
import { plushArtUrls } from './src/components/CreatureThumbnail';
import { boxPayMode, boxPriceLabel, ownedCount, boxRoster } from './src/mysteryBox';
import * as billing from './src/billing';
import { setBoxSettings } from './src/economy';
import { hasSpunToday, todayKey, tzOffsetMinutes } from './src/dailySpin';
import callFunction from './src/firebase/callFunction';
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
const NO_TOKENS = {};
const APP_TOAST_AT = { position: 'absolute', left: 0, right: 0, bottom: 150, height: 0, zIndex: 70, elevation: 70 };

const MUSIC_FOR_STAGE = {
  splash: 'dream',
  auth: 'dream',
  wheel: 'party',
  reel: 'party',
  home: 'cozy',
  store: 'cozy',
  achievements: 'cozy',
  stats: 'cozy',
  create: 'cozy',
  loading: 'calm',
  toy: 'calm',
  box: 'mystery',
};

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
  const [mineFocusToken, setMineFocusToken] = useState(0);
  // Which OUR CREATURES card Home shows — a ref, not state: Home owns its
  // paging and only reports back so it can reopen on the same card after a
  // squish session. Keeping it out of state means paging never re-renders
  // the whole app.
  const homeIndexRef = useRef(0);
  const setHomeIndex = useCallback((i) => {
    homeIndexRef.current = i;
  }, []);
  const [screen, setScreen] = useState('home'); // 'home' | 'achievements' | 'stats' | 'store' | 'create' | 'box' — only relevant once signed in
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
  // Squish-screen settings popup: FPS pill, poke strength (1-5, 3 = the
  // tuned default depth) and poke direction (push in / pop out).
  const [showFps, setShowFps] = useState(true);
  const [pokeStrength, setPokeStrength] = useState(3);
  const [pokeOutward, setPokeOutward] = useState(false);

  // Daily Spin: 'unknown' until the profile loads, then 'show' (today's spin
  // is waiting — it comes before Home) or 'done'. `reel` holds a FREE
  // creature prize while its reel plays.
  const [spinState, setSpinState] = useState('unknown');
  const [reel, setReel] = useState(null);
  const [spinAdTrigger, setSpinAdTrigger] = useState(0);

  // Unlocking and purchases: which locked creature's popup is open
  // (UnlockSheet), the creature the Key Shop should open on, the Remove Ads
  // popup, what's being bought right now ('removeAds' or a creature id),
  // Google Play's prices, and a toast for how a purchase went.
  const [unlockForId, setUnlockForId] = useState(null);
  const [storeFocusId, setStoreFocusId] = useState(null);
  const [removeAdsOpen, setRemoveAdsOpen] = useState(false);
  const [buying, setBuying] = useState(null);
  const [storePrices, setStorePrices] = useState({});
  const [appToast, setAppToast] = useState(null);
  const [appToastKey, setAppToastKey] = useState(0);

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
    const offer = !spunToday && spinOfferedDayRef.current !== today;
    if (offer) spinOfferedDayRef.current = today;
    setSpinState(offer ? 'show' : 'done');
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

  // The Mystery Box numbers from config/mysteryBox (src/economy.js falls back
  // to BOX_DEFAULTS); a re-render picks them up.
  const [boxConfigVersion, setBoxConfigVersion] = useState(0);
  useEffect(() => {
    if (!authUser) return undefined;
    return subscribeToBoxConfig((doc) => {
      setBoxSettings(doc);
      setBoxConfigVersion((v) => v + 1);
    });
  }, [authUser]);

  // In-app purchases (src/billing): Google Play's prices, and any purchase
  // not yet granted (or Remove Ads bought on another phone) sent to the
  // server once signed in.
  useEffect(() => billing.subscribePrices(setStorePrices), []);
  useEffect(() => {
    if (!authUser) return;
    billing.loadProducts().then(() => billing.syncPurchases());
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
    loadCachedCreatures().then(setCreatures);
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
  const handleSpin = useCallback(() => callFunction('spinWheel', { tzOffsetMinutes: tzOffsetMinutes() }), []);
  const handleSpinClaim = useCallback(
    (result) => {
      setSpinState('done');
      if (result.kind === 'unlock' && result.creatureId) {
        // the ad break waits until the reel is done (handleReelDone)
        setReel({ lockedIds: result.lockedIds || [], winnerId: result.creatureId });
        setScreen('home');
        return;
      }
      // the design's "Thanks for spinning!" ad break
      if (!profile?.adsFree) setSpinAdTrigger((t) => t + 1);
      setScreen(result.kind === 'create' ? 'create' : 'home');
    },
    [profile?.adsFree]
  );
  const handleSpinSkip = useCallback(() => setSpinState('done'), []);
  const handleReelDone = useCallback(
    (creatureId) => {
      const i = creatures.findIndex((c) => c.id === creatureId);
      if (i >= 0) homeIndexRef.current = i;
      setReel(null);
      setScreen('home');
      if (!profile?.adsFree) setSpinAdTrigger((t) => t + 1);
    },
    [creatures, profile?.adsFree]
  );

  // --- custom creatures (the "Create your own squishy" flow) ---
  const handleOpenCreator = useCallback(() => setScreen('create'), []);
  const openAchievements = useCallback(() => setScreen('achievements'), []);
  const openStats = useCallback(() => setScreen('stats'), []);
  const openStore = useCallback(() => {
    setStoreFocusId(null);
    setScreen('store');
  }, []);
  const openBoxScreen = useCallback(() => setScreen('box'), []);

  // --- Mystery Box (src/mysteryBox.js) ---
  const handleOpenBox = useCallback((pull, paidAhead) => (authUser ? openBox(authUser.uid, profile, pull, paidAhead) : false), [authUser, profile]);
  // A daily box's video was watched: count the ad and pay for the box.
  const handleVideoBoxWatched = useCallback(() => {
    if (!authUser) return;
    recordAdWatched(authUser.uid, 0).catch(() => {});
    payBoxWithAd(authUser.uid, profile);
  }, [authUser, profile]);
  const handlePayBoxCoins = useCallback(() => (authUser ? payBoxWithCoins(authUser.uid, profile) : false), [authUser, profile]);
  // SQUISH IT: straight to the creature that came out of the box.
  const handleSquishFromBox = useCallback(
    (creatureId) => {
      const i = creatures.findIndex((c) => c.id === creatureId);
      if (i >= 0) {
        homeIndexRef.current = i;
        setScreen('home');
        setLoadingToy(creatures[i]);
      }
    },
    [creatures]
  );
  const handleCreatureCreated = useCallback(
    // Photo path: upload the resized JPEG to Storage, then write a
    // `status: 'pending'` doc — the generateCustomModel Cloud Function runs
    // Tripo from there. Assemble path: no upload, doc is born `ready`.
    // Throws on failure so CreateScreen can surface it and stay put.
    async ({ name, imageUri, build, audio, paid = false }) => {
      if (!authUser) return;
      // Captured before the writes below spend it, so the ad trigger below
      // reflects whether *this* creation was free — see ForcedInterstitialAd.
      // `paid`: bought just now (the credit it uses isn't a free one).
      const hadFreeCredit = !paid && (profile?.generationCredits ?? 1) > 0;
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
      setMineFocusToken((t) => t + 1);
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
    setHomeIndex(0);
    setScreen('home');
    await logout();
  }, []);

  const handleEarnCoins = useCallback(
    (amount) => {
      if (!authUser) return;
      addCoins(authUser.uid, amount).catch(() => {});
    },
    [authUser]
  );

  const flashApp = useCallback((msg) => {
    setAppToast(msg);
    setAppToastKey((k) => k + 1);
    setTimeout(() => setAppToast((cur) => (cur === msg ? null : cur)), 2600);
  }, []);

  // Real-money purchases through Google Play / the App Store (src/billing):
  // Remove Ads, a creature's key, or a custom creation. The server grants
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
        else if (r.granted === 'key') flashApp(`The ${creature ? creature.name : ''} key is ready — hold the card to unlock!`);
        else if (r.granted === 'coins') flashApp(`Already unlocked — here are ${r.coins.toLocaleString()} coins instead`);
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
  const handleBuyNow = useCallback((creature) => purchase('creatureKey', creature), [purchase]);
  const buyRemoveAds = useCallback(() => purchase('removeAds'), [purchase]);
  // a creation: the 15%-off product while the Daily Spin prize is waiting
  const creationKey = profile?.creationDiscountPct ? 'creationDiscount' : 'creation';
  const buyCreation = useCallback(async () => {
    const r = await purchase(creationKey);
    return !!r && r.granted === 'creation';
  }, [purchase, creationKey]);
  const openRemoveAds = useCallback(() => setRemoveAdsOpen(true), []);
  const closeRemoveAds = useCallback(() => setRemoveAdsOpen(false), []);
  const showUnlock = useCallback((creatureOrId) => setUnlockForId(typeof creatureOrId === 'string' ? creatureOrId : creatureOrId?.id ?? null), []);
  const closeUnlock = useCallback(() => setUnlockForId(null), []);
  // from a box reveal: the Key Shop on that creature's row, or its Home
  // card when its tokens just filled (hold it to unlock)
  const boxOpenShop = useCallback((creatureId = null) => {
    setStoreFocusId(creatureId);
    setScreen('store');
  }, []);
  const boxUnlockIt = useCallback(
    (creatureId) => {
      const i = creatures.findIndex((c) => c.id === creatureId);
      if (i >= 0) homeIndexRef.current = i;
      setScreen('home');
    },
    [creatures]
  );
  // the popup's SHOP button: the Key Shop, on this creature's row
  const unlockOpenShop = useCallback((creature) => {
    setUnlockForId(null);
    setStoreFocusId(creature.id);
    setScreen('store');
  }, []);

  const handleUnlockWithKey = useCallback(
    (creatureId) => {
      if (!authUser) return;
      unlockWithKey(authUser.uid, creatureId).catch(() => {});
    },
    [authUser]
  );

  const handleRecordPress = useCallback(
    (creatureId, holdMs) => {
      if (!authUser) return;
      recordPress(authUser.uid, creatureId, holdMs).catch(() => {});
    },
    [authUser]
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
    },
    [authUser, profile?.maxMult, profile?.adsFree]
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
    else if (reel) stage = 'reel';
    else if (activeToy) stage = 'toy';
    else if (loadingToy) stage = 'loading';
    else stage = screen;
  }

  // --- sound (src/audio/sfx.js): each screen's music, a whoosh between
  // screens, and coins coming in or going out. The squish screen and the
  // Mystery Box play their own coin sounds.
  useEffect(() => {
    sfx.music(fontsLoaded ? MUSIC_FOR_STAGE[stage] : null);
  }, [stage, fontsLoaded]);
  const prevStageRef = useRef(stage);
  useEffect(() => {
    if (prevStageRef.current !== stage) sfx.play('whoosh');
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
  const keys = profile?.keys ?? {};
  // back to today's flat rate until that doc exists — see firestore.rules.
  // A Daily Spin CREATE prize takes creationDiscountPct (15) off it.
  // A creation's price comes from the store (the 15%-off product while the
  // Daily Spin's CREATE prize, creationDiscountPct, is waiting).
  const discountPct = profile?.creationDiscountPct ?? 0;
  const priceLabel = billing.priceLabel(creationKey, storePrices);
  const boxMode = boxPayMode(profile);
  const adsFree = profile?.adsFree ?? false;
  const removeAdsPrice = billing.priceLabel('removeAds', storePrices);
  const creatureKeyPrice = billing.priceLabel('creatureKey', storePrices);
  const unlockCreature = unlockForId && !ownedIds.includes(unlockForId) ? creatures.find((c) => c.id === unlockForId) : null;
  const boxLabel = `${ownedCount(creatures, ownedIds)}/${boxRoster(creatures).length || 20} · ${profile?.secretFound ? 'SECRET FOUND' : 'A SECRET AWAITS'}`;

  // Every screen sits on the v3 candy stage (pink at the top), where light
  // status-bar icons still read clearly.
  const statusBarStyle = 'light';

  return (
    <SafeAreaProvider>
      <StatusBar style={statusBarStyle} />
      {stage === 'splash' && <SplashScreen onFinish={() => setSplashDone(true)} ownedIds={ownedIds} creatures={creatures} />}
      {stage === 'auth' && <AuthScreen />}
      {stage === 'home' && (
        <HomeScreen
          creatures={creatures}
          ownedIds={ownedIds}
          keys={keys}
          coins={profile?.coins ?? 0}
          index={homeIndexRef.current}
          onChangeIndex={setHomeIndex}
          onSelectToy={openToy}
          onUnlockWithKey={handleUnlockWithKey}
          tokens={profile?.tokens ?? NO_TOKENS}
          boxConfigVersion={boxConfigVersion}
          onShowUnlock={showUnlock}
          nickname={profile?.nickname ?? 'Squisher'}
          onSaveNickname={handleSaveNickname}
          adsFree={adsFree}
          removeAdsPrice={removeAdsPrice}
          onOpenRemoveAds={openRemoveAds}
          onSubmitFeedback={handleSubmitFeedback}
          onLogout={handleLogout}
          onOpenAchievements={openAchievements}
          onOpenStats={openStats}
          onOpenStore={openStore}
          customCreatures={customCreatures}
          onOpenCreator={handleOpenCreator}
          onSelectCustom={handleSelectCustom}
          onDeleteCustom={handleDeleteCustom}
          onRetryCustom={handleRetryCustom}
          focusMineToken={mineFocusToken}
          generationCredits={profile?.generationCredits ?? 1}
          priceLabel={priceLabel}
          discountPct={discountPct}
          boxLabel={boxLabel}
          boxPrice={boxPriceLabel(boxMode)}
          boxVideos={boxMode === 'ad' ? 1 : 0}
          boxCoins={boxMode === 'coins'}
          onOpenBox={openBoxScreen}
        />
      )}
      {stage === 'wheel' && <DailySpinScreen onSpin={handleSpin} onClaim={handleSpinClaim} onSkip={handleSpinSkip} />}
      {stage === 'reel' && reel && <CreatureReelScreen creatures={creatures} lockedIds={reel.lockedIds} winnerId={reel.winnerId} onDone={handleReelDone} />}
      {stage === 'box' && (
        <MysteryBoxScreen
          profile={profile}
          creatures={creatures}
          onBack={() => setScreen('home')}
          onOpen={handleOpenBox}
          onVideoBoxWatched={handleVideoBoxWatched}
          onPayCoins={handlePayBoxCoins}
          onSquish={handleSquishFromBox}
          onOpenShop={boxOpenShop}
          onUnlockIt={boxUnlockIt}
        />
      )}
      {stage === 'create' && (
        <CreateScreen
          onBack={() => setScreen('home')}
          onCreated={handleCreatureCreated}
          generationCredits={profile?.generationCredits ?? 1}
          priceLabel={priceLabel}
          discountPct={discountPct}
          onBuyCreation={buyCreation}
          buying={buying === 'creation' || buying === 'creationDiscount'}
        />
      )}
      {stage === 'achievements' && (
        <AchievementsScreen creatures={creatures} profile={profile} customCount={customCreatures.length} onBack={() => setScreen('home')} />
      )}
      {stage === 'stats' && (
        <StatsScreen creatures={creatures} customCreatures={customCreatures} profile={profile} onBack={() => setScreen('home')} />
      )}
      {stage === 'store' && (
        <StoreScreen
          creatures={creatures}
          profile={profile}
          onBuyNow={handleBuyNow}
          moneyPrice={creatureKeyPrice}
          buyingId={buying}
          focusId={storeFocusId}
          onBack={() => setScreen('home')}
        />
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
        />
      )}
      {authUser ? (
        <>
          <UnlockSheet creature={unlockCreature} profile={profile} moneyPrice={creatureKeyPrice} onClose={closeUnlock} onOpenShop={unlockOpenShop} />
          <RemoveAdsSheet visible={removeAdsOpen} adsFree={adsFree} price={removeAdsPrice} buying={buying === 'removeAds'} onBuy={buyRemoveAds} onClose={closeRemoveAds} />
        </>
      ) : null}
      {/* above the ad strip and the Mystery Box banner */}
      <View pointerEvents="none" style={APP_TOAST_AT}>
        <Toast message={appToast} messageKey={appToastKey} />
      </View>
      <AchievementToast title={achToast} messageKey={achToastKey} />
      <ForcedInterstitialAd trigger={freeGenAdTrigger} />
      <ForcedInterstitialAd trigger={spinAdTrigger} />
    </SafeAreaProvider>
  );
}
