import React, { memo, useEffect, useRef } from 'react';
import { View, Text, Image, Pressable, StyleSheet, Animated, Easing } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Defs, RadialGradient, Stop, Circle } from 'react-native-svg';
import { BUTTON_VARIANTS, candyColors, candyFonts } from '../theme/candyTheme';
import AssembleCreature from './AssembleCreature';
import { CandyCard, SoftPulse } from './candy/Decor';
import { ButtonText, CandyPill, Shine } from './candy/CandyButton';
import ShineSweep from './candy/ShineSweep';
import { CARD_SIZE } from './CardPager';

// The two card types on Home's "MY CREATURES" tab, in the v3 candy card: the
// dashed-rim "Create your own squishy" card (always at index 0) and a card
// per custom creature the player has made.

// --- "Create your own squishy" -------------------------------------------

// The free creations the player still has, as a blue candy pill (the old
// flat teal outline didn't belong with the candy look): a gold ball with the
// count, "FREE CREATION", gloss, a light streak and a gentle breath.
function FreeCreationPill({ count }) {
  const v = BUTTON_VARIANTS.blue;
  const gold = BUTTON_VARIANTS.gold;
  return (
    <SoftPulse style={styles.freeWrap}>
      <View style={[styles.freeLip, { backgroundColor: v.ring }]}>
        <View style={[styles.freeRing, { backgroundColor: v.ring }]}>
          <LinearGradient colors={v.colors} locations={v.locations} style={styles.freeFace}>
            <Shine />
            <ShineSweep />
            <View style={[styles.countRing, { backgroundColor: gold.ring }]}>
              <LinearGradient colors={gold.colors} locations={gold.locations} style={styles.countFace}>
                <ButtonText ring={gold.ring} size={13}>
                  {String(count)}
                </ButtonText>
              </LinearGradient>
            </View>
            <ButtonText ring={v.ring} size={14} style={styles.freeLabel}>
              {count === 1 ? 'FREE CREATION' : 'FREE CREATIONS'}
            </ButtonText>
          </LinearGradient>
        </View>
      </View>
    </SoftPulse>
  );
}

export const CreateOwnCard = memo(function CreateOwnCard({ onPress, generationCredits = 0, priceLabel = '$4.99', discountPct = 0 }) {
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
      <CandyCard style={styles.card} dashed innerStyle={styles.createBody}>
        <View style={styles.createGlow} pointerEvents="none">
          <Svg width={280} height={280}>
            <Defs>
              <RadialGradient id="createGlow" cx="50%" cy="50%" r="50%">
                <Stop offset="0" stopColor="#ff3ea5" stopOpacity={0.2} />
                <Stop offset="1" stopColor="#ff3ea5" stopOpacity={0} />
              </RadialGradient>
            </Defs>
            <Circle cx={140} cy={140} r={140} fill="url(#createGlow)" />
          </Svg>
        </View>
        <Animated.View style={[styles.plusBadge, { transform: [{ scale: badgeScale }] }]}>
          <LinearGradient colors={['#ffb8e4', '#c78bff']} start={{ x: 0, y: 0 }} end={{ x: 1, y: 1 }} style={StyleSheet.absoluteFillObject} />
          <View style={styles.plusH} />
          <View style={styles.plusV} />
        </Animated.View>
        <Text style={styles.createTitle}>Create your own squishy</Text>
        <Text style={styles.createSub}>Upload or draw a picture, add a squish sound, and we turn it into 3D.</Text>
        {generationCredits > 0 ? (
          <FreeCreationPill count={generationCredits} />
        ) : (
          <View style={styles.pricePill}>
            <Text style={styles.priceAmount}>{priceLabel}</Text>
            <Text style={styles.priceUnit}>PER CREATURE</Text>
            {discountPct ? <Text style={styles.discount}>−{discountPct}%</Text> : null}
          </View>
        )}
      </CandyCard>
    </Pressable>
  );
});

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

export const CustomCreatureCard = memo(function CustomCreatureCard({ creature, onPlay, onDelete, onRetry }) {
  const status = creature.status || 'ready';
  const busy = status === 'pending' || status === 'running';
  // 'capacity': the balance guard (or Tripo's own "insufficient credit" error)
  // held the job back before spending anything. 'blocked': the player had no
  // generation credit left. Both share the failure UI, distinct only in
  // their message — RETRY re-arms the job once they have a credit again.
  const failed = status === 'failed' || status === 'capacity' || status === 'blocked';
  const progress = Math.round(creature.progress || 0);

  return (
    <View style={styles.cardShell}>
      <CandyCard style={styles.card}>
        <Pressable style={styles.cardBody} onPress={busy ? undefined : onPlay}>
          <View style={styles.customImageArea}>
            {creature.build ? (
              <View style={[styles.customPhoto, styles.customPhotoEmpty]}>
                <AssembleCreature build={creature.build} size={112} />
              </View>
            ) : creature.sourceImageUrl ? (
              <View style={styles.customPhotoWrap}>
                <Image source={{ uri: creature.sourceImageUrl }} style={[styles.customPhotoImg, busy && styles.customPhotoDim]} />
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
                <Text style={[styles.genBadgeText, styles.genBadgeTextFail]}>GENERATION FAILED</Text>
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
                  <CandyPill variant="gold" label="RETRY ↻" />
                </Pressable>
              ) : (
                <CandyPill variant="blue" label="PLAY ▶" pulse fontSize={13} padV={5} padH={16} letterSpacing={0.8} />
              )}
            </View>
          </View>
        </Pressable>
      </CandyCard>
    </View>
  );
});

const styles = StyleSheet.create({
  cardShell: { ...CARD_SIZE, alignItems: 'center' },
  card: { width: '100%', height: '100%' },
  cardBody: { flex: 1, flexDirection: 'column' },

  // create-own
  createBody: { alignItems: 'center', justifyContent: 'center', gap: 8, padding: 16 },
  createGlow: { position: 'absolute', top: '6%' },
  plusBadge: {
    width: 56,
    height: 56,
    borderRadius: 28,
    overflow: 'hidden',
    alignItems: 'center',
    justifyContent: 'center',
    borderWidth: 3,
    borderColor: '#ffffff',
    shadowColor: '#ff3ea5',
    shadowOpacity: 0.45,
    shadowRadius: 13,
    shadowOffset: { width: 0, height: 10 },
    elevation: 6,
  },
  plusH: { position: 'absolute', width: 26, height: 4, borderRadius: 2, backgroundColor: '#fff' },
  plusV: { position: 'absolute', width: 4, height: 26, borderRadius: 2, backgroundColor: '#fff' },
  createTitle: { fontFamily: candyFonts.display, fontSize: 18, color: candyColors.ink, textAlign: 'center', lineHeight: 22 },
  createSub: { color: candyColors.muted, fontSize: 11.5, fontFamily: candyFonts.body, textAlign: 'center', lineHeight: 15, maxWidth: 210 },
  pricePill: {
    marginTop: 2,
    flexDirection: 'row',
    alignItems: 'center',
    gap: 8,
    backgroundColor: candyColors.paper,
    borderWidth: 1.5,
    borderColor: '#ffcd3c',
    borderRadius: 999,
    paddingHorizontal: 14,
    paddingVertical: 7,
  },
  priceAmount: { fontFamily: candyFonts.display, fontSize: 15, color: candyColors.goldInk },
  discount: {
    color: '#ffffff',
    backgroundColor: '#0f9d90',
    borderRadius: 999,
    overflow: 'hidden',
    paddingHorizontal: 7,
    paddingVertical: 1,
    fontFamily: candyFonts.bodyBlack,
    fontSize: 10,
    letterSpacing: 0.6,
  },
  priceUnit: { color: candyColors.inkSoft, fontFamily: candyFonts.bodyBlack, fontSize: 9, letterSpacing: 1.4 },
  freeWrap: { marginTop: 4 },
  freeLip: { borderRadius: 999, paddingBottom: 4 },
  freeRing: { borderRadius: 999, padding: 2 },
  freeFace: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: 7,
    borderRadius: 999,
    borderWidth: 3,
    borderColor: '#ffffff',
    overflow: 'hidden',
    paddingLeft: 4,
    paddingRight: 14,
    paddingVertical: 3,
  },
  freeLabel: { letterSpacing: 0.8 },
  countRing: { width: 24, height: 24, borderRadius: 12, padding: 1.5 },
  countFace: { flex: 1, borderRadius: 11, borderWidth: 2, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center', overflow: 'hidden' },

  // custom creature
  customImageArea: { flex: 1, minHeight: 0, alignItems: 'center', justifyContent: 'center', position: 'relative' },
  customPhoto: {
    width: 118,
    height: 118,
    borderRadius: 59,
    borderWidth: 2.5,
    borderColor: 'rgba(34,224,208,0.5)',
  },
  customPhotoEmpty: { backgroundColor: '#ffffff', alignItems: 'center', justifyContent: 'center', overflow: 'hidden' },
  customPhotoWrap: {
    width: 118,
    height: 118,
    borderRadius: 59,
    overflow: 'hidden',
    borderWidth: 2.5,
    borderColor: 'rgba(34,224,208,0.5)',
    shadowColor: '#6b3fa0',
    shadowOpacity: 0.25,
    shadowRadius: 12,
    shadowOffset: { width: 0, height: 10 },
  },
  customPhotoImg: { width: '100%', height: '100%' },
  customPhotoDim: { opacity: 0.6 },
  scanLine: { position: 'absolute', left: 0, right: 0, height: 24, backgroundColor: 'rgba(34,224,208,0.4)' },
  genBadge: {
    position: 'absolute',
    bottom: 10,
    alignSelf: 'center',
    backgroundColor: 'rgba(255,255,255,0.9)',
    borderWidth: 1,
    borderColor: 'rgba(34,224,208,0.5)',
    borderRadius: 999,
    paddingHorizontal: 11,
    paddingVertical: 4,
  },
  genBadgeFail: { borderColor: '#f87171' },
  genBadgeText: { color: '#0f9d90', fontFamily: candyFonts.bodyBlack, fontSize: 9, letterSpacing: 1 },
  genBadgeTextFail: { color: candyColors.danger },
  busyLabel: { color: candyColors.muted, fontFamily: candyFonts.bodyBlack, fontSize: 11, letterSpacing: 1 },
  ownSoundBadge: {
    position: 'absolute',
    bottom: 10,
    right: 12,
    flexDirection: 'row',
    alignItems: 'center',
    gap: 5,
    backgroundColor: 'rgba(255,255,255,0.9)',
    borderWidth: 1,
    borderColor: 'rgba(34,224,208,0.33)',
    borderRadius: 999,
    paddingHorizontal: 9,
    paddingVertical: 4,
  },
  soundBars: { flexDirection: 'row', alignItems: 'flex-end', gap: 2, height: 11 },
  soundBar: { width: 2, backgroundColor: candyColors.teal, borderRadius: 1 },
  ownSoundText: { color: '#0f9d90', fontFamily: candyFonts.bodyBlack, fontSize: 8, letterSpacing: 1 },

  customInfoArea: { flexShrink: 0, paddingHorizontal: 16, paddingTop: 8, paddingBottom: 10 },
  customName: { fontFamily: candyFonts.display, fontSize: 17, color: candyColors.ink, lineHeight: 20 },
  customMeta: { color: candyColors.muted, fontSize: 11, fontFamily: candyFonts.body, marginTop: 2 },
  customStatusRow: {
    marginTop: 8,
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'space-between',
  },
  deleteLabel: { color: candyColors.danger, fontFamily: candyFonts.bodyHeavy, fontSize: 11, letterSpacing: 1 },
});
