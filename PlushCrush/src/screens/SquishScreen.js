import React, { useState } from 'react';
import { View, Text, StyleSheet, PanResponder } from 'react-native';
import { Canvas } from '@react-three/fiber';
import PlushToy from '../components/PlushToy';
import ParticleBurst from '../components/ParticleBurst';
import FillSwapSheet from './FillSwapSheet';
import { useSquishToy } from '../hooks/useSquishToy';
import { colors, spacing, typography, radii } from '../theme/tokens';

export default function SquishScreen({ toy, onBack }) {
  const { squishState, particleTrigger, setFill, onTouchMove, onTouchEnd } = useSquishToy(
    toy.defaultFill
  );
  const [score, setScore] = useState(1240);
  const [fillSheetOpen, setFillSheetOpen] = useState(false);

  const panResponder = React.useRef(
    PanResponder.create({
      onStartShouldSetPanResponder: () => true,
      onMoveShouldSetPanResponder: () => true,
      onPanResponderMove: (evt) => {
        const { locationX, locationY } = evt.nativeEvent;
        // normalize to 0..1 uv-ish space against a nominal stage size
        const u = Math.min(Math.max(locationX / 320, 0), 1);
        const v = Math.min(Math.max(1 - locationY / 320, 0), 1);
        onTouchMove(u, v, 0.9);
      },
      onPanResponderRelease: onTouchEnd,
      onPanResponderTerminate: onTouchEnd,
    })
  ).current;

  return (
    <View style={styles.container}>
      <View style={styles.topBar}>
        <Text onPress={onBack} style={styles.back}>‹</Text>
        <View style={styles.scorePill}>
          <Text style={styles.scoreText}>{score}</Text>
        </View>
        <Text style={styles.menuDot}>·</Text>
      </View>

      <Text style={styles.stageLabel}>squish</Text>

      <View style={styles.stage} {...panResponder.panHandlers}>
        <Canvas camera={{ position: [0, 0, 3] }}>
          <ambientLight intensity={0.8} />
          <directionalLight position={[2, 3, 4]} intensity={0.9} />
          <PlushToy squishState={squishState} colorHex={toy.colorHex} />
          <ParticleBurst trigger={particleTrigger?.type} colorHex={toy.colorHex} />
        </Canvas>
      </View>

      <Text style={styles.scentLabel}>{toy.scent}</Text>

      <View style={styles.dock}>
        <Text onPress={() => setFillSheetOpen(true)} style={styles.dockText}>
          ● {squishState.profile.label} · ASMR
        </Text>
      </View>

      {fillSheetOpen && (
        <FillSwapSheet
          current={squishState.fillKey}
          onSelect={(key) => {
            setFill(key);
            setFillSheetOpen(false);
          }}
          onClose={() => setFillSheetOpen(false)}
        />
      )}
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, backgroundColor: colors.bgDeep, alignItems: 'center' },
  topBar: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    width: '100%',
    paddingHorizontal: spacing(5),
    paddingTop: spacing(12),
  },
  back: { ...typography.title, fontSize: 26 },
  scorePill: {
    backgroundColor: colors.glass,
    borderRadius: radii.pill,
    paddingHorizontal: spacing(4),
    paddingVertical: spacing(1),
  },
  scoreText: { ...typography.body, color: colors.textPrimary },
  menuDot: { ...typography.title, fontSize: 22 },
  stageLabel: { ...typography.label, marginTop: spacing(2) },
  stage: { width: 320, height: 320, marginTop: spacing(4) },
  scentLabel: { ...typography.body, marginTop: spacing(3) },
  dock: {
    backgroundColor: colors.glass,
    borderRadius: radii.pill,
    paddingHorizontal: spacing(5),
    paddingVertical: spacing(3),
    marginTop: spacing(6),
    borderWidth: 1,
    borderColor: colors.bgPanelBorder,
  },
  dockText: { ...typography.body, color: colors.textPrimary },
});
