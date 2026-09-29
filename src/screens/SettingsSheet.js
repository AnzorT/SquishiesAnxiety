import React, { useEffect, useRef, useState } from 'react';
import { View, Text, TextInput, Pressable, Modal, StyleSheet, KeyboardAvoidingView, Platform, ScrollView } from 'react-native';
import { candyColors, candyFonts } from '../theme/candyTheme';
import CandyButton, { CandyPill } from '../components/candy/CandyButton';
import { NoAdsIcon } from '../components/RemoveAds';
import RoundButton, { CloseGlyph } from '../components/candy/RoundButton';
import Toast from '../components/squad/Toast';
import ToggleSwitch from '../components/candy/ToggleSwitch';
import sfx from '../audio/sfx';

// Bottom sheet opened from Home's gear icon — nickname editing, Remove Ads
// (opens the $1.99 purchase popup), a feedback note, real gameplay stats,
// music / sound switches, and logout, in
// the v3 look: a pale pink sheet of white cards, candy SAVE/LOG OUT buttons.
// The stats show total squish presses, longest hold (seconds), and favorite
// creature — derived from `stats` (tracked via recordPress in
// src/firebase/firestore.js) and the pre-computed `favoriteCreatureName`,
// both passed down from App.js.
export default function SettingsSheet({
  visible,
  onClose,
  nickname,
  onSaveNickname,
  adsFree,
  removeAdsPrice,
  onOpenRemoveAds,
  onSubmitFeedback,
  onLogout,
  stats,
  favoriteCreatureName,
}) {
  const [nicknameEdit, setNicknameEdit] = useState(nickname || '');
  const [feedbackOpen, setFeedbackOpen] = useState(false);
  const [feedbackText, setFeedbackText] = useState('');
  const [toast, setToast] = useState(null);
  const [toastKey, setToastKey] = useState(0);

  useEffect(() => {
    if (visible) setNicknameEdit(nickname || '');
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

  const presses = stats?.presses ?? 0;
  const longestHoldSeconds = ((stats?.longestHoldMs ?? 0) / 1000).toFixed(1);
  const favorite = favoriteCreatureName || 'None yet';

  return (
    <Modal visible={visible} transparent animationType="slide" onRequestClose={onClose} statusBarTranslucent>
      <Pressable style={styles.backdrop} onPress={onClose}>
        <Pressable style={styles.sheet} onPress={() => {}}>
          <ScrollView bounces={false} showsVerticalScrollIndicator={false} keyboardShouldPersistTaps="handled" contentContainerStyle={styles.sheetContent}>
            <View style={styles.headerRow}>
              <Text style={styles.title}>SETTINGS</Text>
              <RoundButton size={32} onPress={onClose} style={styles.closeButton}>
                <CloseGlyph />
              </RoundButton>
            </View>

            <View style={[styles.card, styles.cardRow]}>
              <NoAdsIcon size={34} />
              <View style={styles.flex}>
                <Text style={styles.cardLabel}>Remove Ads</Text>
                <Text style={styles.cardSublabel}>{adsFree ? 'Thanks for your support!' : 'No banners, no ad breaks, free daily boxes'}</Text>
              </View>
              {adsFree ? (
                <CandyPill variant="purple" label="★ DONE" fontSize={12} padV={4} padH={12} />
              ) : (
                <CandyButton label={removeAdsPrice} variant="gold" size="sm" pulse="soft" onPress={onOpenRemoveAds} />
              )}
            </View>

            <View style={styles.card}>
              <View style={[styles.statRow, styles.soundRow]}>
                <Text style={styles.cardLabel}>Music</Text>
                <ToggleSwitch value={sound.music} onToggle={() => sfx.setMusicOn(!sound.music)} />
              </View>
              <View style={[styles.statRow, styles.statRowLast, styles.soundRow]}>
                <Text style={styles.cardLabel}>Sound effects</Text>
                <ToggleSwitch value={sound.effects} onToggle={() => sfx.setEffectsOn(!sound.effects)} />
              </View>
            </View>

            <View style={styles.card}>
              <Text style={styles.cardLabel}>Nickname</Text>
              <View style={styles.nicknameRow}>
                <TextInput style={styles.input} value={nicknameEdit} onChangeText={setNicknameEdit} placeholderTextColor="#a98bc9" />
                <CandyButton label="SAVE" variant="blue" size="sm" onPress={saveNickname} />
              </View>
            </View>

            <View style={styles.card}>
              <Text style={styles.statsTitle}>YOUR STATS</Text>
              <View style={styles.statRow}>
                <Text style={styles.statLabel}>Total Presses</Text>
                <Text style={styles.statValue}>{presses}</Text>
              </View>
              <View style={styles.statRow}>
                <Text style={styles.statLabel}>Longest Hold</Text>
                <Text style={styles.statValue}>{longestHoldSeconds}s</Text>
              </View>
              <View style={[styles.statRow, styles.statRowLast]}>
                <Text style={styles.statLabel}>Favorite Creature</Text>
                <Text style={styles.statValue}>{favorite}</Text>
              </View>
            </View>

            <Pressable style={styles.feedbackButton} onPress={() => setFeedbackOpen(true)}>
              <Text style={styles.feedbackButtonText}>SEND FEEDBACK</Text>
            </Pressable>

            <CandyButton label="LOG OUT" variant="pink" size="md" onPress={onLogout} style={styles.logoutButton} textStyle={styles.logoutText} />
          </ScrollView>

          <Toast message={toast} messageKey={toastKey} />
        </Pressable>
      </Pressable>

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
  sheetContent: { paddingBottom: 8 },
  headerRow: { flexDirection: 'row', alignItems: 'center', marginBottom: 14 },
  title: { fontFamily: candyFonts.display, fontSize: 20, color: candyColors.ink },
  closeButton: { marginLeft: 'auto' },
  card: { backgroundColor: '#ffffff', borderRadius: 16, padding: 14, marginBottom: 12 },
  cardRow: { flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between', gap: 10 },
  flex: { flex: 1 },
  cardLabel: { color: candyColors.ink, fontFamily: candyFonts.bodyHeavy, fontSize: 13 },
  cardSublabel: { color: candyColors.mutedLight, fontFamily: candyFonts.body, fontSize: 11 },
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
  statsTitle: { color: candyColors.goldInk, fontFamily: candyFonts.bodyHeavy, fontSize: 12, letterSpacing: 1, marginBottom: 10 },
  statRow: { flexDirection: 'row', justifyContent: 'space-between', marginBottom: 7 },
  statRowLast: { marginBottom: 0 },
  soundRow: { alignItems: 'center', marginBottom: 12 },
  statLabel: { color: candyColors.inkSoft, fontFamily: candyFonts.body, fontSize: 12.5 },
  statValue: { color: candyColors.ink, fontFamily: candyFonts.body, fontSize: 12.5 },
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
