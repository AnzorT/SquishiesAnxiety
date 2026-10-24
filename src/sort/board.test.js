// node src/sort/board.test.js — Squish Sort's levels and board rules.
import assert from 'node:assert/strict';
import { drop, makeBoard, occupant, solved, startState } from './board.js';
import { HEARTS, LEVELS, LEVEL_LIST, afterLevel, coinsFor, levelSpec, nextSkill, record, skillShift, starsFor } from './levels.js';

// a seeded random
const rng = (seed) => () => {
  seed = (seed * 16807) % 2147483647;
  return (seed - 1) / 2147483646;
};
const POOL = Array.from({ length: 27 }, (_, i) => ({ id: String(i), uri: `u${i}` }));

// levels: 50, in bands that only grow, every one with room left over
assert.equal(LEVELS, 50);
assert.equal(LEVEL_LIST.length, 50);
// level 1 is one shelf, easy; the last is eight
assert.deepEqual([levelSpec(1).rows, levelSpec(1).cols, levelSpec(1).tier, levelSpec(1).count], [1, 4, 0, 2]);
assert.equal(levelSpec(50).rows, 8);
for (let lv = 1; lv <= LEVELS; lv++) {
  for (const skill of [-2, 0, 2]) {
    const s = levelSpec(lv, skill);
    const slots = s.rows * s.cols;
    assert.ok(s.count + s.foods <= slots - (slots <= 8 ? 1 : 3), `lv ${lv} leaves empty spots`);
    // as much clutter as the room left allows, up to about four spots in ten
    assert.ok(s.foods >= Math.min(Math.round(slots * 0.4), slots - s.count - (slots <= 8 ? 1 : 3)), `lv ${lv} is cluttered`);
    assert.ok(s.mixed < s.count, lv);
    assert.ok(s.peekMs >= 3800 && s.peekMs <= 7500, `lv ${lv} peek ${s.peekMs}`);
    assert.ok(s.parMs < s.limitMs, lv);
  }
  if (lv > 1) assert.ok(LEVEL_LIST[lv - 1].rows * LEVEL_LIST[lv - 1].cols >= LEVEL_LIST[lv - 2].rows * LEVEL_LIST[lv - 2].cols, lv);
}
assert.equal(levelSpec(1).peekMs, 5000); // "for like 5 seconds"
// no twists on the first levels; then one at a time: impostors at 6, mixed up at 10, the swap at 14
for (let lv = 1; lv <= 5; lv++) assert.ok(!levelSpec(lv).decoys && !levelSpec(lv).swaps && !levelSpec(lv).mixed, lv);
assert.ok(levelSpec(6).decoys && !levelSpec(6).swaps && !levelSpec(6).mixed);
assert.ok(levelSpec(10).mixed && !levelSpec(10).decoys && !levelSpec(10).swaps);
assert.ok(levelSpec(14).swaps && !levelSpec(14).decoys);
// expert has them all
const ex = LEVEL_LIST.findIndex((l) => l.tier === 3) + 1;
assert.ok(levelSpec(ex).decoys && levelSpec(ex).swaps && levelSpec(ex).mixed);
// adaptive: skill moves the tier one step at most, never the size
assert.equal(skillShift(0), 0);
assert.equal(levelSpec(1, 2).tier, 1);
assert.equal(levelSpec(1, 2).rows, 1);
assert.equal(levelSpec(1, -2).tier, 0);
assert.equal(levelSpec(20, 2).rows, levelSpec(20, -2).rows);
assert.ok(nextSkill(0, { won: true, stars: 3 }) > 0 && nextSkill(0, { won: false }) < 0);

// stars and coins
const s1 = levelSpec(1);
assert.equal(starsFor(s1, { mistakes: 0, ms: 1000 }), 3);
assert.equal(starsFor(s1, { mistakes: 0, ms: s1.parMs + 1 }), 2); // too slow for 3
assert.equal(starsFor(s1, { mistakes: 1, ms: 1000 }), 2);
assert.equal(starsFor(s1, { mistakes: 2, ms: 1000 }), 1);
assert.equal(HEARTS, 3);
assert.ok(coinsFor(s1, 3) > coinsFor(s1, 1));
assert.ok(coinsFor(levelSpec(40), 3) > coinsFor(levelSpec(1), 3));

// dealing: every board keeps its promises
for (let seed = 1; seed <= 400; seed++) {
  const spec = levelSpec(1 + (seed % 50), (seed % 5) - 2);
  const b = makeBoard(spec, POOL, rng(seed));
  const real = b.pieces.filter((p) => p.home != null);
  const fakes = b.pieces.filter((p) => p.home == null);
  assert.equal(real.length, spec.count);
  assert.equal(fakes.length, spec.decoys);
  assert.equal(new Set(b.pieces.map((p) => p.id)).size, b.pieces.length, 'all different squishies');
  assert.equal(new Set(real.map((p) => p.home)).size, real.length, 'one per spot');
  real.forEach((p) => assert.ok(p.home >= 0 && p.home < b.slots));
  assert.equal(Object.keys(b.start).length, spec.count);
  assert.equal(b.swaps.length, spec.swaps);
  // the clutter: as much as asked, never under a squishy at the peek…
  assert.equal(Object.keys(b.foodBefore).length, spec.foods);
  Object.keys(b.foodBefore).forEach((s) => assert.equal(b.start[s], undefined));
  // …and the swaps never land on it
  b.swaps.forEach(([x, y]) => [x, y].forEach((s) => assert.equal(b.foodBefore[s], undefined)));
  // replaying the swaps on the start gives the homes
  const now = { ...b.start };
  b.swaps.forEach(([x, y]) => {
    const px = now[x];
    const py = now[y];
    delete now[x];
    delete now[y];
    if (px != null) now[y] = px;
    if (py != null) now[x] = py;
  });
  Object.entries(now).forEach(([s, k]) => assert.equal(b.pieces[k].home, Number(s)));
  // after the shake: the mixed-up ones inside and wrong, the rest in the tray
  const inside = Object.entries(b.after).filter(([, a]) => a.kind === 'slot');
  assert.equal(inside.length, spec.mixed);
  inside.forEach(([k, a]) => assert.notEqual(b.pieces[k].home, a.i, 'mixed-up ones are in the wrong spot'));
  assert.equal(new Set(inside.map(([, a]) => a.i)).size, inside.length);
  const tray = Object.values(b.after).filter((a) => a.kind === 'tray').map((a) => a.i);
  assert.deepEqual(tray.slice().sort((x, y) => x - y), [...Array(tray.length).keys()]);
  assert.equal(Object.keys(b.after).length, b.pieces.length);
  // the moved clutter: never on a home or a mixed-up one, and an empty spot
  // that is nobody's is always left (so the gaps don't give the answer)
  const homes = new Set(real.map((p) => p.home));
  const mixedAt = new Set(inside.map(([, a]) => a.i));
  Object.keys(b.foodAfter).forEach((s) => {
    assert.ok(!homes.has(Number(s)) && !mixedAt.has(Number(s)));
  });
  const decoyGaps = [...Array(b.slots).keys()].filter((s) => !homes.has(s) && !mixedAt.has(s) && b.foodAfter[s] == null);
  assert.ok(decoyGaps.length >= 1, `seed ${seed} leaves a decoy gap`);
}

// playing: a hand-made board (2×2, A home 0, B home 3, impostor C, A mixed into slot 3, food on 1)
const B = { rows: 2, cols: 2, slots: 4, trayCap: 3, foodAfter: { 1: 4 }, pieces: [{ id: 'a', home: 0 }, { id: 'b', home: 3 }, { id: 'c', home: null }], after: { 0: { kind: 'slot', i: 3 }, 1: { kind: 'tray', i: 0 }, 2: { kind: 'tray', i: 1 } } };
let st = startState(B);
assert.equal(occupant(st, 3), 0);
// on the clutter: nothing happens, no mistake
assert.equal(drop(B, st, 1, { kind: 'slot', i: 1 }).outcome, 'none');
// wrong spot: a mistake, nothing moves
let r = drop(B, st, 1, { kind: 'slot', i: 2 });
assert.equal(r.outcome, 'wrong');
assert.deepEqual(r.state.at, st.at);
// B home, where mixed-up A sits: B stays, A goes to B's tray spot
r = drop(B, st, 1, { kind: 'slot', i: 3 });
assert.equal(r.outcome, 'lock');
assert.equal(r.bumped, 0);
assert.deepEqual(r.state.at[0], { kind: 'tray', i: 0 });
st = r.state;
// a locked one can't move, and nothing lands on it
assert.equal(drop(B, st, 1, { kind: 'slot', i: 0 }).outcome, 'none');
assert.equal(drop(B, st, 0, { kind: 'slot', i: 3 }).outcome, 'none');
// the impostor anywhere inside: found out
r = drop(B, st, 2, { kind: 'slot', i: 2 });
assert.equal(r.outcome, 'impostor');
assert.ok(r.state.gone[2]);
st = r.state;
assert.ok(!solved(B, st));
st = drop(B, st, 0, { kind: 'slot', i: 0 }).state;
assert.ok(solved(B, st));
// a mixed-up one can be taken out to the tray, no mistake
st = startState(B);
r = drop(B, st, 0, { kind: 'tray' });
assert.equal(r.outcome, 'tray');
assert.deepEqual(r.state.at[0], { kind: 'tray', i: 2 });
assert.equal(drop(B, r.state, 0, { kind: 'tray' }).outcome, 'none');
// dropped nowhere: back where it was
assert.equal(drop(B, startState(B), 1, null).outcome, 'none');

// the record: a win unlocks the next level of that container only, and moves its skill
const p = { sort: { fridge: { lv: 3, best: { 1: 3 } } } };
const out = afterLevel(p, 'fridge', levelSpec(3), { won: true, mistakes: 1, ms: 5000 });
assert.equal(out.stars, 2);
assert.equal(out.update['sort.fridge.lv'], 4);
assert.equal(out.update['sort.fridge.best.3'], 2);
assert.ok(out.update['sort.fridge.skill'] > 0);
assert.ok(out.coins > 0 && out.unlocked);
assert.equal(afterLevel(p, 'fridge', levelSpec(1), { won: true, mistakes: 2, ms: 1 }).update['sort.fridge.best.1'], undefined); // not better
const lost = afterLevel(p, 'cupboard', levelSpec(1), { won: false });
assert.equal(lost.coins, 0);
assert.ok(lost.update['sort.cupboard.skill'] < 0);
assert.equal(record(p).cupboard.lv, 1);
assert.equal(afterLevel({ sort: { fridge: { lv: 50 } } }, 'fridge', levelSpec(50), { won: true, mistakes: 0, ms: 1 }).unlocked, false);

console.log('sort board.test.js: all passed');
