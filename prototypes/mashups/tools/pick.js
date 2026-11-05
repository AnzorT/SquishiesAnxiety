// Picks the shipped levels from the search results (b1/b2/sl.json, made by gen.js),
// walls off floor nothing can ever reach, trims extra border walls, re-solves
// for the par, and writes levels.js. usage: node pick.js
const E = require('./engine.js'); const fs = require('fs'); const path = require('path');
const J = f => JSON.parse(fs.readFileSync(path.join(__dirname, f), 'utf8')).best;
const b1 = J('b1.json'), b2 = J('b2.json'), sl = J('sl.json');
const intro = { map: ["##########","######...#","#....#...#","#....###.#","#....###.#","#....##..#","#........#","##########"], plush:[{x:1,y:5,bed:[7,1]}], blocks:[[7,1]] };
const picks = [
  ['first', 'First squeeze', 'Find the gap at the bottom of the room. The block on the bed gets shoved off when you pop out.', intro],
  ['toyfirst', 'Toy first', 'Your bed is right next to you, but the toy block has to go in its box first.', b1[3].lvl],
  ['popshove', 'Pop and shove', 'Where you pop out decides which way the block gets shoved.', b1[0].lvl],
  ['sleepy', 'Sleepyhead', 'Bean is fast asleep. Push Bean into the green bed. Pushed plushies squeeze through gaps too.', sl[3].lvl],
  ['twotoys', 'Two toys', 'Two blocks, two boxes. A block pushed into a corner stays there for good.', b2[4].lvl],
  ['rush', 'Lights out', 'Bean, one block, not much room. Hint tells you if you are stuck.', sl[2].lvl],
];
function explore(lvl) {
  const L = E.compile(lvl), M = E.movers(L), st = E.start(L), seen = new Set([E.key(st)]), q = [st], used = new Set();
  for (let h = 0; h < q.length; h++) {
    const s = q[h];
    for (const p of s.ps) for (let j = 0; j < p.h; j++) for (let i = 0; i < p.w; i++) used.add((p.x + i) + ',' + (p.y + j));
    for (const b of s.bs) used.add(b[0] + ',' + b[1]);
    for (const w of M) for (const d of E.DIRS) { const r = E.step(L, s, w, d); if (!r) continue; const k = E.key(r.s); if (!seen.has(k)) { seen.add(k); q.push(r.s); } }
  }
  return { used, states: q.length };
}
// keep a single wall border around the floor
function trim(lvl) {
  let x0 = 99, y0 = 99, x1 = -1, y1 = -1;
  lvl.map.forEach((row, y) => [...row].forEach((ch, x) => { if (ch !== '#') { x0 = Math.min(x0, x); x1 = Math.max(x1, x); y0 = Math.min(y0, y); y1 = Math.max(y1, y); } }));
  const dx = x0 - 1, dy = y0 - 1;
  lvl.map = lvl.map.slice(y0 - 1, y1 + 2).map(r => r.slice(x0 - 1, x1 + 2));
  lvl.plush.forEach(p => { p.x -= dx; p.y -= dy; p.bed = [p.bed[0] - dx, p.bed[1] - dy]; });
  lvl.blocks = lvl.blocks.map(b => [b[0] - dx, b[1] - dy]);
}
const out = [];
for (const [id, name, tip, lvl0] of picks) {
  const lvl = JSON.parse(JSON.stringify(lvl0));
  const before = E.solve(E.compile(lvl), E.start(E.compile(lvl)));
  const { used, states } = explore(lvl);
  lvl.map = lvl.map.map((row, y) => row.split('').map((ch, x) => ch === '.' && !used.has(x + ',' + y) ? '#' : ch).join(''));
  trim(lvl);
  const L = E.compile(lvl), sol = E.solve(L, E.start(L)), after = explore(lvl);
  console.log(id, 'par', before.length, '->', sol.length, 'states', states, '->', after.states);
  lvl.plush.forEach((p, i) => { p.name = i ? 'Bean' : 'Mochi'; });
  out.push({ id, name, tip, par: sol.length, map: lvl.map, plush: lvl.plush, blocks: lvl.blocks });
  console.log(lvl.map.join('\n'));
}
fs.writeFileSync(path.join(__dirname, 'levels.js'),'const SQZ_LEVELS = ' + JSON.stringify(out, null, 1).replace(/\n\s+(?=[\d\-\]])/g, '') + ';\n');
