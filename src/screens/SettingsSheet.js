import React, { useEffect, useRef, useState } from 'react';
import { View, Text, TextInput, Pressable, Modal, StyleSheet, KeyboardAvoidingView, Platform, ScrollView } from 'react-native';
import { candyColors, candyFonts } from '../theme/candyTheme';
import CandyButton from '../components/candy/CandyButton';
import RoundButton, { CloseGlyph } from '../components/candy/RoundButton';
import Toast from '../components/squad/Toast';
import ToggleSwitch from '../components/candy/ToggleSwitch';
import sfx from '../audio/sfx';

// Bottom sheet opened from Home's gear icon — music / sound switches,
// nickname editing, a feedback note and logout, in the v3 look: a pale pink
// sheet of white cards, candy SAVE/LOG OUT buttons. (Remove Ads lives on
// Home's NO ADS button; the stats have their own screen, StatsScreen.)
//
// The sheet scrolls when it's taller than 82% of the screen (small phones,
// large system font). The tap-to-close backdrop is a sibling behind the
// sheet, not its parent, so no touchable sits between the finger and the
// ScrollView.
export default function SettingsSheet({ visible, onClose, nickname, onSaveNickname, onSubmitFeedback, onLogout, onReplayTutorial }) {
  const [nicknameEdit, setNicknameEdit] = useState((nickname || '').slice(0, 10));
  const [feedbackOpen, setFeedbackOpen] = useState(false);
  const [feedbackText, setFeedbackText] = useState('');
  const [toast, setToast] = useState(null);
  const [toastKey, setToastKey] = useState(0);

  useEffect(() => {
    if (visible) setNicknameEdit((nickname || '').slice(0, 10));
  }, [visible, nickname]);

  // pop sounds as the sheet opens and closes (not on first mount)
  const shownRef = useRef(visible);
  useEffect(() => {
    if (shownRef.current === visible) return;
    shownRef.current = visible;
    sfx.play(visible ? 'popOpen' : 'popClose');
  }, [visible]);

  const [sound, setSound] = useState({ music: true, effects: true });
  useEffect(() => sfx.subscribe(setSound), []);

  const flash = (message) => {
    setToast(message);
    setToastKey((k) => k + 1);
    setTimeout(() => setToast((current) => (current === message ? null : current)), 2200);
  };

  const saveNickname = () => {
    if (!nicknameEdit.trim()) return;
    onSaveNickname(nicknameEdit.trim());
    flash('Nickname updated!');
  };

  const submitFeedback = () => {
    if (!feedbackText.trim()) return;
    onSubmitFeedback(feedbackText.trim());
    setFeedbackText('');
    setFeedbackOpen(false);
    flash('Thanks for your feedback!');
  };

  return (
    <Modal visible={visible} transparent animationType="slide" onRequestClose={onClose} statusBarTranslucent>
      <View style={styles.backdrop}>
        <Pressable style={StyleSheet.absoluteFill} onPress={onClose} />
        <View style={styles.sheet}>
          <ScrollView style={styles.scroll} showsVerticalScrollIndicator keyboardShouldPersistTaps="handled" contentContainerStyle={styles.sheetContent}>
            <View style={styles.headerRow}>
              <Text style={styles.title}>SETTINGS</Text>
              <RoundButton size={32} onPress={onClose} style={styles.closeButton}>
                <CloseGlyph />
              </RoundButton>
            </View>

            <View style={styles.card}>
              <View style={styles.soundRow}>
                <Text style={styles.cardLabel}>Music</Text>
                <ToggleSwitch value={sound.music} onToggle={() => sfx.setMusicOn(!sound.music)} />
              </View>
              <View style={[styles.soundRow, styles.soundRowLast]}>
                <Text style={styles.cardLabel}>Sound effects</Text>
                <ToggleSwitch value={sound.effects} onToggle={() => sfx.setEffectsOn(!sound.effects)} />
              </View>
            </View>

            <View style={styles.card}>
              <Text style={styles.cardLabel}>Nickname</Text>
              <View style={styles.nicknameRow}>
                <TextInput style={styles.input} value={nicknameEdit} onChangeText={setNicknameEdit} maxLength={10} placeholderTextColor="#a98bc9" />
                <CandyButton label="SAVE" variant="blue" size="sm" onPress={saveNickname} />
              </View>
            </View>

            <Pressable style={styles.feedbackButton} onPress={() => setFeedbackOpen(true)}>
              <Text style={styles.feedbackButtonText}>SEND FEEDBACK</Text>
            </Pressable>

            {/* the design's "Replay tutorial" (src/tutorial): starts the guide over */}
            {onReplayTutorial ? (
              <Pressable
                style={styles.feedbackButton}
                onPress={() => {
                  onReplayTutorial();
                  onClose();
                }}
              >
                <Text style={styles.feedbackButtonText}>REPLAY TUTORIAL</Text>
              </Pressable>
            ) : null}

            <CandyButton label="LOG OUT" variant="pink" size="md" onPress={onLogout} style={styles.logoutButton} textStyle={styles.logoutText} />
          </ScrollView>

          <Toast message={toast} messageKey={toastKey} />
        </View>
      </View>

      <Modal visible={feedbackOpen} transparent animationType="fade" onRequestClose={() => setFeedbackOpen(false)} statusBarTranslucent>
        <KeyboardAvoidingView style={styles.feedbackBackdrop} behavior={Platform.OS === 'ios' ? 'padding' : undefined}>
          <View style={styles.feedbackCard}>
            <View style={styles.feedbackHeader}>
              <Text style={styles.feedbackTitle}>Feedback</Text>
              <RoundButton size={28} onPress={() => setFeedbackOpen(false)} style={styles.closeButton}>
                <CloseGlyph size={12} />
              </RoundButton>
            </View>
            <TextInput
              style={styles.textarea}
              value={feedbackText}
              onChangeText={setFeedbackText}
              placeholder="Tell us what you think..."
              placeholderTextColor="#a98bc9"
              multiline
              textAlignVertical="top"
            />
            <CandyButton label="SUBMIT" variant="blue" size="md" onPress={submitFeedback} style={styles.feedbackSubmit} textStyle={styles.submitText} />
          </View>
        </KeyboardAvoidingView>
      </Modal>
    </Modal>
  );
}

const styles = StyleSheet.create({
  backdrop: { flex: 1, backgroundColor: candyColors.scrim, justifyContent: 'flex-end' },
  sheet: {
    maxHeight: '82%',
    backgroundColor: candyColors.sheet,
    borderTopLeftRadius: 26,
    borderTopRightRadius: 26,
    borderTopWidth: 2,
    borderColor: candyColors.inkSoft,
    padding: 20,
    paddingBottom: 28,
  },
  scroll: { flexGrow: 0, flexShrink: 1 },
  sheetContent: { paddingBottom: 8 },
  headerRow: { flexDirection: 'row', alignItems: 'center', marginBottom: 14 },
  title: { fontFamily: candyFonts.display, fontSize: 20, color: candyColors.ink },
  closeButton: { marginLeft: 'auto' },
  card: { backgroundColor: '#ffffff', borderRadius: 16, padding: 14, marginBottom: 12 },
  cardLabel: { color: candyColors.ink, fontFamily: candyFonts.bodyHeavy, fontSize: 13 },
  nicknameRow: { flexDirection: 'row', alignItems: 'center', gap: 8, marginTop: 8 },
  input: {
    flex: 1,
    borderRadius: 10,
    borderWidth: 1.5,
    borderColor: candyColors.inkSoft,
    backgroundColor: candyColors.paper,
    color: candyColors.ink,
    fontFamily: candyFonts.body,
    fontSize: 13,
    paddingHorizontal: 12,
    paddingVertical: 9,
  },
  soundRow: { flexDirection: 'row', justifyContent: 'space-between', alignItems: 'center', marginBottom: 12 },
  soundRowLast: { marginBottom: 0 },
  feedbackButton: {
    width: '100%',
    borderRadius: 14,
    backgroundColor: '#ffffff',
    paddingVertical: 13,
    alignItems: 'center',
    marginBottom: 12,
  },
  feedbackButtonText: { color: candyColors.ink, fontFamily: candyFonts.display, fontSize: 14 },
  logoutButton: { width: '100%' },
  logoutText: { fontSize: 14 },
  feedbackBackdrop: { flex: 1, backgroundColor: candyColors.scrim, alignItems: 'center', justifyContent: 'center', padding: 30 },
  feedbackCard: { width: '100%', backgroundColor: candyColors.sheet, borderRadius: 20, borderWidth: 2, borderColor: candyColors.inkSoft, padding: 20 },
  feedbackHeader: { flexDirection: 'row', alignItems: 'center', marginBottom: 12 },
  feedbackTitle: { fontFamily: candyFonts.display, fontSize: 17, color: candyColors.ink },
  textarea: {
    width: '100%',
    height: 90,
    borderRadius: 12,
    borderWidth: 1.5,
    borderColor: candyColors.inkSoft,
    backgroundColor: candyColors.paper,
    color: candyColors.ink,
    fontFamily: candyFonts.bodySemi,
    fontSize: 13,
    padding: 10,
  },
  feedbackSubmit: { width: '100%', marginTop: 12 },
  submitText: { fontSize: 13 },
});
