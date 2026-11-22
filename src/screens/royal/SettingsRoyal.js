import React, { useEffect, useState } from 'react';
import { BackHandler, Keyboard, KeyboardAvoidingView, Modal, ScrollView, StyleSheet, Text, TextInput, View } from 'react-native';
import ToggleSwitch from '../../components/candy/ToggleSwitch';
import TestWallet from '../../components/TestWallet';
import sfx from '../../audio/sfx';
import { Btn, Icon, InkText, Lettering, Orb, PageBg, PageHeader, Plaque, Stage, FONT, INK } from '../../royal';

// Settings in the new look, landscape (REDESIGN_V7 step 3): the Menu's gear opens it (the old Lobby retires). Left:
// sound, nickname, and the places that lived in the Lobby (Achievements, Stats, Level Pass). Right: feedback, log out,
// and a tester's Test wallet (App.js has the handlers).

// (Achievements left Settings for a trophy button next to the Menu's gear: REDESIGN_V8, the user)
const LINKS = [
  ['stats', 'Stats', 'M5 20V11 M12 20V5 M19 20v-6'],
  // (no Level Pass here: REDESIGN_V8, the user; the Menu's level crest opens it)
];

function Panel({ title, children, style }) {
  return (
    <Plaque variant="vel" radius={22} rim={3.5} ring={2} lip={4} style={[styles.panel, style]}>
      <Lettering text={title} variant="gold" size={19} />
      {children}
    </Plaque>
  );
}

export default function SettingsRoyal({ onBack, nickname, onSaveNickname, onSubmitFeedback, onLogout, onOpenStats, onOpenAchievements, onOpenRoad, tester, wallet, fpsOn, onToggleFps }) {
  const [sound, setSound] = useState({ music: true, effects: true });
  useEffect(() => sfx.subscribe(setSound), []);
  const [nick, setNick] = useState((nickname || '').slice(0, 10));
  useEffect(() => setNick((nickname || '').slice(0, 10)), [nickname]);
  const [toast, setToast] = useState(null);
  const [feedback, setFeedback] = useState(null); // the text while the feedback box is open
  const [wall, setWall] = useState(false); // a tester's Test wallet on show
  const flash = (t) => {
    setToast(t);
    setTimeout(() => setToast((c) => (c === t ? null : c)), 2200);
  };
  useEffect(() => {
    const sub = BackHandler.addEventListener('hardwareBackPress', () => {
      if (feedback != null) setFeedback(null);
      else if (wall) setWall(false);
      else onBack();
      return true;
    });
    return () => sub.remove();
  }, [feedback, wall, onBack]);
  const go = { trophies: onOpenAchievements, stats: onOpenStats, road: onOpenRoad };
  const save = () => {
    if (!nick.trim()) return;
    Keyboard.dismiss();
    onSaveNickname(nick.trim());
    flash('Nickname updated!');
  };
  const send = async () => {
    const t = (feedback || '').trim();
    if (!t) return;
    try {
      await onSubmitFeedback(t);
      setFeedback(null);
      flash('Thanks for the feedback!');
    } catch (e) {
      flash('Could not send. Try again!');
    }
  };
  return (
    <View style={styles.root}>
      <PageBg />
      <Stage>
        <PageHeader title="Settings" note={nickname ? `Playing as ${nickname}` : null} onBack={onBack} />
        <View style={styles.cols}>
          <View style={styles.col}>
            <Panel title={tester ? 'Options' : 'Sound'}>
              <View style={styles.row}>
                <InkText size={15}>Music</InkText>
                <ToggleSwitch value={sound.music} onToggle={() => sfx.setMusicOn(!sound.music)} />
              </View>
              <View style={styles.row}>
                <InkText size={15}>Sound effects</InkText>
                <ToggleSwitch value={sound.effects} onToggle={() => sfx.setEffectsOn(!sound.effects)} />
              </View>
              {/* a tester's FPS counter (also in the Test wallet): kept across launches */}
              {tester ? (
                <View style={styles.row}>
                  <InkText size={15}>FPS counter</InkText>
                  <ToggleSwitch value={!!fpsOn} onToggle={onToggleFps} />
                </View>
              ) : null}
            </Panel>
          </View>
          <View style={styles.col}>
            {/* (SAVE is at the bottom, in the middle of the screen: REDESIGN_V8, the user) */}
            <Panel title="Nickname">
              <TextInput style={styles.input} value={nick} onChangeText={setNick} maxLength={10} placeholder="Your name" placeholderTextColor="#e8c9a0" returnKeyType="done" onSubmitEditing={save} />
            </Panel>
            <Panel title="Your squad">
              {LINKS.map(([k, label, d]) =>
                go[k] ? (
                  <Plaque key={k} variant="vel" radius={14} onPress={go[k]} style={styles.link}>
                    <Icon d={d} size={18} width={2.3} />
                    <InkText size={15}>{label}</InkText>
                  </Plaque>
                ) : null,
              )}
            </Panel>
          </View>
          <View style={styles.col}>
            <Panel title="More">
              <Plaque variant="vel" radius={14} onPress={() => setFeedback('')} style={styles.link}>
                <Icon d="M4 5h16v11H8l-4 4Z" size={18} width={2.3} />
                <InkText size={15}>Send feedback</InkText>
              </Plaque>
              {tester ? (
                <Plaque variant="vel" radius={14} onPress={() => setWall(true)} style={styles.link}>
                  <Icon d="M4 7h16v12H4Z M4 7l3-3h10l3 3 M15 13h2" size={18} width={2.3} />
                  <InkText size={15}>Test wallet</InkText>
                </Plaque>
              ) : null}
              <Btn label="LOG OUT" variant="vel" size={16} height={40} radius={14} onPress={onLogout} style={styles.logout} />
            </Panel>
          </View>
        </View>
        <View style={styles.saveAt} pointerEvents="box-none">
          <Btn label="SAVE" size={18} width={190} height={44} radius={15} glow onPress={save} />
        </View>
        {/* (after SAVE, so it covers it) */}
        {tester && wall ? (
          <View style={styles.tester}>
            <Plaque variant="pearl" radius={22} rim={3.5} ring={2} lip={4} style={styles.testerIn}>
              <ScrollView style={{ alignSelf: 'stretch' }} contentContainerStyle={{ padding: 10 }} showsVerticalScrollIndicator={false}>
                <TestWallet wallet={wallet} fpsOn={fpsOn} onToggleFps={onToggleFps} />
              </ScrollView>
            </Plaque>
            <Orb icon="close" size={34} onPress={() => setWall(false)} style={styles.testerX} />
          </View>
        ) : null}
        {toast ? (
          <Plaque variant="gold" style={styles.toast}>
            <Text style={styles.toastT}>{toast}</Text>
          </Plaque>
        ) : null}
      </Stage>
      <Modal visible={feedback != null} transparent animationType="fade" onRequestClose={() => setFeedback(null)} statusBarTranslucent supportedOrientations={['landscape']}>
        <KeyboardAvoidingView style={styles.fbWrap}>
          <Plaque variant="vel" radius={22} rim={3.5} ring={2} lip={4} style={styles.fb}>
            <Lettering text="Feedback" variant="gold" size={20} />
            <TextInput style={styles.fbInput} value={feedback || ''} onChangeText={setFeedback} placeholder="Tell us what you think..." placeholderTextColor="#e8c9a0" multiline textAlignVertical="top" />
            <View style={styles.fbRow}>
              <Btn label="CANCEL" variant="vel" size={15} width={120} height={38} radius={12} onPress={() => setFeedback(null)} />
              <Btn label="SEND" size={15} width={120} height={38} radius={12} onPress={send} />
            </View>
          </Plaque>
        </KeyboardAvoidingView>
      </Modal>
    </View>
  );
}

const styles = StyleSheet.create({
  root: { ...StyleSheet.absoluteFillObject, backgroundColor: '#d27c3e' },
  cols: { position: 'absolute', left: 22, top: 70, right: 22, bottom: 72, flexDirection: 'row', gap: 18 },
  saveAt: { position: 'absolute', left: 0, right: 0, bottom: 16, alignItems: 'center' },
  col: { flex: 1, gap: 14 },
  panel: { alignItems: 'stretch', justifyContent: 'flex-start', paddingHorizontal: 16, paddingTop: 10, paddingBottom: 14, gap: 10 },
  row: { flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between', gap: 10 },
  input: { alignSelf: 'stretch', height: 38, borderRadius: 12, paddingHorizontal: 12, backgroundColor: 'rgba(60,30,10,0.4)', borderWidth: 1.5, borderColor: 'rgba(255,236,170,0.55)', color: '#ffffff', fontFamily: FONT.bodyHeavy, fontSize: 15 },
  link: { height: 42, flexDirection: 'row', gap: 10, paddingHorizontal: 14, justifyContent: 'flex-start' },
  logout: { marginTop: 4 },
  tester: { ...StyleSheet.absoluteFillObject, alignItems: 'center', justifyContent: 'center', backgroundColor: 'rgba(40,20,8,0.55)' },
  testerIn: { width: 420, height: 330, justifyContent: 'flex-start' },
  testerX: { position: 'absolute', left: '50%', marginLeft: 196, top: 18 },
  toast: { position: 'absolute', alignSelf: 'center', left: '35%', right: '35%', bottom: 72, height: 34 },
  toastT: { fontFamily: FONT.display, fontSize: 14, color: INK, includeFontPadding: false },
  fbWrap: { flex: 1, alignItems: 'center', justifyContent: 'center', backgroundColor: 'rgba(40,20,8,0.55)' },
  fb: { width: 460, paddingHorizontal: 18, paddingTop: 12, paddingBottom: 16, gap: 12, alignItems: 'stretch' },
  fbInput: { height: 110, borderRadius: 14, padding: 12, backgroundColor: 'rgba(60,30,10,0.4)', borderWidth: 1.5, borderColor: 'rgba(255,236,170,0.55)', color: '#ffffff', fontFamily: FONT.body, fontSize: 14 },
  fbRow: { flexDirection: 'row', justifyContent: 'center', gap: 16 },
});
