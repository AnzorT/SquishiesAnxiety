import React, { useEffect, useRef, useState } from 'react';
import { View, Text, StyleSheet, PanResponder, Pressable } from 'react-native';
import { Canvas } from '@react-three/fiber';
import SquishyToy, { COLOR_DEFS } from '../components/SquishyToy';
import { SquishyAudioEngine } from '../audio/SquishyAudioEngine';
import { spacing } from '../theme/tokens';

// "Squish Buddies" — ported design: poke the body to dent it (soft-body
// spring + diffusion physics), drag empty space to spin it, tap the nose to
// boop it. See src/components/SquishyToy.js for the physics itself.

const STAGE_WIDTH = 360;
const STAGE_HEIGHT = 400;

export default function SquishScreen({ toy, onBack }) {
  const toyRef = useRef(null);
  const audioRef = useRef(null);
  const lastTouch = useRef({ x: 0, y: 0 });
  const [score] = useState(1240);
  const [selected, setSelected] = useState(toy.startingColorIndex ?? 0);
  const [muted, setMuted] = useState(false);

  useEffect(() => {
    const engine = new SquishyAudioEngine();
    audioRef.current = engine;
    engine.init(false);
    return () => {
      engine.unloadAll();
    };
  }, []);

  const toggleMute = () => {
    setMuted((prev) => {
      const next = !prev;
      audioRef.current?.setMuted(next);
      return next;
    });
  };

  const ndcFromLocation = (locationX, locationY) => ({
    x: (locationX / STAGE_WIDTH) * 2 - 1,
    y: -((locationY / STAGE_HEIGHT) * 2 - 1),
  });

  const panResponder = useRef(
    PanResponder.create({
      onStartShouldSetPanResponder: () => true,
      onMoveShouldSetPanResponder: () => true,
      onPanResponderGrant: (evt) => {
        const { locationX, locationY } = evt.nativeEvent;
        lastTouch.current = { x: locationX, y: locationY };
        const ndc = ndcFromLocation(locationX, locationY);
        toyRef.current?.pointerDown(ndc.x, ndc.y);
      },
      onPanResponderMove: (evt) => {
        const { locationX, locationY } = evt.nativeEvent;
        const dx = locationX - lastTouch.current.x;
        const dy = locationY - lastTouch.current.y;
        lastTouch.current = { x: locationX, y: locationY };
        const ndc = ndcFromLocation(locationX, locationY);
        toyRef.current?.pointerMove(ndc.x, ndc.y, dx, dy);
      },
      onPanResponderRelease: () => toyRef.current?.pointerUp(),
      onPanResponderTerminate: () => toyRef.current?.pointerUp(),
    })
  ).current;

  const current = COLOR_DEFS[selected];

  return (
    <View style={[styles.container, { backgroundColor: current.light }]}>
      <View style={styles.topBar}>
        <Text onPress={onBack} style={[styles.back, { color: current.deep }]}>
          ‹
        </Text>
        <View style={styles.scorePill}>
          <Text style={styles.scoreText}>{score}</Text>
        </View>
        <Pressable onPress={toggleMute} style={styles.muteBtn}>
          <Text style={{ fontSize: 18 }}>{muted ? '🔈' : '🔊'}</Text>
        </Pressable>
      </View>

      <Text style={[styles.title, { color: current.deep }]}>{toy.name}</Text>
      <Text style={styles.subtitle}>poke, squeeze, and stretch — just breathe</Text>

      <View style={styles.swatchRow}>
        {COLOR_DEFS.map((c, i) => (
          <Pressable
            key={c.name}
            onPress={() => {
              setSelected(i);
              toyRef.current?.selectColor(i);
            }}
            style={[styles.swatchBtn, { borderColor: i === selected ? c.deep : '#EDE4F9' }]}
          >
            <View style={[styles.swatchInner, { backgroundColor: c.mid }]} />
          </Pressable>
        ))}
      </View>

      <View style={styles.stage} {...panResponder.panHandlers}>
        <Canvas camera={{ fov: 32, position: [0, 0.15, 4.4], near: 0.1, far: 100 }}>
          <ambientLight intensity={0.62} />
          <directionalLight color={0xfff2e0} intensity={1.35} position={[2.2, 3, 3]} />
          <directionalLight color={0xcdd8ff} intensity={0.55} position={[-2.5, -1, 2]} />
          <directionalLight color={0xffffff} intensity={0.4} position={[-1.5, 2, -3]} />
          <SquishyToy
            ref={toyRef}
            startingColorIndex={selected}
            onSquish={() => audioRef.current?.playSquish()}
            onRelease={() => audioRef.current?.playRelease()}
            onStick={() => audioRef.current?.playStick()}
            onBoop={() => audioRef.current?.playBoop()}
          />
        </Canvas>
      </View>

      <Text style={styles.caption}>
        drag the buddy to squish & stretch it · drag empty space to spin it around
      </Text>
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, alignItems: 'center' },
  topBar: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    width: '100%',
    paddingHorizontal: spacing(5),
    paddingTop: spacing(12),
  },
  back: { fontSize: 26, fontWeight: '700' },
  scorePill: {
    backgroundColor: 'rgba(255,255,255,0.7)',
    borderRadius: 999,
    paddingHorizontal: spacing(4),
    paddingVertical: spacing(1),
  },
  scoreText: { fontSize: 14, fontWeight: '600', color: '#7C4FC0' },
  muteBtn: {
    width: 40,
    height: 40,
    borderRadius: 20,
    borderWidth: 2,
    borderColor: '#E4D6F6',
    backgroundColor: '#FFFFFF',
    alignItems: 'center',
    justifyContent: 'center',
  },
  title: {
    fontSize: 32,
    fontWeight: '800',
    marginTop: spacing(6),
    letterSpacing: -0.5,
  },
  subtitle: {
    fontSize: 14,
    fontWeight: '600',
    color: '#9C87BD',
    marginTop: spacing(1),
  },
  swatchRow: {
    flexDirection: 'row',
    gap: spacing(3),
    marginTop: spacing(6),
  },
  swatchBtn: {
    width: 46,
    height: 46,
    borderRadius: 23,
    borderWidth: 3,
    backgroundColor: '#FFFFFF',
    alignItems: 'center',
    justifyContent: 'center',
  },
  swatchInner: { width: 26, height: 26, borderRadius: 13 },
  stage: { width: STAGE_WIDTH, height: STAGE_HEIGHT, marginTop: spacing(4) },
  caption: {
    fontSize: 13,
    fontWeight: '600',
    fontStyle: 'italic',
    color: '#A691C6',
    marginTop: spacing(1),
    marginBottom: spacing(8),
    textAlign: 'center',
    maxWidth: 300,
    paddingHorizontal: spacing(6),
  },
});
