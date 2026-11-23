// The live host's side in the JS engine (Creatures/LiveRig.cs runs it right after dom-shim.js, then __live.install):
// creatures mounted on the browser stand-in, one virtual clock for all of them, each frame's <svg> markup as
// record.mjs grabs it. Plain ES2017.
(function (G) {
  'use strict';
  var hosts = {}, seq = 0;
  // a C# delegate arrives as a function, or as an object with Invoke (the JS engine's binding decides)
  function call(f, a) { return typeof f === 'function' ? f(a) : f.Invoke(a); }
  G.__live = {
    install: function (readFile) { RigDomShim.install(G, { readFile: function (p) { return call(readFile, p); } }); },
    mount: function (key) {
      var el = document.createElement('div');
      document.body.appendChild(el);
      var id = ++seq;
      hosts[id] = { el: el, ctl: RiveRig.mount(el, key, {}) };
      return id;
    },
    play: function (id, move) { var h = hosts[id]; if (h && h.ctl && h.ctl.play) h.ctl.play(move); },
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
