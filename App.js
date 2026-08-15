// Must load before anything that touches GLTFLoader (see SquishyToy.js's
// Cloude build path) — Hermes doesn't provide TextDecoder/TextEncoder,
// which GLTFLoader needs to decode a GLB's embedded JSON chunk. Has to be
// the first import in the app's entry file so its global.TextDecoder/
// TextEncoder polyfill is in place before any other module (transitively
// including SquishyToy.js) gets evaluated.
import 'fast-text-encoding';
import React, { useCallback, useEffect, useRef, useState } from 'react';
import { View, Alert } from 'react-native';
import { StatusBar } from 'expo-status-bar';
import { SafeAreaProvider } from 'react-native-safe-area-context';
import mobileAds from 'react-native-google-mobile-ads';
import { useFonts } from 'expo-font';
import { Baloo2_500Medium, Baloo2_700Bold, Baloo2_800ExtraBold } from '@expo-google-fonts/baloo-2';
import { Nunito_400Regular, Nunito_600SemiBold, Nunito_700Bold, Nunito_800ExtraBold } from '@expo-google-fonts/nunito';
import SplashScreen from './src/screens/SplashScreen';
import AuthScreen from './src/screens/AuthScreen';
import HomeScreen from './src/screens/HomeScreen';
import AchievementsScreen from './src/screens/AchievementsScreen';
import StoreScreen from './src/screens/StoreScreen';
import LoadingScreen from './src/screens/LoadingScreen';
import SquishScreen from './src/screens/SquishScreen';
import AchievementToast from './src/components/squad/AchievementToast';
import { squadColors } from './src/theme/squadTheme';
import { computeAchievements } from './src/achievements';
import { subscribeToAuthUser, logout } from './src/firebase/auth';
import {
  subscribeToUserProfile,
  subscribeToCreatures,
  addCoins,
  purchaseCreature,
  updateNickname,
  claimAdsFree,
  submitFeedback,
} from './src/firebase/firestore';
import { ensureCreaturesSeeded, DEFAULT_CREATURES } from './src/firebase/seedCreatures';

// GLTFParser's constructor (three.js, used by SquishyToy.js's Cloude build
// path) sniffs navigator.userAgent to work around known Safari ImageBitmap
// bugs (`userAgent.match(/Version\/(\d+)/)`). React Native's global
// `navigator` exists but has no `userAgent` string, so that call throws
// "Cannot read property 'match' of undefined" before parsing even gets to
// Cloude's own mesh/texture data. A harmless placeholder string is enough
// — the Safari-specific branch it's used for is a no-op on a value that
// isn't actually Safari's UA anyway. Runs once here at app start, well
// before any screen can trigger a GLTF load.
if (typeof navigator !== 'undefined' && typeof navigator.userAgent === 'undefined') {
  navigator.userAgent = 'ReactNative';
}

mobileAds()
  .initialize()
  .catch(() => {});

export default function App() {
  const [fontsLoaded] = useFonts({
    Baloo2_500Medium,
    Baloo2_700Bold,
    Baloo2_800ExtraBold,
    Nunito_400Regular,
    Nunito_600SemiBold,
    Nunito_700Bold,
    Nunito_800ExtraBold,
  });

  const [splashDone, setSplashDone] = useState(false);
  const [authChecked, setAuthChecked] = useState(false);
  const [authUser, setAuthUser] = useState(null);
  const [profile, setProfile] = useState(null);
  const [creatures, setCreatures] = useState([]);
  const [homeIndex, setHomeIndex] = useState(0);
  const [screen, setScreen] = useState('home'); // 'home' | 'achievements' | 'store' — only relevant once signed in
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
    ensureCreaturesSeeded().catch(() => {});
    // Firestore may still hold retired creatures, or stale field values for
    // ones that still exist (e.g. an old color list), from earlier in
    // development — client-side updates/deletes are both blocked by
    // firestore.rules (see src/firebase/seedCreatures.js), so the fetched
    // list is filtered down to creatures still in DEFAULT_CREATURES and
    // each one's fields are overridden with that current definition rather
    // than trusted as-is from the database.
    const knownCreatures = new Map(DEFAULT_CREATURES.map((c) => [c.id, c]));
    return subscribeToCreatures((list) =>
      setCreatures(
        list.filter((c) => knownCreatures.has(c.id)).map((c) => ({ ...c, ...knownCreatures.get(c.id) }))
      )
    );
  }, []);

  // Fires a top-banner toast the instant an achievement flips from
  // not-done to done — diffed against the previous profile snapshot rather
  // than stored server-side, since every achievement here is itself derived
  // from ownedIds/totalEarned (see src/achievements.js).
  useEffect(() => {
    if (!profile || !creatures.length) return;
    const current = computeAchievements(creatures, profile.ownedIds ?? [], profile.totalEarned ?? 0);
    const prev = prevAchievementsRef.current;
    if (prev) {
      const newlyDone = current.find((entry) => entry.done && !prev[entry.key]);
      if (newlyDone) {
        setAchToast(newlyDone.title);
        setAchToastKey((k) => k + 1);
      }
    }
    prevAchievementsRef.current = Object.fromEntries(current.map((entry) => [entry.key, entry.done]));
  }, [profile, creatures]);

  const openToy = useCallback((creature) => setLoadingToy(creature), []);
  const finishLoadingToy = useCallback(() => {
    setActiveToy(loadingToy);
    setLoadingToy(null);
  }, [loadingToy]);
  const backToHome = useCallback(() => {
    setActiveToy(null);
    setScreen('home');
  }, []);

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

  const handlePurchase = useCallback(
    async (creature) => {
      if (!authUser) return;
      try {
        const result = await purchaseCreature(authUser.uid, creature.id, creature.price ?? 0);
        if (!result.ok) {
          Alert.alert('Not enough coins', `You need ${creature.price}⊙ to unlock ${creature.name}.`);
        }
      } catch (e) {
        Alert.alert('Something went wrong', 'Could not complete the purchase — try again.');
      }
    },
    [authUser]
  );

  const handleSaveNickname = useCallback(
    (nickname) => {
      if (!authUser) return;
      updateNickname(authUser.uid, nickname).catch(() => {});
    },
    [authUser]
  );

  const handleClaimAdsFree = useCallback(() => {
    if (!authUser) return;
    claimAdsFree(authUser.uid).catch(() => {});
  }, [authUser]);

  const handleSubmitFeedback = useCallback(
    (text) => {
      if (!authUser) return;
      submitFeedback(authUser.uid, text).catch(() => {});
    },
    [authUser]
  );

  if (!fontsLoaded) {
    return <View style={{ flex: 1, backgroundColor: squadColors.bgDeepest }} />;
  }

  const ownedIds = profile?.ownedIds ?? [];

  let stage = 'splash';
  if (splashDone && authChecked) {
    if (!authUser) stage = 'auth';
    else if (activeToy) stage = 'toy';
    else if (loadingToy) stage = 'loading';
    else stage = screen;
  }

  // SquishScreen (and its light card-list styling) is intentionally
  // untouched by the dark "Squish Squad" restyle, so it still needs the
  // dark status-bar icons the rest of the app moved away from.
  const statusBarStyle = stage === 'toy' ? 'dark' : 'light';

  return (
    <SafeAreaProvider>
      <StatusBar style={statusBarStyle} />
      {stage === 'splash' && (
        <SplashScreen onFinish={() => setSplashDone(true)} creatures={creatures} ownedIds={ownedIds} />
      )}
      {stage === 'auth' && <AuthScreen />}
      {stage === 'home' && (
        <HomeScreen
          creatures={creatures}
          ownedIds={profile?.ownedIds ?? ['buddy']}
          coins={profile?.coins ?? 0}
          index={homeIndex}
          onChangeIndex={setHomeIndex}
          onSelectToy={openToy}
          onPurchase={handlePurchase}
          nickname={profile?.nickname ?? 'Squisher'}
          onSaveNickname={handleSaveNickname}
          adsFree={profile?.adsFree ?? false}
          onClaimAdsFree={handleClaimAdsFree}
          totalEarned={profile?.totalEarned ?? 0}
          onSubmitFeedback={handleSubmitFeedback}
          onLogout={handleLogout}
          onOpenAchievements={() => setScreen('achievements')}
          onOpenStore={() => setScreen('store')}
        />
      )}
      {stage === 'achievements' && (
        <AchievementsScreen
          creatures={creatures}
          ownedIds={ownedIds}
          totalEarned={profile?.totalEarned ?? 0}
          onBack={() => setScreen('home')}
        />
      )}
      {stage === 'store' && (
        <StoreScreen
          creatures={creatures}
          ownedIds={ownedIds}
          coins={profile?.coins ?? 0}
          onPurchase={handlePurchase}
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
          squishSoundEnabled={squishSoundEnabled}
          onToggleSquishSound={setSquishSoundEnabled}
          coinSoundEnabled={coinSoundEnabled}
          onToggleCoinSound={setCoinSoundEnabled}
          releaseSoundEnabled={releaseSoundEnabled}
          onToggleReleaseSound={setReleaseSoundEnabled}
        />
      )}
      <AchievementToast title={achToast} messageKey={achToastKey} />
    </SafeAreaProvider>
  );
}
