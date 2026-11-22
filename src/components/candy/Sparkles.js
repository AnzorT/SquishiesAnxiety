import React from 'react';
import { Animated, StyleSheet } from 'react-native';
import { usePingPong } from '../idleLoop';

// A twinkling ✦ glyph — the design's `twinkle` keyframe (opacity 0.2→1,
// scale 0.6→1.1, rotate 0→20deg and back). One native loop (idleLoop.js),
// so it costs the JS thread nothing: as up-and-down sequences the sparkles
// woke it about 20 times a second on a sparkly screen.

export function Twinkle({ size = 14, color = '#ffffff', duration = 2, delay = 0, style }) {
  const t = usePingPong(duration * 1000, { delay: delay * 1000 });
  const opacity = t.interpolate({ inputRange: [0, 1], outputRange: [0.2, 1] });
  const scale = t.interpolate({ inputRange: [0, 1], outputRange: [0.6, 1.1] });
  const rotate = t.interpolate({ inputRange: [0, 1], outputRange: ['0deg', '20deg'] });
  // A hardware layer: the blurred glow is rasterised once and the loop only
  // moves the texture, instead of re-blurring the glyph at every new scale.
  return (
    <Animated.Text
      pointerEvents="none"
      renderToHardwareTextureAndroid
      style={[
        styles.glyph,
        { fontSize: size, lineHeight: size * 1.1, color, opacity, transform: [{ scale }, { rotate }] },
        style,
      ]}
    >
      ✦
    </Animated.Text>
  );
}

const styles = StyleSheet.create({
  glyph: {
    textShadowColor: 'rgba(255,200,245,0.95)',
    textShadowOffset: { width: 0, height: 0 },
    textShadowRadius: 8,
  },
});
