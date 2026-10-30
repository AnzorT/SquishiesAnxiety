import React, { memo } from 'react';
import { ScrollView, StyleSheet, Text, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import OutlinedTitle from '../components/candy/OutlinedTitle';
import { Bob } from '../squad/ui';
import { PopIn, Rock, SlideIn } from '../squishdoku/fx';
import { ModeCard } from '../squishdoku/Hub';
import { BtnLabel, Head, SdButton } from '../squishdoku/ui';
import { F, INK } from '../squishdoku/theme';
import { BLITZ_MS, BLITZ_ROUNDS, LEVELS, clock, doneOf, starsOf } from './levels';

// Squish Stack's front page (as Squishdoku's): the title with squishies
// bobbing round it, and the two modes: REGULAR (the 50-level map) and BLITZ.

function Hub({ rec, uris, onRegular, onBlitz, onRules }) {
  const done = doneOf(rec);
  const b = rec.blitz;
  const pick = (k) => (uris.length ? uris[k % uris.length] : null);
  return (
    <ScrollView style={styles.fill} contentContainerStyle={styles.wrap} showsVerticalScrollIndicator={false}>
      <View style={styles.titleArea}>
        <Bob style={[styles.float, { left: 6, top: 2 }]} ms={2600} dy={9}>
          <Rock deg={8} ms={3000}>
            <Head uri={pick(rec.plays + 3)} size={48} />
          </Rock>
        </Bob>
        <Bob style={[styles.float, { right: 8, top: 10 }]} ms={2200} dy={7} delay={0.4}>
          <Rock deg={10} ms={2600}>
            <Head uri={pick(rec.plays + 11)} size={42} />
          </Rock>
        </Bob>
        <PopIn delay={60} from={0.3} twist={-10}>
          <Rock deg={2} ms={3400}>
            <OutlinedTitle text="SQUISH STACK" size={34} fill="pink" />
          </Rock>
        </PopIn>
        <PopIn delay={220}>
          <Text style={styles.tagline}>{'Move the squishies one at a time.\nA big one never sits on a smaller one!'}</Text>
        </PopIn>
      </View>

      <ModeCard kind="regular" title="REGULAR" lines={[`Level ${Math.min(rec.lv, LEVELS)} of ${LEVELS} · ★ ${starsOf(rec)}`, 'Fewest moves for 3 stars']} cta="PLAY ▶" onPress={onRegular} delay={300}>
        <View style={styles.progTrack}>
          <LinearGradient colors={['#ffe38a', '#ffb02e']} start={{ x: 0, y: 0 }} end={{ x: 1, y: 0 }} style={[styles.progFill, { width: `${Math.max(4, (done / LEVELS) * 100)}%` }]} />
        </View>
      </ModeCard>
      <ModeCard
        kind="blitz"
        title="BLITZ ⚡"
        lines={[`${BLITZ_ROUNDS} puzzles · ${clock(BLITZ_MS)}`, 'Big on small = back to puzzle 1', b.reached ? `Best: puzzle ${b.reached}${b.wins ? ` · ${b.wins} win${b.wins > 1 ? 's' : ''}` : ''}` : 'No runs yet']}
        cta="GO ⚡"
        onPress={onBlitz}
        delay={420}
      />
      <SlideIn delay={540} dy={30}>
        <SdButton kind="white" onPress={onRules} sound="sd_mode" faceStyle={styles.rulesFace}>
          <BtnLabel kind="purple" size={14}>
            HOW TO PLAY
          </BtnLabel>
        </SdButton>
      </SlideIn>
    </ScrollView>
  );
}

const styles = StyleSheet.create({
  fill: { flex: 1 },
  wrap: { flexGrow: 1, alignItems: 'center', justifyContent: 'center', paddingHorizontal: 16, paddingTop: 4, paddingBottom: 40, gap: 14 },
  titleArea: { alignSelf: 'stretch', alignItems: 'center', paddingTop: 8, gap: 6 },
  float: { position: 'absolute' },
  tagline: { fontFamily: F.heavy, fontSize: 13, color: INK, textAlign: 'center', lineHeight: 18 },
  progTrack: { height: 10, borderRadius: 5, backgroundColor: 'rgba(142,21,128,0.18)', overflow: 'hidden', marginTop: 4 },
  progFill: { height: '100%', borderRadius: 5 },
  rulesFace: { paddingHorizontal: 16, paddingVertical: 8 },
});

export default memo(Hub);
