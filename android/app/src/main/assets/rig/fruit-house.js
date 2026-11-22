// Squad House moves for the 11 new Fruit Patch creatures (Nov 10): sit / lounge fidgets, bedtime, water, play + kitchen, the [B] list, the batch-7
// extras, walks and stand fidgets - the same builders the house-*-c.js tables use (as snack2-house.js does for the new snacks), with each fruit's own parts
// (fruit-3d.js channels: lf leaves, stw stem / crown twirl, crf crown flare, jig Razzy's beads, pol Plummy's bloom polished off, cv Nana's curve, fz Coco's hair,
// rl Blueby's + Coco's roll). Perry and Coco have NO LEGS (user, Nov 10): no leg-swinging on seats or swings, Perry rocks along, Coco rolls like Blueby.
// Plummy (a plum, replaced Grapey Nov 10 - user: 'please change the character') is a little ballet dancer: he prances on tiptoe, pirouettes, polishes his bloom.
// Loaded after house-idle-c.js. The 9 older fruits already have their house moves in the house-*-c.js tables.
(function () {
  const K = ['nana', 'bing', 'plummy', 'clemmy', 'appy', 'blueby', 'coco', 'perry', 'grana', 'mangie', 'razzy'];
  (window.HouseCreatures = window.HouseCreatures || []).push(function (H) {
    const { build, bedBuild, waterBuild, playBuild, bBuild, o } = H;
    const sp = (t, v, d, hold) => { const b = {}; Object.keys(v).forEach(k => b[k] = t.B[k] != null ? t.B[k] : 0); t.to((d || 700) * 0.4, v, 'o').wait(hold || 300).to((d || 700) * 0.6, b, 'io'); return t; };
    const bk = (t, d) => t.back(d || 420);
    const hop = { dn: 'hop', up: 'hop' }, RL = { armL: 12, armR: 12, hLx: 3, hRx: -3, hLy: 3, hRy: 3 };
    const mk = (key, base, P) => build(key, o(base, P, { pose: o(base.pose || {}, P.pose || {}), lpose: o(base.lpose || {}, RL, P.lpose || {}) }));
    // ---------- own signature beats (also used for bed / water / play) ----------
    const SIG = {
      nana: t => { t.osc(1200, 3, { cv: 0.6 }, { cv: -0.4 }, 'io').to(200, { cv: 0 }); return bk(t); },
      bing: t => { t.to(700, { stw: 1, lf: 1 }, 'io').to(1, { stw: -1 }, 'l').to(500, { stw: 0, lf: 0 }, 'io'); return bk(t); },
      plummy: t => { t.to(700, { stw: 1, lf: 1 }, 'io').to(1, { stw: -1 }, 'l').to(500, { stw: 0, lf: 0 }, 'io').to(300, { pol: 1 }, 'io').fx('spark', 'head', 2).to(1000, { pol: 0 }, 'io'); return bk(t); },
      clemmy: t => { t.to(800, { stw: 1, lf: 1 }, 'io').to(1, { stw: -1 }, 'l').to(400, { stw: 0, lf: 0 }, 'io').fx('zest', 'head', 3); return bk(t); },
      appy: t => { t.to(200, { lf: 1 }, 'o').to(300, { lf: 0 }, 'io').fx('spark', 'head', 2); return bk(t); },
      blueby: t => { t.osc(1200, 2, { rl: 16, x: (t.B.x || 0) + 2 }, { rl: -16, x: (t.B.x || 0) - 2 }, 'io').to(300, { rl: 0, x: t.B.x || 0 }, 'io'); return bk(t); },
      coco: t => { t.to(150, { fz: 0.9 }, 'o').fx('knock', 'head', 1).to(500, { fz: 0 }, 'io'); return bk(t); },
      perry: t => { t.to(300, { tilt: (t.B.tilt || 0) + 8 }, 'o').to(300, { tilt: (t.B.tilt || 0) - 5 }, 'io').to(300, { tilt: (t.B.tilt || 0) + 2 }, 'io').to(300, { tilt: t.B.tilt || 0 }, 'io'); return bk(t); },
      grana: t => { t.to(900, { stw: 1, crf: 0.6 }, 'io').to(1, { stw: -1 }, 'l').to(400, { stw: 0, crf: 0 }, 'io').fx('arils', 'head', 3); return bk(t); },
      mangie: t => sp(t, { lf: 1, close: 0.6, blush: 0.6, smile: 1 }, 1200, 800),
      razzy: t => { t.to(200, { jig: 1.3 }, 'o').fx('spark', 'head', 2).to(700, { jig: 0 }, 'io'); return bk(t); },
    };
    const SLEEPY = {
      nana: t => sp(t, { cv: 0.8, close: 1 }, 1800, 1600), bing: t => sp(t, { lf: 0.4, close: 1 }, 1600, 1400), plummy: t => sp(t, { lf: 0.4, close: 1 }, 1600, 1400),
      clemmy: t => sp(t, { lf: 0.4, close: 0.9 }, 1400, 1200), appy: t => sp(t, { lf: 0.3, close: 1 }, 1600, 1400), blueby: t => sp(t, { rl: 12, close: 1 }, 1800, 1600),
      coco: t => sp(t, { fz: 0.3, close: 1 }, 1600, 1600), perry: t => sp(t, { tilt: 6, close: 1 }, 1800, 1600), grana: t => sp(t, { crf: -0.3, close: 0.9 }, 1600, 1400),
      mangie: t => sp(t, { lf: 0.5, close: 1, blush: 0.4 }, 1600, 1400), razzy: t => sp(t, { jig: 0.3, close: 1 }, 1600, 1400),
    };
    // ---------- sit / lounge ----------
    mk('nana', hop, { f: ['look', SIG.nana, 'swing', 'hum'], lf: ['sigh', SLEEPY.nana, 'doze', 'stretch'] });
    mk('bing', hop, { f: ['look', SIG.bing, 'swing', 'kick'], lf: ['sigh', 'doze', SLEEPY.bing, 'belly'] });
    const NOLEG = { perry: 1, coco: 1 };
    mk('plummy', hop, { f: ['look', SIG.plummy, 'swing', 'kick'], lf: ['sigh', 'doze', SLEEPY.plummy, 'stretch'] });
    mk('clemmy', hop, { f: ['look', SIG.clemmy, 'kick', 'swing'], lf: ['sigh', 'doze', SLEEPY.clemmy, 'stretch'] });
    mk('appy', hop, { f: ['look', SIG.appy, 'swing', 'hum'], lf: ['sigh', 'doze', SLEEPY.appy, 'stretch'] });
    mk('blueby', hop, { f: ['look', SIG.blueby, 'swing', 'giggle'], lf: ['sigh', 'doze', SLEEPY.blueby, 'belly'] });
    mk('coco', hop, { f: ['look', SIG.coco, 'pat', t => { t.to(500, { rl: 18, x: (t.B.x || 0) + 2 }, 'io').to(500, { rl: -10, x: (t.B.x || 0) - 1 }, 'io').to(400, { rl: 0, x: t.B.x || 0 }, 'io'); return bk(t); }], lf: ['sigh', SLEEPY.coco, 'doze', 'belly'] });
    mk('perry', hop, { f: ['look', SIG.perry, 'hum', 'pat'], lf: ['sigh', 'doze', SLEEPY.perry, 'belly'] });
    mk('grana', hop, { f: ['look', SIG.grana, 'swing', 'hum'], lf: ['sigh', 'doze', SLEEPY.grana, 'stretch'] });
    mk('mangie', hop, { f: ['look', SIG.mangie, 'swing', 'hum'], lf: ['sigh', SLEEPY.mangie, 'doze', 'stretch'] });
    mk('razzy', hop, { f: ['look', SIG.razzy, 'swing', 'giggle'], lf: ['sigh', 'doze', SLEEPY.razzy, 'belly'] });
    // ---------- bedtime (dr = dream icon) ----------
    const DR = { nana: 'sun', bing: 'cherry', plummy: 'star', clemmy: 'sun', appy: 'apple', blueby: 'berry', coco: 'shell', perry: 'leaf', grana: 'crown', mangie: 'sun', razzy: 'star' };
    const WK = { nana: { cv: -0.8 }, bing: { stw: 0.6, lf: 1 }, plummy: { lf: 1, stw: 0.4 }, clemmy: { lf: 1 }, appy: { lf: 1 }, blueby: { crf: 0.8 }, coco: { fz: 1 }, perry: { lf: 1 }, grana: { crf: 1 }, mangie: { lf: 1 }, razzy: { jig: 1 } };
    K.forEach(k => bedBuild(k, { dr: DR[k], wk: WK[k], s: SLEEPY[k] }));
    // ---------- water (sw = swim style, k = shake extras) ----------
    const SW = { nana: 'float', bing: 'bob', plummy: 'bob', clemmy: 'bob', appy: 'bob', blueby: 'bob', coco: 'float', perry: 'bob', grana: 'bob', mangie: 'float', razzy: 'bob' };
    K.forEach(k => waterBuild(k, { sw: SW[k], k: { a: WK[k], b: {}, f: WK[k] }, s: SIG[k] }));
    // ---------- play + kitchen (sn = favourite snack icon from the fridge; round fruits grip the swing ropes low) ----------
    const SN = { nana: 'honey', bing: 'cherry', plummy: 'candy', clemmy: 'drop', appy: 'apple', blueby: 'berry', coco: 'cup', perry: 'honey', grana: 'cake', mangie: 'drop', razzy: 'candy' };
    const CHEER = { nana: { cheer: { cv: -0.8 } }, bing: { cheer: { lf: 1, stw: 0.6 } }, plummy: { cheer: { lf: 1, stw: 0.6 }, cheerFx: ['pljuice', 'head'] }, clemmy: { cheer: { lf: 1 }, cheerFx: ['zest', 'head'] },
      appy: { cheer: { lf: 1 }, cheerFx: ['spark', 'head'] }, blueby: { cheer: { crf: 1 } }, coco: { cheer: { fz: 1 }, cheerFx: ['knock', 'head'] }, perry: { cheer: { lf: 1 } },
      grana: { cheer: { crf: 1 }, cheerFx: ['arils', 'head'] }, mangie: { cheer: { lf: 1 }, cheerFx: ['mjuice', 'head'] }, razzy: { cheer: { jig: 1.3 }, cheerFx: ['spark', 'head'] } };
    K.forEach(k => playBuild(k, o(CHEER[k], { sn: SN[k], p: SIG[k], sp: { armL: 42, armR: 42, hLy: -7, hRy: -7, hLx: 1, hRx: -1 } }, NOLEG[k] ? { swingOrd: ['wheee', 'peek', 'sig', 'breeze', 'onehand', 'higher', 'giggle'] } : {})));
    // ---------- [B] list (fc = what she fishes up, tk = trampoline trick, tb = toothbrush colour) ----------
    const FC = { nana: 'leaf', bing: 'cherry', plummy: 'star', clemmy: 'leaf', appy: 'apple', blueby: 'pearl', coco: 'shell', perry: 'leaf', grana: 'crown', mangie: 'flower', razzy: 'star' }, TBC = ['#5fb8e8', '#7cc35a', '#ff8fa8', '#ffcc3a', '#b98ae8', '#ff8a4a'];
    K.forEach((k, i) => bBuild(k, o(CHEER[k], { fc: FC[k], tk: o(WK[k]), tb: TBC[i % TBC.length], sn: SN[k] })));
    // ---------- batch-7 extras (ks = how she kicks a ball, prop colours) ----------
    if (H.cBuild) K.forEach(k => H.cBuild(k, { ks: k === 'blueby' || NOLEG[k] ? 'body' : 'foot', pc: '#7cc35a', hc: '#7cc35a', mc: '#3b3b4a' }));
    window.HouseWalkRUN = Object.assign(window.HouseWalkRUN || {}, { plummy: { lf: 0.6 }, razzy: { jig: 0.6 }, bing: { lf: 0.6 }, clemmy: { lf: 0.6 }, nana: { cv: 0.3 } });
  });
  // ---------- walks ----------
  const walks = W => { const d = (k, P) => W.def(k, P);
    d('nana', { g: 'waddle', a: 0.85, x: { cv: [0.35, 1, 0, 0] } }); d('bing', { g: 'bounce', a: 0.9, x: { lf: [0.5, 2, 0, 1] } }); d('plummy', { g: 'prance', a: 0.85, x: { lf: [0.5, 2, 0, 1] } });
    d('clemmy', { g: 'bounce', a: 0.95, x: { lf: [0.4, 2, 0, 1] } }); d('appy', { g: 'shuffle', a: 0.85, x: { lf: [0.3, 1, 0, 0] } }); d('blueby', { g: 'eggroll', a: 0.8 });
    d('coco', { g: 'eggroll', a: 0.8 }); d('perry', { g: 'roll', a: 0.9, x: { lf: [0.3, 1, 0, 0] } }); d('grana', { g: 'prance', a: 0.75 });
    d('mangie', { g: 'prance', a: 0.9, x: { lf: [0.4, 1, 0, 0] } }); d('razzy', { g: 'bounce', a: 0.9, x: { jig: [0.6, 2, 0, 1] } });
    // Blueby and Coco ROLL from place to place like Sunny (the same roll: rl follows the ground she covers, clockwise walking right, slower toward / away from you;
    // she rocks back upright on the nearest side when she stops)
    W.G.eggroll = W.G.eggroll || { r: 0.9, dl: 0, f(p, A, o) { o.armL = 24 + 7 * A * Math.sin(p); o.armR = 24 - 7 * A * Math.sin(p); o.sq = 0.02 * A * Math.sin(2 * p); } };
    if (!W.__frRoll) { W.__frRoll = 1; const st0 = W.step; W.step = function (key, st, E, w, dt, spd, spin) { const r = st0.apply(this, arguments); if (key !== 'blueby' && key !== 'coco') return r;
        const dir = Math.sin((spin || 0) * Math.PI / 180), mv = (spd || 0) > 0 && w > 0.3; st.ra = st.ra || 0; st.rv = st.rv || 0;
        if (mv) { const tv = 300 * spd * (st.run ? 1.6 : 1) * (Math.abs(dir) < 0.3 ? (dir < 0 ? -0.3 : 0.3) : dir); st.rv += (tv - st.rv) * Math.min(1, dt * 6); st.ra += st.rv * dt; }
        else { const tg = Math.round(st.ra / 360) * 360; st.rv += ((tg - st.ra) * 60 - st.rv * 7) * Math.min(dt, 0.05); st.ra += st.rv * Math.min(dt, 0.05); if (Math.abs(tg - st.ra) < 0.3 && Math.abs(st.rv) < 2) { st.ra = 0; st.rv = 0; } }
        E.rl = (E.rl || 0) + ((st.ra % 360) + 540) % 360 - 180; return r; }; } };
  if (window.HouseWalk) walks(window.HouseWalk); else (window.HouseWalkC = window.HouseWalkC || []).push(walks);
  // ---------- stand fidgets ----------
  (window.HouseIdleC = window.HouseIdleC || []).push(function (W) {
    const sp = W.sp, d = (k, L) => W.build(k, L);
    d('nana', [t => { t.osc(1400, 3, { cv: 0.6, x: 1 }, { cv: -0.4, x: -1 }, 'io').to(300, { cv: 0, x: 0 }, 'io'); }, t => sp(t, { cv: -0.9, lift: 2, armL: 150, armR: 150 }, 1400, 500), 'hum']);
    d('bing', [t => { t.to(700, { stw: 1, lf: 1 }, 'io').to(1, { stw: -1 }, 'l').to(500, { stw: 0, lf: 0 }, 'io'); }, 'bounce', 'giggle']);
    d('plummy', [t => { t.to(260, { lift: 1.5, sq: -0.04, armL: 150, armR: 150 }, 'io').to(800, { spin: 360, lf: 1 }, 'io').to(1, { spin: 0 }, 'l').to(260, { lift: 0, sq: 0, armL: 0, armR: 0, lf: 0 }, 'io'); },
      t => { t.to(320, { pol: 1 }, 'io').fx('spark', 'head', 2).wait(400).to(1200, { pol: 0 }, 'io'); }, 'curtsy']);
    d('clemmy', [t => { t.to(800, { stw: 1, lf: 1 }, 'io').to(1, { stw: -1 }, 'l').to(400, { stw: 0, lf: 0 }, 'io').fx('zest', 'head', 3); }, ['twirl', 1], 'bounce']);
    d('appy', [t => { t.to(200, { lf: 1 }, 'o').to(300, { lf: 0 }, 'io').fx('spark', 'head', 2); }, 'clap', 'hum']);
    d('blueby', [t => { t.osc(1400, 3, { rl: 16, x: 3 }, { rl: -16, x: -3 }, 'io').to(300, { rl: 0, x: 0 }, 'io'); }, t => { t.to(600, { stw: 1, crf: 0.6 }, 'io').to(1, { stw: -1 }, 'l').to(400, { stw: 0, crf: 0 }, 'io'); }, 'curtsy']);
    d('coco', [t => { t.to(150, { fz: 0.9 }, 'o').fx('knock', 'head', 1).to(500, { fz: 0 }, 'io'); }, t => { t.to(700, { rl: 360, x: 6 }, 'io').to(1, { rl: 0 }, 'l').to(700, { rl: -360, x: 0 }, 'io').to(1, { rl: 0 }, 'l'); }, 'nod']);
    d('perry', [t => { t.to(400, { tilt: 10 }, 'o').to(380, { tilt: -6 }, 'io').to(360, { tilt: 3 }, 'io').to(340, { tilt: 0 }, 'io'); }, t => { t.osc(1600, 4, { tilt: 6, turn: 0.12 }, { tilt: -6, turn: -0.12 }, 'io').to(300, { tilt: 0, turn: 0 }, 'io'); }, 'hum']);
    d('grana', [t => { t.to(900, { stw: 1, crf: 0.6 }, 'io').to(1, { stw: -1 }, 'l').to(400, { stw: 0, crf: 0 }, 'io').fx('arils', 'head', 3); }, 'bow', 'nod']);
    d('mangie', [t => sp(t, { lf: 1, close: 0.6, blush: 0.6, smile: 1 }, 1200, 800), ['twirl', 1], 'curtsy']);
    d('razzy', [t => { t.to(200, { jig: 1.3 }, 'o').fx('spark', 'head', 2).to(700, { jig: 0 }, 'io'); }, ['twirl', 1], 'giggle']);
  });
})();
