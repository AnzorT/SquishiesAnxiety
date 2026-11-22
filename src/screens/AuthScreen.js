import React, { useEffect, useRef, useState } from 'react';
import { Animated, Keyboard, LayoutAnimation, Platform, StyleSheet, Text, UIManager, View } from 'react-native';
import { loginWithEmail, registerWithEmail, sendVerification, setKeepSignedIn } from '../firebase/auth';
import { SKIP_EMAIL_VERIFY } from '../webDebug';
import { startSocial } from '../firebase/social';
import { createUserProfile } from '../firebase/firestore';
import { authErrorMessage } from '../firebase/authErrors';
import { Btn, Lettering, FONT } from '../royal';
import { AuthBg, AuthHeader, Card, CheckRow, CREAM, Dots, Eye, Field, ModeSwitch, OrRow, ROOT_BG, tap, useAuthSizes, useFadeUp, useKeyboardLift } from './auth/kit';
import Socials from './auth/Socials';

// Log in / Register (2026-11-20: remodelled in the game's wood and gold, src/screens/auth/kit.js). The front door of
// the same game: the Main Menu's house softened behind, Mittens (live) beside the plush SQUISH SQUAD logo along the
// top, and under them one wood panel laid out sideways so it fits a landscape phone without scrolling (the user's
// layout of 2026-11-16): the Log in | Register switch (a gold pill springing across), email and password side by side
// (to register, the squad name and the age join that row, so the panel keeps its height), the gold button the
// panel's whole width with "Keep me signed in" under it, then OR and the Google / Facebook / TikTok row (the web flow
// in src/firebase/social.js; a provider not set up yet says so). An error takes the OR line's place, right under the
// button, so nothing moves. A new email account gets a verification link (App holds it at VerifyEmailScreen until it's
// tapped). Firebase Auth's onAuthStateChanged listener in App.js is what moves past this screen.
//
// The keyboard: each field's action key goes to the next one, the last one's logs in / registers; a keyboard drawn
// over the app lifts the panel so the fields and the button stay above it (useKeyboardLift); a tap outside the fields
// puts it away.

// Minimum age to create an account at all. Below this, registration is
// blocked outright — no email/nickname/age is ever sent to Firebase for that
// person: the age is checked on the device before anything else happens.
// This is the app's whole COPPA posture: rather than building a
// parental-consent flow, under-13 signups simply never reach the point of
// collecting personal information.
const MIN_SIGNUP_AGE = 13;

const TABS = [
  ['login', 'Log in'],
  ['register', 'Register'],
];

// Switching Log in ↔ Register opens or closes the register-only fields in the row with a native layout animation
// (the UI thread's, smooth however busy JS is).
if (Platform.OS === 'android' && UIManager.setLayoutAnimationEnabledExperimental) {
  UIManager.setLayoutAnimationEnabledExperimental(true);
}
const SWAP = {
  duration: 280,
  create: { type: LayoutAnimation.Types.easeInEaseOut, property: LayoutAnimation.Properties.opacity },
  update: { type: LayoutAnimation.Types.easeInEaseOut },
  delete: { type: LayoutAnimation.Types.easeInEaseOut, property: LayoutAnimation.Properties.opacity, duration: 140 },
};

export default function AuthScreen() {
  const z = useAuthSizes();
  const [mode, setMode] = useState('login'); // 'login' | 'register'
  const [ageInput, setAgeInput] = useState('');
  const [blocked, setBlocked] = useState(false);
  const [nickname, setNickname] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [showPass, setShowPass] = useState(false);
  const [keep, setKeep] = useState(true);
  const [error, setError] = useState('');
  const [submitting, setSubmitting] = useState(false);
  const [btnW, setBtnW] = useState(0);

  const isRegister = mode === 'register';
  const buttonLabel = isRegister ? 'CREATE MY SQUAD' : 'LOG IN';
  const labelStyle = useFadeUp(buttonLabel);

  // the fields' row and the button: what the keyboard must leave in sight
  const rowRef = useRef(null);
  const btnRef = useRef(null);
  const { lift, up, relift } = useKeyboardLift(() => [rowRef.current, btnRef.current]);
  // (a switch while typing changes the fields, not where the row is; measured again anyway once it's laid out)
  useEffect(() => {
    if (up) requestAnimationFrame(relift);
  }, [mode, blocked, up, relift]);
  const nameIn = useRef(null);
  const ageIn = useRef(null);
  const emailIn = useRef(null);
  const passIn = useRef(null);

  const submit = async () => {
    if (submitting) return;
    Keyboard.dismiss();
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
      if (nickname.trim().length < 2) {
        setError('Pick a squad name of at least 2 letters.');
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
        await setKeepSignedIn(keep);
        const user = await registerWithEmail(trimmedEmail, password);
        await createUserProfile(user.uid, {
          email: trimmedEmail,
          age,
          nickname,
        });
        // the link that proves the address is real (VerifyEmailScreen waits
        // for it); a failed send can be retried there
        if (!SKIP_EMAIL_VERIFY) await sendVerification().catch(() => {});   // (developer mode: no email, src/webDebug.js)
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
      await setKeepSignedIn(keep);
      await loginWithEmail(trimmedEmail, password);
    } catch (e) {
      setError(authErrorMessage(e));
      setSubmitting(false);
    }
  };

  const switchMode = (next) => {
    if (next === mode) return;
    LayoutAnimation.configureNext(SWAP);
    setMode(next);
    setError('');
    // Re-entering register always re-asks age from scratch.
    setAgeInput('');
    setBlocked(false);
  };

  // each field's action key: on to the next, the last one submits
  const next = (ref) => ({ returnKeyType: 'next', blurOnSubmit: false, onSubmitEditing: () => ref.current && ref.current.focus() });
  const trackW = z.cardW - 2 * z.padH;

  return (
    <View style={styles.root} onStartShouldSetResponder={() => up} onResponderRelease={() => Keyboard.dismiss()}>
      <AuthBg />
      <Animated.View style={[styles.col, { height: z.H, paddingVertical: z.top, transform: [{ translateY: lift }] }]} pointerEvents="box-none">
        <AuthHeader z={z} paused={up} />
        <View style={styles.area} pointerEvents="box-none">
          <Card z={z}>
            <ModeSwitch z={z} width={trackW} mode={mode} onChange={switchMode} tabs={TABS} />

            {blocked ? (
              <View style={styles.blocked}>
                <Lettering text="Ask a grown-up!" variant="gold" size={20} />
                <Text style={styles.blockedT}>This game needs a parent or guardian to help set up an account. Ask them to continue!</Text>
              </View>
            ) : (
              <>
                <View ref={rowRef} collapsable={false} style={[styles.row, isRegister && styles.rowReg]}>
                  {isRegister && (
                    <Field
                      z={z}
                      label="SQUAD NAME"
                      inputRef={nameIn}
                      value={nickname}
                      onChangeText={setNickname}
                      placeholder="Squishy"
                      maxLength={10}
                      autoCorrect={false}
                      style={styles.name}
                      {...next(ageIn)}
                    />
                  )}
                  {isRegister && (
                    <Field z={z} label="AGE" inputRef={ageIn} value={ageInput} onChangeText={setAgeInput} keyboardType="number-pad" placeholder="13+" maxLength={3} style={styles.age} {...next(emailIn)} />
                  )}
                  <Field
                    z={z}
                    label="EMAIL"
                    inputRef={emailIn}
                    value={email}
                    onChangeText={setEmail}
                    autoCapitalize="none"
                    autoCorrect={false}
                    autoComplete="email"
                    keyboardType="email-address"
                    placeholder="you@mail.com"
                    style={isRegister ? styles.emailReg : styles.flex}
                    {...next(passIn)}
                  />
                  <Field
                    z={z}
                    label="PASSWORD"
                    inputRef={passIn}
                    value={password}
                    onChangeText={setPassword}
                    secureTextEntry={!showPass}
                    autoCapitalize="none"
                    autoCorrect={false}
                    autoComplete={isRegister ? 'password-new' : 'password'}
                    // (to register it shares the row with three more fields: a shorter hint)
                    placeholder={isRegister ? '6+ chars' : '6+ characters'}
                    returnKeyType="go"
                    onSubmitEditing={submit}
                    style={isRegister ? styles.passReg : styles.flex}
                    right={<Eye shown={showPass} onPress={() => setShowPass((v) => !v)} />}
                  />
                </View>

                <View ref={btnRef} collapsable={false} onLayout={(e) => setBtnW(Math.round(e.nativeEvent.layout.width))}>
                  <Btn height={z.btn} radius={15} width={btnW || undefined} glint={!!btnW && !submitting} onPress={tap(submit)} style={styles.btn}>
                    {/* while it waits on the server: three dots hopping in the label's place */}
                    {submitting ? (
                      <Dots size={10} />
                    ) : (
                      <Animated.View style={labelStyle}>
                        <Lettering text={buttonLabel} variant="whiteB" size={z.btnFont} />
                      </Animated.View>
                    )}
                  </Btn>
                </View>
                <CheckRow on={keep} onToggle={() => setKeep((v) => !v)} label="Keep me signed in" />
                <OrRow error={error} />
                <Socials height={z.social} onPick={startSocial} />
              </>
            )}
          </Card>
        </View>
      </Animated.View>
    </View>
  );
}

const styles = StyleSheet.create({
  root: { flex: 1, backgroundColor: ROOT_BG, overflow: 'hidden' },
  // the header along the top (where the email check's is too), the panel centred under it; the screen's own height, so
  // a keyboard never squeezes it
  col: { position: 'absolute', left: 0, right: 0, top: 0, alignItems: 'center' },
  area: { flex: 1, alignSelf: 'stretch', alignItems: 'center', justifyContent: 'center' },
  flex: { flex: 1 },
  row: { flexDirection: 'row', gap: 8 },
  // (to register, four fields in one row, each wide enough for its hint: short hints since the panel got narrower on
  // 2026-11-21; the password's share is bigger for its Show / Hide)
  rowReg: { gap: 6 },
  name: { flex: 0.8 },
  age: { width: 56 },
  emailReg: { flex: 1.1 },
  passReg: { flex: 1.05 },
  btn: { alignSelf: 'stretch' },
  blocked: { alignItems: 'center', gap: 6, paddingVertical: 14, paddingHorizontal: 24 },
  blockedT: { fontFamily: FONT.bodyHeavy, fontSize: 15, lineHeight: 21, color: CREAM, textAlign: 'center', textShadowColor: 'rgba(80,40,12,0.75)', textShadowOffset: { width: 0, height: 1 }, textShadowRadius: 0.01 },
});
