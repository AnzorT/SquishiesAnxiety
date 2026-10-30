// The containers Squish Sort grows through (the user, 2026-10-28: "i want
// it to be in real fridge … small fridge medium big large extra large XXL
// … VERY VERY LARGE with each time adding more shelfs … same for the
// closet"): seven real fridges and seven real cupboards, one per size, the
// same sizes for both (levels.js MODEL_SIZES says which levels and how many
// shelves). Container.js draws them from this:
//   share     the body's width, as a share of the play area's (more for the
//             bigger ones; one-door models leave room on their hinge side)
//   doors     1 (on `hinge`'s side) or 2
//   radius    the body's corners [top, bottom]
//   top       what's above the inside: { kind, a, b } is a + b × spot high
//             (`keep`: the door covers all but that much of it)
//   bottom    and below it (drawers, grilles, plinths)
//   crisper   the fridge's salad drawers under the last shelf
//   feet      what it stands on
//   handle    the doors' handles; deco: what's on the doors
//   c         the colours, over the fridge's or the cupboard's defaults

export const SIZE_NAMES = ['SMALL', 'MEDIUM', 'BIG', 'LARGE', 'EXTRA LARGE', 'XXL', 'VERY VERY LARGE'];

// --- the colours they start from ------------------------------------------------

const FRIDGE = {
  ring: '#34485c',
  body: ['#ffffff', '#f2f6f9', '#dbe4ec'],
  door: ['#ffffff', '#f4f8fb', '#e1e9f0'],
  doorInner: ['#f4f9fc', '#dcebf4'],
  inside: ['#ffffff', '#eef7fc', '#d6ebf6'],
  shelf: { top: 'rgba(255,255,255,0.95)', face: 'rgba(186,224,246,0.6)', edge: '#9ccbe4' },
  trim: '#c3d1dd',
  handle: ['#ffffff', '#dfe6ec', '#9eabb8'],
  feet: '#4c5b69',
  lamp: '#ffffff',
  dark: '#2b3540',
};
const CUPBOARD = {
  ring: '#5a3412',
  body: ['#f6d3a2', '#e3b277', '#c98f50'],
  door: ['#f8dcb2', '#e9bc84', '#d29a5b'],
  doorInner: ['#f2cf9d', '#d9a668'],
  inside: ['#fff3de', '#f6dfb9', '#e9c690'],
  shelf: { top: '#f2c78e', face: '#c98f50', edge: '#8a5a2b' },
  trim: '#8a5a2b',
  handle: ['#fff6b0', '#f0c43a', '#b88a10'],
  feet: '#5a3412',
  lamp: '#fff3c4',
  dark: '#4a2a0e',
};

// stainless steel: a cool grey that brightens across the front
const STEEL = { body: ['#f4f6f8', '#d3d9df', '#b3bcc6'], door: ['#f7f9fa', '#d8dee4', '#b9c2cb'], trim: '#9aa5b1', handle: ['#ffffff', '#c9d0d7', '#7d8894'] };

// --- the fridges -------------------------------------------------------------------

export const FRIDGES = [
  {
    key: 'mini',
    name: 'Mini Fridge',
    share: 0.56,
    doors: 1,
    hinge: 'right',
    radius: [16, 16],
    top: { kind: 'icebox', a: 12, b: 0.5, keep: 4 },
    bottom: { kind: 'grille', a: 14 },
    feet: 'nubs',
    handle: 'recess',
    deco: ['note'],
    c: {},
  },
  {
    key: 'retro',
    name: 'Retro Fridge',
    share: 0.58,
    doors: 1,
    hinge: 'left',
    radius: [46, 14],
    top: { kind: 'icebox', a: 36, b: 0.45, keep: 28 },
    bottom: { kind: 'chrome', a: 12 },
    feet: 'legs',
    handle: 'lever',
    deco: ['badge'],
    c: {
      ring: '#1d5a52',
      body: ['#dcfff4', '#aaeeda', '#7ed8bf'],
      door: ['#e2fff6', '#b4f1df', '#88dcc4'],
      doorInner: ['#effffa', '#c9f2e5'],
      trim: '#5fbfa5',
      feet: '#9aa5b1',
    },
  },
  {
    key: 'topFreezer',
    name: 'Top-Freezer Fridge',
    share: 0.62,
    doors: 1,
    hinge: 'right',
    radius: [14, 12],
    top: { kind: 'freezer', a: 16, b: 0.95 },
    bottom: { kind: 'kick', a: 12 },
    crisper: true,
    feet: 'none',
    handle: 'pocket',
    deco: ['magnets'],
    c: {
      ring: '#5a4a2a',
      body: ['#fffaf0', '#f5ead2', '#e4d3ad'],
      door: ['#fffbf3', '#f7eed9', '#e8d9b8'],
      trim: '#cdb98d',
      handle: ['#fffdf6', '#e9dcc0', '#b9a37a'],
    },
  },
  {
    key: 'bottomFreezer',
    name: 'Bottom-Freezer Fridge',
    share: 0.64,
    doors: 1,
    hinge: 'left',
    radius: [12, 12],
    top: { kind: 'band', a: 10 },
    bottom: { kind: 'drawer', a: 18, b: 0.85 },
    crisper: true,
    feet: 'none',
    handle: 'bar',
    deco: ['brushed'],
    c: STEEL,
  },
  {
    key: 'sideBySide',
    name: 'Side-by-Side Fridge',
    share: 0.7,
    doors: 2,
    radius: [12, 12],
    top: { kind: 'band', a: 10 },
    bottom: { kind: 'grille', a: 14 },
    crisper: true,
    feet: 'none',
    handle: 'bar',
    deco: ['dispenser', 'brushed'],
    c: {
      ring: '#1c2229',
      body: ['#6e7884', '#4a525c', '#30363e'],
      door: ['#78838f', '#525b66', '#363d46'],
      doorInner: ['#f4f9fc', '#dcebf4'],
      trim: '#262c33',
      handle: ['#f2f4f6', '#b4bcc4', '#6b7682'],
    },
  },
  {
    key: 'frenchDoor',
    name: 'French-Door Fridge',
    share: 0.72,
    doors: 2,
    radius: [12, 12],
    top: { kind: 'band', a: 10 },
    bottom: { kind: 'drawers', a: 16, b: 0.62 },
    crisper: true,
    feet: 'none',
    handle: 'bar',
    deco: ['dispenser', 'display', 'brushed'],
    c: {
      ...STEEL,
      ring: '#2e3d52',
      body: ['#eef3f9', '#c7d3e0', '#a3b2c3'],
      door: ['#f3f7fb', '#cdd8e4', '#a9b8c8'],
    },
  },
  {
    key: 'restaurant',
    name: 'Restaurant Fridge',
    share: 0.8,
    doors: 2,
    radius: [8, 8],
    top: { kind: 'header', a: 18, b: 0.3 },
    bottom: { kind: 'grille', a: 14 },
    feet: 'casters',
    handle: 'long',
    deco: ['brushed', 'lock'],
    c: {
      ...STEEL,
      ring: '#2a3138',
      inside: ['#f6f8fa', '#e2e7ec', '#cbd3db'],
      shelf: { top: 'rgba(255,255,255,0.9)', face: 'rgba(150,162,176,0.55)', edge: '#7d8894', wire: true },
      doorInner: ['#eef1f4', '#d0d7de'],
    },
  },
];

// --- the cupboards -------------------------------------------------------------------

export const CUPBOARDS = [
  {
    key: 'bedside',
    name: 'Bedside Cabinet',
    share: 0.56,
    doors: 1,
    hinge: 'left',
    radius: [8, 8],
    top: { kind: 'drawer', a: 12, b: 0.42 },
    bottom: { kind: 'base', a: 8 },
    feet: 'tapered',
    handle: 'knob',
    deco: ['panel'],
    c: {},
  },
  {
    key: 'hall',
    name: 'Hall Cupboard',
    share: 0.58,
    doors: 1,
    hinge: 'right',
    radius: [6, 6],
    top: { kind: 'cornice', a: 18 },
    bottom: { kind: 'plinth', a: 12 },
    feet: 'none',
    handle: 'knob',
    deco: ['panel2'],
    c: {
      ring: '#4f4334',
      body: ['#fffaf0', '#f1e6d1', '#dccbab'],
      door: ['#fffcf5', '#f4ead8', '#e0d1b4'],
      doorInner: ['#f6ecd9', '#e3d2b1'],
      trim: '#b9a682',
      feet: '#4f4334',
    },
  },
  {
    key: 'toy',
    name: 'Toy Cupboard',
    share: 0.64,
    doors: 2,
    radius: [23, 18],
    top: { kind: 'star', a: 34 },
    bottom: { kind: 'base', a: 10 },
    feet: 'balls',
    handle: 'knob',
    deco: ['cutouts'],
    c: {
      body: ['#ffd7a3', '#eaa865', '#c47a3a'],
      door: ['#ffe0b6', '#f2b673', '#d68c46'],
      doorInner: ['#f6c58c', '#d99a5a'],
      inside: ['#fff6e6', '#ffe4bf', '#f6cd96'],
      shelf: { top: '#f2bf86', face: '#c98a4a', edge: '#8a4f1e' },
      trim: '#8a4f1e',
      handle: ['#fff6b0', '#ffd23a', '#d99400'],
    },
  },
  {
    key: 'wardrobe',
    name: 'Wardrobe',
    share: 0.66,
    doors: 2,
    radius: [6, 6],
    top: { kind: 'cornice', a: 18 },
    bottom: { kind: 'drawer1', a: 14, b: 0.5 },
    feet: 'bracket',
    handle: 'pull',
    deco: ['panel', 'rail'],
    c: {
      ring: '#2e1a0b',
      body: ['#b9835a', '#93603a', '#6e4424'],
      door: ['#c28c62', '#9c6842', '#77492a'],
      doorInner: ['#d9ab7c', '#b9845a'],
      inside: ['#f5dcb8', '#e6c08e', '#d2a66f'],
      shelf: { top: '#d8a978', face: '#93603a', edge: '#5a3518' },
      trim: '#5a3518',
      feet: '#2e1a0b',
    },
  },
  {
    key: 'mirror',
    name: 'Mirror Wardrobe',
    share: 0.7,
    doors: 2,
    radius: [6, 6],
    top: { kind: 'cornice', a: 16 },
    bottom: { kind: 'drawers2', a: 14, b: 0.5 },
    feet: 'none',
    handle: 'pull',
    deco: ['mirror', 'rail'],
    c: {
      ring: '#3f4c5c',
      body: ['#ffffff', '#eef1f5', '#d6dce4'],
      door: ['#ffffff', '#f1f4f7', '#dbe1e8'],
      doorInner: ['#f7f9fb', '#e2e7ed'],
      inside: ['#fff6e8', '#f3e1c4', '#e2c9a0'],
      shelf: { top: '#f1d9b4', face: '#d2b080', edge: '#9c7a4c' },
      trim: '#b9c3cf',
      handle: ['#ffffff', '#cfd6dd', '#8995a2'],
      feet: '#3f4c5c',
    },
  },
  {
    key: 'armoire',
    name: 'Grand Armoire',
    share: 0.72,
    doors: 2,
    radius: [28, 8],
    top: { kind: 'arch', a: 20, b: 0.3 },
    bottom: { kind: 'skirt', a: 14 },
    feet: 'buns',
    handle: 'knob',
    deco: ['arched', 'rail'],
    c: {
      ring: '#3a120c',
      body: ['#d27258', '#a9472f', '#7c2e1e'],
      door: ['#da7c60', '#b04f35', '#843322'],
      doorInner: ['#e39a78', '#c06e4e'],
      inside: ['#fde7d2', '#f2c9a6', '#e0a982'],
      shelf: { top: '#e9ad84', face: '#a9472f', edge: '#6a2516' },
      trim: '#ffd27a',
      feet: '#3a120c',
      dark: '#3a120c',
    },
  },
  {
    key: 'grand',
    name: 'Giant Wardrobe',
    share: 0.8,
    doors: 2,
    radius: [6, 6],
    top: { kind: 'cabinets', a: 14, b: 0.5 },
    bottom: { kind: 'drawersRow', a: 14, b: 0.45 },
    feet: 'none',
    handle: 'pull',
    deco: ['panel2', 'rail'],
    c: {
      ring: '#24160a',
      body: ['#94704a', '#6f5032', '#4f361f'],
      door: ['#9c7850', '#765638', '#553a22'],
      doorInner: ['#c9a074', '#a37a52'],
      inside: ['#f3ddbb', '#e2c293', '#cfa66f'],
      shelf: { top: '#d9b07e', face: '#7a5a38', edge: '#3f2a15' },
      trim: '#ffd27a',
      feet: '#24160a',
      dark: '#24160a',
    },
  },
];

const mix = (kind, base, m, i) => ({ ...m, kind, size: SIZE_NAMES[i], index: i, c: { ...base, ...m.c, shelf: { ...base.shelf, ...(m.c.shelf || {}) } } });
const BUILT = {
  fridge: FRIDGES.map((m, i) => mix('fridge', FRIDGE, m, i)),
  cupboard: CUPBOARDS.map((m, i) => mix('cupboard', CUPBOARD, m, i)),
};

// a theme's model number i (0 SMALL … 6 VERY VERY LARGE)
export const modelOf = (theme, i) => BUILT[theme === 'cupboard' ? 'cupboard' : 'fridge'][Math.max(0, Math.min(6, i | 0))];
export const MODEL_COUNT = FRIDGES.length;
