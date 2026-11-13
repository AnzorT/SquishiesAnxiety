// The classic Home, opened from the new Main Menu's settings gear: everything the new design has no screen for yet
// (squishing any creature, creating one, daily challenges, streak, trophies, stats, settings). A pill at the top and
// the Android back button return to the new Main Menu.
import React, { useEffect } from 'react';
import { BackHandler, Pressable, StyleSheet, Text, View } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';

export default function ClassicBack({ onBack }) {
  const insets = useSafeAreaInsets();
  useEffect(() => {
    const sub = BackHandler.addEventListener('hardwareBackPress', () => {
      onBack();
      return true;
    });
    return () => sub.remove();
  }, [onBack]);
  return (
    <View pointerEvents="box-none" style={[styles.wrap, { top: insets.top + 6 }]}>
      <Pressable onPress={onBack} style={({ pressed }) => [styles.pill, pressed && styles.pressed]} accessibilityRole="button" accessibilityLabel="Back to the main menu">
        <Text style={styles.text}>‹  MAIN MENU</Text>
      </Pressable>
    </View>
  );
}

const styles = StyleSheet.create({
  wrap: { position: 'absolute', left: 0, right: 0, alignItems: 'center', zIndex: 80, elevation: 80 },
  pill: { backgroundColor: '#5a1cb8', borderColor: '#ffdd6e', borderWidth: 2, borderRadius: 99, paddingHorizontal: 16, paddingVertical: 6 },
  pressed: { transform: [{ translateY: 1 }] },
  text: { color: '#fff', fontFamily: 'Fredoka_700Bold', fontSize: 14, letterSpacing: 0.5 },
});
