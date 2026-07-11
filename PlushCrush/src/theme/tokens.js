// PlushCrush design tokens.
// Aesthetic: "collector's night shelf" — deep plum backdrop so the toy glows
// like a lit display piece, candy pastel accents, soft-glass UI surfaces.

export const colors = {
  bgDeep: '#1A1326',
  bgPanel: 'rgba(255,255,255,0.06)',
  bgPanelBorder: 'rgba(255,255,255,0.12)',
  glass: 'rgba(255,255,255,0.08)',

  textPrimary: '#F5EFFF',
  textMuted: '#B8A9CC',

  peach: '#FFC7A8',
  strawberry: '#FF9DB0',
  matcha: '#B6E3B0',
  blueberry: '#A6C4FF',
  lemon: '#FFE79A',

  rarityCommon: '#B8A9CC',
  rarityRare: '#A6C4FF',
  rarityEpic: '#D9A6FF',

  success: '#8FE3A0',
  danger: '#FF6E8E',
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
