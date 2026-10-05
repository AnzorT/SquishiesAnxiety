import React, { memo } from 'react';
import { Pressable, ScrollView, StyleSheet, Text, View } from 'react-native';
import { SvgXml } from 'react-native-svg';
import { candyFonts } from '../theme/candyTheme';
import { CoinGlyph, INK, PAPER, SOFT } from './ui';
import { FOODS } from './data';
import { FOOD_PACK, foodCost } from './model';

// The kitchen's pantry shop (only in the kitchen: its HUD button, and "Buy
// food" in the snack picker): every food the fridge holds, how many are in
// the pantry, and +1 / +FOOD_PACK to buy (a pack costs one less). Meals take
// from the pantry before they cost coins (model.js startMeal), so stocking
// up is cheaper than paying meal by meal. Foods a better fridge would add
// are listed, locked, at the end.

const GREEN = '#4f9a3a';

function BuyButton({ n, cost, afford, deal, onPress }) {
  return (
    <Pressable onPress={onPress} style={({ pressed }) => [styles.buy, deal && styles.buyDeal, { opacity: afford ? 1 : 0.5 }, pressed && afford && { transform: [{ translateY: 2 }] }]}>
      <Text style={styles.buyN}>{`+${n}`}</Text>
      <CoinGlyph size={12} />
      <Text style={styles.buyCost}>{cost}</Text>
    </Pressable>
  );
}

function FoodCard({ f, have, fill, coins, width, onBuy }) {
  const one = foodCost(f, 1);
  const pack = foodCost(f, FOOD_PACK);
  return (
    <View style={[styles.card, { width }]}>
      <View style={styles.preview}>
        <SvgXml xml={f.svg} width={38} height={38} />
        <View style={[styles.have, have > 0 ? styles.haveOn : null]}>
          <Text style={[styles.haveText, have > 0 && { color: '#ffffff' }]}>{`×${have}`}</Text>
        </View>
      </View>
      <Text style={styles.name} numberOfLines={1}>
        {f.name}
      </Text>
      <Text style={styles.fill}>{`+${fill} tummy`}</Text>
      <BuyButton n={1} cost={one} afford={coins >= one} onPress={() => onBuy(f.k, 1)} />
      <View>
        <BuyButton n={FOOD_PACK} cost={pack} afford={coins >= pack} deal onPress={() => onBuy(f.k, FOOD_PACK)} />
        <View style={styles.save} pointerEvents="none">
          <Text style={styles.saveText}>1 FREE</Text>
        </View>
      </View>
    </View>
  );
}

function LockedCard({ f, width }) {
  return (
    <View style={[styles.card, styles.locked, { width }]}>
      <View style={[styles.preview, { backgroundColor: '#eadfce' }]}>
        <View style={{ opacity: 0.45 }}>
          <SvgXml xml={f.svg} width={38} height={38} />
        </View>
      </View>
      <Text style={[styles.name, { color: SOFT }]} numberOfLines={1}>
        {f.name}
      </Text>
      <Text style={styles.lockText}>Needs a better fridge</Text>
    </View>
  );
}

export const Pantry = memo(function Pantry({ pantry, fridge, fill, coins, msg, width, height, onBuy, onClose }) {
  const inFridge = FOODS.filter((f) => fridge.includes(f.k));
  const locked = FOODS.filter((f) => !fridge.includes(f.k));
  const panelW = Math.min(width - 24, 620);
  const pad = 14;
  const gap = 10;
  const cols = Math.max(3, Math.floor((panelW - pad * 2 + gap) / (128 + gap)));
  const cardW = Math.floor((panelW - pad * 2 - gap * (cols - 1)) / cols);
  const stocked = Object.values(pantry).reduce((a, b) => a + (b || 0), 0);
  return (
    <View style={styles.scrim}>
      <Pressable style={StyleSheet.absoluteFill} onPress={onClose} />
      <View style={[styles.panel, { width: panelW, maxHeight: height - 32 }]}>
        <View style={styles.head}>
          <View style={styles.badge}>
            <Text style={styles.badgeText}>PANTRY</Text>
          </View>
          <View style={{ flex: 1 }} />
          <View style={styles.coins}>
            <CoinGlyph size={14} />
            <Text style={styles.coinsText}>{Math.max(0, Math.round(coins)).toLocaleString()}</Text>
          </View>
          <Pressable onPress={onClose} hitSlop={8} style={styles.close}>
            <Text style={styles.closeText}>✕</Text>
          </Pressable>
        </View>
        <Text style={styles.sub}>{`Stock up for your squishies — they eat from the pantry first. Packs of ${FOOD_PACK} come with one free. ${stocked} in the pantry now.`}</Text>
        {msg ? (
          <View style={styles.msg}>
            <Text style={styles.msgText}>{msg}</Text>
          </View>
        ) : null}
        <ScrollView style={{ flexGrow: 0, flexShrink: 1 }} contentContainerStyle={{ paddingHorizontal: pad, paddingBottom: pad, gap: 12 }} showsVerticalScrollIndicator={false}>
          <View style={styles.grid}>
            {inFridge.map((f) => (
              <FoodCard key={f.k} f={f} have={pantry[f.k] || 0} fill={fill(f)} coins={coins} width={cardW} onBuy={onBuy} />
            ))}
          </View>
          {locked.length ? (
            <>
              <Text style={styles.secTitle}>{`${locked.length} more with a better fridge (Home Shop)`}</Text>
              <View style={styles.grid}>
                {locked.map((f) => (
                  <LockedCard key={f.k} f={f} width={cardW} />
                ))}
              </View>
            </>
          ) : null}
        </ScrollView>
      </View>
    </View>
  );
});

const styles = StyleSheet.create({
  scrim: { ...StyleSheet.absoluteFillObject, zIndex: 34, backgroundColor: 'rgba(40,22,10,0.55)', alignItems: 'center', justifyContent: 'center' },
  panel: { backgroundColor: '#f6e3c4', borderRadius: 24, borderWidth: 3, borderColor: INK, overflow: 'hidden', elevation: 14 },
  head: { flexDirection: 'row', alignItems: 'center', gap: 10, paddingHorizontal: 14, paddingTop: 12, paddingBottom: 6 },
  badge: { paddingHorizontal: 14, paddingVertical: 3, borderRadius: 12, borderWidth: 3, borderColor: INK, backgroundColor: '#e8862a' },
  badgeText: { fontFamily: candyFonts.display, fontSize: 17, color: '#ffffff', textShadowColor: INK, textShadowRadius: 1, textShadowOffset: { width: 0, height: 2 } },
  coins: { flexDirection: 'row', alignItems: 'center', gap: 5, backgroundColor: INK, borderWidth: 2, borderColor: '#ffffff', borderRadius: 999, paddingHorizontal: 12, paddingVertical: 4 },
  coinsText: { fontFamily: candyFonts.bodyBlack, fontSize: 14, color: '#fff3a0' },
  close: { width: 34, height: 34, borderRadius: 17, borderWidth: 2.5, borderColor: INK, backgroundColor: '#fff6e6', alignItems: 'center', justifyContent: 'center' },
  closeText: { fontFamily: candyFonts.bodyBlack, fontSize: 14, color: INK },
  sub: { fontFamily: candyFonts.bodyHeavy, fontSize: 11, lineHeight: 15, color: SOFT, paddingHorizontal: 14, paddingBottom: 10 },
  msg: { marginHorizontal: 14, marginBottom: 8, paddingHorizontal: 12, paddingVertical: 6, borderRadius: 12, backgroundColor: INK },
  msgText: { fontFamily: candyFonts.bodyBlack, fontSize: 12, color: '#ffffff', textAlign: 'center' },
  grid: { flexDirection: 'row', flexWrap: 'wrap', gap: 10 },
  secTitle: { fontFamily: candyFonts.display, fontSize: 14, color: INK },
  card: { borderRadius: 18, backgroundColor: PAPER, borderWidth: 3, borderColor: INK, padding: 8, gap: 5 },
  locked: { borderStyle: 'dashed', borderColor: '#b8a08a' },
  preview: { height: 58, borderRadius: 12, backgroundColor: '#f6e7cf', alignItems: 'center', justifyContent: 'center' },
  have: { position: 'absolute', right: 5, top: 5, minWidth: 24, paddingHorizontal: 5, height: 18, borderRadius: 9, borderWidth: 2, borderColor: INK, backgroundColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  haveOn: { backgroundColor: GREEN },
  haveText: { fontFamily: candyFonts.bodyBlack, fontSize: 10, color: INK, includeFontPadding: false },
  name: { fontFamily: candyFonts.display, fontSize: 13, color: INK },
  fill: { fontFamily: candyFonts.bodyBlack, fontSize: 10, color: '#d9483e', marginTop: -4 },
  buy: { height: 30, flexDirection: 'row', alignItems: 'center', justifyContent: 'center', gap: 4, borderRadius: 999, borderWidth: 2.5, borderColor: INK, backgroundColor: '#fff6e6' },
  buyDeal: { backgroundColor: '#ffd66b' },
  buyN: { fontFamily: candyFonts.display, fontSize: 13, color: INK, marginRight: 2 },
  buyCost: { fontFamily: candyFonts.display, fontSize: 13, color: INK },
  save: { position: 'absolute', right: -4, top: -8, paddingHorizontal: 5, paddingVertical: 1, borderRadius: 999, backgroundColor: GREEN, borderWidth: 1.5, borderColor: '#ffffff' },
  saveText: { fontFamily: candyFonts.bodyBlack, fontSize: 8, color: '#ffffff', includeFontPadding: false },
  lockText: { fontFamily: candyFonts.bodyHeavy, fontSize: 10, color: SOFT },
});
