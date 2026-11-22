import React from 'react';
import { StyleSheet, Text, View } from 'react-native';
import OutlinedTitle from '../components/candy/OutlinedTitle';
import { PopIn, Rock, SlideIn } from '../squishdoku/fx';
import { Overlay, Split } from '../squishdoku/Overlays';
import { BtnLabel, Head, SdButton } from '../squishdoku/ui';
import { F, INK } from '../squishdoku/theme';
import { HEARTS } from './levels';

// Squish Sort's cards over the game: the win (stars popping in one by one,
// coins counting up), the fail (out of hearts or time), pause, and how to
// play.

// (the result card is the shared one: squishdoku/Overlays.js ResultCard)
// its titles here, for 1, 2 and 3 stars
export const RESULT_TITLES = ['SORTED!', 'NICE SORTING!', 'PERFECT MEMORY!'];

// Out of hearts, or out of time: the right spots were shown on the shelves.
export function FailCard({ visible, reason, uri, onRetry, onHub }) {
  return (
    <Overlay visible={visible} tint="rgba(80,0,30,0.5)" column>
      <PopIn trigger={visible} delay={60}>
        <OutlinedTitle text={reason === 'time' ? "TIME'S UP!" : 'OH NO!'} size={32} fill="gold" />
      </PopIn>
      <PopIn trigger={visible} delay={220}>
        <Rock deg={8} ms={1800}>
          <Head uri={uri} size={86} dim ring="#ffffff" bg="#efe9f5" />
        </Rock>
      </PopIn>
      <Split />
      <Text style={styles.body}>{reason === 'time' ? 'The clock ran out. You saw where they go. Try again!' : `${HEARTS} mistakes. You saw where they go. Try again!`}</Text>
      <SlideIn trigger={visible} delay={380} style={styles.btnRow}>
        <SdButton kind="white" onPress={onHub} sound="sd_select" faceStyle={styles.pairFace}>
          <BtnLabel kind="white" size={17}>
            MENU
          </BtnLabel>
        </SdButton>
        <SdButton kind="gold" onPress={onRetry} sound="sd_select" faceStyle={styles.pairFace}>
          <BtnLabel kind="gold" size={17}>
            RETRY
          </BtnLabel>
        </SdButton>
      </SlideIn>
    </Overlay>
  );
}

// (the pause card is Squishdoku's, shared by every mini-game: squishdoku/Overlays.js)

const RULES = [
  ['1', 'Look!', 'The doors open for about 5 seconds. Remember which spot each squishy sits on.'],
  ['2', 'Shake!', 'The doors shut, it shakes and jumps, and everyone tumbles out.'],
  ['3', 'Sort!', 'Drag each squishy back to its spot, or tap it and then tap the spot.'],
  ['!', 'Careful', `${HEARTS} mistakes and it's over. No mistakes and a quick sort: 3 stars.`],
  ['?', 'Clutter', "The food gets knocked about by the shake. Don't use it to remember!"],
];
const TWISTS = [
  ['IMPOSTORS', 'Squishies in the tray that were never inside. Leave them out!'],
  ['SNEAKY SWAP', 'Two squishies trade places just before the doors shut. Keep watching!'],
  ['MIXED UP', 'The shake leaves some inside in the wrong spot. Move them to theirs.'],
];

export function RulesCard({ visible, onClose }) {
  return (
    <Overlay visible={visible}>
      <OutlinedTitle text="HOW TO PLAY" size={26} fill="gold" />
      <View style={styles.rules}>
        {RULES.map(([n, title, line]) => (
          <View key={title} style={styles.rule}>
            <View style={styles.ruleNum}>
              <Text style={styles.ruleNumText}>{n}</Text>
            </View>
            <View style={{ flex: 1 }}>
              <Text style={styles.ruleTitle}>{title}</Text>
              <Text style={styles.ruleLine}>{line}</Text>
            </View>
          </View>
        ))}
      </View>
      <Split />
      <Text style={styles.twistHead}>LATER LEVELS ADD TWISTS</Text>
      {TWISTS.map(([name, line]) => (
        <Text key={name} style={styles.twist}>
          <Text style={styles.twistName}>{`${name}  `}</Text>
          {line}
        </Text>
      ))}
      <Text style={styles.twist}>
        <Text style={[styles.twistName, { color: '#1f7a5a' }]}>{'BIGGER AND BIGGER  '}</Text>
        {'Seven sizes, from a mini fridge to a restaurant fridge (and a bedside cabinet to a giant wardrobe), each gaining shelves as you go.'}
      </Text>
      <Text style={styles.twist}>
        <Text style={[styles.twistName, { color: '#0c5a9c' }]}>{'BLITZ MODE  '}</Text>
        Round after round, each on its own clock. One mistake is GAME OVER, unless you save the run.
      </Text>
      <SdButton kind="gold" onPress={onClose} sound="sd_select" faceStyle={styles.bigFace} style={{ marginTop: 8 }}>
        <BtnLabel kind="gold" size={18}>
          GOT IT!
        </BtnLabel>
      </SdButton>
    </Overlay>
  );
}

const styles = StyleSheet.create({
  btnRow: { flexDirection: 'row', alignItems: 'flex-start', justifyContent: 'center', gap: 8, marginTop: 6 },
  bigFace: { paddingHorizontal: 22, paddingVertical: 12 },
  // a fail card's two buttons (MENU / MAP / UNDO and RETRY): the same size, RETRY in the app's gold (the user, 2026-11-16)
  pairFace: { width: 150, paddingVertical: 11, paddingHorizontal: 8 },
  body: { fontFamily: F.heavy, fontSize: 14, color: INK, textAlign: 'center', paddingHorizontal: 6 },
  rules: { alignSelf: 'stretch', gap: 8, marginTop: 4 },
  rule: { flexDirection: 'row', alignItems: 'center', gap: 10 },
  ruleNum: { width: 30, height: 30, borderRadius: 15, backgroundColor: '#ff8a3d', borderWidth: 2.5, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  ruleNumText: { fontFamily: F.display, fontSize: 15, color: '#ffffff', includeFontPadding: false },
  ruleTitle: { fontFamily: F.display, fontSize: 15, color: '#8a3a0e' },
  ruleLine: { fontFamily: F.heavy, fontSize: 12, lineHeight: 16, color: INK },
  twistHead: { marginTop: 6, fontFamily: F.display, fontSize: 12, letterSpacing: 1, color: '#9a6a3a' },
  twist: { alignSelf: 'stretch', fontFamily: F.heavy, fontSize: 11.5, lineHeight: 15.5, color: INK },
  twistName: { fontFamily: F.display, fontSize: 11.5, color: '#e01e4a' },
});
