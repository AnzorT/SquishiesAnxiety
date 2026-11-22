import { RARITY, rarityOf } from '../squad/data';

// Candy theme — the v3 redesign ("ASMR Creature Squash v3.dc.html" in the
// design zip): glossy "candy" buttons (white border, dark ring + bottom lip,
// top shine), sticker-style outlined titles, and the text and card colours.

// (REDESIGN_V8, the user: the wood look everywhere, no pink or purple. The names stay; the colours are the warm
// ones: brown ink and outlines, cream paper, amber stage.)
export const candyColors = {
  ink: '#5b3418', // primary text on light surfaces
  inkSoft: '#7a4a24', // secondary text / input borders
  muted: '#9a6a3a', // descriptions on cards
  mutedLight: '#b08560',
  outline: '#6b4426', // the brown halo around white text / titles
  outlineDeep: '#3f2412', // the 5px drop under titles
  white: '#ffffff',
  paper: '#fffaf0', // inputs, empty slots
  sheet: '#fff6e2', // bottom sheets / modals
  cardRing: '#b8641c',
  goldText: '#fff3a0', // coin counts on glass pills
  goldInk: '#c25e00', // prices on white cards
  goldRing: '#9c4d06',
  glass: 'rgba(90,50,20,0.42)',
  glassBorder: 'rgba(255,255,255,0.9)',
  scrim: 'rgba(60,30,10,0.4)',
  danger: '#e5484d',
  pinkHot: '#ff8a3d',
  pinkRing: '#8a3a0e',
  teal: '#22e0d0',
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
  // (REDESIGN_V8: "pink" a warm orange, "purple" wood, "grey" a warm grey)
  pink: { colors: ['#ffe2c8', '#ff9a4a', '#e0601c'], locations: [0, 0.55, 1], ring: '#8a3a0e' },
  blue: { colors: ['#b0fbff', '#3fd7f6', '#1695d6'], locations: [0, 0.55, 1], ring: '#0c5a9c' },
  gold: { colors: ['#fff7b0', '#ffd23a', '#ff9c0a'], locations: [0, 0.5, 1], ring: '#9c4d06' },
  grey: { colors: ['#efe6dc', '#d6c8b8', '#bfae9c'], locations: [0, 0.55, 1], ring: '#8a7a6a' },
  purple: { colors: ['#f6d9b0', '#d9a066', '#a86e3a'], locations: [0, 0.5, 1], ring: '#6b4426' },
};

// Fills for OutlinedTitle's gradient text.
export const TITLE_FILLS = {
  gold: { colors: ['#fffbd6', '#ffe045', '#ff9500'], locations: [0, 0.45, 1] },
  // (REDESIGN_V8, the user: no pink: the "pink" titles are a warm orange)
  pink: { colors: ['#fff0d6', '#ffb05a', '#e8681c'], locations: [0, 0.52, 1] },
};

// A premade creature's rarity is the squad roster's (functions/squad.js, the 2026-10-06 design): Common, Rare, Epic,
// Legendary, or a set's reward creature.
export function tierOf(creatureId) {
  const r = rarityOf(creatureId);
  return r == null ? null : RARITY[r]; // custom creatures have no tier
}

// The roster creatures of one rarity, in roster order.
export function creaturesOfTier(creatures = [], tier) {
  return creatures.filter((c) => tierOf(c.id) === tier);
}
