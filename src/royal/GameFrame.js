import React from 'react';
import { StyleSheet, View, useWindowDimensions } from 'react-native';
import { Orb, PageBg } from './index';

// A mini-game screen's shared pieces in the landscape app (REDESIGN_V7, V8): the size it lays out in, its background
// and its back button. (The panel that framed a game in the middle of the screen is gone: each game has its own
// landscape layout and takes the whole screen.)

// the size a game lays out in: the window's
export function useGameDims() {
  return useWindowDimensions();
}

// A game screen's background (REDESIGN_V8): the wood look's warm page
export function GameBackground({ style, children }) {
  return (
    <View style={[styles.bg, style]}>
      <PageBg />
      {children}
    </View>
  );
}
// …and its back button, the wooden back orb
export function GameBack({ onPress, size = 40 }) {
  return <Orb icon="back" size={size} onPress={onPress} />;
}

const styles = StyleSheet.create({
  bg: { flex: 1, backgroundColor: '#d27c3e' },
});
