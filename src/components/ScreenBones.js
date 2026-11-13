import React, { memo } from 'react';
import { StyleSheet, View } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import CandyBackground from './candy/CandyBackground';
import { Bone, ViewBones } from './Skeleton';

// A whole screen's placeholder while a screen opened over Home slides in and
// gets built (App wraps it in ScreenLayer's WhenScreenReady): the candy sky,
// a header (the back button's spot and the title's) and ViewBones of `kind`.
function ScreenBones({ kind = 'hub' }) {
  const insets = useSafeAreaInsets();
  return (
    <CandyBackground style={{ paddingTop: insets.top }} sparkles>
      <View style={styles.header}>
        <Bone w={40} h={40} r={20} tone="sky" />
        <Bone w="44%" h={26} r={13} tone="sky" />
        <View style={styles.side} />
      </View>
      <ViewBones kind={kind} />
    </CandyBackground>
  );
}

const styles = StyleSheet.create({
  header: { flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between', paddingHorizontal: 14, paddingTop: 6, paddingBottom: 2 },
  side: { width: 40 },
});

export default memo(ScreenBones);
