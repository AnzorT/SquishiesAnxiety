// The house's piece drawings at runtime (HOUSE_PORT_PLAN.md stage 5 on): the page's own drawing code (House3D
// house4*.js, RenoDraw reno-*.js, in the JS engine after the rig scripts) behind a small API for C#
// (House/HouseDraw.cs). The page's methods it needs (rnReg, rnDraw, rnOpt, rnLayer, tightBB) and constants are copied
// in verbatim by tools/unity/rig/bundle.mjs where it says PAGE. Plain ES2017.
//
//   __house.init()                          the catalog rows (the page's CSV, RenoDraw.parseCSV + edit), sizes: n rows
//   __house.geo(room)                       the room's scale (BIGR) and the dance room's round edge
//   __house.variant(id, st, txt, rot)       a renovation piece's drawing: JSON { src, srcF, whole (SVG text or ''),
//                                           bb, tb, top } (rot null: the page's default angle)
//   __house.render(t, r, c, v)              House3D.render's box, paths and gradients: JSON (registers 'R:' pieces)
(function (G) {
  'use strict';
  /* PAGE */
  var X = G.House3D, RD = G.RenoDraw;
  var sh = {
    X: X, SZ: { a: {} }, rows: [], byId: new Map(),
    /* PAGE-METHODS */
  };
  function uri(u) {
    if (!u || typeof u !== 'string') return '';
    if (u === 'data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==') return '';
    if (u.indexOf('data:image/svg+xml') !== 0) return u;
    var i = u.indexOf(','), head = u.slice(0, i + 1), body = u.slice(i + 1);
    return /;base64,$/.test(head) ? b64(body) : decodeURIComponent(body);
  }
  // base64 -> UTF-8 text (no atob in a bare JS engine)
  function b64(s) {
    var A = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/', bytes = [], buf = 0, bits = 0;
    for (var i = 0; i < s.length; i++) { var v = A.indexOf(s[i]); if (v < 0) continue; buf = (buf << 6) | v; bits += 6; if (bits >= 8) { bits -= 8; bytes.push((buf >> bits) & 255); } }
    var out = '', j = 0;
    while (j < bytes.length) {
      var b = bytes[j++], cp;
      if (b < 0x80) cp = b; else if (b < 0xe0) cp = ((b & 31) << 6) | (bytes[j++] & 63); else if (b < 0xf0) { cp = ((b & 15) << 12) | ((bytes[j++] & 63) << 6) | (bytes[j++] & 63); }
      else { cp = ((b & 7) << 18) | ((bytes[j++] & 63) << 12) | ((bytes[j++] & 63) << 6) | (bytes[j++] & 63); }
      out += String.fromCodePoint(cp);
    }
    return out;
  }
  // the page registers its pieces (rnRegAll) at load, before any room's scale is set (geo): a registration bakes in the
  // scale of that moment, so pieces are registered here under the engine's first scale whatever room is drawn
  var geo0 = null;
  function reg(id) {
    if (X.CAT['R:' + id]) return X.CAT['R:' + id];
    var s = X.RM.s, e = X.RM.e, b = X.BIG;
    if (geo0) { X.RM.s = geo0.s; X.RM.e = geo0.e; X.BIG = geo0.b; }
    try { return sh.rnReg(id); } finally { X.RM.s = s; X.RM.e = e; X.BIG = b; }
  }
  function plain(o) { return JSON.parse(JSON.stringify(o, function (k, v) { return typeof v === 'function' ? undefined : v; })); }
  G.__house = {
    init: function () {
      X = G.House3D; RD = G.RenoDraw; sh.X = X;
      geo0 = X.RM ? { s: X.RM.s, e: X.RM.e, b: X.BIG } : null;
      Object.keys(X.SZDEF || {}).forEach(function (a) { X.setSize(a, X.SZDEF[a]); });
      sh.SZ.a = Object.assign({}, X.SZDEF || {});
      for (var i = 0; i < RCSV.length; i++) {
        var t = G.__readFile ? G.__readFile(RCSV[i]) : null; if (!t) continue;
        var rows = RD.edit(RD.parseCSV(t)).filter(function (x) { return RMAP[x.room] && !/Doorway|Club Entrance|Entry & Divider/.test(x.slotName); });
        if (rows.length) { sh.rows = rows; sh.byId = new Map(rows.map(function (x) { return [x.id, x]; })); break; }
      }
      return sh.rows.length;
    },
    geo: function (rk) { if (!X || !X.RM) return; X.BIG = BIGR; X.RM.s = BIGR[rk] || 1; X.RM.e = rk === 'dance' ? edgeR : null; },
    variant: function (id, st, txt, rot) {
      var r = sh.byId.get(id); if (!r) return 'null';
      var Dr = sh.rnDraw(r, 0, rot == null ? null : rot, st, txt);
      if (!Dr) return 'null';
      var sF = Dr.srcF && Dr.srcB ? 1 : 0, A = reg(id);
      return JSON.stringify({ src: uri(sF ? Dr.srcB : Dr.src || ''), srcF: sF ? uri(Dr.srcF) : '', whole: uri(Dr.src || ''), bb: Dr.bb || null, tb: A && A.mount ? sh.tightBB(Dr, 1) : null, top: Dr.top || null,
        // what the piece's taps use (stage 5): the players' spots, the fog, the robot vacuum's home
        players: Dr.players ? plain(Dr.players) : null, fog: Dr.fog ? plain(Dr.fog) : null, vac: Dr.vac ? { home: plain(Dr.vac.home), bb: Dr.vac.bb } : null });
    },
    render: function (t, r, c, v) {
      if (String(t).indexOf('R:') === 0) reg(t.slice(2));
      var R = X.render(t, r, c, v || ''); if (!R) return 'null';
      var grads = {}; (R.gids || []).forEach(function (g) { var q = X._GR && X._GR.get(g); if (q) grads[g] = plain(q); });
      var D = X.CAT[t] || {};
      return JSON.stringify({ bb: R.bb, vb: R.vb, gids: R.gids, back: D.reno ? [] : plain(R.back), part: D.reno ? [] : plain(R.part), front: D.reno ? [] : plain(R.front), glow: R.glow || null, face: R.face, shadow: R.shadow, contact: R.contact, foot: R.foot, grads: grads });
    },
    // a renovation piece's registered table entry (the C# piece table's row, for pieces the export didn't have)
    piece: function (id) { var A = reg(id); return A ? JSON.stringify(plain(A)) : 'null'; },
  };
})(typeof globalThis !== 'undefined' ? globalThis : this);
