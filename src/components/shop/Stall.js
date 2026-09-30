import React, { memo } from 'react';
import { StyleSheet, Text, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Defs, LinearGradient as SvgLinearGradient, Stop, Path, Rect, Pattern, Circle } from 'react-native-svg';
import { TIERS, candyFonts } from '../../theme/candyTheme';
import { ButtonText, Shine } from '../candy/CandyButton';
import { Twinkle } from '../candy/Sparkles';

// The Key Shop's market stalls, one per rarity: a striped, scalloped awning
// hung from a candy rod with the rarity's sign on it, two candy-cane posts,
// shelves of creatures on a dotted back wall, and a counter along the front
// that says how many of that rarity you own.
//
// A stall is drawn as a stack of fixed-height pieces — StallTop, one
// StallRow per shelf, StallBottom — so the shop's FlatList can build it a
// shelf at a time and jump straight to any shelf. The posts' stripes and the
// wall's dots take the piece's `phase` (its y inside the stall), so they run
// on unbroken across the joins.

export const TIER_ORDER = ['Common', 'Rare', 'Epic', 'Legendary', 'Rainbow', 'Golden'];

// Per-rarity colours. `stripes` repeat across the awning; the first one is
// also the posts' stripe. `face` is the sign, rod and counter; `ring` the
// dark outline and lip on everything (and the captions' outline).
export const STALLS = {
  Common: {
    stripes: ['#4fc3ff', '#ffffff'],
    ring: '#0c5a9c',
    face: ['#b0fbff', '#3fd7f6', '#1695d6'],
    wall: ['#cdeaff', '#f2faff', '#cdeaff'],
    dot: '#9fd8ff',
    shelf: ['#9fe3ff', '#2aa6e6'],
    tint: '#dff2ff',
    glow: '#9fd8ff',
  },
  Rare: {
    stripes: ['#3ddc97', '#ffffff'],
    ring: '#0b7550',
    face: ['#c8ffe6', '#4fe0a8', '#17ad77'],
    wall: ['#c6f3dd', '#f0fff7', '#c6f3dd'],
    dot: '#8fe8bd',
    shelf: ['#a2f2cf', '#1fb884'],
    tint: '#dcfaec',
    glow: '#7ee8b4',
  },
  Epic: {
    stripes: ['#b065ff', '#ffffff'],
    ring: '#45189a',
    face: ['#e6b8ff', '#b65cff', '#7a2ff0'],
    wall: ['#e2cdff', '#f8f1ff', '#e2cdff'],
    dot: '#cfa8ff',
    shelf: ['#d6b3ff', '#8a45f0'],
    tint: '#efe2ff',
    glow: '#c89bff',
  },
  Legendary: {
    stripes: ['#ff962e', '#ffffff'],
    ring: '#9e3f08',
    face: ['#ffe2b8', '#ffa24d', '#ee6a10'],
    wall: ['#ffdfbd', '#fff7ec', '#ffdfbd'],
    dot: '#ffc48a',
    shelf: ['#ffc98f', '#e8730f'],
    tint: '#ffedd6',
    glow: '#ffa94d',
  },
  Rainbow: {
    stripes: ['#ff6fae', '#ffab4a', '#ffe14d', '#5fe3a1', '#56c8ff', '#b98bff'],
    ring: '#8e1580',
    face: ['#ff9ccf', '#ffd27a', '#fff08a', '#9ef2c2', '#9adcff', '#d3b3ff'],
    faceAcross: true,
    wall: ['#ffe0f1', '#fff8fc', '#e6f3ff'],
    dot: '#ffb8de',
    shelf: ['#ffc2e8', '#e04fb4'],
    tint: '#ffeaf6',
    glow: '#ff9fd6',
    twinkles: ['#ffffff', '#fff3a0', '#ffffff'],
  },
  Golden: {
    stripes: ['#ffc629', '#fff6c8'],
    ring: '#9c4d06',
    face: ['#fff7b0', '#ffd23a', '#ff9c0a'],
    wall: ['#ffefae', '#fffbe8', '#ffefae'],
    dot: '#ffdc6e',
    shelf: ['#ffe27a', '#e08a00'],
    tint: '#fff5cf',
    glow: '#ffd24d',
    twinkles: ['#ffffff', '#ffffff', '#fff7d0'],
  },
};

// ---- geometry ----------------------------------------------------------
const GAP = 22; // space above each stall
const SIGN_H = 44; // sign incl. its lip
const ROD_H = 16;
const ROD_Y = GAP + SIGN_H / 2 - ROD_H / 2 - 2; // the sign sits across the rod
const AWN_Y = ROD_Y + ROD_H - 7; // the awning hangs from under the rod
const AWN_BODY = 40;
const AWN_SCALLOP = 15;
const AWN_MARGIN = 3; // room for its outline
const AWN_LIP = 4;
const POST_X = 10;
const POST_W = 14;
const INNER_X = POST_X + POST_W + 6; // where the goods start
const ROW_PAD = 14; // shelf row: space above the goods
const SHELF_H = 16; // plank + its shadow
const COUNTER_Y = 6;
const COUNTER_H = 44;

export const GOODS_H = 160;
export const TOP_H = AWN_Y + AWN_MARGIN + AWN_BODY + AWN_SCALLOP;
export const ROW_H = ROW_PAD + GOODS_H + SHELF_H;
export const BOTTOM_H = COUNTER_Y + COUNTER_H + 12;
// the posts start under the awning's body, part-way down the top piece
const POST_TOP_Y = AWN_Y + AWN_MARGIN + AWN_BODY - 8;
export const POSTS_IN_TOP = TOP_H - POST_TOP_Y;

export const goodsWidth = (stallWidth) => stallWidth - INNER_X * 2;

// ---- awning ------------------------------------------------------------
// Stripes fan out from the rod (the top edge is inset) and each ends in a
// scallop. Candy outline like the buttons: dark ring + lip, a white inner
// line, a gloss across the top, and a little shade in each scallop's fold.
const Awning = memo(function Awning({ stall, width }) {
  const L = AWN_MARGIN;
  const W = width - AWN_MARGIN * 2;
  const flare = 12;
  let n = Math.round(W / 30);
  if (n % 2 === 0) n += 1; // odd, so both edges end on the same stripe
  const sw = W / n;
  const tw = (W - flare * 2) / n;
  const xt = (i) => (L + flare + i * tw).toFixed(2);
  const xb = (i) => (L + i * sw).toFixed(2);
  const B = AWN_BODY;
  const arc = (i) => `A${(sw / 2).toFixed(2)} ${AWN_SCALLOP} 0 0 1 ${xb(i)} ${B}`;

  let outline = `M${xt(0)} 0 H${xt(n)} L${xb(n)} ${B}`;
  for (let i = n - 1; i >= 0; i--) outline += ` ${arc(i)}`;
  outline += ' Z';

  // two-colour awnings: the light stripe is the base fill, so the seams
  // between neighbouring stripes don't show the dark outline through
  const two = stall.stripes.length === 2;
  const byColor = {};
  const folds = [];
  for (let i = 0; i < n; i++) {
    const c = stall.stripes[i % stall.stripes.length];
    folds.push(`M${xb(i + 1)} ${B} ${arc(i)} Z`);
    if (two && i % 2 === 1) continue;
    (byColor[c] = byColor[c] || []).push(`M${xt(i)} 0 L${xt(i + 1)} 0 L${xb(i + 1)} ${B} ${arc(i)} Z`);
  }
  const body = `M${xt(0)} 0 H${xt(n)} L${xb(n)} ${B} H${xb(0)} Z`;
  const H = AWN_MARGIN + B + AWN_SCALLOP + AWN_MARGIN + AWN_LIP;

  return (
    <Svg width={width} height={H}>
      <Defs>
        <SvgLinearGradient id="awnGloss" x1="0" y1="0" x2="0" y2={B} gradientUnits="userSpaceOnUse">
          <Stop offset="0" stopColor="#ffffff" stopOpacity={0.6} />
          <Stop offset="0.6" stopColor="#ffffff" stopOpacity={0} />
        </SvgLinearGradient>
        <SvgLinearGradient id="awnFold" x1="0" y1={B} x2="0" y2={B + AWN_SCALLOP} gradientUnits="userSpaceOnUse">
          <Stop offset="0" stopColor={stall.ring} stopOpacity={0.05} />
          <Stop offset="1" stopColor={stall.ring} stopOpacity={0.3} />
        </SvgLinearGradient>
      </Defs>
      <Path d={outline} transform={`translate(0 ${AWN_MARGIN + AWN_LIP})`} fill={stall.ring} stroke={stall.ring} strokeWidth={5} strokeLinejoin="round" />
      <Path d={outline} transform={`translate(0 ${AWN_MARGIN})`} fill={two ? stall.stripes[1] : '#ffffff'} stroke={stall.ring} strokeWidth={5} strokeLinejoin="round" />
      {Object.keys(byColor).map((c) => (
        <Path key={c} d={byColor[c].join(' ')} transform={`translate(0 ${AWN_MARGIN})`} fill={c} />
      ))}
      <Path d={folds.join(' ')} transform={`translate(0 ${AWN_MARGIN})`} fill="url(#awnFold)" />
      <Path d={body} transform={`translate(0 ${AWN_MARGIN})`} fill="url(#awnGloss)" />
      <Path d={outline} transform={`translate(0 ${AWN_MARGIN})`} fill="none" stroke="#ffffff" strokeWidth={2} strokeLinejoin="round" />
    </Svg>
  );
});

// ---- candy-cane post ---------------------------------------------------
const STRIPE_P = 16; // one stripe + one gap, measured down the post
const STRIPE_RISE = 7; // how far a stripe climbs across the post

const Post = memo(function Post({ stall, height, phase }) {
  const w = POST_W;
  const bands = [];
  for (let y = -(phase % STRIPE_P) - STRIPE_P; y < height + STRIPE_RISE; y += STRIPE_P) {
    bands.push(`M0 ${y} L${w} ${y - STRIPE_RISE} L${w} ${y - STRIPE_RISE + STRIPE_P / 2} L0 ${y + STRIPE_P / 2} Z`);
  }
  return (
    <Svg width={w} height={height}>
      <Defs>
        <SvgLinearGradient id="postShade" x1="0" y1="0" x2="1" y2="0">
          <Stop offset="0" stopColor="#000000" stopOpacity={0.12} />
          <Stop offset="0.35" stopColor="#ffffff" stopOpacity={0.5} />
          <Stop offset="1" stopColor="#000000" stopOpacity={0.2} />
        </SvgLinearGradient>
      </Defs>
      <Rect x={0} y={0} width={w} height={height} fill="#ffffff" />
      <Path d={bands.join(' ')} fill={stall.stripes[0]} />
      <Rect x={0} y={0} width={w} height={height} fill="url(#postShade)" />
      <Rect x={0} y={0} width={2.5} height={height} fill={stall.ring} />
      <Rect x={w - 2.5} y={0} width={2.5} height={height} fill={stall.ring} />
    </Svg>
  );
});

function Posts({ stall, width, top = 0, height, phase }) {
  return (
    <>
      <View style={[styles.abs, { left: POST_X, top }]}>
        <Post stall={stall} height={height} phase={phase} />
      </View>
      <View style={[styles.abs, { left: width - POST_X - POST_W, top }]}>
        <Post stall={stall} height={height} phase={phase} />
      </View>
    </>
  );
}

// ---- back wall: light in the middle, dotted like wallpaper --------------
const DOT_P = 24;

const WallDots = memo(function WallDots({ stall, width, height, phase }) {
  return (
    <Svg width={width} height={height} style={StyleSheet.absoluteFill}>
      <Defs>
        <Pattern id="wallDots" x="0" y={-(phase % DOT_P)} width={DOT_P} height={DOT_P} patternUnits="userSpaceOnUse">
          <Circle cx={6} cy={6} r={2.4} fill={stall.dot} fillOpacity={0.55} />
          <Circle cx={18} cy={18} r={2.4} fill={stall.dot} fillOpacity={0.55} />
        </Pattern>
      </Defs>
      <Rect x="0" y="0" width={width} height={height} fill="url(#wallDots)" />
    </Svg>
  );
});

function Wall({ stall, width, top = 0, height, phase }) {
  const left = POST_X + POST_W / 2;
  const w = width - left * 2;
  return (
    <View style={[styles.abs, { left, top, width: w, height }]}>
      <LinearGradient colors={stall.wall} start={{ x: 0, y: 0 }} end={{ x: 1, y: 0 }} style={StyleSheet.absoluteFill} />
      <WallDots stall={stall} width={w} height={height} phase={phase} />
    </View>
  );
}

// ---- candy slab: the sign, the rod's balls, the counter ----------------
function Slab({ stall, radius = 999, lip = 4, ring = 2.5, rim = 3, style, faceStyle, children }) {
  return (
    <View style={[{ borderRadius: radius, paddingBottom: lip, backgroundColor: stall.ring }, style]}>
      <View style={{ flex: 1, borderRadius: radius, padding: ring, backgroundColor: stall.ring }}>
        <View style={{ flex: 1, borderRadius: radius, borderWidth: rim, borderColor: '#ffffff', overflow: 'hidden' }}>
          <LinearGradient
            colors={stall.face}
            start={{ x: 0, y: 0 }}
            end={stall.faceAcross ? { x: 1, y: 0.3 } : { x: 0, y: 1 }}
            style={[styles.slabFace, faceStyle]}
          >
            <Shine />
            {children}
          </LinearGradient>
        </View>
      </View>
    </View>
  );
}

// ---- the pieces --------------------------------------------------------

// Sign + rod + awning, and the top of the wall and posts under it.
export const StallTop = memo(function StallTop({ tier, width }) {
  const stall = STALLS[tier];
  const rodInset = AWN_MARGIN + 2;
  return (
    <View style={{ width, height: TOP_H }}>
      <Wall stall={stall} width={width} top={POST_TOP_Y} height={POSTS_IN_TOP} phase={0} />
      <Posts stall={stall} width={width} top={POST_TOP_Y} height={POSTS_IN_TOP} phase={0} />
      <View style={[styles.abs, { left: 0, top: AWN_Y }]}>
        <Awning stall={stall} width={width} />
      </View>
      <Slab stall={stall} lip={3} ring={2} rim={2} style={[styles.abs, { left: rodInset, right: rodInset, top: ROD_Y, height: ROD_H }]} />
      {stall.twinkles
        ? stall.twinkles.map((color, i) => (
            <View key={i} pointerEvents="none" style={[styles.abs, TWINKLE_SPOTS[i]]}>
              <Twinkle size={13 + (i % 2) * 4} color={color} duration={1.8 + i * 0.4} delay={i * 0.5} />
            </View>
          ))
        : null}
      <View style={[styles.signRow, { top: GAP, height: SIGN_H }]} pointerEvents="none">
        <Slab stall={stall} style={{ height: SIGN_H }} faceStyle={styles.signFace}>
          <ButtonText ring={stall.ring} size={17} style={styles.signText}>
            {TIERS[tier].label}
          </ButtonText>
        </Slab>
      </View>
    </View>
  );
});

const TWINKLE_SPOTS = [
  { left: '9%', top: AWN_Y + 12 },
  { right: '12%', top: AWN_Y + 8 },
  { left: '66%', top: AWN_Y + 26 },
];

// One shelf of goods: wall, the goods (children), the plank they stand on.
// The wall and posts of a shelf and the counter reach 1 dp up into the piece
// above: piece heights don't land on whole pixels at every screen density,
// and the rounding left a hairline of the stage showing through the joins.
const SEAM = 1;

export function StallRow({ tier, width, phase, children }) {
  const stall = STALLS[tier];
  return (
    <View style={{ width, height: ROW_H }}>
      <Wall stall={stall} width={width} top={-SEAM} height={ROW_H + SEAM} phase={phase - SEAM} />
      <View style={[styles.goods, { left: INNER_X, right: INNER_X, top: ROW_PAD, height: GOODS_H }]}>{children}</View>
      <View style={[styles.shelf, { left: POST_X + 4, right: POST_X + 4, top: ROW_PAD + GOODS_H - 2 }]}>
        <View style={[styles.plankRing, { backgroundColor: stall.ring }]}>
          <LinearGradient colors={stall.shelf} locations={[0.3, 0.32]} style={styles.plankFace} />
        </View>
        <View style={styles.plankShadow} />
      </View>
      <Posts stall={stall} width={width} top={-SEAM} height={ROW_H + SEAM} phase={phase - SEAM} />
    </View>
  );
}

// The counter across the front: a light countertop over a panelled front in
// the stall's colours, with a small "3/7 OWNED" label on it. No gloss, so it
// doesn't read as a button.
const TOP_SLAB_H = 14;
const PANEL_INSET = 8;
const GROOVE_P = 36;

export const StallBottom = memo(function StallBottom({ tier, width, phase, owned, total }) {
  const stall = STALLS[tier];
  const panelW = width - PANEL_INSET * 2;
  const grooves = [];
  for (let x = GROOVE_P; x < panelW - GROOVE_P / 2; x += GROOVE_P) grooves.push(x);
  return (
    <View style={{ width, height: BOTTOM_H }}>
      <Wall stall={stall} width={width} top={-SEAM} height={COUNTER_Y + 20 + SEAM} phase={phase - SEAM} />
      <Posts stall={stall} width={width} top={-SEAM} height={COUNTER_Y + 20 + SEAM} phase={phase - SEAM} />
      <View style={[styles.floorShadow, { top: COUNTER_Y + COUNTER_H - 8, left: width * 0.05, width: width * 0.9 }]} />
      <View
        style={[
          styles.panelLip,
          { backgroundColor: stall.ring, left: PANEL_INSET, right: PANEL_INSET, top: COUNTER_Y + TOP_SLAB_H - 4, height: COUNTER_H - TOP_SLAB_H + 4 },
        ]}
      >
        <View style={[styles.panelRing, { backgroundColor: stall.ring }]}>
          <LinearGradient colors={stall.face} start={{ x: 0, y: 0 }} end={stall.faceAcross ? { x: 1, y: 0.3 } : { x: 0, y: 1 }} style={styles.panelFace}>
            {grooves.map((x) => (
              <View key={x} style={[styles.groove, { left: x, backgroundColor: stall.ring }]} />
            ))}
            <View style={[styles.label, { borderColor: stall.ring }]}>
              <Text style={[styles.labelText, { color: stall.ring }]}>{`${owned}/${total} OWNED`}</Text>
            </View>
          </LinearGradient>
        </View>
      </View>
      <View style={[styles.slabTop, { backgroundColor: stall.ring, top: COUNTER_Y, height: TOP_SLAB_H }]}>
        <LinearGradient colors={['#ffffff', stall.tint]} style={styles.slabTopFace} />
      </View>
    </View>
  );
});

const styles = StyleSheet.create({
  abs: { position: 'absolute' },
  slabFace: { flex: 1, alignItems: 'center', justifyContent: 'center' },
  signRow: { position: 'absolute', left: 0, right: 0, alignItems: 'center' },
  signFace: { paddingHorizontal: 22, paddingVertical: 4 },
  signText: { letterSpacing: 1.6 },
  goods: { position: 'absolute', flexDirection: 'row', justifyContent: 'center', alignItems: 'flex-end', gap: 10 },
  shelf: { position: 'absolute' },
  plankRing: { height: 13, borderRadius: 5, padding: 2 },
  plankFace: { flex: 1, borderRadius: 3 },
  plankShadow: { height: 4, marginHorizontal: 6, borderBottomLeftRadius: 4, borderBottomRightRadius: 4, backgroundColor: 'rgba(50,0,110,0.18)' },
  floorShadow: { position: 'absolute', height: 14, borderRadius: 999, backgroundColor: 'rgba(40,0,90,0.3)' },
  slabTop: { position: 'absolute', left: 0, right: 0, borderRadius: 7, padding: 2 },
  slabTopFace: { flex: 1, borderRadius: 5 },
  panelLip: { position: 'absolute', paddingBottom: 4, borderBottomLeftRadius: 12, borderBottomRightRadius: 12 },
  panelRing: { flex: 1, paddingHorizontal: 2.5, paddingBottom: 2.5, borderBottomLeftRadius: 12, borderBottomRightRadius: 12 },
  panelFace: { flex: 1, paddingTop: 4, alignItems: 'center', justifyContent: 'center', borderBottomLeftRadius: 10, borderBottomRightRadius: 10, overflow: 'hidden' },
  groove: { position: 'absolute', top: 0, bottom: 0, width: 2, opacity: 0.22 },
  label: { backgroundColor: '#ffffff', borderRadius: 999, borderWidth: 2, paddingHorizontal: 12, paddingVertical: 1 },
  labelText: { fontFamily: candyFonts.display, fontSize: 12, letterSpacing: 0.8, includeFontPadding: false },
});
