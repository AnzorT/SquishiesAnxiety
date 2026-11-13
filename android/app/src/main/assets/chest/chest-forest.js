// Forest Friends chests for ChestModels: Mossy Stump Stash -> Birch Bark Box -> Ranger's Log Chest -> Ancient Grove Chest -> Rainbow Fairy Ring Treasury.
(function () {
'use strict';
function run() {
const CM = window.ChestModels, H = CM.H, K = CM.K;
const { parse, poly, line, rect, ell, shift, lg, rg, sh, st, tx, P3, mapD, onP, FR, Box, cvx, boxFill, boxShade, corner3, plankS, surf, Barrel, nail } = H;
const { PI, TAU, mixH, R2, gl, ir, gemS, IRON, ball, rev, ringP, disc, FA, cylP, onCyl, vault, treasury, rbLid, pal, RBW, revE, pE, discE, ringE, onCylE, arcE } = K;

/* ---------- forest art ---------- */
function shroom(x, y, s, c, ink, o) {
  o = o || {}; const cap = parse(`M${x - s * 0.75} ${y - s * 0.68} Q${x - s * 0.72} ${y - s * 1.45} ${x} ${y - s * 1.45} Q${x + s * 0.72} ${y - s * 1.45} ${x + s * 0.75} ${y - s * 0.68} Q${x} ${y - s * 0.5} ${x - s * 0.75} ${y - s * 0.68} Z`);
  return [sh(parse(`M${x - s * 0.26} ${y} L${x - s * 0.2} ${y - s * 0.72} L${x + s * 0.2} ${y - s * 0.72} L${x + s * 0.28} ${y} Q${x} ${y + s * 0.08} ${x - s * 0.26} ${y} Z`), o.stem || lg(x - s * 0.3, 0, x + s * 0.3, 0, '#fff8ea', '#e2d0b0'), { s: ink, w: 1 }),
    sh(cap, o.cap || rg(x - s * 0.25, y - s * 1.2, s, '#ff8a6a', c || '#e5483a', '#9a1e14'), { s: ink, w: 1.2 }),
    ...[[-0.38, -1.02, 0.13], [0.08, -1.24, 0.12], [0.42, -0.94, 0.1], [-0.08, -0.9, 0.08]].map(([a, b, k]) => sh(ell(x + a * s, y + b * s, k * s * 1.25, k * s), o.dot || '#fff8ea')),
    st(parse(`M${x - s * 0.5} ${y - s * 1.08} Q${x - s * 0.35} ${y - s * 1.32} ${x - s * 0.08} ${y - s * 1.38}`), 'rgba(255,255,255,0.6)', Math.max(1, s * 0.07))];
}
function acorn(x, y, s, a, ink, C) {
  C = C || {}; const f = R2(x, y, s, a || 0), M = d => mapD(parse(d), f), lw = Math.max(1, s * 0.06);
  return [sh(M('M-0.42 -0.1 Q-0.46 0.42 0 0.64 Q0.46 0.42 0.42 -0.1 Z'), C.nut || rg(...f(-0.15, 0.1), s * 0.6, '#f4b866', '#c47a30', '#7a4214'), { s: ink, w: lw }),
    sh(M('M-0.54 -0.04 Q-0.52 -0.48 0 -0.5 Q0.52 -0.48 0.54 -0.04 Q0 0.06 -0.54 -0.04 Z'), C.cap || rg(...f(-0.2, -0.35), s * 0.6, '#c8986a', '#8a5a2e', '#4e2e12'), { s: ink, w: lw }),
    st(M('M-0.4 -0.2 L0.4 -0.2'), 'rgba(40,20,5,0.4)', lw * 0.8), st(M('M-0.28 -0.38 L0.28 -0.38'), 'rgba(40,20,5,0.35)', lw * 0.8), st(M('M0 -0.5 Q0.06 -0.66 0.2 -0.72'), ink, Math.max(1.2, s * 0.09)),
    sh(ell(...f(-0.18, 0.2), s * 0.08, s * 0.15), 'rgba(255,255,255,0.6)')];
}
function leaf(x, y, s, a, fill, ink) {
  const f = R2(x, y, s, a || 0), M = d => mapD(parse(d), f), lw = Math.max(0.8, s * 0.06);
  return [sh(M('M0 0 Q0.46 -0.36 0 -1 Q-0.46 -0.36 0 0 Z'), fill || lg(...f(-0.3, -0.5), ...f(0.3, -0.5), '#a4e46a', '#4aa03a', '#2a6a24'), { s: ink, w: lw }),
    st(M('M0 0.08 L0 -0.86'), 'rgba(255,255,255,0.55)', lw), st(M('M0 -0.3 L0.2 -0.44 M0 -0.5 L-0.18 -0.64 M0 -0.62 L0.15 -0.74'), 'rgba(255,255,255,0.4)', lw * 0.8)];
}
const blobs = (B, ink, c) => B.map(([x, y, a, b]) => st(ell(x, y, a, b), ink, 2.2)).concat(B.map(([x, y, a, b]) => sh(ell(x, y, a, b), rg(x - a * 0.35, y - b * 0.45, a * 1.5, ...(c || ['#b4e47a', '#62a83e', '#2e6a24'])))));
const GA = { nut: rg(0, 0, 1, '#fff6c0', '#ffd23a', '#a86e00'), cap: rg(0, 0, 1, '#ffe8a0', '#d89a10', '#7a4800') };
const gAcorn = (x, y, s, a, ink) => acorn(x, y, s, a, ink, { nut: rg(x - s * 0.15, y, s * 0.7, '#fff6c0', '#ffd23a', '#a86e00'), cap: rg(x - s * 0.2, y - s * 0.4, s * 0.7, '#ffe8a0', '#d89a10', '#7a4800') });

/* ---------- COMMON: mossy stump stash ---------- */
function forestStump() {
  const ink = '#3e2208', X = 4, k = 0.4, r = 42, yT = -82, rb = v => r + 7 * Math.pow(1 - v, 3) + 1.4 * Math.sin(v * 9);
  const bark = revE(X, (v, a) => [rb(v) * (1 + 0.025 * Math.sin(a * 11)), yT * v], 44, 6, (u, v, i) => ['#8a5a30', '#74482a', '#966438', '#6a4024', '#82522c'][i % 5], { k, dk: '#2a1404' });
  const body = [...bark.sh], hull = cvx(bark.pts);
  for (let q = 0; q < 44; q++) { const u = (q + 0.5) / 44; bark.lineOn(Array.from({ length: 9 }, (_, j) => [u + Math.sin(j * 1.7 + q * 2.3) * 0.004, j / 8]), 0.04).forEach(p => body.push(st(p, 'rgba(40,18,4,0.55)', 1.3))); }
  body.push(sh(hull, lg(X - 50, 0, X + 50, 0, [0, 'rgba(255,230,190,0.16)'], [0.3, 'rgba(255,230,190,0.26)'], [0.45, 'rgba(255,230,190,0)'], [0.7, 'rgba(30,10,0,0)'], [1, 'rgba(30,10,0,0.45)'])), sh(hull, lg(0, yT, 0, 18, [0, 'rgba(30,10,0,0)'], [0.75, 'rgba(30,10,0,0)'], [1, 'rgba(30,10,0,0.3)'])));
  const door = parse('M-12 0 L-12 -24 Q-12 -36 0 -36 Q12 -36 12 -24 L12 0 Z');
  body.push(...onCylE(X, r + 1.2, [sh(door, lg(-12, 0, 12, 0, '#d8a060', '#a8703f', '#7a4a26')), st(line([[-4, -34], [-4, 0]]), 'rgba(60,30,8,0.5)', 1.2), st(line([[4, -34], [4, 0]]), 'rgba(60,30,8,0.5)', 1.2),
    st(parse('M-12 -1 L-12 -24 Q-12 -36 0 -36 Q12 -36 12 -24 L12 -1'), '#4a2a10', 3.4), sh(ell(7, -16, 1.8), gl(5, -18, 9, -14)),
    sh(ell(0, -54, 7), rg(-2, -56, 9, '#fff6c0', '#ffd23a', '#e88a00'), { s: '#4a2a10', w: 2.6 }), st(line([[-7, -54], [7, -54]]), '#4a2a10', 1.4), st(line([[0, -61], [0, -47]]), '#4a2a10', 1.4)], -0.12, k), st(hull, ink, 2.4));
  const sp = pE(X, r + 5, -PI / 2 - 0.12, 0, k); body.push(sh(ell(sp[0], sp[1] - 1, 15, 4.5), lg(sp[0] - 14, 0, sp[0] + 14, 0, '#d8d4cc', '#8e8a84'), { s: ink, w: 1.2 }));
  body.push(...blobs([[X - 50, -3, 9, 5], [X - 40, 2, 7, 4], [X + 44, 1, 8, 4.5]], '#1e4a14'));
  const rt = rb(1) * 1.0;
  const top = [sh(discE(X, rt + 1, yT, k), '#5a361c'), sh(discE(X, rt - 3, yT, k), lg(X - rt, yT - k * rt, X + rt, yT + k * rt, '#fae2b0', '#e8c088', '#cf9e62'))];
  [0.8, 0.6, 0.42, 0.24].forEach(q => top.push(st(discE(X + 3 * (1 - q), (rt - 3) * q, yT + 1.4 * (1 - q), k), 'rgba(150,95,40,0.5)', 1.2)));
  top.push(sh(ell(X + 3, yT + 1.4, 2.6, 1.2), '#a8703f'), st(line([[X + 6, yT + 2], [X + 20, yT + 6], [X + 26, yT + 9]]), '#6a3e16', 1.6), st(discE(X, rt + 1, yT, k), ink, 2));
  const tw = [X + 16, yT - 8]; top.push(st(parse(`M${tw[0]} ${tw[1]} Q${tw[0] - 2} ${tw[1] - 10} ${tw[0] + 2} ${tw[1] - 18}`), '#5a3a14', 2.4), ...leaf(tw[0] + 1, tw[1] - 12, 11, 1.1, null, '#1e4a14'), ...leaf(tw[0] + 2, tw[1] - 17, 10, -0.7, null, '#1e4a14'));
  const mb = []; for (let q = -7; q <= 7; q++) { const a = -PI / 2 + q * 0.2, p = pE(X, rt + 1, a, yT + 1, k), s = 5 + ((q * 5 + 21) % 3) * 1.4; mb.push([p[0], p[1] + 1, s * 1.25, s]); if ((q + 9) % 3 === 0) mb.push([p[0] + 1, p[1] + s + 4, 3.2, 5.5]); }
  const moss = blobs(mb, '#1e4a14');
  const s0 = pE(X, r + 6, -PI / 2 + 0.95, 0, k), mush = [...shroom(s0[0] + 12, s0[1] - 2, 10, '#ff9a3a', ink), ...shroom(s0[0], s0[1] + 2, 16, null, ink)];
  const ac2 = [X - 12, yT - 6];
  const sg = pE(X, r + 1.5, -PI / 2 - 0.75, -64, k), sign = [nail(sg[0], sg[1] - 6, 1.4), st(line([[sg[0], sg[1] - 6], [sg[0] - 12, sg[1]]]), '#5a3a14', 1), st(line([[sg[0], sg[1] - 6], [sg[0] + 12, sg[1]]]), '#5a3a14', 1),
    sh(rect(sg[0] - 17, sg[1], 34, 12, 2), lg(0, sg[1], 0, sg[1] + 12, '#f2c88a', '#c88a4a'), { s: ink, w: 1.3 }), tx('STASH', sg[0], sg[1] + 6.4, '700 7.6px Fredoka, Nunito, sans-serif', '#5a2e10')];
  return K.liftM({ name: 'Mossy Stump Stash', mat: 'moss', hp: 6, W: 112, H: 137, ko: 'halves',
    hull: cvx(bark.pts.concat(ringE(X, rt + 1, yT, k), [[tw[0], tw[1] - 26], [ac2[0], ac2[1] - 12]])),
    parts: [{ id: 'body', sh: body }, { id: 'top', sh: top, launch: true, launchV: 380 }, { id: 'moss', sh: moss }, { id: 'sign', sh: sign, tear: 0.62, hang: [sg[0], sg[1] - 6], loose: 0.2, hmax: 0.8, hdir: 1 },
      { id: 'mush', sh: mush, tear: 0.34 }, { id: 'acorn', sh: acorn(ac2[0], ac2[1], 16, 0.35, ink), tear: 0.5 }],
    loot: ['acorn', 'coin', 'leaf', 'mushroom'] }, -k * rb(0));
}

/* ---------- RARE: birch bark box ---------- */
function forestBirch() {
  const ink = '#3a3424', B = Box(-66, -78, 48, 0, 36), L = Box(-69, -92, 51, -78, 39, -1.5);
  const BIR = { f: ['#ffffff', '#f2eee2', '#d6d0be'], t: ['#ffffff', '#ebe5d4'], s: ['#e0dac8', '#b4ac98'] };
  const marks = (x0, y0, x1, y1, n, sd) => { const o = []; for (let i = 0; i < n; i++) { const x = x0 + ((i * 37 + sd * 11) % 97) / 97 * (x1 - x0 - 8), y = y0 + 2 + ((i * 53 + sd * 29) % 89) / 89 * (y1 - y0 - 5), w = 4 + (i * 13 + sd) % 8; o.push(sh(rect(x, y, w, 1.4 + (i % 3) * 0.7, 0.7), 'rgba(40,34,26,0.78)')); } return o; };
  const eye = (x, y, s) => [sh(parse(`M${x - s} ${y} Q${x} ${y - s * 0.55} ${x + s} ${y} Q${x} ${y + s * 0.35} ${x - s} ${y} Z`), '#3a3224'), st(parse(`M${x - s * 0.8} ${y - s * 0.5} Q${x} ${y - s * 0.95} ${x + s * 0.8} ${y - s * 0.5}`), 'rgba(40,34,26,0.6)', 1.2)];
  const body = [...boxFill(B, BIR), ...marks(-66, -78, 48, 0, 26, 1), ...eye(-50, -24, 7), ...eye(30, -60, 5), ...onP(marks(0, -78, 36, 0, 9, 3).concat(eye(18, -54, 5)), B.pS)];
  body.push(sh(ell(-38, -52, 14), '#fff8ea', { s: '#2e6a24', w: 2.2 }), sh(ell(-38, -52, 10.5), 'rgba(0,0,0,0)', { s: 'rgba(46,106,36,0.5)', w: 1 }), ...leaf(-38, -43, 17, 0.2, null, '#1e4a14'), ...boxShade(B, ink, { k: 0.8 }));
  const lid = [...boxFill(L, BIR), ...onP(marks(-69, 0, 51, 39, 18, 5), L.pT), ...marks(-69, -92, 51, -80, 6, 7), sh(rect(-69, -80.5, 120, 2.5), '#a8703f'), ...boxShade(L, ink, { k: 0.8 })];
  const rope = (d, w) => [st(d, '#5a3e14', w + 1.8), st(d, '#d8b070', w)];
  const ticks = (pts, n) => { const o = []; for (let i = 1; i < n; i++) { const p = [pts[0][0] + (pts[1][0] - pts[0][0]) * i / n, pts[0][1] + (pts[1][1] - pts[0][1]) * i / n]; o.push(st(line([[p[0] - 1.6, p[1] + 1], [p[0] + 1.6, p[1] - 1]]), 'rgba(110,70,20,0.65)', 1)); } return o; };
  const tw = -12, twine = [...rope(L.top(line([[tw, 0], [tw, 39]])), 2.6), ...rope(line([[tw, -92], [tw, 0]]), 2.8), ...ticks([[tw, -92], [tw, 0]], 22), ...rope(line([[-66, -40], [48, -40]]), 2.8), ...ticks([[-66, -40], [48, -40]], 28), ...rope(B.side(line([[0, -40], [36, -40]])), 2.6),
    st(parse(`M${tw} -40 C${tw - 14} -52 ${tw - 16} -34 ${tw} -40 C${tw + 14} -52 ${tw + 16} -34 ${tw} -40`), '#5a3e14', 4.4), st(parse(`M${tw} -40 C${tw - 14} -52 ${tw - 16} -34 ${tw} -40 C${tw + 14} -52 ${tw + 16} -34 ${tw} -40`), '#d8b070', 2.6), sh(ell(tw, -40, 3), '#c89a58', { s: '#5a3e14', w: 1.2 })];
  const tag = [st(parse(`M${tw} -40 Q${tw + 2} -30 ${tw + 6} -24`), '#5a3e14', 1.2), sh(poly([[tw + 1, -24], [tw + 11, -24], [tw + 15, -18], [tw + 15, -2], [tw - 3, -2], [tw - 3, -18]]), lg(0, -24, 0, -2, '#e8c088', '#c89458'), { s: '#6a4a1e', w: 1.2 }), sh(ell(tw + 6, -19, 1.6), '#6a4a1e'), ...leaf(tw + 6, -5, 11, 0, null, '#1e4a14')];
  const pc = L.pT(-8, 20), cone = [sh(ell(pc[0] + 2, pc[1] + 2, 16, 6), 'rgba(40,30,10,0.3)'), sh(ell(pc[0], pc[1] - 5, 16, 8.5), rg(pc[0] - 5, pc[1] - 9, 18, '#c88a4a', '#8a5426', '#4e2c10'), { s: ink, w: 1.4 })];
  for (let rr = 0; rr < 3; rr++) for (let k = 0; k < 6; k++) { const x = pc[0] - 12 + k * 4.6 + (rr % 2) * 2.3, y = pc[1] - 10 + rr * 4.2; cone.push(st(parse(`M${x - 2.6} ${y} Q${x} ${y + 3} ${x + 2.6} ${y}`), 'rgba(40,20,5,0.6)', 1.1), st(parse(`M${x - 2} ${y - 0.8} Q${x} ${y + 1.4} ${x + 2} ${y - 0.8}`), 'rgba(255,220,170,0.35)', 0.8)); }
  cone.push(st(parse(`M${pc[0] + 15} ${pc[1] - 6} L${pc[0] + 22} ${pc[1] - 8}`), '#5a3a14', 2), ...[-0.9, -0.5, -0.1, 0.3].map(a => st(line([[pc[0] + 21, pc[1] - 8], [pc[0] + 21 + Math.cos(a) * 9, pc[1] - 8 + Math.sin(a) * 9]]), '#2e7a34', 1.4)));
  const m0 = P3(48, 0, 8), mush = [...shroom(m0[0] + 16, m0[1] - 6, 9, '#ff9a3a', ink), ...shroom(m0[0] + 5, m0[1], 14, null, ink)];
  const moss = blobs([[-66, -93, 8, 5], [-58, -95, 7, 4.5], [-50, -92.5, 6, 4], [-67, -86, 4, 6], [-62, -84, 3, 5]], '#1e4a14');
  return { name: 'Birch Bark Box', mat: 'birch', hp: 8, W: 150, H: 140, ko: 'planks', rows: [[-200, -78], [-78, -39], [-39, 30]],
    hull: cvx(B.pts.concat(L.pts, [[pc[0], pc[1] - 16], [m0[0] + 18, m0[1] + 2]])),
    parts: [{ id: 'body', sh: body }, { id: 'lid', sh: lid, launch: true }, { id: 'twine', sh: twine }, { id: 'tag', sh: tag, tear: 0.3, hang: [tw, -40], loose: 0, hmax: 0.6, hdir: 1 },
      { id: 'moss', sh: moss, tear: 0.6, hang: [-58, -92], loose: 0.3, hmax: 0.5, hdir: -1 }, { id: 'mush', sh: mush, tear: 0.46 }, { id: 'cone', sh: cone, launch: true, launchV: 420 }],
    loot: ['acorn', 'coin', 'leaf', 'coin', 'mushroom'] };
}

/* ---------- EPIC: ranger's log chest ---------- */
function forestLog() {
  const ink = '#3a1e08', B = Box(-84, -78, 54, 0, 40), S = d => B.side(d), PC = ['#dca468', '#b88048', '#8e5c2e'], PS = ['#b07a42', '#7e5028'];
  const body = [];
  for (let r = 0; r < 3; r++) body.push(...plankS(-84, -78 + r * 26, 138, 26, FR, PC, r === 1 ? [-56, -40] : null, r * 3 + 1));
  for (let r = 0; r < 3; r++) body.push(...plankS(0, -78 + r * 26, 40, 26, S, PS, null, r * 5 + 2));
  body.push(...boxShade(B, ink, { only: 'FS', k: 0.7, noBevel: true }));
  const band = x => [sh(rect(x, -78, 10, 78), ir(x, 0, x + 10, 0), { s: '#1a1c22', w: 1.2 }), st(line([[x + 2, -76], [x + 2, -2]]), 'rgba(255,255,255,0.35)', 1), nail(x + 5, -70, 1.8), nail(x + 5, -40, 1.8), nail(x + 5, -8, 1.8)];
  body.push(...band(-64), ...band(30));
  const xa = -88, xb = 58, yb = -78, dh = 30, Bl = Barrel(xa, xb, yb, dh, 21, -1), cu = surf(Bl.f3, 22, 12, (u, v, i, j) => ['#7a4a26', '#62391a', '#8a5630', '#6e4220'][(j + (i % 7 === 0 ? 1 : 0)) % 4], { c: [-15, -68, 20], dk: '#1a0a02' });
  const lid = [...cu.sh];
  for (let j = 1; j < 12; j++) cu.lineOn(Array.from({ length: 31 }, (_, i) => [i / 30, j / 12 + 0.012 * Math.sin(i * 0.9 + j * 2)]), 0.02).forEach(p => lid.push(st(p, 'rgba(30,12,2,0.55)', 1.3)));
  const ringC = k => poly(Array.from({ length: 25 }, (_, i) => { const t = PI * i / 24; return P3(xb + 0.5, yb - dh * k * Math.sin(t), 20 - 21 * k * Math.cos(t)); }));
  lid.push(sh(Bl.cap, lg(...P3(xb, -108, 20), ...P3(xb, -78, 20), '#f2d09a', '#d8a868')), ...[0.78, 0.56, 0.34, 0.14].map(k => st(ringC(k), 'rgba(140,84,36,0.55)', 1.2)), st(Bl.cap, '#4a2a10', 4.4), st(Bl.cap, '#8a5630', 2.2));
  [-59, 35].forEach(x => { const u = (x - xa) / (xb - xa); cu.lineOn(Array.from({ length: 25 }, (_, i) => [u, i / 24]), 0.04).forEach(p => lid.push(st(p, '#1a1c22', 11), st(p, ir(0, -110, 0, -78), 8.5), st(shift(p, -1.2, -1), 'rgba(255,255,255,0.3)', 1)));
    [0.12, 0.5].forEach(v => { if (cu.visAt(u, v) > 0) { const p = cu.P(u, v); lid.push(nail(p[0], p[1], 1.8)); } }); });
  lid.push(st(line([P3(xa, yb, -1), P3(xb, yb, -1)]), ink, 2.4));
  const cs = [corner3(B, -1, 1, 18, 6, 1.5, IRON, '#1a1c22'), corner3(B, 1, 1, 18, 6, 1.5, IRON, '#1a1c22')];
  const ow = -15, oy = -42, owl = [sh(ell(ow + 1.5, oy + 1.8, 17), 'rgba(40,15,0,0.35)'), sh(ell(ow, oy, 17), rg(ow - 5, oy - 6, 22, '#f2c88a', '#c88a4a', '#8a5426'), { s: ink, w: 1.6 }), st(ell(ow, oy, 13.5), 'rgba(90,50,15,0.5)', 1.2),
    sh(parse(`M${ow - 9} ${oy - 7} L${ow - 7} ${oy - 13} L${ow - 3} ${oy - 8} Q${ow} ${oy - 9} ${ow + 3} ${oy - 8} L${ow + 7} ${oy - 13} L${ow + 9} ${oy - 7} Q${ow + 11} ${oy + 8} ${ow} ${oy + 10} Q${ow - 11} ${oy + 8} ${ow - 9} ${oy - 7} Z`), '#7a4a1e'),
    sh(ell(ow - 4.2, oy - 2.5, 4), '#f6e2b8'), sh(ell(ow + 4.2, oy - 2.5, 4), '#f6e2b8'), sh(ell(ow - 4, oy - 2.3, 1.9), '#2a1404'), sh(ell(ow + 4, oy - 2.3, 1.9), '#2a1404'), sh(poly([[ow - 1.6, oy + 1], [ow + 1.6, oy + 1], [ow, oy + 4]]), '#ffb020'),
    ...[[-3, 5], [0, 6.5], [3, 5]].map(([a, b]) => st(parse(`M${ow + a - 1.6} ${oy + b} Q${ow + a} ${oy + b + 1.8} ${ow + a + 1.6} ${oy + b}`), '#f2c88a', 1)), nail(ow, oy - 15, 1.5)];
  const lock = [sh(rect(-22, -86, 14, 24, 4), ir(-22, 0, -8, 0), { s: '#1a1c22', w: 1.3 }), nail(-15, -82, 1.5), sh(parse('M-15 -77 Q-9 -72 -15 -66 Q-21 -72 -15 -77 Z'), '#22262c'), st(line([[-15, -74], [-15, -69]]), '#a8b0bc', 1)];
  const mush = [...shroom(-58, 2, 10, '#ff9a3a', ink), ...shroom(-74, 3, 15, null, ink)];
  const vp = Array.from({ length: 25 }, (_, i) => [-86 + i * 4, -79 + Math.sin(i * 0.8) * 3 + i * 0.25]), vine = [st(line(vp), '#1e4a14', 3.6), st(line(vp), '#5aa03a', 2)];
  [2, 6, 10, 14, 18, 22].forEach((i, k) => vine.push(...leaf(vp[i][0], vp[i][1], 9, k % 2 ? 2.6 : 0.5, null, '#1e4a14')));
  const coil = onP([0, 1, 2].map(k => st(ell(20, -40, 11 - k * 3.2, 9 - k * 2.6), '#5a3e14', 3.6)).concat([0, 1, 2].map(k => st(ell(20, -40, 11 - k * 3.2, 9 - k * 2.6), '#d8b070', 2.2)), [st(line([[20, -49], [20, -56]]), '#5a3e14', 1.6), sh(ell(20, -57, 2.4), '#9aa2b0', { s: '#22262c', w: 1 })]), B.pS);
  return { name: "Ranger's Log Chest", mat: 'oak', hp: 10, W: 180, H: 150, ko: 'planks', rows: [[-200, -78], [-78, -40], [-40, 30]],
    hull: cvx(B.pts.concat(Bl.pts, [[-86, 3], [-62, 3]])),
    parts: [{ id: 'body', sh: body }, { id: 'c0', sh: cs[0].sh, tear: 0.36, hang: cs[0].hang, loose: 0.2, hmax: 0.6, hdir: -1 }, { id: 'c1', sh: cs[1].sh, tear: 0.78, hang: cs[1].hang, loose: 0.6, hmax: 0.6, hdir: 1 },
      { id: 'owl', sh: owl, tear: 0.66, hang: [ow, oy - 15], loose: 0.4, hmax: 0.7, hdir: 1 }, { id: 'mush', sh: mush, tear: 0.3 }, { id: 'rope', sh: coil, tear: 0.55, hang: B.pS(20, -56), loose: 0.2, hmax: 0.5, hdir: 1 },
      { id: 'lid', sh: lid, launch: true }, { id: 'vine', sh: vine, tear: 0.46, hang: [-86, -79], loose: 0.15, hmax: 0.5, hdir: -1 }, { id: 'lock', sh: lock, tear: 0.9, hang: [-15, -84], loose: 0.65, hmax: 0.5, hdir: 1 }],
    loot: ['acorn', 'coin', 'leaf', 'mushroom', 'coin', 'star'] };
}

/* ---------- LEGENDARY: ancient grove chest ---------- */
function forestGrove() {
  const ink = '#0a2a12', gi = '#5a3a00';
  const niche = (x0, w) => parse(`M${x0} -52 L${x0} -70 Q${x0} -84 ${x0 + w / 2} -84 Q${x0 + w} -84 ${x0 + w} -70 L${x0 + w} -52 Z`);
  const nArt = (x, w) => { const n = niche(x, w); return [sh(n, lg(x, -84, x + w, -52, '#0e3a18', '#06200c')), ...leaf(x + w / 2 - 5, -54, 22, -0.35, gl(x, -80, x + w, -56), gi), ...gAcorn(x + w / 2 + 8, -62, 10, 0.3, gi), st(n, gi, 4.4), st(n, gl(x, -84, x + w, -52), 2.6)]; };
  return vault({ name: 'Ancient Grove Chest', mat: 'grove', ink, gi, C: { f: ['#5ac06e', '#2a7a3c', '#124a20'], t: ['#7ad08a', '#3a9a4e'], s: ['#22683a', '#0c3818'] },
    front: () => { const o = [...nArt(-86, 34), ...nArt(18, 34)]; [-80, -60, 28, 48].forEach((x, i) => o.push(...leaf(x, -12, 10, i % 2 ? 0.4 : -0.4, gl(x - 4, -22, x + 4, -12), gi))); return o; },
    side: () => nArt(5, 32), band: [-46, 12, '#ffd08a', '#e88a1a', '#8a4006'], gems: ['#ffb020', '#3ad08a'],
    lid: 'barrel', dh: 32, lidCol: (u, v, i, j) => (i + j) % 2 ? '#2e8a44' : '#2a8040', capC: ['#2a7a3c', '#0c3818'], dk: '#04200a',
    lidDeco: ({ cu }) => { const o = [], vv = u => 0.42 + 0.1 * Math.sin(u * TAU * 2.5);
      cu.lineOn(Array.from({ length: 61 }, (_, i) => [i / 60, vv(i / 60)]), 0).forEach(p => o.push(st(p, gi, 4.6), st(p, gl(0, -124, 0, -90), 2.6)));
      for (let k = 0; k < 10; k++) { const u = (k + 0.5) / 10, v = vv(u) + (k % 2 ? 0.08 : -0.08); if (cu.visAt(u, v) > 0.15) { const p = cu.P(u, v); o.push(...leaf(p[0], p[1], 11, k % 2 ? 2.4 : -0.6, gl(p[0] - 5, p[1] - 10, p[0] + 5, p[1]), gi)); } }
      [0.25, 0.65].forEach(u => { const p = cu.P(u, vv(u)); o.push(...gAcorn(p[0], p[1] - 2, 9, 0.2, gi)); }); return o; },
    crest: T => [sh(ell(T[0], T[1] + 2, 16, 4), 'rgba(0,30,10,0.35)'), ...leaf(T[0] - 4, T[1], 18, -1.1, lg(T[0] - 18, 0, T[0], 0, '#9af0a8', '#2aa04a', '#0e5a24'), gi), ...leaf(T[0] + 4, T[1], 18, 1.1, lg(T[0], 0, T[0] + 18, 0, '#9af0a8', '#2aa04a', '#0e5a24'), gi), ...gAcorn(T[0], T[1] - 15, 24, 0, gi), ...gemS(T[0], T[1] - 23, 3, '#3ad08a', gi)],
    corner: (x, y) => gAcorn(x, y, 15, 0, gi),
    med: cx => [st(line([[cx, -40], [cx, -34]]), gi, 2.2), sh(ell(cx + 1.4, -18.6, 14), 'rgba(0,20,5,0.3)'), sh(ell(cx, -20, 14), gl(cx - 14, -34, cx + 14, -6), { s: gi, w: 1.8 }), st(ell(cx, -20, 11), 'rgba(122,72,0,0.55)', 1.2),
      sh(parse(`M${cx - 1.6} -11 L${cx - 1.2} -19 L${cx - 5} -23 M${cx + 1.6} -11 L${cx + 1.2} -19 L${cx + 5} -23`), 'rgba(0,0,0,0)', { s: '#7a4800', w: 1.8 }), st(line([[cx, -11], [cx, -22]]), '#7a4800', 2.4),
      ...[[-5, -25, 5], [5, -25, 5], [0, -28, 6]].map(([a, b, r]) => sh(ell(cx + a, b, r), '#2a9a4a', { s: '#0e5a24', w: 1 })), ...gemS(cx, -26, 2.2, '#ffb020', gi), sh(ell(cx - 7, -27, 2.6, 1.6), 'rgba(255,255,255,0.85)')],
    loot: ['acorn', 'coin', 'gem', 'leaf', 'star', 'coin'] });
}

/* ---------- RAINBOW: fairy ring treasury ---------- */
function forestFairy() {
  const ik = '#8a5200';
  return treasury({ name: 'Rainbow Fairy Ring Treasury', mat: 'fairy',
    art: [(x, y, s) => shroom(x, y + s * 0.32, s * 0.62, null, ik, { cap: RBW(x, y - s * 0.2), dot: '#ffffff' }), (x, y, s) => leaf(x, y + s * 0.42, s * 0.8, 0.3, RBW(x, y), ik), (x, y, s) => acorn(x, y + 2, s * 0.66, 0.25, ik, { nut: RBW(x, y + 6), cap: gl(x - 12, y - 14, x + 12, y) }), (x, y, s) => leaf(x, y + s * 0.4, s * 0.74, -0.2, RBW(x, y), ik)],
    lid: ink => rbLid(ink, (u, w) => mixH(pal(u), '#ff4a5a', 0.18), { x0: -114, x1: 86, z0: -12, z1: 59, h: 54, k: 0.62, deco: cu => { const o = [];
      [[0.12, 0.3], [0.3, 0.18], [0.5, 0.3], [0.7, 0.2], [0.88, 0.32], [0.22, 0.6], [0.42, 0.66], [0.62, 0.58], [0.8, 0.62], [0.95, 0.55], [0.35, 0.42], [0.58, 0.82]].forEach(([u, w]) => { const v = cu.visAt(u, w); if (v > 0.08) { const p = cu.P(u, w), s = 4 + 4 * v; o.push(sh(ell(p[0] + 0.8, p[1] + 1, s * 1.3, s * 0.8), 'rgba(80,0,40,0.18)'), sh(ell(p[0], p[1], s * 1.3, s * 0.8), rg(p[0] - s * 0.4, p[1] - s * 0.3, s * 1.4, '#ffffff', '#fff2fa', '#e8d0e8'))); } }); return o; } }),
    crest: (T, ink) => [sh(ell(T[0], T[1] + 2, 18, 4), 'rgba(60,0,80,0.3)'), ...leaf(T[0] - 3, T[1], 20, -1.15, lg(T[0] - 20, 0, T[0], 0, '#b0ffd0', '#3ad08a', '#0e7a44'), ink), ...leaf(T[0] + 3, T[1], 20, 1.15, lg(T[0], 0, T[0] + 20, 0, '#b0ffd0', '#3ad08a', '#0e7a44'), ink), ...gAcorn(T[0], T[1] - 16, 28, 0, ink), ...gemS(T[0], T[1] - 14, 4, '#ff5c9a', ink), ...gemS(T[0], T[1] - 28, 3, '#3aa8ff', ink)],
    lock: (x, ink) => [sh(rect(x - 5, -97, 10, 16, 4), gl(x - 5, 0, x + 5, 0), { s: ink, w: 1.3 }), ...leaf(x, -50, 34, 0, gl(x - 16, -84, x + 16, -50), '#7a4800'), sh(ell(x, -66, 6.5, 7.5), RBW(x, -66, 1.4), { s: '#7a4800', w: 1.1 }), sh(ell(x - 2, -68.5, 2, 1.4), 'rgba(255,255,255,0.9)'), sh(ell(x, -58, 1.5), '#4a2600')],
    loot: ['acorn', 'gem', 'leaf', 'star', 'mushroom', 'coin'] });
}

/* ---------- loot icons ---------- */
function icAcorn(c, s) {
  const g = c.createRadialGradient(-s * 0.08, 0, 0, 0, s * 0.05, s * 0.32); g.addColorStop(0, '#f4b866'); g.addColorStop(1, '#a8601e'); c.fillStyle = g; c.strokeStyle = '#4e2a0c'; c.lineWidth = s * 0.05;
  c.beginPath(); c.moveTo(-s * 0.24, -s * 0.02); c.quadraticCurveTo(-s * 0.26, s * 0.26, 0, s * 0.4); c.quadraticCurveTo(s * 0.26, s * 0.26, s * 0.24, -s * 0.02); c.closePath(); c.fill(); c.stroke();
  c.fillStyle = '#8a5a2e'; c.beginPath(); c.moveTo(-s * 0.3, 0); c.quadraticCurveTo(-s * 0.3, -s * 0.28, 0, -s * 0.28); c.quadraticCurveTo(s * 0.3, -s * 0.28, s * 0.3, 0); c.closePath(); c.fill(); c.stroke();
  c.beginPath(); c.moveTo(0, -s * 0.28); c.quadraticCurveTo(s * 0.04, -s * 0.38, s * 0.12, -s * 0.42); c.stroke();
}
function icShroom(c, s) {
  c.strokeStyle = '#5a0e08'; c.lineWidth = s * 0.05; c.fillStyle = '#fff2dc'; c.beginPath(); c.moveTo(-s * 0.12, s * 0.4); c.lineTo(-s * 0.1, 0); c.lineTo(s * 0.1, 0); c.lineTo(s * 0.13, s * 0.4); c.closePath(); c.fill(); c.stroke();
  const g = c.createRadialGradient(-s * 0.12, -s * 0.2, 0, 0, -s * 0.1, s * 0.4); g.addColorStop(0, '#ff8a6a'); g.addColorStop(1, '#c42a1e'); c.fillStyle = g;
  c.beginPath(); c.moveTo(-s * 0.4, s * 0.04); c.quadraticCurveTo(-s * 0.38, -s * 0.4, 0, -s * 0.4); c.quadraticCurveTo(s * 0.38, -s * 0.4, s * 0.4, s * 0.04); c.quadraticCurveTo(0, s * 0.12, -s * 0.4, s * 0.04); c.closePath(); c.fill(); c.stroke();
  c.fillStyle = '#ffffff'; [[-0.18, -0.16, 0.06], [0.08, -0.26, 0.05], [0.2, -0.08, 0.05]].forEach(([x, y, r]) => { c.beginPath(); c.arc(x * s, y * s, r * s, 0, TAU); c.fill(); });
}

const Cd = CM.MAT.candy, Mt = CM.MAT.metal, W = CM.MAT.wood, Ca = CM.MAT.card;
CM.register('forest', [forestStump, forestBirch, forestLog, forestGrove, forestFairy], {
  mat: {
    moss: Object.assign({}, Ca, { soft: 1.3, lean: 6, sag: 5, jag: 'ragged', edge: '#e8c890', crack: 'split', chips: ['#8a5a30', '#6a4024', '#7cc04a', '#e5483a', '#f2d09a'], deb: 'splinter', dust: '#e2dcc0', sfx: { m: 'moss', p: 1, x: ['leaf'] }, cav: ['#140a02', '#2a1a08'], glow: '#d8ff8a' }),
    birch: Object.assign({}, W, { chips: ['#ffffff', '#e8e2d0', '#3a3224', '#d8b070', '#7cc04a'], dust: '#efeadc', sfx: { m: 'hardwood', p: 1.05, x: ['leaf'] } }),
    oak: Object.assign({}, W, { chips: ['#dca468', '#8e5c2e', '#62391a', '#6a717e', '#5aa03a'], sfx: { m: 'hardwood', p: 0.9, x: ['iron', 'leaf'] } }),
    grove: Object.assign({}, Mt, { chips: ['#2a7a3c', '#5ac06e', '#ffd23a', '#e88a1a', '#3ad08a'], dust: '#dfeedc', sfx: { m: 'crystal', p: 0.85, x: ['leaf', 'goldx'] }, cav: ['#041408', '#0e2a14'], glow: '#c8ff8a' }),
    fairy: Object.assign({}, Cd, { sfx: { m: 'crystal', p: 1, x: ['rainbow', 'chime', 'leaf'] } }),
  },
  icons: { acorn: icAcorn, mushroom: icShroom },
});
}
(function go() { if (window.ChestModels && window.ChestModels.K) run(); else setTimeout(go, 30); })();
})();
