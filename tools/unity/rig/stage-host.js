// Unity's side of the mini-games' rig stages: tools/rig/sort.html and hop.html, each page's own script compiled into
// the rig's realm by tools/unity/rig/jsc.mjs (stagePage: in a window of its own, G.__stages[page]). Creatures/RigStage.cs
// calls these; the page itself is unchanged, and RigStage.js's postMessage calls become call():
//   size(page, w, h)      the play area, dp (the page's window.innerWidth / innerHeight)
//   ready(page)           whether the page has booted (window.<page>Stage is up)
//   call(page, fn, json)  one of the stage's calls (sortStage.cast, hold, correct...; hopStage.hop, bump...), its
//                         arguments as a JSON array
//   out(page)             what the page posted since the last call (ready, cast, error), as a JSON array
//   read(page)            each squishy as the page placed it now, bottom to top as the page stacks them (z-index, then
//                         the order they were added): [id, key, host, a, b, c, d, e, f, opacity, z, drawn, shadow...]
//                         with (a..f) the .ch box's CSS transform (its 0-100 box onto the play area), `drawn` 1 when
//                         its rig drew this frame (the page only lets the moving ones draw: rive-generic's I.ready),
//                         then for sort.html's floor shadow (.sh) its transform (a..f), opacity and z (else nothing)
//   clip(page)            the board's clip-path (sort.html's doors shutting): [left, right] px of the play area kept,
//                         or null
// Plain ES2017.
(function (G) {
  'use strict';
  var S = G.__stages || (G.__stages = {});
  function api(page) { var s = S[page]; return (s && s.win[page + 'Stage']) || null; }
  // a CSS transform list (translate / scale / rotate, px and deg) as a matrix [a, b, c, d, e, f]
  var RE = /(translate|scale|rotate)\(([^)]*)\)/g;
  function matrix(tf) {
    var m = [1, 0, 0, 1, 0, 0], r;
    RE.lastIndex = 0;
    while ((r = RE.exec(tf || ''))) {
      var a = r[2].split(','), t;
      for (var i = 0; i < a.length; i++) a[i] = parseFloat(a[i]);
      if (r[1] === 'translate') t = [1, 0, 0, 1, a[0], a.length > 1 ? a[1] : 0];
      else if (r[1] === 'scale') t = [a[0], 0, 0, a.length > 1 ? a[1] : a[0], 0, 0];
      else { var q = a[0] * Math.PI / 180, c = Math.cos(q), s = Math.sin(q); t = [c, s, -s, c, 0, 0]; }
      m = [m[0] * t[0] + m[2] * t[1], m[1] * t[0] + m[3] * t[1], m[0] * t[2] + m[2] * t[3], m[1] * t[2] + m[3] * t[3], m[0] * t[4] + m[2] * t[5] + m[4], m[1] * t[4] + m[3] * t[5] + m[5]];
    }
    return m;
  }
  function num(v, d) { var n = parseFloat(v); return isNaN(n) ? d : n; }

  G.__stage = {
    size: function (page, w, h) { var s = S[page]; if (s) { s.win.innerWidth = w; s.win.innerHeight = h; } },
    ready: function (page) { return !!api(page); },
    call: function (page, fn, json) {
      var a = api(page); if (!a || typeof a[fn] !== 'function') return false;
      a[fn].apply(a, json ? JSON.parse(json) : []);
      return true;
    },
    out: function (page) {
      var s = S[page]; if (!s) return '[]';
      var k = '__' + page + 'Out', o = s.win[k];
      if (!o || !o.length) return '[]';
      s.win[k] = [];
      return JSON.stringify(o);
    },
    read: function (page) {
      var a = api(page), out = []; if (!a || !a._C) return out;
      a._C.forEach(function (c) {
        if (!c.el) return;
        var st = c.el.style, m = matrix(st.transform), I = c.I;
        var row = [c.id, c.key, c.inner, m[0], m[1], m[2], m[3], m[4], m[5], num(st.opacity, 1), num(st.zIndex, 0), (!I || !I.generic || I.ready) ? 1 : 0];
        if (c.sh) { var ss = c.sh.style, sm = matrix(ss.transform); row.push(sm[0], sm[1], sm[2], sm[3], sm[4], sm[5], num(ss.opacity, 1), num(ss.zIndex, 0)); }
        out.push(row);
      });
      return out;
    },
    host: function (page, id) { var a = api(page), c = a && a._C && a._C.get(id); return c ? c.inner : null; },
    clip: function (page) {
      var s = S[page]; if (!s) return null;
      var cp = s.board.style.clipPath; if (!cp) return null;
      var r = /inset\(([^)]*)\)/.exec(cp); if (!r) return null;
      var v = r[1].trim().split(/\s+/), W = s.win.innerWidth;
      // inset(top right bottom left): px, or a % of the width
      var px = function (x) { return /%$/.test(x) ? parseFloat(x) / 100 * W : parseFloat(x); };
      var right = px(v[1] || v[0]), left = px(v[3] || v[1] || v[0]);
      return [left, W - right];
    },
  };
})(typeof globalThis !== 'undefined' ? globalThis : this);
