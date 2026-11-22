// PERF 2026-11-20: sleep / wake (SquishApp.receive({ type: 'sleep', on })). The app keeps this page mounted while its
// own screens (Shop, Settings, the mini-games, Squish Time…) cover it, and asks it to sleep: everything the page draws or
// computes stops, so the hidden page costs ~0 CPU / GPU, and on wake everything carries on exactly where it was.
// Loaded first, before any design script, so the design's own engines go through it without knowing:
//   - the page's clock (performance.now() and every requestAnimationFrame time) doesn't run while asleep: on wake every
//     tween, rig and loop carries on from the moment it slept (no jump to the end, no huge frame step)
//   - requestAnimationFrame callbacks wait (held) until wake; they then run in the first frame back
//   - setTimeout: a timer keeps the time it still had left when the page fell asleep and fires that long after wake;
//     setIntervals stop while asleep and start again on wake
//   - CSS animations are paused by one rule (html.sq-sleep), Web Animations and CSS transitions by pause() / play(),
//     SVG (SMIL) animations by pauseAnimations(), <video> / <audio> by pause() / play(), WebAudio by suspend() / resume()
//     (an animation, a clip or a sound started while asleep starts paused and plays on wake)
// SquishSleep.native holds the real timers for the little that must run while asleep (app/bridge.js: saving the house
// to the app, the app's answers). Never asleep unless the app says so: with no 'sleep' messages nothing changes.
(function () {
  var W = window, perf = W.performance;
  var N = {
    raf: W.requestAnimationFrame && W.requestAnimationFrame.bind(W), caf: W.cancelAnimationFrame && W.cancelAnimationFrame.bind(W),
    setTimeout: W.setTimeout.bind(W), clearTimeout: W.clearTimeout.bind(W), setInterval: W.setInterval.bind(W), clearInterval: W.clearInterval.bind(W),
    now: perf.now.bind(perf),
  };
  var asleep = false, slept = 0, fellAt = 0, subs = [];
  var S = W.SquishSleep = { native: N, get asleep() { return asleep; }, sleptMs: function () { return slept; }, on: function (f) { subs.push(f); } };
  // the page's clock: the real one minus the time spent asleep (frozen while asleep)
  var vnow = function () { return (asleep ? fellAt : N.now()) - slept; };
  try { perf.now = vnow; } catch (e) { /* read-only: no frozen clock (the rest still works) */ }

  // ---- requestAnimationFrame (ids of its own, far above the browser's, so a stray browser id still cancels) ----
  var fid = 1e9, frames = {}, held = {};
  function runFrame(id, cb) {
    return function (ts) {
      delete frames[id];
      if (asleep) { held[id] = cb; return; }
      cb(ts - slept);
    };
  }
  if (N.raf) {
    W.requestAnimationFrame = function (cb) {
      var id = ++fid;
      if (asleep) held[id] = cb; else frames[id] = N.raf(runFrame(id, cb));
      return id;
    };
    W.cancelAnimationFrame = function (id) {
      if (held[id]) { delete held[id]; return; }
      if (frames[id] != null) { N.caf(frames[id]); delete frames[id]; } else if (id < 1e9) N.caf(id);
    };
  }

  // ---- timers (one id space for both, as the browser's: clearTimeout clears an interval and back) ----
  var tid = 1e9, timers = {};
  function arm(T, d) { T.n = N.setTimeout(function () { T.n = 0; if (!asleep) T.run(); }, d); }
  W.setTimeout = function (cb, ms) {
    if (typeof cb !== 'function') return N.setTimeout.apply(W, arguments);
    var id = ++tid, args = Array.prototype.slice.call(arguments, 2), d = Math.max(0, +ms || 0);
    var T = timers[id] = { due: vnow() + d, n: 0, run: function () { delete timers[id]; cb.apply(W, args); } };
    if (!asleep) arm(T, d);   // (asleep: its time is kept for wake)
    return id;
  };
  W.setInterval = function (cb, ms) {
    if (typeof cb !== 'function') return N.setInterval.apply(W, arguments);
    var id = ++tid, args = Array.prototype.slice.call(arguments, 2);
    var T = timers[id] = { ms: ms, tick: function () { if (!asleep) cb.apply(W, args); }, iv: 0 };
    if (!asleep) T.iv = N.setInterval(T.tick, ms);
    return id;
  };
  W.clearTimeout = W.clearInterval = function (id) {
    var T = timers[id];
    if (!T) { if (id && id < 1e9) N.clearTimeout(id); return; }
    delete timers[id];
    if (T.tick) { if (T.iv) N.clearInterval(T.iv); } else if (T.n) N.clearTimeout(T.n);
  };
  // asleep: no timer runs (their time left is kept); awake: each carries on with the time it had left
  function timersSleep() { Object.keys(timers).forEach(function (id) { var T = timers[id]; if (T.tick) { if (T.iv) { N.clearInterval(T.iv); T.iv = 0; } } else if (T.n) { N.clearTimeout(T.n); T.n = 0; } }); }
  function timersWake() { var now = vnow(); Object.keys(timers).forEach(function (id) { var T = timers[id]; if (T.tick) { if (!T.iv) T.iv = N.setInterval(T.tick, T.ms); } else if (!T.n) arm(T, Math.max(0, T.due - now)); }); }

  // ---- media and sound: remember what plays, so sleep can pause it and wake can play it again ----
  var media = typeof Set === 'function' ? new Set() : null, contexts = [], wantPlay = [], wantResume = [];
  var MP = W.HTMLMediaElement && W.HTMLMediaElement.prototype;
  if (MP && media) {
    var play = MP.play;
    MP.play = function () {
      // (the ones gone from the page and stopped are let go: the park's clips are made afresh each visit)
      if (media.size > 40) media.forEach(function (m) { if (!m.isConnected && m.paused) media.delete(m); });
      media.add(this);
      if (asleep) { if (wantPlay.indexOf(this) < 0) wantPlay.push(this); return Promise.resolve(); }
      return play.apply(this, arguments);
    };
    S._play = play;
  }
  ['AudioContext', 'webkitAudioContext'].forEach(function (k) {
    var C = W[k]; if (typeof C !== 'function' || C.__sq) return;
    var Wrapped = function () { var c = new (Function.prototype.bind.apply(C, [null].concat(Array.prototype.slice.call(arguments))))(); contexts.push(c); if (asleep && c.state === 'running') { c.suspend(); wantResume.push(c); } return c; };
    Wrapped.prototype = C.prototype; Wrapped.__sq = true;
    try { W[k] = Wrapped; } catch (e) { /* fixed */ }
  });
  var BAC = W.BaseAudioContext || W.AudioContext;
  var resume = BAC && BAC.prototype.resume;
  if (resume) BAC.prototype.resume = function () {
    if (asleep) { if (wantResume.indexOf(this) < 0) wantResume.push(this); return Promise.resolve(); }
    return resume.apply(this, arguments);
  };
  // a Web Animation started while asleep starts paused (played on wake)
  var EP = W.Element && W.Element.prototype, anims = [];
  if (EP && EP.animate) {
    var animate = EP.animate;
    EP.animate = function () { var a = animate.apply(this, arguments); if (asleep) { try { a.pause(); anims.push(a); } catch (e) { /* gone */ } } return a; };
  }

  var svgs = [], style = null;
  function sleep() {
    if (asleep) return;
    fellAt = N.now(); asleep = true;
    var root = document.documentElement;
    // CSS animations: one rule (the menu's own paused-while-covered rules keep working: nothing is overridden by script)
    if (!style) { style = document.createElement('style'); style.textContent = 'html.sq-sleep *,html.sq-sleep *::before,html.sq-sleep *::after{animation-play-state:paused !important;}'; (document.head || root).appendChild(style); }
    root.classList.add('sq-sleep');
    // Web Animations and CSS transitions (not CSS animations: pausing those from script would take them away from the CSS
    // rules that pause them, e.g. .sq-away)
    anims = [];
    try { document.getAnimations().forEach(function (a) { if (a.playState === 'running' && !(W.CSSAnimation && a instanceof W.CSSAnimation)) { a.pause(); anims.push(a); } }); } catch (e) { /* old WebView */ }
    // SVG animations: their outermost <svg>s
    svgs = [];
    document.querySelectorAll('animate,animateTransform,animateMotion,set').forEach(function (e) {
      var s = e.ownerSVGElement; while (s && s.ownerSVGElement) s = s.ownerSVGElement;
      if (s && svgs.indexOf(s) < 0 && s.pauseAnimations && !s.animationsPaused()) { s.pauseAnimations(); svgs.push(s); }
    });
    // clips and sounds
    wantPlay = [];
    if (media) { document.querySelectorAll('video,audio').forEach(function (m) { media.add(m); }); media.forEach(function (m) { if (!m.paused && !m.ended) { m.pause(); wantPlay.push(m); } }); }
    wantResume = [];
    contexts.forEach(function (c) { if (c.state === 'running') { try { c.suspend(); wantResume.push(c); } catch (e) { /* closed */ } } });
    timersSleep();
    subs.forEach(function (f) { try { f(true); } catch (e) { console.error('[SquishSleep]', e); } });
  }
  function wake() {
    if (!asleep) return;
    slept += N.now() - fellAt; asleep = false;
    document.documentElement.classList.remove('sq-sleep');
    anims.forEach(function (a) { try { if (a.playState === 'paused') a.play(); } catch (e) { /* gone */ } }); anims = [];
    svgs.forEach(function (s) { try { s.unpauseAnimations(); } catch (e) { /* gone */ } }); svgs = [];
    wantPlay.forEach(function (m) { if (m.isConnected || m.tagName === 'AUDIO') try { S._play.call(m).catch(function () {}); } catch (e) { /* gone */ } }); wantPlay = [];
    wantResume.forEach(function (c) { try { if (c.state === 'suspended') resume.call(c); } catch (e) { /* closed */ } }); wantResume = [];
    // frames held while asleep run in the first frame back; timers carry on with the time they had left
    var h = held; held = {};
    Object.keys(h).forEach(function (id) { frames[id] = N.raf(runFrame(id, h[id])); });
    timersWake();
    subs.forEach(function (f) { try { f(false); } catch (e) { console.error('[SquishSleep]', e); } });
  }
  S.set = function (on) { if (on) sleep(); else wake(); };
})();

// The in-app game's frame-rate guard (performance, 2026-11-14). Loaded first, before any design script.
// The creatures (rive-rig.js) rebuild and redraw their SVG every frame: the costliest thing left on a weak phone. This
// watches the page's frame rate and, while it stays low, lets the creatures update less often so everything else (the
// camera, the weather, the buttons) stays smooth:
//   step 1: every frame (60) -> under ~55 fps for 2 s -> step 2: every other frame (30)
//   step 2 -> still under ~45 fps for 3 s -> step 3: every third frame (20). Kept for the session.
// (Watched from 4 s after the page has loaded, not while it boots.)
// rive-rig.js asks SquishPerf.rigStride() once a frame (patched in by webgame/patches.mjs): the creatures take turns, 1/step
// of them drawn a frame (PERF 2026-11-20; it was all of them every step-th frame); a creature with sqHold set
// (the menu's, while hidden under the house or a page) isn't drawn at all.
// A phone with 2 GB of memory or 2 cores or fewer starts at step 2.
(function () {
  var weak = (navigator.deviceMemory && navigator.deviceMemory <= 2) || (navigator.hardwareConcurrency && navigator.hardwareConcurrency <= 2);
  var P = window.SquishPerf = { step: weak ? 2 : 1, fps: 0 };
  Object.defineProperty(P, 'half', { get: function () { return P.step > 1; } });
  var t0 = 0, n = 0, slow = 0, k = 0, last = 0;
  var watching = false;
  function watch(now) {
    if (P.step >= 3) { watching = false; return; } // nothing lower to go to
    // (frozen: nothing moves, nothing to judge, and no frame asked for: a frame request makes the WebView draw the whole
    //  page again; checked back on a timer. PERF 2026-11-20)
    if (P.freeze) { watching = false; t0 = 0; slow = 0; var back = function () { if (P.freeze) { setTimeout(back, 250); return; } if (!watching && P.step < 3) { watching = true; requestAnimationFrame(watch); } }; setTimeout(back, 250); return; }
    watching = true;
    requestAnimationFrame(watch);
    // a single stall of over a second (a page or the house loading) is a hiccup, not a slow phone: start over
    if (now - last > 1000 || now < quiet) t0 = 0;
    last = now;
    if (!t0) { t0 = now; n = 0; return; }
    n++;
    if (now - t0 < 1000) return;
    var fps = (n * 1000) / (now - t0);
    P.fps = fps; t0 = now; n = 0;
    // (on trial after a step-up, rigCost below: a single second under 58 fps steps back down; and in the house at every
    // frame, always: its rooms are the heaviest page, and a step-up that held 58 for its trial dipped to 53-55 later,
    // when the creatures got busier, on the Galaxy A16)
    var trial = P.step === 1 && (now < trialUntil || (scopeName === 'house' && upTried.house));
    slow = fps < (trial ? 58 : P.step === 1 ? 55 : 45) ? slow + 1 : 0;
    if (slow >= (trial ? 1 : P.step === 1 ? 2 : 3)) {
      trialUntil = 0;
      P.step++; slow = 0;
      // noted for the chest smash's page (tools/chest/host.html): a phone that had to slow the menu's creatures opens
      // its chests in their lighter mode from the start
      try { localStorage.setItem('sq.perfStep', JSON.stringify({ step: P.step, t: Date.now() })); } catch (e) { /* no storage */ }
    }
  }
  // judged from 4 s after the page has loaded: while it boots it runs at 8-14 fps even on a fast machine, and
  // counting that put every phone at step 2 for the session
  function begin() { setTimeout(function () { if (!watching) { watching = true; requestAnimationFrame(watch); } }, 4000); }
  if (document.readyState === 'complete') begin(); else window.addEventListener('load', begin);
  // a hidden page (the app in the background) doesn't count as slow
  document.addEventListener('visibilitychange', function () { t0 = 0; slow = 0; mt = 0; });
  // nor the first seconds after a sleep (PERF 2026-11-20: the WebView may redraw its tiles as it's uncovered)
  var quiet = 0;
  if (window.SquishSleep) window.SquishSleep.on(function (on) { t0 = 0; slow = 0; mt = 0; if (!on) quiet = performance.now() + 2500; });
  // PERF 2026-11-20: nor a page or the house loading (P.quiet(ms): not judged for that long)
  P.quiet = function (ms) { quiet = Math.max(quiet, performance.now() + (ms || 0)); t0 = 0; slow = 0; };
  // and each place has its own step (P.scope('house' | 'menu')): the house is the heaviest page and used to step the
  // creatures down for the rest of the session, so the menu after a visit to the house drew its creature at 30 or 20
  // fps (the user: the menu at 33-50 fps after leaving the house). Each keeps the step it found.
  var scopes = {}, scopeName = 'menu', base = P.step;
  P.scope = function (name) {
    if (!name || name === scopeName) return;
    scopes[scopeName] = P.step; scopeName = name; P.step = scopes[name] || (name === 'house' ? Math.max(base, 2) : base); t0 = 0; slow = 0; rc = 0; rn = 0; trialUntil = 0;
    quiet = Math.max(quiet, performance.now() + 1500);
    if (P.step < 3 && !watching && document.readyState === 'complete') { watching = true; requestAnimationFrame(watch); }
  };
  P.skipRig = function () { if (P.step === 1) return false; k = (k + 1) % P.step; return k !== 0; };
  // the creatures take turns: each is drawn every P.step frames, 1/P.step of them a frame (rive-rig.js loop, patched)
  P.rigStride = function () { return P.step; };
  // PERF 2026-11-20: freeze: no creature is drawn at all (the house's Catalog book, map or level-up card covers the room:
  // app/menu.js sets it). With the creatures moving under it, the open Catalog was repainted every frame: 66 ms frames,
  // 15 fps on the Galaxy A16.
  P.freeze = false;
  // PERF 2026-11-20: the house starts at step 2 (its 4-5 creatures every frame were ~25 ms on the Galaxy A16: 35 fps for
  // the ~15 s the guard took to step down), and a phone with room to spare goes back to every frame: the loop reports its
  // time each frame (rigCost); at step 2, if drawing ALL the creatures (its time x the step) stays under 7 ms on average
  // for 3 s, step 1 (the rest of the frame, style and paint, costs about as much again). Once per place: a step-up that
  // turns out slow steps down again and stays there. On trial for its first 6 s: the creatures' script time doesn't
  // show what the GPU pays for redrawing them all every frame (the Living Room on the A16: ~15 ms of WebView drawing a
  // frame, 50-58 fps at step 1, which the usual "under 55 for 2 s" let stay), so a single second under 58 fps
  // steps back down. (2026-11-20)
  var rc = 0, rn = 0, rt = 0, upTried = {}, trialUntil = 0;
  P.rigCost = function (ms, N) {
    if (P.step !== 2 || upTried[scopeName] || performance.now() < quiet) { rc = 0; rn = 0; rt = 0; return; }
    var now = performance.now(); if (!rt) rt = now;
    rc += ms * N; rn++;
    if (now - rt < 3000) return;
    if (rn > 60 && rc / rn < 7) { upTried[scopeName] = true; P.step = 1; slow = 0; t0 = 0; trialUntil = now + 6000; if (!watching) { watching = true; requestAnimationFrame(watch); } }
    rc = 0; rn = 0; rt = now;
  };

  // PERF 2026-11-20: the loaders' helpers (app/menu.js, app/games.js)
  // painted(fn): fn runs right after the next frame has been drawn: what is on the page now is on screen (a loader shown
  // by a tap is up before anything heavy starts). A MessageChannel task right after the frame, not a timer: no 4 ms
  // clamp, and it runs before the next frame is due.
  var post = (function () {
    if (typeof MessageChannel !== 'function') return function (f) { setTimeout(f, 0); };
    var q = [], ch = new MessageChannel();
    ch.port1.onmessage = function () { var f = q.shift(); if (f) f(); };
    return function (f) { q.push(f); ch.port2.postMessage(0); };
  })();
  P.post = post;
  P.painted = function (fn) { requestAnimationFrame(function () { post(fn); }); };
  // PERF 2026-11-20: SquishStill(src): an SVG data URI without its SMIL animations (<animate>, <set>…), made once per
  // picture. An animated SVG shown as an image or background is animated by the browser for as long as it shows, and on
  // the phone each of its frames rasters the whole picture again (with its blurs and patterns): the house's Catalog,
  // whose cards are the items' room pictures, drew at 13-20 fps. Used where a still is meant (the Catalog's cards, the
  // item sheet); the room's own furniture keeps moving.
  var stills = typeof Map === 'function' ? new Map() : null;
  var SMIL1 = /<(animate|animateTransform|animateMotion|animateColor|set)\b[^>]*\/>/g;
  var SMIL2 = /<(animate|animateTransform|animateMotion|animateColor)\b[^>]*>[\s\S]*?<\/\1>/g;
  window.SquishStill = function (src) {
      if (!src || typeof src !== 'string' || src.indexOf('data:image/svg+xml') !== 0) return src;
      if (src.indexOf('%3Canimate') < 0 && src.indexOf('%3Cset') < 0 && src.indexOf('<animate') < 0 && src.indexOf('<set') < 0) return src;
      if (stills && stills.has(src)) return stills.get(src);
      var out = src;
      try {
        var i = src.indexOf(','), head = src.slice(0, i + 1), body = src.slice(i + 1);
        var enc = /%[0-9a-fA-F]{2}/.test(body), svg = enc ? decodeURIComponent(body) : body;
        svg = svg.replace(SMIL1, '').replace(SMIL2, '');
        out = head + (enc ? encodeURIComponent(svg) : svg);
      } catch (e) { out = src; }
      if (stills) { if (stills.size > 400) stills.clear(); stills.set(src, out); }
    return out;
  };
  // steady(fn, max): fn runs once frames are really reaching the screen at a normal pace: `n` frames in a row each under
  // 34 ms (or after `max` ms, default 2000). On the phone, the first time a page with big new layers comes up the
  // WebView's GPU thread can be busy for 0.5-1 s making its tiles, and no frame is drawn meanwhile; an animation started
  // on the clock before that played on unseen and was "half way done" when the frames came back (the user, 2026-11-20).
  // Loaders start their motion (and its sounds) from here.
  P.steady = function (fn, max, n) {
    max = max || 2000; n = n || 3;
    var start = performance.now(), last = 0, good = 0, done = false;
    function go() { if (done) return; done = true; fn(); }
    function f(now) {
      if (done) return;
      if (last && now - last < 34) good++; else good = 0;
      last = now;
      if (good >= n || now - start > max) go(); else requestAnimationFrame(f);
    }
    requestAnimationFrame(f);
  };
  // slices(steps, budget): runs the functions one after another, in slices of about `budget` ms (default 6) of the main
  // thread per frame, each slice right after a frame: heavy page building that leaves the frames (and the loader's
  // animations, the page's rig) running. Resolves once all have run; a step returning false stops the rest (the page
  // closed under it).
  P.slices = function (steps, budget) {
    budget = budget || 6;
    var i = 0;
    return new Promise(function (res) {
      function run() {
        var t0 = performance.now();
        while (i < steps.length) {
          var r; try { r = steps[i++](); } catch (e) { console.error('[SquishPerf.slices]', e); }
          if (r === false) { i = steps.length; break; }
          if (performance.now() - t0 > budget) break;
        }
        if (i < steps.length) P.painted(run); else res();
      }
      P.painted(run);
    });
  };

  // The tester's FPS counter (src/components/FpsCounter.js): while the app asks (GameScreen, SquishPerf.meter(true)),
  // this page's own frames go to the app every half second: { fps, low: the slowest frame as fps, lite: creatures
  // drawn less often }. Off unless asked: it costs a frame callback and a message.
  var mt = 0, mlast = 0, mn = 0, mworst = 0, mid = 0;
  function meter(now) {
    mid = requestAnimationFrame(meter);
    if (!mt) { mt = mlast = now; mn = 0; mworst = 0; return; }
    var dt = now - mlast; mlast = now; mn++;
    if (dt > mworst) mworst = dt;
    if (now - mt < 500) return;
    var m = { fps: Math.round((mn * 1000) / (now - mt)), low: Math.round(1000 / Math.max(mworst, 1)), lite: P.step > 1 };
    mt = now; mn = 0; mworst = 0;
    if (window.ReactNativeWebView) window.ReactNativeWebView.postMessage(JSON.stringify({ type: 'fps', payload: m }));
  }
  P.meter = function (on) {
    if (on && !mid) { mt = 0; mid = requestAnimationFrame(meter); }
    else if (!on && mid) { cancelAnimationFrame(mid); mid = 0; }
  };
})();

// House moves on demand (memory, 2026-11-14). The design's house-moves.js builds every creature's own furniture moves
// (sit, lounge, bed, water, play, blocks, cheer…) as keyframe tables when the page loads: all ~86 creatures, ~230 MB of
// live JS memory, while a player has a handful in the house. On a 3-4 GB phone that pressure alone made everything
// stutter, and the build was part of the menu's slow first seconds. Here the builders (build, bedBuild, waterBuild,
// playBuild, bBuild, and house-cx.js's cBuild) keep a creature's calls and run them, in their order, the first time that
// creature is drawn (rive-rig.js asks need(key) before its frame, patched in by webgame/patches.mjs); the shared
// defaults (no key) are built at once. The result is the same tables, only for the creatures that show up.
// Each builder ends by noting the creature in its table (build -> PROF[key], bedBuild -> BED, waterBuild -> WAT,
// playBuild -> PLY, bBuild -> BB, cBuild -> CX), and the later creature files loop over Object.keys(PROF) to call the
// other builders: so a held call notes the creature there at once (with what it was given; the real build, later,
// writes its own value over it), or those files would skip every creature whose build is waiting.
(function () {
  var pend = {}, done = {};
  var TABLE = { build: 'PROF', bedBuild: 'BED', waterBuild: 'WAT', playBuild: 'PLY', bBuild: 'BB', cBuild: 'CX' };
  function wrap(fn, H, name) {
    return function (key, X) {
      if (key == null || key === '' || done[key]) return fn.apply(this, arguments);
      var self = this, args = arguments, T = H[TABLE[name]];
      if (T && !(key in T)) T[key] = X || {};
      (pend[key] || (pend[key] = [])).push(function () { fn.apply(self, args); });
    };
  }
  window.SquishLazy = {
    // house-moves.js, right after it made R.HOUSE and before the creature files' builders run
    house: function (H) {
      ['build', 'bedBuild', 'waterBuild', 'playBuild', 'bBuild'].forEach(function (n) { if (typeof H[n] === 'function') H[n] = wrap(H[n], H, n); });
      // house-cx.js adds cBuild (and its table CX) later: Object.assign(H, { cBuild, CX, ST0 })
      var cb = typeof H.cBuild === 'function' ? wrap(H.cBuild, H, 'cBuild') : H.cBuild;
      Object.defineProperty(H, 'cBuild', { configurable: true, enumerable: true, get: function () { return cb; }, set: function (f) { cb = typeof f === 'function' ? wrap(f, H, 'cBuild') : f; } });
    },
    // a creature is about to be drawn: build its moves now (once)
    need: function (key) {
      if (!key || done[key]) return;
      done[key] = 1;
      var q = pend[key]; if (!q) return;
      delete pend[key];
      q.forEach(function (f) { try { f(); } catch (e) { console.error('[SquishLazy]', key, e); } });
    },
    pending: function () { return Object.keys(pend).length; },
  };
})();
