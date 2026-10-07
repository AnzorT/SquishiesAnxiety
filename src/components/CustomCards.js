import React, { memo, useEffect, useRef, useState } from 'react';
import { View, Text, Image, Pressable, StyleSheet, Animated, Easing } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Defs, RadialGradient, Stop, Circle } from 'react-native-svg';
import { BUTTON_VARIANTS, candyColors, candyFonts } from '../theme/candyTheme';
import AssembleCreature from './AssembleCreature';
import { CandyCard, CandyProgress, Pedestal, RaysSpin, SoftPulse, TierChip } from './candy/Decor';
import { ButtonText, CandyPill, Shine } from './candy/CandyButton';
import ShineSweep from './candy/ShineSweep';
import ShadowText from './candy/ShadowText';
import OutlinedTitle from './candy/OutlinedTitle';
import RoundButton, { TrashIcon } from './candy/RoundButton';
import { ImageBackdrop } from './CreatureCard';
import { CARD_SIZE } from './CardPager';

// The two card types on Home's "MY CREATURES" tab, in the v3 candy card: the
// dashed-rim "Create your own squishy" card (always at index 0) and a card
// per custom creature the player has made.

// --- "Create your own squishy" -------------------------------------------

// The free creations the player still has, as a blue candy pill (the old
// flat teal outline didn't belong with the candy look): a gold ball with the
// count, "FREE CREATION", gloss, a light streak and a gentle breath.
function FreeCreationPill({ count, paid = false }) {
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
              {paid ? (count === 1 ? 'CREATION READY' : 'CREATIONS READY') : count === 1 ? 'FREE CREATION' : 'FREE CREATIONS'}
            </ButtonText>
          </LinearGradient>
        </View>
      </View>
    </SoftPulse>
  );
}

// `paidCredits`: how many of the credits were bought — shown as READY, not FREE.
// `style`: the card's box, when a wrapper already has the card's size (the
// tutorial's target around it — CARD_SIZE's percentages would otherwise
// shrink against the wrapper)
export const CreateOwnCard = memo(function CreateOwnCard({ onPress, generationCredits = 0, paidCredits = 0, priceLabel = '$4.99', discountPct = 0, style }) {
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
    <Pressable style={[styles.cardShell, style]} onPress={onPress}>
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
          <FreeCreationPill count={generationCredits} paid={paidCredits > 0} />
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
// Laid out like the premade CreatureCard: the pink dotted backdrop under
// slowly spinning rays, the creature on the gold pedestal, its name as a pink
// sticker title with a MY CREATION chip, and a candy status row.
//
// `status`: 'pending' | 'running' (Tripo working, `progress` 0–100) |
// 'ready' | 'failed'. Assemble-path creatures are always 'ready' with a
// `build`; photo-path creatures show their picture in a round candy frame —
// while the 3D model is built, a white-and-pink shine sweeps down it and a
// progress bar fills under it.

const MINE_CHIP = { label: 'MY CREATION', bg: ['#ffd6f4', '#e6c8ff'], color: '#4a1a73' };

// A soft white-to-pink band sweeping down the picture, over and over.
function ScanShine({ size }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(t, { toValue: 1, duration: 1400, easing: Easing.inOut(Easing.quad), useNativeDriver: true }),
        Animated.delay(250),
      ])
    );
    loop.start();
    return () => loop.stop();
  }, [t]);
  const band = size * 0.42;
  const translateY = t.interpolate({ inputRange: [0, 1], outputRange: [-band, size] });
  return (
    <Animated.View pointerEvents="none" style={[styles.scan, { height: band, transform: [{ translateY }] }]}>
      <LinearGradient
        colors={['rgba(255,255,255,0)', 'rgba(255,214,244,0.55)', 'rgba(255,255,255,0.95)', 'rgba(255,143,216,0.5)', 'rgba(255,255,255,0)']}
        locations={[0, 0.35, 0.55, 0.7, 1]}
        style={StyleSheet.absoluteFill}
      />
    </Animated.View>
  );
}

// The picture in a round candy frame: violet ring, white rim, gloss on top.
export function PhotoBadge({ uri, size, busy = false, dim = false }) {
  const inner = size - 2 * (FRAME_RING + FRAME_RIM);
  return (
    <View style={{ width: size, height: size + FRAME_LIP }}>
      <View style={[styles.frameLip, { width: size, height: size, borderRadius: size / 2, top: FRAME_LIP }]} />
      <View style={[styles.frameRing, { width: size, height: size, borderRadius: size / 2 }]}>
        <View style={[styles.frameRim, { borderRadius: size / 2 }]}>
          {uri ? <Image source={{ uri }} style={{ width: inner, height: inner, opacity: dim ? 0.55 : 1 }} /> : null}
          {busy ? <ScanShine size={inner} /> : null}
          <Shine inset="14%" height="34%" />
        </View>
      </View>
    </View>
  );
}

// The custom creature's art, bobbing gently like the premade ones' idle mood.
export function CustomArt({ creature, size, busy, dim }) {
  const bob = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    if (busy || dim) return undefined;
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(bob, { toValue: 1, duration: 1300, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
        Animated.timing(bob, { toValue: 0, duration: 1300, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
      ])
    );
    loop.start();
    return () => {
      loop.stop();
      bob.setValue(0);
    };
  }, [bob, busy, dim]);
  const translateY = bob.interpolate({ inputRange: [0, 1], outputRange: [0, -size * 0.05] });
  let art = null;
  if (creature.build) art = <AssembleCreature build={creature.build} size={size} />;
  else if (creature.sourceImageUrl) art = <PhotoBadge uri={creature.sourceImageUrl} size={size * 0.92} busy={busy} dim={dim} />;
  return <Animated.View style={[styles.artWrap, { width: size, height: size, transform: [{ translateY }] }]}>{art}</Animated.View>;
}

// Glass pill over the bottom of the picture: what's happening, and for a
// build in progress, how far along it is.
function StatusGlass({ label, progress }) {
  return (
    <View style={styles.glass} pointerEvents="none">
      <ShadowText style={styles.glassLabel} shadows={GLASS_LABEL_SHADOWS} numberOfLines={1}>
        {label}
      </ShadowText>
      {progress != null ? (
        <CandyProgress pct={Math.max(4, progress)} height={10} ring={candyColors.pinkRing} fill={['#ffa8e6', '#ff4fbf']} style={styles.glassBar} />
      ) : null}
    </View>
  );
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
  const [imgBox, setImgBox] = useState({ w: 0, h: 0 });

  // the premade card's creature size; smaller while a status pill sits below
  const full = imgBox.h ? Math.max(60, Math.min(170, imgBox.h - 34, imgBox.w * 0.8)) : 0;
  const body = busy || failed ? Math.max(60, Math.min(full, imgBox.h - 110)) : full;

  const meta = busy
    ? 'Building your 3D squishy — about a minute'
    : failed
    ? creature.error || 'Something went wrong'
    : `Made ${creature.created}${creature.audio ? ' · with its own squish sound' : ''}`;

  return (
    <View style={styles.cardShell}>
      <CandyCard style={styles.card}>
        <Pressable style={styles.cardBody} onPress={busy || failed ? undefined : onPlay}>
          <View style={styles.imageArea} onLayout={(e) => setImgBox({ w: e.nativeEvent.layout.width, h: e.nativeEvent.layout.height })}>
            <ImageBackdrop />
            <RaysSpin size={260} />
            {body > 0 ? (
              <View style={[{ width: body, height: body }, busy || failed ? styles.artRaised : styles.artCentred]}>
                <View style={[styles.pedestalWrap, { top: body - 14 }]}>
                  <Pedestal width={body * 1.2} height={20} />
                </View>
                <CustomArt creature={creature} size={body} busy={busy} dim={busy || failed} />
              </View>
            ) : null}
            {busy ? (
              <StatusGlass label={`BUILDING IN 3D · ${progress}%`} progress={progress} />
            ) : failed ? (
              <StatusGlass label="COULDN'T BUILD IT" />
            ) : null}
          </View>

          <View style={styles.infoArea}>
            <View style={styles.nameRow}>
              <OutlinedTitle text={creature.name} fill="pink" size={21} outline={2} ring={1.5} drop={3} letterSpacing={0} style={styles.nameTitle} />
              <TierChip look={MINE_CHIP} pulse={false} />
            </View>
            <Text style={styles.cardDesc} numberOfLines={1} ellipsizeMode="tail">
              {meta}
            </Text>
            <View style={styles.statusRow}>
              <RoundButton size={30} lip={3} onPress={onDelete} hitSlop={8}>
                <TrashIcon />
              </RoundButton>
              {busy ? (
                <CandyPill variant="grey" label="PLEASE WAIT…" fontSize={12} padV={4} padH={12} letterSpacing={0.6} />
              ) : failed ? (
                <Pressable onPress={onRetry} hitSlop={8}>
                  <CandyPill variant="gold" label="RETRY ↻" pulse fontSize={13} padV={5} padH={16} letterSpacing={0.8} />
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

const FRAME_RING = 2.5;
const FRAME_RIM = 4;
const FRAME_LIP = 5;
// white caption outlined all round plus a drop, like HOLD TO UNLOCK
const GLASS_LABEL_SHADOWS = [
  [1.5, 0, '#45189a'],
  [-1.5, 0, '#45189a'],
  [0, 1.5, '#45189a'],
  [0, -1.5, '#45189a'],
  [0, 2.5, '#45189a'],
];

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

  // custom creature — the premade card's layout (see CreatureCard.js)
  imageArea: {
    flex: 1,
    minHeight: 0,
    overflow: 'hidden',
    alignItems: 'center',
    justifyContent: 'center',
    borderTopLeftRadius: 24,
    borderTopRightRadius: 24,
    borderBottomLeftRadius: 16,
    borderBottomRightRadius: 16,
    borderWidth: 2,
    borderColor: 'rgba(255,255,255,0.8)',
  },
  artCentred: { marginTop: -6 },
  artRaised: { marginBottom: 64 },
  artWrap: { alignItems: 'center', justifyContent: 'center' },
  pedestalWrap: { position: 'absolute', left: -100, right: -100, alignItems: 'center' },
  frameLip: { position: 'absolute', left: 0, backgroundColor: '#6a1b9a' },
  frameRing: { position: 'absolute', top: 0, left: 0, padding: FRAME_RING, backgroundColor: candyColors.cardRing },
  frameRim: { flex: 1, borderWidth: FRAME_RIM, borderColor: '#ffffff', overflow: 'hidden', backgroundColor: '#ffffff' },
  scan: { position: 'absolute', left: 0, right: 0, top: 0 },
  glass: {
    position: 'absolute',
    bottom: 12,
    left: 16,
    right: 16,
    alignItems: 'center',
    gap: 6,
    borderRadius: 18,
    backgroundColor: candyColors.glass,
    borderWidth: 2,
    borderColor: 'rgba(255,255,255,0.7)',
    paddingVertical: 8,
    paddingHorizontal: 14,
  },
  glassLabel: { color: '#ffffff', fontFamily: candyFonts.display, fontSize: 14, letterSpacing: 0.8, includeFontPadding: false },
  glassBar: { alignSelf: 'stretch' },

  // The sticker title's SVG carries its own outline margin — pulled back as
  // on the premade card.
  infoArea: { paddingHorizontal: 14, paddingTop: 2, paddingBottom: 8 },
  nameRow: { flexDirection: 'row', alignItems: 'center', gap: 4.5 },
  nameTitle: { marginLeft: -3.5, marginTop: -2, marginBottom: -5, flexShrink: 1 },
  cardDesc: { color: candyColors.muted, fontSize: 11, fontFamily: candyFonts.body, marginTop: 2, lineHeight: 14 },
  statusRow: {
    marginTop: 4,
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'space-between',
  },
});
