// Squish Stack's forest road (the level map sideways; the user, 2026-11-17: "let it be the trees forest", the
// background scrolling with the road, the road part of the background, the selected character walking to the next
// level). The forest pictures (assets/stack/forest-*.jpg) are drawn with this road baked in by tools/stack/forest.mjs,
// and src/stack/ForestMap.js stands the levels on the same road, so the two must come from this one file.
// Pure numbers only: the drawing script imports it under Node.
//
// Units are the pictures' own: a tile is 1000 × 460 (the menu world's viewBox, main-menu-scene.js); the map scales
// them to its height. The tiles follow each other A B C D A B …, and everything in them repeats every TILES tiles,
// so the strip has no seams.

export const TILE_W = 1000;
export const TILE_H = 460;
export const TILES = 4;

const TAU = Math.PI * 2;
// the road's middle line at x (repeats every tile: each wave fits a tile a whole number of times)
export const roadY = (x) => 304 + 24 * Math.sin((TAU * x) / 500 + 0.4) + 12 * Math.sin((3 * TAU * x) / TILE_W + 1.1);
// the road's width (the level buttons are a little wider, so they sit on it like stepping stones)
export const ROAD_W = 58;

export const GAP = 128; // from one level to the next
export const SIGN_GAP = 150; // from a band's last level to the next band's sign, and from the sign to its first level
export const START = 150; // the first sign
export const END = 260; // past the last level

// The levels' and the bands' signs' places along the road: list is the levels in order ({ band }).
// → { nodes: [x], signs: [{ x, i }] (i: the band's first level's index), width }
export function layout(list) {
  const nodes = [];
  const signs = [];
  let x = START;
  for (let i = 0; i < list.length; i++) {
    if (i === 0 || list[i].band !== list[i - 1].band) {
      if (i > 0) x += SIGN_GAP - GAP;
      signs.push({ x, i });
      x += SIGN_GAP;
    }
    nodes.push(x);
    x += GAP;
  }
  return { nodes, signs, width: x - GAP + END };
}

// the road between two places, as points ([x, y]) about `step` apart, for the walk
export function roadPath(x0, x1, step = 12) {
  const n = Math.max(2, Math.ceil(Math.abs(x1 - x0) / step) + 1);
  return Array.from({ length: n }, (_, i) => {
    const x = x0 + ((x1 - x0) * i) / (n - 1);
    return [x, roadY(x)];
  });
}
