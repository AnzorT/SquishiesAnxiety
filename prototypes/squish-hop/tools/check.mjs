// Tests for engine.js. On thousands of small random boards with every
// twist (piles, friends, numbered friends, arrows, bubbles, beat tiles),
// the solver's count of full clears must equal a plain brute-force count
// (so its shortcuts never lose an answer), every answer it gives must
// replay to a full clear, and the chessboard check must never turn down a
// board that has one. Then every shipped level must have exactly the
// number of full clears levels.js says, and its stored
// solution must replay to a full clear. (Levels 1-4, the first steps, may
// have up to three; every later level has exactly one.)
// Run: node prototypes/squish-hop/tools/check.mjs
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
    for (const m of E.moves(lv, st)) walk(m.st);
  };
  walk(E.newState(lv));
  return count;
}

const FEATURES = [
  ['.', 0.46], ['#', 0.08], ['D', 0.07], ['F', 0.05], ['^', 0.035], ['>', 0.035], ['v', 0.035], ['<', 0.035],
  ['o', 0.07], ['a', 0.03], ['b', 0.03], ['c', 0.03],
];
function feature() {
  let r = rand();
  for (const [ch, p] of FEATURES) {
    if ((r -= p) < 0) return ch;
  }
  return '.';
}
function randomBoard(w, h, ordered) {
  const rows = [];
  for (let y = 0; y < h; y++) {
    let r = '';
    for (let x = 0; x < w; x++) r += feature();
    rows.push(r);
  }
  const cells = [];
  rows.forEach((r, y) => [...r].forEach((c, x) => c !== '#' && cells.push([x, y])));
  if (cells.length < 3) return null;
  const pick = () => cells.splice(Math.floor(rand() * cells.length), 1)[0];
  const put = ([x, y], ch) => (rows[y] = rows[y].slice(0, x) + ch + rows[y].slice(x + 1));
  put(pick(), 'S');
  put(pick(), 'G');
  if (ordered) {
    let k = 1;
    rows.forEach((r, y) => [...r].forEach((c, x) => c === 'F' && put([x, y], String(k++))));
  }
  return rows;
}

let boards = 0;
let solvable = 0;
const COVER = { piles: /D/, friends: /F/, ordered: /[1-9]/, arrows: /[\^>v<]/, bubbles: /o/, beats: /[abc]/ };
const covered = Object.fromEntries(Object.keys(COVER).map((k) => [k, 0]));
for (let t = 0; t < 40000; t++) {
  const rows = randomBoard(2 + Math.floor(rand() * 4), 2 + Math.floor(rand() * 3), rand() < 0.4);
  if (!rows) continue;
  const lv = E.parse(rows);
  if (lv.friends.length > 4) continue;
  const want = brute(lv);
  const r = E.search(lv, E.newState(lv), { count: true, cap: 1e9, limit: 1e9 });
  if (want !== r.count) {
    console.error('MISMATCH', rows, 'brute', want, 'search', r.count);
    process.exit(1);
  }
  for (const s of r.sols) {
    const p = E.replay(lv, s);
    if (!p.ok || !p.st.done || E.leftOf(lv, p.st.life) !== 0) {
      console.error('BAD ANSWER', rows, s);
      process.exit(1);
    }
  }
  if (want > 0 && !E.parityOk(lv)) {
    console.error('PARITY WRONG', rows);
    process.exit(1);
  }
  boards++;
  if (want) {
    solvable++;
    const all = rows.join('');
    for (const [name, re] of Object.entries(COVER)) if (re.test(all)) covered[name]++;
  }
}
console.log(`solver agrees with brute force on ${boards} boards (${solvable} clearable)`);
console.log('clearable boards with each twist:', JSON.stringify(covered));
for (const [name, n] of Object.entries(covered)) {
  if (n < 30) {
    console.error(`too few clearable boards with ${name}`);
    process.exit(1);
  }
}

let bad = 0;
LEVELS.forEach((L, i) => {
  const lv = E.parse(L.map);
  const r = E.search(lv, E.newState(lv), { count: true, cap: L.sols + 1, limit: 4e7 });
  const dirs = [...L.solution].map((c) => E.DCH.indexOf(c));
  const p = E.replay(lv, dirs);
  const okSol = p.ok && p.st.done && E.leftOf(lv, p.st.life) === 0;
  if (r.aborted || r.count !== L.sols || (i >= 4 && L.sols !== 1) || !okSol) {
    console.error(`level ${i + 1}: ${r.count}${r.aborted ? '+ (search cut short)' : ''} full clears, stored answer ${okSol ? 'ok' : 'BROKEN'}`);
    bad++;
  }
});
if (bad) process.exit(1);
console.log(`all ${LEVELS.length} levels have the full clears levels.js says (exactly one from level 5 on), and their stored answers replay`);
