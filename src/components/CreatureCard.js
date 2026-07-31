import React from 'react';
import { View, Text, StyleSheet, Pressable } from 'react-native';
import { colors, radii, spacing } from '../theme/tokens';
import SquishyThumbnail from './SquishyThumbnail';

// Light/white take on a collectible-card layout: a soft stage area up top
// holding the creature, then name + description, then two stat-style rows
// where ATK/SPD bars would go — here that's lock status and the color
// options this creature ships with.

export default function CreatureCard({ creature, unlocked, onPress, style }) {
  const primary = creature.colors?.[0] ?? colors.accent;

  return (
    <Pressable style={[styles.card, style]} onPress={onPress}>
      <View style={styles.stageArea}>
        <View style={[styles.statusPill, unlocked ? styles.pillUnlocked : styles.pillLocked]}>
          <Text style={[styles.statusPillText, unlocked ? styles.textUnlocked : styles.textLocked]}>
            {unlocked ? 'UNLOCKED' : 'LOCKED'}
          </Text>
        </View>
        <SquishyThumbnail colorHex={primary} size={110} />
      </View>

      <View style={styles.body}>
        <Text style={styles.name} numberOfLines={1}>
          {creature.name}
        </Text>
        <Text style={styles.description} numberOfLines={2}>
          {creature.description}
        </Text>

        <View style={styles.statRow}>
          <Text style={styles.statLabel}>Status</Text>
          <View style={[styles.statusChip, unlocked ? styles.pillUnlocked : styles.pillLocked]}>
            <Text style={[styles.statusChipText, unlocked ? styles.textUnlocked : styles.textLocked]}>
              {unlocked ? 'Unlocked' : 'Locked'}
            </Text>
          </View>
        </View>

        <View style={styles.statRow}>
          <Text style={styles.statLabel}>Colors</Text>
          <View style={styles.swatchRow}>
            {(creature.colors ?? []).map((hex) => (
              <View key={hex} style={[styles.swatch, { backgroundColor: hex }]} />
            ))}
          </View>
        </View>

        <Text style={styles.hint}>{unlocked ? 'tap to play' : `${creature.price}⊙ to unlock`}</Text>
      </View>
    </Pressable>
  );
}

const styles = StyleSheet.create({
  card: {
    backgroundColor: colors.surface,
    borderRadius: radii.lg,
    borderWidth: 1,
    borderColor: colors.surfaceBorder,
    overflow: 'hidden',
    shadowColor: colors.accent,
    shadowOpacity: 0.12,
    shadowRadius: 14,
    shadowOffset: { width: 0, height: 8 },
    elevation: 4,
  },
  stageArea: {
    flex: 1.1,
    backgroundColor: colors.bgGradientMid,
    alignItems: 'center',
    justifyContent: 'center',
  },
  statusPill: {
    position: 'absolute',
    top: spacing(3),
    right: spacing(3),
    borderRadius: radii.pill,
    paddingHorizontal: spacing(3),
    paddingVertical: spacing(1),
    borderWidth: 1,
  },
  pillUnlocked: { backgroundColor: 'rgba(79,174,115,0.14)', borderColor: colors.success },
  pillLocked: { backgroundColor: 'rgba(156,135,189,0.14)', borderColor: colors.textMuted },
  statusPillText: { fontSize: 10, fontWeight: '800', letterSpacing: 0.5 },
  textUnlocked: { color: colors.success },
  textLocked: { color: colors.textMuted },
  body: { flex: 1, padding: spacing(4) },
  name: { fontSize: 20, fontWeight: '800', color: colors.textPrimary },
  description: { fontSize: 12.5, fontWeight: '500', color: colors.textMuted, marginTop: spacing(1) },
  statRow: {
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'space-between',
    marginTop: spacing(3),
  },
  statLabel: { fontSize: 11, fontWeight: '700', color: colors.textMuted, textTransform: 'uppercase', letterSpacing: 0.5 },
  statusChip: { borderRadius: radii.pill, paddingHorizontal: spacing(2.5), paddingVertical: spacing(0.5), borderWidth: 1 },
  statusChipText: { fontSize: 11, fontWeight: '700' },
  swatchRow: { flexDirection: 'row', gap: spacing(1.5) },
  swatch: { width: 16, height: 16, borderRadius: 8, borderWidth: 1, borderColor: 'rgba(0,0,0,0.08)' },
  hint: {
    fontSize: 12,
    fontWeight: '600',
    fontStyle: 'italic',
    color: colors.caption,
    marginTop: spacing(4),
    textAlign: 'center',
  },
});
