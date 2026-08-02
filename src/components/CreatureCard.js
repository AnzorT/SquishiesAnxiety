import React, { useEffect, useRef, useState } from 'react';
import { View, Text, StyleSheet, Pressable, Animated, Easing } from 'react-native';
import { colors, radii, spacing } from '../theme/tokens';
import SquishyThumbnail from './SquishyThumbnail';

// Card widget styled after the PlushCrush2 reference's shelf item. A locked
// creature shows a dark lock scrim across the whole image (not a small
// corner badge) plus a big Unlock button in the body. Pressing it plays a
// fixed-duration fill animation in place of the button while the purchase
// goes through — cosmetic rather than tied to actual network timing, same
// spirit as this app's other reward animations (coin pop, boost timer).
// Each creature is a single fixed color now, so there's no color-swatch row
// to show.
const PURCHASE_ANIM_MS = 1100;

function LockIcon() {
  return (
    <View style={styles.padlockBody}>
      <View style={styles.padlockShackle} />
    </View>
  );
}

export default function CreatureCard({ creature, unlocked, onPress, style }) {
  const primary = creature.colors?.[0] ?? colors.accent;
  const [purchasing, setPurchasing] = useState(false);
  const progressAnim = useRef(new Animated.Value(0)).current;

  // If the purchase actually lands (ownedIds updates and flows back down as
  // `unlocked`), drop the in-progress state immediately rather than waiting
  // out the rest of the cosmetic animation.
  useEffect(() => {
    if (unlocked) {
      setPurchasing(false);
      progressAnim.setValue(0);
    }
  }, [unlocked, progressAnim]);

  const handlePress = () => {
    if (!unlocked && !purchasing) {
      setPurchasing(true);
      progressAnim.setValue(0);
      Animated.timing(progressAnim, {
        toValue: 1,
        duration: PURCHASE_ANIM_MS,
        easing: Easing.out(Easing.cubic),
        useNativeDriver: false,
      }).start(({ finished }) => {
        // Still locked once the bar fills (e.g. insufficient coins) — reset
        // back to the button so the card doesn't get stuck mid-progress.
        if (finished) setPurchasing(false);
      });
    }
    onPress();
  };

  const progressWidth = progressAnim.interpolate({ inputRange: [0, 1], outputRange: ['0%', '100%'] });

  return (
    <Pressable style={[styles.card, style]} onPress={handlePress}>
      <View style={styles.stageArea}>
        <SquishyThumbnail colorHex={primary} species={creature.species} size={150} />
        {unlocked ? (
          <View style={[styles.badge, styles.badgeUnlocked]}>
            <Text style={styles.badgeCheck}>✓</Text>
          </View>
        ) : (
          <View style={styles.lockOverlay}>
            <LockIcon />
          </View>
        )}
      </View>

      <View style={styles.body}>
        <View style={styles.titleRow}>
          <Text style={styles.name} numberOfLines={1}>
            {creature.name}
          </Text>
          <Text style={[styles.status, unlocked ? styles.statusUnlocked : styles.statusLocked]}>
            {unlocked ? 'OWNED' : 'LOCKED'}
          </Text>
        </View>
        <Text style={styles.description} numberOfLines={2}>
          {creature.description}
        </Text>

        {!unlocked && (
          <View style={styles.unlockArea}>
            {purchasing ? (
              <View style={styles.progressTrack}>
                <Animated.View style={[styles.progressFill, { width: progressWidth }]} />
              </View>
            ) : (
              <View style={styles.unlockButton}>
                <Text style={styles.unlockButtonText}>Unlock · {creature.price}⊙</Text>
              </View>
            )}
          </View>
        )}
      </View>
    </Pressable>
  );
}

const styles = StyleSheet.create({
  card: {
    backgroundColor: colors.surface,
    borderRadius: radii.lg,
    borderWidth: 1,
    borderColor: colors.surfaceBorder,
    overflow: 'hidden',
    shadowColor: colors.accent,
    shadowOpacity: 0.14,
    shadowRadius: 16,
    shadowOffset: { width: 0, height: 8 },
    elevation: 4,
  },
  stageArea: {
    flex: 1.35,
    backgroundColor: colors.bgGradientMid,
    alignItems: 'center',
    justifyContent: 'center',
  },
  lockOverlay: {
    ...StyleSheet.absoluteFillObject,
    backgroundColor: 'rgba(29,20,46,0.45)',
    alignItems: 'center',
    justifyContent: 'center',
  },
  badge: {
    position: 'absolute',
    top: spacing(3.5),
    right: spacing(3.5),
    width: 30,
    height: 30,
    borderRadius: 15,
    alignItems: 'center',
    justifyContent: 'center',
  },
  badgeUnlocked: { backgroundColor: colors.success },
  badgeCheck: { color: '#FFFFFF', fontSize: 14, fontWeight: '900' },
  padlockBody: {
    width: 22,
    height: 18,
    borderRadius: 4,
    backgroundColor: '#FFFFFF',
  },
  padlockShackle: {
    position: 'absolute',
    top: -12,
    left: 3,
    width: 16,
    height: 16,
    borderRadius: 8,
    borderWidth: 3,
    borderColor: '#FFFFFF',
    borderBottomWidth: 0,
  },
  body: { flex: 0.8, padding: spacing(4) },
  titleRow: { flexDirection: 'row', alignItems: 'baseline', justifyContent: 'space-between' },
  name: { fontSize: 18, fontWeight: '800', color: colors.textPrimary, flexShrink: 1 },
  status: { fontSize: 11, fontWeight: '700', letterSpacing: 0.5, textTransform: 'uppercase' },
  statusUnlocked: { color: colors.success },
  statusLocked: { color: colors.textMuted },
  description: { fontSize: 12, fontWeight: '500', color: colors.textMuted, marginTop: spacing(0.5), lineHeight: 16 },
  unlockArea: { marginTop: spacing(2) },
  unlockButton: {
    height: 38,
    borderRadius: radii.pill,
    backgroundColor: colors.buttonPrimary,
    alignItems: 'center',
    justifyContent: 'center',
  },
  unlockButtonText: { color: '#FFFFFF', fontSize: 13, fontWeight: '800' },
  progressTrack: {
    height: 38,
    borderRadius: radii.pill,
    backgroundColor: colors.surfaceBorder,
    overflow: 'hidden',
    justifyContent: 'center',
  },
  progressFill: {
    height: '100%',
    backgroundColor: colors.buttonPrimary,
    borderRadius: radii.pill,
  },
});
