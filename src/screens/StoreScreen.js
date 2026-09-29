import React, { memo, useCallback, useMemo } from 'react';
import { View, Text, StyleSheet, FlatList } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { LinearGradient } from 'expo-linear-gradient';
import { BUTTON_VARIANTS, candyColors, candyFonts } from '../theme/candyTheme';
import CandyBackground from '../components/candy/CandyBackground';
import CandyButton, { ButtonText, CandyPill } from '../components/candy/CandyButton';
import RoundButton, { BackGlyph } from '../components/candy/RoundButton';
import OutlinedTitle from '../components/candy/OutlinedTitle';
import CreatureKey from '../components/candy/CreatureKey';
import { SoftPulse } from '../components/candy/Decor';
import CreatureToken from '../components/candy/Tokens';
import { CandyProgress } from '../components/candy/Decor';
import { isUnlockable, tokenCount, tokenPrice } from '../economy';

// The Key Shop sells a creature's *key*, not the creature itself — redeeming
// it is the hold-to-unlock gesture on the Home card (CreatureCard). Every
// row shows the two ways to the key (src/economy.js): the creature's own
// tokens so far (a full set, from Mystery Boxes, puts the key on its card by
// itself), and a $0.99 button. Coins don't buy keys (they buy Mystery
// Boxes). Rows already settled show ★ OWNED or KEY READY instead.
//
// Opened from a locked creature's popup (SHOP), it opens on that creature's
// row (`focusId`), which breathes gently so it's easy to spot.
//
// The rows are a FlatList of fixed-height, memoised rows: each one is heavy
// (an SVG key, the creature's art, candy buttons), and building all of them
// at once held the screen up for over 2 s on the emulator. Now only the rows
// in view are built first — starting at the focused one — and the rest as
// the list scrolls.

const ROW_H = 124;
const GAP = 12;

function WayButton({ variant, onPress, loading, children }) {
  const v = BUTTON_VARIANTS[variant];
  return (
    <CandyButton variant={variant} size="xs" dim={variant === 'grey'} loading={loading} onPress={onPress} style={styles.way} faceStyle={styles.wayFace}>
      <View style={styles.wayRow}>{children(v.ring)}</View>
    </CandyButton>
  );
}

const ShopRow = memo(function ShopRow({ creature, owned, hasKey, have, moneyPrice, buying, focused, onBuyNow }) {
  const settled = owned || hasKey;
  const need = tokenPrice(creature.id);
  return (
    <SoftPulse active={focused} to={1.03} style={styles.rowRing}>
      <View style={styles.rowWhite}>
        <LinearGradient colors={['#fff6fd', '#ffdcf4', '#f5cbff']} locations={[0, 0.6, 1]} style={styles.row}>
          <View style={styles.top}>
            <CreatureKey creature={creature} />
            <Text style={styles.name} numberOfLines={1}>
              {creature.name}
            </Text>
            {owned ? <CandyPill variant="purple" label="★ OWNED" fontSize={12} padV={4} padH={12} /> : null}
            {!owned && hasKey ? <CandyPill variant="gold" label="KEY READY" fontSize={12} padV={4} padH={12} /> : null}
          </View>
          {settled ? null : (
            <View style={styles.ways}>
              <CreatureToken creature={creature} size={24} />
              <View style={styles.tokenCol}>
                <Text style={styles.tokenText}>{`${have.toLocaleString()}/${need.toLocaleString()} TOKENS`}</Text>
                <CandyProgress pct={(have / need) * 100} height={9} ring={candyColors.pinkRing} />
              </View>
              <WayButton variant="blue" loading={buying} onPress={() => onBuyNow(creature)}>
                {(ring) => (
                  <ButtonText ring={ring} size={13}>
                    {moneyPrice}
                  </ButtonText>
                )}
              </WayButton>
            </View>
          )}
        </LinearGradient>
      </View>
    </SoftPulse>
  );
});

const getItemLayout = (_, index) => ({ length: ROW_H + GAP, offset: (ROW_H + GAP) * index, index });
const keyOf = (c) => c.id;

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
  const items = useMemo(() => creatures.filter(isUnlockable), [creatures]);
  const ownedIds = profile?.ownedIds;
  const keys = profile?.keys;
  // the focused row, fixed at mount (FlatList only reads it once)
  const [initialIndex] = React.useState(() => Math.max(0, items.findIndex((c) => c.id === focusId)));

  const renderItem = useCallback(
    ({ item: creature }) => (
      <ShopRow
        creature={creature}
        owned={!!ownedIds?.includes(creature.id)}
        hasKey={keys?.[creature.id] === true}
        have={tokenCount(profile, creature.id)}
        moneyPrice={moneyPrice}
        buying={buyingId === creature.id}
        focused={creature.id === focusId}
        onBuyNow={onBuyNow}
      />
    ),
    [ownedIds, keys, profile, moneyPrice, buyingId, focusId, onBuyNow]
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
        data={items}
        keyExtractor={keyOf}
        renderItem={renderItem}
        getItemLayout={getItemLayout}
        initialScrollIndex={initialIndex > 0 ? initialIndex : undefined}
        initialNumToRender={6}
        maxToRenderPerBatch={4}
        windowSize={5}
        contentContainerStyle={[styles.list, { paddingBottom: insets.bottom + 20 }]}
      />
    </CandyBackground>
  );
}

const styles = StyleSheet.create({
  header: { flexDirection: 'row', alignItems: 'center', gap: 8, paddingHorizontal: 16, paddingTop: 12, paddingBottom: 8 },
  list: { paddingHorizontal: 16, paddingTop: 6 },
  rowRing: {
    height: ROW_H,
    marginBottom: GAP,
    borderRadius: 23,
    padding: 2.5,
    backgroundColor: candyColors.cardRing,
    shadowColor: '#320064',
    shadowOffset: { width: 0, height: 8 },
    shadowOpacity: 0.35,
    shadowRadius: 9,
    elevation: 6,
  },
  rowWhite: { flex: 1, borderRadius: 20, borderWidth: 3, borderColor: '#ffffff', overflow: 'hidden' },
  row: { flex: 1, justifyContent: 'center', paddingHorizontal: 12, paddingVertical: 6, gap: 4 },
  top: { flexDirection: 'row', alignItems: 'center', gap: 10 },
  name: { flex: 1, color: candyColors.ink, fontFamily: candyFonts.display, fontSize: 16 },
  ways: { flexDirection: 'row', alignItems: 'center', gap: 8 },
  way: { width: 92 },
  tokenCol: { flex: 1, gap: 3 },
  tokenText: { color: '#d3179a', fontFamily: candyFonts.display, fontSize: 12, letterSpacing: 0.4 },
  wayFace: { paddingHorizontal: 4 },
  wayRow: { flexDirection: 'row', alignItems: 'center', gap: 5 },
});
