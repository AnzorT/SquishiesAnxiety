// How a Squishdoku board's patches are shaped, so a hill-climb for harder
// boards (levels600.mjs) can't win by growing snakes (SQUISHDOKU.md "Harder
// boards"). `regs` is each cell's patch, row by row.
//
// SHAPE: measured over 1,500 plain 9×9 boards from the maker (2026-11-07),
// each number at its 95th percentile:
//   corridors  cells with patch neighbours only on two opposite sides (a
//              one-cell-wide passage)
//   tips       cells with one patch neighbour
//   edges      the patches' perimeters added up
//   maxRatio / meanRatio  each patch's perimeter over the smallest a patch
//              of its size can have
// Unguarded, climbed boards had 17 corridors (plain ones 7) and 162 edges (138).
export const SHAPE = { corridors: 13, tips: 21, edges: 152, maxRatio: 1.91, meanRatio: 1.34 };

export function shapeOf(n, regs) {
  const size = new Array(n).fill(0);
  const per = new Array(n).fill(0);
  let corridors = 0;
  let tips = 0;
  for (let cell = 0; cell < n * n; cell++) {
    const g = regs[cell];
    size[g]++;
    const r = Math.floor(cell / n);
    const c = cell % n;
    const u = r > 0 && regs[cell - n] === g;
    const d = r < n - 1 && regs[cell + n] === g;
    const l = c > 0 && regs[cell - 1] === g;
    const rt = c < n - 1 && regs[cell + 1] === g;
    const k = u + d + l + rt;
    per[g] += 4 - k;
    if (k === 1) tips++;
    if (k === 2 && ((u && d) || (l && rt))) corridors++;
  }
  let maxRatio = 0;
  let sum = 0;
  let edges = 0;
  for (let g = 0; g < n; g++) {
    const q = per[g] / (2 * Math.ceil(2 * Math.sqrt(size[g])));
    maxRatio = Math.max(maxRatio, q);
    sum += q;
    edges += per[g];
  }
  return { corridors, tips, edges, maxRatio, meanRatio: sum / n };
}

// Whether a 9×9 board's patches look like the plain maker's (the numbers
// were measured at 9×9 only).
export const shapeFits = (n, regs) => {
  const s = shapeOf(n, regs);
  return Object.keys(SHAPE).every((k) => s[k] <= SHAPE[k]);
};
