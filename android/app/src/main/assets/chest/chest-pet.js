// Pet Shop chests for ChestModels: Cardboard Pet Carrier -> Doghouse Chest -> Tufted Velvet Trunk -> Golden Pet Palace -> Rainbow Royal Cushion Chest.
(function () {
'use strict';
function run() {
const CM = window.ChestModels;
const { parse, poly, line, rect, ell, shift, spark4, star5, lg, rg, cg, sh, st, tx, P3, mapD, mp, mlg, onP, Box, cvx, boxFill, boxShade, corner3, surf, RB, nail } = CM.H;
const PI = Math.PI, TAU = PI * 2;
const R2 = (cx, cy, s, a) => { const c = Math.cos(a || 0), n = Math.sin(a || 0); return (x, y) => [cx + (x * c - y * n) * s, cy + (x * n + y * c) * s]; };
const lp = (a, b, t) => [a[0] + (b[0] - a[0]) * t, a[1] + (b[1] - a[1]) * t];
const mixH = (a, b, k) => { const A = parseInt(a.slice(1), 16), B = parseInt(b.slice(1), 16), c = s => Math.round(((A >> s) & 255) * (1 - k) + ((B >> s) & 255) * k); return '#' + ((1 << 24) | (c(16) << 16) | (c(8) << 8) | c(0)).toString(16).slice(1); };
const gemS = (x, y, r, c, ink) => [sh(ell(x, y, r), rg(x - r * 0.35, y - r * 0.4, r * 1.4, '#ffffff', c, mixH(c, '#20002a', 0.45)), { s: ink || '#5a3a00', w: 1 }), sh(ell(x - r * 0.35, y - r * 0.4, r * 0.3, r * 0.2), 'rgba(255,255,255,0.9)')];
const gl = (x0, y0, x1, y1) => lg(x0, y0, x1, y1, '#fff6c0', '#ffd23a', '#e8a400', '#a86e00');
const brass = (x0, y0, x1, y1) => lg(x0, y0, x1, y1, '#fff2c0', '#e8b84a', '#b07c1c', '#6a4608');
const clipAll = (shapes, c) => shapes.map(s => Object.assign({}, s, { clip: c }));
const GOLD = { f: (a, c, e, g) => gl(a, c, e, g), t: '#ffe066', s: '#c88a00' };

/* ---------- pet art ---------- */
function paw(cx, cy, s, fill, o) {
  o = o || {}; const parts = [ell(cx, cy + 0.22 * s, 0.52 * s, 0.42 * s), ell(cx - 0.62 * s, cy - 0.3 * s, 0.2 * s, 0.26 * s), ell(cx + 0.62 * s, cy - 0.3 * s, 0.2 * s, 0.26 * s), ell(cx - 0.23 * s, cy - 0.62 * s, 0.21 * s, 0.27 * s), ell(cx + 0.23 * s, cy - 0.62 * s, 0.21 * s, 0.27 * s)];
  const out = []; if (o.ink) parts.forEach(p => out.push(st(p, o.ink, o.w || 2)));
  parts.forEach(p => out.push(sh(p, fill, o.a != null ? { a: o.a } : {})));
  if (o.hi) parts.forEach((p, i) => { const c = i ? [[cx - 0.62 * s, cy - 0.3 * s], [cx + 0.62 * s, cy - 0.3 * s], [cx - 0.23 * s, cy - 0.62 * s], [cx + 0.23 * s, cy - 0.62 * s]][i - 1] : [cx, cy + 0.22 * s]; out.push(sh(ell(c[0] - s * 0.07, c[1] - s * 0.08, s * (i ? 0.06 : 0.14), s * (i ? 0.05 : 0.09)), 'rgba(255,255,255,0.75)')); });
  return out;
}
function bone(cx, cy, s, a, fill, ink, o) {
  o = o || {}; const f = R2(cx, cy, s, a), M = d => mapD(d, f), bits = [M(rect(-0.75, -0.17, 1.5, 0.34)), M(ell(-0.78, -0.2, 0.24)), M(ell(-0.78, 0.2, 0.24)), M(ell(0.78, -0.2, 0.24)), M(ell(0.78, 0.2, 0.24))], out = [];
  bits.forEach(b => out.push(st(b, ink, Math.max(1.2, s * 0.12))));
  bits.forEach(b => out.push(sh(b, fill)));
  out.push(st(M(line([[-0.6, -0.08], [0.6, -0.08]])), 'rgba(255,255,255,0.7)', Math.max(0.8, s * 0.06)));
  if (o.txt) out.push(tx(o.txt, ...f(0, 0.01), o.font, o.tc, { rot: a || 0 }));
  return out;
}
function tuft(x0, y0, x1, y1, dx, dy, C) {
  const out = [], B = [];
  for (let j = 0, y = y0; y <= y1 + 0.1; y += dy, j++) for (let x = x0 + (j % 2 ? dx / 2 : 0); x <= x1 + 0.1; x += dx) B.push([x, y, j]);
  B.forEach(([x, y]) => out.push(sh(ell(x + dx / 2, y + dy / 2, dx * 0.42, dy * 0.42), rg(x + dx / 2 - 2, y + dy / 2 - 2, dx * 0.5, 'rgba(255,255,255,0.22)', 'rgba(255,255,255,0)'))));
  B.forEach(([x, y]) => { [[dx / 2, dy], [-dx / 2, dy]].forEach(([ox, oy]) => { const q = [x + ox, y + oy]; if (q[0] < x0 - 0.1 || q[0] > x1 + 0.1 || q[1] > y1 + 0.1) return; out.push(st(line([[x, y], q]), C.crease, 1.6), st(line([[x + 0.8, y + 0.9], [q[0] + 0.8, q[1] + 0.9]]), 'rgba(255,255,255,0.18)', 1)); }); });
  B.forEach(([x, y]) => out.push(sh(ell(x, y, 2.6), rg(x - 0.8, y - 0.9, 3.4, C.b0, C.b1, C.b2), { s: C.crease, w: 0.8 })));
  return out;
}
const heart = (x, y, s) => parse(`M${x} ${y + s * 0.8} C${x - s * 1.4} ${y - s * 0.1} ${x - s * 0.7} ${y - s} ${x} ${y - s * 0.35} C${x + s * 0.7} ${y - s} ${x + s * 1.4} ${y - s * 0.1} ${x} ${y + s * 0.8} Z`);

/* ---------- COMMON: cardboard pet carrier ---------- */
function petCarrier() {
  const ink = '#6a3a14', BL = '#2a6ad8';
  const front = poly([[-48, 0], [48, 0], [48, -80], [-48, -80]]), side = poly([[48, 0], [60, -7], [60, -87], [48, -80]]);
  const roof = poly([[-48, -80], [48, -80], [54, -109], [-42, -109]]), gable = poly([[48, -80], [60, -87], [54, -109]]);
  const body = [sh(side, lg(48, -80, 60, 0, '#c8935a', '#93602e')), sh(gable, lg(48, -100, 60, -80, '#b8844a', '#8a5a2a')), sh(front, lg(-48, -80, 48, 0, '#f2c88c', '#ddaa68', '#bd8848')), sh(roof, lg(0, -109, 0, -80, '#fbe2b4', '#e8be82'))];
  body.push(st(line([[-45, -94], [51, -94]]), 'rgba(110,60,20,0.25)', 1.2));
  for (let x = -36; x <= 36; x += 12) body.push(sh(ell(x, -67, 3.4), '#2a1404'), st(parse(`M${x - 3} ${-65.4} Q${x} ${-62.8} ${x + 3} ${-65.4}`), 'rgba(255,240,210,0.7)', 1));
  [0.3, 0.62].forEach(t => { const p = lp(lp([48, -60], [60, -67], 0.5), lp([48, -30], [60, -37], 0.5), t); body.push(sh(ell(p[0], p[1] - 22, 2.2, 3), '#2a1404')); });
  body.push(sh(ell(-25, -36, 11), '#1a0a02', { s: 'rgba(255,240,210,0.6)', w: 1.4 }), sh(ell(-29.5, -37, 2.8, 3.2), '#ffffff'), sh(ell(-20.5, -37, 2.8, 3.2), '#ffffff'), sh(ell(-29, -36.4, 1.6, 2), '#1a1a2a'), sh(ell(-20, -36.4, 1.6, 2), '#1a1a2a'), sh(ell(-29.6, -37.6, 0.7), '#ffffff'), sh(ell(-20.6, -37.6, 0.7), '#ffffff'), sh(ell(-25, -31.6, 1.4, 1), '#ff8aa8'));
  body.push(tx('PET TAXI', 15, -44, '700 13px Fredoka, Nunito, sans-serif', BL, { a: 0.9 }), sh(heart(15, -32, 5), '#e5404a', { a: 0.9 }));
  body.push(...paw(-36, -14, 7, BL, { a: 0.75 }), ...paw(-14, -9, 6, BL, { a: 0.6 }), ...paw(-30, -97, 5, BL, { a: 0.55 }), ...paw(26, -97, 5, BL, { a: 0.55 }));
  body.push(...onP(paw(0, 0, 5, 'rgba(42,106,216,0.6)'), (x, y) => [54 + x * 0.55, -26 + y - x * 0.32]));
  body.push(sh(front, lg(-48, 0, 48, 0, [0, 'rgba(255,250,235,0.32)'], [0.22, 'rgba(255,250,235,0)'], [0.78, 'rgba(80,40,10,0)'], [1, 'rgba(80,40,10,0.22)'])), sh(front, lg(0, -30, 0, 0, 'rgba(80,40,10,0)', 'rgba(80,40,10,0.26)')),
    st(front, ink, 2.6), st(side, ink, 2.6), st(roof, ink, 2.4), st(gable, ink, 2.2), st(line([[-46, -78.5], [46, -78.5]]), 'rgba(255,250,235,0.6)', 1.3));
  const flapF = parse('M-33 -108 L39 -108 L39 -128 Q39 -136 31 -136 L-25 -136 Q-33 -136 -33 -128 Z'), hole = rect(-14, -129, 34, 9, 4.5);
  const flap = [sh(shift(flapF, 2, 2), 'rgba(70,35,10,0.25)'), sh(poly([[39, -108], [43, -110.5], [43, -129], [39, -128]]), '#a8743c', { s: ink, w: 1.4 }), sh(flapF, lg(0, -136, 0, -108, '#fbe4ba', '#e6bb84')), sh(hole, '#2a1404'), st(parse('M-12 -121 Q3 -118.5 18 -121'), 'rgba(255,240,210,0.6)', 1.2),
    st(line([[-31, -133.6], [37, -133.6]]), 'rgba(255,250,235,0.7)', 1.2), st(flapF, ink, 2.4), ...paw(-24, -114.5, 3.2, BL, { a: 0.7 }), ...paw(30, -114.5, 3.2, BL, { a: 0.7 })];
  const nm = rect(-2, -26, 40, 16, 4), name = [sh(shift(nm, 1, 1.4), 'rgba(70,35,10,0.25)'), sh(nm, '#ffffff', { s: '#e5404a', w: 2 }), tx('SQUISH', 18, -17.6, '700 8.5px Fredoka, Nunito, sans-serif', '#e5404a')];
  const tp = poly([[-8, -110], [4, -110], [4, -52], [-8, -52]]), tape = [sh(tp, 'rgba(250,232,180,0.9)'), st(line([[-6, -108], [-6, -54]]), 'rgba(255,255,255,0.7)', 1.2), st(tp, 'rgba(150,100,40,0.55)', 1), tx('FRAGILE', -2, -80, '700 5.5px Nunito, sans-serif', '#c4321c', { rot: -PI / 2 })];
  return { name: 'Cardboard Pet Carrier', mat: 'petcard', hp: 6, W: 112, H: 137, ko: 'halves',
    hull: cvx([[-48, 0], [48, 0], [60, -7], [60, -87], [54, -109], [43, -129], [39, -136], [-33, -136], [-42, -109], [-48, -80]]),
    parts: [{ id: 'body', sh: body }, { id: 'tape', sh: tape, tear: 0.6, hang: [-2, -108], loose: 0.3, hmax: 0.4, hdir: 1 }, { id: 'name', sh: name, tear: 0.34, hang: [0, -24], loose: 0.08, hmax: 0.9, hdir: 1 },
      { id: 'flap', sh: flap, launch: true, launchV: 400 }],
    loot: ['bone', 'coin', 'paw', 'heart'] };
}

/* ---------- RARE: doghouse chest ---------- */
function petHouse() {
  const ink = '#5a1a10', B = Box(-62, -70, 44, 0, 36), { x0, x1, D } = B, S = d => B.side(d);
  const base = [];
  const gab = S(poly([[0, -70], [D, -70], [D / 2, -104]])), sideR = S(rect(0, -70, D, 70));
  base.push(sh(sideR, mlg(S, 0, -70, D, 0, '#d8483a', '#9a2418')), sh(gab, mlg(S, 0, -104, D, -70, '#c8382a', '#9a2418')));
  for (let w = 9; w < D; w += 9) base.push(st(S(line([[w, -70 - (w < D / 2 ? w : D - w) * 1.88], [w, 0]])), 'rgba(70,10,5,0.4)', 1.2));
  base.push(sh(S(ell(18, -46, 8)), '#fff6ec', { s: ink, w: 1.4 }), sh(S(ell(18, -46, 6)), mlg(S, 12, -52, 24, -40, '#bfe8ff', '#4a9ae8')), st(S(line([[18, -52], [18, -40]])), '#fff6ec', 1.6), st(S(line([[12, -46], [24, -46]])), '#fff6ec', 1.6));
  base.push(sh(S(rect(D - 4, -70, 4, 70)), '#ece2d4'), ...onP(bone(18, -20, 9, 0.2, '#fff6ec', ink), B.pS), ...boxShade(B, ink, { only: 'S' }), st(gab, ink, 2));
  const boards = [];
  for (let i = 0, n = 8; i < n; i++) { const xa = x0 + i * (x1 - x0) / n, xb = xa + (x1 - x0) / n, r = rect(xa, -70, xb - xa, 70); boards.push(sh(r, lg(xa, 0, xb, 0, '#ff7a62', '#e5483a', '#c4382a')), st(line([[xa + 2, -68], [xa + 2, -2]]), 'rgba(255,220,200,0.4)', 1), st(line([[xb, -70], [xb, 0]]), 'rgba(70,10,5,0.45)', 1.2), nail(xa + (xb - xa) / 2, -64, 1.4), nail(xa + (xb - xa) / 2, -6, 1.4)); }
  const door = parse('M-40 0 L-40 -30 Q-40 -50 -22 -50 Q-4 -50 -4 -30 L-4 0 Z');
  boards.push(sh(door, rg(-22, -30, 32, '#4a2a1a', '#1a0a04')), sh(ell(-22, -3, 14, 5), lg(-36, -6, -8, 0, '#7ab0ff', '#3a6ad8'), { clip: door }), st(ell(-22, -4.5, 12, 3), 'rgba(255,255,255,0.5)', 1, { clip: door }), st(parse('M-40 -5 L-40 -30 Q-40 -50 -22 -50 Q-4 -50 -4 -30 L-4 -5'), '#3a0a04', 7), st(parse('M-40 -5 L-40 -30 Q-40 -50 -22 -50 Q-4 -50 -4 -30 L-4 -5'), '#fff6ec', 4.6));
  boards.push(sh(rect(x0, -70, 5, 70), lg(x0, 0, x0 + 5, 0, '#ffffff', '#e2d6c8'), { s: ink, w: 1.1 }), sh(rect(x1 - 5, -70, 5, 70), lg(x1 - 5, 0, x1, 0, '#ffffff', '#e2d6c8'), { s: ink, w: 1.1 }), sh(rect(x0, -5, x1 - x0, 5), '#ece2d4', { s: ink, w: 1.1 }), ...boxShade(B, ink, { only: 'F', k: 0.8 }));
  const pm = (u, v) => P3(u, -70 - 34 * v, -5 + 23 * v), M = d => mapD(d, pm), ua = -67, ub = 49;
  const roof = [sh(M(poly([[ua, 0], [ub, 0], [ub, 1], [ua, 1]])), '#24448a')];
  for (let r = 0; r < 5; r++) { const v0 = r / 5, v1 = Math.min(1, (r + 1) / 5 + 0.05), off = r % 2 ? 5.8 : 0;
    for (let u = ua - off, k = 0; u < ub; u += 11.6, k++) { const a = Math.max(ua, u), b = Math.min(ub, u + 11.6), m = (a + b) / 2;
      const d = M(parse(`M${a} ${v1} L${b} ${v1} L${b} ${v0 + 0.07} Q${b} ${v0} ${m} ${v0} Q${a} ${v0} ${a} ${v0 + 0.07} Z`)), c = (k + r) % 3 === 0 ? '#3a74d8' : (k + r) % 3 === 1 ? '#4a8ae8' : '#4280e0';
      roof.push(sh(d, mlg(M, m, v1, m, v0, mixH(c, '#ffffff', 0.18), c)), st(d, '#1a2e6a', 1)); } }
  const E0 = P3(ub, -70, -5), Rg = P3(ub, -104, 18), E1 = P3(ub, -70, 41), dn = p => [p[0], p[1] + 6], strip = poly([E0, Rg, E1, dn(E1), dn(Rg), dn(E0)]), eave = poly([pm(ua, 0), pm(ub, 0), dn(pm(ub, 0)), dn(pm(ua, 0))]);
  roof.push(sh(strip, lg(E0[0], 0, E1[0], 0, '#fff6ec', '#c8bcac'), { s: ink, w: 1.4 }), sh(eave, '#fff6ec', { s: ink, w: 1.3 }), st(M(line([[ua, 1], [ub, 1]])), '#3a0a04', 7), st(M(line([[ua, 1], [ub, 1]])), '#fff6ec', 4.6), st(M(poly([[ua, 0], [ub, 0], [ub, 1], [ua, 1]])), '#1a2e6a', 2));
  const plate = [sh(rect(-40, -64, 36, 11, 3), '#fff6ec', { s: ink, w: 1.3 }), tx('SQUISH', -22, -58.2, '700 6.6px Fredoka, Nunito, sans-serif', '#e5483a'), nail(-37, -58.5, 1.2), nail(-7, -58.5, 1.2)];
  const sign = [st(line([[22, -60], [16, -52]]), '#6a4a2a', 1.2), st(line([[22, -60], [28, -52]]), '#6a4a2a', 1.2), nail(22, -60, 1.6), ...bone(22, -46, 15, 0, '#fff6ec', ink, { txt: 'WOOF', font: '700 6.5px Fredoka, Nunito, sans-serif', tc: '#e5483a' })];
  const bowl = [sh(ell(26, -1, 16, 3.6), 'rgba(40,10,5,0.25)'), sh(parse('M12 -12 L40 -12 L36 -1 Q26 1.5 16 -1 Z'), lg(12, 0, 40, 0, '#7ab0ff', '#3a6ad8', '#1a3a98'), { s: '#0e1e5a', w: 1.4 }), sh(ell(26, -12, 14, 3.4), '#1a3a98', { s: '#0e1e5a', w: 1.2 }),
    ...[[20, -13], [24, -14], [28, -13.4], [32, -13], [23, -12], [29, -12]].map(([x, y]) => sh(ell(x, y, 2.4, 1.7), '#a8642e', { s: '#5a2e10', w: 0.6 })), ...bone(26, -6, 7, 0, '#ffffff', '#0e1e5a')];
  return { name: 'Doghouse Chest', mat: 'kennel', hp: 8, W: 150, H: 140, ko: 'planks', rows: [[-200, -70], [-70, -35], [-35, 30]],
    hull: cvx(B.pts.concat([pm(ua, 0), pm(ub, 0), Rg, pm(ua, 1), E1, dn(E1), dn(E0)])),
    parts: [{ id: 'base', sh: base }, { id: 'boards', sh: boards }, { id: 'plate', sh: plate, tear: 0.3, hang: [-37, -58.5], loose: 0.1, hmax: 0.9, hdir: 1 },
      { id: 'sign', sh: sign, tear: 0.62, hang: [22, -60], loose: 0.2, hmax: 0.6, hdir: 1 }, { id: 'roof', sh: roof, launch: true }, { id: 'bowl', sh: bowl, tear: 0.46 }],
    loot: ['bone', 'coin', 'paw', 'coin', 'heart'] };
}

/* ---------- EPIC: tufted velvet trunk ---------- */
function petTrunk() {
  const ink = '#2a0a3a', B = Box(-84, -80, 54, 0, 40), L = Box(-86, -104, 56, -80, 42), LT = ['#e8b070', '#b8743a', '#7a4418'];
  const TC = { crease: 'rgba(40,0,70,0.55)', b0: '#fff2c0', b1: '#e8b84a', b2: '#7a5410' };
  const body = [...boxFill(B, { f: ['#b874f0', '#7a2ac8', '#4a1488'], t: ['#c890f8', '#9a4ae0'], s: ['#6a22b0', '#3a0a70'] }), ...tuft(-78, -74, 48, -6, 21, 17, TC), ...onP(tuft(6, -74, 34, -6, 14, 17, TC), B.pS)];
  body.push(sh(ell(-64, -50, 18, 26), rg(-64, -50, 28, 'rgba(255,255,255,0.22)', 'rgba(255,255,255,0)')), ...boxShade(B, ink, { only: 'FS', k: 0.9 }));
  const trim = (r, m) => { const d = m ? m(r) : r; return sh(d, '#c88a4a', { s: '#4a2408', w: 1.1 }); }, studsL = [];
  const studRow = (a, b, n, m) => { for (let i = 0; i <= n; i++) { const p = lp(a, b, i / n), q = m ? mp(m, p[0], p[1]) : p; studsL.push(sh(ell(q[0], q[1], 1.5), rg(q[0] - 0.5, q[1] - 0.5, 2, '#ffffff', '#e8b84a', '#7a5410'))); } };
  body.push(trim(rect(-84, -80, 6, 80)), trim(rect(48, -80, 6, 80)), trim(rect(-84, -6, 138, 6)), trim(rect(B.D - 5, -80, 5, 80), B.side), trim(rect(0, -6, B.D, 6), B.side));
  studRow([-81, -74], [-81, -8], 11); studRow([51, -74], [51, -8], 11); studRow([-74, -3], [44, -3], 20); studRow([4, -3], [36, -3], 5, B.side);
  body.push(...studsL.splice(0));
  const lid = [...boxFill(L, { f: ['#b874f0', '#7a2ac8', '#4a1488'], t: ['#c890f8', '#9a4ae0'], s: ['#6a22b0', '#3a0a70'] }), ...tuft(-78, -92, 50, -92, 21, 17, TC), ...onP(tuft(8, -92, 34, -92, 13, 17, TC), L.pS)];
  const cu = surf((u, w) => [L.x0 + 3 + (L.x1 - L.x0 - 6) * u, -104 - 8 * Math.pow(Math.sin(PI * u), 0.5) * Math.pow(Math.sin(PI * w), 0.5), 3 + (L.D - 6) * w], 14, 6, () => '#8a3ad8', { c: [-15, -60, 21], dk: '#1a0430' });
  lid.push(...cu.sh); [[0.25, 0.35], [0.5, 0.35], [0.75, 0.35], [0.375, 0.7], [0.625, 0.7]].forEach(([u, w]) => { const p = cu.P(u, w); lid.push(sh(ell(p[0], p[1], 2.6, 2), rg(p[0] - 0.8, p[1] - 0.8, 3.4, TC.b0, TC.b1, TC.b2), { s: TC.crease, w: 0.8 })); });
  lid.push(...boxShade(L, ink, { only: 'FS', k: 0.9 }), trim(rect(-86, -104, 6, 24)), trim(rect(50, -104, 6, 24)), trim(rect(-86, -84, 142, 4)), trim(rect(-86, -104, 142, 4)), trim(rect(0, -104, L.D, 4), L.side), trim(rect(0, -84, L.D, 4), L.side), trim(rect(L.D - 5, -104, 5, 24), L.side));
  studRow([-80, -102], [50, -102], 22); studRow([-80, -82], [50, -82], 22); studRow([3, -102], [39, -102], 6, L.side); studRow([3, -82], [39, -82], 6, L.side); lid.push(...studsL.splice(0));
  const LTH = (x0, y0, x1, y1) => lg(x0, y0, x1, y1, LT[0], LT[1], LT[2]);
  [-62, 24].forEach(sx => { const t = L.top(rect(sx, 0, 12, L.D), 5), f2 = rect(sx, -109, 12, 29); lid.push(sh(t, mlg(L.top, sx, 0, sx + 12, 0, '#d89a5a', '#9a5a28')), st(t, '#4a2408', 1.2), sh(f2, LTH(sx, 0, sx + 12, 0), { s: '#4a2408', w: 1.3 })); });
  const strap = sx => [sh(parse(`M${sx} -80 L${sx + 12} -80 L${sx + 12} -34 L${sx + 6} -28 L${sx} -34 Z`), LTH(sx, 0, sx + 12, 0), { s: '#4a2408', w: 1.3 }), st(line([[sx + 2.2, -78], [sx + 2.2, -36]]), 'rgba(255,230,190,0.6)', 0.8), st(line([[sx + 9.8, -78], [sx + 9.8, -36]]), 'rgba(255,230,190,0.6)', 0.8),
    sh(rect(sx - 3, -60, 18, 15, 4), brass(sx - 3, -60, sx + 15, -45), { s: '#4a2e06', w: 1.3 }), ...paw(sx + 6, -52, 4.6, '#7a5410')];
  const BC = { f: (a, c, e, g) => brass(a, c, e, g), t: '#f0c860', s: '#9a6a1a' }, cs = [corner3(B, -1, 1, 18, 6, 1.5, BC, '#4a2e06'), corner3(B, 1, 1, 18, 6, 1.5, BC, '#4a2e06'), corner3(L, -1, -1, 16, 6, 1.5, BC, '#4a2e06'), corner3(L, 1, -1, 16, 6, 1.5, BC, '#4a2e06')];
  const cx = -15, lock = [sh(rect(cx - 10, -92, 20, 24, 5), brass(cx - 10, -92, cx + 10, -68), { s: '#4a2e06', w: 1.4 }), sh(heart(cx, -82, 4.2), '#4a2e06'), sh(rect(cx - 1, -79, 2, 5), '#4a2e06'), sh(ell(cx, -70, 3), 'rgba(0,0,0,0)', { s: '#c88a2a', w: 1.6 })];
  const tag = [st(ell(cx, -67, 3), '#7a5410', 1.6), ...bone(cx, -57, 13, 0.08, gl(cx - 12, -62, cx + 12, -52), '#7a4800'), ...paw(cx, -57, 2.4, '#a86e00')];
  const hd = parse('M10 -58 C9 -40 31 -40 30 -58'), handle = [st(B.side(hd, 2), '#4a2408', 6.5), st(B.side(hd, 2), '#c88a4a', 4), st(B.side(shift(hd, -0.6, -0.9), 2.4), 'rgba(255,230,190,0.6)', 1), sh(B.side(rect(6, -62, 8, 8, 2), 1), brass(0, -62, 0, -54), { s: '#4a2e06', w: 1 }), sh(B.side(rect(26, -62, 8, 8, 2), 1), brass(0, -62, 0, -54), { s: '#4a2e06', w: 1 })];
  return { name: 'Tufted Velvet Trunk', mat: 'velvet', hp: 10, W: 180, H: 150, ko: 'pie', pieN: 6,
    hull: cvx(B.pts.concat(L.pts, cu.pts)),
    parts: [{ id: 'body', sh: body }, { id: 'c0', sh: cs[0].sh, tear: 0.44 }, { id: 'c1', sh: cs[1].sh, tear: 0.66 }, { id: 'handle', sh: handle, tear: 0.58, hang: P3(B.x1 + 2, -58, 10), loose: 0.3, hmax: 0.6, hdir: 1 },
      { id: 'sL', sh: strap(-62), tear: 0.5, hang: [-56, -80], loose: 0.28, hmax: 0.5, hdir: -1 }, { id: 'sR', sh: strap(24), tear: 0.76, hang: [30, -80], loose: 0.5, hmax: 0.5, hdir: 1 },
      { id: 'lid', sh: lid, launch: true }, { id: 'c2', sh: cs[2].sh, tear: 0.82 }, { id: 'c3', sh: cs[3].sh, tear: 0.9 },
      { id: 'lock', sh: lock, tear: 0.92, hang: [cx, -90], loose: 0.7, hmax: 0.5, hdir: 1 }, { id: 'tag', sh: tag, tear: 0.4, hang: [cx, -67], loose: 0, hmax: 0.5, hdir: 1 }],
    loot: ['bone', 'coin', 'heart', 'paw', 'coin', 'star'] };
}

/* ---------- LEGENDARY: golden pet palace ---------- */
function petPalace() {
  const ink = '#0e1450', gi = '#6a4200', B = Box(-94, -88, 62, 0, 42), L = Box(-97, -112, 65, -88, 45), L2 = Box(-80, -122, 48, -112, 30, 7.5), cx = -16;
  const BLU = { f: ['#8aa8ff', '#3a5ae8', '#1a2a98'], t: ['#a8c0ff', '#5a78f0'], s: ['#2a3ab8', '#121a6a'] };
  const niche = (x0, w) => parse(`M${x0} -52 L${x0} -70 Q${x0} -84 ${x0 + w / 2} -84 Q${x0 + w} -84 ${x0 + w} -70 L${x0 + w} -52 Z`);
  const body = boxFill(B, BLU);
  [[-86, 34], [18, 34]].forEach(([x, w]) => { const n = niche(x, w); body.push(sh(n, lg(x, -84, x + w, -52, '#1a2a98', '#0a1260')), ...bone(x + w / 2, -66, 15, -0.5, gl(x, -76, x + w, -56), gi), st(n, gi, 4.4), st(n, gl(x, -84, x + w, -52), 2.6)); });
  body.push(...onP([sh(niche(5, 32), lg(5, -84, 37, -52, '#1a2a98', '#0a1260')), st(niche(5, 32), gl(5, -84, 37, -52), 2.6)], B.pS));
  body.push(...onP([sh(rect(-90, -46, 150, 12, 3), lg(0, -46, 0, -34, '#ff6a5a', '#d8302a', '#8a140e'), { s: '#4a0806', w: 1.3 })], B.pF), ...onP([sh(rect(0, -46, 42, 12), lg(0, -46, 0, -34, '#d8302a', '#6a0a06'), { s: '#4a0806', w: 1.1 })], B.pS));
  [-80, -60, 28, 48].forEach(x => body.push(...paw(x, -20, 4.5, gl(x - 4, -24, x + 4, -16))));
  body.push(sh(rect(-96, -9, 160, 9, 2), gl(0, -9, 0, 0), { s: gi, w: 1.3 }), sh(B.side(rect(0, -9, 42, 9)), mlg(B.side, 0, -9, 0, 0, '#e8a400', '#8a5800'), { s: gi, w: 1.1 }), sh(rect(-96, -88, 6, 88, 2), gl(-96, 0, -90, 0), { s: gi, w: 1.1 }), sh(rect(56, -88, 6, 88, 2), gl(56, 0, 62, 0), { s: gi, w: 1.1 }), sh(B.side(rect(36, -88, 6, 88)), mlg(B.side, 36, 0, 42, 0, '#e8a400', '#8a5800'), { s: gi, w: 1.1 }));
  body.push(sh(ell(-72, -60, 14, 20), rg(-72, -60, 22, 'rgba(255,255,255,0.3)', 'rgba(255,255,255,0)')), ...boxShade(B, ink, { only: 'FS', k: 0.85 }));
  const stA = [], stB = []; [-84, -66, -48, -30, 0, 18, 36, 52].forEach((x, i) => (i % 2 ? stB : stA).push(...gemS(x, -40, 3.2, i % 2 ? '#3ad08a' : '#ffd23a', gi)));
  [8, 22, 36].forEach((w, i) => { const p = B.pS(w, -40); (i % 2 ? stA : stB).push(...gemS(p[0], p[1], 3, '#ffd23a', gi)); });
  const lid = boxFill(L, BLU);
  lid.push(sh(rect(-97, -94, 162, 6, 2), gl(0, -94, 0, -88), { s: gi, w: 1.2 }), sh(rect(-97, -112, 162, 5, 2), gl(0, -112, 0, -107), { s: gi, w: 1.2 }), sh(L.side(rect(0, -94, 45, 6)), mlg(L.side, 0, -94, 0, -88, '#e8a400', '#8a5800'), { s: gi, w: 1 }));
  for (let x = -86; x <= 54; x += 14) lid.push(...gemS(x, -100.5, 2.4, x % 28 ? '#ff5c8a' : '#5cb8ff', gi));
  lid.push(...onP(paw(22, -102, 5, gl(16, -108, 28, -96)), L.pS), ...boxShade(L, ink, { k: 0.85 }), ...boxFill(L2, { f: ['#fff6c0', '#ffd23a', '#c88a00'], t: ['#fff6c0', '#ffe066'], s: ['#d89a10', '#8a5800'] }), ...boxShade(L2, gi, { k: 0.7 }));
  const dcx = -16, dcz = 22.5, rx = 23, rz = 11, dh = 24, yb = -122;
  const df = (u, v) => { const ph = TAU * u, ps = v * PI / 2; return [dcx + rx * Math.cos(ph) * Math.cos(ps), yb - dh * Math.sin(ps), dcz + rz * Math.sin(ph) * Math.cos(ps)]; };
  const dm = surf(df, 24, 7, u => Math.floor(u * 12) % 2 ? '#ffd23a' : '#3a5ae8', { c: [dcx, yb + 6, dcz], dk: '#0a0e40' });
  const T = dm.P(0, 1), cup = [...dm.sh];
  dm.lineOn(Array.from({ length: 49 }, (_, i) => [i / 48, 0]), -0.3).forEach(p => cup.push(st(p, gi, 5.5), st(p, gl(0, -126, 0, -118), 3.4)));
  const cr = [[T[0] - 10, T[1] + 1], [T[0] - 12, T[1] - 14], [T[0] - 5, T[1] - 7], [T[0], T[1] - 18], [T[0] + 5, T[1] - 7], [T[0] + 12, T[1] - 14], [T[0] + 10, T[1] + 1]];
  cup.push(sh(poly(cr), gl(T[0] - 12, T[1] - 18, T[0] + 12, T[1]), { s: gi, w: 1.5 }), ...gemS(T[0], T[1] - 20, 3.4, '#ff3a5a', gi), ...gemS(T[0] - 12, T[1] - 16, 2.4, '#5cb8ff', gi), ...gemS(T[0] + 12, T[1] - 16, 2.4, '#3ad08a', gi), sh(rect(T[0] - 11, T[1] - 3, 22, 5, 2), gl(0, T[1] - 3, 0, T[1] + 2), { s: gi, w: 1 }));
  const ball = (x, y, r) => [sh(ell(x, y, r), rg(x - 3, y - 3, r + 2.5, '#fff6c0', '#ffd23a', '#a86e00'), { s: gi, w: 1.4 }), sh(ell(x - r * 0.3, y - r * 0.35, r * 0.28, r * 0.19), '#ffffff')], sock = (x, y) => [sh(ell(x, y, 4.5), '#0a1050')];
  const med = [st(line([[cx, -40], [cx, -34]]), gi, 2.2), sh(ell(cx, -34, 3), 'rgba(0,0,0,0)', { s: '#ffd23a', w: 1.8 }), sh(ell(cx + 1.4, -18.6, 14), 'rgba(40,10,0,0.3)'), sh(ell(cx, -20, 14), gl(cx - 14, -34, cx + 14, -6), { s: gi, w: 1.8 }), st(ell(cx, -20, 11), 'rgba(122,72,0,0.55)', 1.2),
    ...paw(cx, -21, 6, lg(cx - 6, -27, cx + 6, -15, '#c88a00', '#7a4800')), ...gemS(cx, -19.5, 2.2, '#ff3a5a', gi), sh(ell(cx - 7, -27, 2.6, 1.6), 'rgba(255,255,255,0.85)')];
  return { name: 'Golden Pet Palace', mat: 'royal', hp: 12, W: 200, H: 168, ko: 'pie', pieN: 5,
    hull: cvx(B.pts.concat(L.pts, L2.pts, dm.pts, [[T[0], T[1] - 24]])),
    parts: [{ id: 'body', sh: body }, { id: 'stA', sh: stA, tear: 0.32 }, { id: 'stB', sh: stB, tear: 0.54 }, { id: 'lid', sh: lid, launch: true }, { id: 'cup', sh: cup, tear: 0.76, launch: true },
      { id: 'c0', sh: ball(-95, -4, 8.5), tear: 0.46, scar: sock(-95, -4) }, { id: 'c1', sh: ball(63, -4, 8.5), tear: 0.7, scar: sock(63, -4) }, { id: 'c2', sh: ball(-97, -112, 8.5), tear: 0.6, scar: sock(-97, -112) }, { id: 'c3', sh: ball(65, -112, 8.5), tear: 0.88, scar: sock(65, -112) },
      { id: 'med', sh: med, tear: 0.92, hang: [cx, -40], loose: 0.55, hmax: 0.6, hdir: 1 }],
    loot: ['bone', 'coin', 'gem', 'paw', 'heart', 'star'] };
}

/* ---------- RAINBOW: royal cushion chest ---------- */
function petCushion() {
  const ink = '#6a3c00', B = Box(-100, -88, 72, 0, 46), SB = Box(-103, -98, 75, -88, 49, -1.5), S = d => B.side(d), RBC = ['#ff8fd8', '#ffe38a', '#9ff7c8', '#9fd8ff', '#d6b3ff', '#ff8fd8'];
  const panel = (x, y, w, h) => { const r = rect(x, y, w, h, 8), c = [x + w / 2, y + h / 2], s = Math.min(w, h) * 0.3;
    return [sh(r, lg(x, y, x + w, y + h, '#f4ecff', '#e0f0ff')), ...clipAll(paw(c[0], c[1], s, cg(c[0], c[1] - s * 0.2, 0, 1, '#ff5ca8', '#ffb020', '#3ad08a', '#3aa8ff', '#a05cff', '#ff5ca8'), { ink: '#8a5200', w: 1.8 }), r), ...clipAll(paw(c[0], c[1], s, 'rgba(0,0,0,0)', { hi: true }), r),
      sh(r, lg(x, y, x + w * 0.7, y + h, [0, 'rgba(255,255,255,0.6)'], [0.3, 'rgba(255,255,255,0.1)'], [0.31, 'rgba(255,255,255,0)'], [1, 'rgba(80,0,120,0.2)'])), st(line([[x + 5, y + h * 0.4], [x + w * 0.4, y + 5]]), 'rgba(255,255,255,0.8)', 2.6, { clip: r }),
      st(shift(r, 2.4, 2.4), 'rgba(110,50,0,0.5)', 4, { clip: r }), st(shift(r, -1.8, -1.8), 'rgba(255,255,255,0.75)', 2.4, { clip: r }), st(r, '#8a5200', 2)]; };
  const foot = (x, y) => [sh(ell(x, y, 10, 6.5), rg(x - 3, y - 2, 11, '#fff6c0', '#ffd23a', '#a86e00'), { s: ink, w: 1.3 }), ...[-6, 0, 6].map(d => sh(ell(x + d, y - 5, 3.2, 2.6), rg(x + d - 1, y - 6, 3.6, '#fff6c0', '#ffd23a', '#a86e00'), { s: ink, w: 1 }))];
  const [bpx, bpy] = P3(72, 0, 46), plS = S(rect(0, -10, 46, 10));
  const body = [...foot(bpx, bpy + 2), ...boxFill(B, { f: ['#fff2a8', '#ffcf30', '#d99a10'], t: ['#fff6c0', '#ffd84a'], s: ['#e0a414', '#8a5800'] }), ...onP(panel(8, -80, 30, 66), B.pS), sh(plS, mlg(S, 0, -10, 0, 0, '#e8a400', '#8a5800')), st(plS, ink, 1.2),
    ...panel(-92, -82, 46, 68), ...panel(-38, -82, 50, 68), ...panel(20, -82, 44, 68),
    sh(rect(-46, -86, 8, 76, 3), gl(-46, 0, -38, 0), { s: ink, w: 1.4 }), sh(rect(12, -86, 8, 76, 3), gl(12, 0, 20, 0), { s: ink, w: 1.4 }),
    sh(rect(-100, -11, 172, 11), gl(0, -11, 0, 0), { s: ink, w: 1.4 }), st(line([[-98, -9], [70, -9]]), 'rgba(255,255,255,0.7)', 1.2), ...boxShade(B, ink, { k: 0.7 }), ...foot(-100, 2), ...foot(72, 2)];
  const seam = [...boxFill(SB, { f: ['#fff6c0', '#ffcf30', '#c88a00'], t: ['#fff6c0', '#ffe066'], s: ['#d89a10', '#8a5800'] }), ...boxShade(SB, ink, { k: 0.6 })];
  [10, 24, 38].forEach((w, i) => { const [x, y] = SB.Q(75.6, -93, w); seam.push(...gemS(x, y, 3.4, RB[(i + 2) % 5], ink)); });
  const studs = k => { const o = []; let i = 0; for (let x = -92; x <= 66; x += 17.5, i++) if (i % 2 === k && Math.abs(x + 14) > 12) { const [X, Y] = SB.Q(x, -93, 0); o.push(...gemS(X, Y, 4, ['#ff5c9a', '#ffb020', '#3ad08a', '#3aa8ff', '#a05cff'][i % 5], ink)); } return o; };
  const TU = [[0.22, 0.34], [0.5, 0.34], [0.78, 0.34], [0.36, 0.72], [0.64, 0.72]], PAL = ['#ff6fae', '#ff9a3a', '#ffd23a', '#7ee05a', '#3ac8e8', '#8a7cff', '#c86cff'];
  const pal = u => { const q = Math.max(0, Math.min(0.999, u)) * (PAL.length - 1), i = Math.floor(q); return mixH(PAL[i], PAL[i + 1], q - i); };
  const cf = (u, w) => { let h = 30 * Math.pow(Math.sin(PI * u), 0.32) * Math.pow(Math.sin(PI * w), 0.32); TU.forEach(([a, b]) => { h -= 7 * Math.exp(-((u - a) * (u - a) / 0.0035 + (w - b) * (w - b) / 0.011)); }); return [-110 + 192 * u, -98 - Math.max(0, h), -8 + 62 * w]; };
  const cu = surf(cf, 26, 11, (u, w) => mixH(pal(u), '#ffffff', 0.12 + 0.12 * w), { c: [-14, -60, 23], dk: '#3a0a50', cv: -0.1 }), Ls = cu.sh;
  TU.forEach(([a, b]) => { const p = cu.P(a, b); [[0.07, 0], [-0.07, 0], [0, 0.12], [0, -0.12]].forEach(([du, dw]) => Ls.push(st(line([p, cu.P(a + du * 0.7, b + dw * 0.7)]), 'rgba(60,0,80,0.22)', 1.1))); Ls.push(sh(ell(p[0], p[1], 3.6, 2.8), rg(p[0] - 1, p[1] - 1, 4.4, '#fff6c0', '#ffd23a', '#a86e00'), { s: ink, w: 0.9 })); });
  const hp = cu.P(0.3, 0.55); Ls.push(sh(ell(hp[0], hp[1], 30, 8), rg(hp[0], hp[1], 30, 'rgba(255,255,255,0.55)', 'rgba(255,255,255,0)')));
  [[Array.from({ length: 41 }, (_, i) => [i / 40, 0.004])], [Array.from({ length: 17 }, (_, i) => [0.996, i / 20])]].forEach(([uv]) => cu.lineOn(uv, -0.95).forEach(p => Ls.push(st(p, ink, 6.5), st(p, gl(0, -110, 0, -94), 4.2), st(shift(p, 0, -1.2), 'rgba(255,255,255,0.6)', 1))));
  const tassel = p => { const [x, y] = p, o = [st(parse(`M${x} ${y} Q${x - 3} ${y + 5} ${x} ${y + 8}`), ink, 3.4), st(parse(`M${x} ${y} Q${x - 3} ${y + 5} ${x} ${y + 8}`), '#ffd23a', 2), sh(ell(x, y + 9, 3.4, 2.6), gl(x - 3, y + 6, x + 3, y + 12), { s: ink, w: 1 })];
    const fr = parse(`M${x - 3.4} ${y + 10} L${x + 3.4} ${y + 10} L${x + 5.6} ${y + 24} Q${x} ${y + 26} ${x - 5.6} ${y + 24} Z`); o.push(sh(fr, lg(x - 5, 0, x + 5, 0, '#fff6c0', '#ffd23a', '#c88a00'), { s: ink, w: 1.1 }));
    for (let k = -2; k <= 2; k++) o.push(st(line([[x + k * 1.3, y + 12], [x + k * 2.2, y + 24.5]]), 'rgba(122,72,0,0.55)', 0.8)); return o; };
  const tA = cu.P(0, 0), tB = cu.P(1, 0), C = cu.P(0.5, 0.55), crown = [sh(ell(C[0], C[1] - 1, 18, 4), 'rgba(60,0,80,0.3)'), sh(poly([[C[0] - 17, C[1] - 2], [C[0] - 20, C[1] - 24], [C[0] - 9, C[1] - 14], [C[0], C[1] - 30], [C[0] + 9, C[1] - 14], [C[0] + 20, C[1] - 24], [C[0] + 17, C[1] - 2]]), gl(C[0] - 20, C[1] - 30, C[0] + 20, C[1]), { s: '#7a4800', w: 1.8 }),
    sh(rect(C[0] - 18, C[1] - 7, 36, 7, 3), gl(0, C[1] - 7, 0, C[1]), { s: '#7a4800', w: 1.3 }), st(line([[C[0] - 18, C[1] - 22], [C[0] - 15, C[1] - 4]]), 'rgba(255,255,255,0.7)', 1.3),
    ...gemS(C[0], C[1] - 33, 4.2, '#ff3a8a', ink), ...gemS(C[0] - 20, C[1] - 27, 3.2, '#3aa8ff', ink), ...gemS(C[0] + 20, C[1] - 27, 3.2, '#3ad08a', ink), ...gemS(C[0], C[1] - 4, 2.6, '#a05cff', ink), ...gemS(C[0] - 10, C[1] - 4, 2, '#ffb020', ink), ...gemS(C[0] + 10, C[1] - 4, 2, '#ff5c9a', ink)];
  const lock = [sh(rect(-19, -97, 10, 18, 4), gl(-19, 0, -9, 0), { s: ink, w: 1.3 }), ...paw(-14, -66, 15, gl(-28, -82, 0, -52), { ink: '#7a4800', w: 2.4 }), sh(ell(-14, -62.7, 7.8, 6.3), cg(-14, -63, 0, 1.4, ...RBC), { s: '#7a4800', w: 1.1 }), sh(ell(-16.4, -65, 2.2, 1.4), 'rgba(255,255,255,0.9)'), sh(ell(-14, -58, 1.6), '#4a2600')];
  return { name: 'Rainbow Royal Cushion Chest', mat: 'petgem', hp: 14, W: 236, H: 218, ko: 'pie', pieN: 8, ring: true,
    hull: cvx(B.pts.concat(SB.pts, cu.pts, [[C[0], C[1] - 38], [tA[0] - 6, tA[1] + 26], [tB[0] + 6, tB[1] + 26], [-112, 8], [bpx + 12, bpy + 8]])),
    parts: [{ id: 'body', sh: body }, { id: 'seam', sh: seam }, { id: 'studA', sh: studs(0), tear: 0.32 }, { id: 'studB', sh: studs(1), tear: 0.54 },
      { id: 'lock', sh: lock, tear: 0.9, hang: [-14, -96], loose: 0.6, hmax: 0.5, hdir: 1 }, { id: 'lid', sh: Ls, launch: true },
      { id: 'tA', sh: tassel(tA), tear: 0.42, hang: tA, loose: 0, hmax: 0.3, hdir: -1 }, { id: 'tB', sh: tassel(tB), tear: 0.64, hang: tB, loose: 0, hmax: 0.3, hdir: 1 },
      { id: 'crown', sh: crown, tear: 0.74, launch: true }],
    loot: ['bone', 'gem', 'paw', 'star', 'heart', 'coin'] };
}

/* ---------- loot icons ---------- */
function icBone(c, s) {
  const g = c.createLinearGradient(0, -s * 0.2, 0, s * 0.2); g.addColorStop(0, '#ffffff'); g.addColorStop(1, '#e8dcc8'); c.fillStyle = g; c.strokeStyle = '#8a6a4a'; c.lineWidth = s * 0.06;
  const P = () => { c.beginPath(); c.rect(-s * 0.32, -s * 0.08, s * 0.64, s * 0.16); [[-0.34, -0.1], [-0.34, 0.1], [0.34, -0.1], [0.34, 0.1]].forEach(([x, y]) => { c.moveTo(x * s + s * 0.12, y * s); c.arc(x * s, y * s, s * 0.12, 0, TAU); }); };
  c.save(); c.rotate(-0.5); P(); c.stroke(); P(); c.fill(); c.restore();
}
function icPaw(c, s) {
  const g = c.createRadialGradient(-s * 0.1, -s * 0.1, 0, 0, 0, s * 0.5); g.addColorStop(0, '#ffd0ec'); g.addColorStop(1, '#ff5ca8'); c.fillStyle = g; c.strokeStyle = '#9a1a5a'; c.lineWidth = s * 0.05;
  [[0, 0.1, 0.24, 0.2], [-0.29, -0.16, 0.09, 0.12], [0.29, -0.16, 0.09, 0.12], [-0.1, -0.31, 0.1, 0.13], [0.1, -0.31, 0.1, 0.13]].forEach(([x, y, rx, ry]) => { c.beginPath(); c.ellipse(x * s, y * s, rx * s, ry * s, 0, 0, TAU); c.fill(); c.stroke(); });
}
function icHeart(c, s) {
  c.beginPath(); c.moveTo(0, s * 0.36); c.bezierCurveTo(-s * 0.62, -s * 0.04, -s * 0.3, -s * 0.46, 0, -s * 0.16); c.bezierCurveTo(s * 0.3, -s * 0.46, s * 0.62, -s * 0.04, 0, s * 0.36); c.closePath();
  const g = c.createRadialGradient(-s * 0.12, -s * 0.12, 0, 0, 0, s * 0.5); g.addColorStop(0, '#ffb0c8'); g.addColorStop(1, '#e5304a'); c.fillStyle = g; c.fill(); c.strokeStyle = '#8a0a24'; c.lineWidth = s * 0.05; c.stroke();
  c.fillStyle = 'rgba(255,255,255,0.75)'; c.beginPath(); c.ellipse(-s * 0.16, -s * 0.1, s * 0.07, s * 0.05, -0.6, 0, TAU); c.fill();
}

const Cd = CM.MAT.candy, Mt = CM.MAT.metal, W = CM.MAT.wood, Ca = CM.MAT.card;
CM.register('pet', [petCarrier, petHouse, petTrunk, petPalace, petCushion], {
  mat: {
    petcard: Object.assign({}, Ca, { soft: 1.6, chips: ['#dba566', '#c08548', '#f0cf98', '#2a6ad8'], sfx: { m: 'card', p: 1, x: ['squeak'] } }),
    kennel: Object.assign({}, W, { chips: ['#e5483a', '#ff7a62', '#fff6ec', '#3a74d8', '#c48a4e'], sfx: { m: 'wood', p: 1.1, x: ['squeak'] } }),
    velvet: { soft: 0.9, lean: 5, sag: 5, dentK: 7, dentShade: 0.32, holeFrom: 0.3, holeP: 0.6, holeR: [15, 22], jag: 'tear', edge: '#fff2dc', edgeW: 7, crack: 'rip', chips: ['#7a2ac8', '#b874f0', '#ffffff', '#e8b84a', '#c88a4a'], deb: 'fluff', deb2: 'chip', dust: '#f2e6ff', mass: 1.1, sfx: { m: 'velvet', p: 1, x: ['squeak'] }, rest: 0.15, flutter: 0.15, cav: ['#14041e', '#2a0a3a'], glow: '#ffd27a' },
    royal: Object.assign({}, Mt, { chips: ['#3a5ae8', '#ffd23a', '#d8302a', '#c9d3e0', '#3ad08a'], dust: '#e2e4f4', sfx: { m: 'gold', p: 1.05, x: ['squeak', 'vault'] }, cav: ['#060828', '#141a50'], glow: '#ffd84a' }),
    petgem: Object.assign({}, Cd, { deb2: 'fluff', sfx: { m: 'crystal', p: 1, x: ['rainbow', 'squeak'] } }),
  },
  icons: { bone: icBone, paw: icPaw, heart: icHeart },
});
}
(function go() { if (window.ChestModels && window.ChestModels.H) run(); else setTimeout(go, 30); })();
})();
