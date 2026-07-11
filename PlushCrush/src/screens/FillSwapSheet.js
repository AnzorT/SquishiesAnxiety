import React from 'react';
import { View, Text, StyleSheet, Pressable } from 'react-native';
import { FILL_PROFILES } from '../engine/SquishState';
import { colors, spacing, typography, radii } from '../theme/tokens';

export default function FillSwapSheet({ current, onSelect, onClose }) {
  return (
    <View style={styles.overlay}>
      <Pressable style={StyleSheet.absoluteFill} onPress={onClose} />
      <View style={styles.sheet}>
        <Text style={styles.title}>Swap Fill</Text>
        {Object.entries(FILL_PROFILES).map(([key, profile]) => (
          <Pressable
            key={key}
            onPress={() => onSelect(key)}
            style={[styles.row, key === current && styles.rowActive]}
          >
            <Text style={styles.rowText}>{profile.label}</Text>
            {key === current && <Text style={styles.check}>✓</Text>}
          </Pressable>
        ))}
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  overlay: { ...StyleSheet.absoluteFillObject, justifyContent: 'flex-end' },
  sheet: {
    backgroundColor: colors.bgDeep,
    borderTopLeftRadius: radii.lg,
    borderTopRightRadius: radii.lg,
    padding: spacing(6),
    borderWidth: 1,
    borderColor: colors.bgPanelBorder,
  },
  title: { ...typography.title, marginBottom: spacing(4) },
  row: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    paddingVertical: spacing(3),
    borderBottomWidth: 1,
    borderBottomColor: colors.bgPanelBorder,
  },
  rowActive: { opacity: 1 },
  rowText: { ...typography.body, color: colors.textPrimary, fontSize: 16 },
  check: { color: colors.success, fontSize: 16 },
});
