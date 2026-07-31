import React, { useCallback, useEffect, useState } from 'react';
import { Alert } from 'react-native';
import { StatusBar } from 'expo-status-bar';
import { SafeAreaProvider } from 'react-native-safe-area-context';
import mobileAds from 'react-native-google-mobile-ads';
import SplashScreen from './src/screens/SplashScreen';
import LoginScreen from './src/screens/LoginScreen';
import RegisterScreen from './src/screens/RegisterScreen';
import HomeScreen from './src/screens/HomeScreen';
import SquishScreen from './src/screens/SquishScreen';
import { subscribeToAuthUser, logout } from './src/firebase/auth';
import {
  subscribeToUserProfile,
  subscribeToCreatures,
  addCoins,
  purchaseCreature,
} from './src/firebase/firestore';
import { ensureCreaturesSeeded } from './src/firebase/seedCreatures';

mobileAds()
  .initialize()
  .catch(() => {});

export default function App() {
  const [splashDone, setSplashDone] = useState(false);
  const [authChecked, setAuthChecked] = useState(false);
  const [authUser, setAuthUser] = useState(null);
  const [authScreen, setAuthScreen] = useState('login'); // 'login' | 'register'
  const [profile, setProfile] = useState(null);
  const [creatures, setCreatures] = useState([]);
  const [homeIndex, setHomeIndex] = useState(0);
  const [activeToy, setActiveToy] = useState(null);

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
    return subscribeToCreatures(setCreatures);
  }, []);

  const openToy = useCallback((creature) => setActiveToy(creature), []);
  const backToHome = useCallback(() => setActiveToy(null), []);

  const handleLogout = useCallback(async () => {
    setActiveToy(null);
    setHomeIndex(0);
    setAuthScreen('login');
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

  let stage = 'splash';
  if (splashDone && authChecked) {
    if (!authUser) stage = authScreen;
    else if (activeToy) stage = 'toy';
    else stage = 'home';
  }

  return (
    <SafeAreaProvider>
      <StatusBar style="dark" />
      {stage === 'splash' && <SplashScreen onFinish={() => setSplashDone(true)} />}
      {stage === 'login' && <LoginScreen onSwitchToRegister={() => setAuthScreen('register')} />}
      {stage === 'register' && <RegisterScreen onSwitchToLogin={() => setAuthScreen('login')} />}
      {stage === 'home' && (
        <HomeScreen
          creatures={creatures}
          ownedIds={profile?.ownedIds ?? ['buddy']}
          coins={profile?.coins ?? 0}
          index={homeIndex}
          onChangeIndex={setHomeIndex}
          onSelectToy={openToy}
          onPurchase={handlePurchase}
          onLogout={handleLogout}
        />
      )}
      {stage === 'toy' && activeToy && (
        <SquishScreen toy={activeToy} coins={profile?.coins ?? 0} onBack={backToHome} onEarnCoins={handleEarnCoins} />
      )}
    </SafeAreaProvider>
  );
}
