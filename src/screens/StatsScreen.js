import React, { memo, useMemo } from 'react';
import { View, Text, Image, StyleSheet } from 'react-native';
import { computeAchievements } from '../achievements';
import { CandyProgress } from '../components/candy/Decor';
import CreatureThumbnail from '../components/CreatureThumbnail';
import AssembleCreature from '../components/AssembleCreature';
import { fmtNum } from '../format';
import { InkText, Lettering, PageBg, PageHeader, Plaque, Stage, FONT as RFONT } from '../royal';

// The player's stats, opened from Settings: their favourite creature and
// the creatures they've squished longest on the left, a grid of totals on
// the right. Everything is read from the
// profile — `stats` (presses, longest hold, hold time per creature; written
// by recordPress in src/firebase/firestore.js), totalEarned, boxOpens,
// maxMult — plus the catalog and the player's own creations.

const TOP_COUNT = 3;

// 754000 → "12m 34s"; 4500000 → "1h 15m"; 8000 → "8s"
export function formatDuration(ms) {
  const s = Math.floor((ms || 0) / 1000);
  if (s < 60) return `${s}s`;
  const m = Math.floor(s / 60);
  if (m < 60) return `${m}m ${s % 60}s`;
  return `${Math.floor(m / 60)}h ${m % 60}m`;
}

// Every creature with squish time, longest first: { id, ms, creature?, custom? }.
function rankPlayTime(playTime, creatures, customCreatures) {
  return Object.entries(playTime || {})
    .filter(([, ms]) => ms > 0)
    .map(([id, ms]) => {
      if (id.startsWith('custom:')) {
        const custom = customCreatures.find((c) => `custom:${c.id}` === id);
        return custom ? { id, ms, custom } : null;
      }
      const creature = creatures.find((c) => c.id === id);
      return creature ? { id, ms, creature } : null;
    })
    .filter(Boolean)
    .sort((a, b) => b.ms - a.ms);
}

function Art({ entry, size }) {
  // no glow at list size: it only hazes a small thumbnail
  if (entry.creature) return <CreatureThumbnail creature={entry.creature} mood="idle" size={size} glow={size > 60} />;
  const { custom } = entry;
  if (custom.build) return <AssembleCreature build={custom.build} size={size} />;
  if (custom.sourceImageUrl) return <Image source={{ uri: custom.sourceImageUrl }} style={{ width: size, height: size, borderRadius: size / 4 }} />;
  return <View style={{ width: size, height: size }} />;
}

const nameOf = (entry) => (entry.creature ? entry.creature.name : entry.custom.name);

function StatsScreen({ creatures = [], customCreatures = [], profile = null, onBack }) {
  const p = profile || {};
  const stats = p.stats || {};

  const ranked = useMemo(() => rankPlayTime(stats.playTime, creatures, customCreatures), [stats.playTime, creatures, customCreatures]);
  const achievements = useMemo(() => computeAchievements(creatures, p, customCreatures.length), [creatures, p, customCreatures.length]);

  const favorite = ranked[0] || null;
  const totalMs = Object.values(stats.playTime || {}).reduce((sum, ms) => sum + (ms > 0 ? ms : 0), 0);
  // the numbered roster creatures (custom ones aren't counted)
  const roster = creatures.filter((c) => /^\d+$/.test(c.id));
  const owned = roster.filter((c) => (p.ownedIds || []).includes(c.id)).length;
  const rosterSize = roster.length || creatures.length;
  const achDone = achievements.filter((a) => a.done).length;
  const top = ranked.slice(0, TOP_COUNT);

  const tiles = [
    { label: 'SQUISHES', value: fmtNum(stats.presses || 0) },
    { label: 'LONGEST HOLD', value: `${((stats.longestHoldMs || 0) / 1000).toFixed(1)}s` },
    { label: 'TIME SQUISHING', value: formatDuration(totalMs) },
    { label: 'COINS EARNED', value: fmtNum(p.totalEarned || 0) },
    { label: 'CREATURES', value: `${owned}/${rosterSize}` },
    { label: 'ACHIEVEMENTS', value: `${achDone}/${achievements.length}` },
    { label: 'BOXES OPENED', value: fmtNum(p.boxOpens || 0) },
    { label: 'BIGGEST BOOST', value: p.maxMult ? `×${p.maxMult}` : '—' },
  ];

  // the new look (REDESIGN_V7 step 3): favourite + most squished on the left, the totals as tiles on the right
  return (
    <View style={styles.wRoot}>
      <PageBg />
      <Stage>
        <PageHeader title="Your Stats" onBack={onBack} />
        <Plaque variant="vel" radius={22} rim={3.5} ring={2} lip={4} style={styles.wLeft}>
          <View style={styles.favRow}>
            <View style={styles.favArt}>{favorite ? <Art entry={favorite} size={72} /> : null}</View>
            <View style={styles.flex}>
              <Text style={styles.wKicker}>FAVORITE</Text>
              {favorite ? <Lettering text={nameOf(favorite)} variant="gold" size={20} style={{ alignItems: 'flex-start' }} /> : null}
              <Text style={styles.wSub}>{favorite ? `${formatDuration(favorite.ms)} of squishing` : 'Squish a creature to find your favorite!'}</Text>
            </View>
          </View>
          {top.length ? <Text style={[styles.wKicker, { marginTop: 4 }]}>MOST SQUISHED</Text> : null}
          {top.map((entry, i) => (
            <View key={entry.id} style={styles.wRank}>
              <InkText size={14}>{String(i + 1)}</InkText>
              <View style={styles.rankArt}>
                <Art entry={entry} size={30} />
              </View>
              <View style={styles.flex}>
                <View style={styles.rankTop}>
                  <Text style={styles.wRankName} numberOfLines={1}>{nameOf(entry)}</Text>
                  <Text style={styles.wRankTime}>{formatDuration(entry.ms)}</Text>
                </View>
                <CandyProgress pct={(entry.ms / top[0].ms) * 100} height={7} ring="#6b4426" fill={['#ffe08a', '#f0a21c']} />
              </View>
            </View>
          ))}
        </Plaque>
        <View style={styles.wGrid}>
          {tiles.map((t) => (
            <Plaque key={t.label} variant="vel" radius={18} rim={3} ring={2} lip={4} style={styles.wTile}>
              <Lettering text={t.value} variant="gold" size={22} />
              <Text style={styles.wTileLabel} numberOfLines={2}>{t.label}</Text>
            </Plaque>
          ))}
        </View>
      </Stage>
    </View>
  );
}

const styles = StyleSheet.create({
  // in the design's 393-tall units (REDESIGN_V7)
  wRoot: { ...StyleSheet.absoluteFillObject, backgroundColor: '#24123f' },
  wLeft: { position: 'absolute', left: 22, top: 72, bottom: 22, width: 300, paddingHorizontal: 16, paddingVertical: 12, alignItems: 'stretch', justifyContent: 'flex-start', gap: 6 },
  wKicker: { fontFamily: RFONT.bodyBlack, fontSize: 10, letterSpacing: 1.4, color: '#ffe27a' },
  wSub: { fontFamily: RFONT.body, fontSize: 11.5, color: '#fff6e2' },
  wRank: { flexDirection: 'row', alignItems: 'center', gap: 8, paddingVertical: 3 },
  wRankName: { flex: 1, fontFamily: RFONT.display, fontSize: 13.5, color: '#ffffff' },
  wRankTime: { fontFamily: RFONT.bodyHeavy, fontSize: 11, color: '#ffe9a8' },
  wGrid: { position: 'absolute', left: 340, right: 22, top: 72, bottom: 22, flexDirection: 'row', flexWrap: 'wrap', alignContent: 'space-between', justifyContent: 'space-between' },
  wTile: { width: '23.5%', height: 136, gap: 6, paddingHorizontal: 8 },
  // (two lines when it needs them: LONGEST HOLD, TIME SQUISHING… were cut to "LONGES…" on a 796 dp wide phone)
  wTileLabel: { fontFamily: RFONT.bodyBlack, fontSize: 9.5, lineHeight: 12, letterSpacing: 1, color: '#fff6e2', textAlign: 'center' },
  flex: { flex: 1 },
  favRow: { flexDirection: 'row', alignItems: 'center', gap: 14 },
  favArt: { width: 92, height: 92, alignItems: 'center', justifyContent: 'center' },
  rankArt: { width: 40, height: 40, alignItems: 'center', justifyContent: 'center' },
  rankTop: { flexDirection: 'row', alignItems: 'baseline', justifyContent: 'space-between', marginBottom: 4, gap: 8 },
});

// memoized: App re-renders while this is open (Home going to sleep under it,
// a profile change), and those re-rendered the whole screen
export default memo(StatsScreen);
