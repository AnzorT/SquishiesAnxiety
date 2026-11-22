// Chest remodel engine: per-group / per-rarity chest models drawn on canvas, with real damage
// (dents warp the outline, cracks, holes punched out as flying chunks, parts that loosen,
// swing and tear off) and a final break into physics shards + dust, rubble and loot.
// window.ChestModels = { TIER, model, Stage, Lineup }
(function () {
'use strict';
const TAU = Math.PI * 2, rnd = (a, b) => a + Math.random() * (b - a), pick = a => a[Math.floor(Math.random() * a.length)], clamp = (v, a, b) => v < a ? a : v > b ? b : v;
const RB = ['#ff8fd8', '#ffe38a', '#9ff7c8', '#9fd8ff', '#d6b3ff'];
const TIER = [
  { k:'common', n:'Common', c:'#8d7b6a', fx:'#ffe2b8' },
  { k:'rare', n:'Rare', c:'#2f8cff', fx:'#8fd0ff' },
  { k:'epic', n:'Epic', c:'#a24bf0', fx:'#d9a6ff' },
  { k:'legendary', n:'Legendary', c:'#f08c00', fx:'#ffd84a' },
  { k:'rainbow', n:'Rainbow', c:'#e0459f', fx:'#ff9fd6', rb:true },
];
const rgba = (h, a) => { const n = parseInt(h.slice(1), 16); return 'rgba(' + (n >> 16) + ',' + ((n >> 8) & 255) + ',' + (n & 255) + ',' + a.toFixed(3) + ')'; };

/* ---------------- paths ---------------- */
function parse(s) { const t = s.match(/[MLQCZ]|-?\d*\.?\d+(?:e[-+]?\d+)?/g), out = [], N = { M:2, L:2, Q:4, C:6, Z:0 }; let i = 0;
  while (i < t.length) { const c = t[i++], a = [c]; for (let k = 0; k < N[c]; k++) a.push(+t[i++]); out.push(a); } return out; }
const P_ = d => typeof d === 'string' ? parse(d) : d;
function poly(pts, open) { const o = pts.map((p, i) => [i ? 'L' : 'M', p[0], p[1]]); if (!open) o.push(['Z']); return o; }
const line = pts => poly(pts, true);
function rect(x, y, w, h, r) { r = Math.min(r || 0, w / 2, h / 2); if (!r) return poly([[x, y], [x + w, y], [x + w, y + h], [x, y + h]]);
  return [['M', x + r, y], ['L', x + w - r, y], ['Q', x + w, y, x + w, y + r], ['L', x + w, y + h - r], ['Q', x + w, y + h, x + w - r, y + h], ['L', x + r, y + h], ['Q', x, y + h, x, y + h - r], ['L', x, y + r], ['Q', x, y, x + r, y], ['Z']]; }
function ell(cx, cy, rx, ry) { ry = ry == null ? rx : ry; const k = 0.5523;
  return [['M', cx + rx, cy], ['C', cx + rx, cy + ry * k, cx + rx * k, cy + ry, cx, cy + ry], ['C', cx - rx * k, cy + ry, cx - rx, cy + ry * k, cx - rx, cy], ['C', cx - rx, cy - ry * k, cx - rx * k, cy - ry, cx, cy - ry], ['C', cx + rx * k, cy - ry, cx + rx, cy - ry * k, cx + rx, cy], ['Z']]; }
const shift = (d, dx, dy) => P_(d).map(c => c.map((v, i) => i === 0 ? v : (i % 2 ? v + dx : v + dy)));
const rot = (pts, cx, cy, a) => pts.map(([x, y]) => { const c = Math.cos(a), s = Math.sin(a), dx = x - cx, dy = y - cy; return [cx + dx * c - dy * s, cy + dx * s + dy * c]; });
const mxp = (pts, c) => pts.map(p => [2 * c - p[0], p[1]]), myp = (pts, c) => pts.map(p => [p[0], 2 * c - p[1]]);
const spark4 = (cx, cy, r) => poly([[cx, cy - r], [cx + r * 0.28, cy - r * 0.28], [cx + r, cy], [cx + r * 0.28, cy + r * 0.28], [cx, cy + r], [cx - r * 0.28, cy + r * 0.28], [cx - r, cy], [cx - r * 0.28, cy - r * 0.28]]);
const star5 = (cx, cy, R, r) => poly(Array.from({ length: 10 }, (_, i) => { const a = -Math.PI / 2 + i * Math.PI / 5, k = i % 2 ? r : R; return [cx + Math.cos(a) * k, cy + Math.sin(a) * k]; }));
function flat(cmds) {
  const subs = []; let cur = null, x = 0, y = 0, sx = 0, sy = 0;
  const seg = (x0, y0, x1, y1, skipEnd) => { const n = Math.max(1, Math.ceil(Math.hypot(x1 - x0, y1 - y0) / 9)); for (let i = 1; i <= n; i++) { if (skipEnd && i === n) break; cur.p.push(x0 + (x1 - x0) * i / n, y0 + (y1 - y0) * i / n); } };
  for (const c of P_(cmds)) {
    const k = c[0];
    if (k === 'M') { cur = { p: [c[1], c[2]], c: false }; subs.push(cur); x = sx = c[1]; y = sy = c[2]; }
    else if (k === 'L') { seg(x, y, c[1], c[2]); x = c[1]; y = c[2]; }
    else if (k === 'Q') { const n = Math.max(2, Math.ceil((Math.hypot(c[1] - x, c[2] - y) + Math.hypot(c[3] - c[1], c[4] - c[2])) / 6));
      for (let i = 1; i <= n; i++) { const t = i / n, u = 1 - t; cur.p.push(u * u * x + 2 * u * t * c[1] + t * t * c[3], u * u * y + 2 * u * t * c[2] + t * t * c[4]); } x = c[3]; y = c[4]; }
    else if (k === 'C') { const n = Math.max(3, Math.ceil((Math.hypot(c[1] - x, c[2] - y) + Math.hypot(c[3] - c[1], c[4] - c[2]) + Math.hypot(c[5] - c[3], c[6] - c[4])) / 6));
      for (let i = 1; i <= n; i++) { const t = i / n, u = 1 - t, a = u * u * u, b = 3 * u * u * t, d = 3 * u * t * t, e = t * t * t; cur.p.push(a * x + b * c[1] + d * c[3] + e * c[5], a * y + b * c[2] + d * c[4] + e * c[6]); } x = c[5]; y = c[6]; }
    else if (k === 'Z') { cur.c = true; seg(x, y, sx, sy, true); x = sx; y = sy; }
  }
  return subs;
}
const _o = [0, 0];
function trace(ctx, sp, W) { ctx.beginPath(); for (const s of sp) { const p = s.p; for (let i = 0; i < p.length; i += 2) { let x = p[i], y = p[i + 1]; if (W) { W(x, y, _o); x = _o[0]; y = _o[1]; } if (i) ctx.lineTo(x, y); else ctx.moveTo(x, y); } if (s.c) ctx.closePath(); } }
function tracePts(ctx, pts, W) { ctx.beginPath(); pts.forEach(([x, y], i) => { if (W) { W(x, y, _o); x = _o[0]; y = _o[1]; } if (i) ctx.lineTo(x, y); else ctx.moveTo(x, y); }); ctx.closePath(); }
function bbox(sp) { let x0 = 1e9, y0 = 1e9, x1 = -1e9, y1 = -1e9; sp.forEach(s => { for (let i = 0; i < s.p.length; i += 2) { x0 = Math.min(x0, s.p[i]); x1 = Math.max(x1, s.p[i]); y0 = Math.min(y0, s.p[i + 1]); y1 = Math.max(y1, s.p[i + 1]); } }); return { x0, y0, x1, y1 }; }

/* ---------------- paint ---------------- */
const lg = (x0, y0, x1, y1, ...c) => ({ l: [x0, y0, x1, y1], c });
const rg = (cx, cy, r, ...c) => ({ r: [cx, cy, r], c });
const cg = (cx, cy, a, spin, ...c) => ({ k: [cx, cy, a], spin, c });
const sh = (d, f, o) => Object.assign({ d, f }, o || {});
const st = (d, s, w, o) => Object.assign({ d, s, w }, o || {});
const tx = (txt, x, y, font, f, o) => Object.assign({ txt, x, y, font, f }, o || {});
function paint(ctx, f, T) {
  if (!f || typeof f === 'string') return f; let g;
  if (f.l) g = ctx.createLinearGradient(f.l[0], f.l[1], f.l[2], f.l[3]);
  else if (f.r) g = ctx.createRadialGradient(f.r[0], f.r[1], 0, f.r[0], f.r[1], f.r[2]);
  else if (f.k) { if (!ctx.createConicGradient) { const c0 = f.c[0]; return Array.isArray(c0) ? c0[1] : c0; } g = ctx.createConicGradient(f.k[2] + (f.spin || 0) * (T || 0), f.k[0], f.k[1]); }
  const n = f.c.length; f.c.forEach((s, i) => { if (Array.isArray(s)) g.addColorStop(s[0], s[1]); else g.addColorStop(n > 1 ? i / (n - 1) : 0, s); });
  return g;
}
function drawShape(ctx, s, W, T) {
  if (s.txt) { W(s.x, s.y, _o); ctx.save(); ctx.translate(_o[0], _o[1]); if (s.rot) ctx.rotate(s.rot); if (s.a != null) ctx.globalAlpha *= s.a; ctx.font = s.font; ctx.textAlign = 'center'; ctx.textBaseline = 'middle'; ctx.fillStyle = s.f; ctx.fillText(s.txt, 0, 0); ctx.restore(); return; }
  ctx.save();
  if (s.a != null) ctx.globalAlpha *= s.a;
  if (s.op) ctx.globalCompositeOperation = s.op;
  if (s.clipSp) { trace(ctx, s.clipSp, W); ctx.clip(); }
  trace(ctx, s.sp, W);
  if (s.f) { ctx.fillStyle = paint(ctx, s.f, T); ctx.fill(); }
  if (s.s) { ctx.lineWidth = s.w || 2; ctx.strokeStyle = paint(ctx, s.s, T); ctx.lineJoin = 'round'; ctx.lineCap = 'round'; if (s.g) { ctx.shadowColor = s.g; ctx.shadowBlur = s.gb || 8; } ctx.stroke(); }
  ctx.restore();
}
function drawPart(ctx, p, W, T, ang) {
  if (ang && p.hang) { W(p.hang[0], p.hang[1], _o); const px = _o[0], py = _o[1]; ctx.save(); ctx.translate(px, py); ctx.rotate(ang); ctx.translate(-px, -py); }
  for (const s of p.sh) drawShape(ctx, s, W, T);
  if (ang && p.hang) ctx.restore();
}

/* ---------------- materials ---------------- */
const MAT = {
  paper: { soft: 2.6, lean: 9, sag: 7, dentK: 6, dentShade: 0.24, holeFrom: 0.16, holeP: 0.85, holeR: [15, 23], jag: 'tear', edge: '#fff6e2', edgeW: 6, crack: 'rip', chips: ['#e8c48e', '#d4a66a', '#f5dcb2'], deb: 'shred', dust: '#f2e2c6', mass: 0.75, sfx: { m:'paper', p:1 }, rest: 0.12, flutter: 1, cav: ['#2a1406', '#4a2410'], glow: '#ffcf6a' },
  card: { soft: 1.2, lean: 6, sag: 5, dentK: 6, dentShade: 0.3, holeFrom: 0.24, holeP: 0.65, holeR: [15, 22], jag: 'ragged', edge: '#f8deb0', edgeW: 7, crack: 'crease', chips: ['#dba566', '#c08548', '#f0cf98', '#e5432f'], deb: 'shred', dust: '#ead6b4', mass: 1, sfx: { m:'card', p:1 }, rest: 0.18, flutter: 0.5, cav: ['#241004', '#40200a'], glow: '#ffcf6a' },
  wood: { soft: 0.3, lean: 4, sag: 3, dentK: 4, dentShade: 0.26, holeFrom: 0.28, holeP: 0.55, holeR: [16, 23], jag: 'splinter', edge: '#f8dcae', edgeW: 6, crack: 'split', chips: ['#e2a868', '#c8864a', '#9c5f2c', '#f2cf5a'], deb: 'splinter', dust: '#ebd6b6', mass: 1.4, sfx: { m:'wood', p:1 }, rest: 0.28, cav: ['#1e0c02', '#3a1a06'], glow: '#ffd27a' },
  metal: { soft: 0, lean: 3, sag: 2, dentK: 7, dentShade: 0.45, holeFrom: 0.5, holeP: 0.5, holeR: [14, 19], jag: 'petal', edge: '#f2f6ff', edgeW: 6, crack: 'scratch', chips: ['#e8402e', '#c9d3e0', '#8e9bb0', '#ffd23a'], deb: 'bolt', dust: '#ddd6dc', mass: 2, sfx: { m:'steel', p:1.05, x:['iron'] }, rest: 0.32, spark: '#fff2a8', cav: ['#140608', '#2e1010'], glow: '#ffd84a' },
  candy: { soft: 0, lean: 2, sag: 1, dentK: 2.5, dentShade: 0.16, holeFrom: 0.26, holeP: 0.6, holeR: [16, 23], jag: 'shard', edge: '#ffffff', edgeW: 6, crack: 'glow', chips: RB.concat(['#ffd23a']), deb: 'gem', dust: '#fff0fa', mass: 1.8, sfx: { m:'candy', p:1, x:['rainbow', 'fizz'] }, rest: 0.3, spark: 'rb', cav: ['#1a0828', '#3a1450'], glow: '#ff9fd6' },
};
const CRACK = {
  rip: [['rgba(80,40,10,0.75)', 2.2, 0, 0], ['rgba(255,246,226,0.85)', 1.2, 1.2, 1.3]],
  crease: [['rgba(90,50,15,0.55)', 2, 0, 0], ['rgba(255,236,200,0.75)', 1.4, 1.3, 1.3]],
  split: [['#3a1a06', 2.6, 0, 0], ['rgba(255,226,180,0.6)', 1.2, 1.3, 1.5]],
  scratch: [['rgba(60,10,5,0.45)', 1.6, 0.9, 0.9], ['rgba(255,255,255,0.85)', 1.2, 0, 0]],
  glow: [['rgba(255,255,255,0.95)', 2.2, 0, 0, '#ffffff']],
};

/* ---------------- shared decoration ---------------- */
function friesIcon(cx, cy, s, o) {
  o = o || {}; const out = [], S = (x, y) => [cx + x * s, cy + y * s], tops = [8, 0, 4, -3, 6], mono = o.mono, A = o.a != null ? { a: o.a } : {};
  for (let i = 0; i < 5; i++) { const x = -12 + i * 6, t = -50 + tops[i], tl = (i - 2) * 1.6;
    out.push(sh(poly([S(x - 2.6 + tl, t), S(x + 2.6 + tl, t), S(x + 2.6, -26), S(x - 2.6, -26)]), mono || lg(cx + (x - 2.6) * s, 0, cx + (x + 2.6) * s, 0, '#fff0a0', '#ffd23a', '#e8a800'), Object.assign(mono ? {} : { s: '#c98a00', w: 1.1 * s }, A))); }
  const box = poly([S(-17, -32), S(17, -32), S(13, 0), S(-13, 0)]);
  out.push(sh(box, mono || o.box || lg(cx - 17 * s, 0, cx + 17 * s, 0, '#ff7a62', '#e5432f', '#b8281a'), Object.assign(mono ? {} : { s: o.box ? '#8a2216' : '#7a1810', w: 1.3 * s }, A)));
  if (!mono && !o.box) {
    out.push(sh(poly([S(-16.2, -26), S(16.2, -26), S(15.4, -21), S(-15.4, -21)]), '#fff3e0'));
    out.push(sh(ell(cx - 5 * s, cy - 12 * s, 1.7 * s, 2.2 * s), '#4a1208'), sh(ell(cx + 5 * s, cy - 12 * s, 1.7 * s, 2.2 * s), '#4a1208'));
    out.push(st(parse('M' + (cx - 4 * s) + ' ' + (cy - 7 * s) + ' Q' + cx + ' ' + (cy - 4 * s) + ' ' + (cx + 4 * s) + ' ' + (cy - 7 * s)), '#4a1208', 1.3 * s));
  }
  if (o.box) out.push(sh(poly([S(-16.2, -26), S(16.2, -26), S(15.4, -21), S(-15.4, -21)]), '#e5432f'));
  return out;
}
const nail = (x, y, r) => sh(ell(x, y, r || 2.3), rg(x - 0.8, y - 0.8, (r || 2.3) + 0.6, '#eef1f6', '#7a808c', '#3a3e48'));
const chrome = (x0, y0, x1, y1) => lg(x0, y0, x1, y1, '#ffffff', '#d6dee9', '#9aa7ba', '#5f6b80');
const gold = (x0, y0, x1, y1) => lg(x0, y0, x1, y1, '#fff6c0', '#ffd23a', '#e8a400', '#a86e00');

/* ---------------- 3D helpers (oblique 3/4 view: +x right, -y up, +z away) ---------------- */
const KX = 0.74, KY = 0.6;
const P3 = (x, y, z) => [x + z * KX, y - z * KY];
const mapD = (d, fn) => P_(d).map(c => { const o = [c[0]]; for (let i = 1; i < c.length; i += 2) { const p = fn(c[i], c[i + 1]); o.push(p[0], p[1]); } return o; });
const mp = (m, x, y) => { const c = m([['M', x, y]])[0]; return [c[1], c[2]]; };
const mlg = (m, a, b, c, d, ...cols) => { const p = mp(m, a, b), q = mp(m, c, d); return lg(p[0], p[1], q[0], q[1], ...cols); };
const onF = (shapes, m) => shapes.map(s => s.d ? Object.assign({}, s, { d: m(s.d) }, s.clip ? { clip: m(s.clip) } : {}) : s);
const FR = d => P_(d);
const mixC = (h, h2, k) => { const a = parseInt(h.slice(1), 16), b = parseInt(h2.slice(1), 16), c = s => Math.round(((a >> s) & 255) * (1 - k) + ((b >> s) & 255) * k); return 'rgb(' + c(16) + ',' + c(8) + ',' + c(0) + ')'; };
function Box(x0, y0, x1, y1, D, z0) {
  z0 = z0 || 0; const Q = (x, y, z) => P3(x, y, z0 + z), b = { x0, y0, x1, y1, D, z0, dx: D * KX, dy: -D * KY, Q };
  b.front = d => mapD(d, (x, y) => Q(x, y, 0));
  b.top = (d, o) => mapD(d, (u, w) => Q(u, y0 - (o || 0), w));
  b.side = (d, o) => mapD(d, (w, v) => Q(x1 + (o || 0), v, w));
  b.F = poly([Q(x0, y0, 0), Q(x1, y0, 0), Q(x1, y1, 0), Q(x0, y1, 0)]);
  b.T = poly([Q(x0, y0, 0), Q(x1, y0, 0), Q(x1, y0, D), Q(x0, y0, D)]);
  b.S = poly([Q(x1, y0, 0), Q(x1, y0, D), Q(x1, y1, D), Q(x1, y1, 0)]);
  b.pts = [Q(x0, y1, 0), Q(x0, y0, 0), Q(x0, y0, D), Q(x1, y0, D), Q(x1, y1, D), Q(x1, y1, 0)];
  b.pF = (x, y) => Q(x, y, 0); b.pT = (u, w) => Q(u, y0, w); b.pS = (w, v) => Q(x1, v, w);
  return b;
}
function cvx(pts) {
  const p = pts.slice().sort((a, b) => a[0] - b[0] || a[1] - b[1]), cr = (o, a, b) => (a[0] - o[0]) * (b[1] - o[1]) - (a[1] - o[1]) * (b[0] - o[0]), lo = [], up = [];
  for (const q of p) { while (lo.length >= 2 && cr(lo[lo.length - 2], lo[lo.length - 1], q) <= 0) lo.pop(); lo.push(q); }
  for (let i = p.length - 1; i >= 0; i--) { const q = p[i]; while (up.length >= 2 && cr(up[up.length - 2], up[up.length - 1], q) <= 0) up.pop(); up.push(q); }
  return poly(lo.slice(0, -1).concat(up.slice(0, -1)));
}
function boxFill(b, c) {
  const [x0, y0] = b.Q(b.x0, b.y0, 0), [x1, y1] = b.Q(b.x1, b.y1, 0), { dx, dy } = b;
  return [sh(b.S, lg(x1, y0, x1 + dx, y1, c.s[0], c.s[1])), sh(b.T, lg(x0, y0, x1 + dx, y0 + dy, c.t[0], c.t[1])), sh(b.F, lg(x0, y0, x1, y1, ...c.f))];
}
function boxShade(b, ink, o) {
  o = o || {}; const only = o.only || 'FTS', k = o.k == null ? 1 : o.k, W = (c, a) => 'rgba(' + c + ',' + (a * k).toFixed(3) + ')', L = '255,255,255', Dk = '40,10,0';
  const [x0, y0] = b.Q(b.x0, b.y0, 0), [x1, y1] = b.Q(b.x1, b.y1, 0), { dx, dy, D } = b, out = [];
  if (only.includes('F')) out.push(sh(b.F, lg(x0, 0, x1, 0, [0, W(L, 0.2)], [0.18, W(L, 0)], [0.78, W(Dk, 0)], [1, W(Dk, 0.22)])), sh(b.F, lg(0, y0, 0, y1, [0, W(L, 0.16)], [0.3, W(L, 0)], [0.7, W(Dk, 0)], [1, W(Dk, 0.28)])));
  if (only.includes('T')) out.push(sh(b.T, lg(x0, y0, x1 + dx, y0 + dy, [0, W(L, 0.32)], [1, W(L, 0)])));
  if (only.includes('S')) out.push(sh(b.S, lg(x1, 0, x1 + dx, 0, [0, W(L, 0.06)], [1, W(Dk, 0.3)])), sh(b.S, lg(0, y0 + dy, 0, y1, [0, W(Dk, 0)], [1, W(Dk, 0.24)])));
  if (!o.noBevel) {
    if (only.includes('F')) out.push(st(b.front(line([[b.x0 + 4, b.y0 + 1.8], [b.x1 - 3, b.y0 + 1.8]])), W(L, 0.6), 2), st(b.front(line([[b.x1 - 1.8, b.y0 + 4], [b.x1 - 1.8, b.y1 - 4]])), W(L, 0.26), 2.2));
    if (only.includes('S')) out.push(st(b.side(line([[3, b.y0 + 1.8], [D - 3, b.y0 + 1.8]])), W(L, 0.4), 1.6));
    if (only.includes('T')) out.push(st(b.top(line([[b.x0 + 3, D - 1.6], [b.x1 - 3, D - 1.6]])), W(L, 0.25), 1.4));
  }
  if (!o.noInk) { if (only.includes('S')) out.push(st(b.S, ink, 2.4)); if (only.includes('T')) out.push(st(b.T, ink, 2.4)); if (only.includes('F')) out.push(st(b.F, ink, 2.4)); }
  return out;
}
function corner3(b, cx, cy, L, T, o, C, ink) {
  const X = cx < 0 ? b.x0 - o : b.x1 + o, Y = cy < 0 ? b.y0 - o : b.y1 + o, out = [];
  if (cx > 0) { const s = b.side(poly([[0, Y], [0, Y - cy * L], [T, Y - cy * L], [T, Y - cy * T], [L, Y - cy * T], [L, Y]]), o); out.push(sh(s, C.s), st(s, ink, 1.5)); }
  if (cy < 0) { const t = b.top(poly([[X, 0], [X - cx * L, 0], [X - cx * L, T], [X - cx * T, T], [X - cx * T, L], [X, L]]), o); out.push(sh(t, C.t), st(t, ink, 1.5)); }
  const f = poly([[X, Y], [X - cx * L, Y], [X - cx * L, Y - cy * T], [X - cx * T, Y - cy * T], [X - cx * T, Y - cy * L], [X, Y - cy * L]]);
  out.push(sh(f, C.f(X, Y, X - cx * L, Y - cy * L)), st(line([[X - cx * (L - 1), Y - cy * 1.3], [X - cx * 1.3, Y - cy * 1.3], [X - cx * 1.3, Y - cy * (L - 1)]]), 'rgba(255,255,255,0.5)', 1.2), st(f, ink, 1.5));
  return { sh: out, hang: [X - cx * (L - T / 2), Y - cy * T / 2], c: [X - cx * T / 2, Y - cy * T / 2], X, Y };
}
function plankS(u0, v0, du, dv, m, c, knot, seed, extra) {
  m = m || FR; const r = m(rect(u0, v0, du, dv, m === FR ? 2 : 0)), o = [sh(r, mlg(m, u0, v0, u0 + du, v0 + dv, ...c))];
  [0.3, 0.68].forEach((f, j) => { const pts = []; for (let x = u0 + 2; x <= u0 + du - 2; x += 5) pts.push([x, v0 + dv * f + Math.sin(x * 0.09 + j * 2 + seed) * Math.min(1.6, dv * 0.06)]); o.push(st(m(line(pts)), 'rgba(120,64,24,0.35)', 1.3)); });
  if (knot) o.push(sh(m(ell(knot[0], knot[1], 4.2, 2.6)), 'rgba(120,64,24,0.4)', { s: 'rgba(90,45,15,0.55)', w: 1 }));
  if (extra) o.push(...extra);
  o.push(st(m(line([[u0 + 2, v0 + 1.6], [u0 + du - 2, v0 + 1.6]])), 'rgba(255,240,210,0.65)', 1.4), sh(r, mlg(m, u0, v0, u0, v0 + dv, [0, 'rgba(70,30,5,0)'], [0.72, 'rgba(70,30,5,0)'], [1, 'rgba(70,30,5,0.26)'])), st(r, '#5a2e10', 1.6));
  return o;
}

/* ---------------- curved surfaces (lit, back-face culled, depth sorted) ---------------- */
const nrm3 = a => { const l = Math.hypot(a[0], a[1], a[2]); return a.map(v => v / l); };
const VV = nrm3([KX, -KY, -1]), LV = nrm3([-0.45, -0.8, -0.4]);
const litC = (h, li, dk) => li > 0.45 ? mixC(h, '#ffffff', Math.min(0.42, (li - 0.45) * 0.8)) : mixC(h, dk || '#2a0e3a', Math.min(0.62, (0.45 - li) * 0.55));
function mapPaint(f, pm) { if (!f || typeof f === 'string') return f; const o = Object.assign({}, f); if (f.l) { const a = pm(f.l[0], f.l[1]), b = pm(f.l[2], f.l[3]); o.l = [a[0], a[1], b[0], b[1]]; } if (f.r) { const a = pm(f.r[0], f.r[1]); o.r = [a[0], a[1], f.r[2]]; } if (f.k) { const a = pm(f.k[0], f.k[1]); o.k = [a[0], a[1], f.k[2]]; } return o; }
function onP(shapes, pm) { return shapes.map(s => { if (s.txt) { const p = pm(s.x, s.y); return Object.assign({}, s, { x: p[0], y: p[1] }); } const o = Object.assign({}, s); if (s.d) o.d = mapD(s.d, pm); if (s.clip) o.clip = mapD(s.clip, pm); if (s.f) o.f = mapPaint(s.f, pm); if (s.s) o.s = mapPaint(s.s, pm); return o; }); }
const PL = (o, U, V) => (u, v) => P3(o[0] + U[0] * u + V[0] * v, o[1] + U[1] * u + V[1] * v, o[2] + U[2] * u + V[2] * v);
function surf(fn, nu, nv, col, o) {
  o = o || {}; const G = [];
  for (let i = 0; i <= nu; i++) { const r = []; for (let j = 0; j <= nv; j++) r.push(fn(i / nu, j / nv)); G.push(r); }
  let c0 = o.c; if (!c0) { let a = 0, b = 0, c = 0, n = 0; G.forEach(r => r.forEach(p => { a += p[0]; b += p[1]; c += p[2]; n++; })); c0 = [a / n, b / n + 80, c / n]; }
  const nrm = (a, b, c, d, m) => { const ux = c[0] - a[0], uy = c[1] - a[1], uz = c[2] - a[2], vx = d[0] - b[0], vy = d[1] - b[1], vz = d[2] - b[2];
    let nx = uy * vz - uz * vy, ny = uz * vx - ux * vz, nz = ux * vy - uy * vx; const l = Math.hypot(nx, ny, nz); if (l < 1e-9) return null; nx /= l; ny /= l; nz /= l;
    if (nx * (m[0] - c0[0]) + ny * (m[1] - c0[1]) + nz * (m[2] - c0[2]) < 0) { nx = -nx; ny = -ny; nz = -nz; } return [nx, ny, nz]; };
  const P = p => P3(p[0], p[1], p[2]), cells = [], pts = [];
  G.forEach(r => r.forEach(p => pts.push(P(p))));
  for (let i = 0; i < nu; i++) for (let j = 0; j < nv; j++) {
    const a = G[i][j], b = G[i + 1][j], c = G[i + 1][j + 1], d = G[i][j + 1], m = [0, 1, 2].map(k => (a[k] + b[k] + c[k] + d[k]) / 4), n = nrm(a, b, c, d, m); if (!n) continue;
    if (o.cull !== false && n[0] * VV[0] + n[1] * VV[1] + n[2] * VV[2] < (o.cv == null ? -0.02 : o.cv)) continue;
    const h = col((i + 0.5) / nu, (j + 0.5) / nv, i, j, n); if (!h) continue;
    const cc = litC(h, (n[0] * LV[0] + n[1] * LV[1] + n[2] * LV[2]) * (o.lk || 1) + (o.lb || 0), o.dk);
    cells.push({ k: -KX * m[0] + KY * m[1] + m[2], s: sh(poly([a, b, c, d].map(P)), cc, { s: cc, w: 0.7 }) });
  }
  cells.sort((p, q) => q.k - p.k);
  const visAt = (u, v) => { const e = 0.012, u0 = Math.max(0, u - e), u1 = Math.min(1, u + e), v0 = Math.max(0, v - e), v1 = Math.min(1, v + e), n = nrm(fn(u0, v0), fn(u1, v0), fn(u1, v1), fn(u0, v1), fn(u, v)); return n ? n[0] * VV[0] + n[1] * VV[1] + n[2] * VV[2] : -1; };
  const lineOn = (uv, th) => { const out = []; let cur = null; uv.forEach(([u, v]) => { if (visAt(u, v) > (th || 0)) { if (!cur) { cur = []; out.push(cur); } cur.push(P(fn(u, v))); } else cur = null; }); return out.filter(q => q.length > 1).map(q => line(q)); };
  return { sh: cells.map(q => q.s), pts, P: (u, v) => P(fn(u, v)), F: fn, lineOn, visAt };
}
function Barrel(xa, xb, yb, dh, zc, dz) {
  const f3 = (u, v) => { const t = Math.PI * v; return [xa + (xb - xa) * u, yb - dh * Math.sin(t), dz + zc - zc * Math.cos(t)]; };
  const dp = (x, t) => P3(x, yb - dh * Math.sin(t), dz + zc - zc * Math.cos(t)), TC = Math.PI - Math.atan(dh / (zc * KY));
  const prof = (x, T, T0) => { T0 = T0 || 0; T = T == null ? TC : T; return Array.from({ length: 25 }, (_, i) => dp(x, T0 + (T - T0) * i / 24)); };
  return { f3, dp, TC, prof, c: [(xa + xb) / 2, yb + 5, dz + zc], cap: poly(prof(xb, Math.PI)), pts: prof(xa).concat(prof(xb, Math.PI)), xa, xb };
}

/* ---------------- SNACK SHACK ---------------- */
function snackBag() {
  const ink = '#6b3d1a';
  const front = parse('M-50 -2 Q-54 -58 -50 -112 L48 -112 Q52 -58 48 -2 Q0 3 -50 -2 Z');
  const side = parse('M48 -112 L60 -106 Q63 -56 60 -6 L48 -2 Q52 -58 48 -112 Z');
  const zz = []; for (let i = 0, x = 50; x > -53; x -= 6.4, i++) zz.push([x, i % 2 ? -103 : -109]);
  const flap = poly([[-53, -137], [50, -137]].concat(zz, [[-53, -109]])), flapSide = poly([[50, -137], [62, -131], [62, -107], [56, -102], [50, -109]]);
  const crinkles = [];
  [[[-40, -74], [-33, -68], [-36, -60]], [[30, -44], [36, -38], [33, -30]], [[14, -100], [22, -96]], [[-18, -14], [-10, -18], [-4, -13]], [[-42, -38], [-38, -31]], [[38, -84], [42, -76]]]
    .forEach(pts => crinkles.push(st(line(pts), 'rgba(255,248,230,0.65)', 1.4), st(line(pts.map(p => [p[0] + 1.2, p[1] + 1.4])), 'rgba(90,50,15,0.24)', 1.1)));
  const body = [
    sh(front, lg(-50, -112, 48, 0, '#f4d8a8', '#e0b47e', '#bd884c')),
    sh(side, lg(48, -110, 62, -6, '#c28d54', '#93602f')),
    st(line([[54, -108], [56.5, -56], [54, -5]]), 'rgba(90,50,15,0.35)', 1.6),
    sh(front, lg(-50, 0, 48, 0, [0, 'rgba(255,250,235,0.4)'], [0.2, 'rgba(255,250,235,0)'], [0.78, 'rgba(80,40,10,0)'], [1, 'rgba(80,40,10,0.24)'])),
    sh(front, lg(0, -36, 0, 0, 'rgba(80,40,10,0)', 'rgba(80,40,10,0.3)')),
    st(parse('M-47 -12 Q0 -7 45 -12'), 'rgba(90,50,15,0.3)', 1.6),
    sh(ell(-30, -20, 9, 6.5), 'rgba(150,85,20,0.2)'), sh(ell(-26, -24, 4, 3), 'rgba(150,85,20,0.16)'), sh(ell(30, -94, 6, 4.5), 'rgba(150,85,20,0.18)'),
    ...crinkles,
    ...friesIcon(-1, -28, 0.9),
    sh(spark4(-30, -56, 6), '#e5432f', { a: 0.85 }), sh(spark4(29, -64, 5), '#e5432f', { a: 0.85 }), sh(spark4(32, -38, 3.5), '#ffb020'),
    sh(ell(-32, -78, 11, 24), rg(-32, -78, 24, 'rgba(255,255,255,0.32)', 'rgba(255,255,255,0)')),
    st(front, ink, 2.6), st(side, ink, 2.6),
  ];
  const flapP = [
    sh(shift(flap, 0, 4), 'rgba(70,35,10,0.24)'),
    sh(flap, lg(-53, -137, 50, -103, '#f8e2b8', '#e6bd88', '#c99658')), sh(flapSide, lg(50, -137, 62, -104, '#bb8650', '#8e5c2c')),
    st(line([[-51, -131], [49, -131]]), 'rgba(255,250,235,0.7)', 1.5), st(line([[-51, -129.4], [49, -129.4]]), 'rgba(110,60,20,0.25)', 1),
    st(flap, ink, 2.4), st(flapSide, ink, 2.4),
    sh(rect(-7, -127, 14, 3.4, 1.5), '#dde1ea', { s: '#6a6f7c', w: 1 }),
  ];
  const tagR = rect(-14, -122, 28, 27, 4), tag = [sh(tagR, '#fffaf0')];
  for (let r = 0; r < 4; r++) for (let c = 0; c < 5; c++) if ((r + c) % 2 === 0) tag.push(sh(rect(-14 + c * 5.6, -122 + r * 6.75, 5.6, 6.75), '#e5432f', { clip: tagR }));
  tag.push(sh(tagR, lg(-14, -122, 14, -95, 'rgba(255,255,255,0.35)', 'rgba(255,255,255,0)', 'rgba(90,20,10,0.18)')), st(tagR, '#8a2216', 1.6), sh(ell(0, -117.5, 2.4), '#dde1ea', { s: '#6a6f7c', w: 0.8 }));
  return { name: 'Paper Snack Bag', mat: 'paper', hp: 6, W: 112, H: 137, ko: 'halves',
    hull: parse('M-51 -2 Q-54 -58 -52 -136 L50 -136 L61 -130 L61 -108 Q62 -56 59 -7 L48 -2 Q0 3 -51 -2 Z'),
    parts: [{ id: 'body', sh: body }, { id: 'flap', sh: flapP, launch: true, launchV: 380 }, { id: 'tag', sh: tag, tear: 0.34, hang: [0, -118], loose: 0, hmax: 0.5, hdir: 1 }],
    loot: ['fry', 'coin', 'fry', 'drop'] };
}

function snackTakeout() {
  const ink = '#6a3a14', b = Box(-66, -94, 48, 0, 36), { x0, x1, D } = b, S = d => b.side(d);
  const body = boxFill(b, { f: ['#f2c78c', '#d99f5d', '#b67c3c'], t: ['#fbe4ba', '#e6bb84'], s: ['#c58a4e', '#93602e'] });
  const bandF = rect(x0, -62, x1 - x0, 18), bandS = S(rect(0, -62, D, 18));
  for (let c = 0; c < 13; c++) for (let r = 0; r < 2; r++) if ((c + r) % 2 === 0) body.push(sh(rect(x0 + c * 9, -62 + r * 9, 9, 9), '#e5432f', { clip: bandF }));
  for (let c = 0; c < 4; c++) for (let r = 0; r < 2; r++) if ((c + r) % 2 === 1) body.push(sh(S(rect(c * 9, -62 + r * 9, 9, 9)), '#e5432f', { clip: bandS }));
  [-62, -44].forEach(y => body.push(st(line([[x0, y], [x1, y]]), 'rgba(120,30,15,0.5)', 1.2), st(S(line([[0, y], [D, y]])), 'rgba(90,20,10,0.5)', 1.2)));
  const wv = [], wt = []; for (let x = x0 + 2, i = 0; x <= x1 - 2; x += 3.5, i++) { wv.push([x, i % 2 ? -90.5 : -92.5]); wt.push([x, i % 2 ? 16.4 : 17.8]); }
  body.push(st(line(wv), 'rgba(120,70,20,0.45)', 1), st(b.top(line(wt)), 'rgba(120,70,20,0.4)', 1), st(b.top(line([[x0 + 1, 18.8], [x1, 18.8]])), 'rgba(90,50,15,0.6)', 1.4));
  body.push(...onF(friesIcon(26, -20, 0.3, { mono: 'rgba(110,60,20,0.55)' }), S));
  [7, 14].forEach(w => body.push(st(S(line([[w, -16], [w, -32]])), '#4a2a10', 1.6), st(S(line([[w - 2.6, -27.5], [w, -32], [w + 2.6, -27.5]])), '#4a2a10', 1.6)));
  body.push(sh(ell(-6.5, -50.5, 22), 'rgba(70,30,5,0.28)'), sh(ell(-9, -53, 22), '#fff6e8', { s: '#8a2216', w: 2 }), sh(ell(-9, -53, 16.5), lg(-26, -70, 8, -36, '#ff7a62', '#e5432f', '#b8281a')), ...friesIcon(-9, -42, 0.5, { box: '#fff6e8' }), sh(ell(-16, -63, 8, 4), 'rgba(255,255,255,0.45)'));
  body.push(sh(ell(-44, -80, 14, 9), rg(-44, -80, 16, 'rgba(255,255,255,0.26)', 'rgba(255,255,255,0)')));
  body.push(...boxShade(b, ink));
  const tT = b.top(rect(x0, 13, x1 - x0, 10)), tS = S(poly([[13, -94], [23, -94], [23, -78], [20.5, -75.5], [18, -78], [15.5, -75.5], [13, -78]]));
  const tape = [sh(tT, 'rgba(250,232,180,0.95)'), sh(tS, 'rgba(214,184,124,0.96)'), st(b.top(line([[x0 + 2, 15.4], [x1 - 2, 15.4]])), 'rgba(255,255,255,0.75)', 1.4), st(tT, 'rgba(150,100,40,0.55)', 1), st(tS, 'rgba(120,80,30,0.6)', 1)];
  const HZ = 18, hp = mapD(parse('M-24 -94 L-24 -112 Q-24 -124 -12 -124 L14 -124 Q26 -124 26 -112 L26 -94'), (x, y) => P3(x, y, HZ));
  const clipB = cx => { const cb = Box(cx - 7, -98, cx + 7, -94, 11, HZ - 5.5); return boxFill(cb, { f: ['#ffffff', '#eceef2', '#d4d8e0'], t: ['#ffffff', '#f2f3f6'], s: ['#c4c8d2', '#9ea4b2'] }).concat([st(cb.S, '#6e150c', 1.3), st(cb.T, '#6e150c', 1.3), st(cb.F, '#6e150c', 1.3)]); };
  const handle = [st(hp, '#6e150c', 11), st(hp, lg(0, -136, 0, -104, '#ff7a68', '#d8332a', '#a8201a'), 7.5), st(shift(hp, -1.4, -1.2), 'rgba(255,190,180,0.8)', 2), ...clipB(-24), ...clipB(26)];
  const RC = { f: (a, c, e, g) => lg(a, c, e, g, '#ff7a66', '#d8332a', '#9e1e14'), t: '#f0584a', s: '#a3241a' };
  const G = [[-1, -1], [1, -1], [-1, 1], [1, 1]].map(([cx, cy]) => { const g = corner3(b, cx, cy, 22, 7, 2, RC, '#6e150c'); g.sh.push(sh(ell(g.c[0], g.c[1], 1.8), '#ffd8d0')); return g; });
  return { name: 'Takeout Snack Box', mat: 'card', hp: 8, W: 150, H: 140, ko: 'pie', pieN: 6, hull: cvx(b.pts),
    parts: [{ id: 'body', sh: body }, { id: 'tape', sh: tape, tear: 0.3, hang: P3(x1, -94, 18), loose: 0.05, hmax: 0.9, hdir: 1 },
      { id: 'handle', sh: handle, tear: 0.6, hang: P3(-24, -94, HZ), loose: 0.3, hmax: 0.6, hdir: -1, launch: true },
      { id: 'g0', sh: G[0].sh, tear: 0.42 }, { id: 'g1', sh: G[1].sh, tear: 0.62 }, { id: 'g2', sh: G[2].sh, tear: 0.74 }, { id: 'g3', sh: G[3].sh, tear: 0.86 }],
    loot: ['fry', 'coin', 'fry', 'drop', 'coin'] };
}

function snackCrate() {
  const ink = '#4f2608', b = Box(-84, -112, 54, 0, 40), { x0, y0, x1, y1, D } = b, S = (d, o) => b.side(d, o), Tp = d => b.top(d);
  const WF = ['#f0c084', '#d89c5c', '#b67a3e'], WS = ['#cf9454', '#a86e36', '#8a5428'], WT = ['#fbdcaa', '#ecc086', '#d6a062'];
  const base = [sh(b.S, '#3e1e08'), sh(b.T, '#3e1e08')];
  [[-112, 36.6], [-74.4, 36.8], [-36.6, 36.6]].forEach(([v, h], i) => base.push(...plankS(0, v, D, h, S, WS, i === 2 ? [22, -16] : null, i * 3 + 7)));
  base.push(sh(S(star5(20, -94, 6, 2.6)), 'rgba(110,40,15,0.5)'));
  [[0, 12.6], [13.6, 12.8], [27.4, 12.6]].forEach(([w, h], i) => { base.push(...plankS(x0, w, x1 - x0, h, Tp, WT, i === 1 ? [-24, w + 6] : null, i * 5 + 1)); [-60, 28].forEach(u => base.push(nail(...mp(Tp, u, w + h / 2), 1.8))); });
  const postS = w => { const r = S(rect(w, y0, 10, y1 - y0)), o = [sh(r, mlg(S, w, 0, w + 10, 0, '#dca464', '#a86e36')), st(r, ink, 1.6)]; [-104, -56, -8].forEach(v => o.push(nail(...mp(S, w + 5, v), 2))); return o; };
  const eg = (u, w) => { const r = Tp(rect(u, w, 14, 10)); return [sh(r, '#f2ca8e'), st(Tp(ell(u + 7, w + 5, 4.6, 3.4)), 'rgba(140,80,30,0.55)', 1), st(Tp(ell(u + 7, w + 5, 2, 1.5)), 'rgba(140,80,30,0.55)', 1), st(r, ink, 1.6)]; };
  base.push(...postS(0), ...postS(30), ...eg(x0, 0), ...eg(x0, 30), ...eg(40, 0), ...eg(40, 30));
  base.push(...boxShade(b, ink, { only: 'TS' }), sh(b.F, '#3e1e08'));
  const stencil = friesIcon(-50, -41, 0.58, { mono: '#8e2a14', a: 0.78 }).concat([tx('SNACK CO.', 0, -61, '700 12px Fredoka, Nunito, sans-serif', '#8e2a14', { a: 0.8 }), sh(star5(0, -48, 3.5, 1.5), '#8e2a14', { a: 0.78 })]);
  const post = x => { const r = rect(x, y0, 14, y1 - y0, 2); return [sh(r, lg(x, 0, x + 14, 0, '#f6ca90', '#d49654', '#a8692f')), st(line([[x + 3, y0 + 5], [x + 3, y1 - 5]]), 'rgba(255,240,210,0.5)', 1.2), st(r, ink, 1.8), nail(x + 7, -104), nail(x + 7, -56), nail(x + 7, -8)]; };
  const STR = [[-62, -6, 10], [-52, 4, 13], [-42, -3, 8], [-30, 6, 12], [-18, -5, 9], [-6, 3, 14], [6, -6, 10], [16, 5, 12], [28, -2, 9]];
  const straw = []; [13.1, 26.9].forEach((w, j) => STR.forEach(([x, dx, len], i) => { const p = mp(Tp, x + j * 5, w); straw.push(st(line([p, [p[0] + dx * 0.5, p[1] - len * 0.6], [p[0] + dx, p[1] - len]]), (i + j) % 2 ? '#f2cf5a' : '#d9a92a', 2.2)); }));
  const Lb = [[6, -108], [36, -108], [36, -87], [6, -87]], LSb = [[6, -108], [36, -108], [36, -103], [6, -103]], la = -0.07, lc = [21, -97];
  const label = [sh(poly(rot(Lb, lc[0], lc[1], la)), '#fffaf0', { s: '#8a6a4a', w: 1.2 }), sh(poly(rot(LSb, lc[0], lc[1], la)), '#e5432f'),
    st(line(rot([[10, -97], [31, -97]], lc[0], lc[1], la)), 'rgba(60,40,30,0.55)', 1.4), st(line(rot([[10, -92], [24, -92]], lc[0], lc[1], la)), 'rgba(60,40,30,0.55)', 1.4)];
  const rp = parse('M14 -66 C13 -42 27 -42 26 -66'), rope = [st(S(rp, 2), '#6a4a1a', 5.5), st(S(rp, 2), '#d9b070', 3), st(S(shift(rp, -0.6, -0.8), 2.4), 'rgba(255,240,200,0.6)', 1), sh(S(ell(14, -66, 3), 2), '#c9a060', { s: '#6a4a1a', w: 1 }), sh(S(ell(26, -66, 3), 2), '#c9a060', { s: '#6a4a1a', w: 1 })];
  const IRON = { f: (a, c, e, g) => lg(a, c, e, g, '#c4cddb', '#6e7686', '#3a404c'), t: '#a9b2c2', s: '#4c5464' };
  const Bk = [[-1, -1], [1, -1], [-1, 1], [1, 1]].map(([cx, cy]) => { const g = corner3(b, cx, cy, 26, 8, 2, IRON, '#22262e'); g.sh.push(nail(g.c[0], g.c[1], 1.9), nail(g.X - cx * 22, g.Y - cy * 4, 1.9), nail(g.X - cx * 4, g.Y - cy * 22, 1.9)); return g; });
  return { name: 'Snack Crate', mat: 'wood', hp: 10, W: 180, H: 150, ko: 'planks', rows: [[-200, -112], [-112, -74.4], [-74.4, -37], [-37, 30]],
    hull: cvx(b.pts),
    parts: [{ id: 'base', sh: base },
      { id: 'p2', sh: plankS(x0, -74.4, x1 - x0, 36.8, null, WF, [30, -44], 2, stencil) },
      { id: 'p1', sh: plankS(x0, -112, x1 - x0, 36.6, null, WF, [-30, -100], 0), tear: 0.66, hang: [-62, -101], loose: 0.4, hmax: 1.05, hdir: 1 },
      { id: 'p3', sh: plankS(x0, -36.6, x1 - x0, 36.6, null, WF, [-14, -14], 4), tear: 0.86, hang: [36, -20], loose: 0.62, hmax: 0.5, hdir: -1 },
      { id: 'posts', sh: post(x0).concat(post(40), boxShade(b, ink, { only: 'F' })) },
      { id: 'straw', sh: straw, tear: 0.46 },
      { id: 'label', sh: label, tear: 0.26, hang: [8, -107], loose: 0.08, hmax: 1, hdir: 1 },
      { id: 'rope', sh: rope, tear: 0.55, hang: P3(x1 + 2, -66, 20), loose: 0.3, hmax: 0.6, hdir: 1 },
      { id: 'b0', sh: Bk[0].sh, tear: 0.36, hang: Bk[0].hang, loose: 0.2, hmax: 0.8, hdir: -1 },
      { id: 'b1', sh: Bk[1].sh, tear: 0.58, hang: Bk[1].hang, loose: 0.36, hmax: 0.8, hdir: 1 },
      { id: 'b2', sh: Bk[2].sh, tear: 0.78, hang: Bk[2].hang, loose: 0.56, hmax: 0.7, hdir: 1 },
      { id: 'b3', sh: Bk[3].sh, tear: 0.9, hang: Bk[3].hang, loose: 0.7, hmax: 0.7, hdir: -1 }],
    loot: ['fry', 'coin', 'drop', 'coin', 'star'] };
}

function snackVault() {
  const ink = '#4a0a06', B = Box(-94, -92, 62, 0, 42), L = Box(-97, -140, 65, -92, 45), BS = (d, o) => B.side(d, o), LS = (d, o) => L.side(d, o), LT = (d, o) => L.top(d, o), cx = -16, STEEL = '#3a4250';
  const RED = { f: ['#ff7a66', '#e5402e', '#a81e14'], t: ['#ff9c8a', '#f06450'], s: ['#c02e20', '#7a150c'] };
  const ball = (x, y, r) => [sh(ell(x, y, r), rg(x - 3, y - 3, r + 2.5, '#ffffff', '#c9d3e0', '#6a768a'), { s: STEEL, w: 1.4 }), sh(ell(x - r * 0.3, y - r * 0.35, r * 0.28, r * 0.19), '#ffffff')];
  const body = boxFill(B, RED), hz = rect(-94, -34, 156, 15), hzS = BS(rect(0, -34, 42, 15));
  body.push(sh(hz, '#2e2018'), sh(hzS, '#1e140e'));
  for (let x = -110; x < 66; x += 13) body.push(sh(poly([[x, -19], [x + 7, -19], [x + 22, -34], [x + 15, -34]]), '#ffd23a', { clip: hz }));
  for (let w = -18; w < 46; w += 13) body.push(sh(BS(poly([[w, -19], [w + 7, -19], [w + 22, -34], [w + 15, -34]])), '#d9a800', { clip: hzS }));
  body.push(sh(rect(-94, -92, 156, 12), lg(0, -92, 0, -80, 'rgba(40,0,0,0.5)', 'rgba(40,0,0,0)')), sh(BS(rect(0, -92, 42, 12)), mlg(BS, 0, -92, 0, -80, 'rgba(30,0,0,0.55)', 'rgba(30,0,0,0)')));
  const hb = parse('M14 -58 L28 -58');
  body.push(sh(BS(rect(10, -74, 22, 26, 7)), '#3a0a06'), sh(BS(rect(11, -73, 20, 11, 5)), 'rgba(0,0,0,0.35)'), sh(BS(ell(13, -58, 2.4)), '#9aa7ba'), sh(BS(ell(29, -58, 2.4)), '#9aa7ba'), st(BS(hb, 1.5), STEEL, 5.5), st(BS(hb, 1.5), '#d6dee9', 3.4), st(BS(shift(hb, 0, -0.9), 2), '#ffffff', 1));
  body.push(sh(ell(-60, -66, 22, 9), rg(-60, -66, 24, 'rgba(255,255,255,0.32)', 'rgba(255,255,255,0)')));
  body.push(...boxShade(B, ink, { only: 'FS' }));
  body.push(sh(rect(-97, -92, 9, 92, 2), chrome(-97, 0, -88, 0), { s: ink, w: 1.4 }), sh(BS(rect(36, -92, 6, 92), 0.6), mlg(BS, 36, 0, 42, 0, '#aab5c6', '#6a768a'), { s: ink, w: 1.2 }),
    sh(BS(rect(0, -92, 6, 92), 0.6), mlg(BS, 0, 0, 6, 0, '#c9d3e0', '#8e9bb0'), { s: ink, w: 1.2 }), sh(rect(55, -92, 8, 92, 2), chrome(55, 0, 63, 0), { s: ink, w: 1.4 }),
    sh(BS(rect(0, -8, 42, 8), 0.6), mlg(BS, 0, -8, 0, 0, '#aab5c6', '#6a768a'), { s: ink, w: 1.2 }), sh(rect(-97, -8, 160, 8, 3), chrome(0, -8, 0, 0), { s: ink, w: 1.4 }),
    ...ball(...P3(62, -4, 42), 7.5));
  const lid = boxFill(L, RED), tp = LT(rect(-88, 7, 144, 31));
  lid.push(sh(tp, mlg(LT, -88, 7, 56, 38, '#eef2f8', '#aab5c6', '#7d899e')), st(tp, STEEL, 1.4));
  for (let i = 0; i < 13; i++) for (let j = 0; j < 4; j++) { const u = -82 + i * 11 + (j % 2) * 5.5, w = 11.5 + j * 7.5, f = (i + j) % 2 ? 1 : -1; if (u > 52) continue;
    const q = LT(poly([[u - 3.6, w + 1.4 * f], [u - 2.4, w + 2.2 * f], [u + 3.6, w - 1.4 * f], [u + 2.4, w - 2.2 * f]]));
    lid.push(sh(shift(q, 0.7, 0.9), 'rgba(40,50,70,0.5)'), sh(q, '#f6f8fc')); }
  lid.push(sh(rect(cx - 32, -131, 68, 30, 9), 'rgba(60,5,0,0.3)'), sh(rect(cx - 34, -134, 68, 30, 9), gold(cx - 34, -134, cx + 34, -104), { s: '#7a4a00', w: 1.8 }), sh(rect(cx - 29, -130, 58, 22, 6), 'rgba(122,74,0,0.18)'), ...friesIcon(cx, -107, 0.5), sh(star5(cx - 22, -119, 4, 1.8), '#fff6c0'), sh(star5(cx + 22, -119, 4, 1.8), '#fff6c0'));
  const lp = LS(rect(9, -132, 27, 32, 5));
  lid.push(sh(lp, mlg(LS, 9, -132, 36, -100, '#e4e9f0', '#8e9bb0')), st(lp, STEEL, 1.3), ...onF(friesIcon(22.5, -106, 0.42, { mono: 'rgba(90,20,10,0.55)' }), LS), ...[[12, -129], [33, -129], [12, -103], [33, -103]].map(([w, v]) => nail(...mp(LS, w, v), 1.6)));
  lid.push(sh(ell(-66, -128, 18, 6), rg(-66, -128, 20, 'rgba(255,255,255,0.4)', 'rgba(255,255,255,0)')));
  lid.push(...boxShade(L, ink));
  const lt = (r, c) => sh(LT(r, 0.6), c, { s: ink, w: 1.1 }), ls = (r, c) => sh(LS(r, 0.6), c, { s: ink, w: 1.1 });
  lid.push(lt(rect(-97, 40, 162, 5), '#c9d3e0'), lt(rect(-97, 0, 6, 45), '#e4e9f0'), lt(rect(59, 0, 6, 45), '#d6dee9'),
    ls(rect(0, -140, 45, 6), '#b4bfcf'), ls(rect(40, -140, 5, 48), '#7f8ba0'), ls(rect(0, -140, 5, 48), '#aab5c6'), ls(rect(0, -98, 45, 8), '#8e9bb0'),
    sh(rect(-99, -142, 166, 7, 3), chrome(0, -142, 0, -135), { s: ink, w: 1.4 }), sh(rect(-99, -140, 8, 48, 2), chrome(-99, 0, -91, 0), { s: ink, w: 1.4 }), sh(rect(58, -140, 8, 48, 2), chrome(58, 0, 66, 0), { s: ink, w: 1.4 }),
    sh(rect(-99, -98, 166, 8, 3), chrome(0, -98, 0, -90), { s: ink, w: 1.4 }),
    ...ball(...P3(-97, -140, 45), 7), ...ball(...P3(65, -140, 45), 7), ...ball(...P3(65, -94, 45), 6.5),
    sh(rect(cx - 15, -101, 30, 22, 5), chrome(cx - 15, -101, cx + 15, -79), { s: STEEL, w: 1.4 }), nail(cx - 9, -95, 1.8), nail(cx + 9, -95, 1.8));
  const band = x => { const t = LT(rect(x, 0, 14, 45), 1.4), o = [sh(t, mlg(LT, x, 0, x + 14, 45, '#ffffff', '#c9d3e0', '#8e9bb0')), st(t, STEEL, 1.3), sh(rect(x, -141.4, 14, 141.4, 3), chrome(x, 0, x + 14, 0), { s: STEEL, w: 1.4 })];
    for (let y = -132; y > -4; y -= 19) o.push(nail(x + 7, y, 2.4)); o.push(nail(...P3(x + 7, -141.4, 14), 2), nail(...P3(x + 7, -141.4, 32), 2)); return o; };
  const sock = (x, y) => [sh(ell(x, y, 4.5), '#4a0a06')];
  const shk = shift(parse('M-8 -84 L-8 -95 Q-8 -105 0 -105 Q8 -105 8 -95 L8 -84'), cx, 0);
  const lock = [st(shk, STEEL, 7), st(shk, chrome(cx - 8, -105, cx + 8, -84), 4.5),
    sh(rect(cx - 12, -90, 32, 27, 7), '#a86e00', { s: '#6a4200', w: 1.6 }),
    sh(rect(cx - 16, -87, 32, 27, 7), gold(cx - 16, -87, cx + 16, -60), { s: '#6a4200', w: 1.8 }), sh(ell(cx, -77, 4.2), rg(cx - 1.4, -78.4, 5, '#ffd0c8', '#e5302a', '#8a1410')),
    sh(ell(cx, -68, 2), '#4a2a00'), sh(poly([[cx - 1.4, -68], [cx + 1.4, -68], [cx + 2, -63], [cx - 2, -63]]), '#4a2a00'), sh(ell(cx - 9, -81, 2.6, 1.6), 'rgba(255,255,255,0.8)')];
  return { name: 'Heavy-Duty Snack Vault', mat: 'metal', hp: 12, W: 200, H: 168, ko: 'pie', pieN: 5,
    hull: cvx(B.pts.concat(L.pts)),
    parts: [{ id: 'body', sh: body }, { id: 'lid', sh: lid, launch: true },
      { id: 'bandL', sh: band(cx - 53), tear: 0.62, hang: [cx - 46, -136], loose: 0.4, hmax: 0.32, hdir: -1 },
      { id: 'bandR', sh: band(cx + 39), tear: 0.84, hang: [cx + 46, -136], loose: 0.6, hmax: 0.3, hdir: 1 },
      { id: 'c0', sh: ball(-95, -4, 8.5), tear: 0.46, scar: sock(-95, -4) }, { id: 'c1', sh: ball(63, -4, 8.5), tear: 0.7, scar: sock(63, -4) },
      { id: 'c2', sh: ball(-97, -140, 8.5), tear: 0.56, scar: sock(-97, -140) }, { id: 'c3', sh: ball(65, -140, 8.5), tear: 0.9, scar: sock(65, -140) },
      { id: 'lock', sh: lock, tear: 0.92, hang: [cx, -98], loose: 0.6, hmax: 0.7, hdir: 1 }],
    loot: ['coin', 'fry', 'coin', 'gem', 'drop', 'star'] };
}

function snackTreasury() {
  const ink = '#6a3c00', B = Box(-100, -96, 72, 0, 46), SB = Box(-103, -110, 75, -96, 49, -1.5), S = d => B.side(d), PI = Math.PI;
  const RBL = ['#ff8fd8', '#ffe38a', '#9ff7c8', '#9fd8ff', '#d6b3ff', '#ff8fd8'];
  const GB = { f: ['#fff2a8', '#ffcf30', '#d99a10'], t: ['#fff6c0', '#ffd84a'], s: ['#e0a414', '#8a5800'] };
  const panelM = (m, x, y, w, h) => { const r = m(rect(x, y, w, h, 8)), c = mp(m, x + w / 2, y + h / 2), g0 = mp(m, x, y), g1 = mp(m, x, y + h), pts = [];
    for (let t = 0; t < 3 * PI; t += 0.25) { const rr = 2 + t * 2.1; pts.push([x + w / 2 + Math.cos(t) * rr, y + h / 2 + Math.sin(t) * rr]); }
    return [sh(r, cg(c[0], c[1], 0, 0.7, ...RBL)), st(m(line(pts)), 'rgba(255,255,255,0.6)', 3, { clip: r }),
      sh(r, lg(g0[0], g0[1], g1[0], g1[1], [0, 'rgba(255,255,255,0.6)'], [0.35, 'rgba(255,255,255,0.08)'], [1, 'rgba(80,0,120,0.22)'])),
      st(shift(r, 2.4, 2.4), 'rgba(110,50,0,0.55)', 4, { clip: r }), st(shift(r, -1.8, -1.8), 'rgba(255,255,255,0.75)', 2.4, { clip: r }), st(r, '#8a5200', 2)]; };
  const pillar = (x, yT, yB, gem) => { const ym = (yT + yB) / 2; return [sh(rect(x - 7, yT, 14, yB - yT), lg(x - 7, 0, x + 7, 0, '#fff6c0', '#ffd23a', '#d89a10', '#8a5800'), { s: ink, w: 1.4 }),
    st(line([[x - 3.6, yT + 7], [x - 3.6, yB - 8]]), 'rgba(255,255,255,0.8)', 1.6),
    sh(rect(x - 9.5, yT - 2, 19, 7, 3), gold(x - 9.5, yT - 2, x + 9.5, yT + 5), { s: ink, w: 1.3 }), sh(rect(x - 9.5, yB - 8, 19, 7, 3), gold(x - 9.5, yB - 8, x + 9.5, yB - 1), { s: ink, w: 1.3 }),
    sh(ell(x, ym, 3.8), rg(x - 1.2, ym - 1.2, 4.6, '#ffffff', gem), { s: ink, w: 1 })]; };
  const foot = (x, y) => sh(ell(x, y, 10, 7), rg(x - 3, y - 2, 11, '#fff6c0', '#ffd23a', '#a86e00'), { s: ink, w: 1.4 });
  const [bpx, bpy] = P3(72, 0, 46), plS = S(rect(0, -10, 46, 10));
  const body = [foot(bpx, bpy + 3), ...boxFill(B, GB), ...panelM(S, 9, -86, 28, 70),
    sh(plS, mlg(S, 0, -10, 0, 0, '#e8a400', '#8a5800')), st(plS, ink, 1.2),
    ...panelM(FR, -92, -88, 46, 74), ...panelM(FR, -38, -88, 50, 74), ...panelM(FR, 20, -88, 44, 74),
    sh(rect(-46, -92, 8, 80, 3), gold(-46, 0, -38, 0), { s: ink, w: 1.4 }), sh(rect(12, -92, 8, 80, 3), gold(12, 0, 20, 0), { s: ink, w: 1.4 }),
    sh(ell(-42, -52, 4), '#9fd8ff', { s: ink, w: 1 }), sh(ell(16, -52, 4), '#ff8fd8', { s: ink, w: 1 }),
    sh(rect(-100, -11, 172, 11), gold(0, -11, 0, 0), { s: ink, w: 1.4 }), st(line([[-98, -9], [70, -9]]), 'rgba(255,255,255,0.7)', 1.2),
    ...boxShade(B, ink, { k: 0.7 }),
    ...pillar(bpx, bpy - 96, bpy, '#9ff7c8'), foot(-100, 3), foot(72, 3), ...pillar(-100, -96, 0, '#ff6fb8'), ...pillar(72, -96, 0, '#5cb8ff')];
  const seam = [...boxFill(SB, { f: ['#fff6c0', '#ffcf30', '#c88a00'], t: ['#fff6c0', '#ffe066'], s: ['#d89a10', '#8a5800'] }), ...boxShade(SB, ink, { k: 0.6 })];
  [10, 24, 38].forEach((w, i) => { const [x, y] = SB.Q(75.6, -103, w); seam.push(sh(ell(x, y, 3.6, 4.2), rg(x - 1.2, y - 1.4, 4.6, '#ffffff', RB[(i + 1) % 5], RB[(i + 3) % 5]), { s: ink, w: 1 })); });
  const studs = k => { const o = []; let i = 0; for (let x = -92; x <= 66; x += 17.5, i++) if (i % 2 === k) { const [X, Y] = SB.Q(x, -103, 0); o.push(sh(ell(X, Y, 4.4), rg(X - 1.4, Y - 1.4, 5, '#ffffff', RB[i % 5], RB[(i + 2) % 5]), { s: ink, w: 1 })); } return o; };
  const hp = shift(parse('M-1 -34 C-24 -48 -26 -64 -16 -72 C-9 -77 -3 -74 -1 -68 C1 -74 7 -77 14 -72 C24 -64 22 -48 -1 -34 Z'), -12, 0);
  const lock = [sh(rect(-18, -99, 10, 28, 4), gold(-18, 0, -8, 0), { s: ink, w: 1.4 }), sh(shift(hp, 3, -2.4), '#9a6400', { s: '#7a4800', w: 1.6 }), sh(hp, gold(-38, -77, 12, -34), { s: '#7a4800', w: 2 }),
    sh(ell(-13, -58, 7, 8), cg(-13, -58, 0, 1.4, ...RBL), { s: '#7a4800', w: 1.2 }), sh(ell(-15.4, -61, 2.4, 1.6), 'rgba(255,255,255,0.9)'),
    sh(ell(-13, -46, 2.2), '#4a2600'), sh(poly([[-14.4, -46], [-11.6, -46], [-11, -40], [-15, -40]]), '#4a2600'), st(parse('M-31 -62 Q-30 -70 -24 -73'), 'rgba(255,255,255,0.75)', 1.6)];
  const xa = -102, xb = 74, yb = -110, dh = 52, zc = 24.5, dz = -0.5, N = 24, M = 14;
  const dp = (x, t) => P3(x, yb - dh * Math.sin(t), dz + zc - zc * Math.cos(t)), TC = 1.86, prof = (x, T) => Array.from({ length: N + 1 }, (_, i) => dp(x, (T || TC) * i / N));
  const SCL = ['#ff7ccf', '#ffb3e4', '#ffd84a', '#ffe9a0', '#6fe8b0', '#b4f5d6', '#6cc4ff', '#b6dcff', '#b98cff', '#dcc8ff', '#ff7ccf'], nS = SCL.length, sw = (xb - xa) / nS;
  const lit = (h, li) => li > 0.82 ? mixC(h, '#ffffff', Math.min(0.3, (li - 0.82) * 2.2)) : mixC(h, '#4a1060', Math.min(0.55, (0.82 - li) * 0.5));
  const lid = [];
  for (let j = M - 1; j >= 0; j--) { const t0 = TC * j / M, t1 = Math.min(TC, TC * (j + 1) / M + 0.02), tm = TC * (j + 0.5) / M, li = 0.78 * Math.sin(tm) + 0.5 * Math.cos(tm);
    for (let i = 0; i < nS; i++) { const a = xa + i * sw, c = Math.min(xb, a + sw + 0.6); lid.push(sh(poly([dp(a, t0), dp(c, t0), dp(c, t1), dp(a, t1)]), lit(SCL[i], li))); } }
  const dome = poly(prof(xa).concat(prof(xb).reverse()));
  lid.push(sh(dome, lg(xa, 0, xb + 36, 0, [0, 'rgba(255,255,255,0.16)'], [0.5, 'rgba(255,255,255,0)'], [1, 'rgba(60,0,80,0.16)'])));
  const [hx, hy] = dp(-56, 0.95); lid.push(sh(ell(hx, hy, 32, 6), rg(hx, hy, 32, 'rgba(255,255,255,0.75)', 'rgba(255,255,255,0)')));
  [-58, -14, 30].forEach(x => { const pr = line(prof(x)); lid.push(st(pr, ink, 7), st(pr, gold(x, -180, x + 36, -110), 4.5), st(shift(pr, -0.8, -0.8), 'rgba(255,255,255,0.6)', 1.2)); });
  const fe = line([dp(xa, 0), dp(xb, 0)]), la2 = line(prof(xa)), lb3 = line(prof(xb, PI));
  lid.push(st(fe, ink, 8), st(fe, gold(0, -114, 0, -106), 5.5), st(la2, ink, 9), st(la2, gold(xa, -180, xa + 36, -110), 6), st(shift(la2, -1, -1), 'rgba(255,255,255,0.75)', 1.6));
  const cap = poly(prof(xb, PI)), [ccx, ccy] = P3(xb, yb - 20, dz + zc), capI = poly(Array.from({ length: N + 1 }, (_, i) => { const t = PI * i / N; return P3(xb + 0.6, yb - 4 - (dh - 12) * Math.sin(t), dz + zc - (zc - 7) * Math.cos(t)); }));
  lid.push(sh(cap, lg(xb, -170, xb + 36, -110, '#ffd84a', '#d89a10', '#8a5800')), sh(capI, cg(ccx, ccy, 0, 0.7, ...RBL)), sh(capI, 'rgba(60,0,90,0.18)'), st(capI, '#8a5200', 1.6),
    st(lb3, ink, 9), st(lb3, gold(xb, -180, xb + 36, -110), 6), st(shift(lb3, -1, -1), 'rgba(255,255,255,0.5)', 1.4));
  const topOf = pr => pr.reduce((m, p) => p[1] < m[1] ? p : m), tA = dp(xa, TC), tB = dp(xb, TC); lid.splice(M * nS + 2, 0, st(line([tA, tB]), ink, 2.6));
  const [bx, by] = dp(-14, 1.15), cpts = [[-22, 2], [-26, -26], [-12, -14], [0, -37], [12, -14], [26, -26], [22, 2]].map(([x, y]) => [bx + x, by + y]);
  const crest = [sh(poly(cpts.map(([x, y]) => [x + 3, y - 2.4])), '#9a6400', { s: '#7a4800', w: 1.6 }), sh(poly(cpts), gold(bx - 26, by - 37, bx + 22, by), { s: '#7a4800', w: 2 }),
    st(line([[bx - 20.5, by - 1], [bx - 23.5, by - 22]]), 'rgba(255,255,255,0.7)', 1.4), sh(rect(bx - 23, by - 5, 46, 8, 3), gold(0, by - 5, 0, by + 3), { s: '#7a4800', w: 1.4 }),
    sh(ell(bx - 26, by - 28, 4.2), rg(bx - 27, by - 29, 5, '#ffffff', '#ff5c8a')), sh(ell(bx, by - 40, 5.2), rg(bx - 1.5, by - 41.5, 6, '#ffffff', '#5cb8ff')), sh(ell(bx + 26, by - 28, 4.2), rg(bx + 25, by - 29, 5, '#ffffff', '#3ad08a')),
    sh(star5(bx, by - 15, 5.5, 2.4), '#ffffff')];
  return { name: 'Rainbow Snack Treasury', mat: 'candy', hp: 14, W: 236, H: 218, ko: 'pie', pieN: 8, ring: true,
    hull: cvx(B.pts.concat(SB.pts, prof(xa), prof(xb, PI), [[-107, 2], [-107, -97], [bpx + 8, bpy - 97], [bpx + 8, bpy]])),
    parts: [{ id: 'body', sh: body }, { id: 'seam', sh: seam }, { id: 'studA', sh: studs(0), tear: 0.32 }, { id: 'studB', sh: studs(1), tear: 0.54 },
      { id: 'lock', sh: lock, tear: 0.9, hang: [-13, -97], loose: 0.6, hmax: 0.6, hdir: 1 }, { id: 'lid', sh: lid, launch: true },
      { id: 'crest', sh: crest, tear: 0.74, launch: true }],
    loot: ['coin', 'gem', 'fry', 'star', 'coin', 'gem'], rb: true };
}

const MODELS = { snack: [snackBag, snackTakeout, snackCrate, snackVault, snackTreasury] };
const CACHE = {}, ICONS = {};
function register(g, builders, x) { x = x || {}; MODELS[g] = builders; Object.assign(MAT, x.mat || {}); Object.assign(ICONS, x.icons || {}); Object.assign(CRACK, x.crack || {}); for (let i = 0; i < 5; i++) delete CACHE[g + i]; API.groups = Object.keys(MODELS); }
function fin(m) {
  m.parts.forEach(p => [p.sh, p.scar || []].forEach(list => list.forEach(s => { if (s.d) s.sp = flat(s.d); if (s.clip) s.clipSp = flat(s.clip); })));
  m.hullSp = flat(m.hull); m.bb = bbox(m.hullSp); m.sc = m.W / 150; m.M = MAT[m.mat];
  const bb = m.bb; m.peeks = Array.from({ length: 8 }, (_, i) => ({ k: m.loot[i % m.loot.length], x: rnd(bb.x0 + 16, bb.x1 - 22), y: rnd(bb.y0 + 22, bb.y1 - 14), r: rnd(-0.7, 0.7), s: rnd(15, 22), c: RB[i % 5] }));
  return m;
}
function model(group, tier) { const key = group + tier; if (!CACHE[key]) { const g = MODELS[group] || MODELS.snack; CACHE[key] = fin(g[clamp(tier, 0, 4)]()); } return CACHE[key]; }

/* ---------------- icons (loot) ---------------- */
function rrPath(c, x, y, w, h, r) { c.beginPath(); c.moveTo(x + r, y); c.lineTo(x + w - r, y); c.quadraticCurveTo(x + w, y, x + w, y + r); c.lineTo(x + w, y + h - r); c.quadraticCurveTo(x + w, y + h, x + w - r, y + h); c.lineTo(x + r, y + h); c.quadraticCurveTo(x, y + h, x, y + h - r); c.lineTo(x, y + r); c.quadraticCurveTo(x, y, x + r, y); c.closePath(); }
function drawIcon(c, k, s, col) {
  c.lineJoin = 'round';
  if (ICONS[k]) { ICONS[k](c, s, col); return; }
  if (k === 'fry') { rrPath(c, -s * 0.15, -s * 0.5, s * 0.3, s, s * 0.1); c.fillStyle = '#ffd23a'; c.fill(); c.strokeStyle = '#c98a00'; c.lineWidth = s * 0.08; c.stroke(); c.fillStyle = 'rgba(255,255,255,0.6)'; c.fillRect(-s * 0.08, -s * 0.42, s * 0.06, s * 0.7); }
  else if (k === 'coin') { const g = c.createRadialGradient(-s * 0.15, -s * 0.15, 0, 0, 0, s * 0.45); g.addColorStop(0, '#fff6b0'); g.addColorStop(0.5, '#ffd23a'); g.addColorStop(1, '#d08a00'); c.fillStyle = g; c.beginPath(); c.arc(0, 0, s * 0.42, 0, TAU); c.fill(); c.strokeStyle = '#9a6000'; c.lineWidth = s * 0.07; c.stroke(); c.beginPath(); c.arc(0, 0, s * 0.27, 0, TAU); c.strokeStyle = 'rgba(154,96,0,0.55)'; c.lineWidth = s * 0.05; c.stroke(); c.fillStyle = 'rgba(255,255,255,0.85)'; c.beginPath(); c.ellipse(-s * 0.14, -s * 0.16, s * 0.08, s * 0.05, -0.6, 0, TAU); c.fill(); }
  else if (k === 'drop') { c.beginPath(); c.moveTo(0, -s * 0.5); c.bezierCurveTo(s * 0.1, -s * 0.25, s * 0.36, -s * 0.05, s * 0.36, s * 0.14); c.arc(0, s * 0.14, s * 0.36, 0, Math.PI); c.bezierCurveTo(-s * 0.36, -s * 0.05, -s * 0.1, -s * 0.25, 0, -s * 0.5); c.closePath(); c.fillStyle = '#e5302a'; c.fill(); c.strokeStyle = '#8a1410'; c.lineWidth = s * 0.06; c.stroke(); c.fillStyle = 'rgba(255,255,255,0.75)'; c.beginPath(); c.ellipse(-s * 0.12, s * 0.08, s * 0.06, s * 0.11, 0.3, 0, TAU); c.fill(); }
  else if (k === 'star') { c.beginPath(); for (let i = 0; i < 10; i++) { const a = -Math.PI / 2 + i * Math.PI / 5, r = (i % 2 ? 0.22 : 0.5) * s; if (i) c.lineTo(Math.cos(a) * r, Math.sin(a) * r); else c.moveTo(Math.cos(a) * r, Math.sin(a) * r); } c.closePath(); c.fillStyle = '#ffe066'; c.fill(); c.strokeStyle = '#d99a00'; c.lineWidth = s * 0.07; c.stroke(); }
  else { c.beginPath(); c.moveTo(0, -s * 0.45); c.lineTo(s * 0.38, -s * 0.12); c.lineTo(0, s * 0.45); c.lineTo(-s * 0.38, -s * 0.12); c.closePath(); c.fillStyle = col || '#9fd8ff'; c.fill(); c.strokeStyle = 'rgba(40,0,60,0.45)'; c.lineWidth = s * 0.06; c.stroke(); c.beginPath(); c.moveTo(-s * 0.38, -s * 0.12); c.lineTo(s * 0.38, -s * 0.12); c.moveTo(0, -s * 0.45); c.lineTo(-s * 0.12, -s * 0.12); c.lineTo(0, s * 0.45); c.lineTo(s * 0.12, -s * 0.12); c.closePath(); c.strokeStyle = 'rgba(255,255,255,0.75)'; c.lineWidth = s * 0.04; c.stroke(); }
}

/* ---------------- damage helpers ---------------- */
function genCrack(x, y, len, style) {
  const out = [], j = style === 'scratch' ? 0.16 : 0.55;
  const walk = (x, y, a, L, depth) => { const pts = [[x, y]], n = Math.max(2, Math.round(L / 6)); for (let i = 0; i < n; i++) { a += rnd(-j, j); x += Math.cos(a) * 6; y += Math.sin(a) * 6; pts.push([x, y]); if (depth < 2 && Math.random() < 0.18) walk(x, y, a + rnd(0.6, 1.1) * (Math.random() < 0.5 ? -1 : 1), L * 0.45, depth + 1); } out.push(pts); };
  const k = style === 'scratch' ? 2 : style === 'rip' ? 2 : 3, a0 = rnd(0, TAU);
  for (let i = 0; i < k; i++) walk(x, y, a0 + i * TAU / k + rnd(-0.4, 0.4), len * rnd(0.6, 1), 0);
  return out;
}
function holePoly(x, y, R, jag) {
  const pts = [];
  if (jag === 'splinter') { const n = 18; for (let i = 0; i < n; i++) { const a = i / n * TAU, ca = Math.cos(a), sa = Math.sin(a); let k = rnd(0.75, 1); if (Math.abs(ca) > 0.7) k *= i % 2 ? 1.4 : 0.78; pts.push([x + ca * R * 1.5 * k, y + sa * R * 0.55 * k]); } return pts; }
  const n = { tear: 22, ragged: 14, petal: 10, shard: 7 }[jag] || 12;
  for (let i = 0; i < n; i++) { const a = i / n * TAU + rnd(-0.1, 0.1); let k = rnd(0.72, 1);
    if (jag === 'tear') k *= i % 2 ? 0.7 : 1.06; else if (jag === 'petal') k *= i % 2 ? 0.55 : 1.12; else if (jag === 'shard') k = rnd(0.6, 1.15);
    pts.push([x + Math.cos(a) * R * k, y + Math.sin(a) * R * k]); }
  return pts;
}
function koPolys(m) {
  const bb = m.bb, cx = (bb.x0 + bb.x1) / 2, cy = (bb.y0 + bb.y1) / 2, BIG = 420, J = { paper: 5, card: 4, wood: 3, metal: 2.5, candy: 2 }[m.mat] || 3, out = [];
  if (m.ko === 'halves') {
    const seam = []; for (let y = bb.y0 - 40; y <= 40; y += 6) seam.push([cx - 4 + rnd(-J, J) + (seam.length % 2 ? 3.5 : -3.5), y]);
    out.push({ pts: [[-BIG, bb.y0 - 40]].concat(seam, [[-BIG, 40]]), vx: -60, up: 0.28, vr: -rnd(2.4, 3.4), vf: rnd(-1.2, 1.2), pow: 0.3 });
    out.push({ pts: [[BIG, bb.y0 - 40]].concat(seam, [[BIG, 40]]), vx: 60, up: 0.28, vr: rnd(2.4, 3.4), vf: rnd(-1.2, 1.2), pow: 0.3 });
  } else if (m.ko === 'planks') {
    m.rows.forEach(([y0, y1]) => { const sx = cx + rnd(-0.28, 0.28) * m.W, cut = []; for (let y = y0; y <= y1; y += 5) cut.push([sx + rnd(-4, 4) + (cut.length % 2 ? 2.5 : -2.5), y]);
      out.push({ pts: [[-BIG, y0]].concat(cut, [[-BIG, y1]]) }); out.push({ pts: [[BIG, y0]].concat(cut, [[BIG, y1]]) }); });
  } else {
    const n = m.pieN || 7, R = 360, ring = !!m.ring, a0 = rnd(0, TAU), edges = [];
    for (let i = 0; i < n; i++) { const a = a0 + (i + rnd(-0.22, 0.22)) / n * TAU, ca = Math.cos(a), sa = Math.sin(a), rr = Math.min(m.W, m.H) * 0.27 * rnd(0.8, 1.2), pts = [[cx, cy]]; let ri = 0;
      for (let r = 10; r < R; r += 10) { if (ring && !ri && r >= rr) { pts.push([cx + ca * rr, cy + sa * rr]); ri = pts.length - 1; } const jj = r < 150 ? rnd(-J, J) * 1.3 : 0; pts.push([cx + ca * r - sa * jj, cy + sa * r + ca * jj]); }
      pts.push([cx + ca * R, cy + sa * R]); edges.push({ pts, ri, a, rr }); }
    for (let i = 0; i < n; i++) { const A = edges[i], B = edges[(i + 1) % n];
      if (!ring) { out.push({ pts: A.pts.concat(B.pts.slice().reverse()) }); continue; }
      let aB = B.a; if (aB < A.a) aB += TAU; const arc = [];
      for (let k = 1; k < 6; k++) { const t = k / 6, an = A.a + (aB - A.a) * t, r = A.rr + (B.rr - A.rr) * t + rnd(-J, J); arc.push([cx + Math.cos(an) * r, cy + Math.sin(an) * r]); }
      out.push({ pts: A.pts.slice(0, A.ri + 1).concat(arc, B.pts.slice(0, B.ri + 1).reverse()), pow: 0.8 });
      out.push({ pts: A.pts.slice(A.ri).concat(B.pts.slice(B.ri).reverse(), arc.slice().reverse()) });
    }
  }
  return out;
}

/* ---------------- chest instance ---------------- */
const LW = 300, LH = 290, OX = 150, OY = 255;
const UPD = [0, 1.1, 1.45, 1.85, 2.6], UPH = [0, 1.0, 1.2, 1.5, 2.3], DK = [0, 0.62, 0.74, 0.85, 0.94];
const IDW = (x, y, o) => { o[0] = x; o[1] = y; };
class Chest {
  constructor(m) { Object.assign(this, { m, d: 0, dents: [], cracks: [], holes: [], torn: {}, ang: {}, av: {}, lean: Math.random() < 0.5 ? -1 : 1, seed: Math.random() * 100, gone: false }); this.W = (x, y, o) => this.warp(x, y, o); }
  warp(x, y, o) {
    const m = this.m, M = m.M, d = this.d; let X = x, Y = y;
    if (d > 0) {
      const h = clamp(-y / m.H, 0, 1.4); X += this.lean * d * M.lean * h * h; Y += d * M.sag * h;
      if (M.soft) { const s = this.seed, a = M.soft * d * 0.6; X += a * (Math.sin(x * 0.19 + s) + Math.sin(y * 0.23 + s * 1.7)); Y += a * (Math.sin(y * 0.17 + s * 0.6) + Math.sin(x * 0.21 + s * 2.3)); }
      for (let i = 0; i < this.dents.length; i++) { const q = this.dents[i], dx = x - q.x, dy = y - q.y, r2 = dx * dx + dy * dy; if (r2 > q.r2x) continue; const e = Math.exp(-r2 / q.rr); X += q.nx * q.k * e - dx * q.p * e; Y += q.ny * q.k * e - dy * q.p * e; }
    }
    o[0] = X; o[1] = Y;
  }
}

/* ---------------- stage ---------------- */
class Stage {
  constructor(cv, o) {
    this.cv = cv; this.ctx = cv.getContext('2d'); this.o = o || {}; this.on = this.o.onEvent || (() => {});
    this.ts = 1; this.time = 0; this.sound = true; this.q = []; this.spr = []; this.pt = []; this.chest = null; this.group = this.o.group || 'snack'; this.tier = 0;
    this.mo = { x: 0, vx: 0, y: 0, vy: 0, r: 0, vr: 0, q: 0, vq: 0, ps: 1, vps: 0 };
    this.shake = 0; this.flash = 0; this.sflash = 0; this.stop = 0; this.glow = { k: 0, rays: 0 }; this.open = null; this.charge = null; this.busy = false; this.lastB = 0; this.idleT = 0; this.upTo = null; this.dark = 0; this.lift = 0; this.burst = 0; this.burstI = 0; this.burstR = 1; this.pillar = 0; this.sfc = '#ffffff';
    this.layer = document.createElement('canvas'); this.lx = this.layer.getContext('2d');
    this.scr = document.createElement('canvas'); this.sx = this.scr.getContext('2d');
    this.mk = document.createElement('canvas'); this.mk.width = LW; this.mk.height = LH; this.mkx = this.mk.getContext('2d', { willReadFrequently: true }); this._ls = 0; this._ms = -1;
    this.cut = document.createElement('canvas'); this.cutx = this.cut.getContext('2d', { willReadFrequently: true });
    this.resize();
    this.ro = new ResizeObserver(() => this.resize()); this.ro.observe(cv);
    this.vis = true; if (window.IntersectionObserver) { this.io = new IntersectionObserver(es => { this.vis = es[es.length - 1].isIntersecting; }); this.io.observe(cv); }
    let last = performance.now();
    const loop = t => { this.raf = requestAnimationFrame(loop); const dt = Math.min(0.034, Math.max(0, (t - last) / 1000)); last = t; this.tick(dt * this.ts); if (this.vis) this.draw(); };
    this.raf = requestAnimationFrame(loop);
  }
  destroy() { cancelAnimationFrame(this.raf); this.ro.disconnect(); if (this.io) this.io.disconnect(); }
  buildMask() {
    if (this._ms === this._ls) return; this._ms = this._ls; const g = this.mkx, c = this.chest, T = this.time;
    g.setTransform(1, 0, 0, 1, 0, 0); g.clearRect(0, 0, LW, LH); if (!c) return; g.setTransform(1, 0, 0, 1, OX, OY);
    for (const p of c.m.parts) { if (c.torn[p.id]) { if (p.scar) p.scar.forEach(s => drawShape(g, s, c.W, T)); continue; } drawPart(g, p, c.W, T, c.ang[p.id] || 0); }
    if (c.holes.length) { g.save(); g.globalCompositeOperation = 'destination-out'; g.fillStyle = '#000'; c.holes.forEach(h => { tracePts(g, h, c.W); g.fill(); }); g.restore(); }
  }
  covered(pts, x0, y0, x1, y1) {
    this.buildMask(); const w = Math.max(1, Math.ceil(x1 - x0)), h = Math.max(1, Math.ceil(y1 - y0)), g = this.cutx;
    if (this.cut.width < w || this.cut.height < h) { this.cut.width = Math.max(this.cut.width, w); this.cut.height = Math.max(this.cut.height, h); }
    g.setTransform(1, 0, 0, 1, 0, 0); g.clearRect(0, 0, w, h); g.save(); g.beginPath(); pts.forEach(([x, y], i) => { if (i) g.lineTo(x - x0, y - y0); else g.moveTo(x - x0, y - y0); }); g.closePath(); g.clip(); g.drawImage(this.mk, -(x0 + OX), -(y0 + OY)); g.restore();
    const dd = g.getImageData(0, 0, w, h).data; let n = 0; for (let i = 3; i < dd.length; i += 4) if (dd[i] > 40) n++;
    return n >= Math.max(3, w * h * 0.03);
  }
  resize() {
    const r = this.cv.getBoundingClientRect(), dpr = Math.min(2, window.devicePixelRatio || 1); if (!r.width || !r.height) return;
    this.w = r.width; this.h = r.height; this.dpr = dpr; this.cv.width = Math.round(r.width * dpr); this.cv.height = Math.round(r.height * dpr);
    const gr = this.o.ground || 0.8, top = this.o.top || 120; this.gx = this.w / 2; this.gy = this.h * gr;
    this.s = Math.max(0.6, Math.min(this.w / 290, (this.gy - top) / 238)); this.k = this.s * dpr;
    this.layer.width = this.scr.width = Math.ceil(LW * this.k); this.layer.height = this.scr.height = Math.ceil(LH * this.k);
  }
  sfx(fn, ...a) { const X = window.ChestSFX; if (X && this.sound) try { X[fn](...a); } catch (e) {} }
  at(t, fn) { this.q.push({ t, fn }); }
  P(o) { this.pt.push(Object.assign({ t: 0, life: 1.6, g: 1500, drag: 0.4, bounce: 0.35, r: 0, vr: 0, gz: rnd(-4, 16), a: 1 }, o)); if (this.pt.length > 520) this.pt.splice(0, this.pt.length - 520); }
  load(group, tier, pop) {
    this.group = group; this.tier = tier; const m = model(group, tier); this.chest = new Chest(m); this.hp = m.hp; this.open = null; this.charge = null;
    Object.assign(this.mo, { x: 0, vx: 0, y: 0, vy: 0, r: 0, vr: 0, q: 0, vq: 0 });
    if (pop) { this.mo.ps = 0.5; this.mo.vps = 4; } else { this.mo.ps = 1; this.mo.vps = 0; }
    this.on({ type: 'loaded', tier, hp: this.hp, max: m.hp, name: m.name });
  }
  reset(group, tier) {
    this.q = []; this.spr = []; this.pt = []; this.busy = false; this.upTo = null; this.glow.k = 0; this.glow.rays = 0; this.burst = 0; this.pillar = 0; this.load(group || this.group, tier, true);
    const m = this.chest.m; for (let i = 0; i < 10; i++) { const sd = i % 2 ? 1 : -1; this.P({ type: 'dust', x: sd * rnd(10, m.W * 0.5), y: rnd(-4, 4), vx: sd * rnd(60, 160), vy: -rnd(10, 50), s: rnd(12, 22), c: m.M.dust, a: 0.75, life: rnd(0.6, 0.9), g: -20, drag: 3 }); }
  }
  tw(x, y) { const mo = this.mo, q = clamp(mo.q, -0.3, 0.4), sx = mo.ps * (1 + q * 0.5), sy = mo.ps * (1 - q), c = Math.cos(mo.r), s = Math.sin(mo.r); x *= sx; y *= sy; return [x * c - y * s + mo.x, x * s + y * c + mo.y]; }
  fromClient(cx, cy) { const r = this.cv.getBoundingClientRect(), mo = this.mo; let x = (cx - r.left - this.gx) / this.s - mo.x, y = (cy - r.top - this.gy) / this.s - mo.y; const c = Math.cos(-mo.r), s = Math.sin(-mo.r); return [(x * c - y * s) / mo.ps, (x * s + y * c) / mo.ps]; }
  hitAt(cx, cy, P) { if (!this.chest) return; const [x, y] = this.fromClient(cx, cy), bb = this.chest.m.bb; this.hit(clamp(x, bb.x0 + 12, bb.x1 - 14), clamp(y, bb.y0 + 14, bb.y1 - 10), P); }
  hit(x, y, P) {
    const c = this.chest; if (!c || this.busy || this.open || c.gone || this.hp <= 0) return;
    P = P || 1; const m = c.m, M = m.M, mo = this.mo;
    this.hp--; c.d = 1 - this.hp / m.hp; const d = c.d, final = this.hp === 0;
    const ccx = (m.bb.x0 + m.bb.x1) / 2, ccy = -m.H * 0.5; let nx = ccx - x, ny = ccy - y; const nl = Math.hypot(nx, ny) || 1; nx /= nl; ny /= nl;
    const r = rnd(16, 26) * Math.sqrt(m.sc); c.dents.push({ x, y, r, rr: r * r, r2x: r * r * 4.6, k: M.dentK * rnd(0.7, 1.2) * P, nx, ny, p: 0.12 }); if (c.dents.length > 18) c.dents.shift();
    if (d > 0.1) { c.cracks.push(genCrack(x, y, rnd(16, 30) * Math.sqrt(m.sc) * (0.7 + d), M.crack)); if (d > 0.55) c.cracks.push(genCrack(x + rnd(-14, 14), y + rnd(-14, 14), rnd(14, 26), M.crack)); if (c.cracks.length > 24) c.cracks.splice(0, c.cracks.length - 24); }
    m.parts.forEach(p => { if (p.hang && !c.torn[p.id]) c.av[p.id] = (c.av[p.id] || 0) + (x < p.hang[0] ? 1 : -1) * rnd(2.5, 5) * P; });
    if (!final) {
      const fl = this.flash; this.flash = 0; this.renderLayer(); this.flash = fl;
      if (d >= M.holeFrom && Math.random() < M.holeP) this.chunk(x, y, P);
      m.parts.forEach(p => { if (p.tear != null && !c.torn[p.id] && d >= p.tear - 1e-6) this.tearPart(p, x, y, P); });
    }
    const side = x > ccx ? -1 : 1, ms = M.mass * Math.sqrt(m.sc);
    mo.vx += side * 240 * P / ms; mo.vr += side * 1.1 * P / ms; mo.vq += 4.5 * P / ms; if (M.mass < 1.2) mo.vy -= 170 * P;
    this.stop = final ? 0 : 0.05; this.shake = Math.max(this.shake, 3 + 2.5 * P * M.mass); this.flash = 0.9;
    const [wx, wy] = this.tw(x, y);
    this.P({ type: 'ring', x: wx, y: wy, r0: 8, r1: 34 + 16 * P, c: '#ffffff', life: 0.3, g: 0, bounce: -1 });
    for (let i = 0; i < 3; i++) this.P({ type: 'dust', x: wx + rnd(-8, 8), y: wy + rnd(-8, 8), vx: rnd(-60, 60) - nx * 40, vy: rnd(-60, 10), s: rnd(10, 18), c: M.dust, a: 0.7, life: rnd(0.6, 0.9), g: 0, drag: 3 });
    this.debris(wx, wy, Math.round(5 + 4 * P), P, Math.atan2(-ny, -nx));
    if (M.spark) for (let i = 0; i < 9; i++) { const a = rnd(0, TAU), v = rnd(250, 520); this.P({ type: 'spark', x: wx, y: wy, vx: Math.cos(a) * v, vy: Math.sin(a) * v - 120, life: rnd(0.25, 0.45), g: 900, c: M.spark === 'rb' ? pick(RB) : M.spark, bounce: -1 }); }
    this.sfx('hit', { kind: 'poke', heavy: final || P > 1.2, group: this.group, lv: this.tier, dmg: d, ko: final, mat: M.sfx });
    this.on({ type: 'hp', hp: this.hp, max: m.hp });
    if (final) this.ko(x, y);
  }
  debris(x, y, n, P, dirA) {
    const M = this.chest.m.M;
    for (let i = 0; i < n; i++) {
      const a = dirA != null ? dirA + rnd(-1.2, 1.2) : rnd(0, TAU), v = rnd(120, 300) * P, vx = Math.cos(a) * v, vy = Math.sin(a) * v - rnd(140, 280) * P, col = pick(M.chips), rr = Math.random(), kind = rr < 0.4 ? M.deb : rr < 0.62 && M.deb2 ? M.deb2 : rr < 0.5 ? M.deb : 'chip';
      if (kind === 'drop') { this.P({ type: 'drop', x, y, vx, vy, c: M.dropC || col, s: rnd(3, 5.5), bounce: 0.08, life: rnd(1.1, 1.7) }); continue; }
      if (kind === 'bubble') { this.P({ type: 'bubble', x, y, vx: vx * 0.35, vy: -rnd(40, 130), s: rnd(3, 7.5), g: -70, drag: 1.4, bounce: -1, life: rnd(1, 1.8), ph: rnd(0, TAU), fl: 70 }); continue; }
      if (kind === 'fluff') { this.P({ type: 'fluff', x, y, vx: vx * 0.6, vy: vy * 0.6, c: col, s: rnd(4, 8), g: 320, drag: 2, fl: 130, ph: rnd(0, TAU), bounce: 0.05, life: rnd(1.6, 2.4) }); continue; }
      if (kind === 'shred') this.P({ type: 'shred', x, y, vx, vy, c: col, w: rnd(5, 11), h: rnd(4, 8), vr: rnd(-8, 8), vf: rnd(6, 14), g: 650, drag: 1.6, fl: 260, ph: rnd(0, TAU), bounce: 0.1, life: rnd(2.2, 3) });
      else if (kind === 'splinter') this.P({ type: 'splinter', x, y, vx, vy, c: col, w: rnd(10, 18), h: rnd(2, 3.2), r: rnd(0, TAU), vr: rnd(-14, 14), bounce: 0.3, life: rnd(2, 2.8) });
      else if (kind === 'bolt') this.P({ type: 'bolt', x, y, vx, vy, s: rnd(2.5, 4), bounce: 0.5, life: rnd(2, 2.8) });
      else if (kind === 'gem') this.P({ type: 'gem', x, y, vx, vy, c: col, s: rnd(5, 9), r: rnd(0, TAU), vr: rnd(-10, 10), bounce: 0.4, life: rnd(2, 2.8) });
      else { const s = rnd(3, 7), nv = 4 + (Math.random() * 2 | 0), v2 = []; for (let k = 0; k < nv; k++) { const aa = k / nv * TAU + rnd(-0.3, 0.3), rr = s * rnd(0.6, 1); v2.push([Math.cos(aa) * rr, Math.sin(aa) * rr]); } this.P({ type: 'chip', x, y, vx, vy, c: col, v: v2, r: rnd(0, TAU), vr: rnd(-12, 12), bounce: 0.35, life: rnd(2, 2.8) }); }
    }
  }
  crop(pts, check, src) {
    let x0 = 1e9, y0 = 1e9, x1 = -1e9, y1 = -1e9; pts.forEach(([x, y]) => { x0 = Math.min(x0, x); x1 = Math.max(x1, x); y0 = Math.min(y0, y); y1 = Math.max(y1, y); });
    x0 = Math.max(x0 - 2, -OX); y0 = Math.max(y0 - 2, -OY); x1 = Math.min(x1 + 2, LW - OX); y1 = Math.min(y1 + 2, LH - OY); if (x1 - x0 < 2 || y1 - y0 < 2) return null;
    if (check && !this.covered(pts, x0, y0, x1, y1)) return null;
    const k = this.k, w = Math.ceil((x1 - x0) * k), h = Math.ceil((y1 - y0) * k), cv = document.createElement('canvas'); cv.width = w; cv.height = h; const g = cv.getContext('2d');
    g.save(); g.beginPath(); pts.forEach(([x, y], i) => { const px = (x - x0) * k, py = (y - y0) * k; if (i) g.lineTo(px, py); else g.moveTo(px, py); }); g.closePath(); g.clip(); g.drawImage(src || this.layer, -(x0 + OX) * k, -(y0 + OY) * k); g.restore();
    const dk = document.createElement('canvas'); dk.width = w; dk.height = h; const gd = dk.getContext('2d'); gd.drawImage(cv, 0, 0); gd.globalCompositeOperation = 'source-atop'; gd.fillStyle = 'rgba(30,12,0,0.42)'; gd.fillRect(0, 0, w, h);
    return { img: cv, dk, w: x1 - x0, h: y1 - y0, cx: (x0 + x1) / 2, cy: (y0 + y1) / 2 };
  }
  addSpr(s, x, y, vx, vy, vr, vf, r0) { this.spr.push(Object.assign(s, { x, y, vx, vy, vr, vf, r: r0 || 0, fp: 0, gz: rnd(-4, 18), rest: 0, t: 0, M: this.chest.m.M, seed: rnd(0, TAU) })); if (this.spr.length > 70) this.spr.shift(); }
  chunk(x, y, P) {
    const c = this.chest, M = c.m.M, R = rnd(M.holeR[0], M.holeR[1]) * Math.sqrt(c.m.sc), poly = holePoly(x, y, R, M.jag);
    const wp = poly.map(([px, py]) => { c.W(px, py, _o); return [_o[0], _o[1]]; }), s = this.crop(wp, true); c.holes.push(poly); if (!s) return;
    const [wx, wy] = this.tw(s.cx, s.cy), a = Math.atan2(y + c.m.H * 0.5, x - (c.m.bb.x0 + c.m.bb.x1) / 2), v = rnd(140, 260) * P / Math.sqrt(M.mass);
    this.addSpr(s, wx, wy, Math.cos(a) * v, Math.sin(a) * v * 0.5 - rnd(180, 300) * P, rnd(-7, 7), rnd(-9, 9), this.mo.r);
    for (let i = 0; i < 4; i++) this.P({ type: 'dust', x: wx + rnd(-6, 6), y: wy + rnd(-6, 6), vx: rnd(-50, 50), vy: rnd(-50, 0), s: rnd(12, 20), c: M.dust, a: 0.75, life: rnd(0.6, 1), g: 0, drag: 3 });
  }
  partBox(p) {
    const c = this.chest, a = c.ang[p.id] || 0; let pv = null; if (a && p.hang) { c.W(p.hang[0], p.hang[1], _o); pv = [_o[0], _o[1]]; }
    const ca = Math.cos(a), sa = Math.sin(a); let x0 = 1e9, y0 = 1e9, x1 = -1e9, y1 = -1e9;
    const add = (x, y) => { c.W(x, y, _o); let X = _o[0], Y = _o[1]; if (pv) { const dx = X - pv[0], dy = Y - pv[1]; X = pv[0] + dx * ca - dy * sa; Y = pv[1] + dx * sa + dy * ca; } x0 = Math.min(x0, X); x1 = Math.max(x1, X); y0 = Math.min(y0, Y); y1 = Math.max(y1, Y); };
    p.sh.forEach(s => { if (s.sp) s.sp.forEach(sub => { for (let i = 0; i < sub.p.length; i += 2) add(sub.p[i], sub.p[i + 1]); }); else if (s.txt) { add(s.x - 36, s.y - 10); add(s.x + 36, s.y + 10); } });
    const pad = 6; return [[x0 - pad, y0 - pad], [x1 + pad, y0 - pad], [x1 + pad, y1 + pad], [x0 - pad, y1 + pad]];
  }
  tearPart(p, hx, hy, P, launch) {
    const c = this.chest; if (c.torn[p.id]) return; const S = this.sx, k = this.k;
    S.setTransform(1, 0, 0, 1, 0, 0); S.clearRect(0, 0, this.scr.width, this.scr.height); S.setTransform(k, 0, 0, k, OX * k, OY * k); drawPart(S, p, c.W, this.time, c.ang[p.id] || 0);
    const s = this.crop(this.partBox(p), false, this.scr); c.torn[p.id] = true; if (!s) return;
    const [wx, wy] = this.tw(s.cx, s.cy); let dx = s.cx - hx, dy = s.cy - hy; const L = Math.hypot(dx, dy) || 1; dx /= L; dy /= L;
    let vx, vy, vr, vf;
    if (launch) { const lv = p.launchV || 660; vx = rnd(-90, 90) + dx * 60; vy = -rnd(lv * 0.85, lv * 1.15); vr = rnd(-5, 5); vf = rnd(-4, 4); }
    else if (p.hang) { vx = dx * rnd(40, 90) * P; vy = -rnd(30, 120) * P; vr = (c.av[p.id] || 0) * 0.8 + rnd(-2, 2); vf = rnd(-2, 2); }
    else { vx = dx * rnd(160, 280) * P; vy = dy * rnd(80, 160) * P - rnd(200, 330) * P; vr = rnd(-8, 8); vf = rnd(-8, 8); }
    this.addSpr(s, wx, wy, vx, vy, vr, vf, this.mo.r + (c.ang[p.id] || 0) * 0);
    if (c.m.M.spark && !launch) for (let i = 0; i < 6; i++) { const a = rnd(0, TAU), v = rnd(200, 420); this.P({ type: 'spark', x: wx, y: wy, vx: Math.cos(a) * v, vy: Math.sin(a) * v - 100, life: rnd(0.2, 0.4), g: 900, c: c.m.M.spark === 'rb' ? pick(RB) : c.m.M.spark, bounce: -1 }); }
  }
  ko(hx, hy) {
    const c = this.chest, m = c.m, M = m.M; this.busy = true; this.on({ type: 'koStart' });
    this.stop = 0.13; this.shake = 20; this.sflash = 0.9; this.flash = 0;
    this.renderLayer();
    m.parts.forEach(p => { if (p.launch && !c.torn[p.id]) this.tearPart(p, 0, -m.H * 0.2, 1.4, true); });
    this.renderLayer();
    const E = [(m.bb.x0 + m.bb.x1) / 2, -m.H * 0.45];
    koPolys(m).forEach(pl => { const s = this.crop(pl.pts, true); if (!s) return; const [wx, wy] = this.tw(s.cx, s.cy); let dx = s.cx - E[0], dy = s.cy - E[1]; const L = Math.hypot(dx, dy) || 1; dx /= L; dy /= L;
      const sp = rnd(150, 300) * (pl.pow || 1) / Math.sqrt(M.mass); this.addSpr(s, wx, wy, dx * sp + (pl.vx || 0), dy * sp * 0.6 - rnd(220, 400) * (pl.up || 1), pl.vr != null ? pl.vr : rnd(-6, 6), pl.vf != null ? pl.vf : rnd(-7, 7), this.mo.r); });
    c.gone = true;
    const [cx, cy] = this.tw(E[0], E[1]);
    this.P({ type: 'ring', x: cx, y: cy, r0: 10, r1: m.W * 0.95, c: '#ffffff', life: 0.45, g: 0, bounce: -1 });
    this.P({ type: 'ring', x: cx, y: cy, r0: 10, r1: m.W * 0.7, c: TIER[this.tier].fx, life: 0.55, g: 0, bounce: -1 });
    for (let i = 0; i < 24; i++) { const sd = i % 2 ? 1 : -1; this.P({ type: 'dust', x: this.mo.x + rnd(-m.W * 0.5, m.W * 0.5), y: rnd(-6, 4), vx: sd * rnd(70, 260), vy: -rnd(10, 70), s: rnd(18, 34), c: M.dust, a: 0.85, life: rnd(1, 1.6), g: -24, drag: 2.4 }); }
    for (let i = 0; i < 12; i++) this.P({ type: 'dust', x: cx + rnd(-30, 30), y: cy + rnd(-30, 30), vx: rnd(-140, 140), vy: rnd(-160, 40), s: rnd(18, 30), c: M.dust, a: 0.8, life: rnd(0.8, 1.3), g: -10, drag: 2.6 });
    this.debris(cx, cy, 34, 1.6, null);
    if (M.spark) for (let i = 0; i < 26; i++) { const a = rnd(0, TAU), v = rnd(300, 640); this.P({ type: 'spark', x: cx, y: cy, vx: Math.cos(a) * v, vy: Math.sin(a) * v - 160, life: rnd(0.3, 0.55), g: 900, c: M.spark === 'rb' ? pick(RB) : M.spark, bounce: -1 }); }
    this.sfx('burst', this.tier, this.group, M.sfx);
    this.at(this.time + 0.32, () => this.reveal());
  }
  reveal() {
    const m = this.chest.m, n = [12, 16, 22, 30, 40][this.tier], cx = this.mo.x, cy = -m.H * 0.35, kinds = m.loot.concat(this.tier >= 3 ? ['gem', 'gem', 'star'] : []);
    this.open = { t0: this.time };
    for (let i = 0; i < n; i++) { const a = -Math.PI / 2 + rnd(-1, 1) * (0.6 + this.tier * 0.1), v = rnd(420, 760); this.P({ type: 'loot', k: pick(kinds), x: cx + rnd(-10, 10), y: cy, vx: Math.cos(a) * v, vy: Math.sin(a) * v, s: rnd(16, 24), r: rnd(-0.5, 0.5), vr: rnd(-6, 6), g: 1300, bounce: 0.42, life: rnd(3.2, 4.2), c: pick(RB) }); }
    for (let i = 0; i < 18 + this.tier * 6; i++) { const a = rnd(0, TAU), v = rnd(120, 360); this.P({ type: 'star', x: cx, y: cy, vx: Math.cos(a) * v, vy: Math.sin(a) * v - 80, s: rnd(6, 13), c: TIER[this.tier].rb ? pick(RB) : TIER[this.tier].fx, life: rnd(0.6, 1), g: 200, drag: 2, bounce: -1 }); }
    this.busy = false; this.on({ type: 'ko', tier: this.tier });
  }
  upgrade(to) {
    if (this.busy || !this.chest || to <= this.tier) return; this.busy = true; this.upTo = to; let t = this.time + 0.05;
    for (let i = this.tier + 1; i <= to; i++) { const fin = i === to, dur = UPD[i] * (fin ? 1 : 0.55), ti = i; this.at(t, () => this.beginCharge(ti, dur, fin)); this.at(t + dur, () => this.poof(ti, fin)); t += dur + (fin ? 0 : 0.6); }
    this.at(t + UPH[to], () => this.endUp());
  }
  skipUp() { if (this.upTo == null) return; this.q = []; this.charge = null; if (this.tier !== this.upTo) this.poof(this.upTo, true); this.endUp(); }
  endUp() { const to = this.upTo; this.busy = false; this.upTo = null; this.on({ type: 'upgradeDone', tier: to }); }
  beginCharge(i, dur, fin) {
    const n = 5 + 3 * i;
    this.charge = { i, k: 0, rate: 1 / dur, c: TIER[i].fx, rb: !!TIER[i].rb, acc: 0, ra: 0, fin, beams: Array.from({ length: n }, (_, j) => ({ a: (j + rnd(-0.3, 0.3)) / n * TAU, w: rnd(0.04, 0.1), l: rnd(0.8, 1.25), at: rnd(0.06, 0.85), f: rnd(0, TAU) })) };
    this.sfx('charge', dur / this.ts); this.on({ type: 'charge', tier: i });
  }
  poof(i, fin) {
    fin = fin !== false; this.charge = null; this.load(this.group, i, true); const m = this.chest.m, T = TIER[i], cy = -m.H * 0.5, P = fin ? 1 : 0.7, col = () => T.rb ? pick(RB) : T.fx;
    this.mo.ps = 0.3; this.mo.vps = 6 + i;
    this.burst = 1; this.burstI = i; this.burstR = 1 / (0.75 + 0.3 * i); this.pillar = Math.max(this.pillar, (0.45 + 0.15 * i) * P); this.stop = (0.05 + 0.03 * i) * P;
    const nd = 18 + 6 * i;
    for (let k = 0; k < nd; k++) { const a = k / nd * TAU + rnd(-0.1, 0.1), ex = Math.cos(a) * m.W * 0.5, ey = Math.sin(a) * m.H * 0.48, v = 1 + i * 0.18; this.P({ type: 'dust', x: ex, y: cy + ey, vx: Math.cos(a) * rnd(110, 240) * v, vy: Math.sin(a) * rnd(80, 190) * v - 30, s: rnd(20, 36), c: k % 3 ? '#ffffff' : col(), a: 0.95, life: rnd(0.7, 1.2), g: -30, drag: 2.6 }); }
    for (let k = 0; k < (24 + i * 16) * P; k++) { const a = rnd(0, TAU), v = rnd(180, 460 + i * 60); this.P({ type: 'star', x: rnd(-20, 20), y: cy, vx: Math.cos(a) * v, vy: Math.sin(a) * v, s: rnd(6, 14 + i), c: T.rb ? pick(RB) : (k % 3 ? T.fx : '#ffffff'), life: rnd(0.6, 1.1), g: 120, drag: 2.2, bounce: -1 }); }
    for (let k = 0; k <= i; k++) this.at(this.time + k * 0.11, () => this.P({ type: 'ring', x: 0, y: cy, r0: 20, r1: m.W * (1.1 + k * 0.45), c: k % 2 ? '#ffffff' : (T.rb ? RB[(k * 2) % 5] : T.fx), lw: 12 - k, life: 0.55 + k * 0.08, g: 0, bounce: -1 }));
    this.P({ type: 'gring', x: 0, y: 0, r0: 10, r1: m.W * (1.3 + 0.25 * i), c: T.rb ? '#ffffff' : T.fx, lw: 10, life: 0.75, g: 0, bounce: -1 });
    if (i >= 3 && fin) { const cc = T.rb ? RB.concat(['#ffd23a', '#ffffff']) : ['#ffd23a', '#fff6c0', '#ffb020', '#ffffff'];
      for (let k = 0; k < (T.rb ? 80 : 34); k++) this.P({ type: 'shred', x: rnd(-20, 20), y: cy, vx: rnd(-440, 440), vy: -rnd(450, 980), c: pick(cc), w: rnd(6, 11), h: rnd(4, 7), r: 0, vr: rnd(-8, 8), vf: rnd(6, 14), g: 700, drag: 1.4, fl: 300, ph: rnd(0, TAU), bounce: 0.1, life: rnd(2.4, 3.4) }); }
    if (T.rb && fin) for (let k = 1; k < 5; k++) this.at(this.time + 0.2 + k * 0.2, () => { this.sflash = Math.max(this.sflash, 0.32); this.sfc = RB[k % 5]; this.shake = Math.max(this.shake, 7); this.P({ type: 'ring', x: 0, y: cy, r0: 30, r1: m.W * (1.6 + k * 0.3), c: RB[k % 5], lw: 9, life: 0.7, g: 0, bounce: -1 }); for (let j = 0; j < 14; j++) { const a = rnd(0, TAU), v = rnd(200, 420); this.P({ type: 'star', x: Math.cos(a) * 30, y: cy + Math.sin(a) * 30, vx: Math.cos(a) * v, vy: Math.sin(a) * v, s: rnd(7, 13), c: RB[(k + j) % 5], life: rnd(0.6, 1), g: 80, drag: 2.2, bounce: -1 }); } });
    this.sflash = (0.75 + i * 0.06) * P; this.sfc = '#ffffff'; this.shake = (8 + i * 4) * P; this.sfx('poof', i);
    this.on({ type: 'step', tier: i, hp: this.hp, max: m.hp, name: m.name });
  }
  tick(dt) {
    this.time += dt; const T = this.time;
    if (this.q.length) { this.q.sort((a, b) => a.t - b.t); while (this.q.length && this.q[0].t <= T) this.q.shift().fn(); }
    this.flash = Math.max(0, this.flash - dt * 6); this.sflash = Math.max(0, this.sflash - dt * 2.6); this.shake *= Math.exp(-9 * dt);
    const ch = this.chest, m = ch && ch.m, mo = this.mo;
    if (this.stop > 0) { this.stop -= dt; return; }
    mo.vx += (-110 * mo.x - 12 * mo.vx) * dt; mo.x += mo.vx * dt;
    mo.vr += (-140 * mo.r - 11 * mo.vr) * dt; mo.r += mo.vr * dt;
    mo.vq += (-420 * mo.q - 15 * mo.vq) * dt; mo.q += mo.vq * dt;
    mo.vy += 2600 * dt; mo.y += mo.vy * dt; if (mo.y > 0) { mo.y = 0; mo.vy = mo.vy > 200 ? -mo.vy * 0.25 : 0; }
    mo.vps += (-170 * (mo.ps - 1) - 10 * mo.vps) * dt; mo.ps += mo.vps * dt;
    if (ch && !ch.gone) m.parts.forEach(p => { if (!p.hang || ch.torn[p.id]) return; const lo = p.loose != null ? p.loose : (p.tear != null ? p.tear - 0.3 : 0), te = p.tear != null ? p.tear : 1, l = clamp((ch.d - lo) / Math.max(0.05, te - lo), 0, 1);
      const a = ch.ang[p.id] || 0, v = ch.av[p.id] || 0, nv = v + (-55 * (a - p.hdir * p.hmax * l * l) - 3.2 * v) * dt; ch.av[p.id] = nv; ch.ang[p.id] = a + nv * dt; });
    const G = this.glow, tr = TIER[this.tier]; let tk = this.tier === 3 ? 0.4 : this.tier === 4 ? 0.55 : 0, rays = this.tier === 4 ? 0.3 : 0;
    if (this.charge) { const C = this.charge; C.k = Math.min(1, C.k + dt * C.rate); tk = 0.5 + 0.8 * C.k; rays = Math.max(rays, C.k > 0.4 ? C.k : 0); C.acc += dt * (30 + (40 + 26 * C.i) * C.k);
      while (C.acc > 1) { C.acc--; const a = rnd(0, TAU), dd = rnd(170, 280), cy = -m.H * 0.5 + this.lift; this.P({ type: 'mote', x: Math.cos(a) * dd, y: cy + Math.sin(a) * dd, sx: Math.cos(a) * dd, sy: cy + Math.sin(a) * dd, tx: 0, ty: cy, s: rnd(4, 9 + C.i), c: C.rb ? pick(RB) : (Math.random() < 0.3 ? '#ffffff' : C.c), life: rnd(0.4, 0.6), g: 0, bounce: -1, sw: C.rb ? rnd(1.6, 2.6) : C.i >= 3 ? rnd(0.5, 1) : 0 }); } }
    if (this.open) { tk = 1.15; rays = 1; }
    if (ch && ch.gone && !this.open) tk = 0.8;
    { const C = this.charge, ci = C ? C.i : this.tier, dk = this.upTo != null ? DK[ci] * (C ? 0.7 + 0.3 * Math.min(1, C.k * 2) : 1) : 0;
      this.dark += (dk - this.dark) * Math.min(1, dt * (dk > this.dark ? 4 : 1.8));
      const lt = C ? -(6 + 5 * C.i) * (1 - Math.pow(1 - C.k, 2)) : 0; this.lift += (lt - this.lift) * Math.min(1, dt * (C ? 6 : 9));
      if (this.burst > 0) this.burst = Math.max(0, this.burst - dt * this.burstR);
      if (!C) this.pillar = Math.max(0, this.pillar - dt * 0.9);
      if (C && m) { this.pillar = Math.max(this.pillar, C.k * C.k * (0.15 + 0.12 * C.i)); C.ra += dt; const iv = Math.max(0.09, 0.34 - 0.04 * C.i - 0.16 * C.k);
        if (C.ra > iv) { C.ra = 0; this.P({ type: 'iring', x: mo.x, y: -m.H * 0.5 + this.lift, r0: m.W * (1.25 + 0.1 * C.i), r1: m.W * 0.3, c: C.rb ? pick(RB) : C.c, lw: 3 + C.i, life: 0.5, g: 0, bounce: -1 }); } } }
    G.k += (tk - G.k) * Math.min(1, dt * 5); G.rays += (rays - G.rays) * Math.min(1, dt * 4); G.c = this.charge ? this.charge.c : tr.fx; G.rb = this.charge ? this.charge.rb : !!tr.rb;
    this.idleT += dt;
    if (ch && !ch.gone && this.tier >= 3 && this.idleT > (this.tier === 4 ? 0.16 : 0.45)) { this.idleT = 0; const bb = m.bb, [wx, wy] = this.tw(rnd(bb.x0 + 8, bb.x1 - 8), rnd(bb.y0 + 8, bb.y1 - 8)); this.P({ type: 'star', x: wx, y: wy, vx: 0, vy: -10, s: rnd(5, 10), c: this.tier === 4 ? pick(RB) : '#fff6c0', life: rnd(0.5, 0.8), g: 0, bounce: -1 }); }
    for (let i = this.spr.length - 1; i >= 0; i--) {
      const s = this.spr[i], M = s.M; s.t += dt;
      s.vy += (M.flutter ? 1050 : 1500) * dt; if (M.flutter) { s.vx += Math.sin(s.t * 5 + s.seed) * 110 * M.flutter * dt; s.vx *= Math.exp(-1.1 * dt); s.vy *= Math.exp(-0.9 * M.flutter * dt); }
      s.x += s.vx * dt; s.y += s.vy * dt; s.r += s.vr * dt; s.fp += s.vf * dt;
      const fl = Math.abs(Math.cos(s.fp)), hw = s.w / 2 * Math.max(0.12, fl), hh = s.h / 2, e = Math.abs(hw * Math.sin(s.r)) + Math.abs(hh * Math.cos(s.r));
      if (s.y + e > s.gz) {
        s.y = s.gz - e;
        if (s.vy > 110) { if (s.vy > 260 && T - this.lastB > 0.07) { this.lastB = T; this.sfx('bounce', Math.min(1300, s.vy * 1.3), this.group, this.tier, M.sfx); } if (s.vy > 300) for (let k = 0; k < 2; k++) this.P({ type: 'dust', x: s.x + rnd(-hw, hw), y: s.gz - 2, vx: rnd(-80, 80), vy: -rnd(10, 40), s: rnd(10, 16), c: M.dust, a: 0.6, life: 0.6, g: -10, drag: 3 }); s.vy = -s.vy * M.rest; s.vx *= 0.55; s.vr *= 0.45; s.vf *= 0.5; }
        else { s.vy = 0; const f = Math.exp(-9 * dt); s.vx *= f; s.vr *= f; s.vf *= f; const base = s.h > s.w * fl ? Math.PI / 2 : 0, tr2 = base + Math.round((s.r - base) / Math.PI) * Math.PI; s.r += (tr2 - s.r) * Math.min(1, dt * 5); s.fp += (Math.round(s.fp / Math.PI) * Math.PI - s.fp) * Math.min(1, dt * 5); s.rest += dt; }
      }
      if (s.rest > 3.2 || s.y > 900 || Math.abs(s.x) > 900) this.spr.splice(i, 1);
    }
    for (let i = this.pt.length - 1; i >= 0; i--) {
      const p = this.pt[i]; p.t += dt; if (p.t >= p.life) { this.pt.splice(i, 1); continue; }
      if (p.type === 'ring' || p.type === 'iring' || p.type === 'gring') continue;
      if (p.type === 'mote') { const k = p.t / p.life, e2 = k * k; let x = p.sx + (p.tx - p.sx) * e2, y = p.sy + (p.ty - p.sy) * e2; if (p.sw) { const a = p.sw * e2, dx = x - p.tx, dy = y - p.ty, ca = Math.cos(a), sa = Math.sin(a); x = p.tx + dx * ca - dy * sa; y = p.ty + dx * sa + dy * ca; } p.x = x; p.y = y; continue; }
      p.vy += p.g * dt; if (p.drag) { const f = Math.exp(-p.drag * dt); p.vx *= f; p.vy *= f; }
      if (p.fl) p.vx += Math.sin(p.t * 7 + p.ph) * p.fl * dt;
      p.x += p.vx * dt; p.y += p.vy * dt; p.r += p.vr * dt;
      if (p.bounce >= 0 && p.y > p.gz && p.vy > 0) { p.y = p.gz; if (p.vy > 90) { p.vy *= -p.bounce; p.vx *= 0.6; p.vr *= 0.6; } else { p.vy = 0; const f = Math.exp(-12 * dt); p.vx *= f; p.vr *= f; } }
    }
  }
  renderLayer() {
    const L = this.lx, c = this.chest; if (!c) return; this._ls++; const m = c.m, M = m.M, k = this.k, T = this.time;
    L.setTransform(1, 0, 0, 1, 0, 0); L.clearRect(0, 0, this.layer.width, this.layer.height); L.setTransform(k, 0, 0, k, OX * k, OY * k);
    for (const p of m.parts) { if (c.torn[p.id]) { if (p.scar) p.scar.forEach(s => drawShape(L, s, c.W, T)); continue; } drawPart(L, p, c.W, T, c.ang[p.id] || 0); }
    L.save(); L.globalCompositeOperation = 'source-atop';
    c.dents.forEach(q => { c.W(q.x, q.y, _o); const X = _o[0], Y = _o[1], R = q.r * 1.15, a = M.dentShade * Math.min(1, q.k / 5);
      let g = L.createRadialGradient(X - R * 0.22, Y - R * 0.22, 0, X - R * 0.22, Y - R * 0.22, R); g.addColorStop(0, 'rgba(40,15,5,' + a.toFixed(3) + ')'); g.addColorStop(1, 'rgba(40,15,5,0)'); L.fillStyle = g; L.fillRect(X - R * 1.3, Y - R * 1.3, R * 2.6, R * 2.6);
      g = L.createRadialGradient(X + R * 0.34, Y + R * 0.34, 0, X + R * 0.34, Y + R * 0.34, R * 0.55); g.addColorStop(0, 'rgba(255,255,255,' + (a * 0.9).toFixed(3) + ')'); g.addColorStop(1, 'rgba(255,255,255,0)'); L.fillStyle = g; L.fillRect(X - R, Y - R, R * 2, R * 2); });
    const CS = CRACK[M.crack];
    c.cracks.forEach(cr => CS.forEach(([col, w, ox, oy, glow]) => { L.strokeStyle = col; L.lineWidth = w; L.lineJoin = 'round'; L.lineCap = 'round'; L.shadowColor = glow || 'transparent'; L.shadowBlur = glow ? 6 : 0;
      cr.forEach(pl => { L.beginPath(); pl.forEach(([x, y], i) => { c.W(x, y, _o); if (i) L.lineTo(_o[0] + ox, _o[1] + oy); else L.moveTo(_o[0] + ox, _o[1] + oy); }); L.stroke(); }); }));
    L.shadowBlur = 0;
    if (this.charge) { const C = this.charge; L.fillStyle = rgba(C.rb ? RB[Math.floor(T * 8) % 5] : C.c, Math.min(0.75, C.k * (0.3 + 0.1 * C.i))); L.fillRect(-OX, -OY, LW, LH); if (C.k > 0.7) { L.fillStyle = 'rgba(255,255,255,' + Math.min(0.85, (C.k - 0.7) * (1 + 0.45 * C.i)).toFixed(3) + ')'; L.fillRect(-OX, -OY, LW, LH); } }
    if (this.burst > 0.55) { L.fillStyle = 'rgba(255,255,255,' + ((this.burst - 0.55) * 1.9).toFixed(3) + ')'; L.fillRect(-OX, -OY, LW, LH); }
    if (this.flash > 0) { L.fillStyle = 'rgba(255,255,255,' + (this.flash * 0.55).toFixed(3) + ')'; L.fillRect(-OX, -OY, LW, LH); }
    L.restore();
    this._cav = c.holes.length > 0;
    if (c.holes.length) {
      const S = this.sx; S.setTransform(1, 0, 0, 1, 0, 0); S.globalCompositeOperation = 'source-over'; S.clearRect(0, 0, this.scr.width, this.scr.height); S.setTransform(k, 0, 0, k, OX * k, OY * k);
      S.fillStyle = '#000'; c.holes.forEach(h => { tracePts(S, h, c.W); S.fill(); });
      S.globalCompositeOperation = 'source-in'; S.setTransform(1, 0, 0, 1, 0, 0); S.drawImage(this.layer, 0, 0); S.setTransform(k, 0, 0, k, OX * k, OY * k);
      S.globalCompositeOperation = 'source-atop'; this.drawCavity(S, c, true); S.globalCompositeOperation = 'source-over';
      L.save(); L.globalCompositeOperation = 'destination-out'; L.fillStyle = '#000'; c.holes.forEach(h => { tracePts(L, h, c.W); L.fill(); });
      L.globalCompositeOperation = 'source-atop'; L.lineJoin = 'round';
      c.holes.forEach(h => { tracePts(L, h, c.W); L.strokeStyle = M.edge; L.lineWidth = M.edgeW; if (M.crack === 'glow') { L.shadowColor = '#ffffff'; L.shadowBlur = 8; } L.stroke(); L.shadowBlur = 0;
        if (M.jag === 'ragged') { L.setLineDash([2, 3]); L.lineWidth = 3; L.strokeStyle = 'rgba(120,70,20,0.7)'; L.stroke(); L.setLineDash([]); }
        if (M.jag === 'petal') { L.lineWidth = 9; L.strokeStyle = 'rgba(30,5,0,0.25)'; L.stroke(); } });
      L.restore();
    }
  }
  drawCavity(c, ch, noClip) {
    const m = ch.m, bb = m.bb, M = m.M; c.save(); if (!noClip) { trace(c, m.hullSp, ch.W); c.clip(); }
    let g = c.createLinearGradient(0, bb.y0, 0, bb.y1); g.addColorStop(0, M.cav[0]); g.addColorStop(1, M.cav[1]); c.fillStyle = g; c.fillRect(bb.x0 - 20, bb.y0 - 20, bb.x1 - bb.x0 + 40, bb.y1 - bb.y0 + 40);
    const gy = -m.H * 0.45; g = c.createRadialGradient(0, gy, 0, 0, gy, m.W * 0.62); g.addColorStop(0, rgba(M.glow, 0.95)); g.addColorStop(0.5, rgba(M.glow, 0.35)); g.addColorStop(1, rgba(M.glow, 0)); c.fillStyle = g; c.fillRect(bb.x0 - 20, bb.y0 - 20, bb.x1 - bb.x0 + 40, bb.y1 - bb.y0 + 40);
    m.peeks.forEach(pk => { c.save(); c.translate(pk.x, pk.y); c.rotate(pk.r); drawIcon(c, pk.k, pk.s, pk.c); c.restore(); });
    g = c.createLinearGradient(0, bb.y0, 0, bb.y0 + 40); g.addColorStop(0, 'rgba(0,0,0,0.5)'); g.addColorStop(1, 'rgba(0,0,0,0)'); c.fillStyle = g; c.fillRect(bb.x0 - 20, bb.y0 - 20, bb.x1 - bb.x0 + 40, 60);
    c.restore();
  }
  drawGlow(c) {
    const G = this.glow, m = this.chest && this.chest.m; if (!m || (G.k < 0.02 && G.rays < 0.02)) return;
    const cx = this.mo.x, cy = this.open ? -m.H * 0.4 : -m.H * 0.5 * this.mo.ps + this.lift, R = Math.max(m.W, m.H) * (0.8 + 0.55 * G.k), T = this.time;
    if (G.rays > 0.02) { c.save(); c.translate(cx, cy); c.rotate(T * 0.35); const N = 14, RR = R * 1.9; for (let i = 0; i < N; i++) { const col = G.rb ? RB[i % 5] : G.c, g = c.createRadialGradient(0, 0, 0, 0, 0, RR); g.addColorStop(0, rgba(col, 0.55 * G.rays)); g.addColorStop(1, rgba(col, 0)); c.fillStyle = g; c.beginPath(); c.moveTo(0, 0); c.arc(0, 0, RR, i / N * TAU, (i + 0.42) / N * TAU); c.closePath(); c.fill(); } c.restore(); }
    if (G.k > 0.02) { const g = c.createRadialGradient(cx, cy, 0, cx, cy, R), pulse = 1 + Math.sin(T * 4) * 0.04, a = Math.min(1, G.k) * pulse;
      g.addColorStop(0, 'rgba(255,255,255,' + (0.85 * a).toFixed(3) + ')'); if (G.rb) { g.addColorStop(0.3, rgba('#ff9fd6', 0.55 * a)); g.addColorStop(0.55, rgba('#9fd8ff', 0.3 * a)); } else g.addColorStop(0.35, rgba(G.c, 0.6 * a)); g.addColorStop(1, rgba(G.rb ? '#d6b3ff' : G.c, 0)); c.fillStyle = g; c.fillRect(cx - R, cy - R, R * 2, R * 2); }
  }
  draw() {
    const c = this.ctx, d = this.dpr; if (!d) return; c.setTransform(1, 0, 0, 1, 0, 0); c.clearRect(0, 0, this.cv.width, this.cv.height);
    const sh = this.shake, ox = sh > 0.3 ? rnd(-sh, sh) : 0, oy = sh > 0.3 ? rnd(-sh, sh) * 0.6 : 0;
    c.setTransform(d, 0, 0, d, 0, 0); this.drawStageFx(c); c.translate(this.gx + ox, this.gy + oy); c.scale(this.s, this.s);
    const ch = this.chest, m = ch && ch.m, mo = this.mo, T = this.time;
    this.drawGlow(c); this.drawUpFx(c, false);
    if (ch && !ch.gone) {
      const hop = clamp(1 + (mo.y + this.lift) / 260, 0.3, 1), rx = m.W * 0.55 * mo.ps * (1 + clamp(mo.q, -0.3, 0.4) * 0.4), g = c.createRadialGradient(mo.x, 2, 0, mo.x, 2, rx);
      g.addColorStop(0, 'rgba(42,10,40,' + (0.34 * hop).toFixed(3) + ')'); g.addColorStop(1, 'rgba(42,10,40,0)'); c.save(); c.translate(0, 2); c.scale(1, 0.14); c.translate(0, -2); c.fillStyle = g; c.beginPath(); c.arc(mo.x, 2, rx, 0, TAU); c.fill(); c.restore();
      this.renderLayer();
      c.save(); const C = this.charge, rum = C ? C.k : 0, ra = C ? 2 + 2 * C.i : 0, q = clamp(mo.q, -0.3, 0.4) + Math.sin(T * 2.4) * 0.008, pul = C ? 1 + C.k * (0.03 + 0.008 * C.i) * Math.max(0, Math.sin(T * (7 + 16 * C.k))) : 1;
      c.translate(mo.x + (rum ? rnd(-1, 1) * rum * ra : 0), mo.y + this.lift); c.rotate(mo.r + (rum ? rnd(-1, 1) * rum * 0.012 * ra : 0)); c.scale(mo.ps * (1 + q * 0.5) * pul, mo.ps * (1 - q) * pul);
      if (this._cav) c.drawImage(this.scr, -OX, -OY, LW, LH);
      c.drawImage(this.layer, -OX, -OY, LW, LH);
      c.restore();
    }
    this.drawUpFx(c, true);
    const spr = this.spr.slice().sort((a, b) => a.gz - b.gz);
    for (const s of spr) { const fl = Math.cos(s.fp), sc = Math.abs(fl) < 0.1 ? (fl < 0 ? -0.1 : 0.1) : fl, a = s.rest > 2.4 ? clamp(1 - (s.rest - 2.4) / 0.8, 0, 1) : 1; if (a <= 0) continue;
      c.save(); c.globalAlpha = a; c.translate(s.x, s.y); c.rotate(s.r); c.scale(sc, 1); c.drawImage(fl < 0 ? s.dk : s.img, -s.w / 2, -s.h / 2, s.w, s.h); c.restore(); }
    for (const p of this.pt) this.drawP(c, p);
    if (this.sflash > 0) { c.setTransform(d, 0, 0, d, 0, 0); c.fillStyle = rgba(this.sfc, Math.min(0.92, this.sflash * 0.85)); c.fillRect(0, 0, this.w, this.h); }
  }
  drawStageFx(c) {
    const m = this.chest && this.chest.m; if (!m || (this.dark < 0.01 && this.pillar < 0.01)) return;
    const s = this.s, X = this.gx + this.mo.x * s, Y = this.gy + (this.lift - m.H * 0.5) * s, T = this.time, ti = this.charge ? this.charge.i : (this.burst > 0 ? this.burstI : this.tier), rb = !!TIER[ti].rb, col = TIER[ti].fx;
    if (this.dark > 0.01) { const R = Math.hypot(this.w, this.h) * 0.75, g = c.createRadialGradient(X, Y, 0, X, Y, R), a = this.dark, base = rb ? '#16062c' : '#0b0618';
      g.addColorStop(0, rgba(base, a * 0.12)); g.addColorStop(0.16, rgba(base, a * 0.7)); g.addColorStop(1, rgba(base, a)); c.fillStyle = g; c.fillRect(0, 0, this.w, this.h); }
    if (this.pillar > 0.01) { const p = Math.min(1, this.pillar), cl = rb ? RB[Math.floor(T * 6) % 5] : col, w = m.W * s * (0.3 + 0.45 * p);
      c.save(); c.globalCompositeOperation = 'lighter';
      let g = c.createLinearGradient(X - w, 0, X + w, 0); g.addColorStop(0, rgba(cl, 0)); g.addColorStop(0.32, rgba(cl, 0.42 * p)); g.addColorStop(0.5, rgba('#ffffff', 0.85 * p)); g.addColorStop(0.68, rgba(cl, 0.42 * p)); g.addColorStop(1, rgba(cl, 0));
      c.fillStyle = g; c.fillRect(X - w, 0, w * 2, this.gy);
      const rx = m.W * s * (0.7 + 0.6 * p); g = c.createRadialGradient(X, this.gy, 0, X, this.gy, rx); g.addColorStop(0, rgba('#ffffff', 0.8 * p)); g.addColorStop(0.4, rgba(cl, 0.5 * p)); g.addColorStop(1, rgba(cl, 0));
      c.translate(X, this.gy); c.scale(1, 0.2); c.translate(-X, -this.gy); c.fillStyle = g; c.beginPath(); c.arc(X, this.gy, rx, 0, TAU); c.fill(); c.restore(); }
  }
  drawUpFx(c, front) {
    const m = this.chest && this.chest.m, C = this.charge, B = this.burst, T = this.time; if (!m || (!C && B < 0.01)) return;
    const cx = this.mo.x, cy = -m.H * 0.5 + this.lift, i = C ? C.i : this.burstI, rb = !!TIER[i].rb, col = TIER[i].fx, hue = RB[Math.floor(T * 8) % 5];
    const wedge = (L, a, w, cl, al) => { const g = c.createRadialGradient(cx, cy, 0, cx, cy, L); g.addColorStop(0, rgba('#ffffff', al)); g.addColorStop(0.32, rgba(cl, 0.7 * al)); g.addColorStop(1, rgba(cl, 0)); c.fillStyle = g; c.beginPath(); c.moveTo(cx, cy); c.arc(cx, cy, L, a - w, a + w); c.closePath(); c.fill(); };
    const orbit = half => { if (!C || i < 3) return; const n = rb ? 3 : 1, k = Math.min(1, C.k * 1.4);
      for (let j = 0; j < n; j++) { const tl = (j - (n - 1) / 2) * 0.55, rx = m.W * (0.72 + 0.08 * j), ry = m.W * 0.2, sp = T * (2.4 + j * 0.7) * (j % 2 ? -1 : 1), N = 36;
        for (let q = 0; q < N; q++) { const a0 = q / N * TAU, a1 = (q + 1.15) / N * TAU, am = (a0 + a1) / 2; if ((Math.sin(am) > 0) !== half) continue;
          const P = a => { const x = Math.cos(a + sp) * rx, y = Math.sin(a) * ry; return [cx + x * Math.cos(tl) - y * Math.sin(tl), cy + x * Math.sin(tl) + y * Math.cos(tl)]; }, p0 = P(a0), p1 = P(a1);
          c.strokeStyle = rgba(rb ? RB[(q + Math.floor(T * 10)) % 5] : (q % 2 ? '#ffd23a' : '#fff6c0'), 0.85 * k); c.lineWidth = 4 + 2 * Math.sin(am); c.lineCap = 'round'; c.beginPath(); c.moveTo(p0[0], p0[1]); c.lineTo(p1[0], p1[1]); c.stroke(); } } };
    c.save(); c.globalCompositeOperation = 'lighter';
    if (!front) {
      if (C) { const k = C.k;
        C.beams.forEach((b, j) => { if (k < b.at) return; const e = Math.min(1, (k - b.at) / 0.15); wedge(m.W * (0.8 + 1.7 * k) * b.l * (0.85 + 0.15 * Math.sin(T * 30 + b.f)), b.a + T * (0.2 + 0.3 * k), b.w * (0.6 + k), rb ? RB[j % 5] : col, 0.85 * e); });
        const R = m.W * (0.3 + 0.55 * k), g = c.createRadialGradient(cx, cy, 0, cx, cy, R); g.addColorStop(0, rgba('#ffffff', 0.8 * k)); g.addColorStop(0.5, rgba(rb ? hue : col, 0.5 * k)); g.addColorStop(1, rgba(col, 0)); c.fillStyle = g; c.fillRect(cx - R, cy - R, R * 2, R * 2);
        orbit(false); }
      if (B > 0.01) { const N = 16 + 6 * i, L = m.W * (1.5 + 2.4 * (1 - B)), rot = T * 0.4;
        for (let j = 0; j < N; j++) wedge(L * (j % 3 ? 1 : 1.35), rot + j / N * TAU, j % 2 ? 0.035 : 0.075, rb ? RB[j % 5] : (j % 2 ? col : '#ffffff'), B);
        const R = m.W * (0.6 + 1.3 * (1 - B)), g = c.createRadialGradient(cx, cy, 0, cx, cy, R); g.addColorStop(0, rgba('#ffffff', B)); g.addColorStop(0.45, rgba(rb ? hue : col, 0.6 * B)); g.addColorStop(1, rgba(col, 0)); c.fillStyle = g; c.fillRect(cx - R, cy - R, R * 2, R * 2); }
    } else {
      orbit(true);
      const f = C ? Math.max(0, (C.k - 0.55) / 0.45) * (0.5 + 0.12 * i) : B * B;
      if (f > 0.01) { const w = m.W * (1 + 1.9 * f), h = 3 + 7 * f, cl = rb ? hue : col; let g = c.createLinearGradient(cx - w, 0, cx + w, 0); g.addColorStop(0, rgba(cl, 0)); g.addColorStop(0.5, rgba('#ffffff', Math.min(1, 0.9 * f))); g.addColorStop(1, rgba(cl, 0)); c.fillStyle = g; c.fillRect(cx - w, cy - h / 2, w * 2, h);
        const vh = w * 0.45; g = c.createLinearGradient(0, cy - vh, 0, cy + vh); g.addColorStop(0, rgba(cl, 0)); g.addColorStop(0.5, rgba('#ffffff', Math.min(1, 0.7 * f))); g.addColorStop(1, rgba(cl, 0)); c.fillStyle = g; c.fillRect(cx - h * 0.35, cy - vh, h * 0.7, vh * 2); }
    }
    c.restore();
  }
  drawP(c, p) {
    const k = p.t / p.life, fade = p.life - p.t < 0.4 ? (p.life - p.t) / 0.4 : 1;
    if (p.type === 'dust') { const s = p.s * (1 + k * 1.4), a = p.a * Math.pow(1 - k, 1.6), g = c.createRadialGradient(p.x - s * 0.2, p.y - s * 0.25, 0, p.x, p.y, s); g.addColorStop(0, rgba('#ffffff', a)); g.addColorStop(0.45, rgba(p.c, a * 0.85)); g.addColorStop(1, rgba(p.c, 0)); c.fillStyle = g; c.beginPath(); c.arc(p.x, p.y, s, 0, TAU); c.fill(); return; }
    if (p.type === 'ring' || p.type === 'gring') { const r = p.r0 + (p.r1 - p.r0) * (1 - Math.pow(1 - k, 2.4)); c.save(); if (p.lw) c.globalCompositeOperation = 'lighter'; c.strokeStyle = rgba(p.c, (1 - k) * 0.95); c.lineWidth = (p.lw || 6) * (1 - k) + 1; c.translate(p.x, p.y); if (p.type === 'gring') c.scale(1, 0.22); c.beginPath(); c.arc(0, 0, r, 0, TAU); c.stroke(); c.restore(); return; }
    if (p.type === 'iring') { const r = p.r0 + (p.r1 - p.r0) * k * k; c.save(); c.globalCompositeOperation = 'lighter'; c.strokeStyle = rgba(p.c, Math.min(1, k * 2.5) * 0.85); c.lineWidth = p.lw * (0.4 + k); c.beginPath(); c.arc(p.x, p.y, r, 0, TAU); c.stroke(); c.restore(); return; }
    if (p.type === 'mote' || p.type === 'star' || p.type === 'spark') {
      c.save(); c.globalCompositeOperation = 'lighter';
      if (p.type === 'spark') { c.strokeStyle = rgba(p.c, 1 - k); c.lineWidth = 2.2; c.lineCap = 'round'; c.beginPath(); c.moveTo(p.x, p.y); c.lineTo(p.x - p.vx * 0.03, p.y - p.vy * 0.03); c.stroke(); }
      else if (p.type === 'mote') { const g = c.createRadialGradient(p.x, p.y, 0, p.x, p.y, p.s); g.addColorStop(0, 'rgba(255,255,255,0.95)'); g.addColorStop(0.4, rgba(p.c, 0.8)); g.addColorStop(1, rgba(p.c, 0)); c.fillStyle = g; c.beginPath(); c.arc(p.x, p.y, p.s, 0, TAU); c.fill(); }
      else { const s = p.s * Math.sin(Math.PI * Math.min(1, k * 1.1 + 0.05)); c.fillStyle = rgba(p.c, 0.95); c.translate(p.x, p.y); c.rotate(p.t * 3); c.beginPath(); c.moveTo(0, -s); c.lineTo(s * 0.22, -s * 0.22); c.lineTo(s, 0); c.lineTo(s * 0.22, s * 0.22); c.lineTo(0, s); c.lineTo(-s * 0.22, s * 0.22); c.lineTo(-s, 0); c.lineTo(-s * 0.22, -s * 0.22); c.closePath(); c.fill(); }
      c.restore(); return;
    }
    c.save(); c.globalAlpha = fade; c.translate(p.x, p.y); c.rotate(p.r);
    if (p.type === 'chip') { c.beginPath(); p.v.forEach(([x, y], i) => i ? c.lineTo(x, y) : c.moveTo(x, y)); c.closePath(); c.fillStyle = p.c; c.fill(); c.strokeStyle = 'rgba(40,15,5,0.35)'; c.lineWidth = 1; c.stroke(); }
    else if (p.type === 'shred') { c.scale(Math.cos(p.t * p.vf) || 0.1, 1); c.fillStyle = p.c; c.beginPath(); c.moveTo(-p.w / 2, -p.h / 2); c.lineTo(p.w / 2, -p.h / 2 + 1.5); c.lineTo(p.w / 2 - 1, p.h / 2); c.lineTo(-p.w / 2 + 1.5, p.h / 2 - 1); c.closePath(); c.fill(); c.strokeStyle = 'rgba(90,50,15,0.3)'; c.lineWidth = 0.8; c.stroke(); }
    else if (p.type === 'splinter') { c.fillStyle = p.c; c.beginPath(); c.moveTo(-p.w / 2, 0); c.lineTo(-p.w / 4, -p.h / 2); c.lineTo(p.w / 2, -p.h / 4); c.lineTo(p.w / 3, p.h / 2); c.closePath(); c.fill(); c.strokeStyle = 'rgba(70,30,5,0.5)'; c.lineWidth = 0.8; c.stroke(); }
    else if (p.type === 'bolt') { const g = c.createRadialGradient(-p.s * 0.3, -p.s * 0.3, 0, 0, 0, p.s); g.addColorStop(0, '#ffffff'); g.addColorStop(0.5, '#c9d3e0'); g.addColorStop(1, '#5f6b80'); c.fillStyle = g; c.beginPath(); c.arc(0, 0, p.s, 0, TAU); c.fill(); }
    else if (p.type === 'gem') { const s = p.s; c.fillStyle = p.c; c.beginPath(); c.moveTo(0, -s); c.lineTo(s * 0.8, s * 0.6); c.lineTo(-s * 0.7, s * 0.7); c.closePath(); c.fill(); c.strokeStyle = 'rgba(255,255,255,0.9)'; c.lineWidth = 1.2; c.beginPath(); c.moveTo(0, -s); c.lineTo(-s * 0.7, s * 0.7); c.stroke(); }
    else if (p.type === 'loot') { drawIcon(c, p.k, p.s, p.c); }
    else if (p.type === 'drop') { c.rotate(Math.atan2(p.vy, p.vx) - p.r + Math.PI / 2); const s = p.s; c.beginPath(); c.moveTo(0, s * 1.6); c.bezierCurveTo(s * 0.6, s * 0.6, s, 0, s, -s * 0.2); c.arc(0, -s * 0.2, s, 0, Math.PI, true); c.bezierCurveTo(-s, 0, -s * 0.6, s * 0.6, 0, s * 1.6); c.fillStyle = p.c; c.fill(); c.fillStyle = 'rgba(255,255,255,0.6)'; c.beginPath(); c.arc(-s * 0.35, -s * 0.35, s * 0.3, 0, TAU); c.fill(); }
    else if (p.type === 'bubble') { c.rotate(-p.r); c.strokeStyle = 'rgba(255,255,255,0.9)'; c.lineWidth = 1.4; c.beginPath(); c.arc(0, 0, p.s, 0, TAU); c.stroke(); c.fillStyle = 'rgba(190,240,255,0.25)'; c.fill(); c.fillStyle = 'rgba(255,255,255,0.9)'; c.beginPath(); c.arc(-p.s * 0.35, -p.s * 0.35, p.s * 0.25, 0, TAU); c.fill(); }
    else if (p.type === 'fluff') { c.fillStyle = p.c; [[0, 0, 1], [p.s * 0.6, -p.s * 0.2, 0.7], [-p.s * 0.5, p.s * 0.3, 0.65]].forEach(([x, y, k]) => { c.beginPath(); c.arc(x, y, p.s * k, 0, TAU); c.fill(); }); c.fillStyle = 'rgba(255,255,255,0.5)'; c.beginPath(); c.arc(-p.s * 0.3, -p.s * 0.3, p.s * 0.35, 0, TAU); c.fill(); }
    c.restore();
  }
}

/* ---------------- lineup ---------------- */
class Lineup {
  constructor(cv, group, o) {
    this.cv = cv; this.ctx = cv.getContext('2d'); this.group = group; this.o = o || {}; this.sel = 0; this.hover = -1; this.slots = [];
    this.ms = [0, 1, 2, 3, 4].map(i => model(group, i));
    this.resize(); this.ro = new ResizeObserver(() => this.resize()); this.ro.observe(cv);
    this.onClick = e => { const i = this.slotAt(e); if (i >= 0 && this.o.onPick) this.o.onPick(i); };
    this.onMove = e => { this.hover = this.slotAt(e); };
    this.onLeave = () => { this.hover = -1; };
    cv.addEventListener('click', this.onClick); cv.addEventListener('pointermove', this.onMove); cv.addEventListener('pointerleave', this.onLeave);
    this.vis = true; if (window.IntersectionObserver) { this.io = new IntersectionObserver(es => { this.vis = es[es.length - 1].isIntersecting; }); this.io.observe(cv); }
    const loop = t => { this.raf = requestAnimationFrame(loop); if (this.vis) this.draw(t / 1000); }; this.raf = requestAnimationFrame(loop);
  }
  destroy() { cancelAnimationFrame(this.raf); this.ro.disconnect(); if (this.io) this.io.disconnect(); this.cv.removeEventListener('click', this.onClick); this.cv.removeEventListener('pointermove', this.onMove); this.cv.removeEventListener('pointerleave', this.onLeave); }
  setGroup(g) { this.group = g; this.ms = [0, 1, 2, 3, 4].map(i => model(g, i)); this.cache = null; }
  isAnim(m) { if (m._anim == null) { const sp = f => !!(f && typeof f === 'object' && f.k && f.spin); m._anim = m.parts.some(p => p.sh.some(s => sp(s.f) || sp(s.s))); } return m._anim; }
  chestImg(i, m, ox, s, cxs, base) {
    const d = this.dpr, key = this.w + 'x' + this.h + 'x' + d; if (!this.cache || this.cache.key !== key) this.cache = { key, c: [] };
    let e = this.cache.c[i]; if (e) return e;
    const pad = 40, x0 = Math.floor((ox - pad) * d) / d, w = (m.bb.x1 - m.bb.x0) * s + pad * 2 + 60, cv = document.createElement('canvas'); cv.width = Math.ceil(w * d); cv.height = Math.ceil(this.h * d);
    const g = cv.getContext('2d'); g.setTransform(d, 0, 0, d, -x0 * d, 0); g.translate(cxs, base); g.scale(s, s); this.drawChest(g, m, 0);
    e = this.cache.c[i] = { cv, x0 }; return e;
  }
  drawChest(c, m, T) {
    c.save(); c.scale(1, 0.14); const g = c.createRadialGradient(0, 14, 0, 0, 14, m.W * 0.55); g.addColorStop(0, 'rgba(42,10,40,0.3)'); g.addColorStop(1, 'rgba(42,10,40,0)'); c.fillStyle = g; c.beginPath(); c.arc(0, 14, m.W * 0.55, 0, TAU); c.fill(); c.restore();
    for (const p of m.parts) drawPart(c, p, IDW, T, 0);
  }
  slotAt(e) { const r = this.cv.getBoundingClientRect(), x = e.clientX - r.left; return this.slots.findIndex(s => x >= s.x0 && x <= s.x1); }
  resize() { const r = this.cv.getBoundingClientRect(), dpr = Math.min(2, window.devicePixelRatio || 1); if (!r.width) return; this.w = r.width; this.h = r.height; this.dpr = dpr; this.cv.width = Math.round(r.width * dpr); this.cv.height = Math.round(r.height * dpr); this.cache = null; }
  draw(T) {
    const c = this.ctx, d = this.dpr; if (!d) return; c.setTransform(1, 0, 0, 1, 0, 0); c.clearRect(0, 0, this.cv.width, this.cv.height); c.setTransform(d, 0, 0, d, 0, 0);
    const gap = 30, tot = this.ms.reduce((a, m) => a + (m.bb.x1 - m.bb.x0), 0) + gap * 4, labH = 56, base = this.h - labH, maxH = 236;
    const s = Math.min((base - 14) / maxH, (this.w - 24) / tot); let cur = (this.w - tot * s) / 2; this.slots = [];
    this.ms.forEach((m, i) => {
      const bw = (m.bb.x1 - m.bb.x0) * s, cx = cur + bw / 2, x0 = cur - gap * s / 2, x1 = cur + bw + gap * s / 2; this.slots.push({ x0, x1 });
      if (i === this.sel || i === this.hover) { c.fillStyle = i === this.sel ? 'rgba(255,255,255,0.75)' : 'rgba(255,255,255,0.4)'; rrPath(c, x0 + 3, 6, x1 - x0 - 6, this.h - 10, 18); c.fill(); }
      const cxs = cx - (m.bb.x0 + m.bb.x1) / 2 * s;
      c.save(); c.translate(cxs, base); c.scale(s, s);
      if (i >= 3) { const R = Math.max(m.W, m.H) * 0.75, cy = -m.H * 0.5, g = c.createRadialGradient(0, cy, 0, 0, cy, R), a = 0.5 + Math.sin(T * 3 + i) * 0.08; g.addColorStop(0, 'rgba(255,255,255,' + a.toFixed(3) + ')'); g.addColorStop(0.4, rgba(i === 4 ? '#ff9fd6' : '#ffd84a', a * 0.7)); g.addColorStop(1, rgba(i === 4 ? '#9fd8ff' : '#ffd84a', 0)); c.fillStyle = g; c.fillRect(-R, cy - R, R * 2, R * 2); }
      if (this.isAnim(m)) { this.drawChest(c, m, T); c.restore(); }
      else { c.restore(); const e = this.chestImg(i, m, cur, s, cxs, base); c.drawImage(e.cv, e.x0, 0, e.cv.width / d, e.cv.height / d); }
      const t = TIER[i]; c.textAlign = 'center'; c.textBaseline = 'alphabetic';
      c.font = '900 11px Nunito, sans-serif'; c.fillStyle = t.c; c.fillText(t.n.toUpperCase(), cx, base + 22);
      c.font = '600 14px Fredoka, Nunito, sans-serif'; c.fillStyle = '#45107a'; const w = x1 - x0 - 8;
      if (c.measureText(m.name).width <= w) c.fillText(m.name, cx, base + 40);
      else { const ws = m.name.split(' '), h = Math.ceil(ws.length / 2); c.fillText(ws.slice(0, h).join(' '), cx, base + 39); c.fillText(ws.slice(h).join(' '), cx, base + 54); }
      cur += bw + gap * s;
    });
  }
}

const API = window.ChestModels = { TIER, MAT, model, Stage, Lineup, groups: Object.keys(MODELS), _drawPart: drawPart, register, ICONS, CRACK,
  H: { parse, P_, poly, line, rect, ell, shift, rot, mxp, myp, spark4, star5, lg, rg, cg, sh, st, tx, nail, chrome, gold, KX, KY, P3, mapD, mp, mlg, onF, onP, FR, mixC, Box, cvx, boxFill, boxShade, corner3, plankS, surf, Barrel, PL, litC, RB, rnd, VV, LV } };
})();
