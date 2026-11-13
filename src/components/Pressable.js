import React, { forwardRef } from 'react';
import { Pressable as RNPressable } from 'react-native';
import sfx from '../audio/sfx';

// React Native's Pressable plus the button click (the bubble, sfx 'tap') on
// every press, so every button sounds the same without each handler playing
// it. `silent` for what isn't a button: a scrim behind a sheet, a
// tap-anywhere-to-skip area.
const Pressable = forwardRef(function Pressable({ onPress, silent = false, ...rest }, ref) {
  const press =
    onPress && !silent
      ? (e) => {
          sfx.play('tap');
          onPress(e);
        }
      : onPress;
  return <RNPressable ref={ref} onPress={press} {...rest} />;
});

export default Pressable;
