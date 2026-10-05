import React, { useEffect, useRef, useState } from 'react';
import { View, StyleSheet, Pressable, Animated, Easing } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { candyFonts } from '../theme/candyTheme';
import CreatureThumbnail from '../components/CreatureThumbnail';
import CandyBackground from '../components/candy/CandyBackground';
import CandyButton from '../components/candy/CandyButton';
import TutTarget from '../tutorial/Target';
import OutlinedTitle, { HaloText } from '../components/candy/OutlinedTitle';

// First thing shown on launch — the v3 splash: every creature scattered
// around the screen (owned ones bright and full-size, locked ones dim and
// smaller) over the candy stage with its sparkles, the wobbling gold/pink
// "SQUISH SQUAD" sticker wordmark, and the pulsing pink CTA. Stays up until
// the player taps — no auto-advance timer.
//
// `creatures` now comes from App.js's on-device cache of the Firestore
// catalog (see src/data/creatureCache.js), not bundled data — on a
// brand-new install, before anyone has ever logged in, there's no cache yet
// and this array is empty on purpose: the splash just shows no floaters
// that one time, rather than reaching Firestore before auth exists. Once a
// cache has been written (first successful login), every future launch has
// it immediately, before auth even resolves.

// the scattered creatures idle or dance (the user's)
const MOODS = ['idle', 'dance'];

// Where each creature sits: a zone of the screen plus the creature's centre
// as a fraction of that zone. The zones are measured on screen, so a
// creature never lands behind the wordmark, the tagline or the button,
// whatever the screen's shape:
//  · top          — between the status bar and the wordmark
//  · mid          — between the tagline and TAP TO START
//  · left / right — beside the wordmark
//  · btnLeft / btnRight — beside the button
// Consecutive creatures alternate zones, so a small roster still spreads
// over the whole screen. Sizes shrink to fit a short zone.
const SPLASH_SLOTS = [
  { zone: 'top', fx: 0.14, fy: 0.3, size: 70 },
  { zone: 'mid', fx: 0.8, fy: 0.17, size: 66 },
  { zone: 'top', fx: 0.66, fy: 0.3, size: 62 },
  { zone: 'mid', fx: 0.16, fy: 0.2, size: 72 },
  { zone: 'top', fx: 0.3, fy: 0.78, size: 56 },
  { zone: 'mid', fx: 0.44, fy: 0.52, size: 64 },
  { zone: 'top', fx: 0.88, fy: 0.74, size: 54 },
  { zone: 'mid', fx: 0.4, fy: 0.84, size: 66 },
  { zone: 'top', fx: 0.41, fy: 0.2, size: 50 },
  { zone: 'mid', fx: 0.78, fy: 0.56, size: 58 },
  { zone: 'top', fx: 0.6, fy: 0.8, size: 58 },
  { zone: 'mid', fx: 0.12, fy: 0.6, size: 54 },
  { zone: 'top', fx: 0.9, fy: 0.24, size: 46 },
  { zone: 'mid', fx: 0.75, fy: 0.88, size: 56 },
  { zone: 'left', fx: 0.5, fy: 0.5, size: 50 },
  { zone: 'right', fx: 0.5, fy: 0.5, size: 50 },
  { zone: 'mid', fx: 0.12, fy: 0.9, size: 50 },
  { zone: 'mid', fx: 0.46, fy: 0.18, size: 50 },
  { zone: 'btnLeft', fx: 0.5, fy: 0.5, size: 46 },
  { zone: 'btnRight', fx: 0.5, fy: 0.5, size: 46 },
];

// The height each zone's sizes were chosen for; a shorter zone scales its
// creatures down.
const ZONE_REF_H = { top: 230, mid: 260 };
const GAP = 10; // clear space kept around the wordmark block and the button
const JUMP = 0.26; // the jump mood lifts a creature by 26% of its size

// Zone rectangles from the measured screen, wordmark block and button.
function zonesFor(screen, block, button, topInset) {
  const blockBottom = block.y + block.h;
  return {
    top: { x: 0, y: topInset + 4, w: screen.w, h: block.y - GAP - topInset - 4 },
    mid: { x: 0, y: blockBottom + GAP, w: screen.w, h: button.y - GAP - blockBottom - GAP },
    left: { x: 0, y: block.y, w: block.x - GAP, h: block.h },
    right: { x: block.x + block.w + GAP, y: block.y, w: screen.w - block.x - block.w - GAP, h: block.h },
    btnLeft: { x: 0, y: button.y, w: button.x - GAP, h: button.h },
    btnRight: { x: button.x + button.w + GAP, y: button.y, w: screen.w - button.x - button.w - GAP, h: button.h },
  };
}

// A slot's box inside its zone ({ left, top, size }), or null when the zone
// has no room for it on this screen.
function place(slot, zone, locked) {
  if (!zone || zone.w <= 0 || zone.h <= 0) return null;
  const fit = ZONE_REF_H[slot.zone] ? Math.min(1, zone.h / ZONE_REF_H[slot.zone]) : 1;
  // the side zones are narrow: shrink to fit, or leave the slot empty
  const size = Math.min(slot.size * fit * (locked ? 0.75 : 1), zone.w - 4, zone.h / (1 + JUMP));
  if (size < 30) return null;
  const minTop = zone.y + size * JUMP;
  const maxTop = zone.y + zone.h - size;
  const top = Math.min(maxTop, Math.max(minTop, zone.y + zone.h * slot.fy - size / 2));
  const left = Math.min(zone.x + zone.w - size, Math.max(zone.x, zone.x + zone.w * slot.fx - size / 2));
  return { left, top, size };
}

function FloatingCreature({ creature, unlocked, box, delay, mood }) {
  const enter = useRef(new Animated.Value(0)).current;

  useEffect(() => {
    const entrance = Animated.timing(enter, {
      toValue: 1,
      duration: 420,
      delay,
      easing: Easing.out(Easing.back(1.3)),
      useNativeDriver: true,
    });
    entrance.start();
    return () => entrance.stop();
  }, [enter, delay]);

  return (
    <Animated.View
      style={{
        position: 'absolute',
        top: box.top,
        left: box.left,
        opacity: Animated.multiply(enter, unlocked ? 0.95 : 0.35),
        transform: [{ scale: enter }],
      }}
    >
      {/* Locked creatures stay still — no bounce/wobble — so the splash
          scatter reads as "these are the ones you haven't earned yet"
          rather than inviting a tap on something not actually playable. */}
      <CreatureThumbnail creature={creature} mood={mood} size={box.size} locked={!unlocked} animate={unlocked} />
    </Animated.View>
  );
}

const rectOf = (e) => {
  const { x, y, width, height } = e.nativeEvent.layout;
  return { x, y, w: width, h: height };
};

export default function SplashScreen({ onFinish, ownedIds = [], creatures = [] }) {
  const insets = useSafeAreaInsets();
  const finished = useRef(false);
  // Measured on screen: the whole stage, the view that centres the wordmark,
  // the wordmark + tagline block inside it, and the button.
  const [screen, setScreen] = useState(null);
  const [center, setCenter] = useState(null);
  const [block, setBlock] = useState(null);
  const [button, setButton] = useState(null);

  const skip = () => {
    if (finished.current) return;
    finished.current = true;
    onFinish();
  };

  const zones =
    screen && center && block && button
      ? zonesFor(screen, { x: center.x + block.x, y: center.y + block.y, w: block.w, h: block.h }, button, insets.top)
      : null;

  return (
    <Pressable style={styles.flex} onPress={skip}>
      <CandyBackground sparkles sparkleOpacity={1} style={styles.container}>
        <View style={StyleSheet.absoluteFill} pointerEvents="none" onLayout={(e) => setScreen(rectOf(e))}>
          {zones
            ? creatures.slice(0, SPLASH_SLOTS.length).map((creature, i) => {
                const unlocked = ownedIds.includes(String(creature.id));
                const slot = SPLASH_SLOTS[i];
                const box = place(slot, zones[slot.zone], !unlocked);
                if (!box) return null;
                return (
                  <FloatingCreature
                    key={creature.id}
                    creature={creature}
                    unlocked={unlocked}
                    box={box}
                    delay={i * 90}
                    mood={MOODS[i % MOODS.length]}
                  />
                );
              })
            : null}
        </View>

        <View style={styles.center} onLayout={(e) => setCenter(rectOf(e))}>
          {/* padded so the keep-out box covers the wordmark's wobble (±3°, up to 1.05×) */}
          <View style={styles.block} onLayout={(e) => setBlock(rectOf(e))}>
            <Wordmark />
            <HaloText style={styles.tagline}>Squash · Relax · Repeat</HaloText>
          </View>
        </View>

        <View style={{ marginBottom: insets.bottom + 48 }} onLayout={(e) => setButton(rectOf(e))}>
          <TutTarget name="start">
            <CandyButton label="TAP TO START" onPress={skip} pulse="cta" size="lg" />
          </TutTarget>
        </View>
      </CandyBackground>
    </Pressable>
  );
}

// "SQUISH" (gold) over "SQUAD" (pink), wobbling together as one sticker.
function Wordmark() {
  const wob = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(wob, { toValue: 1, duration: 1300, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
        Animated.timing(wob, { toValue: 0, duration: 1300, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
      ])
    );
    loop.start();
    return () => loop.stop();
  }, [wob]);
  const rotate = wob.interpolate({ inputRange: [0, 1], outputRange: ['-3deg', '3deg'] });
  const scale = wob.interpolate({ inputRange: [0, 1], outputRange: [1, 1.05] });
  return (
    <Animated.View style={{ alignItems: 'center', transform: [{ rotate }, { scale }] }}>
      <OutlinedTitle text="SQUISH" fill="gold" size={52} outline={4} />
      <OutlinedTitle text="SQUAD" fill="pink" size={52} outline={4} style={{ marginTop: -14 }} />
    </Animated.View>
  );
}

const styles = StyleSheet.create({
  flex: { flex: 1 },
  container: { flex: 1, alignItems: 'center' },
  center: { flex: 1, alignSelf: 'stretch', alignItems: 'center', justifyContent: 'center' },
  block: { alignItems: 'center', paddingHorizontal: 10, paddingVertical: 8 },
  tagline: {
    marginTop: 6,
    fontFamily: candyFonts.bodyHeavy,
    fontSize: 13,
    letterSpacing: 3,
    textTransform: 'uppercase',
  },
});
