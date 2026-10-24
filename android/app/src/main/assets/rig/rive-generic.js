// Generic Rive-style renderer: rigs any Squish Squad creature from its own front art, driven by the same
// state machine, layers and move library as Mittens (squash, head sphere, ears, paws, feet, tail, face).
(function () {
  if (window.RiveGeneric) return;
  const cache = {};
  const load = k => cache[k] || (cache[k] = fetch('export/tripo/' + k + '/' + k + '-front.svg' + (((window.CREATURES_V2 || []).find(c => c.src && c.src.indexOf('/' + k + '/' + k + '-front.svg?') >= 0) || {}).src || '').replace(/^[^?]*/, '')).then(r => r.text()).then(t => t.replace(/<metadata>[\s\S]*?<\/metadata>/, '')));
  const num = (e, a) => parseFloat(e.getAttribute(a) || '0');
  const pts = segs => segs.flatMap(g => g.p || []);
  const lerpN = (a, b, t) => a + (b - a) * t;

  const R = (o, k, v) => [].concat(v).forEach(i => o[i] = k);
  const PETS = {
    biscuit: o => { R(o, 'head', 5); R(o, 'body', [3, 4]); R(o, 'tail', 0); R(o, 'foot', [1, 2]); R(o, 'pad', [16, 17, 18, 19, 20, 21]); R(o, 'earF', [6, 7]); R(o, 'patch', [8, 9]); R(o, 'arm', [10, 11]); R(o, 'hide', 15); R(o, 'body', 22); R(o, 'swing', 23); },
    prickle: o => { R(o, 'head', 3); R(o, 'mane', 2); R(o, 'foot', [0, 1]); R(o, 'patch', 4); R(o, 'arm', [5, 6]); },
    nibbles: o => { R(o, 'head', 6); R(o, 'body', [2, 3]); R(o, 'foot', [0, 1]); R(o, 'earP', [4, 5]); R(o, 'inner4', 10); R(o, 'inner5', 11); R(o, 'patch', 7); R(o, 'arm', [8, 9]); },
    quill: o => { R(o, 'mane', 0); R(o, 'foot', [1, 2]); R(o, 'body', [3, 4]); R(o, 'earP', [5, 6]); R(o, 'inner5', 11); R(o, 'inner6', 12); R(o, 'head', 7); R(o, 'patch', 8); R(o, 'arm', [9, 10]); },
    waffles: o => { R(o, 'head', 5); R(o, 'body', [3, 4]); R(o, 'tail', 0); R(o, 'foot', [1, 2]); R(o, 'pad', [16, 17, 18, 19, 20, 21]); R(o, 'earF', [6, 7]); R(o, 'patch', [8, 9]); R(o, 'arm', [10, 11]); R(o, 'hide', 15); R(o, 'body', 22); R(o, 'swing', 23); },
    poppy: o => { R(o, 'foot', [0, 1]); R(o, 'earP', [2, 3]); R(o, 'head', 4); R(o, 'patch', [5, 6, 7, 8]); R(o, 'arm', [9, 10]); },
    duchess: o => { R(o, 'tail', 0); R(o, 'foot', [1, 2]); R(o, 'body', [3, 11, 12]); R(o, 'arm', [4, 5]); R(o, 'earP', [6, 7]); R(o, 'inner6', 8); R(o, 'inner7', 9); R(o, 'head', 10); R(o, 'crown', [13, 14, 15, 16]); },
    lumi: o => { R(o, 'foot', [0, 2]); R(o, 'pad', [1, 3]); R(o, 'earP', [4, 5]); R(o, 'inner4', 6); R(o, 'inner5', 7); R(o, 'body', 8); R(o, 'head', 9); R(o, 'arm', [10, 11]); R(o, 'bdeco', [12, 13]); R(o, 'hclip', 14); },
    bubbly: o => { R(o, 'head', 0); R(o, 'headDup', 1); R(o, 'gloss', [2, 3]); R(o, 'orbit', [4, 5]); },
    mamapaws: o => { R(o, 'foot', [0, 1]); R(o, 'body', [2, 3]); R(o, 'arm', [4, 5]); R(o, 'head', 6); R(o, 'earF', [7, 8]); R(o, 'patch', 9); R(o, 'pup', [11, 12, 13, 16, 17, 18, 19, 20, 21]); R(o, 'pupEye', [14, 15]); },
    puff: o => { R(o, 'hide', 0); R(o, 'foot', [1, 2]); R(o, 'arm', [3, 4]); R(o, 'head', 5); R(o, 'patch', [6, 7]); },
    zappi: o => { R(o, 'tail', 0); R(o, 'foot', [1, 3]); R(o, 'pad', [2, 4]); R(o, 'head', 7); R(o, 'arm', [8, 9]); },
  };
  // Sky & Stars: per-creature depth (k = depth/width of the body, <1 = flatter front-to-back) and living props
  const ROUND = { nimbo: { k: 0.62, rain: 1, armIn: 1 }, lumi: { split: 1, lantern: 1, armIn: 1, avoidHead: 1, armDY: 2.5 }, bubbly: { shimmer: 1 }, twinkle: { k: 0.3, star: 1 }, plip: { armIn: 1, hb: 1, gloss: 1, ripple: 1 }, breeze: { armIn: 1, kite: 1, armOut: 2.5, armReach: 0.8 }, dusty: { whole: 1, hb: 1, armIn: 1, armDX: 5, armOut: 2.5, armReach: 0.6, avoidHead: 1, wings: 1, footShade: 1 }, aurora: { whale: 1, whole: 1, hb: 1, armIn: 1, armReach: 1.3, armOut: 5, split: 1 }, mallow: { cyl: 1, whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3 }, bao: { bun: 1, whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3 }, frybo: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, armDY: 12 }, bunbun: { burger: 1, whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3 }, choco: { choco: 1, whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3 }, scoop: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3 }, pina: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, pina: 1 }, avo: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, avo: 1 }, berri: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, berri: 1 }, lemmy: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, lemmy: 1 }, kiwi: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, kiwi: 1 }, peachy: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, peachy: 1 }, melo: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, melo: 1 }, pitaya: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, pitaya: 1 }, tutti: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, tutti: 1 }, hana: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, hana: 1 }, boo: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, boo: 1 }, pixie: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, pixie: 1 }, floof: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, dl: 1, armDY: 7 }, unibun: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, dl: 1 }, gumdrop: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, dl: 1 }, ember: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, dl: 1 }, drako: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, dl: 1 }, jinni: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, dl: 1 }, boba: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3 }, chefbun: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3 }, pip: { whole: 1, hb: 1, peng: 1 }, jelli: { whole: 1, hb: 1, jelly: 1 }, octo: { whole: 1, hb: 1, mReach: 1 }, finn: { whale: 1, dolph: 1, whole: 1, hb: 1, armIn: 1, armReach: 1, armOut: 4 }, shelly: { turtle: 1, mReach: 1 }, puff: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, pfish: 1, armDY: 10, mReach: 1 }, pearl: { whale: 1, dolph: 1, narw: 1, whole: 1, hb: 1, armIn: 1, armReach: 1, armOut: 4 }, sealy: { whale: 1, dolph: 1, seal: 1, whole: 1, hb: 1, armIn: 1, armReach: 1, armOut: 4 }, dunkie: { donut: 1, whole: 1, hb: 1, armIn: 1, lowPaw: 1, armDY: 8, armDX: 2, armOut: 3 }, marina: { whole: 1, hb: 1, mermaid: 1 }, zappi: { armOut: 1.5, zapfx: 1, spiky: 1, split: 1, armIn: 1, armDY: 4, whole: 1, sr: 28, puff: 1, spark: 1 }, teddy: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, dl: 1, ff: 1 }, panko: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, dl: 1, ff: 1 }, hoot: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, dl: 1, ff: 1 }, leo: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, dl: 1, ff: 1 }, acorn: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, dl: 1, ff: 1 }, fawn: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, dl: 1, ff: 1 }, moss: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, dl: 1, ff: 1 }, sprout: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, dl: 1, ff: 1 }, cuppy: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, bk: 1 }, chip: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, bk: 1 }, twisty: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, bk: 1 }, crois: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, bk: 1 }, maca: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, bk: 1 }, puddi: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, bk: 1 }, mochi: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, bk: 1 }, cakey: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, bk: 1 }, sugarplum: { whole: 1, hb: 1, armIn: 1, handFix: 1, armOut: 3, bk: 1 } };
  // Twinkle's own dance: star sway, star jumps, cartwheels both ways, shine spin, disco point (10 s loop)
  function twDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@twinkle']) return;
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.4]] }, at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, HC = 32.4, LP = 10000;
    const wheel = (t0, dur, from, to) => { for (let s = 0; s <= 24; s++) { const u = s / 24, e = u * u * (3 - 2 * u), a = from + (to - from) * e, th = a * Math.PI / 180; at(t0 + dur * u, { tilt: a, x: -HC * Math.sin(th), lift: HC * (1 - Math.cos(th)) + 6 * Math.sin(Math.PI * u) }, 'l'); } };
    for (let b = 0; b < 4; b++) { const d = b % 2 ? 1 : -1, t0 = b * 500;
      at(t0 + 250, { sq: 0.12, lift: 0, tilt: d * 7, lean: d * 1.5, x: d * 2.5, htilt: -d * 3, turn: d * 0.18, armL: d < 0 ? 150 : -25, armR: d > 0 ? 150 : -25, footL: d > 0 ? 3 : 0, footR: d < 0 ? 3 : 0 });
      at(t0 + 500, { sq: -0.05, lift: 3.5 }, 'o'); }
    for (let j = 0; j < 2; j++) { const b = 2000 + j * 1000;
      at(b + 200, { sq: 0.22, lift: 0, tilt: 0, lean: 0, x: 0, htilt: 0, turn: 0, footL: 0, footR: 0, armL: -45, armR: -45, curl: -1 });
      at(b + 480, { sq: -0.16, lift: 13, armL: 140, armR: 140, curl: 1.3 }, 'o');
      at(b + 760, { sq: 0.2, lift: 0, armL: 40, armR: 40, curl: 0.4 }, 'i');
      at(b + 1000, { sq: 0, curl: 0 }); }
    at(4150, { sq: 0.15, armL: 70, armR: 70, curl: 0.9 }); at(4300, { sq: 0 }); wheel(4250, 1000, 0, 360); at(5350, { sq: 0.18 }, 'o'); at(5550, { sq: 0, armL: 30, armR: 30, curl: 0 });
    at(5650, { sq: 0.14, armL: 50, armR: 50 }); at(5850, { sq: -0.1, lift: 9, armL: 165, armR: 165, curl: 0.8 }, 'o'); at(5700, { spin: 0 }, 'l'); at(6650, { spin: 360 }); at(6651, { spin: 0 }, 'l');
    at(6500, { lift: 0 }, 'i'); at(6650, { sq: 0.16 }, 'o'); at(6800, { sq: 0, curl: 0.3 });
    at(7000, { sq: -0.04, lift: 2.5, armL: 115, armR: 170, htilt: 4, turn: 0.2 }, 'o'); at(7250, { sq: 0.08, lift: 0, armL: 170, armR: 115, htilt: -4, turn: -0.2 }); at(7450, { sq: 0, armL: 75, armR: 75, htilt: 0, turn: 0, curl: 0.9 });
    at(7500, { sq: 0.15 }); at(7650, { sq: 0 }); wheel(7550, 1000, 360, 0); at(8650, { sq: 0.18 }, 'o'); at(8850, { sq: 0, armL: 20, armR: 20, curl: 0 });
    at(9100, { armR: 165, armL: -35, tilt: 6, lean: 1.5, htilt: 4, turn: 0.2, x: 2, sq: 0.06, footL: 2.5, footR: 0, lift: 0 }); at(9300, { sq: -0.03, lift: 1.5 }, 'o');
    at(9550, { armL: 165, armR: -35, tilt: -6, lean: -1.5, htilt: -4, turn: -0.2, x: -2, sq: 0.06, footL: 0, footR: 2.5, lift: 0 }); at(9750, { sq: -0.03, lift: 1.5 }, 'o');
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@twinkle': { loop: LP, k: K, ev: [[0, 'emit', 'note', 'head'], [2000, 'emit', 'note', 'head'], [4150, 'emit', 'spark', 'body', 5], [5250, 'emit', 'spark', 'body', 5], [6650, 'emit', 'spark', 'head', 8], [8550, 'emit', 'spark', 'body', 5], [9000, 'emit', 'note', 'head']] } }); }
  // Zappi's own dance, "Static Shock": charge up, ZAP jump, robot pop-lock, electrified shimmy, tesla spin, lightning-bolt freeze (9.6 s loop)
  function zpDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@zappi']) return;
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.45]], zap: [[0, 0]] }, cur = {}, LP = 9600, ev = [];
    const at = (t, v, ez) => { for (const p in v) { (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); cur[p] = v[p]; } };
    const snap = (t, v) => { for (const p in v) { (K[p] || (K[p] = [[0, 0]])).push([t, cur[p] == null ? 0 : cur[p], 'l'], [t + 70, v[p], 'o']); cur[p] = v[p]; } };
    const sp = (t, w, n) => ev.push([t, 'emit', 'spark', w, n]);
    for (let i = 0; i < 16; i++) { const o = i % 2 ? 1 : -1; at(100 + i * 100, { footL: o > 0 ? 2 : 0, footR: o > 0 ? 0 : 2, sq: 0.03 + i * 0.012, earL: o * (2 + i * 0.5), earR: -o * (2 + i * 0.5), armL: -25, armR: -25, curl: 0.4, zap: Math.min(0.6, i * 0.045), x: o * 0.7, htilt: o * 2 }, 'l'); }
    at(1650, { footL: 0, footR: 0, x: 0, htilt: 0, earL: 0, earR: 0, sq: 0.24 });
    at(1900, { sq: -0.18, lift: 15, armL: 170, armR: 170, earL: 14, earR: 14, zap: 1, wide: 1, open: 0.85, curl: 1.2 }, 'o'); sp(1750, 'head', 10); sp(1800, 'body', 6);
    at(2200, { lift: 0, sq: 0.2, armL: 60, armR: 60, wide: 0.3, open: 0.45, earL: 0, earR: 0, curl: 0.3 }, 'i'); at(2400, { sq: 0, zap: 0.35 });
    const PO = [{ armL: 75, armR: -10, turn: -0.3, htilt: -6, tilt: 0, x: 0, sq: 0.04, earL: 8, earR: -3 }, { armL: 75, armR: 75, turn: 0, htilt: 0, sq: 0, earL: 0, earR: 0 }, { armL: -10, armR: 75, turn: 0.3, htilt: 6, sq: 0.04, earL: -3, earR: 8 },
      { armL: 165, armR: -40, turn: 0, htilt: -4, tilt: -8, sq: 0, earL: 10, earR: 2 }, { armL: -40, armR: 165, htilt: 4, tilt: 8, earL: 2, earR: 10 }, { armL: 45, armR: 45, tilt: 0, turn: -0.35, x: -4, htilt: 0, earL: 6, earR: 6 },
      { turn: 0.35, x: 4, earL: -2, earR: -2 }, { armL: 120, armR: 120, turn: 0, x: 0, sq: 0.1, earL: 12, earR: 12 }];
    PO.forEach((v, j) => { const t = 2450 + j * 300; snap(t, v); at(t + 70, { zap: 0.95 }, 'o'); at(t + 270, { zap: 0.3 }); sp(t + 40, v.armR > v.armL ? 'pawR' : 'pawL', 3); });
    at(4900, { armL: 65, armR: 65, curl: 0.6, sq: 0.06, zap: 1, wide: 0.6, open: 0.7, earL: 0, earR: 0 }, 'o');
    for (let i = 0; i < 25; i++) { const o = i % 2 ? 1 : -1; at(4950 + i * 45, { x: o * 1.6, tilt: o * 3, earL: o > 0 ? 10 : -2, earR: o > 0 ? -2 : 10, armL: 65 + o * 14, armR: 65 - o * 14, htilt: o * 2 }, 'l'); }
    [4950, 5250, 5550, 5850].forEach(t => sp(t, 'body', 4));
    at(6150, { x: 0, tilt: 0, earL: 0, earR: 0, htilt: 0, armL: 30, armR: 30, sq: 0.18, zap: 0.5, wide: 0, open: 0.45, curl: 0 });
    at(6300, { spin: 0 }, 'l'); at(6500, { lift: 12, sq: -0.12, armL: 150, armR: 150, zap: 1, curl: 1, earL: 12, earR: 12 }, 'o'); at(7050, { lift: 0 }, 'i'); at(7100, { spin: 360 }); at(7101, { spin: 0 }, 'l');
    at(7250, { sq: 0.18, armL: 40, armR: 40, curl: 0.2, earL: 0, earR: 0 }, 'o'); at(7400, { sq: 0, zap: 0.4 }); sp(6600, 'body', 6); sp(7100, 'body', 8);
    snap(7450, { armL: 150, armR: -50, tilt: -10, lean: -2, htilt: 8, footR: 3, footL: 0, turn: -0.2, earL: 14, earR: -4 }); sp(7480, 'pawL', 6);
    [[7520, 1], [7750, 0.4], [7850, 1], [8080, 0.4]].forEach(([t, v]) => at(t, { zap: v }, 'o'));
    snap(8150, { armL: -50, armR: 150, tilt: 10, lean: 2, htilt: -8, footR: 0, footL: 3, turn: 0.2, earL: -4, earR: 14 }); sp(8180, 'pawR', 6);
    [[8220, 1], [8450, 0.4], [8550, 1], [8750, 0.3]].forEach(([t, v]) => at(t, { zap: v }, 'o'));
    at(9050, { armL: 0, armR: 0, tilt: 0, lean: 0, htilt: 0, footL: 0, footR: 0, turn: 0, earL: 0, earR: 0, sq: 0.06, zap: 0 }); at(9350, { sq: -0.02 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@zappi': { loop: LP, k: K, ev } }); }
  // Plip's own dance, "Drip Drop": two drips that plop and splash, rain shake-off, ocean-wave arms, cannonball splash with a spin, swim strokes (10 s loop)
  function plDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@plip']) return;
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.45]] }, LP = 10000, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    for (let d = 0; d < 2; d++) { const t0 = d * 1200;
      at(t0 + 150, { sq: 0.1, armL: -15, armR: -15, lift: 0 });
      at(t0 + 450, { sq: -0.22, lift: 7, armL: 160, armR: 160, wide: 0.4, open: 0.6 }, 'o');
      at(t0 + 700, { sq: 0.32, lift: 0, armL: 35, armR: 35, wide: 0, open: 0.45 }, 'i');
      at(t0 + 900, { sq: -0.08 }); at(t0 + 1100, { sq: 0.02 });
      em(t0 + 690, 'gush', [14, 93], 2); em(t0 + 690, 'gush', [86, 93], 2); }
    at(2550, { sq: 0.05, armL: 155, armR: 155, sqz: 0.9 });
    for (let i = 0; i < 16; i++) { const o = i % 2 ? 1 : -1, t = 2600 + i * 100;
      at(t, { x: o * 2.2, tilt: o * 5, armL: 155 + o * 12, armR: 155 - o * 12, sq: 0.04 + (i % 4 ? 0 : 0.05), footL: o > 0 ? 1.5 : 0, footR: o > 0 ? 0 : 1.5, htilt: o * 2 }, 'l');
      if (i % 2 === 0) em(t, 'gush', o > 0 ? 'pawR' : 'pawL', 1); }
    at(4250, { x: 0, tilt: 0, htilt: 0, footL: 0, footR: 0, armL: 40, armR: 40, sq: 0.05, sqz: 0 });
    for (let b = 0; b < 4; b++) { const d = b % 2 ? 1 : -1, t = 4500 + b * 500;
      at(t, { armL: d < 0 ? 165 : 10, armR: d > 0 ? 165 : 10, lean: d * 2, tilt: d * 6, x: d * 3, sq: 0.08, lift: 0, turn: d * 0.25, footL: d > 0 ? 2.5 : 0, footR: d < 0 ? 2.5 : 0 });
      at(t + 250, { armL: 90, armR: 90, sq: -0.06, lift: 3, tilt: 0 }, 'o'); em(t + 60, 'gush', d < 0 ? 'pawL' : 'pawR', 1); }
    at(6450, { armL: 30, armR: 30, lean: 0, x: 0, turn: 0, footL: 0, footR: 0, lift: 0, sq: 0, tilt: 0 });
    at(6680, { sq: 0.28, armL: -40, armR: -40, wide: 0.5, open: 0.3 }); at(6720, { spin: 0 }, 'l');
    at(7000, { sq: -0.2, lift: 18, armL: 170, armR: 170, wide: 0.8, open: 0.85 }, 'o'); at(7450, { lift: 0 }, 'i'); at(7500, { spin: 360 }); at(7501, { spin: 0 }, 'l');
    at(7520, { sq: 0.38, armL: 60, armR: 60, wide: 0, open: 0.45 }, 'o'); at(7750, { sq: -0.1 }); at(7950, { sq: 0.04 }); at(8150, { sq: 0 });
    em(7450, 'gush', [12, 93], 4); em(7450, 'gush', [88, 93], 4); em(7480, 'gush', [8, 92], 2); em(7480, 'gush', [92, 92], 2);
    for (let i = 0; i < 4; i++) { const d = i % 2 ? 1 : -1, t = 8300 + i * 320;
      at(t, { armL: d < 0 ? 175 : -30, armR: d > 0 ? 175 : -30, turn: d * 0.3, lean: -d * 1.2, tilt: -d * 3, sq: 0.04, open: 0.7 });
      at(t + 160, { sq: -0.02, open: 0.4 }); em(t + 120, 'bubble', 'mouth', 1); }
    at(9600, { armL: 0, armR: 0, turn: 0, lean: 0, tilt: 0, sq: 0, open: 0.45 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@plip': { loop: LP, k: K, ev } }); }
  // Breeze's own dance, "Gust Slide": glides on the wind, big breath and whoosh both ways, twister spin, kite flight, soft cloud landing, streamer arms (10 s loop)
  function bzDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@breeze']) return;
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.45]], mw: [[0, 1]] }, LP = 10000, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    for (let b = 0; b < 4; b++) { const d = b % 2 ? 1 : -1, t = b * 500;
      at(t + 250, { x: d * 7, tilt: d * 8, lean: d * 2, lift: 5, sq: -0.04, armL: d < 0 ? 125 : 70, armR: d > 0 ? 125 : 70, turn: d * 0.2, htilt: -d * 3 });
      at(t + 450, { lift: 2.5, sq: 0.04 }, 'o'); em(t + 180, 'gust', d < 0 ? 'sideR' : 'sideL', 1); }
    at(2000, { x: 0, tilt: 0, lean: 0, turn: 0, htilt: 0, lift: 1, sq: 0, armL: 40, armR: 40 });
    [[2150, -1], [2900, 1]].forEach(([t, d]) => {
      at(t + 250, { puff: 1, sq: -0.12, lift: 3, armL: 60, armR: 60, wide: 0.5, mw: 0.8, turn: 0, x: 0, lean: 0, tilt: 0 });
      at(t + 400, { puff: -0.3, mw: 0.55, wide: 0, turn: d * 0.35, x: -d * 6, lean: -d * 2.5, tilt: -d * 5, sq: 0.08, lift: 0, armL: d < 0 ? 150 : 20, armR: d > 0 ? 150 : 20 }, 'o');
      for (let i = 0; i < 4; i++) em(t + 400 + i * 80, 'gust', d < 0 ? 'sideL' : 'sideR', 1);
      at(t + 700, { puff: 0, mw: 1, sq: 0, x: -d * 2, lean: 0, tilt: 0 }); });
    at(3750, { turn: 0, x: 0, sq: 0.05, armL: 40, armR: 40 });
    at(3900, { sq: 0.2, armL: -20, armR: -20, lift: 0 }); at(3950, { spin: 0 }, 'l');
    at(4400, { lift: 10, sq: -0.1, armL: 150, armR: 150, wide: 0.5 }, 'o'); at(5000, { lift: 8 }); at(5300, { lift: 0 }, 'i'); at(5350, { spin: 720 }); at(5351, { spin: 0 }, 'l');
    at(5500, { sq: 0.22, armL: 50, armR: 50, wide: 0 }, 'o'); at(5700, { sq: 0 });
    [4100, 4400, 4700, 5000].forEach(t => { em(t, 'gust', 'sideL', 1); em(t + 60, 'gust', 'sideR', 1); });
    at(6000, { lift: 12, sq: -0.05, armL: 110, armR: 110 });
    for (let i = 0; i < 4; i++) { const d = i % 2 ? 1 : -1; at(6250 + i * 400, { tilt: d * 12, x: d * 5, lean: d * 1.5, htilt: -d * 4, lift: 12 + (i % 2) * 2, armL: d < 0 ? 145 : 95, armR: d > 0 ? 145 : 95, turn: d * 0.15 }); }
    at(7750, { tilt: 0, x: 0, lean: 0, htilt: 0, turn: 0, lift: 11, armL: 100, armR: 100 });
    at(8150, { lift: 0, sq: 0.28, puff: 0.6, armL: 30, armR: 30, wide: 0.4 }); at(8350, { sq: -0.08, puff: 0, wide: 0 }, 'o'); at(8500, { sq: 0.03 }); at(8650, { sq: 0 });
    em(8150, 'gust', 'sideL', 2); em(8150, 'gust', 'sideR', 2);
    for (let i = 0; i < 3; i++) { const t = 8700 + i * 400; at(t, { armL: 165, armR: 110, htilt: 4, tilt: 3, x: 1.5, sq: 0.04 }); at(t + 200, { armL: 110, armR: 165, htilt: -4, tilt: -3, x: -1.5, sq: -0.02 }); }
    at(9850, { armL: 0, armR: 0, htilt: 0, tilt: 0, x: 0, sq: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@breeze': { loop: LP, k: K, ev } }); }
  // Dusty's own dance, "Moth Twist": fluttering hover hops, the twist, a spiral up toward the light, a leaf-drift down, antenna shimmy, powder poof, superhero flight across the stage (13.5 s loop)
  function duDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@dusty']) return;
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.45]] }, LP = 13500, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    for (let h = 0; h < 4; h++) { const t = h * 500, d = h % 2 ? 1 : -1;
      at(t + 120, { sq: 0.12, lift: 0, flap: 0.6, earL: -4, earR: -4, armL: 30, armR: 30 });
      at(t + 300, { sq: -0.08, lift: 7, flap: 1, earL: d * 8, earR: -d * 8, armL: 110, armR: 110, htilt: d * 4, x: d * 2 }, 'o');
      at(t + 480, { lift: 2, sq: 0.02 }, 'i'); em(t + 300, 'dust', 'wingL', 2); em(t + 300, 'dust', 'wingR', 2); }
    at(2050, { lift: 0, sq: 0.06, flap: 0.3, earL: 0, earR: 0, htilt: 0, x: 0, armL: 60, armR: 60 });
    for (let i = 0; i < 8; i++) { const d = i % 2 ? 1 : -1, t = 2150 + i * 230;
      at(t, { turn: d * 0.42, tilt: -d * 6, lean: -d * 1.5, sq: 0.1, lift: 0, armL: d < 0 ? 95 : 45, armR: d > 0 ? 95 : 45, footL: d < 0 ? 3 : 0, footR: d > 0 ? 3 : 0, earL: d * 6, earR: d * 6, flap: 0.4 });
      at(t + 115, { sq: 0.02 }, 'o'); }
    at(4050, { turn: 0, tilt: 0, lean: 0, footL: 0, footR: 0, earL: 0, earR: 0, sq: 0.18, armL: 20, armR: 20 });
    at(4250, { spin: 0 }, 'l'); at(4300, { pitch: -0.25, ly: -0.8, flap: 1, wide: 0.5, armL: 165, armR: 165, earL: 12, earR: 12, sq: -0.1 }, 'o');
    at(5500, { lift: 15, spin: 360 }); at(5501, { spin: 0 }, 'l'); [4500, 4800, 5100, 5400].forEach(t => { em(t, 'dust', 'wingL', 2); em(t + 80, 'dust', 'wingR', 2); });
    for (let i = 0; i < 3; i++) { const d = i % 2 ? 1 : -1, t = 5800 + i * 260; at(t, { tilt: d * 11, x: d * 5, lift: 15 - (i + 1) * 4.5, flap: 0.15, pitch: 0, ly: 0, armL: d < 0 ? 140 : 80, armR: d > 0 ? 140 : 80, earL: -d * 5, earR: d * 5 }); }
    at(6650, { lift: 0, tilt: 0, x: 0, sq: 0.24, wide: 0, armL: 40, armR: 40, earL: 0, earR: 0 }, 'i'); at(6850, { sq: -0.04 }, 'o'); at(7000, { sq: 0.02 });
    for (let i = 0; i < 12; i++) { const o = i % 2 ? 1 : -1; at(7050 + i * 100, { x: o * 1.4, earL: o > 0 ? 14 : -4, earR: o > 0 ? -4 : 14, armL: 60 + o * 12, armR: 60 - o * 12, htilt: o * 3, flap: i % 4 < 2 ? 0.9 : 0.3, sq: 0.03 }, 'l'); }
    at(8300, { x: 0, earL: 0, earR: 0, htilt: 0, armL: 0, armR: 0, sq: 0.26, flap: 0.3 });
    at(8550, { sq: -0.14, lift: 8, armL: 125, armR: 125, flap: 1, wide: 0.6, open: 0.8, earL: 12, earR: 12 }, 'o'); em(8550, 'dust', 'wingL', 6); em(8550, 'dust', 'wingR', 6); em(8580, 'dust', 'body', 5);
    at(8900, { lift: 0, sq: 0.16, armL: 40, armR: 40, wide: 0, open: 0.45, earL: 0, earR: 0 }, 'i'); at(9100, { sq: -0.03, htilt: 6, flap: 0.2 }, 'o'); at(9800, { sq: 0, htilt: 0, armL: 0, armR: 0, flap: 0 });
    // superhero flight: launch, fly across to the right, bank round, fly to the left, swoop back and land
    const HC = 30, fp = (t, Xc, Lc, a, v, ez) => { const r = a * Math.PI / 180; at(t, Object.assign({ tilt: a, x: Xc - HC * Math.sin(r), lift: Lc + HC * (1 - Math.cos(r)) }, v), ez); };
    at(10050, { sq: 0.22, armL: -20, armR: -20, flap: 0.4, wide: 0 }); fp(10300, 0, 12, 0, { sq: -0.12, flap: 1, armL: 150, armR: 150, wide: 0.5 }, 'o');
    fp(10650, 2, 14, 62, { armR: 178, armL: -15, turn: 0.28, sq: -0.04, footL: 3, footR: 1.5 }); fp(11300, 19, 15, 66, { footL: 1.5, footR: 3 });
    fp(11550, 21, 18, 0, { turn: 0, armL: 120, armR: 120 }); fp(11800, 19, 15, -62, { armL: 178, armR: -15, turn: -0.28, footL: 1.5, footR: 3 }); fp(12400, -19, 14, -66, { footL: 3, footR: 1.5 });
    fp(12650, -10, 9, -20, { turn: -0.1, armL: 110, armR: 90 }); fp(12900, 0, 0, 0, { turn: 0, armL: 40, armR: 40, sq: 0.24, footL: 0, footR: 0, flap: 0.3, wide: 0 }, 'i');
    at(13100, { sq: -0.05 }, 'o'); at(13350, { sq: 0, armL: 0, armR: 0, flap: 0 });
    for (let t = 10700; t <= 12500; t += 150) em(t, 'dust', 'body', 2); em(10300, 'dust', 'wingL', 4); em(10300, 'dust', 'wingR', 4); em(12900, 'dust', 'wingL', 3); em(12900, 'dust', 'wingR', 3);
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@dusty': { loop: LP, k: K, ev } }); }
  // Bubbly's own dance, "Bubble Bath Boogie": jelly bounces, bubble blowing, a rubber-duck parade, floaty bubble spin, wobble drop, bath-time bob with the ducks (10 s loop)
  function bbDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@bubbly']) return;
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.45]] }, LP = 10000, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    for (let b = 0; b < 4; b++) { const t = b * 500, d = b % 2 ? 1 : -1;
      at(t + 120, { sq: 0.2, lift: 0, x: d * 2, tilt: d * 4 }); at(t + 300, { sq: -0.12, lift: 8, tilt: -d * 3 }, 'o'); at(t + 470, { lift: 0, sq: 0.16 }, 'i'); em(t + 470, 'bubble', 'belly', 2); }
    at(2050, { sq: 0, x: 0, tilt: 0, lift: 0 });
    at(2350, { puff: 1, sq: -0.06, wide: 0.4, pitch: -0.1 }); at(2500, { puff: -0.2, sq: 0.06, wide: 0, open: 0.7 }, 'o'); at(2800, { puff: 1, sq: -0.06 }); at(2950, { puff: -0.2, sq: 0.06, open: 0.7 }, 'o'); at(3200, { puff: 0, sq: 0, pitch: 0, open: 0.45 });
    [2520, 2620, 2970, 3070].forEach((t, i) => em(t, i % 2 ? 'bigbubble' : 'bubble', 'mouth', 2));
    em(3250, 'duck', [22, 84], 1); em(3400, 'duck', [78, 84], 1); em(4250, 'duck', [27, 84], 1); em(4350, 'duck', [73, 84], 1);
    for (let i = 0; i < 8; i++) { const d = i % 2 ? 1 : -1, t = 3300 + i * 250; at(t, { tilt: d * 10, x: d * 4, turn: d * 0.25, sq: 0.1, lift: 0, htilt: d * 3 }); at(t + 125, { sq: -0.05, lift: 4 }, 'o'); }
    at(5350, { tilt: 0, x: 0, turn: 0, htilt: 0, sq: 0.18, lift: 0 }); at(5400, { spin: 0 }, 'l');
    at(5900, { lift: 14, sq: -0.08, wide: 0.5 }, 'o'); at(6700, { spin: 360, lift: 16 }); at(6701, { spin: 0 }, 'l'); [5600, 6000, 6400].forEach(t => em(t, 'spark', 'body', 3));
    for (let i = 0; i < 6; i++) { const o = i % 2 ? 1 : -1; at(6800 + i * 60, { sq: o * 0.08, x: o * 1 }, 'l'); }
    at(7250, { sq: 0, x: 0, wide: 0.8, open: 0.75 }); at(7550, { lift: 0, wide: 0.2, open: 0.45 }, 'i'); at(7650, { sq: 0.34 }, 'o');
    [[7800, -0.16], [7950, 0.12], [8100, -0.07], [8250, 0.03]].forEach(([t, v]) => at(t, { sq: v })); em(7600, 'bubble', 'sideL', 3); em(7600, 'bubble', 'sideR', 3); em(7620, 'bigbubble', 'body', 2);
    em(8300, 'duck', [24, 84], 1); em(8400, 'duck', [76, 84], 1);
    for (let i = 0; i < 4; i++) { const d = i % 2 ? 1 : -1, t = 8450 + i * 330; at(t, { tilt: d * 8, lift: 3 + (i % 2) * 2, x: d * 1.5, htilt: -d * 2, sq: 0.03 }); }
    at(9850, { tilt: 0, lift: 0, x: 0, htilt: 0, sq: 0, wide: 0 }); em(9400, 'bubble', 'head', 2);
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@bubbly': { loop: LP, k: K, ev } }); }
  // Mallow's own dance, "Toasty Twirl": jelly bounces, roasting-stick spin with steam, puffs up tall then melts into a gooey sway, pillow hops side to side, s'more squish finale (10 s loop)
  function mlDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@mallow']) return;
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.45]] }, LP = 10000, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    for (let b = 0; b < 4; b++) { const t = b * 500, d = b % 2 ? 1 : -1;
      at(t + 100, { sq: 0.24, lift: 0, armL: 25, armR: 25, tilt: d * 3, htilt: 0 }, 'i'); at(t + 260, { sq: -0.14, lift: 9, armL: 120, armR: 120, tilt: -d * 2, htilt: d * 5 }, 'o'); at(t + 420, { lift: 0, sq: 0.18 }, 'i'); at(t + 480, { sq: -0.04 }, 'o'); }
    at(2050, { sq: 0, tilt: 0, htilt: 0, armL: 160, armR: 160, lift: 2 }); at(2100, { spin: 0 }, 'l'); at(2950, { lift: 5, sq: -0.06 }); at(3800, { spin: 360, lift: 1, sq: 0.04 }); at(3801, { spin: 0 }, 'l');
    [2300, 2700, 3100, 3500].forEach(t => em(t, 'steam', 'head', 2));
    at(4100, { armL: 60, armR: 60, sq: 0.1, lift: 0 }); at(4500, { sq: -0.22, wide: 0.7, open: 0.7, armL: 110, armR: 110, puff: 0.6, pitch: -0.1 }, 'o'); at(4700, { sq: -0.2 }); em(4500, 'spark', 'head', 3);
    at(5050, { sq: 0.32, wide: 0, open: 0.45, puff: 0, pitch: 0.08, armL: 12, armR: 12, lean: -4, tilt: -3 }); at(5450, { lean: 4, tilt: 3, sq: 0.28, armL: 30, armR: 8 }); at(5850, { lean: -3, tilt: -2, sq: 0.3, armL: 8, armR: 30 }); at(6100, { lean: 0, tilt: 0, sq: 0.05, pitch: 0, armL: 35, armR: 35 }, 'o');
    for (let i = 0; i < 4; i++) { const d = i % 2 ? 1 : -1, t = 6200 + i * 450; at(t, { sq: 0.18, lift: 0 }, 'i'); at(t + 200, { lift: 10, sq: -0.1, x: d * 5, turn: d * 0.75, tilt: d * 6, armL: d < 0 ? 150 : 45, armR: d > 0 ? 150 : 45, footL: d < 0 ? 4 : 1, footR: d > 0 ? 4 : 1 }, 'o'); at(t + 400, { lift: 0, sq: 0.2, x: d * 9, footL: 0, footR: 0 }, 'i'); em(t + 400, 'dust', d < 0 ? 'footL' : 'footR', 2); }
    at(8100, { x: 0, turn: 0, tilt: 0, sq: 0.05 });
    at(8250, { sq: 0.24, armL: 30, armR: 30 }, 'i'); at(8580, { lift: 18, sq: -0.16, armL: 170, armR: 170, wide: 0.5, open: 0.75 }, 'o'); at(8820, { lift: 0, sq: 0.45, armL: 75, armR: 75, wide: 0 }, 'i');
    [[8960, -0.14], [9110, 0.22], [9260, -0.08], [9410, 0.1], [9560, -0.03]].forEach(([t, v]) => at(t, { sq: v })); em(8820, 'dust', 'footL', 4); em(8820, 'dust', 'footR', 4); em(8860, 'heart', 'head', 2); em(8860, 'spark', 'body', 3);
    at(9750, { sq: 0, armL: 0, armR: 0, open: 0.45 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@mallow': { loop: LP, k: K, ev } }); }
  // Bao's own dance, "Steamer Shuffle": rises like dough, steamer-basket bounce with steam, a dumpling pinch-and-twist (knot spins), chopstick-dodge side hops, a soy-dip dunk and a fluffy proud pose (10 s loop)
  function bzBao() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@bao']) return;
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.45]] }, LP = 10000, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    at(200, { sq: 0.3, armL: 10, armR: 10, wide: 0 }, 'i'); at(900, { sq: -0.2, puff: 0.6, armL: 90, armR: 90, wide: 0.5, open: 0.7, lift: 2 }, 'o'); at(1150, { sq: -0.16 }); [600, 850, 1100].forEach(t => em(t, 'steam', 'head', 2));
    for (let b = 0; b < 4; b++) { const t = 1300 + b * 380, d = b % 2 ? 1 : -1;
      at(t, { sq: 0.22, lift: 0, puff: 0, wide: 0, open: 0.45, armL: 35, armR: 35, htilt: 0 }, 'i'); at(t + 190, { sq: -0.1, lift: 7, tilt: d * 4, htilt: d * 5, armL: d < 0 ? 140 : 60, armR: d > 0 ? 140 : 60 }, 'o'); em(t + 190, 'steam', 'head', 1); }
    at(2900, { sq: 0.12, lift: 0, tilt: 0, htilt: 0, armL: 120, armR: 120 }); at(2950, { spin: 0 }, 'l');
    at(3350, { spin: -50, sq: 0.08, tilt: -4, armL: 150, armR: 100 }); at(3700, { spin: 40, tilt: 4, armL: 100, armR: 150 }); at(4050, { spin: -30, tilt: -3, armL: 150, armR: 100 });
    at(4800, { spin: 360, sq: -0.06, lift: 4, tilt: 0, armL: 170, armR: 170, wide: 0.4 }); at(4801, { spin: 0 }, 'l'); em(4500, 'spark', 'head', 3); at(5000, { lift: 0, sq: 0.18, wide: 0 }, 'i');
    for (let i = 0; i < 4; i++) { const d = i % 2 ? 1 : -1, t = 5200 + i * 400;
      at(t, { sq: 0.2, lift: 0, lx: -d * 0.9, wide: 0.6 }, 'i'); at(t + 180, { lift: 9, sq: -0.1, x: d * 8, turn: d * 0.55, lean: d * 3, armL: d > 0 ? 160 : 30, armR: d < 0 ? 160 : 30, footL: d > 0 ? 4 : 1, footR: d < 0 ? 4 : 1 }, 'o'); at(t + 360, { lift: 0, sq: 0.16, footL: 0, footR: 0 }, 'i'); em(t + 360, 'dust', d < 0 ? 'footL' : 'footR', 2); }
    at(6900, { x: 0, turn: 0, lean: 0, lx: 0, wide: 0, sq: 0.05, armL: 40, armR: 40 });
    at(7200, { pitch: 0.4, tilt: 14, x: 4, sq: 0.15, armL: 20, armR: 150 }); at(7550, { lift: -2, sq: 0.32, tilt: 22, open: 0.2, close: 0.6 }, 'i'); em(7550, 'drop', [64, 88], 4);
    at(7900, { pitch: 0, tilt: 0, x: 0, lift: 6, sq: -0.12, close: 0, open: 0.7, armL: 60, armR: 60 }, 'o'); [[8050, 0.12], [8200, -0.06], [8350, 0.03]].forEach(([t, v]) => at(t, { sq: v, lift: 0 }));
    at(8700, { puff: 1, sq: -0.12, wide: 0.5, armL: 175, armR: 175, open: 0.75, lift: 3 }, 'o'); em(8700, 'steam', 'head', 3); em(8750, 'heart', 'head', 1); at(9300, { puff: 0.7, sq: -0.08, htilt: 6 }); at(9500, { htilt: -6 });
    at(9800, { puff: 0, sq: 0, wide: 0, armL: 0, armR: 0, open: 0.45, lift: 0, htilt: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@bao': { loop: LP, k: K, ev } }); }
  // Dunkie's own dance, "Sprinkle Roll": sprinkle shimmy, rolls like a wheel there and back, dunks in coffee and shakes off, hula-hoop spin, glaze-drip splat finale with a wink (10 s loop)
  function dkDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@dunkie']) return;
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.45]] }, LP = 10000, ev = [], HC = 43;
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    for (let i = 0; i < 6; i++) { const d = i % 2 ? 1 : -1, t = 150 + i * 260; at(t, { tilt: d * 7, x: d * 2.5, htilt: d * 4, sq: 0.06, armL: d < 0 ? 130 : 50, armR: d > 0 ? 130 : 50 }); em(t, 'sprinkle', 'head', 3); }
    at(1750, { tilt: 0, x: 0, htilt: 0, sq: 0.15, armL: 25, armR: 25 });
    const wheel = (t0, dur, from, to, x0, x1) => { for (let s = 0; s <= 24; s++) { const u = s / 24, e = u * u * (3 - 2 * u), a = from + (to - from) * e, th = a * Math.PI / 180; at(t0 + dur * u, { tilt: a, x: x0 + (x1 - x0) * e - HC * Math.sin(th), lift: HC * (1 - Math.cos(th)) + 3 * Math.sin(Math.PI * u), sq: 0 }, 'l'); } };
    const trail = (t0, dur, x0, x1) => { for (let s = 1; s < 8; s++) { const u = s / 8, e = u * u * (3 - 2 * u); em(t0 + dur * u, 'dust', [50 + x0 + (x1 - x0) * e, 94], 2); } };
    wheel(1900, 950, 0, 360, 0, 30); at(2851, { tilt: 0 }, 'l'); trail(1900, 950, 0, 30); at(2950, { sq: 0.16 }, 'o');
    wheel(3000, 1150, 0, -360, 30, -30); at(4151, { tilt: 0 }, 'l'); trail(3000, 1150, 30, -30);
    at(4230, { sq: 0.2, armL: 40, armR: 40 }, 'i'); at(4390, { x: -15, lift: 9, sq: -0.1 }, 'o'); at(4540, { x: 0, lift: 0, sq: 0.14 }, 'i'); em(4540, 'dust', 'footL', 2); em(4540, 'dust', 'footR', 2);
    at(4550, { sq: 0.02, pitch: 0.25 }); at(4850, { sq: 0.42, close: 0.7, open: 0.2, armL: 150, armR: 150 }, 'i'); em(4850, 'coffee', 'footL', 5); em(4850, 'coffee', 'footR', 5);
    at(5150, { lift: 12, sq: -0.15, close: 0, open: 0.7, pitch: 0, wide: 0.4 }, 'o'); at(5350, { lift: 0, sq: 0.12, wide: 0 }, 'i');
    for (let i = 0; i < 5; i++) { const d = i % 2 ? 1 : -1, t = 5450 + i * 90; at(t, { tilt: d * 9, x: d * 1.2, htilt: -d * 4 }, 'l'); em(t, 'coffee', d < 0 ? 'sideL' : 'sideR', 2); }
    at(5950, { tilt: 0, x: 0, htilt: 0, sq: 0, armL: 175, armR: 175 }); at(6000, { spin: 0 }, 'l');
    at(6800, { spin: 360, lift: 3, x: 3 }); at(7600, { spin: 720, lift: 2, x: -3 }); at(7601, { spin: 0 }, 'l'); [6200, 6700, 7200].forEach(t => em(t, 'sprinkle', 'head', 4));
    at(7800, { x: 0, lift: 0, sq: 0.25, armL: 30, armR: 30 }, 'i'); at(8150, { lift: 17, sq: -0.15, armL: 170, armR: 170, wide: 0.5, open: 0.75 }, 'o');
    at(8450, { lift: 0, sq: 0.42, armL: 70, armR: 70, wide: 0 }, 'i'); em(8450, 'sprinkle', 'head', 8); em(8450, 'dust', 'footL', 3); em(8450, 'dust', 'footR', 3);
    [[8600, -0.14], [8750, 0.2], [8900, -0.07], [9050, 0.08], [9200, 0]].forEach(([t, v]) => at(t, { sq: v }));
    at(9250, { htilt: 6, tilt: 3, armR: 150, armL: 40, winkR: 0 }); at(9400, { winkR: 1 }); at(9650, { winkR: 0 }); em(9400, 'heart', 'head', 1);
    at(9850, { htilt: 0, tilt: 0, armL: 0, armR: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@dunkie': { loop: LP, k: K, ev } }); }
  // Frybo's own dance, "Fry Shuffle": salt-shaker shimmy, fry fan bounces, ketchup dip and splash, shuffle steps, flip-the-box spin, jazz-hands finish (10 s loop)
  function fyDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@frybo']) return;
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.5]], fw: [[0, 0]] }, LP = 10000, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    for (let i = 0; i < 8; i++) { const d = i % 2 ? 1 : -1, t = 120 + i * 220; at(t, { x: d * 2.5, tilt: d * 6, armL: 150 + d * 15, armR: 150 - d * 15, fw: 1, sq: 0.05, earL: 6, earR: 6, htilt: -d * 3 }); if (i % 2 === 0) em(t + 60, 'salt', [44 + d * 8, 12], 3); }
    at(1950, { x: 0, tilt: 0, htilt: 0, fw: 0, armL: 40, armR: 40, earL: 0, earR: 0, sq: 0 });
    for (let b = 0; b < 3; b++) { const t = 2050 + b * 500;
      at(t + 120, { sq: 0.24, lift: 0, earL: -4, earR: -4, armL: 20, armR: 20 }, 'i'); at(t + 320, { sq: -0.14, lift: 9, earL: 22, earR: 22, armL: 120, armR: 120, wide: 0.5, open: 0.75 }, 'o'); at(t + 480, { lift: 1, sq: 0.06, wide: 0, open: 0.5 }, 'i'); em(t + 320, 'salt', [50, 8], 3); }
    at(3600, { sq: 0, earL: 0, earR: 0, lift: 0, armL: 30, armR: 30 });
    at(3950, { tilt: -16, x: -5, lean: -3, pitch: 0.2, sq: 0.18, armL: -20, armR: 150, htilt: -4, close: 0.5, open: 0.25 });
    at(4300, { tilt: -20, x: -6, sq: 0.28 }, 'i'); em(4250, 'ketchup', [24, 88], 3); em(4300, 'ketchup', [30, 90], 2);
    at(4600, { tilt: 6, x: 2, lean: 1, pitch: -0.1, lift: 10, sq: -0.14, armL: 160, armR: 160, close: 0, open: 0.8, wide: 0.5, earL: 18, earR: 18 }, 'o');
    at(4900, { tilt: 0, x: 0, lean: 0, pitch: 0, lift: 0, sq: 0.18, wide: 0, open: 0.5, earL: 0, earR: 0, htilt: 0 }, 'i'); at(5100, { sq: 0 });
    for (let i = 0; i < 6; i++) { const d = i % 2 ? 1 : -1, t = 5200 + i * 300;
      at(t, { x: d * 5, turn: d * 0.3, footL: d < 0 ? 3 : 0, footR: d > 0 ? 3 : 0, armL: d < 0 ? 110 : 30, armR: d > 0 ? 110 : 30, tilt: d * 4, sq: 0.08, lift: 0, earL: d < 0 ? 10 : 0, earR: d > 0 ? 10 : 0 });
      at(t + 150, { sq: -0.04, lift: 2.5 }, 'o'); em(t + 10, 'crumb', d < 0 ? 'footL' : 'footR', 1); }
    at(7000, { x: 0, turn: 0, footL: 0, footR: 0, tilt: 0, earL: 0, earR: 0, armL: 20, armR: 20, sq: 0.24, lift: 0 }, 'i'); at(7050, { spin: 0 }, 'l');
    at(7400, { lift: 16, sq: -0.16, armL: 170, armR: 170, earL: 24, earR: 24, wide: 0.6, open: 0.85, fw: 0.6 }, 'o'); at(7900, { spin: 360, lift: 15 }); at(7901, { spin: 0 }, 'l');
    [7300, 7600, 7900].forEach(t => em(t, 'salt', [50, 10], 4)); em(7500, 'spark', 'head', 3);
    at(8150, { lift: 0, sq: 0.34, armL: 60, armR: 60, earL: -6, earR: -6, wide: 0, open: 0.5, fw: 0 }, 'i'); em(8150, 'dust', 'footL', 3); em(8150, 'dust', 'footR', 3);
    [[8300, -0.12], [8450, 0.14], [8600, -0.05], [8750, 0]].forEach(([t, v]) => at(t, { sq: v, earL: v * 60, earR: v * 60 }));
    at(9000, { armL: 160, armR: 160, earL: 20, earR: 20, fw: 0.8, htilt: 5, tilt: 3, wide: 0.4, open: 0.7, winkR: 0 }); at(9200, { winkR: 1 }); at(9500, { winkR: 0 }); em(9150, 'heart', 'head', 1); em(9150, 'salt', [50, 8], 3);
    at(9850, { armL: 0, armR: 0, earL: 0, earR: 0, fw: 0, htilt: 0, tilt: 0, wide: 0, open: 0.5 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@frybo': { loop: LP, k: K, ev } }); }
  // Bunbun's own dance, "Stack Attack": bun bounces, a big jump where the layers fly apart like cards and fan out, a card shuffle, a split-stack spin, fan sway, and a stack-slam finish (10 s loop)
  function bnDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@bunbun']) return;
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.5]], split: [[0, 0]], fan: [[0, 0]], shuf: [[0, 0]] }, LP = 10000, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    for (let b = 0; b < 4; b++) { const t = b * 400, d = b % 2 ? 1 : -1; at(t + 120, { sq: 0.2, lift: 0, tilt: d * 4, armL: 30, armR: 30 }, 'i'); at(t + 280, { sq: -0.08, lift: 5, tilt: -d * 2, armL: 110, armR: 110, split: 0.12 }, 'o'); at(t + 400, { lift: 0, sq: 0.06, split: 0 }, 'i'); }
    at(1700, { sq: 0.3, tilt: 0, armL: -10, armR: -10, lift: 0, split: 0 }, 'i');
    at(2050, { sq: -0.15, lift: 5, split: 1, armL: 165, armR: 165, wide: 0.6, open: 0.8, pitch: 0.2 }, 'o'); at(2400, { lift: 5, split: 1.15, fan: 1 }); at(2700, { fan: -1, lift: 4 });
    at(2950, { lift: 0, split: 0, fan: 0, sq: 0.38, armL: 60, armR: 60, wide: 0, open: 0.5, pitch: 0 }, 'i'); em(2950, 'crumb', [30, 82], 3); em(2950, 'crumb', [70, 82], 3);
    [[3100, -0.14], [3250, 0.14], [3400, -0.05], [3550, 0]].forEach(([t, v]) => at(t, { sq: v }));
    at(3700, { split: 0.55, lift: 4, armL: 120, armR: 120 }, 'o');
    for (let i = 0; i < 6; i++) { const d = i % 2 ? 1 : -1, t = 3850 + i * 230; at(t, { shuf: d, tilt: d * 3, x: -d * 1.5, armL: d < 0 ? 150 : 90, armR: d > 0 ? 150 : 90 }); }
    at(5300, { shuf: 0, tilt: 0, x: 0, split: 0, lift: 0, sq: 0.25, armL: 20, armR: 20 }, 'i'); at(5350, { spin: 0 }, 'l');
    at(5650, { lift: 7, sq: -0.12, split: 0.9, armL: 170, armR: 170, wide: 0.5, open: 0.8 }, 'o'); at(6300, { spin: 360, lift: 6, split: 0.9 }); at(6301, { spin: 0 }, 'l');
    at(6600, { lift: 0, split: 0, sq: 0.32, wide: 0, open: 0.5, armL: 50, armR: 50 }, 'i'); em(6600, 'spark', 'head', 3);
    for (let i = 0; i < 4; i++) { const d = i % 2 ? 1 : -1, t = 6900 + i * 300; at(t, { fan: d * 0.8, split: 0.4, tilt: d * 6, lean: d * 1.5, x: d * 2, armL: d < 0 ? 140 : 40, armR: d > 0 ? 140 : 40, sq: 0.05 }); }
    at(8150, { fan: 0, tilt: 0, lean: 0, x: 0, split: 0.1, sq: 0.28, armL: 0, armR: 0 }, 'i');
    at(8450, { lift: 5, split: 1.3, sq: -0.15, armL: 175, armR: 175, wide: 0.7, open: 0.9, pitch: 0.2 }, 'o');
    at(8800, { lift: 0, split: 0, sq: 0.36, wide: 0, open: 0.5, pitch: 0, armL: 70, armR: 70 }, 'i'); em(8800, 'dust', [30, 84], 4); em(8800, 'dust', [70, 84], 4);
    [[8950, -0.16], [9100, 0.16], [9250, -0.06], [9400, 0]].forEach(([t, v]) => at(t, { sq: v }));
    at(9450, { htilt: 5, tilt: 3, armR: 150, armL: 40, winkR: 0 }); at(9600, { winkR: 1 }); at(9800, { winkR: 0 }); em(9600, 'heart', 'head', 1);
    at(9900, { htilt: 0, tilt: 0, armL: 0, armR: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@bunbun': { loop: LP, k: K, ev } }); }
  // Aurora's own dance, "Sky Swim": swims on a wave with paddling flippers, breaches into a barrel roll, blows a sparkly spout, glides past side-on, aurora twirl (10 s loop)
  function auDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@aurora']) return;
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.45]], swim: [[0, 0.5]], spout: [[0, 0]], glow: [[0, 0]] }, LP = 10000, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    for (let b = 0; b < 4; b++) { const t = b * 500, d = b % 2 ? 1 : -1;
      at(t + 250, { lift: 7, pitch: -0.18, x: d * 4, tilt: d * 5, turn: d * 0.22, armL: d < 0 ? 125 : 35, armR: d > 0 ? 125 : 35, swim: 1, sq: -0.04 });
      at(t + 500, { lift: 2, pitch: 0.14, sq: 0.05, armL: 60, armR: 60 }); }
    at(2150, { lift: 0, x: 0, tilt: 0, turn: 0, pitch: 0.3, sq: 0.22, armL: -20, armR: -20, swim: 0.6 }); at(2200, { spin: 0 }, 'l');
    at(2550, { lift: 18, pitch: -0.35, sq: -0.14, armL: 160, armR: 160, wide: 0.6, open: 0.8, swim: 1.3 }, 'o');
    at(3150, { spin: 360, lift: 16 }); at(3151, { spin: 0 }, 'l'); at(3450, { lift: 0, pitch: 0.1, wide: 0 }, 'i');
    at(3600, { sq: 0.3, armL: 70, armR: 70, open: 0.45, swim: 0.5 }, 'o'); at(3800, { sq: -0.08, pitch: 0 }); at(3950, { sq: 0.03 });
    em(2600, 'spark', 'body', 4); em(3450, 'spark', [30, 88], 4); em(3450, 'spark', [70, 88], 4); em(3480, 'dust', [50, 89], 5);
    at(4100, { puff: 1, sq: -0.08, lift: 2, armL: 40, armR: 40 });
    for (let i = 0; i < 3; i++) { const t = 4350 + i * 450; at(t, { puff: -0.2, spout: 1, sq: 0.1, lift: 0, htilt: (i - 1) * 4 }, 'o'); at(t + 300, { puff: 0.6, spout: 0.3, sq: -0.04, lift: 2 }); em(t, 'spark', 'spout', 4); em(t + 60, 'bubble', 'spout', 2); }
    at(5700, { puff: 0, spout: 0, sq: 0, lift: 0, htilt: 0 });
    at(5800, { spin: 0 }, 'l'); at(6250, { spin: 80, x: -4, swim: 1.2, armL: 50, armR: 50, lift: 3 });
    for (let i = 0; i < 3; i++) { const t = 6250 + i * 330; at(t + 165, { lift: 6, tilt: -5 }); at(t + 330, { lift: 2, tilt: 5 }); }
    at(7250, { spin: 80, x: 4, tilt: 0 }); at(7650, { spin: 0, x: 0, lift: 0, swim: 0.5 });
    at(7800, { sq: 0.15, armL: 20, armR: 20 }); at(7850, { spin: 0 }, 'l');
    at(8300, { lift: 10, sq: -0.06, armL: 110, armR: 110, glow: 1, wide: 0.4 }, 'o'); at(9100, { spin: 360, lift: 11 }); at(9101, { spin: 0 }, 'l');
    [8200, 8500, 8800, 9100].forEach(t => em(t, 'spark', 'body', 3));
    at(9500, { lift: 0, sq: 0.2, armL: 40, armR: 40, glow: 0, wide: 0 }, 'i'); at(9700, { sq: -0.04 }, 'o'); at(9900, { sq: 0, armL: 0, armR: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@aurora': { loop: LP, k: K, ev } });
    // yawn: flippers stretch up and out instead of dropping
    const S0 = RR.STATES.sleep; if (S0) { const A = [[0, 0], [380, 150, 'io'], [1100, 160], [1500, 0, 'io']]; RR.add({ 'sleep@aurora': Object.assign({}, S0, { k: Object.assign({}, S0.k, { armL: A, armR: A.map(x => x.slice()), hLy: [[0, 0], [380, -3, 'io'], [1100, -3.5], [1500, 0, 'io']], hRy: [[0, 0], [380, -3, 'io'], [1100, -3.5], [1500, 0, 'io']] }) }) }); } }
  // Choco's own dance, "Choco Pop": snap-pop beats with the segments flashing, a gooey melt-down (drips + puddle), a pop back into shape, a segment-wave square dance, a foil-peel twirl and a snap finish (10 s loop)
  function chDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@choco']) return;
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.5]], melt: [[0, 0]], tw: [[0, 0]], wrap: [[0, 0]] }, LP = 10000, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    for (let i = 0; i < 4; i++) { const d = i % 2 ? 1 : -1, t = 100 + i * 450; at(t, { tilt: d * 9, x: d * 3, htilt: -d * 4, armL: d < 0 ? 160 : 60, armR: d > 0 ? 160 : 60, sq: -0.06, lift: 3, tw: 0.8 }, 'o'); at(t + 220, { sq: 0.12, lift: 0 }, 'i'); em(t, 'crumb', [76, 16], 2); }
    at(1950, { tilt: 0, x: 0, htilt: 0, armL: 30, armR: 30, sq: 0, tw: 0, lean: 0, turn: 0, footL: 0, footR: 0, wrap: 0, wide: 0 }); at(2100, { melt: 0 }, 'l');
    at(3200, { melt: 1, sq: 0.24, armL: 35, armR: 35, open: 0.3, x: -3, tilt: -5, lean: -2 }); at(3600, { x: 3, tilt: 5, lean: 2 }); at(4000, { x: -1, tilt: -2, lean: -1 });
    em(2700, 'coffee', [30, 90], 2); em(3300, 'coffee', [64, 90], 2); em(3800, 'coffee', [44, 90], 2);
    at(4150, { sq: 0.36, x: 0, tilt: 0, lean: 0 }, 'i');
    at(4450, { melt: 0, sq: -0.18, lift: 15, armL: 170, armR: 170, wide: 0.6, open: 0.85 }, 'o'); em(4450, 'spark', 'head', 4); em(4450, 'coffee', 'body', 4);
    at(4750, { lift: 0, sq: 0.3, wide: 0, open: 0.5, armL: 60, armR: 60 }, 'i'); em(4750, 'dust', 'footL', 3); em(4750, 'dust', 'footR', 3);
    [[4900, -0.12], [5050, 0.1], [5200, 0]].forEach(([t, v]) => at(t, { sq: v })); at(5100, { tw: 0, turn: 0, footL: 0, footR: 0 }); at(5250, { tw: 1.2 });
    for (let i = 0; i < 6; i++) { const d = i % 2 ? 1 : -1, t = 5300 + i * 260; at(t, { x: d * 5, turn: d * 0.3, footL: d < 0 ? 3 : 0, footR: d > 0 ? 3 : 0, armL: d < 0 ? 130 : 40, armR: d > 0 ? 130 : 40, tilt: d * 4, sq: 0.08, lift: 0 }); at(t + 130, { sq: -0.04, lift: 2.5 }, 'o'); }
    at(6900, { x: 0, turn: 0, footL: 0, footR: 0, tilt: 0, tw: 0, armL: 20, armR: 20, sq: 0.22, lift: 0, wrap: 0 }, 'i'); at(6950, { spin: 0 }, 'l');
    at(7300, { wrap: 1, lift: 8, sq: -0.1, armL: 120, armR: 120, wide: 0.4, open: 0.8 }, 'o'); at(8000, { spin: 360, lift: 7 }); at(8001, { spin: 0 }, 'l'); [7400, 7700, 8000].forEach(t => em(t, 'spark', 'body', 3));
    at(8250, { wrap: 0, lift: 0, sq: 0.3, wide: 0, open: 0.5, armL: 40, armR: 40 }, 'i'); em(8250, 'dust', 'footL', 3); em(8250, 'dust', 'footR', 3);
    [[8400, -0.12], [8550, 0.1], [8700, 0]].forEach(([t, v]) => at(t, { sq: v }));
    at(8750, { tw: 0, htilt: 0 }); at(8900, { tilt: -6, armL: 170, armR: 30, tw: 1, sq: -0.05 }, 'o'); at(9100, { tilt: 6, armL: 30, armR: 170 }, 'o'); em(8900, 'crumb', [76, 16], 3);
    at(9300, { tilt: 3, htilt: 5, armR: 150, armL: 40, tw: 0, winkR: 0 }); at(9450, { winkR: 1 }); at(9700, { winkR: 0 }); em(9450, 'heart', 'head', 1);
    at(9900, { tilt: 0, htilt: 0, armL: 0, armR: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@choco': { loop: LP, k: K, ev } }); }
  // Scoop's own dance, "Scoop Swirl": side sways with the cherry popping, a swirl spin, cone twists on little hops, a rising double swirl, cherry bops and a wink (10 s loop)
  function scDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@scoop']) return;
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.5]], chb: [[0, 0]] }, LP = 10000, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    for (let i = 0; i < 4; i++) { const d = i % 2 ? 1 : -1, t = 150 + i * 450; at(t, { tilt: d * 8, x: d * 3, htilt: -d * 3, armL: d < 0 ? 150 : 50, armR: d > 0 ? 150 : 50, sq: 0.1, lift: 0, chb: 0 }, 'i'); at(t + 200, { sq: -0.06, lift: 3, chb: 1 }, 'o'); em(t + 200, 'spark', 'head', 1); }
    at(2000, { tilt: 0, x: 0, htilt: 0, armL: 30, armR: 30, sq: 0.18, lift: 0, chb: 0, spin: 0, turn: 0, wide: 0 }, 'i');
    at(2300, { sq: -0.1, lift: 9, armL: 120, armR: 120, wide: 0.4, open: 0.8 }, 'o'); at(3300, { spin: 360, lift: 8 }); at(3301, { spin: 0 }, 'l'); [2500, 2900, 3300].forEach(t => em(t, 'spark', 'body', 2));
    at(3600, { lift: 0, sq: 0.3, wide: 0, open: 0.5, armL: 50, armR: 50 }, 'i'); em(3600, 'dust', [38, 96], 2); em(3600, 'dust', [62, 96], 2);
    [[3750, -0.1], [3900, 0.08], [4050, 0]].forEach(([t, v]) => at(t, { sq: v, chb: v < 0 ? 0.8 : 0 }));
    for (let i = 0; i < 6; i++) { const d = i % 2 ? 1 : -1, t = 4200 + i * 280; at(t, { turn: d * 0.35, tilt: d * 5, x: d * 4, armL: d < 0 ? 140 : 40, armR: d > 0 ? 140 : 40, sq: 0.1, lift: 0, chb: 0 }); at(t + 140, { sq: -0.05, lift: 3, chb: 0.7 }, 'o'); }
    at(5950, { turn: 0, tilt: 0, x: 0, sq: 0.25, lift: 0, chb: 0, armL: 20, armR: 20 }, 'i'); at(6000, { spin: 0 }, 'l');
    at(6300, { lift: 12, sq: -0.12, armL: 170, armR: 170, wide: 0.6, open: 0.9 }, 'o'); at(7500, { spin: 720, lift: 10 }); at(7501, { spin: 0 }, 'l'); [6500, 6800, 7100, 7400].forEach(t => em(t, 'spark', 'body', 2));
    at(7800, { lift: 0, sq: 0.32, wide: 0, open: 0.5, armL: 40, armR: 40 }, 'i'); em(7800, 'dust', [36, 96], 3); em(7800, 'dust', [64, 96], 3);
    [[7950, -0.12], [8100, 0.1], [8250, 0]].forEach(([t, v]) => at(t, { sq: v }));
    for (let i = 0; i < 3; i++) { const t = 8350 + i * 260; at(t, { sq: 0.2, chb: 0, lift: 0 }, 'i'); at(t + 130, { sq: -0.08, chb: 1.6, lift: 2 }, 'o'); }
    at(9150, { sq: 0, chb: 0, lift: 0, tilt: 5, htilt: 5, armR: 160, armL: 40, winkR: 0 }); at(9350, { winkR: 1 }); at(9650, { winkR: 0 }); em(9350, 'heart', 'head', 1);
    at(9900, { tilt: 0, htilt: 0, armL: 0, armR: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@scoop': { loop: LP, k: K, ev } }); }
  // Avo's own dance, "Pit Hop": bouncy side hops with the pit bobbing in his belly and the sprout leaves flapping, a leaf-copter lift-off (the leaves spin like a propeller),
  // a belly roll (the pit rolls round in its socket), a pit toss (it pops out, flies over his head and plops back in), guac-mash stomps, a leaf-whirl spin, pose + wink (11.4 s loop).
  // Channels: lsp (leaf spin, turns), lfl (leaf flap/lift), pp (pit pop), pt (pit toss 0->1), pr (pit roll, turns), prw (pit wobble in the socket)
  function avDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@avo']) return;
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.5]], lsp: [[0, 0]], lfl: [[0, 0]], pp: [[0, 0]], pt: [[0, 0]], pr: [[0, 0]], prw: [[0, 0]] }, LP = 11400, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    // pit hops: side to side, squash on every landing, the pit bounces up in his belly and the leaves flap
    for (let i = 0; i < 4; i++) { const d = i % 2 ? 1 : -1, t = 200 + i * 500;
      at(t, { x: d * 5, tilt: d * 6, htilt: -d * 3, sq: 0.22, lift: 0, armL: 40, armR: 40, pp: 0, lfl: 0.1, footL: 0, footR: 0 }, 'i');
      at(t + 200, { lift: 9, sq: -0.1, armL: d < 0 ? 150 : 70, armR: d > 0 ? 150 : 70, pp: 0.6, lfl: 0.9, footL: d < 0 ? 3 : 1, footR: d > 0 ? 3 : 1 }, 'o');
      at(t + 400, { lift: 0, sq: 0.25, pp: 0.15, lfl: -0.2, footL: 0, footR: 0 }, 'i'); em(t + 400, 'dust', [50 + d * 8, 96], 2); if (i % 2) em(t + 200, 'note', 'head', 1); }
    // leaf-copter: crouch, the leaves spin up like a propeller and lift him off, a hover with a sway, soft landing
    at(2300, { x: 0, tilt: 0, htilt: 0, sq: 0.28, lift: 0, armL: 30, armR: 30, pp: 0, lfl: 0.3, lsp: 0 }, 'i');
    at(2700, { sq: -0.05, lift: 4, armL: 100, armR: 100, lfl: 0.8, lsp: 1.5, open: 0.8, wide: 0.4, prw: 0.6 }, 'i');
    at(3200, { lift: 18, lsp: 4.5, armL: 115, armR: 105, tilt: -5, x: -4 }, 'l'); at(3700, { lift: 21, lsp: 7.5, armL: 105, armR: 115, tilt: 5, x: 4 }, 'l');
    at(4200, { lift: 12, lsp: 10, tilt: 0, x: 0, lfl: 0.5 }, 'l'); at(4550, { lift: 0, sq: 0.3, lsp: 11, lfl: -0.3, armL: 50, armR: 50, open: 0.5, wide: 0, prw: 0, pp: 0.5 }, 'i'); at(4551, { lsp: 0 }, 'l');
    [2900, 3300, 3700, 4100].forEach(t => em(t, 'spark', 'head', 1)); em(4550, 'dust', [38, 96], 3); em(4550, 'dust', [62, 96], 3);
    at(4750, { sq: -0.06, lfl: 0.2, pp: 0 }, 'o'); at(4900, { sq: 0, lfl: 0 });
    // belly roll: hips circle, the pit rolls round in its socket, paws circle over his belly
    for (let i = 0; i <= 8; i++) { const a = i / 8 * Math.PI * 2, t = 5000 + i * 180; at(t, { x: Math.cos(a) * 4, lean: Math.sin(a) * 3, tilt: Math.cos(a) * 5, htilt: -Math.cos(a) * 3, sq: 0.06 + 0.05 * Math.sin(a), armL: 45 + 25 * Math.sin(a), armR: 45 - 25 * Math.sin(a), pr: i / 8 * 2, prw: i === 8 ? 0.3 : 1, pp: 0.2, lfl: 0.15 * Math.cos(a) }, 'l'); }
    em(5400, 'note', 'body', 1); em(6000, 'note', 'body', 1);
    // pit toss: squat, the pit pops out of his belly and flies high over his head (he watches it), then plops back into its socket
    at(6500, { x: 0, lean: 0, tilt: 0, htilt: 0, sq: 0.25, armL: 30, armR: 30, pr: 2, prw: 0, pp: 0.5, lfl: 0 }, 'i'); at(6501, { pr: 0 }, 'l');
    at(6750, { sq: 0.32, pp: 1, pt: 0 }, 'i'); at(6850, { sq: -0.1, lift: 3, armL: 150, armR: 150, open: 0.9, wide: 0.5, lfl: 0.6 }, 'o'); em(6850, 'spark', 'pit', 2);
    at(6860, { pt: 0.02 }, 'l'); at(7850, { pt: 1 }, 'l'); at(7851, { pt: 0 }, 'l');
    at(7150, { ly: -1, lift: 0, sq: 0, pitch: -0.25, armL: 165, armR: 165 }); at(7550, { ly: -0.2, pitch: 0, armL: 70, armR: 70, lfl: 0 }); at(7850, { ly: 0.3, sq: 0.3, pp: 0.8, wide: 0, open: 0.6 }, 'i');
    at(8000, { sq: -0.08, pp: 0, ly: 0 }, 'o'); at(8150, { sq: 0.06, pp: 0.3 }); at(8300, { sq: 0, pp: 0 }); em(7850, 'spark', 'pit', 3); em(7850, 'heart', 'pit', 1);
    // guac-mash stomps: wide squashy stomps left, right, left, right with dust
    for (let i = 0; i < 4; i++) { const L = i % 2 === 0, t = 8400 + i * 240; at(t, { sq: 0.36, wide: 0.3, x: L ? -3 : 3, footL: L ? 0 : 4, footR: L ? 4 : 0, armL: L ? 20 : 80, armR: L ? 80 : 20, lfl: -0.25, tilt: L ? -4 : 4, pp: 0.25 }, 'i'); at(t + 120, { sq: 0.05, lfl: 0.4, pp: 0, footL: 0, footR: 0 }, 'o'); em(t, 'dust', [L ? 38 : 62, 96], 2); }
    // leaf-whirl spin
    at(9400, { x: 0, tilt: 0, sq: 0.2, footL: 0, footR: 0, armL: 40, armR: 40, wide: 0, lfl: 0, spin: 0, lsp: 0 }, 'i');
    at(9600, { sq: -0.08, lift: 8, armL: 140, armR: 140, lfl: 0.7, open: 0.8 }, 'o'); at(10200, { spin: 360, lsp: 3, lift: 7 }); at(10201, { spin: 0, lsp: 0 }, 'l'); [9700, 10000].forEach(t => em(t, 'spark', 'head', 1));
    at(10350, { lift: 0, sq: 0.25, armL: 40, armR: 40, lfl: 0, open: 0.5 }, 'i'); em(10350, 'dust', [40, 96], 2); em(10350, 'dust', [60, 96], 2);
    // pose + wink
    at(10550, { sq: 0, tilt: 6, htilt: 5, armL: 30, armR: 165, winkR: 0, pp: 0.4, lfl: 0.5 }); at(10700, { winkR: 1 }); at(11000, { winkR: 0, pp: 0, lfl: 0 }); em(10700, 'heart', 'head', 1);
    at(11250, { tilt: 0, htilt: 0, armL: 0, armR: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@avo': { loop: LP, k: K, ev } }); }
  // Berri's own dance, "Berry Bop" (strawberry moves): juicy bounces with the calyx flapping and the stem boinging, a calyx twirl (the leaves whirl like a skirt while he pirouettes),
  // a vine dangle (he swings like a berry hanging from the plant, feet dangling), a juice squish (squashes flat, juice splashes) + juicy pop jump, a shortcake shimmy, a deep curtsy that shows off his leafy top, heart pose + wink (11.6 s loop).
  // Channels: lfl (calyx flap/lift), lsp (calyx twirl, turns), stw (stem boing)
  function brDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@berri']) return;
    if (RR.PRE && !RR.PRE.juice) RR.PRE.juice = { n: 6, sp: 24, vy: -22, g: 90, life: 820, r: [0.8, 1.3], col: ['#ff4d6a', '#ff8fa3', '#d42a4a'], kind: 'drop' };
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.5]], lfl: [[0, 0]], lsp: [[0, 0]], stw: [[0, 0]] }, LP = 11600, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    // juicy bounces: squash, spring up with one paw pumping high, the calyx flaps and the stem boings
    for (let i = 0; i < 4; i++) { const d = i % 2 ? 1 : -1, t = 200 + i * 500;
      at(t, { x: 0, tilt: d * 4, htilt: -d * 3, sq: 0.26, wide: 0.15, lift: 0, armL: 30, armR: 30, lfl: -0.25, stw: 0.3, footL: 0, footR: 0 }, 'i');
      at(t + 220, { lift: 11, sq: -0.14, wide: 0, tilt: -d * 3, armL: d < 0 ? 165 : 90, armR: d > 0 ? 165 : 90, lfl: 1, stw: 1, footL: 2, footR: 2 }, 'o');
      at(t + 440, { lift: 0, sq: 0.28, lfl: -0.3, footL: 0, footR: 0 }, 'i'); em(t + 440, 'dust', [50 + d * 6, 96], 2); if (i % 2) em(t + 220, 'note', 'head', 1); }
    // calyx twirl: up on tiptoe, paws up in a circle, two slow pirouettes with the leaves whirling like a skirt
    at(2300, { tilt: 0, htilt: 0, sq: 0.22, lift: 0, armL: 40, armR: 40, lfl: 0, lsp: 0, spin: 0, stw: 0.2 }, 'i');
    at(2600, { sq: -0.1, lift: 6, armL: 170, armR: 170, lfl: 0.6, open: 0.8 }, 'o');
    at(3900, { spin: 720, lsp: 4, lift: 9, lfl: 0.9 }, 'io'); at(3901, { spin: 0, lsp: 0 }, 'l');
    at(4150, { lift: 0, sq: 0.28, armL: 60, armR: 60, lfl: -0.2, open: 0.5, stw: 1 }, 'i'); at(4350, { sq: 0, lfl: 0, stw: 0.2 }, 'o');
    [2800, 3200, 3600].forEach(t => em(t, 'spark', 'head', 1)); em(4150, 'dust', [40, 96], 2); em(4150, 'dust', [60, 96], 2);
    // vine dangle: floats up as if hanging from his stem and swings like a pendulum, feet dangling, paws swinging loose
    at(4500, { sq: 0.15, armL: 30, armR: 30 }, 'i'); at(4800, { lift: 12, sq: -0.08, armL: 60, armR: 60, lfl: 0.3, stw: 0 }, 'o');
    for (let i = 0; i < 4; i++) { const d = i % 2 ? 1 : -1; at(5100 + i * 300, { tilt: d * 12, x: d * 4, htilt: d * 4, armL: d < 0 ? 100 : 30, armR: d > 0 ? 100 : 30, footL: d < 0 ? 3 : 0, footR: d > 0 ? 3 : 0, lfl: 0.3 - d * 0.2 }); }
    em(5400, 'note', 'head', 1); em(6000, 'note', 'head', 1);
    at(6250, { tilt: 0, x: 0, htilt: 0, lift: 0, sq: 0.25, footL: 0, footR: 0, armL: 40, armR: 40, lfl: -0.2, stw: 0.8 }, 'i'); at(6450, { sq: 0.05, stw: 0 }, 'o'); em(6250, 'dust', [42, 96], 2); em(6250, 'dust', [58, 96], 2);
    // juice squish: squashes flat and wide (juice splashes out), then a juicy pop jump high with paws up
    at(6800, { sq: 0.45, wide: 0.6, armL: 10, armR: 10, lfl: -0.5, open: 0.3 }, 'i'); em(6800, 'juice', [30, 90], 6); em(6800, 'juice', [70, 90], 6);
    at(7050, { sq: -0.22, wide: 0, lift: 22, armL: 175, armR: 175, lfl: 1.2, stw: 1.2, open: 0.95 }, 'o'); em(7050, 'spark', 'head', 2);
    at(7450, { lift: 18, sq: -0.08 }); at(7750, { lift: 0, sq: 0.32, armL: 50, armR: 50, lfl: -0.3, open: 0.5 }, 'i'); em(7750, 'juice', [50, 94], 5); em(7750, 'dust', [40, 96], 2); em(7750, 'dust', [60, 96], 2);
    at(7900, { sq: -0.05, lfl: 0.2, stw: 0.8 }, 'o'); at(8050, { sq: 0, lfl: 0, stw: 0.2 });
    // shortcake shimmy: quick side shimmy, paws shaking high-low, calyx fluttering
    for (let i = 0; i < 8; i++) { const d = i % 2 ? 1 : -1; at(8150 + i * 140, { x: d * 3, tilt: d * 3, htilt: -d * 2, sq: 0.08, armL: d < 0 ? 120 : 50, armR: d > 0 ? 120 : 50, lfl: 0.4 + d * 0.25, footL: d < 0 ? 2 : 0, footR: d > 0 ? 2 : 0 }); }
    em(8400, 'note', 'head', 1); em(8900, 'note', 'head', 1);
    // curtsy: a deep bow that shows off his leafy top, then pops back up
    at(9300, { x: 0, tilt: 0, htilt: 0, sq: 0.1, footL: 0, footR: 0, armL: 30, armR: 30, lfl: 0 });
    at(9650, { pitch: 0.55, sq: 0.2, armL: 70, armR: 70, lfl: 0.5 }, 'io'); at(9800, { pitch: 0.55 });
    at(10050, { pitch: -0.15, sq: -0.1, lift: 6, armL: 150, armR: 150, lfl: 0.9, stw: 1 }, 'o'); at(10250, { pitch: 0, lift: 0, sq: 0.22, lfl: -0.1 }, 'i'); em(10050, 'spark', 'head', 2); em(10250, 'dust', [50, 96], 2);
    // heart pose + wink
    at(10450, { sq: 0, tilt: 6, htilt: 5, armL: 30, armR: 165, winkR: 0, lfl: 0.5, stw: 0.3 }); at(10600, { winkR: 1 }); at(10950, { winkR: 0, lfl: 0, stw: 0 }); em(10600, 'heart', 'head', 2);
    at(11400, { tilt: 0, htilt: 0, armL: 0, armR: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@berri': { loop: LP, k: K, ev } }); }
  // Floof's own dance, "Yeti Stomp" (a baby yeti - big shaggy snow beast): heavy stomps that shake snow loose, rolling a snowball and throwing it, a shiver-shake that fluffs his fur up,
  // a belly-flop snow slide, a big mountain bellow with arms up, a stompy spin, wink (11.4 s loop). Channel fzz (fur fluff-up). Snow is PRE.snow
  function flDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@floof']) return; if (RR.PRE && !RR.PRE.snow) RR.PRE.snow = { n: 5, sp: 16, vy: -14, g: 40, life: 1300, r: [0.6, 1.3], col: ['#ffffff', '#eef4ff', '#dce8ff'], kind: 'dot' };
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.5]], mw: [[0, 1]], winkR: [[0, 0]], wide: [[0, 0]], sqz: [[0, 0]], blush: [[0, 0]] }, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    K.fzz = [[0, 0]];
    for (let i = 0; i < 6; i++) { const d = i % 2 ? 1 : -1, t = 150 + i * 420; at(t, { x: d * 3, tilt: d * 7, lean: d * 2, sq: 0.06, footL: d < 0 ? 8 : 0, footR: d > 0 ? 8 : 0, armL: d < 0 ? 70 : 30, armR: d > 0 ? 70 : 30 }, 'o');
      at(t + 200, { sq: 0.26, tilt: d * 3, footL: 0, footR: 0 }, 'i'); em(t + 200, 'snow', [50 + d * 13, 94], 3); em(t + 200, 'dust', [50 + d * 13, 96], 2); }
    // snowball: crouches and rolls a snowball between his paws, then throws it
    at(2750, { armL: 0, armR: 0, hLx: 0, hRx: 0, hLy: 0, hRy: 0, tilt: 0, htilt: 0, x: 0, lift: 0, sq: 0, lean: 0, pitch: 0, footL: 0, footR: 0, sq: 0.2, pitch: 0.25, armL: 20, armR: 20 }, 'i');
    for (let i = 0; i <= 8; i++) { const a = i / 8 * Math.PI * 2; at(2950 + i * 140, { hLx: 6 + 3 * Math.cos(a), hRx: -6 - 3 * Math.cos(a), hLy: 6 + 3 * Math.sin(a), hRy: 6 - 3 * Math.sin(a), sq: 0.2 + 0.04 * Math.sin(a) }, 'l'); } em(3400, 'snow', 'pawL', 2);
    at(4250, { pitch: -0.2, sq: -0.05, armR: 175, hRx: 0, hRy: 0, hLx: 0, hLy: 0, armL: 40, tilt: -6, lean: -2 }, 'i'); at(4450, { armR: 40, tilt: 8, lean: 3, pitch: 0.1, open: 0.9 }, 'o'); em(4450, 'snow', 'pawR', 6);
    // shiver-shake: shakes like a wet dog, fur fluffing right up, snow flying off
    at(4800, { tilt: 0, lean: 0, pitch: 0, armR: 30, armL: 30, sq: 0.05, open: 0.4, sqz: 0.8, hap: 0 });
    for (let i = 0; i < 10; i++) at(4900 + i * 80, { x: i % 2 ? 2 : -2, tilt: i % 2 ? 6 : -6, htilt: i % 2 ? -5 : 5, fzz: 1.2 }, 'l'); [5000, 5300, 5600].forEach(t => em(t, 'snow', 'body', 5));
    at(5800, { x: 0, tilt: 0, htilt: 0, fzz: 0.4, sqz: 0, hap: 0.85, open: 0.6 }, 'o'); at(6200, { fzz: 0 });
    // belly-flop snow slide: dives forward onto his tummy and slides along, kicking his feet
    at(6300, { sq: 0.22, lift: 0, armL: 120, armR: 120 }, 'i'); at(6550, { lift: 8, pitch: 0.6, armL: 170, armR: 170, x: -4, sq: -0.05 }, 'o');
    at(6800, { lift: 0, pitch: 0.9, sq: 0.25, x: 0 }, 'i'); at(7600, { x: 12, pitch: 0.9, footL: 5, footR: 0 }); at(7700, { footL: 0, footR: 5 }, 'l'); at(7800, { footR: 0 });
    [6800, 7100, 7400].forEach(t => em(t, 'snow', 'belly', 4)); at(8100, { pitch: 0, sq: 0.1, x: 6, armL: 40, armR: 40 }, 'io');
    // mountain bellow: rears up tall, arms up, huge open-mouth roar, snow bursts
    at(8300, { x: 0, sq: 0.25, armL: 50, armR: 50 }, 'i'); at(8600, { sq: -0.22, lift: 4, armL: 175, armR: 175, open: 1, mw: 1.4, wide: 1, hap: 0, fzz: 1 }, 'o'); em(8600, 'snow', 'head', 8); em(8700, 'dust', [40, 96], 3); em(8700, 'dust', [60, 96], 3);
    for (let i = 0; i < 5; i++) at(8700 + i * 100, { htilt: i % 2 ? 3 : -3 }, 'l'); at(9300, { lift: 0, sq: 0.15, wide: 0, open: 0.5, mw: 1, hap: 0.85, fzz: 0, armL: 60, armR: 60, htilt: 0 }, 'i');
    // stompy spin: stamps round in a circle
    at(9450, { spin: 0 }); for (let i = 1; i <= 4; i++) { at(9450 + i * 230, { spin: i * 90, sq: i % 2 ? 0.25 : 0.05, footL: i % 2 ? 0 : 6, footR: i % 2 ? 6 : 0 }); em(9450 + i * 230, 'snow', [50, 94], 2); } at(10371, { spin: 0 }, 'l');
    at(10550, { winkR: 0, sq: 0, footL: 0, footR: 0, tilt: 5, htilt: 6, armL: 30, armR: 140, hRx: -6, hRy: -8, mw: 0.8 }); at(10750, { winkR: 1 }); at(11100, { winkR: 0, mw: 1 }); em(10750, 'heart', 'head', 2);
    at(11300, { armL: 0, armR: 0, hLx: 0, hRx: 0, hLy: 0, hRy: 0, tilt: 0, htilt: 0, x: 0, lift: 0, sq: 0, lean: 0, pitch: 0, footL: 0, footR: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < 11400) K[p].push([11400, K[p][0][1], 'io']); }
    RR.add({ 'dance@floof': { loop: 11400, k: K, ev } }); }
  // Unibun's own dance, "Rainbow Prance" (unicorn + bunny): a proud high-stepping unicorn prance, a horn-led spin with a sparkle trail, a bunny ear wiggle,
  // a rainbow arc of sparkles from her horn, rearing up on her hind legs like a unicorn, a sparkly horn bow + wink (11.6 s loop). Rainbow sparkles are PRE.rainbow
  function ubDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@unibun']) return; if (RR.PRE && !RR.PRE.rainbow) RR.PRE.rainbow = { n: 5, sp: 14, vy: -8, g: 6, life: 1300, r: [1.1, 2], col: ['#ff8fc8', '#ffd84a', '#9be38a', '#7cc8ff', '#c8a0ff'], kind: 'star' };
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.5]], mw: [[0, 1]], winkR: [[0, 0]], wide: [[0, 0]], sqz: [[0, 0]], blush: [[0, 0]] }, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    K.flL = [[0, 0]]; K.flR = [[0, 0]];
    for (let i = 0; i < 6; i++) { const d = i % 2 ? 1 : -1, t = 150 + i * 380; at(t, { x: d * 4, lift: 0, sq: 0.15, footL: 0, footR: 0, tilt: 0 }, 'i');
      at(t + 190, { lift: 6, sq: -0.06, footL: d < 0 ? 9 : 0, footR: d > 0 ? 9 : 0, armL: d < 0 ? 110 : 60, armR: d > 0 ? 110 : 60, hLy: d < 0 ? -6 : 0, hRy: d > 0 ? -6 : 0, htilt: -d * 6, tilt: d * 3, earL: d * 8, earR: -d * 8 }, 'o'); if (i % 2) em(t + 190, 'rainbow', 'horn', 2); }
    // horn twirl: spins twice, sparkles trailing from her horn
    at(2550, { armL: 0, armR: 0, hLx: 0, hRx: 0, hLy: 0, hRy: 0, tilt: 0, htilt: 0, x: 0, lift: 0, sq: 0, lean: 0, pitch: 0, footL: 0, footR: 0, earL: 0, earR: 0, sq: 0.1, armL: 90, armR: 90 }, 'i'); at(2700, { lift: 4, armL: 160, armR: 160, spin: 0 }); at(3600, { spin: 720, lift: 6 }, 'io'); at(3601, { spin: 0 }, 'l'); [2800, 3050, 3300, 3550].forEach(tt => em(tt, 'rainbow', 'horn', 3));
    at(3850, { lift: 0, sq: 0.18, armL: 40, armR: 40 }, 'i');
    // ear wiggle: twitches one ear, then the other, then flops both and shakes them back up
    at(4100, { sq: 0, earL: 0, earR: 0 }); [[4300, 'earL', 25], [4550, 'earR', 25], [4800, 'earL', -10], [5050, 'earR', -10]].forEach(([tt, k, v]) => { at(tt, { [k]: v }, 'o'); at(tt + 180, { [k]: 0 }); });
    at(5400, { flL: 1, flR: 1, htilt: 0, sq: 0.1 }); for (let i = 0; i < 6; i++) at(5600 + i * 90, { htilt: i % 2 ? 8 : -8, flL: 1 - i / 5, flR: 1 - i / 5 }, 'l'); at(6200, { htilt: 0, flL: 0, flR: 0, sq: 0 }, 'o'); em(6200, 'spark', 'head', 2);
    // rainbow arc: points her horn and sweeps a rainbow of sparkles across the sky
    at(6400, { lean: 0, pitch: 0.2, armL: 120, armR: 40, hLy: -6 }); for (let i = 0; i <= 6; i++) { const a = i / 6; at(6550 + i * 180, { tilt: -12 + 24 * a, x: -6 + 12 * a, htilt: -6 + 12 * a, armL: 120 + 40 * Math.sin(Math.PI * a) }, 'l'); em(6550 + i * 180, 'rainbow', 'horn', 3); }
    at(7900, { tilt: 0, x: 0, htilt: 0, pitch: 0, armL: 40, hLy: 0 });
    // rear up: rises on her hind legs, front paws kicking, then lands with a sparkle burst
    at(8100, { sq: 0.2, armL: 50, armR: 50 }, 'i'); at(8400, { pitch: -0.45, lift: 6, sq: -0.12, armL: 150, armR: 150, hLy: -8, hRy: -8, open: 1, wide: 0.6 }, 'o');
    for (let i = 0; i < 4; i++) at(8500 + i * 140, { hLy: i % 2 ? -12 : -4, hRy: i % 2 ? -4 : -12 }, 'l'); at(9150, { pitch: 0, lift: 0, sq: 0.25, armL: 50, armR: 50, hLy: 0, hRy: 0, wide: 0, open: 0.5 }, 'i'); em(9150, 'rainbow', [50, 92], 5); em(9150, 'dust', [42, 96], 2); em(9150, 'dust', [58, 96], 2);
    // bow: dips her horn in a curtsy bow, sparkles, wink
    at(9450, { sq: 0 }); at(9800, { pitch: 0.45, sq: 0.15, armL: 30, armR: 30, htilt: 6 }); em(9900, 'rainbow', 'horn', 5); at(10300, { pitch: 0, sq: 0, tilt: 5 });
    at(10500, { winkR: 0, armL: 30, armR: 150, hRx: -6, hRy: -8 }); at(10700, { winkR: 1 }); at(11050, { winkR: 0 }); em(10700, 'heart', 'head', 2); at(11450, { armL: 0, armR: 0, hLx: 0, hRx: 0, hLy: 0, hRy: 0, tilt: 0, htilt: 0, x: 0, lift: 0, sq: 0, lean: 0, pitch: 0, footL: 0, footR: 0, htilt: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < 11600) K[p].push([11600, K[p][0][1], 'io']); }
    RR.add({ 'dance@unibun': { loop: 11600, k: K, ev } }); }
  // Gumdrop's own dance, "Gummy Wiggle" (a gummy bear made of jelly): jelly jiggle shakes (channel jig), a gummy stretch - pulled up tall then snapping back with a wobble,
  // heavy squishy bounces, the gummy-bear arm wave, a melt-down squish and pop back, a wobbly spin, wink (11.2 s loop). His body springs and wobbles on every move (see the gummy jiggle)
  function gmDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@gumdrop']) return;
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.5]], mw: [[0, 1]], winkR: [[0, 0]], wide: [[0, 0]], sqz: [[0, 0]], blush: [[0, 0]] }, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    K.jig = [[0, 0]];
    for (let i = 0; i < 4; i++) { const t = 100 + i * 550, d = i % 2 ? 1 : -1; at(t, { jig: 1, tilt: d * 4, x: d * 2, armL: 70 + d * 20, armR: 70 - d * 20 }); at(t + 450, { jig: 0.2, tilt: 0, x: 0 }); if (i % 2) em(t, 'note', 'head', 1); }
    // gummy stretch: pulled up tall like taffy, then snaps back with a big wobble
    at(2400, { jig: 0, sq: 0.15, armL: 170, armR: 170 }, 'i'); at(2900, { sq: -0.25, lift: 6, armL: 178, armR: 178, wide: 0.6, open: 0.8 }, 'i'); at(3050, { sq: 0.3, lift: 0, wide: 0, open: 0.5, armL: 60, armR: 60 }, 'o'); em(3050, 'spark', 'head', 3);
    // squishy bounces: three heavy bounces that land in a big squish
    for (let i = 0; i < 3; i++) { const t = 3400 + i * 520; at(t, { sq: 0.32, lift: 0 }, 'i'); at(t + 220, { sq: -0.15, lift: 14 - i * 2, armL: 140, armR: 140 }, 'o'); at(t + 470, { lift: 0, sq: 0.3, armL: 40, armR: 40 }, 'i'); em(t + 470, 'dust', [50, 96], 2); }
    // gummy-bear wave: arms wave up and down in turn while he sways
    at(5100, { sq: 0 }); for (let i = 0; i < 6; i++) { const d = i % 2 ? 1 : -1; at(5250 + i * 230, { armL: d < 0 ? 160 : 40, armR: d > 0 ? 160 : 40, tilt: d * 6, htilt: -d * 5, x: d * 2 }); } em(5600, 'note', 'head', 1); em(6300, 'note', 'head', 1);
    // melt-down: slowly squishes down into a puddle, then pops back up
    at(6700, { tilt: 0, htilt: 0, x: 0, armL: 30, armR: 30 }); at(7600, { sq: 0.45, armL: 5, armR: 5, sqz: 0.6, hap: 0, open: 0.2 }, 'i'); at(7900, { sq: -0.22, lift: 10, sqz: 0, hap: 0.85, open: 0.9, armL: 165, armR: 165 }, 'o'); at(8200, { lift: 0, sq: 0.25, open: 0.5, armL: 50, armR: 50 }, 'i'); em(7900, 'spark', 'head', 4);
    // wobbly spin
    at(8400, { sq: 0, spin: 0, jig: 0.5 }); at(9300, { spin: 360, jig: 0.6, armL: 110, armR: 110 }, 'io'); at(9301, { spin: 0 }, 'l'); at(9500, { jig: 0, armL: 30, armR: 30 });
    at(9800, { winkR: 0, tilt: 5, htilt: 6, armL: 30, armR: 150, hRx: -6, hRy: -8, mw: 0.8, jig: 0.3 }); at(10000, { winkR: 1, jig: 0 }); at(10350, { winkR: 0, mw: 1 }); em(10000, 'heart', 'head', 2); at(11000, { armL: 0, armR: 0, hLx: 0, hRx: 0, hLy: 0, hRy: 0, tilt: 0, htilt: 0, x: 0, lift: 0, sq: 0, lean: 0, pitch: 0, footL: 0, footR: 0, jig: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < 11200) K[p].push([11200, K[p][0][1], 'io']); }
    RR.add({ 'dance@gumdrop': { loop: 11200, k: K, ev } }); }
  // Forest Friends dances: keys are seeded at t=0 from the rest pose, long gaps auto-hold (no slow drift between moves), every channel loops back to its t=0 value
  function ffDance(key, LP, fn) { const RR = window.RiveRig; if (!RR || RR.STATES['dance@' + key]) return;
    const DF = { hap: 0.85, smile: 1, open: 0.5, mw: 1 }, K = {}, ev = [], at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    fn(at, em); for (const p in DF) if (!K[p]) K[p] = [[0, DF[p]]];
    for (const p in K) { const A = K[p].sort((a, b) => a[0] - b[0]); if (A[0][0] > 0) A.unshift([0, p in DF ? DF[p] : 0]); const O = [A[0]];
      for (let i = 1; i < A.length; i++) { const pv = O[O.length - 1]; if (A[i][0] - pv[0] > 900) O.push([A[i][0] - 650, pv[1], 'io']); O.push(A[i]); }
      const pv = O[O.length - 1]; if (pv[0] < LP) { if (LP - pv[0] > 900) O.push([LP - 650, pv[1], 'io']); O.push([LP, O[0][1], 'io']); } K[p] = O; }
    ev.sort((a, b) => a[0] - b[0]); RR.add({ ['dance@' + key]: { loop: LP, k: K, ev } }); }
  // Teddy's own dance, "Bear Hug Sway": hugs himself and sways with hearts, heavy bear stomps, a belly drum while his ears wiggle, dips a paw in honey and licks it,
  // a big bear spin, opens his arms wide and gives YOU a squeezy bear hug (hearts + blush), wave + wink (12 s loop)
  function tdDance() { const RR = window.RiveRig; if (RR && RR.PRE && !RR.PRE.honey) RR.PRE.honey = { n: 3, sp: 8, vy: -10, g: 60, life: 900, r: [0.8, 1.2], col: ['#ffc23a', '#ffda6a', '#e89a14'], kind: 'drop' };
    ffDance('teddy', 12000, (at, em) => {
      at(0, { armL: 20, armR: 20 }); at(400, { armL: 75, armR: 75, hLx: 7, hRx: -7, hLy: -3, hRy: -3, sqz: 0.5, hap: 1, blush: 0.6 });
      for (let i = 0; i < 4; i++) { const t = 650 + i * 500, d = i % 2 ? 1 : -1; at(t, { tilt: d * 8, x: d * 3, lean: d * 1.5, earL: d > 0 ? 10 : -4, earR: d > 0 ? -4 : 10, sq: 0.05 }); at(t + 250, { sq: -0.02 }); if (!(i % 2)) em(t, 'heart', 'head', 1); }
      at(2400, { tilt: 0, x: 0, lean: 0, sqz: 0, blush: 0, hap: 0.85, earL: 0, earR: 0, armL: 60, armR: 60, hLx: 0, hRx: 0, hLy: 0, hRy: 0, sq: 0 });
      // bear stomps: heavy left-right stomps with big bear arms, dust on every landing
      for (let i = 0; i < 4; i++) { const t = 2600 + i * 420, d = i % 2 ? 1 : -1, f = d < 0 ? 'footL' : 'footR'; at(t, { [f]: 6, lift: 2, tilt: -d * 4, sq: -0.06, armL: d < 0 ? 100 : 55, armR: d < 0 ? 55 : 100 }, 'o');
        at(t + 200, { [f]: 0, lift: 0, tilt: d * 2, sq: 0.2 }, 'i'); at(t + 380, { sq: 0.02 }); em(t + 200, 'dust', [50 + d * 12, 96], 3); }
      at(4300, { tilt: 0, sq: 0, armL: 45, armR: 45 });
      // belly drum: paws pat his tummy in turn while his ears wiggle
      for (let i = 0; i < 6; i++) { const t = 4500 + i * 230, d = i % 2 ? 1 : -1; at(t, { hLx: d < 0 ? 6 : 2, hRx: d > 0 ? -6 : -2, hLy: d < 0 ? 3 : -1, hRy: d > 0 ? 3 : -1, armL: d < 0 ? 45 : 62, armR: d > 0 ? 45 : 62, earL: d < 0 ? 14 : -6, earR: d > 0 ? 14 : -6, sq: 0.06, htilt: d * 4 }, 'o'); at(t + 115, { sq: 0 }); if (i % 2) em(t, 'note', 'head', 1); }
      at(6000, { hLx: 0, hRx: 0, hLy: 0, hRy: 0, earL: 0, earR: 0, htilt: 0, sq: 0, armL: 30, armR: 30 });
      // honey paw: dips a paw in the honey pot, licks it, happy shimmy
      at(6250, { armR: 30, hRx: -2, hRy: 4, lean: 2, tilt: 4 }); at(6600, { hRx: -7, hRy: -13, armR: 70, lean: 0, tilt: -2, open: 0.8, tongue: 0.6, hap: 1 }); em(6600, 'honey', 'mouth', 2);
      at(6800, { tongue: 0.2, open: 0.4 }); at(7000, { tongue: 0.6, open: 0.8 }); at(7200, { tongue: 0, open: 0.5, hRx: 0, hRy: 0, armR: 40, hap: 0.85 });
      at(7300, { x: -2, tilt: -4 }); at(7450, { x: 2, tilt: 4, blush: 0.8 }); at(7600, { x: 0, tilt: 0, blush: 0.3 }); em(7450, 'heart', 'head', 1);
      // big bear spin
      at(7700, { sq: 0.2, armL: 60, armR: 60, spin: 0, lift: 0 }, 'i'); at(7950, { sq: -0.1, lift: 10, armL: 115, armR: 115 }, 'o'); at(8650, { spin: 360, lift: 4 }); at(8651, { spin: 0 }, 'l');
      at(8850, { lift: 0, sq: 0.22, armL: 50, armR: 50 }, 'i'); at(9000, { sq: 0 }); em(8850, 'dust', [50, 96], 3);
      // a bear hug for you: arms wide open, then a big squeezy hug with hearts and a blush
      at(9300, { armL: 150, armR: 150, hLx: -2, hRx: 2, wide: 0.4, open: 0.9, lift: 1, blush: 0.3 }, 'o');
      at(9800, { armL: 85, armR: 85, hLx: 9, hRx: -9, hLy: -2, hRy: -2, sq: 0.12, sqz: 0.9, wide: 0, hap: 1, blush: 1, open: 0.35, lift: 0 }, 'i'); em(9800, 'heart', 'head', 3);
      at(10100, { sq: 0.18, tilt: -4 }); at(10400, { sq: 0.12, tilt: 4 }); em(10300, 'heart', 'head', 2);
      at(10700, { armL: 30, armR: 30, hLx: 0, hRx: 0, hLy: 0, hRy: 0, sq: 0, tilt: 0, sqz: 0, hap: 0.85, blush: 0.4, open: 0.5 });
      at(10900, { armR: 150, hRy: -3, htilt: 5, tilt: 3 }); at(11100, { armR: 120, winkR: 1 }); at(11300, { armR: 160, winkR: 1 }); em(11100, 'heart', 'head', 1);
      at(11550, { armR: 0, hRy: 0, winkR: 0, htilt: 0, tilt: 0, blush: 0, armL: 0 }); }); }
  // Panko's own dance, "Panda Roll": munches bamboo on the beat (leaves fly), tucks into a ball and rolls across the floor and back (a bit dizzy), a clumsy waddle that trips into a plop,
  // peek-a-boo with his paws over his eye patches, a roly-poly rock on his round bottom, a lazy spin + flop, wave + wink (12.4 s loop). Leaves are PRE.bamboo
  function pkDance() { const RR = window.RiveRig; if (RR && RR.PRE && !RR.PRE.bamboo) RR.PRE.bamboo = { n: 2, sp: 9, vy: -10, g: 14, life: 1500, r: [0.9, 1.3], col: ['#7cc85a', '#5aa83e', '#a8e07a'], kind: 'leaf' };
    ffDance('panko', 12400, (at, em) => { const HC = 33;
      at(0, { armL: 20, armR: 20 }); at(300, { armL: 60, armR: 60, hLx: 6, hRx: -6, hLy: -11, hRy: -11 }, 'o');
      for (let i = 0; i < 6; i++) { const t = 400 + i * 300; at(t, { open: 0.8, sq: 0.08, tilt: i % 2 ? 3 : -3, htilt: i % 2 ? -4 : 4 }, 'o'); at(t + 150, { open: 0.15, sq: -0.02 }, 'i'); if (!(i % 2)) em(t + 150, 'bamboo', 'mouth', 2); }
      at(2200, { armL: 40, armR: 40, hLx: 0, hRx: 0, hLy: 0, hRy: 0, open: 0.5, tilt: 0, htilt: 0, sq: 0 });
      // tuck and roll like a ball (rotates round his middle), there and back
      const roll = (t0, x0, x1, dir) => { for (let s = 0; s <= 16; s++) { const u = s / 16, th = dir * 2 * Math.PI * u; at(t0 + 800 * u, { tilt: dir * 360 * u, x: x0 + (x1 - x0) * u - HC * Math.sin(th), lift: HC * (1 - Math.cos(th)) + Math.sin(Math.PI * u) * 4 }, 'l'); } at(t0 + 801, { tilt: 0, x: x1, lift: 0 }, 'l'); };
      at(2400, { sq: 0.25, armL: 15, armR: 15, x: 0 }, 'i'); at(2500, { sq: 0.1 }); roll(2500, 0, 14, 1); at(3500, { sq: 0.25 }, 'i'); em(3302, 'dust', [64, 96], 3);
      at(3700, { htilt: 9, sq: 0, wide: 0.4 }); at(3900, { htilt: -9 }); at(4100, { htilt: 0, wide: 0, sq: 0.1 });
      roll(4200, 14, 0, -1); at(5150, { sq: 0.25 }, 'i'); em(5002, 'dust', [50, 96], 3); at(5400, { sq: 0, armL: 40, armR: 40 });
      // clumsy waddle that trips into a plop on his bottom
      for (let i = 0; i < 4; i++) { const t = 5550 + i * 300, d = i % 2 ? 1 : -1; at(t, { x: d * 2.5, tilt: d * 7, footL: d < 0 ? 4 : 0, footR: d > 0 ? 4 : 0, armL: d < 0 ? 75 : 30, armR: d < 0 ? 30 : 75, lift: 1.5 }); at(t + 150, { lift: 0 }); }
      at(6800, { tilt: 12, lean: 4, x: 4, wide: 0.6, open: 0.95, armL: 125, armR: 125, lift: 3, footL: 0, footR: 0 }, 'o'); at(7050, { tilt: 0, lean: 0, lift: 0, sq: 0.38, wide: 0, open: 0.6, armL: 50, armR: 50 }, 'i'); em(7050, 'dust', [50, 96], 4); at(7300, { sq: 0.05, x: 0 });
      // peek-a-boo: paws over his eye patches, then pops them open with wide eyes (twice)
      [7400, 8050].forEach((t, j) => { at(t, { armL: 85, armR: 85, hLx: 9, hRx: -9, hLy: -16, hRy: -16, sqz: 0.6, hap: 0.4, sq: 0.08, htilt: j ? 5 : -5, open: 0.3 });
        at(t + 350, { hLx: -2, hRx: 2, hLy: -8, hRy: -8, armL: 130, armR: 130, sqz: 0, wide: 0.7, hap: 0.85, open: 0.95, sq: -0.08, lift: 3, htilt: 0 }, 'o'); em(t + 350, 'spark', 'head', 2); at(t + 600, { wide: 0, open: 0.5, lift: 0, sq: 0 }); });
      // roly-poly rock on his round bottom, paws waving in the air
      at(8800, { armL: 140, armR: 140, hLx: 0, hRx: 0, hLy: -7, hRy: -7 }); for (let i = 0; i < 4; i++) at(8950 + i * 300, { tilt: i % 2 ? 14 : -14, x: i % 2 ? 3 : -3, armL: i % 2 ? 165 : 125, armR: i % 2 ? 125 : 165 }, 's');
      at(10100, { tilt: 0, x: 0, armL: 60, armR: 60, hLy: 0, hRy: 0 });
      // lazy spin and flop
      at(10200, { sq: 0.18, spin: 0, lift: 0 }, 'i'); at(10400, { sq: -0.08, lift: 8 }, 'o'); at(10900, { spin: 360, lift: 3 }); at(10901, { spin: 0 }, 'l'); at(11050, { lift: 0, sq: 0.35, open: 0.8 }, 'i'); em(11050, 'dust', [50, 96], 3); at(11300, { sq: 0, open: 0.5 });
      at(11500, { armR: 150, hRy: -3, htilt: 5 }); at(11700, { armR: 120, winkR: 1 }); at(11900, { armR: 160 }); em(11700, 'heart', 'head', 1); at(12100, { armR: 0, hRy: 0, winkR: 0, htilt: 0, armL: 0 }); }); }
  // Hoot's own dance, "Hoot Owl Hustle": owl head-bobs with hoo-hoo beats and perky ear tufts, a flapping lift-off and hover (feathers drift down), a curious big "hoo?" head tilt,
  // an owl swivel to look behind him and back + a wings-out spin, a feather-ruffle shake, branch hops with balancing wings, a wise bow + wink (12 s loop).
  // Channels: wfl (wing flap, in the pre-update), tfl (ear tufts flare out). Feathers are PRE.feather
  function htDance() { const RR = window.RiveRig; if (RR && RR.PRE && !RR.PRE.feather) RR.PRE.feather = { n: 2, sp: 8, vy: -6, g: 12, life: 1700, r: [0.9, 1.3], col: ['#b98a5e', '#e8c9a4', '#8a5a38'], kind: 'leaf' };
    ffDance('hoot', 12000, (at, em) => {
      for (let i = 0; i < 6; i++) { const t = 200 + i * 330, d = i % 2 ? 1 : -1; at(t, { x: d * 2.5, htilt: d * 12, tilt: d * 3, sq: 0.06, earL: d < 0 ? 14 : -2, earR: d > 0 ? 14 : -2, open: i % 2 ? 0.85 : 0.3 }, 'o'); at(t + 165, { sq: -0.02 }); if (i % 2) em(t, 'note', 'head', 1); }
      at(2200, { x: 0, htilt: 0, tilt: 0, sq: 0, earL: 0, earR: 0, open: 0.5 });
      // flapping lift-off, hover, soft landing
      at(2300, { sq: 0.2, armL: 40, armR: 40, lift: 0 }, 'i'); at(2500, { sq: -0.1, lift: 6, wfl: 1.2, armL: 120, armR: 120, tfl: 0.5 }, 'o');
      at(3000, { lift: 15, x: -5, tilt: -5, sq: 0 }); at(3500, { lift: 17, x: 5, tilt: 5 }); at(3900, { lift: 12, x: 0, tilt: 0 }); em(2700, 'feather', 'body', 2); em(3400, 'feather', 'body', 2);
      at(4200, { lift: 0, sq: 0.2, wfl: 0.2, armL: 50, armR: 50, tfl: 0 }, 'i'); at(4400, { sq: 0, wfl: 0, armL: 20, armR: 20 }); em(4200, 'dust', [50, 96], 3);
      // curious "hoo?" tilt: big slow tilts with wide eyes, tufts twitch in turn
      at(4700, { htilt: 22, tilt: 6, wide: 0.6, open: 0.3, earL: 16, earR: -6, lx: 0.6 }, 's'); em(4700, 'note', 'head', 1); at(5150, { htilt: -22, tilt: -6, earL: -6, earR: 16, lx: -0.6 }, 's'); at(5600, { htilt: 0, tilt: 0, wide: 0, earL: 0, earR: 0, lx: 0, open: 0.5 }, 's');
      // owl swivel: turns round to look behind him, hoots, swivels back; then a full spin with his wings out
      at(5900, { spin: 0, armL: 20, armR: 20 }); at(6300, { spin: 170 }); at(6600, { spin: 170, open: 0.85 }); at(7000, { spin: 0, open: 0.5 });
      at(7050, { spin: 0, armL: 30, armR: 30, lift: 0 }); at(7650, { spin: 360, armL: 130, armR: 130, lift: 5, wfl: 0.6 }); at(7651, { spin: 0 }, 'l'); at(7850, { lift: 0, armL: 30, armR: 30, wfl: 0, sq: 0.15 }, 'i'); at(8000, { sq: 0 });
      // feather ruffle: fluffs up and shakes his feathers out
      at(8100, { sq: 0.1, tfl: 1 }); for (let i = 0; i < 8; i++) at(8200 + i * 90, { tilt: i % 2 ? 5 : -5, x: i % 2 ? 1.2 : -1.2, armL: i % 2 ? 50 : 30, armR: i % 2 ? 30 : 50 }, 'l'); em(8300, 'feather', 'body', 3); em(8650, 'feather', 'body', 3);
      at(8950, { tilt: 0, x: 0, tfl: 0, sq: 0, armL: 20, armR: 20 });
      // branch hops with balancing wings
      for (let i = 0; i < 4; i++) { const t = 9300 + i * 330, d = i % 2 ? 1 : -1; at(t, { sq: 0.15, lift: 0 }, 'i'); at(t + 160, { lift: 7, x: d * 5, sq: -0.08, armL: 80, armR: 80, wfl: 0.5 }, 'o'); at(t + 320, { lift: 0, sq: 0.12, armL: 30, armR: 30, wfl: 0 }, 'i'); }
      at(10650, { x: 0, sq: 0 });
      // wise bow + wing up + wink
      at(10900, { lean: 3, sq: 0.08, armL: 60, armR: 100, hRx: -4 }); at(11200, { lean: 0, sq: 0, winkR: 1, armR: 150 }); em(11200, 'heart', 'head', 1); at(11450, { winkR: 0, armR: 0, armL: 0, hRx: 0 }); }); }
  // Leo's own dance, "Mane Event" (a lion cub king): a proud strut with his mane bouncing, a crouch + bottom-wiggle + pounce, a big ROAR (mane flares, claws up), paw swipes,
  // chasing his own tail round twice (dizzy), a mane-shaking head toss (fur flies), a sunny cat stretch, king-of-the-jungle pose + wink (12.4 s loop).
  // Channels: mfl (mane flare), msh (mane shake), tsw (tail swish). Fur bits are PRE.manefur
  function leDance() { const RR = window.RiveRig; if (RR && RR.PRE && !RR.PRE.manefur) RR.PRE.manefur = { n: 3, sp: 14, vy: -9, g: 14, life: 1300, r: [0.8, 1.2], col: ['#d9762a', '#f2a24a', '#b25a1a'], kind: 'leaf' };
    ffDance('leo', 12400, (at, em) => {
      for (let i = 0; i < 4; i++) { const t = 150 + i * 450, d = i % 2 ? 1 : -1, f = d < 0 ? 'footL' : 'footR'; at(t, { [f]: 4, x: d * 3, tilt: d * 4, lean: -1, sq: -0.05, lift: 1.5, armL: d < 0 ? 40 : 20, armR: d < 0 ? 20 : 40, mfl: 0.25, tsw: d, htilt: -d * 3 }, 'o');
        at(t + 225, { [f]: 0, lift: 0, sq: 0.08, mfl: 0 }, 'i'); }
      at(1950, { x: 0, tilt: 0, lean: 0, htilt: 0, sq: 0, tsw: 0, armL: 30, armR: 30 });
      // crouch, wiggle his bottom, pounce
      at(2250, { sq: 0.3, lean: 3, armL: 70, armR: 70, hLy: 4, hRy: 4, wide: 0.4, open: 0.2 }, 'i'); for (let i = 0; i < 5; i++) at(2400 + i * 110, { x: i % 2 ? 1.5 : -1.5, tsw: i % 2 ? 1.4 : -1.4 }, 'l');
      at(3050, { sq: -0.14, lift: 16, x: 8, lean: 4, armL: 120, armR: 120, hLy: -4, hRy: -4, tsw: 0, open: 0.9, wide: 0 }, 'o'); at(3450, { lift: 0, sq: 0.3, armL: 90, armR: 90, hLy: 4, hRy: 4, lean: 2 }, 'i'); em(3450, 'dust', [58, 96], 4);
      at(3700, { sq: 0, x: 4, lean: 0, hLy: 0, hRy: 0, armL: 40, armR: 40, open: 0.5 });
      // big ROAR
      at(3950, { lean: -3, sq: 0.1, mfl: -0.2, pitch: -0.15, open: 0.3, armL: 60, armR: 60 }, 'i');
      at(4250, { lean: 4, sq: -0.12, mfl: 1.2, msh: 0.6, open: 1, wide: 0.5, mw: 1.3, armL: 140, armR: 140, hLx: -3, hRx: 3, pitch: 0.15, x: 2, tsw: 1.5 }, 'o'); em(4250, 'gust', 'mouth', 2); em(4300, 'manefur', 'head', 4); em(4450, 'gust', 'mouth', 2);
      at(4900, { lean: 0, sq: 0, mfl: 0, msh: 0, open: 0.5, wide: 0, mw: 1, armL: 40, armR: 40, hLx: 0, hRx: 0, pitch: 0, x: 0, tsw: 0 });
      // paw swipes
      for (let i = 0; i < 4; i++) { const t = 5100 + i * 340, d = i % 2 ? 1 : -1; at(t, { armL: d < 0 ? 125 : 30, armR: d > 0 ? 125 : 30, hLx: d < 0 ? 7 : 0, hRx: d > 0 ? -7 : 0, tilt: d * 6, x: d * 2.5, open: 0.8 }, 'o'); at(t + 170, { armL: d < 0 ? 70 : 30, armR: d > 0 ? 70 : 30, open: 0.4 }, 'i'); if (i % 2) em(t, 'spark', d < 0 ? 'sideL' : 'sideR', 2); }
      at(6550, { armL: 30, armR: 30, hLx: 0, hRx: 0, tilt: 0, x: 0, open: 0.5 });
      // chases his tail round twice, then dizzy
      at(6700, { spin: 0, lean: 2, tsw: 1.4, lx: 0.8 }); at(7500, { spin: 360, tsw: -1.4 }, 'l'); at(7501, { spin: 0 }, 'l'); at(8300, { spin: 360, tsw: 1.4 }, 'l'); at(8301, { spin: 0 }, 'l');
      at(8500, { lean: 0, tsw: 0, lx: 0, htilt: 9, sqz: 0.5, tilt: -4 }); at(8750, { htilt: -9, tilt: 4 }); at(9000, { htilt: 0, tilt: 0, sqz: 0 });
      // mane shake: tosses his head and shakes his mane out, fur flies
      at(9100, { msh: 1.4, mfl: 0.5 }); for (let i = 0; i < 8; i++) at(9150 + i * 85, { htilt: i % 2 ? 10 : -10, x: i % 2 ? 1 : -1 }, 'l'); em(9300, 'manefur', 'head', 4); em(9600, 'manefur', 'head', 4);
      at(9900, { msh: 0, mfl: 0, htilt: 0, x: 0 });
      // sunny cat stretch: paws up high, tall and long, then relax
      at(10250, { armL: 175, armR: 175, sq: -0.16, lift: 2, open: 0.9, close: 0.6, mfl: 0.3, tongue: 0.25 }, 's'); at(10700, { armL: 30, armR: 30, sq: 0.08, lift: 0, open: 0.5, close: 0, mfl: 0, tongue: 0 }, 's');
      // king pose + wink
      at(11000, { lean: -1, sq: -0.04, mfl: 0.6, armL: 40, armR: 150, hRy: -3, tsw: 0.8, htilt: 5 }); at(11250, { winkR: 1 }); em(11250, 'heart', 'head', 1); at(11600, { winkR: 0 });
      at(12000, { lean: 0, sq: 0, mfl: 0, armL: 0, armR: 0, hRy: 0, tsw: 0, htilt: 0 }); }); }
  // Acorn's own dance, "Nutty Scurry" (squirrel): chattery nut nibbling with tail flicks, zig-zag darting hops, tips his acorn cap with a bow (ctp lifts it off his head),
  // a double tail-twirl spin, tosses a nut up and catches it overhead + hugs it, a foot-drum with a tail flick on every beat, tail-up pose + wink (12 s loop).
  // Channels: tsw (tail swish), tfl (tail flick up/out), ctp (cap tip). Crumbs are PRE.nutbit
  function acDance() { const RR = window.RiveRig; if (RR && RR.PRE && !RR.PRE.nutbit) RR.PRE.nutbit = { n: 3, sp: 9, vy: -9, g: 40, life: 900, r: [0.6, 1], col: ['#a8743a', '#7a4e22', '#dcae6e'], kind: 'dot' };
    ffDance('acorn', 12000, (at, em) => {
      at(0, { armL: 20, armR: 20 }); at(300, { armL: 62, armR: 62, hLx: 6, hRx: -6, hLy: -11, hRy: -11, puff: 0.3 }, 'o');
      for (let i = 0; i < 12; i++) { const t = 400 + i * 130; at(t, { open: i % 2 ? 0.15 : 0.7, sq: i % 2 ? 0.02 : 0.06 }, 'l'); if (i % 4 === 0) em(t, 'nutbit', 'mouth', 2); }
      [450, 1050, 1650].forEach((t, i) => { at(t, { tsw: i % 2 ? -1.2 : 1.2, tfl: 0.6, earL: 12, earR: 12 }, 'o'); at(t + 300, { tsw: 0, tfl: 0, earL: 0, earR: 0 }); });
      at(2100, { armL: 30, armR: 30, hLx: 0, hRx: 0, hLy: 0, hRy: 0, puff: 0, open: 0.5, sq: 0 });
      // zig-zag scurry: quick darting hops, the tail streams behind
      [[-7, 1], [6, -1], [-5, 1], [7, -1], [0, 0]].forEach(([x, d], i) => { const t = 2250 + i * 360; at(t, { sq: 0.14, lift: 0 }, 'i'); at(t + 180, { x, lift: 6, sq: -0.08, tilt: -d * 8, lean: x > 0 ? 2 : x < 0 ? -2 : 0, tsw: d * 1.3, armL: 60, armR: 60, wide: 0.3 }, 'o'); at(t + 340, { lift: 0, sq: 0.12 }, 'i'); em(t + 340, 'dust', [50 + x, 96], 2); });
      at(4250, { x: 0, tilt: 0, lean: 0, tsw: 0, sq: 0, armL: 30, armR: 30, wide: 0 });
      // tips his acorn cap: paw up, lifts and tilts the cap with a little bow + wink, pops it back on
      at(4450, { armR: 150, hRx: -7, hRy: -16, htilt: 4 }); at(4800, { ctp: 1, lean: 3, sq: 0.06, winkR: 1, armR: 160, hRy: -22, open: 0.8 }, 'o'); em(4800, 'spark', 'head', 2);
      at(5300, { ctp: 1, lean: 3 }); at(5600, { ctp: 0, lean: 0, sq: 0, winkR: 0, armR: 40, hRx: 0, hRy: 0, htilt: 0, open: 0.5 }, 'i'); at(5700, { sq: 0.08 }); at(5850, { sq: 0 });
      // tail-twirl: spins round twice with his tail flared out
      at(5950, { spin: 0, sq: 0.15, tfl: 0, lift: 0 }, 'i'); at(6150, { sq: -0.08, lift: 6, tfl: 1, armL: 120, armR: 120 }, 'o'); at(6750, { spin: 360, lift: 8 }, 'l'); at(6751, { spin: 0 }, 'l'); at(7350, { spin: 360, lift: 4 }, 'l'); at(7351, { spin: 0 }, 'l');
      at(7550, { lift: 0, sq: 0.2, tfl: 0, armL: 40, armR: 40 }, 'i'); em(7550, 'dust', [50, 96], 3); at(7700, { sq: 0 });
      // nut toss: throws a nut up, watches it, catches it overhead and hugs it
      at(7900, { armL: 70, armR: 70, hLx: 5, hRx: -5, hLy: 2, hRy: 2, sq: 0.12 }, 'i'); at(8150, { armL: 150, armR: 150, hLx: 0, hRx: 0, hLy: -6, hRy: -6, sq: -0.06, lift: 3, pitch: -0.25, open: 0.7 }, 'o'); em(8150, 'nutbit', 'head', 3);
      at(8650, { pitch: -0.35, wide: 0.5, lift: 0, armL: 130, armR: 130 }); at(8950, { armL: 165, armR: 165, sq: 0.1, pitch: -0.2, wide: 0 }, 'i'); em(8950, 'spark', 'head', 2);
      at(9300, { armL: 70, armR: 70, hLx: 7, hRx: -7, hLy: -3, hRy: -3, pitch: 0, sqz: 0.6, hap: 1, blush: 0.6, sq: 0.06, tsw: 0.8, open: 0.5 }, 'o'); em(9350, 'heart', 'head', 1); at(9700, { tsw: -0.8 });
      // foot drum: stamps his feet, a tail flick on every beat
      for (let i = 0; i < 6; i++) { const t = 9900 + i * 170, d = i % 2 ? 1 : -1; at(t, { [d < 0 ? 'footL' : 'footR']: 3.5, [d < 0 ? 'footR' : 'footL']: 0, tsw: d * 1.1, tfl: 0.4, sq: 0.05, htilt: d * 4 }, 'o'); if (i % 2) em(t, 'note', 'head', 1); }
      at(10950, { footL: 0, footR: 0, tsw: 0, tfl: 0, sq: 0, htilt: 0, sqz: 0, hap: 0.85, blush: 0, armL: 30, armR: 30, hLx: 0, hRx: 0, hLy: 0, hRy: 0 });
      at(11150, { tfl: 0.9, armR: 150, hRy: -3, htilt: 5, tilt: 3 }); at(11350, { armR: 120, winkR: 1 }); at(11550, { armR: 160 }); em(11350, 'heart', 'head', 1); at(11800, { armR: 0, hRy: 0, winkR: 0, htilt: 0, tilt: 0, tfl: 0, armL: 0 }); }); }
  // Fawn's own dance, "Fawn Prance" (baby deer): wobbly first steps with arms out for balance, springy pronking boings (ears flop up), ear-flick listening with head tilts,
  // a big leap over a log and back, a high-step prance round in a circle, sniffs a flower + happy sneeze shake, a little deer bow + arms up wink (12 s loop). Leaves are PRE.fawnleaf
  function fwDance() { const RR = window.RiveRig; if (RR && RR.PRE && !RR.PRE.fawnleaf) RR.PRE.fawnleaf = { n: 3, sp: 10, vy: -9, g: 14, life: 1600, r: [0.8, 1.2], col: ['#e8a040', '#c8642a', '#9ac85a', '#f2c45a'], kind: 'leaf' };
    ffDance('fawn', 12000, (at, em) => {
      at(0, { armL: 20, armR: 20 }); at(300, { armL: 75, armR: 75, wide: 0.35 });
      for (let i = 0; i < 6; i++) { const t = 400 + i * 260, d = i % 2 ? 1 : -1; at(t, { [d < 0 ? 'footL' : 'footR']: 3, [d < 0 ? 'footR' : 'footL']: 0, tilt: d * 7, x: d * 1.5, sq: 0.07, armL: d < 0 ? 95 : 60, armR: d < 0 ? 60 : 95, earL: d < 0 ? 10 : -6, earR: d > 0 ? 10 : -6 }, 'o'); }
      at(2000, { footL: 0, footR: 0, tilt: 0, x: 0, sq: 0, armL: 40, armR: 40, wide: 0, earL: 0, earR: 0 });
      // pronking: straight-up boings with both legs tucked, ears flop up in the air
      for (let i = 0; i < 4; i++) { const t = 2150 + i * 450; at(t, { sq: 0.2, lift: 0, footL: 0, footR: 0, earL: 14, earR: 14 }, 'i'); at(t + 210, { sq: -0.12, lift: 15, footL: 4, footR: 4, earL: -22, earR: -22, armL: 110, armR: 110, open: 0.85, tilt: i % 2 ? 6 : -6 }, 'o');
        at(t + 420, { lift: 0, sq: 0.16, footL: 0, footR: 0, armL: 50, armR: 50, earL: 10, earR: 10, open: 0.5, tilt: 0 }, 'i'); em(t + 420, 'fawnleaf', [50, 92], 2); }
      at(4100, { sq: 0, earL: 0, earR: 0, armL: 30, armR: 30 });
      // listening: tilts her head, flicks one ear then the other, looks round
      at(4350, { htilt: 14, earL: 22, earR: -8, lx: -0.7, wide: 0.3, open: 0.3 }, 's'); at(4700, { earL: 6 }); at(4850, { earL: 24 }); em(4700, 'note', 'head', 1);
      at(5200, { htilt: -14, earL: -8, earR: 22, lx: 0.7 }, 's'); at(5500, { earR: 6 }); at(5650, { earR: 24 }); at(5950, { htilt: 0, earL: 0, earR: 0, lx: 0, wide: 0, open: 0.5 }, 's');
      // leaps over a log and back
      [[6150, 12, 1], [7050, 0, -1]].forEach(([t, x, d]) => { at(t, { sq: 0.26, lean: d * 2, armL: 40, armR: 40 }, 'i'); at(t + 320, { x: x - d * 6, lift: 18, sq: -0.14, lean: d * 4, tilt: d * 6, footL: 4, footR: 4, armL: 130, armR: 130, open: 0.9 }, 'o');
        at(t + 650, { x, lift: 0, sq: 0.2, lean: 0, tilt: 0, footL: 0, footR: 0, armL: 50, armR: 50, open: 0.5 }, 'i'); em(t + 650, 'dust', [50 + x, 96], 3); em(t + 650, 'fawnleaf', [50 + x, 92], 2); at(t + 800, { sq: 0 }); });
      // high-step prance round in a circle
      at(8000, { spin: 0 }); for (let i = 0; i < 6; i++) { const t = 8050 + i * 200, d = i % 2 ? 1 : -1; at(t, { [d < 0 ? 'footL' : 'footR']: 5, [d < 0 ? 'footR' : 'footL']: 0, lift: 2.5, sq: -0.05, armL: d < 0 ? 100 : 55, armR: d < 0 ? 55 : 100 }, 'o'); at(t + 100, { lift: 0, sq: 0.06 }, 'i'); }
      at(9250, { spin: 360, footL: 0, footR: 0, lift: 0, sq: 0, armL: 30, armR: 30 }); at(9251, { spin: 0 }, 'l');
      // sniffs a flower, then a happy sneeze shake
      at(9450, { pitch: 0.2, lean: 2.5, sq: 0.06, close: 0.5, open: 0.2 }); for (let i = 0; i < 4; i++) at(9550 + i * 110, { sq: i % 2 ? 0.04 : 0.09 }, 'l'); em(9500, 'heart', 'mouth', 1);
      at(10050, { pitch: -0.2, lean: -2, sq: -0.08, close: 0.9, open: 0.15, earL: -10, earR: -10 }, 's'); at(10250, { pitch: 0.25, lean: 3, sq: 0.15, close: 0, open: 0.95, wide: 0.5, earL: 18, earR: 18 }, 'o'); em(10250, 'spark', 'mouth', 3);
      for (let i = 0; i < 6; i++) at(10350 + i * 80, { tilt: i % 2 ? 6 : -6, htilt: i % 2 ? -6 : 6 }, 'l'); at(10850, { tilt: 0, htilt: 0, pitch: 0, lean: 0, sq: 0, wide: 0, open: 0.5, earL: 0, earR: 0 });
      // little deer bow, arms up + wink
      at(11050, { lean: 4, pitch: 0.2, sq: 0.08, armL: 50, armR: 50 }); at(11350, { lean: 0, pitch: 0, sq: -0.04, armL: 150, armR: 150, winkR: 1, open: 0.8 }, 'o'); em(11350, 'heart', 'head', 2); at(11650, { winkR: 0 }); at(11850, { armL: 0, armR: 0, sq: 0, open: 0.5 }); }); }
  // Moss's own dance, "Spore Bounce" (mushroom sprite): squishy bounces with his cap bouncing on top and spores puffing out, a cap twirl while he sways, a rain dance,
  // a grow spurt (squat, shoot up tall, cap pops, spore burst), a side shuffle, a spinning-top spin with the cap spinning faster, cap-tip bow + wave + wink (12 s loop).
  // Channels: cb (cap bounce/lift), csp (cap spin, turns). Spores are PRE.spore
  function msDance() { const RR = window.RiveRig; if (RR && RR.PRE && !RR.PRE.spore) RR.PRE.spore = { n: 5, sp: 10, vy: -12, g: -3, life: 1700, r: [0.5, 1], col: ['#fff4e8', '#ffe6c8', '#f6ead2', '#ffd0c0'], kind: 'dot' };
    ffDance('moss', 12000, (at, em) => {
      for (let i = 0; i < 4; i++) { const t = 150 + i * 480; at(t, { sq: 0.24, lift: 0, cb: -0.25, armL: 30, armR: 30 }, 'i'); at(t + 220, { sq: -0.12, lift: 9, cb: 0.6, armL: 90, armR: 90, open: 0.8 }, 'o'); at(t + 440, { lift: 0, sq: 0.2, cb: -0.3, open: 0.5 }, 'i'); em(t + 440, 'spore', 'head', 4); }
      at(2150, { sq: 0, cb: 0, armL: 40, armR: 40 });
      // cap twirl: the cap spins round twice while he sways with his arms out
      at(2300, { csp: 0, armL: 110, armR: 110, wide: 0.3 }); at(3700, { csp: 2 }, 's'); at(3701, { csp: 0 }, 'l');
      for (let i = 0; i < 4; i++) at(2450 + i * 330, { tilt: i % 2 ? 7 : -7, x: i % 2 ? 2 : -2, sq: 0.04 }); em(2700, 'spore', 'head', 3); em(3300, 'spore', 'head', 3);
      at(3850, { tilt: 0, x: 0, sq: 0, armL: 40, armR: 40, wide: 0 });
      // rain dance: arms up, slow sways, raindrops
      at(4050, { armL: 160, armR: 160, hLx: -2, hRx: 2 }); for (let i = 0; i < 4; i++) { const t = 4250 + i * 380, d = i % 2 ? 1 : -1; at(t, { tilt: d * 10, x: d * 3, htilt: -d * 5, sq: 0.05 }, 's'); em(t, 'drop', 'head', 2); }
      at(5800, { tilt: 0, x: 0, htilt: 0, sq: 0, armL: 50, armR: 50, hLx: 0, hRx: 0 });
      // grow spurt: squats, shoots up tall, the cap pops up and spores burst out
      at(6050, { sq: 0.36, cb: -0.3, armL: 20, armR: 20, sqz: 0.6 }, 'i'); at(6400, { sq: -0.2, lift: 6, cb: 1.2, armL: 150, armR: 150, sqz: 0, wide: 0.6, open: 0.95 }, 'o'); em(6400, 'spore', 'head', 7); em(6450, 'spark', 'head', 2);
      at(6800, { sq: 0.12, lift: 0, cb: -0.2, wide: 0, open: 0.5, armL: 60, armR: 60 }, 'i'); at(7000, { sq: 0, cb: 0 });
      // side shuffle, his cap wobbling
      [-3, -6, -9, -5, 0, 5, 9, 5, 0].forEach((x, i) => { const t = 7150 + i * 150; at(t, { x, [i % 2 ? 'footL' : 'footR']: 2.5, [i % 2 ? 'footR' : 'footL']: 0, lean: i < 3 ? -2 : i > 4 && i < 8 ? 2 : 0, tilt: i % 2 ? 4 : -4, lift: i % 2 ? 1.2 : 0 }, 'l'); });
      at(8550, { footL: 0, footR: 0, lean: 0, tilt: 0, lift: 0, x: 0 });
      // spinning top: spins round, the cap spinning even faster, spores fly
      at(8650, { spin: 0, csp: 0, sq: 0.15, armL: 40, armR: 40 }, 'i'); at(8850, { sq: -0.05, lift: 5, armL: 120, armR: 120 }, 'o'); at(9550, { spin: 360, csp: 1, lift: 3 }); at(9551, { spin: 0, csp: 0 }, 'l'); em(9100, 'spore', 'head', 4);
      at(9750, { lift: 0, sq: 0.2, armL: 40, armR: 40 }, 'i'); em(9750, 'dust', [50, 96], 3); at(9900, { sq: 0 });
      // cap-tip bow, wave + wink
      at(10150, { lean: 3, pitch: 0.25, sq: 0.08, cb: 0.3, armL: 30, armR: 30 }); at(10500, { lean: 0, pitch: 0, sq: -0.04, cb: 0 });
      at(10700, { armR: 150, hRy: -3, htilt: 5, tilt: 3, sq: 0 }); at(10900, { armR: 120, winkR: 1 }); at(11100, { armR: 160 }); em(10900, 'heart', 'head', 1); at(11300, { winkR: 0 }); em(11000, 'spore', 'head', 3);
      at(11700, { armR: 0, hRy: 0, htilt: 0, tilt: 0, armL: 0 }); }); }
  // Sprout's own dance, "Bloom Boogie" (sapling sprite): sprouts from a squashed seed into a tall stretch as his leaves unfurl and the bud blooms, sunny sways with arms up,
  // flaps his leaves like wings for tiny hops, gets bent by gusts of wind both ways, a double twirl (petals fly), root stomps that pulse the flower, full-bloom V pose + wink (12 s loop).
  // Channels: stw (stem wobble/bend), lfl (leaf flap), blm (bloom 0 bud -> 1.4 open), fsp (flower spin, turns). Petals are PRE.petal
  function spDance() { const RR = window.RiveRig; if (RR && RR.PRE && !RR.PRE.petal) RR.PRE.petal = { n: 3, sp: 10, vy: -8, g: 10, life: 1600, r: [0.8, 1.2], col: ['#ffb6d4', '#ff9ac4', '#ffd6e6'], kind: 'leaf' };
    ffDance('sprout', 12000, (at, em) => {
      at(0, { armL: 20, armR: 20 }); at(250, { sq: 0.4, lift: 0, lfl: -0.8, blm: 0, armL: 10, armR: 10, sqz: 0.7, open: 0.2 }, 'i');
      at(800, { sq: -0.16, lift: 4, lfl: 0.9, stw: 0.4, armL: 150, armR: 150, sqz: 0, wide: 0.4, open: 0.9 }, 'o'); at(1100, { blm: 1.1 }, 'o'); em(1100, 'petal', 'head', 3); em(1100, 'spark', 'head', 2);
      at(1500, { sq: 0.04, lift: 0, lfl: 0, stw: -0.3, wide: 0, open: 0.5, blm: 0.9 }); at(1800, { sq: 0, stw: 0, armL: 60, armR: 60 });
      // sun soak: arms up wide, slow sunny sways, the sapling swings on top
      at(2000, { armL: 160, armR: 160, hLx: -3, hRx: 3, sqz: 0.4, hap: 1 }); for (let i = 0; i < 4; i++) { const t = 2250 + i * 420, d = i % 2 ? 1 : -1; at(t, { tilt: d * 9, x: d * 2.5, stw: -d, lfl: 0.3, htilt: d * 3 }, 's'); if (!(i % 2)) em(t, 'spark', 'head', 1); }
      at(4000, { tilt: 0, x: 0, stw: 0, lfl: 0, htilt: 0, sqz: 0, hap: 0.85, armL: 40, armR: 40, hLx: 0, hRx: 0 });
      // leaf flaps: flaps his two leaves like little wings and tries to fly (tiny hops)
      for (let i = 0; i < 8; i++) at(4150 + i * 140, { lfl: i % 2 ? -0.5 : 1.3, armL: i % 2 ? 60 : 110, armR: i % 2 ? 60 : 110 }, 'l');
      [4250, 4700].forEach(t => { at(t, { sq: 0.14, lift: 0 }, 'i'); at(t + 200, { sq: -0.08, lift: 7 }, 'o'); at(t + 400, { lift: 0, sq: 0.12 }, 'i'); }); at(5400, { lfl: 0, sq: 0, armL: 40, armR: 40 }); em(4500, 'petal', 'head', 2);
      // windy day: a gust bends him and his sapling one way, then the other
      [[5600, -1], [6300, 1]].forEach(([t, d]) => { at(t, { lean: d * 4, tilt: d * 10, x: d * 3, stw: -d * 1.4, lfl: 0.6, armL: d < 0 ? 140 : 40, armR: d < 0 ? 40 : 140, sqz: 0.5, open: 0.3 }, 'o'); em(t, 'gust', d < 0 ? 'sideR' : 'sideL', 2); em(t + 100, 'petal', 'head', 2); at(t + 450, { stw: -d * 0.9, lfl: 0.2 }); });
      at(7000, { lean: 0, tilt: 0, x: 0, stw: 0.4, lfl: 0, armL: 40, armR: 40, sqz: 0, open: 0.5 }, 's'); at(7200, { stw: 0 });
      // double twirl, leaves out, petals fly, the flower spins too
      at(7300, { spin: 0, fsp: 0, sq: 0.14, lift: 0 }, 'i'); at(7500, { sq: -0.06, lift: 5, lfl: 1, armL: 130, armR: 130 }, 'o'); at(8000, { spin: 360, lift: 7 }, 'l'); at(8001, { spin: 0 }, 'l'); at(8500, { spin: 360, fsp: 2, lift: 4 }, 'l'); at(8501, { spin: 0, fsp: 0 }, 'l'); em(7800, 'petal', 'head', 3); em(8300, 'petal', 'head', 3);
      at(8700, { lift: 0, sq: 0.2, lfl: 0, armL: 40, armR: 40 }, 'i'); em(8700, 'dust', [50, 96], 3); at(8850, { sq: 0 });
      // root stomps: the flower pulses open on every stomp
      for (let i = 0; i < 4; i++) { const t = 9000 + i * 300, d = i % 2 ? 1 : -1, f = d < 0 ? 'footL' : 'footR'; at(t, { [f]: 5, lift: 1.5, tilt: -d * 4, sq: -0.05, blm: 0.5, armL: d < 0 ? 90 : 40, armR: d < 0 ? 40 : 90 }, 'o'); at(t + 150, { [f]: 0, lift: 0, tilt: d * 2, sq: 0.15, blm: 1.2, stw: d * 0.6 }, 'i'); em(t + 150, 'dust', [50 + d * 12, 96], 2); }
      at(10300, { tilt: 0, sq: 0, blm: 0.8, stw: 0, armL: 40, armR: 40 });
      at(10550, { armL: 160, armR: 160, blm: 1.4, lfl: 0.8, sq: -0.05, open: 0.8 }, 'o'); em(10550, 'petal', 'head', 4); at(10800, { winkR: 1 }); em(10800, 'heart', 'head', 1); at(11100, { winkR: 0 });
      at(11700, { armL: 0, armR: 0, blm: 0, lfl: 0, sq: 0, open: 0.5 }); }); }
  // Flicker's (key ember) own dance, "Phoenix Inferno": ignites (wing rub sparks, flare-up), juggles fireballs wing to wing over his head, spins inside a fire tornado,
  // curls into a flame cocoon and bursts out reborn (fire shockwave), hot-foot hops inside a ring of fire, then a giant flaming phoenix spirit spreads its wings behind him + wink (12.5 s loop).
  // Channels: wfl, wsp, cfl + fire FX (drawn in the ember fire block of the update): fj/fjo fireball juggle, ftor tornado, fcoc cocoon, fbst burst 0->1, fring ground ring, fphx phoenix spirit
  function emDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@ember']) return; if (RR.PRE && !RR.PRE.ember) RR.PRE.ember = { n: 5, sp: 12, vy: -16, g: -6, life: 1200, r: [0.6, 1.2], col: ['#ffd23a', '#ff8a2a', '#ff5a1e', '#fff3a0'], kind: 'dot' };
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.5]], mw: [[0, 1]], winkR: [[0, 0]], wide: [[0, 0]], sqz: [[0, 0]], blush: [[0, 0]] }, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    ['wfl', 'wsp', 'cfl', 'fj', 'fjo', 'ftor', 'fcoc', 'fbst', 'fring', 'fphx', 'spin', 'lift', 'sq', 'x', 'tilt', 'htilt', 'pitch', 'armL', 'armR', 'footL', 'footR'].forEach(k => { K[k] = [[0, 0]]; });
    // 1 ignite: crouches, rubs his wings together (sparks), then flares up with his flames blazing
    at(100, { sq: 0.25, pitch: 0.15, armL: 20, armR: 20, sqz: 0.6, hap: 0.3, open: 0 }, 'i');
    for (let i = 0; i < 4; i++) { const t = 250 + i * 180; at(t, { armL: i % 2 ? 30 : 55, armR: i % 2 ? 55 : 30 }); em(t, 'spark', 'body', 2); }
    at(1000, { sq: -0.15, lift: 10, pitch: -0.1, armL: 150, armR: 150, wsp: 1, wfl: 1, cfl: 1.5, sqz: 0, wide: 1, hap: 0.85, open: 1 }, 'o'); em(1000, 'ember', 'head', 10); em(1000, 'spark', 'head', 4);
    at(1350, { lift: 0, sq: 0.15, pitch: 0, wsp: 0, wfl: 0.2, cfl: 0.6, wide: 0, armL: 70, armR: 70, open: 0.5 }, 'i');
    // 2 fireball juggle: 5 throws in an arc over his head from wing to wing
    at(1450, { fjo: 0, fj: 0, sq: 0 }); at(1600, { fjo: 1 }); at(4000, { fj: 5 }, 'l');
    for (let k = 0; k < 5; k++) { const t = 1500 + k * 500, sd = k % 2 ? 1 : -1, thr = sd < 0 ? 'armL' : 'armR', cat = sd < 0 ? 'armR' : 'armL';
      at(t, { [thr]: 150, [cat]: 80, tilt: -sd * 4, htilt: -sd * 6 }); at(t + 100, { lift: 3, sq: -0.05 }, 'o'); at(t + 260, { [thr]: 80, [cat]: 115, htilt: sd * 6 }); at(t + 420, { lift: 0, sq: 0.08 }, 'i'); em(t, 'spark', sd < 0 ? 'pawL' : 'pawR', 2); }
    at(4050, { fjo: 0, cfl: 1, tilt: 0, htilt: 0, sq: 0 }); em(4050, 'ember', 'pawR', 5);
    // 3 fire tornado: flames swirl up round him while he spins 3 times and rises
    at(4200, { ftor: 0, spin: 0, armL: 80, armR: 80, lift: 0, sq: 0.1, cfl: 0.6 }); at(4600, { ftor: 1.2, armL: 125, armR: 125, wfl: 1, cfl: 1.2, lift: 4, sq: 0, open: 0.9 }, 'o');
    at(6100, { spin: 1080, lift: 14 }, 'io'); at(6101, { spin: 0 }, 'l'); [4700, 5100, 5500, 5900].forEach(t => em(t, 'ember', 'body', 4));
    at(6500, { ftor: 0, lift: 0, wfl: 0.2, cfl: 0.4, armL: 60, armR: 60, sq: 0.2, open: 0.5 }, 'i');
    // 4 rebirth: curls up small inside a flame cocoon, shivers, then bursts out with a fire shockwave
    at(6750, { sq: 0.42, pitch: 0.3, armL: 8, armR: 8, sqz: 1, hap: 0, cfl: 0, fcoc: 0, open: 0 }, 'i'); at(7350, { fcoc: 1.4 }, 'io');
    for (let i = 0; i < 6; i++) at(6900 + i * 90, { x: i % 2 ? 1.2 : -1.2 }); at(7450, { x: 0 });
    at(7480, { fbst: 0 }, 'l'); at(7500, { fcoc: 1.4, sq: 0.42, open: 0 }); at(7580, { fcoc: 0 }, 'o'); at(8200, { fbst: 1 }, 'o'); at(8210, { fbst: 0 }, 'l');
    at(7750, { sq: -0.25, lift: 20, pitch: -0.15, armL: 170, armR: 170, wsp: 1.3, wfl: 1.3, cfl: 1.5, sqz: 0, wide: 1, hap: 0.9, open: 1 }, 'o'); em(7500, 'ember', 'body', 12); em(7520, 'spark', 'body', 6);
    at(8300, { lift: 6, pitch: 0, wide: 0.3, wfl: 0.8 });
    // 5 ring of fire: lands, flames burst up in a ring round him and he does hot-foot hops
    at(8550, { lift: 0, sq: 0.22, wsp: 0, armL: 90, armR: 90, fring: 0, cfl: 0.8 }, 'i'); at(8900, { fring: 1.2, sq: 0, open: 0.8 }, 'o');
    for (let i = 0; i < 6; i++) { const t = 8950 + i * 240, d = i % 2 ? 1 : -1; at(t, { [d < 0 ? 'footL' : 'footR']: 6, lift: 5, x: d * 3, tilt: d * 4, wide: 0.8, armL: d < 0 ? 145 : 100, armR: d < 0 ? 100 : 145, wfl: 0.9 }, 'o');
      at(t + 130, { lift: 0, footL: 0, footR: 0 }, 'i'); em(t + 60, 'ember', d < 0 ? 'footL' : 'footR', 3); }
    at(10350, { fring: 0, x: 0, tilt: 0, wide: 0, wfl: 0, open: 0.5 });
    // 6 phoenix spirit: a giant flaming phoenix spreads its wings behind him, wings up, wink
    at(10500, { fphx: 0, armL: 70, armR: 70, sq: 0.15 }); at(11000, { fphx: 1.2, wsp: 1.3, armL: 165, armR: 165, cfl: 1.3, lift: 5, sq: -0.08, tilt: 3, htilt: 4, open: 1 }, 'o'); em(11000, 'ember', 'head', 8);
    at(11500, { winkR: 1, open: 0.6 }); at(11850, { winkR: 0 }); em(11500, 'heart', 'head', 2); at(12000, { fphx: 0, lift: 0, wsp: 0, cfl: 0.3 }, 'io');
    at(12300, { armL: 0, armR: 0, tilt: 0, htilt: 0, x: 0, lift: 0, sq: 0, pitch: 0, footL: 0, footR: 0, wsp: 0, wfl: 0, cfl: 0, fj: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < 12500) K[p].push([12500, K[p][0][1], 'io']); }
    RR.add({ 'dance@ember': { loop: 12500, k: K, ev } }); }
  // Drako's own dance, "Rawr Rumble" (a baby dragon trying to be a big scary dragon): tail-thump groove (tail curls up and slams the ground on the beat), flap-hop - flaps hard, wobbles up
  // into the air, runs out of puff and plops down; ah-ah-CHOO fire sneeze (fire burst + nostril smoke, recoils, blushes); chases his own tail round twice and gets dizzy; big RAWR with claws up,
  // wings spread and fire; wing-fan sway; smoke puff + wave + wink (12.4 s loop). Channels: wfl (wing flap), wsp (wings spread), tsw (tail swish), tcu (tail curl up / slam). Particles PRE.dfire, PRE.dsmoke
  function drDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@drako']) return;
    if (RR.PRE && !RR.PRE.dfire) { RR.PRE.dfire = { n: 6, sp: 22, vy: -8, g: -14, life: 720, r: [1.8, 3.4], col: ['#ffe14a', '#ffa02a', '#ff5a1e'], kind: 'puff' }; RR.PRE.dsmoke = { n: 2, sp: 4, vy: -9, g: -4, life: 1200, r: [1.6, 3], col: ['#eef0f8', '#dde2ee'], kind: 'puff' }; }
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.5]], mw: [[0, 1]], winkR: [[0, 0]], wide: [[0, 0]], sqz: [[0, 0]], blush: [[0, 0]] }, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    ['wfl', 'wsp', 'tsw', 'tcu', 'armL', 'armR', 'hLx', 'hRx', 'hLy', 'hRy', 'tilt', 'htilt', 'x', 'lift', 'sq', 'lean', 'pitch', 'footL', 'footR', 'spin'].forEach(k => { K[k] = [[0, 0]]; });
    // tail-thump groove: the tail curls up, then slams the ground on the beat (dust at the tail), body bounces, paws bob, head bops
    for (let i = 0; i < 4; i++) { const t = 100 + i * 640, d = i % 2 ? 1 : -1; at(t, { tcu: 0.85, lift: 2.5, sq: -0.06, armL: d < 0 ? 70 : 25, armR: d > 0 ? 70 : 25, htilt: d * 4, footL: d < 0 ? 5 : 0, footR: d > 0 ? 5 : 0, tsw: d * 0.3 }, 'o');
      at(t + 360, { tcu: -0.25, lift: 0, sq: 0.2, footL: 0, footR: 0, wfl: 0.35 }, 'i'); at(t + 520, { sq: 0.04, wfl: 0 }); em(t + 360, 'dust', [87, 93], 3); }
    // flap-hop: crouch, flaps hard and wobbles up into the air, runs out of puff and plops down, dizzy
    at(2650, { tcu: 0, tsw: 0, armL: 50, armR: 50, htilt: 0, sq: 0.26, wsp: 0.6 }, 'i'); at(2900, { wfl: 1.5, lift: 10, sq: -0.1, sqz: 0.7, hap: 0.4, tcu: 0.25, armL: 95, armR: 95, footL: 4, footR: 4 }, 'o');
    for (let i = 0; i < 5; i++) at(3100 + i * 190, { lift: 12 + (i % 2) * 3, tilt: i % 2 ? 4 : -4, x: i % 2 ? 2.5 : -2.5 }); at(4000, { wfl: 0.25, sqz: 0, wide: 0.7, open: 0.9 });
    at(4250, { lift: 0, sq: 0.27, tilt: 0, x: 0, footL: 0, footR: 0, armL: 30, armR: 30, wsp: 0, tcu: -0.2 }, 'i'); em(4250, 'dust', [40, 95], 3); em(4250, 'dust', [60, 95], 3); at(4300, { wfl: 0 });
    for (let i = 0; i < 3; i++) at(4400 + i * 120, { htilt: i % 2 ? 6 : -6, sq: 0.08 }); at(4700, { htilt: 0, wide: 0, open: 0.5, hap: 0.85, sq: 0, tcu: 0 });
    // ah-ah-CHOO: nose twitches, rears back twice, then sneezes a fire burst with nostril smoke, recoils back a step, blushes
    at(4850, { pitch: -0.2, wide: 0.6, open: 0.35, hap: 0.3 }); for (let i = 0; i < 4; i++) at(4900 + i * 70, { htilt: i % 2 ? 1.5 : -1.5 }, 'l'); at(5180, { htilt: 0, pitch: -0.08 });
    at(5350, { pitch: -0.38, sqz: 0.85, wide: 0, sq: -0.1, armL: 45, armR: 45, tcu: 0.3 }, 'i');
    at(5560, { pitch: 0.32, lean: 2, sq: 0.14, open: 1, mw: 1.35, x: -3.5, lift: 3, wsp: 1, wfl: 0.6, tcu: 0.9, sqz: 0.4 }, 'o'); for (let i = 0; i < 5; i++) em(5560 + i * 70, 'dfire', 'mouth', 4); em(5700, 'dsmoke', 'mouth', 2); em(5900, 'dsmoke', 'mouth', 2);
    at(5800, { lift: 0, sq: 0.06, wfl: 0 }, 'i'); at(6150, { pitch: 0, lean: 0, x: 0, open: 0.5, mw: 1, wsp: 0, tcu: 0, sqz: 0, hap: 0.85, blush: 0.8, sq: 0 }); at(6600, { blush: 0 });
    // tail chase: peeks at his tail, then spins round twice after it (tail swung out, little hops), stops dizzy
    at(6350, { tsw: -1, htilt: 8, armL: 60, armR: 60 }); at(6500, { tsw: 1.4, htilt: 0, wsp: 0.5, spin: 0 }); at(7450, { spin: 720 }, 'io'); at(7451, { spin: 0 }, 'l');
    for (let i = 0; i < 4; i++) { const t = 6600 + i * 220; at(t, { lift: 3.5, footL: i % 2 ? 0 : 5, footR: i % 2 ? 5 : 0 }, 'o'); at(t + 110, { lift: 0, footL: 0, footR: 0 }, 'i'); }
    at(7550, { tsw: 0, wsp: 0, armL: 30, armR: 30 }); for (let i = 0; i < 4; i++) at(7600 + i * 130, { htilt: i % 2 ? 7 : -7, tilt: i % 2 ? -3 : 3 }); at(8150, { htilt: 0, tilt: 0 });
    // big RAWR: crouch, then rears up with claws high, wings spread wide, tail up, roars fire with sparks, shakes
    at(8250, { sq: 0.22, armL: 40, armR: 40, hap: 0.6 }, 'i'); at(8550, { sq: -0.12, lift: 4, armL: 165, armR: 165, wsp: 1.4, wfl: 0.45, tcu: 1, open: 1, mw: 1.5, wide: 0.3, sqz: 0.35, hap: 0.7, pitch: -0.12 }, 'o');
    for (let i = 0; i < 6; i++) at(8650 + i * 80, { htilt: i % 2 ? 2.5 : -2.5 }, 'l'); for (let i = 0; i < 4; i++) em(8580 + i * 90, 'dfire', 'mouth', 4); em(8600, 'spark', 'head', 5); em(9000, 'dsmoke', 'mouth', 2);
    at(9300, { sq: 0.08, lift: 0, armL: 40, armR: 40, wsp: 0.2, wfl: 0, tcu: 0, open: 0.5, mw: 1, wide: 0, sqz: 0, hap: 0.85, htilt: 0, pitch: 0 }, 'i');
    // wing-fan sway: wings fanned open, sways side to side with the tail wagging the other way, paws waving in turn
    at(9650, { wsp: 1, sq: 0 }); for (let i = 0; i < 4; i++) { const d = i % 2 ? 1 : -1, t = 9750 + i * 360; at(t, { x: d * 5, tilt: d * 7, tsw: -d * 1.1, armL: d < 0 ? 125 : 35, armR: d > 0 ? 125 : 35, lift: 1.5, hap: 1 }); at(t + 180, { lift: 0 }, 'i'); }
    at(11250, { x: 0, tilt: 0, tsw: 0, wsp: 0.3, armL: 30, armR: 30 });
    // smoke puff + wave + wink, tail curls up behind him
    at(11400, { tilt: 5, htilt: 6, armL: 30, armR: 150, hRx: -6, hRy: -8, tcu: 0.55, wsp: 0.6 }); at(11600, { winkR: 1 }); at(11950, { winkR: 0 }); em(11600, 'heart', 'head', 2); em(11500, 'dsmoke', 'mouth', 2);
    at(12200, { armL: 0, armR: 0, hLx: 0, hRx: 0, hLy: 0, hRy: 0, tilt: 0, htilt: 0, x: 0, lift: 0, sq: 0, lean: 0, pitch: 0, footL: 0, footR: 0, wsp: 0, tcu: 0, tsw: 0 });
    // hold every channel between moves (a key more than 450 ms after the previous one only ramps over its last 300 ms)
    for (const p in K) { const k = K[p].sort((a, b) => a[0] - b[0]), o = [k[0]]; for (let i = 1; i < k.length; i++) { if (p !== 'spin' && k[i][0] - k[i - 1][0] > 450) o.push([k[i][0] - 300, k[i - 1][1], 'io']); o.push(k[i]); } if (o[o.length - 1][0] < 12400) o.push([12400, o[0][1], 'io']); K[p] = o; }
    RR.add({ 'dance@drako': { loop: 12400, k: K, ev } }); }
  // Jinni's own dance, "Wish Whirl" (a tiny genie floating out of his golden lamp): a lamp-side sway with folded arms, swirls down into the lamp (it glows and rattles) and POOFS back out
  // arms-up, a belly-dancer shimmy with hands overhead, a whirlwind double spin up high with the wisp tail twisting like a little tornado, a magic-carpet glide across the stage
  // (the lamp drags behind him), three wish-granting finger snaps that flash the lamp, a deep "your wish is my command" bow, pose + wink (12 s loop).
  // Channels: gin (swirl into the lamp 0-1), gwh (wisp whirl), glo (lamp glow). Sparkles are PRE.jinni
  function jnDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@jinni']) return; if (RR.PRE && !RR.PRE.jinni) RR.PRE.jinni = { n: 4, sp: 14, vy: -6, g: 4, life: 1200, r: [1, 2], col: ['#fff6b0', '#ffffff', '#ffd84a', '#8ff2e0'], kind: 'star' };
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.5]], mw: [[0, 1]], winkR: [[0, 0]], wide: [[0, 0]], blush: [[0, 0]], gin: [[0, 0]], gwh: [[0, 0.3]], glo: [[0, 0]], hLx: [[0, 0]], hRx: [[0, 0]], hLy: [[0, 0]], hRy: [[0, 0]],
      x: [[0, 0]], tilt: [[0, 0]], htilt: [[0, 0]], lift: [[0, 0]], sq: [[0, 0]], lean: [[0, 0]], turn: [[0, 0]], pitch: [[0, 0]], spin: [[0, 0]], armL: [[0, 0]], armR: [[0, 0]] }, LP = 12000, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    // lamp-side sway: arms folded (paws crossed on his chest), head bobbing the other way, wisp swishing
    for (let i = 0; i < 4; i++) { const d = i % 2 ? 1 : -1, t = 100 + i * 450; at(t + 225, { x: d * 6, tilt: d * 7, htilt: -d * 5, lift: 2, armL: 55, armR: 55, hLx: 9, hRx: -9, hLy: -4, hRy: -4, gwh: 0.45 }); at(t + 450, { x: d * 2, tilt: d * 2, lift: 0.5 }); if (!(i % 2)) em(t + 225, 'note', 'head', 1); }
    // swirls down into the lamp (glow builds, the lamp rattles while he's inside), then POOF - out he pops, arms up, eyes wide
    at(1950, { x: 0, tilt: 0, htilt: 0, lift: 0, armL: 30, armR: 30, hLx: 0, hRx: 0, hLy: 0, hRy: 0, gin: 0, glo: 0.2, spin: 0, open: 0.5 });
    at(2400, { gin: 1, glo: 1, spin: 360, open: 0.9, wide: 0.6 }, 'i'); at(2401, { spin: 0 }, 'l');
    at(2900, { gin: 1, glo: 1.3, wide: 0 }); at(3150, { gin: 0, glo: 0.6, lift: 10, sq: -0.2, armL: 170, armR: 170, wide: 1, open: 1, mw: 1.35, hap: 0 }, 'o'); em(3150, 'jinni', [70, 74], 6); em(3150, 'spark', 'head', 3);
    at(3550, { lift: 3, sq: 0.08, armL: 120, armR: 120, wide: 0, open: 0.6, mw: 1, hap: 0.85, glo: 0.2 }, 'i');
    // belly-dancer shimmy: hands up overhead, hips shimmy fast side to side while he travels left then right
    at(3700, { armL: 160, armR: 160, hLx: 6, hRx: -6, hLy: -4, hRy: -4, lift: 3, sq: 0, x: 0, tilt: 0, lean: 0, htilt: 0 });
    for (let i = 0; i < 12; i++) at(3850 + i * 150, { tilt: i % 2 ? 5 : -5, lean: i % 2 ? 2.5 : -2.5, htilt: i % 2 ? -3 : 3, x: i < 6 ? -i * 1.6 : -9.6 + (i - 5) * 3, gwh: 0.7 }, 'io');
    [4100, 4700, 5300].forEach(t => em(t, 'note', 'head', 1));
    // whirlwind: spins twice rising high, the wisp tail twisting like a little tornado, sparkles flying off
    at(5700, { x: 0, tilt: 0, lean: 0, htilt: 0, lift: 3, spin: 0, armL: 100, armR: 100, hLx: 0, hRx: 0, hLy: 0, hRy: 0, gwh: 0.4 });
    at(6800, { spin: 720, lift: 15, gwh: 1.4, armL: 125, armR: 125, open: 0.8 }, 'io'); at(6801, { spin: 0 }, 'l'); em(6100, 'jinni', 'body', 3); em(6600, 'jinni', 'body', 3);
    at(7100, { lift: 6, gwh: 0.4, armL: 70, armR: 70, open: 0.5, turn: 0, x: 0 }, 'i');
    // magic-carpet glide: leans into it and glides left, then right, one arm pointing ahead (the lamp drags along behind him)
    at(7600, { x: -12, tilt: -7, turn: -0.3, armL: 140, armR: 40, lift: 5 }, 'io'); at(8300, { x: 12, tilt: 8, turn: 0.3, armL: 40, armR: 140, lift: 8 }, 'io'); at(8550, { x: 4, tilt: 0, turn: 0, lift: 3, armL: 50, armR: 50 }, 'io');
    // three wishes: three finger snaps overhead, each one flashes the lamp and sends up sparkles
    [8750, 9150, 9550].forEach((t, i) => { at(t, { armR: 150, hRx: -4, hRy: -6, sq: 0.06, x: 4 - i * 2, glo: 0.2, htilt: 0 }, 'i'); at(t + 160, { armR: 125, sq: -0.04, glo: 1, htilt: 4 }, 'o'); at(t + 380, { glo: 0.25, htilt: 0 }); em(t + 160, 'jinni', 'pawR', 3); });
    // "your wish is my command": folds his arms and bows deep, then pops back up
    at(10000, { armR: 55, armL: 55, hLx: 9, hRx: -9, hLy: -4, hRy: -4, x: 0, lift: 2, sq: 0, pitch: 0 }); at(10400, { pitch: 0.35, sq: 0.12, lift: 0 }, 'io'); at(10750, { pitch: 0, sq: -0.05, lift: 4 }, 'o');
    // pose + wink: one paw up with a sparkle, the other low
    at(11000, { armR: 140, armL: 30, hLx: 0, hRx: -6, hLy: 0, hRy: -8, htilt: 6, winkR: 0, sq: 0 }); at(11250, { winkR: 1 }); at(11550, { winkR: 0 }); em(11250, 'heart', 'head', 2); em(11250, 'jinni', 'pawR', 2);
    at(11850, { armR: 0, armL: 0, hRx: 0, hRy: 0, htilt: 0, lift: 0, x: 0, glo: 0, gwh: 0.3 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@jinni': { loop: LP, k: K, ev } }); }
  // Hana's own dance, "Binky Bounce" (she's a kid in a bunny suit, so she dances like a happy bunny): bunny hops with paws held up at her chest, a hind-foot thump,
  // two binkies (the twisting mid-air kick rabbits do when they're happy), ear-flop peek-a-boo, a cotton-tail wiggle with her back to you, a hop-spin with ears streaming out,
  // bunny-paw pose + wink (11.6 s loop). Channels: flL / flR (that ear flops forward), tw (tail wiggle), dsw (hood drawstrings swing)
  function hnDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@hana']) return;
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.5]], mw: [[0, 1]], flL: [[0, 0]], flR: [[0, 0]], tw: [[0, 0]], dsw: [[0, 0]] }, LP = 11600, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    for (let i = 0; i < 4; i++) { const d = i % 2 ? 1 : -1, t = 150 + i * 420;
      at(t, { x: d * 3, sq: 0.22, lift: 0, tilt: 0, armL: 100, armR: 100, hLx: 5, hRx: -5, hLy: -7, hRy: -7, earL: 4, earR: 4, footL: 0, footR: 0, dsw: 0 }, 'i');
      at(t + 210, { x: d * 7, sq: -0.12, lift: 11, tilt: d * 5, earL: -8, earR: -8, footL: 3, footR: 3, dsw: -d * 0.7 }, 'o'); em(t, 'dust', [50 + d * 3, 96], 1); if (i % 2) em(t + 210, 'note', 'head', 1); }
    // hind-foot thump: stands tall with ears perked and thumps her foot three times
    at(1850, { x: 0, tilt: 0, lift: 0, lean: 0, sq: 0.15, armL: 70, armR: 70, hLy: -4, hRy: -4, hLx: 3, hRx: -3, earL: 12, earR: 12, footL: 0, footR: 0, dsw: 0 }, 'i');
    for (let i = 0; i < 3; i++) { const t = 2050 + i * 330; at(t, { footR: 7, sq: -0.05, lean: -1.5, tilt: -3 }, 'o'); at(t + 150, { footR: 0, sq: 0.16, tilt: 0, lean: 0 }, 'i'); em(t + 150, 'dust', [58, 96], 2); }
    // two binkies: crouch, leap, twist the body one way and kick the feet the other, ears flying
    [[3150, 1], [4100, -1]].forEach(([t, d]) => { at(t, { sq: 0.3, lift: 0, armL: 40, armR: 40, hLx: 0, hRx: 0, hLy: 0, hRy: 0, earL: 0, earR: 0, turn: 0, tilt: 0, footL: 0, footR: 0, flL: 0, flR: 0 }, 'i');
      at(t + 250, { sq: -0.2, lift: 19, turn: d * 0.75, tilt: -d * 14, footL: d > 0 ? 7 : 2, footR: d > 0 ? 2 : 7, armL: 150, armR: 150, earL: 20, earR: 20, flL: 0.25, flR: 0.25, open: 0.9, dsw: d }, 'o'); em(t + 250, 'spark', 'head', 3);
      at(t + 600, { turn: 0, tilt: 0, lift: 6, footL: 0, footR: 0, flL: 0, flR: 0, dsw: 0 });
      at(t + 780, { lift: 0, sq: 0.28, armL: 60, armR: 60, earL: -6, earR: -6, open: 0.5 }, 'i'); em(t + 780, 'dust', [43, 96], 2); em(t + 780, 'dust', [57, 96], 2); });
    // ear-flop peek-a-boo: one ear flops over her face, she peeks round it, swaps ears, both flop, then she shakes them back up
    at(5100, { sq: 0, earL: 0, earR: 0, armL: 30, armR: 30 });
    at(5400, { flL: 1, flR: 0, htilt: -6, tilt: -3 }); at(5800, { flL: 1, flR: 0, htilt: 7, tilt: 4, x: 3, open: 0.7 }); em(5800, 'note', 'head', 1);
    at(6150, { flL: 0, flR: 1, htilt: -7, tilt: -4, x: -3 }); at(6550, { flL: 1, flR: 1, htilt: 0, tilt: 0, x: 0, sq: 0.12, open: 0.5 });
    for (let i = 0; i < 6; i++) at(6750 + i * 90, { htilt: i % 2 ? 9 : -9, earL: i % 2 ? 14 : -4, earR: i % 2 ? -4 : 14, flL: 1 - i / 5, flR: 1 - i / 5, sq: 0.05 }, 'l');
    at(7350, { htilt: 0, earL: 14, earR: 14, flL: 0, flR: 0, sq: 0 }, 'o'); em(7350, 'spark', 'head', 2);
    // cotton-tail wiggle: turns her back to you and wiggles her fluffy tail, then turns back
    at(7500, { spin: 0, earL: 4, earR: 4 }); at(7900, { spin: 180, tw: 0, tilt: 0 });
    for (let i = 0; i < 6; i++) at(8000 + i * 140, { tw: 1, x: i % 2 ? 2.5 : -2.5, tilt: i % 2 ? 4 : -4, htilt: i % 2 ? -3 : 3 }, 'l'); em(8300, 'note', 'head', 1);
    at(8900, { tw: 0, x: 0, tilt: 0, htilt: 0 }); at(9250, { spin: 360 }); at(9251, { spin: 0 }, 'l');
    // hop-spin: big hop with a full spin, ears streaming outward
    at(9400, { sq: 0.28, lift: 0, armL: 40, armR: 40 }, 'i');
    at(9700, { sq: -0.18, lift: 17, spin: 0, armL: 160, armR: 160, earL: 28, earR: 28, open: 0.9 }, 'o'); at(10150, { spin: 360, lift: 12 }); at(10151, { spin: 0 }, 'l'); em(9700, 'spark', 'head', 3);
    at(10350, { lift: 0, sq: 0.26, armL: 60, armR: 60, earL: 0, earR: 0, open: 0.5, hLx: 0, hRx: 0, hLy: 0, hRy: 0 }, 'i'); em(10350, 'dust', [42, 96], 2); em(10350, 'dust', [58, 96], 2);
    // bunny-paw pose: paws up by her cheeks, one ear flopped, wink
    at(10600, { winkR: 0, sq: 0, tilt: 5, htilt: 6, armL: 120, armR: 120, hLx: 7, hRx: -7, hLy: -12, hRy: -12, flR: 0.55, earL: 10, mw: 0.8 }); at(10800, { winkR: 1 }); at(11150, { winkR: 0, mw: 1 }); em(10800, 'heart', 'head', 2);
    at(11450, { tilt: 0, htilt: 0, armL: 0, armR: 0, hLx: 0, hRx: 0, hLy: 0, hRy: 0, flR: 0, earL: 0, earR: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@hana': { loop: LP, k: K, ev } }); }
  // Boo's own dance, "Peekaboo Float" (a shy little sheet ghost): floaty "wooo" glides with wavy arms and a fluttering hem, a shy peek-a-boo behind his paws, a big BOO! pop,
  // a ghostly fade-out that reappears on the other side, a loop-de-loop swoop, a hem-flaring twirl, shy blushing pose + wink (11.6 s loop). Channels: flr (hem flare), gho (fade out 0-1)
  function gbDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@boo']) return;
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.5]], mw: [[0, 1]], flr: [[0, 0]], gho: [[0, 0]] }, LP = 11600, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    for (let i = 0; i < 4; i++) { const d = i % 2 ? 1 : -1, t = 100 + i * 560;
      at(t + 280, { x: d * 10, lift: 4 + (i % 2) * 3, tilt: d * 8, htilt: -d * 4, armL: 130 + d * 20, armR: 130 - d * 20, flr: 0.35, open: 0.75, mw: 0.8 });
      at(t + 560, { x: d * 4, lift: 1, tilt: d * 3, armL: 120 - d * 25, armR: 120 + d * 25, flr: 0.15 }); if (i % 2 === 0) em(t + 280, 'note', 'head', 1); }
    // shy peek-a-boo: hides his eyes behind both paws, peeks out with one, hides again, giggles
    at(2500, { lx: 0, blush: 0, x: 0, tilt: 0, htilt: 0, lift: 0, armL: 60, armR: 60, flr: 0, open: 0.4, mw: 1 });
    at(2750, { hLx: 15, hRx: -15, hLy: -15, hRy: -15, armL: 70, armR: 70, sq: 0.12, hap: 0.6, smile: 0.6, blush: 1, open: 0.2 }, 'i');
    at(3150, { hRy: -5, hRx: -4, htilt: 6, hap: 0, smile: 0.8, lx: 0.6 }); at(3550, { hRy: -15, hRx: -15, htilt: 0, lx: 0, hap: 0.6 }, 'i');
    for (let i = 0; i < 4; i++) at(3650 + i * 90, { tilt: i % 2 ? 2.5 : -2.5 }, 'l');
    // BOO! pops up big with arms high, eyes wide, mouth open
    at(4050, { wide: 0, tilt: 0, sq: 0.25, hLx: 0, hRx: 0, hLy: 0, hRy: 0, armL: 40, armR: 40, hap: 0.85, smile: 1 }, 'i');
    at(4300, { sq: -0.22, lift: 9, armL: 170, armR: 170, wide: 1, open: 1, mw: 1.35, hap: 0, flr: 0.6, blush: 0 }, 'o'); em(4300, 'spark', 'head', 4);
    at(4800, { sq: 0, lift: 2, armL: 60, armR: 60, wide: 0, open: 0.5, mw: 1, hap: 0.85, flr: 0.1 }, 'i');
    // ghostly fade: drifts left fading out, reappears on the right and fades back in
    at(5100, { x: 0, gho: 0, tilt: 0 }); at(5600, { x: -14, gho: 0.92, tilt: -6 }, 'i'); at(5750, { x: 14, gho: 0.92, tilt: 6 }, 'l'); at(6250, { x: 8, gho: 0, tilt: 2 }, 'o'); em(6250, 'spark', 'head', 3);
    // loop-de-loop swoop through the air, hem streaming
    at(6500, { x: 0, tilt: 0, lift: 2 });
    for (let i = 1; i <= 10; i++) { const a = i / 10 * Math.PI * 2; at(6500 + i * 200, { x: 13 * Math.sin(a), lift: 2 + 11 * (1 - Math.cos(a)), tilt: i < 10 ? 22 * Math.cos(a) * Math.sin(a) * 1.6 : 0, flr: 0.7, armL: 100 + 30 * Math.sin(a), armR: 100 - 30 * Math.sin(a) }, 'l'); if (i % 3 === 0) em(6500 + i * 200, 'dust', 'body', 2); }
    // twirl: spins twice, hem flaring out wide, arms out
    at(8700, { x: 0, tilt: 0, lift: 3, spin: 0, flr: 0.3, armL: 90, armR: 90 });
    at(9700, { spin: 720, flr: 1.2, lift: 6, armL: 110, armR: 110 }, 'io'); at(9701, { spin: 0 }, 'l'); em(9200, 'spark', 'body', 3);
    at(9950, { flr: 0.1, lift: 1, armL: 50, armR: 50, hLx: 0, hRx: 0, hLy: 0, hRy: 0 }, 'i');
    // shy pose: paws together under his chin, blushing, head tilt + wink
    at(10250, { winkR: 0, hLx: 9, hRx: -9, hLy: -9, hRy: -9, armL: 70, armR: 70, htilt: 8, tilt: 3, blush: 1, mw: 0.75 }); at(10600, { winkR: 1 }); at(10950, { winkR: 0 }); em(10600, 'heart', 'head', 2);
    at(11400, { hLx: 0, hRx: 0, hLy: 0, hRy: 0, armL: 0, armR: 0, htilt: 0, tilt: 0, blush: 0, mw: 1, lift: 0, x: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@boo': { loop: LP, k: K, ev } }); }
  // Pixie's own dance, "Pixie Jig" (pixies love to dance and frolic, wings a-buzz): a fluttering rise flicking pixie dust, a skipping country jig with heel kicks,
  // a loop-the-loop flight with a dust trail, a mischievous giggle behind her paw, a ballet pirouette with her petal dress flaring, curtsy + wink (11.5 s loop).
  // Channels: wfl (fast wing buzz), wsp (wings spread), drf (dress flare)
  function pxDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@pixie']) return;
    if (RR.PRE && !RR.PRE.pixdust) RR.PRE.pixdust = { n: 4, sp: 12, vy: -3, g: 16, life: 1200, r: [0.9, 1.6], col: ['#fff3a0', '#ffd84a', '#ffffff', '#ffc2ec'], kind: 'star' };
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.5]], mw: [[0, 1]], wfl: [[0, 0]], wsp: [[0, 0]], drf: [[0, 0]] }, LP = 11500, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    // fluttering rise: buzzes up swaying side to side, flicking pixie dust from each paw in turn
    for (let i = 0; i < 4; i++) { const d = i % 2 ? 1 : -1, t = 150 + i * 500;
      at(t + 250, { x: d * 6, lift: 5 + i * 2.5, tilt: d * 6, wfl: 1, armL: d < 0 ? 150 : 60, armR: d > 0 ? 150 : 60, hLy: d < 0 ? -6 : 0, hRy: d > 0 ? -6 : 0, footL: 3, footR: 1 });
      at(t + 500, { tilt: d * 2, armL: d < 0 ? 110 : 70, armR: d > 0 ? 110 : 70, footL: 1, footR: 3 }); em(t + 300, 'pixdust', d < 0 ? 'pawL' : 'pawR', 4); }
    // skipping jig: lands and skips side to side with heel kicks, paws on her hips
    at(2300, { x: 0, tilt: 0, lift: 0, wfl: 0, armL: 25, armR: 25, hLx: -3, hRx: 3, hLy: 2, hRy: 2, footL: 0, footR: 0, sq: 0.15 }, 'i');
    for (let i = 0; i < 6; i++) { const d = i % 2 ? 1 : -1, t = 2450 + i * 360;
      at(t, { x: d * 5, sq: 0.16, lift: 0, tilt: -d * 4, footL: d > 0 ? 6 : 0, footR: d < 0 ? 6 : 0, drf: 0.2 }, 'i');
      at(t + 180, { lift: 6, sq: -0.08, tilt: d * 3, footL: d < 0 ? 5 : 0, footR: d > 0 ? 5 : 0, drf: 0.5 }, 'o'); em(t, 'dust', [50 + d * 5, 96], 1); if (i % 2) em(t + 180, 'note', 'head', 1); }
    // loop-the-loop flight with a pixie-dust trail
    at(4700, { pitch: 0, x: 0, lift: 2, sq: 0, tilt: 0, footL: 2, footR: 2, wfl: 1, armL: 100, armR: 100, hLx: 0, hRx: 0, hLy: 0, hRy: 0, drf: 0.2 });
    for (let i = 1; i <= 10; i++) { const a = i / 10 * Math.PI * 2; at(4700 + i * 200, { x: -14 * Math.sin(a), lift: 2 + 12 * (1 - Math.cos(a)), tilt: -24 * Math.sin(a), pitch: 0.4 * Math.sin(a), wfl: 1, drf: 0.4 }, 'l'); if (i % 2) em(4700 + i * 200, 'pixdust', 'body', 3); } at(6650, { hLx: 0, hRx: 0, hLy: 0, hRy: 0 });
    // mischievous giggle: lands and hides a giggle behind her paw, shoulders shaking
    at(6900, { sqz: 0, hap: 0.85, smile: 1, open: 0.5, x: 0, lift: 0, tilt: 0, pitch: 0, wfl: 0, sq: 0.1, armL: 30, armR: 60, hRx: -10, hRy: -14, footL: 0, footR: 0 }, 'i');
    at(7050, { sqz: 0.9, hap: 0, smile: 0.6, open: 0.2 });
    for (let i = 0; i < 8; i++) at(7100 + i * 110, { tilt: i % 2 ? 3 : -3, sq: i % 2 ? 0.14 : 0.06, htilt: i % 2 ? 4 : -2 }, 'l'); em(7300, 'note', 'head', 1);
    at(8050, { sqz: 0, hap: 0.85, smile: 1, open: 0.5, tilt: 0, htilt: 0, sq: 0, hRx: 0, hRy: 0, armR: 40 });
    // pirouette on tiptoe: arms up in a ballet ring, two spins, petal dress flaring, dust burst
    at(8300, { lift: 1, spin: 0, armL: 120, armR: 120, drf: 0.2, wfl: 0.5 });
    at(8500, { lift: 5, armL: 165, armR: 165, hLx: 6, hRx: -6, footL: 3, footR: 3, drf: 0.6 }); at(9400, { spin: 720, drf: 1.3, lift: 6 }, 'io'); at(9401, { spin: 0 }, 'l'); em(9400, 'pixdust', 'head', 6);
    at(9650, { lift: 0, armL: 40, armR: 40, hLx: 0, hRx: 0, footL: 0, footR: 0, drf: 0.1, wfl: 0, sq: 0.15 }, 'i');
    // curtsy: holds out her petal skirt, dips, wings spread wide, wink
    at(9900, { winkR: 0, armL: 25, armR: 25, hLx: -4, hRx: 4, hLy: 3, hRy: 3, sq: 0.25, htilt: 8, tilt: 3, wsp: 1, drf: 0.35 }, 'i'); at(10300, { winkR: 1 }); at(10650, { winkR: 0 }); em(10300, 'heart', 'head', 2); em(10300, 'pixdust', 'pawR', 3);
    at(10900, { sq: 0, htilt: 0, tilt: 0 }); at(11350, { armL: 0, armR: 0, hLx: 0, hRx: 0, hLy: 0, hRy: 0, wsp: 0, drf: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@pixie': { loop: LP, k: K, ev } }); }
  // Lemmy's own dance, "Sour Shuffle" (lemon moves): zesty zig-zag shuffle steps, a sour pucker shiver (scrunched face, shakes, then eyes pop wide - zing!), a juice squeeze (paws press his sides, juice sprays out),
  // a lemonade stir twirl (one paw stirs, the leaf whirls round the stem), a rock-and-roll on his round belly, a zesty spin jump, sour-kiss pose + wink (11.4 s loop). Channels: lfl (leaf flap), lsp (leaf whirl, turns), stw (stem boing)
  function lmDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@lemmy']) return;
    if (RR.PRE && !RR.PRE.lemjuice) RR.PRE.lemjuice = { n: 6, sp: 24, vy: -22, g: 90, life: 820, r: [0.8, 1.3], col: ['#ffe34a', '#fff6b0', '#efb400'], kind: 'drop' };
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.5]], lfl: [[0, 0]], lsp: [[0, 0]], stw: [[0, 0]] }, LP = 11400, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    // sour shuffle: zig-zag side steps, heel taps, paws pumping, the leaf flicking on every step
    for (let i = 0; i < 6; i++) { const d = i % 2 ? 1 : -1, t = 200 + i * 360;
      at(t, { x: d * 6, tilt: d * 5, htilt: -d * 3, sq: 0.18, lift: 0, armL: d < 0 ? 120 : 45, armR: d > 0 ? 120 : 45, footL: d < 0 ? 3 : 0, footR: d > 0 ? 3 : 0, lfl: 0.6, stw: 0.6 }, 'i');
      at(t + 180, { sq: -0.06, lift: 4, armL: d < 0 ? 60 : 100, armR: d > 0 ? 60 : 100, footL: 0, footR: 0, lfl: -0.2, stw: 0 }, 'o'); em(t, 'dust', [50 + d * 10, 96], 1); if (i % 2) em(t + 180, 'note', 'head', 1); }
    // sour pucker: squeezes up small with a scrunched face and shivers, then pops wide-eyed - zing!
    at(2500, { x: 0, tilt: 0, htilt: 0, lift: 0, sq: 0.1, armL: 30, armR: 30, lfl: 0, stw: 0 }, 'i');
    at(2700, { sq: 0.3, sqz: 1, hap: 0, smile: 0, open: 0, mw: 0.45, armL: 15, armR: 15, lfl: -0.4 }, 'i');
    for (let i = 0; i < 6; i++) at(2800 + i * 90, { x: (i % 2 ? 1 : -1) * 1.6, tilt: (i % 2 ? 1 : -1) * 2.5, lfl: -0.4 + (i % 2) * 0.3 }, 'l'); at(3300, { sq: 0.3, sqz: 1, mw: 0.45, open: 0, hap: 0, smile: 0 }, 'l');
    at(3400, { x: 0, tilt: 0, sq: -0.18, lift: 7, sqz: 0, wide: 1, open: 0.7, hap: 0, mw: 1, armL: 160, armR: 160, lfl: 1.2, stw: 1.2 }, 'o'); em(3400, 'spark', 'head', 3);
    at(3700, { lift: 0, sq: 0.15, wide: 0, hap: 0.85, smile: 1, open: 0.5, armL: 50, armR: 50, lfl: 0, stw: 0.4 }, 'i');
    // juice squeeze: paws press in on his sides, he squashes flat and juice sprays out, then springs back tall
    at(3950, { sq: 0.05, armL: 70, armR: 70 });
    at(4300, { sq: 0.3, wide: 0.15, armL: 10, armR: 10, sqz: 0.7, lfl: -0.5, open: 0.3 }, 'i'); [4300, 4500].forEach(t => { em(t, 'lemjuice', [22, 60], 4); em(t, 'lemjuice', [78, 60], 4); });
    at(4600, { sq: 0.28, sqz: 0.7 }); at(4850, { sq: -0.2, wide: 0, lift: 9, sqz: 0, armL: 150, armR: 150, lfl: 1, stw: 1, open: 0.8 }, 'o'); em(4850, 'lemjuice', [50, 26], 5);
    at(5200, { sq: 0.2, lift: 0, armL: 50, armR: 50, lfl: -0.2, open: 0.5 }, 'i'); at(5400, { sq: 0, lfl: 0, stw: 0.2 }, 'o'); em(5200, 'dust', [42, 96], 2); em(5200, 'dust', [58, 96], 2);
    // lemonade stir: one paw stirs circles over his head while he twirls round twice; the leaf whirls round the stem
    at(5600, { spin: 0, lsp: 0, armL: 40, armR: 40 });
    for (let i = 0; i <= 8; i++) { const a = i / 8 * Math.PI * 2; at(5800 + i * 200, { armR: 150 + 20 * Math.sin(a), hRx: 4 * Math.cos(a), armL: 60 + 15 * Math.sin(a + 1), lfl: 0.4 + 0.2 * Math.sin(a), lift: 3 + 2 * Math.sin(a * 2) }, 'l'); }
    at(7400, { spin: 720, lsp: 3 }, 'io'); at(7401, { spin: 0, lsp: 0 }, 'l'); [6000, 6600, 7200].forEach(t => em(t, 'note', 'pawR', 1)); em(6800, 'lemjuice', 'pawR', 3);
    at(7550, { lift: 0, armR: 60, hRx: 0, armL: 50, sq: 0.18, lfl: 0 }, 'i');
    // rock-and-roll: rocks on his round belly, rolling side to side with big tilts, paws flung out
    for (let i = 0; i < 4; i++) { const d = i % 2 ? 1 : -1; at(7800 + i * 330, { tilt: d * 16, x: d * 5, htilt: d * 5, sq: 0.06, pitch: (i % 2 ? -0.25 : 0.25), armL: d > 0 ? 140 : 40, armR: d < 0 ? 140 : 40, footL: d > 0 ? 4 : 0, footR: d < 0 ? 4 : 0, lfl: 0.3 + d * 0.3, stw: 0.5 }); }
    em(8100, 'note', 'head', 1); em(8800, 'note', 'head', 1);
    at(9200, { tilt: 0, x: 0, htilt: 0, pitch: 0, footL: 0, footR: 0, armL: 30, armR: 30, sq: 0.28, lfl: -0.3, stw: 0 }, 'i');
    // zesty spin jump: big jump with a spin, paws up, zest sparks, squashy landing
    at(9450, { sq: -0.15, lift: 18, armL: 170, armR: 170, lfl: 1, stw: 1, open: 0.9, spin: 0 }, 'o'); at(9950, { spin: 360, lift: 14 }); at(9951, { spin: 0 }, 'l'); em(9450, 'spark', 'head', 3); em(9700, 'lemjuice', 'head', 3);
    at(10200, { lift: 0, sq: 0.3, armL: 50, armR: 50, lfl: -0.3, open: 0.5 }, 'i'); em(10200, 'dust', [40, 96], 2); em(10200, 'dust', [60, 96], 2);
    // sour-kiss pose + wink
    at(10400, { sq: 0, tilt: 6, htilt: 5, armL: 30, armR: 165, winkR: 0, mw: 0.6, lfl: 0.5, stw: 0.3 }); at(10600, { winkR: 1 }); at(10950, { winkR: 0, mw: 1, lfl: 0, stw: 0 }); em(10600, 'heart', 'head', 2);
    at(11250, { tilt: 0, htilt: 0, armL: 0, armR: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    K.sq.forEach(k => { if (k[1] > 0) k[1] *= 0.6; }); // his wide lemon body flattens a lot, so squashes are gentler
    RR.add({ 'dance@lemmy': { loop: LP, k: K, ev } }); }
  // Kiwi's own dance, "Kiwi Bird Strut" (he's named after the kiwi bird, so he dances like one): a head-bobbing bird strut with paws tucked back like little wings,
  // pecking at the ground, scratch-kicks with dust, a feather fluff-up (his fuzz ruffles like feathers, fuzz bits fly), tiny wing flaps that never get him off the ground,
  // a proud chest-puff, a bird hop-hop-hop forward and back, peck + wink (11.6 s loop). Channels: fzz (fuzz ruffle), stw (stem bob)
  function kwDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@kiwi']) return;
    if (RR.PRE && !RR.PRE.kiwijuice) RR.PRE.kiwijuice = { n: 6, sp: 24, vy: -22, g: 90, life: 820, r: [0.8, 1.3], col: ['#9ad84a', '#f2ffc8', '#5ea82a'], kind: 'drop' };
    if (RR.PRE && !RR.PRE.kiwifuzz) RR.PRE.kiwifuzz = { n: 8, sp: 30, vy: -14, g: 40, life: 900, r: [0.4, 0.8], col: ['#a87c52', '#dcb88e', '#7a5432'], kind: 'drop' };
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.5]], fzz: [[0, 0]], stw: [[0, 0]] }, LP = 11600, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    // bird strut: paws tucked back low like wings, each step the whole body bobs its "head" forward then back (pitch), stem bobbing
    for (let i = 0; i < 6; i++) { const d = i % 2 ? 1 : -1, t = 200 + i * 330, x = -6 + i * 2.4;
      at(t, { x, pitch: 0.32, htilt: d * 3, sq: 0.1, lift: 0, armL: 8, armR: 8, footL: d < 0 ? 4 : 0, footR: d > 0 ? 4 : 0, stw: 0.7, fzz: 0.15 }, 'i');
      at(t + 165, { pitch: -0.12, sq: -0.04, lift: 1.5, footL: 0, footR: 0, stw: -0.3 }, 'o'); if (i % 2) em(t, 'dust', [50 + x, 96], 1); }
    // pecking: three quick pecks at the ground, a nibble and a happy chirp
    at(2300, { x: 6, pitch: 0, sq: 0, lift: 0, htilt: 0, armL: 15, armR: 15 });
    [2500, 2780, 3060].forEach((t, i) => { at(t, { pitch: 0.55, sq: 0.08, open: 0.7, stw: 1, x: 6 - i }, 'i'); at(t + 140, { pitch: 0.05, sq: 0, open: 0.3, stw: -0.4 }, 'o'); em(t, 'dust', [50 + 6 - i, 95], 1); });
    at(3400, { pitch: -0.1, open: 0.8, mw: 0.7 }); em(3400, 'note', 'head', 1); at(3600, { pitch: 0, mw: 1, open: 0.5 });
    // scratch-kicks: kicks dirt back with one foot then the other, little dust puffs
    for (let i = 0; i < 4; i++) { const L = i % 2 === 0, t = 3800 + i * 260; at(t, { footL: L ? 6 : 0, footR: L ? 0 : 6, tilt: L ? 6 : -6, x: 3 + (L ? -1 : 1), sq: 0.06 }, 'i'); at(t + 130, { footL: 0, footR: 0, tilt: 0, sq: 0 }, 'o'); em(t + 60, 'dust', [L ? 38 : 62, 96], 2); }
    // feather fluff-up: shakes all over like a bird after a bath - fuzz stands on end, bits of fuzz fly, then smooths down
    at(4950, { x: 0, sq: 0.12, fzz: 0.3, armL: 20, armR: 20 }, 'i');
    for (let i = 0; i < 10; i++) at(5050 + i * 70, { tilt: (i % 2 ? 1 : -1) * 6, htilt: (i % 2 ? -1 : 1) * 5, x: (i % 2 ? 1 : -1) * 1.2, fzz: 1.4, sq: -0.06, stw: (i % 2 ? 1 : -1) }, 'l');
    [5100, 5350, 5600].forEach(t => em(t, 'kiwifuzz', 'head', 4)); at(5850, { tilt: 0, htilt: 0, x: 0, fzz: 0.4, sq: 0.05, stw: 0, wide: 1 }, 'o'); at(6150, { fzz: 0, wide: 0, sq: 0 });
    // tiny wing flaps: flaps his little paw-wings as fast as he can, jumps a tiny bit... and stays on the ground (he's a kiwi!)
    for (let i = 0; i < 8; i++) at(6300 + i * 90, { armL: i % 2 ? 95 : 35, armR: i % 2 ? 95 : 35, lift: 2 + (i % 2) * 2, sq: -0.05, fzz: 0.3 }, 'l');
    at(7100, { armL: 20, armR: 20, lift: 0, sq: 0.15, fzz: 0, mw: 0.6, open: 0.2 }, 'i'); at(7350, { sq: 0, mw: 1, open: 0.5 }); em(7150, 'dust', [50, 96], 2);
    // proud chest-puff: puffs up tall, leans back and shows off the green slice
    at(7550, { pitch: -0.4, sq: -0.14, lift: 1, armL: 5, armR: 5, fzz: 0.5 }); [7700, 7950].forEach(t => em(t, 'spark', [50, 75], 2)); at(8150, { pitch: -0.4 }); at(8400, { pitch: 0, sq: 0, lift: 0, fzz: 0 });
    // bird hops: three hops forward, three back, paws tucked
    [[8600, 5], [8900, 10], [9200, 5], [9500, 0], [9800, -5], [10100, 0]].forEach(([t, x], i) => { at(t, { x, sq: 0.18, lift: 0, pitch: 0.15, armL: 10, armR: 10 }, 'i'); at(t + 150, { sq: -0.1, lift: 6, pitch: -0.05, stw: 0.8 }, 'o'); if (i % 2) em(t, 'dust', [50 + x, 96], 1); });
    // peck + wink
    at(10500, { x: 0, sq: 0, lift: 0, pitch: 0.3, stw: 1 }, 'i'); at(10700, { pitch: 0, stw: 0, tilt: -6, htilt: -5, armL: 160, armR: 15, winkR: 0 }, 'o'); at(10850, { winkR: 1 }); at(11200, { winkR: 0 }); em(10850, 'heart', 'head', 2);
    at(11450, { tilt: 0, htilt: 0, armL: 0, armR: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@kiwi': { loop: LP, k: K, ev } }); }
  // Peachy's own dance, "Orchard Drop" (peach tree moves): she sways on the branch with her paws up like she's hanging by the stem, the leaf rustling in the breeze;
  // ripens with a blush, then drops off the tree - plop! - and bounces softly (bruise-free) in shrinking bounces, rolls up, a slow peaches-and-cream waltz in 1-2-3 turns,
  // a summer breeze sway, a sweet curtsy + wink (11.8 s loop). Channels: lfl (leaf flap), lsp (leaf whirl), stw (stem bob), blush
  function peDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@peachy']) return;
    if (RR.PRE && !RR.PRE.peachjuice) RR.PRE.peachjuice = { n: 6, sp: 24, vy: -22, g: 90, life: 820, r: [0.8, 1.3], col: ['#ffaa88', '#ffe4cc', '#ef7468'], kind: 'drop' };
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.5]], lfl: [[0, 0]], lsp: [[0, 0]], stw: [[0, 0]], blush: [[0, 0]] }, LP = 11800, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    // hanging on the branch: lifted up, paws high, swinging like a pendulum from her stem, leaf rustling
    at(150, { lift: 0, armL: 30, armR: 30 }); at(500, { lift: 16, armL: 170, armR: 170, sq: -0.1, stw: 0.6 }, 'o');
    for (let i = 0; i < 4; i++) { const d = i % 2 ? 1 : -1; at(800 + i * 420, { x: d * 6, tilt: -d * 9, htilt: -d * 4, lift: 16 + 1.5 * (i % 2), lfl: 0.4 + 0.3 * (i % 2), stw: d * 0.6 }); }
    // ripening: she glows pink, cheeks blushing, a happy little wiggle
    at(2600, { x: 0, tilt: 0, htilt: 0, blush: 1, hap: 1, lfl: 0.2 }); em(2600, 'spark', 'head', 2); at(2800, { blush: 1, sq: -0.15 }); at(2900, { sq: -0.05 });
    // plop! drops off the tree, lands soft, bounces in shrinking bounces
    at(3050, { lift: 18, wide: 1, open: 0.8, armL: 175, armR: 175 }, 'i'); at(3330, { lift: 0, sq: 0.32, wide: 0, open: 0.4, armL: 60, armR: 60, lfl: -0.6, stw: -1 }, 'i'); em(3330, 'dust', [40, 96], 2); em(3330, 'dust', [60, 96], 2); em(3330, 'peachjuice', [50, 70], 3);
    [[3600, 8, 3800], [3950, 4, 4100], [4220, 1.8, 4330]].forEach(([t, h, t2]) => { at(t, { lift: h, sq: -0.08, lfl: 0.6, stw: 0.8 }, 'o'); at(t2, { lift: 0, sq: 0.18 * h / 8 + 0.05, lfl: -0.3, stw: -0.5 }, 'i'); });
    at(4500, { sq: 0, lfl: 0, stw: 0, armL: 40, armR: 40, hap: 0.85, blush: 0.5 }); em(4450, 'note', 'head', 1);
    // little roll: rocks forward and back like a peach settling on the grass
    [[4700, 0.35, 6], [5000, -0.3, -4], [5250, 0.2, 3], [5450, -0.1, -1], [5600, 0, 0]].forEach(([t, p, ti]) => at(t, { pitch: p, tilt: ti }));
    // peaches-and-cream waltz: 1-2-3, 1-2-3 - a turn on each bar, rising on "1"
    for (let i = 0; i < 3; i++) { const t = 5850 + i * 720, s = (i + 1) * 120;
      at(t, { lift: 4, sq: -0.06, armL: 150, armR: 60, htilt: 6, lfl: 0.4 }, 'o'); at(t + 240, { lift: 0, sq: 0.08, spin: s - 60 }, 'io'); at(t + 480, { lift: 1.5, sq: 0, spin: s, armL: 60, armR: 150, htilt: -6, lfl: -0.1 }, 'io'); em(t, 'note', 'head', 1); }
    at(8010, { spin: 360 }); at(8011, { spin: 0 }, 'l'); at(8200, { lift: 0, armL: 40, armR: 40, htilt: 0, lfl: 0 });
    // summer breeze: sways slow, leaf whirling in the wind, paws drifting like branches
    for (let i = 0; i <= 6; i++) { const a = i / 6 * Math.PI * 2; at(8400 + i * 230, { tilt: 7 * Math.sin(a), x: 3 * Math.sin(a), armL: 110 + 30 * Math.sin(a), armR: 110 - 30 * Math.sin(a), lfl: 0.5 + 0.4 * Math.sin(a * 2) }, 'l'); }
    at(9600, { lsp: 0 }); at(10000, { lsp: 1 }); at(10001, { lsp: 0 }, 'l'); at(10050, { tilt: 0, x: 0, armL: 40, armR: 40, lfl: 0 });
    // sweet curtsy + wink
    at(10300, { sq: 0.2, pitch: 0.25, armL: 70, armR: 70, blush: 0.8 }, 'i'); at(10650, { sq: 0, pitch: 0, tilt: 6, htilt: 5, armL: 30, armR: 165, winkR: 0, lfl: 0.4 }, 'o'); at(10850, { winkR: 1 }); at(11200, { winkR: 0, lfl: 0 }); em(10850, 'heart', 'head', 2);
    at(11550, { tilt: 0, htilt: 0, armL: 0, armR: 0, blush: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    K.sq.forEach(k => { if (k[1] > 0) k[1] *= 0.65; }); // her round body flattens a lot, so squashes are gentler
    RR.add({ 'dance@peachy': { loop: LP, k: K, ev } }); }
  // Pitaya's own dance, "Dragon Leap" (he's a dragonfruit, so he dances like a little dragon): a low dragon prowl with claw paws and half-spread leaf wings, a crouch and a huge flapping leap with a spin,
  // a dragon roar (wings spread wide, bracts and crown flare out, seeds burst out), a lunar-new-year dragon weave, a flapping hover loop, three leap-frog hops, a proud wings-up pose + wink (12.2 s loop).
  // Channels: wfl (wing flap), wsp (wing spread), brf (bract flare), crw (crown flare), spk (sparkle glow)
  function ptDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@pitaya']) return;
    if (RR.PRE && !RR.PRE.pitseed) RR.PRE.pitseed = { n: 6, sp: 22, vy: -20, g: 85, life: 850, r: [0.55, 0.8], col: ['#2a1a30', '#3a2340'], kind: 'seed' };
    if (RR.PRE && !RR.PRE.pitjuice) RR.PRE.pitjuice = { n: 5, sp: 22, vy: -20, g: 90, life: 800, r: [0.8, 1.3], col: ['#ff4fb4', '#ffc6ec', '#c81e86'], kind: 'drop' };
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.5]], wfl: [[0, 0]], wsp: [[0, 0]], brf: [[0, 0]], crw: [[0, 0]], spk: [[0, 0]] }, LP = 12200, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    // dragon prowl: crouched low, claw paws up, wings half spread, sneaking side steps with his head swaying the other way
    at(200, { sq: 0.22, armL: 115, armR: 115, wsp: 0.4, brf: 0.3 });
    for (let i = 0; i < 4; i++) { const d = i % 2 ? 1 : -1, t = 450 + i * 400; at(t, { x: d * 6, tilt: d * 4, htilt: -d * 5, sq: 0.24, lift: 0, footL: d < 0 ? 4 : 0, footR: d > 0 ? 4 : 0, armL: d < 0 ? 135 : 100, armR: d > 0 ? 135 : 100 }, 'i'); at(t + 200, { sq: 0.16, lift: 2.5, footL: 0, footR: 0 }, 'o'); em(t, 'dust', [50 + d * 10, 96], 1); }
    // crouch + dragon leap: deep crouch, then a huge leap with the wings beating and a full spin in the air, squashy landing
    at(2200, { x: 0, tilt: 0, htilt: 0, sq: 0.36, lift: 0, armL: 40, armR: 40, wsp: 0.2, wfl: 0, brf: 0.1, open: 0.3 }, 'i');
    at(2550, { sq: -0.12, lift: 28, armL: 165, armR: 165, wsp: 1, wfl: 1.2, brf: 0.8, crw: 0.8, open: 0.9, spin: 0 }, 'o'); em(2550, 'dust', [40, 96], 2); em(2550, 'dust', [60, 96], 2);
    at(3050, { lift: 30, spin: 360, sq: -0.05 }); at(3051, { spin: 0 }, 'l'); em(2850, 'spark', 'head', 3);
    at(3400, { lift: 0, sq: 0.34, armL: 50, armR: 50, wfl: 0.2, wsp: 0.3, brf: 0.2, crw: 0.2, open: 0.5 }, 'i'); em(3400, 'dust', [38, 96], 3); em(3400, 'dust', [62, 96], 3); em(3400, 'pitjuice', [50, 70], 3);
    at(3600, { sq: 0, wfl: 0 });
    // dragon roar: rears up tall, wings spread wide, bracts and crown flare out, mouth wide, claws up, shaking with the roar; crunchy seeds burst out
    at(3900, { sq: -0.18, lift: 3, wsp: 1.25, brf: 1.1, crw: 1.1, open: 1, hap: 1, armL: 165, armR: 165, spk: 1, pitch: -0.2 }, 'o');
    for (let i = 0; i < 8; i++) at(4050 + i * 80, { tilt: (i % 2 ? 1 : -1) * 2.5, x: (i % 2 ? 1 : -1) * 0.8 }, 'l');
    [4000, 4300].forEach(t => { em(t, 'pitseed', [30, 50], 4); em(t, 'pitseed', [70, 50], 4); }); em(4100, 'spark', 'crown', 4);
    at(4800, { tilt: 0, x: 0, sq: 0.1, lift: 0, wsp: 0.3, brf: 0.2, crw: 0.2, open: 0.5, hap: 0.85, armL: 40, armR: 40, spk: 0.3, pitch: 0 }, 'i');
    // dragon weave: a lunar-new-year dragon dance - he snakes side to side in a wave, head swaying the other way, wings rippling, paws waving
    for (let i = 0; i <= 8; i++) { const a = i / 8 * Math.PI * 2; at(5100 + i * 280, { x: 9 * Math.sin(a), tilt: 8 * Math.cos(a), htilt: -7 * Math.cos(a), lift: 3 + 3 * Math.sin(a * 2), armL: 110 + 45 * Math.sin(a), armR: 110 - 45 * Math.sin(a), wfl: 0.35, wsp: 0.5 + 0.3 * Math.sin(a), brf: 0.4 + 0.3 * Math.cos(a * 2) }, 'l'); }
    [5300, 5860, 6420, 6980].forEach(t => em(t, 'note', 'head', 1));
    at(7500, { x: 0, tilt: 0, htilt: 0, lift: 0, sq: 0.15, armL: 60, armR: 60, wfl: 0.2, brf: 0.2 }, 'i');
    // flapping hover: beats his leaf wings fast, rises and loops round the stage leaning into the turn, then glides back down
    at(7800, { sq: -0.08, lift: 14, wfl: 1.4, wsp: 0.9, armL: 70, armR: 70 }, 'o');
    for (let i = 1; i <= 6; i++) { const a = i / 6 * Math.PI * 2; at(7800 + i * 220, { x: 10 * Math.sin(a), lift: 16 + 5 * (1 - Math.cos(a)), tilt: 8 * Math.cos(a), turn: 0.35 * Math.cos(a), wfl: 1.4 }, 'l'); }
    em(8100, 'spark', 'wingL', 2); em(8500, 'spark', 'wingR', 2);
    at(9300, { x: 0, tilt: 0, turn: 0, lift: 0, sq: 0.25, wfl: 0.1, wsp: 0.3, armL: 40, armR: 40 }, 'i'); em(9300, 'dust', [42, 96], 2); em(9300, 'dust', [58, 96], 2);
    // leap-frog hops: three quick dragon hops across the stage, a wing flap on each
    [[-8, 9600], [0, 9950], [8, 10300]].forEach(([x, t]) => { at(t, { x, lift: 11, sq: -0.12, wfl: 0.9, armL: 140, armR: 140, tilt: x * 0.6 }, 'o'); at(t + 200, { lift: 0, sq: 0.22, wfl: 0.1, armL: 60, armR: 60 }, 'i'); em(t + 200, 'dust', [50 + x, 96], 2); });
    at(10750, { x: 0, tilt: 0, sq: 0, wfl: 0 });
    // proud dragon pose: wings up high, crown flared, one claw raised, wink
    at(11000, { sq: -0.1, wsp: 1.1, crw: 0.7, brf: 0.5, armL: 30, armR: 165, tilt: -5, htilt: -5, spk: 1, winkR: 0 }, 'o'); at(11200, { winkR: 1 }); at(11550, { winkR: 0 }); em(11200, 'heart', 'head', 2); em(11100, 'spark', 'crown', 3);
    at(11950, { sq: 0, wsp: 0, crw: 0, brf: 0, armL: 0, armR: 0, tilt: 0, htilt: 0, spk: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    K.sq.forEach(k => { if (k[1] > 0) k[1] *= 0.7; }); // his round body flattens a lot, so squashes are gentler
    RR.add({ 'dance@pitaya': { loop: LP, k: K, ev } }); }
  // Tutti's own dance, "Fruit Salad Sway" (fruit-basket fairy moves): rocks her basket side to side with the crown cherries bouncing, juggles the cherry and the pear out of her basket,
  // a fairy float (wings fluttering fast, figure-of-eight drift sprinkling fairy dust, slow twirl), a fruit-salad toss (both fruits fly up while she twirls under them and catches them),
  // a slow hula sway (basket one way, head the other), three basket hops with the fruits bouncing, a curtsy + wink (12.4 s loop). Channels: wfl (wing flutter), fL / fR (cherry / pear toss 0-1), cb (crown bounce)
  function tuDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@tutti']) return;
    if (RR.PRE && !RR.PRE.fairydust) RR.PRE.fairydust = { n: 4, sp: 12, vy: -8, g: -4, life: 1200, r: [1, 1.8], col: ['#fff3a0', '#ffffff', '#cdeaff', '#ffd2f0'], kind: 'star' };
    if (RR.PRE && !RR.PRE.fruitjuice) RR.PRE.fruitjuice = { n: 5, sp: 22, vy: -20, g: 90, life: 800, r: [0.8, 1.3], col: ['#ff3a4e', '#a8d84a', '#ffad3a'], kind: 'drop' };
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.5]], wfl: [[0, 0]], fL: [[0, 0]], fR: [[0, 0]], cb: [[0, 0]], blush: [[0, 0]] }, LP = 12400, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    // basket sway: rocks side to side on the basket bottom, paws on the rim, head leaning into it, crown cherries bouncing, wings fluttering
    for (let i = 0; i < 5; i++) { const d = i % 2 ? 1 : -1, t = 200 + i * 450; at(t, { tilt: d * 9, x: d * 3, htilt: d * 4, armL: d < 0 ? 40 : 15, armR: d > 0 ? 40 : 15, cb: 0.6, wfl: 0.2 }); if (i % 2) em(t, 'note', 'head', 1); }
    at(2500, { tilt: 0, x: 0, htilt: 0, armL: 20, armR: 20, cb: 0 });
    // fruit juggle: tosses the cherry up and catches it, then the pear, leaning back to watch each one fly
    at(2700, { armL: 70, sq: 0.12 }, 'i'); at(2800, { armL: 160, sq: -0.05, fL: 0, pitch: 0 }, 'o'); at(3150, { pitch: -0.25, htilt: -5 }); at(3500, { fL: 1, armL: 90, pitch: 0, htilt: 0, sq: 0.1 }, 'l'); at(3501, { fL: 0 }, 'l'); em(3150, 'spark', 'fruitL', 1);
    at(3600, { armR: 70, sq: 0.12 }, 'i'); at(3700, { armR: 160, sq: -0.05, fR: 0, pitch: 0 }, 'o'); at(4050, { pitch: -0.25, htilt: 5 }); at(4400, { fR: 1, armR: 90, pitch: 0, htilt: 0, sq: 0.1 }, 'l'); at(4401, { fR: 0 }, 'l'); em(4050, 'spark', 'fruitR', 1);
    at(4550, { sq: 0, armL: 30, armR: 30 });
    // fairy float: wings flutter fast, she lifts off and drifts in a figure of eight sprinkling fairy dust, then a slow twirl and a soft landing
    at(4750, { wfl: 1.2, lift: 10, sq: -0.08, armL: 100, armR: 100 }, 'o');
    for (let i = 1; i <= 6; i++) { const a = i / 6 * Math.PI * 2; at(4750 + i * 260, { x: 8 * Math.sin(a), lift: 14 + 4 * Math.sin(a * 2), tilt: 6 * Math.cos(a), wfl: 1.2, armL: 100 + 30 * Math.sin(a), armR: 100 - 30 * Math.sin(a) }, 'l'); em(4750 + i * 260, 'fairydust', i % 2 ? 'pawL' : 'pawR', 2); }
    at(5500, { spin: 0 }); at(6300, { spin: 360 }); at(6301, { spin: 0 }, 'l');
    at(6500, { x: 0, tilt: 0, lift: 0, sq: 0.22, wfl: 0.2, armL: 30, armR: 30 }, 'i'); em(6500, 'dust', [40, 96], 2); em(6500, 'dust', [60, 96], 2);
    // fruit-salad toss: both fruits fly up together, she twirls round under them and catches them back in the basket
    at(6750, { sq: 0.2, armL: 60, armR: 60, fL: 0, fR: 0 }, 'i'); at(6900, { sq: -0.12, lift: 4, armL: 165, armR: 165, open: 0.9, spin: 0 }, 'o');
    at(7550, { spin: 360, lift: 2 }); at(7551, { spin: 0 }, 'l'); at(7800, { fL: 1, fR: 1 }, 'l'); at(7801, { fL: 0, fR: 0 }, 'l');
    at(7800, { lift: 0, sq: 0.3, armL: 40, armR: 40, open: 0.6 }, 'i'); em(7800, 'fruitjuice', [50, 62], 4); em(7850, 'spark', 'head', 2); em(7250, 'fairydust', 'head', 2);
    at(8050, { sq: 0 });
    // hula sway: a slow sway, the basket swinging one way while her head leans the other, paws waving like she's tossing a salad
    for (let i = 0; i <= 8; i++) { const a = i / 8 * Math.PI * 2; at(8250 + i * 230, { x: 6 * Math.sin(a), tilt: 10 * Math.sin(a), htilt: -9 * Math.sin(a), armL: 90 + 50 * Math.sin(a), armR: 90 - 50 * Math.sin(a), cb: 0.5, wfl: 0.3 }, 'l'); }
    [8450, 8910, 9370, 9830].forEach(t => em(t, 'note', 'head', 1));
    at(10300, { x: 0, tilt: 0, htilt: 0, armL: 30, armR: 30, cb: 0 });
    // basket hops: three little hops, the fruits bouncing in the basket
    [10450, 10750, 11050].forEach((t, i) => { at(t, { lift: 7, sq: -0.08, cb: 1, x: (i - 1) * 4 }, 'o'); at(t + 150, { lift: 0, sq: 0.18, cb: 0.3 }, 'i'); em(t + 150, 'dust', [50 + (i - 1) * 4, 96], 2); });
    // curtsy + wink: dips the basket with a blush, one paw up, wink
    at(11400, { x: 0, sq: 0.2, pitch: 0.25, armL: 60, armR: 60, blush: 0.8, cb: 0 }, 'i'); at(11700, { sq: 0, pitch: 0, tilt: 6, htilt: 6, armL: 25, armR: 165, winkR: 0, wfl: 0.6 }, 'o'); at(11850, { winkR: 1 }); at(12100, { winkR: 0 }); em(11850, 'heart', 'head', 2); em(11800, 'fairydust', 'wingR', 3);
    at(12300, { tilt: 0, htilt: 0, armL: 0, armR: 0, blush: 0, wfl: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    K.sq.forEach(k => { if (k[1] > 0) k[1] *= 0.7; });
    RR.add({ 'dance@tutti': { loop: LP, k: K, ev } }); }
  // Melo's own dance, "Summer Surf" (beach-day watermelon moves): he surfs on his rind like a surfboard (leans into the waves, paws out for balance, bobbing on the swell),
  // wipes out and pops back up, a rapid-fire seed-spitting contest (recoil on every pew), a picnic-fan flip (flips back and forth showing his rind back and juicy front),
  // a belly-drum on his flesh with juice splashes, a big final seed spit + hang-loose wink (11.6 s loop). Channels: sdj (seed jiggle)
  function moDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@melo']) return;
    if (RR.PRE && !RR.PRE.melojuice) RR.PRE.melojuice = { n: 6, sp: 24, vy: -22, g: 90, life: 820, r: [0.8, 1.3], col: ['#ff6a82', '#ffc4cc', '#e83c5c'], kind: 'drop' };
    if (RR.PRE && !RR.PRE.meloseed) RR.PRE.meloseed = { n: 2, sp: 34, vy: -18, g: 70, life: 700, r: [0.9, 1.3], col: ['#3a2340', '#5a3a60'], kind: 'drop' };
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.5]], sdj: [[0, 0]] }, LP = 11600, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    // surfing: sideways stance, paws out for balance, rides the swell up and down, carving left and right
    at(200, { turn: 0, armL: 40, armR: 40 }); at(500, { turn: 0.35, armL: 100, armR: 80, sq: 0.08 });
    for (let i = 0; i <= 10; i++) { const a = i / 10 * Math.PI * 2; at(600 + i * 190, { lift: 3 + 3 * Math.sin(a * 2), x: 6 * Math.sin(a), tilt: 10 * Math.cos(a), lean: 4 * Math.cos(a), armL: 95 + 25 * Math.sin(a), armR: 85 - 25 * Math.sin(a), sdj: 0.3 }, 'l'); if (i % 3 === 1) em(600 + i * 190, 'melojuice', [50, 96], 2); }
    // wipe-out: tips over the lip of the wave, wobbles, pops back up
    at(2700, { tilt: 24, x: 8, lift: 2, wide: 1, open: 0.8, armL: 170, armR: 30, sdj: 1 }, 'i'); at(2950, { tilt: -10, x: 4, lift: 0, sq: 0.25, sdj: 1 }, 'i'); em(2950, 'melojuice', [58, 90], 5);
    at(3200, { tilt: 5, sq: -0.1, lift: 6, turn: 0, wide: 0, open: 0.6, armL: 150, armR: 150 }, 'o'); at(3450, { tilt: 0, x: 0, lift: 0, sq: 0.1, sdj: 0, armL: 40, armR: 40 }, 'i'); at(3600, { sq: 0 });
    // seed-spitting contest: puffs up, then pew-pew-pew-pew! - each spit kicks him back a little
    at(3800, { sq: 0.15, mw: 0.4, open: 0, hap: 0.5 }, 'i');
    for (let i = 0; i < 5; i++) { const t = 3950 + i * 230, d = i % 2 ? 1 : -1; at(t, { pitch: 0.25, htilt: d * 4, open: 1, mw: 0.5, sq: -0.08, x: -1.2 * i, sdj: 1 }, 'o'); at(t + 120, { pitch: -0.05, open: 0.1, sq: 0.05, sdj: 0.3 }, 'i'); em(t, 'meloseed', [50 + d * 4, 60], 1); }
    at(5250, { x: 0, pitch: 0, htilt: 0, hap: 0.85, mw: 1, open: 0.5, sdj: 0, sq: 0 }); em(5250, 'note', 'head', 1);
    // picnic-fan flip: flips round to show his rind back, back to the juicy front, again faster - fanning like a paper fan
    [[5450, 180], [5800, 0], [6050, 180], [6250, 360]].forEach(([t, s]) => at(t, { spin: s, armL: 120, armR: 120, lift: 2 }));
    at(6251, { spin: 0 }, 'l'); at(6450, { lift: 0, armL: 40, armR: 40, sq: 0.1 }, 'i'); at(6600, { sq: 0 });
    // belly drum: paws pat-pat-pat on his flesh, juice splashing, seeds jiggling
    for (let i = 0; i < 8; i++) { const L = i % 2 === 0, t = 6800 + i * 170; at(t, { armL: L ? 20 : 70, armR: L ? 70 : 20, hLx: L ? 6 : 0, hRx: L ? 0 : 6, sq: 0.08, sdj: 1, htilt: L ? 3 : -3 }, 'i'); at(t + 85, { sq: 0, sdj: 0.4 }, 'o'); if (i % 2) em(t, 'melojuice', [50, 70], 2); }
    at(8250, { hLx: 0, hRx: 0, armL: 40, armR: 40, sdj: 0, htilt: 0 }); em(8100, 'note', 'head', 1); em(8250, 'note', 'head', 1);
    // big seed spit: winds up, leans way back, then the champion spit - seed flies far, he jumps for joy
    at(8500, { pitch: -0.4, sq: 0.2, mw: 0.4, open: 0, armL: 30, armR: 30 }, 'i'); at(8900, { pitch: -0.4, sq: 0.25 });
    at(9050, { pitch: 0.35, sq: -0.15, open: 1, mw: 0.6, sdj: 1 }, 'o'); em(9050, 'meloseed', [50, 58], 2); em(9050, 'spark', 'head', 2);
    at(9350, { pitch: 0, sq: 0.2, open: 0.6, mw: 1, sdj: 0 }, 'i'); at(9600, { sq: -0.15, lift: 14, armL: 170, armR: 170, open: 0.9 }, 'o'); at(9950, { lift: 0, sq: 0.25, armL: 50, armR: 50, open: 0.5, sdj: 1 }, 'i'); em(9950, 'melojuice', [35, 90], 3); em(9950, 'melojuice', [65, 90], 3); at(10200, { sq: 0, sdj: 0 });
    // hang-loose pose + wink
    at(10450, { tilt: 6, htilt: 5, armL: 30, armR: 160, winkR: 0 }); at(10650, { winkR: 1 }); at(11000, { winkR: 0 }); em(10650, 'heart', 'head', 2);
    at(11400, { tilt: 0, htilt: 0, armL: 0, armR: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    K.sq.forEach(k => { if (k[1] > 0) k[1] *= 0.7; }); // wide slab body flattens a lot, so squashes are gentler
    RR.add({ 'dance@melo': { loop: LP, k: K, ev } }); }
  // Pina's own dance, "Tropical Sway" (pineapple / island moves): hula hip sways with ocean-wave arms and the crown swishing, crown shake (leaves flare out and whirl),
  // coconut bongo drumming, a limbo bend-back shuffle, a pineapple upside-down flip, sunshine pose with sparkles + wink (11 s loop). Channels: crw (crown flare), crs (crown whirl)
  function pnDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@pina']) return;
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.5]], crw: [[0, 0]], crs: [[0, 0]] }, LP = 11000, ev = [], HC = 31;
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    // hula: slow hip circles, arms ripple like waves to one side, crown swishes against the hips
    for (let i = 0; i < 4; i++) { const d = i % 2 ? 1 : -1, t = 300 + i * 600; at(t, { x: d * 4, lean: -d * 3, tilt: d * 6, htilt: -d * 4, armL: d < 0 ? 120 : 60, armR: d > 0 ? 120 : 60, curl: d * 0.6, sq: 0.08, lift: 0, crw: 0.2, crs: -d * 0.25, footL: d > 0 ? 2 : 0, footR: d < 0 ? 2 : 0 });
      at(t + 300, { sq: 0.02, armL: d < 0 ? 95 : 85, armR: d > 0 ? 95 : 85, curl: -d * 0.4 }); if (i % 2) em(t, 'note', 'head', 1); }
    // crown shake: crouch, pop up, leaves flare and whirl round
    at(2700, { x: 0, lean: 0, tilt: 0, htilt: 0, curl: 0, footL: 0, footR: 0, sq: 0.25, armL: 30, armR: 30, crw: -0.2, crs: 0 }, 'i');
    at(2950, { sq: -0.12, lift: 8, armL: 160, armR: 160, crw: 1, open: 0.85, wide: 0.5 }, 'o'); em(2950, 'spark', 'head', 4);
    for (let i = 0; i < 6; i++) at(3050 + i * 110, { htilt: i % 2 ? 6 : -6, crs: (i + 1) * 0.5 }, 'l');
    at(3750, { lift: 0, sq: 0.2, htilt: 0, crs: 3.2, crw: 0.3, wide: 0, open: 0.5, armL: 50, armR: 50 }, 'i'); at(3950, { sq: 0, crs: 0, crw: 0 }); em(3750, 'dust', [40, 96], 2); em(3750, 'dust', [60, 96], 2);
    // coconut bongos: paws drum in front, body bops on every beat
    for (let i = 0; i < 8; i++) { const L = i % 2 === 0, t = 4050 + i * 170; at(t, { armL: L ? 70 : 20, armR: L ? 20 : 70, sq: 0.1, lift: 0, x: L ? -1 : 1, htilt: L ? -3 : 3, crw: 0.15 }, 'i'); at(t + 85, { sq: 0.02, crw: 0 }, 'o'); if (i % 2 === 0) em(t, 'note', 'body', 1); }
    // limbo: bend back low and shuffle under the bar left to right
    at(5550, { x: -9, htilt: 0, sq: 0.3, pitch: -0.7, lean: -4, armL: 95, armR: 95, crw: 0.4, footL: 0, footR: 0 });
    for (let i = 1; i <= 6; i++) at(5550 + i * 220, { x: -9 + i * 3, footL: i % 2 ? 2 : 0, footR: i % 2 ? 0 : 2, sq: 0.3 + (i % 2) * 0.04 }, 'l');
    at(7100, { x: 9, sq: 0.15, pitch: 0, lean: 0, footL: 0, footR: 0, armL: 160, armR: 160, crw: 0.8, open: 0.8 }, 'o'); em(7100, 'spark', 'head', 3);
    // upside-down flip: a full forward roll over the crown, landing back on the feet
    at(7450, { x: 6, sq: 0.25, armL: 40, armR: 40, crw: 0, open: 0.5, tilt: 0, lift: 0 }, 'i');
    for (let k = 0; k <= 20; k++) { const u = k / 20, e = u * u * (3 - 2 * u), a = -360 * e, th = a * Math.PI / 180; at(7600 + 900 * u, { tilt: a, x: 6 - 12 * e - HC * Math.sin(th), lift: HC * (1 - Math.cos(th)) + 10 * Math.sin(Math.PI * u), sq: -0.05, crw: 0.6 * Math.sin(Math.PI * u) }, 'l'); }
    at(8501, { tilt: 0 }, 'l'); at(8650, { lift: 0, x: -6, sq: 0.3, crw: -0.3, armL: 60, armR: 60 }, 'i'); em(8650, 'dust', [38, 96], 3); em(8650, 'dust', [56, 96], 3);
    at(8850, { sq: -0.06, crw: 0.4, x: -3 }, 'o'); at(9050, { sq: 0, crw: 0, x: 0 });
    // sunshine pose: arms up like rays, crown fans wide, sparkles, wink
    at(9300, { armL: 150, armR: 150, sq: -0.05, lift: 3, crw: 1, wide: 0.4, crs: 0 }, 'o'); em(9300, 'spark', 'head', 5);
    at(9800, { lift: 0, sq: 0, tilt: 5, htilt: 5, armL: 40, armR: 165, crw: 0.3, wide: 0, winkR: 0 }); at(10000, { winkR: 1 }); at(10350, { winkR: 0 }); em(10000, 'heart', 'head', 1);
    at(10800, { tilt: 0, htilt: 0, armL: 0, armR: 0, crw: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@pina': { loop: LP, k: K, ev } }); }
  // Boba's own dance, "Tapioca Shake": shaker rattle with the pearls flying, a big straw slurp (a pearl rides up the straw) and pop jump, tapioca twists with the pearls swirling, a whirlpool spin, straw sways, wink (10 s loop)
  function boDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@boba']) return;
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.5]], pop: [[0, 0]], stw: [[0, 0]], swirl: [[0, 0]], slurp: [[0, 0]], sup: [[0, 0]] }, LP = 10000, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    at(150, { sq: 0.12, armL: 150, armR: 150, pop: 1, stw: 1, wide: 0.4, open: 0.7 });
    for (let i = 0; i < 14; i++) { const o = i % 2, s = i % 4 < 2 ? -1 : 1, t = 250 + i * 110; at(t, { lift: o ? 5 : 0, sq: o ? -0.08 : 0.1, tilt: s * 4, x: s * 1.2 }, 'l'); }
    [400, 800, 1200, 1600].forEach(t => em(t, 'bubble', 'head', 1));
    at(1850, { lift: 0, sq: 0, tilt: 0, x: 0, pop: 0.2, stw: 0, armL: 40, armR: 40, wide: 0, open: 0.5 });
    at(2150, { sq: 0.22, puff: 0.7, pitch: 0.12, open: 0.1, armL: 70, armR: 70, slurp: 0 }, 'i'); at(2350, { slurp: 1 }); at(3100, { slurp: 1, sq: 0.3, puff: 0.9 });
    at(3300, { slurp: 0, sq: -0.16, lift: 11, puff: 0, pitch: -0.1, open: 0.85, wide: 0.6, armL: 165, armR: 165, sup: 1, pop: 1.6 }, 'o'); em(3300, 'bubble', 'head', 3);
    at(3600, { lift: 0, sq: 0.28, pitch: 0, wide: 0, open: 0.5, armL: 60, armR: 60, sup: 0, pop: 0.3 }, 'i'); em(3600, 'dust', 'footL', 2); em(3600, 'dust', 'footR', 2);
    at(3750, { sq: -0.08 }); at(3900, { sq: 0.04 }); at(4000, { sq: 0, swirl: 0.6 });
    for (let i = 0; i < 6; i++) { const d = i % 2 ? 1 : -1, t = 4100 + i * 260; at(t, { turn: d * 0.4, tilt: -d * 5, x: d * 3, lean: d * 1.5, armL: d < 0 ? 140 : 30, armR: d > 0 ? 140 : 30, footL: d < 0 ? 3 : 0, footR: d > 0 ? 3 : 0, sq: 0.08, swirl: d * 0.8, htilt: d * 3 }); at(t + 130, { sq: -0.03 }, 'o'); }
    at(5750, { turn: 0, tilt: 0, x: 0, lean: 0, footL: 0, footR: 0, htilt: 0, armL: 20, armR: 20, sq: 0.24, swirl: 0, lift: 0 }, 'i'); at(5800, { spin: 0 }, 'l');
    at(6150, { lift: 13, sq: -0.14, armL: 170, armR: 170, wide: 0.5, open: 0.85, swirl: 2.5, pop: 0.8, stw: 1 }, 'o'); at(7000, { spin: 360, lift: 12 }); at(7001, { spin: 0 }, 'l'); [6300, 6600, 6900].forEach(t => em(t, 'spark', 'body', 2));
    at(7300, { lift: 0, sq: 0.34, armL: 50, armR: 50, wide: 0, open: 0.5, swirl: 0, stw: 0, pop: 1.4 }, 'i'); em(7300, 'dust', 'footL', 3); em(7300, 'dust', 'footR', 3);
    [[7450, -0.12], [7600, 0.1], [7750, 0]].forEach(([t, v]) => at(t, { sq: v })); at(7750, { pop: 0.1 });
    for (let i = 0; i < 4; i++) { const d = i % 2 ? 1 : -1, t = 7900 + i * 280; at(t, { tilt: d * 9, x: d * 4, lean: d * 2, htilt: -d * 3, armL: d < 0 ? 160 : 70, armR: d > 0 ? 160 : 70, sq: 0.05, lift: 2 }); at(t + 140, { lift: 0 }, 'o'); }
    at(9100, { tilt: 4, x: 0, lean: 0, htilt: 6, armR: 160, armL: 40, sup: 1, stw: 0.6, winkR: 0, sq: -0.04 }, 'o'); at(9300, { winkR: 1 }); at(9600, { winkR: 0, sup: 0 }); em(9300, 'heart', 'head', 1);
    at(9900, { tilt: 0, htilt: 0, armL: 0, armR: 0, stw: 0, sq: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@boba': { loop: LP, k: K, ev } }); }
  // Chef Bun's own dance, "Chef's Kiss": dough kneading presses, stir-the-pot circles, pancake-flip spin, seasoning sprinkle steps, hat-tip bow, chef's kiss + wink (10 s loop)
  function cbDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@chefbun']) return;
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.5]] }, LP = 10000, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    for (let i = 0; i < 6; i++) { const d = i % 2 ? 1 : -1, t = 150 + i * 280; at(t, { sq: 0.24, armL: d < 0 ? -20 : 70, armR: d > 0 ? -20 : 70, x: d * 1.5, tilt: d * 3, htilt: -d * 3, earL: -4, earR: 4 }, 'i'); at(t + 140, { sq: -0.04, earL: 0, earR: 0 }, 'o'); em(t, 'dust', d < 0 ? 'pawL' : 'pawR', 1); }
    at(1900, { sq: 0, x: 0, tilt: 0, htilt: 0, armL: 40, armR: 40 });
    for (let i = 0; i <= 8; i++) { const a = i / 8 * Math.PI * 2, t = 2000 + i * 190; at(t, { x: Math.cos(a) * 4, lift: 1.5 + Math.sin(a) * 1.5, tilt: Math.cos(a) * 5, turn: Math.sin(a) * 0.25, armR: 100 + Math.sin(a) * 30, armL: 40 + Math.cos(a) * 15, htilt: Math.cos(a) * 3, sq: 0.04 }); }
    em(2300, 'steam', 'head', 2); em(2900, 'steam', 'head', 2);
    at(3650, { x: 0, lift: 0, tilt: 0, turn: 0, htilt: 0, sq: 0.28, armL: -15, armR: -15, earL: -6, earR: 6 }, 'i'); at(3700, { spin: 0 }, 'l');
    at(4050, { lift: 16, sq: -0.15, armL: 170, armR: 170, wide: 0.6, open: 0.85, earL: 10, earR: -10 }, 'o'); at(4650, { spin: 360, lift: 14 }); at(4651, { spin: 0 }, 'l'); em(4100, 'spark', 'head', 3);
    at(4950, { lift: 0, sq: 0.34, armL: 60, armR: 60, wide: 0, open: 0.5, earL: 0, earR: 0 }, 'i'); em(4950, 'dust', 'footL', 3); em(4950, 'dust', 'footR', 3);
    [[5100, -0.12], [5250, 0.1], [5400, 0]].forEach(([t, v]) => at(t, { sq: v }));
    for (let i = 0; i < 6; i++) { const d = i % 2 ? 1 : -1, t = 5500 + i * 260; at(t, { x: d * 4, turn: d * 0.3, footL: d < 0 ? 3 : 0, footR: d > 0 ? 3 : 0, armR: 160 + d * 12, armL: 50, tilt: d * 4, sq: 0.06, lift: 0 }); at(t + 130, { sq: -0.03, lift: 2 }, 'o'); em(t + 60, 'salt', 'pawR', 2); }
    at(7100, { x: 0, turn: 0, footL: 0, footR: 0, tilt: 0, lift: 0, armR: 40, armL: 40, sq: 0 });
    at(7400, { pitch: 0.35, lean: 1.5, sq: 0.12, armR: 150, armL: 20, earL: -8, earR: 8, close: 0.6 }); at(7900, { pitch: 0.35, sq: 0.1 });
    at(8200, { pitch: -0.1, lift: 6, sq: -0.1, armL: 130, armR: 130, close: 0, wide: 0.4, open: 0.8, earL: 6, earR: -6 }, 'o'); at(8450, { lift: 0, pitch: 0, sq: 0.18, wide: 0, open: 0.5, earL: 0, earR: 0, lean: 0 }, 'i'); at(8600, { sq: 0 });
    at(8800, { armR: 150, armL: 40, htilt: 6, tilt: 3, winkR: 0 }); at(9100, { winkR: 1, armR: 175, sq: -0.04 }, 'o'); at(9450, { winkR: 0 }); em(9100, 'heart', 'mouth', 1); em(9200, 'spark', 'pawR', 2);
    at(9850, { armL: 0, armR: 0, htilt: 0, tilt: 0, sq: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@chefbun': { loop: LP, k: K, ev } }); }
  // Pip's own dance, "Waddle Wobble" (from penguin dance moves: waddle, flipper flaps, belly slide, shake-off, spin, proud emperor pose, wobble): 11 s loop
  function ppDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@pip']) return;
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.5]] }, LP = 11000, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    for (let i = 0; i < 8; i++) { const d = i % 2 ? 1 : -1, t = 150 + i * 290; at(t, { tilt: d * 8, x: d * 2.5, htilt: -d * 3, footL: d > 0 ? 3.5 : 0, footR: d < 0 ? 3.5 : 0, armL: 35, armR: 35, wag: d * 14, sq: 0.07, flap: 0.35 }); at(t + 145, { sq: -0.02, flap: 0 }, 'o'); if (i % 2) em(t, 'dust', d > 0 ? 'footR' : 'footL', 1); }
    at(2500, { tilt: 0, x: 0, htilt: 0, footL: 0, footR: 0, wag: 0, armL: 70, armR: 70, sq: 0.16 }, 'i');
    for (let i = 0; i < 3; i++) { const t = 2650 + i * 300; at(t, { lift: 7, sq: -0.1, flap: 1, open: 0.85 }, 'o'); at(t + 150, { lift: 0, sq: 0.14 }, 'i'); em(t, 'spark', i % 2 ? 'pawR' : 'pawL', 1); }
    at(3600, { lift: 0, sq: 0.26, flap: 0, armL: 0, armR: 0, open: 0.5 }, 'i'); at(3650, { spin: 0, tilt: 0, x: 0 });
    at(4000, { spin: 90, tilt: 80, lift: 25, x: -44, sq: 0, armL: -10, armR: -10, wide: 0.4, open: 0.75, footL: 2, footR: 2 }, 'o');
    at(5300, { spin: 90, tilt: 80, lift: 25, x: -24, wag: 10 }, 'l'); [4200, 4600, 5000].forEach(t => em(t, 'dust', 'body', 2));
    at(5750, { tilt: 0, lift: 0, x: 0, sq: 0.2, wide: 0, open: 0.5, armL: 20, armR: 20, footL: 0, footR: 0, wag: 0 }, 'io'); at(6050, { spin: 0, sq: 0 });
    for (let i = 0; i < 10; i++) { const d = i % 2 ? 1 : -1, t = 6150 + i * 85; at(t, { tilt: d * 4, htilt: -d * 6, wag: d * 22, flap: 1, close: 0.7, x: d * 0.6, sq: 0.03 }, 'l'); }
    [6200, 6450, 6700].forEach(t => em(t, 'bubble', 'head', 2));
    at(7100, { tilt: 0, htilt: 0, wag: 0, flap: 0, close: 0, x: 0, sq: 0.28, armL: -10, armR: -10 }, 'i'); at(7150, { spin: 0 }, 'l');
    at(7500, { lift: 13, sq: -0.14, armL: 120, armR: 120, flap: 1, wide: 0.5, open: 0.85 }, 'o'); at(8100, { spin: 360, lift: 12 }); at(8101, { spin: 0 }, 'l'); em(7600, 'spark', 'head', 3);
    at(8350, { lift: 0, sq: 0.3, flap: 0, armL: 20, armR: 20, wide: 0, open: 0.5 }, 'i'); em(8350, 'dust', 'footL', 2); em(8350, 'dust', 'footR', 2);
    at(8600, { sq: -0.13, pitch: -0.14, armL: -18, armR: -18, open: 0.3 }, 'o'); at(9200, { sq: -0.13, pitch: -0.14 });
    for (let i = 0; i < 3; i++) { const d = i % 2 ? 1 : -1, t = 9400 + i * 300; at(t, { tilt: d * 11, lean: d * 2, htilt: -d * 4, sq: 0.04, pitch: 0, flap: 0.5, armL: 40, armR: 40, open: 0.7 }); }
    at(10300, { tilt: 3, lean: 0, htilt: 6, flap: 0, armR: 110, armL: 30, winkR: 0 }, 'o'); at(10500, { winkR: 1 }); at(10800, { winkR: 0 }); em(10500, 'heart', 'head', 1);
    at(10900, { tilt: 0, htilt: 0, armL: 0, armR: 0, sq: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@pip': { loop: LP, k: K, ev } }); }
  // Jelli's own dance, "Jelly Jive": a jellyfish jam. Pulse-bounces to the beat (bell squeezes, tentacles trail), side-to-side sway with tentacles waving up, twirl with spiralling tentacles, bloom (tentacles fan out + glow, then a big pulse), wiggly drift down, wave + wink (10 s loop)
  function jlDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@jelli']) return;
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.5]], jon: [[0, 1]] }, LP = 11000, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    for (let i = 0; i < 4; i++) { const t = 100 + i * 520, L = 1 + i * 2; at(t, { jc: 0.05, lift: L, sq: 0.03 }); at(t + 180, { jc: 1.15, lift: L + 5, sq: -0.06, armL: 30, armR: 30 }, 'o'); at(t + 500, { jc: 0, lift: L + 3, armL: 0, armR: 0 }, 'io'); if (i % 2) em(t + 180, 'bubble', 'head', 1); }
    for (let i = 0; i <= 12; i++) { const a = -Math.PI / 2 + i / 12 * Math.PI * 2, t = 2300 + i * 260; at(t, { x: 14 * Math.cos(a), lift: 9 + 6 * Math.sin(a), tilt: -Math.sin(a) * 12, lean: -Math.sin(a) * 2, htilt: Math.sin(a) * 3, jc: i % 2 ? 0.1 : 1.05, jw: 0.8, armL: 40, armR: 40 }, i % 2 ? 'io' : 'o'); if (i % 3 === 0) em(t, 'bubble', 'head', 1); }
    at(5650, { x: 0, lift: 11, tilt: 0, lean: 0, htilt: 0, jc: 0.2, jw: 0.4, armL: 50, armR: 50, jsw: 0, jsp: 0, glo: 0 }); at(5700, { spin: 0 }, 'l');
    at(5900, { jsw: 1.3, lift: 14, jc: 0.8, jw: 1, armL: 70, armR: 70, wide: 0.4, open: 0.8 }, 'o'); at(6800, { spin: 360, lift: 13, jsw: 1.3 }); at(6801, { spin: 0 }, 'l'); em(6000, 'spark', 'head', 2);
    at(7050, { jsw: 0, jsp: 0, glo: 0, lift: 11, jc: 0.1, jw: 0.3, wide: 0, open: 0.5 });
    at(7350, { jsp: 1, jc: -0.25, glo: 1, armL: 95, armR: 95, lift: 11, wide: 0.5, open: 0.8 }, 'o'); em(7350, 'spark', 'body', 3);
    at(7800, { jc: 1.2, jsp: -0.3, lift: 16, glo: 0.6, armL: 10, armR: 10 }, 'o'); at(8250, { jc: 0, jsp: 0, glo: 0.15, lift: 13, wide: 0, open: 0.5 }, 'io');
    [[8550, -12, 10, 9], [8900, 0, 7, 0], [9250, 12, 5, -9], [9600, 0, 3, 0]].forEach(([t, x, l, tl]) => at(t, { x, lift: l, tilt: tl, jw: 1.6, jc: 0.4 })); [8600, 9000, 9400].forEach(t => em(t, 'bubble', 'head', 1));
    at(9850, { jc: 1, lift: 5, jw: 0.3, armR: 150, armL: 30, htilt: 6, tilt: 0, winkR: 0 }, 'o'); at(10150, { winkR: 1, jc: 0.2 }); at(10450, { winkR: 0 }); em(10150, 'heart', 'head', 1);
    at(10850, { armL: 0, armR: 0, htilt: 0, lift: 0, jc: 0, x: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@jelli': { loop: LP, k: K, ev } }); }
  // Octo's own dance, "Tentacle Tango": noodle-arm sway, stadium wave round his arms, jet squirt with an ink puff + parachute float down, sideways tentacle crawl, flared twirl, wiggle shimmy, wave + wink (11.5 s loop)
  function ocDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@octo']) return;
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.5]] }, LP = 11500, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    for (let i = 0; i < 4; i++) { const t = 100 + i * 550, d = i % 2 ? 1 : -1; at(t, { x: d * 7, tilt: -d * 7, lean: d * 2, htilt: d * 4, armL: d < 0 ? 135 : 25, armR: d > 0 ? 135 : 25, ow: 1.4, lift: 3, sq: -0.04 }); at(t + 300, { lift: 0, sq: 0.1 }, 'i'); if (i % 2) em(t, 'bubble', 'head', 1); }
    at(2350, { x: 0, tilt: 0, lean: 0, htilt: 0, lift: 2, sq: 0, armL: 80, armR: 80, osp: 0.9, orp: 1, ow: 0.6 });
    for (let i = 0; i < 4; i++) { const t = 2550 + i * 330; at(t, { lift: 5, htilt: i % 2 ? 5 : -5 }, 'o'); at(t + 165, { lift: 2 }, 'i'); }
    at(3850, { osp: 0.2, orp: 0, armL: 30, armR: 30, lift: 0, htilt: 0 });
    at(4100, { sq: 0.3, osp: 0.7, open: 0.2, lift: 0, ojt: 0 });
    at(4350, { sq: -0.2, ojt: 1, lift: 19, osp: 0, armL: -15, armR: -15, open: 0.6 }, 'o'); at(4250, { ink: 0 }, 'l'); at(4290, { ink: 1 }, 'l'); at(4800, { ink: 0 }, 'l'); em(4380, 'bubble', 'body', 3);
    at(4800, { ojt: 0.15, sq: 0, lift: 18 });
    at(5100, { osp: 1.3, ocl: -0.6, armL: 60, armR: 60, x: -4, tilt: -4, lift: 13 }, 'o'); at(5450, { x: 3, tilt: 3, lift: 8 }); at(5700, { lift: 0, sq: 0.26, osp: 0.4, ocl: 0, x: 0, tilt: 0, ojt: 0 }, 'i'); at(5850, { sq: 0, osp: 0 }, 'o');
    at(6000, { x: 0, turn: 0, armL: 20, armR: 20 }); at(6550, { x: -12, turn: -0.4, htilt: -3 }, 's'); at(7200, { x: 12, turn: 0.4, htilt: 3 }, 's'); at(7600, { x: 0, turn: 0, htilt: 0 }, 's');
    at(7650, { spin: 0 }, 'l'); at(7800, { lift: 8, osp: 0.6, armL: 100, armR: 100, open: 0.8 }, 'o'); at(8700, { spin: 360, lift: 6 }); at(8701, { spin: 0 }, 'l'); em(7900, 'spark', 'head', 2);
    at(8900, { lift: 0, osp: 0, sq: 0.18, open: 0.5 }, 'i'); at(9050, { sq: 0 });
    for (let i = 0; i < 8; i++) { const t = 9100 + i * 140, d = i % 2 ? 1 : -1; at(t, { x: d * 2, armL: 150 + d * 15, armR: 150 - d * 15, htilt: d * 4, ow: 2.6, open: 0.9 }); if (i % 3 === 0) em(t, 'bubble', 'head', 1); }
    at(10300, { x: 0, ow: 0.5, htilt: 6, armR: 150, armL: -10, ocl: 0.35, open: 0.5 }, 'o'); at(10550, { winkR: 1 }); at(10900, { winkR: 0 }); em(10550, 'heart', 'head', 1);
    at(11350, { htilt: 0, armL: 0, armR: 0, ocl: 0, ow: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@octo': { loop: LP, k: K, ev } }); }
  // Puff's own dance, "Puffer Party": fin-flap swim bobs, sudden bloat + jet deflate, beat bloat-hops, big balloon float spin, side shuffle, bloated ball bounces, deflate twirl, wave + wink (11.5 s loop)
  function pfDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@puff']) return;
    const K = { hap: [[0, 0.9]], smile: [[0, 1]], open: [[0, 0.5]], swim: [[0, 0.6]], blo: [[0, 0]] }, LP = 11500, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    for (let i = 0; i < 4; i++) { const t = 100 + i * 450, d = i % 2 ? 1 : -1; at(t + 225, { lift: 5, x: d * 6, tilt: d * 8, htilt: -d * 4, sq: -0.06, swim: 1.2 }, 'o'); at(t + 450, { lift: 0.5, sq: 0.08, tilt: d * 3 }, 'i'); em(t + 225, 'bubble', 'head', 1); }
    at(1950, { x: 0, tilt: 0, htilt: 0, lift: 0, sq: 0.12, swim: 0.6, armL: 30, armR: 30 });
    at(2100, { blo: 1.15, sq: -0.04, lift: 3 }, 'o'); at(2280, { blo: 1 }); at(2500, { lift: 5, htilt: 5 }); at(2750, { lift: 4, htilt: -5 }); em(2100, 'spark', 'head', 3);
    at(2950, { blo: 1, htilt: 0 }); at(3200, { blo: 0, x: -10, tilt: -14, lift: 6, swim: 1.5 }, 'o'); at(3500, { x: 0, tilt: 0, lift: 0, sq: 0.14, swim: 0.6 }, 'io');
    for (let i = 0; i < 3; i++) { const t = 3650 + i * 420, d = i % 2 ? 1 : -1; at(t, { sq: 0.14, lift: 0, blo: 0 }, 'i'); at(t + 150, { blo: 0.65, lift: 6, sq: -0.06, x: d * 4, tilt: d * 5 }, 'o'); at(t + 330, { blo: 0.1, lift: 1 }, 'io'); em(t + 330, 'bubble', 'mouth', 2); }
    at(4950, { blo: 0, x: 0, tilt: 0, lift: 0, sq: 0.15 });
    at(5100, { blo: 1.25, sq: -0.05, lift: 2, armL: 60, armR: 60 }, 'o'); at(5250, { blo: 1.1 }); at(5251, { spin: 0 }, 'l'); em(5100, 'spark', 'head', 3);
    at(5550, { lift: 8 }); at(6350, { spin: 360, lift: 9 }, 'io'); at(6351, { spin: 0 }, 'l');
    at(6550, { blo: 1.05, lift: 8 }); at(6800, { blo: 0, lift: 2, sq: -0.1, swim: 1.5 }, 'o'); at(7000, { lift: 0, sq: 0.2 }, 'i'); at(7150, { sq: -0.04 }); at(7300, { sq: 0, swim: 0.7 });
    for (let i = 0; i < 4; i++) { const t = 7350 + i * 300, d = i % 2 ? 1 : -1; at(t + 150, { x: d * 8, turn: d * 0.45, tilt: d * 4, lift: 2, armL: d < 0 ? 120 : 30, armR: d > 0 ? 120 : 30 }, 'o'); at(t + 300, { lift: 0, sq: 0.06 }, 'i'); }
    at(8600, { x: 0, turn: 0, tilt: 0, armL: 30, armR: 30, sq: 0.1 });
    at(8750, { blo: 1.1, sq: 0 }, 'o'); for (let i = 0; i < 3; i++) { const t = 8900 + i * 380; at(t + 190, { lift: 7 - i * 2, sq: -0.04 }, 'o'); at(t + 380, { lift: 0, sq: 0.16 }, 'i'); em(t + 380, 'drop', [50, 90], 2); }
    at(10050, { spin: 0, sq: 0 }, 'l'); at(10150, { blo: 0, lift: 3, sq: -0.05, swim: 1.5 }, 'o'); at(10500, { spin: 360, lift: 0, sq: 0.08 }); at(10501, { spin: 0 }, 'l');
    at(10650, { sq: 0, swim: 0.6, armR: 125, armL: 25, htilt: 6, winkR: 0 }, 'o'); at(10800, { winkR: 1 }); at(11050, { winkR: 0 }); em(10800, 'heart', 'head', 1);
    at(11300, { htilt: 0, armL: 0, armR: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@puff': { loop: LP, k: K, ev } }); }
  // Shelly's own dance, "Shell Shuffle" (turtle moves): shuffle steps with neck bobs, periscope neck stretch + look-around, peek-a-boo hide/pop, shell spin on the ground, sea-turtle swim strokes, stomp twist, neck stretch + wave + wink (11.5 s loop)
  function shDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@shelly']) return;
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.45]], hid: [[0, 0]], nk: [[0, 0]] }, LP = 11500, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    for (let i = 0; i < 4; i++) { const t = 100 + i * 520, d = i % 2 ? 1 : -1; at(t + 260, { x: d * 7, tilt: d * 5, htilt: -d * 6, nk: 0.7, turn: d * 0.3, lift: 1.5, armL: d < 0 ? 30 : 0, armR: d > 0 ? 30 : 0 }, 'o'); at(t + 520, { nk: 0, lift: 0, sq: 0.06, tilt: d * 1.5 }, 'i'); em(t + 520, 'dust', [50 + d * 7, 89], 1); }
    at(2250, { x: 0, tilt: 0, htilt: 0, turn: 0, sq: 0, armL: 0, armR: 0 });
    at(2600, { nk: 1.5, sq: -0.05, open: 0.6 }, 'o'); at(2900, { turn: -0.8, htilt: 5 }); at(3250, { turn: 0.8, htilt: -5 }); at(3500, { turn: 0, htilt: 0 }); at(3700, { nk: 0, sq: 0.08, open: 0.45 }, 'i'); em(2650, 'spark', 'head', 2);
    [[3750, 4050], [4300, 4600]].forEach(([a, b]) => { at(a, { hid: 0, sq: 0.08 }); at(a + 130, { hid: 1, sq: 0.15 }, 'o'); at(b - 40, { hid: 1, sq: 0.1 }); at(b + 120, { hid: 0, nk: 1, sq: -0.08, lift: 4, armL: 100, armR: 100, open: 0.95 }, 'o'); at(b + 300, { nk: 0.2, lift: 0, sq: 0.05, armL: 10, armR: 10, open: 0.5 }, 'i'); em(b + 120, 'spark', 'head', 3); });
    at(5000, { hid: 0, armL: 0, armR: 0, nk: 0, sq: 0 }); at(5150, { hid: 1, sq: 0.12 }, 'o'); at(5200, { spin: 0 }, 'l'); at(6300, { spin: 720 }, 'io'); at(6301, { spin: 0 }, 'l');
    [5500, 5800, 6100].forEach(t => em(t, 'spark', [50, 84], 2)); em(5600, 'dust', [36, 89], 2); em(5900, 'dust', [64, 89], 2);
    at(6350, { hid: 1, sq: 0.12 }); at(6500, { hid: 0, nk: 1.2, sq: -0.1, lift: 5, armL: 120, armR: 120, open: 0.95 }, 'o'); at(6750, { lift: 0, nk: 0.3, sq: 0.06, armL: 20, armR: 20, open: 0.5 }, 'i');
    at(7000, { lift: 7, sq: -0.03, x: -8, tilt: -6, nk: 0.8, open: 0.6 }, 'o');
    for (let i = 0; i < 4; i++) { const t = 7050 + i * 400; at(t + 200, { armL: 115, armR: -20, tilt: -4 + i * 2.6, htilt: 4, lift: 8, x: -8 + i * 4 }); at(t + 400, { armL: -20, armR: 115, htilt: -4, lift: 6.5 }); em(t + 200, 'bubble', 'head', 1); }
    at(8800, { x: 8, tilt: 4, lift: 7 }); at(9000, { x: 0, tilt: 0, lift: 0, sq: 0.18, armL: 0, armR: 0, nk: 0, htilt: 0, open: 0.45 }, 'i'); em(9000, 'dust', [50, 89], 3);
    for (let i = 0; i < 4; i++) { const t = 9150 + i * 330, d = i % 2 ? 1 : -1; at(t, { armL: d < 0 ? 55 : 0, armR: d > 0 ? 55 : 0, turn: d * 0.5, htilt: d * 7, nk: 0.5, sq: -0.03 }, 'o'); at(t + 165, { armL: 0, armR: 0, sq: 0.08, nk: 0.1 }, 'i'); em(t + 165, 'dust', d < 0 ? 'pawL' : 'pawR', 1); }
    at(10500, { turn: 0, htilt: 0, sq: 0 });
    at(10750, { nk: 1.1, armR: 120, armL: 0, htilt: 6, winkR: 0 }, 'o'); at(10850, { winkR: 1 }); at(11100, { winkR: 0 }); em(10850, 'heart', 'head', 1);
    at(11350, { nk: 0, armR: 0, htilt: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@shelly': { loop: LP, k: K, ev } }); }
  // Sealy's own dance, "Seal Slide" (real seal moves): belly galumphs, sit-up flipper claps with barks, banana rocks (head + hind flippers up), belly slide across the ice and back, roll-over, clap + wave + wink (11 s loop)
  function slDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@sealy']) return;
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.45]], swim: [[0, 0.3]], flip: [[0, 0]], fsp: [[0, 0]] }, LP = 11000, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]), XS = [0, 5, 10, 5, 0], HC = 31;
    for (let b = 0; b < 4; b++) { const t = 100 + b * 600, d = b < 2 ? 1 : -1;
      at(t + 220, { sq: 0.2, pitch: -0.12, lift: 0, flip: 0.9, fsp: -0.3, armL: -15, armR: -15, x: XS[b], turn: d * 0.3, open: 0.3 });
      at(t + 450, { sq: -0.1, pitch: 0.1, lift: 3.5, flip: 0.1, fsp: 0.2, x: XS[b] + (XS[b + 1] - XS[b]) * 0.8, armL: 35, armR: 35, open: 0.75 }, 'o');
      at(t + 600, { sq: 0.07, lift: 0, pitch: 0, x: XS[b + 1] }, 'i'); em(t + 600, 'drop', [50 + XS[b + 1], 90], 2); }
    at(2600, { sq: 0, turn: 0, x: 0, flip: 0, fsp: 0, armL: 20, armR: 20 });
    at(2900, { pitch: -0.34, lift: 4, sq: -0.08, flip: 0.6, armL: 110, armR: 110, open: 0.5 }, 'o');
    for (let i = 0; i < 6; i++) { const t = 3050 + i * 240; at(t, { armL: 152, armR: 152, open: 0.95, htilt: (i % 2 ? 1 : -1) * 6, sq: -0.04, flip: 0.75 }, 'o'); at(t + 120, { armL: 112, armR: 112, open: 0.35, sq: -0.1, flip: 0.55 }); em(t, 'spark', 'head', 1); }
    at(4700, { pitch: 0, lift: 0, htilt: 0, sq: 0.05, armL: 60, armR: 60, flip: 0, open: 0.5 });
    for (let i = 0; i < 3; i++) { const t = 4900 + i * 440; at(t, { pitch: -0.36, flip: 1.3, fsp: 0.5, lift: 2, sq: -0.05, armL: 80, armR: 80, wide: 0.5, open: 0.85 }); at(t + 220, { pitch: 0.26, flip: -0.3, fsp: 0, lift: 0, sq: 0.1, armL: 40, armR: 40, wide: 0, open: 0.4 }); }
    at(6200, { spin: 0 }, 'l'); at(6250, { pitch: 0, flip: 0, sq: 0, armL: 20, armR: 20 });
    at(6550, { spin: 90, x: -12, sq: 0.15, pitch: 0.14, armL: -25, armR: -25, flip: 0.5, open: 0.6 });
    at(7350, { spin: 90, x: 13, sq: 0.18, flip: 0.7 }, 'o'); [6700, 6900, 7100].forEach((t, i) => em(t, 'drop', [38 + i * 9, 90], 2));
    at(7750, { spin: 270, sq: 0.12, flip: 0.4 }); at(8450, { spin: 270, x: 0, sq: 0.16, flip: 0.7 }, 'o'); [7950, 8150].forEach((t, i) => em(t, 'drop', [60 - i * 8, 90], 2));
    at(8750, { spin: 360, sq: 0, pitch: 0, flip: 0, armL: 30, armR: 30, open: 0.5 }); at(8751, { spin: 0 }, 'l');
    for (let s = 0; s <= 24; s++) { const u = s / 24, e = u * u * (3 - 2 * u), th = e * Math.PI * 2; at(8850 + 800 * u, { tilt: e * 360, x: -6 + 12 * e - HC * Math.sin(th), lift: HC * (1 - Math.cos(th)) + 4 * Math.sin(Math.PI * u), armL: 90, armR: 90, open: 0.8 }, 'l'); }
    at(9651, { tilt: 0 }, 'l'); em(9650, 'drop', [56, 90], 3);
    at(9900, { x: 0, pitch: -0.2, lift: 2, armL: 140, armR: 140, open: 0.9, flip: 0.6 }, 'o');
    [10050, 10300].forEach(t => { at(t, { armL: 152, armR: 152, open: 0.95 }, 'o'); at(t + 120, { armL: 115, armR: 115, open: 0.4 }); em(t, 'spark', 'head', 1); });
    at(10500, { pitch: 0, lift: 0, armR: 125, armL: 25, htilt: 6, flip: 0.3, winkR: 0 }, 'o'); at(10650, { winkR: 1 }); at(10900, { winkR: 0 }); em(10650, 'heart', 'head', 1);
    at(10950, { htilt: 0, armL: 0, armR: 0, sq: 0, flip: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@sealy': { loop: LP, k: K, ev } }); }
  // ---------- Elemental Heroes: power effects that run in every animation (subtle when calm, big in the dance) ----------
  const HERO = { magmara: { eye: ['#fff6b0', '#ff6a1a'], glow: '#ffb03a' }, chronoshade: { eye: ['#f6e6ff', '#8a3aff'], glow: '#b07aff' }, gigagrowth: { eye: ['#f2ffb8', '#3fc84a'], glow: '#9dff6a' }, crystalline: { eye: ['#c9a6ff', '#5a2a9a'] }, aeroswift: { hov: 2.4 }, phantasm: { hov: 1.8, noFace: 1 } };
  const hrnd = n => { const v = Math.sin(n * 12.9898 + 4.1) * 43758.5453; return v - Math.floor(v); };
  function heroSetup(I, root, art, key, H, items) {
    const { mk } = H, u = I.u, RC = HERO[key];
    const bk = mk('g', {}, root); root.insertBefore(bk, art); const fr = mk('g', {}, root), df = mk('defs', {}, bk);
    const X = I.hx = { key, bk, fr, art, pw: 0.4, hov: RC.hov || 0, noFace: !!RC.noFace, ang: 0, ang2: 0, vx: 0, lx: null, rocks: [], sprouts: [], shk: null, wasAir: false, maxL: 0 };
    if (RC.eye) { const gr = I.faceG.querySelector('[id="gey' + u + '"]'); if (gr) { const st = gr.querySelectorAll('stop'); st[0].setAttribute('stop-color', RC.eye[0]); st[1].setAttribute('stop-color', RC.eye[1]); } }
    const pth = (par, a) => mk('path', a, par);
    if (RC.glow) { df.innerHTML += '<radialGradient id="hxe' + u + '"><stop offset="0.3" stop-color="' + RC.glow + '" stop-opacity="0"/><stop offset="0.55" stop-color="' + RC.glow + '" stop-opacity="0.6"/><stop offset="1" stop-color="' + RC.glow + '" stop-opacity="0"/></radialGradient>'; X.eg = [0, 1].map(() => mk('circle', { fill: 'url(#hxe' + u + ')', opacity: 0 }, fr)); }
    if (key === 'magmara') {
      df.innerHTML += '<radialGradient id="hxf' + u + '"><stop offset="0" stop-color="#fffbe0"/><stop offset="0.35" stop-color="#ffd23a"/><stop offset="0.7" stop-color="#ff6a1a" stop-opacity="0.85"/><stop offset="1" stop-color="#ff3a0a" stop-opacity="0"/></radialGradient><linearGradient id="hxv' + u + '" x1="0" y1="1" x2="0" y2="0"><stop offset="0" stop-color="#ff3a0a"/><stop offset="0.5" stop-color="#ff8a1e"/><stop offset="1" stop-color="#ffe45a"/></linearGradient>';
      X.lava = items.filter(q => q.e.getAttribute('stroke') === '#ff8a1e'); X.smk = [0, 1].map(() => pth(bk, { fill: 'none', stroke: '#b8aeb6', 'stroke-width': 1.6, 'stroke-linecap': 'round', 'stroke-linejoin': 'round' })); X.gy = pth(bk, { fill: 'url(#hxv' + u + ')' });
      X.ckG = pth(fr, { fill: 'none', stroke: '#ff5a1a', 'stroke-width': 2.6, 'stroke-linecap': 'round', 'stroke-linejoin': 'round', opacity: 0 }); X.ckL = pth(fr, { fill: 'none', stroke: '#ffd23a', 'stroke-width': 1, 'stroke-linecap': 'round', 'stroke-linejoin': 'round', opacity: 0 });
      X.dr = pth(fr, { fill: '#ff8a1e' }); X.flO = pth(fr, { fill: '#ff6a1a', opacity: 0.9 }); X.flI = pth(fr, { fill: '#ffd23a' }); X.em = pth(fr, { fill: '#ffb03a' });
      X.fb = [0, 1].map(() => ({ t: pth(fr, { fill: 'none', stroke: '#ff8a1e', 'stroke-width': 2.4, 'stroke-linecap': 'round', opacity: 0 }), b: mk('circle', { fill: 'url(#hxf' + u + ')', opacity: 0 }, fr) })); X.cracks = []; X.drops = []; }
    if (key === 'chronoshade') { art.setAttribute('id', 'hxa' + u);
      df.innerHTML += '<radialGradient id="hxk' + u + '" cx="45%" cy="30%" r="85%"><stop offset="0" stop-color="#4e4470"/><stop offset="0.6" stop-color="#2a2442"/><stop offset="1" stop-color="#15111f"/></radialGradient><radialGradient id="hxd' + u + '"><stop offset="0" stop-color="#c49aff" stop-opacity="0.32"/><stop offset="0.8" stop-color="#7a3aff" stop-opacity="0.12"/><stop offset="1" stop-color="#7a3aff" stop-opacity="0"/></radialGradient><filter id="hxt' + u + '" x="-20%" y="-20%" width="140%" height="140%"><feColorMatrix type="matrix" values="0.25 0.1 0.1 0 0.25  0.1 0.15 0.1 0 0.1  0.2 0.2 0.4 0 0.45  0 0 0 1 0"/></filter>';
      X.gh = [0, 1, 2].map(() => { const e = document.createElementNS('http://www.w3.org/2000/svg', 'use'); e.setAttribute('href', '#hxa' + u); e.setAttribute('filter', 'url(#hxt' + u + ')'); e.setAttribute('opacity', 0); bk.appendChild(e); return e; }); X.hist = [];
      X.cg = mk('g', {}, bk); X.cl = pth(X.cg, { fill: 'url(#hxk' + u + ')', stroke: '#6a50a0', 'stroke-width': 0.6, 'stroke-linejoin': 'round' });
      X.dial = mk('g', {}, bk); X.dF = mk('circle', { fill: 'url(#hxd' + u + ')', stroke: '#b98aff', 'stroke-width': 0.8 }, X.dial); X.dR = mk('circle', { fill: 'none', stroke: '#9a6ae0', 'stroke-width': 0.4, opacity: 0.8 }, X.dial); X.dT = pth(X.dial, { fill: 'none', stroke: '#d8bcff', 'stroke-width': 0.7, 'stroke-linecap': 'round' }); X.dH = pth(X.dial, { fill: 'none', stroke: '#f0e0ff', 'stroke-width': 1.1, 'stroke-linecap': 'round' }); X.dC = mk('circle', { fill: '#f0e0ff' }, X.dial);
      X.rb = [0, 1].map(() => ({ b: pth(bk, { fill: 'none', stroke: '#241a38', 'stroke-width': 2.6, 'stroke-linecap': 'round' }), f: pth(fr, { fill: 'none', stroke: '#241a38', 'stroke-width': 2.6, 'stroke-linecap': 'round' }), b2: pth(bk, { fill: 'none', stroke: '#9a5aff', 'stroke-width': 0.6, 'stroke-linecap': 'round' }), f2: pth(fr, { fill: 'none', stroke: '#b07aff', 'stroke-width': 0.6, 'stroke-linecap': 'round' }) }));
      X.fk = pth(fr, { fill: '#1e1630' }); X.fz = mk('circle', { fill: 'none', stroke: '#c49aff', opacity: 0 }, fr); X.mA = 0; }
    if (key === 'gigagrowth') {
      df.innerHTML += '<radialGradient id="hxl' + u + '" cx="38%" cy="30%" r="75%"><stop offset="0" stop-color="#d2f7a0"/><stop offset="0.6" stop-color="#74c44c"/><stop offset="1" stop-color="#3a8a34"/></radialGradient>';
      X.lv = Array.from({ length: 7 }, (_, i) => ({ e: pth(bk, { fill: 'url(#hxl' + u + ')', stroke: '#3a8a34', 'stroke-width': 0.3 }), ph: i / 7 }));
      X.sh = mk('ellipse', { fill: 'none', stroke: '#b9a27a', opacity: 0 }, bk); X.sh2 = mk('ellipse', { fill: 'none', stroke: '#e6d8b0', opacity: 0 }, fr);
      X.rk = pth(fr, { fill: '#8a7a5a', stroke: '#5a4a32', 'stroke-width': 0.3 }); X.sp = pth(fr, { fill: 'url(#hxl' + u + ')' });
      X.vn = pth(fr, { fill: 'none', stroke: '#4e8a3a', 'stroke-width': 2.4, 'stroke-linecap': 'round', 'stroke-linejoin': 'round' }); X.vl = pth(fr, { fill: 'url(#hxl' + u + ')' });
      X.fp = pth(fr, { fill: '#ff9ad6', stroke: '#ffffff', 'stroke-width': 0.25 }); X.fp2 = pth(fr, { fill: '#9ad8ff', stroke: '#ffffff', 'stroke-width': 0.25 }); X.fc = pth(fr, { fill: '#ffe45a' }); }
    if (key === 'crystalline') {
      X.sd = Array.from({ length: 6 }, () => ({ e: pth(bk, { stroke: '#ffffff', 'stroke-width': 0.5, 'stroke-linejoin': 'round' }), h: pth(bk, { fill: '#ffffff', opacity: 0.75 }) }));
      X.spk = pth(fr, { fill: '#ffffff' }); X.bm = ['#ff8ad8', '#ffe27a', '#8af0ff', '#b48cff'].map(c => pth(fr, { fill: 'none', stroke: c, 'stroke-width': 2.2, 'stroke-linecap': 'round', opacity: 0 }));
      const mg = art.querySelector('[id="g_g' + u + '"]'); X.gs = mg ? mg.querySelectorAll('stop') : []; }
    if (key === 'aeroswift') {
      X.wr = [0, 1, 2].map(() => ({ b: pth(bk, { fill: 'none', stroke: '#e8fbff', 'stroke-width': 1.5, 'stroke-linecap': 'round' }), f: pth(fr, { fill: 'none', stroke: '#ffffff', 'stroke-width': 1.5, 'stroke-linecap': 'round' }), b2: pth(bk, { fill: 'none', stroke: '#7ad6ff', 'stroke-width': 0.7, 'stroke-linecap': 'round' }), f2: pth(fr, { fill: 'none', stroke: '#7ad6ff', 'stroke-width': 0.7, 'stroke-linecap': 'round' }) }));
      X.tr = pth(bk, { fill: 'none', stroke: '#ffffff', 'stroke-width': 1.3, 'stroke-linecap': 'round' }); X.tr2 = pth(bk, { fill: 'none', stroke: '#8fe0ff', 'stroke-width': 0.7, 'stroke-linecap': 'round' });
      X.ds = mk('ellipse', { fill: 'none', stroke: '#ffffff', 'stroke-width': 1.1, 'stroke-dasharray': '3 4', 'stroke-linecap': 'round', opacity: 0 }, bk); }
    if (key === 'phantasm') {
      df.innerHTML = '<radialGradient id="hxc' + u + '" cx="45%" cy="35%" r="80%"><stop offset="0" stop-color="#6a3ab8"/><stop offset="0.45" stop-color="#3a1a7a"/><stop offset="0.8" stop-color="#1e0c48"/><stop offset="1" stop-color="#7a3ac8"/></radialGradient><radialGradient id="hxn' + u + '" cx="30%" cy="60%" r="45%"><stop offset="0" stop-color="#ff7ad8" stop-opacity="0.55"/><stop offset="1" stop-color="#ff7ad8" stop-opacity="0"/></radialGradient><radialGradient id="hxo' + u + '"><stop offset="0" stop-color="#ffffff"/><stop offset="0.3" stop-color="#e6b8ff"/><stop offset="0.65" stop-color="#a65cff" stop-opacity="0.55"/><stop offset="1" stop-color="#a65cff" stop-opacity="0"/></radialGradient>';
      X.cg = mk('g', {}, bk); X.cl = pth(X.cg, { fill: 'url(#hxc' + u + ')', stroke: '#9a64e6', 'stroke-width': 0.6, 'stroke-linejoin': 'round' }); X.cn = pth(X.cg, { fill: 'url(#hxn' + u + ')' }); X.cs = pth(X.cg, { fill: '#ffffff' });
      X.chB = pth(bk, { fill: 'none', stroke: '#c890ff', 'stroke-width': 1.6, 'stroke-dasharray': '2.6 1.6', 'stroke-linecap': 'round' }); X.chF = pth(fr, { fill: 'none', stroke: '#d8a8ff', 'stroke-width': 1.6, 'stroke-dasharray': '2.6 1.6', 'stroke-linecap': 'round' });
      X.ob = [0, 1].map(() => ({ g: mk('circle', { fill: 'url(#hxo' + u + ')' }, fr), r: mk('circle', { fill: 'none', stroke: '#e6c4ff', 'stroke-width': 0.6, 'stroke-dasharray': '1.5 1.2' }, fr) }));
      X.mt = pth(fr, { fill: '#f4e2ff' }); X.sw = items.find(q => q.e.getAttribute('stroke') === '#e9a0ff'); }
  }
  function heroFX(I, P, now, C) {
    const X = I.hx, { W, glob, sph, sphZ, byw, bywZ, face, toD, HY, G, TOP, set, r2, clamp, SM, TAU, E } = C, ts = now / 1000, dt = C.dtS || 0.016;
    const nm = (I.cur && I.cur.name) || '', tg = /dance/.test(nm) ? 1 : /sleep/.test(nm) ? 0.12 : /happy|cheer|love|unlock|hatch|grow|celebr|excite/.test(nm) ? 0.8 : 0.38;
    X.pw += (tg - X.pw) * Math.min(1, dt * 2.5); const pw = clamp(X.pw + (+P.pwr || 0), 0, 1.6);
    if (X.lx == null) X.lx = P.x; X.vx += ((P.x - X.lx) / Math.max(dt, 0.001) - X.vx) * Math.min(1, dt * 12); X.lx = P.x;
    const C0 = glob(50, (HY + G) / 2 + 2), vis = z => SM((z + 1) / 5);
    const lens = (x, y, a, l, w) => { const c = Math.cos(a), s = Math.sin(a), ax = c * l / 2, ay = s * l / 2, px = -s * w, py = c * w; return 'M' + r2(x - ax) + ' ' + r2(y - ay) + 'Q' + r2(x + px) + ' ' + r2(y + py) + ' ' + r2(x + ax) + ' ' + r2(y + ay) + 'Q' + r2(x - px) + ' ' + r2(y - py) + ' ' + r2(x - ax) + ' ' + r2(y - ay) + 'Z'; };
    const dia = (x, y, a, h, w) => { const c = Math.cos(a), s = Math.sin(a), q = (dx, dy) => r2(x + dx * c - dy * s) + ' ' + r2(y + dx * s + dy * c); return 'M' + q(0, -h) + 'L' + q(w, -h * 0.15) + 'L' + q(0, h * 0.75) + 'L' + q(-w, -h * 0.15) + 'Z'; };
    const st4 = (x, y, r) => 'M' + r2(x) + ' ' + r2(y - r) + 'Q' + r2(x) + ' ' + r2(y) + ' ' + r2(x + r) + ' ' + r2(y) + 'Q' + r2(x) + ' ' + r2(y) + ' ' + r2(x) + ' ' + r2(y + r) + 'Q' + r2(x) + ' ' + r2(y) + ' ' + r2(x - r) + ' ' + r2(y) + 'Q' + r2(x) + ' ' + r2(y) + ' ' + r2(x) + ' ' + r2(y - r) + 'Z';
    const circ = (x, y, r) => 'M' + r2(x - r) + ' ' + r2(y) + 'a' + r2(r) + ' ' + r2(r) + ' 0 1 0 ' + r2(2 * r) + ' 0a' + r2(r) + ' ' + r2(r) + ' 0 1 0 ' + r2(-2 * r) + ' 0';
    const arc = (cx, cy, rx, ry, a0, span, tl, n) => { let f = '', b = '', prev = null, pf = null; const ct = Math.cos(tl), sn = Math.sin(tl);
      for (let i = 0; i <= n; i++) { const a = a0 + span * i / n, x = Math.cos(a) * rx, y = Math.sin(a) * ry, p = r2(cx + x * ct - y * sn) + ' ' + r2(cy + x * sn + y * ct), fr = Math.sin(a) > 0;
        if (prev === null) { if (fr) f += 'M' + p; else b += 'M' + p; } else if (fr !== pf) { if (fr) f += 'M' + prev + 'L' + p; else b += 'M' + prev + 'L' + p; } else { if (fr) f += 'L' + p; else b += 'L' + p; }
        prev = p; pf = fr; } return [f, b]; };
    const lay = (e, front) => { const tgt = front ? X.fr : X.bk; if (e.parentNode !== tgt) tgt.appendChild(e); };
    const grow = clamp(+P.grow || 0, 0, 0.6), tf = grow > 0.002 ? 'translate(' + r2(50 + P.x) + ' ' + r2(G) + ') scale(' + r2(1 + grow) + ') translate(' + r2(-50 - P.x) + ' ' + r2(-G) + ')' : '';
    [X.art, X.bk, X.fr].forEach(e => { if (tf) set(e, 'transform', tf); else if (e.hasAttribute('transform')) e.removeAttribute('transform'); });
    if (X.eg) ['eyeL', 'eyeR'].forEach((k, i) => { const p = W[k], e = X.eg[i], o = E.eyes[i]; if (!p) return; set(e, 'cx', r2(p[0])); set(e, 'cy', r2(p[1])); set(e, 'r', r2(4.8 + pw * 1.2 + Math.sin(ts * 3 + i) * 0.4)); set(e, 'opacity', r2(clamp(0.3 + pw * 0.55, 0, 0.95) * (o ? +(o.g.getAttribute('opacity') || 1) : 1))); });
    if (X.key === 'gigagrowth') {
      const top = glob(50, TOP)[1];
      X.lv.forEach((L, i) => { const per = 4.6, uu = ((ts / per + L.ph) % 1), a = L.ph * TAU + ts * 0.7, Rr = 33 + 5 * Math.sin(uu * 5 + i), z = Math.sin(a), on = clamp(pw * 1.9 - i * 0.2, 0, 1);
        lay(L.e, z > 0); set(L.e, 'd', lens(C0[0] + Math.cos(a) * Rr, top + (G - top + 4) * uu, a * 2 + Math.sin(ts * 3 + i) * 0.8, 4.8 * (0.85 + 0.2 * z), 1.5)); set(L.e, 'opacity', r2(on * SM(uu * 6) * (1 - SM((uu - 0.86) / 0.14)))); });
      const air = P.lift > 2.2; if (air) { X.wasAir = true; X.maxL = Math.max(X.maxL, P.lift); }
      if (X.wasAir && P.lift < 0.6) { const s = clamp(X.maxL / 10, 0.5, 2.2); X.wasAir = false; X.maxL = 0; X.shk = { t: now, s };
        for (let k = 0; k < 7; k++) { const sd = k % 2 ? 1 : -1, r = hrnd(now + k); X.rocks.push({ x: 50 + P.x + sd * (14 + r * 18), y: G, vx: sd * (14 + r * 30) * s, vy: -(28 + hrnd(k * 7 + now) * 38) * s, r: 0.9 + hrnd(k * 3 + now) * 1.2, a: r * 6, t: now }); }
        [-1, 1].forEach((sd, k) => [0, 1].forEach(j => X.sprouts.push({ x: 50 + P.x + sd * (22 + j * 12 + hrnd(now + k + j) * 4), t: now + j * 90, h: 5 + j * 1.5 }))); }
      if (X.shk) { const k = (now - X.shk.t) / 750; if (k >= 1) { X.shk = null; set(X.sh, 'opacity', 0); set(X.sh2, 'opacity', 0); } else { const rx = 16 + 36 * SM(k) * (0.6 + X.shk.s * 0.3), o = (1 - k) * 0.85;
        [X.sh, X.sh2].forEach((e, j) => { set(e, 'cx', r2(50 + P.x)); set(e, 'cy', r2(G + 0.6)); set(e, 'rx', r2(rx * (j ? 0.75 : 1))); set(e, 'ry', r2(rx * 0.16 * (j ? 0.75 : 1))); set(e, 'stroke-width', r2((2.6 - j) * (1 - k) + 0.3)); set(e, 'opacity', r2(o)); }); } }
      let rd = ''; X.rocks = X.rocks.filter(q => now - q.t < 1400); X.rocks.forEach(q => { if (q.y < G + 0.5 || q.vy < 0) { q.vy += 160 * dt; q.x += q.vx * dt; q.y = Math.min(G + 0.5, q.y + q.vy * dt); q.a += dt * 8; } else { q.vx *= 0.8; } rd += dia(q.x, q.y, q.a, q.r * 1.3, q.r); }); set(X.rk, 'd', rd); set(X.rk, 'opacity', X.rocks.length ? 1 : 0);
      let sd2 = ''; X.sprouts = X.sprouts.filter(q => now - q.t < 1700); X.sprouts.forEach(q => { const a = clamp((now - q.t) / 1700, 0, 1); if (a <= 0) return; const h = q.h * Math.sin(Math.PI * Math.min(1, a * 1.25)) * (1 + pw * 0.3); if (h < 0.3) return;
        sd2 += lens(q.x, G - h * 0.5, Math.PI / 2, h, 0.45) + lens(q.x - h * 0.32, G - h * 0.78, -0.6, h * 0.62, h * 0.17) + lens(q.x + h * 0.32, G - h * 0.78, 0.6, h * 0.62, h * 0.17); }); set(X.sp, 'd', sd2);
      const vine = clamp(+P.vine || 0, 0, 1.4); let vd = '', vl = '';
      if (vine > 0.02) [-1, 1].forEach(sd => { const bx = 50 + P.x + sd * 37, n = 16, L = vine / 1.2; let pts = []; for (let i = 0; i <= n; i++) { const s = i / n * L, y = G - s * 46, x = bx + sd * (Math.sin(s * 6.5 + ts * 2.2) * 3.2 * s - s * s * 4); pts.push([x, y]); }
        vd += 'M' + pts.map(p => r2(p[0]) + ' ' + r2(p[1])).join('L'); [0.28, 0.5, 0.72, 0.92].forEach((f, j) => { const k = Math.round(f * n); if (f > L) return; const p = pts[Math.min(k, n)], sz = 3.6 * SM((L - f) / 0.12); vl += lens(p[0] + sd * (j % 2 ? 2 : -2), p[1], (j % 2 ? 0.5 : -0.5) * sd + Math.sin(ts * 3 + j) * 0.3, sz, sz * 0.32); });
        const tp = pts[n]; vl += circ(tp[0], tp[1], 1.4 * SM(L * 3)); });
      set(X.vn, 'd', vd); set(X.vl, 'd', vl);
      const bl = clamp(+P.bloom || 0, 0, 1.3); let f1 = '', f2 = '', fc = '';
      if (bl > 0.02) [[30, 64], [70, 60], [40, 80], [61, 79], [25, 48], [75, 46], [50, 86], [36, 56], [64, 70]].forEach(([x, y], i) => { const z = sphZ(x, y), k = clamp(bl * 1.7 - i * 0.09, 0, 1) * vis(z); if (k < 0.05) return; const p = sph(x, y), r = 1.5 * k * (1 + 0.1 * Math.sin(ts * 4 + i)); let d = ''; for (let j = 0; j < 5; j++) { const a = j / 5 * TAU + i; d += circ(p[0] + Math.cos(a) * r, p[1] + Math.sin(a) * r, r * 0.75); } if (i % 2) f2 += d; else f1 += d; fc += circ(p[0], p[1], r * 0.6); });
      set(X.fp, 'd', f1); set(X.fp2, 'd', f2); set(X.fc, 'd', fc); }
    if (X.key === 'crystalline') {
      X.ang += dt * (0.5 + 1.4 * pw + clamp(+P.whirl || 0, 0, 4) * 2.6); const bu = clamp(+P.burst || 0, 0, 1.6), Rr = 35 + bu * 18, h0 = ts * 70;
      X.sd.forEach((S, i) => { const a = X.ang + i * TAU / X.sd.length, z = Math.sin(a), x = C0[0] + Math.cos(a) * Rr, y = C0[1] - 6 + z * 7 + Math.sin(ts * 1.6 + i * 1.3) * 3, s = (0.85 + 0.22 * z) * (1 + bu * 0.25), rt = Math.sin(ts * 1.8 + i) * 0.45;
        lay(S.e, z > 0); lay(S.h, z > 0); set(S.e, 'd', dia(x, y, rt, 5 * s, 2.4 * s)); set(S.e, 'fill', 'hsl(' + r2((h0 + i * 60) % 360) + ',95%,' + (z > 0 ? 82 : 70) + '%)');
        set(S.h, 'd', dia(x - 0.7 * s, y - 1.6 * s, rt, 2 * s, 0.7 * s)); const o = r2(clamp(0.5 + pw * 0.5, 0, 1)); set(S.e, 'opacity', o); set(S.h, 'opacity', r2(o * 0.8)); });
      let sk = ''; for (let j = 0; j < 7; j++) { const per = 1.1 + j * 0.13, cyc = Math.floor(ts / per + j * 0.37), uu = (ts / per + j * 0.37) % 1, a = hrnd(cyc * 13 + j) * TAU, rr = 16 + hrnd(cyc * 7 + j) * 26; if (hrnd(cyc * 3 + j * 5) > 0.35 + pw * 0.5) continue; sk += st4(C0[0] + Math.cos(a) * rr, C0[1] - 6 + Math.sin(a) * rr * 0.85, (1.2 + pw * 1.6) * Math.sin(Math.PI * uu)); }
      set(X.spk, 'd', sk); set(X.spk, 'opacity', r2(clamp(0.4 + pw * 0.6, 0, 1)));
      const be = clamp(+P.beam || 0, 0, 1.3), ds = ['', '', '', ''];
      if (be > 0.02) ['pawL', 'pawR'].forEach((k, hi) => { const p = W[k]; if (!p) return; const sd = hi ? 1 : -1, a = -Math.PI / 2 + sd * 0.42 + Math.sin(ts * 3 + hi) * 0.08, L = 48 * be, dx = Math.cos(a), dy = Math.sin(a), nx = -dy, ny = dx;
        for (let j = 0; j < 4; j++) { const o = (j - 1.5) * 1.7; ds[j] += 'M' + r2(p[0] + nx * o * 0.3) + ' ' + r2(p[1] + ny * o * 0.3) + 'L' + r2(p[0] + dx * L + nx * o * (1 + be)) + ' ' + r2(p[1] + dy * L + ny * o * (1 + be)); } });
      X.bm.forEach((e, j) => { set(e, 'd', ds[j]); set(e, 'opacity', r2(clamp(be, 0, 1) * 0.8)); set(e, 'stroke-width', r2(1.6 + be * 1.4)); });
      if (X.gs.length > 2) { set(X.gs[1], 'stop-color', 'hsl(' + r2(268 + Math.sin(ts * 0.9) * 40 + bu * 30) + ',88%,90%)'); set(X.gs[2], 'stop-color', 'hsl(' + r2(258 + Math.sin(ts * 0.9 + 1.4) * 34) + ',62%,74%)'); } }
    if (X.key === 'aeroswift') {
      const gu = clamp(+P.gust || 0, 0, 2.2); X.ang += dt * (2 + 3 * pw + gu * 8);
      X.wr.forEach((Rg, i) => { const c = glob(50, G - 6 - i * 21), rx = (26 + i * 7) * (1 + gu * 0.22) + 3 * pw, a0 = X.ang * (1 + i * 0.25) + i * 2.1, sp = 3.4 + pw * 1.6 + gu, tl = -0.06 + i * 0.05 + clamp(P.tilt, -30, 30) * 0.01;
        const [f, b] = arc(c[0], c[1], rx, rx * 0.2, a0, sp, tl, 22), [f2, b2] = arc(c[0], c[1] + 1.2, rx * 0.86, rx * 0.17, a0 + 2.6, sp * 0.7, tl, 16), o = r2(clamp(0.22 + pw * 0.5 + gu * 0.2, 0, 0.95));
        set(Rg.f, 'd', f); set(Rg.b, 'd', b); set(Rg.f2, 'd', f2); set(Rg.b2, 'd', b2); [Rg.f, Rg.b, Rg.f2, Rg.b2].forEach(e => set(e, 'opacity', o)); });
      const v = Math.abs(X.vx), so = clamp((v - 10) / 40, 0, 0.85); let tr = '', tr2 = '';
      if (so > 0.01) { const sd = Math.sign(X.vx), L = clamp(v * 0.5, 6, 42); for (let j = 0; j < 4; j++) { const y = C0[1] - 18 + j * 10 + Math.sin(ts * 9 + j) * 1.2, x0 = C0[0] - sd * (24 + (j % 2) * 5); const sg = 'M' + r2(x0) + ' ' + r2(y) + 'L' + r2(x0 - sd * L * (0.7 + 0.3 * hrnd(j))) + ' ' + r2(y); if (j % 2) tr2 += sg; else tr += sg; } }
      set(X.tr, 'd', tr); set(X.tr2, 'd', tr2); set(X.tr, 'opacity', r2(so)); set(X.tr2, 'opacity', r2(so));
      set(X.ds, 'cx', r2(50 + P.x)); set(X.ds, 'cy', r2(G + 0.6)); set(X.ds, 'rx', r2(13 + pw * 5 + gu * 6)); set(X.ds, 'ry', r2(2.8 + gu)); set(X.ds, 'stroke-dashoffset', r2(-ts * 26 * (1 + gu))); set(X.ds, 'opacity', r2(clamp(pw * 0.7, 0, 0.8) * SM(P.lift / 3))); }
    if (X.key === 'phantasm') {
      E.eyes.forEach(o => set(o.g, 'opacity', 0)); [E.mouth, E.mopen, E.tongue, E.tout].forEach(e => set(e, 'opacity', 0));
      if (X.sw) { const a = ts * (0.9 + 1.8 * pw), c = Math.cos(a), s = Math.sin(a); const scx = X.sw.cx, scy = X.sw.cy; set(X.sw.e, 'd', toD(X.sw.segs, (x, y) => { const dx = x - scx, dy = y - scy; return face(scx + dx * c - dy * s, scy + dx * s + dy * c); })); }
      const ph = clamp(+P.phase || 0, 0, 1); set(X.art, 'opacity', r2(1 - ph * 0.92)); set(X.fr, 'opacity', r2(1 - ph * 0.6));
      const cp = clamp(+P.cape || 0, 0, 1.6), lag = clamp(-X.vx * 0.22, -12, 12), Y0 = 50, hem = G + 3, M = (x, y) => { const uu = clamp((y - Y0) / (hem - Y0), 0, 1), w = Math.sin(ts * 2.1 + y * 0.16) * (1.2 + cp * 2.4) * uu; return byw(x + lag * uu * uu + w + cp * 6 * uu * Math.sin(ts * 1.3), y, -9); };
      const pts = [[34, Y0], [27, 66], [21, hem - 2]]; for (let i = 0; i <= 12; i++) { const x = 21 + 58 * i / 12; pts.push([x, hem + Math.sin(ts * 3 + i * 1.1) * (1 + cp * 1.5) + (i % 2 ? 1.6 : 0)]); } pts.push([79, hem - 2], [73, 66], [66, Y0], [50, Y0 - 3]);
      set(X.cl, 'd', 'M' + pts.map(p => { const q = M(p[0], p[1]); return r2(q[0]) + ' ' + r2(q[1]); }).join('L') + 'Z'); set(X.cn, 'd', X.cl.getAttribute('d'));
      let cs = ''; for (let j = 0; j < 12; j++) { const uu = 0.15 + hrnd(j) * 0.8, x = 50 + (hrnd(j + 20) - 0.5) * (30 + 24 * uu), y = Y0 + uu * (hem - Y0), q = M(x, y), r = (0.35 + hrnd(j + 40) * 0.5) * (0.6 + 0.4 * Math.sin(ts * 3 + j * 1.7)); cs += circ(q[0], q[1], r); } set(X.cs, 'd', cs);
      const front = bywZ(50, -9) > 0; if (front !== X.cfr) { X.cfr = front; (front ? X.fr : X.bk).insertBefore(X.cg, (front ? X.fr : X.bk).firstChild); }
      const orb = clamp(+P.orb || 0, 0, 1.6); ['pawL', 'pawR'].forEach((k, i) => { const p = W[k], O = X.ob[i]; if (!p) return; const r = 3.4 + pw * 1.6 + orb * 2.6 + Math.sin(ts * 4 + i * 2) * 0.5, o = r2(clamp(0.4 + pw * 0.45 + orb * 0.3, 0, 1));
        set(O.g, 'cx', r2(p[0])); set(O.g, 'cy', r2(p[1] - 1)); set(O.g, 'r', r2(r)); set(O.g, 'opacity', o); set(O.r, 'cx', r2(p[0])); set(O.r, 'cy', r2(p[1] - 1)); set(O.r, 'r', r2(r * 0.8)); set(O.r, 'stroke-dashoffset', r2(ts * 8)); set(O.r, 'opacity', o); });
      const ch = clamp(+P.chain || 0, 0, 1.8); X.ang += dt * (0.4 + pw * 0.6 + ch * 2.5); const [cf, cb] = arc(C0[0], C0[1] + 2, 40 * (1 + ch * 0.12), 8.5 * (1 + ch * 0.3), X.ang, TAU, Math.sin(ts * 0.6) * 0.18, 44), co = r2(clamp(0.18 + pw * 0.5 + ch * 0.3, 0, 1));
      set(X.chF, 'd', cf); set(X.chB, 'd', cb); [X.chF, X.chB].forEach(e => { set(e, 'stroke-dashoffset', r2(-ts * (10 + ch * 30))); set(e, 'opacity', co); });
      let mt = ''; for (let j = 0; j < 8; j++) { const per = 2.6 + j * 0.2, uu = (ts / per + j * 0.29) % 1, cyc = Math.floor(ts / per + j * 0.29), x = C0[0] + (hrnd(cyc * 11 + j) - 0.5) * 70, y = G - uu * 74; mt += st4(x, y, (0.7 + pw * 0.8) * Math.sin(Math.PI * uu)); } set(X.mt, 'd', mt); set(X.mt, 'opacity', r2(clamp(0.3 + pw * 0.6, 0, 1))); }
    if (X.key === 'magmara') {
      const pl = 0.5 + 0.5 * Math.sin(ts * 3.2); X.lava.forEach((q, i) => set(q.e, 'stroke', 'hsl(' + r2(26 + 8 * Math.sin(ts * 2 + i)) + ',100%,' + r2(48 + (14 + 10 * pw) * pl) + '%)'));
      const fire = clamp(+P.fire || 0, 0, 1.8); let fo = '', fi = '';
      ['pawL', 'pawR'].forEach((k, i) => { const p = W[k]; if (!p) return; [0, 1].forEach(j => { const sc = j ? 0.55 : 1, ox = j ? (i ? 2.2 : -2.2) : 0, h = (4.5 + pw * 4 + fire * 6) * sc * (1 + 0.18 * Math.sin(ts * 15 + i * 2 + j * 3)), w = (2.4 + pw * 0.8 + fire * 1.3) * sc, sw = Math.sin(ts * 9 + i + j) * w * 0.6 - X.vx * 0.04, x = p[0] + ox, y = p[1] - 1;
        const fl = (hh, ww) => 'M' + r2(x - ww) + ' ' + r2(y) + 'Q' + r2(x - ww) + ' ' + r2(y - hh * 0.55) + ' ' + r2(x + sw) + ' ' + r2(y - hh) + 'Q' + r2(x + ww) + ' ' + r2(y - hh * 0.55) + ' ' + r2(x + ww) + ' ' + r2(y) + 'Q' + r2(x + ww) + ' ' + r2(y + ww) + ' ' + r2(x) + ' ' + r2(y + ww) + 'Q' + r2(x - ww) + ' ' + r2(y + ww) + ' ' + r2(x - ww) + ' ' + r2(y) + 'Z';
        fo += fl(h, w); fi += fl(h * 0.6, w * 0.55); }); });
      set(X.flO, 'd', fo); set(X.flI, 'd', fi); set(X.flO, 'opacity', r2(clamp(0.45 + pw * 0.5, 0, 0.95)));
      let em = ''; for (let j = 0; j < 10; j++) { const per = 1.8 + j * 0.17, uu = (ts / per + j * 0.31) % 1, cyc = Math.floor(ts / per + j * 0.31), x = C0[0] + (hrnd(cyc * 7 + j) - 0.5) * 50 + Math.sin(ts * 3 + j) * 2, y = G - 6 - uu * 70; if (hrnd(cyc * 5 + j * 3) > 0.3 + pw * 0.7) continue; em += circ(x, y, (0.4 + hrnd(j) * 0.5) * (1 - uu * 0.6)); }
      set(X.em, 'd', em); set(X.em, 'opacity', r2(clamp(0.5 + pw * 0.5, 0, 1)));
      X.smk.forEach((e, i) => { const sd = i ? 1 : -1, b = glob(50 + sd * 15, 49); let d = 'M' + r2(b[0]) + ' ' + r2(b[1]); for (let k = 1; k <= 6; k++) { const y = b[1] - k * 4, x = b[0] + sd * k * 0.8 + Math.sin(ts * 2.4 + k * 0.9 + i * 2) * (1 + k * 0.5); d += 'L' + r2(x) + ' ' + r2(y); } set(e, 'd', d); set(e, 'opacity', r2(0.12 + pw * 0.2)); set(e, 'stroke-width', r2(1.2 + pw)); });
      const air = P.lift > 2.2; if (air) { X.wasAir = true; X.maxL = Math.max(X.maxL, P.lift); }
      if (X.wasAir && P.lift < 0.6) { const s = clamp(X.maxL / 10, 0.5, 2); X.wasAir = false; X.maxL = 0; X.cracks.push({ t: now, x: 50 + P.x, s, seed: hrnd(now) * 100 });
        for (let k = 0; k < 8; k++) { const sd = k % 2 ? 1 : -1, r = hrnd(now + k * 3); X.drops.push({ x: 50 + P.x + sd * (8 + r * 12), y: G, vx: sd * (10 + r * 26) * s, vy: -(26 + hrnd(k * 5 + now) * 34) * s, r: 0.7 + hrnd(k + now) * 0.8, t: now }); } }
      let cg = '', co = 0; X.cracks = X.cracks.filter(c => now - c.t < 1100); X.cracks.forEach(c => { const k = (now - c.t) / 1100, L = (10 + 16 * c.s) * SM(k * 4); co = Math.max(co, 1 - SM((k - 0.5) / 0.5));
        for (let j = 0; j < 6; j++) { const sd = j % 2 ? 1 : -1, a = (j >> 1) * 0.5 + hrnd(c.seed * 9 + j) * 0.3; let x = c.x + sd * 4, y = G + 0.8; cg += 'M' + r2(x) + ' ' + r2(y); for (let m = 1; m <= 4; m++) { x += sd * L / 4; y = G + 0.8 + (hrnd(c.seed + j * 7 + m) - 0.5) * 2.2 + a * m * 0.5; cg += 'L' + r2(x) + ' ' + r2(y); } } });
      set(X.ckG, 'd', cg); set(X.ckL, 'd', cg); set(X.ckG, 'opacity', r2(co * 0.6)); set(X.ckL, 'opacity', r2(co));
      let dd = ''; X.drops = X.drops.filter(q => now - q.t < 1200); X.drops.forEach(q => { if (q.y < G + 0.5 || q.vy < 0) { q.vy += 150 * dt; q.x += q.vx * dt; q.y = Math.min(G + 0.5, q.y + q.vy * dt); } dd += circ(q.x, q.y, q.r * (1 - (now - q.t) / 1500)); }); set(X.dr, 'd', dd);
      const er = clamp(+P.erupt || 0, 0, 1.5); let gd = '';
      if (er > 0.02) [-1, 1].forEach(sd => { const bx = 50 + P.x + sd * 36, h = 44 * er * (1 + 0.06 * Math.sin(ts * 9 + sd)), w0 = 4.2, w1 = 2.6, top = G - h, wb = Math.sin(ts * 7 + sd) * 1.2;
        gd += 'M' + r2(bx - w0) + ' ' + r2(G) + 'Q' + r2(bx - w1 + wb) + ' ' + r2(G - h * 0.5) + ' ' + r2(bx - w1) + ' ' + r2(top) + 'L' + r2(bx + w1) + ' ' + r2(top) + 'Q' + r2(bx + w1 + wb) + ' ' + r2(G - h * 0.5) + ' ' + r2(bx + w0) + ' ' + r2(G) + 'Z';
        for (let j = 0; j < 4; j++) { const a = ts * 5 + j * 1.6 + sd; gd += circ(bx + Math.cos(a) * 3, top - 1 - Math.abs(Math.sin(a)) * 4 - j, (2.4 + j % 2) * Math.min(1, er * 2)); } });
      set(X.gy, 'd', gd);
      ['fbL', 'fbR'].forEach((k, i) => { const F = X.fb[i], u2 = clamp(+P[k] || 0, 0, 1), p = W[i ? 'pawR' : 'pawL']; if (!p || u2 < 0.01 || u2 > 0.99) { set(F.b, 'opacity', 0); set(F.t, 'opacity', 0); return; } const sd = i ? 1 : -1, x = p[0] + sd * u2 * 58, y = p[1] - 2 - u2 * 3, o = r2(1 - SM((u2 - 0.75) / 0.25));
        set(F.b, 'cx', r2(x)); set(F.b, 'cy', r2(y)); set(F.b, 'r', r2(3.6 + Math.sin(ts * 20) * 0.4)); set(F.b, 'opacity', o); set(F.t, 'd', 'M' + r2(x - sd * 2) + ' ' + r2(y) + 'L' + r2(x - sd * (6 + u2 * 14)) + ' ' + r2(y + 0.8)); set(F.t, 'opacity', r2(o * 0.6)); }); }
    if (X.key === 'chronoshade') {
      [E.mouth, E.mopen, E.tongue, E.tout].forEach(e => set(e, 'opacity', 0));
      const rw = clamp(+P.rewind || 0, 0, 1.5), fz = clamp(+P.freeze || 0, 0, 1), ckc = clamp(+P.clock || 0, 0, 1.5), run = 1 - fz * 0.92;
      X.hist.unshift([P.x, P.lift]); if (X.hist.length > 40) X.hist.length = 40;
      const gw = Math.max(rw, clamp((Math.abs(X.vx) - 14) / 40, 0, 0.55)), gsd = X.vx > 2 ? -1 : 1;
      X.gh.forEach((e, i) => { const h = X.hist[Math.min(X.hist.length - 1, (i + 1) * 6)]; if (!h || gw < 0.02) { set(e, 'opacity', 0); return; } set(e, 'transform', 'translate(' + r2(h[0] - P.x + gsd * (i + 1) * rw * 3.5) + ' ' + r2(P.lift - h[1]) + ')'); set(e, 'opacity', r2(gw * (0.42 - i * 0.12))); });
      X.mA += dt * (0.5 + pw * 0.6 - rw * 16) * run; const step = TAU / 60, mA = rw > 0.1 ? X.mA : Math.floor(X.mA / step) * step, hA = X.mA / 12;
      const hp = W.pawR || C0, bxp = hp[0] + 9, byp = hp[1] - 12, kk = clamp(ckc, 0, 1), cx = bxp + (C0[0] - bxp) * kk, cy = byp + (C0[1] - 14 - byp) * kk, Rd = 9 + pw * 2 + ckc * 16 + fz * 3;
      set(X.dF, 'cx', r2(cx)); set(X.dF, 'cy', r2(cy)); set(X.dF, 'r', r2(Rd)); set(X.dR, 'cx', r2(cx)); set(X.dR, 'cy', r2(cy)); set(X.dR, 'r', r2(Rd * 0.82));
      let td = ''; for (let j = 0; j < 12; j++) { const a = j / 12 * TAU, l = j % 3 ? 0.12 : 0.22; td += 'M' + r2(cx + Math.cos(a) * Rd * 0.92) + ' ' + r2(cy + Math.sin(a) * Rd * 0.92) + 'L' + r2(cx + Math.cos(a) * Rd * (0.92 - l)) + ' ' + r2(cy + Math.sin(a) * Rd * (0.92 - l)); } set(X.dT, 'd', td);
      set(X.dH, 'd', 'M' + r2(cx) + ' ' + r2(cy) + 'L' + r2(cx + Math.sin(mA) * Rd * 0.72) + ' ' + r2(cy - Math.cos(mA) * Rd * 0.72) + 'M' + r2(cx) + ' ' + r2(cy) + 'L' + r2(cx + Math.sin(hA) * Rd * 0.45) + ' ' + r2(cy - Math.cos(hA) * Rd * 0.45));
      set(X.dC, 'cx', r2(cx)); set(X.dC, 'cy', r2(cy)); set(X.dC, 'r', r2(0.9 + Rd * 0.03)); set(X.dial, 'opacity', r2(clamp(0.35 + pw * 0.5 + ckc * 0.3 + fz * 0.3, 0, 1))); set(X.dF, 'stroke-width', r2(0.6 + fz * 1.4));
      X.ang += dt * (1 + pw * 1.5 - rw * 6) * run;
      X.rb.forEach((Rg, i) => { const c = glob(50, G - 22 - i * 22), rx = 30 + i * 4 + pw * 3, a0 = X.ang * (i ? -1 : 1) + i * 2, tl = i ? 0.45 : -0.45, [f, b] = arc(c[0], c[1], rx, rx * 0.22, a0, 3.6, tl, 24), [f2, b2] = arc(c[0], c[1], rx, rx * 0.22, a0 + 0.4, 2.6, tl, 18), o = clamp(0.2 + pw * 0.45 + rw * 0.2, 0, 0.8);
        set(Rg.f, 'd', f); set(Rg.b, 'd', b); set(Rg.f2, 'd', f2); set(Rg.b2, 'd', b2); [Rg.f, Rg.b].forEach(e => set(e, 'opacity', r2(o * 0.8))); [Rg.f2, Rg.b2].forEach(e => set(e, 'opacity', r2(o))); });
      let fk = ''; for (let j = 0; j < 14; j++) { const a = X.ang * (0.8 + hrnd(j) * 0.6) + j * 0.9, rr = 22 + hrnd(j + 9) * 18, y = C0[1] - 10 + (hrnd(j + 3) - 0.5) * 50 + Math.sin(a) * 4, x = C0[0] + Math.cos(a) * rr, s = 0.5 + hrnd(j + 5) * 0.8; fk += 'M' + r2(x - s) + ' ' + r2(y) + 'L' + r2(x) + ' ' + r2(y - s) + 'L' + r2(x + s) + ' ' + r2(y) + 'L' + r2(x) + ' ' + r2(y + s) + 'Z'; } set(X.fk, 'd', fk); set(X.fk, 'opacity', r2(clamp(0.3 + pw * 0.5, 0, 0.9)));
      if (fz > 0.02) { const k2 = (ts * 1.6) % 1; set(X.fz, 'cx', r2(C0[0])); set(X.fz, 'cy', r2(C0[1] - 8)); set(X.fz, 'r', r2(16 + k2 * 30)); set(X.fz, 'stroke-width', r2(1.6 * (1 - k2))); set(X.fz, 'opacity', r2(fz * (1 - k2) * 0.8)); } else set(X.fz, 'opacity', 0);
      const lag = clamp(-X.vx * 0.22, -12, 12) * run, Y0 = 51, hem = G + 2, M = (x, y) => { const uu = clamp((y - Y0) / (hem - Y0), 0, 1), w = Math.sin(ts * 1.8 * run + y * 0.15) * 1.3 * uu; return byw(x + lag * uu * uu + w, y, -9); };
      const pts = [[36, Y0], [28, 66], [22, hem - 3]]; for (let i = 0; i <= 10; i++) pts.push([22 + 56 * i / 10, hem + (i % 2 ? -3.5 : 1) + Math.sin(ts * 2.4 + i) * 0.8]); pts.push([78, hem - 3], [72, 66], [64, Y0], [50, Y0 - 2]);
      set(X.cl, 'd', 'M' + pts.map(p => { const q = M(p[0], p[1]); return r2(q[0]) + ' ' + r2(q[1]); }).join('L') + 'Z');
      const front = bywZ(50, -9) > 0; if (front !== X.cfr) { X.cfr = front; (front ? X.fr : X.bk).insertBefore(X.cg, (front ? X.fr : X.bk).firstChild); } }
  }
  const HDANCE = {
    // Giga-Growth "Overgrowth Stomp": quake stomps (shockwave, rocks fly, sprouts pop), grows giant + chest beat, summons vines, spinning ground-pound, blooms flowers all over, wink
    gigagrowth(at, em) {
      for (let b = 0; b < 4; b++) { const t = 150 + b * 560, s = b % 2 ? 1 : -1; at(t + 220, { lift: 6, sq: -0.08, lean: s * 4, tilt: s * 5, armL: 45, armR: 45, open: 0.6 }, 'o'); at(t + 430, { lift: 0, sq: 0.24, tilt: 0, lean: 0, armL: -10, armR: -10, open: 0.35 }, 'i'); at(t + 550, { sq: 0.04 }); }
      at(2600, { grow: 0, sq: 0, armL: 20, armR: 20 }); at(3300, { grow: 0.32, sq: -0.06, armL: 150, armR: 150, open: 0.9, wide: 0.5, pwr: 0.4 }, 'o');
      for (let i = 0; i < 4; i++) { const t = 3450 + i * 220; at(t, { armL: i % 2 ? 150 : 95, armR: i % 2 ? 95 : 150, sq: 0.06 }, 'o'); at(t + 110, { sq: -0.04 }); em(t, 'spark', 'head', 1); }
      at(4500, { armL: 120, armR: 120, grow: 0.18, wide: 0, pwr: 0.2, sq: 0 }); at(5200, { vine: 1.2, turn: 0.35, tilt: -6, armL: 160, armR: 60 }, 'o'); at(5800, { turn: -0.35, tilt: 6, armL: 60, armR: 160 }); at(6300, { turn: 0, tilt: 0, armL: 100, armR: 100 });
      at(6650, { sq: 0.26, lift: 0, armL: -20, armR: -20, spin: 0, vine: 0.5 }); at(7200, { lift: 20, sq: -0.14, spin: 360, armL: 150, armR: 150, open: 0.9 }, 'o'); at(7480, { lift: 0, sq: 0.32 }, 'i'); at(7481, { spin: 0 }, 'l'); at(7700, { sq: 0.05, armL: 40, armR: 40 });
      at(7900, { grow: 0.08, bloom: 0, vine: 0.7 }); at(8700, { bloom: 1, armL: 130, armR: 130, sq: -0.06, pwr: 0.4 }, 'o'); em(8700, 'spark', 'head', 1); at(9100, { x: -6, tilt: -6 }); at(9500, { x: 6, tilt: 6 }); at(9900, { x: 0, tilt: 0, sq: 0 });
      at(10200, { armR: 140, armL: 20, htilt: 6, winkR: 0, pwr: 0 }); at(10400, { winkR: 1 }); at(10700, { winkR: 0 }); em(10400, 'heart', 'head', 1); at(10950, { bloom: 0, vine: 0, grow: 0, armL: 0, armR: 0, htilt: 0 }); },
    // Crystalline "Prism Waltz": waltz sways with shards orbiting, rainbow beams from raised hands, pirouette inside a whirling shard ring, crystal burst, rainbow wave, curtsy + wink
    crystalline(at, em) {
      for (let i = 0; i < 4; i++) { const t = 100 + i * 620, s = i % 2 ? 1 : -1; at(t + 310, { x: s * 8, tilt: s * 7, turn: s * 0.3, armL: s < 0 ? 115 : 30, armR: s > 0 ? 115 : 30, whirl: 0.6, lift: 2.5 }, 'io'); at(t + 620, { lift: 0, sq: 0.05 }); }
      at(2800, { armL: 155, armR: 155, x: 0, tilt: 0, turn: 0, beam: 0, lift: 2, sq: 0 });
      for (let i = 0; i < 3; i++) { const t = 3000 + i * 500; at(t, { beam: 1.1, sq: -0.06, open: 0.8 }, 'o'); at(t + 300, { beam: 0.35, sq: 0, open: 0.45 }); em(t, 'spark', 'head', 1); }
      at(4500, { beam: 0, armL: 60, armR: 60, lift: 0 }); at(4700, { spin: 0 }); at(6200, { spin: 720, lift: 6, whirl: 2.6, burst: 0.25, armL: 150, armR: 150 }, 'io'); at(6201, { spin: 0 }, 'l'); at(6400, { lift: 0, whirl: 0.5, burst: 0, armL: 40, armR: 40 });
      at(6800, { sq: 0.18, armL: -10, armR: -10 }); at(7050, { sq: -0.12, burst: 1.3, armL: 110, armR: 110, lift: 4, pwr: 0.5, wide: 0.5, open: 0.9 }, 'o'); em(7050, 'spark', 'head', 1); at(7700, { burst: 0, sq: 0, lift: 0, pwr: 0, wide: 0, open: 0.45 });
      at(8200, { armR: 150, armL: 40, beam: 0.7, x: -8, tilt: -5 }); at(8900, { x: 8, tilt: 5, armL: 150, armR: 40 }); at(9600, { x: 0, tilt: 0, beam: 0, armL: 60, armR: 60 });
      at(10000, { pitch: 0.25, sq: 0.1, armL: 30, armR: 30 }); at(10350, { pitch: 0, sq: 0, armR: 125, htilt: 6 }); at(10500, { winkR: 1 }); at(10800, { winkR: 0 }); em(10500, 'heart', 'head', 1); at(10950, { htilt: 0, armL: 0, armR: 0, whirl: 0 }); },
    // Aero-Swift "Tornado Twist": lifts off on her breeze, speed dashes with trails, tornado spin, loop-the-loop, jazzy hover, superhero landing + wink
    aeroswift(at, em) {
      at(800, { fly: 0.9, armL: -25, armR: -25, pitch: -0.15, open: 0.55 }, 'io'); let px = 0;
      [-18, 18, -18, 0].forEach((x, i) => { const t = 1200 + i * 430, d = Math.sign(x - px) || 1; at(t, { x: px, lean: 0 }); at(t + 260, { x, lean: d * 8, turn: d * 0.4, gust: 0.5 }, 'io'); at(t + 430, { lean: 0 }); px = x; });
      at(3000, { turn: 0, gust: 0.2, pitch: 0 }); at(3100, { spin: 0, armL: 60, armR: 60 }); at(5300, { spin: 1080, gust: 1.7, armL: 150, armR: 150, sq: -0.08, open: 0.9 }, 'i'); at(5800, { spin: 1440, gust: 0.4, armL: 40, armR: 40, sq: 0 }, 'o'); at(5801, { spin: 0 }, 'l');
      const HC = 11; for (let s = 0; s <= 24; s++) { const uu = s / 24, e = uu * uu * (3 - 2 * uu), th = e * Math.PI * 2; at(6000 + 1400 * uu, { tilt: e * 360, x: -HC * Math.sin(th), lift: HC * (1 - Math.cos(th)), armL: 160, armR: 160, gust: 0.6 }, 'l'); }
      at(7401, { tilt: 0 }, 'l'); em(7400, 'spark', 'head', 1);
      for (let i = 0; i < 4; i++) { const t = 7700 + i * 600, s = i % 2 ? 1 : -1; at(t + 300, { x: s * 8, tilt: s * 6, armL: s < 0 ? 135 : 30, armR: s > 0 ? 135 : 30, gust: 0.35, open: 0.7 }); }
      at(10200, { fly: 0, sq: 0.22, armR: 155, armL: -15, x: 0, tilt: 0, gust: 0.9 }, 'i'); at(10400, { sq: 0, gust: 0.2 }); at(10500, { winkR: 1 }); at(10800, { winkR: 0 }); em(10500, 'heart', 'head', 1); at(10950, { armL: 0, armR: 0, gust: 0 }); },
    // Phantasm "Cosmic Phase": juggles cosmic orbs, phases out and teleports across the stage, spins inside his glowing chain ring, billows his galaxy cloak, starburst, bow
    phantasm(at, em) {
      for (let i = 0; i < 6; i++) { const t = 150 + i * 340; at(t, { armL: i % 2 ? 145 : 40, armR: i % 2 ? 40 : 145, orb: 0.8, x: Math.sin(i) * 3, tilt: (i % 2 ? 1 : -1) * 4 }, 'io'); }
      let t = 2300, px = 0; at(t, { x: 0, tilt: 0, armL: 60, armR: 60, orb: 0.4 });
      [-18, 18, 0].forEach(x => { at(t + 300, { phase: 1, sq: -0.1, x: px }, 'i'); at(t + 320, { x }, 'l'); at(t + 650, { phase: 0, sq: 0 }, 'o'); em(t + 650, 'spark', 'head', 1); px = x; t += 750; });
      at(4700, { spin: 0, chain: 0 }); at(6400, { spin: 720, chain: 1.5, lift: 6, armL: 100, armR: 100 }, 'io'); at(6401, { spin: 0 }, 'l'); at(6600, { chain: 0.3, lift: 0, armL: 30, armR: 30 });
      at(7000, { cape: 1.3, x: -10, tilt: -10 }); at(7600, { x: 10, tilt: 10 }); at(8200, { x: 0, tilt: 0, cape: 0.3 });
      at(8500, { sq: 0.15, armL: 40, armR: 40 }); at(8800, { sq: -0.1, armL: 165, armR: 165, orb: 1.4, pwr: 0.6, lift: 5 }, 'o'); em(8800, 'spark', 'head', 1); em(9100, 'spark', 'head', 1); at(9800, { orb: 0.5, pwr: 0, lift: 0, sq: 0 });
      at(10100, { pitch: 0.3, armL: 20, armR: 20 }); at(10600, { pitch: 0 }); at(10950, { orb: 0, armL: 0, armR: 0, chain: 0, cape: 0 }); },
    // Magmara "Magma Punch": fire-fist punches that throw fireballs, ground slam with lava cracks + geysers, flame spin, lava stomps, eruption finale, flex + wink
    magmara(at, em) {
      for (let i = 0; i < 4; i++) { const t = 150 + i * 560, sd = i % 2 ? 1 : -1, k = sd > 0 ? 'fbR' : 'fbL', ar = sd > 0 ? 'armR' : 'armL', ot = sd > 0 ? 'armL' : 'armR';
        at(t + 150, { [k]: 0 }, 'l'); at(t + 180, { [ar]: 92, [ot]: 20, lean: sd * 6, turn: sd * 0.35, x: sd * 3, sq: -0.04, open: 0.7, fire: 1 }, 'o'); at(t + 420, { [ar]: 40, lean: 0, sq: 0.03, open: 0.4 }); at(t + 520, { [k]: 1 }, 'l'); at(t + 521, { [k]: 0 }, 'l'); }
      at(2500, { turn: 0, x: 0, armL: 30, armR: 30, fire: 0.6 }); at(2800, { sq: 0.2, armL: -10, armR: -10 }); at(3150, { lift: 16, sq: -0.12, armL: 150, armR: 150, open: 0.8 }, 'o'); at(3400, { lift: 0, sq: 0.3, armL: 70, armR: 70, erupt: 0 }, 'i'); at(3700, { erupt: 1.1, sq: 0.05 }, 'o'); em(3400, 'spark', 'head', 1); at(4100, { erupt: 0.6 }); at(4400, { erupt: 0, sq: 0 });
      at(4500, { spin: 0, fire: 0.6 }); at(6000, { spin: 720, fire: 1.6, armL: 100, armR: 100, lift: 4, open: 0.8 }, 'io'); at(6001, { spin: 0 }, 'l'); at(6200, { lift: 0, fire: 0.6, armL: 30, armR: 30 });
      for (let b = 0; b < 4; b++) { const t = 6300 + b * 450, sd = b % 2 ? 1 : -1; at(t + 200, { lift: 5, tilt: sd * 5, lean: sd * 3, armL: 50, armR: 50, sq: -0.05 }, 'o'); at(t + 420, { lift: 0, tilt: 0, lean: 0, sq: 0.2 }, 'i'); }
      at(8200, { sq: 0, armL: 20, armR: 20 }); at(8800, { armL: 160, armR: 160, erupt: 1.4, pwr: 0.5, fire: 1.4, sq: -0.08, wide: 0.5, open: 0.9 }, 'o'); em(8800, 'spark', 'head', 1); em(9200, 'spark', 'head', 1); at(9600, { erupt: 0, pwr: 0, wide: 0, sq: 0, armL: 60, armR: 60, fire: 0.6 });
      at(9900, { armL: 120, armR: 120, sq: 0.06 }); at(10200, { armR: 130, armL: 20, htilt: 6, sq: 0 }); at(10350, { winkR: 1 }); at(10650, { winkR: 0 }); em(10350, 'heart', 'head', 1); at(10950, { armL: 0, armR: 0, htilt: 0, fire: 0.4 }); },
    // Chrono-Shade "Time Warp": tick-tock robot sways, rewind moonwalk with afterimages, time-freeze poses, giant clock spin, slow-motion jump, bow + wink
    chronoshade(at, em) {
      for (let i = 0; i < 8; i++) { const t = 100 + i * 290, sd = i % 2 ? 1 : -1; at(t, { tilt: sd * 7, htilt: -sd * 5, armL: sd < 0 ? 70 : 20, armR: sd > 0 ? 70 : 20, sq: 0.04 }, 'o'); at(t + 260, { sq: 0 }, 'l'); }
      at(2500, { tilt: 0, htilt: 0, armL: 20, armR: 20, x: 0 }); at(2600, { rewind: 1 }, 'o'); at(3500, { x: -16, lean: 5, turn: 0.4 }, 'l'); at(3600, { x: -16, lean: 0 }); at(4500, { x: 0, turn: -0.3, lean: -4 }, 'l'); at(4600, { rewind: 0, turn: 0, lean: 0 });
      [[4750, { armL: 150, armR: 20, tilt: -8, x: -6 }], [5400, { armL: 20, armR: 150, tilt: 8, x: 6 }], [6050, { armL: 110, armR: 110, tilt: 0, x: 0, lift: 4 }]].forEach(([t, v]) => { at(t, { freeze: 0 }); at(t, v, 'o'); at(t + 500, v, 'l'); at(t + 120, { freeze: 1 }, 'o'); at(t + 500, { freeze: 1 }, 'l'); at(t + 580, { freeze: 0 }); em(t + 120, 'spark', 'head', 1); });
      at(6700, { lift: 0, armL: 60, armR: 60, clock: 0, spin: 0 }); at(7200, { clock: 1.2, rewind: 0.8 }, 'o'); at(8300, { spin: 720, armL: 140, armR: 140 }, 'io'); at(8301, { spin: 0 }, 'l'); at(8500, { clock: 0, rewind: 0, armL: 40, armR: 40 });
      at(8600, { sq: 0.15 }); at(9500, { lift: 14, sq: -0.08, armL: 150, armR: 100, rewind: 0.7, tilt: -6 }, 'l'); at(10200, { lift: 0, sq: 0.12, tilt: 0, rewind: 0 }, 'l'); at(10350, { sq: 0 });
      at(10450, { pitch: 0.25, armR: 30, armL: 30 }); at(10700, { pitch: 0, armR: 130, htilt: 6 }); at(10750, { winkR: 1 }); at(10950, { winkR: 0, htilt: 0, armL: 0, armR: 0 }); em(10750, 'heart', 'head', 1); },
  };
  function heroDance(key) { const RR = window.RiveRig; if (!RR || !HDANCE[key] || RR.STATES['dance@' + key]) return;
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.45]] }, LP = 11000, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    HDANCE[key](at, em);
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ ['dance@' + key]: { loop: LP, k: K, ev } }); }
  // Pearl's own dance, "Tusk Twirl" (narwhal moves): Arctic swim bobs with paddling flippers and horn-glow beats, tusk fencing (horn parries side to side with sparks), breach + corkscrew drill spin,
  // ice-floe hops, northern-lights glow sway, flipper claps, proud horn-up pose + wink (11 s loop). Channels: glow (horn glow), hsw (horn sway), fflap (flipper flap), fclap (flippers forward/clap)
  function nwDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@pearl']) return;
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.5]], swim: [[0, 0.6]], glow: [[0, 0.2]], hsw: [[0, 0]], fflap: [[0, 0]], fclap: [[0, 0]] }, LP = 11000, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    for (let b = 0; b < 4; b++) { const t = 100 + b * 540, d = b % 2 ? 1 : -1;
      at(t + 270, { lift: 5, x: d * 6, tilt: d * 8, turn: d * 0.25, pitch: -0.1, armL: d < 0 ? 95 : 20, armR: d > 0 ? 95 : 20, swim: 1.4, sq: -0.05, htilt: -d * 4, glow: 1, open: 0.7 });
      at(t + 540, { lift: 0.5, pitch: 0.1, sq: 0.07, armL: 35, armR: 35, glow: 0.3, open: 0.45 }); em(t + 270, 'spark', 'horn', 2); if (b % 2) em(t + 540, 'note', 'head', 1); }
    for (let i = 0; i < 6; i++) { const t = 2350 + i * 300, d = i % 2 ? 1 : -1; at(t, { x: d * 5, tilt: d * 11, hsw: d * 1, turn: d * 0.15, fclap: 0.6, lift: 2, sq: -0.03, open: 0.8, glow: 0.8 }, 'o'); at(t + 150, { sq: 0.05, lift: 0, glow: 0.5 }); em(t + 60, 'spark', 'horn', 3); }
    at(4250, { x: 0, tilt: 0, hsw: 0, turn: 0, fclap: 0, lift: 0, pitch: 0.3, sq: 0.28, armL: -15, armR: -15, open: 0.3, glow: 0.6 }, 'i'); at(4300, { spin: 0 }, 'l');
    at(4700, { lift: 19, pitch: -0.35, sq: -0.16, armL: -10, armR: -10, open: 0.95, swim: 1.5, glow: 1.5, curl: 0.5 }, 'o'); em(4650, 'splash', [50, 90], 8);
    at(5500, { spin: 720, lift: 17, pitch: 0.1 }); at(5501, { spin: 0 }, 'l'); em(4900, 'spark', 'horn', 4); em(5200, 'spark', 'horn', 4);
    at(5850, { lift: 0, pitch: 0.12, sq: 0.3, open: 0.5, curl: 0, armL: 50, armR: 50, glow: 0.5 }, 'i'); em(5850, 'splash', [36, 90], 7); em(5850, 'splash', [64, 90], 7);
    at(6050, { sq: -0.06, pitch: 0 }, 'o');
    for (let i = 0; i < 3; i++) { const t = 6250 + i * 400, xx = -10 + i * 10; at(t + 200, { lift: 10, x: xx, sq: -0.1, fflap: 1.2, armL: 60, armR: 60, tilt: (i - 1) * 6, open: 0.85 }, 'o'); at(t + 400, { lift: 0, sq: 0.18, fflap: 0, armL: 30, armR: 30 }, 'i'); em(t + 400, 'drop', [50 + xx, 90], 3); }
    at(7650, { x: 0, tilt: 0, sq: 0 });
    for (let i = 0; i < 2; i++) { const t = 7800 + i * 700; at(t + 350, { tilt: 9, htilt: 7, x: 4, glow: 1.5, turn: 0.2, armL: 70, armR: 10, swim: 1 }); at(t + 700, { tilt: -9, htilt: -7, x: -4, glow: 1.5, turn: -0.2, armL: 10, armR: 70 }); em(t + 350, 'spark', 'horn', 3); em(t + 700, 'spark', 'horn', 3); }
    at(9250, { tilt: 0, htilt: 0, x: 0, turn: 0, glow: 0.5, armL: 30, armR: 30, swim: 0.6 });
    for (let i = 0; i < 3; i++) { const t = 9350 + i * 230; at(t, { fclap: 1, open: 0.95, sq: 0.06, lift: 1 }, 'o'); at(t + 115, { fclap: 0.3, open: 0.4, sq: -0.02, lift: 0 }); em(t, 'note', 'head', 1); }
    at(10100, { fclap: 0, pitch: -0.18, sq: -0.04, armL: 20, armR: 20, glow: 1.2 }, 'io');
    at(10450, { armR: 110, armL: 20, htilt: 6, winkR: 0 }, 'o'); at(10600, { winkR: 1 }); at(10850, { winkR: 0 }); em(10600, 'heart', 'head', 1); em(10500, 'spark', 'horn', 3);
    at(10950, { htilt: 0, armL: 0, armR: 0, sq: 0, pitch: 0, glow: 0.2 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@pearl': { loop: LP, k: K, ev } }); }
  // Finn's own dance, "Splash Dance" (dolphin show moves): wave-swim bobs, dive + breach leap with a flip and a splash, tail-walk backwards across the water, flipper clap with happy clicks, barrel roll, blowhole spouts, bow + wink (11 s loop)
  function fnDance() { const RR = window.RiveRig; if (!RR || RR.STATES['dance@finn']) return;
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.5]], swim: [[0, 0.6]] }, LP = 11000, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    for (let b = 0; b < 4; b++) { const t = 100 + b * 560, d = b % 2 ? 1 : -1;
      at(t + 280, { lift: 6, x: d * 6, tilt: d * 7, turn: d * 0.28, pitch: -0.14, armL: d < 0 ? 110 : 25, armR: d > 0 ? 110 : 25, swim: 1.3, sq: -0.05, htilt: -d * 3 });
      at(t + 560, { lift: 1, pitch: 0.12, sq: 0.06, armL: 55, armR: 55 }); if (b % 2) em(t + 560, 'drop', 'body', 3); }
    at(2500, { lift: 0, x: 0, tilt: 0, turn: 0, htilt: 0, pitch: 0.32, sq: 0.26, armL: -15, armR: -15, swim: 0.8, open: 0.3 }, 'i'); at(2550, { spin: 0 }, 'l');
    at(2950, { lift: 17, pitch: -0.4, sq: -0.16, armL: -20, armR: -20, wide: 0.5, open: 0.9, swim: 1.5, curl: 0.6 }, 'o'); em(2900, 'splash', [50, 90], 8);
    at(3800, { spin: 360, lift: 16, pitch: 0.25 }); at(3801, { spin: 0 }, 'l');
    at(4200, { lift: 0, pitch: 0.15, sq: 0.32, wide: 0, open: 0.5, curl: 0, armL: 60, armR: 60 }, 'i'); em(4200, 'splash', [36, 90], 7); em(4200, 'splash', [64, 90], 7);
    at(4450, { sq: -0.08, pitch: 0 }, 'o'); at(4650, { sq: 0.02, x: 0 });
    for (let i = 0; i < 8; i++) { const t = 4800 + i * 180, d = i % 2 ? 1 : -1; at(t, { lift: 8 + (i % 2) * 1.5, pitch: -0.28, x: -12 + i * 3.4, tilt: d * 3, armL: d > 0 ? 125 : 70, armR: d < 0 ? 125 : 70, swim: 1.6, sq: -0.03, open: 0.75 }, 'l'); if (i % 2) em(t, 'drop', [50 + (-12 + i * 3.4), 90], 3); }
    at(6400, { lift: 2, pitch: 0, x: 12, tilt: 0, armL: 40, armR: 40, swim: 0.7, sq: 0.08 });
    for (let i = 0; i < 5; i++) { const t = 6600 + i * 190; at(t, { armL: 150, armR: 150, x: 12 - i * 2.4, open: 0.95, htilt: (i % 2 ? 1 : -1) * 6, sq: 0.06 }, 'o'); at(t + 95, { armL: 115, armR: 115, open: 0.3, sq: -0.02 }); em(t, 'spark', 'head', 1); }
    at(7650, { armL: 50, armR: 50, x: 0, htilt: 0, open: 0.5, sq: 0, lift: 2 }); at(7700, { spin: 0 }, 'l');
    at(8000, { lift: 9, x: -8, tilt: -10, armL: 20, armR: 20, swim: 1.3 }, 'o'); at(8700, { spin: -360, lift: 9, x: 8, tilt: 10 }); at(8701, { spin: 0 }, 'l'); em(8350, 'bubble', 'body', 2);
    at(8950, { lift: 0, x: 0, tilt: 0, sq: 0.2, swim: 0.6 }, 'i');
    for (let i = 0; i < 3; i++) { const t = 9100 + i * 330; at(t, { puff: 0.7, sq: -0.06, lift: 2, htilt: (i - 1) * 4 }); at(t + 160, { puff: -0.2, sq: 0.12, lift: 0 }, 'o'); em(t + 160, 'drop', 'blow', 5); em(t + 200, 'bubble', 'blow', 1); }
    at(10100, { puff: 0, htilt: 0, pitch: 0.3, sq: 0.06, armL: 20, armR: -10 }, 'io');
    at(10450, { pitch: 0, armR: 125, armL: 25, htilt: 6, winkR: 0 }, 'o'); at(10600, { winkR: 1 }); at(10850, { winkR: 0 }); em(10600, 'heart', 'head', 1);
    at(10950, { htilt: 0, armL: 0, armR: 0, sq: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@finn': { loop: LP, k: K, ev } }); }
  // Marina's own dance, "Mermaid Splash": wave-swim with breaststroke arms and an undulating tail, hair flip, tail curls up behind and flicks splashes, whirlpool twirl with bubbles, seaside sway on her tail, bubble blowing, tail-flick pose + wink.
  // Her idle (idle@marina) swings her tail side to side a few times. Channels: tsw tail swing, tlf tail lift/curl, tun tail undulation, hfl hair flow.
  function mmDance() { const RR = window.RiveRig; if (!RR) return;
    if (!RR.STATES['idle@marina'] && RR.STATES.idle) { const S0 = RR.STATES.idle; RR.add({ 'idle@marina': Object.assign({}, S0, { k: Object.assign({}, S0.k, {
      tsw: [[0, 0], [2600, 0], [3000, 0.9, 'io'], [3500, -0.9, 'io'], [4000, 0.85, 'io'], [4500, -0.8, 'io'], [5000, 0.55, 'io'], [5450, 0, 'io'], [8400, 0]],
      tlf: [[0, 0], [2500, 0], [2950, 0.45, 'io'], [5000, 0.42], [5500, 0, 'io'], [8400, 0]],
      tun: [[0, 0], [2600, 0], [2950, 0.5, 'io'], [5000, 0.5], [5450, 0, 'io'], [8400, 0]] }) }) }); }
    if (RR.STATES['dance@marina']) return;
    const K = { hap: [[0, 0.85]], smile: [[0, 1]], open: [[0, 0.45]], tun: [[0, 0.6]] }, LP = 11000, ev = [];
    const at = (t, v, ez) => { for (const p in v) (K[p] || (K[p] = [[0, 0]])).push([t, v[p], ez || 'io']); }, em = (t, n, w, c) => ev.push([t, 'emit', n, w, c]);
    for (let b = 0; b < 4; b++) { const t = 100 + b * 575, d = b % 2 ? 1 : -1;
      at(t + 290, { lift: 5, x: d * 5, tilt: d * 6, turn: d * 0.22, pitch: -0.1, armL: d < 0 ? 125 : 45, armR: d > 0 ? 125 : 45, tsw: -d * 0.55, tun: 1.3, sq: -0.04, htilt: -d * 3 });
      at(t + 575, { lift: 1.5, pitch: 0.06, sq: 0.05, armL: 70, armR: 70 }); if (b % 2) em(t + 300, 'bubble', 'mouth', 2); }
    at(2450, { lift: 0, x: 0, tilt: 0, turn: 0, htilt: 0, pitch: 0, tsw: 0, tun: 0.5, sq: 0, armL: 40, armR: 40 });
    at(2750, { pitch: 0.38, sq: 0.12, hfl: 1.3, armR: 60, armL: 30, htilt: 5, open: 0.3 }, 'io');
    at(3050, { pitch: -0.28, htilt: -7, hfl: -1.4, lift: 4, sq: -0.08, armR: 165, armL: 40, wide: 0.4, open: 0.8 }, 'o'); em(3050, 'spark', 'head', 2);
    at(3400, { pitch: 0, htilt: 0, hfl: 0, lift: 0, sq: 0.03, armR: 60, armL: 40, wide: 0, open: 0.45 }, 'io');
    at(3650, { tlf: 1.15, tsw: 0, lean: 1.5, pitch: 0.1, armL: 75, armR: 75, sq: 0.06 }, 'io');
    [[3900, 1.3], [4200, -1.3]].forEach(([t, v]) => { at(t, { tsw: v, tlf: 1.1, tilt: -v * 3 }, 'o'); em(t + 30, 'splash', 'tail', 5); em(t + 60, 'drop', 'tail', 2); });
    at(4500, { tsw: 0, tlf: 0.2, lean: 0, pitch: 0, tilt: 0, sq: 0.16, armL: 40, armR: 40 }, 'i'); em(4500, 'splash', [50, 92], 6);
    at(4650, { tlf: 0, sq: -0.05 }); at(4800, { sq: 0 });
    at(4850, { spin: 0 }, 'l'); at(4900, { sq: 0.18, armL: 20, armR: 20 });
    at(5150, { lift: 12, sq: -0.12, armL: 165, armR: 165, tun: 1.6, wide: 0.5, open: 0.85 }, 'o');
    at(6250, { spin: 720, lift: 13 }, 'io'); at(6251, { spin: 0 }, 'l');
    [5200, 5500, 5800, 6100].forEach(t => em(t, 'bubble', 'body', 2));
    at(6550, { lift: 0, sq: 0.3, armL: 50, armR: 50, tun: 0.6, wide: 0, open: 0.45 }, 'i'); em(6550, 'splash', [50, 92], 6);
    at(6700, { sq: -0.08 }); at(6850, { sq: 0 });
    for (let i = 0; i < 4; i++) { const t = 6900 + i * 420, d = i % 2 ? 1 : -1;
      at(t + 210, { tilt: d * 9, x: d * 4, lean: d * 1.2, htilt: d * 4, tsw: -d * 0.8, tlf: 0.35, armL: d < 0 ? 150 : 95, armR: d > 0 ? 150 : 95, sq: 0.04 });
      at(t + 420, { sq: -0.02 }); em(t + 210, 'note', 'head', 1); }
    at(8650, { tilt: 0, x: 0, lean: 0, htilt: 0, tsw: 0, tlf: 0, armL: 40, armR: 40, sq: 0 });
    for (let i = 0; i < 3; i++) { const t = 8750 + i * 330; at(t, { puff: 0.9, sq: -0.05, open: 0.15, htilt: (i - 1) * 4 }); at(t + 170, { puff: -0.1, sq: 0.06, open: 0.5 }, 'o'); em(t + 170, i === 2 ? 'bigbubble' : 'bubble', 'mouth', 2); }
    at(9800, { puff: 0, htilt: 0, sq: 0, open: 0.45 });
    at(10050, { tlf: 0.95, tsw: 0.35, armR: 150, armL: 30, htilt: 6, tilt: 3, winkR: 0, sq: -0.04 }, 'o'); at(10200, { winkR: 1 }); at(10450, { winkR: 0 }); em(10200, 'heart', 'head', 1); em(10100, 'drop', 'tail', 2);
    at(10850, { tlf: 0, tsw: 0, armR: 0, armL: 0, htilt: 0, tilt: 0, sq: 0 });
    for (const p in K) { K[p].sort((a, b) => a[0] - b[0]); if (K[p][K[p].length - 1][0] < LP) K[p].push([LP, K[p][0][1], 'io']); }
    RR.add({ 'dance@marina': { loop: LP, k: K, ev } }); }
  function build(I, root, key, H) {
    const { mk, ellS, toD, parsePath, ellAx, SM, clamp, lerp, r2, D2R, TAU } = H;
    if (key === 'floof') flDance(); if (key === 'unibun') ubDance(); if (key === 'gumdrop') gmDance(); if (key === 'teddy') tdDance(); if (key === 'panko') pkDance(); if (key === 'hoot') htDance(); if (key === 'leo') leDance(); if (key === 'acorn') acDance(); if (key === 'fawn') fwDance(); if (key === 'moss') msDance(); if (key === 'sprout') spDance(); if (key === 'ember') emDance(); if (key === 'drako') drDance(); if (key === 'jinni') jnDance(); if (key === 'hana') hnDance(); if (key === 'boo') gbDance(); if (key === 'pixie') pxDance(); if (key === 'twinkle') twDance(); if (key === 'pina') pnDance(); if (key === 'avo') avDance(); if (key === 'berri') brDance(); if (key === 'lemmy') lmDance(); if (key === 'kiwi') kwDance(); if (key === 'peachy') peDance(); if (key === 'melo') moDance(); if (key === 'pitaya') ptDance(); if (key === 'tutti') tuDance(); if (HERO[key]) heroDance(key); if (key === 'sealy') slDance(); if (key === 'zappi') zpDance(); if (key === 'plip') plDance(); if (key === 'breeze') bzDance(); if (key === 'dusty') duDance(); if (key === 'bubbly') bbDance(); if (key === 'aurora') auDance(); if (key === 'mallow') mlDance(); if (key === 'bao') bzBao(); if (key === 'dunkie') dkDance(); if (key === 'frybo') fyDance(); if (key === 'bunbun') bnDance(); if (key === 'choco') chDance(); if (key === 'scoop') scDance(); if (key === 'boba') boDance(); if (key === 'chefbun') cbDance(); if (key === 'pip') ppDance(); if (key === 'jelli') jlDance(); if (key === 'octo') ocDance(); if (key === 'finn') fnDance(); if (key === 'pearl') nwDance(); if (key === 'puff') pfDance(); if (key === 'shelly') shDance(); if (key === 'marina') mmDance(); I.shadow = mk('ellipse', { fill: '#6a1b9a', opacity: 0.2 }, root);
    const art = mk('g', {}, root); I.fxG = mk('g', {}, root); I.pg = {}; I.E = {};
    load(key).then(txt => {
      if (!I.fxG.isConnected && !root.isConnected) return; const p = '_g' + I.u;
      txt = txt.replace(/id="([^"]+)"/g, (m, id) => 'id="' + id + p + '"').replace(/url\(#([^)]+)\)/g, (m, id) => 'url(#' + id + p + ')');
      const tmp = document.createElementNS('http://www.w3.org/2000/svg', 'svg'); tmp.innerHTML = txt.replace(/^[\s\S]*?<svg[^>]*>/, '').replace(/<\/svg>\s*$/, '');
      while (tmp.firstChild) art.appendChild(tmp.firstChild);
      // Hana: her face + hair sit in a scaled group in the art; bake that transform into the shapes so they can ride on the 3D hood
      if (key === 'hana') { const tg = art.querySelector('g[transform]'); if (tg) { [...tg.children].forEach(e => { if (e.tagName === 'ellipse') { e.setAttribute('cx', 50 + (num(e, 'cx') - 50) * 0.82); e.setAttribute('cy', 42 + (num(e, 'cy') - 48) * 0.82); e.setAttribute('rx', num(e, 'rx') * 0.82); e.setAttribute('ry', num(e, 'ry') * 0.82); }
        else if (e.tagName === 'path') { let i = 0; e.setAttribute('d', (e.getAttribute('d') || '').replace(/-?[\d.]+/g, v => { const o = i % 2 ? 42 + (+v - 48) * 0.82 : 50 + (+v - 50) * 0.82; i++; return String(+o.toFixed(2)); })); } }); tg.removeAttribute('transform'); } }
      if (key === 'lumi') { const bp = [...art.querySelectorAll('path')].find(e => /^M28 68 Q24 88/.test(e.getAttribute('d') || '')); if (bp) bp.setAttribute('d', 'M50 60 C63 60 73 66 73 75 C73 84 63 88.5 50 88.5 C37 88.5 27 84 27 75 C27 66 37 60 50 60Z'); }
      if (key === 'scoop') { const sp = [...art.querySelectorAll('path')].find(e => /^M20 44 A30/.test(e.getAttribute('d') || '')); if (sp) sp.setAttribute('d', (sp.getAttribute('d') || '').replace('A30 30 0 0 1 80 44', 'C20 27.43 33.43 14 50 14 C66.57 14 80 27.43 80 44')); const cn = [...art.querySelectorAll('path')].find(e => /^M31 62 H69/.test(e.getAttribute('d') || '')); if (cn) { cn.setAttribute('d', 'M31 62 L69 62 L52 96 Q50 99 48 96Z'); const df = art.querySelector('defs'); if (df) { const lg = document.createElementNS('http://www.w3.org/2000/svg', 'linearGradient'); lg.setAttribute('id', 'scn' + I.u); lg.setAttribute('gradientUnits', 'userSpaceOnUse'); lg.setAttribute('x1', '31'); lg.setAttribute('x2', '69'); lg.setAttribute('y1', '0'); lg.setAttribute('y2', '0'); [[0, '#b97636'], [0.18, '#e9b06c'], [0.36, '#fde0b0'], [0.62, '#e2a35a'], [1, '#9a5a24']].forEach(([o, c]) => { const st = document.createElementNS('http://www.w3.org/2000/svg', 'stop'); st.setAttribute('offset', o); st.setAttribute('stop-color', c); lg.appendChild(st); }); df.appendChild(lg); cn.setAttribute('fill', 'url(#scn' + I.u + ')'); } } }
      if (key === 'leo') [...art.querySelectorAll('path')].forEach(e => { const d = e.getAttribute('d') || ''; if (/^M46.4 53.6 H/.test(d)) e.setAttribute('d', 'M46.2 53.5 Q50 52.3 53.8 53.5 Q52.5 56.2 50 57.5 Q47.5 56.2 46.2 53.5Z'); else if (/^M89.0 46.0 a10/.test(d)) { I.leoMF = e.getAttribute('fill'); e.remove(); } });
      if (key === 'cakey') { const tp = [...art.querySelectorAll('path')].find(e => /^M22 46 Q22 42 26 42 H74/.test(e.getAttribute('d') || '')); if (tp) tp.setAttribute('d', 'M22 46 Q22 42 26 42 L74 42 Q78 42 78 46 L78 70 L22 70Z'); }
      if (key === 'cuppy') { const wp = [...art.querySelectorAll('path')].find(e => /^M18 54 H82/.test(e.getAttribute('d') || '')); if (wp) wp.setAttribute('d', 'M18 54 L82 54 L76 88 Q50 92 24 88Z'); }
      if (key === 'boba') { const cp = [...art.querySelectorAll('path')].find(e => /^M24 30 H76/.test(e.getAttribute('d') || '')); if (cp) cp.setAttribute('d', 'M24 30 L76 30 L70 88 Q50 93 30 88Z'); }
      if (key === 'zappi') { const tp = [...art.querySelectorAll('path')].find(e => /^M70 82/.test(e.getAttribute('d') || '')); if (tp) tp.setAttribute('d', 'M64 78 Q70 72 76 72 L85 63 L82 73 L91 73 L78 89 L80 80 Q72 82 66 84Z'); }
      if (key === 'dusty') { const sp = [...art.querySelectorAll('path')].find(e => e.getAttribute('fill') === '#fff1d6'); if (sp) { [[17, 40, 3.4], [83, 40, 3.4], [22, 76, 2.2], [78, 76, 2.2]].forEach(([x, y, r]) => { const c = document.createElementNS('http://www.w3.org/2000/svg', 'circle'); c.setAttribute('cx', x); c.setAttribute('cy', y); c.setAttribute('r', r); c.setAttribute('fill', '#fff1d6'); sp.parentNode.insertBefore(c, sp); }); sp.remove(); } }
      if (ROUND[key] && ROUND[key].split) [...art.querySelectorAll('path')].filter(e => !e.closest('defs')).forEach(e => { const parts = (e.getAttribute('d') || '').split(/(?=M)/).filter(x => x.trim()); let prev = e; parts.forEach((d, i) => { if (!i) { e.setAttribute('d', d); return; } const c = e.cloneNode(); c.setAttribute('d', d); prev.parentNode.insertBefore(c, prev.nextSibling); prev = c; }); });
      if (PETS[key]) { const o = {}; PETS[key](o); I.petRoles = new Map(); [...art.querySelectorAll('path,ellipse,circle,rect')].filter(e => !e.closest('defs')).forEach((e, i) => { if (o[i]) I.petRoles.set(e, o[i]); });
        if (o.synth) { const bg = art.querySelector('g[filter]'), main = bg && bg.querySelector('path'); const f = main ? main.getAttribute('fill') : '#e0a060';
          [[36, 74, 15], [64, 74, -15]].forEach(([x, y, rt]) => { const el = document.createElementNS('http://www.w3.org/2000/svg', 'ellipse'); el.setAttribute('cx', x); el.setAttribute('cy', y); el.setAttribute('rx', 5.5); el.setAttribute('ry', 7.5); el.setAttribute('transform', 'rotate(' + rt + ' ' + x + ' ' + y + ')'); el.setAttribute('fill', f); bg.appendChild(el); I.petRoles.set(el, 'arm'); }); } }
      setup(I, root, art, key, H, 0);
    }).catch(e => console.error('RiveGeneric load', key, e));
  }

  function setup(I, root, art, key, H, n) {
    const { mk, ellS, toD, parsePath, clamp, D2R } = H;
    const bodyG = art.querySelector('g[filter]'); let BB = null; try { BB = (bodyG || art).getBBox(); } catch (e) {}
    if (!BB || BB.width < 5) { if (n < 50) setTimeout(() => setup(I, root, art, key, H, n + 1), 100); return; }
    const v2 = (window.CREATURES_V2 || []).find(c => c.name.toLowerCase() === key) || {};
    const eyesEl = [...art.querySelectorAll('[fill^="url(#ey"]')];
    const EY = (v2.eyes && v2.eyes.length ? v2.eyes : eyesEl.map(e => ({ x: num(e, 'cx'), y: num(e, 'cy'), r: num(e, 'r') || 4.6 }))).slice(0, 2);
    const eyeY = EY.length ? EY.reduce((s, e) => s + e.y, 0) / EY.length : 50, ex = EY.length ? EY.reduce((s, e) => s + e.x, 0) / EY.length : 50;
    const area = BB.width * BB.height, G = BB.y + BB.height, TOP = BB.y;
    const hide = new Set(); eyesEl.forEach(e => { hide.add(e); let s = e.nextElementSibling; for (let j = 0; j < 2 && s; j++, s = s.nextElementSibling) if ((s.getAttribute('fill') || '') === '#fff') hide.add(s); });
    const items = [];
    art.querySelectorAll('path,ellipse,circle,rect').forEach(e => {
      const inClip = !!e.closest('clipPath'); if (e.closest('defs') && !inClip) return;
      const tag = e.tagName.toLowerCase(), fill = e.getAttribute('fill') || '', inBody = !!e.closest('g[filter]'), tr = e.getAttribute('transform') || '';
      const rm = tr.match(/rotate\(([-\d.]+)/); let b; try { b = e.getBBox(); } catch (x) { b = { x: 0, y: 0, width: 0, height: 0 }; }
      const it = { e, tag, inBody, rot: rm ? +rm[1] : null, cx: b.x + b.width / 2, cy: b.y + b.height / 2, b, a: b.width * b.height, op: e.getAttribute('opacity'), fill };
      if (tag === 'circle' || tag === 'ellipse') { it.ox = num(e, 'cx'); it.oy = num(e, 'cy'); it.rx = tag === 'circle' ? num(e, 'r') : num(e, 'rx'); it.ry = tag === 'circle' ? it.rx : num(e, 'ry'); it.cx = it.ox; it.cy = it.oy; }
      if (hide.has(e) || e.getAttribute('stroke') === '#6a3a3a') { e.style.display = 'none'; return; }
      const pr = I.petRoles && I.petRoles.get(e);
      if (pr === 'hide') { e.style.display = 'none'; return; }
      if (pr) { it.role = pr === 'head' ? 'body' : pr; it.pet = pr; if (it.ox == null) { it.ox = it.cx; it.oy = it.cy; it.rx = it.b.width / 2; it.ry = it.b.height / 2; } if (/^inner/.test(pr)) { it.role = 'inner'; it.ownerIdx = +pr.slice(5); } if (pr === 'arm') { it.side = (it.ox != null ? it.ox : it.cx) < 50 ? -1 : 1; const a = (it.rot || 0) * D2R; it.hx = it.ox - Math.sin(a) * it.ry; it.hy = it.oy + Math.cos(a) * it.ry; } if (/^ear/.test(pr) || pr === 'tail' || pr === 'swing') it.side = it.cx < 50 ? -1 : 1; }
      else if (inClip) it.role = 'body';
      else if (tag === 'ellipse' && /^#ff8fa3/i.test(fill)) { it.role = 'cheek'; it.side = it.ox < ex ? -1 : 1; }
      else if (!inBody && tag === 'ellipse' && fill.indexOf('#fff') === 0 && it.op) it.role = 'shine';
      else if (inBody && tag === 'ellipse' && it.rot != null && fill.indexOf('#fff') !== 0 && !it.op) { it.role = 'arm'; it.side = it.ox < 50 ? -1 : 1; const a = it.rot * D2R; it.hx = it.ox - Math.sin(a) * it.ry; it.hy = it.oy + Math.cos(a) * it.ry; }
      else if (inBody && tag === 'ellipse' && it.rot == null && it.oy >= G - 14 && it.rx >= 4) it.role = 'foot';
      else if (it.cy < eyeY - 12 && it.a < area * 0.22 && !(!inBody && Math.abs(it.cx - 50) < 4)) { it.role = 'top'; it.side = Math.abs(it.cx - 50) < 4 ? 0 : (it.cx < 50 ? -1 : 1); }
      else if (inBody && it.cy > eyeY - 4 && (it.cx < BB.x + BB.width * 0.2 || it.cx > BB.x + BB.width * 0.8) && it.a < area * 0.12) { it.role = 'side'; it.side = it.cx < 50 ? -1 : 1; }
      else it.role = inBody || inClip ? 'body' : 'face';
      // every shape becomes a path so it can bend with the mesh
      if (tag === 'path') it.segs = parsePath(e.getAttribute('d') || '');
      else if (tag === 'rect') { const x = num(e, 'x'), y = num(e, 'y'), w = num(e, 'width'), h = num(e, 'height'); it.segs = parsePath('M' + x + ' ' + y + ' L' + (x + w) + ' ' + y + ' L' + (x + w) + ' ' + (y + h) + ' L' + x + ' ' + (y + h) + ' Z'); }
      else it.segs = ellS(it.ox, it.oy, it.rx, it.ry, it.rot || 0, it.a > area * 0.12 ? 16 : 8);
      if (tag !== 'path' && !inClip) { const pth = document.createElementNS('http://www.w3.org/2000/svg', 'path'); for (const at of e.attributes) if (!/^(cx|cy|r|rx|ry|x|y|width|height|transform)$/.test(at.name)) pth.setAttribute(at.name, at.value); e.parentNode.replaceChild(pth, e); it.e = pth; }
      else if (tag !== 'path' && inClip) { const pth = document.createElementNS('http://www.w3.org/2000/svg', 'path'); e.parentNode.replaceChild(pth, e); it.e = pth; }
      if (tag === 'path') it.e.removeAttribute('transform');
      items.push(it);
    });
    // Choco: the flat bar art (grid lines, gloss marks, wrapper, foil band) is rebuilt in 3D below, so only the bar rect stays as the head
    if (ROUND[key] && ROUND[key].choco) items.forEach(q => { if (q.inBody && ((q.e.closest('g[mask]') && q.a < area * 0.5) || q.fill === '#f2665a' || q.fill === '#ffd66b')) { q.role = 'xHide'; q.e.style.display = 'none'; } });
    // Forest batch 3: Acorn's flat tail and Moss's flat cap would be picked as the main body shape - hidden before the anchors are found (rebuilt in 3D in the dl kit, I.ffH keeps them)
    if (key === 'acorn' || key === 'moss') items.forEach(q => { const d = q.e.getAttribute('d') || ''; if (q.inBody && /^M62 86|^M70 26|^M8 46 Q8 12/.test(d)) { q.role = 'xHide'; q.e.style.display = 'none'; (I.ffH || (I.ffH = {}))[d.slice(0, 5)] = q; } });
    // Sweet Bakery (Cuppy, Chip, Twisty): flat parts rebuilt in 3D in the bakery block are hidden before the anchors are found (Chip's chips path was being picked as his head, hiding his face)
    if (ROUND[key] && ROUND[key].bk) { const BH = I.bkH = {}; items.forEach(q => { const st = q.e.getAttribute('stroke') || '', f = q.fill || '', h = k => { q.role = 'xHide'; q.e.style.display = 'none'; (BH[k] || (BH[k] = [])).push(q); };
      if (key === 'cuppy') { if (q.inBody && /^url\(#fr/.test(f)) h('fr'); else if (q.inBody && /^url\(#ch/.test(f)) h('ch'); else if (q.inBody && st) h('st'); else if (!q.inBody && q.tag === 'ellipse' && f === '#fff' && q.op) h('shine'); }
      if (key === 'chip' && q.inBody && (f === '#6a3a22' || f === '#c8843e')) h('chip');
      if (key === 'twisty' && (q.inBody ? st || f === '#ffffff' : q.tag === 'ellipse' && f === '#fff' && q.op)) h('rope');
      if (key === 'crois' && q.inBody && q.tag === 'path') { if (st) h('st'); else if (/^url\(#d/.test(f)) h('tip'); else if (/^url\(#g/.test(f) && q.b.width < 30) h('lobe'); }
      if (key === 'maca' && q.inBody && f === '#7cd2ac') h('rf');
      if (key === 'mochi' && q.inBody) { if (f === '#ffe58a' || f === '#f0dde4') h('dot'); else if (/^url\(#st/.test(f)) h('st'); else if (/^url\(#l/.test(f)) h('lf'); else if (f === '#ffc6d2') h('bl'); }
      if (key === 'cakey' && q.inBody && !(q.tag === 'ellipse' && q.rot != null)) { if (/^url\(#t1/.test(f)) h('t1'); else if (/^url\(#t3/.test(f)) h('t3'); else if (f === '#fff6fa' || f === '#ffb0d0' || st || q.tag === 'rect' || f === '#ffd0f0' || f === '#ffd24a' || f === '#ff8a2a') h('x'); }
      if (key === 'sugarplum' && q.inBody) { const d = q.e.getAttribute('d') || ''; if (/^M28 46/.test(d)) h('hair'); else if (q.tag === 'circle' && /^url\(#h/.test(f)) h('bun'); else if (/^url\(#gd/.test(f)) h('crown'); else if (f === '#ff6aa8') h('gem'); else if (q.tag === 'ellipse' && /^url\(#dr/.test(f)) h('col'); }
      if (key === 'puddi' && q.inBody) { if (f === '#eef4ff') h('plate'); else if (/^url\(#cr/.test(f)) h('car'); else if (f === '#fffaf2') h('cr'); else if (/^url\(#ch/.test(f)) h('ch'); else if (st === '#5a8a34') h('st'); } }); }
    // Scoop: the flat waffle lines are redrawn as grooves wrapping round the 3D cone (they turn with him); the cherry, stem and shine ride together on top and bob on a spring
    if (key === 'scoop' && bodyG) { const cn = items.find(q => q.inBody && /^url\(#scn/.test(q.fill));
      items.forEach(q => { if (q.inBody && q.e.getAttribute('stroke') === '#c4844a') { q.role = 'xHide'; q.e.style.display = 'none'; }
        else if (q.cy < 20 && (q.e.getAttribute('stroke') === '#5f9a4a' || /^url\(#e_g/.test(q.fill) || (!q.inBody && q.fill === '#fff'))) q.role = 'cherry'; });
      if (cn) { const mkL = (c, w, o) => { const e = document.createElementNS('http://www.w3.org/2000/svg', 'path'); e.setAttribute('fill', 'none'); e.setAttribute('stroke', c); e.setAttribute('stroke-width', w); e.setAttribute('stroke-linecap', 'round'); e.setAttribute('opacity', o); cn.e.parentNode.insertBefore(e, cn.e.nextSibling); return e; };
        const wf = mkL('#b06f36', 1.25, 1), wh = mkL('#fff0d2', 0.6, 0.7); I.sc = { wf, wh, gr: art.querySelector('#scn' + I.u) }; } }
    // Boba: a round 3D cup; pearls sit on a cylinder inside it (front + back layer) and turn, bounce and swirl; the tea sloshes; the straw swings in the lid; cylinder shading on top
    if (key === 'boba' && bodyG) { const SVN = 'http://www.w3.org/2000/svg', B = I.bb = { P: [] };
      B.cup = items.find(q => q.inBody && /^M24 30/.test(q.e.getAttribute('d') || ''));
      items.forEach(q => { const d = q.e.getAttribute('d') || '';
        if (/^M58 30 L68 2/.test(d)) q.role = 'straw';
        else if (q.inBody && (q.fill === '#c9966a' || q.fill === '#f2d9b4' || /^M27 64/.test(d))) q.role = 'tea';
        else if ((q.inBody && /^url\(#c/.test(q.fill)) || (!q.inBody && /^M30 20/.test(d))) q.role = 'body'; });
      const pr = items.filter(q => q.inBody && q.tag === 'circle' && q.rx < 4.5 && q.oy > 60), hi = items.filter(q => q.inBody && q.tag === 'ellipse' && q.fill === '#fff' && q.oy > 60);
      const gB = document.createElementNS(SVN, 'g'), gF = document.createElementNS(SVN, 'g'); B.gB = gB; B.gF = gF;
      if (pr.length) { const par = pr[0].e.parentNode; par.insertBefore(gB, pr[0].e); par.insertBefore(gF, pr[0].e); }
      pr.forEach((q, i) => { const h = hi.find(e => Math.hypot(e.ox - q.ox, e.oy - q.oy) < 2.2), Ri = Math.max(4, 26 - (q.oy - 30) * 6 / 58 - q.rx - 1), th = Math.asin(clamp((q.ox - 50) / Ri, -1, 1)), hs = Math.abs(Math.sin(i * 91.7 + 3.1) * 43758.5) % 1;
        q.role = 'bnop'; if (h) h.role = 'bnop';
        const add = (el, hel, t, s) => { gF.appendChild(el); if (hel) gF.appendChild(hel); B.P.push({ e: el, h: hel, th: t, y0: q.oy, r: q.rx, op: +(q.op || 1), hs: s, ph: i * 1.7 + s * 4, fr: true }); };
        add(q.e, h && h.e, th, hs); add(q.e.cloneNode(), h ? h.e.cloneNode() : null, Math.PI - th + (hs - 0.5) * 0.6, (hs * 7.31) % 1); });
      const lid = items.find(q => q.inBody && q.tag === 'path' && /^url\(#c/.test(q.fill)), cd = mk('defs', {}, art);
      cd.innerHTML = '<linearGradient id="bbs' + I.u + '" gradientUnits="userSpaceOnUse" x1="24" y1="0" x2="76" y2="0"><stop offset="0" stop-color="#7a4a26" stop-opacity="0.4"/><stop offset="0.13" stop-color="#b98455" stop-opacity="0.14"/><stop offset="0.28" stop-color="#ffffff" stop-opacity="0.36"/><stop offset="0.42" stop-color="#ffffff" stop-opacity="0"/><stop offset="0.72" stop-color="#7a4a26" stop-opacity="0.06"/><stop offset="1" stop-color="#6a3e1e" stop-opacity="0.46"/></linearGradient>';
      B.gr = cd.firstChild; B.sh = document.createElementNS(SVN, 'path'); B.sh.setAttribute('fill', 'url(#bbs' + I.u + ')'); if (lid) lid.e.parentNode.insertBefore(B.sh, lid.e);
      const st = items.filter(q => q.role === 'straw'); B.sp = document.createElementNS(SVN, 'path'); B.sp.setAttribute('fill', '#3e2418'); B.sp.setAttribute('opacity', '0'); if (st.length) st[st.length - 1].e.parentNode.insertBefore(B.sp, st[st.length - 1].e.nextSibling); }
    // Chef Bun: no whisk in his paw; the bow tie rides on the front of his round bun and turns with it
    // Chef Bun: the flat hat art is rebuilt as a 3D toque (round band + puffy lobes) that turns with him
    if (key === 'chefbun' && bodyG) { const hq = items.filter(q => /^url\(#hat/.test(q.fill) || (q.fill === 'none' && q.e.getAttribute('stroke') === '#e0e0ee')), hf0 = hq.find(q => /^url/.test(q.fill));
      if (hf0) { let T0base; const hf = hf0.fill, u = I.u, g = mk('g', {}, art); hq[0].e.parentNode.insertBefore(g, hq[0].e); hq.forEach(q => { q.role = 'bnop'; q.e.style.display = 'none'; });
        const cd = mk('defs', {}, art); cd.innerHTML = '<linearGradient id="chb' + u + '" gradientUnits="userSpaceOnUse" x1="30" y1="0" x2="70" y2="0"><stop offset="0" stop-color="#a8a8c8" stop-opacity="0.3"/><stop offset="0.2" stop-color="#d8d8e8" stop-opacity="0.06"/><stop offset="0.33" stop-color="#ffffff" stop-opacity="0.6"/><stop offset="0.5" stop-color="#ffffff" stop-opacity="0"/><stop offset="0.82" stop-color="#b8b8d0" stop-opacity="0.08"/><stop offset="1" stop-color="#9090b4" stop-opacity="0.34"/></linearGradient>';
        const band = mk('path', { fill: hf, stroke: '#e0e0ee', 'stroke-width': 0.6 }, g), bsh = mk('path', { fill: 'url(#chb' + u + ')' }, g), pl = mk('path', { fill: 'none', stroke: '#d4d4e6', 'stroke-width': 0.8, 'stroke-linecap': 'round' }, g), lg = mk('g', {}, g);
        const LB = [[50, 13, -1, 13], [33, 21, -1, 10.5], [67, 21, -1, 10.5], [42, 15, -8, 11], [58, 15, -8, 11], [42, 21, 8, 10], [58, 21, 8, 10]]; T0base = mk('path', { fill: hf }, lg);
        I.hat = { band, bsh, pl, gr: cd.firstChild, lg, base: T0base, L: LB.map(l => ({ l, e: mk('path', { fill: hf, stroke: '#ececf6', 'stroke-width': 0.3 }, lg) })) }; } }
    if (key === 'chefbun') items.forEach(q => { const sk = q.e.getAttribute('stroke'); if (sk === '#c8a070' || sk === '#aab8d0') { q.role = 'bnop'; q.e.style.display = 'none'; } else if (q.fill === '#ff5c6a') q.role = 'bow'; });
    // Berri: the flat seeds, calyx leaves and stem are rebuilt in 3D below (the seeds path was being picked as his head, hiding his face)
    if (ROUND[key] && ROUND[key].berri) items.forEach(q => { if ((q.inBody && q.fill === '#ffe58a') || /^url\(#l/.test(q.fill) || q.e.getAttribute('stroke') === '#4a8a34') { q.role = 'bnop'; q.e.style.display = 'none'; } });
    // Lemmy: the flat pores, stem and leaf are rebuilt in 3D below (the pore dots path would be picked as his head)
    if (ROUND[key] && ROUND[key].lemmy) items.forEach(q => { if ((q.inBody && (q.fill === '#fff6b0' || q.fill === '#7a9a3a')) || /^url\(#l/.test(q.fill) || q.e.getAttribute('stroke') === '#3f8a2a') { q.role = 'bnop'; q.e.style.display = 'none'; } });
    // Kiwi: the flat fuzz dots (would be picked as his head), stem and belly slice are rebuilt in 3D below
    if (ROUND[key] && ROUND[key].kiwi) items.forEach(q => { if (q.inBody && (q.fill === '#d8b48a' || q.fill === '#6a4a2a' || q.fill === '#f6ffe4' || q.fill === '#fffbe2' || q.fill === '#2a1a30' || /^url\(#s_/.test(q.fill))) { q.role = 'bnop'; q.e.style.display = 'none'; } });
    // Peachy: the flat crease, stem and leaf are rebuilt in 3D below
    if (ROUND[key] && ROUND[key].peachy) items.forEach(q => { const s = q.e.getAttribute('stroke'); if ((q.inBody && q.fill === '#8a5a3a') || /^url\(#l_/.test(q.fill) || s === '#3f8a2a' || s === '#e2735e') { q.role = 'bnop'; q.e.style.display = 'none'; } });
    // Melo: the flat white rind, flesh, seeds (would be picked as his head) and stripes are rebuilt in 3D below - the rind outline stays as the head (3D slab)
    if (ROUND[key] && ROUND[key].melo) items.forEach(q => { if (q.inBody && (q.fill === '#f6ffe8' || q.fill === '#3a2340' || /^url\(#g_/.test(q.fill) || q.e.getAttribute('stroke') === '#2f7a2a')) { q.role = 'bnop'; q.e.style.display = 'none'; } });
    // Pitaya: the flat scale flaps and crown spikes (the flaps path would be picked as his head), leaf wings, wing veins and sparkles are rebuilt in 3D below
    if (ROUND[key] && ROUND[key].pitaya) items.forEach(q => { if (/^url\(#(fl|l)_/.test(q.fill) || q.e.getAttribute('stroke') === '#3f8a2a' || (!q.inBody && q.fill === '#fff6b0')) { q.role = 'bnop'; q.e.style.display = 'none'; } });
    // Tutti: the flat wings, fruit crown, basket fruits and wicker basket are rebuilt in 3D below - only her round head and paws stay
    if (ROUND[key] && ROUND[key].tutti) items.forEach(q => { if (q.inBody && q.role !== 'arm' && !(q.tag === 'circle' && q.rx === 22)) { q.role = 'bnop'; q.e.style.display = 'none'; } });
    // Pina: the flat lattice, chevrons and leaves are rebuilt in 3D below (pineapple body, lattice + spikes wrap round it, leafy crown)
    if (ROUND[key] && ROUND[key].pina) items.forEach(q => { const sk = q.e.getAttribute('stroke'); if (sk === '#d48e14' || sk === '#b77810' || /^url\(#l/.test(q.fill)) { q.role = 'bnop'; q.e.style.display = 'none'; } });
    items.filter(q => q.role === 'arm').forEach(a => items.forEach(q => { if ((q.role === 'body' || q.role === 'foot') && q.tag === 'circle' && Math.hypot(q.ox - a.hx, q.oy - a.hy) < 7) { q.role = 'hand'; q.owner = a; q.side = a.side; } }));
    // Dusty: wings hinge on her back and flap in 3D, their spots ride on them; the fluff tuft sits on the front of her round body
    if (ROUND[key] && ROUND[key].wings) { const wg = items.filter(q => q.inBody && /^url\(#w_g/.test(q.fill)); wg.forEach(q => { q.role = 'wing'; q.side = q.cx < 50 ? -1 : 1; q.hX = 50 + q.side * 14; q.sp = []; });
      items.forEach(q => { if (q.inBody && q.fill === '#fff1d6') { q.side = q.cx < 50 ? -1 : 1; q.owner = wg.find(w => w.side === q.side); if (q.owner) { q.role = 'wspot'; q.owner.sp.push(q); } } else if (q.inBody && q.fill === '#ffffff' && !q.op && q.cy < 40) q.role = 'tuft'; else if (q.inBody && q.fill === '#ffffff' && q.op) q.role = 'belly'; }); I.wings = wg; I.wbg = bodyG; }
    // Jinni: the flat lamp, wisp tail, turban (folds, jewel, feather), ears and earrings are rebuilt in 3D (dl kit + I.gn); the vest, its trim and the sash ride on his round chest
    if (key === 'jinni') items.forEach(q => { const st = q.e.getAttribute('stroke'), f = q.fill || '', au = /^url\(#au_/.test(f);
      if (/^url\(#(wp|tb|rb)_/.test(f) || st === '#e0a426' || st === '#8858d4' || f === '#f4ecff' || (au && (q.cy > 74 || q.cy < 30 || !q.inBody)) || (q.inBody && /^url\(#g_/.test(f) && q.tag === 'path' && Math.abs(q.cx - 50) > 18 && q.cy < 40)) { q.role = 'bnop'; q.e.style.display = 'none'; }
      else if (q.inBody && (/^url\(#vs_/.test(f) || st === '#ffcf4a' || au)) { q.role = 'bsurf'; q.bs = { cx: 50, cy: 59.5, rx: 13, ry: 11.5, rz: 11 }; } });
    if (key === 'jinni') { const v0 = items.find(q => q.role === 'bsurf' && /^url\(#vs_/.test(q.fill)), s0 = items.find(q => q.role === 'bsurf' && /^url\(#au_/.test(q.fill));
      if (v0 && s0) [[v0, 'M38.2 52 Q50 47.6 61.8 52 Q64.6 60 62 67 Q50 71.5 38 67 Q35.4 60 38.2 52Z'], [s0, 'M37.6 65 Q50 69.4 62.4 65 L61.6 68.6 Q50 72.6 38.4 68.6Z']].forEach(([o, d]) => { const e = o.e.cloneNode(); e.setAttribute('d', d); v0.e.parentNode.insertBefore(e, v0.e); items.push(Object.assign({}, o, { e, segs: parsePath(d), bs: Object.assign({}, o.bs, { zs: -1 }) })); }); }
    const anchors = items.filter(q => q.role === 'body' && q.inBody && q.fill !== 'none' && q.a > area * 0.14).map(q => ({ q, cx: q.cx, cy: q.cy, hx: q.b.width / 2, hy: q.b.height / 2, a: q.a }));
    const dn = (x, y) => anchors.reduce((m, A) => Math.min(m, Math.hypot((x - A.cx) / A.hx, (y - A.cy) / A.hy)), 9);
    const petHead = items.find(q => q.pet === 'head'); if (petHead && !anchors.some(A => A.q === petHead)) anchors.push({ q: petHead, cx: petHead.cx, cy: petHead.cy, hx: petHead.b.width / 2, hy: petHead.b.height / 2, a: petHead.a });
    const headA = key === 'pip' || key === 'hana' || key === 'floof' || key === 'hoot' || key === 'sprout' ? anchors.slice().sort((a, b) => b.a - a.a)[0] : (ROUND[key] && ROUND[key].donut && anchors.find(A => A.q.tag === 'circle')) || petHead ? (ROUND[key] && ROUND[key].donut && anchors.find(A => A.q.tag === 'circle')) || anchors.find(A => A.q === petHead) : anchors.filter(A => Math.hypot((ex - A.cx) / A.hx, (eyeY - A.cy) / A.hy) < 1).sort((a, b) => a.a - b.a)[0] || anchors.slice().sort((a, b) => b.a - a.a)[0];
    const main = anchors.slice().sort((a, b) => b.a - a.a)[0];
    if (headA) { headA.q.role = 'head'; const hdS = headA.q.e.getAttribute('d') || JSON.stringify(headA.q.segs); items.forEach(q => { if (q.e.closest('clipPath') && q.tag === 'path' && JSON.stringify(q.segs) === JSON.stringify(headA.q.segs)) q.role = 'headDup'; }); }
    const inHead = (x, y) => headA && Math.hypot((x - headA.cx) / headA.hx, (y - headA.cy) / headA.hy) < 1.04;
    items.forEach(q => { if (q.role === 'body' && q.inBody && !anchors.some(A => A.q === q) && q.a >= 1) { const b = q.b; if ([[b.x, b.y], [b.x + b.width, b.y], [b.x, b.y + b.height], [b.x + b.width, b.y + b.height]].every(([x, y]) => inHead(x, y))) q.role = 'patch'; }
      if (q.role === 'face' && !inHead(q.cx, q.cy) && !q.pet) q.role = 'deco'; if (q.role === 'shine' && !inHead(q.cx, q.cy)) q.role = 'body'; });
    // Aurora: belly, stars, spout and gloss ride on the 3D whale body; the flat tail art is replaced by the 3D tail
    if (ROUND[key] && ROUND[key].whale && !ROUND[key].dolph && headA) { let ti = 0; items.forEach(q => { const d = q.e.getAttribute('d') || '', st = q.e.getAttribute('stroke') || '';
      if (q.inBody && /^M70 42/.test(d)) { q.role = 'whHide'; q.e.style.display = 'none'; }
      else if (q.inBody && q.role !== 'arm' && q !== headA.q && (q.fill === '#f4f0ff' || st === '#d8d0f6' || q.fill === '#ffffff')) { q.role = 'wsurf'; if (q.fill === '#ffffff') { q.tw = 1; q.ti = ti++; } }
      else if (!q.inBody && q.fill === '#fff6b0') q.role = 'wspark';
      else if (!q.inBody && st === '#d6f4ff') q.role = 'wspout';
      else if (!q.inBody && q.tag === 'ellipse' && q.fill.indexOf('#fff') === 0) q.role = 'wshine'; }); }
    // Finn: a 3D baby dolphin. The flat tail and dorsal fin art are rebuilt in 3D (tail + flukes on the body, fin on his back); belly and snout are rebuilt on the round body so they turn with him
    if (ROUND[key] && ROUND[key].dolph && headA) { I.fnR = {}; items.forEach(q => { const d = q.e.getAttribute('d') || '';
      // Pearl (narwhal): flat tail, horn, grooves, glow, stars and spots are rebuilt in 3D; the belly is rebuilt on the round underside
      if (ROUND[key].narw) { if (q.inBody && /^M24 76/.test(d)) { q.role = 'bnop'; I.fnR.bel = q; return; } if ((q.inBody && (/^M78 62/.test(d) || /^M46 34/.test(d) || /^M47 28/.test(d) || q.fill === '#8ab4ee' || (q.tag === 'circle' && q.fill === '#fff6c8'))) || (!q.inBody && q.fill === '#fff6c8')) { q.role = 'bnop'; q.e.style.display = 'none'; return; } }
      if (ROUND[key].seal && q.inBody && (/^M72 80/.test(d) || (q.role === 'side' && q.cx > 70))) { q.role = 'bnop'; q.e.style.display = 'none'; }
      else if (ROUND[key].seal && q.inBody && q.tag === 'ellipse' && (q.role === 'patch' || /^url\(#m/.test(q.fill)) && Math.abs(q.oy - 64) < 1) { q.role = 'bnop'; (I.fnR.mz || (I.fnR.mz = [])).push(q); }
      else if (ROUND[key].seal && !q.inBody && (q.role === 'face' || q.role === 'shine') && q.cx > 29 && q.cx < 71 && q.cy > 58 && q.cy < 70) q.role = 'smz';
      else if (q.inBody && (/^M74 82/.test(d) || /^M44 28/.test(d))) { q.role = 'bnop'; q.e.style.display = 'none'; }
      else if (q.inBody && q.tag === 'ellipse' && q.ox === 50 && q.oy === 88) { q.role = 'bnop'; I.fnR.bel = q; }
      else if (q.inBody && q.tag === 'ellipse' && q.ox === 50 && q.oy === 62) { q.role = 'bnop'; I.fnR.sn = q; }
      else if (!q.inBody && q.tag === 'circle' && q.ox === 50 && q.oy === 35) q.role = 'fnBlow';
      else if (!q.inBody && q.tag === 'ellipse' && q.fill.indexOf('#fff') === 0) q.role = 'wshine'; }); }
    // Bao: steam marks removed; the flat top knot and pleats are rebuilt in 3D (round dough knot with twisted folds, pleats fanning all the way round the top)
    if (ROUND[key] && ROUND[key].bun && bodyG) { items.forEach(q => { const d = q.e.getAttribute('d') || '', st = q.e.getAttribute('stroke') || (q.e.closest('g[stroke]') ? q.e.closest('g[stroke]').getAttribute('stroke') : '');
        if (st === '#e6d6c4' || st === '#e2cfb6' || /^M43 31/.test(d) || /^M46 27/.test(d) || q.e.getAttribute('data-art')) { q.role = 'xHide'; q.e.style.display = 'none'; } });
      const xb = mk('defs', {}, art), ub = I.u; xb.innerHTML = '<radialGradient id="bkn' + ub + '" gradientUnits="userSpaceOnUse" cx="47" cy="23" r="9"><stop offset="0" stop-color="#ffffff"/><stop offset="0.55" stop-color="#fff4e6"/><stop offset="1" stop-color="#dcc29f"/></radialGradient>';
      const pl = Array.from({ length: 16 }, (_, k) => ({ a: k / 16 * Math.PI * 2, el: mk('path', { stroke: '#e2cfb6', 'stroke-width': 1.4, fill: 'none', 'stroke-linecap': 'round' }, bodyG) }));
      const kSh = mk('ellipse', { fill: '#cdb393', opacity: 0.45 }, bodyG), kn = mk('path', { fill: 'url(#bkn' + ub + ')' }, bodyG);
      const cr = [0, 1, 2].map(k => ({ a: k / 3 * Math.PI * 2, el: mk('path', { stroke: '#d8c2a6', 'stroke-width': 1, fill: 'none', 'stroke-linecap': 'round' }, bodyG) }));
      I.bun = { pl, kSh, kn, cr, gr: xb.querySelector('#bkn' + ub), C: [50, 26, 0], rx: 7, ry: 5.6 }; }
    // Bunbun: a 3D burger stack (round buns, bumpy patty, melty cheese, tomato, pickles, ruffled lettuce) that turns as one and jiggles layer by layer
    if (ROUND[key] && ROUND[key].burger && headA && bodyG) { const hq = headA.q, par = hq.e.parentNode, ub = I.u, NS0 = 'http://www.w3.org/2000/svg';
      items.forEach(q => { if (q.inBody && q.role === 'body') { q.role = 'xHide'; q.e.style.display = 'none'; } else if (!q.inBody && q.role === 'top') q.role = 'face'; });
      const lg = (id, st) => '<linearGradient id="' + id + ub + '" x1="0" y1="0" x2="1" y2="0">' + st.map(([o, c]) => '<stop offset="' + o + '" stop-color="' + c + '"/>').join('') + '</linearGradient>';
      mk('defs', {}, art).innerHTML = lg('bbb', [[0, '#a9641f'], [0.2, '#e8984a'], [0.4, '#ffd49a'], [0.72, '#e8984a'], [1, '#a05c1c']]) + lg('bpt', [[0, '#3f1d0e'], [0.22, '#7e4428'], [0.4, '#a8673f'], [0.72, '#6e381f'], [1, '#381a0c']])
        + lg('bch', [[0, '#d99a10'], [0.38, '#ffe476'], [0.75, '#ffcc2e'], [1, '#cf900c']]) + lg('btm', [[0, '#a81e14'], [0.38, '#ff7a64'], [0.72, '#e8402e'], [1, '#9c1a12']]) + lg('blt', [[0, '#3f8f38'], [0.38, '#a6ea94'], [0.72, '#7fd06f'], [1, '#3d8a36']]);
      const P0 = a => { const e = document.createElementNS(NS0, 'path'); for (const k in a) e.setAttribute(k, a[k]); par.insertBefore(e, hq.e); return e; };
      const bot = P0({ fill: 'url(#bbb' + ub + ')' }), pat = P0({ fill: 'url(#bpt' + ub + ')' }), tom = P0({ fill: 'url(#btm' + ub + ')' }), tomL = P0({ fill: 'none', stroke: '#ffa392', 'stroke-width': 0.5, 'stroke-linecap': 'round', opacity: 0.55 });
      const che = P0({ fill: 'url(#bch' + ub + ')', stroke: '#e0a414', 'stroke-width': 0.5, 'stroke-linejoin': 'round' });
      const pk = [0.4, -1.0, 1.55, 2.6, -2.2].map(a => ({ a, el: P0({ fill: '#93c652', stroke: '#557f26', 'stroke-width': 0.6 }), rg: P0({ fill: 'none', stroke: '#c9e98f', 'stroke-width': 0.7 }) }));
      const let_ = P0({ fill: 'url(#blt' + ub + ')', stroke: '#4f9e48', 'stroke-width': 0.8, 'stroke-linejoin': 'round' }), letV = P0({ fill: 'none', stroke: '#c4f2b4', 'stroke-width': 0.55, 'stroke-linecap': 'round', opacity: 0.85 });
      const rT = y => y >= 48.8 ? 36 : 36 * Math.pow(Math.max(0, 1 - Math.pow(Math.max(0, 50 - y) / 36, 2.4)), 1 / 2.4);
      const TOPP = [14.2, 14.6, 15.2, 16, 17, 18.3, 19.8, 21.6, 23.7, 26, 28.6, 31.5, 34.7, 38.2, 42, 45.5, 48.8].map(y => [y, rT(y)]).concat([[50.2, 35.2], [51, 33.4]]);
      I.bg = { bot, pat, tom, tomL, che, pk, let: let_, letV, rT, TOP: TOPP, BOT: [[69.6, 34.6], [70.6, 36], [73, 36.6], [77, 35.6], [80, 33], [81.8, 28], [82.4, 20], [82.6, 10]], PAT: [[58.6, 35], [59.6, 36.6], [61, 37.2], [68.6, 37.2], [70, 36.4], [70.8, 35]], sx: { p: 0, v: 0 }, sy: { p: 0, v: 0 } }; }
    // Choco: a chunky 3D chocolate bar (rounded slab with bevelled edges and pillowy segments), the bite cut through it, wrapper sleeve and foil band wrapped round the bottom
    if (ROUND[key] && ROUND[key].choco && headA && bodyG) { const hq = headA.q, ub = I.u, Dh = 10, mEl = art.querySelector('mask'), NS0 = 'http://www.w3.org/2000/svg';
      items.forEach(q => { if (!q.inBody && q.role === 'top') q.role = 'face'; });
      const rg = (id, st) => '<radialGradient id="' + id + ub + '" cx="35%" cy="25%" r="85%">' + st.map(([o, c]) => '<stop offset="' + o + '" stop-color="' + c + '"/>').join('') + '</radialGradient>';
      mk('defs', {}, art).innerHTML = rg('cks', [[0, '#7e4328'], [0.6, '#552a16'], [1, '#3a1b0c']]) + rg('ckm', [[0, '#a5623e'], [0.6, '#7a4127'], [1, '#5a2c18']])
        + '<linearGradient id="ckt' + ub + '" x1="0" y1="0" x2="1" y2="1"><stop offset="0" stop-color="#c88a64"/><stop offset="0.45" stop-color="#9c5c3b"/><stop offset="1" stop-color="#743d23"/></linearGradient>'
        + rg('ckw', [[0, '#ff9a8c'], [0.55, '#f2665a'], [1, '#c8463a']]) + rg('ckx', [[0, '#d65448'], [0.6, '#a8352b'], [1, '#7c2219']]) + rg('ckb', [[0, '#fff3b8'], [0.55, '#ffd66b'], [1, '#e0a83a']]) + rg('cky', [[0, '#e8b444'], [1, '#a8781a']]) + rg('ckp', [[0, '#e0a47a'], [0.3, '#ad6a43'], [0.7, '#76401f'], [1, '#4a2412']]) + rg('ckd', [[0, '#b06c46'], [0.6, '#7e4328'], [1, '#5a2c18']]);
      const F0 = hq.e.getAttribute('fill'); hq.e.setAttribute('fill', 'url(#cks' + ub + ')'); let last = hq.e;
      // paws: round mitts with a strong top-left light, dark rim and a soft gloss so they read as 3D balls
      items.forEach(q => { if (q.role === 'arm') { q.e.setAttribute('fill', 'url(#ckp' + ub + ')'); q.gl = mk('path', { fill: '#fff', opacity: 0 }, bodyG); q.rim = mk('path', { fill: 'none', stroke: '#3a1b0c', 'stroke-width': 0.6, opacity: 0 }, bodyG); }
        if (q.role === 'foot') { q.e.setAttribute('fill', 'url(#ckp' + ub + ')'); const pr = q.e.parentNode, nx = q.e.nextSibling; q.rim = mk('path', { fill: 'none', stroke: '#3a1b0c', 'stroke-width': 0.6, opacity: 0 }, pr); q.gl = mk('path', { fill: '#fff', opacity: 0 }, pr); pr.insertBefore(q.rim, nx); pr.insertBefore(q.gl, nx); } });
      const add = (a, par, before) => { const e = document.createElementNS(NS0, 'path'); for (const k in a) e.setAttribute(k, a[k]); if (before) par.insertBefore(e, before); else { last.parentNode.insertBefore(e, last.nextSibling); last = e; } return e; };
      const bev = add({ fill: 'url(#ckm' + ub + ')' }), fp = add({ fill: F0 }), tiles = [];
      [[24, 40], [40, 60], [60, 76]].forEach((cx, ci) => [[14, 30], [30, 48], [48, 66], [66, 82]].forEach((ry, ri) => tiles.push({ x0: cx[0] + (ci ? 1 : 0.6), x1: cx[1] - (ci < 2 ? 1 : 0.6), y0: ry[0] + (ri ? 1 : 0.6), y1: ry[1] - (ri < 3 ? 1 : 0.6), ci, ri })));
      tiles.forEach(t => { t.sh = add({ fill: '#3a1b0c', opacity: 0 }); }); tiles.forEach(t => { t.tp = add({ fill: 'url(#ckt' + ub + ')', opacity: 0 }); t.hl = add({ fill: '#ffffff', opacity: 0 }); });
      const wq = items.find(q => q.fill === '#f2665a'), wb = wq ? wq.e : null, par = wb ? wb.parentNode : bodyG, A = a => add(a, par, wb);
      const ws = A({ fill: 'url(#ckx' + ub + ')' }), wm = A({ fill: 'url(#ckw' + ub + ')', opacity: 0.6 }), wf = A({ fill: 'url(#ckw' + ub + ')' }), bs = A({ fill: 'url(#cky' + ub + ')' }), bf = A({ fill: 'url(#ckb' + ub + ')' }), bl = A({ fill: 'none', stroke: '#fffbe0', 'stroke-width': 0.7, 'stroke-linecap': 'round', opacity: 0.75 });
      const dr = [[28, 8], [38.5, 4.5], [50, 11], [62, 5.5], [72, 8.5]].map(([x, L], k) => ({ x, L, k, el: A({ fill: 'url(#ckd' + ub + ')', opacity: 0 }) })), mt = A({ fill: 'url(#ckd' + ub + ')', opacity: 0 });
      const pud = mk('ellipse', { fill: '#6b351d', opacity: 0 }, root); root.insertBefore(pud, art);
      let bites = []; if (mEl) { mEl.setAttribute('maskUnits', 'userSpaceOnUse'); mEl.setAttribute('x', -100); mEl.setAttribute('y', -100); mEl.setAttribute('width', 300); mEl.setAttribute('height', 300);
        const rc = mEl.querySelector('rect'); if (rc) { rc.setAttribute('x', -100); rc.setAttribute('y', -100); rc.setAttribute('width', 300); rc.setAttribute('height', 300); }
        bites = [...mEl.querySelectorAll('circle')].map(c => { const p = document.createElementNS(NS0, 'path'); p.setAttribute('fill', '#000'); c.parentNode.replaceChild(p, c); return { x: num(c, 'cx'), y: num(c, 'cy'), r: num(c, 'r'), el: p }; }); }
      // the bar body is a stack of rounded slices whose outline already has the bite taken out, so the bite reads as a real 3D notch with its inner wall from any angle
      const mgp = hq.e.closest('g[mask]') || hq.e.parentNode, sG = document.createElementNS(NS0, 'g'); mgp.parentNode.insertBefore(sG, mgp); hq.e.setAttribute('fill-opacity', '0');
      const NSL = 13, bvl = 4, sdf = (x, y, ins) => { const hw = 30 - ins, hh = 38 - ins, r = Math.max(0.3, 9 - ins), qx = Math.abs(x - 50) - (hw - r), qy = Math.abs(y - 48) - (hh - r); return Math.hypot(Math.max(qx, 0), Math.max(qy, 0)) + Math.min(Math.max(qx, qy), 0) - r; };
      const outl = ins => { const o = []; for (let k = 0; k < 180; k++) { const a = k / 180 * Math.PI * 2, ux = Math.cos(a), uy = Math.sin(a); let lo = 0, hi = 60; for (let it = 0; it < 22; it++) { const m = (lo + hi) / 2; if (sdf(50 + ux * m, 48 + uy * m, ins) < 0) lo = m; else hi = m; } let t = lo;
        bites.forEach(b => { const r = b.r + ins * 0.5, fx = 50 - b.x, fy = 48 - b.y, B = fx * ux + fy * uy, D = B * B - (fx * fx + fy * fy - r * r); if (D > 0) { const t0 = -B - Math.sqrt(D); if (t0 > 0 && t0 < t) t = t0; } }); o.push([50 + ux * t, 48 + uy * t]); } return o; };
      const sl = Array.from({ length: NSL }, (_, k) => { const z = -Dh + 2 * Dh * k / (NSL - 1), t = clamp((Math.abs(z) - (Dh - bvl)) / bvl, 0, 1), ins = bvl * (1 - Math.sqrt(1 - t * t)); const el = document.createElementNS(NS0, 'path'); el.setAttribute('fill', 'url(#cks' + ub + ')'); el.setAttribute('stroke', 'url(#cks' + ub + ')'); el.setAttribute('stroke-width', 1.5); el.setAttribute('stroke-linejoin', 'round'); sG.appendChild(el); return { z, P: outl(ins), el }; });
      I.ck = { sG, sl, dir: 1, bodyG, d: '', Dh, bev, fp, tiles, ws, wm, wf, bs, bf, bl, dr, mt, pud, bites }; I.zE = () => Dh + 0.6; }
    // Dunkie: a real 3D donut (rounded ring). Glaze, sprinkles and bite crumbs sit on its front; the hole and bite are cut through it and turn with it, with the dough wall showing inside the hole
    if (ROUND[key] && ROUND[key].donut && headA) { const mEl = art.querySelector('mask'), dd = mk('defs', {}, art), ud = I.u, NS0 = 'http://www.w3.org/2000/svg';
      items.forEach(q => { if (q.inBody && q.tag === 'rect') { q.role = 'patch'; if (q.rot) { const a = q.rot * D2R, c = Math.cos(a), s = Math.sin(a), cx = q.cx, cy = q.cy; q.segs.forEach(sg => (sg.p || []).forEach(p => { const vx = p[0] - cx, vy = p[1] - cy; p[0] = cx + vx * c - vy * s; p[1] = cy + vx * s + vy * c; })); } }
        else if (q.inBody && q.tag === 'path' && q !== headA.q && q.a > area * 0.14) q.role = 'dglaze';
        else if (!q.inBody && q.e.closest('g[fill="#f7d7a8"]')) q.role = 'face'; });
      if (mEl) { const rc = mEl.querySelector('rect'); if (rc) { rc.setAttribute('x', -100); rc.setAttribute('y', -100); rc.setAttribute('width', 300); rc.setAttribute('height', 300); }
        const cs = [...mEl.querySelectorAll('circle')].map(c => ({ x: num(c, 'cx'), y: num(c, 'cy'), r: num(c, 'r'), el: c })), hole = cs.find(c => Math.abs(c.x - 50) < 2) || { x: 50, y: 40, r: 18 }, bites = cs.filter(c => c !== hole);
        cs.forEach(c => { const p = document.createElementNS(NS0, 'path'); p.setAttribute('fill', '#000'); c.el.parentNode.replaceChild(p, c.el); c.el = p; }); hole.r = Math.max(hole.r, 18);
        dd.innerHTML = '<radialGradient id="dwg' + ud + '" cx="50%" cy="18%" r="85%"><stop offset="0" stop-color="#8a4f22"/><stop offset="0.55" stop-color="#c47d3c"/><stop offset="1" stop-color="#eab06a"/></radialGradient><mask id="dwm' + ud + '" maskUnits="userSpaceOnUse" x="-100" y="-100" width="300" height="300"><rect x="-100" y="-100" width="300" height="300" fill="#fff"/><path fill="#000"/></mask>';
        const mg = bodyG.querySelector('g[mask]'), wall = mk('path', { fill: 'url(#dwg' + ud + ')', mask: 'url(#dwm' + ud + ')' }, bodyG); if (mg) mg.parentNode.insertBefore(wall, mg.nextSibling);
        const T = 11, Ro = headA.hx, HX0 = headA.cx, HY0 = headA.cy;
        I.dn = { hole, bites, wall, wm: dd.querySelector('#dwm' + ud + ' path'), T, Ro };
        I.zE = (dx, dy) => { const rho = Math.hypot(dx, dy), zo = rho <= Ro - T ? T : Math.sqrt(Math.max(0, T * T - (rho - Ro + T) * (rho - Ro + T))), rh = Math.hypot(HX0 + dx - hole.x, HY0 + dy - hole.y) - hole.r, zi = rh >= T ? T : rh <= 0 ? 0 : Math.sqrt(Math.max(0, T * T - (T - rh) * (T - rh))); return Math.min(zo, zi) + 0.4; }; } }
    // Frybo: each fry is a round 3D stick (tube with a rounded tip) fanned like the art, centred in the box and shaded across its width
    if (key === 'frybo') { const fr = items.filter(q => q.inBody && q.tag === 'rect' && q.rot != null).sort((a, b) => a.cx - b.cx), fd = mk('defs', {}, art), uf = I.u;
      const LAY = [[29, -11, -3], [39.5, -5, 1], [50, 0, 2], [60.5, 5, 1], [71, 11, -3]];
      fd.innerHTML = fr.map((q, i) => '<linearGradient id="fry' + uf + '_' + i + '" gradientUnits="userSpaceOnUse"><stop offset="0" stop-color="#c8871a"/><stop offset="0.18" stop-color="#f2bf3e"/><stop offset="0.36" stop-color="#fff5c6"/><stop offset="0.56" stop-color="#ffd65e"/><stop offset="0.84" stop-color="#e6a62a"/><stop offset="1" stop-color="#b8771a"/></linearGradient>').join('');
      fr.forEach((q, i) => { const L = LAY[i] || [q.cx, 0, 0]; q.role = 'fry'; q.fry = { i, cx: L[0], a: L[1] * D2R, z: L[2], y0: q.b.y, y1: q.b.y + q.b.height, py: q.b.y + 22, r: q.b.width / 2 }; q.gr = fd.querySelector('#fry' + uf + '_' + i); q.e.setAttribute('fill', 'url(#fry' + uf + '_' + i + ')'); }); }
    // Plip: white gloss marks are painted on the drop's surface, so they turn, spin and tilt with it (and hide round the back)
    if (ROUND[key] && ROUND[key].gloss) items.forEach(q => { if (!q.inBody && (q.fill === '#fff' || q.e.getAttribute('stroke') === '#ffffff')) q.role = 'face'; });
    // roots for parts that bend (ears, horns, tails, fins)
    const skin = q => { const P = pts(q.segs), d = P.map(p => dn(p[0], p[1])); const ins = P.filter((p, i) => d[i] < 1); let R;
      if (ins.length) R = ins.reduce((s, p) => [s[0] + p[0] / ins.length, s[1] + p[1] / ins.length], [0, 0]); else { let m = 0; d.forEach((v, i) => { if (v < d[m]) m = i; }); R = P[m]; }
      q.R = R; q.L = Math.max(1, ...P.map(p => Math.hypot(p[0] - R[0], p[1] - R[1]))); q.wt = P.map((p, i) => Math.pow(clamp(Math.hypot(p[0] - R[0], p[1] - R[1]) / q.L, 0, 1), 1.3) * clamp((d[i] - 0.85) / 0.4, 0, 1)); };
    [-1, 0, 1].forEach(sd => { const tops = items.filter(q => q.role === 'top' && q.side === sd); if (!tops.length) return; const big = tops.reduce((m, q) => q.a > m.a ? q : m); skin(big);
      tops.forEach(q => { if (q === big) return; if (Math.hypot(q.cx - big.cx, q.cy - big.cy) < 26) { q.owner = big; q.R = big.R; q.L = big.L; q.wt = pts(q.segs).map(p => Math.pow(clamp(Math.hypot(p[0] - big.R[0], p[1] - big.R[1]) / big.L, 0, 1), 1.3)); } else skin(q); }); });
    items.forEach(q => { if (q.role === 'side' || q.role === 'tail') skin(q); });
    const { earSec, flat } = H, allOrig = I.petRoles ? [...I.petRoles.keys()] : [];
    const els = I.petRoles ? [...art.querySelectorAll('path,ellipse,circle,rect')].filter(e => !e.closest('defs')) : [];
    items.forEach(q => { if (q.role !== 'earP' && q.role !== 'earF') return; const P = flat(q.segs, 14); const Hc = headA ? [headA.cx, headA.cy] : [50, 50], Hr = headA ? Math.max(headA.hx, headA.hy) : 26;
      const ins = P.filter(p => Math.hypot(p[0] - Hc[0], p[1] - Hc[1]) < Hr * 0.98);
      let piv; if (q.role === 'earF') { const top = P.slice().sort((a, b) => a[1] - b[1]).slice(0, Math.max(3, Math.round(P.length * 0.15))); piv = top.reduce((s, p) => [s[0] + p[0] / top.length, s[1] + p[1] / top.length], [0, 0]); piv = [lerpN(piv[0], Hc[0], 0.25), piv[1] + 3]; }
      else piv = ins.length ? ins.reduce((s, p) => [s[0] + p[0] / ins.length, s[1] + p[1] / ins.length], [0, 0]) : P.reduce((m, p) => Math.hypot(p[0] - Hc[0], p[1] - Hc[1]) < Math.hypot(m[0] - Hc[0], m[1] - Hc[1]) ? p : m, P[0]);
      const tip = P.reduce((m, p) => Math.hypot(p[0] - piv[0], p[1] - piv[1]) > Math.hypot(m[0] - piv[0], m[1] - piv[1]) ? p : m, P[0]), vx = tip[0] - piv[0], vy = tip[1] - piv[1], len = Math.hypot(vx, vy) || 1;
      if (!(len > 1) || !isFinite(piv[0]) || !isFinite(piv[1])) { q.role = 'top'; q.side = q.cx < 50 ? -1 : 1; return; }
      Object.assign(q, { pivot: piv, ux: vx / len, uy: vy / len, len }); q.S = earSec(q, P); if (!q.S.secs.length || q.S.secs.some(sc => !isFinite(sc.cx) || !isFinite(sc.hw))) { q.role = 'top'; q.side = q.cx < 50 ? -1 : 1; delete q.S; return; }
      const cid = 'gek' + I.u + '_' + items.indexOf(q); q.clipId = cid; });
    items.forEach(q => { if (q.role === 'inner') { const ow = items.find(z => z.e === els[q.ownerIdx] || (z.pet && els.indexOf(z.e) === q.ownerIdx)); q.owner = ow || items.find(z => (z.role === 'earP' || z.role === 'earF') && Math.abs(z.cx - q.cx) < 10); } });
    items.forEach(q => { if (q.role === 'pad') { const fts = items.filter(z => z.role === 'foot'); q.owner = fts.reduce((m, z) => !m || Math.abs(z.ox - q.cx) < Math.abs(m.ox - q.cx) ? z : m, null); } });
    const swingQ = items.filter(q => q.role === 'swing'); swingQ.forEach(q => { q.piv = [q.cx, q.b.y - 1]; });
    const crown = items.filter(q => q.role === 'crown'); if (crown.length) { const bx = Math.min(...crown.map(q => q.b.x)), bw = Math.max(...crown.map(q => q.b.x + q.b.width)) - bx, by = Math.max(...crown.map(q => q.b.y + q.b.height)); crown.forEach(q => { q.base = [bx + bw / 2, by]; }); }
    const pups = items.filter(q => q.role === 'pup' || q.role === 'pupEye'); if (pups.length) { const ys = pups.map(q => q.cy); I.pupC = [pups.reduce((s, q) => s + q.cx, 0) / pups.length, Math.max(...ys)]; }
    const sides = items.filter(q => q.role === 'side'); sides.forEach(q => { q.limb = !items.some(z => z.role === 'arm') && sides.some(o => o !== q && o.side === -q.side && Math.abs(o.cx - (100 - q.cx)) < 9); });
    // move paws on top of the face so they can reach the mouth; food goes between face and paws
    const filt = bodyG ? bodyG.getAttribute('filter') : null, arms = items.filter(q => q.role === 'arm' || q.role === 'hand');
    I.faceG = mk('g', {}, art); I.pg.prop = mk('g', {}, art); const armG = mk('g', filt ? { filter: filt } : {}, art);
    arms.forEach(q => armG.appendChild(q.e));
    // geometry
    const HX = headA ? headA.cx : 50, HY = headA ? headA.cy : 50, HR = headA ? Math.max(headA.hx, headA.hy) : 26;
    const armL = items.find(q => q.role === 'arm' && q.side < 0), armR = items.find(q => q.role === 'arm' && q.side > 0);
    const MO = v2.mouth || { x: ex, y: eyeY + 9, w: 9.6 };
    const pawY = armL ? (armL.oy + (armR ? armR.oy : armL.oy)) / 2 : Math.min(G - 10, MO.y + 18), pawX = armL ? armL.ox : 50 - Math.min(18, BB.width * 0.32);
    const MY = [17, 47, 58, 76, 95.5], CY = [TOP, eyeY, MO.y, pawY, G].map((v, i, a) => i && v <= a[i - 1] ? a[i - 1] + 1 : v);
    const pl = (A, B, v) => { if (v <= A[0]) return B[0] + (v - A[0]) * ((B[1] - B[0]) / (A[1] - A[0])); for (let i = 1; i < A.length; i++) if (v <= A[i] || i === A.length - 1) return B[i - 1] + (v - A[i - 1]) * (B[i] - B[i - 1]) / (A[i] - A[i - 1]); };
    const kx = Math.max(0.5, Math.abs(50 - pawX) / 18);
    I.mapHand = (inX, hy) => [inX * kx, pl(MY, CY, 76 + hy) - pawY];
    I.toM = (x, y) => [50 + (x - HX) / HR * 29, pl(CY, MY, y)];
    I.fromM = (x, y) => [HX + (x - 50) / 29 * HR, pl(MY, CY, y)];
    I.geo = { HX, HY, HR, G, TOP, eyeY, MO, EY, NY: headA ? HY + HR * 0.82 : HY + HR * 0.6, main, headA, pawY, pawX, BB };
    const tubeCol = q => { const f = q.fill || ''; const m = f.match(/url\(#([^)]+)\)/); if (!m) return f || '#e0b080'; const gEl = art.querySelector('[id="' + m[1] + '"]'); const st = gEl ? [...gEl.querySelectorAll('stop')] : []; return st.length ? st[Math.min(st.length - 1, Math.floor(st.length * 0.6))].getAttribute('stop-color') : '#e0b080'; };
    I.tubes = [armL, armR].map(a => a ? mk('path', { fill: 'none', stroke: tubeCol(a), 'stroke-linecap': 'round', opacity: 0 }, armG) : null);
    I.tubes.forEach(t => t && armG.insertBefore(t, armG.firstChild));
    const RC = ROUND[key] || {}; I.rk = RC.k || 1; I.sky = !!ROUND[key]; I.sr = RC.sr || 0; I.armOut = RC.armOut; I.armReach = RC.armReach || 0; I.whole = !!RC.whole; I.hb = !!RC.hb;
    // Mallow: paws rest where the art has them (his shoulders sit above the mouth) and still reach the mouth when asked
    if (RC.handFix) { const mh = I.mapHand, d0 = mh(0, 0)[1]; I.mapHand = (inX, hy) => { const m = mh(inX, hy); return [m[0], m[1] - d0 * clamp(1 + Math.min(0, hy) / 18, 0, 1)]; }; }
    // Pina: when he lifts food the paws come in gently and stop a little below his mouth, so the food sits on/under the mouth instead of above it
    if (RC.pina || RC.avo || RC.berri || RC.lemmy || RC.kiwi || RC.peachy || RC.melo || RC.pitaya || RC.tutti || RC.hana || RC.boo || RC.pixie || RC.bk) { const mh = I.mapHand; I.mapHand = (inX, hy) => { const m = mh(inX, hy), e = clamp(-hy / 18, 0, 1); return [m[0] * (1 - 0.3 * e), m[1] + 11 * e]; }; I.foodK = 0.15; }
    // Choco: hands hang only a little below the art position (no stretching from Mittens' longer body)
    if (RC.choco) { const mh = I.mapHand; I.mapHand = (inX, hy) => { const m = mh(inX, hy); return hy > 0 ? [m[0], hy * 0.5] : m; }; }
    // Dunkie: paws rest lower, level with his mouth, so they only travel a little to feed him
    if (RC.lowPaw) { const pY = pawY + (RC.armDY || 0), CY2 = [TOP, eyeY, MO.y, pY, G].map((v, i, a) => i && v <= a[i - 1] ? a[i - 1] + 1 : v), mh = (inX, hy) => [inX * kx, pl(MY, CY2, 76 + hy) - pY], d0 = mh(0, 0)[1];
      I.mapHand = (inX, hy) => { const m = mh(inX, hy); return [m[0], m[1] - d0 * clamp(1 + Math.min(0, hy) / 18, 0, 1) + 9 * clamp(-hy / 18, 0, 1) + ((I.cur && I.cur.name === 'eat_lollipop') ? 14 : (I.cur && (window.RiveRig.FOODHOLD || {})[I.cur.name] === 'R') ? 11 : 0) * clamp(-hy / 18, 0, 1)]; };
      { const mh2 = I.mapHand; I.mapHand = (inX, hy) => { const m = mh2(inX, hy), r = I.cur && (window.RiveRig.FOODHOLD || {})[I.cur.name] === 'R' ? 5 * clamp(-hy / 18, 0, 1) : 0; return [m[0] + r, m[1]]; }; }
      I.foodDY = { apple: -0.9, carrot: -0.1, donut: -2.1, burger: -1.3, sushi: -4.3, watermelon: -8.5, cupcake: 0.9, noodles: 2.2, fish: -4.5, corn: -5.3, banana: -0.4, cookie: -3.2, pizza: -0.9, pepper: -0.9, lemon: -4.3, strawberry: -4.4, popsicle: -0.6, icecream: 1.5, lollipop: 0.8 }; I.foodK = -0.75; I.foodK1 = 0.9; I.gripStick = 1; }
    // Mallow: a soft 3D cylinder seen a little from above; the cap, its gloss and the face turn round it, light stays put
    if (RC.cyl && headA) { const cd = mk('defs', {}, art), uc = I.u; let capQ = null;
      items.forEach(q => { if (q.inBody && q.tag === 'ellipse' && q.rx > 30) { q.role = 'mcap'; capQ = q; } else if (!q.inBody && q.tag === 'ellipse' && q.fill.indexOf('#fff') === 0 && q.cy < 44) q.role = 'mcapS'; });
      cd.innerHTML = '<linearGradient id="mcs' + uc + '" gradientUnits="userSpaceOnUse" x1="14" y1="0" x2="86" y2="0"><stop offset="0" stop-color="#b8608a" stop-opacity="0.34"/><stop offset="0.16" stop-color="#d98ab0" stop-opacity="0.06"/><stop offset="0.3" stop-color="#ffffff" stop-opacity="0.3"/><stop offset="0.47" stop-color="#ffffff" stop-opacity="0"/><stop offset="0.78" stop-color="#c26a95" stop-opacity="0.1"/><stop offset="1" stop-color="#a8507a" stop-opacity="0.42"/></linearGradient>'
        + '<linearGradient id="mcv' + uc + '" gradientUnits="userSpaceOnUse" x1="0" y1="44" x2="0" y2="88"><stop offset="0" stop-color="#ffffff" stop-opacity="0"/><stop offset="0.55" stop-color="#ffffff" stop-opacity="0"/><stop offset="1" stop-color="#b8608a" stop-opacity="0.32"/></linearGradient>'
        + '<radialGradient id="mct' + uc + '" gradientUnits="userSpaceOnUse" cx="40" cy="38" r="40"><stop offset="0" stop-color="#ffffff" stop-opacity="0"/><stop offset="0.75" stop-color="#ffffff" stop-opacity="0"/><stop offset="1" stop-color="#d98ab0" stop-opacity="0.35"/></radialGradient>';
      const par = headA.q.e.parentNode, sh1 = mk('path', { fill: 'url(#mcs' + uc + ')' }, par), sh2 = mk('path', { fill: 'url(#mcv' + uc + ')' }, par), sh3 = mk('path', { fill: 'url(#mct' + uc + ')' }, par);
      if (capQ) { par.insertBefore(sh1, capQ.e); par.insertBefore(sh2, capQ.e); par.insertBefore(sh3, capQ.e.nextSibling); }
      I.cyl = { e0: Math.asin(9.5 / 36), Yc: 40.5, PR: [[-2.6, 31], [-1.3, 34.6], [0.4, 36.4], [7, 37], [16.2, 37.4], [25.5, 37], [32.5, 35.8], [37.5, 33.2], [40.6, 29], [42.4, 23]], sh: [sh1, sh2, sh3], gs: cd.querySelector('#mcs' + uc), gv: cd.querySelector('#mcv' + uc), gt: cd.querySelector('#mct' + uc) }; }
    I.mReach = !!RC.mReach; I.armStr = !!RC.armIn; I.avoidHead = !!RC.avoidHead; if (RC.armIn) items.forEach(q => { if (q.role === 'arm') { const a = (q.rot || 0) * D2R; q.hx = q.ox + Math.sin(a) * q.ry; q.hy = q.oy - Math.cos(a) * q.ry; } if (q.role === 'arm' && RC.armDY) { q.oy += RC.armDY; q.hy += RC.armDY; } if (q.role === 'arm' && RC.armDX) { q.ox -= q.side * RC.armDX; q.hx -= q.side * RC.armDX; } });
    // Aurora: whale body built from cross-sections (round face in front, body tapering back into a tail that curls up into a fluke)
    if (RC.whale && headA) { const FNR = [[50, 58.5, -6, 35.5, 31.5], [50, 59.5, -13, 33, 29], [50, 61.5, -20, 28.5, 25], [50, 65, -27, 22.5, 20], [50, 69.5, -34, 16, 14], [50, 73, -40, 10.5, 9.5], [50, 75, -45, 7, 6.5], [50, 76, -49, 5, 4.6]], SLR = [[50, 58, -6, 35.5, 31.5], [50, 60, -13, 34, 29.5], [50, 62.5, -20, 31.5, 27], [50, 65.5, -27, 28, 24], [50, 69, -34, 24, 20.5], [50, 72.5, -40, 20, 17], [50, 75.5, -45, 16, 14], [50, 79, -48.5, 12, 10.5], [50, 81.5, -51, 9, 8]], NWR = [[50, 60.5, -6, 35.5, 27.5], [50, 61, -14, 34.5, 26.5], [50, 62.5, -22, 32, 24.5], [50, 64.5, -30, 28, 21.5], [50, 67, -38, 23, 17.5], [50, 69, -45, 17.5, 13.5], [50, 70.5, -51, 12, 9.5], [50, 71.5, -56, 8, 6.5], [50, 72, -59.5, 5, 4.5], [50, 72, -62, 3.6, 3.4]], NWL = [[[50, 74.5, -55.5, 4.6], [43, 73.5, -60, 4.4], [36.5, 71.5, -63.5, 3.4], [31, 69, -65, 2.2]], [[50, 74.5, -55.5, 4.6], [57, 73.5, -60, 4.4], [63.5, 71.5, -63.5, 3.4], [69, 69, -65, 2.2]]], q = headA.q, Zf = 30, AX = headA.hx, BY = headA.hy, CX = headA.cx, CY = headA.cy, st = [];
      const FTH = RC.narw ? [0.1, 0.24, 0.38, 0.52, 0.66, 0.8, 0.94, 1.08, 1.22, 1.36, 1.47, Math.PI / 2] : [0.14, 0.4, 0.66, 0.92, 1.2, Math.PI / 2]; FTH.forEach(th => st.push([CX, CY, Zf * Math.cos(th), AX * Math.sin(th), BY * Math.sin(th)]));
      (RC.seal ? SLR : RC.narw ? NWR : RC.dolph ? FNR : [[50, 60, -6, 37, 27.5], [51, 61, -12, 34.5, 26], [53, 65, -18, 28.5, 22], [56, 71.5, -25, 19.5, 15.5], [59, 77, -31, 11.5, 10], [61, 80.5, -37, 7.5, 6.8], [62, 82, -42, 5.8, 5.4]]).forEach(r => st.push(r));
      const lobes = RC.seal || RC.narw ? [] : RC.dolph ? [[[50, 76, -49, 4.6], [45, 75, -53, 3.9], [40.5, 73.5, -56, 3], [36.5, 71.5, -57.5, 2]], [[50, 76, -49, 4.6], [55, 75, -53, 3.9], [59.5, 73.5, -56, 3], [63.5, 71.5, -57.5, 2]]] : [[[62, 82, -42, 5.2], [56, 84, -46, 4.2], [50.5, 85.3, -49, 3.2], [45.5, 86, -50.5, 2.2]], [[62, 82, -42, 5.2], [68, 84, -46, 4.2], [73.5, 85.3, -49, 3.2], [78.5, 86, -50.5, 2.2]]];
      const wd = mk('defs', {}, art), u1 = I.u;
      wd.innerHTML = '<linearGradient id="wbg' + u1 + '" gradientUnits="userSpaceOnUse" x1="14" y1="18" x2="90" y2="90"><stop offset="0" stop-color="#a6f6e8"/><stop offset="0.5" stop-color="#a2acff"/><stop offset="1" stop-color="#ffaee8"/></linearGradient>'
        + '<radialGradient id="wsh' + u1 + '" gradientUnits="userSpaceOnUse" cx="34" cy="40" r="60"><stop offset="0" stop-color="#ffffff" stop-opacity="0.45"/><stop offset="0.32" stop-color="#ffffff" stop-opacity="0"/><stop offset="0.68" stop-color="#3a2a8a" stop-opacity="0"/><stop offset="1" stop-color="#3a2a8a" stop-opacity="0.36"/></radialGradient>'
        + '<radialGradient id="wfl' + u1 + '" cx="38%" cy="30%" r="75%"><stop offset="0" stop-color="#d4f4ff"/><stop offset="0.6" stop-color="#a2acff"/><stop offset="1" stop-color="#8a7ae6"/></radialGradient>';
      if (RC.dolph) wd.innerHTML = '<radialGradient id="wsh' + u1 + '" gradientUnits="userSpaceOnUse" cx="34" cy="40" r="60"><stop offset="0" stop-color="#ffffff" stop-opacity="0.4"/><stop offset="0.34" stop-color="#ffffff" stop-opacity="0"/><stop offset="0.66" stop-color="#1d4f8f" stop-opacity="0"/><stop offset="1" stop-color="#1d4f8f" stop-opacity="0.34"/></radialGradient>'
        + '<radialGradient id="wfl' + u1 + '" cx="38%" cy="30%" r="75%"><stop offset="0" stop-color="#bfe4ff"/><stop offset="0.6" stop-color="#6ab8f2"/><stop offset="1" stop-color="#3f8ad0"/></radialGradient>'
        + '<radialGradient id="wfd' + u1 + '" cx="40%" cy="25%" r="80%"><stop offset="0" stop-color="#a6d8fb"/><stop offset="0.55" stop-color="#6ab8f2"/><stop offset="1" stop-color="#3a86cc"/></radialGradient>';
      if (RC.seal) wd.innerHTML = '<radialGradient id="wsh' + u1 + '" gradientUnits="userSpaceOnUse" cx="34" cy="40" r="60"><stop offset="0" stop-color="#ffffff" stop-opacity="0.45"/><stop offset="0.34" stop-color="#ffffff" stop-opacity="0"/><stop offset="0.66" stop-color="#5a6a86" stop-opacity="0"/><stop offset="1" stop-color="#5a6a86" stop-opacity="0.3"/></radialGradient>'
        + '<radialGradient id="wfl' + u1 + '" cx="38%" cy="30%" r="75%"><stop offset="0" stop-color="#ffffff"/><stop offset="0.6" stop-color="#eef2f7"/><stop offset="1" stop-color="#c3cedb"/></radialGradient>'
        + '<radialGradient id="wfd' + u1 + '" cx="38%" cy="30%" r="75%"><stop offset="0" stop-color="#ffffff"/><stop offset="0.6" stop-color="#eef2f7"/><stop offset="1" stop-color="#c3cedb"/></radialGradient>';
      if (RC.narw) wd.innerHTML = '<radialGradient id="wsh' + u1 + '" gradientUnits="userSpaceOnUse" cx="34" cy="40" r="60"><stop offset="0" stop-color="#ffffff" stop-opacity="0.45"/><stop offset="0.34" stop-color="#ffffff" stop-opacity="0"/><stop offset="0.66" stop-color="#2c4f9c" stop-opacity="0"/><stop offset="1" stop-color="#2c4f9c" stop-opacity="0.32"/></radialGradient>'
        + '<radialGradient id="wfl' + u1 + '" cx="38%" cy="30%" r="75%"><stop offset="0" stop-color="#f2f9ff"/><stop offset="0.6" stop-color="#b4d8ff"/><stop offset="1" stop-color="#7aa4e8"/></radialGradient><radialGradient id="wfd' + u1 + '"><stop offset="0" stop-color="#b4d8ff"/></radialGradient>'
        + '<linearGradient id="nwh' + u1 + '" gradientUnits="userSpaceOnUse" x1="46" y1="20" x2="56" y2="20"><stop offset="0" stop-color="#efb75a"/><stop offset="0.24" stop-color="#fff8dc"/><stop offset="0.52" stop-color="#ffe6a0"/><stop offset="0.8" stop-color="#f0bb5a"/><stop offset="1" stop-color="#c4852e"/></linearGradient>'
        + '<radialGradient id="nwg' + u1 + '"><stop offset="0" stop-color="#fffbe0" stop-opacity="0.95"/><stop offset="0.42" stop-color="#fff1b0" stop-opacity="0.5"/><stop offset="1" stop-color="#ffe9a0" stop-opacity="0"/></radialGradient>'
        + '<radialGradient id="nwt' + u1 + '"><stop offset="0" stop-color="#ffffff"/><stop offset="0.45" stop-color="#fffbe0" stop-opacity="0.75"/><stop offset="1" stop-color="#fff2b8" stop-opacity="0"/></radialGradient>'
        + '<radialGradient id="nwb' + u1 + '" gradientUnits="userSpaceOnUse" cx="42" cy="72" r="34"><stop offset="0" stop-color="#ffffff"/><stop offset="0.6" stop-color="#f4faff"/><stop offset="1" stop-color="#d8e6f7"/></radialGradient>';
      const F = RC.dolph ? q.fill : 'url(#wbg' + u1 + ')'; q.e.setAttribute('fill', F); q.fill = F; items.forEach(z => { if (z.role === 'arm') { z.e.setAttribute('fill', 'url(#wfl' + u1 + ')'); if (!RC.dolph) z.fill = F; } }); I.tubes.forEach(t => t && t.setAttribute('stroke', RC.seal ? '#e2e8ef' : RC.narw ? '#a2c8f6' : RC.dolph ? '#5aaeea' : F));
      const sh = mk('path', { fill: 'url(#wsh' + u1 + ')' }, q.e.parentNode);
      I.wh = { st, lobes, sh, lg: wd.querySelector('#wbg' + u1), rg: wd.querySelector('#wsh' + u1), stops: [...wd.querySelectorAll('stop')].filter((x, i) => i < 3 || i > 6), hue: [[170, 82, 81], [234, 100, 82], [317, 100, 84], [195, 100, 92], [234, 100, 82], [255, 68, 69]], bb0: [CX - AX, CY - BY, CX + AX, CY + BY], nf: FTH.length };
      if (RC.dolph) { const RP = f => { const c = Math.cos(f), s = Math.sin(f); return s > 0 ? [Math.sign(c) * Math.pow(Math.abs(c), 0.85), Math.pow(s, 0.85)] : [c, s]; }, inB = RC.narw ? ((x, y) => { const t = (x - 24) / 52; return t > 0 && t < 1 && y > 76 - 20 * t * (1 - t); }) : ((x, y) => ((x - 50) / 30) * ((x - 50) / 30) + ((y - 88) / 24) * ((y - 88) / 24) < 1), bs = [];
        (RC.narw ? [0.2, 0.26, 0.32, 0.38, 0.45, 0.53, 0.62, 0.72, 0.83, 0.95, 1.08, 1.22, 1.36, 1.47, Math.PI / 2] : [0.19, 0.26, 0.34, 0.44, 0.56, 0.72, 0.92, 1.15, 1.37, Math.PI / 2]).forEach(th => { const a = AX * Math.sin(th), b = BY * Math.sin(th); let h = 0; for (let k = 1; k <= 60; k++) { const r = RP(Math.PI / 2 + k / 60 * Math.PI / 2); if (inB(CX + a * r[0], CY + b * r[1])) h = k / 60 * Math.PI / 2; else break; } bs.push([CX, CY, Zf * Math.cos(th), a, b, h]); });
        const h0 = bs[bs.length - 1][5]; (RC.narw ? NWR.slice(0, 6) : FNR.slice(0, 6)).forEach(([cx, cy, z, a, b]) => bs.push([cx, cy, z, a, b, h0 * Math.pow(clamp(1 + z / (RC.narw ? 50 : 26), 0, 1), RC.narw ? 1.5 : 1.3)]));
        const R = I.fnR || {}, par = q.e.parentNode, fin = mk('path', { fill: 'url(#wfd' + u1 + ')', stroke: 'url(#wfd' + u1 + ')', 'stroke-width': 0.3, 'stroke-linejoin': 'round' }, par); par.insertBefore(fin, q.e);
        if (R.bel) { R.bel.e.setAttribute('stroke', R.bel.fill); R.bel.e.setAttribute('stroke-width', 0.35); R.bel.e.setAttribute('stroke-linejoin', 'round'); }
        const cav = R.sn ? mk('path', { fill: '#7a2a40', opacity: 0 }, par) : null, jaw = R.sn ? mk('path', { fill: R.sn.fill }, par) : null; if (R.sn) { par.insertBefore(jaw, R.sn.e); par.insertBefore(cav, R.sn.e); }
        I.wh.fin = { RP, bs, fin, bel: R.bel, sn: R.sn, cav, jaw, snZ: Zf * Math.sqrt(1 - Math.pow((62.5 - CY) / BY, 2)), snF: null, par, head: q.e, bg: R.bel ? R.bel.e.parentNode : null }; I.fnB = { bodyG: par };
        // Sealy: no dorsal fin; hind flippers are flat 3D fans at the end of the tail; the two-lobed muzzle is a real bump on his face
        if (RC.seal) { fin.style.display = 'none'; const mz = R.mz || [], fl = [-1, 1].map(sd => { const e = mk('path', { fill: 'url(#wfl' + u1 + ')' }, par); par.insertBefore(e, q.e); return { e, sd, fr: false }; });
          if (mz[1]) mz[1].e.style.display = 'none'; I.wh.fin.seal = { F: fl, mz: mz[0] || null, mzRef: mz[1] ? mz[1].e : null, mzF: null }; }
        // Pearl: a 3D horn (cone + spiral grooves + glow + sparkles) on top of his head; spots all over his back ride on the round body
        if (RC.narw) { fin.style.display = 'none'; const hg = mk('g', {}, par); par.insertBefore(hg, q.e);
          const sB = mk('path', { fill: '#fff6c8' }, hg), glow = mk('circle', { fill: 'url(#nwg' + u1 + ')' }, hg), horn = mk('path', { fill: 'url(#nwh' + u1 + ')', stroke: '#e0a248', 'stroke-width': 0.25, 'stroke-linejoin': 'round' }, hg), grv = mk('path', { fill: 'none', stroke: '#cf8a32', 'stroke-width': 0.8, 'stroke-linecap': 'round', 'stroke-linejoin': 'round' }, hg), grvH = mk('path', { fill: 'none', stroke: '#fffbea', 'stroke-width': 0.45, 'stroke-linecap': 'round', 'stroke-linejoin': 'round', opacity: 0.85 }, hg), tip = mk('circle', { fill: 'url(#nwt' + u1 + ')' }, hg), sF = mk('path', { fill: '#fffbe0' }, hg);
          const spots = mk('path', { fill: '#86aeea' }, par); par.insertBefore(spots, q.e.nextSibling);
          if (R.bel) { R.bel.e.setAttribute('fill', 'url(#nwb' + u1 + ')'); R.bel.e.setAttribute('stroke', 'url(#nwb' + u1 + ')'); }
          const TH = FTH, nL = TH.length - 1, ix = th => { for (let i = 0; i < nL; i++) if (th <= TH[i + 1]) return i + Math.max(0, th - TH[i]) / (TH[i + 1] - TH[i]); return nL; };
          const SPT = [[38, 40, 1.5], [50, 37, 1.2], [62, 41, 1.6], [70, 48, 1.2], [30, 48, 1.1]].map(([x, y, r]) => { const dx = (x - CX) / AX, dy = (y - CY) / BY; return [ix(Math.asin(Math.min(0.999, Math.hypot(dx, dy)))), Math.atan2(dy, dx), r]; })
            .concat([[0.3, -2.6, 1.1], [0.5, -1.9, 1.4], [0.7, -1.2, 1.2], [0.4, -0.6, 1.1], [1.2, -1.6, 1.5], [1.6, -2.3, 1.1], [1.9, -0.8, 1.1], [2.3, -1.9, 1.3], [2.8, -1.3, 1.2], [3.2, -2.3, 1.0], [3.6, -0.9, 1.0], [4.1, -1.7, 1.1], [4.6, -2.4, 0.9], [5, -1.2, 0.9], [5.5, -1.9, 0.8], [6.1, -1.4, 0.7], [6.6, -2.1, 0.6], [7.2, -1.6, 0.55]].map(([i, f, r]) => [nL + i, f, r]));
          I.nwF = 1; I.mReach = 1; I.wh.fin.nw = { hg, glow, horn, grv, grvH, tip, sB, sF, spots, SPT, lg: wd.querySelector('#nwh' + u1), sw: { x: 0, v: 0, px: null, pv: 0 } }; } }
      I.zc0 = RC.narw ? -21 : -10; I.zE = (dx, dy) => Zf * Math.sqrt(Math.max(0, 1 - (dx / AX) * (dx / AX) - (dy / BY) * (dy / BY))) + 0.4; }
    // Breeze: kite tail is a chain hanging from the cloud; it trails behind every move and the bows ride along it
    if (RC.kite) { const tl = items.filter(q => q.inBody && q.role !== 'arm' && q.cx < 24 && q.cy > 70), str = tl.find(q => q.fill === 'none'), bows = tl.filter(q => q !== str);
      if (str) { const P0 = flat(str.segs, 10), cum = [0]; for (let i = 1; i < P0.length; i++) cum.push(cum[i - 1] + Math.hypot(P0[i][0] - P0[i - 1][0], P0[i][1] - P0[i - 1][1]));
        const N = 12, TL = cum[cum.length - 1], rest = []; for (let k = 0, j = 1; k < N; k++) { const s = TL * k / (N - 1); while (j < P0.length - 1 && cum[j] < s) j++; const u = clamp((s - cum[j - 1]) / ((cum[j] - cum[j - 1]) || 1), 0, 1); rest.push([P0[j - 1][0] + (P0[j][0] - P0[j - 1][0]) * u, P0[j - 1][1] + (P0[j][1] - P0[j - 1][1]) * u]); }
        tl.forEach(q => { q.role = 'kite'; }); bows.forEach(b => { let m = 1; rest.forEach((p, i) => { if (i && Math.hypot(p[0] - b.cx, p[1] - b.cy) < Math.hypot(rest[m][0] - b.cx, rest[m][1] - b.cy)) m = i; }); b.kj = m; });
        I.kite = { str, bows, rest, P: null }; } }
    const bel = items.filter(q => q.pet === 'body').sort((a, b) => b.cy - a.cy)[0]; if (bel) I.belly = { x: bel.cx, y: bel.cy, w: bel.b.width / 2, h: bel.b.height / 2, d: bel.b.width / 2 * 0.8 };
    items.forEach(q => { if (q.role === 'hclip') { const dx = q.cx - HX, dy = q.cy - HY; q.zA = Math.sqrt(Math.max(0, (HR + 0.5) * (HR + 0.5) - dx * dx - dy * dy)) * I.rk + 0.6; } });
    const orb = items.filter(q => q.role === 'orbit'); if (orb.length && bodyG) { const big = orb.reduce((m, q) => q.a > m.a ? q : m); I.orb = { c: [big.cx, big.cy], home: [big.cx - HX, big.cy - HY], front: big.e.parentNode, back: mk('g', {}, art), els: orb.map(q => q.e), Z: 1 }; art.insertBefore(I.orb.back, bodyG); }
    const xd = mk('defs', {}, art), u0 = I.u;
    if (RC.footShade) { xd.innerHTML += '<radialGradient id="dft' + u0 + '" cx="38%" cy="30%" r="75%"><stop offset="0" stop-color="#fbf1dc"/><stop offset="0.55" stop-color="#d8c09a"/><stop offset="1" stop-color="#a88a5e"/></radialGradient>'; items.forEach(q => { if (q.role === 'foot') q.e.setAttribute('fill', 'url(#dft' + u0 + ')'); }); }
    // Zappi: the fur spikes live on the sphere (one ring matches the art, three more rings fill in as he turns), drawn behind a round body
    if (RC.spiky && headA) { const q = headA.q, ds = pts(q.segs).map(p => Math.hypot(p[0] - HX, p[1] - HY)), r0 = Math.min(...ds), r1 = Math.max(...ds), D = [], par = q.e.parentNode;
      q.segs = ellS(HX, HY, r0 + 0.3, r0 + 0.3, 0, 16);
      const ring = (lam, list) => list.forEach(f => { const a = f * D2R; D.push([Math.cos(a) * Math.cos(lam * D2R), -Math.sin(a), Math.cos(a) * Math.sin(lam * D2R)]); });
      ring(0, Array.from({ length: 24 }, (_, k) => 90 + k * 15)); [45, 90, 135].forEach(l => ring(l, Array.from({ length: 24 }, (_, k) => 7.5 + k * 15).filter(f => Math.abs(Math.sin(f * D2R)) < 0.95)));
      const bb = q.b, gx = bb.x + bb.width * 0.38, gy = bb.y + bb.height * 0.3; xd.innerHTML += '<radialGradient id="zbg' + u0 + '" gradientUnits="userSpaceOnUse" cx="' + gx + '" cy="' + gy + '" r="' + (bb.width * 0.75) + '"><stop offset="0" stop-color="#fff9c4"/><stop offset="0.6" stop-color="#ffe14a"/><stop offset="1" stop-color="#eebb12"/></radialGradient>';
      const el = mk('path', { fill: 'url(#zbg' + u0 + ')' }, par); par.insertBefore(el, q.e); q.e.setAttribute('fill', 'url(#zbg' + u0 + ')');
      I.spk = { el, dirs: D, r0, r1, rb: r0 - 1.5, w: 4.1, gr: xd.querySelector('#zbg' + u0), g0: [gx, gy] }; }
    // Puff: the flat spike art is rebuilt as 3D spikes all round his round body (they bristle, wiggle and turn with him); one small beak-like mouth
    if (RC.pfish && headA) { const q = headA.q, par = q.e.parentNode, D = [], r0 = Math.max(headA.hx, headA.hy);
      items.forEach(z => { if (z.pet === 'hide' || z.role === 'hide') { z.role = 'bnop'; z.e.style.display = 'none'; } else if (z.inBody && z.fill === '#fff8dc') z.role = 'pfBel'; }); I.pfF = 1;
      const ring = (lam, list) => list.forEach(f => { const a = f * D2R; D.push([Math.cos(a) * Math.cos(lam * D2R), -Math.sin(a), Math.cos(a) * Math.sin(lam * D2R)]); });
      ring(0, [90, 58, 122, 26, 154, -6, 186, -34, 214]); [45, 90, 135].forEach(l => ring(l, [58, 122, 26, 154, -6, 186, -34, 214])); [67.5, 112.5].forEach(l => ring(l, [140, 172, 204])); [22.5, 157.5].forEach(l => ring(l, [74, 106, 10, 170])); [67.5, 112.5].forEach(l => ring(l, [-28, 4, 36])); ring(90, [-50, 70]);
      const bb = q.b, gx = bb.x + bb.width * 0.38, gy = bb.y + bb.height * 0.3; xd.innerHTML += '<radialGradient id="pfs' + u0 + '" gradientUnits="userSpaceOnUse" cx="' + gx + '" cy="' + gy + '" r="' + (bb.width * 0.8) + '"><stop offset="0" stop-color="#ffe08a"/><stop offset="0.55" stop-color="#f2b030"/><stop offset="1" stop-color="#d0861a"/></radialGradient>';
      const el = mk('path', { fill: 'url(#pfs' + u0 + ')', stroke: '#e09a28', 'stroke-width': 0.4, 'stroke-linejoin': 'round' }, par); par.insertBefore(el, q.e);
      const elF = mk('path', { fill: 'url(#pfs' + u0 + ')', stroke: '#d48a1e', 'stroke-width': 0.45, 'stroke-linejoin': 'round' }, par); par.insertBefore(elF, q.e.nextSibling); const bel = items.find(z => z.role === 'pfBel'); if (bel && bel.e.parentNode === par) par.insertBefore(elF, bel.e.nextSibling); I.pfArt = art;
      I.spk = { el, elF, dirs: D, r0, r1: r0 + 8, rb: r0 - 1.5, w: 3.1, gr: xd.querySelector('#pfs' + u0), g0: [gx, gy], pu: 1 };
      I.pfm = { in: mk('path', { fill: '#7a2a40', opacity: 0 }, I.faceG), lo: mk('path', { fill: '#e0882a' }, I.faceG), up: mk('path', { fill: '#f4a640' }, I.faceG), hl: mk('path', { fill: '#fff6e0', opacity: 0.55 }, I.faceG) }; }
    // Pina: a real pineapple. Barrel-shaped body of revolution (narrower rounded top, flatter base); the diamond lattice and a little spike on every fruitlet wrap
    // all round it (front ones drawn on the body, back ones behind so they poke out of the outline); the crown is a rosette of 18 channelled 3D leaves in 4 tiers
    if (RC.pina && headA) { const q = headA.q, par = q.e.parentNode, HY0 = headA.cy, pd = mk('defs', {}, art), NSv = 'http://www.w3.org/2000/svg';
      const rT = y => { const t = y < 64 ? (64 - y) / 31.5 : (y - 64) / 28.5, p = y < 64 ? 2.3 : 3; return t >= 1 ? 0 : 24.6 * Math.pow(1 - Math.pow(t, p), 1 / p); };
      I.zE = (dx, dy) => { const r = rT(HY0 + dy); return Math.sqrt(Math.max(0, r * r - dx * dx)); };
      const crB = mk('g', {}, par), spB = mk('path', { fill: '#d0921c' }, par); par.insertBefore(crB, q.e); par.insertBefore(spB, q.e);
      const ref = q.e.nextSibling, latH = mk('path', { fill: 'none', stroke: '#fff0b0', 'stroke-width': 0.55, opacity: 0.5, 'stroke-linecap': 'round', 'stroke-linejoin': 'round' }, par), lat = mk('path', { fill: 'none', stroke: '#c07e10', 'stroke-width': 1.05, opacity: 0.6, 'stroke-linecap': 'round', 'stroke-linejoin': 'round' }, par);
      const spD = mk('path', { fill: '#a8660c' }, par), spL = mk('path', { fill: '#eaae42' }, par), crF = mk('g', {}, par); [latH, lat, spD, spL, crF].forEach(el => par.insertBefore(el, ref));
      const LV = [], add = (n, th0, e, L, w, b) => { for (let i = 0; i < n; i++) LV.push({ th: (th0 + i * 360 / n) * D2R, e: e * D2R, L, w, b: b * D2R }); };
      add(3, 0, 5, 27, 4.3, 9); add(3, 60, 24, 23.5, 4.5, 15); add(6, 30, 45, 18, 4.3, 22); add(6, 0, 62, 12.5, 3.9, 24);
      LV.forEach((o, i) => { const gr = document.createElementNS(NSv, 'linearGradient'), id = 'pnl' + I.u + '_' + i; gr.setAttribute('id', id); gr.setAttribute('gradientUnits', 'userSpaceOnUse');
        o.st = [0, 0.5, 1].map(f => { const st = document.createElementNS(NSv, 'stop'); st.setAttribute('offset', f); gr.appendChild(st); return st; }); pd.appendChild(gr); o.gr = gr; o.ph = i * 1.37;
        o.g = mk('g', {}, crF); o.bl = mk('path', { fill: 'url(#' + id + ')', stroke: '#3a8a3a', 'stroke-width': 0.35, 'stroke-linejoin': 'round' }, o.g); o.rb = mk('path', { fill: 'none', stroke: '#e0fac8', 'stroke-width': 0.45, opacity: 0.5, 'stroke-linecap': 'round' }, o.g); });
      I.pn = { rT, crB, crF, spB, spL, spD, lat, latH, LV, d: '' }; }
    // Avo: a real 3D avocado. Round body of revolution (skin profile from the art outline); the pale flesh is a patch on its front that slides round as he turns (cut at the limb);
    // the pit is a 3D dome in a socket in the flesh (bobs, rolls, pops out, can be tossed); the two sprout leaves are cupped 3D blades on top (sway, flutter, flap, propeller spin)
    if (RC.avo && headA && main) { const Qb = (a, b, c, s) => (1 - s) * (1 - s) * a + 2 * (1 - s) * s * b + s * s * c;
      const tab = (S, y0, y1) => { const pr = []; S.forEach(([a, b, c]) => { for (let k = 0; k <= 40; k++) { const s = k / 40; pr.push([Qb(a[1], b[1], c[1], s), Qb(a[0], b[0], c[0], s) - 50]); } }); const T = [];
        for (let y = y0; y <= y1 + 1e-6; y += 0.25) { let r = 0; for (let i = 1; i < pr.length; i++) if (y <= pr[i][0]) { const a = pr[i - 1], b = pr[i]; r = b[0] > a[0] ? a[1] + (b[1] - a[1]) * (y - a[0]) / (b[0] - a[0]) : b[1]; break; } T.push(Math.max(0, r)); }
        return y => { const f = (y - y0) * 4; if (f <= 0 || f >= T.length - 1) return 0; const i = Math.floor(f), u = f - i; return T[i] + (T[i + 1] - T[i]) * u; }; };
      const rT = tab([[[50, 12], [67, 12], [71, 34]], [[71, 34], [86, 52], [82, 70]], [[82, 70], [76, 93], [50, 93]]], 12, 93), wF = tab([[[50, 18], [63, 18], [66, 37]], [[66, 37], [78, 52], [75, 68]], [[75, 68], [70, 87], [50, 87]]], 18, 87);
      const dR = y => rT(y + 0.5) - rT(y - 0.5), HY0 = headA.cy; I.zE = (dx, dy) => { const r = rT(HY0 + dy); return Math.sqrt(Math.max(0, r * r - dx * dx)) + 0.3; };
      const FR = []; for (let i = 0; i <= 30; i++) { const y = 18 + 69 * (0.5 - 0.5 * Math.cos(Math.PI * i / 30)), r = rT(y); FR.push({ y, r, dr: dR(y), F: r > 0.2 ? Math.asin(clamp(wF(y) / r, 0, 1)) : 0 }); }
      const sk = main.q, fl = headA.q, pit = items.find(q => q.inBody && q.tag === 'circle' && /^url\(#c_/.test(q.fill)), shn = items.find(q => q.inBody && q.tag === 'circle' && q.fill === '#fff'), lf = items.find(q => q.inBody && q.fill === '#5fb85a');
      sk.role = 'bnop'; if (lf) { lf.role = 'bnop'; lf.e.style.display = 'none'; } if (pit) pit.role = 'bnop'; if (shn) shn.role = 'bnop';
      const par = fl.e.parentNode, ud = I.u, NSv = 'http://www.w3.org/2000/svg', P0 = (a, ref, pp) => { const e = document.createElementNS(NSv, 'path'); for (const k in a) e.setAttribute(k, a[k]); (pp || par).insertBefore(e, ref || null); return e; };
      mk('defs', {}, art).innerHTML = '<radialGradient id="avs' + ud + '" cx="62%" cy="66%" r="70%"><stop offset="0" stop-color="#f4fbd8"/><stop offset="0.55" stop-color="#d4ec9c"/><stop offset="1" stop-color="#93bf5c"/></radialGradient>';
      const lfB = document.createElementNS(NSv, 'g'), lfF = document.createElementNS(NSv, 'g'); par.insertBefore(lfB, sk.e); par.insertBefore(lfF, fl.e.nextSibling);
      const pe = pit ? pit.e : null, sock = P0({ fill: 'url(#avs' + ud + ')', opacity: 0 }, pe), ring = P0({ fill: 'none', stroke: '#6f9e3e', 'stroke-width': 1.1, opacity: 0.35, 'stroke-linejoin': 'round' }, pe);
      const sref = shn ? shn.e : pe ? pe.nextSibling : null, seam = P0({ fill: 'none', stroke: '#6e3e1a', 'stroke-width': 0.75, opacity: 0.45, 'stroke-linecap': 'round' }, sref), seamH = P0({ fill: 'none', stroke: '#e0a878', 'stroke-width': 0.45, opacity: 0.4, 'stroke-linecap': 'round' }, sref);
      const LV = [{ az: -78, el: 31, L: 16.5, W: 4.7, ph: 0 }, { az: 80, el: 33, L: 17.5, W: 4.6, ph: 2.1 }].map(o => { const g0 = document.createElementNS(NSv, 'g'); lfF.appendChild(g0);
        return Object.assign(o, { az: o.az * D2R, el: o.el * D2R, g: g0, hU: P0({ stroke: '#3e8a3c', 'stroke-width': 0.3, 'stroke-linejoin': 'round' }, null, g0), hD: P0({ stroke: '#3e8a3c', 'stroke-width': 0.3, 'stroke-linejoin': 'round' }, null, g0), rib: P0({ fill: 'none', stroke: '#c4f0a8', 'stroke-width': 0.55, opacity: 0.6, 'stroke-linecap': 'round' }, null, g0) }); });
      I.av = { bodyG, rT, ya: 14, yb: 92, rx: 32, d: '', dF: '', FR, sk: sk.e, pit: pe, shn: shn && shn.e, sock, ring, seam, seamH, lfB, lfF, LV, S: { y: 70, r: rT(70), dr: dR(70) } }; }
    // Berri: a real 3D strawberry. Round body of revolution from the art outline (I.zE puts the face on it); the flat seeds, calyx and stem are rebuilt in 3D:
    // seeds sit in little dimples all round the berry and turn with it, the calyx is a ring of 5 cupped leaves on top (sway, flutter, flap, twirl), the stem is a springy round stalk
    if (RC.berri && headA) { const Qb = (a, b, c, s) => (1 - s) * (1 - s) * a + 2 * (1 - s) * s * b + s * s * c, TW = Math.PI * 2;
      const tab = (S, y0, y1) => { const pr = []; S.forEach(([a, b, c]) => { for (let k = 0; k <= 40; k++) { const s = k / 40; pr.push([Qb(a[1], b[1], c[1], s), Qb(a[0], b[0], c[0], s) - 50]); } }); const T = [];
        for (let y = y0; y <= y1 + 1e-6; y += 0.25) { let r = 0; for (let i = 1; i < pr.length; i++) if (y <= pr[i][0]) { const a = pr[i - 1], b = pr[i]; r = b[0] > a[0] ? a[1] + (b[1] - a[1]) * (y - a[0]) / (b[0] - a[0]) : b[1]; break; } T.push(Math.max(0, r)); }
        return y => { const f = (y - y0) * 4; if (f <= 0 || f >= T.length - 1) return 0; const i = Math.floor(f), u = f - i; return T[i] + (T[i + 1] - T[i]) * u; }; };
      const rT = tab([[[50, 30], [72, 30], [84, 46]], [[84, 46], [88, 64], [70, 82]], [[70, 82], [58, 92], [50, 92]]], 30, 92), dR = y => rT(y + 0.5) - rT(y - 0.5), HY0 = headA.cy;
      I.zE = (dx, dy) => { const r = rT(HY0 + dy); return Math.sqrt(Math.max(0, r * r - dx * dx)) + 0.3; };
      const sk = headA.q, par = sk.e.parentNode, ref = sk.e.nextSibling, NSv = 'http://www.w3.org/2000/svg', P0 = (a, rf, pp) => { const e = document.createElementNS(NSv, 'path'); for (const k in a) e.setAttribute(k, a[k]); (pp || par).insertBefore(e, rf || null); return e; };
      const SD = []; [41, 49.5, 58, 66.5, 75, 83, 88.5].forEach((y, j) => { const r = rT(y), n = Math.max(4, Math.round(TW * r / 17)); for (let k = 0; k < n; k++) { const f = (k + (j % 2) * 0.5) / n * TW + j * 0.21, x = r * Math.sin(f); if (Math.cos(f) > 0 && Math.abs(x) < 26 && y > 51 && y < 69) continue; SD.push({ y, f, r, dr: dR(y) }); } });
      const dim = P0({ fill: '#b81f40', opacity: 0.3 }, ref), sdE = P0({ fill: '#ffe58a' }, ref);
      const lfB = document.createElementNS(NSv, 'g'), stG = document.createElementNS(NSv, 'g'), lfF = document.createElementNS(NSv, 'g'); par.insertBefore(lfB, sk.e); par.insertBefore(stG, sk.e); par.insertBefore(lfF, ref);
      const LV = [{ az: -90, el: 11, L: 20, W: 4.6, ph: 0 }, { az: 90, el: 11, L: 20, W: 4.6, ph: 1.3 }, { az: -128, el: 40, L: 18, W: 4.4, ph: 2.6 }, { az: 128, el: 40, L: 18, W: 4.4, ph: 3.9 }, { az: 180, el: 64, L: 16, W: 4.2, ph: 5.2 }].map(o => { const g0 = document.createElementNS(NSv, 'g'); lfF.appendChild(g0);
        return Object.assign(o, { az: o.az * D2R, el: o.el * D2R, g: g0, hU: P0({ stroke: '#3a8a3a', 'stroke-width': 0.3, 'stroke-linejoin': 'round' }, null, g0), hD: P0({ stroke: '#3a8a3a', 'stroke-width': 0.3, 'stroke-linejoin': 'round' }, null, g0), rib: P0({ fill: 'none', stroke: '#d4f5b0', 'stroke-width': 0.55, opacity: 0.6, 'stroke-linecap': 'round' }, null, g0) }); });
      const sa = { fill: 'none', 'stroke-linecap': 'round', 'stroke-linejoin': 'round' }, st = [['#3c7a2a', 2.6, 1], ['#5a9e3e', 1.8, 1], ['#a8dc80', 0.6, 0.85]].map(([c, w, o]) => P0(Object.assign({ stroke: c, 'stroke-width': w, opacity: o }, sa), null, stG));
      I.br = { bodyG, rT, ya: 34, yb: 90, rx: 36, d: '', SD, dim, sdE, lfB, lfF, LV, st }; }
    // Sweet Bakery batch 1 (Cuppy, Chip, Twisty): real 3D pastries (I.bk, drawn in the bakery block of the update). Their paws work like Berri's (hinge at the shoulder, ride on the body, swing up/out).
    // Cuppy: round paper wrapper (his head, face on it) with pleats wrapping round it, three swirled frosting tiers of revolution with drippy scalloped rims, piping swirls + sprinkles all round, a cherry on top (frosting + cherry jiggle on a spring).
    // Chip: a thick round cookie - baked crust edge, domed faces, chocolate chips on both faces; his face hides when his back shows. Twisty: one 3D pretzel rope - the thick belly carries his face,
    // the strands rise up the sides, loop over the top and twist round each other in the middle; the over/under at the twist and where the ends rest on the belly flips correctly as he turns.
    if (RC.bk && headA) { const NSv = 'http://www.w3.org/2000/svg', sk = headA.q, par = sk.e.parentNode, BH = I.bkH || {}, TW = Math.PI * 2, LG = document.createElementNS(NSv, 'g'); par.insertBefore(LG, sk.e.nextSibling);
      const P0 = (a, pp) => { const e = document.createElementNS(NSv, 'path'); for (const k in a) e.setAttribute(k, a[k]); (pp || LG).appendChild(e); return e; }, G0 = pp => { const e = document.createElementNS(NSv, 'g'); (pp || LG).appendChild(e); return e; };
      const df = art.querySelector('defs') || art.insertBefore(document.createElementNS(NSv, 'defs'), art.firstChild), HX0 = headA.cx, HY0 = headA.cy;
      const B = I.bk = { kind: key, bodyG, ya: 40, yb: 92, rx: 40, d: '' };
      if (key === 'cuppy') { const wr = y => { const b = 32 - (y - 54) * 6 / 34; return y <= 87 ? b : b - 3 + Math.sqrt(Math.max(0, 9 - (y - 87) * (y - 87))); };
        B.wr = wr; B.rT = y => y < 54 || y > 90 ? 0 : wr(y); B.ya = 56; B.yb = 89; B.rx = 30; B.zAt = (cx, cy) => { const r = wr(clamp(cy, 56, 89)), dx = clamp(Math.abs(cx - 50), 0, r); return Math.sqrt(r * r - dx * dx); };
        I.zE = (dx, dy) => { const r = wr(clamp(HY0 + dy, 54, 90)); return Math.sqrt(Math.max(0, r * r - dx * dx)) + 0.3; };
        B.pl = P0({ fill: 'none', stroke: '#5ab894', 'stroke-width': 0.85, opacity: 0.75, 'stroke-linecap': 'round' }); B.plL = P0({ fill: 'none', stroke: '#f0fff8', 'stroke-width': 0.5, opacity: 0.55, 'stroke-linecap': 'round' });
        const FR = (BH.fr || []).map(q => q.fill), prof = (yt, yc, yb, R) => y => y < yt || y > yb ? 0 : y < yc ? R * Math.sqrt(Math.max(0, 1 - Math.pow((yc - y) / (yc - yt), 2))) : R * (1 - 0.1 * Math.pow((y - yc) / (yb - yc), 2));
        B.T = [[34, 47, 57.5, 38, 10, 3.3, 16], [22, 35, 43.5, 26, 8, 2.8, 11], [10.5, 21.5, 27, 12.5, 6, 2.2, 5]].map(([yt, yc, yb, R, nd, dr, ns], i) => { const g = G0(), o = { yt, yc, yb, R, nd, dr, ph: i * 0.7, rf: prof(yt, yc, yb, R), g };
          o.e = P0({ fill: FR[i] || '#ffa8d6' }, g); o.gd = P0({ fill: 'none', stroke: '#d8549a', 'stroke-width': 1.3, opacity: 0.28, 'stroke-linecap': 'round', 'stroke-linejoin': 'round' }, g); o.gl = P0({ fill: 'none', stroke: '#fff6fb', 'stroke-width': 1.6, opacity: 0.4, 'stroke-linecap': 'round', 'stroke-linejoin': 'round' }, g);
          o.sp = ['#7cc8ff', '#ffe14a', '#9be38a'].map(c => P0({ fill: 'none', stroke: c, 'stroke-width': 1.25, 'stroke-linecap': 'round' }, g));
          o.SP = []; for (let k = 0; k < ns; k++) { const u = (k + 0.5) / ns; o.SP.push({ y: yt + (yb - yt) * (i === 2 ? 0.15 + 0.7 * u : 0.42 + 0.5 * ((k * 0.618) % 1)), f: k * 2.39996 + i, a: (k * 1.7 + i) % TW, c: k % 3 }); } return o; });
        const stw = P0({ fill: 'none', stroke: '#5a8a34', 'stroke-width': 1.15, 'stroke-linecap': 'round' }); B.stem = stw; B.ch = P0({ fill: ((BH.ch || [])[0] || {}).fill || '#ff3a4e' }); B.chG = P0({ fill: '#ffffff', opacity: 0.7 }); }
      if (key === 'chip') { const rim = H.flat(sk.segs, 6), cx0 = HX0, cy0 = HY0, T = 6.5, D = 2.6, ZF = (x, y) => T + D * Math.max(0, 1 - Math.pow((x - cx0) / 34, 2) - Math.pow((y - cy0) / 32, 2));
        Object.assign(B, { slab: 1, rim, T, D, ZF, cx0, cy0, rT: () => 30, ya: 30, yb: 88, rx: 34 }); B.zAt = (cx, cy) => { const rho = Math.hypot((cx - cx0) / 34, (cy - cy0) / 32); return rho >= 1 ? 0 : ZF(cx, cy) * Math.min(1, (1 - rho) / 0.2); };
        I.zE = (dx, dy) => ZF(HX0 + dx, HY0 + dy) + 0.3;
        const gr = document.createElementNS(NSv, 'radialGradient'); gr.setAttribute('id', 'bkc' + I.u); gr.setAttribute('cx', '38%'); gr.setAttribute('cy', '30%'); gr.setAttribute('r', '75%'); [[0, '#e6a656'], [0.6, '#b8743a'], [1, '#7a4418']].forEach(([o, c]) => { const s = document.createElementNS(NSv, 'stop'); s.setAttribute('offset', o); s.setAttribute('stop-color', c); gr.appendChild(s); }); df.appendChild(gr);
        B.plF = sk.e.getAttribute('fill'); sk.e.setAttribute('fill', 'url(#bkc' + I.u + ')'); B.pl = P0({ fill: B.plF });
        B.cr = P0({ fill: '#b8742e', opacity: 0.8 }); B.ce = P0({ fill: '#5e321c' }); B.chh = P0({ fill: '#a8704a', opacity: 0.75 });
        B.CH = [[34, 36, 3.2], [55, 31, 2.8], [70, 42, 3.4], [26, 52, 2.6], [75, 66, 3], [30, 74, 3.2], [46, 81, 2.8], [62, 79, 3.2], [44, 41, 2.2], [66, 30, 2]].map(([x, y, s]) => ({ x, y: y + 1, s, sd: 1 }))
          .concat([[38, 34, 3], [61, 37, 3.2], [27, 47, 2.8], [72, 53, 3], [33, 64, 3.2], [55, 58, 2.6], [66, 74, 3], [44, 78, 3], [50, 46, 2.4], [24, 66, 2.4]].map(([x, y, s]) => ({ x, y, s, sd: -1 })));
        B.CR = [[40, 30, 0.6], [60, 70, 0.6], [24, 64, 0.5], [70, 54, 0.6], [52, 66, 0.5], [36, 56, 0.45]];
        // baked texture: darker toasted crust ring round the face, golden-brown toasted blotches, little cracks and pits, a buttery sheen on the lit side
        const tx = c => P0(c); B.edge = tx({ fill: '#9a5622', opacity: 0.5, 'fill-rule': 'evenodd' }); B.edge2 = tx({ fill: '#b06a2e', opacity: 0.35, 'fill-rule': 'evenodd' }); B.tst = tx({ fill: '#b8702e', opacity: 0.32 }); B.tst2 = tx({ fill: '#9a5a24', opacity: 0.28 }); B.shn = tx({ fill: '#fff0c8', opacity: 0.35 });
        B.crk = tx({ fill: 'none', stroke: '#8a4c1c', 'stroke-width': 0.55, opacity: 0.55, 'stroke-linecap': 'round', 'stroke-linejoin': 'round' }); B.crkL = tx({ fill: 'none', stroke: '#ffe6b0', 'stroke-width': 0.4, opacity: 0.5, 'stroke-linecap': 'round' }); B.pit = tx({ fill: '#7e461c', opacity: 0.5 });
        [B.edge, B.edge2, B.tst, B.tst2, B.shn, B.crk, B.crkL, B.pit].forEach(e => LG.insertBefore(e, B.cr));
        B.TS = [[30, 44, 6], [66, 36, 5], [74, 58, 6.5], [24, 66, 5.5], [42, 82, 6], [64, 82, 5], [50, 30, 4.5], [56, 50, 4], [36, 58, 3.5]]; B.TS2 = [[31, 45, 3], [73, 59, 3.2], [43, 83, 3], [25, 67, 2.6], [65, 37, 2.4]];
        B.CK = [[[28, 38], [31, 41], [30, 45], [33, 47]], [[70, 70], [67, 72], [68, 76]], [[57, 26], [60, 28], [63, 27]], [[22, 58], [25, 60], [24, 63]], [[48, 86], [52, 85], [55, 87]], [[78, 48], [76, 51], [78, 54]]];
        B.PT = [[37, 49, 0.5], [62, 45, 0.45], [47, 72, 0.5], [70, 64, 0.4], [28, 58, 0.45], [56, 84, 0.4], [44, 28, 0.4], [72, 36, 0.45], [33, 80, 0.45], [58, 64, 0.35], [40, 66, 0.35], [52, 38, 0.35]]; }
      if (key === 'twisty') { const cub = (a, b, c, d, s) => { const u = 1 - s; return [0, 1].map(i => u * u * u * a[i] + 3 * u * u * s * b[i] + 3 * u * s * s * c[i] + s * s * s * d[i]); }, qd = (a, b, c, s) => { const u = 1 - s; return [0, 1].map(i => u * u * a[i] + 2 * u * s * b[i] + s * s * c[i]); };
        const AD = []; [[[61, 64], [56, 54], [46, 42], [42, 32]], [[42, 32], [38, 20], [28, 14], [20, 19]], [[20, 19], [12, 24], [11, 40], [14, 53.5]]].forEach(c => { for (let k = 0; k < 60; k++) AD.push(cub(...c, k / 60)); }); for (let k = 0; k <= 12; k++) AD.push(qd([14, 53.5], [15.4, 58], [17, 60], k / 12));
        const BD = []; for (let k = 1; k < 120; k++) BD.push(qd([17, 60], [50, 100], [83, 60], k / 120)); const MD = AD.slice().reverse().map(p => [100 - p[0], p[1]]);
        const rs = (Lp, st) => { const o = [{ p: Lp[0], s: 0 }]; let acc = 0, s = 0; for (let i = 1; i < Lp.length; i++) { const dd = Math.hypot(Lp[i][0] - Lp[i - 1][0], Lp[i][1] - Lp[i - 1][1]); acc += dd; s += dd; if (acc >= st || i === Lp.length - 1) { o.push({ p: Lp[i], s }); acc = 0; } } o.forEach(q => { q.L = s; }); return o; };
        const S = [], add = (arr, part) => arr.forEach(q => S.push({ x: q.p[0], y: q.p[1], part, s: q.s, L: q.L }));
        add(rs(AD, 2), 'A'); add(rs(BD, 2), 'bel'); add(rs(MD, 2), 'B');
        const sX = S.filter(o => o.part === 'A' && o.s < 40).reduce((m, o) => Math.abs(o.x - 50) < Math.abs(m.x - 50) ? o : m).s, bump = (s, c, w) => Math.exp(-Math.pow((s - c) / w, 2)), e3 = s => 3 * Math.max(0, Math.min(1, (8 - s) / 5));
        S.forEach((o, i) => { const a = S[Math.max(0, i - 1)], b = S[Math.min(S.length - 1, i + 1)], tx = b.x - a.x, ty = b.y - a.y, tl = Math.hypot(tx, ty) || 1; o.nx = -ty / tl; o.ny = tx / tl;
          if (o.part === 'bel') { const u = clamp((o.x - 17) / 66, 0, 1); o.r = 6.5 + 5.5 * Math.sin(Math.PI * u); o.z = 0; }
          else { const sE = o.part === 'A' ? o.s : o.L - o.s; o.r = 6; o.sE = sE; o.z = e3(sE) + (o.part === 'A' ? 2.8 : -2.8) * bump(sE, sX, 6); } });
        const KS = 0.86; S.forEach(o => { o.x = 50 + (o.x - 50) * KS; o.y = 84 + (o.y - 84) * KS; o.r *= KS; o.z *= KS; });
        const idx = f => S.map((o, i) => f(o) ? i : -1).filter(i => i >= 0);
        Object.assign(B, { S, sX, iAll: idx(() => 1), aX: idx(o => o.part === 'A' && Math.abs(o.sE - sX) < 16), aXc: idx(o => o.part === 'A' && Math.abs(o.sE - sX) < 8), bX: idx(o => o.part === 'B' && Math.abs(o.sE - sX) < 16), bXc: idx(o => o.part === 'B' && Math.abs(o.sE - sX) < 8),
          aE: idx(o => o.part === 'A' && o.sE < 18), aEc: idx(o => o.part === 'A' && o.sE < 9), bE: idx(o => o.part === 'B' && o.sE < 18), bEc: idx(o => o.part === 'B' && o.sE < 9), belA: idx(o => o.part === 'bel' && Math.abs(o.x - 59.5) < 14.6), belB: idx(o => o.part === 'bel' && Math.abs(o.x - 40.5) < 14.6) });
        const BI = S.filter(o => o.part === 'bel'), zB = (x, y) => { let m = 1e9, r = 0; BI.forEach(o => { const d = (o.x - x) * (o.x - x) + (o.y - y) * (o.y - y); if (d < m) { m = d; r = o.r; } }); return Math.sqrt(Math.max(0, r * r - m)); };
        Object.assign(B, { rT: () => 10, ya: 56, yb: 90, rx: 40, zAt: zB }); I.zE = (dx, dy) => zB(HX0 + dx, HY0 + dy) + 0.3;
        { const gr = document.createElementNS(NSv, 'radialGradient'); gr.setAttribute('id', 'bkt' + I.u); gr.setAttribute('gradientUnits', 'userSpaceOnUse'); [[0, '#fbcf92'], [0.5, '#cf8a44'], [1, '#93501e']].forEach(([o, c]) => { const s = document.createElementNS(NSv, 'stop'); s.setAttribute('offset', o); s.setAttribute('stop-color', c); gr.appendChild(s); }); df.appendChild(gr); B.gr = gr; }
        const TF = 'url(#bkt' + I.u + ')', RIM = '#8e4c1c', HL = '#ffe0b0';
        sk.e.setAttribute('fill', RIM); B.mid = P0({ fill: TF }); B.hi = P0({ fill: HL, opacity: 0.3 });
        B.px = [0, 1, 2].map(k => { const cp = document.createElementNS(NSv, 'clipPath'); cp.setAttribute('id', 'bkx' + I.u + '_' + k); const ce = document.createElementNS(NSv, 'path'); cp.appendChild(ce); df.appendChild(cp); const g = G0(); g.setAttribute('clip-path', 'url(#bkx' + I.u + '_' + k + ')');
          return { cp: ce, b: P0({ fill: RIM }, g), m: P0({ fill: TF }, g), h: P0({ fill: HL, opacity: 0.3 }, g) }; });
        B.SL = []; [['A', 26, 0.9], ['A', 36, 0.4], ['A', 47, 1.1], ['A', 58, 0.3], ['A', 68, 0.8], ['B', 26, 0.7], ['B', 37, 1.2], ['B', 48, 0.5], ['B', 59, 1], ['B', 69, 0.2], ['bel', 14, 0.9], ['bel', 30, 0.4], ['bel', 52, 1.3], ['bel', 72, -0.9], ['bel', 86, 0.5], ['bel', 22, -1], ['A', 42, -1.2], ['B', 52, -1.1], ['bel', 62, 1.6]].forEach(([pt, s, th]) => {
          let bi = -1, bd = 1e9; S.forEach((o, i) => { if (o.part !== pt) return; const d = Math.abs((pt === 'bel' ? o.s : o.sE) - s); if (d < bd) { bd = d; bi = i; } }); if (bi >= 0) B.SL.push({ i: bi, th }); });
        B.salt = P0({ fill: '#ffffff', opacity: 0.95 }); }

      // Batch 2 (Crois, Maca, Puddi). qt(): radius r(y) of a body of revolution from the art outline (quadratic segments running down)
      const qt = SG => { const pr = []; SG.forEach(([a, b, c]) => { for (let k = 0; k <= 40; k++) { const s = k / 40, u = 1 - s; pr.push([u * u * a[1] + 2 * u * s * b[1] + s * s * c[1], u * u * a[0] + 2 * u * s * b[0] + s * s * c[0] - 50]); } });
        return y => { for (let i = 1; i < pr.length; i++) { const A = pr[i - 1], C = pr[i]; if ((y >= A[0] && y <= C[0]) || (y <= A[0] && y >= C[0])) { const d = C[0] - A[0]; return Math.max(0, d ? A[1] + (C[1] - A[1]) * (y - A[0]) / d : C[1]); } } return 0; }; };
      const ugr = (id, st) => { const gr = document.createElementNS(NSv, 'radialGradient'); gr.setAttribute('id', id + I.u); gr.setAttribute('gradientUnits', 'userSpaceOnUse'); st.forEach(([o, c]) => { const s = document.createElementNS(NSv, 'stop'); s.setAttribute('offset', o); s.setAttribute('stop-color', c); gr.appendChild(s); }); df.appendChild(gr); return gr; };
      // Crois: the middle roll is a round body of revolution (face on it, wrap lines slide round it); each side is 3 puffy 3D rolls getting smaller to a tip that curls down;
      // the rolls sit behind the middle from the front and swing round in front of him when he turns (sorted back to front), sway and lag behind his moves
      if (key === 'crois') { const rT = qt([[[50, 28], [68, 28], [68, 54]], [[68, 54], [68, 86], [50, 86]]]), KZ = 0.9;
        Object.assign(B, { rT, KZ, ya: 32, yb: 84, rx: 18 }); B.zAt = (cx, cy) => { const r = rT(clamp(cy, 32, 84)), dx = clamp(Math.abs(cx - 50), 0, r); return Math.sqrt(Math.max(0, r * r - dx * dx)) * KZ; };
        I.zE = (dx, dy) => { const r = rT(clamp(HY0 + dy, 28.5, 85.5)); return Math.sqrt(Math.max(0, r * r - dx * dx)) * KZ + 0.3; };
        B.rg = P0({ fill: 'none', stroke: '#c8782a', 'stroke-width': 1, opacity: 0.55, 'stroke-linecap': 'round' }); B.rgL = P0({ fill: 'none', stroke: '#fff0c8', 'stroke-width': 0.6, opacity: 0.5, 'stroke-linecap': 'round' });
        B.gr = ugr('bkr', [[0, '#ffe2a2'], [0.45, '#f0a24c'], [1, '#c06e24']]); const TF = 'url(#bkr' + I.u + ')';
        sk.e.setAttribute('fill', TF); sk.e.setAttribute('stroke', '#c27630'); sk.e.setAttribute('stroke-width', '1.1'); sk.e.setAttribute('stroke-opacity', '0.7');
        items.forEach(q => { if (q.role === 'shine') { q.e.setAttribute('opacity', '0.4'); q.e.setAttribute('fill', '#fff4d4'); } });
        B.gB = document.createElementNS(NSv, 'g'); par.insertBefore(B.gB, sk.e); B.gF = document.createElementNS(NSv, 'g'); par.insertBefore(B.gF, LG.nextSibling);
        B.SG = []; [-1, 1].forEach(sd => [[36, 59.5, -2, 8.6, 23, 14, 0, 0.3], [25.5, 62, -5, 8.4, 18.5, 12, -8, 0.6], [15.5, 67.5, -6, 7.6, 12.5, 8.8, -22, 1]].forEach(([x, y, z, a, b, c, rt, lv], i) => {
          const g = document.createElementNS(NSv, 'g'); B.gB.appendChild(g); const mkp = at => { const e = document.createElementNS(NSv, 'path'); for (const k in at) e.setAttribute(k, at[k]); g.appendChild(e); return e; };
          B.SG.push({ c: [sd < 0 ? x : 100 - x, y, z], a, b, cz: c, rt: sd * rt * D2R, lv, ph: i * 1.3 + sd, g, b0: mkp({ fill: '#c27630' }), m: mkp({ fill: TF }), sh: mkp({ fill: 'none', stroke: '#c27630', 'stroke-width': 0.8, opacity: 0.5, 'stroke-linecap': 'round' }), h: mkp({ fill: '#fff4d4', opacity: 0.3 }) }); })); }
      // Maca: a real macaron - the top shell is a dome of revolution (his head, face on it), the cream filling and bottom shell under it, the ruffled shell feet run all the way round and slide as he turns
      if (key === 'maca') { const rTop = qt([[[50, 20], [88, 20], [88, 54]], [[88, 54], [88, 60], [50, 60]]]), rBot = qt([[[50, 62], [86, 62], [86, 66]], [[86, 66], [86, 88], [50, 88]]]), rT = y => y < 57 ? rTop(y) : y < 67 ? 37.5 : rBot(y);
        Object.assign(B, { rTop, rT, ya: 26, yb: 86, rx: 38 }); B.zAt = (cx, cy) => { const r = rT(clamp(cy, 26, 86)), dx = clamp(Math.abs(cx - 50), 0, r); return Math.sqrt(Math.max(0, r * r - dx * dx)); };
        I.zE = (dx, dy) => { const r = rTop(clamp(HY0 + dy, 20.5, 57)); return Math.sqrt(Math.max(0, r * r - dx * dx)) + 0.3; };
        const fi = items.find(q => q.inBody && q.tag === 'path' && /^url\(#fi/.test(q.fill)), mkR = ref => { const g = document.createElementNS(NSv, 'g'); (ref ? ref.parentNode : par).insertBefore(g, ref || null); const e = document.createElementNS(NSv, 'path'); e.setAttribute('fill', '#7cd2ac'); g.appendChild(e);
          const l = document.createElementNS(NSv, 'path'); l.setAttribute('fill', 'none'); l.setAttribute('stroke', '#4fae86'); l.setAttribute('stroke-width', '0.6'); l.setAttribute('opacity', '0.65'); g.appendChild(l); const k = document.createElementNS(NSv, 'path'); k.setAttribute('fill', 'none'); k.setAttribute('stroke', '#58b48c'); k.setAttribute('stroke-width', '0.45'); k.setAttribute('opacity', '0.5'); g.appendChild(k); return { e, l, k }; };
        B.RF = [Object.assign(mkR(LG), { y0: 54.4, r: 37.7, h: 2.4, n: 30 }), Object.assign(mkR(fi ? fi.e : null), { y0: 64.4, r: 36.3, h: 2.4, n: 28 })]; }
      // Puddi: a real caramel pudding - a round body of revolution (seen a touch from above so the top shows), the caramel covers the whole top and runs down
      // all the way round in drips (they slide round as he turns), a swirl of cream with a cherry sits on top (sways + lags, cherry bobs on a spring)
      if (key === 'puddi') { const rS = qt([[[76, 38], [80, 60], [84, 78]], [[84, 78], [85.2, 84.4], [80, 86.4]], [[80, 86.4], [62, 86.8], [50, 86.8]]]), rT = y => y < 38 ? 0 : rS(y);
        { const dg = document.createElementNS(NSv, 'g'); par.insertBefore(dg, sk.e); const mkd = at => { const e = document.createElementNS(NSv, 'path'); for (const k in at) e.setAttribute(k, at[k]); dg.appendChild(e); return e; };
          B.pS = mkd({ fill: '#b8c8e4', opacity: 0.55 }); B.pR = mkd({ fill: '#eef4ff', stroke: '#c4d4ee', 'stroke-width': 0.8 }); B.pW = mkd({ fill: '#dfe8f8' }); B.pH = mkd({ fill: 'none', stroke: '#ffffff', 'stroke-width': 1.1, opacity: 0.85, 'stroke-linecap': 'round' }); }
        Object.assign(B, { rS, rT, ya: 40, yb: 84, rx: 33, vt: 0.2, z0: 30 }); B.zAt = (cx, cy) => { const r = rS(clamp(cy, 40, 84)), dx = clamp(Math.abs(cx - 50), 0, r); return Math.sqrt(Math.max(0, r * r - dx * dx)); };
        I.zE = (dx, dy) => { const r = rS(clamp(HY0 + dy, 38, 85.5)); return Math.sqrt(Math.max(0, r * r - dx * dx)) + 0.3; };
        const cq = (BH.car || [])[0], chq = (BH.ch || [])[0]; B.car = P0({ fill: cq ? cq.fill : '#c07030' }); B.carT = P0({ fill: '#b8692a' }); B.carH = P0({ fill: '#e8a052', opacity: 0.55 }); B.carG = P0({ fill: 'none', stroke: '#fff2d8', 'stroke-width': 1.2, opacity: 0.55, 'stroke-linecap': 'round' });
        B.crS = P0({ fill: '#a85a1a', opacity: 0.35 }); B.cr = P0({ fill: '#f2e8da' }); B.crM = P0({ fill: '#fffaf2' }); B.crL = P0({ fill: 'none', stroke: '#e2d4c0', 'stroke-width': 0.6, opacity: 0.8, 'stroke-linecap': 'round' }); B.crH = P0({ fill: '#ffffff', opacity: 0.75 });
        B.stem = P0({ fill: 'none', stroke: '#5a8a34', 'stroke-width': 1.1, 'stroke-linecap': 'round' }); B.ch = P0({ fill: chq ? chq.fill : '#ff3a4e' }); B.chG = P0({ fill: '#ffffff', opacity: 0.7 }); }

      // Batch 3 (Mochi, Cakey, Sugarplum)
      // Mochi: a soft round mochi ball (body of revolution, face on it) with a 3D strawberry sitting in its top (seeds in dimples all round, 3 leaves on a spring), the pink of the strawberry glows through the skin, powder dots all round
      if (key === 'mochi') { const rT = qt([[[50, 36], [86, 36], [86, 66]], [[86, 66], [86, 90], [50, 90]]]), rS = qt([[[50, 20], [64, 22], [62, 42]]]);
        Object.assign(B, { rT, rS, ya: 42, yb: 88, rx: 36 }); B.zAt = (cx, cy) => { const r = rT(clamp(cy, 42, 88)), dx = clamp(Math.abs(cx - 50), 0, r); return Math.sqrt(Math.max(0, r * r - dx * dx)); };
        I.zE = (dx, dy) => { const r = rT(clamp(HY0 + dy, 36.5, 89.5)); return Math.sqrt(Math.max(0, r * r - dx * dx)) + 0.3; };
        const gB = document.createElementNS(NSv, 'g'); par.insertBefore(gB, sk.e); const mkp = (at, pp) => { const e = document.createElementNS(NSv, 'path'); for (const k in at) e.setAttribute(k, at[k]); pp.appendChild(e); return e; };
        B.lfB = document.createElementNS(NSv, 'g'); gB.appendChild(B.lfB); const sq0 = (BH.st || [])[0], lq0 = (BH.lf || [])[0];
        B.sb = mkp({ fill: sq0 ? sq0.fill : '#ff4a62' }, gB); B.sdD = mkp({ fill: '#b81f40', opacity: 0.3 }, gB); B.sd = mkp({ fill: '#ffe58a' }, gB); B.sh = mkp({ fill: '#ffffff', opacity: 0.45 }, gB); B.lfF = document.createElementNS(NSv, 'g'); gB.appendChild(B.lfF);
        B.LV = [[-90, 22, 13, 3.4, 0], [90, 22, 13, 3.4, 1.4], [180, 70, 11, 3, 2.8], [0, 58, 8, 2.6, 4.1]].map(([az, el, L, W, ph]) => { const g = document.createElementNS(NSv, 'g'); B.lfF.appendChild(g); return { az: az * D2R, el: el * D2R, L, W, ph, g, e: mkp({ fill: lq0 ? lq0.fill : '#7ccd5a', stroke: '#3f9a3a', 'stroke-width': 0.35 }, g), rb: mkp({ fill: 'none', stroke: '#d4f5b0', 'stroke-width': 0.5, opacity: 0.7, 'stroke-linecap': 'round' }, g) }; });
        B.SD = []; [24.5, 28.5, 32.5, 36.5].forEach((y, j) => { const r = rS(y), n = Math.max(4, Math.round(TW * r / 5)); for (let k = 0; k < n; k++) B.SD.push({ y, f: (k + (j % 2) * 0.5) / n * TW, r }); });
        B.bl = P0({ fill: '#ffc6d2', opacity: 0.5 }); B.pd = P0({ fill: '#f0dde4' }); B.PD = []; for (let i = 0; i < 46; i++) { const y = 46 + 40 * ((0.3 + i * 0.5698403) % 1), f = ((0.1 + i * 0.7548777) % 1) * TW; B.PD.push({ y, f }); } }
      // Cakey: three round cake tiers stacked like the art (seen a touch from above so the tops show), each with frosting on top that drips down all the way round
      // (drips slide round as he turns), sprinkles round the bottom tier, three striped candles on top with flickering flames; the top tier + candles sway and lag a little
      if (key === 'cakey') { const fl = k => ((BH[k] || [])[0] || {}).fill;
        B.TR = [{ R: 38, yt: 70, yb: 90, fr: '#fff6fa', nd: 5, gl: '#ffffff' }, { R: 28, yt: 42, yb: 70, fr: '#ffb0d0', nd: 4, gl: '#ffe6f2' }, { R: 18, yt: 26, yb: 42, fr: '#fff6fa', nd: 3, gl: '#ffffff' }];
        const rT = y => y >= 70 ? 38 : y >= 42 ? 28 : y >= 26 ? 18 : 0; Object.assign(B, { rT, ya: 44, yb: 88, rx: 38, vt: 0.2, z0: 28 });
        B.zAt = (cx, cy) => { const r = rT(clamp(cy, 44, 88)), dx = clamp(Math.abs(cx - 50), 0, r); return Math.sqrt(Math.max(0, r * r - dx * dx)); };
        I.zE = (dx, dy) => { const r = rT(clamp(HY0 + dy, 42.5, 69.5)); return Math.sqrt(Math.max(0, r * r - dx * dx)) + 0.3; };
        const g1 = document.createElementNS(NSv, 'g'); par.insertBefore(g1, sk.e); const mkp = (at, pp) => { const e = document.createElementNS(NSv, 'path'); for (const k in at) e.setAttribute(k, at[k]); pp.appendChild(e); return e; };
        const T = B.TR; T[0].e = mkp({ fill: fl('t1') || '#ffb0d0' }, g1); T[0].fe = mkp({ fill: T[0].fr }, g1); T[0].gle = mkp({ fill: 'none', stroke: T[0].gl, 'stroke-width': 1, opacity: 0.6, 'stroke-linecap': 'round' }, g1);
        T[0].sp = ['#7cc8ff', '#ffe14a', '#9be38a'].map(c => mkp({ fill: 'none', stroke: c, 'stroke-width': 1.3, 'stroke-linecap': 'round' }, g1));
        T[0].SP = []; for (let i = 0; i < 30; i++) T[0].SP.push({ y: 76.5 + 10.5 * ((i * 0.618 + 0.2) % 1), f: i * 2.39996, a: (i * 1.9) % TW, c: i % 3 });
        T[1].fe = P0({ fill: T[1].fr }); T[1].gle = P0({ fill: 'none', stroke: T[1].gl, 'stroke-width': 1, opacity: 0.6, 'stroke-linecap': 'round' });
        T[2].e = P0({ fill: fl('t3') || '#a0ecd0' }); T[2].fe = P0({ fill: T[2].fr }); T[2].gle = P0({ fill: 'none', stroke: T[2].gl, 'stroke-width': 0.9, opacity: 0.6, 'stroke-linecap': 'round' });
        B.cdG = G0(); B.CD = [[-10, 1.5], [0, -2.5], [10, 1.5]].map(([x, z], i) => { const g = G0(B.cdG); return { x, z, i, g, b: P0({ fill: '#ffd0f0' }, g), s: P0({ fill: 'none', stroke: '#ff8fc8', 'stroke-width': 0.9, 'stroke-linecap': 'round' }, g), w: P0({ fill: 'none', stroke: '#6a3a3a', 'stroke-width': 0.5, 'stroke-linecap': 'round' }, g),
          gw: P0({ fill: '#ffe680', opacity: 0.22 }, g), f1: P0({ fill: '#ffd24a' }, g), f2: P0({ fill: '#ff8a2a' }, g) }; }); }
      // Sugarplum: round 3D head with a one-piece 3D hair shell (covers the back, sides and top, front/back sorted as she turns; fringe rides on her face), two round 3D hair buns,
      // a 3D crown (5 points, gem on the front point) sitting on her hair; the dress is a body of revolution (pleats turn with her), apron + heart ride on its front, round collar
      if (key === 'sugarplum') { const rD = y => y < 64 ? 14.5 : 16 + 10 * Math.pow(clamp((y - 64) / 24, 0, 1), 0.9);
        Object.assign(B, { rT: rD, rD, ya: 64, yb: 86, rx: 26 }); B.zAt = (cx, cy) => { const r = rD(clamp(cy, 64, 86)), dx = clamp(Math.abs(cx - 50), 0, r); return Math.sqrt(Math.max(0, r * r - dx * dx)); };
        const dOf = q => q.e.getAttribute('d') || ''; B.dr = items.find(q => q.inBody && /^M34 64/.test(dOf(q))); B.ap = items.find(q => q.inBody && /^M40 68/.test(dOf(q))); B.ht = items.find(q => q.inBody && q.fill === '#ff8fc0');
        [B.dr, B.ap, B.ht].forEach(q => { if (q) q.role = 'bnop'; }); const fr = items.find(q => q.inBody && /^M31 40/.test(dOf(q))); if (fr) fr.role = 'patch';
        const mkp = (at, pp, rf) => { const e = document.createElementNS(NSv, 'path'); for (const k in at) e.setAttribute(k, at[k]); pp.insertBefore(e, rf || null); return e; };
        if (B.dr) B.pl = mkp({ fill: 'none', stroke: '#7a40b0', 'stroke-width': 0.8, opacity: 0.4, 'stroke-linecap': 'round' }, B.dr.e.parentNode, B.dr.e.nextSibling);
        const cq = (BH.col || [])[0]; if (B.ht) B.col = mkp({ fill: cq ? cq.fill : '#a060e0' }, B.ht.e.parentNode, B.ht.e.nextSibling);
        B.hg = ugr('bkh', [[0, '#f4e6ff'], [0.55, '#b47ae6'], [1, '#7a40b0']]); const HU = 'url(#bkh' + I.u + ')', bq = (BH.bun || [])[0], crq = (BH.crown || [])[0];
        B.bunB = document.createElementNS(NSv, 'g'); par.insertBefore(B.bunB, sk.e); B.hB = mkp({ fill: HU }, par, sk.e); B.hF = mkp({ fill: HU }, LG); B.hS = mkp({ fill: 'none', stroke: '#7a40b0', 'stroke-width': 0.6, opacity: 0.6, 'stroke-linecap': 'round' }, LG);
        const crG = document.createElementNS(NSv, 'g'); par.insertBefore(crG, fr ? fr.e.nextSibling : LG.nextSibling); B.bunF = document.createElementNS(NSv, 'g'); crG.appendChild(B.bunF);
        B.BN = [-1, 1].map(sd => { const g = document.createElementNS(NSv, 'g'); B.bunB.appendChild(g); return { sd, g, e: mkp({ fill: bq ? bq.fill : HU }, g), h: mkp({ fill: '#ffffff', opacity: 0.35 }, g), l: mkp({ fill: 'none', stroke: '#7a40b0', 'stroke-width': 0.6, opacity: 0.5, 'stroke-linecap': 'round' }, g) }; });
        B.cbk = mkp({ fill: '#d08a10', stroke: '#ffffff', 'stroke-width': 0.5, 'stroke-linejoin': 'round' }, crG); B.cfr = mkp({ fill: crq ? crq.fill : '#ffd23a', stroke: '#ffffff', 'stroke-width': 0.7, 'stroke-linejoin': 'round' }, crG);
        B.cbd = mkp({ fill: 'none', stroke: '#e09a10', 'stroke-width': 0.7, opacity: 0.7, 'stroke-linecap': 'round' }, crG); B.gem = mkp({ fill: '#ff6aa8' }, crG); B.gemH = mkp({ fill: '#ffffff', opacity: 0.8 }, crG); }
    }
    // Lemmy: a real 3D lemon lying on its side - a body of revolution round his long (left-right) axis with a pointy nub at each end (profile from the art outline), so when he turns he goes round;
    // pores sit all round the peel and turn with him; the stem is a short round stalk on top and the leaf a cupped 3D blade beside it (sways, flaps, whirls round the stem)
    if (RC.lemmy && headA) { const TW = Math.PI * 2, Yc = 59, rX = x => { const u = Math.abs(x - 50), m = u < 34 ? 29 * Math.pow(1 - (u / 34) * (u / 34), 0.55) : 0, n = Math.abs(u - 35) < 4.6 ? 6.6 * Math.sqrt(1 - Math.pow((u - 35) / 4.6, 2)) : 0; return Math.max(m, n, Math.sqrt(Math.max(0, m * m + n * n - 30))); };
      const HX0 = headA.cx, HY0 = headA.cy; I.zE = (dx, dy) => { const r = rX(HX0 + dx), v = HY0 + dy - Yc; return Math.sqrt(Math.max(0, r * r - v * v)) + 0.3; };
      const sk = headA.q, par = sk.e.parentNode, ref = sk.e.nextSibling, NSv = 'http://www.w3.org/2000/svg', P0 = (a, rf, pp) => { const e = document.createElementNS(NSv, 'path'); for (const k in a) e.setAttribute(k, a[k]); (pp || par).insertBefore(e, rf || null); return e; };
      const PO = []; for (let x = 19; x <= 81; x += 5.2) { const r = rX(x), n = Math.max(5, Math.round(TW * r / 8.5)); for (let k = 0; k < n; k++) { const f = (k + ((x * 7) % 1) + (Math.round(x) % 2) * 0.5) / n * TW, y = Yc - r * Math.cos(f), z = r * Math.sin(f);
        if (z > 0 && Math.abs(x - 50) < 25 && y > 47 && y < 71) continue; PO.push({ x: x + Math.sin(k * 12.9 + x) * 1.2, f, s: 0.55 + 0.35 * ((Math.abs(Math.sin(k * 7.7 + x * 3.1)) * 9) % 1) }); } }
      const dim = P0({ fill: '#d39a00', opacity: 0.32 }, ref), poE = P0({ fill: '#fff6b0', opacity: 0.9 }, ref);
      const lfB = document.createElementNS(NSv, 'g'), stG = document.createElementNS(NSv, 'g'), lfF = document.createElementNS(NSv, 'g'); par.insertBefore(lfB, sk.e); par.insertBefore(stG, sk.e); par.insertBefore(lfF, ref);
      const LV = [{ az: 84, el: 22, L: 21, W: 5.2, ph: 0 }].map(o => { const g0 = document.createElementNS(NSv, 'g'); lfF.appendChild(g0);
        return Object.assign(o, { az: o.az * D2R, el: o.el * D2R, g: g0, hU: P0({ stroke: '#3a8a3a', 'stroke-width': 0.3, 'stroke-linejoin': 'round' }, null, g0), hD: P0({ stroke: '#3a8a3a', 'stroke-width': 0.3, 'stroke-linejoin': 'round' }, null, g0), rib: P0({ fill: 'none', stroke: '#3f8a2a', 'stroke-width': 0.7, opacity: 0.8, 'stroke-linecap': 'round' }, null, g0) }); });
      const sa = { fill: 'none', 'stroke-linecap': 'round', 'stroke-linejoin': 'round' }, st = [['#56722a', 4, 1], ['#7a9a3a', 3, 1], ['#b8d07a', 0.9, 0.8]].map(([c, w, o]) => P0(Object.assign({ stroke: c, 'stroke-width': w, opacity: o }, sa), null, stG));
      I.lm = { bodyG, rX, Yc, rT: () => 0, zAt: (x, y) => { const r = rX(x), v = y - Yc; return Math.sqrt(Math.max(0, r * r - v * v)); }, d: '', PO, dim, poE, lfB, lfF, LV, st }; }
    // Kiwi: a real 3D kiwi. Round body of revolution from the art outline (I.zE puts the face on it); the flat fuzz dots, stem and belly slice are rebuilt in 3D:
    // short fuzz hairs all round (turn with him, sway and lag behind moves, bristle with fzz), the green slice is a patch on the round belly that slides round as he turns (cut at the limb), the stem is a round nub on top
    if (RC.kiwi && headA) { const Qb = (a, b, c, s) => (1 - s) * (1 - s) * a + 2 * (1 - s) * s * b + s * s * c, TW = Math.PI * 2;
      const tab = (S, y0, y1) => { const pr = []; S.forEach(([a, b, c]) => { for (let k = 0; k <= 40; k++) { const s = k / 40; pr.push([Qb(a[1], b[1], c[1], s), Qb(a[0], b[0], c[0], s) - 50]); } }); const T = [];
        for (let y = y0; y <= y1 + 1e-6; y += 0.25) { let r = 0; for (let i = 1; i < pr.length; i++) if (y <= pr[i][0]) { const a = pr[i - 1], b = pr[i]; r = b[0] > a[0] ? a[1] + (b[1] - a[1]) * (y - a[0]) / (b[0] - a[0]) : b[1]; break; } T.push(Math.max(0, r)); }
        return y => { const f = (y - y0) * 4; if (f <= 0 || f >= T.length - 1) return 0; const i = Math.floor(f), u = f - i; return T[i] + (T[i + 1] - T[i]) * u; }; };
      const rT = tab([[[50, 24], [84, 24], [86, 58]], [[86, 58], [86, 90], [50, 90]]], 24, 90), dR = y => rT(y + 0.5) - rT(y - 0.5), HY0 = headA.cy;
      I.zE = (dx, dy) => { const r = rT(HY0 + dy); return Math.sqrt(Math.max(0, r * r - dx * dx)) + 0.3; };
      const sk = headA.q, par = sk.e.parentNode, ref = sk.e.nextSibling, NSv = 'http://www.w3.org/2000/svg', P0 = (a, rf, pp) => { const e = document.createElementNS(NSv, 'path'); for (const k in a) e.setAttribute(k, a[k]); (pp || par).insertBefore(e, rf || null); return e; };
      const FZ = []; for (let j = 0; j < 17; j++) { const y = 26.5 + j * 3.8, r = rT(y); if (r < 3) continue; const n = Math.max(5, Math.round(TW * r / 5.2)); for (let k = 0; k < n; k++) { const h = Math.abs(Math.sin(k * 12.9898 + j * 78.233) * 43758.5453) % 1, f = (k + h * 0.7 + (j % 2) * 0.5) / n * TW, x = r * Math.sin(f);
        if (Math.cos(f) > 0 && ((Math.abs(x) < 24 && y > 41 && y < 63) || Math.hypot(x, y - 75) < 16.5)) continue; FZ.push({ y: y + (h - 0.5) * 2.4, f, h }); } }
      const fzD = P0({ fill: 'none', stroke: '#6e4a2a', 'stroke-width': 0.55, 'stroke-linecap': 'round', opacity: 0.7 }, ref), fzL = P0({ fill: 'none', stroke: '#e2c49a', 'stroke-width': 0.45, 'stroke-linecap': 'round', opacity: 0.85 }, ref);
      const fl0 = items.find(q => q.inBody && /^url\(#s_/.test(q.fill)), sg = document.createElementNS(NSv, 'g'); par.insertBefore(sg, ref);
      const S = { sh: P0({ fill: '#5a3c22', opacity: 0.35 }, null, sg), rim: P0({ fill: '#f6ffe4' }, null, sg), fl: P0({ fill: fl0 ? fl0.e.getAttribute('fill') : '#9ad84a' }, null, sg), ray: P0({ fill: 'none', stroke: '#f2ffc8', 'stroke-width': 0.35, 'stroke-linecap': 'round', opacity: 0.55 }, null, sg), core: P0({ fill: '#fffbe2' }, null, sg), sd: P0({ fill: '#2a1a30' }, null, sg), sdh: P0({ fill: '#fff', opacity: 0.55 }, null, sg) };
      const stG = document.createElementNS(NSv, 'g'); par.insertBefore(stG, sk.e);
      const sa = { fill: 'none', 'stroke-linecap': 'round', 'stroke-linejoin': 'round' }, st = [['#4a3018', 3.6, 1], ['#6a4a2a', 2.6, 1], ['#a88058', 0.8, 0.8]].map(([c, w, o]) => P0(Object.assign({ stroke: c, 'stroke-width': w, opacity: o }, sa), null, stG));
      I.kw = { bodyG, rT, dR, ya: 26, yb: 90, rx: 36, d: '', FZ, fzD, fzL, sg, S, st }; }
    // Peachy: a real 3D peach. Body of revolution from the art outline with the suture groove pressed into it (runs down her front, over the top and down her back, so the top dips in like the art);
    // the outline is the union of the two lobes so the dip shows from the front. The flat crease, stem and leaf are rebuilt in 3D: the crease rides in the groove, the stem stands in the top dip, the leaf is a cupped blade
    if (RC.peachy && headA) { const Qb = (a, b, c, s) => (1 - s) * (1 - s) * a + 2 * (1 - s) * s * b + s * s * c, TW = Math.PI * 2;
      const tab = (S, y0, y1) => { const pr = []; S.forEach(([a, b, c]) => { for (let k = 0; k <= 40; k++) { const s = k / 40; pr.push([Qb(a[1], b[1], c[1], s), Qb(a[0], b[0], c[0], s) - 50]); } }); const T = [];
        for (let y = y0; y <= y1 + 1e-6; y += 0.25) { let r = 0; for (let i = 1; i < pr.length; i++) if (y <= pr[i][0]) { const a = pr[i - 1], b = pr[i]; r = b[0] > a[0] ? a[1] + (b[1] - a[1]) * (y - a[0]) / (b[0] - a[0]) : b[1]; break; } T.push(Math.max(0, r)); }
        return y => { const f = (y - y0) * 4; if (f <= 0 || f >= T.length - 1) return 0; const i = Math.floor(f), u = f - i; return T[i] + (T[i + 1] - T[i]) * u; }; };
      const rT = tab([[[50, 23.5], [68, 23.5], [79, 31]], [[79, 31], [86, 40], [86, 58]], [[86, 58], [86, 90], [50, 90]]], 23.5, 90), dR = y => rT(y + 0.5) - rT(y - 0.5), HY0 = headA.cy;
      const CD = y => { const u = Math.min(1, Math.max(0, (y - 25) / 21)); return 4.2 * (1 - u * u * (3 - 2 * u)); }, CW = 3.4;
      const SP3 = (y, f) => { const r = rT(y), sf = Math.sin(f), cf = Math.cos(f), dr = dR(y), nn = Math.hypot(1, dr), x = r * sf, dd = CD(y) * Math.exp(-(x / CW) * (x / CW)); return [x - sf / nn * dd, y + dr / nn * dd, r * cf - cf / nn * dd]; };
      I.zE = (dx, dy) => { const r = rT(HY0 + dy); return Math.sqrt(Math.max(0, r * r - dx * dx)) + 0.3; };
      const sk = headA.q, par = sk.e.parentNode, ref = sk.e.nextSibling, NSv = 'http://www.w3.org/2000/svg', P0 = (a, rf, pp) => { const e = document.createElementNS(NSv, 'path'); for (const k in a) e.setAttribute(k, a[k]); (pp || par).insertBefore(e, rf || null); return e; };
      const crD = P0({ fill: 'none', stroke: '#e2735e', 'stroke-width': 1.4, opacity: 0.55, 'stroke-linecap': 'round', 'stroke-linejoin': 'round' }, ref), crH = P0({ fill: 'none', stroke: '#ffe4cc', 'stroke-width': 0.6, opacity: 0.55, 'stroke-linecap': 'round', 'stroke-linejoin': 'round' }, ref);
      const lfB = document.createElementNS(NSv, 'g'), stG = document.createElementNS(NSv, 'g'), lfF = document.createElementNS(NSv, 'g'); par.insertBefore(lfB, sk.e); par.insertBefore(stG, sk.e); par.insertBefore(lfF, ref);
      const LV = [{ az: 82, el: 27, L: 22, W: 5.4, ph: 0 }].map(o => { const g0 = document.createElementNS(NSv, 'g'); lfF.appendChild(g0);
        return Object.assign(o, { az: o.az * D2R, el: o.el * D2R, g: g0, hU: P0({ stroke: '#3a8a3a', 'stroke-width': 0.3, 'stroke-linejoin': 'round' }, null, g0), hD: P0({ stroke: '#3a8a3a', 'stroke-width': 0.3, 'stroke-linejoin': 'round' }, null, g0), rib: P0({ fill: 'none', stroke: '#3f8a2a', 'stroke-width': 0.7, opacity: 0.8, 'stroke-linecap': 'round' }, null, g0) }); });
      const sa = { fill: 'none', 'stroke-linecap': 'round', 'stroke-linejoin': 'round' }, st = [['#5e3a22', 3.6, 1], ['#8a5a3a', 2.6, 1], ['#c08a62', 0.8, 0.8]].map(([c, w, o]) => P0(Object.assign({ stroke: c, 'stroke-width': w, opacity: o }, sa), null, stG));
      I.pe = { bodyG, rT, dR, SP3, ya: 26, yb: 90, rx: 36, d: '', crD, crH, lfB, lfF, LV, st }; }
    // Pitaya: a real 3D dragonfruit. Round body of revolution from the art outline (I.zE puts the face on it); the flat scale flaps, crown spikes, leaf wings and sparkles are rebuilt in 3D:
    // pink bracts with green tips curl out of the skin all round him (turn with him, the back ones poke out behind), a crown of spiky bracts on top, two cupped leaf wings on his sides that flap, twinkling sparkles
    if (RC.pitaya && headA) { const Qb = (a, b, c, s) => (1 - s) * (1 - s) * a + 2 * (1 - s) * s * b + s * s * c, TW = Math.PI * 2;
      const tab = (S, y0, y1) => { const pr = []; S.forEach(([a, b, c]) => { for (let k = 0; k <= 40; k++) { const s = k / 40; pr.push([Qb(a[1], b[1], c[1], s), Qb(a[0], b[0], c[0], s) - 50]); } }); const T = [];
        for (let y = y0; y <= y1 + 1e-6; y += 0.25) { let r = 0; for (let i = 1; i < pr.length; i++) if (y <= pr[i][0]) { const a = pr[i - 1], b = pr[i]; r = b[0] > a[0] ? a[1] + (b[1] - a[1]) * (y - a[0]) / (b[0] - a[0]) : b[1]; break; } T.push(Math.max(0, r)); }
        return y => { const f = (y - y0) * 4; if (f <= 0 || f >= T.length - 1) return 0; const i = Math.floor(f), u = f - i; return T[i] + (T[i + 1] - T[i]) * u; }; };
      const rT = tab([[[50, 24], [78, 26], [82, 56]], [[82, 56], [84, 90], [50, 90]]], 24, 90), dR = y => rT(y + 0.5) - rT(y - 0.5), HY0 = headA.cy;
      I.zE = (dx, dy) => { const r = rT(HY0 + dy); return Math.sqrt(Math.max(0, r * r - dx * dx)) + 0.3; };
      const sk = headA.q, par = sk.e.parentNode, ref = sk.e.nextSibling, NSv = 'http://www.w3.org/2000/svg', P0 = (a, rf, pp) => { const e = document.createElementNS(NSv, 'path'); for (const k in a) e.setAttribute(k, a[k]); (pp || par).insertBefore(e, rf || null); return e; };
      const G0 = rf => { const e = document.createElementNS(NSv, 'g'); par.insertBefore(e, rf || null); return e; }, wB = G0(sk.e), bB = G0(sk.e), bF = G0(ref), wF = G0(ref), df = document.createElementNS(NSv, 'defs'); par.insertBefore(df, wB);
      let gi = 0; const mkC = pg => { const id = 'ptb' + I.u + '_' + (gi++), gr = document.createElementNS(NSv, 'linearGradient'); gr.setAttribute('id', id); gr.setAttribute('gradientUnits', 'userSpaceOnUse'); const st = [0, 0.5, 1].map(o => { const s = document.createElementNS(NSv, 'stop'); s.setAttribute('offset', o); gr.appendChild(s); return s; }); df.appendChild(gr);
        const g0 = document.createElementNS(NSv, 'g'); pg.appendChild(g0); return { gr, st, g: g0, e: P0({ fill: 'url(#' + id + ')', stroke: '#8a1a66', 'stroke-width': 0.22, 'stroke-opacity': 0.6, 'stroke-linejoin': 'round' }, null, g0), sh: P0({ fill: '#2a4a1a', opacity: 0.13 }, null, g0) }; };
      const BR = []; [33, 44, 55, 66, 77, 85].forEach((y, j) => { const r = rT(y), n = Math.max(5, Math.round(TW * r / 15)); for (let k = 0; k < n; k++) { const f = (k + (j % 2) * 0.5) / n * TW + j * 0.37, x = r * Math.sin(f); if (Math.cos(f) > 0 && Math.abs(x) < 23 && y > 43 && y < 78) continue;
        const h = Math.abs(Math.sin(k * 12.9 + j * 7.7) * 43758.5) % 1; BR.push(Object.assign(mkC(bF), { y, f, r, dr: dR(y), L: (y > 84 ? 6.4 : y < 36 ? 7.4 : 9.2) * (0.88 + 0.24 * h), W: y > 84 ? 2.6 : 3.2, ph: h * TW, gk: (y - 30) / 58 })); } });
      const CR = [[0, 84, 14, 3], [-90, 62, 13, 3.1], [90, 62, 13, 3.1], [-150, 66, 11.5, 2.8], [150, 66, 11.5, 2.8], [180, 74, 10, 2.6]].map(([az, el, L, Wd], i) => Object.assign(mkC(bF), { az: az * D2R, el: el * D2R, L, W: Wd, ph: i * 1.9, gk: -1 }));
      const WG = [-1, 1].map(sd => { const g0 = document.createElementNS(NSv, 'g'); wB.appendChild(g0); const lf = { stroke: '#3a8a3a', 'stroke-width': 0.3, 'stroke-linejoin': 'round' };
        return { sd, g: g0, hU: P0(lf, null, g0), hD: P0(lf, null, g0), rib: P0({ fill: 'none', stroke: '#3f8a2a', 'stroke-width': 0.9, opacity: 0.85, 'stroke-linecap': 'round' }, null, g0), vn: P0({ fill: 'none', stroke: '#3f8a2a', 'stroke-width': 0.5, opacity: 0.55, 'stroke-linecap': 'round' }, null, g0) }; });
      const ST = [[16, 24, 3.4], [86, 30, 2.6], [82, 84, 2.2]].map(([x, y, r], i) => { const e = document.createElementNS(NSv, 'path'); e.setAttribute('fill', '#fff6b0'); par.parentNode.insertBefore(e, par.nextSibling); return { x, y, r, ph: i * 2.1, e }; });
      I.pt = { bodyG, rT, dR, ya: 26, yb: 90, rx: 33, d: '', BR, CR, WG, ST, wB, wF, bB, bF }; }
    // Hana: a kid in a 3D bunny suit. The hood is a round squircle body of revolution; her face opening, hair, clip and face ride on its front (with a rolled hood rim) and turn with it;
    // the long bunny ears are rounded 3D blades on top of the hood (pink inside, springy, flop forward with flL / flR), the suit body below is round, the drawstrings hang on its front,
    // the cotton tail sits on her back (wiggles with tw), the legs follow the feet and the hands stay on the sleeve ends
    if (RC.hana && headA) { const NSv = 'http://www.w3.org/2000/svg', sk = headA.q, par = sk.e.parentNode, KH = 0.88, KB = 0.85, HC = 46.1, HA = 31.2, HB = 24.4;
      const rH = y => { const v = Math.abs(y - HC) / HB; return v >= 1 ? 0 : HA * Math.pow(1 - Math.pow(v, 2.6), 1 / 2.6); };
      const rB = y => { const u = clamp((y - 61) / 25, 0, 1); return u >= 1 ? 0 : 20.5 * Math.pow(1 - u * u * u, 1 / 3) * (1 - 0.1 * u); };
      const zAt = (x, y) => { const dx = x - 50, a = rH(y), b = y > 60 ? rB(y) : 0; return Math.max(a > Math.abs(dx) ? KH * Math.sqrt(a * a - dx * dx) : 0, b > Math.abs(dx) ? KB * Math.sqrt(b * b - dx * dx) : 0); };
      I.zE = (dx, dy) => zAt(headA.cx + dx, headA.cy + dy) + 0.3;
      const P0 = (a, rf, pp) => { const e = document.createElementNS(NSv, 'path'); for (const k in a) e.setAttribute(k, a[k]); (pp || par).insertBefore(e, rf || null); return e; }, G0 = (rf, pp) => { const e = document.createElementNS(NSv, 'g'); (pp || par).insertBefore(e, rf || null); return e; };
      const HF = sk.e.getAttribute('fill'), feet = items.filter(q => q.role === 'foot'), LG = []; let bodyQ = null, hair = null, dsE = null;
      items.forEach(q => { const d = q.e.getAttribute('d') || '', st = q.e.getAttribute('stroke') || '';
        if (q.inBody && /^M30 62/.test(d)) { bodyQ = q; q.role = 'bnop'; }
        else if (q.inBody && q.tag === 'rect') { q.role = 'bnop'; const sd = q.cx < 50 ? -1 : 1; LG.push({ e: q.e, sd, ft: feet.find(f => (f.ox < 50) === (sd < 0)) }); }
        else if (q.inBody && /^M32 34|^M68 34|^M33 28|^M67 28/.test(d)) { q.role = 'bnop'; q.e.style.display = 'none'; }
        else if (st === '#ffb3cf') { q.role = 'bnop'; dsE = q.e; }
        else if (q.inBody && q.tag === 'ellipse' && /^url\(#s/.test(q.fill) && q.rx > 15) q.role = 'patch';
        else if (q.inBody && /^url\(#h/.test(q.fill)) { hair = q; q.role = 'patch'; }
        else if (!q.inBody && q.fill === '#7cc8ff') q.role = 'face'; });
      items.filter(q => q.role === 'arm').forEach(a => { const hq = items.find(q => q.inBody && q.tag === 'circle' && /^url\(#s/.test(q.fill) && Math.hypot(q.ox - a.ox, q.oy - a.oy) < 12); if (hq) { hq.role = 'bnop'; a.hnd = hq.e; a.hR = hq.rx; a.e.parentNode.appendChild(hq.e); } });
      const eB = G0(sk.e), eF = G0(null, bodyG), unit = v => { const l = Math.hypot(v[0], v[1], v[2]); return v.map(c => c / l); };
      const EAR = [-1, 1].map(sd => { const g0 = G0(null, eB); return { sd, g: g0, R: [sd * 13.5, 25.2, -1.5], d0: unit([sd * 0.2, -1, -0.06]), sh: P0({ fill: '#8a70b8', opacity: 0 }, null, g0), e: P0({ fill: HF }, null, g0), inr: P0({ fill: '#ffc2d6', opacity: 0.85 }, null, g0) }; });
      const tB = G0(bodyQ ? bodyQ.e : sk.e), tF = G0(bodyQ ? bodyQ.e.nextSibling : sk.e), tdf = document.createElementNS(NSv, 'defs'); par.insertBefore(tdf, par.firstChild); tdf.innerHTML = '<radialGradient id="hnt' + I.u + '" cx="38%" cy="32%" r="70%"><stop offset="0" stop-color="#ffffff"/><stop offset="0.65" stop-color="#fbfaff"/><stop offset="1" stop-color="#ddd5f0"/></radialGradient>'; const tl = P0({ fill: 'url(#hnt' + I.u + ')', stroke: '#d4cbea', 'stroke-width': 0.5 }, null, tB);
      const hp2 = hair ? hair.e.parentNode : par, rf2 = hair ? hair.e.nextSibling : null, rim = P0({ fill: 'none', stroke: '#fbf9ff', 'stroke-width': 2.6, 'stroke-linecap': 'round' }, rf2, hp2), rimS = P0({ fill: 'none', stroke: '#c9bce6', 'stroke-width': 0.8, 'stroke-linecap': 'round', opacity: 0.8 }, rf2, hp2);
      I.hn = { bodyG, rH, rB, KH, KB, zAt, rT: y => Math.max(rH(y), y > 60 ? rB(y) : 0), ya: 22, yb: 86, rx: 31, d: '', body: bodyQ ? bodyQ.e : P0({ fill: HF }, sk.e), EAR, eB, eF, tl, tB, tF, ds: dsE, LG, rim, rimS, FX: 22.1, FY: 48.56, FB: 17.2 }; }
    // Boo: a real 3D sheet ghost. Round body of revolution (dome top, straight sides) with a scalloped hem that runs all the way round, slides past as he turns, ripples and flares
    // when he moves; he floats above the ground and bobs; the nervous drop rides on his front, the gloss stays where the light is; gho fades him out
    if (RC.boo && headA) { const KB = 0.92, Wd = y => y >= 54 ? 32 : y <= 18 ? 0 : 32 * Math.pow(1 - Math.pow((54 - y) / 36, 2.2), 1 / 2.2);
      const zAt = (x, y) => { const w = Wd(Math.min(y, 82)), dx = x - 50; return w > Math.abs(dx) ? KB * Math.sqrt(w * w - dx * dx) : 0; };
      I.zE = (dx, dy) => zAt(headA.cx + dx, headA.cy + dy) + 0.3;
      items.forEach(q => { if (!q.inBody && q.fill === '#a8dcff') q.role = 'face'; else if (!q.inBody && q.tag === 'ellipse' && q.fill.indexOf('#fff') === 0 && q.op) q.role = 'bshine'; });
      I.gb = { bodyG, rT: Wd, Wd, KB, zAt, ya: 18, yb: 82, rx: 32, d: '', art: bodyG.parentNode }; }
    // Pixie: a tiny 3D fairy. Round head with a one-piece 3D bob of hair (covers the back and sides, front/back sorted as she turns) and a hair bun with a flower on top,
    // pointy 3D elf ears, a petal dress (body of revolution with pointed petal hem, seams turn with her, flares when she spins), four see-through wings on her back that buzz all the time
    if (RC.pixie && headA) { const NSv = 'http://www.w3.org/2000/svg', sk = headA.q, par = sk.e.parentNode;
      const P0 = (a, rf, pp) => { const e = document.createElementNS(NSv, 'path'); for (const k in a) e.setAttribute(k, a[k]); (pp || par).insertBefore(e, rf || null); return e; }, G0 = (rf, pp) => { const e = document.createElementNS(NSv, 'g'); (pp || par).insertBefore(e, rf || null); return e; };
      const rD = y => y < 59 ? 0 : y < 66 ? 11 * Math.sqrt(Math.max(0, 1 - Math.pow((66 - y) / 7, 2))) : 11 + 5.5 * H.SM((y - 66) / 15);
      const HR0 = headA.hx, HY0 = headA.cy, zAt = (x, y) => { const dx = x - 50, dy = y - HY0, q = HR0 * HR0 - dx * dx - dy * dy, r = rD(Math.min(y, 82)); return Math.max(q > 0 ? Math.sqrt(q) : 0, r > Math.abs(dx) ? Math.sqrt(r * r - dx * dx) : 0); };
      let dress = null, legs = null, HFill = sk.e.getAttribute('fill'), WF = '#e8f6ff', EF = sk.e.getAttribute('fill'); const hideQ = q => { q.role = 'bnop'; q.e.style.display = 'none'; };
      items.forEach(q => { const d = q.e.getAttribute('d') || '', st = q.e.getAttribute('stroke') || '';
        if (q.inBody && /^url\(#w/.test(q.fill)) { WF = q.fill; hideQ(q); }
        else if (q.inBody && /^M34 66/.test(d)) { dress = q; q.role = 'bnop'; }
        else if (q.inBody && q.tag === 'ellipse' && /^url\(#d/.test(q.fill)) hideQ(q);
        else if (q.inBody && st === '#f6c6b0') { legs = q; q.role = 'bnop'; }
        else if (q.inBody && /^url\(#h/.test(q.fill)) { if (/^M31 40/.test(d)) q.role = 'patch'; else { HFill = q.fill; hideQ(q); } }
        else if (q.inBody && /^M32 47|^M 68 47/.test(d)) { EF = q.fill; hideQ(q); }
        else if (q.inBody && (q.fill === '#fff6a0' || q.fill === '#ffb03a')) hideQ(q);
        else if (!q.inBody && q.tag === 'ellipse' && q.fill.indexOf('#fff') === 0 && q.op) q.role = 'bshine'; });
      const df = document.createElementNS(NSv, 'defs'); par.insertBefore(df, par.firstChild); df.innerHTML = '<radialGradient id="pxh' + I.u + '" gradientUnits="userSpaceOnUse" cx="40" cy="30" r="30"><stop offset="0" stop-color="#ffe2f6"/><stop offset="0.6" stop-color="#ff92d4"/><stop offset="1" stop-color="#d4549e"/></radialGradient>';
      const wgB = G0(par.firstChild), hairB = G0(sk.e), earB = G0(sk.e), ref = sk.e.nextSibling, hairF = G0(ref), earF = G0(ref), bunG = G0(ref), wgF = G0(null, bodyG);
      const HU = 'url(#pxh' + I.u + ')', hB = P0({ fill: HU }, null, hairB), hF = P0({ fill: HU }, null, hairF), hS = P0({ fill: 'none', stroke: '#e468b0', 'stroke-width': 0.6, opacity: 0.7, 'stroke-linecap': 'round' }, null, hairF);
      const EARS = [-1, 1].map(sd => { const g0 = G0(null, earB); return { sd, g: g0, R: [sd * 17.6, 45, -2.5], T: [sd * 29.5, 35.5, -6], e: P0({ fill: EF }, null, g0), ln: P0({ fill: 'none', stroke: '#eba48a', 'stroke-width': 0.8, opacity: 0.8, 'stroke-linecap': 'round' }, null, g0) }; });
      const bun = { e: P0({ fill: HFill }, null, bunG), tw: P0({ fill: 'none', stroke: '#e468b0', 'stroke-width': 0.7, opacity: 0.75, 'stroke-linecap': 'round' }, null, bunG), pe: P0({ fill: '#fff6a0', stroke: '#f2d860', 'stroke-width': 0.3 }, null, bunG), ct: P0({ fill: '#ffb03a' }, null, bunG) };
      const Qb = (a, b, c, s) => (1 - s) * (1 - s) * a + 2 * (1 - s) * s * b + s * s * c, samp = (S, h) => { const o = []; S.forEach(([a, b, c]) => { for (let k = 0; k < 10; k++) { const s = k / 10; o.push([h[0] - Qb(a[0], b[0], c[0], s), Qb(a[1], b[1], c[1], s) - h[1]]); } }); return o; };
      const WLU = samp([[[38, 60], [16, 32], [7, 46]], [[7, 46], [3, 60], [34, 68]], [[34, 68], [36, 64], [38, 60]]], [37, 64]), WLL = samp([[[38, 70], [20, 73], [20, 84]], [[20, 84], [30, 87], [40, 75]], [[40, 75], [39, 72.5], [38, 70]]], [39, 72]);
      const WG = []; [-1, 1].forEach(sd => [[WLU, [sd * 2.5, 63.5, -7.5], 0, [[1, -1], [10, -8], [20, -14], [29, -17]]], [WLL, [sd * 2.5, 71, -7], 1, [[1, 1], [8, 5], [15, 10]]]].forEach(([WL, Hh, lo, VN]) => { const g0 = G0(null, wgB);
        WG.push({ sd, WL, H: Hh, lo, VN, g: g0, e: P0({ fill: WF, opacity: 0.85, stroke: '#b8e0ff', 'stroke-width': 0.8, 'stroke-linejoin': 'round' }, null, g0), vn: P0({ fill: 'none', stroke: '#ffffff', 'stroke-width': 0.6, opacity: 0.75, 'stroke-linecap': 'round' }, null, g0) }); }));
      const seam = dress ? P0({ fill: 'none', stroke: '#3f8a3a', 'stroke-width': 0.6, opacity: 0.55, 'stroke-linecap': 'round' }, dress.e.nextSibling, dress.e.parentNode) : null;
      I.geo.BB = Object.assign({}, I.geo.BB, { x: 30, width: 40 });
      I.px = { bodyG, rT: rD, rD, zAt, ya: 59, yb: 82, rx: 16, d: '', hB, hF, hS, hg: df.firstChild, EARS, bun, WG, wgB, wgF, earB, earF, dress: dress && dress.e, seam, legs: legs && legs.e, feet: items.filter(q => q.role === 'foot') }; }
    // Dreamland batch 2 (Floof, Unibun, Gumdrop, Ember, Drako): the flat art parts are rebuilt as 3D pieces - round tubes/cones (ears, horns, tufts, spikes), balls (gummy ears, tail puffs),
    // hinged flat membranes (wings, tail) and flickering flames - that turn with the body, go behind it when they turn away, trail behind moves on a spring and keep moving on their own
    if (RC.wish) items.forEach(q => { if (!q.inBody && q.tag === 'path' && (q.fill === '#fff6b0' || q.fill === '#ffffff')) q.role = 'wtw'; });
    if (RC.dl && headA) { const NSv = 'http://www.w3.org/2000/svg', sk = headA.q, par = sk.e.parentNode, dOf = q => q.e.getAttribute('d') || '', hideQ = q => { q.role = 'bnop'; q.e.style.display = 'none'; };
      const P0 = (a, pp, rf) => { const e = document.createElementNS(NSv, 'path'); for (const k in a) e.setAttribute(k, a[k]); (pp || par).insertBefore(e, rf || null); return e; }, G0 = (pp, rf) => { const e = document.createElementNS(NSv, 'g'); (pp || par).insertBefore(e, rf || null); return e; };
      const D = I.dl = { key, T: [], F: [], B: [], gB: G0(par, sk.e), gBB: G0(bodyG, bodyG.firstChild), gF: G0(bodyG, null), HF: sk.e.getAttribute('fill'), HX: headA.cx, HY: headA.cy };
      const tube = o => { o.g = G0(D.gB); o.e = P0({ fill: o.fill }, o.g); if (o.inner) o.ie = P0({ fill: o.inner, opacity: 0.85 }, o.g); if (o.groove) o.ge = P0({ fill: 'none', stroke: o.groove, 'stroke-width': 0.6, opacity: 0.85, 'stroke-linecap': 'round' }, o.g); D.T.push(o); return o; };
      const flatP = (qs, o) => { o.qs = qs; o.g = G0(D.gB); qs.forEach(q => { q.role = 'bnop'; q.pts = H.flat(q.segs, 6); o.g.appendChild(q.e); }); D.F.push(o); return o; };
      const ball = o => { o.g = G0(D.gB); o.e = P0({ fill: o.fill }, o.g); if (o.inner) o.ie = P0({ fill: o.inner, opacity: o.iop || 0.7 }, o.g); D.B.push(o); return o; };
      const find = re => items.filter(q => re.test(dOf(q)));
      if (key === 'floof') { items.forEach(q => { if (q.inBody && q.tag === 'ellipse' && /^url\(#fc/.test(q.fill)) q.role = 'patch'; else if (q.inBody && /^M43 31/.test(dOf(q))) hideQ(q); });
        const L = []; for (let i = 0; i < 70; i++) { const y = 1 - 2 * (i + 0.5) / 70, r = Math.sqrt(1 - y * y), a = i * 2.39996; L.push([Math.cos(a) * r, y, Math.sin(a) * r]); }
        D.fur = { e: P0({ fill: D.HF }, par, sk.e.nextSibling), sh: P0({ fill: '#b8c6e6', opacity: 0.5 }, par, sk.e.nextSibling), L }; D.round = [30, 27];
        [[-3, 29.5, 4, -1], [1.5, 28.5, 3.5, 0], [6, 30, 2.5, 1]].forEach(([x, y, z, j]) => tube({ h: 1, fill: D.HF, n: 6, sp: (s, S) => [x + (2.2 + j * 1.4) * s - S.ox * 0.12 * s + Math.sin(S.ts * 2 + j) * 0.5 * s, y - (8 - Math.abs(j)) * s + 2.5 * s * s * (1 + S.cv('fzz')), z + 0.6 * s], w: s => 2.9 * Math.pow(1 - s, 0.8) + 0.1, th: s => 2.4 * Math.pow(1 - s, 0.8) + 0.1 })); }
      if (key === 'unibun') { find(/^M38 30|^M 62 30|^M39 26|^M 61 26/).forEach(hideQ); const hq = find(/^M46.5 28/)[0], HN = hq ? hq.fill : '#ffe0a0'; if (hq) hideQ(hq); items.forEach(q => { if (q.e.getAttribute('stroke') === '#ffffff' && q.inBody) hideQ(q); else if (q.inBody && (q.fill === '#ffb8e0' || q.fill === '#c8b0ff' || q.fill === '#a8e0ff')) q.role = 'patch'; });
        [-1, 1].forEach(sd => tube({ h: 1, fill: D.HF, inner: '#ffc4dc', n: 9, side: sd, sp: (s, S) => { const ev = (sd < 0 ? -S.P.earL : S.P.earR) || 0, a = sd * (0.22 + clamp(ev, -40, 50) * 0.012) + S.ox * 0.03 + Math.sin(S.ts * 1.4 + sd) * 0.04, fl = clamp(S.cv(sd < 0 ? 'flL' : 'flR'), 0, 1.2) - S.oy * 0.02, L = 26;
            return [sd * 8.5 + Math.sin(a) * L * s, 29 - Math.cos(a) * L * s + fl * L * s * s * 0.55, -1 - 0.06 * L * s + fl * L * s * s * 0.9]; }, w: s => 4.6 * Math.sqrt(Math.max(0, 1 - Math.pow((s - 0.45) / 0.58, 2))) + 0.2, th: () => 1.4 }));
        D.horn = tube({ h: 1, fill: HN, groove: '#ffffff', n: 8, sp: (s, S) => [Math.sin(S.ts * 1.1) * 0.3 * s - S.ox * 0.05 * s, 27.5 - 19 * s, 6 + 3 * s], w: s => 3.6 * (1 - s) + 0.15, wk: 'horn' });
        [['#ffb8e0', -2.6, 80, -13], ['#c8b0ff', 2.6, 79.5, -13.4], ['#a8e0ff', 0, 82.6, -12.4]].forEach(([c, x, y, z], i) => ball({ fill: c, c: [50 + x, y, z], r: 3.3, wob: i })); }
      if (key === 'gumdrop') { const ears = items.filter(q => q.inBody && q.tag === 'circle' && q.oy < 30); ears.forEach(hideQ); const pk = ears.find(q => q.fill === '#ff8aa0');
        [-1, 1].forEach(sd => ball({ h: 1, fill: D.HF, inner: '#ff8aa0', iop: 0.7, c: [50 + sd * 20, 24, -3], r: 7.5, ri: 3.5 }));
        items.forEach(q => { if ((q.inBody && q.tag === 'ellipse' && q.fill === '#ffd6dc') || (!q.inBody && q.tag === 'ellipse' && q.fill.indexOf('#fff') === 0 && q.op && q.cy > 55)) { q.role = 'bsurf'; q.bs = { cx: 50, cy: 72, rx: 22, ry: 17, rz: 17 }; } }); D.gum = { y: 0, v: 0, x: 0, vx: 0 }; }
      // Forest Friends (Teddy, Panko, Hoot): the flat ears become round 3D lumps rooted on the head (wiggle with earL/earR, twitch, lag behind moves, turn with him, hide behind his head);
      // Hoot's flat ear tufts become 3D feather wedges; Teddy's bow tie, the bellies, Hoot's belly feathers and Panko's black shoulder band ride on the round body and turn with it
      if (RC.ff) { D.L = []; D.SF = []; const BS = key === 'hoot' ? { cx: 50, cy: 74, rx: 24, ry: 18, rz: 18 } : { cx: 50, cy: 77, rx: 21, ry: 14, rz: 16 };
        const lump = o => { o.g = G0(D.gB); o.e = P0({ fill: o.fill }, o.g); if (o.inner) o.ie = P0({ fill: o.inner, opacity: o.iop || 0.9 }, o.g); D.L.push(o); return o; };
        const surfF = (qs, o) => { o.qs = qs; o.g = G0(D.gB); qs.forEach(q => { q.role = 'bnop'; o.g.appendChild(q.e); }); o.cx = qs[0].cx; o.cy = qs[0].cy; D.SF.push(o); return o; };
        if (key === 'teddy' || key === 'panko' || key === 'leo') { const ears = items.filter(q => q.tag === 'circle' && q.oy < 30 && Math.abs(q.ox - 50) > 15), E0 = ears.find(q => q.inBody), inn = ears.find(q => !q.inBody); ears.forEach(hideQ);
          [-1, 1].forEach(sd => lump({ h: 1, ear: sd, fill: E0 ? E0.fill : D.HF, inner: inn ? inn.fill : null, iop: 0.95, c: [50 + sd * (E0 ? Math.abs(E0.ox - 50) : 24), E0 ? E0.oy : 22, -3], r: E0 ? E0.rx : 10, rn: (E0 ? E0.rx : 10) * 0.5, ri: inn ? inn.rx : 0 })); }
        items.forEach(q => { if (q.inBody && q.tag === 'ellipse' && /^url\(#c/.test(q.fill) && q.oy > 70) { q.role = 'bsurf'; q.bs = BS; }
          else if (key === 'hoot' && q.inBody && q.e.getAttribute('stroke') === '#c9a070') { q.role = 'bsurf'; q.bs = BS; }
        });
        // Panko: the black shoulder band is a real 3D band wrapped all the way round his round body (front and back, like the back picture), lit top-left strip by strip, fabric grain on top
        if (key === 'panko') { const b0 = items.find(q => q.inBody && /^M29 72/.test(dOf(q))); if (b0) { hideQ(b0); const g = G0(b0.e.parentNode, b0.e); D.pb = { F: [] }; for (let k = 0; k < 64; k++) D.pb.F.push(P0({ 'stroke-width': 0.6, 'stroke-linejoin': 'round' }, g)); } }
        // Leo: the flat mane (arc path the rig can't read) is rebuilt as a fluffy 3D ruff of round lobes all round his head (sways, lags, flares with mfl, shakes with msh);
        // the tail is a round 3D tube rooted on his lower back that curls up beside him with a tuft (swishes all the time, tsw swish, lags behind moves)
        if (key === 'leo') { const mg = G0(D.gB, D.gB.firstChild), mf = G0(D.gF), MF = I.leoMF || '#d9762a', L = [];
          // mane layout in the head's own frame: a thick double ring framing the face (just behind it) + a fluffy cap covering the back of the head - so when he turns the ring goes edge-on and the back cap comes round
          for (let i = 0; i < 16; i++) { const a = i / 16 * Math.PI * 2; L.push([Math.cos(a) * 25.5, Math.sin(a) * 25.5, -3, 9.4]); }
          for (let i = 0; i < 14; i++) { const a = (i + 0.5) / 14 * Math.PI * 2; L.push([Math.cos(a) * 23, Math.sin(a) * 23, -11, 9.6]); }
          for (let i = 0; i < 40; i++) { const y = 1 - 2 * (i + 0.5) / 40, r = Math.sqrt(1 - y * y), a = i * 2.39996, d = [Math.cos(a) * r, y, Math.sin(a) * r]; if (d[2] < -0.45) L.push([d[0] * 22, d[1] * 22, d[2] * 22, 9.8]); }
          D.mane = { L, EB: L.map(() => P0({ fill: MF }, mg)), EF: L.map(() => P0({ fill: MF }, mf)), cx: D.HX, cy: D.HY - 1 };
          items.forEach(q => { if (q.inBody && (q.e.getAttribute('stroke') === '#e8a63a' || (q.tag === 'circle' && q.fill === '#b25a1a'))) hideQ(q); });
          const df2 = document.createElementNS(NSv, 'defs'); par.insertBefore(df2, par.firstChild); df2.innerHTML = '<radialGradient id="ltf' + I.u + '" cx="38%" cy="30%" r="75%"><stop offset="0" stop-color="#e8923e"/><stop offset="0.6" stop-color="#b25a1a"/><stop offset="1" stop-color="#7e3c10"/></radialGradient>';
          const TP = [[0, 85, -15.5], [14, 94, -17], [38, 81, -8], [34, 63, -3]];
          const tl = tube({ h: 0, bb: 1, fill: D.HF, n: 12, wk: 'tail', w: s => 2.5 - 0.7 * s, sp: (s, S) => { const u = 1 - s, b = [0, 1, 2].map(j => u * u * u * TP[0][j] + 3 * u * u * s * TP[1][j] + 3 * u * s * s * TP[2][j] + s * s * s * TP[3][j]);
            const a = (Math.sin(S.ts * 1.4) * 0.2 + clamp(S.cv('tsw'), -1.6, 1.6) * 0.55 + clamp(+S.P.wag || 0, -40, 40) * 0.012 + S.ox * 0.03) * s, dx = b[0] - TP[0][0], dz = b[2] - TP[0][2], ca = Math.cos(a), sa = Math.sin(a), wig = Math.sin(S.ts * 3.1 - s * 2) * 1.1 * s * s;
            return [TP[0][0] + dx * ca - dz * sa + wig, b[1] - S.oy * 0.5 * s * s, TP[0][2] + dx * sa + dz * ca]; } });
          D.lt = P0({ fill: 'url(#ltf' + I.u + ')' }, tl.g); D.lt2 = P0({ fill: 'url(#ltf' + I.u + ')' }, tl.g); }
        if (key === 'teddy') { const bw = items.filter(q => !q.inBody && (q.fill === '#f2665a' || q.fill === '#ff8a7a' || q.e.getAttribute('stroke') === '#c4384a'));
          if (bw.length) surfF(bw.sort((a, b) => (a.fill === '#f2665a' ? 0 : a.tag === 'rect' || a.fill === '#ff8a7a' ? 2 : 1) - (b.fill === '#f2665a' ? 0 : b.tag === 'rect' || b.fill === '#ff8a7a' ? 2 : 1)), { h: 0,
            xf: (x, y, S) => { const b = Math.sin(S.ts * 1.6) * 0.05 - S.ox * 0.025 + clamp(S.cv('bow'), -1, 1) * 0.35, dx = x - 50, dy = y - 73, c = Math.cos(b), s = Math.sin(b); return [50 + dx * c - dy * s, 73 + dx * s + dy * c + S.oy * 0.1, 16.5 - dx * dx * 0.012]; } }); }
        if (key === 'hoot') { items.forEach(q => { if (q.inBody && /^M50 30/.test(dOf(q))) q.role = 'patch'; else if (!q.inBody && q.tag === 'path' && q.fill === '#ff9a3c') hideQ(q); });
          // his orange beak is his only mouth (rig mouth hidden): upper beak + lower beak that drops open when he eats, yawns or sings (like Flicker's)
          if (I.faceG) I.emk = { dy: -9.2, in: mk('path', { fill: '#7a2a40', opacity: 0 }, I.faceG), lo: mk('path', { fill: '#e07a1c' }, I.faceG), up: mk('path', { fill: '#ff9a3c', stroke: '#e07a1c', 'stroke-width': 0.45, 'stroke-linejoin': 'round' }, I.faceG), hl: mk('path', { fill: '#fff6e0', opacity: 0.55 }, I.faceG) }; const tf = items.filter(q => q.inBody && /^M(22|78) 34/.test(dOf(q))), TF = tf.length ? tf[0].fill : '#7a5032'; tf.forEach(hideQ);
          [-1, 1].forEach(sd => tube({ h: 1, fill: TF, n: 7, side: sd, sp: (s, S) => { const ev = clamp(sd < 0 ? +S.P.earL || 0 : +S.P.earR || 0, -40, 50), tw = Math.pow(Math.max(0, Math.sin(S.ts * 0.77 + sd * 2.4)), 30) * 0.28,
              a = -sd * (ev * 0.012 + tw) + sd * clamp(S.cv('tfl'), -0.5, 1.2) * 0.35 - S.ox * 0.015 - sd * S.oy * 0.04 + Math.sin(S.ts * 1.2 + sd) * 0.025, ca = Math.cos(a), sa = Math.sin(a), vx = sd * 10, vy = -19.5;
              return [sd * 20 + (vx * ca - vy * sa) * s, 29.5 + (vx * sa + vy * ca) * s, -1 - 2 * s]; }, w: s => 8 * Math.pow(1 - s, 0.9) + 0.25, th: s => 2.6 * (1 - s) + 0.3 })); }
        // Forest batch 3 (Acorn, Fawn, Moss, Sprout). Caps of revolution (Acorn's acorn cap, Moss's mushroom cap, Sprout's leafy hair) are drawn with their real 3D outline
        // (front edge + the two limbs + top) so they turn round with him; spots/dots sit on the round surfaces and slide round/hide; ears, antler nubs, tail, stem and leaves are 3D tubes
        if (key === 'acorn' || key === 'fawn' || key === 'moss' || key === 'sprout') { const TW = Math.PI * 2, F3 = D.f3 = { caps: [], dots: [] }, ffH = I.ffH || {};
          // profile of a body of revolution from quadratic segments [[r, y], ctrl, end]: R(y), arc length S(y) and its inverse Y(s)
          const prof = (SG, dr) => { const pr = []; SG.forEach(([a, b, c]) => { for (let k = 0; k <= 48; k++) { const s = k / 48, u = 1 - s; pr.push([u * u * a[1] + 2 * u * s * b[1] + s * s * c[1], Math.max(0, u * u * a[0] + 2 * u * s * b[0] + s * s * c[0] + dr)]); } });
            pr.sort((a, b) => a[0] - b[0]); const ar = [0]; for (let i = 1; i < pr.length; i++) ar.push(ar[i - 1] + Math.hypot(pr[i][0] - pr[i - 1][0], pr[i][1] - pr[i - 1][1]));
            const ix = (A, j, v) => { if (v <= A(0)) return [0, 0]; for (let i = 1; i < pr.length; i++) if (A(i) >= v) return [i - 1, (v - A(i - 1)) / ((A(i) - A(i - 1)) || 1)]; return [pr.length - 2, 1]; };
            const R = y => { const [i, f] = ix(k => pr[k][0], 0, y); return pr[i][1] + (pr[i + 1][1] - pr[i][1]) * f; };
            R.S = y => { const [i, f] = ix(k => pr[k][0], 0, y); return ar[i] + (ar[i + 1] - ar[i]) * f; }; R.Y = s => { const [i, f] = ix(k => ar[k], 0, s); return pr[i][0] + (pr[i + 1][0] - pr[i][0]) * f; }; R.pts = pr; return R; };
          const cap = (o, ref) => { const pp = ref ? ref.parentNode : par; o.g = G0(pp, ref || sk.e.nextSibling); if (o.band && o.band.behind) o.be = P0({ fill: o.band.fill }, o.g); o.e = P0({ fill: o.fill }, o.g);
            if (o.curves) o.le = P0({ fill: 'none', stroke: o.lines, 'stroke-width': o.lw || 0.8, opacity: o.lo || 0.55, 'stroke-linecap': 'round', 'stroke-linejoin': 'round' }, o.g);
            o.se = (o.spots || []).map(() => P0({ fill: o.spotF }, o.g)); if (o.band && !o.band.behind) o.be = P0({ fill: o.band.fill }, o.g);
            if (o.band && o.band.hl) o.bh = P0({ fill: 'none', stroke: o.band.hl, 'stroke-width': 0.7, opacity: 0.5, 'stroke-linecap': 'round' }, o.g);
            if (o.stem) { o.ste = P0({ fill: 'none', stroke: o.stem.c, 'stroke-width': o.stem.w, 'stroke-linecap': 'round' }, o.g); o.sth = P0({ fill: 'none', stroke: o.stem.hl, 'stroke-width': o.stem.w * 0.32, 'stroke-linecap': 'round', opacity: 0.55 }, o.g); }
            if (o.tuft) o.te = o.tuft.map(() => P0({ fill: o.tuftF }, o.g)); F3.caps.push(o); return o; };
          // art point on the (view-tilted) front of a cap -> local [y, phi]
          const onCap = (R, vt, x, y) => { let yl = y, f = 0; for (let k = 0; k < 6; k++) { const r = Math.max(3, R(yl)); f = Math.asin(clamp((x - 50) / r, -1, 1)); yl = y - vt * r * Math.cos(f); } return [yl, f]; };
          const arcs = d => [...d.matchAll(/M\s*([\d.]+)\s+([\d.]+)\s*a\s*([\d.]+)/g)].map(m => [+m[1] + +m[3], +m[2], +m[3]]);
          // a round dot lying on an ellipsoid E (front sd 1 / back sd -1), drawn in the head (h 1) or body (h 0) frame
          const dot = (E, x, y, r, sd, h, fill, ref) => { const X = (x - E.cx) / E.rx, Y = (y - E.cy) / E.ry, Z = sd * Math.sqrt(Math.max(0.02, 1 - X * X - Y * Y)), L = Math.hypot(X, Y, Z), U = [X / L, Y / L, Z / L];
            let u = [U[2], 0, -U[0]]; const lu = Math.hypot(u[0], u[2]) || 1; u = [u[0] / lu, 0, u[2] / lu]; const v = [U[1] * u[2] - U[2] * u[1], U[2] * u[0] - U[0] * u[2], U[0] * u[1] - U[1] * u[0]], rr = r / ((E.rx + E.ry + E.rz) / 3), pts = [];
            for (let k = 0; k < 14; k++) { const a = k / 14 * TW, p = [0, 1, 2].map(j => U[j] + rr * (Math.cos(a) * u[j] + Math.sin(a) * v[j])), l = Math.hypot(p[0], p[1], p[2]) / 1.012; pts.push([E.cx + E.rx * p[0] / l, E.cy + E.ry * p[1] / l, (E.cz || 0) + E.rz * p[2] / l]); }
            const n = [U[0] / E.rx, U[1] / E.ry, U[2] / E.rz], ln = Math.hypot(n[0], n[1], n[2]); F3.dots.push({ h, pts, c: [E.cx + E.rx * U[0], E.cy + E.ry * U[1], (E.cz || 0) + E.rz * U[2]], n: [n[0] / ln, n[1] / ln, n[2] / ln], e: P0({ fill }, ref.parentNode, ref) }); };
          // flat 3D ear blade rooted behind the head (inner colour on its front face), wiggles with earL/earR, twitches, lags behind moves
          const earT = (sd, o) => tube({ h: 1, fill: o.fill, inner: o.inner, ik: 0.5, io: 0.95, n: o.n || 8, side: sd, sp: (s, S) => { const ev = clamp(sd < 0 ? +S.P.earL || 0 : +S.P.earR || 0, -40, 50), tw = Math.pow(Math.max(0, Math.sin(S.ts * (o.tf || 0.77) + sd * 2.3)), 36) * (o.tk || 0.3),
              a = -sd * (ev * 0.012 + tw) - S.ox * 0.013 - sd * S.oy * 0.035 + Math.sin(S.ts * 1.15 + sd) * 0.03, ca = Math.cos(a), sa = Math.sin(a), vx = sd * o.v[0], vy = o.v[1];
              return [sd * o.r0[0] + (vx * ca - vy * sa) * s, o.r0[1] + (vx * sa + vy * ca) * s, o.r0[2] + (o.dz || 0) * s]; }, w: o.w, th: o.th || (s => 1.4 * (1 - s) + 0.35) });
          if (key === 'acorn') {
            // pointy squirrel ears (pink inside) behind the cap
            const ear = items.filter(q => /^M ?(29|71) 36/.test(dOf(q))), inn = items.filter(q => /^M ?(28\.5|71\.5) 32/.test(dOf(q))), EF = ear.length ? ear[0].fill : D.HF; ear.concat(inn).forEach(hideQ);
            const ew = s => 5.3 * Math.pow(1 - s, 0.8) + 0.4; [-1, 1].forEach(sd => earT(sd, { fill: EF, inner: '#ffc0b0', n: 9, r0: [16.5, 33.5, -3], v: [10.5, -17.5], dz: -1.5, w: ew, th: s => ew(s) * 0.62 }));
            // bushy 3D tail: rooted on his lower back, sweeps out and up behind his right side and curls over at the top (idle sway, tsw swish, tfl flick, wag, lags behind moves)
            const tq = ffH['M62 8'], TF = tq ? tq.fill : D.HF, TP = [[0, 84, -13.5], [34, 89, -17], [43, 17, -15], [17, 24, -12]];
            tube({ h: 0, bb: 1, fill: TF, inner: '#fff0dc', ik: 0.2, io: 0.55, n: 16, wk: 'tail', w: s => 4.4 + 3.8 * Math.sin(Math.PI * Math.min(1, s * 1.08)), sp: (s, S) => { const u = 1 - s, b = [0, 1, 2].map(j => u * u * u * TP[0][j] + 3 * u * u * s * TP[1][j] + 3 * u * s * s * TP[2][j] + s * s * s * TP[3][j]);
              const fl = clamp(S.cv('tfl'), -1, 1.5), a = (Math.sin(S.ts * 1.2) * 0.12 + clamp(S.cv('tsw'), -1.6, 1.6) * 0.5 + clamp(+S.P.wag || 0, -40, 40) * 0.01 + S.ox * 0.03) * s, dx = b[0] - TP[0][0], dz = b[2] - TP[0][2], ca = Math.cos(a), sa = Math.sin(a), wig = Math.sin(S.ts * 2.3 - s * 2.4) * 0.9 * s * s;
              return [TP[0][0] + dx * ca - dz * sa + wig + fl * 5 * s * s, b[1] - S.oy * 0.6 * s * s - fl * 3 * s * s, TP[0][2] + dx * sa + dz * ca]; } });
            const bl = items.find(q => q.inBody && q.tag === 'ellipse' && q.fill === '#fff0dc'); if (bl) { bl.role = 'bsurf'; bl.bs = { cx: 50, cy: 76, rx: 19.3, ry: 14.3, rz: 15 }; }
            // acorn cap: a 3D dome with a crosshatch scale pattern, a rim band round it and a little stem (lifts off and tips with ctp, sways and lags on his head)
            const cq = items.filter(q => q.inBody && (/^url\(#cap/.test(q.fill) || q.e.getAttribute('stroke') === '#7a4e22' || q.fill === '#c8925a' || q.fill === '#6a4220')), c0 = cq.find(q => /^url\(#cap/.test(q.fill));
            const R = prof([[[0, 15.8], [26.2, 15.8], [26.2, 38.4]]], 0.5), CV = []; for (let i = 0; i < 11; i++) [1, -1].forEach(d => CV.push(s => [17.6 + s * 19.4, i / 11 * TW + d * s * 1.05]));
            cap({ h: 1, fill: c0 ? c0.fill : '#a8743a', R, yT: 15.8, ye: () => 38.4, vt: -0.15, pv: [50, 36, 0], curves: CV, lines: '#7a4e22', lw: 0.8, lo: 0.5, band: { fill: '#c8925a', up: 0.9, h: 4.6, bo: 1.1, bb: 0.6, hl: '#e8b47a' }, stem: { c: '#6a4220', hl: '#a87442', w: 2.7 },
              anim: S => { const tp = clamp(S.cv('ctp'), -0.3, 1.3); return { roll: -S.ox * 0.012 + Math.sin(S.ts * 1.4) * 0.015 + tp * 0.32, pit: S.oy * 0.015 - tp * 0.15, lift: tp * 7 + S.oy * 0.15 }; } }, c0 ? c0.e : null);
            cq.forEach(hideQ); }
          if (key === 'fawn') {
            // ears point out to the sides (pink inside), little antler nubs on top - all 3D on the head
            const ear = items.filter(q => /^M ?(30|70) 38/.test(dOf(q))), inn = items.filter(q => /^M ?(29|71) 35/.test(dOf(q))), nub = items.filter(q => /^M ?(41|59) 26/.test(dOf(q))), EF = ear.length ? ear[0].fill : D.HF; ear.concat(inn, nub).forEach(hideQ);
            [-1, 1].forEach(sd => { earT(sd, { fill: EF, inner: '#ffb8c4', n: 9, tf: 0.71, tk: 0.4, r0: [17, 35.5, -5], v: [24.5, -13], dz: 2.5, w: s => (3.3 + 7.2 * s * (1 - s)) * (1 - Math.pow(s, 4)) + 0.35, th: s => 1.3 * (1 - s) + 0.35 });
              tube({ h: 1, fill: '#fff0d8', n: 5, side: sd, sp: (s, S) => [sd * (7 + 2 * s * s) + Math.sin(S.ts * 1.3) * 0.15 * s - S.ox * 0.02 * s, 25.8 - 10.6 * s - S.oy * 0.15 * s, -3 - 1.5 * s], w: s => 2.1 * (1 - s * 0.55) * Math.sqrt(1 - s * s * 0.8) + 0.4 }); });
            // white spots: round dots on his round head and body (front + the back), they turn with him and hide round the far side
            const HE = { cx: D.HX, cy: D.HY, cz: 0, rx: 23.7, ry: 23.7, rz: 23.7 }, BE = { cx: 50, cy: 76, rx: 20.4, ry: 13.4, rz: 16 }, bq = items.find(q => q.inBody && q.tag === 'ellipse' && q.ox === 50 && q.oy === 76), r0 = sk.e.nextSibling, r1 = bq ? bq.e.nextSibling : r0;
            items.filter(q => q.tag === 'path' && q.fill === '#fff6e6' && /a\s*\d/.test(dOf(q))).forEach(q => { const hd = q.cy < 50, E = hd ? HE : BE; arcs(dOf(q)).forEach(([x, y, r]) => [1, -1].forEach(sd => dot(E, sd > 0 ? x : 2 * E.cx - x, y, r, sd, hd ? 1 : 0, '#fff6e6', hd ? r0 : r1))); hideQ(q); }); }
          if (key === 'moss') {
            // red mushroom cap: a 3D dome (seen a touch from above) with its cream gills under the rim, white spots all round (front + back like the art), a moss tuft on top;
            // the cap bounces on his stem with cb, spins with csp, sways and lags behind moves
            const c0 = ffH['M8 46'], gq = items.find(q => q.inBody && q.fill === '#e8d2b0'), sq0 = items.find(q => /^M25 26 a/.test(dOf(q))), tq = items.find(q => /^M60 14/.test(dOf(q)));
            const R = prof([[[0, 10], [42.2, 12], [42.2, 46.2]]], 0.3), vt = 0.19, SPf = []; items.forEach(q => { if (!q.inBody && q.tag === 'ellipse' && q.fill === '#fff' && q.op && q.oy < 40) hideQ(q); });
            if (sq0) { arcs(dOf(sq0)).forEach(([x, y, r]) => { const [yl, f] = onCap(R, vt, x, y); SPf.push({ y: yl, f, r: r * 1.05 }); SPf.push({ y: yl, f: f + Math.PI, r: r * 1.05 }); }); hideQ(sq0); }
            const TU = [[63.5, 13.6, 3.2], [69.5, 11.8, 3.5], [75, 13.8, 2.8]].map(([x, y, r]) => { const [yl, f] = onCap(R, vt, x, y); return { y: yl, f, r, dr: 1.2 }; });
            cap({ h: 1, fill: c0 ? c0.fill : '#f2584c', R, yT: 10, ye: () => 46.2, vt, pv: [50, 40, 0], EN: 40, spots: SPf, spotF: '#fff4e8', tuft: TU, tuftF: tq ? tq.fill : '#7cc04a', band: { fill: gq ? gq.fill : '#e8d2b0', behind: 1, up: 0.5, h: 3.8, bo: -5.2, bb: 0 },
              anim: S => ({ roll: -S.ox * 0.011 + Math.sin(S.ts * 1.25) * 0.02, pit: S.oy * 0.012, lift: clamp(S.cv('cb'), -0.4, 1.5) * 5 + S.oy * 0.25, spin: S.cv('csp') * TW }) }, c0 ? c0.e : null);
            if (gq) hideQ(gq); if (tq) hideQ(tq); }
          if (key === 'sprout') {
            // leafy hair: a 3D cap of leaves hugging the top of his round body (13 pointed leaf tips all round, midribs), turns and squashes with him
            const lq = items.find(q => q.inBody && /^M24 40/.test(dOf(q))), LF = lq ? lq.fill : '#7cc04a'; items.forEach(q => { if (q.inBody && /^url\(#fd/.test(q.fill)) q.role = 'patch'; });
            const R = prof([[[0, 26], [36, 28], [34, 62]]], 0.9), NL = 13, ye = f => 36.6 + 3.3 * Math.pow(1 - Math.abs(Math.sin(NL / 2 * f)), 1.6), CV = [];
            for (let i = 0; i < NL; i++) CV.push(s => [27 + s * 11.6, i / NL * TW]);
            cap({ h: 1, fill: LF, R, yT: 25.1, ye, vt: -0.13, pv: [50, 40, 0], EN: 60, curves: CV, lines: '#3f8a3a', lw: 0.6, lo: 0.45, anim: S => ({ roll: -S.ox * 0.006, pit: S.oy * 0.006, lift: S.oy * 0.1 }) }, lq ? lq.e : null);
            if (lq) hideQ(lq);
            // bark lines ride on the round body (front + back)
            items.filter(q => q.inBody && q.e.getAttribute('stroke') === '#9a6a3a').forEach(q => { q.role = 'bsurf'; q.bs = { cx: 50, cy: 58, rx: 34.6, ry: 32.6, rz: 30, h: 1 }; const e = q.e.cloneNode(); q.e.parentNode.insertBefore(e, q.e); items.push(Object.assign({}, q, { e, bs: Object.assign({}, q.bs, { zs: -1 }) })); });
            // sapling: a round 3D stem growing out of the top (sways on a spring, stw wobble), two leaves on it (flutter, flap with lfl), a flower bud on top that blooms with blm
            items.filter(q => q.inBody && (q.e.getAttribute('stroke') === '#5a8a34' || /^M5[01] 1[39]/.test(dOf(q)) || (q.tag === 'circle' && q.oy < 10))).forEach(hideQ);
            const stemP = (s, S) => { const a = Math.sin(S.ts * 1.3) * 0.07 - S.ox * 0.022 + clamp(S.cv('stw'), -1.4, 1.4) * 0.32, b = Math.sin(S.ts * 0.9 + 1) * 0.12 + S.oy * 0.02, u = 1 - s, x = 2 * u * s * -2.2 + s * s * 1, y = u * u * 29 + 2 * u * s * 18 + s * s * 8.2, dy = y - 29, ca = Math.cos(a * (0.4 + s)), sa = Math.sin(a * (0.4 + s));
              return [x * ca - dy * sa, 29 + x * sa + dy * ca, Math.sin(b) * (29 - y) * 0.5]; };
            tube({ h: 1, fill: '#5a8a34', n: 8, zt: 99, sp: stemP, w: s => 1.1 - 0.3 * s });
            [[0.5, [-14, -8, 2.5], 1], [0.77, [15, -5, -2.5], -1]].forEach(([s0, v, k]) => { const sd = Math.sign(v[0]); tube({ h: 1, fill: LF, inner: '#c8f59a', ik: 0.18, io: 0.6, n: 9, sp: (s, S) => { const b = stemP(s0, S), fl = clamp(S.cv('lfl'), -0.9, 1.4), a = -sd * (fl * 0.5 + Math.sin(S.ts * 2.4 + k) * 0.06 + Math.sin(S.ts * 7.3 + k) * 0.025 * (1 + fl)) - S.ox * 0.01, ca = Math.cos(a), sa = Math.sin(a);
              const px = v[0] * s, py = v[1] * s - Math.sin(Math.PI * s) * 2.2; return [b[0] + px * ca - py * sa, b[1] + px * sa + py * ca, b[2] + v[2] * s]; }, w: s => 3.3 * Math.pow(Math.sin(Math.PI * Math.min(1, s * 0.96 + 0.04)), 0.85) + 0.15, th: () => 0.5 }); });
            const fg = G0(D.gF); F3.fl = { sp: stemP, pe: [0, 1, 2, 3, 4].map(() => P0({ fill: '#ffb6d4', stroke: '#f28ab8', 'stroke-width': 0.3 }, fg)), ce: P0({ fill: '#ffe14a' }, fg) }; } }
      }
      // Ember: a phoenix chick. Only his beak is his mouth (rig mouth hidden in the face update). The flat crest, tail plumes and chest fluff are rebuilt: 3 crest plumes (thin quills ending in teardrop feathers, gold tips, sway, flicker and flare with cfl),
      // 3 long phoenix tail plumes from his lower back sweeping up and out to the side with curled teardrop tips + red eye-spots (trail behind moves, sway, flare with cfl, turn with him),
      // cream chest fluff rides on the round front; wings are his arms (flutter with wfl/wsp in the pre-update); fire glow pulses behind him
      if (key === 'ember') { items.forEach(q => { const st = q.e.getAttribute('stroke'); if (/^url\(#bk/.test(q.fill)) hideQ(q); else if (q.inBody && (st === '#f0582a' || /^url\(#pl/.test(q.fill) || q.fill === '#d8342a')) hideQ(q); else if (q.inBody && q.fill === '#fff0c4') { q.role = 'bsurf'; q.bs = { cx: 50, cy: 58, rx: 29, ry: 29, rz: 29 }; } });
        const df = document.createElementNS(NSv, 'defs'); par.insertBefore(df, par.firstChild); df.innerHTML = '<radialGradient id="emg' + I.u + '"><stop offset="0.45" stop-color="#ffb347" stop-opacity="0.5"/><stop offset="1" stop-color="#ff7a1a" stop-opacity="0"/></radialGradient>'
          + '<linearGradient id="emp' + I.u + '" x1="0" y1="0" x2="0" y2="1"><stop offset="0" stop-color="#fff2a0"/><stop offset="0.3" stop-color="#ffc23a"/><stop offset="0.72" stop-color="#ff7a2a"/><stop offset="1" stop-color="#e0402a"/></linearGradient>';
        D.glow = P0({ fill: 'url(#emg' + I.u + ')' }, D.gB); { const fxB = G0(root, art), fxF = G0(root, null), L3 = g => [P0({ fill: '#ff3a12', opacity: 0.8 }, g), P0({ fill: '#ff9a22', opacity: 0.92 }, g), P0({ fill: '#fff1a0', opacity: 0.95 }, g)], gB = P0({ fill: 'url(#emg' + I.u + ')', opacity: 0 }, fxB), ring = P0({ fill: 'none', stroke: '#ffb03a', 'stroke-width': 1.6, opacity: 0 }, fxB), gF = P0({ fill: 'url(#emg' + I.u + ')', opacity: 0 }, fxF); D.ff = { B: L3(fxB), F: L3(fxF), gB, gF, ring }; } if (I.faceG) I.emk = { in: mk('path', { fill: '#7a2a40', opacity: 0 }, I.faceG), lo: mk('path', { fill: '#f08a1e' }, I.faceG), up: mk('path', { fill: '#ffc04a' }, I.faceG), hl: mk('path', { fill: '#fff6e0', opacity: 0.55 }, I.faceG) }; const PF = 'url(#emp' + I.u + ')', bump = (s, a) => s < a ? 0 : Math.pow(Math.sin(Math.PI * (s - a) / (1 - a)), 0.7);
        [-1, 0, 1].forEach(k => { const wf = s => 0.6 + 2.9 * bump(s, 0.5); tube({ h: 1, fill: PF, inner: '#fff6c0', n: 12, zt: -1, flame: k + 2, w: wf, th: s => wf(s) * 0.5, sp: (s, S) => { const fl = clamp(S.cv('cfl'), 0, 1.5), L = (k ? 14 : 18.5) * (1 + 0.07 * Math.sin(S.ts * 9 + k * 2) + fl * 0.22), a = k * (0.62 + fl * 0.15) + Math.sin(S.ts * 2.6 + k * 1.4) * 0.07 - S.ox * 0.02 * s, cu = (k || 0.6) * 2.2 * s * s;
          return [k * 3.5 + Math.sin(a) * L * s + cu, 30.5 - Math.cos(a) * L * s + S.oy * 0.3 * s * s + 1.2 * s * s, 3 + 1.5 * s + (k ? 0 : 2.5 * s * s)]; } }); });
        [[22, 27, 9, 0.2], [29, 35, 12, 1.4], [33, 19, 7, 2.6]].forEach(([tx, ty, tz, ph]) => { const wf = s => 0.8 + 4 * bump(s, 0.5); tube({ fill: PF, inner: '#fff6c0', n: 14, flame: 4 + ph, w: wf, th: s => wf(s) * 0.42, eye: '#d8342a', eyeS: 0.8, sp: (s, S) => { const fl = clamp(S.cv('cfl'), 0, 1.5), g = 1 + fl * 0.15 + 0.04 * Math.sin(S.ts * 7 + ph), q = Math.max(0, (s - 0.72) / 0.28);
          return [6 + tx * g * s - S.ox * 0.35 * s * s + Math.sin(S.ts * 1.9 + ph) * 1.4 * s * s, 80 - ty * g * (2 * s - s * s) + 4 * q * q + S.oy * 0.45 * s + Math.sin(S.ts * 2.4 + ph) * s * s, -20 - tz * s + 3 * q * q]; } }); }); }
      // Jinni: a tiny genie. Puffy 3D turban (a dome of revolution tilted back on his head, wrap folds lying on it, ruby jewel, swaying feather plume), pointy 3D ears that flick,
      // gold drop earrings that dangle; the golden lamp, the smoky wisp tail, the lamp glow, puffs and sparkles are made here and drawn in the update (I.gn)
      if (key === 'jinni') { const fOf = re => (items.find(q => re.test(q.fill || '')) || {}).fill, AU = fOf(/^url\(#au_/) || '#ffcf4a', RB = fOf(/^url\(#rb_/) || '#ff3a6a', TB = fOf(/^url\(#tb_/) || '#b48af2', WP = fOf(/^url\(#wp_/) || D.HF, TK = 0.16;
        const tw = s => s < 0.25 ? 18.9 + 1.3 * Math.sin(s / 0.25 * Math.PI / 2) : 20.2 * Math.sqrt(Math.max(0, 1 - Math.pow((s - 0.25) / 0.75, 2))) + 0.1;
        const tsp = (s, S) => [Math.sin(S.ts * 1.3) * 0.3 * s, 28.6 - 19.6 * s, -19.6 * s * TK];
        const tS = (a, s, dr, S) => { const c = tsp(s, S), r = tw(s) + dr, z = Math.cos(a) * r; return [c[0] + Math.sin(a) * r, c[1] - TK * z, c[2] + z]; };
        tube({ h: 1, fill: TB, n: 12, zt: -99, sp: tsp, w: tw });
        [[-1.75, 0.05, 1.75, 0.42], [-1.75, 0.46, 1.75, 0.08]].forEach(([a0, s0, a1, s1]) => { for (let j = 0; j < 4; j++) { const u0 = j / 4, u1 = (j + 1) / 4; tube({ h: 1, fill: '#9466e0', n: 5, sp: (s, S) => { const u = u0 + (u1 - u0) * s; return tS(a0 + (a1 - a0) * u, s0 + (s1 - s0) * u, 0.25, S); }, w: () => 1.2, th: () => 0.55 }); } });
        tube({ h: 1, fill: '#f6efff', inner: '#d8c6ff', n: 10, sp: (s, S) => { const b = tS(0, 0.22, 0.6, S), sw = Math.sin(S.ts * 2.1) * 1.4 * s * s - S.ox * 0.22 * s * s; return [b[0] + 2.4 * s + sw, b[1] - 15.5 * s + S.oy * 0.35 * s * s, b[2] - 4.5 * s * s]; }, w: s => 0.4 + 3.1 * Math.sin(Math.PI * Math.pow(s, 0.75)), th: s => 0.3 + 0.8 * Math.sin(Math.PI * Math.pow(s, 0.75)) });
        [-1, 1].forEach(sd => tube({ h: 1, fill: D.HF, inner: '#3cae9c', n: 7, sp: (s, S) => { const ev = clamp(sd < 0 ? -(+S.P.earL || 0) : (+S.P.earR || 0), -40, 50) * 0.09 + Math.sin(S.ts * 1.6 + sd) * 0.35 - S.oy * 0.25; return [sd * (19 + 9.6 * s) - S.ox * 0.12 * s, 37.6 - (7.4 + ev) * s - 1.4 * s * s, -1.6 - 2.4 * s]; }, w: s => 3.5 * Math.pow(1 - s, 0.85) + 0.15, th: s => 1.3 * (1 - s) + 0.25 }));
        const j0 = tS(0, 0.15, 1.7, { ts: 0 }); ball({ h: 1, fill: AU, inner: RB, iop: 1, c: [50 + j0[0], j0[1], j0[2]], r: 3, ri: 1.9 });
        [-1, 1].forEach(sd => ball({ h: 1, fill: AU, c: [50 + sd * 20.3, 43.4, -0.8], r: 1.6, wob: sd > 0 ? 1 : 0 }));
        const gd = document.createElementNS(NSv, 'defs'); root.insertBefore(gd, root.firstChild);
        gd.innerHTML = '<radialGradient id="gng' + I.u + '"><stop offset="0" stop-color="#fff8d0" stop-opacity="0.95"/><stop offset="0.4" stop-color="#ffd84a" stop-opacity="0.4"/><stop offset="1" stop-color="#ffb020" stop-opacity="0"/></radialGradient>';
        const lG = G0(root, art), tG = G0(bodyG, bodyG.firstChild), fG = G0(root, null), GL = 'url(#gng' + I.u + ')';
        const N = I.gn = { art, glow: P0({ fill: GL, opacity: 0.4 }, lG), L: {}, tail: P0({ fill: WP }, tG), thl: P0({ fill: '#ffffff', opacity: 0.2 }, tG), tsw: P0({ fill: 'none', stroke: '#f2fffb', 'stroke-width': 0.6, 'stroke-linecap': 'round', opacity: 0.55 }, tG),
          fgl: P0({ fill: GL, opacity: 0 }, fG), pf: P0({ fill: '#effffa', opacity: 0 }, fG), spk: P0({ fill: '#fff6c8' }, fG) };
        ['foot', 'belly', 'spout', 'handle', 'lid', 'knob', 'gem'].forEach(k => { N.L[k] = P0({ fill: k === 'gem' ? RB : AU }, lG); }); N.shine = P0({ fill: '#ffffff', opacity: 0.55 }, lG); }
      // Drako (remodel v2): a chubby baby dragon. Every flat part is rebuilt in 3D and rides on the round body: curled cream horns with ridges, purple ear fins that flick,
      // a row of purple spikes from the crown down his back, real bat wings hinged on his back (membrane + finger bones, always fluttering, flap with wfl, spread with wsp, rise with his arms,
      // flap when he moves, fold when asleep, membrane shades as it turns), a thick round tail lying on the ground that curls up into a spade (swishes all the time, tsw swish, tcu curl up, lags on moves, tail spikes ride on it)
      if (key === 'drako') { items.forEach(q => { const d = dOf(q), st = q.e.getAttribute('stroke'); if (q.inBody && (/^M29 49|^M 71 49|^M62 80|^M88 68|^M25 34|^M 75 34|^M44 23|^M37 25.5|^M 63 25.5/.test(d) || st === '#7a50d8')) { q.dk = /^M37 25.5|^M 63 25.5/.test(d) ? 'hn' : /^M29 49|^M 71 49/.test(d) ? 'wg' : 0; hideQ(q); }
          else if (q.inBody && (q.fill === '#fff4cc' || st === '#e6d29a')) { q.role = 'bsurf'; q.bs = { cx: 50, cy: 55, rx: 31.5, ry: 34, rz: 28, h: 1 }; } });
        const HN = (items.find(q => q.dk === 'hn') || {}).fill || '#f6e2a8', WGF = (items.find(q => q.dk === 'wg') || {}).fill || '#b090ff', SPK = '#a582f6';
        D.tk = { a: 0, cu: 0, tw: 0, ly: 0 }; const sub3 = (a, b) => [a[0] - b[0], a[1] - b[1], a[2] - b[2]], nr3 = v => { const l = Math.hypot(v[0], v[1], v[2]) || 1; return [v[0] / l, v[1] / l, v[2] / l]; };
        // horns: rooted on top of his head, rise and curl back, ridged
        [-1, 1].forEach(sd => tube({ h: 1, fill: HN, groove: '#d2b06a', n: 9, zt: -2, sp: (s, S) => [sd * (9 + 3.2 * s - 1.4 * s * s) + Math.sin(S.ts * 1.3) * 0.15 * s, 25.5 - 15 * s + S.oy * 0.12 * s * s, 4 - 8.5 * s * s], w: s => 2.9 * Math.pow(1 - s, 0.85) + 0.3 }));
        // ear fins: flat purple blades at the sides of his head, flick and trail behind moves
        [-1, 1].forEach(sd => tube({ h: 1, fill: '#c6adff', inner: '#f1e8ff', n: 7, zt: -1, nf: [0, 0, 1], sp: (s, S) => { const ev = (sd < 0 ? -S.P.earL : S.P.earR) || 0, tw = Math.pow(Math.max(0, Math.sin(S.ts * 0.9 + sd * 1.7)), 24) * 0.35,
            a = clamp(ev, -40, 50) * 0.012 + Math.sin(S.ts * 1.6 + sd) * 0.07 + tw - S.ox * 0.025 * sd - S.oy * 0.02, c = Math.cos(a), sn = Math.sin(a), ux = 9.5 * c + 11 * sn, uy = -11 * c + 9.5 * sn;
            return [sd * (24 + ux * s), 31.5 + uy * s, -1 - 4 * s]; }, w: s => 2.8 * Math.pow(1 - s, 0.8) + 0.15, th: () => 0.75 }));
        // back spikes: crown to lower back on the round body, ripple a little
        [[-0.2, 5.2], [0.2, 6.3], [0.6, 5.8], [1.0, 5.2], [1.4, 4.6], [1.8, 4], [2.2, 3.3]].forEach(([a, Ls], i) => { const ca = Math.cos(a), sa = Math.sin(a), R = [0, 55 - 33 * ca, -27 * sa], N0 = nr3([0, -ca * 0.82, -sa]), N = nr3([0, N0[1] - 0.75, N0[2]]), Tg = nr3([0, sa * 0.82, -ca]);
          tube({ h: 1, fill: SPK, n: 4, zt: a < 0 ? -4 : 0, nf: [1, 0, 0], sp: (s, S) => { const L2 = Ls * (1 + 0.06 * Math.sin(S.ts * 3 - i * 0.8)), b = -1.4 + L2 * s; return [Math.sin(S.ts * 2.2 - i) * 0.3 * s - S.ox * 0.04 * s, R[1] + N[1] * b + Tg[1] * L2 * 0.32 * s * s, R[2] + N[2] * b + Tg[2] * L2 * 0.32 * s * s]; },
            w: s => Ls * 0.44 * (1 - s) + 0.12, th: s => Ls * 0.32 * (1 - s) + 0.12 }); });
        // tail: cubic from the lower back along the ground, curling up at the end; swish / curl / tip wag / lag come from D.tk (set every frame)
        const TB = [[6, 79, -16], [24, 92, -30], [38, 89, -20], [38, 64, -14]], bz = s => { const u = 1 - s; return [0, 1, 2].map(k => u * u * u * TB[0][k] + 3 * u * u * s * TB[1][k] + 3 * u * s * s * TB[2][k] + s * s * s * TB[3][k]); };
        const tailAt = s => { const k = D.tk, p = bz(s); let x = p[0] - TB[0][0], y = p[1] - TB[0][1], z = p[2] - TB[0][2]; y -= k.cu * 17 * Math.pow(s, 1.6); z += k.cu * 3 * s * s; x += k.cu * 4 * s * s; y += k.ly * s - k.tw * 5 * s * s * s;
          const a = k.a * (0.35 + 0.65 * s), c = Math.cos(a), sn = Math.sin(a); return [TB[0][0] + x * c + z * sn, TB[0][1] + y, TB[0][2] - x * sn + z * c]; };
        D.tailAt = tailAt; const tailW = s => 5.3 * (1 - s) + 1.5;
        tube({ h: 1, bb: 1, fill: D.HF, n: 14, zt: -1, sp: s => tailAt(s), w: tailW });
        [0.36, 0.56, 0.74].forEach((s0, i) => { const Ls = 3.4 - i * 0.55; tube({ h: 1, bb: 1, fill: SPK, n: 3, zt: -1, nf: [0, 0, 1], sp: s => { const c = tailAt(s0), T = nr3(sub3(tailAt(s0 + 0.02), tailAt(s0 - 0.02))), dd = -T[1], up = nr3([T[0] * dd, -1 + T[1] * dd, T[2] * dd]), b = tailW(s0) * 0.72 + Ls * s;
            return [c[0] + up[0] * b + T[0] * Ls * 0.3 * s, c[1] + up[1] * b + T[1] * Ls * 0.3 * s, c[2] + up[2] * b + T[2] * Ls * 0.3 * s]; }, w: s => Ls * 0.4 * (1 - s) + 0.1, th: s => Ls * 0.25 * (1 - s) + 0.1 }); });
        const sw = u => u < 0.38 ? 1.3 + 4.3 * u / 0.38 : 5.6 * Math.pow((1 - u) / 0.62, 1.15) + 0.12;
        tube({ h: 1, bb: 1, fill: WGF, n: 8, zt: -1, nf: [0, 0, 1], wk: 'tail', sp: u => { const e = tailAt(1), T = nr3(sub3(e, tailAt(0.96))); return [e[0] + T[0] * 8.5 * u, e[1] + T[1] * 8.5 * u, e[2] + T[2] * 8.5 * u]; }, w: sw, th: u => 0.55 + sw(u) * 0.12 });
        // bat wings: outline + bones in art coords (left wing), hinge on the upper back; mirrored for the right wing
        const QS = (a, b, c, n) => { const o = []; for (let i = 1; i <= n; i++) { const s = i / n, u = 1 - s; o.push([u * u * a[0] + 2 * u * s * b[0] + s * s * c[0], u * u * a[1] + 2 * u * s * b[1] + s * s * c[1]]); } return o; };
        const OL = [[37, 45.5], [30, 48.4]].concat(QS([30, 48.4], [20, 39], [6, 31], 8), QS([6, 31], [8.5, 39], [10.5, 43], 4), QS([10.5, 43], [7, 47], [8, 52], 4), QS([8, 52], [12, 51.5], [15.5, 54.5], 4), QS([15.5, 54.5], [14, 59], [16, 62.5], 4), QS([16, 62.5], [21, 59.5], [27, 61], 4), [[37, 56.5]]);
        const toL = p => [(37 - p[0]) * 1.06, p[1] - 47], BN = [[[33, 47.5], [10.5, 43]], [[33, 48.6], [15.5, 54.5]], [[33, 50], [16, 62.5]]].map(b => b.map(toL)), ARM = [[31, 48]].concat(QS([31, 48], [20, 39], [6, 31], 6)).map(toL);
        D.gW = G0(bodyG, bodyG.firstChild); D.WG = [-1, 1].map(sd => { const g = G0(D.gW), o = { sd, h: 1, zt: 0, g, L: OL.map(toL), BN, ARM, hz: -21.5 }; o.m = P0({ fill: WGF }, g); o.sh = P0({ fill: '#3a1a7a', opacity: 0 }, g); o.hl = P0({ fill: '#ffffff', opacity: 0 }, g);
          o.bn = P0({ fill: 'none', stroke: '#7a50d8', 'stroke-width': 0.8, opacity: 0.75, 'stroke-linecap': 'round' }, g); o.ab = P0({ fill: 'none', stroke: '#8a62e6', 'stroke-width': 1.7, 'stroke-linecap': 'round', 'stroke-linejoin': 'round' }, g); return o; });
        D.smoke = items.filter(q => !q.inBody && q.fill === '#eef0f8'); D.smoke.forEach(q => { q.role = 'bnop'; }); }
      I.geo.BB = Object.assign({}, I.geo.BB); }
    // Tutti: a fruit-basket fairy. Her round head sits in a real 3D wicker basket (body of revolution with woven bands and slats that slide round as she turns, a twisted rim on top);
    // a cherry and a pear ride in the basket (bounce, get tossed with fL/fR), her fruit crown (2 cupped leaves, cherries on stems, an orange-slice disc) sits on her head, see-through fairy wings flutter behind her
    if (RC.tutti && headA) { const Qb = (a, b, c, s) => (1 - s) * (1 - s) * a + 2 * (1 - s) * s * b + s * s * c, U = '_g' + I.u, HR0 = headA.hx, HY0 = headA.cy, KB = 0.8;
      const rB = y => { const u = clamp((y - 62) / 29, 0, 1); return (33 - 6.5 * u) * Math.pow(Math.max(0, 1 - Math.pow(u, 6)), 1 / 6); };
      const zAt = (x, y) => { const dx = x - 50, dy = y - HY0, q = HR0 * HR0 - dx * dx - dy * dy, rb = y >= 60 && y <= 91 ? rB(y) : 0; return Math.max(q > 0 ? Math.sqrt(q) : 0, rb > Math.abs(dx) ? KB * Math.sqrt(rb * rb - dx * dx) : 0); };
      const sk = headA.q, par = sk.e.parentNode, ref = sk.e.nextSibling, NSv = 'http://www.w3.org/2000/svg', P0 = (a, rf, pp) => { const e = document.createElementNS(NSv, 'path'); for (const k in a) e.setAttribute(k, a[k]); (pp || par).insertBefore(e, rf || null); return e; };
      const G0 = (rf, pp) => { const e = document.createElementNS(NSv, 'g'); (pp || par).insertBefore(e, rf || null); return e; };
      const wgB = G0(sk.e), crB = G0(sk.e), frB = G0(sk.e), crF = G0(ref), frF = G0(ref), bkG = G0(ref), wgF = G0(ref), df = document.createElementNS(NSv, 'defs'); par.insertBefore(df, wgB);
      df.innerHTML = '<linearGradient id="tub' + I.u + '" gradientUnits="userSpaceOnUse" x1="17" y1="0" x2="83" y2="0"><stop offset="0" stop-color="#6a3c14" stop-opacity="0.5"/><stop offset="0.16" stop-color="#8a5422" stop-opacity="0.16"/><stop offset="0.32" stop-color="#fff1d0" stop-opacity="0.36"/><stop offset="0.46" stop-color="#ffffff" stop-opacity="0"/><stop offset="0.74" stop-color="#6a3c14" stop-opacity="0.08"/><stop offset="1" stop-color="#5a3210" stop-opacity="0.55"/></linearGradient>';
      const bask = { body: P0({ fill: 'url(#b' + U + ')' }, null, bkG), sh: P0({ fill: 'url(#tub' + I.u + ')' }, null, bkG), wv: P0({ fill: 'none', stroke: '#a86a2a', 'stroke-width': 0.9, opacity: 0.6, 'stroke-linecap': 'round', 'stroke-linejoin': 'round' }, null, bkG),
        rim: P0({ fill: '#efb470', stroke: '#c88a4a', 'stroke-width': 0.4, 'stroke-linejoin': 'round' }, null, bkG), tw: P0({ fill: 'none', stroke: '#c88a4a', 'stroke-width': 0.6, opacity: 0.75, 'stroke-linecap': 'round' }, null, bkG), hl: P0({ fill: 'none', stroke: '#ffe2b0', 'stroke-width': 0.8, opacity: 0.8, 'stroke-linecap': 'round' }, null, bkG), gr: df.querySelector('#tub' + I.u) };
      const WO = [[34, 42]]; [[[34, 42], [12, 18], [6, 34], 10], [[6, 34], [4, 50], [31, 52], 8]].forEach(([a, b, c, n]) => { for (let k = 1; k <= n; k++) { const s = k / n; WO.push([Qb(a[0], b[0], c[0], s), Qb(a[1], b[1], c[1], s)]); } });
      const WL = WO.map(([x, y]) => [32.5 - x, y - 47]);
      const WG = [-1, 1].map(sd => { const g0 = G0(null, wgB); return { sd, g: g0, e: P0({ fill: 'url(#w' + U + ')', opacity: 0.85, stroke: '#b8dcf8', 'stroke-width': 0.8, 'stroke-linejoin': 'round' }, null, g0), vn: P0({ fill: 'none', stroke: '#ffffff', 'stroke-width': 0.6, opacity: 0.75, 'stroke-linecap': 'round' }, null, g0) }; });
      const LV = [-1, 1].map(sd => { const g0 = G0(null, crF), lf = { stroke: '#3a8a3a', 'stroke-width': 0.3, 'stroke-linejoin': 'round' }; return { sd, az: sd * Math.PI / 2, el: -0.1, L: 17, W: 4.4, ph: sd > 0 ? 1.3 : 0, g: g0, hU: P0(lf, null, g0), hD: P0(lf, null, g0), rib: P0({ fill: 'none', stroke: '#d4f5b0', 'stroke-width': 0.55, opacity: 0.6, 'stroke-linecap': 'round' }, null, g0) }; });
      const cg = G0(null, crF), stm = P0({ fill: 'none', stroke: '#5a8a34', 'stroke-width': 1.1, 'stroke-linecap': 'round' }, null, cg), CH = [[-10, 22, 2], [-3, 23, 3.5]].map(([x, y, z]) => ({ x, y, z, r: 4, e: P0({ fill: 'url(#ch' + U + ')' }, null, cg), gl: P0({ fill: '#ffffff', opacity: 0.6 }, null, cg) }));
      const og = G0(null, crF), OR = { g: og, c: [10, 22, 1], r: 6, th: 2.4, edge: P0({ fill: '#e8901e' }, null, og), rind: P0({ fill: '#ffad3a' }, null, og), fl: P0({ fill: '#ffd67a' }, null, og), sg: P0({ fill: 'none', stroke: '#ffad3a', 'stroke-width': 0.6, 'stroke-linecap': 'round' }, null, og), gl: P0({ fill: '#ffffff', opacity: 0.45 }, null, og) };
      const FR = [[-25, 56, 6.5, 'ch', 1], [25, 57, 6, 'pr', -1]].map(([x, y, r, gid, sd]) => { const g0 = G0(null, frF); return { x, y, r, sd, g: g0, e: P0({ fill: 'url(#' + gid + U + ')' }, null, g0), gl: P0({ fill: '#ffffff', opacity: 0.55 }, null, g0), st: P0({ fill: 'none', stroke: '#6a4a2a', 'stroke-width': 1, 'stroke-linecap': 'round' }, null, g0) }; });
      I.tu = { bodyG, rT: rB, rB, KB, zAt, ya: 60, yb: 90, rx: 33, WL, WG, LV, cg, stm, CH, OR, FR, bask, wgB, wgF, crB, crF, frB, frF }; }
    // Melo: a real 3D watermelon slice - a thick slab cut from the art outline with a rounded bevelled rind edge and pillowy flesh on both faces (I.zE puts the face on the front flesh);
    // the white rind + flesh are rebuilt on whichever face looks at you, the seeds sit in the flesh (jiggle with sdj), the dark rind stripes wrap over the edge round the slab
    if (RC.melo && headA) { const Qb = (a, b, c, s) => (1 - s) * (1 - s) * a + 2 * (1 - s) * s * b + s * s * c, Dh = 7, DM = 2.4, bv = 3, OL = [];
      const qd = (a, b, c, n) => { for (let k = 0; k < n; k++) { const s = k / n; OL.push([Qb(a[0], b[0], c[0], s), Qb(a[1], b[1], c[1], s)]); } };
      qd([10, 36], [50, 30], [90, 36], 16); qd([90, 36], [92, 84], [50, 92], 24); qd([50, 92], [8, 84], [10, 36], 24);
      const NO = OL.map((p, i) => { const a = OL[(i + OL.length - 1) % OL.length], b = OL[(i + 1) % OL.length], tx = b[0] - a[0], ty = b[1] - a[1], l = Math.hypot(tx, ty) || 1; return [ty / l, -tx / l]; });
      const wT = i => i <= 16 ? Math.pow(Math.sin(Math.PI * i / 16), 0.35) : 0, ol = (ins, iT) => OL.map((p, i) => { const k = iT == null ? ins : ins + (iT - ins) * wT(i); return [p[0] - NO[i][0] * k, p[1] - NO[i][1] * k]; }), q = (x, y) => clamp(1 - ((x - 50) / 37) * ((x - 50) / 37) - ((y - 63) / 28) * ((y - 63) / 28), 0, 1), zF = (x, y) => Dh + DM * q(x, y);
      const hw = y => { let m = 0; for (let i = 0; i < OL.length; i++) { const a = OL[i], b = OL[(i + 1) % OL.length]; if ((y - a[1]) * (y - b[1]) <= 0 && a[1] !== b[1]) m = Math.max(m, Math.abs(a[0] + (b[0] - a[0]) * (y - a[1]) / (b[1] - a[1]) - 50)); } return m; };
      const HX0 = headA.cx, HY0 = headA.cy; I.zE = (dx, dy) => zF(HX0 + dx, HY0 + dy) + 0.6;
      const sk = headA.q, par = sk.e.parentNode, ref = sk.e.nextSibling, ud = I.u, NSv = 'http://www.w3.org/2000/svg', P0 = (a, rf, pp) => { const e = document.createElementNS(NSv, 'path'); for (const k in a) e.setAttribute(k, a[k]); (pp || par).insertBefore(e, rf || null); return e; };
      const fq = items.find(q0 => q0.inBody && /^url\(#g_/.test(q0.fill));
      mk('defs', {}, art).innerHTML = '<linearGradient id="mlt' + ud + '" x1="0" y1="0" x2="1" y2="0"><stop offset="0" stop-color="#e83c5c"/><stop offset="0.35" stop-color="#ff8fa3"/><stop offset="0.7" stop-color="#ff6a82"/><stop offset="1" stop-color="#d8324f"/></linearGradient><radialGradient id="mlr' + ud + '" cx="35%" cy="25%" r="85%"><stop offset="0" stop-color="#b4f09a"/><stop offset="0.55" stop-color="#62bf52"/><stop offset="1" stop-color="#358a32"/></radialGradient>';
      const rf = P0({ fill: 'url(#mlr' + ud + ')' }, ref), tp = P0({ fill: 'url(#mlt' + ud + ')' }, rf), tsd = P0({ fill: '#3a2340', opacity: 0.85 }, rf), str = P0({ fill: 'none', stroke: '#2f7a2a', 'stroke-width': 1.5, opacity: 0.6, 'stroke-linecap': 'round', 'stroke-linejoin': 'round' }, ref), wr = P0({ fill: '#f6ffe8' }, ref), fl = P0({ fill: fq ? fq.e.getAttribute('fill') : '#ff6a82' }, ref), sd = P0({ fill: '#3a2340' }, ref), sdh = P0({ fill: '#fff', opacity: 0.6 }, ref);
      const SI = [21, 26, 31, 36, 44, 49, 54, 59], SD = [[34, 48], [66, 48], [40.2, 74], [59.8, 74], [50, 79], [31, 63], [69, 63], [50, 44]];
      I.mo = { bodyG, rT: () => 0, Dh, DM, bv, OL, NO, ol, q, zF, hw, d: '', tp, tsd, rf, str, wr, fl, sd, sdh, SI, SD, zAt: (x, y) => zF(x, y) }; }
    if (RC.zapfx) { xd.innerHTML += '<radialGradient id="zau' + u0 + '"><stop offset="0" stop-color="#fff6a0" stop-opacity="0.9"/><stop offset="0.6" stop-color="#ffe14a" stop-opacity="0.35"/><stop offset="1" stop-color="#ffe14a" stop-opacity="0"/></radialGradient><filter id="zgl' + u0 + '" x="-50%" y="-50%" width="200%" height="200%"><feGaussianBlur stdDeviation="1.3"/></filter>';
      const mr0 = I.spk ? I.spk.r0 : 30, mr1 = I.spk ? I.spk.r1 : 36; xd.innerHTML += '<radialGradient id="zmg' + u0 + '" gradientUnits="userSpaceOnUse" cx="50" cy="54" r="90"><stop offset="0" stop-color="#000"/><stop offset="' + ((mr0 - 6) / 90).toFixed(3) + '" stop-color="#000"/><stop offset="' + ((mr0 - 1) / 90).toFixed(3) + '" stop-color="#555"/><stop offset="' + ((mr1 + 5) / 90).toFixed(3) + '" stop-color="#fff"/><stop offset="1" stop-color="#fff"/></radialGradient><mask id="zmk' + u0 + '" maskUnits="userSpaceOnUse" x="-60" y="-60" width="220" height="220"><rect x="-60" y="-60" width="220" height="220" fill="url(#zmg' + u0 + ')"/></mask>';
      const au = mk('circle', { fill: 'url(#zau' + u0 + ')', opacity: 0 }, root); root.insertBefore(au, art);
      const fl = mk('rect', { x: -60, y: -60, width: 220, height: 220, fill: '#fffbe0', opacity: 0 }, root), zg = mk('g', { mask: 'url(#zmk' + u0 + ')' }, root), gl = mk('g', { filter: 'url(#zgl' + u0 + ')' }, zg);
      const ln = (par, w, c) => mk('path', { fill: 'none', stroke: c, 'stroke-width': w, 'stroke-linecap': 'round', 'stroke-linejoin': 'round', opacity: 0 }, par);
      I.zfx = { au, fl, mg: xd.querySelector('#zmg' + u0), M: [ln(gl, 6.5, '#ffe14a'), ln(zg, 3.6, '#eebb12'), ln(zg, 2.5, '#ffd21f'), ln(zg, 1, '#fff9c4')], S: [ln(gl, 3.8, '#ffe14a'), ln(zg, 2.2, '#eebb12'), ln(zg, 1.4, '#ffd21f'), ln(zg, 0.6, '#fff9c4')] }; }
    // Zappi: ears and tail are stacked puffy slices so they read as rounded 3D shapes; cheek sparks crackle
    if (RC.puff) { xd.innerHTML += '<radialGradient id="zpl' + u0 + '" cx="38%" cy="30%" r="75%"><stop offset="0" stop-color="#fffbd6"/><stop offset="0.55" stop-color="#ffe14a"/><stop offset="1" stop-color="#e2a80a"/></radialGradient><radialGradient id="zpd' + u0 + '" cx="38%" cy="30%" r="75%"><stop offset="0" stop-color="#f3c52a"/><stop offset="1" stop-color="#b87c04"/></radialGradient>';
      const LF = 'url(#zpl' + u0 + ')', DF = 'url(#zpd' + u0 + ')';
      items.forEach(q => { if (q.role !== 'top' && q.role !== 'tail') return; const par = q.e.parentNode, P0 = pts(q.segs);
        Object.assign(q, { pc: [P0.reduce((s, p) => s + p[0], 0) / P0.length, P0.reduce((s, p) => s + p[1], 0) / P0.length], pT: q.role === 'tail' ? 4 : 4.2, pd: 1, LF, DF });
        q.pz = Array.from({ length: 7 }, (_, k) => { const u = -1 + k / 3, s = 0.7 + 0.3 * Math.sqrt(1 - u * u), el = mk('path', { fill: LF, stroke: LF, 'stroke-width': +(1.4 * s).toFixed(2), 'stroke-linejoin': 'round' }, par); par.insertBefore(el, q.e); return { u, el, s, f: LF }; });
        q.e.style.display = 'none'; }); }
    if (RC.spark) items.forEach(q => { if (q.role === 'face' && q.e.closest('g[stroke]')) q.spk = Math.random() * 9; });
    // Twinkle: the star IS the body. Built as stacked puffy slices so it turns in 3D; its 5 points are the arms, legs and top
    if (RC.star && headA) { const q = headA.q, P0 = pts(q.segs), V0 = P0.slice(0, 10); let V = V0.length === 10 ? V0 : [[50, 14], [62.3, 37], [88, 41.6], [70, 60.5], [73.5, 86.4], [50, 75], [26.5, 86.4], [30, 60.5], [12, 41.6], [37.7, 37]], CQ = null;
      // Wishling: her star is 5 curved Q points (M inner, then ctrl + inner per point) - put the real tips (curve peaks) at the even slots like Twinkle's so her side points bend as hands, and keep the art's curved sides
      if (RC.wish && P0.length >= 11) { const md = (a, b) => [(a[0] + b[0]) / 2, (a[1] + b[1]) / 2]; V = []; CQ = {}; for (let k = 0; k < 5; k++) { const a = P0[2 * k], c = P0[2 * k + 1], b = P0[2 * k + 2]; V.push([0.25 * a[0] + 0.5 * c[0] + 0.25 * b[0], 0.25 * a[1] + 0.5 * c[1] + 0.25 * b[1]], b); CQ[2 * k] = [md(a, c), md(c, b)]; } }
      const SW = RC.wish ? 1.6 : 7; if (RC.wish) items.forEach(z => { if (z !== q && z.inBody && z.tag === 'path' && z.fill === '#fff6b0') { z.role = 'bnop'; z.e.style.display = 'none'; } }); // flat inner glow star would sit still while her points bend
      const inn = V.filter((p, i) => i % 2), C = [inn.reduce((s, p) => s + p[0] / 5, 0), inn.reduce((s, p) => s + p[1] / 5, 0)];
      xd.innerHTML += '<radialGradient id="tsl' + u0 + '" gradientUnits="userSpaceOnUse" cx="41" cy="36" r="56"><stop offset="0" stop-color="#fff8cc"/><stop offset="0.55" stop-color="#ffd84a"/><stop offset="1" stop-color="#e09e10"/></radialGradient><radialGradient id="tsd' + u0 + '" gradientUnits="userSpaceOnUse" cx="41" cy="36" r="56"><stop offset="0" stop-color="#ffe68a"/><stop offset="0.55" stop-color="#efb326"/><stop offset="1" stop-color="#c2850a"/></radialGradient>';
      const T = 9, N = 9, LF = 'url(#tsl' + u0 + ')', DF = 'url(#tsd' + u0 + ')', par = q.e.parentNode;
      const sl = Array.from({ length: N }, (_, k) => { const z = -T + 2 * T * k / (N - 1), el = mk('path', { fill: LF, stroke: LF, 'stroke-width': SW, 'stroke-linejoin': 'round' }, par); par.insertBefore(el, q.e); return { z, el, s: 0.55 + 0.45 * Math.sqrt(Math.max(0, 1 - (z / T) * (z / T))), f: LF }; });
      q.e.style.display = 'none';
      const RL = { 0: 'top', 2: 'arm', 4: 'leg', 6: 'leg', 8: 'arm' };
      const L = [0, 2, 4, 6, 8].map(i => { const a = V[(i + 9) % 10], b = V[i + 1], m = [(a[0] + b[0]) / 2, (a[1] + b[1]) / 2], piv = [m[0] + (C[0] - m[0]) * 0.35, m[1] + (C[1] - m[1]) * 0.35]; return { i, role: RL[i], side: Math.abs(V[i][0] - C[0]) < 2 ? 0 : V[i][0] < C[0] ? -1 : 1, piv, Lr: Math.hypot(V[i][0] - piv[0], V[i][1] - piv[1]) }; });
      const ov = L.filter(l => l.role === 'arm').map(l => ({ l, sh: mk('path', { fill: '#b8780a', stroke: '#b8780a', 'stroke-width': SW + 0.6, 'stroke-linejoin': 'round', opacity: 0, transform: 'translate(0.6 1.2)' }, armG), p: mk('path', { fill: LF, stroke: LF, 'stroke-width': SW, 'stroke-linejoin': 'round', opacity: 0 }, armG) }));
      // nightcap rebuilt in 3D: floppy cone over the top point, fur trim ring around it, round pompom
      items.forEach(z => { if (z.role === 'top') { z.e.style.display = 'none'; z.role = 'capHidden'; } });
      xd.innerHTML += '<radialGradient id="tcb' + u0 + '" gradientUnits="userSpaceOnUse" cx="45" cy="7" r="20"><stop offset="0" stop-color="#d6ebff"/><stop offset="0.5" stop-color="#8cc4ff"/><stop offset="1" stop-color="#4f86cc"/></radialGradient><radialGradient id="tcw' + u0 + '" gradientUnits="userSpaceOnUse" cx="44" cy="18" r="17"><stop offset="0" stop-color="#ffffff"/><stop offset="0.6" stop-color="#f1f2fb"/><stop offset="1" stop-color="#bfc4e0"/></radialGradient><radialGradient id="tcp' + u0 + '" cx="35%" cy="30%" r="75%"><stop offset="0" stop-color="#ffffff"/><stop offset="0.65" stop-color="#eef0fa"/><stop offset="1" stop-color="#c3c8e2"/></radialGradient>';
      const capE = { rb: mk('path', { fill: 'url(#tcw' + u0 + ')' }, par), cone: mk('path', { fill: 'url(#tcb' + u0 + ')' }, par), rf: mk('path', { fill: 'url(#tcw' + u0 + ')' }, par), pom: mk('path', { fill: 'url(#tcp' + u0 + ')' }, par) };
      I.star = { capE, V, CQ, SW, C, T, sl, L, ov, LF, DF, anchor: q.e, grads: [xd.querySelector('#tsl' + u0), xd.querySelector('#tsd' + u0)], cgr: [xd.querySelector('#tcb' + u0), xd.querySelector('#tcw' + u0)], dir: 1, md: '', hd: '' }; I.foodK = 0.35; }
    if (RC.lantern) { xd.innerHTML += '<radialGradient id="lgb' + u0 + '" cx="40%" cy="38%" r="70%"><stop offset="0" stop-color="#fffdf0"/><stop offset="0.55" stop-color="#ffe58a"/><stop offset="1" stop-color="#f2b53a"/></radialGradient><linearGradient id="lgc' + u0 + '" x1="0" y1="0" x2="1" y2="1"><stop offset="0" stop-color="#ffe7a0"/><stop offset="1" stop-color="#b9822a"/></linearGradient><radialGradient id="lgl' + u0 + '"><stop offset="0" stop-color="#fff3b0" stop-opacity="0.85"/><stop offset="0.45" stop-color="#ffe27a" stop-opacity="0.35"/><stop offset="1" stop-color="#ffe27a" stop-opacity="0"/></radialGradient>';
      const lg = mk('g', {}, art); art.insertBefore(lg, armG); const L = I.lan = { g: lg, th: 0, w: 0 };
      L.glow = mk('circle', { cx: 0, cy: 9, r: 10, fill: 'url(#lgl' + u0 + ')' }, lg);
      mk('path', { d: 'M-2 3.6 Q0 -1.4 2 3.6', fill: 'none', stroke: '#c9902e', 'stroke-width': 0.8, 'stroke-linecap': 'round' }, lg);
      mk('path', { d: 'M-3.4 5.2 Q-3.2 3.2 0 3.2 Q3.2 3.2 3.4 5.2 Z', fill: 'url(#lgc' + u0 + ')' }, lg);
      mk('path', { d: 'M-3.5 7.4 Q-3.5 4.6 -0.7 4.6 L0.7 4.6 Q3.5 4.6 3.5 7.4 L3.5 9.8 Q3.5 12.6 0.7 12.6 L-0.7 12.6 Q-3.5 12.6 -3.5 9.8 Z', fill: 'url(#lgb' + u0 + ')' }, lg);
      mk('path', { d: 'M-1.3 5.2 L-1.3 12 M1.3 5.2 L1.3 12', stroke: '#e3a238', 'stroke-width': 0.45, opacity: 0.55, fill: 'none' }, lg);
      L.flame = mk('ellipse', { cx: 0, cy: 8.8, rx: 1.2, ry: 1.9, fill: '#fffbe6' }, lg);
      mk('path', { d: 'M-3.1 12.2 L3.1 12.2 Q2.9 14.2 0 14.2 Q-2.9 14.2 -3.1 12.2 Z', fill: 'url(#lgc' + u0 + ')' }, lg);
      mk('ellipse', { cx: -2, cy: 7.2, rx: 0.6, ry: 1.7, fill: '#ffffff', opacity: 0.85 }, lg); }
    if (RC.rain) { xd.innerHTML += '<radialGradient id="rdg' + u0 + '" cx="38%" cy="35%" r="75%"><stop offset="0" stop-color="#e6f6ff"/><stop offset="0.6" stop-color="#8fd3ff"/><stop offset="1" stop-color="#4fa6dc"/></radialGradient>';
      const rg = mk('g', {}, root); root.insertBefore(rg, art); I.rain = { next: 0, drops: Array.from({ length: 16 }, () => ({ st: 0, el: mk('path', { fill: 'url(#rdg' + u0 + ')', opacity: 0 }, rg), sp: mk('ellipse', { fill: 'none', stroke: '#8fd3ff', 'stroke-width': 0.4, opacity: 0 }, rg) })) }; }
    if (RC.ripple) { const rg = mk('g', {}, root); root.insertBefore(rg, art); I.rip = { air: 0, pk: 0, pd: { t: null, el: mk('ellipse', { fill: '#8fd3ff', opacity: 0 }, rg) }, rs: Array.from({ length: 6 }, () => ({ on: 0, el: mk('ellipse', { fill: 'none', stroke: '#8fd3ff', opacity: 0 }, rg) })) }; }
    if (RC.shimmer) { const ir = art.querySelector('[id="r_g' + u0 + '"]'), mg = art.querySelector('[id="g_g' + u0 + '"]'), st = mg ? mg.querySelectorAll('stop') : []; I.shim = { ir, s2: st[2], s3: st[3] }; }
    // the rig's own face: eyes with lids, morphing mouth, tongue, tear pools, tints
    const defs = mk('defs', {}, I.faceG); const u = I.u;
    defs.innerHTML = '<radialGradient id="gey' + u + '" cx="35%" cy="30%" r="70%"><stop offset="0" stop-color="#6b5470"/><stop offset="1" stop-color="#2a1a30"/></radialGradient><clipPath id="ghc' + u + '" clipPathUnits="userSpaceOnUse"><path/></clipPath>' + EY.map((e, i) => '<clipPath id="gec' + i + u + '" clipPathUnits="userSpaceOnUse"><path/></clipPath>').join('');
    I.headClip = defs.querySelector('#ghc' + u + ' path');
    const fg = mk('g', { 'clip-path': 'url(#ghc' + u + ')' }, I.faceG); const E = I.E;
    E.tintR = mk('path', { fill: '#ff4040', opacity: 0 }, fg); E.tintG = mk('path', { fill: '#93b84a', opacity: 0 }, fg);
    E.eyes = EY.map((e, i) => { const gg = mk('g', {}, fg), el = mk('path', { fill: 'url(#gey' + u + ')', stroke: '#2a1a30', 'stroke-linecap': 'round', 'stroke-linejoin': 'round' }, gg), hg = mk('g', { 'clip-path': 'url(#gec' + i + u + ')' }, gg);
      return { g: gg, e: el, tp: mk('path', { fill: '#a8dcff', opacity: 0 }, hg), h1: mk('path', { fill: '#fff' }, hg), h2: mk('path', { fill: '#fff' }, hg), clip: defs.querySelector('#gec' + i + u + ' path') }; });
    E.mopen = mk('path', { fill: '#7a2a40' }, fg); E.tongue = mk('path', { fill: '#ff8fa3' }, fg);
    E.mouth = mk('path', { fill: 'none', stroke: v2.mouthInk || '#6a3a3a', 'stroke-width': 1.2, 'stroke-linecap': 'round', 'stroke-linejoin': 'round' }, fg);
    E.tout = mk('path', { fill: '#ff7f9a', stroke: '#e0607e', 'stroke-width': 0.3, opacity: 0 }, fg);
    if (main) { E.bodyG = mk('path', { fill: '#93b84a', opacity: 0 }, main.q.e.parentNode); main.q.e.parentNode.insertBefore(E.bodyG, main.q.e.nextSibling); }
    items.forEach(q => { if (q.role === 'patch' || q.role === 'face' || q.role === 'cheek' || q.role === 'wsurf') q.e.setAttribute('clip-path', 'url(#ghc' + u + ')'); });
    const cdefs = mk('defs', {}, art); items.forEach(q => { if (q.clipId) { cdefs.innerHTML += '<clipPath id="' + q.clipId + '" clipPathUnits="userSpaceOnUse"><path/></clipPath>'; } });
    items.forEach(q => { if (q.clipId) q.clipEl = cdefs.querySelector('#' + q.clipId + ' path'); if (q.role === 'inner' && q.owner && q.owner.clipId) q.e.setAttribute('clip-path', 'url(#' + q.owner.clipId + ')'); });
    // Pip: a round 3D penguin. The egg body turns as one; the white belly wraps round its front, flippers are puffy 3D paddles hinged at the shoulders, a little tail sits on his back; only his yellow beak opens (no extra mouth)
    if (key === 'pip' && headA && bodyG) { const bq = headA.q, HY0 = headA.cy, Q = (a, b, c, s) => (1 - s) * (1 - s) * a + 2 * s * (1 - s) * b + s * s * c, prof = [];
      for (let k = 0; k < 60; k++) { const s = (k % 30) / 30; prof.push(k < 30 ? [Q(16, 16, 54, s), Q(50, 82, 82, s) - 50] : [Q(54, 90, 90, s), Q(82, 82, 50, s) - 50]); } prof.push([90, 0]);
      const rY = y => { if (y <= 16 || y >= 90) return 0; for (let i = 1; i < prof.length; i++) if (y <= prof[i][0]) { const a = prof[i - 1], b = prof[i]; return a[1] + (b[1] - a[1]) * (y - a[0]) / ((b[0] - a[0]) || 1); } return 0; };
      I.zE = (dx, dy) => { const r = rY(HY0 + dy); return Math.sqrt(Math.max(0, r * r - dx * dx)) + 0.4; };
      const xd2 = mk('defs', {}, art), u = I.u, rg = (id, st) => '<radialGradient id="' + id + u + '" cx="38%" cy="30%" r="75%">' + st.map(([o, c]) => '<stop offset="' + o + '" stop-color="' + c + '"/>').join('') + '</radialGradient>';
      xd2.innerHTML = rg('pfl', [[0, '#8595c0'], [0.55, '#46557f'], [1, '#262f4c']]) + rg('pfd', [[0, '#4a5884'], [1, '#1c2338']]) + rg('pft', [[0, '#ffd590'], [0.55, '#ffa53a'], [1, '#d9741a']]) + rg('pbk', [[0, '#ffd590'], [0.6, '#ffa53a'], [1, '#e0801a']]);
      const LF = 'url(#pfl' + u + ')', DF = 'url(#pfd' + u + ')', bel = items.find(q => q.inBody && /^url\(#w_g/.test(q.fill));
      const slices = (par, n, sw) => Array.from({ length: n }, (_, k) => { const uu = -1 + 2 * k / (n - 1), s = 0.62 + 0.38 * Math.sqrt(1 - uu * uu); return { u: uu, s, f: LF, el: mk('path', { fill: LF, stroke: LF, 'stroke-width': (sw * s).toFixed(2), 'stroke-linejoin': 'round' }, par) }; });
      const fl = items.filter(q => q.inBody && q.tag === 'path' && q !== bq && q !== bel && /^url\(#g_g/.test(q.fill)).map(q => { q.role = 'pgFlip'; q.e.style.display = 'none'; const sd = q.cx < 50 ? -1 : 1, g = mk('g', {}, bodyG);
        return { q, sd, g, pv: [50 + sd * 29, 55], c: [q.cx, q.cy], tip: [50 + sd * 40, 76], S: slices(g, 7, 1.3), fr: null }; });
      xd2.innerHTML += '<linearGradient id="ptl' + u + '" x1="0" y1="0" x2="0" y2="1"><stop offset="0" stop-color="#6c7cab"/><stop offset="0.5" stop-color="#3a4874"/><stop offset="1" stop-color="#1e2640"/></linearGradient>';
      const tg = mk('g', {}, bodyG), tq = { g: tg, fr: null, el: mk('path', { fill: 'url(#ptl' + u + ')', stroke: '#1a2034', 'stroke-width': 0.5, 'stroke-linejoin': 'round' }, tg), hl: mk('path', { fill: 'none', stroke: '#a2b0d8', 'stroke-width': 0.7, 'stroke-linecap': 'round', opacity: 0.75 }, tg) };
      if (bel) bel.role = 'pgBelly';
      items.forEach(q => { if (!q.inBody && (q.fill === '#ffa53a' || q.e.getAttribute('stroke') === '#e0801a')) { q.role = 'pgX'; q.e.style.display = 'none'; } else if (q.role === 'shine' && !q.inBody) q.role = 'pgShine';
        if (q.role === 'foot') { q.e.setAttribute('fill', 'url(#pft' + u + ')'); const pr = q.e.parentNode, nx = q.e.nextSibling; q.rim = mk('path', { fill: 'none', stroke: '#b85e12', 'stroke-width': 0.6, opacity: 0 }, pr); q.gl = mk('path', { fill: '#fff', opacity: 0 }, pr); pr.insertBefore(q.rim, nx); pr.insertBefore(q.gl, nx); } });
      const bk = { in: mk('path', { fill: '#7a2a40', opacity: 0 }, I.faceG), lo: mk('path', { fill: '#ec8a22' }, I.faceG), up: mk('path', { fill: 'url(#pbk' + u + ')' }, I.faceG), hl: mk('path', { fill: '#fff6e0', opacity: 0.6 }, I.faceG) };
      I.pq = { rY, bq, bel, fl, tq, bk, LF, DF }; }
    // Shelly: a real turtle. The flat shell art is rebuilt as a 3D dome (scutes + rim slide round it as it turns), the head sits on a neck that stretches and pulls back into the shell, 4 stubby legs (the front pair hold food), little tail
    if (RC.turtle && headA && bodyG) { const hq = headA.q, par = hq.e.parentNode, u = I.u, filt = bodyG.getAttribute('filter'), SVN = 'http://www.w3.org/2000/svg';
      const shQ = items.find(q => q.inBody && /^url\(#s_/.test(q.fill)), shF = shQ ? shQ.fill : '#7ee6d8', skF = hq.fill;
      items.forEach(q => { const st = q.e.getAttribute('stroke'); if (q === shQ || (q.inBody && (q.fill === '#2fa39c' || (q.fill === 'none' && st === '#ffffff'))) || q.role === 'arm' || q.role === 'foot' || q.role === 'hand' || (!q.inBody && q.tag === 'ellipse' && q.cx < 36 && q.cy < 42)) { q.role = 'bnop'; q.e.style.display = 'none'; } });
      (I.tubes || []).forEach(t => t && (t.style.display = 'none'));
      const Qb = (a, b, c, s) => (1 - s) * (1 - s) * a + 2 * s * (1 - s) * b + s * s * c, pr = [];
      for (let k = 0; k <= 40; k++) { const s = k / 40; pr.push([Qb(24, 26, 66, s), 50 - Qb(50, 10, 12, s)]); if (k) pr.push([Qb(66, 82, 82, s), 50 - Qb(12, 12, 50, s)]); }
      pr.sort((a, b) => a[0] - b[0]);
      const rY = y => { if (y <= pr[0][0]) return 0; for (let i = 1; i < pr.length; i++) if (y <= pr[i][0]) { const a = pr[i - 1], b = pr[i]; return a[1] + (b[1] - a[1]) * (y - a[0]) / ((b[0] - a[0]) || 1); } return 0; };
      const gBack = mk('g', {}, bodyG); bodyG.insertBefore(gBack, bodyG.firstChild);
      const gShell = mk('g', { id: 'tts' + u }, par); par.insertBefore(gShell, hq.e);
      const dome = mk('path', { fill: shF }, gShell), band = mk('path', { fill: '#2fa39c', opacity: 0.5 }, gShell), hex = mk('path', { fill: 'none', stroke: '#ffffff', 'stroke-width': 1.3, 'stroke-linejoin': 'round', opacity: 0.55 }, gShell), hole = mk('path', { fill: '#1e5f5a', opacity: 0 }, gShell), shine = mk('path', { fill: '#fff', opacity: 0.75 }, gShell);
      const gNeck = mk('g', {}, par); par.insertBefore(gNeck, hq.e);
      const neck = mk('path', { fill: skF }, gNeck), fold = mk('path', { fill: 'none', stroke: '#6fae52', 'stroke-width': 0.9, 'stroke-linecap': 'round', opacity: 0 }, gNeck);
      const gLate = mk('g', {}, art); art.insertBefore(gLate, I.faceG.nextSibling);
      const gFront = mk('g', filt ? { filter: filt } : {}, art); art.insertBefore(gFront, gLate.nextSibling);
      const xdT = mk('defs', {}, art); xdT.innerHTML = '<clipPath id="ttc' + u + '" clipPathUnits="userSpaceOnUse"><path d="M0 0Z"/></clipPath>';
      const lid = mk('g', Object.assign({ 'clip-path': 'url(#ttc' + u + ')' }, filt ? { filter: filt } : {}), art); art.insertBefore(lid, gFront.nextSibling); const us = document.createElementNS(SVN, 'use'); us.setAttribute('href', '#tts' + u); lid.appendChild(us); lid.style.display = 'none';
      const legs = [[-1, 1], [1, 1], [-1, 0], [1, 0]].map(([sd, fr]) => { const g2 = mk('g', {}, fr ? gFront : gBack); return { sd, fr, g: g2, el: mk('path', { fill: skF }, g2), toe: mk('path', { fill: '#efffdc', opacity: 0.9 }, g2) }; });
      const tg = mk('g', {}, gBack), tail = mk('path', { fill: skF }, tg), HEX = [];
      [[50, 36, 7], [37, 43, 6], [63, 43, 6], [26, 56, 5], [74, 56, 5]].forEach(([cx, cy, R]) => { const t0 = Math.asin(clamp((cx - 50) / rY(cy), -1, 1)); HEX.push([t0, cy, R]); HEX.push([Math.PI - t0, cy, R]); });
      [-1, 1].forEach(s => [[90, 38, 6.5], [68, 48, 5.5], [112, 48, 5.5], [65, 58, 5], [90, 58, 5], [115, 58, 5]].forEach(([d, y, R]) => HEX.push([s * d * D2R, y, R])));
      I.tt = { rY, K: 0.85, HZ: 30, YS: [24.3, 25, 26.5, 29, 33, 39, 46, 54, 62, 66, 71, 75, 78, 80, 81.2, 81.8], dome, band, hex, hole, shine, neck, fold, gShell, gNeck, gLate, gFront, gBack, par, filt, lid, clip: xdT.querySelector('path'), legs, tail, tg, HEX, h: 0, nk: 0, s: 1, hx: 0, hy: 0, hz: 30, ys: 0 };
      I.mReach = 1; }
    // Jelli: a real jellyfish. The bell pulses (rim squeezes in, dome rises, small thrust up); all 4 tentacles are round tapered 3D tubes hanging from a ring under the bell: they wave all the time, trail behind every move, turn round with the body, and the outer two reach up to his mouth to eat
    if (key === 'jelli' && headA && bodyG) { const tq = items.filter(q => q.inBody && q.tag === 'path' && q.fill === 'none' && q.e.getAttribute('stroke') === '#c6a6fb').sort((a, b) => a.cx - b.cx), u = I.u;
      const jd = mk('defs', {}, art); jd.innerHTML = '<radialGradient id="jgl' + u + '"><stop offset="0" stop-color="#eadcff" stop-opacity="0.9"/><stop offset="0.5" stop-color="#c9a8ff" stop-opacity="0.35"/><stop offset="1" stop-color="#c9a8ff" stop-opacity="0"/></radialGradient>';
      const glow = mk('ellipse', { fill: 'url(#jgl' + u + ')', opacity: 0 }, root); root.insertBefore(glow, art);
      const par = tq.length ? tq[0].e.parentNode : bodyG, fg = mk('g', bodyG.getAttribute('filter') ? { filter: bodyG.getAttribute('filter') } : {}, art);
      const T = tq.map((q, i) => { const p0 = pts(q.segs)[0] || [q.cx, 56], dd = q.e.getAttribute('d') || '', m = dd.match(/q\s*(-?)/i), g = mk('g', { opacity: 0.96 }, par); par.insertBefore(g, q.e); q.role = 'bnop'; q.e.style.display = 'none';
        return { g, b: mk('path', { fill: 'none', stroke: q.e.getAttribute('stroke') || '#c6a6fb', 'stroke-width': q.e.getAttribute('stroke-width') || 5.5, 'stroke-linecap': 'round', 'stroke-linejoin': 'round' }, g), f: mk('path', { fill: 'none', stroke: q.e.getAttribute('stroke') || '#c6a6fb', 'stroke-width': q.e.getAttribute('stroke-width') || 5.5, 'stroke-linecap': 'round', 'stroke-linejoin': 'round', opacity: 0 }, fg),
          th: Math.asin(clamp((p0[0] - 50) / 26, -1, 1)), z0: [7, -9, 9, -7][i] || 0, sg: m && m[1] === '-' ? -1 : 1, side: i === 0 ? -1 : i === tq.length - 1 ? 1 : 0, ph: i * 1.37, fr: false }; });
      I.jl = { T, glow, par, fg, anchor: tq.length ? tq[0].e : null, c: 0, bob: 0, ph: 0 }; }
    // Octo: a real octopus. 8 tapered 3D arms on a ring under his soft mantle (6 in front like the art + 2 at the back); the outer two are his hands
    if (key === 'octo' && headA && bodyG) { const tq = items.filter(q => q.inBody && q.tag === 'path' && q.fill === 'none' && /^url\(#t/.test(q.e.getAttribute('stroke') || '')).sort((a, b) => a.cx - b.cx);
      items.forEach(q => { if (q.inBody && q.fill === '#ffe0ee') { q.role = 'bnop'; q.e.style.display = 'none'; } });
      const par = tq.length ? tq[0].e.parentNode : bodyG, anchor = tq.length ? tq[0].e : null, grad = tq.length ? tq[0].e.getAttribute('stroke') : '#ff90c0';
      tq.forEach(q => { q.role = 'bnop'; q.e.style.display = 'none'; });
      const filt = bodyG.getAttribute('filter'), fg = mk('g', filt ? { filter: filt } : {}, art);
      const mkT = pr => { const g = mk('g', {}, pr); return { g, b: mk('path', { fill: grad }, g), sh: mk('path', { fill: 'none', stroke: '#b8306f', 'stroke-opacity': 0.2, 'stroke-width': 2.6, 'stroke-linecap': 'round', 'stroke-linejoin': 'round' }, g), hl: mk('path', { fill: 'none', stroke: '#ffffff', 'stroke-opacity': 0.32, 'stroke-width': 1.5, 'stroke-linecap': 'round', 'stroke-linejoin': 'round' }, g), cu: mk('path', { fill: '#ffe0ee' }, g) }; };
      // [root x, root y, root z, exit angle, curl, length, curl power, plane yaw] for the left side (mirrored for the right); fitted to the art paths
      const SPEC = [[26, 64, 7, 54, -178, 37, 2, 0], [36, 70, 15, 27, -162, 29, 3, 0], [46, 72, 18, 6, -112, 23.5, 3, 0], [38, 65, -14, 40, -150, 25, 2.5, -1.0]], T = [];
      [-1, 1].forEach(sd => SPEC.forEach((p, j) => { const o = mkT(par); if (anchor) par.insertBefore(o.g, anchor); const rx = sd < 0 ? p[0] : 100 - p[0];
        T.push(Object.assign(o, { sd, j, arm: j === 0, rx, ry: p[1], rz: p[2], f0: p[3] * D2R, C: p[4] * D2R, L: p[5], pw: p[6], be: p[7], ph: j * 1.9 + (sd > 0 ? 0.9 : 0), ri: 0, fr: j === 0 ? mkT(fg) : null })); }));
      T.slice().sort((a, b) => a.rx - b.rx).forEach((t, i) => { t.ri = i; });
      const ig = mk('g', { opacity: 0 }, root); root.insertBefore(ig, art); ig.style.display = 'none';
      I.oc = { T, par, anchor, fg, ig, IP: Array.from({ length: 7 }, () => mk('circle', { fill: '#3a2050' }, ig)), ok: '' }; }
    // Marina: a real mermaid. One-piece 3D hair (a shell round the back of her head + two locks, one gradient, pieces sorted in front of / behind the head as she turns),
    // round torso with a shell top, tapered 3D fish tail with scales and a fluke; the pearl is only held in idle
    if (key === 'marina' && headA && bodyG) { const u = I.u, hq = headA.q, par = hq.e.parentNode; let tFill = null, gFill = null; const M = I.mm = { par, cups: [] };
      // arms hinge at the shoulder end (the art's outer end), so they can swing down to her sides and raise like real arms
      items.forEach(q => { if (q.role === 'arm' && q.hx != null) { q.hx = 2 * q.ox - q.hx - q.side * 2.6; q.hy = 2 * q.oy - q.hy; } });
      items.forEach(q => { if (q === hq || q.role === 'arm') return;
        if (q.role === 'hand') { q.role = 'bnop'; M.pearl = q; return; }
        if (q.inBody && q.role === 'top') { q.role = 'bnop'; if (q.fill === '#ffd24a') M.star = q; else M.bang = q; return; }
        if (q.inBody) { if (/^url\(#t/.test(q.fill) && !tFill) tFill = q.fill; if (q.tag === 'ellipse' && /^url\(#g/.test(q.fill)) gFill = q.fill; q.role = 'bnop'; q.e.style.display = 'none'; } });
      const df = mk('defs', {}, art); df.innerHTML = '<radialGradient id="mmh' + u + '" gradientUnits="userSpaceOnUse" cx="38" cy="28" r="34"><stop offset="0" stop-color="#c8fff4"/><stop offset="0.6" stop-color="#5ed8d0"/><stop offset="1" stop-color="#2a9aa6"/></radialGradient>'
        + '<linearGradient id="mmc' + u + '" gradientUnits="userSpaceOnUse" x1="37" y1="0" x2="63" y2="0"><stop offset="0" stop-color="#2a1a70" stop-opacity="0.42"/><stop offset="0.16" stop-color="#4a4ab0" stop-opacity="0.12"/><stop offset="0.3" stop-color="#ffffff" stop-opacity="0.3"/><stop offset="0.46" stop-color="#ffffff" stop-opacity="0"/><stop offset="0.74" stop-color="#2a1a70" stop-opacity="0.08"/><stop offset="1" stop-color="#2a1a70" stop-opacity="0.48"/></linearGradient>'
        + '<radialGradient id="mmk' + u + '" cx="38%" cy="30%" r="75%"><stop offset="0" stop-color="#ffe2ee"/><stop offset="0.6" stop-color="#ffb6d0"/><stop offset="1" stop-color="#e888b0"/></radialGradient>';
      M.hgr = df.querySelector('#mmh' + u); M.cgr = df.querySelector('#mmc' + u);
      const HF = 'url(#mmh' + u + ')', ins = el => { par.insertBefore(el, hq.e); return el; }, TF = tFill || '#5a9ae8';
      M.hB = mk('path', { fill: HF }, par); par.insertBefore(M.hB, par.firstChild);
      M.tail = ins(mk('path', { fill: TF }, par)); M.tsh = ins(mk('path', { fill: 'url(#mmc' + u + ')' }, par)); M.scl = ins(mk('path', { fill: 'none', stroke: '#ffffff', 'stroke-width': 0.8, opacity: 0.45, 'stroke-linecap': 'round' }, par));
      M.flG = ins(mk('g', {}, par)); M.fl = mk('path', { fill: TF }, M.flG); M.frib = mk('path', { fill: 'none', stroke: '#e8f2ff', 'stroke-width': 0.55, opacity: 0.5, 'stroke-linecap': 'round' }, M.flG);
      M.torso = ins(mk('path', { fill: gFill || '#ffd6c0' }, par)); [44.5, 55.5].forEach(x => M.cups.push({ x, e: ins(mk('path', { fill: 'url(#mmk' + u + ')' }, par)) }));
      if (M.bang) { M.bang.e.setAttribute('fill', HF); M.bang.e.setAttribute('clip-path', 'url(#ghc' + u + ')'); par.appendChild(M.bang.e); }
      M.hF = mk('path', { fill: HF }, par); M.sF = mk('path', { fill: 'none', stroke: '#2a9aa6', 'stroke-width': 0.7, opacity: 0.35, 'stroke-linecap': 'round', 'stroke-linejoin': 'round' }, par);
      if (M.star) par.appendChild(M.star.e);
      if (M.pearl) M.pearl.e.parentNode.appendChild(M.pearl.e);
      M.YH = [17.5, 19.5, 22, 25.5, 30, 35, 41, 47, 53, 59, 65, 71]; M.RH = [0.6, 10, 15.2, 19.6, 23.1, 25.4, 26.5, 26.6, 25.8, 24.2, 22.3, 20.4];
      M.LK = [-1, 1].map(sd => ({ sd, pts: [[20.5, 44, 2.5, 5.2], [21.4, 51, 3.2, 5], [22.4, 58, 3.8, 4.7], [22.8, 65, 4.2, 4.1], [22.2, 72, 4.6, 3.2], [21, 77.5, 5, 2], [19.8, 81.6, 5.3, 0.7]] }));
      const RT = [[0, 12.5], [0.26, 13], [0.52, 11.6], [0.74, 8.2], [0.89, 5.2], [1, 3.6]]; M.rT = s => { for (let i = 1; i < RT.length; i++) if (s <= RT[i][0]) { const a = RT[i - 1], b = RT[i], t = (s - a[0]) / (b[0] - a[0]); return a[1] + (b[1] - a[1]) * t * t * (3 - 2 * t); } return RT[RT.length - 1][1]; };
      M.ffr = true; M.tbk = false; }
    if (HERO[key]) heroSetup(I, root, art, key, H, items);
    I.items = items; I.render = render(H); I.ready = true; (window.__rgI || (window.__rgI = {}))[key] = I; if (window.RiveRig && window.RiveRig.tick1) window.RiveRig.tick1(I); // draw the full creature right away (don't wait for the next animation frame, which can be paused in a background tab)
  }

  const render = H => (I, P, now) => {
    if (I.mReach || I.pq) { const de = I.pEt ? Math.min(0.1, (now - I.pEt) / 1000) : 0, on = I.cur && /^eat_/.test(I.cur.name) && I.ctr && !I.ctr.done ? 1 : 0; I.pEt = now; I.pEw = (I.pEw || 0) + (on - (I.pEw || 0)) * Math.min(1, de * 7); I.pEu = Math.min(1, Math.max(0, (Math.max(-P.hLy, -P.hRy) - 4) / 10)); I.foodMid = 1; }
    if (I.hx && I.hx.hov) { const sl = /sleep/.test((I.cur && I.cur.name) || '') ? 0.35 : 1; P = Object.assign({}, P, { lift: P.lift + (I.hx.hov + Math.sin(now / 650) * I.hx.hov * 0.5) * sl + (+P.fly || 0) * 10 }); }
    // Puff bloats: blo channel (his dance) + a sudden bloat on every poke; body balloons, spikes stand up, cheeks fill, fins buzz; bubbles when he lets the air out
    if (I.pfF) { const nm = (I.cur && I.cur.name) || ''; let b = Math.max(0, +P.blo || 0);
      if (/^poke/.test(nm) && I.cur.t0 !== I.pfPk0) { I.pfPk0 = I.cur.t0; I.pfPk = now; } if (I.pfPk && now - I.pfPk < 1900) { const t = now - I.pfPk, u = t < 150 ? H.SM(t / 150) * 1.18 : t < 330 ? 1.18 - 0.18 * H.SM((t - 150) / 180) : t < 1500 ? 1 + Math.sin((t - 330) / 110) * 0.04 : t < 1900 ? 1 - H.SM((t - 1500) / 400) : 0; b = Math.max(b, u); }
      b = Math.min(b, 1.3); I.pfB = b; if (b > 0.7) I.pfHi = 1; if (I.pfHi && b < 0.45) { I.pfHi = 0; const RR = window.RiveRig; if (RR && RR.emit) { RR.emit(I, 'bubble', 'mouth', 3); RR.emit(I, 'bigbubble', 'mouth', 1); } }
      const bm = Math.min(b, 1), fl = 7 + Math.min(Math.max(+P.swim || 0, 0), 1.5) * 8 - bm * 3, fq = 170 - bm * 75;
      P = Object.assign({}, P, { armL: P.armL + Math.sin(now / fq) * fl, armR: P.armR + Math.sin(now / fq + 0.7) * fl, puff: Math.max(+P.puff || 0, b), wide: Math.max(+P.wide || 0, bm * 0.4), sq: (+P.sq || 0) * (1 - bm * 0.6), open: H.lerp(+P.open || 0, 0.2, bm) }); }
    // Shelly (turtle): hides in his shell on every poke (and with the hid channel in his dance), peeks out, pops back out; legs walk when he moves; the shell rocks; neck bobs
    if (I.tt) { const T = I.tt, SMf = H.SM, cl = H.clamp, nm = (I.cur && I.cur.name) || '', dt = T.t ? Math.min(0.05, (now - T.t) / 1000) : 0.016; T.t = now;
      if (/^poke/.test(nm) && I.cur.t0 !== T.pk0) { T.pk0 = I.cur.t0; T.pk = now; }
      let h = cl(+P.hid || 0, 0, 1), nk = cl(+P.nk || 0, -0.6, 1.6) + Math.sin(now / 900) * 0.12 + 0.06, tl = Math.sin(now / 1500) * 0.8, tn = 0;
      if (T.pk) { const t = now - T.pk; if (t < 2300) { const u = t < 160 ? SMf(t / 160) : t < 1100 ? 1 : t < 1350 ? 1 - 0.38 * SMf((t - 1100) / 250) : t < 1650 ? 0.62 : 0.62 * (1 - SMf((t - 1650) / 450)); h = Math.max(h, u);
          if (t > 160 && t < 1300) tl += Math.sin((t - 160) / 65) * 6 * Math.exp(-(t - 160) / 380);
          if (t > 1350 && t < 1650) tn += Math.sin((t - 1350) / 300 * Math.PI * 2) * 0.45;
          if (t > 1650) nk += 0.55 * Math.sin(Math.PI * cl((t - 1650) / 650, 0, 1)); } else T.pk = 0; }
      if (T.px == null) T.px = P.x; const v = (P.x - T.px) / Math.max(dt, 0.001); T.px = P.x; T.v = (T.v || 0) + (v - (T.v || 0)) * Math.min(1, dt * 8);
      const wk = cl(Math.abs(T.v) / 10, 0, 1) * (1 - h); T.ph = (T.ph || 0) + dt * 11 * wk; T.wk = wk; tl += Math.sin(T.ph) * 3 * wk;
      T.h = h; T.nk = nk * (1 - h);
      P = Object.assign({}, P, { lift: P.lift - h * 6.5, tilt: P.tilt + tl, turn: P.turn + tn, sq: (+P.sq || 0) * (1 - 0.75 * h) }); }
    // Ember: his wings are his arms - they flutter with wfl (wing flap) and lift with wsp (wings spread), plus a soft idle flutter
    if (I.dl && I.dl.key === 'ember') { const cl = (v, lo, hi) => Math.max(lo, Math.min(hi, v)), w = cl(+P.wfl || 0, 0, 1.5), sp = cl(+P.wsp || 0, 0, 1.5), fl = Math.sin(now / 1000 * 26) * w * 20 + Math.sin(now / 1000 * 3.2) * 3; P = Object.assign({}, P, { armL: (+P.armL || 0) + fl + sp * 12, armR: (+P.armR || 0) + fl + sp * 12 }); }
    // Hoot: his wings are his arms - they flap with wfl (his dance)
    if (I.dl && I.dl.key === 'hoot') { const w = Math.max(0, Math.min(1.5, +P.wfl || 0)), fl = Math.sin(now / 1000 * 24) * w * 24; if (w > 0.001) P = Object.assign({}, P, { armL: (+P.armL || 0) + fl, armR: (+P.armR || 0) + fl }); }
    // Boo and Pixie float: the ghost hovers above the ground and bobs, the fairy hovers on her buzzing wings
    if (I.gb || I.px) { const hv = I.gb ? 4.5 : 2.6, b2 = Math.sin(now / (I.gb ? 760 : 520)) * (I.gb ? 1.8 : 0.9); P = Object.assign({}, P, { lift: (+P.lift || 0) + hv + b2 }); }
    // Jinni floats over his lamp with a gentle hover bob; every poke (and the gin channel) swirls him into the lamp and poofs him back out
    if (I.gn) { const N = I.gn, nm = (I.cur && I.cur.name) || ''; if (/^poke/.test(nm) && I.cur.t0 !== N.pk0) { N.pk0 = I.cur.t0; N.pk = now; }
      let u = 0; if (N.pk) { const t = now - N.pk; if (t < 1700) u = t < 400 ? H.SM(t / 400) : t < 1200 ? 1 : 1 - H.SM((t - 1200) / 330); else N.pk = 0; }
      const gi = Math.max(H.clamp(+P.gin || 0, 0, 1), u), g0 = N.gi || 0; if (g0 > 0.9 && gi <= 0.9) { N.pft = now; N.pfB = 1; } else if (g0 < 0.4 && gi >= 0.4) { N.pft = now; N.pfB = 0.55; } N.gi = gi;
      P = Object.assign({}, P, { lift: (+P.lift || 0) + 1.2 + Math.sin(now / 820) * 1.3 }); }
    // Gumdrop: a gummy body - every move sets off a springy jelly wobble (squash + lean that lag and overshoot), plus a soft idle jiggle
    if (I.dl && I.dl.gum) { const J = I.dl.gum, dt = J.t ? Math.min(0.05, (now - J.t) / 1000) : 0.016, L0 = +P.lift || 0, X0 = +P.x || 0; J.t = now; if (J.i == null) { J.i = 1; J.y = L0; J.x = X0; }
      J.v += ((L0 - J.y) * 160 - J.v * 6) * dt; J.y += J.v * dt; J.vx += ((X0 - J.x) * 140 - J.vx * 6) * dt; J.x += J.vx * dt; const jy = H.clamp(J.y - L0, -6, 6), jx = H.clamp(J.x - X0, -6, 6);
      P = Object.assign({}, P, { sq: (+P.sq || 0) - jy * 0.035 + Math.sin(now / 260) * 0.012 + H.clamp(+P.jig || 0, 0, 1.5) * 0.08 * Math.sin(now / 55), lean: (+P.lean || 0) + jx * 0.55 + H.clamp(+P.jig || 0, 0, 1.5) * 1.6 * Math.sin(now / 70) }); }
    // Sugarplum is tall (big head on a dress): squash/stretch is softened so her head never sinks into or pulls off her body
    if (I.bk && I.bk.kind === 'sugarplum') P = Object.assign({}, P, { sq: (+P.sq || 0) * 0.35, lean: (+P.lean || 0) * 0.6 });
    const { toD, ellS, parsePath, ellAx, SM, clamp, lerp, r2, D2R, TAU } = H, g = I.geo, set = (e, a, v) => e.setAttribute(a, v);
    if (I.pfArt) { const b = I.pfB || 0, tf = b > 0.003 ? 'translate(' + r2(50 + P.x) + ' ' + r2(g.G) + ') scale(' + r2(1 + b * 0.12) + ') translate(' + r2(-50 - P.x) + ' ' + r2(-g.G) + ')' : ''; if (tf) set(I.pfArt, 'transform', tf); else if (I.pfArt.hasAttribute('transform')) I.pfArt.removeAttribute('transform'); }
    const G = g.G, Hh = G - g.TOP, HX = g.HX, HY = g.HY, SR = I.sr || g.HR + 0.5, NX = HX, NY = g.NY;
    const yb = (P.spin + (I.whole ? P.turn * 40 : 0)) * D2R, yh = I.whole ? yb : yb + P.turn * 40 * D2R, ph = P.pitch * 22 * D2R * (I.bk ? 0.15 : 1), cyb = Math.cos(yb), syb = Math.sin(yb), cyh = Math.cos(yh), syh = Math.sin(yh), cp = Math.cos(ph), sp = Math.sin(ph);
    const JL = I.jl; if (JL) { const jdt = JL.t ? clamp((now - JL.t) / 1000, 0, 0.05) : 0.016, on = clamp(+P.jon || 0, 0, 1); JL.t = now; JL.ph = (JL.ph + jdt / 2.6) % 1; const f = JL.ph, ip = f < 0.28 ? SM(f / 0.28) : 1 - SM((f - 0.28) / 0.72); JL.c = ip * 1.25 * (1 - on) + clamp(+P.jc || 0, -0.4, 1.3); JL.bob = ip * 4 * (1 - on) + Math.sin(now / 1700) * 1.2; JL.tt = now / 1000;
      const jt = P.x + P.tilt * 0.4 + P.lean * 1.2 + P.turn * 10, jl2 = P.lift; if (JL.sx == null) { JL.sx = jt; JL.svx = 0; JL.sl = jl2; JL.slv = 0; } JL.svx += ((jt - JL.sx) * 90 - JL.svx * 5) * jdt; JL.sx += JL.svx * jdt; JL.slv += ((jl2 - JL.sl) * 100 - JL.slv * 5.5) * jdt; JL.sl += JL.slv * jdt;
      JL.jx = clamp(JL.sx - jt, -9, 9) * 0.6 + Math.sin(now / 1300) * 2.2 + Math.sin(now / 610) * 0.6; JL.jy = clamp(JL.sl - jl2, -6, 6) * 0.5; JL.ang = (Math.sin(now / 1500) * 5 + clamp(JL.sx - jt, -9, 9) * 0.9 + clamp(P.turn, -1, 1) * 6) * D2R; JL.wb = Math.sin(now / 260) * 0.03 * (0.4 + clamp(Math.abs(JL.svx) / 30 + Math.abs(JL.slv) / 25, 0, 1.2)); }
    const OC = I.oc; if (OC) { const odt = OC.t ? clamp((now - OC.t) / 1000, 0, 0.05) : 0.016, ts = now / 1000; OC.t = now;
      const tg = P.x + P.tilt * 0.4 + P.lean * 1.2 + P.turn * 10, tl = P.lift; if (OC.sx == null) { OC.sx = tg; OC.svx = 0; OC.sl = tl; OC.slv = 0; }
      OC.svx += ((tg - OC.sx) * 80 - OC.svx * 6) * odt; OC.sx += OC.svx * odt; OC.slv += ((tl - OC.sl) * 90 - OC.slv * 6) * odt; OC.sl += OC.slv * odt;
      OC.jt = clamp(+P.ojt || 0, 0, 1.2); OC.br = Math.sin(ts * 1.95); OC.bob = Math.sin(ts * 1.95 - 0.6) * 0.9 * (1 - Math.min(1, OC.jt));
      OC.jx = clamp(OC.sx - tg, -9, 9) * 0.55 + Math.sin(ts * 0.83) * 1.1; OC.jy = clamp(OC.sl - tl, -6, 6) * 0.45; OC.ang = (Math.sin(ts * 0.62) * 2.5 + clamp(OC.sx - tg, -9, 9) * 0.7) * D2R; }
    const sq = clamp(P.sq, -0.25, 0.45), sy = 1 - sq, tr = (P.tilt + (I.hb ? P.htilt * 0.6 : 0)) * D2R, ct = Math.cos(tr), stt = Math.sin(tr), dn = I.dent && I.dent.a > 0.01 ? I.dent : null;
    const dnP = dn ? (I.fromM ? null : null) : null;
    const glob = (x, y) => {
      if (I.sc && I.sc.jx != null && y < 67) { const S = I.sc, a = clamp((67 - y) / 52, 0, 1), rp = y > 55 ? Math.sin(x * 0.55 + S.t * 3.2) * S.rip * clamp((y - 55) / 5, 0, 1) : 0; x += S.jx * a * a; y += S.jy * a + rp; }
      if (JL && y < 62) { const vv = clamp((60 - y) / 44, 0, 1), ca = Math.cos(JL.ang * (0.4 + 0.6 * vv)), sa = Math.sin(JL.ang * (0.4 + 0.6 * vv)), vx = x - 50, vy = y - 58; x = 50 + vx * ca - vy * sa + JL.jx * vv * vv; y = 58 + vx * sa + vy * ca + JL.jy * vv; const wk = 1 + JL.wb * (vv * 2 - 1); x = 50 + (x - 50) * wk; }
      if (JL) { const uu = clamp((y - 16) / 42, 0, 1), cc = JL.c || 0; x = 50 + (x - 50) * (1 - cc * 0.17 * uu * uu + (1 - uu) * cc * 0.04); y -= cc * 4.5 * (1 - uu) - cc * 1.6 * uu * uu; if (y > 50 && y < 62) y += Math.sin(x * 0.42 - JL.tt * 3.2) * (0.5 + Math.abs(cc) * 0.7) * clamp((y - 50) / 6, 0, 1); }
      // Octo: the soft mantle breathes (swells and rises), squeezes thin for a jet, sways and its top lags behind moves; it bobs on its arms
      if (OC) { if (!OC.raw && y < 75) { const vv = clamp((74 - y) / 56, 0, 1), ca = Math.cos(OC.ang * vv), sa = Math.sin(OC.ang * vv), vx = x - 50, vy = y - 72; x = 50 + vx * ca - vy * sa + OC.jx * vv * vv; y = 72 + vx * sa + vy * ca + OC.jy * vv * vv;
          x = 50 + (x - 50) * (1 + (OC.br * 0.026 - OC.jt * 0.17) * 4 * vv * (1 - vv) * 1.3); y -= (OC.br * 0.9 + OC.jt * 7) * vv * vv; }
        y -= OC.bob * clamp((86 - y) / 12, 0, 1); }
      if (dn) { const ddx = x - dn.x, ddy = y - dn.y, gg = Math.exp(-(ddx * ddx + ddy * ddy) / 90); if (gg > 0.01) { const vx = HX - dn.x, vy = (HY + G) / 2 - dn.y, L = Math.hypot(vx, vy) || 1; x += vx / L * dn.a * 4.5 * gg; y += vy / L * dn.a * 4.5 * gg; } }
      const u = clamp((G - y) / Hh, 0, 1), k = 1 + sq * (0.45 + 0.6 * 4 * u * (1 - u)), X = (x - 50) * k + P.lean * Math.pow(u, 1.5), Y = -(G - y) * sy;
      return [50 + X * ct - Y * stt + P.x, G + X * stt + Y * ct - P.lift - (JL ? JL.bob : 0)]; };
    const hs = I.hb ? 0 : I.hs, hr = I.hb ? 0 : P.htilt * D2R, chr = Math.cos(hr), shr = Math.sin(hr), hyo = I.hb ? 0 : -P.pitch * 1.1;
    const TT = I.tt; if (TT) { const ys = yb + P.turn * 14 * D2R, h = TT.h, dz = TT.HZ + TT.nk * 6 - h * 14, sw = Math.sin(now / 1300) * 0.7 + clamp(P.lean, -6, 6) * 0.3; TT.ys = ys; TT.s = 1 - h * 0.72; TT.hx = sw * Math.cos(ys) + dz * Math.sin(ys); TT.hy = -TT.nk * 7 + h * 16; TT.hz = -sw * Math.sin(ys) + dz * Math.cos(ys); }
    const headT = (x, y) => { x = HX + (x - HX) * (1 + hs * 0.6); y = NY - (NY - y) * (1 - hs) + hyo; const dx = x - NX, dy = y - NY; let X = NX + dx * chr - dy * shr, Y = NY + dx * shr + dy * chr; if (TT) { X = HX + (X - HX) * TT.s + TT.hx; Y = HY + (Y - HY) * TT.s + TT.hy; } return glob(X, Y); };
    const RK = I.rk || 1, sz = (dx, dy, zm) => { if (typeof zm === 'number') return zm; const q = SR * SR - dx * dx - dy * dy, z = I.zE ? I.zE(dx, dy) : (q > 0 ? Math.sqrt(q) : 0) * RK; return zm === 'b' ? -z : z; }, ZC = I.zc0 || 0;
    const CYL = I.cyl, cE = CYL ? clamp(CYL.e0 - ph * 0.8, 0.05, 0.9) : 0, ccE = Math.cos(cE), scE = Math.sin(cE), ce0 = CYL ? Math.cos(CYL.e0) : 1, se0 = CYL ? Math.sin(CYL.e0) : 0;
    const cylW = (u, v, w) => headT(50 + u * cyh + w * syh, CYL.Yc + 18 * ce0 + (v - 18) * ccE + (-u * syh + w * cyh) * scE);
    const cylIn = (x, y, zm) => { const u = x - 50, w = typeof zm === 'number' ? zm : Math.sqrt(Math.max(0, 1369 - u * u)) * (zm === 'b' ? -1 : 1); return [u, (y - CYL.Yc - w * se0) / ce0, w]; };
    const BG = I.bg; let bgJ = null; if (BG) { const dt = BG.t ? clamp((now - BG.t) / 1000, 0, 0.05) : 0.016; BG.t = now; const tx = P.x + P.tilt * 0.35 + P.lean * 1.2 + P.turn * 5, ty = P.lift - sq * 6;
      [[BG.sx, tx], [BG.sy, ty]].forEach(([s, tg]) => { if (!BG.init) s.p = tg; s.v += ((tg - s.p) * 150 - s.v * 8.5) * dt; s.p += s.v * dt; }); BG.init = true;
      const ox = clamp(BG.sx.p - tx, -6, 6), oy = clamp(BG.sy.p - ty, -5, 5), br = Math.sin(now / 950) * 0.4;
      bgJ = y => { const a = clamp((80 - y) / 62, 0, 1); return [(ox * 1.1 + br) * a * a, -oy * a * 0.35]; }; BG.spl = clamp(+P.split || 0, 0, 1.5); BG.fan = clamp(+P.fan || 0, -1.5, 1.5); BG.shf = clamp(+P.shuf || 0, -1, 1); BG.cl = 5; }
    const bgP = (u, y, w) => { const X = u * cyb + w * syb, Z = -u * syb + w * cyb, j = bgJ(y); let px = 50 + X + j[0], py = 50 + (y - 50) * cp + j[1];
      if (BG.spl > 0.001 || Math.abs(BG.fan) > 0.001 || Math.abs(BG.shf) > 0.001) { const L = BG.cl, Li = Math.floor(L), k = L - 2.5, yc = [76, 64.5, 61, 55.5, 54, 36][Li], a = BG.fan * k * 5 * D2R, c = Math.cos(a), s = Math.sin(a), vx = px - 50, vy = py - yc; px = 50 + vx * c - vy * s + BG.fan * k * 1.5 + BG.shf * (Li % 2 ? 1 : -1) * 6; py = yc + vx * s + vy * c - BG.spl * (L - 2) * 3.2; }
      return glob(px, py); };
    const bgW = (x, y, zm) => { const u = x - 50, R = BG.rT(y); return typeof zm === 'number' ? zm : Math.sqrt(Math.max(0, R * R - u * u)) * (zm === 'b' ? -1 : 1); };
    const sph = BG ? (x, y, zm) => bgP(x - 50, y, bgW(x, y, zm)) : CYL ? (x, y, zm) => { const c = cylIn(x, y, zm); return cylW(c[0], c[1], c[2]); } : (x, y, zm) => { const dx = x - HX, dy = y - HY, z = sz(dx, dy, zm) - ZC, x1 = dx * cyh + z * syh, z1 = -dx * syh + z * cyh + ZC; return headT(HX + x1, HY + dy * cp - z1 * sp); };
    const sphZ = BG ? (x, y, zm) => { const u = x - 50, w = bgW(x, y, zm); return -u * syb + w * cyb; } : CYL ? (x, y, zm) => { const c = cylIn(x, y, zm); return (-c[0] * syh + c[2] * cyh) * ccE; } : (x, y, zm) => { const dx = x - HX, dy = y - HY, z = sz(dx, dy, zm) - ZC, z1 = -dx * syh + z * cyh; return dy * sp + z1 * cp; };
    if (CYL) { const rings = CYL.PR.map(([v, r]) => { const o = []; for (let k = 0; k < 24; k++) { const f = k / 24 * TAU; o.push(cylW(r * Math.sin(f), v, r * Math.cos(f))); } return o; }), hp = H.hull([].concat(...rings));
      CYL.cap = H.closedD(rings[0]); CYL.d = H.closedD(hp); CYL.sh.forEach(s => set(s, 'd', s === CYL.sh[2] ? CYL.cap : CYL.d)); CYL.capV = SM(scE / 0.12);
      let x0 = 1e9, x1 = -1e9, y1 = -1e9; hp.forEach(p => { if (p[0] < x0) x0 = p[0]; if (p[0] > x1) x1 = p[0]; if (p[1] > y1) y1 = p[1]; }); const cc = cylW(0, 0, 0);
      set(CYL.gs, 'x1', r2(x0)); set(CYL.gs, 'x2', r2(x1)); set(CYL.gv, 'y1', r2(cc[1])); set(CYL.gv, 'y2', r2(y1)); set(CYL.gv, 'x1', r2(cc[0])); set(CYL.gv, 'x2', r2(cc[0]));
      const ct = cylW(-12, 0, -8); set(CYL.gt, 'cx', r2(ct[0])); set(CYL.gt, 'cy', r2(ct[1])); set(CYL.gt, 'r', r2((x1 - x0) * 0.55)); }
    const face = (x, y) => sph(x, y), vis = z => SM((z - 1.5) / 6), zc = I.star ? () => SM((cyh * cp - 0.12) / 0.25) : I.dn || I.ck || I.mo || (I.bk && (I.bk.slab || I.bk.kind === 'twisty')) ? () => SM((cyh * cp - 0.04) / 0.2) : (x, y) => vis(sphZ(x, y));
    const zmS = (x, y) => { const dx = x - HX, dy = y - HY, q = SR * SR - dx * dx - dy * dy; return q > 0 ? -0.35 * Math.sqrt(q) : 0; };
    const byw = (x, y, z) => glob(50 + (x - 50) * cyb + (z - ZC) * syb, y), bywZ = (x, z) => -(x - 50) * syb + (z - ZC) * cyb;
    const pf = clamp(P.puff, -0.5, 1.2), MO = g.MO, W = I.W = {}, dtS = I._lt ? clamp((now - I._lt) / 1000, 0, 0.05) : 0.016; I._lt = now;
    if (I.sc) { const S = I.sc, tg = P.x * 1.4 + P.tilt * 0.5 + P.lean * 1.5 + P.turn * 14, ly = P.lift - sq * 8;
      if (S.p == null) { S.p = tg; S.v = 0; S.l = ly; S.lv = 0; } S.v += ((tg - S.p) * 140 - S.v * 7) * dtS; S.p += S.v * dtS; S.lv += ((ly - S.l) * 160 - S.lv * 8) * dtS; S.l += S.lv * dtS;
      S.t = now / 1000; S.jx = clamp(S.p - tg, -14, 14) * 0.55 + Math.sin(now / 640) * 0.8; S.jy = -clamp(S.l - ly, -5, 5) * 0.5 + Math.sin(now / 880) * 0.4; S.rip = 0.3 + clamp(Math.abs(S.v) / 50 + Math.abs(S.lv) / 40, 0, 1) * 0.9;
      const a = (clamp(S.p - tg, -14, 14) * 1.6 + Math.sin(now / 520) * 4) * D2R; S.cc = Math.cos(a); S.cs = Math.sin(a); S.cy = clamp(S.l - ly, -5, 5) * 0.6 + (+P.chb || 0) * 5 + Math.sin(now / 700) * 0.5;
      // waffle lattice: two diagonal helix families (crossing at a 45-degree-ish angle) + horizontal rungs, all wrapping the cone; only the front-facing part is drawn
      let d = '', dh = '';
      const wTrace = (phOf, yLo, yHi, K) => { let pen = false; for (let k = 0; k <= K; k++) { const t = k / K, y = yLo + (yHi - yLo) * t, r = Math.max(0, 19 * (96.5 - y) / 34.5 - 0.5), ph = phOf(y, t);
        if (Math.cos(ph) > 0.1) { const p = glob(50 + r * Math.sin(ph), y), c = pen ? 'L' : 'M'; d += c + r2(p[0]) + ' ' + r2(p[1]); dh += c + r2(p[0] - 0.4) + ' ' + r2(p[1] - 0.4); pen = true; } else pen = false; } };
      for (let f = 0; f < 16; f++) for (const s of [-1, 1]) wTrace(y => f / 16 * TAU + s * (y - 62.5) * 0.085 + yb, 62.5, 89, 40);
      for (let j = 1; j <= 6; j++) wTrace((y, t) => t * TAU + yb, 62.5 + j * 4.1, 62.5 + j * 4.1, 48);
      set(S.wf, 'd', d); set(S.wh, 'd', dh); if (S.gr) { const ga = glob(31, 70), gb = glob(69, 70); set(S.gr, 'x1', r2(ga[0])); set(S.gr, 'y1', r2(ga[1])); set(S.gr, 'x2', r2(gb[0])); set(S.gr, 'y2', r2(gb[1])); } }
    const NS = RK < 1 ? Math.sqrt(cyh * cyh + RK * RK * syh * syh) : 1, nrw = x => HX + (x - HX) * NS, globN = NS < 1 ? (x, y) => glob(nrw(x), y) : glob;
    if (I.hat) { const T = I.hat, ts = now / 1000, ID = (x, y) => [x, y], ha = ((P.earR - P.earL) * 0.35 + Math.sin(ts * 1.7) * 1.5 + clamp(P.htilt, -10, 10) * 0.2) * D2R, ca = Math.cos(ha), sa = Math.sin(ha);
      const HP = (x, y, z) => { const vx = x - 50, vy = y - 40; return sph(50 + vx * ca - vy * sa, 40 + vx * sa + vy * ca, z); }, HZ = (x, y, z) => sphZ(x, y, z), KB = 0.12, RB = 20;
      const pts = []; [32.5, 41.5].forEach(y => { for (let k = 0; k < 24; k++) { const f = k / 24 * TAU, z = RB * Math.cos(f); pts.push(HP(50 + RB * Math.sin(f), y - z * KB, z)); } });
      const bd = H.closedD(H.hull(pts)); set(T.band, 'd', bd); set(T.bsh, 'd', bd); const ga = glob(30, 37), gb = glob(70, 37); set(T.gr, 'x1', r2(ga[0])); set(T.gr, 'y1', r2(ga[1])); set(T.gr, 'x2', r2(gb[0])); set(T.gr, 'y2', r2(gb[1]));
      let pd = ''; for (let i = 0; i < 8; i++) { const f = (i + 0.5) / 8 * TAU, x = 50 + (RB - 0.3) * Math.sin(f), z = (RB - 0.3) * Math.cos(f); if (HZ(x, 37, z) < 3) continue; const a = HP(x, 33.5 - z * KB, z), b = HP(x, 40.5 - z * KB, z); pd += 'M' + r2(a[0]) + ' ' + r2(a[1]) + 'L' + r2(b[0]) + ' ' + r2(b[1]); } set(T.pl, 'd', pd);
      T.L.forEach(o => { const [x, y, z, r] = o.l, C = HP(x, y + Math.sin(ts * 2.1 + x) * 0.25, z); o.dz = HZ(x, y, z); set(o.e, 'd', toD(ellS(C[0], C[1], r * (1 + o.dz / 160), r * (1 + o.dz / 160), 0, 12), ID)); });
      const od = T.L.slice().sort((a, b) => a.dz - b.dz), key2 = od.map(o => T.L.indexOf(o)).join(','); if (key2 !== T.ok) { T.ok = key2; od.forEach(o => T.lg.appendChild(o.e)); }
      const bp = []; T.L.forEach(o => { const [x, y, z, r] = o.l, C = HP(x, y, z); for (let k = 0; k < 12; k++) { const f = k / 12 * TAU; bp.push([C[0] + r * 0.92 * Math.cos(f), C[1] + r * 0.92 * Math.sin(f)]); } }); [-1, 1].forEach(s => bp.push(HP(50 + s * RB, 33 - 0, 0))); set(T.base, 'd', H.closedD(H.hull(bp))); }
    if (I.pn) { const N = I.pn, ts = now / 1000, P3 = (x, y, z) => sph(50 + x, y, z), Z3 = (x, y, z) => sphZ(50 + x, y, z), pt = p => r2(p[0]) + ' ' + r2(p[1]);
      const tg = P.x * 1.4 + P.tilt * 0.5 + P.lean * 1.5 + P.turn * 12, ly = P.lift - sq * 8; if (N.p == null) { N.p = tg; N.v = 0; N.l = ly; N.lv = 0; }
      N.v += ((tg - N.p) * 120 - N.v * 7) * dtS; N.p += N.v * dtS; N.lv += ((ly - N.l) * 140 - N.lv * 7.5) * dtS; N.l += N.lv * dtS; const ox = clamp(N.p - tg, -12, 12), oy = clamp(N.l - ly, -6, 6);
      const hp = []; for (let i = 0; i <= 18; i++) { const y = 32.5 + i / 18 * 60, r = N.rT(y); if (r < 0.3) { hp.push(P3(0, y, 0)); continue; } for (let k = 0; k < 28; k++) { const f = k / 28 * TAU; hp.push(P3(r * Math.sin(f), y, r * Math.cos(f))); } } N.d = H.closedD(H.hull(hp));
      const KK = 1 / 22, DL = TAU / 16, Y0 = 63.5; let dG = '', dH = '';
      for (const s of [-1, 1]) for (let i = 0; i < 16; i++) { let pen = false; for (let k = 0; k <= 30; k++) { const y = 34 + k * 1.95, r = N.rT(y), f = i * DL + s * KK * (y - Y0), X = r * Math.sin(f), Z = r * Math.cos(f);
        if (r > 2 && Z3(X, y, Z) / r > 0.03) { const p = P3(X, y, Z), c = pen ? 'L' : 'M'; dG += c + pt(p); dH += c + r2(p[0] + 0.35) + ' ' + r2(p[1] + 0.45); pen = true; } else pen = false; } }
      set(N.lat, 'd', dG); set(N.latH, 'd', dH);
      let dB = '', dL = '', dD = ''; const tri = (a, b, c) => 'M' + pt(a) + 'L' + pt(b) + 'L' + pt(c) + 'Z';
      for (let m = -6; m <= 6; m++) { const y = Y0 + m * DL / (2 * KK) - 0.8, r = N.rT(y); if (r < 5) continue; const dr = N.rT(y + 0.5) - N.rT(y - 0.5), sc = clamp(r / 22, 0.6, 1), un = Math.hypot(dr, 1), nn = Math.hypot(1, dr);
        for (let i = 0; i < 16; i++) { const f = i * DL + (m + 1) * DL / 2, sf = Math.sin(f), cf = Math.cos(f), S = [r * sf, y, r * cf], n = [sf / nn, -dr / nn, cf / nn], t = [cf, 0, -sf], u = [dr * sf / un, 1 / un, dr * cf / un];
          const A = (k1, k2, k3) => [S[0] + n[0] * k1 + t[0] * k2 + u[0] * k3, S[1] + n[1] * k1 + t[1] * k2 + u[1] * k3, S[2] + n[2] * k1 + t[2] * k2 + u[2] * k3];
          const bl = A(0, -1.9 * sc, 1 * sc), br = A(0, 1.9 * sc, 1 * sc), bm = A(0.3, 0, 0.7 * sc), tp = A(1.9 * sc, 0, -2.4 * sc), zz = Z3(S[0], S[1], S[2]) / r;
          const pl = P3(...bl), pr = P3(...br), pm = P3(...bm), ptp = P3(...tp);
          if (zz > 0.12) { const a = tri(pl, pm, ptp), b = tri(pm, pr, ptp); if (pl[0] <= pr[0]) { dL += a; dD += b; } else { dL += b; dD += a; } } else if (zz > -0.3) dB += tri(pl, pm, ptp) + tri(pm, pr, ptp); } }
      set(N.spB, 'd', dB); set(N.spL, 'd', dL); set(N.spD, 'd', dD);
      const sw = (ox * 1.3 + Math.sin(ts * 0.9) * 2.2 + clamp(P.earR - P.earL, -30, 30) * 0.25 + clamp(P.htilt, -10, 10) * 0.3) * D2R, cw = Math.cos(sw), swn = Math.sin(sw), ls = 1 + oy * 0.025, CBy = 35.2;
      const RO = v => [v[0] * cw - (v[1] - CBy) * swn, CBy + v[0] * swn + (v[1] - CBy) * cw, v[2]], RN = v => [v[0] * cw - v[1] * swn, v[0] * swn + v[1] * cw, v[2]];
      const LT = [-0.45, -0.72, 0.53], SC = v => { const z1 = -v[0] * syb + v[2] * cyb; return [v[0] * cyb + v[2] * syb, v[1] * cp - z1 * sp, v[1] * sp + z1 * cp]; };
      const lit = v => { const q = SC(RN(v)), l = Math.hypot(q[0], q[1], q[2]) || 1, d = (q[0] * LT[0] + q[1] * LT[1] + q[2] * LT[2]) / l; return clamp(0.3 + 0.7 * Math.max(d, -d * 0.8), 0, 1); };
      const col = b => { const A = b < 0.55 ? [[46, 122, 48], [95, 184, 79], b / 0.55] : [[95, 184, 79], [184, 240, 158], (b - 0.55) / 0.45]; return 'rgb(' + A[0].map((c, j) => Math.round(c + (A[1][j] - c) * A[2])).join(',') + ')'; };
      const crw = clamp(+P.crw || 0, -0.5, 1.2), crs = +P.crs || 0; N.LV.forEach(o => { const th = o.th + crs + Math.sin(ts * 0.8 + o.ph) * 0.05 + Math.sin(ts * 9 + o.ph) * 0.03 * Math.max(0, crw), e0 = o.e + crw * (0.35 + o.e * 0.5) + Math.sin(ts * 1.3 + o.ph * 1.7) * 0.04 + oy * 0.012, st = Math.sin(th), ct2 = Math.cos(th), tv = [ct2, 0, -st];
        let x = 1.8 * st, y = CBy, z = 1.8 * ct2; const C3 = [], NO = [], WW = [];
        for (let k = 0; k <= 9; k++) { const s = k / 9; if (k) { const p2 = e0 + o.b * (s - 0.055), dl = o.L * ls / 9; x += Math.sin(p2) * dl * st; z += Math.sin(p2) * dl * ct2; y -= Math.cos(p2) * dl; }
          const p3 = e0 + o.b * s; C3.push([x, y, z]); NO.push([Math.cos(p3) * st, Math.sin(p3), Math.cos(p3) * ct2]); WW.push(o.w * Math.pow(Math.sin(Math.PI * Math.min(1, 0.12 + s * 0.88)), 0.7) * (1 - 0.2 * s)); }
        const PC = C3.map(v => P3(...RO(v))), Lp = [], Rp = []; let gL = null, gR = null;
        for (let k = 0; k <= 9; k++) { const c = PC[k], A0 = PC[Math.max(0, k - 1)], A1 = PC[Math.min(9, k + 1)], tx = A1[0] - A0[0], ty = A1[1] - A0[1], tl = Math.hypot(tx, ty) || 1, nx = -ty / tl, ny = tx / tl, w = WW[k], n = NO[k];
          if (w < 0.05) { Lp.push(c); Rp.push(c); continue; } let mx = -1e9, mn = 1e9, pL = c, pR = c, aL = 0, aR = 0;
          for (let j = 0; j < 8; j++) { const an = j / 8 * TAU, ca = Math.cos(an) * w, sa = Math.sin(an) * w * 0.5, C = C3[k], p = P3(...RO([C[0] + tv[0] * ca + n[0] * sa, C[1] + n[1] * sa, C[2] + tv[2] * ca + n[2] * sa])), d = (p[0] - c[0]) * nx + (p[1] - c[1]) * ny;
            if (d > mx) { mx = d; pL = p; aL = an; } if (d < mn) { mn = d; pR = p; aR = an; } }
          Lp.push(pL); Rp.push(pR); if (k === 4) { const nv = an => [tv[0] * Math.cos(an) + n[0] * 2 * Math.sin(an), n[1] * 2 * Math.sin(an), tv[2] * Math.cos(an) + n[2] * 2 * Math.sin(an)]; gL = [pL, nv(aL)]; gR = [pR, nv(aR)]; o.dz = Z3(...RO(C3[4])); } }
        set(o.bl, 'd', 'M' + Lp.concat(Rp.slice().reverse()).map(pt).join('L') + 'Z'); set(o.rb, 'd', 'M' + PC.slice(1, 8).map(pt).join('L'));
        set(o.gr, 'x1', r2(gL[0][0])); set(o.gr, 'y1', r2(gL[0][1])); set(o.gr, 'x2', r2(gR[0][0])); set(o.gr, 'y2', r2(gR[0][1]));
        const bL = lit(gL[1]), bR = lit(gR[1]), bF = lit(NO[4].map((v, j) => v * 0.4 + (j === 1 ? 0 : 0) )), bM = Math.min(1, Math.max(bL, bR, bF) + 0.12);
        o.st[0].setAttribute('stop-color', col(bL * 0.72)); o.st[1].setAttribute('stop-color', col(bM)); o.st[2].setAttribute('stop-color', col(bR * 0.72)); });
      const od = N.LV.slice().sort((p, q) => p.dz - q.dz), ok = od.map(o => N.LV.indexOf(o) + (o.dz < -1.5 ? 'b' : 'f')).join(','); if (ok !== N.ok) { N.ok = ok; od.forEach(o => (o.dz < -1.5 ? N.crB : N.crF).appendChild(o.g)); } }
    if (I.av) { const A = I.av, ts = now / 1000, P3 = (x, y, z) => sph(50 + x, y, z), NZ = (x, y, z) => sphZ(50 + x, HY + y, z), pt = p => r2(p[0]) + ' ' + r2(p[1]), cv = k => { const v = +P[k]; return v === v ? v : 0; };
      const tg = P.x * 1.4 + P.tilt * 0.5 + P.lean * 1.5 + P.turn * 12, ly = P.lift - sq * 8; if (A.p == null) { A.p = tg; A.v = 0; A.l = ly; A.lv = 0; }
      A.v += ((tg - A.p) * 120 - A.v * 7) * dtS; A.p += A.v * dtS; A.lv += ((ly - A.l) * 140 - A.lv * 7.5) * dtS; A.l += A.lv * dtS; const ox = clamp(A.p - tg, -12, 12), oy = clamp(A.l - ly, -6, 6);
      // round skin silhouette (hull of the body of revolution)
      const hp = []; for (let i = 0; i <= 24; i++) { const y = 12 + 81 * (0.5 - 0.5 * Math.cos(Math.PI * i / 24)), r = A.rT(y); if (r < 0.3) { hp.push(P3(0, y, 0)); continue; } for (let k = 0; k < 30; k++) { const f = k / 30 * TAU; hp.push(P3(r * Math.sin(f), y, r * Math.cos(f))); } }
      A.d = H.closedD(H.hull(hp)); set(A.sk, 'd', A.d);
      // flesh: the front patch of the surface, cut where it turns past the limb
      const vz = (o, f) => NZ(Math.sin(f), -o.dr, Math.cos(f)), Lp = [], Rp = [];
      A.FR.forEach(o => { if (o.F < 1e-3) { if (vz(o, 0) > 0) { const p = P3(0, o.y, o.r); Lp.push(p); Rp.push(p); } return; }
        const n = 16, fv = []; let i0 = -1, i1 = -1; for (let k = 0; k <= n; k++) { const f = -o.F + 2 * o.F * k / n, v = vz(o, f); fv.push([f, v]); if (v > 0) { if (i0 < 0) i0 = k; i1 = k; } } if (i0 < 0) return;
        const bis = (a, b) => { let fa = a[0], fb = b[0]; for (let j = 0; j < 6; j++) { const fm = (fa + fb) / 2; if (vz(o, fm) > 0) fa = fm; else fb = fm; } return (fa + fb) / 2; };
        const fl = i0 > 0 ? bis(fv[i0], fv[i0 - 1]) : fv[0][0], fh = i1 < n ? bis(fv[i1], fv[i1 + 1]) : fv[n][0];
        Lp.push(P3(o.r * Math.sin(fl), o.y, o.r * Math.cos(fl))); Rp.push(P3(o.r * Math.sin(fh), o.y, o.r * Math.cos(fh))); });
      A.dF = Lp.length > 1 ? 'M' + Lp.concat(Rp.reverse()).map(pt).join('L') + 'Z' : 'M0 0Z';
      // pit: a 3D dome in its socket (lags on moves, pops out, rolls, flies when tossed)
      const S = A.S, nn = Math.hypot(1, S.dr), n = [0, -S.dr / nn, 1 / nn], t2 = [0, 1 / nn, S.dr / nn], tz = clamp(cv('pt'), 0, 1), out = tz > 0.001 && tz < 0.999 ? SM(Math.min(tz, 1 - tz) / 0.08) : 0;
      const pp = clamp(cv('pp'), 0, 1.4) + 0.05 * (1 + Math.sin(ts * 1.3)) + clamp(-oy, 0, 6) * 0.04, wb = clamp(cv('prw'), 0, 1.5), ro = cv('pr') * TAU + Math.sin(ts * 0.7) * 0.25 + tz * TAU * 1.5;
      const o = -1.5 + pp * 6 + out * 6, up = 74 * Math.sin(Math.PI * tz), Rp0 = 11 * (1 - 0.07 * out), hz = (5 + clamp(pp, 0, 1) * 3.5) * (1 - out) + Rp0 * out;
      const C = [Math.cos(ro) * 1.4 * wb - ox * 0.1, S.y + Math.sin(ro) * 1.4 * wb + oy * 0.3 - up, S.r + 7 * Math.sin(Math.PI * tz)].map((v, j) => v + n[j] * o);
      const L3 = (a, b, zl) => [C[0] + a, C[1] + t2[1] * b + n[1] * zl, C[2] + t2[2] * b + n[2] * zl], pts = [];
      [0, 0.4, 0.7, 0.9, 1].forEach(zf => { const rr = Rp0 * Math.sqrt(1 - zf * zf); for (let k = 0; k < (zf === 1 ? 1 : 18); k++) { const a = k / 18 * TAU; pts.push(P3(...L3(rr * Math.cos(a), rr * Math.sin(a), zf * hz))); } });
      if (out > 0.01) [0.4, 0.7, 0.9, 1].forEach(zf => { const rr = Rp0 * Math.sqrt(1 - zf * zf); for (let k = 0; k < (zf === 1 ? 1 : 18); k++) { const a = k / 18 * TAU; pts.push(P3(...L3(rr * Math.cos(a), rr * Math.sin(a), -zf * hz * out))); } });
      const nzP = NZ(n[0], n[1], n[2]), pv = Math.max(SM((nzP + 0.14) / 0.12), out); if (A.pit) { set(A.pit, 'd', H.closedD(H.hull(pts))); set(A.pit, 'opacity', r2(pv)); }
      const sv = SM((nzP - 0.05) / 0.25), rimD = R0 => { const q = []; for (let k = 0; k < 22; k++) { const a = k / 22 * TAU, y = S.y + R0 * Math.sin(a), r = A.rT(y), x = clamp(R0 * Math.cos(a), -r, r); q.push(P3(x, y, Math.sqrt(Math.max(0, r * r - x * x)))); } return 'M' + q.map(pt).join('L') + 'Z'; };
      set(A.sock, 'd', rimD(10.8)); set(A.ring, 'd', rimD(11.6)); set(A.sock, 'opacity', r2(sv * clamp((o - 0.5) / 3, 0, 1))); set(A.ring, 'opacity', r2(sv * 0.35));
      const smP = [], cr = Math.cos(ro), sr = Math.sin(ro); for (let k = -6; k <= 6; k++) { const s2 = k / 6 * 0.82, zl = hz * Math.sqrt(Math.max(0, 1 - s2 * s2)); smP.push(P3(...L3(Rp0 * s2 * cr, Rp0 * s2 * sr, zl + 0.15))); }
      set(A.seam, 'd', 'M' + smP.map(pt).join('L')); set(A.seamH, 'd', 'M' + smP.map(p => r2(p[0] + 0.4) + ' ' + r2(p[1] + 0.4)).join('L')); set(A.seam, 'opacity', r2(0.3 * pv)); set(A.seamH, 'opacity', r2(0.3 * pv));
      if (A.shn) { const Cs = L3(-4.2, -4.2, hz * 0.84 + 0.2), sh = []; for (let k = 0; k < 12; k++) { const a = k / 12 * TAU; sh.push(P3(Cs[0] + 3.2 * Math.cos(a), Cs[1] + t2[1] * 3.2 * Math.sin(a), Cs[2] + t2[2] * 3.2 * Math.sin(a))); } set(A.shn, 'd', 'M' + sh.map(pt).join('L') + 'Z'); set(A.shn, 'opacity', r2(0.3 * pv)); }
      A.pc = P3(...L3(0, 0, hz));
      // sprout leaves: cupped 3D blades on the top, swaying on a spring, fluttering, flapping (lfl) and spinning like a propeller (lsp)
      const lsp = cv('lsp') * TAU, lfl = clamp(cv('lfl'), -0.6, 1.3), swz = (ox * 1.6 + Math.sin(ts * 0.9) * 2.5 + clamp(P.htilt || 0, -10, 10) * 0.3) * D2R, swx = (oy * 2.2 + Math.sin(ts * 0.7 + 1) * 1.5) * D2R, B0 = [0, 12.9, 0];
      const LT = [-0.45, -0.72, 0.53], DV = v => { const x1 = v[0] * cyh + v[2] * syh, z1 = -v[0] * syh + v[2] * cyh; return [x1, v[1] * cp - z1 * sp, v[1] * sp + z1 * cp]; };
      const col = b => { const Aa = b < 0.55 ? [[36, 106, 44], [95, 184, 90], b / 0.55] : [[95, 184, 90], [188, 240, 160], (b - 0.55) / 0.45]; return 'rgb(' + Aa[0].map((c, j) => Math.round(c + (Aa[1][j] - c) * Aa[2])).join(',') + ')'; };
      const cz = Math.cos(swz), sz2 = Math.sin(swz), cx2 = Math.cos(swx), sx2 = Math.sin(swx), T = v => { const x = v[0] - B0[0], y = v[1] - B0[1], z = v[2] - B0[2], x1 = x * cz - y * sz2, y1 = x * sz2 + y * cz; return [x1 + B0[0], y1 * cx2 - z * sx2 + B0[1], y1 * sx2 + z * cx2 + B0[2]]; };
      A.LV.forEach((o, i) => { const er = (i ? P.earR : -P.earL) || 0, el = o.el + lfl * 0.55 + Math.sin(ts * 1.7 + o.ph) * 0.05 + Math.sin(ts * 9 + o.ph) * 0.05 * Math.max(0, lfl) + clamp(er, -40, 40) * 0.006 - oy * 0.02, az = o.az + lsp + Math.sin(ts * 0.6 + o.ph) * 0.06;
        const d = [Math.sin(az) * Math.cos(el), -Math.sin(el), Math.cos(az) * Math.cos(el)], sg = o.az > 0 ? 1 : -1, n0 = [-Math.cos(az) * sg, 0, Math.sin(az) * sg], cr0 = [n0[1] * d[2] - n0[2] * d[1], n0[2] * d[0] - n0[0] * d[2], n0[0] * d[1] - n0[1] * d[0]].map(v => v * -sg);
        const M = [], U = [], Dn = []; for (let k = 0; k <= 8; k++) { const u = k / 8, w = o.W * Math.pow(Math.sin(Math.PI * Math.min(1, 0.07 + u * 0.93)), 0.8), bw = 1.6 * Math.sin(Math.PI * u), cu = -1.4 * u * u;
          const m = [0, 1, 2].map(j => B0[j] + d[j] * o.L * u + cr0[j] * bw + (j === 1 ? cu : 0)); M.push(T(m)); U.push(T(m.map((v, j) => v + cr0[j] * w * 1.05 + n0[j] * w * 0.35))); Dn.push(T(m.map((v, j) => v - cr0[j] * w * 0.85 + n0[j] * w * 0.35))); }
        const Mp = M.map(v => P3(...v)), Up = U.map(v => P3(...v)), Dp = Dn.map(v => P3(...v));
        set(o.hU, 'd', 'M' + Mp.concat(Up.slice().reverse()).map(pt).join('L') + 'Z'); set(o.hD, 'd', 'M' + Mp.concat(Dp.slice().reverse()).map(pt).join('L') + 'Z'); set(o.rib, 'd', 'M' + Mp.slice(0, 8).map(pt).join('L'));
        const lit = E => { const a = [M[6][0] - M[2][0], M[6][1] - M[2][1], M[6][2] - M[2][2]], b = [E[4][0] - M[4][0], E[4][1] - M[4][1], E[4][2] - M[4][2]], c = [a[1] * b[2] - a[2] * b[1], a[2] * b[0] - a[0] * b[2], a[0] * b[1] - a[1] * b[0]], v = DV(c), l = Math.hypot(v[0], v[1], v[2]) || 1, s2 = v[2] < 0 ? -1 : 1; return clamp(0.32 + 0.68 * Math.max(0, s2 * (v[0] * LT[0] + v[1] * LT[1] + v[2] * LT[2]) / l), 0, 1); };
        set(o.hU, 'fill', col(lit(U))); set(o.hD, 'fill', col(lit(Dn) * 0.85));
        const bk = sphZ(50 + M[4][0], M[4][1], M[4][2]) < -2; if (o.bk !== bk) { o.bk = bk; (bk ? A.lfB : A.lfF).appendChild(o.g); } }); }
    // Lemmy: 3D lemon - round peel turning round his long axis, pores all round (hide round the back), stem + cupped leaf on top
    if (I.lm) { const A = I.lm, ts = now / 1000, P3 = (x, y, z) => sph(50 + x, y, z), pt = p => r2(p[0]) + ' ' + r2(p[1]), cv = k => { const v = +P[k]; return v === v ? v : 0; };
      const tg = P.x * 1.4 + P.tilt * 0.5 + P.lean * 1.5 + P.turn * 12, ly = P.lift - sq * 8; if (A.p == null) { A.p = tg; A.v = 0; A.l = ly; A.lv = 0; }
      A.v += ((tg - A.p) * 120 - A.v * 7) * dtS; A.p += A.v * dtS; A.lv += ((ly - A.l) * 140 - A.lv * 7.5) * dtS; A.l += A.lv * dtS; const ox = clamp(A.p - tg, -12, 12), oy = clamp(A.l - ly, -6, 6);
      const hp = []; for (let i = 0; i <= 30; i++) { const x = 10.4 + 79.2 * (0.5 - 0.5 * Math.cos(Math.PI * i / 30)), r = A.rX(x); if (r < 0.3) { hp.push(P3(x - 50, A.Yc, 0)); continue; } for (let k = 0; k < 26; k++) { const f = k / 26 * TAU; hp.push(P3(x - 50, A.Yc - r * Math.cos(f), r * Math.sin(f))); } }
      A.d = H.closedD(H.hull(hp));
      let dS = '', dP = ''; A.PO.forEach(o => { const r = A.rX(o.x); if (r < 2) return; const cf = Math.cos(o.f), sf = Math.sin(o.f), dr = A.rX(o.x + 0.5) - A.rX(o.x - 0.5), nl = Math.hypot(dr, 1), n = [-dr / nl, -cf / nl, sf / nl];
        const nz1 = -n[0] * syh + n[2] * cyh, nzz = n[1] * sp + nz1 * cp; if (nzz < 0.12) return;
        const S = [o.x - 50, A.Yc - r * cf, r * sf], t1 = [1, 0, 0], t2 = [0, sf, cf], E = (a, b, k) => pt(P3(S[0] + t1[0] * a + t2[0] * b + n[0] * k, S[1] + t1[1] * a + t2[1] * b + n[1] * k, S[2] + t1[2] * a + t2[2] * b + n[2] * k));
        for (let k = 0; k < 8; k++) { const a = k / 8 * TAU, c = Math.cos(a) * o.s, s = Math.sin(a) * o.s, m = k ? 'L' : 'M'; dP += m + E(c * 1.1 + 0.25, s * 1.1 + 0.25, 0); dS += m + E(c * 0.8, s * 0.8, 0.15); } dP += 'Z'; dS += 'Z'; });
      set(A.dim, 'd', dP || 'M0 0Z'); set(A.poE, 'd', dS || 'M0 0Z');
      const lsp = cv('lsp') * TAU, lfl = clamp(cv('lfl'), -0.6, 1.3), swz = (ox * 1.6 + Math.sin(ts * 0.9) * 2.5 + clamp(P.htilt || 0, -10, 10) * 0.3) * D2R, swx = (oy * 2.2 + Math.sin(ts * 0.7 + 1) * 1.5) * D2R, B0 = [0, 27.5, 0];
      const LT = [-0.45, -0.72, 0.53], DV = v => { const x1 = v[0] * cyh + v[2] * syh, z1 = -v[0] * syh + v[2] * cyh; return [x1, v[1] * cp - z1 * sp, v[1] * sp + z1 * cp]; };
      const col = b => { const Aa = b < 0.55 ? [[44, 120, 46], [118, 200, 88], b / 0.55] : [[118, 200, 88], [204, 246, 158], (b - 0.55) / 0.45]; return 'rgb(' + Aa[0].map((c, j) => Math.round(c + (Aa[1][j] - c) * Aa[2])).join(',') + ')'; };
      const cz = Math.cos(swz), sz2 = Math.sin(swz), cx2 = Math.cos(swx), sx2 = Math.sin(swx), T = v => { const x = v[0] - B0[0], y = v[1] - B0[1], z = v[2] - B0[2], x1 = x * cz - y * sz2, y1 = x * sz2 + y * cz; return [x1 + B0[0], y1 * cx2 - z * sx2 + B0[1], y1 * sx2 + z * cx2 + B0[2]]; };
      A.LV.forEach(o => { const el = Math.min(1.45, o.el + lfl * 0.5 + Math.sin(ts * 1.7 + o.ph) * 0.06 + Math.sin(ts * 9 + o.ph) * 0.05 * Math.max(0, lfl) + clamp(P.earR || 0, -40, 40) * 0.006 - oy * 0.025), az = o.az + lsp + Math.sin(ts * 0.6 + o.ph) * 0.08;
        const d = [Math.sin(az) * Math.cos(el), -Math.sin(el), Math.cos(az) * Math.cos(el)], sg = 1, n0 = [-Math.cos(az) * sg, 0, Math.sin(az) * sg], cr0 = [n0[1] * d[2] - n0[2] * d[1], n0[2] * d[0] - n0[0] * d[2], n0[0] * d[1] - n0[1] * d[0]].map(v => v * -sg);
        const M = [], U = [], Dn = []; for (let k = 0; k <= 8; k++) { const u = k / 8, w = o.W * Math.pow(Math.sin(Math.PI * Math.min(1, 0.07 + u * 0.93)), 0.8), bw = 1.8 * Math.sin(Math.PI * u), cu = -2.2 * u * u;
          const m = [0, 1, 2].map(j => B0[j] + d[j] * o.L * u + cr0[j] * bw + (j === 1 ? cu : 0)); M.push(T(m)); U.push(T(m.map((v, j) => v + cr0[j] * w * 1.05 + n0[j] * w * 0.35))); Dn.push(T(m.map((v, j) => v - cr0[j] * w * 0.85 + n0[j] * w * 0.35))); }
        const Mp = M.map(v => P3(...v)), Up = U.map(v => P3(...v)), Dp = Dn.map(v => P3(...v));
        set(o.hU, 'd', 'M' + Mp.concat(Up.slice().reverse()).map(pt).join('L') + 'Z'); set(o.hD, 'd', 'M' + Mp.concat(Dp.slice().reverse()).map(pt).join('L') + 'Z'); set(o.rib, 'd', 'M' + Mp.slice(1, 8).map(pt).join('L'));
        const lit = E => { const a = [M[6][0] - M[2][0], M[6][1] - M[2][1], M[6][2] - M[2][2]], b = [E[4][0] - M[4][0], E[4][1] - M[4][1], E[4][2] - M[4][2]], c = [a[1] * b[2] - a[2] * b[1], a[2] * b[0] - a[0] * b[2], a[0] * b[1] - a[1] * b[0]], v = DV(c), l = Math.hypot(v[0], v[1], v[2]) || 1, s2 = v[2] < 0 ? -1 : 1; return clamp(0.32 + 0.68 * Math.max(0, s2 * (v[0] * LT[0] + v[1] * LT[1] + v[2] * LT[2]) / l), 0, 1); };
        set(o.hU, 'fill', col(lit(U))); set(o.hD, 'fill', col(lit(Dn) * 0.85));
        const bk = sphZ(50 + M[4][0], M[4][1], M[4][2]) < -2; if (o.bk !== bk) { o.bk = bk; (bk ? A.lfB : A.lfF).appendChild(o.g); } });
      // stem: a short round stalk standing on top of the peel; it wobbles on a spring and boings with stw
      const stw = clamp(cv('stw'), -1, 1.5), a1 = swz * 1.3 + stw * 0.25 * Math.sin(ts * 12), b1 = swx * 1.2, ca = Math.cos(a1), sa = Math.sin(a1), cb = Math.cos(b1), sb = Math.sin(b1), SP = [];
      for (let k = 0; k <= 6; k++) { const s = k / 6, vy = -s * 6.5, x = -0.6 * s * s, x1 = x * ca - vy * sa, y1 = x * sa + vy * ca; SP.push(P3(x1, 31 + y1 * cb, y1 * sb)); }
      const sdP = 'M' + SP.map(pt).join('L'); set(A.st[0], 'd', sdP); set(A.st[1], 'd', sdP); set(A.st[2], 'd', 'M' + SP.slice(1, 6).map(p => r2(p[0] - 0.6) + ' ' + r2(p[1])).join('L'));
      const sv = SM((sphZ(50, 31, 0) + 6) / 6); A.st.forEach(e => set(e, 'opacity', r2(sv))); W.stem = SP[6]; }
    // Kiwi: 3D kiwi - round fuzzy body, fuzz hairs all round (hide round the back, sway, lag and bristle), the belly slice rides on the round front, stem nub on top
    if (I.kw) { const A = I.kw, ts = now / 1000, P3 = (x, y, z) => sph(50 + x, y, z), pt = p => r2(p[0]) + ' ' + r2(p[1]), cv = k => { const v = +P[k]; return v === v ? v : 0; }, NV = n => n[1] * sp + (-n[0] * syh + n[2] * cyh) * cp;
      const tg = P.x * 1.4 + P.tilt * 0.5 + P.lean * 1.5 + P.turn * 12, ly = P.lift - sq * 8; if (A.p == null) { A.p = tg; A.v = 0; A.l = ly; A.lv = 0; }
      A.v += ((tg - A.p) * 120 - A.v * 7) * dtS; A.p += A.v * dtS; A.lv += ((ly - A.l) * 140 - A.lv * 7.5) * dtS; A.l += A.lv * dtS; const ox = clamp(A.p - tg, -12, 12), oy = clamp(A.l - ly, -6, 6);
      const hp = []; for (let i = 0; i <= 24; i++) { const y = 24 + 66 * (0.5 - 0.5 * Math.cos(Math.PI * i / 24)), r = A.rT(y); if (r < 0.3) { hp.push(P3(0, y, 0)); continue; } for (let k = 0; k < 30; k++) { const f = k / 30 * TAU; hp.push(P3(r * Math.sin(f), y, r * Math.cos(f))); } }
      A.d = H.closedD(H.hull(hp));
      const br = Math.max(0, clamp(cv('fzz'), -0.5, 1.6)); let dD = '', dL = '';
      A.FZ.forEach((o, i) => { const r = A.rT(o.y); if (r < 1.5) return; const sf = Math.sin(o.f), cf = Math.cos(o.f), dr = A.dR(o.y), nn = Math.hypot(1, dr), n = [sf / nn, -dr / nn, cf / nn]; if (NV(n) < 0.06) return;
        const u = [dr * sf / nn, 1 / nn, dr * cf / nn], tt = [cf, 0, -sf], S0 = [r * sf, o.y, r * cf], Lh = (1 + 0.6 * o.h) * (1 + 0.8 * br) + 0.3 * br * Math.sin(ts * 30 + o.h * 20), dn = 0.6 * (1 - clamp(br, 0, 1)), wv = 0.3 * Math.sin(ts * 2.1 + o.h * 9 + o.y * 0.2) + (o.h - 0.5) * 0.6;
        const Tp = [0, 1, 2].map(j => S0[j] + n[j] * Lh * 0.8 + u[j] * Lh * dn + tt[j] * wv * Lh); Tp[0] += ox * 0.1; Tp[1] += oy * 0.08; const Mp = [0, 1, 2].map(j => (S0[j] + Tp[j]) / 2);
        dD += 'M' + pt(P3(...S0)) + 'L' + pt(P3(...Tp)); if (i % 3 === 0) dL += 'M' + pt(P3(...Mp)) + 'L' + pt(P3(...Tp)); });
      set(A.fzD, 'd', dD || 'M0 0'); set(A.fzL, 'd', dL || 'M0 0');
      const SY = 75, zS = (x, y) => { const r = A.rT(y); return Math.sqrt(Math.max(0, r * r - x * x)); }, nAt = (x, y) => { const r = A.rT(y) || 1, v = [x / r, -A.dR(y), zS(x, y) / r], l = Math.hypot(v[0], v[1], v[2]) || 1; return [v[0] / l, v[1] / l, v[2] / l]; };
      const svs = SM((NV(nAt(0, SY)) - 0.08) / 0.2); set(A.sg, 'opacity', r2(svs));
      if (svs > 0.01) { const cut = (dx, dy) => { if (NV(nAt(dx, SY + dy)) > 0.02) return [dx, dy]; let lo = 0, hi = 1; for (let j = 0; j < 7; j++) { const m = (lo + hi) / 2; if (NV(nAt(dx * m, SY + dy * m)) > 0.02) lo = m; else hi = m; } return [dx * lo, dy * lo]; };
        const KP = (dx, dy, zo) => { const c = cut(dx, dy); return P3(c[0], SY + c[1], zS(c[0], SY + c[1]) + zo); }, ring = (R, zo, ry) => { const qq = []; for (let k = 0; k < 28; k++) { const a = k / 28 * TAU; qq.push(KP(R * Math.cos(a), (ry || R) * Math.sin(a), zo)); } return 'M' + qq.map(pt).join('L') + 'Z'; }, ok = (dx, dy) => NV(nAt(dx, SY + dy)) > 0.05;
        set(A.S.sh, 'd', ring(14.4, 0.05)); set(A.S.rim, 'd', ring(13.5, 0.35)); set(A.S.fl, 'd', ring(12, 0.5)); set(A.S.core, 'd', ring(3.6, 0.7, 2.6));
        let dr = '', ds = '', dh = ''; const gl = 0.5 + 0.5 * Math.sin(ts * 1.3);
        for (let k = 0; k < 20; k++) { const a = k / 20 * TAU + 0.16, c = Math.cos(a), s = Math.sin(a); if (!ok(10 * c, 10 * s)) continue; dr += 'M' + pt(KP(3.4 * c, 2.6 * s, 0.6)) + 'L' + pt(KP(10.2 * c, 10.2 * s, 0.6)); }
        for (let k = 0; k < 10; k++) { const a = k / 10 * TAU, c = Math.cos(a), s = Math.sin(a), R0 = 6.6; if (!ok(R0 * c, R0 * s)) continue;
          for (let m = 0; m < 10; m++) { const b = m / 10 * TAU, rc = Math.cos(b), rs = Math.sin(b), ra = rc * (rc < 0 ? 1.5 : 1.0), ta = rs * 0.62 * (rc < 0 ? 1 + 0.35 * rc : 1), x = (R0 + ra) * c - ta * s, y = (R0 + ra) * s + ta * c; ds += (m ? 'L' : 'M') + pt(KP(x, y, 0.75)); } ds += 'Z';
          const hx = (R0 + 0.3) * c - 0.25 * s - 0.2, hy = (R0 + 0.3) * s + 0.25 * c - 0.2, hr = 0.22 + 0.12 * gl; dh += 'M' + pt(KP(hx - hr, hy, 0.8)) + 'L' + pt(KP(hx, hy - hr, 0.8)) + 'L' + pt(KP(hx + hr, hy, 0.8)) + 'L' + pt(KP(hx, hy + hr, 0.8)) + 'Z'; }
        set(A.S.ray, 'd', dr || 'M0 0'); set(A.S.sd, 'd', ds || 'M0 0Z'); set(A.S.sdh, 'd', dh || 'M0 0Z'); }
      const swz = (ox * 1.6 + Math.sin(ts * 0.9) * 2.5 + clamp(P.htilt || 0, -10, 10) * 0.3) * D2R, swx = (oy * 2.2 + Math.sin(ts * 0.7 + 1) * 1.5) * D2R;
      const stw = clamp(cv('stw'), -1, 1.5), a1 = swz * 1.3 + stw * 0.25 * Math.sin(ts * 12), b1 = swx * 1.2, ca = Math.cos(a1), sa = Math.sin(a1), cb = Math.cos(b1), sb = Math.sin(b1), SP = [];
      for (let k = 0; k <= 6; k++) { const s = k / 6, vy = -s * 6.5, x = 0.5 * s * s, x1 = x * ca - vy * sa, y1 = x * sa + vy * ca; SP.push(P3(x1, 25 + y1 * cb, y1 * sb)); }
      const sdP = 'M' + SP.map(pt).join('L'); set(A.st[0], 'd', sdP); set(A.st[1], 'd', sdP); set(A.st[2], 'd', 'M' + SP.slice(1, 6).map(p => r2(p[0] - 0.6) + ' ' + r2(p[1])).join('L'));
      W.stem = SP[6]; /* stem is drawn behind the body, so only the body hides it */ }
    // Peachy: 3D peach - round skin with the suture groove (top dips in, crease rides in the groove front and back), stem in the top dip + cupped leaf
    if (I.pe) { const A = I.pe, ts = now / 1000, P3 = (x, y, z) => sph(50 + x, y, z), pt = p => r2(p[0]) + ' ' + r2(p[1]), cv = k => { const v = +P[k]; return v === v ? v : 0; }, NV = n => n[1] * sp + (-n[0] * syh + n[2] * cyh) * cp;
      const tg = P.x * 1.4 + P.tilt * 0.5 + P.lean * 1.5 + P.turn * 12, ly = P.lift - sq * 8; if (A.p == null) { A.p = tg; A.v = 0; A.l = ly; A.lv = 0; }
      A.v += ((tg - A.p) * 120 - A.v * 7) * dtS; A.p += A.v * dtS; A.lv += ((ly - A.l) * 140 - A.lv * 7.5) * dtS; A.l += A.lv * dtS; const ox = clamp(A.p - tg, -12, 12), oy = clamp(A.l - ly, -6, 6);
      const L1 = [], R1 = []; for (let i = 0; i <= 26; i++) { const y = 23.5 + 66.5 * (0.5 - 0.5 * Math.cos(Math.PI * i / 26)); for (let k = 0; k <= 16; k++) { L1.push(P3(...A.SP3(y, Math.PI + k / 16 * Math.PI))); R1.push(P3(...A.SP3(y, k / 16 * Math.PI))); } }
      A.d = H.closedD(H.hull(L1)) + ' ' + H.closedD(H.hull(R1));
      let cD = '', cH = '', pen = false; const cr = (y, f) => { const dr = A.dR(y), nn = Math.hypot(1, dr), cf = Math.cos(f); if (NV([0, -dr / nn, cf / nn]) < 0.03) { pen = false; return; } const p = A.SP3(y, f), h = A.SP3(y, f + (cf > 0 ? 0.035 : -0.035) * (1 + 3 * SM((30 - y) / 6)));
        cD += (pen ? 'L' : 'M') + pt(P3(p[0], p[1], p[2] + 0.15 * cf)); cH += (pen ? 'L' : 'M') + pt(P3(h[0] + 1.1, h[1], h[2] + 0.15 * cf)); pen = true; };
      for (let k = 0; k <= 16; k++) cr(46 - k / 16 * 22.3, 0); pen = false; for (let k = 0; k <= 16; k++) cr(23.7 + k / 16 * 22.3, Math.PI);
      set(A.crD, 'd', cD || 'M0 0'); set(A.crH, 'd', cH || 'M0 0');
      const lsp = cv('lsp') * TAU, lfl = clamp(cv('lfl'), -0.6, 1.3), swz = (ox * 1.6 + Math.sin(ts * 0.9) * 2.5 + clamp(P.htilt || 0, -10, 10) * 0.3) * D2R, swx = (oy * 2.2 + Math.sin(ts * 0.7 + 1) * 1.5) * D2R, B0 = [1.4, 25.2, 0];
      const LT = [-0.45, -0.72, 0.53], DV = v => { const x1 = v[0] * cyh + v[2] * syh, z1 = -v[0] * syh + v[2] * cyh; return [x1, v[1] * cp - z1 * sp, v[1] * sp + z1 * cp]; };
      const col = b => { const Aa = b < 0.55 ? [[44, 120, 46], [118, 200, 88], b / 0.55] : [[118, 200, 88], [204, 246, 158], (b - 0.55) / 0.45]; return 'rgb(' + Aa[0].map((c, j) => Math.round(c + (Aa[1][j] - c) * Aa[2])).join(',') + ')'; };
      const cz = Math.cos(swz), sz2 = Math.sin(swz), cx2 = Math.cos(swx), sx2 = Math.sin(swx), T = v => { const x = v[0] - B0[0], y = v[1] - B0[1], z = v[2] - B0[2], x1 = x * cz - y * sz2, y1 = x * sz2 + y * cz; return [x1 + B0[0], y1 * cx2 - z * sx2 + B0[1], y1 * sx2 + z * cx2 + B0[2]]; };
      A.LV.forEach(o => { const el = Math.min(1.45, o.el + lfl * 0.5 + Math.sin(ts * 1.7 + o.ph) * 0.06 + Math.sin(ts * 9 + o.ph) * 0.05 * Math.max(0, lfl) + clamp(P.earR || 0, -40, 40) * 0.006 - oy * 0.025), az = o.az + lsp + Math.sin(ts * 0.6 + o.ph) * 0.08;
        const d = [Math.sin(az) * Math.cos(el), -Math.sin(el), Math.cos(az) * Math.cos(el)], sg = 1, n0 = [-Math.cos(az) * sg, 0, Math.sin(az) * sg], cr0 = [n0[1] * d[2] - n0[2] * d[1], n0[2] * d[0] - n0[0] * d[2], n0[0] * d[1] - n0[1] * d[0]].map(v => v * -sg);
        const M = [], U = [], Dn = []; for (let k = 0; k <= 8; k++) { const u = k / 8, w = o.W * Math.pow(Math.sin(Math.PI * Math.min(1, 0.07 + u * 0.93)), 0.8), bw = 1.8 * Math.sin(Math.PI * u), cu = -2.2 * u * u;
          const m = [0, 1, 2].map(j => B0[j] + d[j] * o.L * u + cr0[j] * bw + (j === 1 ? cu : 0)); M.push(T(m)); U.push(T(m.map((v, j) => v + cr0[j] * w * 1.05 + n0[j] * w * 0.35))); Dn.push(T(m.map((v, j) => v - cr0[j] * w * 0.85 + n0[j] * w * 0.35))); }
        const Mp = M.map(v => P3(...v)), Up = U.map(v => P3(...v)), Dp = Dn.map(v => P3(...v));
        set(o.hU, 'd', 'M' + Mp.concat(Up.slice().reverse()).map(pt).join('L') + 'Z'); set(o.hD, 'd', 'M' + Mp.concat(Dp.slice().reverse()).map(pt).join('L') + 'Z'); set(o.rib, 'd', 'M' + Mp.slice(1, 8).map(pt).join('L'));
        const lit = E => { const a = [M[6][0] - M[2][0], M[6][1] - M[2][1], M[6][2] - M[2][2]], b = [E[4][0] - M[4][0], E[4][1] - M[4][1], E[4][2] - M[4][2]], c = [a[1] * b[2] - a[2] * b[1], a[2] * b[0] - a[0] * b[2], a[0] * b[1] - a[1] * b[0]], v = DV(c), l = Math.hypot(v[0], v[1], v[2]) || 1, s2 = v[2] < 0 ? -1 : 1; return clamp(0.32 + 0.68 * Math.max(0, s2 * (v[0] * LT[0] + v[1] * LT[1] + v[2] * LT[2]) / l), 0, 1); };
        set(o.hU, 'fill', col(lit(U))); set(o.hD, 'fill', col(lit(Dn) * 0.85));
        const bk = sphZ(50 + M[4][0], M[4][1], M[4][2]) < -2; if (o.bk !== bk) { o.bk = bk; (bk ? A.lfB : A.lfF).appendChild(o.g); } });
      const stw = clamp(cv('stw'), -1, 1.5), a1 = swz * 1.3 + stw * 0.25 * Math.sin(ts * 12), b1 = swx * 1.2, ca = Math.cos(a1), sa = Math.sin(a1), cb = Math.cos(b1), sb = Math.sin(b1), SP = [];
      for (let k = 0; k <= 6; k++) { const s = k / 6, vy = -s * 8, x = 0.5 * s * s, x1 = x * ca - vy * sa, y1 = x * sa + vy * ca; SP.push(P3(x1, 27.6 + y1 * cb, y1 * sb)); }
      const sdP = 'M' + SP.map(pt).join('L'); set(A.st[0], 'd', sdP); set(A.st[1], 'd', sdP); set(A.st[2], 'd', 'M' + SP.slice(1, 6).map(p => r2(p[0] - 0.6) + ' ' + r2(p[1])).join('L'));
      W.stem = SP[6]; /* stem is drawn behind the body, so only the body hides it */ }
    // Pitaya: 3D dragonfruit - round skin, pink bracts with green tips curling out all round (turn with him, the back ones poke out behind, flare with brf), crown of spiky bracts (sway, flare with crw),
    // cupped leaf wings on his sides (always fluttering, flap with wfl, spread with wsp), twinkling sparkles round him (spk)
    if (I.pt) { const A = I.pt, ts = now / 1000, P3 = (x, y, z) => sph(50 + x, y, z), Z3 = (x, y, z) => sphZ(50 + x, y, z), pt = p => r2(p[0]) + ' ' + r2(p[1]), cv = k => { const v = +P[k]; return v === v ? v : 0; };
      const tg = P.x * 1.4 + P.tilt * 0.5 + P.lean * 1.5 + P.turn * 12, ly = P.lift - sq * 8; if (A.p == null) { A.p = tg; A.v = 0; A.l = ly; A.lv = 0; }
      A.v += ((tg - A.p) * 120 - A.v * 7) * dtS; A.p += A.v * dtS; A.lv += ((ly - A.l) * 140 - A.lv * 7.5) * dtS; A.l += A.lv * dtS; const ox = clamp(A.p - tg, -12, 12), oy = clamp(A.l - ly, -6, 6);
      const LT = [-0.45, -0.72, 0.53], DV = v => { const x1 = v[0] * cyh + v[2] * syh, z1 = -v[0] * syh + v[2] * cyh; return [x1, v[1] * cp - z1 * sp, v[1] * sp + z1 * cp]; }, lt = v => { const w = DV(v), l = Math.hypot(w[0], w[1], w[2]) || 1; return (w[0] * LT[0] + w[1] * LT[1] + w[2] * LT[2]) / l; };
      const mx = (a, b, t) => a.map((c, j) => c + (b[j] - c) * clamp(t, 0, 1)), rgb = a => 'rgb(' + a.map(Math.round).join(',') + ')', C3 = (Pl, b) => b < 0.55 ? mx(Pl[0], Pl[1], b / 0.55) : mx(Pl[1], Pl[2], (b - 0.55) / 0.45), GR = [[44, 120, 46], [118, 200, 88], [204, 246, 158]];
      const lit = (M, E) => { const a = [M[6][0] - M[2][0], M[6][1] - M[2][1], M[6][2] - M[2][2]], b = [E[4][0] - M[4][0], E[4][1] - M[4][1], E[4][2] - M[4][2]], c = [a[1] * b[2] - a[2] * b[1], a[2] * b[0] - a[0] * b[2], a[0] * b[1] - a[1] * b[0]], v = DV(c), l = Math.hypot(v[0], v[1], v[2]) || 1, s2 = v[2] < 0 ? -1 : 1; return clamp(0.32 + 0.68 * Math.max(0, s2 * (v[0] * LT[0] + v[1] * LT[1] + v[2] * LT[2]) / l), 0, 1); };
      const swz = (ox * 1.6 + Math.sin(ts * 0.9) * 2.5 + clamp(P.htilt || 0, -10, 10) * 0.3) * D2R, swx = (oy * 2.2 + Math.sin(ts * 0.7 + 1) * 1.5) * D2R, B0 = [0, 25, 0];
      const cz = Math.cos(swz), sz2 = Math.sin(swz), cx2 = Math.cos(swx), sx2 = Math.sin(swx), T = v => { const x = v[0] - B0[0], y = v[1] - B0[1], z = v[2] - B0[2], x1 = x * cz - y * sz2, y1 = x * sz2 + y * cz; return [x1 + B0[0], y1 * cx2 - z * sx2 + B0[1], y1 * sx2 + z * cx2 + B0[2]]; };
      const hp = []; for (let i = 0; i <= 24; i++) { const y = 24 + 66 * (0.5 - 0.5 * Math.cos(Math.PI * i / 24)), r = A.rT(y); if (r < 0.3) { hp.push(P3(0, y, 0)); continue; } for (let k = 0; k < 30; k++) { const f = k / 30 * TAU; hp.push(P3(r * Math.sin(f), y, r * Math.cos(f))); } }
      A.d = H.closedD(H.hull(hp));
      const PK = [[160, 16, 104], [228, 48, 156], [255, 150, 210]], LM = [[70, 160, 54], [168, 236, 106], [226, 255, 190]], ad = (a, b, k) => [a[0] + b[0] * k, a[1] + b[1] * k, a[2] + b[2] * k];
      const brf = clamp(cv('brf'), -0.3, 1.3), crw = clamp(cv('crw'), -0.3, 1.3), wfl = clamp(cv('wfl'), 0, 1.5), wsp = clamp(cv('wsp'), -0.5, 1.3), spk = clamp(cv('spk'), 0, 1.5);
      // one bract: a pointy scale rising from S along up, curling out along out (width along t); pink base fading to a green tip, the half turned from the light shaded so it reads cupped
      const claw = (o, S, up, out, t, L, Wd, cu, wg, TF) => { const Lw = [], Rw = [], Cn = [], tl = Math.hypot(t[0] + out[0] * 0.8, t[1] + out[1] * 0.8, t[2] + out[2] * 0.8) || 1; t = [0, 1, 2].map(j => (t[j] + out[j] * 0.8) / tl); for (let k = 0; k <= 6; k++) { const s = k / 6, w = Wd * (1 - s) * (0.8 + 0.8 * s), c = ad(ad(ad(S, up, L * s), out, L * (0.08 * s + cu * s * s)), t, L * wg * s * s);
          [[Cn, c], [Lw, ad(c, t, -w)], [Rw, ad(c, t, w)]].forEach(([a, v]) => a.push(P3(...(TF ? TF(v) : v)))); }
        set(o.e, 'd', 'M' + Lw.map(pt).join('L') + 'L' + Rw.slice(0, 6).reverse().map(pt).join('L') + 'Z');
        set(o.sh, 'd', 'M' + Cn.map(pt).join('L') + 'L' + (lt(t) > 0 ? Lw : Rw).slice(0, 6).reverse().map(pt).join('L') + 'Z');
        const b = clamp(0.45 + 0.55 * Math.max(0, lt(out) * 0.7 + lt(up) * 0.3), 0, 1), m = o.gk < 0 ? 0.18 : clamp(0.62 - 0.34 * (1 - o.gk), 0.25, 0.62);
        set(o.gr, 'x1', r2(Cn[0][0])); set(o.gr, 'y1', r2(Cn[0][1])); set(o.gr, 'x2', r2(Cn[6][0])); set(o.gr, 'y2', r2(Cn[6][1]));
        set(o.st[0], 'stop-color', rgb(C3(PK, b))); set(o.st[1], 'offset', r2(m)); set(o.st[1], 'stop-color', rgb(C3(LM, b * 0.85))); set(o.st[2], 'stop-color', rgb(C3(LM, b))); };
      const wgl = Math.sin(ts * 1.1) * 0.03 - ox * 0.012;
      A.BR.forEach(o => { const sf = Math.sin(o.f), cf = Math.cos(o.f), nn = Math.hypot(1, o.dr), n = [sf / nn, -o.dr / nn, cf / nn], nz = DV(n)[2];
        if (nz < -0.7) { if (!o.hd) { o.hd = 1; o.g.style.display = 'none'; } return; } if (o.hd) { o.hd = 0; o.g.style.display = ''; }
        const bk = nz < -0.18; if (o.bk !== bk) { o.bk = bk; (bk ? A.bB : A.bF).appendChild(o.g); }
        const up = [-o.dr * sf / nn, -1 / nn, -o.dr * cf / nn], t = [cf, 0, -sf], S = [o.r * sf - n[0] * 0.4, o.y - n[1] * 0.4, o.r * cf - n[2] * 0.4];
        claw(o, S, up, n, t, o.L * (1 + brf * 0.18), o.W, 0.45 + brf * 0.45 + Math.sin(ts * 1.6 + o.ph) * 0.04 - oy * 0.03, wgl + Math.sin(ts * 2.3 + o.ph) * 0.04); });
      A.CR.forEach(o => { const el = Math.min(1.5, o.el - crw * 0.45 + Math.sin(ts * 1.5 + o.ph) * 0.05 - oy * 0.02), az = o.az + Math.sin(ts * 0.6 + o.ph) * 0.06, ca = Math.cos(az), sa = Math.sin(az), h = [sa, 0, ca], up = [sa * Math.cos(el), -Math.sin(el), ca * Math.cos(el)], t = [ca, 0, -sa], S = [sa * 2.2, 26.2, ca * 2.2];
        claw(o, S, up, h, t, o.L * (1 + crw * 0.15), o.W, 0.12 + crw * 0.2, Math.sin(ts * 1.9 + o.ph) * 0.03, T);
        const bk = Z3(...T(ad(S, up, o.L * 0.5))) < -1.5; if (o.bk !== bk) { o.bk = bk; (bk ? A.bB : A.bF).appendChild(o.g); } });
      W.crown = P3(...T([0, 12, 0]));
      // leaf wings: cupped 3D leaves rooted on his sides just behind the middle, always fluttering a little, beating fast with wfl, opening wide with wsp; behind him from the front, in front when that side turns to you
      A.WG.forEach(o => { const sd = o.sd, er = (sd < 0 ? -P.earL : P.earR) || 0, q0 = sd > 0 ? 0.5 : 0, f0 = sd * (Math.PI / 2 + 0.28), r0 = A.rT(47) - 1.5, B = [r0 * Math.sin(f0), 47, r0 * Math.cos(f0)];
        const fp = Math.sin(ts * 2.1 + q0) * 0.08 + wfl * 0.6 * Math.sin(ts * 15 + q0 * 0.5), el = 0.74 + wsp * 0.32 + fp + clamp(er, -40, 40) * 0.006 - oy * 0.035, az = sd * (1.98 - wsp * 0.3 + Math.max(0, fp) * 0.25) - ox * 0.012;
        const d = [Math.sin(az) * Math.cos(el), -Math.sin(el), Math.cos(az) * Math.cos(el)], n0 = [-Math.cos(az) * sd, 0, Math.sin(az) * sd], cr0 = [n0[1] * d[2] - n0[2] * d[1], n0[2] * d[0] - n0[0] * d[2], n0[0] * d[1] - n0[1] * d[0]].map(v => v * -sd);
        const M = [], U = [], Dn = []; for (let k = 0; k <= 8; k++) { const u = k / 8, w = 7.2 * Math.pow(Math.sin(Math.PI * Math.min(1, 0.07 + u * 0.93)), 0.8), bw = 2.2 * Math.sin(Math.PI * u), cu = -2 * u * u;
          const m = [0, 1, 2].map(j => B[j] + d[j] * 31 * u + cr0[j] * bw + (j === 1 ? cu : 0)); M.push(m); U.push(m.map((v, j) => v + cr0[j] * w * 1.05 + n0[j] * w * 0.35)); Dn.push(m.map((v, j) => v - cr0[j] * w * 0.85 + n0[j] * w * 0.35)); }
        const Mp = M.map(v => P3(...v)), Up = U.map(v => P3(...v)), Dp = Dn.map(v => P3(...v)), hf = (a, b) => P3(...a.map((v, j) => (v + b[j]) / 2));
        set(o.hU, 'd', 'M' + Mp.concat(Up.slice().reverse()).map(pt).join('L') + 'Z'); set(o.hD, 'd', 'M' + Mp.concat(Dp.slice().reverse()).map(pt).join('L') + 'Z'); set(o.rib, 'd', 'M' + Mp.slice(0, 8).map(pt).join('L'));
        set(o.vn, 'd', [2, 4, 6].map(k => 'M' + pt(Mp[k]) + 'L' + pt(hf(M[k + 1], U[k + 1])) + 'M' + pt(Mp[k]) + 'L' + pt(hf(M[k + 1], Dn[k + 1]))).join(''));
        set(o.hU, 'fill', rgb(C3(GR, lit(M, U)))); set(o.hD, 'fill', rgb(C3(GR, lit(M, Dn) * 0.85)));
        const bk = Z3(...M[4]) < -1; if (o.bk !== bk) { o.bk = bk; (bk ? A.wB : A.wF).appendChild(o.g); } W[sd < 0 ? 'wingL' : 'wingR'] = Mp[8]; });
      A.ST.forEach(o => { const tw = 0.5 + 0.5 * Math.sin(ts * 2.4 + o.ph), Rr = o.r * (0.6 + 0.4 * tw) * (1 + spk * 0.5), c = glob(o.x + Math.sin(ts * 0.7 + o.ph) * 1.4, o.y + Math.cos(ts * 0.9 + o.ph) * 1.2 - spk * 2), x = r2(c[0]), y = r2(c[1]), q = x + ' ' + y;
        set(o.e, 'd', 'M' + x + ' ' + r2(c[1] - Rr) + 'Q' + q + ' ' + r2(c[0] + Rr) + ' ' + y + 'Q' + q + ' ' + x + ' ' + r2(c[1] + Rr) + 'Q' + q + ' ' + r2(c[0] - Rr) + ' ' + y + 'Q' + q + ' ' + x + ' ' + r2(c[1] - Rr) + 'Z'); set(o.e, 'opacity', r2(0.55 + 0.45 * tw)); }); }
    // Tutti: fruit-basket fairy - round head in a 3D wicker basket (woven bands + slats slide round as she turns, twisted rim), cherry + pear ride in the basket (bounce, tossed with fL/fR),
    // fruit crown on her head (cupped leaves, cherries on stems, orange-slice disc) sways on a spring and bounces (cb), see-through fairy wings flutter behind her (wfl = fast flutter)
    if (I.tu) { const A = I.tu, ts = now / 1000, P3 = (x, y, z) => sph(50 + x, y, z), Z3 = (x, y, z) => sphZ(50 + x, y, z), pt = p => r2(p[0]) + ' ' + r2(p[1]), cv = k => { const v = +P[k]; return v === v ? v : 0; };
      const tg = P.x * 1.4 + P.tilt * 0.5 + P.lean * 1.5 + P.turn * 12, ly = P.lift - sq * 8; if (A.p == null) { A.p = tg; A.v = 0; A.l = ly; A.lv = 0; }
      A.v += ((tg - A.p) * 120 - A.v * 7) * dtS; A.p += A.v * dtS; A.lv += ((ly - A.l) * 140 - A.lv * 7.5) * dtS; A.l += A.lv * dtS; const ox = clamp(A.p - tg, -12, 12), oy = clamp(A.l - ly, -6, 6);
      const LT = [-0.45, -0.72, 0.53], DV = v => { const x1 = v[0] * cyh + v[2] * syh, z1 = -v[0] * syh + v[2] * cyh; return [x1, v[1] * cp - z1 * sp, v[1] * sp + z1 * cp]; }, lt = v => { const w = DV(v), l = Math.hypot(w[0], w[1], w[2]) || 1; return (w[0] * LT[0] + w[1] * LT[1] + w[2] * LT[2]) / l; };
      const mx = (a, b, t) => a.map((c, j) => c + (b[j] - c) * clamp(t, 0, 1)), rgb = a => 'rgb(' + a.map(Math.round).join(',') + ')', C3 = (Pl, b) => b < 0.55 ? mx(Pl[0], Pl[1], b / 0.55) : mx(Pl[1], Pl[2], (b - 0.55) / 0.45), GR = [[44, 120, 46], [118, 200, 88], [204, 246, 158]];
      const lit = (M, E) => { const a = [M[6][0] - M[2][0], M[6][1] - M[2][1], M[6][2] - M[2][2]], b = [E[4][0] - M[4][0], E[4][1] - M[4][1], E[4][2] - M[4][2]], c = [a[1] * b[2] - a[2] * b[1], a[2] * b[0] - a[0] * b[2], a[0] * b[1] - a[1] * b[0]], v = DV(c), l = Math.hypot(v[0], v[1], v[2]) || 1, s2 = v[2] < 0 ? -1 : 1; return clamp(0.32 + 0.68 * Math.max(0, s2 * (v[0] * LT[0] + v[1] * LT[1] + v[2] * LT[2]) / l), 0, 1); };
      const swz = (ox * 1.6 + Math.sin(ts * 0.9) * 2.5 + clamp(P.htilt || 0, -10, 10) * 0.3) * D2R, swx = (oy * 2.2 + Math.sin(ts * 0.7 + 1) * 1.5) * D2R, B0 = [0, 25, 0];
      const cz = Math.cos(swz), sz2 = Math.sin(swz), cx2 = Math.cos(swx), sx2 = Math.sin(swx), T = v => { const x = v[0] - B0[0], y = v[1] - B0[1], z = v[2] - B0[2], x1 = x * cz - y * sz2, y1 = x * sz2 + y * cz; return [x1 + B0[0], y1 * cx2 - z * sx2 + B0[1], y1 * sx2 + z * cx2 + B0[2]]; };
      const KB = A.KB, Qb = (a, b, c, s) => (1 - s) * (1 - s) * a + 2 * (1 - s) * s * b + s * s * c, VP = (x, y, z) => { const p = P3(x, y, z); return [p[0], p[1] - 0.13 * (Z3(x, y, z) - Z3(0, y, 0))]; };
      const cP = (x, y, r) => 'M' + r2(x - r) + ' ' + r2(y) + 'A' + r2(r) + ' ' + r2(r) + ' 0 1 0 ' + r2(x + r) + ' ' + r2(y) + 'A' + r2(r) + ' ' + r2(r) + ' 0 1 0 ' + r2(x - r) + ' ' + r2(y) + 'Z', eP = (x, y, a, b) => 'M' + r2(x - a) + ' ' + r2(y) + 'A' + r2(a) + ' ' + r2(b) + ' 0 1 0 ' + r2(x + a) + ' ' + r2(y) + 'A' + r2(a) + ' ' + r2(b) + ' 0 1 0 ' + r2(x - a) + ' ' + r2(y) + 'Z';
      // basket: round wicker body (seen from a touch below like the art, so the rim bows up), cylinder shading, woven bands + slats on the front half, twisted rim band
      const Bk = A.bask, hp = []; for (let i = 0; i <= 12; i++) { const y = 61.5 + 29.5 * i / 12, r = A.rB(y); if (r < 0.3) { hp.push(VP(0, y, 0)); continue; } for (let k = 0; k < 28; k++) { const f = k / 28 * TAU; hp.push(VP(r * Math.sin(f), y, KB * r * Math.cos(f))); } }
      const bd = H.closedD(H.hull(hp)); let x0 = 1e9, x1 = -1e9; hp.forEach(p => { if (p[0] < x0) x0 = p[0]; if (p[0] > x1) x1 = p[0]; }); set(Bk.body, 'd', bd); set(Bk.sh, 'd', bd); set(Bk.gr, 'x1', r2(x0)); set(Bk.gr, 'x2', r2(x1));
      const f0 = Math.atan2(-syh, KB * cyh), fz = (r, y, f) => Z3(r * Math.sin(f), y, KB * r * Math.cos(f)) - Z3(0, y, 0);
      let wv = ''; [70.5, 79].forEach(y => { const r = A.rB(y) + 0.1; for (let i = 0; i <= 32; i++) { const f = f0 - Math.PI / 2 + i / 32 * Math.PI; wv += (i ? 'L' : 'M') + pt(VP(r * Math.sin(f), y, KB * r * Math.cos(f))); } });
      for (let k = 0; k < 18; k++) { const f = k / 18 * TAU + 0.17; if (fz(30, 76, f) < 2.5) continue; const s = Math.sin(f), c = Math.cos(f); for (let j = 0; j <= 5; j++) { const y = 64.5 + j * 5, r = A.rB(y) + 0.1; wv += (j ? 'L' : 'M') + pt(VP(r * s, y, KB * r * c)); } }
      set(Bk.wv, 'd', wv);
      const Rr = 34.2, Yr = 62.3, tp = [], bt = [], hl = []; for (let i = 0; i <= 36; i++) { const f = f0 - Math.PI / 2 + i / 36 * Math.PI, s = Math.sin(f), c = Math.cos(f); tp.push(VP(Rr * s, Yr - 3.4, KB * Rr * c)); bt.push(VP(Rr * s, Yr + 3.4, KB * Rr * c)); if (i > 3 && i < 33) hl.push(VP(Rr * s, Yr - 2.3, KB * Rr * c + 0.5)); }
      set(Bk.rim, 'd', 'M' + tp.map(pt).join('L') + 'L' + bt.reverse().map(pt).join('L') + 'Z'); set(Bk.hl, 'd', 'M' + hl.map(pt).join('L'));
      let tw = ''; for (let k = 0; k < 44; k++) { const f = k / 44 * TAU; if (fz(Rr, Yr, f) < 4) continue; tw += 'M' + pt(VP(Rr * Math.sin(f - 0.04), Yr - 3, KB * Rr * Math.cos(f - 0.04) + 0.3)) + 'L' + pt(VP(Rr * Math.sin(f + 0.04), Yr + 3, KB * Rr * Math.cos(f + 0.04) + 0.3)); } set(Bk.tw, 'd', tw || 'M0 0');
      // fairy wings: thin see-through membranes hinged behind her head, always fluttering (fast with wfl), the sheen changes as they turn; behind her head from the front, in front when that side turns to you
      const wfl = clamp(cv('wfl'), 0, 1.5);
      A.WG.forEach(o => { const sd = o.sd, er = (sd < 0 ? -P.earL : P.earR) || 0, q0 = sd > 0 ? 0.5 : 0, phi = 0.42 + Math.sin(ts * 6.5 + q0) * 0.2 * (1 - 0.5 * Math.min(1, wfl)) + wfl * 0.5 * Math.sin(ts * 26 + q0) + clamp(er, -40, 40) * 0.006 - oy * 0.04, cf = Math.cos(phi), sf = Math.sin(phi);
        const WP = (u, v) => [sd * (17 + u * 1.05 * cf), 46 + v * 1.05 + u * u * 0.004 * Math.sin(ts * 3 + q0), -10 - u * 1.05 * sf];
        set(o.e, 'd', 'M' + A.WL.map(([u, v]) => pt(P3(...WP(u, v)))).join('L') + 'Z');
        set(o.vn, 'd', 'M' + [[1, -1], [9, -7], [17, -11], [24, -12]].map(([u, v]) => pt(P3(...WP(u, v)))).join('L') + 'M' + [[1, 2], [10, 3.5], [20, 4.2]].map(([u, v]) => pt(P3(...WP(u, v)))).join('L'));
        const nz = Math.abs(DV([sf, 0, sd * cf])[2]); set(o.e, 'opacity', r2(0.62 + 0.28 * nz)); set(o.vn, 'opacity', r2(0.45 + 0.4 * nz));
        const bk = Z3(...WP(14, -6)) < -1; if (o.bk !== bk) { o.bk = bk; (bk ? A.wgB : A.wgF).appendChild(o.g); } W[sd < 0 ? 'wingL' : 'wingR'] = P3(...WP(26, -12)); });
      // fruit crown: two cupped leaves, a cherry pair on stems and an orange-slice disc on top of her head, swaying on a spring and bouncing with cb; parts that turn behind her head go behind it
      const cbv = clamp(cv('cb'), 0, 1.5), hop = cbv * 2.6 * Math.abs(Math.sin(ts * 9)), LB = [0, 25.6, 1.5];
      A.LV.forEach(o => { const er = (o.az > 0 ? P.earR : -P.earL) || 0, el = o.el + Math.sin(ts * 1.7 + o.ph) * 0.05 + clamp(er, -40, 40) * 0.006 - oy * 0.03 + cbv * 0.15 * Math.sin(ts * 9 + o.ph), az = o.az + Math.sin(ts * 0.6 + o.ph) * 0.06;
        const d = [Math.sin(az) * Math.cos(el), -Math.sin(el), Math.cos(az) * Math.cos(el)], sg = o.az > 0 ? 1 : -1, n0 = [-Math.cos(az) * sg, 0, Math.sin(az) * sg], cr0 = [n0[1] * d[2] - n0[2] * d[1], n0[2] * d[0] - n0[0] * d[2], n0[0] * d[1] - n0[1] * d[0]].map(v => v * -sg);
        const M = [], U = [], Dn = []; for (let k = 0; k <= 8; k++) { const u = k / 8, w = o.W * Math.pow(Math.sin(Math.PI * Math.min(1, 0.07 + u * 0.93)), 0.8), bw = 1.4 * Math.sin(Math.PI * u), cu = 1.4 * u * u;
          const m = [0, 1, 2].map(j => LB[j] + d[j] * o.L * u + cr0[j] * bw + (j === 1 ? cu : 0)); M.push(T(m)); U.push(T(m.map((v, j) => v + cr0[j] * w * 1.05 + n0[j] * w * 0.35))); Dn.push(T(m.map((v, j) => v - cr0[j] * w * 0.85 + n0[j] * w * 0.35))); }
        const Mp = M.map(v => P3(...v)), Up = U.map(v => P3(...v)), Dp = Dn.map(v => P3(...v));
        set(o.hU, 'd', 'M' + Mp.concat(Up.slice().reverse()).map(pt).join('L') + 'Z'); set(o.hD, 'd', 'M' + Mp.concat(Dp.slice().reverse()).map(pt).join('L') + 'Z'); set(o.rib, 'd', 'M' + Mp.slice(0, 8).map(pt).join('L'));
        set(o.hU, 'fill', rgb(C3(GR, lit(M, U)))); set(o.hD, 'fill', rgb(C3(GR, lit(M, Dn) * 0.85)));
        const bk = Z3(...M[4]) < -3; if (o.bk !== bk) { o.bk = bk; (bk ? A.crB : A.crF).appendChild(o.g); } });
      const CC = A.CH.map((o, i) => { const C = T([o.x + Math.sin(ts * 1.3 + i * 2) * 0.25, o.y - hop * (i ? 0.8 : 1) + oy * 0.25, o.z]), p = P3(...C); set(o.e, 'd', cP(p[0], p[1], o.r)); set(o.gl, 'd', eP(p[0] - o.r * 0.35, p[1] - o.r * 0.4, o.r * 0.3, o.r * 0.2)); return C; });
      { const J = T([Math.sin(ts * 1.1) * 0.5 - ox * 0.12, 11 - hop * 0.6, 1.5]); let sd = ''; A.CH.forEach((o, i) => { const C = CC[i], s0 = [C[0] + 0.6, C[1] - o.r * 0.6, C[2]], Tc = T([i ? -2 : -6, (i ? 15 : 13) - hop * 0.7, 2.2]);
          for (let k = 0; k <= 6; k++) { const s = k / 6; sd += (k ? 'L' : 'M') + pt(P3(...[0, 1, 2].map(j => Qb(s0[j], Tc[j], J[j], s)))); } }); set(A.stm, 'd', sd);
        const bk = Z3(...CC[0]) + Z3(...CC[1]) < -6; if (A.cbk !== bk) { A.cbk = bk; (bk ? A.crB : A.crF).appendChild(A.cg); } }
      { const O = A.OR, c = O.c, wq = Math.sin(ts * 1.2) * 0.18 + ox * 0.02, cw = Math.cos(wq), sw = Math.sin(wq), cy0 = c[1] - hop * 0.7 + oy * 0.2, F = (a, rr, zz) => P3(...T([c[0] + rr * Math.cos(a) * cw + zz * sw, cy0 + rr * Math.sin(a), c[2] - rr * Math.cos(a) * sw + zz * cw]));
        const fF = Z3(...T([c[0] + O.th * sw, cy0, c[2] + O.th * cw])) >= Z3(...T([c[0] - O.th * sw, cy0, c[2] - O.th * cw])) ? 1 : -1, zf = fF * O.th / 2, ring = (rr, zz) => { const o = []; for (let k = 0; k < 20; k++) o.push(F(k / 20 * TAU, rr, zz)); return o; };
        set(O.edge, 'd', H.closedD(H.hull(ring(O.r, O.th / 2).concat(ring(O.r, -O.th / 2))))); set(O.rind, 'd', 'M' + ring(O.r, zf).map(pt).join('L') + 'Z'); set(O.fl, 'd', 'M' + ring(4.8, zf * 1.02).map(pt).join('L') + 'Z');
        let sgd = ''; for (let k = 0; k < 4; k++) { const a = k / 4 * Math.PI; sgd += 'M' + pt(F(a, 4.4, zf * 1.04)) + 'L' + pt(F(a + Math.PI, 4.4, zf * 1.04)); } set(O.sg, 'd', sgd);
        const cc = F(0, 0, zf); set(O.gl, 'd', eP(cc[0] - 2.2, cc[1] - 2.4, 1.3, 0.8));
        const bk = Z3(...T([c[0], cy0, c[2]])) < -3; if (O.bk !== bk) { O.bk = bk; (bk ? A.crB : A.crF).appendChild(O.g); } }
      // basket fruits: a cherry and a pear sitting in the basket, bobbing and bouncing on a spring as she moves, tossed up and spun with fL / fR; the one that turns to the back goes behind her head
      const fT = [clamp(cv('fL'), 0, 1), clamp(cv('fR'), 0, 1)];
      A.FR.forEach((o, i) => { const f = fT[i], ar = Math.sin(Math.PI * f), up = 48 * ar, bob = Math.sin(ts * 1.7 + i * 2) * 0.45 + oy * 0.55 * (1 - ar), C = [o.x * (1 - 0.12 * ar) - ox * 0.08, o.y - up + bob, 6 * ar], p = P3(...C), r = o.r;
        set(o.e, 'd', cP(p[0], p[1], r)); set(o.gl, 'd', eP(p[0] - r * 0.36, p[1] - r * 0.4, r * 0.32, r * 0.2));
        const sa = Math.sin(ts * 2 + i) * 0.1 + f * TAU * 1.5 * o.sd, ca = Math.cos(sa), sn = Math.sin(sa), kx = o.sd * (0.4 + 0.6 * Math.abs(cyh)), R2 = (x, y) => { const vy = y - r + 0.8; return [p[0] + x * ca - vy * sn, p[1] + x * sn + vy * ca]; };
        set(o.st, 'd', 'M' + pt(R2(0, 0)) + 'Q' + pt(R2(kx, -3)) + ' ' + pt(R2(kx * 3, -4)));
        const bk = Z3(...C) < -1; if (o.bk !== bk) { o.bk = bk; (bk ? A.frB : A.frF).appendChild(o.g); } W[i ? 'fruitR' : 'fruitL'] = p; }); }
    // Melo: 3D watermelon slice - rounded slab hull, rind face + white rind + pillowy flesh on whichever face looks at you, seeds in the flesh, rind stripes wrap over the edge
    if (I.mo) { const C = I.mo, A = C, Dh = C.Dh, ts = now / 1000, pt = p => r2(p[0]) + ' ' + r2(p[1]), cv = k => { const v = +P[k]; return v === v ? v : 0; }, NV = n => n[1] * sp + (-n[0] * syh + n[2] * cyh) * cp, fz = NV([0, 0, 1]) >= 0 ? 1 : -1, PL = a => a.map((p, k) => (k ? 'L' : 'M') + pt(p)).join('') + 'Z';
      const tg = P.x * 1.4 + P.tilt * 0.5 + P.lean * 1.5 + P.turn * 12, ly = P.lift - sq * 8; if (A.p == null) { A.p = tg; A.v = 0; A.l = ly; A.lv = 0; }
      A.v += ((tg - A.p) * 120 - A.v * 7) * dtS; A.p += A.v * dtS; A.lv += ((ly - A.l) * 140 - A.lv * 7.5) * dtS; A.l += A.lv * dtS; const ox = clamp(A.p - tg, -12, 12), oy = clamp(A.l - ly, -6, 6);
      const pp = [], b = C.bv; for (let k = 0; k <= 3; k++) { const th = k / 6 * Math.PI, z = Dh - b + b * Math.sin(th); C.ol(b * (1 - Math.cos(th))).forEach(p => { pp.push(sph(p[0], p[1], z)); pp.push(sph(p[0], p[1], -z)); }); }
      for (let k = 0; k < 12; k++) { const a = k / 12 * TAU, x = 50 + 20 * Math.cos(a), y = 63 + 15 * Math.sin(a), z = C.zF(x, y); pp.push(sph(x, y, z)); pp.push(sph(x, y, -z)); }
      C.d = PL(H.hull(pp));
      const pan = (ins, zo, dm) => PL(C.ol(ins).map(p => sph(p[0], p[1], fz * (Dh + zo + (dm ? C.DM * C.q(p[0], p[1]) : 0)))));
      const panT = (ins, iT, zo, dm) => PL(C.ol(ins, iT).map(p => sph(p[0], p[1], fz * (Dh + zo + (dm ? C.DM * C.q(p[0], p[1]) : 0)))));
      set(C.rf, 'd', pan(1.3, -0.3)); set(C.wr, 'd', panT(2.6, 0.2, 0.05, 1)); set(C.fl, 'd', panT(4.8, 0.3, 0.15, 1));
      { const tq = []; let ds = ''; for (let i = 1; i < 16; i++) { const p = C.OL[i], n2 = C.NO[i]; for (let k = 0; k <= 6; k++) { const th = k / 6 * Math.PI, zz = (Dh - b + b * Math.sin(th)) * (k < 3 ? 1 : 1), rr = b * (1 - Math.sin(th)) * 0; tq.push(sph(p[0], p[1], zz)); tq.push(sph(p[0], p[1], -zz)); } tq.push(sph(p[0] - n2[0] * 0.3, p[1] - n2[1] * 0.3, Dh + C.DM * C.q(p[0], p[1]))); tq.push(sph(p[0] - n2[0] * 0.3, p[1] - n2[1] * 0.3, -(Dh + C.DM * C.q(p[0], p[1])))); }
        set(C.tp, 'd', PL(H.hull(tq)));
        [[30, -0.45], [50, 0.3], [70, -0.2]].forEach(([x, zf]) => { const y = 33.3 + 0.0006 * (x - 50) * (x - 50) * 6, z = zf * Dh; for (let m = 0; m < 8; m++) { const a = m / 8 * TAU; ds += (m ? 'L' : 'M') + pt(sph(x + 1.6 * Math.cos(a), y - 0.15, z + 0.9 * Math.sin(a))); } ds += 'Z'; }); set(C.tsd, 'd', ds); }
      const prof = []; for (let k = 3; k >= 0; k--) { const th = k / 6 * Math.PI; prof.push([b * (1 - Math.cos(th)) * (k === 3 ? 0.8 : 1), Dh - b + b * Math.sin(th), Math.cos(th), Math.sin(th)]); } const PF = prof.concat([[0, 0, 1, 0]], prof.slice().reverse().map(v => [v[0], -v[1], v[2], -v[3]]));
      let dS = ''; C.SI.forEach((i, si) => { const p = C.OL[i], n2 = C.NO[i]; let on = false; PF.forEach(v => { const nv = [n2[0] * v[2], n2[1] * v[2], v[3]]; if (NV(nv) < 0.02) { on = false; return; } const wg = 0.7 * Math.sin(v[1] * 0.45 + si * 1.7), x = p[0] - n2[0] * v[0] - n2[1] * wg, y = p[1] - n2[1] * v[0] + n2[0] * wg; dS += (on ? 'L' : 'M') + pt(sph(x, y, v[1])); on = true; }); });
      set(C.str, 'd', dS || 'M0 0');
      const jg = clamp(cv('sdj'), 0, 1.5); let dS2 = '', dH2 = '';
      C.SD.forEach((s, i) => { const wj = jg * 0.5 * Math.sin(ts * 26 + i * 1.9) - ox * 0.05, hj = jg * 0.4 * Math.cos(ts * 23 + i * 2.3) - oy * 0.08, x = s[0] + wj, y = s[1] + hj, ux = 50 - s[0], uy = 30 - s[1], ul = Math.hypot(ux, uy) || 1, u = [ux / ul, uy / ul], v = [-u[1], u[0]], z = fz * (C.zF(x, y) + 0.3 + jg * 0.4);
        for (let m = 0; m < 10; m++) { const bb = m / 10 * TAU, rc = Math.cos(bb), al = rc * (rc > 0 ? 2.0 : 1.25), pe = Math.sin(bb) * 0.85 * (rc > 0 ? 1 - 0.5 * rc : 1); dS2 += (m ? 'L' : 'M') + pt(sph(x + u[0] * al + v[0] * pe, y + u[1] * al + v[1] * pe, z)); } dS2 += 'Z';
        const hx = x - u[0] * 0.3 - 0.35, hy = y - u[1] * 0.3 - 0.35; dH2 += 'M' + pt(sph(hx, hy - 0.35, z)) + 'L' + pt(sph(hx + 0.35, hy, z)) + 'L' + pt(sph(hx, hy + 0.35, z)) + 'L' + pt(sph(hx - 0.35, hy, z)) + 'Z'; });
      set(C.sd, 'd', dS2); set(C.sdh, 'd', dH2); }
    // Dreamland batch 2: 3D tubes, balls, hinged membranes and flames (see setup), fur clumps for Floof, glow for Ember, smoke puffs for Drako
    if (I.dl) { const D = I.dl, ts = now / 1000, cv = k => { const v = +P[k]; return v === v ? v : 0; }, pt = p => r2(p[0]) + ' ' + r2(p[1]);
      const tg = P.x * 1.4 + P.tilt * 0.5 + P.lean * 1.5 + P.turn * 12, ly = P.lift - sq * 8; if (D.p == null) { D.p = tg; D.v = 0; D.l = ly; D.lv = 0; }
      D.v += ((tg - D.p) * 120 - D.v * 7) * dtS; D.p += D.v * dtS; D.lv += ((ly - D.l) * 140 - D.lv * 7.5) * dtS; D.l += D.lv * dtS; const ox = clamp(D.p - tg, -12, 12), oy = clamp(D.l - ly, -6, 6), S = { ts, ox, oy, cv, P };
      const PJ = (p, h) => h ? sph(p[0], p[1], p[2]) : byw(p[0], p[1], p[2]), ZJ = (p, h) => h ? sphZ(p[0], p[1], p[2]) : bywZ(p[0], p[2]);
      const sortG = (o, z) => { const fr = z > (o.zt || 0); if (o.fr !== fr) { o.fr = fr; (fr ? D.gF : o.h && !o.bb ? D.gB : D.gBB).appendChild(o.g); } }; // body parts go behind the whole body, head parts just behind the head
      const sub = (a, b) => [a[0] - b[0], a[1] - b[1], a[2] - b[2]], nrm = v => { const l = Math.hypot(v[0], v[1], v[2]) || 1; return [v[0] / l, v[1] / l, v[2] / l]; }, crs = (a, b) => [a[1] * b[2] - a[2] * b[1], a[2] * b[0] - a[0] * b[2], a[0] * b[1] - a[1] * b[0]], ad = (p, v, k) => [p[0] + v[0] * k, p[1] + v[1] * k, p[2] + v[2] * k];
      const mkP = (a, pp) => { const e = document.createElementNS('http://www.w3.org/2000/svg', 'path'); for (const k in a) e.setAttribute(k, a[k]); pp.appendChild(e); return e; };
      // Ember: fire strength for his flames + embers (stronger with cfl, calm when asleep)
      if (D.key === 'ember') D.fire = (0.9 + clamp(cv('cfl'), 0, 1.5) * 0.55) * (I.cur && /sleep/.test(I.cur.name || '') ? 0.4 : 1);
      // Drako: tail pose for this frame (idle swish + tsw, curl up with tcu, tip wag, drags behind moves and jumps)
      if (D.tk) { const k = D.tk; k.a = Math.sin(ts * 1.5) * 0.2 + Math.sin(ts * 0.55) * 0.08 + clamp(cv('tsw'), -1.6, 1.6) * 0.55 + clamp(+P.wag || 0, -40, 40) * 0.01 + ox * 0.035; k.cu = clamp(cv('tcu'), -0.3, 1.3); k.tw = Math.sin(ts * 3.2) * 0.22 + clamp(cv('tcu'), 0, 1) * Math.sin(ts * 9) * 0.25; k.ly = -oy * 0.9; }
      D.T.forEach(o => { const N = o.n || 8, C = [], WW = [], TH = [], nf = o.nf || [0, 0, 1]; for (let i = 0; i <= N; i++) { const s = i / N, c = o.sp(s, S); C.push([50 + c[0], c[1], c[2]]); WW.push(o.w(s)); TH.push(o.th ? o.th(s) : o.w(s)); }
        const RG = [], FR = []; for (let i = 0; i <= N; i++) { const T = nrm(sub(C[Math.min(N, i + 1)], C[Math.max(0, i - 1)])), wv = nrm(crs(T, nf)), tv = crs(wv, T), ring = []; FR.push({ wv, tv }); for (let k = 0; k < 12; k++) { const f = k / 12 * TAU; ring.push(PJ(ad(ad(C[i], wv, WW[i] * Math.cos(f)), tv, TH[i] * Math.sin(f)), o.h)); } RG.push(ring); }
        let d = ''; for (let i = 0; i < N; i++) d += H.closedD(H.hull(RG[i].concat(RG[i + 1]))); set(o.e, 'd', d);
        if (o.ie) { const U = [], Dn = []; let vis2 = 0; for (let i = 1; i < N; i++) { const F2 = FR[i], k = o.ik || 0.55; U.push(PJ(ad(ad(C[i], F2.wv, WW[i] * k), F2.tv, TH[i]), o.h)); Dn.push(PJ(ad(ad(C[i], F2.wv, -WW[i] * k), F2.tv, TH[i]), o.h)); vis2 += ZJ(ad(C[i], F2.tv, 1), o.h) - ZJ(C[i], o.h); }
          set(o.ie, 'd', 'M' + U.concat(Dn.reverse()).map(pt).join('L') + 'Z'); set(o.ie, 'opacity', r2((o.io || 0.85) * SM(vis2 / (N - 1) * 3))); }
        if (o.ge) { let gd = ''; [0, Math.PI].forEach(a0 => { let pen = false; for (let j = 0; j <= 28; j++) { const s = j / 28, i = Math.min(N - 1, Math.floor(s * N)), u = s * N - i, Cc = ad(C[i], sub(C[i + 1], C[i]), u), w = WW[i] + (WW[i + 1] - WW[i]) * u, a = a0 + s * TAU * 3.2, F2 = FR[i], Pp = ad(ad(Cc, F2.wv, w * 1.02 * Math.cos(a)), F2.tv, w * 1.02 * Math.sin(a));
            if (ZJ(Pp, o.h) - ZJ(Cc, o.h) > w * 0.15) { gd += (pen ? 'L' : 'M') + pt(PJ(Pp, o.h)); pen = true; } else pen = false; } }); set(o.ge, 'd', gd || 'M0 0'); }
        if (o.eye) { if (!o.ee) { o.ee = document.createElementNS('http://www.w3.org/2000/svg', 'path'); o.ee.setAttribute('fill', o.eye); o.g.appendChild(o.ee); } const i2 = Math.round(N * o.eyeS), p = PJ(C[i2], o.h), r = WW[i2] * 0.42; set(o.ee, 'd', 'M' + r2(p[0] - r) + ' ' + r2(p[1]) + 'A' + r2(r) + ' ' + r2(r) + ' 0 1 0 ' + r2(p[0] + r) + ' ' + r2(p[1]) + 'A' + r2(r) + ' ' + r2(r) + ' 0 1 0 ' + r2(p[0] - r) + ' ' + r2(p[1]) + 'Z'); }
        // Ember: a flickering flame licks up off the tip of every crest plume and tail plume (3 layers: red-orange, orange, hot yellow core)
        if (o.flame) { if (!o.fe) o.fe = [mkP({ fill: '#ff4a1a', opacity: 0.75 }, o.g), mkP({ fill: '#ffa02a', opacity: 0.9 }, o.g), mkP({ fill: '#fff2a8', opacity: 0.95 }, o.g)];
          const p = PJ(C[N], o.h), q2 = PJ(C[N - 1], o.h), dl = Math.hypot(p[0] - q2[0], p[1] - q2[1]) || 1, dx = (p[0] - q2[0]) / dl, dy = (p[1] - q2[1]) / dl, fi = D.fire || 1, ph = o.flame * 1.7, tl = o.h ? 1 : 0.85;
          let ux = dx * 0.3 + Math.sin(ts * 6.5 + ph) * 0.2 - ox * 0.035, uy = dy * 0.3 - 0.7 + oy * 0.03; const ul = Math.hypot(ux, uy) || 1; ux /= ul; uy /= ul; const nx = -uy, ny = ux, bx = p[0] - dx * 1.1, by = p[1] - dy * 1.1;
          o.fe.forEach((e, j) => { const h = 5.6 * tl * (1 - j * 0.3) * fi * (1 + 0.2 * Math.sin(ts * 13 + ph + j) + 0.12 * Math.sin(ts * 23 + ph * 2 + j)), r = (2 - j * 0.5) * tl * Math.min(1.35, 0.7 + fi * 0.32), w = Math.sin(ts * 9 + ph + j * 0.8) * r * 0.7;
            const Lx = bx + nx * r, Ly = by + ny * r, Rx = bx - nx * r, Ry = by - ny * r, Tx = bx + ux * h + nx * w, Ty = by + uy * h + ny * w;
            set(e, 'd', 'M' + r2(Lx) + ' ' + r2(Ly) + 'Q' + r2(Lx + ux * h * 0.55) + ' ' + r2(Ly + uy * h * 0.55) + ' ' + r2(Tx) + ' ' + r2(Ty) + 'Q' + r2(Rx + ux * h * 0.55) + ' ' + r2(Ry + uy * h * 0.55) + ' ' + r2(Rx) + ' ' + r2(Ry) + 'Q' + r2(bx - ux * r * 1.4) + ' ' + r2(by - uy * r * 1.4) + ' ' + r2(Lx) + ' ' + r2(Ly) + 'Z'); }); }
        sortG(o, ZJ(C[N >> 1], o.h)); if (o.wk) W[o.wk] = PJ(C[N], o.h); });
      D.F.forEach(o => { o.qs.forEach(q => set(q.e, 'd', 'M' + q.pts.map(p => pt(PJ(o.xf(p[0], p[1], S), o.h))).join('L') + 'Z')); const q = o.qs[0], m = o.xf(q.cx, q.cy, S); sortG(o, ZJ(m, o.h)); });
      // Drako: bat wings hinged on his back - flutter all the time, flap with wfl and when he moves, spread with wsp, rise with his arms, lag behind moves, fold when asleep; membrane shades as it turns
      if (D.WG) { const sl = I.cur && /sleep/.test(I.cur.name || '') ? 1 : 0, wfl = clamp(cv('wfl'), 0, 1.6), wsp = clamp(cv('wsp'), -0.5, 1.5), spd = clamp(Math.abs(D.lv) * 0.012 + Math.abs(D.v) * 0.006, 0, 0.6);
        D.wph = (D.wph || 0) + dtS * TAU * (0.45 + 2.3 * wfl + 1.4 * spd); const A = (0.09 + 0.5 * wfl + 0.3 * spd) * (1 - sl * 0.7), ph = Math.sin(D.wph), fx = -A * 0.6 * Math.cos(D.wph);
        D.WG.forEach(o => { const sd = o.sd, arm = clamp((sd < 0 ? +P.armL : +P.armR) || 0, 0, 180) / 160, b0 = 0.36 + sl * 0.4 - wsp * 0.3 - arm * 0.12 + A * 0.9 * ph, g0 = 0.05 + wsp * 0.32 + arm * 0.22 + A * 0.5 * ph + oy * 0.05 - sd * ox * 0.02 - sl * 0.1;
          const cg = Math.cos(g0), sg = Math.sin(g0), hx = 50 + sd * 13, X = l => { const u1 = l[0] * cg + l[1] * sg, v1 = l[1] * cg - l[0] * sg, b = b0 + fx * Math.pow(l[0] / 30, 2); return [hx + sd * u1 * Math.cos(b), 47 + v1, o.hz - u1 * Math.sin(b)]; };
          const md = 'M' + o.L.map(l => pt(PJ(X(l), 1))).join('L') + 'Z'; set(o.m, 'd', md); set(o.sh, 'd', md); set(o.hl, 'd', md);
          const H0 = X([10, 0]), n = nrm(crs(sub(X([11, 0]), H0), sub(X([10, 1]), H0))).map(v => v * sd), f = (ZJ(ad(H0, n, 4), 1) - ZJ(H0, 1)) / 4;
          set(o.sh, 'opacity', r2(0.34 * SM(-f * 2.5) + 0.1 * (1 - Math.abs(f)))); set(o.hl, 'opacity', r2(0.16 * SM(f * 2.5)));
          set(o.bn, 'd', o.BN.map(b => 'M' + pt(PJ(X(b[0]), 1)) + 'L' + pt(PJ(X(b[1]), 1))).join('')); set(o.ab, 'd', 'M' + o.ARM.map(l => pt(PJ(X(l), 1))).join('L'));
          const fr = ZJ(X([12, 4]), 1) > 0; if (o.fr !== fr) { o.fr = fr; (fr ? D.gF : D.gW).appendChild(o.g); } }); }
      D.B.forEach((o, i) => { const c = [o.c[0] - ox * (o.h ? 0.06 : 0.12) + (o.wob != null ? Math.sin(ts * 3 + o.wob * 2) * 0.35 : 0), o.c[1] + oy * 0.25, o.c[2]], p = PJ(c, o.h), cP = (x, y, r) => 'M' + r2(x - r) + ' ' + r2(y) + 'A' + r2(r) + ' ' + r2(r) + ' 0 1 0 ' + r2(x + r) + ' ' + r2(y) + 'A' + r2(r) + ' ' + r2(r) + ' 0 1 0 ' + r2(x - r) + ' ' + r2(y) + 'Z';
        set(o.e, 'd', cP(p[0], p[1], o.r)); if (o.ie) { const n = nrm([c[0] - D.HX, c[1] - D.HY, c[2] + 6]), f = (ZJ(ad(c, n, 3), o.h) - ZJ(c, o.h)) / 3, q2 = PJ(ad(c, n, o.r * 0.55), o.h); set(o.ie, 'd', cP(q2[0], q2[1], o.ri * (0.6 + 0.4 * clamp(f, 0, 1)))); set(o.ie, 'opacity', r2((o.iop || 0.7) * SM(f * 2.5))); }
        sortG(o, ZJ(c, o.h)); });
      // Forest Friends ears: round 3D lumps (ellipsoids) rooted on the head; they tilt round their root with earL/earR, twitch now and then, lag behind moves and face a little outward
      if (D.L) D.L.forEach(o => { const sd = o.ear || 0, ev = clamp(sd < 0 ? +P.earL || 0 : +P.earR || 0, -40, 50), tw = Math.pow(Math.max(0, Math.sin(ts * 0.83 + sd * 2.2)), 30) * 0.3,
          a = -sd * (ev * 0.011 + tw) - ox * 0.012 - sd * oy * 0.035 + Math.sin(ts * 1.3 + sd) * 0.02, yw = sd * 0.38, ca = Math.cos(a), sa = Math.sin(a), cy0 = Math.cos(yw), sy0 = Math.sin(yw);
        const rz = v => [v[0] * ca - v[1] * sa, v[0] * sa + v[1] * ca, v[2]], ry = v => [v[0] * cy0 + v[2] * sy0, v[1], -v[0] * sy0 + v[2] * cy0];
        const R0 = [D.HX + (o.c[0] - D.HX) * 0.7, D.HY + (o.c[1] - D.HY) * 0.7], d0 = rz([o.c[0] - R0[0], o.c[1] - R0[1], 0]), C = [R0[0] + d0[0], R0[1] + d0[1], o.c[2]];
        const U = rz(ry([1, 0, 0])), V = rz(ry([0, 1, 0])), Nn = rz(ry([0, 0, 1])), r = o.r, rn = o.rn, Pp = [PJ(ad(C, Nn, rn), o.h), PJ(ad(C, Nn, -rn), o.h)];
        for (let i = 1; i < 6; i++) { const th = i / 6 * Math.PI, st = Math.sin(th), ct = Math.cos(th); for (let j = 0; j < 14; j++) { const f = j / 14 * TAU; Pp.push(PJ(ad(ad(ad(C, U, r * st * Math.cos(f)), V, r * 0.96 * st * Math.sin(f)), Nn, rn * ct), o.h)); } }
        set(o.e, 'd', H.closedD(H.hull(Pp)));
        if (o.ie) { const f = (ZJ(ad(C, Nn, 3), o.h) - ZJ(C, o.h)) / 3, Q = []; for (let j = 0; j < 16; j++) { const t2 = j / 16 * TAU; Q.push(PJ(ad(ad(ad(C, U, o.ri * Math.cos(t2)), V, o.ri * Math.sin(t2)), Nn, rn * 0.75), o.h)); }
          set(o.ie, 'd', 'M' + Q.map(pt).join('L') + 'Z'); set(o.ie, 'opacity', r2((o.iop || 0.9) * SM(f * 2.5))); }
        sortG(o, ZJ(C, o.h)); });
      // Forest Friends: flat art pieces (Teddy's bow tie) mapped onto the round body - they keep their curves, turn with him and go behind him when he faces away
      if (D.SF) D.SF.forEach(o => { o.qs.forEach(q => set(q.e, 'd', toD(q.segs, (x, y) => PJ(o.xf(x, y, S), o.h)))); sortG(o, ZJ(o.xf(o.cx, o.cy, S), o.h)); });
      const cir = (x, y, r) => 'M' + r2(x - r) + ' ' + r2(y) + 'A' + r2(r) + ' ' + r2(r) + ' 0 1 0 ' + r2(x + r) + ' ' + r2(y) + 'A' + r2(r) + ' ' + r2(r) + ' 0 1 0 ' + r2(x - r) + ' ' + r2(y) + 'Z';
      // Panko's shoulder band: strips of a 3D band on his round body, only the strips facing you are drawn, each lit by the top-left light
      if (D.pb) { const B = { cx: 50, cy: 77, rx: 21.3, ry: 14.3, rz: 16.3 }, NB = D.pb.F.length, LT = [-0.45, -0.72, 0.53], top = f => 68.6 + 3.8 * Math.sin(f) * Math.sin(f), bot = f => 77.6 + 2.4 * Math.sin(f) * Math.sin(f);
        const S3 = (f, y) => { const s = Math.sqrt(Math.max(0, 1 - ((y - B.cy) / B.ry) * ((y - B.cy) / B.ry))); return [B.cx + B.rx * s * Math.sin(f), y, B.rz * s * Math.cos(f) + 0.3]; }, C0 = [24, 20, 31], C1 = [40, 36, 50], C2 = [76, 70, 90];
        for (let k = 0; k < NB; k++) { const f0 = k / NB * TAU, f1 = (k + 1.06) / NB * TAU, fm = (k + 0.5) / NB * TAU, ym = (top(fm) + bot(fm)) / 2, pm = S3(fm, ym), n = nrm([(pm[0] - B.cx) / (B.rx * B.rx), (pm[1] - B.cy) / (B.ry * B.ry), pm[2] / (B.rz * B.rz)]);
          const nx = n[0] * cyb + n[2] * syb, nz = -n[0] * syb + n[2] * cyb, e = D.pb.F[k]; if (nz < -0.05) { set(e, 'd', 'M0 0'); continue; }
          const sh = clamp(nx * LT[0] + n[1] * LT[1] + nz * LT[2], -1, 1) * 0.5 + 0.5, cc = sh < 0.5 ? C0.map((v, j) => v + (C1[j] - v) * sh * 2) : C1.map((v, j) => v + (C2[j] - v) * Math.pow((sh - 0.5) * 2, 1.6)), col = 'rgb(' + cc.map(Math.round).join(',') + ')';
          const Pp = []; [0, 0.5, 1].forEach(t => { const y = top(f0) + (bot(f0) - top(f0)) * t; Pp.push(PJ(S3(f0, y), 0)); }); [1, 0.5, 0].forEach(t => { const y = top(f1) + (bot(f1) - top(f1)) * t; Pp.push(PJ(S3(f1, y), 0)); });
          set(e, 'd', 'M' + Pp.map(pt).join('L') + 'Z'); set(e, 'fill', col); set(e, 'stroke', col); } }
      // Leo's mane: fluffy round lobes on a shell round his head (none over his face), drawn back to front behind his head so the ruff frames his face from every side
      if (D.mane) { const M = D.mane, fl = clamp(cv('mfl'), -0.3, 1.4), sk = clamp(cv('msh'), 0, 1.5), A = [];
        M.L.forEach((d, i) => { const w = Math.sin(ts * 1.7 + i * 1.3) * 0.5 + sk * Math.sin(ts * 31 + i * 2.1) * 1.5, k = 1 + fl * 0.12 + w * 0.015, lg = clamp(0.5 - d[2] / 30, 0, 1.2);
          const c = [M.cx + d[0] * k - ox * 0.12 * lg, M.cy + d[1] * k + oy * 0.35 * lg + Math.sin(ts * 1.2) * 0.25, d[2] * (1 + fl * 0.05)]; A.push({ p: PJ(c, 1), z: ZJ(c, 1), r: d[3] * (1 + fl * 0.08) + w * 0.15 }); });
        // lobes facing you (in front of the head's middle) are drawn over the head, the rest behind it; each set back to front
        A.sort((a, b) => a.z - b.z); let nb = 0, nf = 0; A.forEach(a => { if (a.z > 2) set(M.EF[nf++], 'd', cir(a.p[0], a.p[1], a.r)); else set(M.EB[nb++], 'd', cir(a.p[0], a.p[1], a.r)); });
        for (; nb < M.EB.length; nb++) set(M.EB[nb], 'd', 'M0 0'); for (; nf < M.EF.length; nf++) set(M.EF[nf], 'd', 'M0 0'); }
      // Leo's tail tuft rides on the tip of the 3D tail
      if (D.lt && W.tail) { const p = W.tail, sw = Math.sin(ts * 3.1) * 0.6; set(D.lt, 'd', cir(p[0], p[1] - 0.6, 4.4)); set(D.lt2, 'd', cir(p[0] + 1.6 + sw, p[1] - 3.4, 2.8)); }
      // Forest batch 3: caps of revolution (outline = visible front edge + both limbs + top), surface lines, spots, moss tuft, rim band, stem; dots on the round head/body; Sprout's flower
      if (D.f3) { const F3 = D.f3;
        F3.caps.forEach(o => { const A = o.anim ? o.anim(S) : {}, R = o.R, pv = o.pv, rl = A.roll || 0, pi = A.pit || 0, lf = A.lift || 0, spn = A.spin || 0, cr = Math.cos(rl), sr = Math.sin(rl), cpi = Math.cos(pi), spi = Math.sin(pi);
          const L3 = (x, y, z) => { const X = x - pv[0], Y = y - pv[1], Z = z - pv[2], y1 = Y * cpi - Z * spi, z1 = Y * spi + Z * cpi; return [pv[0] + X * cr - y1 * sr, pv[1] + X * sr + y1 * cr - lf, pv[2] + z1]; };
          const SPt = (y, f, dr) => { const r = R(y) + (dr || 0); return L3(50 + r * Math.sin(f), y, r * Math.cos(f)); };
          const PV = p => { const q = PJ(p, o.h); return [q[0], q[1] + o.vt * ZJ(p, o.h)]; };
          const fa = (y, f) => ZJ(SPt(y, f, 1), o.h) - ZJ(SPt(y, f), o.h);
          const K = 72, st = TAU / K, y0 = o.ye(0), ym = o.yT + (y0 - o.yT) * 0.7, FA = []; for (let k = 0; k < K; k++) FA.push(fa(ym, k * st));
          let k0 = -1; for (let k = 0; k < K; k++) if (FA[(k + K - 1) % K] <= 0 && FA[k] > 0) { k0 = k; break; }
          let f0 = 0, f1 = TAU; if (k0 >= 0) { const kp = (k0 + K - 1) % K; f0 = (k0 - 1 + (0 - FA[kp]) / (FA[k0] - FA[kp])) * st; let k = k0, n = 0; while (FA[k % K] > 0 && n < K) { k++; n++; } const ka = (k - 1) % K, kb = k % K; f1 = (k - 1 + FA[ka] / ((FA[ka] - FA[kb]) || 1)) * st; }
          const EN = o.EN || 36; let out = []; for (let i = 0; i <= EN; i++) { const f = f0 + (f1 - f0) * i / EN; out.push(PV(SPt(o.ye(f - spn), f))); }
          if (k0 < 0) { [0.25, 0.5, 0.75, 0.92].forEach(u => { const y = R.Y(R.S(o.yT) + (R.S(y0) - R.S(o.yT)) * u); for (let k = 0; k < 24; k++) out.push(PV(SPt(y, k / 24 * TAU))); }); out.push(PV(SPt(o.yT, 0))); out = H.hull(out); }
          if (k0 >= 0) { const LM = (f, up) => { const ye = o.ye(f - spn), Ps = R.pts.filter(p => p[0] < ye - 0.05 && p[0] > o.yT - 0.01).map(p => p[0]), ys = up ? Ps.reverse() : Ps; return ys.filter((y, i) => i % 2 === 0 || i === ys.length - 1).map(y => PV(SPt(y, f))); };
            out.push(...LM(f1, 1)); out.push(PV(SPt(o.yT, f1))); out.push(...LM(f0, 0)); }
          set(o.e, 'd', 'M' + out.map(pt).join('L') + 'Z');
          if (o.le) { let ld = ''; o.curves.forEach(c => { let pen = false; for (let i = 0; i <= 10; i++) { const yf = c(i / 10), f = yf[1] + spn; if (fa(yf[0], f) > 0.1) { ld += (pen ? 'L' : 'M') + pt(PV(SPt(yf[0], f, 0.15))); pen = true; } else pen = false; } }); set(o.le, 'd', ld || 'M0 0'); }
          o.se.forEach((e, i) => { const sp = o.spots[i], f = sp.f + spn, v = fa(sp.y, f); if (v < -0.12) { set(e, 'd', 'M0 0'); return; } const s0 = R.S(sp.y), R0 = Math.max(4, R(sp.y)), Q = [];
            for (let k = 0; k < 16; k++) { const a = k / 16 * TAU; Q.push(PV(SPt(R.Y(s0 + sp.r * Math.sin(a)), f + sp.r * Math.cos(a) / R0, 0.25))); } set(e, 'd', 'M' + Q.map(pt).join('L') + 'Z'); set(e, 'opacity', r2(SM((v + 0.08) * 5))); });
          if (o.te) o.te.forEach((e, i) => { const u = o.tuft[i], f = u.f + spn, v = fa(u.y, f), p = PV(SPt(u.y, f, u.dr + Math.sin(ts * 2.1 + i) * 0.2)); set(e, 'd', cir(p[0], p[1], u.r * (1 + Math.sin(ts * 1.7 + i * 2) * 0.04))); set(e, 'opacity', r2(SM((v + 0.3) * 4))); });
          if (o.be && k0 >= 0) { const B = o.band, T = [], Bt = [], HL = []; for (let i = 0; i <= EN; i++) { const f = f0 + (f1 - f0) * i / EN, ye = o.ye(f - spn), r0 = R(ye) + B.bo, r1 = r0 + (B.bb || 0);
              T.push(PV(L3(50 + r0 * Math.sin(f), ye - (B.up || 0), r0 * Math.cos(f)))); Bt.push(PV(L3(50 + r1 * Math.sin(f), ye + B.h, r1 * Math.cos(f)))); if (o.bh) HL.push(PV(L3(50 + (r0 + 0.5) * Math.sin(f), ye + B.h * 0.3, (r0 + 0.5) * Math.cos(f)))); }
            set(o.be, 'd', 'M' + T.map(pt).join('L') + 'L' + Bt.reverse().map(pt).join('L') + 'Z'); if (o.bh) set(o.bh, 'd', 'M' + HL.slice(Math.round(EN * 0.08), Math.round(EN * 0.6)).map(pt).join('L')); }
          if (o.ste) { const wb = Math.sin(ts * 2.1) * 0.5 - ox * 0.06, a = PV(L3(50, o.yT + 1.2, 0)), b = PV(L3(49.5 + wb * 0.4, o.yT - 3.8, -0.2)), c = PV(L3(51.2 + wb, o.yT - 7.2, -0.4));
            set(o.ste, 'd', 'M' + pt(a) + 'Q' + pt(b) + ' ' + pt(c)); set(o.sth, 'd', 'M' + pt([a[0] - 0.55, a[1] - 0.6]) + 'Q' + pt([b[0] - 0.55, b[1]]) + ' ' + pt([c[0] - 0.35, c[1] + 0.5])); } });
        F3.dots.forEach(o => { const v = ZJ(ad(o.c, o.n, 1), o.h) - ZJ(o.c, o.h); if (v < -0.05) { set(o.e, 'd', 'M0 0'); return; } set(o.e, 'd', 'M' + o.pts.map(p => pt(PJ(p, o.h))).join('L') + 'Z'); set(o.e, 'opacity', r2(SM((v + 0.05) * 4))); });
        if (F3.fl) { const Fl = F3.fl, c = Fl.sp(1, S), C0 = [50 + c[0], c[1] - 0.6, c[2]], bl = clamp(cv('blm'), 0, 1.5), rp = 0.95 + 1.9 * bl, rr = 1.55 + 0.75 * bl, sp0 = ts * 0.4 + cv('fsp') * TAU;
          const PP = Fl.pe.map((e, k) => { const a = k / 5 * TAU + sp0, q = [C0[0] + rp * Math.cos(a), C0[1] + rp * Math.sin(a) * 0.9, C0[2] + rp * Math.sin(a) * 0.42]; return { e, p: PJ(q, 1), z: ZJ(q, 1) }; });
          PP.sort((a, b) => a.z - b.z).forEach((u, k) => set(Fl.pe[k], 'd', cir(u.p[0], u.p[1], rr))); const q = PJ([C0[0], C0[1], C0[2] + 0.8], 1); set(Fl.ce, 'd', cir(q[0], q[1], 0.95 + 0.4 * bl)); } }
      if (D.fur) { const U = D.fur, fz = clamp(cv('fzz'), 0, 1.5), rx = 31.5 * (1 + fz * 0.06), ry = 28.5 * (1 + fz * 0.06); let d = '', ds = '';
        U.L.forEach((u, i) => { const sw = Math.sin(ts * 2.4 + i * 1.3) * 0.25, c = [D.HX + u[0] * rx * 0.93 - ox * 0.06 * (1 - u[1]), D.HY + u[1] * ry * 0.93 + sw * 0.4, u[2] * 28 * 0.93], z = sphZ(c[0], c[1], c[2]); if (z < -6) return;
          const p = sph(c[0], c[1], c[2]), r = 4.7 * (1 + fz * 0.25 + 0.06 * Math.sin(ts * 3 + i)); d += 'M' + r2(p[0] - r) + ' ' + r2(p[1]) + 'A' + r2(r) + ' ' + r2(r) + ' 0 1 0 ' + r2(p[0] + r) + ' ' + r2(p[1]) + 'A' + r2(r) + ' ' + r2(r) + ' 0 1 0 ' + r2(p[0] - r) + ' ' + r2(p[1]) + 'Z';
          if (z > 4 && u[1] > -0.75) ds += 'M' + r2(p[0] - r * 0.7) + ' ' + r2(p[1] + r * 0.55) + 'Q' + r2(p[0]) + ' ' + r2(p[1] + r * 1.05) + ' ' + r2(p[0] + r * 0.7) + ' ' + r2(p[1] + r * 0.55) + 'Q' + r2(p[0]) + ' ' + r2(p[1] + r * 0.75) + ' ' + r2(p[0] - r * 0.7) + ' ' + r2(p[1] + r * 0.55) + 'Z'; });
        set(U.e, 'd', d || 'M0 0Z'); set(U.sh, 'd', ds || 'M0 0Z'); }
      // Ember: glowing embers rise off his body all the time (twinkle, drift, fade), more when his flames flare
      if (D.key === 'ember') { D.cen = sph(D.HX, D.HY, 0); if (!D.emb) D.emb = Array.from({ length: 12 }, (_, i) => ({ h: mkP({ fill: '#ff4a12', opacity: 0 }, D.gF), c: mkP({ fill: '#ffc83a', opacity: 0 }, D.gF), a: (hrnd(i + 3) * 2 - 1) * 1.9, sp: 0.3 + hrnd(i + 11) * 0.25, o0: hrnd(i + 21), rise: 14 + hrnd(i + 31) * 12, rr: 0.5 + hrnd(i + 41) * 0.55 }));
        const fi = D.fire || 1, cP = (x, y, r) => 'M' + r2(x - r) + ' ' + r2(y) + 'A' + r2(r) + ' ' + r2(r) + ' 0 1 0 ' + r2(x + r) + ' ' + r2(y) + 'A' + r2(r) + ' ' + r2(r) + ' 0 1 0 ' + r2(x - r) + ' ' + r2(y) + 'Z';
        D.emb.forEach((m, i) => { const f = (ts * m.sp * (0.8 + fi * 0.3) + m.o0) % 1, x = D.HX + 31 * Math.sin(m.a) + Math.sin(ts * 2.3 + i * 1.7) * 1.6 * f - ox * 0.4 * f, y = D.HY - 31 * Math.cos(m.a) - f * m.rise * (0.8 + fi * 0.25) + oy * 0.3 * f;
          const op = Math.pow(Math.sin(Math.PI * f), 0.8) * Math.min(1, fi * 0.8) * (0.7 + 0.3 * Math.sin(ts * 17 + i * 2.1)), r = m.rr * (1 - f * 0.45) * Math.min(1.3, 0.8 + fi * 0.25);
          set(m.h, 'd', cP(x, y, r * 2.3)); set(m.h, 'opacity', r2(op * 0.55)); set(m.c, 'd', cP(x, y, r)); set(m.c, 'opacity', r2(op)); }); }
      if (D.glow) { const p = sph(D.HX, D.HY, 0), r = 38 + 3 * Math.sin(ts * 3.1) + 2 * Math.sin(ts * 7.3) + clamp(cv('cfl'), 0, 1.5) * 8; set(D.glow, 'd', 'M' + r2(p[0] - r) + ' ' + r2(p[1]) + 'A' + r2(r) + ' ' + r2(r) + ' 0 1 0 ' + r2(p[0] + r) + ' ' + r2(p[1]) + 'A' + r2(r) + ' ' + r2(r) + ' 0 1 0 ' + r2(p[0] - r) + ' ' + r2(p[1]) + 'Z'); }
      if (D.smoke) { const n0 = sph(53.4, 56.2, D.tk ? 29.5 : (I.zE ? I.zE(52.5 - HX, 56.5 - HY) : 20) + 1), sl = I.cur && /sleep/.test(I.cur.name || ''), per = sl ? 4.2 : 3.4, ph = (ts % per); W.mouth = W.mouth || n0;
        // little puffs of smoke from his nostrils now and then (a burst of 3 that rise and grow), slower snore puffs when asleep
        D.smoke.forEach((q, i) => { if (!q.so) { q.so = 1; q.e.setAttribute('stroke', '#c6cee2'); q.e.setAttribute('stroke-width', '0.35'); q.e.setAttribute('fill', '#f6f8fc'); } const f = clamp((ph - i * 0.2) / (sl ? 2 : 1.3), 0, 1), x = n0[0] + (i % 2 ? 1.5 : -0.8) * f * 3 + Math.sin(ts * 3 + i) * 0.6 * f, y = n0[1] - 2.5 - f * 20, r = 0.7 + f * 2.8;
          set(q.e, 'd', 'M' + r2(x - r) + ' ' + r2(y) + 'A' + r2(r) + ' ' + r2(r) + ' 0 1 0 ' + r2(x + r) + ' ' + r2(y) + 'A' + r2(r) + ' ' + r2(r) + ' 0 1 0 ' + r2(x - r) + ' ' + r2(y) + 'Z'); set(q.e, 'opacity', r2(f > 0 && f < 1 ? 0.9 * Math.pow(Math.sin(Math.PI * f), 0.6) * (0.4 + 0.6 * SM(cyh * 2)) : 0)); }); } }
    // Hana: 3D bunny suit - round hood (face opening + rolled rim ride on its front), round suit body, springy 3D bunny ears that flop, drawstrings, cotton tail, legs to the feet
    if (I.hn) { const A = I.hn, ts = now / 1000, P3 = (x, y, z) => sph(50 + x, y, z), Z3 = (x, y, z) => sphZ(50 + x, y, z), pt = p => r2(p[0]) + ' ' + r2(p[1]), cv = k => { const v = +P[k]; return v === v ? v : 0; };
      const tg = P.x * 1.4 + P.tilt * 0.5 + P.lean * 1.5 + P.turn * 12, ly = P.lift - sq * 8; if (A.p == null) { A.p = tg; A.v = 0; A.l = ly; A.lv = 0; }
      A.v += ((tg - A.p) * 120 - A.v * 7) * dtS; A.p += A.v * dtS; A.lv += ((ly - A.l) * 140 - A.lv * 7.5) * dtS; A.l += A.lv * dtS; const ox = clamp(A.p - tg, -12, 12), oy = clamp(A.l - ly, -6, 6);
      const DV = v => { const x1 = v[0] * cyh + v[2] * syh, z1 = -v[0] * syh + v[2] * cyh; return [x1, v[1] * cp - z1 * sp, v[1] * sp + z1 * cp]; };
      const hp = []; for (let i = 0; i <= 16; i++) { const y = 21.8 + 48.6 * (0.5 - 0.5 * Math.cos(Math.PI * i / 16)), r = A.rH(y); if (r < 0.3) { hp.push(P3(0, y, 0)); continue; } for (let k = 0; k < 28; k++) { const f = k / 28 * TAU; hp.push(P3(r * Math.sin(f), y, A.KH * r * Math.cos(f))); } }
      A.d = H.closedD(H.hull(hp));
      const bp = []; for (let i = 0; i <= 10; i++) { const y = 61 + 25 * i / 10, r = A.rB(y); if (r < 0.3) { bp.push(P3(0, y, 0)); continue; } for (let k = 0; k < 24; k++) { const f = k / 24 * TAU; bp.push(P3(r * Math.sin(f), y, A.KB * r * Math.cos(f))); } }
      set(A.body, 'd', H.closedD(H.hull(bp)));
      // rolled hood rim round the face opening (only the part that faces you is drawn)
      const rim = (k, dz) => { let d = '', pen = false; for (let i = 0; i <= 48; i++) { const a = i / 48 * TAU, x = 50 + A.FX * k * Math.cos(a), y = A.FY + A.FB * k * Math.sin(a), z = A.zAt(x, y) + dz; if (Z3(x - 50, y, z) > 0.3) { d += (pen ? 'L' : 'M') + pt(P3(x - 50, y, z)); pen = true; } else pen = false; } return d || 'M0 0'; };
      set(A.rim, 'd', rim(1.03, 1.1)); set(A.rimS, 'd', rim(0.965, 0.5));
      // bunny ears: rounded blades rooted on top of the hood; they spread with earL / earR, trail behind moves on a spring, and flop forward from the middle with flL / flR
      const rX = (v, a) => { const c = Math.cos(a), s = Math.sin(a); return [v[0], v[1] * c - v[2] * s, v[1] * s + v[2] * c]; }, rZ = (v, a) => { const c = Math.cos(a), s = Math.sin(a); return [v[0] * c - v[1] * s, v[0] * s + v[1] * c, v[2]]; }, ad = (p, v, k) => [p[0] + v[0] * k, p[1] + v[1] * k, p[2] + v[2] * k];
      A.EAR.forEach(o => { const sd = o.sd, ev = sd < 0 ? -(+P.earL || 0) : (+P.earR || 0), fl = clamp(cv(sd < 0 ? 'flL' : 'flR'), -0.3, 1.2);
        const aIn = clamp(ev, -40, 50) * 0.7 * D2R + ox * 0.035 + Math.sin(ts * 1.3 + sd) * 0.04, Fb = fl * 2.85 + oy * 0.06 + Math.sin(ts * 1.1 + sd * 0.7) * 0.07;
        const fA = s => Fb * SM((s - 0.13) / 0.24), dirAt = s => rZ(rX(o.d0, fA(s)), aIn), tvAt = s => rZ(rX([0, 0, 1], fA(s)), aIn), wv = rZ([1, 0, 0], aIn), N = 10, Lr = 19.5, RG = [], M = []; let C = o.R.slice();
        for (let i = 0; i <= N; i++) { const s = i / N; if (i) C = ad(C, dirAt(s - 0.5 / N), Lr / N);
          const w = 4.1 * Math.sqrt(Math.max(0, 1 - Math.pow((s - 0.42) / 0.6, 2))) + 0.2, th = 1.1 + 0.5 * w / 4.1, tv = tvAt(s), ring = [];
          if (s > 0.2 && C[1] > 23) { const zs = A.zAt(50 + C[0], C[1]) + th + 0.5; if (C[2] < zs) C = [C[0], C[1], zs]; } // a flopped ear lies on the hood instead of sinking into it
          for (let k = 0; k < 12; k++) { const f = k / 12 * TAU; ring.push(P3(...ad(ad(C, wv, w * Math.cos(f)), tv, th * Math.sin(f)))); } RG.push(ring); M.push({ C, w, th, tv }); }
        RG.push([P3(...ad(C, dirAt(1), 1.6))]);
        let fd = ''; for (let i = 0; i < RG.length - 1; i++) fd += H.closedD(H.hull(RG[i].concat(RG[i + 1]))); set(o.e, 'd', fd);
        if (fl > 0.15) { let sd2 = ''; for (let i = 3; i < RG.length - 1; i++) sd2 += H.closedD(H.hull(RG[i].concat(RG[i + 1]).map(p => [p[0] + 0.6, p[1] + 1.3]))); set(o.sh, 'd', sd2); set(o.sh, 'opacity', r2(0.22 * SM((fl - 0.15) / 0.4))); } else set(o.sh, 'opacity', 0); // soft shadow under a flopped ear so it reads on the white hood
        let last = 9; for (let i = 1; i <= 9; i++) if (DV(M[i].tv)[2] < 0.05) { last = i - 1; break; }
        if (last >= 3) { const U = [], Dn = []; for (let i = 1; i <= last; i++) { const m = M[i], k = 0.55 * (i === 9 ? 0.6 : 1); U.push(P3(...ad(ad(m.C, wv, m.w * k), m.tv, m.th))); Dn.push(P3(...ad(ad(m.C, wv, -m.w * k), m.tv, m.th))); }
          set(o.inr, 'd', 'M' + U.concat(Dn.reverse()).map(pt).join('L') + 'Z'); set(o.inr, 'opacity', r2(0.85 * SM(DV(M[2].tv)[2] * 4))); } else set(o.inr, 'opacity', 0);
        const fr = Math.max(Z3(...o.R), Z3(...M[7].C)) > 2; if (o.fr !== fr) { o.fr = fr; (fr ? A.eF : A.eB).appendChild(o.g); } });
      // cotton tail on her back: a fluffy ball that bounces on a spring and wiggles with tw; behind her body from the front
      { const tw = clamp(cv('tw'), 0, 1.5), y = 80.5 + oy * 0.3, C = [tw * 1.6 * Math.sin(ts * 19) + Math.sin(ts * 1.6) * 0.3 - ox * 0.12, y, -(A.KB * A.rB(y)) + 1.2], p = P3(...C), r = 5.6 * (1 + 0.04 * Math.sin(ts * 2.3));
        let d = ''; for (let k = 0; k < 36; k++) { const a = k / 36 * TAU, rr = r * (1 + 0.06 * Math.sin(a * 7 + ts * 1.5)); d += (k ? 'L' : 'M') + r2(p[0] + rr * Math.cos(a)) + ' ' + r2(p[1] + rr * Math.sin(a)); } set(A.tl, 'd', d + 'Z');
        const fr = Z3(...C) > 0; if (A.tfr !== fr) { A.tfr = fr; (fr ? A.tF : A.tB).appendChild(A.tl); } }
      // hood drawstrings hanging on the front of her suit, swinging with dsw and trailing behind moves
      if (A.ds) { const sw = clamp(cv('dsw'), -1.5, 1.5); let d = ''; [-1, 1].forEach(sd => { const a = Math.sin(ts * 1.8 + sd) * 0.06 + ox * 0.03 + sw * 0.35; let pen = false;
          for (let i = 0; i <= 6; i++) { const s = i / 6, x = sd * (7 + 0.8 * s) + 10.5 * s * s * Math.sin(a) * 0.9, y = 73.5 + 10.5 * s * Math.cos(a), z = A.zAt(50 + x, y) + 0.6; if (Z3(x, y, z) > 0.5) { d += (pen ? 'L' : 'M') + pt(P3(x, y, z)); pen = true; } else pen = false; } }); set(A.ds, 'd', d || 'M0 0'); }
      // legs: soft white legs from under the suit down to each foot
      A.LG.forEach(o => { const f = o.ft, lift = f ? (f.ox < 50 ? P.footL : P.footR) : 0, top = byw(50 + o.sd * 10.5, 81, 3), bot = byw(f ? f.ox : 50 + o.sd * 10, (f ? f.oy : 92) - 3.5 - lift, 5), q2 = [];
        for (let i = 0; i <= 4; i++) { const u = i / 4, cx = top[0] + (bot[0] - top[0]) * u, cy = top[1] + (bot[1] - top[1]) * u; for (let k = 0; k < 10; k++) { const a = k / 10 * TAU; q2.push([cx + 3.4 * Math.cos(a), cy + 3.4 * Math.sin(a)]); } } set(o.e, 'd', H.closedD(H.hull(q2))); }); }
    // Boo: 3D sheet ghost - round dome body, scalloped hem all the way round (slides past as he turns, ripples, flares and trails when he moves), fades out with gho
    if (I.gb) { const A = I.gb, ts = now / 1000, cv = k => { const v = +P[k]; return v === v ? v : 0; };
      const tg = P.x * 1.4 + P.tilt * 0.5 + P.lean * 1.5 + P.turn * 12, ly = P.lift - sq * 8; if (A.p == null) { A.p = tg; A.v = 0; A.l = ly; A.lv = 0; }
      A.v += ((tg - A.p) * 90 - A.v * 6) * dtS; A.p += A.v * dtS; A.lv += ((ly - A.l) * 100 - A.lv * 6.5) * dtS; A.l += A.lv * dtS; const ox = clamp(A.p - tg, -12, 12), oy = clamp(A.l - ly, -6, 6);
      const fl = clamp(Math.abs(A.v) / 70 + Math.abs(A.lv) / 60, 0, 1) * 0.1 + clamp(cv('flr'), 0, 1.5) * 0.14 + Math.max(0, sq) * 0.05, Wf = y => A.Wd(y) * (1 + fl * SM((y - 50) / 32)), sw = y => (ox * 0.35 + Math.sin(ts * 1.2) * 0.5) * SM((y - 55) / 30);
      const V = (x, y, z) => headT(x, HY + (y - HY) * cp - z * sp), o = [], pq = (x, y, z) => { const p = V(x, y, z); o.push(r2(p[0]) + ' ' + r2(p[1])); };
      const YS = []; for (let i = 0; i <= 12; i++) YS.push(18 + 36 * (1 - Math.cos(Math.PI / 2 * i / 12))); for (let i = 1; i <= 4; i++) YS.push(54 + 28 * i / 4);
      YS.slice().reverse().forEach(y => pq(50 - Wf(y) + sw(y), y, 0)); YS.slice(1).forEach(y => pq(50 + Wf(y) + sw(y), y, 0));
      const R = Wf(82), hem = tv => 82 + 7.6 * Math.pow(Math.abs(Math.cos(7 * (tv - yb) + Math.sin(ts * 1.7 + tv * 2) * 0.12)), 0.55) + Math.sin(tv * 3 - ts * 2.3) * (0.5 + fl * 6) - oy * 0.5;
      for (let i = 0; i <= 72; i++) { const tv = Math.PI / 2 - i / 72 * Math.PI; pq(50 + R * Math.sin(tv) + sw(86), hem(tv), A.KB * R * Math.cos(tv)); }
      A.d = 'M' + o.join('L') + 'Z';
      const gh = clamp(cv('gho'), 0, 1); if (gh !== A.gh0) { A.gh0 = gh; set(A.art, 'opacity', r2(1 - 0.88 * gh)); } }
    // Pixie: 3D fairy - one-piece bob of hair round her head, hair bun + flower, pointy elf ears, petal dress, four buzzing see-through wings, legs to the feet
    if (I.px) { const A = I.px, ts = now / 1000, P3 = (x, y, z) => sph(50 + x, y, z), Z3 = (x, y, z) => sphZ(50 + x, y, z), pt = p => r2(p[0]) + ' ' + r2(p[1]), cv = k => { const v = +P[k]; return v === v ? v : 0; };
      const tg = P.x * 1.4 + P.tilt * 0.5 + P.lean * 1.5 + P.turn * 12, ly = P.lift - sq * 8; if (A.p == null) { A.p = tg; A.v = 0; A.l = ly; A.lv = 0; }
      A.v += ((tg - A.p) * 120 - A.v * 7) * dtS; A.p += A.v * dtS; A.lv += ((ly - A.l) * 140 - A.lv * 7.5) * dtS; A.l += A.lv * dtS; const ox = clamp(A.p - tg, -12, 12), oy = clamp(A.l - ly, -6, 6);
      const DV = v => { const x1 = v[0] * cyh + v[2] * syh, z1 = -v[0] * syh + v[2] * cyh; return [x1, v[1] * cp - z1 * sp, v[1] * sp + z1 * cp]; }, ad = (p, v, k) => [p[0] + v[0] * k, p[1] + v[1] * k, p[2] + v[2] * k];
      // petal dress: bodice + flared skirt, pointed petal hem all the way round (turns with her), seams down to each petal tip
      if (A.dress) { const fl = clamp(cv('drf'), 0, 1.5) * 0.3 + clamp(Math.abs(A.v) / 70 + Math.abs(A.lv) / 60, 0, 1) * 0.08, V = (x, y, z) => headT(x, HY + (y - HY) * cp - z * sp), Rf = y => A.rD(y) * (1 + fl * SM((y - 68) / 14)), sw = y => (ox * 0.3 + Math.sin(ts * 1.4) * 0.3) * SM((y - 68) / 16);
        const YS = []; for (let i = 0; i <= 8; i++) YS.push(59 + 7 * (1 - Math.cos(Math.PI / 2 * i / 8))); for (let i = 1; i <= 6; i++) YS.push(66 + 16.5 * i / 6);
        const hem = tv => 86.5 - 4 * Math.pow(Math.abs(Math.sin(4 * (tv - yb - Math.PI / 8))), 0.6) + Math.sin(tv * 3 - ts * 2) * 0.3 - fl * 2.5, o = [];
        YS.slice().reverse().forEach(y => o.push(pt(V(50 - Rf(y) + sw(y), y, 0)))); YS.slice(1).forEach(y => o.push(pt(V(50 + Rf(y) + sw(y), y, 0))));
        const R = Rf(82.5); for (let i = 0; i <= 48; i++) { const tv = Math.PI / 2 - i / 48 * Math.PI; o.push(pt(V(50 + R * Math.sin(tv) + sw(86), hem(tv), R * Math.cos(tv)))); }
        set(A.dress, 'd', 'M' + o.join('L') + 'Z');
        if (A.seam) { let sd2 = ''; for (let k = 0; k < 8; k++) { const tv = Math.PI / 8 + k * Math.PI / 4 + yb, c = Math.cos(tv); if (c < 0.15) continue; for (let j = 0; j <= 4; j++) { const y = 67.5 + (hem(tv) - 0.6 - 67.5) * j / 4, r = j === 4 ? R : Rf(y); sd2 += (j ? 'L' : 'M') + pt(V(50 + r * Math.sin(tv) + sw(y), y, r * c + 0.2)); } } set(A.seam, 'd', sd2 || 'M0 0'); } }
      if (A.legs) { let d = ''; A.feet.forEach(f => { const sd = f.ox < 50 ? -1 : 1, lift = sd < 0 ? P.footL : P.footR, a = byw(50 + sd * 6.5, 81, 2), b = byw(f.ox + sd * 0.5, f.oy - 2.2 - lift, 5); d += 'M' + pt(a) + 'L' + pt(b); }); set(A.legs, 'd', d); }
      // hair: a bob-shaped shell round her head, cut into small patches; the ones facing you are drawn over her head, the rest behind it; strand lines on the back
      { const hR = la => 20 + 4 * SM((0.5 - la) / 0.6), lmin = th => lerp(0.42, -0.62, SM((Math.abs(th) - 1.25) / 0.4)), s2 = ox * 0.4 + Math.sin(ts * 1.2) * 0.4;
        const HPt = (th, la) => { const r = hR(la), w = SM((0.2 - la) / 0.8); return [r * Math.cos(la) * Math.sin(th) + s2 * w, 44 - r * Math.sin(la) - oy * 0.3 * w, r * Math.cos(la) * Math.cos(th)]; };
        let dF = '', dB = '', x0 = 1e9, y0 = 1e9, x1 = -1e9, y1 = -1e9; const NT = 28, NL = 6;
        for (let i = 0; i < NT; i++) { const ta = -Math.PI + i / NT * TAU - 0.02, tb = -Math.PI + (i + 1) / NT * TAU + 0.02, tm = (ta + tb) / 2, l0 = lmin(tm);
          for (let j = 0; j < NL; j++) { const la = l0 + (Math.PI / 2 - l0) * j / NL - 0.02, lb = l0 + (Math.PI / 2 - l0) * (j + 1) / NL + 0.02; let zs = 0;
            const sc = [HPt(ta, la), HPt(tb, la), HPt(ta, lb), HPt(tb, lb), HPt(tm, la), HPt(tm, lb)].map(p => { zs += Z3(...p); const s = P3(...p); if (s[0] < x0) x0 = s[0]; if (s[0] > x1) x1 = s[0]; if (s[1] < y0) y0 = s[1]; if (s[1] > y1) y1 = s[1]; return s; });
            const dd = 'M' + H.hull(sc).map(pt).join('L') + 'Z'; if (zs / 6 > 2) dF += dd; else dB += dd; } }
        set(A.hF, 'd', dF || 'M0 0Z'); set(A.hB, 'd', dB || 'M0 0Z'); const bw = x1 - x0, bh = y1 - y0; set(A.hg, 'cx', r2(x0 + bw * 0.38)); set(A.hg, 'cy', r2(y0 + bh * 0.3)); set(A.hg, 'r', r2((bw + bh) * 0.42));
        let sd3 = ''; [-0.7, -0.35, 0, 0.35, 0.7].forEach(o2 => { const th = Math.PI + o2, P2 = []; for (let j = 0; j <= 6; j++) P2.push(HPt(th + Math.sin(j * 0.8 + o2 * 3) * 0.03, 1.2 - (1.2 - lmin(th) - 0.08) * j / 6)); if (P2.reduce((s, p) => s + Z3(...p), 0) / P2.length < 4) return; sd3 += 'M' + P2.map(p => pt(P3(...p))).join('L'); }); set(A.hS, 'd', sd3 || 'M0 0'); }
      // pointy elf ears: flat 3D cones from the sides of her head, twitching now and then; in front of her head when that side turns to you
      A.EARS.forEach(o => { const sd = o.sd, up = (sd < 0 ? +P.earL : +P.earR) || 0, tw = Math.sin(ts * 0.9 + sd) * 0.04 + (Math.sin(ts * 0.37 + sd * 2) > 0.96 ? Math.sin(ts * 40) * 0.12 : 0), a = -sd * clamp(up, -40, 40) * 0.6 * D2R + tw - ox * 0.01;
        const R = o.R, c = Math.cos(a), s = Math.sin(a), T0 = [o.T[0] - R[0], o.T[1] - R[1], o.T[2] - R[2]], d = [T0[0] * c - T0[1] * s, T0[0] * s + T0[1] * c, T0[2]], L = Math.hypot(...d), u = d.map(v => v / L), wl = Math.hypot(u[0], u[1]) || 1, wv = [-u[1] / wl, u[0] / wl, 0], tv = [u[1] * wv[2] - u[2] * wv[1], u[2] * wv[0] - u[0] * wv[2], u[0] * wv[1] - u[1] * wv[0]];
        const RG = []; for (let i = 0; i <= 6; i++) { const s2 = i / 6, C = ad(R, d, s2), w = 3.6 * Math.pow(1 - s2, 0.75) + 0.15, th = 1.3 * (1 - s2) + 0.25, ring = []; for (let k = 0; k < 10; k++) { const f = k / 10 * TAU; ring.push(P3(...ad(ad(C, wv, w * Math.cos(f)), tv, th * Math.sin(f)))); } RG.push(ring); }
        let fd = ''; for (let i = 0; i < RG.length - 1; i++) fd += H.closedD(H.hull(RG[i].concat(RG[i + 1]))); set(o.e, 'd', fd);
        set(o.ln, 'd', 'M' + [0.18, 0.4, 0.62].map(s2 => pt(P3(...ad(ad(R, d, s2), tv, (1.3 * (1 - s2) + 0.25) * 0.95)))).join('L')); set(o.ln, 'opacity', r2(0.8 * SM(DV(tv)[2] * 3)));
        const fr = Z3(...ad(R, d, 0.5)) > 3; if (o.fr !== fr) { o.fr = fr; (fr ? A.earF : A.earB).appendChild(o.g); } });
      // hair bun on top (springy) with twisted strands and a little flower on its front-right
      { const B = A.bun, C = [-ox * 0.12 + Math.sin(ts * 1.5) * 0.25, 18 + oy * 0.35 + Math.sin(ts * 2.1) * 0.2, -1], p = P3(...C), r = 8, cP = (x, y, rr) => 'M' + r2(x - rr) + ' ' + r2(y) + 'A' + r2(rr) + ' ' + r2(rr) + ' 0 1 0 ' + r2(x + rr) + ' ' + r2(y) + 'A' + r2(rr) + ' ' + r2(rr) + ' 0 1 0 ' + r2(x - rr) + ' ' + r2(y) + 'Z';
        set(B.e, 'd', cP(p[0], p[1], r)); const zc0 = Z3(...C);
        let tw = ''; [0.3, -0.25].forEach(la => { let pen = false; for (let k = 0; k <= 32; k++) { const b = k / 32 * TAU, q = [C[0] + r * Math.cos(la) * Math.sin(b), C[1] - r * Math.sin(la) + 1.4 * Math.sin(b + la * 3), C[2] + r * Math.cos(la) * Math.cos(b)]; if (Z3(...q) - zc0 > 0.8) { tw += (pen ? 'L' : 'M') + pt(P3(...q)); pen = true; } else pen = false; } }); set(B.tw, 'd', tw || 'M0 0');
        const Nn = [0.8, -0.5, 0.33].map(v => v / Math.hypot(0.8, 0.5, 0.33)), F0 = ad(C, Nn, 8.2), t1 = (() => { const v = [Nn[2], 0, -Nn[0]], l = Math.hypot(...v); return v.map(c => c / l); })(), t2 = [Nn[1] * t1[2] - Nn[2] * t1[1], Nn[2] * t1[0] - Nn[0] * t1[2], Nn[0] * t1[1] - Nn[1] * t1[0]];
        let pe = ''; for (let k = 0; k < 5; k++) { const a = k / 5 * TAU + Math.sin(ts * 0.8) * 0.15, Pc = ad(ad(ad(F0, t1, 2.6 * Math.cos(a)), t2, 2.6 * Math.sin(a)), Nn, 0.2); for (let m = 0; m < 8; m++) { const b = m / 8 * TAU; pe += (m ? 'L' : 'M') + pt(P3(...ad(ad(Pc, t1, 1.8 * Math.cos(b)), t2, 1.8 * Math.sin(b)))); } pe += 'Z'; }
        let ct = ''; for (let m = 0; m < 8; m++) { const b = m / 8 * TAU; ct += (m ? 'L' : 'M') + pt(P3(...ad(ad(ad(F0, Nn, 0.6), t1, 1.4 * Math.cos(b)), t2, 1.4 * Math.sin(b)))); }
        set(B.pe, 'd', pe); set(B.ct, 'd', ct + 'Z'); const fv = r2(SM((Z3(...F0) - zc0 + 2) / 3)); set(B.pe, 'opacity', fv); set(B.ct, 'opacity', fv); W.head = P3(C[0], C[1] - r, C[2]); }
      // wings: four see-through wings hinged on her upper back, buzzing all the time (faster with wfl, spread with wsp); behind her from the front, in front when she turns away
      { const wfl = clamp(cv('wfl'), 0, 1.5), wsp = clamp(cv('wsp'), 0, 1.5);
        A.WG.forEach(o => { const sd = o.sd, q0 = o.lo ? 0.8 : 0, phi = (o.lo ? 0.4 : 0.3) - wsp * 0.25 + Math.sin(ts * 15 + q0) * 0.22 * (1 - 0.4 * Math.min(1, wfl)) + wfl * 0.35 * Math.sin(ts * 34 + q0) - oy * 0.03, cf = Math.cos(phi), sf = Math.sin(phi), Hh = o.H;
          const WP = (u, v) => [Hh[0] + sd * u * 1.16 * cf, Hh[1] + v * 1.1 + u * u * 0.002 * Math.sin(ts * 3 + q0) - wsp * u * (o.lo ? -0.05 : 0.12), Hh[2] - u * 1.16 * sf];
          set(o.e, 'd', 'M' + o.WL.map(([u, v]) => pt(P3(...WP(u, v)))).join('L') + 'Z'); set(o.vn, 'd', 'M' + o.VN.map(([u, v]) => pt(P3(...WP(u, v)))).join('L'));
          const nz = Math.abs(DV([sf, 0, sd * cf])[2]); set(o.e, 'opacity', r2(0.6 + 0.3 * nz)); set(o.vn, 'opacity', r2(0.45 + 0.4 * nz));
          const bk = Z3(...WP(12, o.lo ? 4 : -6)) < -1; if (o.bk !== bk) { o.bk = bk; (bk ? A.wgB : A.wgF).appendChild(o.g); } if (!o.lo) W[sd < 0 ? 'wingL' : 'wingR'] = P3(...WP(28, -16)); }); } }
    // Berri: 3D strawberry - round skin, seeds in dimples all round (turn with him, hide round the back), calyx leaves + springy stem on top
    // Sweet Bakery batch 1: Cuppy (wrapper + pleats, frosting tiers with drips, piping swirl, sprinkles, cherry), Chip (crust edge, domed faces, chips), Twisty (3D pretzel rope with over/under)
    if (I.bk) { const B = I.bk, ts = now / 1000, pt = p => r2(p[0]) + ' ' + r2(p[1]);
      const tg = P.x * 1.4 + P.tilt * 0.5 + P.lean * 1.5 + P.turn * 12, ly = P.lift - sq * 8; if (B.p == null) { B.p = tg; B.v = 0; B.l = ly; B.lv = 0; }
      B.v += ((tg - B.p) * 120 - B.v * 7) * dtS; B.p += B.v * dtS; B.lv += ((ly - B.l) * 140 - B.lv * 7.5) * dtS; B.l += B.lv * dtS; const ox = clamp(B.p - tg, -12, 12), oy = clamp(B.l - ly, -6, 6);
      const g0 = glob(40, HY), g1 = glob(60, HY), kS = Math.hypot(g1[0] - g0[0], g1[1] - g0[1]) / 20;
      const circ = (c, r) => 'M' + r2(c[0] - r) + ' ' + r2(c[1]) + 'a' + r2(r) + ' ' + r2(r) + ' 0 1 0 ' + r2(2 * r) + ' 0a' + r2(r) + ' ' + r2(r) + ' 0 1 0 ' + r2(-2 * r) + ' 0Z';
      // every sub-shape gets the same winding as circ() so one path fills as their union
      const poly = Q => { let a = 0; for (let i = 0; i < Q.length; i++) { const p = Q[i], q = Q[(i + 1) % Q.length]; a += p[0] * q[1] - q[0] * p[1]; } if (Math.abs(a) < 0.02) return ''; if (a > 0) Q = Q.slice().reverse(); return 'M' + Q.map(pt).join('L') + 'Z'; };

      const ell = (cx, cy, rx, ry) => 'M' + r2(cx - rx) + ' ' + r2(cy) + 'a' + r2(rx) + ' ' + r2(ry) + ' 0 1 0 ' + r2(2 * rx) + ' 0a' + r2(rx) + ' ' + r2(ry) + ' 0 1 0 ' + r2(-2 * rx) + ' 0Z', bb = Q => { let x0 = 1e9, x1 = -1e9, y0 = 1e9, y1 = -1e9; Q.forEach(p => { if (p[0] < x0) x0 = p[0]; if (p[0] > x1) x1 = p[0]; if (p[1] < y0) y0 = p[1]; if (p[1] > y1) y1 = p[1]; }); return [x1 - x0, y1 - y0]; };
      if (B.kind === 'crois') { const KZ = B.KZ, hp = []; for (let i = 0; i <= 16; i++) { const y = 28 + 58 * i / 16, r = B.rT(y); if (r < 0.3) { hp.push(sph(50, y, 0)); continue; } for (let k = 0; k < 24; k++) { const f = k / 24 * TAU; hp.push(sph(50 + r * Math.sin(f), y, r * KZ * Math.cos(f))); } } B.d = H.closedD(H.hull(hp));
        { const c = glob(36, 34); B.gr.setAttribute('cx', r2(c[0])); B.gr.setAttribute('cy', r2(c[1])); B.gr.setAttribute('r', r2(62 * kS)); }
        // wrap lines: tilted rings round the middle roll (bow up near the top, down near the bottom), only the part facing you
        const ring = (y0, s, dx, dy) => { let d = '', pen = false; for (let j = 0; j <= 64; j++) { const f = Math.PI - yh + j / 64 * TAU; if (Math.cos(f + yh) > 0.06) { const y = y0 + s * 3.2 * Math.cos(f), r = B.rT(y) + 0.1, p = sph(50 + r * Math.sin(f), y, r * KZ * Math.cos(f)); d += (pen ? 'L' : 'M') + r2(p[0] + dx) + ' ' + r2(p[1] + dy); pen = true; } else pen = false; } return d; };
        set(B.rg, 'd', ring(36.5, -1, 0, 0) + ring(78.5, 1, 0, 0) || 'M0 0'); set(B.rgL, 'd', ring(36.5, -1, -0.3, 0.9) + ring(78.5, 1, -0.3, -0.9) || 'M0 0');
        const SG = B.SG.map(o => { const cr = Math.cos(o.rt), sr = Math.sin(o.rt), lv = o.lv, cx = o.c[0] + ox * 0.22 * lv + Math.sin(ts * 1.3 + o.ph) * 0.35 * lv, cy = o.c[1] - oy * 0.3 * lv + Math.sin(ts * 1.7 + o.ph) * 0.3 * lv, cz = o.c[2], Pp = [];
          for (let i = 0; i <= 6; i++) { const th = Math.PI * i / 6, st = Math.sin(th), ct = Math.cos(th), n = i === 0 || i === 6 ? 1 : 12; for (let k = 0; k < n; k++) { const f = k / n * TAU, lx = o.a * ct, ly = o.b * st * Math.cos(f), lz = o.cz * st * Math.sin(f); Pp.push(sph(cx + lx * cr - ly * sr, cy + lx * sr + ly * cr, cz + lz)); } }
          return { o, hl: H.hull(Pp), C: sph(cx, cy, cz), dz: sphZ(cx, cy, cz), cx, cy, cz, cr, sr }; });
        SG.forEach(s => { const { o, hl, C } = s, [w, h] = bb(hl); set(o.b0, 'd', H.closedD(hl)); set(o.m, 'd', H.closedD(hl.map(p => [C[0] + (p[0] - C[0]) * 0.93 - w * 0.02, C[1] + (p[1] - C[1]) * 0.94 - h * 0.025])));
          let sd = '', pen = false; for (let j = 0; j <= 16; j++) { const f = -1.2 + j / 16 * 2.4, ly = o.b * 0.92 * Math.sin(f), lz = o.cz * 0.92 * Math.cos(f), lx = o.a * 0.15, p = sph(s.cx + lx * s.cr - ly * s.sr, s.cy + lx * s.sr + ly * s.cr, s.cz + lz); sd += (pen ? 'L' : 'M') + pt(p); pen = true; } set(o.sh, 'd', sd);
          set(o.h, 'd', ell(C[0] - w * 0.15, C[1] - h * 0.22, w * 0.12, h * 0.07)); });
        const ord = SG.slice().sort((a, b) => a.dz - b.dz), k2 = ord.map(s => B.SG.indexOf(s.o) + (s.dz > 2 ? 'f' : 'b')).join(','); if (k2 !== B.ok) { B.ok = k2; ord.forEach(s => (s.dz > 2 ? B.gF : B.gB).appendChild(s.o.g)); } }
      if (B.kind === 'maca') { const hp = []; for (let i = 0; i <= 16; i++) { const y = 20 + 40 * i / 16, r = B.rTop(y); if (r < 0.3) { hp.push(sph(50, y, 0)); continue; } for (let k = 0; k < 28; k++) { const f = k / 28 * TAU; hp.push(sph(50 + r * Math.sin(f), y, r * Math.cos(f))); } } B.d = H.closedD(H.hull(hp));
        // ruffled shell feet: a band round the rim with a scalloped lower edge and little ridges, front half only (scallops slide round as he turns)
        B.RF.forEach(R => { const T = [], Bt = []; let dl = '', dk = '', pl = false; for (let j = 0; j <= 150; j++) { const f = Math.PI - yh + j / 150 * TAU; if (Math.cos(f + yh) <= 0.02) { pl = false; continue; }
            const s = Math.abs(Math.sin(R.n * f / 2)), yb2 = R.y0 + R.h * 0.55 + R.h * 0.75 * Math.sqrt(s), sf = Math.sin(f), cf = Math.cos(f), a = sph(50 + R.r * sf, R.y0, R.r * cf), b = sph(50 + (R.r + 0.2) * sf, yb2, (R.r + 0.2) * cf); T.push(a); Bt.push(b);
            dl += (pl ? 'L' : 'M') + pt(b); pl = true; if (j % 3 === 0) { const m = sph(50 + (R.r + 0.15) * sf, R.y0 + R.h * 0.35, (R.r + 0.15) * cf); dk += 'M' + pt(m) + 'L' + pt(sph(50 + (R.r + 0.2) * sf, R.y0 + R.h * 0.9, (R.r + 0.2) * cf)); } }
          set(R.e, 'd', T.length > 1 ? poly(T.concat(Bt.reverse())) : 'M0 0'); set(R.l, 'd', dl || 'M0 0'); set(R.k, 'd', dk || 'M0 0'); }); }
      if (B.kind === 'puddi') { const ca = Math.cos(B.vt), sa = Math.sin(B.vt), Z0 = B.z0, PV = (x, y, z) => { const dx = x - 50, x1 = dx * cyh + z * syh, z1 = -dx * syh + z * cyh; return headT(50 + x1, HY + (y - HY) * ca + (z1 - Z0) * sa); };
        const hp = []; for (let i = 0; i <= 18; i++) { const y = 38 + 48.8 * i / 18, r = B.rT(y); for (let k = 0; k < 28; k++) { const f = k / 28 * TAU; hp.push(PV(50 + r * Math.sin(f), y, r * Math.cos(f))); } } B.d = H.closedD(H.hull(hp));
        // plate: a round dish under him (raised rim, shallow well, rim shine), seen from the same angle so he sits right on it
        { const rg = (r, y) => { const Q = []; for (let k = 0; k < 40; k++) { const f = k / 40 * TAU; Q.push(PV(50 + r * Math.sin(f), y, r * Math.cos(f))); } return Q; }, o = rg(42, 87.6), u = rg(42, 89.4), w = rg(35, 87.4);
          set(B.pR, 'd', H.closedD(H.hull(o.concat(u)))); set(B.pS, 'd', H.closedD(H.hull(u.concat(rg(41, 90))))); set(B.pW, 'd', poly(w));
          let hd = ''; for (let j = 0; j <= 16; j++) { const f = -2.4 + j / 16 * 1.5 - yh; hd += (j ? 'L' : 'M') + pt(PV(50 + 39 * Math.sin(f), 87.4, 39 * Math.cos(f))); } set(B.pH, 'd', hd); }
        // caramel: covers the whole top and runs down all the way round in drips (front half drawn over him, the top face always shows)
        const R0 = B.rS(38) + 0.5, L = f => 2.4 + 7.5 * Math.pow(Math.max(0, Math.cos(6 * f + 0.5)), 6) + 3.8 * Math.pow(Math.max(0, Math.cos(6 * f + 2.4)), 6) + Math.max(0, -oy) * 0.25, top = [], T = [], Bt = [];
        for (let k = 0; k < 48; k++) { const f = k / 48 * TAU; top.push(PV(50 + R0 * Math.sin(f), 37.8, R0 * Math.cos(f))); }
        let dH = ''; for (let j = 0; j <= 160; j++) { const f = Math.PI - yh + j / 160 * TAU; if (Math.cos(f + yh) <= 0.0) continue; const sf = Math.sin(f), cf = Math.cos(f), y = 38 + L(f), r = B.rS(y) + 0.5; T.push(PV(50 + R0 * sf, 37.9, R0 * cf)); Bt.push(PV(50 + r * sf, y, r * cf)); }
        set(B.car, 'd', poly(top) + (T.length > 1 ? poly(T.concat(Bt.slice().reverse())) : '')); set(B.carT, 'd', poly(top));
        const ti = []; for (let k = 0; k < 40; k++) { const f = k / 40 * TAU; ti.push(PV(50 + (R0 - 1.6) * Math.sin(f), 37.6, (R0 - 1.6) * Math.cos(f))); } set(B.carH, 'd', poly(ti));
        let gd = ''; for (let j = 0; j <= 14; j++) { const f = -2.05 + j / 14 * 1.15 - yh, p = PV(50 + (R0 - 4) * Math.sin(f), 37.5, (R0 - 4) * Math.cos(f)); gd += (j ? 'L' : 'M') + pt(p); } set(B.carG, 'd', gd);
        // cream swirl + cherry: sways and lags behind his moves, cherry bobs on a spring
        const sw = ox * 0.3 + Math.sin(ts * 1.4) * 0.45, lf = y => clamp((38 - y) / 12, 0, 1), CRp = [[37.8, 9.6], [36.4, 10.2], [34.6, 9], [33.4, 8.4], [31.8, 6.6], [30.6, 5.4], [29.2, 3], [28.4, 0]];
        const cp3 = (x, y, z) => { const u = lf(y); return PV(x + sw * u, y - oy * 0.25 * u, z); }, cq = []; CRp.forEach(([y, r], i) => { if (r < 0.2) { cq.push(cp3(50, y, 0)); return; } for (let k = 0; k < 18; k++) { const f = k / 18 * TAU; cq.push(cp3(50 + r * Math.sin(f), y, r * Math.cos(f))); } });
        const ch = H.hull(cq), [cw, chh] = bb(ch), cc = cp3(50, 33, 0); set(B.cr, 'd', H.closedD(ch)); set(B.crM, 'd', H.closedD(ch.map(p => [cc[0] + (p[0] - cc[0]) * 0.88 - cw * 0.03, cc[1] + (p[1] - cc[1]) * 0.88 - chh * 0.04])));
        const sh = []; for (let k = 0; k < 24; k++) { const f = k / 24 * TAU; sh.push(PV(50.6 + 10.6 * Math.sin(f), 38, 10.6 * Math.cos(f))); } set(B.crS, 'd', poly(sh));
        let cl = ''; [34.8, 31.6].forEach(y0 => { let pen = false; for (let j = 0; j <= 24; j++) { const f = -Math.PI / 2 + j / 24 * Math.PI, y = y0 + 0.8 * Math.cos(f), r = (y0 > 33 ? 9.3 : 6.6) + 0.05; cl += (pen ? 'L' : 'M') + pt(cp3(50 + r * Math.sin(f), y, r * Math.cos(f))); pen = true; } }); set(B.crL, 'd', cl);
        set(B.crH, 'd', ell(cc[0] - cw * 0.2, cc[1] - chh * 0.18, cw * 0.12, chh * 0.08));
        if (B.cb == null) { B.cb = 0; B.cv = 0; } B.cv += ((-oy * 0.6 - B.cb) * 160 - B.cv * 6) * dtS; B.cb += B.cv * dtS; const CX = 52, CZ = 1.5, C = cp3(CX, 24.6 + B.cb * 0.4, CZ), r = 4 * kS;
        set(B.ch, 'd', circ(C, r)); set(B.chG, 'd', circ([C[0] - r * 0.38, C[1] - r * 0.42], r * 0.28));
        const SP = []; for (let k = 0; k <= 8; k++) { const u = k / 8, sw2 = Math.sin(ts * 1.9) * 0.6 * u; SP.push(cp3(CX + u * u * 4.6 + sw2, 21.4 + B.cb * 0.4 - u * 4.6 + u * u * 1.6 - 1.2 * u, CZ - u * 0.8)); }
        set(B.stem, 'd', 'M' + SP.map(pt).join('L')); W.top = SP[8];
        // cherry + stem go behind the cream when they turn round to his back
        const cbk = sphZ(CX, 25, CZ) < sphZ(50, 25, 0) - 0.5; if (B.cbk !== cbk) { B.cbk = cbk; const pp = B.cr.parentNode; if (cbk) { pp.insertBefore(B.stem, B.crS); pp.insertBefore(B.ch, B.crS); pp.insertBefore(B.chG, B.crS); } else { pp.appendChild(B.stem); pp.appendChild(B.ch); pp.appendChild(B.chG); } } }

      if (B.kind === 'mochi') { const hp = []; for (let i = 0; i <= 16; i++) { const y = 36 + 54 * i / 16, r = B.rT(y); if (r < 0.3) { hp.push(sph(50, y, 0)); continue; } for (let k = 0; k < 28; k++) { const f = k / 28 * TAU; hp.push(sph(50 + r * Math.sin(f), y, r * Math.cos(f))); } } B.d = H.closedD(H.hull(hp));
        { const Q = []; for (let k = 0; k < 24; k++) { const a = k / 24 * TAU; Q.push(glob(50 + 14 * Math.cos(a), 41 + 4.6 * Math.sin(a))); } set(B.bl, 'd', poly(Q)); }
        let pd = ''; B.PD.forEach(o => { const r = B.rT(o.y) + 0.1, X = r * Math.sin(o.f), Z = r * Math.cos(o.f); if (sphZ(50 + X, o.y, Z) - sphZ(50, o.y, 0) < r * 0.25) return; pd += circ(sph(50 + X, o.y, Z), 0.6 * kS); }); set(B.pd, 'd', pd || 'M0 0');
        // strawberry: sits in the top of the mochi, sways and lags behind his moves
        const LXs = ox * 0.3 + Math.sin(ts * 1.3) * 0.35, u0 = y => clamp((40 - y) / 20, 0, 1), P3s = (x, y, z) => { const u = u0(y); return sph(50 + x + LXs * u, y - oy * 0.3 * u, z); }, Z3s = (x, y, z) => sphZ(50 + x, y, z);
        const sp = []; for (let i = 0; i <= 12; i++) { const y = 20 + 24 * i / 12, r = B.rS(Math.min(y, 42)); if (r < 0.3) { sp.push(P3s(0, y, 0)); continue; } for (let k = 0; k < 24; k++) { const f = k / 24 * TAU; sp.push(P3s(r * Math.sin(f), y, r * Math.cos(f))); } }
        const sh = H.hull(sp), [sw0, sh0] = bb(sh), sc = P3s(0, 30, 0); set(B.sb, 'd', H.closedD(sh)); set(B.sh, 'd', ell(sc[0] - sw0 * 0.18, sc[1] - sh0 * 0.2, sw0 * 0.12, sh0 * 0.1));
        let dS = '', dD = ''; B.SD.forEach(o => { const X = o.r * Math.sin(o.f), Z = o.r * Math.cos(o.f); if (Z3s(X, o.y, Z) - Z3s(0, o.y, 0) < o.r * 0.3) return; const p = P3s(X, o.y, Z); dD += circ(p, 0.95 * kS); dS += ell(p[0], p[1] - 0.15 * kS, 0.45 * kS, 0.62 * kS); }); set(B.sd, 'd', dS || 'M0 0'); set(B.sdD, 'd', dD || 'M0 0');
        const swz = (ox * 1.4 + Math.sin(ts * 0.9) * 3) * D2R, cz = Math.cos(swz), sz2 = Math.sin(swz), R0 = [0, 21.2, 0], RT = v => { const x = v[0], y = v[1] - R0[1]; return [x * cz - y * sz2, R0[1] + x * sz2 + y * cz, v[2]]; };
        B.LV.forEach(o => { const el = o.el + Math.sin(ts * 1.6 + o.ph) * 0.06 - oy * 0.02, az = o.az + Math.sin(ts * 0.7 + o.ph) * 0.05, d = [Math.sin(az) * Math.cos(el), -Math.sin(el), Math.cos(az) * Math.cos(el)], n0 = [Math.cos(az), 0, -Math.sin(az)], L = [], Rr = [], M = [];
          for (let k = 0; k <= 8; k++) { const u = k / 8, w = o.W * Math.pow(Math.sin(Math.PI * Math.min(1, 0.08 + u * 0.92)), 0.8), dr = 1.6 * u * u * Math.cos(o.el), m = [d[0] * o.L * u, R0[1] + d[1] * o.L * u + dr, d[2] * o.L * u];
            M.push(P3s(...RT(m))); L.push(P3s(...RT([m[0] + n0[0] * w, m[1] - w * 0.25, m[2] + n0[2] * w]))); Rr.push(P3s(...RT([m[0] - n0[0] * w, m[1] - w * 0.25, m[2] - n0[2] * w]))); }
          set(o.e, 'd', 'M' + L.concat(Rr.reverse()).map(pt).join('L') + 'Z'); set(o.rb, 'd', 'M' + M.slice(0, 7).map(pt).join('L'));
          const bk = Z3s(d[0] * o.L * 0.5, R0[1] + d[1] * o.L * 0.5, d[2] * o.L * 0.5) < Z3s(0, 26, 0) - 2; if (o.bk !== bk) { o.bk = bk; (bk ? B.lfB : B.lfF).appendChild(o.g); } }); W.top = P3s(0, 12, 0); }
      if (B.kind === 'cakey') { const ca = Math.cos(B.vt), sa = Math.sin(B.vt), Z0 = B.z0, lg = y => clamp((44 - y) / 22, 0, 1), LX = ox * 0.3 + Math.sin(ts * 1.2) * 0.3;
        const PV = (x, y, z) => { const u = lg(y), dx = x - 50 + LX * u, x1 = dx * cyh + z * syh, z1 = -dx * syh + z * cyh; return headT(50 + x1, HY + (y - oy * 0.25 * u - HY) * ca + (z1 - Z0) * sa); }, VZ = (x, z) => -x * syh + z * cyh;
        B.TR.forEach((T, ti) => { const rr = y => { const a = y - T.yt, b = T.yb - y; let r = T.R; if (a < 3) r -= 3 - Math.sqrt(Math.max(0, 9 - (3 - a) * (3 - a))); if (b < 2) r -= 2 - Math.sqrt(Math.max(0, 4 - (2 - b) * (2 - b))); return r; };
          const hp = []; for (let i = 0; i <= 10; i++) { const y = T.yt + (T.yb - T.yt) * i / 10, r = rr(y); for (let k = 0; k < 32; k++) { const f = k / 32 * TAU; hp.push(PV(50 + r * Math.sin(f), y, r * Math.cos(f))); } }
          const D = H.closedD(H.hull(hp)); if (ti === 1) B.d = D; else set(T.e, 'd', D);
          const R0 = T.R + 0.35, top = [], Tp = [], Bt = [], L = f => 2.2 + 3.8 * Math.pow(Math.max(0, Math.cos(T.nd * f)), 4) + 2 * Math.pow(Math.max(0, -Math.cos(T.nd * f)), 6) + Math.max(0, -oy) * 0.2;
          for (let k = 0; k < 48; k++) { const f = k / 48 * TAU; top.push(PV(50 + R0 * Math.sin(f), T.yt + 0.4, R0 * Math.cos(f))); }
          for (let j = 0; j <= 96; j++) { const fv = -Math.PI / 2 + j / 96 * Math.PI, f = fv - yh, sf = Math.sin(f), cf = Math.cos(f); Tp.push(PV(50 + R0 * sf, T.yt + 0.5, R0 * cf)); Bt.push(PV(50 + R0 * sf, T.yt + L(f), R0 * cf)); }
          set(T.fe, 'd', poly(top) + poly(Tp.concat(Bt.reverse())));
          let gd = ''; for (let j = 0; j <= 16; j++) { const fv = -1.35 + j / 16 * 1.25, f = fv - yh; gd += (j ? 'L' : 'M') + pt(PV(50 + (R0 - 1.4) * Math.sin(f), T.yt + 0.6, (R0 - 1.4) * Math.cos(f))); } set(T.gle, 'd', gd);
          if (T.SP) { const sd = ['', '', '']; T.SP.forEach(o => { const f = o.f, r = T.R + 0.2; if (Math.cos(f + yh) < 0.2) return; const tg = [Math.cos(f), 0, -Math.sin(f)], ca2 = Math.cos(o.a) * 1.1, sa2 = Math.sin(o.a) * 1.1, X = r * Math.sin(f), Z = r * Math.cos(f);
            sd[o.c] += 'M' + pt(PV(50 + X + tg[0] * ca2, o.y + sa2, Z + tg[2] * ca2)) + 'L' + pt(PV(50 + X - tg[0] * ca2, o.y - sa2, Z - tg[2] * ca2)); }); T.sp.forEach((e, i) => set(e, 'd', sd[i] || 'M0 0')); } });
        // candles: round striped sticks on the top tier, sorted back to front; flames flicker and trail behind his moves
        const ord = B.CD.slice().sort((a, b) => VZ(a.x, a.z) - VZ(b.x, b.z)), ok = ord.map(o => o.i).join(''); if (ok !== B.ok) { B.ok = ok; ord.forEach(o => B.cdG.appendChild(o.g)); }
        B.CD.forEach(o => { const rc = 1.8, y0 = 26.8, y1 = 13, ring = y => { const Q = []; for (let k = 0; k < 16; k++) { const f = k / 16 * TAU; Q.push(PV(50 + o.x + rc * Math.sin(f), y, o.z + rc * Math.cos(f))); } return Q; };
          set(o.b, 'd', H.closedD(H.hull(ring(y0).concat(ring(y1))))); let sd = '';
          for (let s = 0; s < 3; s++) { let pen = false; for (let j = 0; j <= 14; j++) { const y = y0 - 1 - (y0 - y1 - 2) * j / 14, f = s * TAU / 3 + (y0 - y) * 0.55; if (Math.cos(f + yh) > 0.15) { sd += (pen ? 'L' : 'M') + pt(PV(50 + o.x + (rc + 0.05) * Math.sin(f), y, o.z + (rc + 0.05) * Math.cos(f))); pen = true; } else pen = false; } } set(o.s, 'd', sd || 'M0 0');
          const T0 = PV(50 + o.x, y1, o.z), Tw = PV(50 + o.x, y1 - 1, o.z); set(o.w, 'd', 'M' + pt(T0) + 'L' + pt(Tw));
          const h = 6.4 * (1 + 0.1 * Math.sin(ts * 11 + o.i * 2) + 0.06 * Math.sin(ts * 23 + o.i)) * kS, sw = (Math.sin(ts * 6 + o.i * 1.7) * 0.5 - ox * 0.25) * kS, bx = Tw[0], by = Tw[1] + 0.3 * kS, tp = [bx + sw * 2, by - h], k2 = kS;
          set(o.f1, 'd', 'M' + pt(tp) + 'Q' + r2(bx + 2.7 * k2 + sw) + ' ' + r2(by - h * 0.38) + ' ' + pt([bx, by]) + 'Q' + r2(bx - 2.7 * k2 + sw) + ' ' + r2(by - h * 0.38) + ' ' + pt(tp) + 'Z');
          const ti2 = [bx + sw * 1.2, by - h * 0.6]; set(o.f2, 'd', 'M' + pt(ti2) + 'Q' + r2(bx + 1.2 * k2 + sw * 0.6) + ' ' + r2(by - h * 0.2) + ' ' + r2(bx) + ' ' + r2(by - 0.4 * k2) + 'Q' + r2(bx - 1.2 * k2 + sw * 0.6) + ' ' + r2(by - h * 0.2) + ' ' + pt(ti2) + 'Z');
          set(o.gw, 'd', circ([bx + sw, by - h * 0.45], 4.4 * kS)); if (o.i === 1) W.top = tp; }); }
      if (B.kind === 'sugarplum') { const P3 = (x, y, z) => sph(50 + x, y, z), Z3 = (x, y, z) => sphZ(50 + x, y, z), HC = 44;
        { const hp = []; for (let i = 0; i <= 8; i++) { const la = -Math.PI / 2 + Math.PI * i / 8, r = 19 * Math.cos(la), y = HC - 19 * Math.sin(la); if (r < 0.3) { hp.push(P3(0, y, 0)); continue; } for (let k = 0; k < 24; k++) { const f = k / 24 * TAU; hp.push(P3(r * Math.sin(f), y, r * Math.cos(f))); } } B.d = H.closedD(H.hull(hp)); }
        // dress: body of revolution (fitted top, flared skirt), hem seen a touch from above, skirt sways and lags; pleats, apron, heart and collar ride on it
        if (B.dr) { const sw = y => ox * 0.12 * clamp((y - 66) / 22, 0, 1), hp = []; [62, 64, 67, 70, 74, 78, 82, 85].forEach(y => { const r = B.rD(y); for (let k = 0; k < 28; k++) { const f = k / 28 * TAU; hp.push(P3(r * Math.sin(f) + sw(y), y, r * Math.cos(f))); } });
          const Rh = B.rD(88); for (let k = 0; k < 40; k++) { const f = k / 40 * TAU; hp.push(P3(Rh * Math.sin(f) + sw(88), 88 + 2.6 * Math.cos(f + yh), Rh * Math.cos(f))); } set(B.dr.e, 'd', H.closedD(H.hull(hp)));
          if (B.pl) { let d = ''; for (let k = 0; k < 10; k++) { const f = (k + 0.5) / 10 * TAU; if (Math.cos(f + yh) < 0.15) continue; for (let j = 0; j <= 5; j++) { const y = 69 + (88 + 2.6 * Math.cos(f + yh) - 1.2 - 69) * j / 5, r = B.rD(Math.min(88, y)) + 0.1; d += (j ? 'L' : 'M') + pt(P3(r * Math.sin(f) + sw(y), y, r * Math.cos(f))); } } set(B.pl, 'd', d || 'M0 0'); }
          const zD = (x, y, k) => Math.sqrt(Math.max(0, Math.pow(B.rD(Math.min(88, y)), 2) - (x - 50) * (x - 50))) + k, av = r2(vis(sphZ(50, 78, zD(50, 78, 0)) + 2));
          if (B.ap) { set(B.ap.e, 'd', toD(B.ap.segs, (x, y) => P3(x - 50 + sw(y), y, zD(x, y, 0.25)))); set(B.ap.e, 'opacity', av); }
          if (B.ht) { set(B.ht.e, 'd', toD(B.ht.segs, (x, y) => P3(x - 50 + sw(y), y, zD(x, y, 0.45)))); set(B.ht.e, 'opacity', av); } }
        if (B.col) { const Q = []; for (let i = 0; i <= 6; i++) { const th = Math.PI * i / 6 - Math.PI / 2, cy = 63.5 + 5.2 * Math.sin(th), rr = 12.8 * Math.cos(th) + 0.3; for (let k = 0; k < 20; k++) { const f = k / 20 * TAU; Q.push(P3(rr * Math.sin(f), cy, rr * 0.95 * Math.cos(f))); } } set(B.col, 'd', H.closedD(H.hull(Q))); }
        // hair: one shell round the back, sides and top of her head (down to her shoulders at the sides and back), cut into patches; the ones facing you go over her head, the rest behind
        const hR = la => 21.5 + 1.5 * SM((-0.3 - la) / 0.5), lmin = th => lerp(0.42, -0.84, SM((Math.abs(th) - 1.3) / 0.38)), s2 = ox * 0.12 + Math.sin(ts * 1.2) * 0.2;
        const HPt = (th, la) => { const r = hR(la), w = SM((0.2 - la) / 0.9); return [r * Math.cos(la) * Math.sin(th) + s2 * w, HC - r * Math.sin(la) - oy * 0.1 * w, r * Math.cos(la) * Math.cos(th)]; };
        let dF = '', dB = '', x0 = 1e9, y0 = 1e9, x1 = -1e9, y1 = -1e9; const NT = 28, NL = 6;
        for (let i = 0; i < NT; i++) { const ta = -Math.PI + i / NT * TAU - 0.02, tb = -Math.PI + (i + 1) / NT * TAU + 0.02, tm = (ta + tb) / 2, l0 = lmin(tm);
          for (let j = 0; j < NL; j++) { const la = l0 + (Math.PI / 2 - l0) * j / NL - 0.02, lb = l0 + (Math.PI / 2 - l0) * (j + 1) / NL + 0.02; let zs = 0;
            const sc = [HPt(ta, la), HPt(tb, la), HPt(ta, lb), HPt(tb, lb), HPt(tm, la), HPt(tm, lb)].map(p => { zs += Z3(...p); const s = P3(...p); if (s[0] < x0) x0 = s[0]; if (s[0] > x1) x1 = s[0]; if (s[1] < y0) y0 = s[1]; if (s[1] > y1) y1 = s[1]; return s; });
            const dd = poly(H.hull(sc)); if (zs / 6 > 2) dF += dd; else dB += dd; } }
        set(B.hF, 'd', dF || 'M0 0Z'); set(B.hB, 'd', dB || 'M0 0Z'); { const bw = x1 - x0, bh = y1 - y0; B.hg.setAttribute('cx', r2(x0 + bw * 0.38)); B.hg.setAttribute('cy', r2(y0 + bh * 0.3)); B.hg.setAttribute('r', r2((bw + bh) * 0.42)); }
        let sd3 = ''; [-0.8, -0.4, 0, 0.4, 0.8].forEach(o2 => { const th = Math.PI + o2, P2 = []; for (let j = 0; j <= 6; j++) P2.push(HPt(th + Math.sin(j * 0.8 + o2 * 3) * 0.03, 1.15 - (1.15 - lmin(th) - 0.1) * j / 6)); if (P2.reduce((s, p) => s + Z3(...p), 0) / P2.length < 4) return; sd3 += 'M' + P2.map(p => pt(P3(...p))).join('L'); }); set(B.hS, 'd', sd3 || 'M0 0');
        // buns: round 3D balls on the top corners of her hair, bounce on a spring; behind her hair from the front, in front when that side turns to you
        if (B.bv == null) { B.bb2 = 0; B.bv = 0; } B.bv += ((-oy * 0.25 - B.bb2) * 170 - B.bv * 9) * dtS; B.bb2 += B.bv * dtS;
        B.BN.forEach(o => { const C = [o.sd * 18.5 + s2 * 0.8, 26.5 + B.bb2 * 0.5, -3], p = P3(...C), r = 7 * kS; set(o.e, 'd', circ(p, r)); set(o.h, 'd', ell(p[0] - r * 0.35, p[1] - r * 0.4, r * 0.28, r * 0.18));
          let l = '', pen = false; for (let k = 0; k <= 24; k++) { const b = k / 24 * TAU, q = [C[0] + 7.05 * Math.cos(0.25) * Math.sin(b), C[1] - 7.05 * Math.sin(0.25) + 1.2 * Math.sin(b * 2), C[2] + 7.05 * Math.cos(0.25) * Math.cos(b)]; if (Z3(...q) - Z3(...C) > 1) { l += (pen ? 'L' : 'M') + pt(P3(...q)); pen = true; } else pen = false; } set(o.l, 'd', l || 'M0 0');
          const fr = Z3(...C) > 6; if (o.fr !== fr) { o.fr = fr; (fr ? B.bunF : B.bunB).appendChild(o.g); } });
        // crown: a gold band with 5 points sitting on top of her hair (inside of the back half shows between the points), gem on the front point; bobs a little
        { const rc = 10.2, yb0 = 24.6 + B.bb2 * 0.3, cx = s2 * 0.9, hh = f => { let s = 0; for (let k = 0; k < 5; k++) { let d = Math.abs(((f - k * TAU / 5) % TAU + TAU + Math.PI) % TAU - Math.PI); s = Math.max(s, 1 - d / 0.5); } return 3 + 8 * Math.max(0, s) * (Math.abs(Math.sin(f / 2)) < 0.2 ? 1.12 : 1); };
          const band = (a0, a1) => { const tp = [], bs = []; for (let j = 0; j <= 40; j++) { const fv = a0 + (a1 - a0) * j / 40, f = fv - yh, sf = Math.sin(f), cf = Math.cos(f); tp.push(P3(cx + rc * sf, yb0 - hh(f), rc * cf)); bs.push(P3(cx + rc * sf, yb0, rc * cf)); } return [tp, bs]; };
          const [bt, bb0] = band(Math.PI / 2, Math.PI * 1.5), [ft, fb] = band(-Math.PI / 2, Math.PI / 2); set(B.cbk, 'd', 'M' + bt.concat(bb0.reverse()).map(pt).join('L') + 'Z'); set(B.cfr, 'd', 'M' + ft.concat(fb.slice().reverse()).map(pt).join('L') + 'Z');
          let bd = ''; for (let j = 0; j <= 40; j++) { const f = -Math.PI / 2 + j / 40 * Math.PI - yh; bd += (j ? 'L' : 'M') + pt(P3(cx + (rc + 0.1) * Math.sin(f), yb0 - 2, (rc + 0.1) * Math.cos(f))); } set(B.cbd, 'd', bd);
          const gp = P3(cx, yb0 - 4.2, rc + 0.4), gv = r2(SM((Math.cos(yh) - 0.1) / 0.25)); set(B.gem, 'd', circ(gp, 1.6 * kS)); set(B.gemH, 'd', circ([gp[0] - 0.5 * kS, gp[1] - 0.55 * kS], 0.45 * kS)); set(B.gem, 'opacity', gv); set(B.gemH, 'opacity', gv); W.head = P3(cx, yb0 - 12, 0); } }
      if (B.kind === 'cuppy') { const lag = y => { const u = clamp((60 - y) / 50, 0, 1); return u * u; }, sw = Math.sin(ts * 1.3) * 0.5 + Math.sin(ts * 0.7 + 1) * 0.3;
        const F = (x, y, z) => { const u = lag(y); return sph(50 + x + (ox * 0.6 + sw) * u, y - oy * 0.4 * u, z); }, FZ = (x, y, z) => sphZ(50 + x, y, z);
        const hp = []; for (let i = 0; i <= 14; i++) { const y = 54 + 36 * i / 14, r = B.wr(y); for (let k = 0; k < 28; k++) { const f = k / 28 * TAU; hp.push(sph(50 + r * Math.sin(f), y, r * Math.cos(f))); } } B.d = H.closedD(H.hull(hp));
        let dP = '', dL = ''; for (let k = 0; k < 18; k++) { const f = (k + 0.5) / 18 * TAU; let pen = false; for (let j = 0; j <= 8; j++) { const y = 57 + 31 * j / 8, r = B.wr(y) + 0.05, X = r * Math.sin(f), Z = r * Math.cos(f);
          if (FZ(X, y, Z) / r > 0.08) { const p = sph(50 + X, y, Z), c = pen ? 'L' : 'M'; dP += c + pt(p); dL += c + r2(p[0] + 0.55) + ' ' + r2(p[1]); pen = true; } else pen = false; } }
        set(B.pl, 'd', dP || 'M0 0'); set(B.plL, 'd', dL || 'M0 0');
        B.T.forEach((T, ti) => { const hq = []; for (let i = 0; i <= 12; i++) { const y = T.yt + (T.yb - T.yt) * i / 12, r = T.rf(y); if (r < 0.3) { hq.push(F(0, y, 0)); continue; } for (let k = 0; k < 28; k++) { const f = k / 28 * TAU; hq.push(F(r * Math.sin(f), y, r * Math.cos(f))); } }
          let d = poly(H.hull(hq)); const rb = T.rf(T.yb) - T.dr * 0.55;
          for (let k = 0; k < T.nd; k++) { const f = (k + 0.5 * ti) / T.nd * TAU + T.ph, X = rb * Math.sin(f), Z = rb * Math.cos(f); if (FZ(X, T.yb, Z) < -rb * 0.3) continue; d += circ(F(X, T.yb + T.dr * 0.3 + (k % 2) * 0.6, Z), T.dr * kS); }
          set(T.e, 'd', d);
          let gD = '', gL = ''; [[T.yb - 2.4, 0], [T.yt + (T.yb - T.yt) * 0.42, 1]].forEach(([yy, hl]) => { let pen = false; for (let j = 0; j <= 48; j++) { const f = -Math.PI / 2 + j / 48 * Math.PI, y = yy + Math.sin(f * 3 + T.ph) * 0.5, r = T.rf(y) + 0.05, X = r * Math.sin(f), Z = r * Math.cos(f);
            const ok = r > 1 && FZ(X, y, Z) / r > 0.15 && (!hl || X < r * 0.35); if (ok) { const p = F(X, y, Z), c = pen ? 'L' : 'M'; if (hl) gL += c + pt(p); else gD += c + pt(p); pen = true; } else pen = false; } });
          set(T.gd, 'd', gD || 'M0 0'); set(T.gl, 'd', gL || 'M0 0');
          const sd = ['', '', '']; T.SP.forEach(o => { const r = T.rf(o.y) + 0.35, sf = Math.sin(o.f), cf = Math.cos(o.f), X = r * sf, Z = r * cf; if (r < 1 || FZ(X, o.y, Z) / r < 0.18) return;
            const ca = Math.cos(o.a) * 1.3, sa = Math.sin(o.a) * 1.3, a = F(X + cf * ca, o.y + sa, Z - sf * ca), b = F(X - cf * ca, o.y - sa, Z + sf * ca); sd[o.c] += 'M' + pt(a) + 'L' + pt(b); });
          T.sp.forEach((e, i) => set(e, 'd', sd[i] || 'M0 0')); });
        const cb = Math.sin(ts * 2.2) * 0.35 - Math.max(0, oy) * 0.15, C = F(1.5 + ox * 0.12, 7.6 + cb, 0), cr = 4 * kS;
        set(B.ch, 'd', circ(C, cr)); set(B.chG, 'd', circ([C[0] - cr * 0.38, C[1] - cr * 0.42], cr * 0.28));
        const SP = []; for (let k = 0; k <= 8; k++) { const u = k / 8, a = (Math.sin(ts * 1.9) * 6 + ox * 1.5) * D2R * u; SP.push(F(1.5 + 2 * (1 - u) * u * 1.2 + u * u * 5 + Math.sin(a) * 3 * u, 4 + cb - 2 * (1 - u) * u * 5 - u * u * 6.4, u * 1.4)); } set(B.stem, 'd', 'M' + SP.map(pt).join('L')); W.top = SP[8]; }
      if (B.kind === 'chip') { const T = B.T, D = B.D, ZF = B.ZF, R = B.rim, c0 = B.cx0, c1 = B.cy0, rimAt = (s, z) => R.map(p => sph(c0 + (p[0] - c0) * s, c1 + (p[1] - c1) * s, z));
        let d = ''; [[1, T], [1, -T], [0.8, T + D * 0.36], [0.8, -T - D * 0.36], [0.5, T + D * 0.75], [0.5, -T - D * 0.75]].forEach(([s, z]) => { d += poly(rimAt(s, z)); });
        const Fp = rimAt(1, T), Bp = rimAt(1, -T); for (let i = 0; i < R.length; i++) { const j = (i + 1) % R.length; d += poly([Fp[i], Fp[j], Bp[j], Bp[i]]); } B.d = d;
        const fz = sphZ(c0, c1, T + 1) - sphZ(c0, c1, T), fr = fz >= 0, sdv = fr ? 1 : -1, ev = r2(SM((Math.abs(fz) - 0.12) / 0.3)); set(B.pl, 'd', poly(fr ? Fp : Bp));
        { const zf = (x, y) => sdv * (ZF(x, y) + 0.05), mx = x => fr ? x : 100 - x, dsc = (x, y, r) => { const Q = []; for (let k = 0; k < 12; k++) { const a = k / 12 * TAU; Q.push(sph(mx(x) + Math.cos(a) * r, y + Math.sin(a) * r * 0.92, zf(mx(x) + Math.cos(a) * r, y + Math.sin(a) * r))); } return poly(Q); };
          const zr = sdv * (T + 0.05), ring = (s0, s1) => { const o = rimAt(s0, zr), i = rimAt(s1, sdv * (T + D * (1 - s1 * s1) * 0.9 + 0.05)); return 'M' + o.map(pt).join('L') + 'Z M' + i.map(pt).join('L') + 'Z'; };
          set(B.edge, 'd', ring(1, 0.88)); set(B.edge2, 'd', ring(0.88, 0.76));
          set(B.tst, 'd', B.TS.map(o => dsc(...o)).join('')); set(B.tst2, 'd', B.TS2.map(o => dsc(...o)).join('')); set(B.pit, 'd', B.PT.map(o => dsc(o[0], o[1], o[2] * 1.4)).join(''));
          set(B.shn, 'd', dsc(fr ? 36 : 64, 40, 9) + dsc(fr ? 32 : 68, 48, 5));
          let ck = '', cl = ''; B.CK.forEach(L => { const Q = L.map(p => sph(mx(p[0]), p[1], zf(mx(p[0]), p[1]))); ck += 'M' + Q.map(pt).join('L'); cl += 'M' + Q.map(p => r2(p[0] - 0.4) + ' ' + r2(p[1] - 0.45)).join('L'); }); set(B.crk, 'd', ck); set(B.crkL, 'd', cl);
          [[B.edge, 0.5], [B.edge2, 0.35], [B.tst, 0.32], [B.tst2, 0.28], [B.shn, 0.35], [B.crk, 0.55], [B.crkL, 0.5], [B.pit, 0.5]].forEach(([e, o]) => set(e, 'opacity', r2(o * ev))); }
        let dc = '', dh = ''; B.CH.forEach(o => { if (o.sd !== sdv) return; const z0 = sdv * ZF(o.x, o.y), Q = []; for (let k = 0; k < 10; k++) { const a = k / 10 * TAU; Q.push(sph(o.x + Math.cos(a) * o.s, o.y + Math.sin(a) * o.s * 0.9, z0)); }
          Q.push(sph(o.x + 0.2 * o.s, o.y - o.s * 0.3, z0 + sdv * o.s * 0.55)); dc += poly(H.hull(Q)); dh += circ(sph(o.x - o.s * 0.3, o.y - o.s * 0.45, z0 + sdv * o.s * 0.42), o.s * 0.26 * kS); });
        let dk = ''; if (fr) B.CR.forEach(o => { dk += circ(sph(o[0], o[1], ZF(o[0], o[1]) + 0.1), o[2] * kS); });
        set(B.ce, 'd', dc || 'M0 0'); set(B.chh, 'd', dh || 'M0 0'); set(B.cr, 'd', dk || 'M0 0'); [B.ce, B.chh, B.cr].forEach(e => set(e, 'opacity', ev)); }
      if (B.kind === 'twisty') { const S = B.S, front = cyh * cp >= 0, lag = y => { const u = clamp((66 - y) / 52, 0, 1); return u * u; }, sw = Math.sin(ts * 1.1) * 0.4, LX = ox * 0.45 + sw;
        const pr = S.map(o => { const u = lag(o.y), p = sph(o.x + LX * u, o.y - oy * 0.3 * u, o.z); return [p[0], p[1], o.r * kS]; });
        const lay = ix => { let b = '', m = '', h = ''; ix.forEach(i => { const [x, y, r] = pr[i]; b += circ([x, y], r); m += circ([x - 0.07 * r, y - 0.09 * r], r * 0.89); h += circ([x - 0.3 * r, y - 0.36 * r], r * 0.42); }); return [b, m, h]; };
        { const c = glob(34, 30), gg = B.gr; gg.setAttribute('cx', r2(c[0])); gg.setAttribute('cy', r2(c[1])); gg.setAttribute('r', r2(70 * kS)); }
        const all = lay(B.iAll); B.d = all[0]; set(B.mid, 'd', all[1]); set(B.hi, 'd', all[2]);
        const setP = (Pc, show, cl) => { const Lr = lay(show); set(Pc.b, 'd', Lr[0] || 'M0 0'); set(Pc.m, 'd', Lr[1] || 'M0 0'); set(Pc.h, 'd', Lr[2] || 'M0 0'); set(Pc.cp, 'd', cl.map(i => circ([pr[i][0], pr[i][1]], pr[i][2] + 0.35)).join('') || 'M0 0'); };
        setP(B.px[0], front ? B.aX : B.bX, front ? B.aXc : B.bXc); setP(B.px[1], front ? B.aE : B.belA, B.aEc); setP(B.px[2], front ? B.bE : B.belB, B.bEc);
        let dS = ''; B.SL.forEach(o => { const s = S[o.i], c = Math.cos(o.th), nx = c * s.nx, ny = c * s.ny, nz = Math.sin(o.th), q = [s.x + nx * s.r, s.y + ny * s.r, s.z + nz * s.r];
          if (sphZ(q[0] + nx, q[1] + ny, q[2] + nz) - sphZ(q[0], q[1], q[2]) < 0.3) return; const u = lag(q[1]), p = sph(q[0] + LX * u, q[1] - oy * 0.3 * u, q[2]), k = 1.1 * kS;
          dS += 'M' + r2(p[0]) + ' ' + r2(p[1] - k) + 'L' + r2(p[0] + k * 0.9) + ' ' + r2(p[1]) + 'L' + r2(p[0]) + ' ' + r2(p[1] + k) + 'L' + r2(p[0] - k * 0.9) + ' ' + r2(p[1]) + 'Z'; }); set(B.salt, 'd', dS || 'M0 0'); } }
    if (I.br) { const A = I.br, ts = now / 1000, P3 = (x, y, z) => sph(50 + x, y, z), Z3 = (x, y, z) => sphZ(50 + x, y, z), pt = p => r2(p[0]) + ' ' + r2(p[1]), cv = k => { const v = +P[k]; return v === v ? v : 0; };
      const tg = P.x * 1.4 + P.tilt * 0.5 + P.lean * 1.5 + P.turn * 12, ly = P.lift - sq * 8; if (A.p == null) { A.p = tg; A.v = 0; A.l = ly; A.lv = 0; }
      A.v += ((tg - A.p) * 120 - A.v * 7) * dtS; A.p += A.v * dtS; A.lv += ((ly - A.l) * 140 - A.lv * 7.5) * dtS; A.l += A.lv * dtS; const ox = clamp(A.p - tg, -12, 12), oy = clamp(A.l - ly, -6, 6);
      const hp = []; for (let i = 0; i <= 24; i++) { const y = 30 + 62 * (0.5 - 0.5 * Math.cos(Math.PI * i / 24)), r = A.rT(y); if (r < 0.3) { hp.push(P3(0, y, 0)); continue; } for (let k = 0; k < 30; k++) { const f = k / 30 * TAU; hp.push(P3(r * Math.sin(f), y, r * Math.cos(f))); } }
      A.d = H.closedD(H.hull(hp));
      let dS = '', dP = ''; A.SD.forEach(o => { const sf = Math.sin(o.f), cf = Math.cos(o.f), nn = Math.hypot(1, o.dr), S = [o.r * sf, o.y, o.r * cf]; if (Z3(S[0], S[1], S[2]) / o.r < 0.1) return;
        const n = [sf / nn, -o.dr / nn, cf / nn], t = [cf, 0, -sf], u = [o.dr * sf / nn, 1 / nn, o.dr * cf / nn], E = (a, b, k) => pt(P3(S[0] + u[0] * a + t[0] * b + n[0] * k, S[1] + u[1] * a + t[1] * b + n[1] * k, S[2] + u[2] * a + t[2] * b + n[2] * k));
        for (let k = 0; k < 10; k++) { const a = k / 10 * TAU, c = Math.cos(a), s = Math.sin(a), m = k ? 'L' : 'M'; dP += m + E(0.35 + c * 2.1, s * 1.2, -0.1); dS += m + E(c * (c < 0 ? 1.75 : 1.15), s * 0.62 * (c < 0 ? 1 + 0.35 * c : 1), 0.3); } dP += 'Z'; dS += 'Z'; });
      set(A.dim, 'd', dP || 'M0 0Z'); set(A.sdE, 'd', dS || 'M0 0Z');
      const lsp = cv('lsp') * TAU, lfl = clamp(cv('lfl'), -0.6, 1.3), swz = (ox * 1.6 + Math.sin(ts * 0.9) * 2.5 + clamp(P.htilt || 0, -10, 10) * 0.3) * D2R, swx = (oy * 2.2 + Math.sin(ts * 0.7 + 1) * 1.5) * D2R, B0 = [0, 31, 0];
      const LT = [-0.45, -0.72, 0.53], DV = v => { const x1 = v[0] * cyh + v[2] * syh, z1 = -v[0] * syh + v[2] * cyh; return [x1, v[1] * cp - z1 * sp, v[1] * sp + z1 * cp]; };
      const col = b => { const Aa = b < 0.55 ? [[44, 120, 46], [118, 200, 88], b / 0.55] : [[118, 200, 88], [204, 246, 158], (b - 0.55) / 0.45]; return 'rgb(' + Aa[0].map((c, j) => Math.round(c + (Aa[1][j] - c) * Aa[2])).join(',') + ')'; };
      const cz = Math.cos(swz), sz2 = Math.sin(swz), cx2 = Math.cos(swx), sx2 = Math.sin(swx), T = v => { const x = v[0] - B0[0], y = v[1] - B0[1], z = v[2] - B0[2], x1 = x * cz - y * sz2, y1 = x * sz2 + y * cz; return [x1 + B0[0], y1 * cx2 - z * sx2 + B0[1], y1 * sx2 + z * cx2 + B0[2]]; };
      A.LV.forEach(o => { const er = (o.az > 0 ? P.earR : -P.earL) || 0, el = Math.min(1.45, o.el + lfl * 0.5 + Math.sin(ts * 1.7 + o.ph) * 0.05 + Math.sin(ts * 9 + o.ph) * 0.05 * Math.max(0, lfl) + clamp(er, -40, 40) * 0.006 - oy * 0.02), az = o.az + lsp + Math.sin(ts * 0.6 + o.ph) * 0.06;
        const d = [Math.sin(az) * Math.cos(el), -Math.sin(el), Math.cos(az) * Math.cos(el)], sg = o.az > 0 ? 1 : -1, n0 = [-Math.cos(az) * sg, 0, Math.sin(az) * sg], cr0 = [n0[1] * d[2] - n0[2] * d[1], n0[2] * d[0] - n0[0] * d[2], n0[0] * d[1] - n0[1] * d[0]].map(v => v * -sg);
        const M = [], U = [], Dn = []; for (let k = 0; k <= 8; k++) { const u = k / 8, w = o.W * Math.pow(Math.sin(Math.PI * Math.min(1, 0.07 + u * 0.93)), 0.8), bw = 1.6 * Math.sin(Math.PI * u), cu = -1.4 * u * u;
          const m = [0, 1, 2].map(j => B0[j] + d[j] * o.L * u + cr0[j] * bw + (j === 1 ? cu : 0)); M.push(T(m)); U.push(T(m.map((v, j) => v + cr0[j] * w * 1.05 + n0[j] * w * 0.35))); Dn.push(T(m.map((v, j) => v - cr0[j] * w * 0.85 + n0[j] * w * 0.35))); }
        const Mp = M.map(v => P3(...v)), Up = U.map(v => P3(...v)), Dp = Dn.map(v => P3(...v));
        set(o.hU, 'd', 'M' + Mp.concat(Up.slice().reverse()).map(pt).join('L') + 'Z'); set(o.hD, 'd', 'M' + Mp.concat(Dp.slice().reverse()).map(pt).join('L') + 'Z'); set(o.rib, 'd', 'M' + Mp.slice(0, 8).map(pt).join('L'));
        const lit = E => { const a = [M[6][0] - M[2][0], M[6][1] - M[2][1], M[6][2] - M[2][2]], b = [E[4][0] - M[4][0], E[4][1] - M[4][1], E[4][2] - M[4][2]], c = [a[1] * b[2] - a[2] * b[1], a[2] * b[0] - a[0] * b[2], a[0] * b[1] - a[1] * b[0]], v = DV(c), l = Math.hypot(v[0], v[1], v[2]) || 1, s2 = v[2] < 0 ? -1 : 1; return clamp(0.32 + 0.68 * Math.max(0, s2 * (v[0] * LT[0] + v[1] * LT[1] + v[2] * LT[2]) / l), 0, 1); };
        set(o.hU, 'fill', col(lit(U))); set(o.hD, 'fill', col(lit(Dn) * 0.85));
        const bk = sphZ(50 + M[4][0], M[4][1], M[4][2]) < -2; if (o.bk !== bk) { o.bk = bk; (bk ? A.lfB : A.lfF).appendChild(o.g); } });
      // stem: a round stalk rising from the calyx and curling to his right; it sways on a spring (more than the leaves) and boings with stw
      const stw = clamp(cv('stw'), -1, 1.5), a1 = swz * 1.6 + stw * 0.3 * Math.sin(ts * 12), b1 = swx * 1.4 + stw * 0.12 * Math.cos(ts * 10), ca = Math.cos(a1), sa = Math.sin(a1), cb = Math.cos(b1), sb = Math.sin(b1), SP = [];
      for (let k = 0; k <= 12; k++) { const s = k / 12; let x = 0, y = 31 - s / 0.4 * 9, z = 0; if (s > 0.4) { const w = (s - 0.4) / 0.6; x = 5 * w * w; y = (1 - w) * (1 - w) * 22 + 2 * (1 - w) * w * 15 + w * w * 11; z = -0.8 * w * w; }
        const vy = y - 31, x1 = x * ca - vy * sa, y1 = x * sa + vy * ca; SP.push(P3(x1, 31 + y1 * cb - z * sb, y1 * sb + z * cb)); }
      const sdP = 'M' + SP.map(pt).join('L'); set(A.st[0], 'd', sdP); set(A.st[1], 'd', sdP); set(A.st[2], 'd', 'M' + SP.slice(2).map(p => r2(p[0] - 0.45) + ' ' + r2(p[1] - 0.3)).join('L')); W.stem = SP[12]; }
    if (I.bb) { const B = I.bb, ts = now / 1000, tg = P.x * 1.4 + P.tilt * 0.5 + P.lean * 1.5 + P.turn * 12, ly = P.lift - sq * 8, ID = (x, y) => [x, y];
      if (B.p == null) { B.p = tg; B.v = 0; B.l = ly; B.lv = 0; B.sw = 0; }
      B.v += ((tg - B.p) * 110 - B.v * 6) * dtS; B.p += B.v * dtS; B.lv += ((ly - B.l) * 130 - B.lv * 6.5) * dtS; B.l += B.lv * dtS;
      const ox = clamp(B.p - tg, -12, 12), oy = clamp(B.l - ly, -7, 7), pop = clamp(+P.pop || 0, 0, 2); B.sw += dtS * (0.12 + clamp(+P.swirl || 0, -3, 3) * 3.2);
      B.sl = clamp(-ox * 0.022 + Math.sin(ts * 1.4) * 0.02, -0.2, 0.2); B.wv = 0.25 + clamp(Math.abs(B.v) / 40 + Math.abs(B.lv) / 30 + pop * 0.5, 0, 1.2); B.t = ts;
      B.P.forEach(p => { const hop = pop * (2.5 + 6 * p.hs) * Math.abs(Math.sin(ts * (7 + p.hs * 3) + p.ph)), y = clamp(p.y0 - hop - oy * (0.5 + p.hs) * 0.9 + Math.sin(ts * 1.2 + p.ph) * 0.35, 58 + p.r, 89.5 - p.r);
        const Ri = Math.max(3, 26 - (y - 30) * 6 / 58 - p.r - 1), th = p.th + yb + B.sw * (0.5 + p.hs * 0.8), u = clamp(Ri * Math.sin(th) + ox * 0.35, -Ri, Ri), w = Ri * Math.cos(th), fr = w > 0;
        if (fr !== p.fr) { p.fr = fr; const gg = fr ? B.gF : B.gB; gg.appendChild(p.e); if (p.h) gg.appendChild(p.h); }
        const C = glob(50 + u, y + B.sl * u), R = p.r * (1 + w / 110), dv = SM((w / Ri + 0.35) / 0.7);
        set(p.e, 'd', toD(ellS(C[0], C[1], R, R, 0, 8), ID)); set(p.e, 'opacity', r2(p.op * (0.4 + 0.6 * dv)));
        if (p.h) { set(p.h, 'd', toD(ellS(C[0] - 0.3 * R, C[1] - 0.36 * R, 0.3 * R, 0.2 * R, 0, 6), ID)); set(p.h, 'opacity', r2(0.3 * dv)); } });
      const sa = (ox * 1.0 + Math.sin(ts * 1.5) * 2.5 + clamp(+P.stw || 0, 0, 2) * Math.sin(ts * 15) * 7 + clamp(P.htilt, -10, 10) * 0.5) * D2R, ca = Math.cos(sa), sn = Math.sin(sa), su = -clamp(+P.sup || 0, 0, 1.5) * 5;
      B.SF = (x, y) => { const vx = x - 58, vy = y - 30; return byw(58 + vx * ca - vy * sn, 30 + vx * sn + vy * ca + su, 0); };
      const sl = clamp(+P.slurp || 0, 0, 1); if (sl > 0.02) { const f = (ts * 1.4) % 1, Q = B.SF(58 + 10 * f, 32 - 28 * f), v = sl * SM(f * 5) * (1 - SM((f - 0.8) / 0.2)); set(B.sp, 'd', toD(ellS(Q[0], Q[1], 2.1, 2.1, 0, 8), ID)); set(B.sp, 'opacity', r2(v)); } else set(B.sp, 'opacity', 0);
      if (B.cup) { set(B.sh, 'd', toD(B.cup.segs, globN)); const ga = glob(24, 60), gb = glob(76, 60); set(B.gr, 'x1', r2(ga[0])); set(B.gr, 'y1', r2(ga[1])); set(B.gr, 'x2', r2(gb[0])); set(B.gr, 'y2', r2(gb[1])); } }
    if (I.orb) { const O = I.orb, t = now / 1000, hx = O.home[0] + Math.sin(t * 0.9) * 3, hy = O.home[1] + Math.sin(t * 1.3 + 1) * 2.5, hz = 6 + Math.sin(t * 0.7) * 9, X = hx * cyb + hz * syb, Z = -hx * syb + hz * cyb, tg = glob(HX + X, HY + hy);
      if (!O.P) O.P = tg; const kf = Math.min(1, dtS * 6); O.P = [O.P[0] + (tg[0] - O.P[0]) * kf, O.P[1] + (tg[1] - O.P[1]) * kf]; O.s = 1 + Z / 140;
      const z0 = Z < -3 ? -1 : 1; if (z0 !== O.Z) { O.Z = z0; O.els.forEach(el => (z0 < 0 ? O.back : O.front).appendChild(el)); } }
    const bend = (q, a) => (x, y, i) => { const w = q.wt ? (q.wt[i] || 0) : 1, R = q.R; if (!R || Math.abs(a * w) < 1e-4) return [x, y]; const c = Math.cos(a * w), s = Math.sin(a * w), vx = x - R[0], vy = y - R[1]; return [R[0] + vx * c - vy * s, R[1] + vx * s + vy * c]; };
    const mapSeg = (segs, F) => { let i = 0; return toD(segs, (x, y) => F(x, y, i++)); };
    const spikeD = () => { const S = I.spk, C = sph(HX, HY, 0); let d = '';
      // Puff: the spike crown swishes left and right round his body and every spike sways on its own
      if (S.pu) { let ext = clamp(P.puff, 0, 1.2) * 5 + clamp(P.wide, 0, 1) * 2.5 + Math.max(0, -sq) * 8 + Math.max(0, sq) * 4; ext = Math.min(ext, 6 + (I.pfB || 0) * 2.5); let dB = '', dF = '';
        S.dirs.forEach(n => { const fr = n[2] > 0.6, r1 = fr ? S.r0 + 2.8 + ext * 0.5 : S.r1 + ext, sw = fr ? S.w * 0.72 : S.w, ax0 = Math.abs(n[1]) > 0.9 ? [1, 0, 0] : [0, 1, 0], a0 = [n[1] * ax0[2] - n[2] * ax0[1], n[2] * ax0[0] - n[0] * ax0[2], n[0] * ax0[1] - n[1] * ax0[0]], al = Math.hypot(a0[0], a0[1], a0[2]) || 1, A = a0.map(v => v / al), Bv = [n[1] * A[2] - n[2] * A[1], n[2] * A[0] - n[0] * A[2], n[0] * A[1] - n[1] * A[0]], pts = [];
          for (let k = 0; k < 10; k++) { const f = k / 10 * TAU, c = Math.cos(f) * sw, s = Math.sin(f) * sw; pts.push(sph(HX + n[0] * S.rb + A[0] * c + Bv[0] * s, HY + n[1] * S.rb + A[1] * c + Bv[1] * s, n[2] * S.rb + A[2] * c + Bv[2] * s)); }
          pts.push(sph(HX + n[0] * r1, HY + n[1] * r1, n[2] * r1)); const dd = H.closedD(H.hull(pts)); if (sphZ(HX + n[0] * S.r0, HY + n[1] * S.r0, n[2] * S.r0) > S.r0 * 0.35) dF += dd; else dB += dd; });
        set(S.elF, 'd', dF); const gw = glob(S.g0[0], S.g0[1]); set(S.gr, 'cx', r2(gw[0])); set(S.gr, 'cy', r2(gw[1])); return dB; }
      S.dirs.forEach((n0, si) => { const n = n0; const r1 = S.pu ? S.r1 + clamp(P.puff, 0, 1.2) * 5 + clamp(P.wide, 0, 1) * 2.5 + Math.max(0, -sq) * 8 + Math.max(0, sq) * 4 : S.r1, T = sph(HX + n[0] * r1, HY + n[1] * r1, n[2] * r1); if (Math.hypot(T[0] - C[0], T[1] - C[1]) < S.r0 * 0.8) return;
      const B = sph(HX + n[0] * S.rb, HY + n[1] * S.rb, n[2] * S.rb), vx = T[0] - B[0], vy = T[1] - B[1], L = Math.hypot(vx, vy); if (L < 0.8) return; const px = -vy / L * S.w, py = vx / L * S.w;
      d += 'M' + r2(B[0] + px) + ' ' + r2(B[1] + py) + 'L' + r2(T[0]) + ' ' + r2(T[1]) + 'L' + r2(B[0] - px) + ' ' + r2(B[1] - py) + 'Z'; });
      const gw = glob(S.g0[0], S.g0[1]); set(S.gr, 'cx', r2(gw[0])); set(S.gr, 'cy', r2(gw[1])); return d; };
    const puff = (q, F, fc) => { const c = q.pc, dir = fc >= 0 ? 1 : -1; if (dir !== q.pd) { q.pd = dir; (dir > 0 ? q.pz : q.pz.slice().reverse()).forEach(s => q.e.parentNode.insertBefore(s.el, q.e)); }
      q.pz.forEach(s => { set(s.el, 'd', mapSeg(q.segs, (x, y, i) => F(c[0] + (x - c[0]) * s.s, c[1] + (y - c[1]) * s.s, i, s.u * q.pT))); const f = s.u * fc > -0.3 ? q.LF : q.DF; if (f !== s.f) { s.f = f; set(s.el, 'fill', f); set(s.el, 'stroke', f); } }); };
    if (I.star) { const S = I.star, V = S.V, Cx = S.C[0], Cy = S.C[1], T = S.T, ts = now / 1000, fc = cyh * cp;
      const rot = (p, c, a, k) => { const co = Math.cos(a), si = Math.sin(a), vx = (p[0] - c[0]) * k, vy = (p[1] - c[1]) * k; return [c[0] + vx * co - vy * si, c[1] + vx * si + vy * co]; };
      const wa = a => ((a % TAU) + TAU * 1.5) % TAU - Math.PI, mid = (a, b) => [(a[0] + b[0]) / 2, (a[1] + b[1]) / 2], pp = (F, p) => { const q = F(p[0], p[1]); return r2(q[0]) + ' ' + r2(q[1]); };
      const qb = (a, b, c, u) => [(1 - u) * (1 - u) * a[0] + 2 * u * (1 - u) * b[0] + u * u * c[0], (1 - u) * (1 - u) * a[1] + 2 * u * (1 - u) * b[1] + u * u * c[1]], lp = (a, b, u) => [lerp(a[0], b[0], u), lerp(a[1], b[1], u)];
      // each star point bends from its own root: side points are arms (raise, wave, reach to the mouth), bottom points are legs
      const J = {};
      S.L.forEach(l => { const r = V[l.i], Lf = l.side < 0; let a = 0, k = 1;
        if (l.role === 'arm') { const av = Lf ? P.armL : P.armR, hx = Lf ? P.hLx : P.hRx, hy = Lf ? P.hLy : P.hRy, w = SM((Math.hypot(hx, hy) - 4) / 8);
          a = -l.side * (clamp(av, -70, 190) * (av > 0 ? 0.3 : 0.55) * D2R + Math.sin(ts * 1.6 + l.side) * 0.035 + (I.ed || 0) * 0.01);
          if (w > 0.001) { const m = I.mapHand(Lf ? hx : -hx, hy), tg = [50 + l.side * Math.abs(50 - g.pawX) + (Lf ? m[0] : -m[0]), g.pawY + m[1]], tp = rot(r, l.piv, a, 1), q2 = [lerp(tp[0], tg[0], w), lerp(tp[1], tg[1], w)], d0x = r[0] - l.piv[0], d0y = r[1] - l.piv[1], d1x = q2[0] - l.piv[0], d1y = q2[1] - l.piv[1];
            a = wa(Math.atan2(d1y, d1x) - Math.atan2(d0y, d0x)); k = clamp(Math.hypot(d1x, d1y) / l.Lr, 0.45, 1.2); } }
        else if (l.role === 'leg') { const lift = Lf ? P.footL : P.footR; a = -l.side * (clamp(lift, -2, 10) * 3.5 + clamp(P.curl, -1.5, 1.5) * 13 + Math.sin(ts * 1.3 + l.side * 2) * 0.6) * D2R; k = 1 - clamp(lift, 0, 8) * 0.025; }
        else { a = Math.sin(ts * 1.1) * 0.02 + clamp(P.htilt, -10, 10) * 0.004; S.topA = a; S.topPiv = l.piv; }
        J[l.i] = { k, tip: rot(r, l.piv, a, k), cA: S.CQ ? rot(S.CQ[l.i][0], l.piv, a * 0.85, k) : rot(mid(V[(l.i + 9) % 10], r), l.piv, a / 2, (1 + k) / 2), cB: S.CQ ? rot(S.CQ[l.i][1], l.piv, a * 0.85, k) : rot(mid(r, V[l.i + 1]), l.piv, a / 2, (1 + k) / 2) }; });
      const OD = F => { let s = 'M' + pp(F, V[9]); for (let i = 0; i < 10; i += 2) { const j = J[i]; s += 'Q' + pp(F, j.cA) + ' ' + pp(F, j.tip) + 'Q' + pp(F, j.cB) + ' ' + pp(F, V[i + 1]); } return s + 'Z'; };
      const dir = fc >= 0 ? 1 : -1; if (dir !== S.dir) { S.dir = dir; (dir > 0 ? S.sl : S.sl.slice().reverse()).forEach(s => S.anchor.parentNode.insertBefore(s.el, S.anchor)); }
      S.sl.forEach(s => { const sc = s.s; set(s.el, 'd', OD((x, y) => sph(Cx + (x - Cx) * sc, Cy + (y - Cy) * sc, s.z))); set(s.el, 'stroke-width', r2(S.SW * sc)); const f = (s.z / T) * fc > -0.3 ? S.LF : S.DF; if (f !== s.f) { s.f = f; set(s.el, 'fill', f); set(s.el, 'stroke', f); } });
      S.md = OD((x, y) => sph(x, y, 0)); S.hd = OD((x, y) => sph(Cx + (x - Cx) * 1.07, Cy + (y - Cy) * 1.07, T + 2));
      const Wc = glob(Cx, Cy - 4); S.grads.forEach(gr => { if (gr) { set(gr, 'cx', r2(Wc[0] - 9)); set(gr, 'cy', r2(Wc[1] - 14)); } });
      // an arm folding across the face is drawn in front of it
      S.ov.forEach(o => { const i = o.l.i, j = J[i], r = V[i], fold = SM((0.8 - Math.hypot(j.tip[0] - Cx, j.tip[1] - Cy) / Math.hypot(r[0] - Cx, r[1] - Cy)) / 0.3), vs = fold * SM(fc * 3), z = (T + 5) * fold;
        W[o.l.side < 0 ? 'pawL' : 'pawR'] = sph(j.tip[0], j.tip[1], z + 1);
        if (vs < 0.01) { set(o.p, 'opacity', 0); set(o.sh, 'opacity', 0); return; }
        const F = (x, y) => sph(x, y, z), a0 = V[(i + 9) % 10], b0 = V[i + 1], u = 0.35;
        const d = 'M' + pp(F, qb(a0, j.cA, j.tip, u)) + 'Q' + pp(F, lp(j.cA, j.tip, u)) + ' ' + pp(F, j.tip) + 'Q' + pp(F, lp(j.tip, j.cB, 1 - u)) + ' ' + pp(F, qb(j.tip, j.cB, b0, 1 - u)) + 'Z';
        set(o.p, 'd', d); set(o.p, 'opacity', r2(SM(vs * 4))); set(o.sh, 'd', d); set(o.sh, 'opacity', r2(0.35 * vs)); });
      { const CE = S.capE, tA = S.topA || 0, tP = S.topPiv || [50, 30], cF = (x, y, z) => { const r = rot([x, y], tP, tA, 1); return sph(r[0], r[1], z); }, cZ = (x, y, z) => { const r = rot([x, y], tP, tA, 1); return sphZ(r[0], r[1], z); };
        const fl = clamp(P.earR, -30, 30) * 0.4 * D2R + Math.sin(ts * 1.2) * 0.05, SP0 = [[50, 20, 10.6], [50.3, 14, 8.9], [51.6, 9, 6.7], [54.5, 5.6, 4.5], [58.6, 4.4, 3.1], [63, 5.6, 2.2], [67, 8.4, 1.5]], n = SP0.length;
        const SPn = SP0.map((p, i) => { const r = rot(p, [50, 20], fl * Math.pow(i / (n - 1), 1.6), 1); return [r[0], r[1], p[2]]; });
        const rings = SPn.map((p, i) => { const a = SPn[Math.max(0, i - 1)], b = SPn[Math.min(n - 1, i + 1)], tx = b[0] - a[0], ty = b[1] - a[1], tl = Math.hypot(tx, ty) || 1, nx = -ty / tl, ny = tx / tl, out = [];
          for (let k = 0; k < 12; k++) { const f = k / 12 * TAU; out.push(cF(p[0] + nx * p[2] * Math.cos(f), p[1] + ny * p[2] * Math.cos(f), p[2] * 0.85 * Math.sin(f))); } return out; });
        let cd = ''; for (let i = 0; i < n - 1; i++) cd += H.closedD(H.hull(rings[i].concat(rings[i + 1]))); set(CE.cone, 'd', cd);
        const RX = 12.4, RZ = 9.4, RY = 21.4, TR = 3.4, secs = []; for (let j = 0; j <= 16; j++) { const th = j / 16 * TAU, cx = 50 + RX * Math.cos(th), cz = RZ * Math.sin(th), ux = Math.cos(th), uz = Math.sin(th), out = [];
          for (let k = 0; k < 8; k++) { const f = k / 8 * TAU; out.push(cF(cx + ux * TR * Math.cos(f), RY + TR * Math.sin(f), cz + uz * TR * Math.cos(f))); } secs.push({ out, x: cx, z: cz }); }
        let fd = '', bd = ''; for (let j = 0; j < 16; j++) { const A = secs[j], B = secs[j + 1], dd = H.closedD(H.hull(A.out.concat(B.out))); if (cZ((A.x + B.x) / 2, RY, (A.z + B.z) / 2) >= 0) fd += dd; else bd += dd; }
        set(CE.rf, 'd', fd); set(CE.rb, 'd', bd);
        const lt = SPn[n - 1], l2 = SPn[n - 2], tl = Math.hypot(lt[0] - l2[0], lt[1] - l2[1]) || 1, pc = cF(lt[0] + (lt[0] - l2[0]) / tl * 1.6, lt[1] + (lt[1] - l2[1]) / tl * 1.6, 0); set(CE.pom, 'd', toD(ellS(pc[0], pc[1], 3.5, 3.5, 0, 8), (x, y) => [x, y]));
        const Wk = glob(50, 12), Wt = glob(50, RY); if (S.cgr[0]) { set(S.cgr[0], 'cx', r2(Wk[0] - 5)); set(S.cgr[0], 'cy', r2(Wk[1] - 5)); } if (S.cgr[1]) { set(S.cgr[1], 'cx', r2(Wt[0] - 6)); set(S.cgr[1], 'cy', r2(Wt[1] - 3)); } }
      S.L.forEach(l => { if (l.role === 'leg') W[l.side < 0 ? 'footL' : 'footR'] = sph(J[l.i].tip[0], J[l.i].tip[1], 0); }); }
    if (I.dn) { const D = I.dn, T = D.T, Ro = D.Ro, ring = (cx, cy, r, z, n) => { const o = []; for (let k = 0; k < n; k++) { const f = k / n * TAU; o.push(sph(cx + r * Math.cos(f), cy + r * Math.sin(f), z)); } return o; };
      let pp0 = []; for (let i = 0; i <= 6; i++) { const a0 = i / 6 * Math.PI / 2, r = Ro - T + T * Math.cos(a0), z = T * Math.sin(a0); pp0 = pp0.concat(ring(HX, HY, r, z, 28), ring(HX, HY, r, -z, 28)); }
      D.d = H.closedD(H.hull(pp0)); const fz = cyh * cp >= 0 ? 1 : -1, dz = T * 0.55, hF = H.closedD(ring(D.hole.x, D.hole.y, D.hole.r, fz * dz, 24));
      set(D.hole.el, 'd', hF); set(D.wall, 'd', hF); set(D.wm, 'd', H.closedD(ring(D.hole.x, D.hole.y, D.hole.r, -fz * dz, 24)));
      D.bites.forEach(q => { const c = sph(q.x, q.y, 0); let d = 'M' + r2(c[0] + q.r) + ' ' + r2(c[1]); for (let k = 1; k <= 16; k++) { const f = k / 16 * TAU; d += 'L' + r2(c[0] + q.r * Math.cos(f)) + ' ' + r2(c[1] + q.r * Math.sin(f)); } set(q.el, 'd', d + 'Z'); }); }
    if (I.bun) { const B = I.bun, [Cx, Cy, Cz] = B.C, rotZ = (dx, z) => -dx * syh + z * cyh, P = (x, y, z) => { const p = sph(x, y, z); return r2(p[0]) + ' ' + r2(p[1]); }, tw = Math.sin(now / 900) * 0.04;
      B.pl.forEach(o => { const a = o.a + tw, s = Math.sin(a), c = Math.cos(a), dr = 3 + 4.6 * Math.abs(s), a2 = a - 0.38, x2 = 50 + 9 * Math.sin(a2), z2 = 9 * Math.cos(a2);
        set(o.el, 'd', 'M' + P(50 + 2.5 * s, 31, 2.5 * c) + ' Q' + P(x2, 31.6 + dr * 0.35, z2) + ' ' + P(50 + 15 * s, 31 + dr, 15 * c)); set(o.el, 'opacity', r2(0.8 * SM((rotZ(15 * s, 15 * c) + 2) / 7))); });
      const sp = sph(50, 31.4, 0); set(B.kSh, 'cx', r2(sp[0])); set(B.kSh, 'cy', r2(sp[1])); set(B.kSh, 'rx', 7.2); set(B.kSh, 'ry', 2);
      const out = []; for (let i = 0; i < 6; i++) { const v = -1 + i / 5 * 2, rr = Math.sqrt(1 - v * v * 0.92); for (let k = 0; k < 14; k++) { const f = k / 14 * TAU; out.push(sph(Cx + B.rx * rr * Math.sin(f), Cy + B.ry * v, Cz + B.rx * rr * Math.cos(f))); } }
      set(B.kn, 'd', H.closedD(H.hull(out))); const kc = sph(Cx, Cy, Cz); set(B.gr, 'cx', r2(kc[0] - 2.6)); set(B.gr, 'cy', r2(kc[1] - 2.4));
      B.cr.forEach(o => { const a = o.a + tw * 3; let d = ''; for (let i = 0; i <= 6; i++) { const u = -1 + i / 3, v = -0.15 - 0.55 * (1 - u * u * 0.6), ang = a + u * 0.75, rr = Math.sqrt(Math.max(0, 1 - v * v)) * 1.02; d += (i ? 'L' : 'M') + P(Cx + B.rx * rr * Math.sin(ang), Cy + B.ry * v, Cz + B.rx * rr * Math.cos(ang)); }
        set(o.el, 'd', d); set(o.el, 'opacity', r2(SM((rotZ(Math.sin(a), Math.cos(a)) - 0.1) / 0.35))); }); }
    if (BG) { const PL = a => a.map((p, k) => (k ? 'L' : 'M') + r2(p[0]) + ' ' + r2(p[1])).join('') + 'Z', ring = (y, r, n, rf) => { const o = []; for (let k = 0; k < n; k++) { const f = k / n * TAU, rr = rf ? rf(f, r) : r; o.push(bgP(rr * Math.sin(f), y, rr * Math.cos(f))); } return o; };
      const solid = (prof, n, rf) => PL(H.hull([].concat(...prof.map(([y, r]) => ring(y, r, n, rf)))));
      const edge = (F, e, rev) => { const o = [], N = 30; for (let i = 0; i <= N; i++) { const b = -Math.PI / 2 - e + (Math.PI + 2 * e) * (rev ? N - i : i) / N, a = b - yb, t = F(a); o.push(bgP(t[1] * Math.sin(a), t[0], t[1] * Math.cos(a))); } return o; };
      const band = (T, B, e) => PL(edge(T, e).concat(edge(B, e, 1))), ts = now / 1000;
      BG.cl = 5; BG.dome = solid(BG.TOP, 56); BG.cl = 0; set(BG.bot, 'd', solid(BG.BOT, 56)); BG.cl = 1; set(BG.pat, 'd', solid(BG.PAT, 56, (f, r) => r + 0.5 * Math.sin(f * 7) + 0.3 * Math.sin(f * 13 + 1)));
      BG.cl = 3; set(BG.tom, 'd', band(a => [53, 37.3 + 0.9 * Math.max(0, Math.cos(3 * a + 0.5))], a => [58.4, 37.3 + 0.9 * Math.max(0, Math.cos(3 * a + 0.5))], 0.12));
      set(BG.tomL, 'd', edge(a => [57, 37.6 + 0.9 * Math.max(0, Math.cos(3 * a + 0.5))], -0.25).map((p, k) => (k ? 'L' : 'M') + r2(p[0]) + ' ' + r2(p[1])).join(''));
      BG.cl = 2; const dr = a => Math.pow(Math.max(0, Math.cos(4 * a + 0.4)), 4) * (1 + 0.08 * Math.sin(ts * 1.7 + a * 3));
      set(BG.che, 'd', band(a => [57.3, 37.4], a => { const d = dr(a); return [59.6 + 5.4 * d, 37.5 + 0.7 * d]; }, 0.1));
      BG.cl = 2.5; BG.pk.forEach(c => { const a = c.a, Zc = Math.cos(a + yb), vs = SM((Zc - 0.15) / 0.3); if (vs < 0.02) { set(c.el, 'opacity', 0); set(c.rg, 'opacity', 0); return; }
        const R0 = 37.6, k = 50 * D2R, rc = 4.4, cy0 = 57.2, e1 = [Math.cos(a), 0, -Math.sin(a)], e2 = [Math.sin(a) * Math.cos(k), Math.sin(k), Math.cos(a) * Math.cos(k)], C = [R0 * Math.sin(a), cy0, R0 * Math.cos(a)];
        const chip = s => { const o = []; for (let i = 0; i < 18; i++) { const f = i / 18 * TAU, cf = Math.cos(f) * rc * s, sf = Math.sin(f) * rc * s * (1 + 0.04 * Math.sin(f * 9)); o.push(bgP(C[0] + e1[0] * cf + e2[0] * sf, C[1] + e2[1] * sf, C[2] + e1[2] * cf + e2[2] * sf)); } return PL(o); };
        set(c.el, 'd', chip(1)); set(c.rg, 'd', chip(0.62)); set(c.el, 'opacity', r2(vs)); set(c.rg, 'opacity', r2(vs)); });
      BG.cl = 4; const rip = a => Math.pow(0.5 + 0.5 * Math.cos(10 * a + Math.sin(ts * 0.9) * 0.3), 1.3) * (0.8 + 0.2 * Math.cos(3 * a + 1)), wob = a => 0.35 * Math.sin(ts * 2.2 + a * 5);
      set(BG.let, 'd', band(a => [49.4, 37.2], a => { const s = rip(a); return [53.6 + 4.6 * s + wob(a), 38 + 2.6 * s]; }, 0.32));
      { let d = ''; for (let k = 0; k < 20; k++) { const a = k / 10 * Math.PI, z = Math.cos(a + yb); if (z < 0.2) continue; const p0 = bgP(37.9 * Math.sin(a), 51, 37.9 * Math.cos(a)), s = rip(a), p1 = bgP(38.6 * Math.sin(a), 53.6 + 3.4 * s + wob(a), 38.6 * Math.cos(a)); d += 'M' + r2(p0[0]) + ' ' + r2(p0[1]) + 'L' + r2(p1[0]) + ' ' + r2(p1[1]); } set(BG.letV, 'd', d); } BG.cl = 5; }
    if (I.ck) { const C = I.ck, Dh = C.Dh, ts = now / 1000, nf = cyh * cp, fz = nf >= 0 ? 1 : -1, tv = SM((nf - 0.05) / 0.2), wr = clamp(+P.wrap || 0, 0, 1), ml = clamp(+P.melt || 0, 0, 1.2), tw = clamp(+P.tw || 0, 0, 1.5);
      const PL = a => a.map((p, k) => (k ? 'L' : 'M') + r2(p[0]) + ' ' + r2(p[1])).join('') + 'Z';
      const RO = (x0, x1, ytl, ytr, ybl, ybr, Rt, Rb) => ins => { const o = [], X0 = x0 + ins, X1 = x1 - ins, rt = Math.max(0.3, Rt - ins), rb = Math.max(0.3, Rb - ins), arc = (cx, cy, r, a0) => { for (let k = 0; k <= 4; k++) { const a = a0 + k / 8 * Math.PI; o.push([cx + r * Math.cos(a), cy + r * Math.sin(a)]); } };
        arc(X1 - rb, ybr - ins - rb, rb, 0); arc(X0 + rb, ybl - ins - rb, rb, Math.PI / 2); arc(X0 + rt, ytl + ins + rt, rt, Math.PI); arc(X1 - rt, ytr + ins + rt, rt, Math.PI * 1.5); return o; };
      const slab = (ol, Dz, b) => { const pp = []; for (let k = 0; k <= 3; k++) { const t = k / 6 * Math.PI, z = Dz - b + b * Math.sin(t); ol(b * (1 - Math.cos(t))).forEach(p => { pp.push(sph(p[0], p[1], z)); pp.push(sph(p[0], p[1], -z)); }); } return PL(H.hull(pp)); };
      const pan = (ol, ins, z) => PL(ol(ins).map(p => sph(p[0], p[1], z)));
      const barO = RO(20, 80, 10, 10, 86, 86, 9, 9); C.d = slab(barO, Dh, 4); set(C.bev, 'd', pan(barO, 1.2, fz * (Dh - 1.2))); set(C.fp, 'd', pan(barO, 4, fz * Dh));
      // pillowy segments: raised squares with a soft shadow and a gloss streak; in the dance they pop out in a wave
      C.tiles.forEach(t => { if (tv < 0.01) { [t.sh, t.tp, t.hl].forEach(el => set(el, 'opacity', 0)); return; }
        const w = Math.max(0, Math.sin(ts * 7 - (t.ci + t.ri) * 0.9)), pop = tw * w * w, cx = (t.x0 + t.x1) / 2, cy = (t.y0 + t.y1) / 2, k = 1 + pop * 0.07, z = Dh + 0.4 + pop * 2;
        const box = (dx, dy, kk) => [cx + (t.x0 - cx) * kk + dx, cx + (t.x1 - cx) * kk + dx, cy + (t.y0 - cy) * kk + dy, cy + (t.y1 - cy) * kk + dy], s = box(0.5 + pop * 0.7, 0.7 + pop, 1 + pop * 0.04), b = box(0, 0, k), hw = (b[1] - b[0]) * 0.5;
        set(t.sh, 'd', pan(RO(s[0], s[1], s[2], s[2], s[3], s[3], 2.6, 2.6), 0, Dh + 0.2)); set(t.tp, 'd', pan(RO(b[0], b[1], b[2], b[2], b[3], b[3], 2.6, 2.6), 0, z));
        set(t.hl, 'd', pan(RO(b[0] + 1.3, b[0] + 1.3 + hw, b[2] + 1.1, b[2] + 1.1, b[2] + 2.6, b[2] + 2.6, 0.75, 0.75), 0, z + 0.1));
        set(t.sh, 'opacity', r2(0.45 * tv)); set(t.tp, 'opacity', r2(tv)); set(t.hl, 'opacity', r2((0.16 + pop * 0.3) * tv)); });
      // wrapper sleeve + foil band wrap round the bar (the foil peels down in the dance)
      const yl = 64 + wr * 9, yr = 62 + wr * 9, wz = Dh + 1.4, bz = Dh + 1.9, wO = RO(18, 82, yl, yr, 88, 88, 1.5, 8), bO = RO(17.4, 82.6, yl - 0.4, yr - 0.4, yl + 6, yr + 6, 1.2, 1.2);
      set(C.ws, 'd', slab(wO, wz, 3)); set(C.wm, 'd', pan(wO, 0.9, fz * (wz - 0.9))); set(C.wf, 'd', pan(wO, 3, fz * wz)); set(C.bs, 'd', slab(bO, bz, 1.6)); set(C.bf, 'd', pan(bO, 1.6, fz * bz));
      { const a = sph(20, yl + 1.5, fz * (bz + 0.1)), b = sph(80, yr + 1.5, fz * (bz + 0.1)); set(C.bl, 'd', 'M' + r2(a[0]) + ' ' + r2(a[1]) + 'L' + r2(b[0]) + ' ' + r2(b[1])); }
      // melting: chocolate flows over the foil and drips down the wrapper, a puddle spreads under his feet
      const mv = SM(ml / 0.15), zz = fz * (bz + 0.3); set(C.mt, 'opacity', r2(mv)); C.dr.forEach(d => set(d.el, 'opacity', r2(mv)));
      if (mv > 0.01) { const top = x => lerp(yl, yr, (x - 18) / 64) - 1.2, o = [];
        for (let i = 0; i <= 12; i++) { const x = 19 + i * 62 / 12; o.push(sph(x, top(x), zz)); }
        for (let i = 12; i >= 0; i--) { const x = 19 + i * 62 / 12; o.push(sph(x, top(x) + 2 + ml * 1.6 + 0.7 * Math.sin(x * 0.55 + ts * 2.2), zz)); } set(C.mt, 'd', PL(o));
        C.dr.forEach(d => { const L = d.L * ml * (1 + 0.14 * Math.sin(ts * 2.3 + d.k * 1.7)), y0 = top(d.x) + 1, rb = 1.3 + 0.5 * ml, pp = [sph(d.x - 2.6, y0, zz), sph(d.x + 2.6, y0, zz)];
          for (let k = 0; k < 10; k++) { const f = k / 10 * TAU; pp.push(sph(d.x + rb * Math.cos(f), y0 + 1.5 + L + rb * Math.sin(f), zz)); } set(d.el, 'd', PL(H.hull(pp))); }); }
      const pv = SM(ml / 0.3); set(C.pud, 'opacity', r2(0.9 * pv)); if (pv > 0.01) { set(C.pud, 'cx', r2(50 + P.x)); set(C.pud, 'cy', r2(G + 0.4)); set(C.pud, 'rx', r2((14 + 2 * Math.sin(ts * 1.8)) * ml)); set(C.pud, 'ry', r2(2.6 * ml)); }
      // the bite goes right through the bar and turns with it
      if (C.dir !== fz) { C.dir = fz; (fz > 0 ? C.sl : C.sl.slice().reverse()).forEach(q => C.sG.appendChild(q.el)); } C.sl.forEach(q => set(q.el, 'd', PL(q.P.map(p => sph(p[0], p[1], q.z)))));
      C.bites.forEach(b => { const pp = [], r = b.r + 2.2; for (let k = 0; k < 20; k++) { const f = k / 20 * TAU; pp.push(sph(b.x + r * Math.cos(f), b.y + r * Math.sin(f), fz * Dh)); } set(b.el, 'd', PL(pp)); }); }
    if (I.wings) { const f = clamp(Math.max(+P.flap || 0, clamp((P.lift - 1) / 10, 0, 1) * 0.8), 0, 1); I.wph = (I.wph || 0) + dtS * (5 + 16 * f); I.wphi = 0.35 + (0.16 + 0.44 * f) * Math.sin(I.wph); }
    let headD = '';
    if (I.wh) { const Wh = I.wh, ts = now / 1000, sw = clamp(+P.swim || 0, 0, 1.5); Wh.ph = (Wh.ph || 0) + dtS * (2.4 + 4.2 * sw);
      // tail flaps up and down while swimming (a wave down the body), lags sideways when turning
      const fa = -(0.5 + 0.5 * Math.sin(Wh.ph)) * (0.05 + 0.2 * sw) - clamp(P.curl, 0, 1.5) * 0.2 + clamp(P.lift, 0, 20) * 0.005 - Math.abs(clamp(P.wag, -30, 30)) * 0.002 - (Wh.fin && Wh.fin.nw ? 0.1 + 0.25 * (0.5 + 0.5 * Math.cos(yb)) : 0), fy = -clamp(P.turn, -1, 1) * 0.25 + Math.sin(Wh.ph * 0.5 + 1) * 0.04 - (Wh.fin ? (Wh.fin.nw ? 0.85 * Math.cos(yb) * Math.cos(yb) : 0.7 * (0.5 + 0.5 * Math.cos(yb))) : 0);
      const BP = (x, y, z) => { if (z >= -8) return [x, y, z]; const w = Math.min(1, (-8 - z) / 33), a = fa * w * 1.3, b = fy * w, vy = y - 80, vz = z + 8, y1 = 80 + vy * Math.cos(a) - vz * Math.sin(a), vz2 = vy * Math.sin(a) + vz * Math.cos(a), vx = x - 50;
        return [50 + vx * Math.cos(b) + vz2 * Math.sin(b), y1, -8 - vx * Math.sin(b) + vz2 * Math.cos(b)]; };
      const FN = Wh.fin, NR = FN ? (FN.nw ? 34 : 20) : 14, RPf = FN ? FN.RP : f => [Math.cos(f), Math.sin(f)]; const rings = Wh.st.map(([cx, cy, z, a, b]) => { const o = []; for (let k = 0; k < NR; k++) { const r = RPf(k / NR * TAU), p = BP(cx + a * r[0], cy + b * r[1], z); o.push(sph(p[0], p[1], p[2])); } return o; });
      const nf = Wh.nf || 6; let d = H.closedD(H.hull([].concat(...rings.slice(0, nf + 3)))); for (let i = nf + 2; i < rings.length - 1; i++) d += H.closedD(H.hull(rings[i].concat(rings[i + 1])));
      Wh.lobes.forEach(Lb => { const cs = Lb.map(([x, y, z, r]) => { const p = BP(x, y, z), C = sph(p[0], p[1], p[2]), o = []; for (let k = 0; k < 12; k++) { const f = k / 12 * TAU; o.push([C[0] + r * Math.cos(f), C[1] + r * Math.sin(f)]); } return o; });
        for (let i = 0; i < cs.length - 1; i++) d += H.closedD(H.hull(cs[i].concat(cs[i + 1]))); });
      // Pearl: broad horizontal narwhal flukes (two rounded lobes swept back from a narrow tail stock, notch in the middle, tips curl up a little); flap with the tail
      if (FN && FN.nw) { const FO = [[1.2, 0, 1.6], [8.5, -3, 1.2], [15.5, -7.5, 0.85], [20.5, -13, 0.5], [20, -15.6, 0.45], [13.5, -16.4, 0.6], [6, -15.4, 0.75], [1.2, -12, 1]];
        const rl = -1.2 * Math.cos(yb) * Math.cos(yb), cr = Math.cos(rl), sr = Math.sin(rl); [-1, 1].forEach(sd => { const pts = []; FO.forEach(([dx, dz, th]) => { const up = -Math.pow(dx / 20.5, 1.6) * 6.5; [-th, th].forEach(dy => { const X = sd * dx, Y = up + dy, p = BP(50 + X * cr - Y * sr, 72 + X * sr + Y * cr, -61 + dz); pts.push(sph(p[0], p[1], p[2])); }); }); d += H.closedD(H.hull(pts)); }); }
      let x0 = 1e9, y0 = 1e9, x1 = -1e9, y1 = -1e9; for (let i = 0; i < nf + 3; i++) rings[i].forEach(p => { if (p[0] < x0) x0 = p[0]; if (p[0] > x1) x1 = p[0]; if (p[1] < y0) y0 = p[1]; if (p[1] > y1) y1 = p[1]; });
      Wh.bb = [x0, y0, x1, y1]; Wh.d = d; set(Wh.sh, 'd', d); const bw = x1 - x0, bh = y1 - y0;
      set(Wh.rg, 'cx', r2(x0 + bw * 0.32)); set(Wh.rg, 'cy', r2(y0 + bh * 0.26)); set(Wh.rg, 'r', r2(Math.max(bw, bh) * 0.82));
      // aurora colors drift through the body and swirl as it turns (stronger in the twirl)
      if (!FN) { const gl = clamp(+P.glow || 0, 0, 1), amp = 22 + gl * 40; Wh.stops.forEach((sp0, i) => { const c = Wh.hue[i]; set(sp0, 'stop-color', 'hsl(' + r2(c[0] + amp * Math.sin(ts * (0.55 + gl * 0.9) + i * 2.1)) + ',' + c[1] + '%,' + c[2] + '%)'); });
      set(Wh.lg, 'gradientTransform', 'rotate(' + r2(yb / D2R * 0.6 + Math.sin(ts * 0.4) * 12) + ' 50 55)'); } else {
        // Finn's belly: a strip of the round underside; only quads facing the viewer are drawn (clipped to the body), so it wraps round and tucks away as he turns
        if (FN.bel) { const M = FN.nw ? 13 : 7, Gs = FN.bs.map(([cx, cy, z, a, b, h]) => { const o = []; for (let j = 0; j < M; j++) { const r = FN.RP(Math.PI / 2 - h + 2 * h * j / (M - 1)), p = BP(cx + a * r[0], cy + b * r[1], z); o.push(sph(p[0], p[1], p[2])); } return o; });
          let bd = ''; for (let i = 0; i < Gs.length - 1; i++) for (let j = 0; j < M - 1; j++) { const A = Gs[i][j], B = Gs[i][j + 1], C = Gs[i + 1][j + 1], D = Gs[i + 1][j]; if ((C[0] - A[0]) * (B[1] - D[1]) - (C[1] - A[1]) * (B[0] - D[0]) > 0.02) bd += 'M' + r2(A[0]) + ' ' + r2(A[1]) + 'L' + r2(B[0]) + ' ' + r2(B[1]) + 'L' + r2(C[0]) + ' ' + r2(C[1]) + 'L' + r2(D[0]) + ' ' + r2(D[1]) + 'Z'; }
          set(FN.bel.e, 'd', bd || 'M0 0Z'); }
        // Pearl's horn: a round 3D cone with spiral grooves that wind round it (only the front-facing part is drawn), a spring sway, a pulsing glow at the tip and sparkles orbiting it
        if (FN.nw) { const N = FN.nw, gl = clamp(+P.glow || 0, 0, 1.5), V = (a, b, k) => [a[0] + b[0] * k, a[1] + b[1] * k, a[2] + b[2] * k], NRM = v => { const l = Math.hypot(v[0], v[1], v[2]) || 1; return [v[0] / l, v[1] / l, v[2] / l]; }, CRS = (a, b) => [a[1] * b[2] - a[2] * b[1], a[2] * b[0] - a[0] * b[2], a[0] * b[1] - a[1] * b[0]], PJ = p => sph(p[0], p[1], p[2]), DZ = p => sphZ(p[0], p[1], p[2]);
          const S = N.sw, b0 = PJ([50, 36, 0]), dt = Math.max(dtS, 1e-3); if (S.px == null) { S.px = b0[0]; S.pv = 0; } const vx = (b0[0] - S.px) / dt, ax = clamp((vx - S.pv) / dt, -900, 900); S.px = b0[0]; S.pv = vx; S.v += (-90 * S.x - 9 * S.v - ax * 0.01) * dt; S.x = clamp(S.x + S.v * dt, -4, 4);
          const B = [50, 36.5, 0], T = [54 + S.x + Math.sin(ts * 1.1) * 0.45 + clamp(+P.hsw || 0, -1.5, 1.5) * 6, 5 + Math.abs(S.x) * 0.15, Math.sin(ts * 0.8) * 0.4], A = V(T, B, -1), An = NRM(A), e1 = NRM(CRS(An, [0, 0, 1])), e2 = NRM(CRS(e1, An)), rad = s => 4.1 - 3.25 * s;
          const ring = s => { const c = V(B, A, s), r = rad(s), o = []; for (let k = 0; k < 12; k++) { const f = k / 12 * TAU; o.push(PJ(V(V(c, e1, r * Math.cos(f)), e2, r * Math.sin(f)))); } return o; }, RS = [0, 0.2, 0.4, 0.6, 0.8, 0.94, 1].map(ring), tp = PJ(V(T, An, 0.7)); N.tp = tp;
          let hd = ''; for (let i = 0; i < RS.length - 1; i++) hd += H.closedD(H.hull(RS[i].concat(RS[i + 1]))); hd += H.closedD(H.hull(RS[RS.length - 1].concat([tp]))); set(N.horn, 'd', hd);
          const pb = PJ(B), pt = PJ(T), al = Math.hypot(pt[0] - pb[0], pt[1] - pb[1]) || 1, nx = -(pt[1] - pb[1]) / al, ny = (pt[0] - pb[0]) / al, M0 = PJ(V(B, A, 0.35)), w = rad(0.35) * 1.05;
          set(N.lg, 'x1', r2(M0[0] - nx * w)); set(N.lg, 'y1', r2(M0[1] - ny * w)); set(N.lg, 'x2', r2(M0[0] + nx * w)); set(N.lg, 'y2', r2(M0[1] + ny * w));
          let gd = '', gh = '', on = false; for (let i = 0; i <= 120; i++) { const s = 0.05 + 0.88 * i / 120, f = 0.6 + s * 4.2 * TAU, n = V(V([0, 0, 0], e1, Math.cos(f)), e2, Math.sin(f)), c = V(B, A, s), r = rad(s) + 0.05, p = V(c, n, r), vis = DZ(V(p, n, 1)) - DZ(p) > 0.12;
            if (vis) { const a2 = PJ(p), h2 = PJ(V(V(c, A, 0.013), n, r)); gd += (on ? 'L' : 'M') + r2(a2[0]) + ' ' + r2(a2[1]); gh += (on ? 'L' : 'M') + r2(h2[0]) + ' ' + r2(h2[1]); } on = vis; }
          set(N.grv, 'd', gd || 'M0 0'); set(N.grvH, 'd', gh || 'M0 0');
          const slp = /sleep/.test((I.cur && I.cur.name) || '') ? 0.4 : 1, pul = (0.5 + 0.5 * Math.sin(ts * (slp < 1 ? 1.1 : 2.3))) * slp, gp = PJ(V(T, An, -1.5)); set(N.glow, 'cx', r2(gp[0])); set(N.glow, 'cy', r2(gp[1])); set(N.glow, 'r', r2(8 + pul * 1.6 + gl * 4)); set(N.glow, 'opacity', r2(Math.min(1, 0.55 + pul * 0.3 + gl * 0.2)));
          set(N.tip, 'cx', r2(tp[0])); set(N.tip, 'cy', r2(tp[1])); set(N.tip, 'r', r2(2.4 + pul * 0.8 + gl * 1.2)); set(N.tip, 'opacity', r2(Math.min(1, 0.6 + pul * 0.35 + gl * 0.2)));
          const st4 = (x, y, r) => { const X = r2(x), Y = r2(y); return 'M' + X + ' ' + r2(y - r) + 'Q' + X + ' ' + Y + ' ' + r2(x + r) + ' ' + Y + 'Q' + X + ' ' + Y + ' ' + X + ' ' + r2(y + r) + 'Q' + X + ' ' + Y + ' ' + r2(x - r) + ' ' + Y + 'Q' + X + ' ' + Y + ' ' + X + ' ' + r2(y - r) + 'Z'; };
          let sfd = '', sbd = ''; const zT = DZ(T); for (let i = 0; i < 3; i++) { const a = ts * 0.9 + i * TAU / 3, Rr = 8.5 + Math.sin(ts * 1.3 + i) * 1.2 + gl * 3, p = V(V(V(T, An, -3 + Math.sin(ts * 1.7 + i * 2) * 2), e1, Rr * Math.cos(a)), e2, Rr * Math.sin(a)), q2 = PJ(p), z = Math.max(0, Math.sin(ts * 2.6 + i * 2.1)), r = 0.8 + 1.7 * z + gl * 0.6;
            if (DZ(p) >= zT) sfd += st4(q2[0], q2[1], r); else sbd += st4(q2[0], q2[1], r); }
          set(N.sF, 'd', sfd || 'M0 0'); set(N.sB, 'd', sbd || 'M0 0');
          // spots: little discs on the round body (front of the head + all over the back), drawn only where the surface faces the viewer
          const stt = Wh.st, SP = (i, f) => { i = clamp(i, 0, stt.length - 1.001); const i0 = Math.floor(i), k = i - i0, a0 = stt[i0], a1 = stt[i0 + 1], L = j => a0[j] + (a1[j] - a0[j]) * k, r = FN.RP(f); return BP(L(0) + L(3) * r[0], L(1) + L(4) * r[1], L(2)); };
          let sd = ''; N.SPT.forEach(([i, f, r]) => { const p = SP(i, f), t1 = NRM(V(SP(i, f + 0.04), p, -1)), t2r = V(SP(i + 0.04, f), p, -1); let n = NRM(CRS(t1, t2r)); if ((p[0] - 50) * n[0] + (p[1] - 64) * n[1] + (p[2] + 24) * n[2] < 0) n = [-n[0], -n[1], -n[2]];
            const t2 = CRS(n, t1); if (DZ(V(p, n, 1)) - DZ(p) < 0.25) return; const o = []; for (let k = 0; k < 10; k++) { const g = k / 10 * TAU; o.push(PJ(V(V(V(p, n, 0.15), t1, r * Math.cos(g)), t2, r * Math.sin(g)))); } sd += H.closedD(o); });
          set(N.spots, 'd', sd || 'M0 0'); }
        // snout: a little round bump on the front of his face; pokes out in profile, goes behind the body when he faces away
        if (FN.sn) { const SNS = [[-2, 9, 5.6], [1.5, 8.6, 5.3], [3.5, 7.2, 4.5], [5, 4.8, 3], [5.7, 2, 1.3]], SH = (yc, kx, ky) => { const pts = []; SNS.forEach(([dz, rx, ry]) => { for (let k = 0; k < 14; k++) { const f = k / 14 * TAU; pts.push(sph(50 + rx * kx * Math.cos(f), yc + ry * ky * Math.sin(f), FN.snZ + dz * Math.min(kx, 1))); } }); return H.closedD(H.hull(pts)); };
          // the snout is his mouth: it opens like a beak (dark gap + lower jaw drops), no separate mouth below it
          const o = clamp(I.fnOp || 0, 0, 1); set(FN.sn.e, 'd', SH(62.5 - o * 0.6, 1, 1)); set(FN.cav, 'd', SH(66.2 + o * 1.6, 0.7, 0.25 + o * 0.35)); set(FN.cav, 'opacity', r2(SM(o * 6))); set(FN.jaw, 'd', SH(64.8 + o * 5, 0.8, 0.5));
          const fr = sphZ(50, 62.5, FN.snZ + 3) > 0; if (fr !== FN.snF) { FN.snF = fr; const ref = fr && FN.bg ? FN.bg.nextSibling : FN.head; [FN.jaw, FN.cav, FN.sn.e].forEach(el => FN.par.insertBefore(el, ref)); } }
        // dorsal fin: a thin swept-back fin standing on his back (y-z plane), sways a little; drawn behind the body so its root stays buried
        if (FN.seal) { const S = FN.seal, spr = clamp(+P.fsp || 0, -0.6, 1.2), flp = clamp(+P.flip || 0, -0.5, 1.5), swp = Math.sin(Wh.ph) * (0.05 + 0.28 * sw) + clamp(+P.fsw || 0, -1, 1) * 0.45 - clamp(P.turn, -1, 1) * 0.15;
          const V3 = (a, b, k) => [a[0] + b[0] * k, a[1] + b[1] * k, a[2] + b[2] * k], NRM = v => { const l = Math.hypot(v[0], v[1], v[2]) || 1; return [v[0] / l, v[1] / l, v[2] / l]; };
          // hind flippers: fan out from the tail end (wide forked tips like the art), sweep side to side, lift up for the banana pose, go behind the body when he faces you
          S.F.forEach(Fp => { const sd = Fp.sd, ay = sd * (0.8 + spr * 0.3) + swp, ax = -0.08 - flp * 0.5 - (0.5 + 0.5 * Math.sin(Wh.ph + 0.9)) * (0.04 + 0.12 * sw) + Math.sin(ts * 1.7 + sd) * 0.03, Lf = 14, R0 = [50 + sd * 3, 83.5, -48.5];
            const u = [Math.sin(ay) * Math.cos(ax), Math.sin(ax), -Math.cos(ay) * Math.cos(ax)], v0 = [sd * 0.3, 0.95, 0], du = v0[0] * u[0] + v0[1] * u[1] + v0[2] * u[2], v = NRM([v0[0] - du * u[0], v0[1] - du * u[1], v0[2] - du * u[2]]), nn = [u[1] * v[2] - u[2] * v[1], u[2] * v[0] - u[0] * v[2], u[0] * v[1] - u[1] * v[0]];
            const ring = (c, w, th) => { const o = []; for (let k = 0; k < 10; k++) { const f = k / 10 * TAU, p = BP(...V3(V3(c, v, w * Math.cos(f)), nn, th * Math.sin(f))); o.push(sph(p[0], p[1], p[2])); } return o; };
            const Wd = s => 2.8 + 5 * Math.pow(s, 0.8), secs = [0, 0.22, 0.44, 0.64, 0.82].map(s => ring(V3(R0, u, Lf * s), Wd(s), 1.7 - 0.9 * s)), cE = V3(R0, u, Lf), tips = [-1, 1].map(k => ring(V3(cE, v, k * Wd(1) * 0.55), 2.2, 0.7));
            let fd = ''; for (let i = 0; i < secs.length - 1; i++) fd += H.closedD(H.hull(secs[i].concat(secs[i + 1]))); tips.forEach(tp => { fd += H.closedD(H.hull(secs[secs.length - 1].concat(tp))); }); set(Fp.e, 'd', fd);
            const M = BP(...V3(R0, u, Lf * 0.45)), fr = sphZ(M[0], M[1], M[2]) > 0; if (fr !== Fp.fr) { Fp.fr = fr; FN.par.insertBefore(Fp.e, fr ? FN.head.nextSibling : FN.head); } });
          // muzzle: two puffy whisker pads + a bridge under the nose, pokes out in profile; nose, whisker dots and whiskers ride on it
          if (S.mz) { const MZ = [[45, 64.6, 6.2, 4.8, 3.2], [55, 64.6, 6.2, 4.8, 3.2], [50, 62.4, 4.8, 3.8, 4]], zS = (x, y) => sz(x - HX, y - HY); let md = '';
            MZ.forEach(([cx, cy, rx, ry, h]) => { const pts = []; [0, 0.4, 0.68, 0.87, 1].forEach(k => { const sc = Math.sqrt(1 - k * k * 0.92); for (let j = 0; j < 14; j++) { const f = j / 14 * TAU, x = cx + rx * sc * Math.cos(f), y = cy + ry * sc * Math.sin(f); pts.push(sph(x, y, zS(x, y) - 0.5 + h * k)); } }); md += H.closedD(H.hull(pts)); });
            set(S.mz.e, 'd', md); I.slZ = (x, y) => { let b = 0; MZ.forEach(([cx, cy, rx, ry, h]) => { const r = 1 - ((x - cx) / rx) * ((x - cx) / rx) - ((y - cy) / ry) * ((y - cy) / ry); if (r > 0) b = Math.max(b, h * Math.sqrt(r)); }); return zS(x, y) + b + 0.2; };
            const fr = sphZ(50, 63, zS(50, 63) + 3) > 0; if (fr !== S.mzF) { S.mzF = fr; FN.par.insertBefore(S.mz.e, fr ? S.mzRef : FN.head); } } }
        else if (!FN.nw) { const ln = 5 + Math.sin(ts * 1.3) * 1.2 + clamp(P.tilt, -20, 20) * 0.08, secs = [];
          for (let i = 0; i <= 20; i++) { const s = i / 20, Q = (a, b, c) => (1 - s) * (1 - s) * a + 2 * s * (1 - s) * b + s * s * c, xc = 50 + ln * Math.pow(s, 1.6), t = 2.6 * (1 - s) + 0.35, ly = Q(28, 9, 7), lz = Q(-1, -6, -21), ty = Q(39, 21, 7), tz = Q(-21, -13, -21);
            secs.push([[xc - t, ly, lz], [xc + t, ly, lz], [xc - t, ty, tz], [xc + t, ty, tz]].map(([x, y, z]) => { const p = BP(x, y, z); return sph(p[0], p[1], p[2]); })); }
          let fd = ''; for (let i = 0; i < secs.length - 1; i++) fd += H.hull(secs[i].concat(secs[i + 1])).map((p, k) => (k ? 'L' : 'M') + r2(p[0]) + ' ' + r2(p[1])).join('') + 'Z'; set(FN.fin, 'd', fd); } } }
    if (I.jl) { const J = I.jl, ts = now / 1000, jw = clamp(+P.jw || 0, 0, 2.5), jsw = clamp(+P.jsw || 0, -3, 3), jsp = clamp(+P.jsp || 0, -0.5, 1.5), c = J.c, N = 16;
      const tg = P.x + P.tilt * 0.45 + P.lean * 1.3 + P.turn * 12 + (P.htilt || 0) * 0.3, ly = P.lift + J.bob * 2.5 - sq * 6;
      if (J.p == null) { J.p = tg; J.v = 0; J.l = ly; J.lv = 0; J.wp = 0; } J.v += ((tg - J.p) * 110 - J.v * 9) * dtS; J.p += J.v * dtS; J.lv += ((ly - J.l) * 80 - J.lv * 6) * dtS; J.l += J.lv * dtS;
      const ox = clamp(J.p - tg, -7, 7) * 0.8, oy = clamp(J.l - ly, -7, 7); J.wp += dtS * (2.3 + jw * 5 + Math.abs(jsw) * 1.5);
      const SP = (a, cl) => { let d = 'M' + r2(a[0][0]) + ' ' + r2(a[0][1]); for (let i = 1; i < a.length - 1; i++) d += 'Q' + r2(a[i][0]) + ' ' + r2(a[i][1]) + ' ' + r2((a[i][0] + a[i + 1][0]) / 2) + ' ' + r2((a[i][1] + a[i + 1][1]) / 2); const l = a[a.length - 1]; return d + 'L' + r2(l[0]) + ' ' + r2(l[1]) + (cl ? 'Z' : ''); };
      const ord = [];
      J.T.forEach(t => { const sd = t.side, Lf = sd < 0, hx = Lf ? P.hLx : P.hRx, hy = Lf ? P.hLy : P.hRy, arm = sd < 0 ? P.armL : sd > 0 ? P.armR : 0, w = sd ? SM((Math.hypot(hx, hy) - 4) / 10) : 0;
        const a0 = -sd * clamp(arm, -40, 180) * 0.22 * D2R, M = [];
        let Bz = null; if (w > 0.001) { const mh = I.mapHand(Lf ? hx : -hx, hy), tx = 50 + sd * Math.abs(50 - g.pawX) + (Lf ? mh[0] : -mh[0]), ty = g.pawY + mh[1], tz = 12 + 18 * SM((-hy - 6) / 10); Bz = { tx, ty, tz }; }
        let R0x = 0, R0y = 0, R0z = 0;
        for (let k = 0; k < N; k++) { const s = k / (N - 1), ths = t.th + jsw * 0.55 * s * s, R = 26 + jsp * 14 * Math.pow(s, 1.2) - c * 3 * s, env = Math.min(1, s * 4);
          const wv = t.sg * 3 * Math.sin(Math.PI * 2 * s - J.wp + t.ph) * env * (0.5 + 0.5 * s) * (1 + jw * 0.8), wz = 2.4 * Math.cos(Math.PI * 2 * s - J.wp * 0.8 + t.ph * 1.3) * s * (1 + jw * 0.6), swy = Math.sin(ts * 1.1 + t.ph) * 1.6 * Math.pow(s, 1.5);
          const sw0 = ths - t.th, bx0 = R * Math.sin(t.th), bz0 = t.z0 * R / 26, bxr = bx0 * Math.cos(sw0) + bz0 * Math.sin(sw0), bzr = -bx0 * Math.sin(sw0) + bz0 * Math.cos(sw0);
          let x = 50 + bxr + wv + swy - ox * Math.pow(s, 1.6) * 0.9, y = 46 + 39 * s * (1 + c * 0.05 - jsp * 0.22) - oy * Math.pow(s, 1.5) * 0.7, z = bzr + wz * 0.6;
          if (!k) { R0x = x; R0y = y; R0z = z; } else if (sd) { const a = a0 * s, ca = Math.cos(a), sa = Math.sin(a), vx = x - R0x, vy = y - R0y; x = R0x + vx * ca - vy * sa; y = R0y + vx * sa + vy * ca; }
          if (Bz) { const u1 = 1 - s, bx = u1 * u1 * u1 * R0x + 3 * u1 * u1 * s * (R0x + sd * 5) + 3 * u1 * s * s * (Bz.tx + sd * 13) + s * s * s * Bz.tx, by = u1 * u1 * u1 * R0y + 3 * u1 * u1 * s * 70 + 3 * u1 * s * s * (Bz.ty + 18) + s * s * s * Bz.ty, bz = u1 * u1 * u1 * R0z + 3 * u1 * u1 * s * (R0z + 4) + 3 * u1 * s * s * Bz.tz + s * s * s * Bz.tz, ww = Math.sin(ts * 6 + s * 5) * 0.5 * s;
            x = lerp(x, bx + ww, w); y = lerp(y, by, w); z = lerp(z, bz, w); }
          M.push([x, y, z]); }
        const Wp = M.map(p => { const dx = p[0] - 50, x1 = dx * cyb + p[2] * syb, z1 = -dx * syb + p[2] * cyb; return glob(50 + x1, HY + (p[1] - HY) * cp - z1 * sp); }), nr = Wp.map((p, k) => { const A = Wp[Math.max(0, k - 1)], B = Wp[Math.min(N - 1, k + 1)], tx = B[0] - A[0], ty = B[1] - A[1], l = Math.hypot(tx, ty) || 1; return [-ty / l, tx / l, tx / l, ty / l]; });
        const mi = nr[N >> 1], ls = mi[0] * -0.8 + mi[1] * -0.6 >= 0 ? 1 : -1, wd = k => 2.75 * (1 - 0.42 * k / (N - 1));
        const rib = (off, wf) => { const L = [], Rr = []; for (let k = 0; k < N; k++) { const n = nr[k], W0 = wd(k), cx = Wp[k][0] + n[0] * ls * off * W0, cy = Wp[k][1] + n[1] * ls * off * W0; L.push([cx + n[0] * W0 * wf, cy + n[1] * W0 * wf]); Rr.push([cx - n[0] * W0 * wf, cy - n[1] * W0 * wf]); }
          const n = nr[N - 1], W1 = wd(N - 1) * wf, C = [(L[N - 1][0] + Rr[N - 1][0]) / 2, (L[N - 1][1] + Rr[N - 1][1]) / 2], cap = []; for (let k = 1; k < 6; k++) { const f = k / 6 * Math.PI; cap.push([C[0] + n[0] * W1 * Math.cos(f) + n[2] * W1 * Math.sin(f), C[1] + n[1] * W1 * Math.cos(f) + n[3] * W1 * Math.sin(f)]); }
          const n0 = nr[0], W2 = wd(0) * wf, C0 = [(L[0][0] + Rr[0][0]) / 2, (L[0][1] + Rr[0][1]) / 2], cap0 = []; for (let k = 1; k < 6; k++) { const f = k / 6 * Math.PI; cap0.push([C0[0] - n0[0] * W2 * Math.cos(f) - n0[2] * W2 * Math.sin(f), C0[1] - n0[1] * W2 * Math.cos(f) - n0[3] * W2 * Math.sin(f)]); }
          return SP(L.concat(cap, Rr.reverse(), cap0), true); };
        set(t.b, 'd', SP(Wp, false));
        // reaching to eat: the tentacle stays hanging from under the bell; only the part that has come out below the rim and curls up is drawn over the face
        if (t.f) { let k0 = -1; if (w > 0.02) for (let k = 2; k < N; k++) if (M[k][1] > 57) { k0 = k; break; } if (k0 > 0 && N - k0 >= 3) { set(t.f, 'd', SP(Wp.slice(k0))); set(t.f, 'opacity', r2(SM(w * 2.5))); } else set(t.f, 'opacity', 0); }
        const fr = false;
        t.z = bywZ(M[N >> 1][0], M[N >> 1][2]); if (!fr) ord.push(t); if (sd) W[Lf ? 'pawL' : 'pawR'] = Wp[N - 1]; });
      const key2 = ord.slice().sort((a, b) => a.z - b.z).map(t => J.T.indexOf(t)).join(','); if (key2 !== J.ok && J.anchor) { J.ok = key2; key2.split(',').forEach(i => { if (i !== '') J.par.insertBefore(J.T[+i].g, J.anchor); }); }
      const gc = glob(50, 40); set(J.glow, 'cx', r2(gc[0])); set(J.glow, 'cy', r2(gc[1])); set(J.glow, 'rx', 50); set(J.glow, 'ry', 44); set(J.glow, 'opacity', r2(0.16 + Math.max(0, c) * 0.16 + clamp(+P.glo || 0, 0, 1) * 0.6)); }
    // Octo's arms: each is a curl chain (exit angle + a bend that grows to the tip, like the art) with a travelling wave, slow curl breathing, now-and-then exploring, spring lag behind every move, flare when he spins and crawl steps when he walks.
    // The outer arms are his hands: armL/armR raise them (yawn, wave), hand channels and eating curl them round to his mouth and round the food.
    if (I.oc) { const O = I.oc, ts = now / 1000, ow = clamp(+P.ow || 0, 0, 3), osp = clamp(+P.osp || 0, -0.6, 1.6), ocl = clamp(+P.ocl || 0, -1, 1), ojt = Math.min(1, O.jt || 0), orp = clamp(+P.orp || 0, 0, 1.5), N = 18;
      const tg = P.x + P.tilt * 0.45 + P.lean * 1.3 + P.turn * 12, ly = P.lift - sq * 6;
      if (O.p == null) { O.p = tg; O.v = 0; O.l = ly; O.lv = 0; O.wp = 0; O.spn = P.spin; O.fl = 0; O.gp = 0; O.px = P.x; O.wk = 0; }
      O.v += ((tg - O.p) * 70 - O.v * 7) * dtS; O.p += O.v * dtS; O.lv += ((ly - O.l) * 70 - O.lv * 6) * dtS; O.l += O.lv * dtS;
      const lgx = clamp(O.p - tg, -9, 9), lgy = clamp(ly - O.l, -9, 9);
      let dsp = P.spin - O.spn; dsp = ((dsp % 360) + 540) % 360 - 180; O.spn = P.spin; O.fl += (clamp(Math.abs(dsp) / Math.max(dtS, 0.004) / 520, 0, 1) - O.fl) * Math.min(1, dtS * 5);
      const vxs = (P.x - O.px) / Math.max(dtS, 0.004); O.px = P.x; O.wk += (clamp(Math.abs(vxs) / 14, 0, 1) - O.wk) * Math.min(1, dtS * 5); O.gp += dtS * 10 * O.wk; O.wp += dtS * (1.6 + ow * 3.2);
      const fl = O.fl, wk = O.wk, eatW = SM(I.pEw || 0), eu = I.pEu || 0, sqp = Math.max(0, sq), wd = s => 4.3 * (1 - 0.36 * s) * (1 + sqp * 0.1);
      const SP = (a, cl) => { let d = 'M' + r2(a[0][0]) + ' ' + r2(a[0][1]); for (let i = 1; i < a.length - 1; i++) d += 'Q' + r2(a[i][0]) + ' ' + r2(a[i][1]) + ' ' + r2((a[i][0] + a[i + 1][0]) / 2) + ' ' + r2((a[i][1] + a[i + 1][1]) / 2); const l = a[a.length - 1]; return d + 'L' + r2(l[0]) + ' ' + r2(l[1]) + (cl ? 'Z' : ''); };
      const prj = p => { const dx = p[0] - 50, x1 = dx * cyb + p[2] * syb, z1 = -dx * syb + p[2] * cyb; return glob(50 + x1, HY + (p[1] - HY) * cp - z1 * sp); };
      const draw = (E, Wp, k0, cv) => { const n = Wp.length, e = n - 1, T2 = [], Lp = [], Rp = [], hl = [], sh = [], cap = [], cap0 = [];
        for (let k = 0; k < n; k++) { const A = Wp[Math.max(0, k - 1)], B = Wp[Math.min(e, k + 1)], tx = B[0] - A[0], ty = B[1] - A[1], l = Math.hypot(tx, ty) || 1; T2.push([tx / l, ty / l]); }
        for (let k = k0; k < n; k++) { const w = wd(k / e), c = Wp[k], t = T2[k], m = [-t[1], t[0]], ld = clamp((m[0] * -0.6 + m[1] * -0.8) * 3, -1, 1);
          Lp.push([c[0] + m[0] * w, c[1] + m[1] * w]); Rp.push([c[0] - m[0] * w, c[1] - m[1] * w]); hl.push([c[0] + m[0] * ld * w * 0.45, c[1] + m[1] * ld * w * 0.45]); sh.push([c[0] - m[0] * ld * w * 0.66, c[1] - m[1] * ld * w * 0.66]); }
        const te = T2[e], we = wd(1), Ce = Wp[e], t0 = T2[k0], w0 = wd(k0 / e), C0 = Wp[k0];
        for (let i = 1; i < 6; i++) { const f = i / 6 * Math.PI, c = Math.cos(f), s = Math.sin(f); cap.push([Ce[0] - te[1] * we * c + te[0] * we * s, Ce[1] + te[0] * we * c + te[1] * we * s]); cap0.push([C0[0] + t0[1] * w0 * c - t0[0] * w0 * s, C0[1] - t0[0] * w0 * c - t0[1] * w0 * s]); }
        set(E.b, 'd', SP(Lp.concat(cap, Rp.reverse(), cap0), true)); set(E.hl, 'd', SP(hl.slice(0, -1))); set(E.sh, 'd', SP(sh));
        let cd = ''; if (cv > 0.02) [0.6, 0.72, 0.84, 0.95].forEach(s => { const k = Math.round(s * e); if (k < k0 + 1) return; const c = Wp[k], r = 0.95 * (1 - 0.3 * s); cd += 'M' + r2(c[0] - r) + ' ' + r2(c[1]) + 'a' + r2(r) + ' ' + r2(r) + ' 0 1 0 ' + r2(2 * r) + ' 0a' + r2(r) + ' ' + r2(r) + ' 0 1 0 ' + r2(-2 * r) + ' 0'; });
        set(E.cu, 'd', cd); set(E.cu, 'opacity', r2(cv * 0.9)); };
      O.raw = 1;
      O.T.forEach(t => { const sd = t.sd, Lf = sd < 0, ax0 = t.arm ? clamp(Lf ? P.armL : P.armR, -40, 190) : 0; if (t.axs == null) t.axs = ax0; t.axs += (ax0 - t.axs) * Math.min(1, dtS * (ax0 > t.axs ? 3.2 : 7)); const ax = t.axs, raise = SM(ax / 120);
        const ex = t.arm ? 0 : Math.pow(Math.max(0, Math.sin(ts * 0.41 + t.ph * 2.3)), 10), st = wk * Math.max(0, Math.sin(O.gp + (t.j % 2 ? Math.PI : 0) + (Lf ? 0 : Math.PI / 2))), rp = orp * Math.max(0, Math.sin(ts * 6.5 - t.ri * 0.8));
        let f0 = t.f0 + (ax * 0.7 + osp * 24 + fl * 40 + sqp * 36 + ex * 24 + st * 26 + rp * 55) * D2R; f0 = lerp(f0, 0.07, ojt);
        const fx = lerp(t.f0 + (36 * raise + osp * 8) * D2R, 0.07, ojt);
        if (t.al == null) { t.al = f0; t.av = 0; } t.av += ((f0 - t.al) * 240 - t.av * 19) * dtS; t.al += t.av * dtS;
        const C = lerp(t.C, -t.C * 0.28, SM((ax - 50) / 70)) * (1 + 0.1 * Math.sin(ts * 0.9 + t.ph) + ocl * 0.6) * (1 - 0.5 * fl) * (1 - 0.75 * ojt) * (1 - 0.35 * ex) * (1 - 0.35 * rp), wa = 0.13 + ow * 0.2 + ex * 0.2 + st * 0.15;
        const phi = s => fx + (f0 - fx) * SM(Math.min(1, s * 2.4)) + (t.al - f0) * Math.pow(s, 1.5) + C * Math.pow(s, t.pw) + wa * Math.sin(Math.PI * 2.2 * s - O.wp + t.ph) * s;
        const ds = t.L * (1 + 0.035 * Math.sin(ts * 1.25 + t.ph) + osp * 0.05 + ojt * 0.15 + raise * 0.28) / (N - 1), hx = Math.cos(t.be), hz = Math.sin(t.be), gy = G + 0.8 + Math.max(0, P.lift), M = []; let ox = 0, oy = 0;
        for (let k = 0; k < N; k++) { const s = k / (N - 1); if (k) { const a = phi((k - 0.5) / (N - 1)); ox += Math.sin(a) * ds; oy += Math.cos(a) * ds; }
          let x = t.rx + sd * ox * hx, y = t.ry + oy, z = t.rz + ox * hz + 1.8 * Math.cos(Math.PI * 2 * s - O.wp * 0.8 + t.ph * 1.3) * s * (1 + ow * 0.5);
          if (ojt > 0.01) x = lerp(x, 50 + (t.rx - 50) * 0.45, ojt * s);
          x += lgx * Math.pow(s, 1.6) * 0.9; y = Math.min(gy, y + lgy * Math.pow(s, 1.5) * 0.8); M.push([x, y, z]); }
        let w = 0, kG = N - 1;
        if (t.arm) { const hX = Lf ? P.hLx : P.hRx, hY = Lf ? P.hLy : P.hRy, wH = SM((Math.hypot(hX, hY) - 4) / 10); w = Math.max(wH, eatW);
          if (w > 0.001) { const mh = I.mapHand(Lf ? hX : -hX, hY), hT = [50 + sd * Math.abs(50 - g.pawX) + (Lf ? mh[0] : -mh[0]), g.pawY + mh[1], 12 + 18 * SM((-hY - 6) / 10)], eT = [50 + sd * 9.5, MO.y + 16 - 7 * eu, 17];
            const Tg = [0, 1, 2].map(i => lerp(hT[i], eT[i], eatW)), R0 = M[0], B1 = [R0[0] + sd * 5, R0[1] + 15, R0[2] + 4], B2 = [Tg[0] + sd * 6, Tg[1] + 12, Tg[2]], kE = Math.round((N - 1) * 0.8), tr = Math.sin(ts * 5) * 0.08;
            let pv = null, ang = 0;
            for (let k = 0; k < N; k++) { let b; if (k <= kE) { const u = k / kE, v = 1 - u; b = [0, 1, 2].map(i => v * v * v * R0[i] + 3 * v * v * u * B1[i] + 3 * v * u * u * B2[i] + u * u * u * Tg[i]); if (k === kE) ang = Math.atan2(Tg[1] - B2[1], Tg[0] - B2[0]); }
              else { ang += -sd * 0.34 + tr; b = [pv[0] + Math.cos(ang) * 1.5, pv[1] + Math.sin(ang) * 1.5, pv[2] + 0.4]; }
              pv = b; M[k] = [lerp(M[k][0], b[0], w), lerp(M[k][1], b[1], w), lerp(M[k][2], b[2], w)]; }
            kG = kE; } }
        const Wp = M.map(prj), fz = (-(t.rx - 50) * syb + t.rz * cyb) / Math.hypot(t.rx - 50, t.rz), cv = SM((fz + 0.4) / 0.5); draw(t, Wp, 0, cv);
        if (t.fr) { let k0 = -1; if (w > 0.02) for (let k = 1; k < N; k++) { const p = M[k], ex2 = (p[0] - 50) / 34.5, ey2 = (p[1] - 46) / 28.5; if (ex2 * ex2 + ey2 * ey2 > 1) { k0 = k; break; } }
          if (k0 > 0 && N - k0 >= 3) { draw(t.fr, Wp, k0, cv); set(t.fr.g, 'opacity', r2(SM(w * 2.5))); } else set(t.fr.g, 'opacity', 0); }
        t.z = bywZ(M[N >> 1][0], M[N >> 1][2]); if (t.arm) W[Lf ? 'pawL' : 'pawR'] = Wp[kG]; });
      O.raw = 0;
      const key2 = O.T.slice().sort((a, b) => a.z - b.z).map(t => O.T.indexOf(t)).join(','); if (key2 !== O.ok && O.anchor) { O.ok = key2; key2.split(',').forEach(i => O.par.insertBefore(O.T[+i].g, O.anchor)); }
      const ik = +P.ink || 0; if (ik > 0.5 && !O.ik) { O.ik = 1; O.inkT = now; O.inkP = glob(50, 88); } if (ik < 0.2) O.ik = 0;
      const ia = O.inkT ? (now - O.inkT) / 1700 : 2; if (ia < 1) { O.ig.style.display = ''; O.IP.forEach((c, i) => { const a = i / O.IP.length * TAU + 0.4, r = 2 + ia * (5 + (i % 3) * 2.5); set(c, 'cx', r2(O.inkP[0] + Math.cos(a) * r * 1.3)); set(c, 'cy', r2(O.inkP[1] + Math.sin(a) * r * 0.45 - ia * 3)); set(c, 'r', r2(3.5 + ia * (6 + (i % 2) * 2.5))); }); set(O.ig, 'opacity', r2(0.85 * (1 - SM(ia)))); } else O.ig.style.display = 'none'; }
    if (I.pq) { const Pq = I.pq, rY = Pq.rY, ts = now / 1000, fc = cyb * cp, par = Pq.bq.e.parentNode, PJ = (x1, y, z1) => glob(50 + x1, HY + (y - HY) * cp - z1 * sp);
      const out = []; [16.4, 17.4, 19.2, 22, 26, 31, 37, 44, 51, 57, 63, 69, 75, 80, 84.5, 87.6, 89.5].forEach(y => { const r = rY(y); for (let k = 0; k < 20; k++) out.push(sph(50 + r * Math.sin(k / 20 * TAU), y, r * Math.cos(k / 20 * TAU))); });
      Pq.d = H.closedD(H.hull(out));
      // the white belly is painted on the front of the round body: it slides round as he turns and tucks away at the edge
      if (Pq.bel) { set(Pq.bel.e, 'd', toD(Pq.bel.segs, (x, y) => { const r = Math.max(rY(y), 0.5); let t2 = Math.asin(clamp((x - 50) / r, -1, 1)) + yb; t2 = clamp(((t2 % TAU) + TAU * 1.5) % TAU - Math.PI, -Math.PI / 2, Math.PI / 2); return PJ(r * Math.sin(t2), y, r * Math.cos(t2) + 0.3); })); set(Pq.bel.e, 'opacity', r2(SM((fc + 0.55) / 0.4))); }
      const place = (g, front) => par.insertBefore(g, front ? (Pq.bel ? Pq.bel.e : Pq.bq.e).nextSibling : par.firstChild);
      const puffS = (S, F, g) => { const dr = fc >= 0 ? 1 : -1; if (dr !== g._d) { g._d = dr; (dr > 0 ? S : S.slice().reverse()).forEach(s => g.appendChild(s.el)); }
        S.forEach(s => { set(s.el, 'd', F(s)); const f = s.u * fc > -0.3 ? Pq.LF : Pq.DF; if (f !== s.f) { s.f = f; set(s.el, 'fill', f); set(s.el, 'stroke', f); } }); };
      Pq.fl.forEach(F => { const Lf = F.sd < 0, hy = Lf ? P.hLy : P.hRy, ek = SM(I.pEw || 0), a = ((Lf ? P.armL : -P.armR) * 0.75 + (Lf ? 1 : -1) * (Math.max(0, -hy) * 1.6 * (1 - ek) + Math.sin(ts * 1.9) * 3 + clamp(+P.flap || 0, 0, 1.5) * (14 + 16 * Math.sin(ts * 26)))) * D2R, ca = Math.cos(a), sa = Math.sin(a), px = F.pv[0], py = F.pv[1], cx = F.c[0], cy = F.c[1];
        // eating: the flipper stays hinged at the shoulder, swings round and stretches so its tip reaches the beak
        let ca2 = ca, sa2 = sa, kS = 1; const tvx = F.tip[0] - px, tvy = F.tip[1] - py, tl0 = Math.hypot(tvx, tvy) || 1, ux = tvx / tl0, uy = tvy / tl0;
        if (ek > 0) { const Tx = MO.x + F.sd * 7.5, Ty = MO.y + 13.5 - 8 * (I.pEu || 0), aE = Math.atan2(Ty - py, Tx - px) - Math.atan2(tvy, tvx); let df = aE - a; df = ((df % TAU) + TAU * 1.5) % TAU - Math.PI; const a2 = a + df * ek; ca2 = Math.cos(a2); sa2 = Math.sin(a2); kS = 1 + (clamp(Math.hypot(Tx - px, Ty - py) / tl0, 0.6, 1.7) - 1) * ek; }
        const M = (x, y, s, uu) => { const x0 = cx + (x - cx) * s, y0 = cy + (y - cy) * s; let vx = x0 - px, vy = y0 - py; const dl = (vx * ux + vy * uy) * (kS - 1); vx += ux * dl; vy += uy * dl; const xr = px + vx * ca2 - vy * sa2, yr = py + vx * sa2 + vy * ca2; return sph(xr, yr, 7 - Math.abs(xr - px) * 0.3 + uu * 2.4 + ek * 8); };
        puffS(F.S, s => toD(F.q.segs, (x, y) => M(x, y, s.s, s.u)), F.g);
        const fr = sphZ(px - F.sd * 2, py + 6, 7) > -2; if (fr !== F.fr) { F.fr = fr; place(F.g, fr); }
        W[Lf ? 'pawL' : 'pawR'] = M(F.tip[0], F.tip[1], 1, 0); });
      // penguin tail: a short stiff wedge sticking out of the lower back, slightly drooping; wags side to side, pokes out in profile
      { const T = Pq.tq, wa = (Math.sin(ts * 2.3) * 9 + clamp(P.wag, -30, 30) * 0.8) * D2R, cw = Math.cos(wa), sw = Math.sin(wa), y0 = 80.5, z0 = -rY(y0) + 2.5, N = 7, pts2 = [], rid = [];
        const TP = (x, y, z) => { const dx = x - 50, dz = z - z0; return sph(50 + dx * cw + dz * sw, y, z0 - dx * sw + dz * cw); };
        for (let i = 0; i < N; i++) { const s = i / (N - 1), cy = y0 + 4.2 * s * s + 1.2 * s, cz = z0 - 8.5 * s, w = 6.2 * (1 - s * 0.55) * (i === N - 1 ? 0.75 : 1), h = 1.9 * (1 - s * 0.45);
          for (let k = 0; k < 10; k++) { const f = k / 10 * TAU; pts2.push(TP(50 + w * Math.cos(f), cy + h * Math.sin(f), cz)); } if (i && i < N - 1) rid.push(TP(50, cy - h * 0.8, cz)); }
        set(T.el, 'd', H.closedD(H.hull(pts2))); set(T.hl, 'd', rid.map((p, k) => (k ? 'L' : 'M') + r2(p[0]) + ' ' + r2(p[1])).join(''));
        const fr = sphZ(50, 84, z0 - 6) > 0; if (fr !== T.fr) { T.fr = fr; place(T.g, fr); } }
      I.items.forEach(q => { if (q.role === 'pgShine') set(q.e, 'd', toD(q.segs, glob)); }); }
    // Shelly: 3D shell dome (scutes + rim slide round as it turns), neck, 4 legs (front pair hold the food), tail; the shell lip covers his head and legs as he hides
    if (I.tt) { const T = I.tt, ts = now / 1000, ys = T.ys, cs = Math.cos(ys), ss = Math.sin(ys), K = T.K, rY = T.rY, h = T.h, hS = SM(Math.min(1, h * 2)), pS = p => r2(p[0]) + ' ' + r2(p[1]);
      const SA = (x, y, z) => [50 + x * cs + z * ss, y], SP = (x, y, z) => glob(50 + x * cs + z * ss, y), SZ = (x, z) => -x * ss + z * cs, hullD = pp => H.closedD(H.hull(pp));
      const out = []; T.YS.forEach(y => { const r = rY(y); for (let k = 0; k < 28; k++) { const f = k / 28 * TAU; out.push(SP(r * Math.sin(f), y, r * K * Math.cos(f))); } }); set(T.dome, 'd', hullD(out));
      const th0 = Math.atan2(-ss, K * cs), tp = [], bt = []; for (let i = 0; i <= 40; i++) { const th = th0 - Math.PI / 2 + i / 40 * Math.PI, c = Math.abs(Math.cos(th)), yT = 66 + 4 * c * c, yB = 66 + 14 * Math.pow(c, 1.5), rT = rY(yT), rB = rY(yB); tp.push(SP(rT * Math.sin(th), yT, rT * K * Math.cos(th))); bt.push(SP(rB * Math.sin(th), yB, rB * K * Math.cos(th))); }
      set(T.band, 'd', 'M' + tp.concat(bt.reverse()).map(pS).join('L') + 'Z');
      let hd = ''; T.HEX.forEach(([t0, yc, R]) => { const rc = rY(yc); if (rc * (-Math.sin(t0) * ss + K * Math.cos(t0) * cs) < rc * 0.5) return; hd += 'M' + [30, 90, 150, 210, 270, 330].map(dg => { const f = dg * D2R, y = yc + R * Math.sin(f), r = rY(y), th = t0 + R * Math.cos(f) / Math.max(r, 4); return pS(SP(r * Math.sin(th), y, r * K * Math.cos(th))); }).join('L') + 'Z'; }); set(T.hex, 'd', hd);
      set(T.shine, 'd', toD(ellS(30, 36, 8, 3.5, -32, 12), glob));
      const lip = 82 - 11 * hS, hcx = 50 + rY(lip) * K * ss * 0.9, hw = 13 * Math.max(0, cs) + 1, A = glob(hcx - hw, lip), Bp = glob(hcx + hw, lip), Cq = glob(hcx, lip + 7), Ct = glob(hcx, lip - 16 * hS);
      if (h > 0.01 && cs > 0) { set(T.hole, 'd', 'M' + pS(A) + 'Q' + pS(Ct) + ' ' + pS(Bp) + 'Q' + pS(Cq) + ' ' + pS(A) + 'Z'); set(T.hole, 'opacity', r2(SM(cs * 4) * SM(h * 5))); T.lid.style.display = '';
        set(T.clip, 'd', 'M' + pS(glob(-30, lip)) + 'L' + pS(A) + 'Q' + pS(Cq) + ' ' + pS(Bp) + 'L' + pS(glob(130, lip)) + 'L' + pS(glob(130, 150)) + 'L' + pS(glob(-30, 150)) + 'Z'); }
      else { set(T.hole, 'opacity', 0); T.lid.style.display = 'none'; }
      const late = T.hz < 0; if (late !== T.late) { T.late = late; if (late) { T.gLate.appendChild(T.gShell); if (T.filt) T.gShell.setAttribute('filter', T.filt); } else { T.par.insertBefore(T.gShell, T.gNeck); T.gShell.removeAttribute('filter'); } }
      const nb = SA(0, 72 + h * 2, rY(72) * K - 5), ne = [50 + T.hx, 60 + T.hy + 19 * T.s * 0.45], rN = 6.8 * (0.6 + 0.4 * T.s), np = [];
      for (let i = 0; i <= 6; i++) { const u2 = i / 6, x = nb[0] + (ne[0] - nb[0]) * u2, y = nb[1] + (ne[1] - nb[1]) * u2 + Math.sin(u2 * Math.PI) * 1.5; for (let k = 0; k < 12; k++) { const f = k / 12 * TAU; np.push(glob(x + rN * Math.cos(f), y + rN * Math.sin(f))); } }
      set(T.neck, 'd', hullD(np));
      { const dx = ne[0] - nb[0], dy = ne[1] - nb[1], ln = Math.hypot(dx, dy) || 1, ux = dx / ln, uy = dy / ln, nx = -uy, ny = ux; let fd = ''; [0.3, 0.55].forEach(f => { const cx = nb[0] + dx * f, cy = nb[1] + dy * f; fd += 'M' + pS(glob(cx - nx * rN * 0.75, cy - ny * rN * 0.75)) + 'Q' + pS(glob(cx + ux * 1.6, cy + uy * 1.6)) + ' ' + pS(glob(cx + nx * rN * 0.75, cy + ny * rN * 0.75)); }); set(T.fold, 'd', fd); set(T.fold, 'opacity', r2(0.8 * SM((ln - 5) / 5))); }
      const ek = SM(I.pEw || 0), mA = [50 + (MO.x - 50) * T.s + T.hx, 60 + (MO.y - 60) * T.s + T.hy], gp = Math.sin(T.ph || 0);
      T.legs.forEach(Lg => { const sd = Lg.sd, fr = Lg.fr, x0 = sd * (fr ? 18 : 27) * (1 - h * 0.3), z0 = (fr ? 17 : -14) * (1 - h * 0.25), y0 = (fr ? 80 : 79) - h * 6, hip = SA(x0, y0, z0), zz = SZ(x0, z0), wl = (T.wk || 0) * 3.5 * Math.max(0, ((sd < 0) === !!fr) ? gp : -gp);
        let a = 0, len = fr ? 6.3 : 7.3, lift = wl;
        if (fr) { const hy = sd < 0 ? P.hLy : P.hRy, ao = clamp((sd < 0 ? P.armL : P.armR) * 0.55 + Math.max(0, -hy) * 1.2 + Math.sin(ts * 1.7 + sd) * 2, -40, 120); a = (sd < 0 ? 1 : -1) * ao * D2R;
          if (ek > 0) { const Tg = [mA[0] + sd * 6.5, mA[1] + 8 - 6 * (I.pEu || 0)], vx = Tg[0] - hip[0], vy = Tg[1] - hip[1], aT = Math.atan2(-vx, vy); let df = aT - a; df = ((df % TAU) + TAU * 1.5) % TAU - Math.PI; a += df * ek; len += (clamp(Math.hypot(vx, vy), 4, 26) - len) * ek; lift *= 1 - ek; } }
        else lift += clamp(sd < 0 ? P.footL : P.footR, 0, 12) * 0.8;
        const kH = 1 - h * 0.9, kR = 1 - h * 0.35; len *= kH; lift *= kH;
        const dx = -Math.sin(a), dy = Math.cos(a), fx = hip[0] + dx * len, fy = hip[1] + dy * len - lift, px = -dy, py = dx, pts = [];
        for (let i = 0; i <= 4; i++) { const u2 = i / 4, cx = hip[0] + (fx - hip[0]) * u2, cy = hip[1] + (fy - hip[1]) * u2, r = (4.8 - 0.6 * u2) * kR; for (let k = 0; k < 10; k++) { const f = k / 10 * TAU; pts.push(glob(cx + r * Math.cos(f), cy + r * Math.sin(f))); } }
        for (let k = 0; k < 14; k++) { const f = k / 14 * TAU, c = Math.cos(f) * 5.8 * kR, s2 = Math.sin(f) * 3.2 * kR; pts.push(glob(fx + px * c + dx * s2, fy + py * c + dy * s2)); }
        set(Lg.el, 'd', hullD(pts)); let td = ''; [-1, 0, 1].forEach(j => { td += toD(ellS(fx + dx * 2.5 * kR + px * j * 2.9 * kR, fy + dy * 2.5 * kR + py * j * 2.9 * kR, 1.25 * kR, 0.9 * kR, Math.atan2(py, px) / D2R, 6), glob); }); set(Lg.toe, 'd', td);
        if (fr) W[sd < 0 ? 'pawL' : 'pawR'] = glob(fx, fy);
        const tg = zz > -1 ? T.gFront : T.gBack; if (Lg.g.parentNode !== tg) tg.appendChild(Lg.g); });
      { const zt = -rY(78) * K + 1.5, b = SA(0, 78 - h * 3, zt), wa = Math.sin(ts * 2.2) * 2 + clamp(P.wag, -30, 30) * 0.08, tq = SA(wa, 80.5 - h * 3, zt - 6 * (1 - h)), pts = []; for (let i = 0; i <= 4; i++) { const u2 = i / 4, x = b[0] + (tq[0] - b[0]) * u2, y = b[1] + (tq[1] - b[1]) * u2, r = 2.6 - 1.8 * u2; for (let k = 0; k < 8; k++) { const f = k / 8 * TAU; pts.push(glob(x + r * Math.cos(f), y + r * Math.sin(f))); } }
        set(T.tail, 'd', hullD(pts)); const tgp = SZ(0, zt) > 0 ? T.gFront : T.gBack; if (T.tg.parentNode !== tgp) tgp.appendChild(T.tg); } }
    for (const q of I.items) {
      const e = q.e;
      switch (q.role) {
        case 'mcap': set(e, 'd', CYL.cap); set(e, 'opacity', r2(CYL.capV)); break;
        case 'mcapS': set(e, 'd', toD(q.segs, (x, y) => cylW(x - 50, 0, (y - CYL.Yc) / se0))); set(e, 'opacity', r2((q.op ? +q.op : 1) * CYL.capV)); break;
        case 'dglaze': set(e, 'd', toD(q.segs, (x, y) => sph(x, y))); set(e, 'opacity', r2(SM((cyh * cp + 0.25) / 0.35))); break;
        case 'head': { if (I.bk) { headD = I.bk.d; set(e, 'd', headD); break; } if (I.pn) { headD = I.pn.d; set(e, 'd', headD); break; } if (I.av) { headD = I.av.d; set(e, 'd', I.av.dF); break; } if (I.br) { headD = I.br.d; set(e, 'd', headD); break; } if (I.lm) { headD = I.lm.d; set(e, 'd', headD); break; } if (I.kw) { headD = I.kw.d; set(e, 'd', headD); break; } if (I.pe) { headD = I.pe.d; set(e, 'd', headD); break; } if (I.pt) { headD = I.pt.d; set(e, 'd', headD); break; } if (I.mo) { headD = I.mo.d; set(e, 'd', headD); break; } if (I.pq) { headD = I.pq.d; set(e, 'd', headD); break; } if (I.hn) { headD = I.hn.d; set(e, 'd', headD); break; } if (I.dl && I.dl.round) { headD = toD(ellS(HX, HY, I.dl.round[0], I.dl.round[1], 0, 24), headT); set(e, 'd', headD); break; } if (I.gb) { headD = I.gb.d; set(e, 'd', headD); break; }
          // Jelli: the bell is a 3D dome of revolution; its scalloped rim runs all the way round and slides past as he turns, so the whole bell visibly rotates
          if (I.jl) { const o = [], V = (x, y, z) => { const p = headT(x, HY + (y - HY) * cp - z * sp); o.push(r2(p[0]) + ' ' + r2(p[1])); };
            for (let i = 0; i <= 18; i++) { const s = i / 18; V(50 + 36 * (1 - s * s), 58 - 84 * s + 42 * s * s, 0); } for (let i = 17; i >= 0; i--) { const s = i / 18; V(50 - 36 * (1 - s * s), 58 - 84 * s + 42 * s * s, 0); }
            for (let i = 1; i < 72; i++) { const tv = -Math.PI / 2 + i / 72 * Math.PI, tw = tv - yb; V(50 + 36 * Math.sin(tv), 58.6 - 3 * Math.pow(Math.abs(Math.sin(4 * tw)), 0.7), 36 * Math.cos(tv)); }
            headD = 'M' + o.join('L') + 'Z'; set(e, 'd', headD); break; } if (I.bg) { headD = I.bg.dome; set(e, 'd', headD); break; } if (I.ck) { headD = I.ck.d; set(e, 'd', headD); break; } if (I.dn) { headD = I.dn.d; set(e, 'd', headD); break; } if (CYL) { headD = CYL.d; set(e, 'd', headD); break; } if (I.wh) { headD = I.wh.d; set(e, 'd', headD); break; } if (I.star) { headD = I.star.hd; set(e, 'd', I.star.md); break; } headD = toD(q.segs, pf ? (x, y) => { const dy = y - MO.y, gg = Math.exp(-dy * dy / 80); return headT(nrw(x + (x < HX ? -1 : 1) * pf * 3.2 * gg * clamp(Math.abs(x - HX) / 20, 0, 1)), y); } : NS < 1 ? (x, y) => headT(nrw(x), y) : headT); set(e, 'd', headD); if (I.spk) set(I.spk.el, 'd', spikeD()); break; }
        case 'shine': if (I.star) { set(e, 'd', toD(q.segs, (x, y) => sph(x, y, I.star.T + 2.5))); set(e, 'opacity', r2(0.8 * SM(cyh * cp * 2.5))); break; }
        case 'wsurf': { const k = q.tw ? 0.82 + 0.28 * Math.sin(now / 420 + q.ti * 1.7) : 1, cx = q.cx, cy = q.cy; set(e, 'd', toD(q.segs, (x, y) => sph(cx + (x - cx) * k, cy + (y - cy) * k))); set(e, 'opacity', r2((q.op ? +q.op : 1) * zc(cx, cy) * (q.tw ? 0.75 + 0.25 * k : 1))); break; }
        case 'wspout': case 'wspark': { const ts = now / 1000, spv = clamp(+P.spout || 0, 0, 1.5), a = Math.sin(ts * 1.7) * 0.12 + clamp(P.htilt, -10, 10) * 0.01 + clamp(P.lean, -5, 5) * 0.02, sc = 1 + 0.07 * Math.sin(ts * 3.1) + spv * 0.55 + Math.max(0, pf) * 0.2, c = Math.cos(a), si = Math.sin(a);
          const SP = (x, y) => { const vx = (x - 50) * sc, vy = (y - 32) * sc; return [50 + vx * c - vy * si, 32 + vx * si + vy * c]; };
          if (q.role === 'wspout') { const B0 = sph(50, 32, 3); set(e, 'd', toD(q.segs, (x, y) => { const p = SP(x, y); return [B0[0] + p[0] - 50, B0[1] + p[1] - 32]; })); set(e, 'stroke-width', r2(1.4 * (1 + spv * 0.4))); break; }
          const tw = 0.55 + 0.45 * Math.sin(ts * 2.6 + q.cx * 0.37), C0 = SP(q.cx, q.cy - spv * 4), k = tw * (1 + spv * 0.3);
          const B1 = sph(50, 32, 3); set(e, 'd', toD(q.segs, (x, y) => [B1[0] + C0[0] - 50 + (x - q.cx) * k, B1[1] + C0[1] - 32 + (y - q.cy) * k])); set(e, 'opacity', r2(0.45 + 0.55 * tw)); break; }
        case 'wshine': { const B = I.wh.bb, R0 = I.wh.bb0; if (!B) break; const nx = B[0] + (q.cx - R0[0]) / (R0[2] - R0[0]) * (B[2] - B[0]), ny = B[1] + (q.cy - R0[1]) / (R0[3] - R0[1]) * (B[3] - B[1]); set(e, 'd', toD(q.segs, (x, y) => [x - q.cx + nx, y - q.cy + ny])); break; }
        case 'fry': { const F = q.fry, ts = now / 1000, fw = clamp(+P.fw || 0, 0, 1.5), a = F.a + (Math.sin(ts * 1.6 + F.i * 1.3) * 1.2 + (F.cx - 50) / 21 * (F.cx < 50 ? P.earL : P.earR) * 0.55 + Math.sin(now / 42 + F.i * 1.9) * fw * 3.5) * D2R, ca = Math.cos(a), sa = Math.sin(a), Lf = F.y1 - F.y0, r = F.r;
          const ax = s => { const vy = F.y1 - s - F.py; return [F.cx - vy * sa, F.py + vy * ca]; }, ring = (s, rr, o) => { const c = ax(s); for (let k = 0; k < 12; k++) { const f = k / 12 * TAU, cf = Math.cos(f) * rr; o.push(byw(c[0] + ca * cf, c[1] + sa * cf, F.z + rr * Math.sin(f))); } };
          const out = []; [0, 0.3, 0.6].forEach(u => ring(Lf * u, r, out)); [0, 0.4, 0.8, 1.15, 1.45].forEach(ph => ring(Lf - r + r * Math.sin(ph), r * Math.cos(ph), out)); const tp = ax(Lf); out.push(byw(tp[0], tp[1], F.z));
          set(e, 'd', H.hull(out).map((p, k) => (k ? 'L' : 'M') + r2(p[0]) + ' ' + r2(p[1])).join('') + 'Z');
          const Pb = byw(...ax(Lf * 0.4), F.z), Pt = byw(...ax(Lf * 0.8), F.z), dx = Pt[0] - Pb[0], dy = Pt[1] - Pb[1], dl = Math.hypot(dx, dy) || 1; let nx = -dy / dl, ny = dx / dl; if (nx < 0) { nx = -nx; ny = -ny; } const rw = r * 1.02;
          set(q.gr, 'x1', r2(Pb[0] - nx * rw)); set(q.gr, 'y1', r2(Pb[1] - ny * rw)); set(q.gr, 'x2', r2(Pb[0] + nx * rw)); set(q.gr, 'y2', r2(Pb[1] + ny * rw)); break; }
        case 'cherry': { const S = I.sc; if (!S || S.cc == null) { set(e, 'd', toD(q.segs, glob)); break; } set(e, 'd', toD(q.segs, (x, y) => { const vx = x - 50, vy = y - 18.5; return sph(50 + vx * S.cc - vy * S.cs, 18.5 + vx * S.cs + vy * S.cc - S.cy, 0); })); break; }
        case 'straw': set(e, 'd', toD(q.segs, I.bb.SF)); break;
        case 'tea': { const B = I.bb; set(e, 'd', toD(q.segs, (x, y) => globN(x, y < 70 ? y + B.sl * (x - 50) + Math.sin(x * 0.45 + B.t * 3) * 0.35 * B.wv * clamp((70 - y) / 6, 0, 1) : y))); break; }
        case 'smz': { const zz = I.slZ ? I.slZ(q.cx, q.cy) : undefined; set(e, 'd', toD(q.segs, (x, y) => sph(x, y, I.slZ ? I.slZ(x, y) : undefined))); set(e, 'opacity', r2((q.op ? +q.op : 1) * vis(sphZ(q.cx, q.cy, zz)))); break; }
        case 'pfBel': { const k = 1 + Math.sin(now / 520) * 0.035 + clamp(P.puff, 0, 1.2) * 0.08 + clamp(P.wide, 0, 1) * 0.04, wb = Math.sin(now / 230) * 0.5 + clamp(P.tilt, -20, 20) * 0.04, cx = q.cx, cy = q.cy; set(e, 'd', toD(q.segs, (x, y) => sph(cx + (x - cx) * k + wb * (y - cy) / 12, cy + (y - cy) * k * (1 + Math.sin(now / 520 + 1) * 0.03)))); set(e, 'opacity', r2(vis(sphZ(cx, cy - 4)))); break; }
        case 'bshine': set(e, 'd', toD(q.segs, headT)); break;
        case 'wtw': { if (I.star && !I.star.capOff) { I.star.capOff = 1; Object.values(I.star.capE).forEach(x => { x.style.display = 'none'; }); } // Wishling: no nightcap; her little wish-sparkles twinkle
          if (!q.sub) q.sub = (q.e.getAttribute('d') || '').split(/(?=M)/).filter(s => s.trim()).map(s => { const sg = parsePath(s), P2 = pts(sg); return { sg, c: [P2.reduce((a, p) => a + p[0], 0) / P2.length, P2.reduce((a, p) => a + p[1], 0) / P2.length] }; });
          const ts = now / 1000; set(e, 'd', q.sub.map((o, i) => { const k = 0.55 + 0.6 * Math.abs(Math.sin(ts * 1.8 + i * 1.7 + q.cx * 0.1)); return toD(o.sg, (x, y) => [o.c[0] + (x - o.c[0]) * k, o.c[1] + (y - o.c[1]) * k]); }).join('')); break; }
        case 'bsurf': { const B = q.bs, zE2 = (x, y) => (B.zs || 1) * B.rz * Math.sqrt(Math.max(0, 1 - Math.pow((x - B.cx) / B.rx, 2) - Math.pow((y - B.cy) / B.ry, 2))) + 0.3; set(e, 'd', toD(q.segs, (x, y) => B.h ? sph(x, y, zE2(x, y)) : byw(x, y, zE2(x, y)))); set(e, 'opacity', r2((q.op ? +q.op : 1) * vis((B.h ? sphZ(q.cx, q.cy, zE2(q.cx, q.cy)) : bywZ(q.cx, zE2(q.cx, q.cy))) + 2))); break; }
        case 'bnop': break;
        case 'fnBlow': { const p = sph(50, 30, 13); W.blow = p; set(e, 'd', toD(q.segs, (x, y) => [p[0] + x - q.cx, p[1] + y - q.cy])); break; }
        case 'bow': { const by = 82, z0 = sz(0, by - HY), bt = Math.sin(now / 380) * 2.5 * D2R + clamp(P.tilt, -15, 15) * 0.25 * D2R, cb = Math.cos(bt), sb = Math.sin(bt);
          set(e, 'd', toD(q.segs, (x, y) => { const vx = x - 50, vy = y - by; return sph(50 + vx * cb - vy * sb, by + vx * sb + vy * cb, z0); })); set(e, 'opacity', r2(vis(sphZ(50, by, z0)))); break; }
        case 'body': case 'deco': set(e, 'd', toD(q.segs, globN)); break;
        case 'wing': case 'wspot': { const w = q.role === 'wing' ? q : q.owner, ph = I.wphi || 0, cph = Math.cos(ph), sph0 = Math.sin(ph), WF = (x, y, dz) => { const dx = x - w.hX; return byw(w.hX + dx * cph, y, -6 - Math.abs(dx) * sph0 + dz); };
          set(e, 'd', toD(q.segs, (x, y) => WF(x, y, q.role === 'wspot' ? 0.3 : 0)));
          if (q.role === 'wing') { const dx = q.cx - q.hX, fr = bywZ(q.hX + dx * cph, -6 - Math.abs(dx) * sph0) > 4; if (fr !== q._fr) { q._fr = fr; const bg = I.wbg; if (fr) { bg.appendChild(e); q.sp.forEach(s => bg.appendChild(s.e)); } else { q.sp.slice().reverse().forEach(s => bg.insertBefore(s.e, bg.firstChild)); bg.insertBefore(e, bg.firstChild); } }
            W[q.side < 0 ? 'wingL' : 'wingR'] = WF(q.side < 0 ? 8 : 92, 34, 0); } break; }
        case 'tuft': set(e, 'd', toD(q.segs, (x, y) => sph(x, y, 6))); set(e, 'opacity', r2(SM(cyh * cp * 3))); break;
        case 'belly': set(e, 'd', toD(q.segs, (x, y) => { const dx = x - HX, dy = y - HY, qq = SR * SR - dx * dx - dy * dy; return sph(x, y, (qq > 0 ? Math.sqrt(qq) : 0) * RK + 0.4); })); set(e, 'opacity', r2((+q.op || 1) * zc(q.cx, q.cy))); break;
        case 'gloss': set(e, 'd', toD(q.segs, (x, y) => sph(x, y))); set(e, 'opacity', r2((q.op ? +q.op : 1) * zc(q.cx, q.cy))); break;
        case 'hclip': set(e, 'd', toD(q.segs, (x, y) => sph(x, y, q.zA))); set(e, 'opacity', r2(vis(sphZ(q.cx, q.cy, q.zA)))); break;
        case 'bdeco': { const B = I.belly, zf = (x, y) => { const dx = x - B.x, v = clamp((y - B.y) / B.h, -1, 1), w = B.w * Math.sqrt(1 - v * v * 0.5); return B.d * Math.sqrt(Math.max(0, 1 - (dx / w) * (dx / w))); };
          set(e, 'd', toD(q.segs, (x, y) => glob(B.x + (x - B.x) * cyb + zf(x, y) * syb, y))); set(e, 'opacity', r2(SM((-(q.cx - B.x) * syb + zf(q.cx, q.cy) * cyb) / 3))); break; }
        case 'orbit': { const O = I.orb; set(e, 'd', toD(q.segs, (x, y) => [O.P[0] + (x - O.c[0]) * O.s, O.P[1] + (y - O.c[1]) * O.s])); break; }
        case 'patch': case 'face': if (q.spk != null) { const st = Math.floor(now / 85), rn = k => { const v = Math.sin((st + q.spk) * 12.9898 + k * 78.233) * 43758.5453; return v - Math.floor(v); }, on = rn(0) > 0.3, jx = (rn(1) - 0.5) * 1.2, jy = (rn(2) - 0.5) * 1.2; set(e, 'd', toD(q.segs, (x, y) => face(x + jx, y + jy))); set(e, 'opacity', r2((on ? 1 : 0.25) * zc(q.cx, q.cy))); break; } set(e, 'd', toD(q.segs, face)); set(e, 'opacity', r2((q.op ? +q.op : 1) * zc(q.cx, q.cy))); break;
        case 'cheek': { const k = 1 + Math.max(0, pf) * 0.35; set(e, 'd', toD(ellS(q.ox + q.side * Math.max(0, pf) * 1.2, q.oy - clamp(P.smile, 0, 1) * 0.6, q.rx * k, q.ry * k, 0, 8), face)); set(e, 'opacity', r2(clamp((q.op ? +q.op : 0.5) + clamp(P.blush, 0, 1) * 0.45 + Math.max(0, pf) * 0.25 + clamp(P.red, 0, 1) * 0.3, 0, 1) * zc(q.ox, q.oy))); break; }
        case 'top': { const o = q.owner || q, a = (o.side < 0 ? -P.earL : o.side > 0 ? P.earR : (P.earR - P.earL) * 0.5) * D2R, B = bend(q, a);
          const tF = (x, y, i, dz) => { const p = B(x, y, i); return sph(p[0], p[1], (inHeadPt(g, p[0], p[1]) ? zmS(p[0], p[1]) : 0) + (dz || 0)); }; if (q.pz) puff(q, tF, cyh * cp); else set(e, 'd', mapSeg(q.segs, tF)); if (I.zfx) { if (q.tipI == null) { const P0 = pts(q.segs); q.tipI = P0.reduce((m, p, i) => p[1] < P0[m][1] ? i : m, 0); q.tipP = P0[q.tipI]; } q.tipW = tF(q.tipP[0], q.tipP[1], q.tipI, 0); } break; }
        case 'side': { const a = q.limb ? ((q.side < 0 ? P.armL : -P.armR) * 0.75 + (q.side < 0 ? 1 : -1) * Math.max(0, -(q.side < 0 ? P.hLy : P.hRy)) * 1.6) * D2R : (q.side > 0 ? 1 : -1) * (P.wag * 0.6 + (q.side > 0 ? P.curl : -P.curl) * -18) * D2R, B = bend(q, a);
          if (q.limb) { const P0 = pts(q.segs), far = P0.reduce((m, p) => Math.hypot(p[0] - q.R[0], p[1] - q.R[1]) > Math.hypot(m[0] - q.R[0], m[1] - q.R[1]) ? p : m, q.R), fi = P0.indexOf(far), tp = B(far[0], far[1], fi); W[q.side < 0 ? 'pawL' : 'pawR'] = byw(tp[0], tp[1], 4); } set(e, 'd', mapSeg(q.segs, (x, y, i) => { const p = B(x, y, i); return byw(p[0], p[1], -7); })); break; }
        case 'earP': case 'earF': { const fl = q.role === 'earF', side = q.side, a = (fl ? (side < 0 ? P.earL : -P.earR) * 0.9 : (side < 0 ? -P.earL : P.earR)) * D2R, [px, py] = q.pivot, S2 = q.S, out = [], lim = SR * SR * 0.81;
          const bnd = (x, y, w) => { const vx = x - px, vy = y - py, c = Math.cos(a * w), s = Math.sin(a * w); return [px + vx * c - vy * s, py + vx * s + vy * c]; };
          for (const sc of S2.secs) { const w = Math.pow(sc.s, 1.3), c = Math.cos(a * w), s = Math.sin(a * w), nx = S2.nx * c - S2.ny * s, ny = S2.nx * s + S2.ny * c, [cx, cy] = bnd(sc.cx, sc.cy, w);
            for (let k2 = 0; k2 < 12; k2++) { const f = k2 / 12 * TAU, cf = Math.cos(f), X = cx + nx * sc.hw * cf, Y = cy + ny * sc.hw * cf, Z = zmS(X, Y) - sc.hd * 0.15 + sc.hd * Math.sin(f) * (fl ? 0.7 : 1), dx = X - HX, dy = Y - HY; if (fl || dx * dx + dy * dy + Z * Z >= lim) out.push(sph(X, Y, Z)); } }
          const hd = H.closedD(H.hull(out)); set(e, 'd', hd); if (q.clipEl) set(q.clipEl, 'd', hd); q._bnd = bnd; q._a = a; break; }
        case 'inner': { const o = q.owner; if (!o || !o._bnd) { set(e, 'd', toD(q.segs, face)); break; } const [px, py] = o.pivot; set(e, 'd', toD(q.segs, (x, y) => { const s0 = clamp(((x - px) * o.ux + (y - py) * o.uy) / o.S.amax, 0, 1), p = o._bnd(x, y, Math.pow(s0, 1.3)); return sph(p[0], p[1], zmS(p[0], p[1]) + 2.5); })); set(e, 'opacity', r2((q.op ? +q.op : 1) * SM(cyh * cp * 3))); break; }
        case 'tail': { const sd = q.side > 0 ? 1 : -1, a = sd * (P.wag * 1.1 - P.curl * 26) * D2R, B = bend(q, a); const tz = I.whole ? -11 : -9, tF = (x, y, i, dz) => { const p = B(x, y, i); return byw(p[0], p[1], tz + (dz || 0)); }; if (q.pz) puff(q, tF, cyb); else set(e, 'd', mapSeg(q.segs, tF)); break; }
        case 'mane': { const k = 1 + clamp(P.wide, 0, 1) * 0.1 + Math.max(0, sq) * 0.06, rp = 0.03 + clamp(P.wide, 0, 1) * 0.05, tt = now / 260; set(e, 'd', toD(q.segs, (x, y) => { const dx = x - HX, dy = y - HY, rr = Math.hypot(dx, dy) || 1, th = Math.atan2(dy, dx), m = k * (1 + rp * Math.sin(th * 7 - tt)) + (I.ed || 0) * 0.004 * Math.cos(th); return headT(HX + dx * m, HY + dy * m); })); break; }
        case 'pad': { const f = q.owner; if (!f) { set(e, 'd', toD(q.segs, glob)); break; } const L = f.ox < 50, st = clamp(+P.sit || 0, 0, 1), lift = (L ? P.footL : P.footR) - st * 4.6, X = 50 + (f.ox - 50) * (1 + st * 0.3) * cyb + (7 + st * 7) * syb, pk = 1 + st * 0.75, sh = (L ? 1 : -1) * st * 0.28; set(e, 'd', toD(q.segs, (x, y) => glob(X + (x - f.ox - sh * (y - f.oy)) * cyb, f.oy + (y - f.oy) * pk - lift))); set(e, 'opacity', r2(SM(cyb * 3))); break; }
        case 'swing': { const ang = (-(I.ed || 0) * 5 + Math.sin(now / 380) * 3 + P.lean * 1.5) * D2R, [px, py] = q.piv, c = Math.cos(ang), s = Math.sin(ang); set(e, 'd', toD(q.segs, (x, y) => { const vx = x - px, vy = y - py; return glob(px + vx * c - vy * s, py + vx * s + vy * c); })); break; }
        case 'crown': { const ang = ((P.earR - P.earL) * 0.25 - (I.ed || 0) * 2.5 + P.htilt * 0.3) * D2R, [bx, by] = q.base, c = Math.cos(ang), s = Math.sin(ang); set(e, 'd', toD(q.segs, (x, y) => { const vx = x - bx, vy = y - by; return sph(bx + vx * c - vy * s, by + vx * s + vy * c + Math.min(0, sq) * 2, -3); })); break; }
        case 'pup': case 'pupEye': { const bob = Math.sin(now / 520) * 0.7 - (I.ld || 0) * 0.25, pc = I.pupC || [50, 70], bl = q.role === 'pupEye' && (now % 3400) < 150 ? 0.12 : 1;
          set(e, 'd', toD(q.segs, (x, y) => glob(x + Math.sin(now / 700) * 0.4, (q.role === 'pupEye' ? q.cy + (y - q.cy) * bl : y) + bob))); break; }
        case 'foot': { const L = q.ox < 50, st = clamp(+P.sit || 0, 0, 1), cy0 = q.oy - (L ? P.footL : P.footR) + st * 4.6, z = 6 + st * 7, X = 50 + (q.ox - 50) * (1 + st * 0.3) * cyb + z * syb, ry = q.ry * (1 + st * 0.75); set(e, 'd', toD(ellAx(X, cy0, [[q.rx * (1 + st * 0.08) * cyb, 0], [(L ? 1 : -1) * st * ry * 0.28 * cyb, ry], [q.rx * 0.9 * syb, 0]]), glob));
          if (q.gl) { set(q.gl, 'd', toD(ellAx(X - q.rx * 0.32 * Math.abs(cyb), cy0 - q.ry * 0.42, [[q.rx * 0.36, 0], [0, q.ry * 0.26]]), glob)); set(q.gl, 'opacity', 0.45); set(q.rim, 'd', e.getAttribute('d')); set(q.rim, 'opacity', 0.35); } break; }
      }
    }
    if (I.wh) W.spout = sph(50, 20, 3); if (I.av && I.av.pc) W.pit = I.av.pc; if (I.wh && I.wh.fin && I.wh.fin.nw && I.wh.fin.nw.tp) W.horn = I.wh.fin.nw.tp;
    if (headD) { set(I.headClip, 'd', headD); I.items.forEach(q => { if (q.role === 'headDup') set(q.e, 'd', headD); }); }
    // paws: reach anywhere (offsets remapped from Mittens' proportions), stay round, linked to the shoulder by a soft tube
    const arms = I.items.filter(q => q.role === 'arm'); const ed = I.ed || 0;
    const mitArm = a => { const Lf = a.side < 0, av = Lf ? P.armL : P.armR, wr = I.pn || I.av || I.br || I.bk || I.lm || I.kw || I.pe || I.pt || I.tu || I.hn || I.gb || I.px ? 0 : SM(Math.abs(av) / 45), ang = ((Lf ? P.armL : -P.armR) + ((Lf ? 20 : -20) - (a.rot || 0)) * wr) * D2R, c = Math.cos(ang), s = Math.sin(ang), px = a.hx, py = a.hy, [ox, oy] = I.mapHand(Lf ? P.hLx : -P.hRx, Lf ? P.hLy : P.hRy), hz = Lf ? P.hLz : P.hRz;
      const vx = a.ox - px, vy = a.oy - py, rk = 1 + I.armReach * SM((av - 60) / 80); let cx = px + (vx * c - vy * s) * rk + (Lf ? ox : -ox) + ed * 0.35 + a.side * (I.armOut != null ? I.armOut : 7) * wr, cy = py + (vx * s + vy * c) * rk + oy; let z = 9 + hz + Math.max(0, -oy) * 0.25;
      // Pina: paws work like Mittens' - they hinge at the shoulder and swing in front of the body (never round the back), riding on the front of the round body as he turns
      if (I.pn || I.av || I.br || I.bk || I.lm || I.kw || I.pe || I.pt || I.tu || I.hn || I.gb || I.px) { const RV = I.pn || I.av || I.br || I.bk || I.lm || I.kw || I.pe || I.pt || I.tu || I.hn || I.gb || I.px, ra = clamp(av, 0, 180) * D2R; cx -= a.side * (I.av || I.br || I.bk || I.lm || I.kw || I.pe || I.pt || I.tu || I.hn || I.gb || I.px ? -3.5 : 7.5) * Math.sin(ra) * (1 - 0.5 * SM((av - 120) / 50)); cy += (I.av || I.br || I.bk || I.lm || I.kw || I.pe || I.pt || I.tu || I.hn || I.gb || I.px ? -2 : 2.5) * Math.sin(ra); const dx = clamp(Math.abs(cx - 50), 0, RV.rx || 24), r = RV.rT(clamp(cy, RV.ya || 34, RV.yb || 90)); z = (RV.zAt ? RV.zAt(cx, cy) : Math.sqrt(Math.max(0, r * r - dx * dx))) + 5 + hz + Math.max(0, -oy) * 0.2; }
      // Melo: paws hinge at the rind edge (middle of the slab's thickness) and come forward onto the flesh face as they swing in
      if (I.mo) { const e = SM((I.mo.hw(cy) - Math.abs(cx - 50) - 1) / 8); z = (I.mo.Dh + 3) * e + hz + Math.max(0, -oy) * 0.2; }
      let mk2 = 0; if (I.mReach) { mk2 = SM(I.pEw || 0); if (mk2 > 0) { cx += (MO.x + a.side * 7.5 - cx) * mk2; cy += (MO.y + 14 - 5 * (I.pEu || 0) - cy) * mk2; } }
      if (I.ck) cx -= a.side * Math.max(0, sq) * 8; // Choco: squash widens the bar, paws stay hugging its sides
      if (I.avoidHead) { const dx = cx - HX, dy = cy - HY, d = Math.hypot(dx, dy) || 1, m = g.HR + a.rx * 0.5; if (d < m) { cx = HX + dx / d * m; cy = HY + dy / d * m; } }
      const sx = px - a.side * 1.2, sy0 = py + 1.5, ddx = cx - sx, ddy = cy - sy0, len = Math.hypot(ddx, ddy), rest = Math.hypot(vx + a.side * 1.2, vy - 1.5);
      let r0 = (a.rot || 0) * D2R + ang; if (len > rest + 1) { const want = Math.atan2(ddy, ddx) - Math.PI / 2; let df = want - r0; df = ((df % TAU) + TAU * 1.5) % TAU - Math.PI; r0 += df * SM((len - rest - 1) / 8); }
      if (mk2 > 0) { const w0 = Math.atan2(cy - sy0, cx - sx) - Math.PI / 2; let df = w0 - r0; df = ((df % TAU) + TAU * 1.5) % TAU - Math.PI; r0 += df * mk2; z += mk2 * 20; }
      const c0 = Math.cos(r0), s0 = Math.sin(r0), ax = [[a.rx * c0, a.rx * s0, 0], [-a.ry * s0, a.ry * c0, 0], [0, 0, a.rx * 1.05]].map(([x, y, zz]) => [x * cyb + zz * syb, y]);
      const PX = 50 + (cx - 50) * cyb + (z - ZC) * syb, Pw = glob(PX, cy), zv = bywZ(cx, z), zH = I.ck || I.fnB || I.pn || I.av || I.br || I.bk || I.lm || I.kw || I.pe || I.pt || I.tu || I.hn || I.gb || I.px || I.mo ? -1e9 : -3; set(a.e, 'd', toD(ellAx(PX, cy, ax), glob)); set(a.e, 'opacity', zv < zH ? 0 : 1); a._zv = zv; if (a.hnd) { const hk = 0.84, hr = a.hR || 3.4; set(a.hnd, 'd', toD(ellAx(PX + ax[1][0] * hk, cy + ax[1][1] * hk, [[hr, 0], [0, hr]]), glob)); set(a.hnd, 'opacity', zv < zH ? 0 : 1); }
      const tb = I.tubes[Lf ? 0 : 1];
      // Choco: a paw that swings round the back stays visible beside the bar, drawn behind it
      if (I.ck || I.fnB || I.av || I.br || I.bk || I.lm || I.kw || I.pe || I.pt || I.tu || I.hn || I.gb || I.px || I.mo) { const C = I.ck || I.fnB || I.av || I.br || I.bk || I.lm || I.kw || I.pe || I.pt || I.tu || I.hn || I.gb || I.px || I.mo, bk = zv < 0; if (!C.armF) { C.armF = a.e.parentNode; C.armB = document.createElementNS('http://www.w3.org/2000/svg', 'g'); const fl = C.armF.getAttribute('filter'); if (fl) C.armB.setAttribute('filter', fl); C.bodyG.parentNode.insertBefore(C.armB, C.bodyG); }
        if (a._bk !== bk) { a._bk = bk; const tg = bk ? C.armB : C.armF; if (tb) tg.insertBefore(tb, tg.firstChild); tg.appendChild(a.e); if (a.rim) tg.appendChild(a.rim); if (a.gl) tg.appendChild(a.gl); if (a.hnd) tg.appendChild(a.hnd); }
        if (a.gl) { const k = 0.34, gx = PX - a.rx * 0.32, gy = cy - a.ry * 0.38; set(a.gl, 'd', toD(ellAx(gx, gy, ax.map(v => [v[0] * k, v[1] * k * 0.8])), glob)); set(a.gl, 'opacity', 0.42); set(a.rim, 'd', a.e.getAttribute('d')); set(a.rim, 'opacity', 0.35); } }
      if (tb) { const Sw = byw(sx, sy0, 4), mx = (Sw[0] + Pw[0]) / 2, my = (Sw[1] + Pw[1]) / 2, tx = Pw[0] - Sw[0], ty = Pw[1] - Sw[1], tl = Math.hypot(tx, ty) || 1; let nx = -ty / tl, ny = tx / tl; if (nx * a.side < 0) { nx = -nx; ny = -ny; }
        const bu = Math.max(0, tl - rest - 2) * 0.18, gw = SM((len - rest - 0.5) / 5); set(tb, 'd', 'M' + r2(Sw[0]) + ' ' + r2(Sw[1]) + ' Q' + r2(mx + nx * bu) + ' ' + r2(my + ny * bu) + ' ' + r2(Pw[0]) + ' ' + r2(Pw[1])); set(tb, 'stroke-width', r2(a.rx * 1.6 * Math.sqrt((1 + sq * 0.4) * sy) * gw)); set(tb, 'opacity', zv < zH || gw < 0.02 ? 0 : 1); }
      W[Lf ? 'pawL' : 'pawR'] = Pw; };
    // Pearl: real narwhal flippers. Short round 3D paddles rooted on the lower sides of his body (the root stays buried in the body); they paddle all the time, lift out/up to about the horizontal when he waves or cheers,
    // sweep forward and in to hold food under his mouth; the far flipper is drawn behind the body when he turns
    const nwArm = a => { const Lf = a.side < 0, sd = Lf ? -1 : 1, av = Lf ? P.armL : P.armR, ts2 = now / 1000, ew = SM(I.pEw || 0), eu = I.pEu || 0, V = (p, q, k) => [p[0] + q[0] * k, p[1] + q[1] * k, p[2] + q[2] * k], NRM = v => { const l = Math.hypot(v[0], v[1], v[2]) || 1; return [v[0] / l, v[1] / l, v[2] / l]; }, CRS = (p, q) => [p[1] * q[2] - p[2] * q[1], p[2] * q[0] - p[0] * q[2], p[0] * q[1] - p[1] * q[0]];
      const [hx, hy] = I.mapHand(Lf ? P.hLx : -P.hRx, Lf ? P.hLy : P.hRy), reach = clamp(Math.hypot(hx, hy) / 16, 0, 1) * (1 - ew), fl = clamp(av * 0.62, -22, 92) + Math.sin(ts2 * 2.2 + sd * 1.3) * 6 + clamp(+P.fflap || 0, -1, 1.6) * 34, th = Math.atan2(0.64, sd * 0.77) - sd * fl * D2R;
      let d = NRM([Math.cos(th) * 0.98, Math.sin(th) * 0.98, -0.12 + Math.sin(ts2 * 1.7 + sd) * 0.06]); const fw = Math.max(ew, reach * 0.6, clamp(+P.fclap || 0, 0, 1)); if (fw > 0) d = NRM(V(V(d, d, -fw), NRM([-sd * 0.58, 0.18 - 0.5 * eu * ew, 0.8]), fw));
      const R0 = [50 + sd * 29, 70.5 - sq * 2, 9], L = 15.5 * (1 + 0.42 * ew + 0.15 * fw * (1 - ew)), wv0 = CRS(d, [0, 0, 1]), wv = Math.hypot(wv0[0], wv0[1], wv0[2]) > 0.2 ? NRM(wv0) : NRM(CRS(d, [0, 1, 0])), tv = NRM(CRS(wv, d));
      const CP = s => V(V(R0, d, L * s), tv, -L * 0.1 * s * s), RG = []; for (let i = 0; i <= 14; i++) { const s = i / 14, e = Math.sqrt(Math.max(0, 1 - Math.pow((s - 0.42) / 0.6, 2))), w = 4.8 * e + 0.25, tk = 1.05 + 1.05 * e, c = CP(s), o = []; for (let k = 0; k < 16; k++) { const f = k / 16 * TAU; o.push(sph(...V(V(c, wv, w * Math.cos(f)), tv, tk * Math.sin(f)))); } RG.push(o); }
      RG.push([sph(...V(CP(1), d, 0.9))]); let fd = ''; for (let i = 0; i < RG.length - 1; i++) fd += H.closedD(H.hull(RG[i].concat(RG[i + 1]))); set(a.e, 'd', fd); set(a.e, 'opacity', 1);
      const mid = V(R0, d, L * 0.55), zv = sphZ(mid[0], mid[1], mid[2]) - sphZ(50, 62, -4), bk = zv < -2, C = I.fnB; a._zv = bk ? -5 : 5;
      if (C) { if (!C.armF) { C.armF = a.e.parentNode; C.armB = document.createElementNS('http://www.w3.org/2000/svg', 'g'); const flt = C.armF.getAttribute('filter'); if (flt) C.armB.setAttribute('filter', flt); C.bodyG.parentNode.insertBefore(C.armB, C.bodyG); }
        if (a._bk !== bk) { a._bk = bk; (bk ? C.armB : C.armF).appendChild(a.e); } }
      const tb = I.tubes[Lf ? 0 : 1]; if (tb) set(tb, 'opacity', 0);
      W[Lf ? 'pawL' : 'pawR'] = sph(...V(R0, d, L * 0.9)); };
    const mmR = I.mm ? 1 - (I.mm.pw == null ? 1 : I.mm.pw) : 0; // Marina: arms cup the pearl only in idle; otherwise they rest down at her sides like regular arms
    arms.forEach(a => { if (I.nwF) return nwArm(a); if (I.armStr) return mitArm(a); const Lf = a.side < 0, ang = ((Lf ? P.armL : -P.armR) + mmR * (Lf ? 72 : -72)) * D2R, c = Math.cos(ang), s = Math.sin(ang), px = a.hx, py = a.hy, [ox, oy] = I.mapHand(Lf ? P.hLx : -P.hRx, Lf ? P.hLy : P.hRy), hz = Lf ? P.hLz : P.hRz;
      const vx = a.ox - px, vy = a.oy - py, cx = px + vx * c - vy * s + (Lf ? ox : -ox) + ed * 0.35, cy = py + vx * s + vy * c + oy, z = 9 + hz + Math.max(0, -oy) * 0.25, ddx = cx - px, ddy = cy - py, len = Math.hypot(ddx, ddy);
      let r0 = (a.rot || 0) * D2R + ang; if (len > 9) { const want = Math.atan2(ddy, ddx) - Math.PI / 2; let df = want - r0; df = ((df % TAU) + TAU * 1.5) % TAU - Math.PI; r0 += df * SM((len - 9) / 8); }
      const c0 = Math.cos(r0), s0 = Math.sin(r0), ax = [[a.rx * c0, a.rx * s0, 0], [-a.ry * s0, a.ry * c0, 0], [0, 0, a.rx * 1.05]].map(([x, y, zz]) => [x * cyb + zz * syb, y]);
      const PX = 50 + (cx - 50) * cyb + (z - ZC) * syb, Pw = glob(PX, cy), zv = bywZ(cx, z); set(a.e, 'd', toD(ellAx(PX, cy, ax), glob)); set(a.e, 'opacity', zv < -3 ? 0 : 1); a._zv = zv;
      I.items.forEach(hq => { if (hq.role === 'hand' && hq.owner === a) { const hvx = hq.ox - px, hvy = hq.oy - py, hx = px + hvx * c - hvy * s + (cx - (px + vx * c - vy * s)), hy2 = py + hvx * s + hvy * c + (cy - (py + vx * s + vy * c)); set(hq.e, 'd', toD(ellAx(50 + (hx - 50) * cyb + z * syb, hy2, [[hq.rx, 0], [0, hq.ry]]), glob)); set(hq.e, 'opacity', zv < -3 ? 0 : 1); } });
      const tb = I.tubes[Lf ? 0 : 1]; if (tb) { const Sw = byw(px - a.side * 1.2, py + 1.5, 4), mx = (Sw[0] + Pw[0]) / 2, my = (Sw[1] + Pw[1]) / 2, tx = Pw[0] - Sw[0], ty = Pw[1] - Sw[1], tl = Math.hypot(tx, ty) || 1; let nx = -ty / tl, ny = tx / tl; if (nx * a.side < 0) { nx = -nx; ny = -ny; }
        const bu = Math.max(0, tl - 10) * 0.18; set(tb, 'd', 'M' + r2(Sw[0]) + ' ' + r2(Sw[1]) + ' Q' + r2(mx + nx * bu) + ' ' + r2(my + ny * bu) + ' ' + r2(Pw[0]) + ' ' + r2(Pw[1])); set(tb, 'stroke-width', r2(a.rx * 1.6 * Math.sqrt((1 + sq * 0.4) * sy))); set(tb, 'opacity', r2(zv < -3 ? 0 : SM((len - 7.5) / 5))); }
      W[Lf ? 'pawL' : 'pawR'] = Pw; });
    ['L', 'R'].forEach(sd => { if (W['paw' + sd]) return; const s = sd === 'L' ? -1 : 1, [ox, oy] = I.mapHand(sd === 'L' ? P.hLx : -P.hRx, sd === 'L' ? P.hLy : P.hRy); W['paw' + sd] = glob(50 + s * Math.abs(50 - g.pawX) + (sd === 'L' ? ox : -ox), g.pawY + oy); });
    // Marina (mermaid): one-piece 3D hair, round torso + shell top, tapered fish tail with scales and a fluke (swings, curls, undulates); the pearl only in idle
    if (I.mm) { const M = I.mm, ts = now / 1000, nm = (I.cur && I.cur.name) || '', NRM = v => { const l = Math.hypot(v[0], v[1], v[2]) || 1; return [v[0] / l, v[1] / l, v[2] / l]; }, CR = (a, b) => [a[1] * b[2] - a[2] * b[1], a[2] * b[0] - a[0] * b[2], a[0] * b[1] - a[1] * b[0]], PL = a => H.closedD(H.hull(a)), PG = a => 'M' + H.hull(a).map(p => r2(p[0]) + ' ' + r2(p[1])).join('L') + 'Z';
      const tg = P.x + P.tilt * 0.45 + P.lean * 1.3 + P.turn * 12, ly = P.lift - sq * 6;
      if (M.p == null) { M.p = tg; M.v = 0; M.l = ly; M.lv = 0; M.spn = P.spin; M.flr = 0; M.pw = nm === 'idle' || nm === 'idle@marina' ? 1 : 0; }
      M.v += ((tg - M.p) * 90 - M.v * 8) * dtS; M.p += M.v * dtS; M.lv += ((ly - M.l) * 90 - M.lv * 7) * dtS; M.l += M.lv * dtS;
      let dsp = P.spin - M.spn; dsp = ((dsp % 360) + 540) % 360 - 180; M.spn = P.spin; M.flr += (clamp(Math.abs(dsp) / Math.max(dtS, 0.004) / 520, 0, 1) - M.flr) * Math.min(1, dtS * 5);
      const ox = clamp(M.p - tg, -10, 10), oy = clamp(M.l - ly, -7, 7), fl = M.flr, hfl = clamp(+P.hfl || 0, -1.6, 1.6), sw0 = Math.sin(ts * 1.3) * 0.7, hw = y => SM((y - 34) / 38);
      const YH = M.YH, RH = M.RH, NYh = YH.length, hem = th => 71 + 1.5 * Math.sin(th * 7 + 0.6);
      const wr = a => Math.abs(((a % TAU) + TAU * 1.5) % TAU - Math.PI), RHt = (th, j) => { const y = YH[j]; if (y > 58) return RH[j]; const hr = Math.sqrt(Math.max(0, SR * SR - (y - HY) * (y - HY))) + 1; return lerp(Math.min(hr, RH[j]), RH[j], SM((wr(th) - 0.35) / 1.4)); };
      const HP = (th, j, dr) => { const y0 = j === NYh - 1 ? hem(th) : YH[j], w = hw(y0), r = RHt(th, j) * (1 + fl * 0.22 * w) + (dr || 0); return [50 + Math.sin(th) * r + (ox * 0.9 + sw0 + hfl * 4) * w, y0 - oy * 0.5 * w - (fl * 4 + Math.abs(hfl) * 1.5) * w * w, Math.cos(th) * r * 0.94]; };
      let dB = '', dF = '', x0 = 1e9, y0 = 1e9, x1 = -1e9, y1 = -1e9;
      const acc = (p3, thr, bb) => { let zs = 0; const s2 = p3.map(p => { zs += sphZ(p[0], p[1], p[2]); const s = sph(p[0], p[1], p[2]); if (bb) { if (s[0] < x0) x0 = s[0]; if (s[0] > x1) x1 = s[0]; if (s[1] < y0) y0 = s[1]; if (s[1] > y1) y1 = s[1]; } return s; }); const d = PG(s2); if (zs / p3.length > thr) dF += d; else dB += d; };
      const NL = 15, TA = 72 * D2R, TB = 288 * D2R, pad = 0.03;
      for (let i = 0; i < NL; i++) { const a = TA + (TB - TA) * i / NL - pad, b = TA + (TB - TA) * (i + 1) / NL + pad, m = (a + b) / 2;
        for (let j = 0; j < NYh - 1; j++) { if (YH[j] > 56 && wr(m) < 1.47) continue; acc([HP(a, j), HP(m, j), HP(b, j), HP(a, j + 1), HP(m, j + 1), HP(b, j + 1)], 3, 1); } }
      // scalp cap over the crown so the top of her head is never bald when she turns (the fringe covers the front below it)
      for (let i = 0; i < 8; i++) { const a = -TA + 2 * TA * i / 8 - pad, b = -TA + 2 * TA * (i + 1) / 8 + pad, m = (a + b) / 2; for (let j = 0; j < 3; j++) acc([HP(a, j), HP(m, j), HP(b, j), HP(a, j + 1), HP(m, j + 1), HP(b, j + 1)], 3, 1); }
      const ringL = p => { const o = []; for (let k = 0; k < 8; k++) { const f = k / 8 * TAU; o.push([p[0] + Math.cos(f) * p[3], p[1], p[2] + Math.sin(f) * p[3] * 0.8]); } return o; };
      M.LK.forEach(L => { const sd = L.sd, P3 = L.pts.map(([ax, y, z, r]) => { const w = SM((y - 44) / 38); return [50 + sd * ax + (ox * 1.2 + sw0 + Math.sin(ts * 1.6 + sd) * 0.5 + hfl * 5.5) * w + sd * fl * 7 * w, y - oy * 0.6 * w - fl * 3 * w, z + fl * 2 * w, r]; });
        for (let i = 0; i < P3.length - 1; i++) acc(ringL(P3[i]).concat(ringL(P3[i + 1])), 6, 0); });
      let sd2 = ''; [-0.9, -0.55, -0.2, 0.2, 0.55, 0.9].forEach(o => { const th = Math.PI + o * 1.25, p3 = []; for (let j = 3; j < NYh - 1; j++) p3.push(HP(th + Math.sin(j * 0.9 + o * 3) * 0.04, j, 0.35)); if (p3.reduce((s, p) => s + sphZ(p[0], p[1], p[2]), 0) / p3.length < 6) return; sd2 += 'M' + p3.map(p => { const s = sph(p[0], p[1], p[2]); return r2(s[0]) + ' ' + r2(s[1]); }).join('L'); });
      set(M.hB, 'd', dB || 'M0 0Z'); set(M.hF, 'd', dF || 'M0 0Z'); set(M.sF, 'd', sd2 || 'M0 0Z');
      { const bw = x1 - x0, bh = y1 - y0; set(M.hgr, 'cx', r2(x0 + bw * 0.38)); set(M.hgr, 'cy', r2(y0 + bh * 0.3)); set(M.hgr, 'r', r2((bw + bh) * 0.42)); }
      if (M.bang) { set(M.bang.e, 'd', toD(M.bang.segs, (x, y) => { const dx = x - HX, dy = y - HY; return sph(x, y, Math.sqrt(Math.max(0, SR * SR - dx * dx - dy * dy)) + 0.4); })); set(M.bang.e, 'opacity', r2(SM((cyh * cp + 0.45) / 0.3))); }
      if (M.star) { const zS = 11, a = Math.sin(ts * 1.9) * 0.06, k = 1 + Math.sin(ts * 3.1) * 0.04, cx = M.star.cx, cy = M.star.cy, ca = Math.cos(a), sa = Math.sin(a); set(M.star.e, 'd', toD(M.star.segs, (x, y) => { const vx = (x - cx) * k, vy = (y - cy) * k; return sph(cx + vx * ca - vy * sa, cy + vx * sa + vy * ca, zS); })); set(M.star.e, 'opacity', r2(SM((sphZ(cx, cy, zS) + 3) / 5))); }
      // torso: a small round body with a shell top on its front
      const br = 1 + Math.sin(ts * 2.1) * 0.015, TX = 12 * br, TY = 7.5, TZ = 9 * br, TC = 66;
      { const o = []; for (let k = 0; k <= 6; k++) { const v = -1 + 2 * k / 6, rr = Math.sqrt(1 - v * v); for (let m = 0; m < 16; m++) { const f = m / 16 * TAU; o.push(byw(50 + TX * rr * Math.cos(f), TC + TY * v, TZ * rr * Math.sin(f))); } } set(M.torso, 'd', PL(o)); }
      const zT = (x, y) => TZ * Math.sqrt(Math.max(0, 1 - ((x - 50) / TX) * ((x - 50) / TX) - ((y - TC) / TY) * ((y - TC) / TY)));
      M.cups.forEach(c => { const o = []; for (let m = 0; m < 14; m++) { const f = m / 14 * TAU, x = c.x + 3.4 * Math.cos(f), y = 64 + 3.4 * Math.sin(f); o.push(byw(x, y, zT(x, y) + 0.7)); } set(c.e, 'd', PL(o)); set(c.e, 'opacity', r2(SM(bywZ(c.x, zT(c.x, 64) + 0.7) / 3))); });
      // tail: tapered tube along a spine that swings side to side (tsw), curls up behind her (tlf) and undulates (tun); trails behind moves
      const tsw = clamp((+P.tsw || 0) + clamp(+P.wag || 0, -40, 40) / 40, -1.6, 1.6), tlf = clamp((+P.tlf || 0) + clamp(+P.curl || 0, 0, 1.5) * 0.4 + clamp((+P.footL || 0) + (+P.footR || 0), 0, 12) * 0.035, -0.3, 1.5), tun = clamp(+P.tun || 0, 0, 2), NT = 12, dsT = 23 / NT, lagT = clamp(-ox * 0.5, -5, 5), SPN = []; let cy0 = 66, cz0 = 0;
      for (let k = 0; k <= NT; k++) { const s = k / NT; if (k) { const ph = tlf * 2.2 * Math.pow((k - 0.5) / NT, 1.3); cy0 += dsT * Math.cos(ph); cz0 -= dsT * Math.sin(ph); }
        const bx = (tsw * 10 + lagT + tun * 2.4 * Math.sin(ts * 6.5 - s * 3.2) + Math.sin(ts * 1.1) * 0.5) * Math.pow(s, 1.7); SPN.push({ s, C: [50 + bx, cy0, cz0], r: M.rT(s) }); }
      SPN.forEach((n, k) => { const a = SPN[Math.max(0, k - 1)].C, b = SPN[Math.min(NT, k + 1)].C, T = NRM([b[0] - a[0], b[1] - a[1], b[2] - a[2]]), nB = NRM(CR(T, [1, 0, 0])); n.T = T; n.nB = nB; n.nA = NRM(CR(nB, T)); });
      const RP = (n, az, dr) => { const rx = n.r + (dr || 0), rz = n.r * 0.82 + (dr || 0), sa = Math.sin(az), ca = Math.cos(az); return [0, 1, 2].map(i => n.C[i] + n.nA[i] * rx * sa - n.nB[i] * rz * ca); };
      const BW = p => byw(p[0], p[1], p[2]), FR = s => { const f = s * NT, i = Math.min(NT - 1, Math.floor(f)), t = f - i, A = SPN[i], B = SPN[i + 1], L3 = (a, b) => [0, 1, 2].map(j => lerp(a[j], b[j], t)); return { C: L3(A.C, B.C), nA: L3(A.nA, B.nA), nB: L3(A.nB, B.nB), r: lerp(A.r, B.r, t) }; };
      const rings = SPN.map(n => { const o = []; for (let m = 0; m < 16; m++) o.push(BW(RP(n, m / 16 * TAU))); return o; });
      let td = ''; for (let k = 0; k < NT; k++) td += PG(rings[k].concat(rings[k + 1])); set(M.tail, 'd', td); set(M.tsh, 'd', td);
      { let a = 1e9, b = -1e9; rings[4].forEach(p => { if (p[0] < a) a = p[0]; if (p[0] > b) b = p[0]; }); set(M.cgr, 'x1', r2(a)); set(M.cgr, 'x2', r2(b)); }
      let sc = ''; [0.32, 0.47, 0.62].forEach((s, ri) => { const n = FR(s), n2 = FR(s + 0.05), dl = TAU / 32; for (let m = 0; m < 16; m++) { const az = (m + (ri % 2) * 0.5) / 16 * TAU, Mp = RP(n2, az, 0.2), nz = -(Mp[0] - n2.C[0]) * syb + (Mp[2] - n2.C[2]) * cyb; if (nz < n2.r * 0.3) continue;
        const a = BW(RP(n, az - dl, 0.2)), b = BW(Mp), c = BW(RP(n, az + dl, 0.2)); sc += 'M' + r2(a[0]) + ' ' + r2(a[1]) + 'Q' + r2(2 * b[0] - (a[0] + c[0]) / 2) + ' ' + r2(2 * b[1] - (a[1] + c[1]) / 2) + ' ' + r2(c[0]) + ' ' + r2(c[1]); } });
      set(M.scl, 'd', sc);
      // fluke: two thick lobes fanned from the tail end (resting forward on the ground like the art), flaps with the undulation, follows every swing and curl
      const nF = FR(0.86), Tn = SPN[NT].T, fa = (45 + tun * 6 * Math.sin(ts * 6.5 - 3.6) - clamp(tlf, 0, 1.5) * 68) * D2R, Ty = NRM([0, Tn[1], Tn[2]]), nBy = NRM(CR(Ty, [1, 0, 0])), A0 = [0, 1, 2].map(i => Ty[i] * Math.cos(fa) - nBy[i] * Math.sin(fa)), yw = -clamp(Math.atan2(Tn[0], Math.hypot(Tn[1], Tn[2])), -1, 1) * 1.3 * (1 - 0.75 * SM(clamp(tlf, 0, 1.5))), cw = Math.cos(yw), sw = Math.sin(yw), RY = v => [v[0] * cw + v[2] * sw, v[1], -v[0] * sw + v[2] * cw], Bv = RY([1, 0, 0]), Av = RY(A0), Nn = NRM(CR(Bv, Av)), O = nF.C, kv = 1.2;
      const FP = (uu, v, t) => { const th = (1.9 - 0.1 * v) * t + uu * uu * 0.004 + v * v * 0.005; return BW([0, 1, 2].map(i => O[i] + Bv[i] * uu + Av[i] * v * kv + Nn[i] * th)); };
      const qb = (p, c, q, t) => [(1 - t) * (1 - t) * p[0] + 2 * t * (1 - t) * c[0] + t * t * q[0], (1 - t) * (1 - t) * p[1] + 2 * t * (1 - t) * c[1] + t * t * q[1]];
      let fd = '', rb = ''; const vsd = (-Nn[0] * syb + Nn[2] * cyb) >= 0 ? 1 : -1;
      [-1, 1].forEach(sd => { const L2 = []; for (let i = 0; i <= 6; i++) L2.push(qb([-4, 0], [-14, 4], [-22, 12], i / 6)); for (let i = 1; i <= 6; i++) L2.push(qb([-22, 12], [-8, 13], [0, 6], i / 6)); L2.push([0, 0]);
        const pp = []; L2.forEach(([uu, v]) => { pp.push(FP(sd * uu, v, 1)); pp.push(FP(sd * uu, v, -1)); }); fd += PL(pp);
        [[0.4, 1], [0.72, 1], [1, 1], [0.45, 2]].forEach(([t, sg]) => { const e = sg === 1 ? qb([-4, 0], [-14, 4], [-22, 12], t) : qb([-22, 12], [-8, 13], [0, 6], t), a = FP(sd * -1.2, 1.2, vsd * 1.05), b = FP(sd * e[0] * 0.86, e[1] * 0.86, vsd * 1.05); rb += 'M' + r2(a[0]) + ' ' + r2(a[1]) + 'L' + r2(b[0]) + ' ' + r2(b[1]); }); });
      set(M.fl, 'd', fd); set(M.frib, 'd', rb); M.tailW = FP(0, 9, 0);
      { const tz = bywZ(SPN[NT].C[0], SPN[NT].C[2]), mz = bywZ(SPN[NT >> 1].C[0], SPN[NT >> 1].C[2]), bk = M.tbk ? (tz < -1 || mz < -2) : (tz < -3 || mz < -5), fz = bywZ(O[0] + Av[0] * 7, O[2] + Av[2] * 7), front = !bk && fz > tz - 1;
        // tail curled up behind her: the whole tail + fluke go behind her body and the back of her hair
        if (bk !== M.tbk || front !== M.ffr) { M.tbk = bk; M.ffr = front; const ref = bk ? M.hB : M.torso; [M.tail, M.tsh, M.scl].forEach(e => M.par.insertBefore(e, ref)); M.par.insertBefore(M.flG, front ? ref : M.tail); } }
      I.items.forEach(q => { if (q.role === 'arm' && q._zv != null) set(q.e, 'opacity', r2(SM((q._zv + 0.5) / 4))); });
      // pearl: held between her hands only in idle; rides in the lower hand when they part, hides when she faces away
      if (M.pearl) { const tw = nm === 'idle' || nm === 'idle@marina' ? 1 : 0; M.pw += (tw - M.pw) * Math.min(1, dtS * (tw ? 4 : 9)); const pL = W.pawL, pR = W.pawR, vk = M.pw * SM((bywZ(50, 12) + 2) / 4);
        if (pL && pR && vk > 0.01) { const d = Math.hypot(pL[0] - pR[0], pL[1] - pR[1]), cl = 1 - SM((d - 24) / 10), lo = pL[1] > pR[1] ? pL : pR, sl = lo === pL ? 1 : -1, px = lerp(lo[0] + sl * 6, (pL[0] + pR[0]) / 2, cl), py = lerp(lo[1] + 1, (pL[1] + pR[1]) / 2 + 2, cl), rr = 5 * (0.7 + 0.3 * M.pw);
          set(M.pearl.e, 'd', toD(ellS(px, py, rr, rr, 0, 12), (x, y) => [x, y])); set(M.pearl.e, 'opacity', r2(vk)); } else set(M.pearl.e, 'opacity', 0); } }
    // Flicker (ember): dance fire FX - fireball juggle, fire tornado, flame cocoon, burst shockwave, ground ring of fire, phoenix spirit (channels from dance@ember)
    if (I.dl && I.dl.ff) { const D = I.dl, F = D.ff, cvv = k => { const v = +P[k]; return v === v ? v : 0; }, ts = now / 1000, c = D.cen || [50 + P.x, HY], gx = 50 + P.x;
      const sB = ['', '', ''], sF = ['', '', ''], cir = (x, y, r) => 'M' + r2(x - r) + ' ' + r2(y) + 'A' + r2(r) + ' ' + r2(r) + ' 0 1 0 ' + r2(x + r) + ' ' + r2(y) + 'A' + r2(r) + ' ' + r2(r) + ' 0 1 0 ' + r2(x - r) + ' ' + r2(y) + 'Z';
      const fl = (S, bx, by, ux, uy, h, r, ph) => { if (h < 0.4) return; const ul = Math.hypot(ux, uy) || 1; ux /= ul; uy /= ul; const nx = -uy, ny = ux;
        for (let j = 0; j < 3; j++) { const hh = h * (1 - j * 0.3) * (1 + 0.2 * Math.sin(ts * 13 + ph + j) + 0.1 * Math.sin(ts * 23 + ph * 2 + j)), rr = r * (1 - j * 0.28), w = Math.sin(ts * 9 + ph + j * 0.8) * rr * 0.7, Lx = bx + nx * rr, Ly = by + ny * rr, Rx = bx - nx * rr, Ry = by - ny * rr;
          S[j] += 'M' + r2(Lx) + ' ' + r2(Ly) + 'Q' + r2(Lx + ux * hh * 0.55) + ' ' + r2(Ly + uy * hh * 0.55) + ' ' + r2(bx + ux * hh + nx * w) + ' ' + r2(by + uy * hh + ny * w) + 'Q' + r2(Rx + ux * hh * 0.55) + ' ' + r2(Ry + uy * hh * 0.55) + ' ' + r2(Rx) + ' ' + r2(Ry) + 'Q' + r2(bx - ux * rr * 1.4) + ' ' + r2(by - uy * rr * 1.4) + ' ' + r2(Lx) + ' ' + r2(Ly) + 'Z'; } };
      let gB = 0, gBr = 40, gBx = c[0], gBy = c[1], gF = 0, gFr = 9, gFx = c[0], gFy = c[1], ringD = '', ringO = 0;
      const fjo = clamp(cvv('fjo'), 0, 1);
      if (fjo > 0.02) { const fj = Math.max(0, cvv('fj')), k = Math.floor(fj), p = fj - k, sd = k % 2 ? 1 : -1, A = (sd < 0 ? W.pawL : W.pawR) || [c[0] + sd * 26, c[1] + 6], B = (sd < 0 ? W.pawR : W.pawL) || [c[0] - sd * 26, c[1] + 6];
        const x = A[0] + (B[0] - A[0]) * p, y = A[1] - 4 + (B[1] - A[1]) * p - 160 * p * (1 - p), vx = B[0] - A[0], vy = (B[1] - A[1]) - 160 * (1 - 2 * p), r = 3.4 * fjo;
        fl(sF, x, y, -vx, -vy, 10 * fjo, r * 0.85, k * 1.3); for (let j = 0; j < 3; j++) sF[j] += cir(x, y, r * (1 - j * 0.3)); gF = 0.9 * fjo; gFr = 10; gFx = x; gFy = y; }
      const tor = clamp(cvv('ftor'), 0, 1.5);
      if (tor > 0.02) { for (let i = 0; i < 22; i++) { const t = i / 22, a = ts * 8 + i * 1.15, rad = (15 + t * 18) * (0.85 + tor * 0.15), x = gx + Math.cos(a) * rad, y = G - 2 - t * 62 * Math.min(1, tor), z = Math.sin(a);
          fl(z > 0 ? sF : sB, x, y, -Math.sin(a) * 0.5, -1, (8 - t * 3) * tor, 2.4 * (1 - t * 0.3), i); }
        gB = Math.max(gB, 0.8 * Math.min(1, tor)); gBr = 42; }
      const coc = clamp(cvv('fcoc'), 0, 1.5);
      if (coc > 0.02) { for (let i = 0; i < 14; i++) { const a = i / 14 * TAU + Math.sin(ts * 2 + i) * 0.08, ex = Math.sin(a), ey = -Math.cos(a), bx = c[0] + ex * 24, by = c[1] + ey * 22;
          fl(ey < 0.2 ? sF : sB, bx, by, ex * 0.6, ey * 0.6 - 0.8, (9 + 4 * Math.max(0, -ey)) * coc, 3, i * 2); }
        gB = Math.max(gB, Math.min(1, coc)); gBr = 36; }
      const bs = clamp(cvv('fbst'), 0, 1);
      if (bs > 0.005 && bs < 0.995) { const o = Math.sin(Math.PI * bs), R = 14 + bs * 52; ringD += cir(c[0], c[1], R); ringO = Math.max(ringO, o);
        for (let i = 0; i < 12; i++) { const a = i / 12 * TAU + 0.26, ex = Math.cos(a), ey = Math.sin(a), rr = 26 + bs * 30; fl(sF, c[0] + ex * rr, c[1] + ey * rr, ex, ey, 12 * o, 2.6 * o + 0.4, i * 3); }
        gF = Math.max(gF, o); gFr = 30 + bs * 30; gFx = c[0]; gFy = c[1]; }
      const rg = clamp(cvv('fring'), 0, 1.5);
      if (rg > 0.02) { const rx = 38, ry = 9; for (let i = 0; i < 18; i++) { const a = i / 18 * TAU + 0.1; fl(Math.sin(a) > 0 ? sF : sB, gx + Math.cos(a) * rx, G + Math.sin(a) * ry, Math.cos(a) * 0.15, -1, (9 + 3 * Math.sin(ts * 3 + i * 1.7)) * rg, 2.6, i * 2.2); }
        ringD += 'M' + r2(gx - rx) + ' ' + r2(G) + 'A' + rx + ' ' + ry + ' 0 1 0 ' + r2(gx + rx) + ' ' + r2(G) + 'A' + rx + ' ' + ry + ' 0 1 0 ' + r2(gx - rx) + ' ' + r2(G) + 'Z'; ringO = Math.max(ringO, Math.min(1, rg) * 0.8);
        gB = Math.max(gB, Math.min(1, rg) * 0.7); gBr = 46; gBx = gx; gBy = G - 8; }
      const phx = clamp(cvv('fphx'), 0, 1.5);
      if (phx > 0.02) { [-1, 1].forEach(sd => { for (let j = 0; j < 7; j++) { const th = (18 + j * 13) * Math.PI / 180 + Math.sin(ts * 3 + j) * 0.05, ux = sd * Math.sin(th), uy = -Math.cos(th), L = (22 + 16 * Math.sin((j + 0.5) / 7 * Math.PI)) * phx;
            fl(sB, c[0] + sd * 8 + ux * 6, c[1] + 2 + uy * 6, ux, uy, L, 4.2 - j * 0.25, j * 1.9 + sd); } });
        fl(sB, c[0], c[1] - 24, 0, -1, 22 * phx, 5, 7); gB = Math.max(gB, Math.min(1, phx)); gBr = 58; gBx = c[0]; gBy = c[1] - 6; }
      F.B.forEach((e, j) => set(e, 'd', sB[j] || 'M0 0')); F.F.forEach((e, j) => set(e, 'd', sF[j] || 'M0 0'));
      set(F.gB, 'd', gB > 0.01 ? cir(gBx, gBy, gBr * (1 + 0.04 * Math.sin(ts * 11))) : 'M0 0'); set(F.gB, 'opacity', r2(gB));
      set(F.gF, 'd', gF > 0.01 ? cir(gFx, gFy, gFr) : 'M0 0'); set(F.gF, 'opacity', r2(gF * 0.8)); set(F.ring, 'd', ringD || 'M0 0'); set(F.ring, 'opacity', r2(ringO)); }
    if (I.lan && W.pawR) { const L = I.lan, hx = W.pawR[0], hy = W.pawR[1] + 2.4, dt = Math.max(dtS, 1e-3); if (L.px == null) { L.px = hx; L.vx = 0; }
      const vx = (hx - L.px) / dt, ax = clamp((vx - L.vx) / dt, -700, 700); L.px = hx; L.vx = vx; L.w += (-49 * Math.sin(L.th) + ax / 9 * Math.cos(L.th) - 2.4 * L.w) * dtS; L.th = clamp(L.th + L.w * dtS, -1.1, 1.1);
      const ar = I.items.find(q => q.role === 'arm' && q.side > 0); set(L.g, 'transform', 'translate(' + r2(hx) + ' ' + r2(hy) + ') rotate(' + r2(L.th / D2R + Math.sin(now / 900) * 3) + ')'); set(L.g, 'opacity', ar && ar._zv < -3 ? 0 : 1);
      const fl = 0.5 + 0.5 * Math.sin(now / 430) * 0.8 + Math.sin(now / 160) * 0.12; set(L.glow, 'opacity', r2(0.6 + fl * 0.4)); set(L.glow, 'r', r2(9 + fl * 2)); set(L.flame, 'ry', r2(1.7 + fl * 0.4)); }
    if (I.rain) { const Rn = I.rain; if (now >= Rn.next) { const d = Rn.drops.find(x => !x.st); Rn.next = now + 110 + Math.random() * 130; if (d) { const uu = Math.random() * 2 - 1, zz = (Math.random() * 2 - 1) * 14, p = glob(50 + uu * 24 * NS * Math.sign(cyb || 1) + zz * syb * 0.5, 76.5); Object.assign(d, { st: 1, x: p[0], y: p[1], vy: 6, t: 0 }); } }
      Rn.drops.forEach(d => { if (d.st === 1) { d.vy += 75 * dtS; d.y += d.vy * dtS; d.t += dtS; const k = 1, st = 1 + d.vy / 110; set(d.el, 'd', 'M' + r2(d.x) + ' ' + r2(d.y - 1.5 * k * st) + ' Q' + r2(d.x + 1 * k) + ' ' + r2(d.y) + ' ' + r2(d.x + 0.9 * k) + ' ' + r2(d.y + 0.6 * k) + ' A' + r2(0.9 * k) + ' ' + r2(0.9 * k) + ' 0 1 1 ' + r2(d.x - 0.9 * k) + ' ' + r2(d.y + 0.6 * k) + ' Q' + r2(d.x - 1 * k) + ' ' + r2(d.y) + ' ' + r2(d.x) + ' ' + r2(d.y - 1.5 * k * st) + 'Z'); set(d.el, 'opacity', r2(0.9 * Math.min(1, d.t * 8)));
          if (d.y >= G + 0.4) { d.st = 2; d.t = 0; set(d.el, 'opacity', 0); } }
        else if (d.st === 2) { d.t += dtS; const k = clamp(d.t / 0.32, 0, 1); set(d.sp, 'cx', r2(d.x)); set(d.sp, 'cy', r2(G + 0.6)); set(d.sp, 'rx', r2(0.6 + k * 2.4)); set(d.sp, 'ry', r2(0.25 + k * 0.6)); set(d.sp, 'opacity', r2(0.75 * (1 - k))); if (k >= 1) { d.st = 0; set(d.sp, 'opacity', 0); } } }); }
    if (I.rip) { const Rp = I.rip, L = P.lift, bw = g.BB.width;
      if (L > 1.5) { Rp.air = 1; Rp.pk = Math.max(Rp.pk, L); } else if (Rp.air && L < 0.6) { Rp.air = 0; const s = clamp(Rp.pk / 14, 0.4, 1.25), cx = 50 + P.x; [0, 0.16, 0.32].forEach(dl => { const r = Rp.rs.find(z => !z.on); if (r) Object.assign(r, { on: 1, t: -dl, s, x: cx }); }); Object.assign(Rp.pd, { t: 0, s, x: cx }); Rp.pk = 0; }
      Rp.rs.forEach(r => { if (!r.on) return; r.t += dtS; if (r.t < 0) return; const k = r.t / 0.95; if (k >= 1) { r.on = 0; set(r.el, 'opacity', 0); return; } const rx = (bw * 0.3 + k * 26) * r.s;
        set(r.el, 'cx', r2(r.x)); set(r.el, 'cy', r2(G + 0.8)); set(r.el, 'rx', r2(rx)); set(r.el, 'ry', r2(rx * 0.2)); set(r.el, 'stroke-width', r2(0.9 * (1 - k * 0.6))); set(r.el, 'opacity', r2(0.8 * (1 - k) * Math.min(1, r.t * 12))); });
      const pd = Rp.pd; if (pd.t != null) { pd.t += dtS; const k = clamp(pd.t / 1.4, 0, 1), rx = bw * 0.42 * pd.s * (0.8 + 0.4 * SM(k * 3)); set(pd.el, 'cx', r2(pd.x)); set(pd.el, 'cy', r2(G + 0.8)); set(pd.el, 'rx', r2(rx)); set(pd.el, 'ry', r2(rx * 0.2)); set(pd.el, 'opacity', r2(0.4 * (1 - SM(k)))); if (k >= 1) { pd.t = null; set(pd.el, 'opacity', 0); } } }
    if (I.shim) { const S = I.shim, yw = P.spin + P.turn * 40, ph = now / 1600 + yw * D2R * 0.8, h = 200 + Math.sin(ph) * 45; if (S.ir) set(S.ir, 'gradientTransform', 'rotate(' + r2(yw * 0.9 + now / 1000 * 18) + ' 0.5 0.5)'); if (S.s2) set(S.s2, 'stop-color', 'hsl(' + r2(h) + ',100%,87%)'); if (S.s3) set(S.s3, 'stop-color', 'hsl(' + r2(h + 85) + ',100%,88%)'); }
    // face drawn by the rig
    const E = I.E, rd = clamp(P.red, 0, 1), gr = clamp(P.green, 0, 1); set(E.tintR, 'd', headD); set(E.tintR, 'opacity', r2(rd * 0.34)); set(E.tintG, 'd', headD); set(E.tintG, 'opacity', r2(gr * 0.26));
    if (E.bodyG) { if (gr > 0.01) set(E.bodyG, 'd', g.main.q.e.getAttribute('d')); set(E.bodyG, 'opacity', r2(gr * 0.26)); }
    const ox = P.lx * 2.6, oy = P.ly * 2.2, ws = 1 + clamp(P.wide, 0, 1) * 0.22, h = clamp(P.hap, 0, 1), qz = clamp(P.sqz, 0, 1), cr = clamp(P.cross, 0, 1) * 1.8, ty = clamp(P.teary, 0, 1); I.eyeW = [];
    g.EY.forEach((ey, i) => { const Lf = ey.x < (g.EY.length > 1 ? (g.EY[0].x + g.EY[1].x) / 2 : 50) || g.EY.length === 1 && false, dir = Lf ? 1 : -1, c = clamp(Math.max(P.close, Lf ? P.winkL : P.winkR), 0, 1) * (1 - SM(h * 1.6));
      const R0 = (ey.r || 4.6) * 1.08, k = R0 / 5.2, cx = ey.x + ox * k + dir * cr * k, cy = ey.y + oy * k - h * 0.8 * k, r = R0 * ws, o = E.eyes[i], sl = clamp(P.sl, 0, 1) * 0.32, out = Lf ? -1 : 1;
      const eD = toD(ellS(cx, cy, r, r, 0, 8), (x, y) => { const dy = y - cy, ce = clamp(c + sl * (0.5 + 0.5 * out * (x - cx) / r), 0, 1); let X = x, Y = cy + dy * (dy < 0 ? 1 - 2 * ce : 1 - 2 * h);
        if (qz > 0) { const cu = clamp((x - cx) / r, -1, 1), uu = dir > 0 ? (cu + 1) / 2 : (1 - cu) / 2; X = lerp(X, cx + dir * (-0.8 + uu * 1.4) * r, qz); Y = lerp(Y, cy + Math.sign(dy) * (1 - uu) * 0.6 * r, qz); } return face(X, Y); });
      set(o.e, 'd', eD); set(o.clip, 'd', eD); set(o.e, 'stroke-width', r2(1.3 * k * Math.max(SM((c - 0.5) / 0.45), SM((h - 0.5) / 0.45), SM(qz * 1.6))));
      const ha = (1 - SM((c - 0.4) / 0.25)) * (1 - SM((h - 0.12) / 0.3)) * (1 - SM(qz * 2.5)), hk = ws * (1 + ty * 0.4) * k, hd = c * r * 0.7;
      set(o.h1, 'd', toD(ellS(cx - 1.7 * k * ws, cy - 1.9 * k * ws + hd, 1.8 * hk, 1.8 * hk, 0, 6), face)); set(o.h2, 'd', toD(ellS(cx + 1.8 * k * ws, cy + 1.6 * k * ws, 0.7 * hk, 0.7 * hk, 0, 6), face));
      set(o.h1, 'opacity', r2(ha)); set(o.h2, 'opacity', r2(ha * 0.9)); set(o.tp, 'd', toD(ellS(cx, cy + r * 0.8, r, r * 0.42, 0, 8), face)); set(o.tp, 'opacity', r2(ty * 0.85 * (1 - qz) * (1 - SM(c * 1.5))));
      set(o.g, 'opacity', r2(zc(cx, cy))); const w = face(cx, cy); I.eyeW.push(w); W[Lf ? 'eyeL' : 'eyeR'] = w; });
    if (!W.eyeR && W.eyeL) W.eyeR = W.eyeL;
    { const mk0 = (MO.w || 9.6) * 0.36 / 3.5, sm = clamp(P.smile, 0, 1), op = Math.max(clamp(P.open, 0, 1), I.sky ? (I.dj = (I.dj || 0) + ((/dance/.test(I.cur.name) ? 0.55 : 0) - (I.dj || 0)) * Math.min(1, dtS * 5)) : 0), fr = clamp(P.frown, 0, 1), mw = P.mw * (1 + sm * 0.12), hw = 3.5 * mk0 * mw * (1 + op * 0.3), X0 = MO.x, Y0 = MO.y;
      const y0 = Y0 + (-sm * 0.5 + fr * 1.3) * mk0, d = (2.3 * (1 + sm * 0.45) - fr * 4) * (1 - op * 0.55) * mk0, ym = Y0 - fr * 0.2 * mk0;
      const lip = 'M' + r2(X0 - hw) + ' ' + r2(y0) + ' Q' + r2(X0 - hw / 2) + ' ' + r2(y0 + d) + ' ' + r2(X0) + ' ' + r2(ym) + ' Q' + r2(X0 + hw / 2) + ' ' + r2(ym + d) + ' ' + r2(X0 + hw) + ' ' + r2(y0);
      const mv = zc(X0, Y0); set(E.mouth, 'd', toD(parsePath(lip), face)); set(E.mouth, 'opacity', r2(mv)); set(E.mouth, 'stroke-width', r2(1.2 * Math.max(0.8, mk0)));
      if (op > 0.03) { set(E.mopen, 'd', toD(parsePath(lip + ' C' + r2(X0 + hw) + ' ' + r2(y0 + op * 8 * mk0) + ' ' + r2(X0 - hw) + ' ' + r2(y0 + op * 8 * mk0) + ' ' + r2(X0 - hw) + ' ' + r2(y0) + 'Z'), face)); set(E.tongue, 'd', toD(ellS(X0, y0 + op * 4.2 * mk0, 2.3 * op * mw * mk0, 1.4 * op * mk0, 0, 8), face)); set(E.mopen, 'opacity', r2(mv)); set(E.tongue, 'opacity', r2(mv)); }
      else { set(E.mopen, 'opacity', 0); set(E.tongue, 'opacity', 0); }
      const tg = clamp(P.tongue, 0, 1); set(E.tout, 'opacity', r2(mv * SM(tg * 3))); if (tg > 0.02) set(E.tout, 'd', toD(ellS(X0, y0 + (1.3 + tg * 1.9) * mk0, 2.2 * (1 + tg * 0.15) * mk0, (1 + tg * 1.7) * mk0, 0, 8), face));
      if (I.wh && I.wh.fin && !I.wh.fin.seal && !I.wh.fin.nw) { [E.mouth, E.mopen, E.tongue, E.tout].forEach(x => set(x, 'opacity', 0)); I.fnOp = Math.max(op, clamp(P.tongue, 0, 1) * 0.6); }
      // Flicker: his beak is his only mouth and opens like Pip's - upper beak lifts a little, lower beak drops, dark gap between (rig mouth hidden)
      if (I.emk) { [E.mouth, E.mopen, E.tongue, E.tout].forEach(x => set(x, 'opacity', 0)); const K = I.emk, o = clamp(Math.max(op, clamp(P.tongue, 0, 1) * 0.6), 0, 1), BF = (x, y) => { y += K.dy || 0; const dx = x - 50, dy = y - 61.6, w = clamp(1 - (dx / 4.6) * (dx / 4.6) - (dy / 4.4) * (dy / 4.4), 0, 1); return sph(x, y, (I.zE ? I.zE(dx, y - HY) : sz(x - HX, y - HY)) + 2.2 * Math.sqrt(w)); }, D = s => toD(parsePath(s), BF), bv = r2(mv);
        set(K.up, 'd', D('M46.6 60.2 Q50 58.4 53.4 60.2 Q51.7 ' + r2(63.2 - o * 1.2) + ' 50 ' + r2(64.2 - o * 1.6) + ' Q48.3 ' + r2(63.2 - o * 1.2) + ' 46.6 60.2Z'));
        set(K.lo, 'd', D('M47.2 60.9 Q50 ' + r2(62.4 + o * 5) + ' 52.8 60.9 Q51.3 ' + r2(63.8 + o * 4.2) + ' 50 ' + r2(64.5 + o * 5) + ' Q48.7 ' + r2(63.8 + o * 4.2) + ' 47.2 60.9Z'));
        set(K.in, 'd', D('M47 60.8 Q50 61.4 53 60.8 Q50 ' + r2(63 + o * 6) + ' 47 60.8Z')); set(K.hl, 'd', toD(ellS(48.6, 59.9, 1.1, 0.4, -10, 6), BF));
        set(K.up, 'opacity', bv); set(K.lo, 'opacity', bv); set(K.hl, 'opacity', r2(0.55 * mv)); set(K.in, 'opacity', r2(mv * SM(o * 6))); }
      if (I.pq) { [E.mouth, E.mopen, E.tongue, E.tout].forEach(x => set(x, 'opacity', 0)); const K = I.pq.bk, o = clamp(op, 0, 1), BF = (x, y) => { const dx = x - 50, w = clamp(1 - (dx / 4.8) * (dx / 4.8), 0, 1) * clamp(1 - Math.abs(y - 54.5) / 5, 0, 1); return sph(x, y, I.zE(dx, y - HY) + 2.6 * w); }, D = s => toD(parsePath(s), BF), bv = r2(mv);
        set(K.up, 'd', D('M45.5 54 Q50 50.6 54.5 54 Q50 ' + r2(55.4 - o * 0.5) + ' 45.5 54Z')); set(K.lo, 'd', D('M45.9 54.2 Q50 ' + r2(55.5 + o * 3.4) + ' 54.1 54.2 Q50 ' + r2(58.6 + o * 4.6) + ' 45.9 54.2Z'));
        set(K.in, 'd', D('M45.8 54.1 Q50 ' + r2(55.2 - o * 0.5) + ' 54.2 54.1 Q50 ' + r2(55.7 + o * 3.4) + ' 45.8 54.1Z')); set(K.hl, 'd', toD(ellS(48.4, 52.5, 1.7, 0.6, -14, 6), BF));
        set(K.up, 'opacity', bv); set(K.lo, 'opacity', bv); set(K.hl, 'opacity', r2(0.6 * mv)); set(K.in, 'opacity', r2(mv * SM(o * 6))); }
      if (I.pfm) { [E.mouth, E.mopen, E.tongue, E.tout].forEach(x => set(x, 'opacity', 0)); const K = I.pfm, o = clamp(Math.max(op, clamp(P.tongue, 0, 1) * 0.6), 0, 1), BF = (x, y) => { const dx = x - 50, dy = y - 62.4, w = clamp(1 - (dx / 4.2) * (dx / 4.2) - (dy / 3.8) * (dy / 3.8), 0, 1); return sph(x, y, sz(x - HX, y - HY) + 1.8 * Math.sqrt(w)); }, D = s => toD(parsePath(s), BF), bv = r2(mv);
        set(K.up, 'd', D('M46.3 62 Q50 59.3 53.7 62 Q50 ' + r2(63 - o * 0.4) + ' 46.3 62Z')); set(K.lo, 'd', D('M46.7 62.3 Q50 ' + r2(63.1 + o * 2.6) + ' 53.3 62.3 Q50 ' + r2(65.3 + o * 3.6) + ' 46.7 62.3Z'));
        set(K.in, 'd', D('M46.9 62.2 Q50 62.7 53.1 62.2 Q50 ' + r2(63.3 + o * 2.8) + ' 46.9 62.2Z')); set(K.hl, 'd', toD(ellS(48.6, 60.9, 1.2, 0.45, -10, 6), BF));
        set(K.up, 'opacity', bv); set(K.lo, 'opacity', bv); set(K.hl, 'opacity', r2(0.55 * mv)); set(K.in, 'opacity', r2(mv * SM(o * 6))); }
      W.mouth = face(X0, Y0); W.nose = face(X0, Y0 - 3.5); }
    const bb = g.BB, tops = I.items.filter(q => q.role === 'top' && !q.owner);
    W.head = I.topW = headT(HX, g.TOP + 1); W.body = glob(50, (g.HY + G) / 2 + 6); W.belly = glob(50, G - (G - g.HY) * 0.28); W.sideL = glob(bb.x + bb.width * 0.12, G - 14); W.sideR = glob(bb.x + bb.width * 0.88, G - 14);
    ['L', 'R'].forEach(sd => { const t = tops.find(q => q.side === (sd === 'L' ? -1 : 1)); W['ear' + sd] = t ? sph(t.cx, t.b.y + 2, 0) : headT(HX + (sd === 'L' ? -1 : 1) * g.HR * 0.6, g.TOP + 4); });
    const sideT = I.items.find(q => q.role === 'side'); W.tail = sideT ? glob(sideT.cx, sideT.cy) : glob(bb.x + bb.width * 0.9, G - 16); if (I.mm && I.mm.tailW) W.tail = I.mm.tailW;
    if (I.kite) { const K = I.kite, N = K.rest.length, T = K.rest.map(p => byw(p[0], p[1], -7)), ts = now / 1000; if (!K.P) K.P = T.map(p => p.slice()); K.P[0] = T[0].slice();
      for (let i = 1; i < N; i++) { const u = i / (N - 1), dx = T[i][0] - T[i - 1][0], dy = T[i][1] - T[i - 1][1], dl = Math.hypot(dx, dy) || 1, fl = (Math.sin(ts * 5.2 - i * 0.75) * 1.1 + Math.sin(ts * 2.1 - i * 0.4) * 0.6) * u, k = 1 - Math.exp(-dtS * lerp(30, 6, u));
        const p = K.P[i]; p[0] += (T[i][0] - dy / dl * fl - p[0]) * k; p[1] += (T[i][1] + dx / dl * fl - p[1]) * k; }
      for (let i = 1; i < N; i++) { const a = K.P[i - 1], b = K.P[i], dx = b[0] - a[0], dy = b[1] - a[1], d = Math.hypot(dx, dy) || 1, Lr = Math.hypot(T[i][0] - T[i - 1][0], T[i][1] - T[i - 1][1]); b[0] = a[0] + dx / d * Lr; b[1] = a[1] + dy / d * Lr; }
      const Pk = K.P, mp = (a, b) => r2((a[0] + b[0]) / 2) + ' ' + r2((a[1] + b[1]) / 2); let sd = 'M' + r2(Pk[0][0]) + ' ' + r2(Pk[0][1]); for (let i = 1; i < N - 1; i++) sd += ' Q' + r2(Pk[i][0]) + ' ' + r2(Pk[i][1]) + ' ' + mp(Pk[i], Pk[i + 1]); sd += ' L' + r2(Pk[N - 1][0]) + ' ' + r2(Pk[N - 1][1]); set(K.str.e, 'd', sd);
      K.bows.forEach(b => { const j = b.kj, j0 = Math.max(0, j - 1), j1 = Math.min(N - 1, j + 1), ra = Math.atan2(Pk[j1][1] - Pk[j0][1], Pk[j1][0] - Pk[j0][0]) - Math.atan2(T[j1][1] - T[j0][1], T[j1][0] - T[j0][0]), c = Math.cos(ra), s = Math.sin(ra), O = T[j], Q = Pk[j], tw = 0.68 + 0.32 * Math.cos(ts * 6.5 + j);
        set(b.e, 'd', toD(b.segs, (x, y) => { const w = byw(b.cx + (x - b.cx) * tw, y, -7), vx = w[0] - O[0], vy = w[1] - O[1]; return [Q[0] + vx * c - vy * s, Q[1] + vx * s + vy * c]; })); });
      W.tail = Pk[N - 1]; }
    if (!I.star) { const feet = I.items.filter(q => q.role === 'foot'); W.footL = feet[0] ? glob(feet[0].ox, feet[0].oy) : glob(42, G - 3); W.footR = feet[1] ? glob(feet[1].ox, feet[1].oy) : glob(58, G - 3); }
    if (I.zfx) { const Z = I.zfx, zp = clamp(+P.zap || 0, 0, 1), st = Math.floor(now / 60), rn = k => { const v = Math.sin(st * 12.9898 + k * 78.233) * 43758.5453; return v - Math.floor(v); }, C = headT(HX, HY), R0 = I.spk ? I.spk.r1 : g.HR;
      set(Z.mg, 'cx', r2(C[0])); set(Z.mg, 'cy', r2(C[1])); set(Z.au, 'cx', r2(C[0])); set(Z.au, 'cy', r2(C[1])); set(Z.au, 'r', r2(R0 * (1.3 + 0.15 * rn(9)))); set(Z.au, 'opacity', r2(zp * (0.6 + 0.3 * rn(8))));
      const jagP = (A, B, n, amp, bow, k0) => { const dx = B[0] - A[0], dy = B[1] - A[1], L = Math.hypot(dx, dy) || 1, nx = -dy / L, ny = dx / L, o = [A]; for (let i = 1; i < n; i++) { const u = i / n, f = (rn(k0 + i) - 0.5) * 2 * amp + bow * Math.sin(Math.PI * u); o.push([A[0] + dx * u + nx * f, A[1] + dy * u + ny * f]); } o.push(B); return o; };
      const dP = Q => Q.map((p, i) => (i ? 'L' : 'M') + r2(p[0]) + ' ' + r2(p[1])).join('');
      let M = '', S = '';
      const bolt = (A, B, n, amp, bow, k0, br, small) => { const Q = jagP(A, B, n, amp, bow, k0); if (small) S += dP(Q); else M += dP(Q); const base = Math.atan2(B[1] - A[1], B[0] - A[0]);
        for (let b = 0; b < br; b++) { const p = Q[1 + Math.floor(rn(k0 + 50 + b) * (n - 1))], a = base + (rn(k0 + 60 + b) - 0.5) * 2, l = 4 + rn(k0 + 70 + b) * 8; S += dP(jagP(p, [p[0] + Math.cos(a) * l, p[1] + Math.sin(a) * l], 3, 1.3, 0, k0 + 80 + b * 7)); } };
      const eL = I.items.find(q => q.role === 'top' && q.side < 0), eR = I.items.find(q => q.role === 'top' && q.side > 0), A = eL && eL.tipW, B = eR && eR.tipW;
      if (zp > 0.05 && A && B && rn(0) > 0.12) bolt(A, B, 10, 2 + zp * 1.5, -12 - zp * 6, 1, 1 + Math.round(zp * 2));
      const strike = false;
      const hL = W.pawL, hR = W.pawR; if (zp > 0.4 && hL && hR && (hL[1] + hR[1]) / 2 < C[1] + 4 && Math.hypot(hL[0] - hR[0], hL[1] - hR[1]) > 20 && rn(6) > 0.25) bolt(hL, hR, 11, 2.6, (rn(7) > 0.5 ? 1 : -1) * 6, 200, 2);
      if (zp > 0.15) for (let j = 0; j < 6; j++) { if (rn(20 + j) > zp * 0.95) continue; const a = rn(30 + j) * TAU, a1 = a + (rn(35 + j) - 0.5) * 0.6, L1 = R0 + 9 + zp * 9 + rn(38 + j) * 6, p0 = [C[0] + Math.cos(a) * (R0 - 12), C[1] + Math.sin(a) * (R0 - 12)], p1 = [C[0] + Math.cos(a1) * L1, C[1] + Math.sin(a1) * L1]; bolt(p0, p1, 6, 2, 0, 400 + j * 9, 2, j > 2); }
      if (zp > 0.6) ['footL', 'footR'].forEach((k, j) => { const f = W[k]; if (f && rn(45 + j) > 0.45) bolt([f[0], f[1] + 2], [f[0] + (rn(47 + j) - 0.5) * 22, G + 1.5], 4, 1.4, 0, 500 + j * 9, 1, true); });
      Z.M.forEach((p, i) => { if (M) set(p, 'd', M); set(p, 'opacity', M ? r2(i === 1 ? 0.75 : i ? 1 : 0.85) : 0); }); Z.S.forEach((p, i) => { if (S) set(p, 'd', S); set(p, 'opacity', S ? r2(i === 1 ? 0.7 : i ? 1 : 0.8) : 0); });
      set(Z.fl, 'opacity', strike ? r2(0.1 + rn(10) * 0.1) : 0); }
    if (I.hx) heroFX(I, P, now, { W, glob, sph, sphZ, byw, bywZ, face, toD, HX, HY, G, TOP: g.TOP, set, r2, clamp, SM, TAU, E, dtS });
    // Jinni: the golden lamp sits on the ground under him (lags behind his moves on a spring, turns with him a beat late, rocks, rattles while he is inside, glows), the smoky wisp tail
    // runs from its spout up into his chest (swirls, waves, stretches when he rises, twists with gwh), he swirls into the lamp and poofs back out (gin + pokes), sparkles drift up the wisp
    if (I.gn) { const N = I.gn, ts = now / 1000, LC = 45.6, pt = p => r2(p[0]) + ' ' + r2(p[1]), cv = k => { const v = +P[k]; return v === v ? v : 0; };
      const cir = (x, y, r) => 'M' + r2(x - r) + ' ' + r2(y) + 'A' + r2(r) + ' ' + r2(r) + ' 0 1 0 ' + r2(x + r) + ' ' + r2(y) + 'A' + r2(r) + ' ' + r2(r) + ' 0 1 0 ' + r2(x - r) + ' ' + r2(y) + 'Z';
      const ell = (x, y, rx, ry) => 'M' + r2(x - rx) + ' ' + r2(y) + 'A' + r2(rx) + ' ' + r2(ry) + ' 0 1 0 ' + r2(x + rx) + ' ' + r2(y) + 'A' + r2(rx) + ' ' + r2(ry) + ' 0 1 0 ' + r2(x - rx) + ' ' + r2(y) + 'Z';
      const star = (x, y, r) => 'M' + r2(x) + ' ' + r2(y - r) + 'Q' + r2(x) + ' ' + r2(y) + ' ' + r2(x + r) + ' ' + r2(y) + 'Q' + r2(x) + ' ' + r2(y) + ' ' + r2(x) + ' ' + r2(y + r) + 'Q' + r2(x) + ' ' + r2(y) + ' ' + r2(x - r) + ' ' + r2(y) + 'Q' + r2(x) + ' ' + r2(y) + ' ' + r2(x) + ' ' + r2(y - r) + 'Z';
      if (N.lx == null) { N.lx = P.x; N.lv = 0; N.ly = yb; N.yv = 0; }
      N.lv += ((P.x - N.lx) * 55 - N.lv * 8.5) * dtS; N.lx += N.lv * dtS; N.yv += ((yb - N.ly) * 70 - N.yv * 9) * dtS; N.ly += N.yv * dtS;
      const gi = N.gi || 0, sg = SM(gi), cl = Math.cos(N.ly), sl = Math.sin(N.ly), glo = clamp(cv('glo'), 0, 1.5), slp = I.cur && /sleep/.test(I.cur.name || '') ? 1 : 0;
      const rk = (clamp(N.lv * 0.3 + (P.x - N.lx) * 0.7, -15, 15) + Math.sin(ts * 1.4) * 1.1 + Math.sin(ts * 43) * 6 * SM((gi - 0.6) / 0.4) * (0.6 + 0.4 * Math.sin(ts * 5))) * D2R, cr = Math.cos(rk), sr = Math.sin(rk), px0 = LC + N.lx, py0 = 95;
      const LPj = p => { const u = p[0] - LC, X = px0 + u * cl + p[2] * sl, dx = X - px0, dy = p[1] - py0; return [px0 + dx * cr - dy * sr, py0 + dx * sr + dy * cr]; }, LZ = p => -(p[0] - LC) * sl + p[2] * cl;
      const sub = (a, b) => [a[0] - b[0], a[1] - b[1], a[2] - b[2]], nrm = v => { const l = Math.hypot(v[0], v[1], v[2]) || 1; return [v[0] / l, v[1] / l, v[2] / l]; }, crs = (a, b) => [a[1] * b[2] - a[2] * b[1], a[2] * b[0] - a[0] * b[2], a[0] * b[1] - a[1] * b[0]];
      if (!N.geo) { const cb3 = (a, b, c, d, s) => [0, 1, 2].map(k => (1 - s) ** 3 * a[k] + 3 * (1 - s) ** 2 * s * b[k] + 3 * (1 - s) * s * s * c[k] + s ** 3 * d[k]), sm = (n, f) => { const C = [], W = [], T2 = []; for (let i = 0; i <= n; i++) { const r = f(i / n); C.push(r[0]); W.push(r[1]); T2.push(r[2]); } return [C, W, T2]; };
        const be = s => Math.pow(Math.max(0, Math.sin(Math.PI * (0.05 + 0.9 * s))), 0.6), dm = s => Math.sqrt(Math.max(0, 1 - s * s)), kb = s => 1.4 * Math.sin(Math.PI * (0.08 + 0.84 * s)) + 0.1;
        N.geo = { belly: sm(12, s => [[33.2 + 25 * s, 87.6 - 1.2 * s * s, 0], 5.2 * be(s) + 0.2, 7.4 * be(s) + 0.2]), spout: sm(8, s => [cb3([55, 86.6, 0], [62, 87.4, 0], [65.8, 83.6, 0], [68.6, 79.2, 0], s), 2.5 - 1.5 * s, 2.5 - 1.5 * s]),
          handle: sm(9, s => [cb3([34.6, 84.6, 0], [25.2, 82.2, 0], [25.4, 92.4, 0], [34.4, 90.6, 0], s), 1.05, 1.05]), lid: sm(5, s => [[LC, 83.4 - 4.9 * s, 0], 4.6 * dm(s) + 0.15, 4.6 * dm(s) + 0.15]),
          knob: sm(5, s => [[LC, 78.9 - 2.8 * s, 0], kb(s), kb(s)]), foot: sm(3, s => [[LC, 95 - 3.6 * s, 0], 5 - 1.5 * s, 5 - 1.5 * s]), gemC: [LC, 87.6, 7.75] }; }
      const solid = G3 => { const C = G3[0], W2 = G3[1], T2 = G3[2], n = C.length - 1, RG = []; for (let i = 0; i <= n; i++) { const T = nrm(sub(C[Math.min(n, i + 1)], C[Math.max(0, i - 1)])), wv = nrm(crs(T, [0, 0, 1])), tv = crs(wv, T), r = [];
          for (let k = 0; k < 14; k++) { const f = k / 14 * TAU, a = W2[i] * Math.cos(f), b = T2[i] * Math.sin(f); r.push(LPj([C[i][0] + wv[0] * a + tv[0] * b, C[i][1] + wv[1] * a + tv[1] * b, C[i][2] + wv[2] * a + tv[2] * b])); } RG.push(r); }
        let d = ''; for (let i = 0; i < n; i++) d += H.closedD(H.hull(RG[i].concat(RG[i + 1]))); return d; };
      const O = N.L, Gm = N.geo; ['foot', 'belly', 'spout', 'handle', 'lid', 'knob'].forEach(k => set(O[k], 'd', solid(Gm[k])));
      const gz = LZ(Gm.gemC), gp = LPj(Gm.gemC); set(O.gem, 'd', cir(gp[0], gp[1], 1.6)); set(O.gem, 'opacity', r2(SM((gz - 2) / 3)));
      const ord = [['foot', -0.2], ['belly', 0], ['lid', 0.2], ['knob', 0.3], ['spout', LZ([61.6, 85.4, 0]) - 0.05], ['handle', LZ([29.6, 87.4, 0]) - 0.05], ['gem', gz > 2 ? 9 : -9]].sort((a, b) => a[1] - b[1]).map(a => a[0]).join();
      if (ord !== N.ord) { N.ord = ord; ord.split(',').forEach(k => N.glow.parentNode.appendChild(O[k])); N.glow.parentNode.appendChild(N.shine); }
      const bc = LPj([LC, 87.6, 0]), hw = Math.hypot(12.6 * cl, 7.6 * sl); set(N.shine, 'd', ell(bc[0] - hw * 0.4, bc[1] - 3, hw * 0.3, 0.95));
      const tip = LPj([68.6, 79.2, 0]), tp2 = LPj([73.2, 70.8, 0]), pul = 0.5 + 0.5 * Math.sin(ts * 2.6), gw = (0.32 + 0.16 * pul + glo * 0.45 + sg * 0.5) * (slp ? 0.5 : 1);
      set(N.glow, 'd', cir(tip[0], tip[1], 6 + 2 * pul + glo * 6 + sg * 5)); set(N.glow, 'opacity', r2(clamp(gw, 0, 1)));
      set(N.fgl, 'd', cir(tip[0], tip[1], 5 + sg * 6 + glo * 3)); set(N.fgl, 'opacity', r2(clamp(sg * 0.75 + glo * 0.25, 0, 0.9)));
      // wisp tail: cubic from the spout (lamp frame) up into his chest (body frame), with a travelling wave, a tornado twist (gwh) and a drag bow when the lamp lags
      const q3 = byw(50, 66.5, 0), q2 = byw(55, 79.5, 0), wh = clamp(cv('gwh'), 0, 1.6), lagx = clamp(P.x - N.lx, -12, 12), TN = 26, CP = [], WD = [];
      for (let i = 0; i <= TN; i++) { const s = i / TN, a = (1 - s) ** 3, b = 3 * (1 - s) ** 2 * s, c = 3 * (1 - s) * s * s, d = s ** 3; CP.push([a * tip[0] + b * tp2[0] + c * q2[0] + d * q3[0], a * tip[1] + b * tp2[1] + c * q2[1] + d * q3[1]]); WD.push((1 + 7.4 * Math.pow(s, 1.25)) * (1 + wh * 0.08 * Math.sin(ts * 7 - s * 9))); }
      const CC = CP.map((p, i) => { const s = i / TN, a = CP[Math.max(0, i - 1)], b = CP[Math.min(TN, i + 1)], dx = b[0] - a[0], dy = b[1] - a[1], l = Math.hypot(dx, dy) || 1, env = Math.sin(Math.PI * s), wv = (0.8 + wh * 1.6 + Math.min(1.5, Math.abs(N.lv) * 0.05)) * env * Math.sin(ts * 3.1 - s * 7.5), sw = wh * 3 * env;
        return [p[0] - dy / l * wv + Math.cos(ts * 9 + s * 10) * sw - lagx * 0.35 * env, p[1] + dx / l * wv + Math.sin(ts * 9 + s * 10) * sw * 0.45]; });
      const ring = (c, r) => { const o = []; for (let k = 0; k < 12; k++) { const f = k / 12 * TAU; o.push([c[0] + r * Math.cos(f), c[1] + r * Math.sin(f)]); } return o; };
      let td = '', hd = '', pr = null, ph = null; CC.forEach((c, i) => { const w = WD[i], R = ring(c, w), Rh = ring([c[0] - w * 0.3, c[1] - w * 0.32], w * 0.4); if (pr) { td += H.closedD(H.hull(pr.concat(R))); if (i > 2 && i < TN - 1) hd += H.closedD(H.hull(ph.concat(Rh))); } pr = R; ph = Rh; });
      set(N.tail, 'd', td); set(N.thl, 'd', hd || 'M0 0');
      let sd = ''; [0, Math.PI].forEach(a0 => { let pen = false; for (let i = 3; i <= TN - 3; i++) { const s = i / TN, c = CC[i], a = CC[i - 1], b = CC[i + 1], dx = b[0] - a[0], dy = b[1] - a[1], l = Math.hypot(dx, dy) || 1, p2 = a0 + s * 11 - ts * 3.6 * (1 + wh), o = Math.sin(p2) * WD[i] * 0.62;
        if (Math.cos(p2) > -0.2) { sd += (pen ? 'L' : 'M') + r2(c[0] - dy / l * o) + ' ' + r2(c[1] + dx / l * o); pen = true; } else pen = false; } }); set(N.tsw, 'd', sd || 'M0 0');
      let kd = ''; for (let k = 0; k < 5; k++) { const u = (ts * 0.24 + k / 5) % 1, i = Math.min(TN, Math.round(u * TN)), c = CC[i], r = (0.6 + 0.9 * Math.sin(Math.PI * u)) * (0.6 + 0.4 * Math.sin(ts * 7 + k * 2)) * (slp ? 0.5 : 1) * (1 - sg); if (r > 0.1) kd += star(c[0] + Math.sin(k * 2.3 + ts * 1.3) * (WD[i] + 2.5), c[1] - 2 - u * 3, r * 1.6); } set(N.spk, 'd', kd || 'M0 0');
      if (N.pft && now - N.pft < 750) { const k = (now - N.pft) / 750, B = N.pfB || 1; let d = ''; for (let j = 0; j < 7; j++) { const a = j / 7 * TAU + 0.4, R = (3 + 9 * SM(k)) * B; d += cir(tip[0] + Math.cos(a) * R, tip[1] - (3 + 9 * SM(k)) * B + Math.sin(a) * R * 0.6, (2.2 + 3.4 * k) * B); } set(N.pf, 'd', d); set(N.pf, 'opacity', r2(0.85 * (1 - k))); } else set(N.pf, 'opacity', 0);
      if (sg > 0.002) { set(N.art, 'transform', 'translate(' + pt(tip) + ') rotate(' + r2(-150 * sg) + ') scale(' + r2(1 - 0.95 * SM(gi * 1.35)) + ') translate(' + r2(-tip[0]) + ' ' + r2(-tip[1]) + ')'); set(N.art, 'opacity', r2(1 - SM((gi - 0.8) / 0.2))); N.tf = 1; } else if (N.tf) { N.tf = 0; N.art.removeAttribute('transform'); N.art.removeAttribute('opacity'); } }
    const cwh = I.star ? G - I.star.C[1] : I.pq ? G - HY : 0, gl = Math.max(0, P.lift - cwh * (1 - Math.cos(tr))); set(I.shadow, 'cx', r2(50 + P.x + P.lean * 0.15 + cwh * Math.sin(tr))); set(I.shadow, 'cy', r2(G + 0.6)); set(I.shadow, 'rx', r2((I.key === 'pina' ? Math.min(bb.width, 56) : bb.width) * 0.5 * (1 + sq * 0.45) * (1 - gl / 70))); set(I.shadow, 'ry', r2(3.6 * (1 - gl / 90))); set(I.shadow, 'opacity', r2(0.2 * (1 - gl / 50)));
    if (I.gn) { set(I.shadow, 'cx', r2(45.6 + (I.gn.lx || 0))); set(I.shadow, 'rx', 15.5); set(I.shadow, 'ry', 3.2); set(I.shadow, 'opacity', 0.2); }
  };
  const inHeadPt = (g, x, y) => g.headA && Math.hypot((x - g.headA.cx) / g.headA.hx, (y - g.headA.cy) / g.headA.hy) < 1;

  window.RiveGeneric = { build };
})();
