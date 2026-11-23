// A clock the host drives: performance.now, Date.now, setTimeout / setInterval and requestAnimationFrame only move
// when the host calls __clock.frame(ms). Loaded before the rig scripts in Chrome (tests) and in the host (Node, Unity),
// so both run exactly the same frames. Also seeds Math.random (the same generator as webgame/test/pixel-diff.mjs).
(function (G) {
  'use strict';
  var now = 0, T0 = Date.UTC(2026, 10, 13, 12, 0, 0), seq = 0, timers = [], raf = [], rafSeq = 0;
  var s = 0x2f6b9a1;
  Math.random = function () { s ^= s << 13; s >>>= 0; s ^= s >>> 17; s ^= s << 5; s >>>= 0; return s / 4294967296; };
  // the host's real timers, for waiting on things outside the virtual time (a file arriving) without moving it
  G.__realSetTimeout = G.__realSetTimeout || G.setTimeout;
  var perf = G.performance || (G.performance = {});
  try { perf.now = function () { return now; }; } catch (e) { Object.defineProperty(G, 'performance', { value: { now: function () { return now; } }, configurable: true }); }
  Date.now = function () { return T0 + now; };
  function add(fn, ms, args, every) { var id = ++seq; timers.push({ id: id, at: now + Math.max(0, +ms || 0), fn: fn, args: args, every: every ? Math.max(1, +ms || 0) : 0 }); return id; }
  G.setTimeout = function (fn, ms) { return add(fn, ms, [].slice.call(arguments, 2), false); };
  G.setInterval = function (fn, ms) { return add(fn, ms, [].slice.call(arguments, 2), true); };
  G.clearTimeout = G.clearInterval = function (id) { for (var i = 0; i < timers.length; i++) if (timers[i].id === id) { timers.splice(i, 1); return; } };
  G.requestAnimationFrame = function (cb) { var id = ++rafSeq; raf.push({ id: id, cb: cb }); return id; };
  G.cancelAnimationFrame = function (id) { for (var i = 0; i < raf.length; i++) if (raf[i].id === id) { raf.splice(i, 1); return; } };
  G.queueMicrotask = G.queueMicrotask || function (f) { Promise.resolve().then(f); };
  // one frame: timers due up to now + ms fire in time order (each at its own time), then the frame's callbacks
  function frame(ms) {
    var end = now + (ms == null ? 16 : ms);
    for (;;) {
      var next = null;
      for (var i = 0; i < timers.length; i++) if (timers[i].at <= end && (!next || timers[i].at < next.at || (timers[i].at === next.at && timers[i].id < next.id))) next = timers[i];
      if (!next) break;
      now = Math.max(now, next.at);
      if (next.every) next.at += next.every; else timers.splice(timers.indexOf(next), 1);
      try { next.fn.apply(G, next.args); } catch (e) { if (G.console) G.console.error(e); }
    }
    now = end;
    var q = raf; raf = [];
    for (var j = 0; j < q.length; j++) { try { q[j].cb(now); } catch (e) { if (G.console) G.console.error(e); } }
  }
  G.__clock = { frame: frame, get now() { return now; }, pending: function () { return { timers: timers.length, raf: raf.length }; } };
})(typeof globalThis !== 'undefined' ? globalThis : this);
