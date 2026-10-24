import React, { forwardRef, memo, useImperativeHandle, useRef, useState } from 'react';
import { Animated, Easing, Image, StyleSheet, Text, View } from 'react-native';
import RigCreature from '../components/RigCreature';
import { F } from './theme';

// The player's own creature (the one picked in the Lobby), live below the
// board: the design's rig in a WebView, the same as on the Lobby. It cheers
// a right creature, gasps at a mistake, spins on a solve, fidgets when time
// is short, with a speech bubble for each. Its still shows until the rig has
// drawn. `ref.current.react(kind, n)`:
//   'start' | 'right' (n = the streak) | 'wrong' | 'hurry' | 'solve' | 'timeup'

const SAY = {
  start: ["Let's go!", 'You got this!', 'Squish time!'],
  right: ['Yay!', 'Nice!', 'Squishy!', 'Woo!', 'Yes!'],
  streak: ['On fire!', 'Unstoppable!', 'So good!'],
  wrong: ['Oops!', 'Uh-oh!', 'Not there!', 'Hmm…'],
  hurry: ['Hurry!', 'Quick quick!'],
  solve: ['We did it!', 'Squishtastic!', 'Hooray!'],
  timeup: ['Aww…', 'So close!'],
};
// which rig move each reaction plays (rive-rig.js STATES)
const MOVE = { start: 'hop', right: 'happy', streak: 'hop', wrong: 'surprised', hurry: 'look', solve: 'spin', timeup: 'surprised' };
const pick = (list) => list[Math.floor(Math.random() * list.length)];

function Buddy({ creatureKey, uri, paused = false, size = 96, style }, ref) {
  const rig = useRef(null);
  const [drawn, setDrawn] = useState(false);
  const jump = useRef(new Animated.Value(0)).current;
  const shake = useRef(new Animated.Value(0)).current;
  const bubble = useRef(new Animated.Value(0)).current;
  const [say, setSay] = useState({ text: '', bad: false, key: 0 });
  const hideTimer = useRef(null);

  const speak = (text, bad) => {
    setSay((s) => ({ text, bad, key: s.key + 1 }));
    bubble.setValue(0);
    Animated.spring(bubble, { toValue: 1, friction: 5, tension: 180, useNativeDriver: true }).start();
    clearTimeout(hideTimer.current);
    hideTimer.current = setTimeout(() => Animated.timing(bubble, { toValue: 0, duration: 180, useNativeDriver: true }).start(), 1100);
  };
  const hop = (height) => {
    jump.setValue(0);
    Animated.sequence([
      Animated.timing(jump, { toValue: height, duration: 180, easing: Easing.out(Easing.quad), useNativeDriver: true }),
      Animated.timing(jump, { toValue: 0, duration: 220, easing: Easing.bounce, useNativeDriver: true }),
    ]).start();
  };

  useImperativeHandle(ref, () => ({
    react(kind, n = 0) {
      const k = kind === 'right' && n >= 3 ? 'streak' : kind;
      rig.current?.play(MOVE[k] || 'happy');
      if (k === 'solve') setTimeout(() => rig.current?.play('happy'), 1300);
      if (k === 'wrong' || k === 'timeup') {
        shake.setValue(0);
        Animated.sequence([1, -1, 0.8, -0.8, 0.4, 0].map((v) => Animated.timing(shake, { toValue: v, duration: 55, useNativeDriver: true }))).start();
      } else hop(k === 'solve' ? 1 : k === 'streak' ? 0.8 : 0.5);
      // a word for most moments; not every right creature, or it chatters
      if (k !== 'right' || Math.random() < 0.55) speak(pick(SAY[k]), k === 'wrong' || k === 'timeup');
    },
  }));

  const translateY = jump.interpolate({ inputRange: [0, 1], outputRange: [0, -size * 0.32] });
  const translateX = shake.interpolate({ inputRange: [-1, 1], outputRange: [-size * 0.08, size * 0.08] });
  return (
    <View style={[{ width: size, height: size }, style]} pointerEvents="none">
      <View style={[styles.floor, { width: size * 0.62, height: size * 0.1, left: size * 0.19 }]} />
      <Animated.View style={{ width: size, height: size, transform: [{ translateY }, { translateX }] }}>
        {!drawn && uri ? <Image source={{ uri }} style={StyleSheet.absoluteFill} resizeMode="contain" fadeDuration={0} /> : null}
        {creatureKey ? (
          <RigCreature ref={rig} creatureKey={creatureKey} shuffle={false} renderScale={0.8} paused={paused} onMounted={() => setDrawn(true)} style={StyleSheet.absoluteFill} />
        ) : null}
      </Animated.View>
      {say.text ? (
        <Animated.View
          style={[
            styles.bubble,
            say.bad && styles.bubbleBad,
            {
              bottom: size * 0.86,
              opacity: bubble,
              transform: [{ scale: bubble.interpolate({ inputRange: [0, 1], outputRange: [0.4, 1] }) }, { rotate: say.bad ? '4deg' : '-4deg' }],
            },
          ]}
        >
          <Text style={[styles.bubbleText, say.bad && styles.bubbleTextBad]} numberOfLines={1}>
            {say.text}
          </Text>
          <View style={[styles.tail, say.bad && styles.tailBad]} />
        </Animated.View>
      ) : null}
    </View>
  );
}

const styles = StyleSheet.create({
  floor: { position: 'absolute', bottom: 2, borderRadius: 999, backgroundColor: 'rgba(69,16,122,0.2)' },
  bubble: { position: 'absolute', alignSelf: 'center', backgroundColor: '#ffffff', borderRadius: 14, borderWidth: 2.5, borderColor: '#45189a', paddingHorizontal: 10, paddingVertical: 3, minWidth: 54, alignItems: 'center' },
  bubbleBad: { borderColor: '#e01e4a', backgroundColor: '#fff0f3' },
  bubbleText: { fontFamily: F.display, fontSize: 13, color: '#45189a', includeFontPadding: false },
  bubbleTextBad: { color: '#e01e4a' },
  tail: { position: 'absolute', bottom: -7, width: 12, height: 12, backgroundColor: '#ffffff', borderRightWidth: 2.5, borderBottomWidth: 2.5, borderColor: '#45189a', transform: [{ rotate: '45deg' }] },
  tailBad: { backgroundColor: '#fff0f3', borderColor: '#e01e4a' },
});

export default memo(forwardRef(Buddy));
