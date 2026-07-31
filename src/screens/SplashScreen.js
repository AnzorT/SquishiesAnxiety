import React, { useEffect, useRef } from 'react';
import { View, Text, StyleSheet, Pressable } from 'react-native';

// First thing shown on launch — auto-advances to the Home Screen after a
// beat, but a tap skips straight there too.

const AUTO_ADVANCE_MS = 1400;

export default function SplashScreen({ onFinish }) {
  const finished = useRef(false);

  useEffect(() => {
    const timer = setTimeout(() => {
      if (!finished.current) {
        finished.current = true;
        onFinish();
      }
    }, AUTO_ADVANCE_MS);
    return () => clearTimeout(timer);
  }, [onFinish]);

  const skip = () => {
    if (finished.current) return;
    finished.current = true;
    onFinish();
  };

  return (
    <Pressable style={styles.container} onPress={skip}>
      <Text style={styles.title}>PlushCrush</Text>
      <Text style={styles.tagline}>squishy friends, right in your pocket</Text>
    </Pressable>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#1A1326',
    alignItems: 'center',
    justifyContent: 'center',
  },
  title: { fontSize: 34, fontWeight: '800', color: '#FFFFFF', letterSpacing: -0.5 },
  tagline: { fontSize: 13, fontWeight: '600', color: '#B7A9CB', marginTop: 8 },
});
