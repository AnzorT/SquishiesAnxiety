// The live host's side in the JS engine (Creatures/LiveRig.cs runs it right after dom-shim.js, then __live.install):
// creatures mounted on the browser stand-in, one virtual clock for all of them, each frame's <svg> markup as
// record.mjs grabs it. Plain ES2017.
(function (G) {
  'use strict';
  var hosts = {}, seq = 0;
  // a C# delegate arrives as a function, or as an object with Invoke (the JS engine's binding decides)
  function call(f, a) { return typeof f === 'function' ? f(a) : f.Invoke(a); }
  G.__live = {
    install: function (readFile) { G.__readFile = function (p) { return call(readFile, p); }; RigDomShim.install(G, { readFile: G.__readFile }); },
    mount: function (key) {
      var el = document.createElement('div');
      document.body.appendChild(el);
      var id = ++seq, h = hosts[id] = { el: el, ev: [] };
      // (the house's onRig: each state the rig goes into, read with __live.events)
      h.ctl = RiveRig.mount(el, key, { onState: function (n) { h.ev.push(n); } });
      return id;
    },
    play: function (id, move) { var h = hosts[id]; if (h && h.ctl && h.ctl.play) h.ctl.play(move); },
    // the house: the walk's channels on the rig (ctl.ext: one object it reads every frame), its idle fidgets on or off
    // (the house turns them on while he stands free), and whether he's in one now (Squad House's fidg)
    ext: function (id, json) {
      var h = hosts[id]; if (!h || !h.ctl) return;
      if (!h.ext) { h.ext = {}; if (h.ctl.ext) h.ctl.ext(h.ext); }
      var o = JSON.parse(json); for (var k in h.ext) h.ext[k] = 0; for (var k2 in o) h.ext[k2] = o[k2];
    },
    events: function (id) { var h = hosts[id]; if (!h || !h.ev.length) return '[]'; var e = JSON.stringify(h.ev); h.ev = []; return e; },
    fidgets: function (id, on) { var h = hosts[id], I = h && h.ctl && h.ctl._I; if (I) { I.fidgets = !!on; I.hfid = 1; } },
    fidg: function (id) { var h = hosts[id], I = h && h.ctl && h.ctl._I; return !!(I && I.cur && /^(hf\d|idle_)/.test(I.cur.name)); },
    frame: function (ms) { G.__clock.frame(ms); },
    now: function () { return G.__clock.now; },
    svg: function (id) {
      var h = hosts[id], s = h && h.el.querySelector('svg');
      return s ? s.outerHTML.replace(/href="shim-canvas:[^"]*"/g, 'href="grain"').replace(/\n/g, ' ') : null;
    },
    unmount: function (id) {
      var h = hosts[id];
      if (!h) return;
      try { if (h.ctl && h.ctl.destroy) h.ctl.destroy(); } catch (e) { /* as the app */ }
      if (h.el.parentNode) h.el.parentNode.removeChild(h.el);
      delete hosts[id];
    },
  };
})(typeof globalThis !== 'undefined' ? globalThis : this);
