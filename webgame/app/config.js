// window.SquishConfig: what the admin controls from Firebase, applied inside the design's own engines.
// Loaded after app/bridge.js, before any design script. Plain ES2017.
//
// The config comes from the app (Firestore doc gameConfig/live, see webgame/README.md):
//   {
//     animsOff:  ['dance', ...],                                   // switched off for every creature
//     creatures: { mittens: { on: true, rar: 0, off: ['sit', 'eat_cookie'], gait: 'waddle' }, ... },
//     items:     { 'LIV-011': { cost: 120, lv: 3, on: true }, 'BCH-004': {...}, ... }
//   }
// Anything missing keeps the design's own value: with no config at all the game is exactly the prototype.
//
// Where it plugs in (webgame/patches.mjs puts one call at each spot, nothing else in the design changes):
//   rive-rig.js setState       -> gateState(): every animation any screen plays (menu, house, games, pickers)
//   rive-rig.js idle fidgets   -> filter(): the random idle moves only pick switched-on ones
//   rig-shuffle.js             -> filter(): the menu / picker showcase only picks switched-on moves
//   Squad House v6 hsGet       -> allowed(): furniture actions that are off are skipped like a missing one
//   Squad House v6 loadReno    -> applyItems() / visibleItems(): item prices, unlock levels, hidden items
//   house-walk.js prof         -> walkProfile(): the creature's walk style
(function () {
  var cfg = {}, version = 0;
  var offAll = {}, perKey = {}, memo = new WeakMap();
  // a seat that's switched off falls back to plain sitting, not to standing up (the house would keep re-seating it)
  var SEAT = { lounge: 'sit', watch: 'sit', snuggleL: 'sit', snuggleR: 'sit', sitdown_watch: 'sitdown', pouf: 'sit' };

  function index() {
    offAll = {}; perKey = {};
    (cfg.animsOff || []).forEach(function (n) { offAll[n] = 1; });
    var cs = cfg.creatures || {};
    Object.keys(cs).forEach(function (k) { var o = {}; (cs[k].off || []).forEach(function (n) { o[n] = 1; }); perKey[k] = o; });
    version++;
    memo = new WeakMap();
  }

  var C = {
    get version() { return version; },
    get raw() { return cfg; },
    set: function (next) { cfg = next || {}; index(); C.applyLive(); },

    // off in the admin's creature switch, or in a group that isn't out (the app's config/roster: hiddenKeys)
    creatureOn: function (key) {
      var c = (cfg.creatures || {})[key];
      if (c && c.on === false) return false;
      var hk = window.SquishApp && window.SquishApp.state && window.SquishApp.state.hiddenKeys;
      return !(hk && hk.indexOf(key) >= 0);
    },
    rarity: function (key, fallback) { var c = (cfg.creatures || {})[key]; return c && typeof c.rar === 'number' ? c.rar : fallback; },
    // idle can never be switched off: it is what everything falls back to.
    // "bedin" / "bedout" / "bedwake" (the steps into and out of "bed") follow bed's switch.
    _stem: {},
    allowed: function (key, anim) {
      if (!anim || anim === 'idle' || !version) return true;
      var base = String(anim).split('@')[0];
      var stem = C._stem[base];
      if (stem === undefined) {
        var m = /^(.+?)(in|out|wake)$/.exec(base), S = window.RiveRig && window.RiveRig.STATES;
        stem = m && S && S[m[1]] ? m[1] : null;
        if (S) C._stem[base] = stem;
      }
      var o = perKey[key];
      if (offAll[base] || (o && o[base])) return false;
      if (stem && (offAll[stem] || (o && o[stem]))) return false;
      return true;
    },
    filter: function (key, list) {
      if (!list || (!version)) return list;
      var m = memo.get(list);
      if (!m) { m = {}; memo.set(list, m); }
      var hit = m[key];
      if (hit) return hit;
      return (m[key] = list.filter(function (n) { return C.allowed(key, n); }));
    },
    // rive-rig setState: the state to play instead of a switched-off one
    gateState: function (key, name, STATES) {
      for (var hop = 0; hop < 6 && !C.allowed(key, name); hop++) {
        var st = STATES[name] || {};
        var alt = SEAT[name];
        if (!alt) {
          // eat_cookie -> another food, bath_x -> another bath, poke_head -> another poke
          var m = /^(eat|bath|poke)_/.exec(name);
          if (m) {
            var fam = Object.keys(STATES).filter(function (n) { return n.indexOf(m[0]) === 0 && n.indexOf('@') < 0 && C.allowed(key, n); });
            alt = fam[0];
          }
        }
        name = alt || st.next || 'idle';
      }
      return C.allowed(key, name) && STATES[name] ? name : 'idle';
    },
    // called every frame while a creature walks: keep one copy per creature until the config changes
    _walk: {},
    _walkV: 0,
    walkProfile: function (key, prof) {
      var c = (cfg.creatures || {})[key];
      if (!c || !c.gait || !prof) return prof;
      if (C._walkV !== version) { C._walk = {}; C._walkV = version; }
      var hit = C._walk[key];
      if (hit && hit.src === prof) return hit.p;
      var p = {};
      for (var k in prof) p[k] = prof[k];
      p.g = c.gait;
      C._walk[key] = { src: prof, p: p };
      return p;
    },

    // ---- house items ----
    _rows: null,
    applyItems: function (rows) {
      var items = cfg.items || {};
      rows.forEach(function (r) {
        if (!r.__orig) r.__orig = { cost: r.cost, lv: r.lv };
        var o = items[r.id];
        r.cost = o && typeof o.cost === 'number' ? o.cost : r.__orig.cost;
        r.lv = o && typeof o.lv === 'number' ? o.lv : r.__orig.lv;
      });
      C._rows = rows;
      return rows;
    },
    // hidden items leave the catalog, but ones already bought still draw in the house
    visibleItems: function (rows) {
      var items = cfg.items || {};
      return rows.filter(function (r) { return !(items[r.id] && items[r.id].on === false); });
    },
    // a new config while the house is open: re-price the loaded catalog and redraw
    applyLive: function () {
      var sh = window.__sh;
      if (C._rows) {
        C.applyItems(C._rows);
        if (sh && sh.byId) { sh.rows = C.visibleItems(C._rows); try { sh.setState({}); } catch (e) { /* not mounted */ } }
      }
      if (window.SquishApp) window.SquishApp.emit('configApplied', { version: version });
    },
  };

  // ---- creatures: switched off (nobody owns or sees it) and rarity, applied to the roster (squad-store.js) ----
  var squad = null;
  function applySquad() {
    if (!squad || !squad.ROSTER) return;
    squad.ROSTER.forEach(function (c) {
      if (c.__rar0 === undefined) c.__rar0 = c.rar;
      c.rar = C.rarity(c.key, c.__rar0);
    });
  }
  function hookSquad(Q) {
    if (!Q || Q.__squishConfig) return;
    Q.__squishConfig = 1;
    var owns = Q.owns;
    // squad-store calls API.owns internally too (ownedIds, set progress), so this covers every list of owned creatures
    Q.owns = function (id) { var c = Q.ROSTER && Q.ROSTER[id]; return owns.call(Q, id) && (!c || C.creatureOn(c.key)); };
    applySquad();
  }
  try {
    Object.defineProperty(window, 'SquishSquad', {
      configurable: true, enumerable: true,
      get: function () { return squad; },
      set: function (v) { squad = v; hookSquad(v); },
    });
  } catch (e) { /* already defined: fall back to hooking it when the config arrives */ }

  var set0 = C.set;
  C.set = function (next) { set0(next); applySquad(); hookSquad(window.SquishSquad); };

  window.SquishConfig = C;
  if (window.SquishApp) {
    C.set(window.SquishApp.config);
    window.SquishApp.on('config', function (m) { C.set(m.config); });
  }
})();
