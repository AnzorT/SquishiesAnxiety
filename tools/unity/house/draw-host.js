// The house's piece drawings at runtime (HOUSE_PORT_PLAN.md stage 5 on): the page's own drawing code (House3D
// house4*.js, RenoDraw reno-*.js, in the JS engine after the rig scripts) behind a small API for C#
// (House/HouseDraw.cs). The page's methods it needs (rnReg, rnDraw, rnOpt, rnLayer, tightBB) and constants are copied
// in verbatim by tools/unity/rig/bundle.mjs where it says PAGE. Plain ES2017.
//
//   __house.init()                          the catalog rows (the page's CSV, RenoDraw.parseCSV + edit), sizes: n rows
//   __house.geo(room)                       the room's scale (BIGR) and the dance room's round edge
//   __house.variant(id, st, txt, rot)       a renovation piece's drawing: JSON { src, srcF, whole (SVG text or ''),
//                                           bb, tb, top } (rot null: the page's default angle)
//   __house.vac(id, rot)                    the robot vacuum's sprite (the page's Dr.vac, what VacBot drives round the
//                                           room) for the dock at rot: JSON { src (SVG text, its SMIL kept: the brushes,
//                                           the lidar, the eyes and the LED move), bb, home }
//   __house.render(t, r, c, v)              House3D.render's box, paths and gradients: JSON (registers 'R:' pieces)
//   __house.shell(rk, sf, locks)            House3D.shell: the room's shell (walls, floor, ceiling light) for the room's
//                                           surfaces sf ({ slot: id, lx, lz }) and its doors' lock levels ({ to: lv })
//   __house.tex(id)                         a renovated surface's textures, as the export's tex.json entry (pictures as
//                                           SVG text; stage 6)
//   __house.beach(o)                        the Beach's scene for o = { season, night, sand, pier, light } (defs, body:
//                                           SVG with SMIL), its props, the shells, the fishing sign, the board and the rod
//                                           (stage 10): JSON
//   __house.map(st)                         the house map's values (the page's mapVals, natMap, lockVals; stage 8) for
//                                           st = { lvl, cur, open: [rooms], b0: { room: shell colour }, cs: [{ key,
//                                           name, room, N }], season, mapHov, mapGo, mapIn }: JSON
(function (G) {
  'use strict';
  /* PAGE */
  var X = G.House3D, RD = G.RenoDraw;
  var sh = {
    X: X, SZ: { a: {} }, rows: [], byId: new Map(), texC: {},
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
  // the house map's methods (stage 8), called on a stand-in for the page's component (__house.map)
  var mp = {
    /* PAGE-MAP */
  };
  function plain(o) { return JSON.parse(JSON.stringify(o, function (k, v) { return typeof v === 'function' ? undefined : v; })); }
  G.__house = {
    init: function () {
      X = G.House3D; RD = G.RenoDraw; sh.X = X;
      geo0 = X.RM ? { s: X.RM.s, e: X.RM.e, b: X.BIG } : null;
      Object.keys(X.SZDEF || {}).forEach(function (a) { X.setSize(a, X.SZDEF[a]); });
      sh.SZ.a = Object.assign({}, X.SZDEF || {});
      // the page's initH: windows and art on the walls are renovation pieces now, not part of the shell
      (X.RKEYS || []).forEach(function (rk) { var R = X.ROOMS[rk]; if (!R || R.out || R._w31) return; R._w31 = 1; R.winX0 = R.winX; R.winX = null; R.artX0 = R.artX; R.artX = null; R.fixed = (R.fixed || []).filter(function (a) { return a[0] === 'hwin'; }); });
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
        players: Dr.players ? plain(Dr.players) : null, fog: Dr.fog ? plain(Dr.fog) : null, vac: Dr.vac ? { home: plain(Dr.vac.home), bb: Dr.vac.bb } : null,
        // the screen's picture box (stage 9: the movie's quad): { w, h, m: [a, b, c, d, e, f] }
        screen: Dr.screen ? plain(Dr.screen) : null });
    },
    vac: function (id, rot) {
      var r = sh.byId.get(id); if (!r) return 'null';
      var Dr = sh.rnDraw(r, 0, rot == null ? null : rot, '', '');
      if (!Dr || !Dr.vac) return 'null';
      return JSON.stringify({ src: uri(Dr.vac.src), bb: Dr.vac.bb, home: plain(Dr.vac.home) });
    },
    render: function (t, r, c, v) {
      if (String(t).indexOf('R:') === 0) reg(t.slice(2));
      var R = X.render(t, r, c, v || ''); if (!R) return 'null';
      var grads = {}; (R.gids || []).forEach(function (g) { var q = X._GR && X._GR.get(g); if (q) grads[g] = plain(q); });
      var D = X.CAT[t] || {};
      return JSON.stringify({ bb: R.bb, vb: R.vb, gids: R.gids, back: D.reno ? [] : plain(R.back), part: D.reno ? [] : plain(R.part), front: D.reno ? [] : plain(R.front), glow: R.glow || null, face: R.face, shadow: R.shadow, contact: R.contact, foot: R.foot, grads: grads });
    },
    shell: function (rk, sf, locks) {
      var L = JSON.parse(locks || '{}'), Sh = X.shell(rk, JSON.parse(sf || '{}'), function (to) { return L[to] || 0; });
      return Sh ? JSON.stringify(plain(Sh)) : 'null';
    },
    tex: function (id) {
      var r = sh.byId.get(id); if (!r) return 'null'; var D0 = sh.rnDraw(r, 0) || {}, T = function (k) { return uri(sh.rnTex(id, k)); };
      return JSON.stringify({ wall: T('wall'), wallS: T('wallS'), board: T('board'), floor: T('floor'), ceil: T('ceil'), fence: T('fence'), fenceR: T('fenceR'),
        fW: D0.fW || 0, fWR: D0.fWR || 0, ceilRoom: !!D0.ceilRoom, ceilBase: D0.ceilBase || '', ceilTrim: D0.ceilTrim || '', wallOne: uri(D0.wallOne || ''), wallOneR: uri(D0.wallOneR || ''), wallOneFull: !!D0.wallOneFull, wallRnd: uri(D0.wallRnd || ''),
        floorRoom: D0.floorRoom ? { bg: D0.floorRoom.bg, layers: D0.floorRoom.layers.map(function (l) { return Object.assign({}, l, { url: uri(l.url) }); }) } : null, ylRoom: uri(D0.ylRoom || ''), win19: !!D0.win19, src: uri(D0.src || ''),
        wallL: D0.wallL || '', wallR: D0.wallR || '', wallRoom: D0.wallRoom || '', fH: D0.fH || 0 });
    },
    beach: function (oJson) {
      var BE = G.Beach; if (!BE) return 'null'; var o = JSON.parse(oJson || '{}'); BE.setSeason(o.season);
      var dec = function (u) { u = String(u || ''); return u.indexOf('data:image/svg+xml,') === 0 ? decodeURIComponent(u.slice(19)) : u; };
      var sc = BE.scene(o), props = BE.props({ season: o.season }).map(function (q) { return { id: q.id, x: q.x, y: q.y, w: q.w, h: q.h, ax: q.ax, ay: q.ay, src: dec(q.src) }; });
      return JSON.stringify({ defs: sc.defs, body: sc.body, props: props, shells: [0, 1, 2, 3, 4].map(function (k) { return dec(BE.shellSvg(k)); }), fish: dec(FISHB), board: BOARDH, rod: RODH });
    },
    map: function (stJson) {
      var st = JSON.parse(stJson), open = {}; (st.open || []).forEach(function (r) { open[r] = 1; });
      var me = { X: X, props: {}, state: { cur: st.cur, mapHov: st.mapHov || null, mapGo: st.mapGo || null, mapIn: !!st.mapIn }, cs: st.cs || [], _nat: mp._nat,
        lvl: function () { return st.lvl; }, isOpen: function (r) { return !!open[r]; }, seasonNow: function () { return st.season; },
        shellOf: function (r) { return { P: { b0: (st.b0 || {})[r] } }; }, lowest: mp.lowest, lockVals: mp.lockVals };
      var v = mp.mapVals.call(me, {}); mp._nat = me._nat;
      v.mx.nat = me._nat; return JSON.stringify(plain(v));
    },
    // a renovation piece's registered table entry (the C# piece table's row, for pieces the export didn't have)
    piece: function (id) { var A = reg(id); return A ? JSON.stringify(plain(A)) : 'null'; },
  };
})(typeof globalThis !== 'undefined' ? globalThis : this);
