// Random level search for Squish Squeeze v2.
// usage: node gen.js <seed> <seconds> <mode: block1|block2|sleepy> <out.json>
const E = require("./engine.js");
const fs = require("fs");
const [seedArg, secArg, mode, out] = process.argv.slice(2);
let seed = +seedArg || 1;
const R = () => { seed |= 0; seed = seed + 0x6D2B79F5 | 0; let t = Math.imul(seed ^ seed >>> 15, 1 | seed); t = t + Math.imul(t ^ t >>> 7, 61 | t) ^ t; return ((t ^ t >>> 14) >>> 0) / 4294967296; };
const ri = (a, b) => a + Math.floor(R() * (b - a + 1));

function makeMap(W, H) {
  const g = [];
  for (let y = 0; y < H; y++) g.push(new Array(W).fill("#"));
  const style = R();
  if (style < 0.5) {
    // open interior with random wall bits
    for (let y = 1; y < H - 1; y++) for (let x = 1; x < W - 1; x++) g[y][x] = ".";
    const n = ri(10, 22);
    for (let i = 0; i < n; i++) {
      const x = ri(1, W - 2), y = ri(1, H - 2);
      g[y][x] = "#";
      if (R() < 0.45) { const hz = R() < 0.5, len = ri(1, 3); for (let k = 1; k <= len; k++) { const xx = hz ? x + k : x, yy = hz ? y : y + k; if (xx > 0 && yy > 0 && xx < W - 1 && yy < H - 1) g[yy][xx] = "#"; } }
    }
  } else {
    // rooms joined by 1-wide corridors
    const rooms = [];
    const nr = ri(2, 4);
    for (let i = 0; i < nr; i++) {
      const w = ri(2, 4), h = ri(2, 4), x = ri(1, W - 1 - w), y = ri(1, H - 1 - h);
      rooms.push({ x, y, w, h });
      for (let yy = y; yy < y + h; yy++) for (let xx = x; xx < x + w; xx++) g[yy][xx] = ".";
    }
    for (let i = 1; i < rooms.length; i++) {
      const a = rooms[i - 1], b = rooms[i];
      let x = ri(a.x, a.x + a.w - 1), y = ri(a.y, a.y + a.h - 1);
      const tx = ri(b.x, b.x + b.w - 1), ty = ri(b.y, b.y + b.h - 1);
      const hFirst = R() < 0.5;
      const walk = (axis) => { if (axis) { while (x !== tx) { x += Math.sign(tx - x); g[y][x] = "."; } } else { while (y !== ty) { y += Math.sign(ty - y); g[y][x] = "."; } } };
      walk(hFirst); walk(!hFirst);
    }
    const extra = ri(0, 6);
    for (let i = 0; i < extra; i++) g[ri(1, H - 2)][ri(1, W - 2)] = ".";
  }
  return g;
}
function spots2(g) { const o = []; for (let y = 1; y < g.length - 2; y++) for (let x = 1; x < g[0].length - 2; x++) if (g[y][x] === "." && g[y][x + 1] === "." && g[y + 1][x] === "." && g[y + 1][x + 1] === ".") o.push([x, y]); return o; }
function spots1(g) { const o = []; for (let y = 1; y < g.length - 1; y++) for (let x = 1; x < g[0].length - 1; x++) if (g[y][x] === ".") o.push([x, y]); return o; }
const pick = a => a[Math.floor(R() * a.length)];
const overl = (a, cells) => cells.some(([x, y]) => x >= a[0] && x < a[0] + 2 && y >= a[1] && y < a[1] + 2);
const sq = ([x, y]) => [[x, y], [x + 1, y], [x, y + 1], [x + 1, y + 1]];

function candidate() {
  const W = ri(8, 10), H = ri(7, 9);
  const g = makeMap(W, H);
  const s2 = spots2(g);
  if (s2.length < 3) return null;
  const used = [];
  const take2 = () => { for (let t = 0; t < 40; t++) { const p = pick(s2); if (!overl(p, used)) { used.push(...sq(p)); return p; } } return null; };
  const me = take2(), bed = take2();
  if (!me || !bed) return null;
  const plush = [{ x: me[0], y: me[1], bed }];
  if (mode === "sleepy") { const f = take2(), fb = take2(); if (!f || !fb) return null; plush.push({ x: f[0], y: f[1], bed: fb, sleepy: true }); }
  const nb = mode === "block2" ? 2 : (mode === "sleepy" ? ri(0, 1) : 1);
  const s1 = spots1(g).filter(c => !used.some(u => u[0] === c[0] && u[1] === c[1]));
  if (s1.length < 2 * nb + 2) return null;
  const blocks = [], targets = [];
  for (let i = 0; i < nb; i++) {
    for (let t = 0; t < 40; t++) { const c = pick(s1); if (![...blocks, ...targets].some(u => u[0] === c[0] && u[1] === c[1])) { blocks.push(c); break; } }
    for (let t = 0; t < 40; t++) { const c = pick(s1); if (![...blocks, ...targets].some(u => u[0] === c[0] && u[1] === c[1])) { targets.push(c); break; } }
  }
  if (blocks.length !== nb || targets.length !== nb) return null;
  for (const [x, y] of targets) g[y][x] = "o";
  return { map: g.map(r => r.join("")), plush, blocks };
}
function analyse(lvl) {
  const L = E.compile(lvl);
  const st = E.start(L);
  const sol = E.solve(L, st, 250000);
  if (!sol || !sol.length) return null;
  let s = st;
  const kinds = { move: 0, push: 0, squeeze: 0, puff: 0, shove: 0 };
  for (const [w, d] of sol) { const r = E.step(L, s, w, d); kinds[r.kind]++; s = r.s; }
  return { len: sol.length, kinds, sol: sol.map(m => (m[0] ? "B" : "") + m[1][0]).join("") };
}
const deadline = Date.now() + (+secArg || 60) * 1000;
const best = [];
let tried = 0, solved = 0;
while (Date.now() < deadline) {
  const lvl = candidate();
  if (!lvl) continue;
  tried++;
  const a = analyse(lvl);
  if (!a) continue;
  solved++;
  const k = a.kinds;
  if (k.squeeze < 2) continue;
  const score = a.len + 4 * k.shove + 2 * k.squeeze + (k.push > 0 ? 3 : 0);
  best.push({ score, ...a, lvl });
  best.sort((x, y) => y.score - x.score);
  if (best.length > 25) best.pop();
}
fs.writeFileSync(out, JSON.stringify({ tried, solved, best }, null, 1));
console.log("tried", tried, "solved", solved, "top", best.slice(0, 5).map(b => b.score + "/" + b.len));
