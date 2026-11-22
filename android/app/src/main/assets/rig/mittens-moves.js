// Mittens move library for RiveRig: idle fidgets, dance, 20 meals, 10 baths, poke reactions, crying, stinky.
// Every move is keyframed on the whole body (squash, lean, head, ears, arms, feet, tail); the rig adds follow-through on top.
(function boot() {
  const R = window.RiveRig; if (!R || !R.REST) { setTimeout(boot, 25); return; } if (R.movesV) return; R.movesV = 1;
  const REST = R.REST, r2 = R.r2, SM = R.SM, TAU = Math.PI * 2;

  // ---------- tiny timeline DSL ----------
  function TL() {
    const k = {}, ev = [], em = []; let t = 0;
    const o = {
      get t() { return t; },
      to(dt, v, ez) { for (const p in v) { const L = k[p] || (k[p] = [[0, REST[p]]]); if (L[L.length - 1][0] < t) L.push([t, L[L.length - 1][1], 'l']); } t += dt; for (const p in v) k[p].push([t, v[p], ez || 'io']); return o; },
      wait(dt) { t += dt; return o; },
      at(x) { t = x; return o; },
      e(...a) { ev.push([t, ...a]); return o; },
      em(dur, every, preset, where, n) { em.push([t, t + dur, every, preset, where, n]); return o; },
      osc(dt, n, A, B, ez) { const h = dt / n / 2; for (let i = 0; i < n; i++) o.to(h, A, ez || 'io').to(h, B, ez || 'io'); return o; },
      rest(dt, ez) { const b = {}; for (const p in k) b[p] = REST[p]; return o.to(dt || 450, b, ez); },
      out(x, loop) { for (const p in k) k[p].sort((a, b) => a[0] - b[0]); ev.sort((a, b) => a[0] - b[0]); return Object.assign(loop ? { loop: t } : { dur: t }, { k, ev, emit: em }, x || {}); },
      done(x) { return o.out(x); }, loop(x) { return o.out(x, true); },
    };
    return o;
  }
  const S = s => s < 0 ? { arm: 'armL', hx: 'hLx', hy: 'hLy', hz: 'hLz', ear: 'earL', wink: 'winkL', foot: 'footL', eye: 'eyeL', paw: 'pawL' } : { arm: 'armR', hx: 'hRx', hy: 'hRy', hz: 'hRz', ear: 'earR', wink: 'winkR', foot: 'footR', eye: 'eyeR', paw: 'pawR' };
  const hand = (s, inX, y, z) => { const k = S(s), q = { [k.hx]: s < 0 ? inX : -inX, [k.hy]: y }; if (z != null) q[k.hz] = z; return q; };
  const both = (inX, y, z) => Object.assign(hand(-1, inX, y, z), hand(1, inX, y, z));
  const o = (...a) => Object.assign({}, ...a);
  const ST = {};

  // ---------- idle fidgets ----------
  ST.idle_look = TL().to(240, { lx: -0.9 }, 'o')
    .to(520, { spin: -34, turn: -0.4, lean: -1.4, x: -1.2, footL: 2.2, htilt: -2, wag: 10 }, 'io').to(160, { footL: 0, sq: 0.035 }, 'io').to(220, { sq: 0 }, 'io')
    .wait(800).e('blink').to(240, { lx: 0.9 }, 'o')
    .to(700, { spin: 34, turn: 0.4, lean: 1.4, x: 1.2, footR: 2.2, htilt: 2, wag: -10 }, 'io').to(160, { footR: 0, sq: 0.035 }, 'io').to(220, { sq: 0 }, 'io')
    .wait(800).to(220, { lx: 0 }, 'o').to(560, { spin: 0, turn: 0, lean: 0, x: 0, htilt: 0, footL: 1.6, wag: 0 }, 'io').to(160, { footL: 0, sq: 0.03 }).rest(320).done();
  ST.idle_yawn = TL().to(300, { sq: 0.04, pitch: -0.1, close: 0.3 }, 'io')
    .to(650, { sq: -0.1, pitch: 0.45, open: 0.95, mw: 0.8, close: 0.85, armL: 150, armR: 150, hLy: -4, hRy: -4, earL: -8, earR: -8, tongue: 0.25, lift: 1 }, 'io')
    .osc(700, 2, { tilt: 1.5 }, { tilt: -1.5 }, 's')
    .to(550, { sq: 0.05, pitch: -0.05, open: 0, mw: 1, close: 0.35, armL: 0, armR: 0, hLy: 0, hRy: 0, earL: 4, earR: 4, tongue: 0, lift: 0, tilt: 0 }, 'io')
    .osc(520, 2, { open: 0.16, smile: 0.3 }, { open: 0, smile: 0.2 }, 's').to(300, { close: 0, sq: 0, earL: 0, earR: 0 }).e('blink2').wait(400).rest(400).done();
  const wave = s => { const k = S(s), t = TL();
    t.to(220, { [k.arm]: -10, sq: 0.04, lx: s * 0.2 }, 'io').to(380, { [k.arm]: 150, [k.hy]: -3, hap: 1, smile: 1, open: 0.35, lean: -s * 1.4, htilt: s * 5, sq: -0.04, turn: s * 0.15, [k.ear]: -8 }, 'o');
    const a = t.t; t.osc(1800, 4, { [k.arm]: 118 }, { [k.arm]: 165 }, 'io'); const b = t.t; t.at(a).osc(1800, 3, { wag: 16, sq: -0.01 }, { wag: -16, sq: -0.05 }, 's').at(b);
    return t.wait(120).to(460, { [k.arm]: 0, [k.hy]: 0, lean: 0, htilt: 0, sq: 0.035, open: 0, turn: 0, wag: 0, [k.ear]: 0 }, 'io').to(260, { sq: 0, hap: 0.2, smile: 0.4 }).rest(420).done(); };
  ST.idle_waveL = wave(-1); ST.idle_waveR = wave(1);
  R.FIDGETS.push('idle_look', 'idle_yawn', 'idle_waveL', 'idle_waveR');

  // ---------- dance: 20 beats at 120 bpm = 10 s, seamless loop ----------
  ST.dance = (() => { const t = TL(), h = 250, bt = (dn, up) => t.to(h, o({ sq: 0.1, lift: 0 }, dn), 'io').to(h, o({ sq: -0.04, lift: 1.6 }, up || {}), 'o');
    t.e('emit', 'note', 'head');
    bt({ x: 4, lean: 2, armL: -6, armR: 34, htilt: 3, turn: 0.2, hap: 0.7, smile: 0.9 }, { footL: 2.5 }); bt({ footL: 0, lean: 1 }); // two-step right
    bt({ x: -4, lean: -2, armL: 34, armR: -6, htilt: -3, turn: -0.2 }, { footR: 2.5 }); bt({ footR: 0, lean: -1 });          // two-step left
    t.e('emit', 'note', 'head');
    [-1, 1, -1, 1].forEach(d => bt({ x: 0, lean: 0, htilt: d * 2, turn: 0, pitch: 0.1, footL: d < 0 ? 4.5 : 0, footR: d > 0 ? 4.5 : 0, armL: d < 0 ? 45 : -12, armR: d > 0 ? 45 : -12 }, d < 0 ? { footL: 1 } : { footR: 1 })); // running man
    t.e('emit', 'note', 'head');
    [1, -1, 1, -1].forEach(d => { const k = S(d), j = S(-d); t.to(130, { sq: 0.17, lift: 0, footL: 0, footR: 0, pitch: 0, tilt: d * 7, lean: d * 3, htilt: -d * 4, [k.arm]: 150, [k.hy]: -4, [j.arm]: -10, [j.hy]: 0, wide: 0.3, hap: 0 }, 'o').to(370, { sq: 0.12, tilt: d * 6 }, 'io'); }); // the Woah
    t.e('emit', 'note', 'head').to(500, { sq: 0.22, tilt: 0, lean: 0, htilt: 0, armL: -14, armR: -14, hLy: 0, hRy: 0, wide: 0, earL: 10, earR: 10 }, 'io'); // crouch
    { const a = t.t; t.to(260, { sq: -0.18, armL: 120, armR: 120, earL: -6, earR: -6, hap: 1, smile: 1, open: 0.4 }, 'o').to(480, { sq: -0.05 }, 'io').to(120, { sq: 0.28 }, 'o').to(140, { sq: -0.06 }, 'io');
      const b = t.t; t.at(a).to(430, { lift: 15 }, 'o').to(430, { lift: 0 }, 'i').at(a + 60).to(760, { spin: 360 }, 'io').to(1, { spin: 0 }, 'l').at(b).e('emit', 'spark', 'body', 6); } // hop + spin
    t.to(500, { sq: 0.04, armL: 75, armR: 75, open: 0.3, winkR: 1 }, 'o');                                                  // ta-da
    t.e('emit', 'note', 'head');
    [1, -1, 1].forEach(d => bt({ sq: 0.09, pitch: -0.25, armL: d > 0 ? 22 : 6, armR: d > 0 ? 6 : 22, htilt: d * 3, turn: d * 0.15, x: d * 1.5, winkR: 0, open: 0.15 }, { sq: -0.02, lift: 1 })); // Billy bounce
    t.to(h, { sq: 0.09, pitch: -0.25, armL: 6, armR: 22, htilt: -3, turn: -0.15, x: -1.5 }, 'io').rest(h, 'io');
    return t.loop(); })();

  // ---------- eating: 20 foods ----------
  const HOLD = { two: { chest: both(7, -6), mouth: both(10, -13) }, R: { chest: hand(1, 6, -8), mouth: hand(1, 13, -15) } };
  const chew = (t, n, big) => t.osc(n * 260, n, { open: 0.24, puff: big ? 1 : 0.65, htilt: 2.5, sq: 0.025, mw: 0.85 }, { open: 0.02, puff: big ? 0.85 : 0.5, htilt: -2.5, sq: 0, mw: 1 }, 's');
  const gulp = t => t.to(150, { puff: 0, sq: 0.06, pitch: 0.18, open: 0, htilt: 0 }, 'o').e('gulp').to(220, { sq: 0, pitch: 0 }, 'io');
  const bite = (t, H, last) => { t.to(300, o(H.mouth, { open: 0.75, pitch: -0.1, ly: 0.4, lean: 0.4, hap: 0, wide: 0.15 }), 'io').to(90, { open: 0, sq: 0.07, earL: 4, earR: 4 }, 'o').e('bite').e('emit', 'crumb', 'mouth');
    if (last) t.e('done'); return t.to(280, o(H.chest, { sq: 0, earL: 0, earR: 0, lean: 0, pitch: 0, ly: 0.2, puff: 0.5, wide: 0 }), 'io'); };
  const STYLE = {
    chomp(t, H, f) { for (let i = 0; i < f.n; i++) { bite(t, H, i === f.n - 1); chew(t, f.chew || 3); gulp(t); } },
    nibble(t, H, f) { t.to(320, o(H.mouth, { pitch: -0.05, ly: 0.5 }), 'io'); for (let i = 0; i < f.n; i++) t.to(85, { open: 0.3, mw: 0.6, sq: 0.02 }, 'o').to(85, { open: 0, sq: 0, puff: 0.45 }, 'io').e('bite').e('emit', 'crumb', 'mouth', 1);
      t.e('done').to(260, o(H.chest, { puff: 0.55, mw: 1 }), 'io'); chew(t, 3); gulp(t); },
    typewriter(t, H, f) { const m = H.mouth; for (let row = 0; row < 2; row++) { t.to(300, o(m, { hLx: m.hLx + 6, hRx: m.hRx + 6, pitch: -0.05, ly: 0.4, turn: 0.15 }), 'io');
        for (let i = 0; i < f.n; i++) { const p = 6 - (i + 1) * 12 / f.n; t.to(110, { open: 0.35, hLx: m.hLx + p, hRx: m.hRx + p, turn: -p / 32 }, 'io').to(90, { open: 0, sq: 0.03 }, 'o').e('bite').e('emit', 'crumb', 'mouth', 1); }
        t.to(170, { hLx: m.hLx + 6, hRx: m.hRx + 6, turn: 0.2, sq: 0, wide: 0.4 }, 'o').e('ding').to(120, { wide: 0 }); }
      t.e('done').to(300, o(H.chest, { turn: 0, puff: 0.7 }), 'io'); chew(t, 3);
      if (f.seed) t.to(160, { puff: 0.3, mw: 0.45, open: 0.2, turn: 0.4 }, 'o').e('emit', 'seed', 'mouth').to(220, { open: 0, mw: 1, turn: 0 }); gulp(t); },
    lick(t, H, f) { const L = o(H.mouth); for (const q in L) if (/y$/.test(q)) L[q] += 3;
      t.to(320, o(L, { ly: 0.5 }), 'io'); for (let i = 0; i < f.n; i++) t.to(170, { tongue: 1, pitch: 0.25, sq: -0.04, open: 0.12, hap: 0.5, turn: f.swirl ? (i % 2 ? 0.25 : -0.25) : 0 }, 'io').e('lick').to(230, { tongue: 0.15, pitch: -0.05, sq: 0.01, open: 0 }, 'io');
      t.to(200, { tongue: 0, turn: 0, hap: 0.8, smile: 0.8 }, 'io'); if (f.then) bite(t, H, true), chew(t, 3), gulp(t); else t.e('done').to(300, o(H.chest), 'io'); },
    whole(t, H) { t.to(320, o(H.mouth, { open: 1, mw: 1.1, pitch: 0.1, wide: 0.3 }), 'io').to(110, { open: 0, mw: 1, puff: 1.1, sq: 0.08 }, 'o').e('bite').e('done').to(300, o(H.chest, { sq: 0, wide: 0, hap: 1 }), 'io'); chew(t, 5, true); gulp(t); },
    slurp(t, H, f) { for (let i = 0; i < 3; i++) { t.to(220, { pitch: -0.25, ly: 0.6, mw: 0.5, open: 0.25 }, 'io'); const a = t.t; t.osc(700, 5, { sq: 0.04, open: 0.2, mw: 0.42 }, { sq: -0.01, open: 0.28, mw: 0.5 }, 's'); f.wins.push([a, t.t]); t.to(120, { open: 0, mw: 1, puff: 0.6, pitch: 0.05 }, 'o'); chew(t, 2); gulp(t); } t.e('done'); },
    sip(t, H, f) { t.to(320, o(f.mp || H.mouth, { pitch: -0.05 }), 'io').to(160, { mw: 0.42, open: 0.1, puff: -0.4 }, 'o').em(1800, 450, 'bubble', 'mouth', 1).osc(1800, 6, { puff: -0.5, sq: 0.03 }, { puff: -0.3, sq: 0 }, 's')
      .to(140, { puff: -0.6, sq: 0.06, wide: 0.4 }, 'o').e('crumple').to(260, o(H.chest, { mw: 1, open: 0, puff: 0, sq: 0, wide: 0 }), 'io').wait(300).e('done'); },
    big(t, H) { t.to(380, o(H.mouth, { open: 1, mw: 1.45, pitch: 0.15, htilt: -6, wide: 0.5, sq: -0.05 }), 'io').wait(150).to(110, { open: 0, mw: 1, sq: 0.1, puff: 1.2, htilt: 0, wide: 0 }, 'o').e('bite').e('emit', 'crumb', 'mouth', 5).to(300, o(H.chest, { sq: 0 }), 'io');
      chew(t, 6, true); gulp(t); bite(t, H, true); chew(t, 3); gulp(t); },
    gobble(t, H, f) { for (let i = 0; i < f.n; i++) { t.to(160, o(H.mouth, { open: 0.85, pitch: -0.1 }), 'io').to(70, { open: 0, sq: 0.06, puff: 0.7 }, 'o').e('bite').e('emit', 'crumb', 'mouth', 2); if (i === f.n - 1) t.e('done'); t.to(160, o(H.chest, { sq: 0 }), 'io'); chew(t, 1); } gulp(t); },
  };
  const REACT = {
    yum(t) { t.to(320, o(hand(-1, 10, 1), hand(1, 0, 0), { hap: 1, smile: 1, open: 0.3, sq: 0.03, pitch: 0.1 }), 'io');
      const a = t.t; t.osc(1200, 3, { hLx: 13, hLy: 3, htilt: 4, lean: 1 }, { hLx: 8, hLy: -1, htilt: -4, lean: -1 }, 's'); const b = t.t; t.at(a).osc(1200, 4, { wag: 16 }, { wag: -16 }, 's').at(b);
      t.to(200, { sq: 0.12, hLx: 0, hLy: 0, htilt: 0, lean: 0 }, 'io').to(220, { sq: -0.1, lift: 7, armL: 40, armR: 40 }, 'o').to(240, { lift: 0, sq: 0.18 }, 'i').to(220, { sq: 0, armL: 0, armR: 0 }, 'io'); },
    love(t) { t.to(350, o(hand(-1, 2, -18), hand(1, 2, -18), { hap: 1, smile: 0.8, blush: 1, sq: 0.03 }), 'io').e('emit', 'heart', 'head', 2)
      .osc(1600, 2, { htilt: 6, lean: 1.4, x: 1 }, { htilt: -6, lean: -1.4, x: -1 }, 's').e('emit', 'heart', 'head', 2).to(300, { x: 0, htilt: 0, lean: 0 }); },
    spicy(t) { t.to(150, { wide: 1, open: 0.2, sq: -0.05 }, 'o').wait(350).to(500, { red: 1, wide: 0.6, earL: -10, earR: -10 }, 'io').e('emit', 'steam', 'earL', 3).e('emit', 'steam', 'earR', 3)
      .to(200, o(hand(1, 12, -14), { tongue: 1, open: 0.5, sqz: 0.8 }), 'io').em(1500, 200, 'steam', 'head', 1);
      const a = t.t; t.osc(1500, 6, { hRx: -16, tongue: 1 }, { hRx: -8, tongue: 0.7 }, 'io'); const b = t.t; t.at(a).osc(1500, 3, { lift: 4, sq: -0.06 }, { lift: 0, sq: 0.08 }, 'io').at(b);
      t.to(400, { red: 0.4, tongue: 0, sqz: 0, open: 0, wide: 0, earL: 0, earR: 0, hRx: 0, hRy: 0, sq: 0 }, 'io').to(300, { red: 0, frown: 0.3 }).wait(200); },
    sour(t) { t.to(130, { sqz: 1, mw: 0.4, open: 0.15, sq: 0.12, earL: 14, earR: 14, pitch: -0.2 }, 'o'); const a = t.t; t.wait(1000); const b = t.t; t.at(a).osc(1000, 10, { x: 0.8 }, { x: -0.8 }, 'l').at(b);
      t.osc(700, 3, { turn: 0.35 }, { turn: -0.35 }, 'io').to(300, { sqz: 0, mw: 1, open: 0, sq: 0, earL: 0, earR: 0, pitch: 0, turn: 0, x: 0, smile: 0.6, hap: 0.5 }, 'io').wait(200); },
    freeze(t) { t.to(150, { sqz: 1, sq: 0.08, frown: 0.5 }, 'o').to(300, o(hand(-1, -1, -22), hand(1, -1, -22), { armL: 30, armR: 30, earL: 16, earR: 16 }), 'io');
      const a = t.t; t.wait(1100); const b = t.t; t.at(a).osc(1100, 11, { x: 0.7 }, { x: -0.7 }, 'l').at(b);
      t.to(400, { sqz: 0, frown: 0, hLx: 0, hLy: 0, hRx: 0, hRy: 0, armL: 0, armR: 0, earL: 0, earR: 0, sq: 0, x: 0, hap: 1, smile: 1 }, 'io').wait(300); },
  };
  const foodProp = (f, key) => (I, t) => { const c = I.ctr, W = I.W; if (c.done || !W.pawR) return '';
    let x, y; if (f.hold === 'two') { x = (W.pawL[0] + W.pawR[0]) / 2; y = (W.pawL[1] + W.pawR[1]) / 2 - 5.5 * (I.foodK != null ? I.foodK : 1); } else if (f.grip && I.gripStick) { const s = f.sc || 1.15, a = (f.grip[2] || 0) * Math.PI / 180, gx = f.grip[0], gy = f.grip[1]; x = W.pawR[0] - (gx * Math.cos(a) - gy * Math.sin(a)) * s; y = W.pawR[1] - (gx * Math.sin(a) + gy * Math.cos(a)) * s; } else { x = W.pawR[0] - 2.5; y = W.pawR[1] - 6 * (I.foodK1 != null ? I.foodK1 : I.foodK != null ? I.foodK : 1); }
    if (I.foodMid && W.pawL && !(f.grip && I.gripStick)) { x = (W.pawL[0] + W.pawR[0]) / 2; y = (W.pawL[1] + W.pawR[1]) / 2; } // Pip/Puff: food sits between both flippers
    if (I.foodDY && I.foodDY[key]) y += I.foodDY[key];
    const nb = Math.min(c.bite || 0, f.bm ? f.bm.length : 0), id = 'bm' + I.u + key; let m = '';
    if (nb) { m = '<mask id="' + id + '" maskUnits="userSpaceOnUse" x="-30" y="-30" width="60" height="60"><rect x="-30" y="-30" width="60" height="60" fill="#fff"/>'; for (let i = 0; i < nb; i++) { const b = f.bm[i]; m += '<circle cx="' + b[0] + '" cy="' + b[1] + '" r="' + b[2] + '" fill="#000"/>'; } m += '</mask>'; }
    const body = typeof f.svg === 'function' ? f.svg(I, t, c, x, y) : f.svg;
    return '<g transform="translate(' + r2(x) + ' ' + r2(y) + ') rotate(' + (f.grip && I.gripStick ? f.grip[2] || 0 : f.rot || 0) + ') scale(' + r2(SM(t / 220) * (f.sc || 1.15)) + ')">' + m + '<g' + (nb ? ' mask="url(#' + id + ')"' : '') + '>' + body + '</g></g>'; };
  const top = (n, y, w, r) => Array.from({ length: n }, (_, i) => [r2(w / 2 - i * w / (n - 1 || 1)), y, r]);
  const FOODS = {
    apple: { label: 'Apple', d: 'Two paws, three crunchy bites.', hold: 'two', style: 'chomp', n: 3, react: 'yum', bm: [[1.5, -5, 2.4], [-2.4, -4.4, 2.4], [3.6, -1.2, 2.6]],
      svg: '<circle cx="0" cy="0.5" r="5.2" fill="#ff5a5f"/><path d="M-2.2 -3.6 Q0 -2.2 2.2 -3.6" fill="none" stroke="#d93a45" stroke-width="0.8"/><path d="M0 -4 L0.6 -6.4" stroke="#7a4a2a" stroke-width="0.9" stroke-linecap="round"/><path d="M0.6 -5.6 Q3 -7.4 4 -5 Q2 -4.4 0.6 -5.6Z" fill="#6fcf5a"/><ellipse cx="-2" cy="-1.4" rx="1.4" ry="0.9" fill="#ffffff" opacity="0.5"/>' },
    banana: { label: 'Banana', d: 'One paw, bites from the tip.', hold: 'R', style: 'chomp', n: 3, react: 'yum', rot: -10, bm: [[-1.6, -6.4, 2], [-3, -3.8, 2.2], [-4, -0.8, 2.4]],
      svg: '<path d="M-5 3 Q-6 -3 -2 -6 Q-1 -6.5 -0.6 -5.6 Q-3.6 -2 -2 3 Q0 6 5 5.6 Q5.6 6.4 4.6 7 Q-2 8 -5 3Z" fill="#ffd84a" stroke="#e0b52a" stroke-width="0.5"/><path d="M-2 -6 L-1.2 -7.4" stroke="#7a5a2a" stroke-width="1" stroke-linecap="round"/>' },
    carrot: { label: 'Carrot', d: 'Fast rabbit nibbles down the carrot.', hold: 'two', style: 'nibble', n: 8, react: 'yum', bm: [[0, -7, 1.6], [0, -5.4, 1.8], [0, -3.6, 2], [0, -1.8, 2.1], [0, 0, 2.3], [0, 1.8, 2.4], [0, 3.4, 2.6], [0, 5, 3]],
      svg: '<path d="M-2.6 4 Q0 5 2.6 4 L0.4 -7 Q0 -7.8 -0.4 -7 Z" fill="#ff9a3a"/><path d="M-1.6 0.5 L0.4 0.2 M-1 -2.5 L0.8 -2.8" stroke="#e07a1a" stroke-width="0.5"/><path d="M0 4.4 Q-2.4 8 -1.2 9 Q0 7 0 4.4 Q1 8.6 2.6 8.2 Q1.4 6 0 4.4Z" fill="#6fcf5a"/>' },
    cookie: { label: 'Cookie', d: 'Crumbly bites, crumbs everywhere, love.', hold: 'R', style: 'chomp', n: 3, react: 'love', bm: [[1.5, -4.6, 2.3], [-2, -4.2, 2.3], [3.8, -1.6, 2.4]],
      svg: '<circle r="5" fill="#e0a75e"/><circle r="5" fill="none" stroke="#c48a45" stroke-width="0.6"/><circle cx="-2" cy="-1.5" r="0.8" fill="#5a3420"/><circle cx="1.8" cy="0.6" r="0.9" fill="#5a3420"/><circle cx="-0.6" cy="2.4" r="0.7" fill="#5a3420"/><circle cx="2.2" cy="-2.6" r="0.6" fill="#5a3420"/>' },
    donut: { label: 'Donut', d: 'Peeks through the hole first, then bites.', hold: 'two', style: 'chomp', n: 3, react: 'yum', bm: [[1.6, -5, 2.4], [-2.6, -4.4, 2.4], [4.2, -1.4, 2.4]],
      pre(t) { t.to(420, { hLx: 23, hLy: -24, hRx: -2, hRy: -24, lx: 0.6, ly: -0.1, winkL: 1, pitch: 0.05, wide: 0.3 }, 'io').wait(500).to(240, { hLx: 18, hRx: -7 }, 'io').to(240, { hLx: 23, hRx: -2 }, 'io').to(400, o(both(7, -6), { winkL: 0, lx: 0, wide: 0, hap: 1 }), 'io'); },
      svg: '<path fill-rule="evenodd" d="M5.4 0 A5.4 5.4 0 1 0 -5.4 0 A5.4 5.4 0 1 0 5.4 0Z M1.7 0 A1.7 1.7 0 1 1 -1.7 0 A1.7 1.7 0 1 1 1.7 0Z" fill="#e8b06a"/><path fill-rule="evenodd" d="M4.7 -0.4 Q4.4 -4.6 0 -4.7 Q-4.4 -4.6 -4.7 -0.4 Q-4.2 2.6 -2.6 2 Q-1 3.4 0 2.2 Q1.6 3.6 2.8 2.2 Q4.4 2.6 4.7 -0.4Z M2.3 0 A2.3 2.3 0 1 1 -2.3 0 A2.3 2.3 0 1 1 2.3 0Z" fill="#ff8fc8"/><path d="M-3 -2.6 l0.8 -0.6 M1.6 -3.4 l0.9 0.3 M3.4 -1 l0.2 0.9 M-3.6 0.6 l0.6 0.6 M-0.6 -3.6 l-0.3 0.8" stroke="#ffffff" stroke-width="0.6" stroke-linecap="round"/>' },
    pizza: { label: 'Pizza slice', d: 'Holds it up high, looks up, then bites.', hold: 'R', style: 'chomp', n: 2, react: 'yum', bm: [[0, -6.4, 2.6], [0, -3.4, 3]],
      pre(t) { t.to(450, o(hand(1, 10, -30), { pitch: 0.5, ly: -0.9, open: 0.6, armR: 30 }), 'io').wait(500).to(380, o(hand(1, 6, -8), { pitch: 0, ly: 0.3, open: 0, armR: 0 }), 'io'); },
      svg: '<path d="M-4.5 4 L4.5 4 L0 -7 Z" fill="#ffd25a"/><path d="M-5 4 Q0 6.2 5 4 L4.6 5.6 Q0 7.6 -4.6 5.6Z" fill="#d9903a"/><circle cx="-1.2" cy="1.4" r="1.1" fill="#e2483a"/><circle cx="1.4" cy="-1.4" r="0.9" fill="#e2483a"/><circle cx="1.6" cy="2.4" r="0.8" fill="#e2483a"/>' },
    icecream: { label: 'Ice cream', d: 'Four long licks, then a bite of cone.', hold: 'R', style: 'lick', n: 4, then: true, react: 'yum', bm: [[0, -6, 3.4], [0, -2.4, 3.8]],
      svg: (I, t, c) => { const k = 1 - 0.07 * Math.min(4, c.lick || 0); return '<path d="M-3.4 0 L3.4 0 L0 9 Z" fill="#e8b06a"/><path d="M-2.4 1.6 L1.6 5.6 M2.4 1.6 L-1.6 5.6" stroke="#c48a45" stroke-width="0.5"/><circle cx="0" cy="-1.6" r="3.8" fill="#ffc0de"/><circle cx="0" cy="' + r2(-5.2 * k) + '" r="' + r2(3 * k) + '" fill="#fff4c2"/>'; } },
    burger: { label: 'Burger', d: 'Opens super wide for one huge chomp.', hold: 'two', style: 'big', react: 'yum', bm: [[0, -6, 3.6], [3.6, -4.6, 3.6]],
      svg: '<path d="M-6 3.6 L6 3.6 Q6 6.4 3 6.4 L-3 6.4 Q-6 6.4 -6 3.6Z" fill="#e8963a"/><rect x="-6.2" y="1.2" width="12.4" height="2.6" rx="1.3" fill="#7a3a24"/><path d="M-5.6 0.6 L5.6 0.6 L4 2.6 L2.4 1.4 L-5.6 1.6Z" fill="#ffd23a"/><path d="M-6.4 -0.6 Q-4.8 1 -3.2 -0.4 Q-1.6 1 0 -0.4 Q1.6 1 3.2 -0.4 Q4.8 1 6.4 -0.6 L6.4 0.8 L-6.4 0.8Z" fill="#7ad36a"/><path d="M-6 -0.6 Q-6 -6.5 0 -6.5 Q6 -6.5 6 -0.6Z" fill="#f0a64a"/><path d="M-2.4 -4.2 l0.8 -0.3 M1 -5 l0.8 0.2 M3 -3.4 l0.6 -0.5 M-4 -2.6 l0.5 -0.6" stroke="#fff4d6" stroke-width="0.6" stroke-linecap="round"/>' },
    sushi: { label: 'Sushi', d: 'Pops it in whole, cheeks puffed, love.', hold: 'two', style: 'whole', react: 'love',
      svg: '<rect x="-4.5" y="-1.5" width="9" height="4.5" rx="2.2" fill="#ffffff" stroke="#e8e0d8" stroke-width="0.4"/><path d="M-4.8 -1 Q-5 -4 0 -4 Q5 -4 4.8 -1 Q0 0 -4.8 -1Z" fill="#ff8a65"/><path d="M-2.5 -3.6 L-1.5 -1 M0.5 -3.9 L1.3 -1.1 M3 -3.4 L3.4 -1.2" stroke="#ffd1bf" stroke-width="0.6"/><rect x="-1.2" y="-4" width="2.4" height="7" fill="#2f4a3a"/>' },
    watermelon: { label: 'Watermelon', d: 'Typewriter bites across, spits a seed.', hold: 'two', style: 'typewriter', n: 5, seed: true, react: 'yum', bm: top(5, -0.2, 10, 2).concat(top(5, 1.8, 9, 2.2)),
      svg: '<path d="M-7 0 A7 7 0 0 0 7 0 Z" fill="#7ad36a"/><path d="M-6 0 A6 6 0 0 0 6 0 Z" fill="#ff5a6a"/><ellipse cx="-2.6" cy="2" rx="0.4" ry="0.7" fill="#2a1a30"/><ellipse cx="0" cy="3.4" rx="0.4" ry="0.7" fill="#2a1a30"/><ellipse cx="2.6" cy="2" rx="0.4" ry="0.7" fill="#2a1a30"/>' },
    strawberry: { label: 'Strawberry', d: 'One bite, blushes, hearts.', hold: 'R', style: 'whole', react: 'love', sc: 0.8,
      svg: '<path d="M0 6 Q-5.6 2 -4.6 -2.4 Q-3.6 -4.4 0 -3.6 Q3.6 -4.4 4.6 -2.4 Q5.6 2 0 6Z" fill="#ff4b5c"/><path d="M-3 -3.4 L-1 -5.6 L0 -3.8 L1 -5.6 L3 -3.4 Q0 -2.6 -3 -3.4Z" fill="#5fc24a"/><circle cx="-2" cy="-0.6" r="0.35" fill="#ffe08a"/><circle cx="1.4" cy="0.4" r="0.35" fill="#ffe08a"/><circle cx="-0.4" cy="2.6" r="0.35" fill="#ffe08a"/><circle cx="2.4" cy="-1.8" r="0.35" fill="#ffe08a"/>' },
    cupcake: { label: 'Cupcake', d: 'Licks the frosting, then bites.', hold: 'two', style: 'lick', n: 2, then: true, react: 'love', bm: [[0, -5.6, 3.4], [2.4, -2.6, 3.4]],
      svg: '<path d="M-4.6 0 L4.6 0 L3.4 6 L-3.4 6Z" fill="#7cc8ff"/><path d="M-2.4 0.4 L-1.8 5.6 M0 0.4 L0 5.6 M2.4 0.4 L1.8 5.6" stroke="#5aa8e8" stroke-width="0.5"/><path d="M-5 0.4 Q-6 -2.6 -3 -3 Q-2.6 -6 0 -5.6 Q2.6 -6 3 -3 Q6 -2.6 5 0.4Z" fill="#ffc0de"/><circle cx="0" cy="-6.4" r="1.4" fill="#ff3b4b"/>' },
    noodles: { label: 'Noodles', d: 'Slurps long noodles from the bowl.', hold: 'two', style: 'slurp', react: 'yum', wins: [],
      svg: (I, t, c, x, y) => { let h = '<path d="M-7 -1 L7 -1 Q6.4 6 0 6.4 Q-6.4 6 -7 -1Z" fill="#ff8fa3"/><path d="M-6 3 L6 3" stroke="#ffffff" stroke-width="0.6" opacity="0.7"/><path d="M-6 -1.2 Q-3 -3 0 -1.4 Q3 -3 6 -1.2" stroke="#ffe08a" stroke-width="1.2" fill="none"/>';
        const w = FOODS.noodles.wins.find(q => t >= q[0] && t <= q[1]); if (w && I.W.mouth) { const u = (t - w[0]) / (w[1] - w[0]), mx = I.W.mouth[0] - x, my = I.W.mouth[1] - y + 0.5, by = -1.5 + (my + 1.5) * u * 0.92;
          h += '<path d="M0 ' + r2(by) + ' Q' + r2(mx * 0.5 + Math.sin(t / 60) * 1.4) + ' ' + r2((by + my) / 2) + ' ' + r2(mx) + ' ' + r2(my) + '" stroke="#ffe08a" stroke-width="1.1" fill="none" stroke-linecap="round"/>'; } return h; } },
    corn: { label: 'Corn on the cob', d: 'Typewriter-style rows, ding at each end.', hold: 'two', style: 'typewriter', n: 6, react: 'yum', bm: top(6, -2.6, 11, 1.6).concat(top(6, -0.6, 11, 1.8)),
      svg: '<path d="M-7 0 L-9.6 -2.6 L-9 2.6Z M7 0 L9.6 -2.6 L9 2.6Z" fill="#9be38a"/><rect x="-7" y="-2.8" width="14" height="5.6" rx="2.8" fill="#ffd84a"/><path d="M-5 -2.6 L-5 2.6 M-2.5 -2.8 L-2.5 2.8 M0 -2.8 L0 2.8 M2.5 -2.8 L2.5 2.8 M5 -2.6 L5 2.6 M-7 0 L7 0" stroke="#f0b52a" stroke-width="0.4"/>' },
    lollipop: { label: 'Lollipop', d: 'Five swirly licks.', hold: 'R', style: 'lick', n: 5, swirl: true, react: 'love', grip: [0, 10.5, -30],
      svg: (I, t, c) => { const k = 1 - 0.06 * Math.min(5, c.lick || 0); return '<path d="M0 3 L0 ' + (I.gripStick ? 14 : 10) + '" stroke="#ffffff" stroke-width="1.2" stroke-linecap="round"/><g transform="scale(' + r2(k) + ')"><circle cx="0" cy="-1" r="4.6" fill="#ff7fc8"/><path d="M0 -1 m-3 0 a3 3 0 1 1 3 3 a2 2 0 1 1 -2 -2 a1 1 0 1 1 1 1" stroke="#fff" stroke-width="0.9" fill="none"/></g>'; } },
    fish: { label: 'Fish', d: 'Jumps with excitement, then gobbles it up.', hold: 'two', style: 'gobble', n: 4, react: 'yum', bm: [[-5, 0, 2.6], [-2.4, -0.4, 2.8], [0.6, 0, 2.8], [3.6, 0, 3]],
      pre(t) { t.to(160, { sq: 0.18 }, 'io').to(260, { sq: -0.15, lift: 9, wide: 1, armL: 40, armR: 40, open: 0.5 }, 'o').to(260, { lift: 0, sq: 0.2 }, 'i').to(200, { sq: 0, wide: 0.3, armL: 0, armR: 0, open: 0 }, 'io'); },
      svg: '<path d="M-6 0 Q-2 -4.6 3.6 -0.4 L7 -3.4 L6.4 0 L7 3.4 L3.6 0.4 Q-2 4.6 -6 0Z" fill="#7cc8ff"/><path d="M-1 -2 Q0 0 -1 2" stroke="#5aa8e8" stroke-width="0.6" fill="none"/><circle cx="-3.6" cy="-0.8" r="0.8" fill="#2a1a30"/>' },
    pepper: { label: 'Hot pepper', d: 'One bite, turns red, steam, fans her tongue.', hold: 'R', style: 'chomp', n: 1, chew: 2, react: 'spicy', rot: 20, bm: [[0.5, -3.4, 2.4]],
      svg: '<path d="M-1 -4 Q4 -3 3 3 Q2 7 -2 8 Q1 4 0 0 Q-0.6 -2.6 -1 -4Z" fill="#ff3b30"/><path d="M-1 -4 Q-2 -6 0 -7" stroke="#4caf50" stroke-width="1.2" fill="none" stroke-linecap="round"/>' },
    lemon: { label: 'Lemon', d: 'One bite, huge sour pucker, shivers.', hold: 'R', style: 'chomp', n: 1, chew: 1, react: 'sour', bm: [[0, -3.6, 2.6]],
      svg: '<path d="M-5.4 0 Q-5.4 -4 0 -4 Q5.4 -4 5.4 0 Q5.4 4 0 4 Q-5.4 4 -5.4 0Z M5.2 -0.7 L6.8 0 L5.2 0.7Z M-5.2 -0.7 L-6.8 0 L-5.2 0.7Z" fill="#ffe14a"/><ellipse cx="-1.8" cy="-1.6" rx="1.4" ry="0.7" fill="#ffffff" opacity="0.5"/>' },
    juice: { label: 'Juice box', d: 'Sips through the straw, squeezes the box.', hold: 'R', style: 'sip', react: 'yum', mp: hand(1, 17, -3),
      svg: (I, t, c) => { const k = c.crumple ? 0.75 : 1; return '<g transform="scale(' + k + ' 1)"><rect x="-3.4" y="-3" width="6.8" height="9" rx="0.8" fill="#9be38a"/><rect x="-2.4" y="0" width="4.8" height="3.6" rx="0.6" fill="#ffffff"/><circle cx="0" cy="1.8" r="1.1" fill="#ff9a3a"/></g><path d="M1.4 -3 L2.4 -8.4" stroke="#ff5cc6" stroke-width="0.9" stroke-linecap="round"/>'; } },
    popsicle: { label: 'Popsicle', d: 'Licks, bites, brain freeze.', hold: 'R', style: 'lick', n: 3, then: true, react: 'freeze', bm: [[0, -6, 3.2]],
      svg: '<rect x="-0.8" y="3.6" width="1.6" height="5" rx="0.8" fill="#f0c890"/><rect x="-3.4" y="-6" width="6.8" height="10" rx="3.4" fill="#7cc8ff"/><rect x="-3.4" y="-1" width="6.8" height="5" rx="0" fill="#ff8fc8"/><rect x="-3.4" y="-6" width="6.8" height="10" rx="3.4" fill="none" stroke="#ffffff" stroke-width="0.4"/>' },
  };
  const meal = (key, f) => { const t = TL(), H = HOLD[f.hold];
    t.e('food').to(320, o(H.chest, { wide: 0.5, ly: 0.6, pitch: -0.25, sq: 0.06, earL: -6, earR: -6 }), 'o').to(300, { wide: 0, smile: 0.7, hap: 0.6, sq: 0, earL: 0, earR: 0 }, 'io').wait(200);
    if (f.pre) f.pre(t, H); STYLE[f.style](t, H, f); REACT[f.react](t); t.rest(450);
    return t.done({ prop: foodProp(f, key) }); };
  Object.keys(FOODS).forEach(k => { ST['eat_' + k] = meal(k, FOODS[k]); });
  R.FOODHOLD = {}; Object.keys(FOODS).forEach(k => { R.FOODHOLD['eat_' + k] = FOODS[k].hold; });

  // ---------- bathing: 10 kinds (the game's tub is drawn separately) ----------
  const toolProp = (svg, opt) => (I, t) => { const c = I.ctr, W = I.W; if (c.toolgone || !W.pawR) return ''; const P = opt.hold === 'two' ? [(W.pawL[0] + W.pawR[0]) / 2, (W.pawL[1] + W.pawR[1]) / 2 - 3] : W[opt.hold === 'L' ? 'pawL' : 'pawR'];
    const sq = opt.squish && I.ctT.squeak ? 1 - 0.3 * Math.max(0, 1 - (performance.now() - I.ctT.squeak) / 260) : 1;
    return '<g transform="translate(' + r2(P[0] + (opt.dx || 0)) + ' ' + r2(P[1] + (opt.dy || 0)) + ') rotate(' + (opt.rot || 0) + ') scale(' + r2(SM(t / 220)) + ' ' + r2(SM(t / 220) * sq) + ')">' + (typeof svg === 'function' ? svg(I, t) : svg) + '</g>'; };
  const SPONGE = '<rect x="-4" y="-3" width="8" height="6" rx="2" fill="#ffd84a" stroke="#e8b52a" stroke-width="0.5"/><circle cx="-1.6" cy="-0.8" r="0.6" fill="#e8b52a"/><circle cx="1.4" cy="0.9" r="0.5" fill="#e8b52a"/><circle cx="2" cy="-1.4" r="0.4" fill="#e8b52a"/><circle cx="-2.6" cy="-3" r="1.2" fill="#ffffff"/><circle cx="-0.8" cy="-3.4" r="1" fill="#ffffff"/>';
  const BRUSH = '<rect x="-1" y="-14" width="2" height="13" rx="1" fill="#c88a5a"/><rect x="-3.2" y="-17.5" width="6.4" height="4" rx="1.6" fill="#7cc8ff"/><path d="M-2.6 -17.5 L-2.6 -19.4 M-1 -17.5 L-1 -19.6 M0.6 -17.5 L0.6 -19.6 M2.2 -17.5 L2.2 -19.4" stroke="#ffffff" stroke-width="0.7"/>';
  const DUCK = '<ellipse cx="0" cy="1" rx="5" ry="3.6" fill="#ffd23a"/><path d="M-4.6 0 Q-6.4 -1.8 -5 -3 Q-4.2 -1.2 -3 -1Z" fill="#ffd23a"/><circle cx="2.4" cy="-2.6" r="2.8" fill="#ffd23a"/><path d="M4.8 -2.6 L7.4 -2 L4.8 -1.2Z" fill="#ff9a3a"/><circle cx="3.2" cy="-3.2" r="0.6" fill="#2a1a30"/><path d="M-1.6 0.4 Q0 2 1.6 0.4" stroke="#f0b52a" stroke-width="0.6" fill="none"/>';
  const WAND = '<path d="M0 0 L0 9" stroke="#ff5cc6" stroke-width="1" stroke-linecap="round"/><circle cx="0" cy="-2.4" r="2.6" fill="rgba(220,245,255,0.45)" stroke="#ff5cc6" stroke-width="0.9"/>';
  const FOAM = [[-12, 4, 5], [-4, -1, 6], [5, 0, 5.5], [13, 5, 4.5], [0, 6, 5], [-8, 8, 4], [9, 9, 4], [-15, 10, 3.4], [16, 11, 3.2]];
  const foamFx = (t0, t1) => (I, t) => { if (t < t0) return ''; const n = Math.min(FOAM.length, Math.floor((t - t0) / 260) + 1), fade = 1 - SM((t - t1) / 500); if (fade <= 0) return ''; const [x, y] = I.W.head || [50, 17]; let h = '<g opacity="' + r2(fade) + '">';
    for (let i = 0; i < n; i++) { const f = FOAM[i], g = SM((t - t0 - i * 260) / 300), w = Math.sin(t / 300 + i) * 0.4; h += '<circle cx="' + r2(x + f[0]) + '" cy="' + r2(y + f[1] - 2) + '" r="' + r2(f[2] * g + w) + '" fill="#ffffff" stroke="#d6f2fc" stroke-width="0.6"/>'; } return h + '</g>'; };
  const B = {};
  B.belly = ['Scrub the belly', 'Sponge circles on her tummy, bubbles.', (() => { const t = TL(); t.to(350, o(hand(1, 9, 0), { pitch: -0.4, ly: 0.7, smile: 0.5 }), 'io');
    const a = t.t; t.em(2600, 200, 'bubble', 'belly', 1).osc(2600, 6, { hRx: -13, hRy: 3, lean: 0.8, htilt: 2 }, { hRx: -6, hRy: -3, lean: -0.8, htilt: -2 }, 's'); const b = t.t; t.at(a).osc(2600, 3, { sq: 0.04, hap: 0.7 }, { sq: 0, hap: 0.3 }, 's').at(b);
    t.to(300, o(both(9, 0), { pitch: -0.1, ly: 0.2 }), 'io').osc(900, 3, { sq: 0.06, hap: 1, smile: 1, open: 0.3 }, { sq: 0, open: 0.1 }).e('toolgone').rest(450); return t.done({ prop: toolProp(SPONGE, { dy: -1 }) }); })()];
  B.shampoo = ['Shampoo', 'Rubs her head with both paws, foam piles up.', (() => { const t = TL(); t.to(450, o(both(2, -31), { armL: 25, armR: 25, close: 1, smile: 0.6, pitch: -0.15, earL: 10, earR: 10 }), 'io');
    const a = t.t; t.em(3200, 260, 'bubble', 'head', 1).osc(3200, 7, { hLy: -35, hRy: -28, htilt: 3, sq: 0.03 }, { hLy: -28, hRy: -35, htilt: -3, sq: 0 }, 's'); const b = t.t; t.at(a).osc(3200, 4, { open: 0.15, wag: 12 }, { open: 0, wag: -12 }, 's').at(b);
    t.to(400, { hLx: 0, hLy: 0, hRx: 0, hRy: 0, armL: 0, armR: 0, earL: 0, earR: 0, wag: 0 }, 'io').osc(700, 3, { turn: 0.4, htilt: -5 }, { turn: -0.4, htilt: 5 }, 'io').e('emit', 'drop', 'head', 6).to(300, { close: 0, turn: 0, htilt: 0, hap: 1, smile: 1 }).rest(450);
    return t.done({ fx: foamFx(500, b + 300) }); })()];
  B.face = ['Wash the face', 'Paws rub her cheeks, then splash and blink.', (() => { const t = TL(); t.to(350, o(hand(-1, 3, -17), hand(1, 3, -17), { sqz: 0.7, mw: 0.6, open: 0.08, puff: 0.2 }), 'io');
    t.em(2000, 300, 'bubble', 'nose', 1).osc(2000, 5, { hLx: 6, hLy: -20, hRx: -2, hRy: -15, htilt: 3 }, { hLx: 2, hLy: -15, hRx: -6, hRy: -20, htilt: -3 }, 's');
    t.to(160, o(hand(-1, 7, -25), hand(1, 7, -25), { sq: 0.06 }), 'o').e('emit', 'splash', 'nose').to(300, { hLx: 0, hLy: 0, hRx: 0, hRy: 0, sq: 0 }, 'io')
     .to(200, { sqz: 0, mw: 1, open: 0, puff: 0 }).e('blink2').osc(600, 3, { turn: 0.35, htilt: -4 }, { turn: -0.35, htilt: 4 }, 'io').e('emit', 'drop', 'eyeL', 3).e('emit', 'drop', 'eyeR', 3).to(300, { turn: 0, htilt: 0, hap: 1, smile: 1 }).rest(450); return t.done(); })()];
  B.back = ['Scrub the back', 'Reaches behind with a brush, twisting.', (() => { const t = TL(); t.to(500, o(hand(1, -10, -8, -10.5), { armR: 150, spin: -18, lx: 0.9, turn: 0.45, tongue: 0.5, footL: 2 }), 'io');
    const a = t.t; t.em(2800, 240, 'bubble', 'sideR', 1).osc(2800, 6, { armR: 135, spin: -24, sq: 0.03 }, { armR: 168, spin: -12, sq: -0.02 }, 's'); const b = t.t; t.at(a).osc(2800, 4, { footL: 0, footR: 2 }, { footL: 2, footR: 0 }, 's').at(b);
    t.to(450, { hRx: 0, hRy: 0, hRz: 0, armR: 0, spin: 0, lx: 0, turn: 0, tongue: 0, footL: 0, footR: 0, sq: 0, hap: 1, smile: 0.8 }, 'io').e('toolgone').rest(450); return t.done({ propZ: 0.5, prop: toolProp(BRUSH, { dy: 1, rot: 25 }) }); })()];
  B.splash = ['Splash around', 'Slaps the water with both paws, laughing.', (() => { const t = TL(); t.to(250, { hap: 1, smile: 1, open: 0.4 });
    for (let i = 0; i < 6; i++) { const two = i % 3 !== 1; t.to(200, { armL: two || i % 2 ? 70 : 10, armR: two || !(i % 2) ? 70 : 10, sq: -0.05, lift: 2, earL: -6, earR: -6 }, 'io').to(110, { armL: -12, armR: -12, sq: 0.12, lift: 0, earL: 8, earR: 8 }, 'o').e('emit', 'splash', 'pawL').e('emit', 'splash', 'pawR').wait(120); }
    t.to(300, { armL: 0, armR: 0, sq: 0, earL: 0, earR: 0, open: 0.2 }, 'io').osc(600, 2, { sq: 0.05 }, { sq: 0 }).rest(450); return t.done(); })()];
  B.duck = ['Rubber duck', 'Squeezes it, it squeaks, it swims, she kisses it.', (() => { const t = TL(); t.to(350, o(both(7, -6), { ly: 0.5, pitch: -0.2, smile: 0.6 }), 'io').wait(200)
    .to(120, o(both(10, -6), { sq: 0.05 }), 'o').e('squeak').to(150, { wide: 1, sq: -0.03, earL: -8, earR: -8 }, 'o').to(300, o(both(7, -6), { wide: 0, earL: 0, earR: 0, hap: 1, smile: 1, open: 0.3 }), 'io').osc(400, 2, { sq: 0.05 }, { sq: 0 })
    .to(120, o(both(10, -6)), 'o').e('squeak').to(200, o(both(7, -6)), 'io')
    .osc(1600, 2, { hLx: 13, hRx: -1, lx: 0.6, turn: 0.2 }, { hLx: 1, hRx: -13, lx: -0.6, turn: -0.2 }, 's')
    .to(400, o(both(10, -12), { lx: 0, turn: 0, pitch: -0.15, mw: 0.4, blush: 1, hap: 0.6, open: 0 }), 'io').e('emit', 'heart', 'mouth', 2).wait(400).to(350, o(both(7, -6), { mw: 1 }), 'io').e('toolgone').rest(450);
    return t.done({ prop: toolProp(DUCK, { hold: 'two', squish: true }) }); })()];
  B.bubbles = ['Blow bubbles', 'Puffs her cheeks, blows big bubbles, pops one.', (() => { const t = TL(); t.to(350, o(hand(1, 6, -8)), 'io');
    for (let i = 0; i < 3; i++) t.to(300, o(hand(1, 12, -13), { puff: 1, pitch: 0, lx: 0, ly: 0 }), 'io').to(450, { puff: 0, mw: 0.35, open: 0.18, sq: 0.04 }, 'io').e('emit', 'bigbubble', 'pawR').e('emit', 'bubble', 'pawR', 2).to(500, { mw: 1, open: 0, sq: 0, lx: 0.7, ly: -0.7, pitch: 0.3, hap: 0.6, smile: 0.8 }, 'io');
    t.to(260, { armL: 120, hLy: -6 }, 'o').e('emit', 'spark', [70, 26], 5).to(300, { armL: 0, hLy: 0, hap: 1, open: 0.35 }, 'io').e('toolgone').rest(450); return t.done({ prop: toolProp(WAND, { dx: -1, dy: -4 }) }); })()];
  B.shake = ['Shake dry', 'Wet-dog shake from head to tail, then fluffy.', (() => { const t = TL(); t.to(400, { sq: 0.1, close: 0.6, earL: 6, earR: 6 }, 'io').em(1300, 70, 'splash', 'body', 2);
    t.osc(1300, 9, { spin: 26, htilt: -8, sqz: 1, open: 0.2 }, { spin: -26, htilt: 8 }, 'io').to(250, { spin: 0, htilt: 0, sqz: 0, open: 0, close: 0, sq: -0.06, wide: 0.6 }, 'io')
     .osc(1200, 2, { htilt: 5, lx: 0.6, ly: -0.3 }, { htilt: -5, lx: -0.6, ly: 0.3 }, 's').to(300, { wide: 0, lx: 0, ly: 0, htilt: 0, hap: 1, smile: 1 }).rest(450); return t.done(); })()];
  B.ears = ['Clean the ears', 'Tilts her head, rubs each ear, ear flicks.', (() => { const t = TL();
    [-1, 1].forEach(s => { const k = S(s); t.to(400, o(hand(s, -6, -26), { [k.arm]: 35, htilt: s * 12, lean: s * 1.5, [k.wink]: 1, tongue: 0.3 }), 'io').osc(1400, 4, { [k.hy]: -30, [k.ear]: 10 }, { [k.hy]: -24, [k.ear]: -6 }, 's')
      .to(300, { [k.hx]: 0, [k.hy]: 0, [k.arm]: 0, htilt: 0, lean: 0, [k.wink]: 0, [k.ear]: 0, tongue: 0 }, 'io'); });
    t.osc(700, 3, { turn: 0.35, htilt: -5 }, { turn: -0.35, htilt: 5 }, 'io').e('emit', 'drop', 'earL', 3).e('emit', 'drop', 'earR', 3).to(250, { turn: 0, htilt: 0, hap: 1, smile: 0.8 }).rest(450); return t.done(); })()];
  B.soak = ['Relax and soak', 'Leans back, eyes closed, slow happy breaths.', (() => { const t = TL(); t.to(700, { pitch: 0.35, lean: -1.2, close: 1, smile: 0.6, armL: 35, armR: 35, sq: 0.05, earL: 6, earR: 6 }, 'io').em(6000, 420, 'steam', 'body', 1);
    const a = t.t; t.osc(4800, 2, { sq: -0.03, pitch: 0.42 }, { sq: 0.06, pitch: 0.32 }, 's'); const b = t.t; t.at(a + 1200).osc(1600, 4, { footL: 1.5, footR: 0 }, { footL: 0, footR: 1.5 }, 's').at(a + 3000).to(400, { open: 0.3, mw: 0.7 }, 'io').to(600, { open: 0, mw: 1 }, 'io').at(b);
    t.to(500, { pitch: 0, lean: 0, close: 0, armL: 0, armR: 0, sq: 0, earL: 0, earR: 0, hap: 0.8 }, 'io').e('blink').rest(450); return t.done(); })()];
  R.PRE.steamBig = { n: 1, sp: 16, vy: -9, g: -3, life: 1700, r: [3, 5.5], col: ['#ffffff'], kind: 'puff' };
  const fxs = (...f) => (I, t) => f.filter(Boolean).map(g => g(I, t)).join('');
  const SOAP = [['head', -13, 7, 4.2], ['body', -17, -2, 4.4], ['belly', 4, 1, 3.6], ['head', 6, 1, 4.6], ['sideR', 1, -3, 3.8], ['body', 12, 6, 3.8], ['earL', 1, 3, 2.6], ['sideL', -1, 2, 3.6], ['head', -4, 2, 4], ['body', -8, 7, 3.4],
    ['earR', -1, 3, 2.6], ['body', 18, -4, 3.6], ['head', 14, 8, 3.6], ['belly', -6, 3, 3.2], ['body', 0, -6, 3], ['sideL', 2, -6, 3], ['sideR', -2, 4, 3.2], ['head', 0, 8, 3], ['footL', 0, -2, 2.6], ['footR', 0, -2, 2.6]];
  const soapFx = (n, a, f, r, rd) => (I, t) => { const W = I.W; if (!W.body) return ''; let h = ''; n = Math.min(n, SOAP.length);
    for (let i = 0; i < n; i++) { const [w, dx, dy, rr] = SOAP[i], p = W[w]; if (!p) continue; const g = SM((t - a - i * (f - a) / n) / 260) * (1 - SM((t - r - (i % 5) * 60) / (rd || 450))); if (g <= 0.01) continue;
      const x = p[0] + dx, y = p[1] + dy, wb = Math.sin(t / 340 + i * 1.7) * 0.35, R0 = rr * (0.4 + 0.6 * g) + wb;
      h += '<g opacity="' + r2(g) + '"><circle cx="' + r2(x) + '" cy="' + r2(y) + '" r="' + r2(R0) + '" fill="#ffffff" stroke="#cfeefc" stroke-width="0.55"/><circle cx="' + r2(x + R0 * 0.85) + '" cy="' + r2(y + R0 * 0.35) + '" r="' + r2(R0 * 0.55) + '" fill="#ffffff" stroke="#cfeefc" stroke-width="0.45"/><circle cx="' + r2(x - R0 * 0.75) + '" cy="' + r2(y + R0 * 0.45) + '" r="' + r2(R0 * 0.45) + '" fill="#ffffff" stroke="#cfeefc" stroke-width="0.45"/><circle cx="' + r2(x - R0 * 0.3) + '" cy="' + r2(y - R0 * 0.35) + '" r="' + r2(R0 * 0.22) + '" fill="#e6f7ff"/></g>'; } return h; };
  const MINI = (s, fl) => '<g transform="scale(' + r2(s) + ')' + (fl ? ' scale(-1 1)' : '') + '">' + DUCK + '</g>';
  B.duck[1] = 'A whole flock of ducks bobs around her; she squeezes one, it squeaks, one hops onto her head.';
  B.duck[2].fx = (I, t) => { let h = ''; [[16, 0.62, 0], [30, 0.5, 1], [72, 0.55, 1], [86, 0.66, 0], [50, 0.45, 0]].forEach(([x0, sc, fl], i) => { const x = x0 + Math.sin(t / 900 + i * 2) * 3, y = 92 + Math.sin(t / 380 + i) * 0.8 - (i === 4 ? 4 : 0), sp = SM((t - i * 160) / 300);
      h += '<g transform="translate(' + r2(x) + ' ' + r2(y) + ') rotate(' + r2(Math.sin(t / 420 + i) * 8) + ') scale(' + r2(sp) + ')">' + MINI(sc, fl) + '</g>'; });
    const hd = I.W.head, u = SM((t - 3600) / 380), up = Math.sin(Math.PI * Math.min(1, Math.max(0, (t - 3600) / 380))) * 8; if (hd && t > 3600 && t < (I.cur ? 1e9 : 1e9)) h += '<g transform="translate(' + r2(hd[0] + 2 + (1 - u) * 26) + ' ' + r2(hd[1] - 3 - up + (1 - u) * 60) + ') rotate(' + r2(Math.sin(t / 300) * 6) + ')">' + MINI(0.6, 0) + '</g>'; return h; };
  B.duck[2].emit = (B.duck[2].emit || []).concat([[3700, 4200, 999, 'spark', 'head', 3]]);
  B.mask = ['Face mask', 'Pats on a green mask, cucumber slices on her eyes, relaxes, wipes it off fresh.', (() => { const t = TL();
    t.to(350, o(hand(-1, 3, -17), hand(1, 3, -17), { close: 0.5, smile: 0.4 }), 'io').e('mask').osc(1200, 4, { hLy: -19, hRy: -15, sq: 0.03 }, { hLy: -15, hRy: -19, sq: 0 }, 's')
     .to(400, o(hand(-1, 6, -27), hand(1, 6, -27), { close: 1 }), 'io').e('cuke').to(350, { hLx: 0, hLy: 0, hRx: 0, hRy: 0, pitch: 0.3, lean: -1, armL: 30, armR: 30, smile: 0.7, earL: 6, earR: 6 }, 'io');
    const a = t.t; t.osc(3000, 2, { sq: -0.02, pitch: 0.36 }, { sq: 0.05, pitch: 0.28 }, 's'); const b = t.t; t.at(a + 600).e('emit', 'note', 'mouth').at(a + 1800).e('emit', 'note', 'mouth').at(b);
    t.to(350, o(hand(-1, 6, -27), hand(1, 6, -27), { pitch: 0, lean: 0, armL: 0, armR: 0 }), 'io').e('cukeoff').to(300, o(hand(-1, 3, -17), hand(1, 3, -17), { close: 0.6 }), 'io')
     .osc(900, 3, { hLx: 6, hRx: -6, hLy: -19, hRy: -19 }, { hLx: 2, hRx: -2, hLy: -15, hRy: -15 }, 's').e('maskoff').to(300, { hLx: 0, hLy: 0, hRx: 0, hRy: 0, close: 0, earL: 0, earR: 0 }, 'io')
     .e('emit', 'spark', 'eyeL', 4).e('emit', 'spark', 'eyeR', 4).to(250, { hap: 1, smile: 1, blush: 0.8, sq: 0.1 }).to(220, { sq: -0.1, lift: 6 }, 'o').to(240, { lift: 0, sq: 0.15 }, 'i').to(200, { sq: 0 }).rest(450);
    return t.done({ prop: (I, tt) => { const c = I.ctT, W = I.W; if (!c.mask || !W.eyeL) return ''; const now = performance.now(), ma = SM((now - c.mask) / 900) * (c.maskoff ? 1 - SM((now - c.maskoff) / 500) : 1);
      const eL = W.eyeL, eR = W.eyeR, m = W.mouth, cx = (eL[0] + eR[0]) / 2, cy = (eL[1] + eR[1]) / 2 + 3, w = Math.max(6, eR[0] - eL[0]), ang = Math.atan2(eR[1] - eL[1], eR[0] - eL[0]) * 180 / Math.PI, id = 'mk' + I.u;
      let h = ''; if (ma > 0.01) h += '<mask id="' + id + '" maskUnits="userSpaceOnUse" x="0" y="0" width="100" height="100"><rect width="100" height="100" fill="#fff"/><ellipse cx="' + r2(eL[0]) + '" cy="' + r2(eL[1]) + '" rx="4.6" ry="4.6" fill="#000"/><ellipse cx="' + r2(eR[0]) + '" cy="' + r2(eR[1]) + '" rx="4.6" ry="4.6" fill="#000"/><ellipse cx="' + r2(m[0]) + '" cy="' + r2(m[1] + 0.5) + '" rx="3.6" ry="2.2" fill="#000"/></mask>' +
        '<g mask="url(#' + id + ')" opacity="' + r2(ma * 0.92) + '"><ellipse cx="' + r2(cx) + '" cy="' + r2(cy) + '" rx="' + r2(w * 1.12) + '" ry="' + r2(w * 0.86) + '" transform="rotate(' + r2(ang) + ' ' + r2(cx) + ' ' + r2(cy) + ')" fill="#9fd67a"/><circle cx="' + r2(cx - w * 0.6) + '" cy="' + r2(cy + 3) + '" r="1" fill="#c4eaa6"/><circle cx="' + r2(cx + w * 0.5) + '" cy="' + r2(cy - 4) + '" r="0.8" fill="#c4eaa6"/><circle cx="' + r2(cx + w * 0.2) + '" cy="' + r2(cy + 6) + '" r="0.7" fill="#c4eaa6"/></g>';
      if (c.cuke && !(c.cukeoff && now - c.cukeoff > 250)) { const k = SM((now - c.cuke) / 200) * (c.cukeoff ? 1 - SM((now - c.cukeoff) / 250) : 1); [eL, eR].forEach(e => { h += '<g transform="translate(' + r2(e[0]) + ' ' + r2(e[1]) + ') scale(' + r2(k) + ')"><circle r="5" fill="#5fae4a"/><circle r="4.2" fill="#c8ef9a"/><circle r="1.2" fill="#e8ffd0"/><path d="M0 -3.4 L0 -1.6 M0 1.6 L0 3.4 M-3.4 0 L-1.6 0 M1.6 0 L3.4 0" stroke="#a6dc78" stroke-width="0.5"/></g>'; }); }
      return h; } }); })()];
  B.sauna = ['Sauna', 'Towel on her head, steam all around, gets rosy and sweaty, fans herself, phew.', (() => { const t = TL();
    t.to(600, { sl: 1, smile: 0.6, close: 0.4, sq: 0.06, earL: 10, earR: 10, armL: 20, armR: 20, red: 0.25 }, 'io').em(7200, 160, 'steamBig', 'body', 1).em(7200, 300, 'steam', 'head', 1);
    const a = t.t; t.osc(2400, 1, { sq: 0.02, red: 0.5, close: 0.6 }, { sq: 0.08, red: 0.6, close: 0.5 }, 's'); t.at(a + 900).e('emit', 'sweat', [37, 30]).at(a + 1700).e('emit', 'sweat', [64, 32]).at(a + 2400);
    t.to(350, o(hand(1, 12, -16), { red: 0.75, tongue: 0.6, open: 0.3, close: 0.2, sl: 0.5 }), 'io').osc(1500, 6, { hRx: -16 }, { hRx: -9 }, 'io').e('emit', 'sweat', [40, 28]).e('emit', 'sweat', [61, 29])
     .to(300, { hRx: 0, hRy: 0, tongue: 0, open: 0 }, 'io').to(300, { armR: 60, sq: 0.04 }, 'io').to(150, { armR: -10 }, 'o').e('emit', 'steamBig', [70, 88], 6).e('emit', 'steamBig', [30, 88], 6).to(300, { wide: 0.6, armR: 0, red: 0.9 }, 'io')
     .wait(500).to(400, { sq: 0.12, earL: 22, earR: 22, sl: 1, close: 0.55, red: 0.95 }, 'io').to(400, o(hand(1, -4, -30), { armR: 30, wide: 0 }), 'io').to(450, { hRx: 6, hRy: -26 }, 'io').e('emit', 'sweat', [72, 30])
     .to(300, { hRx: 0, hRy: 0, armR: 0, open: 0.35, sq: -0.04 }, 'io').to(300, { open: 0, sq: 0.05 }).to(500, { red: 0.3 }).rest(500);
    return t.done({ prop: (I, tt) => { const hd = I.W.head; if (!hd) return ''; const k = SM(tt / 300); return '<g transform="translate(' + r2(hd[0]) + ' ' + r2(hd[1] + 3) + ') scale(' + r2(k) + ')"><path d="M-17 6 Q-18 -6 0 -7 Q18 -6 17 6 Q8 2 0 3 Q-8 2 -17 6Z" fill="#ffffff" stroke="#e3d4f5" stroke-width="0.6"/><path d="M-12 1 Q0 -3 12 1 M-14 4 Q0 0 14 4" stroke="#efe6fb" stroke-width="0.8" fill="none"/><path d="M14 -1 Q22 -6 19 4 Q16 5 14 3Z" fill="#ffffff" stroke="#e3d4f5" stroke-width="0.6"/></g>'; } }); })()];
  const SOAPCFG = { belly: [18, 300, 2600, -900], shampoo: [14, 300, 3000, -1500], face: [12, 200, 2200, -1600], back: [18, 300, 2800, -900], splash: [10, 200, 2000, -700], duck: [12, 200, 2600, -700], bubbles: [9, 200, 2600, -800], shake: [20, 0, 1, 400, 1100], ears: [14, 200, 2600, -1100], soak: [8, 300, 2500, -1000] };
  Object.keys(B).forEach(k => { const st = B[k][2], c = SOAPCFG[k]; if (c) { const r = c[3] < 0 ? st.dur + c[3] : c[3]; st.fx = fxs(st.fx, soapFx(c[0], c[1], c[2], r, c[4])); } ST['bath_' + k] = st; });

  // ---------- poke reactions by spot ----------
  ST.poke_head = TL().to(80, { sq: 0.26, sqz: 1, earL: 14, earR: 14, pitch: -0.3 }, 'o').to(160, { sq: -0.1, pitch: 0.1 }, 'o').to(200, { sq: 0.04 }, 'io').to(200, { sq: 0, sqz: 0, frown: 0.5, puff: 0.35, ly: -0.9, earL: 4, earR: 4 }, 'io')
    .to(350, o(hand(1, -2, -30), { armR: 25 }), 'io').osc(900, 3, { hRx: -4, htilt: 3 }, { hRx: 4, htilt: -3 }, 's').to(350, { hRx: 0, hRy: 0, armR: 0, frown: 0, puff: 0, smile: 0.4, ly: 0, htilt: 0 }, 'io').rest(350).done({ tap: [50, 24] });
  const pokeEar = s => { const k = S(s); return TL().to(70, { [k.ear]: -22, [k.wink]: 1, htilt: s * 5 }, 'o').to(130, { [k.ear]: 14 }, 'o').to(130, { [k.ear]: -10 }, 'io').to(150, { [k.ear]: 6 }, 'io').to(150, { [k.ear]: 0, [k.wink]: 0 }, 'io')
    .osc(600, 3, { turn: 0.3, htilt: -4 }, { turn: -0.3, htilt: 4 }, 'io').to(250, { turn: 0, htilt: 0, hap: 1, smile: 0.8 }, 'io').osc(500, 3, { sq: 0.05 }, { sq: 0 }).rest(350).done({ tap: [s < 0 ? 28 : 72, 16] }); };
  ST.poke_earL = pokeEar(-1); ST.poke_earR = pokeEar(1);
  ST.poke_nose = TL().to(250, { cross: 1, ly: 0.7, pitch: -0.1, wide: 0.2 }, 'io').wait(450)
    .to(300, { cross: 0, ly: 0, wide: 0, pitch: 0.35, open: 0.4, close: 0.6, sq: -0.08, earL: -6, earR: -6 }, 'io').to(150, { pitch: 0.25, open: 0.3, sq: -0.04 }).to(260, { pitch: 0.5, open: 0.55, close: 0.8, sq: -0.12 }, 'io')
    .to(90, { pitch: -0.55, open: 0.9, sqz: 1, close: 0, sq: 0.22, lean: 0.5, earL: 16, earR: 16 }, 'o').e('emit', 'sneeze', 'nose').to(260, { pitch: -0.1, open: 0.1, sq: 0, earL: 0, earR: 0, lean: 0 }, 'io')
    .to(250, { sqz: 0, open: 0 }, 'io').to(300, o(hand(1, 13, -18)), 'io').osc(450, 3, { hRx: -15 }, { hRx: -11 }).to(300, { hRx: 0, hRy: 0, hap: 0.8, smile: 0.6 }, 'io').osc(400, 2, { turn: 0.2 }, { turn: -0.2 }).rest(350).done({ tap: [50, 54] });
  const pokeEye = s => { const k = S(s); return TL().to(60, { [k.wink]: 1, pitch: 0.2, lean: -s * 2.5, htilt: -s * 5, sq: 0.06 }, 'o').to(200, { sq: 0 }, 'io')
    .to(300, o(hand(s, 6, -27)), 'io').osc(700, 3, { [k.hy]: -29, [k.hx]: s < 0 ? 4 : -4 }, { [k.hy]: -25, [k.hx]: s < 0 ? 7 : -7 }, 's')
    .to(300, { [k.hx]: 0, [k.hy]: 0, pitch: 0, lean: 0, htilt: 0 }, 'io').to(150, { [k.wink]: 0 }).e('blink2').to(300, { frown: 0.4 }).rest(400).done({ tap: [s < 0 ? 38 : 62, 47] }); };
  ST.poke_eyeL = pokeEye(-1); ST.poke_eyeR = pokeEye(1);
  const pokeCheek = s => { const k = S(s); return TL().to(90, { htilt: -s * 9, lean: -s * 2, [k.wink]: 0.8, sq: 0.05 }, 'o').to(250, { blush: 1, hap: 1, smile: 1, open: 0.3, sq: 0 }, 'io')
    .to(300, o(hand(s, 2, -18)), 'io').osc(600, 3, { sq: 0.05, htilt: -s * 7 }, { sq: 0, htilt: -s * 10 }, 's').to(400, { [k.hx]: 0, [k.hy]: 0, htilt: 0, lean: 0, [k.wink]: 0, open: 0 }, 'io').rest(500).done({ tap: [s < 0 ? 33 : 67, 58] }); };
  ST.poke_cheekL = pokeCheek(-1); ST.poke_cheekR = pokeCheek(1);
  ST.poke_belly = (() => { const t = TL().to(90, { sq: 0.14, pitch: -0.3, sqz: 0.8 }, 'o').to(250, o(both(9, 0), { hap: 1, sqz: 0, open: 0.65, smile: 1 }), 'io');
    const a = t.t; t.osc(1400, 7, { sq: 0.12, lift: 0, htilt: 4 }, { sq: 0.02, lift: 1.5, htilt: -4 }, 'io'); const b = t.t; t.at(a).osc(1400, 5, { wag: 22 }, { wag: -22 }).at(b);
    return t.to(400, { hLx: 0, hLy: 0, hRx: 0, hRy: 0, sq: 0, pitch: 0, open: 0.2, lift: 0, htilt: 0, wag: 0 }, 'io').to(300, { sq: -0.04, pitch: 0.15 }).rest(400).done({ tap: [50, 82] }); })();
  const pokeSide = s => { const k = S(s), j = S(-s), d = -s; return TL().to(90, { x: d * 3, lean: d * 4, tilt: d * 8, sq: 0.06, wide: 0.8, [k.foot]: 3, [j.arm]: 60, open: 0.3 }, 'o')
    .to(250, { x: d * 6, tilt: d * 10, lean: d * 3, lift: 2 }, 'o').to(220, { lift: 0, tilt: d * 2, sq: 0.08, [k.foot]: 0 }, 'i').to(220, { tilt: -d * 2, sq: 0, [j.arm]: 0 }, 'io')
    .to(300, { x: 0, tilt: 0, lean: 0, lx: s * 0.9, turn: s * 0.3, wide: 0, open: 0, frown: 0.4 }, 'io').to(300, o(hand(s, -3, -2)), 'io').osc(500, 2, { [k.hy]: -4 }, { [k.hy]: 0 }).rest(400).done({ tap: [s < 0 ? 30 : 70, 78] }); };
  ST.poke_sideL = pokeSide(-1); ST.poke_sideR = pokeSide(1);
  const pokeFoot = s => { const k = S(s), j = S(-s); return TL().to(80, { sq: 0.08, wide: 1, [k.foot]: 2 }, 'o').to(250, { lift: 8, sq: -0.14, armL: 40, armR: 40, earL: -10, earR: -10, open: 0.5 }, 'o').to(250, { lift: 0, sq: 0.2 }, 'i')
    .to(200, { sq: 0, armL: 10, armR: 10, open: 0.2, wide: 0.3, earL: 0, earR: 0 }, 'io').osc(1000, 4, { [k.foot]: 4, [j.foot]: 0, tilt: -s * 3, hap: 1, smile: 1 }, { [k.foot]: 0, [j.foot]: 4, tilt: s * 3 }, 'io')
    .to(250, { footL: 0, footR: 0, tilt: 0 }).rest(400).done({ tap: [s < 0 ? 38 : 62, 91] }); };
  ST.poke_footL = pokeFoot(-1); ST.poke_footR = pokeFoot(1);
  ST.poke_tail = TL().to(80, { sq: 0.1, wide: 1, curl: 0.9 }, 'o').to(240, { lift: 6, sq: -0.12, wag: 30, open: 0.4 }, 'o').to(240, { lift: 0, sq: 0.15 }, 'i').to(150, { sq: 0, open: 0 })
    .to(500, { spin: 50, turn: 0.7, lx: 1, ly: 0.4, wide: 0.3 }, 'io').osc(800, 4, { wag: 25 }, { wag: -25 }, 'io').to(250, { frown: 0.5, puff: 0.4 }).wait(300)
    .to(500, { spin: 0, turn: 0, lx: 0, ly: 0, curl: 0, wag: 0, puff: 0, frown: 0 }, 'io').rest(400).done({ tap: [86, 70] });
  ST.poke = { seq: ['poke_head', 'poke_earL', 'poke_nose', 'poke_cheekR', 'poke_eyeL', 'poke_belly', 'poke_sideL', 'poke_sideR', 'poke_footL', 'poke_tail', 'poke_earR', 'poke_cheekL', 'poke_eyeR', 'poke_footR'], k: {} };

  // ---------- sad: quiet crying and heavy sobbing ----------
  ST.cry = (() => { const t = TL().to(700, { pitch: -0.4, ly: 0.6, frown: 0.85, teary: 1, earL: 24, earR: 24, sl: 1, sq: 0.06, curl: -0.6, armL: -6, armR: -6 }, 'io');
    const a = t.t; t.osc(5600, 28, { frown: 1, open: 0.05 }, { frown: 0.75, open: 0 }, 's'); const b = t.t;
    t.at(a + 600).e('emit', 'tear', 'eyeL').at(a + 1500).e('emit', 'tear', 'eyeR').at(a + 2900).e('emit', 'tear', 'eyeL').at(a + 4000).e('emit', 'tear', 'eyeR').at(a + 4900).e('emit', 'tear', 'eyeL');
    t.at(a + 1800).to(120, { sq: 0.02, pitch: -0.25 }, 'o').to(160, { sq: 0.06, pitch: -0.4 }).to(120, { sq: 0.02, pitch: -0.27 }, 'o').to(200, { sq: 0.06, pitch: -0.4 });
    t.at(a + 3000).to(350, o(hand(1, 6, -27), { htilt: 4 }), 'io').osc(700, 2, { hRy: -29, hRx: -4 }, { hRy: -25, hRx: -7 }, 's').to(350, { hRx: 0, hRy: 0, htilt: 0 }, 'io');
    t.at(a + 4500).to(500, { sq: -0.03, pitch: -0.2 }, 'io').to(700, { sq: 0.08, pitch: -0.45 }, 'io').at(b);
    return t.rest(600).done(); })();
  ST.sob = (() => { const t = TL().to(300, { frown: 1, teary: 1, pitch: -0.2, sq: 0.05, earL: 18, earR: 18 }, 'io').osc(400, 4, { open: 0.1 }, { open: 0 }, 'l')
    .to(260, { pitch: 0.5, open: 0.85, mw: 1.25, sqz: 1, earL: 22, earR: 22, sq: -0.04 }, 'o').em(2600, 90, 'gush', 'eyeL', 1).em(2600, 90, 'gush', 'eyeR', 1);
    const a = t.t; t.osc(2600, 13, { sq: 0.12, lift: 0, x: 0.5 }, { sq: 0, lift: 1.2, x: -0.5 }, 'io'); const b = t.t; t.at(a).osc(2600, 5, { armL: 100, armR: 40, htilt: 4 }, { armL: 40, armR: 100, htilt: -4 }, 'io').at(b);
    t.to(400, { open: 0.3, mw: 0.9, pitch: 0.1, sq: -0.08, armL: 0, armR: 0, htilt: 0, x: 0, lift: 0 }, 'io').to(200, { sq: 0.02 })
     .to(300, o(hand(-1, 6, -27), hand(1, 6, -27), { pitch: 0.3, open: 0.8, mw: 1.1, sqz: 1 }), 'io').em(2000, 110, 'gush', 'eyeL', 1).em(2000, 110, 'gush', 'eyeR', 1);
    const c = t.t; t.osc(2000, 8, { hLy: -29, hRy: -25, sq: 0.1 }, { hLy: -25, hRy: -29, sq: 0 }, 's'); const d = t.t; t.at(c).osc(2000, 10, { lift: 1, x: 0.4 }, { lift: 0, x: -0.4 }, 'io').at(d);
    return t.to(400, { hLx: 0, hLy: 0, hRx: 0, hRy: 0, open: 0.1, mw: 1, sqz: 0.2, pitch: -0.2, x: 0, lift: 0 }, 'io').to(150, { sq: 0.05, pitch: -0.1 }, 'o').to(200, { sq: 0 }).to(500, { teary: 0.6, sqz: 0, frown: 0.8, earL: 20, earR: 20 }).rest(600).done(); })();

  // ---------- stinky: loops until she gets a bath ----------
  ST.stinky = (() => { const t = TL();
    t.to(450, { armR: 120, hRy: -3, turn: 0.6, pitch: -0.25, lx: 1, ly: 0.5, lean: 0.8 }, 'io').osc(600, 3, { sq: -0.03 }, { sq: 0 }, 'o')
     .to(150, { lean: -3, tilt: -4, wide: 1, tongue: 1, open: 0.3, sqz: 0.7, earL: 14, earR: 14, armR: 0, hRy: 0, turn: -0.2, lx: 0, ly: 0, pitch: 0.15 }, 'o');
    const a = t.t; t.wait(700); const b = t.t; t.at(a).osc(700, 7, { x: 0.6 }, { x: -0.6 }, 'l').at(b);
    t.to(350, o(hand(1, 12, -16), { lean: 0, tilt: 0, wide: 0, tongue: 0, open: 0, sqz: 0, frown: 0.6, puff: 0.3, earL: 8, earR: 8, pitch: 0, turn: 0 }), 'io').osc(1300, 5, { hRx: -16 }, { hRx: -9 }, 'io')
     .to(350, { hRx: 0, hRy: 0, puff: 0, frown: 0.2, blush: 1, smile: 0.35, htilt: 6 }, 'io').e('emit', 'sweat', [67, 26]).to(350, o(hand(1, -2, -30), { armR: 25 }), 'io').osc(800, 3, { hRx: -4 }, { hRx: 4 }, 's')
     .to(350, { hRx: 0, hRy: 0, armR: 0, htilt: 0, blush: 0.4 }, 'io').to(400, { armL: 120, hLy: -3, turn: -0.6, pitch: -0.25, lx: -1, ly: 0.5 }, 'io').osc(500, 2, { sq: -0.03 }, { sq: 0 }, 'o')
     .to(300, { armL: 0, hLy: 0, turn: 0, pitch: -0.15, lx: 0, ly: 0.3, earL: 22, earR: 22, sl: 1, frown: 0.8, smile: 0 }, 'io').wait(500).rest(600);
    const L = t.loop({ emit: [[0, 1e9, 280, 'stink', 'body', 1], [140, 1e9, 560, 'stink', 'head', 1], [0, 1e9, 900, 'stink', 'sideL', 1], [450, 1e9, 900, 'stink', 'sideR', 1]] });
    L.k.green = [[0, 0.75]];
    L.fx = (I, tt) => { const c = I.W.body || [50, 78]; let h = ''; for (let i = 0; i < 2; i++) { const a = tt / (520 + i * 140) + i * Math.PI, x = c[0] + Math.cos(a) * (26 - i * 4), y = c[1] - 18 + Math.sin(a * 1.3) * 12, fl = Math.sin(tt / 18 + i) * 0.6;
      h += '<g transform="translate(' + r2(x) + ' ' + r2(y) + ')"><ellipse cx="-0.8" cy="-1" rx="1.1" ry="' + r2(0.5 + fl * 0.4) + '" fill="#ffffff" opacity="0.8"/><ellipse cx="0.8" cy="-1" rx="1.1" ry="' + r2(0.5 - fl * 0.4) + '" fill="#ffffff" opacity="0.8"/><circle r="0.95" fill="#2a1a30"/></g>'; } return h; };
    return L; })();

  R.add(ST);
  const F = Object.keys(FOODS);
  R.GROUPS = [
    { name: 'Idle', where: 'Plays by itself', items: [['idle', 'Idle', 'Breathes and sways. Every few seconds she looks around, yawns or waves.'], ['idle_look', 'Look left and right', 'Turns her whole body each way, stepping with her feet.'], ['idle_yawn', 'Yawn', 'Stretches both arms up, big yawn, smacks her lips.'], ['idle_waveL', 'Wave, left paw', 'Lifts her left paw and waves with a big smile.'], ['idle_waveR', 'Wave, right paw', 'Same with the right paw.']] },
    { name: 'Dance', where: '10-second loop, repeats non-stop', items: [['dance', 'Signature dance', 'Two-step, running man, the Woah, hop-spin, Billy Bounce.']] },
    { name: 'Poke', where: 'Tap anywhere on her', items: [['poke', 'Every spot in turn', 'Plays all 14 reactions one after another.'], ['poke_head', 'Top of head', 'Bonk: squashes, eyes shut, rubs her head.'], ['poke_earL', 'Left ear', 'Ear flicks, head shakes, giggles.'], ['poke_earR', 'Right ear', 'Ear flicks, head shakes, giggles.'], ['poke_nose', 'Nose', 'Goes cross-eyed, then sneezes.'], ['poke_eyeL', 'Left eye', 'Flinches and rubs her eye.'], ['poke_eyeR', 'Right eye', 'Flinches and rubs her eye.'], ['poke_cheekL', 'Left cheek', 'Tilts away, blushes, giggles.'], ['poke_cheekR', 'Right cheek', 'Tilts away, blushes, giggles.'], ['poke_belly', 'Belly', 'Ticklish: curls up laughing.'], ['poke_sideL', 'Left side', 'Pushed off balance, hops back, rubs the spot.'], ['poke_sideR', 'Right side', 'Pushed off balance, hops back, rubs the spot.'], ['poke_footL', 'Left foot', 'Jumps, then hops foot to foot.'], ['poke_footR', 'Right foot', 'Jumps, then hops foot to foot.'], ['poke_tail', 'Tail', 'Jumps, turns to look at her tail, pouts.']] },
    { name: 'Eating', where: '20 foods', items: F.map(k => ['eat_' + k, FOODS[k].label, FOODS[k].d]) },
    { name: 'Bathing', where: '12 kinds, no tub drawn', items: Object.keys(B).map(k => ['bath_' + k, B[k][0], B[k][1]]) },
    { name: 'Feelings', where: 'Game, Crib, reveal', items: [['cry', 'Sad: quiet crying', 'Ears droop, teary eyes, lip wobbles, a few tears, wipes an eye.'], ['sob', 'Sad: heavy crying', 'Wails with tears gushing, sobs shake her body, rubs both eyes.'], ['stinky', 'Stinky', 'Needs a bath: stink lines, flies, sniffs herself, fans the smell. Loops.'], ['happy', 'Happy', 'Double bounce, arms up, tail wagging.'], ['surprised', 'Surprised', 'Jumps back wide-eyed, glances around.'], ['sleep', 'Sleepy and asleep', 'Yawns, nods off, breathes, wakes up.']] },
    { name: 'Moves', where: 'Crib and game', items: [['look', 'Look around', 'Eyes first, head follows.'], ['squish', 'Squish', 'Pressed flat, springs back.'], ['spin', 'Spin around', 'Full 360° turn.'], ['hop', 'Hop', 'Crouch, jump, squash landing.']] },
  ];
})();
