// Tests for engine.js: the solver's shortcuts (the shape checks that cut
// the search short) never lose an answer. On many small random boards it
// counts the full-clear paths both with the solver and with a plain
// brute-force search, and they must agree. Then every shipped level must
// have a full clear. Run: node prototypes/squish-hop/tools/check.mjs
import { createRequire } from 'node:module';
const require = createRequire(import.meta.url);
const E = require('../engine.js');
const { LEVELS } = require('../levels.js');

let seed = 12345;
const rand = () => ((seed = (seed * 1103515245 + 12345) & 0x7fffffff) / 0x7fffffff);

function brute(lv) {
  let count = 0;
  const walk = (st) => {
    if (st.done) {
      if (E.leftOf(lv, st.life) === 0) count++;
      return;
    }
    for (const j of E.moves(lv, st)) walk(E.step(lv, st, j));
  };
  walk(E.newState(lv));
  return count;
}

function randomBoard(w, h) {
  const rows = [];
  for (let y = 0; y < h; y++) {
    let r = '';
    for (let x = 0; x < w; x++) {
      const p = rand();
      r += p < 0.15 ? '#' : p < 0.27 ? 'D' : p < 0.33 ? 'F' : '.';
    }
    rows.push(r);
  }
  const cells = [];
  rows.forEach((r, y) => [...r].forEach((c, x) => c !== '#' && cells.push([x, y])));
  if (cells.length < 3) return null;
  const pick = () => cells.splice(Math.floor(rand() * cells.length), 1)[0];
  const put = ([x, y], ch) => (rows[y] = rows[y].slice(0, x) + ch + rows[y].slice(x + 1));
  put(pick(), 'S');
  put(pick(), 'G');
  return rows;
}

let boards = 0;
let solvable = 0;
for (let t = 0; t < 3000; t++) {
  const rows = randomBoard(2 + Math.floor(rand() * 3), 2 + Math.floor(rand() * 3));
  if (!rows) continue;
  const lv = E.parse(rows);
  if (lv.friends.length > 4) continue;
  const want = brute(lv);
  const got = E.search(lv, E.newState(lv), { count: true, cap: 1e9, limit: 1e9 }).count;
  if (want !== got) {
    console.error('MISMATCH', rows, 'brute', want, 'search', got);
    process.exit(1);
  }
  if (want > 0 && !E.parityOk(lv)) {
    console.error('PARITY WRONG', rows);
    process.exit(1);
  }
  boards++;
  if (want) solvable++;
}
console.log(`solver agrees with brute force on ${boards} boards (${solvable} clearable)`);

LEVELS.forEach((L, i) => {
  const lv = E.parse(L.map);
  const r = E.search(lv, E.newState(lv), { count: true, cap: 1e6, limit: 5e7 });
  if (!r.count) {
    console.error(`level ${i + 1} has no full clear`);
    process.exit(1);
  }
  console.log(`level ${i + 1}: ${r.count}${r.aborted ? '+' : ''} full clears, ${E.leftOf(lv, lv.life)} hops`);
});
