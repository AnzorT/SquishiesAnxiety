import React, { forwardRef, memo, useEffect, useImperativeHandle, useRef, useState } from 'react';
import { Animated, BackHandler, Easing, Keyboard, View, Text, TextInput, Pressable, Modal, StyleSheet, KeyboardAvoidingView, Platform, ScrollView, useWindowDimensions } from 'react-native';
import { candyColors, candyFonts } from '../theme/candyTheme';
import CandyButton from '../components/candy/CandyButton';
import RoundButton, { CloseGlyph } from '../components/candy/RoundButton';
import Toast from '../components/squad/Toast';
import ToggleSwitch from '../components/candy/ToggleSwitch';
import sfx from '../audio/sfx';

// Bottom sheet opened from Home's menu — music / sound switches, nickname
// editing, a feedback note and logout, in the v3 look: a pale pink sheet of
// white cards, candy SAVE/LOG OUT buttons. (Remove Ads lives on Home's NO
// ADS button; the stats have their own screen, StatsScreen.)
//
// It's drawn in the app's own tree, built once and then kept: opening only
// slides it up (native) and fades the backdrop in. It used to be a
// <Modal>, which made a new Android dialog window and built the whole sheet
// on every open (~0.6 s in a debug build before it could start to move)
// and threw it away on close. It's built in the background a few seconds
// after start, so even the first open is only the slide. The Android back
// key closes it, as the Modal's did.
//
// The sheet scrolls when it's taller than 82% of the screen (small phones,
// large system font). The tap-to-close backdrop is a sibling behind the
// sheet, not its parent, so no touchable sits between the finger and the
// ScrollView.
const OPEN = { duration: 280, easing: Easing.bezier(0.22, 1, 0.36, 1), useNativeDriver: true };
const CLOSE = { duration: 200, easing: Easing.in(Easing.quad), useNativeDriver: true };

// The sheet's contents, memoized: opening and closing only move the sheet.
// `ref.reset()` puts the nickname field back to the saved nickname (on
// each open).
const Body = memo(
  forwardRef(function Body({ onClose, nickname, onSaveNickname, onSubmitFeedback, onLogout, onReplayTutorial }, ref) {
    const [nicknameEdit, setNicknameEdit] = useState((nickname || '').slice(0, 10));
    const [feedbackOpen, setFeedbackOpen] = useState(false);
    const [feedbackText, setFeedbackText] = useState('');
    const [toast, setToast] = useState(null);
    const [toastKey, setToastKey] = useState(0);

    useEffect(() => setNicknameEdit((nickname || '').slice(0, 10)), [nickname]);
    useImperativeHandle(ref, () => ({ reset: () => setNicknameEdit((nickname || '').slice(0, 10)) }), [nickname]);

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
      <>
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
      </>
    );
  }),
);

function SettingsSheet({ visible, onClose, nickname, onSaveNickname, onSubmitFeedback, onLogout, onReplayTutorial }) {
  const { height } = useWindowDimensions();
  const [built, setBuilt] = useState(visible);
  useEffect(() => {
    if (built) return undefined;
    const id = setTimeout(() => setBuilt(true), 4000);
    return () => clearTimeout(id);
  }, [built]);
  const t = useRef(new Animated.Value(visible ? 1 : 0)).current;
  const body = useRef(null);
  const shownRef = useRef(visible);
  useEffect(() => {
    if (visible) {
      setBuilt(true);
      body.current?.reset();
    } else Keyboard.dismiss();
    Animated.timing(t, { toValue: visible ? 1 : 0, ...(visible ? OPEN : CLOSE) }).start();
    // pop sounds as the sheet opens and closes (not on first mount)
    if (shownRef.current !== visible) {
      shownRef.current = visible;
      sfx.play(visible ? 'popOpen' : 'popClose');
    }
  }, [visible, t]);
  // the Android back key closes it (the Modal's onRequestClose did)
  useEffect(() => {
    if (!visible) return undefined;
    const sub = BackHandler.addEventListener('hardwareBackPress', () => {
      onClose();
      return true;
    });
    return () => sub.remove();
  }, [visible, onClose]);

  if (!built) return null;
  const translateY = t.interpolate({ inputRange: [0, 1], outputRange: [height, 0] });
  return (
    <View style={StyleSheet.absoluteFill} pointerEvents={visible ? 'box-none' : 'none'}>
      <Animated.View style={[StyleSheet.absoluteFill, styles.scrim, { opacity: t }]}>
        <Pressable style={StyleSheet.absoluteFill} onPress={onClose} />
      </Animated.View>
      <View style={styles.backdrop} pointerEvents="box-none">
        <Animated.View style={[styles.sheet, { transform: [{ translateY }] }]}>
          <Body
            ref={body}
            onClose={onClose}
            nickname={nickname}
            onSaveNickname={onSaveNickname}
            onSubmitFeedback={onSubmitFeedback}
            onLogout={onLogout}
            onReplayTutorial={onReplayTutorial}
          />
        </Animated.View>
      </View>
    </View>
  );
}

export default memo(SettingsSheet);

const styles = StyleSheet.create({
  scrim: { backgroundColor: candyColors.scrim },
  backdrop: { flex: 1, justifyContent: 'flex-end' },
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
