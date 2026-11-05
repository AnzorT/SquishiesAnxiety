// DJ crew: builds an animated DJ version of a creature's front picture (boss shades, studio headset, one paw holding the ear cup,
// the other pumping the crowd, head bob + body bounce on a 120 BPM beat). Arms have a fixed length; they only rotate at the shoulder.
// window.DJCrew.get(key) -> data-URI (or null while the creature art loads); DJCrew.sub(fn) -> unsubscribe; fires when art arrives.
(function () {
  if (window.DJCrew) return;
  const f1 = n => (Math.round(n * 10) / 10).toString(), BEAT = 0.5;
  // anchors in the art's 0..100 viewBox: eyes (ey, ex = half gap, er), ear cups (cy, hw = half width), head top (ht), mouth (my),
  // neck (nk: head nods on its own), shoulders (sy, sx = half gap), clip = [y, x0, x1] hides the art's own side arms below y, c = arm colours
  const A = {
    mittens: { ey: 47, ex: 12, er: 5.4, cy: 46, hw: 29.5, ht: 16, my: 58, nk: 65, sy: 69, sx: 23, c: ['#ffd9a8', '#eba45e', '#a35a24'], bean: '#ff9fb0' },
    mochi: { ey: 62, ex: 10, er: 4.6, cy: 58, hw: 34.5, ht: 36, my: 69, sy: 71, sx: 36, c: ['#ffffff', '#f3e9ef', '#c4b0bd'] },
    boba: { ey: 50, ex: 10, er: 4.6, cy: 46, hw: 26.5, ht: 28, my: 56, sy: 59, sx: 25, clip: [40, 23.6, 76.4], c: ['#fff4e4', '#efd2a8', '#b48656'] },
    pip: { ey: 47, ex: 9, er: 4.8, cy: 44, hw: 31.5, ht: 16, my: null, sy: 57, sx: 30, clip: [50, 18.6, 81.4], c: ['#7484ad', '#3e4c78', '#1f2740'], flip: 1 },
    kiwi: { ey: 50, ex: 10, er: 4.6, cy: 46, hw: 34.5, ht: 23, my: 57, sy: 62, sx: 35, c: ['#b08a5e', '#8a6038', '#553a1e'] },
    floof: { ey: 53, ex: 9, er: 4.6, cy: 49, hw: 32, ht: 24, my: 60, sy: 64, sx: 30, clip: [57, 17.5, 82.5], c: ['#ffffff', '#e3e6f4', '#a3a9cb'] },
    gumdrop: { ey: 40, ex: 9, er: 4.5, cy: 39, hw: 24.5, ht: 16, my: 49.5, nk: 62, sy: 60, sx: 19, clip: [55, 28.6, 71.4], c: ['#ff9aa6', '#f04a5e', '#a81e34'] },
    mallow: { ey: 62, ex: 10, er: 4.6, cy: 58, hw: 37.5, ht: 32, my: 69, sy: 71, sx: 37, c: ['#fff4f7', '#f6d3de', '#c4919f'] },
  };
  const GEN = { ey: 48, ex: 11, er: 5, cy: 46, hw: 30, ht: 18, my: 57, sy: 66, sx: 28, c: ['#ffffff', '#dcdcdc', '#9a9a9a'] };
  const RAW = {}, OUT = {}, SUBS = new Set();
  const load = k => { if (RAW[k] !== undefined) return; RAW[k] = null;
    fetch((window.DJ_BASE || '') + 'export/tripo/' + k + '/' + k + '-front.svg').then(r => r.ok ? r.text() : Promise.reject(r.status)).then(t => {
      t = t.replace(/<metadata>[\s\S]*?<\/metadata>/, ''); const a = t.indexOf('>', t.indexOf('<svg')) + 1, b = t.lastIndexOf('</svg>'); RAW[k] = t.slice(a, b); SUBS.forEach(fn => fn(k)); })
      .catch(() => { RAW[k] = ''; }); };
  const spl = (vals, kt, d, extra) => ' values="' + vals + '" keyTimes="' + kt + '" calcMode="spline" keySplines="' + kt.split(';').slice(1).map(() => '0.45 0 0.55 1').join(';') + '" dur="' + d + 's" repeatCount="indefinite"' + (extra || '');
  const atr = (type, vals, kt, d, extra) => '<animateTransform attributeName="transform" type="' + type + '"' + spl(vals, kt, d, extra) + '/>';
  // R = region kept from the art: y < clip y, or inside the clip x range; returns rects for R within yA..yB
  const rects = (q, yA, yB) => { const r = (x, y, w, h) => h > 0 ? '<rect x="' + f1(x) + '" y="' + f1(y) + '" width="' + f1(w) + '" height="' + f1(h) + '"/>' : '';
    if (!q.clip) return r(-10, yA, 120, yB - yA); const [cy, x0, x1] = q.clip; return r(-10, yA, 120, Math.min(yB, cy) - yA) + r(x0, Math.max(yA, cy), x1 - x0, yB - Math.max(yA, cy)); };
  function arm(q, R, P, tk, kind) { const c = q.c, dx = P[0] - R[0], dy = P[1] - R[1], L = Math.hypot(dx, dy) || 1, ux = dx / L, uy = dy / L, nx = -uy, ny = ux, sg = nx + ny < 0 ? 1 : -1;
    const d = 'M' + f1(R[0]) + ' ' + f1(R[1]) + 'L' + f1(P[0]) + ' ' + f1(P[1]), hx = nx * sg * tk * 0.2, hy = ny * sg * tk * 0.2, pr = tk * (q.flip ? 0.55 : 0.66);
    let s = '<path d="' + d + '" stroke="' + c[2] + '" stroke-width="' + f1(tk + 1.2) + '" stroke-linecap="round" fill="none"/><path d="' + d + '" stroke="url(#djAg)" stroke-width="' + f1(tk) + '" stroke-linecap="round" fill="none"/>'
      + '<path d="M' + f1(R[0] + hx + ux * 2) + ' ' + f1(R[1] + hy + uy * 2) + 'L' + f1(P[0] + hx - ux * pr) + ' ' + f1(P[1] + hy - uy * pr) + '" stroke="' + c[0] + '" stroke-width="' + f1(tk * 0.32) + '" stroke-linecap="round" opacity="0.7" fill="none"/>';
    s += '<circle cx="' + f1(P[0]) + '" cy="' + f1(P[1]) + '" r="' + f1(pr) + '" fill="url(#djPw)" stroke="' + c[2] + '" stroke-width="0.6"/><ellipse cx="' + f1(P[0] - pr * 0.32) + '" cy="' + f1(P[1] - pr * 0.38) + '" rx="' + f1(pr * 0.34) + '" ry="' + f1(pr * 0.22) + '" fill="#ffffff" opacity="0.55"/>';
    if (!q.flip) { const ax = kind === 'fist' ? ux : -nx * sg, ay = kind === 'fist' ? uy : -ny * sg; // knuckle / finger creases face along the arm (fist) or toward the cup
      [-1, 0, 1].forEach(i => { const bx = P[0] + ax * pr * 0.55 + (-ay) * i * pr * 0.36, by = P[1] + ay * pr * 0.55 + ax * i * pr * 0.36; s += '<path d="M' + f1(bx - ax * pr * 0.32) + ' ' + f1(by - ay * pr * 0.32) + 'L' + f1(bx) + ' ' + f1(by) + '" stroke="' + c[2] + '" stroke-width="0.55" stroke-linecap="round" opacity="0.7"/>'; });
      if (q.bean && kind !== 'fist') s += '<ellipse cx="' + f1(P[0] - ax * pr * 0.1) + '" cy="' + f1(P[1] - ay * pr * 0.1) + '" rx="' + f1(pr * 0.3) + '" ry="' + f1(pr * 0.24) + '" fill="' + q.bean + '" opacity="0.8"/>'; }
    return s; }
  function build(k, raw) { const q = A[k] || GEN, c = q.c, er = q.er, xL = 50 - q.hw, xR = 50 + q.hw, ch = er * 1.65, cw = er * 1.25;
    let defs = '<g id="djC">' + raw + '</g>'
      + '<linearGradient id="djAg" x1="0" y1="0" x2="1" y2="1"><stop offset="0" stop-color="' + c[0] + '"/><stop offset="0.55" stop-color="' + c[1] + '"/><stop offset="1" stop-color="' + c[2] + '"/></linearGradient>'
      + '<radialGradient id="djPw" cx="36%" cy="32%" r="72%"><stop offset="0" stop-color="' + c[0] + '"/><stop offset="0.6" stop-color="' + c[1] + '"/><stop offset="1" stop-color="' + c[2] + '"/></radialGradient>'
      + '<radialGradient id="djCup" cx="34%" cy="30%" r="75%"><stop offset="0" stop-color="#5a5e6c"/><stop offset="0.5" stop-color="#26272f"/><stop offset="1" stop-color="#0c0c10"/></radialGradient>'
      + '<linearGradient id="djBand" x1="0" y1="0" x2="0" y2="1"><stop offset="0" stop-color="#4a4d5a"/><stop offset="0.5" stop-color="#1d1e25"/><stop offset="1" stop-color="#0c0c10"/></linearGradient>'
      + '<linearGradient id="djLens" x1="0" y1="0" x2="0.3" y2="1"><stop offset="0" stop-color="#3a3350"/><stop offset="0.55" stop-color="#14121c"/><stop offset="1" stop-color="#050508"/></linearGradient>'
      + '<linearGradient id="djGold" x1="0" y1="0" x2="0" y2="1"><stop offset="0" stop-color="#fff0b8"/><stop offset="0.5" stop-color="#e2b14a"/><stop offset="1" stop-color="#9a6a1a"/></linearGradient>'
      + '<filter id="djGl" x="-60%" y="-60%" width="220%" height="220%"><feGaussianBlur stdDeviation="0.9"/></filter>';
    const neck = q.nk != null;
    if (neck) defs += '<clipPath id="djBc" clipPathUnits="userSpaceOnUse">' + rects(q, q.nk - 1, 110) + '</clipPath><clipPath id="djHc" clipPathUnits="userSpaceOnUse">' + rects(q, -10, q.nk + 3) + '</clipPath>';
    else if (q.clip) defs += '<clipPath id="djBc" clipPathUnits="userSpaceOnUse">' + rects(q, -10, 110) + '</clipPath>';
    // headset: padded band over the crown, chrome sliders + yokes, big cups with a beat-pulsing ring light
    const yT = q.ht - 3.2, y0 = q.cy - ch * 0.9, yc = (4 * yT - y0) / 3, band = 'M' + f1(xL) + ' ' + f1(y0) + 'C' + f1(xL - 1) + ' ' + f1(yc) + ' ' + f1(xR + 1) + ' ' + f1(yc) + ' ' + f1(xR) + ' ' + f1(y0);
    let hs = '<path d="' + band + '" fill="none" stroke="#0c0c10" stroke-width="5.6" stroke-linecap="round"/><path d="' + band + '" fill="none" stroke="url(#djBand)" stroke-width="4.4" stroke-linecap="round"/>'
      + '<path d="' + band + '" fill="none" stroke="#6a6e7c" stroke-width="0.7" stroke-linecap="round" stroke-dasharray="1.4 1.2" opacity="0.8" transform="translate(0 -0.9)"/>'
      + '<path d="' + band + '" fill="none" stroke="#ffffff" stroke-width="0.9" stroke-linecap="round" pathLength="100" stroke-dasharray="0 22 56 22" opacity="0.3" transform="translate(0 -1.3)"/>';
    const cup = (x, side) => { const cx = x + side * 1.2; let s = '<path d="M' + f1(x - side * 0.6) + ' ' + f1(y0 - 1.6) + 'V' + f1(q.cy - ch * 0.55) + '" stroke="#d5dde2" stroke-width="1.6" stroke-linecap="round"/>'
        + '<path d="M' + f1(cx - cw * 0.95) + ' ' + f1(q.cy - ch * 0.25) + 'Q' + f1(cx - cw * 0.95) + ' ' + f1(q.cy - ch * 1.05) + ' ' + f1(cx) + ' ' + f1(q.cy - ch * 1.05) + 'Q' + f1(cx + cw * 0.95) + ' ' + f1(q.cy - ch * 1.05) + ' ' + f1(cx + cw * 0.95) + ' ' + f1(q.cy - ch * 0.25) + '" fill="none" stroke="#b9c0c8" stroke-width="0.9"/>'
        + '<ellipse cx="' + f1(cx - side * 1.1) + '" cy="' + f1(q.cy) + '" rx="' + f1(cw * 0.75) + '" ry="' + f1(ch * 0.96) + '" fill="#141418"/>'
        + '<ellipse cx="' + f1(cx) + '" cy="' + f1(q.cy) + '" rx="' + f1(cw) + '" ry="' + f1(ch) + '" fill="url(#djCup)" stroke="#07070a" stroke-width="0.7"/>'
        + '<ellipse cx="' + f1(cx) + '" cy="' + f1(q.cy) + '" rx="' + f1(cw * 0.66) + '" ry="' + f1(ch * 0.66) + '" fill="none" stroke="#d5dde2" stroke-width="0.7"/>'
        + '<ellipse cx="' + f1(cx) + '" cy="' + f1(q.cy) + '" rx="' + f1(cw * 0.66) + '" ry="' + f1(ch * 0.66) + '" fill="none" stroke="#3ff0ff" stroke-width="1.6" filter="url(#djGl)"><animate attributeName="opacity" values="1;0.35;1" dur="' + BEAT + 's" repeatCount="indefinite"/><animate attributeName="stroke" values="#3ff0ff;#ff4fb8;#ffe14f;#3ff0ff" dur="' + BEAT * 8 + 's" repeatCount="indefinite"/></ellipse>'
        + '<circle cx="' + f1(cx) + '" cy="' + f1(q.cy) + '" r="' + f1(er * 0.42) + '" fill="#202128" stroke="#5a5e6c" stroke-width="0.35"/><path d="M' + f1(cx - er * 0.2) + ' ' + f1(q.cy + er * 0.18) + 'L' + f1(cx) + ' ' + f1(q.cy - er * 0.26) + 'L' + f1(cx + er * 0.2) + ' ' + f1(q.cy + er * 0.18) + '" fill="none" stroke="#e2b14a" stroke-width="0.45"/>'
        + '<ellipse cx="' + f1(cx - cw * 0.35) + '" cy="' + f1(q.cy - ch * 0.5) + '" rx="' + f1(cw * 0.32) + '" ry="' + f1(ch * 0.2) + '" fill="#ffffff" opacity="0.32"/>';
      return s; };
    hs += cup(xL, -1) + cup(xR, 1);
    // boss shades: gold brow bar, dark gradient lenses with club-light reflections, temples into the cups
    const lw = er * 3, lh = er * 2.1, lens = cx => { const l = cx - lw / 2, r = cx + lw / 2, t = q.ey - lh * 0.45, b = q.ey + lh * 0.55;
      return 'M' + f1(l) + ' ' + f1(t) + 'H' + f1(r) + 'Q' + f1(r + 0.4) + ' ' + f1(b) + ' ' + f1(cx + lw * 0.18) + ' ' + f1(b) + 'H' + f1(cx - lw * 0.18) + 'Q' + f1(l - 0.4) + ' ' + f1(b) + ' ' + f1(l) + ' ' + f1(t) + 'Z'; };
    const lx = 50 - q.ex, rx = 50 + q.ex, tY = q.ey - lh * 0.45;
    let sh = '<path d="M' + f1(lx - lw / 2) + ' ' + f1(tY + 0.6) + 'L' + f1(xL + 1.5) + ' ' + f1(q.cy - 0.6) + 'M' + f1(rx + lw / 2) + ' ' + f1(tY + 0.6) + 'L' + f1(xR - 1.5) + ' ' + f1(q.cy - 0.6) + '" stroke="#16161c" stroke-width="1.1" stroke-linecap="round"/>';
    [lx, rx].forEach((cx, i) => { sh += '<path d="' + lens(cx) + '" fill="url(#djLens)" stroke="url(#djGold)" stroke-width="0.75"/>'
      + '<path d="M' + f1(cx - lw * 0.32) + ' ' + f1(tY + lh * 0.75) + 'L' + f1(cx - lw * 0.05) + ' ' + f1(tY + 0.5) + 'L' + f1(cx + lw * 0.12) + ' ' + f1(tY + 0.5) + 'L' + f1(cx - lw * 0.16) + ' ' + f1(tY + lh * 0.82) + 'Z" fill="#ffffff" opacity="0.28"/>'
      + '<ellipse cx="' + f1(cx + lw * 0.22) + '" cy="' + f1(q.ey + lh * 0.2) + '" rx="' + f1(lw * 0.13) + '" ry="' + f1(lh * 0.1) + '" fill="#3ff0ff" opacity="0.6"><animate attributeName="fill" values="#3ff0ff;#ff4fb8;#ffe14f;#3ff0ff" dur="' + BEAT * 8 + 's" begin="' + (-i * BEAT * 2) + 's" repeatCount="indefinite"/></ellipse>'; });
    sh += '<path d="M' + f1(lx - lw / 2 - 0.4) + ' ' + f1(tY) + 'H' + f1(rx + lw / 2 + 0.4) + '" stroke="url(#djGold)" stroke-width="1.5" stroke-linecap="round"/><path d="M' + f1(lx + lw / 2) + ' ' + f1(tY + 1.2) + 'Q50 ' + f1(tY - 0.6) + ' ' + f1(rx - lw / 2) + ' ' + f1(tY + 1.2) + '" fill="none" stroke="url(#djGold)" stroke-width="0.9"/>';
    // party face: open happy smile that sings along on the beat
    let mo = ''; if (q.my != null) { const w = er * 0.78, my = q.my;
      mo = '<g transform="translate(50 ' + f1(my - 1) + ')"><g>' + atr('scale', '1 1;1 0.72;1 1', '0;0.5;1', BEAT) + '<path d="M' + f1(-w) + ' 0Q0 ' + f1(w * 1.55) + ' ' + f1(w) + ' 0Q0 ' + f1(w * 0.28) + ' ' + f1(-w) + ' 0Z" fill="#5c1f30" stroke="#3a1420" stroke-width="0.35"/>'
        + '<ellipse cx="0" cy="' + f1(w * 0.68) + '" rx="' + f1(w * 0.5) + '" ry="' + f1(w * 0.28) + '" fill="#ff7f9a"/></g></g>'; }
    // arms (fixed length, rotate only at the shoulder): the raised arm starts behind the body so only the forearm + fist poke out high beside the head;
    // the other arm holds the right ear cup in front
    const tk = q.flip ? 8.4 : 9.6, R1 = [50 - q.sx * 0.78, q.sy - 6], P1 = [xL - 4.5, q.ht + 3], R2 = [50 + q.sx, q.sy], P2 = [xR + 2.6, q.cy + ch * 0.45];
    const pump = '<g>' + atr('rotate', '0 ' + f1(R1[0]) + ' ' + f1(R1[1]) + ';9 ' + f1(R1[0]) + ' ' + f1(R1[1]) + ';0 ' + f1(R1[0]) + ' ' + f1(R1[1]), '0;0.32;1', BEAT) + arm(q, R1, P1, tk, 'fist') + '</g>';
    const hold = arm(q, R2, P2, tk, 'cup');
    const use = cp => '<use href="#djC"' + (cp ? ' clip-path="url(#' + cp + ')"' : '') + '/>';
    const nod = neck ? '<g>' + atr('translate', '0 0;0 2;0 0', '0;0.45;1', BEAT, ' begin="-0.06s"') + '<g>' + atr('rotate', '0 50 ' + q.nk + ';-3 50 ' + q.nk + ';0 50 ' + q.nk + ';3 50 ' + q.nk + ';0 50 ' + q.nk, '0;0.25;0.5;0.75;1', BEAT * 4) : '<g><g>';
    let body = pump + (neck ? use('djBc') : use(q.clip ? 'djBc' : ''));
    body += nod + (neck ? use('djHc') : '') + mo + hs + sh + hold + '</g></g>';
    // whole-body groove: squash-bounce on every beat + a slow side lean (pivot at the feet)
    const svg = '<svg xmlns="http://www.w3.org/2000/svg" viewBox="-10 -10 120 120" width="240" height="240"><defs>' + defs + '</defs>'
      + '<g transform="translate(50 96)"><g>' + atr('scale', '1 1;1.025 0.965;1 1', '0;0.4;1', BEAT) + '<g>' + atr('rotate', '0;-2.5;0;2.5;0', '0;0.25;0.5;0.75;1', BEAT * 4) + '<g transform="translate(-50 -96)">' + body + '</g></g></g></g></svg>';
    return 'data:image/svg+xml,' + encodeURIComponent(svg); }
  window.DJCrew = {
    get(k) { if (OUT[k]) return OUT[k]; load(k); const raw = RAW[k]; if (!raw) return null; try { OUT[k] = build(k, raw); } catch (e) { console.warn('dj crew', k, e); OUT[k] = null; } return OUT[k]; },
    sub(fn) { SUBS.add(fn); return () => SUBS.delete(fn); }, A,
  };
})();
