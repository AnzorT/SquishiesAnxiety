import React from 'react';
import { StyleSheet, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';

// The gold "▶" video badge on buttons that play a rewarded video (WATCH TO
// OPEN, OPEN ANOTHER, DOUBLE IT, SPIN AGAIN).
export default function VideoBadge({ w = 34, h = 24 }) {
  return (
    <View style={[styles.ring, { width: w + 3, height: h + 3, borderRadius: 8.5 }]}>
      <LinearGradient colors={['#ffe98a', '#e89400']} style={[styles.face, { borderRadius: 7 }]}>
        <View style={styles.play} />
      </LinearGradient>
    </View>
  );
}

const styles = StyleSheet.create({
  ring: { backgroundColor: '#9c4d06', padding: 1.5 },
  face: { flex: 1, borderWidth: 2, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  play: {
    marginLeft: 2,
    width: 0,
    height: 0,
    borderTopWidth: 5,
    borderBottomWidth: 5,
    borderLeftWidth: 8,
    borderTopColor: 'transparent',
    borderBottomColor: 'transparent',
    borderLeftColor: '#ffffff',
  },
});
