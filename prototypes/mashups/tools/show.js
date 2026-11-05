// node show.js file.json [count]  -> ASCII view + metrics of the top candidates
const E = require("./engine.js");
const fs = require("fs");
const [file, cnt] = process.argv.slice(2);
const data = JSON.parse(fs.readFileSync(file, "utf8"));
function render(lvl) {
  const g = lvl.map.map(r => r.split(""));
  lvl.plush.forEach((p, i) => {
    const [bx, by] = p.bed;
    for (const [dx, dy] of [[0, 0], [1, 0], [0, 1], [1, 1]]) if (g[by + dy][bx + dx] !== "o") g[by + dy][bx + dx] = i ? "f" : "m";
    for (const [dx, dy] of [[0, 0], [1, 0], [0, 1], [1, 1]]) g[p.y + dy][p.x + dx] = i ? "F" : "M";
  });
  for (const [x, y] of lvl.blocks) g[y][x] = g[y][x] === "o" ? "*" : "B";
  return g.map(r => r.join("")).join("\n");
}
// full exploration: how many reachable states can still be won?
function deadness(lvl) {
  const L = E.compile(lvl), M = E.movers(L), st = E.start(L);
  const idx = new Map(), states = [st], edges = [];
  idx.set(E.key(st), 0);
  for (let h = 0; h < states.length && states.length < 300000; h++) {
    edges[h] = [];
    for (const w of M) for (const d of E.DIRS) {
      const r = E.step(L, states[h], w, d); if (!r) continue;
      const k = E.key(r.s); let j = idx.get(k);
      if (j === undefined) { j = states.length; idx.set(k, j); states.push(r.s); }
      edges[h].push(j);
    }
  }
  const n = states.length, rev = Array.from({ length: n }, () => []);
  for (let h = 0; h < n; h++) for (const j of edges[h] || []) rev[j].push(h);
  const alive = new Uint8Array(n), q = [];
  for (let h = 0; h < n; h++) if (E.won(L, states[h])) { alive[h] = 1; q.push(h); }
  for (let k = 0; k < q.length; k++) for (const p of rev[q[k]]) if (!alive[p]) { alive[p] = 1; q.push(p); }
  let a = 0; for (let h = 0; h < n; h++) a += alive[h];
  return { states: n, dead: n - a, deadPct: Math.round(100 * (n - a) / n) };
}
console.log("tried", data.tried, "solved", data.solved);
data.best.slice(0, +cnt || 8).forEach((b, i) => {
  const d = deadness(b.lvl);
  console.log(`\n#${i} score ${b.score} len ${b.len} kinds ${JSON.stringify(b.kinds)} states ${d.states} dead ${d.deadPct}%`);
  console.log(render(b.lvl));
  console.log("solution:", b.sol);
});
