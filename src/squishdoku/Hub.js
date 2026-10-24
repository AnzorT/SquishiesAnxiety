import React, { memo } from 'react';
import { ScrollView, StyleSheet, Text, View } from 'react-native';
import ToggleSwitch from '../components/candy/ToggleSwitch';
import { LinearGradient } from 'expo-linear-gradient';
import OutlinedTitle from '../components/candy/OutlinedTitle';
import { Bob } from '../squad/ui';
import { PopIn, Pulse, Rock, SlideIn } from './fx';
import { BtnLabel, Head, SdButton, XGlyph } from './ui';
import { HEAD_START, LEVELS, blitzMs, clock, puzzleLevel } from './levels';
import { F, INK } from './theme';

// Squishdoku's front page: the title with creatures bobbing round it, the
// player's Puzzle Level, and the two modes.

function ModeCard({ kind, title, lines, cta, onPress, delay, children }) {
  const colors = kind === 'blitz' ? ['#e0fbff', '#9feeff', '#5fd0f5'] : ['#fff0fa', '#ffc6ea', '#ff93d6'];
  const ring = kind === 'blitz' ? '#0c5a9c' : '#8e1580';
  return (
    <SlideIn delay={delay} dy={50} style={styles.cardWrap}>
      <View style={[styles.cardRing, { backgroundColor: ring }]}>
        <LinearGradient colors={colors} locations={[0, 0.5, 1]} style={styles.cardFace}>
          <View style={styles.cardShine} />
          <View style={styles.cardBody}>
            <Text style={[styles.cardTitle, { color: ring }]}>{title}</Text>
            {lines.map((l) => (
              <Text key={l} style={styles.cardLine}>
                {l}
              </Text>
            ))}
            {children}
          </View>
          <Pulse to={1.06} ms={1300}>
            <SdButton kind={kind === 'blitz' ? 'cyan' : 'green'} onPress={onPress} sound="sd_select" faceStyle={styles.ctaFace}>
              <BtnLabel kind={kind === 'blitz' ? 'cyan' : 'green'} size={18}>
                {cta}
              </BtnLabel>
            </SdButton>
          </Pulse>
        </LinearGradient>
      </View>
    </SlideIn>
  );
}

// HEAD START: the first row's creature comes placed, for a shorter clock
// and smaller prizes (levels.js HEAD_START). Both modes.
function HeadStart({ on, uri, onToggle, delay }) {
  return (
    <SlideIn delay={delay} dy={40} style={styles.headWrap}>
      <View style={[styles.headCard, on && styles.headCardOn]}>
        <Pulse active={on} to={1.08} ms={1200}>
          <Head uri={uri} size={40} ring={on ? '#ffd23a' : '#ffffff'} />
        </Pulse>
        <View style={{ flex: 1 }}>
          <Text style={styles.headTitle}>HEAD START</Text>
          <Text style={styles.headLine}>{`First creature placed for you\n${Math.round((1 - HEAD_START.time) * 100)}% less time · ×${HEAD_START.reward} coins & XP`}</Text>
        </View>
        <ToggleSwitch value={on} onToggle={onToggle} />
      </View>
    </SlideIn>
  );
}

function Hub({ rec, roster, head, onToggleHead, onRegular, onBlitz, onRules }) {
  const pl = puzzleLevel(rec.xp);
  const done = rec.lv - 1 + (rec.best[LEVELS] ? 1 : 0);
  const pick = (k) => (roster.length ? roster[k % roster.length] : null);
  return (
    // scrolls only on short screens; centred otherwise
    <ScrollView style={styles.fill} contentContainerStyle={styles.wrap} showsVerticalScrollIndicator={false}>
      <View style={styles.titleArea}>
        <Bob style={[styles.float, { left: 6, top: 4 }]} ms={2600} dy={9}>
          <Rock deg={8} ms={3000}>
            <Head uri={pick(rec.plays + 3)} size={50} />
          </Rock>
        </Bob>
        <Bob style={[styles.float, { right: 8, top: 14 }]} ms={2200} dy={7} delay={0.4}>
          <Rock deg={10} ms={2600}>
            <Head uri={pick(rec.plays + 17)} size={44} />
          </Rock>
        </Bob>
        <Bob style={[styles.float, { left: 14, top: 112 }]} ms={3000} dy={6} delay={0.8}>
          <Head uri={pick(rec.plays + 29)} size={32} />
        </Bob>
        <PopIn delay={60} from={0.3} twist={-10}>
          <Rock deg={2} ms={3400}>
            <OutlinedTitle text="SQUISHDOKU" size={36} fill="pink" />
          </Rock>
        </PopIn>
        <PopIn delay={220}>
          <Text style={styles.tagline}>One creature in every row, column and patch.{'\n'}No two may touch!</Text>
        </PopIn>
        <PopIn delay={340} style={styles.levelPill}>
          <View style={styles.lvBadge}>
            <Text style={styles.lvNum}>{pl.level}</Text>
          </View>
          <View style={{ gap: 3 }}>
            <Text style={styles.lvLabel}>PUZZLE LEVEL</Text>
            <View style={styles.xpTrack}>
              <View style={[styles.xpFill, { width: `${Math.round((pl.into / pl.need) * 100)}%` }]} />
            </View>
          </View>
          <Text style={styles.xpText}>{`${pl.into}/${pl.need}`}</Text>
        </PopIn>
      </View>

      <ModeCard kind="regular" title="REGULAR" lines={[`Level ${Math.min(rec.lv, LEVELS)} of ${LEVELS}`, 'Beat the clock, keep your 3 creatures']} cta="PLAY ▶" onPress={onRegular} delay={300}>
        <View style={styles.progTrack}>
          <LinearGradient colors={['#ffe38a', '#ffb02e']} start={{ x: 0, y: 0 }} end={{ x: 1, y: 0 }} style={[styles.progFill, { width: `${Math.max(4, (done / LEVELS) * 100)}%` }]} />
        </View>
      </ModeCard>
      <ModeCard
        kind="blitz"
        title="BLITZ ⚡"
        lines={[`10 boards · ${clock(blitzMs(head))} · no ✕`, '1 mistake = back to board 1', rec.blitz.reached ? `Best: board ${rec.blitz.reached}${rec.blitz.wins ? ` · ${rec.blitz.wins} win${rec.blitz.wins > 1 ? 's' : ''}` : ''}` : 'No runs yet']}
        cta="GO ⚡"
        onPress={onBlitz}
        delay={420}
      />
      <HeadStart on={head} uri={pick(rec.plays + 7)} onToggle={onToggleHead} delay={520} />
      <SlideIn delay={600} dy={30}>
        <SdButton kind="white" onPress={onRules} sound="sd_mode" faceStyle={styles.rulesFace}>
          <XGlyph size={13} />
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
  levelPill: { flexDirection: 'row', alignItems: 'center', gap: 8, backgroundColor: 'rgba(255,255,255,0.85)', borderRadius: 999, borderWidth: 2.5, borderColor: '#ffffff', paddingVertical: 4, paddingLeft: 4, paddingRight: 12 },
  lvBadge: { width: 32, height: 32, borderRadius: 16, backgroundColor: '#7a2fd6', borderWidth: 2.5, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  lvNum: { fontFamily: F.display, fontSize: 15, color: '#ffffff', includeFontPadding: false },
  lvLabel: { fontFamily: F.display, fontSize: 10, color: '#7a2fd6', letterSpacing: 0.8 },
  xpTrack: { width: 120, height: 8, borderRadius: 4, backgroundColor: 'rgba(122,47,214,0.2)', overflow: 'hidden' },
  xpFill: { height: '100%', borderRadius: 4, backgroundColor: '#9a4dff' },
  xpText: { fontFamily: F.display, fontSize: 11, color: '#8a5fc0' },
  cardWrap: { alignSelf: 'stretch' },
  cardRing: { borderRadius: 26, padding: 2.5, paddingBottom: 7 },
  cardFace: { borderRadius: 23.5, borderWidth: 3, borderColor: '#ffffff', flexDirection: 'row', alignItems: 'center', paddingHorizontal: 14, paddingVertical: 12, gap: 10, overflow: 'hidden' },
  cardShine: { position: 'absolute', left: 14, right: 14, top: 3, height: '35%', borderRadius: 20, backgroundColor: 'rgba(255,255,255,0.4)' },
  cardBody: { flex: 1, gap: 2 },
  cardTitle: { fontFamily: F.display, fontSize: 24, letterSpacing: 1, includeFontPadding: false },
  cardLine: { fontFamily: F.heavy, fontSize: 12.5, color: INK },
  ctaFace: { paddingHorizontal: 16, paddingVertical: 12 },
  progTrack: { height: 10, borderRadius: 5, backgroundColor: 'rgba(142,21,128,0.18)', overflow: 'hidden', marginTop: 4 },
  progFill: { height: '100%', borderRadius: 5 },
  rulesFace: { paddingHorizontal: 16, paddingVertical: 8 },
  headWrap: { alignSelf: 'stretch' },
  headCard: { flexDirection: 'row', alignItems: 'center', gap: 10, backgroundColor: 'rgba(255,255,255,0.8)', borderRadius: 20, borderWidth: 2.5, borderColor: '#ffffff', paddingHorizontal: 12, paddingVertical: 8 },
  headCardOn: { backgroundColor: '#fff4cc', borderColor: '#ffd23a' },
  headTitle: { fontFamily: F.display, fontSize: 15, color: '#b86200', letterSpacing: 0.8 },
  headLine: { fontFamily: F.heavy, fontSize: 11, color: INK, lineHeight: 15 },
});

export default memo(Hub);
