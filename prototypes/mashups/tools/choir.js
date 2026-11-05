/* ------------------------------------------------------------------ */
/* 4. SQUISH CHOIR: copy who sang AND when, faster every round, twists */
/* ------------------------------------------------------------------ */
const CHOIR = (() => {
  const W = 400, H = 300, STAGE_Y = 150;
  const cv = $("#choir-cv"), ctx = setupCanvas(cv, W, H);
  // Each singer has its own pitch AND its own sound, so curtain rounds can be done by ear.
  const VOICES = [
    { name: "Mochi", color: "#ff7ac8", f: 261.63, type: "triangle", lp: 2600 },
    { name: "Puddin", color: "#56c6ff", f: 329.63, type: "sine", lp: 4000 },
    { name: "Taffy", color: "#ffc23d", f: 392.0, type: "square", lp: 1500 },
    { name: "Bean", color: "#7ee8b4", f: 440.0, type: "sawtooth", lp: 1300 },
    { name: "Bubbles", color: "#b98cff", f: 523.25, type: "sine", lp: 4000, vib: true },
  ];
  const PLAN = [
    { n: 3, bars: 1, off: 1, tw: [] },
    { n: 4, bars: 1, off: 2, tw: [] },
    { n: 4, bars: 1, off: 2, tw: ["swap"] },
    { n: 5, bars: 1, off: 2, tw: ["duet"] },
    { n: 5, bars: 1, off: 3, tw: ["curtain"] },
    { n: 6, bars: 2, off: 3, tw: ["swap", "duet"] },
    { n: 7, bars: 2, off: 4, tw: ["curtain", "swap"] },
  ];
  const TWIST = {
    swap: { tag: "SEAT SWAP", text: "After the tune, two singers change seats." },
    duet: { tag: "DUET", text: "Some notes are two singers at once. Tap both." },
    curtain: { tag: "CURTAIN", text: "They sing behind a curtain. Know them by their voices." },
  };
  const say = sayIn($("#choir-msg")), roundEl = $("#choir-round"), livesEl = $("#choir-lives"), scoreEl = $("#choir-score"), bpmEl = $("#choir-bpm"), startBtn = $("#choir-start");
  const R = rng(Date.now() & 0xffff);
  let A = null, master = null, noise = null;
  const s = {
    phase: "idle", round: 1, lives: 3, score: 0, unlocked: 4, seat: [0, 1, 2, 3, 4], xs: [], bounce: [0, 0, 0, 0, 0],
    joinT: -1, plan: PLAN[0], ph: [], T: null, expected: [], taps: [], listen: [], played: 0, swapped: false, next: null, nextAt: 0, bpm: 92, swapPair: null,
  };
  const seatX = (k, n) => W * (k + 0.5) / n;
  const seatOf = v => s.seat.indexOf(v);
  for (let v = 0; v < 5; v++) s.xs[v] = v < 4 ? seatX(v, 4) : W + 60;

  function ensureAudio() {
    if (A) return true;
    try {
      const AC = window.AudioContext || window.webkitAudioContext;
      A = new AC(); master = A.createGain(); master.gain.value = 0.5; master.connect(A.destination);
      noise = A.createBuffer(1, Math.floor(A.sampleRate * 0.2), A.sampleRate);
      const d = noise.getChannelData(0); for (let i = 0; i < d.length; i++) d[i] = Math.random() * 2 - 1;
      return true;
    } catch (e) { A = null; return false; }
  }
  function voice(t, i, vol) {
    if (!A) return;
    vol = vol || 0.45;
    const V = VOICES[i], o = A.createOscillator(), g = A.createGain(), lp = A.createBiquadFilter();
    o.type = V.type;
    o.frequency.setValueAtTime(V.f * 1.6, t); o.frequency.exponentialRampToValueAtTime(V.f, t + 0.06);
    if (V.vib) { const l = A.createOscillator(), lg = A.createGain(); l.frequency.value = 11; lg.gain.value = V.f * 0.04; l.connect(lg); lg.connect(o.frequency); l.start(t); l.stop(t + 0.4); }
    else o.frequency.exponentialRampToValueAtTime(V.f * 0.95, t + 0.34);
    lp.type = "lowpass"; lp.frequency.setValueAtTime(V.lp, t); lp.frequency.exponentialRampToValueAtTime(Math.max(500, V.lp * 0.35), t + 0.3);
    const v2 = V.type === "square" || V.type === "sawtooth" ? vol * 0.55 : vol;
    g.gain.setValueAtTime(0.0001, t); g.gain.exponentialRampToValueAtTime(v2, t + 0.012); g.gain.exponentialRampToValueAtTime(0.0001, t + 0.36);
    o.connect(lp); lp.connect(g); g.connect(master); o.start(t); o.stop(t + 0.4);
    const n = A.createBufferSource(), bp = A.createBiquadFilter(), ng = A.createGain();
    n.buffer = noise; bp.type = "bandpass"; bp.Q.value = 2;
    bp.frequency.setValueAtTime(1900, t); bp.frequency.exponentialRampToValueAtTime(450, t + 0.08);
    ng.gain.setValueAtTime(0.25 * vol, t); ng.gain.exponentialRampToValueAtTime(0.0001, t + 0.09);
    n.connect(bp); bp.connect(ng); ng.connect(master); n.start(t); n.stop(t + 0.1);
  }
  function tick(t, accent, soft) {
    if (!A) return;
    const o = A.createOscillator(), g = A.createGain();
    o.type = "square"; o.frequency.value = accent ? 1560 : 1040;
    g.gain.setValueAtTime((accent ? 0.05 : 0.03) * (soft || 1), t); g.gain.exponentialRampToValueAtTime(0.0001, t + 0.035);
    o.connect(g); g.connect(master); o.start(t); o.stop(t + 0.05);
  }
  function hud() { roundEl.textContent = s.round; livesEl.textContent = s.lives; scoreEl.textContent = s.score; bpmEl.textContent = s.bpm; }

  function planFor(r) {
    if (r <= PLAN.length) return PLAN[r - 1];
    const ex = r - PLAN.length, opts = ["swap", "duet", "curtain"];
    const a = opts[Math.floor(R() * 3)], b = opts.filter(o => o !== a)[Math.floor(R() * 2)];
    return { n: Math.min(7 + ex, 12), bars: 2, off: Math.min(4 + ex, 8), tw: [a, b] };
  }
  function makePhrase(p) {
    const slots = p.bars * 8, chosen = new Set([0]);
    let off = 0, guard = 0;
    while (chosen.size < p.n && guard++ < 400) {
      const k = Math.floor(R() * slots);
      if (chosen.has(k)) continue;
      if (k % 2 === 1) { if (off >= p.off) continue; off++; }
      chosen.add(k);
    }
    const ev = [];
    let last = -1, last2 = -1;
    for (const k of [...chosen].sort((a, b) => a - b)) {
      let v;
      do { v = Math.floor(R() * s.unlocked); } while (v === last && v === last2);
      ev.push({ slot: k, voices: [v] }); last2 = last; last = v;
    }
    if (p.tw.includes("duet")) {
      for (let i = 0; i < p.bars; i++) {
        const e = ev[1 + Math.floor(R() * (ev.length - 1))];
        if (e.voices.length > 1) continue;
        let v2; do { v2 = Math.floor(R() * s.unlocked); } while (v2 === e.voices[0]);
        e.voices.push(v2);
      }
    }
    return ev;
  }
  function start() {
    if (!ensureAudio()) { say("This browser would not start sound, so the choir cannot sing here."); return; }
    if (A.resume) A.resume().catch(() => {});
    s.round = 1; s.lives = 3; s.score = 0; s.unlocked = 4; s.joinT = -1; s.seat = [0, 1, 2, 3, 4]; s.xs[4] = W + 60;
    startBtn.textContent = "Restart";
    beginRound(false);
    cv.focus({ preventScroll: true });
  }
  function beginRound(retry) {
    if (!retry) {
      s.plan = planFor(s.round);
      if (s.round === 3 && s.unlocked < 5) { s.unlocked = 5; s.joinT = performance.now(); }
      s.ph = makePhrase(s.plan);
    }
    s.bpm = Math.min(150, 92 + 7 * (s.round - 1));
    const b = 60 / s.bpm, e = b / 2, bars = s.plan.bars, t0 = A.currentTime + 0.35;
    s.T = { b, e, t0, L0: t0 + 4 * b, G0: t0 + 4 * b + bars * 4 * b, A0: t0 + 8 * b + bars * 4 * b };
    s.T.end = s.T.A0 + bars * 4 * b;
    s.T.win = Math.min(0.14, e * 0.45);
    for (let i = 0; i < 4; i++) tick(t0 + i * b, i === 0);
    for (let i = 0; i < bars * 4; i++) tick(s.T.L0 + i * b, i % 4 === 0, 0.45);
    for (let i = 0; i < 4; i++) tick(s.T.G0 + i * b, i === 0);
    for (let i = 0; i < bars * 4; i++) tick(s.T.A0 + i * b, i % 4 === 0, 0.45);
    s.listen = [];
    for (const ev of s.ph) for (const v of ev.voices) { voice(s.T.L0 + ev.slot * e, v); s.listen.push({ t: s.T.L0 + ev.slot * e, v }); }
    s.expected = [];
    for (const ev of s.ph) for (const v of ev.voices) s.expected.push({ t: s.T.A0 + ev.slot * e, v, slot: ev.slot, hit: null });
    s.taps = []; s.played = 0; s.swapped = false; s.swapPair = null; s.phase = "intro";
    const tw = s.plan.tw.map(k => TWIST[k].text).join(" ");
    say((retry ? "Same tune again. " : "") + (s.joinT > 0 && s.round === 3 && !retry ? "Bubbles joined: a new voice! " : "") + (tw || "Listen to who sings, and when."));
    hud();
  }
  function tapVoice(v) {
    if (v == null || v >= s.unlocked) return;
    if (!ensureAudio()) return;
    if (A.resume) A.resume().catch(() => {});
    const t = A.currentTime;
    voice(t + 0.003, v, 0.42); s.bounce[v] = 1;
    if (s.phase !== "answer") return;
    let best = null, bd = 1e9;
    for (const ex of s.expected) { if (ex.hit || ex.v !== v) continue; const d = Math.abs(t - ex.t); if (d < bd) { bd = d; best = ex; } }
    const tap = { t, v, ok: false, grade: "" };
    if (best && bd <= s.T.win) { best.hit = tap; tap.ok = true; tap.grade = bd <= 0.05 ? "Perfect" : bd <= 0.09 ? "Good" : "OK"; }
    s.taps.push(tap);
  }
  function judge() {
    const misses = s.expected.filter(x => !x.hit).length, extras = s.taps.filter(t => !t.ok).length;
    let pts = 0, perfect = 0;
    for (const ex of s.expected) if (ex.hit) { pts += ex.hit.grade === "Perfect" ? 100 : ex.hit.grade === "Good" ? 60 : 30; if (ex.hit.grade === "Perfect") perfect++; }
    s.phase = "result";
    if (!misses && !extras) {
      s.score += pts; s.round++;
      s.next = () => beginRound(false);
      say("Round cleared! +" + pts + (perfect === s.expected.length ? " (all Perfect)" : "") + ". Next one is faster.");
    } else {
      s.lives--;
      const why = [misses ? misses + " missed" : "", extras ? extras + " wrong or off-beat" : ""].filter(Boolean).join(", ");
      if (s.lives <= 0) { s.phase = "over"; s.next = null; say("Out of tries (" + why + "). You reached round " + s.round + " with " + s.score + " points."); startBtn.textContent = "Play again"; hud(); return; }
      s.next = () => beginRound(true);
      say("Not quite: " + why + ". " + s.lives + (s.lives === 1 ? " try" : " tries") + " left.");
    }
    s.nextAt = A.currentTime + 2.2;
    hud();
  }
  function update(dt) {
    for (let v = 0; v < 5; v++) {
      s.bounce[v] = Math.max(0, s.bounce[v] - dt * 3.2);
      const tx = v < s.unlocked ? seatX(seatOf(v), s.unlocked) : W + 60;
      s.xs[v] = lerp(s.xs[v], tx, 1 - Math.exp(-5 * dt));
    }
    if (!A || !s.T) return;
    const t = A.currentTime, T = s.T;
    if (s.phase === "intro" || s.phase === "listen" || s.phase === "gap" || s.phase === "answer") {
      while (s.played < s.listen.length && t >= s.listen[s.played].t) { s.bounce[s.listen[s.played].v] = 1; s.played++; }
      if (t >= T.L0 && s.phase === "intro") s.phase = "listen";
      if (t >= T.G0 && s.phase === "listen") s.phase = "gap";
      if (s.phase === "gap" && !s.swapped && t >= T.G0 + T.b * 0.6 && s.plan.tw.includes("swap")) {
        s.swapped = true;
        const a = Math.floor(R() * s.unlocked);
        let b = Math.floor(R() * (s.unlocked - 1)); if (b >= a) b++;
        const tmp = s.seat[a]; s.seat[a] = s.seat[b]; s.seat[b] = tmp;
        s.swapPair = [s.seat[a], s.seat[b]];
      }
      if (s.phase === "gap" && t >= T.A0 - 0.2) { s.phase = "answer"; say("Your turn: same singers, same rhythm."); }
      if (s.phase === "answer" && t > T.end + T.win) judge();
    } else if (s.phase === "result" && s.next && t >= s.nextAt) { const f = s.next; s.next = null; f(); }
  }
  function curtainAmount(t) {
    if (!s.T || !s.plan.tw.includes("curtain")) return 0;
    if (s.phase === "intro" || s.phase === "listen") return 1;
    if (s.phase === "gap") return clamp(1 - (t - s.T.G0) / (s.T.b * 1.2), 0, 1);
    return 0;
  }
  function draw(now) {
    const bg = ctx.createLinearGradient(0, 0, 0, H); bg.addColorStop(0, "#3b1673"); bg.addColorStop(1, "#6a2bb8");
    ctx.fillStyle = bg; ctx.fillRect(0, 0, W, H);
    ctx.fillStyle = "rgba(255,240,170,.07)";
    ctx.beginPath(); ctx.moveTo(W / 2 - 40, 0); ctx.lineTo(W / 2 + 40, 0); ctx.lineTo(W - 10, STAGE_Y + 28); ctx.lineTo(10, STAGE_Y + 28); ctx.closePath(); ctx.fill();
    rr(ctx, 6, STAGE_Y, W - 12, 34, 14); ctx.fillStyle = "#c13ea6"; ctx.fill();
    rr(ctx, 6, STAGE_Y, W - 12, 10, 6); ctx.fillStyle = "#ff7ad0"; ctx.fill();
    const t = A ? A.currentTime : 0;
    // seat numbers stay put; singers move between them
    ctx.textAlign = "center"; ctx.textBaseline = "middle";
    for (let k = 0; k < s.unlocked; k++) {
      ctx.fillStyle = "rgba(255,255,255,.85)"; ctx.font = "700 12px Fredoka, system-ui, sans-serif";
      ctx.beginPath(); ctx.arc(seatX(k, s.unlocked), STAGE_Y + 22, 9, 0, TAU); ctx.fillStyle = "rgba(60,10,110,.55)"; ctx.fill();
      ctx.fillStyle = "#fff"; ctx.fillText(String(k + 1), seatX(k, s.unlocked), STAGE_Y + 22.5);
    }
    for (let v = 0; v < 5; v++) {
      const x = s.xs[v]; if (x > W + 40) continue;
      const tx = v < s.unlocked ? seatX(seatOf(v), s.unlocked) : x;
      const hop = Math.min(1, Math.abs(x - tx) / 50) * 22;
      const b = s.bounce[v], size = 64;
      let pop = 1;
      if (v === 4 && s.joinT > 0) pop = easeOutBack(clamp((now - s.joinT) / 700, 0, 1));
      const w = size * (1 + 0.18 * b) * pop, h = size * (1 - 0.2 * b) * pop;
      drawPlush(ctx, x - w / 2, STAGE_Y + 4 - h - hop, w, h, VOICES[v].color, { face: b > 0.3 ? "happy" : "dot" });
      if (b > 0.1) { ctx.fillStyle = "rgba(255,255,255," + b + ")"; ctx.font = "700 20px Fredoka, system-ui, sans-serif"; ctx.fillText("♪", x + 26, STAGE_Y - h - 8 - (1 - b) * 14); }
      ctx.fillStyle = "#fff"; ctx.font = "700 12px Nunito, system-ui, sans-serif"; ctx.fillText(VOICES[v].name, x, STAGE_Y - h - (hop > 1 ? hop : 0) - 4 + (b > 0.1 ? -12 : 0));
    }
    // curtain
    const c = curtainAmount(t);
    if (c > 0) {
      const half = (W / 2) * c;
      for (const side of [0, 1]) {
        const x0 = side ? W - half : 0;
        const g = ctx.createLinearGradient(x0, 0, x0 + half, 0);
        for (let i = 0; i <= 6; i++) g.addColorStop(i / 6, i % 2 ? "#b0136e" : "#e2389a");
        ctx.fillStyle = g; ctx.fillRect(x0, 0, half, STAGE_Y + 34);
      }
      ctx.fillStyle = "#ffd23a"; ctx.fillRect(0, 0, W, 10);
      if (c > 0.9) { ctx.fillStyle = "#fff3a0"; ctx.font = "700 16px Fredoka, system-ui, sans-serif"; ctx.fillText("Who is singing?", W / 2, 80); }
    }
    // twist tags
    if (s.phase !== "idle" && s.plan.tw.length) {
      let x = 12;
      ctx.font = "700 11px Fredoka, system-ui, sans-serif"; ctx.textAlign = "left";
      for (const k of s.plan.tw) {
        const label = TWIST[k].tag, w = ctx.measureText(label).width + 16;
        rr(ctx, x, 16, w, 20, 10); ctx.fillStyle = "#ffd23a"; ctx.fill();
        ctx.fillStyle = "#7a3a00"; ctx.fillText(label, x + 8, 26.5); x += w + 6;
      }
      ctx.textAlign = "center";
    }
    // track
    const ly = 194, bars = s.plan.bars, slots = bars * 8, x0 = 34, x1 = W - 34;
    const sx = k => x0 + (x1 - x0) * (k + 0.5) / slots;
    rr(ctx, 14, ly, W - 28, 96, 18); ctx.fillStyle = "rgba(20,5,45,.55)"; ctx.fill();
    const label = { idle: "TAP THE SINGERS TO HEAR THEM", intro: "GET READY", listen: "LISTEN", gap: "GET READY", answer: "YOUR TURN", result: "RESULT", over: "RESULT" }[s.phase] || "";
    ctx.fillStyle = "#cdb6f0"; ctx.font = "700 12px Fredoka, system-ui, sans-serif"; ctx.textAlign = "left"; ctx.fillText(label, 28, ly + 16);
    ctx.textAlign = "right"; ctx.fillText(s.bpm + " BPM", W - 28, ly + 16);
    if (s.phase === "intro" || s.phase === "gap") {
      const base = s.phase === "intro" ? s.T.t0 : s.T.G0, beat = Math.floor((t - base) / s.T.b);
      ctx.textAlign = "center"; ctx.fillStyle = "#fff3a0"; ctx.font = "700 16px Fredoka, system-ui, sans-serif";
      ctx.fillText(beat >= 3 ? (s.phase === "intro" ? "Listen!" : "Go!") : String(Math.max(1, beat + 1)), W / 2, ly + 16);
    }
    for (let k = 0; k < slots; k++) {
      const x = sx(k), strong = k % 2 === 0;
      ctx.strokeStyle = strong ? "rgba(255,255,255,.28)" : "rgba(255,255,255,.1)"; ctx.lineWidth = strong ? 2 : 1;
      ctx.beginPath(); ctx.moveTo(x, ly + 34); ctx.lineTo(x, ly + 78); ctx.stroke();
      if (k % 8 === 0 && k) { ctx.strokeStyle = "rgba(255,210,58,.5)"; ctx.lineWidth = 2; ctx.beginPath(); ctx.moveTo(x - (x1 - x0) / slots / 2, ly + 30); ctx.lineTo(x - (x1 - x0) / slots / 2, ly + 82); ctx.stroke(); }
    }
    const dot = (x, y, col, ring) => { ctx.beginPath(); ctx.arc(x, y, 9, 0, TAU); ctx.fillStyle = col; ctx.fill(); if (ring) { ctx.lineWidth = 2.5; ctx.strokeStyle = ring; ctx.stroke(); } };
    const hidden = s.plan.tw.includes("curtain");
    if (s.phase === "listen" || s.phase === "gap") {
      const fade = s.phase === "gap" ? clamp(1 - (t - s.T.G0) / (s.T.b * 2), 0, 1) : 1;
      ctx.globalAlpha = fade;
      const counts = {};
      for (let i = 0; i < s.played; i++) {
        const n = s.listen[i], k = Math.round((n.t - s.T.L0) / s.T.e), c2 = counts[k] = (counts[k] || 0) + 1;
        dot(sx(k), ly + 56 + (c2 - 1) * 18 - 9 * (c2 > 1 ? 1 : 0), hidden ? "#9a86c0" : VOICES[n.v].color, "#fff");
      }
      ctx.globalAlpha = 1;
    }
    if (s.phase === "answer" || s.phase === "result" || s.phase === "over") {
      if (s.phase !== "answer") {
        const counts = {};
        for (const ex of s.expected) { const c2 = counts[ex.slot] = (counts[ex.slot] || 0) + 1; ctx.beginPath(); ctx.arc(sx(ex.slot), ly + 48 + (c2 - 1) * 20, 10, 0, TAU); ctx.lineWidth = 3; ctx.strokeStyle = ex.hit ? VOICES[ex.v].color : "#ff5a6a"; ctx.stroke(); }
      }
      for (const tp of s.taps) {
        const k = (tp.t - s.T.A0) / s.T.e;
        if (k < -1 || k > slots + 1) continue;
        const x = x0 + (x1 - x0) * (k + 0.5) / slots;
        dot(x, ly + (s.phase === "answer" ? 56 : 70), VOICES[tp.v].color, tp.ok ? "#fff" : "#ff5a6a");
      }
    }
    if (s.phase === "listen" || s.phase === "answer") {
      const base = s.phase === "listen" ? s.T.L0 : s.T.A0, k = (t - base) / s.T.e;
      if (k >= -0.5 && k <= slots + 0.5) {
        const x = x0 + (x1 - x0) * (clamp(k, 0, slots) + 0.5) / slots;
        ctx.strokeStyle = "#fff3a0"; ctx.lineWidth = 3; ctx.beginPath(); ctx.moveTo(x, ly + 28); ctx.lineTo(x, ly + 84); ctx.stroke();
      }
    }
    if (s.phase === "result" || s.phase === "over") {
      ctx.fillStyle = "#cdb6f0"; ctx.font = "700 11px Nunito, system-ui, sans-serif"; ctx.textAlign = "center";
      ctx.fillText("rings = the tune · dots = your taps", W / 2, ly + 90);
    }
  }
  function hit(e) {
    const p = toLocal(cv, e, W, H);
    if (p.y < 40 || p.y > STAGE_Y + 36) return null;
    let best = null, bd = 44;
    for (let v = 0; v < s.unlocked; v++) { const d = Math.abs(p.x - s.xs[v]); if (d < bd) { bd = d; best = v; } }
    return best;
  }
  cv.addEventListener("pointerdown", e => { cv.focus({ preventScroll: true }); const v = hit(e); if (v != null) tapVoice(v); });
  cv.addEventListener("keydown", e => {
    const k = parseInt(e.key, 10);
    if (k >= 1 && k <= s.unlocked) { e.preventDefault(); if (!e.repeat) tapVoice(s.seat[k - 1]); }
  });
  startBtn.addEventListener("click", start);
  hud();
  return { el: $("#choir"), update, draw, always: () => s.phase !== "idle" && s.phase !== "over" };
})();
