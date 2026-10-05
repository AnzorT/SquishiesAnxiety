import React, { memo } from 'react';
import { StyleSheet, Text, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Circle, Defs, LinearGradient as SvgLinearGradient, Path, Pattern, RadialGradient, Rect, Stop } from 'react-native-svg';
import { TIERS, candyFonts } from '../../theme/candyTheme';

// The Key Shop's stalls, one per rarity, drawn as the v3 design draws them
// ("ASMR Creature Squash v3.dc.html", storeSections): a rounded stall in the
// rarity's trim colour with a white rim, a striped awning ending in
// scallops, a wooden sign across its top edge ("Common Corner" and how many
// you own), a striped back wall, the creatures two to a row each standing on
// a wooden shelf, and a striped strip along the bottom.
//
// A stall is a stack of fixed-height pieces — StallTop, one StallRow per
// row of two, StallBottom — so the shop's FlatList can build it a row at a
// time and jump straight to any row. The wall's gradient runs over the whole
// stall: each piece gets its slice (`from`/`to`, fractions of the stall).

export const TIER_ORDER = ['Common', 'Rare', 'Epic', 'Legendary', 'Rainbow', 'Golden'];

// the design's SH table: shop name, awning stripes, wall, wall stripe, trim
export const STALLS = {
  Common: { name: 'Common Corner', a: '#5cc3ff', b: '#ffffff', wall: ['#eaf7ff', '#cdeaff'], stripe: ['#5cc3ff', 0.12], trim: '#2a7fc4' },
  Rare: { name: 'Rare Boutique', a: '#3fd99a', b: '#ffffff', wall: ['#e8fff4', '#c6f5de'], stripe: ['#3fd99a', 0.13], trim: '#1f9a68' },
  Epic: { name: 'Epic Emporium', a: '#a45cff', b: '#f1e3ff', wall: ['#f5ecff', '#e0cbff'], stripe: ['#a45cff', 0.12], trim: '#6a2fc4' },
  Legendary: { name: 'Legendary Vault', a: '#ff9a2e', b: '#fff1d6', wall: ['#fff5e6', '#ffdcb0'], stripe: ['#ff9a2e', 0.13], trim: '#b85d00' },
  Rainbow: { name: 'Rainbow Parlor', a: '#ff7fbf', b: '#8fd8ff', wall: ['#fff0f8', '#e6f4ff', '#f3ffe6'], stripe: ['#ff7fbf', 0.12], trim: '#c2388a' },
  Golden: { name: 'Golden Palace', a: '#ffc233', b: '#fff6c8', wall: ['#fffbe6', '#ffe89a'], stripe: ['#f0a000', 0.14], trim: '#a86a00' },
};

// ---- geometry (the design's px) -------------------------------------------
const RING = 3; // the trim ring outside the white rim
const RIM = 3;
const EDGE = RING + RIM;
const RADIUS = 24;
const GAP = 42; // above a stall: the design's 22px list gap + 20px margin
const SIGN_RISE = 22; // the sign sits this far above the stall's top
const AWN_H = 40;
const SCALLOP_H = 14;
const STRIPE_W = 26;
const BODY_PAD = 6; // the wall's padding above the first row
const SIDE_PAD = 10;
export const CARD_H = 236;
const SHELF_H = 12;
const ROW_GAP = 16;
const FOOT_H = 16;

export const TOP_H = GAP + EDGE + AWN_H + SCALLOP_H + BODY_PAD;
export const ROW_H = ROW_GAP / 2 + CARD_H - 4 + SHELF_H + ROW_GAP / 2;
export const BOTTOM_H = 14 - ROW_GAP / 2 + FOOT_H + EDGE;
// the width a card gets (two per row, 6px either side of each)
export const cardWidth = (stallWidth) => Math.floor((stallWidth - EDGE * 2 - SIDE_PAD * 2) / 2) - 12;

// ---- colours along the wall --------------------------------------------------
const hex = (c) => [1, 3, 5].map((i) => parseInt(c.slice(i, i + 2), 16));
const toHex = (rgb) => `#${rgb.map((v) => Math.round(v).toString(16).padStart(2, '0')).join('')}`;
function colorAt(stops, f) {
  const t = Math.max(0, Math.min(1, f)) * (stops.length - 1);
  const i = Math.min(stops.length - 2, Math.floor(t));
  const a = hex(stops[i]);
  const b = hex(stops[i + 1]);
  return toHex(a.map((v, k) => v + (b[k] - v) * (t - i)));
}

// the back wall between the rims: its slice of the gradient, and the
// vertical stripes
const Wall = memo(function Wall({ stall, top, height, from, to }) {
  return (
    <View style={[styles.abs, { left: EDGE, right: EDGE, top, height }]}>
      <LinearGradient colors={[colorAt(stall.wall, from), colorAt(stall.wall, to)]} style={StyleSheet.absoluteFill} />
      <Svg width="100%" height={height} style={StyleSheet.absoluteFill}>
        <Defs>
          <Pattern id="wallStripes" x={SIDE_PAD} y="0" width={36} height={10} patternUnits="userSpaceOnUse">
            <Rect x={18} y={0} width={18} height={10} fill={stall.stripe[0]} fillOpacity={stall.stripe[1]} />
          </Pattern>
        </Defs>
        <Rect x={0} y={0} width="100%" height={height} fill="url(#wallStripes)" />
      </Svg>
    </View>
  );
});

// the stall's sides: trim ring and white rim, `top`..`top + height`
function Sides({ stall, top, height }) {
  return (
    <>
      <View style={[styles.abs, { left: 0, width: RING, top, height, backgroundColor: stall.trim }]} />
      <View style={[styles.abs, { left: RING, width: RIM, top, height, backgroundColor: '#ffffff' }]} />
      <View style={[styles.abs, { right: 0, width: RING, top, height, backgroundColor: stall.trim }]} />
      <View style={[styles.abs, { right: RING, width: RIM, top, height, backgroundColor: '#ffffff' }]} />
    </>
  );
}

// ---- the awning: stripes, then a row of scallops ------------------------------
const Awning = memo(function Awning({ stall, width }) {
  const w = width - EDGE * 2;
  const n = Math.ceil(w / STRIPE_W) + 1;
  const stripes = [];
  for (let i = 0; i < n; i += 2) stripes.push(`M${i * STRIPE_W} 0 h${STRIPE_W} v${AWN_H} h${-STRIPE_W} Z`);
  const scallops = [];
  for (let i = 0; i < n; i++) scallops.push({ cx: 13 + i * STRIPE_W, c: i % 2 ? stall.b : stall.a });
  const r = RADIUS - RIM;
  return (
    <View style={{ width: w, height: AWN_H + SCALLOP_H }}>
      <View style={{ width: w, height: AWN_H, borderTopLeftRadius: r, borderTopRightRadius: r, overflow: 'hidden', backgroundColor: stall.b }}>
        <Svg width={w} height={AWN_H}>
          <Defs>
            <SvgLinearGradient id="awnInset" x1="0" y1="0" x2="0" y2={AWN_H} gradientUnits="userSpaceOnUse">
              <Stop offset="0" stopColor="#ffffff" stopOpacity={0.5} />
              <Stop offset={3 / AWN_H} stopColor="#ffffff" stopOpacity={0} />
              <Stop offset={(AWN_H - 3) / AWN_H} stopColor="#000000" stopOpacity={0} />
              <Stop offset={(AWN_H - 3) / AWN_H} stopColor="#000000" stopOpacity={0.08} />
              <Stop offset="1" stopColor="#000000" stopOpacity={0.08} />
            </SvgLinearGradient>
          </Defs>
          <Path d={stripes.join(' ')} fill={stall.a} />
          <Rect x={0} y={0} width={w} height={AWN_H} fill="url(#awnInset)" />
        </Svg>
      </View>
      <Svg width={w} height={SCALLOP_H + 3} style={{ marginTop: -1 }}>
        {scallops.map((s, i) => (
          <Circle key={`s${i}`} cx={s.cx} cy={3} r={12.5} fill="#000000" fillOpacity={0.1} />
        ))}
        {scallops.map((s, i) => (
          <Circle key={i} cx={s.cx} cy={0} r={12.5} fill={s.c} />
        ))}
      </Svg>
    </View>
  );
});

// the wooden sign: "Common Corner" and the owned count on the rarity's chip
const Sign = memo(function Sign({ tier, count }) {
  const stall = STALLS[tier];
  const t = TIERS[tier];
  return (
    <View style={styles.signLip}>
      <View style={styles.signRing}>
        <LinearGradient colors={['#b8733a', '#8f4f1c']} style={styles.signFace}>
          <Text style={styles.signText}>{stall.name}</Text>
          <View style={styles.countRim}>
            <LinearGradient colors={t.bg.length > 1 ? t.bg : [t.bg[0], t.bg[0]]} start={{ x: 0, y: 0 }} end={{ x: 1, y: 0.4 }} style={styles.countFace}>
              <Text style={styles.countText}>{count}</Text>
            </LinearGradient>
          </View>
        </LinearGradient>
      </View>
    </View>
  );
});

// ---- the pieces ----------------------------------------------------------------

// The stall's top: the sign, the rounded top of the frame, the awning, and
// the top of the wall. `span` is the stall's height (its pieces together).
export const StallTop = memo(function StallTop({ tier, width, count, span }) {
  const stall = STALLS[tier];
  const top = GAP;
  const wallTop = top + EDGE + AWN_H;
  const h = TOP_H - wallTop;
  return (
    <View style={{ width, height: TOP_H }}>
      <View style={[styles.abs, { left: 0, right: 0, top, bottom: 0, borderTopLeftRadius: RADIUS + RING, borderTopRightRadius: RADIUS + RING, backgroundColor: stall.trim }]} />
      <View style={[styles.abs, { left: RING, right: RING, top: top + RING, bottom: 0, borderTopLeftRadius: RADIUS, borderTopRightRadius: RADIUS, backgroundColor: '#ffffff' }]} />
      <Wall stall={stall} top={wallTop} height={h + 1} from={(wallTop - top) / span} to={(TOP_H - top) / span} />
      <View style={[styles.abs, { left: EDGE, top: top + EDGE }]}>
        <Awning stall={stall} width={width} />
      </View>
      <View style={[styles.signRow, { top: top - SIGN_RISE }]} pointerEvents="none">
        <Sign tier={tier} count={count} />
      </View>
    </View>
  );
});

// One row of (up to) two cards, each on its shelf. `at` is where the row
// starts inside the stall (for the wall's gradient).
export function StallRow({ tier, width, at, span, children }) {
  const stall = STALLS[tier];
  return (
    <View style={{ width, height: ROW_H }}>
      <Sides stall={stall} top={-1} height={ROW_H + 1} />
      <Wall stall={stall} top={-1} height={ROW_H + 1} from={(at - GAP) / span} to={(at - GAP + ROW_H) / span} />
      <View style={[styles.row, { left: EDGE + SIDE_PAD, right: EDGE + SIDE_PAD, top: ROW_GAP / 2 }]}>{children}</View>
    </View>
  );
}

// a card on its shelf: the card (children) sinks 4px into the plank
export function OnShelf({ width, children }) {
  return (
    <View style={{ width: width + 12 }}>
      <View style={styles.cardSlot}>{children}</View>
      <View style={styles.shelfShadow} />
      <LinearGradient colors={['#e0a066', '#c47a3c', '#8f4f1c']} locations={[0, 0.55, 1]} style={styles.shelf} />
    </View>
  );
}

// The bottom: the last of the wall, the striped strip, the rounded corners.
export const StallBottom = memo(function StallBottom({ tier, width, at, span }) {
  const stall = STALLS[tier];
  const wallH = BOTTOM_H - EDGE - FOOT_H;
  const r = RADIUS - RIM;
  return (
    <View style={{ width, height: BOTTOM_H }}>
      <View style={[styles.abs, { left: 0, right: 0, top: -1, bottom: 0, borderBottomLeftRadius: RADIUS + RING, borderBottomRightRadius: RADIUS + RING, backgroundColor: stall.trim }]} />
      <View style={[styles.abs, { left: RING, right: RING, top: -1, bottom: RING, borderBottomLeftRadius: RADIUS, borderBottomRightRadius: RADIUS, backgroundColor: '#ffffff' }]} />
      <Wall stall={stall} top={-1} height={wallH + 1} from={(at - GAP) / span} to={(at - GAP + wallH) / span} />
      <View style={[styles.abs, { left: EDGE, right: EDGE, top: wallH, height: FOOT_H, borderBottomLeftRadius: r, borderBottomRightRadius: r, overflow: 'hidden', backgroundColor: colorAt(stall.wall, 1) }]}>
        <Svg width="100%" height={FOOT_H} style={{ opacity: 0.85 }}>
          <Defs>
            <Pattern id="footStripes" x="0" y="0" width={16} height={FOOT_H} patternUnits="userSpaceOnUse">
              <Rect x={0} y={0} width={14} height={FOOT_H} fill={stall.trim} />
              <Rect x={14} y={0} width={2} height={FOOT_H} fill="#ffffff" fillOpacity={0.35} />
            </Pattern>
          </Defs>
          <Rect x={0} y={0} width="100%" height={FOOT_H} fill="url(#footStripes)" />
        </Svg>
      </View>
    </View>
  );
});

// the height of a stall with `rows` rows, for the wall's gradient
export const stallSpan = (rows) => TOP_H - GAP + rows * ROW_H + BOTTOM_H;

// ---- a card's bits ---------------------------------------------------------------

// The design's gold key (viewBox 54×26): brown outline, gold fill with a
// white line, and a drop under it.
const KEY_BOW = 'M11 4.5 a8.5 8.5 0 1 0 0.01 0 Z M11 9.5 a3.5 3.5 0 1 1 -0.01 0 Z';
const KEY_BLADE = 'M19 11 H50 V15 H45 V21 H40 V15 H35 V19 H30 V15 H19 Z';
export const GoldKey = memo(function GoldKey({ width = 30 }) {
  const h = (width * 26) / 54;
  return (
    <Svg width={width} height={h + 2} viewBox="0 0 54 28" style={{ overflow: 'visible' }}>
      <Defs>
        <SvgLinearGradient id="keyGold2" x1="0" y1="0" x2="0" y2="1">
          <Stop offset="0" stopColor="#fff7b0" />
          <Stop offset="0.5" stopColor="#ffd23a" />
          <Stop offset="1" stopColor="#ff9c0a" />
        </SvgLinearGradient>
      </Defs>
      <Circle cx={11} cy={15} r={8.5} stroke="#9c4d06" strokeWidth={4.5} fill="none" />
      <Path d={KEY_BLADE} transform="translate(0 2)" stroke="#9c4d06" strokeWidth={4.5} strokeLinejoin="round" fill="#9c4d06" />
      <Circle cx={11} cy={13} r={8.5} stroke="#9c4d06" strokeWidth={4.5} fill="none" />
      <Path d={KEY_BLADE} stroke="#9c4d06" strokeWidth={4.5} strokeLinejoin="round" fill="none" />
      <Path d={KEY_BOW} fillRule="evenodd" stroke="#ffffff" strokeWidth={2} strokeLinejoin="round" fill="url(#keyGold2)" />
      <Path d={KEY_BLADE} stroke="#ffffff" strokeWidth={2} strokeLinejoin="round" fill="url(#keyGold2)" />
      <Circle cx={8} cy={9.5} r={1.6} fill="#ffffff" />
    </Svg>
  );
});

// the card's top: white in the middle fading to the rarity's glow, with
// still rays (the design's repeating-conic-gradient under a radial mask)
const RAYS = Array.from({ length: 15 }, (_, i) => i * 24);
export const CardGlow = memo(function CardGlow({ width, height, glow }) {
  const cx = width / 2;
  const cy = height * 0.55;
  const far = Math.hypot(Math.max(cx, width - cx), Math.max(cy, height - cy));
  const ray = (a) => {
    const p = (deg) => [cx + 110 * Math.sin((deg * Math.PI) / 180), cy - 110 * Math.cos((deg * Math.PI) / 180)];
    const [x0, y0] = p(a);
    const [x1, y1] = p(a + 8);
    return `M${cx} ${cy} L${x0.toFixed(1)} ${y0.toFixed(1)} L${x1.toFixed(1)} ${y1.toFixed(1)} Z`;
  };
  return (
    <Svg width={width} height={height} style={StyleSheet.absoluteFill}>
      <Defs>
        <RadialGradient id="cardGlow" cx={cx} cy={cy} r={far} gradientUnits="userSpaceOnUse">
          <Stop offset="0" stopColor="#ffffff" />
          <Stop offset="0.22" stopColor="#ffffff" />
          <Stop offset="1" stopColor={glow} />
        </RadialGradient>
        <RadialGradient id="rayFade" cx={cx} cy={cy} r={110} gradientUnits="userSpaceOnUse">
          <Stop offset="0.1" stopColor="#ffffff" stopOpacity={0.5} />
          <Stop offset="0.6" stopColor="#ffffff" stopOpacity={0} />
        </RadialGradient>
      </Defs>
      <Rect x={0} y={0} width={width} height={height} fill="url(#cardGlow)" />
      <Path d={RAYS.map(ray).join(' ')} fill="url(#rayFade)" />
    </Svg>
  );
});

const styles = StyleSheet.create({
  abs: { position: 'absolute' },
  signRow: { position: 'absolute', left: 0, right: 0, alignItems: 'center' },
  signLip: { borderRadius: 17, paddingBottom: 4, backgroundColor: '#5a2a08' },
  signRing: { borderRadius: 17, padding: 2.5, backgroundColor: '#5a2a08' },
  signFace: { flexDirection: 'row', alignItems: 'center', gap: 8, borderRadius: 14, borderWidth: 3, borderColor: '#ffffff', paddingTop: 5, paddingBottom: 6, paddingHorizontal: 17 },
  signText: { fontFamily: candyFonts.display, fontSize: 16, letterSpacing: 0.4, color: '#fff3c4', textShadowColor: '#5a2a08', textShadowRadius: 1, textShadowOffset: { width: 0, height: 2 } },
  countRim: { borderRadius: 999, borderWidth: 2, borderColor: '#ffffff', overflow: 'hidden' },
  countFace: { paddingHorizontal: 7, paddingVertical: 1 },
  countText: { fontFamily: candyFonts.display, fontSize: 10, color: '#4a1a73' },
  row: { position: 'absolute', flexDirection: 'row', justifyContent: 'flex-start' },
  cardSlot: { paddingHorizontal: 6, marginBottom: -4, zIndex: 1, elevation: 1 },
  shelfShadow: { position: 'absolute', left: 0, right: 0, bottom: -4, height: SHELF_H, borderRadius: 3, backgroundColor: 'rgba(90,40,10,0.25)' },
  shelf: { height: SHELF_H, marginHorizontal: -1, borderRadius: 3, borderTopWidth: 2, borderTopColor: '#ffd9a8' },
});
