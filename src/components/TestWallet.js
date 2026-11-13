import React, { useEffect, useState } from 'react';
import { StyleSheet, Text, TextInput, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import Pressable from './Pressable';
import ToggleSwitch from './candy/ToggleSwitch';
import callFunction from '../firebase/callFunction';
import { tzOffsetMinutes } from '../dailySpin';
import { F } from '../squad/ui';

// The design's Test wallet ("Squish Squad App v4" dev panel): coins, gems
// and the level, with quick buttons, and the FPS counter switch. Shown in
// Settings only for a tester account (the `tester` claim); the testWallet
// Cloud Function checks the claim again (REDESIGN_V6 ruling 5).
// Replays too: the Deals streak's next day (or day 1 again), and the level
// road's prizes with the LEVEL UP card.
const n = (v) => Math.max(0, Math.round(Number(v) || 0));

export default function TestWallet({ wallet, fpsOn, onToggleFps }) {
  const [draft, setDraft] = useState({});
  const [msg, setMsg] = useState('');
  useEffect(() => setDraft({}), [wallet.coins, wallet.gems, wallet.level]);
  // `done`: what to say once it's set
  const set = async (w, done = 'Done!') => {
    setMsg('…');
    try {
      // the player's day, for the streak's "yesterday"
      await callFunction('testWallet', { ...w, tzOffsetMinutes: tzOffsetMinutes() });
      setMsg(done);
    } catch (e) {
      setMsg(e.code === 'functions/permission-denied' ? 'Not a tester account' : 'Could not set it');
    }
    setTimeout(() => setMsg(''), done === 'Done!' ? 1500 : 3000);
  };
  const val = (k) => (draft[k] != null ? draft[k] : String(wallet[k] ?? 0));
  const apply = () => {
    const w = {};
    ['coins', 'gems', 'level'].forEach((k) => draft[k] != null && draft[k] !== '' && (w[k] = n(draft[k])));
    set(w);
  };
  const quick = (label, onPress, tone) => (
    <Pressable key={label} onPress={onPress} style={[styles.quick, tone]}>
      <Text style={[styles.quickText, { color: tone.color }]}>{label}</Text>
    </Pressable>
  );
  const gold = { borderColor: '#ffd27a', backgroundColor: '#fff6dc', color: '#b86200' };
  const violet = { borderColor: '#c9b2ff', backgroundColor: '#efe8ff', color: '#5a22c8' };
  const fire = { borderColor: '#ffb98a', backgroundColor: '#fff0e4', color: '#c2531c' };
  const pink = { borderColor: '#f2b3e6', backgroundColor: '#ffeefa', color: '#8e1580' };
  return (
    <View style={styles.box}>
      <LinearGradient colors={['#8a4dff', '#6a22d6', '#45107a']} locations={[0, 0.55, 1]} style={styles.head}>
        <Text style={styles.headText}>Test wallet</Text>
        <Text style={styles.headNote}>{msg || 'tester only'}</Text>
      </LinearGradient>
      <View style={styles.body}>
        <View style={styles.row}>
          <Text style={[styles.label, { color: '#b86200' }]}>Coins</Text>
          <TextInput style={styles.input} keyboardType="number-pad" value={val('coins')} onChangeText={(t) => setDraft((d) => ({ ...d, coins: t }))} onSubmitEditing={apply} />
        </View>
        <View style={styles.quicks}>
          {quick('+1K', () => set({ coins: n(wallet.coins) + 1000 }), gold)}
          {quick('+10K', () => set({ coins: n(wallet.coins) + 10000 }), gold)}
          {quick('0', () => set({ coins: 0 }), gold)}
        </View>
        <View style={styles.row}>
          <Text style={[styles.label, { color: '#5a22c8' }]}>Gems</Text>
          <TextInput style={styles.input} keyboardType="number-pad" value={val('gems')} onChangeText={(t) => setDraft((d) => ({ ...d, gems: t }))} onSubmitEditing={apply} />
        </View>
        <View style={styles.quicks}>
          {quick('+100', () => set({ gems: n(wallet.gems) + 100 }), violet)}
          {quick('+1K', () => set({ gems: n(wallet.gems) + 1000 }), violet)}
          {quick('0', () => set({ gems: 0 }), violet)}
        </View>
        <View style={styles.row}>
          <Text style={[styles.label, { color: '#8e1580' }]}>Level</Text>
          <Pressable onPress={() => set({ level: Math.max(1, n(wallet.level) - 1) })} style={styles.step}>
            <Text style={styles.stepText}>−</Text>
          </Pressable>
          <TextInput style={[styles.input, { width: 52, textAlign: 'center' }]} keyboardType="number-pad" value={val('level')} onChangeText={(t) => setDraft((d) => ({ ...d, level: t }))} onSubmitEditing={apply} />
          <Pressable onPress={() => set({ level: Math.min(99, n(wallet.level) + 1) })} style={styles.step}>
            <Text style={styles.stepText}>+</Text>
          </Pressable>
        </View>
        <View style={styles.row}>
          <Text style={[styles.label, { color: '#c2531c' }]}>Daily streak (Shop)</Text>
        </View>
        <View style={styles.quicks}>
          {quick('Next day', () => set({ streak: 'next' }, 'Next day ready in Deals'), fire)}
          {quick('Start over', () => set({ streak: 'reset' }, 'Back to day 1'), fire)}
        </View>
        <View style={styles.row}>
          <Text style={[styles.label, { color: '#8e1580' }]}>Level road</Text>
        </View>
        <View style={styles.quicks}>
          {quick('Claim prizes again', () => set({ road: 'replay' }, 'LEVEL UP shows on the lobby'), pink)}
        </View>
        <View style={styles.row}>
          <Text style={[styles.label, { color: '#17652f' }]}>FPS counter</Text>
          <ToggleSwitch value={fpsOn} onToggle={onToggleFps} />
        </View>
        <Pressable onPress={apply} style={({ pressed }) => [styles.setRing, pressed && { transform: [{ translateY: 2 }] }]}>
          <LinearGradient colors={['#fff3b0', '#ffd83a', '#ffb000']} style={styles.set}>
            <Text style={styles.setText}>Set</Text>
          </LinearGradient>
        </Pressable>
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  box: { borderRadius: 22, borderWidth: 3, borderColor: '#ffffff', backgroundColor: '#f6efff', overflow: 'hidden', marginBottom: 14 },
  head: { flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between', paddingVertical: 9, paddingHorizontal: 14 },
  headText: { fontFamily: F.display, fontSize: 16, color: '#ffffff' },
  headNote: { fontFamily: F.display, fontSize: 12, color: '#ffffff' },
  body: { gap: 10, padding: 12 },
  row: { flexDirection: 'row', alignItems: 'center', gap: 8 },
  label: { flex: 1, fontFamily: F.black, fontSize: 14 },
  input: { width: 110, paddingVertical: 5, paddingHorizontal: 8, borderRadius: 10, borderWidth: 2, borderColor: '#d9c4f7', backgroundColor: '#ffffff', fontFamily: F.heavy, fontSize: 14, color: '#45107a', textAlign: 'right' },
  quicks: { flexDirection: 'row', gap: 5, paddingLeft: 26, marginTop: -4 },
  quick: { flex: 1, alignItems: 'center', paddingVertical: 4, borderRadius: 999, borderWidth: 2 },
  quickText: { fontFamily: F.display, fontSize: 12 },
  step: { width: 28, height: 28, borderRadius: 14, borderWidth: 2, borderColor: '#f2b3e6', backgroundColor: '#ffeefa', alignItems: 'center', justifyContent: 'center' },
  stepText: { fontFamily: F.display, fontSize: 15, color: '#8e1580' },
  setRing: { borderRadius: 18, backgroundColor: '#b86200', padding: 2, paddingBottom: 5 },
  set: { alignItems: 'center', paddingVertical: 8, borderRadius: 16, borderWidth: 3, borderColor: '#ffffff' },
  setText: { fontFamily: F.display, fontSize: 16, color: '#7a3d00' },
});
