// The native host's helpers, compiled with the rig (tools/unity/rig/jsc.mjs; Creatures/Js/RigHost.cs calls them):
// what Creatures/ResultRig.cs used to hand the JS engine as text (its walk step, its bursts), and live-host.js's ext /
// events without the JSON in between. Plain ES2017.
(function (G) {
  'use strict';
  var ctl = {}, ext = {}, walk = {}, park = {}, els = {};
  var EIO = function (t) { return t < 0.5 ? 2 * t * t : 1 - Math.pow(-2 * t + 2, 2) / 2; };
  // each creature's controller (RiveRig.mount's: the last one it made), by its live-host id
  var mount = G.__live.mount;
  G.__live.mount = function (key) {
    var id = mount(key), b = G.document.body.childNodes;
    ctl[id] = G.RiveRig && G.RiveRig._last; els[id] = b[b.length - 1];
    return id;
  };
  function hostEl(id) { return els[id] || null; }
  var unmount = G.__live.unmount;
  G.__live.unmount = function (id) { delete ctl[id]; delete ext[id]; delete walk[id]; delete park[id]; delete els[id]; return unmount(id); };
  function I(id) { var c = ctl[id]; return c && c._I; }
  G.__native = {
    ctl: function (id) { return ctl[id] || null; },
    host: function (id) { return els[id] || null; },
    // the house walk's / the result card's channels on the rig this frame (live-host.js ext, from an object)
    ext: function (id, o) {
      var c = ctl[id]; if (!c) return;
      var h = ext[id];
      if (!h) { h = ext[id] = {}; if (c.ext) c.ext(h); }
      for (var k in h) h[k] = 0;
      for (var k2 in o) h[k2] = o[k2];
    },
    events: function (id) { return JSON.parse(G.__live.events(id)); },
    // tools/rig/walk.html step(): the Squad House's walk (HouseWalk.step) on the rig's ext, `w` its weight
    walkStep: function (id, key, w, dt, spin) {
      var i = I(id); if (!i) return;
      var s = walk[id] || (walk[id] = { E: {}, ws: {} });
      if (i.ext !== s.E) i.ext = s.E;
      for (var k in s.E) s.E[k] = 0;
      if (w > 0 && G.HouseWalk) try { G.HouseWalk.step(key, s.ws, s.E, w, dt, 1, spin); } catch (e) { /* as the page */ }
    },
    // tools/rig/result.html burst(): RiveRig.emit at the rig's own spot (`at`: eyeL...) or at x, y
    emit: function (id, kind, at, x, y, n) {
      var i = I(id); if (!i || !G.RiveRig.emit) return;
      var p = at ? ((i.W && i.W[at]) || [50, 50]) : [x, y];
      G.RiveRig.emit(i, kind, p, n > 0 ? n : 0);
    },
    // webgame/app/menu.js enterPark / leavePark, the creature's part (as record.mjs recorded it): it turns (spinOff),
    // walks with the Squad House's gait (HouseWalk), turns back, then 'happy'; parkStep(id, ms since the start)
    parkStart: function (id, key, enter) {
      var i = I(id), c = ctl[id]; if (!i) return;
      var HW = G.HouseWalk, E = {}, ws = {}, prev = i.ext, ph = 0;
      var turn = enter ? 380 : 340, walkMs = enter ? 2300 : 2100, dir = enter ? -90 : 90;
      park[id] = function (now) {
        if (ph === 0) { c.play('idle'); ph = 1; }
        if (now < turn) { i.spinOff = dir * EIO(now / turn); return; }
        if (now < turn + walkMs) {
          if (i.ext !== E) i.ext = E;
          var tt = (now - turn) / walkMs, w = Math.min(1, tt / 0.08, (1 - tt) / 0.1);
          for (var k in E) E[k] = 0;
          try { HW.step(key, ws, E, Math.max(0, w), 0.016, 1, dir); } catch (e) { /* as the page */ }
          i.spinOff = dir;
          return;
        }
        if (i.ext === E) { for (var k2 in E) E[k2] = 0; i.ext = prev; }
        if (now < 2 * turn + walkMs) { i.spinOff = dir * (1 - EIO((now - turn - walkMs) / turn)); return; }
        if (ph === 1) { i.spinOff = 0; c.play('happy'); ph = 2; delete park[id]; }
      };
    },
    parkStep: function (id, ms) { if (park[id]) park[id](ms); },
    // a pointer on the creature (x, y in its 0-100 box), as the page's touch reaches the rig's own handlers
    pointer: function (id, type, x, y) {
      var el = hostEl(id); if (!el) return;
      el.__rect = { left: 0, top: 0, width: 100, height: 100 };
      var w = el.firstChild; if (!w) return;
      w.dispatchEvent({ type: type, clientX: x, clientY: y, pointerId: 1, preventDefault: function () {}, stopPropagation: function () {} });
    },
    // intro.js's squish: the squeeze starts at once (the rig's own starts after a 170 ms hold)
    press: function (id) { var i = I(id); if (i) { i.press = true; i.pressT = G.performance.now(); } },
    // the scene's light on the rig (ctl.light), from JSON (null: its own)
    light: function (id, json) { var c = ctl[id]; if (c && c.light) c.light(json ? JSON.parse(json) : null); },
    // tools/chest/host.html rigReady: its body's box at rest (idle, t 0), [x, y, w, h], once it's drawn (null before);
    // the landing's dust and sparkles defined once (host.html adds them to RiveRig.PRE)
    restBox: function (id) {
      var c = ctl[id], i = I(id), el = els[id]; if (!c || !el) return null;
      if (i.generic && !i.ready) return null;
      if (!G.__heroPre) { G.__heroPre = 1; Object.assign(G.RiveRig.PRE, {
        unDust: { n: 8, sp: 26, vy: -5, g: 10, life: 650, r: [1.4, 2.6], col: ['#ffffff', '#fff6e6', '#f6e2c4'], kind: 'dot' },
        unSpark: { n: 8, sp: 34, vy: -14, g: 0, life: 800, r: [2.2, 3.8], col: ['#fff3a0', '#ffffff', '#ffd23a', '#ffd1f5'], kind: 'star' },
      }); }
      c._pose('idle', 0);
      var svg = el.querySelector('svg'), b = null;
      try { b = svg && svg.getBBox(); } catch (e) { /* not drawn yet */ }
      if (!b || !(b.width > 1)) return null;
      return [b.x, b.y, b.width, b.height];
    },
    // the rig's state machine and a few of its switches
    state: function (id) { var i = I(id); return i && i.cur ? i.cur.name : null; },
    spinOff: function (id, deg) { var i = I(id); if (i) i.spinOff = deg; },
    // the border looks (below): `n` everyone's, `over` JSON { key: n } for single creatures, `keys` JSON [the creatures
    // that have look pictures] (null: every creature)
    looks: function (n, over, keys) {
      LOOK.n = n == null ? 4 : Math.max(0, Math.min(4, n | 0));
      LOOK.over = over ? JSON.parse(over) || {} : {};
      LOOK.keys = keys ? JSON.parse(keys) : null;
      auto = auto.filter(alive);
      auto.forEach(function (r) { r.I.lookM = lookOf(r.key); });
      // (setLook re-applies every rig's look: its line and shading redrawn on the next frame)
      if (G.RiveRig && G.RiveRig.setLook) G.RiveRig.setLook(LOOK.n);
    },
    lookOf: function (key) { return lookOf(key); },
    // one creature in a look of its own whatever config/roster says (the yard games' posters: 3, as develop's
    // yg-intros.js mounts them); its scene light kept
    look: function (id, n) {
      var c = ctl[id], i = c && c._I; if (!i) return;
      auto = auto.filter(function (r) { return r.I !== i; });
      i.lookM = Math.max(0, Math.min(4, n | 0));
      if (c.light) c.light(i.sceneL || null);
    },
  };

  // ---- the creatures' border looks (2026-11-26, the user: "i want all of them to have the number 3") ----
  // Firestore config/roster's `look` (everyone) and `looks` ({ creature id or key: n }), as src/squad/looks.js reads
  // them; Unity: Creatures/CreatureLooks.cs hands them over (__native.looks). The rig draws the look itself (rive-rig.js
  // applyLook, MODES: 1 shading only, 2 thin ink line, 3 bold ink line, 4 bold line in each part's own darker colour;
  // 0 off), its line round each part as the look pictures have it. Every creature mounted gets its look; a mount that
  // brings its own (the yard games' posters: look 3) keeps it; a creature without look pictures gets none (as the app's
  // rigLookOf). The app's own outline (webgame/app/rig-look.js, an outer edge as an SVG filter) isn't used here: it
  // waits for the app's page (window.SquishApp), which the realm doesn't have.
  var LOOK = { n: 4, over: {}, keys: null }, auto = [];
  function lookOf(key) {
    if (LOOK.keys && LOOK.keys.indexOf(key) < 0) return 0;
    return LOOK.over[key] != null ? Math.max(0, Math.min(4, LOOK.over[key] | 0)) : LOOK.n;
  }
  function alive(r) { var s = r.I.shadow; return !s || s.isConnected; }
  var R = G.RiveRig;
  if (R && typeof R.mount === 'function' && !R.__unityLook) {
    var rmount = R.mount;
    R.mount = function (host, key, o) {
      var own = !!(o && o.look != null), oo = o;
      if (!own) { oo = {}; if (o) for (var k in o) oo[k] = o[k]; oo.look = lookOf(key); }
      var c = rmount.call(this, host, key, oo);
      if (!own && c && c._I) { auto = auto.filter(alive); auto.push({ I: c._I, key: key }); }
      return c;
    };
    R.__unityLook = true;
    if (R.setLook) R.setLook(LOOK.n);
  }
})(typeof globalThis !== 'undefined' ? globalThis : this);
