import React from 'react';
import { StyleSheet, View } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { Bone } from '../components/Skeleton';

// The Crib while it slides in (its scene is built once the slide is over):
// the dark wood frame, the HUD's button row, the room and the room tabs as
// placeholders. Portrait only; the Crib turns itself once it's built.
const FRAME = '#2b1d16'; // CribScreen's

export default function CribBones() {
  const insets = useSafeAreaInsets();
  return (
    <View style={[styles.root, { paddingTop: insets.top + 10, paddingBottom: insets.bottom + 14 }]}>
      <View style={styles.row}>
        {[0, 1, 2, 3, 4, 5].map((i) => (
          <Bone key={i} tone="dark" w={42} h={42} r={21} />
        ))}
      </View>
      <View style={styles.titles}>
        <Bone tone="dark" w={170} h={22} r={11} />
        <Bone tone="dark" w={220} h={11} r={6} />
      </View>
      <Bone tone="dark" h={undefined} r={26} style={styles.room} />
      <View style={styles.row}>
        {[0, 1, 2, 3].map((i) => (
          <Bone key={i} tone="dark" w={64} h={54} r={16} />
        ))}
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  root: { flex: 1, backgroundColor: FRAME, paddingHorizontal: 14, gap: 14 },
  row: { flexDirection: 'row', justifyContent: 'space-between' },
  titles: { alignItems: 'center', gap: 8 },
  room: { flex: 1 },
});
