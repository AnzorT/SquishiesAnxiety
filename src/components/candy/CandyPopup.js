import React, { useEffect, useRef } from 'react';
import { Animated, BackHandler, Pressable, StyleSheet, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { candyColors } from '../../theme/candyTheme';
import RoundButton, { CloseGlyph } from './RoundButton';
import sfx from '../../audio/sfx';

// A centred candy popup over whatever screen is showing (the unlock choices,
// Remove Ads): a dimmed backdrop, and the candy card — plum ring, white rim,
// pink gradient — springing in with a little twist, like the WHOA THERE!
// card. Tapping the backdrop, the round ✕ or Android's back button closes it.
// Rendered as an overlay at the app root rather than a <Modal>, so the app's
// own toasts can still show above it.
export default function CandyPopup({ visible, onClose, children, maxWidth = 360 }) {
  const t = useRef(new Animated.Value(0)).current;
  const closeRef = useRef(onClose);
  closeRef.current = onClose;
  useEffect(() => {
    if (!visible) return undefined;
    t.setValue(0);
    sfx.play('popOpen');
    Animated.spring(t, { toValue: 1, friction: 6, tension: 120, useNativeDriver: true }).start();
    const sub = BackHandler.addEventListener('hardwareBackPress', () => {
      closeRef.current();
      return true;
    });
    return () => sub.remove();
  }, [visible, t]);
  if (!visible) return null;
  const scale = t.interpolate({ inputRange: [0, 1], outputRange: [0.6, 1] });
  const rotate = t.interpolate({ inputRange: [0, 1], outputRange: ['-5deg', '0deg'] });
  const opacity = t.interpolate({ inputRange: [0, 0.4, 1], outputRange: [0, 1, 1], extrapolate: 'clamp' });
  return (
    <View style={styles.overlay}>
      <Animated.View style={[StyleSheet.absoluteFill, styles.scrim, { opacity }]}>
        <Pressable style={StyleSheet.absoluteFill} onPress={onClose} />
      </Animated.View>
      <Animated.View style={[styles.ring, { maxWidth, opacity, transform: [{ scale }, { rotate }] }]}>
        <View style={styles.rim}>
          <LinearGradient colors={['#fff6fd', '#ffdcf4', '#f5cbff']} locations={[0, 0.6, 1]} style={styles.fill}>
            {children}
          </LinearGradient>
        </View>
        <RoundButton size={34} onPress={onClose} hitSlop={10} style={styles.close}>
          <CloseGlyph />
        </RoundButton>
      </Animated.View>
    </View>
  );
}

const styles = StyleSheet.create({
  overlay: {
    ...StyleSheet.absoluteFillObject,
    alignItems: 'center',
    justifyContent: 'center',
    padding: 20,
    zIndex: 60,
    elevation: 60,
  },
  scrim: { backgroundColor: 'rgba(40,6,80,0.55)' },
  ring: {
    width: '100%',
    borderRadius: 31,
    padding: 3,
    backgroundColor: candyColors.cardRing,
    shadowColor: '#320064',
    shadowOffset: { width: 0, height: 14 },
    shadowOpacity: 0.5,
    shadowRadius: 18,
    elevation: 12,
  },
  rim: { borderRadius: 28, borderWidth: 4, borderColor: '#ffffff', overflow: 'hidden' },
  fill: { paddingHorizontal: 16, paddingTop: 18, paddingBottom: 18, alignItems: 'center' },
  close: { position: 'absolute', top: -10, right: -8 },
});
