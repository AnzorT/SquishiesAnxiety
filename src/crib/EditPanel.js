import React, { memo, useEffect, useRef } from 'react';
import { Animated, Pressable, ScrollView, StyleSheet, Text, View } from 'react-native';
import Svg, { Path } from 'react-native-svg';
import { candyFonts } from '../theme/candyTheme';
import { INK, SOFT } from './ui';
import { FitSvg, ItemIcon } from './Shop';
import { ThemeSwatch } from './art';
import catalog from './catalog';
import { EXTRAS, GAMES, ITEMS, PADS, THEMES, ownedDecor, slotsIn, themeIdx, themeOwned } from './home';

// Edit mode's panel (the design's "Edit {room}" panel in "Squad Crib v5" and
// "Squad Crib Vertical"): three tabs —
//   Furniture (Games in the yard): each slot's tiers to swap between (the
//     yard: what's on each of its four play spots), bath stations — any
//     piece can be dragged around the room itself;
//   Decor: the room's decor, to put away or bring back (dragging is in the
//     room itself);
//   Walls & floor (Ground in the yard): the room's walls, floors and
//     ceilings, from bare to luxurious.
// Things not owned yet open the shop.
// Landscape: a strip along the bottom that scrolls sideways and can be
// tucked away (its arrow tab stays on the bottom edge to pull it back up);
// portrait: it takes over the room dock's whole place, edge to edge, and
// scrolls down.

const GREEN = '#4f9a3a';
const roomName = (room) => (catalog.rooms.find((r) => r.k === room) || { name: '' }).name;
const EMPTY = '<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 40 30"><rect x="4" y="4" width="32" height="22" rx="6" fill="none" stroke="#b8a08a" stroke-width="2.5" stroke-dasharray="4 3"/></svg>';

// a swappable option: the item's picture, green when in use, a tag for
// what's missing (a level or a price)
function Opt({ id, svg, on, owned = true, tag, onPress, w, h }) {
  return (
    <Pressable onPress={onPress} style={[styles.opt, { width: w, height: h, borderColor: on ? GREEN : INK, backgroundColor: on ? '#e3f1d4' : owned ? '#ffffff' : '#f1e6d6', opacity: owned ? 1 : 0.55 }]}>
      {svg ? <FitSvg svg={svg} w={w - 8} h={h - 8} /> : <ItemIcon id={id} w={w - 8} h={h - 8} />}
      {tag ? (
        <View style={styles.optTag}>
          <Text style={styles.optTagText}>{tag}</Text>
        </View>
      ) : null}
    </Pressable>
  );
}

function Furniture({ home, room, level, onEquip, onPlace, onShop, vertical }) {
  const optSize = { w: vertical ? 56 : 48, h: vertical ? 44 : 40 };
  const tagOf = (it) => (home.own[it.id] ? null : level < it.lvl ? `LV ${it.lvl}` : String(it.coins));
  const groups = [];
  if (room === 'yard') {
    PADS.forEach((p, k) => {
      const g = home.pads[p.k];
      const opts = [<Opt key="empty" svg={EMPTY} on={!g} onPress={() => onPlace(p.k, null)} {...optSize} />];
      GAMES.filter((G) => !G.pad || G.pad === p.k).forEach((G) => {
        const it = ITEMS[G.itemId];
        const owned = !!home.own[G.itemId];
        opts.push(<Opt key={G.id} id={G.itemId} on={g === G.id} owned={owned} tag={tagOf(it)} onPress={() => (owned ? onPlace(p.k, G.id) : onShop())} {...optSize} />);
      });
      groups.push({ key: p.k, name: `Play spot ${k + 1}`, effect: g ? ITEMS[`g_${g}`].name : 'Empty', opts });
    });
  } else {
    slotsIn(room).forEach((sl) => {
      const cur = ITEMS[home.eq[sl.key]];
      groups.push({
        key: sl.key,
        name: sl.name,
        effect: cur ? cur.effect : '',
        opts: sl.tiers.map((t) => {
          const owned = !!home.own[t.id];
          return <Opt key={t.id} id={t.id} on={home.eq[sl.key] === t.id} owned={owned} tag={tagOf(ITEMS[t.id])} onPress={() => (owned ? onEquip(sl.key, t.id) : onShop())} {...optSize} />;
        }),
      });
    });
    if (room === 'bath') {
      groups.push({
        key: 'extras',
        name: 'Bath stations',
        effect: 'Owned stations are always on',
        opts: EXTRAS.map((e) => <Opt key={e.id} id={e.id} on={!!home.own[e.id]} owned={!!home.own[e.id]} tag={tagOf(ITEMS[e.id])} onPress={() => (home.own[e.id] ? null : onShop())} {...optSize} />),
      });
    }
  }
  return groups.map((g) => (
    <View key={g.key} style={[styles.group, !vertical && { minWidth: 240 }]}>
      <View style={styles.groupHead}>
        <Text style={styles.groupName}>{g.name}</Text>
        <Text style={styles.groupEffect} numberOfLines={1}>
          {g.effect}
        </Text>
      </View>
      <View style={[styles.optRow, vertical && { flexWrap: 'wrap' }]}>{g.opts}</View>
    </View>
  ));
}

function Decor({ home, room, onStore, vertical }) {
  const list = ownedDecor(home, room);
  return (
    <>
      <Text style={[styles.hint, !vertical && { width: 130 }]}>Drag anything in the room to move it — furniture too.</Text>
      {!list.length ? <Text style={styles.empty}>No decor yet. Find some in the shop.</Text> : null}
      {list.map((d) => {
        const placed = !home.stored[d.id];
        return (
          <View key={d.id} style={[styles.decorRow, !vertical && { width: 230 }]}>
            <ItemIcon id={d.id} w={36} h={30} />
            <View style={{ flex: 1, minWidth: 0 }}>
              <Text style={styles.decorName} numberOfLines={1}>
                {d.name}
              </Text>
              <Text style={styles.decorPerk}>{d.perkText}</Text>
            </View>
            <Pressable onPress={() => onStore(d.id)} style={[styles.smallBtn, { backgroundColor: placed ? '#ffffff' : '#c9e8a8' }]}>
              <Text style={styles.smallBtnText}>{placed ? 'Store' : 'Place'}</Text>
            </Pressable>
          </View>
        );
      })}
    </>
  );
}

function Walls({ home, room, level, onTheme, onShop, vertical }) {
  const T = THEMES[room] || {};
  const names = { wall: 'Wall', floor: room === 'yard' ? 'Ground' : 'Floor', ceil: 'Ceiling' };
  return ['wall', 'floor', 'ceil']
    .filter((k) => T[k])
    .map((k) => (
      <View key={k} style={styles.group}>
        <Text style={styles.groupName}>{names[k]}</Text>
        <View style={[styles.optRow, { flexWrap: vertical ? 'wrap' : 'nowrap' }]}>
          {T[k].map((t, i) => {
            const owned = themeOwned(home, room, k, i);
            const on = themeIdx(home, room, k) === i;
            const sw = vertical ? 96 : 56;
            const tag = owned ? null : level < t.lvl ? `LV ${t.lvl}` : String(t.coins);
            return (
              <Pressable key={i} onPress={() => (owned ? onTheme(k, i) : onShop())} style={[styles.swatch, { width: sw, borderColor: on ? GREEN : INK, opacity: owned ? 1 : 0.55 }]}>
                <ThemeSwatch room={room} kind={k} theme={t} width={sw - 10} height={vertical ? 26 : 18} />
                <Text style={styles.swatchName} numberOfLines={1}>
                  {t.name}
                </Text>
                {tag ? (
                  <View style={styles.optTag}>
                    <Text style={styles.optTagText}>{tag}</Text>
                  </View>
                ) : null}
              </Pressable>
            );
          })}
        </View>
      </View>
    ));
}

function Arrow({ up }) {
  return (
    <Svg width={18} height={18} viewBox="0 0 24 24" style={{ transform: [{ rotate: up ? '0deg' : '180deg' }] }}>
      <Path d="M6 15 L12 9 L18 15" stroke={INK} strokeWidth={3.2} fill="none" strokeLinecap="round" strokeLinejoin="round" />
    </Svg>
  );
}

// (`homeRev` only tells memo the home changed: it changes in place)
export const EditPanel = memo(function EditPanel({ home, room, level, tab, onTab, onEquip, onPlace, onStore, onTheme, onShop, onDone, vertical, hidden, onToggleHidden, bottomPad = 8 }) {
  const tabs = [
    ['furn', room === 'yard' ? 'Games' : 'Furniture'],
    ['decor', 'Decor'],
    ['walls', room === 'yard' ? 'Ground' : 'Walls & floor'],
  ];
  const body =
    tab === 'decor' ? (
      <Decor home={home} room={room} onStore={onStore} vertical={vertical} />
    ) : tab === 'walls' ? (
      <Walls home={home} room={room} level={level} onTheme={onTheme} onShop={onShop} vertical={vertical} />
    ) : (
      <Furniture home={home} room={room} level={level} onEquip={onEquip} onPlace={onPlace} onShop={onShop} vertical={vertical} />
    );
  const tabRow = (
    <View style={[styles.tabs, !vertical && { width: 300 }]}>
      {tabs.map(([k, l]) => (
        <Pressable key={k} onPress={() => onTab(k)} style={[styles.tab, k === tab && styles.tabOn]}>
          <Text style={[styles.tabText, k === tab && styles.tabTextOn]} numberOfLines={1}>
            {l}
          </Text>
        </Pressable>
      ))}
    </View>
  );
  const buttons = (
    <>
      <Pressable onPress={onShop} style={[styles.headBtn, { backgroundColor: '#c9b6f0' }]}>
        <Text style={styles.headBtnText}>Shop</Text>
      </Pressable>
      <Pressable onPress={onDone} style={[styles.headBtn, { backgroundColor: '#7fae6a' }]}>
        <Text style={[styles.headBtnText, { color: '#ffffff' }]}>Done</Text>
      </Pressable>
    </>
  );

  // landscape: tucks away downwards
  const slide = useRef(new Animated.Value(hidden ? 1 : 0)).current;
  useEffect(() => {
    Animated.timing(slide, { toValue: hidden ? 1 : 0, duration: 300, useNativeDriver: true }).start();
  }, [hidden, slide]);

  if (vertical) {
    return (
      <View style={[styles.panel, styles.vertical, { paddingBottom: bottomPad + 10 }]}>
        <View style={styles.headRow}>
          <Text style={[styles.title, { flex: 1 }]} numberOfLines={1}>{`Edit ${roomName(room)}`}</Text>
          {buttons}
        </View>
        {tabRow}
        <ScrollView style={{ flex: 1 }} contentContainerStyle={{ gap: 9, paddingBottom: 6 }} showsVerticalScrollIndicator={false}>
          {body}
        </ScrollView>
      </View>
    );
  }
  const PANEL_H = 120;
  return (
    <Animated.View pointerEvents="box-none" style={[styles.landWrap, { bottom: bottomPad, transform: [{ translateY: slide.interpolate({ inputRange: [0, 1], outputRange: [0, PANEL_H + bottomPad - 3] }) }] }]}>
      <Pressable onPress={onToggleHidden} style={styles.tuck}>
        <Arrow up={hidden} />
      </Pressable>
      <View style={[styles.panel, { height: PANEL_H }]}>
        <View style={styles.headRow}>
          <Text style={styles.title} numberOfLines={1}>{`Edit ${roomName(room)}`}</Text>
          {tabRow}
          <View style={{ flex: 1 }} />
          {buttons}
        </View>
        <ScrollView horizontal showsHorizontalScrollIndicator={false} style={{ flex: 1 }} contentContainerStyle={{ gap: 16, alignItems: 'flex-start', paddingBottom: 2 }}>
          {body}
        </ScrollView>
      </View>
    </Animated.View>
  );
});

const styles = StyleSheet.create({
  landWrap: { position: 'absolute', left: 14, right: 14, zIndex: 26, alignItems: 'center' },
  tuck: { width: 56, height: 24, borderTopLeftRadius: 14, borderTopRightRadius: 14, borderWidth: 3, borderBottomWidth: 0, borderColor: INK, backgroundColor: '#fff8ee', alignItems: 'center', justifyContent: 'center', marginBottom: -3, zIndex: 1 },
  panel: { alignSelf: 'stretch', borderRadius: 22, backgroundColor: '#fff8ee', borderWidth: 3, borderColor: INK, paddingHorizontal: 12, paddingVertical: 6, gap: 5, overflow: 'hidden' },
  vertical: { flex: 1, borderRadius: 0, borderWidth: 0, paddingHorizontal: 14, paddingTop: 12, gap: 10 },
  headRow: { flexDirection: 'row', alignItems: 'center', gap: 6 },
  title: { fontFamily: candyFonts.display, fontSize: 16, color: INK },
  tabs: { flexDirection: 'row', gap: 5 },
  tab: { flex: 1, minWidth: 0, height: 28, borderRadius: 999, borderWidth: 2, borderColor: INK, backgroundColor: '#ffffff', alignItems: 'center', justifyContent: 'center', paddingHorizontal: 4 },
  tabOn: { backgroundColor: INK },
  tabText: { fontFamily: candyFonts.display, fontSize: 11, color: INK },
  tabTextOn: { color: '#ffffff' },
  headBtn: { height: 30, paddingHorizontal: 12, borderRadius: 999, borderWidth: 2.5, borderColor: INK, alignItems: 'center', justifyContent: 'center' },
  headBtnText: { fontFamily: candyFonts.display, fontSize: 12, color: INK },
  group: { gap: 5 },
  groupHead: { flexDirection: 'row', alignItems: 'baseline', justifyContent: 'space-between', gap: 6 },
  groupName: { fontFamily: candyFonts.bodyBlack, fontSize: 12, color: INK },
  groupEffect: { flexShrink: 1, fontFamily: candyFonts.bodyHeavy, fontSize: 10, color: GREEN, textAlign: 'right' },
  optRow: { flexDirection: 'row', gap: 5 },
  opt: { borderRadius: 10, borderWidth: 2.5, padding: 2, alignItems: 'center', justifyContent: 'center' },
  optTag: { position: 'absolute', right: -4, top: -6, paddingHorizontal: 4, height: 14, borderRadius: 7, backgroundColor: INK, justifyContent: 'center' },
  optTagText: { fontFamily: candyFonts.bodyBlack, fontSize: 8, color: '#ffffff' },
  hint: { fontFamily: candyFonts.bodyHeavy, fontSize: 11, color: SOFT },
  empty: { fontFamily: candyFonts.bodyHeavy, fontSize: 12, color: INK, paddingVertical: 10 },
  decorRow: { flexDirection: 'row', alignItems: 'center', gap: 8, paddingHorizontal: 6, paddingVertical: 4, borderRadius: 12, backgroundColor: '#ffffff', borderWidth: 2, borderColor: '#ead8bf' },
  decorName: { fontFamily: candyFonts.display, fontSize: 13, color: INK },
  decorPerk: { fontFamily: candyFonts.bodyHeavy, fontSize: 10, color: GREEN },
  smallBtn: { height: 28, paddingHorizontal: 12, borderRadius: 999, borderWidth: 2, borderColor: INK, alignItems: 'center', justifyContent: 'center' },
  smallBtnText: { fontFamily: candyFonts.display, fontSize: 12, color: INK },
  swatch: { padding: 3, gap: 2, borderRadius: 10, borderWidth: 2.5, backgroundColor: '#ffffff', alignItems: 'center' },
  swatchName: { fontFamily: candyFonts.bodyBlack, fontSize: 9, color: INK },
});
