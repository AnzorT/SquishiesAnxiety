// Dreamland chests for ChestModels: Sleepy Pillow Pouch -> Toy Block Box -> Lullaby Music Box -> Dream Castle Chest -> Rainbow Unicorn Dream Treasury.
(function () {
'use strict';
function run() {
const CM = window.ChestModels, H = CM.H, K = CM.K;
const { parse, poly, line, rect, ell, shift, spark4, star5, lg, rg, sh, st, tx, P3, mapD, onP, Box, cvx, boxFill, boxShade, corner3, surf } = H;
const { PI, TAU, mixH, R2, gl, gemS, GOLD, ball, rev, disc, ringP, cylP, onCyl, puffLid, lidRim, vault, treasury, rbLid, pal, RBW, moonP, cloudS, clipAll } = K;
const STAR = '#ffe066';
const sleepy = (x, y, s, c) => [st(parse(`M${x - s * 1.5} ${y} Q${x - s} ${y + s * 0.6} ${x - s * 0.5} ${y}`), c, Math.max(1.4, s * 0.28)), st(parse(`M${x + s * 0.5} ${y} Q${x + s} ${y + s * 0.6} ${x + s * 1.5} ${y}`), c, Math.max(1.4, s * 0.28)),
  st(parse(`M${x - s * 0.4} ${y + s * 1.1} Q${x} ${y + s * 1.5} ${x + s * 0.4} ${y + s * 1.1}`), c, Math.max(1.2, s * 0.22)), sh(ell(x - s * 1.9, y + s * 0.9, s * 0.5, s * 0.3), 'rgba(255,130,170,0.5)'), sh(ell(x + s * 1.9, y + s * 0.9, s * 0.5, s * 0.3), 'rgba(255,130,170,0.5)')];
const note = (x, y, s, f, ink) => [sh(ell(x, y, s * 0.5, s * 0.36), f, { s: ink, w: 0.9 }), st(line([[x + s * 0.45, y - 0.2], [x + s * 0.45, y - s * 1.6]]), ink, Math.max(1.2, s * 0.18)), st(parse(`M${x + s * 0.45} ${y - s * 1.6} Q${x + s * 1.1} ${y - s * 1.3} ${x + s} ${y - s * 0.7}`), ink, Math.max(1.2, s * 0.18))];
const horn = (x, y, s, f, ink) => { const P = poly([[x - s * 0.17, y], [x, y - s], [x + s * 0.17, y]]), o = [sh(P, f, { s: ink, w: 1.4 })]; for (let k = 1; k < 5; k++) { const yy = y - s * k / 5, w = s * 0.17 * (1 - k / 5); o.push(st(line([[x - w - 0.5, yy + s * 0.04], [x + w + 0.5, yy - s * 0.06]]), 'rgba(122,72,0,0.6)', 1.1, { clip: P })); }
  o.push(st(line([[x - s * 0.06, y - s * 0.1], [x - s * 0.02, y - s * 0.7]]), 'rgba(255,255,255,0.7)', 1.2)); return o; };
const wing = (x, y, s, d, f, ink) => { const M = q => mapD(parse(q), (a, b) => [x + a * s * d, y + b * s]); return [sh(M('M0 0 C0.3 -0.5 0.8 -0.8 1.2 -0.7 C1.05 -0.55 1.1 -0.45 1.0 -0.38 C1.08 -0.3 1.0 -0.18 0.86 -0.14 C0.9 -0.04 0.76 0.06 0.6 0.04 C0.5 0.12 0.3 0.1 0 0 Z'), f, { s: ink, w: 1.3 }), st(M('M0.2 -0.08 C0.5 -0.3 0.8 -0.45 1.0 -0.5'), 'rgba(122,72,0,0.5)', 1), st(M('M0.25 -0.02 C0.5 -0.15 0.7 -0.22 0.86 -0.2'), 'rgba(122,72,0,0.5)', 1)]; };

/* ---------- COMMON: sleepy pillow pouch ---------- */
function dreamPillow() {
  const ink = '#4a2a8a', A = 50, Bh = 58, cy = -62, cx = -2, D = 17, n = 2.8, sg = (q, e) => Math.sign(q) * Math.pow(Math.abs(q), e);
  const edge = th => { const pin = 1 + 0.13 * Math.pow(Math.abs(Math.sin(2 * th)), 8); return [A * pin * sg(Math.cos(th), 2 / n), Bh * pin * sg(Math.sin(th), 2 / n)]; };
  const zf = rho => D * Math.pow(Math.max(0, 1 - Math.pow(rho, 3)), 0.45);
  const sheet = s => surf((u, w) => { const e = edge(TAU * u), rho = 0.02 + 0.98 * w; return [cx + e[0] * rho, cy + e[1] * rho, s * zf(rho)]; }, 36, 9, () => '#c4aef6', { c: [cx, cy, 0], dk: '#2a0a5a', cv: -0.05 });
  const back = sheet(1), front = sheet(-1), FP = (px, py) => { const rho = Math.pow(Math.pow(Math.abs(px), n) + Math.pow(Math.abs(py), n), 1 / n); return P3(cx + A * px, cy + Bh * py, -zf(Math.min(1, rho))); };
  const body = [...back.sh, ...front.sh];
  [[-0.62, -0.7], [0.1, -0.78], [0.66, -0.56], [-0.7, 0.05], [0.72, 0.12], [-0.56, 0.66], [0.04, 0.72], [0.6, 0.7], [-0.3, -0.42], [0.36, -0.36], [-0.34, 0.4], [0.4, 0.42]].forEach(([px, py], i) => { const p = FP(px, py); body.push(i % 2 ? sh(star5(p[0], p[1], 4.4, 2), '#ffffff', { a: 0.9 }) : sh(moonP(p[0] + 3, p[1], 5.6), '#ffe066')); });
  const fc = FP(0, -0.04); body.push(...sleepy(fc[0], fc[1], 6, '#3a1a6a'));
  [[[-0.95, -0.95], [-0.62, -0.62]], [[0.95, -0.95], [0.62, -0.62]], [[-0.95, 0.95], [-0.62, 0.62]], [[0.95, 0.95], [0.62, 0.62]]].forEach(([a, b]) => body.push(st(line([FP(...a), FP(...b)]), 'rgba(70,30,140,0.3)', 1.6)));
  const sm = line(Array.from({ length: 73 }, (_, i) => { const e = edge(TAU * i / 72); return P3(cx + e[0], cy + e[1], 0); }));
  body.push(st(sm, ink, 6), st(sm, '#ffe8a0', 3), st(shift(sm, -0.6, -0.8), 'rgba(255,255,255,0.6)', 0.9));
  const cr = th => { const e = edge(th); return P3(cx + e[0], cy + e[1], 0); }, C0 = cr(-PI * 0.75), C1 = cr(-PI * 0.25), C3 = cr(PI * 0.25);
  const bow = [sh(parse(`M${C0[0]} ${C0[1]} C${C0[0] - 18} ${C0[1] - 16} ${C0[0] - 22} ${C0[1] + 8} ${C0[0]} ${C0[1]} C${C0[0] + 6} ${C0[1] - 22} ${C0[0] + 24} ${C0[1] - 12} ${C0[0]} ${C0[1]} Z`), lg(C0[0] - 20, C0[1] - 18, C0[0] + 22, C0[1] + 10, '#b8f4e4', '#6ad0b4'), { s: '#2e7a68', w: 1.4 }), sh(parse(`M${C0[0] - 1} ${C0[1] + 1} L${C0[0] - 12} ${C0[1] + 18} L${C0[0] - 7} ${C0[1] + 18} L${C0[0] - 4} ${C0[1] + 22} Z`), '#6ad0b4', { s: '#2e7a68', w: 1 }), sh(parse(`M${C0[0] + 1} ${C0[1] + 1} L${C0[0] + 8} ${C0[1] + 19} L${C0[0] + 4} ${C0[1] + 18} L${C0[0] + 2} ${C0[1] + 22} Z`), '#6ad0b4', { s: '#2e7a68', w: 1 }), sh(ell(C0[0], C0[1], 4, 3.4), '#9ae8d4', { s: '#2e7a68', w: 1.2 })];
  const tag = [st(ell(C1[0], C1[1] + 2, 3.4), '#c8b8e8', 1.4), st(parse(`M${C1[0]} ${C1[1] + 5} Q${C1[0] + 4} ${C1[1] + 12} ${C1[0] + 6} ${C1[1] + 18}`), '#8a7ab8', 1.1), sh(rect(C1[0] - 6, C1[1] + 18, 24, 14, 4), lg(0, C1[1] + 18, 0, C1[1] + 32, '#ffffff', '#efe6ff'), { s: ink, w: 1.3 }), tx('Zzz', C1[0] + 6, C1[1] + 25.4, '700 8.6px Fredoka, Nunito, sans-serif', '#6a44b8')];
  const sk = [C3[0] - 2, C3[1] - 10], key = [st(ell(sk[0], sk[1], 3.6), '#c8d0e0', 1.6), st(parse(`M${sk[0]} ${sk[1] + 3} Q${sk[0] + 2} ${sk[1] + 6} ${sk[0] + 4} ${sk[1] + 8}`), '#c8d0e0', 1.2), sh(star5(sk[0] + 5, sk[1] + 16, 9, 5), lg(sk[0] - 4, sk[1] + 7, sk[0] + 14, sk[1] + 25, '#fff6c0', '#ffd23a'), { s: '#a87a00', w: 1.4 }), ...sleepy(sk[0] + 5, sk[1] + 15, 1.6, '#7a4800')];
  return { name: 'Sleepy Pillow Pouch', mat: 'pillow', hp: 6, W: 112, H: 137, ko: 'halves',
    hull: cvx(back.pts.concat(front.pts, [[C0[0] - 22, C0[1] - 14], [C0[0] + 20, C0[1] - 18], [C1[0] + 20, C1[1] + 34], [sk[0] + 16, sk[1] + 26]])),
    parts: [{ id: 'body', sh: body }, { id: 'tag', sh: tag, tear: 0.34, hang: [C1[0], C1[1] + 2], loose: 0, hmax: 0.6, hdir: 1 }, { id: 'key', sh: key, tear: 0.6, hang: sk, loose: 0, hmax: 0.5, hdir: 1 }, { id: 'bow', sh: bow, launch: true, launchV: 380 }],
    loot: ['moon', 'coin', 'candy', 'star'] };
}

/* ---------- RARE: toy block box ---------- */
function dreamToys() {
  const ink = '#3a2a6a', B = Box(-66, -76, 48, 0, 36), L = Box(-69, -88, 51, -76, 39, -1.5);
  const BU = { f: ['#fff2b0', '#ffd86a', '#e8b03a'], t: ['#fff6c8', '#ffe08a'], s: ['#e8b84a', '#b8862a'] }, MI = { f: ['#b8f4e4', '#7ad8c0', '#4aa890'], t: ['#c8faec', '#8ee4cc'], s: ['#5ab8a0', '#2e8070'] };
  const body = [...boxFill(B, BU), st(rect(-60, -70, 102, 64, 7), 'rgba(255,255,255,0.75)', 2.4), st(shift(rect(-60, -70, 102, 64, 7), 1.4, 1.4), 'rgba(150,100,20,0.35)', 1.2),
    sh(star5(-36, -36, 17, 7.5), lg(-52, -52, -20, -20, '#e0d0ff', '#9a7ae8'), { s: ink, w: 1.6 }), ...sleepy(-36, -37, 2.4, '#3a1a6a'), sh(moonP(26, -38, 16), lg(10, -54, 26, -22, '#d8fff2', '#5ac8aa'), { s: '#2e7a68', w: 1.6 }),
    sh(star5(-4, -22, 4.5, 2), '#ffffff'), sh(star5(4, -50, 3.6, 1.6), '#ffffff'), sh(star5(36, -16, 3.4, 1.5), '#ffffff')];
  const arc = [['#ff9ac0', 13], ['#ffd23a', 10.5], ['#7ad8c0', 8], ['#8ab4ff', 5.5]].map(([c, r]) => st(parse(`M${18 - r} -30 C${18 - r} ${-30 - r * 1.33} ${18 + r} ${-30 - r * 1.33} ${18 + r} -30`), c, 2.6));
  body.push(...onP(arc.concat(cloudS(9, -29, 10, '#ffffff', '#8a7ab8', 1.6), cloudS(27, -29, 10, '#ffffff', '#8a7ab8', 1.6), [sh(star5(10, -62, 4, 1.8), '#ffffff'), sh(star5(28, -12, 3.4, 1.5), '#ffffff')]), B.pS), ...boxShade(B, ink, { k: 0.8 }));
  const lid = [...boxFill(L, MI)];
  for (let x = -63; x < 48; x += 14) lid.push(sh(rect(x, -86, 7, 8, 2), 'rgba(255,255,255,0.5)'));
  lid.push(...boxShade(L, ink, { k: 0.8 }));
  const blk = (x0, y1, s, z0, c, ch) => { const b = Box(x0, y1 - s, x0 + s, y1, s, z0), cc = { f: [mixH(c, '#ffffff', 0.35), c, mixH(c, '#20003a', 0.25)], t: [mixH(c, '#ffffff', 0.5), mixH(c, '#ffffff', 0.2)], s: [mixH(c, '#20003a', 0.15), mixH(c, '#20003a', 0.4)] }, f0 = b.Q(x0 + s / 2, y1 - s / 2, 0);
    return [...boxFill(b, cc), st(b.front(rect(x0 + 2.5, y1 - s + 2.5, s - 5, s - 5, 2)), 'rgba(255,255,255,0.7)', 1.4), tx(ch, f0[0], f0[1] + 0.6, '700 ' + Math.round(s * 0.62) + 'px Fredoka, Nunito, sans-serif', '#ffffff'), ...onP([sh(star5(s / 2, y1 - s / 2, s * 0.26, s * 0.12), '#ffffff', { a: 0.85 })], b.pS), ...boxShade(b, ink, { k: 0.8 })]; };
  const b1 = blk(-58, -88, 20, 6, '#a07ae8', 'A'), b2 = blk(-32, -88, 20, 10, '#5aa8ff', 'B'), b3 = blk(-46, -108, 20, 8, '#ff8a6a', 'C');
  const plate = [sh(rect(-28, -70, 48, 13, 4), '#ffffff', { s: ink, w: 1.3 }), tx('DREAMS', -4, -63, '700 8.4px Fredoka, Nunito, sans-serif', '#6a44b8')];
  const sk = B.pS(18, -62), stick = [st(star5(sk[0], sk[1], 7, 3.2), '#ffffff', 4), sh(star5(sk[0], sk[1], 7, 3.2), lg(sk[0] - 7, sk[1] - 7, sk[0] + 7, sk[1] + 7, '#fff6c0', '#ffd23a'), { s: '#a87a00', w: 0.8 })];
  return { name: 'Toy Block Box', mat: 'toywood', hp: 8, W: 150, H: 140, ko: 'planks', rows: [[-200, -76], [-76, -38], [-38, 30]],
    hull: cvx(B.pts.concat(L.pts, [P3(-58, -88, 6), P3(-46, -128, 8), P3(-26, -128, 28), P3(-12, -108, 30)])),
    parts: [{ id: 'body', sh: body }, { id: 'lid', sh: lid, launch: true }, { id: 'plate', sh: plate, tear: 0.3, hang: [-24, -64], loose: 0.08, hmax: 0.9, hdir: 1 }, { id: 'stick', sh: stick, tear: 0.56 },
      { id: 'b1', sh: b1, tear: 0.7 }, { id: 'b2', sh: b2, launch: true, launchV: 380 }, { id: 'b3', sh: b3, tear: 0.46 }],
    loot: ['candy', 'coin', 'star', 'moon', 'coin'] };
}

/* ---------- EPIC: lullaby music box ---------- */
function dreamMusic() {
  const ink = '#2a1050', B = Box(-84, -74, 54, 0, 40), L = Box(-87, -94, 57, -74, 43, -1.5), gi = '#6a4200';
  const LV = { f: ['#d8bcff', '#a07ae8', '#6a44b8'], t: ['#e4ccff', '#b490f0'], s: ['#7e54c8', '#4a2a8a'] };
  const scroll = (x, y, d) => st(parse(`M${x} ${y} C${x + 10 * d} ${y - 10} ${x + 20 * d} ${y + 4} ${x + 12 * d} ${y + 8} C${x + 6 * d} ${y + 11} ${x + 4 * d} ${y + 3} ${x + 9 * d} ${y + 2}`), gl(x - 10, y - 10, x + 10, y + 10), 1.8);
  const body = [...boxFill(B, LV), st(rect(-78, -68, 44, 60, 7), gl(-78, -68, -34, -8), 2.4), st(rect(4, -68, 44, 60, 7), gl(4, -68, 48, -8), 2.4), scroll(-74, -60, 1), scroll(-38, -18, -1), scroll(8, -60, 1), scroll(44, -18, -1),
    sh(moonP(-50, -38, 12), gl(-62, -50, -50, -26), { s: gi, w: 1.2 }), sh(star5(-44, -46, 3, 1.4), STAR), sh(star5(32, -38, 10, 4.5), gl(22, -48, 42, -28), { s: gi, w: 1.2 }), sh(star5(16, -54, 3, 1.4), STAR),
    ...onP([st(rect(4, -68, 32, 60, 7), gl(4, -68, 36, -8), 2.2), sh(moonP(24, -38, 11), gl(13, -49, 24, -27), { s: gi, w: 1 }), scroll(8, -62, 1)], B.pS), sh(rect(-84, -7, 138, 7), gl(0, -7, 0, 0), { s: gi, w: 1.2 }), sh(B.side(rect(0, -7, 40, 7)), lg(...P3(54, -7, 0), ...P3(54, 0, 0), '#e8a400', '#8a5800'), { s: gi, w: 1 }),
    sh(ell(-66, -56, 12, 18), rg(-66, -56, 20, 'rgba(255,255,255,0.32)', 'rgba(255,255,255,0)')), ...boxShade(B, ink, { k: 0.8 })];
  const cu = puffLid(-85, 55, -94, 0.5, 39.5, 9, 0.35, () => '#b48af0', { dk: '#2a0a50', nu: 18, nv: 8 }), lid = [...boxFill(L, LV), ...cu.sh, ...lidRim(cu, gi, gl(0, -100, 0, -90), 5), st(rect(-80, -90, 130, 12, 4), gl(0, -90, 0, -78), 1.6), ...boxShade(L, ink, { only: 'FS', k: 0.8 })];
  for (let x = -70; x <= 40; x += 22) lid.push(sh(star5(x, -84, 3, 1.4), STAR));
  const cs = [corner3(B, -1, 1, 16, 6, 1.5, GOLD, gi), corner3(B, 1, 1, 16, 6, 1.5, GOLD, gi), corner3(L, -1, -1, 14, 5.5, 1.5, GOLD, gi), corner3(L, 1, -1, 14, 5.5, 1.5, GOLD, gi)];
  const notes = [...note(-64, -22, 7, gl(-68, -26, -60, -18), gi), ...note(-54, -60, 6, gl(-58, -64, -50, -56), gi), ...note(24, -60, 6, gl(20, -64, 28, -56), gi), ...note(38, -20, 7, gl(34, -24, 42, -16), gi)];
  const ks = B.pS(20, -40), key = [st(line([ks, [ks[0] + 10, ks[1] - 2]]), gi, 4.6), st(line([ks, [ks[0] + 10, ks[1] - 2]]), gl(ks[0], ks[1] - 3, ks[0], ks[1] + 3), 2.6),
    sh(parse(`M${ks[0] + 10} ${ks[1] - 2} C${ks[0] + 14} ${ks[1] - 16} ${ks[0] + 24} ${ks[1] - 12} ${ks[0] + 10} ${ks[1] - 2} C${ks[0] + 18} ${ks[1] + 10} ${ks[0] + 26} ${ks[1] + 2} ${ks[0] + 10} ${ks[1] - 2} Z`), gl(ks[0] + 10, ks[1] - 14, ks[0] + 26, ks[1] + 8), { s: gi, w: 1.3 }), sh(ell(ks[0] + 10, ks[1] - 2, 2.4), gl(ks[0] + 8, ks[1] - 4, ks[0] + 12, ks[1]), { s: gi, w: 0.8 })];
  const lock = [sh(ell(-15, -42, 15, 18), gl(-30, -60, 0, -24), { s: gi, w: 1.6 }), sh(ell(-15, -42, 11.5, 14.5), rg(-18, -46, 16, '#e8d8ff', '#a07ae8', '#5a34a8'), { s: gi, w: 1 }), sh(moonP(-11, -42, 8), STAR, { s: gi, w: 0.9 }), st(parse('M-20 -44 Q-18.5 -42 -17 -44'), '#7a4800', 1.1), sh(star5(-8, -49, 2.6, 1.2), '#ffffff'), sh(ell(-15, -27, 1.6), '#2a1050')];
  const pc = [-15, 19.5], ped = rev(pc[0], pc[1], v => [12 - v * 2, -94 - v * 7], 20, 2, () => '#ffcf30', { dk: '#5a3000' }), tp = P3(pc[0], -101, pc[1]);
  const fig = [...ped.sh, sh(disc(pc[0], pc[1], 10, -101, 24), gl(tp[0] - 10, tp[1] - 5, tp[0] + 10, tp[1] + 5), { s: gi, w: 1 }), ...cloudS(tp[0], tp[1] - 3, 13, '#ffffff', '#8a7ab8', 1.8),
    st(line([[tp[0], tp[1] - 4], [tp[0], tp[1] - 44]]), gi, 3.6), st(line([[tp[0], tp[1] - 4], [tp[0], tp[1] - 44]]), gl(tp[0] - 2, 0, tp[0] + 2, 0), 2), ...[0, 1, 2, 3, 4].map(k => st(line([[tp[0] - 1.6, tp[1] - 8 - k * 7], [tp[0] + 1.6, tp[1] - 12 - k * 7]]), '#a86e00', 0.9)),
    sh(moonP(tp[0] + 11, tp[1] - 30, 14), lg(tp[0] - 4, tp[1] - 44, tp[0] + 10, tp[1] - 16, '#fff6c0', '#ffd23a', '#e8a400'), { s: gi, w: 1.4 }), st(parse(`M${tp[0] - 1} ${tp[1] - 33} Q${tp[0] + 1} ${tp[1] - 30.5} ${tp[0] + 3} ${tp[1] - 33}`), '#7a4800', 1.3),
    sh(star5(tp[0], tp[1] - 48, 6.5, 3), gl(tp[0] - 6, tp[1] - 54, tp[0] + 6, tp[1] - 42), { s: gi, w: 1 }), sh(spark4(tp[0] + 14, tp[1] - 50, 4), '#ffffff')];
  return { name: 'Lullaby Music Box', mat: 'lacquer', hp: 10, W: 180, H: 150, ko: 'pie', pieN: 6,
    hull: cvx(B.pts.concat(L.pts, cu.pts, [[tp[0], tp[1] - 56], [tp[0] - 14, tp[1] - 8], [ks[0] + 26, ks[1]]])),
    parts: [{ id: 'body', sh: body }, { id: 'c0', sh: cs[0].sh, tear: 0.44 }, { id: 'c1', sh: cs[1].sh, tear: 0.66 }, { id: 'notes', sh: notes, tear: 0.3 }, { id: 'key', sh: key, tear: 0.5, hang: ks, loose: 0.2, hmax: 0.6, hdir: 1 },
      { id: 'lid', sh: lid, launch: true }, { id: 'c2', sh: cs[2].sh, tear: 0.82 }, { id: 'c3', sh: cs[3].sh, tear: 0.9 }, { id: 'lock', sh: lock, tear: 0.92, hang: [-15, -60], loose: 0.7, hmax: 0.5, hdir: 1 }, { id: 'fig', sh: fig, launch: true, launchV: 420 }],
    loot: ['moon', 'coin', 'star', 'candy', 'coin', 'cloud'] };
}

/* ---------- LEGENDARY: dream castle chest ---------- */
function dreamCastle() {
  const ink = '#3a2470', gi = '#6a4200', PE = { f: ['#ffffff', '#e8dafc', '#b8a0e0'], t: ['#ffffff', '#efe4fd'], s: ['#cab6ee', '#8a70c0'] };
  const bricks = (x0, y0, x1, y1) => { const o = []; for (let y = y0 + 11, r = 0; y < y1 - 2; y += 11, r++) { o.push(st(line([[x0 + 2, y], [x1 - 2, y]]), 'rgba(120,90,180,0.28)', 1)); for (let x = x0 + (r % 2 ? 8 : 16); x < x1 - 4; x += 16) o.push(st(line([[x, y], [x, y + 11]]), 'rgba(120,90,180,0.24)', 1)); } return o; };
  const win = (x, y, w, h) => { const d = parse(`M${x} ${y + h} L${x} ${y + w / 2} Q${x} ${y} ${x + w / 2} ${y} Q${x + w} ${y} ${x + w} ${y + w / 2} L${x + w} ${y + h} Z`); return [sh(d, rg(x + w / 2, y + h * 0.6, h, '#fff6c0', '#ffc848', '#e88a20')), st(line([[x + w / 2, y + 2], [x + w / 2, y + h]]), gi, 1.6), st(line([[x, y + h * 0.55], [x + w, y + h * 0.55]]), gi, 1.6), st(d, gi, 3.6), st(d, gl(x, y, x + w, y + h), 2)]; };
  const gate = parse('M-36 0 L-36 -34 Q-36 -58 -16 -58 Q4 -58 4 -34 L4 0 Z');
  const turret = (x, z, i) => { const r = 11, t = rev(x, z, v => [r, -v * 118], 18, 3, () => '#efe4fd', { dk: '#3a2470' }), roof = rev(x, z, v => [(r + 3) * (1 - v), -118 - v * 30], 18, 4, () => ['#a07ae8', '#7ad8c0', '#a07ae8'][i], { dk: '#2a0a50' }), tp = P3(x, -148, z);
    return [...t.sh, ...onCyl(x, z, r, [sh(parse('M-3 -76 L-3 -88 Q-3 -92 0 -92 Q3 -92 3 -88 L3 -76 Z'), '#ffc848', { s: gi, w: 1.2 }), st(line([[-r * 1.3, -50], [r * 1.3, -50]]), 'rgba(120,90,180,0.3)', 1), st(line([[-r * 1.3, -26], [r * 1.3, -26]]), 'rgba(120,90,180,0.3)', 1)]), sh(disc(x, z, r + 3, -118, 24), '#c8b4ec', { s: ink, w: 1.2 }), ...roof.sh,
      st(line([tp, [tp[0], tp[1] - 12]]), gi, 1.6), sh(poly([[tp[0], tp[1] - 12], [tp[0] + 11, tp[1] - 9], [tp[0], tp[1] - 6]]), ['#ffd23a', '#ff8ab8', '#ffd23a'][i], { s: gi, w: 0.9 }), ...ball(tp[0], tp[1], 2.6, gi)]; };
  return vault({ name: 'Dream Castle Chest', mat: 'castle', ink, gi, C: PE, LC: { f: ['#f4ecff', '#d4c0f8', '#a088d8'], t: ['#ffffff', '#e4d8fc'], s: ['#b8a0e4', '#7a60b0'] }, gems: ['#ff8ab8', '#5ac8ff'],
    front: () => [...bricks(-94, -88, 62, 0), sh(gate, lg(-36, -58, 4, 0, '#5a3a9a', '#2a1660')), ...[-28, -20, -12, -4].map(x => st(line([[x, -54], [x, 0]]), gl(x - 1, 0, x + 1, 0), 1.6, { clip: gate })), ...[-46, -34, -22, -10].map(y => st(line([[-36, y], [4, y]]), gl(0, y - 1, 0, y + 1), 1.6, { clip: gate })),
      st(gate, gi, 4.6), st(gate, gl(-36, -58, 4, 0), 2.6), ...win(-74, -70, 18, 30), ...win(26, -70, 18, 30), ...[-82, -62, 30, 48].map(x => sh(star5(x, -20, 5, 2.2), gl(x - 5, -25, x + 5, -15), { s: gi, w: 0.9 }))],
    side: () => [...bricks(0, -88, 42, 0), ...win(12, -70, 18, 30)],
    lid: 'box', lidTop: ({ L }) => { const o = [], m = (x, z) => { const b = Box(x, -121, x + 9, -112, 7, z); o.push(...boxFill(b, PE), ...boxShade(b, ink, { k: 0.7 })); };
      [36, 26, 16].forEach(z => m(56, z)); for (let x = -97; x <= 56; x += 17) m(x, 0); return o; },
    crest: T => { const cx = -16, cz = 22.5, t = rev(cx, cz, v => [13, -112 - v * 26], 18, 2, () => '#f4ecff', { dk: '#3a2470' }), roof = rev(cx, cz, v => [16 * (1 - v), -138 - v * 34], 18, 4, () => '#a07ae8', { dk: '#2a0a50' }), tp = P3(cx, -172, cz);
      return [...t.sh, ...onCyl(cx, cz, 13, [sh(parse('M-4 -116 L-4 -128 Q-4 -133 0 -133 Q4 -133 4 -128 L4 -116 Z'), '#ffc848', { s: gi, w: 1.2 })]), sh(disc(cx, cz, 16, -138, 24), '#c8b4ec', { s: ink, w: 1.2 }), ...roof.sh, ...[0.1, 0.35, 0.6].map(v => st(line([P3(cx - 16 * (1 - v), -138 - v * 34, cz), P3(cx, -138 - v * 34, cz - 16 * (1 - v)), P3(cx + 16 * (1 - v), -138 - v * 34, cz)]), 'rgba(255,255,255,0.35)', 1)),
        st(line([tp, [tp[0], tp[1] - 16]]), gi, 1.8), sh(poly([[tp[0], tp[1] - 16], [tp[0] + 15, tp[1] - 12], [tp[0], tp[1] - 8]]), '#7ad8c0', { s: gi, w: 1 }), sh(star5(tp[0] + 6, tp[1] - 12, 2.2, 1), '#ffffff'), ...ball(tp[0], tp[1], 3, gi)]; }, crestH: 80,
    corners: false, pre: [{ id: 'tB', sh: turret(62, 42, 2), tear: 0.6 }], extra: () => [{ id: 'tL', sh: turret(-94, 0, 0), tear: 0.46 }, { id: 'tR', sh: turret(62, 0, 1), tear: 0.7 }],
    med: cx => [st(line([[cx, -66], [cx, -62]]), gi, 2), sh(ell(cx, -70, 10, 11), gl(cx - 10, -81, cx + 10, -59), { s: gi, w: 1.6 }), sh(ell(cx, -70, 7.5, 8.5), rg(cx - 2, -73, 10, '#e8d8ff', '#8a6ad8', '#4a2a98')), sh(moonP(cx + 3, -70, 5.5), STAR), ...gemS(cx, -84, 2.4, '#ff8ab8', gi)], medHang: [-16, -81],
    loot: ['moon', 'gem', 'candy', 'star', 'coin', 'cloud'] });
}

/* ---------- RAINBOW: unicorn dream treasury ---------- */
function dreamUnicorn() {
  const ik = '#8a5200';
  return treasury({ name: 'Rainbow Unicorn Dream Treasury', mat: 'dreamgem',
    art: [(x, y, s) => [...cloudS(x, y + 6, s * 0.6, RBW(x, y), ik, 2.4), ...sleepy(x - 1, y + 2, s * 0.06, '#5a2a00')], (x, y, s) => horn(x, y + s * 0.42, s * 0.84, RBW(x, y), ik), (x, y, s) => [sh(star5(x, y + 2, s * 0.42, s * 0.19), RBW(x, y), { s: ik, w: 2 })], (x, y, s) => [sh(moonP(x + s * 0.16, y, s * 0.34), RBW(x, y), { s: ik, w: 2 })]],
    lid: ink => { const L = rbLid(ink, (u, w) => mixH(pal(1 - w), '#ffffff', 0.12), { h: 46, k: 0.55, deco: cu => { const o = []; [[0.08, 0.2], [0.92, 0.22]].forEach(([u, w]) => { const p = cu.P(u, w); o.push(...cloudS(p[0], p[1] - 4, 20, rg(p[0] - 6, p[1] - 10, 24, '#ffffff', '#eef2ff', '#c8d4f8'), '#8a7ab8', 2.4)); }); return o; } }); return L; },
    crest: (T, ink) => [sh(ell(T[0], T[1] + 2, 18, 4), 'rgba(60,0,80,0.3)'), ...wing(T[0] - 6, T[1] - 8, 26, -1, gl(T[0] - 36, T[1] - 30, T[0] - 6, T[1]), '#7a4800'), ...wing(T[0] + 6, T[1] - 8, 26, 1, gl(T[0] + 6, T[1] - 30, T[0] + 36, T[1]), '#7a4800'),
      sh(ell(T[0], T[1] - 6, 9, 6), gl(T[0] - 9, T[1] - 12, T[0] + 9, T[1]), { s: '#7a4800', w: 1.3 }), ...horn(T[0], T[1] - 8, 40, lg(T[0] - 7, 0, T[0] + 7, 0, '#fff6c0', '#ffd23a', '#c88a00'), '#7a4800'), ...gemS(T[0], T[1] - 6, 3.6, '#ff5c9a', ink), sh(spark4(T[0] + 9, T[1] - 46, 5), '#ffffff')],
    crestH: 52,
    lock: (x, ink) => [sh(rect(x - 5, -97, 10, 16, 4), gl(x - 5, 0, x + 5, 0), { s: ink, w: 1.3 }), sh(moonP(x + 9, -64, 20), gl(x - 18, -84, x + 9, -44), { s: '#7a4800', w: 2 }), sh(ell(x - 2, -64, 6, 7), RBW(x - 2, -64, 1.4), { s: '#7a4800', w: 1.1 }), sh(ell(x - 4, -66.5, 2, 1.4), 'rgba(255,255,255,0.9)'), sh(ell(x - 2, -54, 1.5), '#4a2600')],
    loot: ['moon', 'gem', 'star', 'candy', 'cloud', 'coin'] });
}

const Cd = CM.MAT.candy, Mt = CM.MAT.metal, W = CM.MAT.wood;
CM.register('dream', [dreamPillow, dreamToys, dreamMusic, dreamCastle, dreamUnicorn], {
  mat: {
    pillow: { soft: 2.2, lean: 7, sag: 6, dentK: 7, dentShade: 0.24, holeFrom: 0.2, holeP: 0.75, holeR: [15, 22], jag: 'tear', edge: '#fff6ff', edgeW: 7, crack: 'rip', chips: ['#c2acf6', '#ffffff', '#ffe066', '#9ae8d4'], deb: 'fluff', deb2: 'fluff', dust: '#f6f0ff', mass: 0.7, sfx: { m: 'puff', p: 1, x: ['chime'] }, rest: 0.12, flutter: 0.8, cav: ['#1a0a30', '#34205a'], glow: '#ffe8a0' },
    toywood: Object.assign({}, W, { chips: ['#ffd86a', '#7ad8c0', '#a07ae8', '#5aa8ff', '#ff8a6a'], dust: '#f6eedc', sfx: { m: 'wood', p: 1.15, x: ['latch'] }, cav: ['#1a0e2a', '#30204a'], glow: '#ffe8a0' }),
    lacquer: Object.assign({}, W, { soft: 0.2, crack: 'scratch', chips: ['#a07ae8', '#d8bcff', '#ffd23a', '#ffffff', '#6a44b8'], dust: '#f0e8fc', sfx: { m: 'hardwood', p: 1.1, x: ['chime'] }, cav: ['#14062a', '#2a1450'], glow: '#ffe8a0' }),
    castle: Object.assign({}, Mt, { jag: 'ragged', crack: 'split', deb: 'chip', chips: ['#efe4fd', '#c8b4ec', '#a07ae8', '#ffd23a', '#7ad8c0'], dust: '#f2ecfc', sfx: { m: 'stone', p: 1.05, x: ['goldx', 'chime'] }, cav: ['#12082a', '#2a1650'], glow: '#ffe8a0' }),
    dreamgem: Object.assign({}, Cd, { deb2: 'fluff', sfx: { m: 'crystal', p: 1, x: ['rainbow', 'chime'] } }),
  },
});
}
(function go() { if (window.ChestModels && window.ChestModels.K) run(); else setTimeout(go, 30); })();
})();
