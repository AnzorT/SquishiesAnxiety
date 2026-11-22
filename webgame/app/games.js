// The app's games on the design's own Mini Games page, and the Yard Games button in the backyard.
// Loaded after app/config.js, before any design script. Plain ES2017.
//
// PLAY / GAMES on the Main Menu opens the design's Mini Games page (main-menu.js, patched in webgame/patches.mjs)
// with the app's games instead of the yard games: Squish Time (the design's own card) and what the app lists in
// SquishApp.state.games ({ id, name, item, best, color, open }), e.g. Squishdoku "Level 37 / 600". PLAY on one sends
// 'play' { mode: id } to the app, which opens that game.
//
// The 7 yard games are only in the backyard: a "Yard Games" button in the house's backyard opens the same page
// with them (MainMenu instance .games('yard')), over the house.
(function () {
  var App = window.SquishApp;
  if (!App) return;

  // ---- the cards' pictures: 120 x 84 scenes in the style of the design's yard-game icons ----
  function heads(n) {
    var Q = window.SquishSquad, T = window.SQ_THUMBS || {}, out = [];
    if (!Q || !Q.src) return out;
    var ids = (Q.ownedIds ? Q.ownedIds() : []).concat([1, 0, 2, 3, 6, 12]);
    for (var i = 0; i < ids.length && out.length < n; i++) {
      var s = Q.src(ids[i]);
      if (s && out.indexOf(T[s] || s) < 0) out.push(T[s] || s);
    }
    return out;
  }
  function img(href, x, y, w, h) { return href ? '<image href="' + href + '" x="' + x + '" y="' + y + '" width="' + w + '" height="' + h + '" preserveAspectRatio="xMidYMid meet"/>' : ''; }
  var ICONS = {
    squishdoku: function () {
      var H = heads(4), P = ['#ffd3ec', '#d6f4c4', '#fff0b0', '#dcd0ff'];
      var patch = [0, 0, 1, 1, 0, 2, 2, 1, 3, 2, 2, 1, 3, 3, 3, 1], cells = '', at = [1, 7, 8, 14];
      for (var i = 0; i < 16; i++) {
        var x = 30 + (i % 4) * 15, y = 12 + Math.floor(i / 4) * 15;
        cells += '<rect x="' + x + '" y="' + y + '" width="14" height="14" rx="3" fill="' + P[patch[i]] + '"/>';
      }
      var hs = at.map(function (c, k) { return img(H[k % Math.max(1, H.length)], 30 + (c % 4) * 15, 11 + Math.floor(c / 4) * 15, 14, 14); }).join('');
      return '<svg viewBox="0 0 120 84" aria-hidden="true"><rect width="120" height="84" fill="#c9f1ff"/><circle cx="104" cy="14" r="22" fill="#e6f9ff"/>'
        + '<rect x="25" y="7" width="70" height="70" rx="9" fill="#ffffff" stroke="#6ccbea" stroke-width="2.5"/>' + cells + hs + '</svg>';
    },
    sort: function () {
      var H = heads(3);
      return '<svg viewBox="0 0 120 84" aria-hidden="true"><rect width="120" height="84" fill="#ffe3bd"/><rect y="70" width="120" height="14" fill="#f5c68c"/>'
        + '<rect x="33" y="4" width="54" height="76" rx="8" fill="#f8fbff" stroke="#c4d2e4" stroke-width="2.5"/><path d="M33 30H87" stroke="#c4d2e4" stroke-width="2.5"/>'
        + '<rect x="79" y="12" width="3" height="12" rx="1.5" fill="#aebdd2"/><rect x="79" y="36" width="3" height="16" rx="1.5" fill="#aebdd2"/>'
        + '<path d="M38 56H74M38 74H74" stroke="#d7e2ef" stroke-width="2"/>' + img(H[0], 38, 38, 18, 18) + img(H[1], 56, 38, 18, 18) + img(H[2], 46, 57, 17, 17)
        + '<path d="M95 18 l4 -8 l4 8 M92 30 l3 -5" stroke="#ffffff" stroke-width="3" stroke-linecap="round" fill="none"/></svg>';
    },
    stack: function () {
      var H = heads(1);
      return '<svg viewBox="0 0 120 84" aria-hidden="true"><rect width="120" height="84" fill="#e8dcff"/><rect y="74" width="120" height="10" fill="#cbb8f2"/>'
        + '<rect x="24" y="62" width="72" height="14" rx="7" fill="#ff9ccf"/><rect x="24" y="62" width="72" height="5" rx="2.5" fill="#ffc4e2"/>'
        + '<rect x="33" y="48" width="54" height="14" rx="7" fill="#8fd2ff"/><rect x="33" y="48" width="54" height="5" rx="2.5" fill="#bfe6ff"/>'
        + '<rect x="42" y="34" width="36" height="14" rx="7" fill="#ffdc6e"/><rect x="42" y="34" width="36" height="5" rx="2.5" fill="#fff0b3"/>'
        + img(H[0], 45, 4, 30, 30) + '</svg>';
    },
    hop: function () {
      var H = heads(1);
      return '<svg viewBox="0 0 120 84" aria-hidden="true"><rect width="120" height="84" fill="#cdf5ea"/><path d="M0 58 Q60 44 120 58 V84 H0Z" fill="#9fe0b0"/>'
        + '<ellipse cx="18" cy="70" rx="12" ry="5" fill="#ff9ccf"/><ellipse cx="46" cy="62" rx="12" ry="5" fill="#8fd2ff"/><ellipse cx="74" cy="62" rx="12" ry="5" fill="#ffdc6e"/>'
        + '<path d="M100 56 l3.5 7 7.7 1.1 -5.6 5.4 1.3 7.7 -6.9 -3.6 -6.9 3.6 1.3 -7.7 -5.6 -5.4 7.7 -1.1Z" fill="#ffc93c" stroke="#e09a14" stroke-width="1.2"/>'
        + '<path d="M22 50 Q34 30 44 44" stroke="#ffffff" stroke-width="2.5" stroke-dasharray="3 4" fill="none" stroke-linecap="round"/>'
        + img(H[0], 32, 22, 28, 28) + '</svg>';
    },
  };

  // main-menu.js asks for its games list here (patched in by webgame/patches.mjs)
  // (no list from the app, e.g. the page opened in a browser: null, and the menu keeps the design's own games)
  App.menuGames = function (SQUISH) {
    var list = App.state && App.state.games;
    if (!list || !list.length) return null;
    return [SQUISH].concat(list.map(function (g) {
      return { id: g.id, name: g.name, item: g.item, best: g.best, color: g.color || '#8a5cf6', open: g.open !== false, app: true, icon: ICONS[g.id] ? ICONS[g.id]() : '' };
    }));
  };
  Object.defineProperty(App, 'gamesNote', { get: function () { return (App.state && App.state.gamesNote) || null; } });

  // ---- the Main Menu instance (MainMenu.mount's result), for .games('yard') ----
  var MM = null;
  function hookMenu(v) {
    if (!v || v.__squishHook || !v.mount) return;
    v.__squishHook = 1;
    var mount = v.mount;
    v.mount = function () { var inst = mount.apply(this, arguments); App.menu = inst; return inst; };
  }
  try {
    Object.defineProperty(window, 'MainMenu', { configurable: true, enumerable: true, get: function () { return MM; }, set: function (v) { MM = v; hookMenu(v); } });
  } catch (e) { /* defined already */ }

  // ---- the Yard Games button: in the house, only in the backyard ----
  // (inside .mm-root: the menu's colours and gold rims are its CSS variables)
  var BTN_CSS = '.sq-yard-wrap{position:absolute!important;right:22px;top:14px;z-index:6;}'
    // the MY HOUSE tab's look (main-menu.js .mm-tab v-gold), a little bigger: it's the backyard's one button
    + '.sq-yard{height:34px;padding:0 15px;display:flex;align-items:center;gap:6px;cursor:pointer;border:0;}'
    + '.sq-yard svg{width:16px;height:16px;flex:none;}.sq-yard span{font:700 14px Fredoka,sans-serif;color:#3d1268;letter-spacing:.6px;}'
    + '.sq-yard:active{transform:translateY(2px);}'
    // a game just bought: NEW on the button's corner (2026-11-18), until the Yard Games are opened
    + '.sq-yard{position:relative;}'
    + '.sq-yard-b{position:absolute;right:-10px;top:-11px;padding:3px 7px 2px;border-radius:999px;background:linear-gradient(180deg,#ff8a9e,#ff3d64);border:2px solid #ffffff;box-shadow:0 2px 0 #8e1030;'
    + 'font:700 11px/1 Fredoka,sans-serif;letter-spacing:.5px;color:#ffffff;text-shadow:0 1px 0 #8e1030;pointer-events:none;animation:sqYardB 1.4s ease-in-out infinite;}'
    + '@keyframes sqYardB{0%,100%{transform:scale(1);}50%{transform:scale(1.14);}}';
  var PAD = 'M6 9h12a3 3 0 0 1 3 3v2a3 3 0 0 1-5.4 1.8L14.5 14h-5l-1.1 1.8A3 3 0 0 1 3 14v-2a3 3 0 0 1 3-3Z M8 11v2 M7 12h2 M15.5 11.5h.01 M17 13h.01';
  var btn = null, wrap = null;
  function ensureBtn(parent) {
    if (wrap && wrap.parentNode === parent) return wrap;
    if (!document.getElementById('sq-yard-css')) { var st = document.createElement('style'); st.id = 'sq-yard-css'; st.textContent = BTN_CSS; document.head.appendChild(st); }
    if (wrap) wrap.remove();
    wrap = document.createElement('div');
    wrap.className = 'mm-root sq-yard-wrap';
    btn = document.createElement('button');
    btn.className = 'sq-yard mm-tab mm-p tip v-gold';
    btn.setAttribute('aria-label', 'Yard Games');
    btn.innerHTML = '<svg viewBox="0 0 24 24" fill="none" stroke="#3d1268" stroke-width="2.5" stroke-linecap="round" stroke-linejoin="round"><path d="' + PAD + '"/></svg><span>YARD GAMES</span>';
    btn.onclick = function (e) { e.stopPropagation(); if (App.menu && App.menu.games) App.menu.games('yard'); };
    wrap.appendChild(btn);
    parent.appendChild(wrap);
    return wrap;
  }
  function tick() {
    var sh = window.__sh, inHouse = document.querySelector('.mm-house-in');
    var s = sh && sh.state;
    var show = !!(inHouse && s && s.ready && s.cur === 'backyard' && !s.map && !s.shop && !s.edit && !s.det && !s.party && document.querySelector('.mm-hback'));
    if (show) ensureBtn(inHouse).style.display = '';
    else if (wrap) wrap.style.display = 'none';
    // the NEW badge: how many games were bought since the Yard Games were last opened
    if (btn) {
      var n = typeof newList === 'function' ? newList().length : 0, b = btn.querySelector('.sq-yard-b');
      if (n && !b) { b = document.createElement('i'); b.className = 'sq-yard-b'; btn.appendChild(b); }
      if (b) { if (n) b.textContent = n > 1 ? n + ' NEW' : 'NEW'; else b.remove(); }
    }
  }
  setInterval(tick, 300);

  // ---- the Yard Games page (2026-11-18, the user: "in the menu of the yard games I want it to be in horizontal and put
  // the images of the games on them (on all of them) and make the list of the games scrollable, I want the game to be
  // unlocked only when the game got purchased") ----
  // A yard game opens once one of its toys is bought in the house's Backyard (the house catalog's YRD rows; bought =
  // the house's owned['R:<id>'] > 0). The ids are the catalog's today; rows whose name matches are counted too, so a
  // new hoop or slide in the catalog opens its game as well.
  var YARD_ITEMS = { hoop: ['YRD-102'], soccer: ['YRD-104'], hop: ['YRD-101'], tramp: ['YRD-120', 'YRD-121'], slide: ['YRD-123', 'YRD-124', 'YRD-125'], corn: ['YRD-037'], pong: ['YRD-057'] };
  var YARD_RE = { hoop: /basketball hoop/i, soccer: /soccer goal/i, hop: /hopscotch/i, tramp: /trampoline/i, slide: /\bslide\b/i, corn: /cornhole/i, pong: /ping-?pong|table tennis/i };
  var idCache = {};   // (per game, for the catalog rows it was worked out from: the catalog asks on every draw)
  function yardIds(id) {
    var sh = window.__sh, rows = sh && sh.rows, re = YARD_RE[id], c = idCache[id];
    if (c && c.rows === rows) return c.ids;
    var ids = (YARD_ITEMS[id] || []).slice();
    if (rows && re) rows.forEach(function (r) { if (r && r.room === 'YRD' && re.test(r.name || '') && ids.indexOf(r.id) < 0) ids.push(r.id); });
    idCache[id] = { rows: rows, ids: ids };
    return ids;
  }
  // what the player owns in the house: the live house's, else its save (the menu without the house)
  function houseOwned() {
    var sh = window.__sh;
    if (sh && !sh.dead && sh.H && sh.H.owned) return sh.H.owned;
    try { var h = JSON.parse(localStorage.getItem('ssHouse5b') || 'null'); return (h && h.owned) || {}; } catch (e) { return {}; }
  }
  App.yardLocked = function (id) {
    if (!YARD_ITEMS[id]) return false;
    var own = houseOwned();
    return !yardIds(id).some(function (i) { return (own['R:' + i] || 0) > 0; });
  };
  // the cheapest toy that opens it (the catalog row: name, cost, lv), when the house's catalog is loaded
  function yardToy(id) {
    var sh = window.__sh, by = sh && sh.byId, best = null;
    if (!by || !by.get) return null;
    yardIds(id).forEach(function (i) { var r = by.get(i); if (r && (!best || r.cost < best.cost)) best = r; });
    return best;
  }
  function yardNeedText(id) {
    var t = yardToy(id);
    // (the name the catalog shows it under)
    var nm = t && ((window.RenoShort && window.RenoShort[t.id]) || t.name);
    return t ? 'Buy ' + nm + ' in the Backyard catalog' + (t.cost ? ' (' + Number(t.cost).toLocaleString('en-US') + ' coins)' : '') : 'Buy it in the Backyard catalog to play';
  }
  App.yardNeed = function (id) { return yardNeedText(id); };

  // ---- the toys are bought, never placed (2026-11-18, the user: "in the yard, the games, they will not be placable,
  // they will be purchasable and each game that is purchased will unlock in the yard games icon on the top right
  // corner"). The house asks these (patches.mjs, Squad House v6): ----
  var GAME_NAMES = { hoop: 'Hoop Shot', soccer: 'Penalty Kick', hop: 'Hopscotch', tramp: 'Bounce Up', slide: 'Slide & Splash', corn: 'Cornhole', pong: 'Ping-Pong' };
  var ITEM_GAME = {};
  Object.keys(YARD_ITEMS).forEach(function (g) { YARD_ITEMS[g].forEach(function (i) { ITEM_GAME[i] = g; }); });
  function gameKey(id, row) {
    var g = ITEM_GAME[String(id || '').replace(/^R:/, '')];
    if (!g && row && (row.room === 'YRD' || row.room === 'backyard')) {
      var nm = row.name || row.n || '';
      for (var k in YARD_RE) if (YARD_RE[k].test(nm)) { g = k; break; }
    }
    return g || null;
  }
  // the yard game a house item opens, or null: { id, name, open } (open: the game is unlocked already, by this toy or
  // another of its toys). id: the house's item id ('R:YRD-102' or 'YRD-102'); row (optional): its catalog row, so a new
  // hoop or slide in the catalog counts by its name
  App.yardGameOf = function (id, row) {
    var g = gameKey(id, row);
    if (!g) return null;
    var G = window.YardGames && window.YardGames.GAMES && window.YardGames.GAMES.filter(function (x) { return x.id === g; })[0];
    return { id: g, name: (G && G.name) || GAME_NAMES[g], open: !App.yardLocked(g) };
  };
  // the house's rooms without the yard games' toys (one placed before this rule is taken out; it stays bought)
  App.yardStrip = function (rooms) {
    var out = {};
    Object.keys(rooms || {}).forEach(function (rk) {
      var L = rooms[rk];
      out[rk] = Array.isArray(L) ? L.filter(function (it) { return !(it && gameKey(it.t)); }) : L;
    });
    return out;
  };
  // a game just bought: the YARD GAMES button shows a NEW badge until the Yard Games are opened
  var NEWK = 'squishsquad.yard.new.v1';
  function newList() { try { var a = JSON.parse(localStorage.getItem(NEWK) || '[]'); return Array.isArray(a) ? a : []; } catch (e) { return []; } }
  App.yardNew = function (id) {
    var a = newList();
    if (a.indexOf(id) < 0) a.push(id);
    try { localStorage.setItem(NEWK, JSON.stringify(a)); } catch (e) { /* full */ }
    tick();
  };
  function yardSeen() { try { localStorage.removeItem(NEWK); } catch (e) { /* none */ } }

  var YCSS = '.mm-gr.sq-yg{scroll-snap-type:none;touch-action:none;cursor:grab;gap:18px;padding:12px 26px 20px;}'
    + '.mm-gr.sq-yg.drag{cursor:grabbing;}'
    + '.mm-gc.sq-ygc{width:316px;height:262px;padding:8px 8px 10px;}'
    + '.mm-gc.sq-ygc .win{height:146px;}'
    + '.mm-gc.sq-ygc .win svg{width:100%;height:100%;display:block;}'
    + '.mm-gc.sq-ygc .row{display:flex;align-items:center;justify-content:space-between;align-self:stretch;gap:8px;margin-top:10px;padding:0 4px;}'
    + '.mm-gc.sq-ygc .row .nm{margin:0;}.mm-gc.sq-ygc .row .best{margin:0;flex:none;}'
    + '.mm-gc.sq-ygc .it{align-self:flex-start;padding:0 6px;margin-top:1px;}'
    + '.mm-gc.sq-ygc .go{width:62%;}'
    + '.mm-gc.sq-ygc.lock{filter:none;}'
    + '.mm-gc.sq-ygc.lock .win>svg{filter:saturate(.3) brightness(.78);}'
    + '.mm-gc.sq-ygc .padlock{position:absolute;right:8px;top:8px;width:34px;height:34px;border-radius:50%;background:rgba(40,16,4,.6);display:flex;align-items:center;justify-content:center;box-shadow:0 0 0 2px #ffd76a;}'
    + '.mm-gc.sq-ygc .padlock svg{width:18px!important;height:18px!important;}'
    + '.mm-gc.sq-ygc .need{margin-top:auto;align-self:stretch;display:flex;align-items:center;justify-content:center;gap:7px;min-height:36px;padding:4px 10px;border-radius:12px;background:rgba(40,16,4,.45);box-shadow:inset 0 0 0 1px rgba(255,236,170,.5);font:800 11px/1.25 Nunito,sans-serif;color:#fff3d6;text-align:center;}';
  var PADLOCK = '<svg viewBox="0 0 24 24" fill="none" stroke="#ffe9a8" stroke-width="2.6" stroke-linecap="round" stroke-linejoin="round"><rect x="5" y="11" width="14" height="10" rx="2.5"/><path d="M8 11V8a4 4 0 0 1 8 0v3"/></svg>';
  function yardCss() { if (document.getElementById('sq-yg-css')) return; var st = document.createElement('style'); st.id = 'sq-yg-css'; st.textContent = YCSS; document.head.appendChild(st); }

  // a game's card: its poster across the top (drawn in by yardPage), its name and best, its toy, PLAY or what to buy
  App.yardCard = function (g, o) {
    yardCss();
    var col = g.color || '#ff8a3d', op = o.open, sh = o.shade;
    var need = !o.backyard ? 'Opens with the Backyard at level ' + o.lv : yardNeedText(g.id);
    return '<div class="mm-gc mm-p sq-ygc' + (op ? '' : ' lock') + '" data-g="' + g.id + '" style="--gc:' + col + ';--gcl:' + sh(col, 0.35) + ';--gcd:' + sh(col, -0.42) + '">'
      + '<div class="win" data-poster="' + g.id + '">' + (g.icon || '') + (op ? '' : '<i class="padlock">' + PADLOCK + '</i>') + '</div>'
      + '<div class="row"><div class="nm">' + o.ft(g.name, 'white', 18) + '</div><div class="best">' + (o.best ? '★ Best ' + o.best : op ? 'New!' : 'Locked') + '</div></div>'
      + '<div class="it">' + o.esc(g.item || '') + '</div>'
      + (op ? '<button class="go mm-p tip v-gold">' + o.ft('PLAY', 'whiteB', 17) + '</button>' : '<div class="need">' + o.esc(need) + '</div>')
      + '</div>';
  };

  // ---- the yard games' popups in the app's look (2026-11-18, the user: "change the popups of the yard mini games to
  // match the ones in the app"): the intro's how-to sheet and the results card become the app's cards (squishdoku/
  // Overlays.js: cream paper, a white rim, a brown ink outline and lip), their titles its outlined lettering
  // (OutlinedTitle: gradient fill, white outline, brown halo, a deep drop), the rules numbered in orange discs (Squish
  // Hop's how-to), the buttons its SdButton (gold for the main one, cream for the other), and the back buttons its
  // orange back orb. Sizes in cqh: the game's frame is 360 high, so 1cqh is a 3.6th of the design's px. Scoped to the
  // games inside the menu's page (.mm-gp), on top of yard-games.js's own styles (:not(.yg-port) outranks them). ----
  var P = '.mm-gp .yg-frame:not(.yg-port) ';
  var INK = '#5b3418', BROWN = '#6b4426';
  var GOLD_BTN = 'background:linear-gradient(180deg,#fff7b0 0%,#ffd23a 50%,#ff9c0a 100%);box-shadow:0 0 0 0.75cqh #9c4d06,0 1.5cqh 0 0.75cqh #9c4d06;color:#ffffff;'
    + 'text-shadow:-.45cqh 0 0 #9c4d06,.45cqh 0 0 #9c4d06,0 -.45cqh 0 #9c4d06,0 .45cqh 0 #9c4d06,-.32cqh -.32cqh 0 #9c4d06,.32cqh -.32cqh 0 #9c4d06,-.32cqh .32cqh 0 #9c4d06,.32cqh .32cqh 0 #9c4d06;';
  var CREAM_BTN = 'background:linear-gradient(180deg,#ffffff 0%,#fff6e8 50%,#f3dfbd 100%);box-shadow:0 0 0 0.75cqh ' + BROWN + ',0 1.5cqh 0 0.75cqh ' + BROWN + ';color:' + BROWN + ';text-shadow:none;';
  var CARD = 'background:linear-gradient(180deg,#fffaf0 0%,#fff1dc 55%,#f6e2c4 100%);border:0.85cqh solid #ffffff;box-shadow:0 0 0 0.85cqh ' + BROWN + ',0 2.2cqh 0 0.85cqh ' + BROWN + ',0 5cqh 12cqh rgba(40,16,4,.35);';
  var BACK = 'background:linear-gradient(180deg,#ffc58a 0%,#ff9a4a 55%,#e0601c 100%);border:0.7cqh solid #ffffff;color:#ffffff;box-shadow:0 0 0 0.6cqh #8a3a0e,0 1.1cqh 0 0.6cqh #8a3a0e;'
    + 'text-shadow:0 .3cqh 0 #8a3a0e;font-weight:700;display:flex;align-items:center;justify-content:center;';
  var YPOP = ''
    // the dim behind a card (the app's warm brown), the results card
    + P + '.yg-ov:not(.yg-intro){background:rgba(50,24,6,.55);}'
    + P + '.yg-card{' + CARD + 'border-radius:8cqh;padding:3.6cqh 6cqh 4.6cqh;}'
    // titles: the app's lettering (an SVG, yardPopup)
    + P + '.sq-ttl{display:block;width:100%;overflow:visible;}'
    + P + '.yg-res-t{line-height:0;color:transparent;}'
    // stars: gold with a brown edge; the missed ones pale
    + P + '.yg-star{color:#eadbc6;text-shadow:0 0 0 transparent,-.4cqh 0 0 #c9b293,.4cqh 0 0 #c9b293,0 -.4cqh 0 #c9b293,0 .6cqh 0 #c9b293;}'
    + P + '.yg-star.on{color:#ffd23a;text-shadow:-.45cqh 0 0 #9c4d06,.45cqh 0 0 #9c4d06,0 -.45cqh 0 #9c4d06,0 .9cqh 0 #9c4d06;}'
    + P + '.yg-res-score{font:700 12cqh/1 Fredoka,sans-serif;color:#8a3a0e;}'
    + P + '.yg-res-sub{font:800 3.6cqh/1.3 Nunito,sans-serif;color:#9a6a3a;}'
    // the coins line: the app's reward row (the coin, then the amount in amber)
    + P + '.yg-res-coins{display:inline-flex;align-items:center;gap:1.4cqh;background:none;padding:0;margin:2.4cqh 0 3.6cqh;font:700 4.6cqh/1 Fredoka,sans-serif;color:#b86200;}'
    + P + '.yg-res-coins img{width:6.6cqh;height:6.6cqh;object-fit:contain;}'
    + P + '.yg-row{gap:3cqh;}'
    // the buttons: the app's SdButton (gold, or cream with brown lettering), a white edge, a darker ring and lip
    + P + '.yg-btn{position:relative;overflow:hidden;isolation:isolate;border:0.85cqh solid #ffffff;border-radius:99px;padding:2.6cqh 6cqh;font:700 5cqh/1 Fredoka,sans-serif;letter-spacing:.03em;text-transform:uppercase;' + GOLD_BTN + '}'
    + P + '.yg-btn::before{content:"";position:absolute;left:8%;right:8%;top:.5cqh;height:42%;border-radius:99px;background:rgba(255,255,255,.45);pointer-events:none;z-index:-1;}'
    + P + '.yg-btn:active{transform:translateY(1cqh) scale(.95);box-shadow:0 0 0 0.75cqh #9c4d06,0 .5cqh 0 0.75cqh #9c4d06;}'
    + P + '.yg-ghost{' + CREAM_BTN + '}'
    + P + '.yg-ghost:active{box-shadow:0 0 0 0.75cqh ' + BROWN + ',0 .5cqh 0 0.75cqh ' + BROWN + ';}'
    // the intro's how-to sheet: an app card down the right
    + P + '.yg-isheet{' + CARD + 'border-radius:8cqh;padding:3cqh 5cqh 4cqh;}'
    + P + '.yg-ihead{display:block;color:transparent;line-height:0;}'
    + P + '.yg-ihead::before,' + P + '.yg-ihead::after{display:none;}'
    // the rules: numbered orange discs, brown words (Squish Hop's how-to)
    + P + '.yg-isheet .yg-how{list-style:none;counter-reset:sqr;padding:0;margin:2.2cqh 0 .6cqh;display:flex;flex-direction:column;gap:1.6cqh;font:800 3.4cqh/1.32 Nunito,sans-serif;color:' + INK + ';}'
    + P + '.yg-isheet .yg-how li{counter-increment:sqr;display:flex;align-items:flex-start;gap:2.2cqh;margin:0;}'
    + P + '.yg-isheet .yg-how li::before{content:counter(sqr);flex:none;width:7cqh;height:7cqh;margin-top:-.4cqh;border-radius:50%;box-sizing:border-box;background:#ff8a3d;border:.7cqh solid #ffffff;box-shadow:0 0 0 .35cqh #e0601c;display:flex;align-items:center;justify-content:center;font:700 3.6cqh/1 Fredoka,sans-serif;color:#ffffff;}'
    + P + '.yg-isheet .yg-go{margin-top:3cqh;padding:2.8cqh 12cqh;font-size:5.6cqh;}'
    + P + '.yg-best{font:800 3.2cqh/1 Nunito,sans-serif;color:#9a6a3a;}'
    // the game's options (e.g. the slide's look): cream chips, the chosen one gold
    + P + '.yg-opt{border:.6cqh solid #ffffff;box-shadow:0 0 0 .4cqh ' + BROWN + ';background:#fff6e8;color:' + BROWN + ';font:800 3.2cqh/1 Nunito,sans-serif;}'
    + P + '.yg-opt.on{background:linear-gradient(180deg,#fff7b0,#ffd23a 50%,#ff9c0a);box-shadow:0 0 0 .4cqh #9c4d06;color:#7a3a04;}'
    // the back buttons (the intro's and the game's top bar): the app's orange back orb
    + P + '.yg-iback,' + P + '.yg-back{' + BACK + '}'
    + P + '.yg-iback:active,' + P + '.yg-back:active{transform:translateY(.6cqh);}';
  function yardPopCss() { if (document.getElementById('sq-ypop-css')) return; var st = document.createElement('style'); st.id = 'sq-ypop-css'; st.textContent = YPOP; document.head.appendChild(st); }

  // the app's outlined title (OutlinedTitle) as SVG: a deep drop, a brown halo, a white outline, the gradient letters;
  // size in cqh of the game's frame
  var tUid = 0;
  var FILLS = { gold: ['#fffbd6', '#ffe045', '#ff9500'], orange: ['#fff0d6', '#ffb05a', '#e8681c'] };
  function escT(s) { return String(s).replace(/[&<>"]/g, function (c) { return { '&': '&amp;', '<': '&lt;', '>': '&gt;', '"': '&quot;' }[c]; }); }
  function sqTitle(text, fill, size) {
    var id = 'sqtg' + (++tUid), F = FILLS[fill] || FILLS.gold, T = escT(String(text).toUpperCase());
    var font = 'font:700 ' + size + 'cqh Fredoka,sans-serif;letter-spacing:.03em;';
    var tx = function (style) { return '<text x="50%" y="' + (size * 1.06) + 'cqh" text-anchor="middle" style="' + font + style + '">' + T + '</text>'; };
    var w = function (k) { return 'stroke-width:' + (size * k).toFixed(2) + 'cqh;stroke-linejoin:round;'; };
    return '<svg class="sq-ttl" role="img" aria-label="' + T + '" style="height:' + (size * 1.42).toFixed(2) + 'cqh">'
      + '<defs><linearGradient id="' + id + '" x1="0" y1="0" x2="0" y2="1"><stop offset="0" stop-color="' + F[0] + '"/><stop offset=".5" stop-color="' + F[1] + '"/><stop offset="1" stop-color="' + F[2] + '"/></linearGradient></defs>'
      + tx('fill:#3f2412;stroke:#3f2412;' + w(0.34) + 'transform:translateY(' + (size * 0.15).toFixed(2) + 'cqh);')
      + tx('fill:' + BROWN + ';stroke:' + BROWN + ';' + w(0.34))
      + tx('fill:#ffffff;stroke:#ffffff;' + w(0.2))
      + tx('fill:url(#' + id + ');')
      + '</svg>';
  }
  // yard-games.js calls this once a popup is built (patched in): 'intro' = the how-to sheet, 'result' = the results card
  App.yardPopup = function (el, kind, stars) {
    if (!el || !el.closest || !el.closest('.mm-gp')) return;   // only the games inside the app's page
    yardPopCss();
    if (kind === 'intro') {
      var h = el.querySelector('.yg-ihead');
      if (h) h.innerHTML = sqTitle('How to play', 'gold', 6.4);
    } else if (kind === 'result') {
      var t = el.querySelector('.yg-res-t');
      if (t) t.innerHTML = sqTitle(t.textContent, stars >= 3 ? 'gold' : 'orange', 8.4);
      var c = el.querySelector('.yg-res-coins'), src = window.SquishCoin && window.SquishCoin.coin && window.SquishCoin.coin(0);
      if (c && src && !c.querySelector('img')) c.insertAdjacentHTML('afterbegin', '<img alt="" src="' + src + '">');
    }
  };

  // after the page is up: each card gets its game's intro poster (yg-intros.js, your character in it), and the list
  // drags sideways (finger or mouse, with a glide), a drag never counting as a tap on a card
  App.yardPage = function (p, gr, G, c) {
    yardCss();
    yardPopCss();
    yardSeen();   // the NEW badge goes once the games are seen
    gr.classList.add('sq-yg');
    var YG = window.YardGames, Q = window.SquishSquad, T = window.SQ_THUMBS || {};
    var s = c && Q && Q.src ? Q.src(c.id) : '', src = T[s] || s;
    var wins = [].slice.call(p.querySelectorAll('.sq-ygc .win[data-poster]'));
    // PERF 2026-11-20: the page is on screen first (its cards, their frames), the posters go in right after its first
    // frame, one per slice (app/perf.js SquishPerf.slices), as its fade-in starts: the tap no longer waits for all seven
    // posters to be drawn
    var poster = function (win, i) {
      if (!win.isConnected) return false;
      var id = win.getAttribute('data-poster'), PO = YG && YG.POSTER && YG.POSTER[id];
      if (!PO) return;
      var art = '';
      try { art = PO('sqyc' + id + '_', { src: src, name: c ? c.name : '' }); } catch (e) { console.warn('[yard card]', id, e); }
      if (!art) return;
      var lock = win.querySelector('.padlock');
      win.innerHTML = art;
      if (lock) win.appendChild(lock);
      // the live character goes in one card at a time (each is a rig for ~1 s, then a still)
      if (YG.posterRig && c && c.key) setTimeout(function () { if (win.isConnected) try { YG.posterRig(win, c.key, {}); } catch (e) { console.warn('[yard card rig]', id, e); } }, 120 + i * 180);
    };
    if (window.SquishPerf && window.SquishPerf.slices) window.SquishPerf.slices(wins.map(function (win, i) { return function () { return poster(win, i); }; }), 4);
    else wins.forEach(poster);
    var down = null, dragged = false, vel = 0, lastX = 0, lastT = 0, raf = 0;
    var scale = function () { return (gr.getBoundingClientRect().width / gr.offsetWidth) || 1; };
    gr.addEventListener('pointerdown', function (e) {
      if (e.button > 0) return;
      cancelAnimationFrame(raf);
      down = { x: e.clientX, s: gr.scrollLeft, id: e.pointerId, k: scale() };
      dragged = false; vel = 0; lastX = e.clientX; lastT = performance.now();
    });
    gr.addEventListener('pointermove', function (e) {
      if (!down || e.pointerId !== down.id) return;
      var dx = e.clientX - down.x;
      if (!dragged && Math.abs(dx) > 8) { dragged = true; gr.classList.add('drag'); try { gr.setPointerCapture(e.pointerId); } catch (x) { /* gone */ } }
      if (!dragged) return;
      gr.scrollLeft = down.s - dx / down.k;
      var now = performance.now();
      vel = (e.clientX - lastX) / Math.max(1, now - lastT) / down.k; lastX = e.clientX; lastT = now;
    });
    var end = function () {
      if (!down) return;
      down = null; gr.classList.remove('drag');
      if (!dragged) return;
      var v = -vel * 16;
      (function glide() { if (Math.abs(v) < 0.4 || !gr.isConnected) return; gr.scrollLeft += v; v *= 0.93; raf = requestAnimationFrame(glide); })();
    };
    gr.addEventListener('pointerup', end);
    gr.addEventListener('pointercancel', end);
    // a drag isn't a tap: swallow the click it ends with
    gr.addEventListener('click', function (e) { if (dragged) { e.stopPropagation(); e.preventDefault(); dragged = false; } }, true);
  };
})();
