import React, { useState } from 'react';
import { StyleSheet, Text, View } from 'react-native';
import ShadowText from '../components/candy/ShadowText';
import IntroBackground from '../squad/IntroBackground';
import RigCreature from '../components/RigCreature';
import Pressable from '../components/Pressable';
import HopDots from '../components/candy/HopDots';
import { BtnText, CandyBtn, F, PINK_RING } from '../squad/ui';
import { reloadVerified, sendVerification } from '../firebase/auth';

// Email verification (REDESIGN_V6 step 8, ruling 4: "make sure they are
// real"): an email/password account plays once its address is confirmed.
// Register sends the link; this waits for it — "I've verified" asks Firebase
// again, "Send it again" resends (Firebase limits how often), and "Log out"
// is the way back. It also catches accounts made before verification existed.

const PURPLE = '#45107a';

export default function VerifyEmailScreen({ email, onVerified, onLogout }) {
  const [busy, setBusy] = useState(false);
  const [note, setNote] = useState('');
  const check = async () => {
    if (busy) return;
    setBusy(true);
    try {
      if (await reloadVerified()) return onVerified();
      setNote("Not yet — tap the link in the email first. Check your spam folder too.");
    } catch (e) {
      setNote('Could not check right now. Try again in a moment.');
    } finally {
      setBusy(false);
    }
  };
  const resend = async () => {
    try {
      await sendVerification();
      setNote(`Sent again to ${email}.`);
    } catch (e) {
      setNote('Please wait a minute before sending another.');
    }
  };
  return (
    <IntroBackground>
      <View style={styles.col}>
        <RigCreature creatureKey="mittens" style={styles.mittens} />
        <ShadowText style={styles.title} shadows={[[0, 4, PURPLE], [2.5, 0, PURPLE], [-2.5, 0, PURPLE], [0, -2.5, PURPLE]]}>
          Check your email
        </ShadowText>
        <View style={styles.cardLip}>
          <View style={styles.card}>
            <Text style={styles.text}>
              We sent a link to <Text style={styles.email}>{email}</Text>. Tap it to confirm it's really you, then come back here.
            </Text>
            {!!note && <Text style={styles.note}>{note}</Text>}
            <CandyBtn kind="pink" onPress={check} padV={10} lip={5} stretch>
              {busy ? (
                <HopDots size={14} style={{ height: 26 }} />
              ) : (
                <BtnText ring={PINK_RING} size={20}>
                  I've verified
                </BtnText>
              )}
            </CandyBtn>
            <View style={styles.row}>
              <Pressable onPress={resend} hitSlop={8}>
                <Text style={styles.link}>Send it again</Text>
              </Pressable>
              <Pressable onPress={onLogout} hitSlop={8}>
                <Text style={styles.link}>Log out</Text>
              </Pressable>
            </View>
          </View>
        </View>
      </View>
    </IntroBackground>
  );
}

const styles = StyleSheet.create({
  col: { flex: 1, justifyContent: 'center', paddingHorizontal: 22, gap: 10 },
  mittens: { width: 150, height: 150, alignSelf: 'center' },
  title: { alignSelf: 'center', fontFamily: F.display, fontSize: 34, lineHeight: 40, color: '#ffffff' },
  cardLip: { borderRadius: 30, backgroundColor: '#d9c4f7', paddingBottom: 6 },
  card: { gap: 14, padding: 18, borderRadius: 28, backgroundColor: '#ffffff', borderWidth: 3, borderColor: '#ffffff' },
  text: { fontFamily: F.heavy, fontSize: 14, lineHeight: 20, color: PURPLE, textAlign: 'center' },
  email: { fontFamily: F.black, color: '#c02bd9' },
  note: { fontFamily: F.heavy, fontSize: 12.5, lineHeight: 17, color: '#d0345a', textAlign: 'center' },
  row: { flexDirection: 'row', justifyContent: 'space-between', paddingHorizontal: 6 },
  link: { fontFamily: F.black, fontSize: 13, color: '#8e1580' },
});
