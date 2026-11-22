// Squad House moves for the 11 new Snack Shack creatures (Nov 9): sit / lounge fidgets, bedtime, water, play + kitchen, the [B] list, the batch-7
// extras, walks and stand fidgets - the same builders the house-*-c.js tables use, with each one's own parts (snack-3d.js channels). Loaded after
// house-idle-c.js (the builders already ran for the rest; HouseCreatures / HouseIdleC push run at once from here on).
(function () {
  const K = ['frankie', 'corny', 'peppi', 'nori', 'sunny', 'toco', 'churro', 'khinki', 'maki', 'noodle', 'flossie'];
  (window.HouseCreatures = window.HouseCreatures || []).push(function (H) {
    const { build, bedBuild, waterBuild, playBuild, bBuild, hand, both, o } = H;
    const sp = (t, v, d, hold) => { const b = {}; Object.keys(v).forEach(k => b[k] = t.B[k] != null ? t.B[k] : 0); t.to((d || 700) * 0.4, v, 'o').wait(hold || 300).to((d || 700) * 0.6, b, 'io'); return t; };
    const bk = (t, d) => t.back(d || 420);
    const hop = { dn: 'hop', up: 'hop' }, RL = { armL: 12, armR: 12, hLx: 3, hRx: -3, hLy: 3, hRy: 3 };
    const mk = (key, base, P) => build(key, o(base, P, { pose: o(base.pose || {}, P.pose || {}), lpose: o(base.lpose || {}, RL, P.lpose || {}) }));
    // ---------- own signature beats (also used for bed / water / play) ----------
    const SIG = {
      frankie: t => { sp(t, { hug: -0.7, sq: t.B.sq + 0.04, smile: 1, close: 0.6 }, 1200, 900); t.fx('mustard', 'head'); return t; },
      corny: t => { t.to(200, { cfz: 1 }).wait(300).to(120, { pop: 1 }, 'o').fx('popk', 'head', 3).to(380, { pop: 0, cfz: 0 }, 'i'); return bk(t); },
      peppi: t => sp(t, { flop: 0.8, close: 0.6, smile: 1 }, 1600, 1400),
      nori: t => { t.to(300, { pitch: (t.B.pitch || 0) - 0.15, close: 0.6 }).wait(200).to(300, { pitch: t.B.pitch || 0, close: 0 }).to(140, { ume: 1 }, 'o').to(300, { ume: 0 }, 'i'); return bk(t); },
      sunny: t => sp(t, { cap: 0.7, wob: 0.8, smile: 1, hap: 0.6 }, 1200, 700),
      toco: t => { for (let i = 0; i < 2; i++) t.to(110, { snap: -0.5 }, 'o').to(200, { snap: 0.4 }, 'io'); t.to(150, { snap: 0 }).fx('lettuce', 'head', 2); return bk(t); },
      churro: t => { t.to(400, { cork: 0.8 }, 'io').to(400, { cork: -0.6 }, 'io').to(300, { cork: 0 }, 'io').fx('sugar', 'head', 3); return bk(t); },
      khinki: t => { t.osc(1000, 3, { knot: 0.6 }, { knot: -0.6 }, 'io').to(150, { knot: 0 }); return bk(t); },
      maki: t => sp(t, { veg: 0.9, smile: 1, hap: 0.5 }, 900, 600),
      noodle: t => { t.to(300, { slurp: 1, puff: -0.3, mw: 0.5 }).wait(300).to(250, { slurp: 0, puff: 0, mw: 1, hap: 0.6, smile: 1 }, 'o').fx('steam', 'head'); return bk(t); },
      flossie: t => sp(t, { fluff: 1, smile: 1, hap: 0.6 }, 1000, 700),
    };
    const SLEEPY = {
      frankie: t => sp(t, { hug: -0.5, close: 1 }, 1600, 1600), corny: t => sp(t, { cfz: 0.5, close: 0.8 }, 1400, 1200), peppi: t => sp(t, { flop: 1, close: 1 }, 2000, 1800),
      nori: t => sp(t, { nwr: 0.5, close: 0.8 }, 1400, 1200), sunny: t => sp(t, { cap: 0.3, close: 1 }, 1600, 1400), toco: t => sp(t, { snap: 0.6, close: 0.8 }, 1400, 1200),
      churro: t => sp(t, { cork: 0.5, close: 0.9 }, 1600, 1400), khinki: t => sp(t, { kt: 0.6, close: 0.8 }, 1400, 1200), maki: t => sp(t, { veg: 0.4, close: 1 }, 1600, 1400),
      noodle: t => { t.fx('steam', 'head').wait(800).fx('steam', 'head'); return t; }, flossie: t => sp(t, { fluff: 0.6, close: 1 }, 1600, 1400),
    };
    // ---------- sit / lounge ----------
    mk('frankie', hop, { f: ['look', SIG.frankie, t => { t.osc(1200, 3, { slip: 0.4 }, { slip: -0.4 }, 's').to(200, { slip: 0 }); bk(t); }, 'swing'], lf: ['sigh', SLEEPY.frankie, 'doze', 'belly'] });
    mk('corny', hop, { f: ['look', SIG.corny, 'swing', 'kick'], lf: ['sigh', 'doze', SLEEPY.corny, 'belly'] });
    mk('peppi', hop, { f: ['look', SIG.peppi, 'swing', 'hum'], lf: ['sigh', SLEEPY.peppi, 'doze', 'stretch'] });
    mk('nori', hop, { f: ['look', SIG.nori, 'swing', 'pat'], lf: ['sigh', 'doze', SLEEPY.nori, 'stretch'] });
    mk('sunny', hop, { f: ['look', SIG.sunny, 'swing', 'giggle'], lf: ['sigh', 'doze', SLEEPY.sunny, 'belly'] });
    mk('toco', hop, { f: ['look', SIG.toco, 'kick', 'swing'], lf: ['sigh', 'doze', SLEEPY.toco, 'belly'] });
    mk('churro', hop, { f: ['look', SIG.churro, 'swing', 'hum'], lf: ['sigh', 'doze', 'stretch', 'belly'] });
    mk('khinki', hop, { f: ['look', SIG.khinki, 'swing', 'pat'], lf: ['sigh', 'doze', SLEEPY.khinki, 'belly'] });
    mk('maki', hop, { f: ['look', SIG.maki, 'swing', 'hum'], lf: ['sigh', 'doze', 'belly', 'stretch'] });
    mk('noodle', hop, { f: ['look', SIG.noodle, 'swing', 'kick'], lf: ['sigh', SLEEPY.noodle, 'doze', 'stretch'] });
    mk('flossie', { dn: 'float', up: 'float' }, { f: ['look', SIG.flossie, t => { t.to(1400, { swirl: 1 }, 'io').to(1, { swirl: 0 }, 'l'); bk(t); }, 'hum'], lf: ['sigh', 'doze', SLEEPY.flossie, 'stretch'] });
    // ---------- bedtime (dr = dream icon) ----------
    const DR = { frankie: 'ketchup', corny: 'star', peppi: 'cheese', nori: 'fish', sunny: 'sun', toco: 'cheese', churro: 'cookie', khinki: 'cup', maki: 'fish', noodle: 'cup', flossie: 'cloud' };
    const WK = { frankie: { hug: 0.6 }, corny: { pop: 0.8 }, peppi: { flop: -0.6 }, nori: { ume: 0.8 }, sunny: { cap: 0.6 }, toco: { snap: 0.8 }, churro: { cork: 0.8 }, khinki: { knot: 0.6 }, maki: { veg: 0.8 }, noodle: { lid: 0.8 }, flossie: { fluff: 1 } };
    K.forEach(k => bedBuild(k, { dr: DR[k], wk: WK[k], s: SLEEPY[k] }));
    // ---------- water (sw = swim style, k = shake extras) ----------
    const SW = { frankie: 'bob', corny: 'bob', peppi: 'float', nori: 'bob', sunny: 'bob', toco: 'bob', churro: 'float', khinki: 'bob', maki: 'bob', noodle: 'bob', flossie: 'float' };
    K.forEach(k => waterBuild(k, { sw: SW[k], k: { a: WK[k], b: {}, f: WK[k] }, s: SIG[k] }));
    // ---------- play + kitchen (sn = favourite snack icon from the fridge; round foods grip the swing ropes low) ----------
    const SN = { frankie: 'ketchup', corny: 'candy', peppi: 'cheese', nori: 'fish', sunny: 'cookie', toco: 'cheese', churro: 'cookie', khinki: 'cup', maki: 'fish', noodle: 'cup', flossie: 'candy' };
    const CHEER = { frankie: { cheer: { hug: 0.6 }, cheerFx: ['mustard', 'head'] }, corny: { cheer: { pop: 1 }, cheerFx: ['popk', 'head'] }, peppi: { cheer: { pull: 0.6 } }, nori: { cheer: { ume: 1 } }, sunny: { cheer: { cap: 0.8 } },
      toco: { cheer: { snap: 0.8 }, cheerFx: ['lettuce', 'head'] }, churro: { cheer: { cork: 0.8 }, cheerFx: ['sugar', 'head'] }, khinki: { cheer: { knot: 0.6 } }, maki: { cheer: { veg: 1 } }, noodle: { cheer: { lid: 0.8 }, cheerFx: ['steam', 'head'] }, flossie: { cheer: { fluff: 1 }, cheerFx: ['floss', 'head'] } };
    K.forEach(k => playBuild(k, o(CHEER[k], { sn: SN[k], p: SIG[k], sp: { armL: 42, armR: 42, hLy: -7, hRy: -7, hLx: 1, hRx: -1 } })));
    // ---------- [B] list (fc = what he fishes up, tk = trampoline trick, tb = toothbrush colour) ----------
    const FC = { frankie: 'boot', corny: 'star', peppi: 'cheese', nori: 'fish', sunny: 'shell', toco: 'leaf', churro: 'cookie', khinki: 'cup', maki: 'fish', noodle: 'cup', flossie: 'cloud' }, TBC = ['#5fb8e8', '#7cc35a', '#ff8fa8', '#ffcc3a', '#b98ae8', '#ff8a4a'];
    K.forEach((k, i) => bBuild(k, o(CHEER[k], { fc: FC[k], tk: o(WK[k]), tb: TBC[i % TBC.length], sn: SN[k] })));
    // ---------- batch-7 extras (ks = how he kicks a ball, prop colours) ----------
    if (H.cBuild) K.forEach(k => H.cBuild(k, { ks: k === 'maki' || k === 'corny' || k === 'noodle' || k === 'sunny' ? 'body' : 'foot', pc: '#ffb84a', hc: '#ffb84a', mc: k === 'flossie' ? '#ff8fc8' : '#3b3b4a' }));
    window.HouseWalkRUN = Object.assign(window.HouseWalkRUN || {}, { corny: { pop: 0.4 }, toco: { snap: 0.3 }, flossie: { fluff: 0.4 }, khinki: { knot: 0.4 } });
  });
  // ---------- walks ----------
  const walks = W => { const d = (k, P) => W.def(k, P);
    d('frankie', { g: 'shuffle', a: 0.9, x: { slip: [0.25, 1, 0, 0] } }); d('corny', { g: 'bounce', a: 0.9, x: { pop: [0.35, 2, 0, 1] } }); d('peppi', { g: 'waddle', a: 0.8, x: { flop: [0.4, 1, 0, 0] } });
    d('nori', { g: 'shuffle', a: 0.8 }); d('sunny', { g: 'eggroll', a: 0.8 }); d('toco', { g: 'bounce', a: 0.9, x: { snap: [0.35, 2, 0, 0] } });
    d('churro', { g: 'prance', a: 0.9, x: { cork: [0.3, 1, 0, 0] } }); d('khinki', { g: 'waddle', a: 0.85, x: { knot: [0.4, 1, 0, 0] } }); d('maki', { g: 'shuffle', a: 0.85, x: { veg: [0.3, 2, 0, 1] } });
    d('noodle', { g: 'bounce', a: 0.8, x: { lid: [0.3, 2, 0, 1] }, fx: ['steam', 1100] }); d('flossie', { g: 'float', a: 0.9 });
    // Sunny has no legs - she ROLLS from place to place (user, Nov 9): her roll angle (rl) follows the ground she covers (clockwise walking right, the
    // way a ball rolls; a slower roll when she heads toward / away from you), paws out for balance; when she stops she rocks back upright on the
    // nearest side with a little wobble (a spring with some overshoot)
    W.G.eggroll = W.G.eggroll || { r: 0.9, dl: 0, f(p, A, o) { o.armL = 24 + 7 * A * Math.sin(p); o.armR = 24 - 7 * A * Math.sin(p); o.sq = 0.02 * A * Math.sin(2 * p); } };
    if (!W.__snRoll) { W.__snRoll = 1; const st0 = W.step; W.step = function (key, st, E, w, dt, spd, spin) { const r = st0.apply(this, arguments); if (key !== 'sunny') return r;
        const dir = Math.sin((spin || 0) * Math.PI / 180), mv = (spd || 0) > 0 && w > 0.3; st.ra = st.ra || 0; st.rv = st.rv || 0;
        if (mv) { const tv = 300 * spd * (st.run ? 1.6 : 1) * (Math.abs(dir) < 0.3 ? (dir < 0 ? -0.3 : 0.3) : dir); st.rv += (tv - st.rv) * Math.min(1, dt * 6); st.ra += st.rv * dt; }
        else { const tg = Math.round(st.ra / 360) * 360; st.rv += ((tg - st.ra) * 60 - st.rv * 7) * Math.min(dt, 0.05); st.ra += st.rv * Math.min(dt, 0.05); if (Math.abs(tg - st.ra) < 0.3 && Math.abs(st.rv) < 2) { st.ra = 0; st.rv = 0; } }
        E.rl = (E.rl || 0) + ((st.ra % 360) + 540) % 360 - 180; return r; }; } };
  if (window.HouseWalk) walks(window.HouseWalk); else (window.HouseWalkC = window.HouseWalkC || []).push(walks);
  // ---------- stand fidgets ----------
  (window.HouseIdleC = window.HouseIdleC || []).push(function (W) {
    const { hand, o } = window.RiveRig.HOUSE, sp = W.sp, d = (k, L) => W.build(k, L);
    d('frankie', [t => { sp(t, { hug: -0.7, sq: 0.04, smile: 1, close: 0.6 }, 1200, 900); t.fx('mustard', 'head'); }, t => { t.osc(1200, 3, { slip: 0.4 }, { slip: -0.4 }, 's').to(200, { slip: 0 }); }, 'clap']);
    d('corny', [t => { t.to(200, { cfz: 1 }).wait(300).to(120, { pop: 1 }, 'o').fx('popk', 'head', 3).to(380, { pop: 0, cfz: 0 }, 'i'); }, 'bounce', 'giggle']);
    d('peppi', [t => sp(t, { flop: 0.8, close: 0.6, smile: 1 }, 1600, 1400), t => { t.to(300, { pull: 1, lift: 2 }, 'o').to(260, { pull: 0, lift: 0 }, 'i').fx('cheese', 'head', 2); }, 'hum']);
    d('nori', [t => { t.to(300, { pitch: -0.15, close: 0.6 }).wait(200).to(300, { pitch: 0, close: 0 }).to(140, { ume: 1 }, 'o').to(300, { ume: 0 }, 'i'); }, 'bow', 'nod']);
    d('sunny', [t => sp(t, { cap: 0.7, wob: 0.8, smile: 1, hap: 0.6 }, 1200, 700), t => { t.osc(1400, 3, { rl: 14, x: 3 }, { rl: -14, x: -3 }, 'io').to(300, { rl: 0, x: 0 }, 'io'); }, 'curtsy']);
    d('toco', [t => { for (let i = 0; i < 2; i++) t.to(110, { snap: -0.5 }, 'o').to(200, { snap: 0.4 }, 'io'); t.to(150, { snap: 0 }).fx('lettuce', 'head', 2); }, 'clap', 'wiggle']);
    d('churro', [t => { t.to(400, { cork: 0.8 }, 'io').to(400, { cork: -0.6 }, 'io').to(300, { cork: 0 }, 'io').fx('sugar', 'head', 3); }, ['twirl', 1], 'bow']);
    d('khinki', [t => { t.osc(1000, 3, { knot: 0.6 }, { knot: -0.6 }, 'io').to(150, { knot: 0 }); }, 'belly', 'nod']);
    d('maki', [t => sp(t, { veg: 0.9, smile: 1, hap: 0.5 }, 900, 600), ['twirl', 1], 'bow']);
    d('noodle', [t => { t.to(300, { slurp: 1, puff: -0.3, mw: 0.5 }).wait(300).to(250, { slurp: 0, puff: 0, mw: 1, hap: 0.6, smile: 1 }, 'o').fx('steam', 'head'); }, 'bounce', 'hum']);
    d('flossie', [t => sp(t, { fluff: 1, smile: 1, hap: 0.6 }, 1000, 700), t => { t.to(1400, { swirl: 1 }, 'io').to(1, { swirl: 0 }, 'l'); }, 'curtsy']);
  });
})();
