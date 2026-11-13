// Ocean Pals chests for ChestModels: Sand Bucket -> Beach Cooler -> Sea Chest -> Brass Diving Vault -> Pearl Clam Treasury.
(function () {
'use strict';
function run() {
const CM = window.ChestModels;
const { parse, poly, line, rect, ell, shift, spark4, star5, lg, rg, cg, sh, st, tx, P3, mapD, mp, mlg, onP, FR, Box, cvx, boxFill, boxShade, corner3, plankS, surf, Barrel, RB, nail } = CM.H;
const PI = Math.PI, TAU = PI * 2;
const R2 = (cx, cy, s, a) => { const c = Math.cos(a || 0), n = Math.sin(a || 0); return (x, y) => [cx + (x * c - y * n) * s, cy + (x * n + y * c) * s]; };
const U = (d, f) => mapD(parse(d), f);
const mixH = (a, b, k) => { const A = parseInt(a.slice(1), 16), B = parseInt(b.slice(1), 16), c = s => Math.round(((A >> s) & 255) * (1 - k) + ((B >> s) & 255) * k); return '#' + ((1 << 24) | (c(16) << 16) | (c(8) << 8) | c(0)).toString(16).slice(1); };
const gemS = (x, y, r, c, ink) => [sh(ell(x, y, r), rg(x - r * 0.35, y - r * 0.4, r * 1.4, '#ffffff', c, mixH(c, '#20002a', 0.45)), { s: ink || '#5a3a00', w: 1 }), sh(ell(x - r * 0.35, y - r * 0.4, r * 0.3, r * 0.2), 'rgba(255,255,255,0.9)')];
const gl = (x0, y0, x1, y1) => lg(x0, y0, x1, y1, '#fff6c0', '#ffd23a', '#e8a400', '#a86e00');
const brass = (x0, y0, x1, y1) => lg(x0, y0, x1, y1, '#fff2c0', '#e8b84a', '#b07c1c', '#6a4608');
const iron = (x0, y0, x1, y1) => lg(x0, y0, x1, y1, '#8a929c', '#5a6068', '#2e3238');
const clipAll = (shapes, c) => shapes.map(s => Object.assign({}, s, { clip: c }));
const dome = (x, y, r, C) => sh(ell(x, y, r), rg(x - r * 0.35, y - r * 0.4, r * 1.3, C[0], C[1], C[2]));

/* ---------- ocean art ---------- */
function starfish(cx, cy, r, a, C) {
  C = C || ['#ffb070', '#ff7a3a', '#c8461a', '#8a2a0a']; const f = R2(cx, cy, r, a), pts = Array.from({ length: 10 }, (_, i) => { const an = -PI / 2 + i * PI / 5, k = i % 2 ? 0.44 : 1; return f(Math.cos(an) * k, Math.sin(an) * k); }), p = f(-0.2, -0.25);
  const out = [sh(poly(pts), rg(p[0], p[1], r * 1.2, C[0], C[1], C[2]), { s: C[3], w: Math.max(1, r * 0.12) })];
  for (let i = 0; i < 5; i++) { const an = -PI / 2 + i * TAU / 5; [0.35, 0.6].forEach(k => { const q = f(Math.cos(an) * k, Math.sin(an) * k); out.push(sh(ell(q[0], q[1], r * 0.07), 'rgba(255,240,210,0.85)')); }); }
  out.push(sh(ell(...f(0, 0), r * 0.1), 'rgba(255,240,210,0.85)'));
  return out;
}
function shellArt(cx, cy, s, a, C) {
  C = C || ['#fff0f6', '#ffb8d8', '#e0789e', '#9a3a62']; const f = R2(cx, cy, s, a), N = 7, edge = [];
  for (let i = 0; i <= N * 2; i++) { const an = PI + 0.35 + (PI - 0.7) * i / (N * 2), k = i % 2 ? 1.0 : 0.9; edge.push(f(Math.cos(an) * k, 0.45 + Math.sin(an) * k)); }
  const body = poly([f(0, 0.5)].concat(edge)), p = f(-0.2, -0.2), out = [sh(poly([f(-0.32, 0.38), f(0.32, 0.38), f(0.22, 0.62), f(-0.22, 0.62)]), C[2], { s: C[3], w: 0.9 }), sh(body, rg(p[0], p[1], s * 1.2, C[0], C[1], C[2]), { s: C[3], w: Math.max(0.9, s * 0.07) })];
  for (let i = 1; i < N * 2; i += 2) out.push(st(line([f(0, 0.5), edge[i]]), 'rgba(140,50,90,0.4)', Math.max(0.7, s * 0.05)));
  out.push(sh(ell(...f(-0.3, -0.05), s * 0.12, s * 0.2), 'rgba(255,255,255,0.55)'));
  return out;
}
function fishArt(cx, cy, s, C, flip) {
  C = C || ['#fff3a0', '#ffc81a', '#d88a00', '#8a5200']; const d = flip ? -1 : 1, f = (x, y) => [cx + x * s * d, cy + y * s], out = [];
  out.push(sh(poly([f(-0.7, 0), f(-1.25, -0.42), f(-1.15, 0), f(-1.25, 0.42)]), C[2], { s: C[3], w: 0.9 }));
  out.push(sh(mapD(ell(0, 0, 0.82, 0.5), (x, y) => f(x, y)), rg(...f(-0.15, -0.2), s * 0.9, C[0], C[1], C[2]), { s: C[3], w: Math.max(0.9, s * 0.08) }));
  out.push(st(line([f(-0.15, -0.45), f(0, 0), f(-0.15, 0.45)]), 'rgba(255,255,255,0.6)', Math.max(0.8, s * 0.06)));
  out.push(sh(ell(...f(0.42, -0.1), s * 0.14), '#ffffff'), sh(ell(...f(0.46, -0.1), s * 0.08), '#1a1a2a'));
  return out;
}
const pearl = (x, y, r) => [sh(ell(x + r * 0.15, y + r * 0.2, r), 'rgba(40,20,60,0.25)'), sh(ell(x, y, r), rg(x - r * 0.35, y - r * 0.4, r * 1.5, '#ffffff', '#fbe8f4', '#d8c4e8', '#9a84b8')), sh(ell(x, y, r), cg(x, y, 0, 0.8, 'rgba(255,170,220,0.25)', 'rgba(170,230,255,0.25)', 'rgba(255,240,170,0.25)', 'rgba(255,170,220,0.25)')), sh(ell(x - r * 0.35, y - r * 0.38, r * 0.3, r * 0.2), 'rgba(255,255,255,0.95)')];
const bubble = (x, y, r) => [st(ell(x, y, r), 'rgba(255,255,255,0.85)', 1.2), sh(ell(x - r * 0.35, y - r * 0.35, r * 0.25), 'rgba(255,255,255,0.9)')];
function coral(cx, by, s, c) {
  const d = 'M0 0 L0 -1.2 M0 -0.45 Q-0.55 -0.75 -0.65 -1.4 M0 -0.65 Q0.55 -0.85 0.6 -1.55 M-0.35 -0.95 Q-0.1 -1.3 -0.25 -1.8 M0.32 -1.1 Q0.12 -1.5 0.26 -1.95 M0 -1.2 L0.02 -1.75', f = R2(cx, by, s);
  return [st(U(d, f), '#6a1a2a', s * 0.34), st(U(d, f), c || '#ff7a9a', s * 0.24), st(shift(U(d, f), -s * 0.05, -s * 0.03), 'rgba(255,255,255,0.4)', s * 0.07)];
}

/* ---------- COMMON: plastic sand bucket ---------- */
function oceanBucket() {
  const ink = '#0e4a6a', yT = -92, r0 = 36, r1 = 48, e = 0.26, rY = y => r0 + (r1 - r0) * (-y / 92);
  const arcF = (y, r, n, w) => Array.from({ length: n + 1 }, (_, i) => { const t = PI - PI * i / n; return [Math.cos(t) * r, y + Math.sin(t) * r * e - (w ? w(t) : 0)]; });
  const arcB = (y, r, n) => Array.from({ length: n + 1 }, (_, i) => { const t = -PI * i / n; return [Math.cos(t) * r, y + Math.sin(t) * r * e]; });
  const bodyP = poly(arcF(0, r0, 24).concat(arcF(yT, r1, 24).reverse())), band = (ya, yb) => poly(arcF(ya, rY(ya), 20).concat(arcF(yb, rY(yb), 20).reverse()));
  const topE = ell(0, yT, r1, r1 * e), sandE = ell(0, yT + 5, r1 - 3, (r1 - 3) * e);
  const base = [sh(topE, lg(0, yT - 13, 0, yT + 13, '#0e5a7e', '#4ac0dc')), sh(sandE, lg(-40, yT, 40, yT + 10, '#fff4cc', '#f2d488', '#d8b060'), { clip: topE })];
  for (let i = 0; i < 26; i++) { const a = i * 2.39, r = Math.sqrt((i + 0.5) / 26) * 40; base.push(sh(ell(Math.cos(a) * r, yT + 5 + Math.sin(a) * r * e * 0.9, 0.9), i % 2 ? 'rgba(160,110,40,0.5)' : 'rgba(255,255,255,0.7)', { clip: topE })); }
  base.push(st(line(arcB(yT, r1, 24)), '#c89a10', 6), st(line(arcB(yT, r1, 24)), '#ffd23a', 3.6), st(line(arcB(yT, r1 - 1, 24)), 'rgba(255,255,255,0.6)', 1));
  const cs = 'M-26 -86 L-26 -112 L-23 -112 L-23 -109 L-20 -109 L-20 -112 L-17 -112 L-17 -109 L-14 -109 L-14 -112 L-12 -112 L-12 -98 L2 -98 L2 -112 L4 -112 L4 -109 L7 -109 L7 -112 L10 -112 L10 -109 L13 -109 L13 -112 L16 -112 L16 -86 Q-5 -82 -26 -86 Z';
  const castle = [sh(parse(cs), lg(-26, 0, 16, 0, '#fff0c0', '#f2cc7a', '#c8963e'), { s: '#9a6a28', w: 1.6 }), sh(parse('M-11 -98 L1 -98 L1 -104 L-0.5 -104 L-0.5 -101.5 L-3.5 -101.5 L-3.5 -104 L-8.5 -104 L-8.5 -101.5 L-11 -101.5 Z'), '#e6bc6a', { s: '#9a6a28', w: 1.2 }),
    sh(parse('M-9 -86 L-9 -92 Q-5 -97 -1 -92 L-1 -86 Z'), '#6a4a1a'), sh(ell(-19, -101, 1.6, 2.4), '#8a5a20'), sh(ell(9, -101, 1.6, 2.4), '#8a5a20'),
    st(line([[13, -112], [13, -126]]), '#6a4a1a', 1.4), sh(poly([[13, -126], [22, -122.5], [13, -119]]), '#e5303a', { s: '#8a1a14', w: 0.9 }),
    ...[[-24, -94], [-6, -105], [12, -92], [-16, -90]].map(([x, y]) => sh(ell(x, y, 0.9), 'rgba(140,90,30,0.6)'))];
  const S0 = [26, yT + 3], S1 = [42, yT - 40], shovel = [sh(poly([[S0[0] - 7, S0[1] + 1], [S0[0] + 7, S0[1] - 2], [S0[0] + 4, S0[1] - 7], [S0[0] - 4, S0[1] - 5]]), '#ff5a4a', { s: '#8a1a14', w: 1.2 }),
    st(line([S0, S1]), '#8a1a14', 6), st(line([S0, S1]), '#ff5a4a', 4), st(line([[S1[0] - 7, S1[1] + 2.5], [S1[0] + 7, S1[1] - 2.5]]), '#8a1a14', 6.5), st(line([[S1[0] - 7, S1[1] + 2.5], [S1[0] + 7, S1[1] - 2.5]]), '#ff5a4a', 4.4), st(line([[S0[0] - 0.8, S0[1] - 4], [S1[0] - 1.6, S1[1] + 2]]), 'rgba(255,255,255,0.55)', 1.1)];
  const body = [sh(bodyP, lg(-r1, 0, r1, 0, [0, '#c8f6ff'], [0.3, '#6adcf2'], [0.7, '#2ab0d8'], [1, '#1480a8'])), sh(band(-7, 0), 'rgba(10,60,100,0.25)')];
  const wv = t => 2.6 * Math.abs(Math.sin(t * 6)), wb = poly(arcF(-30, rY(-30), 40, wv).concat(arcF(-22, rY(-22), 20).reverse()));
  body.push(sh(wb, '#ffffff', { a: 0.95 }), st(line(arcF(-21, rY(-21), 20)), '#ffd23a', 2.2), st(line(arcF(-34, rY(-34), 30, wv)), 'rgba(255,255,255,0.6)', 1.2));
  body.push(sh(ell(-30, -54, 8, 24), rg(-30, -54, 24, 'rgba(255,255,255,0.4)', 'rgba(255,255,255,0)')), st(bodyP, ink, 2.6), st(line(arcF(yT, r1, 30)), '#a87a00', 7.5), st(line(arcF(yT, r1, 30)), '#ffd23a', 5), st(line(arcF(yT - 1.4, r1 - 1, 30)), 'rgba(255,255,255,0.7)', 1.3));
  const sk1 = [sh(ell(-20, -60, 15), '#ffffff', { s: 'rgba(14,74,106,0.4)', w: 1 }), ...starfish(-20, -60, 12, -0.2)];
  const sk2 = [sh(ell(23, -56, 12), '#ffffff', { s: 'rgba(14,74,106,0.4)', w: 1 }), ...shellArt(23, -57, 10, 0.1)];
  const bail = parse('M-49 -84 Q0 -14 49 -84'), handle = [st(bail, '#8a6a00', 5.4), st(bail, '#ffd23a', 3.4), st(shift(bail, 0, -1), 'rgba(255,255,255,0.6)', 1), sh(ell(-49, -84, 3.6), '#ffd23a', { s: '#8a6a00', w: 1.2 }), sh(ell(49, -84, 3.6), '#ffd23a', { s: '#8a6a00', w: 1.2 })];
  return { name: 'Sand Bucket', mat: 'beachplastic', hp: 6, W: 112, H: 137, ko: 'halves',
    hull: cvx(arcF(0, r0, 12).concat(arcB(yT, r1, 12), [[-26, -114], [22, -128], [S1[0] + 8, S1[1] - 4]])),
    parts: [{ id: 'base', sh: base }, { id: 'castle', sh: castle, launch: true, launchV: 400 }, { id: 'shovel', sh: shovel, tear: 0.44, hang: S0, loose: 0.1, hmax: 0.6, hdir: 1, launch: true },
      { id: 'body', sh: body }, { id: 'sk1', sh: sk1, tear: 0.3, hang: [-32, -70], loose: 0.05, hmax: 0.7, hdir: -1 }, { id: 'sk2', sh: sk2, tear: 0.54, hang: [33, -64], loose: 0.25, hmax: 0.7, hdir: 1 },
      { id: 'handle', sh: handle, tear: 0.66, hang: [-49, -84], loose: 0.3, hmax: 0.6, hdir: -1 }],
    loot: ['shell', 'coin', 'star', 'pearl'] };
}

/* ---------- RARE: beach cooler ---------- */
function oceanCooler() {
  const ink = '#0e3a5a', B = Box(-66, -70, 48, 0, 36), L = Box(-68, -90, 50, -70, 38), S = d => B.side(d);
  const body = boxFill(B, { f: ['#8aeaff', '#2ab4dc', '#1480a8'], t: ['#9aeaff', '#4ac4e4'], s: ['#1a8ab4', '#0e5a7e'] });
  const wave = (x0, x1) => { const p = [[x0, -8]]; for (let x = x0; x <= x1; x += 2) p.push([x, -19 - 3.2 * Math.abs(Math.sin(x * 0.16))]); p.push([x1, -8]); return poly(p); };
  body.push(sh(wave(-66, 48), '#ffffff', { a: 0.95 }), ...onP([sh(wave(0, 36), '#e2f2fa')], B.pS), st(line([[-66, -7], [48, -7]]), '#ffd23a', 2), sh(rect(-66, -6, 114, 6), 'rgba(10,50,80,0.3)'));
  body.push(...onP([sh(rect(8, -54, 20, 11, 5.5), '#0e4a6a'), sh(rect(8, -54, 20, 4, 2), 'rgba(0,0,0,0.35)'), st(line([[11, -45], [25, -45]]), 'rgba(255,255,255,0.4)', 1)], B.pS));
  [-62, 26].forEach(x => body.push(sh(rect(x, -3, 18, 5, 2), '#2a3a48', { s: '#0e1a24', w: 1 })));
  body.push(sh(ell(-50, -54, 10, 14), rg(-50, -54, 16, 'rgba(255,255,255,0.32)', 'rgba(255,255,255,0)')), ...boxShade(B, ink, { only: 'FS' }));
  const lid = boxFill(L, { f: ['#ffffff', '#eef4f8', '#c8d6e0'], t: ['#ffffff', '#eef3f7'], s: ['#c4d2dc', '#94a8b8'] });
  lid.push(...onP([sh(ell(-46, 13, 8, 7), '#c8d6e0', { s: '#8aa0b0', w: 1 }), sh(ell(-46, 13, 5.6, 4.8), '#9ab0c0'), sh(ell(30, 13, 8, 7), '#c8d6e0', { s: '#8aa0b0', w: 1 }), sh(ell(30, 13, 5.6, 4.8), '#9ab0c0')], L.pT));
  lid.push(sh(rect(-68, -74, 118, 4), '#2ab4dc'), tx('SQUISH COOL', -9, -81, '700 9px Fredoka, Nunito, sans-serif', '#2ab4dc'), ...boxShade(L, ink, { k: 0.8 }));
  const hx0 = L.x0 - 3, hx1 = L.x1 + 3, A = P3(hx1, -80, 19), Bp = P3(hx1, -93, 33), C = P3(hx0, -93, 33), D = P3(hx0, -80, 19), hpts = [D, C, Bp, A];
  const handle = [st(line(hpts), ink, 7), st(line(hpts), '#ffffff', 4.4), st(shift(line([C, Bp]), 0, -1.3), 'rgba(255,255,255,0.9)', 1.2), st(line([C, Bp]), 'rgba(140,170,190,0.6)', 1, {}),
    sh(ell(A[0], A[1], 4.4, 3.6), '#9ab0c0', { s: ink, w: 1.2 }), sh(ell(D[0], D[1], 4.4, 3.6), '#9ab0c0', { s: ink, w: 1.2 })];
  const latch = [sh(rect(-16, -76, 14, 16, 3), lg(-16, -76, -2, -60, '#fff07a', '#ffd23a', '#d89a00'), { s: '#7a5200', w: 1.4 }), sh(rect(-13, -66, 8, 3, 1.5), 'rgba(122,82,0,0.5)'), sh(ell(-9, -73, 1.5), '#7a5200')];
  const sk1 = [sh(ell(-38, -44, 14), '#ffffff', { s: 'rgba(14,58,90,0.5)', w: 1.2 }), sh(ell(-38, -44, 11.5), '#ffe8a0'), ...fishArt(-37, -44, 8)];
  const sk2 = [sh(star5(24, -44, 14, 8), '#ff7ab8', { s: '#9a1a5a', w: 1.4 }), tx('SURF', 24, -43, '700 7px Fredoka, Nunito, sans-serif', '#ffffff')];
  const plug = [sh(ell(-55, -30, 5.4), '#0e2a3a'), sh(ell(-55, -30, 3.8), lg(-58, -33, -52, -27, '#fff07a', '#e8a800'), { s: '#7a5200', w: 0.9 })];
  return { name: 'Beach Cooler', mat: 'cooler', hp: 8, W: 150, H: 140, ko: 'pie', pieN: 6,
    hull: cvx(B.pts.concat(L.pts, hpts)),
    parts: [{ id: 'body', sh: body }, { id: 'plug', sh: plug, tear: 0.86 }, { id: 'lid', sh: lid, launch: true }, { id: 'latch', sh: latch, tear: 0.42 },
      { id: 'sk1', sh: sk1, tear: 0.3, hang: [-50, -55], loose: 0.05, hmax: 0.8, hdir: -1 }, { id: 'sk2', sh: sk2, tear: 0.54, hang: [12, -55], loose: 0.2, hmax: 0.7, hdir: 1 },
      { id: 'handle', sh: handle, tear: 0.62, hang: D, loose: 0.3, hmax: 0.5, hdir: -1, launch: true }],
    loot: ['fish', 'coin', 'shell', 'coin', 'star'] };
}

/* ---------- EPIC: barnacled pirate sea chest ---------- */
function oceanPirate() {
  const ink = '#2a2418', B = Box(-84, -78, 54, 0, 40), K = Barrel(-86, 56, -78, 34, 21, -1), S = (d, o) => B.side(d, o), cx = -15;
  const DW = ['#ddd2b8', '#b8aa8e', '#918266'], DS = ['#ad9e80', '#7e705a'];
  const algae = (pts, m) => pts.map(([x, y, rx, ry]) => sh(m ? m(ell(x, y, rx, ry)) : ell(x, y, rx, ry), rg(...(m ? mp(m, x, y) : [x, y]), Math.max(rx, ry) * 1.2, 'rgba(60,150,120,0.42)', 'rgba(60,150,120,0)')));
  const base = [];
  [[-78, 26], [-52, 26], [-26, 26]].forEach(([v, h], i) => base.push(...plankS(0, v, B.D, h, S, DS, i === 1 ? [24, -40] : null, i * 3 + 9)));
  base.push(...algae([[12, -10, 10, 6], [30, -20, 8, 5]], S), ...boxShade(B, ink, { only: 'S' }), sh(B.F, '#2a2016'));
  const rp = parse('M12 -60 C11 -38 29 -38 28 -60'), rope = [st(S(rp, 2), '#5a4a2a', 5.5), st(S(rp, 2), '#d8c090', 3), st(S(shift(rp, -0.6, -0.8), 2.4), 'rgba(255,245,215,0.6)', 1), sh(S(ell(12, -60, 3), 2), '#4a5058', { s: '#1a1e22', w: 1 }), sh(S(ell(28, -60, 3), 2), '#4a5058', { s: '#1a1e22', w: 1 })];
  const plank = (v, i, ex) => plankS(B.x0, v, B.x1 - B.x0, 26, null, DW, i === 1 ? [-40, v + 10] : null, i * 2 + 1, algae(i === 2 ? [[-60, v + 18, 14, 7], [40, v + 20, 12, 6]] : i === 1 ? [[20, v + 16, 10, 5]] : [], null).concat(ex || []));
  const band = x => { const r = rect(x - 5, -78, 10, 78, 1.5), o = [sh(r, iron(x - 5, 0, x + 5, 0), { s: '#141618', w: 1.3 })]; [-70, -48, -26, -8].forEach(y => o.push(sh(ell(x, y, 1.8), rg(x - 0.6, y - 0.6, 2.4, '#c8d0d8', '#5a6068', '#1a1e22')))); o.push(sh(ell(x + 1, -36, 3, 5), 'rgba(170,80,30,0.45)')); return o; };
  const IR = { f: (a, c, e, g) => iron(a, c, e, g), t: '#7a828c', s: '#3a4048' }, c0 = corner3(B, -1, 1, 20, 7, 2, IR, '#141618'), c1 = corner3(B, 1, 1, 20, 7, 2, IR, '#141618');
  [c0, c1].forEach(c => c.sh.push(nail(c.c[0], c.c[1], 1.8)));
  const lid = surf(K.f3, 18, 10, (u, v) => ['#bcae92', '#a89a7e'][Math.floor(v * 5) % 2], { c: K.c, dk: '#141008' }), Ls = lid.sh;
  for (let k = 1; k < 5; k++) lid.lineOn(Array.from({ length: 31 }, (_, i) => [i / 30, k / 5]), 0.02).forEach(p => Ls.push(st(p, 'rgba(50,35,15,0.6)', 1.6), st(shift(p, 0, 1.2), 'rgba(255,245,220,0.35)', 0.9)));
  [[-70, 0.35, 12, 5], [10, 0.6, 14, 5], [44, 0.25, 10, 4]].forEach(([x, t, rx, ry]) => { const p = K.dp(x, t); Ls.push(sh(ell(p[0], p[1], rx, ry), rg(p[0], p[1], rx * 1.2, 'rgba(60,150,120,0.45)', 'rgba(60,150,120,0)'))); });
  Ls.push(st(line([K.dp(K.xa, K.TC), K.dp(K.xb, K.TC)]), ink, 2.2));
  [-59, 29].forEach(x => { const pr = line(K.prof(x)); Ls.push(st(pr, '#141618', 9.5), st(pr, iron(x, -140, x + 30, -78), 6.5), st(shift(pr, -0.8, -0.8), 'rgba(255,255,255,0.35)', 1.2)); [0.3, 0.9, 1.5].forEach(t => { const p = K.dp(x, t); Ls.push(sh(ell(p[0], p[1], 1.8), rg(p[0] - 0.6, p[1] - 0.6, 2.4, '#c8d0d8', '#5a6068', '#1a1e22'))); }); });
  const fe = line([K.dp(K.xa, 0), K.dp(K.xb, 0)]), la = line(K.prof(K.xa)), lb = line(K.prof(K.xb, PI));
  Ls.push(st(fe, '#141618', 8), st(fe, iron(0, -84, 0, -76), 5.4), st(la, '#141618', 8.5), st(la, iron(K.xa, -140, K.xa + 30, -78), 5.6));
  const [ccx, ccy] = P3(K.xb, -78 - 15, 20);
  Ls.push(sh(K.cap, lg(ccx - 10, ccy - 18, ccx + 14, ccy + 16, '#a89a7e', '#7e705a', '#5a4e3a')), st(parse(`M${ccx - 12} ${ccy + 4} L${ccx + 14} ${ccy - 6}`), 'rgba(50,35,15,0.5)', 1.4), st(parse(`M${ccx - 10} ${ccy + 12} L${ccx + 12} ${ccy + 3}`), 'rgba(50,35,15,0.5)', 1.4), st(lb, '#141618', 8.5), st(lb, iron(K.xb, -140, K.xb + 30, -78), 5.6));
  const [ax, ay] = K.dp(cx, 0.8), anc = parse(`M${ax} ${ay - 12} L${ax} ${ay + 11} M${ax - 7} ${ay - 6} L${ax + 7} ${ay - 6} M${ax - 11} ${ay + 3} Q${ax - 9} ${ay + 12} ${ax} ${ay + 12} Q${ax + 9} ${ay + 12} ${ax + 11} ${ay + 3}`);
  Ls.push(st(anc, '#141618', 5.2), st(anc, '#8a929c', 3), st(ell(ax, ay - 15, 3), '#141618', 4.6), st(ell(ax, ay - 15, 3), '#8a929c', 2.6), sh(poly([[ax - 13, ay + 1], [ax - 9, ay + 1], [ax - 11, ay + 6]]), '#8a929c', { s: '#141618', w: 1 }), sh(poly([[ax + 13, ay + 1], [ax + 9, ay + 1], [ax + 11, ay + 6]]), '#8a929c', { s: '#141618', w: 1 }));
  const weed = (x, len, sw) => { const p = []; for (let i = 0; i <= 10; i++) { const t = i / 10; p.push([x + Math.sin(t * 5 + sw) * 3.2 + t * sw * 2, -80 + t * len]); } const L2 = line(p); return [st(L2, '#1a5a32', 5.4), st(L2, '#3aa05a', 3.4), st(shift(L2, -0.8, 0), 'rgba(200,255,200,0.4)', 0.9), sh(ell(p[6][0] + 3, p[6][1], 3.4, 1.8), '#4ab868', { s: '#1a5a32', w: 0.8 }), sh(ell(p[9][0] - 3, p[9][1], 3, 1.6), '#4ab868', { s: '#1a5a32', w: 0.8 })]; };
  const weedSh = [...weed(-77, 34, 0.3), ...weed(-70, 24, -0.6), ...weed(40, 28, 0.5), ...weed(47, 40, -0.2)];
  const barn = []; [[30, -14, 4.2], [37, -9, 3.4], [24, -7, 3], [42, -17, 3.2], [33, -22, 2.6], [-74, -28, 3.4], [-68, -22, 2.8]].forEach(([x, y, r]) => barn.push(sh(ell(x, y, r, r * 0.86), rg(x - r * 0.3, y - r * 0.4, r * 1.3, '#ffffff', '#d8d4c8', '#8a8478'), { s: '#4a463c', w: 0.9 }), sh(ell(x, y - r * 0.15, r * 0.4, r * 0.3), '#3a3428'), st(parse(`M${x - r * 0.7} ${y + r * 0.2} L${x - r * 0.3} ${y - r * 0.2} M${x + r * 0.7} ${y + r * 0.2} L${x + r * 0.3} ${y - r * 0.2}`), 'rgba(80,70,50,0.5)', 0.7)));
  const lock = [sh(rect(cx - 6, -86, 12, 22, 3), iron(cx - 6, 0, cx + 6, 0), { s: '#141618', w: 1.3 }), nail(cx, -80, 1.8), st(parse(`M${cx - 8} -60 L${cx - 8} -68 Q${cx - 8} -76 ${cx} -76 Q${cx + 8} -76 ${cx + 8} -68 L${cx + 8} -60`), '#141618', 6.5), st(parse(`M${cx - 8} -60 L${cx - 8} -68 Q${cx - 8} -76 ${cx} -76 Q${cx + 8} -76 ${cx + 8} -68 L${cx + 8} -60`), '#9aa2ac', 4),
    sh(rect(cx - 14, -64, 28, 26, 7), iron(cx - 14, -64, cx + 14, -38), { s: '#141618', w: 1.6 }), sh(ell(cx, -52, 6.5), brass(cx - 6, -58, cx + 6, -46), { s: '#4a2e06', w: 1 }), sh(ell(cx, -53, 1.8), '#1a1008'), sh(poly([[cx - 1.2, -53], [cx + 1.2, -53], [cx + 1.8, -48.5], [cx - 1.8, -48.5]]), '#1a1008'), sh(ell(cx - 7, -59, 2.6, 1.6), 'rgba(255,255,255,0.5)')];
  return { name: 'Barnacle Sea Chest', mat: 'seawood', hp: 10, W: 180, H: 150, ko: 'planks', rows: [[-200, -52], [-52, -26], [-26, 30]],
    hull: cvx(B.pts.concat(K.pts)),
    parts: [{ id: 'base', sh: base }, { id: 'rope', sh: rope, tear: 0.55, hang: P3(B.x1 + 2, -60, 12), loose: 0.3, hmax: 0.6, hdir: 1 },
      { id: 'star', sh: onP(starfish(22, -34, 10, 0.3), B.pS), tear: 0.46 },
      { id: 'p2', sh: plank(-52, 1) }, { id: 'p1', sh: plank(-78, 0), tear: 0.68, hang: [-62, -66], loose: 0.42, hmax: 1, hdir: 1 }, { id: 'p3', sh: plank(-26, 2), tear: 0.88, hang: [36, -14], loose: 0.64, hmax: 0.5, hdir: -1 },
      { id: 'bands', sh: band(-59).concat(band(29), boxShade(B, ink, { only: 'F', k: 0.8 })) }, { id: 'c0', sh: c0.sh, tear: 0.36, hang: c0.hang, loose: 0.2, hmax: 0.8, hdir: -1 }, { id: 'c1', sh: c1.sh, tear: 0.78, hang: c1.hang, loose: 0.56, hmax: 0.7, hdir: 1 },
      { id: 'barn', sh: barn, tear: 0.6 }, { id: 'lid', sh: Ls, launch: true }, { id: 'weed', sh: weedSh, tear: 0.3, hang: [-74, -80], loose: 0, hmax: 0.4, hdir: 1 },
      { id: 'lock', sh: lock, tear: 0.9, hang: [cx, -84], loose: 0.6, hmax: 0.7, hdir: 1 }],
    loot: ['shell', 'coin', 'pearl', 'coin', 'fish', 'star'] };
}

/* ---------- LEGENDARY: brass diving vault with porthole ---------- */
function oceanDiver() {
  const ink = '#4a2e06', B = Box(-94, -94, 62, 0, 42), L = Box(-97, -124, 65, -94, 45), cx = -16, cy = -48;
  const BR = { f: ['#ffeeb0', '#e0b04a', '#a8741c'], t: ['#fff2c0', '#f0c860'], s: ['#c08a2a', '#7a5410'] };
  const riv = (x, y) => sh(ell(x, y, 2), rg(x - 0.7, y - 0.7, 2.8, '#ffffff', '#e8b84a', '#6a4608'));
  const body = boxFill(B, BR);
  [[-86, 18], [-58, 26], [40, 22], [54, 14]].forEach(([x, h]) => body.push(sh(rect(x - 4, -h - 4, 8, h + 4, 3), lg(0, -h, 0, 0, 'rgba(60,170,150,0)', 'rgba(60,170,150,0.5)'))));
  body.push(...onP([sh(rect(6, -26, 10, 26, 3), lg(0, -26, 0, 0, 'rgba(60,170,150,0)', 'rgba(60,170,150,0.5)'))], B.pS));
  for (let x = -88; x <= 56; x += 12) body.push(riv(x, -88), riv(x, -6)); for (let y = -76; y >= -76 && y < -6; y += 12) body.push(riv(-88, y), riv(56, y));
  body.push(sh(ell(cx + 2, cy + 3, 33), 'rgba(60,30,0,0.35)'), sh(ell(cx, cy, 32), rg(cx - 12, cy - 14, 44, '#fff6d0', '#e8b84a', '#8a5a10'), { s: ink, w: 1.8 }), sh(ell(cx, cy, 25), lg(cx - 20, cy - 20, cx + 20, cy + 20, '#6a4608', '#c88a2a')), st(ell(cx, cy, 30), 'rgba(255,255,255,0.5)', 1.2));
  for (let i = 0; i < 8; i++) { const a = i / 8 * TAU + 0.2; body.push(riv(cx + Math.cos(a) * 28.5, cy + Math.sin(a) * 28.5)); }
  body.push(st(B.side(parse('M21 -50 L21 -30 Q21 -22 29 -22 L42 -22')), '#6a4608', 6), st(B.side(parse('M21 -50 L21 -30 Q21 -22 29 -22 L42 -22')), '#e8b84a', 3.6));
  body.push(...boxShade(B, ink, { only: 'FS' }));
  const glass = [sh(ell(cx, cy, 23), rg(cx - 7, cy - 9, 30, '#8af0ff', '#1a7ab0', '#06284a')), sh(ell(cx, cy + 4, 18, 14), rg(cx, cy + 4, 18, 'rgba(255,216,74,0.5)', 'rgba(255,216,74,0)')),
    ...clipAll([...fishArt(cx - 4, cy - 2, 7.5), ...pearl(cx + 8, cy + 12, 4.2), ...pearl(cx - 1, cy + 15, 3.4), ...pearl(cx + 14, cy + 6, 2.8), ...bubble(cx + 9, cy - 10, 2.4), ...bubble(cx + 4, cy - 15, 1.6), ...bubble(cx - 12, cy + 4, 1.8)], ell(cx, cy, 23)),
    st(parse(`M${cx - 15} ${cy - 6} Q${cx - 13} ${cy - 15} ${cx - 4} ${cy - 18}`), 'rgba(255,255,255,0.8)', 3), st(parse(`M${cx + 12} ${cy + 12} Q${cx + 16} ${cy + 6} ${cx + 16} ${cy}`), 'rgba(255,255,255,0.45)', 2), st(ell(cx, cy, 23), '#3a2004', 1.6)];
  const scar = [sh(ell(cx, cy, 23), rg(cx, cy, 23, '#ffd84a', '#6a3a00', '#140600')), ...[0, 1.1, 2.3, 3.4, 4.6, 5.5].map(a => sh(poly([[cx + Math.cos(a - 0.2) * 23, cy + Math.sin(a - 0.2) * 23], [cx + Math.cos(a + 0.2) * 23, cy + Math.sin(a + 0.2) * 23], [cx + Math.cos(a) * 16, cy + Math.sin(a) * 16]]), 'rgba(170,230,255,0.85)', { s: 'rgba(255,255,255,0.9)', w: 0.8 }))];
  const lid = boxFill(L, BR);
  for (let x = -90; x <= 58; x += 12) lid.push(riv(x, -119), riv(x, -99));
  lid.push(...onP([...[-82, -50, 18, 50].map(u => sh(ell(u, 39, 2, 2), '#c08a2a'))], L.pT));
  lid.push(sh(rect(cx - 31, -116, 62, 15, 4), lg(0, -116, 0, -101, '#c08a2a', '#8a5a10'), { s: ink, w: 1.4 }), sh(rect(cx - 29, -114, 58, 11, 3), lg(0, -114, 0, -103, '#4a2e06', '#2a1802')), tx('DEEP SEA', cx, -108.4, '700 9px Fredoka, Nunito, sans-serif', '#ffd84a'));
  lid.push(...onP([sh(rect(8, -120, 28, 22, 4), 'rgba(60,170,150,0.25)'), ...shellArt(22, -111, 8, 0, ['#fff6d0', '#e8b84a', '#a8741c', '#6a4608'])], L.pS), ...boxShade(L, ink, { k: 0.85 }));
  const ball = (x, y, r) => [sh(ell(x, y, r), rg(x - 3, y - 3, r + 2.5, '#fff6d0', '#e0b04a', '#7a5410'), { s: ink, w: 1.4 }), sh(ell(x - r * 0.3, y - r * 0.35, r * 0.28, r * 0.19), '#ffffff')], sock = (x, y) => [sh(ell(x, y, 4.5), '#2a1802')];
  const WH = (u, w) => P3(u, -130, w), wc = [cx, 22.5];
  const wheel = [st(line([P3(cx, -124, 22.5), P3(cx, -130, 22.5)]), '#6a4608', 6), st(line([P3(cx, -124, 22.5), P3(cx, -130, 22.5)]), '#e8b84a', 3.6),
    ...onP([st(ell(wc[0], wc[1], 20, 17), '#5a0e0a', 7.5), st(ell(wc[0], wc[1], 20, 17), '#e5302a', 4.8), ...[0, 1, 2, 3, 4, 5].map(i => { const a = i / 6 * TAU; return st(line([[wc[0], wc[1]], [wc[0] + Math.cos(a) * 19, wc[1] + Math.sin(a) * 16]]), '#5a0e0a', 3.2); }),
      ...[0, 1, 2, 3, 4, 5].map(i => { const a = i / 6 * TAU; return sh(ell(wc[0] + Math.cos(a) * 20, wc[1] + Math.sin(a) * 17, 2.6), '#ff6a5a', { s: '#5a0e0a', w: 0.8 }); }), sh(ell(wc[0], wc[1], 5, 4.4), '#e8b84a', { s: ink, w: 1.1 })], WH),
    st(shift(line(Array.from({ length: 13 }, (_, i) => { const a = PI + i / 12 * PI * 0.9; return WH(wc[0] + Math.cos(a) * 20, wc[1] + Math.sin(a) * 17); })), 0, -1.6), 'rgba(255,200,190,0.8)', 1.4)];
  const clamp = x => [sh(rect(x - 7, -106, 14, 12, 3), brass(x - 7, -106, x + 7, -94), { s: ink, w: 1.3 }), sh(rect(x - 6, -94, 12, 16, 3), brass(x - 6, -94, x + 6, -78), { s: ink, w: 1.3 }), st(line([[x, -101], [x, -84]]), '#4a2e06', 4.2), st(line([[x, -101], [x, -84]]), '#fff2c0', 2.2), riv(x, -84)];
  const gauge = onP([st(line([[21, -52], [21, -58]]), '#6a4608', 4), sh(ell(21, -66, 10), brass(11, -76, 31, -56), { s: ink, w: 1.3 }), sh(ell(21, -66, 7.4), '#fffaf0'), ...[0, 1, 2, 3, 4].map(i => { const a = PI * 0.8 + i * PI * 0.35; return st(line([[21 + Math.cos(a) * 5.4, -66 + Math.sin(a) * 5.4], [21 + Math.cos(a) * 7, -66 + Math.sin(a) * 7]]), '#4a2e06', 0.9); }), st(line([[21, -66], [25, -70]]), '#e5302a', 1.4), sh(ell(21, -66, 1.3), '#4a2e06')], B.pS);
  return { name: 'Brass Diving Vault', mat: 'brass', hp: 12, W: 200, H: 168, ko: 'pie', pieN: 5,
    hull: cvx(B.pts.concat(L.pts, [WH(cx - 22, 22), WH(cx + 22, 22), WH(cx, 2), WH(cx, 42)])),
    parts: [{ id: 'body', sh: body }, { id: 'glass', sh: glass, tear: 0.5, scar }, { id: 'gauge', sh: gauge, tear: 0.62, hang: B.pS(21, -52), loose: 0.3, hmax: 0.7, hdir: 1 },
      { id: 'lid', sh: lid, launch: true }, { id: 'wheel', sh: wheel, tear: 0.78, launch: true },
      { id: 'kL', sh: clamp(-76), tear: 0.66, hang: [-76, -104], loose: 0.44, hmax: 0.5, hdir: -1 }, { id: 'kR', sh: clamp(44), tear: 0.84, hang: [44, -104], loose: 0.6, hmax: 0.5, hdir: 1 },
      { id: 'c0', sh: ball(-95, -4, 8.5), tear: 0.46, scar: sock(-95, -4) }, { id: 'c1', sh: ball(63, -4, 8.5), tear: 0.7, scar: sock(63, -4) },
      { id: 'c2', sh: ball(-97, -124, 8.5), tear: 0.56, scar: sock(-97, -124) }, { id: 'c3', sh: ball(65, -124, 8.5), tear: 0.9, scar: sock(65, -124) }],
    loot: ['pearl', 'coin', 'fish', 'gem', 'shell', 'star'] };
}

/* ---------- RAINBOW: pearl clam treasury (scallop shell lid) ---------- */
function oceanClam() {
  const ink = '#5a3a00', B = Box(-100, -90, 72, 0, 46), SB = Box(-103, -102, 75, -90, 49, -1.5), S = d => B.side(d);
  const NAC = ['#ffe6f4', '#e0f4ff', '#fff6d8', '#e6ffef', '#efe0ff', '#ffe6f4'];
  const panel = (x, y, w, h, art) => { const r = rect(x, y, w, h, 8), c = [x + w / 2, y + h / 2], o = [sh(r, cg(c[0], c[1], 0, 0.5, ...NAC))];
    for (let k = -h; k < w; k += 9) o.push(st(line([[x + k, y + h], [x + k + h, y]]), 'rgba(255,255,255,0.6)', 1.2, { clip: r }), st(line([[x + k + 4.5, y + h], [x + k + 4.5 - h * 0.6, y]]), 'rgba(170,120,200,0.25)', 1, { clip: r }));
    o.push(...clipAll(art, r), sh(r, lg(x, y, x + w * 0.7, y + h, [0, 'rgba(255,255,255,0.6)'], [0.3, 'rgba(255,255,255,0.1)'], [0.31, 'rgba(255,255,255,0)'], [1, 'rgba(80,0,120,0.2)'])),
      st(shift(r, 2.4, 2.4), 'rgba(110,50,0,0.5)', 4, { clip: r }), st(shift(r, -1.8, -1.8), 'rgba(255,255,255,0.75)', 2.4, { clip: r }), st(r, '#8a5200', 2)); return o; };
  const GS = ['#fff6c0', '#ffd23a', '#c88a00', '#7a4800'], [bpx, bpy] = P3(72, 0, 46), plS = S(rect(0, -10, 46, 10));
  const body = [...shellArt(bpx, bpy - 2, 11, 0, GS), ...boxFill(B, { f: ['#fff2a8', '#ffcf30', '#d99a10'], t: ['#fff6c0', '#ffd84a'], s: ['#e0a414', '#8a5800'] }),
    ...onP(panel(9, -84, 28, 72, starfish(23, -48, 10, 0.2, ['#ffd0e8', '#ff6fae', '#b8306a', '#7a1a44'])), B.pS), sh(plS, mlg(S, 0, -10, 0, 0, '#e8a400', '#8a5800')), st(plS, ink, 1.2),
    ...panel(-92, -84, 46, 72, [...coral(-76, -12, 18, '#ff7a9a'), ...coral(-60, -12, 13, '#ff9a4a'), ...bubble(-58, -66, 3), ...bubble(-64, -74, 2)]),
    ...panel(-38, -84, 50, 72, [...shellArt(-13, -44, 20, 0, ['#ffffff', '#ffc8e8', '#d878a8', '#8a2a5a']), ...pearl(-13, -36, 6)]),
    ...panel(20, -84, 44, 72, [...coral(34, -12, 15, '#b86cff'), ...coral(50, -12, 17, '#3ac8e8'), ...fishArt(40, -64, 6, ['#ffffff', '#ffb0d8', '#d8609a', '#7a1a44'], true)]),
    sh(rect(-46, -88, 8, 78, 3), gl(-46, 0, -38, 0), { s: ink, w: 1.4 }), sh(rect(12, -88, 8, 78, 3), gl(12, 0, 20, 0), { s: ink, w: 1.4 }),
    sh(rect(-100, -11, 172, 11), gl(0, -11, 0, 0), { s: ink, w: 1.4 }), st(line([[-98, -9], [70, -9]]), 'rgba(255,255,255,0.7)', 1.2), ...boxShade(B, ink, { k: 0.7 }),
    ...shellArt(-100, -2, 11, 0, GS), ...shellArt(72, -2, 11, 0, GS), ...shellArt(-96, -84, 7, -0.6, GS), ...shellArt(68, -84, 7, 0.6, GS)];
  const seam = [...boxFill(SB, { f: ['#fff6c0', '#ffcf30', '#c88a00'], t: ['#fff6c0', '#ffe066'], s: ['#d89a10', '#8a5800'] }), ...boxShade(SB, ink, { k: 0.6 })];
  [10, 24, 38].forEach(w => { const [x, y] = SB.Q(75.6, -96, w); seam.push(...pearl(x, y, 3.8)); });
  const studs = k => { const o = []; let i = 0; for (let x = -92; x <= 66; x += 17.5, i++) if (i % 2 === k && Math.abs(x + 14) > 12) { const [X, Y] = SB.Q(x, -96, 0); o.push(...(i % 4 === 1 ? gemS(X, Y, 4.2, ['#3ac8e8', '#ff6fae', '#7ee05a', '#b86cff'][i % 4], ink) : pearl(X, Y, 4.4))); } return o; };
  const hx = -14, hz = 47, Rx = 89, Rz = 48, Hh = 46, yb = -102, NH = ['#ff9ad0', '#8ad0ff', '#ffe08a', '#8af0c0', '#c4a8ff'];
  const sf = (u, v) => { const ph = PI * u, w = Math.cos(14 * ph), rr = v * (1 + 0.022 * w * v), bump = Math.pow(Math.sin(PI * Math.min(1, v)), 0.7) * (0.55 + 0.45 * Math.min(1, v * 1.8));
    return [hx + Math.cos(ph) * rr * Rx, yb - Hh * bump * (1 + 0.13 * w * Math.min(1, v * 1.4)) - 2.6 * w * Math.pow(v, 4), hz - Math.sin(ph) * rr * Rz]; };
  const shell = surf(sf, 42, 9, (u, v) => { const k = u * 14, f = k - Math.floor(k); return mixH(NH[Math.floor(k) % 5], '#ffffff', 0.08 + 0.22 * (1 - Math.abs(f - 0.5) * 2)); }, { c: [hx, yb + 20, 23], dk: '#4a1a6a', cv: -0.05 });
  const Ls = shell.sh;
  for (let k = 0; k < 7; k++) { const vu = (2 * k + 1) / 14; shell.lineOn(Array.from({ length: 14 }, (_, i) => [vu, 0.1 + 0.9 * i / 13]), 0.02).forEach(p => Ls.push(st(p, 'rgba(110,50,140,0.45)', 1.4))); }
  for (let k = 1; k < 7; k++) shell.lineOn(Array.from({ length: 14 }, (_, i) => [k / 7, 0.12 + 0.86 * i / 13]), 0.02).forEach(p => Ls.push(st(p, 'rgba(255,255,255,0.7)', 1.4)));
  [0.45, 0.75].forEach(v => shell.lineOn(Array.from({ length: 57 }, (_, i) => [i / 56, v]), 0.05).forEach(p => Ls.push(st(p, 'rgba(255,255,255,0.3)', 1))));
  const hp = shell.P(0.66, 0.5); Ls.push(sh(ell(hp[0], hp[1], 26, 8), rg(hp[0], hp[1], 26, 'rgba(255,255,255,0.7)', 'rgba(255,255,255,0)')));
  shell.lineOn(Array.from({ length: 85 }, (_, i) => [0.02 + 0.96 * i / 84, 1]), 0.02).forEach(p => Ls.push(st(p, ink, 7), st(p, gl(0, -110, 0, -96), 4.4), st(shift(p, 0, -1.2), 'rgba(255,255,255,0.65)', 1.1)));
  const pk = shell.P(0.5, 0.5), crest = [...starfish(pk[0], pk[1] - 10, 17, 0, ['#fff6c0', '#ffd23a', '#c88a00', '#7a4800']), ...gemS(pk[0], pk[1] - 10, 4.4, '#ff6fae', ink), ...[0, 1, 2, 3, 4].map(i => { const a = -PI / 2 + i * TAU / 5; return gemS(pk[0] + Math.cos(a) * 10, pk[1] - 10 + Math.sin(a) * 10, 2.4, ['#3ac8e8', '#7ee05a', '#b86cff', '#ffb020', '#ff6fae'][i], ink); }).flat()];
  const lock = [sh(parse('M-30 -100 Q-24 -82 -14 -78 Q-4 -82 2 -100 L-6 -100 Q-10 -88 -14 -86 Q-18 -88 -22 -100 Z'), gl(-30, -100, 2, -78), { s: ink, w: 1.5 }), ...pearl(-14, -92, 12.5), sh(spark4(-6, -100, 4), '#ffffff')];
  return { name: 'Pearl Clam Treasury', mat: 'nacre', hp: 14, W: 236, H: 218, ko: 'pie', pieN: 8, ring: true,
    hull: cvx(B.pts.concat(SB.pts, shell.pts, [[pk[0], pk[1] - 30], [-112, 8], [bpx + 12, bpy + 8]])),
    parts: [{ id: 'body', sh: body }, { id: 'seam', sh: seam }, { id: 'studA', sh: studs(0), tear: 0.32 }, { id: 'studB', sh: studs(1), tear: 0.54 },
      { id: 'lid', sh: Ls, launch: true }, { id: 'lock', sh: lock, tear: 0.9, hang: [-14, -102], loose: 0.6, hmax: 0.5, hdir: 1 }, { id: 'crest', sh: crest, tear: 0.74, launch: true }],
    loot: ['pearl', 'shell', 'gem', 'star', 'coin', 'fish'] };
}

/* ---------- loot icons ---------- */
function icShell(c, s) {
  const N = 7; c.beginPath(); c.moveTo(0, s * 0.42);
  for (let i = 0; i <= N * 2; i++) { const a = PI + 0.35 + (PI - 0.7) * i / (N * 2), k = (i % 2 ? 0.5 : 0.45) * s; c.lineTo(Math.cos(a) * k, s * 0.22 + Math.sin(a) * k); }
  c.closePath(); const g = c.createRadialGradient(-s * 0.1, -s * 0.1, 0, 0, 0, s * 0.6); g.addColorStop(0, '#fff0f6'); g.addColorStop(0.6, '#ffb8d8'); g.addColorStop(1, '#e0789e'); c.fillStyle = g; c.fill(); c.strokeStyle = '#9a3a62'; c.lineWidth = s * 0.06; c.stroke();
  c.strokeStyle = 'rgba(140,50,90,0.45)'; c.lineWidth = s * 0.04; for (let i = 1; i < N * 2; i += 2) { const a = PI + 0.35 + (PI - 0.7) * i / (N * 2); c.beginPath(); c.moveTo(0, s * 0.4); c.lineTo(Math.cos(a) * s * 0.48, s * 0.22 + Math.sin(a) * s * 0.48); c.stroke(); }
}
function icPearl(c, s) { const g = c.createRadialGradient(-s * 0.12, -s * 0.14, 0, 0, 0, s * 0.42); g.addColorStop(0, '#ffffff'); g.addColorStop(0.5, '#fbe8f4'); g.addColorStop(1, '#b8a4d8'); c.fillStyle = g; c.beginPath(); c.arc(0, 0, s * 0.36, 0, TAU); c.fill(); c.strokeStyle = 'rgba(90,60,120,0.5)'; c.lineWidth = s * 0.04; c.stroke(); c.fillStyle = 'rgba(255,255,255,0.95)'; c.beginPath(); c.ellipse(-s * 0.12, -s * 0.13, s * 0.09, s * 0.06, -0.5, 0, TAU); c.fill(); }
function icFish(c, s) {
  c.fillStyle = '#ff8a1a'; c.strokeStyle = '#8a3a00'; c.lineWidth = s * 0.05; c.beginPath(); c.moveTo(-s * 0.25, 0); c.lineTo(-s * 0.5, -s * 0.2); c.lineTo(-s * 0.45, 0); c.lineTo(-s * 0.5, s * 0.2); c.closePath(); c.fill(); c.stroke();
  const g = c.createRadialGradient(-s * 0.05, -s * 0.08, 0, 0, 0, s * 0.4); g.addColorStop(0, '#fff3a0'); g.addColorStop(0.6, '#ffb01a'); g.addColorStop(1, '#e06a00'); c.fillStyle = g; c.beginPath(); c.ellipse(0, 0, s * 0.34, s * 0.22, 0, 0, TAU); c.fill(); c.stroke();
  c.fillStyle = '#ffffff'; c.beginPath(); c.arc(s * 0.17, -s * 0.04, s * 0.06, 0, TAU); c.fill(); c.fillStyle = '#1a1a2a'; c.beginPath(); c.arc(s * 0.19, -s * 0.04, s * 0.035, 0, TAU); c.fill();
}

const Cd = CM.MAT.candy, Mt = CM.MAT.metal, W = CM.MAT.wood;
CM.register('ocean', [oceanBucket, oceanCooler, oceanPirate, oceanDiver, oceanClam], {
  mat: {
    beachplastic: { soft: 1.1, lean: 6, sag: 4, dentK: 6, dentShade: 0.26, holeFrom: 0.24, holeP: 0.7, holeR: [15, 21], jag: 'shard', edge: '#e8fbff', edgeW: 5, crack: 'stress', chips: ['#2ab0d8', '#6adcf2', '#ffd23a', '#f2d488', '#ffffff'], deb: 'chip', deb2: 'bubble', dust: '#f6e6bc', mass: 0.8, sfx: { m: 'plastic', p: 1.1, x: ['water'] }, rest: 0.3, cav: ['#062a3a', '#0e4a5e'], glow: '#9ff0ff' },
    cooler: { soft: 0.4, lean: 4, sag: 3, dentK: 6, dentShade: 0.3, holeFrom: 0.3, holeP: 0.6, holeR: [15, 21], jag: 'shard', edge: '#ffffff', edgeW: 6, crack: 'stress', chips: ['#2ab4dc', '#ffffff', '#ffd23a', '#c8d6e0'], deb: 'chip', deb2: 'bubble', dust: '#e6f2f8', mass: 1.2, sfx: { m: 'plastic', p: 0.95, x: ['latch', 'water'] }, rest: 0.32, cav: ['#041a2a', '#0a3448'], glow: '#9ff0ff' },
    seawood: Object.assign({}, W, { chips: ['#d8cdb4', '#b4a68a', '#8e8068', '#3aa05a', '#ffffff'], deb2: 'bubble', dust: '#e2dccc', sfx: { m: 'wood', p: 0.88, x: ['water', 'creak'] }, cav: ['#0a1410', '#1a2a22'], glow: '#9ff0e0' }),
    brass: Object.assign({}, Mt, { chips: ['#e8b84a', '#ffeeb0', '#a8741c', '#3ac8b0', '#e5302a'], deb2: 'bubble', dust: '#e6e0cc', sfx: { m: 'gold', p: 0.85, x: ['water', 'vault'] }, cav: ['#06141c', '#0e2a34'], glow: '#7ae8ff', spark: '#fff2a8' }),
    nacre: Object.assign({}, Cd, { chips: ['#ffe6f4', '#e0f4ff', '#fff6d8', '#ffd23a', '#c0e4ff', '#ffc0e4'], deb2: 'bubble', dust: '#f6f0ff', sfx: { m: 'crystal', p: 1.1, x: ['rainbow', 'pearl', 'water'] }, glow: '#bff4ff' }),
  },
  crack: { stress: [['rgba(255,255,255,0.85)', 2, 0, 0], ['rgba(0,40,80,0.3)', 1, 1, 1]] },
  icons: { shell: icShell, pearl: icPearl, fish: icFish },
});
}
(function go() { if (window.ChestModels && window.ChestModels.H) run(); else setTimeout(go, 30); })();
})();
