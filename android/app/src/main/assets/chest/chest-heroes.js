// Masked Heroes chests for ChestModels: Comic Book Box -> Hero Lunchbox -> Hero Gear Locker -> Hero HQ Vault -> Rainbow Legend Treasury.
(function () {
'use strict';
function run() {
const CM = window.ChestModels, H = CM.H, K = CM.K;
const { parse, poly, line, rect, ell, shift, spark4, star5, lg, rg, sh, st, tx, P3, mapD, onP, Box, cvx, boxFill, boxShade, corner3, nail } = H;
const { PI, TAU, mixH, R2, gl, sv, ir, gemS, IRON, ball, vault, treasury, rbLid, pal, RBW, clipAll } = K;
const mask = (x, y, s, f, ink) => [sh(parse(`M${x - s} ${y - s * 0.1} Q${x - s * 0.9} ${y - s * 0.5} ${x - s * 0.4} ${y - s * 0.46} Q${x} ${y - s * 0.4} ${x} ${y - s * 0.2} Q${x} ${y - s * 0.4} ${x + s * 0.4} ${y - s * 0.46} Q${x + s * 0.9} ${y - s * 0.5} ${x + s} ${y - s * 0.1} Q${x + s * 0.8} ${y + s * 0.36} ${x + s * 0.36} ${y + s * 0.3} Q${x + s * 0.1} ${y + s * 0.26} ${x} ${y + s * 0.08} Q${x - s * 0.1} ${y + s * 0.26} ${x - s * 0.36} ${y + s * 0.3} Q${x - s * 0.8} ${y + s * 0.36} ${x - s} ${y - s * 0.1} Z`), f, { s: ink, w: Math.max(1, s * 0.08) }),
  sh(ell(x - s * 0.44, y - s * 0.04, s * 0.24, s * 0.16), '#ffffff', { s: ink, w: Math.max(0.8, s * 0.05) }), sh(ell(x + s * 0.44, y - s * 0.04, s * 0.24, s * 0.16), '#ffffff', { s: ink, w: Math.max(0.8, s * 0.05) })];
const bolt = (x, y, s, f, ink) => [sh(poly([[x + s * 0.12, y - s * 0.5], [x - s * 0.3, y + s * 0.06], [x - s * 0.02, y + s * 0.06], [x - s * 0.14, y + s * 0.5], [x + s * 0.32, y - s * 0.1], [x + s * 0.04, y - s * 0.1], [x + s * 0.2, y - s * 0.5]]), f, { s: ink, w: Math.max(1, s * 0.07) })];
const shield = (x, y, s) => parse(`M${x} ${y - s * 0.55} Q${x + s * 0.3} ${y - s * 0.42} ${x + s * 0.5} ${y - s * 0.46} Q${x + s * 0.52} ${y + s * 0.15} ${x} ${y + s * 0.56} Q${x - s * 0.52} ${y + s * 0.15} ${x - s * 0.5} ${y - s * 0.46} Q${x - s * 0.3} ${y - s * 0.42} ${x} ${y - s * 0.55} Z`);
const burst = (x, y, R, r, n) => poly(Array.from({ length: n * 2 }, (_, i) => { const a = i / (n * 2) * TAU - PI / 2, k = i % 2 ? r : R * (0.9 + 0.1 * ((i * 7) % 3)); return [x + Math.cos(a) * k, y + Math.sin(a) * k]; }));
const wing = (x, y, s, d, f, ink) => { const M = q => mapD(parse(q), (a, b) => [x + a * s * d, y + b * s]); return [sh(M('M0 0 C0.3 -0.5 0.8 -0.8 1.2 -0.7 C1.05 -0.55 1.1 -0.45 1.0 -0.38 C1.08 -0.3 1.0 -0.18 0.86 -0.14 C0.9 -0.04 0.76 0.06 0.6 0.04 C0.5 0.12 0.3 0.1 0 0 Z'), f, { s: ink, w: 1.3 }), st(M('M0.2 -0.08 C0.5 -0.3 0.8 -0.45 1.0 -0.5'), 'rgba(122,72,0,0.5)', 1), st(M('M0.25 -0.02 C0.5 -0.15 0.7 -0.22 0.86 -0.2'), 'rgba(122,72,0,0.5)', 1)]; };
const logo = (t, x, y, px, c) => [tx(t, x + 1.4, y + 1.6, '700 ' + px + 'px Fredoka, Nunito, sans-serif', '#1a1030'), tx(t, x, y, '700 ' + px + 'px Fredoka, Nunito, sans-serif', c)];

/* ---------- COMMON: comic book box ---------- */
function heroComic() {
  const ink = '#4a2a14', B = Box(-48, -82, 40, 0, 26), x0 = -48, x1 = 40;
  const body = [...boxFill(B, { f: ['#f2c88c', '#ddaa68', '#bd8848'], t: ['#3a1e08', '#5a3414'], s: ['#c8935a', '#93602e'] }), ...boxShade(B, ink, { only: 'S' })];
  for (let r = 0; r < 7; r++) for (let c = 0; c < 9; c++) body.push(sh(ell(-44 + c * 10 + (r % 2) * 5, -6 - r * 11, 1.6), 'rgba(230,60,60,0.22)'));
  const pnl = rect(-42, -76, 76, 42, 3);
  body.push(sh(pnl, lg(0, -76, 0, -34, '#7ad0ff', '#3a8ae8')), sh(burst(-4, -55, 34, 22, 12), 'rgba(255,255,255,0.35)', { clip: pnl }), ...clipAll(mask(-4, -55, 18, lg(-22, 0, 14, 0, '#ff5a5a', '#d81e2a'), '#1a1030'), pnl), st(pnl, '#1a1030', 2.4), ...logo('HERO', -16, -21, 15, '#ffd23a'), ...logo('COMICS', -16, -8.5, 7.5, '#ffffff'));
  body.push(...onP([sh(burst(13, -42, 9, 6, 8), '#ffd23a', { s: '#1a1030', w: 1 }), ...bolt(13, -42, 9, '#ff5a5a', '#1a1030')], B.pS), ...boxShade(B, ink, { only: 'F', k: 0.7 }));
  const flaps = [sh(poly([P3(x0, -82, 26), P3(x1, -82, 26), P3(x1, -98, 17), P3(x0, -98, 17)]), lg(...P3(x0, -98, 17), ...P3(x0, -82, 26), '#f8d8a4', '#d8a868'), { s: ink, w: 2 }),
    sh(poly([P3(x0, -82, 0), P3(x1, -82, 0), P3(x1, -95, 9), P3(x0, -95, 9)]), lg(...P3(x0, -95, 9), ...P3(x0, -82, 0), '#fbe4ba', '#e6bb84'), { s: ink, w: 2 }), ...onP(logo('POW', 0, 0, 7, '#e5303a'), (a, b) => P3(-8 + a, -89 + b, 4.5))];
  const cape = [sh(parse(`M${P3(18, -82, 12).join(' ')} Q${P3(26, -82, 12)[0]} ${P3(26, -82, 12)[1]} ${P3(30, -82, 12).join(' ')} L${P3(40, -60, 0)[0] + 6} -40 Q${P3(40, -60, 0)[0] - 2} -36 ${P3(40, -60, 0)[0] - 4} -44 Q24 -60 18 -76 Z`), lg(18, -80, 50, -40, '#ff5a5a', '#d81e2a', '#8a0a14'), { s: '#5a0610', w: 1.4 }), st(parse('M24 -76 Q30 -62 40 -48'), 'rgba(255,255,255,0.35)', 1.2)];
  const pow = [sh(burst(28, -14, 12, 8, 10), lg(16, -26, 40, -2, '#fff6a0', '#ffd23a', '#ff9a1a'), { s: '#1a1030', w: 1.4 }), ...logo('POW!', 28, -13.4, 7, '#e5303a')];
  const tp = poly([[-34, -88], [-24, -88], [-24, -70], [-34, -70]]), tape = [sh(tp, 'rgba(250,232,180,0.92)'), st(tp, 'rgba(150,100,40,0.55)', 1), st(line([[-32, -86], [-32, -72]]), 'rgba(255,255,255,0.7)', 1)];
  return { name: 'Comic Book Box', mat: 'comic', hp: 6, W: 112, H: 137, ko: 'halves',
    hull: cvx(B.pts.concat([P3(x0, -98, 17), P3(x1, -98, 17), [P3(40, -60, 0)[0] + 6, -40]])),
    parts: [{ id: 'body', sh: body }, { id: 'cape', sh: cape, tear: 0.46, hang: P3(24, -82, 12), loose: 0.1, hmax: 0.5, hdir: 1 }, { id: 'tape', sh: tape, tear: 0.6, hang: [-29, -88], loose: 0.3, hmax: 0.4, hdir: -1 }, { id: 'pow', sh: pow, tear: 0.34 }, { id: 'flaps', sh: flaps, launch: true, launchV: 400 }],
    loot: ['mask', 'coin', 'bolt', 'star'] };
}

/* ---------- RARE: hero lunchbox ---------- */
function heroLunch() {
  const ink = '#1a1030', B = Box(-64, -64, 46, 0, 32), L = Box(-66, -80, 48, -64, 34, -1);
  const body = [...boxFill(B, { f: ['#ff6a6a', '#e5303a', '#a8141e'], t: ['#ff8a8a', '#e5303a'], s: ['#c41e2a', '#7a0a14'] }), sh(rect(-60, -58, 102, 52, 8), 'rgba(255,255,255,0.12)', { s: 'rgba(255,255,255,0.5)', w: 1.6 })];
  body.push(sh(ell(-30, -32, 21), lg(-50, -52, -10, -12, '#fff6a0', '#ffd23a', '#e8a400'), { s: ink, w: 2 }), sh(star5(-30, -32, 15, 6.5), '#ffffff', { s: ink, w: 1.6 }), ...logo('SQUISH', 16, -40, 10, '#ffd23a'), ...logo('SQUAD', 16, -27, 10, '#ffffff'));
  body.push(...onP([sh(ell(16, -32, 11), '#2a5ad8', { s: ink, w: 1.4 }), sh(star5(16, -32, 7, 3), '#ffffff')], B.pS), ...boxShade(B, ink, { k: 0.9 }));
  const lid = [...boxFill(L, { f: ['#6a94ff', '#2a5ad8', '#16348a'], t: ['#8aacff', '#3a6ae8'], s: ['#2448b8', '#0e2068'] })];
  for (let x = -58; x < 44; x += 12) lid.push(sh(star5(x, -72, 2.6, 1.2), '#ffffff', { a: 0.8 }));
  lid.push(...onP([[-50, 10], [-30, 24], [10, 8], [30, 24]].map(([u, w]) => sh(star5(u, w, 3, 1.4), '#ffffff', { a: 0.8 })), L.pT), ...boxShade(L, ink, { k: 0.9 }));
  const hA = L.pT(-34, 17), hB = L.pT(16, 17), hm = [(hA[0] + hB[0]) / 2, (hA[1] + hB[1]) / 2 - 30], hd = parse(`M${hA[0]} ${hA[1]} C${hA[0]} ${hm[1]} ${hB[0]} ${hm[1]} ${hB[0]} ${hB[1]}`);
  const handle = [st(hd, ink, 9), st(hd, lg(0, hm[1], 0, hA[1], '#fff6a0', '#ffd23a', '#c88a00'), 6.4), st(shift(hd, -0.8, -1), 'rgba(255,255,255,0.6)', 1.4), ...[hA, hB].map(p => sh(rect(p[0] - 5, p[1] - 3, 10, 6, 2), '#2a2a3a', { s: ink, w: 1 }))];
  const latch = [sh(rect(-16, -72, 14, 20, 3), sv(-16, 0, -2, 0), { s: '#3a4660', w: 1.3 }), sh(rect(-13, -58, 8, 4, 1.5), '#3a4660'), st(line([[-13, -69], [-13, -61]]), 'rgba(255,255,255,0.8)', 1)];
  const stk = [st(star5(38, -14, 9, 4), '#ffffff', 4), sh(star5(38, -14, 9, 4), '#ffd23a', { s: ink, w: 1 })];
  const bp = B.pS(16, -12), side = [sh(burst(bp[0], bp[1], 8, 5, 8), '#ffd23a', { s: ink, w: 1 }), ...bolt(bp[0], bp[1], 9, '#2a5ad8', ink)];
  return { name: 'Hero Lunchbox', mat: 'lunch', hp: 8, W: 150, H: 140, ko: 'pie', pieN: 6,
    hull: cvx(B.pts.concat(L.pts, [[hm[0], hm[1] + 6]])),
    parts: [{ id: 'body', sh: body }, { id: 'stk', sh: stk, tear: 0.3 }, { id: 'side', sh: side, tear: 0.54 }, { id: 'lid', sh: lid, launch: true }, { id: 'latch', sh: latch, tear: 0.42, hang: [-9, -72], loose: 0.15, hmax: 0.6, hdir: 1 }, { id: 'handle', sh: handle, tear: 0.66, launch: true }],
    loot: ['mask', 'coin', 'bolt', 'star', 'coin'] };
}

/* ---------- EPIC: hero gear locker ---------- */
function heroLocker() {
  const ink = '#141a2a', B = Box(-84, -80, 54, 0, 40), L = Box(-87, -96, 57, -80, 43, -1.5);
  const body = [...boxFill(B, { f: ['#8a9ac0', '#5a6a8a', '#36405a'], t: ['#9aaac8', '#6a7a9a'], s: ['#4a5672', '#262e40'] })];
  for (let x = -78; x <= 48; x += 14) body.push(H.nail(x, -75, 1.6), H.nail(x, -5, 1.6));
  [-60, -40, -20].forEach(y => body.push(H.nail(-79, y, 1.6), H.nail(49, y, 1.6)));
  body.push(...onP([...[0, 1, 2, 3, 4].map(k => sh(rect(8, -68 + k * 9, 24, 4, 2), '#1a2030', { s: 'rgba(255,255,255,0.25)', w: 0.8 })), sh(rect(6, -22, 28, 14, 3), '#2a3448', { s: ink, w: 1 }), sh(ell(14, -15, 2.4), '#5aff7a', { g: '#5aff7a', gb: 6 }), sh(ell(22, -15, 2.4), '#ff5a5a')], B.pS));
  body.push(sh(rect(-84, -30, 138, 14), lg(0, -30, 0, -16, '#5a3a24', '#3a2210'), { s: ink, w: 1.2 }), sh(B.side(rect(0, -30, 40, 14)), lg(...P3(54, -30, 0), ...P3(54, -16, 0), '#4a2e1a', '#2a1808'), { s: ink, w: 1 }), st(line([[-82, -27], [52, -27]]), 'rgba(255,220,180,0.35)', 1), ...boxShade(B, ink, { k: 0.85 }));
  const lid = [...boxFill(L, { f: ['#ff6a6a', '#d8303a', '#8a0a14'], t: ['#ff8a8a', '#e5404a'], s: ['#b41e2a', '#6a0610'] }), sh(rect(-87, -91, 144, 4), '#ffffff', { a: 0.85 }), sh(L.side(rect(0, -91, 43, 4)), '#e8e8f0'), ...onP([sh(rect(-87, 19, 144, 5), '#ffffff', { a: 0.85 })], L.pT), ...boxShade(L, ink, { k: 0.85 })];
  const sword = (a, c) => { const f = (x, y) => L.pT(-15 + x * Math.cos(a) - y * Math.sin(a), 21.5 + (x * Math.sin(a) + y * Math.cos(a)) * 0.8), M = d => mapD(d, f);
    return [sh(M(parse('M-34 -4.4 L30 -4.4 L42 0 L30 4.4 L-34 4.4 Z')), lg(...f(0, -3), ...f(0, 3), '#ffffff', '#c8d0e0', '#8a96aa'), { s: ink, w: 1.2 }), st(M(line([[-30, 0], [32, 0]])), 'rgba(255,255,255,0.8)', 0.8), sh(M(rect(-39, -12, 6, 24, 2)), gl(...f(0, -9), ...f(0, 9)), { s: ink, w: 1.1 }), sh(M(rect(-57, -4.6, 18, 9.2, 3)), c, { s: ink, w: 1.1 }), ...[-52, -47, -42].map(x => st(M(line([[x, -3.4], [x + 2, 3.4]])), 'rgba(0,0,0,0.35)', 1)), sh(M(ell(-58, 0, 4)), gl(...f(-62, -4), ...f(-54, 4)), { s: ink, w: 1 })]; };
  const swords = [...sword(0.5, '#2a5ad8'), ...sword(-0.5, '#e5303a')];
  const cs = [corner3(B, -1, 1, 18, 6, 1.5, IRON, ink), corner3(B, 1, 1, 18, 6, 1.5, IRON, ink)];
  const shd = shield(-15, -54, 34), emb = [st(line([[-15, -73], [-15, -78]]), ink, 2), sh(shift(shd, 1.6, 1.8), 'rgba(0,0,20,0.35)'), sh(shd, lg(-32, -72, 2, -36, '#ff6a6a', '#d8303a', '#8a0a14'), { s: ink, w: 2 }), sh(shield(-15, -54, 25), lg(-28, -66, -2, -42, '#6a94ff', '#2a5ad8'), { s: '#ffffff', w: 2 }), sh(star5(-15, -55, 9, 3.8), '#ffffff', { s: ink, w: 1 })];
  const buckle = [sh(rect(-28, -33, 26, 20, 4), gl(-28, -33, -2, -13), { s: '#6a4200', w: 1.4 }), sh(rect(-23, -28, 16, 10, 2), lg(0, -28, 0, -18, '#5a3a24', '#3a2210')), sh(star5(-15, -23, 6, 2.6), gl(-21, -29, -9, -17), { s: '#6a4200', w: 0.8 })];
  const cap = [sh(parse('M-87 -95 L-62 -95 Q-58 -84 -62 -70 Q-60 -52 -66 -36 Q-74 -40 -78 -34 Q-84 -40 -90 -36 Q-92 -60 -88 -80 Z'), lg(-92, -96, -58, -36, '#ff6a6a', '#d8303a', '#8a0a14'), { s: '#5a0610', w: 1.5 }), st(parse('M-80 -92 Q-78 -70 -82 -44'), 'rgba(80,0,10,0.4)', 1.4), st(parse('M-70 -92 Q-68 -70 -72 -42'), 'rgba(80,0,10,0.4)', 1.4), st(parse('M-84 -90 Q-86 -70 -86 -50'), 'rgba(255,255,255,0.3)', 1.2)];
  const pad = [sh(rect(26, -76, 20, 24, 3), '#1e2638', { s: '#9aa4b8', w: 1.4 }), ...[0, 1, 2].flatMap(r => [0, 1, 2].map(c => sh(rect(29 + c * 5.4, -66 + r * 4.6, 4, 3.2, 1), '#c8d0e0'))), sh(rect(29, -73, 14, 4, 1), '#5aff7a', { g: '#5aff7a', gb: 5 })];
  return { name: 'Hero Gear Locker', mat: 'herosteel', hp: 10, W: 180, H: 150, ko: 'pie', pieN: 6,
    hull: cvx(B.pts.concat(L.pts, [L.pT(-75, 21), L.pT(45, 21), [-92, -36]])),
    parts: [{ id: 'body', sh: body }, { id: 'c0', sh: cs[0].sh, tear: 0.44 }, { id: 'c1', sh: cs[1].sh, tear: 0.78 }, { id: 'buckle', sh: buckle, tear: 0.5 }, { id: 'emb', sh: emb, tear: 0.66, hang: [-15, -76], loose: 0.4, hmax: 0.7, hdir: 1 },
      { id: 'lid', sh: lid, launch: true }, { id: 'cape', sh: cap, tear: 0.36, hang: [-74, -95], loose: 0.05, hmax: 0.4, hdir: -1 }, { id: 'pad', sh: pad, tear: 0.9, hang: [36, -76], loose: 0.6, hmax: 0.5, hdir: 1 }, { id: 'swords', sh: swords, launch: true, launchV: 420 }],
    loot: ['mask', 'coin', 'bolt', 'star', 'coin', 'gem'] };
}

/* ---------- LEGENDARY: hero HQ vault ---------- */
function heroHQ() {
  const ink = '#080c22', gi = '#6a4200', CHR = ['#ffffff', '#c8d0e0', '#5f6b80'];
  const niche = (x, w) => { const sd = shield(x + w / 2, -66, 30); return [sh(rect(x, -84, w, 34, 5), lg(x, -84, x + w, -50, '#0e1430', '#1e2a5e'), { s: gi, w: 1.4 }), sh(sd, lg(x, -80, x + w, -52, '#ff6a6a', '#d8303a'), { s: '#ffffff', w: 1.6 }), sh(star5(x + w / 2, -67, 7, 3), '#ffffff'), st(line([[x + 3, -80], [x + 3, -54]]), '#5ac8ff', 2, { g: '#5ac8ff', gb: 8 }), st(line([[x + w - 3, -80], [x + w - 3, -54]]), '#5ac8ff', 2, { g: '#5ac8ff', gb: 8 })]; };
  return vault({ name: 'Hero HQ Vault', mat: 'herovault', ink, gi, C: { f: ['#5a6aaa', '#1e2a5e', '#0e1430'], t: ['#6a7aba', '#2a3a74'], s: ['#18224e', '#080c22'] },
    LC: { f: ['#ff6a6a', '#d8202a', '#7a0a0a'], t: ['#ff8a8a', '#e5303a'], s: ['#b41e2a', '#5a0408'] },
    front: () => [...niche(-86, 34), ...niche(18, 34), ...[-80, -60, 28, 48].map(x => sh(star5(x, -18, 6, 2.6), gl(x - 6, -24, x + 6, -12), { s: gi, w: 1 }))], side: () => niche(5, 32), band: [-46, 12, '#ff6a6a', '#d8202a', '#7a0a0a'], gems: ['#5ac8ff', '#ffd23a'],
    lid: 'box', lidDeco: ({ L }) => [st(line([[-90, -100], [58, -100]]), '#5ac8ff', 2.4, { g: '#5ac8ff', gb: 10 }), st(L.side(line([[2, -100], [43, -100]])), '#5ac8ff', 2.2, { g: '#5ac8ff', gb: 8 }), ...onP([-70, -40, -10, 20, 48].map(u => sh(star5(u, 22, 4, 1.8), '#ffd23a', { s: gi, w: 0.8 })), L.pT)],
    crest: T => [sh(ell(T[0], T[1] + 2, 20, 4), 'rgba(0,0,20,0.35)'), ...wing(T[0] - 8, T[1] - 10, 30, -1, gl(T[0] - 40, T[1] - 30, T[0] - 8, T[1]), '#7a4800'), ...wing(T[0] + 8, T[1] - 10, 30, 1, gl(T[0] + 8, T[1] - 30, T[0] + 40, T[1]), '#7a4800'), ...mask(T[0], T[1] - 10, 16, gl(T[0] - 16, T[1] - 18, T[0] + 16, T[1] - 2), '#7a4800'), sh(star5(T[0], T[1] - 28, 9, 4), gl(T[0] - 9, T[1] - 37, T[0] + 9, T[1] - 19), { s: '#7a4800', w: 1.2 }), ...gemS(T[0], T[1] - 28, 2.6, '#ff3a5a', gi)], crestH: 40,
    corner: (x, y) => ball(x, y, 8.5, '#3a4660', CHR),
    med: cx => { const o = [st(line([[cx, -40], [cx, -36]]), gi, 2.2), sh(ell(cx + 1.6, -18.4, 15), 'rgba(0,0,20,0.35)'), sh(ell(cx, -20, 15), sv(cx - 15, -35, cx + 15, -5), { s: '#3a4660', w: 1.8 }), st(ell(cx, -20, 11.5), 'rgba(60,70,96,0.6)', 1.4)];
      for (let k = 0; k < 6; k++) { const a = k * PI / 3 + 0.3; o.push(st(line([[cx + Math.cos(a) * 4, -20 + Math.sin(a) * 4], [cx + Math.cos(a) * 12, -20 + Math.sin(a) * 12]]), '#3a4660', 3), st(line([[cx + Math.cos(a) * 4, -20 + Math.sin(a) * 4], [cx + Math.cos(a) * 12, -20 + Math.sin(a) * 12]]), '#e8eef8', 1.6)); }
      o.push(sh(ell(cx, -20, 5), gl(cx - 5, -25, cx + 5, -15), { s: gi, w: 1.2 }), sh(star5(cx, -20, 3.2, 1.4), '#ffffff'), sh(ell(cx - 7, -28, 3, 1.8), 'rgba(255,255,255,0.85)')); return o; },
    loot: ['mask', 'coin', 'gem', 'bolt', 'star', 'coin'] });
}

/* ---------- RAINBOW: legend treasury ---------- */
function heroLegend() {
  const ik = '#8a5200';
  return treasury({ name: 'Rainbow Legend Treasury', mat: 'legendgem',
    art: [(x, y, s) => mask(x, y, s * 0.42, RBW(x, y), ik), (x, y, s) => [sh(star5(x, y + 2, s * 0.42, s * 0.19), RBW(x, y), { s: ik, w: 2 })], (x, y, s) => bolt(x, y, s * 0.8, RBW(x, y), ik), (x, y, s) => [sh(shield(x, y, s * 0.7), RBW(x, y), { s: ik, w: 2 }), sh(star5(x, y - 1, s * 0.16, s * 0.07), '#ffffff')]],
    lid: ink => rbLid(ink, (u, w) => { const a = Math.atan2((w - 0.5) * 1.3, u - 0.5); return Math.floor((a / TAU + 1) * 18) % 2 ? mixH(pal(u), '#ffffff', 0.15) : mixH(pal(u), '#ffffff', 0.55); }, { h: 42, k: 0.5, nu: 30, nv: 14 }),
    crest: (T, ink) => [sh(ell(T[0], T[1] + 2, 20, 4), 'rgba(60,0,80,0.3)'), ...wing(T[0] - 8, T[1] - 12, 30, -1, gl(T[0] - 40, T[1] - 32, T[0] - 8, T[1]), '#7a4800'), ...wing(T[0] + 8, T[1] - 12, 30, 1, gl(T[0] + 8, T[1] - 32, T[0] + 40, T[1]), '#7a4800'),
      sh(star5(T[0], T[1] - 16, 19, 8.5), gl(T[0] - 19, T[1] - 35, T[0] + 19, T[1] + 3), { s: '#7a4800', w: 1.8 }), ...mask(T[0], T[1] - 16, 9, RBW(T[0], T[1] - 16, 1.4), '#7a4800')], crestH: 44,
    lock: (x, ink) => [sh(rect(x - 5, -97, 10, 14, 4), gl(x - 5, 0, x + 5, 0), { s: ink, w: 1.3 }), ...bolt(x, -64, 40, gl(x - 14, -84, x + 14, -44), '#7a4800'), ...gemS(x + 1, -66, 4, '#3aa8ff', ink)],
    loot: ['mask', 'gem', 'bolt', 'star', 'coin', 'gem'] });
}

/* ---------- loot icons ---------- */
function icMask(c, s) { c.fillStyle = '#e5303a'; c.strokeStyle = '#1a1030'; c.lineWidth = s * 0.05; c.beginPath(); c.moveTo(-s * 0.46, -s * 0.04); c.quadraticCurveTo(-s * 0.42, -s * 0.24, -s * 0.18, -s * 0.22); c.quadraticCurveTo(0, -s * 0.2, 0, -s * 0.1); c.quadraticCurveTo(0, -s * 0.2, s * 0.18, -s * 0.22); c.quadraticCurveTo(s * 0.42, -s * 0.24, s * 0.46, -s * 0.04); c.quadraticCurveTo(s * 0.36, s * 0.18, s * 0.16, s * 0.14); c.quadraticCurveTo(0, s * 0.12, 0, s * 0.04); c.quadraticCurveTo(0, s * 0.12, -s * 0.16, s * 0.14); c.quadraticCurveTo(-s * 0.36, s * 0.18, -s * 0.46, -s * 0.04); c.closePath(); c.fill(); c.stroke(); c.fillStyle = '#ffffff'; [-1, 1].forEach(d => { c.beginPath(); c.ellipse(d * s * 0.2, -s * 0.02, s * 0.1, s * 0.07, 0, 0, TAU); c.fill(); c.stroke(); }); }
function icBolt(c, s) { c.beginPath(); [[0.06, -0.46], [-0.26, 0.04], [-0.02, 0.04], [-0.12, 0.46], [0.28, -0.08], [0.04, -0.08], [0.18, -0.46]].forEach(([x, y], i) => i ? c.lineTo(x * s, y * s) : c.moveTo(x * s, y * s)); c.closePath(); const g = c.createLinearGradient(0, -s * 0.4, 0, s * 0.4); g.addColorStop(0, '#fff6a0'); g.addColorStop(1, '#ffb020'); c.fillStyle = g; c.fill(); c.strokeStyle = '#8a5200'; c.lineWidth = s * 0.05; c.stroke(); }

const Cd = CM.MAT.candy, Mt = CM.MAT.metal, Ca = CM.MAT.card;
CM.register('heroes', [heroComic, heroLunch, heroLocker, heroHQ, heroLegend], {
  mat: {
    comic: Object.assign({}, Ca, { chips: ['#dba566', '#c08548', '#ffd23a', '#e5303a', '#3a8ae8'], sfx: { m: 'card', p: 0.92 } }),
    lunch: { soft: 0.4, lean: 4, sag: 3, dentK: 6, dentShade: 0.3, holeFrom: 0.3, holeP: 0.6, holeR: [15, 21], jag: 'shard', edge: '#ffffff', edgeW: 6, crack: 'stress', chips: ['#e5303a', '#2a5ad8', '#ffd23a', '#ffffff'], deb: 'chip', dust: '#f0eef6', mass: 1.1, sfx: { m: 'plastic', p: 0.9, x: ['latch'] }, rest: 0.32, cav: ['#0e0a1e', '#22183a'], glow: '#ffe066' },
    herosteel: Object.assign({}, Mt, { chips: ['#5a6a8a', '#d8303a', '#c9d3e0', '#ffd23a', '#2a5ad8'], dust: '#e2e4ec', sfx: { m: 'iron', p: 1 }, cav: ['#060810', '#141a2a'], glow: '#9fd8ff' }),
    herovault: Object.assign({}, Mt, { chips: ['#1e2a5e', '#d8202a', '#ffd23a', '#5ac8ff', '#c9d3e0'], dust: '#e2e4f0', sfx: { m: 'steel', p: 1, x: ['vault'] }, cav: ['#04060e', '#0e1430'], glow: '#9fe8ff' }),
    legendgem: Object.assign({}, Cd, { sfx: { m: 'steel', p: 1.1, x: ['vault', 'rainbow'] } }),
  },
  crack: { stress: [['rgba(255,255,255,0.85)', 2, 0, 0], ['rgba(0,20,60,0.3)', 1, 1, 1]] },
  icons: { mask: icMask, bolt: icBolt },
});
}
(function go() { if (window.ChestModels && window.ChestModels.K) run(); else setTimeout(go, 30); })();
})();
