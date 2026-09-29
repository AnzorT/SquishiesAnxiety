import React, { useEffect, useRef, useState } from 'react';
import { View, Text, TextInput, KeyboardAvoidingView, ScrollView, Platform, StyleSheet, Animated, Easing } from 'react-native';
import { loginWithEmail, registerWithEmail } from '../firebase/auth';
import { createUserProfile } from '../firebase/firestore';
import { authErrorMessage } from '../firebase/authErrors';
import { candyColors, candyFonts } from '../theme/candyTheme';
import CandyBackground from '../components/candy/CandyBackground';
import CandyButton, { ButtonText } from '../components/candy/CandyButton';
import CandyTabs from '../components/candy/CandyTabs';
import OutlinedTitle from '../components/candy/OutlinedTitle';

// Single Auth screen with a LOGIN/REGISTER toggle — the v3 look: pink sticker
// title, a glass tab bar whose pink pill springs between the two tabs, pale
// candy inputs, and a blue candy submit button. As in the design, REGISTER
// only grows one extra row above Email (authFieldIn); nothing else on the
// screen is re-animated or resized, and switching back folds it away again
// (authFieldOut). The button caption fades up when it changes (authTextIn).
// Firebase Auth's onAuthStateChanged listener in App.js is what actually
// advances past this screen — there's no local navigation call on success.

// Minimum age to create an account at all. Below this, registration is
// blocked outright — no email/nickname/age is ever sent to Firebase for that
// person: the age is checked on the device before anything else happens.
// This is the app's whole COPPA posture: rather than building a
// parental-consent flow, under-13 signups simply never reach the point of
// collecting personal information.
const MIN_SIGNUP_AGE = 13;

const AUTH_TABS = [
  { value: 'login', label: 'LOGIN' },
  { value: 'register', label: 'REGISTER' },
];

const ROW_GAP = 12;
// the design's input: 14px padding, 15px text, 2px border
const INPUT_H = 52;

// The register-only row: grows open from nothing (height, 12px gap, a small
// drop and scale-up, fading in) and folds shut again when leaving REGISTER.
function ExtraRow({ open, children }) {
  const [mounted, setMounted] = useState(open);
  const t = useRef(new Animated.Value(open ? 1 : 0)).current;
  useEffect(() => {
    if (open) setMounted(true);
    Animated.timing(t, {
      toValue: open ? 1 : 0,
      duration: open ? 420 : 360,
      easing: open ? Easing.bezier(0.3, 1.2, 0.5, 1) : Easing.bezier(0.42, 0, 1, 1),
      useNativeDriver: false, // height
    }).start(({ finished }) => {
      if (finished && !open) setMounted(false);
    });
  }, [open, t]);
  if (!mounted) return null;
  return (
    <Animated.View
      style={{
        width: '100%',
        overflow: 'hidden',
        height: t.interpolate({ inputRange: [0, 1], outputRange: [0, INPUT_H + ROW_GAP] }),
        opacity: t.interpolate({ inputRange: [0, 0.6, 1], outputRange: [0, 1, 1] }),
        transform: [
          { translateY: t.interpolate({ inputRange: [0, 1], outputRange: [-10, 0] }) },
          { scale: t.interpolate({ inputRange: [0, 1], outputRange: [0.96, 1] }) },
        ],
      }}
    >
      {children}
    </Animated.View>
  );
}

// Caption that fades up whenever its text changes (authTextIn).
function useFadeUp(text) {
  const t = useRef(new Animated.Value(1)).current;
  const first = useRef(true);
  useEffect(() => {
    if (first.current) {
      first.current = false;
      return;
    }
    t.setValue(0);
    Animated.timing(t, { toValue: 1, duration: 300, easing: Easing.out(Easing.quad), useNativeDriver: true }).start();
  }, [text, t]);
  return { opacity: t, transform: [{ translateY: t.interpolate({ inputRange: [0, 1], outputRange: [6, 0] }) }] };
}

function CandyInput(props) {
  return <TextInput placeholderTextColor="#a98bc9" {...props} style={[styles.input, props.style]} />;
}

export default function AuthScreen() {
  const [mode, setMode] = useState('login'); // 'login' | 'register'
  const [ageInput, setAgeInput] = useState('');
  const [blocked, setBlocked] = useState(false);
  const [nickname, setNickname] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const [submitting, setSubmitting] = useState(false);

  const isRegister = mode === 'register';
  const buttonLabel = isRegister ? 'CREATE ACCOUNT' : 'ENTER THE SQUAD';
  const labelStyle = useFadeUp(buttonLabel);

  const submit = async () => {
    const trimmedEmail = email.trim();

    if (isRegister) {
      // age first — nothing else is looked at, let alone sent, before it
      const age = parseInt(ageInput, 10);
      if (!ageInput || Number.isNaN(age) || age < 1 || age > 120) {
        setError('Enter your age.');
        return;
      }
      if (age < MIN_SIGNUP_AGE) {
        setError('');
        setBlocked(true);
        return;
      }
      if (!trimmedEmail || !password) {
        setError('Enter your email and password.');
        return;
      }
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

    if (!trimmedEmail || !password) {
      setError('Enter your email and password.');
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
    setAgeInput('');
    setBlocked(false);
  };

  return (
    <CandyBackground>
      <KeyboardAvoidingView style={styles.flex} behavior={Platform.OS === 'ios' ? 'padding' : undefined}>
        <ScrollView contentContainerStyle={styles.scrollContent} keyboardShouldPersistTaps="handled" showsVerticalScrollIndicator={false}>
          <OutlinedTitle text="Welcome Back!" fill="pink" size={30} outline={3} ring={2} drop={5} style={styles.title} />

          <CandyTabs options={AUTH_TABS} value={mode} onChange={switchMode} style={styles.tabBar} />

          {blocked ? (
            <View style={styles.blockedCard}>
              <Text style={styles.blockedText}>This game needs a parent or guardian to help set up an account. Ask them to continue!</Text>
            </View>
          ) : (
            <>
              <ExtraRow open={isRegister}>
                <View style={styles.row}>
                  <CandyInput value={nickname} onChangeText={setNickname} placeholder="Nickname" style={styles.nickname} />
                  <CandyInput value={ageInput} onChangeText={setAgeInput} keyboardType="number-pad" placeholder="Age" maxLength={3} style={styles.age} />
                </View>
              </ExtraRow>
              <CandyInput value={email} onChangeText={setEmail} autoCapitalize="none" keyboardType="email-address" placeholder="Email" style={styles.gap} />
              <CandyInput value={password} onChangeText={setPassword} secureTextEntry placeholder="Password" style={styles.lastInput} />
              {!!error && <Text style={styles.error}>{error}</Text>}
              <CandyButton variant="blue" size="auth" onPress={submit} loading={submitting} style={styles.submitButton}>
                <Animated.View style={labelStyle}>
                  <ButtonText ring="#0c5a9c" size={17} style={styles.caption}>
                    {buttonLabel}
                  </ButtonText>
                </Animated.View>
              </CandyButton>
            </>
          )}
        </ScrollView>
      </KeyboardAvoidingView>
    </CandyBackground>
  );
}

const styles = StyleSheet.create({
  flex: { flex: 1 },
  scrollContent: { flexGrow: 1, alignItems: 'center', justifyContent: 'center', paddingHorizontal: 28, paddingVertical: 40 },
  // the sticker's SVG carries 5px of outline + 5px drop below the letters
  title: { marginBottom: 12 },
  tabBar: { width: '100%', marginBottom: 20 },
  row: { flexDirection: 'row', gap: 10 },
  nickname: { flex: 1 },
  age: { width: 84, textAlign: 'center' },
  input: {
    width: '100%',
    borderRadius: 14,
    borderWidth: 2,
    borderColor: candyColors.inkSoft,
    backgroundColor: candyColors.paper,
    color: candyColors.ink,
    fontFamily: candyFonts.body,
    fontSize: 15,
    height: INPUT_H,
    paddingHorizontal: 16,
    paddingVertical: 0,
  },
  gap: { marginBottom: ROW_GAP },
  lastInput: { marginBottom: 22 },
  error: {
    width: '100%',
    color: '#ffffff',
    backgroundColor: 'rgba(229,72,77,0.85)',
    borderRadius: 10,
    overflow: 'hidden',
    paddingHorizontal: 12,
    paddingVertical: 6,
    fontFamily: candyFonts.body,
    fontSize: 13,
    marginTop: -10,
    marginBottom: 12,
  },
  blockedCard: {
    width: '100%',
    backgroundColor: candyColors.sheet,
    borderRadius: 18,
    borderWidth: 2,
    borderColor: candyColors.inkSoft,
    padding: 18,
  },
  blockedText: {
    color: candyColors.ink,
    fontFamily: candyFonts.body,
    fontSize: 15,
    textAlign: 'center',
    lineHeight: 22,
  },
  submitButton: { width: '100%' },
  caption: { letterSpacing: 0.5 },
});
