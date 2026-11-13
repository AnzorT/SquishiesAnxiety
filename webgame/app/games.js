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
    + '.sq-yard:active{transform:translateY(2px);}';
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
  }
  setInterval(tick, 300);
})();
