// Dark theme lifted directly from "Squish Squad Prototype.html" — deep
// violet/plum stage, neon pink + gold + teal accents, Baloo 2 display type
// over Nunito body copy. Deliberately kept separate from tokens.js (the
// light PlushCrush2 palette): CreatureCard and SquishScreen still read the
// original `colors` export and must keep looking exactly as they do today,
// so this file only backs the screens being restyled to match the prototype
// (Splash, Auth, Home chrome, Achievements, Store, Settings, toasts).

export const squadColors = {
  bgDeepest: '#0d0620',
  bgAuthTop: '#1f0f3d',
  bgHomeTop: '#1a0e38',
  bgHomeBottom: '#100823',
  splashTop: '#4a1f8f',
  splashBottom: '#14092b',

  panel: '#241243',
  panelAlt: '#221049',
  panelBorder: '#3d2166',
  inputBg: '#1a0e33',
  sheetBg: '#1a0e38',

  textWhite: '#ffffff',
  textLavender: '#e4d4ff',
  textMutedLavender: '#c9b6e8',
  textMuted: '#8b78b8',
  textFaint: '#7a67ad',
  textFaintAlt: '#7a6ba0',
  textDisabled: '#5c4d80',

  pink: '#ff3ea5',
  pinkLight: '#ff8bd0',
  pinkDeep: '#c81e6b',

  gold: '#ffcd3c',
  goldLight: '#ffe27a',
  goldAmber: '#ffb703',
  goldDeep: '#d4a017',

  teal: '#22e0d0',
  tealDeep: '#0fb8a9',

  keyReadyBg: '#1f4d3d',
  keyReadyText: '#34d399',
  disabledBg: '#2f2450',
  disabledText: '#7a6ba0',
  danger: '#ff6b81',
};

// expo-linear-gradient takes flat start/end colors, not the multi-stop CSS
// gradients in the prototype — every gradient there is exactly two stops,
// so each of these maps straight across.
export const squadGradients = {
  authBg: { colors: [squadColors.bgAuthTop, squadColors.bgDeepest], start: { x: 0, y: 0 }, end: { x: 0, y: 1 } },
  homeBg: { colors: [squadColors.bgHomeTop, squadColors.bgHomeBottom], start: { x: 0, y: 0 }, end: { x: 0, y: 1 } },
  splashBg: { colors: [squadColors.splashTop, squadColors.splashBottom], start: { x: 0.5, y: 0 }, end: { x: 0.5, y: 1 } },
  ctaPink: { colors: [squadColors.pink, squadColors.pinkLight], start: { x: 0, y: 0 }, end: { x: 1, y: 1 } },
  ctaTeal: { colors: [squadColors.teal, squadColors.tealDeep], start: { x: 0, y: 0 }, end: { x: 1, y: 1 } },
  ctaLogout: { colors: [squadColors.pink, squadColors.pinkDeep], start: { x: 0, y: 0 }, end: { x: 1, y: 1 } },
  ctaGoldPink: { colors: [squadColors.gold, squadColors.pinkLight], start: { x: 0, y: 0 }, end: { x: 1, y: 1 } },
  goldDot: { colors: [squadColors.goldLight, squadColors.goldAmber], start: { x: 0.35, y: 0.3 }, end: { x: 1, y: 1 } },
};

export const squadFonts = {
  headingRegular: 'Baloo2_500Medium',
  headingBold: 'Baloo2_700Bold',
  headingExtraBold: 'Baloo2_800ExtraBold',
  bodyRegular: 'Nunito_400Regular',
  bodySemiBold: 'Nunito_600SemiBold',
  bodyBold: 'Nunito_700Bold',
  bodyExtraBold: 'Nunito_800ExtraBold',
};

export const squadRadii = {
  sm: 10,
  md: 14,
  lg: 20,
  xl: 26,
  pill: 999,
};

export default { squadColors, squadGradients, squadFonts, squadRadii };
