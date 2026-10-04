import React, { useEffect, useRef } from 'react';
import { Animated, Easing, Pressable, StyleSheet, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { candyFonts } from '../../theme/candyTheme';
import ShadowText, { outline3 } from './ShadowText';
import { Shine } from './CandyButton';
import sfx from '../../audio/sfx';

// On/off switch in the candy-button look (it replaced the design's flat
// teal/plum switch, which read like a system control next to everything
// else): a glossy track inside a white rim and a dark ring with a bottom
// lip, mint when on and lilac-grey when off, an outlined ON / OFF caption,
// and a white candy ball for a knob that squashes while pressed and
// springs across.

const W = 58;
const H = 30;
const RING = 2;
const RIM = 2.5;
const KNOB = H - (RING + RIM) * 2 - 4; // 4px of track showing round it
const TRAVEL = W - (RING + RIM) * 2 - KNOB - 4;

const ON = { colors: ['#c8fff4', '#4fe6cf', '#14b3a0'], ring: '#0b6f68' };
const OFF = { colors: ['#eee6f8', '#c3b3dd', '#9a86c0'], ring: '#5a4a80' };

export default function ToggleSwitch({ value, onToggle }) {
  const pos = useRef(new Animated.Value(value ? 1 : 0)).current;
  const press = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    Animated.spring(pos, { toValue: value ? 1 : 0, friction: 6, tension: 140, useNativeDriver: true }).start();
  }, [value, pos]);
  const squash = (to) => Animated.timing(press, { toValue: to, duration: 90, easing: Easing.out(Easing.quad), useNativeDriver: true }).start();

  const knobX = pos.interpolate({ inputRange: [0, 1], outputRange: [0, TRAVEL] });
  const knobScaleX = press.interpolate({ inputRange: [0, 1], outputRange: [1, 1.18] });
  const knobScaleY = press.interpolate({ inputRange: [0, 1], outputRange: [1, 0.86] });
  const onOpacity = pos.interpolate({ inputRange: [0, 0.5, 1], outputRange: [0, 0.5, 1], extrapolate: 'clamp' });
  const offOpacity = pos.interpolate({ inputRange: [0, 0.5, 1], outputRange: [1, 0.5, 0], extrapolate: 'clamp' });

  return (
    <Pressable
      onPress={() => {
        sfx.play('tap');
        onToggle();
      }}
      onPressIn={() => squash(1)}
      onPressOut={() => squash(0)}
      hitSlop={8}
      accessibilityRole="switch"
      accessibilityState={{ checked: !!value }}
    >
      <View style={styles.wrap}>
        {/* ring + lip, each state's colour crossfading */}
        <Animated.View style={[styles.lip, { backgroundColor: OFF.ring, opacity: offOpacity }]} />
        <Animated.View style={[styles.lip, { backgroundColor: ON.ring, opacity: onOpacity }]} />
        <View style={styles.rim}>
          <View style={styles.face}>
            <Animated.View style={[StyleSheet.absoluteFill, { opacity: offOpacity }]}>
              <LinearGradient colors={OFF.colors} locations={[0, 0.55, 1]} style={StyleSheet.absoluteFill} />
              <ShadowText style={[styles.caption, styles.captionOff]} shadows={outline3(OFF.ring, 1.5)}>
                OFF
              </ShadowText>
            </Animated.View>
            <Animated.View style={[StyleSheet.absoluteFill, { opacity: onOpacity }]}>
              <LinearGradient colors={ON.colors} locations={[0, 0.55, 1]} style={StyleSheet.absoluteFill} />
              <ShadowText style={[styles.caption, styles.captionOn]} shadows={outline3(ON.ring, 1.5)}>
                ON
              </ShadowText>
            </Animated.View>
            <Shine />
            <Animated.View style={[styles.knobWrap, { transform: [{ translateX: knobX }, { scaleX: knobScaleX }, { scaleY: knobScaleY }] }]}>
              <View style={styles.knobShadow} />
              <LinearGradient colors={['#ffffff', '#fbeaff', '#e2c9f5']} locations={[0, 0.5, 1]} style={styles.knob}>
                <View style={styles.knobShine} />
              </LinearGradient>
            </Animated.View>
          </View>
        </View>
      </View>
    </Pressable>
  );
}

const styles = StyleSheet.create({
  wrap: { width: W, height: H + 3, paddingBottom: 3 },
  // the ring, plus the 3px lip below it
  lip: { position: 'absolute', left: 0, right: 0, top: 0, bottom: 0, borderRadius: H / 2 + 1.5 },
  rim: {
    height: H,
    borderRadius: H / 2,
    margin: 0,
    padding: RING,
  },
  face: {
    flex: 1,
    borderRadius: H / 2,
    borderWidth: RIM,
    borderColor: '#ffffff',
    overflow: 'hidden',
    justifyContent: 'center',
  },
  caption: {
    position: 'absolute',
    top: 0,
    bottom: 0,
    textAlignVertical: 'center',
    color: '#ffffff',
    fontFamily: candyFonts.display,
    fontSize: 10,
    letterSpacing: 0.6,
    lineHeight: H - (RING + RIM) * 2,
    includeFontPadding: false,
  },
  captionOn: { left: 7 },
  captionOff: { right: 6 },
  knobWrap: { position: 'absolute', left: 2, top: 2, width: KNOB, height: KNOB },
  knobShadow: {
    position: 'absolute',
    left: 0,
    right: 0,
    top: 1.5,
    bottom: -1.5,
    borderRadius: KNOB / 2,
    backgroundColor: 'rgba(69,24,154,0.35)',
  },
  knob: { flex: 1, borderRadius: KNOB / 2, overflow: 'hidden' },
  knobShine: {
    position: 'absolute',
    left: '18%',
    top: '12%',
    width: '42%',
    height: '32%',
    borderRadius: 999,
    backgroundColor: 'rgba(255,255,255,0.95)',
  },
});
