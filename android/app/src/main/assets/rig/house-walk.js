// Squad House walks: every creature's own gait, driven per frame through the rig's ext channels (no rig states, so it blends with whatever he is doing).
// HouseWalk.step(key, st, E, w, dt, spd, spin): st = per-creature memory (phase, fx timers), E = ext object (ADDS to it), w = walk weight 0..1 (fades to rest),
// spd = phase speed (0 = frozen while he stops), spin = facing deg (0 = camera, 90 = walking right). Returns { v: speed multiplier this frame, fx: particle kind or null }.
// Profiles (house-walk-c.js): HouseWalk.def(key, { g: gait, a: size, r: tempo, x: { ch: [amp, harmonic, phase, abs] }, c: { ch: value }, m: { ch: scale }, fx: [kind, ms], dust, wing }).
(function () {
  const TAU = Math.PI * 2, PI = Math.PI, S = Math.sin, C = Math.cos, ab = Math.abs, pos = x => x > 0 ? x : 0, pw = (x, k) => Math.pow(ab(x), k);
  // jump cycle: air from a to b (u = 0..1 per cycle), ground the rest (wraps)
  const jmp = (p, a, b) => { const u = ((p / TAU) % 1 + 1) % 1; if (u > a && u < b) { const au = (u - a) / (b - a); return { air: S(PI * au), au, gb: 0 }; } return { air: 0, au: -1, gb: S(PI * (((u - b + 1) % 1) / (1 - b + a))) }; };
  const G = {
    // four-paw plush trot: quick steps, springy bob, head counter-tilt, tail swish
    trot: { r: 1, dl: 2, f(p, A, o) { const s = S(p); o.footL = 2.6 * A * pos(s); o.footR = 2.6 * A * pos(-s); o.armL = 12 * A * s; o.armR = -12 * A * s; o.tilt = 2.2 * A * s; o.lift = 2.6 * A * ab(s); o.sq = 0.035 * A * pw(C(p), 6) - 0.02 * A * ab(s); o.htilt = -2.5 * A * s; o.pitch = 0.04; o.wag = 12 * S(2 * p); } },
    // side-to-side rock over each foot, arms held out a little
    waddle: { r: 0.72, dl: 1, f(p, A, o) { const s = S(p); o.tilt = 7 * A * s; o.x = 1.1 * A * s; o.footL = 1.9 * A * pos(s); o.footR = 1.9 * A * pos(-s); o.armL = 16 * A + 8 * A * s; o.armR = 16 * A - 8 * A * s; o.lift = 1.3 * A * ab(s); o.htilt = -4 * A * s; o.sq = 0.03 * A * pw(C(p), 6); return { v: 0.8 + 0.4 * ab(s) }; } },
    // two-foot bunny hops: crouch, spring up stretched, feet tuck, squash on landing
    hop: { r: 0.6, dl: 2, f(p, A, o) { const j = jmp(p, 0.2, 0.8); o.lift = 14 * A * j.air; o.sq = 0.12 * A * j.gb - 0.07 * A * j.air; o.footL = o.footR = 2 * A * j.air; o.armL = o.armR = 20 * A * j.air; o.pitch = j.au >= 0 ? -0.05 * C(PI * j.au) : 0.03 * j.gb; return { v: j.au >= 0 ? 1.5 : 0.18, land: j.gb }; } },
    // round blob boing: big squash and stretch, no feet
    bounce: { r: 0.7, dl: 1.5, f(p, A, o) { const j = jmp(p, 0.22, 0.78); o.lift = 12 * A * j.air; o.sq = 0.2 * A * j.gb - 0.09 * A * j.air; o.armL = o.armR = 18 * A * j.air; o.tilt = 3 * A * S(2 * p); o.htilt = 2 * A * S(2 * p + 1); return { v: j.au >= 0 ? 1.5 : 0.22, land: j.gb }; } },
    // hovering drift: slow bob, lean into the drift, little paddling paws
    float: { r: 0.42, dl: 4, f(p, A, o) { const s = S(p); o.lift = 3 + 2.5 * A * s; o.x = 0.8 * A * S(p + 0.8); o.tilt = 2.5 * A * S(p + 0.8); o.armL = 6 + 7 * A * S(2 * p); o.armR = 6 + 7 * A * S(2 * p + PI); o.pitch = 0.06; o.sq = 0.025 * A * S(2 * p); } },
    // flying: lifts off, bobs with the wingbeats (arm-wings flap)
    flutter: { r: 0.55, dl: 5, f(p, A, o, P) { const s = S(p); o.lift = A * (9 + 3 * S(2 * p)); o.tilt = 2 * A * s; o.pitch = 0.07; o.footL = o.footR = 0.8; if (P.wing === 'own') { o.armL = 8 + 5 * S(2 * p); o.armR = 8 + 5 * S(2 * p + PI); } else { o.armL = o.armR = 34 + 30 * S(6 * p); } o.sq = -0.03 * S(6 * p); } },
    // sea creature on land: belly galumph, flippers push, tail flicks
    galumph: { r: 0.55, dl: 1.5, f(p, A, o) { const j = jmp(p, 0.3, 0.75); o.lift = 6 * A * j.air; o.sq = 0.14 * A * j.gb - 0.04 * A * j.air; o.pitch = 0.06 * j.gb - 0.08 * j.air; o.armL = o.armR = 8 + 16 * A * j.air; o.wag = 18 * A * S(p + 1.2); return { v: 0.4 + 1.3 * j.air, land: j.gb }; } },
    // rigid little totter: fast short steps, rocking side to side
    shuffle: { r: 1.35, dl: 1, f(p, A, o) { const s = S(p); o.tilt = 4.5 * A * s; o.footL = 1.4 * A * pos(s); o.footR = 1.4 * A * pos(-s); o.lift = 1.2 * A * ab(s); o.armL = 7 * A * s; o.armR = -7 * A * s; o.htilt = -2 * A * s; o.sq = 0.02 * A * pw(C(p), 4); } },
    // heavy steps: big foot lifts, squash on every footfall
    stomp: { r: 0.62, dl: 1, f(p, A, o) { const s = S(p), c = pw(C(p), 8); o.footL = 3.4 * A * pos(s); o.footR = 3.4 * A * pos(-s); o.tilt = 4 * A * s; o.lift = 2.6 * A * ab(s); o.sq = 0.07 * A * c; o.armL = 16 * A * s; o.armR = -16 * A * s; o.htilt = -3 * A * s; o.pitch = 0.03; return { land: c }; } },
    // dainty high steps, chin up, paws out
    prance: { r: 0.9, dl: 1.5, f(p, A, o) { const s = S(p), k = pw(s, 0.7); o.footL = 3.4 * A * Math.pow(pos(s), 0.7); o.footR = 3.4 * A * Math.pow(pos(-s), 0.7); o.lift = 3.6 * A * k; o.armL = 20 * A + 5 * A * s; o.armR = 20 * A - 5 * A * s; o.pitch = -0.05; o.htilt = 3 * A * S(2 * p); o.tilt = 1.5 * A * s; o.sq = 0.02 * A * pw(C(p), 6) - 0.03 * A * k; } },
    // skip-hop: a little hop on every step, big arm swings
    skip: { r: 0.8, dl: 2, f(p, A, o) { const s = S(p), k = pw(s, 0.6); o.lift = 6 * A * k; o.footL = 3 * A * pos(s); o.footR = 3 * A * pos(-s); o.armL = 24 * A * s; o.armR = -24 * A * s; o.tilt = 3 * A * s; o.sq = 0.06 * A * pw(C(p), 8) - 0.04 * A * k; o.htilt = 3 * A * s; } },
    // tiny fast scurry, body low and leaning in
    scurry: { r: 1.9, dl: 2.5, f(p, A, o) { const s = S(p); o.footL = 1.3 * A * pos(s); o.footR = 1.3 * A * pos(-s); o.lift = 1.1 * A * ab(s); o.tilt = 1.5 * A * s; o.armL = 6 + 4 * A * s; o.armR = 6 - 4 * A * s; o.pitch = 0.06; o.sq = 0.03; return { v: 1.1 }; } },
    // slow plod (turtle): heavy little steps, neck bobs with each one
    plod: { r: 0.45, dl: 0.5, f(p, A, o) { const s = S(p); o.footL = 1.7 * A * pos(s); o.footR = 1.7 * A * pos(-s); o.armL = 8 * A * -s; o.armR = 8 * A * s; o.tilt = 2.5 * A * s; o.lift = 0.8 * A * ab(s); o.pitch = 0.03; return { v: 0.75 }; } },
    // octopus crawl: arms ripple, body rolls along on them
    crawl: { r: 0.6, dl: 1.5, f(p, A, o) { const s = S(p); o.lift = 2 * A * ab(s); o.tilt = 2.2 * A * s; o.x = 0.6 * A * s; o.sq = 0.04 * A * S(2 * p); o.armL = 10 + 12 * A * s; o.armR = 10 - 12 * A * s; o.footL = 1.2 * A * pos(s); o.footR = 1.2 * A * pos(-s); } },
    // zombie shuffle: arms out front, feet drag, head lolls
    zombie: { r: 0.5, dl: 0.5, f(p, A, o) { const s = S(p); o.armL = 84 + 4 * S(2 * p); o.armR = 84 + 4 * S(2 * p + 1); o.htilt = 7 * A * s; o.tilt = 5 * A * s; o.footL = 1.1 * A * pos(s); o.footR = 1.1 * A * pos(-s); o.lift = 0.6 * A * ab(s); o.x = 0.6 * A * s; return { v: 0.7 }; } },
    // spooky glide: low hover, smooth, leaning into it
    glide: { r: 0.4, dl: 5, f(p, A, o) { const s = S(p); o.lift = 3 + 1.5 * A * s; o.pitch = 0.05; o.armL = 10 + 4 * S(p + 1); o.armR = 10 + 4 * S(p + 1 + PI); o.tilt = 1.5 * A * S(p + 0.6); o.sq = 0.02 * A * S(2 * p); } },
    // round thing rocking along on its bottom
    roll: { r: 0.9, dl: 1, f(p, A, o) { const s = S(p); o.tilt = 8 * A * s; o.turn = 0.18 * A * s; o.lift = 1.5 * A * ab(s); o.sq = 0.03 * A * pw(C(p), 4); o.armL = 10 * A * s; o.armR = -10 * A * s; o.x = 0.8 * A * s; } },
    // bird strut: head bobs forward on each step
    strut: { r: 0.85, dl: 1, f(p, A, o) { const s = S(p); o.footL = 2.6 * A * pos(s); o.footR = 2.6 * A * pos(-s); o.lift = 1.6 * A * ab(s); o.tilt = 2 * A * s; o.pitch = 0.02 + 0.1 * A * pos(S(2 * p)); o.armL = 10 + 6 * A * S(2 * p); o.armR = 10 + 6 * A * S(2 * p); o.sq = 0.03 * A * pw(C(p), 6); } },
  };
  const PROF = {}, DEF = { g: 'trot' };
  const W = window.HouseWalk = {
    G, PROF, DLS: 1,
    def(key, P) { PROF[key] = P; },
    prof(key) { key = (window.SQ_ALIAS && window.SQ_ALIAS[key]) || key; const P0 = PROF[key] || DEF; return window.SquishConfig ? window.SquishConfig.walkProfile(key, P0) : P0; },
    // cycle length in ms (one cycle = two steps / one hop) for test pages
    period(key) { const P = W.prof(key), g = G[P.g] || G.trot; return 1000 * TAU / (11 * g.r * (P.r || 1)); },
    step(key, st, E, w, dt, spd, spin) { key = (window.SQ_ALIAS && window.SQ_ALIAS[key]) || key;
      // st.run = 1 while he runs / chases the ball: faster bigger steps, leans in, mouth open, ears streaming back, his own run extras (window.HouseWalkRUN[key])
      const rk = st.rk = (st.rk || 0) + ((st.run ? 1 : 0) - (st.rk || 0)) * Math.min(1, dt * 6);
      const P = W.prof(key), g = G[P.g] || G.trot, A = (P.a || 1) * (1 + 0.28 * rk);
      st.ph = (st.ph || 0) + dt * 11 * g.r * (P.r || 1) * (spd || 0) * (1 + 0.6 * rk);
      if (w < 0.002) return { v: 1, fx: null };
      const p = st.ph, o = {}, m = g.f(p, A, o, P) || {}, sr = (spin || 0) * PI / 180, sd = 0.45 + 0.55 * ab(C(sr));
      if (o.tilt) o.tilt *= sd; if (o.x) o.x *= sd;
      o.tilt = (o.tilt || 0) + W.DLS * (P.dl != null ? P.dl : g.dl) * S(sr);
      if (P.x) for (const k in P.x) { const q = P.x[k], v = S((q[1] || 1) * p + (q[2] || 0)); o[k] = (o[k] || 0) + q[0] * (q[3] ? ab(v) : v); }
      if (P.c) for (const k in P.c) o[k] = (o[k] || 0) + P.c[k];
      if (P.m) for (const k in P.m) if (o[k] != null) o[k] *= P.m[k];
      if (rk > 0.01) { const RX = (window.HouseWalkRUN || {})[key] || {}, add = (k, v) => { o[k] = (o[k] || 0) + v * rk; };
        add('tilt', 3.5 * W.DLS * S(sr)); add('pitch', -0.06); add('open', 0.32); add('mw', -0.25); add('hap', 0.7); add('smile', 0.3); add('wide', 0.25); add('earL', 10); add('earR', -10); for (const k in RX) add(k, RX[k]); }
      for (const k in o) E[k] = (E[k] || 0) + o[k] * w;
      let fx = null; const now = st.t = (st.t || 0) + dt * 1000;
      if (w > 0.6 && spd) {
        if (P.fx && now > (st.fxAt || 0)) { st.fxAt = now + P.fx[1] * (0.7 + Math.random() * 0.6); fx = P.fx[0]; }
        if (P.dust && m.land != null) { const ld = m.land > 0.9; if (ld && !st.ld) fx = P.dust; st.ld = ld; }
        if (rk > 0.5 && !fx && now > (st.ruAt || 0)) { st.ruAt = now + 260; fx = P.dust || null; }
      }
      return { v: m.v || 1, fx };
    },
  };
  (window.HouseWalkC || []).forEach(f => f(W));
})();
