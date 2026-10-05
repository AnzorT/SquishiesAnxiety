// Candy theme — the v3 redesign ("ASMR Creature Squash v3.dc.html" in the
// design zip): a pink→violet gradient stage with polka dots and bokeh,
// glossy "candy" buttons (white border, dark ring + bottom lip, top shine),
// sticker-style outlined titles, and deep-plum text on white/pink cards.

export const candyColors = {
  ink: '#4a1a73', // primary text on light surfaces
  inkSoft: '#6b3fa0', // secondary text / input borders
  muted: '#9467bd', // descriptions on cards
  mutedLight: '#9a7cc0',
  outline: '#6a1b9a', // purple halo around white text / titles
  outlineDeep: '#45107a', // the 5px drop under titles
  white: '#ffffff',
  paper: '#fff5fb', // inputs, empty slots
  sheet: '#fff0f8', // bottom sheets / modals
  cardRing: '#a23ad8',
  goldText: '#fff3a0', // coin counts on glass pills
  goldInk: '#c25e00', // prices on white cards
  goldRing: '#9c4d06',
  glass: 'rgba(80,12,140,0.42)',
  glassBorder: 'rgba(255,255,255,0.9)',
  scrim: 'rgba(74,26,115,0.35)',
  danger: '#e5484d',
  pinkHot: '#ff4fbf',
  pinkRing: '#8e1580',
  teal: '#22e0d0',
};

// Vertical stage gradient every full-screen view sits on.
export const candyBg = {
  colors: ['#ff8fd8', '#d85cf0', '#8f3cf2', '#5a22c8'],
  locations: [0, 0.4, 0.74, 1],
};

export const candyFonts = {
  display: 'Fredoka_700Bold',
  displaySemi: 'Fredoka_600SemiBold',
  displayMedium: 'Fredoka_500Medium',
  body: 'Nunito_700Bold',
  bodySemi: 'Nunito_600SemiBold',
  bodyHeavy: 'Nunito_800ExtraBold',
  bodyBlack: 'Nunito_900Black',
};

// Glossy button looks: top→bottom face gradient plus the dark ring/lip color
// that also tints the label's shadow.
export const BUTTON_VARIANTS = {
  pink: { colors: ['#ffa8e6', '#ff4fbf', '#d3179a'], locations: [0, 0.55, 1], ring: '#8e1580' },
  blue: { colors: ['#b0fbff', '#3fd7f6', '#1695d6'], locations: [0, 0.55, 1], ring: '#0c5a9c' },
  gold: { colors: ['#fff7b0', '#ffd23a', '#ff9c0a'], locations: [0, 0.5, 1], ring: '#9c4d06' },
  grey: { colors: ['#e8e0f5', '#b9a8d6', '#8f7bb8'], locations: [0, 0.55, 1], ring: '#5a4a80' },
  purple: { colors: ['#e6b8ff', '#b65cff', '#7a2ff0'], locations: [0, 0.5, 1], ring: '#45189a' },
};

// Fills for OutlinedTitle's gradient text.
export const TITLE_FILLS = {
  gold: { colors: ['#fffbd6', '#ffe045', '#ff9500'], locations: [0, 0.45, 1] },
  pink: { colors: ['#ffd6f4', '#ff5cc6', '#c02bd9'], locations: [0, 0.52, 1] },
};

// Rarity tiers. A premade creature's tier comes from its roster position
// (TIER_OF). The design's formula (ids 0-7 Common, 8-12 Rare, 13-15 Epic,
// 16-17 Legendary, 18 Rainbow, 19 Golden) was written for 20 creatures and
// never updated for the 30-creature plush roster of 2026-10-03 (it would make
// ids 19-29 all Golden), so the same proportions are spread over 30: 0-11
// Common, 12-18 Rare, 19-23 Epic, 24-27 Legendary, 28 Rainbow (Boba), 29
// Golden (Avo). `w` is the mystery-box pull weight in percent — retuned from
// the design's 55/25/12/6/1.5/0.5 for the sticker economy (see
// src/economy.js); Secret is never rolled, only granted once everything is
// owned.
export const TIERS = {
  Common: { label: 'COMMON', w: 45, bg: ['#d7f0ff', '#d7f0ff'], color: '#4a1a73', glow: '#9fd8ff' },
  Rare: { label: 'RARE', w: 27, bg: ['#c9f7e1', '#c9f7e1'], color: '#4a1a73', glow: '#7ee8b4' },
  Epic: { label: 'EPIC', w: 15, bg: ['#ead6ff', '#ead6ff'], color: '#4a1a73', glow: '#c89bff' },
  Legendary: { label: 'LEGENDARY', w: 8, bg: ['#ffdcb0', '#ffdcb0'], color: '#4a1a73', glow: '#ffa94d' },
  Rainbow: { label: 'RAINBOW', w: 3.5, bg: ['#ffb3c7', '#ffe38a', '#b3f5c8', '#b3e0ff', '#dcc2ff'], color: '#4a1a73', glow: '#ff9fd6' },
  Golden: { label: 'GOLDEN', w: 1.5, bg: ['#fff3b0', '#ffc233', '#f0a000'], color: '#4a1a73', glow: '#ffd24d' },
  Secret: { label: 'SECRET', w: 0, bg: ['#4a1a73', '#ff4fa3'], color: '#ffffff', glow: '#ff6fbd' },
};

export function tierOf(creatureId) {
  const id = Number(creatureId);
  if (!Number.isFinite(id)) return null; // custom creatures have no tier
  if (id <= 11) return 'Common';
  if (id <= 18) return 'Rare';
  if (id <= 23) return 'Epic';
  if (id <= 27) return 'Legendary';
  if (id === 28) return 'Rainbow';
  return 'Golden';
}

// The roster creatures of one rarity, in roster order.
export function creaturesOfTier(creatures = [], tier) {
  return creatures.filter((c) => tierOf(c.id) === tier);
}

export default { candyColors, candyBg, candyFonts, BUTTON_VARIANTS, TITLE_FILLS, TIERS, tierOf, creaturesOfTier };
