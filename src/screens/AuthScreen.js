import React, { useState } from 'react';
import { View, Text, TextInput, Pressable, KeyboardAvoidingView, ScrollView, Platform, StyleSheet } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { loginWithEmail, registerWithEmail } from '../firebase/auth';
import { createUserProfile } from '../firebase/firestore';
import { authErrorMessage } from '../firebase/authErrors';
import { squadColors, squadGradients, squadFonts } from '../theme/squadTheme';
import GradientButton from '../components/squad/GradientButton';

// Single Auth screen with a LOGIN/REGISTER tab toggle, matching the
// prototype exactly instead of two separate screens the user has to
// navigate between. Firebase Auth's onAuthStateChanged listener in App.js
// is what actually advances past this screen — there's no local
// navigation call on success.
function AuthTab({ label, active, onPress }) {
  if (active) {
    return (
      <Pressable style={styles.tab} onPress={onPress}>
        <LinearGradient colors={squadGradients.ctaTeal.colors} start={squadGradients.ctaTeal.start} end={squadGradients.ctaTeal.end} style={styles.tabActiveFill}>
          <Text style={[styles.tabText, styles.tabTextActive]}>{label}</Text>
        </LinearGradient>
      </Pressable>
    );
  }
  return (
    <Pressable style={styles.tab} onPress={onPress}>
      <Text style={styles.tabText}>{label}</Text>
    </Pressable>
  );
}

// Minimum age to create an account at all. Below this, registration is
// blocked outright — no email/nickname/age is ever collected or sent to
// Firebase for that person. This is the app's whole COPPA posture: rather
// than building a parental-consent flow, under-13 signups simply never
// reach the point of collecting personal information.
const MIN_SIGNUP_AGE = 13;

export default function AuthScreen() {
  const [mode, setMode] = useState('login'); // 'login' | 'register'
  // Register flow is gated in stages: 'age' (asked first, before any other
  // field) -> 'blocked' (under MIN_SIGNUP_AGE, dead end) -> 'form' (the
  // actual nickname/email/password fields).
  const [gateStage, setGateStage] = useState('age');
  const [ageInput, setAgeInput] = useState('');
  const [age, setAge] = useState(null);
  const [nickname, setNickname] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const [submitting, setSubmitting] = useState(false);

  const isRegister = mode === 'register';

  const submitAgeGate = () => {
    const ageNum = parseInt(ageInput, 10);
    if (!ageInput || Number.isNaN(ageNum) || ageNum < 1 || ageNum > 120) {
      setError('Enter a valid age.');
      return;
    }
    setError('');
    if (ageNum < MIN_SIGNUP_AGE) {
      setGateStage('blocked');
      return;
    }
    setAge(ageNum);
    setGateStage('form');
  };

  const submit = async () => {
    const trimmedEmail = email.trim();
    if (!trimmedEmail || !password) {
      setError('Enter your email and password.');
      return;
    }

    if (isRegister) {
      if (password.length < 6) {
        setError('Password needs at least 6 characters.');
        return;
      }
      setError('');
      setSubmitting(true);
      try {
        const user = await registerWithEmail(trimmedEmail, password);
        await createUserProfile(user.uid, { email: trimmedEmail, age, nickname });
      } catch (e) {
        setError(authErrorMessage(e));
        setSubmitting(false);
      }
      return;
    }

    setError('');
    setSubmitting(true);
    try {
      await loginWithEmail(trimmedEmail, password);
    } catch (e) {
      setError(authErrorMessage(e));
      setSubmitting(false);
    }
  };

  const switchMode = (next) => {
    if (next === mode) return;
    setMode(next);
    setError('');
    // Re-entering register always re-asks age from scratch.
    setGateStage('age');
    setAgeInput('');
    setAge(null);
  };

  return (
    <LinearGradient colors={squadGradients.authBg.colors} start={squadGradients.authBg.start} end={squadGradients.authBg.end} style={styles.container}>
      <KeyboardAvoidingView style={styles.flex} behavior={Platform.OS === 'ios' ? 'padding' : undefined}>
        <ScrollView contentContainerStyle={styles.scrollContent} keyboardShouldPersistTaps="handled" showsVerticalScrollIndicator={false}>
          <Text style={styles.title}>Welcome Back!</Text>

          <View style={styles.tabRow}>
            <AuthTab label="LOGIN" active={!isRegister} onPress={() => switchMode('login')} />
            <AuthTab label="REGISTER" active={isRegister} onPress={() => switchMode('register')} />
          </View>

          {isRegister && gateStage === 'age' && (
            <>
              <TextInput
                style={styles.input}
                value={ageInput}
                onChangeText={setAgeInput}
                keyboardType="number-pad"
                placeholder="How old are you?"
                placeholderTextColor={squadColors.textFaint}
                maxLength={3}
              />
              {!!error && <Text style={styles.error}>{error}</Text>}
              <GradientButton
                label="CONTINUE"
                onPress={submitAgeGate}
                colors={squadGradients.ctaTeal.colors}
                start={squadGradients.ctaTeal.start}
                end={squadGradients.ctaTeal.end}
                shadowColor={squadColors.teal}
                textColor={squadColors.bgDeepest}
                fontSize={16}
                style={styles.submitButton}
              />
            </>
          )}

          {isRegister && gateStage === 'blocked' && (
            <Text style={styles.blockedText}>
              This game needs a parent or guardian to help set up an account. Ask them to continue!
            </Text>
          )}

          {isRegister && gateStage === 'form' && (
            <>
              <TextInput
                style={styles.input}
                value={nickname}
                onChangeText={setNickname}
                placeholder="Nickname"
                placeholderTextColor={squadColors.textFaint}
              />
              <TextInput
                style={styles.input}
                value={email}
                onChangeText={setEmail}
                autoCapitalize="none"
                keyboardType="email-address"
                placeholder="Email"
                placeholderTextColor={squadColors.textFaint}
              />
              <TextInput
                style={styles.input}
                value={password}
                onChangeText={setPassword}
                secureTextEntry
                placeholder="Password"
                placeholderTextColor={squadColors.textFaint}
              />
              {!!error && <Text style={styles.error}>{error}</Text>}
              <GradientButton
                label="CREATE ACCOUNT"
                onPress={submit}
                loading={submitting}
                colors={squadGradients.ctaTeal.colors}
                start={squadGradients.ctaTeal.start}
                end={squadGradients.ctaTeal.end}
                shadowColor={squadColors.teal}
                textColor={squadColors.bgDeepest}
                fontSize={16}
                style={styles.submitButton}
              />
            </>
          )}

          {!isRegister && (
            <>
              <TextInput
                style={styles.input}
                value={email}
                onChangeText={setEmail}
                autoCapitalize="none"
                keyboardType="email-address"
                placeholder="Email"
                placeholderTextColor={squadColors.textFaint}
              />
              <TextInput
                style={styles.input}
                value={password}
                onChangeText={setPassword}
                secureTextEntry
                placeholder="Password"
                placeholderTextColor={squadColors.textFaint}
              />
              {!!error && <Text style={styles.error}>{error}</Text>}
              <GradientButton
                label="ENTER THE SQUAD"
                onPress={submit}
                loading={submitting}
                colors={squadGradients.ctaTeal.colors}
                start={squadGradients.ctaTeal.start}
                end={squadGradients.ctaTeal.end}
                shadowColor={squadColors.teal}
                textColor={squadColors.bgDeepest}
                fontSize={16}
                style={styles.submitButton}
              />
            </>
          )}
        </ScrollView>
      </KeyboardAvoidingView>
    </LinearGradient>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1 },
  flex: { flex: 1 },
  scrollContent: { flexGrow: 1, alignItems: 'center', justifyContent: 'center', paddingHorizontal: 28, paddingVertical: 40 },
  title: {
    fontFamily: squadFonts.headingExtraBold,
    fontSize: 30,
    color: squadColors.gold,
    marginBottom: 22,
    textAlign: 'center',
  },
  tabRow: {
    flexDirection: 'row',
    width: '100%',
    backgroundColor: squadColors.panel,
    borderRadius: 16,
    padding: 5,
    marginBottom: 20,
  },
  tab: { flex: 1, borderRadius: 12, overflow: 'hidden' },
  tabActiveFill: { borderRadius: 12 },
  tabText: { fontFamily: squadFonts.headingBold, fontSize: 15, color: squadColors.textMutedLavender, textAlign: 'center', paddingVertical: 11 },
  tabTextActive: { color: squadColors.bgDeepest },
  input: {
    width: '100%',
    borderRadius: 14,
    borderWidth: 2,
    borderColor: squadColors.panelBorder,
    backgroundColor: squadColors.inputBg,
    color: squadColors.textWhite,
    fontFamily: squadFonts.bodyBold,
    fontSize: 15,
    paddingHorizontal: 16,
    paddingVertical: 14,
    marginBottom: 12,
  },
  error: {
    width: '100%',
    color: squadColors.danger,
    fontFamily: squadFonts.bodyBold,
    fontSize: 13,
    marginBottom: 10,
  },
  blockedText: {
    width: '100%',
    color: squadColors.textWhite,
    fontFamily: squadFonts.bodyBold,
    fontSize: 15,
    textAlign: 'center',
    lineHeight: 22,
  },
  submitButton: { width: '100%', marginTop: 10 },
});
