// PlushCrush design tokens.
// Palette lifted directly from the "Cute Squishies" reference design
// (Cute Squishies (standalone).html) — soft lavender stage, glassy white
// controls, plum text hierarchy.

export const colors = {
  bg: '#F3EEFB',
  bgGradientTop: '#FBF7FF',
  bgGradientMid: '#F1E9FC',
  bgGradientBottom: '#E7DAF6',

  surface: '#FFFFFF',
  surfaceBorder: '#E4D6F6',
  glass: 'rgba(255,255,255,0.7)',

  textPrimary: '#3A2E4D',
  accent: '#8A5CC7',
  accentHover: '#6B3AA0',
  textMuted: '#9C87BD',
  caption: '#A691C6',
  iconStroke: '#C3AEDD',
  shadow: 'rgba(110,70,160,0.14)',

  arrowActive: '#FFFFFF',
  arrowInactive: '#B7A9CB',

  peach: '#FFC7A8',
  strawberry: '#FF9DB0',
  matcha: '#B6E3B0',
  blueberry: '#A6C4FF',
  lemon: '#FFE79A',

  rarityCommon: '#9C87BD',
  rarityRare: '#5C8CE0',
  rarityEpic: '#B15CE0',

  success: '#4FAE73',
  danger: '#E0567E',

  // Coin currency — warm metallic gold, distinct from the purple/green UI
  // palette so coins read as "money" wherever they appear.
  coinGold: '#F5B816',
  coinGoldDeep: '#B9790A',
  coinGoldShine: '#FFF3C8',
  coinGoldBg: '#FFF6DE',
};

export const radii = {
  sm: 10,
  md: 18,
  lg: 28,
  pill: 999,
};

export const spacing = (n) => n * 4;

export const typography = {
  display: { fontSize: 28, fontWeight: '700', color: colors.textPrimary },
  title: { fontSize: 18, fontWeight: '600', color: colors.textPrimary },
  body: { fontSize: 14, fontWeight: '400', color: colors.textMuted },
  label: { fontSize: 12, fontWeight: '600', color: colors.textMuted, letterSpacing: 0.5 },
};

export default { colors, radii, spacing, typography };
