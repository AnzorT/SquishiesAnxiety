// Web only: the demo build (tools/web/demo.mjs, EXPO_PUBLIC_DEMO=1), to try Squish Stack and Squish Hop from a link
// with no account. In that build metro.config.js puts this in place of App.js, and the games' saves and server moves
// in place of Firebase's (src/web/demo/store.js, api.js): the profile lives in the page, starting with every level
// open and some gems for Blitz's saves, and a reload starts over. The squishies are the bundled cut-outs
// (src/stack/art.js), standing in for the roster from Firestore. Ads are the web version's pretend ones.
import React, { useEffect, useMemo, useState } from 'react';
import { StyleSheet, Text, View } from 'react-native';
import { SafeAreaProvider } from 'react-native-safe-area-context';
import { useFonts } from 'expo-font';
import { Asset } from 'expo-asset';
// (each weight on its own: the packages' index would bundle every weight)
import { Baloo2_500Medium } from '@expo-google-fonts/baloo-2/500Medium';
import { Baloo2_700Bold } from '@expo-google-fonts/baloo-2/700Bold';
import { Baloo2_800ExtraBold } from '@expo-google-fonts/baloo-2/800ExtraBold';
import { Nunito_400Regular } from '@expo-google-fonts/nunito/400Regular';
import { Nunito_600SemiBold } from '@expo-google-fonts/nunito/600SemiBold';
import { Nunito_700Bold } from '@expo-google-fonts/nunito/700Bold';
import { Nunito_800ExtraBold } from '@expo-google-fonts/nunito/800ExtraBold';
import { Nunito_900Black } from '@expo-google-fonts/nunito/900Black';
import { Fredoka_500Medium } from '@expo-google-fonts/fredoka/500Medium';
import { Fredoka_600SemiBold } from '@expo-google-fonts/fredoka/600SemiBold';
import { Fredoka_700Bold } from '@expo-google-fonts/fredoka/700Bold';
import { GameBackground } from '../royal/GameFrame';
import { HubTitle, ModePanel } from '../squishdoku/Hub';
import { F, INK } from '../squishdoku/theme';
import StackScreen from '../screens/StackScreen';
import HopScreen from '../screens/HopScreen';
import { BY_ID } from '../squad/data';
import STACK_ART from '../stack/art';
import { record as stackRecord } from '../stack/levels';
import { record as hopRecord } from '../hop/levels';
import { demoProfile, setDemoProfile, subscribeDemo } from './demo/store';
import { DEMO_KEYS } from './demo/cast';

// the demo's squishies (demo/cast.js), as the roster from Firestore gives them ({ id, thumb: { url } })
const CREATURES = DEMO_KEYS.map((key) => Object.entries(BY_ID).find(([, d]) => d.key === key))
  .filter(Boolean)
  .map(([id, d]) => ({ id, thumb: { url: Asset.fromModule(STACK_ART[d.key].src).uri } }));

// the demo player: owns a few squishies (the hopper is the first), every level open, gems for Blitz's saves
setDemoProfile({
  gems: 200,
  coins: 0,
  pxp: 0,
  ownedIds: CREATURES.slice(0, 6).map((c) => c.id),
  stack: { lv: 50 },
  hop: { lv: 100 },
});

const PICS = { stack: require('../../assets/stack/mode-regular.jpg'), hop: require('../../assets/hop/mode-regular.jpg') };

function Picker({ profile, onPick }) {
  const stk = stackRecord(profile);
  const hop = hopRecord(profile);
  return (
    <View style={styles.page}>
      <View style={styles.top}>
        <HubTitle text="TEST BUILD" size={30} />
        <View style={styles.gems}>
          <Text style={styles.gemsText}>{`💎 ${profile.gems || 0}  ·  🪙 ${profile.coins || 0}`}</Text>
        </View>
      </View>
      <View style={styles.cards}>
        <ModePanel kind="regular" pic={PICS.stack} title="Squish Stack" onPress={() => onPick('stack')} delay={200} width={330} picH={120}>
          <Text style={styles.info}>{`BLITZ BEST: ${stk.blitz.top}`}</Text>
        </ModePanel>
        <ModePanel kind="regular" pic={PICS.hop} title="Squish Hop" onPress={() => onPick('hop')} delay={320} width={330} picH={120}>
          <Text style={styles.info}>{`BLITZ BEST: ${hop.blitz.top}`}</Text>
        </ModePanel>
      </View>
      <Text style={styles.note}>Stand-in squishies, every level open, ads are pretend. Nothing is saved to an account: a reload starts over.</Text>
    </View>
  );
}

export default function Demo() {
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
  const [profile, setProfile] = useState(demoProfile());
  const [game, setGame] = useState(null); // null | stack | hop
  useEffect(() => subscribeDemo(setProfile), []);
  const back = useMemo(() => () => setGame(null), []);
  if (!fonts) return <View style={styles.fill} />;
  const props = { profile, creatures: CREATURES, uid: 'demo', adsFree: false, haptics: true, onBack: back };
  return (
    <SafeAreaProvider>
      <View style={styles.fill}>
        {game === 'stack' ? <StackScreen {...props} /> : null}
        {game === 'hop' ? <HopScreen {...props} /> : null}
        {game ? null : (
          <GameBackground style={styles.fill}>
            <Picker profile={profile} onPick={setGame} />
          </GameBackground>
        )}
      </View>
    </SafeAreaProvider>
  );
}

const styles = StyleSheet.create({
  fill: { flex: 1 },
  page: { flex: 1, alignItems: 'center', justifyContent: 'space-between', paddingTop: 8, paddingBottom: 10 },
  top: { alignSelf: 'stretch', alignItems: 'center', justifyContent: 'center' },
  gems: { position: 'absolute', right: 14, top: 2, backgroundColor: 'rgba(91,58,41,0.75)', borderRadius: 999, borderWidth: 2, borderColor: '#ffffff', paddingHorizontal: 10, paddingVertical: 3 },
  gemsText: { fontFamily: F.display, fontSize: 13, color: '#ffffff' },
  cards: { flexDirection: 'row', gap: 22 },
  info: { flex: 1, textAlign: 'center', fontFamily: F.display, fontSize: 16, color: '#ffffff', textShadowColor: INK, textShadowRadius: 1.5, textShadowOffset: { width: 0, height: 1.5 } },
  note: { fontFamily: F.heavy, fontSize: 11.5, color: INK, textAlign: 'center', paddingHorizontal: 30 },
});
