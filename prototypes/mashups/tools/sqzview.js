const SQZ = (() => {
  const CW = 400, CH = 340;
  const cv = $("#sqz-cv"), ctx = setupCanvas(cv, CW, CH);
  const say = sayIn($("#sqz-msg")), movesEl = $("#sqz-moves"), parEl = $("#sqz-par"), starsEl = $("#sqz-stars"), lvlBox = $("#sqz-levels");
  const COLORS = ["#ff7ac8", "#7ee8b4", "#56c6ff"];
  const MSG = { squeeze: "Squeezed into the gap!", puff: "Puffed back up!", shove: "Puffed up and shoved something!", push: "", move: "" };
  let li = 0, L, lv, st, hist = [], anim = null, won = false, sel = 0, hintMove = null, hinted = false, jig = -1, C = 40, ox = 0, oy = 0;
  const best = {};
  try { Object.assign(best, JSON.parse(localStorage.getItem("sqz-best") || "{}")); } catch (_) {}

  function starsFor(moves, usedHint) {
    if (moves <= lv.par && !usedHint) return 3;
    if (moves <= Math.ceil(lv.par * 1.5)) return 2;
    return 1;
  }
  const starStr = n => "★".repeat(n) + "☆".repeat(3 - n);
  function renderLevels() {
    lvlBox.replaceChildren();
    SQZ_LEVELS.forEach((l, i) => {
      const b = document.createElement("button");
      b.className = "lvl"; b.type = "button";
      if (i === li) b.setAttribute("aria-current", "true");
      b.innerHTML = '<span class="n">' + (i + 1) + '</span><span class="st">' + (best[l.id] ? starStr(best[l.id]) : "☆☆☆") + "</span>";
      b.setAttribute("aria-label", "Level " + (i + 1) + ", " + l.name);
      b.addEventListener("click", () => { load(i); cv.focus({ preventScroll: true }); });
      lvlBox.appendChild(b);
    });
  }
  function hud() {
    movesEl.textContent = st.ps ? hist.length : 0;
    parEl.textContent = lv.par;
    starsEl.textContent = won ? starStr(starsFor(hist.length, hinted)) : (hinted ? "max ★★" : "");
  }
  function load(i) {
    li = i; lv = SQZ_LEVELS[i]; L = SQE.compile(lv); st = SQE.start(L);
    hist = []; won = false; anim = null; hintMove = null; hinted = false;
    sel = SQE.movers(L)[0];
    C = Math.floor(Math.min(CW / L.W, CH / L.H)); ox = Math.floor((CW - C * L.W) / 2); oy = Math.floor((CH - C * L.H) / 2);
    renderLevels(); hud(); say(lv.tip);
  }
  function tryMove(dir) {
    if (won) { say("Everyone is asleep. Pick another level or Restart."); return; }
    const r = SQE.step(L, st, sel, dir), now = performance.now();
    if (!r) { anim = { kind: "bump", dir, from: st, to: st, t0: now, dur: REDUCED ? 1 : 200 }; say("Bonk! Can't go that way."); return; }
    const pop = r.kind === "puff" || r.kind === "shove";
    anim = { kind: r.kind, from: st, to: r.s, t0: now, dur: REDUCED ? 1 : (pop ? 320 : 150) };
    hist.push(st); st = r.s; hintMove = null;
    won = SQE.won(L, st);
    if (won) {
      const n = starsFor(hist.length, hinted);
      if (!best[lv.id] || n > best[lv.id]) { best[lv.id] = n; try { localStorage.setItem("sqz-best", JSON.stringify(best)); } catch (_) {} }
      renderLevels();
      say("Everyone tucked in! " + hist.length + " moves (best possible " + lv.par + "). " + starStr(n));
    } else say(MSG[r.kind] || "");
    hud();
  }
  function undo() { if (!hist.length) return; st = hist.pop(); won = false; anim = null; hintMove = null; hud(); say(hist.length ? "Took a move back." : "Back to the start."); }
  function restart() { load(li); }
  function hint() {
    if (won) return;
    say("Thinking…");
    setTimeout(() => {
      const sol = SQE.solve(L, st, 300000);
      if (sol === null) { say("No way to finish from here. Undo a few moves."); return; }
      if (sol === undefined) { say("Too many options to check from here. Try Restart."); return; }
      if (!sol.length) return;
      hinted = true; hintMove = sol[0]; sel = hintMove[0];
      say("Hint: " + (SQE.movers(L).length > 1 ? (lv.plush[sel].name || "this plush") + " moves " : "move ") + hintMove[1] + ". " + sol.length + " moves left at best.");
      hud();
    }, 30);
  }

  document.querySelectorAll("#squeeze [data-dir]").forEach(b => b.addEventListener("click", () => tryMove(b.dataset.dir)));
  $("#sqz-undo").addEventListener("click", undo);
  $("#sqz-restart").addEventListener("click", restart);
  $("#sqz-hint").addEventListener("click", hint);
  const KEYS = { ArrowLeft: "left", ArrowRight: "right", ArrowUp: "up", ArrowDown: "down", a: "left", d: "right", w: "up", s: "down" };
  cv.addEventListener("keydown", e => {
    const d = KEYS[e.key];
    if (d) { e.preventDefault(); tryMove(d); }
    else if (e.key === "z" || e.key === "u") undo();
    else if (e.key === "r") restart();
    else if (e.key === "Tab" && SQE.movers(L).length > 1 && !e.shiftKey) { /* let Tab move focus */ }
  });
  let down = null;
  const cellAt = p => [Math.floor((p.x - ox) / C), Math.floor((p.y - oy) / C)];
  cv.addEventListener("pointerdown", e => { down = toLocal(cv, e, CW, CH); cv.focus({ preventScroll: true }); });
  cv.addEventListener("pointerup", e => {
    if (!down) return;
    const p = toLocal(cv, e, CW, CH), dx = p.x - down.x, dy = p.y - down.y;
    down = null;
    if (Math.hypot(dx, dy) >= 18) { tryMove(Math.abs(dx) > Math.abs(dy) ? (dx > 0 ? "right" : "left") : (dy > 0 ? "down" : "up")); return; }
    const [cx, cy] = cellAt(p);
    for (const i of SQE.movers(L)) if (SQE.inRect(st.ps[i], cx, cy)) {
      if (i === sel) { jig = performance.now(); say("Squish!"); } else { sel = i; say("Now moving " + (lv.plush[i].name || "this plush") + "."); }
      return;
    }
    const P = st.ps[sel], pcx = ox + (P.x + P.w / 2) * C, pcy = oy + (P.y + P.h / 2) * C, tx = p.x - pcx, ty = p.y - pcy;
    tryMove(Math.abs(tx) > Math.abs(ty) ? (tx > 0 ? "right" : "left") : (ty > 0 ? "down" : "up"));
  });
  cv.addEventListener("pointercancel", () => { down = null; });

  function drawBoard() {
    ctx.fillStyle = "#3a1270"; ctx.fillRect(0, 0, CW, CH);
    for (let y = 0; y < L.H; y++) for (let x = 0; x < L.W; x++) {
      const px = ox + x * C, py = oy + y * C;
      if (!L.floor[y * L.W + x]) {
        rr(ctx, px + 2, py + 2, C - 4, C - 4, C * 0.2); ctx.fillStyle = "#6a2fc0"; ctx.fill();
        rr(ctx, px + C * 0.15, py + C * 0.12, C * 0.7, C * 0.15, 3); ctx.fillStyle = "rgba(255,255,255,.12)"; ctx.fill();
      } else {
        rr(ctx, px + 1, py + 1, C - 2, C - 2, C * 0.15); ctx.fillStyle = (x + y) % 2 ? "#ffe2f4" : "#ffd6ef"; ctx.fill();
      }
    }
    for (const [x, y] of L.targets) {
      const px = ox + x * C, py = oy + y * C, filled = st.bs.some(b => b[0] === x && b[1] === y);
      rr(ctx, px + 4, py + 4, C - 8, C - 8, C * 0.18);
      ctx.fillStyle = filled ? "rgba(255,210,58,.5)" : "rgba(194,94,0,.12)"; ctx.fill();
      ctx.setLineDash([4, 3]); ctx.lineWidth = 2; ctx.strokeStyle = "#c25e00"; ctx.stroke(); ctx.setLineDash([]);
    }
  }
  function drawBed(i, blanketOnly) {
    const b = lv.plush[i].bed, col = COLORS[i % COLORS.length];
    const bx = ox + b[0] * C, by = oy + b[1] * C, bw = 2 * C, bh = 2 * C;
    if (!blanketOnly) {
      rr(ctx, bx + 3, by + 3, bw - 6, bh - 6, C * 0.3); ctx.fillStyle = shade(col, 0.75); ctx.fill();
      ctx.lineWidth = 3; ctx.strokeStyle = shade(col, -0.2); ctx.stroke();
      rr(ctx, bx + C * 0.35, by + C * 0.2, bw - C * 0.7, C * 0.45, C * 0.22); ctx.fillStyle = "#fff"; ctx.fill();
    }
    rr(ctx, bx + 3, by + bh * 0.52, bw - 6, bh * 0.48 - 3, C * 0.25);
    ctx.fillStyle = shade(col, -0.05); ctx.fill(); ctx.lineWidth = 3; ctx.strokeStyle = shade(col, -0.35); ctx.stroke();
    ctx.fillStyle = "rgba(255,255,255,.6)";
    for (let k = 0; k < 4; k++) { ctx.beginPath(); ctx.arc(bx + C * 0.35 + k * C * 0.42, by + bh * 0.52 + C * 0.3 + (k % 2) * C * 0.22, C * 0.08, 0, TAU); ctx.fill(); }
  }
  function drawBlock(x, y, onTarget) {
    const px = ox + x * C + 4, py = oy + y * C + 4, s = C - 8;
    rr(ctx, px, py, s, s, C * 0.18);
    const g = ctx.createLinearGradient(0, py, 0, py + s); g.addColorStop(0, "#fff3a0"); g.addColorStop(1, onTarget ? "#ffd23a" : "#ffb21e");
    ctx.fillStyle = g; ctx.fill(); ctx.lineWidth = 2.5; ctx.strokeStyle = "#b8640a"; ctx.stroke();
    ctx.fillStyle = "#b8640a"; ctx.font = "700 " + Math.round(C * 0.5) + "px Fredoka, system-ui, sans-serif"; ctx.textAlign = "center"; ctx.textBaseline = "middle";
    ctx.fillText(onTarget ? "✓" : "A", px + s / 2, py + s / 2 + 1);
  }
  function draw(now) {
    drawBoard();
    lv.plush.forEach((_, i) => drawBed(i, false));
    const t = anim ? clamp((now - anim.t0) / anim.dur, 0, 1) : 1;
    st.bs.forEach((b, i) => {
      const f = anim ? anim.from.bs[i] : b, e = easeOut(t);
      drawBlock(lerp(f[0], b[0], e), lerp(f[1], b[1], e), L.targets.some(([x, y]) => x === b[0] && y === b[1]));
    });
    const movers = SQE.movers(L);
    st.ps.forEach((p, i) => {
      let r;
      if (anim && anim.kind !== "bump") {
        const a = anim.from.ps[i], popped = !SQE.round(a) && SQE.round(p);
        const e = popped ? easeOutBack(t) : easeOut(t);
        r = { x: lerp(a.x, p.x, e) * C, y: lerp(a.y, p.y, e) * C, w: lerp(a.w, p.w, e) * C, h: lerp(a.h, p.h, e) * C };
      } else r = { x: p.x * C, y: p.y * C, w: p.w * C, h: p.h * C };
      r.x += ox; r.y += oy;
      if (anim && anim.kind === "bump" && i === sel) {
        const [dx, dy] = SQE.D[anim.dir], k = Math.sin(t * Math.PI);
        r.x += dx * k * 5; r.y += dy * k * 5;
        if (dx) { r.w -= k * 6; r.h += k * 4; r.y -= k * 2; if (dx < 0) r.x += k * 6; } else { r.h -= k * 6; r.w += k * 4; r.x -= k * 2; if (dy < 0) r.y += k * 6; }
      }
      if (jig > 0 && i === sel) {
        const jt = (now - jig) / 420;
        if (jt >= 1) jig = -1;
        else { const k = Math.sin(jt * Math.PI * 3) * (1 - jt) * 0.14, cx = r.x + r.w / 2, by = r.y + r.h; r.w *= 1 + k; r.h *= 1 - k; r.x = cx - r.w / 2; r.y = by - r.h; }
      }
      const thin = p.w !== p.h, sleepy = lv.plush[i].sleepy;
      const face = won ? "sleep" : thin ? "squint" : sleepy ? "sleep" : (anim && anim.kind === "bump" && i === sel && t < 1 ? "squint" : "dot");
      if (movers.length > 1 && i === sel && !won) { rr(ctx, r.x, r.y, r.w, r.h, Math.min(r.w, r.h) * 0.5); ctx.lineWidth = 3; ctx.strokeStyle = "#fff3a0"; ctx.stroke(); }
      drawPlush(ctx, r.x + 3, r.y + 3, r.w - 6, r.h - 6, COLORS[i % COLORS.length], { face, ears: !thin || r.h > r.w });
      if (sleepy && !won && !thin) {
        ctx.fillStyle = "#fff"; ctx.font = "700 " + Math.round(C * 0.4) + "px Fredoka, system-ui, sans-serif"; ctx.textAlign = "left";
        const zz = (now / 900 + i * 0.3) % 1; ctx.globalAlpha = 1 - zz; ctx.fillText("z", r.x + r.w - C * 0.3 + zz * 6, r.y + C * 0.1 - zz * 10); ctx.globalAlpha = 1;
      }
    });
    if (won && (!anim || t >= 1)) lv.plush.forEach((_, i) => drawBed(i, true));
    if (hintMove && !anim) {
      const P = st.ps[hintMove[0]], [dx, dy] = SQE.D[hintMove[1]];
      const cx = ox + (P.x + P.w / 2) * C, cy = oy + (P.y + P.h / 2) * C, k = (Math.sin(now / 180) + 1) * 4;
      const ex = cx + dx * (C * 1.2 + k), ey = cy + dy * (C * 1.2 + k);
      ctx.strokeStyle = "#fff"; ctx.lineWidth = 6; ctx.lineCap = "round";
      ctx.beginPath(); ctx.moveTo(cx + dx * C * 0.5, cy + dy * C * 0.5); ctx.lineTo(ex, ey); ctx.stroke();
      ctx.beginPath(); ctx.moveTo(ex, ey); ctx.lineTo(ex - dx * 12 - dy * 10, ey - dy * 12 - dx * 10); ctx.moveTo(ex, ey); ctx.lineTo(ex - dx * 12 + dy * 10, ey - dy * 12 + dx * 10); ctx.stroke();
    }
    if (anim && t >= 1) anim = null;
  }
  load(0);
  return {
    el: $("#squeeze"), update() {}, draw, always: () => false,
    save: () => ({ li, moves: hist.length }),
    load(saved) { if (saved && typeof saved.li === "number" && SQZ_LEVELS[saved.li]) load(saved.li); },
  };
})();
