import React, { memo, useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { Animated, BackHandler, StyleSheet, Text, View } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { GameBackground, GameBack } from '../royal/GameFrame';
import { KeptView, ViewSlot, useViewSwitch } from '../components/ViewSwitch';
import RoundButton, { BackGlyph } from '../components/candy/RoundButton';
import sfx from '../audio/sfx';
import ForestMap from '../stack/ForestMap';
import StackGame from '../stack/Game';
import Hub from '../stack/Hub';
import { RulesCard } from '../stack/Cards';
import { LEVELS, LEVEL_LIST, doneOf, record, starsOf } from '../stack/levels';
import { castOf } from '../stack/roster';
import { ownedKey } from '../squishdoku/roster';
import { BY_ID } from '../squad/data';
import { selectedId } from '../squad/lobby';
import { saveStack } from '../firebase/firestore';
import { F, INK } from '../squishdoku/theme';

// Squish Stack (SQUISH_STACK.md), opened from the Menu's Game Park: the hub
// (REGULAR MODE and BLITZ MODE cards), REGULAR's 50-level forest road
// (src/stack/ForestMap.js) and a level, each sliding in over the
// last as placeholders first (src/components/ViewSwitch.js); or BLITZ MODE,
// straight from the hub.

// sounds kept loaded while the game is open (src/audio/sfx.js setBudget)
const SOUND_BUDGET = 28;
// the biggest level stacks 8 different squishies
const MIN_CAST = 8;
// each view's placeholder while it's built
const BONES = { hub: 'hub', map: 'map', game: 'game', blitz: 'game' };

const bannerOf = (L) => `${L.n} SQUISHIES · ${L.k} CUSHIONS`;

function StackScreen({ profile, creatures, hidden, uid, adsFree, haptics, onBack }) {
  const insets = useSafeAreaInsets();
  const rec = record(profile);
  const sw = useViewSwitch('hub'); // hub | map | game | blitz
  const { view, go } = sw;
  const [playLv, setPlayLv] = useState(1);
  const [rules, setRules] = useState(false);
  const owned = ownedKey(profile);
  const cast = useMemo(() => castOf(creatures, profile, hidden), [creatures, hidden, owned]); // eslint-disable-line react-hooks/exhaustive-deps
  // the forest map's walker: the player's selected character (the Menu's pick)
  const walker = BY_ID[selectedId(profile)]?.key || null;
  // each time the map comes into view (the walker gets a fresh page: src/stack/ForestMap.js)
  const visits = useRef({ n: 0, last: null });
  if (view === 'map' && visits.current.last !== 'map') visits.current.n += 1;
  visits.current.last = view;

  useEffect(() => {
    sfx.setBudget(SOUND_BUDGET);
    // first visit: how to play
    if (!rec.seen) {
      setTimeout(() => setRules(true), 700);
      if (uid) saveStack(uid, { 'stack.seen': true }, 0);
    }
    return () => sfx.setBudget(null);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  // back: rules → map → hub → lobby (the game and Blitz handle their own)
  useEffect(() => {
    if (view === 'game' || view === 'blitz') return undefined;
    const sub = BackHandler.addEventListener('hardwareBackPress', () => {
      if (rules) setRules(false);
      else if (view === 'map') go('hub');
      else onBack();
      sfx.play('sd_boardOut');
      return true;
    });
    return () => sub.remove();
  }, [view, rules, go, onBack]);

  const play = useCallback(
    (lv) => {
      setPlayLv(lv);
      go('game');
    },
    [go],
  );
  const leaveGame = useCallback(() => {
    sfx.play('sd_boardOut');
    go('map');
  }, [go]);
  const leaveBlitz = useCallback(() => {
    sfx.play('sd_boardOut');
    go('hub');
  }, [go]);

  const ready = cast.length >= MIN_CAST;
  const playing = view === 'game' || view === 'blitz';
  const waiting = (
    <View style={styles.wait}>
      <Text style={styles.waitText}>The squishies are still on their way. Try again in a moment!</Text>
      <RoundButton size={44} onPress={view === 'blitz' ? leaveBlitz : leaveGame}>
        <BackGlyph />
      </RoundButton>
    </View>
  );

  // the map is the forest, the whole screen, with this bar over its sky
  const header = (
    <View style={styles.header}>
      <GameBack onPress={() => (view === 'map' ? go('hub') : onBack())} />
      {view === 'map' ? (
        <>
          <View style={styles.titleBox}>
            <Text style={styles.headerTitle}>SQUISH STACK</Text>
            <Text style={styles.headerSub}>{`${doneOf(rec)} / ${LEVELS} levels`}</Text>
          </View>
          <View style={styles.starPill}>
            <Text style={styles.starPillText}>{`★ ${starsOf(rec)}`}</Text>
          </View>
        </>
      ) : null}
    </View>
  );

  return (
    <GameBackground style={{ paddingTop: insets.top }}>
      {!playing && view !== 'map' ? header : null}
      <Animated.View style={[styles.fill, sw.style]}>
        {/* the map stays built under a level, so leaving the level is instant */}
        <KeptView sw={sw} name="map" keepWhile={view === 'game'} bones="map">
          <ForestMap rec={rec} list={LEVEL_LIST} bannerOf={bannerOf} onPlay={play} walker={walker} visit={visits.current.n} header={header} />
        </KeptView>
        {view !== 'map' ? (
          <ViewSlot sw={sw} bones={BONES[view]}>
            {view === 'hub' ? <Hub rec={rec} onRegular={() => go('map')} onBlitz={() => go('blitz')} onRules={() => setRules(true)} /> : null}
            {view === 'game' ? (
              ready ? (
                <View style={[styles.fill, { paddingBottom: insets.bottom }]}>
                  <StackGame startLv={playLv} cast={cast} profile={profile} uid={uid} adsFree={adsFree} haptics={haptics} onExit={leaveGame} />
                </View>
              ) : (
                waiting
              )
            ) : null}
            {view === 'blitz' ? (
              ready ? (
                <View style={[styles.fill, { paddingBottom: insets.bottom }]}>
                  <StackGame blitz cast={cast} profile={profile} uid={uid} adsFree={adsFree} haptics={haptics} onExit={leaveBlitz} />
                </View>
              ) : (
                waiting
              )
            ) : null}
          </ViewSlot>
        ) : null}
      </Animated.View>
      <RulesCard visible={rules} onClose={() => setRules(false)} />
    </GameBackground>
  );
}

const styles = StyleSheet.create({
  fill: { flex: 1 },
  header: { flexDirection: 'row', alignItems: 'center', gap: 10, paddingHorizontal: 14, paddingTop: 6, paddingBottom: 2 },
  titleBox: { flex: 1, alignItems: 'center' },
  // over the forest's sky
  headerTitle: { fontFamily: F.display, fontSize: 20, letterSpacing: 1, color: '#ffffff', textShadowColor: 'rgba(90,40,10,0.85)', textShadowOffset: { width: 0, height: 2 }, textShadowRadius: 3 },
  headerSub: { fontFamily: F.heavy, fontSize: 11.5, color: '#ffffff', textShadowColor: 'rgba(60,30,10,0.8)', textShadowOffset: { width: 0, height: 1 }, textShadowRadius: 2 },
  starPill: { backgroundColor: '#ffffff', borderRadius: 999, borderWidth: 2.5, borderColor: '#ffd23a', paddingHorizontal: 10, paddingVertical: 4 },
  starPillText: { fontFamily: F.display, fontSize: 14, color: '#b86200' },
  wait: { flex: 1, alignItems: 'center', justifyContent: 'center', padding: 30, gap: 16 },
  waitText: { fontFamily: F.display, fontSize: 16, color: INK, textAlign: 'center' },
});

// App re-renders while it's open (Home waking on the way back, the profile)
export default memo(StackScreen);
