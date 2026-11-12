import React, { memo, useCallback, useEffect, useMemo, useState } from 'react';
import { Animated, BackHandler, StyleSheet, Text, View } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import CandyBackground from '../components/candy/CandyBackground';
import { KeptView, ViewSlot, useViewSwitch } from '../components/ViewSwitch';
import RoundButton, { BackGlyph } from '../components/candy/RoundButton';
import sfx from '../audio/sfx';
import LevelMap from '../sort/LevelMap';
import HopGame from '../hop/Game';
import { RulesCard } from '../hop/Cards';
import { RoomCard } from '../hop/Room';
import { LEVELS, LEVEL_LIST, ROOMS, TWISTS, doneOf, record, starsOf } from '../hop/levels';
import { castOf } from '../stack/roster';
import { ownedKey } from '../squishdoku/roster';
import { saveHop } from '../firebase/firestore';
import { F, INK } from '../squishdoku/theme';

// Squish Hop (SQUISH_HOP.md), opened from the Lobby's PLAY game picker: the
// level map (Squish Sort's map, a band per Crib room with the room's picture
// over its banner) and a level, sliding in over it as placeholders first
// (src/components/ViewSwitch.js).

// sounds kept loaded while the game is open (src/audio/sfx.js setBudget)
const SOUND_BUDGET = 28;
// the most friends a level has, and the hopper
const MIN_CAST = 6;
const BONES = { map: 'map', game: 'game' };

// a room's banner: its name and the twist it brings in
const bannerOf = (L) => {
  const twist = LEVEL_LIST.find((x) => x.band === L.band && x.news);
  return `${ROOMS[L.room].name.toUpperCase()}${twist ? ` · ${TWISTS[twist.news].name}` : ''}`;
};
const iconOf = (L) => <RoomCard room={L.room} />;

function HopScreen({ profile, creatures, hidden, uid, adsFree, haptics, onBack }) {
  const insets = useSafeAreaInsets();
  const rec = record(profile);
  const sw = useViewSwitch('map'); // map | game
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
      if (uid) saveHop(uid, { 'hop.seen': true }, 0);
    }
    return () => sfx.setBudget(null);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  // back: rules → map → lobby (the game handles its own)
  useEffect(() => {
    if (view === 'game') return undefined;
    const sub = BackHandler.addEventListener('hardwareBackPress', () => {
      if (rules) setRules(false);
      else onBack();
      sfx.play('sd_boardOut');
      return true;
    });
    return () => sub.remove();
  }, [view, rules, onBack]);

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

  const ready = cast.length >= MIN_CAST;
  const playing = view === 'game';

  return (
    <CandyBackground style={{ paddingTop: playing ? 0 : insets.top }} sparkles={!playing}>
      {!playing ? (
        <View style={styles.header}>
          <RoundButton size={40} onPress={onBack}>
            <BackGlyph />
          </RoundButton>
          <View style={styles.titleBox}>
            <Text style={styles.headerTitle}>SQUISH HOP</Text>
            <Text style={styles.headerSub}>{`${doneOf(rec)} / ${LEVELS} levels`}</Text>
          </View>
          <RoundButton size={40} onPress={() => setRules(true)}>
            <Text style={styles.help}>?</Text>
          </RoundButton>
          <View style={styles.starPill}>
            <Text style={styles.starPillText}>{`★ ${starsOf(rec)}`}</Text>
          </View>
        </View>
      ) : null}
      <Animated.View style={[styles.fill, sw.style]}>
        {/* the map stays built under a level, so leaving the level is instant */}
        <KeptView sw={sw} name="map" keepWhile={view === 'game'} bones="map">
          <LevelMap rec={rec} uris={uris} onPlay={play} list={LEVEL_LIST} bannerOf={bannerOf} iconOf={iconOf} />
        </KeptView>
        {view !== 'map' ? (
          <ViewSlot sw={sw} bones={BONES[view]}>
            {ready ? (
              <HopGame startLv={playLv} cast={cast} profile={profile} uid={uid} adsFree={adsFree} haptics={haptics} onExit={leaveGame} />
            ) : (
              <View style={[styles.wait, { paddingTop: insets.top }]}>
                <Text style={styles.waitText}>The squishies are still on their way. Try again in a moment!</Text>
                <RoundButton size={44} onPress={leaveGame}>
                  <BackGlyph />
                </RoundButton>
              </View>
            )}
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
  help: { fontFamily: F.display, fontSize: 20, color: '#ffffff', includeFontPadding: false },
  starPill: { backgroundColor: '#ffffff', borderRadius: 999, borderWidth: 2.5, borderColor: '#ffd23a', paddingHorizontal: 10, paddingVertical: 4 },
  starPillText: { fontFamily: F.display, fontSize: 14, color: '#b86200' },
  wait: { flex: 1, alignItems: 'center', justifyContent: 'center', padding: 30, gap: 16 },
  waitText: { fontFamily: F.display, fontSize: 16, color: INK, textAlign: 'center' },
});

// App re-renders while it's open (Home waking on the way back, the profile)
export default memo(HopScreen);
