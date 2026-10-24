// Squish Squad Rive-style rig: bones + mesh warp + 2.5D head sphere + layered state machine with blended transitions.
// RiveRig.mount(host, 'mittens', { onState }) -> { play(name), destroy(), state }
(function () {
  if (window.RiveRig) return;
  // Plush fabric grain. Was a live feTurbulence (CPU noise regenerated every frame = big FPS drop); now a pre-baked seamless noise tile, same look.
  let FAB = null;
  function fabricFx() {
    if (FAB === null) { FAB = '';
      try { const S = 128, cv = document.createElement('canvas'); cv.width = cv.height = S; const x = cv.getContext('2d'), im = x.createImageData(S, S);
        let sd = 7; const rnd = () => (sd = (sd * 16807) % 2147483647) / 2147483647;
        const oct = n => { const g = []; for (let i = 0; i < n * n; i++) g.push(rnd()); const c = S / n, sm = t => t * t * (3 - 2 * t);
          return (px, py) => { const gx = px / c, gy = py / c, x0 = Math.floor(gx), y0 = Math.floor(gy), fx = sm(gx - x0), fy = sm(gy - y0), a = (i, j) => g[((j % n + n) % n) * n + ((i % n + n) % n)];
            const t = a(x0, y0) + (a(x0 + 1, y0) - a(x0, y0)) * fx, b = a(x0, y0 + 1) + (a(x0 + 1, y0 + 1) - a(x0, y0 + 1)) * fx; return t + (b - t) * fy; }; };
        const o1 = oct(32), o2 = oct(64);
        for (let y = 0; y < S; y++) for (let X = 0; X < S; X++) { const v = (o1(X, y) + o2(X, y)) / 2, k = (y * S + X) * 4; im.data[k + 3] = Math.round(0.2 * 255 * v); }
        x.putImageData(im, 0, 0); const B = 1024, cb = document.createElement('canvas'); cb.width = cb.height = B; const xb = cb.getContext('2d'); xb.fillStyle = xb.createPattern(cv, 'repeat'); xb.fillRect(0, 0, B, B); FAB = cb.toDataURL('image/png'); } catch (e) { FAB = ''; } }
    return FAB ? '<feImage href="' + FAB + '" x="-30" y="-30" width="160" height="160" preserveAspectRatio="none"/>' : '<feFlood flood-opacity="0"/>';
  }
  const NS = 'http://www.w3.org/2000/svg', D2R = Math.PI / 180, TAU = Math.PI * 2;
  const clamp = (v, a, b) => Math.max(a, Math.min(b, v)), r2 = n => Math.round(n * 100) / 100, lerp = (a, b, t) => a + (b - a) * t;
  const SM = x => { x = clamp(x, 0, 1); return x * x * (3 - 2 * x); };
  const bez = (x1, y1, x2, y2) => { const cx = 3 * x1, bx = 3 * (x2 - x1) - cx, ax = 1 - cx - bx, cy = 3 * y1, by = 3 * (y2 - y1) - cy, ay = 1 - cy - by;
    const X = t => ((ax * t + bx) * t + cx) * t, dX = t => (3 * ax * t + 2 * bx) * t + cx, Y = t => ((ay * t + by) * t + cy) * t;
    return x => { if (x <= 0) return 0; if (x >= 1) return 1; let t = x; for (let i = 0; i < 8; i++) { const d = dX(t); if (Math.abs(d) < 1e-5) break; t = clamp(t - (X(t) - x) / d, 0, 1); } return Y(t); }; };
  const EZ = { l: x => x, io: bez(0.45, 0, 0.55, 1), s: bez(0.37, 0, 0.63, 1), o: x => 1 - Math.pow(1 - x, 2.4), i: x => Math.pow(x, 2.2), bk: bez(0.34, 1.45, 0.64, 1) };
  const kv = (K, t) => { if (t <= K[0][0]) return K[0][1]; for (let i = 1; i < K.length; i++) { const b = K[i]; if (t <= b[0]) { const a = K[i - 1]; return a[1] + (b[1] - a[1]) * EZ[b[2] || 'io']((t - a[0]) / Math.max(1, b[0] - a[0])); } } return K[K.length - 1][1]; };
  class Fol { constructor(v, w, z) { this.v = v || 0; this.d = 0; this.w = w; this.z = z == null ? 1 : z; }
    step(t, dt) { const n = Math.max(1, Math.ceil(dt / 0.006)), h = dt / n; for (let i = 0; i < n; i++) { this.d += (this.w * this.w * (t - this.v) - 2 * this.z * this.w * this.d) * h; this.v += this.d * h; } return this.v; } }

  function parsePath(d) {
    const tk = d.match(/[a-zA-Z]|-?\d*\.?\d+(?:e-?\d+)?/g) || []; let i = 0, cmd = '', x = 0, y = 0, sx = 0, sy = 0; const out = []; const n = () => +tk[i++];
    while (i < tk.length) {
      if (/[a-zA-Z]/.test(tk[i])) cmd = tk[i++];
      const C = cmd.toUpperCase(), rel = cmd !== C, ox = rel ? x : 0, oy = rel ? y : 0;
      if (C === 'Z') { out.push({ c: 'Z' }); x = sx; y = sy; continue; }
      if (C === 'M' || C === 'L') { const p = [ox + n(), oy + n()]; out.push({ c: C, p: [p] }); [x, y] = p; if (C === 'M') { sx = x; sy = y; cmd = rel ? 'l' : 'L'; } }
      else if (C === 'Q') { const a = [ox + n(), oy + n()], b = [ox + n(), oy + n()]; out.push({ c: 'Q', p: [a, b] }); [x, y] = b; }
      else if (C === 'C') { const a = [ox + n(), oy + n()], b = [ox + n(), oy + n()], c = [ox + n(), oy + n()]; out.push({ c: 'C', p: [a, b, c] }); [x, y] = c; }
      else i++;
    }
    return out;
  }
  const ellS = (cx, cy, rx, ry, rot, n) => { n = n || 8; const k = 4 / 3 * Math.tan(Math.PI / (2 * n)), c = Math.cos((rot || 0) * D2R), s = Math.sin((rot || 0) * D2R);
    const P = (x, y) => [cx + x * c - y * s, cy + x * s + y * c]; const out = [{ c: 'M', p: [P(rx, 0)] }];
    for (let i = 0; i < n; i++) { const a0 = i / n * TAU, a1 = (i + 1) / n * TAU, c0 = Math.cos(a0), s0 = Math.sin(a0), c1 = Math.cos(a1), s1 = Math.sin(a1);
      out.push({ c: 'C', p: [P(rx * (c0 - k * s0), ry * (s0 + k * c0)), P(rx * (c1 + k * s1), ry * (s1 - k * c1)), P(rx * c1, ry * s1)] }); }
    out.push({ c: 'Z' }); return out; };
  const toD = (segs, F) => { let s = ''; for (const g of segs) { if (g.c === 'Z') { s += 'Z'; continue; } s += g.c; for (const p of g.p) { const q = F(p[0], p[1]); s += r2(q[0]) + ' ' + r2(q[1]) + ' '; } } return s; };
  const smoothD = P => { let s = 'M' + r2(P[0][0]) + ' ' + r2(P[0][1]);
    for (let i = 0; i < P.length - 1; i++) { const p0 = P[i - 1] || P[i], p1 = P[i], p2 = P[i + 1], p3 = P[i + 2] || p2;
      s += ' C' + r2(p1[0] + (p2[0] - p0[0]) / 6) + ' ' + r2(p1[1] + (p2[1] - p0[1]) / 6) + ' ' + r2(p2[0] - (p3[0] - p1[0]) / 6) + ' ' + r2(p2[1] - (p3[1] - p1[1]) / 6) + ' ' + r2(p2[0]) + ' ' + r2(p2[1]); }
    return s; };
  // volume helpers: outline -> polygon, convex hull silhouette, ellipsoid -> projected ellipse
  const flat = (segs, n) => { const out = []; let p = null; for (const g of segs) { if (g.c === 'M' || g.c === 'L') { p = g.p[0]; out.push(p); }
      else if (g.c === 'Q') { const [a, b] = g.p; for (let i = 1; i <= n; i++) { const t = i / n, m = 1 - t; out.push([m * m * p[0] + 2 * m * t * a[0] + t * t * b[0], m * m * p[1] + 2 * m * t * a[1] + t * t * b[1]]); } p = b; }
      else if (g.c === 'C') { const [a, b, c] = g.p; for (let i = 1; i <= n; i++) { const t = i / n, m = 1 - t; out.push([m * m * m * p[0] + 3 * m * m * t * a[0] + 3 * m * t * t * b[0] + t * t * t * c[0], m * m * m * p[1] + 3 * m * m * t * a[1] + 3 * m * t * t * b[1] + t * t * t * c[1]]); } p = c; } } return out; };
  const hull = P => { P = P.slice().sort((a, b) => a[0] - b[0] || a[1] - b[1]); const cr = (o, a, b) => (a[0] - o[0]) * (b[1] - o[1]) - (a[1] - o[1]) * (b[0] - o[0]), lo = [], up = [];
    for (const p of P) { while (lo.length >= 2 && cr(lo[lo.length - 2], lo[lo.length - 1], p) <= 0) lo.pop(); lo.push(p); }
    for (let i = P.length - 1; i >= 0; i--) { const p = P[i]; while (up.length >= 2 && cr(up[up.length - 2], up[up.length - 1], p) <= 0) up.pop(); up.push(p); }
    up.pop(); lo.pop(); return lo.concat(up); };
  const closedD = P => { const n = P.length; if (n < 3) return ''; let s = 'M' + r2(P[0][0]) + ' ' + r2(P[0][1]);
    for (let i = 0; i < n; i++) { const p0 = P[(i - 1 + n) % n], p1 = P[i], p2 = P[(i + 1) % n], p3 = P[(i + 2) % n];
      s += ' C' + r2(p1[0] + (p2[0] - p0[0]) / 6) + ' ' + r2(p1[1] + (p2[1] - p0[1]) / 6) + ' ' + r2(p2[0] - (p3[0] - p1[0]) / 6) + ' ' + r2(p2[1] - (p3[1] - p1[1]) / 6) + ' ' + r2(p2[0]) + ' ' + r2(p2[1]); } return s + 'Z'; };
  const ellAx = (cx, cy, A) => { let a = 0, b = 0, c = 0; for (const v of A) { a += v[0] * v[0]; b += v[0] * v[1]; c += v[1] * v[1]; } const tr = (a + c) / 2, df = Math.sqrt(Math.max(0, (a - c) * (a - c) / 4 + b * b));
    return ellS(cx, cy, Math.sqrt(tr + df), Math.sqrt(Math.max(0.01, tr - df)), 0.5 * Math.atan2(2 * b, a - c) / D2R, 8); };
  const earSec = (e, poly) => { const [px, py] = e.pivot, ux = e.ux, uy = e.uy, nx = -uy, ny = ux, A = poly.map(([x, y]) => [(x - px) * ux + (y - py) * uy, (x - px) * nx + (y - py) * ny]);
    const amax = Math.max(...A.map(a => a[0])), amin = Math.max(Math.min(...A.map(a => a[0])), -4), secs = [];
    for (let i = 0; i <= 13; i++) { const a = amin + (amax - amin - 0.5) * i / 13; let lo = 1e9, hi = -1e9;
      for (let j = 0; j < A.length; j++) { const p = A[j], q = A[(j + 1) % A.length]; if ((p[0] - a) * (q[0] - a) <= 0 && p[0] !== q[0]) { const t = p[1] + (q[1] - p[1]) * (a - p[0]) / (q[0] - p[0]); lo = Math.min(lo, t); hi = Math.max(hi, t); } }
      if (lo > hi) continue; const hw = Math.max(0.8, (hi - lo) / 2), tc = (hi + lo) / 2, s = clamp(a / amax, 0, 1); secs.push({ s, cx: px + a * ux + tc * nx, cy: py + a * uy + tc * ny, hw, hd: Math.max(0.8, hw * 0.55 * (0.3 + 0.7 * SM((s - 0.1) / 0.4))) }); }
    return { secs, amax, nx, ny }; };
  const mk = (tag, at, par) => { const e = document.createElementNS(NS, tag); for (const k in at) e.setAttribute(k, at[k]); if (par) par.appendChild(e); return e; };
  const star4 = (x, y, r) => 'M' + r2(x) + ' ' + r2(y - r) + ' Q' + r2(x) + ' ' + r2(y) + ' ' + r2(x + r) + ' ' + r2(y) + ' Q' + r2(x) + ' ' + r2(y) + ' ' + r2(x) + ' ' + r2(y + r) + ' Q' + r2(x) + ' ' + r2(y) + ' ' + r2(x - r) + ' ' + r2(y) + ' Q' + r2(x) + ' ' + r2(y) + ' ' + r2(x) + ' ' + r2(y - r) + 'Z';

  // ---------- Mittens: parts, pivots, depth ----------
  const DEFS = { mittens: {
    G: 95.5, top: 17, head: [50, 46, 29], neck: [50, 73],
    c: { tail: '#e59a58', pad: '#ffb8c6', inner: '#ffb3c1', muzzle: '#fff1e2', nose: '#e8798f', cheek: '#ff8fa3', mouth: '#6a3a3a', whisker: '#a86a3a', stripe: '#e08e48', arm: '#f0aa6a', g: ['#ffe4c0', '#f8b77a', '#d98a4a'] },
    body: [50, 78, 22, 13], feet: [[38, 90], [62, 90]],
    ears: [{ side: -1, pivot: [34, 30], tip: [26, 9], d: 'M22 36 Q20 8 30 10 Q38 14 46 24 Z', inner: 'M28 28 Q28 16 32 16 Q36 18 40 24 Z' }, { side: 1, pivot: [66, 30], tip: [74, 9], d: 'M78 36 Q80 8 70 10 Q62 14 54 24 Z', inner: 'M72 28 Q72 16 68 16 Q64 18 60 24 Z' }],
    arms: [{ side: -1, e: [32, 76, 6, 8, 20], pivot: [34.6, 68.6] }, { side: 1, e: [68, 76, 6, 8, -20], pivot: [65.4, 68.6] }],
    tail: [[52, 86], [74, 92], [92, 82], [88, 66]], eyes: [[38, 47], [62, 47]], eyeR: 5.2,
    whiskers: ['M36 55 Q27 52.5 18 52', 'M36 58 Q27 58.5 18 60', 'M64 55 Q73 52.5 82 52', 'M64 58 Q73 58.5 82 60'],
    stripes: 'M44 18 L45 24 M56 18 L55 24', back: 'M43 21 L44 28 M50 19 L50 27 M57 21 L56 28' } };

  DEFS.biscuit = {
    G: 95.5, top: 16, head: [50, 44, 28], neck: [50, 71],
    c: { tail: '#e8a45a', pad: '#7a4a2a', inner: '#c98a50', muzzle: '#fff1de', nose: '#2a1a30', cheek: '#ff8fa3', mouth: '#6a3a3a', whisker: 'none', stripe: '#fff1de', arm: '#efae62', g: ['#ffe2b8', '#f2b56c', '#d48a3e'], ge: ['#c98a50', '#a8693a', '#7c4724'], tailHL: '#ffe2b8' },
    body: [50, 77, 21, 14], belly: [50, 80, 12, 9, '#fff3e0'], bellyTurn: true, feet: [[38, 90], [62, 90]], pads: [[-4, 1, 1.6, 1.2], [0, 2, 1.6, 1.2], [4, 1, 1.6, 1.2]],
    ears: [{ side: -1, flop: true, lobe: [19, 42, 10.5, 18, 9, -2, 14], pivot: [27, 30], tip: [15, 58], d: 'M28 26 Q14 22 10 36 Q8 52 18 60 Q24 62 26 54 Q26 40 32 32Z' }, { side: 1, flop: true, lobe: [81, 42, 10.5, 18, 9, -2, -14], pivot: [73, 30], tip: [85, 58], d: 'M72 26 Q86 22 90 36 Q92 52 82 60 Q76 62 74 54 Q74 40 68 32Z' }],
    arms: [{ side: -1, e: [33, 77, 6, 8, 15], pivot: [35.1, 69.3] }, { side: 1, e: [67, 77, 6, 8, -15], pivot: [64.9, 69.3] }],
    tail: [[72, 78], [86, 77], [89, 65], [84, 57]], tailW: 6, tailRoot: [[62, 86], [67, 83]], eyes: [[38, 45], [62, 45]], eyeR: 5.2,
    muzzle: [50, 56, 15, 11], nose: [50, 53, 4.4, 3.2], noseHL: [48.6, 52, 1.4, 0.9], mouth: [50, 60, 4.5], cheeks: [[33, 55], [67, 55]],
    faceExtra: [{ d: 'M44 20 Q50 16 56 20 Q54 30 50 34 Q46 30 44 20Z', fill: '#fff1de', op: 0.9 }, { d: 'M50 56 L50 59', stroke: '#6a3a3a', sw: 1.2 }],
    whiskers: [], stripes: '', back: 'M44 22 Q50 18 56 22',
    collar: { d: 'M30 66 Q50 74 70 66 L70 70 Q50 78 30 70Z', fill: '#ff6f86' }, tag: { x: 50, y: 74, r: 3.4, fill: '#ffd84a' } };
  // ---------- state machine: keyframed timelines, blended on every transition ----------
  const REST = { x: 0, lift: 0, tilt: 0, sq: 0, lean: 0, spin: 0, turn: 0, pitch: 0, htilt: 0, armL: 0, armR: 0, earL: 0, earR: 0, wag: 0, curl: 0, footL: 0, footR: 0, lx: 0, ly: 0, close: 0, sl: 0, winkL: 0, winkR: 0, hap: 0, wide: 0, smile: 0, open: 0, mw: 1, frown: 0, blush: 0, hLx: 0, hLy: 0, hLz: 0, hRx: 0, hRy: 0, hRz: 0, puff: 0, tongue: 0, sqz: 0, cross: 0, teary: 0, red: 0, green: 0, sit: 0 };
  const AR = K => ({ armL: K, armR: K }), ER = K => ({ earL: K, earR: K });
  const STATES = {
    idle: { loop: 8400, look: true, k: {
      sq: [[0, 0], [2100, -0.025, 's'], [4200, 0.012, 's'], [6300, -0.025, 's'], [8400, 0, 's']],
      lean: [[0, 0], [2100, 0.9, 's'], [4200, 0, 's'], [6300, -0.9, 's'], [8400, 0, 's']],
      htilt: [[0, 0], [2100, 1.4, 's'], [4200, 0, 's'], [6300, -1.4, 's'], [8400, 0, 's']],
      wag: [[0, 0], [2100, 9, 's'], [4200, 0, 's'], [6300, -9, 's'], [8400, 0, 's']],
      earR: [[0, 0], [5200, 0], [5280, -9, 'o'], [5420, 4, 'io'], [5600, 0, 'io']] } },
    look: { dur: 6000, ev: [[1950, 'blink'], [4500, 'blink']], k: {
      lx: [[0, 0], [200, 0], [380, -1, 'o'], [1700, -1], [1880, 1, 'io'], [3200, 1], [3380, 0, 'io']],
      ly: [[0, 0], [3400, 0], [3580, -1, 'o'], [4400, -1], [4580, 0.8, 'io'], [5200, 0.8], [5400, 0, 'io']],
      turn: [[0, 0], [330, 0], [850, -0.97, 'io'], [1050, -0.9, 'io'], [1950, -0.9], [2550, 0.97, 'io'], [2750, 0.9, 'io'], [3300, 0.9], [3750, -0.05, 'io'], [3950, 0, 'io']],
      pitch: [[0, 0], [3450, 0], [3950, 0.7, 'io'], [4450, 0.7], [4950, -0.5, 'io'], [5250, -0.5], [5800, 0, 'io']],
      htilt: [[0, 0], [330, 0], [900, -4, 'io'], [1950, -4], [2600, 4, 'io'], [3300, 4], [3800, 0, 'io']],
      lean: [[0, 0], [350, 0], [950, -1.5, 'io'], [1950, -1.5], [2650, 1.5, 'io'], [3300, 1.5], [3800, 0, 'io']],
      sq: [[0, 0], [3450, 0], [3950, -0.04, 'io'], [4450, -0.04], [4950, 0.03, 'io'], [5250, 0.03], [5800, 0, 'io']],
      armL: [[0, 0], [330, 0], [850, 10, 'io'], [1950, 10], [2550, 0, 'io']], armR: [[0, 0], [1950, 0], [2550, 10, 'io'], [3300, 10], [3750, 0, 'io']],
      footL: [[0, 0], [350, 0], [550, 2.2, 'o'], [750, 0, 'io'], [2000, 0], [2200, 2.2, 'o'], [2400, 0, 'io'], [3350, 0], [3550, 1.6, 'o'], [3750, 0, 'io']],
      footR: [[0, 0], [500, 0], [700, 2.2, 'o'], [900, 0, 'io'], [2150, 0], [2350, 2.2, 'o'], [2550, 0, 'io'], [3500, 0], [3700, 1.6, 'o'], [3900, 0, 'io']] } },
    squish: { dur: 5400, loop: 1800, k: {
      sq: [[0, 0], [150, -0.05, 'o'], [480, 0.38, 'io'], [900, 0.4, 'l'], [1030, -0.18, 'o'], [1180, 0.08, 'io'], [1340, -0.03, 'io'], [1520, 0, 'io']],
      hap: [[0, 0], [330, 0], [450, 0.85, 'o'], [920, 0.85], [1040, 0, 'o']],
      smile: [[0, 0], [1000, 0], [1100, 1, 'o'], [1500, 1], [1800, 0, 'io']],
      open: [[0, 0], [1000, 0], [1080, 0.45, 'o'], [1400, 0, 'io']],
      lift: [[0, 0], [980, 0], [1110, 3.5, 'o'], [1240, 0, 'i']],
      ...AR([[0, 0], [480, 18, 'io'], [900, 20], [1050, -4, 'o'], [1300, 0, 'io']]),
      ...ER([[0, 0], [480, 12, 'io'], [900, 14], [1050, -6, 'o'], [1300, 0, 'io']]),
      blush: [[0, 0], [600, 0.6, 'io'], [1000, 0.6], [1500, 0, 'io']] } },
    spin: { dur: 5400, ev: [[1750, 'blink'], [4450, 'blink']], k: {
      spin: [[0, 0], [200, 0], [500, -25, 'io'], [1450, 375, 'io'], [1700, 360, 'io'], [2900, 360], [3200, 335, 'io'], [4150, 735, 'io'], [4400, 720, 'io']],
      turn: [[0, 0], [200, 0], [500, 0.3, 'io'], [900, -0.5, 'io'], [1450, 0.4, 'io'], [1800, 0, 'io'], [2900, 0], [3200, 0.3, 'io'], [3600, -0.5, 'io'], [4150, 0.4, 'io'], [4500, 0, 'io']],
      sq: [[0, 0], [200, 0], [500, 0.14, 'io'], [700, -0.1, 'o'], [1250, -0.04, 'io'], [1450, 0.14, 'o'], [1600, -0.04, 'io'], [1800, 0, 'io'], [2900, 0], [3200, 0.14, 'io'], [3400, -0.1, 'o'], [3950, -0.04, 'io'], [4150, 0.14, 'o'], [4300, -0.04, 'io'], [4500, 0, 'io']],
      lift: [[0, 0], [550, 0], [850, 4, 'o'], [1200, 4], [1450, 0, 'i'], [3250, 0], [3550, 4, 'o'], [3900, 4], [4150, 0, 'i']],
      ...AR([[0, 0], [500, -8, 'io'], [750, 35, 'o'], [1300, 35], [1500, 0, 'io'], [2900, 0], [3200, -8, 'io'], [3450, 35, 'o'], [4000, 35], [4200, 0, 'io']]),
      hap: [[0, 0], [700, 0.7, 'io'], [1700, 0.7], [2100, 0, 'io'], [2900, 0], [3400, 0.7, 'io'], [4400, 0.7], [4800, 0, 'io']],
      smile: [[0, 0], [700, 1, 'io'], [1700, 1], [2100, 0, 'io'], [2900, 0], [3400, 1, 'io'], [4400, 1], [4800, 0, 'io']] } },
    hop: { dur: 5700, loop: 1900, k: {
      sq: [[0, 0], [120, 0], [330, 0.24, 'io'], [410, -0.2, 'o'], [640, -0.03, 'io'], [780, -0.12, 'i'], [820, 0.3, 'o'], [960, -0.07, 'io'], [1100, 0.035, 'io'], [1260, 0, 'io']],
      lift: [[0, 0], [380, 0], [620, 18, 'o'], [820, 0, 'i']],
      ...AR([[0, 0], [330, -12, 'io'], [460, 38, 'o'], [700, 26, 'io'], [830, -8, 'o'], [1050, 0, 'io']]),
      ...ER([[0, 0], [330, -6, 'io'], [450, 10, 'o'], [650, 2, 'io'], [830, 12, 'o'], [1000, -3, 'io'], [1200, 0, 'io']]),
      ly: [[0, 0], [250, 0.4, 'io'], [450, -0.6, 'o'], [850, 0.2, 'io'], [1200, 0, 'io']],
      pitch: [[0, 0], [330, -0.2, 'io'], [500, 0.3, 'o'], [820, -0.2, 'io'], [1100, 0, 'io']],
      hap: [[0, 0], [300, 0.6, 'io'], [430, 0, 'io'], [800, 0], [840, 0.6, 'o'], [1100, 0, 'io']] } },
    happy: { dur: 7200, loop: 2400, k: {
      sq: [[0, 0], [200, 0.2, 'io'], [270, -0.16, 'o'], [480, -0.02, 'io'], [600, -0.1, 'i'], [640, 0.26, 'o'], [760, -0.04, 'io'], [860, 0.18, 'io'], [930, -0.16, 'o'], [1140, -0.02, 'io'], [1260, -0.1, 'i'], [1300, 0.26, 'o'], [1440, -0.06, 'io'], [1600, 0.03, 'io'], [1800, 0, 'io']],
      lift: [[0, 0], [240, 0], [440, 13, 'o'], [640, 0, 'i'], [900, 0], [1100, 13, 'o'], [1300, 0, 'i']],
      tilt: [[0, 0], [240, 0], [440, -7, 'io'], [700, 0, 'io'], [900, 0], [1100, 7, 'io'], [1360, 0, 'io']],
      htilt: [[0, 0], [440, -3, 'io'], [720, 4, 'io'], [900, 0, 'io'], [1100, 3, 'io'], [1380, -4, 'io'], [1600, 0, 'io']],
      ...AR([[0, 0], [200, -8, 'io'], [330, 48, 'o'], [640, 40], [700, 24, 'io'], [860, -6, 'io'], [990, 48, 'o'], [1300, 40], [1400, 24, 'io'], [1800, 0, 'io']]),
      wag: [[0, 0], [300, 16, 'io'], [600, -16, 'io'], [900, 16, 'io'], [1200, -16, 'io'], [1500, 16, 'io'], [1800, -16, 'io'], [2100, 10, 'io'], [2400, 0, 'io']],
      hap: [[0, 1]], smile: [[0, 1]], open: [[0, 0.5]], ly: [[0, -0.3]] } },
    surprised: { dur: 5200, ev: [[2400, 'blink2']], k: {
      sq: [[0, 0], [200, 0], [280, 0.16, 'o'], [380, -0.2, 'o'], [700, -0.12, 'io'], [900, 0.12, 'o'], [1050, -0.04, 'io'], [1200, 0, 'io'], [3700, 0], [3800, 0.1, 'o'], [3900, -0.15, 'o'], [4200, -0.05, 'io'], [4350, 0.08, 'o'], [4550, 0, 'io']],
      lift: [[0, 0], [300, 0], [560, 9, 'o'], [880, 0, 'i'], [3820, 0], [4020, 6, 'o'], [4300, 0, 'i']],
      x: [[0, 0], [300, 0], [880, -7, 'o'], [2500, -7], [3300, 0, 'io']],
      lean: [[0, 0], [300, 0], [500, -5, 'o'], [880, -2, 'io'], [1100, 1.5, 'io'], [1400, 0, 'io']],
      tilt: [[0, 0], [300, 0], [500, -7, 'o'], [900, -2, 'io'], [1300, 0, 'io']],
      wide: [[0, 0], [280, 0], [340, 1, 'o'], [2300, 1], [2700, 0.3, 'io'], [3700, 0.3], [3800, 1, 'o'], [4500, 1], [4900, 0, 'io']],
      open: [[0, 0], [280, 0], [360, 0.7, 'o'], [1900, 0.65], [2300, 0.15, 'io'], [3700, 0.1], [3800, 0.65, 'o'], [4500, 0.55], [4900, 0, 'io']],
      mw: [[0, 1], [280, 1], [360, 0.6, 'o'], [2300, 0.6], [2700, 1, 'io'], [3700, 1], [3800, 0.6, 'o'], [4500, 0.6], [4900, 1, 'io']],
      ...AR([[0, 0], [280, 0], [380, 34, 'o'], [1900, 30], [2400, 8, 'io'], [3700, 8], [3800, 34, 'o'], [4500, 30], [4900, 0, 'io']]),
      ...ER([[0, 0], [280, 0], [380, -12, 'o'], [1700, -10], [2100, 0, 'io'], [3700, 0], [3800, -10, 'o'], [4500, -8], [4900, 0, 'io']]),
      lx: [[0, 0], [2500, 0], [2650, -0.9, 'o'], [3000, -0.9], [3150, 0.9, 'io'], [3550, 0.9], [3700, 0, 'io']],
      turn: [[0, 0], [2550, 0], [2900, -0.35, 'io'], [3100, -0.35], [3450, 0.35, 'io'], [3600, 0.35], [3800, 0, 'io']],
      pitch: [[0, 0], [300, 0], [450, 0.25, 'o'], [1500, 0.2], [2000, 0, 'io']],
      curl: [[0, 0], [350, 0.8, 'o'], [2000, 0.6], [2600, 0, 'io']] } },
    sleep: { dur: 9000, noBlink: true, ev: [[8550, 'blink2']], k: {
      open: [[0, 0], [300, 0.9, 'io'], [1100, 0.9], [1500, 0, 'io']], mw: [[0, 1], [300, 0.75, 'io'], [1100, 0.75], [1500, 1, 'io']],
      sq: [[0, 0], [300, -0.08, 'io'], [1100, -0.08], [1500, 0.05, 'io'], [2800, 0.05], [4100, 0.09, 's'], [5400, 0.03, 's'], [6700, 0.09, 's'], [8000, 0.05, 's'], [8250, -0.1, 'o'], [8500, 0.04, 'io'], [8800, 0, 'io']],
      ...AR([[0, 0], [300, 36, 'io'], [1100, 36], [1500, 0, 'io']]),
      close: [[0, 0], [300, 0.75, 'io'], [1100, 0.75], [1500, 0.45, 'io'], [2000, 0.7, 'io'], [2300, 0.4, 'io'], [2800, 1, 'io'], [8200, 1], [8450, 0, 'o']],
      pitch: [[0, 0], [300, 0.4, 'io'], [1100, 0.4], [1600, 0, 'io'], [2800, -0.4, 'io'], [8200, -0.4], [8450, 0, 'io']],
      htilt: [[0, 0], [2800, 0], [3300, 7, 'io'], [8200, 7], [8450, 0, 'io']],
      ...ER([[0, 0], [2800, 8, 'io'], [8200, 8], [8300, -6, 'o'], [8600, 0, 'io']]),
      smile: [[0, 0], [2800, 0], [3300, 0.3, 'io'], [8200, 0.3], [8400, 0, 'io']],
      curl: [[0, 0], [2800, 0], [3400, -0.3, 'io'], [8200, -0.3], [8600, 0, 'io']] } },
  };
  const RELEASE = { dur: 1000, k: { sq: [[0, 0], [110, -0.2, 'o'], [250, 0.1, 'io'], [390, -0.04, 'io'], [540, 0, 'io']], lift: [[0, 0], [120, 3, 'o'], [270, 0, 'i']],
    smile: [[0, 0], [150, 0.8, 'o'], [700, 0.8], [1000, 0, 'io']], open: [[0, 0], [120, 0.35, 'o'], [500, 0, 'io']], ...ER([[0, 0], [120, -8, 'o'], [300, 6, 'io'], [500, 0, 'io']]) } };
  const POKE = s => ({ dur: 1100, k: { dent: [[0, 0], [45, 1, 'o'], [200, 0.3, 'io'], [460, 0, 'io']], lean: [[0, 0], [70, 4 * s, 'o'], [300, -1.6 * s, 'io'], [540, 0, 'io']],
    close: [[0, 0], [40, 1, 'o'], [170, 1], [300, 0, 'io']], hap: [[0, 0], [280, 0], [360, 1, 'o'], [850, 1], [1050, 0, 'io']], smile: [[0, 0], [280, 0], [360, 1, 'o'], [850, 1], [1050, 0, 'io']],
    open: [[0, 0], [280, 0], [360, 0.35, 'o'], [850, 0.3], [1050, 0, 'io']], sq: [[0, 0], [60, 0.06, 'o'], [200, -0.03, 'io'], [380, 0.05, 'io'], [480, -0.02, 'io'], [580, 0.04, 'io'], [680, -0.01, 'io'], [800, 0, 'io']] } });

  function poseAt(name, t, key) {
    const st = (key && STATES[name + '@' + key]) || STATES[name], P = Object.assign({}, REST), id = STATES.idle;
    if (name !== 'idle') { const ti = t % id.loop; for (const k in id.k) P[k] = kv(id.k[k], ti); }
    const tl = st.loop ? t % st.loop : Math.min(t, st.dur || t); for (const k in st.k) P[k] = kv(st.k[k], tl);
    if (st.breathe) { const bk = st.breathe; P.sq += Math.sin(t / 640) * 0.013 * bk; P.lean += Math.sin(t / 1350) * 0.4 * bk; P.htilt += Math.sin(t / 1900 + 1) * 0.8 * bk; } return P;
  }
  const DENT = { dur: 600, k: { dent: [[0, 0], [45, 1, 'o'], [200, 0.3, 'io'], [460, 0, 'io']], sq: [[0, 0], [50, 0.05, 'o'], [200, -0.02, 'io'], [360, 0, 'io']] } };
  function setState(I, name, now, keepQ) {
    if (!STATES[name]) name = 'idle';
    if (!keepQ) I.queue = [];
    if (STATES[name].seq) { I.queue = STATES[name].seq.slice(1); name = STATES[name].seq[0]; if (!STATES[name]) name = 'idle'; }
    I.prev = I.prev ? { frozen: I.lastP } : { name: I.cur.name, t0: I.cur.t0 };
    I.cur = { name, t0: now }; I.bt0 = now; I.bd = STATES[name].blend || 280; I.evC = -1; I.evF = {}; I.ctr = {}; I.ctT = {}; I.emL = {};
    const st = STATES[name]; if (st.tap) { const tp = I.fromM ? I.fromM(st.tap[0], st.tap[1]) : st.tap; I.shots.push({ S: DENT, t0: now, x: tp[0], y: tp[1] }); }
    if (I.onState) I.onState(name);
  }
  function fire(I, e, now) { const n = e[1]; I.ctr[n] = (I.ctr[n] || 0) + 1; I.ctT[n] = now;
    if (n === 'blink' || n === 'blink2') { I.blinkT = now; I.dbl = n === 'blink2'; I.blinkAt = now + 2600; }
    else if (n === 'poke') poke(I, e[2], e[3], now);
    else if (n === 'emit') emit(I, e[2], e[3], e[4]);
    const st = STATES[I.cur.name]; if (st.on && st.on[n]) st.on[n](I, e, now); }
  function poke(I, x, y, now) { I.shots.push({ S: POKE(x < 50 ? 1 : -1), t0: now, x, y }); }
  function region(I, x, y) { const P = I.lastP || REST; x -= P.x; y += P.lift; if (I.toM) [x, y] = I.toM(x, y); const dx = x - 50, dh = Math.hypot(dx, y - 46), L = dx < 0;
    if (x > 74 && y > 56 && y < 92) return 'tail';
    if (y > 87) return L ? 'footL' : 'footR';
    if (y < 30 && Math.abs(dx) > 9) return L ? 'earL' : 'earR';
    if (y >= 70 && Math.abs(dx) < 13) return 'belly';
    if (y >= 64 && Math.abs(dx) >= 13) return L ? 'sideL' : 'sideR';
    if (dh < 31) { if (y < 38) return 'head'; if (Math.abs(dx) < 6 && y >= 50 && y < 62) return 'nose'; if (y >= 40 && y < 52 && Math.abs(Math.abs(dx) - 12) < 6) return L ? 'eyeL' : 'eyeR'; if (y < 50) return 'head'; return L ? 'cheekL' : 'cheekR'; }
    return L ? 'sideL' : 'sideR'; }
  // particles: crumbs, drops, tears, bubbles, sparkles, hearts, stink waves, steam, notes
  const PRE = {
    crumb: { n: 3, sp: 9, vy: -6, g: 90, life: 650, r: [0.5, 0.9], col: ['#d9a35a', '#b77a3a', '#f0c890'], kind: 'dot' },
    drop: { n: 5, sp: 20, vy: -16, g: 80, life: 750, r: [0.7, 1.2], col: ['#8fd3ff', '#bfe8ff'], kind: 'drop' },
    splash: { n: 8, sp: 28, vy: -28, g: 95, life: 820, r: [0.8, 1.4], col: ['#8fd3ff', '#bfe8ff'], kind: 'drop' },
    tear: { n: 1, sp: 0.6, vy: 3, g: 16, life: 1150, r: [1, 1.2], col: ['#8fd3ff'], kind: 'drop' },
    gush: { n: 2, sp: 5, vx: 24, vy: -15, g: 75, life: 760, r: [0.9, 1.4], col: ['#8fd3ff', '#bfe8ff'], kind: 'drop', out: 1 },
    bubble: { n: 2, sp: 7, vy: -9, g: -3, life: 1700, r: [1.2, 2.6], kind: 'bubble' },
    bigbubble: { n: 1, sp: 3, vx: 7, vy: -6, g: -1.5, life: 2600, r: [3.6, 4.6], kind: 'bubble', out: 1 },
    spark: { n: 4, sp: 16, vy: -6, g: 0, life: 700, r: [1.4, 2.4], col: ['#fff3a0', '#ffffff'], kind: 'star' },
    heart: { n: 1, sp: 7, vy: -12, g: -2, life: 1300, r: [0.8, 1.1], kind: 'heart' },
    stink: { n: 1, sp: 7, vy: -7, g: -1, life: 1900, r: [1, 1.3], col: ['#8fae55', '#a3c266'], kind: 'wave' },
    steam: { n: 2, sp: 3, vy: -13, g: -4, life: 900, r: [1.6, 2.6], col: ['#ffffff'], kind: 'puff' },
    foam: { n: 2, sp: 9, vy: -3, g: 0, life: 1300, r: [1.6, 2.8], col: ['#ffffff'], kind: 'puff' },
    seed: { n: 1, sp: 2, vx: 20, vy: -10, g: 70, life: 800, r: [0.7, 0.8], col: ['#2a1a30'], kind: 'seed', out: 1 },
    sneeze: { n: 9, sp: 20, vy: 2, g: 18, life: 620, r: [0.5, 1], col: ['#d6f2fc', '#ffffff'], kind: 'dot' },
    note: { n: 1, sp: 9, vy: -11, g: -2, life: 1400, r: [1, 1], col: ['#8f3cf2', '#ff5cc6', '#2f7fd6'], kind: 'note' },
    sweat: { n: 1, sp: 0, vy: 2, g: 20, life: 900, r: [1.1, 1.1], col: ['#8fd3ff'], kind: 'drop' },
    duck: { n: 1, sp: 0, vx: 2.2, vy: -24, g: 120, life: 3600, r: [1, 1.15], kind: 'duck', out: 1, hop: 1 },
    dust: { n: 3, sp: 8, vy: -2, g: 5, life: 1500, r: [0.35, 0.75], col: ['#fff1d6', '#d2b6f4', '#ffffff'], kind: 'dot' },
    sprinkle: { n: 4, sp: 22, vy: -22, g: 90, life: 950, r: [0.7, 0.9], col: ['#ffd84a', '#7cc8ff', '#9be38a', '#ffffff', '#ff5cc6'], kind: 'seed' },
    salt: { n: 3, sp: 10, vy: 2, g: 70, life: 900, r: [0.45, 0.75], col: ['#ffffff', '#f2f0ff', '#fffbe6'], kind: 'dot' },
    ketchup: { n: 3, sp: 14, vy: -15, g: 90, life: 800, r: [0.9, 1.4], col: ['#e8352a', '#ff5a4a', '#c8241c'], kind: 'drop' },
    coffee: { n: 4, sp: 18, vy: -20, g: 90, life: 800, r: [0.8, 1.3], col: ['#8a5a3a', '#b07a52'], kind: 'drop' },
    gust: { n: 1, sp: 3, vx: 26, vy: -3, g: 0, life: 1000, r: [0.9, 1.4], col: ['#9ad8cc', '#7cc8ff'], kind: 'wisp', out: 1 },
  };
  function where(I, w) { if (Array.isArray(w)) return [w[0], w[1], w[0] < 50 ? -1 : 1]; const p = (I.W && I.W[w]) || [50, 50]; const sd = /L$/.test(w) ? -1 : /R$/.test(w) || w === 'tail' ? 1 : 0; return [p[0], p[1], sd]; }
  function emit(I, name, w, n) { const q = PRE[name]; if (!q) return; const [x, y, sd] = where(I, w); n = n || q.n;
    for (let i = 0; i < n && I.parts.length < 140; i++) { const a = Math.random() * TAU, m = Math.random() * q.sp, side = q.out ? (sd || (Math.random() < 0.5 ? -1 : 1)) : 1;
      I.parts.push({ x: x + Math.cos(a) * 0.6, y: y + Math.sin(a) * 0.6, vx: (q.vx || 0) * side + Math.cos(a) * m, vy: (q.vy || 0) + Math.sin(a) * m * 0.7, g: q.g, life: q.life * (0.8 + Math.random() * 0.4), age: 0,
        r: q.r[0] + Math.random() * (q.r[1] - q.r[0]), col: q.col ? q.col[Math.floor(Math.random() * q.col.length)] : '#fff', kind: q.kind, ph: Math.random() * TAU, gy: q.hop ? y : null }); } }
  function drawParts(I, dt) { let h = '';
    I.parts = I.parts.filter(p => { p.age += dt * 1000; if (p.age > p.life) return false; p.vy += p.g * dt; p.x += p.vx * dt; p.y += p.vy * dt; if (p.gy != null && p.y > p.gy && p.vy > 0) { p.y = p.gy; p.vy = -24 * (0.85 + Math.random() * 0.3); p.land = p.age; } const u = p.age / p.life, op = r2(Math.min(1, u * 8) * (1 - SM((u - 0.7) / 0.3)));
      const tr = 'translate(' + r2(p.x) + ' ' + r2(p.y) + ')';
      if (p.kind === 'dot') h += '<circle cx="' + r2(p.x) + '" cy="' + r2(p.y) + '" r="' + r2(p.r) + '" fill="' + p.col + '" opacity="' + op + '"/>';
      else if (p.kind === 'drop') h += '<path transform="' + tr + ' rotate(' + r2(Math.atan2(-p.vx, p.vy) / D2R) + ') scale(' + r2(p.r) + ')" d="M0 -2 Q1.4 0.4 0 1.3 Q-1.4 0.4 0 -2Z" fill="' + p.col + '" stroke="#ffffff" stroke-width="0.3" opacity="' + op + '"/>';
      else if (p.kind === 'bubble') { const pop = SM((u - 0.88) / 0.12), rr = p.r * (1 + pop * 0.4); h += '<g opacity="' + r2(op * (1 - pop)) + '"><circle cx="' + r2(p.x + Math.sin(p.age / 300 + p.ph) * 1.2) + '" cy="' + r2(p.y) + '" r="' + r2(rr) + '" fill="rgba(215,240,255,0.35)" stroke="#ffffff" stroke-width="0.45"/><circle cx="' + r2(p.x - rr * 0.35) + '" cy="' + r2(p.y - rr * 0.35) + '" r="' + r2(rr * 0.22) + '" fill="#ffffff"/></g>'; }
      else if (p.kind === 'star') h += '<path d="' + star4(p.x, p.y, p.r * (0.6 + 0.6 * Math.sin(Math.PI * u))) + '" fill="' + p.col + '" opacity="' + op + '"/>';
      else if (p.kind === 'heart') h += '<path transform="' + tr + ' scale(' + r2(p.r * (0.8 + u * 0.5)) + ')" d="M0 2.6 C-4.6 -0.6 -3.4 -5.6 0 -3 C3.4 -5.6 4.6 -0.6 0 2.6Z" fill="#ff5c9e" stroke="#ffffff" stroke-width="0.5" opacity="' + op + '"/>';
      else if (p.kind === 'wave') { const w = Math.sin(p.age / 260 + p.ph) * 1.2; h += '<path transform="' + tr + ' scale(' + r2(p.r) + ')" d="M0 0 q' + r2(-1.6 + w) + ' -2 0 -4 q' + r2(1.6 + w) + ' -2 0 -4" stroke="' + p.col + '" stroke-width="1.1" fill="none" stroke-linecap="round" opacity="' + r2(op * 0.9) + '"/>'; }
      else if (p.kind === 'wisp') { const s = p.r * (0.8 + u * 0.6), dr = p.vx < 0 ? -1 : 1; h += '<path transform="' + tr + ' scale(' + r2(dr * s) + ' ' + r2(s) + ')" d="M-5 0 Q-2 -1.6 1 0 T5 -0.6 Q7 -1.6 6 -3 Q4.6 -3.6 4.6 -2.2" stroke="' + p.col + '" stroke-width="' + r2(0.9 / s) + '" fill="none" stroke-linecap="round" opacity="' + r2(op * 0.9) + '"/>'; }
      else if (p.kind === 'leaf') { const sw = Math.sin(p.age / 260 + p.ph); h += '<path transform="translate(' + r2(p.x + sw * 2.2) + ' ' + r2(p.y) + ') rotate(' + r2(p.ph * 57 + sw * 55) + ') scale(' + r2(p.r) + ')" d="M0 -2.6 Q1.8 -0.8 0.3 2.3 L0 2.9 L-0.3 2.3 Q-1.8 -0.8 0 -2.6Z" fill="' + p.col + '" stroke="#ffffff" stroke-width="0.25" opacity="' + op + '"/>'; }
      else if (p.kind === 'duck') { const sq = p.land != null && p.age - p.land < 140 ? 1 - SM((p.age - p.land) / 140) : 0, wd = Math.sin(p.age / 110 + p.ph) * 14, dr = p.vx < 0 ? -1 : 1, s = p.r * 1.5;
        h += '<g transform="' + tr + ' scale(' + r2(dr * s * (1 + sq * 0.18)) + ' ' + r2(s * (1 - sq * 0.22)) + ') rotate(' + r2(wd) + ')" opacity="' + op + '"><ellipse cx="0.2" cy="-2" rx="3.5" ry="2.3" fill="#e9a512"/><ellipse cx="-0.2" cy="-2.4" rx="3.1" ry="1.9" fill="#ffd43b"/><path d="M-3 -2.6 L-4.5 -4.2 L-2.4 -3.5Z" fill="#ffd43b"/><path d="M-1.6 -2.6 Q0 -1.2 1.4 -2.6" stroke="#e9a512" stroke-width="0.5" fill="none" stroke-linecap="round"/><circle cx="1.95" cy="-4.85" r="1.85" fill="#e9a512"/><circle cx="1.8" cy="-5" r="1.75" fill="#ffd43b"/><ellipse cx="3.7" cy="-4.6" rx="1.05" ry="0.5" fill="#ff8a2a"/><circle cx="2.4" cy="-5.4" r="0.36" fill="#2a1a30"/><ellipse cx="1.1" cy="-5.8" rx="0.6" ry="0.35" fill="#fff8d0"/><ellipse cx="-1.2" cy="-3.3" rx="1" ry="0.4" fill="#fff8d0" opacity="0.8"/></g>'; }
      else if (p.kind === 'puff') h += '<circle cx="' + r2(p.x) + '" cy="' + r2(p.y) + '" r="' + r2(p.r * (0.7 + u * 0.8)) + '" fill="' + p.col + '" opacity="' + r2(op * 0.85) + '"/>';
      else if (p.kind === 'seed') h += '<ellipse cx="' + r2(p.x) + '" cy="' + r2(p.y) + '" rx="' + r2(p.r * 0.7) + '" ry="' + r2(p.r) + '" fill="' + p.col + '" opacity="' + op + '"/>';
      else if (p.kind === 'note') h += '<g transform="' + tr + ' rotate(' + r2(Math.sin(p.age / 200) * 12) + ')" opacity="' + op + '"><ellipse cx="0" cy="0" rx="1.5" ry="1.1" fill="' + p.col + '" transform="rotate(-20)"/><path d="M1.3 -0.3 L1.3 -5 Q3 -4.2 3.3 -2.6" stroke="' + p.col + '" stroke-width="0.8" fill="none" stroke-linecap="round"/></g>';
      return true; });
    return h; }

  const blinkC = t => t < 0 ? 0 : t < 75 ? EZ.i(t / 75) : t < 105 ? 1 : t < 240 ? 1 - EZ.o((t - 105) / 135) : 0;

  function tick(I, now, dt) {
    const SO = n => (I.key && STATES[n + '@' + I.key]) || STATES[n]; let st = SO(I.cur.name), t = now - I.cur.t0;
    if (st.dur && t >= st.dur) { setState(I, I.queue.length ? I.queue.shift() : (st.next || 'idle'), now, true); st = SO(I.cur.name); t = 0; }
    if (I.cur.name === 'idle' && I.fidgets && !I.press && !I.down && FIDGETS.length) { if (!I.fidAt) I.fidAt = now + 4200 + Math.random() * 4200; else if (now > I.fidAt) { I.fidAt = 0; let f; do { f = FIDGETS[Math.floor(Math.random() * FIDGETS.length)]; } while (FIDGETS.length > 1 && f === I.lastFid); I.lastFid = f; setState(I, f, now, true); st = SO(f); t = 0; } } else if (I.cur.name !== 'idle') I.fidAt = 0;
    if (st.emit) { const tl = st.loop ? t % st.loop : t; st.emit.forEach((m, i) => { if (tl >= m[0] && tl <= m[1] && now - (I.emL[i] || 0) >= m[2]) { I.emL[i] = now; emit(I, m[3], m[4], m[5]); } }); }
    if (st.ev) { const c = st.loop ? Math.floor(t / st.loop) : 0, tl = st.loop ? t % st.loop : t; if (c !== I.evC) { I.evC = c; I.evF = {}; } st.ev.forEach((e, i) => { if (tl >= e[0] && !I.evF[i]) { I.evF[i] = 1; fire(I, e, now); } }); }
    const P = poseAt(I.cur.name, t, I.key);
    if (I.prev) { const w = EZ.io(clamp((now - I.bt0) / I.bd, 0, 1)); if (w >= 1) I.prev = null; else { const Q = I.prev.frozen || poseAt(I.prev.name, now - I.prev.t0, I.key);
      for (const k in P) { if (k === 'spin') { let d = P.spin - Q.spin; d = ((d % 360) + 540) % 360 - 180; P.spin = Q.spin + d * w; } else P[k] = lerp(Q[k] == null ? P[k] : Q[k], P[k], w); } } }
    if (I.ext) for (const k in I.ext) P[k] = (P[k] || 0) + I.ext[k];
    I.lastP = Object.assign({}, P);
    // look layer: eyes lead, head follows
    I.flw.step(st.look ? 1 : 0, dt); const lw = clamp(I.flw.v, 0, 1);
    let tx = 0, ty = 0; if (I.ptr) { tx = I.ptr.x; ty = I.ptr.y; } else { if (now > I.glAt) { const g = Math.random() < 0.3 ? [0, 0] : [(Math.random() * 2 - 1) * 0.9, (Math.random() - 0.5) * 0.7]; if (Math.abs(g[0] - I.gl[0]) > 0.9 && now - I.blinkT > 800) { I.blinkT = now + 60; I.dbl = false; } I.gl = g; I.glAt = now + 1400 + Math.random() * 2600; } tx = I.gl[0]; ty = I.gl[1]; }
    I.fex.step(tx, dt); I.fey.step(ty, dt); I.fhx.step(tx, dt); I.fhy.step(ty, dt);
    P.lx += I.fex.v * lw; P.ly += I.fey.v * lw; P.turn += I.fhx.v * 0.6 * lw; P.pitch -= I.fhy.v * 0.35 * lw; P.htilt += I.fhx.v * 2.5 * lw;
    // blink layer
    if (now > I.blinkAt) { I.blinkT = now; I.dbl = Math.random() < 0.2; I.blinkAt = now + 2200 + Math.random() * 3200; }
    if (!st.noBlink) { let b = blinkC(now - I.blinkT); if (I.dbl) b = Math.max(b, blinkC(now - I.blinkT - 260)); P.close = Math.max(P.close, b); }
    // touch layer
    I.fp.w = I.press ? 14 : 28; I.fp.step(I.press ? 1 : 0, dt); const pv = clamp(I.fp.v, 0, 1.05), ht = I.press ? now - I.pressT : 0;
    if (pv > 0.001) { P.sq += pv * (0.34 + 0.06 * clamp(ht / 2000, 0, 1)); P.hap = Math.max(P.hap, pv * 0.85); P.armL += pv * 22; P.armR += pv * 22; P.earL += pv * 14; P.earR += pv * 14;
      P.blush = Math.max(P.blush, pv * clamp((ht - 400) / 900, 0, 1)); if (ht > 1300) P.x += Math.sin(now / 24) * 0.22 * pv; }
    I.dent = null;
    I.shots = I.shots.filter(s => { const u = now - s.t0; if (u > s.S.dur) return false; for (const k in s.S.k) { const v = kv(s.S.k[k], u); if (k === 'dent') I.dent = { x: s.x, y: s.y, a: v }; else P[k] += v; } return true; });
    if (I.spinTw) { const u = clamp((now - I.spinTw.t0) / I.spinTw.d, 0, 1); I.spinOff = lerp(I.spinTw.from, I.spinTw.to, EZ.bk(u)); if (u >= 1) { I.spinOff = I.spinTw.to % 360; I.spinTw = null; } }
    P.spin += I.spinOff;
    // follow-through: head jiggle, ears and tail trail behind
    I.fs.step(P.sq, dt); I.hs = clamp((I.fs.v - P.sq) * 0.55, -0.12, 0.12);
    const hx = P.x + P.lean + P.tilt * 0.9 + P.htilt * 0.4; I.fx.step(hx, dt); const ed = clamp(I.fx.v - hx, -8, 8);
    I.fl.step(P.lift, dt); const ld = clamp(I.fl.v - P.lift, -10, 10); I.ld = ld;
    if (I.lastSpin != null) { const dd = P.spin - I.lastSpin; if (Math.abs(dd) > 180) I.fsp.v += Math.round(dd / 360) * 360; } I.lastSpin = P.spin;
    I.fsp.step(P.spin, dt); const sd = clamp(I.fsp.v - P.spin, -40, 40);
    I.ed = ed; P.earL += clamp(-ed * 2 - ld * 1.3, -22, 22); P.earR += clamp(ed * 2 - ld * 1.3, -22, 22); P.wag += clamp(sd * 0.5 - ed * 3, -30, 30);
    I.propZ = st.propZ; if (I.generic) { if (!I.ready) return; I.render(I, P, now); } else render(I, P, now);
    const tt = now - I.cur.t0, fx = st.fx || FX[I.cur.name], pr = st.prop ? st.prop(I, tt) : '';
    if (pr || I.propOn) { I.pg.prop.innerHTML = pr; I.propOn = !!pr; }
    I.fxG.innerHTML = drawParts(I, dt) + (fx ? fx(I, tt) : '');
  }

  const FX = {
    sleep(I, t) { if (t < 2900 || t > 8150) return ''; let h = ''; const [x0, y0] = I.topW; for (let i = 0; i < 3; i++) { const u = (((t - 2900) / 2600) + i / 3) % 1; const x = x0 + 16 + u * 14 + Math.sin(u * TAU) * 2, y = y0 + 4 - u * 22;
      h += '<text x="' + r2(x) + '" y="' + r2(y) + '" font-family="Fredoka,sans-serif" font-weight="700" font-size="' + r2(5 + u * 5) + '" fill="#8f3cf2" stroke="#ffffff" stroke-width="0.6" paint-order="stroke" opacity="' + r2(Math.sin(Math.PI * u)) + '">z</text>'; } return h; },
    happy(I, t) { let h = ''; for (let i = 0; i < 8; i++) { const a = i / 8 * TAU + i * 0.7, u = ((t / 900) + i / 8) % 1, r = 36 * (0.55 + 0.45 * u); h += '<path d="' + star4(50 + Math.cos(a) * r, 52 + Math.sin(a) * r * 0.8, 1.2 + 2.2 * Math.sin(Math.PI * u)) + '" fill="' + (i % 2 ? '#fff3a0' : '#ffffff') + '" opacity="' + r2(Math.sin(Math.PI * u)) + '"/>'; } return h; },
    surprised(I, t) { const u = clamp((t - 300) / 700, 0, 1); if (u <= 0 || u >= 1) return ''; const [x0, y0] = I.topW, a = Math.sin(Math.PI * u); let h = '';
      [-34, 0, 34].forEach(d => { const r = d * D2R, s = 6 + u * 4, x1 = x0 + Math.sin(r) * s, y1 = y0 - 3 - Math.cos(r) * s, x2 = x0 + Math.sin(r) * (s + 5), y2 = y0 - 3 - Math.cos(r) * (s + 5); h += '<path d="M' + r2(x1) + ' ' + r2(y1) + ' L' + r2(x2) + ' ' + r2(y2) + '" stroke="#8f3cf2" stroke-width="1.6" stroke-linecap="round" opacity="' + r2(a) + '"/>'; }); return h; },
  };

  function render(I, P, now) {
    const D = I.D, R = I.RG, E = I.E, G = D.G, Hh = G - D.top, [HX, HY, HR] = D.head, SR = HR + 0.5, HRY = D.head[3] || HR, SRY = HRY + 0.5, KY = SRY / SR, [NX, NY] = D.neck;
    const yb = (P.spin + P.turn * 40) * D2R, yh = yb, ph = P.pitch * 22 * D2R;
    const cyb = Math.cos(yb), syb = Math.sin(yb), cyh = Math.cos(yh), syh = Math.sin(yh), cp = Math.cos(ph), sp = Math.sin(ph);
    const sq = clamp(P.sq, -0.25, 0.45), sy = 1 - sq, tr = P.tilt * D2R, ct = Math.cos(tr), stt = Math.sin(tr), dn = I.dent && I.dent.a > 0.01 ? I.dent : null;
    const glob = (x, y) => {
      if (dn) { const ddx = x - dn.x, ddy = y - dn.y, g = Math.exp(-(ddx * ddx + ddy * ddy) / 90); if (g > 0.01) { const vx = 50 - dn.x, vy = 60 - dn.y, L = Math.hypot(vx, vy) || 1; x += vx / L * dn.a * 4.5 * g; y += vy / L * dn.a * 4.5 * g; } }
      const u = clamp((G - y) / Hh, 0, 1), kx = 1 + sq * (0.45 + 0.6 * 4 * u * (1 - u)), X = (x - 50) * kx + P.lean * Math.pow(u, 1.5), Y = -(G - y) * sy;
      return [50 + X * ct - Y * stt + P.x, G + X * stt + Y * ct - P.lift]; };
    const hs = I.hs, hr = P.htilt * D2R, chr = Math.cos(hr), shr = Math.sin(hr), hyo = -P.pitch * 1.1;
    const headT = (x, y) => { x = 50 + (x - 50) * (1 + hs * 0.6); y = NY - (NY - y) * (1 - hs) + hyo; const dx = x - NX, dy = y - NY; return glob(NX + dx * chr - dy * shr, NY + dx * shr + dy * chr); };
    const sz = (dx, dy, zm) => { if (typeof zm === 'number') return zm; const q = 1 - (dx / SR) * (dx / SR) - (dy / SRY) * (dy / SRY), z = q > 0 ? SR * Math.sqrt(q) : 0; return zm === 'b' ? -z : z; };
    const sph = (x, y, zm) => { const dx = x - HX, dy = y - HY, z = sz(dx, dy, zm), x1 = dx * cyh + z * syh, z1 = -dx * syh + z * cyh; let X = x1, Y = dy * cp - z1 * sp * KY;
      if (zm === undefined && dy * sp / KY + z1 * cp < 0) { const nr = Math.hypot(X / SR, Y / SRY) || 1; X /= nr; Y /= nr; } return headT(HX + X, HY + Y); };
    const sphZ = (x, y, zm) => { const dx = x - HX, dy = y - HY, z = sz(dx, dy, zm), z1 = -dx * syh + z * cyh; return dy * sp / KY + z1 * cp; };
    const face = (x, y) => sph(x, y), wrapF = (x, y) => { const dx = x - HX, dy = y - HY, q = 1 - (dx / SR) * (dx / SR) - (dy / SRY) * (dy / SRY), w = SM((q - 0.04) / 0.32); if (w >= 1) return sph(x, y); const a = sph(x, y), b = headT(x, y); return [b[0] + (a[0] - b[0]) * w, b[1] + (a[1] - b[1]) * w]; }, vis = z => SM((z - 1.5) / 6), zc = (x, y, zm) => vis(sphZ(x, y, zm));
    const yw = ((yh / D2R) % 360 + 540) % 360 - 180, hY = clamp(yw, -85, 85) * D2R, hw = 1 - SM((Math.abs(yw) - 45) / 40), HP = Math.PI / 2;
    const hugF = (x, y) => { const dx = x - HX, dy = y - HY, z = sz(dx, dy), r = Math.hypot(dx, z), th = Math.atan2(dx, z), t2 = th < 0 ? -HP + (th + HP) * (HP + hY) / HP : hY + th * (HP - hY) / HP, z1 = r * Math.cos(t2), b = headT(HX + r * Math.sin(t2), HY + dy * cp - z1 * sp * KY); if (hw >= 1) return b; const a = wrapF(x, y); return [a[0] + (b[0] - a[0]) * hw, a[1] + (b[1] - a[1]) * hw]; };
    const byw = (x, y, z) => glob(50 + (x - 50) * cyb + z * syb, y), bywZ = (x, z) => -(x - 50) * syb + z * cyb;
    const set = (e, a, v) => e.setAttribute(a, v);

    set(E.body, 'd', toD(R.body, glob));
    const pf = clamp(P.puff, -0.5, 1.2), skD = toD(R.skull, pf ? (x, y) => { const dy = y - 58, g = Math.exp(-dy * dy / 80); return headT(x + (x < 50 ? -1 : 1) * pf * 3.2 * g * clamp(Math.abs(x - 50) / 20, 0, 1), y); } : headT);
    set(E.skull, 'd', skD); set(E.clip, 'd', skD);
    const rd = clamp(P.red, 0, 1), gr = clamp(P.green, 0, 1); set(E.tintR, 'd', skD); set(E.tintR, 'opacity', r2(rd * 0.34)); set(E.tintG, 'd', skD); set(E.tintG, 'opacity', r2(gr * 0.26));
    if (gr > 0.01) set(E.bodyG, 'd', E.body.getAttribute('d')); set(E.bodyG, 'opacity', r2(gr * 0.26));
    const keys = { body: 0, head: 1, collar: 1.5, prop: I.propZ != null ? I.propZ : 5 }; I.W = {};
    // feet: ellipsoids that keep their roundness from every side; pads are painted on the front
    R.feet.forEach((f, i) => { const st = clamp(+P.sit || 0, 0, 1), cy = f.y - (i ? P.footR : P.footL) + st * 4.6, z = 8 + st * 7, X = 50 + (f.x - 50) * (1 + st * 0.3) * cyb + z * syb, fsd = f.x < 50 ? 1 : -1;
      const FS0 = D.footS || [9, 5.5, 8], FS = [FS0[0] * (1 + st * 0.06), FS0[1] * (1 + st * 0.75), FS0[2]], fd = toD(ellAx(X, cy, [[FS[0] * cyb, 0], [fsd * st * FS[1] * 0.28 * cyb, FS[1]], [FS[2] * syb, 0]]), glob); set(E.feet[i].f, 'd', fd); set(E.feet[i].clip, 'd', fd);
      const zp = z + 7.5; set(E.feet[i].p, 'd', (D.pads || [[0, 1, 5, 2.8]]).map(([dx, dy, rx, ry]) => toD(ellAx(50 + (f.x * (1 + st * 0.3) - st * 15 + dx - fsd * st * dy * 0.28 - 50) * cyb + zp * syb, cy + dy * (1 + st * 0.75) - st * 0.8, [[rx * cyb, 0], [0, ry * (1 + st * 0.6)]]), glob)).join(' ')); set(E.feet[i].p, 'opacity', r2(0.9 * SM(cyb * 3)));
      keys[i ? 'footR' : 'footL'] = -(f.x - 50) * syb + z * cyb + (D.footK != null ? D.footK : -10); I.W[i ? 'footR' : 'footL'] = glob(X, cy); });
    // ears: rounded cones whose roots sit on the curved head (mid-surface follows the sphere), bent from the root; parts buried in the head are dropped
    R.ears.forEach((e, i) => { const a = (e.flop ? (e.side < 0 ? P.earL : -P.earR) * 0.9 : (e.side < 0 ? -P.earL : P.earR)) * D2R, [px, py] = e.pivot, S = e.S, pts = [], lim = SR * SR * 0.81;
      // lobe ears: a rounded ellipsoid hanging beside the head; tucked behind the head's rim until its side turns toward the camera
      if (e.lobe) { const [lx, ly, la, lb, lc, lz, lr] = e.lobe, ca = Math.cos(a), sa = Math.sin(a), vx = lx - px, vy = ly - py, cx = px + vx * ca - vy * sa, cy = py + vx * sa + vy * ca, rr = (lr || 0) * D2R + a, cr = Math.cos(rr), sr = Math.sin(rr);
        const pv = (x, y, z) => { const z1 = -x * syh + z * cyh; return [x * cyh + z * syh, y * cp - z1 * sp * KY]; }, C = pv(cx - HX, cy - HY, lz || 0);
        const ld = toD(ellAx(HX + C[0], HY + C[1], [pv(la * cr, la * sr, 0), pv(-lb * sr, lb * cr, 0), pv(0, 0, lc)]), headT); set(E.ears[i].o, 'd', ld); set(E.ears[i].clip, 'd', ld); set(E.ears[i].n, 'opacity', 0);
        const bk = r2(1 - SM((-e.side * syh - 0.2) / 0.35)); (E.ears[i].mk || []).forEach((m, j) => { set(m, 'd', j ? E.body.getAttribute('d') : skD); set(m, 'fill-opacity', bk); });
        keys[i ? 'earR' : 'earL'] = 2.5; I.W[i ? 'earR' : 'earL'] = headT(HX + C[0], HY + C[1] + lb * 0.8); return; }
      const zm = (x, y) => { const dx = x - HX, dy = y - HY, q = 1 - (dx / SR) * (dx / SR) - (dy / SRY) * (dy / SRY); return e.flop ? (q > 0 ? 0.12 * SR * Math.sqrt(q) : 1) : (q > 0 ? -0.35 * SR * Math.sqrt(q) : 0); };
      const bend = (x, y, w) => { const vx = x - px, vy = y - py, c = Math.cos(a * w), s = Math.sin(a * w); return [px + vx * c - vy * s, py + vx * s + vy * c]; };
      for (const q of S.secs) { const w = Math.pow(q.s, 1.3), c = Math.cos(a * w), s = Math.sin(a * w), nx = S.nx * c - S.ny * s, ny = S.nx * s + S.ny * c, [cx, cy] = bend(q.cx, q.cy, w);
        for (let k = 0; k < 14; k++) { const f = k / 14 * TAU, cf = Math.cos(f), X = cx + nx * q.hw * cf, Y = cy + ny * q.hw * cf, Z = zm(X, Y) - q.hd * 0.15 + q.hd * Math.sin(f), dx = X - HX, dy = Y - HY;
          if (e.flop || (dx / SR) * (dx / SR) + (dy / SRY) * (dy / SRY) + (Z / SR) * (Z / SR) >= 0.81) pts.push(sph(X, Y, Z)); } }
      const ed = closedD(hull(pts)); set(E.ears[i].o, 'd', ed); set(E.ears[i].clip, 'd', ed);
      const hdAt = s => { const L = S.secs; let j = 0; while (j < L.length - 2 && L[j + 1].s < s) j++; const A = L[j], B = L[j + 1] || A, u = B.s > A.s ? clamp((s - A.s) / (B.s - A.s), 0, 1) : 0; return lerp(A.hd, B.hd, u); };
      if (e.n) set(E.ears[i].n, 'd', toD(e.n, (x, y) => { const s = clamp(((x - px) * e.ux + (y - py) * e.uy) / S.amax, 0, 1), hd = hdAt(s), [bx, by] = bend(x, y, Math.pow(s, 1.3)); return sph(bx, by, zm(bx, by) - hd * 0.15 + hd * 0.85); }));
      set(E.ears[i].n, 'opacity', r2(0.8 * SM(cyh * cp * 3))); keys[i ? 'earR' : 'earL'] = sphZ(px, py, zm(px, py)) + (e.flop ? 2.5 : 1); const tq = S.secs[S.secs.length - 1], tb = bend(tq.cx, tq.cy, 1); I.W[i ? 'earR' : 'earL'] = sph(tb[0], tb[1], 0); });
    // paws: ellipsoids that swing around the body and stay round
    R.arms.forEach((a, i) => { const Lf = a.side < 0, av = Lf ? P.armL : P.armR, base = Lf ? 20 : -20, wr = SM(Math.abs(av) / 45), ang = ((Lf ? P.armL : -P.armR) + (base - a.e[4]) * wr) * D2R, c = Math.cos(ang), s = Math.sin(ang), [px, py] = a.pivot, vx = a.e[0] - px, vy = a.e[1] - py;
      const [mhx, mhy] = I.mapHand ? I.mapHand(Lf ? P.hLx : -P.hRx, Lf ? P.hLy : P.hRy) : [Lf ? P.hLx : -P.hRx, Lf ? P.hLy : P.hRy], hy = mhy, hz = Lf ? P.hLz : P.hRz, cx = px + vx * c - vy * s + (Lf ? mhx : -mhx) + (I.ed || 0) * 0.35 + (I.mapHand ? a.side * 7 * wr : 0), cy = py + vx * s + vy * c + hy, z = (D.armZ != null ? D.armZ : 9) + hz + Math.max(0, -hy) * 0.25;
      const sx = px - a.side * 1.2, sy0 = py + 1.5, ddx = cx - sx, ddy = cy - sy0, len = Math.hypot(ddx, ddy);
      let r0 = a.e[4] * D2R + ang; if (len > 9) { const want = Math.atan2(ddy, ddx) - Math.PI / 2; let df = want - r0; df = ((df % TAU) + TAU * 1.5) % TAU - Math.PI; r0 += df * SM((len - 9) / 8); }
      const c0 = Math.cos(r0), s0 = Math.sin(r0), ax = [[a.e[2] * c0, a.e[2] * s0, 0], [-a.e[3] * s0, a.e[3] * c0, 0], [0, 0, 6.5]].map(([x, y, zz]) => [x * cyb + zz * syb, y]);
      const PX = 50 + (cx - 50) * cyb + z * syb; set(E.arms[i], 'd', toD(ellAx(PX, cy, ax), glob)); keys[i ? 'armR' : 'armL'] = -(cx - 50) * syb + z * cyb;
      const Sw = byw(sx, sy0, 4), Pw = glob(PX, cy), mx = (Sw[0] + Pw[0]) / 2, my = (Sw[1] + Pw[1]) / 2, tx = Pw[0] - Sw[0], ty = Pw[1] - Sw[1], tl = Math.hypot(tx, ty) || 1; let nx = -ty / tl, ny = tx / tl; if (nx * a.side < 0) { nx = -nx; ny = -ny; }
      const bu = Math.max(0, tl - 10) * 0.18; set(E.armT[i], 'd', 'M' + r2(Sw[0]) + ' ' + r2(Sw[1]) + ' Q' + r2(mx + nx * bu) + ' ' + r2(my + ny * bu) + ' ' + r2(Pw[0]) + ' ' + r2(Pw[1]));
      set(E.armT[i], 'stroke-width', r2(9.5 * Math.sqrt((1 + sq * 0.4) * sy))); set(E.armT[i], 'opacity', r2(SM((len - 7.5) / 5))); I.W[Lf ? 'pawL' : 'pawR'] = Pw; });
    // tail: a tube whose spine curls back in depth, with a soft highlight along the top
    { const b = R.tail[0], wa = P.wag * D2R, cu = P.curl * 40 * D2R;
      const sp3 = R.tail.map(([x, y, s, z]) => { const th = wa * Math.pow(s, 1.2) - cu * Math.pow(s, 1.6), c = Math.cos(th), sn = Math.sin(th), vx = x - b[0], vy = y - b[1]; return byw(b[0] + vx * c - vy * sn, b[1] + vx * sn + vy * c, z); });
      const tw = 7 * Math.sqrt((1 + sq * 0.5) * sy); set(E.tail, 'd', smoothD(sp3)); set(E.tail, 'stroke-width', r2(tw * (D.tailW || 7) / 7));
      set(E.tailH, 'd', smoothD(sp3.slice(0, -1).map(p => [p[0] - tw * 0.16, p[1] - tw * 0.18]))); set(E.tailH, 'stroke-width', r2(tw * (D.tailW || 7) / 7 * (D.tailHLW || 0.3)));
      if (D.tail) keys.tail = bywZ(66, -12); keys.collar = 1.5; if (D.mane) { keys.mane = -30; keys.maneF = 1.3; } if (D.pup) keys.pup = 12; I.W.tail = sp3[sp3.length - 1]; }
    // face, painted on the head sphere
    const MZ = D.muzzle || [50, 57, 16, 10]; set(E.muzzle, 'd', toD(R.muzzle, face)); set(E.muzzle, 'opacity', r2(zc(MZ[0], MZ[1])));
    (E.fx || []).forEach((el, i) => { const fe = D.faceExtra[i], big = R.fxBig && R.fxBig[i]; set(el, 'd', toD(R.fx[i], fe.gloss ? headT : fe.hug ? hugF : big && !fe.sph ? wrapF : face)); set(el, 'opacity', r2((fe.op || 1) * (fe.gloss ? 1 : fe.hug ? zc(HX, R.fxC[i][1]) : big && !fe.sph ? 1 : zc(R.fxC[i][0], R.fxC[i][1])))); });
    set(E.stripes, 'd', toD(R.stripes, face)); set(E.stripes, 'opacity', r2(zc(50, 21)));
    set(E.back, 'd', toD(R.back, (x, y) => sph(x, y, 'b'))); set(E.back, 'opacity', r2(zc(50, 23, 'b')));
    const NS0 = D.nose || [50, 54, 2.6, 1.8]; set(E.nose, 'd', toD(R.nose, face)); set(E.nose, 'opacity', r2(zc(NS0[0], NS0[1]))); if (E.noseHL) { set(E.noseHL, 'd', toD(R.noseHL, face)); set(E.noseHL, 'opacity', r2(0.7 * zc(NS0[0], NS0[1]))); }
    const sm = clamp(P.smile, 0, 1);
    // cheek decals: follow the surface but never stretch past their front-view size (they only compress toward the rim)
    const decal = (F, cx, cy) => { const e = 0.5, k = 1 / (2 * e), C = F(cx, cy), a = F(cx + e, cy), b = F(cx - e, cy), c = F(cx, cy + e), d = F(cx, cy - e), h1 = headT(cx + e, cy), h2 = headT(cx - e, cy), h3 = headT(cx, cy + e), h4 = headT(cx, cy - e);
      const mul = (A, B) => [A[0] * B[0] + A[1] * B[2], A[0] * B[1] + A[1] * B[3], A[2] * B[0] + A[3] * B[2], A[2] * B[1] + A[3] * B[3]];
      const J = [(a[0] - b[0]) * k, (c[0] - d[0]) * k, (a[1] - b[1]) * k, (c[1] - d[1]) * k], Hm = [(h1[0] - h2[0]) * k, (h3[0] - h4[0]) * k, (h1[1] - h2[1]) * k, (h3[1] - h4[1]) * k], dt = Hm[0] * Hm[3] - Hm[1] * Hm[2] || 1;
      const m = mul([Hm[3] / dt, -Hm[1] / dt, -Hm[2] / dt, Hm[0] / dt], J), e1 = (m[0] + m[3]) / 2, f1 = (m[0] - m[3]) / 2, g1 = (m[2] + m[1]) / 2, k1 = (m[2] - m[1]) / 2, q1 = Math.hypot(e1, k1), q2 = Math.hypot(f1, g1), a1 = Math.atan2(g1, f1), a2 = Math.atan2(k1, e1), th = (a2 - a1) / 2, ph2 = (a2 + a1) / 2;
      const s1 = Math.min(q1 + q2, 1), s2 = Math.sign(q1 - q2) * Math.min(Math.abs(q1 - q2), 1), cf = Math.cos(ph2), sf = Math.sin(ph2), ct = Math.cos(th), st = Math.sin(th);
      const M = mul(Hm, mul([cf * s1, -sf * s2, sf * s1, cf * s2], [ct, -st, st, ct])); return (x, y) => { const u = x - cx, v = y - cy; return [C[0] + M[0] * u + M[1] * v, C[1] + M[2] * u + M[3] * v]; }; };
    const CK = D.cheekR || [4, 2.6]; (D.cheeks || [[33, 56], [67, 56]]).forEach(([cx, cy0], i) => { const cy = cy0 - sm * 0.6; const pk = 1 + Math.max(0, pf) * 0.35; set(E.cheeks[i], 'd', toD(ellS(cx + (i ? 1 : -1) * Math.max(0, pf) * 1.2, cy, CK[0] * (1 + sm * 0.08) * pk, CK[1] * pk, 0, 8), D.hugCheeks ? decal(hugF, cx, cy) : face)); set(E.cheeks[i], 'opacity', r2(clamp(0.5 + clamp(P.blush, 0, 1) * 0.45 + Math.max(0, pf) * 0.25 + rd * 0.3, 0, 1) * zc(D.hugCheeks ? HX : cx, cy))); });
    const ox = P.lx * 2.6, oy = P.ly * 2.2, ws = 1 + clamp(P.wide, 0, 1) * 0.22, h = clamp(P.hap, 0, 1), qz = clamp(P.sqz, 0, 1), cr = clamp(P.cross, 0, 1) * 1.8, ty = clamp(P.teary, 0, 1); I.eyeW = [];
    D.eyes.forEach(([ex, ey], i) => { const c = clamp(Math.max(P.close, i ? P.winkR : P.winkL), 0, 1) * (1 - SM(h * 1.6)), dir = i ? -1 : 1, cx = ex + ox + dir * cr, cy = ey + oy - h * 0.8, r = D.eyeR * ws, o = E.eyes[i];
      const sl = clamp(P.sl, 0, 1) * 0.32, out = i ? 1 : -1;
      const eD = toD(ellS(cx, cy, r, r, 0, 8), (x, y) => { const dy = y - cy, ce = clamp(c + sl * (0.5 + 0.5 * out * (x - cx) / r), 0, 1); let X = x, Y = cy + dy * (dy < 0 ? 1 - 2 * ce : 1 - 2 * h);
        if (qz > 0) { const cu = clamp((x - cx) / r, -1, 1), u = dir > 0 ? (cu + 1) / 2 : (1 - cu) / 2; X = lerp(X, cx + dir * (-0.8 + u * 1.4) * r, qz); Y = lerp(Y, cy + Math.sign(dy) * (1 - u) * 0.6 * r, qz); } return face(X, Y); }); set(o.e, 'd', eD); set(o.clip, 'd', eD);
      set(o.e, 'stroke-width', r2(1.3 * Math.max(SM((c - 0.5) / 0.45), SM((h - 0.5) / 0.45), SM(qz * 1.6))));
      const ha = (1 - SM((c - 0.4) / 0.25)) * (1 - SM((h - 0.12) / 0.3)) * (1 - SM(qz * 2.5)), hk = ws * (1 + ty * 0.4);
      const hd = c * r * 0.7; set(o.h1, 'd', toD(ellS(cx - 1.7 * ws, cy - 1.9 * ws + hd, 1.8 * hk, 1.8 * hk, 0, 6), face)); set(o.h2, 'd', toD(ellS(cx + 1.8 * ws, cy + 1.6 * ws, 0.7 * hk, 0.7 * hk, 0, 6), face));
      set(o.tp, 'd', toD(ellS(cx, cy + r * 0.8, r, r * 0.42, 0, 8), face)); set(o.tp, 'opacity', r2(ty * 0.85 * (1 - qz) * (1 - SM(c * 1.5))));
      set(o.h1, 'opacity', r2(ha)); set(o.h2, 'opacity', r2(ha * 0.9)); set(o.g, 'opacity', r2(zc(cx, cy))); I.eyeW.push(face(cx, cy)); I.W[i ? 'eyeR' : 'eyeL'] = face(cx, cy); });
    { const [MX0, MY0, MH0] = D.mouth || [50, 58, 3.5], mk0 = MH0 / 3.5, op = clamp(P.open, 0, 1), fr = clamp(P.frown, 0, 1), mw = P.mw * (1 + sm * 0.12), hw = MH0 * mw * (1 + op * 0.3), y0 = MY0 + (-sm * 0.5 + fr * 1.3) * mk0, d = (2.3 * (1 + sm * 0.45) - fr * 4) * (1 - op * 0.55) * mk0, ym = MY0 - fr * 0.2 * mk0;
      const lip = 'M' + r2(MX0 - hw) + ' ' + r2(y0) + ' Q' + r2(MX0 - hw / 2) + ' ' + r2(y0 + d) + ' ' + r2(MX0) + ' ' + r2(ym) + ' Q' + r2(MX0 + hw / 2) + ' ' + r2(ym + d) + ' ' + r2(MX0 + hw) + ' ' + r2(y0);
      const mv = zc(MX0, MY0); set(E.mouth, 'd', toD(parsePath(lip), face)); set(E.mouth, 'opacity', r2(mv));
      if (op > 0.03) { set(E.mopen, 'd', toD(parsePath(lip + ' C' + r2(MX0 + hw) + ' ' + r2(y0 + op * 8 * mk0) + ' ' + r2(MX0 - hw) + ' ' + r2(y0 + op * 8 * mk0) + ' ' + r2(MX0 - hw) + ' ' + r2(y0) + 'Z'), face));
        set(E.tongue, 'd', toD(ellS(MX0, y0 + op * 4.2 * mk0, 2.3 * op * mw * mk0, 1.4 * op * mk0, 0, 8), face)); set(E.mopen, 'opacity', r2(mv)); set(E.tongue, 'opacity', r2(mv)); }
      else { set(E.mopen, 'opacity', 0); set(E.tongue, 'opacity', 0); }
      const tg = clamp(P.tongue, 0, 1); set(E.tout, 'opacity', r2(mv * SM(tg * 3))); if (tg > 0.02) set(E.tout, 'd', toD(ellS(MX0, y0 + (1.3 + tg * 1.9) * mk0, 2.2 * (1 + tg * 0.15) * mk0, (1 + tg * 1.7) * mk0, 0, 8), face)); }
    { const M0 = D.mouth || [50, 58], N0 = D.nose || [50, 54]; I.W.mouth = face(M0[0], M0[1]); I.W.nose = face(N0[0], N0[1]); } I.W.body = glob(50, 78); I.W.belly = glob(50, 83); I.W.sideL = glob(30, 78); I.W.sideR = glob(70, 78);
    R.wh.forEach((w, i) => { const sd = i < 2 ? -1 : 1, far = 1 - SM((syh * sd - 0.06) / 0.22); set(E.wh[i], 'd', toD(w, face)); set(E.wh[i], 'opacity', r2(0.8 * zc(i < 2 ? 36 : 64, 56) * far)); });
    // bellyTurn: the belly patch is painted on the body's front and turns with it, sliding to the rim and fading as it goes round the back
    if (E.belly) { if (D.bellyTurn && D.belly) { const [BX, BY, BW, BH] = D.body, bf = (x, y) => { const dx = x - BX, v = clamp((y - BY) / BH, -1, 1), w = BW * Math.sqrt(1 - v * v), wc = BW * Math.sqrt(1 - v * v * 0.36), q = wc * wc - dx * dx, z = q > 0 ? Math.sqrt(q) : 0; let X = dx * cyb + z * syb; if (-dx * syb + z * cyb < 0) X = (X < 0 ? -1 : 1) * wc; return glob(BX + clamp(X, -w, w), y); };
      set(E.belly, 'd', closedD((R.bellyP || (R.bellyP = flat(R.belly, 4).slice(0, -1))).map(p => bf(p[0], p[1])))); set(E.belly, 'opacity', r2(SM((cyb + 0.3) / 0.4))); } else set(E.belly, 'd', toD(R.belly, glob)); }
    if (E.hog) { const K = R.hog, ed = I.ed || 0, ld = I.ld || 0, grow = 1 + clamp(P.wide, 0, 1) * 0.2 + Math.max(0, sq) * 0.15, [BX0, BY0, BW0, BH0] = D.body, BZ = BW0 * 0.75;
      const rot = p => [50 + (p[0] - 50) * cyb + p[2] * syb, p[1], -(p[0] - 50) * syb + p[2] * cyb], fac = n => -n[0] * syb + n[2] * cyb, p2s = q => r2(q[0]) + ' ' + r2(q[1]);
      const W2 = (X, Y) => { const w = SM((NY - Y) / 12); if (w <= 0) return glob(X, Y); const a = headT(X, Y); if (w >= 1) return a; const b = glob(X, Y); return [b[0] + (a[0] - b[0]) * w, b[1] + (a[1] - b[1]) * w]; };
      const surf = (X, Y) => { const a = 1 - ((X - HX) / SR) ** 2 - ((Y - HY) / SRY) ** 2, b = 1 - ((X - BX0) / BW0) ** 2 - ((Y - BY0) / BH0) ** 2; return Math.max(a > 0 ? SR * Math.sqrt(a) : -1e9, b > 0 ? BZ * Math.sqrt(b) : -1e9); };
      // back shell: every quad goes behind the body; quads facing the camera and in front of head/body are drawn again on top
      const S = K.G.map(row => row.map(p => { const q = rot(p); return { q, w: W2(q[0], q[1]) }; })), na = K.A.length; let dB = '', dF = '';
      for (let j = 0; j < K.B.length - 1; j++) for (let i = 0; i < na; i++) { const i2 = (i + 1) % na, c = [S[j][i], S[j][i2], S[j + 1][i2], S[j + 1][i]], w = c.map(o => o.w); let ar = 0;
        for (let k = 0; k < 4; k++) { const a = w[k], b = w[(k + 1) % 4]; ar += a[0] * b[1] - b[0] * a[1]; } if (ar < 0) w.reverse(); const d = 'M' + w.map(p2s).join(' L') + 'Z'; dB += d;
        if (fac(K.QN[j][i]) > 0.02) { const mx = (c[0].q[0] + c[2].q[0]) / 2, my = (c[0].q[1] + c[2].q[1]) / 2, mz = (c[0].q[2] + c[1].q[2] + c[2].q[2] + c[3].q[2]) / 4; if (mz > surf(mx, my) - 1.5) dF += d; } }
      // spikes: away-facing ones sit under the shell, the rim ring on it, camera-facing ones in front of the body
      const LS = [[], [], []];
      K.sp.forEach(s => { const bc = [(s.b1[0] + s.b2[0]) / 2, (s.b1[1] + s.b2[1]) / 2, (s.b1[2] + s.b2[2]) / 2], t3 = [0, 1, 2].map(k => bc[k] + (s.t[k] - bc[k]) * grow);
        const q1 = rot(s.b1), q2 = rot(s.b2), qt = rot(t3), f = fac(s.n), k = s.len / 10, wob = Math.sin(now / 520 + s.i * 1.7) * 0.25 * k; let A1 = W2(q1[0], q1[1]), A2 = W2(q2[0], q2[1]); const At = W2(qt[0], qt[1]);
        { // seen edge-on a spike keeps some width (it is a cone, not a flat blade)
          const mx = (A1[0] + A2[0]) / 2, my = (A1[1] + A2[1]) / 2, ax = At[0] - mx, ay = At[1] - my, al = Math.hypot(ax, ay) || 1, px = -ay / al, py = ax / al, hx = (A2[0] - A1[0]) / 2, hy = (A2[1] - A1[1]) / 2, dp = hx * px + hy * py, need = s.w * 0.8 - Math.abs(dp);
          if (need > 0) { const sg = dp < 0 ? -1 : 1, nx = hx + px * need * sg, ny = hy + py * need * sg; A1 = [mx - nx, my - ny]; A2 = [mx + nx, my + ny]; } }
        const tx = A2[0] - A1[0], ty = A2[1] - A1[1], tl = Math.hypot(tx, ty) || 1, Tp = [At[0] + ed * 0.35 * k + tx / tl * wob, At[1] - ld * 0.3 * k + ty / tl * wob];
        const vis = Math.abs((Tp[0] - A1[0]) * ty - (Tp[1] - A1[1]) * tx) / (tl * Math.max(1, s.len * grow)), qc = [(q1[0] + q2[0]) / 2, (q1[1] + q2[1]) / 2, (q1[2] + q2[2]) / 2];
        const front = f > 0.1 && qc[2] > surf(qc[0], qc[1]) - 1.5; LS[front ? 2 : f < -0.01 ? 0 : 1].push([(qc[2] + qt[2]) / 2, 'M' + p2s(A1) + ' L' + p2s(Tp) + ' L' + p2s(A2), r2(SM(vis * 3))]); });
      const put = (pool, list) => { list.sort((a, b) => a[0] - b[0]); pool.forEach((el, i) => { const v = list[i]; const d = v ? v[1] : '', o = v ? v[2] : 1; if (el._d !== d) { el._d = d; set(el, 'd', d); } if (el._o !== o) { el._o = o; set(el, 'stroke-opacity', o); } }); };
      put(E.hog.pre, LS[0]); put(E.hog.post, LS[1]); put(E.hog.fs, LS[2]); set(E.hog.domeB, 'd', dB); set(E.hog.domeF, 'd', dF); }
    else if (E.mane && R.spk) { const K = R.spk, [cx0, cy0] = K.C, grow = 1 + clamp(P.wide, 0, 1) * 0.12, tris = [];
      const cY = Math.cos(yh), sY = Math.sin(yh), rot = v => { const x1 = v[0] * cY + v[2] * sY, z0 = -v[0] * sY + v[2] * cY; return [x1, v[1] * cp - z0 * sp, v[1] * sp + z0 * cp]; };
      for (const q of K.list) { const sT = Math.sin(q.th), ct2 = Math.cos(q.t), st2 = Math.sin(q.t), d = rot([sT * ct2, sT * st2, -Math.cos(q.th)]), tg = rot(q.th ? [-st2, ct2, 0] : [1, 0, 0]);
        const pr = (rr, ww) => headT(cx0 + d[0] * rr + tg[0] * ww, cy0 + d[1] * rr + tg[1] * ww);
        tris.push([d[2], pr(K.rb * 0.9, K.w), pr(K.rt * grow, 0), pr(K.rb * 0.9, -K.w)]); }
      tris.sort((a, b) => a[0] - b[0]); const pth = L => L.map(([z, a, b, c]) => 'M' + r2(a[0]) + ' ' + r2(a[1]) + ' L' + r2(b[0]) + ' ' + r2(b[1]) + ' L' + r2(c[0]) + ' ' + r2(c[1]) + 'Z').join(' ');
      set(E.mane, 'd', pth(tris.filter(t => t[0] < 0.18))); if (E.maneF) set(E.maneF, 'd', pth(tris.filter(t => t[0] >= 0.18))); }
    else if (E.mane) { const k = 1 + clamp(P.wide, 0, 1) * 0.1 + Math.max(0, sq) * 0.05, rp = 0.025 + clamp(P.wide, 0, 1) * 0.05, tt = now / 260, HC = D.mane.c || [HX, HY], T = D.mane.mode === 'body' ? glob : headT;
      set(E.mane, 'd', toD(R.mane, (x, y) => { const dx = x - HC[0], dy = y - HC[1], th = Math.atan2(dy, dx), m = k * (1 + rp * clamp(P.wide, 0, 1) * Math.sin(th * 7)); return T(HC[0] + dx * m, HC[1] + dy * m); })); }
    (E.hx || []).forEach((el, i) => set(el, 'd', toD(R.hx[i], wrapF)));
    if (E.crown.length) { const ang = ((P.earR - P.earL) * 0.25 - (I.ed || 0) * 2.5 + P.htilt * 0.3) * D2R, [bx, by] = D.crownBase, c = Math.cos(ang), sn = Math.sin(ang); E.crown.forEach((el, i) => set(el, 'd', toD(R.crown[i], (x, y) => { const vx = x - bx, vy = y - by; return sph(bx + vx * c - vy * sn, by + vx * sn + vy * c + Math.min(0, sq) * 2 + (D.crownDy || 0), D.crownZ != null ? D.crownZ : -3); }))); }
    if (E.pup.length) { const [pcx, pcy, pr] = D.pupC || [50, 71, 11], [BX, BY, BW, BH] = D.body, t = now / 1000; const pdt = I.pjT ? Math.min(0.05, (now - I.pjT) / 1000) : 0.016; I.pjT = now; I.pj = (I.pj || 0) + ((/dance/.test(I.cur.name) ? 1 : 0) - (I.pj || 0)) * Math.min(1, pdt * 5); const pj = SM(I.pj);
      const fb = pcy + pr - 1, td = Math.sin(t * 1.3) * 6 * (1 - pj) + Math.sin(t * Math.PI * 2) * 9 * pj + clamp(I.ed || 0, -4, 4) * 2, tl = td * D2R, ca = Math.cos(tl), sa = Math.sin(tl), sq = Math.sin(t * 2.6) * 0.03 * (1 - pj) - clamp(P.sq || 0, -0.3, 0.3) * 0.7 * pj + clamp(I.ld || 0, -6, 6) * 0.008, bl = (now % 3400) < 150 ? 0.12 : 1;
      E.pup.forEach((el, i) => { const h = D.pup[i], ea = h.ear ? -h.ear[2] * (5 + Math.sin(t * 2.6 - 0.9) * 5 * (1 - pj) + Math.abs(Math.sin(t * Math.PI * 2 - 0.6)) * 16 * pj + clamp(I.ld || 0, -6, 6) * 1.2) * D2R - td * 0.5 * D2R : 0, ec = Math.cos(ea), es = Math.sin(ea), cs = h.cheek ? 1 + pj * 0.18 : 1;
        if (h.shine || h.mouthLine || h.joy || h.cheek) set(el, 'opacity', r2(h.joy ? pj : h.cheek ? Math.min(1, (h.op || 1) + pj * 0.4) : (h.op || 1) * (1 - pj)));
        set(el, 'd', toD(R.pup[i], (x, y) => { if (h.eye) { const dy = y - h.eye[1]; y = h.eye[1] - pj * 0.5 + dy * (dy > 0 ? bl * (1 - 1.75 * pj) : bl); } if (h.joy) y = h.joy[1] + (y - h.joy[1]) * Math.max(0.05, pj); if (h.cheek) { x = h.cheek[0] + (x - h.cheek[0]) * cs; y = h.cheek[1] + (y - h.cheek[1]) * cs; }
          if (h.ear) { const p = x - h.ear[0], q = y - h.ear[1]; x = h.ear[0] + p * ec - q * es; y = h.ear[1] + p * es + q * ec; }
          const u0 = x - pcx, v0 = y - pcy, zp = Math.sqrt(Math.max(0, 1 - (u0 * u0 + v0 * v0) / (pr * pr))) * pr * 0.5; x = pcx + u0 * (1 - sq * 0.5); y = fb + (y - fb) * (1 + sq);
          const p = x - pcx, q = y - fb; x = pcx + p * ca - q * sa; y = fb + p * sa + q * ca;
          const dx = x - BX, v = clamp((y - BY) / BH, -1, 1), wc = BW * Math.sqrt(1 - v * v * 0.36), zb = Math.sqrt(Math.max(0, wc * wc - dx * dx)); return glob(BX + dx * cyb + (zb + zp) * syb, y); })); });
      set(I.pg.pup, 'opacity', r2(SM((cyb + 0.15) / 0.35))); }
    if (E.collar) { if (D.collar.head) { const T = D.tag || { x: 50, y: 66 }, fa = (-(I.ed || 0) * 4 + P.lean * 1.5 + P.htilt * 0.4 - (I.ld || 0) * 1.2 + Math.sin(now / 520) * 2) * D2R, ca = Math.cos(fa), sa = Math.sin(fa), fl = 1 + Math.sin(now / 430) * 0.05 + clamp(I.ld || 0, -10, 10) * 0.012;
      set(E.collar, 'd', toD(R.collar, (x, y) => { const u = (x - T.x) * fl, v = y - T.y; return face(T.x + u * ca - v * sa, T.y + u * sa + v * ca); })); set(E.collar, 'opacity', r2(zc(T.x, T.y))); }
      else if (D.collar.body) { const T = D.tag, cz = D.collar.z || 14, fa = (Math.sin(now / 520) * 3 + P.lean * 1.5 - (I.ld || 0) * 1.2) * D2R, ca = Math.cos(fa), sa = Math.sin(fa), fl = 1 + Math.sin(now / 430) * 0.05; set(E.collar, 'd', toD(R.collar, (x, y) => { const u = (x - T.x) * fl, v = y - T.y; return byw(T.x + u * ca - v * sa, T.y + u * sa + v * ca, cz); })); set(E.collar, 'opacity', r2(SM(bywZ(T.x, cz) / 4))); }
      else set(E.collar, 'd', toD(R.collar, glob)); }
    if (E.tag && D.collar.head) { const T = D.tag; set(E.tag, 'd', toD(ellS(T.x, T.y, T.r, T.r, 0, 8), face)); set(E.tag, 'opacity', r2(zc(T.x, T.y))); }
    else if (E.tag && D.collar.body) { const T = D.tag, cz = (D.collar.z || 14) + 0.5; set(E.tag, 'd', toD(ellS(T.x, T.y, T.r, T.r, 0, 8), (x, y) => byw(x, y, cz))); set(E.tag, 'opacity', r2(SM(bywZ(T.x, cz) / 4))); }
    else if (E.tag) { const T = D.tag, sw = (-(I.ed || 0) * 6 + Math.sin(now / 360) * 4 + P.lean * 2 - (I.ld || 0) * 1.5) * D2R, cz = 13, tx = T.x + Math.sin(sw) * T.r * 1.2, ty = T.y + (Math.cos(sw) - 1) * T.r, X = 50 + (tx - 50) * cyb + cz * syb; set(E.tag, 'd', toD(ellS(X, ty, T.r * (0.75 + 0.25 * Math.abs(cyb)), T.r, 0, 8), glob)); set(E.tag, 'opacity', r2(SM((-(tx - 50) * syb + cz * cyb) / 4))); }
    I.topW = headT(50, D.top); I.W.head = I.topW;
    // ground shadow shrinks as she leaves the floor
    const gl = Math.max(0, P.lift); set(I.shadow, 'cx', r2(50 + P.x + P.lean * 0.15)); set(I.shadow, 'cy', r2(G + 0.6)); set(I.shadow, 'rx', r2(25 * (1 + sq * 0.45) * (1 - gl / 70))); set(I.shadow, 'ry', r2(3.6 * (1 - gl / 90))); set(I.shadow, 'opacity', r2(0.2 * (1 - gl / 50)));
    // depth sort parts as she turns
    const order = Object.keys(keys).sort((a, b) => keys[a] - keys[b]), os = order.join();
    if (os !== I.order) { I.order = os; order.forEach(k => I.root.appendChild(I.pg[k])); }
  }

  // hedgehog quills: the front spike ring becomes the rim of a shell over the back; extra rows cover the back and everything turns with the body
  function hogBuild(D) {
    const M = D.mane, H = M.hog, C = M.c, zc = H.z != null ? H.z : -5, RZ = H.rz || 30, P = flat(parsePath(M.d), 1), ring = P.slice(1, P.length - 2), c0 = P[0], c1 = P[P.length - 2];
    const ang = p => Math.atan2(p[0] - C[0], C[1] - p[1]), rad = p => Math.hypot(p[0] - C[0], p[1] - C[1]), V = ring.filter((p, i) => i % 2 === 0), T = ring.filter((p, i) => i % 2 === 1);
    const prof = L => { const A = L.map(p => [ang(p), rad(p)]).sort((a, b) => a[0] - b[0]); return a => { if (a <= A[0][0]) return A[0][1]; for (let i = 1; i < A.length; i++) if (a <= A[i][0]) return lerp(A[i - 1][1], A[i][1], (a - A[i - 1][0]) / (A[i][0] - A[i - 1][0])); return A[A.length - 1][1]; }; };
    const rim = [c0, ...V, c1], rv0 = prof(rim), rt = prof(T), aE = Math.abs(ang(c0)), yc = (c0[1] + c1[1]) / 2;
    const rv = a => Math.abs(a) <= aE ? rv0(a) : (yc - C[1]) / Math.max(0.3, -Math.cos(a));
    // the rim is not flat: it starts forward on the forehead and sweeps back toward the bottom, so the quill line curves in side view
    const zr = a => zc + (H.zt != null ? H.zt : 9) * Math.max(0, Math.cos(a)) - (H.zb != null ? H.zb : 6) * Math.max(0, -Math.cos(a));
    const sh = (a, b, r, rz) => [C[0] + r * Math.cos(b) * Math.sin(a), C[1] - r * Math.cos(b) * Math.cos(a), zc - rz * Math.sin(b) + (zr(a) - zc) * Math.cos(b)], nrm = (a, b) => [Math.cos(b) * Math.sin(a), -Math.cos(b) * Math.cos(a), -Math.sin(b)];
    const A = rim.map(ang).concat([1, 2, 3].map(k => aE + k * (TAU - 2 * aE) / 4)), B = [0, 18, 36, 54, 72, 90].map(d => d * D2R);
    const G = B.map(b => A.map(a => sh(a, b, rv(a), RZ))), QN = B.slice(0, -1).map((b, j) => A.map((a, i) => { let a2 = A[(i + 1) % A.length]; if (a2 < a) a2 += TAU; return nrm((a + a2) / 2, (b + B[j + 1]) / 2); }));
    const sp = [];
    for (let k = 0; k < T.length; k++) { const b1 = V[k], b2 = V[k + 1], t = T[k], len = rad(t) - (rad(b1) + rad(b2)) / 2;
      sp.push({ b1: [b1[0], b1[1], zr(ang(b1))], b2: [b2[0], b2[1], zr(ang(b2))], t: [t[0], t[1], zr(ang(t)) - len * ((H.tilt != null ? H.tilt : 1) + 0.8 * Math.max(0, Math.cos(ang(t))))], n: nrm(ang(t), 0), len, i: sp.length }); }
    (H.rows || []).forEach(([bd, m, am]) => { const b = bd * D2R, full = am >= 180, stp = (full ? 360 : 2 * am) / m * D2R, a0 = full ? -Math.PI : -am * D2R;
      for (let j = 0; j < m; j++) { const a = a0 + (j + 0.5) * stp, da = stp / 2, len = Math.max(2, (rt(a) - rv(a)) * (H.lk || 0.9));
        sp.push({ b1: sh(a - da, b, rv(a - da), RZ), b2: sh(a + da, b, rv(a + da), RZ), t: sh(a, b, rv(a) + len, RZ + len), n: nrm(a, b), len, i: sp.length }); } });
    return { A, B, G, QN, sp: sp.map(s => Object.assign(s, { w: Math.hypot(s.b2[0] - s.b1[0], s.b2[1] - s.b1[1], s.b2[2] - s.b1[2]) / 2 })) };
  }

  const ALL = new Set(); let raf = 0, last = 0, UID = 0;
  function loop(now) { raf = ALL.size ? requestAnimationFrame(loop) : 0; const dt = clamp((now - (last || now - 16)) / 1000, 0.001, 1 / 20); last = now; ALL.forEach(I => { try { tick(I, now, dt); } catch (e) { if (!I.err) { I.err = 1; console.error('RiveRig', e); } } }); }
  const kick = () => { if (!raf) { last = 0; raf = requestAnimationFrame(loop); } };
  setInterval(() => { const n = performance.now(); if (ALL.size && n - last > 80) { const r = raf; raf = 0; if (r) cancelAnimationFrame(r); loop(n); } }, 50);

  function mount(host, key, opts) {
    opts = opts || {}; const D = DEFS[key] || DEFS.mittens, u = 'rv' + (++UID), now = performance.now();
    const I = { D, onState: opts.onState, cur: { name: 'idle', t0: now }, prev: null, shots: [], press: false, spinOff: 0, ptr: null, gl: [0, 0], glAt: now + 1200, blinkT: -1e9, blinkAt: now + 1500, dbl: false, hs: 0, lastSpin: null, queue: [], ctr: {}, ctT: {}, emL: {}, parts: [], fidgets: opts.fidgets !== false,
      flw: new Fol(1, 8), fex: new Fol(0, 22), fey: new Fol(0, 22), fhx: new Fol(0, 6.5), fhy: new Fol(0, 6.5), fp: new Fol(0, 14), fs: new Fol(0, 18, 0.55), fx: new Fol(0, 9, 0.6), fl: new Fol(0, 9, 0.6), fsp: new Fol(0, 7, 0.7) };
    const wrap = document.createElement('div'); wrap.style.cssText = 'position:relative;width:100%;height:100%;touch-action:none;cursor:pointer;user-select:none;-webkit-user-select:none;';
    host.innerHTML = ''; host.appendChild(wrap);
    const svg = mk('svg', { viewBox: '0 0 100 100', width: '100%', height: '100%' }); svg.style.cssText = 'position:absolute;inset:0;overflow:visible;pointer-events:none;'; wrap.appendChild(svg);
    if (!DEFS[key] && window.RiveGeneric) { I.generic = true; I.key = key; I.u = u; window.RiveGeneric.build(I, svg, key, { mk, ellS, toD, parsePath, ellAx, smoothD, SM, clamp, lerp, r2, D2R, TAU, Fol, earSec, flat, hull, closedD }); } else {
    I.key = key; const g = D.c.g; mk('defs', {}, svg).innerHTML =
      '<radialGradient id="g' + u + '" cx="38%" cy="30%" r="75%"><stop offset="0" stop-color="' + g[0] + '"/><stop offset="0.6" stop-color="' + g[1] + '"/><stop offset="1" stop-color="' + g[2] + '"/></radialGradient>' + (D.c.ge ? '<radialGradient id="ge' + u + '" cx="38%" cy="30%" r="75%"><stop offset="0" stop-color="' + D.c.ge[0] + '"/><stop offset="0.6" stop-color="' + D.c.ge[1] + '"/><stop offset="1" stop-color="' + D.c.ge[2] + '"/></radialGradient>' : '') +
      '<radialGradient id="ey' + u + '" cx="35%" cy="30%" r="70%"><stop offset="0" stop-color="#6b5470"/><stop offset="1" stop-color="#2a1a30"/></radialGradient>' +
      '<filter id="ft' + u + '" x="-15%" y="-15%" width="130%" height="130%">' + fabricFx() + '<feComposite in2="SourceGraphic" operator="in"/><feBlend in="SourceGraphic" mode="multiply"/></filter>' +
      '<clipPath id="fc' + u + '" clipPathUnits="userSpaceOnUse"><path/></clipPath>' + [0, 1].map(i => '<clipPath id="fk' + i + u + '" clipPathUnits="userSpaceOnUse"><path/></clipPath><clipPath id="ek' + i + u + '" clipPathUnits="userSpaceOnUse"><path/></clipPath>').join('') + '<clipPath id="ec0' + u + '" clipPathUnits="userSpaceOnUse"><path/></clipPath><clipPath id="ec1' + u + '" clipPathUnits="userSpaceOnUse"><path/></clipPath>';
    if (key !== 'mittens' && !D.mittensFrame && D.mouth && D.eyes && D.arms) { const pawY = (D.arms[0].e[1] + D.arms[1].e[1]) / 2, pawX = D.arms[0].e[0], MY = [17, 47, 58, 76, 95.5], CY = [D.top, D.eyes[0][1], D.mouth[1], pawY, D.G].map((v, i, a2) => i && v <= a2[i - 1] ? a2[i - 1] + 1 : v);
      const pl = (A, B, v) => { for (let i = 1; i < A.length; i++) if (v <= A[i] || i === A.length - 1) return B[i - 1] + (v - A[i - 1]) * (B[i] - B[i - 1]) / (A[i] - A[i - 1]); }, kx = Math.max(0.5, Math.abs(50 - pawX) / 18), mxk = Math.abs(50 - D.mouth[0]) < 1 ? 1 : 1;
      I.mapHand = (inX, hy) => [inX * kx, pl(MY, CY, 76 + hy) - pawY]; I.foodK = Math.max(0.05, Math.min(1.5, (pawY - D.mouth[1]) / 18)); I.toM = (x, y) => [50 + (x - D.head[0]) / D.head[2] * 29, pl(CY, MY, y)]; I.fromM = (x, y) => [D.head[0] + (x - 50) / 29 * D.head[2], pl(MY, CY, y)]; }
    const FUR = 'url(#g' + u + ')', CF = f => f ? String(f).replace(/url\(#([^)]+)\)/, 'url(#$1' + u + ')') : FUR;
    if (D.grads) svg.querySelector('defs').insertAdjacentHTML('beforeend', Object.keys(D.grads).map(id => '<radialGradient id="' + id + u + '" cx="38%" cy="30%" r="75%">' + D.grads[id].map(([o, c]) => '<stop offset="' + o + '" stop-color="' + c + '"/>').join('') + '</radialGradient>').join(''));
    if (D.mane && D.mane.hog) { const gs = (D.grads && D.grads[(String(D.mane.fill).match(/url\(#([^)]+)\)/) || [])[1]]) || [['0', '#a8794e'], ['1', '#5a3a22']]; svg.querySelector('defs').insertAdjacentHTML('beforeend', '<radialGradient id="hg' + u + '" gradientUnits="userSpaceOnUse" cx="40" cy="38" r="58">' + gs.map(([o, c]) => '<stop offset="' + o + '" stop-color="' + c + '"/>').join('') + '</radialGradient>'); }
    I.shadow = mk('ellipse', { fill: '#6a1b9a', opacity: 0.2 }, svg);
    I.root = mk('g', { filter: 'url(#ft' + u + ')' }, svg); I.pg = {}; I.u = u;
    ['mane', 'tail', 'footL', 'footR', 'body', 'earL', 'earR', 'head', 'maneF', 'collar', 'pup', 'prop', 'armL', 'armR'].forEach(k => I.pg[k] = mk('g', {}, I.root));
    const pg = I.pg, E = I.E = {};
    if (D.collar) { E.collar = mk('path', { fill: D.collar.fill }, pg.collar); E.tag = mk('path', { fill: D.tag.fill, stroke: '#ffffff', 'stroke-width': 0.8 }, pg.collar); }
    E.tail = mk('path', { fill: 'none', stroke: D.c.tail, 'stroke-width': 7, 'stroke-linecap': 'round', 'stroke-linejoin': 'round' }, pg.tail);
    E.tailH = mk('path', { fill: 'none', stroke: D.c.tailHL || '#ffd2a3', 'stroke-width': 2, 'stroke-linecap': 'round', opacity: 0.55 }, pg.tail);
    E.feet = [0, 1].map(i => { const p = pg[i ? 'footR' : 'footL']; return { f: mk('path', { fill: CF(D.c.foot) }, p), p: mk('path', { fill: D.c.pad, opacity: 0.9, 'clip-path': 'url(#fk' + i + u + ')' }, p), clip: svg.querySelector('#fk' + i + u + ' path') }; });
    if (D.mane) { const ma = { fill: CF(D.mane.fill), stroke: D.mane.stroke ? CF(D.mane.stroke) : 'none', 'stroke-width': D.mane.sw || 0, 'stroke-linejoin': 'round' }; E.mane = mk('path', ma, pg.mane); if (D.mane.spiky) E.maneF = mk('path', ma, pg.maneF); }
    E.body = mk('path', { fill: CF(D.c.body) }, pg.body); if (D.hideBody) E.body.style.display = 'none'; if (D.belly || D.bellyD) E.belly = mk('path', { fill: CF(D.bellyD ? D.bellyD.fill : D.belly[4]) }, pg.body); E.bodyG = mk('path', { fill: '#93b84a', opacity: 0 }, pg.body);
    E.ears = D.ears.map((ed, i) => { const p = pg[ed.side > 0 ? 'earR' : 'earL']; return { o: mk('path', { fill: ed.fill ? CF(ed.fill) : D.c.ge ? 'url(#ge' + u + ')' : FUR }, p), n: mk('path', { fill: CF(ed.innerFill || D.c.inner), opacity: ed.innerOp || 0.8, 'clip-path': 'url(#ek' + i + u + ')' }, p), clip: svg.querySelector('#ek' + i + u + ' path') }; });
    D.ears.forEach((ed, i) => { if (!ed.lobe) return; const m = mk('mask', { id: 'em' + i + u, maskUnits: 'userSpaceOnUse', x: -50, y: -50, width: 200, height: 200 }, svg.querySelector('defs')); mk('rect', { x: -50, y: -50, width: 200, height: 200, fill: '#fff' }, m); E.ears[i].mk = [mk('path', { fill: '#000' }, m), mk('path', { fill: '#000' }, m)]; pg[ed.side > 0 ? 'earR' : 'earL'].setAttribute('mask', 'url(#em' + i + u + ')'); });
    E.skull = mk('path', { fill: CF(D.c.head) }, pg.head); E.hx = (D.headExtra || []).map(h => mk('path', { fill: CF(h.fill), opacity: h.op || 1 }, pg.head));
    const face = mk('g', { 'clip-path': 'url(#fc' + u + ')' }, pg.head);
    E.muzzle = mk('path', { fill: D.c.muzzle }, face); (E.hx || []).forEach(el => face.insertBefore(el, E.muzzle)); E.tintR = mk('path', { fill: '#ff4040', opacity: 0 }, face); E.tintG = mk('path', { fill: '#93b84a', opacity: 0 }, face);
    E.stripes = mk('path', { fill: 'none', stroke: D.c.stripe, 'stroke-width': 2, 'stroke-linecap': 'round' }, face);
    E.back = mk('path', { fill: 'none', stroke: D.c.stripe, 'stroke-width': 2.2, 'stroke-linecap': 'round' }, face);
    E.fx = (D.faceExtra || []).map(fe => mk('path', fe.stroke && !fe.fill ? { fill: 'none', stroke: fe.stroke, 'stroke-width': fe.sw || 1, 'stroke-linecap': 'round' } : { fill: CF(fe.fill), stroke: fe.stroke || 'none', 'stroke-width': fe.sw || 0 }, face)); E.nose = mk('path', { fill: D.c.nose }, face); if (D.noseHL) E.noseHL = mk('path', { fill: '#ffffff' }, face);
    E.cheeks = [0, 1].map(() => mk('path', { fill: D.c.cheek }, face));
    E.eyes = [0, 1].map(i => { const gg = mk('g', {}, face), e = mk('path', { fill: 'url(#ey' + u + ')', stroke: '#2a1a30', 'stroke-linecap': 'round', 'stroke-linejoin': 'round' }, gg), hg = mk('g', { 'clip-path': 'url(#ec' + i + u + ')' }, gg);
      return { g: gg, e, tp: mk('path', { fill: '#a8dcff', opacity: 0 }, hg), h1: mk('path', { fill: '#fff' }, hg), h2: mk('path', { fill: '#fff' }, hg), clip: svg.querySelector('#ec' + i + u + ' path') }; });
    E.mopen = mk('path', { fill: '#7a2a40' }, face); E.tongue = mk('path', { fill: '#ff8fa3' }, face);
    E.mouth = mk('path', { fill: 'none', stroke: D.c.mouth, 'stroke-width': 1.2, 'stroke-linecap': 'round', 'stroke-linejoin': 'round' }, face);
    E.tout = mk('path', { fill: '#ff7f9a', stroke: '#e0607e', 'stroke-width': 0.3, opacity: 0 }, face);
    const wg = mk('g', { fill: 'none', stroke: D.c.whisker, 'stroke-width': 0.9, 'stroke-linecap': 'round' }, pg.head); E.wh = D.whiskers.map(() => mk('path', {}, wg));
    E.armT = [0, 1].map(i => mk('path', { fill: 'none', stroke: D.c.arm, 'stroke-linecap': 'round', opacity: 0 }, pg[i ? 'armR' : 'armL']));
    E.arms = [0, 1].map(i => mk('path', { fill: CF(D.c.armFill) }, pg[i ? 'armR' : 'armL']));
    E.crown = (D.crown || []).map(h => mk('path', { fill: CF(h.fill), stroke: h.stroke || 'none', 'stroke-width': h.sw || 0 }, pg.head)); E.pup = (D.pup || []).map(h => mk('path', h.stroke && !h.fill ? { fill: 'none', stroke: h.stroke, 'stroke-width': h.sw || 1, 'stroke-linecap': 'round' } : { fill: CF(h.fill), opacity: h.op || 1 }, pg.pup));
    if (!D.tail) pg.tail.style.display = 'none'; if (D.muzzle === null) E.muzzle.style.display = 'none'; if (D.nose === null) E.nose.style.display = 'none';
    E.clip = svg.querySelector('#fc' + u + ' path');
    I.fxG = mk('g', {}, svg);
    const [t0, t1, t2, t3] = D.tail || [[50, 85], [50, 85], [50, 85], [50, 85]], cub = (a, b, c, d, t) => { const m = 1 - t; return m * m * m * a + 3 * m * m * t * b + 3 * m * t * t * c + t * t * t * d; };
    I.RG = { body: D.bodyD ? parsePath(D.bodyD) : ellS(D.body[0], D.body[1], D.body[2], D.body[3], 0, 16), skull: D.headD ? parsePath(D.headD) : ellS(D.head[0], D.head[1], D.head[2], D.head[3] || D.head[2], 0, 16), muzzle: D.muzzle === null ? [] : ellS(...(D.muzzle || [50, 57, 16, 10]).slice(0, 4), 0, 12), mane: D.mane ? parsePath(D.mane.d) : null, spk: D.mane && D.mane.spiky ? (() => { const C = D.mane.c || [D.head[0], D.head[1]], P = flat(parsePath(D.mane.d), 1).map(p => [Math.atan2(p[1] - C[1], p[0] - C[0]), Math.hypot(p[0] - C[0], p[1] - C[1])]); const avg = P.reduce((a, q) => a + q[1], 0) / P.length, tips = P.filter(q => q[1] > avg), vals = P.filter(q => q[1] <= avg);
        const rt = tips.reduce((a, q) => a + q[1], 0) / tips.length, rb = vals.reduce((a, q) => a + q[1], 0) / vals.length, n = tips.length, th = tips.map(q => q[0]), list = [];
        [[90, 1, 0], [58, 0.8, 0.5], [28, 0.45, 0]].forEach(([tq, f, off]) => { const m = Math.max(3, Math.round(n * f)); for (let k = 0; k < m; k++) list.push({ th: tq * D2R, t: (k + off) / m * TAU + (f === 1 ? th[0] : 0) }); }); list.push({ th: 0, t: 0 }); return { C, rt, rb, w: rb * Math.sin(Math.PI / n) * 1.05, list }; })() : null, hx: (D.headExtra || []).map(h => parsePath(h.d)), crown: (D.crown || []).map(h => parsePath(h.d)), pup: (D.pup || []).map(h => parsePath(h.d)), nose: D.nose === null ? [] : ellS(...(D.nose || [50, 54, 2.6, 1.8]), 0, 8), noseHL: D.noseHL ? ellS(...D.noseHL, 0, 6) : null, belly: D.bellyD ? parsePath(D.bellyD.d) : D.belly ? ellS(D.belly[0], D.belly[1], D.belly[2], D.belly[3], 0, 12) : null, collar: D.collar ? parsePath(D.collar.d) : null,
      fx: (D.faceExtra || []).map(fe => parsePath(fe.d)), fxBig: (D.faceExtra || []).map(fe => { const P = parsePath(fe.d).flatMap(g => g.p || []), hx = D.head[0], hy = D.head[1], rx = D.head[2], ry = D.head[3] || D.head[2]; return P.some(p => Math.pow((p[0] - hx) / rx, 2) + Math.pow((p[1] - hy) / ry, 2) > 0.8); }), fxC: (D.faceExtra || []).map(fe => { const P = parsePath(fe.d).flatMap(g => g.p || []); return [P.reduce((a, p) => a + p[0], 0) / P.length, P.reduce((a, p) => a + p[1], 0) / P.length]; }),
      feet: D.feet.map(([x, y]) => ({ x, y })),
      ears: D.ears.map(e => { const vx = e.tip[0] - e.pivot[0], vy = e.tip[1] - e.pivot[1], len = Math.hypot(vx, vy), q = Object.assign({}, e, { o: parsePath(e.d), n: e.inner ? parsePath(e.inner) : null, ux: vx / len, uy: vy / len, len }); q.S = earSec(q, flat(q.o, 14)); return q; }),
      arms: D.arms.map(a => Object.assign({}, a, { s: ellS(a.e[0], a.e[1], a.e[2], a.e[3], a.e[4], 8) })),
      tail: Array.from({ length: 14 }, (_, i) => { const s = i / 13, ins = (1 - SM(s / 0.18)) * 3.2; return [cub(t0[0], t1[0], t2[0], t3[0], s) - ins, cub(t0[1], t1[1], t2[1], t3[1], s) + ins * 0.25, s, -9 - 9 * Math.pow(s, 0.9)]; }),
      stripes: parsePath(D.stripes), back: parsePath(D.back), wh: D.whiskers.map(parsePath) };
    if (D.mane && D.mane.hog) { I.RG.hog = hogBuild(D); const n = I.RG.hog.sp.length, HF = 'url(#hg' + u + ')', sa = { fill: HF, stroke: D.mane.stroke || 'none', 'stroke-width': D.mane.sw || 0, 'stroke-linejoin': 'round', 'stroke-linecap': 'round' }, pool = par => Array.from({ length: n }, () => mk('path', sa, par));
      E.mane.style.display = 'none'; E.hog = { pre: pool(pg.mane), domeB: mk('path', { fill: HF }, pg.mane), post: pool(pg.mane), domeF: mk('path', { fill: HF }, pg.maneF), fs: pool(pg.maneF) }; }
    }
    // touch: tap = poke, hold = squeeze, drag sideways = spin, hover = she watches
    const loc = e => { const r = wrap.getBoundingClientRect(); return { r, x: (e.clientX - r.left) / r.width * 100, y: (e.clientY - r.top) / r.height * 100 }; };
    wrap.addEventListener('pointermove', e => { const p = loc(e); I.ptr = { x: clamp((p.x - 50) / 42, -1, 1), y: clamp((p.y - 46) / 42, -1, 1) };
      if (I.down) { const dx = e.clientX - I.down.cx; if (!I.drag && !I.press && Math.abs(dx) > 10) { I.drag = true; clearTimeout(I.ht); I.spinTw = null; I.spin0 = I.spinOff; } if (I.drag) I.spinOff = I.spin0 + dx / p.r.width * 360; } });
    wrap.addEventListener('pointerleave', () => { I.ptr = null; });
    wrap.addEventListener('pointerdown', e => { try { wrap.setPointerCapture(e.pointerId); } catch (x) {} const p = loc(e), n = performance.now(); if (I.cur.name !== 'idle') setState(I, 'idle', n);
      I.down = { cx: e.clientX, x: p.x, y: p.y }; I.drag = false; clearTimeout(I.ht); I.ht = setTimeout(() => { if (I.down && !I.drag) { I.press = true; I.pressT = performance.now(); } }, 170); });
    const up = () => { if (!I.down) return; clearTimeout(I.ht); const n = performance.now();
      if (I.drag) I.spinTw = { from: I.spinOff, to: Math.round(I.spinOff / 360) * 360, t0: n, d: 650 };
      else if (I.press) { I.press = false; I.shots.push({ S: RELEASE, t0: n }); } else { const nm = 'poke_' + region(I, I.down.x, I.down.y); I.shots.push({ S: DENT, t0: n, x: I.down.x, y: I.down.y }); if (STATES[nm]) { const tp = STATES[nm].tap; STATES[nm].tap = null; setState(I, nm, n); STATES[nm].tap = tp; } else poke(I, I.down.x, I.down.y, n); }
      I.down = null; I.drag = false; };
    wrap.addEventListener('pointerup', up); wrap.addEventListener('pointercancel', up);
    ALL.add(I); kick(); tick(I, now, 0.016);
    return window.RiveRig._last = { play: n => setState(I, n, performance.now()), ext: o => { I.ext = o; }, destroy: () => { ALL.delete(I); clearTimeout(I.ht); host.innerHTML = ''; }, _pose: (name, t) => { const n = performance.now(); I.cur = { name, t0: n - t }; I.prev = null; I.shots = []; I.flw.v = 0; tick(I, n, 0.016); }, get state() { return I.cur.name; }, _I: I };
  }

  const FIDGETS = [];
  window.RiveRig = { v: 2, DEFS, mount, STATES, REST, FIDGETS, PRE, EZ, kv, r2, star4, clamp, SM, add: o => Object.assign(STATES, o), emit, tick1: I => { try { tick(I, performance.now(), 0.016); } catch (e) { if (!I.err) { I.err = 1; console.error('RiveRig', e); } } } };
})();
