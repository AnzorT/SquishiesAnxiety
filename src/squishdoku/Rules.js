import React, { useMemo } from 'react';
import { Image, ScrollView, StyleSheet, Text, View } from 'react-native';
import OutlinedTitle from '../components/candy/OutlinedTitle';
import { makePuzzle } from './engine';
import { Overlay } from './Overlays';
import { PopIn, SlideIn } from './fx';
import { BtnLabel, SdButton, XGlyph } from './ui';
import Tile from './Tile';
import { F, INK, PATCHES } from './theme';
import { headOf } from './roster';

// How to play: a solved 5×5 drawn small, and the rules in five lines.

function MiniBoard({ roster, size = 130 }) {
  const p = useMemo(() => makePuzzle({ n: 5, tier: 0, seed: 20261022 }), []);
  const cs = size / p.n;
  const sol = new Set(p.solution.map((c, r) => r * p.n + c));
  return (
    <View style={[styles.mini, { width: size + 8, height: size + 8 }]}>
      {p.regions.map((reg, cell) => {
        const r = Math.floor(cell / p.n);
        const c = cell % p.n;
        const uri = roster.length ? roster[(reg * 5 + 3) % roster.length] : null;
        const head = uri ? headOf(uri) : null;
        return (
          <View key={cell} style={{ position: 'absolute', left: 4 + c * cs, top: 4 + r * cs, width: cs, height: cs }}>
            <Tile size={cs} patch={PATCHES[reg]} />
            {sol.has(cell) && uri ? <Image source={head ? head.idle : { uri }} style={{ position: 'absolute', width: '86%', height: '86%', left: '7%', top: '4%' }} resizeMode="contain" /> : null}
          </View>
        );
      })}
    </View>
  );
}

const RULES = [
  ['1', 'One creature in every ROW and every COLUMN.'],
  ['2', 'One creature in every coloured PATCH.'],
  ['3', "Creatures can't TOUCH, not even corner to corner."],
  ['✕', 'Tap to place. Rule cells out with ✕ (MARK, or long-press). A wrong tap is a mistake.'],
  ['★', 'No ✕ and no mistakes = PERFECT: all 3 creatures and triple coins. Otherwise beat the clock to keep them.'],
  ['⚡', 'BLITZ: 10 boards, one clock, no ✕. One mistake sends you back to board 1, with one revive per run.'],
];

export default function RulesCard({ visible, roster, onClose }) {
  return (
    <Overlay visible={visible}>
      <ScrollView style={{ maxHeight: 560, alignSelf: 'stretch' }} contentContainerStyle={{ alignItems: 'center', gap: 8 }} showsVerticalScrollIndicator={false}>
        <PopIn trigger={visible} delay={40}>
          <OutlinedTitle text="HOW TO PLAY" size={26} fill="pink" />
        </PopIn>
        <PopIn trigger={visible} delay={140}>
          <MiniBoard roster={roster} />
        </PopIn>
        {RULES.map(([k, text], i) => (
          <SlideIn key={k} trigger={visible} delay={200 + i * 70} dy={14} style={styles.rule}>
            <View style={styles.ruleBadge}>{k === '✕' ? <XGlyph size={11} color="#ffffff" /> : <Text style={styles.ruleKey}>{k}</Text>}</View>
            <Text style={styles.ruleText}>{text}</Text>
          </SlideIn>
        ))}
        <SdButton kind="green" onPress={onClose} sound="sd_select" faceStyle={{ paddingHorizontal: 30, paddingVertical: 11 }} style={{ marginTop: 4 }}>
          <BtnLabel kind="green" size={18}>
            GOT IT!
          </BtnLabel>
        </SdButton>
      </ScrollView>
    </Overlay>
  );
}

const styles = StyleSheet.create({
  mini: { borderRadius: 12, backgroundColor: '#e9dcf7', borderWidth: 2.5, borderColor: '#45189a', overflow: 'hidden' },
  rule: { flexDirection: 'row', alignItems: 'flex-start', gap: 9, alignSelf: 'stretch', paddingHorizontal: 4 },
  ruleBadge: { width: 24, height: 24, borderRadius: 12, backgroundColor: '#ff5cc6', borderWidth: 2, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center', marginTop: 1 },
  ruleKey: { fontFamily: F.display, fontSize: 12, color: '#ffffff', includeFontPadding: false },
  ruleText: { flex: 1, fontFamily: F.heavy, fontSize: 13, color: INK, lineHeight: 18 },
});
