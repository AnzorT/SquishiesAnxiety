import { F } from '../squad/ui';
import CUSHIONS from './cushions';

// Squishdoku's look: the candy app's fonts and rings, and the patch colours.
export { F };

// (REDESIGN_V8: the wood look's browns, were plum and purple)
export const INK = '#5b3418';

// The nine patch colours, as plush cushions (cushions.js, made by
// tools/squishdoku/cushions.mjs): { name, shade: [edge, body, light], src }.
// Nine clearly different hues: with no lines between patches the colours
// alone tell them apart. The user's picks on 2026-10-28, in turn: much more
// colour that fits the app, then "cooler" (Jewel: deep and rich, the pastel
// creatures stand out on it), then plush cushions in those colours, because
// glossy candy buttons didn't match the creatures' fabric. Turned down that
// day: bright candy (out of context) and Dreamy pastels (not cool).
export const PATCHES = CUSHIONS;

// MASTER and LEGEND: the 600 levels' hardest boards (levels.js tierOfEffort)
export const TIER_NAMES = ['EASY', 'MEDIUM', 'HARD', 'EXPERT', 'MASTER', 'LEGEND'];
export const TIER_COLORS = ['#3ddc97', '#5fb8ff', '#ff8a4a', '#e01e4a', '#8f3cf2', '#f5a300'];
