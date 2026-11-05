// Club atmosphere FX: tiered fog / haze / CO2 / mist / bubbles / confetti, spawned as DOM puffs into an fx layer.
// ClubFog.toggle(key, getAnchor, cfg) -> on?  getAnchor() -> { el, pts: [{x,y}], fl: {x,y}, dir: [dx,dy], s } (px, relative to el) or null.
// cfg: { t: tier 1-5, style: jet|haze|up|mist|ring|bubble, tint: [hex], confetti: {x,y} | null }.
// Higher tiers: more puffs per second, bigger, denser, longer life, a ground fog bank and a longer linger after switching off.
(function () {
  if (window.ClubFog) return;
  const TIER = {
    1: { rate: 0, size: [0, 0], life: 4.6, op: 0, spd: 0, bank: 0, linger: 0.4, dim: 0, bub: 6 },
    2: { rate: 4, size: [24, 42], life: 3.6, op: 0.5, spd: 70, bank: 0, linger: 1.2, dim: 0.1, bub: 0 },
    3: { rate: 7, size: [34, 62], life: 6, op: 0.56, spd: 52, bank: 0.32, linger: 6, dim: 0.18, bub: 0 },
    4: { rate: 10, size: [42, 80], life: 7.6, op: 0.62, spd: 48, bank: 0.44, linger: 9, dim: 0.24, bub: 0 },
    5: { rate: 14, size: [56, 104], life: 10.5, op: 0.7, spd: 38, bank: 0.56, linger: 14, dim: 0.3, bub: 3 },
  };
  const ON = new Map(), CAP = 170;
  const R = (a, b) => a + Math.random() * (b - a), pick = a => a[Math.floor(Math.random() * a.length)];
  const hexA = (h, a) => { const n = parseInt(h.slice(1), 16); return 'rgba(' + (n >> 16 & 255) + ',' + (n >> 8 & 255) + ',' + (n & 255) + ',' + a.toFixed(3) + ')'; };
  const tr = (x, y, s, r) => 'translate(' + x.toFixed(1) + 'px,' + y.toFixed(1) + 'px) scale(' + s.toFixed(3) + ')' + (r ? ' rotate(' + r.toFixed(0) + 'deg)' : '');
  const mk = (box, css) => { const d = document.createElement('div'); d.className = 'cfog'; d.style.cssText = 'position:absolute;left:0;top:0;pointer-events:none;will-change:transform,opacity;' + css; box.appendChild(d); return d; };
  const busy = box => box.childElementCount > CAP;
  const run = (el, k, ms, ease) => { const a = el.animate(k, { duration: ms, easing: ease || 'cubic-bezier(0.22,0.6,0.35,1)', fill: 'forwards' }); a.onfinish = () => el.remove(); return a; };

  function puff(job, A) {
    const t = job.T, s = A.s, st = job.cfg.style || 'jet', q = pick(A.pts), sz = R(t.size[0], t.size[1]) * s, life = t.life * R(0.8, 1.15) * 1000;
    const col = pick(job.cfg.tint), op = t.op * R(0.7, 1), h = sz / 2;
    const el = mk(A.el, 'width:' + sz.toFixed(0) + 'px;height:' + sz.toFixed(0) + 'px;border-radius:50%;background:radial-gradient(closest-side,' + hexA(col, op) + ' 0%,' + hexA(col, op * 0.6) + ' 42%,' + hexA(col, op * 0.18) + ' 72%,' + hexA(col, 0) + ' 100%);');
    const x0 = q.x - h, y0 = q.y - h, d = A.dir, px = -d[1], py = d[0], sp = t.spd * s * t.life;
    let k, ease;
    if (st === 'jet') { const a = R(-0.4, 0.4), L = sp * R(0.45, 0.75);
      k = [{ transform: tr(x0, y0, 0.22), opacity: 0 }, { transform: tr(x0 + d[0] * L * 0.5 + px * a * L * 0.25, y0 + d[1] * L * 0.5 + py * a * L * 0.25, 0.9), opacity: 1, offset: 0.16 },
        { transform: tr(x0 + d[0] * L + px * a * L * 0.8, y0 + d[1] * L + py * a * L * 0.8 - L * 0.16, 2.1), opacity: 0 }]; }
    else if (st === 'haze') { const L = sp * R(0.35, 0.7), ex = R(-1, 1) * L, ey = -R(0.05, 0.35) * L;
      k = [{ transform: tr(x0, y0, 0.3), opacity: 0 }, { transform: tr(x0 + d[0] * L * 0.4 + ex * 0.3, y0 + d[1] * L * 0.3 + ey * 0.3, 1), opacity: 1, offset: 0.2 }, { transform: tr(x0 + d[0] * L * 0.6 + ex, y0 + d[1] * L * 0.2 + ey, 2.4), opacity: 0 }]; }
    else if (st === 'up') { const H = 150 * s * R(0.8, 1.2), jx = R(-8, 8) * s;
      k = [{ transform: tr(x0, y0, 0.18), opacity: 0 }, { transform: tr(x0 + jx, y0 - H * 0.55, 0.85), opacity: 1, offset: 0.14 }, { transform: tr(x0 + jx * 4, y0 - H, 2.3), opacity: 0 }]; ease = 'cubic-bezier(0.1,0.8,0.3,1)'; }
    else if (st === 'ring' || st === 'mist') { const a = R(0, Math.PI * 2), L = sp * R(0.3, 0.6), up = st === 'mist' ? R(0.15, 0.45) : 0.05, sw = R(-0.6, 0.6);
      k = [{ transform: tr(x0 + Math.cos(a) * 6 * s, y0 + Math.sin(a) * 2 * s, 0.3), opacity: 0 }, { transform: tr(x0 + Math.cos(a + sw) * L * 0.45, y0 + Math.sin(a + sw) * L * 0.16 - L * up * 0.5, 1), opacity: 1, offset: 0.2 },
        { transform: tr(x0 + Math.cos(a) * L, y0 + Math.sin(a) * L * 0.34 - L * up, 2.3), opacity: 0 }]; }
    else return;
    run(el, k, life, ease);
  }
  function bubble(job, A, small) {
    const s = A.s, q = pick(A.pts), sz = R(small ? 6 : 9, small ? 12 : 20) * s, h = sz / 2, d = A.dir, px = -d[1], py = d[0], L = R(70, 150) * s, life = R(3.2, 5.2) * 1000, w = R(4, 10) * s * (Math.random() < 0.5 ? -1 : 1);
    const el = mk(A.el, 'width:' + sz.toFixed(0) + 'px;height:' + sz.toFixed(0) + 'px;border-radius:50%;box-shadow:inset 0 0 0 ' + Math.max(1, sz * 0.06).toFixed(1) + 'px rgba(255,255,255,0.75), inset ' + (sz * 0.12).toFixed(1) + 'px ' + (-sz * 0.1).toFixed(1) + 'px ' + (sz * 0.2).toFixed(1) + 'px rgba(120,220,255,0.45), inset ' + (-sz * 0.1).toFixed(1) + 'px ' + (sz * 0.12).toFixed(1) + 'px ' + (sz * 0.2).toFixed(1) + 'px rgba(255,140,220,0.4);background:radial-gradient(circle at 32% 28%, rgba(255,255,255,0.95) 0 9%, rgba(255,255,255,0) 24%), radial-gradient(circle, rgba(200,240,255,0.06) 60%, rgba(255,255,255,0.18) 100%);');
    const P = f => { const ux = d[0] * L * f + px * Math.sin(f * 6.3) * w, uy = d[1] * L * f + py * Math.sin(f * 6.3) * w - L * 0.55 * Math.pow(f, 1.25); return [q.x - h + ux, q.y - h + uy]; };
    const k = [0, 0.25, 0.5, 0.75, 0.93].map((f, i) => { const [x, y] = P(f); return { transform: tr(x, y, i ? 1 : 0.4), opacity: i ? 0.95 : 0, offset: f }; });
    const e = P(0.93); k.push({ transform: tr(e[0], e[1], 1.35), opacity: 0, offset: 1 });
    run(el, k, life, 'linear');
  }
  const CONF = ['#ff4f6a', '#ffd84f', '#3ff0ff', '#7dff6a', '#b04bff', '#ffffff', '#ff9d3c'];
  function confetti(job, A) { const c = A.cf; if (!c) return; const s = A.s;
    for (let i = 0; i < 22; i++) { const w = R(3, 6) * s, hh = w * R(0.45, 0.7), vx = R(-70, 70) * s, H = R(110, 190) * s, life = R(2.2, 3.4) * 1000;
      const el = mk(A.el, 'width:' + w.toFixed(0) + 'px;height:' + hh.toFixed(0) + 'px;border-radius:1px;background:' + pick(CONF) + ';');
      run(el, [{ transform: tr(c.x, c.y, 0.6, 0), opacity: 1 }, { transform: tr(c.x + vx * 0.6, c.y - H, 1, R(200, 500)), opacity: 1, offset: 0.32 }, { transform: tr(c.x + vx, c.y - H * 0.35 + R(0, 50) * s, 1, R(700, 1200)), opacity: 0 }], life, 'cubic-bezier(0.15,0.75,0.4,1)'); } }
  function layers(job, A) { const t = job.T, s = A.s, f = A.fl || A.pts[0];
    if (t.dim) { job.dim = mk(A.el, 'inset:0;width:auto;height:auto;background:radial-gradient(ellipse at ' + f.x.toFixed(0) + 'px ' + f.y.toFixed(0) + 'px, rgba(24,18,48,' + (t.dim * 0.55).toFixed(2) + '), rgba(12,10,26,' + t.dim.toFixed(2) + ') 70%);opacity:0;transition:opacity 1.6s;');
      requestAnimationFrame(() => { if (job.dim) job.dim.style.opacity = '1'; }); }
    if (t.bank) { const w = (150 + job.cfg.t * 40) * s, h = w * 0.3, col = job.cfg.tint[0];
      job.bank = mk(A.el, 'width:' + w.toFixed(0) + 'px;height:' + h.toFixed(0) + 'px;border-radius:50%;left:' + (f.x - w / 2).toFixed(0) + 'px;top:' + (f.y - h * 0.6).toFixed(0) + 'px;opacity:0;transition:opacity 3s;background:radial-gradient(closest-side,' + hexA(col, t.bank) + ' 0%,' + hexA(col, t.bank * 0.7) + ' 45%,' + hexA(col, 0) + ' 100%);');
      job.bank.animate([{ transform: 'translateX(-4%) scale(1,1)' }, { transform: 'translateX(4%) scale(1.14,1.08)' }], { duration: 5200, direction: 'alternate', iterations: Infinity, easing: 'ease-in-out' });
      requestAnimationFrame(() => { if (job.bank) job.bank.style.opacity = '1'; }); } }
  function fadeOut(el, ms) { if (!el) return; el.style.transition = 'opacity ' + ms + 'ms ease-in'; el.style.opacity = '0'; setTimeout(() => el.remove(), ms + 80); }

  function start(key, getA, cfg) {
    stop(key, true); const T = TIER[Math.max(1, Math.min(5, cfg.t | 0))] || TIER[2];
    const job = { key, getA, cfg: Object.assign({}, cfg, { tint: (cfg.tint && cfg.tint.length) ? cfg.tint : ['#f4f6fa'], style: cfg.style || 'jet' }), T, acc: 0, bacc: 0, t0: performance.now(), miss: 0 };
    const A0 = getA(); if (!A0) return false; layers(job, A0);
    job.iv = setInterval(() => { const A = getA(); if (!A || !A.el.isConnected) { if (++job.miss > 4) stop(key, true); return; } job.miss = 0;
      const el = (performance.now() - job.t0) / 1000; let rate = T.rate;
      if (job.cfg.style === 'up') { const ph = el % 2.4; rate = ph < 0.7 ? T.rate * 3.2 : T.rate * 0.12; if (A.cf && ph < 0.1 && !job.cfDone) { job.cfDone = 1; confetti(job, A); } if (ph > 0.2) job.cfDone = 0; }
      if (busy(A.el)) return; const now = performance.now(), dt = Math.min(0.5, (now - (job.last || now - 100)) / 1000); job.last = now;
      job.acc += rate * dt; while (job.acc >= 1) { job.acc -= 1; puff(job, A); }
      job.bacc += T.bub * dt; while (job.bacc >= 1) { job.bacc -= 1; bubble(job, A, cfg.t > 1); } }, 100);
    ON.set(key, job); return true;
  }
  function stop(key, quick) { const job = ON.get(key); if (!job) return; clearInterval(job.iv); ON.delete(key);
    const ms = quick ? 300 : Math.round(job.T.linger * 1000); fadeOut(job.bank, ms); fadeOut(job.dim, Math.max(600, ms * 0.7)); }
  function toggle(key, getA, cfg) { if (ON.has(key)) { stop(key); return false; } return start(key, getA, cfg); }
  window.ClubFog = { toggle, start, stop, isOn: k => ON.has(k), stopAll: pre => [...ON.keys()].forEach(k => { if (!pre || k.startsWith(pre)) stop(k, true); }), TIER };
})();
