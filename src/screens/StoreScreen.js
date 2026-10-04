import React, { memo, useCallback, useMemo } from 'react';
import { View, Text, StyleSheet, FlatList, useWindowDimensions } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { LinearGradient } from 'expo-linear-gradient';
import { BUTTON_VARIANTS, TIERS, candyFonts, tierOf } from '../theme/candyTheme';
import CandyBackground from '../components/candy/CandyBackground';
import CandyButton, { ButtonText } from '../components/candy/CandyButton';
import RoundButton, { BackGlyph } from '../components/candy/RoundButton';
import OutlinedTitle from '../components/candy/OutlinedTitle';
import { SoftPulse } from '../components/candy/Decor';
import { CoinPill } from '../components/candy/Coin';
import CreatureToken from '../components/candy/Tokens';
import CreatureThumbnail from '../components/CreatureThumbnail';
import { TIER_ORDER, StallTop, StallRow, StallBottom, OnShelf, GoldKey, CardGlow, TOP_H, ROW_H, BOTTOM_H, CARD_H, cardWidth, stallSpan } from '../components/shop/Stall';
import NextUp, { NEXT_UP_H } from '../components/shop/NextUp';
import { isUnlockable, tokenCount, tokenPrice } from '../economy';
import AdStrip from '../components/AdStrip';
import TutTarget from '../tutorial/Target';

// The Key Shop sells a creature's *key*, not the creature itself — redeeming
// it is the hold-to-unlock gesture on the Home card (CreatureCard). Every
// creature shows the two ways to the key (src/economy.js): its own tokens so
// far (a full set, from Mystery Boxes, puts the key on its card by itself),
// and the key's price button. Coins don't buy keys (they buy Mystery Boxes).
// Ones already settled show ★ OWNED or KEY READY instead.
//
// Laid out as the v3 design's Key Shop: the coins up top, the NEXT UP banner
// (src/components/shop/NextUp.js), then one stall per rarity
// (src/components/shop/Stall.js — "Common Corner", "Rare Boutique"…), two
// creature cards to a shelf.
//
// Opened from a locked creature's popup (SHOP), it opens on that creature's
// shelf (`focusId`), and the creature breathes gently so it's easy to spot.
//
// The list is a FlatList of fixed-height pieces (the banner, a stall's top,
// each row, its bottom): the cards are heavy (the creature's art, its token,
// candy buttons) and building them all at once held the screen up for over
// 2 s on the emulator. Only the pieces in view are built first — starting at
// the focused row — and the rest as the list scrolls.

const LIST_PAD = 16;

// The stalls' pieces, in order. `at`: where a row/bottom starts in its
// stall (from the top piece's top), `span` the stall's height — for the
// wall's gradient.
function buildPieces(items, next, ownedIds) {
  const pieces = [];
  if (next) pieces.push({ key: 'next', kind: 'next', creature: next });
  TIER_ORDER.forEach((tier) => {
    const goods = items.filter((c) => tierOf(c.id) === tier);
    if (!goods.length) return;
    const span = stallSpan(Math.ceil(goods.length / 2));
    const owned = goods.filter((c) => ownedIds?.includes(c.id)).length;
    pieces.push({ key: `${tier}:top`, kind: 'top', tier, span, count: `${owned}/${goods.length}` });
    let at = TOP_H;
    for (let i = 0; i < goods.length; i += 2) {
      pieces.push({ key: `${tier}:${i}`, kind: 'row', tier, goods: goods.slice(i, i + 2), at, span });
      at += ROW_H;
    }
    pieces.push({ key: `${tier}:bottom`, kind: 'bottom', tier, at, span });
  });
  return pieces;
}

const HEIGHTS = { next: NEXT_UP_H + 6, top: TOP_H, row: ROW_H, bottom: BOTTOM_H };

// the card's chip, top right: ★ OWNED, or READY (its key is waiting)
function StateChip({ owned }) {
  const v = owned ? { colors: ['#e6b8ff', '#7a2ff0'], ring: '#45189a', ink: '#ffffff', label: '★ OWNED' } : { colors: ['#fff7b0', '#ff9c0a'], ring: '#9c4d06', ink: '#7a3a00', label: 'READY' };
  return (
    <View style={[styles.chipRing, { backgroundColor: v.ring }]}>
      <LinearGradient colors={v.colors} style={styles.chipFace}>
        <Text style={[styles.chipText, { color: v.ink }]}>{v.label}</Text>
      </LinearGradient>
    </View>
  );
}

// One creature — the design's store card: the creature on a glow in its
// rarity's colour with the gold key, a strip of the rarity's colour, its
// name, the button and its tokens so far.
const Goods = memo(function Goods({ creature, tier, width, owned, hasKey, have, moneyPrice, buying, focused, onBuyNow }) {
  const t = TIERS[tier];
  const need = tokenPrice(creature.id);
  const inner = width - 11; // inside the ring and the rim
  let button;
  if (owned) button = <CandyButton variant="purple" size="shop" label="★ OWNED" disabled style={styles.buyWrap} />;
  else if (hasKey) button = <CandyButton variant="gold" size="shop" label="KEY READY" disabled style={styles.buyWrap} />;
  else
    button = (
      <CandyButton variant="pink" size="shop" pulse="soft" loading={buying} onPress={() => onBuyNow(creature)} style={styles.buyWrap}>
        <ButtonText ring={BUTTON_VARIANTS.pink.ring} size={14}>
          {`KEY · ${moneyPrice}`}
        </ButtonText>
      </CandyButton>
    );
  return (
    <SoftPulse active={focused} to={1.04}>
      <View style={[styles.cardRing, { width, opacity: owned ? 0.72 : 1 }]}>
        <View style={styles.cardRim}>
          <LinearGradient colors={['#fff6fd', '#ffe6f7']} style={styles.cardFace}>
            <View style={styles.art}>
              <CardGlow width={inner} height={112} glow={t.glow} />
              <CreatureThumbnail creature={creature} size={78} mood="cycle" />
              <View style={styles.key}>
                <GoldKey width={30} />
              </View>
              {owned || hasKey ? (
                <View style={styles.chipAt}>
                  <StateChip owned={owned} />
                </View>
              ) : null}
            </View>
            <LinearGradient colors={t.bg.length > 1 ? t.bg : [t.bg[0], t.bg[0]]} start={{ x: 0, y: 0 }} end={{ x: 1, y: 0 }} style={styles.divider} />
            <View style={styles.info}>
              <Text style={styles.name} numberOfLines={1}>
                {creature.name}
              </Text>
              {button}
              <View style={styles.tokenLine}>
                {owned || hasKey ? null : (
                  <>
                    <CreatureToken creature={creature} size={12} />
                    <Text style={styles.tokenText}>{`${Math.min(have, need)}/${need} tokens`}</Text>
                    {need > have ? <Text style={styles.needText}>{`${need - have} more`}</Text> : null}
                  </>
                )}
              </View>
            </View>
          </LinearGradient>
        </View>
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
  const cardW = cardWidth(stallW);
  const adsFree = !!profile?.adsFree;
  const items = useMemo(() => creatures.filter(isUnlockable), [creatures]);
  const ownedIds = profile?.ownedIds;
  const keys = profile?.keys;
  // the first locked one without its key: NEXT UP, and what the tutorial's
  // "keys unlock creatures" points at
  const next = useMemo(() => items.find((c) => !ownedIds?.includes(c.id) && keys?.[c.id] !== true) || null, [items, ownedIds, keys]);
  const pieces = useMemo(() => buildPieces(items, next, ownedIds), [items, next, ownedIds]);
  const offsets = useMemo(() => {
    let y = 0;
    return pieces.map((p) => {
      const at = y;
      y += HEIGHTS[p.kind];
      return at;
    });
  }, [pieces]);
  // Opens with the focused creature's row second from the top. Fixed at
  // mount: FlatList only reads it once.
  const [initialIndex] = React.useState(() => {
    const at = pieces.findIndex((p) => p.kind === 'row' && p.goods.some((c) => c.id === focusId));
    return at > 0 ? at - 1 : 0;
  });

  const getItemLayout = useCallback((_, index) => ({ length: HEIGHTS[pieces[index].kind], offset: offsets[index], index }), [pieces, offsets]);

  const renderItem = useCallback(
    ({ item: piece }) => {
      if (piece.kind === 'next') {
        const c = piece.creature;
        return (
          <View style={{ paddingTop: 6 }}>
            <NextUp creature={c} width={stallW} have={tokenCount(profile, c.id)} moneyPrice={moneyPrice} buying={buyingId === c.id} onBuyNow={onBuyNow} tut />
          </View>
        );
      }
      if (piece.kind === 'top') return <StallTop tier={piece.tier} width={stallW} count={piece.count} span={piece.span} />;
      if (piece.kind === 'bottom') return <StallBottom tier={piece.tier} width={stallW} at={piece.at} span={piece.span} />;
      return (
        <StallRow tier={piece.tier} width={stallW} at={piece.at} span={piece.span}>
          {piece.goods.map((creature) => (
            <OnShelf key={creature.id} width={cardW}>
              <Goods
                creature={creature}
                tier={piece.tier}
                width={cardW}
                owned={!!ownedIds?.includes(creature.id)}
                hasKey={keys?.[creature.id] === true}
                have={tokenCount(profile, creature.id)}
                moneyPrice={moneyPrice}
                buying={buyingId === creature.id}
                focused={creature.id === focusId}
                onBuyNow={onBuyNow}
              />
            </OnShelf>
          ))}
        </StallRow>
      );
    },
    [stallW, cardW, ownedIds, keys, profile, moneyPrice, buyingId, focusId, onBuyNow]
  );

  return (
    <CandyBackground style={{ paddingTop: insets.top }}>
      <View style={styles.header}>
        <TutTarget name="storeBack">
          <RoundButton size={36} onPress={onBack}>
            <BackGlyph />
          </RoundButton>
        </TutTarget>
        <OutlinedTitle text="KEY SHOP" fill="pink" size={20} outline={3} ring={2} drop={5} />
        <CoinPill coins={(profile?.coins ?? 0).toLocaleString()} size={13} style={styles.coins} textStyle={styles.coinsText} />
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
        contentContainerStyle={[styles.listContent, { paddingBottom: adsFree ? insets.bottom + 28 : 28 }]}
      />
      {/* the ad strip along the bottom, as on Home (none with Remove Ads) */}
      {adsFree ? null : <AdStrip />}
    </CandyBackground>
  );
}

const keyOf = (p) => p.key;

const styles = StyleSheet.create({
  header: { flexDirection: 'row', alignItems: 'center', gap: 12, paddingHorizontal: 16, paddingTop: 16, paddingBottom: 4 },
  coins: { marginLeft: 'auto', paddingTop: 5, paddingBottom: 5 },
  coinsText: { fontSize: 13 },
  listContent: { paddingHorizontal: LIST_PAD, alignItems: 'center' },

  cardRing: { height: CARD_H, borderRadius: 24.5, padding: 2.5, backgroundColor: '#a23ad8' },
  cardRim: { flex: 1, borderRadius: 22, borderWidth: 3, borderColor: '#ffffff', overflow: 'hidden' },
  cardFace: { flex: 1 },
  art: { height: 112, alignItems: 'center', justifyContent: 'center', overflow: 'hidden' },
  key: { position: 'absolute', top: 8, left: 8 },
  chipAt: { position: 'absolute', top: 8, right: 8 },
  chipRing: { borderRadius: 999, padding: 1.5 },
  chipFace: { borderRadius: 999, borderWidth: 2, borderColor: '#ffffff', paddingHorizontal: 7, paddingVertical: 1 },
  chipText: { fontFamily: candyFonts.display, fontSize: 10, letterSpacing: 0.6 },
  divider: { height: 3 },
  info: { flex: 1, alignItems: 'center', justifyContent: 'center', gap: 7, paddingHorizontal: 10, paddingTop: 6, paddingBottom: 10 },
  name: { fontFamily: candyFonts.display, fontSize: 16, lineHeight: 19, color: '#4a1a73', textAlign: 'center' },
  buyWrap: { alignSelf: 'stretch' },
  tokenLine: { flexDirection: 'row', alignItems: 'center', gap: 4, minHeight: 12 },
  tokenText: { fontFamily: candyFonts.bodyHeavy, fontSize: 10, color: '#9467bd' },
  needText: { fontFamily: candyFonts.bodyHeavy, fontSize: 10, color: '#c25e00' },
});
