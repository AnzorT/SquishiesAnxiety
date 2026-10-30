import React, { memo, useCallback, useEffect, useMemo, useState } from 'react';
import { Animated, BackHandler, StyleSheet, Text, View } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import CandyBackground from '../components/candy/CandyBackground';
import { KeptView, ViewSlot, useViewSwitch } from '../components/ViewSwitch';
import RoundButton, { BackGlyph } from '../components/candy/RoundButton';
import sfx from '../audio/sfx';
import LevelMap from '../sort/LevelMap';
import StackGame from '../stack/Game';
import Hub from '../stack/Hub';
import { RulesCard } from '../stack/Cards';
import { LEVELS, LEVEL_LIST, doneOf, record, starsOf } from '../stack/levels';
import { castOf } from '../stack/roster';
import { ownedKey } from '../squishdoku/roster';
import { saveStack } from '../firebase/firestore';
import { F, INK } from '../squishdoku/theme';

// Squish Stack (SQUISH_STACK.md), opened from the Lobby's PLAY game picker:
// the hub, REGULAR's 50-level map (Squish Sort's map, with this game's
// levels) and a level, each sliding in over the last as placeholders first
// (src/components/ViewSwitch.js); or BLITZ, straight from the hub.

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
  const uris = useMemo(() => cast.map((c) => c.uri), [cast]);

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
  // Blitz plays to party music (as Squishdoku's)
  useEffect(() => {
    if (view !== 'blitz') return undefined;
    sfx.music('party');
    return () => sfx.music('cozy');
  }, [view]);


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

  return (
    <CandyBackground style={{ paddingTop: insets.top }} sparkles>
      {!playing ? (
        <View style={styles.header}>
          <RoundButton size={40} onPress={() => (view === 'map' ? go('hub') : onBack())}>
            <BackGlyph />
          </RoundButton>
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
      ) : null}
      <Animated.View style={[styles.fill, sw.style]}>
        {/* the map stays built under a level, so leaving the level is instant */}
        <KeptView sw={sw} name="map" keepWhile={view === 'game'} bones="map">
          <LevelMap rec={rec} uris={uris} onPlay={play} list={LEVEL_LIST} bannerOf={bannerOf} />
        </KeptView>
        {view !== 'map' ? (
          <ViewSlot sw={sw} bones={BONES[view]}>
            {view === 'hub' ? <Hub rec={rec} uris={uris} onRegular={() => go('map')} onBlitz={() => go('blitz')} onRules={() => setRules(true)} /> : null}
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
    </CandyBackground>
  );
}

const styles = StyleSheet.create({
  fill: { flex: 1 },
  header: { flexDirection: 'row', alignItems: 'center', gap: 10, paddingHorizontal: 14, paddingTop: 6, paddingBottom: 2 },
  titleBox: { flex: 1, alignItems: 'center' },
  headerTitle: { fontFamily: F.display, fontSize: 20, letterSpacing: 1, color: '#8e1580' },
  headerSub: { fontFamily: F.heavy, fontSize: 11.5, color: INK },
  starPill: { backgroundColor: '#ffffff', borderRadius: 999, borderWidth: 2.5, borderColor: '#ffd23a', paddingHorizontal: 10, paddingVertical: 4 },
  starPillText: { fontFamily: F.display, fontSize: 14, color: '#b86200' },
  wait: { flex: 1, alignItems: 'center', justifyContent: 'center', padding: 30, gap: 16 },
  waitText: { fontFamily: F.display, fontSize: 16, color: INK, textAlign: 'center' },
});

// App re-renders while it's open (Home waking on the way back, the profile)
export default memo(StackScreen);
