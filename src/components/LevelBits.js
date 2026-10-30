import React, { memo, useEffect, useRef } from 'react';
import { Animated, Image, StyleSheet, Text, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import Pressable from './Pressable';
import OutlinedTitle from './candy/OutlinedTitle';
import { RaysSpin } from './candy/Decor';
import { BtnText, CandyBtn, F, GOLD, GOLD_RING, Ringed } from '../squad/ui';
import GCHEST from '../squad/groupChestArt';
import { COIN, GEM } from '../squad/currencyArt';
import { CHEST_NAME } from '../playerXp';
import { fmtNum } from '../format';

// The player level's pieces (PLAYER_XP.md): a level road prize's art, the
// lobby's LV chip, and the LEVEL UP card App shows when the level rises.

// "1,200 coins", "50 gems", "Rare chest"
export const prizeLabel = (r) => (!r ? '' : r.k === 'coins' ? `${fmtNum(r.n)} coins` : r.k === 'gems' ? `${fmtNum(r.n)} gems` : `${CHEST_NAME[r.t] || ''} chest`);

// A prize's picture: a coin or gem (one of the six stamped ones, by `i`),
// or the chest of its size in `group`'s art (the group its chest opens in).
export const PrizeArt = memo(function PrizeArt({ r, group, i = 0, size = 44, dim }) {
  const op = dim ? { opacity: 0.45 } : null;
  if (!r) return <View style={{ width: size, height: size }} />;
  if (r.k === 'chest') {
    // the art is 480 × 400 with the chest about half its width: drawn
    // bigger, spilling over its `size` box
    const art = (GCHEST[group] || GCHEST.snack)[`${r.t}-grow`];
    const w = size * 2;
    const h = (w * 400) / 480;
    return <Image source={art} style={[{ width: w, height: h, marginHorizontal: (size - w) / 2, marginVertical: (size - h) / 2 }, op]} resizeMode="contain" fadeDuration={0} />;
  }
  return <Image source={r.k === 'gems' ? GEM[i % 6] : COIN[i % 6]} style={[{ width: size, height: size }, op]} fadeDuration={0} />;
});

// The LV chip: the level on a gold disc beside its XP bar, with a red count
// of the road's prizes waiting. Opens the level road.
export const LevelChip = memo(function LevelChip({ level, into, need, waiting = 0, onPress }) {
  const pct = Math.max(4, Math.min(100, Math.round((into / Math.max(1, need)) * 100)));
  return (
    <Pressable onPress={onPress} hitSlop={6}>
      <Ringed ring={GOLD_RING} lip={3} ringW={2} border={2.5} innerStyle={styles.chip}>
        <LinearGradient colors={GOLD} locations={[0, 0.5, 1]} style={styles.disc}>
          <Text style={styles.discText} numberOfLines={1} adjustsFontSizeToFit>
            {level}
          </Text>
        </LinearGradient>
        <View style={styles.chipCol}>
          <Text style={styles.chipLabel}>LEVEL</Text>
          <View style={styles.track}>
            <LinearGradient colors={['#ffb3e0', '#c02bd9']} start={{ x: 0, y: 0 }} end={{ x: 1, y: 0 }} style={[styles.fill, { width: `${pct}%` }]} />
          </View>
        </View>
      </Ringed>
      {waiting ? (
        <View style={styles.dot} pointerEvents="none">
          <Text style={styles.dotText}>{waiting > 9 ? '9+' : waiting}</Text>
        </View>
      ) : null}
    </Pressable>
  );
});

// LEVEL UP: rays, the new level on a big gold disc, and what it brought: the
// road's prize (`prize`; `more` other prizes waiting too), or nothing past
// the road's end. COLLECT goes to the road to claim them; LATER keeps them there.
export function LevelUpCard({ level, prize, more = 0, group, onCollect, onLater }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    Animated.spring(t, { toValue: 1, friction: 6, tension: 80, useNativeDriver: true }).start();
  }, [t]);
  const scale = t.interpolate({ inputRange: [0, 1], outputRange: [0.6, 1] });
  return (
    <View style={StyleSheet.absoluteFill}>
      <Animated.View style={[StyleSheet.absoluteFill, styles.scrim, { opacity: t }]} />
      <View style={styles.center} pointerEvents="box-none">
        <Animated.View style={[styles.cardWrap, { opacity: t, transform: [{ scale }] }]}>
          <Ringed ring="#45189a" lip={6} colors={['#c58bff', '#8f3cf2', '#5a1fb0']} radius={26} innerStyle={styles.card}>
            <OutlinedTitle text="LEVEL UP!" size={34} fill="gold" />
            <View style={styles.discAt}>
              <View style={styles.rays} pointerEvents="none">
                <RaysSpin size={RAYS} color="#ffe45c" opacity={0.55} />
              </View>
              <LinearGradient colors={GOLD} locations={[0, 0.5, 1]} style={styles.bigDisc}>
                <Text style={styles.bigNum} numberOfLines={1} adjustsFontSizeToFit>
                  {level}
                </Text>
              </LinearGradient>
            </View>
            {prize ? (
              <>
                <Text style={styles.kicker}>YOUR PRIZE</Text>
                <View style={styles.prizeRow}>
                  <PrizeArt r={prize} group={group} i={level} size={52} />
                  <Text style={styles.prizeText}>{prizeLabel(prize)}</Text>
                </View>
                {more ? <Text style={styles.more}>{`+ ${more} more ${more > 1 ? 'prizes' : 'prize'} on your level road`}</Text> : null}
                <CandyBtn kind="gold" padV={9} padH={30} lip={5} onPress={onCollect} style={styles.btn}>
                  <BtnText ring={GOLD_RING} size={20}>
                    COLLECT
                  </BtnText>
                </CandyBtn>
                <Pressable onPress={onLater} hitSlop={10}>
                  <Text style={styles.later}>LATER</Text>
                </Pressable>
              </>
            ) : (
              <>
                <Text style={styles.more}>{more ? `${more} ${more > 1 ? 'prizes wait' : 'prize waits'} on your level road` : 'Every level counts toward your trophies'}</Text>
                <CandyBtn kind="gold" padV={9} padH={30} lip={5} onPress={more ? onCollect : onLater} style={styles.btn}>
                  <BtnText ring={GOLD_RING} size={20}>
                    {more ? 'COLLECT' : 'NICE!'}
                  </BtnText>
                </CandyBtn>
              </>
            )}
          </Ringed>
        </Animated.View>
      </View>
    </View>
  );
}

const DISC = 96;
const RAYS = 300; // round the disc

const styles = StyleSheet.create({
  chip: { flexDirection: 'row', alignItems: 'center', gap: 6, paddingLeft: 3, paddingRight: 9, paddingVertical: 3 },
  disc: { width: 22, height: 22, borderRadius: 11, alignItems: 'center', justifyContent: 'center', borderWidth: 1.5, borderColor: '#ffffff' },
  discText: { fontFamily: F.display, fontSize: 11.5, color: '#7a3d00', includeFontPadding: false, paddingHorizontal: 1 },
  chipCol: { gap: 2 },
  chipLabel: { fontFamily: F.black, fontSize: 8.5, color: '#b86200', includeFontPadding: false, letterSpacing: 0.4 },
  track: { width: 46, height: 7, borderRadius: 4, backgroundColor: '#f3e4fb', overflow: 'hidden' },
  fill: { height: '100%', borderRadius: 4 },
  dot: { position: 'absolute', top: -6, right: -6, minWidth: 18, height: 18, borderRadius: 9, paddingHorizontal: 4, backgroundColor: '#ff3d5a', borderWidth: 2, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  dotText: { fontFamily: F.black, fontSize: 9.5, color: '#ffffff', includeFontPadding: false },
  scrim: { backgroundColor: 'rgba(40,8,80,0.6)' },
  center: { ...StyleSheet.absoluteFillObject, alignItems: 'center', justifyContent: 'center', paddingHorizontal: 28 },
  cardWrap: { width: '100%', maxWidth: 340 },
  card: { alignItems: 'center', paddingTop: 22, paddingBottom: 16, paddingHorizontal: 18, gap: 8, overflow: 'hidden' },
  discAt: { width: DISC, height: DISC, marginVertical: 4 },
  rays: { position: 'absolute', left: (DISC - RAYS) / 2, top: (DISC - RAYS) / 2, width: RAYS, height: RAYS },
  bigDisc: { width: DISC, height: DISC, borderRadius: DISC / 2, alignItems: 'center', justifyContent: 'center', borderWidth: 4, borderColor: '#ffffff' },
  bigNum: { fontFamily: F.display, fontSize: 46, color: '#7a3d00', includeFontPadding: false, paddingHorizontal: 6 },
  kicker: { fontFamily: F.black, fontSize: 11, color: '#f0dcff', letterSpacing: 1 },
  prizeRow: { flexDirection: 'row', alignItems: 'center', gap: 10, backgroundColor: 'rgba(255,255,255,0.18)', borderRadius: 16, paddingHorizontal: 14, paddingVertical: 6 },
  prizeText: { fontFamily: F.display, fontSize: 20, color: '#ffffff' },
  more: { fontFamily: F.heavy, fontSize: 12.5, color: '#f0dcff', textAlign: 'center' },
  btn: { marginTop: 6 },
  later: { fontFamily: F.black, fontSize: 12.5, color: '#e6d2ff', paddingTop: 4, letterSpacing: 0.5 },
});
