// Spooky Squish chests for ChestModels: Pumpkin Treat Pail -> Creaky Coffin Crate -> Haunted Trunk -> Moonlit Crypt Chest -> Rainbow Phantom Treasury.
(function () {
'use strict';
function run() {
const CM = window.ChestModels, H = CM.H, K = CM.K;
const { parse, poly, line, rect, ell, shift, spark4, star5, lg, rg, sh, st, tx, P3, mapD, onP, FR, Box, cvx, boxFill, boxShade, corner3, plankS, surf, Barrel, nail, KX, KY } = H;
const { PI, TAU, mixH, R2, gl, ir, gemS, IRON, ball, ringP, disc, FA, cylP, onCyl, vault, treasury, rbLid, pal, RBW, moonP, clipAll, revE, pE, discE, onCylE, arcE } = K;
const ghost = (x, y, s, f, ink, o) => { o = o || {}; const P = parse(`M${x - s * 0.5} ${y + s * 0.5} L${x - s * 0.5} ${y - s * 0.1} Q${x - s * 0.5} ${y - s * 0.62} ${x} ${y - s * 0.62} Q${x + s * 0.5} ${y - s * 0.62} ${x + s * 0.5} ${y - s * 0.1} L${x + s * 0.5} ${y + s * 0.5} Q${x + s * 0.38} ${y + s * 0.36} ${x + s * 0.25} ${y + s * 0.5} Q${x + s * 0.12} ${y + s * 0.36} ${x} ${y + s * 0.5} Q${x - s * 0.12} ${y + s * 0.36} ${x - s * 0.25} ${y + s * 0.5} Q${x - s * 0.38} ${y + s * 0.36} ${x - s * 0.5} ${y + s * 0.5} Z`);
  return [sh(P, f || rg(x - s * 0.2, y - s * 0.3, s * 0.8, '#ffffff', '#f2eeff', '#c8c0e8'), { s: ink, w: Math.max(1, s * 0.06) }), sh(ell(x - s * 0.17, y - s * 0.16, s * 0.08, s * 0.12), o.eye || '#2a1a3a'), sh(ell(x + s * 0.17, y - s * 0.16, s * 0.08, s * 0.12), o.eye || '#2a1a3a'), sh(ell(x, y + s * 0.06, s * 0.08, s * 0.1), o.eye || '#2a1a3a'), sh(ell(x - s * 0.3, y - s * 0.02, s * 0.07, s * 0.04), 'rgba(255,130,170,0.55)'), sh(ell(x + s * 0.3, y - s * 0.02, s * 0.07, s * 0.04), 'rgba(255,130,170,0.55)')]; };
const bat = (x, y, s, f, ink) => [sh(parse(`M${x} ${y - s * 0.12} Q${x - s * 0.18} ${y - s * 0.34} ${x - s * 0.5} ${y - s * 0.3} Q${x - s * 0.44} ${y - s * 0.16} ${x - s * 0.52} ${y} Q${x - s * 0.36} ${y - s * 0.02} ${x - s * 0.3} ${y + s * 0.12} Q${x - s * 0.18} ${y} ${x - s * 0.1} ${y + s * 0.16} Q${x} ${y + s * 0.06} ${x + s * 0.1} ${y + s * 0.16} Q${x + s * 0.18} ${y} ${x + s * 0.3} ${y + s * 0.12} Q${x + s * 0.36} ${y - s * 0.02} ${x + s * 0.52} ${y} Q${x + s * 0.44} ${y - s * 0.16} ${x + s * 0.5} ${y - s * 0.3} Q${x + s * 0.18} ${y - s * 0.34} ${x} ${y - s * 0.12} Z`), f, ink ? { s: ink, w: Math.max(0.8, s * 0.04) } : {}),
  sh(poly([[x - s * 0.1, y - s * 0.16], [x - s * 0.08, y - s * 0.28], [x - s * 0.02, y - s * 0.18], [x + s * 0.02, y - s * 0.18], [x + s * 0.08, y - s * 0.28], [x + s * 0.1, y - s * 0.16]]), f)];
const jack = (x, y, r, f, ink, o) => { o = o || {}; const out = [sh(ell(x, y, r * 1.1, r), f || rg(x - r * 0.35, y - r * 0.4, r * 1.4, '#ffd08a', '#ff8a1a', '#c4500a'), { s: ink, w: Math.max(1, r * 0.08) })];
  [-0.5, 0, 0.5].forEach(k => out.push(st(parse(`M${x + k * r * 0.9} ${y - r * 0.95} Q${x + k * r * 1.4} ${y} ${x + k * r * 0.9} ${y + r * 0.95}`), 'rgba(140,50,0,0.4)', Math.max(0.8, r * 0.06))));
  const fc = o.face || '#3a1404'; out.push(sh(poly([[x - r * 0.55, y - r * 0.1], [x - r * 0.3, y - r * 0.45], [x - r * 0.12, y - r * 0.1]]), fc), sh(poly([[x + r * 0.55, y - r * 0.1], [x + r * 0.3, y - r * 0.45], [x + r * 0.12, y - r * 0.1]]), fc),
    sh(parse(`M${x - r * 0.6} ${y + r * 0.2} Q${x} ${y + r * 0.42} ${x + r * 0.6} ${y + r * 0.2} Q${x + r * 0.45} ${y + r * 0.66} ${x} ${y + r * 0.66} Q${x - r * 0.45} ${y + r * 0.66} ${x - r * 0.6} ${y + r * 0.2} Z`), fc),
    sh(rect(x - r * 0.12, y - r * 1.25, r * 0.24, r * 0.34, r * 0.08), '#4a7a2a', { s: ink, w: Math.max(0.8, r * 0.05) })); return out; };
const web = (x, y, s, dx, dy) => { const o = [], R = [0.35, 0.65, 1]; for (let k = 0; k <= 4; k++) { const a = k / 4 * PI / 2; o.push(st(line([[x, y], [x + Math.cos(a) * s * dx, y + Math.sin(a) * s * dy]]), 'rgba(255,255,255,0.75)', 0.9)); }
  R.forEach(r => { const p = []; for (let k = 0; k <= 4; k++) { const a = k / 4 * PI / 2; p.push([x + Math.cos(a) * s * r * dx, y + Math.sin(a) * s * r * dy]); } o.push(st(line(p), 'rgba(255,255,255,0.7)', 0.8)); }); return o; };
const candyCorn = (x, y, s, a) => { const f = R2(x, y, s, a || 0), M = d => mapD(parse(d), f); return [sh(M('M0 -0.5 L0.32 0.4 Q0 0.5 -0.32 0.4 Z'), '#ffffff', { s: '#6a3a14', w: 0.8 }), sh(M('M-0.2 0.06 L0.2 0.06 L0.32 0.4 Q0 0.5 -0.32 0.4 Z'), '#ff8a1a'), sh(M('M-0.1 -0.2 L0.1 -0.2 L0.2 0.06 L-0.2 0.06 Z'), '#ffd23a'), st(M('M0 -0.5 L0.32 0.4 Q0 0.5 -0.32 0.4 Z'), '#6a3a14', 0.8)]; };
const wrapC = (x, y, s, c) => [sh(poly([[x - s * 0.4, y], [x - s * 0.9, y - s * 0.32], [x - s * 0.9, y + s * 0.32]]), c, { s: '#3a1a3a', w: 0.8 }), sh(poly([[x + s * 0.4, y], [x + s * 0.9, y - s * 0.32], [x + s * 0.9, y + s * 0.32]]), c, { s: '#3a1a3a', w: 0.8 }), sh(ell(x, y, s * 0.5, s * 0.42), rg(x - s * 0.15, y - s * 0.15, s * 0.6, '#ffffff', c), { s: '#3a1a3a', w: 0.9 })];
const flameG = (x, y, s) => [sh(parse(`M${x} ${y - s} Q${x + s * 0.5} ${y - s * 0.3} ${x} ${y} Q${x - s * 0.5} ${y - s * 0.3} ${x} ${y - s} Z`), rg(x, y - s * 0.3, s * 0.7, '#ffffff', '#a8ff6a', '#3ac84a'), { g: '#7aff5a', gb: 10 })];

/* ---------- COMMON: pumpkin treat pail ---------- */
function spookyPail() {
  const ink = '#5a2404', X = 4, k = 0.4, yT = -70, rr = v => 57 * (0.6 + 0.4 * Math.sin(PI * (0.06 + 0.86 * v))), lob = a => 0.93 + 0.07 * Math.pow(Math.abs(Math.cos(4 * a)), 0.7);
  const pail = revE(X, (v, a) => [rr(v) * lob(a), yT * v], 48, 8, (u, v, i) => (i % 6 === 3 || i % 6 === 2) ? '#e66c08' : i % 6 === 0 ? '#ff9a2e' : '#ff8a1a', { k, dk: '#4a1400' }), body = [...pail.sh], hull = cvx(pail.pts);
  for (let n = 0; n < 8; n++) { pail.lineOn(Array.from({ length: 11 }, (_, j) => [1 / 16 + n / 8, j / 10]), 0.02).forEach(p => body.push(st(p, 'rgba(120,36,0,0.55)', 1.8))); pail.lineOn(Array.from({ length: 7 }, (_, j) => [n / 8, 0.2 + j * 0.1]), 0.25).forEach(p => body.push(st(p, 'rgba(255,230,170,0.35)', 3.2))); }
  body.push(sh(hull, lg(X - 58, 0, X + 58, 0, [0, 'rgba(255,240,200,0.2)'], [0.3, 'rgba(255,240,200,0.3)'], [0.45, 'rgba(255,240,200,0)'], [0.68, 'rgba(60,10,0,0)'], [1, 'rgba(60,10,0,0.42)'])), sh(hull, lg(0, yT, 0, 18, [0, 'rgba(60,10,0,0)'], [0.72, 'rgba(60,10,0,0)'], [1, 'rgba(60,10,0,0.3)'])));
  const face = (d) => [sh(d, rg(X, -30, 40, '#fff2a0', '#ffb020', '#a84a06')), st(d, '#5a1a00', 1.6), st(shift(d, -0.8, -0.8), 'rgba(255,220,150,0.55)', 1)];
  body.push(...onCylE(X, rr(0.55) * 0.97 + 0.5, [...face(poly([[-25, -48], [-12, -64], [-5, -48]])), ...face(poly([[25, -48], [12, -64], [5, -48]])), ...face(poly([[-3.5, -40], [3.5, -40], [0, -46]])),
    ...face(parse('M-34 -27 L-25 -23 L-19 -29 L-12 -22 L-4 -27 L4 -22 L12 -27 L19 -22 L25 -29 L30 -23 L34 -27 Q25 -8 0 -8 Q-25 -8 -34 -27 Z'))], 0, k));
  body.push(st(hull, ink, 2.6));
  const r1 = rr(1) * 0.97, rim = [sh(discE(X, r1 + 1.5, yT, k), lg(X - r1, 0, X + r1, 0, '#ffc070', '#ff9a2e', '#c85a08'), { s: ink, w: 2 }), sh(discE(X, r1 - 3.5, yT + 0.5, k), lg(0, yT - k * r1, 0, yT + k * r1, '#c86a1a', '#7a3006', '#2a0c02')), st(poly(arcE(X, r1 - 3.5, yT + 0.5, k, PI * 1.05, PI * 1.95, 16)), 'rgba(255,200,120,0.5)', 1.4)];
  const hA = [X - rr(0.9) - 1, -63], hB = [X + rr(0.9) + 1, -63], hd = parse(`M${hA[0]} ${hA[1]} C${hA[0] - 2} -136 ${hB[0] + 2} -136 ${hB[0]} ${hB[1]}`);
  const handle = [st(hd, '#1a0a1a', 6.4), st(hd, lg(0, -130, 0, -70, '#7a5a8a', '#3a2248'), 3.8), st(shift(hd, -0.8, -1), 'rgba(255,255,255,0.45)', 1.1), ...[hA, hB].map(p => sh(ell(p[0], p[1], 4.4, 5), rg(p[0] - 1.4, p[1] - 1.6, 5.6, '#7a5a8a', '#2a1a2a'), { s: '#1a0a1a', w: 1 }))];
  const c0 = [X, yT], dk = c => mixH(c, '#2a0a2a', 0.45);
  const gum = (x, y, r, c) => [sh(ell(x, y, r), rg(x - r * 0.35, y - r * 0.4, r * 1.35, mixH(c, '#ffffff', 0.55), c, dk(c)), { s: '#3a1a3a', w: 0.9 }), sh(ell(x - r * 0.36, y - r * 0.4, r * 0.3, r * 0.2), 'rgba(255,255,255,0.85)')];
  const mint = (x, y, r) => { const p = (t, f) => (x + Math.cos(t) * r * 0.95 * f) + ' ' + (y + Math.sin(t) * r * 0.78 * f), o = [sh(ell(x, y, r, r * 0.82), rg(x - r * 0.3, y - r * 0.35, r * 1.3, '#ffffff', '#fff2f4', '#d8bcc8'), { s: '#5a1a2a', w: 0.9 })];
    for (let j = 0; j < 3; j++) { const a = j * TAU / 3; o.push(sh(parse(`M${x} ${y} Q${p(a + 0.3, 0.6)} ${p(a + 0.75, 1)} L${p(a + 1.2, 1)} Q${p(a + 0.75, 0.5)} ${x} ${y} Z`), '#ff2a4a')); }
    o.push(sh(ell(x, y, r, r * 0.82), rg(x - r * 0.3, y - r * 0.35, r * 1.3, 'rgba(255,255,255,0.35)', 'rgba(255,255,255,0)', 'rgba(80,0,20,0.3)')), st(ell(x, y, r, r * 0.82), '#5a1a2a', 0.9), sh(ell(x - r * 0.4, y - r * 0.36, r * 0.26, r * 0.15), 'rgba(255,255,255,0.9)')); return o; };
  const bar = (x, y, s, a, c, lab) => { const f = R2(x, y, s, a), M = d => mapD(parse(d), f), B = 'M-0.55 -0.3 L0.55 -0.3 Q0.62 -0.3 0.62 -0.22 L0.62 0.22 Q0.62 0.3 0.55 0.3 L-0.55 0.3 Q-0.62 0.3 -0.62 0.22 L-0.62 -0.22 Q-0.62 -0.3 -0.55 -0.3 Z';
    return [sh(M(B), lg(x, y - s * 0.32, x, y + s * 0.32, mixH(c, '#ffffff', 0.4), c, dk(c))), sh(M('M-0.2 -0.3 L0.2 -0.3 L0.2 0.3 L-0.2 0.3 Z'), lab), sh(M('M-0.1 -0.1 L0.1 -0.1 L0.1 0.1 L-0.1 0.1 Z'), c),
      st(M('M-0.48 -0.26 L-0.48 0.26 M0.48 -0.26 L0.48 0.26'), 'rgba(40,0,30,0.35)', 0.8), sh(M(B), lg(x, y - s * 0.32, x, y + s * 0.32, 'rgba(255,255,255,0)', 'rgba(255,255,255,0)', 'rgba(40,0,30,0.25)')), st(M(B), '#3a1a3a', 0.9), st(M('M-0.5 -0.19 L0.5 -0.19'), 'rgba(255,255,255,0.6)', 1.1)]; };
  const worm = (P, c1, c2) => { const pts = P.map(p => p.join(' ')), d1 = parse(`M${pts[0]} Q${pts[1]} ${pts[2]}`), d2 = parse(`M${pts[2]} Q${pts[3]} ${pts[4]}`);
    return [st(d1, '#3a1a3a', 6.6), st(d2, '#3a1a3a', 6.6), st(d1, c1, 4.8), st(d2, c2, 4.8), st(shift(d1, -0.8, -1), 'rgba(255,255,255,0.55)', 1.3), st(shift(d2, -0.8, -1), 'rgba(255,255,255,0.55)', 1.3)]; };
  const mound = parse('M-31 -70 C-30 -88 -14 -94 4 -94 C22 -94 38 -88 39 -70 C36 -60 22 -57 4 -57 C-14 -57 -28 -60 -31 -70 Z');
  const heap = [sh(mound, rg(-4, -90, 46, '#c070b0', '#6a2a6a', '#2a0a2a')),
    ...wrapC(-22, -88, 7, '#3ac0ff'), ...candyCorn(14, -93, 10, 0.7), ...gum(-4, -93, 5, '#ff5c9a'),
    ...gum(-14, -89, 6, '#5ae07a'), ...wrapC(5, -95, 9, '#ff8a1a'), ...bar(24, -89, 22, -0.45, '#8a4ae0', '#ffd23a'), ...mint(-24, -83, 8),
    ...candyCorn(-5, -85, 15, -0.2), ...gum(12, -82, 7, '#ffd23a'), ...wrapC(31, -78, 9, '#5ae07a'), ...bar(-20, -74, 22, 0.35, '#ff7a1a', '#3a1a3a'), ...gum(-31, -73, 5.5, '#a05cff'),
    ...wrapC(-11, -68, 10, '#a05cff'), ...mint(8, -68, 9), ...candyCorn(25, -70, 13, 0.5), ...gum(36, -65, 6, '#ff5c9a'), ...wrapC(-27, -62, 8, '#ffd23a'),
    ...bar(19, -58, 20, 0.22, '#3ac0ff', '#ffffff'), ...candyCorn(-3, -57, 11, -0.9),
    ...worm([[-18, -66], [-40, -74], [-41, -60], [-42, -48], [-36, -42]], '#ff5c9a', '#ffd23a')];
  const lol = [st(line([[c0[0] + 8, c0[1]], [c0[0] + 18, c0[1] - 34]]), '#5a3a5a', 4.2), st(line([[c0[0] + 8, c0[1]], [c0[0] + 18, c0[1] - 34]]), '#ffffff', 2.6), sh(ell(c0[0] + 19, c0[1] - 40, 10), RBW(c0[0] + 19, c0[1] - 40, 0), { s: '#5a1a3a', w: 1.3 }),
    st(parse(`M${c0[0] + 19} ${c0[1] - 40} Q${c0[0] + 25} ${c0[1] - 44} ${c0[0] + 21} ${c0[1] - 48} Q${c0[0] + 13} ${c0[1] - 48} ${c0[0] + 12} ${c0[1] - 40}`), 'rgba(255,255,255,0.75)', 1.6)];
  const stick = onCylE(X, rr(0.35) * 0.97 + 1, [st(ell(0, -24, 10, 11), '#ffffff', 3.6), ...ghost(0, -24, 18, null, '#4a3a6a')], 1.05, k);
  return K.liftM({ name: 'Pumpkin Treat Pail', mat: 'pail', hp: 6, W: 112, H: 137, ko: 'halves',
    hull: cvx(pail.pts.concat([[X, -118], [hA[0] - 4, -63], [hB[0] + 4, -63], [c0[0] + 19, c0[1] - 52], [-46, -60], [-40, -40]])),
    parts: [{ id: 'body', sh: body.concat(rim) }, { id: 'stick', sh: stick, tear: 0.5 }, { id: 'heap', sh: heap, launch: true, launchV: 380 }, { id: 'lol', sh: lol, tear: 0.34 }, { id: 'handle', sh: handle, tear: 0.66, hang: hA, loose: 0.3, hmax: 0.5, hdir: -1 }],
    loot: ['candy', 'coin', 'pumpkin', 'ghost'] }, -k * rr(0) * 0.96);
}

/* ---------- RARE: creaky coffin crate ---------- */
function spookyCoffin() {
  const ink = '#1a0a24', D = 26, F = [[-28, 0], [28, 0], [44, -82], [30, -114], [-30, -114], [-44, -82]], d = p => P3(p[0], p[1], D);
  const quad = (a, b) => poly([a, b, d(b), d(a)]);
  const body = [sh(quad(F[1], F[2]), lg(...F[1], ...d(F[2]), '#5a3a6a', '#2e1a3a')), st(quad(F[1], F[2]), ink, 2.2), sh(quad(F[2], F[3]), lg(...F[2], ...d(F[3]), '#6a4a7a', '#3a2248')), st(quad(F[2], F[3]), ink, 2.2), sh(quad(F[3], F[4]), lg(...F[4], ...d(F[3]), '#8a6a9a', '#5a3a6a')), st(quad(F[3], F[4]), ink, 2.2)];
  [8, 17].forEach(w => body.push(st(line([P3(28, 0, w), P3(44, -82, w), P3(30, -114, w)]), 'rgba(20,5,30,0.45)', 1.2)));
  body.push(sh(poly(F), lg(-44, -114, 44, 0, '#7a5a8a', '#4a2e5a', '#2e1a3a')), st(poly(F), ink, 2.4));
  const LF = F.map(([x, y]) => [x * 0.86 - 1, -57 + (y + 57) * 0.9]), lid = [sh(shift(poly(LF), 1.6, 2), 'rgba(10,0,20,0.4)'), sh(poly(LF), lg(-40, -110, 40, -4, '#a07ab8', '#6a4a8a', '#3e2650'), { s: ink, w: 1.8 })];
  [-20, -8, 4, 16].forEach(x => lid.push(st(line([[x, -106], [x * 1.1, -6]]), 'rgba(20,5,30,0.4)', 1.2)));
  [[-22, -100], [22, -100], [-20, -10], [20, -10]].forEach(([x, y]) => lid.push(nail(x, y, 1.8)));
  lid.push(sh(rect(-38, -86, 12, 6, 2), ir(-38, -86, -26, -80), { s: ink, w: 1 }), sh(rect(-38, -30, 12, 6, 2), ir(-38, -30, -26, -24), { s: ink, w: 1 }), sh(moonP(4, -70, 12), lg(-8, -82, 4, -58, '#fff6c0', '#ffd23a'), { s: '#8a5a00', w: 1.2 }), ...[[10, -80, 2.4], [16, -64, 1.8], [-14, -50, 2]].map(([x, y, s]) => sh(spark4(x, y, s), '#fff6c0')), st(poly(LF), 'rgba(255,255,255,0.25)', 1));
  const plate = [st(line([[-4, -44], [-4, -40]]), '#9aa2b0', 1.4), sh(rect(-18, -40, 28, 13, 3), lg(0, -40, 0, -27, '#e8e0f0', '#a8a0b8'), { s: ink, w: 1.3 }), tx('BOO!', -4, -33, '700 8.5px Fredoka, Nunito, sans-serif', '#6a2a8a')];
  const cob = [...web(-30, -114, 22, 1, 1), ...web(30, -114, 18, -1, 1)];
  const bp = [P3(36, -50, 13)], batS = [...bat(bp[0][0], bp[0][1], 22, '#2a1a3a', ink), sh(ell(bp[0][0] - 2.4, bp[0][1] - 4, 1.2), '#ffd23a'), sh(ell(bp[0][0] + 2.4, bp[0][1] - 4, 1.2), '#ffd23a')];
  return { name: 'Creaky Coffin Crate', mat: 'coffin', hp: 8, W: 150, H: 140, ko: 'planks', rows: [[-200, -82], [-82, -40], [-40, 30]],
    hull: cvx(F.concat(F.map(d))),
    parts: [{ id: 'body', sh: body }, { id: 'lid', sh: lid, launch: true }, { id: 'cob', sh: cob, tear: 0.3 }, { id: 'bat', sh: batS, tear: 0.5 }, { id: 'plate', sh: plate, tear: 0.62, hang: [-4, -44], loose: 0.2, hmax: 0.8, hdir: 1 }],
    loot: ['ghost', 'coin', 'candy', 'pumpkin', 'coin'] };
}

/* ---------- EPIC: haunted trunk ---------- */
function spookyTrunk() {
  const ink = '#140820', B = Box(-84, -78, 54, 0, 40), S = d => B.side(d), xa = -88, xb = 58, yb = -78, dh = 28, PC = ['#7a5a8a', '#5a3e6a', '#3a2448'], PS = ['#5a3e6a', '#2e1a3a'];
  const body = [];
  for (let r = 0; r < 3; r++) body.push(...plankS(-84, -78 + r * 26, 138, 26, FR, PC, r === 1 ? [30, -40] : null, r * 4 + 2));
  for (let r = 0; r < 3; r++) body.push(...plankS(0, -78 + r * 26, 40, 26, S, PS, null, r * 3 + 5));
  const band = x => [sh(rect(x, -78, 10, 78), ir(x, 0, x + 10, 0), { s: ink, w: 1.2 }), nail(x + 5, -70, 1.8), nail(x + 5, -40, 1.8), nail(x + 5, -8, 1.8)];
  body.push(...boxShade(B, ink, { only: 'FS', k: 0.8, noBevel: true }), ...band(-64), ...band(30));
  const Bl = Barrel(xa, xb, yb, dh, 21, -1), cu = surf(Bl.f3, 22, 12, (u, v, i, j) => (i + j) % 2 ? '#5a3a7a' : '#523472', { c: [-15, -68, 20], dk: '#0a0414' }), lid = [...cu.sh];
  [-59, 35].forEach(x => { const u = (x - xa) / (xb - xa); cu.lineOn(Array.from({ length: 25 }, (_, i) => [u, i / 24]), 0.04).forEach(p => lid.push(st(p, ink, 11), st(p, ir(0, -110, 0, -78), 8.5))); });
  for (let k = 0; k < 14; k++) { const u = (k * 0.618) % 1, v = 0.15 + (k * 0.37) % 0.7; if (cu.visAt(u, v) > 0.1 && Math.abs(u - 0.2) > 0.05 && Math.abs(u - 0.84) > 0.05) { const p = cu.P(u, v); lid.push(sh(star5(p[0], p[1], 2.4, 1), '#ffe066', { a: 0.8 })); } }
  lid.push(sh(Bl.cap, lg(...P3(xb, -106, 20), ...P3(xb, -78, 20), '#5a3a7a', '#2e1a3a')), ...onP(bat(0, 0, 18, '#1a0a24'), (a, b) => P3(xb + 0.5, -88 + b, 20 + a)), st(Bl.cap, ink, 2.4), st(line([P3(xa, yb, -1), P3(xb, yb, -1)]), ink, 2.4));
  const gx = 8, gst = [...ghost(gx, -66, 30, null, '#4a3a6a'), sh(parse(`M${gx - 15} -84 Q${gx} -88 ${gx + 15} -84`), 'rgba(0,0,0,0)', { s: 'rgba(80,60,120,0.4)', w: 1.2 })];
  const can = []; [[-50, 20], [24, 22]].forEach(([u, w], k) => { const p = cu.P((u - xa) / (xb - xa), 0.5 + (k ? 0.05 : -0.05)), x = p[0], y = p[1] + 2, r0 = rect(x - 4, y - 24 + k * 6, 8, 24 - k * 6, 2);
    can.push(sh(ell(x, y, 8, 2.6), '#2a1a2a', { s: ink, w: 1 }), sh(r0, lg(x - 4, 0, x + 4, 0, '#fff6e8', '#e8dcc8', '#b8a890'), { s: ink, w: 1 }), sh(parse(`M${x - 4} ${y - 24 + k * 6} Q${x - 3} ${y - 18 + k * 6} ${x - 2} ${y - 20 + k * 6} Q${x - 1} ${y - 14 + k * 6} ${x} ${y - 22 + k * 6} Z`), '#fff6e8'), st(line([[x, y - 24 + k * 6], [x, y - 28 + k * 6]]), '#2a1a1a', 1), ...flameG(x, y - 28 + k * 6, 12)); });
  const ch = [], n = 13; for (let i = 0; i <= n; i++) { const t = i / n, x = -82 + 134 * t, y = -40 + Math.sin(t * PI) * 10; ch.push(st(mapD(ell(0, 0, 5, 2.8), R2(x, y, 1, 0.05)), ink, 4), i % 2 ? st(line([[x - 3, y], [x + 3, y]]), '#9aa2b0', 2.4) : st(mapD(ell(0, 0, 5, 2.8), R2(x, y, 1, 0.05)), '#9aa2b0', 2.2)); }
  const pl = [-15, -24], pad = [st(parse(`M${pl[0] - 6} ${pl[1] - 8} Q${pl[0] - 6} ${pl[1] - 18} ${pl[0]} ${pl[1] - 18} Q${pl[0] + 6} ${pl[1] - 18} ${pl[0] + 6} ${pl[1] - 8}`), '#9aa2b0', 3), sh(rect(pl[0] - 9, pl[1] - 9, 18, 16, 3), ir(pl[0] - 9, 0, pl[0] + 9, 0), { s: ink, w: 1.2 }), sh(ell(pl[0], pl[1] - 2, 2), '#140820')];
  const cs = [corner3(B, -1, 1, 18, 6, 1.5, IRON, ink), corner3(B, 1, 1, 18, 6, 1.5, IRON, ink)];
  const lock = [sh(rect(-22, -88, 14, 22, 4), ir(-22, 0, -8, 0), { s: ink, w: 1.3 }), sh(ell(-15, -76, 4.6, 3.4), '#0a0414'), sh(ell(-17, -76.4, 1.3), '#ffe066', { s: '#ffe066', w: 0.4, g: '#ffe066', gb: 6 }), sh(ell(-13, -76.4, 1.3), '#ffe066')];
  const cob = [...web(-84, -78, 20, 1, 1), ...web(54, -78, 16, -1, 1)];
  return { name: 'Haunted Trunk', mat: 'haunt', hp: 10, W: 180, H: 150, ko: 'planks', rows: [[-200, -78], [-78, -40], [-40, 30]],
    hull: cvx(B.pts.concat(Bl.pts, [[can.length ? cu.P(0.26, 0.45)[0] : 0, cu.P(0.26, 0.45)[1] - 42], [cu.P(0.77, 0.55)[0], cu.P(0.77, 0.55)[1] - 38]])),
    parts: [{ id: 'body', sh: body }, { id: 'cob', sh: cob, tear: 0.3 }, { id: 'c0', sh: cs[0].sh, tear: 0.44 }, { id: 'c1', sh: cs[1].sh, tear: 0.8 }, { id: 'chain', sh: ch.concat(pad), tear: 0.56, hang: [-82, -40], loose: 0.3, hmax: 0.4, hdir: -1 },
      { id: 'lid', sh: lid, launch: true }, { id: 'ghost', sh: gst, tear: 0.46, hang: [gx, -84], loose: 0, hmax: 0.4, hdir: 1 }, { id: 'lock', sh: lock, tear: 0.9, hang: [-15, -86], loose: 0.6, hmax: 0.5, hdir: 1 }, { id: 'can', sh: can, launch: true, launchV: 420 }],
    loot: ['ghost', 'coin', 'candy', 'pumpkin', 'coin', 'star'] };
}

/* ---------- LEGENDARY: moonlit crypt chest ---------- */
function spookyCrypt() {
  const ink = '#10061e', gi = '#6a4200';
  const gw = (x, y, w, h) => { const d = parse(`M${x} ${y + h} L${x} ${y + h * 0.4} Q${x} ${y + h * 0.1} ${x + w / 2} ${y} Q${x + w} ${y + h * 0.1} ${x + w} ${y + h * 0.4} L${x + w} ${y + h} Z`); return [sh(d, rg(x + w / 2, y + h * 0.7, h, '#e0ffb0', '#7aff5a', '#1a8a3a')), ...bat(x + w / 2, y + h * 0.5, w * 0.7, '#14301a'), st(line([[x + w / 2, y + 3], [x + w / 2, y + h]]), gi, 1.4), st(d, gi, 4), st(d, gl(x, y, x + w, y + h), 2.2)]; };
  return vault({ name: 'Moonlit Crypt Chest', mat: 'crypt', ink, gi, C: { f: ['#9a7ac8', '#4a2a7a', '#24104a'], t: ['#aa8ad8', '#5a3a8a'], s: ['#3a1e64', '#140630'] }, LC: { f: ['#7a5aa8', '#3a1e64', '#1a0a36'], t: ['#8a6ab8', '#4a2a7a'], s: ['#2e1854', '#0e0424'] },
    front: () => [...gw(-84, -86, 26, 36), ...gw(24, -86, 26, 36), ...[-78, -58, 26, 46].map((x, i) => i % 2 ? sh(star5(x, -18, 5, 2.2), '#ffe066', { s: gi, w: 0.8 }) : sh(moonP(x + 3, -18, 5.5), '#ffe066', { s: gi, w: 0.8 })), ...web(-90, -88, 18, 1, 1)],
    side: () => gw(8, -86, 24, 34), band: [-46, 12, '#ffd08a', '#ff8a1a', '#a8400a'], gems: ['#7aff5a', '#c86cff'],
    lid: 'box', lidDeco: ({ L }) => [...onP([-70, -40, -10, 20, 48].map(u => sh(star5(u, 22, 3.6, 1.6), '#ffe066', { a: 0.85 })), L.pT), ...[-84, -60, -36, 24, 48].map(x => sh(spark4(x, -100, 2.4), '#ffe066'))],
    lidTop: ({ L }) => { const o = []; for (let x = -92; x <= 62; x += 16) { const a = L.pT(x - 4, 2), b = L.pT(x + 4, 2), c = L.pT(x, 2); o.push(sh(poly([a, b, [c[0], c[1] - 10]]), gl(a[0], a[1] - 10, b[0], b[1]), { s: gi, w: 1 })); } return o; },
    crest: T => [sh(ell(T[0], T[1] + 2, 22, 5), 'rgba(0,0,0,0.35)'), sh(moonP(T[0] + 12, T[1] - 28, 22), lg(T[0] - 10, T[1] - 50, T[0] + 12, T[1] - 6, '#fff6c0', '#ffd23a', '#c88a00'), { s: '#7a4800', w: 1.6 }), ...bat(T[0] + 4, T[1] - 14, 40, gl(T[0] - 16, T[1] - 26, T[0] + 24, T[1] - 4), '#7a4800'), sh(ell(T[0] + 1.6, T[1] - 18, 1.4), '#ff3a5a'), sh(ell(T[0] + 6.4, T[1] - 18, 1.4), '#ff3a5a')], crestH: 52,
    corner: (x, y) => jack(x, y, 8, null, '#5a2404'),
    med: cx => [st(line([[cx, -40], [cx, -36]]), gi, 2.2), sh(ell(cx + 1.4, -18.6, 14), 'rgba(0,0,0,0.35)'), sh(ell(cx, -20, 14), gl(cx - 14, -34, cx + 14, -6), { s: gi, w: 1.8 }), sh(ell(cx, -20, 10.5), rg(cx - 3, -23, 13, '#fff6c0', '#ffe066', '#e8a400')), ...bat(cx, -19, 16, '#2a1040')],
    loot: ['ghost', 'coin', 'gem', 'pumpkin', 'candy', 'star'] });
}

/* ---------- RAINBOW: phantom treasury ---------- */
function spookyPhantom() {
  const ik = '#8a5200';
  return treasury({ name: 'Rainbow Phantom Treasury', mat: 'phantom',
    art: [(x, y, s) => ghost(x, y + 2, s * 0.72, RBW(x, y), ik, { eye: '#4a1a5a' }), (x, y, s) => jack(x, y + 4, s * 0.32, RBW(x, y + 4), ik, { face: '#4a1a5a' }), (x, y, s) => bat(x, y, s * 0.86, RBW(x, y), ik), (x, y, s) => wrapC(x, y, s * 0.3, '#ff9ac0').map((q, i) => i === 2 ? Object.assign({}, q, { f: RBW(x, y) }) : q)],
    lid: ink => rbLid(ink, (u, w) => mixH(pal(u), '#3a1a6a', 0.32), { h: 42, k: 0.55, deco: cu => { const o = []; for (let k = 0; k < 22; k++) { const u = 0.06 + (k * 0.618) % 0.88, w = 0.08 + (k * 0.37) % 0.84; if (cu.visAt(u, w) > 0.1) { const p = cu.P(u, w); o.push(sh(k % 3 ? spark4(p[0], p[1], 2.4) : star5(p[0], p[1], 3.4, 1.5), '#ffffff', { a: 0.9 })); } } return o; } }),
    crest: (T, ink) => [sh(ell(T[0], T[1] + 2, 16, 4), 'rgba(60,0,80,0.3)'), ...jack(T[0], T[1] - 14, 15, gl(T[0] - 16, T[1] - 30, T[0] + 16, T[1]), '#7a4800', { face: '#4a2600' }), ...gemS(T[0] - 6, T[1] - 18, 2.6, '#7aff5a', ink), ...gemS(T[0] + 6, T[1] - 18, 2.6, '#7aff5a', ink)], crestH: 40,
    lock: (x, ink) => [sh(rect(x - 5, -97, 10, 14, 4), gl(x - 5, 0, x + 5, 0), { s: ink, w: 1.3 }), ...ghost(x, -64, 34, gl(x - 17, -86, x + 17, -46), '#7a4800', { eye: '#4a2600' }), sh(ell(x, -66, 4.4, 5), RBW(x, -66, 1.4), { s: '#7a4800', w: 0.8 })],
    loot: ['ghost', 'gem', 'pumpkin', 'candy', 'star', 'coin'] });
}

/* ---------- loot icons ---------- */
function icPumpkin(c, s) { const g = c.createRadialGradient(-s * 0.12, -s * 0.12, 0, 0, 0, s * 0.45); g.addColorStop(0, '#ffd08a'); g.addColorStop(1, '#e8600a'); c.fillStyle = g; c.strokeStyle = '#5a2404'; c.lineWidth = s * 0.05; c.beginPath(); c.ellipse(0, s * 0.04, s * 0.42, s * 0.36, 0, 0, TAU); c.fill(); c.stroke();
  c.fillStyle = '#3a1404'; [[-1], [1]].forEach(([d]) => { c.beginPath(); c.moveTo(d * s * 0.22, -s * 0.02); c.lineTo(d * s * 0.12, -s * 0.16); c.lineTo(d * s * 0.04, -s * 0.02); c.closePath(); c.fill(); }); c.beginPath(); c.moveTo(-s * 0.22, s * 0.1); c.quadraticCurveTo(0, s * 0.3, s * 0.22, s * 0.1); c.quadraticCurveTo(0, s * 0.18, -s * 0.22, s * 0.1); c.fill(); c.fillStyle = '#4a7a2a'; c.fillRect(-s * 0.04, -s * 0.42, s * 0.08, s * 0.12); }
function icGhost(c, s) { c.beginPath(); c.moveTo(-s * 0.3, s * 0.36); c.lineTo(-s * 0.3, -s * 0.06); c.quadraticCurveTo(-s * 0.3, -s * 0.4, 0, -s * 0.4); c.quadraticCurveTo(s * 0.3, -s * 0.4, s * 0.3, -s * 0.06); c.lineTo(s * 0.3, s * 0.36); c.lineTo(s * 0.15, s * 0.26); c.lineTo(0, s * 0.36); c.lineTo(-s * 0.15, s * 0.26); c.closePath();
  const g = c.createLinearGradient(0, -s * 0.4, 0, s * 0.4); g.addColorStop(0, '#ffffff'); g.addColorStop(1, '#d8d0f4'); c.fillStyle = g; c.fill(); c.strokeStyle = '#4a3a6a'; c.lineWidth = s * 0.05; c.stroke(); c.fillStyle = '#2a1a3a'; [-0.1, 0.1].forEach(x => { c.beginPath(); c.ellipse(x * s, -s * 0.1, s * 0.04, s * 0.06, 0, 0, TAU); c.fill(); }); }

const Cd = CM.MAT.candy, Mt = CM.MAT.metal, W = CM.MAT.wood;
CM.register('spooky', [spookyPail, spookyCoffin, spookyTrunk, spookyCrypt, spookyPhantom], {
  mat: {
    pail: { soft: 1.1, lean: 6, sag: 4, dentK: 6, dentShade: 0.26, holeFrom: 0.24, holeP: 0.7, holeR: [15, 21], jag: 'shard', edge: '#ffe0b0', edgeW: 5, crack: 'stress', chips: ['#ff8a1a', '#e8700a', '#a05cff', '#5aff7a', '#ffd23a'], deb: 'chip', dust: '#f4e6d8', mass: 0.8, sfx: { m: 'plastic', p: 1, x: ['ghost'] }, rest: 0.3, cav: ['#1a0602', '#3a1404'], glow: '#ffb050' },
    coffin: Object.assign({}, W, { chips: ['#7a5a8a', '#4a2e5a', '#2e1a3a', '#ffd23a'], dust: '#e2dae8', sfx: { m: 'pine', p: 0.95, x: ['creak'] }, cav: ['#08020e', '#1a0a24'], glow: '#a8ff8a' }),
    haunt: Object.assign({}, W, { chips: ['#7a5a8a', '#5a3e6a', '#9aa2b0', '#ffffff', '#7aff5a'], dust: '#e4dcea', sfx: { m: 'wood', p: 0.85, x: ['creak', 'ghost'] }, cav: ['#06020c', '#160a22'], glow: '#a8ff8a' }),
    crypt: Object.assign({}, Mt, { jag: 'ragged', crack: 'split', deb: 'chip', chips: ['#4a2a7a', '#9a7ac8', '#ff8a1a', '#ffd23a', '#7aff5a'], dust: '#e4dcf0', sfx: { m: 'iron', p: 0.9, x: ['creak', 'ghost'] }, cav: ['#06020c', '#160a22'], glow: '#a8ff8a' }),
    phantom: Object.assign({}, Cd, { sfx: { m: 'crystal', p: 0.9, x: ['rainbow', 'ghost'] } }),
  },
  crack: { stress: [['rgba(255,255,255,0.85)', 2, 0, 0], ['rgba(60,20,0,0.3)', 1, 1, 1]] },
  icons: { pumpkin: icPumpkin, ghost: icGhost },
});
}
(function go() { if (window.ChestModels && window.ChestModels.K) run(); else setTimeout(go, 30); })();
})();
