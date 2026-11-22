import React from 'react';
import { StyleSheet, Text, View } from 'react-native';
import OutlinedTitle from '../components/candy/OutlinedTitle';
import { Overlay, Split } from '../squishdoku/Overlays';
import { BtnLabel, SdButton } from '../squishdoku/ui';
import { F, INK } from '../squishdoku/theme';
import { PICTURE_FROM } from './levels';

// Squish Stack's cards over the game: the win (stars popping in one by one,
// coins counting up), time's up, pause, the hint offer, and how to play.

// (the result card is the shared one: squishdoku/Overlays.js ResultCard)
// its titles here, for 1, 2 and 3 stars
export const RESULT_TITLES = ['STACKED!', 'NICE STACKING!', 'PERFECT STACK!'];

// (the pause card is Squishdoku's, shared by every mini-game: squishdoku/Overlays.js)

// A hint costs an ad (free with Remove Ads) and one star off this level
// (the user, 2026-10-24). Asked the first time in a level only.
export function HintCard({ visible, adReady, adsFree, onWatch, onClose }) {
  return (
    <Overlay visible={visible}>
      <OutlinedTitle text="NEED A HINT?" size={28} fill="gold" />
      <Text style={styles.body}>{adsFree ? "We'll show you the next best move." : "Watch a short ad and we'll show you the next best move."}</Text>
      <Text style={styles.cost}>This level gives one star less</Text>
      <Split />
      <View style={styles.col}>
        <SdButton kind="gold" onPress={onWatch} disabled={!adsFree && !adReady} sound="sd_select" faceStyle={styles.wideFace}>
          <BtnLabel kind="gold" size={17}>{adsFree ? 'SHOW ME' : adReady ? '▶ WATCH AD' : 'LOADING AD…'}</BtnLabel>
        </SdButton>
        <SdButton kind="white" onPress={onClose} sound="sd_select" faceStyle={styles.wideFace}>
          <BtnLabel kind="white" size={15}>
            NO THANKS
          </BtnLabel>
        </SdButton>
      </View>
    </Overlay>
  );
}

const RULES = [
  ['1', 'Lift', "Tap a cushion to lift the squishy on top. Or drag it."],
  ['2', 'Stack', 'Tap another cushion to put it there. A big squishy can never sit on a smaller one!'],
  ['3', 'Goal', 'Get everyone onto the ★ cushion, or make the cushions look like the GOAL card.'],
  ['★', 'Par', 'MOVES 5 / 7 at the top: your moves, and the most for 3 stars.'],
];
const LATER = [
  ['GOAL CARD', `From level ${PICTURE_FROM}: match a picture, not just one tower.`],
  ['4 CUSHIONS', 'Later on, an extra cushion and more squishies.'],
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
      <Text style={styles.twistHead}>LATER LEVELS ADD</Text>
      {LATER.map(([name, line]) => (
        <Text key={name} style={styles.twist}>
          <Text style={styles.twistName}>{`${name}  `}</Text>
          {line}
        </Text>
      ))}
      <Text style={styles.twist}>
        <Text style={styles.twistName}>{'HINT  '}</Text>
        Shows the next best move, for an ad and one star.
      </Text>
      <Text style={styles.twist}>
        <Text style={[styles.twistName, { color: '#0c5a9c' }]}>{'BLITZ MODE  '}</Text>
        Puzzle after puzzle, no clock. A big one on a smaller one is GAME OVER, unless you save the run.
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
  col: { alignSelf: 'stretch', gap: 4, marginTop: 6 },
  bigFace: { paddingHorizontal: 22, paddingVertical: 12 },
  wideFace: { paddingVertical: 12 },
  body: { fontFamily: F.heavy, fontSize: 14, color: INK, textAlign: 'center', paddingHorizontal: 6 },
  cost: { fontFamily: F.display, fontSize: 13, color: '#e01e4a', textAlign: 'center' },
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
