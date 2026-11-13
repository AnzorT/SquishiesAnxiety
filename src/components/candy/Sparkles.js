import React, { memo } from 'react';
import { Animated, StyleSheet, View } from 'react-native';
import { usePingPong } from '../idleLoop';

// Twinkling ✦ glyphs — the design's `twinkle` keyframe (opacity 0.2→1,
// scale 0.6→1.1, rotate 0→20deg and back). Positions/sizes/timings are the
// design's own deterministic SPARKLES table, so every screen sparkles the
// same way. Each one native loop (idleLoop.js), so they cost the JS thread
// nothing: as up-and-down sequences they woke it about 20 times a second
// on a sparkly screen.

const COLORS = ['#ffffff', '#fff3a0', '#ffd1f5', '#ffffff'];
export const SPARKLES = Array.from({ length: 14 }, (_, i) => ({
  id: i,
  x: ((i * 37 + 11) % 92) + 2,
  y: ((i * 53 + 7) % 88) + 4,
  size: 10 + ((i * 7) % 14),
  color: COLORS[i % 4],
  dur: 1.8 + (i % 5) * 0.5,
  delay: (i * 0.37) % 2,
}));

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

const Sparkles = memo(function Sparkles({ opacity = 0.7 }) {
  return (
    <View style={[StyleSheet.absoluteFill, { opacity }]} pointerEvents="none">
      {SPARKLES.map((sp) => (
        <View key={sp.id} style={{ position: 'absolute', left: `${sp.x}%`, top: `${sp.y}%` }}>
          <Twinkle size={sp.size} color={sp.color} duration={sp.dur} delay={sp.delay} />
        </View>
      ))}
    </View>
  );
});

export default Sparkles;

const styles = StyleSheet.create({
  glyph: {
    textShadowColor: 'rgba(255,200,245,0.95)',
    textShadowOffset: { width: 0, height: 0 },
    textShadowRadius: 8,
  },
});
