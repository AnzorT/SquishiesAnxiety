import React, { memo, useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { Animated, Easing, Image, ScrollView, StyleSheet, Text, View, useWindowDimensions } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Circle, Defs, Ellipse, Path, Pattern, RadialGradient, Rect, Stop } from 'react-native-svg';
import Pressable from '../components/Pressable';
import CandyBackground from '../components/candy/CandyBackground';
import RoundButton from '../components/candy/RoundButton';
import ShadowText from '../components/candy/ShadowText';
import RigCreature from '../components/RigCreature';
import { BY_ID, GROUPS, GROUP_INK, HIDDEN, RAR_LOOK, ROSTER, SET_REWARDS, copyProgress, isOut, owns, wallet } from '../squad/data';
import { isNewId, ownedIdList, selectedId } from '../squad/lobby';
import { COIN } from '../squad/currencyArt';
import { F, Ringed } from '../squad/ui';
import { fmtNum } from '../format';
import { useProgressive } from '../components/Skeleton';

// The Squad screen (the 2026-10-19 design's "Squad Select v2"), sliding up
// over the lobby: the squishy you're looking at, live (drag to spin), with
// its name, group and rarity and one big button — SELECTED, SELECT (it
// becomes the lobby's), or where it comes from (no coin price: chest copies
// are the only way to unlock, user 2026-10-24) — over a
// grid of all 86 but the ones not out yet (rig stills from the catalog's
// `thumb.url`): rarity chip,
// a lock and the copies found so far (a creature joins after its rarity's
// number of finds: functions/squad.js COPIES) when missing, a green tick on
// the selected one, NEW until looked at, a soft pink tile behind the one
// you're viewing. Rarest last, as the design sorts them (Rainbows, the sets' reward
// creatures, between Epic and Legendary).
//
// Growth stages and finishes (the old Squishies sheet) aren't on this
// screen in the design; the server still keeps both.

const OUTLINE = (c) => [[0, 2, c], [1.5, 0, c], [-1.5, 0, c], [0, -1, c]];
const NAME_SHADOWS = [[0, 3.5], [2.5, 0], [-2.5, 0], [0, -2.5], [2, 2], [-2, 2]].map(([x, y]) => [x, y, '#45107a']);
const TITLE_SHADOWS = [[0, 2.5], [1.5, 0], [-1.5, 0], [0, -1.5]].map(([x, y]) => [x, y, '#45107a']);
const GROUP_NAME = Object.fromEntries(GROUPS.map((g) => [g.key, g.name]));
const rank = (c) => (c.rar === 4 ? 2.5 : c.rar);
const ORDER = ROSTER.slice().sort((a, b) => rank(a) - rank(b) || Number(a.id) - Number(b.id));
const GREEN = ['#d8ffc2', '#6fe07a', '#26a94e'];
// a tile's floor shadow: the soft purple ellipse the tiles had as an SVG
// radial gradient, as one shared image (assets/squad/tile-floor.png). SVGs
// are drawn on the UI thread one by one: ~80 floors and ~70 locks showing
// at once were a 0.3 s hitch every time the Squad slid up (2026-10-28).
const FLOOR = require('../../assets/squad/tile-floor.png');

// --- the grid ---------------------------------------------------------------------

const Cell = memo(function Cell({ c, uri, mine, have, need, sel, fresh, on, onView, size }) {
  const r = RAR_LOOK[c.rar];
  return (
    <Pressable style={({ pressed }) => [styles.cell, size, pressed && { transform: [{ translateY: 2 }] }]} onPress={() => onView(c.id)}>
      {/* the one in view sits on a soft candy tile (the design's pink ring
          under it read as a hard bar, user 2026-10-24); every one has the
          same soft floor shadow */}
      {on ? (
        <View style={styles.tileOn} pointerEvents="none">
          <LinearGradient colors={['#fff6fd', '#ffe3f6']} style={StyleSheet.absoluteFill} />
        </View>
      ) : null}
      <Image source={FLOOR} style={styles.ground} resizeMode="stretch" fadeDuration={0} />
      {uri ? <Image source={{ uri }} style={[styles.thumb, !mine && styles.thumbLocked]} resizeMode="contain" fadeDuration={150} /> : null}
      {!mine && <CopyBar have={have} need={need} style={styles.cellCopies} />}
      {sel && (
        <View style={styles.tickWrap} pointerEvents="none">
          <LinearGradient colors={GREEN} locations={[0, 0.55, 1]} style={styles.tick}>
            <Svg width={12} height={10} viewBox="0 0 12 10">
              <Path d="M1.5 5 L4.5 8 L10.5 2" stroke="#ffffff" strokeWidth={2.4} fill="none" strokeLinecap="round" strokeLinejoin="round" />
            </Svg>
          </LinearGradient>
        </View>
      )}
      {fresh && (
        <View style={styles.newWrap} pointerEvents="none">
          <LinearGradient colors={['#ff8fd8', '#e0249f']} style={styles.newTag}>
            <Text style={styles.newText}>NEW</Text>
          </LinearGradient>
        </View>
      )}
      <View style={styles.cellFoot}>
        <View style={[styles.rarChip, { backgroundColor: r.bg }]}>
          <Text style={[styles.rarText, { color: r.ink }]} numberOfLines={1}>
            {r.label}
          </Text>
        </View>
        {!mine && (
          <View style={styles.lock}>
            <LockMini />
          </View>
        )}
      </View>
    </Pressable>
  );
});

// The copies found of one not unlocked yet: a candy bar with "2/5".
function CopyBar({ have, need, big = false, style }) {
  const pct = `${Math.round((Math.min(have, need) / Math.max(1, need)) * 100)}%`;
  return (
    <View style={[styles.copyRow, style]} pointerEvents="none">
      <View style={[styles.copyTrack, big && styles.copyTrackBig]}>
        {have > 0 ? <LinearGradient colors={['#ffd6f4', '#ff5cc6', '#c02bd9']} locations={[0, 0.45, 1]} style={[styles.copyFill, { width: pct }]} /> : null}
        {big ? (
          <Text style={styles.copyBigText}>{`FOUND ${Math.min(have, need)} / ${need}`}</Text>
        ) : null}
      </View>
      {big ? null : <Text style={styles.copyText}>{`${Math.min(have, need)}/${need}`}</Text>}
    </View>
  );
}

function LockGlyph({ size, color }) {
  return (
    <Svg width={size} height={size * 1.1} viewBox="0 0 13 14">
      <Rect x={1.5} y={6} width={10} height={7} rx={2} fill={color} />
      <Path d="M3.8 6 V4.2 A2.7 2.7 0 0 1 9.2 4.2 V6" stroke={color} strokeWidth={1.8} fill="none" />
    </Svg>
  );
}

// The tile's small lock, LockGlyph's shape at 10 px in plain views.
function LockMini() {
  return (
    <View style={styles.lockMini}>
      <View style={styles.lockShackle} />
      <View style={styles.lockBody} />
    </View>
  );
}

// The grid's own backdrop: purple dots every 14px on a white wash.
const GridBack = memo(function GridBack() {
  return (
    <Svg style={StyleSheet.absoluteFill} width="100%" height="100%" pointerEvents="none">
      <Defs>
        <Pattern id="ssDots" x="0" y="0" width="14" height="14" patternUnits="userSpaceOnUse">
          <Circle cx="1.5" cy="1.5" r="1.4" fill="#8f3cf2" fillOpacity={0.13} />
        </Pattern>
      </Defs>
      <Rect x="0" y="0" width="100%" height="100%" fill="#ffffff" fillOpacity={0.45} />
      <Rect x="0" y="0" width="100%" height="100%" fill="url(#ssDots)" />
    </Svg>
  );
});

// --- the hero ------------------------------------------------------------------

const HeroBack = memo(function HeroBack({ k = 1 }) {
  return (
    <>
      <Svg pointerEvents="none" width={230} height={230} style={[styles.heroGlow, { transform: [{ scale: k }] }]}>
        <Defs>
          <RadialGradient id="ssGlow" cx="50%" cy="50%" r="50%">
            <Stop offset="0" stopColor="#ffffff" stopOpacity={0.95} />
            <Stop offset="0.45" stopColor="#ffffff" stopOpacity={0.55} />
            <Stop offset="0.72" stopColor="#ffffff" stopOpacity={0} />
          </RadialGradient>
        </Defs>
        <Circle cx={115} cy={115} r={115} fill="url(#ssGlow)" />
      </Svg>
      <Svg pointerEvents="none" width={150} height={22} style={[styles.heroFloor, { bottom: 14 * k, transform: [{ scale: k }] }]}>
        <Defs>
          <RadialGradient id="ssFloor" cx="50%" cy="50%" r="50%">
            <Stop offset="0" stopColor="#45107a" stopOpacity={0.28} />
            <Stop offset="0.7" stopColor="#45107a" stopOpacity={0} />
          </RadialGradient>
        </Defs>
        <Ellipse cx={75} cy={11} rx={75} ry={11} fill="url(#ssFloor)" />
      </Svg>
    </>
  );
});

const ICONS = {
  lock: (lip) => <LockGlyph size={20} color={lip} />,
  gift: () => (
    <Svg width={22} height={22} viewBox="0 0 22 22">
      <Rect x={3} y={9} width={16} height={10} rx={2} fill="#6a22d6" />
      <Rect x={2} y={6} width={18} height={4.5} rx={1.5} fill="#8f3cf2" />
      <Rect x={9.7} y={6} width={2.6} height={13} fill="#ffd83a" />
      <Path d="M11 6 C8 1.5 4.5 3.5 7 6 M11 6 C14 1.5 17.5 3.5 15 6" stroke="#ffd83a" strokeWidth={2} fill="none" strokeLinecap="round" />
    </Svg>
  ),
};

// The big pill under the hero: a white disc with the icon, then the label.
// SELECT / SELECTED have no icon, so their label sits in the middle.
function MainButton({ m, onPress }) {
  const size = m.small ? 19 : m.price ? 21 : 24;
  return (
    <Pressable onPress={onPress} style={({ pressed }) => [styles.mainSlot, pressed && { transform: [{ translateY: 4 }, { scale: 0.98 }] }]}>
      <Ringed ring={m.lip} lip={6} ringW={2.5} border={3} radius={999} colors={m.bg} innerStyle={[styles.mainFace, !m.ic && styles.mainFaceBare]}>
        <LinearGradient pointerEvents="none" colors={['rgba(255,255,255,0.6)', 'rgba(255,255,255,0.04)']} style={[styles.mainShine, !m.ic && styles.mainShineBare]} />
        {m.ic ? (
          <View style={[styles.mainDiscLip, { backgroundColor: m.lip }]}>
            <View style={styles.mainDisc}>{ICONS[m.ic](m.lip)}</View>
          </View>
        ) : null}
        <View style={[styles.mainLabels, !m.ic && styles.mainLabelsBare]}>
          <ShadowText style={[styles.mainText, { fontSize: size, lineHeight: size + 4, color: m.ink }]} shadows={m.ts ? OUTLINE(m.ts) : []} numberOfLines={1}>
            {m.label}
          </ShadowText>
          {m.price ? (
            <ShadowText style={styles.mainPrice} shadows={OUTLINE(m.ts)}>
              {m.price}
            </ShadowText>
          ) : null}
        </View>
      </Ringed>
    </Pressable>
  );
}

// `hidden`: the groups and creatures not out yet (config/roster), left out
// of the grid unless owned. `setRewards`: a set's reward creature comes from
// finishing the set (else from its group's chests).
// `onBuilt()`: once every tile is built (the lobby lets it sleep then)
function SquadScreen({ active = true, profile, creatures, hidden = HIDDEN, setRewards = SET_REWARDS, onClose, onSelect, onSeen, onBuilt }) {
  const insets = useSafeAreaInsets();
  const sel = selectedId(profile);
  const [view, setView] = useState(sel);
  const [toast, setToast] = useState(null);
  const w = wallet(profile);
  const catalog = useMemo(() => Object.fromEntries((creatures || []).map((c) => [c.id, c])), [creatures]);
  const ownedN = ownedIdList(profile).filter((id) => BY_ID[id]).length;
  const shown = useMemo(() => ORDER.filter((x) => isOut(x, hidden) || owns(profile || {}, x.id)), [profile, hidden]);
  // what each tile shows, worked out once per profile (not on every render)
  const tileInfo = useMemo(
    () =>
      shown.map((x) => {
        const p = copyProgress(profile, x.id);
        return { x, mine: owns(profile || {}, x.id), have: p.have, need: p.need, fresh: isNewId(profile, x.id) };
      }),
    [shown, profile],
  );
  // the grid's tiles a few a frame (first build only), never all at once
  const tiles = useProgressive(shown.length, 12, 8);
  const built = tiles >= shown.length;
  useEffect(() => {
    if (built && onBuilt) onBuilt();
  }, [built, onBuilt]);
  // 4 columns, 9px apart, 12px from the edges; each 0.84 as wide as tall
  const { width: winW } = useWindowDimensions();
  // The hero's stage gives way on short pages (the banner ad takes room the
  // design doesn't have), so the grid keeps about two rows in view.
  const [pageH, setPageH] = useState(0);
  const onRoot = useCallback((e) => {
    const h = e.nativeEvent.layout.height;
    if (h > 0) setPageH(h);
  }, []);
  const stageH = pageH ? Math.max(150, Math.min(236, Math.round(pageH - 470))) : 236;
  const heroSize = stageH - 10;
  const cellSize = useMemo(() => {
    const cw = Math.floor(((winW - 24 - 27) / 4) * 10) / 10;
    return { width: cw, height: Math.round((cw / 0.84) * 10) / 10 };
  }, [winW]);

  const flash = useCallback((text) => setToast({ text, key: Date.now() }), []);
  useEffect(() => {
    if (!toast) return undefined;
    const t = setTimeout(() => setToast(null), 2200);
    return () => clearTimeout(t);
  }, [toast]);

  // the one in view isn't NEW any more (the selected one too, on opening)
  const profileRef = useRef(profile);
  profileRef.current = profile;
  useEffect(() => {
    if (isNewId(profileRef.current, view)) onSeen(view);
  }, [view, onSeen]);

  // A new squishy pops in: squashed small, stretches up, settles (the
  // design's reveal); the rig swaps creatures under the first, hidden third.
  const pop = useRef(new Animated.Value(1)).current;
  // stable, so a tap re-renders only the two cells whose ring moves
  const viewRef = useRef(view);
  viewRef.current = view;
  const viewNow = useCallback(
    (id) => {
      if (id === viewRef.current) return;
      setView(id);
      pop.setValue(0);
      Animated.timing(pop, { toValue: 1, duration: 520, easing: Easing.bezier(0.3, 1.5, 0.5, 1), useNativeDriver: true }).start();
    },
    [pop],
  );
  const popStyle = {
    opacity: pop.interpolate({ inputRange: [0, 0.3, 0.62, 1], outputRange: [0, 0, 1, 1] }),
    transform: [
      { translateY: pop.interpolate({ inputRange: [0, 0.3, 0.62, 0.8, 1], outputRange: [40, 40, -14, 0, 0] }) },
      { scaleX: pop.interpolate({ inputRange: [0, 0.3, 0.62, 0.8, 1], outputRange: [0.25, 0.25, 0.9, 1.1, 1] }) },
      { scaleY: pop.interpolate({ inputRange: [0, 0.3, 0.62, 0.8, 1], outputRange: [0.25, 0.25, 1.18, 0.9, 1] }) },
    ],
  };

  // The live hero is made each time the screen is up (once its slide is
  // over) and let go when it closes. The app's WebViews share Chromium's tile
  // memory: one made off screen and asleep never drew, and one kept while
  // closed left the lobby's own creature blank when it came back ("tile
  // memory limits exceeded", 2026-10-28). The creature's still shows until
  // the rig has drawn.
  const rig = useRef(null);
  const [rigLive, setRigLive] = useState(false);
  const [rigDrawn, setRigDrawn] = useState(false);
  useEffect(() => {
    if (!active) {
      setRigLive(false);
      setRigDrawn(false);
      return undefined;
    }
    const t = setTimeout(() => setRigLive(true), 450);
    return () => clearTimeout(t);
  }, [active]);
  const onRigDrawn = useCallback(() => setRigDrawn(true), []);
  const c = BY_ID[view];
  const own = owns(profile || {}, view);
  const isSel = own && view === sel;
  const R = RAR_LOOK[c.rar];
  const group = GROUP_NAME[c.set];
  const prog = copyProgress(profile, view);
  const more = Math.max(1, prog.need - prog.have);
  const findMore = `Find ${more} more ${more === 1 ? 'copy' : 'copies'}`;

  let m;
  if (isSel) m = { label: 'SELECTED', bg: ['#ffffff', '#f4fdf1', '#eafbe4'], lip: '#6fbf7e', ink: '#26a94e', tap: () => flash(`${c.name} is in your lobby`) };
  else if (own)
    m = {
      label: 'SELECT',
      bg: GREEN,
      lip: '#17652f',
      ink: '#ffffff',
      ts: '#17652f',
      tap: () => {
        onSelect(c.id);
        flash(`${c.name} is in your lobby`);
        rig.current?.play('happy');
      },
    };
  else {
    // not yet: only chests unlock it, by its copies (no coin price)
    const viaSet = c.reward && setRewards;
    m = {
      ic: 'gift',
      label: viaSet ? 'SET REWARD' : c.season ? 'SEASON CHEST' : 'FROM CHESTS',
      bg: ['#ffffff', '#f7f2fd', '#efe6fb'],
      lip: '#b8a0dc',
      ink: '#6a22d6',
      small: true,
      note: viaSet
        ? `Collect the whole ${group} set to get ${c.name}.`
        : c.season
          ? `${findMore} in Spooky Squish season chests.`
          : `${findMore} in ${group} chests in the shop to unlock ${c.name}.`,
      tap: () => flash(viaSet ? `Finish the ${group} set first` : `${findMore} in ${c.season ? 'season' : group} chests`),
    };
  }

  return (
    <CandyBackground style={{ paddingTop: insets.top }}>
      <View style={StyleSheet.absoluteFill} onLayout={onRoot} pointerEvents="none" />
      <View style={styles.head}>
        <RoundButton size={42} onPress={onClose}>
          <Svg width={20} height={20} viewBox="0 0 24 24">
            <Path d="M15 5.5 L7 13.5 L15 21.5" stroke="#45189a" strokeWidth={4} fill="none" strokeLinecap="round" strokeLinejoin="round" />
            <Path d="M15 4 L7 12 L15 20" stroke="#ffffff" strokeWidth={4} fill="none" strokeLinecap="round" strokeLinejoin="round" />
          </Svg>
        </RoundButton>
        <View style={styles.headText}>
          <ShadowText style={styles.title} shadows={TITLE_SHADOWS}>
            Squad
          </ShadowText>
          <Text style={styles.have}>{`${ownedN} / ${shown.length} collected`}</Text>
        </View>
        <Ringed ring="#8e1580" lip={3} ringW={2} border={2.5} style={styles.coinPill} innerStyle={styles.purse}>
          <Image source={COIN[0]} style={styles.coinImg} fadeDuration={0} />
          <Text style={styles.purseText}>{fmtNum(w.coins)}</Text>
        </Ringed>
      </View>

      <View style={styles.hero}>
        <ShadowText style={styles.heroName} shadows={NAME_SHADOWS} numberOfLines={1}>
          {c.name}
        </ShadowText>
        <View style={styles.heroTags}>
          <Text style={[styles.heroGroup, { color: GROUP_INK[c.set] || '#45107a' }]}>{group}</Text>
          <View style={[styles.heroRar, { backgroundColor: R.bg }]}>
            <Text style={[styles.heroRarText, { color: R.ink }]}>{R.label}</Text>
          </View>
        </View>
        <View style={[styles.heroStage, { height: stageH }]}>
          <HeroBack k={stageH / 236} />
          <Animated.View style={[{ width: heroSize, height: heroSize }, popStyle]}>
            {!rigDrawn && catalog[view]?.thumb?.url ? <Image source={{ uri: catalog[view].thumb.url }} style={StyleSheet.absoluteFill} resizeMode="contain" fadeDuration={0} /> : null}
            {rigLive ? <RigCreature ref={rig} creatureKey={c.key} paused={!active} rigShadow={false} onMounted={onRigDrawn} style={{ width: heroSize, height: heroSize }} /> : null}
          </Animated.View>
          <View style={styles.spinHint} pointerEvents="none">
            <Svg width={16} height={10} viewBox="0 0 16 10">
              <Path d="M1 5 H15 M4 2 L1 5 L4 8 M12 2 L15 5 L12 8" stroke="#6a4a9a" strokeWidth={1.6} fill="none" strokeLinecap="round" strokeLinejoin="round" />
            </Svg>
            <Text style={styles.spinText}>Drag to spin</Text>
          </View>
          {!own && !(c.reward && setRewards) ? <CopyBar big have={prog.have} need={prog.need} style={styles.heroCopies} /> : null}
        </View>
        <MainButton m={m} onPress={m.tap} />
        {m.note ? <Text style={styles.note}>{m.note}</Text> : null}
      </View>

      <View style={styles.divider} />
      <View style={styles.gridBox}>
        <GridBack />
        {/* tiles scrolled out of sight are taken out of the drawing: with all
            ~80 in it, every frame of the live hero re-prepared every tile's
            picture (66 ms a frame, the screen at ~25 fps on the Galaxy A15,
            2026-10-28) */}
        <ScrollView contentContainerStyle={styles.grid} showsVerticalScrollIndicator={false} removeClippedSubviews>
          {tileInfo.slice(0, tiles).map(({ x, mine, have, need, fresh }) => (
            <Cell
              key={x.id}
              c={x}
              uri={catalog[x.id]?.thumb?.url || null}
              mine={mine}
              have={have}
              need={need}
              sel={x.id === sel}
              fresh={fresh}
              on={x.id === view}
              onView={viewNow}
              size={cellSize}
            />
          ))}
        </ScrollView>
      </View>

      {toast && (
        <View style={styles.toast} pointerEvents="none">
          <Text style={styles.toastText}>{toast.text}</Text>
        </View>
      )}
    </CandyBackground>
  );
}

const styles = StyleSheet.create({
  head: { flexDirection: 'row', alignItems: 'center', gap: 8, paddingTop: 10, paddingHorizontal: 14, paddingBottom: 4 },
  headText: { gap: 1, minWidth: 0 },
  title: { fontFamily: F.display, fontSize: 22, lineHeight: 25, color: '#ffffff', includeFontPadding: false },
  have: { fontFamily: F.black, fontSize: 11, color: '#45107a' },
  coinPill: { marginLeft: 'auto' },
  purse: { flexDirection: 'row', alignItems: 'center', gap: 5, paddingLeft: 7, paddingRight: 9, paddingVertical: 4 },
  coinImg: { width: 22, height: 22, marginVertical: -5, marginLeft: -4 },
  purseText: { fontFamily: F.black, fontSize: 13.5, color: '#b86200', includeFontPadding: false },
  hero: { alignItems: 'center', paddingTop: 2, paddingHorizontal: 16, paddingBottom: 12 },
  heroName: { fontFamily: F.display, fontSize: 34, lineHeight: 38, color: '#ffffff', textAlign: 'center', includeFontPadding: false },
  heroTags: { flexDirection: 'row', alignItems: 'center', gap: 6, marginTop: 4 },
  heroGroup: { fontFamily: F.display, fontSize: 16, includeFontPadding: false },
  heroRar: { borderRadius: 999, paddingHorizontal: 8, paddingVertical: 1, borderWidth: 2, borderColor: '#ffffff' },
  heroRarText: { fontFamily: F.black, fontSize: 10, letterSpacing: 0.6 },
  heroStage: { width: '100%', alignItems: 'center', justifyContent: 'center' },
  heroGlow: { position: 'absolute', left: '50%', top: '50%', marginLeft: -115, marginTop: -115 },
  heroFloor: { position: 'absolute', left: '50%', bottom: 14, marginLeft: -75 },
  spinHint: { position: 'absolute', right: 4, bottom: 6, flexDirection: 'row', alignItems: 'center', gap: 4 },
  spinText: { fontFamily: F.heavy, fontSize: 10.5, color: '#6a4a9a' },
  mainSlot: { width: '100%', maxWidth: 230 + 5 },
  mainFace: { height: 64, flexDirection: 'row', alignItems: 'center', gap: 10, paddingLeft: 8, paddingRight: 18 },
  mainFaceBare: { paddingLeft: 18 },
  mainShine: { position: 'absolute', left: 46, right: '8%', top: 3, height: '38%', borderRadius: 999 },
  mainShineBare: { left: '8%' },
  mainDiscLip: { borderRadius: 22, paddingBottom: 3, marginBottom: -3 },
  mainDisc: { width: 44, height: 44, borderRadius: 22, backgroundColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  mainLabels: { flex: 1, minWidth: 0, alignItems: 'flex-start', gap: 2 },
  mainLabelsBare: { alignItems: 'center' },
  mainText: { fontFamily: F.display, letterSpacing: 1, includeFontPadding: false },
  mainPrice: { fontFamily: F.display, fontSize: 14, lineHeight: 17, color: '#ffffff', includeFontPadding: false },
  note: { marginTop: 7, maxWidth: 260, fontFamily: F.heavy, fontSize: 11.5, lineHeight: 15, color: '#45107a', textAlign: 'center' },
  divider: { height: 3, backgroundColor: '#ffffff', zIndex: 3, borderBottomWidth: 1, borderBottomColor: 'rgba(201,176,236,0.9)', elevation: 4, shadowColor: '#45107a' },
  gridBox: { flex: 1, minHeight: 0 },
  grid: { flexDirection: 'row', flexWrap: 'wrap', gap: 9, paddingTop: 12, paddingHorizontal: 12, paddingBottom: 24 },
  cell: { alignItems: 'center', justifyContent: 'flex-end', paddingBottom: 2 },
  ground: { position: 'absolute', left: '14%', right: '14%', bottom: '17%', height: '13%' },
  tileOn: { position: 'absolute', left: -4, right: -4, top: -4, bottom: -3, borderRadius: 18, borderWidth: 2.5, borderColor: '#ffb3e4', overflow: 'hidden' },
  thumb: { position: 'absolute', left: '4%', right: '4%', top: 0, height: '78%' },
  thumbLocked: { opacity: 0.72 },
  copyRow: { flexDirection: 'row', alignItems: 'center', gap: 3 },
  copyTrack: { flex: 1, height: 7, borderRadius: 4, backgroundColor: 'rgba(69,16,122,0.16)', borderWidth: 1.5, borderColor: '#ffffff', overflow: 'hidden', justifyContent: 'center' },
  copyTrackBig: { height: 22, borderRadius: 11, borderWidth: 2.5, backgroundColor: 'rgba(69,16,122,0.2)' },
  copyFill: { position: 'absolute', left: 0, top: 0, bottom: 0, borderRadius: 999 },
  copyText: { fontFamily: F.black, fontSize: 8.5, color: '#45107a', includeFontPadding: false },
  copyBigText: { textAlign: 'center', fontFamily: F.display, fontSize: 12, letterSpacing: 0.8, color: '#ffffff', textShadowColor: '#45107a', textShadowOffset: { width: 0, height: 1.5 }, textShadowRadius: 1, includeFontPadding: false },
  cellCopies: { position: 'absolute', left: '9%', right: '9%', bottom: 19 },
  heroCopies: { position: 'absolute', bottom: 2, width: '54%', maxWidth: 220 },
  tickWrap: { position: 'absolute', left: -2, top: -2, borderRadius: 999, backgroundColor: '#17652f', paddingBottom: 2 },
  tick: { width: 22, height: 22, borderRadius: 11, borderWidth: 2, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  newWrap: { position: 'absolute', right: -4, top: -4, borderTopLeftRadius: 9, borderTopRightRadius: 9, borderBottomRightRadius: 9, borderBottomLeftRadius: 2, backgroundColor: '#8e1580', paddingBottom: 2 },
  newTag: { borderTopLeftRadius: 9, borderTopRightRadius: 9, borderBottomRightRadius: 9, borderBottomLeftRadius: 2, borderWidth: 2, borderColor: '#ffffff', paddingHorizontal: 6, paddingVertical: 1 },
  newText: { fontFamily: F.display, fontSize: 10, lineHeight: 12, letterSpacing: 0.5, color: '#ffffff', includeFontPadding: false },
  cellFoot: { maxWidth: '100%', flexDirection: 'row', alignItems: 'center', gap: 3 },
  rarChip: { flexShrink: 1, minWidth: 0, borderRadius: 999, paddingHorizontal: 6, paddingVertical: 1, borderWidth: 1.5, borderColor: '#ffffff', borderBottomColor: 'rgba(69,16,122,0.18)' },
  rarText: { fontFamily: F.black, fontSize: 8, letterSpacing: 0.5 },
  lock: { width: 16, height: 16, borderRadius: 8, backgroundColor: '#ffffff', borderWidth: 1.5, borderColor: '#c9b0ec', borderBottomWidth: 3, alignItems: 'center', justifyContent: 'center' },
  // LockGlyph (viewBox 13×14) at 10 px: the shackle's arc, the body
  lockMini: { width: 10, height: 11, alignItems: 'center' },
  lockShackle: { width: 5.5, height: 4.3, marginTop: 0.5, borderWidth: 1.4, borderBottomWidth: 0, borderColor: '#8a6ab8', borderTopLeftRadius: 2.75, borderTopRightRadius: 2.75 },
  lockBody: { width: 7.7, height: 5.4, borderRadius: 1.5, backgroundColor: '#8a6ab8' },
  toast: { position: 'absolute', alignSelf: 'center', bottom: 26, maxWidth: '86%', paddingHorizontal: 16, paddingVertical: 10, borderRadius: 16, backgroundColor: '#45107a', borderWidth: 2.5, borderColor: '#ffffff', zIndex: 9 },
  toastText: { fontFamily: F.heavy, fontSize: 13, lineHeight: 17, color: '#ffffff', textAlign: 'center' },
});

export default memo(SquadScreen);
