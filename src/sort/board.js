// Squish Sort's board (SQUISH_SORT.md), kept free of React so it can be
// tested alone: dealing a level, and what a drop does.
//
// A board is
//   slots       rows × cols spots, numbered row by row from the top shelf
//   pieces      [{ id, uri, home }]: the squishies of the level, then the
//               impostors (home null: never inside)
//   start       { [slot]: piece } — what the peek shows first
//   swaps       [[slotA, slotB]] — played in turn near the end of the peek
//               (a squishy and an empty spot: it hops over)
//   after       { [piece]: { kind: 'slot' | 'tray', i } } — where each one is
//               once the doors open again: the mixed-up ones inside, in
//               the wrong spots; the rest tumbled out into the tray
//   foodBefore  { [slot]: kind } — the clutter (food, toys) during the peek
//   foodAfter   { [slot]: kind } — the same clutter, moved about by the
//               shake: never on a squishy's spot, but anywhere else, so it
//               can't be used to remember by
// and a piece's `home` is where it sat when the doors closed (after the
// swaps): where it has to go back.

const pickN = (list, n, random) => {
  const pool = list.slice();
  const out = [];
  while (out.length < n && pool.length) out.push(pool.splice(Math.floor(random() * pool.length), 1)[0]);
  return out;
};
const shuffle = (list, random) => pickN(list, list.length, random);
const range = (n) => [...Array(n).keys()];

// `pool`: [{ id, uri }] to draw from (distinct squishies); `kinds`: how
// many kinds of clutter there are to draw.
export function makeBoard(spec, pool, random = Math.random, kinds = 16) {
  const slots = spec.rows * spec.cols;
  const count = Math.min(spec.count, slots, pool.length);
  const drawn = pickN(pool, count + (spec.decoys || 0), random);
  const real = drawn.slice(0, count);
  const fakes = drawn.slice(count);
  const seats = pickN(range(slots), count, random);
  const start = {};
  seats.forEach((s, k) => (start[s] = k));
  // the clutter, on spots no squishy has, all kinds before any repeats
  const nFoods = Math.max(0, Math.min(spec.foods || 0, slots - count - 1));
  const kindsFor = (n) => {
    const out = [];
    while (out.length < n) out.push(...shuffle(range(kinds), random));
    return out.slice(0, n);
  };
  const foodKinds = kindsFor(nFoods);
  const foodBefore = {};
  pickN(
    range(slots).filter((s) => start[s] == null),
    nFoods,
    random,
  ).forEach((s, j) => (foodBefore[s] = foodKinds[j]));

  // the swaps: the first trades two squishies, the next sends one to an
  // empty spot (not one with clutter) if there is one
  const now = { ...start };
  const swaps = [];
  for (let n = 0; n < (spec.swaps || 0); n++) {
    const full = Object.keys(now).map(Number);
    const empty = range(slots).filter((s) => now[s] == null && foodBefore[s] == null);
    let pair;
    if (n % 2 === 1 && empty.length) pair = [pickN(full, 1, random)[0], pickN(empty, 1, random)[0]];
    else if (full.length >= 2) pair = pickN(full, 2, random);
    else continue;
    const [a, b] = pair;
    const pa = now[a];
    const pb = now[b];
    delete now[a];
    delete now[b];
    if (pa != null) now[b] = pa;
    if (pb != null) now[a] = pb;
    swaps.push(pair);
  }
  const home = {};
  Object.entries(now).forEach(([s, k]) => (home[k] = Number(s)));
  const pieces = [...real.map((c, k) => ({ id: c.id, uri: c.uri, home: home[k] })), ...fakes.map((c) => ({ id: c.id, uri: c.uri, home: null }))];
  const homes = new Set(Object.values(home));

  // the shake: `mixed` of them stay inside, each somewhere it doesn't belong
  const mixedK = pickN(range(count), Math.min(spec.mixed || 0, count), random);
  const after = {};
  let spots = null;
  for (let tries = 0; tries < 200 && !spots; tries++) {
    const pickSpots = pickN(range(slots), mixedK.length, random);
    if (pickSpots.every((s, j) => s !== home[mixedK[j]])) spots = pickSpots;
  }
  // (a sure answer: each takes the next one's home)
  if (!spots) spots = mixedK.map((_, j) => home[mixedK[(j + 1) % mixedK.length]]);
  mixedK.forEach((k, j) => (after[k] = { kind: 'slot', i: spots[j] }));
  const out = shuffle(
    pieces.map((_, k) => k).filter((k) => !after[k]),
    random,
  );
  out.forEach((k, j) => (after[k] = { kind: 'tray', i: j }));
  // ...and the clutter goes anywhere but a squishy's spot or a mixed-up one
  const taken = new Set(mixedK.map((k) => after[k].i));
  const foodAfter = {};
  const free = range(slots).filter((s) => !homes.has(s) && !taken.has(s));
  // keep at least one empty spot that isn't anyone's, so the empty spots
  // never give the answer away
  pickN(free, Math.min(nFoods, Math.max(0, free.length - 1)), random).forEach((s, j) => (foodAfter[s] = foodKinds[j]));
  return { rows: spec.rows, cols: spec.cols, slots, pieces, start, swaps, after, foodBefore, foodAfter, trayCap: count + fakes.length };
}

// --- playing ---------------------------------------------------------------------
// The play state: { at: { [piece]: { kind, i } }, locked: { [piece]: true },
// gone: { [piece]: true } } (gone: an impostor found out).

export const startState = (board) => ({ at: { ...board.after }, locked: {}, gone: {} });

// the piece in slot `i` now, or null
export function occupant(state, i) {
  for (const k of Object.keys(state.at)) {
    const a = state.at[k];
    if (!state.gone[k] && a.kind === 'slot' && a.i === i) return Number(k);
  }
  return null;
}

function freeTray(board, state) {
  const used = new Set(
    Object.keys(state.at)
      .filter((k) => !state.gone[k] && state.at[k].kind === 'tray')
      .map((k) => state.at[k].i),
  );
  for (let j = 0; j < board.trayCap; j++) if (!used.has(j)) return j;
  return board.trayCap;
}

// Piece `k` dropped on `target` ({ kind: 'slot', i } | { kind: 'tray' } |
// null: nowhere). Returns { state, outcome, bumped }:
//   'lock'      its home: it stays (a mixed-up one sitting there goes where
//               `k` came from: `bumped`)
//   'wrong'     not its home: a mistake, it goes back
//   'impostor'  an impostor put in: a mistake, and it's found out (gone)
//   'tray'      a mixed-up one taken out to the tray (no mistake)
//   'none'      nothing happens (back where it was): dropped nowhere, on a
//               squishy already home, or on clutter
export function drop(board, state, k, target) {
  const none = { state, outcome: 'none', bumped: null };
  const from = state.at[k];
  if (!from || state.locked[k] || state.gone[k]) return none;
  if (!target || target.kind === 'tray') {
    if (from.kind === 'tray') return none;
    return { state: { ...state, at: { ...state.at, [k]: { kind: 'tray', i: freeTray(board, state) } } }, outcome: 'tray', bumped: null };
  }
  const i = target.i;
  if (board.foodAfter && board.foodAfter[i] != null) return none;
  const occ = occupant(state, i);
  if (occ === k || (occ != null && state.locked[occ])) return none;
  const home = board.pieces[k].home;
  if (home == null) return { state: { ...state, gone: { ...state.gone, [k]: true } }, outcome: 'impostor', bumped: null };
  if (home !== i) return { state, outcome: 'wrong', bumped: null };
  const at = { ...state.at, [k]: { kind: 'slot', i } };
  if (occ != null) at[occ] = from;
  return { state: { ...state, at, locked: { ...state.locked, [k]: true } }, outcome: 'lock', bumped: occ };
}

// every real squishy home
export const solved = (board, state) => board.pieces.every((p, k) => p.home == null || state.locked[k]);
