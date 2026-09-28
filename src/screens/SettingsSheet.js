import React, { useEffect, useState } from 'react';
import { View, Text, TextInput, Pressable, Modal, StyleSheet, KeyboardAvoidingView, Platform, ScrollView } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { candyColors, candyFonts } from '../theme/candyTheme';
import CandyButton from '../components/candy/CandyButton';
import RoundButton, { CloseGlyph } from '../components/candy/RoundButton';
import Toast from '../components/squad/Toast';

// Bottom sheet opened from Home's gear icon — nickname editing, one-time
// "remove ads" claim, a feedback note, real gameplay stats, and logout, in
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
  onClaimAdsFree,
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

  const claimAds = () => {
    if (adsFree) return;
    onClaimAdsFree();
    flash('Ads removed!');
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
              <View>
                <Text style={styles.cardLabel}>Remove Ads</Text>
                <Text style={styles.cardSublabel}>One-time free removal</Text>
              </View>
              <Pressable onPress={claimAds} disabled={adsFree}>
                {adsFree ? (
                  <View style={[styles.flatPill, styles.flatPillDone]}>
                    <Text style={[styles.flatPillText, styles.flatPillTextDone]}>REMOVED ✓</Text>
                  </View>
                ) : (
                  <LinearGradient colors={['#ffe27a', '#ff9fd6']} start={{ x: 0, y: 0 }} end={{ x: 1, y: 1 }} style={styles.flatPill}>
                    <Text style={styles.flatPillText}>CLAIM FREE</Text>
                  </LinearGradient>
                )}
              </Pressable>
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
  cardRow: { flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between' },
  cardLabel: { color: candyColors.ink, fontFamily: candyFonts.bodyHeavy, fontSize: 13 },
  cardSublabel: { color: candyColors.mutedLight, fontFamily: candyFonts.body, fontSize: 11 },
  flatPill: { borderRadius: 10, paddingVertical: 9, paddingHorizontal: 14 },
  flatPillDone: { backgroundColor: '#ece4f5' },
  flatPillText: { color: candyColors.ink, fontFamily: candyFonts.bodyHeavy, fontSize: 11 },
  flatPillTextDone: { color: '#a898bf' },
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
