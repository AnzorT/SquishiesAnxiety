// The yard games' host side, compiled with the rig (tools/unity/rig/jsc.mjs) so the app's own yard games (yard-games.js
// v6, yg-intros.js, yg-*.js, as webgame/build.mjs builds them with webgame/patches.mjs) run in Unity on the browser
// stand-in: Games/Yard/YardJs.cs calls __yard, Games/Yard/View/YardScreen.cs draws what it reads back. A game is opened
// as the app's menu page opens one (main-menu.js playGame: YardGames.mount, the menu's creature picked on the strip,
// app.play), and runs on the one virtual clock (requestAnimationFrame) with the creatures.
//   open(id, key)      the game with the creature `key` (when it's one the yard games take); false if there's no such game
//   stage()            the stage's layers bottom to top (the <svg>s, the creature layers, the HUD, the cards: elements)
//   ui()               the words and states Unity draws itself, as JSON: the top bar, the hint, the games' own pills and
//                      buttons, the toasts (each with an id of its own), the intro's sheet, the results card
//   pointer(t, x, y)   a finger on the stage (stage units): the game's input layer gets pointerdown / move / up
//   click(el) / press(el)   a card's button (the intro's PLAY and options, the results' buttons, the back orbs) / one of
//                      a game's own buttons (Hopscotch's, on pointerdown)
//   sfx()              the synth sounds asked for since the last call (YardGames.SFX names: Unity plays its own clips)
//   closed()           whether the game went back to the hub (its back orb, YARD GAMES): Unity closes it
//   saved()            the bests and plays (localStorage yardgames.v1), to keep on the device
// The saved bests come in before yard-games.js reads them: Unity hands them over as the file 'local/yardgames.v1'.
// Plain ES2017.
(function (G) {
  'use strict';
  try { var s0 = G.__readFile && G.__readFile('local/yardgames.v1'); if (s0) G.localStorage.setItem('yardgames.v1', s0); } catch (e) { /* none yet */ }
  var root = null, app = null, closed = true, sfx = [], hooked = false, tid = 0;
  var f0 = function () {};
  function Y() { return G.YardGames; }
  function q(sel) { return root ? root.querySelector(sel) : null; }
  function ev(type, x, y) { return { type: type, clientX: x || 0, clientY: y || 0, pointerId: 1, button: 0, preventDefault: f0, stopPropagation: f0 }; }
  function txt(el) { return el ? el.textContent : ''; }
  function cls(el, c) { return !!(el && el.classList && el.classList.contains(c)); }
  // the synth sounds as names (the stand-in has no AudioContext: the page's would be silent)
  function hook() {
    var y = Y(); if (!y || hooked) return; hooked = true;
    Object.keys(y.SFX).forEach(function (k) { y.SFX[k] = function () { sfx.push(k); }; });
  }
  // a style length in % of the stage (the creatures' boxes, the toasts' places)
  function pc(v) { var n = parseFloat(v); return isNaN(n) ? 0 : n; }

  G.__yard = {
    open: function (id, key) {
      hook();
      var y = Y(); if (!y || !y.mount) return false;
      var g = y.GAMES.filter(function (x) { return x.id === id; })[0]; if (!g) return false;
      if (!root) { root = document.createElement('div'); root.className = 'sq-yard-host'; document.body.appendChild(root); }
      sfx = [];
      app = y.mount(root);
      // the player: the menu's creature, picked on the hub's strip as main-menu.js does (when it's one the yard takes)
      var SQ = G.SquishSquad, c = SQ && SQ.ROSTER ? SQ.ROSTER.filter(function (x) { return x && x.key === key; })[0] : null;
      if (c) { var picks = root.querySelectorAll('.yg-pick'); for (var i = 0; i < picks.length; i++) if (picks[i].title === c.name) { picks[i].dispatchEvent(ev('click')); break; } }
      var hub0 = app.hub; app.hub = function () { hub0(); closed = true; };
      closed = false;
      app.play(g);
      return true;
    },
    close: function () { if (app && !closed) { try { app.hub(); } catch (e) { /* as the page */ } } closed = true; },
    closed: function () { return closed; },
    stage: function () { var st = q('.yg-stage'); return st ? st.childNodes : []; },
    // a creature's host: its box (% of the stage), its turn about (ox, oy) % of its box, its depth, hidden
    box: function (h) {
      var s = h.style, m = /rotate\(([-\d.e]+)deg\)/.exec(s.transform || ''), o = (s.transformOrigin || '50% 93%').split(' ');
      return [pc(s.left), pc(s.top), pc(s.width), pc(s.height), m ? +m[1] : 0, pc(o[0]), pc(o[1]), +s.zIndex || 0, s.visibility === 'hidden' ? 1 : 0, s.display === 'none' ? 1 : 0];
    },
    ui: function () {
      var y = Y(), o = { W: y.W, H: y.H };
      var ov = q('.yg-ov'), oc = ov ? ov.className : '';
      o.phase = /yg-show/.test(oc) ? (/yg-intro/.test(oc) ? 'intro' : q('.yg-res') ? 'result' : 'card') : 'play';
      var tm = q('.yg-time');
      o.ttl = txt(q('.yg-ttl')); o.score = txt(q('.yg-score')); o.time = tm && tm.style.display !== 'none' ? txt(tm) : ''; o.hurry = cls(tm, 'yg-hurry');
      o.hint = txt(q('.yg-hint'));
      // the games' own: pills (Penalty Kick's marks, Cornhole's wind, Ping-Pong's score) and buttons (Hopscotch)
      o.extra = [];
      var hud = q('.yg-hud');
      if (hud) for (var i = 0; i < hud.childNodes.length; i++) {
        var e = hud.childNodes[i]; if (!e.classList || cls(e, 'yg-top') || cls(e, 'yg-hint')) continue;
        if (cls(e, 'yg-pill')) {
          var spans = [], kids = e.childNodes;
          for (var j = 0; j < kids.length; j++) if (kids[j].nodeType === 1) spans.push([kids[j].textContent, kids[j].style.color || '']);
          o.extra.push({ kind: 'pill', css: e.style.cssText, text: e.textContent, spans: spans });
        } else {
          var bs = [], btns = e.querySelectorAll('button');
          for (var b = 0; b < btns.length; b++) { var ic = btns[b].querySelector('svg'), bl = btns[b].childNodes[btns[b].childNodes.length - 1]; bs.push({ label: bl ? bl.textContent : '', color: btns[b].style.color, css: btns[b].style.cssText, icon: ic ? ic.outerHTML : '' }); }
          o.extra.push({ kind: 'buttons', css: e.style.cssText, buttons: bs });
        }
      }
      // the toasts, each with an id (Unity runs its animation from when it first sees it)
      o.toasts = [];
      var tl = q('.yg-toasts');
      if (tl) for (var t = 0; t < tl.childNodes.length; t++) {
        var te = tl.childNodes[t]; if (!te.__tid) te.__tid = ++tid;
        o.toasts.push({ id: te.__tid, text: te.textContent, x: pc(te.style.left), y: pc(te.style.top), col: te.style.color || '#ffffff', big: cls(te, 'yg-big') });
      }
      if (o.phase === 'intro') {
        var how = [], li = root.querySelectorAll('.yg-isheet .yg-how li'), opts = [], ob = root.querySelectorAll('.yg-isheet .yg-opt');
        for (var k = 0; k < li.length; k++) how.push(li[k].textContent);
        for (var p = 0; p < ob.length; p++) opts.push({ label: ob[p].textContent, on: cls(ob[p], 'on') });
        o.intro = { how: how, opts: opts, best: txt(q('.yg-isheet .yg-best')), color: ov.style.getPropertyValue ? ov.style.getPropertyValue('--gc') : '' };
      } else if (o.phase === 'result') {
        var st = root.querySelectorAll('.yg-res .yg-star.on').length, bt = root.querySelectorAll('.yg-res .yg-btn'), labels = [];
        for (var r = 0; r < bt.length; r++) labels.push(bt[r].textContent);
        // (the title: its text, before or after the app's lettering took it over)
        var te2 = q('.yg-res-t'), svgT = te2 && te2.querySelector('svg');
        o.result = { title: svgT ? svgT.getAttribute('aria-label') : txt(te2), stars: st, score: txt(q('.yg-res-score')), sub: txt(q('.yg-res-sub')), coins: txt(q('.yg-res-coins')), buttons: labels };
      }
      return JSON.stringify(o);
    },
    // the elements Unity's buttons stand for, by what they are
    el: function (what, i) {
      if (what === 'play') return q('.yg-isheet .yg-go');
      if (what === 'iback') return q('.yg-iback');
      if (what === 'back') return q('.yg-back');
      if (what === 'opt') return (root ? root.querySelectorAll('.yg-isheet .yg-opt') : [])[i] || null;
      if (what === 'res') return (root ? root.querySelectorAll('.yg-res .yg-btn') : [])[i] || null;
      if (what === 'btn') { var hud = q('.yg-hud'), all = hud ? hud.querySelectorAll('button') : []; return all[i] || null; }
      if (what === 'art') return q('.yg-iart');
      return null;
    },
    click: function (el) { if (el) el.dispatchEvent(ev('click')); },
    press: function (el) { if (el) el.dispatchEvent(ev('pointerdown')); },
    pointer: function (type, x, y) {
      var inp = q('.yg-input'); if (!inp) return;
      inp.__rect = { left: 0, top: 0, width: Y().W, height: Y().H };
      inp.dispatchEvent(ev(type, x, y));
    },
    sfx: function () { var s = sfx; sfx = []; return s; },
    saved: function () { try { return G.localStorage.getItem('yardgames.v1'); } catch (e) { return null; } },
  };
  // the app's page has window.SquishApp (the patched yard-games.js reads it: the results' YARD GAMES button); its other
  // hooks (yardPopup) restyle the page's own cards, which Unity draws itself. (rig-look.js read it at its load, before
  // this: the rigs keep their own looks.)
  G.SquishApp = G.SquishApp || {};
})(typeof globalThis !== 'undefined' ? globalThis : this);
