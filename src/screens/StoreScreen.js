import React, { memo, useCallback, useMemo } from 'react';
import { View, Text, StyleSheet, FlatList, useWindowDimensions } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Defs, RadialGradient, Stop, Circle } from 'react-native-svg';
import { BUTTON_VARIANTS, candyColors, candyFonts, tierOf } from '../theme/candyTheme';
import CandyBackground from '../components/candy/CandyBackground';
import CandyButton, { ButtonText, CandyPill } from '../components/candy/CandyButton';
import RoundButton, { BackGlyph } from '../components/candy/RoundButton';
import OutlinedTitle from '../components/candy/OutlinedTitle';
import { SoftPulse, CandyProgress } from '../components/candy/Decor';
import CreatureToken from '../components/candy/Tokens';
import CreatureThumbnail from '../components/CreatureThumbnail';
import { STALLS, TIER_ORDER, StallTop, StallRow, StallBottom, TOP_H, ROW_H, BOTTOM_H, GOODS_H, POSTS_IN_TOP, goodsWidth } from '../components/shop/Stall';
import { isUnlockable, tokenCount, tokenPrice } from '../economy';
import AdStrip from '../components/AdStrip';

// The Key Shop sells a creature's *key*, not the creature itself — redeeming
// it is the hold-to-unlock gesture on the Home card (CreatureCard). Every
// creature shows the two ways to the key (src/economy.js): its own tokens so
// far (a full set, from Mystery Boxes, puts the key on its card by itself),
// and a $0.99 button. Coins don't buy keys (they buy Mystery Boxes). Ones
// already settled show ★ OWNED or KEY READY instead.
//
// The creatures are laid out in market stalls, one per rarity
// (src/components/shop/Stall.js), two to a shelf; a rarity with a single
// creature shows it as one wide showcase.
//
// Opened from a locked creature's popup (SHOP), it opens on that creature's
// shelf (`focusId`), and the creature breathes gently so it's easy to spot.
//
// The list is a FlatList of fixed-height pieces (a stall's top, each shelf,
// its counter): the goods are heavy (the creature's art, its token, candy
// buttons) and building them all at once held the screen up for over 2 s on
// the emulator. Only the pieces in view are built first — starting at the
// focused shelf — and the rest as the list scrolls.

const LIST_PAD = 12;
const SHELF_GAP = 10;

// A stall's pieces, in order, with the y each one starts at inside its
// stall (the posts' stripes and the wall's dots continue from it).
function buildPieces(items) {
  const pieces = [];
  TIER_ORDER.forEach((tier) => {
    const goods = items.filter((c) => tierOf(c.id) === tier);
    if (!goods.length) return;
    pieces.push({ key: `${tier}:top`, kind: 'top', tier });
    let phase = POSTS_IN_TOP;
    for (let i = 0; i < goods.length; i += 2) {
      pieces.push({ key: `${tier}:${i}`, kind: 'row', tier, goods: goods.slice(i, i + 2), wide: goods.length === 1, phase });
      phase += ROW_H;
    }
    pieces.push({ key: `${tier}:bottom`, kind: 'bottom', tier, goods, phase });
  });
  return pieces;
}

const HEIGHTS = { top: TOP_H, row: ROW_H, bottom: BOTTOM_H };

// The token count, its bar, and the $0.99 button — or the settled pill.
function Ways({ creature, stall, wide, owned, hasKey, have, moneyPrice, buying, onBuyNow }) {
  if (owned || hasKey) {
    return (
      <View style={[styles.settled, wide && styles.settledWide]}>
        {owned ? (
          <CandyPill variant="purple" label="★ OWNED" fontSize={12} padV={4} padH={12} />
        ) : (
          <CandyPill variant="gold" label="KEY READY" fontSize={12} padV={4} padH={12} />
        )}
      </View>
    );
  }
  const need = tokenPrice(creature.id);
  return (
    <>
      <View style={styles.tokenRow}>
        <CreatureToken creature={creature} size={20} />
        <Text style={[styles.tokenText, { color: stall.ring }]}>{`${have.toLocaleString()}/${need.toLocaleString()}`}</Text>
        <CandyProgress pct={(have / need) * 100} height={11} ring={stall.ring} style={styles.bar} />
      </View>
      <CandyButton variant="blue" size="xs" loading={buying} onPress={() => onBuyNow(creature)} faceStyle={styles.buyFace}>
        <ButtonText ring={BUTTON_VARIANTS.blue.ring} size={13}>
          {moneyPrice}
        </ButtonText>
      </CandyButton>
    </>
  );
}

// A soft glow in the stall's colour behind the creature.
const Spotlight = memo(function Spotlight({ color, size }) {
  const r = size / 2;
  return (
    <Svg width={size} height={size} style={styles.spot}>
      <Defs>
        <RadialGradient id="goodsSpot" cx={r} cy={r} r={r} gradientUnits="userSpaceOnUse">
          <Stop offset="0" stopColor={color} stopOpacity={0.75} />
          <Stop offset="0.55" stopColor={color} stopOpacity={0.3} />
          <Stop offset="1" stopColor={color} stopOpacity={0} />
        </RadialGradient>
      </Defs>
      <Circle cx={r} cy={r} r={r} fill="url(#goodsSpot)" />
    </Svg>
  );
});

// One creature on a shelf: a candy display box in its stall's colours.
const Goods = memo(function Goods({ creature, tier, width, wide, owned, hasKey, have, moneyPrice, buying, focused, onBuyNow }) {
  const stall = STALLS[tier];
  const art = wide ? 96 : 58;
  const ways = <Ways creature={creature} stall={stall} wide={wide} owned={owned} hasKey={hasKey} have={have} moneyPrice={moneyPrice} buying={buying} onBuyNow={onBuyNow} />;
  const name = (
    <Text style={[styles.name, wide && styles.nameWide]} numberOfLines={1}>
      {creature.name}
    </Text>
  );
  return (
    <SoftPulse active={focused} to={1.04} style={[styles.goodsRing, { width, backgroundColor: stall.ring }]}>
      <View style={styles.goodsRim}>
        <LinearGradient colors={['#ffffff', stall.tint]} locations={[0.35, 1]} style={[styles.goodsFace, wide && styles.goodsFaceWide]}>
          <View style={[styles.artBox, wide && styles.artBoxWide]}>
            <Spotlight color={stall.glow} size={wide ? 132 : 88} />
            <CreatureThumbnail creature={creature} size={art} mood="idle" glow={false} />
          </View>
          {wide ? (
            <View style={styles.wideInfo}>
              {name}
              {ways}
            </View>
          ) : (
            <>
              {name}
              {ways}
            </>
          )}
        </LinearGradient>
      </View>
    </SoftPulse>
  );
});

export default function StoreScreen({
  creatures = [],
  profile,
  onBuyNow,
  moneyPrice = '',
  buyingId = null,
  focusId = null,
  onBack,
}) {
  const insets = useSafeAreaInsets();
  const { width: screenW } = useWindowDimensions();
  const stallW = Math.min(screenW, 520) - LIST_PAD * 2;
  const shelfW = goodsWidth(stallW);
  const goodsW = Math.floor((shelfW - SHELF_GAP) / 2);
  const adsFree = !!profile?.adsFree;
  const items = useMemo(() => creatures.filter(isUnlockable), [creatures]);
  const pieces = useMemo(() => buildPieces(items), [items]);
  const offsets = useMemo(() => {
    let y = 0;
    return pieces.map((p) => {
      const at = y;
      y += HEIGHTS[p.kind];
      return at;
    });
  }, [pieces]);
  const ownedIds = profile?.ownedIds;
  const keys = profile?.keys;
  // Opens with the focused creature's shelf second from the top (under the
  // awning, or under the shelf above it). Fixed at mount: FlatList only
  // reads it once.
  const [initialIndex] = React.useState(() => {
    const at = pieces.findIndex((p) => p.kind === 'row' && p.goods.some((c) => c.id === focusId));
    return at > 0 ? at - 1 : 0;
  });

  const getItemLayout = useCallback((_, index) => ({ length: HEIGHTS[pieces[index].kind], offset: offsets[index], index }), [pieces, offsets]);

  const renderItem = useCallback(
    ({ item: piece }) => {
      if (piece.kind === 'top') return <StallTop tier={piece.tier} width={stallW} />;
      if (piece.kind === 'bottom') {
        const owned = piece.goods.filter((c) => ownedIds?.includes(c.id)).length;
        return <StallBottom tier={piece.tier} width={stallW} phase={piece.phase} owned={owned} total={piece.goods.length} />;
      }
      return (
        <StallRow tier={piece.tier} width={stallW} phase={piece.phase}>
          {piece.goods.map((creature) => (
            <Goods
              key={creature.id}
              creature={creature}
              tier={piece.tier}
              width={piece.wide ? shelfW : goodsW}
              wide={piece.wide}
              owned={!!ownedIds?.includes(creature.id)}
              hasKey={keys?.[creature.id] === true}
              have={tokenCount(profile, creature.id)}
              moneyPrice={moneyPrice}
              buying={buyingId === creature.id}
              focused={creature.id === focusId}
              onBuyNow={onBuyNow}
            />
          ))}
        </StallRow>
      );
    },
    [stallW, shelfW, goodsW, ownedIds, keys, profile, moneyPrice, buyingId, focusId, onBuyNow]
  );

  return (
    <CandyBackground style={{ paddingTop: insets.top }}>
      <View style={styles.header}>
        <RoundButton size={36} onPress={onBack}>
          <BackGlyph />
        </RoundButton>
        <OutlinedTitle text="KEY SHOP" fill="pink" size={20} outline={3} ring={2} drop={5} />
      </View>

      <FlatList
        data={pieces}
        keyExtractor={keyOf}
        renderItem={renderItem}
        getItemLayout={getItemLayout}
        initialScrollIndex={initialIndex > 0 ? initialIndex : undefined}
        initialNumToRender={5}
        maxToRenderPerBatch={3}
        windowSize={5}
        contentContainerStyle={[styles.listContent, { paddingBottom: adsFree ? insets.bottom + 20 : 20 }]}
      />
      {/* the ad strip along the bottom, as on Home (none with Remove Ads) */}
      {adsFree ? null : <AdStrip />}
    </CandyBackground>
  );
}

const keyOf = (p) => p.key;

const styles = StyleSheet.create({
  header: { flexDirection: 'row', alignItems: 'center', gap: 8, paddingHorizontal: 16, paddingTop: 12, paddingBottom: 2 },
  listContent: { paddingHorizontal: LIST_PAD, alignItems: 'center' },

  goodsRing: {
    height: GOODS_H,
    borderRadius: 20,
    padding: 2,
    shadowColor: '#320064',
    shadowOffset: { width: 0, height: 4 },
    shadowOpacity: 0.3,
    shadowRadius: 5,
    elevation: 4,
  },
  goodsRim: { flex: 1, borderRadius: 18, borderWidth: 2.5, borderColor: '#ffffff', overflow: 'hidden' },
  goodsFace: { flex: 1, alignItems: 'stretch', justifyContent: 'space-between', paddingHorizontal: 8, paddingTop: 4, paddingBottom: 6 },
  goodsFaceWide: { flexDirection: 'row', alignItems: 'center', paddingHorizontal: 10, gap: 10 },
  artBox: { height: 64, alignItems: 'center', justifyContent: 'center' },
  artBoxWide: { width: 118, height: 118 },
  spot: { position: 'absolute' },
  wideInfo: { flex: 1, gap: 8 },
  name: { color: candyColors.ink, fontFamily: candyFonts.display, fontSize: 15, textAlign: 'center' },
  nameWide: { fontSize: 19, textAlign: 'left' },
  tokenRow: { flexDirection: 'row', alignItems: 'center', gap: 5 },
  tokenText: { fontFamily: candyFonts.display, fontSize: 12, letterSpacing: 0.3 },
  bar: { flex: 1 },
  buyFace: { paddingHorizontal: 4 },
  settled: { height: 58, alignItems: 'center', justifyContent: 'center' },
  settledWide: { height: 'auto', alignItems: 'flex-start' },
});
