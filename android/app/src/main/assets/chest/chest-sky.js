// Sky & Stars chests for ChestModels: Cloud Puff Sack -> Stargazer Box -> Silver Moon Trunk -> Celestial Observatory Vault -> Rainbow Aurora Treasury.
(function () {
'use strict';
function run() {
const CM = window.ChestModels, H = CM.H, K = CM.K;
const { parse, poly, line, rect, ell, shift, spark4, star5, lg, rg, sh, st, tx, P3, mapD, onP, Box, cvx, boxFill, boxShade, corner3, surf, Barrel } = H;
const { PI, TAU, mixH, R2, lp, gl, sv, gemS, SILV, ball, vault, treasury, rbLid, pal, RBW, moonP, cloudB, cloudS } = K;
const STAR = '#ffe066';
const dash = (a, b, n, c, w) => { const o = []; for (let i = 0; i < n; i++) o.push(st(line([lp(a, b, (i + 0.2) / n), lp(a, b, (i + 0.7) / n)]), c, w)); return o; };
const starS = (x, y, s, c, ink) => sh(star5(x, y, s, s * 0.45), c || STAR, { s: ink || '#a87a00', w: 0.8 });
const cloudG = (x, y, s) => rg(x - s * 0.3, y - s * 0.3, s * 1.1, '#ffffff', '#f0f4ff', '#c4d0f8');

/* ---------- COMMON: cloud puff sack ---------- */
function skyCloud() {
  const ink = '#4a5aa8', BL = [[0, -52, 46, 42], [-36, -36, 26, 26], [38, -36, 26, 28], [-22, -16, 26, 16], [22, -16, 26, 16], [0, -18, 30, 18], [-16, -84, 24, 22], [16, -86, 22, 20]];
  const U0 = [].concat(...BL.map(b => ell(...b)));
  const body = BL.map(b => st(ell(...b), ink, 5)); [0, 6, 7, 1, 2, 5, 3, 4].forEach(i => { const [x, y, a, b] = BL[i], R = Math.max(a, b); body.push(sh(ell(x + a * 0.08, y + b * 0.12, a * 1.02, b * 1.02), 'rgba(60,70,170,0.2)', { clip: U0 }), sh(ell(x, y, a, b), rg(x - a * 0.38, y - b * 0.48, R * 1.55, [0, '#ffffff'], [0.35, '#f6f8ff'], [0.72, '#d2dcfa'], [1, '#9aa8e8'])), sh(ell(x - a * 0.36, y - b * 0.44, a * 0.26, b * 0.16), 'rgba(255,255,255,0.85)')); });
  body.push(sh(U0, lg(-62, 0, 64, 0, [0, 'rgba(255,255,255,0.25)'], [0.6, 'rgba(70,80,170,0)'], [1, 'rgba(70,80,170,0.22)'])), sh(U0, lg(0, -106, 0, 0, [0, 'rgba(255,255,255,0)'], [0.72, 'rgba(70,80,170,0)'], [1, 'rgba(70,80,170,0.22)'])));
  [['M-12 -4 Q-4 -10 2 -4'], ['M28 -54 Q34 -48 34 -40'], ['M-40 -58 Q-46 -50 -44 -42']].forEach(([d]) => body.push(st(parse(d), 'rgba(90,100,190,0.35)', 1.6)));
  [[-40, -60, 4], [34, -66, 3.5], [-32, -22, 3.2], [36, -20, 3.6], [-6, -86, 3], [48, -44, 2.6], [-50, -34, 2.6]].forEach(([x, y, s]) => body.push(starS(x, y, s, STAR, '#c89a20')));
  body.push(st(parse('M-20 -50 Q-15 -44 -10 -50'), '#2a2a5a', 2.4), st(parse('M10 -50 Q15 -44 20 -50'), '#2a2a5a', 2.4), sh(ell(-25, -41, 5, 3), 'rgba(255,140,170,0.5)'), sh(ell(25, -41, 5, 3), 'rgba(255,140,170,0.5)'), st(parse('M-5 -40 Q0 -35 5 -40'), '#2a2a5a', 2));
  body.push(sh(parse('M-13 -100 Q0 -104 13 -100 L9 -114 Q0 -116 -9 -114 Z'), lg(-13, 0, 13, 0, '#ffffff', '#d8e2fa'), { s: ink, w: 1.6 }), ...[-6, 0, 6].map(x => st(line([[x, -102], [x * 0.7, -113]]), 'rgba(90,100,190,0.4)', 1)));
  const top = [sh(parse('M-9 -114 Q-20 -118 -22 -128 Q-16 -124 -12 -130 Q-8 -124 -4 -132 Q0 -126 4 -132 Q8 -124 12 -130 Q16 -124 22 -128 Q20 -118 9 -114 Z'), lg(0, -132, 0, -114, '#ffffff', '#dce4fa'), { s: ink, w: 1.6 }),
    sh(rect(-13, -112, 26, 6, 3), lg(0, -112, 0, -106, '#fff2a0', '#ffc020'), { s: '#a87a00', w: 1.2 }), sh(parse('M0 -109 C-15 -121 -19 -101 0 -109 C15 -121 19 -101 0 -109 Z'), lg(-18, 0, 18, 0, '#ffe066', '#ffc020', '#ffe066'), { s: '#a87a00', w: 1.3 }),
    sh(parse('M-2 -108 L-8 -96 L-4 -97 L-2 -94 Z'), '#ffc020', { s: '#a87a00', w: 1 }), sh(parse('M2 -108 L8 -96 L4 -97 L2 -94 Z'), '#ffc020', { s: '#a87a00', w: 1 }), sh(ell(0, -109, 3, 2.6), '#ffe066', { s: '#a87a00', w: 1 })];
  const charm = [st(parse('M7 -106 Q13 -96 20 -86'), '#a87a00', 1.2), sh(star5(21, -79, 8, 3.6), gl(13, -87, 29, -71), { s: '#8a5a00', w: 1.3 }), sh(ell(19, -82, 1.6, 1), 'rgba(255,255,255,0.9)')];
  const mp = [], mo = moonP(-24, -26, 11); for (let i = 0; i < 12; i++) { const a = i / 12 * TAU; mp.push(st(line([[-31 + Math.cos(a) * 12.5, -26 + Math.sin(a) * 13.5], [-31 + Math.cos(a + 0.22) * 12.5, -26 + Math.sin(a + 0.22) * 13.5]]), 'rgba(255,255,255,0.9)', 1.2)); }
  const patch = [sh(ell(-31, -26, 14.5, 15.5), '#7a8ae0', { s: ink, w: 1.4 }), ...mp, sh(mo, lg(-38, -37, -24, -15, '#fff6c0', '#ffd23a'), { s: '#a87a00', w: 1 })];
  return { name: 'Cloud Puff Sack', mat: 'cloud', hp: 6, W: 112, H: 137, ko: 'halves',
    hull: cvx([].concat(...BL.map(([x, y, a, b]) => [[x - a, y], [x + a, y], [x, y - b], [x, y + b], [x - a * 0.7, y - b * 0.7], [x + a * 0.7, y - b * 0.7], [x - a * 0.7, y + b * 0.7], [x + a * 0.7, y + b * 0.7]]), [[-22, -128], [22, -128], [0, -132], [29, -72]])),
    parts: [{ id: 'body', sh: body }, { id: 'patch', sh: patch, tear: 0.6, hang: [-31, -41], loose: 0.3, hmax: 0.7, hdir: -1 }, { id: 'top', sh: top, launch: true, launchV: 380 }, { id: 'charm', sh: charm, tear: 0.34, hang: [7, -106], loose: 0, hmax: 0.5, hdir: 1 }],
    loot: ['star', 'coin', 'cloud', 'moon'] };
}

/* ---------- RARE: stargazer box ---------- */
function skyStargazer() {
  const ink = '#0e1650', B = Box(-66, -80, 48, 0, 36), L = Box(-69, -94, 51, -80, 39, -1.5);
  const NV = { f: ['#5a74e0', '#2e40b0', '#1a2680'], t: ['#7a94f4', '#4258c8'], s: ['#26348e', '#121c5e'] }, NL = { f: ['#6a84ea', '#3a4ec0', '#22308a'], t: ['#8aa2f6', '#4a62d0'], s: ['#2a3a9a', '#141e64'] };
  const body = [...boxFill(B, NV), sh(moonP(-30, -44, 20), lg(-56, -64, -30, -24, '#fff6c0', '#ffd23a', '#e8a400'), { s: '#a86e00', w: 1.6 }), st(parse('M-48 -48 Q-45 -44.5 -42 -48'), '#7a4800', 1.6), sh(ell(-47, -40, 2.6, 1.6), 'rgba(255,120,120,0.6)')];
  const cp = [[4, -68], [14, -60], [26, -64], [36, -52], [28, -38], [12, -34], [20, -20]]; body.push(st(line(cp), 'rgba(255,255,255,0.5)', 1));
  cp.forEach(([x, y], i) => body.push(sh(ell(x, y, 3.2), 'rgba(255,255,255,0.25)'), sh(ell(x, y, i % 3 ? 1.6 : 2.2), '#ffffff')));
  [[-58, -70, 3], [-10, -72, 2.6], [-20, -14, 3], [42, -10, 2.4], [-58, -12, 2.4], [-6, -40, 2]].forEach(([x, y, s]) => body.push(starS(x, y, s)));
  const pm = (d, a) => mapD(d, R2(18, -44, 1, a)), port = [sh(ell(18, -44, 12.5), sv(6, -56, 30, -32), { s: ink, w: 1.4 }), sh(ell(18, -44, 9.5), rg(16, -46, 12, '#1a2a7a', '#060a30')),
    st(pm(parse('M-10 0 C-10 -3.6 10 -3.6 10 0'), -0.35), '#ffd0a0', 1.6), sh(ell(18, -44, 5), rg(16.5, -45.5, 6, '#ffd8a0', '#ff8a3a', '#a8401a')), st(pm(parse('M-10 0 C-10 3.6 10 3.6 10 0'), -0.35), '#ffd0a0', 1.6), starS(12, -50, 1.6, '#ffffff', '#ffffff'), starS(24, -38, 1.4, '#ffffff', '#ffffff')];
  body.push(...onP(port.concat([starS(8, -16, 2.6), starS(28, -70, 2.4), starS(30, -14, 2)]), B.pS), ...boxShade(B, ink));
  const lid = [...boxFill(L, NL), ...onP([[-60, 8, 3], [-40, 26, 2.4], [-18, 10, 2.8], [6, 30, 2.2], [30, 12, 3], [42, 30, 2.4], [-52, 30, 2]].map(([x, y, s]) => starS(x, y, s)), L.pT)];
  for (let x = -62; x <= 46; x += 12) lid.push(starS(x, -87, 2.2, x % 24 ? STAR : '#ffffff'));
  lid.push(...boxShade(L, ink));
  const cs = [corner3(B, -1, 1, 16, 6, 1.5, SILV, '#3a4660'), corner3(B, 1, 1, 16, 6, 1.5, SILV, '#3a4660')];
  const tp = L.pT(-22, 22), apex = [tp[0], tp[1] - 24], tele = [sh(ell(tp[0], tp[1] + 1, 14, 3.5), 'rgba(0,0,30,0.3)')];
  [[-12, 4], [12, 3], [3, -5]].forEach(([dx, dy]) => tele.push(st(line([apex, [tp[0] + dx, tp[1] + dy]]), '#4a2e10', 3.2), st(line([apex, [tp[0] + dx, tp[1] + dy]]), '#c88a4a', 1.6)));
  const f = R2(apex[0], apex[1], 1, -0.45), M = d => mapD(d, f);
  tele.push(sh(M(rect(-24, -5, 46, 10, 3)), lg(...f(0, -5), ...f(0, 5), '#fff2c0', '#e8b84a', '#8a5a10'), { s: '#4a2e06', w: 1.3 }), sh(M(rect(-31, -3.5, 8, 7, 2)), '#3a3a4a', { s: '#1a1a24', w: 1 }), sh(M(rect(18, -7, 10, 14, 3)), lg(...f(0, -7), ...f(0, 7), '#fff2c0', '#c88a2a'), { s: '#4a2e06', w: 1.3 }),
    sh(M(ell(28, 0, 2.6, 6)), '#9fe0ff', { s: '#4a2e06', w: 1 }), st(M(line([[-20, -2.6], [16, -2.6]])), 'rgba(255,255,255,0.7)', 1.2), sh(ell(apex[0], apex[1], 3), gl(apex[0] - 3, apex[1] - 3, apex[0] + 3, apex[1] + 3), { s: '#4a2e06', w: 1 }), sh(spark4(...f(40, -6), 6), '#ffffff'));
  const tag = [st(parse('M32 -80 Q34 -73 35 -68'), '#c8d0e0', 1.2), sh(ell(35, -60, 8.5), lg(28, -68, 42, -52, '#ffffff', '#c8d4ec'), { s: ink, w: 1.3 }), sh(moonP(38, -60, 5.5), STAR, { s: '#a87a00', w: 0.8 }), sh(ell(35, -68, 1.4), ink)];
  const big = [st(star5(26, -18, 11, 5), '#ffffff', 5), sh(star5(26, -18, 11, 5), lg(16, -28, 36, -8, '#fff6c0', '#ffd23a', '#e8a400'), { s: '#a86e00', w: 1 }), sh(ell(23, -21, 2, 1.3), 'rgba(255,255,255,0.9)')];
  return { name: 'Stargazer Box', mat: 'starbox', hp: 8, W: 150, H: 140, ko: 'pie', pieN: 6,
    hull: cvx(B.pts.concat(L.pts, [f(30, -8), f(30, 8), f(-31, 0), [tp[0] - 12, tp[1] + 4]])),
    parts: [{ id: 'body', sh: body }, { id: 'c0', sh: cs[0].sh, tear: 0.42 }, { id: 'c1', sh: cs[1].sh, tear: 0.74 }, { id: 'lid', sh: lid, launch: true }, { id: 'big', sh: big, tear: 0.56, hang: [26, -29], loose: 0.25, hmax: 0.7, hdir: 1 },
      { id: 'tag', sh: tag, tear: 0.3, hang: [32, -80], loose: 0, hmax: 0.6, hdir: 1 }, { id: 'tele', sh: tele, launch: true, launchV: 420 }],
    loot: ['star', 'coin', 'moon', 'star', 'cloud'] };
}

/* ---------- EPIC: silver moon trunk ---------- */
function skyTrunk() {
  const ink = '#0a1040', B = Box(-84, -80, 54, 0, 40), xa = -88, xb = 58, yb = -80, dh = 28;
  const MN = { f: ['#4a5ad0', '#26338e', '#141c58'], t: ['#5a6ae0', '#2e3c9e'], s: ['#1e2a78', '#0c1240'] }, SC = 'rgba(200,215,255,0.65)';
  const body = [...boxFill(B, MN), ...dash([-80, -76], [50, -76], 22, SC, 1.1), ...dash([-80, -4], [50, -4], 22, SC, 1.1), ...dash([-80, -76], [-80, -4], 12, SC, 1.1), ...dash([50, -76], [50, -4], 12, SC, 1.1)];
  const dp = [[-46, -32], [-36, -24], [-26, -30], [-14, -24], [-4, -34], [8, -36], [10, -22]]; body.push(st(line(dp), 'rgba(220,230,255,0.55)', 1));
  dp.forEach(([x, y], i) => body.push(sh(ell(x, y, 3.4), 'rgba(255,255,255,0.22)'), sh(ell(x, y, i % 2 ? 1.6 : 2.2), '#ffffff')));
  [[-74, -66, 2.6], [-70, -18, 2.2], [42, -64, 2.2], [44, -16, 2.6], [-30, -60, 2], [12, -60, 2]].forEach(([x, y, s]) => body.push(starS(x, y, s)));
  body.push(...onP([...dash([4, -76], [36, -76], 6, SC, 1.1), ...dash([4, -4], [36, -4], 6, SC, 1.1), ...[0, 1, 2].map(k => st(line([[18 - k * 4, -50 + k * 3], [6 - k * 5, -30 + k * 6]]), ['rgba(255,240,180,0.8)', 'rgba(180,220,255,0.6)', 'rgba(255,200,240,0.5)'][k], 2.4 - k * 0.6)), sh(star5(20, -52, 7, 3), gl(13, -59, 27, -45), { s: '#a86e00', w: 1 })], B.pS));
  body.push(...boxShade(B, ink, { only: 'FS', k: 0.8 }));
  const Bl = Barrel(xa, xb, yb, dh, 21, -1), cu = surf(Bl.f3, 22, 12, (u, v, i, j) => (i + j) % 2 ? '#2a3a9e' : '#2e40a8', { c: [-15, -70, 20], dk: '#060a2a' }), lid = [...cu.sh];
  for (let k = 0; k < 34; k++) { const u = (k * 0.618) % 1, v = (k * 0.371 + 0.08) % 1, vi = cu.visAt(u, v); if (vi > 0.05) { const p = cu.P(u, v); lid.push(sh(spark4(p[0], p[1], 1.6 + (k % 3) * 0.8), k % 4 ? '#ffffff' : STAR)); } }
  [[[0.12, 0.3], [0.2, 0.46], [0.29, 0.38], [0.37, 0.56], [0.3, 0.7]], [[0.6, 0.28], [0.69, 0.42], [0.78, 0.36], [0.86, 0.52]]].forEach(ch => { const uv = []; for (let i = 0; i < ch.length - 1; i++) for (let t = 0; t <= 1; t += 0.1) uv.push([ch[i][0] + (ch[i + 1][0] - ch[i][0]) * t, ch[i][1] + (ch[i + 1][1] - ch[i][1]) * t]);
    cu.lineOn(uv, 0).forEach(p => lid.push(st(p, 'rgba(220,230,255,0.6)', 1))); ch.forEach(([u, v]) => { if (cu.visAt(u, v) > 0) { const p = cu.P(u, v); lid.push(sh(ell(p[0], p[1], 3.2), 'rgba(255,255,255,0.25)'), sh(ell(p[0], p[1], 1.9), '#ffffff')); } }); });
  lid.push(sh(Bl.cap, lg(...P3(xb, -108, 20), ...P3(xb, -80, 20), '#2a3a9a', '#141c58')), sh(star5(...P3(xb + 0.5, -90, 20), 6, 2.6), STAR), st(line(Bl.prof(xb, PI)), '#3a4660', 6), st(line(Bl.prof(xb, PI)), sv(0, -110, 0, -80), 3.8),
    st(line([P3(xa, yb, -1), P3(xb, yb, -1)]), '#3a4660', 6), st(line([P3(xa, yb, -1), P3(xb, yb, -1)]), sv(0, -83, 0, -77), 3.8));
  const strap = sx => { const u = (sx + 6 - xa) / (xb - xa), o = []; cu.lineOn(Array.from({ length: 13 }, (_, i) => [u, i / 24]), 0.04).forEach(p => o.push(st(p, '#3a4660', 13), st(p, sv(0, -108, 0, -80), 10.5)));
    o.push(sh(parse(`M${sx} -80 L${sx + 12} -80 L${sx + 12} -34 L${sx + 6} -28 L${sx} -34 Z`), sv(sx, 0, sx + 12, 0), { s: '#3a4660', w: 1.3 }), sh(rect(sx - 3, -60, 18, 15, 4), gl(sx - 3, -60, sx + 15, -45), { s: '#6a4200', w: 1.3 }), sh(star5(sx + 6, -52.5, 5.5, 2.4), '#fff6c0', { s: '#a86e00', w: 0.8 })); return o; };
  const cs = [corner3(B, -1, 1, 18, 6, 1.5, SILV, '#3a4660'), corner3(B, 1, 1, 18, 6, 1.5, SILV, '#3a4660')];
  const lock = [sh(rect(-21, -90, 12, 16, 4), sv(-21, 0, -9, 0), { s: '#3a4660', w: 1.3 }), sh(moonP(-8, -64, 13), lg(-26, -78, -8, -50, '#fff6c0', '#ffd23a', '#c88a00'), { s: '#7a4800', w: 1.5 }), st(parse('M-22 -66 Q-19.5 -63 -17 -66'), '#7a4800', 1.4), sh(ell(-20, -60, 2, 1.2), 'rgba(255,120,120,0.6)'),
    st(line([[-8, -51], [-8, -44]]), '#c8d0e0', 1), sh(star5(-8, -40, 4.5, 2), gl(-12, -44, -4, -36), { s: '#7a4800', w: 0.8 })];
  const clouds = [...cloudS(-80, -6, 26, cloudG(-80, -10, 26), '#4a5aa8', 3), ...cloudS(56, -4, 22, cloudG(56, -8, 22), '#4a5aa8', 3)];
  return { name: 'Silver Moon Trunk', mat: 'moontrunk', hp: 10, W: 180, H: 150, ko: 'pie', pieN: 6,
    hull: cvx(B.pts.concat(Bl.pts, [[-96, 4], [-92, -16], [68, -14], [70, 4]])),
    parts: [{ id: 'body', sh: body }, { id: 'c0', sh: cs[0].sh, tear: 0.44 }, { id: 'c1', sh: cs[1].sh, tear: 0.66 }, { id: 'lid', sh: lid, launch: true },
      { id: 'sL', sh: strap(-62), tear: 0.5, hang: [-56, -80], loose: 0.28, hmax: 0.5, hdir: -1 }, { id: 'sR', sh: strap(24), tear: 0.76, hang: [30, -80], loose: 0.5, hmax: 0.5, hdir: 1 },
      { id: 'lock', sh: lock, tear: 0.92, hang: [-15, -88], loose: 0.7, hmax: 0.5, hdir: 1 }, { id: 'clouds', sh: clouds, tear: 0.3 }],
    loot: ['moon', 'coin', 'star', 'cloud', 'coin', 'star'] };
}

/* ---------- LEGENDARY: celestial observatory vault ---------- */
function skyObserv() {
  const ink = '#0a1040', gi = '#6a4200';
  const chart = (x, y, r) => { const P = [[-0.5, -0.3], [-0.15, -0.5], [0.2, -0.2], [0.45, 0.2], [0.05, 0.45], [-0.35, 0.3]].map(([a, b]) => [x + a * r, y + b * r]), o = [sh(ell(x, y, r), rg(x - 3, y - 3, r * 1.4, '#2a3a9a', '#0e1450')), st(line(P), 'rgba(255,240,180,0.6)', 0.9)];
    P.forEach(([a, b], i) => o.push(sh(ell(a, b, i % 2 ? 1.2 : 1.7), '#ffffff'))); for (let i = 0; i < 12; i++) { const t = i / 12 * TAU; o.push(st(line([[x + Math.cos(t) * (r - 2.5), y + Math.sin(t) * (r - 2.5)], [x + Math.cos(t) * (r - 0.5), y + Math.sin(t) * (r - 0.5)]]), 'rgba(255,230,150,0.8)', 1)); }
    o.push(st(ell(x, y, r), gi, 4.4), st(ell(x, y, r), gl(x - r, y - r, x + r, y + r), 2.6)); return o; };
  const ring = (x, y, half) => mapD(parse(half ? 'M-14 0 C-14 4.6 14 4.6 14 0' : 'M-14 0 C-14 -4.6 14 -4.6 14 0'), R2(x, y, 1, -0.3));
  return vault({ name: 'Celestial Observatory Vault', mat: 'observ', ink, gi, C: { f: ['#6a88f0', '#2e48b8', '#14206e'], t: ['#88a4f8', '#4462d0'], s: ['#2a3aa0', '#101a5a'] },
    front: () => [...chart(-69, -66, 14), ...chart(35, -66, 14), ...[-80, -60, 28, 48].map(x => sh(star5(x, -18, 6, 2.6), gl(x - 6, -24, x + 6, -12), { s: gi, w: 1 }))],
    side: () => chart(21, -66, 12), band: [-46, 12, '#fff6c0', '#ffd23a', '#a86e00'], gems: ['#9fd8ff', '#ffffff'],
    lid: 'dome', dh: 46, dk2: 0.62, dk: '#2a3060', lidCol: (u, w) => (u > 0.42 && u < 0.58 && w > 0.06) ? '#141a48' : (Math.floor(u * 10) % 2 ? '#eef2fa' : '#dfe6f4'),
    lidDeco: ({ cu }) => { const o = []; for (let k = 1; k < 10; k++) cu.lineOn(Array.from({ length: 13 }, (_, i) => [k / 10, i / 12]), 0).forEach(p => o.push(st(p, 'rgba(80,90,140,0.45)', 1)));
      [0.42, 0.58].forEach(u => cu.lineOn(Array.from({ length: 11 }, (_, i) => [u, 0.06 + 0.94 * i / 10]), 0).forEach(p => o.push(st(p, gi, 3.2), st(p, gl(0, -140, 0, -90), 1.8))));
      for (let k = 0; k < 6; k++) { const v = 0.3 + k * 0.11; if (cu.visAt(0.5, v) > 0) { const p = cu.P(0.5, v); o.push(sh(spark4(p[0], p[1], 1.6 + (k % 2)), '#ffffff')); } } return o; },
    crest: T => { const f = R2(T[0], T[1] + 4, 1, -0.95), M = d => mapD(d, f); return [sh(M(rect(-6, -7, 44, 14, 4)), lg(...f(0, -7), ...f(0, 7), '#fff6c0', '#ffd23a', '#a86e00'), { s: gi, w: 1.4 }), sh(M(rect(8, -8.5, 4, 17, 1)), '#a86e00'), sh(M(rect(30, -9, 12, 18, 4)), lg(...f(0, -9), ...f(0, 9), '#fff6c0', '#c88a00'), { s: gi, w: 1.4 }),
      sh(M(ell(42, 0, 3, 8)), '#9fe0ff', { s: gi, w: 1 }), st(M(line([[0, -4], [30, -4]])), 'rgba(255,255,255,0.75)', 1.4), sh(spark4(...f(56, -6), 7), '#ffffff'), sh(star5(...f(50, 12), 4, 1.8), STAR)]; }, crestH: 56,
    corner: (x, y) => [st(ring(x, y), gi, 3.4), st(ring(x, y), '#ffe066', 1.8), ...ball(x, y, 8, gi, ['#ffe8c0', '#ff9a3a', '#a8401a']), st(ring(x, y, 1), gi, 3.4), st(ring(x, y, 1), '#ffe066', 1.8)],
    med: cx => [st(line([[cx, -40], [cx, -36]]), gi, 2.2), sh(star5(cx, -20, 18, 12), gl(cx - 18, -38, cx + 18, -2), { s: gi, w: 1.4 }), sh(ell(cx, -20, 11), rg(cx - 3, -23, 13, '#fff6c0', '#ffd23a', '#e88a00'), { s: gi, w: 1.6 }),
      st(parse(`M${cx - 6} -22 Q${cx - 4} -19.5 ${cx - 2} -22 M${cx + 2} -22 Q${cx + 4} -19.5 ${cx + 6} -22`), '#7a4800', 1.4), st(parse(`M${cx - 4} -16 Q${cx} -12.5 ${cx + 4} -16`), '#7a4800', 1.4), sh(ell(cx - 5, -25, 2.4, 1.5), 'rgba(255,255,255,0.85)')],
    loot: ['moon', 'coin', 'gem', 'star', 'cloud', 'star'] });
}

/* ---------- RAINBOW: aurora treasury ---------- */
function skyAurora() {
  const ik = '#8a5200', BU = [[0.14, 0.32], [0.32, 0.26], [0.5, 0.34], [0.68, 0.26], [0.86, 0.32], [0.24, 0.68], [0.44, 0.72], [0.62, 0.66], [0.8, 0.7]];
  return treasury({ name: 'Rainbow Aurora Treasury', mat: 'aurora',
    art: [(x, y, s) => cloudS(x, y + 4, s * 0.62, RBW(x, y), ik, 2.4), (x, y, s) => [sh(star5(x, y + 2, s * 0.42, s * 0.19), RBW(x, y), { s: ik, w: 2 })], (x, y, s) => [sh(moonP(x + s * 0.18, y, s * 0.36), RBW(x, y), { s: ik, w: 2 })], (x, y, s) => [sh(star5(x, y, s * 0.36, s * 0.16), RBW(x, y), { s: ik, w: 2 })]],
    lid: ink => rbLid(ink, (u, w) => mixH(pal(u), '#ffffff', 0.5), { h: 26, k: 0.4, hf: (u, w, hh) => { let b = 0; BU.forEach(([a, c]) => { b += 15 * Math.exp(-((u - a) * (u - a) / 0.006 + (w - c) * (w - c) / 0.03)); }); return hh + b * Math.pow(Math.sin(PI * u) * Math.sin(PI * w), 0.6); },
      deco: cu => { const o = []; [[0.2, 0.5], [0.56, 0.5], [0.76, 0.48], [0.38, 0.86]].forEach(([u, w], i) => { if (cu.visAt(u, w) > 0) { const p = cu.P(u, w); o.push(sh(spark4(p[0], p[1] - 4, 4 + i % 2 * 2), '#ffffff')); } }); return o; } }),
    crest: (T, ink) => [...[['#ff6fae', 0], ['#ffd23a', 5], ['#3ac8e8', 10]].map(([c, d]) => st(parse(`M${T[0] - 8} ${T[1] - 22 + d * 0.3} Q${T[0] - 26} ${T[1] - 12 + d} ${T[0] - 44} ${T[1] + d}`), c, 5)),
      sh(ell(T[0], T[1] + 2, 14, 4), 'rgba(60,0,80,0.3)'), sh(star5(T[0], T[1] - 22, 20, 9), gl(T[0] - 20, T[1] - 42, T[0] + 20, T[1] - 4), { s: '#7a4800', w: 1.8 }), ...gemS(T[0], T[1] - 22, 5, '#3aa8ff', ink), st(line([[T[0] - 6, T[1] - 34], [T[0] - 12, T[1] - 26]]), 'rgba(255,255,255,0.75)', 1.4)],
    lock: (x, ink) => [sh(rect(x - 5, -97, 10, 16, 4), gl(x - 5, 0, x + 5, 0), { s: ink, w: 1.3 }), sh(moonP(x + 9, -64, 20), gl(x - 18, -84, x + 9, -44), { s: '#7a4800', w: 2 }), sh(ell(x - 2, -64, 6, 7), RBW(x - 2, -64, 1.4), { s: '#7a4800', w: 1.1 }), sh(ell(x - 4, -66.5, 2, 1.4), 'rgba(255,255,255,0.9)'), sh(ell(x - 2, -54, 1.5), '#4a2600')],
    loot: ['star', 'gem', 'moon', 'cloud', 'star', 'coin'] });
}

const Cd = CM.MAT.candy, Mt = CM.MAT.metal, W = CM.MAT.wood;
CM.register('sky', [skyCloud, skyStargazer, skyTrunk, skyObserv, skyAurora], {
  mat: {
    cloud: { soft: 2, lean: 7, sag: 6, dentK: 7, dentShade: 0.22, holeFrom: 0.2, holeP: 0.75, holeR: [15, 22], jag: 'tear', edge: '#ffffff', edgeW: 7, crack: 'rip', chips: ['#ffffff', '#dfe8ff', '#b8c8f8', '#ffe066'], deb: 'fluff', deb2: 'drop', dropC: '#7ac8ff', dust: '#f4f8ff', mass: 0.7, sfx: { m: 'puff', p: 0.95, x: ['water'] }, rest: 0.12, flutter: 0.8, cav: ['#141a3a', '#2a3468'], glow: '#bfe4ff' },
    starbox: Object.assign({}, W, { chips: ['#2e40b0', '#5a74e0', '#ffe066', '#ffffff', '#c9d3e0'], dust: '#e4e8f8', sfx: { m: 'puff', p: 1.1, x: ['chime'] }, cav: ['#060a24', '#141c48'], glow: '#bfe4ff' }),
    moontrunk: { soft: 0.8, lean: 5, sag: 4, dentK: 7, dentShade: 0.32, holeFrom: 0.3, holeP: 0.6, holeR: [15, 21], jag: 'tear', edge: '#c8d4ff', edgeW: 6, crack: 'rip', chips: ['#26338e', '#4a5ad0', '#dfe6f0', '#ffe066', '#ffffff'], deb: 'fluff', deb2: 'chip', dust: '#e8ecff', mass: 1.1, sfx: { m: 'puff', p: 1.05, x: ['silver'] }, rest: 0.18, flutter: 0.2, cav: ['#04061e', '#10163e'], glow: '#c8e4ff' },
    observ: Object.assign({}, Mt, { chips: ['#2e48b8', '#ffd23a', '#eef2fa', '#9fd8ff', '#ffffff'], dust: '#e6e8f6', sfx: { m: 'gold', p: 1.15, x: ['chime'] }, cav: ['#04061e', '#10163e'], glow: '#ffe8a0' }),
    aurora: Object.assign({}, Cd, { deb2: 'fluff', sfx: { m: 'crystal', p: 1.2, x: ['rainbow', 'chime'] } }),
  },
});
}
(function go() { if (window.ChestModels && window.ChestModels.K) run(); else setTimeout(go, 30); })();
})();
