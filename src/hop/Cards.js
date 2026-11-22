import React, { useCallback, useEffect, useRef, useState } from 'react';
import { StyleSheet, Text, View } from 'react-native';
import OutlinedTitle from '../components/candy/OutlinedTitle';
import { PopIn, SlideIn } from '../squishdoku/fx';
import { Overlay, Split } from '../squishdoku/Overlays';
import { BtnLabel, SdButton } from '../squishdoku/ui';
import RigCreature from '../components/RigCreature';
import { Squishy } from '../stack/Pieces';
import { F, INK } from '../squishdoku/theme';
import { TWISTS } from './levels';

// Squish Hop's cards over the game (SQUISH_HOP.md): the win (stars popping in
// one by one, coins counting up), STUCK, pause, the hint offer, and how to
// play. Squish Stack's cards, with this game's words.

// (the result card is the shared one: squishdoku/Overlays.js ResultCard)
// its titles here, for 1, 2 and 3 stars
export const RESULT_TITLES = ['CLEARED!', 'NICE HOPPING!', 'PERFECT HOPS!'];

// Nowhere left to hop. `who`: the hopper (its cast entry: key, cut-out),
// crying (SadSquishy); `shut`: the ★ is next to it but still shut (cushions
// are left that can't be reached any more). RETRY only (no UNDO since 2026-11-17, the user).
export function StuckCard({ visible, who, shut, onRetry }) {
  return (
    <Overlay visible={visible} tint="rgba(80,0,30,0.5)" column>
      <PopIn trigger={visible} delay={60}>
        <OutlinedTitle text="STUCK!" size={32} fill="gold" />
      </PopIn>
      <PopIn trigger={visible} delay={220}>
        <SadSquishy who={who} />
      </PopIn>
      <Split />
      <Text style={styles.body}>{shut ? 'The ★ stays shut until every other cushion is cleared, and there is nowhere else to hop.' : 'There is nowhere left to hop.'}</Text>
      <SlideIn trigger={visible} delay={380} style={styles.btnRow}>
        <SdButton kind="gold" onPress={onRetry} sound="sd_select" faceStyle={styles.pairFace}>
          <BtnLabel kind="gold" size={17}>
            RETRY
          </BtnLabel>
        </SdButton>
      </SlideIn>
    </Overlay>
  );
}

// The hopper itself on the STUCK card, whole (not a head in a bubble: the user, 2026-11-17), crying: its live rig
// (the design's 2.5D creature, RigCreature) plays the design's quiet `cry` for a moment, then its heavy `sob`, over
// and over until the card goes. Its cut-out stands in while the rig loads, and stays if the rig won't.
const CRY_MS = 2200; // the quiet crying before the sobbing starts
function SadSquishy({ who }) {
  const rig = useRef(null);
  const sobbing = useRef(false);
  const timer = useRef(null);
  const [drawn, setDrawn] = useState(false);
  useEffect(() => () => clearTimeout(timer.current), []);
  const onMounted = useCallback(() => {
    setDrawn(true);
    rig.current?.play('cry');
    timer.current = setTimeout(() => rig.current?.play('sob'), CRY_MS);
  }, []);
  // a sob ends back at idle: sob again
  const onState = useCallback((s) => {
    if (s === 'sob') sobbing.current = true;
    else if (s === 'idle' && sobbing.current) rig.current?.play('sob');
  }, []);
  return (
    <View style={styles.sadBox}>
      {who && !drawn ? (
        <View style={styles.sadCut}>
          <Squishy c={who} w={84} />
        </View>
      ) : null}
      {who && who.key ? <RigCreature ref={rig} creatureKey={who.key} shuffle={false} bleed={SAD_BLEED} onMounted={onMounted} onState={onState} style={[StyleSheet.absoluteFill, !drawn && styles.hidden]} /> : null}
    </View>
  );
}
// room past its box for the sob's arms and gushing tears (RigCreature `bleed`)
const SAD_BLEED = { x: 60, top: 20, bottom: 4 };

// (the pause card is Squishdoku's, shared by every mini-game: squishdoku/Overlays.js)

// A hint costs an ad (free with Remove Ads) and one star off this level, like
// Squish Stack's. Asked the first time in a level only.
export function HintCard({ visible, adReady, adsFree, onWatch, onClose }) {
  return (
    <Overlay visible={visible}>
      <OutlinedTitle text="NEED A HINT?" size={28} fill="gold" />
      <Text style={styles.body}>{adsFree ? "We'll show you the next hop." : "Watch a short ad and we'll show you the next hop."}</Text>
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
  ['1', 'Hop', 'Swipe, or tap a cushion next to you. A long swipe can turn corners.'],
  ['2', 'Puff!', 'The cushion you hop off puffs away. No going back!'],
  ['3', 'The ★', 'Opens once every other cushion is gone. Hop on to finish.'],
  ['4', 'Stars', '3 with no RESTART or RETRY, 2 with up to 3.'],
];
const ROOM_ORDER = ['friends', 'arrows', 'bubbles', 'piles', 'ordered', 'beats'];
const LINES = {
  friends: 'hop onto each one to pick it up.',
  arrows: 'you can only hop off an arrow cushion the way it points.',
  bubbles: 'land on a bubble and it bounces you one cushion further.',
  piles: 'two cushions on top of each other take two hops.',
  ordered: 'numbered friends are picked up 1, 2, 3…',
  beats: 'coloured tiles light up every third hop. Land on them lit.',
};

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
      <Text style={styles.twistHead}>ROOM BY ROOM</Text>
      {ROOM_ORDER.map((k) => (
        <Text key={k} style={styles.twist}>
          <Text style={styles.twistName}>{`${TWISTS[k].name}  `}</Text>
          {LINES[k]}
        </Text>
      ))}
      <Text style={styles.twist}>
        <Text style={styles.twistName}>{'HINT  '}</Text>
        Shows the next hop, for an ad and one star.
      </Text>
      <Text style={styles.twist}>
        <Text style={[styles.twistName, { color: '#0c5a9c' }]}>{'BLITZ MODE  '}</Text>
        Fresh boards on short clocks. A wrong hop is GAME OVER, unless you save the run.
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
  col: { alignSelf: 'stretch', gap: 4, marginTop: 6 },
  bigFace: { paddingHorizontal: 22, paddingVertical: 12 },
  // a fail card's buttons (MENU / MAP and RETRY): the same size, RETRY in the app's gold (the user, 2026-11-16)
  pairFace: { width: 150, paddingVertical: 11, paddingHorizontal: 8 },
  wideFace: { paddingVertical: 12 },
  body: { fontFamily: F.heavy, fontSize: 14, color: INK, textAlign: 'center', paddingHorizontal: 6 },
  cost: { fontFamily: F.display, fontSize: 13, color: '#e01e4a', textAlign: 'center' },
  // the crying hopper: its rig drawn in a box this size (its body about two thirds of it)
  sadBox: { width: 150, height: 128 },
  sadCut: { ...StyleSheet.absoluteFillObject, alignItems: 'center', justifyContent: 'flex-end', paddingBottom: 6 },
  hidden: { opacity: 0 },
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
