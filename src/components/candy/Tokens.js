import React, { memo } from 'react';
import { StyleSheet, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { TIERS, candyColors, tierOf } from '../../theme/candyTheme';
import CreatureThumbnail from '../CreatureThumbnail';
import { Shine } from './CandyButton';

// A creature's token (src/economy.js — every creature has its own): a round
// candy coin with a plum ring, a white rim, and the creature on a face in
// its rarity's colours, with a gloss on top.
function CreatureToken({ creature, size = 22 }) {
  const tier = tierOf(creature?.id) || 'Common';
  const bg = TIERS[tier].bg;
  const colors = bg.length > 1 ? bg : [bg[0], bg[0]];
  const ring = Math.min(3.5, Math.max(1, size * 0.07));
  const rim = Math.min(6, Math.max(1.5, size * 0.09));
  const face = size - (ring + rim) * 2;
  return (
    <View style={[styles.ring, { width: size, height: size, borderRadius: size / 2, padding: ring }]}>
      <View style={[styles.rim, { borderRadius: size / 2, padding: rim }]}>
        <LinearGradient colors={colors} start={{ x: 0, y: 0 }} end={{ x: 1, y: 1 }} style={[styles.face, { borderRadius: face / 2 }]}>
          {creature ? <CreatureThumbnail creature={creature} size={Math.round(face * 0.95)} animate={false} glow={false} /> : null}
          <Shine inset="14%" height="40%" />
        </LinearGradient>
      </View>
    </View>
  );
}

export default memo(CreatureToken);

const styles = StyleSheet.create({
  ring: { backgroundColor: candyColors.cardRing },
  rim: { flex: 1, backgroundColor: '#ffffff' },
  face: { flex: 1, overflow: 'hidden', alignItems: 'center', justifyContent: 'center' },
});
