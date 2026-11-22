import React, { memo } from 'react';
import { StyleSheet, View } from 'react-native';
import { PageBg, WoodBg } from '../royal/parts';
import { Bone, ViewBones } from './Skeleton';

// A whole screen's placeholder while a screen opened over the menu gets built (App wraps it in ScreenLayer's
// WhenScreenReady): the games' warm page (the same PageBg their hubs stand on), the back orb's and the title's spots,
// and ViewBones of `kind` ('hub', 'map', 'game', 'list'), all in the wood look, laid out sideways like the screens.
// bg: the background of the screen coming ('page', the warm page; 'wood', the planks: Squishdoku, the level road).
// (2026-11-20, the user: "lots of flickering": it was the old design's light-blue sky with portrait bones, flashed
// for half a second before every game's wooden hub.)
function ScreenBones({ kind = 'hub', bg = 'page' }) {
  return (
    <View style={styles.root}>
      {bg === 'wood' ? <WoodBg /> : <PageBg />}
      <View style={styles.header}>
        <Bone w={40} h={40} r={20} tone="wood" />
        <Bone w={220} h={30} r={15} tone="wood" />
      </View>
      <ViewBones kind={kind} />
    </View>
  );
}

const styles = StyleSheet.create({
  root: { flex: 1 },
  header: { height: 64, flexDirection: 'row', alignItems: 'center', gap: 14, paddingHorizontal: 16 },
});

export default memo(ScreenBones);
