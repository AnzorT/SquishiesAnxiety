// Fruit Patch chests for ChestModels: Berry Punnet -> Orchard Crate -> Picnic Hamper -> Golden Harvest Chest -> Rainbow Fruit Jewel Box.
(function () {
'use strict';
function run() {
const CM = window.ChestModels;
const { parse, poly, line, rect, ell, shift, rot, spark4, star5, lg, rg, cg, sh, st, tx, P3, mapD, mp, mlg, onP, FR, mixC, Box, cvx, boxFill, boxShade, corner3, plankS, surf, Barrel, RB } = CM.H;
const PI = Math.PI, TAU = PI * 2;
const R2 = (cx, cy, s, a) => { const c = Math.cos(a || 0), n = Math.sin(a || 0); return (x, y) => [cx + (x * c - y * n) * s, cy + (x * n + y * c) * s]; };
const U = (d, f) => mapD(parse(d), f);
const lp = (a, b, t) => [a[0] + (b[0] - a[0]) * t, a[1] + (b[1] - a[1]) * t];
const mixH = (a, b, k) => { const A = parseInt(a.slice(1), 16), B = parseInt(b.slice(1), 16), c = s => Math.round(((A >> s) & 255) * (1 - k) + ((B >> s) & 255) * k); return '#' + ((1 << 24) | (c(16) << 16) | (c(8) << 8) | c(0)).toString(16).slice(1); };
const gemS = (x, y, r, c, ink) => [sh(ell(x, y, r), rg(x - r * 0.35, y - r * 0.4, r * 1.4, '#ffffff', c, mixH(c, '#20002a', 0.45)), { s: ink || '#5a3a00', w: 1 }), sh(ell(x - r * 0.35, y - r * 0.4, r * 0.3, r * 0.2), 'rgba(255,255,255,0.9)')];
const GOLD = ['#fff6c0', '#ffd23a', '#c88a00', '#7a4800'];
const gl = (x0, y0, x1, y1) => lg(x0, y0, x1, y1, '#fff6c0', '#ffd23a', '#e8a400', '#a86e00');
const clipAll = (shapes, c) => shapes.map(s => Object.assign({}, s, { clip: c }));

/* ---------- fruit art (local 2D coords, map onto faces with onP) ---------- */
const SEEDS = [[-0.3, -0.2], [0, -0.24], [0.3, -0.2], [-0.42, 0.04], [-0.14, 0], [0.14, 0.02], [0.42, 0.04], [-0.26, 0.24], [0.04, 0.27], [0.3, 0.24], [-0.1, 0.45], [0.12, 0.45]];
function berry(cx, cy, s, a, o) {
  o = o || {}; const f = R2(cx, cy, s, a), p = f(-0.22, -0.2), C = o.c || ['#ff9a9a', '#ea2a3e', '#a8122c', '#78101e'], out = [];
  out.push(sh(U('M0 -0.42 C0.62 -0.7 0.8 0.05 0 0.62 C-0.8 0.05 -0.62 -0.7 0 -0.42 Z', f), rg(p[0], p[1], s * 0.95, C[0], C[1], C[2]), { s: C[3], w: Math.max(0.9, s * 0.06) }));
  SEEDS.forEach(([x, y]) => { const q = f(x, y); out.push(sh(ell(q[0], q[1], s * 0.035, s * 0.06), o.seed || '#ffe58a')); });
  out.push(sh(poly(Array.from({ length: 10 }, (_, i) => { const an = -PI / 2 + i * PI / 5, r = i % 2 ? 0.1 : 0.34; return f(Math.cos(an) * r * 1.35, -0.46 + Math.sin(an) * r * 0.62); })), o.cal || '#44b04a', { s: o.calI || '#1e6a26', w: Math.max(0.8, s * 0.05) }));
  const h = f(-0.28, -0.12); out.push(sh(ell(h[0], h[1], s * 0.08, s * 0.14), 'rgba(255,255,255,0.55)'));
  return out;
}
const APC = { r: ['#ff9a8a', '#e8323a', '#9a1420', '#6a0c16'], g: ['#e4ff9a', '#8fd64a', '#4c9a22', '#2e6414'], y: ['#fff6b0', '#ffd84a', '#d99a10', '#8a5a00'], gold: GOLD };
function apple(cx, cy, s, k, a, o) {
  o = o || {}; const f = R2(cx, cy, s, a), C = Array.isArray(k) ? k : APC[k || 'r'], p = f(-0.28, -0.25), h = f(-0.34, -0.12);
  return [sh(U('M0 -0.32 C0.25 -0.55 0.72 -0.45 0.72 0 C0.72 0.45 0.35 0.7 0 0.58 C-0.35 0.7 -0.72 0.45 -0.72 0 C-0.72 -0.45 -0.25 -0.55 0 -0.32 Z', f), rg(p[0], p[1], s * 1.1, C[0], C[1], C[2]), { s: C[3], w: Math.max(0.9, s * 0.07) }),
    sh(ell(h[0], h[1], s * 0.12, s * 0.19), 'rgba(255,255,255,0.55)'),
    st(U('M0 -0.3 Q0.02 -0.5 0.1 -0.64', f), o.stem || '#6a3a14', Math.max(1.1, s * 0.09)),
    sh(U('M0.08 -0.5 Q0.32 -0.74 0.56 -0.56 Q0.3 -0.38 0.08 -0.5 Z', f), o.leaf || '#4caf3a', { s: o.leafI || '#22661a', w: Math.max(0.7, s * 0.05) })];
}
function pear(cx, cy, s, C) {
  const f = R2(cx, cy, s, 0.12), p = f(-0.2, -0.1); C = C || ['#f6ff9a', '#c8e04a', '#7a9a1a', '#4a6410'];
  return [sh(U('M0 -0.7 C0.22 -0.7 0.25 -0.35 0.3 -0.15 C0.62 0.05 0.65 0.7 0 0.72 C-0.65 0.7 -0.62 0.05 -0.3 -0.15 C-0.25 -0.35 -0.22 -0.7 0 -0.7 Z', f), rg(p[0], p[1], s * 1.1, C[0], C[1], C[2]), { s: C[3], w: Math.max(0.9, s * 0.07) }),
    st(U('M0 -0.68 Q0.04 -0.86 0.14 -0.94', f), C[3], Math.max(1, s * 0.08)), sh(U('M0.06 -0.82 Q0.3 -1.0 0.5 -0.84 Q0.28 -0.7 0.06 -0.82 Z', f), C[1], { s: C[3], w: 0.8 })];
}
function cherries(cx, cy, s, o) {
  o = o || {}; const f = R2(cx, cy, s, o.a || 0), C = o.c || ['#ff8a8a', '#e01e3a', '#8a0a1e'], sw = Math.max(1.1, s * 0.12), out = [];
  out.push(st(U('M-0.75 -0.5 Q-0.5 -1.6 0.35 -2.3', f), o.stem || '#4a8a2a', sw), st(U('M0.85 -0.4 Q0.75 -1.5 0.35 -2.3', f), o.stem || '#4a8a2a', sw));
  out.push(sh(U('M0.35 -2.3 Q0.9 -2.75 1.55 -2.3 Q0.95 -1.95 0.35 -2.3 Z', f), o.leaf || '#4caf3a', { s: o.leafI || '#22661a', w: 0.9 }));
  [[-0.75, 0], [0.85, 0.1]].forEach(([x, y]) => { const q = f(x, y), h = f(x - 0.2, y - 0.22); out.push(sh(ell(q[0], q[1], 0.62 * s), rg(h[0], h[1], 0.8 * s, C[0], C[1], C[2]), { s: o.ink || '#6a0614', w: Math.max(0.9, s * 0.07) }), sh(ell(h[0], h[1], 0.15 * s, 0.1 * s), 'rgba(255,255,255,0.85)')); });
  return out;
}
function orange(cx, cy, r, o) {
  o = o || {}; const C = o.c || ['#ffe08a', '#ff9a1a'], out = [sh(ell(cx, cy, r), o.rind || '#ff9a1a', { s: o.ink || '#a85400', w: 1.3 }), sh(ell(cx, cy, r * 0.86), o.pith || '#fff3d6')];
  for (let i = 0; i < 8; i++) { const a0 = i / 8 * TAU + 0.07, a1 = (i + 1) / 8 * TAU - 0.07, R = r * 0.78, am = (a0 + a1) / 2;
    out.push(sh(poly([[cx + Math.cos(am) * r * 0.1, cy + Math.sin(am) * r * 0.1]].concat([0, 1, 2, 3, 4].map(k => { const a = a0 + (a1 - a0) * k / 4; return [cx + Math.cos(a) * R, cy + Math.sin(a) * R]; }))), rg(cx, cy, R, C[0], C[1]))); }
  out.push(sh(ell(cx, cy, r * 0.09), o.pith || '#fff3d6'), sh(ell(cx - r * 0.4, cy - r * 0.42, r * 0.2, r * 0.12), 'rgba(255,255,255,0.6)'));
  return out;
}
function grapes(cx, cy, s, C) {
  C = C || ['#d8b0ff', '#9a4ae8', '#5a1a9a', '#3a0a6a']; const out = [st(parse(`M${cx} ${cy - 1.6 * s} Q${cx + 0.3 * s} ${cy - 2.3 * s} ${cx + 0.8 * s} ${cy - 2.5 * s}`), '#6a4a1a', Math.max(1, s * 0.22)), sh(U('M0 -1.9 Q0.8 -2.7 1.7 -2.1 Q0.9 -1.5 0 -1.9 Z', R2(cx, cy, s)), '#4caf3a', { s: '#22661a', w: 0.8 })];
  [[-1.5, -1.25], [-0.5, -1.3], [0.5, -1.3], [1.5, -1.25], [-1, -0.4], [0, -0.45], [1, -0.4], [-0.5, 0.45], [0.5, 0.45], [0, 1.3]].forEach(([x, y]) => { const X = cx + x * s, Y = cy + y * s, r = 0.58 * s;
    out.push(sh(ell(X, Y, r), rg(X - r * 0.35, Y - r * 0.4, r * 1.4, C[0], C[1], C[2]), { s: C[3], w: Math.max(0.7, s * 0.08) }), sh(ell(X - r * 0.35, Y - r * 0.38, r * 0.25, r * 0.17), 'rgba(255,255,255,0.75)')); });
  return out;
}
const blueberry = (x, y, r) => [sh(ell(x, y, r), rg(x - r * 0.35, y - r * 0.4, r * 1.3, '#b8c8ff', '#4a5fd0', '#232a78'), { s: '#1a1e5a', w: 1 }), sh(star5(x, y - r * 0.5, r * 0.34, r * 0.14), '#1a1e5a'), sh(ell(x - r * 0.4, y - r * 0.15, r * 0.18, r * 0.24), 'rgba(255,255,255,0.55)')];
const leafA = (x, y, s, a, c, ci) => { const f = R2(x, y, s, a); return [sh(U('M0 0 Q0.5 -0.5 1.2 -0.1 Q0.6 0.35 0 0 Z', f), c || '#4caf3a', { s: ci || '#22661a', w: 0.9 }), st(U('M0.1 0 Q0.6 -0.1 1.05 -0.1', f), 'rgba(255,255,255,0.45)', 0.8)]; };

/* ---------- wicker / braid helpers ---------- */
function weave(Q, nu, nv, cO, cU, off) {
  const out = [];
  for (let j = 0; j < nv; j++) for (let i = 0; i < nu; i++) {
    const u0 = i / nu, u1 = (i + 1) / nu, v0 = j / nv, v1 = (j + 1) / nv, ov = (i + j + (off || 0)) % 2 === 0, a = Q(u0, v0), b = Q(u1, v0), c = Q(u1, v1), d = Q(u0, v1), col = ov ? cO : cU;
    out.push(sh(poly([a, b, c, d]), col, { s: col, w: 0.6 }));
    if (ov) out.push(st(line([lp(d, a, 0.22), lp(c, b, 0.22)]), 'rgba(255,248,225,0.6)', 1.2), st(line([lp(a, d, 0.1), lp(b, c, 0.1)]), 'rgba(80,40,10,0.35)', 1));
    else out.push(st(line([lp(a, b, 0.32), lp(d, c, 0.32)]), 'rgba(255,240,210,0.35)', 1), st(line([a, d]), 'rgba(80,40,10,0.3)', 0.9));
  }
  return out;
}
function braid(a, b, n, h, c1, c2, ink) {
  const out = [], dx = b[0] - a[0], dy = b[1] - a[1], L = Math.hypot(dx, dy) || 1, ux = dx / L, uy = dy / L, nx = -uy * h, ny = ux * h, sl = L / n * 0.45;
  for (let k = 0; k < n; k++) { const p = lp(a, b, k / n), q = lp(a, b, (k + 1) / n), g = poly([[p[0] - nx + ux * sl, p[1] - ny + uy * sl], [q[0] - nx + ux * sl, q[1] - ny + uy * sl], [q[0] + nx - ux * sl, q[1] + ny - uy * sl], [p[0] + nx - ux * sl, p[1] + ny - uy * sl]]);
    out.push(sh(g, k % 2 ? c1 : c2, { s: ink, w: 0.8 })); }
  out.push(st(line([[a[0] - nx * 0.5, a[1] - ny * 0.5], [b[0] - nx * 0.5, b[1] - ny * 0.5]]), 'rgba(255,245,215,0.5)', 1));
  return out;
}
const fq = b => (u, v) => b.pF(b.x0 + (b.x1 - b.x0) * u, b.y1 - (b.y1 - b.y0) * v);
const sq = b => (u, v) => b.pS(b.D * u, b.y1 - (b.y1 - b.y0) * v);
const tq = b => (u, v) => b.pT(b.x0 + (b.x1 - b.x0) * u, b.D * v);

/* ---------- COMMON: chip-wood berry punnet ---------- */
function fruitPunnet() {
  const ink = '#6a3c14', YT = -72, hw = k => 36 + 10 * k, dd = k => 22 + 6 * k, zf = k => 13 - dd(k) / 2, zb = k => 13 + dd(k) / 2;
  const FQ = (u, v) => P3(-hw(v) + 2 * hw(v) * u, YT * v, zf(v)), SQ = (u, v) => P3(hw(v), YT * v, zf(v) + dd(v) * u);
  const fP = [FQ(0, 0), FQ(1, 0), FQ(1, 1), FQ(0, 1)], sP = [SQ(0, 0), SQ(1, 0), SQ(1, 1), SQ(0, 1)], BL = P3(-hw(1), YT, zb(1)), BR = P3(hw(1), YT, zb(1));
  const front = poly(fP), side = poly(sP), top = poly([fP[3], fP[2], BR, BL]);
  const base = [sh(top, lg(0, BL[1], 0, fP[3][1], '#2a1404', '#5a3010')), st(line([fP[3], BL, BR]), '#d8a868', 4), st(line([fP[3], BL, BR]), ink, 1.4)];
  const HEAP = [[-28, 22, 6, 'b', 17, -0.3], [-6, 23, 13, 'b', 18, 0.1], [17, 22, 9, 'b', 17, 0.4], [36, 21, 3, 'u', 7], [-38, 13, 2, 'u', 7.5], [-19, 13, 12, 'b', 18, -0.15], [4, 13, 17, 'b', 19, 0.05], [26, 12, 8, 'b', 17, 0.42], [-30, 4, 3, 'b', 16, -0.5], [-12, 5, 7, 'u', 7.5], [36, 5, 1, 'u', 7], [-2, 6, 9, 'l', 9, -0.6]];
  const one = ([x, z, l, k, s, a]) => { const [X, Y] = P3(x, YT - l, z); return k === 'b' ? berry(X, Y, s, a) : k === 'u' ? blueberry(X, Y, s) : leafA(X, Y, s * 1.3, a); };
  const heap = []; HEAP.forEach(h => heap.push(...one(h)));
  const loose = one([13, 4, 4, 'b', 17, 0.25]);
  const fr = [...weave(FQ, 9, 6, '#ecc890', '#b9864c'), ...weave(SQ, 3, 6, '#c99a5e', '#8e5e2c', 1),
    sh(front, lg(fP[0][0], 0, fP[1][0], 0, [0, 'rgba(255,250,235,0.3)'], [0.25, 'rgba(255,250,235,0)'], [0.75, 'rgba(70,30,5,0)'], [1, 'rgba(70,30,5,0.25)'])), sh(front, lg(0, -72, 0, 0, 'rgba(70,30,5,0)', 'rgba(70,30,5,0.3)')), sh(side, 'rgba(50,20,0,0.24)'),
    sh(poly([FQ(0, 0), FQ(1, 0), FQ(1, 0.08), FQ(0, 0.08)]), 'rgba(70,30,5,0.3)')];
  const RF = (u, v) => P3(-(hw(v) + 1.5) + 2 * (hw(v) + 1.5) * u, YT * v, zf(v) - 1), RS = (u, v) => P3(hw(v) + 1.5, YT * v, zf(v) - 1 + (dd(v) + 2) * u);
  const rimF = poly([RF(0, 0.86), RF(1, 0.86), RF(1, 1.03), RF(0, 1.03)]), rimS = poly([RS(0, 0.86), RS(1, 0.86), RS(1, 1.03), RS(0, 1.03)]);
  fr.push(sh(rimS, lg(...RS(0, 1), ...RS(1, 0.86), '#b88448', '#8a5a2a')), sh(rimF, lg(0, RF(0, 1.03)[1], 0, RF(0, 0.86)[1], '#f2c890', '#d49a5a', '#a8743c')), st(line([RF(0.01, 1.0), RF(0.99, 1.0)]), 'rgba(255,245,220,0.7)', 1.3),
    st(front, ink, 2.4), st(side, ink, 2.4), st(rimF, ink, 1.8), st(rimS, ink, 1.8));
  [0.14, 0.5, 0.86].forEach(u => { const p = RF(u, 0.945); fr.push(sh(rect(p[0] - 3, p[1] - 1.4, 6, 2.8, 1), '#dde1ea', { s: '#5a5f6a', w: 0.8 })); });
  const L0 = FQ(0.5, 0.46), f = R2(L0[0], L0[1], 1, -0.05), lr = mapD(rect(-23, -13, 46, 26, 3), f);
  const label = [sh(shift(lr, 1.2, 1.6), 'rgba(70,30,5,0.25)'), sh(lr, '#fffaf0'), sh(mapD(rect(-23, -13, 46, 8), f), '#e5303a', { clip: lr }), st(lr, '#8a6a4a', 1.2),
    tx('FRESH', ...f(0, -9), '700 6.5px Fredoka, Nunito, sans-serif', '#ffffff', { rot: -0.05 }), ...berry(...f(-15, 4), 9.5, -0.2), tx('BERRIES', ...f(7, 4), '700 6.5px Fredoka, Nunito, sans-serif', '#8a1a14', { rot: -0.05 })];
  const hp = th => P3((hw(1) + 2) * Math.cos(th), YT + 4 - 60 * Math.sin(th), 13), wp = Array.from({ length: 31 }, (_, i) => hp(PI * i / 30)), gp = Array.from({ length: 9 }, (_, i) => hp(PI / 2 - 0.34 + 0.68 * i / 8));
  const handle = [st(line(wp), '#3a3f4a', 4.2), st(line(wp), '#c9d0da', 2.3), st(shift(line(wp.slice(4, 27)), -0.6, -0.9), 'rgba(255,255,255,0.8)', 0.9),
    st(line(gp), '#4a2408', 9.5), st(line(gp), '#d9a05e', 6.5), st(shift(line(gp), 0, -1.6), 'rgba(255,235,200,0.75)', 1.5),
    sh(ell(...wp[0], 3.2), '#9aa2ae', { s: '#3a3f4a', w: 1 }), sh(ell(...wp[30], 3.2), '#9aa2ae', { s: '#3a3f4a', w: 1 })];
  return { name: 'Berry Punnet', mat: 'veneer', hp: 6, W: 112, H: 137, ko: 'halves',
    hull: cvx(fP.concat(sP, [BL, BR], wp, HEAP.map(([x, z, l, k, s]) => { const p = P3(x, YT - l, z); return [p[0], p[1] - s * 0.7]; }))),
    parts: [{ id: 'base', sh: base }, { id: 'heap', sh: heap, launch: true, launchV: 420 }, { id: 'loose', sh: loose, tear: 0.5 }, { id: 'front', sh: fr },
      { id: 'label', sh: label, tear: 0.34, hang: f(-21, -11), loose: 0.08, hmax: 0.9, hdir: 1 },
      { id: 'handle', sh: handle, tear: 0.62, hang: wp[30], loose: 0.3, hmax: 0.7, hdir: 1, launch: true }],
    loot: ['berry', 'coin', 'apple', 'cherry'] };
}

/* ---------- RARE: slatted orchard crate ---------- */
function fruitCrate() {
  const ink = '#5a3210', b = Box(-66, -84, 48, 0, 36), { x0, y0, x1, D } = b, S = (d, o) => b.side(d, o), Tp = d => b.top(d);
  const WF = ['#f8dca6', '#e6b878', '#c89452'], WS = ['#dcae70', '#b8844a', '#946232'], WT = ['#fbe6bc', '#d4aa6c'];
  const base = [sh(b.T, mlg(Tp, 0, 0, 0, D, '#4a2810', '#1e0c02')), sh(Tp(rect(x0, D - 3.5, x1 - x0, 3.5)), WT[0], { s: ink, w: 1.2 }), sh(Tp(rect(x0, 0, 3.5, D)), WT[1], { s: ink, w: 1.2 })];
  [[-84, 28], [-56, 28], [-28, 28]].forEach(([v, h], i) => base.push(...plankS(0, v, D, h, S, WS, i === 2 ? [24, -14] : null, i * 3 + 5)));
  base.push(sh(S(rect(10, -80, 16, 6, 3)), '#2a1404'), sh(S(rect(10, -80, 16, 2.4, 1.2)), 'rgba(0,0,0,0.4)'));
  [0, D - 6].forEach(w => { const r = S(rect(w, y0, 6, 84)); base.push(sh(r, mlg(S, w, 0, w + 6, 0, '#dca464', '#a86e36')), st(r, ink, 1.4)); [-78, -42, -6].forEach(v => base.push(CM.H.nail(...mp(S, w + 3, v), 1.7))); });
  base.push(...boxShade(b, ink, { only: 'S' }), sh(b.F, '#1e0c02'));
  [[-62, 9], [-31, 9]].forEach(([y, h]) => { const cr = rect(x0, y, x1 - x0, h); for (let x = x0 + 8, i = 0; x < x1; x += 21, i++) base.push(...clipAll(apple(x, y + h * 0.65, 11, i % 3 === 1 ? 'g' : 'r', i * 0.7), cr)); base.push(sh(cr, lg(0, y, 0, y + h, 'rgba(0,0,0,0.6)', 'rgba(0,0,0,0.1)'))); });
  const AP = [[-50, 28, 5, 'r', 14, 0.2], [-27, 29, 9, 'g', 14.5, -0.2], [-3, 28, 7, 'r', 15, 0.1], [21, 29, 8, 'y', 14, 0.3], [40, 28, 4, 'r', 13, -0.1],
    [-40, 18, 10, 'r', 15, -0.15], [-14, 19, 14, 'r', 16, 0.05], [12, 18, 11, 'g', 15, 0.25], [34, 18, 7, 'r', 14.5, -0.3],
    [-54, 8, 4, 'y', 13.5, 0.3], [-28, 8, 8, 'r', 15, -0.1], [-2, 9, 10, 'r', 15.5, 0.2], [24, 8, 6, 'g', 14.5, -0.25], [42, 8, 2, 'r', 13, 0.1]];
  const ap = a => { const p = P3(a[0], y0 - a[2], a[1]); return apple(p[0], p[1], a[4], a[3], a[5]); }, LOOSE = [6, 10, 12], heap = [];
  AP.forEach((a, i) => { if (!LOOSE.includes(i)) heap.push(...ap(a)); });
  const stencil = [tx('ORCHARD FRESH', -9, -41.5, '700 8.5px Fredoka, Nunito, sans-serif', '#a8321c', { a: 0.82 }), sh(star5(-46, -42, 3.6, 1.6), '#a8321c', { a: 0.78 }), sh(star5(28, -42, 3.6, 1.6), '#a8321c', { a: 0.78 })];
  const post = x => { const r = rect(x, y0, 12, 84, 2); return [sh(r, lg(x, 0, x + 12, 0, '#f6ca90', '#d49654', '#a8692f')), st(line([[x + 3, y0 + 5], [x + 3, -5]]), 'rgba(255,240,210,0.5)', 1.2), st(r, ink, 1.8), CM.H.nail(x + 6, -73), CM.H.nail(x + 6, -42), CM.H.nail(x + 6, -11)]; };
  const rims = [sh(Tp(rect(x0, 0, x1 - x0, 3.5)), WT[0], { s: ink, w: 1.2 }), sh(Tp(rect(x1 - 3.5, 0, 3.5, D)), WT[1], { s: ink, w: 1.2 }), st(b.T, ink, 2.2)];
  const lab = [sh(rect(5, -68, 26, 36, 3), '#fff8e6'), sh(rect(5, -68, 26, 9, 3), '#d8323a'), ...apple(18, -46, 9, 'r', 0.1), tx('No.1', 18, -63.5, '700 6px Fredoka, Nunito, sans-serif', '#ffffff'), st(rect(5, -68, 26, 36, 3), '#8a6a4a', 1.2)];
  const label = onP(lab, b.pS);
  const tw0 = [x1 - 6, -73], tagC = [x1 + 4, -50], tf = R2(tagC[0], tagC[1], 1, 0.18), tg = mapD(parse('M-7 -9 L7 -9 L7 9 L-7 9 Z'), tf);
  const tag = [st(line([tw0, tf(0, -6)]), '#c9a060', 1.4), sh(tg, '#f8ecc8', { s: '#8a6a4a', w: 1.1 }), sh(ell(...tf(0, -6), 1.6), '#8a6a4a'), tx('A+', ...tf(0, 2), '700 7px Fredoka, Nunito, sans-serif', '#c4321c', { rot: 0.18 })];
  return { name: 'Orchard Crate', mat: 'pine', hp: 8, W: 150, H: 132, ko: 'planks', rows: [[-200, -62], [-62, -31], [-31, 30]],
    hull: cvx(b.pts.concat(AP.map(a => { const p = P3(a[0], y0 - a[2], a[1]); return [p[0], p[1] - a[4] * 0.7]; }))),
    parts: [{ id: 'base', sh: base }, { id: 'heap', sh: heap, launch: true, launchV: 440 },
      { id: 'a0', sh: ap(AP[6]), tear: 0.4 }, { id: 'a1', sh: ap(AP[10]), tear: 0.68 }, { id: 'a2', sh: ap(AP[12]), tear: 0.82 },
      { id: 'p2', sh: plankS(x0, -53, x1 - x0, 22, null, WF, [24, -44], 2, stencil) },
      { id: 'p1', sh: plankS(x0, -84, x1 - x0, 22, null, WF, [-30, -74], 0), tear: 0.6, hang: [-58, -73], loose: 0.36, hmax: 1, hdir: 1 },
      { id: 'p3', sh: plankS(x0, -22, x1 - x0, 22, null, WF, [-10, -12], 4), tear: 0.86, hang: [38, -11], loose: 0.6, hmax: 0.5, hdir: -1 },
      { id: 'posts', sh: post(x0).concat(post(x1 - 12), boxShade(b, ink, { only: 'F', k: 0.8 })) }, { id: 'rims', sh: rims },
      { id: 'label', sh: label, tear: 0.3, hang: b.pS(7, -66), loose: 0.06, hmax: 0.9, hdir: 1 },
      { id: 'tag', sh: tag, tear: 0.5, hang: tw0, loose: 0, hmax: 0.4, hdir: 1 }],
    loot: ['apple', 'coin', 'apple', 'berry', 'coin'] };
}

/* ---------- EPIC: wicker picnic hamper ---------- */
function fruitHamper() {
  const ink = '#5a3410', B = Box(-84, -78, 54, 0, 40), L = Box(-86, -102, 56, -78, 42), WO = '#eac682', WU = '#b6864a', SO = '#c99a5c', SU = '#8e602e';
  const body = [...boxFill(B, { f: ['#d8aa66', '#c4924e', '#a87a3a'], t: ['#e8c07e', '#c99a5c'], s: ['#a87a3a', '#7a5226'] }), ...weave(fq(B), 14, 7, WO, WU), ...weave(sq(B), 4, 7, SO, SU, 1), ...boxShade(B, ink, { only: 'FS', k: 0.85 })];
  body.push(...braid(B.pF(B.x0, -2), B.pF(B.x1, -2), 22, 3, '#c4924e', '#a87a3a', ink), ...braid(B.pS(0, -2), B.pS(B.D, -2), 7, 3, '#9a6a34', '#7a5226', ink));
  const C1 = corner3(B, -1, 1, 18, 6, 1.5, { f: (a, c, e, g) => lg(a, c, e, g, '#b8743a', '#7a4018', '#4a2408'), t: '#9a5a28', s: '#5a2e10' }, '#3a1a06'), C2 = corner3(B, 1, 1, 18, 6, 1.5, { f: (a, c, e, g) => lg(a, c, e, g, '#b8743a', '#7a4018', '#4a2408'), t: '#9a5a28', s: '#5a2e10' }, '#3a1a06');
  const clothP = (pts, ox) => { const r = poly(pts), o = [sh(shift(r, 1.5, 2.2), 'rgba(60,20,0,0.3)'), sh(r, '#fff6f0')]; let x0 = 1e9, y0 = 1e9, x1 = -1e9, y1 = -1e9; pts.forEach(([x, y]) => { x0 = Math.min(x0, x); x1 = Math.max(x1, x); y0 = Math.min(y0, y); y1 = Math.max(y1, y); });
    for (let y = y0, r2 = 0; y < y1; y += 5, r2++) for (let x = x0 + (ox || 0), c = 0; x < x1; x += 5, c++) { if ((r2 + c) % 2 === 0) o.push(sh(rect(x, y, 5, 5), '#e5404a', { clip: r, a: 0.9 })); else if (r2 % 2) o.push(sh(rect(x, y, 5, 5), 'rgba(229,64,74,0.45)', { clip: r })); }
    o.push(sh(r, lg(x0, y0, x0, y1, 'rgba(255,255,255,0.25)', 'rgba(90,10,10,0.25)')), st(r, '#8a1a1a', 1.4)); return o; };
  const cloth = clothP([[-74, -79], [-32, -79], [-46, -64], [-55, -54], [-62, -62]]).concat(clothP([[8, -79], [42, -79], [33, -66], [24, -58], [16, -66]], 2));
  const lid = [...boxFill(L, { f: ['#e0b470', '#c4924e', '#a87a3a'], t: ['#f2d496', '#d4a868'], s: ['#a87a3a', '#7a5226'] }), ...weave(fq(L), 14, 2, WO, WU), ...weave(sq(L), 4, 2, SO, SU, 1), ...weave(tq(L), 14, 4, '#f2d496', '#c49458'), ...boxShade(L, ink, { k: 0.8 })];
  lid.push(...braid(L.pF(L.x0, -79), L.pF(L.x1, -79), 22, 3.2, '#c4924e', '#a87a3a', ink), ...braid(L.pS(0, -79), L.pS(L.D, -79), 7, 3.2, '#9a6a34', '#7a5226', ink),
    ...braid(L.pF(L.x0, -101), L.pF(L.x1, -101), 22, 2.6, '#e0b470', '#c4924e', ink), ...braid(L.pS(0, -101), L.pS(L.D, -101), 7, 2.6, '#b8844a', '#9a6a34', ink));
  const LTH = (x0, y0, x1, y1) => lg(x0, y0, x1, y1, '#b8642e', '#8a4220', '#5a2a10');
  [-62, 22].forEach(sx => { const t = L.top(rect(sx, 0, 12, L.D)), f2 = rect(sx, -102, 12, 24); lid.push(sh(t, mlg(L.top, sx, 0, sx + 12, 0, '#c8743a', '#8a4220')), st(t, '#3a1606', 1.3), sh(f2, LTH(sx, 0, sx + 12, 0)), st(line([[sx + 2.2, -100], [sx + 2.2, -79]]), 'rgba(255,220,180,0.6)', 0.8), st(line([[sx + 9.8, -100], [sx + 9.8, -79]]), 'rgba(255,220,180,0.6)', 0.8), st(f2, '#3a1606', 1.4)); });
  const strap = sx => [sh(parse(`M${sx} -79 L${sx + 12} -79 L${sx + 12} -44 L${sx + 6} -38 L${sx} -44 Z`), LTH(sx, 0, sx + 12, 0), { s: '#3a1606', w: 1.4 }), st(line([[sx + 2.2, -77], [sx + 2.2, -46]]), 'rgba(255,220,180,0.6)', 0.8), st(line([[sx + 9.8, -77], [sx + 9.8, -46]]), 'rgba(255,220,180,0.6)', 0.8),
    sh(ell(sx + 6, -46, 1.3), '#2a0e02'), sh(rect(sx - 2.5, -64, 17, 13, 2.5), 'rgba(0,0,0,0)', { s: '#6a4200', w: 4.2 }), st(rect(sx - 2.5, -64, 17, 13, 2.5), gl(sx, -64, sx + 14, -51), 2.6), st(line([[sx + 6, -64], [sx + 6, -54]]), '#e8c050', 1.6)];
  const hp = th => P3(-15 + 45 * Math.cos(th), -102 - 26 * Math.sin(th), 21), hw = Array.from({ length: 25 }, (_, i) => hp(PI * i / 24));
  const handle = [sh(ell(...hp(0), 5, 3), gl(...hp(0), hp(0)[0] + 4, hp(0)[1] + 3), { s: '#6a4200', w: 1 }), sh(ell(...hp(PI), 5, 3), '#e8b030', { s: '#6a4200', w: 1 }),
    st(line(hw), '#3a1a06', 8.5), st(line(hw), lg(0, -150, 0, -100, '#d9945a', '#a8642e'), 5.5), st(shift(line(hw.slice(3, 22)), -0.6, -1.4), 'rgba(255,225,190,0.7)', 1.4)];
  const badge = [sh(ell(-15, -90, 14, 8.5), gl(-29, -98, -1, -82), { s: '#6a4200', w: 1.4 }), sh(ell(-15, -90, 11, 6.5), 'rgba(120,70,0,0.18)'), ...berry(-15, -89.5, 10, 0)];
  const tg = [st(line([[20, -70], [20, -63]]), '#c9a060', 1.4), sh(rect(8, -63, 24, 17, 4), LTH(8, -63, 32, -46), { s: '#3a1606', w: 1.2 }), ...cherries(19, -50, 3.3)];
  return { name: 'Picnic Hamper', mat: 'wicker', hp: 10, W: 180, H: 150, ko: 'pie', pieN: 6,
    hull: cvx(B.pts.concat(L.pts, hw)),
    parts: [{ id: 'body', sh: body }, { id: 'c0', sh: C1.sh, tear: 0.46 }, { id: 'c1', sh: C2.sh, tear: 0.68 },
      { id: 'tag', sh: onP(tg, B.pS), tear: 0.28, hang: B.pS(20, -70), loose: 0.05, hmax: 0.8, hdir: 1 },
      { id: 'cloth', sh: cloth, tear: 0.38, hang: [-52, -79], loose: 0.12, hmax: 0.5, hdir: 1 },
      { id: 'sL', sh: strap(-62), tear: 0.52, hang: [-56, -79], loose: 0.3, hmax: 0.5, hdir: -1 }, { id: 'sR', sh: strap(22), tear: 0.74, hang: [28, -79], loose: 0.48, hmax: 0.5, hdir: 1 },
      { id: 'lid', sh: lid, launch: true }, { id: 'badge', sh: badge, tear: 0.84 },
      { id: 'handle', sh: handle, tear: 0.62, hang: hp(PI), loose: 0.32, hmax: 0.7, hdir: 1, launch: true }],
    loot: ['berry', 'coin', 'cherry', 'apple', 'coin', 'star'] };
}

/* ---------- LEGENDARY: green lacquer harvest chest with gold vines ---------- */
function fruitHarvest() {
  const ink = '#0e3a1e', gi = '#6a4200', B = Box(-94, -88, 62, 0, 42), K = Barrel(-96, 64, -88, 38, 22.5, -1), cx = -16;
  const body = boxFill(B, { f: ['#5ad48a', '#2a9a58', '#146a38'], t: ['#7ae0a0', '#3ab06a'], s: ['#1e7a44', '#0e4a28'] });
  body.push(sh(ell(-74, -64, 16, 24), rg(-74, -64, 26, 'rgba(255,255,255,0.3)', 'rgba(255,255,255,0)')));
  body.push(...apple(-79, -44, 12, 'gold', 0.1), ...pear(47, -44, 12, GOLD));
  body.push(...onP(grapes(21, -46, 4.2, GOLD), B.pS), sh(B.side(rect(4, -84, 34, 80, 6)), 'rgba(0,0,0,0)', { s: '#d9a400', w: 2 }));
  [-64, 32].forEach(x => { body.push(sh(rect(x - 5, -88, 10, 88, 2), gl(x - 5, 0, x + 5, 0), { s: gi, w: 1.3 })); [-80, -58, -36, -14].forEach(y => body.push(sh(ell(x, y, 1.9), rg(x - 0.6, y - 0.6, 2.6, '#ffffff', '#e8a400', '#7a4800')))); });
  body.push(sh(rect(-96, -9, 160, 9, 2), gl(0, -9, 0, 0), { s: gi, w: 1.3 }), sh(B.side(rect(0, -9, 42, 9)), mlg(B.side, 0, -9, 0, 0, '#e8a400', '#8a5800'), { s: gi, w: 1.1 }), st(line([[-94, -7.6], [60, -7.6]]), 'rgba(255,255,255,0.7)', 1.1));
  body.push(...boxShade(B, ink, { only: 'FS', k: 0.85 }));
  const [fx, fy] = P3(62, 0, 42); body.unshift(sh(ell(fx, fy + 2, 9, 6), rg(fx - 3, fy, 10, '#fff6c0', '#ffd23a', '#a86e00'), { s: gi, w: 1.3 }));
  body.push(...[[-92, 2], [60, 2]].map(([x, y]) => sh(ell(x, y, 10, 6.5), rg(x - 3, y - 2, 11, '#fff6c0', '#ffd23a', '#a86e00'), { s: gi, w: 1.3 })));
  const GC = { f: (a, c, e, g) => gl(a, c, e, g), t: '#ffe066', s: '#c88a00' }, c0 = corner3(B, -1, 1, 20, 7, 2, GC, gi), c1 = corner3(B, 1, 1, 20, 7, 2, GC, gi);
  [c0, c1].forEach(c => c.sh.push(sh(ell(c.c[0], c.c[1], 2.2), '#e5304a', { s: gi, w: 0.8 })));
  const studB = []; [[-64, -69], [-64, -25], [32, -69], [32, -25]].forEach(([x, y]) => studB.push(...gemS(x, y, 3.6, '#3ae08a', gi)));
  const lid = surf(K.f3, 20, 12, () => '#2a9a58', { c: K.c, dk: '#04200c' }), L = lid.sh;
  L.push(st(line([K.dp(K.xa, K.TC), K.dp(K.xb, K.TC)]), ink, 2.4));
  const [gx, gy] = K.dp(-58, 0.85); L.push(sh(ell(gx, gy, 30, 6), rg(gx, gy, 30, 'rgba(255,255,255,0.55)', 'rgba(255,255,255,0)')));
  const vine = []; for (let x = -90; x <= 58; x += 3) vine.push(K.dp(x, 0.62 + 0.18 * Math.sin(x * 0.075)));
  L.push(st(line(vine), gi, 3.6), st(line(vine), '#ffd23a', 2.1));
  vine.forEach((p, i) => { if (i % 6 === 3) L.push(...leafA(p[0], p[1], 8, i % 12 === 3 ? -1.9 : 1.1, '#ffd23a', gi)); });
  [-64, cx, 32].forEach(x => { const pr = line(K.prof(x)); L.push(st(pr, ink, 9.5), st(pr, gl(x, -150, x + 30, -88), 6.5), st(shift(pr, -0.8, -0.8), 'rgba(255,255,255,0.6)', 1.3)); [0.35, 0.95, 1.5].forEach(t => { const p = K.dp(x, t); L.push(sh(ell(p[0], p[1], 1.9), rg(p[0] - 0.6, p[1] - 0.6, 2.6, '#ffffff', '#e8a400', '#7a4800'))); }); });
  const fe = line([K.dp(K.xa, 0), K.dp(K.xb, 0)]), la = line(K.prof(K.xa)), lb = line(K.prof(K.xb, PI));
  L.push(st(fe, ink, 8.5), st(fe, gl(0, -92, 0, -84), 5.8), st(la, ink, 9), st(la, gl(K.xa, -150, K.xa + 30, -88), 6), st(shift(la, -1, -1), 'rgba(255,255,255,0.7)', 1.4));
  const [ccx, ccy] = P3(K.xb, -88 - 17, 21.5);
  L.push(sh(K.cap, lg(ccx - 10, ccy - 20, ccx + 16, ccy + 18, '#3ab06a', '#146a38', '#0a3a1c')), ...pear(ccx, ccy + 2, 9, GOLD), st(lb, ink, 9), st(lb, gl(K.xb, -150, K.xb + 30, -88), 6));
  const studA = []; [-86, -40, 8, 52].forEach(x => { const p = K.dp(x, 0.02); studA.push(...gemS(p[0], p[1], 3.8, '#e5304a', gi)); });
  const top = K.dp(cx, K.TC * 0.9), crest = [sh(ell(top[0], top[1] + 1, 14, 4.5), gl(top[0] - 14, top[1] - 4, top[0] + 14, top[1] + 5), { s: gi, w: 1.3 }), ...apple(top[0], top[1] - 13, 21, 'gold', -0.05, { stem: '#7a4800', leaf: '#ffd23a', leafI: gi }), ...gemS(top[0] - 4, top[1] - 13, 3.6, '#e5304a', gi)];
  const lock = [sh(rect(cx - 6, -96, 12, 16, 3), gl(cx - 6, -96, cx + 6, -80), { s: gi, w: 1.3 }), sh(rect(cx - 15, -82, 34, 38, 8), '#a86e00', { s: gi, w: 1.4 }), sh(rect(cx - 18, -84, 36, 38, 8), gl(cx - 18, -84, cx + 18, -46), { s: gi, w: 1.8 }),
    ...cherries(cx - 1, -62, 5.4, { c: ['#ffb0b8', '#e5203a', '#7a0614'], stem: '#a86e00', leaf: '#ffe066', leafI: gi, ink: '#5a0410' }),
    sh(ell(cx, -52, 2.2), '#4a2a00'), sh(poly([[cx - 1.4, -52], [cx + 1.4, -52], [cx + 2, -47.5], [cx - 2, -47.5]]), '#4a2a00'), sh(ell(cx - 11, -78, 2.6, 1.6), 'rgba(255,255,255,0.8)')];
  const ring = onP([sh(rect(15, -66, 12, 8, 3), gl(15, -66, 27, -58), { s: gi, w: 1.1 }), st(ell(21, -50, 9), gi, 4.2), st(ell(21, -50, 9), gl(12, -59, 30, -41), 2.6)], B.pS);
  return { name: 'Golden Harvest Chest', mat: 'lacquer', hp: 12, W: 200, H: 168, ko: 'pie', pieN: 5,
    hull: cvx(B.pts.concat(K.pts, [[top[0] - 16, top[1] - 32], [top[0] + 16, top[1] - 32], [-104, 8], [fx + 10, fy + 8]])),
    parts: [{ id: 'body', sh: body }, { id: 'studB', sh: studB, tear: 0.52 }, { id: 'c0', sh: c0.sh, tear: 0.46, scar: [sh(ell(c0.c[0], c0.c[1], 4), '#0a2a14')] }, { id: 'c1', sh: c1.sh, tear: 0.7, scar: [sh(ell(c1.c[0], c1.c[1], 4), '#0a2a14')] },
      { id: 'ring', sh: ring, tear: 0.62, hang: B.pS(21, -62), loose: 0.35, hmax: 0.6, hdir: 1 },
      { id: 'lid', sh: L, launch: true }, { id: 'studA', sh: studA, tear: 0.3 }, { id: 'crest', sh: crest, tear: 0.78, launch: true },
      { id: 'lock', sh: lock, tear: 0.92, hang: [cx, -94], loose: 0.6, hmax: 0.6, hdir: 1 }],
    loot: ['apple', 'coin', 'cherry', 'gem', 'berry', 'star'] };
}

/* ---------- RAINBOW: crystal fruit jewel box with citrus dome ---------- */
function fruitJewel() {
  const ink = '#6a3c00', B = Box(-100, -92, 72, 0, 46), SB = Box(-103, -104, 75, -92, 49, -1.5), S = d => B.side(d);
  const PAST = ['#ffd6ec', '#fff2c2', '#d6ffe8', '#d6eeff', '#ecdcff', '#ffd6ec'];
  const panel = (x, y, w, h, fruit) => { const r = rect(x, y, w, h, 8), c = [x + w / 2, y + h / 2];
    return [sh(r, cg(c[0], c[1], 0, 0.6, ...PAST)), sh(r, 'rgba(255,255,255,0.3)'), ...clipAll(fruit, r), sh(spark4(x + w * 0.78, y + h * 0.2, 5), '#ffffff', { clip: r }),
      sh(r, lg(x, y, x + w * 0.7, y + h, [0, 'rgba(255,255,255,0.65)'], [0.3, 'rgba(255,255,255,0.12)'], [0.31, 'rgba(255,255,255,0)'], [1, 'rgba(80,0,120,0.22)'])),
      st(line([[x + 6, y + h * 0.55], [x + w * 0.55, y + 6]]), 'rgba(255,255,255,0.7)', 3, { clip: r }),
      st(shift(r, 2.4, 2.4), 'rgba(110,50,0,0.5)', 4, { clip: r }), st(shift(r, -1.8, -1.8), 'rgba(255,255,255,0.75)', 2.4, { clip: r }), st(r, '#8a5200', 2)]; };
  const JB = { c: ['#ffd0e0', '#ff3a7a', '#b0104a', '#7a0a34'], seed: '#ffffff', cal: '#3ae08a', calI: '#0a6a3a' };
  const pillar = (x, yT, yB) => { const r = rect(x - 7, yT, 14, yB - yT), o = [sh(r, lg(x - 7, 0, x + 7, 0, '#fff6c0', '#ffd23a', '#d89a10', '#8a5800'), { s: ink, w: 1.4 })];
    for (let y = yT + 4; y < yB - 6; y += 9) o.push(st(line([[x - 7, y + 5], [x + 7, y]]), 'rgba(122,72,0,0.45)', 1.6, { clip: r }), st(line([[x - 7, y + 3.5], [x + 7, y - 1.5]]), 'rgba(255,255,255,0.55)', 1, { clip: r }));
    o.push(sh(rect(x - 9.5, yT - 2, 19, 7, 3), gl(x - 9.5, yT - 2, x + 9.5, yT + 5), { s: ink, w: 1.3 }), sh(rect(x - 9.5, yB - 8, 19, 7, 3), gl(x - 9.5, yB - 8, x + 9.5, yB - 1), { s: ink, w: 1.3 }), ...leafA(x - 1, yT + 10, 7, -2.4, '#ffd23a', ink)); return o; };
  const [bpx, bpy] = P3(72, 0, 46), plS = S(rect(0, -10, 46, 10));
  const body = [...apple(bpx, bpy - 1, 10, 'gold', 0, { stem: '#7a4800', leaf: '#ffd23a', leafI: ink }), ...boxFill(B, { f: ['#fff2a8', '#ffcf30', '#d99a10'], t: ['#fff6c0', '#ffd84a'], s: ['#e0a414', '#8a5800'] }),
    ...onP(panel(9, -86, 28, 70, cherries(23, -42, 6.5, { c: ['#ffd0e0', '#ff2a6a', '#9a0a3a'], stem: '#3ae08a', leaf: '#3ae08a' })), B.pS),
    sh(plS, mlg(S, 0, -10, 0, 0, '#e8a400', '#8a5800')), st(plS, ink, 1.2),
    ...panel(-92, -88, 46, 74, berry(-69, -50, 34, -0.12, JB)), ...panel(-38, -88, 50, 74, orange(-13, -54, 19, { c: ['#fff0a0', '#ffa02a'], rind: '#ffb020' })), ...panel(20, -88, 44, 74, grapes(42, -46, 6.4, ['#f0d8ff', '#b050ff', '#5a10b0', '#3a0a7a'])),
    sh(rect(-46, -92, 8, 80, 3), gl(-46, 0, -38, 0), { s: ink, w: 1.4 }), sh(rect(12, -92, 8, 80, 3), gl(12, 0, 20, 0), { s: ink, w: 1.4 }),
    sh(rect(-100, -11, 172, 11), gl(0, -11, 0, 0), { s: ink, w: 1.4 }), st(line([[-98, -9], [70, -9]]), 'rgba(255,255,255,0.7)', 1.2),
    ...boxShade(B, ink, { k: 0.7 }), ...pillar(bpx, bpy - 96, bpy), ...apple(-100, 1, 10, 'gold', 0, { stem: '#7a4800', leaf: '#ffd23a', leafI: ink }), ...apple(72, 1, 10, 'gold', 0, { stem: '#7a4800', leaf: '#ffd23a', leafI: ink }), ...pillar(-100, -96, 0), ...pillar(72, -96, 0)];
  const seam = [...boxFill(SB, { f: ['#fff6c0', '#ffcf30', '#c88a00'], t: ['#fff6c0', '#ffe066'], s: ['#d89a10', '#8a5800'] }), ...boxShade(SB, ink, { k: 0.6 })];
  [10, 24, 38].forEach((w, i) => { const [x, y] = SB.Q(75.6, -98, w); seam.push(...gemS(x, y, 3.8, RB[(i + 1) % 5], ink)); });
  const studs = k => { const o = []; let i = 0; for (let x = -92; x <= 66; x += 17.5, i++) if (i % 2 === k) { const [X, Y] = SB.Q(x, -98, 0); o.push(...gemS(X, Y, 4.3, ['#ff5c9a', '#ffb020', '#3ad08a', '#3aa8ff', '#a05cff'][i % 5], ink)); } return o; };
  const SEG = ['#ff6fae', '#ff9a3a', '#ffd23a', '#7ee05a', '#3ac8e8', '#6a8cff', '#b86cff', '#ff6fd8'], dcx = -14, dcz = 23, rx = 86, rz = 23, dh = 64, yb = -104;
  const df = (u, v) => { const ph = TAU * u, ps = v * PI / 2; return [dcx + rx * Math.cos(ph) * Math.cos(ps), yb - dh * Math.sin(ps), dcz + rz * Math.sin(ph) * Math.cos(ps)]; };
  const dome = surf(df, 32, 9, (u, v) => { const q = u * 8, s = Math.floor(q) % 8, w = q - Math.floor(q); return mixH(SEG[s], '#ffffff', 0.34 * (1 - Math.abs(w - 0.5) * 2) + 0.12 * v); }, { c: [dcx, yb + 10, dcz], dk: '#3a0a50' });
  const lid = dome.sh;
  for (let k = 0; k < 8; k++) dome.lineOn(Array.from({ length: 17 }, (_, i) => [k / 8, i / 16 * 0.97]), 0.02).forEach(p => lid.push(st(p, ink, 4.6), st(p, gl(0, -170, 0, -104), 2.6)));
  [0.38, 0.7].forEach(v => dome.lineOn(Array.from({ length: 65 }, (_, i) => [i / 64, v]), 0.05).forEach(p => lid.push(st(p, 'rgba(255,255,255,0.45)', 1.4))));
  const hp = dome.P(0.62, 0.55); lid.push(sh(ell(hp[0], hp[1], 26, 9), rg(hp[0], hp[1], 26, 'rgba(255,255,255,0.75)', 'rgba(255,255,255,0)')));
  dome.lineOn(Array.from({ length: 65 }, (_, i) => [i / 64, 0]), -0.3).forEach(p => lid.push(st(p, ink, 8.5), st(p, gl(0, -112, 0, -98), 5.5), st(shift(p, 0, -1.4), 'rgba(255,255,255,0.6)', 1.2)));
  const T = dome.P(0, 1), crest = [st(parse(`M${T[0]} ${T[1] + 2} Q${T[0] + 1} ${T[1] - 10} ${T[0] + 5} ${T[1] - 16}`), ink, 6), st(parse(`M${T[0]} ${T[1] + 2} Q${T[0] + 1} ${T[1] - 10} ${T[0] + 5} ${T[1] - 16}`), '#ffd23a', 3.6),
    ...leafA(T[0] + 2, T[1] - 6, 16, -2.6, '#ffd23a', ink), ...leafA(T[0] + 3, T[1] - 7, 15, -0.5, '#ffd23a', ink),
    sh(ell(T[0] + 5, T[1] - 26, 11), cg(T[0] + 5, T[1] - 26, 0, 1.4, '#ff8fd8', '#ffe38a', '#9ff7c8', '#9fd8ff', '#d6b3ff', '#ff8fd8'), { s: ink, w: 1.6 }), sh(ell(T[0] + 1.5, T[1] - 30, 3.6, 2.4), 'rgba(255,255,255,0.9)'), sh(spark4(T[0] + 12, T[1] - 34, 4), '#ffffff')];
  const lk = berry(-13, -58, 34, 0, { c: ['#fff6c0', '#ffd23a', '#c88a00', '#7a4800'], seed: '#fff6c0', cal: '#ffe066', calI: '#7a4800' });
  const lock = [sh(rect(-18, -101, 10, 28, 4), gl(-18, 0, -8, 0), { s: ink, w: 1.4 }), ...lk, sh(ell(-13, -56, 6.5, 7.5), cg(-13, -56, 0, 1.4, '#ff8fd8', '#ffe38a', '#9ff7c8', '#9fd8ff', '#d6b3ff', '#ff8fd8'), { s: '#7a4800', w: 1.2 }), sh(ell(-15.2, -59, 2.2, 1.5), 'rgba(255,255,255,0.9)'),
    sh(ell(-13, -44, 2), '#4a2600'), sh(poly([[-14.3, -44], [-11.7, -44], [-11.2, -39], [-14.8, -39]]), '#4a2600')];
  return { name: 'Rainbow Fruit Jewel Box', mat: 'fruitgem', hp: 14, W: 236, H: 218, ko: 'pie', pieN: 8, ring: true,
    hull: cvx(B.pts.concat(SB.pts, dome.pts, [[T[0] + 5, T[1] - 38], [-110, 8], [-110, -97], [bpx + 10, bpy - 97], [bpx + 10, bpy + 8]])),
    parts: [{ id: 'body', sh: body }, { id: 'seam', sh: seam }, { id: 'studA', sh: studs(0), tear: 0.32 }, { id: 'studB', sh: studs(1), tear: 0.54 },
      { id: 'lock', sh: lock, tear: 0.9, hang: [-13, -99], loose: 0.6, hmax: 0.6, hdir: 1 }, { id: 'lid', sh: lid, launch: true }, { id: 'crest', sh: crest, tear: 0.74, launch: true }],
    loot: ['berry', 'gem', 'apple', 'star', 'coin', 'cherry'] };
}

/* ---------- loot icons ---------- */
function icBerry(c, s) {
  c.beginPath(); c.moveTo(0, -s * 0.3); c.bezierCurveTo(s * 0.45, -s * 0.5, s * 0.55, s * 0.05, 0, s * 0.45); c.bezierCurveTo(-s * 0.55, s * 0.05, -s * 0.45, -s * 0.5, 0, -s * 0.3); c.closePath();
  const g = c.createRadialGradient(-s * 0.15, -s * 0.15, 0, 0, 0, s * 0.6); g.addColorStop(0, '#ff9a9a'); g.addColorStop(0.6, '#ea2a3e'); g.addColorStop(1, '#a8122c'); c.fillStyle = g; c.fill(); c.strokeStyle = '#78101e'; c.lineWidth = s * 0.06; c.stroke();
  c.fillStyle = '#ffe58a'; [[-0.15, -0.08], [0.15, -0.08], [0, 0.06], [-0.22, 0.1], [0.22, 0.1], [0, 0.25]].forEach(([x, y]) => { c.beginPath(); c.ellipse(x * s, y * s, s * 0.03, s * 0.05, 0, 0, TAU); c.fill(); });
  c.beginPath(); for (let i = 0; i < 10; i++) { const a = -PI / 2 + i * PI / 5, r = (i % 2 ? 0.07 : 0.24) * s, x = Math.cos(a) * r * 1.3, y = -s * 0.32 + Math.sin(a) * r * 0.6; if (i) c.lineTo(x, y); else c.moveTo(x, y); } c.closePath(); c.fillStyle = '#44b04a'; c.fill(); c.strokeStyle = '#1e6a26'; c.lineWidth = s * 0.04; c.stroke();
}
function icApple(c, s) {
  c.beginPath(); c.moveTo(0, -s * 0.22); c.bezierCurveTo(s * 0.18, -s * 0.38, s * 0.48, -s * 0.3, s * 0.48, 0); c.bezierCurveTo(s * 0.48, s * 0.3, s * 0.24, s * 0.46, 0, s * 0.38); c.bezierCurveTo(-s * 0.24, s * 0.46, -s * 0.48, s * 0.3, -s * 0.48, 0); c.bezierCurveTo(-s * 0.48, -s * 0.3, -s * 0.18, -s * 0.38, 0, -s * 0.22); c.closePath();
  const g = c.createRadialGradient(-s * 0.18, -s * 0.16, 0, 0, 0, s * 0.6); g.addColorStop(0, '#ff9a8a'); g.addColorStop(0.6, '#e8323a'); g.addColorStop(1, '#9a1420'); c.fillStyle = g; c.fill(); c.strokeStyle = '#6a0c16'; c.lineWidth = s * 0.06; c.stroke();
  c.strokeStyle = '#6a3a14'; c.lineWidth = s * 0.07; c.beginPath(); c.moveTo(0, -s * 0.2); c.quadraticCurveTo(0, -s * 0.36, s * 0.06, -s * 0.44); c.stroke();
  c.fillStyle = '#4caf3a'; c.beginPath(); c.moveTo(s * 0.05, -s * 0.36); c.quadraticCurveTo(s * 0.22, -s * 0.52, s * 0.38, -s * 0.38); c.quadraticCurveTo(s * 0.2, -s * 0.26, s * 0.05, -s * 0.36); c.fill();
  c.fillStyle = 'rgba(255,255,255,0.6)'; c.beginPath(); c.ellipse(-s * 0.22, -s * 0.06, s * 0.07, s * 0.12, 0.3, 0, TAU); c.fill();
}
function icCherry(c, s) {
  c.strokeStyle = '#4a8a2a'; c.lineWidth = s * 0.06; c.beginPath(); c.moveTo(-s * 0.2, s * 0.1); c.quadraticCurveTo(-s * 0.12, -s * 0.3, s * 0.08, -s * 0.46); c.moveTo(s * 0.22, s * 0.14); c.quadraticCurveTo(s * 0.2, -s * 0.24, s * 0.08, -s * 0.46); c.stroke();
  [[-0.2, 0.2], [0.22, 0.24]].forEach(([x, y]) => { const g = c.createRadialGradient((x - 0.06) * s, (y - 0.06) * s, 0, x * s, y * s, s * 0.2); g.addColorStop(0, '#ff9a9a'); g.addColorStop(0.6, '#e01e3a'); g.addColorStop(1, '#8a0a1e'); c.fillStyle = g; c.beginPath(); c.arc(x * s, y * s, s * 0.18, 0, TAU); c.fill(); c.strokeStyle = '#6a0614'; c.lineWidth = s * 0.04; c.stroke(); c.fillStyle = 'rgba(255,255,255,0.8)'; c.beginPath(); c.arc((x - 0.06) * s, (y - 0.07) * s, s * 0.04, 0, TAU); c.fill(); });
}

const W = CM.MAT.wood, Cd = CM.MAT.candy, Mt = CM.MAT.metal;
CM.register('fruit', [fruitPunnet, fruitCrate, fruitHamper, fruitHarvest, fruitJewel], {
  mat: {
    veneer: { soft: 1.8, lean: 8, sag: 6, dentK: 5.5, dentShade: 0.26, holeFrom: 0.18, holeP: 0.8, holeR: [15, 22], jag: 'splinter', edge: '#f6e2b8', edgeW: 5, crack: 'split', chips: ['#e8c890', '#d4a862', '#e8283c', '#f2d9a8', '#44b04a'], deb: 'splinter', deb2: 'drop', dropC: '#e8283c', dust: '#efe0c4', mass: 0.8, sfx: { m: 'wood', p: 1.15, x: ['juice'] }, rest: 0.18, flutter: 0.35, cav: ['#2a1406', '#4a2410'], glow: '#ffcf6a' },
    pine: Object.assign({}, W, { chips: ['#f2cf94', '#e2b474', '#c48a4e', '#e8323a', '#8fd64a'], deb2: 'drop', dropC: '#f0a030', dust: '#f2e2c4', sfx: { m: 'pine', p: 1, x: ['juice'] }, mass: 1.1 }),
    wicker: { soft: 0.8, lean: 5, sag: 4, dentK: 5, dentShade: 0.28, holeFrom: 0.26, holeP: 0.62, holeR: [16, 22], jag: 'ragged', edge: '#f0d49a', edgeW: 6, crack: 'crease', chips: ['#eac682', '#c4924e', '#a87a3a', '#e5404a', '#ffffff'], deb: 'splinter', dust: '#eedcb8', mass: 1.2, sfx: { m: 'wicker', p: 0.95, x: ['latch'] }, rest: 0.2, flutter: 0.2, cav: ['#241004', '#40200a'], glow: '#ffd27a' },
    lacquer: Object.assign({}, Mt, { dentK: 5, dentShade: 0.4, holeFrom: 0.46, jag: 'shard', edge: '#fff6c0', crack: 'scratch', chips: ['#2a9a58', '#ffd23a', '#e5304a', '#146a38', '#5ad48a'], deb: 'gem', deb2: 'drop', dropC: '#ff8a1a', dust: '#e6f2dc', sfx: { m: 'gold', p: 0.95, x: ['juice'] }, cav: ['#041a0a', '#0e3a1c'], glow: '#ffd84a', spark: '#fff2a8' }),
    fruitgem: Object.assign({}, Cd, { chips: RB.concat(['#ffd23a', '#ff6fae']), deb2: 'drop', dropC: '#ff6fae', sfx: { m: 'crystal', p: 1, x: ['rainbow', 'juice'] } }),
  },
  icons: { berry: icBerry, apple: icApple, cherry: icCherry },
});
}
(function go() { if (window.ChestModels && window.ChestModels.H) run(); else setTimeout(go, 30); })();
})();
