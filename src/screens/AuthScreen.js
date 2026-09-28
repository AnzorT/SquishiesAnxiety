import React, { useEffect, useRef, useState } from 'react';
import { View, Text, TextInput, KeyboardAvoidingView, ScrollView, Platform, StyleSheet, Animated, Easing } from 'react-native';
import { loginWithEmail, registerWithEmail } from '../firebase/auth';
import { createUserProfile } from '../firebase/firestore';
import { authErrorMessage } from '../firebase/authErrors';
import { candyColors, candyFonts } from '../theme/candyTheme';
import CandyBackground from '../components/candy/CandyBackground';
import CandyButton from '../components/candy/CandyButton';
import CandyTabs from '../components/candy/CandyTabs';
import OutlinedTitle from '../components/candy/OutlinedTitle';

// Single Auth screen with a LOGIN/REGISTER toggle — the v3 look: pink sticker
// title, a glass tab bar whose pink pill springs between the two tabs, pale
// candy inputs, and a blue candy submit button whose label cross-fades when
// the mode changes. Firebase Auth's onAuthStateChanged listener in App.js is
// what actually advances past this screen — there's no local navigation
// call on success.

// Minimum age to create an account at all. Below this, registration is
// blocked outright — no email/nickname/age is ever collected or sent to
// Firebase for that person. This is the app's whole COPPA posture: rather
// than building a parental-consent flow, under-13 signups simply never
// reach the point of collecting personal information.
const MIN_SIGNUP_AGE = 13;

const AUTH_TABS = [
  { value: 'login', label: 'LOGIN' },
  { value: 'register', label: 'REGISTER' },
];

// Fields that slide/grow into place (the design's authFieldIn keyframe) —
// used for everything that appears when switching mode or gate stage.
function FieldIn({ children, stageKey }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    t.setValue(0);
    Animated.timing(t, { toValue: 1, duration: 420, easing: Easing.bezier(0.3, 1.2, 0.5, 1), useNativeDriver: true }).start();
  }, [t, stageKey]);
  const translateY = t.interpolate({ inputRange: [0, 1], outputRange: [-10, 0] });
  const scale = t.interpolate({ inputRange: [0, 1], outputRange: [0.96, 1] });
  return <Animated.View style={{ width: '100%', opacity: t, transform: [{ translateY }, { scale }] }}>{children}</Animated.View>;
}

function CandyInput(props) {
  return <TextInput placeholderTextColor="#a98bc9" {...props} style={[styles.input, props.style]} />;
}

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

  const stageKey = `${mode}-${gateStage}`;

  return (
    <CandyBackground>
      <KeyboardAvoidingView style={styles.flex} behavior={Platform.OS === 'ios' ? 'padding' : undefined}>
        <ScrollView contentContainerStyle={styles.scrollContent} keyboardShouldPersistTaps="handled" showsVerticalScrollIndicator={false}>
          <OutlinedTitle text={isRegister ? 'Join the Squad!' : 'Welcome Back!'} fill="pink" size={30} style={styles.title} />

          <CandyTabs options={AUTH_TABS} value={mode} onChange={switchMode} style={styles.tabBar} />

          {isRegister && gateStage === 'age' && (
            <FieldIn stageKey={stageKey}>
              <CandyInput value={ageInput} onChangeText={setAgeInput} keyboardType="number-pad" placeholder="How old are you?" maxLength={3} />
              {!!error && <Text style={styles.error}>{error}</Text>}
              <CandyButton label="CONTINUE" variant="blue" size="md" onPress={submitAgeGate} style={styles.submitButton} />
            </FieldIn>
          )}

          {isRegister && gateStage === 'blocked' && (
            <FieldIn stageKey={stageKey}>
              <View style={styles.blockedCard}>
                <Text style={styles.blockedText}>This game needs a parent or guardian to help set up an account. Ask them to continue!</Text>
              </View>
            </FieldIn>
          )}

          {isRegister && gateStage === 'form' && (
            <FieldIn stageKey={stageKey}>
              <CandyInput value={nickname} onChangeText={setNickname} placeholder="Nickname" />
              <CandyInput value={email} onChangeText={setEmail} autoCapitalize="none" keyboardType="email-address" placeholder="Email" />
              <CandyInput value={password} onChangeText={setPassword} secureTextEntry placeholder="Password" style={styles.lastInput} />
              {!!error && <Text style={styles.error}>{error}</Text>}
              <CandyButton label="CREATE ACCOUNT" variant="blue" size="md" onPress={submit} loading={submitting} style={styles.submitButton} />
            </FieldIn>
          )}

          {!isRegister && (
            <FieldIn stageKey={stageKey}>
              <CandyInput value={email} onChangeText={setEmail} autoCapitalize="none" keyboardType="email-address" placeholder="Email" />
              <CandyInput value={password} onChangeText={setPassword} secureTextEntry placeholder="Password" style={styles.lastInput} />
              {!!error && <Text style={styles.error}>{error}</Text>}
              <CandyButton label="ENTER THE SQUAD" variant="blue" size="md" onPress={submit} loading={submitting} style={styles.submitButton} />
            </FieldIn>
          )}
        </ScrollView>
      </KeyboardAvoidingView>
    </CandyBackground>
  );
}

const styles = StyleSheet.create({
  flex: { flex: 1 },
  scrollContent: { flexGrow: 1, alignItems: 'center', justifyContent: 'center', paddingHorizontal: 28, paddingVertical: 40 },
  title: { marginBottom: 16 },
  tabBar: { width: '100%', marginBottom: 20 },
  input: {
    width: '100%',
    borderRadius: 14,
    borderWidth: 2,
    borderColor: candyColors.inkSoft,
    backgroundColor: candyColors.paper,
    color: candyColors.ink,
    fontFamily: candyFonts.body,
    fontSize: 15,
    paddingHorizontal: 16,
    paddingVertical: 13,
    marginBottom: 12,
  },
  lastInput: { marginBottom: 14 },
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
    marginBottom: 10,
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
  submitButton: { width: '100%', marginTop: 4 },
});
