// Squad House life for the 9 new Pet Shop creatures (Nov 10): sit / lounge fidgets, bedtime, water, play + kitchen, the [B] list, the batch-7
// extras, walks and stand fidgets - the same builders the house-*-c.js tables use (like snack2-house.js), each with its own signature beat.
// Loaded after house-idle-c.js. Channels: pet2-anims.js header (Tilly's crest = ears, negative = up; Clover's tall ears spread out when positive).
(function () {
  const K = ['tilly', 'pico', 'clover', 'chilla', 'mimi', 'puddles', 'bean', 'zippy', 'mango'];
  (window.HouseCreatures = window.HouseCreatures || []).push(function (H) {
    const { build, bedBuild, waterBuild, playBuild, bBuild, o } = H;
    const sp = (t, v, d, hold) => { const b = {}; Object.keys(v).forEach(k => b[k] = t.B[k] != null ? t.B[k] : 0); t.to((d || 700) * 0.4, v, 'o').wait(hold || 300).to((d || 700) * 0.6, b, 'io'); return t; };
    const bk = (t, d) => t.back(d || 420);
    const B = (t, k) => t.B[k] || 0;
    const hop = { dn: 'hop', up: 'hop' };
    const mk = (key, base, P) => build(key, o(base, P, { pose: o(base.pose || {}, P.pose || {}), lpose: o(base.lpose || {}, P.lpose || {}) }));
    // ---------- own signature beats (also used for bed / water / play) ----------
    const SIG = {
      tilly: t => { t.to(160, { earL: -24, earR: -24 }, 'o'); for (let i = 0; i < 3; i++) t.to(110, { pitch: B(t, 'pitch') - 0.15 }, 'o').to(160, { pitch: B(t, 'pitch') }, 'io'); t.fx('note', 'head'); return bk(t); },   // crest up, head bobs, whistle
      pico: t => { t.osc(900, 6, { open: 0.4, mw: 0.6 }, { open: 0, mw: 1 }, 'o').fx('note', 'head'); return bk(t); },                                                                                                  // chatters
      clover: t => { t.osc(600, 4, { mw: 0.7 }, { mw: 1 }, 'o').to(300, { earL: 16, earR: 16 }, 'io').to(300, { earL: 0, earR: 0 }, 'io'); return bk(t); },                                                         // nose twitch, ears flare
      chilla: t => { t.to(160, { sq: B(t, 'sq') + 0.08 }, 'io').to(200, { lift: B(t, 'lift') + 4, sq: B(t, 'sq') - 0.06 }, 'o').to(220, { lift: B(t, 'lift'), sq: B(t, 'sq') }, 'i').fx('poof', 'body', 2); return bk(t); },   // a little popcorn
      mimi: t => { t.osc(800, 5, { mw: 0.7, pitch: B(t, 'pitch') + 0.05 }, { mw: 1, pitch: B(t, 'pitch') }, 'o').fx('note', 'head'); return bk(t); },                                                              // sniffs, squeaks
      puddles: t => { t.osc(800, 6, { wag: 30 }, { wag: -30 }, 'io').to(120, { wag: 0 }).fx('note', 'head'); return bk(t); },                                                                                       // tail waggle, quack
      bean: t => { t.to(200, { tongue: 0.7, open: 0.25, hap: 0.8 }, 'io').osc(1000, 6, { wag: 40 }, { wag: -40 }, 'io'); return bk(t); },                                                                          // tongue out, tail going
      zippy: t => { for (let i = 0; i < 3; i++) t.to(80, { lift: B(t, 'lift') + 1.6 }, 'o').to(90, { lift: B(t, 'lift') }, 'i'); t.fx('note', 'head'); return bk(t); },                                            // dook dook dook
      mango: t => { t.to(380, { close: 1 }, 'io').wait(300).to(400, { close: 0 }, 'io').osc(1400, 3, { wag: 26 }, { wag: -26 }, 'io'); return bk(t); },                                                            // slow blink, lazy tail wave
    };
    const SLEEPY = {
      tilly: t => sp(t, { earL: 22, earR: 22, sq: B(t, 'sq') + 0.08, close: 1 }, 1600, 1500), pico: t => sp(t, { sq: B(t, 'sq') + 0.1, close: 1, pitch: B(t, 'pitch') - 0.1 }, 1500, 1400),
      clover: t => sp(t, { earL: -6, earR: -6, close: 1, sq: B(t, 'sq') + 0.06 }, 1600, 1500), chilla: t => sp(t, { sq: B(t, 'sq') + 0.1, close: 1 }, 1500, 1400),
      mimi: t => sp(t, { sq: B(t, 'sq') + 0.08, close: 1, wag: 14 }, 1400, 1300), puddles: t => sp(t, { sq: B(t, 'sq') + 0.08, close: 1, pitch: B(t, 'pitch') - 0.12 }, 1500, 1400),
      bean: t => { sp(t, { sq: B(t, 'sq') + 0.08, close: 1, tongue: 0.4, open: 0.15 }, 1700, 1600); t.fx('note', 'head'); return t; }, zippy: t => sp(t, { sq: B(t, 'sq') + 0.12, close: 1, bend: 3 }, 1500, 1400),
      mango: t => sp(t, { close: 1, sq: B(t, 'sq') + 0.06, wag: 18 }, 1900, 1800),
    };
    // ---------- sit / lounge ----------
    const AR = { armL: 60, armR: 60 }, WG = { armL: 18, armR: 18 };
    mk('tilly', hop, { lpose: WG, f: ['look', SIG.tilly, 'swing', 'hum'], lf: ['sigh', SLEEPY.tilly, 'doze', 'stretch'] });
    mk('pico', hop, { lpose: WG, f: ['look', SIG.pico, 'swing', 'giggle'], lf: ['sigh', 'doze', SLEEPY.pico, 'belly'] });
    mk('clover', hop, { lpose: AR, f: ['look', SIG.clover, 'swing', 'ears'], lf: ['sigh', 'doze', SLEEPY.clover, 'belly'] });
    mk('chilla', hop, { lpose: AR, f: ['look', SIG.chilla, 'swing', 'ears'], lf: ['sigh', 'doze', SLEEPY.chilla, 'stretch'] });
    mk('mimi', hop, { lpose: AR, f: ['look', SIG.mimi, 'kick', 'ears'], lf: ['sigh', 'doze', SLEEPY.mimi, 'belly'] });
    mk('puddles', hop, { lpose: WG, f: ['look', SIG.puddles, 'kick', 'giggle'], lf: ['sigh', 'doze', SLEEPY.puddles, 'belly'] });
    mk('bean', hop, { lpose: AR, f: ['look', SIG.bean, 'swing', 'kick'], lf: ['belly', SLEEPY.bean, 'doze', 'sigh'] });
    mk('zippy', hop, { lpose: AR, f: ['look', SIG.zippy, 'kick', 'wiggle'], lf: ['sigh', 'doze', SLEEPY.zippy, 'stretch'] });
    mk('mango', hop, { lpose: AR, f: ['look', SIG.mango, 'swing', 'hum'], lf: ['sigh', 'doze', SLEEPY.mango, 'belly'] });
    // ---------- bedtime (dr = dream icon, wk = waking-up extras) ----------
    const DR = { tilly: 'flower', pico: 'nut', clover: 'carrot', chilla: 'acorn', mimi: 'cheese', puddles: 'drop', bean: 'bone', zippy: 'crown', mango: 'sun' };
    const WK = { tilly: { earL: -26, earR: -26 }, pico: { armL: 90, armR: 90 }, clover: { earL: 22, earR: 22 }, chilla: { lift: 3 }, mimi: { earL: -10, earR: -10 }, puddles: { wag: 30 }, bean: { tongue: 0.7, open: 0.3 }, zippy: { lift: 2 }, mango: { wag: 24 } };
    K.forEach(k => bedBuild(k, { dr: DR[k], wk: WK[k], s: SLEEPY[k] }));
    // ---------- water (sw = swim style) - Puddles really swims, Mango floats like a log ----------
    const SW = { tilly: 'bob', pico: 'bob', clover: 'bob', chilla: 'bob', mimi: 'bob', puddles: 'glide', bean: 'bob', zippy: 'glide', mango: 'float' };
    K.forEach(k => waterBuild(k, { sw: SW[k], k: { a: WK[k], b: {}, f: WK[k] }, s: SIG[k] }));
    // ---------- play + kitchen (sn = favourite snack icon) ----------
    const SN = { tilly: 'berry', pico: 'apple', clover: 'carrot', chilla: 'apple', mimi: 'cheese', puddles: 'berry', bean: 'bone', zippy: 'apple', mango: 'berry' };
    const CHEER = { tilly: { cheer: { earL: -26, earR: -26 } }, pico: { cheer: { armL: 120, armR: 120 }, cheerFx: ['featherG', 'body'] }, clover: { cheer: { earL: 24, earR: 24 } }, chilla: { cheer: { earL: 10, earR: 10 }, cheerFx: ['poof', 'body'] },
      mimi: { cheer: { wag: 30 } }, puddles: { cheer: { wag: 30 }, cheerFx: ['splash', 'body'] }, bean: { cheer: { tongue: 0.7, wag: 40 } }, zippy: { cheer: { bend: -3, wag: 30 } }, mango: { cheer: { wag: 30 } } };
    K.forEach(k => playBuild(k, o(CHEER[k], { sn: SN[k], p: SIG[k] })));
    // ---------- [B] list (fc = what she fishes up, tk = trampoline trick, tb = toothbrush colour) ----------
    const FC = { tilly: 'flower', pico: 'star', clover: 'carrot', chilla: 'acorn', mimi: 'cheese', puddles: 'boot', bean: 'bone', zippy: 'crown', mango: 'shell' }, TBC = ['#5fb8e8', '#7cc35a', '#ff8fa8', '#ffcc3a', '#b98ae8', '#ff8a4a'];
    K.forEach((k, i) => bBuild(k, o(CHEER[k], { fc: FC[k], tk: o(WK[k]), tb: TBC[i % TBC.length], sn: SN[k] })));
    // ---------- batch-7 extras (ks = how she kicks a ball, Pet Shop prop colours) ----------
    if (H.cBuild) K.forEach(k => H.cBuild(k, { ks: 'foot', pc: '#e8483c', hc: '#e8483c', mc: '#3b3b4a', fc2: ['#ffcc3a', '#5ab4f0', '#ff8fa8', '#b98ae8', '#7cc35a', '#ff8a4a', '#ffcc3a', '#5ab4f0', '#ff8fa8'][K.indexOf(k)] }));
    window.HouseWalkRUN = Object.assign(window.HouseWalkRUN || {}, { tilly: { earL: -16, earR: -16 }, pico: { armL: 50, armR: 50 }, clover: { earL: 14, earR: 14 }, zippy: { bend: -2 }, bean: { tongue: 0.6, open: 0.25 } });
  });
  // ---------- walks ----------
  const walks = W => { const d = (k, P) => W.def(k, P);
    d('tilly', { g: 'strut', a: 0.9 }); d('pico', { g: 'hop', a: 1.1 }); d('clover', { g: 'hop', a: 1.2 }); d('chilla', { g: 'hop', a: 1.25 }); d('mimi', { g: 'scurry', a: 1 });
    d('puddles', { g: 'waddle', a: 1.1 }); d('bean', { g: 'trot', a: 1 }); d('zippy', { g: 'skip', a: 1.1 }); d('mango', { g: 'crawl', a: 0.8 }); };
  if (window.HouseWalk) walks(window.HouseWalk); else (window.HouseWalkC = window.HouseWalkC || []).push(walks);
  // ---------- stand fidgets ----------
  (window.HouseIdleC = window.HouseIdleC || []).push(function (W) {
    const { hand, both, o } = window.RiveRig.HOUSE, sp = W.sp, d = (k, L) => W.build(k, L);
    d('tilly', [t => { t.to(160, { earL: -24, earR: -24 }, 'o').to(240, { armL: 96, armR: 96 }, 'o'); for (let i = 0; i < 3; i++) t.to(110, { pitch: -0.15 }, 'o').to(160, { pitch: 0 }, 'io'); t.fx('note', 'head').to(300, { armL: 0, armR: 0, earL: 0, earR: 0 }, 'io'); },
      t => { t.to(380, { hyaw: -0.5, pitch: -0.25, htilt: -10, armL: 30 }, 'io').osc(800, 3, { pitch: -0.32, open: 0.2 }, { pitch: -0.22, open: 0 }, 'io').to(360, { hyaw: 0, pitch: 0, htilt: 0, armL: 0 }, 'io'); }, 'flap']);   // heart wings + bob, preening
    d('pico', [t => { t.osc(1000, 7, { open: 0.4, mw: 0.6, pitch: 0.05 }, { open: 0, mw: 1, pitch: 0 }, 'o').fx('note', 'head'); for (let i = 0; i < 3; i++) t.to(100, { pitch: -0.18 }, 'o').to(140, { pitch: 0 }, 'io'); }, ['hops', 2], 'flap']);
    d('clover', [t => { t.osc(600, 4, { mw: 0.7 }, { mw: 1 }, 'o').to(300, o(both(4, -16), { armL: 30, armR: 30 }), 'io').osc(900, 3, both(5, -22), both(4, -13), 'io').to(280, o(both(0, 0), { armL: 0, armR: 0 }), 'io'); }, ['hops', 2], 'sniff']);   // face wash
    // Nov 10 v2 (user: 'the dust bath needs to be bigger' + a photo of a chinchilla rolling in a big tub of dust): the tub is big now (rig) and she
    // rolls in it like the dance - flops over onto her side, rolls onto her back (feet in the air) and over, ~1.7 s, a little cloud of dust, rolls back up
    // (the same lying pose + rolls as pet2-anims BLIE / BA / BB - copied here: this table is built before pet2-anims boots)
    const CB = { LIE: { tilt: 99, x: -43.5, lift: 26.5, spin: -16, sq: 0.1, sit: 1, close: 1, hap: 1, smile: 1, earL: 18, earR: 50, footL: 1.5, footR: 1.5, armL: -8, armR: -8, htilt: 0, hyaw: 0, bend: 0, twist: 0, lean: 0, wag: 0, dbs: 1, wsk: 1 },
      A: { tilt: 105, x: -42, lift: 28.5, spin: -82, sq: 0.18, footL: 3.4, footR: 1.2, armL: -28, armR: 6, earL: 27, earR: 50, htilt: -11, hyaw: -0.14, bend: -14, twist: -0.12, wag: -32 }, B: { tilt: 95, x: -46, lift: 25.5, spin: 38, sq: 0.18, footL: 0.6, footR: 3.4, armL: 6, armR: -28, earL: 26, earR: 55, htilt: 11, hyaw: 0.14, bend: 18, twist: 0.12, wag: 32 } };
    d('chilla', [t => { t.to(240, { dbb: 1.12 }, 'o').to(160, { dbb: 1 }, 'io').to(200, { lift: -2.5, sq: 0.14, close: 0.7, hap: 1, smile: 1 }, 'io').fx('dustbath', [50, 84], 3);
      { const L = CB.LIE, mx = (q, g) => { const r = {}; for (const k in q) r[k] = L[k] + (q[k] - L[k]) * g; return r; };
        t.to(200, { tilt: 44, x: -17, lift: 9, spin: -6, sq: 0.06, sit: 0.6, earL: 18, earR: 18, close: 1 }, 'i').to(190, Object.assign({}, L, { tilt: 105, lift: 25, x: -42.5 }), 'o').fx('dustbath', [30, 83], 3).fx('dustbath', [70, 83], 3).to(170, { tilt: 99, lift: 26.5, x: -43.5, dbh: 0.4 }, 'io');
        for (let i = 0; i < 10; i++) { const g = Math.min(1, (i + 1) / 3, (10 - i) / 3); t.to(170, Object.assign(mx(i % 2 ? CB.B : CB.A, g), { dbh: 0.8 }), 'io'); if (i % 2) t.fx('dustbath', [24 + (i * 13) % 52, 83], 2).fx('dustspray', [i % 4 === 1 ? 24 : 80, 82], 2); }
        t.to(200, Object.assign(mx(CB.A, 0), { dbh: 0.3 }), 'io').to(230, { tilt: 46, x: -16, lift: 10, spin: -6, sit: 0.4, sq: 0.06, close: 0.4, footL: 0, footR: 0, armL: 0, armR: 0, htilt: 0, hyaw: 0, bend: 0, twist: 0, lean: 0, wag: 0, dbh: 0, dbs: 0, wsk: 0.4 }, 'i')
         .to(230, { tilt: -6, x: 0, lift: -1, spin: 0, sit: 0, sq: 0.04, close: 0, hap: 0, earL: 0, earR: 0, smile: 0, wsk: 0 }, 'o').to(170, { tilt: 0, lift: -2.5, sq: 0.1 }, 'io'); }
      t.to(180, { lift: 2 }, 'o').to(240, { dbb: 0, lift: 0, sq: 0 }, 'i').fx('poof', 'body', 2); }, ['hops', 2], 'shake']);   // a real dust bath (rig tub, dbb)
    d('mimi', [t => { t.to(240, o(both(5, -15), { armL: 34, armR: 34 }), 'io').osc(900, 4, both(9, -13), both(4, -15), 'io').to(240, o(both(0, 0), { armL: 0, armR: 0 }), 'io'); }, 'sniff', 'clap']);   // whisker wash
    d('puddles', [t => { for (let i = 0; i < 4; i++) { const f = i % 2 ? 'footL' : 'footR'; t.to(140, { [f]: 3.5 }, 'o').to(90, { [f]: 0, sq: 0.06 }, 'i').fx('splash', 'body', 2).to(120, { sq: 0 }, 'io'); } }, 'flap', 'shimmy']);   // puddle stomps
    d('bean', [t => { t.to(320, { htilt: 16, earL: -10, earR: -10 }, 'io').wait(400).to(340, { htilt: -12 }, 'io').wait(300).to(260, { htilt: 0, earL: 0, earR: 0 }, 'io'); }, 'shimmy', 'sniff']);   // the pug head tilt
    d('zippy', [t => { for (let i = 0; i < 4; i++) { const s = i % 2 ? -1 : 1; t.to(70, { sq: 0.1 }, 'io').to(140, { lift: 5, x: s * 2.5, tilt: s * 10 }, 'o').to(150, { lift: 0, tilt: 0 }, 'i'); } t.to(300, { x: 0 }, 'io').fx('note', 'head'); }, ['hops', 3], 'shimmy']);   // war-dance hops
    d('mango', [t => { t.to(120, { tongue: 1, open: 0.3, pitch: 0.18, htilt: 8, winkR: 1 }, 'o').to(180, { tongue: 0, open: 0, pitch: 0, htilt: 0, winkR: 0 }, 'io').wait(300).osc(1400, 3, { wag: 26 }, { wag: -26 }, 'io'); }, 'stretch', 'rock']);   // eye lick, tail wave
  });
})();
