// window.SquishApp: the link between the in-app game (these pages) and the React Native app around it.
// Loaded right after app/boot.js, before support.js and before any design script. Plain ES2017.
//
// app -> game: the app sets window.__SQUISH_INIT__ before the page loads (WebView injectedJavaScriptBeforeContentLoaded)
//              and later calls window.SquishApp.receive({ type, ... }) (WebView injectJavaScript).
// game -> app: window.SquishApp.send(type, payload) -> window.ReactNativeWebView.postMessage(JSON).
// The messages are listed in webgame/README.md.
//
// The player belongs to the app (Firestore users/{uid}); the design's engines keep their own copy in localStorage.
// Before the engines load, this file writes the app's player into those localStorage keys, and it watches the keys
// to tell the app when the game changes them (coins spent in the house catalog, the house layout).
(function () {
  var init = window.__SQUISH_INIT__ || {};
  var subs = {};
  var KEYS = window.__SQUISH_ROSTER_KEYS || []; // roster id -> creature key (app/roster.js, written by the build)
  var PROFILE = 'squishsquad.profile.v1', COLLECTION = 'squishsquad.collection.v1', HOUSE = 'ssHouse5b', LOBBY = 'squishsquad.lobby.v1';
  var ls = window.localStorage;
  var rawSet = Storage.prototype.setItem;
  var quiet = 0; // > 0 while this file writes, so its own writes aren't reported back to the app

  function readJSON(k) { try { return JSON.parse(ls.getItem(k)); } catch (e) { return null; } }
  function write(k, v) { quiet++; try { rawSet.call(ls, k, typeof v === 'string' ? v : JSON.stringify(v)); } catch (e) { /* storage full */ } quiet--; }

  var App = {
    inApp: !!window.ReactNativeWebView,
    screen: init.screen || null,
    // the player: { level, coins, gems, owned: [creature keys], col: { key: { f, eq, st } }, sel: key,
    //              hiddenKeys: [creature keys not out], games: [...], house: '<ssHouse5b JSON>' }
    state: init.state || {},
    config: init.config || {},   // the admin's remote config (Firestore config/game), applied by app/config.js
    send: function (type, payload) {
      var msg = JSON.stringify({ type: type, payload: payload === undefined ? null : payload });
      if (window.ReactNativeWebView) window.ReactNativeWebView.postMessage(msg);
      else if (window.__squishOutbox) window.__squishOutbox.push(JSON.parse(msg)); // tests
    },
    on: function (type, fn) {
      (subs[type] = subs[type] || []).push(fn);
      return function () { subs[type] = (subs[type] || []).filter(function (f) { return f !== fn; }); };
    },
    emit: function (type, data) { (subs[type] || []).slice().forEach(function (fn) { try { fn(data); } catch (e) { console.error('[SquishApp]', type, e); } }); },
    // the app calls this
    receive: function (msg) {
      if (!msg || !msg.type) return;
      if (msg.type === 'state') { App.state = Object.assign({}, App.state, msg.state); applyLive(msg.state || {}); }
      if (msg.type === 'config') App.config = msg.config || {};
      if (msg.type === 'screen') App.screen = msg.screen;
      App.emit(msg.type, msg);
    },
    // Android back button: close what's on top (the house, a game, the games page, the picker), like its own back
    // button would. Nothing open: tell the app (it leaves the app).
    back: function () {
      var hb = document.querySelector('.mm-hback');
      if (hb) { hb.click(); return true; }
      var xs = document.querySelectorAll('[data-x]');
      if (xs.length) { xs[xs.length - 1].click(); return true; }
      var pk = document.querySelector('.mm-pick');
      if (pk) { pk.click(); return true; }
      App.send('backUnhandled');
      return false;
    },
    // roster id <-> key
    idOf: function (key) { var i = KEYS.indexOf(key); return i < 0 ? null : i; },
    keyOf: function (id) { return KEYS[id] || null; },
  };
  window.SquishApp = App;

  // ---- 1. the app's player -> the engines' localStorage (before they load) ----
  var lastCoins = null, lastSel = null;
  function seed(st) {
    if (!st || !App.inApp && !window.__squishOutbox) return; // a plain browser keeps the prototype's own demo save
    var p = readJSON(PROFILE) || {};
    if (typeof st.level === 'number') p.level = st.level;
    if (typeof st.coins === 'number') { p.coins = st.coins; lastCoins = st.coins; }
    p.owned = []; // ownership lives in the collection below (the profile's list is the old 30-creature one)
    write(PROFILE, p);
    if (st.owned || st.col) {
      var c = readJSON(COLLECTION) || {};
      if (c.v !== 1) c = { v: 1, fp11: 1, gems: 600, stars: 180, pity: 18, epic: 4, col: {} };
      var col = {};
      // the app's collection entries (finishes, growth stage) when it sends them, else plain ones
      var entry = function (key, id) {
        var e = st.col && st.col[key];
        return e ? { f: e.f || { n: 1 }, eq: e.eq || 'n', st: e.st || 0, xp: (c.col && c.col[id] && c.col[id].xp) || 0 } : (c.col && c.col[id]) || { f: { n: 1 }, eq: 'n', st: 0, xp: 0 };
      };
      (st.owned || Object.keys(st.col)).forEach(function (key) { var id = App.idOf(key); if (id != null) col[id] = entry(key, id); });
      c.col = col;
      if (typeof st.gems === 'number') c.gems = st.gems;
      write(COLLECTION, c);
    }
    if (st.sel) {
      var sid = App.idOf(st.sel), lb = readJSON(LOBBY) || { seen: [] };
      if (sid != null) { lb.sel = sid; lastSel = sid; write(LOBBY, lb); }
    }
    if (typeof st.house === 'string' && st.house) write(HOUSE, st.house);
  }
  seed(App.state);
  if (lastCoins == null) { var p0 = readJSON(PROFILE); lastCoins = p0 && typeof p0.coins === 'number' ? p0.coins : null; }

  // ---- 2. the engines' changes -> the app ----
  var houseT = 0;
  Storage.prototype.setItem = function (k, v) {
    rawSet.call(this, k, v);
    if (quiet || this !== ls) return;
    if (k === PROFILE) {
      var p = null; try { p = JSON.parse(v); } catch (e) { /* not ours */ }
      if (p && typeof p.coins === 'number' && p.coins !== lastCoins) {
        var delta = lastCoins == null ? 0 : p.coins - lastCoins;
        lastCoins = p.coins;
        App.send('coins', { coins: p.coins, delta: delta });
      }
    } else if (k === LOBBY) {
      // the creature picked on the menu (CREATURES): the app keeps it as the player's selected squishy
      var lb = null; try { lb = JSON.parse(v); } catch (e) { /* not ours */ }
      if (lb && lb.sel != null && lb.sel !== lastSel) { lastSel = lb.sel; App.send('select', { id: lb.sel, key: App.keyOf(lb.sel) }); }
    } else if (k === HOUSE) {
      // the house saves on every change: tell the app once things settle
      clearTimeout(houseT);
      houseT = setTimeout(function () { App.send('house', { data: ls.getItem(HOUSE) }); }, 1500);
    }
  };

  // ---- 3. the app's live changes (coins earned elsewhere, a level up) -> the running engines ----
  function applyLive(st) {
    // a creature the player just got (a box, the shop): the engines learn it like one won in a chest
    if (st.owned && window.SquishSquad && window.SquishSquad.grant) {
      var Q0 = window.SquishSquad;
      st.owned.forEach(function (key) { var id = App.idOf(key); if (id != null && !Q0.owns(id)) Q0.grant(id); });
    }
    if (typeof st.gems === 'number' && window.SquishSquad && window.SquishSquad.setWallet) {
      quiet++;
      try { window.SquishSquad.setWallet({ gems: st.gems }); } finally { quiet--; }
    }
    if (st.hiddenKeys) window.dispatchEvent(new CustomEvent('squishsquad'));
    if (typeof st.coins === 'number') {
      lastCoins = st.coins;
      var Q = window.SquishSquad;
      quiet++;
      try { if (Q && Q.setWallet) Q.setWallet({ coins: st.coins }); else seed({ coins: st.coins }); } finally { quiet--; }
      if (window.__sh && window.__sh.coinCount) try { window.__sh.setState({ coins: window.__sh.coinCount() }); } catch (e) { /* house not mounted */ }
      window.dispatchEvent(new CustomEvent('squishsquad'));
    }
    if (typeof st.level === 'number' && window.SquishProfile) {
      quiet++;
      try { window.SquishProfile.set({ level: st.level }); } finally { quiet--; }
      if (window.__sh && window.__sh.setLv) try { window.__sh.setLv(st.level); } catch (e) { /* house not mounted */ }
    }
  }

  window.addEventListener('error', function (e) { App.send('error', { message: String(e.message || e), file: e.filename, line: e.lineno }); });
  window.addEventListener('unhandledrejection', function (e) { App.send('error', { message: 'unhandled rejection: ' + String(e.reason && e.reason.message || e.reason) }); });
})();
