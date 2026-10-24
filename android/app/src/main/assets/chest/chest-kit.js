// Shared kit for the later chest groups (forest, sky, dream, bakery, heroes, elemental, spooky): window.ChestModels.K
// rev() solids of revolution, puffLid() lit curved lids, panel() crystal panels, vault() Legendary template, treasury() Rainbow template, shared loot icons.
(function () {
'use strict';
function run() {
const CM = window.ChestModels, H = CM.H;
const { parse, poly, line, rect, ell, shift, star5, lg, rg, cg, sh, st, P3, mapD, mlg, onP, Box, cvx, boxFill, boxShade, surf, Barrel, KX, KY } = H;
const PI = Math.PI, TAU = PI * 2;
const mixH = (a, b, k) => { const A = parseInt(a.slice(1), 16), B = parseInt(b.slice(1), 16), c = s => Math.round(((A >> s) & 255) * (1 - k) + ((B >> s) & 255) * k); return '#' + ((1 << 24) | (c(16) << 16) | (c(8) << 8) | c(0)).toString(16).slice(1); };
const R2 = (cx, cy, s, a) => { const c = Math.cos(a || 0), n = Math.sin(a || 0); return (x, y) => [cx + (x * c - y * n) * s, cy + (x * n + y * c) * s]; };
const lp = (a, b, t) => [a[0] + (b[0] - a[0]) * t, a[1] + (b[1] - a[1]) * t];
const U = (d, f) => mapD(parse(d), f);
const clipAll = (shapes, c) => shapes.map(s => Object.assign({}, s, { clip: c }));
const gl = (x0, y0, x1, y1) => lg(x0, y0, x1, y1, '#fff6c0', '#ffd23a', '#e8a400', '#a86e00');
const sv = (x0, y0, x1, y1) => lg(x0, y0, x1, y1, '#ffffff', '#dfe6f0', '#a4b0c4', '#5f6b80');
const ir = (x0, y0, x1, y1) => lg(x0, y0, x1, y1, '#a8b0bc', '#6a717e', '#3a4048', '#22262c');
const gemS = (x, y, r, c, ink) => [sh(ell(x, y, r), rg(x - r * 0.35, y - r * 0.4, r * 1.4, '#ffffff', c, mixH(c, '#20002a', 0.45)), { s: ink || '#5a3a00', w: 1 }), sh(ell(x - r * 0.35, y - r * 0.4, r * 0.3, r * 0.2), 'rgba(255,255,255,0.9)')];
const heart = (x, y, s) => parse(`M${x} ${y + s * 0.8} C${x - s * 1.4} ${y - s * 0.1} ${x - s * 0.7} ${y - s} ${x} ${y - s * 0.35} C${x + s * 0.7} ${y - s} ${x + s * 1.4} ${y - s * 0.1} ${x} ${y + s * 0.8} Z`);
// "front-on" round solids: upright axis at screen x = X, ellipse ratio k (horizontal ellipses, look right for stand-alone round chests)
const EK = 0.36;
const pE = (X, r, a, y, k) => [X + r * Math.cos(a), y - (k || EK) * r * Math.sin(a)];
function revE(X, pr, nu, nv, col, o) { o = o || {}; const k = o.k || EK, kz = k / KY, fn = (u, v) => { const a = TAU * u, p = pr(v, a), r = p[0]; return [X + r * Math.cos(a) - KX * kz * r * Math.sin(a), p[1], kz * r * Math.sin(a)]; };
  return surf(fn, nu, nv, col, Object.assign({ c: [X, (pr(0, 0)[1] + pr(1, 0)[1]) / 2, 0] }, o)); }
const ringE = (X, r, y, k, n) => Array.from({ length: n || 40 }, (_, i) => pE(X, r, TAU * i / (n || 40), y, k));
const discE = (X, r, y, k, n) => poly(ringE(X, r, y, k, n));
const arcE = (X, r, y, k, a0, a1, n) => Array.from({ length: (n || 24) + 1 }, (_, i) => pE(X, r, a0 + (a1 - a0) * i / (n || 24), y, k));
const onCylE = (X, r, shapes, da, k) => onP(shapes, (x, y) => pE(X, r, -PI / 2 + (da || 0) + x / r, y, k));
// cylinder light overlay: lit left, shaded right, soft specular band, clipped to the silhouette
const silE = (X, r, y0, y1, k) => poly(arcE(X, r, y1, k || EK, 0, PI, 20).concat(arcE(X, r, y0, k || EK, PI, TAU, 20)));
function shadeE(X, r, y0, y1, k, o) { o = o || {}; k = k || EK; const sil2 = silE(X, r, y0, y1, k);
  return [sh(sil2, lg(X - r, 0, X + r, 0, [0, 'rgba(255,255,255,0.18)'], [0.28, 'rgba(255,255,255,0.32)'], [0.42, 'rgba(255,255,255,0)'], [0.7, 'rgba(30,0,20,0)'], [1, 'rgba(30,0,20,' + (o.dk || 0.38) + ')'])),
    sh(sil2, lg(0, y1, 0, y0 + k * r, [0, 'rgba(30,0,20,0)'], [0.75, 'rgba(30,0,20,0)'], [1, 'rgba(30,0,20,0.22)']))]; }
// lift a finished model so a round chest's front-bottom edge sits on the ground line
const liftM = (m, dy) => { const f = (x, y) => [x, y + dy]; m.parts.forEach(p => { p.sh = onP(p.sh, f); if (p.scar) p.scar = onP(p.scar, f); if (p.hang) p.hang = f(...p.hang); }); m.hull = mapD(m.hull, f); return m; };
const moonP = (x, y, r) => parse(`M${x} ${y - r} C${x - 1.36 * r} ${y - r} ${x - 1.36 * r} ${y + r} ${x} ${y + r} C${x - 0.72 * r} ${y + 0.62 * r} ${x - 0.72 * r} ${y - 0.62 * r} ${x} ${y - r} Z`);
const cloudB = (x, y, s) => [[x - 0.5 * s, y + 0.1 * s, 0.34 * s, 0.3 * s], [x - 0.08 * s, y - 0.16 * s, 0.42 * s, 0.4 * s], [x + 0.42 * s, y - 0.02 * s, 0.34 * s, 0.32 * s], [x + 0.05 * s, y + 0.2 * s, 0.5 * s, 0.24 * s]];
const cloudS = (x, y, s, fill, ink, w) => { const b = cloudB(x, y, s), out = []; if (ink) b.forEach(q => out.push(st(ell(...q), ink, w || 3))); b.forEach(q => out.push(sh(ell(...q), fill))); return out; };
const GOLD = { f: gl, t: '#ffe066', s: '#c88a00' }, SILV = { f: sv, t: '#f2f5fa', s: '#8a96aa' }, IRON = { f: ir, t: '#8a929e', s: '#3a4048' };
const GBOX = { f: ['#fff6c0', '#ffcf30', '#c88a00'], t: ['#fff6c0', '#ffe066'], s: ['#d89a10', '#8a5800'] };
const GEMC = ['#ff5c9a', '#ffb020', '#3ad08a', '#3aa8ff', '#a05cff'];
const RBW = (x, y, sp) => cg(x, y, 0, sp == null ? 1 : sp, '#ff5ca8', '#ffb020', '#3ad08a', '#3aa8ff', '#a05cff', '#ff5ca8');
const PAL = ['#ff6fae', '#ff9a3a', '#ffd23a', '#7ee05a', '#3ac8e8', '#8a7cff', '#c86cff'];
const pal = u => { const q = Math.max(0, Math.min(0.999, u)) * (PAL.length - 1), i = Math.floor(q); return mixH(PAL[i], PAL[i + 1], q - i); };
const ball = (x, y, r, ink, c) => [sh(ell(x, y, r), rg(x - r * 0.35, y - r * 0.35, r * 1.3, ...(c || ['#fff6c0', '#ffd23a', '#a86e00'])), { s: ink || '#6a4200', w: 1.4 }), sh(ell(x - r * 0.3, y - r * 0.35, r * 0.28, r * 0.19), '#ffffff')];
const sock = (x, y, r) => [sh(ell(x, y, r || 4.5), '#140a1e')];
// solid of revolution round an upright axis at (cx, cz); pr(v) -> [radius, y], v 0 = bottom .. 1 = top
function rev(cx, cz, pr, nu, nv, col, o) { const fn = (u, v) => { const a = TAU * u, p = pr(v); return [cx + p[0] * Math.cos(a), p[1], cz + p[0] * Math.sin(a)]; }; return surf(fn, nu, nv, col, Object.assign({ c: [cx, (pr(0)[1] + pr(1)[1]) / 2, cz] }, o || {})); }
const ringP = (cx, cz, r, y, n) => Array.from({ length: n || 36 }, (_, i) => { const a = TAU * i / (n || 36); return P3(cx + r * Math.cos(a), y, cz + r * Math.sin(a)); });
const disc = (cx, cz, r, y, n) => poly(ringP(cx, cz, r, y, n));
const FA = Math.atan2(-1, KX); // angle on an upright cylinder that faces the viewer most
const cylP = (cx, cz, r, x, y, da) => { const a = FA + (da || 0) + x / r; return P3(cx + r * Math.cos(a), y, cz + r * Math.sin(a)); };
const onCyl = (cx, cz, r, shapes, da) => onP(shapes, (x, y) => cylP(cx, cz, r, x, y, da));
// curved lid (heightfield) over the rect x0..x1 / z0..z1 at height y; h = dome height, k = roundness (0.3 = boxy cushion, 0.7 = dome)
function puffLid(x0, x1, y, z0, z1, h, k, col, o) { o = o || {}; const fn = (u, w) => { let hh = h * Math.pow(Math.sin(PI * u), k) * Math.pow(Math.sin(PI * w), k); if (o.hf) hh = o.hf(u, w, hh); return [x0 + (x1 - x0) * u, y - Math.max(0, hh), z0 + (z1 - z0) * w]; };
  return surf(fn, o.nu || 24, o.nv || 10, col, Object.assign({ c: [(x0 + x1) / 2, y + 40, (z0 + z1) / 2] }, o)); }
function lidRim(cu, ink, paint, wd) { const out = []; wd = wd || 6.5;
  [Array.from({ length: 41 }, (_, i) => [i / 40, 0.004]), Array.from({ length: 17 }, (_, i) => [0.996, i / 16])].forEach(uv => cu.lineOn(uv, -0.95).forEach(p => out.push(st(p, ink, wd), st(p, paint, wd - 2.3), st(shift(p, 0, -1.2), 'rgba(255,255,255,0.6)', 1))));
  return out; }
function panel(x, y, w, h, art, o) { o = o || {}; const r = rect(x, y, w, h, 8), c = [x + w / 2, y + h / 2];
  return [sh(r, lg(x, y, x + w, y + h, ...(o.bg || ['#f4ecff', '#e0f0ff']))), ...clipAll(art(c[0], c[1], Math.min(w, h)), r),
    sh(r, lg(x, y, x + w * 0.7, y + h, [0, 'rgba(255,255,255,0.6)'], [0.3, 'rgba(255,255,255,0.1)'], [0.31, 'rgba(255,255,255,0)'], [1, 'rgba(80,0,120,0.2)'])), st(line([[x + 5, y + h * 0.4], [x + w * 0.4, y + 5]]), 'rgba(255,255,255,0.8)', 2.6, { clip: r }),
    st(shift(r, 2.4, 2.4), 'rgba(110,50,0,0.5)', 4, { clip: r }), st(shift(r, -1.8, -1.8), 'rgba(255,255,255,0.75)', 2.4, { clip: r }), st(r, o.ink || '#8a5200', 2)]; }

/* ---------- Legendary template: enamel body with gold trims, ball corners, gem band, lid (box | barrel | dome), crest + medallion ---------- */
function vault(o) {
  const ink = o.ink, gi = o.gi || '#6a4200', tr = o.trim || gl, td = o.trimD || ['#e8a400', '#8a5800'], B = Box(-94, -88, 62, 0, 42), cx = -16;
  const body = boxFill(B, o.C); if (o.front) body.push(...o.front(B)); if (o.side) body.push(...onP(o.side(B), B.pS));
  if (o.band) { const [y, hh, c0, c1, c2] = o.band; body.push(...onP([sh(rect(-90, y, 150, hh, 3), lg(0, y, 0, y + hh, c0, c1, c2), { s: mixH(c2, '#000000', 0.4), w: 1.3 })], B.pF), ...onP([sh(rect(0, y, 42, hh), lg(0, y, 0, y + hh, c1, c2), { s: mixH(c2, '#000000', 0.4), w: 1.1 })], B.pS)); }
  body.push(sh(rect(-96, -9, 160, 9, 2), tr(0, -9, 0, 0), { s: gi, w: 1.3 }), sh(B.side(rect(0, -9, 42, 9)), mlg(B.side, 0, -9, 0, 0, ...td), { s: gi, w: 1.1 }), sh(rect(-96, -88, 6, 88, 2), tr(-96, 0, -90, 0), { s: gi, w: 1.1 }), sh(rect(56, -88, 6, 88, 2), tr(56, 0, 62, 0), { s: gi, w: 1.1 }), sh(B.side(rect(36, -88, 6, 88)), mlg(B.side, 36, 0, 42, 0, ...td), { s: gi, w: 1.1 }));
  if (o.frontOver) body.push(...o.frontOver(B));
  body.push(sh(ell(-72, -60, 14, 20), rg(-72, -60, 22, 'rgba(255,255,255,0.3)', 'rgba(255,255,255,0)')), ...boxShade(B, ink, { only: 'FS', k: 0.85 }));
  const stA = [], stB = [], sy = o.band ? o.band[0] + o.band[1] / 2 : -84, gc = o.gems || ['#ffd23a', '#3ad08a'];
  [-84, -66, -48, -30, 0, 18, 36, 52].forEach((x, i) => (i % 2 ? stB : stA).push(...gemS(x, sy, 3.2, gc[i % 2], gi)));
  [8, 22, 36].forEach((w, i) => { const p = B.pS(w, sy); (i % 2 ? stA : stB).push(...gemS(p[0], p[1], 3, gc[0], gi)); });
  const LC = o.LC || o.C, lid = [], X = { ink, gi }; let lpts, T;
  if (o.lid === 'barrel') {
    const xa = -97, xb = 65, yb = -88, dh = o.dh || 30, zc = 22.5, dz = -0.5, Bl = Barrel(xa, xb, yb, dh, zc, dz), cu = surf(Bl.f3, 24, 12, o.lidCol || (() => LC.f[1]), { c: [(xa + xb) / 2, yb + 10, dz + zc], dk: o.dk });
    lid.push(...cu.sh, sh(Bl.cap, mlg(m => m, 0, -120, 0, -88, ...(o.capC || [LC.s[0], LC.s[1]]))), st(Bl.cap, gi, 1.4));
    Object.assign(X, { cu, Bl, xa, xb }); lpts = Bl.pts; T = cu.P(0.5, 0.5);
    if (o.lidDeco) lid.push(...o.lidDeco(X));
    [0.03, 0.97].forEach(u => cu.lineOn(Array.from({ length: 25 }, (_, i) => [u, i / 24]), 0.04).forEach(p => lid.push(st(p, gi, 6), st(p, tr(0, -130, 0, -88), 3.8))));
    lid.push(st(line(Bl.prof(xb, PI)), gi, 7), st(line(Bl.prof(xb, PI)), tr(0, -130, 0, -88), 4.6), st(line([P3(xa, yb, dz), P3(xb, yb, dz)]), gi, 7), st(line([P3(xa, yb, dz), P3(xb, yb, dz)]), tr(0, yb - 3, 0, yb + 3), 4.6));
  } else if (o.lid === 'dome') {
    const cu = puffLid(-97, 65, -88, -1.5, 43.5, o.dh || 36, o.dk2 || 0.55, o.lidCol || (() => LC.f[1]), { dk: o.dk, nu: 26, nv: 12 });
    if (o.lidUnder) lid.push(...o.lidUnder()); lid.push(...(o.lidA ? cu.sh.map(s => Object.assign({}, s, { a: o.lidA })) : cu.sh)); Object.assign(X, { cu }); lpts = cu.pts; T = cu.P(0.5, 0.5);
    if (o.lidDeco) lid.push(...o.lidDeco(X));
    lid.push(...lidRim(cu, gi, tr(0, -96, 0, -84)));
  } else {
    const L = Box(-97, -112, 65, -88, 45); lid.push(...boxFill(L, LC));
    lid.push(sh(rect(-97, -94, 162, 6, 2), tr(0, -94, 0, -88), { s: gi, w: 1.2 }), sh(rect(-97, -112, 162, 5, 2), tr(0, -112, 0, -107), { s: gi, w: 1.2 }), sh(L.side(rect(0, -94, 45, 6)), mlg(L.side, 0, -94, 0, -88, ...td), { s: gi, w: 1 }));
    Object.assign(X, { L }); if (o.lidDeco) lid.push(...o.lidDeco(X));
    lid.push(...boxShade(L, ink, { k: 0.85 })); lpts = L.pts; T = L.pT(cx, 22.5);
    if (o.lidTop) lid.push(...o.lidTop(X));
  }
  const parts = (o.pre || []).concat([{ id: 'body', sh: body }, { id: 'stA', sh: stA, tear: 0.32 }, { id: 'stB', sh: stB, tear: 0.54 }, { id: 'lid', sh: lid, launch: true }]);
  if (o.crest) parts.push({ id: 'crest', sh: o.crest(T, X), tear: 0.76, launch: true });
  if (o.corners !== false) { const bl = o.corner || ((x, y) => ball(x, y, 8.5, gi)), uy = o.lid === 'box' ? -112 : -88;
    [[-95, -4, 0.46], [63, -4, 0.7], [-97, uy, 0.6], [65, uy, 0.88]].forEach(([x, y, t], i) => parts.push({ id: 'c' + i, sh: bl(x, y, i), tear: t, scar: (o.scar || sock)(x, y) })); }
  if (o.med) parts.push({ id: 'med', sh: o.med(cx), tear: 0.92, hang: o.medHang || [cx, -40], loose: 0.55, hmax: 0.6, hdir: 1 });
  if (o.extra) parts.push(...o.extra(X));
  return { name: o.name, mat: o.mat, hp: 12, W: 200, H: 168, ko: 'pie', pieN: 5, hull: cvx(B.pts.concat(lpts, [[T[0], T[1] - (o.crestH || 30)], [-104, 4], [72, 4]])), parts, loot: o.loot };
}

/* ---------- Rainbow template: gold frame, 3 + 1 crystal panels, gold seam with gem studs, curved lid, crest + lock ---------- */
function treasury(o) {
  const ink = o.ink || '#6a3c00', B = Box(-100, -88, 72, 0, 46), SB = Box(-103, -98, 75, -88, 49, -1.5), S = d => B.side(d), po = { bg: o.bg, ink: '#8a5200' };
  const foot = o.foot || ((x, y) => ball(x, y, 8.5, ink));
  const [bpx, bpy] = P3(72, 0, 46), plS = S(rect(0, -10, 46, 10)), art = o.art;
  const body = [...foot(bpx, bpy + 2, 2), ...boxFill(B, o.frame || { f: ['#fff2a8', '#ffcf30', '#d99a10'], t: ['#fff6c0', '#ffd84a'], s: ['#e0a414', '#8a5800'] }), ...onP(panel(8, -80, 30, 66, art[3] || art[0], po), B.pS), sh(plS, mlg(S, 0, -10, 0, 0, '#e8a400', '#8a5800')), st(plS, ink, 1.2),
    ...panel(-92, -82, 46, 68, art[0], po), ...panel(-38, -82, 50, 68, art[1], po), ...panel(20, -82, 44, 68, art[2], po),
    sh(rect(-46, -86, 8, 76, 3), gl(-46, 0, -38, 0), { s: ink, w: 1.4 }), sh(rect(12, -86, 8, 76, 3), gl(12, 0, 20, 0), { s: ink, w: 1.4 }),
    sh(rect(-100, -11, 172, 11), gl(0, -11, 0, 0), { s: ink, w: 1.4 }), st(line([[-98, -9], [70, -9]]), 'rgba(255,255,255,0.7)', 1.2), ...boxShade(B, ink, { k: 0.7 }), ...foot(-100, 2, 0), ...foot(72, 2, 1)];
  if (o.bodyX) body.push(...o.bodyX(B));
  const seam = [...boxFill(SB, GBOX), ...boxShade(SB, ink, { k: 0.6 })];
  [10, 24, 38].forEach((w, i) => { const [x, y] = SB.Q(75.6, -93, w); seam.push(...gemS(x, y, 3.4, GEMC[(i + 2) % 5], ink)); });
  const studs = k => { const out = []; let i = 0; for (let x = -92; x <= 66; x += 17.5, i++) if (i % 2 === k && Math.abs(x + 14) > 12) { const [X, Y] = SB.Q(x, -93, 0); out.push(...gemS(X, Y, 4, GEMC[i % 5], ink)); } return out; };
  const L = o.lid(ink), top = L.top, crest = o.crest(top, ink);
  const parts = [{ id: 'body', sh: body }, { id: 'seam', sh: seam }, { id: 'studA', sh: studs(0), tear: 0.32 }, { id: 'studB', sh: studs(1), tear: 0.54 },
    { id: 'lock', sh: o.lock(-14, ink), tear: 0.9, hang: [-14, -96], loose: 0.6, hmax: 0.5, hdir: 1 }, { id: 'lid', sh: L.sh, launch: true }].concat(L.parts || [], [{ id: 'crest', sh: crest, tear: 0.74, launch: true }]);
  return { name: o.name, mat: o.mat, hp: 14, W: 236, H: 218, ko: 'pie', pieN: 8, ring: true,
    hull: cvx(B.pts.concat(SB.pts, L.pts, [[top[0], top[1] - (o.crestH || 38)], [-112, 8], [bpx + 12, bpy + 8]])), parts, loot: o.loot };
}
// standard rainbow dome lid over the seam (col(u, w) -> hex); returns { sh, pts, top, cu }
function rbLid(ink, col, o) { o = o || {}; const cu = puffLid(o.x0 || -106, o.x1 || 78, -98, o.z0 == null ? -4 : o.z0, o.z1 || 51, o.h || 40, o.k || 0.5, col, Object.assign({ dk: '#3a0a50', cv: -0.1, nu: 28, nv: 12 }, o));
  const s = cu.sh.slice(); if (o.deco) s.push(...o.deco(cu)); const hp = cu.P(0.3, 0.5); s.push(sh(ell(hp[0], hp[1], 30, 8), rg(hp[0], hp[1], 30, 'rgba(255,255,255,0.5)', 'rgba(255,255,255,0)')));
  if (o.rim !== false) s.push(...lidRim(cu, ink, gl(0, -110, 0, -94))); return { sh: s, pts: cu.pts, top: cu.P(0.5, o.tw || 0.55), cu }; }

/* ---------- shared loot icons ---------- */
const IC = {
  moon(c, s) { c.beginPath(); c.arc(0, 0, s * 0.4, 0.5, TAU - 0.5 + 0.0001); c.arc(s * 0.16, -s * 0.06, s * 0.3, TAU - 0.9, 0.9, true); c.closePath(); const g = c.createRadialGradient(-s * 0.1, -s * 0.1, 0, 0, 0, s * 0.45); g.addColorStop(0, '#fff6c0'); g.addColorStop(1, '#ffc020'); c.fillStyle = g; c.fill(); c.strokeStyle = '#a86e00'; c.lineWidth = s * 0.05; c.stroke(); },
  cloud(c, s) { const P = () => { c.beginPath(); [[-0.22, 0.06, 0.2], [0.02, -0.08, 0.26], [0.24, 0.06, 0.19], [0, 0.12, 0.2]].forEach(([x, y, r]) => { c.moveTo(x * s + r * s, y * s); c.arc(x * s, y * s, r * s, 0, TAU); }); }; c.strokeStyle = '#7a8ac8'; c.lineWidth = s * 0.08; P(); c.stroke(); const g = c.createLinearGradient(0, -s * 0.3, 0, s * 0.3); g.addColorStop(0, '#ffffff'); g.addColorStop(1, '#cfdcff'); c.fillStyle = g; P(); c.fill(); },
  leaf(c, s) { c.save(); c.rotate(-0.6); c.beginPath(); c.moveTo(0, s * 0.45); c.quadraticCurveTo(s * 0.42, 0, 0, -s * 0.45); c.quadraticCurveTo(-s * 0.42, 0, 0, s * 0.45); const g = c.createLinearGradient(-s * 0.3, 0, s * 0.3, 0); g.addColorStop(0, '#9ae05a'); g.addColorStop(1, '#3a9a3a'); c.fillStyle = g; c.fill(); c.strokeStyle = '#1e5a1a'; c.lineWidth = s * 0.05; c.stroke(); c.beginPath(); c.moveTo(0, s * 0.45); c.lineTo(0, -s * 0.3); c.strokeStyle = 'rgba(255,255,255,0.6)'; c.stroke(); c.restore(); },
  candy(c, s) { c.save(); c.rotate(-0.4); c.fillStyle = '#ff7ab8'; c.strokeStyle = '#8a1a5a'; c.lineWidth = s * 0.05; [[-1], [1]].forEach(([d]) => { c.beginPath(); c.moveTo(d * s * 0.2, 0); c.lineTo(d * s * 0.46, -s * 0.18); c.lineTo(d * s * 0.46, s * 0.18); c.closePath(); c.fill(); c.stroke(); }); const g = c.createRadialGradient(-s * 0.06, -s * 0.06, 0, 0, 0, s * 0.24); g.addColorStop(0, '#ffffff'); g.addColorStop(1, '#ffb020'); c.fillStyle = g; c.beginPath(); c.arc(0, 0, s * 0.22, 0, TAU); c.fill(); c.stroke(); c.restore(); },
};
Object.assign(CM.ICONS, IC);

CM.K = { liftM, silE, EK, pE, revE, ringE, discE, arcE, onCylE, shadeE, moonP, cloudB, cloudS, PI, TAU, mixH, R2, lp, U, clipAll, gl, sv, ir, gemS, heart, GOLD, SILV, IRON, GBOX, GEMC, RBW, PAL, pal, ball, sock, rev, ringP, disc, FA, cylP, onCyl, puffLid, lidRim, panel, vault, treasury, rbLid };
}
(function go() { if (window.ChestModels && window.ChestModels.H) run(); else setTimeout(go, 30); })();
})();
