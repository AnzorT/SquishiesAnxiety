import React, { memo, useEffect, useState } from 'react';
import { View, Text, Pressable, StyleSheet } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Rect, Path } from 'react-native-svg';
import { Btn, InkText, Lettering, Orb, Plaque, FONT, INK } from '../royal';
import { dailyView } from '../progression';
import sfx from '../audio/sfx';

// DAILY CHALLENGES (the 2026-10-03 design's panel), in the game's wood look (2026-11-20: it was the old design's white
// candy card with a blue candy button): over the menu, a wood panel the screen's height with "In Squish Squad" (3 game
// challenges) and "In the Crib" (3 house ones, OPEN CRIB) side by side, each row a progress bar, its reward, CLAIM +N
// when done, DONE once claimed; and the daily chest along the bottom: claim all six for its coins, XP and the streak's
// reward (the streak has its own screen: StreakScreen). The rules and the rows come from src/progression.js; the panel
// reads them again every minute so the "new challenges in 5h 12m" countdown keeps time. Everything fits on the screen
// (no scrolling).

function ChestIcon() {
  return (
    <Svg width={34} height={32} viewBox="0 0 30 28">
      <Rect x={3} y={11} width={24} height={15} rx={3} fill="#cf955a" stroke={INK} strokeWidth={2} />
      <Path d="M3 13 Q3 3 15 3 Q27 3 27 13 Z" fill="#e6b47c" stroke={INK} strokeWidth={2} strokeLinejoin="round" />
      <Rect x={12} y={10} width={6} height={8} rx={1.5} fill="#ffe045" stroke="#a04a00" strokeWidth={1.6} />
    </Svg>
  );
}

function Bar({ pct, gold }) {
  return (
    <View style={styles.bar}>
      <LinearGradient colors={gold ? ['#fffbd6', '#ffe045', '#ff9500'] : ['#ffe08a', '#ffb347', '#f07a1c']} locations={[0, 0.5, 1]} style={[styles.barFill, { width: `${Math.max(0, Math.min(100, pct))}%` }]} />
    </View>
  );
}

const Row = memo(function Row({ row, onClaim }) {
  return (
    <View style={styles.row}>
      <View style={styles.rowMain}>
        <Text style={styles.rowTitle} numberOfLines={1}>{row.title}</Text>
        <View style={styles.barRow}>
          <Bar pct={row.pct} />
          <Text style={styles.barLabel}>{row.label}</Text>
        </View>
      </View>
      <View style={styles.rewardCol}>
        {row.open ? (
          <View style={styles.rewardPill}>
            <Text style={styles.rewardText}>{`+${row.reward}`}</Text>
          </View>
        ) : row.claimable ? (
          <Btn label={`CLAIM +${row.reward}`} size={13} height={30} radius={11} glow onPress={() => onClaim(row.id)} />
        ) : (
          <View style={styles.donePill}>
            <Text style={styles.doneText}>DONE</Text>
          </View>
        )}
        {!row.claimed ? <Text style={styles.xpText}>{`+${row.xp} XP`}</Text> : null}
      </View>
    </View>
  );
});

function Section({ title, right, rows, onClaim }) {
  return (
    <View style={styles.section}>
      <View style={styles.sectionHead}>
        <InkText size={16}>{title}</InkText>
        {right}
      </View>
      {rows.map((r) => (
        <Row key={r.id} row={r} onClaim={onClaim} />
      ))}
    </View>
  );
}

function DailyChallengesSheet({ visible, profile, onClose, onClaim, onClaimChest, onOpenCrib }) {
  const [clock, setClock] = useState(() => new Date());
  useEffect(() => {
    if (!visible) return undefined;
    setClock(new Date());
    const iv = setInterval(() => setClock(new Date()), 60000);
    return () => clearInterval(iv);
  }, [visible]);
  useEffect(() => {
    if (visible) sfx.play('popOpen');
  }, [visible]);
  if (!visible) return null;
  const v = dailyView(profile, clock);
  return (
    <View style={styles.overlay}>
      <Pressable style={[StyleSheet.absoluteFill, styles.scrim]} onPress={onClose} />
      <Plaque variant="vel" radius={26} rim={4} ring={2} lip={5} style={styles.panel}>
        <View style={styles.header}>
          <View style={styles.headText}>
            <Lettering text="Daily Challenges" variant="gold" size={26} />
            <Text style={styles.resetIn}>{`New challenges in ${v.resetIn}`}</Text>
          </View>
          <Orb icon="close" size={38} onPress={onClose} />
        </View>

        {/* opened from the house (no onOpenCrib), "you are here" moves over */}
        <View style={styles.cols}>
          <Section title="In Squish Squad" right={onOpenCrib ? <Text style={styles.here}>YOU ARE HERE</Text> : null} rows={v.game} onClaim={onClaim} />
          <Section
            title="In the Crib"
            right={onOpenCrib ? <Btn label="OPEN CRIB" size={13} height={28} radius={10} onPress={onOpenCrib} /> : <Text style={styles.here}>YOU ARE HERE</Text>}
            rows={v.crib}
            onClaim={onClaim}
          />
        </View>

        <View style={styles.chest}>
          <ChestIcon />
          <View style={styles.chestMain}>
            <Text style={styles.chestText} numberOfLines={1}>{`Claim all ${v.total} for the daily chest · +${v.chestReward} coins + ${v.chestXp} XP + your streak reward`}</Text>
            <Bar pct={v.chestPct} gold />
          </View>
          {v.chestReady ? (
            <Btn label="OPEN" size={14} width={88} height={32} radius={11} glow onPress={onClaimChest} />
          ) : v.chestDone ? (
            <View style={styles.donePill}>
              <Text style={styles.doneText}>OPENED</Text>
            </View>
          ) : null}
          <Text style={styles.chestCount}>{`${v.claimedN}/${v.total}`}</Text>
        </View>
      </Plaque>
    </View>
  );
}

// the cream paper rows on the wood (the item cards' look)
const PAPER = '#fff6e2';
const EDGE = '#e2c49c';
const styles = StyleSheet.create({
  overlay: { ...StyleSheet.absoluteFillObject, zIndex: 60, elevation: 60, alignItems: 'center', justifyContent: 'center' },
  scrim: { backgroundColor: 'rgba(40,20,6,0.62)' },
  panel: { width: '88%', maxWidth: 760, alignItems: 'stretch', justifyContent: 'flex-start', paddingHorizontal: 16, paddingTop: 10, paddingBottom: 12, gap: 8 },
  header: { flexDirection: 'row', alignItems: 'center', gap: 10 },
  headText: { flex: 1, alignItems: 'flex-start', gap: 2 },
  resetIn: { fontFamily: FONT.bodyHeavy, fontSize: 11.5, color: PAPER },
  cols: { flexDirection: 'row', gap: 12 },
  section: { flex: 1, gap: 6 },
  sectionHead: { height: 30, flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between' },
  here: { fontFamily: FONT.bodyBlack, fontSize: 10, letterSpacing: 1, color: PAPER, opacity: 0.85 },
  row: { flexDirection: 'row', alignItems: 'center', gap: 10, paddingVertical: 6, paddingHorizontal: 12, borderRadius: 14, backgroundColor: PAPER, borderWidth: 2, borderColor: INK, borderBottomWidth: 4 },
  rowMain: { flex: 1, minWidth: 0, gap: 5 },
  rowTitle: { fontFamily: FONT.bodyHeavy, fontSize: 13, lineHeight: 16, color: INK },
  barRow: { flexDirection: 'row', alignItems: 'center', gap: 8 },
  bar: { flex: 1, height: 10, borderRadius: 6, backgroundColor: '#f1dfc2', borderWidth: 1.5, borderColor: EDGE, overflow: 'hidden' },
  barFill: { height: '100%', borderRadius: 6 },
  barLabel: { fontFamily: FONT.bodyHeavy, fontSize: 11, color: '#8a5a34' },
  rewardCol: { alignItems: 'center', gap: 2, minWidth: 62 },
  xpText: { fontFamily: FONT.bodyBlack, fontSize: 10, color: '#b8641c' },
  rewardPill: { paddingHorizontal: 10, paddingVertical: 3, borderRadius: 999, backgroundColor: '#fff1b0', borderWidth: 1.5, borderColor: '#d9a066' },
  rewardText: { fontFamily: FONT.bodyBlack, fontSize: 12, color: '#9c4d06' },
  donePill: { paddingHorizontal: 10, paddingVertical: 3, borderRadius: 999, backgroundColor: '#d8ffc2', borderWidth: 1.5, borderColor: '#26a94e' },
  doneText: { fontFamily: FONT.bodyBlack, fontSize: 11, color: '#17652f' },
  chest: { flexDirection: 'row', alignItems: 'center', gap: 10, paddingHorizontal: 12, paddingVertical: 7, borderRadius: 16, backgroundColor: '#fff1b0', borderWidth: 2, borderColor: INK, borderBottomWidth: 4 },
  chestMain: { flex: 1, minWidth: 0, gap: 5 },
  chestText: { fontFamily: FONT.bodyBlack, fontSize: 12, lineHeight: 15, color: '#7a3d00' },
  chestCount: { fontFamily: FONT.bodyBlack, fontSize: 12, color: '#7a3d00' },
});

export default memo(DailyChallengesSheet);
