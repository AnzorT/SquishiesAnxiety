import React, { memo, useCallback, useEffect, useMemo, useState } from 'react';
import { Animated, BackHandler, StyleSheet, Text, View } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { GameBackground, GameBack } from '../royal/GameFrame';
import { ROW_ON_FLOOR, RoomBackdrop, useRoomStrip, useRoomUnder } from '../royal/WorldBg';
import { KeptView, ViewSlot, useViewSwitch } from '../components/ViewSwitch';
import RoundButton, { BackGlyph } from '../components/candy/RoundButton';
import sfx from '../audio/sfx';
import LevelMap from '../sort/LevelMap';
import HopGame from '../hop/Game';
import Hub from '../hop/Hub';
import { RulesCard } from '../hop/Cards';
import { RoomCard } from '../hop/Room';
import { LEVELS, LEVEL_LIST, ROOMS, TWISTS, doneOf, record, starsOf } from '../hop/levels';
import { castOf } from '../stack/roster';
import { ownedKey } from '../squishdoku/roster';
import { saveHop } from '../firebase/firestore';
import { F, INK } from '../squishdoku/theme';

// Squish Hop (SQUISH_HOP.md), opened from the Menu's Game Park: the
// hub (REGULAR MODE and BLITZ MODE cards, as Squishdoku's: the user,
// 2026-11-16), the level map (Squish Sort's map, a band per Crib room with the
// room's picture over its banner) and a level, each sliding in over the last
// as placeholders first (src/components/ViewSwitch.js); or BLITZ MODE,
// straight from the hub.

// sounds kept loaded while the game is open (src/audio/sfx.js setBudget)
const SOUND_BUDGET = 34;
// the most friends a level has, and the hopper
const MIN_CAST = 6;
const BONES = { hub: 'hub', map: 'map', game: 'game', blitz: 'game' };

// a room's banner: its name and the twist it brings in
const bannerOf = (L) => {
  const twist = LEVEL_LIST.find((x) => x.band === L.band && x.news);
  return `${ROOMS[L.room].name.toUpperCase()}${twist ? ` · ${TWISTS[twist.news].name}` : ''}`;
};
const iconOf = (L) => <RoomCard room={L.room} />;
// the room a level is played in (the map's background)
const roomOf = (L) => L.room;

function HopScreen({ profile, creatures, hidden, uid, adsFree, haptics, onBack }) {
  const insets = useSafeAreaInsets();
  const rec = record(profile);
  const sw = useViewSwitch('hub'); // hub | map | game | blitz
  const { view, go } = sw;
  const [playLv, setPlayLv] = useState(1);
  const [rules, setRules] = useState(false);
  const owned = ownedKey(profile);
  const cast = useMemo(() => castOf(creatures, profile, hidden), [creatures, hidden, owned]); // eslint-disable-line react-hooks/exhaustive-deps
  const uris = useMemo(() => cast.map((c) => c.uri), [cast]);
  // the map's background: the rooms its levels are played in, scrolling with it
  const strip = useRoomStrip();
  // the map's room held under a level that's starting, until the level has drawn its own (WorldBg useRoomUnder)
  const roomUnder = useRoomUnder(sw, sw.view === 'game');

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

  return (
    <GameBackground style={{ paddingTop: playing ? 0 : insets.top }}>
      {/* the level map runs through the rooms its levels are played in (src/royal/WorldBg.js) */}
      <RoomBackdrop sw={sw} on={view === 'map' || roomUnder} under={roomUnder} spans={strip.spans} scrollX={strip.scrollX} />
      {!playing ? (
        <View style={styles.header}>
          <GameBack onPress={() => (view === 'map' ? go('hub') : onBack())} />
          {view === 'map' ? (
            <>
              <View style={styles.titleBox}>
                <View style={styles.plaque}>
                  <Text style={styles.headerTitle}>SQUISH HOP</Text>
                  <Text style={styles.headerSub}>{`${doneOf(rec)} / ${LEVELS} levels`}</Text>
                </View>
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
          <LevelMap rec={rec} uris={uris} onPlay={play} list={LEVEL_LIST} bannerOf={bannerOf} iconOf={iconOf} roomOf={roomOf} onSpans={strip.onSpans} scrollX={strip.scrollX} rowAt={ROW_ON_FLOOR} />
        </KeptView>
        {view !== 'map' ? (
          <ViewSlot sw={sw} bones={BONES[view]}>
            {view === 'hub' ? <Hub rec={rec} onRegular={() => go('map')} onBlitz={() => go('blitz')} onRules={() => setRules(true)} /> : null}
            {playing ? (
              ready ? (
                view === 'blitz' ? (
                  <HopGame blitz cast={cast} profile={profile} uid={uid} adsFree={adsFree} haptics={haptics} onExit={leaveBlitz} />
                ) : (
                  <HopGame startLv={playLv} cast={cast} profile={profile} uid={uid} adsFree={adsFree} haptics={haptics} onExit={leaveGame} />
                )
              ) : (
                <View style={[styles.wait, { paddingTop: insets.top }]}>
                  <Text style={styles.waitText}>The squishies are still on their way. Try again in a moment!</Text>
                  <RoundButton size={44} onPress={view === 'blitz' ? leaveBlitz : leaveGame}>
                    <BackGlyph />
                  </RoundButton>
                </View>
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
  // the title sits on the room's wall: on a plaque, to read over the furniture
  plaque: { alignItems: 'center', backgroundColor: 'rgba(255,247,234,0.94)', borderRadius: 16, borderWidth: 2, borderColor: '#e2b27a', paddingHorizontal: 16, paddingTop: 1, paddingBottom: 3 },
  headerTitle: { fontFamily: F.display, fontSize: 20, letterSpacing: 1, color: '#8a3a0e' },
  headerSub: { fontFamily: F.heavy, fontSize: 11.5, color: INK, textAlign: 'center' },
  starPill: { backgroundColor: '#ffffff', borderRadius: 999, borderWidth: 2.5, borderColor: '#ffd23a', paddingHorizontal: 10, paddingVertical: 4 },
  starPillText: { fontFamily: F.display, fontSize: 14, color: '#b86200' },
  wait: { flex: 1, alignItems: 'center', justifyContent: 'center', padding: 30, gap: 16 },
  waitText: { fontFamily: F.display, fontSize: 16, color: INK, textAlign: 'center' },
});

// App re-renders while it's open (Home waking on the way back, the profile)
export default memo(HopScreen);
