import React, { memo, useCallback, useEffect, useMemo, useState } from 'react';
import { Animated, BackHandler, StyleSheet, Text, View } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import CandyBackground from '../components/candy/CandyBackground';
import { KeptView, ViewSlot, useViewSwitch } from '../components/ViewSwitch';
import RoundButton, { BackGlyph } from '../components/candy/RoundButton';
import sfx from '../audio/sfx';
import Hub from '../sort/Hub';
import LevelMap from '../sort/LevelMap';
import SortGame, { SortBlitz } from '../sort/Game';
import { RulesCard } from '../sort/Cards';
import { LEVELS, doneIn, record, starsIn } from '../sort/levels';
import { MiniContainer } from '../sort/Container';
import { modelOf } from '../sort/models';
import { THEMES, poolOf } from '../sort/themes';
import { saveSort } from '../firebase/firestore';
import { F, INK } from '../squishdoku/theme';

// Squish Sort (SQUISH_SORT.md), opened from the Lobby's PLAY game picker:
// the hub (the fridge or the toy cupboard), that container's 50-level map,
// and a level, each sliding in over the last as placeholders first (as
// Squishdoku: src/components/ViewSwitch.js); or Blitz, straight from the hub.

// sounds kept loaded while the game is open (src/audio/sfx.js setBudget)
const SOUND_BUDGET = 26;
// a container needs this many different squishies to draw from
const MIN_POOL = 8;
// each view's placeholder while it's built
const BONES = { hub: 'hub', map: 'map', game: 'game', blitz: 'game' };

// the map: each fridge (or cupboard) with its picture and size, then a
// banner for each shelf it gains
const shelvesOf = (n) => `${n} ${n > 1 ? 'SHELVES' : 'SHELF'}`;
const MAP = Object.fromEntries(
  Object.keys(THEMES).map((theme) => [
    theme,
    {
      bannerOf: (L) => (L.first ? `${modelOf(theme, L.model).size}\n${modelOf(theme, L.model).name.toUpperCase()}` : `+1 SHELF · ${shelvesOf(L.rows)}`),
      iconOf: (L) => (L.first ? <MiniContainer m={modelOf(theme, L.model)} rows={L.rows} cols={L.cols} size={84} /> : null),
    },
  ]),
);

function SortScreen({ profile, creatures, hidden, uid, adsFree, haptics, onBack }) {
  const insets = useSafeAreaInsets();
  const rec = record(profile);
  const sw = useViewSwitch('hub'); // hub | map | game | blitz
  const { view, go } = sw;
  const [theme, setTheme] = useState('fridge');
  const [playLv, setPlayLv] = useState(1);
  const [rules, setRules] = useState(false);
  const pools = useMemo(() => ({ fridge: poolOf('fridge', creatures, hidden), cupboard: poolOf('cupboard', creatures, hidden) }), [creatures, hidden]);
  const mapUris = useMemo(() => pools[theme].map((c) => c.uri), [pools, theme]);

  useEffect(() => {
    sfx.setBudget(SOUND_BUDGET);
    sfx.music('party');
    // first visit: how to play
    if (!rec.seen) {
      setTimeout(() => setRules(true), 700);
      if (uid) saveSort(uid, { 'sort.seen': true }, 0);
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

  const openMap = useCallback(
    (k) => {
      setTheme(k);
      go('map');
    },
    [go],
  );
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

  const ready = view === 'blitz' ? pools.fridge.length >= MIN_POOL && pools.cupboard.length >= MIN_POOL : pools[theme].length >= MIN_POOL;
  const t = THEMES[theme];

  return (
    <CandyBackground style={{ paddingTop: insets.top }} sparkles>
      {view !== 'game' && view !== 'blitz' ? (
        <View style={styles.header}>
          <RoundButton size={40} onPress={() => (view === 'map' ? go('hub') : onBack())}>
            <BackGlyph />
          </RoundButton>
          {view === 'map' ? (
            <>
              <View style={styles.titleBox}>
                <Text style={[styles.headerTitle, { color: t.ring }]}>{t.name.toUpperCase()}</Text>
                <Text style={styles.headerSub}>{`${doneIn(rec, theme)} / ${LEVELS} levels`}</Text>
              </View>
              <View style={styles.starPill}>
                <Text style={styles.starPillText}>{`★ ${starsIn(rec, theme)}`}</Text>
              </View>
            </>
          ) : null}
        </View>
      ) : null}
      <Animated.View style={[styles.fill, sw.style]}>
        {/* the map stays built under a level, so leaving the level is instant */}
        <KeptView sw={sw} name="map" keepWhile={view === 'game'} bones="map">
          <LevelMap key={theme} rec={rec[theme]} uris={mapUris} onPlay={play} bannerOf={MAP[theme].bannerOf} iconOf={MAP[theme].iconOf} />
        </KeptView>
        {view !== 'map' ? (
          <ViewSlot sw={sw} bones={BONES[view]}>
            {view === 'hub' ? <Hub rec={rec} pools={pools} onPlay={openMap} onBlitz={() => go('blitz')} onRules={() => setRules(true)} /> : null}
            {view === 'blitz' ? (
              ready ? (
                <View style={[styles.fill, { paddingBottom: insets.bottom }]}>
                  <SortBlitz pools={pools} profile={profile} uid={uid} adsFree={adsFree} haptics={haptics} onExit={leaveBlitz} />
                </View>
              ) : (
                <View style={styles.wait}>
                  <Text style={styles.waitText}>The squishies are still on their way. Try again in a moment!</Text>
                  <RoundButton size={44} onPress={leaveBlitz}>
                    <BackGlyph />
                  </RoundButton>
                </View>
              )
            ) : null}
            {view === 'game' ? (
              ready ? (
                <View style={[styles.fill, { paddingBottom: insets.bottom }]}>
                  <SortGame theme={theme} startLv={playLv} pool={pools[theme]} profile={profile} uid={uid} haptics={haptics} onExit={leaveGame} />
                </View>
              ) : (
                <View style={styles.wait}>
                  <Text style={styles.waitText}>The squishies are still on their way. Try again in a moment!</Text>
                  <RoundButton size={44} onPress={leaveGame}>
                    <BackGlyph />
                  </RoundButton>
                </View>
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
  headerTitle: { fontFamily: F.display, fontSize: 20, letterSpacing: 1 },
  headerSub: { fontFamily: F.heavy, fontSize: 11.5, color: INK },
  starPill: { backgroundColor: '#ffffff', borderRadius: 999, borderWidth: 2.5, borderColor: '#ffd23a', paddingHorizontal: 10, paddingVertical: 4 },
  starPillText: { fontFamily: F.display, fontSize: 14, color: '#b86200' },
  wait: { flex: 1, alignItems: 'center', justifyContent: 'center', padding: 30, gap: 16 },
  waitText: { fontFamily: F.display, fontSize: 16, color: INK, textAlign: 'center' },
});

// App re-renders while it's open (Home waking on the way back, the profile)
export default memo(SortScreen);
