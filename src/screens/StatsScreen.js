import React, { useMemo } from 'react';
import { View, Text, Image, ScrollView, StyleSheet } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { LinearGradient } from 'expo-linear-gradient';
import { candyColors, candyFonts } from '../theme/candyTheme';
import { computeAchievements } from '../achievements';
import CandyBackground from '../components/candy/CandyBackground';
import RoundButton, { BackGlyph } from '../components/candy/RoundButton';
import OutlinedTitle from '../components/candy/OutlinedTitle';
import { CandyProgress } from '../components/candy/Decor';
import CreatureThumbnail from '../components/CreatureThumbnail';
import AssembleCreature from '../components/AssembleCreature';
import AdStrip from '../components/AdStrip';

// The player's stats, opened from Home's chart button (they used to sit at
// the bottom of Settings): their favourite creature, a grid of totals, and
// the creatures they've squished longest. Everything is read from the
// profile — `stats` (presses, longest hold, hold time per creature; written
// by recordPress in src/firebase/firestore.js), totalEarned, boxOpens,
// maxMult — plus the catalog and the player's own creations.

const TOP_COUNT = 5;

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

// The Key Shop's card: violet ring, white rim, pale pink face.
function Card({ children, style }) {
  return (
    <View style={[styles.cardRing, style]}>
      <View style={styles.cardWhite}>
        <LinearGradient colors={['#fff6fd', '#ffdcf4', '#f5cbff']} locations={[0, 0.6, 1]} style={styles.cardFace}>
          {children}
        </LinearGradient>
      </View>
    </View>
  );
}

function Tile({ value, label, color }) {
  return (
    <Card style={styles.tile}>
      <Text style={[styles.tileValue, color && { color }]} numberOfLines={1} adjustsFontSizeToFit>
        {value}
      </Text>
      <Text style={styles.tileLabel} numberOfLines={1} adjustsFontSizeToFit>
        {label}
      </Text>
    </Card>
  );
}

export default function StatsScreen({ creatures = [], customCreatures = [], profile = null, onBack }) {
  const insets = useSafeAreaInsets();
  const p = profile || {};
  const stats = p.stats || {};
  const adsFree = !!p.adsFree;

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
    { label: 'SQUISHES', value: (stats.presses || 0).toLocaleString(), color: '#d3179a' },
    { label: 'LONGEST HOLD', value: `${((stats.longestHoldMs || 0) / 1000).toFixed(1)}s`, color: '#1695d6' },
    { label: 'TIME SQUISHING', value: formatDuration(totalMs), color: '#7a2ff0' },
    { label: 'COINS EARNED', value: (p.totalEarned || 0).toLocaleString(), color: candyColors.goldInk },
    { label: 'CREATURES', value: `${owned}/${rosterSize}`, color: '#d3179a' },
    { label: 'ACHIEVEMENTS', value: `${achDone}/${achievements.length}`, color: candyColors.goldInk },
    { label: 'BOXES OPENED', value: (p.boxOpens || 0).toLocaleString(), color: '#7a2ff0' },
    { label: 'BIGGEST BOOST', value: p.maxMult ? `×${p.maxMult}` : '—', color: '#1695d6' },
  ];

  return (
    <CandyBackground style={{ paddingTop: insets.top }}>
      <View style={styles.header}>
        <RoundButton size={36} onPress={onBack}>
          <BackGlyph />
        </RoundButton>
        <OutlinedTitle text="YOUR STATS" fill="pink" size={20} outline={3} ring={2} drop={5} />
      </View>

      <ScrollView contentContainerStyle={[styles.body, { paddingBottom: adsFree ? insets.bottom + 24 : 24 }]} showsVerticalScrollIndicator={false}>
        <Card>
          <View style={styles.favRow}>
            <View style={styles.favArt}>{favorite ? <Art entry={favorite} size={92} /> : null}</View>
            <View style={styles.flex}>
              <Text style={styles.kicker}>FAVORITE CREATURE</Text>
              {favorite ? (
                <>
                  <Text style={styles.favName} numberOfLines={1}>
                    {nameOf(favorite)}
                  </Text>
                  <Text style={styles.favSub}>{`${formatDuration(favorite.ms)} of squishing`}</Text>
                </>
              ) : (
                <Text style={styles.favSub}>Squish a creature to find your favorite!</Text>
              )}
            </View>
          </View>
        </Card>

        <View style={styles.grid}>
          {tiles.map((t) => (
            <Tile key={t.label} {...t} />
          ))}
        </View>

        {top.length ? (
          <Card>
            <Text style={[styles.kicker, styles.listTitle]}>MOST SQUISHED</Text>
            {top.map((entry, i) => (
              <View key={entry.id} style={[styles.rankRow, i === top.length - 1 && styles.rankRowLast]}>
                <Text style={styles.rankNum}>{i + 1}</Text>
                <View style={styles.rankArt}>
                  <Art entry={entry} size={40} />
                </View>
                <View style={styles.flex}>
                  <View style={styles.rankTop}>
                    <Text style={styles.rankName} numberOfLines={1}>
                      {nameOf(entry)}
                    </Text>
                    <Text style={styles.rankTime}>{formatDuration(entry.ms)}</Text>
                  </View>
                  <CandyProgress pct={(entry.ms / top[0].ms) * 100} height={8} ring={candyColors.pinkRing} fill={['#ffa8e6', '#ff4fbf']} />
                </View>
              </View>
            ))}
          </Card>
        ) : null}
      </ScrollView>
      {/* the ad strip along the bottom, as on Home (none with Remove Ads) */}
      {adsFree ? null : <AdStrip />}
    </CandyBackground>
  );
}

const TILE_GAP = 10;

const styles = StyleSheet.create({
  flex: { flex: 1 },
  header: { flexDirection: 'row', alignItems: 'center', gap: 8, paddingHorizontal: 16, paddingTop: 12, paddingBottom: 8 },
  body: { paddingHorizontal: 16, paddingTop: 6, gap: 12 },

  cardRing: {
    borderRadius: 23,
    padding: 2.5,
    backgroundColor: candyColors.cardRing,
    shadowColor: '#320064',
    shadowOffset: { width: 0, height: 8 },
    shadowOpacity: 0.35,
    shadowRadius: 9,
    elevation: 6,
  },
  cardWhite: { borderRadius: 20, borderWidth: 3, borderColor: '#ffffff', overflow: 'hidden' },
  cardFace: { paddingHorizontal: 14, paddingVertical: 12 },

  favRow: { flexDirection: 'row', alignItems: 'center', gap: 14 },
  favArt: { width: 92, height: 92, alignItems: 'center', justifyContent: 'center' },
  kicker: { color: candyColors.goldInk, fontFamily: candyFonts.bodyHeavy, fontSize: 11.5, letterSpacing: 1.2 },
  favName: { color: candyColors.ink, fontFamily: candyFonts.display, fontSize: 26, marginTop: 2 },
  favSub: { color: candyColors.muted, fontFamily: candyFonts.body, fontSize: 13, marginTop: 2 },

  grid: { flexDirection: 'row', flexWrap: 'wrap', justifyContent: 'space-between', rowGap: TILE_GAP },
  tile: { width: '48.4%' },
  tileValue: { color: candyColors.ink, fontFamily: candyFonts.display, fontSize: 24, includeFontPadding: false },
  tileLabel: { color: candyColors.inkSoft, fontFamily: candyFonts.bodyHeavy, fontSize: 11, letterSpacing: 1, marginTop: 3 },

  listTitle: { marginBottom: 8 },
  rankRow: { flexDirection: 'row', alignItems: 'center', gap: 10, marginBottom: 10 },
  rankRowLast: { marginBottom: 0 },
  rankNum: { width: 16, textAlign: 'center', color: candyColors.inkSoft, fontFamily: candyFonts.display, fontSize: 15 },
  rankArt: { width: 40, height: 40, alignItems: 'center', justifyContent: 'center' },
  rankTop: { flexDirection: 'row', alignItems: 'baseline', justifyContent: 'space-between', marginBottom: 4, gap: 8 },
  rankName: { flex: 1, color: candyColors.ink, fontFamily: candyFonts.display, fontSize: 15 },
  rankTime: { color: candyColors.inkSoft, fontFamily: candyFonts.body, fontSize: 12.5 },
});
