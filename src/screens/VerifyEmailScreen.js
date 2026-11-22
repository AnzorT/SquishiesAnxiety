import React, { useState } from 'react';
import { Animated, StyleSheet, Text, View } from 'react-native';
import { Btn, Icon, InkText, Lettering, Plaque, FONT } from '../royal';
import { reloadVerified, sendVerification } from '../firebase/auth';
import { AuthBg, AuthHeader, Card, CREAM, Dots, ErrorPill, GOLD_TXT, ROOT_BG, tap, useAuthSizes, useFadeUp } from './auth/kit';

// Email verification (REDESIGN_V6 step 8, ruling 4: "make sure they are
// real"): an email/password account plays once its address is confirmed.
// Register sends the link; this waits for it — "I've verified" asks Firebase
// again, "Send it again" resends (Firebase limits how often), and "Log out"
// is the way back. It also catches accounts made before verification existed.
//
// 2026-11-20: the sign-in screen's look (src/screens/auth/kit.js): the house behind, Mittens and the logo along the top
// where they stood on the sign-in screen (so only the panel changes after registering), and a wood panel with the gold
// title, the address, the gold button and two wood buttons.

const MAIL = 'M3.5 6.5h17v11h-17Z M4 7l8 6.2L20 7';

export default function VerifyEmailScreen({ email, onVerified, onLogout }) {
  const z = useAuthSizes();
  const [busy, setBusy] = useState(false);
  const [note, setNote] = useState({ text: '', bad: false });
  const [btnW, setBtnW] = useState(0);
  const noteStyle = useFadeUp(note.text);
  const check = async () => {
    if (busy) return;
    setBusy(true);
    try {
      if (await reloadVerified()) return onVerified();
      setNote({ text: 'Not yet — tap the link in the email first. Check your spam folder too.', bad: true });
    } catch (e) {
      setNote({ text: 'Could not check right now. Try again in a moment.', bad: true });
    } finally {
      setBusy(false);
    }
  };
  const resend = async () => {
    try {
      await sendVerification();
      setNote({ text: `Sent again to ${email}.`, bad: false });
    } catch (e) {
      setNote({ text: 'Please wait a minute before sending another.', bad: true });
    }
  };
  const cardW = Math.min(z.cardW, z.H < 376 ? 470 : 500);
  return (
    <View style={styles.root}>
      <AuthBg />
      <View style={[styles.col, { height: z.H, paddingVertical: z.top }]}>
        <AuthHeader z={z} />
        <View style={styles.area}>
          <Card z={z} width={cardW} style={styles.card}>
            <View style={styles.title}>
              <Icon d={MAIL} size={26} color={GOLD_TXT} width={2.4} />
              <Lettering text="Check your email" variant="gold" size={z.H < 376 ? 21 : 23} />
            </View>
            <Text style={styles.text}>
              We sent a link to <Text style={styles.email}>{email}</Text>. Tap it to confirm it's really you, then come back here.
            </Text>
            {/* (the note's line is always there, so the buttons don't move when it shows) */}
            <View style={styles.noteRow}>
              {note.text ? (
                <Animated.View style={[styles.noteWrap, noteStyle]}>
                  {note.bad ? (
                    <ErrorPill text={note.text} lines={2} />
                  ) : (
                    <Text style={styles.sent} numberOfLines={2}>
                      {note.text}
                    </Text>
                  )}
                </Animated.View>
              ) : null}
            </View>
            <View onLayout={(e) => setBtnW(Math.round(e.nativeEvent.layout.width))}>
              <Btn height={z.btn} radius={15} width={btnW || undefined} glint={!!btnW && !busy} onPress={tap(check)} style={styles.btn}>
                {/* (an en space between the words: the thick outline closed up a plain one) */}
                {busy ? <Dots size={10} /> : <Lettering text={'I\u2019VE\u2002VERIFIED'} variant="whiteB" size={z.btnFont} />}
              </Btn>
            </View>
            <View style={styles.links}>
              <Plaque variant="vel" radius={14} onPress={tap(resend)} hitSlop={4} style={[styles.link, { height: z.social }]}>
                <Icon d="M4 12a8 8 0 1 0 2.3-5.7 M4 4v4h4" size={17} width={2.4} />
                <InkText size={15}>Send it again</InkText>
              </Plaque>
              <Plaque variant="vel" radius={14} onPress={tap(onLogout)} hitSlop={4} style={[styles.link, { height: z.social }]}>
                <Icon d="M14 5h5v14h-5 M10 8l-4 4 4 4 M6 12h10" size={17} width={2.4} />
                <InkText size={15}>Log out</InkText>
              </Plaque>
            </View>
          </Card>
        </View>
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  root: { flex: 1, backgroundColor: ROOT_BG, overflow: 'hidden' },
  // (as the sign-in screen's: the header where it was there, the panel centred under it)
  col: { position: 'absolute', left: 0, right: 0, top: 0, alignItems: 'center' },
  area: { flex: 1, alignSelf: 'stretch', alignItems: 'center', justifyContent: 'center' },
  card: { alignItems: 'stretch' },
  title: { flexDirection: 'row', alignItems: 'center', justifyContent: 'center', gap: 8 },
  text: { fontFamily: FONT.bodyHeavy, fontSize: 14.5, lineHeight: 20, color: CREAM, textAlign: 'center', paddingHorizontal: 6, textShadowColor: 'rgba(80,40,12,0.75)', textShadowOffset: { width: 0, height: 1 }, textShadowRadius: 0.01 },
  email: { fontFamily: FONT.bodyBlack, color: GOLD_TXT },
  noteRow: { minHeight: 20, marginVertical: -3, alignItems: 'center', justifyContent: 'center' },
  noteWrap: { maxWidth: '100%' },
  sent: { fontFamily: FONT.bodyBlack, fontSize: 12.5, lineHeight: 16, color: '#d6ffb8', textAlign: 'center', textShadowColor: 'rgba(40,60,10,0.8)', textShadowOffset: { width: 0, height: 1 }, textShadowRadius: 0.01 },
  btn: { alignSelf: 'stretch' },
  links: { flexDirection: 'row', gap: 12 },
  link: { flex: 1, flexDirection: 'row', gap: 8 },
});
