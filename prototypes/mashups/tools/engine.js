/* Squish Squeeze engine v2 (pure; runs in the browser and in node).
   Rules:
   - A plush is 2x2. Walk into a 1-wide gap (one face cell open, the other solid)
     and it squeezes into a 1x4 strip; its back stays put, its front goes 2 cells in.
   - A strip puffs back to 2x2 at its leading end as soon as there is room,
     preferring the side it squeezed from. Anything in the way gets shoved 1 cell
     outward if it can move; otherwise that side doesn't count as room.
   - You push blocks and plushies one cell (no chains). A pushed plush that hits a
     gap squeezes too. A round plush can't push a block into a 1-wide gap, because
     its other half hits the wall.
   - Win: every plush round in its own bed, every toy box (o) holding a block. */
/*ENGINE-START*/
const SQE = (() => {
  const D = { left: [-1, 0], right: [1, 0], up: [0, -1], down: [0, 1] };
  const DIRS = ["left", "right", "up", "down"];
  function compile(level) {
    const H = level.map.length, W = level.map[0].length, floor = [], targets = [];
    for (let y = 0; y < H; y++) for (let x = 0; x < W; x++) {
      const ch = level.map[y][x];
      floor.push(ch !== "#");
      if (ch === "o") targets.push([x, y]);
    }
    return { W, H, floor, targets, level };
  }
  function start(L) {
    return { ps: L.level.plush.map(p => ({ x: p.x, y: p.y, w: 2, h: 2, side: 0 })), bs: L.level.blocks.map(b => b.slice()) };
  }
  const isFloor = (L, x, y) => x >= 0 && y >= 0 && x < L.W && y < L.H && L.floor[y * L.W + x];
  const inRect = (p, x, y) => x >= p.x && x < p.x + p.w && y >= p.y && y < p.y + p.h;
  const round = p => p.w === 2 && p.h === 2;
  function occAt(s, x, y) {
    for (let i = 0; i < s.ps.length; i++) if (inRect(s.ps[i], x, y)) return { t: "p", i };
    for (let i = 0; i < s.bs.length; i++) if (s.bs[i][0] === x && s.bs[i][1] === y) return { t: "b", i };
    return null;
  }
  const free = (L, s, x, y) => isFloor(L, x, y) && !occAt(s, x, y);
  function cellsOf(p) { const o = []; for (let j = 0; j < p.h; j++) for (let i = 0; i < p.w; i++) o.push([p.x + i, p.y + j]); return o; }
  function face(p, dx, dy) {
    const o = [];
    if (dx) { const fx = dx > 0 ? p.x + p.w : p.x - 1; for (let j = 0; j < p.h; j++) o.push([fx, p.y + j]); }
    else { const fy = dy > 0 ? p.y + p.h : p.y - 1; for (let i = 0; i < p.w; i++) o.push([p.x + i, fy]); }
    return o;
  }
  const clone = s => ({ ps: s.ps.map(p => ({ x: p.x, y: p.y, w: p.w, h: p.h, side: p.side })), bs: s.bs.map(b => b.slice()) });
  function squeezed(p, dx, dy, ox, oy) {
    if (dx) { const back = dx > 0 ? p.x : p.x + 1; return { x: dx > 0 ? back : back - 3, y: oy, w: 4, h: 1, side: oy === p.y ? 1 : -1 }; }
    const back = dy > 0 ? p.y : p.y + 1;
    return { x: ox, y: dy > 0 ? back : back - 3, w: 1, h: 4, side: ox === p.x ? 1 : -1 };
  }
  // motion along a strip's length: '+', '-', or null
  function lon(p, dx, dy) {
    if (round(p)) return null;
    if (p.h === 1 && dx) return dx > 0 ? "+" : "-";
    if (p.w === 1 && dy) return dy > 0 ? "+" : "-";
    return null;
  }
  function trySqueeze(L, s, p, dx, dy) {
    if (!round(p)) return false;
    const f = face(p, dx, dy), open = f.filter(([x, y]) => free(L, s, x, y));
    if (open.length !== 1) return false;
    const np = squeezed(p, dx, dy, open[0][0], open[0][1]);
    if (!cellsOf(np).every(([x, y]) => inRect(p, x, y) || free(L, s, x, y))) return false;
    Object.assign(p, np);
    return true;
  }
  // A pushed thing moves one cell, or (a round plush) squeezes into a gap. No chains.
  function moveObj(L, s, o, dx, dy, motion) {
    if (o.t === "b") {
      const b = s.bs[o.i], nx = b[0] + dx, ny = b[1] + dy;
      if (!free(L, s, nx, ny)) return false;
      b[0] = nx; b[1] = ny; return true;
    }
    const q = s.ps[o.i];
    if (face(q, dx, dy).every(([x, y]) => free(L, s, x, y))) { q.x += dx; q.y += dy; motion[o.i] = lon(q, dx, dy); return true; }
    if (trySqueeze(L, s, q, dx, dy)) { motion[o.i] = dx + dy > 0 ? "+" : "-"; return true; }
    return false;
  }
  function tryPuff(L, s, i, mot) {
    const p = s.ps[i], horiz = p.h === 1;
    const k = mot === "+" ? 2 : mot === "-" ? 0 : 1;
    const pref = p.side || -1;
    for (const side of [pref, -pref]) {
      const np = horiz ? { x: p.x + k, y: side < 0 ? p.y - 1 : p.y, w: 2, h: 2 } : { x: side < 0 ? p.x - 1 : p.x, y: p.y + k, w: 2, h: 2 };
      const sx = horiz ? 0 : side, sy = horiz ? side : 0;
      const s2 = clone(s);
      let ok = true, shoved = false;
      const done = new Set();
      for (const [x, y] of cellsOf(np)) {
        if (inRect(p, x, y)) continue;
        if (!isFloor(L, x, y)) { ok = false; break; }
        const o = occAt(s2, x, y);
        if (!o) continue;
        const key = o.t + o.i;
        if (done.has(key)) continue;
        done.add(key);
        if (o.t === "b") {
          const b = s2.bs[o.i], nx = b[0] + sx, ny = b[1] + sy;
          if (!isFloor(L, nx, ny) || inRect(np, nx, ny) || occAt(s2, nx, ny)) { ok = false; break; }
          b[0] = nx; b[1] = ny; shoved = true;
        } else {
          const q = s2.ps[o.i];
          if (!face(q, sx, sy).every(([fx, fy]) => isFloor(L, fx, fy) && !inRect(np, fx, fy) && !occAt(s2, fx, fy))) { ok = false; break; }
          q.x += sx; q.y += sy; shoved = true;
        }
      }
      if (ok) {
        Object.assign(s2.ps[i], { x: np.x, y: np.y, w: 2, h: 2, side: 0 });
        s.ps = s2.ps; s.bs = s2.bs;
        return shoved ? "shove" : "puff";
      }
    }
    return null;
  }
  function finish(L, s, motion, kind) {
    let ev = kind;
    for (let pass = 0; pass < 4; pass++) {
      let changed = false;
      for (let i = 0; i < s.ps.length; i++) {
        if (round(s.ps[i])) continue;
        const r = tryPuff(L, s, i, motion[i]);
        if (r) { changed = true; ev = r === "shove" || ev !== "shove" ? r : ev; motion[i] = null; }
      }
      if (!changed) break;
    }
    return { s, kind: ev };
  }
  // One move of plush `who`. Returns { s, kind } or null if nothing happens.
  function step(L, st, who, dir) {
    const [dx, dy] = D[dir];
    const s = clone(st), P = s.ps[who], f = face(P, dx, dy);
    const motion = new Array(s.ps.length).fill(null);
    let walls = 0;
    const objs = [], seen = new Set();
    for (const [x, y] of f) {
      if (!isFloor(L, x, y)) { walls++; continue; }
      const o = occAt(s, x, y);
      if (o && !seen.has(o.t + o.i)) { seen.add(o.t + o.i); objs.push(o); }
    }
    if (!walls) {
      const s2 = clone(s);
      const m2 = motion.slice();
      let ok = true;
      for (const o of objs) if (!moveObj(L, s2, o, dx, dy, m2)) { ok = false; break; }
      if (ok) {
        const P2 = s2.ps[who];
        if (face(P2, dx, dy).every(([x, y]) => free(L, s2, x, y))) {
          P2.x += dx; P2.y += dy; m2[who] = lon(P2, dx, dy);
          return finish(L, s2, m2, objs.length ? "push" : "move");
        }
        if (objs.length) return finish(L, s2, m2, "push");
      }
    }
    if (trySqueeze(L, s, P, dx, dy)) { motion[who] = dx + dy > 0 ? "+" : "-"; return finish(L, s, motion, "squeeze"); }
    return null;
  }
  function won(L, s) {
    return s.ps.every((p, i) => round(p) && p.x === L.level.plush[i].bed[0] && p.y === L.level.plush[i].bed[1]) &&
      L.targets.every(([x, y]) => s.bs.some(b => b[0] === x && b[1] === y));
  }
  function key(s) {
    let k = "";
    for (const p of s.ps) k += p.x + "," + p.y + "," + p.w + "," + (p.side || 0) + "|";
    return k + s.bs.map(b => b[0] * 100 + b[1]).sort((a, b) => a - b).join(",");
  }
  const movers = L => L.level.plush.map((p, i) => (p.sleepy ? -1 : i)).filter(i => i >= 0);
  // Breadth-first search. Returns the shortest list of [who, dir], [] if already won, null if stuck.
  function solve(L, st, cap) {
    cap = cap || 400000;
    if (won(L, st)) return [];
    const M = movers(L), seen = new Map([[key(st), null]]), q = [st], keys = [key(st)];
    for (let h = 0; h < q.length; h++) {
      const s = q[h], ks = keys[h];
      for (const who of M) for (const d of DIRS) {
        const r = step(L, s, who, d);
        if (!r) continue;
        const k = key(r.s);
        if (seen.has(k)) continue;
        seen.set(k, [ks, who, d]);
        if (won(L, r.s)) {
          const path = [];
          let cur = k;
          while (seen.get(cur)) { const [pk, w, dd] = seen.get(cur); path.push([w, dd]); cur = pk; }
          return path.reverse();
        }
        if (seen.size > cap) return undefined;
        q.push(r.s); keys.push(k);
      }
    }
    return null;
  }
  return { D, DIRS, compile, start, step, won, solve, key, movers, round, inRect };
})();
/*ENGINE-END*/
if (typeof module !== "undefined") module.exports = SQE;
