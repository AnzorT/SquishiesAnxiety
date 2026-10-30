import { F } from '../squad/ui';
import CUSHIONS from './cushions';

// Squishdoku's look: the candy app's fonts and rings, and the patch colours.
export { F };

export const INK = '#45107a'; // the app's deep plum
export const RING = '#45189a';

// The nine patch colours, as plush cushions (cushions.js, made by
// tools/squishdoku/cushions.mjs): { name, shade: [edge, body, light], src }.
// Nine clearly different hues: with no lines between patches the colours
// alone tell them apart. The user's picks on 2026-10-28, in turn: much more
// colour that fits the app, then "cooler" (Jewel: deep and rich, the pastel
// creatures stand out on it), then plush cushions in those colours, because
// glossy candy buttons didn't match the creatures' fabric. Turned down that
// day: bright candy (out of context) and Dreamy pastels (not cool).
export const PATCHES = CUSHIONS;

export const MODE_COLORS = {
  regular: { ring: '#8e1580', colors: ['#ffd6f4', '#ff5cc6', '#c02bd9'] },
  blitz: { ring: '#0c5a9c', colors: ['#b0fbff', '#3fd7f6', '#1695d6'] },
};

export const TIER_NAMES = ['EASY', 'MEDIUM', 'HARD', 'EXPERT'];
export const TIER_COLORS = ['#3ddc97', '#5fb8ff', '#ff8a4a', '#e01e4a'];
