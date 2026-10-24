import { F } from '../squad/ui';

// Squishdoku's look: the candy app's fonts and rings, and the patch colours.
export { F };

export const INK = '#45107a'; // the app's deep plum
export const RING = '#45189a';

// Nine patch colours, nine clearly different hues: with no lines between
// patches the colours alone tell them apart, so two must never be mixed up,
// even under a creature. Each is a candy tile's three shades (Tile.js):
// [its darker 3D base, the face, the face's light top].
export const PATCHES = [
  ['#d94fa0', '#ff8fd0', '#ffd6ef'], // bubblegum pink
  ['#d34646', '#ff7b7b', '#ffd2d2'], // coral red
  ['#e3803a', '#ffb56a', '#ffe3c6'], // orange
  ['#d6ac25', '#ffdc5c', '#fff6c4'], // yellow
  ['#8fb92f', '#c8ea6a', '#effcc6'], // lime
  ['#38b673', '#7fe3ad', '#d6f8e6'], // mint
  ['#25a3ae', '#62dbe4', '#cff7fa'], // teal
  ['#4a6de0', '#8aa6ff', '#dde6ff'], // blue
  ['#8355dc', '#bb97ff', '#ece0ff'], // purple
];

export const MODE_COLORS = {
  regular: { ring: '#8e1580', colors: ['#ffd6f4', '#ff5cc6', '#c02bd9'] },
  blitz: { ring: '#0c5a9c', colors: ['#b0fbff', '#3fd7f6', '#1695d6'] },
};

export const TIER_NAMES = ['EASY', 'MEDIUM', 'HARD', 'EXPERT'];
export const TIER_COLORS = ['#3ddc97', '#5fb8ff', '#ff8a4a', '#e01e4a'];
