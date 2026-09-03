import React, { useEffect, useRef } from 'react';
import { View, Text, Image, Pressable, StyleSheet, Animated, Easing } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { squadColors, squadFonts } from '../theme/squadTheme';
import AssembleCreature from './AssembleCreature';

// The two card types on Home's "MY CREATURES" tab, ported from the decoded
// "ASMR Creature Squash Game.html": the dashed "Create your own squishy" card
// (always at index 0) and a card per custom creature the player has made.

// --- "Create your own squishy" -------------------------------------------

export function CreateOwnCard({ onPress }) {
  // createPulse: scale 1 -> 1.07 -> 1 with a widening glow, 2.4s loop
  const pulse = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(pulse, { toValue: 1, duration: 1200, easing: Easing.inOut(Easing.ease), useNativeDriver: true }),
        Animated.timing(pulse, { toValue: 0, duration: 1200, easing: Easing.inOut(Easing.ease), useNativeDriver: true }),
      ])
    );
    loop.start();
    return () => loop.stop();
  }, [pulse]);
  const badgeScale = pulse.interpolate({ inputRange: [0, 1], outputRange: [1, 1.07] });

  return (
    <Pressable style={styles.cardShell} onPress={onPress}>
      <LinearGradient
        colors={['#2a1650', squadColors.inputBg]}
        start={{ x: 0.15, y: 0 }}
        end={{ x: 0.85, y: 1 }}
        style={[styles.card, styles.cardDashed]}
      >
        <View style={styles.createBody}>
          <Animated.View style={[styles.plusBadge, { transform: [{ scale: badgeScale }] }]}>
            <LinearGradient colors={['#ff3ea5', '#a21caf']} start={{ x: 0, y: 0 }} end={{ x: 1, y: 1 }} style={StyleSheet.absoluteFillObject} />
            <View style={styles.plusH} />
            <View style={styles.plusV} />
          </Animated.View>
          <Text style={styles.createTitle}>Create your own squishy</Text>
          <Text style={styles.createSub}>Upload or draw a picture, add a squish sound, and we turn it into 3D.</Text>
          <View style={styles.pricePill}>
            <Text style={styles.priceAmount}>$4.99</Text>
            <Text style={styles.priceUnit}>PER CREATURE</Text>
          </View>
        </View>
      </LinearGradient>
    </Pressable>
  );
}

// --- a made creature ----------------------------------------------------
//
// `status`: 'pending' | 'running' (Tripo working, `progress` 0–100) |
// 'ready' | 'failed'. Assemble-path creatures are always 'ready' with a
// `build`; photo-path creatures show their source photo under a scan-line
// while generating and become a real 3D squishy once done.

function ScanLine() {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const loop = Animated.loop(Animated.timing(t, { toValue: 1, duration: 1500, easing: Easing.linear, useNativeDriver: true }));
    loop.start();
    return () => loop.stop();
  }, [t]);
  const translateY = t.interpolate({ inputRange: [0, 1], outputRange: [-70, 70] });
  return <Animated.View pointerEvents="none" style={[styles.scanLine, { transform: [{ translateY }] }]} />;
}

export function CustomCreatureCard({ creature, onPlay, onDelete, onRetry }) {
  const status = creature.status || 'ready';
  const busy = status === 'pending' || status === 'running';
  const failed = status === 'failed';
  const progress = Math.round(creature.progress || 0);

  return (
    <View style={styles.cardShell}>
      <LinearGradient
        colors={['#2a1650', squadColors.inputBg]}
        start={{ x: 0.15, y: 0 }}
        end={{ x: 0.85, y: 1 }}
        style={[styles.card, styles.cardCustom]}
      >
        <Pressable style={styles.cardBody} onPress={busy ? undefined : onPlay}>
          <View style={styles.customImageArea}>
            {creature.build ? (
              <View style={[styles.customPhoto, styles.customPhotoEmpty]}>
                <AssembleCreature build={creature.build} size={112} />
              </View>
            ) : creature.sourceImageUrl ? (
              <View style={styles.customPhotoWrap}>
                <Image source={{ uri: creature.sourceImageUrl }} style={[styles.customPhoto, busy && styles.customPhotoDim]} />
                {busy ? <ScanLine /> : null}
              </View>
            ) : (
              <View style={[styles.customPhoto, styles.customPhotoEmpty]} />
            )}

            {busy ? (
              <View style={styles.genBadge}>
                <Text style={styles.genBadgeText}>GENERATING 3D · {progress}%</Text>
              </View>
            ) : failed ? (
              <View style={[styles.genBadge, styles.genBadgeFail]}>
                <Text style={styles.genBadgeText}>GENERATION FAILED</Text>
              </View>
            ) : creature.audio ? (
              <View style={styles.ownSoundBadge}>
                <View style={styles.soundBars}>
                  <View style={[styles.soundBar, { height: 5 }]} />
                  <View style={[styles.soundBar, { height: 11 }]} />
                  <View style={[styles.soundBar, { height: 7 }]} />
                </View>
                <Text style={styles.ownSoundText}>OWN SOUND</Text>
              </View>
            ) : null}
          </View>

          <View style={styles.customInfoArea}>
            <Text style={styles.customName} numberOfLines={1}>
              {creature.name}
            </Text>
            <Text style={styles.customMeta} numberOfLines={1}>
              {busy
                ? 'Building your 3D squishy…'
                : failed
                ? creature.error || 'Something went wrong'
                : `Your creation · made ${creature.created}`}
            </Text>
            <View style={styles.customStatusRow}>
              <Pressable onPress={onDelete} hitSlop={8}>
                <Text style={styles.deleteLabel}>DELETE</Text>
              </Pressable>
              {busy ? (
                <Text style={styles.busyLabel}>PLEASE WAIT…</Text>
              ) : failed ? (
                <Pressable onPress={onRetry} hitSlop={8}>
                  <Text style={styles.retryLabel}>RETRY →</Text>
                </Pressable>
              ) : (
                <Text style={styles.tapToPlayLabel}>TAP TO PLAY →</Text>
              )}
            </View>
          </View>
        </Pressable>
      </LinearGradient>
    </View>
  );
}

const styles = StyleSheet.create({
  cardShell: { width: '84%', maxWidth: 340, height: '96%', alignItems: 'center' },
  card: {
    width: '100%',
    height: '100%',
    borderRadius: 28,
    borderWidth: 2,
    overflow: 'hidden',
    shadowColor: '#000000',
    shadowOffset: { width: 0, height: 16 },
    shadowOpacity: 0.4,
    shadowRadius: 34,
    elevation: 10,
  },
  cardDashed: { borderStyle: 'dashed', borderColor: squadColors.pinkLight, alignItems: 'center', justifyContent: 'center' },
  cardCustom: { borderColor: 'rgba(34,224,208,0.33)' },
  // whole custom card is tappable → play; the DELETE pill keeps its own handler
  cardBody: { flex: 1, flexDirection: 'column' },

  // create-own
  createBody: { alignItems: 'center', justifyContent: 'center', gap: 9, padding: 16 },
  plusBadge: {
    width: 62,
    height: 62,
    borderRadius: 31,
    overflow: 'hidden',
    alignItems: 'center',
    justifyContent: 'center',
    shadowColor: squadColors.pink,
    shadowOpacity: 0.45,
    shadowRadius: 26,
    shadowOffset: { width: 0, height: 10 },
  },
  plusH: { position: 'absolute', width: 26, height: 4, borderRadius: 2, backgroundColor: '#fff' },
  plusV: { position: 'absolute', width: 4, height: 26, borderRadius: 2, backgroundColor: '#fff' },
  createTitle: { fontFamily: squadFonts.headingExtraBold, fontSize: 17, color: '#fff', textAlign: 'center', lineHeight: 20 },
  createSub: { color: '#b7a3e0', fontSize: 11, fontFamily: squadFonts.bodyBold, textAlign: 'center', lineHeight: 15, maxWidth: 210 },
  pricePill: {
    marginTop: 2,
    flexDirection: 'row',
    alignItems: 'center',
    gap: 8,
    backgroundColor: squadColors.bgDeepest,
    borderWidth: 1.5,
    borderColor: squadColors.gold,
    borderRadius: 999,
    paddingHorizontal: 14,
    paddingVertical: 7,
  },
  priceAmount: { fontFamily: squadFonts.headingExtraBold, fontSize: 15, color: squadColors.gold },
  priceUnit: { color: squadColors.textLavender, fontFamily: squadFonts.bodyExtraBold, fontSize: 9, letterSpacing: 1.4 },

  // custom creature
  customImageArea: { flex: 1, minHeight: 0, alignItems: 'center', justifyContent: 'center', position: 'relative' },
  customPhoto: {
    width: 118,
    height: 118,
    borderRadius: 59,
    borderWidth: 2.5,
    borderColor: 'rgba(34,224,208,0.5)',
  },
  customPhotoEmpty: { backgroundColor: squadColors.panel, alignItems: 'center', justifyContent: 'center', overflow: 'hidden' },
  customPhotoWrap: { width: 118, height: 118, borderRadius: 59, overflow: 'hidden', borderWidth: 2.5, borderColor: 'rgba(34,224,208,0.5)' },
  customPhotoDim: { opacity: 0.6, borderWidth: 0 },
  scanLine: { position: 'absolute', left: 0, right: 0, height: 24, backgroundColor: 'rgba(34,224,208,0.4)' },
  genBadge: {
    position: 'absolute',
    bottom: 10,
    alignSelf: 'center',
    backgroundColor: 'rgba(21,10,46,0.85)',
    borderWidth: 1,
    borderColor: 'rgba(34,224,208,0.4)',
    borderRadius: 999,
    paddingHorizontal: 11,
    paddingVertical: 4,
  },
  genBadgeFail: { borderColor: '#f87171' },
  genBadgeText: { color: squadColors.teal, fontFamily: squadFonts.bodyExtraBold, fontSize: 9, letterSpacing: 1 },
  busyLabel: { color: squadColors.textFaint, fontFamily: squadFonts.bodyExtraBold, fontSize: 11, letterSpacing: 1 },
  retryLabel: { color: squadColors.gold, fontFamily: squadFonts.bodyExtraBold, fontSize: 12, letterSpacing: 1 },
  ownSoundBadge: {
    position: 'absolute',
    bottom: 10,
    right: 12,
    flexDirection: 'row',
    alignItems: 'center',
    gap: 5,
    backgroundColor: 'rgba(21,10,46,0.8)',
    borderWidth: 1,
    borderColor: 'rgba(34,224,208,0.33)',
    borderRadius: 999,
    paddingHorizontal: 9,
    paddingVertical: 4,
  },
  soundBars: { flexDirection: 'row', alignItems: 'flex-end', gap: 2, height: 11 },
  soundBar: { width: 2, backgroundColor: squadColors.teal, borderRadius: 1 },
  ownSoundText: { color: squadColors.teal, fontFamily: squadFonts.bodyExtraBold, fontSize: 8, letterSpacing: 1 },

  customInfoArea: { flexBasis: 82, flexGrow: 0, flexShrink: 0, paddingHorizontal: 16, paddingVertical: 8 },
  customName: { fontFamily: squadFonts.headingExtraBold, fontSize: 16, color: '#fff', lineHeight: 18 },
  customMeta: { color: '#b7a3e0', fontSize: 11, fontFamily: squadFonts.bodyBold, marginTop: 2 },
  customStatusRow: {
    marginTop: 'auto',
    paddingTop: 4,
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'space-between',
  },
  deleteLabel: { color: '#f87171', fontFamily: squadFonts.bodyExtraBold, fontSize: 11, letterSpacing: 1 },
  tapToPlayLabel: { color: squadColors.teal, fontFamily: squadFonts.bodyExtraBold, fontSize: 12 },
});
