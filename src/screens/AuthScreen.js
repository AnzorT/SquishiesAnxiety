import React, { useEffect, useRef, useState } from 'react';
import { View, Text, TextInput, KeyboardAvoidingView, ScrollView, Platform, StyleSheet, Animated, Easing, LayoutAnimation, UIManager } from 'react-native';
import Pressable from '../components/Pressable';
import Svg, { Circle, Path } from 'react-native-svg';
import { LinearGradient } from 'expo-linear-gradient';
import { loginWithEmail, registerWithEmail, sendVerification, setKeepSignedIn } from '../firebase/auth';
import { startSocial } from '../firebase/social';
import RigCreature from '../components/RigCreature';
import { createUserProfile } from '../firebase/firestore';
import { authErrorMessage } from '../firebase/authErrors';
import TutTarget from '../tutorial/Target';
import ShadowText from '../components/candy/ShadowText';
import IntroBackground from '../squad/IntroBackground';
import HopDots from '../components/candy/HopDots';
import { BtnText, CandyBtn, F, PINK, PINK_RING } from '../squad/ui';

// Log in / Register, from the app shell of "Squish Squad App.html": the
// white outlined "Squish Squad" title and a line under it, then one white
// card with the Log in / Register switch (a pink pill that springs across),
// labelled fields, the pink submit button and "Keep me signed in"; since
// REDESIGN_V6 step 8 also the design's live Mittens on top and its OR +
// Google / Facebook / TikTok row (the web flow in src/firebase/social.js; a
// provider not set up yet says so). A new email account gets a verification
// link (App holds it at VerifyEmailScreen until it's tapped).
// Register grows one row above Email: the squad name, plus the age, which
// the design doesn't have but our COPPA gate needs. Firebase Auth's
// onAuthStateChanged listener in App.js is what moves past this screen.

// Minimum age to create an account at all. Below this, registration is
// blocked outright — no email/nickname/age is ever sent to Firebase for that
// person: the age is checked on the device before anything else happens.
// This is the app's whole COPPA posture: rather than building a
// parental-consent flow, under-13 signups simply never reach the point of
// collecting personal information.
const MIN_SIGNUP_AGE = 13;

const PURPLE = '#45107a';
const LABEL = '#6a3d9a';
const INK = '#4a1a73';
const LINE = '#e3cff5';
const FOCUS = '#c02bd9';

const GAP = 11; // the card's row gap
const INPUT_H = 48;
const FIELD_H = 16 + 4 + INPUT_H; // label, gap, input

// Switching Log in ↔ Register opens or closes the register-only row (squad
// name + age) with a native layout animation: it runs on the UI thread, so
// it stays smooth however busy JS is (the old height animation was driven
// from JS and stuttered). Under the card, a spacer shrinks by exactly what
// the row adds (same animation), so the centred column keeps its height and
// the title and the line under it never move; only the card's lower part
// does.
if (Platform.OS === 'android' && UIManager.setLayoutAnimationEnabledExperimental) {
  UIManager.setLayoutAnimationEnabledExperimental(true);
}
const SWAP = {
  duration: 300,
  create: { type: LayoutAnimation.Types.easeInEaseOut, property: LayoutAnimation.Properties.opacity },
  update: { type: LayoutAnimation.Types.easeInEaseOut },
  delete: { type: LayoutAnimation.Types.easeInEaseOut, property: LayoutAnimation.Properties.opacity, duration: 150 },
};
const EXTRA_H = FIELD_H + GAP; // the register row and the card gap it brings

// A line that fades up whenever its text changes.
function useFadeUp(text) {
  const t = useRef(new Animated.Value(1)).current;
  const first = useRef(true);
  useEffect(() => {
    if (first.current) {
      first.current = false;
      return;
    }
    t.setValue(0);
    Animated.timing(t, {
      toValue: 1,
      duration: 300,
      easing: Easing.out(Easing.quad),
      useNativeDriver: true,
    }).start();
  }, [text, t]);
  return {
    opacity: t,
    transform: [
      {
        translateY: t.interpolate({ inputRange: [0, 1], outputRange: [6, 0] }),
      },
    ],
  };
}

// "EMAIL" over a white rounded input whose border turns pink while focused;
// `right` sits inside the input's right end (the password's Show / Hide).
function Field({ label, style, right, ...input }) {
  const [focus, setFocus] = useState(false);
  return (
    <View style={style}>
      <Text style={styles.label}>{label}</Text>
      <View>
        <TextInput
          placeholderTextColor="#a98bc9"
          {...input}
          onFocus={() => setFocus(true)}
          onBlur={() => setFocus(false)}
          style={[styles.input, focus && { borderColor: FOCUS }, right && { paddingRight: 64 }, input.style]}
        />
        {right}
      </View>
    </View>
  );
}

// Log in | Register: a lilac track with the pink pill under the chosen side
function ModeSwitch({ mode, onChange }) {
  const [w, setW] = useState(0);
  const x = useRef(new Animated.Value(mode === 'register' ? 1 : 0)).current;
  useEffect(() => {
    Animated.timing(x, {
      toValue: mode === 'register' ? 1 : 0,
      duration: 350,
      easing: Easing.bezier(0.3, 1.3, 0.5, 1),
      useNativeDriver: true,
    }).start();
  }, [mode, x]);
  const half = (w - 8) / 2;
  return (
    <View style={styles.track} onLayout={(e) => setW(e.nativeEvent.layout.width)}>
      {w ? (
        <Animated.View
          style={[
            styles.pill,
            {
              width: half,
              transform: [
                {
                  translateX: x.interpolate({
                    inputRange: [0, 1],
                    outputRange: [0, half],
                  }),
                },
              ],
            },
          ]}
        >
          <View style={styles.pillRing} />
          <LinearGradient colors={PINK} locations={[0, 0.55, 1]} style={styles.pillFace} />
        </Animated.View>
      ) : null}
      {[
        ['login', 'Log in'],
        ['register', 'Register'],
      ].map(([value, label]) => (
        <Pressable key={value} onPress={() => onChange(value)} style={styles.tab}>
          <Text style={[styles.tabText, { color: mode === value ? '#ffffff' : LABEL }]}>{label}</Text>
        </Pressable>
      ))}
    </View>
  );
}

function Tick() {
  return (
    <Svg width={12} height={12} viewBox="0 0 12 12">
      <Path d="M2.5 6.2 L5 8.6 L9.6 3.4" stroke="#ffffff" strokeWidth={2.2} fill="none" strokeLinecap="round" strokeLinejoin="round" />
    </Svg>
  );
}

export default function AuthScreen() {
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
  // the register row's real height plus the card's gap (measured the first
  // time it opens; until then the computed one)
  const [extraH, setExtraH] = useState(EXTRA_H);

  const isRegister = mode === 'register';
  const buttonLabel = isRegister ? 'Create my squad' : 'Log in';
  const labelStyle = useFadeUp(buttonLabel);

  const submit = async () => {
    if (submitting) return;
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
        await sendVerification().catch(() => {});
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

  return (
    <IntroBackground>
      <KeyboardAvoidingView style={styles.flex} behavior={Platform.OS === 'ios' ? 'padding' : undefined}>
        <ScrollView contentContainerStyle={styles.scrollContent} keyboardShouldPersistTaps="handled" showsVerticalScrollIndicator={false}>
          <RigCreature creatureKey="mittens" style={styles.mittens} />
          <ShadowText
            style={styles.title}
            shadows={[
              [0, 4, PURPLE],
              [2.5, 0, PURPLE],
              [-2.5, 0, PURPLE],
              [0, -2.5, PURPLE],
            ]}
          >
            Squish Squad
          </ShadowText>
          {/* one line for both modes: it stays put while the card changes */}
          <Text style={styles.sub}>Log in or make an account to save your squad.</Text>

          <View style={styles.cardLip}>
            <View style={styles.card}>
              <ModeSwitch mode={mode} onChange={switchMode} />

              {blocked ? (
                <Text style={styles.blocked}>This game needs a parent or guardian to help set up an account. Ask them to continue!</Text>
              ) : (
                <>
                  {isRegister && (
                    <View style={styles.row} onLayout={(e) => setExtraH(Math.round(e.nativeEvent.layout.height) + GAP)}>
                      <Field label="SQUAD NAME" value={nickname} onChangeText={setNickname} placeholder="Captain Squish" maxLength={10} style={styles.flex} />
                      <Field label="AGE" value={ageInput} onChangeText={setAgeInput} keyboardType="number-pad" placeholder="13+" maxLength={3} style={styles.age} />
                    </View>
                  )}
                  <Field label="EMAIL" value={email} onChangeText={setEmail} autoCapitalize="none" autoComplete="email" keyboardType="email-address" placeholder="you@example.com" />
                  <Field
                    label="PASSWORD"
                    value={password}
                    onChangeText={setPassword}
                    secureTextEntry={!showPass}
                    autoCapitalize="none"
                    placeholder="At least 6 characters"
                    right={
                      <Pressable onPress={() => setShowPass((v) => !v)} hitSlop={8} style={styles.eye}>
                        <Text style={styles.eyeText}>{showPass ? 'Hide' : 'Show'}</Text>
                      </Pressable>
                    }
                  />
                  {!!error && <Text style={styles.error}>{error}</Text>}
                  <TutTarget name="enter">
                    <CandyBtn kind="pink" onPress={submit} disabled={submitting} padV={10} lip={5} stretch>
                      {/* while it waits on the server: the loading screen's hopping dots */}
                      {submitting ? (
                        <HopDots size={14} style={styles.dots} />
                      ) : (
                        <Animated.View style={labelStyle}>
                          <BtnText ring={PINK_RING} size={20}>
                            {buttonLabel}
                          </BtnText>
                        </Animated.View>
                      )}
                    </CandyBtn>
                  </TutTarget>
                  <Pressable onPress={() => setKeep((v) => !v)} style={styles.keep} hitSlop={6}>
                    {keep ? (
                      <LinearGradient colors={['#ff8fd8', '#c02bd9']} style={styles.box}>
                        <Tick />
                      </LinearGradient>
                    ) : (
                      <View style={styles.box} />
                    )}
                    <Text style={styles.keepText}>Keep me signed in</Text>
                  </Pressable>
                  <View style={styles.orRow}>
                    <View style={styles.orLine} />
                    <Text style={styles.orText}>OR</Text>
                    <View style={styles.orLine} />
                  </View>
                  <View style={styles.socials}>
                    {SOCIALS.map(([id, label, Icon]) => (
                      <Pressable key={id} onPress={() => startSocial(id)} style={({ pressed }) => [styles.social, pressed && { transform: [{ translateY: 2 }] }]}>
                        <Icon />
                        <Text style={styles.socialText}>{label}</Text>
                      </Pressable>
                    ))}
                  </View>
                </>
              )}
            </View>
          </View>
          {/* room the register row takes when it's open (see SWAP) */}
          <View style={{ height: isRegister ? 0 : extraH }} />
        </ScrollView>
      </KeyboardAvoidingView>
    </IntroBackground>
  );
}

// the three social buttons' logos
const GoogleLogo = () => (
  <Svg width={26} height={26} viewBox="0 0 24 24">
    <Path d="M21.6 12.2c0-.7-.1-1.4-.2-2H12v3.8h5.4a4.6 4.6 0 0 1-2 3v2.5h3.2c1.9-1.7 3-4.3 3-7.3z" fill="#4285F4" />
    <Path d="M12 22c2.7 0 5-.9 6.6-2.5l-3.2-2.5c-.9.6-2 1-3.4 1a5.9 5.9 0 0 1-5.6-4.1H3.1v2.6A10 10 0 0 0 12 22z" fill="#34A853" />
    <Path d="M6.4 13.9a6 6 0 0 1 0-3.8V7.5H3.1a10 10 0 0 0 0 9z" fill="#FBBC05" />
    <Path d="M12 6c1.5 0 2.8.5 3.8 1.5l2.9-2.9A10 10 0 0 0 3.1 7.5l3.3 2.6A5.9 5.9 0 0 1 12 6z" fill="#EA4335" />
  </Svg>
);
const FacebookLogo = () => (
  <Svg width={26} height={26} viewBox="0 0 24 24">
    <Circle cx={12} cy={12} r={11} fill="#1877F2" />
    <Path d="M13.2 19v-6.1h2.1l.3-2.4h-2.4V9c0-.7.2-1.2 1.2-1.2h1.3V5.7c-.2 0-1-.1-1.9-.1-1.9 0-3.1 1.1-3.1 3.2v1.7H8.6v2.4h2.1V19z" fill="#ffffff" />
  </Svg>
);
const TT = 'M14.6 6.5c.4 1.3 1.4 2.2 2.7 2.3v2a4.6 4.6 0 0 1-2.7-.9v4.2a3.6 3.6 0 1 1-3.6-3.6h.4v2.1a1.5 1.5 0 1 0 1.1 1.5V6.5z';
const TikTokLogo = () => (
  <Svg width={26} height={26} viewBox="0 0 24 24">
    <Circle cx={12} cy={12} r={11} fill="#111111" />
    <Path d={TT} fill="#25F4EE" transform="translate(-0.5,-0.4)" />
    <Path d={TT} fill="#FE2C55" transform="translate(0.5,0.4)" />
    <Path d={TT} fill="#ffffff" />
  </Svg>
);
const SOCIALS = [
  ['google', 'Google', GoogleLogo],
  ['facebook', 'Facebook', FacebookLogo],
  ['tiktok', 'TikTok', TikTokLogo],
];

const styles = StyleSheet.create({
  flex: { flex: 1 },
  mittens: { width: 130, height: 130, alignSelf: 'center', marginBottom: -6 },
  orRow: { flexDirection: 'row', alignItems: 'center', gap: 10, marginTop: 2 },
  orLine: { flex: 1, height: 2, borderRadius: 1, backgroundColor: '#ece0f8' },
  orText: { fontFamily: F.black, fontSize: 10.5, letterSpacing: 1.2, color: '#a98bc9' },
  socials: { flexDirection: 'row', gap: 7 },
  social: { flex: 1, alignItems: 'center', gap: 4, paddingTop: 10, paddingBottom: 8, borderRadius: 16, backgroundColor: '#ffffff', borderWidth: 2.5, borderColor: '#ece0f8', borderBottomWidth: 5 },
  socialText: { fontFamily: F.black, fontSize: 11, color: '#45107a' },
  // the dots (14 + 7 hop room) in the label's place: about the label's
  // line height, so the button keeps its size
  dots: { height: 26 },
  scrollContent: {
    flexGrow: 1,
    justifyContent: 'center',
    paddingHorizontal: 22,
    paddingVertical: 40,
  },
  title: {
    alignSelf: 'center',
    fontFamily: F.display,
    fontSize: 38,
    lineHeight: 44,
    color: '#ffffff',
  },
  sub: {
    alignSelf: 'center',
    textAlign: 'center',
    fontFamily: F.heavy,
    fontSize: 13.5,
    color: PURPLE,
    marginTop: 6,
    marginBottom: 12,
  },
  // the card: 90% white over the sky (drawn opaque, so the lip doesn't show
  // through it), a 3px white rim and a 6px lilac lip under it
  cardLip: { borderRadius: 28, backgroundColor: '#d6b8ee', paddingBottom: 6 },
  card: {
    borderRadius: 28,
    borderWidth: 3,
    borderColor: '#ffffff',
    backgroundColor: '#fcfaff',
    paddingTop: 14,
    paddingHorizontal: 16,
    paddingBottom: 16,
    gap: GAP,
  },
  track: {
    flexDirection: 'row',
    borderRadius: 999,
    backgroundColor: '#f1e4ff',
    padding: 4,
  },
  // the pill: the pink face in a 2px ring with a 3px lip
  pill: { position: 'absolute', top: 4, bottom: 4, left: 4 },
  pillRing: {
    position: 'absolute',
    left: -2,
    right: -2,
    top: -2,
    bottom: -5,
    borderRadius: 999,
    backgroundColor: PINK_RING,
  },
  pillFace: { ...StyleSheet.absoluteFillObject, borderRadius: 999 },
  tab: { flex: 1, alignItems: 'center', paddingVertical: 9 },
  tabText: { fontFamily: F.display, fontSize: 16 },
  row: { flexDirection: 'row', gap: 10 },
  age: { width: 84 },
  label: {
    fontFamily: F.black,
    fontSize: 11,
    lineHeight: 16,
    letterSpacing: 1,
    color: LABEL,
    marginBottom: 4,
  },
  input: {
    height: INPUT_H,
    borderRadius: 16,
    borderWidth: 2.5,
    borderColor: LINE,
    backgroundColor: '#ffffff',
    color: INK,
    fontFamily: F.heavy,
    fontSize: 15,
    paddingHorizontal: 14,
    paddingVertical: 0,
  },
  eye: {
    position: 'absolute',
    right: 12,
    top: 0,
    bottom: 0,
    justifyContent: 'center',
  },
  eyeText: { fontFamily: F.black, fontSize: 12, color: FOCUS },
  error: {
    fontFamily: F.heavy,
    fontSize: 12.5,
    lineHeight: 17,
    color: '#c4204f',
    backgroundColor: '#ffe6ee',
    borderRadius: 12,
    overflow: 'hidden',
    paddingHorizontal: 11,
    paddingVertical: 8,
  },
  blocked: {
    fontFamily: F.heavy,
    fontSize: 15,
    lineHeight: 22,
    color: INK,
    textAlign: 'center',
    paddingVertical: 8,
  },
  keep: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: 8,
    alignSelf: 'flex-start',
  },
  box: {
    width: 20,
    height: 20,
    borderRadius: 7,
    borderWidth: 2.5,
    borderColor: FOCUS,
    backgroundColor: '#ffffff',
    alignItems: 'center',
    justifyContent: 'center',
  },
  keepText: { fontFamily: F.heavy, fontSize: 13, color: INK },
});
