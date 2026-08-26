import React, { useEffect, useRef } from 'react';
import { View, Text, StyleSheet, ScrollView, Animated, Easing } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { squadColors, squadGradients, squadFonts, squadRadii } from '../theme/squadTheme';
import { computeAchievements } from '../achievements';
import IconButton from '../components/squad/IconButton';
import CreatureThumbnail from '../components/CreatureThumbnail';

// Grid of achievement badges, matching the prototype's ACHIEVEMENTS screen.
// See src/achievements.js for what's tracked and why.

function ShimmerRing({ done, children }) {
  const anim = useRef(new Animated.Value(0)).current;

  useEffect(() => {
    if (!done) return undefined;
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(anim, { toValue: 1, duration: 1000, easing: Easing.inOut(Easing.sin), useNativeDriver: false }),
        Animated.timing(anim, { toValue: 0, duration: 1000, easing: Easing.inOut(Easing.sin), useNativeDriver: false }),
      ])
    );
    loop.start();
    return () => loop.stop();
  }, [done, anim]);

  const shadowOpacity = anim.interpolate({ inputRange: [0, 1], outputRange: [0, 0.55] });
  const shadowRadius = anim.interpolate({ inputRange: [0, 1], outputRange: [0, 10] });

  return (
    <Animated.View
      style={[
        styles.badge,
        done
          ? { backgroundColor: squadColors.panelBorder, shadowColor: squadColors.gold, shadowOpacity, shadowRadius, elevation: done ? 4 : 0 }
          : { backgroundColor: squadColors.inputBg },
      ]}
    >
      {children}
    </Animated.View>
  );
}

export default function AchievementsScreen({ creatures = [], ownedIds = [], totalEarned = 0, achievements = {}, onBack }) {
  const insets = useSafeAreaInsets();
  const entries = computeAchievements(creatures, ownedIds, totalEarned, achievements);
  const doneCount = entries.filter((e) => e.done).length;

  return (
    <LinearGradient colors={squadGradients.homeBg.colors} start={squadGradients.homeBg.start} end={squadGradients.homeBg.end} style={[styles.container, { paddingTop: insets.top }]}>
      <View style={styles.header}>
        <IconButton name="chevron-left" onPress={onBack} iconSize={22} />
        <Text style={styles.headerTitle}>ACHIEVEMENTS</Text>
        <Text style={styles.headerCount}>{doneCount}/{entries.length}</Text>
      </View>

      <ScrollView contentContainerStyle={[styles.grid, { paddingBottom: insets.bottom + 20 }]}>
        {entries.map((entry) => (
          <View key={entry.key} style={[styles.card, { borderColor: entry.done ? '#ffcd3c55' : squadColors.panelBorder }]}>
            <ShimmerRing done={entry.done}>
              {entry.creature ? (
                <CreatureThumbnail creatureId={entry.creature.id} mood={entry.done ? 'idle' : 'sleep'} size={46} locked={!entry.done} />
              ) : (
                <Text
                  style={[
                    styles.badgeLabel,
                    { color: entry.done ? squadColors.goldLight : squadColors.textDisabled, opacity: entry.done ? 1 : 0.6 },
                  ]}
                >
                  {entry.badgeLabel}
                </Text>
              )}
            </ShimmerRing>
            <Text style={[styles.cardTitle, { color: entry.done ? squadColors.textWhite : '#7a6ba0' }]}>{entry.title}</Text>
            <Text style={styles.cardDesc}>{entry.desc}</Text>
          </View>
        ))}
      </ScrollView>
    </LinearGradient>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1 },
  header: { flexDirection: 'row', alignItems: 'center', gap: 12, paddingHorizontal: 16, paddingVertical: 16 },
  headerTitle: { fontFamily: squadFonts.headingExtraBold, fontSize: 20, color: squadColors.textWhite },
  headerCount: { marginLeft: 'auto', color: squadColors.gold, fontFamily: squadFonts.bodyExtraBold, fontSize: 13 },
  grid: {
    paddingHorizontal: 16,
    paddingTop: 6,
    flexDirection: 'row',
    flexWrap: 'wrap',
    justifyContent: 'space-between',
    gap: 14,
  },
  card: {
    width: '47%',
    backgroundColor: squadColors.panelAlt,
    borderRadius: squadRadii.lg,
    borderWidth: 1.5,
    padding: 14,
    alignItems: 'center',
  },
  badge: {
    width: 66,
    height: 66,
    borderRadius: 33,
    alignItems: 'center',
    justifyContent: 'center',
  },
  badgeLabel: { fontFamily: squadFonts.headingExtraBold, fontSize: 16 },
  cardTitle: { fontFamily: squadFonts.headingBold, fontSize: 13, marginTop: 8, textAlign: 'center' },
  cardDesc: { color: squadColors.textMuted, fontFamily: squadFonts.bodyBold, fontSize: 10.5, marginTop: 3, textAlign: 'center', lineHeight: 14 },
});
