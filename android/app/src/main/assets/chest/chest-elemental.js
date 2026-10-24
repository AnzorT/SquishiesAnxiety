// Elemental Heroes chests for ChestModels: Cracked Ember Rock -> Rune Stone Chest -> Elemental Forge Chest -> Magma Core Vault -> Rainbow Prism Treasury.
(function () {
'use strict';
function run() {
const CM = window.ChestModels, H = CM.H, K = CM.K;
const { parse, poly, line, rect, ell, shift, spark4, star5, lg, rg, sh, st, tx, P3, mapD, onP, Box, cvx, boxFill, boxShade, corner3, surf, Barrel, nail } = H;
const { PI, TAU, mixH, R2, gl, ir, gemS, IRON, ball, vault, treasury, rbLid, pal, RBW, clipAll } = K;
const EL = { fire: ['#fff0a0', '#ff7a1a', '#a8200a'], water: ['#d8f6ff', '#3aa8ff', '#0e3a9a'], earth: ['#e0ffb0', '#4ac05a', '#0e5a24'], air: ['#ffffff', '#c8e4f4', '#7a9ab8'] };
const crystal = (x, y, w, h, a, C, ink) => { const f = R2(x, y, 1, a || 0), M = d => mapD(d, f), out = [sh(M(poly([[-w / 2, 0], [-w / 2, -h * 0.8], [0, -h], [0, 0]])), lg(...f(-w / 2, 0), ...f(0, 0), C[0], C[1]), { s: ink, w: 1.1 }), sh(M(poly([[0, 0], [0, -h], [w / 2, -h * 0.8], [w / 2, 0]])), lg(...f(0, 0), ...f(w / 2, 0), C[1], C[2]), { s: ink, w: 1.1 })];
  out.push(st(M(line([[-w * 0.3, -h * 0.1], [-w * 0.3, -h * 0.72]])), 'rgba(255,255,255,0.7)', Math.max(0.8, w * 0.08))); return out; };
const lava = (pts, w) => [st(line(pts), '#3a0a00', w + 2.4), st(line(pts), '#ff7a1a', w, { g: '#ff6a00', gb: 9 }), st(line(pts), '#fff0a0', Math.max(0.6, w * 0.35))];
const zig = (x0, y0, x1, y1, n, j, sd) => Array.from({ length: n + 1 }, (_, i) => { const t = i / n; return [x0 + (x1 - x0) * t + (i % 2 ? j : -j) * Math.cos(sd + i), y0 + (y1 - y0) * t + (i % 2 ? -j : j) * Math.sin(sd + i * 1.3) * 0.6]; });
const flame = (x, y, s, f, ink) => [sh(parse(`M${x} ${y + s * 0.5} C${x - s * 0.5} ${y + s * 0.5} ${x - s * 0.5} ${y} ${x - s * 0.2} ${y - s * 0.2} C${x - s * 0.24} ${y + s * 0.05} ${x - s * 0.08} ${y + s * 0.06} ${x - s * 0.06} ${y - s * 0.12} C${x - s * 0.1} ${y - s * 0.32} ${x + s * 0.06} ${y - s * 0.4} ${x + s * 0.08} ${y - s * 0.56} C${x + s * 0.3} ${y - s * 0.34} ${x + s * 0.5} ${y} ${x + s * 0.4} ${y + s * 0.24} C${x + s * 0.34} ${y + s * 0.44} ${x + s * 0.2} ${y + s * 0.5} ${x} ${y + s * 0.5} Z`), f, { s: ink, w: Math.max(1, s * 0.06) })];
const drop = (x, y, s, f, ink) => [sh(parse(`M${x} ${y - s * 0.5} C${x + s * 0.1} ${y - s * 0.25} ${x + s * 0.36} ${y - s * 0.05} ${x + s * 0.36} ${y + s * 0.16} C${x + s * 0.36} ${y + s * 0.4} ${x + s * 0.18} ${y + s * 0.52} ${x} ${y + s * 0.52} C${x - s * 0.18} ${y + s * 0.52} ${x - s * 0.36} ${y + s * 0.4} ${x - s * 0.36} ${y + s * 0.16} C${x - s * 0.36} ${y - s * 0.05} ${x - s * 0.1} ${y - s * 0.25} ${x} ${y - s * 0.5} Z`), f, { s: ink, w: Math.max(1, s * 0.06) })];
const leaf = (x, y, s, f, ink) => [sh(parse(`M${x - s * 0.3} ${y + s * 0.4} Q${x - s * 0.4} ${y - s * 0.3} ${x + s * 0.3} ${y - s * 0.44} Q${x + s * 0.34} ${y + s * 0.24} ${x - s * 0.3} ${y + s * 0.4} Z`), f, { s: ink, w: Math.max(1, s * 0.06) }), st(parse(`M${x - s * 0.3} ${y + s * 0.4} Q${x} ${y} ${x + s * 0.22} ${y - s * 0.32}`), 'rgba(255,255,255,0.6)', Math.max(0.8, s * 0.04))];
const swirl = (x, y, s, c, ink) => [0, 1, 2].map(k => st(parse(`M${x - s * 0.42} ${y - s * 0.22 + k * s * 0.22} L${x + s * 0.18} ${y - s * 0.22 + k * s * 0.22} Q${x + s * 0.42} ${y - s * 0.3 + k * s * 0.22} ${x + s * 0.32} ${y - s * 0.42 + k * s * 0.22}`), c, Math.max(1.6, s * 0.08))).concat(ink ? [] : []);
const orb = (x, y, r, ink) => { const q = (a0, C) => sh(parse(`M${x} ${y} L${x + Math.cos(a0) * r} ${y + Math.sin(a0) * r} Q${x + Math.cos(a0 + PI / 4) * r * 1.42} ${y + Math.sin(a0 + PI / 4) * r * 1.42} ${x + Math.cos(a0 + PI / 2) * r} ${y + Math.sin(a0 + PI / 2) * r} Z`), rg(x - r * 0.3, y - r * 0.3, r * 1.3, C[0], C[1], C[2]));
  return [q(-PI, EL.fire), q(-PI / 2, EL.water), q(0, EL.earth), q(PI / 2, EL.air), st(ell(x, y, r), ink, 1.6), sh(ell(x - r * 0.35, y - r * 0.4, r * 0.3, r * 0.2), 'rgba(255,255,255,0.85)')]; };

/* ---------- COMMON: cracked ember rock ---------- */
function elemRock() {
  const ink = '#2a2430', dx = 20, dy = -16, F = [[-50, 0], [-52, -34], [-44, -70], [-14, -84], [22, -80], [44, -58], [48, -20], [42, 0]], d = p => [p[0] + dx, p[1] + dy];
  const topE = [F[2], F[3], F[4], F[5]], sideE = [F[5], F[6], F[7]];
  const top = poly(topE.concat(topE.slice().reverse().map(d))), side = poly(sideE.concat(sideE.slice().reverse().map(d))), front = poly(F);
  const body = [sh(side, lg(44, -60, 66, 0, '#6e6878', '#3e3846')), ...[[F[6], d(F[6])]].map(p => st(line(p), 'rgba(20,10,30,0.45)', 1.4)), st(side, ink, 2.4)];
  const FC = [[[-52, -34], [-44, -70], [-14, -84], [-20, -40], '#c8c2d0', '#a8a2b2'], [[-14, -84], [22, -80], [14, -46], [-20, -40], '#d6d0dc', '#b4aec0'], [[22, -80], [44, -58], [46, -34], [14, -46], '#a8a2b2', '#86808f'],
    [[-50, 0], [-52, -34], [-20, -40], [-30, 0], '#aaa4b4', '#8a8494'], [[-30, 0], [-20, -40], [14, -46], [10, 0], '#b8b2c0', '#948e9e'], [[10, 0], [14, -46], [46, -34], [48, -20], [42, 0], '#8e8898', '#6a6474']];
  FC.forEach(f => { const pts = f.filter(q => Array.isArray(q)), c = f.filter(q => typeof q === 'string'), P = poly(pts); body.push(sh(P, lg(pts[0][0], pts[0][1], pts[2][0], pts[2][1], c[0], c[1])), st(P, 'rgba(40,30,50,0.45)', 1.2)); });
  for (let i = 0; i < 26; i++) body.push(sh(ell(-46 + (i * 41) % 90, -6 - (i * 29) % 74, 0.9 + (i % 3) * 0.5), i % 2 ? 'rgba(40,30,50,0.35)' : 'rgba(255,255,255,0.4)'));
  body.push(st(line([[-44, -70], [-14, -84], [22, -80]]), 'rgba(255,255,255,0.55)', 1.6), ...lava([[-2, -82], [-8, -66], [2, -56], [-6, -42], [4, -30], [-2, -14]], 2.4), ...lava([[-6, -42], [-20, -36], [-28, -40]], 1.6), ...lava([[2, -56], [16, -60]], 1.4), ...lava([[46, -40], [52, -46], [58, -44]], 1.2), st(front, ink, 2.6));
  const lidS = [sh(top, lg(-44, -100, 66, -60, '#e2dce8', '#b4aec0')), st(line([d(F[3]), F[3]]), 'rgba(40,30,50,0.35)', 1.2), st(line([d(F[4]), F[4]]), 'rgba(40,30,50,0.35)', 1.2), st(top, ink, 2.4), ...lava([[-12, -80], [-4, -88], [8, -86], [16, -94]], 1.4), sh(ell(-12, -92, 12, 4), 'rgba(255,255,255,0.3)')];
  const cr = [...crystal(30, -86, 9, 22, 0.35, ['#d8f6ff', '#3ac8e8', '#0e5a8a'], ink), ...crystal(22, -82, 7, 15, -0.2, ['#f0d8ff', '#a05cff', '#4a1a8a'], ink), ...crystal(37, -80, 6, 12, 0.8, ['#d8f6ff', '#3ac8e8', '#0e5a8a'], ink)];
  const peb = [[-58, -2, 7, 4.5], [-46, 0, 5, 3.4], [54, -1, 6, 4]].flatMap(([x, y, a, b]) => [sh(ell(x, y, a, b), rg(x - 2, y - 2, a * 1.4, '#c8c2d0', '#8e8898', '#5a5464'), { s: ink, w: 1.2 })]);
  const rune = [sh(ell(-30, -58, 9), 'rgba(0,0,0,0)', { s: '#5ac8ff', w: 1.6, g: '#5ac8ff', gb: 6 }), st(parse('M-30 -64 L-30 -52 M-34 -60 L-26 -56 M-34 -56 L-26 -60'), '#5ac8ff', 1.4, { g: '#5ac8ff', gb: 6 })];
  return { name: 'Cracked Ember Rock', mat: 'rock', hp: 6, W: 112, H: 137, ko: 'halves',
    hull: cvx(F.concat(F.map(d), [[30, -108], [44, -90], [-62, 4], [60, 3]])),
    parts: [{ id: 'body', sh: body }, { id: 'rune', sh: rune, tear: 0.62 }, { id: 'top', sh: lidS, launch: true, launchV: 360 }, { id: 'cr', sh: cr, tear: 0.34 }, { id: 'peb', sh: peb, tear: 0.5 }],
    loot: ['flame', 'coin', 'gem', 'bolt'] };
}

/* ---------- RARE: rune stone chest ---------- */
function elemRune() {
  const ink = '#141a2a', B = Box(-66, -76, 48, 0, 36), L = Box(-70, -90, 52, -76, 40, -2);
  const SL = { f: ['#9aa8c0', '#6a7890', '#465268'], t: ['#aab6cc', '#7a88a0'], s: ['#56627a', '#2e384c'] }, SD = { f: ['#7e8aa4', '#525e78', '#343e54'], t: ['#96a2bc', '#66728c'], s: ['#444e66', '#222a3c'] };
  const glyph = (x, y, r) => [st(ell(x, y, r), '#5ae8ff', 1.8, { g: '#3ac8ff', gb: 8 }), st(ell(x, y, r * 0.7), 'rgba(90,232,255,0.5)', 1), st(parse(`M${x} ${y - r * 0.6} L${x} ${y + r * 0.6} M${x - r * 0.5} ${y - r * 0.2} L${x} ${y - r * 0.6} L${x + r * 0.5} ${y - r * 0.2} M${x - r * 0.4} ${y + r * 0.3} L${x + r * 0.4} ${y + r * 0.3}`), '#5ae8ff', 1.6, { g: '#3ac8ff', gb: 8 })];
  const chips = (x0, x1, y) => { const o = []; for (let x = x0 + 6; x < x1; x += 13) o.push(sh(poly([[x, y], [x + 4, y + 3], [x + 8, y]]), 'rgba(40,46,64,0.45)')); return o; };
  const body = [...boxFill(B, SL), ...chips(-66, 48, -76), st(parse('M-60 -30 L-50 -38 L-44 -30 L-30 -36'), 'rgba(30,36,50,0.5)', 1.3), st(parse('M20 -12 L28 -20 L40 -16'), 'rgba(30,36,50,0.5)', 1.3), ...glyph(-38, -40, 16), ...glyph(14, -40, 16), ...onP(glyph(18, -40, 11), B.pS)];
  for (let i = 0; i < 18; i++) body.push(sh(ell(-62 + (i * 37) % 106, -6 - (i * 23) % 64, 1), 'rgba(255,255,255,0.3)'));
  body.push(...boxShade(B, ink, { k: 0.85 }));
  const lid = [...boxFill(L, SD), st(line([[-66, -83], [48, -83]]), '#5ae8ff', 1.6, { g: '#3ac8ff', gb: 8 }), ...[-56, -30, -4, 22].map(x => sh(parse(`M${x} -86 L${x + 4} -83 L${x} -80 L${x - 4} -83 Z`), '#5ae8ff', { g: '#3ac8ff', gb: 6 })), ...onP(chips(-70, 52, 0), L.pT), ...boxShade(L, ink, { k: 0.85 })];
  const tp = L.pT(-10, 20), top = [sh(ell(tp[0], tp[1], 14, 5), lg(tp[0] - 14, 0, tp[0] + 14, 0, '#7e8aa4', '#343e54'), { s: ink, w: 1.3 }), ...crystal(tp[0], tp[1] - 1, 16, 40, 0, ['#e0faff', '#5ae8ff', '#1a6ab8'], ink), ...crystal(tp[0] - 9, tp[1] + 1, 8, 18, -0.4, ['#e0faff', '#5ae8ff', '#1a6ab8'], ink), ...crystal(tp[0] + 9, tp[1] + 1, 8, 16, 0.45, ['#e0faff', '#5ae8ff', '#1a6ab8'], ink), sh(spark4(tp[0] + 12, tp[1] - 40, 5), '#ffffff'), st(parse(`M${tp[0] - 14} ${tp[1] - 30} L${tp[0] - 20} ${tp[1] - 24} L${tp[0] - 16} ${tp[1] - 22} L${tp[0] - 23} ${tp[1] - 14}`), '#ffe066', 1.6, { g: '#ffd23a', gb: 6 })];
  const tab = [st(parse('M-14 -76 L-18 -66 M-4 -76 L0 -66'), '#8a96aa', 1.4), sh(rect(-24, -66, 30, 20, 3), lg(0, -66, 0, -46, '#c8d0dc', '#8a96aa'), { s: ink, w: 1.3 }), st(parse('M-18 -60 L-12 -52 L-6 -60 L0 -52'), '#3a6ab8', 1.6)];
  const peb = [[-72, -1, 7, 4.5], [-60, 0, 5, 3.4], [56, -1, 6, 4]].flatMap(([x, y, a, b]) => [sh(ell(x, y, a, b), rg(x - 2, y - 2, a * 1.4, '#c8d0dc', '#8a96aa', '#465268'), { s: ink, w: 1.2 })]);
  const sk = B.pS(30, -72), spk = [...crystal(sk[0] + 4, sk[1] - 6, 6, 12, 0.3, ['#fff6c0', '#ffd23a', '#c88a00'], ink), sh(spark4(sk[0] + 12, sk[1] - 16, 4), '#ffffff')];
  return { name: 'Rune Stone Chest', mat: 'slate', hp: 8, W: 150, H: 140, ko: 'pie', pieN: 6,
    hull: cvx(B.pts.concat(L.pts, [[tp[0], tp[1] - 42], [-78, 3], [62, 3]])),
    parts: [{ id: 'body', sh: body }, { id: 'peb', sh: peb, tear: 0.5 }, { id: 'lid', sh: lid, launch: true }, { id: 'tab', sh: tab, tear: 0.3, hang: [-9, -76], loose: 0, hmax: 0.6, hdir: 1 }, { id: 'spk', sh: spk, tear: 0.62 }, { id: 'top', sh: top, launch: true, launchV: 420 }],
    loot: ['gem', 'coin', 'bolt', 'flame', 'gem'] };
}

/* ---------- EPIC: elemental forge chest ---------- */
function elemForge() {
  const ink = '#10141c', B = Box(-84, -78, 54, 0, 40), xa = -88, xb = 58, yb = -78, dh = 28;
  const body = [...boxFill(B, { f: ['#7a8494', '#4a525e', '#2a2e36'], t: ['#8a94a4', '#5a626e'], s: ['#3a404a', '#1a1e24'] })];
  for (let x = -78; x <= 48; x += 14) body.push(nail(x, -73, 1.7), nail(x, -5, 1.7));
  body.push(...onP([0, 1, 2, 3].map(k => sh(rect(8, -66 + k * 13, 24, 5, 2.5), lg(0, -66 + k * 13, 0, -61 + k * 13, '#fff0a0', '#ff7a1a', '#a8200a'), { s: ink, w: 1, g: '#ff6a00', gb: 8 })), B.pS));
  const sock = x => [sh(ell(x, -44, 13), lg(x - 13, -57, x + 13, -31, '#2a2e36', '#5a626e')), st(ell(x, -44, 13), '#6a4200', 4), st(ell(x, -44, 13), gl(x - 13, -57, x + 13, -31), 2.4), sh(ell(x, -44, 8.5), '#0a0c10')];
  const SX = [-66, -38, 8, 36]; SX.forEach(x => body.push(...sock(x)));
  body.push(...boxShade(B, ink, { k: 0.85 }));
  const gem = (x, k) => { const C = EL[k]; return [sh(ell(x, -44, 9), rg(x - 3, -47, 11, C[0], C[1], C[2]), { s: ink, w: 1, g: C[1], gb: 10 }), sh(ell(x - 3, -47.5, 2.6, 1.7), 'rgba(255,255,255,0.9)')]; };
  const gA = [...gem(SX[0], 'fire'), ...gem(SX[2], 'earth')], gB = [...gem(SX[1], 'water'), ...gem(SX[3], 'air')];
  const Bl = Barrel(xa, xb, yb, dh, 21, -1), cu = surf(Bl.f3, 22, 12, (u, v, i) => i % 2 ? '#5a626e' : '#525a66', { c: [-15, -68, 20], dk: '#06080c' }), lid = [...cu.sh];
  [0.15, 0.5, 0.85].forEach(u => cu.lineOn(Array.from({ length: 25 }, (_, i) => [u, i / 24]), 0.04).forEach(p => lid.push(st(p, ink, 9), st(p, ir(0, -110, 0, -78), 6.5))));
  [0.15, 0.5, 0.85].forEach(u => [0.15, 0.4, 0.62].forEach(v => { if (cu.visAt(u, v) > 0.05) { const p = cu.P(u, v); lid.push(nail(p[0], p[1], 1.7)); } }));
  const cp = cu.P(0.33, 0.48); lid.push(sh(ell(cp[0], cp[1], 15, 9), '#0a0c10', { s: '#6a4200', w: 3 }), sh(ell(cp[0], cp[1], 12, 7), RBW(cp[0], cp[1], 1.6)), sh(ell(cp[0], cp[1], 12, 7), rg(cp[0], cp[1], 12, 'rgba(255,255,255,0.7)', 'rgba(255,255,255,0)')), st(ell(cp[0], cp[1], 15, 9), gl(cp[0] - 15, cp[1] - 9, cp[0] + 15, cp[1] + 9), 1.6));
  lid.push(sh(Bl.cap, lg(...P3(xb, -106, 20), ...P3(xb, -78, 20), '#5a626e', '#1a1e24')), ...onP(orb(0, 0, 8, ink), (a, b) => P3(xb + 0.5, -88 + b, 20 + a)), st(Bl.cap, ink, 2.4), st(line([P3(xa, yb, -1), P3(xb, yb, -1)]), ink, 2.4));
  const link = (x, y, a) => st(mapD(ell(0, 0, 5, 2.8), R2(x, y, 1, a)), '#9aa2b0', 2.4);
  const chain = (x0, y0, x1, y1) => { const o = [], n = 12; for (let i = 0; i <= n; i++) { const t = i / n, x = x0 + (x1 - x0) * t, y = y0 + (y1 - y0) * t + Math.sin(t * PI) * 8, a = Math.atan2(y1 - y0, x1 - x0) + (i % 2 ? 0 : 0); o.push(st(mapD(ell(0, 0, 5, 2.8), R2(x, y, 1, a)), ink, 4.2), i % 2 ? st(line([[x - 3, y], [x + 3, y]]), '#9aa2b0', 2.4) : link(x, y, a)); } return o; };
  const chA = chain(-82, -74, 50, -10), chB = chain(-82, -10, 50, -74);
  const cs = [corner3(B, -1, 1, 18, 6, 1.5, IRON, ink), corner3(B, 1, 1, 18, 6, 1.5, IRON, ink)];
  const lock = [sh(rect(-26, -88, 22, 26, 5), gl(-26, -88, -4, -62), { s: '#6a4200', w: 1.4 }), ...orb(-15, -75, 7, '#6a4200')];
  return { name: 'Elemental Forge Chest', mat: 'forge', hp: 10, W: 180, H: 150, ko: 'pie', pieN: 6,
    hull: cvx(B.pts.concat(Bl.pts)),
    parts: [{ id: 'body', sh: body }, { id: 'gA', sh: gA, tear: 0.36 }, { id: 'gB', sh: gB, tear: 0.6 }, { id: 'c0', sh: cs[0].sh, tear: 0.44 }, { id: 'c1', sh: cs[1].sh, tear: 0.8 },
      { id: 'chA', sh: chA, tear: 0.5, hang: [-82, -74], loose: 0.25, hmax: 0.4, hdir: -1 }, { id: 'chB', sh: chB, tear: 0.72, hang: [50, -74], loose: 0.45, hmax: 0.4, hdir: 1 }, { id: 'lid', sh: lid, launch: true }, { id: 'lock', sh: lock, tear: 0.9, hang: [-15, -86], loose: 0.6, hmax: 0.5, hdir: 1 }],
    loot: ['flame', 'coin', 'gem', 'bolt', 'coin', 'drop2'] };
}

/* ---------- LEGENDARY: magma core vault ---------- */
function elemMagma() {
  const ink = '#060306', gi = '#6a4200';
  return vault({ name: 'Magma Core Vault', mat: 'magma', ink, gi, C: { f: ['#5a4a5a', '#241a24', '#0a060a'], t: ['#6a5a6a', '#2e222e'], s: ['#1e141e', '#060306'] },
    front: () => [...lava(zig(-86, -84, -50, -50, 6, 3, 1), 2.4), ...lava(zig(-50, -50, -30, -84, 4, 3, 2), 1.8), ...lava(zig(20, -84, 54, -52, 6, 3, 3), 2.4), ...lava(zig(-80, -30, -40, -12, 5, 2.6, 4), 1.8), ...lava(zig(16, -10, 52, -32, 5, 2.6, 5), 1.8), ...crystal(-69, -54, 10, 22, -0.2, EL.fire, ink), ...crystal(35, -54, 10, 22, 0.2, EL.water, ink)],
    side: () => [...lava(zig(4, -82, 38, -20, 7, 3, 6), 2), ...crystal(22, -50, 9, 20, 0.1, EL.fire, ink)], band: [-46, 12, '#fff0a0', '#ff7a1a', '#a8200a'], gems: ['#ff3a1a', '#5ac8ff'],
    lid: 'barrel', dh: 32, dk: '#000000', lidCol: (u, v, i, j) => (i + j) % 2 ? '#2e222e' : '#2a1e2a', capC: ['#3a2e3a', '#0a060a'],
    lidDeco: ({ cu }) => { const o = []; [[0.05, 0.2, 0.45, 0.7], [0.55, 0.15, 0.95, 0.6]].forEach(([u0, v0, u1, v1], k) => { const uv = Array.from({ length: 21 }, (_, i) => { const t = i / 20; return [u0 + (u1 - u0) * t + (i % 2 ? 0.012 : -0.012), v0 + (v1 - v0) * t + (i % 2 ? -0.03 : 0.03)]; }); cu.lineOn(uv, 0).forEach(p => o.push(st(p, '#3a0a00', 4.2), st(p, '#ff7a1a', 2.2, { g: '#ff6a00', gb: 9 }), st(p, '#fff0a0', 0.8))); }); return o; },
    crest: (T) => [sh(ell(T[0], T[1] + 2, 20, 5), 'rgba(0,0,0,0.4)'), ...crystal(T[0] - 12, T[1] + 2, 12, 26, -0.45, EL.water, '#2a0a00'), ...crystal(T[0] + 12, T[1] + 2, 12, 24, 0.45, ['#f0d8ff', '#a05cff', '#3a0a7a'], '#2a0a00'), ...crystal(T[0], T[1] + 3, 18, 44, 0, EL.fire, '#2a0a00'), sh(spark4(T[0] + 10, T[1] - 44, 6), '#fff6c0')], crestH: 50,
    corner: (x, y) => ball(x, y, 8.5, '#2a0a00', ['#fff0a0', '#ff7a1a', '#8a1a00']),
    med: cx => [st(line([[cx, -40], [cx, -36]]), gi, 2.2), sh(ell(cx + 1.4, -18.6, 14), 'rgba(0,0,0,0.4)'), sh(ell(cx, -20, 14), gl(cx - 14, -34, cx + 14, -6), { s: gi, w: 1.8 }), ...orb(cx, -20, 10, gi)],
    loot: ['flame', 'coin', 'gem', 'bolt', 'drop2', 'star'] });
}

/* ---------- RAINBOW: prism treasury ---------- */
function elemPrism() {
  const ik = '#8a5200';
  return treasury({ name: 'Rainbow Prism Treasury', mat: 'prism',
    art: [(x, y, s) => flame(x, y + 4, s * 0.76, RBW(x, y), ik), (x, y, s) => drop(x, y + 2, s * 0.72, RBW(x, y), ik), (x, y, s) => leaf(x, y, s * 0.8, RBW(x, y), ik), (x, y, s) => [st(ell(x, y, s * 0.3), RBW(x, y), 3), ...swirl(x, y, s * 0.7, '#7a5ae8')]],
    lid: ink => rbLid(ink, (u, w) => mixH(pal(u), '#ffffff', 0.35), { h: 26, k: 0.45, deco: cu => { const o = []; [[0.12, 0.3, 0.3], [0.3, 0.6, -0.2], [0.72, 0.62, 0.25], [0.88, 0.3, -0.3], [0.62, 0.25, 0.1], [0.24, 0.22, -0.4]].forEach(([u, w, a], i) => { if (cu.visAt(u, w) > 0) { const p = cu.P(u, w), c = pal(u); o.push(...crystal(p[0], p[1] + 2, 9 + (i % 2) * 3, 20 + (i % 3) * 5, a, [mixH(c, '#ffffff', 0.6), c, mixH(c, '#20002a', 0.35)], '#7a4800')); } }); return o; } }),
    crest: (T, ink) => [sh(ell(T[0], T[1] + 2, 16, 4), 'rgba(60,0,80,0.3)'), sh(ell(T[0], T[1], 14, 5), gl(T[0] - 14, T[1] - 5, T[0] + 14, T[1] + 5), { s: '#7a4800', w: 1.4 }), ...crystal(T[0], T[1], 22, 50, 0, ['#ffffff', '#c8b0ff', '#6a3ad8'], '#7a4800'), sh(poly([[T[0] - 11, T[1]], [T[0] - 11, T[1] - 40], [T[0], T[1] - 50], [T[0] + 11, T[1] - 40], [T[0] + 11, T[1]]]), RBW(T[0], T[1] - 24, 1.4), { a: 0.45 }), ...gemS(T[0], T[1] - 6, 3.4, '#ffb020', ink)], crestH: 56,
    lock: (x, ink) => [sh(rect(x - 5, -97, 10, 14, 4), gl(x - 5, 0, x + 5, 0), { s: ink, w: 1.3 }), sh(ell(x, -66, 17), gl(x - 17, -83, x + 17, -49), { s: '#7a4800', w: 2 }), ...orb(x, -66, 12, '#7a4800'), sh(ell(x, -54, 1.6), '#4a2600')],
    loot: ['flame', 'gem', 'bolt', 'star', 'drop2', 'coin'] });
}

/* ---------- loot icons ---------- */
function icFlame(c, s) { c.beginPath(); c.moveTo(0, s * 0.42); c.bezierCurveTo(-s * 0.4, s * 0.42, -s * 0.42, 0, -s * 0.16, -s * 0.18); c.bezierCurveTo(-s * 0.1, -s * 0.02, 0, -s * 0.04, -s * 0.02, -s * 0.14); c.bezierCurveTo(-s * 0.06, -s * 0.3, s * 0.06, -s * 0.36, s * 0.08, -s * 0.48); c.bezierCurveTo(s * 0.3, -s * 0.28, s * 0.42, 0, s * 0.34, s * 0.2); c.bezierCurveTo(s * 0.28, s * 0.36, s * 0.16, s * 0.42, 0, s * 0.42); c.closePath();
  const g = c.createRadialGradient(0, s * 0.18, 0, 0, 0, s * 0.5); g.addColorStop(0, '#fff6a0'); g.addColorStop(0.5, '#ff9a1a'); g.addColorStop(1, '#e5301a'); c.fillStyle = g; c.fill(); c.strokeStyle = '#8a1a00'; c.lineWidth = s * 0.05; c.stroke(); }
function icDrop(c, s) { c.beginPath(); c.moveTo(0, -s * 0.46); c.bezierCurveTo(s * 0.1, -s * 0.22, s * 0.32, -s * 0.04, s * 0.32, s * 0.14); c.bezierCurveTo(s * 0.32, s * 0.36, s * 0.16, s * 0.44, 0, s * 0.44); c.bezierCurveTo(-s * 0.16, s * 0.44, -s * 0.32, s * 0.36, -s * 0.32, s * 0.14); c.bezierCurveTo(-s * 0.32, -s * 0.04, -s * 0.1, -s * 0.22, 0, -s * 0.46); c.closePath();
  const g = c.createRadialGradient(-s * 0.1, 0, 0, 0, s * 0.1, s * 0.4); g.addColorStop(0, '#d8f6ff'); g.addColorStop(1, '#2a8ae8'); c.fillStyle = g; c.fill(); c.strokeStyle = '#0e3a9a'; c.lineWidth = s * 0.05; c.stroke(); c.fillStyle = 'rgba(255,255,255,0.8)'; c.beginPath(); c.ellipse(-s * 0.1, s * 0.08, s * 0.05, s * 0.1, 0.3, 0, TAU); c.fill(); }

const Cd = CM.MAT.candy, Mt = CM.MAT.metal;
const STONE = { soft: 0, lean: 2, sag: 1.5, dentK: 4, dentShade: 0.32, holeFrom: 0.3, holeP: 0.6, holeR: [15, 21], jag: 'ragged', edge: '#d8d2e0', edgeW: 6, crack: 'split', deb: 'chip', mass: 2, rest: 0.25, spark: '#ffd27a' };
CM.register('elemental', [elemRock, elemRune, elemForge, elemMagma, elemPrism], {
  mat: {
    rock: Object.assign({}, STONE, { chips: ['#b8b2c0', '#8e8898', '#5a5464', '#ff7a1a'], dust: '#e2dee6', sfx: { m: 'rock', p: 1 }, cav: ['#1a0602', '#3a1406'], glow: '#ffb050' }),
    slate: Object.assign({}, STONE, { chips: ['#9aa8c0', '#6a7890', '#465268', '#5ae8ff'], dust: '#e0e4ec', sfx: { m: 'rock', p: 1.05, x: ['zap'] }, cav: ['#04101e', '#0e2238'], glow: '#7af0ff' }),
    forge: Object.assign({}, Mt, { chips: ['#4a525e', '#7a8494', '#ff7a1a', '#3aa8ff', '#4ac05a'], dust: '#dcdce2', sfx: { m: 'iron', p: 1.1, x: ['zap'] }, cav: ['#100402', '#2a0e06'], glow: '#ffb050' }),
    magma: Object.assign({}, Mt, { crack: 'lava', chips: ['#241a24', '#5a4a5a', '#ff7a1a', '#fff0a0', '#3aa8ff'], dust: '#d8ccd0', sfx: { m: 'crystal', p: 0.9, x: ['zap', 'fire'] }, cav: ['#1a0402', '#4a0e04'], glow: '#ff9a3a', spark: '#ffb020' }),
    prism: Object.assign({}, Cd, { sfx: { m: 'crystal', p: 1, x: ['rainbow', 'zap', 'fire'] } }),
  },
  crack: { lava: [['#3a0a00', 2.8, 0, 0], ['#ff8a1a', 1.6, 0, 0, '#ff6a00']] },
  icons: { flame: icFlame, drop2: icDrop },
});
}
(function go() { if (window.ChestModels && window.ChestModels.K) run(); else setTimeout(go, 30); })();
})();
