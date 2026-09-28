import React, { useEffect, useRef } from 'react';
import { Animated, Text, StyleSheet } from 'react-native';
import { candyColors, candyFonts } from '../../theme/candyTheme';

// Small bottom-center pill notification — mirrors the prototype's toastIn
// keyframe (fade + rise 10px). The parent owns the show/auto-hide timer
// (same split as the prototype's showToastMsg) and re-mounts this via
// `messageKey` each time a new message should slide in.
export default function Toast({ message, messageKey }) {
  const anim = useRef(new Animated.Value(0)).current;

  useEffect(() => {
    if (!message) return;
    anim.setValue(0);
    Animated.timing(anim, { toValue: 1, duration: 220, useNativeDriver: true }).start();
  }, [message, messageKey, anim]);

  if (!message) return null;

  const translateY = anim.interpolate({ inputRange: [0, 1], outputRange: [10, 0] });

  return (
    <Animated.View style={[styles.wrap, { opacity: anim, transform: [{ translateY }] }]} pointerEvents="none">
      <Text style={styles.text}>{message}</Text>
    </Animated.View>
  );
}

const styles = StyleSheet.create({
  wrap: {
    position: 'absolute',
    bottom: 24,
    alignSelf: 'center',
    backgroundColor: '#ffffff',
    borderWidth: 1.5,
    borderColor: candyColors.inkSoft,
    borderRadius: 999,
    paddingHorizontal: 20,
    paddingVertical: 10,
  },
  text: {
    color: candyColors.ink,
    fontFamily: candyFonts.body,
    fontSize: 12.5,
  },
});
