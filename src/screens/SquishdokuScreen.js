import React, { useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { Animated, BackHandler, StyleSheet, Text, View } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import CandyBackground from '../components/candy/CandyBackground';
import RoundButton, { BackGlyph } from '../components/candy/RoundButton';
import sfx from '../audio/sfx';
import Hub from '../squishdoku/Hub';
import LevelMap from '../squishdoku/LevelMap';
import RegularGame from '../squishdoku/RegularGame';
import BlitzGame from '../squishdoku/BlitzGame';
import RulesCard from '../squishdoku/Rules';
import { prefetchPuzzle } from '../squishdoku/game';
import { levelSpec, puzzleLevel, record } from '../squishdoku/levels';
import { ownedKey, rosterOf } from '../squishdoku/roster';
import { BY_ID } from '../squad/data';
import { selectedId } from '../squad/lobby';
import { saveSquishdoku } from '../firebase/firestore';
import { F, INK } from '../squishdoku/theme';

// Squishdoku (SQUISHDOKU.md), opened from the Lobby's Puzzle tile: the hub,
// the level map, a Regular level, or a Blitz run. Each view slides in over
// the last. The creatures are the catalog's rig stills (`thumb.url`).

// sounds kept loaded while the game is open (src/audio/sfx.js setBudget)
const SOUND_BUDGET = 18;

export default function SquishdokuScreen({ profile, creatures, uid, adsFree, haptics, onBack }) {
  const insets = useSafeAreaInsets();
  const rec = record(profile);
  const [view, setView] = useState('hub'); // hub | map | play | blitz
  const [playLv, setPlayLv] = useState(1);
  const [rules, setRules] = useState(false);
  const [justUnlocked, setJustUnlocked] = useState(null);
  const slide = useRef(new Animated.Value(1)).current;
  // re-picked only when what the player owns changes
  const owned = ownedKey(profile);
  const roster = useMemo(() => rosterOf(creatures, profile), [creatures, owned]); // eslint-disable-line react-hooks/exhaustive-deps
  // the buddy under the board: the creature picked in the Lobby
  const buddyId = selectedId(profile);
  const buddyKey = BY_ID[buddyId] ? BY_ID[buddyId].key : null;
  const buddyUri = useMemo(() => {
    const entry = (creatures || []).find((x) => String(x.id) === String(buddyId));
    return entry && entry.thumb ? entry.thumb.url : null;
  }, [creatures, buddyId]);
  // HEAD START, flipped here at once and saved to the profile
  const [head, setHead] = useState(rec.head);
  const toggleHead = useCallback(() => {
    setHead((on) => {
      const next = !on;
      if (uid) saveSquishdoku(uid, { 'sdk.head': next }, 0);
      return next;
    });
  }, [uid]);

  useEffect(() => {
    sfx.setBudget(SOUND_BUDGET);
    sfx.music('dream');
    // the next level's board, made while the player looks at the menus
    const s = levelSpec(rec.lv, rec.skill, rec.head);
    prefetchPuzzle(s.n, s.tier);
    // first visit: the rules
    if (!rec.plays) setTimeout(() => setRules(true), 700);
    return () => sfx.setBudget(null);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const go = useCallback(
    (next) => {
      slide.setValue(0);
      setView(next);
      Animated.spring(slide, { toValue: 1, friction: 8, tension: 70, useNativeDriver: true }).start();
    },
    [slide],
  );

  // back: rules → map → hub → lobby (the games handle their own)
  useEffect(() => {
    if (view === 'play' || view === 'blitz') return undefined;
    const sub = BackHandler.addEventListener('hardwareBackPress', () => {
      if (rules) setRules(false);
      else if (view === 'map') go('hub');
      else onBack();
      sfx.play('sd_boardOut');
      return true;
    });
    return () => sub.remove();
  }, [view, rules, go, onBack]);

  const startLevel = useCallback(
    (lv) => {
      setPlayLv(lv);
      setJustUnlocked(null);
      go('play');
    },
    [go],
  );
  const leaveLevel = useCallback(
    ({ unlocked } = {}) => {
      setJustUnlocked(unlocked || null);
      sfx.play('sd_boardOut');
      go('map');
    },
    [go],
  );
  const leaveBlitz = useCallback(() => {
    sfx.play('sd_boardOut');
    go('hub');
  }, [go]);

  const pl = puzzleLevel(rec.xp);
  const translateX = slide.interpolate({ inputRange: [0, 1], outputRange: [60, 0] });
  const opacity = slide.interpolate({ inputRange: [0, 0.4, 1], outputRange: [0, 1, 1] });

  return (
    <CandyBackground style={{ paddingTop: insets.top }} sparkles>
      {view === 'hub' || view === 'map' ? (
        <View style={styles.header}>
          <RoundButton size={40} onPress={() => (view === 'map' ? go('hub') : onBack())}>
            <BackGlyph />
          </RoundButton>
          <Text style={styles.headerTitle}>{view === 'map' ? 'LEVELS' : ''}</Text>
          {view === 'map' ? (
            <View style={styles.lvPill}>
              <Text style={styles.lvPillText}>{`LV ${pl.level}`}</Text>
            </View>
          ) : (
            <View style={{ width: 40 }} />
          )}
        </View>
      ) : null}
      <Animated.View style={[styles.fill, { opacity, transform: [{ translateX }] }]}>
        {view === 'hub' ? (
          <Hub rec={rec} roster={roster} head={head} onToggleHead={toggleHead} onRegular={() => go('map')} onBlitz={() => go('blitz')} onRules={() => setRules(true)} />
        ) : null}
        {view === 'map' ? <LevelMap rec={rec} roster={roster} onPlay={startLevel} justUnlocked={justUnlocked} /> : null}
        {view === 'play' ? (
          <RegularGame startLv={playLv} profile={profile} uid={uid} roster={roster} head={head} buddyKey={buddyKey} buddyUri={buddyUri} haptics={haptics} onExit={leaveLevel} />
        ) : null}
        {view === 'blitz' ? (
          <BlitzGame profile={profile} uid={uid} roster={roster} adsFree={adsFree} head={head} buddyKey={buddyKey} buddyUri={buddyUri} haptics={haptics} onExit={leaveBlitz} />
        ) : null}
      </Animated.View>
      <RulesCard visible={rules} roster={roster} onClose={() => setRules(false)} />
    </CandyBackground>
  );
}

const styles = StyleSheet.create({
  fill: { flex: 1 },
  header: { flexDirection: 'row', alignItems: 'center', paddingHorizontal: 14, paddingTop: 6, paddingBottom: 2 },
  headerTitle: { flex: 1, textAlign: 'center', fontFamily: F.display, fontSize: 22, color: '#ffffff', letterSpacing: 1.5, textShadowColor: INK, textShadowOffset: { width: 0, height: 2.5 }, textShadowRadius: 1 },
  lvPill: { backgroundColor: '#7a2fd6', borderRadius: 999, borderWidth: 2.5, borderColor: '#ffffff', paddingHorizontal: 10, paddingVertical: 4 },
  lvPillText: { fontFamily: F.display, fontSize: 13, color: '#ffffff' },
});
