// The fridges Squish Sort grows through (the user, 2026-10-28: "i want it to be in real fridge … small fridge medium
// big large extra large XXL … VERY VERY LARGE with each time adding more shelfs"): seven real fridges, one per size
// (levels.js MODEL_SIZES says which levels and how many shelves). Only fridges since 2026-11-17 (the user: "lets make
// it only with food ok ? so delete the toy cupboard"), drawn "realistic and high detailed" since the same day
// (Container.js). Container.js draws them from this:
//   share     the body's width, as a share of the play area's (more for the bigger ones; one-door models leave room on
//             their hinge side)
//   doors     1 (on `hinge`'s side) or 2
//   radius    the body's corners [top, bottom]
//   top       what's above the inside: { kind, a, b } is a + b × spot high (`keep`: the door covers all but that much
//             of it)
//   bottom    and below it (a toe-kick grille, chrome trim, freezer drawers)
//   crisper   the salad drawers under the last shelf
//   feet      what it stands on
//   handle    the doors' handles; deco: what's on the doors
//   finish    the body's and the doors' material (below); metal: the handles'
//   liner     the inside's plastic, front to back; shelf: 'glass' or 'wire'

export const SIZE_NAMES = ['SMALL', 'MEDIUM', 'BIG', 'LARGE', 'EXTRA LARGE', 'XXL', 'VERY VERY LARGE'];

// --- the materials ---------------------------------------------------------------------------------------------------
// across: the colour left to right over the front (the darker ends are its rounded edges; the bright bit off-centre is
// the room's light on it); edge: the outline; seam: the gaps between panels; kind: enamel (glossy paint, a strong soft
// reflection) or steel (a brushed grain and a duller one)

const WHITE = { kind: 'enamel', across: ['#b9c2cb', '#e7ecf0', '#ffffff', '#fbfcfd', '#eef1f4', '#d5dbe1', '#aeb8c2'], edge: '#5d6873', seam: '#8a96a2', shade: '#9aa6b2' };
const MINT = { kind: 'enamel', across: ['#5aa991', '#93dcc5', '#c9f7e8', '#b9f1de', '#9fe5cd', '#7fceb6', '#559f88'], edge: '#1f5e4f', seam: '#3d8a74', shade: '#4f9c85' };
const ALMOND = { kind: 'enamel', across: ['#cbbd9f', '#ece4d0', '#fffcf4', '#fbf6ea', '#f3ebd8', '#e2d6bb', '#c8b998'], edge: '#7a6c52', seam: '#aa9c7e', shade: '#b8a98a' };
const STEEL = { kind: 'steel', across: ['#7f8a95', '#bcc4cc', '#e9edf0', '#d0d6dc', '#f2f4f6', '#c1c8cf', '#98a2ac', '#77818c'], edge: '#46505a', seam: '#5f6a75', shade: '#7c8692' };
const BLUE_STEEL = { kind: 'steel', across: ['#7a8798', '#b6c3d2', '#e6edf5', '#cdd7e2', '#eef3f8', '#bdc9d6', '#94a2b3', '#728093'], edge: '#3e4b5c', seam: '#5a6879', shade: '#788699' };
const BLACK = { kind: 'steel', across: ['#15191d', '#30363d', '#545d67', '#3b424a', '#646d77', '#3a4048', '#262b31', '#14181c'], edge: '#07090b', seam: '#0b0e11', shade: '#0e1114' };

// the handles' metal, across a round bar
export const CHROME = ['#4e5964', '#9aa4ae', '#e9edf0', '#ffffff', '#c9d0d7', '#7d8894', '#4b5560'];
const BRUSHED = ['#5b6570', '#a3acb5', '#dde2e7', '#f4f6f8', '#b9c1c9', '#7f8994', '#56606b'];
const DARK_METAL = ['#1b1f24', '#454c55', '#7a838d', '#a3abb3', '#5d6670', '#30363d', '#16191d'];

// the inside's plastic liner: the side walls' front and back, the back wall's top and bottom
const LINER = { front: '#f3f7fa', back: '#cfdbe4', top: '#fbfdfe', bottom: '#dde7ee', rib: '#bccbd6' };
const LINER_GREY = { front: '#eef1f4', back: '#c5ced7', top: '#f6f8fa', bottom: '#d6dde4', rib: '#b2bdc8' };

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
    finish: WHITE,
    metal: CHROME,
    liner: LINER,
    shelf: 'glass',
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
    deco: ['badge', 'stripe'],
    finish: MINT,
    metal: CHROME,
    liner: LINER,
    shelf: 'wire',
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
    finish: ALMOND,
    metal: ['#8f8064', '#cfc3a8', '#f4eedf', '#fffcf5', '#e2d8c2', '#b6a888', '#83755a'],
    liner: LINER,
    shelf: 'glass',
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
    deco: [],
    finish: STEEL,
    metal: BRUSHED,
    liner: LINER,
    shelf: 'glass',
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
    deco: ['dispenser'],
    finish: BLACK,
    metal: DARK_METAL,
    liner: LINER,
    shelf: 'glass',
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
    deco: ['dispenser', 'display'],
    finish: BLUE_STEEL,
    metal: BRUSHED,
    liner: LINER,
    shelf: 'glass',
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
    deco: ['lock', 'plate'],
    finish: STEEL,
    metal: BRUSHED,
    liner: LINER_GREY,
    shelf: 'wire',
  },
];

const BUILT = FRIDGES.map((m, i) => ({ ...m, kind: 'fridge', size: SIZE_NAMES[i], index: i }));

// the fridge number i (0 SMALL … 6 VERY VERY LARGE); `theme` is always the fridge now (kept for the callers)
export const modelOf = (theme, i) => BUILT[Math.max(0, Math.min(6, i | 0))];
export const MODEL_COUNT = FRIDGES.length;
