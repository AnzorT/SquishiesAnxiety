// The creatures' border looks on the LIVE rigs (2026-11-16, the user: "the character himself does not have the look 3,
// for example look at the character at main menu"). The look picked in Firestore config/roster (src/squad/looks.js:
// `look` for everyone, `looks` per creature) already swaps every still picture; this gives the animated creature the
// same outline while it moves:
//   1 shading only: no line (the rig as the design drew it) · 2 thin ink line · 3 bold ink line · 4 bold colour line
//   0 the old pictures: no line either
// The line goes round the creature's outer edge: an SVG filter (the creature's shape, grown by the line's width, in the
// line's colour, under the creature) on the group that holds the whole creature but not its floor shadow. The look
// pictures also draw a line where an arm crosses the body; the rigs' parts are built too differently from creature to
// creature to outline each one safely, so a live rig has its outline only. Colours: tools/looks/lines.py
// (look-lines.js), measured in the pictures; widths below, also measured there (in the rig's 100-unit box, so the line
// grows and shrinks with the creature like the picture's).
// Used by the game's pages (every RiveRig.mount: the menu, Characters, the house, the loaders; the look follows the
// app's state.looks live) and by the app's own rig page (android assets/rig/host.html: rigHost.look(n)).
(function () {
  if (window.RigLook) return;
  var NS = 'http://www.w3.org/2000/svg';
  var WIDTH = { 2: 0.6, 3: 1, 4: 1 };
  var uid = 0;

  // the line for a creature in look n, or null (no line)
  function lineOf(key, n) {
    var c = (window.SQ_LOOK_LINES || {})[key];
    if (!c || !WIDTH[n]) return null;
    return { w: WIDTH[n], col: n === 4 ? c[1] : c[0] };
  }

  // the group holding the whole creature: the one after its floor shadow (both rig kinds: the design's own rigs, where
  // it is I.root, and the generic ones built from the creature's art)
  function body(I) {
    var sh = I && I.shadow, g = sh && sh.parentNode ? sh.nextElementSibling : null;
    return g && g.tagName === 'g' ? g : null;
  }

  function mk(tag, attrs, parent) {
    var e = document.createElementNS(NS, tag);
    for (var a in attrs) e.setAttribute(a, attrs[a]);
    if (parent) parent.appendChild(e);
    return e;
  }

  // the outline filter: the creature's solid parts (faint glows and halos left out, so they get no ring), grown by the
  // line's width, filled with its colour, under the creature
  function filterFor(g) {
    var f = g.__sqLook;
    if (f && f.isConnected) return f;
    var svg = g.ownerSVGElement, defs = svg.querySelector('defs') || svg.insertBefore(document.createElementNS(NS, 'defs'), svg.firstChild);
    f = mk('filter', { id: 'sqlook' + (++uid), x: '-15%', y: '-15%', width: '130%', height: '130%', 'color-interpolation-filters': 'sRGB' }, defs);
    var a = mk('feComponentTransfer', { in: 'SourceAlpha', result: 'a' }, f);
    mk('feFuncA', { type: 'linear', slope: '2.5', intercept: '-0.5' }, a);
    f.__m = mk('feMorphology', { in: 'a', operator: 'dilate', radius: '0.8', result: 'd' }, f);
    f.__c = mk('feFlood', { 'flood-color': '#3f2f26' }, f);
    mk('feComposite', { in2: 'd', operator: 'in', result: 'o' }, f);
    var m = mk('feMerge', {}, f);
    mk('feMergeNode', { in: 'o' }, m);
    mk('feMergeNode', { in: 'SourceGraphic' }, m);
    g.__sqLook = f;
    return f;
  }

  // Draws (or takes off) the line on a mounted rig now. False: its creature isn't built yet.
  function paint(ctrl, key, n) {
    var I = ctrl && ctrl._I, g = body(I);
    if (!g) return false;
    var L = lineOf(key, n);
    if (!L) { g.style.filter = ''; return true; }
    var f = filterFor(g);
    f.__m.setAttribute('radius', L.w);
    f.__c.setAttribute('flood-color', L.col);
    // the rig's own filter on that group (its fabric grain) stays, first ("none": the art's grain taken off by the build,
    // webgame/build.mjs noGrain; "none url(#…)" would be invalid and drop the line too)
    var own = g.getAttribute('filter');
    if (own === 'none') own = '';
    g.style.filter = (own ? own + ' ' : '') + 'url(#' + f.id + ')';
    return true;
  }

  // A generic creature builds its parts after its art has loaded: retry until they're there (8 s at most).
  function apply(ctrl, key, n) {
    if (!ctrl) return;
    ctrl.__sqLookN = n;
    var tries = 0;
    (function go() {
      if (ctrl.__sqLookN !== n) return; // a newer look took over
      if (!paint(ctrl, key, n) && ++tries < 270) setTimeout(go, 30);
    })();
  }

  window.RigLook = { apply: apply, lineOf: lineOf, WIDTH: WIDTH };

  // ---- the game's pages: every rig mounted gets the look the app's state gives its creature, and follows it ----
  var App = window.SquishApp;
  if (!App) return;
  // state.looks (src/game/player.js, src/squad/looks.js menuLooks): { n, over: { key: n }, keys: [the creatures with looks] }
  function lookFor(key) {
    var L = App.state && App.state.looks;
    if (!L || !L.keys || L.keys.indexOf(key) < 0) return 0;
    return L.over && L.over[key] != null ? L.over[key] : L.n;
  }
  var live = [];
  // still on the page (or still being built)
  function alive(r) { var I = r.c._I; return !!I && (!I.shadow || I.shadow.isConnected); }
  function track(ctrl, key) {
    if (!ctrl || !key) return;
    live = live.filter(function (r) { return r.c !== ctrl && alive(r); });
    live.push({ c: ctrl, k: key });
    apply(ctrl, key, lookFor(key));
  }
  var last = '';
  App.on('state', function () {
    var now = JSON.stringify((App.state && App.state.looks) || null);
    if (now === last) return;
    last = now;
    live = live.filter(alive);
    live.forEach(function (r) { apply(r.c, r.k, lookFor(r.k)); });
  });
  // RiveRig arrives later (the page's own scripts, after this one): catch it as it's set and wrap its mount
  var rig = window.RiveRig;
  // (2026-11-18) The rig from the yard games' zip (rive-rig v1115+) has the design's own looks built in, on by default
  // (look 4 on every creature). In the app the look comes from Firebase, drawn by this file, so the built-in one is off
  // (0 = the rig as before). A rig mounted with its own look (the yard games' intro posters: look 3, the user's pick)
  // keeps it and gets no second line from here.
  function wrap(R) {
    if (!R || R.__sqLook || typeof R.mount !== 'function') return R;
    if (typeof R.setLook === 'function') try { R.setLook(0); } catch (e) { console.error('[RigLook]', e); }
    var mount = R.mount;
    R.mount = function (host, key, o) { var c = mount.apply(this, arguments); try { if (!(o && o.look != null)) track(c, key); } catch (e) { console.error('[RigLook]', e); } return c; };
    R.__sqLook = true;
    return R;
  }
  try {
    Object.defineProperty(window, 'RiveRig', { configurable: true, enumerable: true, get: function () { return rig; }, set: function (R) { rig = wrap(R); } });
    if (rig) wrap(rig);
  } catch (e) { console.error('[RigLook]', e); }
})();
