// Sweet Bakery chests for ChestModels: Bakery Pastry Box -> Cookie Tin -> Layer Cake Chest -> Glass Cloche Patisserie -> Rainbow Swirl Sugar Treasury.
(function () {
'use strict';
function run() {
const CM = window.ChestModels, H = CM.H, K = CM.K;
const { parse, poly, line, rect, ell, shift, spark4, star5, lg, rg, sh, st, tx, P3, mapD, mp, mlg, onP, Box, cvx, boxFill, boxShade } = H;
const { PI, TAU, mixH, R2, gl, gemS, heart, ball, rev, disc, ringP, cylP, onCyl, vault, treasury, rbLid, pal, RBW, clipAll, revE, pE, discE, ringE, onCylE, shadeE, silE, arcE } = K;
const SPR = ['#ff5ca8', '#3aa8ff', '#ffd23a', '#3ad08a', '#a05cff'];
function cupcake(x, y, s, o) {
  o = o || {}; const ink = o.ink || '#6a3a24', lw = Math.max(0.8, s * 0.06), w = parse(`M${x - s * 0.5} ${y - s * 0.55} L${x + s * 0.5} ${y - s * 0.55} L${x + s * 0.38} ${y} L${x - s * 0.38} ${y} Z`), out = [sh(w, o.wrap || lg(x - s * 0.5, 0, x + s * 0.5, 0, '#ffb0cc', '#e8608a'), { s: ink, w: lw })];
  for (let k = 1; k < 5; k++) { const t = k / 5; out.push(st(line([[x - s * 0.5 + s * t, y - s * 0.55], [x - s * 0.38 + s * 0.76 * t, y]]), 'rgba(120,20,60,0.4)', lw * 0.8)); }
  const fr = parse(`M${x - s * 0.58} ${y - s * 0.52} Q${x - s * 0.7} ${y - s * 0.86} ${x - s * 0.3} ${y - s * 0.92} Q${x - s * 0.3} ${y - s * 1.24} ${x + s * 0.05} ${y - s * 1.2} Q${x + s * 0.42} ${y - s * 1.2} ${x + s * 0.32} ${y - s * 0.9} Q${x + s * 0.7} ${y - s * 0.84} ${x + s * 0.58} ${y - s * 0.52} Q${x} ${y - s * 0.42} ${x - s * 0.58} ${y - s * 0.52} Z`);
  out.push(sh(fr, o.fr || rg(x - s * 0.2, y - s, s * 0.8, '#ffffff', '#fff2e0', '#e8d0b8'), { s: ink, w: lw }), st(parse(`M${x - s * 0.4} ${y - s * 0.7} Q${x} ${y - s * 0.84} ${x + s * 0.4} ${y - s * 0.68}`), 'rgba(140,90,60,0.35)', lw));
  if (o.spr !== false) [[-0.3, -0.75, 0.4], [0.1, -0.98, -0.6], [0.3, -0.72, 1.2], [-0.08, -0.7, 2]].forEach(([a, b, r], i) => { const p = [x + a * s, y + b * s], d = s * 0.07; out.push(st(line([[p[0] - Math.cos(r) * d, p[1] - Math.sin(r) * d], [p[0] + Math.cos(r) * d, p[1] + Math.sin(r) * d]]), SPR[i], Math.max(1, s * 0.07))); });
  out.push(sh(ell(x + s * 0.04, y - s * 1.28, s * 0.14), o.cherry || rg(x, y - s * 1.32, s * 0.17, '#ff8a8a', '#e5203a', '#8a0a1a'), { s: ink, w: lw * 0.8 }), st(parse(`M${x + s * 0.04} ${y - s * 1.4} Q${x + s * 0.1} ${y - s * 1.55} ${x + s * 0.22} ${y - s * 1.58}`), '#5a3a14', lw * 0.8));
  return out;
}
const cookie = (x, y, rx, ry, ink, o) => { o = o || {}; const out = [sh(ell(x, y, rx, ry), o.f || rg(x - rx * 0.3, y - ry * 0.3, rx * 1.3, '#f6c886', '#d89a50', '#a86a2a'), { s: ink, w: 1.2 })]; [[-0.4, -0.3], [0.3, -0.4], [0.1, 0.2], [-0.3, 0.4], [0.5, 0.25]].forEach(([a, b]) => out.push(sh(ell(x + a * rx, y + b * ry, rx * 0.12, ry * 0.12), o.chip || '#5a2a10'))); return out; };
const macaron = (x, y, s, c, ink) => [sh(ell(x, y + s * 0.22, s * 0.5, s * 0.22), lg(x - s * 0.5, 0, x + s * 0.5, 0, mixH(c, '#ffffff', 0.3), c, mixH(c, '#20002a', 0.3)), { s: ink, w: 1 }), sh(rect(x - s * 0.46, y - s * 0.06, s * 0.92, s * 0.14, s * 0.07), '#fff6e8', { s: ink, w: 0.8 }), sh(ell(x, y - s * 0.16, s * 0.5, s * 0.24), rg(x - s * 0.15, y - s * 0.3, s * 0.6, mixH(c, '#ffffff', 0.5), c, mixH(c, '#20002a', 0.25)), { s: ink, w: 1 }), st(parse(`M${x - s * 0.44} ${y - s * 0.02} Q${x} ${y + s * 0.06} ${x + s * 0.44} ${y - s * 0.02}`), 'rgba(255,255,255,0.5)', 1)];
const donut = (x, y, s, glaze, ink) => { const R = s * 0.5, out = [sh(ell(x, y, R, R * 0.9), rg(x - R * 0.3, y - R * 0.3, R * 1.4, '#f6c886', '#d89a50', '#a86a2a'), { s: ink, w: 1.2 }), sh(parse(`M${x - R * 0.92} ${y - R * 0.05} Q${x - R * 0.9} ${y - R * 0.86} ${x} ${y - R * 0.84} Q${x + R * 0.9} ${y - R * 0.86} ${x + R * 0.92} ${y - R * 0.05} Q${x + R * 0.7} ${y + R * 0.2} ${x + R * 0.5} ${y + R * 0.05} Q${x + R * 0.3} ${y + R * 0.5} ${x} ${y + R * 0.3} Q${x - R * 0.4} ${y + R * 0.55} ${x - R * 0.55} ${y + R * 0.1} Q${x - R * 0.8} ${y + R * 0.25} ${x - R * 0.92} ${y - R * 0.05} Z`), glaze, { s: ink, w: 1 })];
  [[-0.5, -0.4, 0.3], [0.4, -0.5, -0.6], [0.6, -0.1, 1.2], [-0.2, -0.65, 2], [-0.65, 0, -0.3], [0.15, 0.2, 0.8]].forEach(([a, b, r], i) => { const p = [x + a * R, y + b * R], d = R * 0.12; out.push(st(line([[p[0] - Math.cos(r) * d, p[1] - Math.sin(r) * d], [p[0] + Math.cos(r) * d, p[1] + Math.sin(r) * d]]), i % 2 ? '#ffffff' : SPR[i % 5], Math.max(1, R * 0.1))); });
  out.push(sh(ell(x, y - R * 0.1, R * 0.3, R * 0.24), '#4a2410', { s: ink, w: 1 })); return out; };

/* ---------- COMMON: bakery pastry box ---------- */
function bakeryBox() {
  const ink = '#6a3a24', B = Box(-48, -84, 40, 0, 26), S = d => B.side(d), sx = 28;
  const body = [...boxFill(B, { f: ['#ffffff', '#fbf2e8', '#e8d8c4'], t: ['#ffffff', '#f6ece0'], s: ['#efe2d2', '#cdb8a0'] })];
  for (let i = 0; i < 11; i += 2) body.push(sh(rect(-48 + i * 8, -84, 8, 84), 'rgba(122,216,192,0.5)'));
  body.push(...onP([0, 2].map(i => sh(rect(i * 8.6, -84, 8.6, 84), 'rgba(90,180,160,0.5)')), B.pS));
  const win = rect(-40, -70, 52, 34, 7);
  body.push(sh(win, lg(0, -70, 0, -36, '#7a4a30', '#4a2814')), ...clipAll([...cupcake(-27, -38, 15, { ink }), ...cupcake(-1, -38, 15, { ink, wrap: lg(-8, 0, 6, 0, '#a8e8ff', '#4aa8e8'), fr: rg(-3, -52, 12, '#fff0f6', '#ffb0cc', '#e8608a') })], win),
    sh(win, lg(-40, -70, 0, -36, [0, 'rgba(255,255,255,0.45)'], [0.35, 'rgba(255,255,255,0.08)'], [0.36, 'rgba(255,255,255,0)'], [1, 'rgba(255,255,255,0.12)'])), st(line([[-34, -48], [-18, -66]]), 'rgba(255,255,255,0.7)', 2.4, { clip: win }), st(win, ink, 2.2),
    tx('SQUISH', -18, -27, '700 8px Fredoka, Nunito, sans-serif', '#c8507a'), tx('BAKERY', -18, -17.6, '700 9.5px Fredoka, Nunito, sans-serif', '#6a3a24'));
  for (let x = -48; x < 40; x += 8) body.push(sh(parse(`M${x} -84 Q${x + 4} -77 ${x + 8} -84 Z`), '#7ad8c0', { s: 'rgba(40,120,100,0.5)', w: 0.8 }));
  body.push(...boxShade(B, ink, { k: 0.8 }));
  const rope = d => [st(d, '#8a1a1a', 3.6), st(d, '#e5303a', 2.2), st(shift(d, -0.5, -0.5), 'rgba(255,255,255,0.55)', 0.8)];
  const string = [...rope(line([[sx, -84], [sx, 0]])), ...rope(B.top(line([[sx, 0], [sx, 26]]))), ...rope(B.top(line([[-48, 13], [40, 13]]))), ...rope(S(line([[13, -84], [13, 0]])))];
  const bp = B.pT(sx, 13), bow = [sh(parse(`M${bp[0]} ${bp[1]} C${bp[0] - 16} ${bp[1] - 14} ${bp[0] - 18} ${bp[1] + 6} ${bp[0]} ${bp[1]} C${bp[0] + 16} ${bp[1] - 14} ${bp[0] + 18} ${bp[1] + 6} ${bp[0]} ${bp[1]} Z`), lg(bp[0] - 18, 0, bp[0] + 18, 0, '#ff7a80', '#e5303a', '#ff7a80'), { s: '#8a1a1a', w: 1.4 }),
    st(parse(`M${bp[0]} ${bp[1]} Q${bp[0] - 6} ${bp[1] + 8} ${bp[0] - 10} ${bp[1] + 14}`), '#e5303a', 2.4), st(parse(`M${bp[0]} ${bp[1]} Q${bp[0] + 6} ${bp[1] + 8} ${bp[0] + 8} ${bp[1] + 15}`), '#e5303a', 2.4), sh(ell(bp[0], bp[1], 3.4, 3), '#ff5a60', { s: '#8a1a1a', w: 1.2 })];
  const seal = [sh(ell(16.6, -16.6, 8.6), 'rgba(80,30,10,0.25)'), sh(star5(16, -18, 9.5, 7.6), gl(7, -27, 25, -9), { s: '#8a5a00', w: 1 }), sh(heart(16, -18.6, 3.6), '#e5303a')];
  return { name: 'Bakery Pastry Box', mat: 'cakebox', hp: 6, W: 112, H: 137, ko: 'halves',
    hull: cvx(B.pts.concat([[bp[0] - 18, bp[1] - 10], [bp[0] + 18, bp[1] - 10], [bp[0] + 10, bp[1] + 16]])),
    parts: [{ id: 'body', sh: body }, { id: 'string', sh: string, tear: 0.6, hang: bp, loose: 0.3, hmax: 0.4, hdir: 1 }, { id: 'seal', sh: seal, tear: 0.34 }, { id: 'bow', sh: bow, launch: true, launchV: 400 }],
    loot: ['cupcake', 'coin', 'cookie', 'candy'] };
}

/* ---------- RARE: cookie tin ---------- */
function bakeryTin() {
  const ink = '#0e2a6a', X = 2, k = 0.36, r = 54, yL = -58, rl = 56.5, yT = -78;
  const tin = revE(X, v => [r, yL * v], 44, 3, () => '#3a6ad8', { k, dk: '#081a50' }), body = [...tin.sh];
  const bead = (R, y, c) => { const p = line(arcE(X, R, y, k, PI, TAU, 30)); return [st(p, '#0e2a6a', 3.6), st(p, c, 2.2), st(shift(p, 0, -1), 'rgba(255,255,255,0.7)', 0.8)]; };
  const flake = (x, y, s) => { const o = []; for (let q = 0; q < 3; q++) { const a = q * PI / 3; o.push(st(line([[x - Math.cos(a) * s, y - Math.sin(a) * s], [x + Math.cos(a) * s, y + Math.sin(a) * s]]), '#ffffff', 1.6)); } o.push(sh(ell(x, y, 1.6), '#ffffff')); return o; };
  body.push(...onCylE(X, r + 0.3, [sh(rect(-90, -50, 180, 34), 'rgba(255,255,255,0.12)'), ...[-66, -40, -14, 14, 40, 66].flatMap((a, i) => i % 2 ? flake(a, -33, 7.5) : cookie(a, -33, 10, 9.5, '#6a3a14')), tx('COOKIES', 0, -46, '700 9px Fredoka, Nunito, sans-serif', '#ffffff')], 0, k));
  body.push(...onCylE(X, r + 0.3, [-36, -12, 12, 36].map(x => sh(star5(x, -10, 2.8, 1.2), '#ffe066')), 0, k), ...shadeE(X, r, 0, yL, k, { dk: 0.45 }), ...bead(r + 0.6, -3, '#ffd23a'), ...bead(r + 0.6, -50, '#ffd23a'), st(silE(X, r, 0, yL, k), ink, 2.4));
  const ls = revE(X, v => [rl, yL + (yT - yL) * v], 44, 2, () => '#2a58c8', { k, dk: '#081a50' }), lid = [...ls.sh, ...shadeE(X, rl, yL, yT, k, { dk: 0.45 }), ...bead(rl + 0.5, yL - 3, '#ffffff'), st(silE(X, rl, yL, yT, k), ink, 2.4)];
  const TP = d => mapD(d, (x, y) => [X + x, yT + k * y]);
  lid.push(sh(discE(X, rl, yT, k, 48), lg(X - rl, yT - k * rl, X + rl, yT + k * rl, '#7aa0ff', '#3a6ad8', '#2448b0'), { s: ink, w: 2 }), sh(TP(ell(0, 0, rl - 7)), 'rgba(0,0,0,0)', { s: 'rgba(255,255,255,0.55)', w: 2 }), sh(TP(ell(0, 0, 42)), lg(X - 42, 0, X + 42, 0, '#ffffff', '#eef2fa', '#c8d4ec'), { s: '#ffd23a', w: 2.8 }), st(TP(ell(0, 0, 38)), 'rgba(58,106,216,0.35)', 1.2));
  const ck3 = (px, pz, R, t) => { const c = [X + px, yT + k * pz], o = [sh(ell(c[0], c[1] - t + 3, R, R * k * 1.15), '#8a5426'), sh(rect(c[0] - R, c[1] - t, R * 2, 3), '#a86a2a')]; o.push(...cookie(c[0], c[1] - t, R, R * k * 1.15, '#6a3a14')); return o; };
  lid.push(...ck3(-16, 10, 14, 1), ...ck3(16, 12, 14, 1), ...ck3(0, -12, 14, 1), ...ck3(-4, 2, 13, 5));
  lid.push(sh(TP(ell(-22, 22, 12, 6)), 'rgba(255,255,255,0.4)'));
  const rbF = d => onCylE(X, r + 0.8, [sh(rect(24, -58, 9, 58), lg(24, 0, 33, 0, '#ff7a80', '#e5303a', '#a8141e'), { s: '#6a0a10', w: 1 })], 0, k), rb = pE(X, rl + 1, -PI / 2 + 28.5 / rl, yT + 1, k);
  const ribbon = [...rbF(), ...onCylE(X, rl + 0.8, [sh(rect(24, -78, 9, 20), lg(24, 0, 33, 0, '#ff7a80', '#e5303a', '#a8141e'), { s: '#6a0a10', w: 1 })], 0, k),
    sh(parse(`M${rb[0]} ${rb[1]} C${rb[0] - 16} ${rb[1] - 14} ${rb[0] - 18} ${rb[1] + 6} ${rb[0]} ${rb[1]} C${rb[0] + 16} ${rb[1] - 14} ${rb[0] + 18} ${rb[1] + 6} ${rb[0]} ${rb[1]} Z`), lg(rb[0] - 18, 0, rb[0] + 18, 0, '#ff7a80', '#e5303a', '#ff7a80'), { s: '#6a0a10', w: 1.4 }), sh(ell(rb[0], rb[1], 3.6, 3.2), '#ff5a60', { s: '#6a0a10', w: 1.2 })];
  const tag = [st(parse(`M${rb[0]} ${rb[1]} Q${rb[0] + 4} ${rb[1] + 10} ${rb[0] + 6} ${rb[1] + 18}`), '#8a1a1a', 1.2), sh(rect(rb[0] - 2, rb[1] + 18, 18, 14, 3), '#fff6e8', { s: ink, w: 1.2 }), sh(heart(rb[0] + 7, rb[1] + 25, 3.6), '#e5303a')];
  const ck = [X + r + 8, -14], ckS = [sh(ell(ck[0] + 3, ck[1] + 14, 15, 3), 'rgba(40,20,10,0.25)'), sh(ell(ck[0] + 3.5, ck[1] + 0.5, 14, 13.5), '#8a5426', { s: '#6a3a14', w: 1.2 }), ...cookie(ck[0], ck[1], 14, 13.5, '#6a3a14'), sh(ell(ck[0] + 12, ck[1] - 9, 6, 5), '#fdf1e4')];
  return K.liftM({ name: 'Cookie Tin', mat: 'tin', hp: 8, W: 150, H: 140, ko: 'pie', pieN: 6,
    hull: cvx(tin.pts.concat(ls.pts, ringE(X, rl, yT, k), [[ck[0] - 15, ck[1] + 14], [ck[0] + 18, ck[1] + 14], [ck[0] + 18, ck[1] - 14]])),
    parts: [{ id: 'body', sh: body }, { id: 'ck', sh: ckS, tear: 0.46 }, { id: 'lid', sh: lid, launch: true }, { id: 'ribbon', sh: ribbon, tear: 0.3 }, { id: 'tag', sh: tag, tear: 0.62, hang: rb, loose: 0, hmax: 0.6, hdir: 1 }],
    loot: ['cookie', 'coin', 'cookie', 'cupcake', 'candy'] }, -k * r);
}

/* ---------- EPIC: layer cake chest ---------- */
function bakeryCake() {
  const ink = '#5a2a1a', B = Box(-84, -72, 54, 0, 40), S = d => B.side(d), L = Box(-88, -86, 58, -72, 44, -2);
  const LAY = [[-72, -60, '#fff2d0', '#f0d8a0'], [-60, -55, '#ffffff', '#f2e6e6'], [-55, -40, '#ff9ab8', '#e86a90'], [-40, -35, '#ffffff', '#f2e6e6'], [-35, -20, '#b0703e', '#7a4220'], [-20, -15, '#ffffff', '#f2e6e6'], [-15, 0, '#fff2d0', '#f0d8a0']];
  const body = [];
  LAY.forEach(([y0, y1, c0, c1]) => body.push(sh(rect(-84, y0, 138, y1 - y0), lg(0, y0, 0, y1, c0, c1)), sh(S(rect(0, y0, 40, y1 - y0)), mlg(S, 0, y0, 0, y1, mixH(c0, '#000000', 0.1), mixH(c1, '#000000', 0.2)))));
  for (let i = 0; i < 30; i++) { const x = -80 + (i * 47) % 130, y = [-66, -9, -28][i % 3] + ((i * 13) % 7) - 3; body.push(sh(ell(x, y, 1.2 + (i % 3) * 0.4, 0.9), i % 3 === 2 ? 'rgba(60,20,5,0.4)' : 'rgba(170,110,40,0.35)')); }
  [-70, -42, 2, 30].forEach(x => body.push(sh(parse(`M${x - 7} -42 Q${x} -54 ${x + 7} -42 Q${x} -38 ${x - 7} -42 Z`), lg(x, -54, x, -40, '#ff6a6a', '#d8202a'), { s: '#8a0a14', w: 0.8 }), sh(ell(x, -44, 3, 2), '#ffd0d0'), ...[[-3, -46], [3, -46], [0, -49]].map(([a, b]) => sh(ell(x + a, b, 0.7, 1), '#ffe066'))));
  body.push(...boxShade(B, ink, { only: 'FS', k: 0.7, noBevel: true }));
  const DR = [[-80, 10], [-66, 18], [-54, 8], [-36, 22], [-16, 12], [4, 26], [20, 9], [36, 17], [50, 10]], dy = x => { let m = 0; DR.forEach(([xd, l]) => { const k = 1 - ((x - xd) / 5.5) ** 2; if (k > 0) m = Math.max(m, l * Math.sqrt(k)); }); return m; };
  const dp = [[-88, -73]]; for (let x = -88; x <= 58; x += 1.5) dp.push([x, -72 + dy(x)]); dp.push([58, -73]);
  const DS = [[8, 14], [20, 22], [32, 10]], dys = w => { let m = 0; DS.forEach(([wd, l]) => { const k = 1 - ((w - wd) / 4.5) ** 2; if (k > 0) m = Math.max(m, l * Math.sqrt(k)); }); return m; }, sp = [[0, -73]]; for (let w = 0; w <= 40; w += 1.5) sp.push([w, -72 + dys(w)]); sp.push([40, -73]);
  const FR = { f: ['#ffe6f0', '#ffb8d0', '#f088ac'], t: ['#fff0f6', '#ffc8dc'], s: ['#f098b8', '#c85c84'] };
  const lid = [sh(B.side(poly(sp)), mlg(S, 0, -72, 0, -50, '#ffb8d0', '#e8789c'), { s: '#b04870', w: 1 }), sh(poly(dp), lg(0, -72, 0, -46, '#ffc8dc', '#f088ac'), { s: '#b04870', w: 1.2 }), ...boxFill(L, FR)];
  DR.forEach(([x, l]) => lid.push(sh(ell(x - 1.2, -72 + l - 3, 1.2, 2), 'rgba(255,255,255,0.6)')));
  for (let i = 0; i < 44; i++) { const u = -84 + (i * 37) % 138, w = 4 + (i * 23) % 36, a = i * 1.7; lid.push(...onP([st(line([[u - Math.cos(a) * 2.4, w - Math.sin(a) * 2.4], [u + Math.cos(a) * 2.4, w + Math.sin(a) * 2.4]]), SPR[i % 5], 2.2)], L.pT)); }
  lid.push(...boxShade(L, '#b04870', { k: 0.7 }));
  for (let x = -84; x <= 54; x += 11) { const p = L.pT(x, 3); lid.push(sh(ell(p[0], p[1] - 2, 6, 4.4), rg(p[0] - 2, p[1] - 4, 7, '#ffffff', '#fff2f6', '#f0c0d0'), { s: '#c87090', w: 1 }), st(parse(`M${p[0] - 3} ${p[1] - 3} Q${p[0]} ${p[1] - 6} ${p[0] + 3} ${p[1] - 3}`), 'rgba(200,110,140,0.5)', 0.9)); }
  for (let w = 8; w <= 40; w += 10) { const p = L.pT(55, w); lid.push(sh(ell(p[0], p[1] - 2, 5, 4), rg(p[0] - 2, p[1] - 4, 6, '#ffffff', '#fff2f6', '#f0c0d0'), { s: '#c87090', w: 1 })); }
  const chs = [[-60, 3], [-2, 3], [40, 3]].map(([u, w]) => L.pT(u, w)), cher = []; chs.forEach(([x, y]) => cher.push(st(parse(`M${x} ${y - 8} Q${x + 3} ${y - 16} ${x + 8} ${y - 18}`), '#5a3a14', 1.4), sh(ell(x, y - 7, 5.5), rg(x - 2, y - 9, 7, '#ff9a9a', '#e5203a', '#8a0a1a'), { s: '#5a0a10', w: 1 }), sh(ell(x - 1.8, y - 9, 1.6, 1.1), 'rgba(255,255,255,0.85)')));
  const can = []; [[-52, 24, '#7ad8c0'], [-15, 26, '#ffd23a'], [22, 24, '#8ab4ff']].forEach(([u, w, c]) => { const p = L.pT(u, w), x = p[0], y = p[1], r0 = rect(x - 3.6, y - 26, 7.2, 26, 1.5);
    can.push(sh(ell(x, y, 5, 2), 'rgba(120,40,70,0.3)'), sh(r0, lg(x - 3.6, 0, x + 3.6, 0, mixH(c, '#ffffff', 0.4), c, mixH(c, '#20002a', 0.3)), { s: ink, w: 1 }), ...[0, 1, 2, 3].map(k => st(line([[x - 3.6, y - 4 - k * 6], [x + 3.6, y - 8 - k * 6]]), 'rgba(255,255,255,0.75)', 1.6, { clip: r0 })), st(line([[x, y - 26], [x, y - 30]]), '#3a2a1a', 1),
      sh(parse(`M${x} ${y - 42} Q${x + 5} ${y - 34} ${x} ${y - 29} Q${x - 5} ${y - 34} ${x} ${y - 42} Z`), rg(x, y - 33, 7, '#ffffff', '#ffe066', '#ff8a1a'), { g: '#ffb020', gb: 10 }), sh(ell(x, y - 33, 1.6, 2.6), '#ffffff')); });
  const wp = P3(54, -60, 30), f = R2(wp[0] + 8, wp[1] + 10, 1, -1.2), wafer = [sh(mapD(rect(-26, -4, 52, 8, 4), f), lg(...f(0, -4), ...f(0, 4), '#f6d0a0', '#c8884a', '#8a5426'), { s: ink, w: 1.2 }), ...[-16, -6, 4, 14].map(a => st(mapD(line([[a, -4], [a + 6, 4]]), f), 'rgba(110,60,20,0.5)', 1)), sh(mapD(ell(26, 0, 2.6, 4), f), '#5a2a10')];
  const plq = [st(line([[-15, -66], [-15, -62]]), '#3a1a08', 1.4), sh(rect(-35, -62, 40, 20, 5), lg(0, -62, 0, -42, '#8a5430', '#5a2e14', '#3a1a08'), { s: '#2a1004', w: 1.4 }), st(rect(-32, -59, 34, 14, 3), 'rgba(255,220,180,0.35)', 1), tx('YUM!', -15, -51.6, '700 10px Fredoka, Nunito, sans-serif', '#ffe8f0')];
  return { name: 'Layer Cake Chest', mat: 'frosting', hp: 10, W: 180, H: 150, ko: 'pie', pieN: 6,
    hull: cvx(B.pts.concat(L.pts, [[chs[0][0], chs[0][1] - 20], ...can.length ? [L.pT(-52, 24), L.pT(22, 24)].map(p => [p[0], p[1] - 44]) : [], f(-26, 0), f(26, 0)])),
    parts: [{ id: 'body', sh: body }, { id: 'lid', sh: lid, launch: true }, { id: 'wafer', sh: wafer, tear: 0.55 }, { id: 'cher', sh: cher, tear: 0.4 }, { id: 'plq', sh: plq, tear: 0.9, hang: [-15, -64], loose: 0.6, hmax: 0.5, hdir: 1 }, { id: 'can', sh: can, launch: true, launchV: 420 }],
    loot: ['cupcake', 'coin', 'donut', 'cookie', 'candy', 'star'] };
}

/* ---------- LEGENDARY: glass cloche patisserie ---------- */
function bakeryCloche() {
  const ink = '#0e4a3a', gi = '#6a4200', MAC = ['#ffb0cc', '#b8f0a0', '#c8b0ff', '#ffe08a'];
  const pipe = (x0, x1, y) => { const p = []; for (let x = x0; x <= x1; x += 2) p.push([x, y + Math.sin((x - x0) * 0.55) * 2.2]); return [st(line(p), 'rgba(60,140,120,0.5)', 4.4), st(line(p), '#ffffff', 3), st(shift(line(p), -0.5, -0.8), 'rgba(255,255,255,0.9)', 1)]; };
  const nich = (x, y, r, c) => [sh(ell(x, y, r), rg(x + 2, y + 2, r * 1.2, '#e0fff8', '#8ae8d0')), st(ell(x, y, r), gi, 4.2), st(ell(x, y, r), gl(x - r, y - r, x + r, y + r), 2.4), ...macaron(x, y + 2, r * 1.3, c, '#6a3a24')];
  return vault({ name: 'Glass Cloche Patisserie', mat: 'cloche', ink, gi, C: { f: ['#d0fff2', '#6ad8bc', '#2a9a80'], t: ['#e0fff8', '#8ae8d0'], s: ['#4ab8a0', '#1e7a66'] },
    front: () => [...pipe(-88, 56, -80), ...pipe(-88, 56, -16), ...nich(-69, -64, 12, MAC[0]), ...nich(35, -64, 12, MAC[1]), ...[-82, -56, 22, 48].map((x, i) => sh(heart(x, -27, 4), '#ff8ab0', { s: '#c8507a', w: 0.8 }))],
    side: () => [...nich(21, -64, 11, MAC[2]), ...pipe(2, 40, -80).map(s => s), ...pipe(2, 40, -16)], band: [-46, 12, '#ffe0ec', '#ff9ac0', '#c8507a'], gems: ['#ffffff', '#ffd23a'],
    lid: 'dome', dh: 58, dk2: 0.7, lidA: 0.3, dk: '#2a6a80', lidCol: () => '#dff6ff',
    lidUnder: () => { const o = [], cx = -16, cz = 21, t1 = rev(cx, cz, v => [28, -88 - v * 18], 24, 2, () => '#ffb8d0', { dk: '#6a1a40' }), t2 = rev(cx, cz, v => [18, -106 - v * 15], 20, 2, () => '#fff6ee', { dk: '#6a3a20' });
      o.push(sh(disc(cx, cz, 34, -88, 32), gl(...P3(cx - 34, -88, cz), ...P3(cx + 34, -88, cz)), { s: gi, w: 1.2 }), ...t1.sh, sh(disc(cx, cz, 28, -106, 32), '#ffc8dc', { s: '#c8507a', w: 1 }));
      for (let k = 0; k < 8; k++) { const a = -2.6 + k * 0.42, p = P3(cx + 28 * Math.cos(a), -106, cz + 28 * Math.sin(a)); if (Math.sin(a) < 0.3) o.push(sh(ell(p[0], p[1] + 4, 2.4, 4.6), '#ffc8dc')); }
      o.push(...t2.sh, sh(disc(cx, cz, 18, -121, 28), '#ffffff', { s: '#c8a080', w: 1 }));
      [[-6, -2], [6, -3], [0, 8]].forEach(([a, b]) => { const p = P3(cx + a, -121, cz + b); o.push(sh(ell(p[0], p[1] - 3, 3.6), rg(p[0] - 1, p[1] - 4, 4.4, '#ff9a9a', '#e5203a', '#8a0a1a'), { s: '#5a0a10', w: 0.8 })); }); return o; },
    lidDeco: ({ cu }) => { const o = []; [[0.2, 0.25, 0.75], [0.3, 0.3, 0.6]].forEach(([u, w0, w1], i) => cu.lineOn(Array.from({ length: 9 }, (_, k) => [u + k * 0.01, w0 + (w1 - w0) * k / 8]), 0).forEach(p => o.push(st(p, 'rgba(255,255,255,0.85)', i ? 2 : 4)))); return o; },
    crest: T => [st(line([[T[0], T[1]], [T[0], T[1] - 8]]), gi, 5), st(line([[T[0], T[1]], [T[0], T[1] - 8]]), gl(T[0] - 2, 0, T[0] + 2, 0), 3), sh(ell(T[0], T[1] + 1, 9, 3.4), gl(T[0] - 9, T[1] - 2, T[0] + 9, T[1] + 4), { s: gi, w: 1.2 }), ...ball(T[0], T[1] - 15, 8.5, gi), ...gemS(T[0], T[1] - 15, 2.8, '#ff5c9a', gi)], crestH: 30,
    corner: (x, y, i) => macaron(x, y + 2, 17, MAC[i], '#6a3a24'),
    med: cx => [st(line([[cx, -40], [cx, -36]]), gi, 2.2), sh(ell(cx + 1.4, -18.6, 14), 'rgba(0,30,20,0.3)'), sh(ell(cx, -20, 14), gl(cx - 14, -34, cx + 14, -6), { s: gi, w: 1.8 }), ...cupcake(cx, -11, 14, { ink: '#7a4800', wrap: lg(cx - 7, 0, cx + 7, 0, '#ffe8a0', '#c88a00'), fr: rg(cx - 3, -24, 10, '#fff6c0', '#ffd23a', '#c88a00'), spr: false, cherry: rg(cx, -29, 3, '#ff9a9a', '#e5203a') })],
    loot: ['cupcake', 'coin', 'gem', 'donut', 'cookie', 'star'] });
}

/* ---------- RAINBOW: swirl sugar treasury ---------- */
function bakerySwirl() {
  const ik = '#8a5200';
  return treasury({ name: 'Rainbow Swirl Sugar Treasury', mat: 'sugargem',
    art: [(x, y, s) => cupcake(x, y + s * 0.4, s * 0.56, { ink: ik, fr: RBW(x, y - 6), wrap: gl(x - 14, 0, x + 14, 0) }), (x, y, s) => donut(x, y + 2, s * 0.8, RBW(x, y), ik), (x, y, s) => [...macaron(x, y + s * 0.18, s * 0.62, '#ff9ac0', ik), ...macaron(x, y - s * 0.16, s * 0.56, '#8ad8ff', ik)], (x, y, s) => cupcake(x, y + s * 0.36, s * 0.5, { ink: ik, fr: RBW(x, y - 4), wrap: gl(x - 10, 0, x + 10, 0) })],
    lid: ink => rbLid(ink, (u, w) => { const a = Math.atan2((w - 0.5) * 1.2, u - 0.5), r = Math.hypot(u - 0.5, (w - 0.5) * 1.2); return mixH(pal((((a / TAU + r * 2.4) % 1) + 1) % 1), '#ffffff', 0.32); }, { h: 52, k: 0.72, nu: 30, nv: 14,
      deco: cu => { const o = []; for (let i = 0; i < 40; i++) { const u = 0.08 + ((i * 0.618) % 1) * 0.84, w = 0.08 + ((i * 0.371) % 1) * 0.84; if (cu.visAt(u, w) > 0.15) { const p = cu.P(u, w), a = i * 1.9; o.push(st(line([[p[0] - Math.cos(a) * 2.6, p[1] - Math.sin(a) * 2.6], [p[0] + Math.cos(a) * 2.6, p[1] + Math.sin(a) * 2.6]]), i % 3 ? '#ffffff' : SPR[i % 5], 2.2)); } } return o; } }),
    crest: (T, ink) => [sh(ell(T[0], T[1] + 2, 14, 4), 'rgba(60,0,80,0.3)'), st(parse(`M${T[0]} ${T[1] - 18} Q${T[0] + 4} ${T[1] - 34} ${T[0] + 14} ${T[1] - 40}`), '#7a4800', 3.4), st(parse(`M${T[0]} ${T[1] - 18} Q${T[0] + 4} ${T[1] - 34} ${T[0] + 14} ${T[1] - 40}`), '#ffd23a', 1.8),
      sh(parse(`M${T[0] + 12} ${T[1] - 39} Q${T[0] + 24} ${T[1] - 48} ${T[0] + 30} ${T[1] - 38} Q${T[0] + 20} ${T[1] - 32} ${T[0] + 12} ${T[1] - 39} Z`), lg(T[0] + 12, 0, T[0] + 30, 0, '#b0ffd0', '#3ad08a'), { s: '#0e6a3a', w: 1.2 }), sh(ell(T[0], T[1] - 10, 13), gl(T[0] - 13, T[1] - 23, T[0] + 13, T[1] + 3), { s: '#7a4800', w: 1.8 }), ...gemS(T[0] - 2, T[1] - 11, 5, '#ff3a5a', ink), sh(ell(T[0] - 6, T[1] - 16, 3, 2), 'rgba(255,255,255,0.85)')], crestH: 46,
    lock: (x, ink) => [sh(rect(x - 5, -97, 10, 14, 4), gl(x - 5, 0, x + 5, 0), { s: ink, w: 1.3 }), ...cupcake(x, -48, 30, { ink: '#7a4800', wrap: gl(x - 15, 0, x + 15, 0), fr: gl(x - 18, -84, x + 18, -60), spr: false, cherry: RBW(x, -86, 1.4) }), sh(ell(x, -56, 1.6), '#4a2600'), ...gemS(x, -70, 3.4, '#3aa8ff', ink)],
    loot: ['cupcake', 'gem', 'donut', 'star', 'cookie', 'coin'] });
}

/* ---------- loot icons ---------- */
function icCupcake(c, s) {
  c.lineWidth = s * 0.05; c.strokeStyle = '#6a3a24'; c.fillStyle = '#ff8ab0'; c.beginPath(); c.moveTo(-s * 0.3, -s * 0.02); c.lineTo(s * 0.3, -s * 0.02); c.lineTo(s * 0.22, s * 0.38); c.lineTo(-s * 0.22, s * 0.38); c.closePath(); c.fill(); c.stroke();
  const g = c.createRadialGradient(-s * 0.1, -s * 0.2, 0, 0, -s * 0.1, s * 0.4); g.addColorStop(0, '#ffffff'); g.addColorStop(1, '#ffd0e0'); c.fillStyle = g; c.beginPath(); c.moveTo(-s * 0.36, 0); c.quadraticCurveTo(-s * 0.42, -s * 0.24, -s * 0.18, -s * 0.28); c.quadraticCurveTo(-s * 0.12, -s * 0.46, s * 0.06, -s * 0.42); c.quadraticCurveTo(s * 0.3, -s * 0.4, s * 0.22, -s * 0.24); c.quadraticCurveTo(s * 0.44, -s * 0.2, s * 0.36, 0); c.closePath(); c.fill(); c.stroke();
  c.fillStyle = '#e5203a'; c.beginPath(); c.arc(s * 0.02, -s * 0.46, s * 0.08, 0, TAU); c.fill(); c.stroke();
}
function icCookie(c, s) { const g = c.createRadialGradient(-s * 0.1, -s * 0.1, 0, 0, 0, s * 0.42); g.addColorStop(0, '#f6c886'); g.addColorStop(1, '#b8783a'); c.fillStyle = g; c.beginPath(); c.arc(0, 0, s * 0.38, 0, TAU); c.fill(); c.strokeStyle = '#6a3a14'; c.lineWidth = s * 0.05; c.stroke(); c.fillStyle = '#4a2210'; [[-0.14, -0.12], [0.12, -0.16], [0.04, 0.1], [-0.16, 0.14], [0.2, 0.08]].forEach(([x, y]) => { c.beginPath(); c.arc(x * s, y * s, s * 0.05, 0, TAU); c.fill(); }); }
function icDonut(c, s) { c.lineWidth = s * 0.05; c.strokeStyle = '#6a3a14'; c.fillStyle = '#d89a50'; c.beginPath(); c.arc(0, 0, s * 0.4, 0, TAU); c.fill(); c.stroke(); c.fillStyle = '#ff8ab8'; c.beginPath(); c.arc(0, -s * 0.03, s * 0.34, 0, TAU); c.fill(); c.fillStyle = '#fdf1e4'; c.beginPath(); c.arc(0, 0, s * 0.13, 0, TAU); c.fill(); c.stroke(); ['#ffffff', '#3aa8ff', '#ffd23a', '#3ad08a'].forEach((k, i) => { const a = i * 1.6 + 0.4; c.strokeStyle = k; c.lineWidth = s * 0.05; c.beginPath(); c.moveTo(Math.cos(a) * s * 0.22, Math.sin(a) * s * 0.22); c.lineTo(Math.cos(a) * s * 0.22 + s * 0.07, Math.sin(a) * s * 0.22 + s * 0.04); c.stroke(); }); }

const Cd = CM.MAT.candy, Mt = CM.MAT.metal, Ca = CM.MAT.card;
CM.register('bakery', [bakeryBox, bakeryTin, bakeryCake, bakeryCloche, bakerySwirl], {
  mat: {
    cakebox: Object.assign({}, Ca, { chips: ['#ffffff', '#7ad8c0', '#e5303a', '#f0d8c0'], dust: '#fbf0e6', sfx: { m: 'cake', p: 1, x: ['paperx'] }, cav: ['#2a1206', '#4a2410'], glow: '#ffe8b0' }),
    tin: Object.assign({}, Mt, { soft: 0.4, lean: 4, dentK: 8, holeFrom: 0.36, chips: ['#3a6ad8', '#ffffff', '#ffd23a', '#d89a50'], dust: '#ece6f0', sfx: { m: 'tin', p: 1, x: ['latch'] }, cav: ['#0a1030', '#1a2a5a'], glow: '#ffe8b0' }),
    frosting: { soft: 1, lean: 5, sag: 6, dentK: 7, dentShade: 0.24, holeFrom: 0.24, holeP: 0.7, holeR: [15, 22], jag: 'tear', edge: '#fff2f6', edgeW: 7, crack: 'rip', chips: ['#ffb8d0', '#fff2d0', '#b0703e', '#ffffff', '#e5203a'], deb: 'fluff', deb2: 'drop', dropC: '#ff8ab0', dust: '#fff0f4', mass: 0.9, sfx: { m: 'frosting', p: 1, x: ['paperx'] }, rest: 0.12, flutter: 0.2, cav: ['#3a1408', '#5a2414'], glow: '#ffe8b0' },
    cloche: Object.assign({}, Mt, { jag: 'shard', crack: 'glow', deb: 'gem', chips: ['#6ad8bc', '#dff6ff', '#ffb0cc', '#ffd23a', '#ffffff'], dust: '#eef8f6', sfx: { m: 'glass', p: 1, x: ['goldx'] }, cav: ['#062a22', '#0e4a3a'], glow: '#ffe8b0', spark: '#ffffff' }),
    sugargem: Object.assign({}, Cd, { sfx: { m: 'sugar', p: 1.1, x: ['rainbow', 'fizz'] } }),
  },
  icons: { cupcake: icCupcake, cookie: icCookie, donut: icDonut },
});
}
(function go() { if (window.ChestModels && window.ChestModels.K) run(); else setTimeout(go, 30); })();
})();
