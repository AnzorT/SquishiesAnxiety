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
    // the rig's state machine and a few of its switches
    state: function (id) { var i = I(id); return i && i.cur ? i.cur.name : null; },
    spinOff: function (id, deg) { var i = I(id); if (i) i.spinOff = deg; },
  };
})(typeof globalThis !== 'undefined' ? globalThis : this);
