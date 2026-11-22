import React from 'react';
import { Image, ImageBackground, StyleSheet, Text, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import Pressable from '../components/Pressable';
import ShadowText from '../components/candy/ShadowText';
import { BY_ID, GROUPS, RAINBOW, ROSTER, SEASON, SET_OF, SIZES, SIZE_I, UPGRADE, chestPool, copyProgress, dropRar, dupeCoinsFor, groupOut, inGroupChest, owns, lineup, rainbowProgress, rainbowReady } from '../squad/data';
import GCHEST, { CHEST_NAMES } from '../squad/groupChestArt';
import { COIN, GEM } from '../squad/currencyArt';
import { Bob, F } from '../squad/ui';
import { fmtNum } from '../format';

// The Shop's group chests: what each group's chests are and say (allChests, chestInfo, groupCollected: the Chests tab,
// royal/ShopChestsRoyal.js, draws them), and the sheets a chest's details and every size's odds open in (ShopScreen's
// Sheet). The chests are the design's own art (tools/shop-art/groupchests.mjs). Every purchase is the server's (squad
// groupChest / freeChest / adChest / dealChest) and opens at once in the chest smash (ShopScreen → ChestSmash).

const fmt = fmtNum;
const OUT = (c, w = 1.5) => [[0, w + 0.5, c], [w, 0, c], [-w, 0, c], [0, -w, c]];
const GOLD = { bg: ['#fff3b0', '#ffd83a', '#ffb000'], rim: '#b86200', ink: '#7a3d00', ts: null };
const PURPLE = { bg: ['#f3d2ff', '#b65cff', '#6a22d6'], rim: '#45189a', ink: '#ffffff', ts: '#45189a' };
const GREY = { bg: ['#f7f3fc', '#ece6f6', '#e2d8f0'], rim: '#b8a8d4', ink: '#8a78b0', ts: null };
const GREEN = ['#d8ffc2', '#6fe07a', '#26a94e'];
// each size's colour (the design's TC)
const TC = [{ c: '#a0623a' }, { c: '#2f7ad6' }, { c: '#8a3cff' }, { c: '#d98200' }, { c: '#d6249a' }];
const SIZE_NAME = ['Common', 'Rare', 'Epic', 'Legendary', 'Rainbow'];
const RAR_ROW = [['Common', '#e3f1ff', '#2f6fc0'], ['Rare', '#e3fbe9', '#17803a'], ['Epic', '#f1e6ff', '#6a22d6'], ['Legendary', '#fff3d6', '#b86200'], ['Rainbow', '#ffe6f6', '#d6249a']];
const GROUP_LABEL = { snack: 'SNACK SHACK', fruit: 'FRUIT PATCH', ocean: 'OCEAN PALS', pet: 'PET SHOP', forest: 'FOREST FRIENDS', sky: 'SKY & STARS', dream: 'DREAMLAND', bakery: 'SWEET BAKERY', heroes: 'MASKED HEROES', elemental: 'ELEMENTAL HEROES', spooky: 'SPOOKY SQUISH' };

// Every group that's out, in the design's order for the day: the three HOT
// ones, the season, the rest. The season obeys config/roster's switch like
// any group (it used to be listed always, so a switched-off Spooky Squish
// still showed a chest the server then refused to sell).
export function allChests(day, hidden) {
  const hot = lineup(day, hidden);
  const rest = GROUPS.map((g) => g.key).filter((k) => k !== SEASON.key && !hot.includes(k) && groupOut(k, hidden));
  return [
    ...hot.map((k) => ({ k, tag: 'HOT TODAY', tagBg: ['#ff3d6e', '#ff7a3d'] })),
    ...(groupOut(SEASON.key, hidden) ? [{ k: SEASON.key, tag: 'SEASON', tagBg: ['#ff8a1e', '#b03a00'] }] : []),
    ...rest.map((k) => ({ k, tag: '' })),
  ];
}

// A group's earned Rainbow chest (functions/squad.js RAINBOW): not sold, it
// opens free once the rest of the group is unlocked, with the group's
// Rainbow creature inside. `pool`: the rest of the group (what earns it).
// `earned`: { reward (null: the group has none out), ready, opened, have, need }
const GREEN_LOOK = { bg: GREEN, rim: '#17652f', ink: '#ffffff', ts: '#17652f' };
function rainbowInfo(gk, profile, artIds) {
  const p = profile || {};
  const r = rainbowProgress(p, gk, artIds);
  const reward = r.reward && artIds.includes(r.reward) ? BY_ID[r.reward] : null;
  const opened = !!reward && owns(p, reward.id);
  const ready = rainbowReady(p, gk, artIds);
  const ti = SIZE_I.set;
  return {
    ti,
    T: SIZES[ti],
    pool: ((SET_OF[gk] && SET_OF[gk].ids) || []).filter((id) => artIds.includes(id)).map((id) => BY_ID[id]),
    have: r.have,
    name: (CHEST_NAMES[gk] || [])[ti] || 'Rainbow chest',
    look: ready ? GREEN_LOOK : GREY,
    odds: reward ? `${reward.name} 100%` : '',
    dupeCoins: '',
    upNote: '',
    earned: { reward, ready, opened, have: r.have, need: r.need },
  };
}

// How much of a group's chest creatures, of every rarity, the player has.
export function groupCollected(gk, profile, artIds, setRewards, rainbow = RAINBOW) {
  const all = ROSTER.filter((c) => inGroupChest(c, gk, setRewards, rainbow) && artIds.includes(c.id));
  return { have: all.filter((c) => owns(profile || {}, c.id)).length, total: all.length };
}

// A group's chest of a size: what the card and the sheet say.
export function chestInfo(gk, size, profile, artIds, setRewards, rainbow = RAINBOW) {
  if (size === 'set' && rainbow === 'chest') return rainbowInfo(gk, profile, artIds);
  const ti = SIZE_I[size];
  const T = SIZES[ti];
  // only this chest's own rarity (functions/squad.js chestPool)
  const pool = chestPool(gk, size, artIds, setRewards, rainbow);
  const have = pool.filter((c) => owns(profile || {}, c.id)).length;
  return {
    ti,
    T,
    pool,
    have,
    name: (CHEST_NAMES[gk] || [])[ti] || `${SIZE_NAME[ti]} chest`,
    look: T.price.cur === 'coins' ? GOLD : PURPLE,
    odds: `Only ${SIZE_NAME[ti]} pals`,
    // what a duplicate pays: 7% of the chest's worth (no other coins inside)
    dupeCoins: `+${fmt(dupeCoinsFor(size))}`,
    upNote: ti <= 1 ? `${UPGRADE[size]}% chance it upgrades on your first smash` : '',
  };
}

// The glossy candy button (the design's bg + 3px white border + ring and lip).
function Candy({ colors, rim, lip = 4, radius = 16, height, style, children, onPress, shine = true }) {
  return (
    <Pressable onPress={onPress} style={({ pressed }) => [style, pressed && { transform: [{ translateY: 3 }] }]}>
      <View style={{ borderRadius: radius + 2, backgroundColor: rim, padding: 2, paddingBottom: 2 + lip }}>
        <LinearGradient colors={colors} locations={colors.length === 3 ? [0, 0.55, 1] : undefined} style={{ height, borderRadius: radius, borderWidth: 3, borderColor: '#ffffff', overflow: 'hidden', flexDirection: 'row', alignItems: 'center', justifyContent: 'center', gap: 6 }}>
          {shine && <LinearGradient pointerEvents="none" colors={['rgba(255,255,255,0.72)', 'rgba(255,255,255,0.05)']} style={styles.shine} />}
          {children}
        </LinearGradient>
      </View>
    </Pressable>
  );
}

const Label = ({ children, size, color = '#ffffff', ts, style }) =>
  ts ? (
    <ShadowText style={[{ fontFamily: F.display, fontSize: size, color, includeFontPadding: false }, style]} shadows={OUT(ts)}>
      {children}
    </ShadowText>
  ) : (
    <Text style={[{ fontFamily: F.display, fontSize: size, color, includeFontPadding: false }, style]}>{children}</Text>
  );

// --- the sheets: a chest's details, and every size's odds ----------------------------------

// (landscape, REDESIGN_V8: the chest and its button on the left, what's in it on the right)
export function ChestSheetBody({ gk, size, profile, artIds, setRewards, rainbow = RAINBOW, catalog, wallet, onBuy }) {
  const C = chestInfo(gk, size, profile, artIds, setRewards, rainbow);
  if (C.earned) return <EarnedSheetBody gk={gk} C={C} profile={profile} catalog={catalog} onBuy={() => onBuy(gk, size)} />;
  const tc = TC[C.ti];
  const gemsCur = C.T.price.cur === 'gems';
  const afford = (gemsCur ? wallet.gems : wallet.coins) >= C.T.price.n;
  const look = afford ? C.look : GREY;
  const art = (
    <ImageBackground source={GCHEST[gk].bg} style={styles.sheetArt} imageStyle={{ borderRadius: 22 }} resizeMode="cover">
      <Bob ms={2600} style={styles.sheetChest}>
        <Image source={GCHEST[gk][`${size}-grow`]} style={styles.fill} resizeMode="contain" fadeDuration={0} />
      </Bob>
    </ImageBackground>
  );
  const head = (
    <>
      <View style={styles.sheetTag}>
        <Text style={[styles.sheetTagText, { color: tc.c }]}>{`${GROUP_LABEL[gk]} · ${SIZE_NAME[C.ti].toUpperCase()}`}</Text>
      </View>
      <Text style={styles.sheetName}>{C.name}</Text>
      {!!C.upNote && <Text style={styles.sheetUp}>{C.upNote}</Text>}
    </>
  );
  const details = (
    <>
      <View style={styles.sheetOdds}>
        <View style={[styles.sheetOdd, { backgroundColor: RAR_ROW[C.ti][1] }]}>
          <Text style={[styles.sheetOddPct, { color: RAR_ROW[C.ti][2] }]}>100%</Text>
          <Text style={[styles.sheetOddName, { color: RAR_ROW[C.ti][2] }]}>{RAR_ROW[C.ti][0]}</Text>
        </View>
      </View>
      <View style={styles.sheetRow}>
        <Text style={styles.sheetInside}>Squishies inside</Text>
        <Text style={styles.sheetHave}>{`${C.have} / ${C.pool.length} collected`}</Text>
      </View>
      <View style={styles.mons}>
        {C.pool.map((c) => {
          const o = owns(profile || {}, c.id);
          const uri = catalog[c.id]?.thumb?.url;
          const cp = o ? null : copyProgress(profile, c.id);
          return (
            <View key={c.id} style={[styles.mon, { backgroundColor: o ? '#f8f1e7' : '#ffffff', borderColor: o ? '#efe2cf' : RAR_ROW[dropRar(c)] ? RAR_ROW[dropRar(c)][2] : '#e2cfb4' }]}>
              {uri ? <Image source={{ uri }} style={[styles.monImg, { opacity: o ? 0.5 : 1 }]} resizeMode="contain" /> : null}
              {cp && (
                <View style={styles.monNew}>
                  <Text style={styles.monNewText}>{`${cp.have}/${cp.need}`}</Text>
                </View>
              )}
            </View>
          );
        })}
      </View>
      <View style={styles.row4}>
        <Image source={COIN[0]} style={styles.icon16} />
        <Text style={styles.sheetCoins}>{`Duplicate: ${C.dupeCoins} coins`}</Text>
      </View>
    </>
  );
  const buy = (
    <Candy colors={look.bg} rim={look.rim} lip={5} radius={20} height={52} style={{ alignSelf: 'stretch' }} onPress={() => onBuy(gk, size)}>
      {afford && <Image source={gemsCur ? GEM[0] : COIN[0]} style={styles.icon30} />}
      <Label size={20} color={look.ink} ts={look.ts}>
        {afford ? `Open · ${fmt(C.T.price.n)}` : `Get more ${C.T.price.cur}`}
      </Label>
    </Candy>
  );
  return (
    <View style={styles.sheetWide}>
      <View style={styles.sheetLeft}>
        {art}
        {buy}
      </View>
      <View style={styles.sheetRight}>
        {head}
        {details}
      </View>
    </View>
  );
}

// An earned Rainbow chest's sheet: the chest, who's inside, the rest of the
// group (what earns it), and the card's button.
function EarnedSheetBody({ gk, C, profile, catalog, onBuy }) {
  const e = C.earned;
  const tc = TC[C.ti];
  const rewardUri = e.reward ? catalog[e.reward.id]?.thumb?.url : null;
  const art = (
    <ImageBackground source={GCHEST[gk].bg} style={styles.sheetArt} imageStyle={{ borderRadius: 22 }} resizeMode="cover">
      <Bob ms={2600} style={styles.sheetChest}>
        <Image source={GCHEST[gk]['set-grow']} style={styles.fill} resizeMode="contain" fadeDuration={0} />
      </Bob>
    </ImageBackground>
  );
  const info = (
    <>
      <View style={styles.sheetTag}>
        <Text style={[styles.sheetTagText, { color: tc.c }]}>{`${GROUP_LABEL[gk]} · RAINBOW · ONCE ONLY`}</Text>
      </View>
      <Text style={styles.sheetName}>{C.name}</Text>
      <Text style={styles.rbSheetNote}>
        {e.opened ? `Opened: ${e.reward.name} is in your squad.` : `Not sold in the shop. Unlock every other pal of this group and it's yours, once, free.`}
      </Text>
      {e.reward ? (
        <View style={styles.rbInside}>
          <View style={styles.rbInsideImg}>{rewardUri ? <Image source={{ uri: rewardUri }} style={styles.monImg} resizeMode="contain" /> : null}</View>
          <View style={{ flex: 1, gap: 2 }}>
            <Text style={styles.rbInsideLabel}>INSIDE</Text>
            <Text style={styles.rbInsideName}>{e.reward.name}</Text>
            <Text style={styles.rbInsideSub}>Rainbow pal · joins whole, no copies</Text>
          </View>
        </View>
      ) : null}
      <View style={styles.sheetRow}>
        <Text style={styles.sheetInside}>The rest of the group</Text>
        <Text style={styles.sheetHave}>{`${e.have} / ${e.need} unlocked`}</Text>
      </View>
      <View style={styles.mons}>
        {C.pool.map((c) => {
          const o = owns(profile || {}, c.id);
          const uri = catalog[c.id]?.thumb?.url;
          const cp = o ? null : copyProgress(profile, c.id);
          return (
            <View key={c.id} style={[styles.mon, { backgroundColor: o ? '#ffffff' : '#f8f1e7', borderColor: o ? '#26a94e' : '#efe2cf' }]}>
              {uri ? <Image source={{ uri }} style={[styles.monImg, { opacity: o ? 1 : 0.45 }]} resizeMode="contain" /> : null}
              {cp && (
                <View style={styles.monNew}>
                  <Text style={styles.monNewText}>{`${cp.have}/${cp.need}`}</Text>
                </View>
              )}
            </View>
          );
        })}
      </View>
    </>
  );
  const buy = (
    <Candy colors={C.look.bg} rim={C.look.rim} lip={5} radius={20} height={52} style={{ alignSelf: 'stretch' }} onPress={onBuy}>
      <Label size={20} color={C.look.ink} ts={C.look.ts}>
        {e.opened ? 'Opened' : e.ready ? 'Open free!' : `Unlock all ${e.need} pals`}
      </Label>
    </Candy>
  );
  return (
    <View style={styles.sheetWide}>
      <View style={styles.sheetLeft}>
        {art}
        {buy}
      </View>
      <View style={styles.sheetRight}>{info}</View>
    </View>
  );
}

export function OddsSheetBody({ rainbow = RAINBOW }) {
  const earned = rainbow === 'chest';
  return (
    <View style={styles.sheetBody}>
      <Text style={styles.sheetName}>Drop odds</Text>
      {SIZES.map((T, i) => (
        <View key={T.k} style={styles.oddsRow}>
          <Text style={[styles.oddsRowName, { color: TC[i].c }]}>{SIZE_NAME[i]}</Text>
          <Text style={styles.oddsRowOdds}>{earned && T.k === 'set' ? "Not sold: earned once by unlocking a group, with its Rainbow pal" : `100% ${SIZE_NAME[i]} pals`}</Text>
        </View>
      ))}
      <Text style={styles.oddsNote}>
        {`Each chest holds only pals of its own rarity. Common and Rare chests can upgrade on your first smash, and then hold the rarity they became. Duplicates turn into coins.${earned ? " Rainbow pals come only from their group's Rainbow chest." : ''}`}
      </Text>
    </View>
  );
}

const styles = StyleSheet.create({
  fill: { width: '100%', height: '100%' },
  shine: { position: 'absolute', left: '8%', right: '8%', top: 2, height: '40%', borderRadius: 999 },
  row4: { flexDirection: 'row', alignItems: 'center', gap: 4 },
  icon16: { width: 16, height: 16 },
  icon30: { width: 30, height: 30 },
  // an earned Rainbow chest's sheet
  rbSheetNote: { fontFamily: F.heavy, fontSize: 12.5, lineHeight: 17, color: '#8a3a0e', textAlign: 'center' },
  rbInside: { alignSelf: 'stretch', flexDirection: 'row', alignItems: 'center', gap: 12, padding: 10, borderRadius: 18, backgroundColor: '#fff3e0', borderWidth: 2, borderColor: '#f2cf9e' },
  rbInsideImg: { width: 72, height: 72, borderRadius: 16, backgroundColor: '#ffffff', alignItems: 'center', justifyContent: 'center', overflow: 'hidden' },
  rbInsideLabel: { fontFamily: F.black, fontSize: 10, letterSpacing: 1, color: '#e0601c' },
  rbInsideName: { fontFamily: F.display, fontSize: 20, lineHeight: 22, color: '#5b3418' },
  rbInsideSub: { fontFamily: F.heavy, fontSize: 11, color: '#9a7a5a' },
  // the odds sheet
  sheetBody: { alignSelf: 'stretch', alignItems: 'center', gap: 10 },
  // a chest's sheet (REDESIGN_V8): the chest and its button on the left, what's in it on the right
  sheetWide: { alignSelf: 'stretch', flexDirection: 'row', gap: 16 },
  sheetLeft: { width: 230, gap: 10 },
  sheetRight: { flex: 1, alignItems: 'center', gap: 8 },
  sheetArt: { width: '100%', height: 196, borderRadius: 22, overflow: 'hidden' },
  sheetChest: { position: 'absolute', left: '50%', top: 10, width: 240, height: 184, marginLeft: -120 },
  sheetTag: { paddingHorizontal: 12, paddingVertical: 3, borderRadius: 999, backgroundColor: '#f6ead8' },
  sheetTagText: { fontFamily: F.black, fontSize: 10.5, letterSpacing: 1 },
  sheetName: { fontFamily: F.display, fontSize: 26, lineHeight: 28, color: '#5b3418', textAlign: 'center' },
  sheetUp: { fontFamily: F.heavy, fontSize: 12, color: '#17803a', textAlign: 'center' },
  sheetOdds: { alignSelf: 'stretch', flexDirection: 'row', gap: 6 },
  sheetOdd: { flex: 1, alignItems: 'center', gap: 1, paddingVertical: 7, borderRadius: 12 },
  sheetOddPct: { fontFamily: F.display, fontSize: 16 },
  sheetOddName: { fontFamily: F.black, fontSize: 9.5 },
  sheetRow: { alignSelf: 'stretch', flexDirection: 'row', alignItems: 'baseline', justifyContent: 'space-between' },
  sheetInside: { fontFamily: F.black, fontSize: 12.5, color: '#5b3418' },
  sheetHave: { fontFamily: F.heavy, fontSize: 11.5, color: '#9a6a3a' },
  mons: { alignSelf: 'stretch', flexDirection: 'row', flexWrap: 'wrap', gap: 6 },
  mon: { width: '11.4%', aspectRatio: 1, borderRadius: 14, borderWidth: 2, alignItems: 'center', justifyContent: 'center', overflow: 'hidden' },
  monImg: { width: '86%', height: '86%' },
  monNew: { position: 'absolute', left: 3, bottom: 3, paddingHorizontal: 4, borderRadius: 5, backgroundColor: '#e01e4a' },
  monNewText: { fontFamily: F.black, fontSize: 8, color: '#ffffff' },
  sheetCoins: { fontFamily: F.bold, fontSize: 11.5, color: '#9a6a3a' },
  oddsRow: { alignSelf: 'stretch', flexDirection: 'row', alignItems: 'center', gap: 8, paddingHorizontal: 12, paddingVertical: 9, borderRadius: 14, backgroundColor: '#f6ead8' },
  oddsRowName: { width: 80, fontFamily: F.display, fontSize: 14 },
  oddsRowOdds: { flex: 1, fontFamily: F.heavy, fontSize: 11.5, color: '#5b3418' },
  oddsNote: { fontFamily: F.bold, fontSize: 11, lineHeight: 15.5, color: '#9a6a3a' },
});
