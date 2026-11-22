(function () {
  // Layered impact: transient crack + saturated sub kick + crunchy body + material ring + debris + accents + room tail.
  // Every chest (group x rarity) has its own material recipe in CHESTS.
  const S = { ctx: null, on: true };
  const rr = (a, b) => a + Math.random() * (b - a);
  function ctx() {
    if (!S.ctx) {
      const AC = window.AudioContext || window.webkitAudioContext; if (!AC) return null;
      const c = (S.ctx = new AC());
      const comp = c.createDynamicsCompressor(); comp.threshold.value = -16; comp.knee.value = 4; comp.ratio.value = 8; comp.attack.value = 0.002; comp.release.value = 0.12; comp.connect(c.destination);
      S.out = c.createGain(); S.out.gain.value = S.on ? 1 : 0; S.out.connect(comp);
      S.dist = c.createWaveShaper(); const n = 1024, cv = new Float32Array(n), k = 14;
      for (let i = 0; i < n; i++) { const x = i * 2 / n - 1; cv[i] = (1 + k) * x / (1 + k * Math.abs(x)); }
      S.dist.curve = cv; S.dist.oversample = '2x'; S.dg = c.createGain(); S.dg.gain.value = 0.55; S.dist.connect(S.dg); S.dg.connect(S.out);
      const len = c.sampleRate * 0.9, ir = c.createBuffer(2, len, c.sampleRate);
      for (let ch = 0; ch < 2; ch++) { const d = ir.getChannelData(ch); for (let i = 0; i < len; i++) d[i] = (Math.random() * 2 - 1) * Math.pow(1 - i / len, 4); }
      S.verb = c.createConvolver(); S.verb.buffer = ir; S.vin = c.createGain(); S.vin.gain.value = 0.35; S.vin.connect(S.verb); S.verb.connect(S.out);
      const nl = c.sampleRate * 2; S.nb = c.createBuffer(1, nl, c.sampleRate);
      const nd = S.nb.getChannelData(0); for (let i = 0; i < nl; i++) nd[i] = Math.random() * 2 - 1;
    }
    if (S.ctx.state === 'suspended') S.ctx.resume();
    return S.ctx;
  }
  function env(g, t, v, a, dur) { g.gain.setValueAtTime(0.0001, t); g.gain.linearRampToValueAtTime(Math.max(0.0002, v), t + a); g.gain.exponentialRampToValueAtTime(0.0001, t + dur); }
  function tone(f, t, dur, o) {
    t = Math.max(0, t); o = o || {}; const c = S.ctx, osc = c.createOscillator(), g = c.createGain();
    osc.type = o.type || 'sine'; osc.frequency.setValueAtTime(f, t);
    if (o.to) osc.frequency.exponentialRampToValueAtTime(o.to, t + (o.slide || dur));
    env(g, t, o.vol == null ? 0.3 : o.vol, o.a || 0.002, dur);
    let out = g; if (o.lp) { const lp = c.createBiquadFilter(); lp.type = 'lowpass'; lp.frequency.value = o.lp; g.connect(lp); out = lp; }
    osc.connect(g); out.connect(o.dist ? S.dist : S.out);
    if (o.verb) { const s = c.createGain(); s.gain.value = o.verb; out.connect(s); s.connect(S.vin); }
    osc.start(t); osc.stop(t + dur + 0.05);
  }
  function noise(t, dur, o) {
    t = Math.max(0, t); o = o || {}; const c = S.ctx, src = c.createBufferSource(); src.buffer = S.nb; src.loop = true;
    const f = c.createBiquadFilter(); f.type = o.ft || 'bandpass'; f.Q.value = o.q || 1; f.frequency.setValueAtTime(o.f || 1000, t);
    if (o.fTo) f.frequency.exponentialRampToValueAtTime(o.fTo, t + dur);
    const g = c.createGain(); env(g, t, o.vol == null ? 0.2 : o.vol, o.a || 0.001, dur);
    src.connect(f); f.connect(g); g.connect(o.dist ? S.dist : S.out);
    if (o.verb) { const s = c.createGain(); s.gain.value = o.verb; g.connect(s); s.connect(S.vin); }
    src.start(t, Math.random()); src.stop(t + dur + 0.05);
  }
  const bell = (f, t, dur, v) => { tone(f, t, dur, { vol: v, verb: 0.6 }); tone(f * 2.76, t, dur * 0.4, { vol: v * 0.25, verb: 0.5 }); tone(f * 5.4, t, dur * 0.15, { vol: v * 0.1 }); };
  const mtof = m => 440 * Math.pow(2, (m - 69) / 12);

  // Materials. body = main noise band, sub = kick pitch, cr = crunch band, q = crunch resonance, deb = debris type,
  // ring = resonant partials [freqs, decay, vol], hard = how much transient/sub punch (0-1).
  const M = {
    paper:   { body: 2600, sub: 150, cr: [2500, 6500], q: 0.8, deb: 'rustle', hard: 0.55 },
    card:    { body: 650,  sub: 130, cr: [500, 1900],  q: 2,   deb: 'rustle', hard: 0.75 },
    plastic: { body: 1300, sub: 170, cr: [900, 3000],  q: 4,   deb: 'clatter', ring: [[620, 1480, 2300], 0.12, 0.16], hard: 0.85 },
    tin:     { body: 1800, sub: 160, cr: [1500, 5000], q: 3,   deb: 'tink', ring: [[740, 1890, 3100, 4400], 0.4, 0.2], hard: 0.9 },
    iron:    { body: 1100, sub: 105, cr: [800, 3200],  q: 2,   deb: 'tink', ring: [[310, 845, 1620, 2580], 0.95, 0.24], hard: 1 },
    steel:   { body: 800,  sub: 80,  cr: [600, 2600],  q: 2,   deb: 'tink', ring: [[175, 520, 1100, 1980, 3050], 1.5, 0.26], hard: 1 },
    gold:    { body: 1400, sub: 110, cr: [900, 3600],  q: 2,   deb: 'tink', ring: [[520, 1310, 2470, 3900], 1.1, 0.2], hard: 1 },
    glass:   { body: 4200, sub: 150, cr: [3000, 8000], q: 1.5, deb: 'shard', ring: [[2100, 3400, 5200], 0.5, 0.14], hard: 0.85 },
    crystal: { body: 5000, sub: 135, cr: [3500, 9000], q: 1.2, deb: 'shard', ring: [[2600, 3900, 5800, 7400], 0.85, 0.12], hard: 0.9 },
    sugar:   { body: 3600, sub: 140, cr: [2500, 7000], q: 2,   deb: 'shard', ring: [[1900, 3100, 4600], 0.28, 0.1], hard: 0.8 },
    candy:   { body: 2200, sub: 160, cr: [1500, 4500], q: 5,   deb: 'clatter', ring: [[1300, 2600, 3900], 0.16, 0.14], hard: 0.85 },
    wood:    { body: 950,  sub: 145, cr: [700, 2700],  q: 5,   deb: 'splinter', ring: [[420, 980], 0.12, 0.12], hard: 0.95 },
    pine:    { body: 1200, sub: 165, cr: [900, 3200],  q: 6,   deb: 'splinter', ring: [[520, 1240], 0.09, 0.12], hard: 0.9 },
    hardwood:{ body: 750,  sub: 120, cr: [600, 2200],  q: 5,   deb: 'splinter', ring: [[330, 800], 0.18, 0.14], hard: 1 },
    moss:    { body: 600,  sub: 125, cr: [500, 1600],  q: 3,   deb: 'splinter', hard: 0.7 },
    wicker:  { body: 1700, sub: 150, cr: [1400, 3800], q: 9,   deb: 'weave', hard: 0.7 },
    stone:   { body: 1500, sub: 110, cr: [1100, 4500], q: 2,   deb: 'grit', hard: 1 },
    pebble:  { body: 1900, sub: 135, cr: [1500, 5000], q: 2.5, deb: 'grit', ring: [[1250], 0.04, 0.12], hard: 0.9 },
    rock:    { body: 1000, sub: 90,  cr: [800, 3500],  q: 1.8, deb: 'grit', hard: 1 },
    shell:   { body: 2200, sub: 150, cr: [1600, 5200], q: 3,   deb: 'clatter', ring: [[1100, 2300, 3700], 0.12, 0.14], hard: 0.85 },
    velvet:  { body: 500,  sub: 120, cr: [400, 1300],  q: 2,   deb: 'soft', hard: 0.75 },
    puff:    { body: 420,  sub: 110, cr: [380, 1200],  q: 1,   deb: 'soft', hard: 0.6 },
    cake:    { body: 520,  sub: 120, cr: [450, 1400],  q: 3,   deb: 'soft', hard: 0.65 },
    frosting:{ body: 700,  sub: 125, cr: [600, 1800],  q: 4,   deb: 'soft', hard: 0.65 },
  };
  // m = material, p = pitch shift, x = accents layered on top
  const CHESTS = {
    snack:     [{ m:'paper', p:1 }, { m:'plastic', p:1, x:['latch'] }, { m:'tin', p:1, x:['latch'] }, { m:'glass', p:1 }, { m:'candy', p:1, x:['rainbow','fizz'] }],
    fruit:     [{ m:'wood', p:1.05 }, { m:'wicker', p:1 }, { m:'wicker', p:0.85, x:['latch'] }, { m:'crystal', p:0.9, x:['juice'] }, { m:'crystal', p:1, x:['rainbow','juice'] }],
    ocean:     [{ m:'pebble', p:1 }, { m:'shell', p:1, x:['water'] }, { m:'shell', p:0.92, x:['pearl','water'] }, { m:'crystal', p:1.05, x:['water'] }, { m:'crystal', p:1.1, x:['rainbow','pearl','water'] }],
    pet:       [{ m:'card', p:1 }, { m:'wood', p:1.1, x:['squeak'] }, { m:'velvet', p:1, x:['squeak'] }, { m:'crystal', p:0.95, x:['squeak'] }, { m:'crystal', p:1, x:['rainbow','squeak'] }],
    forest:    [{ m:'moss', p:1, x:['leaf'] }, { m:'hardwood', p:1, x:['leaf'] }, { m:'hardwood', p:0.9, x:['iron'] }, { m:'crystal', p:0.85, x:['leaf'] }, { m:'crystal', p:1, x:['rainbow','chime'] }],
    sky:       [{ m:'puff', p:0.95, x:['water'] }, { m:'puff', p:1.1 }, { m:'puff', p:1.05, x:['silver'] }, { m:'puff', p:1.15, x:['chime'] }, { m:'crystal', p:1.2, x:['rainbow','chime'] }],
    dream:     [{ m:'stone', p:1 }, { m:'stone', p:1.1, x:['latch'] }, { m:'stone', p:0.95, x:['goldx'] }, { m:'crystal', p:0.95, x:['chime'] }, { m:'crystal', p:1, x:['rainbow','chime'] }],
    bakery:    [{ m:'cake', p:1 }, { m:'cake', p:1.1, x:['paperx'] }, { m:'frosting', p:1, x:['paperx'] }, { m:'sugar', p:1 }, { m:'sugar', p:1.1, x:['rainbow','fizz'] }],
    heroes:    [{ m:'card', p:0.92 }, { m:'plastic', p:0.9, x:['latch'] }, { m:'iron', p:1 }, { m:'steel', p:1, x:['vault'] }, { m:'steel', p:1.1, x:['vault','rainbow'] }],
    elemental: [{ m:'rock', p:1 }, { m:'rock', p:1.05, x:['zap'] }, { m:'iron', p:1.1, x:['zap'] }, { m:'crystal', p:0.9, x:['zap'] }, { m:'crystal', p:1, x:['rainbow','zap','fire'] }],
    spooky:    [{ m:'pine', p:1 }, { m:'wood', p:0.85, x:['creak'] }, { m:'iron', p:0.9, x:['creak'] }, { m:'crystal', p:0.8, x:['ghost'] }, { m:'crystal', p:0.9, x:['rainbow','ghost'] }],
  };
  const spec = (g, lv) => (CHESTS[g] || CHESTS.fruit)[lv] || CHESTS.fruit[0];

  function ring(m, t, H, p, len) {
    if (!m.ring) return; const [fs, d, v] = m.ring;
    fs.forEach((f, i) => tone(f * p * rr(0.98, 1.02), t, d * (1 - i * 0.12) * len, { type: i ? 'sine' : 'triangle', vol: v * H / (1 + i * 0.6), verb: 0.35 }));
  }
  function debris(m, t, H, n, spread, p) {
    for (let i = 0; i < n; i++) {
      const tt = t + Math.pow(Math.random(), 1.6) * spread, v = H * Math.max(0.15, 1 - (tt - t) / (spread * 1.3));
      switch (m.deb) {
        case 'splinter': noise(tt, rr(0.01, 0.035), { f: rr(900, 3200) * p, q: 6, vol: 0.22 * v }); if (Math.random() < 0.4) tone(rr(260, 700) * p, tt, rr(0.04, 0.09), { type:'triangle', vol: 0.12 * v }); break;
        case 'grit': noise(tt, rr(0.012, 0.04), { f: rr(1500, 6000) * p, q: 3, vol: 0.2 * v }); if (Math.random() < 0.35) tone(rr(700, 1600) * p, tt, 0.03, { type:'triangle', vol: 0.09 * v }); break;
        case 'rustle': noise(tt, rr(0.015, 0.05), { ft:'highpass', f: rr(1800, 5000) * p, vol: 0.16 * v }); break;
        case 'clatter': tone(rr(1200, 3200) * p, tt, rr(0.02, 0.05), { type:'triangle', vol: 0.12 * v }); noise(tt, 0.012, { f: rr(2000, 5000), q: 4, vol: 0.1 * v }); break;
        case 'tink': tone(rr(2500, 6500) * p, tt, rr(0.08, 0.2), { vol: 0.07 * v, verb: 0.3 }); noise(tt, 0.008, { ft:'highpass', f: 5000, vol: 0.08 * v }); break;
        case 'shard': tone(rr(3000, 8500) * p, tt, rr(0.1, 0.35), { vol: 0.07 * v, verb: 0.45 }); noise(tt, 0.01, { ft:'highpass', f: 7000, vol: 0.1 * v }); break;
        case 'weave': noise(tt, rr(0.006, 0.018), { f: rr(1500, 3500) * p, q: 12, vol: 0.25 * v }); if (Math.random() < 0.2) tone(rr(500, 900), tt, 0.05, { type:'sawtooth', to: rr(300, 500), vol: 0.03 * v, lp: 1500 }); break;
        default: noise(tt, rr(0.03, 0.07), { f: rr(500, 1500) * p, q: 2, vol: 0.14 * v });
      }
    }
  }
  const ACC = {
    latch(t, H) { tone(1800, t + 0.01, 0.03, { type:'square', vol: 0.06 * H, lp: 4000 }); tone(2700, t + 0.04, 0.05, { type:'triangle', vol: 0.06 * H }); },
    iron(t, H) { [330, 880, 1700].forEach((f, i) => tone(f * rr(0.98, 1.02), t, 0.6 - i * 0.15, { vol: 0.12 * H / (i + 1), verb: 0.3 })); },
    goldx(t, H) { [1480, 3720].forEach(f => tone(f, t + 0.01, 0.7, { vol: 0.07 * H, verb: 0.5 })); },
    silver(t, H) { [2350, 4100].forEach(f => tone(f, t + 0.01, 0.6, { vol: 0.06 * H, verb: 0.5 })); },
    paperx(t, H) { for (let i = 0; i < 3; i++) noise(t + i * 0.02, 0.03, { ft:'highpass', f: 3500, vol: 0.1 * H }); },
    pearl(t, H) { bell(2800, t + 0.03, 0.4, 0.06 * H); },
    chime(t, H) { [88, 91, 95].forEach((m, i) => bell(mtof(m), t + 0.04 + i * 0.05, 0.6, 0.05 * H)); },
    rainbow(t, H) { [84, 86, 88, 91, 93, 96].forEach((m, i) => bell(mtof(m), t + 0.05 + i * 0.03, 0.5, 0.04 * H)); },
    water(t, H) { noise(t + 0.01, 0.25, { f: 700, fTo: 2600, q: 1.5, vol: 0.2 * H, a: 0.01 }); for (let i = 0; i < 4; i++) tone(rr(350, 700), t + 0.03 + i * rr(0.02, 0.05), 0.06, { to: rr(900, 1600), vol: 0.08 * H }); },
    juice(t, H) { noise(t + 0.02, 0.18, { f: 900, fTo: 300, q: 4, vol: 0.18 * H }); },
    fizz(t, H) { noise(t + 0.05, 0.5, { ft:'highpass', f: 6000, vol: 0.05 * H, a: 0.05 }); for (let i = 0; i < 8; i++) tone(rr(3000, 6000), t + 0.05 + rr(0, 0.4), 0.015, { vol: 0.04 * H }); },
    squeak(t, H) { tone(1400, t + 0.06, 0.12, { to: 2200, slide: 0.06, type:'triangle', vol: 0.06 * H }); },
    leaf(t, H) { noise(t + 0.02, 0.22, { ft:'highpass', f: 3000, fTo: 1800, vol: 0.09 * H, a: 0.02 }); },
    zap(t, H) { tone(90, t, 0.25, { type:'sawtooth', vol: 0.14 * H, lp: 2200, dist: true }); for (let i = 0; i < 6; i++) noise(t + rr(0, 0.2), 0.012, { ft:'highpass', f: 5000, vol: 0.14 * H }); },
    fire(t, H) { noise(t + 0.02, 0.4, { ft:'lowpass', f: 1400, vol: 0.18 * H, a: 0.05 }); },
    vault(t, H) { tone(55, t, 0.7, { type:'triangle', to: 40, vol: 0.4 * H, dist: true }); noise(t + 0.03, 0.3, { f: 300, q: 3, vol: 0.12 * H }); },
    creak(t, H) { tone(rr(170, 220), t + 0.04, 0.3, { type:'sawtooth', to: rr(110, 140), vol: 0.05 * H, lp: 1100 }); },
    ghost(t, H) { tone(320, t + 0.03, 0.6, { to: 640, slide: 0.5, vol: 0.06 * H, a: 0.1, verb: 0.7 }); tone(327, t + 0.03, 0.6, { to: 600, slide: 0.5, vol: 0.05 * H, a: 0.1, verb: 0.7 }); },
  };
  function smash(t, sp, o) {
    const m = M[sp.m], p = sp.p || 1, H = o.H, hd = m.hard;
    noise(t, 0.012, { ft:'highpass', f: 2500 * p, vol: 0.9 * H * hd, dist: true });
    tone(3200 * p, t, 0.008, { type:'square', vol: 0.25 * H * hd });
    const s0 = m.sub * p * rr(0.94, 1.06) * (o.low || 1);
    tone(s0 * 1.6, t, 0.28 * o.len, { to: s0 * 0.3, slide: 0.12 * o.len, vol: 0.95 * H * (0.5 + hd * 0.5), dist: true });
    tone(s0 * 0.5, t, 0.35 * o.len, { to: 32, slide: 0.25 * o.len, vol: 0.6 * H });
    const nb = Math.round(6 + 10 * H * o.len);
    for (let i = 0; i < nb; i++) noise(t + i * rr(0.006, 0.014), rr(0.012, 0.03), { f: rr(m.cr[0], m.cr[1]) * p, q: m.q, vol: 0.55 * H * (1 - i / nb * 0.8), dist: true });
    noise(t, 0.09 * o.len, { f: m.body * p, q: 0.8, vol: 0.5 * H, dist: true, verb: 0.35 });
    ring(m, t, H, p, o.len);
    debris(m, t + 0.03, H, Math.round(o.deb), 0.25 * o.len, p);
    (sp.x || []).forEach(a => ACC[a] && ACC[a](t, H));
  }
  function voice(kind, t, H) {
    if (kind === 'battle') noise(Math.max(0, t - 0.07), 0.07, { f: 600, fTo: 3500, q: 0.8, vol: 0.25 * H, a: 0.06 });
    if (kind === 'squash') { noise(t + 0.02, 0.3, { f: 800, fTo: 200, q: 4, vol: 0.35 * H, a: 0.01 }); tone(220, t + 0.03, 0.3, { type:'sawtooth', to: 90, vol: 0.06 * H, lp: 900 }); }
    if (kind === 'land') { tone(60, t, 0.5, { to: 28, vol: 0.8 * H, dist: true }); noise(t, 0.5, { ft:'lowpass', f: 900, fTo: 150, vol: 0.45 * H }); }
  }
  function cracks(t, m, p, dmg, H) {
    const n = Math.round(2 + dmg * 10);
    for (let i = 0; i < n; i++) noise(t + 0.04 + i * rr(0.01, 0.03), rr(0.008, 0.02), { f: rr(m.cr[0], m.cr[1] * 1.3) * p, q: 8, vol: (0.15 + dmg * 0.3) * H, dist: true });
    if (dmg > 0.5) tone(rr(160, 240) * p, t + 0.05, 0.25, { type:'sawtooth', to: rr(70, 110), vol: 0.08 * H, lp: 1200 });
  }
  const API = {
    get on() { return S.on; },
    setOn(v) { S.on = !!v; if (S.out) S.out.gain.setTargetAtTime(S.on ? 1 : 0, S.ctx.currentTime, 0.02); },
    hit({ kind, heavy, group, lv, dmg, ko, mat }) {
      const c = ctx(); if (!c) return; const t = c.currentTime + 0.005, sp = mat || spec(group, lv), m = M[sp.m];
      const H = ko ? 1 : heavy ? 0.95 : 0.65;
      voice(kind, t, H);
      smash(t, sp, { H, len: ko ? 1.6 : heavy ? 1.2 : 0.8, deb: ko ? 40 : heavy ? 18 : 8, low: kind === 'land' ? 0.8 : kind === 'poke' && !heavy ? 1.2 : 1 });
      if (dmg >= 0.25) cracks(t, m, sp.p || 1, dmg, H);
      if (ko) {
        smash(t + 0.07, sp, { H: 0.8, len: 1.4, deb: 25, low: 0.85 });
        tone(45, t, 1.1, { to: 25, vol: 0.7, dist: true }); noise(t, 1.0, { ft:'lowpass', f: 400, fTo: 80, vol: 0.4 });
        noise(t + 0.2, 0.45, { f: 300, fTo: 3000, q: 1, vol: 0.2, a: 0.4 });
      }
    },
    fall(heavy) {
      const c = ctx(); if (!c) return; const t = c.currentTime, d = heavy ? 0.68 : 0.48;
      tone(1500, t, d, { to: 380, slide: d, vol: 0.07, type:'triangle', a: 0.05 });
      noise(t, d, { f: 400, fTo: 2000, q: 1, vol: 0.1, a: d * 0.85 });
    },
    bounce(v, group, lv, mat) {
      const c = ctx(); if (!c) return; const t = c.currentTime, H = Math.min(0.9, v / 1300);
      if (H < 0.2) return; const sp = mat || spec(group, lv || 0);
      smash(t, { m: sp.m, p: sp.p }, { H: H * 0.75, len: 0.7, deb: 4 + H * 8, low: 0.85 });
    },
    charge(dur) {
      const c = ctx(); if (!c) return; const t = c.currentTime;
      noise(t, dur, { f: 300, fTo: 4200, q: 2, vol: 0.13, a: dur * 0.9 });
      tone(196, t, dur, { type:'sawtooth', to: 784, slide: dur, vol: 0.035, lp: 1800, a: dur * 0.8 });
    },
    poof(lv) {
      const c = ctx(); if (!c) return; const t = c.currentTime;
      noise(t, 0.7, { ft:'lowpass', f: 2400, fTo: 180, vol: 0.4, verb: 0.4 });
      tone(72, t, 0.5, { to: 34, vol: 0.55, dist: true });
      [72, 76, 79, 84, 88, 91].slice(0, 2 + lv).forEach((m, i) => bell(mtof(m), t + 0.05 + i * 0.06, 0.9, 0.11));
    },
    burst(lv, group, mat) {
      const c = ctx(); if (!c) return; const t = c.currentTime + 0.01, sp = mat || spec(group, lv);
      smash(t, sp, { H: 1, len: 1.8, deb: 50, low: 0.7 });
      tone(38, t, 1.4, { to: 22, vol: 0.8, dist: true });
      noise(t, 1.2, { ft:'lowpass', f: 2200, fTo: 120, vol: 0.45, verb: 0.5 });
      debris(M[sp.m], t + 0.25, 0.5, 22, 0.8, sp.p || 1);
      const fan = [[72, 76, 79], [72, 76, 79, 84], [72, 76, 79, 84, 88], [72, 76, 79, 84, 88, 91], [72, 76, 79, 84, 88, 91, 96]][lv];
      fan.forEach((m, i) => bell(mtof(m), t + 0.32 + i * 0.075, 0.9, 0.12));
      const end = t + 0.32 + fan.length * 0.075;
      [60, 64, 67].forEach(m => tone(mtof(m), end, 1.2 + lv * 0.2, { type:'triangle', vol: 0.05, a: 0.04, verb: 0.4 }));
      const n = [8, 12, 16, 22, 28][lv];
      for (let i = 0; i < n; i++) {
        const tt = t + 0.4 + i * rr(0.035, 0.07);
        if (i % 3 === 0) { tone(1318, tt, 0.07, { type:'square', vol: 0.03, lp: 5000 }); bell(1976, tt + 0.06, 0.35, 0.045); }
        else bell(rr(1700, 3800), tt, 0.4, 0.04);
      }
    },
  };
  window.ChestSFX = API;
})();
