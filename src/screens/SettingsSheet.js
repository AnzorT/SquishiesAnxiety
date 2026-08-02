import React, { useEffect, useState } from 'react';
import { View, Text, TextInput, Pressable, Modal, StyleSheet, KeyboardAvoidingView, Platform } from 'react-native';
import { squadColors, squadGradients, squadFonts, squadRadii } from '../theme/squadTheme';
import GradientButton from '../components/squad/GradientButton';
import IconButton from '../components/squad/IconButton';
import Toast from '../components/squad/Toast';

// Bottom sheet opened from Home's gear icon — nickname editing, one-time
// "remove ads" claim, a feedback note, real account stats, and logout, all
// matching the prototype's SETTINGS panel. The prototype also tracks press
// count / longest hold / favorite creature there, but those only exist as
// events inside SquishScreen's squish gesture, which is explicitly out of
// scope for this pass — so this sheet's stats row shows creatures
// owned/total-earned/coins-spent instead, real numbers derived from the
// same profile document rather than fabricated placeholders.
export default function SettingsSheet({
  visible,
  onClose,
  nickname,
  onSaveNickname,
  adsFree,
  onClaimAdsFree,
  onSubmitFeedback,
  onLogout,
  ownedCount,
  totalCount,
  totalEarned = 0,
  coins = 0,
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

  const spent = Math.max(0, totalEarned - coins);

  return (
    <Modal visible={visible} transparent animationType="slide" onRequestClose={onClose}>
      <Pressable style={styles.backdrop} onPress={onClose}>
        <Pressable style={styles.sheet} onPress={() => {}}>
          <View style={styles.headerRow}>
            <Text style={styles.title}>SETTINGS</Text>
            <IconButton name="close" onPress={onClose} size={32} iconSize={16} color={squadColors.textWhite} style={styles.closeButton} />
          </View>

          <View style={styles.card}>
            <View style={styles.cardRow}>
              <View>
                <Text style={styles.cardLabel}>Remove Ads</Text>
                <Text style={styles.cardSublabel}>One-time free removal</Text>
              </View>
              <GradientButton
                label={adsFree ? 'REMOVED ✓' : 'CLAIM FREE'}
                onPress={claimAds}
                disabled={adsFree}
                colors={squadGradients.ctaGoldPink.colors}
                start={squadGradients.ctaGoldPink.start}
                end={squadGradients.ctaGoldPink.end}
                fontSize={11}
                pillStyle={styles.smallPill}
              />
            </View>
          </View>

          <View style={styles.card}>
            <Text style={styles.cardLabel}>Nickname</Text>
            <View style={styles.nicknameRow}>
              <TextInput
                style={styles.input}
                value={nicknameEdit}
                onChangeText={setNicknameEdit}
                placeholderTextColor={squadColors.textFaint}
              />
              <GradientButton
                label="SAVE"
                onPress={saveNickname}
                colors={squadGradients.ctaTeal.colors}
                start={squadGradients.ctaTeal.start}
                end={squadGradients.ctaTeal.end}
                textColor={squadColors.bgDeepest}
                fontSize={12}
                pillStyle={styles.smallPill}
              />
            </View>
          </View>

          <View style={styles.card}>
            <Text style={styles.statsTitle}>YOUR STATS</Text>
            <View style={styles.statRow}>
              <Text style={styles.statLabel}>Creatures Owned</Text>
              <Text style={styles.statValue}>{ownedCount}/{totalCount}</Text>
            </View>
            <View style={styles.statRow}>
              <Text style={styles.statLabel}>Total Coins Earned</Text>
              <Text style={styles.statValue}>{totalEarned}</Text>
            </View>
            <View style={[styles.statRow, styles.statRowLast]}>
              <Text style={styles.statLabel}>Coins Spent</Text>
              <Text style={styles.statValue}>{spent}</Text>
            </View>
          </View>

          <Pressable style={styles.feedbackButton} onPress={() => setFeedbackOpen(true)}>
            <Text style={styles.feedbackButtonText}>SEND FEEDBACK</Text>
          </Pressable>

          <GradientButton
            label="LOG OUT"
            onPress={onLogout}
            colors={squadGradients.ctaLogout.colors}
            start={squadGradients.ctaLogout.start}
            end={squadGradients.ctaLogout.end}
            textColor="#ffffff"
            fontSize={14}
            style={styles.logoutButton}
          />

          <Toast message={toast} messageKey={toastKey} />
        </Pressable>
      </Pressable>

      <Modal visible={feedbackOpen} transparent animationType="fade" onRequestClose={() => setFeedbackOpen(false)}>
        <KeyboardAvoidingView
          style={styles.feedbackBackdrop}
          behavior={Platform.OS === 'ios' ? 'padding' : undefined}
        >
          <View style={styles.feedbackCard}>
            <View style={styles.headerRow}>
              <Text style={styles.feedbackTitle}>Feedback</Text>
              <IconButton name="close" onPress={() => setFeedbackOpen(false)} size={28} iconSize={14} color={squadColors.textWhite} style={styles.closeButton} />
            </View>
            <TextInput
              style={styles.textarea}
              value={feedbackText}
              onChangeText={setFeedbackText}
              placeholder="Tell us what you think..."
              placeholderTextColor={squadColors.textFaint}
              multiline
              textAlignVertical="top"
            />
            <GradientButton
              label="SUBMIT"
              onPress={submitFeedback}
              colors={squadGradients.ctaTeal.colors}
              start={squadGradients.ctaTeal.start}
              end={squadGradients.ctaTeal.end}
              textColor={squadColors.bgDeepest}
              fontSize={13}
              style={styles.feedbackSubmit}
            />
          </View>
        </KeyboardAvoidingView>
      </Modal>
    </Modal>
  );
}

const styles = StyleSheet.create({
  backdrop: { flex: 1, backgroundColor: 'rgba(10,4,25,0.7)', justifyContent: 'flex-end' },
  sheet: {
    maxHeight: '82%',
    backgroundColor: squadColors.sheetBg,
    borderTopLeftRadius: squadRadii.xl,
    borderTopRightRadius: squadRadii.xl,
    borderTopWidth: 2,
    borderColor: squadColors.panelBorder,
    padding: 20,
  },
  headerRow: { flexDirection: 'row', alignItems: 'center', marginBottom: 16 },
  title: { fontFamily: squadFonts.headingExtraBold, fontSize: 20, color: squadColors.textWhite },
  closeButton: { marginLeft: 'auto' },
  card: { backgroundColor: squadColors.panelAlt, borderRadius: squadRadii.md, padding: 14, marginBottom: 12 },
  cardRow: { flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between' },
  cardLabel: { color: squadColors.textWhite, fontFamily: squadFonts.bodyExtraBold, fontSize: 13, marginBottom: 4 },
  cardSublabel: { color: squadColors.textMuted, fontFamily: squadFonts.bodyBold, fontSize: 11 },
  smallPill: { paddingVertical: 9, paddingHorizontal: 14 },
  nicknameRow: { flexDirection: 'row', gap: 8, marginTop: 8 },
  input: {
    flex: 1,
    borderRadius: 10,
    borderWidth: 1.5,
    borderColor: squadColors.panelBorder,
    backgroundColor: '#150a2e',
    color: squadColors.textWhite,
    fontFamily: squadFonts.bodyBold,
    fontSize: 13,
    paddingHorizontal: 12,
    paddingVertical: 10,
  },
  statsTitle: { color: squadColors.gold, fontFamily: squadFonts.bodyExtraBold, fontSize: 12, letterSpacing: 1, marginBottom: 10 },
  statRow: { flexDirection: 'row', justifyContent: 'space-between', marginBottom: 7 },
  statRowLast: { marginBottom: 0 },
  statLabel: { color: squadColors.textLavender, fontFamily: squadFonts.bodyBold, fontSize: 12.5 },
  statValue: { color: squadColors.textWhite, fontFamily: squadFonts.bodyBold, fontSize: 12.5 },
  feedbackButton: {
    width: '100%',
    borderRadius: squadRadii.md,
    backgroundColor: squadColors.panel,
    paddingVertical: 13,
    alignItems: 'center',
    marginBottom: 10,
  },
  feedbackButtonText: { color: squadColors.textWhite, fontFamily: squadFonts.headingBold, fontSize: 14 },
  logoutButton: { width: '100%' },
  feedbackBackdrop: { flex: 1, backgroundColor: 'rgba(10,4,25,0.75)', alignItems: 'center', justifyContent: 'center', padding: 30 },
  feedbackCard: { width: '100%', backgroundColor: squadColors.sheetBg, borderRadius: squadRadii.lg, borderWidth: 2, borderColor: squadColors.panelBorder, padding: 20 },
  feedbackTitle: { fontFamily: squadFonts.headingExtraBold, fontSize: 17, color: squadColors.textWhite },
  textarea: {
    width: '100%',
    height: 90,
    borderRadius: squadRadii.md,
    borderWidth: 1.5,
    borderColor: squadColors.panelBorder,
    backgroundColor: '#150a2e',
    color: squadColors.textWhite,
    fontFamily: squadFonts.bodySemiBold,
    fontSize: 13,
    padding: 10,
  },
  feedbackSubmit: { width: '100%', marginTop: 10 },
});
