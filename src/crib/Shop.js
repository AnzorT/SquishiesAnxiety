import React, { memo, useMemo } from 'react';
import { Pressable, ScrollView, StyleSheet, Text, View } from 'react-native';
import Svg, { Path, Rect } from 'react-native-svg';
import { SvgXml } from 'react-native-svg';
import { candyFonts } from '../theme/candyTheme';
import { CoinGlyph, INK, SOFT } from './ui';
import { DECOR, EXTRAS, GAMES, ITEMS, THEMES, slotsIn } from './home';
import { ItemArt, ThemeSwatch } from './art';
import catalog from './catalog';

// The Home Shop (the design's "HOME SHOP" page in "Squad Crib v5"): a tab
// per room, and its furniture (a section per slot, from the free cheap tier
// up), bath stations, yard games, decor (the room's fixtures among it) and
// walls / floors / ceilings as cards. Things above the player's level are
// locked; the rest cost coins. (The design's $ prices are left out for now:
// the economy stays as it is.)

const GREEN = '#4f9a3a';

// the width / height of an SVG string's viewBox
export function aspectOf(svg) {
  const m = svg && svg.match(/viewBox="([-\d.\s]+)"/);
  if (!m) return 1;
  const [, , w, h] = m[1].trim().split(/\s+/).map(Number);
  return w && h ? w / h : 1;
}

// an SVG fitted inside w×h, keeping its shape
export function FitSvg({ svg, w, h, style }) {
  if (!svg) return null;
  const a = aspectOf(svg);
  const fw = Math.min(w, h * a);
  const fh = fw / a;
  return (
    <View style={[{ width: fw, height: fh }, style]}>
      <SvgXml xml={svg} width={fw} height={fh} />
    </View>
  );
}

export const iconOf = (id) => {
  const it = ITEMS[id];
  if (!it) return null;
  return it.kind === 'decor' ? it.svg : it.icon;
};

// an item's picture: its SVG icon, a cut-out picture, a wall / floor
// swatch, or (a bare floor, nothing to show) a dashed outline
export function ItemIcon({ id, w, h }) {
  const it = ITEMS[id];
  if (!it) return null;
  if (it.kind === 'theme') return <ThemeSwatch room={it.room} kind={it.themeKind} theme={THEMES[it.room][it.themeKind][it.index]} width={w} height={Math.min(h, Math.round(w * 0.5))} />;
  if (it.kind === 'decor') return it.svg ? <ItemArt svg={it.svg} w={w} h={h} /> : <ItemArt art={it.art} aspect={it.w / it.h} w={w} h={h} />;
  if (it.icon) return <ItemArt svg={it.icon} w={w} h={h} />;
  if (it.iconArt) return <ItemArt art={it.iconArt} aspect={it.iconAspect || 1} w={w} h={h} />;
  return <View style={{ width: Math.min(w, h * 1.4), height: Math.min(h, w / 1.4), borderRadius: 8, borderWidth: 2.5, borderStyle: 'dashed', borderColor: '#b8a08a' }} />;
}

function LockGlyph({ size = 11, color = '#ffffff' }) {
  return (
    <Svg width={size} height={size} viewBox="0 0 24 24">
      <Rect x={5} y={11} width={14} height={10} rx={2} fill={color} />
      <Path d="M8 11V8a4 4 0 0 1 8 0v3" stroke={color} strokeWidth={2.6} fill="none" />
    </Svg>
  );
}

// the cards of a room: { title, items: [{ id, sub, perk, used }] }
export function shopSections(home, room) {
  const sections = [];
  slotsIn(room).forEach((sl) => {
    const items = sl.tiers.filter((t) => t.tier > 0).map((t) => ({ id: t.id, sub: `${sl.name} · tier ${t.tier + 1}`, perk: t.effect, used: home.eq[sl.key] === t.id }));
    if (items.length) sections.push({ title: sl.name, items });
  });
  if (room === 'bath') sections.push({ title: 'Bath stations', items: EXTRAS.map((e) => ({ id: e.id, sub: 'Bath station', perk: e.effect, used: true })) });
  if (room === 'yard') sections.push({ title: 'Games', items: GAMES.filter((g) => g.coins > 0).map((g) => ({ id: g.itemId, sub: g.pad ? 'Has its own play spot' : 'Fits any play spot', perk: g.effect, used: Object.values(home.pads).includes(g.id) })) });
  const dec = DECOR.filter((d) => d.room === room).map((d) => ({ id: d.id, sub: 'Decor · drag to place', perk: d.perkText, used: !home.stored[d.id] }));
  if (dec.length) sections.push({ title: 'Decor', items: dec });
  const T = THEMES[room] || {};
  const kindName = { wall: 'Wall', floor: room === 'yard' ? 'Ground' : 'Floor', ceil: 'Ceiling' };
  const th = [];
  ['wall', 'floor', 'ceil'].forEach((k) =>
    (T[k] || []).forEach((t, i) => {
      if (!t.coins) return;
      const used = ((home.th || {})[room] || {})[k] === i;
      th.push({ id: `th:${room}:${k}:${i}`, sub: kindName[k], perk: i === T[k].length - 1 && room !== 'yard' ? 'The finest there is' : 'A new look', used });
    })
  );
  if (th.length) sections.push({ title: room === 'yard' ? 'Ground' : 'Walls, floors & ceilings', items: th });
  return sections;
}

function Card({ it, home, level, coins, width, onBuy }) {
  const item = ITEMS[it.id];
  const owned = !!home.own[it.id];
  const locked = !owned && level < item.lvl;
  const afford = coins >= (item.coins || 0);
  return (
    <View style={[styles.card, { width }]}>
      <View style={[styles.preview, { backgroundColor: owned ? '#e3f1d4' : locked ? '#eadfce' : '#f6e7cf' }]}>
        <View style={{ opacity: locked ? 0.55 : 1 }}>
          <ItemIcon id={it.id} w={width * 0.72} h={72} />
        </View>
        {locked ? (
          <View style={styles.lockTag}>
            <LockGlyph />
            <Text style={styles.lockTagText}>{`LEVEL ${item.lvl}`}</Text>
          </View>
        ) : null}
        {owned ? (
          <View style={styles.ownedTag}>
            <Text style={styles.ownedTagText}>OWNED</Text>
          </View>
        ) : null}
      </View>
      <Text style={styles.name} numberOfLines={1}>
        {item.name}
      </Text>
      <Text style={styles.sub} numberOfLines={1}>
        {it.sub}
      </Text>
      <Text style={styles.perk} numberOfLines={1}>
        {it.perk}
      </Text>
      {owned ? (
        <Text style={styles.ownedText}>{it.used ? 'In use' : 'Owned · swap it in Edit mode'}</Text>
      ) : locked ? (
        <View style={styles.lockBtn}>
          <Text style={styles.lockBtnText}>{`Reach level ${item.lvl}`}</Text>
        </View>
      ) : (
        <Pressable onPress={() => onBuy(it.id)} style={({ pressed }) => [styles.buy, { opacity: afford ? 1 : 0.55 }, pressed && { transform: [{ translateY: 2 }] }]}>
          <CoinGlyph size={14} />
          <Text style={styles.buyText}>{(item.coins || 0).toLocaleString()}</Text>
        </Pressable>
      )}
    </View>
  );
}

export const Shop = memo(function Shop({ home, homeRev, room, level, coins, msg, width, onRoom, onBuy, onClose, topPad = 12, bottomPad = 12 }) {
  const sections = useMemo(() => shopSections(home, room), [home, homeRev, room]); // eslint-disable-line react-hooks/exhaustive-deps
  const pad = 16;
  const gap = 12;
  const cols = Math.max(2, Math.floor((width - pad * 2 + gap) / (168 + gap)));
  const cardW = Math.floor((width - pad * 2 - gap * (cols - 1)) / cols);
  return (
    <View style={styles.page}>
      <View style={[styles.head, { paddingTop: topPad }]}>
        <View style={styles.badge}>
          <Text style={styles.badgeText}>HOME SHOP</Text>
        </View>
        <Text style={styles.level}>{`LEVEL ${level}`}</Text>
        <View style={{ flex: 1 }} />
        <View style={styles.coins}>
          <CoinGlyph size={14} />
          <Text style={styles.coinsText}>{Math.max(0, Math.round(coins)).toLocaleString()}</Text>
        </View>
        <Pressable onPress={onClose} hitSlop={8} style={styles.close}>
          <Text style={styles.closeText}>✕</Text>
        </Pressable>
      </View>
      <ScrollView horizontal showsHorizontalScrollIndicator={false} style={{ flexGrow: 0 }} contentContainerStyle={styles.tabs}>
        {catalog.rooms.map((r) => (
          <Pressable key={r.k} onPress={() => onRoom(r.k)} style={[styles.tab, r.k === room && styles.tabOn]}>
            <Text style={[styles.tabText, r.k === room && styles.tabTextOn]}>{r.name}</Text>
          </Pressable>
        ))}
      </ScrollView>
      {msg ? (
        <View style={styles.msg}>
          <Text style={styles.msgText}>{msg}</Text>
        </View>
      ) : null}
      <ScrollView style={{ flex: 1 }} contentContainerStyle={{ paddingHorizontal: pad, paddingBottom: bottomPad + 16, gap: 16 }}>
        {sections.map((sec) => (
          <View key={sec.title} style={{ gap: 10 }}>
            <Text style={styles.secTitle}>{sec.title}</Text>
            <View style={{ flexDirection: 'row', flexWrap: 'wrap', gap }}>
              {sec.items.map((it) => (
                <Card key={it.id} it={it} home={home} level={level} coins={coins} width={cardW} onBuy={onBuy} />
              ))}
            </View>
          </View>
        ))}
      </ScrollView>
    </View>
  );
});

const styles = StyleSheet.create({
  page: { ...StyleSheet.absoluteFillObject, zIndex: 34, backgroundColor: '#f6e3c4' },
  head: { flexDirection: 'row', alignItems: 'center', gap: 10, paddingHorizontal: 16, paddingBottom: 8 },
  badge: { paddingHorizontal: 14, paddingVertical: 3, borderRadius: 12, borderWidth: 3, borderColor: INK, backgroundColor: '#c98a4b' },
  badgeText: { fontFamily: candyFonts.display, fontSize: 17, color: '#ffffff', textShadowColor: INK, textShadowRadius: 1, textShadowOffset: { width: 0, height: 2 } },
  level: { fontFamily: candyFonts.bodyBlack, fontSize: 11, color: SOFT },
  coins: { flexDirection: 'row', alignItems: 'center', gap: 5, backgroundColor: INK, borderWidth: 2, borderColor: '#ffffff', borderRadius: 999, paddingHorizontal: 12, paddingVertical: 4 },
  coinsText: { fontFamily: candyFonts.bodyBlack, fontSize: 14, color: '#fff3a0' },
  close: { width: 34, height: 34, borderRadius: 17, borderWidth: 2.5, borderColor: INK, backgroundColor: '#fff6e6', alignItems: 'center', justifyContent: 'center' },
  closeText: { fontFamily: candyFonts.bodyBlack, fontSize: 14, color: INK },
  tabs: { gap: 6, paddingHorizontal: 16, paddingTop: 2, paddingBottom: 10 },
  tab: { paddingHorizontal: 14, paddingVertical: 6, borderRadius: 999, borderWidth: 2.5, borderColor: INK, backgroundColor: '#fff8ee' },
  tabOn: { backgroundColor: INK },
  tabText: { fontFamily: candyFonts.display, fontSize: 13, color: INK },
  tabTextOn: { color: '#ffffff' },
  msg: { marginHorizontal: 16, marginBottom: 8, paddingHorizontal: 12, paddingVertical: 6, borderRadius: 12, backgroundColor: INK },
  msgText: { fontFamily: candyFonts.bodyBlack, fontSize: 12, color: '#ffffff', textAlign: 'center' },
  secTitle: { fontFamily: candyFonts.display, fontSize: 16, color: INK },
  card: { borderRadius: 20, backgroundColor: '#fff8ee', borderWidth: 3, borderColor: INK, padding: 10, gap: 4 },
  preview: { height: 96, borderRadius: 14, alignItems: 'center', justifyContent: 'center' },
  lockTag: { position: 'absolute', left: 8, top: 8, flexDirection: 'row', alignItems: 'center', gap: 4, paddingHorizontal: 8, paddingVertical: 2, borderRadius: 999, backgroundColor: INK },
  lockTagText: { fontFamily: candyFonts.bodyBlack, fontSize: 10, color: '#ffffff' },
  ownedTag: { position: 'absolute', right: 8, top: 8, paddingHorizontal: 8, paddingVertical: 2, borderRadius: 999, backgroundColor: GREEN },
  ownedTagText: { fontFamily: candyFonts.bodyBlack, fontSize: 10, color: '#ffffff' },
  name: { fontFamily: candyFonts.display, fontSize: 15, color: INK, marginTop: 2 },
  sub: { fontFamily: candyFonts.bodyHeavy, fontSize: 10, color: SOFT },
  perk: { fontFamily: candyFonts.bodyBlack, fontSize: 11, color: GREEN },
  ownedText: { fontFamily: candyFonts.bodyHeavy, fontSize: 11, color: SOFT, paddingVertical: 8 },
  lockBtn: { height: 34, borderRadius: 999, borderWidth: 2.5, borderStyle: 'dashed', borderColor: '#b8a08a', alignItems: 'center', justifyContent: 'center', marginTop: 2 },
  lockBtnText: { fontFamily: candyFonts.bodyBlack, fontSize: 11, color: SOFT },
  buy: { height: 34, flexDirection: 'row', alignItems: 'center', justifyContent: 'center', gap: 5, borderRadius: 999, borderWidth: 2.5, borderColor: INK, backgroundColor: '#ffd66b', marginTop: 2 },
  buyText: { fontFamily: candyFonts.display, fontSize: 14, color: INK },
});
