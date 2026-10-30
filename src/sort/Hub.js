import React, { memo, useEffect, useRef } from 'react';
import { Animated, Easing, ScrollView, StyleSheet, Text, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import OutlinedTitle from '../components/candy/OutlinedTitle';
import { Pulse, Rock, PopIn, SlideIn } from '../squishdoku/fx';
import { BtnLabel, SdButton } from '../squishdoku/ui';
import { F, INK } from '../squishdoku/theme';
import { MiniContainer } from './Container';
import { modelOf } from './models';
import { THEMES } from './themes';
import { ModeCard } from '../squishdoku/Hub';
import { BLITZ_MS, BLITZ_ROUNDS, LEVELS, LEVEL_LIST, clock, starsIn } from './levels';

// Squish Sort's front page: a card per container (the fridge for the food
// squishies, the toy cupboard for the rest), each with its own 50 levels
// (PLAY opens its level map) and the fridge or cupboard the player is up
// to (models.js), Blitz, and how to play.

// Doors that open, stay, shut, rattle and open again, forever (the picker's
// and the hub's little containers).
export function useDoorLoop() {
  const door = useRef(new Animated.Value(1)).current;
  const wob = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const T = (v, ms, ease = Easing.inOut(Easing.quad), val = door) => Animated.timing(val, { toValue: v, duration: ms, easing: ease, useNativeDriver: true });
    const loop = Animated.loop(
      Animated.sequence([
        T(1, 1400),
        T(0, 380, Easing.in(Easing.quad)),
        Animated.sequence([1, -1, 1, -1, 0].map((v) => T(v, 90, Easing.inOut(Easing.quad), wob))),
        T(0, 200),
        T(1, 420, Easing.out(Easing.back(1.4))),
      ]),
    );
    loop.start();
    return () => loop.stop();
  }, [door, wob]);
  return { door, rotate: wob.interpolate({ inputRange: [-1, 1], outputRange: ['-5deg', '5deg'] }) };
}

function ThemeCard({ themeKey, rec, uris, onPlay, delay }) {
  const t = THEMES[themeKey];
  const { door, rotate } = useDoorLoop();
  const lv = rec[themeKey].lv;
  const stars = starsIn(rec, themeKey);
  const L = LEVEL_LIST[lv - 1];
  const m = modelOf(themeKey, L.model);
  return (
    <SlideIn delay={delay} dy={50} style={styles.cardWrap}>
      <View style={[styles.cardRing, { backgroundColor: t.card.ring }]}>
        <LinearGradient colors={t.card.colors} locations={[0, 0.55, 1]} style={styles.cardFace}>
          <View style={styles.cardShine} />
          <Animated.View style={{ transform: [{ rotate }] }}>
            <MiniContainer m={m} rows={Math.min(3, L.rows)} cols={L.cols} size={96} door={door} uris={uris} />
          </Animated.View>
          <View style={styles.cardBody}>
            <Text style={[styles.cardTitle, { color: t.card.ring }]}>{t.name.toUpperCase()}</Text>
            <Text style={styles.cardLine}>{t.blurb}</Text>
            <Text style={[styles.modelLine, { color: t.card.ring }]} numberOfLines={1}>{`${m.size} · ${m.name.toUpperCase()}`}</Text>
            <View style={styles.row6}>
              <View style={[styles.lvChip, { backgroundColor: t.card.ring }]}>
                <Text style={styles.lvChipText}>{`LEVEL ${lv}/${LEVELS}`}</Text>
              </View>
              <Text style={styles.stars}>{`★ ${stars}`}</Text>
            </View>
            <Pulse to={1.05} ms={1300} style={{ alignSelf: 'flex-start', marginTop: 4 }}>
              <SdButton kind="green" onPress={onPlay} sound="sd_select" faceStyle={styles.ctaFace}>
                <BtnLabel kind="green" size={17}>
                  PLAY ▶
                </BtnLabel>
              </SdButton>
            </Pulse>
          </View>
        </LinearGradient>
      </View>
    </SlideIn>
  );
}

function Hub({ rec, pools, onPlay, onBlitz, onRules }) {
  const b = rec.blitz;
  return (
    <ScrollView style={styles.fill} contentContainerStyle={styles.wrap} showsVerticalScrollIndicator={false}>
      <PopIn delay={60} from={0.3} twist={-10}>
        <Rock deg={2} ms={3400}>
          <OutlinedTitle text="SQUISH SORT" size={36} fill="pink" />
        </Rock>
      </PopIn>
      <PopIn delay={220}>
        <Text style={styles.tagline}>{'Remember who sits where.\nThe doors shut, it shakes… sort them back!'}</Text>
      </PopIn>
      {['fridge', 'cupboard'].map((k, i) => (
        <ThemeCard key={k} themeKey={k} rec={rec} uris={(pools[k] || []).slice(i * 3, i * 3 + 3).map((c) => c.uri)} onPlay={() => onPlay(k)} delay={300 + i * 120} />
      ))}
      <ModeCard
        kind="blitz"
        title="BLITZ ⚡"
        lines={[`${BLITZ_ROUNDS} rounds · ${clock(BLITZ_MS)} · fridge & cupboard`, '1 mistake = back to round 1', b.reached ? `Best: round ${b.reached}${b.wins ? ` · ${b.wins} win${b.wins > 1 ? 's' : ''}` : ''}` : 'No runs yet']}
        cta="GO ⚡"
        onPress={onBlitz}
        delay={540}
      />
      <SlideIn delay={640} dy={30}>
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
  wrap: { flexGrow: 1, alignItems: 'center', justifyContent: 'center', paddingHorizontal: 16, paddingTop: 4, paddingBottom: 40, gap: 16 },
  tagline: { fontFamily: F.heavy, fontSize: 13, color: INK, textAlign: 'center', lineHeight: 18 },
  row6: { flexDirection: 'row', alignItems: 'center', gap: 6, marginTop: 2 },
  cardWrap: { alignSelf: 'stretch' },
  cardRing: { borderRadius: 26, padding: 2.5, paddingBottom: 7 },
  cardFace: { borderRadius: 23.5, borderWidth: 3, borderColor: '#ffffff', flexDirection: 'row', alignItems: 'center', paddingHorizontal: 14, paddingVertical: 14, gap: 14, overflow: 'hidden' },
  cardShine: { position: 'absolute', left: 14, right: 14, top: 3, height: '30%', borderRadius: 20, backgroundColor: 'rgba(255,255,255,0.4)' },
  cardBody: { flex: 1, gap: 2 },
  cardTitle: { fontFamily: F.display, fontSize: 22, letterSpacing: 0.8, includeFontPadding: false },
  cardLine: { fontFamily: F.heavy, fontSize: 12.5, color: INK },
  modelLine: { fontFamily: F.display, fontSize: 11, letterSpacing: 0.6 },
  lvChip: { paddingHorizontal: 8, paddingVertical: 2, borderRadius: 999, borderWidth: 2, borderColor: '#ffffff' },
  lvChipText: { fontFamily: F.display, fontSize: 11, letterSpacing: 0.6, color: '#ffffff' },
  stars: { fontFamily: F.display, fontSize: 14, color: '#b86200' },
  ctaFace: { paddingHorizontal: 18, paddingVertical: 10 },
  rulesFace: { paddingHorizontal: 16, paddingVertical: 8 },
});

export default memo(Hub);
