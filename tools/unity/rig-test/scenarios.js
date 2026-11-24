// What the parity test (run.mjs) has each creature do, on both sides: the JS rig in Node on the browser stand-in and
// the compiled C# rig (jsc.mjs --test compiles this file too, so both run the very same steps). Every move and state
// the app uses: the menu's idle and its fidgets, a script of moves (parity.mjs's), a poke and a squeeze, the Game
// Park's walk in and out and MY HOUSE's turn (record.mjs's clips), the game intro's surprised / look / idle / dance,
// the result card's four clips (record.mjs --clip result: the card's states, ext moves and bursts), Squish Stack's
// road walk (walk.html), the Squad House's idle fidgets. Plain ES2017.
//   __scn.start(key, name) -> number of snapshots it will take; (the host lets the promises settle: the art arriving)
//   __scn.run() -> [svg markup, ...]; __scn.stop()
(function (G) {
  'use strict';
  var R, cur = null;
  var clamp = function (v, a, b) { return Math.max(a, Math.min(b, v)); };
  var SM = function (x) { x = clamp(x, 0, 1); return x * x * (3 - 2 * x); };
  var parab = function (u) { return u <= 0 || u >= 1 ? 0 : 4 * u * (1 - u); };
  var EIO = function (t) { return t < 0.5 ? 2 * t * t : 1 - Math.pow(-2 * t + 2, 2) / 2; };
  var AR = function (K) { return { armL: K, armR: K }; };

  function ctlOf(id) { return G.__native.ctl(id); }
  // (the native host's own markup writer when there is one: RigHost.Svg, what Unity draws)
  function svg(id) { return G.__svgOf ? G.__svgOf(id) : G.__live.svg(id); }

  // each scenario: frames (16 ms each), a snapshot every `every`, setup(c) once, step(c, f, t) before each frame
  var S = {
    // parity.mjs's script of moves
    moves: { frames: 421, every: 10, step: function (c, f) { var P = [[0, 'idle'], [90, 'dance'], [190, 'hop'], [250, 'squish'], [310, 'idle_waveL'], [370, 'happy']]; for (var i = 0; i < P.length; i++) if (P[i][0] === f) c.ctl.play(P[i][1]); } },
    // the menu: idle, its glances, blinks and fidgets
    idle: { frames: 760, every: 19, setup: function (c) { c.ctl.play('idle'); } },
    // a tap on the head (a poke), then a hold (a squeeze) and its let-go
    touch: {
      frames: 200, every: 8,
      step: function (c, f) {
        if (f === 10) G.__native.pointer(c.id, 'pointerdown', 50, 30);
        if (f === 13) G.__native.pointer(c.id, 'pointerup', 50, 30);
        if (f === 80) G.__native.pointer(c.id, 'pointerdown', 50, 60);
        if (f === 120) G.__native.pointer(c.id, 'pointerup', 50, 60);
      },
    },
    // the game intro (webgame/app/intro.js): out of the box surprised, the look round, idle, then the dance at dawn
    // (with a squish in its idle: native-host.js pointer + press, as Unity's intro does it)
    intro: {
      frames: 480, every: 12,
      step: function (c, f) {
        if (f === 0) c.ctl.play('surprised'); if (f === 96) c.ctl.play('look'); if (f === 190) c.ctl.play('idle'); if (f === 300) c.ctl.play('dance');
        if (f === 220) { G.__native.pointer(c.id, 'pointerdown', 50, 60); G.__native.press(c.id); }
        if (f === 236) G.__native.pointer(c.id, 'pointerup', 50, 60);
      },
    },
    // MY HOUSE (main-menu.js goHome): the turn to the door in its idle
    'home-enter': { frames: 113, every: 4, setup: function (c) { c.ctl.play('idle'); }, step: function (c, f, t) { c.I.spinOff = 180 * EIO(Math.min(1, t / 430)); } },
    // the walk to the Game Park and back (webgame/app/menu.js enterPark / leavePark): turn, HouseWalk's gait, turn, happy
    // (native-host.js's parkStart / parkStep, what Unity's menu calls)
    'park-enter': { frames: 250, every: 5, setup: function (c) { G.__native.parkStart(c.id, c.key, true); }, step: function (c, f, t) { G.__native.parkStep(c.id, t); } },
    'park-leave': { frames: 250, every: 5, setup: function (c) { G.__native.parkStart(c.id, c.key, false); }, step: function (c, f, t) { G.__native.parkStep(c.id, t); } },
    // the result card (tools/rig/result.html, record.mjs --clip result)
    'res-wait': { frames: 125, every: 5, setup: function (c) { res(c, 'wait'); }, step: function (c, f, t) { c.res(t); } },
    'res-fill': { frames: 200, every: 4, setup: function (c) { res(c, 'fill'); }, step: function (c, f, t) { c.res(t); } },
    'res-happy': { frames: 620, every: 10, setup: function (c) { res(c, 'happy'); }, step: function (c, f, t) { c.res(t); } },
    'res-miss': { frames: 119, every: 4, setup: function (c) { res(c, 'miss'); }, step: function (c, f, t) { c.res(t); } },
    // Squish Stack's road (tools/rig/walk.html): turned side-on, walking the Squad House's gait, then stopping
    walk: {
      frames: 300, every: 6, setup: function (c) { G.__live.fidgets(c.id, false); },
      step: function (c, f) {
        var yaw = f < 30 ? 0 : f < 60 ? 90 * (f - 30) / 30 : f < 260 ? 90 : 90 * (1 - (f - 260) / 30);
        var w = f < 60 || f > 270 ? 0 : Math.min(1, (f - 60) / 12, (270 - f) / 12);
        G.__native.spinOff(c.id, Math.max(0, yaw));
        G.__native.walkStep(c.id, c.key, w, 0.016, 90);
      },
    },
    // the chest unlock's creature (tools/chest/host.html rigReady / popAt, Creatures/HeroCreature.cs): its box at rest,
    // out of the burst turning once with its arms up, the landing's dust and sparkles, its cheer
    hero: {
      frames: 150, every: 5,
      setup: function (c) { c.bb = G.__native.restBox(c.id) || [30, 20, 40, 70]; c.ctl.play('surprised'); },
      step: function (c, f, t) {
        var land = 640, arm = t < land ? 55 * SM(t / 160) : 55 * (1 - SM((t - land) / 250));
        G.__native.ext(c.id, t < 1060 ? { spin: t < land ? 360 * SM(t / (land - 40)) : 0, armL: arm, armR: arm } : {});
        if (t === 640) {
          var b = c.bb;
          G.__native.emit(c.id, 'unDust', null, b[0] + b[2] / 2, b[1] + b[3] - 2, 0);
          G.__native.emit(c.id, 'unSpark', null, b[0] + b[2] / 2, b[1] + 4, 0);
          c.ctl.play('happy');
        }
      },
    },
    // the Squad House: standing free, its own idle fidgets
    house: { frames: 900, every: 25, setup: function (c) { G.__live.fidgets(c.id, true); } },
  };

  // record.mjs --clip result's drivers: the card's ext moves and bursts on the rig, from each clip's start
  var FILL = 560, CROUCH = 360, RISE = 640, HANG = 320, FALL = 460, LAND = 480;
  var RA = FILL, RB = RA + CROUCH, TOP = RB + RISE, DOWN = TOP + HANG, GROUND = DOWN + FALL, RD = GROUND + LAND;
  var HAPPY = [
    { ms: 1000, f: function (t) { var u = t / 1000, h = Math.max(parab(u * 2), parab(u * 2 - 1)); return { ext: AR(30 * h + 8) }; } },
    { ms: 1300, f: function (t) { var e = Math.sin(clamp(t / 1300, 0, 1) * Math.PI), w = Math.sin(t / 85); return { ext: { armR: (54 + 16 * w) * e, armL: -6 * e, htilt: 6 * e } }; } },
    { ms: 1100, f: function (t) { var e = Math.sin(clamp(t / 1100, 0, 1) * Math.PI), w = Math.sin(t / 90); return { ext: { lean: 2.2 * w * e, armL: (24 + 14 * w) * e, armR: (24 - 14 * w) * e } }; } },
    { ms: 1200, f: function (t) { var u = t / 1200, h = parab((u - 0.15) / 0.7); return { ext: Object.assign({ spin: 360 * SM((u - 0.2) / 0.62) }, AR(40 * h)) }; } },
  ];
  function res(c, clip) {
    var R2 = G.RiveRig, kv = R2.kv, I = c.I, E = {}, bb = null, fired = {}, hp = clip === 'happy' ? { n: 0, next: 500, mv: null, at: 0 } : null;
    I.fidgets = false; I.hfid = 1; I.ext = E;
    var box = function () { try { var g = c.el.querySelector('svg').getBBox(); return { cx: g.x + g.width / 2, gy: g.y + g.height, top: g.y }; } catch (e) { return { cx: 50, gy: 90, top: 10 }; } };
    var burst = function (kind, where, n) { var p = where === 'feet' ? [bb.cx, bb.gy - 2] : where === 'head' ? [bb.cx, bb.top + 4] : (I.W && I.W[where]) || [50, 50]; try { R2.emit(I, kind, p, n); } catch (e) { /* as the page */ } };
    var once = function (k, t, at, fn) { if (t >= at && !fired[k]) { fired[k] = 1; fn(); } };
    c.ctl.play('resWait');
    for (var t0 = 0; t0 < 1500; t0 += 16) G.__clock.frame(16);
    if (clip === 'happy') c.ctl.play('resHappy'); else if (clip === 'miss') c.ctl.play('resMiss');
    c.res = function (t) {
      if (!bb) bb = box();
      for (var k in E) E[k] = 0;
      if (clip === 'fill') {
        once('wow', t, FILL * 0.62, function () { c.ctl.play('resWow'); });
        once('s1', t, FILL, function () { burst('resSpark', 'head', 7); });
        once('h1', t, TOP - 120, function () { burst('resHeart', 'head', 1); });
        once('h2', t, TOP + 160, function () { burst('resHeart', 'head', 1); });
        once('g', t, GROUND, function () { burst('resDust', 'feet'); burst('resSpark', 'feet', 5); });
        once('happy', t, RD, function () { c.ctl.play('resHappy'); });
        if (t < RD) {
          var arm = kv([[0, 0], [RA, 6, 'io'], [RB, -16, 'io'], [RB + 160, 52, 'o'], [DOWN, 46, 'io'], [GROUND, 30, 'io'], [GROUND + 120, -10, 'o'], [RD, 14, 'io']], t);
          var wave = t > RB + 160 && t < DOWN ? 10 * Math.sin((t - RB) / 95) : 0;
          var spin = t < RB + 80 ? 0 : t > GROUND - 40 ? 0 : 360 * SM((t - RB - 80) / (GROUND - 40 - RB - 80));
          Object.assign(E, { armL: arm + wave, armR: arm - wave, spin: spin, footL: t > RB && t < GROUND ? 2 : 0, footR: t > RB && t < GROUND ? 2 : 0 });
        }
      } else if (clip === 'miss') once('tear', t, 700, function () { burst('resTear', 'eyeL'); });
      else if (clip === 'happy') {
        var w = t / 1000; Object.assign(E, AR(10 + 6 * Math.sin(w * 3)));
        if (!hp.mv && t >= hp.next) { hp.mv = HAPPY[hp.n % HAPPY.length]; hp.n += 1; hp.at = t; if (hp.n % 2 === 0) burst('resHeart', 'head', 1); }
        if (hp.mv) {
          var u = t - hp.at;
          if (u >= hp.mv.ms) { hp.mv = null; hp.next = t + 900 + ((hp.n * 211) % 700); }
          else { var r = hp.mv.f(u); for (var k3 in r.ext) E[k3] = (E[k3] || 0) + r.ext[k3]; }
        }
      }
    };
  }

  G.__scn = {
    names: Object.keys(S),
    start: function (key, name) {
      var sc = S[name];
      if (!sc) throw new Error('no scenario ' + name);
      var id = G.__live.mount(key), ctl = ctlOf(id);
      cur = { id: id, key: key, sc: sc, ctl: ctl, I: ctl && ctl._I, el: null };
      var hosts = G.document.body.childNodes;
      cur.el = hosts[hosts.length - 1];
      return Math.floor((sc.frames - 1) / sc.every) + 1;
    },
    run: function () {
      var c = cur, sc = c.sc, out = [];
      if (sc.setup) sc.setup(c);
      for (var f = 0; f < sc.frames; f++) {
        if (sc.step) sc.step(c, f, f * 16);
        if (f % sc.every === 0) out.push(svg(c.id));
        G.__clock.frame(16);
      }
      return out;
    },
    stop: function () { if (cur) G.__live.unmount(cur.id); cur = null; },
  };
})(typeof globalThis !== 'undefined' ? globalThis : this);
