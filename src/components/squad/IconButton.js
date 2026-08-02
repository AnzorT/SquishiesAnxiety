import React from 'react';
import { Pressable, StyleSheet } from 'react-native';
import { MaterialIcons } from '@expo/vector-icons';
import { squadColors } from '../../theme/squadTheme';

// Small rounded panel button used for the header glyphs (achievements,
// store, settings, back) across the Squish Squad screens.
export default function IconButton({ name, onPress, size = 38, iconSize = 19, color = squadColors.gold, style }) {
  return (
    <Pressable
      onPress={onPress}
      style={[styles.button, { width: size, height: size, borderRadius: size * 0.32 }, style]}
      hitSlop={6}
    >
      <MaterialIcons name={name} size={iconSize} color={color} />
    </Pressable>
  );
}

const styles = StyleSheet.create({
  button: {
    backgroundColor: squadColors.panel,
    alignItems: 'center',
    justifyContent: 'center',
  },
});
